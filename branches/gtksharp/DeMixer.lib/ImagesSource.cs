using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using Gtk;

namespace DeMixer.lib {
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
		
		public virtual string PluginDescription {
			get { return Kernel.Translate(string.Format("{0} description", GetType().FullName)); }
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
		
		public virtual Gtk.Widget ExpandTagsControl {
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

		public abstract System.Drawing.Image GetNextImage();

		public abstract System.Drawing.Image GetImageFromSource(string source);
		
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
		
		public void GetNextImages(System.Drawing.Image[] buffer, uint tryCount) {
			ManualResetEvent endChek = new ManualResetEvent(false);
			Exception lastExc = null;
			List<System.Drawing.Image> images = new List<System.Drawing.Image>();			
			endChek.Reset();
			
			for (int i=0; i<buffer.Length; i++) {
				Thread t = new Thread((ThreadStart)delegate {
					System.Drawing.Image img = null;
					Exception exc = null;
					for (int trys=0; trys<tryCount; trys++) {					
						try {
							exc = null;
							img = GetNextImage();	
							break;
						} catch (Exception e) {
							exc = e;
						}					
					}
					lock (endChek) {
						if (exc == null) {
							images.Add(img);	
						} else {
							lastExc = exc;
							images.Add(null);
						}			
						if (buffer.Length == images.Count)
							endChek.Set();
					}
				});				
				t.Start();
			}
			
			endChek.WaitOne();			
			if (lastExc != null)
				throw lastExc;
			for (int i=0; i<buffer.Length; i++) {
				buffer[i] = images[i];
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
		
		public override string ToString() {
			return PluginTitle;
		}

	}
}
