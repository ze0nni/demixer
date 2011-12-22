using System;
using FlickrNet;
using System.IO;
using System.Net;
using DeMixer.lib;

namespace DeMixer.Source.Flickr {	
		
	public partial class FlickrSelectGUDialog : Gtk.Dialog {			
		
		IDeMixerKernel Kernel;
		Gtk.ListStore FoundListStore = null;
		FlickrSource.SearchMode Mode = FlickrSource.SearchMode.Group;
				
		public FlickrSelectGUDialog(IDeMixerKernel k, string t, Gtk.Window w, FlickrSource.SearchMode m) : base(t, w, Gtk.DialogFlags.Modal) {
			this.Build();
			Kernel = k;
			Mode = m;
			
			FoundListStore = new Gtk.ListStore (typeof (string));
			
			Gtk.TreeViewColumn columnLogo = new Gtk.TreeViewColumn ();			
			
			Gtk.TreeViewColumn columnTitle = new Gtk.TreeViewColumn ();
			columnTitle.Title = "Title";			
			Gtk.CellRendererText titleTextCell = new Gtk.CellRendererText();			
			columnTitle.PackStart(titleTextCell, true);
			columnTitle.AddAttribute(titleTextCell, "text", 0);
						
			FoundenList.AppendColumn(columnTitle);
			
			FoundenList.Model = FoundListStore;
		}
		
		#region update found		
		int startUpdateFoundListTick = 0;
		void startUpdateFoundList() {			
			if (startUpdateFoundListTick == Environment.TickCount) return;
			startUpdateFoundListTick = Environment.TickCount;
			new System.Threading.Thread((System.Threading.ThreadStart) delegate {				
				int t = startUpdateFoundListTick;
				System.Threading.Thread.Sleep(150);
				if (t != startUpdateFoundListTick) return;
				new System.Threading.Thread((System.Threading.ThreadStart)updateFoundList).Start();
			}).Start();
		}
					
		GroupSearchResultCollection lastGroupRes = null;		
		void updateFoundList() {
			int t = startUpdateFoundListTick;
			try {
				//Show loading message
				Gtk.Application.Invoke(delegate {
					foreach (Gtk.Widget w in previewHBox.AllChildren)
						w.Destroy();
					previewHBox.Add(new Gtk.Label(Kernel.Translate("Loading...")));
					previewHBox.ShowAll();	
				});
				
				
				string sText = searchText.Text;
				FlickrNet.Flickr f = new FlickrNet.Flickr(FlickrSource.FlickrApiPublicKey);
				switch (Mode) {
				case FlickrSource.SearchMode.Group:
					
					if (t != startUpdateFoundListTick) return;
					System.Threading.Thread.Sleep(50);
					GroupSearchResultCollection res = f.GroupsSearch(sText);
					if (t != startUpdateFoundListTick) return;
					
					Gtk.Application.Invoke(delegate {						
						FoundListStore.Clear();
						foreach (GroupSearchResult g in res) {							
							FoundListStore.AppendValues(g.GroupName);							
						}
						lastGroupRes = res;
						FoundenList.ShowAll();
						//hede loading message
						foreach (Gtk.Widget w in previewHBox.AllChildren)
							w.Destroy();					
					});
					break;
				case FlickrSource.SearchMode.User:					
					break;
				}
			} catch {
			}
		}
		
		#endregion
		
		#region update images
		int startUpdateImagesTick = 0;
		void startUpdateImages() {
			if (startUpdateImagesTick == Environment.TickCount) return;
			startUpdateImagesTick = Environment.TickCount;
			int t = startUpdateImagesTick;
			System.Threading.Thread.Sleep(150);
			if (t != startUpdateImagesTick) return;	
			new System.Threading.Thread((System.Threading.ThreadStart)updateImages).Start();
		}
		
		void updateImages() {									
			try {
				//Show loading message
				Gtk.Application.Invoke(delegate {
					foreach (Gtk.Widget w in previewHBox.AllChildren)
						w.Destroy();
					previewHBox.Add(new Gtk.Label(Kernel.Translate("Loading...")));
					previewHBox.ShowAll();	
				});
				
				FlickrNet.Flickr f = new FlickrNet.Flickr(FlickrSource.FlickrApiPublicKey);
				PhotoSearchOptions op = new PhotoSearchOptions();
				op.GroupId = ActiveGroupID;
				op.PerPage = 5;
				op.Extras |= PhotoSearchExtras.ThumbnailUrl;
				op.Extras |= PhotoSearchExtras.SquareUrl;
				int t = startUpdateImagesTick;
				PhotoCollection res = f.PhotosSearch(op);
				if (t != startUpdateImagesTick) return;				
				
				//Hide message
				Gtk.Application.Invoke(delegate {
					foreach (Gtk.Widget w in previewHBox.AllChildren)
						w.Destroy();					
				});
				
				foreach (Photo p in res) {					
					byte[] rawpix = Kernel.GetWebClient().DownloadData(p.SquareThumbnailUrl);					
						
					Gdk.Pixbuf pix = new Gdk.Pixbuf(new MemoryStream(rawpix));
					Gtk.Application.Invoke(delegate {
						if (t != startUpdateImagesTick) return;	
						Gtk.Image img = new Gtk.Image(pix);
						previewHBox.Add(img);
						previewHBox.ShowAll();
					});
				}
				
				Gtk.Application.Invoke(delegate {
					previewHBox.Add(new Gtk.Label(Kernel.Translate("Total: {0}", res.Total)));
					previewHBox.ShowAll();
				});
			} catch (Exception exc) {
				Gtk.Application.Invoke(delegate {
					foreach (Gtk.Widget w in previewHBox.AllChildren)
						w.Destroy();
					previewHBox.Add(new Gtk.Label(Kernel.Translate("Error\n{0}",exc.Message)));
					previewHBox.ShowAll();	
				});			
			}
		}
		#endregion
		
		protected void 	OnSearchTextChanged(object sender, System.EventArgs e) {
			startUpdateFoundList();
		}
		
		string activeGroupID = "";
		public string ActiveGroupID {
			get { return activeGroupID; }
		}
		
		string activeGroupTitle = "";
		public string ActiveGroupTitle {
			get { return activeGroupTitle; }
		}

		protected void OnFoundenListCursorChanged(object sender, System.EventArgs e) {
			Gtk.TreeIter itr;
								
			if (FoundenList.Selection.GetSelected(out itr)) {
				int i = int.Parse(
					FoundListStore.GetPath(itr).ToString());
				activeGroupID = lastGroupRes[i].GroupId;
				activeGroupTitle = lastGroupRes[i].GroupName;
			} else {
				activeGroupID = "";	
			}
			startUpdateImages();
		}
	}
}

