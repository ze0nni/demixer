
using System;

namespace DeMixer.lib.std
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class DirectorySourceConfigView : Gtk.Bin
	{
		
		DirectorySource Source;
		public DirectorySourceConfigView(DirectorySource source) {
			this.Build();
			Source = source;			
		}
	}
}
