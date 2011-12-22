using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Collections.Generic;
using Gdk;
using FlickrNet;
using System.Xml;

//Flickr api public key: 16cc9f828de720615e9b103bc3369411

namespace DeMixer.Source.Flickr {
	public class FlickrSource : ImagesSource {
					
		public enum SearchMode {
			None,
			Group,
			User			
		}
		
		public static string FlickrApiPublicKey {
			get { return "16cc9f828de720615e9b103bc3369411"; }
		}
				
		public FlickrSource () : base() {
		}
		
		public override string Url {
			get { return "http://Flickr.com"; }	
		}
		
		Random rnd = new Random();
		
		public override System.Drawing.Image GetNextImage () {			
			FlickrNet.Flickr f = new FlickrNet.Flickr(FlickrSource.FlickrApiPublicKey);
			PhotoSearchOptions opt = new PhotoSearchOptions();
			if (SearchQuery!=null && SearchQuery.Length>0) {
				if (ByTags)
					opt.Tags = SearchQuery;
				else
					opt.Text = SearchQuery;
			}				
			if (SearchByMode == FlickrSource.SearchMode.Group && GroupId.Length>0)
				opt.GroupId = GroupId;									
			opt.Extras |= PhotoSearchExtras.OriginalUrl;
			opt.Extras |= PhotoSearchExtras.LargeUrl;			
			PhotoCollection res = f.PhotosSearch(opt);

			if (res.Count != 0) {
				WebClient wc = Kernel.GetWebClient();
				int n = rnd.Next(res.Count);
				Photo p = res[n];				
				
				string url = p.LargeUrl;
				if (p.OriginalUrl != null && p.OriginalUrl.Length > 0)
					url = p.OriginalUrl;
				
				MemoryStream ms = new MemoryStream(wc.DownloadData(url));
				return new Bitmap(ms);			
			} else {
				throw new DeMixerException(Kernel.Translate("No valid images for this tag"));
			}
		}
		
		public override System.Drawing.Image GetImageFromSource (string source) {
			throw new NotImplementedException ();
		}
				
		public override bool SaveTempImages {
			get { return true; }	
		}
		
		public override Gtk.Widget ExpandTagsControl {
			get {				
				return new FlickrSourceWiget(this, Kernel);
				//return new Gtk.Button("Hello");
			}
		}
		
		protected override void Write(System.Xml.XmlWriter cfg) {
			cfg.WriteElementString("query", SearchQuery);
			cfg.WriteElementString("bytags", ByTags.ToString());
			cfg.WriteElementString("mode", SearchByMode.ToString());
			cfg.WriteElementString("groupid", GroupId);		
			cfg.WriteElementString("grouptitle", GroupTitle);
		}
				
		protected override void Read(System.Xml.XmlNode r) {
			SearchQuery = r.SelectSingleNode("query").InnerXml;			
			ByTags = Boolean.Parse(
				r.SelectSingleNode("bytags").InnerXml);
			SearchByMode = (SearchMode)
				Enum.Parse(typeof(SearchMode),
				r.SelectSingleNode("mode").InnerXml);
			groupId = r.SelectSingleNode("groupid").InnerXml;
			groupTitle = r.SelectSingleNode("grouptitle").InnerXml;
		}
		
		string searchQuery = "";
		public string SearchQuery {
			get { return searchQuery; }
			set { searchQuery = value; }
		}
		
		bool byTags = false;
		public bool ByTags {
			get { return byTags; }
			set { byTags = value; }
		}
		
			
		string groupId = "";
		public string GroupId {
			get { return groupId; }
			set { groupId = value; }
		}
		
		string groupTitle = "";
		public string GroupTitle {
			get { return groupTitle; }
			set { groupTitle = value; }
		}
		
		SearchMode searchByMode = SearchMode.None;
		public SearchMode SearchByMode {
			get { return searchByMode; }
			set { searchByMode = value; }
		}
	}
}

