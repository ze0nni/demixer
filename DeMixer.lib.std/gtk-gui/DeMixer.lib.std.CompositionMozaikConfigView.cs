
// This file has been generated by the GUI designer. Do not modify.
namespace DeMixer.lib.std
{
	public partial class CompositionMozaikConfigView
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label2;
		private global::Gtk.ComboBox combobox1;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DeMixer.lib.std.CompositionMozaikConfigView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "DeMixer.lib.std.CompositionMozaikConfigView";
			// Container child DeMixer.lib.std.CompositionMozaikConfigView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Images count");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.combobox1 = global::Gtk.ComboBox.NewText ();
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("1"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("2"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("3"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("4"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("5"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("6"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("7"));
			this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("8"));
			this.combobox1.Name = "combobox1";
			this.combobox1.Active = 0;
			this.hbox2.Add (this.combobox1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.combobox1]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
