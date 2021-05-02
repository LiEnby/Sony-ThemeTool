using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CustomControl;
using theme_tool.BaseClass;
using theme_tool.Properties;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	[Save]
	public class StartScreenProperty : BaseSaveAttributeProperty
	{
		public enum DateLayoutEnum
		{
			LeftBottom,
			LeftTop,
			RightBottom
		}

		private static readonly Point[] m_dateTimePointTbl = new Point[3]
		{
			new Point(393, -48),
			new Point(393, 45),
			new Point(-36, -48)
		};

		private static readonly Point[] m_meridianPointTbl = new Point[3]
		{
			new Point(511, -48),
			new Point(511, 45),
			new Point(-46, -48)
		};

		private static readonly int[] m_datePointTbl = new int[3] { 60, 60, -365 };

		private static readonly Point[] m_notifyPointTbl = new Point[3]
		{
			new Point(62, 54),
			new Point(62, 225),
			new Point(62, 54)
		};

		private string m_filePath_;

		private Color m_dateColor_;

		private DateLayoutEnum m_dateLayout_;

		private Color m_notifyBgColor_;

		private Color m_notifyBorderColor_;

		private Color m_notifyFontColor_;

		public Color m_barColor_;

		public Color m_indicatorColor_;

		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[Save]
		[FilePath]
		[PropertyCategory("startSceenCategory")]
		[PropertyDisplayName("image")]
		public string m_filePath
		{
			get
			{
				return m_filePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_filePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.startImage.ImageLocation = value;
				if (MainForm.m_mainForm.startImage.ImageLocation == null || MainForm.m_mainForm.startImage.ImageLocation.Length == 0)
				{
					MainForm.m_mainForm.startImage.Image = null;
				}
			}
		}

		[PropertyCategory("startDateTimeCategory")]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[TypeConverter(typeof(MyColorConverter))]
		[PropertyDisplayName("fontColor")]
		[Save]
		public Color m_dateColor
		{
			get
			{
				return m_dateColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value.IsEmpty)
				{
					value = Color.White;
				}
				m_dateColor_ = value;
				MainForm.m_mainForm.dateLabel.ForeColor = value;
				MainForm.m_mainForm.timeLabel.ForeColor = value;
				MainForm.m_mainForm.meridianLabel.ForeColor = value;
			}
		}

		[PropertyDisplayName("layout")]
		[Save]
		[PropertyCategory("startDateTimeCategory")]
		public DateLayoutEnum m_dateLayout
		{
			get
			{
				return m_dateLayout_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_dateLayout_ = value;
				updateDateTimeLayout();
				Point location = m_notifyPointTbl[(int)value];
				Point location2 = m_notifyPointTbl[(int)value];
				location.X = (int)((double)location.X * MainForm.m_mainForm.m_scale);
				location.Y = (int)((double)location.Y * MainForm.m_mainForm.m_scale);
				location2.X = (int)((double)location2.X * MainForm.m_mainForm.m_scale);
				location2.Y = (int)((double)location2.Y * MainForm.m_mainForm.m_scale);
				MainForm.m_mainForm.notificationBgPictureBox.Location = location;
				MainForm.m_mainForm.notificationFramePictureBox.Location = location2;
			}
		}

		[Editor(typeof(AlphaColorEditorDialog), typeof(UITypeEditor))]
		[PropertyCategory("startNotifyCategory")]
		[Save]
		[TypeConverter(typeof(MyColorConverter))]
		[PropertyDisplayName("backgroundColor")]
		public Color m_notifyBgColor
		{
			get
			{
				return m_notifyBgColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value.IsEmpty)
				{
					value = Color.FromArgb(31, 255, 255, 255);
				}
				m_notifyBgColor_ = value;
				TransparentPictureBox notificationBgPictureBox = MainForm.m_mainForm.notificationBgPictureBox;
				Bitmap notifacationbg = Resources.notifacationbg;
				Bitmap bitmap = new Bitmap(notifacationbg.Width, notifacationbg.Height, PixelFormat.Format32bppArgb);
				Graphics.FromImage(bitmap);
				for (int i = 0; i < bitmap.Width; i++)
				{
					for (int j = 0; j < bitmap.Height; j++)
					{
						Color pixel = notifacationbg.GetPixel(notifacationbg.Width * i / bitmap.Width, notifacationbg.Height * j / bitmap.Height);
						int num = pixel.ToArgb();
						int num2 = (int)((float)(int)pixel.A / 255f * ((float)(int)m_notifyBgColor_.A / 255f) * 255f);
						int num3 = (int)((float)(int)pixel.R / 255f * ((float)(int)m_notifyBgColor_.R / 255f) * 255f);
						int num4 = (int)((float)(int)pixel.G / 255f * ((float)(int)m_notifyBgColor_.G / 255f) * 255f);
						int num5 = (int)((float)(int)pixel.B / 255f * ((float)(int)m_notifyBgColor_.B / 255f) * 255f);
						if (255 < num2)
						{
							num2 = 255;
						}
						if (255 < num3)
						{
							num3 = 255;
						}
						if (255 < num4)
						{
							num4 = 255;
						}
						if (255 < num5)
						{
							num5 = 255;
						}
						num = num2 << 24;
						num |= num3 << 16;
						num |= num4 << 8;
						num |= num5;
						bitmap.SetPixel(i, j, Color.FromArgb(num));
					}
				}
				MainForm.m_mainForm.notificationBgPictureBox.Image = bitmap;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					MainForm.m_mainForm.startImage.Refresh();
				}
			}
		}

		[PropertyCategory("startNotifyCategory")]
		[Editor(typeof(AlphaColorEditorDialog), typeof(UITypeEditor))]
		[TypeConverter(typeof(MyColorConverter))]
		[Save]
		[PropertyDisplayName("borderColor")]
		public Color m_notifyBorderColor
		{
			get
			{
				return m_notifyBorderColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value.IsEmpty)
				{
					value = Color.FromArgb(62, 255, 255, 255);
				}
				m_notifyBorderColor_ = value;
				TransparentPictureBox notificationBgPictureBox = MainForm.m_mainForm.notificationBgPictureBox;
				Bitmap notifacationborder = Resources.notifacationborder;
				Bitmap bitmap = new Bitmap(notifacationborder.Width, notifacationborder.Height, PixelFormat.Format32bppArgb);
				Graphics.FromImage(bitmap);
				for (int i = 0; i < bitmap.Width; i++)
				{
					for (int j = 0; j < bitmap.Height; j++)
					{
						Color pixel = notifacationborder.GetPixel(notifacationborder.Width * i / bitmap.Width, notifacationborder.Height * j / bitmap.Height);
						int num = pixel.ToArgb();
						int num2 = (int)((float)(int)pixel.A / 255f * ((float)(int)m_notifyBorderColor_.A / 255f) * 255f);
						int num3 = (int)((float)(int)pixel.R / 255f * ((float)(int)m_notifyBorderColor_.R / 255f) * 255f);
						int num4 = (int)((float)(int)pixel.G / 255f * ((float)(int)m_notifyBorderColor_.G / 255f) * 255f);
						int num5 = (int)((float)(int)pixel.B / 255f * ((float)(int)m_notifyBorderColor_.B / 255f) * 255f);
						if (255 < num2)
						{
							num2 = 255;
						}
						if (255 < num3)
						{
							num3 = 255;
						}
						if (255 < num4)
						{
							num4 = 255;
						}
						if (255 < num5)
						{
							num5 = 255;
						}
						num = num2 << 24;
						num |= num3 << 16;
						num |= num4 << 8;
						num |= num5;
						bitmap.SetPixel(i, j, Color.FromArgb(num));
					}
				}
				MainForm.m_mainForm.notificationFramePictureBox.Image = bitmap;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					MainForm.m_mainForm.startImage.Refresh();
				}
			}
		}

		[PropertyDisplayName("fontColor")]
		[TypeConverter(typeof(MyColorConverter))]
		[PropertyCategory("startNotifyCategory")]
		[Save]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		public Color m_notifyFontColor
		{
			get
			{
				return m_notifyFontColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value.IsEmpty)
				{
					value = Color.Black;
				}
				m_notifyFontColor_ = value;
				MainForm.m_mainForm.notificationText1.ForeColor = value;
				MainForm.m_mainForm.notificationText2.ForeColor = value;
				MainForm.m_mainForm.notificationText3.ForeColor = value;
			}
		}

		[PropertyCategory("infomationBarCategory")]
		[TypeConverter(typeof(MyColorConverter))]
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
				if (value.IsEmpty)
				{
					value = Color.Black;
				}
				MainForm.m_mainForm.m_infomationBar.m_barColor = value;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					MainForm.m_mainForm.homePropertyGrid.Refresh();
				}
			}
		}

		[TypeConverter(typeof(MyColorConverter))]
		[PropertyCategory("infomationBarCategory")]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		[PropertyDisplayName("indicatorColor")]
		public Color m_indicatorColor
		{
			get
			{
				return m_indicatorColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value.IsEmpty)
				{
					value = Color.White;
				}
				MainForm.m_mainForm.m_infomationBar.m_indicatorColor = value;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					MainForm.m_mainForm.homePropertyGrid.Refresh();
				}
			}
		}

		public override bool CheckProperties()
		{
			bool result = true;
			string msg;
			if (!checkImageFile(out msg, m_filePath, 32, false, 960, 512, 614400L))
			{
				msg = "[" + GetPropertyCategory("m_filePath") + "] -> [" + GetPropertyDisplayName("m_filePath") + "] : " + m_filePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			return result;
		}

		private static RectangleF MeasurableLabel(Label label)
		{
			if (label.Text == null)
			{
				return new RectangleF(0f, 0f, 0f, 0f);
			}
			Bitmap bitmap = new Bitmap(1, 1);
			Graphics graphics = Graphics.FromImage(bitmap);
			CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
			{
				new CharacterRange(0, label.Text.Length)
			};
			StringFormat stringFormat = new StringFormat();
			stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
			Region[] array = graphics.MeasureCharacterRanges(label.Text, label.Font, new RectangleF(0f, 0f, 10000f, 10000f), stringFormat);
			if (array.Length == 0)
			{
				return new RectangleF(0f, 0f, 0f, 0f);
			}
			RectangleF bounds = array[0].GetBounds(graphics);
			graphics.Dispose();
			bitmap.Dispose();
			float num = label.Font.FontFamily.GetCellAscent(label.Font.Style);
			float num2 = label.Font.FontFamily.GetCellDescent(label.Font.Style);
			float num3 = label.Font.FontFamily.GetEmHeight(label.Font.Style);
			label.Font.FontFamily.GetLineSpacing(label.Font.Style);
			float num4 = MainForm.m_mainForm.m_dpi / 72f * label.Font.Size * (num2 / num3);
			float num5 = MainForm.m_mainForm.m_dpi / 72f * label.Font.Size * (num / num3);
			bounds.Y = num4;
			bounds.Height = num5 - num4;
			return bounds;
		}

		public StartScreenProperty()
		{
			m_filePath = null;
			m_dateColor = Color.White;
			m_dateLayout = DateLayoutEnum.LeftBottom;
			m_notifyBgColor = Color.FromArgb(31, 255, 255, 255);
			m_notifyBorderColor = Color.FromArgb(62, 255, 255, 255);
			m_notifyFontColor = Color.Black;
		}

		public void updateDateTimeLayout()
		{
			Point location = default(Point);
			Point location2 = default(Point);
			Point location3 = default(Point);
			RectangleF rectangleF = MeasurableLabel(MainForm.m_mainForm.timeLabel);
			RectangleF rectangleF2 = MeasurableLabel(MainForm.m_mainForm.dateLabel);
			RectangleF rectangleF3 = MeasurableLabel(MainForm.m_mainForm.meridianLabel);
			if (0 > m_dateTimePointTbl[(int)m_dateLayout].Y)
			{
				double num = (double)m_dateTimePointTbl[(int)m_dateLayout].Y * MainForm.m_mainForm.m_scale;
				location2.Y = MainForm.m_mainForm.startImage.Height + (int)num - (int)rectangleF.Height - (int)rectangleF.Top;
				location3.Y = MainForm.m_mainForm.startImage.Height + (int)num - (int)rectangleF3.Height - (int)rectangleF3.Top;
				location.Y = location2.Y + (int)rectangleF.Top - MainForm.m_mainForm.dateLabel.Height;
			}
			else
			{
				double num2 = (double)m_dateTimePointTbl[(int)m_dateLayout].Y * MainForm.m_mainForm.m_scale;
				location.Y = (int)num2 - (int)rectangleF2.Top;
				location2.Y = (int)num2 + MainForm.m_mainForm.dateLabel.Height - (int)rectangleF.Top;
				location3.Y = location2.Y + ((int)rectangleF.Height - (int)rectangleF3.Height + (int)rectangleF3.Top);
			}
			if (0 <= m_dateTimePointTbl[(int)m_dateLayout].X)
			{
				double num3 = (double)m_dateTimePointTbl[(int)m_dateLayout].X * MainForm.m_mainForm.m_scale;
				double num4 = (double)m_meridianPointTbl[(int)m_dateLayout].X * MainForm.m_mainForm.m_scale;
				double num5 = (double)m_datePointTbl[(int)m_dateLayout] * MainForm.m_mainForm.m_scale;
				location2.X = (int)num3 - (int)rectangleF.Right;
				location3.X = (int)num4 - (int)rectangleF3.Right;
				location.X = (int)num5 - (int)rectangleF2.Left;
			}
			else
			{
				double num6 = (double)m_dateTimePointTbl[(int)m_dateLayout].X * MainForm.m_mainForm.m_scale;
				double num7 = (double)m_meridianPointTbl[(int)m_dateLayout].X * MainForm.m_mainForm.m_scale;
				double num8 = (double)m_datePointTbl[(int)m_dateLayout] * MainForm.m_mainForm.m_scale;
				if (0f == rectangleF3.Width)
				{
					location2.X = MainForm.m_mainForm.startImage.Width + (int)num6 - (int)rectangleF.Width - (int)rectangleF.Left;
					location3.X = location2.X;
				}
				else
				{
					location3.X = MainForm.m_mainForm.startImage.Width + (int)num7 - (int)rectangleF3.Width - (int)rectangleF3.Left;
					location2.X = location3.X - (int)rectangleF.Width - (int)rectangleF.Left;
					num8 = -516.0 * MainForm.m_mainForm.m_scale;
				}
				location.X = MainForm.m_mainForm.startImage.Width + (int)num8 - (int)rectangleF2.Left;
			}
			MainForm.m_mainForm.dateLabel.Location = location;
			MainForm.m_mainForm.timeLabel.Location = location2;
			MainForm.m_mainForm.meridianLabel.Location = location3;
		}

		public void startImageLoaded()
		{
			if (MainForm.m_mainForm.startImage.Image != null)
			{
				Bitmap bitmap = new Bitmap(MainForm.m_mainForm.startImage.Image);
				Bitmap image = bitmap.Clone(new Rectangle(new Point(0, 0), bitmap.Size), PixelFormat.Format32bppRgb);
				MainForm.m_mainForm.startImage.Image = image;
			}
		}
	}
}
