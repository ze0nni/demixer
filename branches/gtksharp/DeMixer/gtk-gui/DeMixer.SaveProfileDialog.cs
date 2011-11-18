
// This file has been generated by the GUI designer. Do not modify.
namespace DeMixer
{
	public partial class SaveProfileDialog
	{
		private global::Gtk.VBox vbox4;

		private global::Gtk.Entry entry1;

		private global::Gtk.HBox hbox4;

		private global::Gtk.CheckButton checkbutton2;

		private global::Gtk.CheckButton checkbutton3;

		private global::Gtk.CheckButton checkbutton4;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DeMixer.SaveProfileDialog
			this.Name = "DeMixer.SaveProfileDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.BorderWidth = ((uint)(3));
			// Internal child DeMixer.SaveProfileDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.entry1 = new global::Gtk.Entry ();
			this.entry1.CanFocus = true;
			this.entry1.Name = "entry1";
			this.entry1.IsEditable = true;
			this.entry1.InvisibleChar = '●';
			this.vbox4.Add (this.entry1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.entry1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			this.hbox4.BorderWidth = ((uint)(3));
			// Container child hbox4.Gtk.Box+BoxChild
			this.checkbutton2 = new global::Gtk.CheckButton ();
			this.checkbutton2.CanFocus = true;
			this.checkbutton2.Name = "checkbutton2";
			this.checkbutton2.Label = global::Mono.Unix.Catalog.GetString ("Save source");
			this.checkbutton2.DrawIndicator = true;
			this.checkbutton2.UseUnderline = true;
			this.hbox4.Add (this.checkbutton2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.checkbutton2]));
			w3.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.checkbutton3 = new global::Gtk.CheckButton ();
			this.checkbutton3.CanFocus = true;
			this.checkbutton3.Name = "checkbutton3";
			this.checkbutton3.Label = global::Mono.Unix.Catalog.GetString ("Save composition");
			this.checkbutton3.DrawIndicator = true;
			this.checkbutton3.UseUnderline = true;
			this.hbox4.Add (this.checkbutton3);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.checkbutton3]));
			w4.Position = 1;
			// Container child hbox4.Gtk.Box+BoxChild
			this.checkbutton4 = new global::Gtk.CheckButton ();
			this.checkbutton4.CanFocus = true;
			this.checkbutton4.Name = "checkbutton4";
			this.checkbutton4.Label = global::Mono.Unix.Catalog.GetString ("Save effects");
			this.checkbutton4.DrawIndicator = true;
			this.checkbutton4.UseUnderline = true;
			this.hbox4.Add (this.checkbutton4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.checkbutton4]));
			w5.Position = 2;
			this.vbox4.Add (this.hbox4);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox4]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			w1.Add (this.vbox4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(w1[this.vbox4]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Internal child DeMixer.SaveProfileDialog.ActionArea
			global::Gtk.HButtonBox w8 = this.ActionArea;
			w8.Name = "dialog1_ActionArea";
			w8.Spacing = 6;
			w8.BorderWidth = ((uint)(5));
			w8.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w8[this.buttonCancel]));
			w9.Expand = false;
			w9.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w10 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w8[this.buttonOk]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 325;
			this.DefaultHeight = 143;
			this.Show ();
		}
	}
}
