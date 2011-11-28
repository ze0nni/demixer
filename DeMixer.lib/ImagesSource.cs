using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using Gtk;

namespace DeMixer.lib {
	public abstract class ImagesSource : DeMixerPlugin {
		
		public ImagesSource() {
		}
		
		public virtual string Url {
			get { return ""; }	
		}
		
		public virtual string PluginDescription {
			get { return Kernel.Translate(string.Format("{0} description", GetType().FullName)); }
		}		

		private string FTags;

		public virtual string Tags {
			get { return FTags; }
			set { FTags = value; }
		}
		
		public virtual Gtk.Widget ExpandTagsControl {
			get { return null; }		
		}

		public abstract System.Drawing.Image GetNextImage();

		public abstract System.Drawing.Image GetImageFromSource(string source);	
		
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
		
		public override string ToString() {
			return PluginTitle;
		}

	}
}
