using System.ComponentModel;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	public class LanguageParam
	{
		private string m_default_;

		private LanguagePartParam m_param_;

		[Save]
		[PropertyDisplayName("lang_default")]
		public string m_default
		{
			get
			{
				return m_default_;
			}
			set
			{
				m_default_ = value;
			}
		}

		[Save]
		[PropertyDisplayName("language")]
		public LanguagePartParam m_param
		{
			get
			{
				return m_param_;
			}
			set
			{
				m_param_ = value;
			}
		}

		public LanguageParam()
		{
			m_default = null;
			m_param = new LanguagePartParam();
		}
	}
}
