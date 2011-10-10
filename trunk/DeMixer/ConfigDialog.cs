
using System;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using DeMixer.lib;
using System.IO;
using RowDialog;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Drawing;

namespace DeMixer {
	
	
	public class ConfigDialog :RowDialogClass {
		private IDeMixerKernel Kernel;
		public ConfigDialog(IDeMixerKernel kernel) {
			Kernel = kernel;
			Width *= 2;
			InitControls();
			LockDialogHeight();
			
			//if (Height > Screen.PrimaryScreen.WorkingArea.Height) {
			//	InitControls(true);
			//	LockDialogHeight();
			//}
						
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			Text = "Конфигурации";
		}
#region InitControls
				
		private ComboBox SourceComboBox = new ComboBox();
		private LinkLabel SourceUrlLabel = new LinkLabel();
		private TextBox TagsEdit = new TextBox();
		private Panel TagPanel = new Panel();
		private ComboBox ProfileComboBox = new ComboBox();
		private ComboBox CompositionComboBox = new ComboBox();
		
		private TrackBar IntervalTrackBar = new TrackBar();
		private Label IntervalLabel = new Label();	
		private ListBox EffectsListBox = new ListBox();
		private ComboBox EffectsComboBox = new ComboBox();
		private bool InitComplite = false;		
		
		Button btnOk = new Button();
		protected override Control GetFixedBottom () {			
			Panel bottomP = new Panel();			
			btnOk.Click += delegate {
				DialogResult = DialogResult.OK;	
			};
			AcceptButton = btnOk;		
			bottomP.Controls.Add(btnOk);
			
			bottomP.Height = btnOk.Height + 16;
			btnOk.Location = new System.Drawing.Point(bottomP.Width - btnOk.Width - 8, 8);
			btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			
			return bottomP;
		}

		private class tabPageTag {
			public tabPageTag(int ind) {
				index = ind;	
			}
			public int index;	
		}
		
