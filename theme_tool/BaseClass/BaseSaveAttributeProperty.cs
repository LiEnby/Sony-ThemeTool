using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;

namespace theme_tool.BaseClass
{
	public abstract class BaseSaveAttributeProperty
	{
		protected T GetPropertyAttribute<T>(string property_name) where T : Attribute
		{
			return GetPropertyAttribute<T>(this, property_name);
		}

		protected T GetPropertyAttribute<T>(object o, string property_name) where T : Attribute
		{
			PropertyInfo property = o.GetType().GetProperty(property_name);
			Attribute customAttribute = Attribute.GetCustomAttribute(property, typeof(T));
			return customAttribute as T;
		}

		protected string GetPropertyCategory(string property_name)
		{
			return GetPropertyCategory(this, property_name);
		}

		protected string GetPropertyCategory(object o, string property_name)
		{
			PropertyInfo property = o.GetType().GetProperty(property_name);
			return GetPropertyCategory(property);
		}

		protected string GetPropertyCategory(PropertyInfo pi)
		{
			string result = string.Empty;
			object[] customAttributes = pi.GetCustomAttributes(typeof(PropertyCategoryAttribute), false);
			if (0 < customAttributes.Length)
			{
				PropertyCategoryAttribute propertyCategoryAttribute = customAttributes[0] as PropertyCategoryAttribute;
				result = propertyCategoryAttribute.PropertyCategory;
			}
			return result;
		}

		protected string GetPropertyDisplayName(string property_name)
		{
			return GetPropertyDisplayName(this, property_name);
		}

		protected string GetPropertyDisplayName(object o, string property_name)
		{
			PropertyInfo property = o.GetType().GetProperty(property_name);
			return GetPropertyDisplayName(property);
		}

		protected string GetPropertyDisplayName(PropertyInfo pi)
		{
			string empty = string.Empty;
			object[] customAttributes = pi.GetCustomAttributes(typeof(PropertyDisplayNameAttribute), false);
			if (0 < customAttributes.Length)
			{
				PropertyDisplayNameAttribute propertyDisplayNameAttribute = customAttributes[0] as PropertyDisplayNameAttribute;
				return propertyDisplayNameAttribute.PropertyDisplayName;
			}
			return pi.Name;
		}

		protected bool checkStringNullOrEmpty(out string msg, string str)
		{
			msg = string.Empty;
			bool result = true;
			if (string.IsNullOrEmpty(str))
			{
				msg = ErrorMsg.GetString(ErrorMsg.DEFINES.EMPTY_STRING);
				msg += "\n";
				result = false;
			}
			return result;
		}

		protected bool checkStringByteSize(out string msg, string str, int max_bytes)
		{
			msg = string.Empty;
			bool result = true;
			Encoding encoding = Encoding.GetEncoding("utf-8");
			int byteCount = encoding.GetByteCount(str);
			if (max_bytes < byteCount)
			{
				msg = "\"" + str + "\"\n";
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_STRING_BYTE_SIZE);
				string text = msg;
				msg = text + byteCount + "/" + max_bytes + "(byte)\n";
				result = false;
			}
			return result;
		}

