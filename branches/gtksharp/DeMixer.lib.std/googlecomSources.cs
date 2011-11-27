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
		
		public override bool AllowTags {
				get { return true; }
		}
		
		public override bool SaveConfig(Stream stream) {			
			//return  base.SaveConfig(stream);
			BinaryWriter bw = new BinaryWriter(stream, System.Text.Encoding.UTF8);
			bw.Write(
				String.Join("\n", new string[]{Tags, imgSize, imgColor}));
			bw.Write(saveToHistory);
			return true;
		}
		
		public override bool LoadConfig(Stream stream) {			
			//return base.LoadConfig(stream);
			BinaryReader br = new BinaryReader(stream, System.Text.Encoding.UTF8);
			string[] args = br.ReadString().Split('\n');
			if (args.Length>=1) Tags = args[0];
			if (args.Length>=2) imgSize = args[1];
			if (args.Length>=3) imgColor = args[2];
			if (br.BaseStream.CanRead) saveToHistory = br.ReadBoolean();
			return true;
		}
		
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
	}
}

