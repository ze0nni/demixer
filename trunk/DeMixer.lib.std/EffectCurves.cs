
using System;
using DeMixer.lib;
using System.Drawing;
using System.Drawing.Imaging;

namespace DeMixer.lib.std {
	
	
	public class EffectCurves : ImagePostEffect {
		
		public EffectCurves() {
		}
		
		public override	string PluginName {
			get { return "Коррекция цвета"; }
		}
		
		public override string PluginTitle {
			get { return  "Коррекция цвета"; }
		}
		
		public override Image Execute(Image img) {
			Bitmap bmp = new Bitmap(img, img.Width, img.Height);
			Rectangle lockRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			BitmapData bmpData = bmp.LockBits(lockRect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			
			byte[] data = new byte[bmpData.Stride * bmpData.Height];
			System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, data.Length);
			
			for (int i=0; i<data.Length; i+=3) {
				byte r = data[i];
				byte g = data[i+1];
				byte b = data[i+2];
				ColorMixer(ref r, ref g, ref b);
				data[i] = r;
				data[i+1] = g;
				data[i+2] = b;
			}
			
			System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
			
			bmp.UnlockBits(bmpData);			
			return bmp;
		}
		
		void ColorMixer(ref byte r, ref byte g, ref byte b) {
			double R = r/255d;
			double G = g/255d;
			double B = b/255d;
			
			double vLen = Math.Sqrt(R*R + G*G + B*B);			
			if (vLen!=0d) {
				double RN = R/vLen;
				double GN = G/vLen;
				double BN = B/vLen;
				
				double Mod = vLen;
				vLen *= (1d-Math.Sin(vLen*Math.PI)*0.05d);
				
				R = RN * Mod * (1d-Math.Sin(R*Math.PI)*0.04d);
				G = GN * Mod * (1d-Math.Sin(G*Math.PI)*0.04d);
				B = BN * Mod * (1d+(0.5d-B)*0.1d);
				
				if (R>1d) R=1d;
				if (G>1d) G=1d;
				if (B>1d) B=1d;
			}
			r = (byte)(255*R);
			g = (byte)(255*G);
			b = (byte)(255*B);
		}
		
		private void init() {
		}
	}
}
