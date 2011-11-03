// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace DeMixer.lib.std {
    
    
    public partial class DirectorySourceConfigView {
        
        private Gtk.HBox hbox1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.FileChooserButton folderNavBox;
        
        private Gtk.ScrolledWindow Scrolled;
        
        private Gtk.TreeView FoldersList;
        
        private Gtk.VButtonBox vbuttonbox1;
        
        private Gtk.Button folderAddBtn;
        
        private Gtk.Button folderDeleteBtn;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget DeMixer.lib.std.DirectorySourceConfigView
            Stetic.BinContainer.Attach(this);
            this.Name = "DeMixer.lib.std.DirectorySourceConfigView";
            // Container child DeMixer.lib.std.DirectorySourceConfigView.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.folderNavBox = new Gtk.FileChooserButton(Mono.Unix.Catalog.GetString("browse folder"), ((Gtk.FileChooserAction)(2)));
            this.folderNavBox.Name = "folderNavBox";
            this.vbox2.Add(this.folderNavBox);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.folderNavBox]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.Scrolled = new Gtk.ScrolledWindow();
            this.Scrolled.Name = "Scrolled";
            this.Scrolled.ShadowType = ((Gtk.ShadowType)(1));
            // Container child Scrolled.Gtk.Container+ContainerChild
            this.FoldersList = new Gtk.TreeView();
            this.FoldersList.CanFocus = true;
            this.FoldersList.Name = "FoldersList";
            this.Scrolled.Add(this.FoldersList);
            this.vbox2.Add(this.Scrolled);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.Scrolled]));
            w3.Position = 1;
            this.hbox1.Add(this.vbox2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
            w4.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbuttonbox1 = new Gtk.VButtonBox();
            this.vbuttonbox1.Name = "vbuttonbox1";
            this.vbuttonbox1.Spacing = 4;
            this.vbuttonbox1.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
            // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
            this.folderAddBtn = new Gtk.Button();
            this.folderAddBtn.CanFocus = true;
            this.folderAddBtn.Name = "folderAddBtn";
            this.folderAddBtn.UseUnderline = true;
            // Container child folderAddBtn.Gtk.Container+ContainerChild
            Gtk.Alignment w5 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w6 = new Gtk.HBox();
            w6.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w7 = new Gtk.Image();
            w7.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-add", Gtk.IconSize.Menu, 19);
            w6.Add(w7);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w9 = new Gtk.Label();
            w9.LabelProp = Mono.Unix.Catalog.GetString("_Add");
            w9.UseUnderline = true;
            w6.Add(w9);
            w5.Add(w6);
            this.folderAddBtn.Add(w5);
            this.vbuttonbox1.Add(this.folderAddBtn);
            Gtk.ButtonBox.ButtonBoxChild w13 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.folderAddBtn]));
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
            this.folderDeleteBtn = new Gtk.Button();
            this.folderDeleteBtn.CanFocus = true;
            this.folderDeleteBtn.Name = "folderDeleteBtn";
            this.folderDeleteBtn.UseUnderline = true;
            // Container child folderDeleteBtn.Gtk.Container+ContainerChild
            Gtk.Alignment w14 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w15 = new Gtk.HBox();
            w15.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w16 = new Gtk.Image();
            w16.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-delete", Gtk.IconSize.Menu, 19);
            w15.Add(w16);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w18 = new Gtk.Label();
            w18.LabelProp = Mono.Unix.Catalog.GetString("_Delete");
            w18.UseUnderline = true;
            w15.Add(w18);
            w14.Add(w15);
            this.folderDeleteBtn.Add(w14);
            this.vbuttonbox1.Add(this.folderDeleteBtn);
            Gtk.ButtonBox.ButtonBoxChild w22 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.folderDeleteBtn]));
            w22.Position = 1;
            w22.Expand = false;
            w22.Fill = false;
            this.hbox1.Add(this.vbuttonbox1);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbuttonbox1]));
            w23.Position = 1;
            w23.Expand = false;
            w23.Fill = false;
            this.Add(this.hbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
            this.folderNavBox.SelectionChanged += new System.EventHandler(this.OnFolderNavBoxSelectionChanged);
            this.FoldersList.CursorChanged += new System.EventHandler(this.OnFoldersListCursorChanged);
            this.folderAddBtn.Clicked += new System.EventHandler(this.OnFolderAddBtnClicked);
            this.folderDeleteBtn.Clicked += new System.EventHandler(this.OnFolderDeleteBtnClicked);
        }
    }
}
