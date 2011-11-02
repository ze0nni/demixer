
using System;

namespace DeMixer.lib.std
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class konachancomSourceConfigView : Gtk.Bin
	{
		konachancomSource Source;
		public konachancomSourceConfigView(konachancomSource source)
		{
			this.Build();
			Source = source;
		}
	}
}
