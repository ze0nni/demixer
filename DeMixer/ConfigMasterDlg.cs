
using System;
using RowDialog;
using System.Windows.Forms;
using System.Drawing;
using DeMixer.lib;
using System.Reflection;
using System.Diagnostics;

namespace DeMixer {
	
	
	public class ConfigMasterDlg : RowDialogClass {
		
		private IDeMixerKernel Kernel;
		public ConfigMasterDlg(IDeMixerKernel kernel) {
			Kernel = kernel;
			Init();
		}
		
		private Label MasterText = new Label();
		protected override Control GetFixedTop () {			
			MasterText.Text = "";
			MasterText.Height = MasterText.Font.Height * 3;
			MasterText.BackColor = SystemColors.Window;
			MasterText.ForeColor = SystemColors.WindowText;
			return MasterText;
		}
		
		protected override Control GetFixedBottom () {
			MasterDlgButtons btns = new MasterDlgButtons(this);
			btns.BtnReadyClick += delegate {
				Kernel.ActiveSourceIndex = SourcesLb.SelectedIndex;	
				Kernel.UpdateInterval = ConfigDialog.GetInterval(TimeIntervalLb.SelectedIndex+1) * 60 * 1000;
				Kernel.UpdateIntervalMode = UpdateIntervalMode;
				this.DialogResult = DialogResult.OK;				
			};
			return btns;
		}
 

		ListBox SourcesLb;
		ListBox TimeIntervalLb;
		int UpdateIntervalMode = 1;
		
