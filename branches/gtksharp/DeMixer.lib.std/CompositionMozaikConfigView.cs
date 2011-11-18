using System;
namespace DeMixer.lib.std
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CompositionMozaikConfigView : Gtk.Bin {
		CompositionMozaik Composition;		
		public CompositionMozaikConfigView (CompositionMozaik composition) {
			this.Build ();
			Composition = composition;
		}
	}
}