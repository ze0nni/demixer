
using System;
using System.Drawing;

namespace DeMixer.lib.std {	
	public class CompositionAutoSize : ImagesComposition {		
		
		public override Image GetCompostion(int width, int height) {
			Image[] imgs = new Image[1];
			Source.GetNextImages(imgs, 5);
			Image img = imgs[0];
			float sx = (float)width / img.Width;
			float sy = (float)height / img.Height;
			float sn = Math.Max(sx, sy);
			float imgW = img.Width * sn;
			float imgH = img.Height * sn;
			float imgX = (width - imgW) / 2;
			float imgY = (height - imgH) / 2;
						
			Image des = new Bitmap(width, height);	
			Graphics g = Graphics.FromImage(des);
			
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.DrawImage(img, imgX, imgY, imgW, imgH);
			return des;
		}
	}
}
