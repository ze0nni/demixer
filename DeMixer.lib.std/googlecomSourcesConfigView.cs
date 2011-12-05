using System;

namespace DeMixer.lib.std {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class googlecomSourcesConfigView : Gtk.Bin {
		googlecomSources Source;

		protected virtual void OnTagsEditChanged(object sender, System.EventArgs e) {			
			Source.Tags = tagsEdit.Text;			
		}
		
		IDeMixerKernel Kernel;
		public googlecomSourcesConfigView(googlecomSources source, IDeMixerKernel k ) {
			this.Build();
			Source = source;
			Kernel = k;
			Kernel.TranslateWidget(this);
			tagsEdit.Text = Source.Tags;						
			foreach (string s in Source.SizeEnum) {
				imageSizeCombo.AppendText(k.Translate(s));
			}
			imageSizeCombo.ShowAll();
			imageSizeCombo.Active = Source.ImgSize;
			
			foreach (string c in Source.ColorEnum) {
				imageColorCombo.AppendText(k.Translate(c));
			}
			imageColorCombo.ShowAll();
			imageColorCombo.Active = Source.ImgColor;
		}
		
		protected void OnImageSizeComboChanged (object sender, System.EventArgs e) {
			Source.ImgSize = imageSizeCombo.Active;
		}

		protected void OnImageColorComboChanged (object sender, System.EventArgs e) {
			Source.ImgColor = imageColorCombo.Active;
		}
	}
}