		Label[] pagesTabs = new Label[4];
		protected override Control GetFixedTop () {
			Panel topP = new Panel();
			
			for (int i=0; i<4; i++) {
				pagesTabs[i] = new Label();
				pagesTabs[i].Tag = new tabPageTag(i);
				pagesTabs[i].Click += delegate(object sender, EventArgs e) {
					tabPageTag tt = (tabPageTag)((Control)sender).Tag;
					ActivePageIndex = tt.index;
					updatePagesColor();
				};
				pagesTabs[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				pagesTabs[i].Left = 8 + (pagesTabs[i].Width + 4) * i;				
				pagesTabs[i].Top = 8;				
				topP.Controls.Add(pagesTabs[i]);
			}
			topP.Height = pagesTabs[0].Height + 16;
			updatePagesColor();
			return topP;
	 	}
		
		void updatePagesColor() {
			for (int pi=0; pi<4; pi++) {
				Label p = pagesTabs[pi];
				p.Cursor = System.Windows.Forms.Cursors.Hand;
				if 	(ActivePageIndex == pi) {					
					p.BackColor = System.Drawing.SystemColors.ActiveCaption;
					p.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				} else {										
					p.BackColor = System.Drawing.SystemColors.InactiveCaption;
					p.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				}
			}	
		}

		
		private void InitControls() {
			//top control			
			
			for (int i=0; i<4; i++) {
				switch (i) {
					case 0:
						pagesTabs[i].Text = Kernel.Translate("core.cfg.page source");
						break;
					case 1:
						pagesTabs[i].Text = Kernel.Translate("core.cfg.page composition");
						break;
					case 2:
						pagesTabs[i].Text = Kernel.Translate("core.cfg.page effects");
						break;
					case 3:
						pagesTabs[i].Text = Kernel.Translate("core.cfg.page system");
						break;						
				}
			}			
			//bottom control			
			btnOk.Text = Kernel.Translate("core.cfg btnok");
			
			//SetRowSpace(compact_mod ? 1 : 8);
			//Clear();
			SourceComboBox = new ComboBox();
			SourceUrlLabel = new LinkLabel();
			TagPanel = new Panel();
			TagsEdit = new TextBox();
			ProfileComboBox = new ComboBox();
			CompositionComboBox = new ComboBox();
			IntervalTrackBar = new TrackBar();
			IntervalLabel = new Label();	
			EffectsListBox = new ListBox();
			EffectsComboBox = new ComboBox();
			
			//todo
			#region SourceComboBox					
			SourceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (ImagesSource s in Kernel.SourceList) {
				SourceComboBox.Items.Add(s.PluginName);	
			}
			SourceComboBox.SelectedIndexChanged += SourceHandleSelectedIndexChanged;
			//LOOK DOWN! SourceComboBox.SelectedIndex = Kernel.ActiveSourceIndex;
			Button btnConfigSource = new Button();
			btnConfigSource.Click += btnConfigSourceHandleClick;			
			btnConfigSource.Text = Kernel.Translate("core.cfg.source dialog");			
			//AddTextCol("Источник", true);
			AddRight(btnConfigSource);
			AddRow(SourceComboBox);
#endregion
#region TagsEdit			
			TagsEdit.Multiline = true;
			TagsEdit.ScrollBars = ScrollBars.Vertical;
			TagsEdit.Height *= 8;
			TagsEdit.TextChanged += TagsEditHandleTextChanged;
						
			TagPanel.Controls.Add(TagsEdit);			
			TagPanel.Width = TagsEdit.Width;
			TagPanel.Height = TagsEdit.Height;
			TagsEdit.Dock = DockStyle.Fill;
			
			SourceUrlLabel.Click += HandleSourceUrlLabelClick;
			
			AddTextCol(Kernel.Translate("core.cfg.source tags"));
			AddRow(SourceUrlLabel);
			AddRow(TagPanel);
			
			/* LOOK UP */SourceComboBox.SelectedIndex = Kernel.ActiveSourceIndex;
#endregion			
#region ProfileComboBox
			AddTextCol(Kernel.Translate("core.cfg.profiles"));
			UpdateProfilesList();
			{
				Button btnDeleteProfile = new Button();
				btnDeleteProfile.Text = Kernel.Translate("core.cfg.profile delete");
				btnDeleteProfile.Click += BtnDeleteProflieHandleClick;
				AddRight(btnDeleteProfile);
				
				Button btnSaveProfile = new Button();
				btnSaveProfile.Text = Kernel.Translate("core.cfg.profile save");
				btnSaveProfile.Click += BtnWriteProflieHandleClick;
				AddRight(btnSaveProfile);
				
				Button btnReadProfile = new Button();
				btnReadProfile.Click += BtnReadProflieHandleClick;
				btnReadProfile.Text = Kernel.Translate("core.cfg.profile load");
				AddRight(btnReadProfile);							
			}
			AddRow(ProfileComboBox);
#endregion		
			NewPage();
#region CompositionComboBox			
			CompositionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (ImagesComposition c in Kernel.CompositionList) {
				CompositionComboBox.Items.Add(c.PluginName);
			}					
						
			
			TextBox compositionTitle = new TextBox();						
			Panel drawArea = new Panel();
						
			
			CompositionComboBox.SelectedIndexChanged += delegate {
				Kernel.ActiveCompositionIndex = CompositionComboBox.SelectedIndex;	
				compositionTitle.Text = Kernel.ActiveComposition.PluginTitle;
				
				ImagesSource src = Kernel.ActiveComposition.Source;
				drawArea.BackgroundImage = Kernel.ActiveComposition.GetCompostion(
				                                                                  new ColorSource(),
				                                                                  drawArea.ClientSize.Width*5,
				                                                                  drawArea.ClientSize.Height*5);
				
			};
			
			CompositionComboBox.SelectedIndex = Kernel.ActiveCompositionIndex;
			
			Button btnConfigComposition = new Button();
			btnConfigComposition.Text = Kernel.Translate("core.cfg.composition dialog");
			btnConfigComposition.Click += delegate {
				Kernel.ActiveComposition.ShowDialog();			
				ImagesSource src = Kernel.ActiveComposition.Source;
				drawArea.BackgroundImage = Kernel.ActiveComposition.GetCompostion(
				                                                                  new ColorSource(),
				                                                                  drawArea.ClientSize.Width*5,
				                                                                  drawArea.ClientSize.Height*5);
			};
					
			compositionTitle.Multiline = true;
			compositionTitle.Height *= 2;
			compositionTitle.ReadOnly = true;
			compositionTitle.BorderStyle = BorderStyle.None;
			
			
			drawArea.Height = (int) (drawArea.Height * 1.5);
			drawArea.Width = drawArea.Height * 2;
			drawArea.BorderStyle = BorderStyle.Fixed3D;
			drawArea.BackgroundImageLayout = ImageLayout.Stretch;
			
			//AddText("Расположение", true);
			AddRight(btnConfigComposition);
			AddRow(CompositionComboBox);
			AddRow(compositionTitle);
			AddCol(drawArea);			
			AddRow(new Panel());			
#endregion
			NewPage();
#region PostEffects
			EffectsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (ImagePostEffect pe in Kernel.PostEffectsList) {
				EffectsComboBox.Items.Add(pe.PluginName);					
			}
						
			UpdateEffectsList();						
			
			Button btnAddEffect = new Button();
			btnAddEffect.Text = Kernel.Translate("core.cfg.effects add");
			#region btnAddEffect
			btnAddEffect.Click += delegate(object sender, EventArgs e) {
				if (EffectsComboBox.SelectedIndex != -1) {	
					EffectsListBox.Items.Add(Kernel.PostEffectsList[EffectsComboBox.SelectedIndex].GetClone());
					MoveEffectListToKernal();
					Kernel.UpdateEffectForLastWallpaper();
				}				
			};			
			#endregion
			
			Button btnConfigEffect = new Button();
			btnConfigEffect.Text = Kernel.Translate("core.cfg.effects dialog");
			#region btnConfigEffect
			btnConfigEffect.Click += delegate(object sender, EventArgs e) {
				ImagePostEffect pe = (ImagePostEffect)EffectsListBox.SelectedItem;
				if (pe != null) {
					pe.ShowDialog();					
					EffectsListBox.Invalidate();
					Kernel.UpdateEffectForLastWallpaper();
					UpdateEffectsList();
				}
			};
			#endregion
			
			Button btnCopyEffect = new Button();
			btnCopyEffect.Text = Kernel.Translate("core.cfg.effects clone");
			#region btnCopyEffect
			btnCopyEffect.Click += delegate(object sender, EventArgs e) {
				ImagePostEffect pe = (ImagePostEffect)EffectsListBox.SelectedItem;
				if (pe != null) {
					EffectsListBox.Items.Add(pe.GetClone());
					MoveEffectListToKernal();
					Kernel.UpdateEffectForLastWallpaper();
					UpdateEffectsList();
				}
			};
			#endregion
			
			Button btnMoveUp = new Button();
			btnMoveUp.Text = Kernel.Translate("core.cfg.effects up");
			#region btnMoveUp
			btnMoveUp.Click += delegate(object sender, EventArgs e) {
				int index = EffectsListBox.SelectedIndex;
				if (index > 0) {					
					object o = EffectsListBox.SelectedItem;
					EffectsListBox.Items.RemoveAt(index);
					EffectsListBox.Items.Insert(index-1, o);
					EffectsListBox.SelectedIndex = index - 1;
					MoveEffectListToKernal();
					Kernel.UpdateEffectForLastWallpaper();
				}
			};
			#endregion
			
			Button btnMoveDown = new Button();
			btnMoveDown.Text = Kernel.Translate("core.cfg.effects down");
			#region btnMoveDown
			btnMoveDown.Click += delegate(object sender, EventArgs e) {
				int index = EffectsListBox.SelectedIndex;
				if (index < EffectsListBox.Items.Count - 1) {					
					object o = EffectsListBox.SelectedItem;
					EffectsListBox.Items.RemoveAt(index);
					EffectsListBox.Items.Insert(index+1, o);
					EffectsListBox.SelectedIndex = index + 1;
					MoveEffectListToKernal();
					Kernel.UpdateEffectForLastWallpaper();
				}
			};
			#endregion
			
			Button btnDeleteEffect = new Button();
			btnDeleteEffect.Text = Kernel.Translate("core.cfg.effects delete");	
			#region btnDeleteEffect
			btnDeleteEffect.Click += delegate(object sender, EventArgs e) {
				if (EffectsListBox.SelectedIndex != -1) {					
					EffectsListBox.Items.RemoveAt(EffectsListBox.SelectedIndex);
					MoveEffectListToKernal();
					Kernel.UpdateEffectForLastWallpaper();
				}
			};
			#endregion
						
			//AddText("Эффекты", true);
			AddRight(btnAddEffect);
			AddRow(EffectsComboBox);
			AddRow(EffectsListBox);
			AddCol(btnConfigEffect);
			AddCol(btnCopyEffect);
			AddCol(btnMoveUp);
			AddCol(btnMoveDown);
			AddCol(btnDeleteEffect);
			EndCol();
#endregion
			NewPage();
#region PreviewBox	
			/*
			PreviewBox.BorderStyle = BorderStyle.Fixed3D;
			PreviewBox.Width = 190;
			PreviewBox.Height = 120;
			AddText("Демонстрация", true);
			AddCol(PreviewBox);
			EndCol();
			*/
#endregion
#region IntervalTrackBar
			CheckBox saveHistoryCb = new CheckBox();			
			saveHistoryCb.Text = Kernel.Translate("core.cfg.program save history");
			
			NumericUpDown historySizeUd = new NumericUpDown();
			historySizeUd.Minimum = 0;
			historySizeUd.Maximum = 1024*5;
			try { historySizeUd.Value = Kernel.SaveHistorySize; } catch {}
			historySizeUd.ValueChanged += delegate {
				Kernel.SaveHistorySize = (int)historySizeUd.Value;	
			};
			
			TextBox saveToDir = new TextBox();
			saveToDir.Text = Kernel.SaveHistoryPath;
			
			saveToDir.TextChanged += delegate {
				Kernel.SaveHistoryPath = saveToDir.Text;
			};
			
			Button saveToDirSelectBtn = new Button();
			saveToDirSelectBtn.Text = Kernel.Translate("core.cfg.program select dir");
			saveToDirSelectBtn.Click += delegate {
				FolderBrowserDialog dlg = new FolderBrowserDialog();
				dlg.SelectedPath = saveToDir.Text;
				if (dlg.ShowDialog() == DialogResult.OK) {
					saveToDir.Text = dlg.SelectedPath;	
				}
			};
			
			saveHistoryCb.Checked = true;
			saveHistoryCb.CheckedChanged += delegate {
				historySizeUd.Enabled = saveHistoryCb.Checked;
				saveToDir.Enabled = saveHistoryCb.Checked;
				saveToDirSelectBtn.Enabled = saveHistoryCb.Checked;
				Kernel.SaveHistory = saveHistoryCb.Checked;
			};			
			saveHistoryCb.Checked = Kernel.SaveHistory;
			
			AddCol(saveHistoryCb);			
			AddCol(historySizeUd);
			AddText(Kernel.Translate("core.cfg.program history size"));
			
			AddTextCol(Kernel.Translate("core.cfg.program save to dir"));
			AddRight(saveToDirSelectBtn);
			AddRow(saveToDir);
			
			IntervalTrackBar.ValueChanged += IntervalTrackBarHandleValueChanged;
			
			
			IntervalTrackBar.Minimum = 1;
			IntervalTrackBar.Maximum = 56;
			try {IntervalTrackBar.Value = SetInterval(Kernel.UpdateInterval); } catch {}
			IntervalTrackBarHandleValueChanged(this, new EventArgs());
			IntervalLabel.Height = IntervalLabel.Font.Height * 2;
			
			ComboBox updateIntervalModeCb = new ComboBox();
			updateIntervalModeCb.DropDownStyle = ComboBoxStyle.DropDownList;
			string[] updateIntervalModeCbItems = {
				Kernel.Translate("core.cfg.program change on start"),
				Kernel.Translate("core.cfg.program wait after start"),
				Kernel.Translate("core.cfg.program wait after last")
			};
			updateIntervalModeCb.Items.AddRange(updateIntervalModeCbItems);
			updateIntervalModeCb.Width = updateIntervalModeCb.Width / 3 * 4;
			updateIntervalModeCb.SelectedIndex = Kernel.UpdateIntervalMode;
			updateIntervalModeCb.SelectedIndexChanged += delegate {
				Kernel.UpdateIntervalMode = updateIntervalModeCb.SelectedIndex;
			};
			
			CheckBox AutorunCb = new CheckBox();
			AutorunCb.Text = Kernel.Translate("core.cfg.program autorun");
			AutorunCb.Checked = (AutorunKey.GetValue(Application.ProductName, "").ToString() == Application.ExecutablePath);
			AutorunCb.Click += delegate(object sender, EventArgs e) {
				if (AutorunCb.Checked) {
					AutorunKey.SetValue(Application.ProductName, Application.ExecutablePath);
				} else {
					AutorunKey.DeleteValue(Application.ProductName);
				}
			};			
			
			Label timeLeftLabel = new Label();
			System.Windows.Forms.Timer timeleftTimer = new System.Windows.Forms.Timer();
			timeleftTimer.Tick += delegate(object sender, EventArgs e) {
				TimeSpan tm = Kernel.TimeLeft;
				timeLeftLabel.Text = string.Format("{0:d2}:{1:d2}:{2:d2}",
				                                   tm.Hours, tm.Minutes, tm.Seconds
				                                   );
			};
			timeleftTimer.Interval = 100;
			timeleftTimer.Start();
			
			//AddText("Смена обоев", true);
			AddCol(IntervalLabel);
			AddRight(updateIntervalModeCb);
			AddRow(IntervalTrackBar);
			AddCol(AutorunCb);
			AddCol(timeLeftLabel);
			
#endregion
			ActivePageIndex = 1;
			ActivePageIndex = 0;
			InitComplite = true;
		}
		
		private void UpdateEffectsList() {
			EffectsListBox.Items.Clear();	
			foreach (ImagePostEffect pe in Kernel.ActiveEffects) {
				EffectsListBox.Items.Add(pe);					
			}
		}
		
		private RegistryKey AutorunKey {
			get { return
				Registry.CurrentUser.
				CreateSubKey("Software").
					CreateSubKey("Microsoft").
						CreateSubKey("Windows").
							CreateSubKey("CurrentVersion").
								CreateSubKey("Run");
			}
		}

		private void btnConfigSourceHandleClick(object sender, EventArgs e) {
			ActiveSource.ShowDialog(this);
			ReadSourceSettings();			
		}
		
		private void ReadSourceSettings() {
			TagsEdit.Enabled = ActiveSource.AllowTags;
			TagsEdit.Text = 
				TagsEdit.Enabled ? ActiveSource.Tags : "";	
			SourceUrlLabel.Text = ActiveSource.Url;
		}

		private void HandleSourceUrlLabelClick(object sender, EventArgs e) {
			ActiveSource.UrlClick();
		}
		
		public static int GetInterval(int v) {
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
		
		private int GetInterval () {
			return	GetInterval(IntervalTrackBar.Value);
		}
		
		public static int SetInterval(int v) {
			v = v / 60 / 1000;
			if (v<=10) return v; //1..10
			else if (v<=60) return (v - 10) / 5 + 10; //11..20
			else if (v<=120) return (v - 60) / 15 + 20; //21..24
			else if (v<=720) return (v - 120) / 30 + 24; //25..44
			else if (v<=1440) return (v - 720) / 60 + 44; //45..56
			else return 56;
		}
		
		void IntervalTrackBarHandleValueChanged(object sender, EventArgs e) {
			int i = GetInterval();
			if (i<60) {
				IntervalLabel.Text = Kernel.Translate("core.cfg.program interval {0} m", i);
			} else {
				int h = i / 60;
				int m = i % 60;
				IntervalLabel.Text = m == 0 ?
					Kernel.Translate("core.cfg.program interval {0} h", h) :
					Kernel.Translate("core.cfg.program interval {0} h {1} m", h, m);
			}
			Kernel.UpdateInterval = i * 60 * 1000;
		}
		
		private void UpdateProfilesList() {
			ProfileComboBox.Items.Clear();
			foreach (string s in Kernel.GetProfileList()) 
				ProfileComboBox.Items.Add(s);
		}
		
		void BtnReadProflieHandleClick(object sender, EventArgs e) {			
			Kernel.LoadConfig(ProfileComboBox.Text);
			SourceComboBox.SelectedIndex = Kernel.ActiveSourceIndex;
			ReadSourceSettings();
			SourceHandleSelectedIndexChanged(this, new EventArgs());
		}
		
		void BtnWriteProflieHandleClick(object sender, EventArgs e) {
			Kernel.SaveConfig(ProfileComboBox.Text);
			UpdateProfilesList();
		}
		
		void BtnDeleteProflieHandleClick(object sender, EventArgs e) {
			if (MessageBox.Show(Kernel.Translate("core.cfg.profile delete dlg title"),
					            Kernel.Translate("core.cfg.profile delete dlg text"),
					                   MessageBoxButtons.YesNo,
					                   MessageBoxIcon.Question) != DialogResult.Yes) return;
			string filename = Kernel.GetUserFileName("profiles", ProfileComboBox.Text);
			FileInfo fi = new FileInfo(filename);			
			try {
				if (!fi.Exists) throw new Exception();
				fi.Delete();
			} catch {
				
			}
			UpdateProfilesList();
		}

		private Control ExpandTagsControl;
		void SourceHandleSelectedIndexChanged(object sender, EventArgs e) {
			if (InitComplite) Kernel.UserRegistry.SetValue("SelectionProfile", "");
			
			Kernel.ActiveSourceIndex = SourceComboBox.SelectedIndex;
			ReadSourceSettings();
			if (ExpandTagsControl != null) {
				ExpandTagsControl.Hide();
				TagPanel.Controls.Remove(ExpandTagsControl);
				ExpandTagsControl = null;				
			}
			ExpandTagsControl = ActiveSource.ExpandTagsControl;
			TagsEdit.Visible = ExpandTagsControl == null;
			if (ExpandTagsControl != null) {
				//ExpandTagsControl.Location = TagsEdit.Location;				
				//ExpandTagsControl.Size = TagsEdit.Size;		
				ExpandTagsControl.Dock = DockStyle.Fill;
				TagPanel.Controls.Add(ExpandTagsControl);
				ExpandTagsControl.Show();
			}
			ReadSourceSettings();
		}
		
		private ImagesSource ActiveSource {
			get {
				return Kernel.SourceList[SourceComboBox.SelectedIndex];
			}
		}
		
		void TagsEditHandleTextChanged(object sender, EventArgs e) {
			if (InitComplite) Kernel.UserRegistry.SetValue("SelectionProfile", "");
			ActiveSource.Tags = TagsEdit.Text;
		}
		
		void MoveEffectListToKernal() {
			List<ImagePostEffect> l = new List<ImagePostEffect>();
			foreach (object o in EffectsListBox.Items) {
					l.Add((ImagePostEffect)o);
			}
			Kernel.ActiveEffects = l.ToArray();
		}
#endregion
	}
	
	internal class ColorSource : ImagesSource {
		Random rndCol = new Random();
		public override Image GetNextImage () {
			Image img = new Bitmap(320, 200);
			Graphics g = Graphics.FromImage(img);			
			g.Clear(Color.FromArgb(255,
			                       (byte)rndCol.Next(),
			                       (byte)rndCol.Next(),
			                       (byte)rndCol.Next()));
			return img;
		}
		
		public override Image GetImageFromSource (string source) {
			throw new System.NotImplementedException ();
		}
	
	}
}
