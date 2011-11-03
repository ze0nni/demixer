
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
			Gtk.TreeIter itr = FoldersListStore.AppendValues(new object[]{true, folderNavBox.Filename});
			FoldersList.Selection.SelectIter(itr);
			updateSeekPath();
		}

		protected virtual void OnFolderNavBoxSelectionChanged (object sender, System.EventArgs e){
			Gtk.TreeIter itr;
			if (FoldersList.Selection.GetSelected(out itr)) {
				FoldersListStore.SetValue(itr, 1, folderNavBox.Filename);
				updateSeekPath();
			}
		}

		protected virtual void OnFoldersListCursorChanged (object sender, System.EventArgs e) {
			Gtk.TreeIter itr;
			if (FoldersList.Selection.GetSelected(out itr)) {
				folderNavBox.SetCurrentFolder(FoldersListStore.GetValue(itr, 1).ToString());
				updateSeekPath();
			}
		}

		protected virtual void OnFolderDeleteBtnClicked (object sender, System.EventArgs e) {
			Gtk.TreeIter itr;
			if (FoldersList.Selection.GetSelected(out itr)) {
				Gtk.TreeIter itrn = itr;
				if (FoldersListStore.IterNext(ref itrn)) {
					FoldersList.Selection.SelectIter(itrn);		
				} //todo: before
				FoldersListStore.Remove(ref itr);
				updateSeekPath();
			}
		}
		
		void updateSeekPath() {
			Source.FSeekPath.Clear();
			Gtk.TreeIter itr;
			if (FoldersListStore.GetIterFirst(out itr)) {
				do {
					Value val = Value.Empty;
					FoldersListStore.GetValue(itr, 1, ref val);
					Source.FSeekPath.Add(val.Val.ToString());
					if (!FoldersListStore.IterNext(ref itr)) break;
				} while (true);
			}
		}
	}
}

	