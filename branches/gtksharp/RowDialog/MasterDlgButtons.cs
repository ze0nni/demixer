
using System;
using System.Windows.Forms;

namespace RowDialog {
		
	public class MasterDlgButtons : Control {
		private RowDialogClass Dlg;
		public MasterDlgButtons(RowDialogClass dlg) {
			Dlg = dlg;
			Button btnBack = new Button();
			Controls.Add(btnBack);
			btnBack.Top = 8;
			btnBack.Left = 8;
			btnBack.Text = "<< Назад";
			btnBack.Enabled = Dlg.ActivePageIndex > 0;
			btnBack.Click += delegate(object sender, EventArgs e) {
				Dlg.ActivePageIndex -= 1;
				btnBack.Enabled = Dlg.ActivePageIndex > 0;
			};
			
			Button btnNext = new Button();
			Controls.Add(btnNext);
			btnNext.Top = 8;
			btnNext.Left += btnNext.Width + 16;
			btnNext.Text = "Далее >>";
			btnNext.Click += delegate(object sender, EventArgs e) {
				if (Dlg.ActivePageIndex < Dlg.PagesCount-1) {
					Dlg.ActivePageIndex += 1;
					btnBack.Enabled = Dlg.ActivePageIndex > 0;
				} else {
					if (BtnReadyClick != null) {
						BtnReadyClick(this, new EventArgs());	
					}
				}
			};
			
			Height = btnBack.Height + 16;
		}	
		
		public event EventHandler<EventArgs> BtnCancelClick;
		public event EventHandler<EventArgs> BtnReadyClick;
	}
}
