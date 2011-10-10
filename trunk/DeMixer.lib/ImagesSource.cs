
using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace DeMixer.lib {
	
	public class GetImageEventArgs : EventArgs {
		public GetImageEventArgs(		                         
		                         Image img,
		                         string source) : base() {
			FNextImage = img;
			FImageSource = source;
		}
		
		private Image FNextImage;
		public Image NextImage {
			get { return FNextImage; }
		}
		
		private string FImageSource;
		public string ImageSource {
			get { return FImageSource; }
		}
	}
	
	public abstract class ImagesSource {
		
		public ImagesSource() {
		}
		
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
		
		public virtual string Url {
			get { return ""; }	
		}
		
		public virtual void UrlClick() {
			ProcessStartInfo psi = new ProcessStartInfo(Url);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();  
		}
		
		public virtual bool AllowTags {
				get { return true; }
		}
		
		private string FTags;
		public virtual string Tags {
			get { return FTags; }
			set { FTags = value; }
		}
		
		public virtual Control ExpandTagsControl {
			get { return null; }		
		}
		
		public virtual bool AllowConfig {
			get { return true; }
		}
		
		public virtual bool SaveConfig(Stream stream) {
			BinaryWriter bw = new BinaryWriter(stream, System.Text.Encoding.UTF8);
			bw.Write(Tags);
			return true;
		}
		
		public virtual bool LoadConfig(Stream stream) {
			BinaryReader br = new BinaryReader(stream, System.Text.Encoding.UTF8);
			Tags = br.ReadString();
			return true;
		}
		
		public virtual bool AcceptDialog {
			get { return false; }
		}
		
		public virtual void ShowDialog(System.Windows.Forms.Form parent) {
				
		}
		
		public abstract Image GetNextImage();
		//todo: get next images ex. With multi threads and multi gets
		
		public abstract Image GetImageFromSource(string source);
		
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
		
		public override string ToString () {
			return PluginTitle;
		}

	}
}
