
using System;
using System.Net;

namespace DeMixer.lib {
	
	public class DeMixerException : Exception {
		public DeMixerException(string message) : base(message) {
		}
	}
	
	public enum UpdateMode {
		UpdateOnStart,
		WaitFromStart,
		WaitFromLastUpdate
	}
	
	public interface IDeMixerKernel {
		ImagesSource[] SourceList {
			get;
		}
		
		ImagesComposition[] CompositionList {
			get;
		}
		
		ImagePostEffect[] PostEffectsList {
			get;
		}
		
		ImagePostEffect[] ActiveEffects {
			get;
			set;
		}
		
		int ActiveSourceIndex {
			get; set;
		}
		
		int ActiveCompositionIndex {
			get; set;
		}
		
		ImagesSource ActiveSource {
			get;
		}
		
		ImagesComposition ActiveComposition {
			get;
		}
		
		string AppDir {
			get;	
		}
		
		string GetAppFileName(params string[] args);
		
		string UserDir {
			get;	
		}		
				
		string[] GetProfileList();		
		bool LoadConfig(string configName);
		bool SaveConfig(string configName);
		
		string GetUserFileName(params string[] args);
		int GetSourceIndex(string name);
		int GetCompositionIndex(string name);
		
		bool SaveHistory { get; set; }
		string SaveHistoryPath { get; set; }
		int SaveHistorySize { get; set; }
		
		void UpdateEffectForLastWallpaper();
		
		int UpdateInterval {
			get; set;
		}
		
		UpdateMode UpdateIntervalMode {
			get; set;
		}
		
		TimeSpan TimeLeft {
			get;
		}
		
		string Translate(string format, params object[] args);
		void TranslateWidget(Gtk.Widget w);
		
		void ShowNotify(string title, string message, bool errorIcon);
		
		WebClient GetWebClient();
	}
}
