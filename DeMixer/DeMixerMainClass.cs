using System;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using DeMixer.lib;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Runtime.InteropServices;
using System.Resources;
using System.Diagnostics;
using System.Threading;

namespace DeMixer {
        public class DeMixerMainClass : IDeMixerKernel {		
                [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
         public static extern int SystemParametersInfo(int uAction, int uParam, IntPtr lpvParam, int fuWinIni);
                
                public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINIFILE = 0x1;
        public const int SPIF_SENDWININICHANGE = 0x2;
                
    [STAThread]
    private static void Main(string[] args) {
            Gtk.Application.Init("demixer", ref args);
            DeMixerMainClass mainClass = new DeMixerMainClass();
            Gtk.Application.Run();
    }
    
    private Gtk.StatusIcon TrayIcon = new Gtk.StatusIcon();
    private System.Threading.Timer UpdateTimer = null;
    public DeMixerMainClass() {            
            TrayIcon.Activate += HandleActivate;
			TrayIcon.PopupMenu += (o, e) => {
				HandlePopupMenu();	
			};
				
            /*
            Application.ThreadException += delegate(object sender, System.Threading.ThreadExceptionEventArgs e) {
                    //AbortThread();
                    //WriteLog(e.Exception);                        
            };            
            */
            UpdatePlugins();                        
            ReadSettings();
            LoadDictionary("ru");
            /*      
            UpdateDialog udlg = new UpdateDialog(this);
            udlg.Width *= 2;
            udlg.StartPosition = FormStartPosition.CenterParent;
            udlg.ShowDialog();
            Application.Exit();
            return;
            
            /*
            
            if (UserRegistry.GetValue("firt", "true").ToString() == "true") {
                    ConfigMasterDlg dlg = new ConfigMasterDlg(this);                                
                    dlg.Icon = GetrayIcon("icon.ico");
                    dlg.ShowDialog();
                    UserRegistry.SetValue("firt", "false");
                    RefreshMemory();
            }
            */
            
            
            switch (UpdateIntervalMode) {
            case 0:
                    LastUpdateTick = DateTime.Now.AddMilliseconds(-UpdateInterval);
                    break;                          
            case 1:
                    LastUpdateTick = DateTime.Now;
                    break;
            case 2:
                    break;
            }
            
            //Application.ApplicationExit += HandleApplicationExit;
            
            TrayIcon.File = @"/usr/share/demixer/icon";            
            TrayIcon.Visible = true;        
            					
			UpdateTimer = new Timer(HandleTick);
			UpdateTimer.Change(0, 1000);
            
            RefreshMemory();			
        }


	    void HandleActivate(object sender, EventArgs e) {
			
		}		
        
        void HandleDoubleClick(object sender, EventArgs e) {
                
        }

        private bool FIsGenerateNewPhoto = false;
        protected bool IsGenerateNewPhoto {
                get { return FIsGenerateNewPhoto; }
                set {                           
                        FIsGenerateNewPhoto = value;
                        if (value) 
                                TrayIcon.File = @"/usr/share/demixer/iconu";
                        else
                                TrayIcon.File = @"/usr/share/demixer/icon";
                }
        }
        
        private DateTime LastUpdateTick = DateTime.Now;
		
        private void HandleTick(object state) {			
	        try {  
				Console.WriteLine(DateTime.Now);				
				Console.WriteLine(ActiveSource);
				return;
	            lock (NextProcessThreadSync) {					
	                if (IsGenerateNewPhoto) return;					
	                if (LastUpdateTick.AddMilliseconds(UpdateInterval) <= DateTime.Now) {
	                	//todo: Application.DoEvents();						
	                    StartThread();			
					}					
	            }
	        } catch(Exception exc) {
	                WriteLog(exc);
	        }
        }
        
        private System.Threading.Thread NextProcessThread;
        private object NextProcessThreadSync = new object();
        
        
        private void StartThread() {                    
	        lock (NextProcessThreadSync) {
	            //if (NextProcessThread != null) throw new Exception("DoNext() Thread already exists");                         
	            IsGenerateNewPhoto = true;
	            
	            NextProcessThread = new System.Threading.Thread(DoNext);
				NextProcessThread.Priority = ThreadPriority.BelowNormal;
	            NextProcessThread.Start();                        
	        }
        }
        
        private void AbortThread() {
                lock (NextProcessThreadSync) {
                        IsGenerateNewPhoto = false;                             
                        try { NextProcessThread.Abort(); } catch {}
                        NextProcessThread = null;
                        LastUpdateTick = LastUpdateTick.AddMinutes(5);
                        //todo: TrayIcon.BalloonTipIcon = ToolTipIcon.Info;
                        
                        //todo: NextMenuItem.Text = Translate("core.menu next");                                
                        LastUpdateTick = LastUpdateTick.AddMinutes(5);
                }
        }
        
        private void DoNext() {         
                try {
                        ActiveComposition.Source = ActiveSource;                                
                        System.Drawing.Image img = null;
                        switch (Environment.OSVersion.Platform) {
                        case PlatformID.Unix:
                                //todo:
                                //img = ActiveComposition.GetCompostion(1280, 1024);
                                //break;
                        case PlatformID.Win32Windows:
                        case PlatformID.Win32NT:
                        default:
                                img = ActiveComposition.GetCompostion(1280, 1024);
                                /*todo:
                                img = ActiveComposition.GetCompostion(
                                                                      SystemInformation.PrimaryMonitorSize.Width,
                                                                      SystemInformation.PrimaryMonitorSize.Height);
                                                                      */
                                break;
                        }                               
                        
                        #region сохраняем в png без эффектов
                        {       
                                string fName = GetUserFileName("courient.png");
                                img.Save(fName, ImageFormat.Png);
                                UserRegistry.SetValue("courient", fName);
                                //ведем историю
                                if (saveHistory) {
                                        string historyfName = String.Format("{1}{0}{2}.png",
                                                                            Path.DirectorySeparatorChar,
                                                                            SaveHistoryPath,
                                                                            DateTime.Now.ToString());
                                        try { 
                                                img.Save(historyfName, ImageFormat.Png); 
                                        } catch (Exception exc) {
                                                /*todo:
                                                TrayIcon.ShowBalloonTip(
                                                                        0,
                                                                        Translate("core.error"),
                                                                        Translate("core.error save file {0} in history error {1}", historyfName, exc.Message),
                                                                        ToolTipIcon.Error);
                                                                        */
                                                WriteLog(exc);
                                        }
                                }
                                #region сохраняем десять последних
                                /*
                                string fDir = String.Format("{1}{0}{2}{0}",
                                                            Path.DirectorySeparatorChar,
                                                            Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                                                            Application.ProductName);                                   
                                Directory.CreateDirectory(fDir);
                                */                                      
                                string fDir = GetUserFileName("last") + Path.DirectorySeparatorChar;
                                Directory.CreateDirectory(fDir);
                                for (int i=7; i>0; i--) {
                                        fName = String.Format("{0}{1}.png", fDir, i);
                                        string fNewName = String.Format("{0}{1}.png", fDir, i+1);
                                        try {
                                                try { File.Delete(fNewName); } catch  {}
                                                File.Move(fName, fNewName);     
                                        } catch(Exception exc) {
                                                
                                        }
                                }                                       
                                fName = String.Format("{0}{1}.png", fDir, 1);
                                File.Delete(fName);                                     
                                img.Save(fName, ImageFormat.Png);
                                
                                #endregion
                                
                        }
                        #endregion                                                      
                        ApplyEffectsAndSetAsWallpaper(img);                                                             
                        
                        if (UpdateInterval < 60*1000) UpdateInterval = 60*1000;                         
                        LastUpdateTick = DateTime.Now;
                        
                        UserRegistry.SetValue("LastTick", LastUpdateTick);
                        IsGenerateNewPhoto = false;
                        
                        //todo: TrayIcon.ContextMenu = GetMenu();
                        
                        lock (NextProcessThreadSync) {
                                IsGenerateNewPhoto = false;
                                NextProcessThread = null;                                       
                                //todo: NextMenuItem.Text = Translate("core.menu next");
                        }
                } catch(Exception exc) {
                                WriteLog(exc);
                                ShowNotify(
                                   Translate("core.error get_image"),
                                                Translate("core.error get_image from {0} error {1} repeat {2}",
                            ActiveSource.PluginTitle,
                            exc.Message,
                            5),
                                   true);                                       
                                IsGenerateNewPhoto = false;
                                //todo: NextMenuItem.Text = Translate("core.menu next");
                                LastUpdateTick = DateTime.Now.AddMilliseconds(-UpdateInterval).AddMinutes(5);
                                //todo: TrayIcon.ContextMenu = GetMenu();
                                AbortThread();
                }
                finally {
                        RefreshMemory();
                }
        }
        
        private void ApplyEffectsAndSetAsWallpaper(System.Drawing.Image img) {
                foreach (ImagePostEffect ef in ActiveEffects) {
                        img = ef.Execute(img);  
                }
                /*
                string fDir = String.Format("{1}{0}{2}",
                            Path.DirectorySeparatorChar,
                            Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                            Application.ProductName);
    
                */
                string fDir = GetUserFileName("");
                // BMP  
                Directory.CreateDirectory(fDir);                                
                string fName = String.Format("{1}{0}courient.bmp",
                                            Path.DirectorySeparatorChar,
                                            fDir);
                img.Save(fName, ImageFormat.Bmp);                                                               
                
                switch (Environment.OSVersion.Platform) {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:                           
                        SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, Marshal.StringToBSTR(fName), SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                        break;
                }       
        }
        
        public void UpdateEffectForLastWallpaper() {
                try {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(UserRegistry.GetValue("courient").ToString());
                        ApplyEffectsAndSetAsWallpaper(img);
                } catch {
                }
        }
        
        private void SaveSettings() {
                try {
                        string fileName = GetUserFileName("config");
                        FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                        try {
                                BinaryWriter bw = new BinaryWriter(fs, System.Text.Encoding.UTF8);
                                //SIGN

                                bw.Write(System.Text.Encoding.ASCII.GetBytes("dmcf"));
                                //VERSION                                       
                                byte[] ver = {1, 0};
                                bw.Write(ver);
                                //ActiveSource
                                bw.Write(ActiveSource.GetType().FullName);
                                //Active composition
                                bw.Write(ActiveComposition.GetType().FullName);                         
                                //Interval
                                bw.Write((Int32)UpdateInterval);                                                                                
                                bw.Write((Int32)UpdateIntervalMode);
                                //history
                                
                                bw.Write(SaveHistory);
                                
                                bw.Write((Int32)SaveHistorySize);
                                
                                bw.Write(SaveHistoryPath);
                        } catch(Exception exc) {
                                WriteLog(exc);
                        } finally {
                                fs.Close();     
                        }
                        
                        //Состояния источников
                        foreach (ImagesSource i in FSources) {
                                try {
                                        i.WriteSettings(this);
                                } catch(Exception exc) {
                                        WriteLog(exc);
                                }
                        }
                        
                        //Состояния композиций
                        foreach (ImagesComposition c in FCompositions) {
                                try {
                                        c.WriteSettings(this);
                                } catch(Exception exc) {
                                        WriteLog(exc);
                                }
                        }       
                        
                        #region effects
                        //Effects
                        fileName = GetUserFileName("effects");
                        fs = new FileStream(fileName, FileMode.OpenOrCreate);
                        try {
                                BinaryWriter bw = new BinaryWriter(fs, System.Text.Encoding.UTF8);
                                bw.Write((Int32)ActiveEffects.Length);
                                foreach (ImagePostEffect pe in FActiveEffects) {
                                        bw.Write(pe.GetType().FullName);
                                        pe.Save(bw);
                                }
                        } catch(Exception exc) {
                                WriteLog(exc);
                        }finally {
                                fs.Close();
                        }                               
                        #endregion
                                                
                } catch(Exception exc) {
                        WriteLog(exc);
                }
        }
        
        private void ReadSettings() {                   
                try {                                   
                        #region registry 
                        try {
                                object nTime = UserRegistry.GetValue("LastTick");                               
                                LastUpdateTick =
                                        nTime == null ?
                                                DateTime.Now : 
                                                        DateTime.Parse(nTime.ToString());                       
                        } catch(Exception exc) { WriteLog(exc); }
                        #endregion

                        #region config
                        try {
                                string fileName = GetUserFileName("config");
                                FileStream fs = new FileStream(fileName, FileMode.Open);
                                try {
                                        BinaryReader br = new BinaryReader(fs, System.Text.Encoding.UTF8);
                                        String sign = System.Text.Encoding.ASCII.GetString(br.ReadBytes(4));
                                        //SIGN
                                        if (sign != "dmcf") throw new Exception("bad config file");
                                        //VER
                                        byte[] ver = br.ReadBytes(2);
                                        //ActiveSource
                                        string activeSourceName = br.ReadString();
                                        int sIndex = GetSourceIndex(activeSourceName);
                                        //ActiveIndex
                                        string activeCompositionName = br.ReadString();
                                        int cIndex = GetCompositionIndex(activeCompositionName);                                                                                
                                        
                                        //Interval
                                        UpdateInterval = br.ReadInt32();
                                        UpdateIntervalMode = br.ReadInt32();
                                        
                                        ActiveSourceIndex = sIndex == -1 ? 0 : sIndex;
                                        ActiveCompositionIndex = cIndex == -1 ? 0 :  cIndex;                                    
                                        //History
                                        if (br.BaseStream.CanRead) SaveHistory = br.ReadBoolean();
                                        if (br.BaseStream.CanRead)SaveHistorySize = br.ReadInt32();
                                        if (br.BaseStream.CanRead)SaveHistoryPath = br.ReadString();
                                } finally {
                                        fs.Close();     
                                }
                        } catch (Exception exc) {
                                WriteLog(exc);  
                        }
                        #endregion                              
                        #region effects
                        //Effects
                        try {
                                string fileName = GetUserFileName("effects");
                                FileStream fs = new FileStream(fileName, FileMode.Open);
                                try {
                                        BinaryReader br = new BinaryReader(fs, System.Text.Encoding.UTF8);
                                        int effCount = br.ReadInt32();
                                        List<ImagePostEffect> effList = new List<ImagePostEffect>();
                                        for (int i=0; i<effCount; i++) {
                                                string peName = br.ReadString();
                                                ImagePostEffect pe = PostEffectByName(peName);
                                                if (pe == null) {
                                                        //todo: MessageBox.Show(Translate("core.error effect not found {0}", peName));
                                                        throw new Exception();
                                                }                                               
                                                pe.Load(br);
                                                effList.Add(pe);
                                        }
                                        ActiveEffects = effList.ToArray();
                                }finally {
                                        fs.Close();
                                }                               
                        } catch (Exception exc) {
                                WriteLog(exc);  
                        }
                        #endregion
                } catch(Exception exc) {WriteLog(exc);}
        }

        void HandleApplicationExit(object sender, EventArgs e) {
                try {
                        TrayIcon.Visible = false;
                } catch {}
                SaveSettings();                 
                try {
                        TrayIcon.Visible = false;       
                } catch {}
        }
        
        private bool FIsRunning = true;
        private DateTime FStopTime;
        
        //private MenuItem NextMenuItem;
        //private List<Image> FMenuImage = new List<Image>();
        /*private  ContextMenu GetMenu() {                      
                ContextMenu menu = new ContextMenu();
                NextMenuItem = new MenuItem();
                NextMenuItem.Text = Translate("core.menu next");
                NextMenuItem.Click += MenuNextClick;
                menu.MenuItems.Add(NextMenuItem);
                
                string startStopTitle = FIsRunning ? Translate("core.menu stop") : Translate("core.menu start");
                menu.MenuItems.Add(startStopTitle, MenuStartStopClick);
                #region profile menu
                MenuItem cbox = new MenuItem();
                cbox.Text = Translate("core.menu profiles");
                foreach (string s in GetProfileList()) {
                        MenuItem nmi = new MenuItem(s);
                        nmi.Click += delegate(object sender, EventArgs e) {
                                        try {
                                                MenuItem _mi = (MenuItem)sender;
                                                LoadConfig(_mi.Text);
                                        } catch {
                                        }
                                };
                        object aprofileo = UserRegistry.GetValue("SelectionProfile");
                        string aprofile = aprofileo == null ? "" : aprofileo.ToString();
                        nmi.Checked =  nmi.Text == aprofile;
                        cbox.MenuItems.Add(nmi);
                }
                
                #region предыдущие
                MenuItem cPreveous = new MenuItem();
                cPreveous.Text = Translate("core.menu last");
                {
                        string di = GetUserFileName("last", "");                     
                        int count = 0;
                        FMenuImage.Clear();
                        for (int i = 1; i<=8; i++) {
                                try {
                                        string fileName = String.Format("{0}{1}.png", di, i);
                                        FileStream fs = new FileStream(fileName, FileMode.Open);
                                        Image img;                                        
                                        try {
                                                img = Image.FromStream(fs);
                                        } finally {
                                                fs.Close();
                                        }
                                        int imgh = 100;
                                        int imgw = (int)((float)img.Width/img.Height*imgh);
                                        Image sImage = new Bitmap(imgw, imgh);
                                        Graphics g = Graphics.FromImage(sImage);
                                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                        g.DrawImage(img, new Rectangle(0, 0, imgw, imgh));
                                        FMenuImage.Add(sImage);
                                        
                                        MenuItem newm = new MenuItem(fileName);
                                        newm.OwnerDraw = true;
                                        newm.MeasureItem += delegate(object sender, MeasureItemEventArgs e) {
                                                e.ItemWidth = imgw + 4;
                                                e.ItemHeight = imgh + 4;
                                        };
                                        newm.DrawItem += delegate(object sender, DrawItemEventArgs e) {
                                                Image simg = FMenuImage[e.Index];
                                                e.DrawBackground();
                                                e.DrawFocusRectangle();
                                                
                                                int topInc = 0;
                                                if (e.State  == DrawItemState.Selected) {
                                                        e.Graphics.FillRectangle(
                                                                                 SystemBrushes.ControlDarkDark,
                                                                                 e.Bounds.Left+3,
                                                                                 e.Bounds.Top+3,
                                                                                 simg.Width, simg.Height);
                                                        topInc = -1;
                                                }
                                                e.Graphics.DrawImage(simg,
                                                                     e.Bounds.Left+3,
                                                                     e.Bounds.Top+3 + topInc);
                                        };                                              
                                        #region пункты меню для изобрежения
                                        newm.Tag = fileName;
                                        newm.Click += MenuUseImageClick;
                                                                                        
                                        #endregion                                              
                                        cPreveous.MenuItems.Add(newm);
                                        count++;
                                if (count>=10) break;
                                } catch {
                                        
                                }
                        }
                }
                menu.MenuItems.Add(cPreveous);
                #endregion
                
                menu.MenuItems.Add(cbox);
                #endregion                      
                menu.MenuItems.Add(Translate("core.menu config"), MenuConfigClick);
                menu.MenuItems.Add(Translate("core.menu about"), MenuAboutClick);
                menu.MenuItems.Add(Translate("core.menu exit"), MenuExitClick);
                return menu;
        }
        */
        
		void HandlePopupMenu() {
    		Gtk.Menu trayMenu = new Gtk.Menu();
			
			Gtk.ImageMenuItem miNext = new Gtk.ImageMenuItem("Next wallpaper");			
			miNext.Activated += (o, e) => {
				LastUpdateTick = DateTime.Now;	
			};
			
			Gtk.CheckMenuItem miEnable = new Gtk.CheckMenuItem("Enable");
			
			#region menu Previous
			Gdk.Pixbuf[] prev = getPreviousImages();
			Gtk.ImageMenuItem miLast = new Gtk.ImageMenuItem("Previous");
			if (prev.Length==0) {
				miLast.Sensitive = false;
			} else {
				miEnable.Submenu = new Gtk.Menu();
				foreach (Gdk.Pixbuf img in prev) {
					Gtk.ImageMenuItem pmi = new Gtk.ImageMenuItem("");					
					((Gtk.Menu)miEnable.Submenu).Append(pmi);
				}
			}
			#endregion			
			#region menu profiles
			string[] profiles = GetProfileList();			
			Gtk.ImageMenuItem miProfiles = new Gtk.ImageMenuItem("Profiles");
			if (profiles.Length == 0) {
				miProfiles.Sensitive = false;
			} else {
				miProfiles.Submenu = new Gtk.Menu();
				foreach (string pname in GetProfileList()) {
					Gtk.ImageMenuItem pmi = new Gtk.ImageMenuItem(pname);
					((Gtk.Menu)miProfiles.Submenu).Append(pmi);
				}
			}
			#endregion
			
			Gtk.ImageMenuItem miConfig = new Gtk.ImageMenuItem("Configuration");
			miConfig.Activated += (o, e) => {
				ConfigDlg dlg = new ConfigDlg(this);
				dlg.Modal = true;
				dlg.ShowAll();
			};
			
			Gtk.ImageMenuItem miAbout = new Gtk.ImageMenuItem("About");
			miAbout.Activated  += (o, e) => {
				AboutDialog dlg = new AboutDialog();
				dlg.Modal = true;
				dlg.ShowAll();
			};
			
			Gtk.MenuItem miExit = new Gtk.ImageMenuItem("Exit");
			miExit.Activated += (o, e) => {
				Gtk.Application.Quit();	
			};
			
			
			trayMenu.Append(miNext);
			trayMenu.Append(miEnable);
			trayMenu.Append(miLast);
			trayMenu.Append(miProfiles);
			trayMenu.Append(miConfig);
			trayMenu.Append(miAbout);
			trayMenu.Append(miExit);
			
			trayMenu.ShowAll();
			trayMenu.Popup();
    	}
		
		Gdk.Pixbuf[] getPreviousImages() {
			return new Gdk.Pixbuf[0];
		}
		
#region клик по изображению             
/*todo
void MenuUseImageClick(object sender, EventArgs e) {
        //todo: MenuItem mi = (MenuItem)sender;
        string iName = (String)mi.Tag;
        string cName = GetUserFileName("courient.png");                                                 
        //заменяем текущее изображение новым
        if (!File.Exists(iName)) {
                TrayIcon.ShowBalloonTip(15*1000,
                                        Translate("core.error"),
                                        Translate("core.error file not fountd {0}", iName),
                                        ToolTipIcon.Error);
                TrayIcon.ContextMenu = GetMenu();                                                               
                return;                                                         
        }
        File.Delete(cName);
        File.Move(iName, cName);
        //перемещаем оставшиеся
        string di = GetUserFileName("last", "");
        for (int fi=7; fi>=1; fi--) {
                string fn = String.Format("{0}{1}.png",di, fi);
                string fnl = String.Format("{0}{1}.png",di, fi+1);
                if (File.Exists(fn)) {
                        if (!File.Exists(fnl)) {
                            File.Move(fn, fnl);
                        }
                }
        }
        string fnfirst = String.Format("{0}{1}.png",di, 1);                                                     
        File.Copy(cName, fnfirst);
        
        UpdateEffectForLastWallpaper();
        LastUpdateTick = DateTime.Now;
        TrayIcon.ContextMenu = GetMenu();
}
*/
#endregion
        
#region события на меню
        private void MenuNextClick(object sender, EventArgs e) {
                lock(NextProcessThreadSync) {
                        if (FIsGenerateNewPhoto) 
                                AbortThread();
                        else
                                LastUpdateTick = DateTime.Now.AddMilliseconds(-UpdateInterval);
                }
        }
        
        private void MenuStartStopClick(object sender, EventArgs e) {
                FIsRunning = !FIsRunning;
                //todo: TrayIcon.ContextMenu = GetMenu();
                if (FIsRunning) {
                        //Запущено
                        LastUpdateTick = LastUpdateTick.Add(DateTime.Now - FStopTime);
                        TrayIcon.File = @"./icon.png";
                        //todo: UpdateTimer.Start();
                        
                } else {
                        //Остановлено
                        FStopTime = DateTime.Now;
                        //todo: UpdateTimer.Stop();
                        TrayIcon.File = @"./icond.ico";
                }
        }
        
        private void MenuConfigClick(object sender, EventArgs e) {
                /*todo
                ConfigDialog dlg = new ConfigDialog(this);
                dlg.Icon = GetrayIcon("icon.ico");
                dlg.StartPosition = FormStartPosition.CenterScreen;
                dlg.ShowDialog();
                SaveSettings();
                TrayIcon.ContextMenu = GetMenu();
                RefreshMemory();
                */
        }
        
        private void MenuAboutClick(object sender, EventArgs e) {
                /*todo
                AboutDlg dlg = new AboutDlg(this);
                dlg.Icon = GetrayIcon("icon.ico");
                dlg.ShowDialog();
                RefreshMemory();
                */
        }
        
        private void MenuExitClick(object sender, EventArgs e) {
                //todo
                Gtk.Application.Quit();
        }
        
        private ImagePostEffect PostEffectByName(string name) {
                foreach (ImagePostEffect pe in PostEffectsList) {
                        if (name == pe.GetType().FullName) return pe.GetClone();        
                }
                return null;
        }
#endregion

#region работа с плагинами
        private int FActiveSouceIndex;
        private List<ImagesSource> FSources = new List<ImagesSource>();
        private int FActiveCompositionIndex;
        private List<ImagesComposition> FCompositions = new List<ImagesComposition>();
        private List<ImagePostEffect> FEffects = new List<ImagePostEffect>();
        private void UpdatePlugins() {
                string dir = (new FileInfo(@"./")).Directory.FullName +
                        Path.DirectorySeparatorChar;
                foreach (FileInfo f in (new DirectoryInfo(dir)).GetFiles()) {					
                        SeekInAssembly(f.FullName);
                }
                
                foreach (FileInfo f in (new DirectoryInfo(GetUserFileName("plugins", ""))).GetFiles()) {
                        SeekInAssembly(f.FullName);
                }
        }
        
        public ImagesSource ActiveSource {
                get { return FSources[ActiveSourceIndex]; }
        }
        
        public ImagesComposition ActiveComposition {
                get { return FCompositions[ActiveCompositionIndex]; }
        }
        
	    public void SeekInAssembly(string filename) { 						
	        try {				
	            Assembly asm = Assembly.LoadFile(filename);				
	            foreach (Type t in asm.GetTypes()) {
                    try {
                        if (t.IsAbstract ) continue;
                        if (t.IsSubclassOf(typeof(ImagesSource))) {
                                ConstructorInfo constr = t.GetConstructor(new Type[0]);
                                ImagesSource newSource = (ImagesSource)(constr.Invoke(null));
                                newSource.Init(this);
                                FSources.Add(newSource);
                                newSource.ReadSettings(this);
                        }
                        if (t.IsSubclassOf(typeof(ImagesComposition))) {
                                ConstructorInfo constr = t.GetConstructor(new Type[0]);
                                ImagesComposition newComp = (ImagesComposition)(constr.Invoke(null));
                                newComp.Init(this);
                                FCompositions.Add(newComp);                                                     
                                newComp.ReadSettings(this);
                        }
                        if (t.IsSubclassOf(typeof(ImagePostEffect))) {
                                ConstructorInfo constr = t.GetConstructor(new Type[0]);
                                ImagePostEffect newEffect = (ImagePostEffect)(constr.Invoke(null));
                                newEffect.Init(this);
                                FEffects.Add(newEffect);
				}
	                    } catch { }
	            }
	        } catch { }			
		}
#endregion
                
                public static void RefreshMemory() { 
            try { 
                         Process curProc = Process.GetCurrentProcess(); 
                    curProc.MaxWorkingSet = curProc.MaxWorkingSet; 
            } catch { 
                // Handle the exception 
            } 
        } 
                
#region IDeMixerKernel
                public ImagesSource[] SourceList {
                        get { return FSources.ToArray(); } 
                }
                
                public ImagesComposition[] CompositionList {
                        get { return FCompositions.ToArray(); }
                }
                
                public ImagePostEffect[] PostEffectsList {
                        get { return FEffects.ToArray(); }
                }
                                
                private ImagePostEffect[] FActiveEffects = new ImagePostEffect[0];
                public ImagePostEffect[] ActiveEffects {
                        get { return FActiveEffects; }
                        set { 
                                lock(ActiveEffects) {
                                        FActiveEffects = value;
                                }
                        }
                }
                
                public int ActiveSourceIndex {
                        get { return FActiveSouceIndex; }
                        set { FActiveSouceIndex = value; }
                }
                
                public int ActiveCompositionIndex {
                        get { return FActiveCompositionIndex; }
                        set { FActiveCompositionIndex = value; }
                }
                
                #region Directoryes             
                public string AppDir {
                        get {
                                FileInfo fi = new FileInfo("./");
                                return fi.Directory.ToString() + Path.DirectorySeparatorChar;
                        }
                }
                
                public string GetAppFileName(params string[] args) {
                        string res = AppDir + string.Join(Path.DirectorySeparatorChar.ToString(), args);
                        try {
                                FileInfo fi = new FileInfo(res);
                                Directory.CreateDirectory(fi.Directory.FullName);
                        } catch { }                     
                        return res;
                }
                
                public string UserDir {
                        get { 
                                return "~/.config/demixer";
                                /*todo
                                string appDir = 
                                String.Format("{1}{0}{2}{0}{3}{0}",
                                              Path.DirectorySeparatorChar,
                                              Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                              Application.CompanyName,
                                                  Application.ProductName);
                                System.IO.Directory.CreateDirectory(appDir);
                                return appDir;
                                */
                        }
                }
                
                public string GetUserFileName(params string[] args) {           
                        string res = UserDir + string.Join(Path.DirectorySeparatorChar.ToString(), args);
                        FileInfo fi = new FileInfo(res);
                        Directory.CreateDirectory(fi.Directory.FullName);
                        return res;
                }
                
                
                public RegistryKey UserRegistry {
                        get {
                                return null;
                                /*
                                return
                                        Registry.CurrentUser.
                                                CreateSubKey("Software").
                                                CreateSubKey(Application.CompanyName);
                                                CreateSubKey(Application.ProductName);*/}
                }
                
                
                #endregion
                
                #region Profile
                public string[] GetProfileList() {
                        string dname = GetUserFileName("profiles", "");
                        List<string> ls = new List<string>();
                        foreach (FileInfo f in (new DirectoryInfo(dname).GetFiles())) {
                                ls.Add(f.Name);
                        }
                        return ls.ToArray();
                }
                public bool LoadConfig(string configName) {
                        string filename = GetUserFileName("profiles", configName);              
                        FileInfo fi = new FileInfo(filename);
                        if (!fi.Exists) {
                                //todo! MessageBox.Show(Translate("core.error profile not found"), Translate("core.error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                        }
                        try {
                                FileStream fs = new FileStream(filename, FileMode.Open);
                                BinaryReader br = new BinaryReader(fs, System.Text.Encoding.UTF8);
                                //SIGN
                                byte[] sign = br.ReadBytes(4);
                                if (System.Text.Encoding.ASCII.GetString(sign) != "dmxc") throw new Exception();                                
                                //имя плагина
                                string pluginClass = br.ReadString();
                                //имя сборки
                                string assemblyName = br.ReadString();
                                //загружаем сборку                              
                                int sourceIndex = GetSourceIndex(pluginClass);                          
                                if (sourceIndex == -1) throw new Exception();                           
                                ActiveSourceIndex = sourceIndex;                                
                                if (! ActiveSource.LoadConfig(fs)) throw new Exception();
                                
                                UserRegistry.SetValue("SelectionProfile", configName);
                                //todo TrayIcon.ContextMenu = GetMenu();
                                try {
                                        
                                } finally {
                                        fs.Close();
                                }
                        } catch(Exception exc) {
                                WriteLog(exc);
                                /*todo
                                if (MessageBox.Show(
                                                    Translate("core.error profile read error delete"),
                                                    Translate("core.error"),
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)                                                         
                                {
                                        fi.Delete();
                                }
                                */
                                RefreshMemory();
                        }
                        return true;
                }
                
                public bool SaveConfig(string configName) {
                        if (configName == "") {
                                //todo MessageBox.Show("Вы должны указать имя профиля", "Сохрание профиля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                        }
                        try {
                                string filename = GetUserFileName("profiles", configName);
                                if (File.Exists(filename)) {
                                        /*todo if (MessageBox.Show("Профиль уже существует, хотите заменить?",
                                                           "Замена профиля",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Question) != DialogResult.Yes) return false;
                                                           */
                                }
                                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                                try {
                                        try {                                           
                                                BinaryWriter bw = new BinaryWriter(fs, System.Text.Encoding.UTF8);
                                                //SIGN
                                                bw.Write(System.Text.Encoding.ASCII.GetBytes("dmxc"));
                                                //имя класса
                                                ImagesSource aSource = ActiveSource;
                                                bw.Write(aSource.GetType().FullName);
                                                //имя сборки
                                                bw.Write(aSource.GetType().Assembly.FullName);
                                                if (!aSource.SaveConfig(fs)) throw new Exception();
                                        } finally {
                                                fs.Close();
                                        }
                                } catch(Exception exc) {
                                        WriteLog(exc);
                                        File.Delete(filename);
                                        throw;  
                                }
                        } catch(Exception exc) {
                                WriteLog(exc);
                                //todo MessageBox.Show("Не удалсь сохранить профиль", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);                               
                        }
                        //todo TrayIcon.ContextMenu = GetMenu();
                        return true;
                }
                #endregion
                
                                
                
                public int GetSourceIndex(string name) {
                        int i = 0;
                        foreach (ImagesSource s in FSources) {
                                if (s.GetType().FullName == name) return i;
                                i++;
                        }
                        return -1;
                }
                
                public int GetCompositionIndex(string name) {
                        int i = 0;
                        foreach (ImagesComposition c in FCompositions) {
                                if (c.GetType().FullName == name) return i;
                                i++;
                        }                       
                        return -1;
                }
                
                bool saveHistory = false;
                public bool SaveHistory {
                        get { return saveHistory; }
                        set { saveHistory = value; }
                }
                
                string saveHistoryPath = "";
                public string SaveHistoryPath {
                        get { return saveHistoryPath; }
                        set { saveHistoryPath = value; }
                }
                
                int saveHistorySize;
                public int SaveHistorySize {
                        get { return saveHistorySize; }
                        set { saveHistorySize = value; }
                }
                
                private int FUpdateInterval;
                public int UpdateInterval {
                        get { return FUpdateInterval; }
                        set { FUpdateInterval = value; }
                }
                
                private int FUpdateIntervalMode = 0;
                public int UpdateIntervalMode {
                        get { return FUpdateIntervalMode; }
                        set { FUpdateIntervalMode = value; }
                }
                
                public TimeSpan TimeLeft {
                        get {
                                if (FIsRunning)
                                        return 
                                                LastUpdateTick.AddMilliseconds(UpdateInterval) - DateTime.Now;
                                else
                                        return
                                                LastUpdateTick.AddMilliseconds(UpdateInterval) - FStopTime;
                        }
                }
                
                public void WriteLog(object obj) {
                        WriteLog(obj.ToString());
                }
                
                public void WriteLog(string str) {
                        lock (this) {
                                string fname = GetUserFileName("log");
                                long fsize = 0;
                                FileStream fs = new FileStream(fname, FileMode.Append | FileMode.OpenOrCreate);                 
                                string ln = String.Format(
                                            "\n=={0}==\n{1}{2}",
                                            DateTime.Now.ToString(),
                                            str,
                                            Environment.NewLine);                               
                                byte[] buff = System.Text.Encoding.UTF8.GetBytes(ln);
                                fs.Write(buff, 0, buff.Length);
                                fsize = fs.Position;
                                
                                fs.Close();
                                
                                if (fsize > 1024*1024*5) {
                                        try { 
                                                File.Delete(GetUserFileName("log2"));
                                                File.Move(GetUserFileName("log1"), GetUserFileName("log2"));
                                        } catch {}
                                        try { 
                                                File.Delete(GetUserFileName("log1"));
                                                File.Move(fname, GetUserFileName("log1"));
                                        } catch {}
                                }
                        }
                }
                
                public string Language {
                        get { return "en English"; }
                        set { }
                }
                
                public string[] Languages {
                        get { return new string[]{"en English"}; }
                }
                
                void LoadDictionary(string locName) {
                        translateDict.Clear();
                        try {
                                DirectoryInfo alocDir= new DirectoryInfo(GetAppFileName("loc"));
                                searchLocInDir(alocDir, locName);
                        } catch {}
                        try {
                                DirectoryInfo ulocDir= new DirectoryInfo(GetUserFileName("loc"));
                                searchLocInDir(ulocDir, locName);
                        } catch {}
                }
                
                void searchLocInDir(DirectoryInfo locDir, string locName) {
                        foreach (FileInfo f in locDir.GetFiles(String.Format("*.{0}", locName))) {
                                FileStream fs = new FileStream(f.FullName, FileMode.Open);
                                try {
                                        StreamReader sr = new StreamReader(fs);
                                        string[] lines = sr.ReadToEnd().Split('\n');
                                        foreach(string ln in lines) {
                                                string[] args=ln.Split(new char[]{'='}, 2);
                                                if (args.Length==2) {                                                   
                                                        translateDict[args[0]] = args[1];       
                                                }
                                        }
                                } finally {
                                        fs.Close();
                                }
                        }
                }
                
                Dictionary<string, string> translateDict = new Dictionary<string, string>();
                public string Translate(string format, params object[] args) {                  
                        string formato;
                        if (translateDict.TryGetValue(format, out formato))
                                format = formato;
                        return String.Format(format, args).Replace("\\n", "\n").Replace("\\t", "\t");
                }
                
                public void ShowNotify(string title, string message, bool errorIcon) {
                        switch (Environment.OSVersion.Platform) {                                                               
                                case PlatformID.Win32Windows:
                                case PlatformID.Win32NT:                                
                                        /* todo
                                        TrayIcon.BalloonTipTitle = title;
                                        TrayIcon.BalloonTipText = message;
                                        TrayIcon.BalloonTipIcon = errorIcon ? ToolTipIcon.Error : ToolTipIcon.Info;
                                        TrayIcon.ShowBalloonTip(1000*15);
                                        */
                                        break;
                                case PlatformID.Unix:   
                                default:
                                        /*todo!
                                        (new System.Threading.Thread((System.Threading.ThreadStart)delegate {
                                                MessageBox.Show(
                                                message,
                                                String.Format("{0} - DeMixer", title),
                                                MessageBoxButtons.OK,
                                                errorIcon ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                                        })).Start();                                    
                                        */
                                        break;
                        }       
                }
        #endregion
        }
}
