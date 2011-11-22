using System;

namespace DeMixer.lib.std {
	public partial class EffectShadowDialog : Gtk.Dialog {
		EffectShadow Effect;
		public EffectShadowDialog(EffectShadow effect, Gtk.Window parent)
			: base("Shadow effect dialog",
				parent,
				Gtk.DialogFlags.Modal, new object[0])				
								
		{
			this.Build();
			Effect = effect;
			
			checkbAbove.Active = Effect.DrawTop;
			checkbBelow.Active = Effect.DrawBottom;
			checkbLeft.Active = Effect.DrawLeft;
			checkbRight.Active = Effect.DrawRight;
			hscaleSize.SetRange(0f, Math.Max(Gdk.Display.Default.DefaultScreen.Width,
				Gdk.Display.Default.DefaultScreen.Height));
			hscaleSize.Value = Effect.DrawBorderSize;			
			colorbuttonStart.Color = new Gdk.Color(
				Effect.ColorStart.R,
				Effect.ColorStart.G,
				Effect.ColorStart.B);
			colorbuttonEnd.Color = new Gdk.Color(
				Effect.ColorEnd.R,
				Effect.ColorEnd.G,
				Effect.ColorEnd.B);
			hscaleTransparentStart.Value = (Effect.ColorStartAlpha / 255f) * 100f;
			hscaleTransparentEnd.Value = (Effect.ColorEndAlpha / 255f) * 100f;
			checkbSyncColor.Active =
				colorbuttonStart.Color.Red == colorbuttonEnd.Color.Red &&
				colorbuttonStart.Color.Green == colorbuttonEnd.Color.Green &&
				colorbuttonStart.Color.Blue == colorbuttonEnd.Color.Blue;
		}

		protected void OnColorbuttonStartColorSet(object sender, System.EventArgs e) {
			if (checkbSyncColor.Active) {
				colorbuttonEnd.Color = colorbuttonStart.Color;
				checkbSyncColor.Active = true;
			}
		}

		protected void OnColorbuttonEndColorSet(object sender, System.EventArgs e) {
			checkbSyncColor.Active = false;
		}

		protected void OnCheckbSyncColorToggled(object sender, System.EventArgs e) {
			if (checkbSyncColor.Active) {
				colorbuttonEnd.Color = colorbuttonStart.Color;
			}
		}
		
		private System.Drawing.Color tocolor(uint r, uint g, uint b) {
			float cmod = 256f/65536f;						
			return System.Drawing.Color.FromArgb(
				255,
				(byte)(Math.Round(Math.Min(255f, r*cmod))),
				(byte)(Math.Round(Math.Min(255f, g*cmod))),
				(byte)(Math.Round(Math.Min(255f, b*cmod))));	
		}
		
		protected void OnButtonOkClicked(object sender, System.EventArgs e) {
			Effect.DrawTop = checkbAbove.Active;
			Effect.DrawBottom = checkbBelow.Active;
			Effect.DrawLeft = checkbLeft.Active;
			Effect.DrawRight = checkbRight.Active;
			Effect.DrawBorderSize = (int)(hscaleSize.Value);								
			Effect.ColorStart = tocolor(
				colorbuttonStart.Color.Red,
				colorbuttonStart.Color.Green,
				colorbuttonStart.Color.Blue);				
			Effect.ColorEnd = tocolor(
				colorbuttonEnd.Color.Red,
				colorbuttonEnd.Color.Green,
				colorbuttonEnd.Color.Blue);				
			Effect.ColorStartAlpha = (byte)((hscaleTransparentStart.Value/100f)*255f);
			Effect.ColorEndAlpha = (byte)((hscaleTransparentEnd.Value/100f)*255f);
		}
	}
}

