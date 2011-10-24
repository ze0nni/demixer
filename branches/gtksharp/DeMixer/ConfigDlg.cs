
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
				SourceComboBox.AppendText(s.PluginTitle);
			}			
			SourceComboBox.Active = Kernel.ActiveSourceIndex;
			SourceComboBox.ShowAll();
			
			foreach (ImagesComposition c in Kernel.CompositionList) {
				CompositionComboBox.AppendText(c.PluginTitle);	
			}
			CompositionComboBox.Active = Kernel.ActiveCompositionIndex;
			CompositionComboBox.ShowAll();
			foreach (ImagePostEffect e in Kernel.PostEffectsList) {
				EffectsComboBox.AppendText(e.PluginTitle);	
			}
			EffectsComboBox.ShowAll();
		}

		protected virtual void OnSourceComboBoxChanged (object sender, System.EventArgs e) {
			Kernel.ActiveSourceIndex = SourceComboBox.Active;
			SourceInformationLabel.Markup = Kernel.ActiveSource.PluginDescription;
		}

		protected virtual void OnCompositionComboBoxChanged (object sender, System.EventArgs e) {
			Kernel.ActiveCompositionIndex = CompositionComboBox.Active;
			CompositionInformationLabel.Markup = Kernel.ActiveComposition.PluginDescription;
		}

		protected virtual void OnEffectsComboBoxChanged (object sender, System.EventArgs e) {
			EffectInformationLabel.Markup = 
				Kernel.PostEffectsList[EffectsComboBox.Active].PluginDescription;
		}
	}
}
