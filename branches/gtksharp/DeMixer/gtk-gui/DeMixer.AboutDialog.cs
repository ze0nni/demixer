// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace DeMixer {
    
    
    public partial class AboutDialog {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Image image1;
        
        private Gtk.IconView iconview1;
        
        private Gtk.Button buttonCheckUpdate;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget DeMixer.AboutDialog
            this.Name = "DeMixer.AboutDialog";
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.HasSeparator = false;
            // Internal child DeMixer.AboutDialog.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.image1 = new Gtk.Image();
            this.image1.Name = "image1";
            this.vbox2.Add(this.image1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.image1]));
            w2.Position = 0;
            w2.Expand = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.iconview1 = new Gtk.IconView();
            this.iconview1.CanFocus = true;
            this.iconview1.Name = "iconview1";
            this.vbox2.Add(this.iconview1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.iconview1]));
            w3.Position = 1;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w4.Position = 0;
            // Internal child DeMixer.AboutDialog.ActionArea
            Gtk.HButtonBox w5 = this.ActionArea;
            w5.Name = "dialog1_ActionArea";
            w5.Spacing = 6;
            w5.BorderWidth = ((uint)(5));
            w5.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCheckUpdate = new Gtk.Button();
            this.buttonCheckUpdate.CanDefault = true;
            this.buttonCheckUpdate.CanFocus = true;
            this.buttonCheckUpdate.Name = "buttonCheckUpdate";
            this.buttonCheckUpdate.UseStock = true;
            this.buttonCheckUpdate.UseUnderline = true;
            this.buttonCheckUpdate.Label = "gtk-refresh";
            w5.Add(this.buttonCheckUpdate);
            Gtk.ButtonBox.ButtonBoxChild w6 = ((Gtk.ButtonBox.ButtonBoxChild)(w5[this.buttonCheckUpdate]));
            w6.Expand = false;
            w6.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w7 = ((Gtk.ButtonBox.ButtonBoxChild)(w5[this.buttonOk]));
            w7.Position = 1;
            w7.Expand = false;
            w7.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 404;
            this.DefaultHeight = 300;
            this.Show();
        }
    }
}
