
// This file has been generated by the GUI designer. Do not modify.
namespace DeMixer
{
	public partial class ConfigDlg
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Notebook notebook1;

		private global::Gtk.VBox SourceVBox;

		private global::Gtk.HBox hbox8;

		private global::Gtk.VBox vbox3;

		private global::Gtk.ComboBox SourceComboBox;

		private global::Gtk.Label SourceInformationLabel;

		private global::Gtk.Label label1;

		private global::Gtk.VBox CompositionVBox;

		private global::Gtk.HBox hbox9;

		private global::Gtk.VBox vbox4;

		private global::Gtk.ComboBox CompositionComboBox;

		private global::Gtk.Label CompositionInformationLabel;

		private global::Gtk.HBox CompositionVBox1;

		private global::Gtk.Image image776;

		private global::Gtk.Label label3;

		private global::Gtk.VBox vbox5;

		private global::Gtk.HBox hbox2;

		private global::Gtk.VBox vbox7;

		private global::Gtk.HBox hbox10;

		private global::Gtk.ComboBox EffectsComboBox;

		private global::Gtk.Button effectAddBtn;

		private global::Gtk.Label EffectInformationLabel;

		private global::Gtk.HBox hbox3;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView EffectsList;

		private global::Gtk.VButtonBox vbuttonbox1;

		private global::Gtk.Button editEffectBtn;

		private global::Gtk.Button upEffectBtn;

		private global::Gtk.Button downEffectBtn;

		private global::Gtk.Button cloneEffectBtn;

		private global::Gtk.Button deleteEffectBtn;

		private global::Gtk.Label label5;

		private global::Gtk.VBox vbox6;

		private global::Gtk.HBox hbox4;

		private global::Gtk.CheckButton saveHistoryChBox;

		private global::Gtk.FileChooserButton selectSaveHostoryFolderBox;

		private global::Gtk.CheckButton historyLimitSizeChBox;

		private global::Gtk.SpinButton historyMaxSizeSpin;

		private global::Gtk.Label label8;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label9;

		private global::Gtk.Label label10;

		private global::Gtk.HScale hscale2;

		private global::Gtk.Label label11;

		private global::Gtk.ComboBox combobox5;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label label12;

		private global::Gtk.ComboBox combobox6;

		private global::Gtk.CheckButton checkbutton3;

		private global::Gtk.Label label7;

		private global::Gtk.HSeparator hseparator2;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment6;

		private global::Gtk.HBox hbox1;

		private global::Gtk.ComboBox combobox4;

		private global::Gtk.HButtonBox hbuttonbox2;

		private global::Gtk.Button applyProfileBtn;

		private global::Gtk.Button saveProfileBtn;

		private global::Gtk.Button deleteProfileBtn;

