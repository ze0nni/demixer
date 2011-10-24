
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RowDialog
{
	
	
	public class RowDialogClass : Form{
		
		public RowDialogClass() : base() {						
			FixedTop = GetFixedTop();
			if (FixedTop != null) {
				Controls.Add(FixedTop);
				FixedTop.Dock = DockStyle.Top;
			}
			FixedBottom = GetFixedBottom();
			if (FixedBottom != null) {
				Controls.Add(FixedBottom);
				FixedBottom.Dock = DockStyle.Bottom;
			}
			NewPage();
		}
		
		protected List<List<Control> > FPages = new List<List<Control>>();
		private int FActivePageIndex;
		public int ActivePageIndex {
			get { return FActivePageIndex; }
			set {FActivePageIndex = value; 
				foreach (List<Control> c in FPages) {
					foreach (Control ctrl in c) {
						ctrl.Visible = c == FPages[ActivePageIndex];
						if (ctrl.Visible)
							Controls.Add(ctrl);
						else
							Controls.Remove(ctrl);
					}
				}
			}
		}
		
		public int PagesCount {
			get { return FPages.Count; }
		}
		
		protected void NewPage() {			
			MaximumPageHeight = Math.Max(MaximumPageHeight, GetActualHeight());
			
			FPages.Add(new List<Control>());
			ActivePageIndex = FPages.Count - 1;
			//RowSpace = 8;
			RowLeft = RowSpace;
			RowTop = FixedTop == null ? RowSpace : FixedTop.Height + RowSpace;
			RowRight = 0;
			RowHeight = 0;
		}
		
		private void AddTextRow(string text) {
			Label l = new Label();
			l.Text = text;
			AddRow(l);
		}
		
		protected void AddHr() {
			Panel p = new Panel();
			p.Height = 7;
			p.BorderStyle = BorderStyle.Fixed3D;
			p.BackColor = System.Drawing.SystemColors.InactiveCaption;
			AddRow(p);
		}
		
		private Control FixedTop { get; set; }
		private Control FixedBottom { get; set; }
		
		protected virtual Control GetFixedTop() {
			return null;
		}
		
		protected virtual Control GetFixedBottom() {
			return null;
		}
		
		protected void SetRowSpace(int w) {
			RowSpace = w;
			RowLeft = w;
			RowTop = w;
		}
		
		private int RowSpace = 8;
		private int RowLeft = 8;
		private int RowTop = 8;
		private int RowRight = 0;
		private int RowHeight = 0;
		
		protected void AddTextCol(string text) {
			AddTextCol(text, false);
		}
		
		protected void AddTextCol(string text, bool header) {
			Label l = new Label();
			l.Text = text;
			if (header) {
				l.BorderStyle = BorderStyle.Fixed3D;
				l.BackColor = System.Drawing.SystemColors.InactiveCaption;
				l.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			}
			AddCol(l);
		}
		
		protected void AddText(string text) {
			AddText(text, false);
		}
		
		protected void AddText(string text, bool header) {
			Label l = new Label();
			l.Text = text;
			if (header) {
				l.BorderStyle = BorderStyle.Fixed3D;
				l.BackColor = System.Drawing.SystemColors.InactiveCaption;
				l.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			}
			AddRow(l);
		}
		
		protected void AddRow(Control c) {
			Controls.Add(c);
			FPages[ActivePageIndex].Add(c);
			c.Left = RowLeft;
			c.Top = RowTop;	
			c.Width = ClientSize.Width - RowSpace - RowLeft - RowRight;
			
			if (RowHeight < c.Height) RowHeight = c.Height;
			RowLeft = RowSpace;
			RowTop += RowHeight + RowSpace;
			RowHeight = 0;
			RowRight = 0;
		}
		
		protected void AddCol(Control c) {			
			Controls.Add(c);
			FPages[ActivePageIndex].Add(c);
			c.Left = RowLeft;
			c.Top = RowTop;				
			
			if (RowHeight < c.Height) RowHeight = c.Height;
			RowLeft += c.Width + RowSpace;
		}
		
		protected void EndCol() {
			RowLeft = RowSpace;
			RowTop += RowHeight + RowSpace;
			RowHeight = 0;
			RowRight = 0;
		}
						
		protected void AddRight(Control c) {
			Controls.Add(c);
			FPages[ActivePageIndex].Add(c);
			c.Left = ClientSize.Width - RowSpace - RowRight - c.Width;
			c.Top = RowTop;
			
			RowRight += c.Width + RowSpace;
			if (RowHeight < c.Height) RowHeight = c.Height;
		}
		
		private int MaximumPageHeight = 0;
		private int GetActualHeight() {
			int ah = 0;
			//if (FixedTop != null) ah += FixedTop.Height;
			if (FixedBottom != null) ah += FixedBottom.Height;
			return  RowTop + RowHeight + RowSpace + ah;
		}
		
		protected void Clear() {
			Controls.Clear();	
			RowLeft = RowSpace;
			RowTop = RowSpace;
			RowRight = 0;
			RowHeight = 0;
		}
		
		protected void LockDialogHeight() {
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			this.StartPosition = FormStartPosition.CenterParent;			
			this.SetClientSizeCore(ClientSize.Width,
			                       Math.Max(MaximumPageHeight, GetActualHeight()));
		}
	}
}
