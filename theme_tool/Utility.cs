using System;
using System.IO;
using System.Windows.Forms;

namespace theme_tool
{
	public class Utility
	{
		public class TransparentPictureBox : PictureBox
		{
		}

		public static string getRelativePath(string aPath)
		{
			if (string.IsNullOrEmpty(aPath))
			{
				return null;
			}
			string uriString = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
			if (!Path.IsPathRooted(aPath))
			{
				return aPath;
			}
			try
			{
				Uri uri = new Uri(aPath);
				Uri uri2 = new Uri(uriString);
				string text = Uri.UnescapeDataString(uri2.MakeRelativeUri(uri).ToString());
				return text.Replace('/', Path.DirectorySeparatorChar);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
