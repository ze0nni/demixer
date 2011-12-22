using System;
using DeMixer.lib;
using System.Threading;
using FlickrNet;
using System.IO;

namespace DeMixer.Source.Flickr {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class FlickrSourceWiget : Gtk.Bin {
		
		IDeMixerKernel Kernel;
		FlickrSource Source;
		public FlickrSourceWiget(FlickrSource s, IDeMixerKernel k) {
			this.Build();
			Kernel = k;
			Source = s;			
			queryEd.Text = s.SearchQuery;
			if (s.ByTags)
				byTagsCb.Active = true;
			else
				byTextCb.Active = true;			
			switch (Source.SearchByMode) {
				
			case FlickrSource.SearchMode.None:
				byNoneCb.Active = true;
				break;
			case FlickrSource.SearchMode.Group:
				byGroupCb.Active = true;
				break;
			}
			updatePreview();
		}

		protected void OnSelectGUClicked(object sender, System.EventArgs e) {
			Gtk.Widget w = this;
			do {
				w = w.Parent;
			} while (w.Parent != null);
			
			FlickrSelectGUDialog dlg = new FlickrSelectGUDialog(				
				Kernel,
				"", //todo: translate
				(Gtk.Window)w,				
				byGroupCb.Active ?	
					FlickrSource.SearchMode.Group :
					FlickrSource.SearchMode.User
				);
			try {	
				if ((Gtk.ResponseType)dlg.Run() == Gtk.ResponseType.Ok) {
					this.Source.GroupId = dlg.ActiveGroupID;
					this.Source.GroupTitle = dlg.ActiveGroupTitle;
					OnByNoneCbToggled(this, new EventArgs());
					updatePreview();
				}
			} finally {
				dlg.Destroy();	
			}			
		}

		protected void OnByNoneCbToggled(object sender, System.EventArgs e) {
						SelectGU.Sensitive = !byNoneCb.Active;
			if (byNoneCb.Active) {
				SelectGU.Label = "None";
				Source.SearchByMode = FlickrSource.SearchMode.None;
			} else if (byGroupCb.Active) {
				SelectGU.Label = 
					Source.GroupTitle.Length > 0 ?
						Source.GroupTitle : "Select group";
				Source.SearchByMode = FlickrSource.SearchMode.Group;
			} else if (byUserCb.Active) {
				SelectGU.Label = "Select User";
				Source.SearchByMode = FlickrSource.SearchMode.User;
			}
			updatePreview();
		}

		protected void OnQueryEdChanged(object sender, System.EventArgs e) {
			Source.SearchQuery = queryEd.Text;			
			updatePreview();
		}

		protected void OnByTextCbToggled(object sender, System.EventArgs e) {
			Source.ByTags = byTagsCb.Active;
			updatePreview();
			
		}
		
		int updatePreviewTick = 0;
		void updatePreview() {				
			(new Thread((ThreadStart)delegate {
				System.Threading.Thread.Sleep(50);
				if (updatePreviewTick == Environment.TickCount) return;
				updatePreviewTick = Environment.TickCount;
				int t = updatePreviewTick;
				System.Threading.Thread.Sleep(100);
				if (t != updatePreviewTick) return;
				(new Thread(updatePreviewStart)).Start();
			})).Start();
		}
		
		void updatePreviewStart() {			
			int t = updatePreviewTick;
			try {				
				//Show loading message
				Gtk.Application.Invoke(delegate {
					foreach (Gtk.Widget w in previewHBox.AllChildren)
						w.Destroy();
					previewHBox.Add(new Gtk.Label(Kernel.Translate("Loading...")));
					previewHBox.ShowAll();	
				});
				
				FlickrNet.Flickr f = new FlickrNet.Flickr(FlickrSource.FlickrApiPublicKey);
				PhotoSearchOptions opt = new PhotoSearchOptions();
				if (Source.SearchQuery!=null && Source.SearchQuery.Length>0) {
					if (Source.ByTags)
						opt.Tags = Source.SearchQuery;
					else
						opt.Text = Source.SearchQuery;
				}				
				if (Source.SearchByMode == FlickrSource.SearchMode.Group && Source.GroupId.Length>0)
					opt.GroupId = Source.GroupId;
				opt.PerPage = 5;
				opt.Extras |= PhotoSearchExtras.ThumbnailUrl;
				opt.Extras |= PhotoSearchExtras.SquareUrl;				
				PhotoCollection res = f.PhotosSearch(opt);										
				if (t != updatePreviewTick) return;
				//Hide message
				Gtk.Application.Invoke(delegate {
					foreach (Gtk.Widget w in previewHBox.AllChildren)
						w.Destroy();					
				});
				//add preview
				foreach (Photo p in res) {
					if (t != updatePreviewTick) return;
					byte[] rawpix = Kernel.GetWebClient().DownloadData(p.SquareThumbnailUrl);					
						
					Gdk.Pixbuf pix = new Gdk.Pixbuf(new MemoryStream(rawpix));
					Gtk.Application.Invoke(delegate {
						Gtk.Image img = new Gtk.Image(pix);
						previewHBox.Add(img);
						previewHBox.ShowAll();
					});
				}				
				Gtk.Application.Invoke(delegate {
					if (t != updatePreviewTick) return;
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
	}
}

