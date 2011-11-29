using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using Google.API.Search;
using System.Collections.Generic;
using Gdk;

namespace DeMixer.lib.std
{
	public class googlecomSources : ImagesSource {
		public googlecomSources () : base() {
		}
		
		public override string Url {
			get { return "http://Images.Google.com"; }	
		}				
		
		public string imgSize = "Large";
		public string imgColor = "All";
		public bool saveToHistory = false;
		
		Random rnd = new Random();
		public override System.Drawing.Image GetNextImage() {
			GimageSearchClient gs = new GimageSearchClient(Guid.NewGuid().ToString());
			IList<IImageResult> res =  gs.Search(
				Tags,
				int.MaxValue,
				"",
				imgSize.ToLower(),
				"all",
				imgColor.ToLower(),
				"",
				"",
				"");
			
			WebClient wc = new WebClient();
			byte[] imgData = wc.DownloadData(res[rnd.Next(res.Count)].Url);			
			System.Drawing.Image bmp = System.Drawing.Image.FromStream(new MemoryStream(imgData));
			
			try {
				if (saveToHistory && Kernel.SaveHistory) {
					string historyfName = String.Format("{1}{0}{2}_{3}{4}.png",
						                                Path.DirectorySeparatorChar,
					                                    Kernel.SaveHistoryPath,
					                                    DateTime.Now.ToString(),
				                                    	"Google.com",
					                                    bmp.GetHashCode()
					                                    );
					bmp.Save(historyfName, ImageFormat.Png); 
				}
			} catch {
					
			}
			
			return bmp;
		}
		
		public override System.Drawing.Image GetImageFromSource(string source) {
			return null;
		}
		
		public override Gtk.Widget ExpandTagsControl {
			get {
				return new googlecomSourcesConfigView(this, Kernel);				
			}
		}
		
		public string[] SizeEnum {
			get { return new string[] {
					"Large",
					"XLarge",
					"XXLarge",
					"Hude"
				};
			}
		}
		
		public string[] ColorEnum {
			get { return new string[] {
					"All",
					"Red",
					"Orange",
					"Yellow",
					"Green",
					"Aqua",
					"Blue",
					"Purple",
					"Pink",
					"White",
					"Gray",
					"Black",
					"Brown"
				};
			}
		}
		
		protected override void Write(System.Xml.XmlWriter cfg) {			
			cfg.WriteElementString("q", Tags);
			cfg.WriteElementString("size", imgSize);
			cfg.WriteElementString("color", imgColor);
			cfg.WriteElementString("append", "");
		}
		
		protected override void Read(System.Xml.XmlNode r) {
			Tags = r.SelectSingleNode("q").InnerXml;
			imgSize = r.SelectSingleNode("size").InnerXml;
			imgColor = r.SelectSingleNode("color").InnerXml;
		}
	}
}

