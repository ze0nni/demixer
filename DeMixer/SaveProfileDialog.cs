
using System;

namespace DeMixer
{
	
	
	public partial class SaveProfileDialog : Gtk.Dialog
	{
		
		public SaveProfileDialog(string title, Gtk.Window parent) : base(title,
		                                  parent,
		                                  Gtk.DialogFlags.Modal)
		{
			this.Build();
		}
	}
}
