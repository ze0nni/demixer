using System;

namespace DeMixer.lib.std {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class googlecomSourcesConfigView : Gtk.Bin {
		googlecomSources Source;

		protected virtual void OnTagsEditChanged(object sender, System.EventArgs e) {
			Source.Tags = tagsEdit.Text;
		}
		
		public googlecomSourcesConfigView(googlecomSources source) {
			this.Build();
			Source = source;
			tagsEdit.Text = Source.Tags;			
			//todo: init params
		}
		
		int comboboxIndexof(Gtk.ComboBox cb, string item) {
			//todo :return -1;
		}
		
		protected void OnImageSizeComboChanged (object sender, System.EventArgs e) {
			Source.imgSize = imageSizeCombo.ActiveText;
		}

		protected void OnImageColorComboChanged (object sender, System.EventArgs e) {
			Source.imgColor = imageColorCombo.ActiveText;
		}
	}
}
