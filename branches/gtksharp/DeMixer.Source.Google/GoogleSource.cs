using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using Google.API.Search;
using System.Collections.Generic;
using Gdk;

namespace DeMixer.Source.Google {
	public class googlecomSources : ImagesSource {
		public googlecomSources () : base() {
		}
		
		public override string Url {
			get { return "http://Images.Google.com"; }	
		}				
		
		private int imgSize = 0;
		public int ImgSize {
			get { return imgSize; }
			set {
				if (value >= 0 && value < SizeEnum.Length)
					imgSize = value;
			}
		}
		
		private int imgColor = 0;
		public int ImgColor {
			get { return imgColor; }
			set {
				if (value >= 0 && value < ColorEnum.Length)
					imgColor = value;
			}
		}
		
		Random rnd = new Random();
		public override System.Drawing.Image GetNextImage() {
			GimageSearchClient gs = new GimageSearchClient(Guid.NewGuid().ToString());
			IList<IImageResult> res =  gs.Search(
				Tags,
				int.MaxValue,
				"",
				SizeEnum[ImgSize].ToLower(),
				"all",
				ColorEnum[ImgColor].ToLower(),
				"",
				"",
				"");
			
			WebClient wc = new WebClient();
			byte[] imgData = wc.DownloadData(res[rnd.Next(res.Count)].Url);			
			System.Drawing.Image bmp = System.Drawing.Image.FromStream(new MemoryStream(imgData));
			return bmp;
		}
		
		public override System.Drawing.Image GetImageFromSource(string source) {
			return null;
		}
		
		public override bool SaveTempImages {
			get { return true; }	
		}
		
		public override Gtk.Widget ExpandTagsControl {
			get {
				return new GoogleSourceConfigWiget(this, Kernel);				
			}
		}
		
		public string[] SizeEnum {
			get { 	//return Enum.GetNames(typeof(ImageSize));
				return new string[] {
					"Large",
					"XLarge",
					"XXLarge",
					"Huge"
				};				
			}
		}
		
		public string[] ColorEnum {
			get { 	//return Enum.GetNames(typeof(ImageColor));
				return new string[] {
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
			cfg.WriteElementString("size", imgSize.ToString());
			cfg.WriteElementString("color", imgColor.ToString());
			cfg.WriteElementString("append", "");
		}
		
		protected override void Read(System.Xml.XmlNode r) {
			Tags = r.SelectSingleNode("q").InnerXml;
			ImgSize = int.Parse(
				r.SelectSingleNode("size").InnerXml);
			ImgColor = int.Parse(
				r.SelectSingleNode("color").InnerXml);
		}
	}
}

