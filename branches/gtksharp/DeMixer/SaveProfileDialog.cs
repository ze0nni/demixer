using System;

namespace DeMixer {
	public partial class SaveProfileDialog : Gtk.Dialog {
		
		public SaveProfileDialog(string title, Gtk.Window parent) : base(title,
		                                  parent,
		                                  Gtk.DialogFlags.Modal) {
			this.Build();
		}
		
		public string ProfileName {
			get { return ProfileNameEdit.Text; }
		}
		
		public bool SaveSource {
			get { return SaveSourceCb.Active; }
		}
		
		public bool SaveCompostion {
			get { return SaveCompositionCb.Active; }
		}
		
		public bool SaveEffects {
			get { return SaveEffectsCb.Active; }
		}
	}
}
