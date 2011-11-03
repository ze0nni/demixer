
using System;
using DeMixer.lib;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Gdk;

namespace DeMixer.lib.std {
	public class DirectorySource : ImagesSource {
		
		public DirectorySource() {			
		}
		
		public override string PluginName {
			get { return "Папка"; }
		}
		
		public override string PluginTitle {
			get { return "Поиск в папках"; }
		}
		
		public List<string> FSeekPath = new List<string>();		
		public override string Url {
			get { return FSeekPath.Count == 0 ? "" : FSeekPath[0]; }	
		}	
		
		
		public string GetPluginDescription() {
			return 	"\tПлагин предназначен для поиска уже сохраненных на жестком диске, " + 
					"или каком либо другом носителе,изображенний.\r\n" +
					"\tВам следует просто указать одну или несколько папок с изображениями.";
		}
		
		public override bool AllowTags {
				get { return false; }
		}
		
		public override Gtk.Widget ExpandTagsControl {
			get {
				return new DirectorySourceConfigView(this);
			}
		}

		
		public override bool SaveConfig(Stream stream) {
			BinaryWriter bw = new BinaryWriter(stream, System.Text.Encoding.UTF8);						
			bw.Write(string.Join("\n", FSeekPath.ToArray()));
			return true;
		}
		
		public override bool LoadConfig(Stream stream) {
			BinaryReader br = new BinaryReader(stream, System.Text.Encoding.UTF8);
			try {
				FSeekPath.Clear();
				string[] seekp = br.ReadString().Split('\n');
				foreach (string ln in seekp) {
					FSeekPath.Add(ln);
				}
			} catch {
				FSeekPath.Clear();
				FSeekPath.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
			} finally {
				
			}
			return true;
		}		
		
		private Random rnd = new Random();
		public override System.Drawing.Image GetNextImage() {
			try {
				Console.WriteLine("GetNextImage enter");
				List<string> files = new List<string>();
				foreach (string d in FSeekPath) {
					DirectoryInfo di = new DirectoryInfo(d);
					foreach (FileInfo f in di.GetFiles()) {
					 	files.Add(f.FullName);	
					}
				}					
				return System.Drawing.Image.FromFile(files[rnd.Next(0, files.Count)]);
			} catch(Exception exc) {
				Console.WriteLine(exc);
				//todo: Kernel.log(exc);
				Bitmap bmp = new Bitmap(320, 200);
				Graphics g = Graphics.FromImage(bmp);
				g.Clear(System.Drawing.Color.Black);
				g.DrawString("NO FILES",
				             new System.Drawing.Font(FontFamily.GenericSerif, 25, GraphicsUnit.Pixel),
				             Brushes.Red, 5, 5);
				return bmp;	
			}
		}
		
		public override System.Drawing.Image GetImageFromSource(string source) {
			return null;
		}
	}	
	
	/*
	public class DirectorySourceExpandTagsControl : Gtk.Widget {
		private DirectorySource Source;
		public DirectorySourceExpandTagsControl(DirectorySource source) {
			Source = source;
			Init();
		}
		
		private ListBox SourcesList = new ListBox();
		private Panel ActToolBar = new Panel();
		private void Init() {		
			
			foreach (string l in Source.FSeekPath) {
				SourcesList.Items.Add(l);	
			}
			
			SourcesList.IntegralHeight = false;
			SourcesList.Dock = DockStyle.Fill;			
			Controls.Add(SourcesList);
			
			ActToolBar.Width = 75;
			ActToolBar.Dock = DockStyle.Right;
			
			Button btnAdd = new Button();
			btnAdd.Text = "Добавить";
			btnAdd.Click += delegate(object sender, EventArgs e) {
				string f = GetFolder("");
				if (f != "") {
					SourcesList.Items.Add(f);	
					UpdateSourceList();
				}
			};
			btnAdd.Dock = DockStyle.Top;
			
			Button btnEdit = new Button();
			btnEdit.Text = "Изменить";
			btnEdit.Click += delegate(object sender, EventArgs e) {
				if (SourcesList.SelectedItem == null) return;
				string f = GetFolder(SourcesList.SelectedItem.ToString());
				if (f != "") {
					SourcesList.Items[SourcesList.SelectedIndex] = f;
					UpdateSourceList();
				}
			};
			btnEdit.Dock = DockStyle.Top;
			
			Button btnDelete = new Button();
			btnDelete.Text = "Удалить";
			btnDelete.Click += delegate(object sender, EventArgs e) {
				if (SourcesList.SelectedItem == null) return;
				SourcesList.Items.RemoveAt(SourcesList.SelectedIndex);
				UpdateSourceList();
			};
			btnDelete.Dock = DockStyle.Top;
			
			ActToolBar.Controls.Add(btnDelete);
			ActToolBar.Controls.Add(btnEdit);
			ActToolBar.Controls.Add(btnAdd);
			
			Controls.Add(ActToolBar);
		}
		
		private void UpdateSourceList() {
			lock (Source) {
				Source.FSeekPath.Clear();
				foreach (string l in SourcesList.Items) {
					Source.FSeekPath.Add(l);	
				}
			}
		}
		
		private string GetFolder(string start) {
			if (start == "") {
				start = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);	
			}
			
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.SelectedPath = start;
			if (dlg.ShowDialog() == DialogResult.OK) {
				return dlg.SelectedPath;
			} else {
				return "";
			}
		}
	}
	*/
}
