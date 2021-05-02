using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CustomControl;
using theme_tool.Properties;
using theme_tool.resource;
using theme_tool.TMUtility;

namespace theme_tool
{
	public class MainForm : Form
	{
		private IContainer components;

		private TabControl tabControl;

		private TabPage startTab;

		private TabPage homeTab;

		private SplitContainer startSplitContainer;

		public PictureBox startImage;

		private MainMenu mainMenu1;

		private MenuItem FileMenu;

		private MenuItem menuItemNew;

		private MenuItem menuItemLoad;

		private MenuItem menuItemSave;

		private MenuItem menuItemSaveAs;

		private MenuItem menuItemSep0;

		private MenuItem menuItemExportDir;

		private MenuItem menuItemSep1;

		private MenuItem menuItemExit;

		private MenuItem AboutMenu;

		public PropertyGrid startPropertyGrid;

		private OpenFileDialog openFileDialog1;

		private SaveFileDialog saveFileDialog1;

		private FolderBrowserDialog folderBrowserDialog1;

		public TransparentPictureBox notificationFramePictureBox;

		public Label timeLabel;

		public Label dateLabel;

		public TransparentLabel notificationText1;

		public TransparentPictureBox notificationBgPictureBox;

		public Panel startPanel;

		public TransparentLabel barTimeLabel;

		public TransparentPictureBox startInfomationBarPictureBox;

		private TabPage tabPage1;

		private TabPage tabPage2;

		public TransparentLabel homeBatTimeLabel1;

		public TransparentPictureBox homeInfomationBarPictureBox1;

		public PictureBox homePictureBox1;

		private TabPage tabPage3;

		private TabPage tabPage4;

		private TabPage tabPage5;

		private TabPage tabPage6;

		private TabPage tabPage7;

		private TabPage tabPage8;

		private TabPage tabPage9;

		private TabPage tabPage10;

		public TabControl homeScreenTab;

		public TransparentPictureBox browserIcon;

		public TransparentPictureBox videoIcon;

		public TransparentPictureBox musicIcon;

		public TransparentPictureBox ps3LinkIcon;

		public TransparentPictureBox partyIcon;

		public TransparentPictureBox trophyIcon;

		public TransparentPictureBox nearIcon;

		public TransparentPictureBox hostCollaboIcon;

		public TransparentPictureBox welcomeParkIcon;

		public TransparentPictureBox ps4LinkIcon;

		public TransparentPictureBox friendIcon;

		public TransparentPictureBox emailIcon;

		public TransparentPictureBox calendarIcon;

		public TransparentPictureBox storeIcon;

		public TransparentPictureBox messageIcon;

		public TransparentPictureBox parentalIcon;

		public TransparentPictureBox cameraIcon;

		public TransparentPictureBox settingsIcon;

		public TransparentPictureBox powerIcon;

		private TabPage infomationTab;

		private PropertyGrid infoPropertyGrid;

		private MenuItem modeMenuItem;

		private MenuItem vitaModeItem;

		private MenuItem vitaTvModeItem;

		public Panel homePanel1;

		public SplitContainer splitContainer1;

		private SplitContainer splitContainer2;

		private FlowLayoutPanel flowLayoutPanel1;

		public PictureBox previewHomePictureBox;

		public PictureBox previewStartPictureBox;

		public PictureBox pkgPictureBox;

		private TransparentPictureBox startOvarlayPictureBox;

		public TransparentPictureBox notificationCalendarIcon;

		public TransparentPictureBox notificationEmailIcon;

		public TransparentPictureBox notificationMessageIcon;

		public TransparentLabel notificationText2;

		public TransparentLabel notificationText3;

		public TransparentPictureBox homeBgPictureBox1;

		public PropertyGrid homePropertyGrid;

		private MenuItem menuItemDevKit;

		private MenuItem menuItemDevKitPowerOn;

		private MenuItem menuItemDevKitPowerOff;

		private MenuItem menuItemDevKitReboot;

		private MenuItem pkgMenuItem;

		private MenuItem pkgNormalMenuItem;

		private MenuItem pkgVitaPreInstallMenuItem;

		private Timer timer1;

		public Label meridianLabel;

		public TransparentLabel barMeridianLabel;

		public TransparentLabel homeMeridianLabel;

		public TransparentLabel hostCollaboLabel;

		public TransparentLabel trophyLabel;

		public TransparentLabel nearLabel;

		public TransparentLabel welcomeParkLabel;

		public TransparentLabel partyLabel;

		public TransparentLabel ps3LinkLabel;

		public TransparentLabel videoLabel;

		public TransparentLabel emailLabel;

		public TransparentLabel friendLabel;

		public TransparentLabel messageLabel;

		public TransparentLabel calendarLabel;

		public TransparentLabel ps4LinkLabel;

		public TransparentLabel settingsLabel;

		public TransparentLabel powerLabel;

		public TransparentLabel parentalLabel;

		public TransparentLabel cameraLabel;

		public TransparentLabel storeLabel;

		public TransparentLabel browserLabel;

		public TransparentLabel musicLabel;

		public TransparentPictureBox indicatorBG0;

		public TransparentPictureBox indicatorBG1;

		public TransparentPictureBox indicatorBG4;

		public TransparentPictureBox indicatorBG3;

		public TransparentPictureBox indicatorBG2;

		public TransparentPictureBox indicatorBG5;

		public TransparentPictureBox indicatorBG6;

		public TransparentPictureBox indicatorBG7;

		public TransparentPictureBox indicatorBG8;

		public TransparentPictureBox indicatorBG9;

		public TransparentPictureBox indicatorGlow;

		public TransparentPictureBox newNoticeIcon;

		private MenuItem menuItem1;

		private MenuItem menuNewNotifyItem;

		private MenuItem menuNoneNotifyItem;

		public TransparentPictureBox glowNoticeIcon;

		public TransparentPictureBox noNoticeIcon;

		public TransparentLabel noticeLabel;

		public static MainForm m_mainForm = null;

		private static Bitmap m_maskBitmap = new Bitmap(Resources.Blue_Button_mask);

		public InfomationBarProperty m_infomationBar;

		public StartScreenProperty m_startScreen;

		public HomeProperty m_home;

		public InfomationProperty m_infoProperty;

		public Mode m_mode;

		public Package m_package;

		public Notify m_notify;

		public bool m_load;

		public bool m_refreshInvalid;

		public string m_dateString;

		public string m_timeString;

		public string m_meridianString;

		public readonly double m_scale = 1.0;

		public readonly float m_dpi = 96f;

		private bool m_edit;

		private string m_curFilename_ = "";

