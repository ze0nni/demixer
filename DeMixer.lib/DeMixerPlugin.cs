using System;
using DeMixer.lib;

namespace DeMixer.lib {	
	public abstract class DeMixerPlugin {
		public void Init(IDeMixerKernel k) {
			kernel = k;
		}
		
		IDeMixerKernel kernel;

		protected IDeMixerKernel Kernel {
			get { return kernel; }	
		}
		
		public string PluginName {
			get { return Kernel.Translate(string.Format("{0} name", GetType().FullName)); }
		}
		
		public string PluginTitle {
			get { return Kernel.Translate(string.Format("{0} title", GetType().FullName)); }
		}
		
		public string PluginDescription {
			get { return Kernel.Translate(string.Format("{0} description", GetType().FullName)); }
		}
		
		protected virtual void Write(System.Xml.XmlWriter cfg) {
			cfg.WriteComment("not options");	
		}
		
		protected virtual void Read(System.Xml.XmlNode r) {
		}
		
		public void ReadConfig(System.Xml.XmlNode r) {
			if (r.Name != "plugin")
				throw new DeMixerException(Kernel.Translate("Bad xmlNode {0} need {1}", r.Name, "plugin"));
			if (r.Attributes["class"].InnerText != this.GetType().FullName) 
				throw new DeMixerException(Kernel.Translate("Bad xmlAttribute value {0} need {1}",
					r.Attributes["class"].InnerText,
					this.GetType().FullName));
			Read(r);
		}
		
		public void WriteConfig(System.Xml.XmlWriter cfg) {			
			cfg.WriteStartElement("plugin");
			cfg.WriteAttributeString("class", this.GetType().FullName);
			try {
				Write(cfg);	
			} catch (Exception exc) {
				cfg.WriteComment(exc.ToString());
				throw;
			} finally {
				cfg.WriteEndElement();
			}
		}
		/// <summary>
		/// Reads the config from file.
		/// </summary>
		/// <param name='k'>
		/// K.
		/// </param>
		public void ReadConfigFromFile(IDeMixerKernel k) {
						
			string fileName = k.GetUserFileName("plugins",
			                                    "settings",
			                                    GetType().FullName + ".xml");
			if (!System.IO.File.Exists(fileName)) return;
			System.Xml.XmlDocument cfg = new System.Xml.XmlDocument();
			cfg.Load(fileName);
			try {
				ReadConfig(cfg.FirstChild);
			} finally {
				
			}
		}				
		
		/// <summary>
		/// Writes the config to file.
		/// </summary>
		/// <param name='k'>
		/// K.
		/// </param>
		public void WriteConfigToFile(IDeMixerKernel k) {
			string fileName = k.GetUserFileName("plugins",
			                                    "settings",
			                                    GetType().FullName + ".xml");
			System.Xml.XmlTextWriter cfg = new System.Xml.XmlTextWriter(fileName, System.Text.Encoding.UTF8);			
			try {
				WriteConfig(cfg);
			} finally {								
				cfg.Close();
			}
		}
	}
}

