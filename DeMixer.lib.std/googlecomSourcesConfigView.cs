
using System;

namespace DeMixer.lib.std
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class googlecomSourcesConfigView : Gtk.Bin
	{
		googlecomSources Source;
		public googlecomSourcesConfigView(googlecomSources source)
		{
			this.Build();
			Source = source;
		}
	}
}
