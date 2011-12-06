using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Collections.Generic;
using Gdk;
using FlickrNet;

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
		
		Random rnd = new Random();
		
		public override System.Drawing.Image GetNextImage () {			
			FlickrNet.Flickr f = new FlickrNet.Flickr(FlickrApiPublicKey);
			PhotoSearchOptions opt = new PhotoSearchOptions();
			//opt.GroupId = "43982356@N00";
			opt.GroupId = "421232@N24";
			PhotoCollection res = f.PhotosSearch(opt);			
			
			WebClient wc = Kernel.GetWebClient();
			MemoryStream ms = new MemoryStream(wc.DownloadData(res[rnd.Next(res.Count)].LargeUrl));			
			
			return new Bitmap(ms);
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

