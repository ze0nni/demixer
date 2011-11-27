using System;

namespace DeMixer.lib.std {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class googlecomSourcesConfigView : Gtk.Bin {
		googlecomSources Source;

		protected virtual void OnTagsEditChanged(object sender, System.EventArgs e) {
			Source.Tags = tagsEdit.Text;			
		}
		
		public googlecomSourcesConfigView(googlecomSources source, IDeMixerKernel k ) {
			this.Build();
			Source = source;
			tagsEdit.Text = Source.Tags;						
			foreach (string s in Source.SizeEnum) {
				imageSizeCombo.AppendText(k.Translate(s));
			}
			imageSizeCombo.ShowAll();
			foreach (string c in Source.ColorEnum) {
				imageColorCombo.AppendText(k.Translate(c));
			}
		}
		
		protected void OnImageSizeComboChanged (object sender, System.EventArgs e) {
			Source.imgSize = imageSizeCombo.ActiveText;
		}

		protected void OnImageColorComboChanged (object sender, System.EventArgs e) {
			Source.imgColor = imageColorCombo.ActiveText;
		}
	}
}
