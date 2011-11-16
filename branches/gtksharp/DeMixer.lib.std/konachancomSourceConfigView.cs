
using System;

namespace DeMixer.lib.std
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class konachancomSourceConfigView : Gtk.Bin
	{
		konachancomSource Source;

		protected virtual void OnTagsEditChanged (object sender, System.EventArgs e) {
			Source.Tags = tagsEdit.Text;
		}
		
		public konachancomSourceConfigView(konachancomSource source) {
			this.Build();
			Source = source;
			tagsEdit.Text = Source.Tags;
		}
	}
}
