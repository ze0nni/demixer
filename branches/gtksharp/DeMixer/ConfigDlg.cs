using System;
using DeMixer.lib;
using Gdk;
using System.Collections.Generic;

namespace DeMixer {
	public partial class ConfigDlg : Gtk.Dialog {

		protected virtual void OnsaveProfileBtnClicked(object sender, System.EventArgs e) {
			SaveProfileDialog dlg =
				new SaveProfileDialog("Save profeile dialog", this);
			Kernel.TranslateWidget(dlg);			
			dlg.Run();
			dlg.Destroy();
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
			Gtk.TreeViewColumn effectNameColumn = new Gtk.TreeViewColumn();
			effectNameColumn.Title = "type";			
			Gtk.CellRendererText effectNameCell = new Gtk.CellRendererText();
			effectNameColumn.PackStart(effectNameCell, true);
			effectNameColumn.AddAttribute(effectNameCell, "text", 0);
			
			Gtk.TreeViewColumn effectStateColumn = new Gtk.TreeViewColumn();
			effectStateColumn.Title = "state";
			Gtk.CellRendererText effectStateCell = new Gtk.CellRendererText();
			effectStateColumn.PackStart(effectStateCell, true);
			effectStateColumn.AddAttribute(effectStateCell, "text", 1);
			
			EffectsList.AppendColumn(effectNameColumn);
			EffectsList.AppendColumn(effectStateColumn);
			Gtk.CellRendererText FoldersListCell = new Gtk.CellRendererText();
			
			EffectsListStore = new Gtk.ListStore(typeof(string), typeof(string));			
			EffectsList.Model = EffectsListStore;
			
			//добавляем эффекты в список
			foreach (ImagePostEffect e in Kernel.ActiveEffects) {
				EffectsListStore.AppendValues(new object[]{e.PluginName, e.ToString()});				
			}
		}

		Gtk.Widget lastSourceView = null;

		protected virtual void OnSourceComboBoxChanged(object sender, System.EventArgs e) {
			Kernel.ActiveSourceIndex = SourceComboBox.Active;
			SourceInformationLabel.Markup = Kernel.ActiveSource.PluginDescription;
			Gtk.Widget view = Kernel.ActiveSource.ExpandTagsControl;
			
			if (lastSourceView != null) {
				SourceVBox.Remove(lastSourceView);	
				lastSourceView.Destroy();
			}
			
			if (view == null) {
				view = new Gtk.Label("no options");	
			}
			Kernel.TranslateWidget(view);
			lastSourceView = view;
			SourceVBox.Add(view);
			view.ShowAll();			
		}
		
		Gtk.Widget lastCompositionView = null;

		protected virtual void OnCompositionComboBoxChanged(object sender, System.EventArgs e) {
			Kernel.ActiveCompositionIndex = CompositionComboBox.Active;
			CompositionInformationLabel.Markup = Kernel.ActiveComposition.PluginDescription;
			
			Gtk.Widget view = Kernel.ActiveComposition.ExpandControl;
			
			if (lastCompositionView != null) {
				CompositionVBox.Remove(lastCompositionView);	
				lastCompositionView.Destroy();
			}			
			if (view == null) {
				view = new Gtk.Label("no options");	
			}
			Kernel.TranslateWidget(view);
			lastCompositionView = view;
			CompositionVBox.Add(view);						
			view.ShowAll();			
		}

		protected virtual void OnEffectsComboBoxChanged(object sender, System.EventArgs e) {
			EffectInformationLabel.Markup = 
				Kernel.PostEffectsList[EffectsComboBox.Active].PluginDescription;
		}

		protected virtual void OnEffectsListCursorChanged(object sender, System.EventArgs e) {
			editEffectBtn.Sensitive = EffectsList.Selection != null;
			deleteEffectBtn.Sensitive = EffectsList.Selection != null;
			cloneEffectBtn.Sensitive = EffectsList.Selection != null;
			Gtk.TreeIter itr;
			if (EffectsList.Selection.GetSelected(out itr)) {				
				upEffectBtn.Sensitive = EffectsListStore.GetPath(itr).ToString() != "0";
				downEffectBtn.Sensitive = EffectsListStore.IterNext(ref itr);
			} else {
				upEffectBtn.Sensitive = downEffectBtn.Sensitive = false;
			}
		}

