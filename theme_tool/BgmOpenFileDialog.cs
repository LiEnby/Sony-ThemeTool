using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace theme_tool
{
	public class BgmOpenFileDialog : UITypeEditor
	{
		private OpenFileDialog m_editorUi;

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (m_editorUi == null)
			{
				m_editorUi = new OpenFileDialog();
				m_editorUi.Filter = "ATRAC9 Files (*.at9)|*.at9";
				m_editorUi.CheckFileExists = true;
			}
			m_editorUi.FileName = value as string;
			if (m_editorUi.ShowDialog() == DialogResult.OK)
			{
				return m_editorUi.FileName;
			}
			return value;
		}
	}
}
