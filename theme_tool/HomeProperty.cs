using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using theme_tool.BaseClass;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	[Save]
	public class HomeProperty : BaseSaveAttributeProperty
	{
		private static readonly IconLayout[] s_vitaIconLayout = new IconLayout[19]
		{
			new IconLayout(0, 2),
			new IconLayout(1, 0),
			new IconLayout(1, 1),
			new IconLayout(1, 7),
			new IconLayout(0, 6),
			new IconLayout(0, 3),
			new IconLayout(1, 6),
			new IconLayout(1, 5),
			new IconLayout(0, 0),
			new IconLayout(0, 7),
			new IconLayout(0, 4),
			new IconLayout(1, 3),
			new IconLayout(1, 4),
			new IconLayout(0, 1),
			new IconLayout(0, 5),
			new IconLayout(0, 9),
			new IconLayout(1, 2),
			new IconLayout(1, 9),
			new IconLayout(-1, -1)
		};

		private static readonly IconLayout[] s_vitaTvIconLayout = new IconLayout[19]
		{
			new IconLayout(0, 1),
			new IconLayout(0, 8),
			new IconLayout(0, 9),
			new IconLayout(-1, -1),
			new IconLayout(0, 6),
			new IconLayout(0, 3),
			new IconLayout(-1, -1),
			new IconLayout(1, 3),
			new IconLayout(-1, -1),
			new IconLayout(0, 7),
			new IconLayout(0, 4),
			new IconLayout(1, 1),
			new IconLayout(1, 2),
			new IconLayout(0, 0),
			new IconLayout(0, 5),
			new IconLayout(1, 4),
			new IconLayout(1, 0),
			new IconLayout(1, 5),
			new IconLayout(0, 2)
		};

		private BackgroundParam[] m_bgParam_ = new BackgroundParam[10];

		private string m_bgmFilePath_;

		public Color m_barColor_;

		public Color m_indicatorColor_;

		public Color m_indicatorFontColor_;

		public string m_noNoticeFilePath_;

		public string m_newNoticeFilePath_;

		public Color m_noticeGlowColor_;

		private string m_basePageFilePath_;

		private string m_curPageFilePath_;

		private IconParam m_browser_;

		private IconParam m_video_;

		private IconParam m_music_;

		private IconParam m_ps3Link_;

		private IconParam m_party_;

		private IconParam m_trophy_;

		private IconParam m_near_;

		private IconParam m_hostCollabo_;

		private IconParam m_welcomePark_;

		private IconParam m_ps4Link_;

		private IconParam m_friend_;

		private IconParam m_email_;

		private IconParam m_calendar_;

		private IconParam m_store_;

		private IconParam m_message_;

		private IconParam m_parental_;

		private IconParam m_camera_;

		private IconParam m_settings_;

		private IconParam m_power_;

		[PropertyCategory("backgroundCategory")]
		[TypeConverter(typeof(CustomArrayConverter))]
		[Editor(typeof(DummyEditor), typeof(UITypeEditor))]
		[PropertyDisplayName("param")]
		[Save]
		public BackgroundParam[] m_bgParam
		{
			get
			{
				return m_bgParam_;
			}
			set
			{
				m_bgParam_ = value;
			}
		}

		[Save]
		[PropertyCategory("bgmCategory")]
		[Editor(typeof(BgmOpenFileDialog), typeof(UITypeEditor))]
		[PropertyDisplayName("filePath")]
		[FilePath]
		public string m_bgmFilePath
		{
			get
			{
				return m_bgmFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_bgmFilePath_ = Utility.getRelativePath(value);
			}
		}

		[TypeConverter(typeof(MyColorConverter))]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[PropertyCategory("infomationBarCategory")]
		[PropertyDisplayName("infomationBarColor")]
		public Color m_barColor
		{
			get
			{
				return m_barColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				MainForm.m_mainForm.m_infomationBar.m_barColor = value;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					MainForm.m_mainForm.startPropertyGrid.Refresh();
				}
			}
		}

		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[TypeConverter(typeof(MyColorConverter))]
		[PropertyDisplayName("indicatorColor")]
		[PropertyCategory("infomationBarCategory")]
		public Color m_indicatorColor
		{
			get
			{
				return m_indicatorColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				MainForm.m_mainForm.m_infomationBar.m_indicatorColor = value;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					MainForm.m_mainForm.startPropertyGrid.Refresh();
				}
			}
		}

		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[PropertyDisplayName("noticeFontColor")]
		[TypeConverter(typeof(MyColorConverter))]
		[PropertyCategory("infomationBarCategory")]
		public Color m_indicatorFontColor
		{
			get
			{
				return m_indicatorFontColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				MainForm.m_mainForm.m_infomationBar.m_noticeFontColor = value;
			}
		}

		[PropertyCategory("infomationBarCategory")]
		[FilePath]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[PropertyDisplayName("noNoticeFilePath")]
		public string m_noNoticeFilePath
		{
			get
			{
				return m_noNoticeFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				MainForm.m_mainForm.m_infomationBar.m_noNoticeFilePath = value;
			}
		}

		[FilePath]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[PropertyCategory("infomationBarCategory")]
		[PropertyDisplayName("newNoticeFilePath")]
		public string m_newNoticeFilePath
		{
			get
			{
				return m_newNoticeFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				MainForm.m_mainForm.m_infomationBar.m_newNoticeFilePath = value;
			}
		}

		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[PropertyCategory("infomationBarCategory")]
		[PropertyDisplayName("noticeGlowColor")]
		[TypeConverter(typeof(MyColorConverter))]
		public Color m_noticeGlowColor
		{
			get
			{
				return m_noticeGlowColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				MainForm.m_mainForm.m_infomationBar.m_noticeGlowColor = value;
			}
		}

		[PropertyDisplayName("basePageImage")]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[Save]
		[PropertyCategory("pageIndicatorCategory")]
		[FilePath]
		public string m_basePageFilePath
		{
			get
			{
				return m_basePageFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_basePageFilePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.setIndicatorBG(m_basePageFilePath_);
			}
		}

		[FilePath]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[Save]
		[PropertyCategory("pageIndicatorCategory")]
		[PropertyDisplayName("curPageImage")]
		public string m_curPageFilePath
		{
			get
			{
				return m_curPageFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_curPageFilePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.setIndicatorGlow(m_curPageFilePath_);
			}
		}

		[PropertyDisplayName("browser")]
		[PropertyCategory("iconCategory")]
		[Save]
		public IconParam m_browser
		{
			get
			{
				return m_browser_;
			}
			set
			{
				m_browser_ = value;
			}
		}

		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("video")]
		[Save]
		public IconParam m_video
		{
			get
			{
				return m_video_;
			}
			set
			{
				m_video_ = value;
			}
		}

		[Save]
		[PropertyDisplayName("music")]
		[PropertyCategory("iconCategory")]
		public IconParam m_music
		{
			get
			{
				return m_music_;
			}
			set
			{
				m_music_ = value;
			}
		}

		[PropertyDisplayName("ps3Link")]
		[Save]
		[PropertyCategory("iconCategory")]
		public IconParam m_ps3Link
		{
			get
			{
				return m_ps3Link_;
			}
			set
			{
				m_ps3Link_ = value;
			}
		}

		[Save]
		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("party")]
		public IconParam m_party
		{
			get
			{
				return m_party_;
			}
			set
			{
				m_party_ = value;
			}
		}

		[Save]
		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("trophy")]
		public IconParam m_trophy
		{
			get
			{
				return m_trophy_;
			}
			set
			{
				m_trophy_ = value;
			}
		}

		[Save]
		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("near")]
		public IconParam m_near
		{
			get
			{
				return m_near_;
			}
			set
			{
				m_near_ = value;
			}
		}

		[Save]
		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("hostCollabo")]
		public IconParam m_hostCollabo
		{
			get
			{
				return m_hostCollabo_;
			}
			set
			{
				m_hostCollabo_ = value;
			}
		}

		[TypeConverter(typeof(PosOnlyIconPropertyDisplayConverter))]
		[PkgNormalHide]
		[Save]
		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("welcomePark")]
		public IconParam m_welcomePark
		{
			get
			{
				return m_welcomePark_;
			}
			set
			{
				m_welcomePark_ = value;
			}
		}

		[PropertyCategory("iconCategory")]
		[Save]
		[PropertyDisplayName("ps4Link")]
		public IconParam m_ps4Link
		{
			get
			{
				return m_ps4Link_;
			}
			set
			{
				m_ps4Link_ = value;
			}
		}

		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("friend")]
		[Save]
		public IconParam m_friend
		{
			get
			{
				return m_friend_;
			}
			set
			{
				m_friend_ = value;
			}
		}

		[Save]
		[PropertyDisplayName("email")]
		[PropertyCategory("iconCategory")]
		public IconParam m_email
		{
			get
			{
				return m_email_;
			}
			set
			{
				m_email_ = value;
			}
		}

		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("calendar")]
		[Save]
		public IconParam m_calendar
		{
			get
			{
				return m_calendar_;
			}
			set
			{
				m_calendar_ = value;
			}
		}

		[TypeConverter(typeof(PosOnlyIconPropertyDisplayConverter))]
		[Save]
		[PropertyDisplayName("store")]
		[PkgNormalHide]
		[PropertyCategory("iconCategory")]
		public IconParam m_store
		{
			get
			{
				return m_store_;
			}
			set
			{
				m_store_ = value;
			}
		}

		[PropertyDisplayName("message")]
		[Save]
		[PropertyCategory("iconCategory")]
		public IconParam m_message
		{
			get
			{
				return m_message_;
			}
			set
			{
				m_message_ = value;
			}
		}

		[PropertyDisplayName("parental")]
		[Save]
		[PropertyCategory("iconCategory")]
		public IconParam m_parental
		{
			get
			{
				return m_parental_;
			}
			set
			{
				m_parental_ = value;
			}
		}

		[Save]
		[PropertyCategory("iconCategory")]
		[PropertyDisplayName("camera")]
		public IconParam m_camera
		{
			get
			{
				return m_camera_;
			}
			set
			{
				m_camera_ = value;
			}
		}

		[Save]
		[PropertyDisplayName("settings")]
		[PropertyCategory("iconCategory")]
		public IconParam m_settings
		{
			get
			{
				return m_settings_;
			}
			set
			{
				m_settings_ = value;
			}
		}

		[PropertyCategory("iconCategory")]
		[PkgVitaPreInstallHide]
		[Save]
		[PropertyDisplayName("power")]
		public IconParam m_power
		{
			get
			{
				return m_power_;
			}
			set
			{
				m_power_ = value;
			}
		}

		public override bool CheckProperties()
		{
			bool result = true;
			string msg;
			if (!string.IsNullOrEmpty(m_bgmFilePath))
			{
				if (!checkFileSize(out msg, m_bgmFilePath, 5242880L))
				{
					msg = m_bgmFilePath + msg + "\n";
					Dialog.AddMsg(msg);
					result = false;
				}
				if (!BgmChecker.bgmFileCheck(m_bgmFilePath))
				{
					msg = ErrorMsg.GetString(ErrorMsg.DEFINES.INVALID_BGM_FILE) + " : " + m_bgmFilePath + "\n";
					Dialog.AddMsg(msg);
					result = false;
				}
			}
			string empty = string.Empty;
			string text = empty;
			empty = text + "[" + GetPropertyCategory(this, "m_bgParam") + "] -> [" + GetPropertyDisplayName(this, "m_bgParam") + "] -> ";
			for (int i = 0; i < m_bgParam.Length; i++)
			{
				if (!checkImageFile(out msg, m_bgParam[i].m_imageFilePath, 32, false, 960, 512, 614400L))
				{
					msg = empty + "[" + i + "] -> [" + GetPropertyDisplayName(m_bgParam[i], "m_imageFilePath") + "] : " + m_bgParam[i].m_imageFilePath + "\n" + msg;
					Dialog.AddMsg(msg);
					result = false;
				}
			}
			if (!checkImageFile(out msg, m_basePageFilePath, 22, 22, 4096L))
			{
				msg = "[" + GetPropertyCategory("m_basePageFilePath") + "] -> [" + GetPropertyDisplayName("m_basePageFilePath") + "] : " + m_basePageFilePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			if (!checkImageFile(out msg, m_curPageFilePath, 22, 22, 4096L))
			{
				msg = "[" + GetPropertyCategory("m_curPageFilePath") + "] -> [" + GetPropertyDisplayName("m_curPageFilePath") + "] : " + m_curPageFilePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			if (!checkEmptyPage())
			{
				result = false;
			}
			return result;
		}

		private bool checkEmptyPage()
		{
			bool result = true;
			string msg = string.Empty;
			int[] array = new int[10];
			PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			PropertyInfo[] array2 = properties;
			foreach (PropertyInfo propertyInfo in array2)
			{
				object value = propertyInfo.GetValue(this, null);
				if (!(value is IconParam))
				{
					continue;
				}
				object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(SaveAttribute), false);
				if (0 >= customAttributes.Length)
				{
					continue;
				}
				string empty = string.Empty;
				empty = empty + "[" + GetPropertyCategory(propertyInfo) + "] -> ";
				empty = empty + "[" + GetPropertyDisplayName(propertyInfo) + "]";
				IconParam iconParam = value as IconParam;
				if (!checkImageFile(out msg, iconParam.m_iconFilePath, 32, false, 128, 128, 32768L))
				{
					msg = empty + " -> [" + GetPropertyDisplayName(iconParam, "m_iconFilePath") + "] : " + iconParam.m_iconFilePath + "\n" + msg;
					Dialog.AddMsg(msg);
					result = false;
				}
				if (iconParam.m_pagePos != -1)
				{
					if (checkPageIndex(out msg, iconParam.m_pagePos, 10))
					{
						array[iconParam.m_pagePos]++;
						continue;
					}
					msg = empty + " -> [" + GetPropertyDisplayName(iconParam, "m_pagePos") + "] : \n" + msg;
					Dialog.AddMsg(msg);
					result = false;
				}
			}
			string text = string.Empty;
			for (int j = 0; j < 10; j++)
			{
				if (array[j] != 0)
				{
					continue;
				}
				bool flag = false;
				for (int k = j + 1; k < 10; k++)
				{
					if (array[k] != 0)
					{
						flag = true;
					}
				}
				if (flag)
				{
					text += ErrorMsg.GetString(ErrorMsg.DEFINES.NON_CONTIGUOUS_PAGE);
					text = text + " : Page " + j + "\n";
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				Dialog.AddMsg(text);
				result = false;
			}
			return result;
		}

		public HomeProperty()
		{
			for (int i = 0; i < m_bgParam_.Length; i++)
			{
				m_bgParam_[i] = new BackgroundParam(i);
			}
			MainForm.m_mainForm.homeBgPictureBox1.ImageLocation = null;
			MainForm.m_mainForm.homeBgPictureBox1.Image = null;
			MainForm.m_mainForm.homePictureBox1.Image = BackgroundParam.s_waveImage[1];
			m_browser = new IconParam(MainForm.m_mainForm.browserIcon, MainForm.m_mainForm.browserLabel, null);
			m_video = new IconParam(MainForm.m_mainForm.videoIcon, MainForm.m_mainForm.videoLabel, null);
			m_music = new IconParam(MainForm.m_mainForm.musicIcon, MainForm.m_mainForm.musicLabel, null);
			m_ps3Link = new IconParam(MainForm.m_mainForm.ps3LinkIcon, MainForm.m_mainForm.ps3LinkLabel, null);
			m_party = new IconParam(MainForm.m_mainForm.partyIcon, MainForm.m_mainForm.partyLabel, null);
			m_trophy = new IconParam(MainForm.m_mainForm.trophyIcon, MainForm.m_mainForm.trophyLabel, null);
			m_near = new IconParam(MainForm.m_mainForm.nearIcon, MainForm.m_mainForm.nearLabel, null);
			m_hostCollabo = new IconParam(MainForm.m_mainForm.hostCollaboIcon, MainForm.m_mainForm.hostCollaboLabel, null);
			m_welcomePark = new IconParam(MainForm.m_mainForm.welcomeParkIcon, MainForm.m_mainForm.welcomeParkLabel, null);
			m_ps4Link = new IconParam(MainForm.m_mainForm.ps4LinkIcon, MainForm.m_mainForm.ps4LinkLabel, null);
			m_friend = new IconParam(MainForm.m_mainForm.friendIcon, MainForm.m_mainForm.friendLabel, null);
			m_email = new IconParam(MainForm.m_mainForm.emailIcon, MainForm.m_mainForm.emailLabel, MainForm.m_mainForm.notificationEmailIcon);
			m_calendar = new IconParam(MainForm.m_mainForm.calendarIcon, MainForm.m_mainForm.calendarLabel, MainForm.m_mainForm.notificationCalendarIcon);
			m_store = new IconParam(MainForm.m_mainForm.storeIcon, MainForm.m_mainForm.storeLabel, null);
			m_message = new IconParam(MainForm.m_mainForm.messageIcon, MainForm.m_mainForm.messageLabel, MainForm.m_mainForm.notificationMessageIcon);
			m_parental = new IconParam(MainForm.m_mainForm.parentalIcon, MainForm.m_mainForm.parentalLabel, null);
			m_camera = new IconParam(MainForm.m_mainForm.cameraIcon, MainForm.m_mainForm.cameraLabel, null);
			m_settings = new IconParam(MainForm.m_mainForm.settingsIcon, MainForm.m_mainForm.settingsLabel, null);
			m_power = new IconParam(MainForm.m_mainForm.powerIcon, MainForm.m_mainForm.powerLabel, null);
			resetLayout();
		}

		public void resetLayout(bool bLoad = false)
		{
			MainForm.m_mainForm.resetHomePanel();
			for (int i = 0; i < m_bgParam_.Length; i++)
			{
				for (int j = 0; j < m_bgParam_[i].m_iconLayouts.Length; j++)
				{
					m_bgParam_[i].m_iconLayouts[j] = null;
				}
			}
			if (bLoad)
			{
				IconLayout iconLayout = new IconLayout(-1, -1);
				m_browser.initIconLayout(this, iconLayout);
				m_video.initIconLayout(this, iconLayout);
				m_music.initIconLayout(this, iconLayout);
				m_ps3Link.initIconLayout(this, iconLayout);
				m_party.initIconLayout(this, iconLayout);
				m_trophy.initIconLayout(this, iconLayout);
				m_near.initIconLayout(this, iconLayout);
				m_hostCollabo.initIconLayout(this, iconLayout);
				m_welcomePark.initIconLayout(this, iconLayout);
				m_ps4Link.initIconLayout(this, iconLayout);
				m_friend.initIconLayout(this, iconLayout);
				m_email.initIconLayout(this, iconLayout);
				m_calendar.initIconLayout(this, iconLayout);
				m_store.initIconLayout(this, iconLayout);
				m_message.initIconLayout(this, iconLayout);
				m_parental.initIconLayout(this, iconLayout);
				m_camera.initIconLayout(this, iconLayout);
				m_settings.initIconLayout(this, iconLayout);
				m_power.initIconLayout(this, iconLayout);
			}
			else if (MainForm.m_mainForm.m_mode == Mode.Vita)
			{
				m_browser.initIconLayout(this, s_vitaIconLayout[0]);
				m_video.initIconLayout(this, s_vitaIconLayout[1]);
				m_music.initIconLayout(this, s_vitaIconLayout[2]);
				m_ps3Link.initIconLayout(this, s_vitaIconLayout[3]);
				m_party.initIconLayout(this, s_vitaIconLayout[4]);
				m_trophy.initIconLayout(this, s_vitaIconLayout[5]);
				m_near.initIconLayout(this, s_vitaIconLayout[6]);
				m_hostCollabo.initIconLayout(this, s_vitaIconLayout[7]);
				m_welcomePark.initIconLayout(this, s_vitaIconLayout[8]);
				m_ps4Link.initIconLayout(this, s_vitaIconLayout[9]);
				m_friend.initIconLayout(this, s_vitaIconLayout[10]);
				m_email.initIconLayout(this, s_vitaIconLayout[11]);
				m_calendar.initIconLayout(this, s_vitaIconLayout[12]);
				m_store.initIconLayout(this, s_vitaIconLayout[13]);
				m_message.initIconLayout(this, s_vitaIconLayout[14]);
				m_parental.initIconLayout(this, s_vitaIconLayout[15]);
				m_camera.initIconLayout(this, s_vitaIconLayout[16]);
				m_settings.initIconLayout(this, s_vitaIconLayout[17]);
				m_power.initIconLayout(this, s_vitaIconLayout[18]);
			}
			else if (Mode.VitaTV == MainForm.m_mainForm.m_mode)
			{
				m_browser.initIconLayout(this, s_vitaTvIconLayout[0]);
				m_video.initIconLayout(this, s_vitaTvIconLayout[1]);
				m_music.initIconLayout(this, s_vitaTvIconLayout[2]);
				m_ps3Link.initIconLayout(this, s_vitaTvIconLayout[3]);
				m_party.initIconLayout(this, s_vitaTvIconLayout[4]);
				m_trophy.initIconLayout(this, s_vitaTvIconLayout[5]);
				m_near.initIconLayout(this, s_vitaTvIconLayout[6]);
				m_hostCollabo.initIconLayout(this, s_vitaTvIconLayout[7]);
				m_welcomePark.initIconLayout(this, s_vitaTvIconLayout[8]);
				m_ps4Link.initIconLayout(this, s_vitaTvIconLayout[9]);
				m_friend.initIconLayout(this, s_vitaTvIconLayout[10]);
				m_email.initIconLayout(this, s_vitaTvIconLayout[11]);
				m_calendar.initIconLayout(this, s_vitaTvIconLayout[12]);
				m_store.initIconLayout(this, s_vitaTvIconLayout[13]);
				m_message.initIconLayout(this, s_vitaTvIconLayout[14]);
				m_parental.initIconLayout(this, s_vitaTvIconLayout[15]);
				m_camera.initIconLayout(this, s_vitaTvIconLayout[16]);
				m_settings.initIconLayout(this, s_vitaTvIconLayout[17]);
				m_power.initIconLayout(this, s_vitaTvIconLayout[18]);
			}
		}
	}
}
