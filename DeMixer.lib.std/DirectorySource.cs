
using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Gdk;

namespace DeMixer.lib.std {
	public class DirectorySource : ImagesSource {
		
		public DirectorySource() {			
		}
		
		public List<string> FSeekPath = new List<string>();		
		public override string Url {
			get { return FSeekPath.Count == 0 ? "" : FSeekPath[0]; }	
		}	
				
		
		public override Gtk.Widget ExpandTagsControl {
			get {
				return new DirectorySourceConfigView(this);
			}
		}

		private Random rnd = new Random();
		public override System.Drawing.Image GetNextImage() {
			try {
				Console.WriteLine("GetNextImage enter");
				List<string> files = new List<string>();
				foreach (string d in FSeekPath) {
					DirectoryInfo di = new DirectoryInfo(d);
					foreach (FileInfo f in di.GetFiles()) {
					 	files.Add(f.FullName);	
					}
				}					
				return System.Drawing.Image.FromFile(files[rnd.Next(0, files.Count)]);
			} catch(Exception exc) {
				Console.WriteLine(exc);
				//todo: Kernel.log(exc);
				Bitmap bmp = new Bitmap(320, 200);
				Graphics g = Graphics.FromImage(bmp);
				g.Clear(System.Drawing.Color.Black);
				g.DrawString("NO FILES",
				             new System.Drawing.Font(FontFamily.GenericSerif, 25, GraphicsUnit.Pixel),
				             Brushes.Red, 5, 5);
				return bmp;	
			}
		}
		
		public override System.Drawing.Image GetImageFromSource(string source) {
			return null;
		}
		
		protected override void Write(System.Xml.XmlWriter cfg) {
			cfg.WriteStartElement("paths");
			try {
				foreach (string l in FSeekPath) {
					cfg.WriteElementString("path", l);
					cfg.WriteAttributeString("forced", false.ToString());
				}
			} finally {
				cfg.WriteEndElement();
			}
		}
		
		protected override void Read(System.Xml.XmlNode r) {
			System.Xml.XmlNodeList paths = r.SelectSingleNode("paths").SelectNodes("path");
			FSeekPath.Clear();
			foreach (System.Xml.XmlNode n in paths) {
				FSeekPath.Add(n.InnerXml);
			}			
		}
	}	
}
