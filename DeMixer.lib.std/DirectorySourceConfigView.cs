
using System;
using GLib;


namespace DeMixer.lib.std
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class DirectorySourceConfigView : Gtk.Bin
	{
		
		DirectorySource Source;
		Gtk.ListStore FoldersListStore = null;
		
		public DirectorySourceConfigView(DirectorySource source) {
			this.Build();						
			Source = source;
			//Добавляем колонки к списку
			Gtk.TreeViewColumn forcedSearchColumt = new Gtk.TreeViewColumn ();
			forcedSearchColumt.Title = "forced";			
			Gtk.CellRendererToggle forcedSearchCell = new Gtk.CellRendererToggle();
			forcedSearchColumt.PackStart(forcedSearchCell, true);
			forcedSearchColumt.AddAttribute(forcedSearchCell, "active", 0);			
			
			Gtk.TreeViewColumn folderColumt = new Gtk.TreeViewColumn ();
			folderColumt.Title = "folder";
			Gtk.CellRendererText folderCell = new Gtk.CellRendererText();
			folderCell.Editable = true;
			
			folderColumt.PackStart(folderCell, true);
			folderColumt.AddAttribute(folderCell, "text", 1);
			
			FoldersList.AppendColumn(forcedSearchColumt);
			FoldersList.AppendColumn (folderColumt);
			Gtk.CellRendererText FoldersListCell = new Gtk.CellRendererText();
			
			
			FoldersListStore = new Gtk.ListStore (typeof (bool), typeof (string));			
			FoldersList.Model = FoldersListStore;
									
			FoldersList.ShowAll();
			
			FoldersListStore.AppendValues(new object[]{true, "/home/onni/images"});
		}
		
		protected virtual void OnFolderAddBtnClicked (object sender, System.EventArgs e) {
			
			FoldersListStore.AppendValues(new object[]{true, folderNavBox.Filename});
		}

		protected virtual void OnApplyEditBtnClicked (object sender, System.EventArgs e) {			
			
		}		
		
	}
}

	