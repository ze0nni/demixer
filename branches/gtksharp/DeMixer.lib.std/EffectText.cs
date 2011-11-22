
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace DeMixer.lib.std
{
	
	
	public class EffectText : ImagePostEffect {
		
		public override	string PluginName {
			get { return "Надпись"; }
		}
		
		public override string PluginTitle {
			get { return  "Выводит надпись"; }
		}
		
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

		public override void Save (System.IO.BinaryWriter stream) {
			stream.Write(Text);
			stream.Write((Int32)Position);
			stream.Write((Int32)XOffset);
			stream.Write((Int32)YOffset);
			stream.Write(UseWorkArea);
			stream.Write(TextFont.Name);
			stream.Write((Int32)TextFont.Size);
			stream.Write(TextFont.Bold);
			stream.Write(TextFont.Italic);
			stream.Write((Int32)FontColor.ToArgb());
			stream.Write((Int32)FrameColor.ToArgb());
		}
		
		public override void Load (System.IO.BinaryReader stream) {
			Text = stream.ReadString();
			Position = stream.ReadInt32();
			XOffset = stream.ReadInt32();
			YOffset = stream.ReadInt32();
			UseWorkArea = stream.ReadBoolean();
			string fontName = stream.ReadString();
			int fontSize = stream.ReadInt32();
			bool fontBold = stream.ReadBoolean();
			bool fontItalic = stream.ReadBoolean();
			TextFont = new Font(fontName,
			                    fontSize,
			                    FontStyle.Regular);
			
			FontColor = Color.FromArgb(stream.ReadInt32());
			FrameColor = Color.FromArgb(stream.ReadInt32());
		}

		public string Text = "Привет мир!";		
		public int Position = 0;
		public int XOffset;
		public int YOffset;
		public bool UseWorkArea = true;
		public Font TextFont = new Font(FontFamily.GenericSansSerif, 14, GraphicsUnit.Pixel);
		public Color FontColor = Color.White;
		public Color FrameColor = Color.Gray;
	}
	
	/*
	class EffectTextDlg : RowDialogClass {
		private EffectText Effect;
		public EffectTextDlg(EffectText eff) {
				Effect = eff;
			init();
		}
				
		private void init() {
			Text = String.Format("{0} - {1}",
			                     Effect.PluginName,
			                     Effect.PluginTitle);
			
			
			TextBox effectTextTb = new TextBox();
			effectTextTb.Text = Effect.Text;
			
			ComboBox effectPositionCb = new ComboBox();
			effectPositionCb.DropDownStyle = ComboBoxStyle.DropDownList;
			string[] items = {
				"Слева сверху", "Сверху", "Справа сверху",
				"Справа", "В центре", "Слева",
				"Справа снизу", "Снизу", "Слева снизу"};
			effectPositionCb.Items.AddRange(items);
			effectPositionCb.SelectedIndex = Effect.Position;
			
			TrackBar textOffsetXTb = new TrackBar();
			textOffsetXTb.Minimum = 0;
			textOffsetXTb.Maximum = 1000;
			textOffsetXTb.TickStyle = TickStyle.None;
			textOffsetXTb.Value = Effect.XOffset;			
			TrackBar textOffsetYTb = new TrackBar();
			textOffsetYTb.Minimum = 0;
			textOffsetYTb.Maximum = 1000;
			textOffsetYTb.Value = Effect.YOffset;
			textOffsetYTb.TickStyle = TickStyle.None;
			
			CheckBox useWorkAreaCb = new CheckBox();
			useWorkAreaCb.Text = "Внутри рабочей области";
			useWorkAreaCb.Checked = Effect.UseWorkArea;
			
			AddText("Надпись и положение", true);
			AddRow(effectTextTb);
			AddTextCol("Положение"); AddRow(effectPositionCb);
			AddTextCol("Отступ по X"); AddRow(textOffsetXTb);
			AddTextCol("Отступ по Y"); AddRow(textOffsetYTb);
			AddRow(useWorkAreaCb);
			
			//
			
			Label fontNameLb = new Label();
			Font  effectFont = Effect.TextFont;
			fontNameLb.Text = String.Format("{0} {1}",
			                                Effect.TextFont.Name,
			                                Effect.TextFont.Size);
			fontNameLb.BorderStyle = BorderStyle.Fixed3D;
			
			Button selectFontBtn = new Button();
			selectFontBtn.Text = "Выбрать";
			selectFontBtn.Click += delegate(object sender, EventArgs e) {
				FontDialog dlg = new FontDialog();
				dlg.Font = effectFont;
				if (dlg.ShowDialog() == DialogResult.OK){
					effectFont = dlg.Font;
					fontNameLb.Text = String.Format("{0} {1}",
			                                Effect.TextFont.Name,
			                                Effect.TextFont.Size);
				}
			};
			
			Panel textColorLb = new Panel();
			textColorLb.BackColor = Effect.FontColor;
			textColorLb.BorderStyle = BorderStyle.Fixed3D;
			textColorLb.Width = 32; textColorLb.Height = 16;
			textColorLb.Click += delegate(object sender, EventArgs e) {
				ColorDialog dlg = new ColorDialog();
				dlg.Color = textColorLb.BackColor;
				if (dlg.ShowDialog() == DialogResult.OK) {
					textColorLb.BackColor = dlg.Color;	
				}
			};
			Panel borderColorLb = new Panel();
			borderColorLb.BackColor = Effect.FrameColor;
			borderColorLb.BorderStyle = BorderStyle.Fixed3D;
			borderColorLb.Width = 32; borderColorLb.Height = 16;
			borderColorLb.Click += delegate(object sender, EventArgs e) {
				ColorDialog dlg = new ColorDialog();
				dlg.Color = borderColorLb.BackColor;
				if (dlg.ShowDialog() == DialogResult.OK) {
					borderColorLb.BackColor = dlg.Color;	
				}
			};
			
			AddText("Внешний вид", true);
			AddRight(selectFontBtn);
			AddRow(fontNameLb);
			AddTextCol("Цвет"); AddRow(textColorLb);
			AddTextCol("Обрамление"); AddRow(borderColorLb);
			
			Button okBtn = new Button();
			okBtn.Text = "Ok";
			okBtn.Click += delegate(object sender, EventArgs e) {
				Effect.Text = effectTextTb.Text;
				Effect.Position = effectPositionCb.SelectedIndex;
				Effect.XOffset = textOffsetXTb.Value;
				Effect.YOffset = textOffsetYTb.Value;
				Effect.UseWorkArea = useWorkAreaCb.Checked;
				
				Effect.TextFont = effectFont;
				Effect.FontColor = textColorLb.BackColor;
				Effect.FrameColor = borderColorLb.BackColor;
				
				DialogResult = DialogResult.OK;
			};
			
			AddRight(okBtn);
			
			this.LockDialogHeight();
		}
	}
	*/
}
