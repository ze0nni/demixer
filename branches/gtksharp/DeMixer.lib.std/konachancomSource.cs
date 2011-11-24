
using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Net;
using System.Xml;
using Gtk;

namespace DeMixer.lib.std {
	
	
	public class konachancomSource : ImagesSource {
		
		public konachancomSource() : base() {
		}
			
		public override string Url {
			get { return "http://KonaChan.com"; }	
		}		
		
		public override bool AllowTags {
				get { return true; }
		}
		
		public override Gtk.Widget ExpandTagsControl {
			get {
				return new konachancomSourceConfigView(this);
			}
		}
		
		public override bool SaveConfig(Stream stream) {
			return  base.SaveConfig(stream);
		}
		
		public override bool LoadConfig(Stream stream) {			
			return base.LoadConfig(stream);
		}
		
		private Random rnd = new Random();
		public override System.Drawing.Image GetNextImage() {			
			WebClient wc = Kernel.GetWebClient();
		 //todo: user-agent			
			byte[] data = wc.DownloadData(new Uri(GetUrl(1)));
			XmlDocument doc = new XmlDocument();
			doc.Load(new MemoryStream(data));
			int pageCount = GetPagesCount(doc);
			//выбираем случайно
			data = wc.DownloadData(new Uri(GetUrl(rnd.Next(1, pageCount+1))));
			doc.Load(new MemoryStream(data));
			return GetImage(doc);				
		}
		
		private string GetUrl(int page) {
			return 
				string.Format(
					"http://konachan.com/post/index.xml?tags={0}&limit=1&page={1}",
					Tags,
					page);
		}
		
		private int GetPagesCount(XmlDocument doc) {
			XmlNode req = doc.SelectSingleNode("posts");
			if (req == null) throw new Exception("Bad xml");
			return int.Parse(req.Attributes["count"].Value);
		}
		
		private System.Drawing.Image GetImage(XmlDocument doc) {
			XmlNode req = doc.SelectSingleNode("posts").SelectSingleNode("post");
			string imgPath = req.Attributes["sample_url"].Value;
			WebClient wc = new WebClient();
			byte[] d = wc.DownloadData(new Uri(imgPath));
			return System.Drawing.Image.FromStream(new MemoryStream(d));
		}
		
		public override System.Drawing.Image GetImageFromSource(string source) {
			return null;
		}
	}
}
