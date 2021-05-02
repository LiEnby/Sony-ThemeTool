using System.Collections.Generic;
using System.Windows.Forms;
using theme_tool.UserControl;

namespace theme_tool
{
	internal class Dialog
	{
		private static List<string> m_msg_list = new List<string>();

		public static bool HaveMsg()
		{
			if (m_msg_list.Count == 0)
			{
				return false;
			}
			return true;
		}

		public static int CountMsg()
		{
			return m_msg_list.Count;
		}

		public static void ClearMsg()
		{
			m_msg_list.Clear();
		}

		public static void AddMsg(string msg)
		{
			m_msg_list.Add(msg + "\n");
		}

		public static DialogResult Show(string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return show(caption, buttons, icon);
		}

		private static DialogResult show(string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			if (m_msg_list.Count == 0)
			{
				return DialogResult.OK;
			}
			string text = "";
			for (int i = 0; i < m_msg_list.Count; i++)
			{
				text += m_msg_list[i];
			}
			ErrorMessageBox errorMessageBox = new ErrorMessageBox();
			errorMessageBox.SetMessage(text);
			errorMessageBox.Show();
			return DialogResult.OK;
		}
	}
}