		private string m_curFilename
		{
			get
			{
				return m_curFilename_;
			}
			set
			{
				m_curFilename_ = value;
				if (0 < value.Length)
				{
					m_mainForm.Text = value + " - " + theme.appTitle;
				}
				else
				{
					m_mainForm.Text = theme.appTitle;
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(theme_tool.MainForm));
			startSplitContainer = new System.Windows.Forms.SplitContainer();
			startPropertyGrid = new System.Windows.Forms.PropertyGrid();
			startPanel = new System.Windows.Forms.Panel();
			startOvarlayPictureBox = new CustomControl.TransparentPictureBox();
			barTimeLabel = new CustomControl.TransparentLabel();
			barMeridianLabel = new CustomControl.TransparentLabel();
			startInfomationBarPictureBox = new CustomControl.TransparentPictureBox();
			notificationBgPictureBox = new CustomControl.TransparentPictureBox();
			notificationText1 = new CustomControl.TransparentLabel();
			notificationText2 = new CustomControl.TransparentLabel();
			notificationText3 = new CustomControl.TransparentLabel();
			timeLabel = new System.Windows.Forms.Label();
			meridianLabel = new System.Windows.Forms.Label();
			dateLabel = new System.Windows.Forms.Label();
			notificationFramePictureBox = new CustomControl.TransparentPictureBox();
			notificationCalendarIcon = new CustomControl.TransparentPictureBox();
			notificationEmailIcon = new CustomControl.TransparentPictureBox();
			notificationMessageIcon = new CustomControl.TransparentPictureBox();
			startImage = new System.Windows.Forms.PictureBox();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			musicLabel = new CustomControl.TransparentLabel();
			browserLabel = new CustomControl.TransparentLabel();
			storeLabel = new CustomControl.TransparentLabel();
			cameraLabel = new CustomControl.TransparentLabel();
			powerLabel = new CustomControl.TransparentLabel();
			settingsLabel = new CustomControl.TransparentLabel();
			parentalLabel = new CustomControl.TransparentLabel();
			ps4LinkLabel = new CustomControl.TransparentLabel();
			calendarLabel = new CustomControl.TransparentLabel();
			hostCollaboLabel = new CustomControl.TransparentLabel();
			trophyLabel = new CustomControl.TransparentLabel();
			nearLabel = new CustomControl.TransparentLabel();
			welcomeParkLabel = new CustomControl.TransparentLabel();
			partyLabel = new CustomControl.TransparentLabel();
			ps3LinkLabel = new CustomControl.TransparentLabel();
			videoLabel = new CustomControl.TransparentLabel();
			emailLabel = new CustomControl.TransparentLabel();
			friendLabel = new CustomControl.TransparentLabel();
			messageLabel = new CustomControl.TransparentLabel();
			homePropertyGrid = new System.Windows.Forms.PropertyGrid();
			hostCollaboIcon = new CustomControl.TransparentPictureBox();
			trophyIcon = new CustomControl.TransparentPictureBox();
			nearIcon = new CustomControl.TransparentPictureBox();
			welcomeParkIcon = new CustomControl.TransparentPictureBox();
			partyIcon = new CustomControl.TransparentPictureBox();
			ps3LinkIcon = new CustomControl.TransparentPictureBox();
			videoIcon = new CustomControl.TransparentPictureBox();
			emailIcon = new CustomControl.TransparentPictureBox();
			friendIcon = new CustomControl.TransparentPictureBox();
			messageIcon = new CustomControl.TransparentPictureBox();
			calendarIcon = new CustomControl.TransparentPictureBox();
			ps4LinkIcon = new CustomControl.TransparentPictureBox();
			settingsIcon = new CustomControl.TransparentPictureBox();
			parentalIcon = new CustomControl.TransparentPictureBox();
			powerIcon = new CustomControl.TransparentPictureBox();
			cameraIcon = new CustomControl.TransparentPictureBox();
			storeIcon = new CustomControl.TransparentPictureBox();
			browserIcon = new CustomControl.TransparentPictureBox();
			musicIcon = new CustomControl.TransparentPictureBox();
			homeScreenTab = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			homePanel1 = new System.Windows.Forms.Panel();
			noticeLabel = new CustomControl.TransparentLabel();
			glowNoticeIcon = new CustomControl.TransparentPictureBox();
			noNoticeIcon = new CustomControl.TransparentPictureBox();
			newNoticeIcon = new CustomControl.TransparentPictureBox();
			indicatorBG9 = new CustomControl.TransparentPictureBox();
			indicatorBG8 = new CustomControl.TransparentPictureBox();
			indicatorBG7 = new CustomControl.TransparentPictureBox();
			indicatorBG6 = new CustomControl.TransparentPictureBox();
			indicatorBG5 = new CustomControl.TransparentPictureBox();
			indicatorBG4 = new CustomControl.TransparentPictureBox();
			indicatorBG3 = new CustomControl.TransparentPictureBox();
			indicatorBG0 = new CustomControl.TransparentPictureBox();
			indicatorGlow = new CustomControl.TransparentPictureBox();
			indicatorBG1 = new CustomControl.TransparentPictureBox();
			indicatorBG2 = new CustomControl.TransparentPictureBox();
			homeMeridianLabel = new CustomControl.TransparentLabel();
			homeBatTimeLabel1 = new CustomControl.TransparentLabel();
			homeInfomationBarPictureBox1 = new CustomControl.TransparentPictureBox();
			homeBgPictureBox1 = new CustomControl.TransparentPictureBox();
			homePictureBox1 = new System.Windows.Forms.PictureBox();
			tabPage2 = new System.Windows.Forms.TabPage();
			tabPage3 = new System.Windows.Forms.TabPage();
			tabPage4 = new System.Windows.Forms.TabPage();
			tabPage5 = new System.Windows.Forms.TabPage();
			tabPage6 = new System.Windows.Forms.TabPage();
			tabPage7 = new System.Windows.Forms.TabPage();
			tabPage8 = new System.Windows.Forms.TabPage();
			tabPage9 = new System.Windows.Forms.TabPage();
			tabPage10 = new System.Windows.Forms.TabPage();
			tabControl = new System.Windows.Forms.TabControl();
			startTab = new System.Windows.Forms.TabPage();
			homeTab = new System.Windows.Forms.TabPage();
			infomationTab = new System.Windows.Forms.TabPage();
			splitContainer2 = new System.Windows.Forms.SplitContainer();
			infoPropertyGrid = new System.Windows.Forms.PropertyGrid();
			flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			previewHomePictureBox = new System.Windows.Forms.PictureBox();
			previewStartPictureBox = new System.Windows.Forms.PictureBox();
			pkgPictureBox = new System.Windows.Forms.PictureBox();
			mainMenu1 = new System.Windows.Forms.MainMenu(components);
			FileMenu = new System.Windows.Forms.MenuItem();
			menuItemNew = new System.Windows.Forms.MenuItem();
			menuItemLoad = new System.Windows.Forms.MenuItem();
			menuItemSave = new System.Windows.Forms.MenuItem();
			menuItemSaveAs = new System.Windows.Forms.MenuItem();
			menuItemSep0 = new System.Windows.Forms.MenuItem();
			menuItemExportDir = new System.Windows.Forms.MenuItem();
			menuItemSep1 = new System.Windows.Forms.MenuItem();
			menuItemExit = new System.Windows.Forms.MenuItem();
			menuItemDevKit = new System.Windows.Forms.MenuItem();
			menuItemDevKitPowerOn = new System.Windows.Forms.MenuItem();
			menuItemDevKitPowerOff = new System.Windows.Forms.MenuItem();
			menuItemDevKitReboot = new System.Windows.Forms.MenuItem();
			modeMenuItem = new System.Windows.Forms.MenuItem();
			vitaModeItem = new System.Windows.Forms.MenuItem();
			vitaTvModeItem = new System.Windows.Forms.MenuItem();
			pkgMenuItem = new System.Windows.Forms.MenuItem();
			pkgNormalMenuItem = new System.Windows.Forms.MenuItem();
			pkgVitaPreInstallMenuItem = new System.Windows.Forms.MenuItem();
			menuItem1 = new System.Windows.Forms.MenuItem();
			menuNewNotifyItem = new System.Windows.Forms.MenuItem();
			menuNoneNotifyItem = new System.Windows.Forms.MenuItem();
			AboutMenu = new System.Windows.Forms.MenuItem();
			openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			timer1 = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)startSplitContainer).BeginInit();
			startSplitContainer.Panel1.SuspendLayout();
			startSplitContainer.Panel2.SuspendLayout();
			startSplitContainer.SuspendLayout();
			startPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)startOvarlayPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)startInfomationBarPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)notificationBgPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)notificationFramePictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)notificationCalendarIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)notificationEmailIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)notificationMessageIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)startImage).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)hostCollaboIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)trophyIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)nearIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)welcomeParkIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)partyIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)ps3LinkIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)videoIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)emailIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)friendIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)messageIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)calendarIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)ps4LinkIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)settingsIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)parentalIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)powerIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)cameraIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)storeIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)browserIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)musicIcon).BeginInit();
			homeScreenTab.SuspendLayout();
			tabPage1.SuspendLayout();
			homePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)glowNoticeIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)noNoticeIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)newNoticeIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG9).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG8).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG7).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG6).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG5).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG4).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG3).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG0).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorGlow).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG1).BeginInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG2).BeginInit();
			((System.ComponentModel.ISupportInitialize)homeInfomationBarPictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)homeBgPictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)homePictureBox1).BeginInit();
			tabControl.SuspendLayout();
			startTab.SuspendLayout();
			homeTab.SuspendLayout();
			infomationTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)previewHomePictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)previewStartPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)pkgPictureBox).BeginInit();
			SuspendLayout();
			startSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(startSplitContainer, "startSplitContainer");
			startSplitContainer.Name = "startSplitContainer";
			startSplitContainer.Panel1.Controls.Add(startPropertyGrid);
			resources.ApplyResources(startSplitContainer.Panel2, "startSplitContainer.Panel2");
			startSplitContainer.Panel2.Controls.Add(startPanel);
			resources.ApplyResources(startPropertyGrid, "startPropertyGrid");
			startPropertyGrid.Name = "startPropertyGrid";
			startPropertyGrid.ToolbarVisible = false;
			startPropertyGrid.Click += new System.EventHandler(startPropertyGrid_Click);
			startPanel.Controls.Add(startOvarlayPictureBox);
			startPanel.Controls.Add(barTimeLabel);
			startPanel.Controls.Add(barMeridianLabel);
			startPanel.Controls.Add(startInfomationBarPictureBox);
			startPanel.Controls.Add(notificationBgPictureBox);
			startPanel.Controls.Add(notificationText1);
			startPanel.Controls.Add(notificationText2);
			startPanel.Controls.Add(notificationText3);
			startPanel.Controls.Add(timeLabel);
			startPanel.Controls.Add(meridianLabel);
			startPanel.Controls.Add(dateLabel);
			startPanel.Controls.Add(notificationFramePictureBox);
			startPanel.Controls.Add(notificationCalendarIcon);
			startPanel.Controls.Add(notificationEmailIcon);
			startPanel.Controls.Add(notificationMessageIcon);
			startPanel.Controls.Add(startImage);
			resources.ApplyResources(startPanel, "startPanel");
			startPanel.Name = "startPanel";
			startOvarlayPictureBox.BackgroundImage = theme_tool.Properties.Resources.startscreen_ovarlay;
			resources.ApplyResources(startOvarlayPictureBox, "startOvarlayPictureBox");
			startOvarlayPictureBox.Name = "startOvarlayPictureBox";
			startOvarlayPictureBox.TabStop = false;
			resources.ApplyResources(barTimeLabel, "barTimeLabel");
			barTimeLabel.ForeColor = System.Drawing.Color.White;
			barTimeLabel.Name = "barTimeLabel";
			barTimeLabel.Tag = "AM";
			resources.ApplyResources(barMeridianLabel, "barMeridianLabel");
			barMeridianLabel.ForeColor = System.Drawing.Color.White;
			barMeridianLabel.Name = "barMeridianLabel";
			startInfomationBarPictureBox.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(startInfomationBarPictureBox, "startInfomationBarPictureBox");
			startInfomationBarPictureBox.Name = "startInfomationBarPictureBox";
			startInfomationBarPictureBox.TabStop = false;
			notificationBgPictureBox.BackColor = System.Drawing.Color.Transparent;
			notificationBgPictureBox.Image = theme_tool.Properties.Resources.notifacationbg;
			resources.ApplyResources(notificationBgPictureBox, "notificationBgPictureBox");
			notificationBgPictureBox.Name = "notificationBgPictureBox";
			notificationBgPictureBox.TabStop = false;
			resources.ApplyResources(notificationText1, "notificationText1");
			notificationText1.Name = "notificationText1";
			resources.ApplyResources(notificationText2, "notificationText2");
			notificationText2.Name = "notificationText2";
			resources.ApplyResources(notificationText3, "notificationText3");
			notificationText3.Name = "notificationText3";
			resources.ApplyResources(timeLabel, "timeLabel");
			timeLabel.BackColor = System.Drawing.Color.Transparent;
			timeLabel.Name = "timeLabel";
			resources.ApplyResources(meridianLabel, "meridianLabel");
			meridianLabel.Name = "meridianLabel";
			resources.ApplyResources(dateLabel, "dateLabel");
			dateLabel.BackColor = System.Drawing.Color.Transparent;
			dateLabel.Name = "dateLabel";
			notificationFramePictureBox.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(notificationFramePictureBox, "notificationFramePictureBox");
			notificationFramePictureBox.Image = theme_tool.Properties.Resources.notifacationborder;
			notificationFramePictureBox.Name = "notificationFramePictureBox";
			notificationFramePictureBox.TabStop = false;
			resources.ApplyResources(notificationCalendarIcon, "notificationCalendarIcon");
			notificationCalendarIcon.Image = theme_tool.Properties.Resources.appicn_Calendar;
			notificationCalendarIcon.Name = "notificationCalendarIcon";
			notificationCalendarIcon.TabStop = false;
			resources.ApplyResources(notificationEmailIcon, "notificationEmailIcon");
			notificationEmailIcon.Image = theme_tool.Properties.Resources.appicn_Email;
			notificationEmailIcon.Name = "notificationEmailIcon";
			notificationEmailIcon.TabStop = false;
			notificationMessageIcon.Image = theme_tool.Properties.Resources.appicn_Messages;
			resources.ApplyResources(notificationMessageIcon, "notificationMessageIcon");
			notificationMessageIcon.Name = "notificationMessageIcon";
			notificationMessageIcon.TabStop = false;
			startImage.BackColor = System.Drawing.Color.Transparent;
			startImage.BackgroundImage = theme_tool.Properties.Resources.startscreen_bg;
			resources.ApplyResources(startImage, "startImage");
			startImage.Name = "startImage";
			startImage.TabStop = false;
			startImage.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(startImage_LoadCompleted);
			startImage.Click += new System.EventHandler(startImage_Click);
			resources.ApplyResources(splitContainer1, "splitContainer1");
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Panel1.Controls.Add(musicLabel);
			splitContainer1.Panel1.Controls.Add(browserLabel);
			splitContainer1.Panel1.Controls.Add(storeLabel);
			splitContainer1.Panel1.Controls.Add(cameraLabel);
			splitContainer1.Panel1.Controls.Add(powerLabel);
			splitContainer1.Panel1.Controls.Add(settingsLabel);
			splitContainer1.Panel1.Controls.Add(parentalLabel);
			splitContainer1.Panel1.Controls.Add(ps4LinkLabel);
			splitContainer1.Panel1.Controls.Add(calendarLabel);
			splitContainer1.Panel1.Controls.Add(hostCollaboLabel);
			splitContainer1.Panel1.Controls.Add(trophyLabel);
			splitContainer1.Panel1.Controls.Add(nearLabel);
			splitContainer1.Panel1.Controls.Add(welcomeParkLabel);
			splitContainer1.Panel1.Controls.Add(partyLabel);
			splitContainer1.Panel1.Controls.Add(ps3LinkLabel);
			splitContainer1.Panel1.Controls.Add(videoLabel);
			splitContainer1.Panel1.Controls.Add(emailLabel);
			splitContainer1.Panel1.Controls.Add(friendLabel);
			splitContainer1.Panel1.Controls.Add(messageLabel);
			splitContainer1.Panel1.Controls.Add(homePropertyGrid);
			resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
			splitContainer1.Panel2.Controls.Add(hostCollaboIcon);
			splitContainer1.Panel2.Controls.Add(trophyIcon);
			splitContainer1.Panel2.Controls.Add(nearIcon);
			splitContainer1.Panel2.Controls.Add(welcomeParkIcon);
			splitContainer1.Panel2.Controls.Add(partyIcon);
			splitContainer1.Panel2.Controls.Add(ps3LinkIcon);
			splitContainer1.Panel2.Controls.Add(videoIcon);
			splitContainer1.Panel2.Controls.Add(emailIcon);
			splitContainer1.Panel2.Controls.Add(friendIcon);
			splitContainer1.Panel2.Controls.Add(messageIcon);
			splitContainer1.Panel2.Controls.Add(calendarIcon);
			splitContainer1.Panel2.Controls.Add(ps4LinkIcon);
			splitContainer1.Panel2.Controls.Add(settingsIcon);
			splitContainer1.Panel2.Controls.Add(parentalIcon);
			splitContainer1.Panel2.Controls.Add(powerIcon);
			splitContainer1.Panel2.Controls.Add(cameraIcon);
			splitContainer1.Panel2.Controls.Add(storeIcon);
			splitContainer1.Panel2.Controls.Add(browserIcon);
			splitContainer1.Panel2.Controls.Add(musicIcon);
			splitContainer1.Panel2.Controls.Add(homeScreenTab);
			resources.ApplyResources(musicLabel, "musicLabel");
			musicLabel.ForeColor = System.Drawing.Color.White;
			musicLabel.Name = "musicLabel";
			resources.ApplyResources(browserLabel, "browserLabel");
			browserLabel.ForeColor = System.Drawing.Color.White;
			browserLabel.Name = "browserLabel";
			resources.ApplyResources(storeLabel, "storeLabel");
			storeLabel.ForeColor = System.Drawing.Color.White;
			storeLabel.Name = "storeLabel";
			resources.ApplyResources(cameraLabel, "cameraLabel");
			cameraLabel.ForeColor = System.Drawing.Color.White;
			cameraLabel.Name = "cameraLabel";
			resources.ApplyResources(powerLabel, "powerLabel");
			powerLabel.ForeColor = System.Drawing.Color.White;
			powerLabel.Name = "powerLabel";
			resources.ApplyResources(settingsLabel, "settingsLabel");
			settingsLabel.ForeColor = System.Drawing.Color.White;
			settingsLabel.Name = "settingsLabel";
			resources.ApplyResources(parentalLabel, "parentalLabel");
			parentalLabel.ForeColor = System.Drawing.Color.White;
			parentalLabel.Name = "parentalLabel";
			resources.ApplyResources(ps4LinkLabel, "ps4LinkLabel");
			ps4LinkLabel.ForeColor = System.Drawing.Color.White;
			ps4LinkLabel.Name = "ps4LinkLabel";
			resources.ApplyResources(calendarLabel, "calendarLabel");
			calendarLabel.ForeColor = System.Drawing.Color.White;
			calendarLabel.Name = "calendarLabel";
			resources.ApplyResources(hostCollaboLabel, "hostCollaboLabel");
			hostCollaboLabel.ForeColor = System.Drawing.Color.White;
			hostCollaboLabel.Name = "hostCollaboLabel";
			resources.ApplyResources(trophyLabel, "trophyLabel");
			trophyLabel.ForeColor = System.Drawing.Color.White;
			trophyLabel.Name = "trophyLabel";
			resources.ApplyResources(nearLabel, "nearLabel");
			nearLabel.ForeColor = System.Drawing.Color.White;
			nearLabel.Name = "nearLabel";
			resources.ApplyResources(welcomeParkLabel, "welcomeParkLabel");
			welcomeParkLabel.ForeColor = System.Drawing.Color.White;
			welcomeParkLabel.Name = "welcomeParkLabel";
			resources.ApplyResources(partyLabel, "partyLabel");
			partyLabel.ForeColor = System.Drawing.Color.White;
			partyLabel.Name = "partyLabel";
			resources.ApplyResources(ps3LinkLabel, "ps3LinkLabel");
			ps3LinkLabel.ForeColor = System.Drawing.Color.White;
			ps3LinkLabel.Name = "ps3LinkLabel";
			resources.ApplyResources(videoLabel, "videoLabel");
			videoLabel.ForeColor = System.Drawing.Color.White;
			videoLabel.Name = "videoLabel";
			resources.ApplyResources(emailLabel, "emailLabel");
			emailLabel.ForeColor = System.Drawing.Color.White;
			emailLabel.Name = "emailLabel";
			resources.ApplyResources(friendLabel, "friendLabel");
			friendLabel.ForeColor = System.Drawing.Color.White;
			friendLabel.Name = "friendLabel";
			resources.ApplyResources(messageLabel, "messageLabel");
			messageLabel.ForeColor = System.Drawing.Color.White;
			messageLabel.Name = "messageLabel";
			resources.ApplyResources(homePropertyGrid, "homePropertyGrid");
			homePropertyGrid.Name = "homePropertyGrid";
			homePropertyGrid.ToolbarVisible = false;
			homePropertyGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(homePropertyGrid_SelectedGridItemChanged);
			resources.ApplyResources(hostCollaboIcon, "hostCollaboIcon");
			hostCollaboIcon.InitialImage = theme_tool.Properties.Resources.appicn_ContentManager;
			hostCollaboIcon.Name = "hostCollaboIcon";
			hostCollaboIcon.TabStop = false;
			resources.ApplyResources(trophyIcon, "trophyIcon");
			trophyIcon.InitialImage = theme_tool.Properties.Resources.appicn_Trophies;
			trophyIcon.Name = "trophyIcon";
			trophyIcon.TabStop = false;
			resources.ApplyResources(nearIcon, "nearIcon");
			nearIcon.InitialImage = theme_tool.Properties.Resources.appicn_near;
			nearIcon.Name = "nearIcon";
			nearIcon.TabStop = false;
			resources.ApplyResources(welcomeParkIcon, "welcomeParkIcon");
			welcomeParkIcon.InitialImage = theme_tool.Properties.Resources.appicn_WelcomePark;
			welcomeParkIcon.Name = "welcomeParkIcon";
			welcomeParkIcon.TabStop = false;
			resources.ApplyResources(partyIcon, "partyIcon");
			partyIcon.InitialImage = theme_tool.Properties.Resources.appicn_Party;
			partyIcon.Name = "partyIcon";
			partyIcon.TabStop = false;
			resources.ApplyResources(ps3LinkIcon, "ps3LinkIcon");
			ps3LinkIcon.InitialImage = theme_tool.Properties.Resources.appicn_RemotePlay;
			ps3LinkIcon.Name = "ps3LinkIcon";
			ps3LinkIcon.TabStop = false;
			resources.ApplyResources(videoIcon, "videoIcon");
			videoIcon.InitialImage = theme_tool.Properties.Resources.appicn_Videos;
			videoIcon.Name = "videoIcon";
			videoIcon.TabStop = false;
			resources.ApplyResources(emailIcon, "emailIcon");
			emailIcon.InitialImage = theme_tool.Properties.Resources.appicn_Email;
			emailIcon.Name = "emailIcon";
			emailIcon.TabStop = false;
			resources.ApplyResources(friendIcon, "friendIcon");
			friendIcon.InitialImage = theme_tool.Properties.Resources.appicn_Friends;
			friendIcon.Name = "friendIcon";
			friendIcon.TabStop = false;
			resources.ApplyResources(messageIcon, "messageIcon");
			messageIcon.InitialImage = theme_tool.Properties.Resources.appicn_Messages;
			messageIcon.Name = "messageIcon";
			messageIcon.TabStop = false;
			resources.ApplyResources(calendarIcon, "calendarIcon");
			calendarIcon.InitialImage = theme_tool.Properties.Resources.appicn_Calendar;
			calendarIcon.Name = "calendarIcon";
			calendarIcon.TabStop = false;
			resources.ApplyResources(ps4LinkIcon, "ps4LinkIcon");
			ps4LinkIcon.InitialImage = theme_tool.Properties.Resources.appicn_PS4Link;
			ps4LinkIcon.Name = "ps4LinkIcon";
			ps4LinkIcon.TabStop = false;
			resources.ApplyResources(settingsIcon, "settingsIcon");
			settingsIcon.InitialImage = theme_tool.Properties.Resources.appicn_Settings;
			settingsIcon.Name = "settingsIcon";
			settingsIcon.TabStop = false;
			resources.ApplyResources(parentalIcon, "parentalIcon");
			parentalIcon.InitialImage = theme_tool.Properties.Resources.appicn_ParentalControl;
			parentalIcon.Name = "parentalIcon";
			parentalIcon.TabStop = false;
			resources.ApplyResources(powerIcon, "powerIcon");
			powerIcon.InitialImage = theme_tool.Properties.Resources.appicn_power;
			powerIcon.Name = "powerIcon";
			powerIcon.TabStop = false;
			resources.ApplyResources(cameraIcon, "cameraIcon");
			cameraIcon.InitialImage = theme_tool.Properties.Resources.appicn_Photos;
			cameraIcon.Name = "cameraIcon";
			cameraIcon.TabStop = false;
			resources.ApplyResources(storeIcon, "storeIcon");
			storeIcon.InitialImage = theme_tool.Properties.Resources.appicn_PSStore;
			storeIcon.Name = "storeIcon";
			storeIcon.TabStop = false;
			resources.ApplyResources(browserIcon, "browserIcon");
			browserIcon.InitialImage = theme_tool.Properties.Resources.appicn_Browser;
			browserIcon.Name = "browserIcon";
			browserIcon.TabStop = false;
			resources.ApplyResources(musicIcon, "musicIcon");
			musicIcon.InitialImage = theme_tool.Properties.Resources.appicn_Music;
			musicIcon.Name = "musicIcon";
			musicIcon.TabStop = false;
			homeScreenTab.Controls.Add(tabPage1);
			homeScreenTab.Controls.Add(tabPage2);
			homeScreenTab.Controls.Add(tabPage3);
			homeScreenTab.Controls.Add(tabPage4);
			homeScreenTab.Controls.Add(tabPage5);
			homeScreenTab.Controls.Add(tabPage6);
			homeScreenTab.Controls.Add(tabPage7);
			homeScreenTab.Controls.Add(tabPage8);
			homeScreenTab.Controls.Add(tabPage9);
			homeScreenTab.Controls.Add(tabPage10);
			resources.ApplyResources(homeScreenTab, "homeScreenTab");
			homeScreenTab.Multiline = true;
			homeScreenTab.Name = "homeScreenTab";
			homeScreenTab.SelectedIndex = 0;
			homeScreenTab.Selected += new System.Windows.Forms.TabControlEventHandler(homeScreenTab_Selected);
			tabPage1.Controls.Add(homePanel1);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			homePanel1.Controls.Add(noticeLabel);
			homePanel1.Controls.Add(glowNoticeIcon);
			homePanel1.Controls.Add(noNoticeIcon);
			homePanel1.Controls.Add(newNoticeIcon);
			homePanel1.Controls.Add(indicatorBG9);
			homePanel1.Controls.Add(indicatorBG8);
			homePanel1.Controls.Add(indicatorBG7);
			homePanel1.Controls.Add(indicatorBG6);
			homePanel1.Controls.Add(indicatorBG5);
			homePanel1.Controls.Add(indicatorBG4);
			homePanel1.Controls.Add(indicatorBG3);
			homePanel1.Controls.Add(indicatorBG0);
			homePanel1.Controls.Add(indicatorGlow);
			homePanel1.Controls.Add(indicatorBG1);
			homePanel1.Controls.Add(indicatorBG2);
			homePanel1.Controls.Add(homeMeridianLabel);
			homePanel1.Controls.Add(homeBatTimeLabel1);
			homePanel1.Controls.Add(homeInfomationBarPictureBox1);
			homePanel1.Controls.Add(homeBgPictureBox1);
			homePanel1.Controls.Add(homePictureBox1);
			resources.ApplyResources(homePanel1, "homePanel1");
			homePanel1.Name = "homePanel1";
			resources.ApplyResources(noticeLabel, "noticeLabel");
			noticeLabel.ForeColor = System.Drawing.Color.White;
			noticeLabel.Name = "noticeLabel";
			glowNoticeIcon.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(glowNoticeIcon, "glowNoticeIcon");
			glowNoticeIcon.InitialImage = theme_tool.Properties.Resources.Blue_Button_glow_white;
			glowNoticeIcon.Name = "glowNoticeIcon";
			glowNoticeIcon.TabStop = false;
			resources.ApplyResources(noNoticeIcon, "noNoticeIcon");
			noNoticeIcon.InitialImage = theme_tool.Properties.Resources.News_BTN_None;
			noNoticeIcon.Name = "noNoticeIcon";
			noNoticeIcon.TabStop = false;
			resources.ApplyResources(newNoticeIcon, "newNoticeIcon");
			newNoticeIcon.InitialImage = theme_tool.Properties.Resources.News_BTN_On;
			newNoticeIcon.Name = "newNoticeIcon";
			newNoticeIcon.TabStop = false;
			resources.ApplyResources(indicatorBG9, "indicatorBG9");
			indicatorBG9.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG9.Name = "indicatorBG9";
			indicatorBG9.TabStop = false;
			resources.ApplyResources(indicatorBG8, "indicatorBG8");
			indicatorBG8.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG8.Name = "indicatorBG8";
			indicatorBG8.TabStop = false;
			resources.ApplyResources(indicatorBG7, "indicatorBG7");
			indicatorBG7.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG7.Name = "indicatorBG7";
			indicatorBG7.TabStop = false;
			resources.ApplyResources(indicatorBG6, "indicatorBG6");
			indicatorBG6.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG6.Name = "indicatorBG6";
			indicatorBG6.TabStop = false;
			resources.ApplyResources(indicatorBG5, "indicatorBG5");
			indicatorBG5.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG5.Name = "indicatorBG5";
			indicatorBG5.TabStop = false;
			resources.ApplyResources(indicatorBG4, "indicatorBG4");
			indicatorBG4.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG4.Name = "indicatorBG4";
			indicatorBG4.TabStop = false;
			resources.ApplyResources(indicatorBG3, "indicatorBG3");
			indicatorBG3.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG3.Name = "indicatorBG3";
			indicatorBG3.TabStop = false;
			resources.ApplyResources(indicatorBG0, "indicatorBG0");
			indicatorBG0.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG0.Name = "indicatorBG0";
			indicatorBG0.TabStop = false;
			resources.ApplyResources(indicatorGlow, "indicatorGlow");
			indicatorGlow.InitialImage = theme_tool.Properties.Resources.tab_indicator_glow;
			indicatorGlow.Name = "indicatorGlow";
			indicatorGlow.TabStop = false;
			resources.ApplyResources(indicatorBG1, "indicatorBG1");
			indicatorBG1.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG1.Name = "indicatorBG1";
			indicatorBG1.TabStop = false;
			resources.ApplyResources(indicatorBG2, "indicatorBG2");
			indicatorBG2.InitialImage = theme_tool.Properties.Resources.tab_indicator_bg;
			indicatorBG2.Name = "indicatorBG2";
			indicatorBG2.TabStop = false;
			resources.ApplyResources(homeMeridianLabel, "homeMeridianLabel");
			homeMeridianLabel.Name = "homeMeridianLabel";
			resources.ApplyResources(homeBatTimeLabel1, "homeBatTimeLabel1");
			homeBatTimeLabel1.ForeColor = System.Drawing.Color.White;
			homeBatTimeLabel1.Name = "homeBatTimeLabel1";
			homeInfomationBarPictureBox1.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(homeInfomationBarPictureBox1, "homeInfomationBarPictureBox1");
			homeInfomationBarPictureBox1.Name = "homeInfomationBarPictureBox1";
			homeInfomationBarPictureBox1.TabStop = false;
			homeBgPictureBox1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(homeBgPictureBox1, "homeBgPictureBox1");
			homeBgPictureBox1.Name = "homeBgPictureBox1";
			homeBgPictureBox1.TabStop = false;
			homePictureBox1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(homePictureBox1, "homePictureBox1");
			homePictureBox1.Name = "homePictureBox1";
			homePictureBox1.TabStop = false;
			resources.ApplyResources(tabPage2, "tabPage2");
			tabPage2.Name = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage3, "tabPage3");
			tabPage3.Name = "tabPage3";
			tabPage3.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage4, "tabPage4");
			tabPage4.Name = "tabPage4";
			tabPage4.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage5, "tabPage5");
			tabPage5.Name = "tabPage5";
			tabPage5.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage6, "tabPage6");
			tabPage6.Name = "tabPage6";
			tabPage6.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage7, "tabPage7");
			tabPage7.Name = "tabPage7";
			tabPage7.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage8, "tabPage8");
			tabPage8.Name = "tabPage8";
			tabPage8.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage9, "tabPage9");
			tabPage9.Name = "tabPage9";
			tabPage9.UseVisualStyleBackColor = true;
			resources.ApplyResources(tabPage10, "tabPage10");
			tabPage10.Name = "tabPage10";
			tabPage10.UseVisualStyleBackColor = true;
			tabControl.Controls.Add(startTab);
			tabControl.Controls.Add(homeTab);
			tabControl.Controls.Add(infomationTab);
			resources.ApplyResources(tabControl, "tabControl");
			tabControl.Multiline = true;
			tabControl.Name = "tabControl";
			tabControl.SelectedIndex = 0;
			startTab.Controls.Add(startSplitContainer);
			resources.ApplyResources(startTab, "startTab");
			startTab.Name = "startTab";
			startTab.UseVisualStyleBackColor = true;
			homeTab.Controls.Add(splitContainer1);
			resources.ApplyResources(homeTab, "homeTab");
			homeTab.Name = "homeTab";
			homeTab.UseVisualStyleBackColor = true;
			infomationTab.Controls.Add(splitContainer2);
			resources.ApplyResources(infomationTab, "infomationTab");
			infomationTab.Name = "infomationTab";
			infomationTab.UseVisualStyleBackColor = true;
			resources.ApplyResources(splitContainer2, "splitContainer2");
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Panel1.Controls.Add(infoPropertyGrid);
			splitContainer2.Panel2.Controls.Add(flowLayoutPanel1);
			resources.ApplyResources(infoPropertyGrid, "infoPropertyGrid");
			infoPropertyGrid.Name = "infoPropertyGrid";
			infoPropertyGrid.ToolbarVisible = false;
			flowLayoutPanel1.Controls.Add(previewHomePictureBox);
			flowLayoutPanel1.Controls.Add(previewStartPictureBox);
			flowLayoutPanel1.Controls.Add(pkgPictureBox);
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			previewHomePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(previewHomePictureBox, "previewHomePictureBox");
			previewHomePictureBox.Name = "previewHomePictureBox";
			previewHomePictureBox.TabStop = false;
			previewStartPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(previewStartPictureBox, "previewStartPictureBox");
			previewStartPictureBox.Name = "previewStartPictureBox";
			previewStartPictureBox.TabStop = false;
			pkgPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(pkgPictureBox, "pkgPictureBox");
			pkgPictureBox.Name = "pkgPictureBox";
			pkgPictureBox.TabStop = false;
			mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[6] { FileMenu, menuItemDevKit, modeMenuItem, pkgMenuItem, menuItem1, AboutMenu });
			FileMenu.Index = 0;
			FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[8] { menuItemNew, menuItemLoad, menuItemSave, menuItemSaveAs, menuItemSep0, menuItemExportDir, menuItemSep1, menuItemExit });
			resources.ApplyResources(FileMenu, "FileMenu");
			menuItemNew.Index = 0;
			resources.ApplyResources(menuItemNew, "menuItemNew");
			menuItemNew.Click += new System.EventHandler(menuItemNew_Click);
			menuItemLoad.Index = 1;
			resources.ApplyResources(menuItemLoad, "menuItemLoad");
			menuItemLoad.Click += new System.EventHandler(menuItemOpen_Click);
			menuItemSave.Index = 2;
			resources.ApplyResources(menuItemSave, "menuItemSave");
			menuItemSave.Click += new System.EventHandler(menuItemSave_Click);
			menuItemSaveAs.Index = 3;
			resources.ApplyResources(menuItemSaveAs, "menuItemSaveAs");
			menuItemSaveAs.Click += new System.EventHandler(menuItemSaveAs_Click);
			menuItemSep0.Index = 4;
			resources.ApplyResources(menuItemSep0, "menuItemSep0");
			menuItemExportDir.Index = 5;
			resources.ApplyResources(menuItemExportDir, "menuItemExportDir");
			menuItemExportDir.Click += new System.EventHandler(menuItemExportDir_Click);
			menuItemSep1.Index = 6;
			resources.ApplyResources(menuItemSep1, "menuItemSep1");
			menuItemExit.Index = 7;
			resources.ApplyResources(menuItemExit, "menuItemExit");
			menuItemExit.Click += new System.EventHandler(menuItemExit_Click);
			menuItemDevKit.Index = 1;
			menuItemDevKit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[3] { menuItemDevKitPowerOn, menuItemDevKitPowerOff, menuItemDevKitReboot });
			resources.ApplyResources(menuItemDevKit, "menuItemDevKit");
			menuItemDevKitPowerOn.Index = 0;
			resources.ApplyResources(menuItemDevKitPowerOn, "menuItemDevKitPowerOn");
			menuItemDevKitPowerOn.Click += new System.EventHandler(menuItemDevKitPowerOn_Click);
			menuItemDevKitPowerOff.Index = 1;
			resources.ApplyResources(menuItemDevKitPowerOff, "menuItemDevKitPowerOff");
			menuItemDevKitPowerOff.Click += new System.EventHandler(menuItemDevKitPowerOff_Click);
			menuItemDevKitReboot.Index = 2;
			resources.ApplyResources(menuItemDevKitReboot, "menuItemDevKitReboot");
			menuItemDevKitReboot.Click += new System.EventHandler(menuItemDevKitReboot_Click);
			modeMenuItem.Index = 2;
			modeMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[2] { vitaModeItem, vitaTvModeItem });
			resources.ApplyResources(modeMenuItem, "modeMenuItem");
			vitaModeItem.Checked = true;
			vitaModeItem.Index = 0;
			resources.ApplyResources(vitaModeItem, "vitaModeItem");
			vitaModeItem.Click += new System.EventHandler(vitaModeItem_Click);
			vitaTvModeItem.Index = 1;
			resources.ApplyResources(vitaTvModeItem, "vitaTvModeItem");
			vitaTvModeItem.Click += new System.EventHandler(vitaTvModeItem_Click);
			pkgMenuItem.Index = 3;
			pkgMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[2] { pkgNormalMenuItem, pkgVitaPreInstallMenuItem });
			resources.ApplyResources(pkgMenuItem, "pkgMenuItem");
			pkgNormalMenuItem.Checked = true;
			pkgNormalMenuItem.Index = 0;
			resources.ApplyResources(pkgNormalMenuItem, "pkgNormalMenuItem");
			pkgNormalMenuItem.Click += new System.EventHandler(pkgNormal_Click);
			pkgVitaPreInstallMenuItem.Index = 1;
			resources.ApplyResources(pkgVitaPreInstallMenuItem, "pkgVitaPreInstallMenuItem");
			pkgVitaPreInstallMenuItem.Click += new System.EventHandler(pkgVitaPreIntall_Click);
			menuItem1.Index = 4;
			menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[2] { menuNewNotifyItem, menuNoneNotifyItem });
			resources.ApplyResources(menuItem1, "menuItem1");
			menuNewNotifyItem.Checked = true;
			menuNewNotifyItem.Index = 0;
			resources.ApplyResources(menuNewNotifyItem, "menuNewNotifyItem");
			menuNewNotifyItem.Click += new System.EventHandler(menuNewNotifyItem_Click);
			menuNoneNotifyItem.Index = 1;
			resources.ApplyResources(menuNoneNotifyItem, "menuNoneNotifyItem");
			menuNoneNotifyItem.Click += new System.EventHandler(menuNoneNotifyItem_Click);
			AboutMenu.Index = 5;
			resources.ApplyResources(AboutMenu, "AboutMenu");
			AboutMenu.Click += new System.EventHandler(AboutMenu_Click);
			openFileDialog1.DefaultExt = "tpj";
			resources.ApplyResources(openFileDialog1, "openFileDialog1");
			saveFileDialog1.DefaultExt = "tpj";
			resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
			timer1.Enabled = true;
			timer1.Interval = 1000;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			BackColor = System.Drawing.SystemColors.Control;
			BackgroundImage = theme_tool.Properties.Resources.icon_mask;
			base.Controls.Add(tabControl);
			base.Menu = mainMenu1;
			base.Name = "MainForm";
			base.Load += new System.EventHandler(MainForm_Load);
			startSplitContainer.Panel1.ResumeLayout(false);
			startSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)startSplitContainer).EndInit();
			startSplitContainer.ResumeLayout(false);
			startPanel.ResumeLayout(false);
			startPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)startOvarlayPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)startInfomationBarPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)notificationBgPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)notificationFramePictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)notificationCalendarIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)notificationEmailIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)notificationMessageIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)startImage).EndInit();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)hostCollaboIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)trophyIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)nearIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)welcomeParkIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)partyIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)ps3LinkIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)videoIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)emailIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)friendIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)messageIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)calendarIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)ps4LinkIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)settingsIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)parentalIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)powerIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)cameraIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)storeIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)browserIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)musicIcon).EndInit();
			homeScreenTab.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			homePanel1.ResumeLayout(false);
			homePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)glowNoticeIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)noNoticeIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)newNoticeIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG9).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG8).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG7).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG6).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG5).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG4).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG3).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG0).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorGlow).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG1).EndInit();
			((System.ComponentModel.ISupportInitialize)indicatorBG2).EndInit();
			((System.ComponentModel.ISupportInitialize)homeInfomationBarPictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)homeBgPictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)homePictureBox1).EndInit();
			tabControl.ResumeLayout(false);
			startTab.ResumeLayout(false);
			homeTab.ResumeLayout(false);
			infomationTab.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)previewHomePictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)previewStartPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)pkgPictureBox).EndInit();
			ResumeLayout(false);
		}

		public MainForm()
		{
			m_mainForm = this;
			InitializeComponent();
			m_scale = (double)homePictureBox1.Size.Width / 960.0;
			Graphics graphics = Graphics.FromHwnd(base.Handle);
			m_dpi = graphics.DpiX;
			graphics.Dispose();
			barMeridianLabel.Parent = startInfomationBarPictureBox;
			barTimeLabel.Parent = startInfomationBarPictureBox;
			startOvarlayPictureBox.Parent = startImage;
			notificationFramePictureBox.Parent = startOvarlayPictureBox;
			notificationBgPictureBox.Parent = startOvarlayPictureBox;
			dateLabel.Parent = startOvarlayPictureBox;
			meridianLabel.Parent = startOvarlayPictureBox;
			timeLabel.Parent = startOvarlayPictureBox;
			notificationText1.Parent = notificationFramePictureBox;
			notificationText2.Parent = notificationFramePictureBox;
			notificationText3.Parent = notificationFramePictureBox;
			notificationCalendarIcon.Parent = notificationFramePictureBox;
			notificationEmailIcon.Parent = notificationFramePictureBox;
			notificationMessageIcon.Parent = notificationFramePictureBox;
			notificationFramePictureBox.m_normal = false;
			homeMeridianLabel.Parent = homeInfomationBarPictureBox1;
			homeBatTimeLabel1.Parent = homeInfomationBarPictureBox1;
			noticeLabel.Parent = newNoticeIcon;
			newNoticeIcon.m_normal = false;
			newNoticeIcon.Parent = homePictureBox1.Parent;
			noNoticeIcon.m_normal = false;
			noNoticeIcon.Parent = homePictureBox1.Parent;
			noNoticeIcon.Hide();
			glowNoticeIcon.m_normal = false;
			glowNoticeIcon.Parent = newNoticeIcon;
			newNoticeIcon.LoadCompleted += notifyLoadCompleted;
			noNoticeIcon.LoadCompleted += notifyLoadCompleted;
			indicatorGlow.m_normal = false;
			indicatorGlow.Parent = homeBgPictureBox1;
			indicatorBG0.Parent = homeBgPictureBox1;
			indicatorBG1.Parent = homeBgPictureBox1;
			indicatorBG2.Parent = homeBgPictureBox1;
			indicatorBG3.Parent = homeBgPictureBox1;
			indicatorBG4.Parent = homeBgPictureBox1;
			indicatorBG5.Parent = homeBgPictureBox1;
			indicatorBG6.Parent = homeBgPictureBox1;
			indicatorBG7.Parent = homeBgPictureBox1;
			indicatorBG8.Parent = homeBgPictureBox1;
			indicatorBG9.Parent = homeBgPictureBox1;
			indicatorBG0.Hide();
			homeBgPictureBox1.Parent = homePictureBox1;
			homeBgPictureBox1.LoadCompleted += notifyRefreshCB;
			homePictureBox1.LoadCompleted += notifyRefreshCB;
			updateDateTimeString();
			resetObject();
		}

		public void setEdit()
		{
			m_edit = true;
		}

		private void resetObject()
		{
			m_infomationBar = new InfomationBarProperty();
			m_startScreen = new StartScreenProperty();
			m_home = new HomeProperty();
			m_infoProperty = new InfomationProperty();
			m_infomationBar.m_barColor = Color.Black;
			m_infomationBar.m_indicatorColor = Color.White;
			m_infomationBar.m_noticeFontColor = Color.White;
			m_infomationBar.m_noticeGlowColor = Color.FromArgb(255, 56, 182, 255);
			startPropertyGrid.SelectedObject = m_startScreen;
			homePropertyGrid.SelectedObject = m_home;
			infoPropertyGrid.SelectedObject = m_infoProperty;
			setIndicatorBG(null);
			setIndicatorGlow(null);
			setNewNoticeIcon(null);
			setNoNoticeIcon(null);
			resetHomePanel();
			m_home.m_bgParam[homeScreenTab.SelectedIndex].setPanel();
			m_curFilename = "";
			m_edit = false;
		}

		private void tabPage1_Click(object sender, EventArgs e)
		{
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void startPropertyGrid_Click(object sender, EventArgs e)
		{
		}

		private void menuItemNew_Click(object sender, EventArgs e)
		{
			if (chkEditData())
			{
				Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
				resetObject();
			}
		}

		private void menuItemOpen_Click(object sender, EventArgs e)
		{
			if (chkEditData())
			{
				DialogResult dialogResult = openFileDialog1.ShowDialog();
				if (dialogResult == DialogResult.OK && openFileDialog1.FileName.Length != 0)
				{
					Directory.GetCurrentDirectory();
					resetObject();
					Directory.SetCurrentDirectory(Path.GetDirectoryName(openFileDialog1.FileName));
					m_load = true;
					m_refreshInvalid = true;
					XmlDataManager.load(openFileDialog1.FileName);
					m_refreshInvalid = false;
					m_load = false;
					startPropertyGrid.Refresh();
					homePropertyGrid.Refresh();
					infoPropertyGrid.Refresh();
					m_curFilename = openFileDialog1.FileName;
					m_edit = false;
				}
			}
		}

		private void menuItemSave_Click(object sender, EventArgs e)
		{
			Directory.GetCurrentDirectory();
			m_refreshInvalid = true;
			if (0 < m_curFilename.Length)
			{
				string extension = Path.GetExtension(m_curFilename);
				if (".tpj" == extension)
				{
					XmlDataManager.save(m_curFilename);
				}
				else
				{
					saveAsProject();
				}
			}
			else
			{
				saveAsProject();
			}
			m_refreshInvalid = false;
			startPropertyGrid.Refresh();
			homePropertyGrid.Refresh();
			infoPropertyGrid.Refresh();
		}

		private void menuItemSaveAs_Click(object sender, EventArgs e)
		{
			saveAsProject();
			startPropertyGrid.Refresh();
			homePropertyGrid.Refresh();
			infoPropertyGrid.Refresh();
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
		}

		private void saveAsProject()
		{
			DialogResult dialogResult = saveFileDialog1.ShowDialog();
			if (dialogResult == DialogResult.OK && saveFileDialog1.FileName.Length != 0)
			{
				XmlDataManager.save(saveFileDialog1.FileName);
				m_curFilename = saveFileDialog1.FileName;
				Directory.SetCurrentDirectory(Path.GetDirectoryName(m_curFilename));
			}
		}

		private void startImage_Click(object sender, EventArgs e)
		{
		}

		private void menuItemExportDir_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
			if (dialogResult != DialogResult.OK || folderBrowserDialog1.SelectedPath.Length == 0)
			{
				return;
			}
			if (File.Exists(folderBrowserDialog1.SelectedPath + Path.DirectorySeparatorChar + "theme.xml"))
			{
				DialogResult dialogResult2 = MessageBox.Show(Resources.MSG_XML_OVERWRITE, "ExportDir", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
				if (DialogResult.Cancel == dialogResult2)
				{
					return;
				}
			}
			XmlDataManager.exportDir(folderBrowserDialog1.SelectedPath);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		public void resetHomePanel()
		{
			browserIcon.Parent = splitContainer1.Panel2;
			videoIcon.Parent = splitContainer1.Panel2;
			musicIcon.Parent = splitContainer1.Panel2;
			ps3LinkIcon.Parent = splitContainer1.Panel2;
			partyIcon.Parent = splitContainer1.Panel2;
			trophyIcon.Parent = splitContainer1.Panel2;
			nearIcon.Parent = splitContainer1.Panel2;
			hostCollaboIcon.Parent = splitContainer1.Panel2;
			welcomeParkIcon.Parent = splitContainer1.Panel2;
			ps4LinkIcon.Parent = splitContainer1.Panel2;
			friendIcon.Parent = splitContainer1.Panel2;
			emailIcon.Parent = splitContainer1.Panel2;
			calendarIcon.Parent = splitContainer1.Panel2;
			storeIcon.Parent = splitContainer1.Panel2;
			messageIcon.Parent = splitContainer1.Panel2;
			parentalIcon.Parent = splitContainer1.Panel2;
			cameraIcon.Parent = splitContainer1.Panel2;
			settingsIcon.Parent = splitContainer1.Panel2;
			powerIcon.Parent = splitContainer1.Panel2;
			browserIcon.Hide();
			videoIcon.Hide();
			musicIcon.Hide();
			ps3LinkIcon.Hide();
			partyIcon.Hide();
			trophyIcon.Hide();
			nearIcon.Hide();
			hostCollaboIcon.Hide();
			welcomeParkIcon.Hide();
			ps4LinkIcon.Hide();
			friendIcon.Hide();
			emailIcon.Hide();
			calendarIcon.Hide();
			storeIcon.Hide();
			messageIcon.Hide();
			parentalIcon.Hide();
			cameraIcon.Hide();
			settingsIcon.Hide();
			powerIcon.Hide();
			browserLabel.Parent = splitContainer1.Panel2;
			videoLabel.Parent = splitContainer1.Panel2;
			musicLabel.Parent = splitContainer1.Panel2;
			ps3LinkLabel.Parent = splitContainer1.Panel2;
			partyLabel.Parent = splitContainer1.Panel2;
			trophyLabel.Parent = splitContainer1.Panel2;
			nearLabel.Parent = splitContainer1.Panel2;
			hostCollaboLabel.Parent = splitContainer1.Panel2;
			welcomeParkLabel.Parent = splitContainer1.Panel2;
			ps4LinkLabel.Parent = splitContainer1.Panel2;
			friendLabel.Parent = splitContainer1.Panel2;
			emailLabel.Parent = splitContainer1.Panel2;
			calendarLabel.Parent = splitContainer1.Panel2;
			storeLabel.Parent = splitContainer1.Panel2;
			messageLabel.Parent = splitContainer1.Panel2;
			parentalLabel.Parent = splitContainer1.Panel2;
			cameraLabel.Parent = splitContainer1.Panel2;
			settingsLabel.Parent = splitContainer1.Panel2;
			powerLabel.Parent = splitContainer1.Panel2;
			browserLabel.Hide();
			videoLabel.Hide();
			musicLabel.Hide();
			ps3LinkLabel.Hide();
			partyLabel.Hide();
			trophyLabel.Hide();
			nearLabel.Hide();
			hostCollaboLabel.Hide();
			welcomeParkLabel.Hide();
			ps4LinkLabel.Hide();
			friendLabel.Hide();
			emailLabel.Hide();
			calendarLabel.Hide();
			storeLabel.Hide();
			messageLabel.Hide();
			parentalLabel.Hide();
			cameraLabel.Hide();
			settingsLabel.Hide();
			powerLabel.Hide();
		}

		private void homeScreenTab_Selected(object sender, TabControlEventArgs e)
		{
			resetHomePanel();
			m_home.m_bgParam[e.TabPageIndex].setPanel();
			Point location = new Point(indicatorGlow.Location.X, 158 + 22 * e.TabPageIndex);
			indicatorGlow.Location = location;
			indicatorBG0.Show();
			indicatorBG1.Show();
			indicatorBG2.Show();
			indicatorBG3.Show();
			indicatorBG4.Show();
			indicatorBG5.Show();
			indicatorBG6.Show();
			indicatorBG7.Show();
			indicatorBG8.Show();
			indicatorBG9.Show();
			if (e.TabPageIndex == 0)
			{
				indicatorBG0.Hide();
			}
			else if (1 == e.TabPageIndex)
			{
				indicatorBG1.Hide();
			}
			else if (2 == e.TabPageIndex)
			{
				indicatorBG2.Hide();
			}
			else if (3 == e.TabPageIndex)
			{
				indicatorBG3.Hide();
			}
			else if (4 == e.TabPageIndex)
			{
				indicatorBG4.Hide();
			}
			else if (5 == e.TabPageIndex)
			{
				indicatorBG5.Hide();
			}
			else if (6 == e.TabPageIndex)
			{
				indicatorBG6.Hide();
			}
			else if (7 == e.TabPageIndex)
			{
				indicatorBG7.Hide();
			}
			else if (8 == e.TabPageIndex)
			{
				indicatorBG8.Hide();
			}
			else if (9 == e.TabPageIndex)
			{
				indicatorBG9.Hide();
			}
			m_mainForm.homeBgPictureBox1.ImageLocation = m_home.m_bgParam[e.TabPageIndex].m_imageFilePath;
			m_mainForm.homePictureBox1.Image = m_home.m_bgParam[e.TabPageIndex].getWaveImage();
			homePanel1.Parent = e.TabPage;
		}

		private void homePropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
		{
			if (e.NewSelection != null && e.NewSelection.Value != null)
			{
				BackgroundParam backgroundParam = null;
				if (e.NewSelection.Value.GetType().Equals(typeof(BackgroundParam)))
				{
					backgroundParam = (BackgroundParam)e.NewSelection.Value;
				}
				else if (e.NewSelection.Parent != null && e.NewSelection.Parent.Value != null && e.NewSelection.Parent.Value.GetType().Equals(typeof(BackgroundParam)))
				{
					backgroundParam = (BackgroundParam)e.NewSelection.Parent.Value;
				}
				if (backgroundParam != null)
				{
					homeScreenTab.SelectedIndex = backgroundParam.m_paramIdx;
				}
			}
		}

		private void changeModeNormalPkg()
		{
			m_home.resetLayout();
			m_home.m_bgParam[homeScreenTab.SelectedIndex].setPanel();
		}

		private void changeModeVita(bool bLoad = false)
		{
			m_mode = Mode.Vita;
			vitaModeItem.Checked = true;
			vitaTvModeItem.Checked = false;
			m_home.resetLayout(bLoad);
			m_home.m_bgParam[homeScreenTab.SelectedIndex].setPanel();
		}

		private void changeModeVitaTv()
		{
			m_mode = Mode.VitaTV;
			vitaModeItem.Checked = false;
			vitaTvModeItem.Checked = true;
			m_home.resetLayout();
			m_home.m_bgParam[homeScreenTab.SelectedIndex].setPanel();
		}

		private void vitaModeItem_Click(object sender, EventArgs e)
		{
			changeModeVita();
		}

		private void vitaTvModeItem_Click(object sender, EventArgs e)
		{
			changeModeVitaTv();
		}

		public void setBackHomePictureBox()
		{
			m_mainForm.homePictureBox1.Parent = null;
			m_mainForm.homePictureBox1.Parent = m_mainForm.homePanel1;
		}

		private void AboutMenu_Click(object sender, EventArgs e)
		{
			AboutBox aboutBox = new AboutBox();
			aboutBox.ShowDialog();
		}

		private void menuItemDevKitReboot_Click(object sender, EventArgs e)
		{
			psp2ctrl.Reboot();
		}

		private void menuItemDevKitPowerOn_Click(object sender, EventArgs e)
		{
			psp2ctrl.PowerOn();
		}

		private void menuItemDevKitPowerOff_Click(object sender, EventArgs e)
		{
			psp2ctrl.PowerOff();
		}

		public void UpdateMenu_DevKit()
		{
			if (psp2ctrl.IsPowerOn())
			{
				menuItemDevKitPowerOn.Enabled = false;
				menuItemDevKitPowerOff.Enabled = true;
				menuItemDevKitReboot.Enabled = true;
			}
			else if (psp2ctrl.IsPowerOff())
			{
				menuItemDevKitPowerOn.Enabled = true;
				menuItemDevKitPowerOff.Enabled = false;
				menuItemDevKitReboot.Enabled = false;
			}
		}

		public void Enable_menuItemDevkit()
		{
			menuItemDevKit.Enabled = true;
		}

		public void Disable_menuItemDevkit()
		{
			menuItemDevKit.Enabled = false;
		}

		private void pkgNormal_Click(object sender, EventArgs e)
		{
			changePkg(Package.Normal);
		}

		private void pkgVitaPreIntall_Click(object sender, EventArgs e)
		{
			changePkg(Package.VitaPreInstall);
		}

		public void changePkg(Package pkg, bool bLoad = false)
		{
			setEdit();
			if (pkg == Package.Normal)
			{
				m_package = Package.Normal;
				pkgNormalMenuItem.Checked = true;
				pkgVitaPreInstallMenuItem.Checked = false;
				changeModeNormalPkg();
				vitaTvModeItem.Enabled = true;
			}
			else if (Package.VitaPreInstall == pkg)
			{
				m_package = Package.VitaPreInstall;
				pkgNormalMenuItem.Checked = false;
				pkgVitaPreInstallMenuItem.Checked = true;
				changeModeVita(bLoad);
				vitaTvModeItem.Enabled = false;
			}
			homePropertyGrid.Refresh();
		}

		private void updateBarTimeString()
		{
			int num = 0;
			if (barTimeLabel.Text != m_timeString)
			{
				int num2 = 52;
				barMeridianLabel.Text = m_meridianString;
				if (0 < m_meridianString.Length)
				{
					barMeridianLabel.Show();
					barMeridianLabel.Location = new Point((int)((double)startInfomationBarPictureBox.Width - m_scale * (double)num2 - (double)barMeridianLabel.Width), barMeridianLabel.Location.Y);
					num = barMeridianLabel.Width - 6;
				}
				else
				{
					barMeridianLabel.Hide();
				}
			}
			if (homeBatTimeLabel1.Text != m_timeString)
			{
				int num3 = 132;
				homeMeridianLabel.Text = m_meridianString;
				if (0 < m_meridianString.Length)
				{
					homeMeridianLabel.Show();
					homeMeridianLabel.Location = new Point((int)((double)startInfomationBarPictureBox.Width - m_scale * (double)num3 - (double)homeMeridianLabel.Width), homeMeridianLabel.Location.Y);
				}
				else
				{
					homeMeridianLabel.Hide();
				}
			}
			if (barTimeLabel.Text != m_timeString)
			{
				int num4 = 52 + num;
				barTimeLabel.Text = m_timeString;
				barTimeLabel.Location = new Point((int)((double)startInfomationBarPictureBox.Width - m_scale * (double)num4 - (double)barTimeLabel.Width), barTimeLabel.Location.Y);
			}
			if (homeBatTimeLabel1.Text != m_timeString)
			{
				int num5 = 132 + num;
				homeBatTimeLabel1.Text = m_timeString;
				homeBatTimeLabel1.Location = new Point((int)((double)startInfomationBarPictureBox.Width - m_scale * (double)num5 - (double)homeBatTimeLabel1.Width), homeBatTimeLabel1.Location.Y);
			}
		}

		private void updateDateTimeString()
		{
			CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
			string shortTimePattern = currentUICulture.DateTimeFormat.ShortTimePattern;
			shortTimePattern = shortTimePattern.Replace("tt ", "");
			shortTimePattern = shortTimePattern.Replace(" tt", "");
			shortTimePattern = shortTimePattern.Replace("t ", "");
			shortTimePattern = shortTimePattern.Replace(" t", "");
			shortTimePattern = shortTimePattern.Replace("hh", "h");
			shortTimePattern = shortTimePattern.Replace("HH", "H");
			string timeString = DateTime.Now.ToString(shortTimePattern, currentUICulture);
			string text = DateTime.Now.ToString(currentUICulture.DateTimeFormat.MonthDayPattern, currentUICulture);
			m_dateString = text + "(" + currentUICulture.DateTimeFormat.DayNames[(int)DateTime.Now.DayOfWeek] + ")";
			m_timeString = timeString;
			m_meridianString = "";
			if (0 <= shortTimePattern.IndexOf("h"))
			{
				if (12 > DateTime.Now.Hour)
				{
					m_meridianString = "AM";
				}
				else
				{
					m_meridianString = "PM";
				}
			}
			if (dateLabel.Text != m_dateString || timeLabel.Text != m_timeString)
			{
				dateLabel.Text = m_dateString;
				timeLabel.Text = m_timeString;
				meridianLabel.Text = m_meridianString;
				if (m_startScreen != null)
				{
					m_startScreen.updateDateTimeLayout();
				}
			}
			updateBarTimeString();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			updateDateTimeString();
		}

		private void menuItemExit_Click(object sender, EventArgs e)
		{
			if (chkEditData())
			{
				Close();
			}
		}

		private bool chkEditData()
		{
			if (!m_edit)
			{
				return true;
			}
			DialogResult dialogResult = MessageBox.Show(Resources.MSG_EDIT_SAVE, "Theme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
			if (DialogResult.Yes == dialogResult)
			{
				saveAsProject();
				startPropertyGrid.Refresh();
				homePropertyGrid.Refresh();
				infoPropertyGrid.Refresh();
			}
			else if (DialogResult.No != dialogResult && DialogResult.Cancel == dialogResult)
			{
				return false;
			}
			m_edit = false;
			return true;
		}

		private void startImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			m_startScreen.startImageLoaded();
		}

		public void setIndicatorBG(string filePath)
		{
			if (filePath == null || filePath.Length == 0)
			{
				indicatorBG0.Image = indicatorBG0.InitialImage;
				indicatorBG1.Image = indicatorBG1.InitialImage;
				indicatorBG2.Image = indicatorBG2.InitialImage;
				indicatorBG3.Image = indicatorBG3.InitialImage;
				indicatorBG4.Image = indicatorBG4.InitialImage;
				indicatorBG5.Image = indicatorBG5.InitialImage;
				indicatorBG6.Image = indicatorBG6.InitialImage;
				indicatorBG7.Image = indicatorBG7.InitialImage;
				indicatorBG8.Image = indicatorBG8.InitialImage;
				indicatorBG9.Image = indicatorBG9.InitialImage;
			}
			else
			{
				indicatorBG0.ImageLocation = filePath;
				indicatorBG1.ImageLocation = filePath;
				indicatorBG2.ImageLocation = filePath;
				indicatorBG3.ImageLocation = filePath;
				indicatorBG4.ImageLocation = filePath;
				indicatorBG5.ImageLocation = filePath;
				indicatorBG6.ImageLocation = filePath;
				indicatorBG7.ImageLocation = filePath;
				indicatorBG8.ImageLocation = filePath;
				indicatorBG9.ImageLocation = filePath;
			}
		}

		public void setIndicatorGlow(string filePath)
		{
			if (filePath == null || filePath.Length == 0)
			{
				indicatorGlow.Image = indicatorGlow.InitialImage;
			}
			else
			{
				indicatorGlow.ImageLocation = filePath;
			}
		}

		public void setNewNoticeIcon(string filePath)
		{
			if (filePath == null)
			{
				newNoticeIcon.Image = newNoticeIcon.InitialImage;
			}
			else
			{
				newNoticeIcon.ImageLocation = filePath;
			}
		}

		public void setNoNoticeIcon(string filePath)
		{
			if (filePath == null)
			{
				noNoticeIcon.Image = noNoticeIcon.InitialImage;
			}
			else
			{
				noNoticeIcon.ImageLocation = filePath;
			}
		}

		private void menuNewNotifyItem_Click(object sender, EventArgs e)
		{
			m_notify = Notify.New;
			menuNewNotifyItem.Checked = true;
			menuNoneNotifyItem.Checked = false;
			newNoticeIcon.Show();
			glowNoticeIcon.Show();
			noNoticeIcon.Hide();
		}

		private void menuNoneNotifyItem_Click(object sender, EventArgs e)
		{
			m_notify = Notify.None;
			menuNewNotifyItem.Checked = false;
			menuNoneNotifyItem.Checked = true;
			newNoticeIcon.Hide();
			glowNoticeIcon.Hide();
			noNoticeIcon.Show();
		}

		private void notifyRefreshCB(object sender, AsyncCompletedEventArgs e)
		{
			if (!e.Cancelled && e.Error == null)
			{
				notifyRefresh();
			}
		}

		public void notifyRefresh()
		{
			if (newNoticeIcon.Visible)
			{
				newNoticeIcon.Refresh();
			}
			if (noNoticeIcon.Visible)
			{
				noNoticeIcon.Refresh();
			}
		}

		private void notifyLoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (!e.Cancelled && e.Error == null)
			{
				notifyUpdateImage((PictureBox)sender);
			}
		}

		private void notifyUpdateImage(PictureBox picBox)
		{
			Bitmap bitmap = new Bitmap(picBox.Image.Width, picBox.Image.Height, PixelFormat.Format32bppArgb);
			Graphics.FromImage(bitmap);
			Bitmap bitmap2 = new Bitmap(picBox.Image);
			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int j = 0; j < bitmap.Height; j++)
				{
					Color pixel = bitmap2.GetPixel(bitmap2.Width * i / bitmap.Width, bitmap2.Height * j / bitmap.Height);
					Color pixel2 = m_maskBitmap.GetPixel(m_maskBitmap.Width * i / bitmap.Width, m_maskBitmap.Height * j / bitmap.Height);
					int num = pixel.ToArgb();
					int num2 = (int)((float)(int)pixel.A / 255f * ((float)(int)pixel2.A / 255f) * 255f);
					if (255 < num2)
					{
						num2 = 255;
					}
					num &= 0xFFFFFF;
					num |= num2 << 24;
					bitmap.SetPixel(i, j, Color.FromArgb(num));
				}
			}
			bitmap2.Dispose();
			bitmap2 = null;
			picBox.Image = bitmap;
			if (!m_mainForm.m_refreshInvalid)
			{
				picBox.Refresh();
			}
		}
	}
}
