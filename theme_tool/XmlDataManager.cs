using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using theme_tool.BaseClass;

namespace theme_tool
{
	public class XmlDataManager
	{
		private static readonly string m_exportXmlName = "theme.xml";

		private static void internalClassSave(object classObj, ref XmlTextWriter writer, string envCutDir, string dirName)
		{
			PropertyInfo[] properties = classObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				IEnumerable<object> source = from n2 in propertyInfo.GetCustomAttributes(true)
					where n2 is SaveAttribute
					select n2;
				if (0 < source.Count())
				{
					propertySave(propertyInfo, classObj, ref writer, envCutDir, dirName);
				}
			}
		}

		private static void classSave(object classObj, ref XmlTextWriter writer, string envCutDir, string dirName)
		{
			writer.WriteStartElement(classObj.GetType().Name);
			internalClassSave(classObj, ref writer, envCutDir, dirName);
			writer.WriteEndElement();
		}

		private static void propertySave(PropertyInfo property, object classObj, ref XmlTextWriter writer, string envCutDir, string dirName)
		{
			MethodInfo getMethod = property.GetGetMethod();
			Type returnType = getMethod.ReturnType;
			if (typeof(string) == returnType)
			{
				string text = (string)getMethod.Invoke(classObj, null);
				if (text != null)
				{
					if (property.GetCustomAttributes(typeof(FilePathAttribute), true).Length != 0)
					{
						string path = Path.Combine(envCutDir, text);
						path = Path.GetFullPath(path);
						Uri uri = new Uri(path);
						Uri uri2 = new Uri(dirName);
						text = Uri.UnescapeDataString(uri2.MakeRelativeUri(uri).ToString());
						text.Replace('/', Path.DirectorySeparatorChar);
						string currentDirectory = Directory.GetCurrentDirectory();
						Directory.SetCurrentDirectory(dirName);
						property.SetValue(classObj, text, null);
						Directory.SetCurrentDirectory(currentDirectory);
					}
					writer.WriteElementString(property.Name, text);
				}
			}
			else if (typeof(int) == returnType)
			{
				int num = (int)getMethod.Invoke(classObj, null);
				if (0 <= num)
				{
					writer.WriteElementString(property.Name, getMethod.Invoke(classObj, null).ToString());
				}
			}
			else if (typeof(Color) == returnType)
			{
				writer.WriteElementString(property.Name, ((Color)getMethod.Invoke(classObj, null)).ToArgb().ToString("x8"));
			}
			else if (returnType.IsEnum)
			{
				int num2 = (int)getMethod.Invoke(classObj, null);
				if (property.GetCustomAttributes(typeof(WaveAttribute), true).Length != 0)
				{
					num2 = (int)BackgroundParam.s_nativeWaveType[num2];
				}
				writer.WriteElementString(property.Name, num2.ToString());
			}
			else if (returnType.IsArray)
			{
				Array array = (Array)getMethod.Invoke(classObj, null);
				writer.WriteStartElement(property.Name);
				foreach (object item in array)
				{
					classSave(item, ref writer, envCutDir, dirName);
				}
				writer.WriteEndElement();
			}
			else if (returnType.IsClass)
			{
				object classObj2 = getMethod.Invoke(classObj, null);
				writer.WriteStartElement(property.Name);
				internalClassSave(classObj2, ref writer, envCutDir, dirName);
				writer.WriteEndElement();
			}
		}

