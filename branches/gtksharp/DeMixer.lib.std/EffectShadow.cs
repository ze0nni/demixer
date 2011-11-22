
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DeMixer.lib.std {	
	public class EffectShadow : ImagePostEffect {
		
		public override	string PluginName {
			get { return "Тень"; }
		}
		
		public override string PluginTitle {
			get { return  "Эффект тени"; }
		}
				
		public override void Save (System.IO.BinaryWriter stream) {
			stream.Write(DrawTop);	
			stream.Write(DrawBottom);
			stream.Write(DrawLeft);
			stream.Write(DrawRight);
			stream.Write((Int32)DrawBorderSize);
			stream.Write(ColorStart.ToArgb());
			stream.Write(ColorStartAlpha);
			stream.Write(ColorEnd.ToArgb());
			stream.Write(ColorEndAlpha);
		}
		public override void Load (System.IO.BinaryReader stream) {
			DrawTop = stream.ReadBoolean();
			DrawBottom = stream.ReadBoolean();
			DrawLeft = stream.ReadBoolean();
			DrawRight = stream.ReadBoolean();
			DrawBorderSize = stream.ReadInt32();
			ColorStart = Color.FromArgb(stream.ReadInt32());
			ColorStartAlpha = stream.ReadByte();
			ColorEnd = Color.FromArgb(stream.ReadInt32());
			ColorEndAlpha = stream.ReadByte();

		}

		public override void ShowDialog (Gtk.Window parent) {
			EffectShadowDialog dlg = new EffectShadowDialog(this, parent);
			try {
				Kernel.TranslateWidget(dlg);
				dlg.Run();
			} finally {
				dlg.Destroy();	
			}
		}

		
		public override Image Execute(Image img) {
			Color c1 = Color.FromArgb(ColorStartAlpha,
			                          ColorStart.R,
			                          ColorStart.G,
			                          ColorStart.B);
			Color c2 = Color.FromArgb(ColorEndAlpha,
			                          ColorEnd.R,
			                          ColorEnd.G,
			                          ColorEnd.B);
			Graphics g = Graphics.FromImage(img);
			if (DrawTop) {
				Brush b = new LinearGradientBrush(
				                                  new Point(0, 0),
				                                  new Point(0, DrawBorderSize),
				                                  c1, c2);
				g.FillRectangle(b, 0, 0, img.Width, DrawBorderSize);
			}
			
			if (DrawBottom) {
				Brush b = new LinearGradientBrush(
				                                  new Point(0, img.Height - DrawBorderSize-1),
				                                  new Point(0, img.Height),
				                                  c2, c1);
				g.FillRectangle(b, 0, img.Height - DrawBorderSize, img.Width, DrawBorderSize);
			}			
			if (DrawLeft) {
				Brush b = new LinearGradientBrush(
				                                  new Point(0, 0),
				                                  new Point(DrawBorderSize, 0),
				                                  c1, c2);
				g.FillRectangle(b, 0, 0, DrawBorderSize, img.Height);
			}
			if (DrawRight) {
				Brush b = new LinearGradientBrush(
				                                  new Point(img.Width - DrawBorderSize-1, 0),
				                                  new Point(img.Width, 0),				                                  
				                                  c2, c1);
				g.FillRectangle(b, img.Width - DrawBorderSize, 0, DrawBorderSize, img.Height);
			}
			return img;
		}
		
		public bool DrawTop = true;
		public bool DrawBottom = true;
		public bool DrawLeft = false;
		public bool DrawRight = false;
		public Color ColorStart = Color.Black;
		public byte ColorStartAlpha = 172;
		public Color ColorEnd = Color.Black;
		public byte ColorEndAlpha = 0;
		public int DrawBorderSize = 48;
		
		public override string ToString () {
			string borders = "";
			if (DrawTop) borders += "сверху ";
			if (DrawBottom) borders += "снизу ";
			if (DrawLeft) borders += "слева ";
			if (DrawRight) borders += "справа ";
			return String.Format(
			                     "{0}: {1}px {2}",
			                     PluginName,
			                     DrawBorderSize,
			                     borders
			                     );
			                     
		}
 
	}
	
	/*
	class EffectShadowDlg : RowDialogClass {
		
		private EffectShadow Effect;
		public EffectShadowDlg(EffectShadow eff) {
				Effect = eff;
			init();
		}
				
		private void init() {
			Text = String.Format("{0} - {1}",
			                     Effect.PluginName,
			                     Effect.PluginTitle);
			
			Width += Width / 2;
			CheckBox cbTop = new CheckBox(); cbTop.Checked = Effect.DrawTop; cbTop.Text = "Сверху";
			CheckBox cbBottom = new CheckBox(); cbBottom.Checked = Effect.DrawBottom; cbBottom.Text = "Снизу";
			CheckBox cbLeft = new CheckBox(); cbLeft.Checked = Effect.DrawLeft; cbLeft.Text = "Слева";
			CheckBox cbRight = new CheckBox(); cbRight.Checked = Effect.DrawRight; cbRight.Text = "Справа";			
			
			Panel Color1 = new Panel();
			Color1.BorderStyle = BorderStyle.Fixed3D;
			Color1.BackColor = Effect.ColorStart;
			Color1.ForeColor = Effect.ColorStart;
			Color1.Width = 32; Color1.Height = 16;
			Color1.Click += delegate(object sender, EventArgs e) {
				ColorDialog dlg = new ColorDialog();
				dlg.Color = Color1.BackColor;
				if (dlg.ShowDialog() == DialogResult.OK)
					Color1.BackColor = dlg.Color;
			};
			TrackBar ColorT1 = new TrackBar();
			ColorT1.Minimum = 0;
			ColorT1.Maximum = 255;
			ColorT1.Value = Effect.ColorStartAlpha;
			ColorT1.TickStyle = TickStyle.None;
			
			Panel Color2 = new Panel();
			Color2.BorderStyle = BorderStyle.Fixed3D;
			Color2.BackColor = Effect.ColorEnd;
			Color2.ForeColor = Effect.ColorEnd;
			Color2.Width = 32; Color2.Height = 16;
			Color2.Click += delegate(object sender, EventArgs e) {
				ColorDialog dlg = new ColorDialog();
				dlg.Color = Color2.BackColor;
				if (dlg.ShowDialog() == DialogResult.OK)
					Color2.BackColor = dlg.Color;
			};
			TrackBar ColorT2 = new TrackBar();
			ColorT2.Minimum = 0;
			ColorT2.Maximum = 255;
			ColorT2.Value = Effect.ColorEndAlpha;
			ColorT2.TickStyle = TickStyle.None;
			
			Label borderSizeLab = new Label();
			borderSizeLab.Text = String.Format("Размер {0}", Effect.DrawBorderSize);
			TrackBar borderSizeTb = new TrackBar();
			borderSizeTb.Minimum = 1;
			borderSizeTb.Maximum = Math.Max(Screen.PrimaryScreen.Bounds.Width,
			                                Screen.PrimaryScreen.Bounds.Height);
			try { borderSizeTb.Value = Effect.DrawBorderSize; } catch {}
			borderSizeTb.TickStyle = TickStyle.None;
			borderSizeTb.ValueChanged += delegate {
				borderSizeLab.Text = String.Format("Размер {0}", borderSizeTb.Value);	
			};
			
			Button btnOk = new Button();
			btnOk.Text = "Ok";
			btnOk.Click += delegate(object sender, EventArgs e) {
				Effect.DrawTop = cbTop.Checked;
				Effect.DrawBottom = cbBottom.Checked;
				Effect.DrawLeft = cbLeft.Checked;
				Effect.DrawRight = cbRight.Checked;
				Effect.ColorStart = Color1.BackColor;
				Effect.ColorStartAlpha = (byte)ColorT1.Value;
				Effect.ColorEnd = Color2.BackColor;
				Effect.ColorEndAlpha = (byte)ColorT2.Value;
				Effect.DrawBorderSize = borderSizeTb.Value;				
					
				DialogResult = DialogResult.OK;				
			};
			
			AddText("Грани", true);
			AddCol(cbTop);
			AddCol(cbBottom);
			AddCol(cbLeft);
			AddCol(cbRight);
			EndCol();
			AddCol(borderSizeLab);
			AddRow(borderSizeTb);
			
			AddText("Цвета", true);
			AddTextCol("Цвет 1:"); AddCol(Color1); AddTextCol("Прозрачность:"); AddRow(ColorT1);
			AddTextCol("Цвет 2:"); AddCol(Color2); AddTextCol("Прозрачность:"); AddRow(ColorT2);
						
			AddRight(btnOk);
			
			
			this.LockDialogHeight();
		}
	}
	*/
}
