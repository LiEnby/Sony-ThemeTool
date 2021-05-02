using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Text;
using theme_tool.BaseClass;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	[Save]
	public class InfomationProperty : BaseSaveAttributeProperty
	{
		private string m_contentVer_;

		private LanguageParam m_title_;

		private LanguageParam m_provider_;

		private string m_homePreviewFilePath_;

		private string m_startPreviewFilePath_;

		private string m_packageImageFilePath_;

		[PropertyCategory("infomation")]
		[PropertyDisplayName("version")]
		[Save]
		public string m_contentVer
		{
			get
			{
				return m_contentVer_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_contentVer_ = value;
			}
		}

		[PropertyCategory("infomation")]
		[PropertyDisplayName("title")]
		[Save]
		public LanguageParam m_title
		{
			get
			{
				return m_title_;
			}
			set
			{
				m_title_ = value;
			}
		}

		[Save]
		[PropertyCategory("infomation")]
		[PropertyDisplayName("provider")]
		public LanguageParam m_provider
		{
			get
			{
				return m_provider_;
			}
			set
			{
				m_provider_ = value;
			}
		}

		[PropertyCategory("preview")]
		[PropertyDisplayName("home")]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[Save]
		[FilePath]
		public string m_homePreviewFilePath
		{
			get
			{
				return m_homePreviewFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_homePreviewFilePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.previewHomePictureBox.ImageLocation = value;
			}
		}

		[Save]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		[FilePath]
		[PropertyCategory("preview")]
		[PropertyDisplayName("startscreen")]
		public string m_startPreviewFilePath
		{
			get
			{
				return m_startPreviewFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_startPreviewFilePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.previewStartPictureBox.ImageLocation = value;
			}
		}

		[Save]
		[FilePath]
		[PropertyCategory("infomation")]
		[PropertyDisplayName("package")]
		[Editor(typeof(PngOpenFileDialog), typeof(UITypeEditor))]
		public string m_packageImageFilePath
		{
			get
			{
				return m_packageImageFilePath_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				m_packageImageFilePath_ = Utility.getRelativePath(value);
				MainForm.m_mainForm.pkgPictureBox.ImageLocation = value;
			}
		}

		public override bool CheckProperties()
		{
			bool result = true;
			string msg;
			if (!checkImageFile(out msg, m_packageImageFilePath, 226, 128, 49152L))
			{
				msg = "[" + GetPropertyCategory("m_packageImageFilePath") + "] -> [" + GetPropertyDisplayName("m_packageImageFilePath") + "] : " + m_packageImageFilePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			if (!checkImageFile(out msg, m_homePreviewFilePath, 480, 272, 133120L))
			{
				msg = "[" + GetPropertyCategory("m_homePreviewFilePath") + "] -> [" + GetPropertyDisplayName("m_homePreviewFilePath") + "] : " + m_homePreviewFilePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			if (!checkImageFile(out msg, m_startPreviewFilePath, 480, 272, 133120L))
			{
				msg = "[" + GetPropertyCategory("m_startPreviewFilePath") + "] -> [" + GetPropertyDisplayName("m_startPreviewFilePath") + "] : " + m_startPreviewFilePath + "\n" + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			if (0 < m_contentVer.Length)
			{
				bool flag = false;
				if (5 == m_contentVer.Length)
				{
					try
					{
						int.Parse(m_contentVer.Substring(0, 1), NumberStyles.Number);
						int.Parse(m_contentVer.Substring(1, 1), NumberStyles.Number);
						int.Parse(m_contentVer.Substring(3, 1), NumberStyles.Number);
						int.Parse(m_contentVer.Substring(4, 1), NumberStyles.Number);
					}
					catch
					{
						flag = true;
					}
					if ('.' != m_contentVer[2])
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					msg = "[" + GetPropertyCategory("m_contentVer") + "] -> [" + GetPropertyDisplayName("m_contentVer") + "] : " + m_contentVer + "\n" + msg;
					Dialog.AddMsg(msg);
					result = false;
				}
			}
			string empty = string.Empty;
			empty = "[" + GetPropertyCategory("m_provider") + "] -> [" + GetPropertyDisplayName("m_provider") + "] -> ";
			if (!checkLangaugeParam(m_provider, empty))
			{
				result = false;
			}
			empty = "[" + GetPropertyCategory("m_title") + "] -> [" + GetPropertyDisplayName("m_title") + "] -> ";
			if (!checkLangaugeParam(m_title, empty))
			{
				result = false;
			}
			return result;
		}

		private bool checkLangaugeParam(LanguageParam lp, string prefix)
		{
			bool result = true;
			Encoding.GetEncoding("utf-8");
			string msg;
			if (lp.m_param != null)
			{
				PropertyInfo[] properties = lp.m_param.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(SaveAttribute), false);
					if (0 < customAttributes.Length)
					{
						string text = (string)propertyInfo.GetValue(lp.m_param, null);
						if (!string.IsNullOrEmpty(text) && !checkStringByteSize(out msg, text, 127))
						{
							string text2 = "[" + GetPropertyDisplayName(lp, "m_param") + "] -> [" + GetPropertyDisplayName(propertyInfo) + "] : ";
							msg = prefix + text2 + msg;
							Dialog.AddMsg(msg);
							result = false;
						}
					}
				}
			}
			if (!checkStringNullOrEmpty(out msg, lp.m_default))
			{
				msg = prefix + "[" + GetPropertyDisplayName(lp, "m_default") + "] : " + msg;
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.MUST_PARAMETER);
				msg += "\n";
				Dialog.AddMsg(msg);
				result = false;
			}
			else if (!checkStringByteSize(out msg, lp.m_default, 127))
			{
				msg = prefix + "[" + GetPropertyDisplayName(lp, "m_default") + "] : " + msg;
				Dialog.AddMsg(msg);
				result = false;
			}
			return result;
		}

		public InfomationProperty()
		{
			m_title = new LanguageParam();
			m_provider = new LanguageParam();
			m_contentVer = "01.00";
			MainForm.m_mainForm.previewHomePictureBox.ImageLocation = null;
			MainForm.m_mainForm.previewHomePictureBox.Image = null;
			MainForm.m_mainForm.previewStartPictureBox.ImageLocation = null;
			MainForm.m_mainForm.previewStartPictureBox.Image = null;
			MainForm.m_mainForm.pkgPictureBox.ImageLocation = null;
			MainForm.m_mainForm.pkgPictureBox.Image = null;
		}
	}
}
