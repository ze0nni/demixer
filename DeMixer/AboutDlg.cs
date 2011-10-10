
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using RowDialog;
using DeMixer.lib;
using System.IO;
using System.Collections.Generic;

namespace DeMixer {
	
	
	public class AboutDlg : RowDialogClass {
		
		private IDeMixerKernel Kernel;
		public AboutDlg(IDeMixerKernel k) {
			Kernel = k;
			Init();
			DoubleBuffered = true;
		}
		
		PictureBox DrawPanel;
		private void Init() {
			
			FileInfo fi = new FileInfo(Application.ExecutablePath);
			string logoname = String.Format("{1}{0}{2}",
			                             Path.DirectorySeparatorChar,
			                             fi.Directory.FullName,
			                             "logo.png");
			
			Bitmap img = new Bitmap(logoname);
			BackgroundImage = img;			
			BackColor = img.GetPixel(0, img.Height-1);
			BackgroundImageLayout = ImageLayout.None;
			this.SetClientSizeCore(img.Width, ClientSize.Height);
			
			Text = "О программе";
						
			DrawPanel = new PictureBox();
			DrawPanel.BackColor = Color.Transparent;
			DrawPanel.Height = img.Height;
			AddRow(DrawPanel);
			DrawPanel.Click += delegate {
				DialogResult = DialogResult.OK;
			};				
						
			LinkLabel Link = new LinkLabel();
			Link.Text = "www.zeDevel.org";
			Link.Click += delegate {
				ProcessStartInfo psi = new ProcessStartInfo(String.Format("http://{0}",Link.Text));
	            Process proc = new Process();
	            proc.StartInfo = psi;
	            proc.Start();  
			};
			AddCol(Link);
			
			Button btnClose  = new Button();
			btnClose.Text = "Проверить обновления";
			btnClose.Width = img.Width/2;
			btnClose.Click += delegate {
				UpdateDialog dlg = new UpdateDialog(Kernel);
				dlg.Width *= 2;
				dlg.StartPosition = FormStartPosition.CenterParent;
				dlg.ShowDialog();
			};
			AddRight(btnClose);
			
			
			initText();
			
			Timer t = new Timer();
			t.Interval = 50;
			t.Tick +=  delegate {	
				AnimationStep++;
				if (AnimationStep> AboutLines.Length*Font.Height + DrawPanel.Height)
					AnimationStep = 0;
				Invalidate();
			};
			t.Start();
			
			this.LockDialogHeight();
			StartPosition = FormStartPosition.CenterScreen;			
		}
		
		void initText() {
			List<string> l = new List<string>();
			
			l.Add("DeMixer v1.0");
			
			l.Add("");
			l.Add("Лицензия:");
			l.Add("    Freeware");
			
			l.Add("");
			l.Add("Автор:");
			l.Add("    Благодарев Евгений");
			
			l.Add("");
			l.Add("Помощь в тестировании:");
			l.Add("    Галузин Юрий");
			
			l.Add("");
			l.Add("Расширения:");
			foreach (ImagesSource s in Kernel.SourceList) {
				l.Add(String.Format("    {0}", s.PluginName));
			}
			foreach (ImagesComposition c in Kernel.CompositionList) {
				l.Add(String.Format("    {0}", c.PluginName));	
			}
			foreach (ImagePostEffect e in Kernel.PostEffectsList) {
				l.Add(String.Format("    {0}", e.PluginName));	
			}
			
			AboutLines = l.ToArray();
		}
		
		int AnimationStep = 0;
		string[] AboutLines = new string[0];
		protected override void OnPaint (System.Windows.Forms.PaintEventArgs e) {
			draw(e.Graphics);	
		}

		void draw(Graphics g) {
			g.TranslateTransform(DrawPanel.Left + DrawPanel.Width/2,
			                     DrawPanel.Top);
			g.SetClip(new Rectangle(0, 0, DrawPanel.Width/2, DrawPanel.Height));
			
			for (int i=0; i<AboutLines.Length; i++) {
				int top = i*Font.Height-AnimationStep+DrawPanel.Height;
				if (top + Font.Height <= 0) continue;
				if (top >= DrawPanel.Height) continue;
				
				float vValue = (float)top/DrawPanel.Height;
				if (vValue > 0.5f) vValue = -(vValue - 1f);
				if (vValue <0f) vValue =0f;
				if (vValue >0.5f) vValue =0f;
				vValue *= 2f;
				vValue = (float)Math.Sin(vValue * Math.PI/2);
				//
				vValue *= 1.5f;
				if (vValue >1f) vValue = 1f;
				
				
				byte aTop = (byte)(255 * vValue);
				
				Brush bB = new SolidBrush(Color.FromArgb(aTop, 64, 64, 64));
				Brush bW = new SolidBrush(Color.FromArgb(aTop, 255, 255, 255));
				
				g.DrawString(AboutLines[i], Font, bB, 1, top+1);
				g.DrawString(AboutLines[i], Font, bW, 0, top);				
			}
		}
		
		protected override void OnClick (System.EventArgs e){
			DialogResult = DialogResult.OK;
		}

	}
}
