
using System;
using Microsoft.Win32;

namespace DeMixer.lib {
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
		
		RegistryKey UserRegistry {
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
		
		int UpdateIntervalMode {
			get; set;
		}
		
		TimeSpan TimeLeft {
			get;
		}
		
		string Translate(string format, params object[] args);
	}
}
