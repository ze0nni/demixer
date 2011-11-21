using System;

namespace DeMixer.lib.std {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CompositionSeasonsConfigView : Gtk.Bin {
		CompositionSeasons Compostion;

		public CompositionSeasonsConfigView(CompositionSeasons compostion) {
			this.Build();
			Compostion = compostion;
		}
	}
}

