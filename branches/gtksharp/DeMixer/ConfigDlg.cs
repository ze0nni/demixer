using System;
using DeMixer.lib;
using Gdk;
using System.Collections.Generic;
using System.IO;

namespace DeMixer {
	public partial class ConfigDlg : Gtk.Dialog {	
		
		IDeMixerKernel Kernel;

		public ConfigDlg(IDeMixerKernel k) {			
			this.Build();
			Kernel = k;
			Kernel.TranslateWidget(this);
			init();			
		}
		
		//Список активных эффектов
		Gtk.ListStore EffectsListStore = null;
		
		void init() {									
			foreach (ImagesSource s in Kernel.SourceList) {
				SourceCb.AppendText(s.PluginTitle);
			}			
			SourceCb.Active = Kernel.ActiveSourceIndex;
			SourceCb.ShowAll();
			
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
			reloadEffectList();
			
			#region system page
			try {
				intervalScale.Value = timeToInterval(Kernel.UpdateInterval);
				OnIntervalScaleChangeValue(intervalScale, new Gtk.ChangeValueArgs());
			} catch {
			}
			switch (Kernel.UpdateIntervalMode) {
			case UpdateMode.UpdateOnStart:
				UpdateIntervalModeCb.Active = 0;
				break;
			case UpdateMode.WaitFromStart:
				UpdateIntervalModeCb.Active = 1;
				break;
			case UpdateMode.WaitFromLastUpdate:
				UpdateIntervalModeCb.Active = 2;
				break;
			}
			#endregion
			
			#region profiles
			updateProfilesList();
			#endregion
		}

		Gtk.Widget lastSourceView = null;

		protected virtual void OnSourceCbChanged(object sender, System.EventArgs e) {
			Kernel.ActiveSourceIndex = SourceCb.Active;
			SourceInformationLabel.Markup = Kernel.ActiveSource.PluginDescription;
			Gtk.Widget view = Kernel.ActiveSource.ExpandTagsControl;
			
			if (lastSourceView != null) {
				SourceSettingsPlace.Remove(lastSourceView);	
				lastSourceView.Destroy();
			}
			
			if (view == null) {
				view = new Gtk.Label("no options");	
			}
			//fix: Stranget effect — with mark-up
			//Kernel.TranslateWidget(view);
			lastSourceView = view;
			SourceSettingsPlace.Add(view);
			view.ShowAll();			
		}
		
		Gtk.Widget lastCompositionView = null;

		protected virtual void OnCompositionComboBoxChanged(object sender, System.EventArgs e) {
			try {
				Kernel.ActiveCompositionIndex = CompositionComboBox.Active;
				Kernel.ActiveComposition.UpdatePreview += delegate {
					updatePreview();
				};
				CompositionInformationLabel.Markup = Kernel.ActiveComposition.PluginDescription;
				
				Gtk.Widget view = Kernel.ActiveComposition.ExpandControl;
				
				if (lastCompositionView != null) {
					CompositionSettingsPlace.Remove(lastCompositionView);	
					lastCompositionView.Destroy();
				}			
				if (view == null) {
					view = new Gtk.Label("no options");	
				}
				//Kernel.TranslateWidget(view);
				lastCompositionView = view;
				CompositionSettingsPlace.Add(view);						
				view.ShowAll();
				updatePreview();
			} catch (Exception exc) {
				Console.WriteLine(exc);	
			}
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
		
		#region updatePreview
		
		internal class ColorSource : ImagesSource {			
			Random rndCol;
			public ColorSource() {
				rndCol = new Random();
			}
			
			public ColorSource(int s) {
				rndCol = new Random(s);
			}
			
            public override System.Drawing.Image GetNextImage () {
				System.Drawing.Image img = new System.Drawing.Bitmap(320, 200);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);                   
                g.Clear(System.Drawing.Color.FromArgb(255,
                                       (byte)rndCol.Next(),
                                       (byte)rndCol.Next(),
                                       (byte)rndCol.Next()));
                return img;
            }
                
            public override System.Drawing.Image GetImageFromSource (string source) {
				return null;
            }
        
        }
		
		static Gdk.Pixbuf image2Pixbuf(System.Drawing.Image image ) {
			using ( MemoryStream stream = new MemoryStream() ) {
				image.Save( stream, System.Drawing.Imaging.ImageFormat.Png );
				stream.Position = 0;
				return new Gdk.Pixbuf( stream );
			}
	    } 
		
		int updatePreviewLastTick = 0;
		void updatePreview() {
			updatePreviewLastTick = Environment.TickCount;
			int t = updatePreviewLastTick;
			new System.Threading.Thread((System.Threading.ThreadStart)delegate {
				System.Threading.Thread.Sleep(150);
				if (updatePreviewLastTick != t) return;
				ColorSource src = new ColorSource(0);
				src.Init(Kernel);
				System.Drawing.Image img = Kernel.ActiveComposition.GetCompostion(src, 800, 600);
				img = new System.Drawing.Bitmap(img, new System.Drawing.Size(800/3, 600/3));
				//Gdk.Pixbuf gtkimg = new Gdk.Pixbuf(@"/home/onni/Изображения/demixer-wallpaper.png", 320, 200);
				Gdk.Pixbuf gtkimg = image2Pixbuf(img);
				Gtk.Application.Invoke(delegate {
					imagePreview.Pixbuf = gtkimg;
				});
			}).Start();
		}
		#endregion
		
