using System;
using System.Windows.Forms;

namespace theme_tool
{
	public class NumericTextBox : TextBox
	{
		public int IntValue
		{
			get
			{
				return int.Parse(Text);
			}
		}

		public NumericTextBox()
		{
			MaxLength = 4;
			Text = "255";
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			e.KeyChar.ToString();
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			if ("" != Text)
			{
				if (0 > IntValue)
				{
					Text = "0";
				}
				else if (255 < IntValue)
				{
					Text = "255";
				}
			}
			base.OnTextChanged(e);
		}
	}
}
