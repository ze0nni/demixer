
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace DeMixer.lib.std
{
	
	
	public class EffectText : ImagePostEffect {		
		public override void ShowDialog (Gtk.Window parent) {
			//EffectTextDlg dlg = new EffectTextDlg(this);
			//dlg.ShowDialog();
		}

		
		Random rnd = new Random();
		public override Image Execute(Image img) {
			return img;
			/*todo 
			Graphics g = Graphics.FromImage(img);
			
			string t = Text;			
			try {
				if (System.IO.File.Exists(Text)) {
					Stream fs = new FileStream(Text, FileMode.Open);
					StreamReader sr = new StreamReader(fs);
					string[] lines = sr.ReadToEnd().Split('\n');
					fs.Close();
					t = String.Format(lines[rnd.Next(0, lines.Length-1)]);
				}
			} catch {}
			
			int w = img.Width;
			int h = img.Height;
			int ox = 0;
			int oy = 0;
			
			if (UseWorkArea) {
				w = Screen.PrimaryScreen.WorkingArea.Width;
				h = Screen.PrimaryScreen.WorkingArea.Height;
				ox = Screen.PrimaryScreen.WorkingArea.Left;
				oy = Screen.PrimaryScreen.WorkingArea.Top;			 
			}
			SizeF textSize = g.MeasureString(t, TextFont);
			int tw = (int)textSize.Width;
			int th = (int)textSize.Height;
			switch (Position) {
				case 0: break;
				case 1: ox -= tw/2; break;
				case 2: ox -= tw/2; break;
				case 3: oy -= th/2; break;
				case 4: ox -= tw/2; oy -= th/2; break;
				case 5: ox -= tw; oy -= th/2; break;
				case 6: oy -= th; break;
				case 7: ox -= tw/2; oy -= th; break;
				case 8: ox -= tw; oy -= th; break;
			}
			
			float tx = ox + (float)w / 1000 * XOffset;
			float ty = oy + (float)h / 1000 * YOffset;
			Brush b = new SolidBrush(FontColor);
			Brush bb = new SolidBrush(FrameColor);
				
			g.DrawString(t, TextFont, bb, tx+1, ty+1);
			g.DrawString(t, TextFont, b, tx, ty);
			return img;	
			*/
		}
		
		public override string ToString () {			
			return String.Format("{0}: {1}",
			                     PluginName,
			                     Text);
		}

//		public override void Save (System.IO.BinaryWriter stream) {
//			stream.Write(Text);
//			stream.Write((Int32)Position);
//			stream.Write((Int32)XOffset);
//			stream.Write((Int32)YOffset);
//			stream.Write(UseWorkArea);
//			stream.Write(TextFont.Name);
//			stream.Write((Int32)TextFont.Size);
//			stream.Write(TextFont.Bold);
//			stream.Write(TextFont.Italic);
//			stream.Write((Int32)FontColor.ToArgb());
//			stream.Write((Int32)FrameColor.ToArgb());
//		}
//		
//		public override void Load (System.IO.BinaryReader stream) {
//			Text = stream.ReadString();
//			Position = stream.ReadInt32();
//			XOffset = stream.ReadInt32();
//			YOffset = stream.ReadInt32();
//			UseWorkArea = stream.ReadBoolean();
//			string fontName = stream.ReadString();
//			int fontSize = stream.ReadInt32();
//			bool fontBold = stream.ReadBoolean();
//			bool fontItalic = stream.ReadBoolean();
//			TextFont = new Font(fontName,
//			                    fontSize,
//			                    FontStyle.Regular);
//			
//			FontColor = Color.FromArgb(stream.ReadInt32());
//			FrameColor = Color.FromArgb(stream.ReadInt32());
//		}

		public string Text = "Привет мир!";		
		public int Position = 0;
		public int XOffset;
		public int YOffset;
		public bool UseWorkArea = true;
		public Font TextFont = new Font(FontFamily.GenericSansSerif, 14, GraphicsUnit.Pixel);
		public Color FontColor = Color.White;
		public Color FrameColor = Color.Gray;
	}
	//todo: read/write
}