		#region updateDesktop			
		int updateDesktopLastTick = 0;
		void updateDesktop() {
			//Обновляем не сразу, а с небольшой задержкой
			updateDesktopLastTick = Environment.TickCount;
			int t = updateDesktopLastTick;
			new System.Threading.Thread((System.Threading.ThreadStart)delegate {
				System.Threading.Thread.Sleep(2500);
				if (updateDesktopLastTick != t) return;
				Kernel.UpdateEffectForLastWallpaper();				
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
			EffectsList.ShowAll();
		}
		
		void reloadEffectList() {
			EffectsListStore.Clear();
			foreach (ImagePostEffect e in Kernel.ActiveEffects) {
				EffectsListStore.AppendValues(new object[]{e.PluginName, e.ToString()});				
			}
			EffectsList.ShowAll();
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
		
		#region interval 
		
		 public static int intervalToTime(int v) {
                        int res = v;
                        if (res <= 10) {
                                return res;
                        } else if (res <= 20) {
                                return (res - 10) * 5 + 10;
                        } else if (res <= 24) {
                                return (res - 20) * 15 + 60;
                        } else if (res <= 44) {
                                return (res - 24) * 30 + 60 * 2;
                        } else {
                                return (res - 44) * 60 + 60 * 12;       
                        }
                }
                
                public static int timeToInterval(int v) {
                        v = v / 60 / 1000;
                        if (v<=10) return v; //1..10
                        else if (v<=60) return (v - 10) / 5 + 10; //11..20
                        else if (v<=120) return (v - 60) / 15 + 20; //21..24
                        else if (v<=720) return (v - 120) / 30 + 24; //25..44
                        else if (v<=1440) return (v - 720) / 60 + 44; //45..56
                        else return 56;
                }

		
		protected void OnIntervalScaleChangeValue(object o, Gtk.ChangeValueArgs args) {
			int i = intervalToTime((int)intervalScale.Value);
			IntervalLabel.Text = "123";
                        if (i<60) {
                                IntervalLabel.Text = Kernel.Translate("{0} m", i);
                        } else {
                                int h = i / 60;
                                int m = i % 60;
                                IntervalLabel.Text = m == 0 ?
                                        Kernel.Translate("{0} h", h) :
                                        Kernel.Translate("{0} h {1} m", h, m);
                        }
                        Kernel.UpdateInterval = i * 60 * 1000;
		}
		
		#endregion
		protected void OnUpdateIntervalModeCbChanged(object sender, System.EventArgs e) {
			switch (UpdateIntervalModeCb.Active) {
			case 0:
				Kernel.UpdateIntervalMode = UpdateMode.UpdateOnStart;
				break;
			case 1:
				Kernel.UpdateIntervalMode = UpdateMode.WaitFromStart;
				break;
			case 2:
				Kernel.UpdateIntervalMode = UpdateMode.WaitFromLastUpdate;
				break;
			}
		}
		
		#region profiles
		
		void updateProfilesList() {			
			((Gtk.ListStore)ProfilesCb.Model).Clear();
			foreach (string p in Kernel.GetProfileList()) {
				ProfilesCb.AppendText(p);				
			}
			ProfilesCb.ShowAll();
		}
				
		
		protected virtual void OnsaveProfileBtnClicked(object sender, System.EventArgs e) {
			SaveProfileDialog dlg =
				new SaveProfileDialog("Save profeile dialog", this);
			//Kernel.TranslateWidget(dlg);			
			if ((Gtk.ResponseType)dlg.Run() == Gtk.ResponseType.Ok) {
				Kernel.SaveProfile(dlg.ProfileName,
					dlg.SaveSource,
					dlg.SaveCompostion,
					dlg.SaveEffects);
				updateProfilesList();
			}
			dlg.Destroy();			
		}
		

		protected void OnApplyProfileBtnClicked(object sender, System.EventArgs e) {
			Kernel.LoadProfile(ProfilesCb.ActiveText, true, true, true);
			
			SourceCb.Active = Kernel.ActiveSourceIndex;
			OnSourceCbChanged(SourceCb, new EventArgs());
			CompositionComboBox.Active = Kernel.ActiveCompositionIndex;
			OnCompositionComboBoxChanged(CompositionComboBox, new EventArgs());
			reloadEffectList();			
		}

		protected void OnProfilesCbChanged(object sender, System.EventArgs e) {
			applyProfileBtn.Sensitive = ProfilesCb.Active != -1;
			deleteProfileBtn.Sensitive = ProfilesCb.Active != -1;
		}

		protected void OnDeleteProfileBtnClicked(object sender, System.EventArgs e) {
			Kernel.DeleteProfile(ProfilesCb.ActiveText);
			updateProfilesList();
		}
		#endregion
	}
}