		private TextBox SourceTagsText = new TextBox();
		private Button SourceConfigBtn;
		private int SourceTagsTextPageIndex;
		private int SourceTagsTextCtrlIndex;
		public void Init() {
			MasterText.Text = Kernel.Translate("core.cfgwiz title");
			
			Text = Kernel.Translate("core.cfgwiz window title");
			Width*=2;				
			#region page 1
			TextBox WelcomeText = new TextBox();
			WelcomeText.Multiline = true;
			WelcomeText.Height *= 11;
			WelcomeText.ReadOnly = true;
			WelcomeText.ScrollBars = ScrollBars.Vertical;
			WelcomeText.BorderStyle = BorderStyle.None;
			
			WelcomeText.Text = Kernel.Translate("core.cfgwiz welcome text");					
			
			AddRow(WelcomeText);
		 	//AddText("Для начала работы Мастра нажмите Далее");
			#endregion page 1			
			#region page 2
			NewPage();
			AddText(Kernel.Translate("core.cfgwiz select source"));
			SourcesLb = new ListBox();
			TextBox SourceDescText = new TextBox();
			LinkLabel SourceUrl = new LinkLabel();
			
			AddRow(SourcesLb);
			foreach (ImagesSource imgsrc in Kernel.SourceList) {
				SourcesLb.Items.Add(imgsrc);	
			}
			SourcesLb.SelectedIndexChanged += delegate(object sender, EventArgs e) {
				ImagesSource imgs = (ImagesSource)SourcesLb.SelectedItem;
				
				SourceUrl.Text = imgs.Url;
				SourceTagsText.Enabled = imgs.AllowTags;
				SourceTagsText.Text = SourceTagsText.Enabled ?
						imgs.Tags : "";
				
				SourceConfigBtn.Enabled = imgs.AcceptDialog;
				
				Type imgst = imgs.GetType();
				MethodInfo GetPluginDescription = imgst.GetMethod("GetPluginDescription");
				SourceDescText.Text = GetPluginDescription == null ?
					"" :
						GetPluginDescription.Invoke(imgs, new object[0]).ToString();
				Control ExpandTagsEdit = imgs.ExpandTagsControl;				
								
				if (ExpandTagsEdit != null ) {
					ExpandTagsEdit.Location = SourceTagsText.Location;
					ExpandTagsEdit.Size = SourceTagsText.Size;
					FPages[SourceTagsTextPageIndex][SourceTagsTextCtrlIndex] = ExpandTagsEdit;
					Controls.Remove(SourceTagsText);
				} else {
					FPages[SourceTagsTextPageIndex][SourceTagsTextCtrlIndex] = SourceTagsText;
				}
			};
			// LOOK DOWN SourcesLb.SelectedIndex = 0;
			
			SourceUrl.Click += delegate(object sender, EventArgs e) {
				ProcessStartInfo psi = new ProcessStartInfo(SourceUrl.Text);
	            Process p = new Process();
	            p.StartInfo = psi;
	            p.Start();  
			};
			AddRow(SourceUrl);
			
			//TextBox SourceDescText = new TextBox();
			SourceDescText.Multiline = true;
			SourceDescText.Height = SourceDescText.Font.Height * 7;
			SourceDescText.BorderStyle = BorderStyle.None;
			SourceDescText.ScrollBars = ScrollBars.Vertical;
			SourceDescText.ReadOnly = true;
			AddRow(SourceDescText);
						
			#endregion
			#region page 3
			NewPage();
			AddText(Kernel.Translate("core.cfgwiz source tags"));
			//TextBox SourceTagsText = new TextBox();
			SourceTagsText.Multiline = true;
			SourceTagsText.Height = SourceDescText.Font.Height * 9;
			SourceTagsText.ScrollBars = ScrollBars.Vertical;			
			AddRow(SourceTagsText);
			SourceTagsTextPageIndex = ActivePageIndex;
			SourceTagsTextCtrlIndex = FPages[ActivePageIndex].IndexOf(SourceTagsText);
						
			
			SourceConfigBtn = new Button();
			SourceConfigBtn.Text = Kernel.Translate("core.cfgwiz source dialog");
			SourceConfigBtn.Width *= 2;
			SourceConfigBtn.Height *= 2;
			SourceConfigBtn.Click += delegate(object sender, EventArgs e) {
				((ImagesSource)SourcesLb.SelectedItem).ShowDialog(this);
			};
			AddCol(SourceConfigBtn);
			
			/* LOOK UP */ SourcesLb.SelectedIndex = 0;
			#endregion
			#region page 4
			NewPage();
			AddText(Kernel.Translate("core.cfgwiz select interval"));
			TimeIntervalLb = new ListBox();			
			for (int i=1; i<=56; i++) {				
				int interval = ConfigDialog.GetInterval(i);
				string txt = "";
				if (i<60) {
					txt = Kernel.Translate("core.cfg.program interval {0} m", i);
				} else {
					int h = i / 60;
					int m = i % 60;
					txt = m == 0 ?
						Kernel.Translate("core.cfg.program interval {0} h", h) :
						Kernel.Translate("core.cfg.program interval {0} h {1} m", h, m);
				}
				TimeIntervalLb.Items.Add(txt);
			}
			TimeIntervalLb.SelectedIndex = 19;			
			AddRow(TimeIntervalLb);
			
			AddText("Выбирете от какого момента следует вести отсчет времени:");
			RadioButton btnFromStart = new RadioButton();
			btnFromStart.Text = "Считать время от старта программы (обои меняются при запуске)";
			btnFromStart.Click += delegate {
				UpdateIntervalMode = 0;
			};
			
			RadioButton btnWaitFromStart = new RadioButton();
			btnWaitFromStart.Checked = true;
			btnWaitFromStart.Text = "Считать время от старта программы (обои НЕ меняются при запуске)";
			btnWaitFromStart.Click += delegate {
				UpdateIntervalMode = 1;
			};
			
			RadioButton btnFromLastTime = new RadioButton();
			btnFromLastTime.Text = "Считать время от последнегй смены обоев, даже если программа выключена";			
			btnFromLastTime.Click += delegate {
				UpdateIntervalMode = 2;
			};
			
			AddRow(btnFromStart);
			AddRow(btnWaitFromStart);
			AddRow(btnFromLastTime);
			
			#endregion		
			#region page 5
			NewPage();
			AddText("Для завершения работы мастера нажмите \"Готово\"");			
			#endregion		
			ActivePageIndex = 0;
			this.LockDialogHeight();
			this.StartPosition = FormStartPosition.CenterScreen;
		}		
	}
}
