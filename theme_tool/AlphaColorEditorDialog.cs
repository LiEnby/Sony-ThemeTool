using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace theme_tool
{
	public class AlphaColorEditorDialog : UITypeEditor
	{
		private AlphaColorDialog m_editorUi;

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs e)
		{
			Color color = (Color)e.Value;
			e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (m_editorUi == null)
			{
				m_editorUi = new AlphaColorDialog();
			}
			m_editorUi.Color = (Color)value;
			if (m_editorUi.ShowDialog() == DialogResult.OK)
			{
				return m_editorUi.Color;
			}
			return value;
		}
	}
}
