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
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.NodeView FolderView;
        
        private Gtk.CheckButton checkbutton1;
        
        private Gtk.VButtonBox vbuttonbox1;
        
        private Gtk.Button button11;
        
        private Gtk.Button button12;
        
        private Gtk.Button button13;
        
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
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.FolderView = new Gtk.NodeView();
            this.FolderView.CanFocus = true;
            this.FolderView.Name = "FolderView";
            this.GtkScrolledWindow.Add(this.FolderView);
            this.vbox2.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
            w2.Position = 0;
            // Container child vbox2.Gtk.Box+BoxChild
            this.checkbutton1 = new Gtk.CheckButton();
            this.checkbutton1.CanFocus = true;
            this.checkbutton1.Name = "checkbutton1";
            this.checkbutton1.Label = Mono.Unix.Catalog.GetString("Force Search");
            this.checkbutton1.DrawIndicator = true;
            this.checkbutton1.UseUnderline = true;
            this.vbox2.Add(this.checkbutton1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.checkbutton1]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.hbox1.Add(this.vbox2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
            w4.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbuttonbox1 = new Gtk.VButtonBox();
            this.vbuttonbox1.Name = "vbuttonbox1";
            this.vbuttonbox1.Spacing = 4;
            this.vbuttonbox1.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
            // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
            this.button11 = new Gtk.Button();
            this.button11.CanFocus = true;
            this.button11.Name = "button11";
            this.button11.UseUnderline = true;
            // Container child button11.Gtk.Container+ContainerChild
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
            this.button11.Add(w5);
            this.vbuttonbox1.Add(this.button11);
            Gtk.ButtonBox.ButtonBoxChild w13 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.button11]));
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
            this.button12 = new Gtk.Button();
            this.button12.CanFocus = true;
            this.button12.Name = "button12";
            this.button12.UseUnderline = true;
            // Container child button12.Gtk.Container+ContainerChild
            Gtk.Alignment w14 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w15 = new Gtk.HBox();
            w15.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w16 = new Gtk.Image();
            w16.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-edit", Gtk.IconSize.Menu, 19);
            w15.Add(w16);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w18 = new Gtk.Label();
            w18.LabelProp = Mono.Unix.Catalog.GetString("_Edit");
            w18.UseUnderline = true;
            w15.Add(w18);
            w14.Add(w15);
            this.button12.Add(w14);
            this.vbuttonbox1.Add(this.button12);
            Gtk.ButtonBox.ButtonBoxChild w22 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.button12]));
            w22.Position = 1;
            w22.Expand = false;
            w22.Fill = false;
            // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
            this.button13 = new Gtk.Button();
            this.button13.CanFocus = true;
            this.button13.Name = "button13";
            this.button13.UseUnderline = true;
            // Container child button13.Gtk.Container+ContainerChild
            Gtk.Alignment w23 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w24 = new Gtk.HBox();
            w24.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w25 = new Gtk.Image();
            w25.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-delete", Gtk.IconSize.Menu, 19);
            w24.Add(w25);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w27 = new Gtk.Label();
            w27.LabelProp = Mono.Unix.Catalog.GetString("_Delete");
            w27.UseUnderline = true;
            w24.Add(w27);
            w23.Add(w24);
            this.button13.Add(w23);
            this.vbuttonbox1.Add(this.button13);
            Gtk.ButtonBox.ButtonBoxChild w31 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.button13]));
            w31.Position = 2;
            w31.Expand = false;
            w31.Fill = false;
            this.hbox1.Add(this.vbuttonbox1);
            Gtk.Box.BoxChild w32 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbuttonbox1]));
            w32.Position = 1;
            w32.Expand = false;
            w32.Fill = false;
            this.Add(this.hbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
        }
    }
}