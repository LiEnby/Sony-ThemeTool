using System;
using System.ComponentModel;
using System.Globalization;

namespace theme_tool
{
	public class PosOnlyIconPropertyDisplayConverter : TypeConverter
	{
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object instance, Attribute[] filters)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance, filters, true);
			foreach (PropertyDescriptor item in properties)
			{
				if (!("m_iconFilePath" == item.DisplayName))
				{
					propertyDescriptorCollection.Add(new PropertyDisplayPropertyDescriptor(item));
				}
			}
			return propertyDescriptorCollection;
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
