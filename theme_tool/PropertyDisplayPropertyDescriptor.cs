using System;
using System.ComponentModel;
using System.Drawing;

namespace theme_tool
{
	public class PropertyDisplayPropertyDescriptor : PropertyDescriptor
	{
		private PropertyDescriptor oneProperty;

		private PropertyDescriptorCollection oneCollection;

		private bool m_readOnly;

		public override Type ComponentType
		{
			get
			{
				return oneProperty.ComponentType;
			}
		}

		public override string Description
		{
			get
			{
				return oneProperty.Description;
			}
		}

		public override bool IsReadOnly
		{
			get
			{
				if (m_readOnly)
				{
					return true;
				}
				return oneProperty.IsReadOnly;
			}
		}

		public override Type PropertyType
		{
			get
			{
				return oneProperty.PropertyType;
			}
		}

		public override string Category
		{
			get
			{
				PropertyCategoryAttribute propertyCategoryAttribute = (PropertyCategoryAttribute)oneProperty.Attributes[typeof(PropertyCategoryAttribute)];
				if (propertyCategoryAttribute != null)
				{
					return propertyCategoryAttribute.PropertyCategory;
				}
				return oneProperty.Category;
			}
		}

		public override string DisplayName
		{
			get
			{
				PropertyDisplayNameAttribute propertyDisplayNameAttribute = (PropertyDisplayNameAttribute)oneProperty.Attributes[typeof(PropertyDisplayNameAttribute)];
				if (propertyDisplayNameAttribute != null)
				{
					return propertyDisplayNameAttribute.PropertyDisplayName;
				}
				return oneProperty.DisplayName;
			}
		}

		public PropertyDisplayPropertyDescriptor(PropertyDescriptor desc, PropertyDescriptorCollection collection = null, bool readOnly = false)
			: base(desc)
		{
			oneProperty = desc;
			oneCollection = collection;
			m_readOnly = readOnly;
		}

		public override bool CanResetValue(object component)
		{
			return oneProperty.CanResetValue(component);
		}

		public override object GetValue(object component)
		{
			return oneProperty.GetValue(component);
		}

		public override void ResetValue(object component)
		{
			oneProperty.ResetValue(component);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return oneProperty.ShouldSerializeValue(component);
		}

		public override void SetValue(object component, object value)
		{
			oneProperty.SetValue(component, value);
			if (!(component is BackgroundParam) || !("m_imageFilePath" == oneProperty.Name))
			{
				return;
			}
			string text = value as string;
			bool readOnly = false;
			if (text == null || text.Length == 0)
			{
				BackgroundParam backgroundParam = component as BackgroundParam;
				backgroundParam.m_fontShadow = OnOffType.On;
				backgroundParam.m_fontColor = Color.White;
				readOnly = true;
			}
			if (oneCollection == null)
			{
				return;
			}
			foreach (PropertyDescriptor item in oneCollection)
			{
				PropertyDisplayPropertyDescriptor propertyDisplayPropertyDescriptor = item as PropertyDisplayPropertyDescriptor;
				if ("m_fontColor" == propertyDisplayPropertyDescriptor.Name || "m_fontShadow" == propertyDisplayPropertyDescriptor.Name)
				{
					propertyDisplayPropertyDescriptor.m_readOnly = readOnly;
				}
			}
		}
	}
}
