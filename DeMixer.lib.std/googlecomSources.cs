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
			
		public override string PluginName {
			get { return "Google.com"; }
		}
		
		public override string PluginTitle {
			get { return "Поиск на Google.com"; }
		}
		
		public override string Url {
			get { return "http://Images.Google.com"; }	
		}		
		
		public string PluginDescription {
			get {
				return 	"\tЭто плагин предназначен для поиска изображений через сервис " +
						"поиска изображений, всемирно известного поискового гиганта Google.\r\n" +
						"\tДля поиска вы можете вписать в качестве ключевых слов, например: " + 
						"\"Солнце и песок\".\r\n" + 
						"\tЕсли вы хотите исключить какие-то ключевые слова, то ставьте перед ними минус. " + 
						"Например \"Солнце и песок -чайки\".\r\n" + 
						"\tТак же вы можете воспользоваться расширенными настройками что бы задать " + 
						"особые параетры поиска, такие как размер изображений или преобладающие цвета.";
			}
		}
		
		string imgSize = "Large";
		string imgColor = "All";
		bool saveToHistory = false;
		
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
				return null;
				/*
				Panel p = new Panel();
				
				TextBox searchTb = new TextBox();
				searchTb.Text = Tags;			
				searchTb.Dock = DockStyle.Top;
				searchTb.TextChanged += delegate {
					Tags = searchTb.Text;	
				};
				
				CheckBox saveToHistoryCb = new CheckBox();
				saveToHistoryCb.Text = Kernel.Translate("DeMixer.lib.std.googlecomSources save to history");
				saveToHistoryCb.Checked = saveToHistory;
				saveToHistoryCb.CheckedChanged += delegate {
					saveToHistory=saveToHistoryCb.Checked;
				};
				saveToHistoryCb.Dock = DockStyle.Bottom;						
				
				
				Panel p2 = new Panel();
				p2.Dock = DockStyle.Fill;
				p.Controls.Add(p2);
				p.Controls.Add(saveToHistoryCb);
				p.Controls.Add(searchTb);
				
				
				ListBox colorLb = new ListBox();
				colorLb.IntegralHeight = false;
				colorLb.Dock = DockStyle.Left;
				colorLb.Items.AddRange(new object[]{"All", "Red", "Orange", "Yellow", "Green", "Teal", "Blue", "Purple", "Pink", "White", "Gray", "Black", "Brown"});
				colorLb.SelectedIndexChanged += delegate {
					imgColor = colorLb.SelectedItem.ToString();
					//colorLb.Invalidate();
				};
				colorLb.DrawMode = DrawMode.OwnerDrawFixed;
				colorLb.DrawItem += delegate(object sender, DrawItemEventArgs e) {
					string cName = colorLb.Items[e.Index].ToString();
					if (cName.ToLower() == "teal") cName = "Aqua";
					
					e.DrawBackground();
					e.Graphics.DrawString(
						cName,
						colorLb.Font,
							(e.State & DrawItemState.Selected) != 0 ?
						 SystemBrushes.HighlightText : SystemBrushes.WindowText,
						e.Bounds);
					if (e.Index != 0) {						
						Color c = Color.FromName(cName);					
						c = Color.FromArgb(255, c.R, c.G, c.B);
						Brush b = new SolidBrush(c);
						Rectangle r = e.Bounds;
						r.Width /= 3;
						r.X += r.Width*2;
						e.Graphics.FillRectangle(b, r);
						e.Graphics.DrawRectangle(SystemPens.WindowFrame, r);
					}
					e.DrawFocusRectangle();
				};
				int colorIndex = colorLb.Items.IndexOf(imgColor);
				try { colorLb.SelectedIndex = colorIndex == -1 ? 0 : colorIndex; } catch {}
				p2.Controls.Add(colorLb);
				
				ListBox sizeLb = new ListBox();
				sizeLb.IntegralHeight = false;
				sizeLb.Dock = DockStyle.Left;
				sizeLb.Items.AddRange(new object[]{"Medium", "Large", "XLarge", "XXLarge", "Huge"});
				sizeLb.SelectedIndexChanged += delegate {
					imgSize = sizeLb.SelectedItem.ToString();
				};
				int sizeIndex = sizeLb.Items.IndexOf(imgSize);
				try {sizeLb.SelectedIndex = sizeIndex == -1 ? 0 : sizeIndex; } catch {}
				p2.Controls.Add(sizeLb);				
								
				
				return p;
				*/
			}
		}
	}
}

