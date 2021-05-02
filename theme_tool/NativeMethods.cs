using System;
using System.Runtime.InteropServices;

namespace theme_tool
{
	public class NativeMethods
	{
		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		internal static extern IntPtr GetDlgItem(IntPtr hWndDlg, short Id);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		internal static extern IntPtr GetParent(IntPtr hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		internal static extern int GetWindowRect(IntPtr hWnd, ref RECT rc);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		internal static extern int GetClientRect(IntPtr hWnd, ref RECT rc);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool repaint);
	}
}
