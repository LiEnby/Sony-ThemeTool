using System.ComponentModel;
using System.Drawing;

namespace theme_tool
{
	public class MyColorConverter : ColorConverter
	{
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return false;
		}
	}
}
