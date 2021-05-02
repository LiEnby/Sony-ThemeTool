using System.ComponentModel;

namespace theme_tool
{
	[TypeConverter(typeof(PropertyDisplayConverter))]
	public class LanguagePartParam
	{
		private string m_ja_;

		private string m_en_;

		private string m_fr_;

		private string m_es_;

		private string m_de_;

		private string m_it_;

		private string m_nl_;

		private string m_pt_;

		private string m_ru_;

		private string m_ko_;

		private string m_ch_;

		private string m_zh_;

		private string m_fi_;

		private string m_sv_;

		private string m_da_;

		private string m_no_;

		private string m_pl_;

		private string m_en_gb_;

		private string m_pt_br_;

		private string m_tr_;

		[PropertyDisplayName("lang_ja")]
		[Save]
		public string m_ja
		{
			get
			{
				return m_ja_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_ja_ = value;
				}
				else
				{
					m_ja_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_en")]
		public string m_en
		{
			get
			{
				return m_en_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_en_ = value;
				}
				else
				{
					m_en_ = null;
				}
			}
		}

		[PropertyDisplayName("lang_fr")]
		[Save]
		public string m_fr
		{
			get
			{
				return m_fr_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_fr_ = value;
				}
				else
				{
					m_fr_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_es")]
		public string m_es
		{
			get
			{
				return m_es_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_es_ = value;
				}
				else
				{
					m_es_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_de")]
		public string m_de
		{
			get
			{
				return m_de_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_de_ = value;
				}
				else
				{
					m_de_ = null;
				}
			}
		}

		[PropertyDisplayName("lang_it")]
		[Save]
		public string m_it
		{
			get
			{
				return m_it_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_it_ = value;
				}
				else
				{
					m_it_ = null;
				}
			}
		}

		[PropertyDisplayName("lang_nl")]
		[Save]
		public string m_nl
		{
			get
			{
				return m_nl_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_nl_ = value;
				}
				else
				{
					m_nl_ = null;
				}
			}
		}

		[PropertyDisplayName("lang_pt")]
		[Save]
		public string m_pt
		{
			get
			{
				return m_pt_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_pt_ = value;
				}
				else
				{
					m_pt_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_ru")]
		public string m_ru
		{
			get
			{
				return m_ru_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_ru_ = value;
				}
				else
				{
					m_ru_ = null;
				}
			}
		}

		[PropertyDisplayName("lang_ko")]
		[Save]
		public string m_ko
		{
			get
			{
				return m_ko_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_ko_ = value;
				}
				else
				{
					m_ko_ = null;
				}
			}
		}

		[PropertyDisplayName("lang_ch")]
		[Save]
		public string m_ch
		{
			get
			{
				return m_ch_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_ch_ = value;
				}
				else
				{
					m_ch_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_zh")]
		public string m_zh
		{
			get
			{
				return m_zh_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_zh_ = value;
				}
				else
				{
					m_zh_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_fi")]
		public string m_fi
		{
			get
			{
				return m_fi_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_fi_ = value;
				}
				else
				{
					m_fi_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_sv")]
		public string m_sv
		{
			get
			{
				return m_sv_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_sv_ = value;
				}
				else
				{
					m_sv_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_da")]
		public string m_da
		{
			get
			{
				return m_da_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_da_ = value;
				}
				else
				{
					m_da_ = null;
				}
			}
		}

		[PropertyDisplayName("lang_no")]
		[Save]
		public string m_no
		{
			get
			{
				return m_no_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_no_ = value;
				}
				else
				{
					m_no_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_pl")]
		public string m_pl
		{
			get
			{
				return m_pl_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_pl_ = value;
				}
				else
				{
					m_pl_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_en_gb")]
		public string m_en_gb
		{
			get
			{
				return m_en_gb_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_en_gb_ = value;
				}
				else
				{
					m_en_gb_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_pt_br")]
		public string m_pt_br
		{
			get
			{
				return m_pt_br_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_pt_br_ = value;
				}
				else
				{
					m_pt_br_ = null;
				}
			}
		}

		[Save]
		[PropertyDisplayName("lang_tr")]
		public string m_tr
		{
			get
			{
				return m_tr_;
			}
			set
			{
				MainForm.m_mainForm.setEdit();
				if (value != null && 0 < value.Length)
				{
					m_tr_ = value;
				}
				else
				{
					m_tr_ = null;
				}
			}
		}

		public LanguagePartParam()
		{
			m_ja = null;
			m_en = null;
			m_fr = null;
			m_es = null;
			m_de = null;
			m_it = null;
			m_nl = null;
			m_pt = null;
			m_ru = null;
			m_ko = null;
			m_ch = null;
			m_zh = null;
			m_fi = null;
			m_sv = null;
			m_da = null;
			m_no = null;
			m_pl = null;
			m_en_gb = null;
			m_pt_br = null;
			m_tr = null;
		}
	}
}
