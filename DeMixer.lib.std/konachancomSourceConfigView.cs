
using System;
using System.Net;
using System.Xml;

namespace DeMixer.lib.std
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class konachancomSourceConfigView : Gtk.Bin
	{
		konachancomSource Source;

		protected virtual void OnTagsEditChanged (object sender, System.EventArgs e) {
			Source.Tags = tagsEdit.Text;
			updateHelpButtons();
		}
		
		IDeMixerKernel Kernel;
		public konachancomSourceConfigView(konachancomSource source, IDeMixerKernel kernel) {
			this.Build();
			Kernel = kernel;
			Source = source;
			kernel.TranslateWidget(this);
			tagsEdit.Text = Source.Tags;
			//tagsEdit.Text = Source.Tags;
//			Gtk.IconSource i = new Gtk.IconSource();			
//			i.IconName = "demixer-character";
//			i.Pixbuf = new Gdk.Pixbuf("/usr/share/demixer/icond.png");			
		}
				
		
		int spaceFromLeft(string str, int p) {
			if (p == 0) return 0;
			if (p > str.Length - 1) p = str.Length - 1;
			while (p > 0 && str[p-1] != ' ') 
				p--;
			return 	p;
		}
		
		int spaceFromRight(string str, int p) {
			if (p == 0) p++;
			if (p > str.Length) return str.Length;
						
			while ((p < str.Length) && str[p] != ' ')
				p++;
			return 	p;
		}
		
		string wordFromPos(string str, int pos) {
			if (str.Length<=1) return str;			
			int l = spaceFromLeft(str, pos);			
			int r = spaceFromRight(str, pos);
			string w = str.Substring(l, r-l);
			return w;	
		}
		
		int updateHelpButtonsTick;
		object updateHelpButtonsSyncObject = new object();
		void updateHelpButtons() {
			int t = 0;
			lock (updateHelpButtonsSyncObject) {
				updateHelpButtonsTick = Environment.TickCount;
				t = updateHelpButtonsTick;
			}
			new System.Threading.Thread((System.Threading.ThreadStart) delegate {
				System.Threading.Thread.Sleep(300);
				//
				if (updateHelpButtonsTick != t) return;				
				string tagatpos = wordFromPos(Source.Tags,
					tagsEdit.CursorPosition);
				if (tagatpos.Length > 0 && tagatpos[0] == '-')
					tagatpos = tagatpos.Remove(0, 1);
				Uri rstr = new Uri(String.Format("http://konachan.com/tag/index.xml?name={0}&order=count&limit=12",
					Uri.EscapeDataString(tagatpos)));
				
				WebClient wc = Kernel.GetWebClient();
				string responce = wc.DownloadString(rstr);
				//
				if (updateHelpButtonsTick != t) return;
				XmlDocument xml = new XmlDocument();
				xml.LoadXml(responce);
				Gtk.Application.Invoke(delegate {
					//Clear buttons
					foreach (Gtk.Widget w in tagsButtonsBox1.AllChildren)
						w.Destroy();
					foreach (Gtk.Widget w in tagsButtonsBox2.AllChildren)
						w.Destroy();
					foreach (Gtk.Widget w in tagsButtonsBox3.AllChildren)
						w.Destroy();
					int i = 0;
					XmlNodeList tags = xml.SelectSingleNode("tags").SelectNodes("tag");
					foreach (XmlNode tag in tags) {			
						/*type:
							General: 0
							artist: 1
							copyright: 3
							character: 4
						*/
						string btntag = tag.Attributes["name"].Value;
						string labelText = String.Format("{0} ({1})",
							btntag.Replace("_", "__"),
							tag.Attributes["count"].Value);
						//type						
						Gtk.Image btnimage = new Gtk.Image();						
						switch (tag.Attributes["type"].Value) {
						case "1":
							//artist
							//btnimage.IconName = "demixer-artist";
							break;
						case "2":
							//copyright							
							//btnimage.IconName = "demixer-copyright";
							break;
						case "3":
							//character
							//btnimage.IconName = "demixer-character";
							btnimage.IconName = "avatar-default";
							break;
						default:
							break;
								
						}
						//label
						Gtk.Label btnlabel = new Gtk.Label(labelText);
						btnlabel.Ellipsize = ((global::Pango.EllipsizeMode)(3));						
						
						
						Gtk.Button tagw = new Gtk.Button();						
						tagw.TooltipMarkup = string.Format("Tag: <b>{0}</b>\nType: {1}\nCount: {2}",
							btntag,
							tag.Attributes["type"].Value,
							tag.Attributes["count"].Value);
						Gtk.HBox bthhp = new Gtk.HBox();
						
						bthhp.Add(btnimage);
						bthhp.Add(btnlabel);						
						((Gtk.Box.BoxChild)bthhp[btnimage]).Expand = false;
						((Gtk.Box.BoxChild)bthhp[btnimage]).Fill = false;
						
						tagw.Add(bthhp);
						
						tagw.Data["tag"] = btntag;
						//tagw.SetPadding(0, 2);	
						tagw.Clicked += HandleTagwClicked;
						if (i<4)
							tagsButtonsBox1.Add(tagw);
						else if (i<8)
							tagsButtonsBox2.Add(tagw);
						else
							tagsButtonsBox3.Add(tagw);
						if (++i>11) break;						
					}					
					tagsButtonsBox1.ShowAll();
					tagsButtonsBox2.ShowAll();
					tagsButtonsBox3.ShowAll();
				});
			}).Start();
		}

		void HandleTagwClicked (object sender, EventArgs e) {
			string str = tagsEdit.Text;
			int pos = tagsEdit.CursorPosition;
			int l = spaceFromLeft(str, pos);
			int r = spaceFromRight(str, pos);			
			string tag = ((Gtk.Button)sender).Data["tag"].ToString() + " ";
			tagsEdit.Text = (str.Remove(l, r-l).Insert(l, tag));
			tagsEdit.SelectRegion(l+tag.Length, l+tag.Length);
			this.FocusChild = tagsEdit;
		}

		protected void OnTagsEditMoveCursor(object o, Gtk.MoveCursorArgs args) {
			updateHelpButtons();
		}
	}
}
