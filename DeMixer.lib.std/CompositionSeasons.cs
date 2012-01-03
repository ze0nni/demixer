using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace DeMixer.lib.std {
	public class CompositionSeasons : ImagesComposition {
		
		public CompositionSeasons() {
		}
		
		int imagesCount = 4;

		public int ImagesCount {
			get { return imagesCount; }
			set {
				if (value >= 2 && value <= 7)
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
		
		DashStyle lineStyle = DashStyle.Solid;
		public DashStyle LineStyle {
			get { return lineStyle; }
			set { lineStyle = value; }
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
		
		int separatorAngle = 0;
		public int SeparatorAngle {
			get { return separatorAngle; }
			set {
				separatorAngle = value;
				if (separatorAngle > 30) separatorAngle = 30;
				if (separatorAngle < -30) separatorAngle = -30;
			}
		}
		
		int separatorOffset = 0;
		public int SeparatorOffset {
			get { return separatorOffset; }
			set {
				separatorOffset = value;
				if (separatorOffset > 50) separatorOffset = 50;
				if (separatorOffset < 0) separatorOffset = 0;
			}
		}
		
		public override Image GetCompostion(int width, int height) {
			Image[] imgs = new Image[imagesCount];
			Source.GetNextImages(imgs, 5);
			
			Image des = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(des);
			g.SmoothingMode = SmoothingMode.HighQuality;
			//
			float sectorWidth = width/ImagesCount;
			for (int i=0; i<ImagesCount; i++) {
				//init
				Image img = imgs[i];
				//float angle = 15f * (i % 2 == 1 ? 1 : -1);
				float angle = SeparatorAngle * (float)(Math.Cos(i*Math.PI*(1f + SeparatorOffset/100f)));
				
				PointF center = new PointF(sectorWidth * i + sectorWidth / 2f, height / 2f);				
				Matrix matrix = g.Transform;
				//find image height
				float sectorHeight = height;
				//transform
				g.TranslateTransform(center.X, center.Y);
				//g.RotateTransform(angle);
				//draw
				try {
					
					float imgScale = Math.Max((float)width / img.Width,
				                      (float)sectorHeight / img.Height);
					float neww = img.Width * imgScale;
					float newh = img.Height * imgScale;
					if (i > 0) {
						Matrix matrixR = g.Transform;
						g.RotateTransform(angle);
						g.SetClip(new RectangleF(-sectorWidth/2f, -sectorHeight, sectorWidth*2f, sectorHeight*2f));
						g.Transform = matrixR;
					}
					//Draw image
					g.DrawImage(img, new RectangleF(-neww/2f, -newh/2f, neww, newh));
					g.ResetClip();
					//Draw separator
					if (i > 0 && SeparatorSize > 0) {
						g.RotateTransform(angle);
						g.TranslateTransform(-sectorWidth/2f, 0);											
						
						Brush gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
						new Point(0, 0), new Point(0, height),
						SeparatorColor1,
						SeparatorColor2);
						Pen p = new Pen(gradBrush, SeparatorSize);
						p.DashStyle = LineStyle;
						p.DashOffset = SeparatorSize * i;
						g.DrawLine(p,
						           0,
						           -sectorHeight,
						           0,
						           sectorHeight);
					}
				} finally {
					g.Transform = matrix;
				}
			}
			
			/*
			g.SetClip(new Rectangle(0, 0, width / ImagesCount, height));
			for (int i=0; i<ImagesCount; i++) {
				Image img = imgs[i];
				
				float news = Math.Max((float)width / img.Width,
				                      (float)height / img.Height);
				                      
				                 				
				float neww = img.Width * news;
				float newh = img.Height * news;
				
				float l = 0;
				l = (i * width / ImagesCount) +
					(width / ImagesCount - neww) / 2;
				
				g.DrawImage(img,
				            l,
				            (height - newh) / 2,
				            (int)neww,
				            (int)newh);
				g.TranslateClip(width / ImagesCount, 0);
			}
			
			g.SetClip(new Rectangle(0, 0, width, height));
			
			if (SeparatorSize != 0) {
				Brush gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
					new Point(0, 0), new Point(0, height),
					SeparatorColor1,
					SeparatorColor2);
				Pen p = new Pen(gradBrush, SeparatorSize);
				
				for (int i=1; i<ImagesCount; i++) {										
					g.DrawLine(p,
					           i * width / ImagesCount + SeparatorSize / 4,
					           0,
					           i * width / ImagesCount + SeparatorSize / 4,
					           height);
				}
			}
			*/
			return des;
		}
		
		protected override void Write(System.Xml.XmlWriter cfg) {
			cfg.WriteElementString("count", ImagesCount.ToString());
			cfg.WriteStartElement("separator");
			try {
				cfg.WriteElementString("size", SeparatorSize.ToString());
				cfg.WriteElementString("style", LineStyle.ToString());
				cfg.WriteElementString("color1", SeparatorColor1.Name);
				cfg.WriteElementString("color2", SeparatorColor2.Name);
				cfg.WriteElementString("angle", SeparatorAngle.ToString());
				cfg.WriteElementString("offset", SeparatorOffset.ToString());
			} finally {
				cfg.WriteEndElement();
			}
		}
		
		protected override void Read(System.Xml.XmlNode r) {
			ImagesCount = int.Parse(
					r.SelectSingleNode("count").InnerXml);
			System.Xml.XmlNode sep = r.SelectSingleNode("separator");
			if (sep != null) {
				SeparatorSize = int.Parse(
					sep.SelectSingleNode("size").InnerXml);				
				SeparatorColor1 = Color.FromName(
					sep.SelectSingleNode("color1").InnerXml);
				SeparatorColor1 = Color.FromName(
					sep.SelectSingleNode("color2").InnerXml);
				 SeparatorAngle = int.Parse(
					sep.SelectSingleNode("angle").InnerXml);
				SeparatorOffset = int.Parse(
					sep.SelectSingleNode("offset").InnerXml);
				LineStyle = (DashStyle)Enum.Parse(typeof(DashStyle),
				    sep.SelectSingleNode("style").InnerXml);
			}
		}

		public override Gtk.Widget ExpandControl {
			get {
				return new CompositionSeasonsConfigView(this, Kernel);
			}
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
