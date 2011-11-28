
using System;
using System.Drawing;
using System.IO;
using System.Xml;

namespace DeMixer.lib {
	
	
	public abstract class ImagesComposition : DeMixerPlugin {				
		
		IDeMixerKernel kernel;
		protected IDeMixerKernel Kernel {
			get { return kernel; }	
		}
		
		
		public virtual Gtk.Widget ExpandControl {
			get { return null; }		
		}
					
		
		private ImagesSource FSource;
		public ImagesSource Source {
			get { return FSource; }
			set { FSource = value; }
		}
		
		public abstract Image GetCompostion(int width, int height);
		public Image GetCompostion(ImagesSource newsource, int width, int height) {
			ImagesSource src = Source;
			Image res;
			try {
				Source = newsource;
				res = GetCompostion(width, height);				
			} finally {
				Source = src;
			}
			return res;	
		}
		
		public event EventHandler<EventArgs> UpdatePreview;
		public void doUpdatePreview() {
			if (UpdatePreview != null) {
				UpdatePreview(this, new EventArgs());	
			}
		}
	}
}
