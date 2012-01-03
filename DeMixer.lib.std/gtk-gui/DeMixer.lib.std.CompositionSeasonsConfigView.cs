
// This file has been generated by the GUI designer. Do not modify.
namespace DeMixer.lib.std
{
	public partial class CompositionSeasonsConfigView
	{
		private global::Gtk.VBox vbox3;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label3;

		private global::Gtk.HScale hscaleCount;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label4;

		private global::Gtk.HScale hscaleSize;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label5;

		private global::Gtk.ComboBox lineStyle;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment;

		private global::Gtk.Table table1;

		private global::Gtk.CheckButton checkbSyncColor;

		private global::Gtk.ColorButton colorbEnd;

		private global::Gtk.ColorButton colorbStart;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label GtkLabel1;

		private global::Gtk.Expander expander1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label6;

		private global::Gtk.HScale rotateAngle;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label7;

		private global::Gtk.HScale rotateOffset;

		private global::Gtk.Label GtkLabel2;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DeMixer.lib.std.CompositionSeasonsConfigView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "DeMixer.lib.std.CompositionSeasonsConfigView";
			// Container child DeMixer.lib.std.CompositionSeasonsConfigView.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Images count");
			this.hbox3.Add (this.label3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.hscaleCount = new global::Gtk.HScale (null);
			this.hscaleCount.CanFocus = true;
			this.hscaleCount.Name = "hscaleCount";
			this.hscaleCount.Adjustment.Lower = 2;
			this.hscaleCount.Adjustment.Upper = 7;
			this.hscaleCount.Adjustment.PageIncrement = 10;
			this.hscaleCount.Adjustment.StepIncrement = 1;
			this.hscaleCount.Adjustment.Value = 2;
			this.hscaleCount.DrawValue = true;
			this.hscaleCount.Digits = 0;
			this.hscaleCount.ValuePos = ((global::Gtk.PositionType)(2));
			this.hbox3.Add (this.hscaleCount);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.hscaleCount]));
			w2.Position = 1;
			this.vbox3.Add (this.hbox3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Separator size");
			this.hbox4.Add (this.label4);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label4]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.hscaleSize = new global::Gtk.HScale (null);
			this.hscaleSize.CanFocus = true;
			this.hscaleSize.Name = "hscaleSize";
			this.hscaleSize.Adjustment.Upper = 64;
			this.hscaleSize.Adjustment.PageIncrement = 10;
			this.hscaleSize.Adjustment.StepIncrement = 1;
			this.hscaleSize.DrawValue = true;
			this.hscaleSize.Digits = 0;
			this.hscaleSize.ValuePos = ((global::Gtk.PositionType)(2));
			this.hbox4.Add (this.hscaleSize);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.hscaleSize]));
			w5.Position = 1;
			this.vbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox4]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Separator type");
			this.hbox5.Add (this.label5);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label5]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.lineStyle = global::Gtk.ComboBox.NewText ();
			this.lineStyle.Name = "lineStyle";
			this.hbox5.Add (this.lineStyle);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.lineStyle]));
			w8.Position = 1;
			this.vbox3.Add (this.hbox5);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox5]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkbSyncColor = new global::Gtk.CheckButton ();
			this.checkbSyncColor.Sensitive = false;
			this.checkbSyncColor.CanFocus = true;
			this.checkbSyncColor.Name = "checkbSyncColor";
			this.checkbSyncColor.Label = global::Mono.Unix.Catalog.GetString ("Sycn colors");
			this.checkbSyncColor.DrawIndicator = true;
			this.checkbSyncColor.UseUnderline = true;
			this.table1.Add (this.checkbSyncColor);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.checkbSyncColor]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.colorbEnd = new global::Gtk.ColorButton ();
			this.colorbEnd.CanFocus = true;
			this.colorbEnd.Events = ((global::Gdk.EventMask)(784));
			this.colorbEnd.Name = "colorbEnd";
			this.table1.Add (this.colorbEnd);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.colorbEnd]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.colorbStart = new global::Gtk.ColorButton ();
			this.colorbStart.CanFocus = true;
			this.colorbStart.Events = ((global::Gdk.EventMask)(784));
			this.colorbStart.Name = "colorbStart";
			this.table1.Add (this.colorbStart);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.colorbStart]));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Start");
			this.table1.Add (this.label1);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("End");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.GtkAlignment.Add (this.table1);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel1 = new global::Gtk.Label ();
			this.GtkLabel1.Name = "GtkLabel1";
			this.GtkLabel1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Gradient</b>");
			this.GtkLabel1.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel1;
			this.vbox3.Add (this.frame1);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.frame1]));
			w17.Position = 3;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.expander1 = new global::Gtk.Expander (null);
			this.expander1.CanFocus = true;
			this.expander1.Name = "expander1";
			this.expander1.Expanded = true;
			// Container child expander1.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Angle");
			this.hbox1.Add (this.label6);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label6]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.rotateAngle = new global::Gtk.HScale (null);
			this.rotateAngle.CanFocus = true;
			this.rotateAngle.Name = "rotateAngle";
			this.rotateAngle.Adjustment.Lower = -15;
			this.rotateAngle.Adjustment.Upper = 15;
			this.rotateAngle.Adjustment.PageIncrement = 10;
			this.rotateAngle.Adjustment.StepIncrement = 1;
			this.rotateAngle.DrawValue = true;
			this.rotateAngle.Digits = 0;
			this.rotateAngle.ValuePos = ((global::Gtk.PositionType)(2));
			this.hbox1.Add (this.rotateAngle);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.rotateAngle]));
			w19.Position = 1;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Offset");
			this.hbox2.Add (this.label7);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label7]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.rotateOffset = new global::Gtk.HScale (null);
			this.rotateOffset.CanFocus = true;
			this.rotateOffset.Name = "rotateOffset";
			this.rotateOffset.Adjustment.Upper = 50;
			this.rotateOffset.Adjustment.PageIncrement = 10;
			this.rotateOffset.Adjustment.StepIncrement = 1;
			this.rotateOffset.DrawValue = true;
			this.rotateOffset.Digits = 0;
			this.rotateOffset.ValuePos = ((global::Gtk.PositionType)(2));
			this.hbox2.Add (this.rotateOffset);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.rotateOffset]));
			w22.Position = 1;
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			this.expander1.Add (this.vbox1);
			this.GtkLabel2 = new global::Gtk.Label ();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("Rotate");
			this.GtkLabel2.UseUnderline = true;
			this.expander1.LabelWidget = this.GtkLabel2;
			this.vbox3.Add (this.expander1);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.expander1]));
			w25.Position = 4;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.hscaleCount.ChangeValue += new global::Gtk.ChangeValueHandler (this.OnHscaleCountChangeValue);
			this.hscaleSize.ChangeValue += new global::Gtk.ChangeValueHandler (this.OnHscaleSizeChangeValue);
			this.lineStyle.Changed += new global::System.EventHandler (this.OnLineStyleChanged);
			this.colorbStart.ColorSet += new global::System.EventHandler (this.OnColorbStartColorSet);
			this.colorbEnd.ColorSet += new global::System.EventHandler (this.OnColorbEndColorSet);
			this.rotateAngle.ChangeValue += new global::Gtk.ChangeValueHandler (this.OnRotateAngleChangeValue);
			this.rotateOffset.ChangeValue += new global::Gtk.ChangeValueHandler (this.OnRotateOffsetChangeValue);
		}
	}
}
