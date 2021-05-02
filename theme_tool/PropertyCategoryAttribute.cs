using System;
using theme_tool.resource;

namespace theme_tool
{
	[AttributeUsage(AttributeTargets.Property)]
	internal class PropertyCategoryAttribute : Attribute
	{
		private string myPropertyCategory;

		public string PropertyCategory
		{
			get
			{
				return myPropertyCategory;
			}
		}

		public PropertyCategoryAttribute(string name)
		{
			myPropertyCategory = theme.ResourceManager.GetString(name, theme.Culture);
		}
	}
}
