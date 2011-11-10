
using System;
using DeMixer.lib;
using Gdk;

namespace DeMixer
{
	
	
	public partial class ConfigDlg : Gtk.Dialog
	{

		protected virtual void OnsaveProfileBtnClicked (object sender, System.EventArgs e) {
			SaveProfileDialog dlg = new SaveProfileDialog();
			dlg.Modal = true;
			dlg.ShowAll();
		}	
		
		IDeMixerKernel Kernel;
		public ConfigDlg(IDeMixerKernel k) {			
			this.Build();
			Kernel = k;
			init();			
		}
		
		//Список активных эффектов
		Gtk.ListStore EffectsListStore = null;
		
		void init() {									
			foreach (ImagesSource s in Kernel.SourceList) {
				SourceComboBox.AppendText(s.PluginTitle);
			}			
			SourceComboBox.Active = Kernel.ActiveSourceIndex;
			SourceComboBox.ShowAll();
			
			foreach (ImagesComposition c in Kernel.CompositionList) {
				CompositionComboBox.AppendText(c.PluginTitle);	
			}
			CompositionComboBox.Active = Kernel.ActiveCompositionIndex;
			CompositionComboBox.ShowAll();
			foreach (ImagePostEffect e in Kernel.PostEffectsList) {
				EffectsComboBox.AppendText(e.PluginTitle);	
			}
			EffectsComboBox.ShowAll();
			
			//Создание столбцов в списке эффектов
			Gtk.TreeViewColumn effectNameColumn = new Gtk.TreeViewColumn ();
			effectNameColumn.Title = "type";			
			Gtk.CellRendererText effectNameCell = new Gtk.CellRendererText();
			effectNameColumn.PackStart(effectNameCell, true);
			effectNameColumn.AddAttribute(effectNameCell, "text", 0);
			
			Gtk.TreeViewColumn effectStateColumn = new Gtk.TreeViewColumn ();
			effectStateColumn.Title = "state";
			Gtk.CellRendererText effectStateCell = new Gtk.CellRendererText();
			effectStateColumn.PackStart(effectStateCell, true);
			effectStateColumn.AddAttribute(effectStateCell, "text", 1);
			
			EffectsList.AppendColumn(effectNameColumn);
			EffectsList.AppendColumn (effectStateColumn);
			Gtk.CellRendererText FoldersListCell = new Gtk.CellRendererText();
			
			EffectsListStore = new Gtk.ListStore (typeof (string), typeof (string));			
			EffectsList.Model = EffectsListStore;
			
			//добавляем эффекты в список
			foreach (ImagePostEffect e in Kernel.ActiveEffects) {
				EffectsListStore.AppendValues(new object[]{e.PluginName, e.ToString()});	
			}
		}

		Gtk.Widget lastView = null;
		protected virtual void OnSourceComboBoxChanged (object sender, System.EventArgs e) {
			Kernel.ActiveSourceIndex = SourceComboBox.Active;
			SourceInformationLabel.Markup = Kernel.ActiveSource.PluginDescription;
			Gtk.Widget view = Kernel.ActiveSource.ExpandTagsControl;
			
			if (lastView != null) {
				SourceVBox.Remove(lastView);	
			}
			
			if (view==null) {
				view = new Gtk.Label(Kernel.Translate("no options"));	
			}
				
			lastView = view;
			SourceVBox.Add(view);
			view.ShowAll();			
		}

		protected virtual void OnCompositionComboBoxChanged (object sender, System.EventArgs e) {
			Kernel.ActiveCompositionIndex = CompositionComboBox.Active;
			CompositionInformationLabel.Markup = Kernel.ActiveComposition.PluginDescription;
		}

		protected virtual void OnEffectsComboBoxChanged (object sender, System.EventArgs e) {
			EffectInformationLabel.Markup = 
				Kernel.PostEffectsList[EffectsComboBox.Active].PluginDescription;
		}

		protected virtual void OnEffectsListCursorChanged (object sender, System.EventArgs e) {
			editEffectBtn.Sensitive = EffectsList.Selection != null;
		}

		protected virtual void OnSaveHistoryChBoxClicked (object sender, System.EventArgs e) {
			selectSaveHostoryFolderBox.Sensitive = saveHistoryChBox.Active;
			historyLimitSizeChBox.Sensitive = saveHistoryChBox.Active;
			historyMaxSizeSpin.Sensitive = saveHistoryChBox.Active && historyLimitSizeChBox.Active;
		}

		protected virtual void OnHistoryLimitSizeChBoxClicked (object sender, System.EventArgs e){
			historyMaxSizeSpin.Sensitive = historyLimitSizeChBox.Active;
		}
	}
}