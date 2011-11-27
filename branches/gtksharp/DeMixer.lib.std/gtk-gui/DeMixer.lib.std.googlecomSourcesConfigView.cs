
// This file has been generated by the GUI designer. Do not modify.
namespace DeMixer.lib.std
{
	public partial class googlecomSourcesConfigView
	{
		private global::Gtk.VBox vbox5;
		private global::Gtk.HBox hbox7;
		private global::Gtk.Label label5;
		private global::Gtk.Entry tagsEdit;
		private global::Gtk.ComboBox combobox1;
		private global::Gtk.HBox hbox8;
		private global::Gtk.Label size;
		private global::Gtk.ComboBox imageSizeCombo;
		private global::Gtk.Label label7;
		private global::Gtk.ComboBox imageColorCombo;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DeMixer.lib.std.googlecomSourcesConfigView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "DeMixer.lib.std.googlecomSourcesConfigView";
			// Container child DeMixer.lib.std.googlecomSourcesConfigView.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Responce");
			this.hbox7.Add (this.label5);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.label5]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.tagsEdit = new global::Gtk.Entry ();
			this.tagsEdit.CanFocus = true;
			this.tagsEdit.Name = "tagsEdit";
			this.tagsEdit.IsEditable = true;
			this.tagsEdit.InvisibleChar = '●';
			this.hbox7.Add (this.tagsEdit);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.tagsEdit]));
			w2.Position = 1;
			// Container child hbox7.Gtk.Box+BoxChild
			this.combobox1 = global::Gtk.ComboBox.NewText ();
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("<none>"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("add \"Desktop wallpaper\""));
			this.combobox1.Name = "combobox1";
			this.combobox1.Active = 0;
			this.hbox7.Add (this.combobox1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.combobox1]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox5.Add (this.hbox7);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox7]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.size = new global::Gtk.Label ();
			this.size.Name = "size";
			this.size.LabelProp = global::Mono.Unix.Catalog.GetString ("Images size");
			this.hbox8.Add (this.size);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.size]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.imageSizeCombo = global::Gtk.ComboBox.NewText ();
			this.imageSizeCombo.Name = "imageSizeCombo";
			this.hbox8.Add (this.imageSizeCombo);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.imageSizeCombo]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Color");
			this.hbox8.Add (this.label7);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.label7]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.imageColorCombo = global::Gtk.ComboBox.NewText ();
			this.imageColorCombo.Name = "imageColorCombo";
			this.hbox8.Add (this.imageColorCombo);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.imageColorCombo]));
			w8.Position = 3;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox5.Add (this.hbox8);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox8]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.Add (this.vbox5);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.tagsEdit.Changed += new global::System.EventHandler (this.OnTagsEditChanged);
			this.imageSizeCombo.Changed += new global::System.EventHandler (this.OnImageSizeComboChanged);
			this.imageColorCombo.Changed += new global::System.EventHandler (this.OnImageColorComboChanged);
		}
	}
}
