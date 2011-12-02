using System;

namespace DeMixer.lib.std {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CompositionSeasonsConfigView : Gtk.Bin {
		CompositionSeasons Compositon;

		public CompositionSeasonsConfigView(CompositionSeasons compositon, IDeMixerKernel kernel) {
			this.Build();			
			Compositon = compositon;
			hscaleCount.Value = Compositon.ImagesCount;
			hscaleSize.Value = Compositon.SeparatorSize;
			colorbStart.Color = new Gdk.Color(
				Compositon.SeparatorColor1.R,
				Compositon.SeparatorColor1.G,
				Compositon.SeparatorColor1.B);
			colorbEnd.Color = new Gdk.Color(
				Compositon.SeparatorColor2.R,
				Compositon.SeparatorColor2.G,
				Compositon.SeparatorColor2.B);
		}

		protected void OnHscaleCountChangeValue (object o, Gtk.ChangeValueArgs args) {			
			Compositon.ImagesCount = (int)hscaleCount.Value;
			Compositon.doUpdatePreview();
		}

		protected void OnHscaleSizeChangeValue (object o, Gtk.ChangeValueArgs args) {
			Compositon.SeparatorSize = (int)hscaleSize.Value;
			Compositon.doUpdatePreview();
		}
		
		private System.Drawing.Color tocolor(uint r, uint g, uint b) {
			float cmod = 256f/65536f;						
			return System.Drawing.Color.FromArgb(
				255,
				(byte)(Math.Round(Math.Min(255f, r*cmod))),
				(byte)(Math.Round(Math.Min(255f, g*cmod))),
				(byte)(Math.Round(Math.Min(255f, b*cmod))));	
		}
		
		protected void OnColorbStartColorSet (object sender, System.EventArgs e) {
			Compositon.SeparatorColor1 = tocolor(
				colorbStart.Color.Red,
				colorbStart.Color.Green,
				colorbStart.Color.Blue);
			Compositon.doUpdatePreview();
		}

		protected void OnColorbEndColorSet (object sender, System.EventArgs e) {
			Compositon.SeparatorColor2 = tocolor(
				colorbEnd.Color.Red,
				colorbEnd.Color.Green,
				colorbEnd.Color.Blue);
			Compositon.doUpdatePreview();
		}
	}
}

