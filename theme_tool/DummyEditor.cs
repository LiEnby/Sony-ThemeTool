using System.ComponentModel;
using System.Drawing.Design;

namespace theme_tool
{
	public class DummyEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.None;
		}
	}
}
