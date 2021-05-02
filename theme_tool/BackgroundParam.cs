using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using theme_tool.Properties;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	public class BackgroundParam
	{
		public readonly int m_paramIdx = -1;

		private string m_imageFilePath_;

		public static readonly NativeWaveType[] s_nativeWaveType = new NativeWaveType[31]
		{
			NativeWaveType.BLACK,
			NativeWaveType.DEFAULT,
			NativeWaveType.A5,
			NativeWaveType.DALIA,
			NativeWaveType.GRAY_FLAT,
			NativeWaveType.BLUE_FLAT,
			NativeWaveType.BLUETB_0513_01,
			NativeWaveType.ORANGE,
			NativeWaveType.KOIAO_0512_01,
			NativeWaveType.TURQUOISE_0513_01,
			NativeWaveType.COLOR_VARI_2G_03,
			NativeWaveType.MARRYGOLD,
			NativeWaveType.PEACH_0512_001,
			NativeWaveType.COLOR_VARI_2G_01,
			NativeWaveType.COLOR_VARI_2G_02,
			NativeWaveType.GREEN_0512_01,
			NativeWaveType.LIMEGREEN_0513_02,
			NativeWaveType.COLOR_VARI_2G_04,
			NativeWaveType.YELLOW_0512_01,
			NativeWaveType.CASIS,
			NativeWaveType.PURPLE_02,
			NativeWaveType.MAINTOSH,
			NativeWaveType.PURPLE_03,
			NativeWaveType.REDTB_0513_01,
			NativeWaveType.RUBY,
			NativeWaveType.PURPLE_01,
			NativeWaveType.RUBY2,
			NativeWaveType.PURPLERED,
			NativeWaveType.A1,
			NativeWaveType.BLUEWHITE_05,
			NativeWaveType.INITBOOT
		};

		public static readonly WaveType[] s_waveType = new WaveType[31]
		{
			WaveType.BLUE01,
			WaveType.WHITE01,
			WaveType.RED01,
			WaveType.RED02,
			WaveType.BLUE07,
			WaveType.PURPLE01,
			WaveType.BLUE02,
			WaveType.BLUE03,
			WaveType.BLUE04,
			WaveType.RED03,
			WaveType.YELLOW01,
			WaveType.BLACK01,
			WaveType.BLUE05,
			WaveType.BLUE06,
			WaveType.YELLOW02,
			WaveType.PINK01,
			WaveType.GREEN03,
			WaveType.BLUE08,
			WaveType.PURPLE02,
			WaveType.BROWN01,
			WaveType.BROWN02,
			WaveType.PURPLE03,
			WaveType.RED04,
			WaveType.GREY02,
			WaveType.PURPLE04,
			WaveType.GREEN04,
			WaveType.BLUE09,
			WaveType.GREEN01,
			WaveType.GREEN02,
			WaveType.BLUE10,
			WaveType.GREY01
		};

		public static readonly Bitmap[] s_waveImage = new Bitmap[31]
		{
			Resources.black,
			Resources._default,
			Resources._0415a5,
			Resources._0518dalia,
			Resources._0518grayflat,
			Resources.blueflat,
			Resources.bluetb051301,
			Resources._0408orange,
			Resources.koiao0512,
			Resources.turquoise0513,
			Resources.colorvari2g03,
			Resources.marrygold,
			Resources.peach0512,
			Resources.colorvari2g01,
			Resources.colorvari2g02,
			Resources.green0512,
			Resources.limegreen0513,
			Resources.colorvari2g04,
			Resources.yellow0512,
			Resources.casis,
			Resources._0411purple02,
			Resources.maintosh,
			Resources.purple01,
			Resources.redtb0513,
			Resources._0518ruby,
			Resources._0407purple01,
			Resources._0406ruby,
			Resources.purplered,
			Resources.a1,
			Resources.bluewhite05,
			Resources.initboot
		};

		private WaveType m_waveType_ = WaveType.BLUE01;

		private Color m_fontColor_;

		private OnOffType m_fontShadow_;

		public IconParam[] m_iconLayouts = new IconParam[10];

		[Save]
		[PropertyDisplayName("image")]
		[FilePath]
		[Thumbnail]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		public string m_imageFilePath
		{
			get
			{
				return m_imageFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_imageFilePath_ = Utility.getRelativePath(value);
				if (m_imageFilePath_ == null || m_imageFilePath_.Length == 0)
				{
					m_fontColor_ = Color.White;
					m_fontShadow_ = OnOffType.On;
					setFontColor();
				}
				MainForm.m_mainForm.homePropertyGrid.Refresh();
				if (MainForm.m_mainForm.homeScreenTab.SelectedIndex != m_paramIdx)
				{
					return;
				}
				MainForm.m_mainForm.homeBgPictureBox1.ImageLocation = m_imageFilePath_;
				if (!MainForm.m_mainForm.m_refreshInvalid)
				{
					MainForm.m_mainForm.homeBgPictureBox1.Refresh();
					if (m_imageFilePath_ == null || m_imageFilePath_.Length == 0)
					{
						MainForm.m_mainForm.notifyRefresh();
					}
				}
			}
		}

		[PropertyDisplayName("wave")]
		[Wave]
		[Save]
		public WaveType m_waveType
		{
			get
			{
				return m_waveType_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_waveType_ = value;
				if (MainForm.m_mainForm.homeScreenTab.SelectedIndex == m_paramIdx)
				{
					MainForm.m_mainForm.homePictureBox1.Image = getWaveImage();
					if (!MainForm.m_mainForm.m_refreshInvalid)
					{
						MainForm.m_mainForm.homePictureBox1.Refresh();
						MainForm.m_mainForm.notifyRefresh();
					}
				}
			}
		}

		[PropertyDisplayName("fontColor")]
		[TypeConverter(typeof(MyColorConverter))]
		[Save]
		[Editor(typeof(ColorEditorDialog), typeof(UITypeEditor))]
		public Color m_fontColor
		{
			get
			{
				return m_fontColor_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_fontColor_ = value;
				if (MainForm.m_mainForm.homeScreenTab.SelectedIndex == m_paramIdx)
				{
					setFontColor();
					if (!MainForm.m_mainForm.m_refreshInvalid)
					{
						MainForm.m_mainForm.homePictureBox1.Refresh();
					}
				}
			}
		}

		[PropertyDisplayName("fontShadow")]
		[Save]
		public OnOffType m_fontShadow
		{
			get
			{
				return m_fontShadow_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_fontShadow_ = value;
			}
		}

		public static NativeWaveType getNativeWaveType(WaveType waveType)
		{
			return s_nativeWaveType[(int)waveType];
		}

		public BackgroundParam(int paramIdx)
		{
			m_paramIdx = paramIdx;
			m_fontColor = Color.White;
			m_fontShadow = OnOffType.On;
			m_imageFilePath = null;
		}

		public Bitmap getWaveImage()
		{
			return s_waveImage[(int)m_waveType];
		}

		public override string ToString()
		{
			return string.Format("{0},{1}", m_imageFilePath_, m_waveType.ToString());
		}

		public void setPanel()
		{
			int num = 0;
			IconParam[] iconLayouts = m_iconLayouts;
			foreach (IconParam iconParam in iconLayouts)
			{
				if (iconParam != null)
				{
					iconParam.setHomePanel(num, m_fontColor);
				}
				num++;
			}
			MainForm.m_mainForm.setBackHomePictureBox();
		}

		public void setFontColor()
		{
			int num = 0;
			IconParam[] iconLayouts = m_iconLayouts;
			foreach (IconParam iconParam in iconLayouts)
			{
				if (iconParam != null)
				{
					iconParam.setFontColor(m_fontColor);
				}
				num++;
			}
		}
	}
}
