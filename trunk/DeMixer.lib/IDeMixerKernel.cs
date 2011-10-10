
using System;
using Microsoft.Win32;

namespace DeMixer.lib {
	public interface IDeMixerKernel {
		//// <value>
		///Возвращает список доступных источников 
		/// </value>
		ImagesSource[] SourceList {
			get;
		}
		
		//// <value>
		/// Возвращает список доступных композиций 
		/// </value>
		ImagesComposition[] CompositionList {
			get;
		}
		
		
		//// <value>
		/// Возвращает список доступных эффектов 
		/// </value>
		ImagePostEffect[] PostEffectsList {
			get;
		}
		
		
		//// <value>
		/// Список активных эффектов 
		/// </value>
		ImagePostEffect[] ActiveEffects {
			get;
			set;
		}
		
		//// <value>
		/// Индекс активного источника 
		/// </value>
		int ActiveSourceIndex {
			get; set;
		}
		
		//// <value>
		/// Индекс активной композиции 
		/// </value>
		int ActiveCompositionIndex {
			get; set;
		}
		
		//// <value>
		/// Активный источник 
		/// </value>
		ImagesSource ActiveSource {
			get;
		}
		
		//// <value>
		/// Активная композиция 
		/// </value>
		ImagesComposition ActiveComposition {
			get;
		}
		
		//// <value>
		/// Папка в которой лежит исполняемый файл 
		/// </value>
		string AppDir {
			get;	
		}
		
		/// <summary>
		/// Возвращает путь внутри папки с приложением 
		/// </summary>
		/// <param name="args">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		string GetAppFileName(params string[] args);
		
		string UserDir {
			get;	
		}		
		
		//// <value>
		/// Рееестр пользователя 
		/// </value>
		RegistryKey UserRegistry {
			get;
		}
				
		/// <summary>
		/// Список профилей из папки пользователя 
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		string[] GetProfileList();
		/// <summary>
		/// Загрузить текущий конфиг 
		/// </summary>
		/// <param name="configName">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		bool LoadConfig(string configName);
		/// <summary>
		/// Сохранить текущий конфиг 
		/// </summary>
		/// <param name="configName">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		bool SaveConfig(string configName);
		
		/// <summary>
		/// Возвращает путь к файлу внутри пользовательской папки приложения 
		/// </summary>
		/// <param name="args">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
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
