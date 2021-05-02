using System;
using System.ComponentModel;
using System.Globalization;

namespace theme_tool
{
	public class PropertyDisplayConverter : TypeConverter
	{
		public PropertyDescriptorCollection m_collection;

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object instance, Attribute[] filters)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance, filters, true);
			foreach (PropertyDescriptor item in properties)
			{
				if (instance is BackgroundParam)
				{
					if ("m_fontColor" == item.Name || "m_fontShadow" == item.Name)
					{
						BackgroundParam backgroundParam = instance as BackgroundParam;
						if (backgroundParam.m_imageFilePath == null || backgroundParam.m_imageFilePath.Length == 0)
						{
							propertyDescriptorCollection.Add(new PropertyDisplayPropertyDescriptor(item, propertyDescriptorCollection, true));
						}
						else
						{
							propertyDescriptorCollection.Add(new PropertyDisplayPropertyDescriptor(item, propertyDescriptorCollection));
						}
					}
					else
					{
						propertyDescriptorCollection.Add(new PropertyDisplayPropertyDescriptor(item, propertyDescriptorCollection));
					}
				}
				else if (MainForm.m_mainForm.m_package == Package.Normal)
				{
					if (!("m_store" == item.DisplayName) && !("m_welcomePark" == item.DisplayName) && !("m_map" == item.DisplayName) && !("m_iconPos" == item.DisplayName) && !("m_pagePos" == item.DisplayName))
					{
						propertyDescriptorCollection.Add(new PropertyDisplayPropertyDescriptor(item));
					}
				}
				else if (Package.VitaPreInstall == MainForm.m_mainForm.m_package && !("m_power" == item.DisplayName))
				{
					propertyDescriptorCollection.Add(new PropertyDisplayPropertyDescriptor(item));
				}
			}
			m_collection = propertyDescriptorCollection;
			return propertyDescriptorCollection;
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && (value is LanguageParam || value is LanguagePartParam))
			{
				return "";
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
