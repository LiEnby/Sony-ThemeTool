using System;
using System.ComponentModel;
using System.Globalization;

namespace theme_tool
{
	public class CustomArrayConverter : ArrayConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is BackgroundParam[])
			{
				return "";
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
