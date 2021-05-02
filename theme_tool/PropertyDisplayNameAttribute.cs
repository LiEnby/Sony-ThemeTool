using System;
using theme_tool.resource;

namespace theme_tool
{
	[AttributeUsage(AttributeTargets.Property)]
	internal class PropertyDisplayNameAttribute : Attribute
	{
		private string myPropertyDisplayName;

		public string PropertyDisplayName
		{
			get
			{
				return myPropertyDisplayName;
			}
		}

		public PropertyDisplayNameAttribute(string name)
		{
			myPropertyDisplayName = theme.ResourceManager.GetString(name, theme.Culture);
		}
	}
}
