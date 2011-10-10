
using System;
using System.Windows.Forms;
using DeMixer.lib;
using System.Xml;
using System.Net;
using System.IO;

namespace DeMixer {
			
	public class UpdateDialog : Form {
		IDeMixerKernel Kernel;
		public UpdateDialog(IDeMixerKernel k) {
			Kernel = k;
			init();
		}
		
		void init() {
			ListBox view = new ListBox();
			view.Dock = DockStyle.Fill;
			view.IntegralHeight = false;
			Controls.Add(view);			
			
			Panel p = new Panel();
			p.Dock = DockStyle.Bottom;
						
			Controls.Add(p);
			
			WebClient wc = new WebClient();			
			wc.DownloadProgressChanged += delegate(object sender, DownloadProgressChangedEventArgs e) {
				Text = Kernel.Translate("core.update download progress {0}%",
				                     (float)e.TotalBytesToReceive/e.BytesReceived*100);
			};
			wc.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e) {
				if (e.Error != null) {
					Text = Kernel.Translate("core.update.error download");
					MessageBox.Show(
					                Kernel.Translate("core.update.error download {0}", e.Error.Message),
					                Kernel.Translate("core.error"));
					return;
				}
				Text = Kernel.Translate("core.update download complite");
				XmlDocument doc = new XmlDocument();
				doc.Load(new MemoryStream(e.Result));
				foreach (XmlNode n in doc.SelectSingleNode("update").SelectSingleNode("files").SelectNodes("file")) {
					try {
						UpdateListItem li = new UpdateListItem(n);
						view.Items.Add(li);
					} catch {}
				}
			};
			wc.DownloadDataAsync(new Uri("http://localhost/demixer/updates.xml"));
		}
	}
	
	internal class UpdateListItem {
		public UpdateListItem(XmlNode n) {
			
		}
	}
}
