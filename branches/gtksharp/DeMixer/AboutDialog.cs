
using System;

namespace DeMixer
{
	
	
	public partial class AboutDialog : Gtk.Dialog
	{
		
		public AboutDialog()
		{
			this.Build();
			//logoImage.Pixbuf = new Gdk.Pixbuf("/usr/share/demixer/logo");
			logoImage.IconName = "gtk-about";
		}
	}
}
