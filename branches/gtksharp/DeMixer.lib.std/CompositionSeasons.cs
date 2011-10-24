
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DeMixer.lib.std {
	
	
	public class CompositionSeasons : ImagesComposition {
		
		public CompositionSeasons() {
		}
		
		int imagesCount = 4;
		public int ImagesCount {
			get { return imagesCount; }
			set {
				if (value >= 2 && value <= 6)
					imagesCount = value;
			}
				
		}
		
		int separatorSize = 4;
		public int SeparatorSize {
			get { return separatorSize; }
			set {
				separatorSize = value;
			}
				
		}
		
		Color separatorColor1 = Color.White;
		public Color SeparatorColor1 {
			get { return separatorColor1; }
			set {
				separatorColor1 = Color.FromArgb(255, value.R, value.G, value.B);
			}
		}
		
		Color separatorColor2 = Color.White;
		public Color SeparatorColor2 {
			get { return separatorColor2; }
			set {
				separatorColor2 = Color.FromArgb(255, value.R, value.G, value.B);
			}
		}
		
		public override Image GetCompostion (int width, int height) {
			Image[] imgs = new Image[imagesCount];
			Source.GetNextImages(imgs, 5);
			
			Image des = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(des);
			g.SetClip(new Rectangle(0, 0, width/ImagesCount, height));
			for (int i=0;i<ImagesCount;i++) {
				Image img = imgs[i];
				
				float news = Math.Max((float)width/img.Width,
				                      (float)height/img.Height);
				                      
				                 				
				float neww = img.Width * news;
				float newh = img.Height * news;
				
				float l = 0;
				l = (i*width/ImagesCount) +
					(width/ImagesCount - neww)/2;
				
				g.DrawImage(img,
				            l,
				            (height - newh)/2,
				            (int)neww,
				            (int)newh);
				g.TranslateClip(width/ImagesCount, 0);
			}
			
			g.SetClip(new Rectangle(0, 0, width, height));
			
			if (SeparatorSize != 0) {
				Brush gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
					new Point(0, 0), new Point(0, height),
					SeparatorColor1,
					SeparatorColor2);
				Pen p = new Pen(gradBrush, SeparatorSize);
				
				for (int i=1;i<ImagesCount;i++) {										
					g.DrawLine(p,
					           i*width/ImagesCount-SeparatorSize/2,
					           0,
					           i*width/ImagesCount-SeparatorSize/2,
					           height);
				}
			}
			return des;
		}
		
		public override bool LoadConfig (System.IO.Stream stream) {
			BinaryReader br = new BinaryReader(stream);
			if (stream.CanRead) ImagesCount = br.ReadInt32();
			if (stream.CanRead) SeparatorSize = br.ReadInt32();
			if (stream.CanRead) SeparatorColor1 = Color.FromArgb(br.ReadInt32());
			if (stream.CanRead) SeparatorColor2 = Color.FromArgb(br.ReadInt32());
			return true;
		}
		
		public override bool SaveConfig (System.IO.Stream stream) {			
			BinaryWriter bw = new BinaryWriter(stream);
			bw.Write((Int32)imagesCount);
			bw.Write((Int32)SeparatorSize);
			bw.Write((Int32)SeparatorColor1.ToArgb());
			bw.Write((Int32)SeparatorColor2.ToArgb());
			return true;
		}
		
		public override void ShowDialog () {
			//CompositionSeasonsDlg dlg = new CompositionSeasonsDlg(this);
			//dlg.ShowDialog();
		}
	}
	
	/*
	internal class CompositionSeasonsDlg : RowDialogClass {
		
		public CompositionSeasonsDlg(CompositionSeasons eff) : base() {	
			ComboBox imagesCountCb = new ComboBox();
			imagesCountCb.DropDownStyle = ComboBoxStyle.DropDownList;
			imagesCountCb.Items.AddRange(new object[]{"2", "3", "4", "5", "6"});
			try {
				imagesCountCb.SelectedIndex = eff.ImagesCount - 2;
			} catch {
				imagesCountCb.SelectedIndex = 3;
			}
			
			AddTextCol("Число изображений");
			AddRow(imagesCountCb);
			
			Label separatorSizeLb = new Label();
			TrackBar separatorSizeTb = new TrackBar();
			separatorSizeTb.Minimum = 0;
			separatorSizeTb.Maximum = 32;
			separatorSizeTb.ValueChanged += delegate {
				separatorSizeLb.Text = String.Format("Граница: {0}px", separatorSizeTb.Value);
			};
			try {
				separatorSizeTb.Value = eff.SeparatorSize;
			} catch {
			}
			
			AddCol(separatorSizeLb);
			AddRow(separatorSizeTb);
			
			Panel separatorColor1 = new Panel();
			separatorColor1.BorderStyle = BorderStyle.Fixed3D;
			separatorColor1.Width = 32; separatorColor1.Height = 16;
			separatorColor1.Click += HandleSeparatorColorClick;
			separatorColor1.BackColor = eff.SeparatorColor1;
			
			Panel separatorColor2 = new Panel();
			separatorColor2.BorderStyle = BorderStyle.Fixed3D;
			separatorColor2.Width = 32; separatorColor2.Height = 16;
			separatorColor2.Click += HandleSeparatorColorClick;
			separatorColor2.BackColor = eff.SeparatorColor2;
			
			AddRight(separatorColor2);
			AddRight(separatorColor1);
			AddText("Цвета границы");			
			
			ComboBox separatorStyleCb = new ComboBox();		
			separatorStyleCb.DropDownStyle = ComboBoxStyle.DropDownList;
			separatorStyleCb.Items.AddRange(new object[]{				
				"Сплошная линия",
				"Размытие",
				"Мозаика"
			});
			separatorStyleCb.SelectedIndex = 0;
			
			AddTextCol("Тип границы");
			AddRow(separatorStyleCb);
			
			Button btnOk = new Button();
			btnOk.Text = "Ok";
			btnOk.Click += delegate {
				eff.ImagesCount = imagesCountCb.SelectedIndex + 2;
				eff.SeparatorSize = separatorSizeTb.Value;
				eff.SeparatorColor1 = separatorColor1.BackColor;
				eff.SeparatorColor2 = separatorColor2.BackColor;
				
				DialogResult = DialogResult.OK;
			};
			
			AddRight(btnOk);
			
			this.LockDialogHeight();
		}

		void HandleSeparatorColorClick (object sender, EventArgs e) {
			ColorDialog dlg = new ColorDialog();
			dlg.Color = ((Panel)sender).BackColor;
			if (dlg.ShowDialog() == DialogResult.OK)
				((Panel)sender).BackColor = dlg.Color;
		}
				
	}
	*/
}
