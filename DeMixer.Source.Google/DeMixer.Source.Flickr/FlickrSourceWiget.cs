using System;
using DeMixer.lib;

namespace DeMixer.Source.Flickr {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class FlickrSourceWiget : Gtk.Bin {
		
		IDeMixerKernel Kernel;
		FlickrSource Source;
		public FlickrSourceWiget(FlickrSource s, IDeMixerKernel k) {
			this.Build();
			Kernel = k;
			Source = s;
		}

		protected void OnSelectGUClicked(object sender, System.EventArgs e) {
			Gtk.Widget w = this;
			do {
				w = w.Parent;
			} while (w.Parent != null);
			
			FlickrSelectGUDialog dlg = new FlickrSelectGUDialog(				
				Kernel,
				"", //todo: translate
				(Gtk.Window)w,				
				byGroupCb.Active ?	
					FlickrSelectGUDialog.SearchMode.Group :
					FlickrSelectGUDialog.SearchMode.User
				);
			try {	
				if ((Gtk.ResponseType)dlg.Run() == Gtk.ResponseType.Ok) {
					this.Source.GroupId = dlg.ActiveGroupID;
				}
			} finally {
				dlg.Destroy();	
			}
		}

		protected void OnByNoneCbToggled(object sender, System.EventArgs e) {
						SelectGU.Sensitive = !byNoneCb.Active;
			if (byNoneCb.Active) {
				SelectGU.Label = "None";	
			} else if (byGroupCb.Active) {
				SelectGU.Label = "Select group";
			} else if (byUserCb.Active) {
				SelectGU.Label = "Select User";
			}
		}
	}
}

