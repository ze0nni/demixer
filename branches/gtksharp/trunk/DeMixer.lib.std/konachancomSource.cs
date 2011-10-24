
using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace DeMixer.lib.std {
	
	
	public class konachancomSource : ImagesSource {
		
		public konachancomSource() : base() {
		}
			
		public override string PluginName {
			get { return "KonaChan.com"; }
		}
		
		public override string PluginTitle {
			get { return "Поиск на KonaChan.com"; }
		}
		
		public override string Url {
			get { return "http://KonaChan.com"; }	
		}		
		
		public string GetPluginDescription() {
			return 	"\tЭто плагин предназначен для поиска изображений на сайте KonaChan.com. "+
					"Этот сайт, по сути огромных, структуризированны и постоянно пополняемый архив " +
					"обоев для рабочего стола на тему аниме.\r\n" +
					"\tДля каждлого изображения существует набор тегов, например комбинация тегов " +
					"\"dark scenic\" соответствует темным обоям с изображением сцен (улицы, дома, пейзажи...), " +
					"а комбинация \"-blood\" соответствует всем картинкам, которых нет крови.\r\n" + 
					"\tПосмотреть список возможных тегов вы можете насамом сайте или через встроенный редактор.";
		}
		
		public override bool AllowTags {
				get { return true; }
		}
		
		public override Control ExpandTagsControl {
			get {
				return base.ExpandTagsControl;
			}
		}
		
		public override bool SaveConfig(Stream stream) {
			return  base.SaveConfig(stream);
		}
		
		public override bool LoadConfig(Stream stream) {			
			return base.LoadConfig(stream);
		}
		
		public override bool AcceptDialog {
			get { return false; }
		}
		
		public override void ShowDialog(System.Windows.Forms.Form parent) {
				
		}
		
		private Random rnd = new Random();
		public override Image GetNextImage() {			
			WebClient wc = new WebClient();
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
		
		private Image GetImage(XmlDocument doc) {
			XmlNode req = doc.SelectSingleNode("posts").SelectSingleNode("post");
			string imgPath = req.Attributes["sample_url"].Value;
			WebClient wc = new WebClient();
			byte[] d = wc.DownloadData(new Uri(imgPath));
			return Image.FromStream(new MemoryStream(d));
		}
		
		public override Image GetImageFromSource(string source) {
			return null;
		}
	}
}
