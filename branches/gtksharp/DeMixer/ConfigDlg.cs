
using System;
using DeMixer.lib;
using Gdk;

namespace DeMixer
{
	
	
	public partial class ConfigDlg : Gtk.Dialog
	{

		protected virtual void OnButton83Clicked (object sender, System.EventArgs e) {
			SaveProfileDialog dlg = new SaveProfileDialog();
			dlg.ShowAll();
		}	
		
		IDeMixerKernel Kernel;
		public ConfigDlg(IDeMixerKernel k) {			
			this.Build();
			Kernel = k;
			init();			
		}
		
		void init() {
			foreach (ImagesSource s in Kernel.SourceList) {
				SourceComboBox.AppendText(s.ToString());
			}			
			SourceComboBox.ShowAll();
			
			foreach (ImagesComposition c in Kernel.CompositionList) {
				CompositionComboBox.AppendText(c.ToString());	
			}
			CompositionComboBox.ShowAll();
			foreach (ImagePostEffect e in Kernel.PostEffectsList) {
				EffectsComboBox.AppendText(e.ToString());	
			}
			EffectsComboBox.ShowAll();
		}
	}
}