		protected bool checkStringLength(out string msg, string str, int max_length)
		{
			msg = string.Empty;
			bool result = true;
			if (max_length < str.Length)
			{
				msg = str + "\n";
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_PATH_LENGTH);
				string text = msg;
				msg = text + str.Length + "/" + max_length + "(chars)\n";
				result = false;
			}
			return result;
		}

		protected bool checkPageIndex(out string msg, int page, int max)
		{
			string @string = ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_PAGE_INDEX);
			ErrorMsg.GetString(ErrorMsg.DEFINES.LESS_PAGE_INDEX);
			bool flag = true;
			bool flag2 = true;
			string msg2 = string.Empty;
			string empty = string.Empty;
			msg = string.Empty;
			flag = checkOver(out msg2, @string, "(page)", page, max);
			bool result = true;
			if (!flag2)
			{
				result = false;
				msg += empty;
			}
			if (!flag)
			{
				result = false;
				msg += msg2;
			}
			return result;
		}

		protected bool checkImageFile(out string msg, string filepath, int max_w, int max_h)
		{
			return checkImageFile(out msg, filepath, -1, false, max_w, max_h, -1L);
		}

		protected bool checkImageFile(out string msg, string filepath, bool null_error_filepath, int max_w, int max_h)
		{
			return checkImageFile(out msg, filepath, -1, null_error_filepath, max_w, max_h, -1L);
		}

		protected bool checkImageFile(out string msg, string filepath, int max_filepath_length, bool null_error_filepath, int max_w, int max_h)
		{
			return checkImageFile(out msg, filepath, -1, null_error_filepath, max_w, max_h, -1L);
		}

		protected bool checkImageFile(out string msg, string filepath, int max_w, int max_h, long max_file_size)
		{
			return checkImageFile(out msg, filepath, -1, false, max_w, max_h, max_file_size);
		}

		protected bool checkImageFile(out string msg, string filepath, bool null_error_filepath, int max_w, int max_h, long max_file_size)
		{
			return checkImageFile(out msg, filepath, -1, null_error_filepath, max_w, max_h, max_file_size);
		}

		protected bool checkImageFile(out string msg, string filepath, int max_filepath_length, bool null_error_filepath, int max_w, int max_h, long max_file_size)
		{
			bool result = true;
			msg = string.Empty;
			if (string.IsNullOrEmpty(filepath))
			{
				if (null_error_filepath)
				{
					msg += ErrorMsg.GetString(ErrorMsg.DEFINES.EMPTY_STRING);
					msg += "\n";
					result = false;
				}
				return result;
			}
			string extension = Path.GetExtension(filepath);
			if (string.IsNullOrEmpty(extension))
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.INVALID_FILE_PATH);
				msg += "\n";
				return false;
			}
			if (extension.ToLower() != ".png")
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.NOT_PNG_FILE);
				msg += "\n";
				return false;
			}
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			if (0 < Path.GetFileNameWithoutExtension(filepath).IndexOfAny(invalidFileNameChars))
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.INVALID_CHARS_IN_FILEPATH);
				msg += "\n";
				return false;
			}
			if (!StrictCheckFileName_VITA(filepath))
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.INVALID_CHARS_IN_FILEPATH);
				msg += "\n";
				return false;
			}
			if (!File.Exists(filepath))
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.NOT_FOUND_FILE);
				msg += "\n";
				return false;
			}
			Image image = null;
			try
			{
				image = Image.FromFile(filepath);
			}
			catch (FileNotFoundException)
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.NOT_FOUND_FILE);
				msg += "\n";
				return false;
			}
			catch (OutOfMemoryException)
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.NOT_PNG_FILE);
				msg += "\n";
				return false;
			}
			catch (ArgumentException)
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.READ_FILE_FAILURE);
				msg += "\n";
				return false;
			}
			catch (Exception)
			{
				image = null;
			}
			if (!ImageFormat.Png.Equals(image.RawFormat))
			{
				result = false;
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.NOT_PNG_FILE);
				msg += "\n";
			}
			if (image == null)
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.READ_FILE_FAILURE);
				msg += "\n";
				return false;
			}
			string msg2;
			if (!checkFileSize(out msg2, filepath, max_file_size))
			{
				result = false;
				msg += msg2;
			}
			if (!checkWidth(out msg2, image.Width, max_w))
			{
				result = false;
				msg += msg2;
			}
			if (!checkHeight(out msg2, image.Height, max_h))
			{
				result = false;
				msg += msg2;
			}
			if (!checkPixelFormat_8bppIndexed(out msg2, filepath))
			{
				result = false;
				msg += msg2;
			}
			return result;
		}

		protected bool checkFileSize(out string msg, string filepath, long max_byte)
		{
			msg = string.Empty;
			if (max_byte <= 0)
			{
				return true;
			}
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			if (0 < Path.GetFileNameWithoutExtension(filepath).IndexOfAny(invalidFileNameChars))
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.INVALID_CHARS_IN_FILEPATH);
				msg += "\n";
				return false;
			}
			if (!StrictCheckFileName_VITA(filepath))
			{
				msg += ErrorMsg.GetString(ErrorMsg.DEFINES.INVALID_CHARS_IN_FILEPATH);
				msg += "\n";
				return false;
			}
			FileInfo fileInfo = new FileInfo(filepath);
			bool flag;
			if (fileInfo != null)
			{
				long value_unit = 1L;
				string post_msg = "(byte)";
				if (1048576 <= fileInfo.Length && 1048576 <= max_byte)
				{
					value_unit = 1048576L;
					post_msg = "(MiB)";
				}
				else if (1024 <= fileInfo.Length && 1024 <= max_byte)
				{
					value_unit = 1024L;
					post_msg = "(KiB)";
				}
				string @string = ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_FILE_SIZE);
				flag = checkOver(out msg, @string, post_msg, fileInfo.Length, max_byte, value_unit);
				if (!flag)
				{
					msg += "\n";
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		protected bool checkWidth(out string msg, int w, int max)
		{
			string @string = ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_IMAGE_WIDTH);
			bool result = checkValue(out msg, @string, "(pixel)", w, max);
			msg += "\n";
			return result;
		}

		protected bool checkHeight(out string msg, int h, int max)
		{
			string @string = ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_IMAGE_HEIGHT);
			bool result = checkValue(out msg, @string, "(pixel)", h, max);
			msg += "\n";
			return result;
		}

		protected bool checkPixelFormat_8bppIndexed(out string msg, string filepath)
		{
			msg = string.Empty;
			bool flag = true;
			try
			{
				BinaryReader binaryReader = new BinaryReader(File.OpenRead(filepath));
				byte[] array = new byte[32];
				binaryReader.Read(array, 0, 32);
				if (3 != array[25])
				{
					flag = false;
				}
			}
			catch
			{
				flag = false;
			}
			if (!flag)
			{
				msg = msg + ErrorMsg.GetString(ErrorMsg.DEFINES.NOT_INDEX_COLOR256) + "\n";
				msg += "\n";
			}
			return flag;
		}

		private bool checkOver(out string msg, string pre_msg, string post_msg, int v, int max)
		{
			return checkOver(out msg, pre_msg, post_msg, v, max, 1L);
		}

		private bool checkOver(out string msg, string pre_msg, string post_msg, int v, int max, int value_unit)
		{
			return checkOver(out msg, pre_msg, post_msg, (long)v, (long)max, (long)value_unit);
		}

		private bool checkOver(out string msg, string pre_msg, string post_msg, long v, long max, long value_unit)
		{
			msg = string.Empty;
			bool result = true;
			if (max < v)
			{
				if (value_unit == 0)
				{
					value_unit = 1L;
				}
				msg = pre_msg;
				msg = msg + v / value_unit + " / " + max / value_unit;
				msg += post_msg;
				result = false;
			}
			return result;
		}

		private bool checkOver(out string msg, string pre_msg, string post_msg, float v, float max)
		{
			msg = string.Empty;
			bool result = true;
			if (max < v)
			{
				msg = pre_msg;
				msg = msg + v + " / " + max;
				msg += post_msg;
				result = false;
			}
			return result;
		}

		private bool checkLess(out string msg, string pre_msg, string post_msg, int v, int min)
		{
			msg = string.Empty;
			bool result = true;
			if (v < min)
			{
				msg = pre_msg;
				msg = msg + v + " / " + min;
				msg += post_msg;
				result = false;
			}
			return result;
		}

		private bool checkValue(out string msg, string pre_msg, string post_msg, int v, int chkValue)
		{
			return checkValue(out msg, pre_msg, post_msg, v, chkValue, 1L);
		}

		private bool checkValue(out string msg, string pre_msg, string post_msg, int v, int chkValue, int value_unit)
		{
			return checkValue(out msg, pre_msg, post_msg, (long)v, (long)chkValue, (long)value_unit);
		}

		private bool checkValue(out string msg, string pre_msg, string post_msg, long v, long chkValue, long value_unit)
		{
			msg = string.Empty;
			bool result = true;
			if (chkValue != v)
			{
				if (value_unit == 0)
				{
					value_unit = 1L;
				}
				msg = pre_msg;
				msg = msg + v / value_unit + " / " + chkValue / value_unit;
				msg += post_msg;
				result = false;
			}
			return result;
		}

		public virtual bool CheckProperties()
		{
			return false;
		}

		public static bool StrictCheckFileName_VITA(string name)
		{
			if (name == null)
			{
				return true;
			}
			string fileName = Path.GetFileName(name);
			for (int i = 0; i < fileName.Length; i++)
			{
				if (!StrictCheckFileName_VITA(fileName[i]))
				{
					return false;
				}
			}
			return true;
		}

		private static bool StrictCheckFileName_VITA(char c)
		{
			char result;
			return StrictCheckFileName_VITA(c, out result);
		}

		private static bool StrictCheckFileName_VITA(char c, out char result)
		{
			result = c;
			if (' ' > c || c >= '\u007f')
			{
				return false;
			}
			if (0 <= "*:;?\"<>|\\/".IndexOf(c))
			{
				return false;
			}
			result = '\0';
			return true;
		}
	}
}
