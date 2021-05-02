using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Windows.Forms;
using theme_tool.Properties;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	public class IconParam
	{
		private Label m_label;

		private PictureBox m_picBox;

		private PictureBox m_notificationPixBox;

		private static Bitmap m_maskBitmap = new Bitmap(Resources.icon_mask);

		private string m_iconFilePath_;

		private int m_pagePos_;

		private int m_iconPos_;

		[FilePath]
		[Save]
		[PropertyDisplayName("filePath")]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		public string m_iconFilePath
		{
			get
			{
				return m_iconFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_iconFilePath_ = Utility.getRelativePath(value);
				if (m_iconFilePath_ == null)
				{
					m_picBox.Image = m_picBox.InitialImage;
					updateImage();
				}
				else
				{
					m_picBox.ImageLocation = value;
				}
			}
		}

		[Save]
		[PropertyDisplayName("pagePos")]
		[PkgNormalHide]
		public int m_pagePos
		{
			get
			{
				return m_pagePos_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (8 < value)
				{
					value = 8;
				}
				else if (0 > value)
				{
					value = 0;
				}
				setIconLayout(new IconLayout(value, m_iconPos));
				if (!MainForm.m_mainForm.m_load && value != MainForm.m_mainForm.homeScreenTab.SelectedIndex)
				{
					MainForm.m_mainForm.homeScreenTab.SelectedIndex = value;
				}
			}
		}

		[PropertyDisplayName("iconPos")]
		[Save]
		[PkgNormalHide]
		public int m_iconPos
		{
			get
			{
				return m_iconPos_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (9 < value)
				{
					value = 9;
				}
				else if (0 > value)
				{
					value = 0;
				}
				setIconLayout(new IconLayout(m_pagePos, value));
				if (!MainForm.m_mainForm.m_load && m_pagePos != MainForm.m_mainForm.homeScreenTab.SelectedIndex)
				{
					MainForm.m_mainForm.homeScreenTab.SelectedIndex = m_pagePos;
				}
			}
		}

		public IconParam(PictureBox picBox, Label label, PictureBox notificationPixBox)
		{
			m_picBox = picBox;
			m_label = label;
			m_notificationPixBox = notificationPixBox;
			m_picBox.LoadCompleted += loadCompleted;
			m_picBox.Image = m_picBox.InitialImage;
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
			Bitmap bitmap = new Bitmap(m_picBox.Image.Width, m_picBox.Image.Height, PixelFormat.Format32bppArgb);
			Graphics.FromImage(bitmap);
			Bitmap bitmap2 = new Bitmap(m_picBox.Image);
			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int j = 0; j < bitmap.Height; j++)
				{
					Color pixel = bitmap2.GetPixel(bitmap2.Width * i / bitmap.Width, bitmap2.Height * j / bitmap.Height);
					Color pixel2 = m_maskBitmap.GetPixel(m_maskBitmap.Width * i / bitmap.Width, m_maskBitmap.Height * j / bitmap.Height);
					int num = pixel.ToArgb();
					num &= 0xFFFFFF;
					num |= pixel2.A << 24;
					bitmap.SetPixel(i, j, Color.FromArgb(num));
				}
			}
			bitmap2.Dispose();
			bitmap2 = null;
			m_picBox.Image = bitmap;
			if (!MainForm.m_mainForm.m_refreshInvalid)
			{
				m_picBox.Refresh();
				m_label.Refresh();
			}
			if (m_notificationPixBox != null)
			{
				m_notificationPixBox.Image = bitmap;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					m_notificationPixBox.Refresh();
				}
			}
		}

		public override string ToString()
		{
			return "";
		}

		public void initIconLayout(HomeProperty homeProperty, IconLayout iconLayout)
		{
			m_pagePos_ = iconLayout.m_pagePos;
			m_iconPos_ = iconLayout.m_iconPos;
			if (0 <= m_pagePos && 0 <= m_iconPos)
			{
				homeProperty.m_bgParam[m_pagePos].m_iconLayouts[m_iconPos] = this;
			}
		}

		public void setHomePanel(int idx, Color textColor)
		{
			Point location = new Point((int)((double)IconLayout.m_pointTbl[idx].X * MainForm.m_mainForm.m_scale), (int)((double)IconLayout.m_pointTbl[idx].Y * MainForm.m_mainForm.m_scale));
			if (m_label != null)
			{
				m_label.Parent = MainForm.m_mainForm.homeBgPictureBox1;
				m_label.Location = new Point(location.X, location.Y + (int)(104.0 * MainForm.m_mainForm.m_scale));
				m_label.ForeColor = textColor;
				m_label.Show();
			}
			m_picBox.Parent = MainForm.m_mainForm.homeBgPictureBox1;
			m_picBox.Location = location;
			m_picBox.Show();
		}

		public void setFontColor(Color textColor)
		{
			if (m_label != null)
			{
				m_label.ForeColor = textColor;
			}
		}

		public void unsetHomePanel()
		{
			if (m_label != null)
			{
				m_label.Parent = MainForm.m_mainForm.splitContainer1.Panel2;
				m_label.Hide();
			}
			m_picBox.Parent = MainForm.m_mainForm.splitContainer1.Panel2;
			m_picBox.Hide();
		}

		public void setIconLayout(IconLayout iconLayout)
		{
			HomeProperty home = MainForm.m_mainForm.m_home;
			if (home == null)
			{
				return;
			}
			if (0 > iconLayout.m_pagePos && 0 <= iconLayout.m_iconPos)
			{
				m_iconPos_ = iconLayout.m_iconPos;
				return;
			}
			if (0 > iconLayout.m_iconPos && 0 <= iconLayout.m_pagePos)
			{
				m_pagePos_ = iconLayout.m_pagePos;
				return;
			}
			if (!MainForm.m_mainForm.m_load)
			{
				IconParam iconParam = home.m_bgParam[iconLayout.m_pagePos].m_iconLayouts[iconLayout.m_iconPos];
				if (iconParam != null)
				{
					if (iconLayout.m_pagePos != m_pagePos && iconLayout.m_pagePos == MainForm.m_mainForm.homeScreenTab.SelectedIndex)
					{
						iconParam.unsetHomePanel();
					}
					home.m_bgParam[m_pagePos].m_iconLayouts[m_iconPos] = iconParam;
					iconParam.m_pagePos_ = m_pagePos;
					iconParam.m_iconPos_ = m_iconPos;
					if (m_pagePos == MainForm.m_mainForm.homeScreenTab.SelectedIndex)
					{
						iconParam.setHomePanel(m_iconPos, home.m_bgParam[m_pagePos].m_fontColor);
					}
				}
				else
				{
					home.m_bgParam[m_pagePos].m_iconLayouts[m_iconPos] = null;
				}
			}
			if (iconLayout.m_pagePos != m_pagePos && m_pagePos == MainForm.m_mainForm.homeScreenTab.SelectedIndex)
			{
				unsetHomePanel();
			}
			home.m_bgParam[iconLayout.m_pagePos].m_iconLayouts[iconLayout.m_iconPos] = this;
			if (iconLayout.m_pagePos == MainForm.m_mainForm.homeScreenTab.SelectedIndex)
			{
				setHomePanel(iconLayout.m_iconPos, home.m_bgParam[iconLayout.m_pagePos].m_fontColor);
			}
			m_pagePos_ = iconLayout.m_pagePos;
			m_iconPos_ = iconLayout.m_iconPos;
			MainForm.m_mainForm.setBackHomePictureBox();
			if (!MainForm.m_mainForm.m_refreshInvalid)
			{
				MainForm.m_mainForm.homePropertyGrid.Refresh();
			}
		}
	}
}
