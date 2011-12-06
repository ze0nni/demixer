using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Collections.Generic;
using Gdk;

//Flickr api public key: 16cc9f828de720615e9b103bc3369411

namespace DeMixer.Source.Flickr {
	public class FlickrSource : ImagesSource {
		
		static string FlickrApiPublicKey {
			get { return "16cc9f828de720615e9b103bc3369411"; }
		}
		
		public FlickrSource () : base() {		
		}
		
		public override string Url {
			get { return "http://Flickr.com"; }	
		}
		
		public override System.Drawing.Image GetNextImage () {
			throw new NotImplementedException ();
		}
		
		public override System.Drawing.Image GetImageFromSource (string source) {
			throw new NotImplementedException ();
		}
				
		public override bool SaveTempImages {
			get { return true; }	
		}
		
		public override Gtk.Widget ExpandTagsControl {
			get {				
				return new FlickrSourceWiget();
				//return new Gtk.Button("Hello");
			}
		}
	}
}