		private global::Gtk.Label GtkLabel13;

		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DeMixer.ConfigDlg
			this.Name = "DeMixer.ConfigDlg";
			this.Title = global::Mono.Unix.Catalog.GetString ("Demixer config dialog");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.Modal = true;
			this.BorderWidth = ((uint)(6));
			// Internal child DeMixer.ConfigDlg.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 1;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.SourceVBox = new global::Gtk.VBox ();
			this.SourceVBox.Name = "SourceVBox";
			this.SourceVBox.Spacing = 6;
			this.SourceVBox.BorderWidth = ((uint)(3));
			// Container child SourceVBox.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.SourceComboBox = global::Gtk.ComboBox.NewText ();
			this.SourceComboBox.CanFocus = true;
			this.SourceComboBox.Name = "SourceComboBox";
			this.vbox3.Add (this.SourceComboBox);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.SourceComboBox]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			this.hbox8.Add (this.vbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.vbox3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.SourceInformationLabel = new global::Gtk.Label ();
			this.SourceInformationLabel.Name = "SourceInformationLabel";
			this.SourceInformationLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("SourceInformationLabel");
			this.SourceInformationLabel.UseMarkup = true;
			this.SourceInformationLabel.Wrap = true;
			this.SourceInformationLabel.Selectable = true;
			this.hbox8.Add (this.SourceInformationLabel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.SourceInformationLabel]));
			w4.Position = 1;
			this.SourceVBox.Add (this.hbox8);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.SourceVBox[this.hbox8]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			this.notebook1.Add (this.SourceVBox);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Source");
			this.notebook1.SetTabLabel (this.SourceVBox, this.label1);
			this.label1.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.CompositionVBox = new global::Gtk.VBox ();
			this.CompositionVBox.Name = "CompositionVBox";
			this.CompositionVBox.Spacing = 6;
			this.CompositionVBox.BorderWidth = ((uint)(3));
			// Container child CompositionVBox.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.CompositionComboBox = global::Gtk.ComboBox.NewText ();
			this.CompositionComboBox.Name = "CompositionComboBox";
			this.vbox4.Add (this.CompositionComboBox);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.CompositionComboBox]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			this.hbox9.Add (this.vbox4);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.vbox4]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.CompositionInformationLabel = new global::Gtk.Label ();
			this.CompositionInformationLabel.Name = "CompositionInformationLabel";
			this.CompositionInformationLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("CompositionInformationLabel");
			this.CompositionInformationLabel.UseMarkup = true;
			this.CompositionInformationLabel.Wrap = true;
			this.CompositionInformationLabel.Selectable = true;
			this.hbox9.Add (this.CompositionInformationLabel);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.CompositionInformationLabel]));
			w9.Position = 1;
			this.CompositionVBox.Add (this.hbox9);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.CompositionVBox[this.hbox9]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child CompositionVBox.Gtk.Box+BoxChild
			this.CompositionVBox1 = new global::Gtk.HBox ();
			this.CompositionVBox1.Name = "CompositionVBox1";
			this.CompositionVBox1.Spacing = 6;
			// Container child CompositionVBox1.Gtk.Box+BoxChild
			this.image776 = new global::Gtk.Image ();
			this.image776.Name = "image776";
			this.CompositionVBox1.Add (this.image776);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.CompositionVBox1[this.image776]));
			w11.Position = 1;
			this.CompositionVBox.Add (this.CompositionVBox1);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.CompositionVBox[this.CompositionVBox1]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			this.notebook1.Add (this.CompositionVBox);
			global::Gtk.Notebook.NotebookChild w13 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.CompositionVBox]));
			w13.Position = 1;
			// Notebook tab
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Composition");
			this.notebook1.SetTabLabel (this.CompositionVBox, this.label3);
			this.label3.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			this.vbox5.BorderWidth = ((uint)(3));
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox ();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.EffectsComboBox = global::Gtk.ComboBox.NewText ();
			this.EffectsComboBox.Name = "EffectsComboBox";
			this.hbox10.Add (this.EffectsComboBox);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.EffectsComboBox]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.effectAddBtn = new global::Gtk.Button ();
			this.effectAddBtn.CanFocus = true;
			this.effectAddBtn.Name = "effectAddBtn";
			this.effectAddBtn.UseUnderline = true;
			// Container child effectAddBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w15 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w16 = new global::Gtk.HBox ();
			w16.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w17 = new global::Gtk.Image ();
			w17.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			w16.Add (w17);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w19 = new global::Gtk.Label ();
			w19.LabelProp = global::Mono.Unix.Catalog.GetString ("Add");
			w19.UseUnderline = true;
			w16.Add (w19);
			w15.Add (w16);
			this.effectAddBtn.Add (w15);
			this.hbox10.Add (this.effectAddBtn);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.effectAddBtn]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			this.vbox7.Add (this.hbox10);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox10]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			this.hbox2.Add (this.vbox7);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox7]));
			w25.Position = 0;
			w25.Expand = false;
			w25.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.EffectInformationLabel = new global::Gtk.Label ();
			this.EffectInformationLabel.Name = "EffectInformationLabel";
			this.EffectInformationLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("EffectInformationLabel");
			this.EffectInformationLabel.UseMarkup = true;
			this.EffectInformationLabel.Wrap = true;
			this.EffectInformationLabel.Selectable = true;
			this.hbox2.Add (this.EffectInformationLabel);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.EffectInformationLabel]));
			w26.Position = 1;
			this.vbox5.Add (this.hbox2);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox2]));
			w27.Position = 0;
			w27.Expand = false;
			w27.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.EffectsList = new global::Gtk.TreeView ();
			this.EffectsList.CanFocus = true;
			this.EffectsList.Name = "EffectsList";
			this.GtkScrolledWindow.Add (this.EffectsList);
			this.hbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.GtkScrolledWindow]));
			w29.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbuttonbox1 = new global::Gtk.VButtonBox ();
			this.vbuttonbox1.Name = "vbuttonbox1";
			this.vbuttonbox1.Spacing = 4;
			this.vbuttonbox1.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(3));
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.editEffectBtn = new global::Gtk.Button ();
			this.editEffectBtn.Sensitive = false;
			this.editEffectBtn.CanFocus = true;
			this.editEffectBtn.Name = "editEffectBtn";
			this.editEffectBtn.UseUnderline = true;
			// Container child editEffectBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w30 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w31 = new global::Gtk.HBox ();
			w31.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w32 = new global::Gtk.Image ();
			w32.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu);
			w31.Add (w32);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w34 = new global::Gtk.Label ();
			w34.LabelProp = global::Mono.Unix.Catalog.GetString ("_Edit");
			w34.UseUnderline = true;
			w31.Add (w34);
			w30.Add (w31);
			this.editEffectBtn.Add (w30);
			this.vbuttonbox1.Add (this.editEffectBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w38 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.editEffectBtn]));
			w38.Expand = false;
			w38.Fill = false;
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.upEffectBtn = new global::Gtk.Button ();
			this.upEffectBtn.Sensitive = false;
			this.upEffectBtn.CanFocus = true;
			this.upEffectBtn.Name = "upEffectBtn";
			this.upEffectBtn.UseUnderline = true;
			// Container child upEffectBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w39 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w40 = new global::Gtk.HBox ();
			w40.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w41 = new global::Gtk.Image ();
			w41.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-go-up", global::Gtk.IconSize.Menu);
			w40.Add (w41);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w43 = new global::Gtk.Label ();
			w43.LabelProp = global::Mono.Unix.Catalog.GetString ("_Up");
			w43.UseUnderline = true;
			w40.Add (w43);
			w39.Add (w40);
			this.upEffectBtn.Add (w39);
			this.vbuttonbox1.Add (this.upEffectBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w47 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.upEffectBtn]));
			w47.Position = 1;
			w47.Expand = false;
			w47.Fill = false;
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.downEffectBtn = new global::Gtk.Button ();
			this.downEffectBtn.Sensitive = false;
			this.downEffectBtn.CanFocus = true;
			this.downEffectBtn.Name = "downEffectBtn";
			this.downEffectBtn.UseUnderline = true;
			// Container child downEffectBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w48 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w49 = new global::Gtk.HBox ();
			w49.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w50 = new global::Gtk.Image ();
			w50.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-go-down", global::Gtk.IconSize.Menu);
			w49.Add (w50);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w52 = new global::Gtk.Label ();
			w52.LabelProp = global::Mono.Unix.Catalog.GetString ("Do_wn");
			w52.UseUnderline = true;
			w49.Add (w52);
			w48.Add (w49);
			this.downEffectBtn.Add (w48);
			this.vbuttonbox1.Add (this.downEffectBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w56 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.downEffectBtn]));
			w56.Position = 2;
			w56.Expand = false;
			w56.Fill = false;
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.cloneEffectBtn = new global::Gtk.Button ();
			this.cloneEffectBtn.Sensitive = false;
			this.cloneEffectBtn.CanFocus = true;
			this.cloneEffectBtn.Name = "cloneEffectBtn";
			this.cloneEffectBtn.UseUnderline = true;
			// Container child cloneEffectBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w57 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w58 = new global::Gtk.HBox ();
			w58.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w59 = new global::Gtk.Image ();
			w59.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-copy", global::Gtk.IconSize.Menu);
			w58.Add (w59);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w61 = new global::Gtk.Label ();
			w61.LabelProp = global::Mono.Unix.Catalog.GetString ("_Clone");
			w61.UseUnderline = true;
			w58.Add (w61);
			w57.Add (w58);
			this.cloneEffectBtn.Add (w57);
			this.vbuttonbox1.Add (this.cloneEffectBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w65 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.cloneEffectBtn]));
			w65.Position = 3;
			w65.Expand = false;
			w65.Fill = false;
			// Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.deleteEffectBtn = new global::Gtk.Button ();
			this.deleteEffectBtn.Sensitive = false;
			this.deleteEffectBtn.CanFocus = true;
			this.deleteEffectBtn.Name = "deleteEffectBtn";
			this.deleteEffectBtn.UseUnderline = true;
			// Container child deleteEffectBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w66 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w67 = new global::Gtk.HBox ();
			w67.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w68 = new global::Gtk.Image ();
			w68.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			w67.Add (w68);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w70 = new global::Gtk.Label ();
			w70.LabelProp = global::Mono.Unix.Catalog.GetString ("_Delete");
			w70.UseUnderline = true;
			w67.Add (w70);
			w66.Add (w67);
			this.deleteEffectBtn.Add (w66);
			this.vbuttonbox1.Add (this.deleteEffectBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w74 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.deleteEffectBtn]));
			w74.Position = 4;
			w74.Expand = false;
			w74.Fill = false;
			this.hbox3.Add (this.vbuttonbox1);
			global::Gtk.Box.BoxChild w75 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbuttonbox1]));
			w75.Position = 1;
			w75.Expand = false;
			w75.Fill = false;
			this.vbox5.Add (this.hbox3);
			global::Gtk.Box.BoxChild w76 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox3]));
			w76.Position = 1;
			this.notebook1.Add (this.vbox5);
			global::Gtk.Notebook.NotebookChild w77 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox5]));
			w77.Position = 2;
			// Notebook tab
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Effects");
			this.notebook1.SetTabLabel (this.vbox5, this.label5);
			this.label5.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			this.vbox6.BorderWidth = ((uint)(3));
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.saveHistoryChBox = new global::Gtk.CheckButton ();
			this.saveHistoryChBox.CanFocus = true;
			this.saveHistoryChBox.Name = "saveHistoryChBox";
			this.saveHistoryChBox.Label = global::Mono.Unix.Catalog.GetString ("Save history");
			this.saveHistoryChBox.DrawIndicator = true;
			this.saveHistoryChBox.UseUnderline = true;
			this.hbox4.Add (this.saveHistoryChBox);
			global::Gtk.Box.BoxChild w78 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.saveHistoryChBox]));
			w78.Position = 0;
			w78.Expand = false;
			w78.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.selectSaveHostoryFolderBox = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Выберите файл"), ((global::Gtk.FileChooserAction)(2)));
			this.selectSaveHostoryFolderBox.Sensitive = false;
			this.selectSaveHostoryFolderBox.Name = "selectSaveHostoryFolderBox";
			this.selectSaveHostoryFolderBox.ShowHidden = true;
			this.hbox4.Add (this.selectSaveHostoryFolderBox);
			global::Gtk.Box.BoxChild w79 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.selectSaveHostoryFolderBox]));
			w79.Position = 1;
			// Container child hbox4.Gtk.Box+BoxChild
			this.historyLimitSizeChBox = new global::Gtk.CheckButton ();
			this.historyLimitSizeChBox.Sensitive = false;
			this.historyLimitSizeChBox.CanFocus = true;
			this.historyLimitSizeChBox.Name = "historyLimitSizeChBox";
			this.historyLimitSizeChBox.Label = global::Mono.Unix.Catalog.GetString ("Max size");
			this.historyLimitSizeChBox.DrawIndicator = true;
			this.historyLimitSizeChBox.UseUnderline = true;
			this.hbox4.Add (this.historyLimitSizeChBox);
			global::Gtk.Box.BoxChild w80 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.historyLimitSizeChBox]));
			w80.Position = 2;
			w80.Expand = false;
			w80.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.historyMaxSizeSpin = new global::Gtk.SpinButton (0, 100, 1);
			this.historyMaxSizeSpin.Sensitive = false;
			this.historyMaxSizeSpin.CanFocus = true;
			this.historyMaxSizeSpin.Name = "historyMaxSizeSpin";
			this.historyMaxSizeSpin.Adjustment.PageIncrement = 10;
			this.historyMaxSizeSpin.ClimbRate = 1;
			this.historyMaxSizeSpin.Numeric = true;
			this.hbox4.Add (this.historyMaxSizeSpin);
			global::Gtk.Box.BoxChild w81 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.historyMaxSizeSpin]));
			w81.Position = 3;
			w81.Expand = false;
			w81.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Mb");
			this.hbox4.Add (this.label8);
			global::Gtk.Box.BoxChild w82 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label8]));
			w82.Position = 4;
			w82.Expand = false;
			w82.Fill = false;
			this.vbox6.Add (this.hbox4);
			global::Gtk.Box.BoxChild w83 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox4]));
			w83.Position = 0;
			w83.Expand = false;
			w83.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Update interval:");
			this.hbox5.Add (this.label9);
			global::Gtk.Box.BoxChild w84 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label9]));
			w84.Position = 0;
			w84.Expand = false;
			w84.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("1 min");
			this.hbox5.Add (this.label10);
			global::Gtk.Box.BoxChild w85 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label10]));
			w85.Position = 1;
			w85.Expand = false;
			w85.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.hscale2 = new global::Gtk.HScale (null);
			this.hscale2.CanFocus = true;
			this.hscale2.Name = "hscale2";
			this.hscale2.Adjustment.Upper = 100;
			this.hscale2.Adjustment.PageIncrement = 10;
			this.hscale2.Adjustment.StepIncrement = 1;
			this.hscale2.DrawValue = false;
			this.hscale2.Digits = 0;
			this.hscale2.ValuePos = ((global::Gtk.PositionType)(2));
			this.hbox5.Add (this.hscale2);
			global::Gtk.Box.BoxChild w86 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.hscale2]));
			w86.Position = 2;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Update Mode");
			this.hbox5.Add (this.label11);
			global::Gtk.Box.BoxChild w87 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label11]));
			w87.Position = 3;
			w87.Expand = false;
			w87.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.combobox5 = global::Gtk.ComboBox.NewText ();
			this.combobox5.AppendText (global::Mono.Unix.Catalog.GetString ("Updata on start"));
			this.combobox5.AppendText (global::Mono.Unix.Catalog.GetString ("Wait after start"));
			this.combobox5.AppendText (global::Mono.Unix.Catalog.GetString ("Wait from last update"));
			this.combobox5.Name = "combobox5";
			this.combobox5.Active = 1;
			this.hbox5.Add (this.combobox5);
			global::Gtk.Box.BoxChild w88 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.combobox5]));
			w88.Position = 4;
			w88.Expand = false;
			w88.Fill = false;
			this.vbox6.Add (this.hbox5);
			global::Gtk.Box.BoxChild w89 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox5]));
			w89.Position = 1;
			w89.Expand = false;
			w89.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label12 = new global::Gtk.Label ();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("Language");
			this.hbox7.Add (this.label12);
			global::Gtk.Box.BoxChild w90 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label12]));
			w90.Position = 0;
			w90.Expand = false;
			w90.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.combobox6 = global::Gtk.ComboBox.NewText ();
			this.combobox6.Name = "combobox6";
			this.hbox7.Add (this.combobox6);
			global::Gtk.Box.BoxChild w91 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.combobox6]));
			w91.Position = 1;
			w91.Expand = false;
			this.vbox6.Add (this.hbox7);
			global::Gtk.Box.BoxChild w92 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox7]));
			w92.Position = 2;
			w92.Expand = false;
			w92.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.checkbutton3 = new global::Gtk.CheckButton ();
			this.checkbutton3.CanFocus = true;
			this.checkbutton3.Name = "checkbutton3";
			this.checkbutton3.Label = global::Mono.Unix.Catalog.GetString ("Autorun");
			this.checkbutton3.DrawIndicator = true;
			this.checkbutton3.UseUnderline = true;
			this.vbox6.Add (this.checkbutton3);
			global::Gtk.Box.BoxChild w93 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.checkbutton3]));
			w93.Position = 3;
			w93.Expand = false;
			w93.Fill = false;
			this.notebook1.Add (this.vbox6);
			global::Gtk.Notebook.NotebookChild w94 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox6]));
			w94.Position = 3;
			// Notebook tab
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Program");
			this.notebook1.SetTabLabel (this.vbox6, this.label7);
			this.label7.ShowAll ();
			this.vbox2.Add (this.notebook1);
			global::Gtk.Box.BoxChild w95 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.notebook1]));
			w95.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.vbox2.Add (this.hseparator2);
			global::Gtk.Box.BoxChild w96 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hseparator2]));
			w96.Position = 1;
			w96.Expand = false;
			w96.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment6 = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.GtkAlignment6.Name = "GtkAlignment6";
			this.GtkAlignment6.LeftPadding = ((uint)(12));
			// Container child GtkAlignment6.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.combobox4 = global::Gtk.ComboBox.NewText ();
			this.combobox4.Name = "combobox4";
			this.hbox1.Add (this.combobox4);
			global::Gtk.Box.BoxChild w97 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.combobox4]));
			w97.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.hbuttonbox2 = new global::Gtk.HButtonBox ();
			this.hbuttonbox2.Name = "hbuttonbox2";
			this.hbuttonbox2.Spacing = 4;
			this.hbuttonbox2.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.applyProfileBtn = new global::Gtk.Button ();
			this.applyProfileBtn.Sensitive = false;
			this.applyProfileBtn.CanFocus = true;
			this.applyProfileBtn.Name = "applyProfileBtn";
			this.applyProfileBtn.UseUnderline = true;
			// Container child applyProfileBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w98 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w99 = new global::Gtk.HBox ();
			w99.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w100 = new global::Gtk.Image ();
			w100.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			w99.Add (w100);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w102 = new global::Gtk.Label ();
			w102.LabelProp = global::Mono.Unix.Catalog.GetString ("_Apply");
			w102.UseUnderline = true;
			w99.Add (w102);
			w98.Add (w99);
			this.applyProfileBtn.Add (w98);
			this.hbuttonbox2.Add (this.applyProfileBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w106 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.applyProfileBtn]));
			w106.Expand = false;
			w106.Fill = false;
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.saveProfileBtn = new global::Gtk.Button ();
			this.saveProfileBtn.CanFocus = true;
			this.saveProfileBtn.Name = "saveProfileBtn";
			this.saveProfileBtn.UseUnderline = true;
			// Container child saveProfileBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w107 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w108 = new global::Gtk.HBox ();
			w108.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w109 = new global::Gtk.Image ();
			w109.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			w108.Add (w109);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w111 = new global::Gtk.Label ();
			w111.LabelProp = global::Mono.Unix.Catalog.GetString ("_Save");
			w111.UseUnderline = true;
			w108.Add (w111);
			w107.Add (w108);
			this.saveProfileBtn.Add (w107);
			this.hbuttonbox2.Add (this.saveProfileBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w115 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.saveProfileBtn]));
			w115.Position = 1;
			w115.Expand = false;
			w115.Fill = false;
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.deleteProfileBtn = new global::Gtk.Button ();
			this.deleteProfileBtn.Sensitive = false;
			this.deleteProfileBtn.CanFocus = true;
			this.deleteProfileBtn.Name = "deleteProfileBtn";
			this.deleteProfileBtn.UseUnderline = true;
			// Container child deleteProfileBtn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w116 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w117 = new global::Gtk.HBox ();
			w117.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w118 = new global::Gtk.Image ();
			w118.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			w117.Add (w118);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w120 = new global::Gtk.Label ();
			w120.LabelProp = global::Mono.Unix.Catalog.GetString ("_Delete");
			w120.UseUnderline = true;
			w117.Add (w120);
			w116.Add (w117);
			this.deleteProfileBtn.Add (w116);
			this.hbuttonbox2.Add (this.deleteProfileBtn);
			global::Gtk.ButtonBox.ButtonBoxChild w124 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.deleteProfileBtn]));
			w124.Position = 2;
			w124.Expand = false;
			w124.Fill = false;
			this.hbox1.Add (this.hbuttonbox2);
			global::Gtk.Box.BoxChild w125 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.hbuttonbox2]));
			w125.Position = 1;
			w125.Expand = false;
			w125.Fill = false;
			this.GtkAlignment6.Add (this.hbox1);
			this.frame1.Add (this.GtkAlignment6);
			this.GtkLabel13 = new global::Gtk.Label ();
			this.GtkLabel13.Name = "GtkLabel13";
			this.GtkLabel13.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Profiles</b>");
			this.GtkLabel13.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel13;
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w128 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
			w128.Position = 2;
			w128.Expand = false;
			w128.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w129 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
			w129.Position = 0;
			// Internal child DeMixer.ConfigDlg.ActionArea
			global::Gtk.HButtonBox w130 = this.ActionArea;
			w130.Name = "dialog1_ActionArea";
			w130.Spacing = 6;
			w130.BorderWidth = ((uint)(5));
			w130.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseUnderline = true;
			// Container child buttonOk.Gtk.Container+ContainerChild
			global::Gtk.Alignment w131 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w132 = new global::Gtk.HBox ();
			w132.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w133 = new global::Gtk.Image ();
			w133.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-close", global::Gtk.IconSize.Menu);
			w132.Add (w133);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w135 = new global::Gtk.Label ();
			w135.LabelProp = global::Mono.Unix.Catalog.GetString ("_Close");
			w135.UseUnderline = true;
			w132.Add (w135);
			w131.Add (w132);
			this.buttonOk.Add (w131);
			this.AddActionWidget (this.buttonOk, -7);
			global::Gtk.ButtonBox.ButtonBoxChild w139 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w130[this.buttonOk]));
			w139.Expand = false;
			w139.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 506;
			this.DefaultHeight = 401;
			this.Show ();
			this.SourceComboBox.Changed += new global::System.EventHandler (this.OnSourceComboBoxChanged);
			this.CompositionComboBox.Changed += new global::System.EventHandler (this.OnCompositionComboBoxChanged);
			this.EffectsComboBox.Changed += new global::System.EventHandler (this.OnEffectsComboBoxChanged);
			this.EffectsList.CursorChanged += new global::System.EventHandler (this.OnEffectsListCursorChanged);
			this.saveHistoryChBox.Clicked += new global::System.EventHandler (this.OnSaveHistoryChBoxClicked);
			this.historyLimitSizeChBox.Clicked += new global::System.EventHandler (this.OnHistoryLimitSizeChBoxClicked);
			this.saveProfileBtn.Clicked += new global::System.EventHandler (this.OnsaveProfileBtnClicked);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