		public static void save(string filename)
		{
			string dirName = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar;
			string envCutDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
			XmlTextWriter writer = new XmlTextWriter(filename, Encoding.UTF8);
			writer.WriteStartDocument();
			writer.WriteStartElement("theme");
			writer.WriteAttributeString("format-ver", "01.00");
			XmlTextWriter xmlTextWriter = writer;
			int package = (int)MainForm.m_mainForm.m_package;
			xmlTextWriter.WriteAttributeString("package", package.ToString());
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					if (type.GetCustomAttributes(typeof(SaveAttribute), true).Length != 0)
					{
						object classObj = null;
						if (type.Equals(typeof(StartScreenProperty)))
						{
							classObj = MainForm.m_mainForm.startPropertyGrid.SelectedObject;
						}
						else if (type.Equals(typeof(InfomationBarProperty)))
						{
							classObj = MainForm.m_mainForm.m_infomationBar;
						}
						else if (type.Equals(typeof(HomeProperty)))
						{
							classObj = MainForm.m_mainForm.m_home;
						}
						else if (type.Equals(typeof(InfomationProperty)))
						{
							classObj = MainForm.m_mainForm.m_infoProperty;
						}
						classSave(classObj, ref writer, envCutDir, dirName);
					}
				}
			}
			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Close();
		}

		private static void propertyLoad(PropertyInfo property, object classObj, XmlNode propNode, string dirName)
		{
			property.GetSetMethod();
			Type returnType = property.GetGetMethod().ReturnType;
			if (typeof(string) == returnType)
			{
				XmlNode firstChild = propNode.FirstChild;
				if (firstChild != null)
				{
					string text = firstChild.Value;
					if (property.GetCustomAttributes(typeof(FilePathAttribute), true).Length != 0)
					{
						text = Path.Combine(dirName, text);
						text = Path.GetFullPath(text);
					}
					property.SetValue(classObj, text, null);
				}
			}
			else if (typeof(int) == returnType)
			{
				XmlNode firstChild2 = propNode.FirstChild;
				if ((property.GetCustomAttributes(typeof(PkgNormalHideAttribute), true).Length == 0 || MainForm.m_mainForm.m_package != 0) && firstChild2 != null)
				{
					int num = int.Parse(firstChild2.Value);
					property.SetValue(classObj, num, null);
				}
			}
			else if (typeof(Color) == returnType)
			{
				XmlNode firstChild3 = propNode.FirstChild;
				if (firstChild3 != null)
				{
					Color color = Color.FromArgb(int.Parse(firstChild3.Value, NumberStyles.HexNumber));
					property.SetValue(classObj, color, null);
				}
			}
			else if (returnType.IsEnum)
			{
				XmlNode firstChild4 = propNode.FirstChild;
				if (firstChild4 != null)
				{
					int num2 = int.Parse(firstChild4.Value);
					if (property.GetCustomAttributes(typeof(WaveAttribute), true).Length != 0)
					{
						num2 = (int)BackgroundParam.s_waveType[num2];
					}
					property.SetValue(classObj, num2, null);
				}
			}
			else if (returnType.IsArray)
			{
				Array array = (Array)property.GetGetMethod().Invoke(classObj, null);
				int num3 = 0;
				foreach (XmlNode childNode in propNode.ChildNodes)
				{
					classLoad(array.GetValue(num3), childNode, dirName);
					num3++;
				}
			}
			else if (returnType.IsClass)
			{
				object classObj2 = property.GetGetMethod().Invoke(classObj, null);
				classLoad(classObj2, propNode, dirName);
			}
		}

		private static void classLoad(object classObj, XmlNode classNode, string dirName)
		{
			classObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			foreach (XmlNode childNode in classNode.ChildNodes)
			{
				PropertyInfo property = classObj.GetType().GetProperty(childNode.Name);
				if (null != property)
				{
					propertyLoad(property, classObj, childNode, dirName);
				}
			}
		}

		public static void load(string filename)
		{
			string dirName = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(filename);
			XmlNode lastChild = xmlDocument.LastChild;
			XmlAttribute xmlAttribute = (XmlAttribute)lastChild.Attributes.GetNamedItem("package");
			if (xmlAttribute != null)
			{
				MainForm.m_mainForm.changePkg((Package)int.Parse(xmlAttribute.Value), true);
			}
			foreach (XmlNode childNode in lastChild.ChildNodes)
			{
				object obj = null;
				if ("StartScreenProperty" == childNode.Name)
				{
					obj = MainForm.m_mainForm.m_startScreen;
				}
				else if ("InfomationBarProperty" == childNode.Name)
				{
					obj = MainForm.m_mainForm.m_infomationBar;
				}
				else if ("HomeProperty" == childNode.Name)
				{
					obj = MainForm.m_mainForm.m_home;
				}
				else if ("InfomationProperty" == childNode.Name)
				{
					obj = MainForm.m_mainForm.m_infoProperty;
				}
				if (obj != null)
				{
					classLoad(obj, childNode, dirName);
				}
			}
		}

		public static bool checkFilepathLength(PropertyInfo property, object classObj, ExportItem exportItem)
		{
			bool result = true;
			string text = string.Empty;
			object[] customAttributes = property.GetCustomAttributes(typeof(PropertyCategoryAttribute), false);
			if (0 < customAttributes.Length)
			{
				PropertyCategoryAttribute propertyCategoryAttribute = customAttributes[0] as PropertyCategoryAttribute;
				if (!string.IsNullOrEmpty(propertyCategoryAttribute.PropertyCategory))
				{
					text = text + "[" + propertyCategoryAttribute.PropertyCategory + "] -> ";
				}
			}
			customAttributes = property.GetCustomAttributes(typeof(PropertyDisplayNameAttribute), false);
			if (0 < customAttributes.Length)
			{
				PropertyDisplayNameAttribute propertyDisplayNameAttribute = customAttributes[0] as PropertyDisplayNameAttribute;
				if (!string.IsNullOrEmpty(propertyDisplayNameAttribute.PropertyDisplayName))
				{
					text = text + "[" + propertyDisplayNameAttribute.PropertyDisplayName + "] : ";
				}
			}
			else
			{
				text = text + "[" + property.Name + "] : ";
			}
			switch (property.Name)
			{
			case "m_bgmFilePath":
			case "m_imageFilePath":
			case "m_filePath":
			case "m_iconFilePath":
				if (32 < exportItem.m_exportFile.Length)
				{
					result = false;
					text = text + "\"" + exportItem.m_exportFile + "\"";
					text += "\n";
					text += ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_PATH_LENGTH);
					object obj = text;
					text = string.Concat(obj, " ", exportItem.m_exportFile.Length.ToString(), "/", 32, "(chars)\n");
					Dialog.AddMsg(text);
				}
				if (!string.IsNullOrEmpty(exportItem.m_exportThumbnailFile) && 32 < exportItem.m_exportThumbnailFile.Length)
				{
					result = false;
					text = text + "\"" + exportItem.m_exportThumbnailFile + "\"";
					text += "\n";
					text += ErrorMsg.GetString(ErrorMsg.DEFINES.OVER_PATH_LENGTH);
					object obj2 = text;
					text = string.Concat(obj2, " ", exportItem.m_exportThumbnailFile.Length.ToString(), "/", 32, "(chars)\n");
					Dialog.AddMsg(text);
				}
				break;
			}
			return result;
		}

		public static void getExportProperty(PropertyInfo property, object classObj, ref XmlTextWriter writer, ref List<string> loadImageList, ref List<ExportItem> exportImageList, string envCutDir)
		{
			MethodInfo getMethod = property.GetGetMethod();
			Type returnType = getMethod.ReturnType;
			if (MainForm.m_mainForm.m_package == Package.Normal)
			{
				if (property.GetCustomAttributes(typeof(PkgNormalHideAttribute), true).Length != 0)
				{
					return;
				}
			}
			else if (Package.VitaPreInstall == MainForm.m_mainForm.m_package && property.GetCustomAttributes(typeof(PkgVitaPreInstallHideAttribute), true).Length != 0)
			{
				return;
			}
			if (typeof(string) == returnType)
			{
				string text = (string)getMethod.Invoke(classObj, null);
				if (text == null)
				{
					return;
				}
				if (property.GetCustomAttributes(typeof(FilePathAttribute), true).Length != 0)
				{
					string fullPath = Path.Combine(envCutDir, text);
					fullPath = Path.GetFullPath(fullPath);
					ExportItem exportItem = new ExportItem();
					exportItem.m_exportFile = Path.GetFileName(fullPath);
					if (loadImageList.Exists((string x) => fullPath == x))
					{
						int index = loadImageList.IndexOf(fullPath);
						if (property.GetCustomAttributes(typeof(ThumbnailAttribute), true).Length != 0 && string.IsNullOrEmpty(exportImageList[index].m_exportThumbnailFile))
						{
							exportImageList[index].m_exportThumbnailFile = getThumbnailFilePath(ref exportImageList, exportImageList[index].m_exportFile);
						}
						exportItem = exportImageList[index];
					}
					else
					{
						int num = loadImageList.Count + 1;
						while (exportImageList.Exists((ExportItem x) => exportItem.m_exportFile == x.m_exportFile || exportItem.m_exportFile == x.m_exportThumbnailFile))
						{
							string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(exportItem.m_exportFile);
							string extension = Path.GetExtension(exportItem.m_exportFile);
							exportItem.m_exportFile = fileNameWithoutExtension + num + extension;
						}
						if (property.GetCustomAttributes(typeof(ThumbnailAttribute), true).Length != 0)
						{
							exportItem.m_exportThumbnailFile = getThumbnailFilePath(ref exportImageList, exportItem.m_exportFile);
						}
						if (checkFilepathLength(property, classObj, exportItem))
						{
							loadImageList.Add(fullPath);
							exportImageList.Add(exportItem);
						}
					}
					text = exportItem.m_exportFile;
					if (property.GetCustomAttributes(typeof(ThumbnailAttribute), true).Length != 0)
					{
						writer.WriteElementString("m_thumbnailFilePath", exportItem.m_exportThumbnailFile);
					}
				}
				writer.WriteElementString(property.Name, text);
			}
			else if (typeof(int) == returnType)
			{
				int num2 = (int)getMethod.Invoke(classObj, null);
				if (0 <= num2)
				{
					writer.WriteElementString(property.Name, getMethod.Invoke(classObj, null).ToString());
				}
			}
			else if (typeof(Color) == returnType)
			{
				writer.WriteElementString(property.Name, ((Color)getMethod.Invoke(classObj, null)).ToArgb().ToString("x8"));
			}
			else if (returnType.IsEnum)
			{
				int num3 = (int)getMethod.Invoke(classObj, null);
				if (property.GetCustomAttributes(typeof(WaveAttribute), true).Length != 0)
				{
					num3 = (int)BackgroundParam.s_nativeWaveType[num3];
				}
				writer.WriteElementString(property.Name, num3.ToString());
			}
			else if (returnType.IsArray)
			{
				Array array = (Array)getMethod.Invoke(classObj, null);
				writer.WriteStartElement(property.Name);
				foreach (object item in array)
				{
					getExportClass(item, ref writer, ref loadImageList, ref exportImageList, envCutDir);
				}
				writer.WriteEndElement();
			}
			else if (returnType.IsClass)
			{
				object classObj2 = getMethod.Invoke(classObj, null);
				writer.WriteStartElement(property.Name);
				getInternalExportClass(classObj2, ref writer, ref loadImageList, ref exportImageList, envCutDir);
				writer.WriteEndElement();
			}
		}

		public static void getInternalExportClass(object classObj, ref XmlTextWriter writer, ref List<string> loadImageList, ref List<ExportItem> exportImageList, string envCutDir)
		{
			if (classObj is BaseSaveAttributeProperty)
			{
				BaseSaveAttributeProperty baseSaveAttributeProperty = (BaseSaveAttributeProperty)classObj;
				if (!baseSaveAttributeProperty.CheckProperties())
				{
					return;
				}
			}
			PropertyInfo[] properties = classObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				IEnumerable<object> source = from n2 in propertyInfo.GetCustomAttributes(true)
					where n2 is SaveAttribute
					select n2;
				if (0 < source.Count())
				{
					getExportProperty(propertyInfo, classObj, ref writer, ref loadImageList, ref exportImageList, envCutDir);
				}
			}
		}

		public static void getExportClass(object classObj, ref XmlTextWriter writer, ref List<string> loadImageList, ref List<ExportItem> exportImageList, string envCutDir)
		{
			writer.WriteStartElement(classObj.GetType().Name);
			getInternalExportClass(classObj, ref writer, ref loadImageList, ref exportImageList, envCutDir);
			writer.WriteEndElement();
		}

		public static int getExportData(ref MemoryStream memStream, ref List<string> loadImageList, ref List<ExportItem> exportImageList)
		{
			string envCutDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
			int num = 0;
			XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.UTF8);
			writer.WriteStartDocument();
			writer.WriteStartElement("theme");
			writer.WriteAttributeString("format-ver", "01.00");
			XmlTextWriter xmlTextWriter = writer;
			int package = (int)MainForm.m_mainForm.m_package;
			xmlTextWriter.WriteAttributeString("package", package.ToString());
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					if (type.GetCustomAttributes(typeof(SaveAttribute), true).Length != 0)
					{
						object classObj = null;
						if (type.Equals(typeof(StartScreenProperty)))
						{
							classObj = MainForm.m_mainForm.startPropertyGrid.SelectedObject;
						}
						else if (type.Equals(typeof(InfomationBarProperty)))
						{
							classObj = MainForm.m_mainForm.m_infomationBar;
						}
						else if (type.Equals(typeof(HomeProperty)))
						{
							classObj = MainForm.m_mainForm.m_home;
						}
						else if (type.Equals(typeof(InfomationProperty)))
						{
							classObj = MainForm.m_mainForm.m_infoProperty;
						}
						getExportClass(classObj, ref writer, ref loadImageList, ref exportImageList, envCutDir);
					}
				}
			}
			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Flush();
			num = (int)memStream.Length;
			writer.Close();
			return num;
		}

		public static void exportDir(string folderName)
		{
			Dialog.ClearMsg();
			MemoryStream memStream = new MemoryStream();
			List<string> loadImageList = new List<string>();
			List<ExportItem> exportImageList = new List<ExportItem>();
			folderName += Path.DirectorySeparatorChar;
			int exportData = getExportData(ref memStream, ref loadImageList, ref exportImageList);
			using (FileStream fileStream = new FileStream(folderName + m_exportXmlName, FileMode.Create))
			{
				byte[] buffer = memStream.GetBuffer();
				fileStream.Write(buffer, 0, exportData);
			}
			string msg;
			if (!checkXmlFileSize(out msg, folderName + m_exportXmlName))
			{
				Dialog.AddMsg(msg);
			}
			if (Dialog.HaveMsg())
			{
				File.Delete(folderName + m_exportXmlName);
				Dialog.Show("ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			for (int i = 0; i < loadImageList.Count; i++)
			{
				File.Copy(loadImageList[i], folderName + exportImageList[i].m_exportFile, true);
				if (!string.IsNullOrEmpty(exportImageList[i].m_exportThumbnailFile))
				{
					Bitmap image = new Bitmap(loadImageList[i]);
					Bitmap bitmap = new Bitmap(360, 192);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.SmoothingMode = SmoothingMode.None;
					graphics.InterpolationMode = InterpolationMode.Bicubic;
					graphics.DrawImage(image, 0, 0, 360, 192);
					bitmap.Save(folderName + exportImageList[i].m_exportThumbnailFile);
				}
			}
		}

		public static string getThumbnailFilePath(ref List<ExportItem> exportImageList, string exportFile)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(exportFile);
			string extension = Path.GetExtension(exportFile);
			exportFile = fileNameWithoutExtension + "t" + extension;
			while (exportImageList.Exists((ExportItem x) => exportFile == x.m_exportFile || exportFile == x.m_exportThumbnailFile))
			{
				fileNameWithoutExtension = Path.GetFileNameWithoutExtension(exportFile);
				extension = Path.GetExtension(exportFile);
				exportFile = fileNameWithoutExtension + "t" + extension;
			}
			return exportFile;
		}

		private static bool checkXmlFileSize(out string msg, string filepath)
		{
			bool result = true;
			msg = string.Empty;
			FileInfo fileInfo = new FileInfo(filepath);
			if (fileInfo != null && 32768 < fileInfo.Length)
			{
				msg = filepath + "\novered output filesize. " + fileInfo.Length + "/" + 32768L + "(bytes)";
				result = false;
			}
			return result;
		}
	}
}
