using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using Google.API.Search;
using System.Collections.Generic;
using Gdk;

namespace DeMixer.lib.std {
	public class FlickrSource : ImagesSource {
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
	}
}

