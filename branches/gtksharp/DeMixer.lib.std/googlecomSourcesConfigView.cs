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
		}
	}
}
