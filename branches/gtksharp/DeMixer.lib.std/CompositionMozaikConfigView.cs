using System;
namespace DeMixer.lib.std
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CompositionMozaikConfigView : Gtk.Bin {
		CompositionMozaik Composition;		
		public CompositionMozaikConfigView (CompositionMozaik composition) {
			this.Build ();
			Composition = composition;			
			combobox1.Active = Composition.ImagesCount - 2;
		}

		protected void OnCombobox1Changed (object sender, System.EventArgs e) {
			Composition.ImagesCount = 2 + combobox1.Active;
			Composition.doUpdatePreview();
		}
	}
}