		protected virtual void OnSaveHistoryChBoxClicked(object sender, System.EventArgs e) {
			selectSaveHostoryFolderBox.Sensitive = saveHistoryChBox.Active;
			historyLimitSizeChBox.Sensitive = saveHistoryChBox.Active;
			historyMaxSizeSpin.Sensitive = saveHistoryChBox.Active && historyLimitSizeChBox.Active;
		}

		protected virtual void OnHistoryLimitSizeChBoxClicked(object sender, System.EventArgs e) {
			historyMaxSizeSpin.Sensitive = historyLimitSizeChBox.Active;
		}

		protected virtual void OnButtonOkClicked(object sender, System.EventArgs e) {
			//todo: save
			this.Hide();
			this.HideAll();
		}
		
		#region updateDesktop			
		int updateDesktopLastTick = 0;
		void updateDesktop() {
			//Обновляем не сразу, а с небольшой задержкой
			updateDesktopLastTick = Environment.TickCount;
			int t = updateDesktopLastTick;
			new System.Threading.Thread((System.Threading.ThreadStart)delegate {
				System.Threading.Thread.Sleep(2500);
				if (updateDesktopLastTick == t) {					
					Kernel.UpdateEffectForLastWallpaper();
				}
			}).Start();
			
		}			
		#endregion
		
		void updateEffectList() {
			Gtk.TreeIter itr;
			if (EffectsListStore.GetIterFirst(out itr)) {
				do {				
					int index = int.Parse(EffectsListStore.GetPath(itr).ToString());
					EffectsListStore.SetValue(itr, 1, Kernel.ActiveEffects[index].ToString());
					if (!EffectsListStore.IterNext(ref itr)) break;
				} while (true);
			}
		}
		
		protected void OnEditEffectBtnClicked(object sender, System.EventArgs e) {			
			Gtk.TreeIter itr;			
			if (EffectsList.Selection.GetSelected(out itr)) {
				int index = int.Parse(EffectsListStore.GetPath(itr).ToString());				
				Kernel.ActiveEffects[index].ShowDialog(this);				
				updateEffectList();								
				updateDesktop();
				OnEffectsListCursorChanged(this, new EventArgs());
			}	
		}

		protected void OnEffectAddBtnClicked (object sender, System.EventArgs e) {
			Gtk.TreeIter itr;			
			if (EffectsComboBox.GetActiveIter(out itr)) {
				ImagePostEffect ef = Kernel.PostEffectsList[EffectsComboBox.Active].GetClone();							
				List<ImagePostEffect> l = new List<ImagePostEffect>();
				l.AddRange(Kernel.ActiveEffects);
				l.Add(ef);
				Kernel.ActiveEffects = l.ToArray();
				EffectsList.Selection.SelectIter(
					EffectsListStore.AppendValues(new object[]{ef.PluginName, ef.ToString()})
					);
				updateDesktop();
				OnEffectsListCursorChanged(this, new EventArgs());
			}
		}

		protected void OnDeleteEffectBtnClicked (object sender, System.EventArgs e) {
			Gtk.TreeIter itr;			
			if (EffectsList.Selection.GetSelected(out itr)) {
				int index = int.Parse(EffectsListStore.GetPath(itr).ToString());				
				List<ImagePostEffect> l = new List<ImagePostEffect>();
				l.AddRange(Kernel.ActiveEffects);
				l.RemoveAt(index);
				Kernel.ActiveEffects = l.ToArray();
				EffectsListStore.Remove(ref itr);
				updateDesktop();
				OnEffectsListCursorChanged(this, new EventArgs());
			}
		}

		protected void OnUpEffectBtnClicked (object sender, System.EventArgs e) {
			Gtk.TreeIter itr;			
			if (EffectsList.Selection.GetSelected(out itr)) {
				int index = int.Parse(EffectsListStore.GetPath(itr).ToString());				
				List<ImagePostEffect> l = new List<ImagePostEffect>();
				l.AddRange(Kernel.ActiveEffects);
				//
				Kernel.ActiveEffects = l.ToArray();
				EffectsListStore.Remove(ref itr);
				updateDesktop();
				OnEffectsListCursorChanged(this, new EventArgs());
			}
		}
	}
}
