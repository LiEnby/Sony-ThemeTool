using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace theme_tool.TMUtility
{
	internal class psp2ctrl
	{
		private const string PSP2CTRL_EXE = "psp2ctrl.exe";

		private const string ARGS_POWER_ON = "on";

		private const string ARGS_POWER_OFF = "off";

		private const string ARGS_REBOOT = "reboot";

		private const string ARGS_INFO = "info";

		private const string STATE_POWER_ON = "POWER_STATUS_ON";

		private const string STATE_POWER_OFF = "POWER_STATUS_OFF";

		private static string m_error_msg = string.Empty;

		private static void exec(string arg)
		{
			bool blocking = false;
			string output;
			exec(arg, blocking, out output);
		}

		private static void exec(string arg, bool blocking, out string output)
		{
			m_error_msg = string.Empty;
			output = string.Empty;
			MainForm.m_mainForm.Disable_menuItemDevkit();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "psp2ctrl.exe";
			processStartInfo.Arguments = arg;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.ErrorDialog = true;
			processStartInfo.ErrorDialogParentHandle = MainForm.m_mainForm.Handle;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
			Process process = null;
			try
			{
				process = Process.Start(processStartInfo);
				process.OutputDataReceived += processDataReceived2;
				process.ErrorDataReceived += processDataReceived;
				if (blocking)
				{
					output = process.StandardOutput.ReadToEnd();
					return;
				}
				process.SynchronizingObject = MainForm.m_mainForm;
				process.EnableRaisingEvents = true;
				process.Exited += exited;
			}
			catch (FileNotFoundException)
			{
				m_error_msg = ErrorMsg.GetString(ErrorMsg.DEFINES.CAN_NOT_BOOT) + " : psp2ctrl.exe\n\n" + ErrorMsg.GetString(ErrorMsg.DEFINES.CHECK_TM_PATH_OR_INSRALLED) + m_error_msg;
				exited(process, new EventArgs());
			}
			catch (Win32Exception)
			{
				m_error_msg = ErrorMsg.GetString(ErrorMsg.DEFINES.CAN_NOT_BOOT) + " : psp2ctrl.exe\n\n" + ErrorMsg.GetString(ErrorMsg.DEFINES.CHECK_TM_PATH_OR_INSRALLED) + m_error_msg;
				exited(process, new EventArgs());
			}
			catch (Exception ex3)
			{
				m_error_msg += ex3.Message;
				exited(process, new EventArgs());
			}
		}

		private static void processDataReceived(object sender, DataReceivedEventArgs e)
		{
			string datum = e.Data;
		}

		private static void processDataReceived2(object sender, DataReceivedEventArgs e)
		{
			string datum = e.Data;
		}

		private static void exited(object sender, EventArgs e)
		{
			Process process = sender as Process;
			if (process != null)
			{
				if (process.ExitCode < 0)
				{
					m_error_msg = "Exit Code : " + process.ExitCode + "\n\n" + m_error_msg;
					m_error_msg += process.StandardError.ReadToEnd();
				}
				process.Close();
			}
			if (!string.IsNullOrEmpty(m_error_msg))
			{
				MessageBox.Show(m_error_msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			MainForm.m_mainForm.Enable_menuItemDevkit();
		}

		public static void PowerOn()
		{
			exec("on");
		}

		public static void PowerOff()
		{
			exec("off");
		}

		public static void Reboot()
		{
			exec("reboot");
		}

		private static bool existState(string state)
		{
			string output;
			exec("info", true, out output);
			if (!string.IsNullOrEmpty(output) && 0 <= output.IndexOf(state))
			{
				return true;
			}
			return false;
		}

		public static bool IsPowerOn()
		{
			return existState("POWER_STATUS_ON");
		}

		public static bool IsPowerOff()
		{
			return existState("POWER_STATUS_OFF");
		}
	}
}
