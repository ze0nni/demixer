
// This file has been generated by the GUI designer. Do not modify.
namespace DeMixer.Source.Flickr
{
	public partial class FlickrSourceWiget
	{
		private global::Gtk.VBox vbox6;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.VBox vbox3;
		private global::Gtk.Entry entry2;
		private global::Gtk.HBox hbox4;
		private global::Gtk.RadioButton byTextCb;
		private global::Gtk.RadioButton byTagsCb;
		private global::Gtk.Label GtkLabel1;
		private global::Gtk.Frame frame2;
		private global::Gtk.Alignment GtkAlignment1;
		private global::Gtk.VBox vbox4;
		private global::Gtk.HBox hbox5;
		private global::Gtk.RadioButton byNoneCb;
		private global::Gtk.RadioButton byGroupCb;
		private global::Gtk.RadioButton byUserCb;
		private global::Gtk.Button SelectGU;
		private global::Gtk.Label GtkLabel2;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label1;
		private global::Gtk.HBox hbox3;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DeMixer.Source.Flickr.FlickrSourceWiget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "DeMixer.Source.Flickr.FlickrSourceWiget";
			// Container child DeMixer.Source.Flickr.FlickrSourceWiget.Gtk.Container+ContainerChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.entry2 = new global::Gtk.Entry ();
			this.entry2.CanFocus = true;
			this.entry2.Name = "entry2";
			this.entry2.IsEditable = true;
			this.entry2.InvisibleChar = '•';
			this.vbox3.Add (this.entry2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.entry2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.byTextCb = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("By text"));
			this.byTextCb.CanFocus = true;
			this.byTextCb.Name = "byTextCb";
			this.byTextCb.DrawIndicator = true;
			this.byTextCb.UseUnderline = true;
			this.byTextCb.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.hbox4.Add (this.byTextCb);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.byTextCb]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.byTagsCb = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("By tags"));
			this.byTagsCb.CanFocus = true;
			this.byTagsCb.Name = "byTagsCb";
			this.byTagsCb.DrawIndicator = true;
			this.byTagsCb.UseUnderline = true;
			this.byTagsCb.Group = this.byTextCb.Group;
			this.hbox4.Add (this.byTagsCb);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.byTagsCb]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.GtkAlignment.Add (this.vbox3);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel1 = new global::Gtk.Label ();
			this.GtkLabel1.Name = "GtkLabel1";
			this.GtkLabel1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Search</b>");
			this.GtkLabel1.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel1;
			this.vbox6.Add (this.frame1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.frame1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(12));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.byNoneCb = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("None"));
			this.byNoneCb.CanFocus = true;
			this.byNoneCb.Name = "byNoneCb";
			this.byNoneCb.DrawIndicator = true;
			this.byNoneCb.UseUnderline = true;
			this.byNoneCb.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.hbox5.Add (this.byNoneCb);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.byNoneCb]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.byGroupCb = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("By group"));
			this.byGroupCb.CanFocus = true;
			this.byGroupCb.Name = "byGroupCb";
			this.byGroupCb.DrawIndicator = true;
			this.byGroupCb.UseUnderline = true;
			this.byGroupCb.Group = this.byNoneCb.Group;
			this.hbox5.Add (this.byGroupCb);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.byGroupCb]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.byUserCb = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("By user"));
			this.byUserCb.Sensitive = false;
			this.byUserCb.CanFocus = true;
			this.byUserCb.Name = "byUserCb";
			this.byUserCb.DrawIndicator = true;
			this.byUserCb.UseUnderline = true;
			this.byUserCb.Group = this.byNoneCb.Group;
			this.hbox5.Add (this.byUserCb);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.byUserCb]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox4.Add (this.hbox5);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox5]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.SelectGU = new global::Gtk.Button ();
			this.SelectGU.Sensitive = false;
			this.SelectGU.CanFocus = true;
			this.SelectGU.Name = "SelectGU";
			this.SelectGU.UseUnderline = true;
			// Container child SelectGU.Gtk.Container+ContainerChild
			global::Gtk.Alignment w12 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w13 = new global::Gtk.HBox ();
			w13.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w14 = new global::Gtk.Image ();
			w13.Add (w14);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w16 = new global::Gtk.Label ();
			w16.LabelProp = global::Mono.Unix.Catalog.GetString ("None");
			w16.UseUnderline = true;
			w13.Add (w16);
			w12.Add (w13);
			this.SelectGU.Add (w12);
			this.vbox4.Add (this.SelectGU);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.SelectGU]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			this.GtkAlignment1.Add (this.vbox4);
			this.frame2.Add (this.GtkAlignment1);
			this.GtkLabel2 = new global::Gtk.Label ();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Additionally</b>");
			this.GtkLabel2.UseMarkup = true;
			this.frame2.LabelWidget = this.GtkLabel2;
			this.vbox6.Add (this.frame2);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.frame2]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Preview");
			this.hbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label1]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			this.hbox3.BorderWidth = ((uint)(3));
			this.hbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.hbox3]));
			w25.Position = 1;
			this.vbox6.Add (this.hbox2);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.hbox2]));
			w26.Position = 2;
			w26.Expand = false;
			w26.Fill = false;
			this.Add (this.vbox6);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.byNoneCb.Toggled += new global::System.EventHandler (this.OnByNoneCbToggled);
			this.SelectGU.Clicked += new global::System.EventHandler (this.OnSelectGUClicked);
		}
	}
}
