using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Windows.Forms;
using theme_tool.BaseClass;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	[Save]
	public class InfomationBarProperty : BaseSaveAttributeProperty
	{
		private Color m_barColor_;

		private Color m_indicatorColor_;

		private Color m_noticeFontColor_;

		private string m_noNoticeFilePath_;

		private string m_newNoticeFilePath_;

		private Color m_noticeGlowColor_;

		[TypeConverter(typeof(MyColorConverter))]
		[Save]
		[PropertyCategory("infomationBarCategory")]
		[PropertyDisplayName("infomationBarColor")]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		public Color m_barColor
		{
			get
			{
				return m_barColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_barColor_ = value;
				MainForm.m_mainForm.startInfomationBarPictureBox.BackColor = value;
				MainForm.m_mainForm.homeInfomationBarPictureBox1.BackColor = value;
				MainForm.m_mainForm.m_startScreen.m_barColor_ = value;
				MainForm.m_mainForm.m_home.m_barColor_ = value;
				if (MainForm.m_mainForm.newNoticeIcon.Visible)
				{
					MainForm.m_mainForm.newNoticeIcon.Refresh();
				}
				if (MainForm.m_mainForm.noNoticeIcon.Visible)
				{
					MainForm.m_mainForm.noNoticeIcon.Refresh();
				}
			}
		}

		[Save]
		[TypeConverter(typeof(MyColorConverter))]
		[PropertyCategory("infomationBarCategory")]
		[PropertyDisplayName("indicatorColor")]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		public Color m_indicatorColor
		{
			get
			{
				return m_indicatorColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_indicatorColor_ = value;
				MainForm.m_mainForm.barMeridianLabel.ForeColor = value;
				MainForm.m_mainForm.homeMeridianLabel.ForeColor = value;
				MainForm.m_mainForm.barTimeLabel.ForeColor = value;
				MainForm.m_mainForm.homeBatTimeLabel1.ForeColor = value;
				MainForm.m_mainForm.m_startScreen.m_indicatorColor_ = value;
				MainForm.m_mainForm.m_home.m_indicatorColor_ = value;
			}
		}

		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[TypeConverter(typeof(MyColorConverter))]
		[Save]
		[PropertyCategory("infomationBarCategory")]
		[PropertyDisplayName("fontColor")]
		public Color m_noticeFontColor
		{
			get
			{
				return m_noticeFontColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_noticeFontColor_ = value;
				MainForm.m_mainForm.noticeLabel.ForeColor = value;
				MainForm.m_mainForm.m_home.m_indicatorFontColor_ = value;
			}
		}

		[Save]
		[PropertyDisplayName("noNoticeFilePath")]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[FilePath]
		[PropertyCategory("infomationBarCategory")]
		public string m_noNoticeFilePath
		{
			get
			{
				return m_noNoticeFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_noNoticeFilePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.m_home.m_noNoticeFilePath_ = m_noNoticeFilePath_;
				MainForm.m_mainForm.setNoNoticeIcon(MainForm.m_mainForm.m_infomationBar.m_noNoticeFilePath);
			}
		}

		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[PropertyDisplayName("newNoticeFilePath")]
		[Save]
		[FilePath]
		[PropertyCategory("infomationBarCategory")]
		public string m_newNoticeFilePath
		{
			get
			{
				return m_newNoticeFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_newNoticeFilePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.m_home.m_newNoticeFilePath_ = m_newNoticeFilePath_;
				MainForm.m_mainForm.setNewNoticeIcon(MainForm.m_mainForm.m_infomationBar.m_newNoticeFilePath);
			}
		}

		[PropertyDisplayName("noticeGlowColor")]
		[TypeConverter(typeof(MyColorConverter))]
		[PropertyCategory("infomationBarCategory")]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[Save]
		public Color m_noticeGlowColor
		{
			get
			{
				return m_noticeGlowColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				MainForm.m_mainForm.m_home.m_noticeGlowColor_ = value;
				m_noticeGlowColor_ = value;
				updateImage();
			}
		}

		public InfomationBarProperty()
		{
			updateImage();
		}

		private void loadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (!e.Cancelled && e.Error == null)
			{
				updateImage();
			}
		}

		private void updateImage()
		{
			PictureBox glowNoticeIcon = MainForm.m_mainForm.glowNoticeIcon;
			Bitmap bitmap = new Bitmap(glowNoticeIcon.InitialImage.Width, glowNoticeIcon.InitialImage.Height, PixelFormat.Format32bppArgb);
			Graphics.FromImage(bitmap);
			Bitmap bitmap2 = new Bitmap(glowNoticeIcon.InitialImage);
			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int j = 0; j < bitmap.Height; j++)
				{
					Color pixel = bitmap2.GetPixel(bitmap2.Width * i / bitmap.Width, bitmap2.Height * j / bitmap.Height);
					Color noticeGlowColor = m_noticeGlowColor;
					int red = (int)((float)(int)pixel.R / 255f * ((float)(int)noticeGlowColor.R / 255f) * 255f);
					int green = (int)((float)(int)pixel.G / 255f * ((float)(int)noticeGlowColor.G / 255f) * 255f);
					int blue = (int)((float)(int)pixel.B / 255f * ((float)(int)noticeGlowColor.B / 255f) * 255f);
					bitmap.SetPixel(i, j, Color.FromArgb(pixel.A, red, green, blue));
				}
			}
			bitmap2.Dispose();
			bitmap2 = null;
			glowNoticeIcon.Image = bitmap;
			if (!MainForm.m_mainForm.m_refreshInvalid)
			{
				glowNoticeIcon.Refresh();
				if (MainForm.m_mainForm.newNoticeIcon.Visible)
				{
					MainForm.m_mainForm.newNoticeIcon.Refresh();
				}
			}
		}

		public override bool CheckProperties()
		{
			bool result = true;
			string msg;
			if (!checkImageFile(out msg, m_noNoticeFilePath, 120, 110, 12288L))
			{
				msg = "[" + GetPropertyCategory("m_noNoticeFilePath") + "] -> [" + GetPropertyDisplayName("m_noNoticeFilePath") + "] : " + m_noNoticeFilePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			if (!checkImageFile(out msg, m_newNoticeFilePath, 120, 110, 12288L))
			{
				msg = "[" + GetPropertyCategory("m_newNoticeFilePath") + "] -> [" + GetPropertyDisplayName("m_newNoticeFilePath") + "] : " + m_newNoticeFilePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			return result;
		}
	}
}
