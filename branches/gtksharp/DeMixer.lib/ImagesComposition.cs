
using System;
using System.Drawing;
using System.IO;

namespace DeMixer.lib {
	
	
	public abstract class ImagesComposition {		
		
		
		public void Init(IDeMixerKernel k) {
			kernel = k;
		}
		
		IDeMixerKernel kernel;
		protected IDeMixerKernel Kernel {
			get { return kernel; }	
		}
		
		public virtual string PluginName {
			get { return Kernel.Translate(string.Format("{0} name", GetType().FullName)); }
		}
		
		public virtual string PluginTitle {
			get { return Kernel.Translate(string.Format("{0} title", GetType().FullName)); }
		}
		
		public virtual string PluginDescription {
			get { return Kernel.Translate(string.Format("{0} description", GetType().FullName)); }
		}
		
		public virtual void ShowDialog() {			
		}
		
		public virtual bool SaveConfig(Stream stream) {
			
			return true;
		}
		
		public virtual bool LoadConfig(Stream stream) {			
			
			return true;
		}
		
		public virtual Gtk.Widget ExpandControl {
			get { return null; }		
		}
				
		
		public virtual void ReadSettings(IDeMixerKernel k) {
			string fileName = k.GetUserFileName("plugins",
			                                    "settings",
			                                    GetType().FullName);
			FileStream fs = new FileStream(fileName, FileMode.Open);
			try { 				
				LoadConfig(fs);				
			} catch {
			} finally {
				fs.Close();
			}
		}
		
		public virtual void WriteSettings(IDeMixerKernel k) {
			string fileName = k.GetUserFileName("plugins",
			                                    "settings",
			                                    GetType().FullName);
			FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
			try { 
				SaveConfig(fs);				
			} catch {				
			} finally {
				fs.Close();
			}
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
