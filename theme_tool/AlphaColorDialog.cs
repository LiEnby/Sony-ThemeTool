using System;
using System.Drawing;
using System.Windows.Forms;

namespace theme_tool
{
	public class AlphaColorDialog : ColorDialog
	{
		private Panel m_alphaPanel;

		private NumericTextBox m_alphaText;

		private Label m_alphaLabel;

		private AlphaTrackBar m_alphaBar;

		public AlphaColorDialog()
		{
			FullOpen = true;
			m_alphaPanel = new Panel();
			m_alphaText = new NumericTextBox();
			m_alphaLabel = new Label();
			m_alphaBar = new AlphaTrackBar();
			m_alphaPanel.BorderStyle = BorderStyle.None;
			m_alphaPanel.Width = 50;
			m_alphaPanel.Height = 268;
			m_alphaPanel.Padding = new Padding(3);
			m_alphaBar.Name = "alphaBar";
			m_alphaBar.Location = new Point(10, 3);
			m_alphaBar.Height = 180;
			m_alphaBar.Width = 36;
			m_alphaBar.AutoSize = false;
			m_alphaBar.ValueChanged += BarValueChanged;
			m_alphaText.Name = "alphaText";
			m_alphaText.Height = 12;
			m_alphaText.Width = 28;
			m_alphaText.TextChanged += TextValueChanged;
			m_alphaLabel.Height = 14;
			m_alphaLabel.Width = 15;
			m_alphaLabel.Text = "A:";
			m_alphaPanel.Controls.Add(m_alphaBar);
			m_alphaPanel.Controls.Add(m_alphaLabel);
			m_alphaPanel.Controls.Add(m_alphaText);
			m_alphaLabel.Font = new Font(m_alphaLabel.Font.FontFamily, 9f);
			m_alphaLabel.Location = new Point(0, 189);
			m_alphaText.Font = new Font(m_alphaText.Font.FontFamily, 9f);
			m_alphaText.Location = new Point(14, 186);
		}

		public new void Dispose()
		{
			m_alphaText.Dispose();
			m_alphaLabel.Dispose();
			m_alphaBar.Dispose();
			m_alphaPanel.Dispose();
			m_alphaLabel = null;
			m_alphaText = null;
			m_alphaBar = null;
			m_alphaPanel = null;
			base.Dispose();
		}

		protected override bool RunDialog(IntPtr hwndOwner)
		{
			m_alphaBar.Value = base.Color.A;
			bool result = base.RunDialog(hwndOwner);
			if ("" != m_alphaText.Text)
			{
				base.Color = Color.FromArgb(m_alphaBar.Value, base.Color);
			}
			return result;
		}

		protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
		{
			IntPtr result = base.HookProc(hWnd, msg, wparam, lparam);
			if (272 == msg)
			{
				RECT rc = default(RECT);
				RECT rc2 = default(RECT);
				NativeMethods.SetParent(m_alphaPanel.Handle, hWnd);
				NativeMethods.GetWindowRect(hWnd, ref rc);
				NativeMethods.GetClientRect(hWnd, ref rc2);
				Size size = m_alphaPanel.Size;
				NativeMethods.MoveWindow(hWnd, rc.left, rc.top, rc.right - rc.left + size.Width, rc.bottom - rc.top, true);
				m_alphaPanel.Location = new Point(rc2.right - rc2.left, m_alphaPanel.Location.Y);
			}
			return result;
		}

		private void BarValueChanged(object sender, EventArgs e)
		{
			if (m_alphaText.IntValue != m_alphaBar.Value)
			{
				m_alphaText.Text = m_alphaBar.Value.ToString();
			}
		}

		private void TextValueChanged(object sender, EventArgs e)
		{
			if ("" != m_alphaText.Text && m_alphaText.IntValue != m_alphaBar.Value)
			{
				m_alphaBar.Value = m_alphaText.IntValue;
			}
		}
	}
}
