
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
			//
			FolderView.AppendColumn("column",
			                        new Gtk.CellRendererText(),
			                        "text", 0);
			FolderView.AppendColumn("column1",
			                        new Gtk.CellRendererText(),
			                        "text", 0);
			FolderView.ShowAll();                        
		}
	}
}
