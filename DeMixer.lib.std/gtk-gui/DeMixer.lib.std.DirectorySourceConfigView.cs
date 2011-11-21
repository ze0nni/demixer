
// This file has been generated by the GUI designer. Do not modify.
namespace DeMixer.lib.std
{
	public partial class DirectorySourceConfigView
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.VBox vbox2;
		private global::Gtk.FileChooserButton folderNavBox;
		private global::Gtk.ScrolledWindow Scrolled;
		private global::Gtk.TreeView FoldersList;
		private global::Gtk.VButtonBox vbuttonbox1;
		private global::Gtk.Button folderAddBtn;
		private global::Gtk.Button folderApplyBtn;
		private global::Gtk.Button folderDeleteBtn;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DeMixer.lib.std.DirectorySourceConfigView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "DeMixer.lib.std.DirectorySourceConfigView";
			// Container child DeMixer.lib.std.DirectorySourceConfigView.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.folderNavBox = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("browse folder"), ((global::Gtk.FileChooserAction)(2)));
			this.folderNavBox.Name = "folderNavBox";
			this.vbox2.Add (this.folderNavBox);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.folderNavBox]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.Scrolled = new global::Gtk.ScrolledWindow ();
			this.Scrolled.Name = "Scrolled";
			this.Scrolled.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child Scrolled.Gtk.Container+ContainerChild
			this.FoldersList = new global::Gtk.TreeView ();
			this.FoldersList.CanFocus = true;
			this.FoldersList.Name = "FoldersList";
			this.Scrolled.Add (this.FoldersList);
			this.vbox2.Add (this.Scrolled);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.Scrolled]));
			w3.Position = 1;
			this.hbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox2]));
			w4.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbuttonbox1 = new global::Gtk.VButtonBox ();
			this.vbuttonbox1.Name = "vbuttonbox1";
			this.vbuttonbox1.Spacing = 4;
			this.vbuttonbox1.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.folderAddBtn = new global::Gtk.Button ();
			this.folderAddBtn.CanFocus = true;
			this.folderAddBtn.Name = "folderAddBtn";
			this.folderAddBtn.UseUnderline = true;
			// Container child folderAddBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w5 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w6 = new global::Gtk.HBox ();
			w6.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w7 = new global::Gtk.Image ();
			w7.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			w6.Add (w7);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w9 = new global::Gtk.Label ();
			w9.LabelProp = global::Mono.Unix.Catalog.GetString ("_Add");
			w9.UseUnderline = true;
			w6.Add (w9);
			w5.Add (w6);
			this.folderAddBtn.Add (w5);
			this.vbuttonbox1.Add (this.folderAddBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1 [this.folderAddBtn]));
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.folderApplyBtn = new global::Gtk.Button ();
			this.folderApplyBtn.CanFocus = true;
			this.folderApplyBtn.Name = "folderApplyBtn";
			this.folderApplyBtn.UseUnderline = true;
			// Container child folderApplyBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w14 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w15 = new global::Gtk.HBox ();
			w15.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w16 = new global::Gtk.Image ();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			w15.Add (w16);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w18 = new global::Gtk.Label ();
			w18.LabelProp = global::Mono.Unix.Catalog.GetString ("_Apply");
			w18.UseUnderline = true;
			w15.Add (w18);
			w14.Add (w15);
			this.folderApplyBtn.Add (w14);
			this.vbuttonbox1.Add (this.folderApplyBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w22 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1 [this.folderApplyBtn]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.folderDeleteBtn = new global::Gtk.Button ();
			this.folderDeleteBtn.CanFocus = true;
			this.folderDeleteBtn.Name = "folderDeleteBtn";
			this.folderDeleteBtn.UseUnderline = true;
			// Container child folderDeleteBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w23 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w24 = new global::Gtk.HBox ();
			w24.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w25 = new global::Gtk.Image ();
			w25.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			w24.Add (w25);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w27 = new global::Gtk.Label ();
			w27.LabelProp = global::Mono.Unix.Catalog.GetString ("_Delete");
			w27.UseUnderline = true;
			w24.Add (w27);
			w23.Add (w24);
			this.folderDeleteBtn.Add (w23);
			this.vbuttonbox1.Add (this.folderDeleteBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w31 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1 [this.folderDeleteBtn]));
			w31.Position = 2;
			w31.Expand = false;
			w31.Fill = false;
			this.hbox1.Add (this.vbuttonbox1);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbuttonbox1]));
			w32.Position = 1;
			w32.Expand = false;
			w32.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.FoldersList.CursorChanged += new global::System.EventHandler (this.OnFoldersListCursorChanged);
			this.folderAddBtn.Clicked += new global::System.EventHandler (this.OnFolderAddBtnClicked);
			this.folderApplyBtn.Clicked += new global::System.EventHandler (this.OnFolderApplyBtnClicked);
			this.folderDeleteBtn.Clicked += new global::System.EventHandler (this.OnFolderDeleteBtnClicked);
		}
	}
}
