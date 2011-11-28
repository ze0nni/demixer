
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace DeMixer.lib.std {
		
	public class CompositionMozaik : ImagesComposition
	{
		
		public CompositionMozaik() {
		}
		
		
		int imagesCount = 5;
		public int ImagesCount {
			get { return imagesCount; }
			set { if (value >= 2 && value <=9) 
				imagesCount = value;
			}
		}
				
		public override Image GetCompostion(int width, int height) {			
			Image[] imgs = new Image[ImagesCount];
			Source.GetNextImages(imgs, 5);
			
			for (int i=0; i<imgs.Length; i++) {
				Image img = imgs[i];
				
				float sx = (float)width / img.Width;
				float sy = (float)height / img.Height;

				
				float sn = Math.Max(sx, sy);
				int imgW = (int)(img.Width * sn);
				int imgH = (int)(img.Height * sn);	
								
				
				int imgX = (int)((width - imgW) / 2);
				int imgY = (int)((height - imgH) / 2);
				
				if (i>0) {
					imgW = (int)(imgW / 3);
					imgH = (int)(imgH / 3);					
					imgX = 0;
					imgY = 0;
				}	
				
				
				Image nImg = new Bitmap(imgW, imgH);
				Graphics g = Graphics.FromImage(nImg);
				g.DrawImage(img, imgX, imgY, imgW, imgH);
				imgs[i] = nImg;
			}
						
			Image des = new Bitmap(width, height);	
			Graphics gr = Graphics.FromImage(des);
			
			gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
			gr.DrawImage(imgs[0], 0, 0);
			
			Random rnd = new Random();
			float offset = (float)(Math.PI/4f + Math.PI/2f*rnd.Next(4));
			for (int i=1; i<imgs.Length; i++) {
				Image img = imgs[i];				
				float secSize = (float)Math.PI*2f/(ImagesCount-1);				
				int imgX = (int)(Math.Cos((i*secSize+offset) + rnd.Next(-100, 100)/500.0) * (width-img.Width*1.6f) + width/2);
				int imgY = (int)(Math.Sin((i*secSize+offset) + rnd.Next(-100, 100)/500.0) * (height-img.Height*1.6f) + height/2);
				imgX += rnd.Next(-width/16, width/16);
				imgY += rnd.Next(-height/16, height/16);
				Matrix m = gr.Transform;
				try {					
					gr.TranslateTransform(imgX, imgY);
					gr.RotateTransform(rnd.Next(-30, 30));					
					
					gr.FillRectangle(Brushes.White,
				                 -8-img.Width/2, -8-img.Height/2,
				                 img.Width + 16, img.Height + 16);
					//gr.DrawImage(img, -img.Width/2, -img.Height/2);
					TextureBrush ib = new TextureBrush(img);
					ib.TranslateTransform(img.Width/2, img.Height/2);
					gr.FillRectangle(ib,
				                 -img.Width/2, -img.Height/2,
				                 img.Width, img.Height);
				} finally {
					gr.Transform = m;	
				}
			}			
			return des;
		}
		
		protected override void Read(System.Xml.XmlNode r) {
			ImagesCount = int.Parse(
					r.SelectSingleNode("count").InnerXml
				);
		}
		
		protected override void Write(System.Xml.XmlWriter cfg) {
			cfg.WriteElementString("count", ImagesCount.ToString());
		}		
				
		public override Gtk.Widget ExpandControl {
			get {
				return new CompositionMozaikConfigView(this);				
			}
		}


	}
	/*
	internal class CompositionMozaikDlg : RowDialog.RowDialogClass {
		CompositionMozaik Comp;
		public CompositionMozaikDlg(CompositionMozaik comp) : base() {
			Comp = comp;
			ComboBox imagesCountCb = new ComboBox();
			imagesCountCb.Items.AddRange(new object[]{"2", "3", "4", "5", "6", "7", "8", "9"});
			imagesCountCb.DropDownStyle = ComboBoxStyle.DropDownList;
			try { imagesCountCb.SelectedIndex=Comp.ImagesCount-2; } catch {imagesCountCb.SelectedIndex = 3;}
			AddRow(imagesCountCb);
			
			Button btnOk = new Button();
			btnOk.Text = "Ok";
			btnOk.Click += delegate {				
				Comp.ImagesCount = imagesCountCb.SelectedIndex + 2;
				DialogResult = DialogResult.OK;
			};
			AddRight(btnOk);
			
			LockDialogHeight();
		}
	}
	*/
}
