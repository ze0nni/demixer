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
			queryEd.Text = s.SearchQuery;
			if (s.ByTags)
				byTagsCb.Active = true;
			else
				byTextCb.Active = true;			
			switch (Source.SearchByMode) {
				
			case FlickrSource.SearchMode.None:
				byNoneCb.Active = true;
				break;
			case FlickrSource.SearchMode.Group:
				byGroupCb.Active = true;
				break;
			}
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
					FlickrSource.SearchMode.Group :
					FlickrSource.SearchMode.User
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
				Source.SearchByMode = FlickrSource.SearchMode.None;
			} else if (byGroupCb.Active) {
				SelectGU.Label = "Select group";
				Source.SearchByMode = FlickrSource.SearchMode.Group;
			} else if (byUserCb.Active) {
				SelectGU.Label = "Select User";
				Source.SearchByMode = FlickrSource.SearchMode.User;
			}
		}

		protected void OnQueryEdChanged(object sender, System.EventArgs e) {
			Source.SearchQuery = queryEd.Text;			
		}

		protected void OnByTextCbToggled(object sender, System.EventArgs e) {
			Source.ByTags = byTagsCb.Active;
		}
	}
}

