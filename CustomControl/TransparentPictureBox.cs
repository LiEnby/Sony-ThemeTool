using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CustomControl
{
	public class TransparentPictureBox : PictureBox
	{
		private IContainer components;

		public bool m_normal = true;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}

		public TransparentPictureBox()
		{
			InitializeComponent();
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (!m_normal)
			{
				DrawParentWithBackControl(pevent);
			}
			else
			{
				base.OnPaintBackground(pevent);
			}
		}

		private void DrawParentWithBackControl(PaintEventArgs pevent)
		{
			DrawParentControl(base.Parent, pevent);
			for (int num = base.Parent.Controls.Count - 1; num >= 0; num--)
			{
				Control control = base.Parent.Controls[num];
				if (control == this)
				{
					break;
				}
				if (base.Bounds.IntersectsWith(control.Bounds) && control.Visible)
				{
					DrawBackControl(control, pevent);
				}
			}
		}

		private void DrawParentControl(Control c, PaintEventArgs pevent)
		{
			using (Bitmap bitmap = new Bitmap(c.Width, c.Height, PixelFormat.Format32bppArgb))
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					using (PaintEventArgs e = new PaintEventArgs(graphics, c.ClientRectangle))
					{
						InvokePaintBackground(c, e);
						InvokePaint(c, e);
					}
				}
				int num = base.Left + (int)Math.Floor((double)(base.Bounds.Width - base.ClientRectangle.Width) / 2.0);
				int num2 = base.Top + (int)Math.Floor((double)(base.Bounds.Height - base.ClientRectangle.Height) / 2.0);
				pevent.Graphics.DrawImage(bitmap, base.ClientRectangle, new Rectangle(num, num2, base.ClientRectangle.Width, base.ClientRectangle.Height), GraphicsUnit.Pixel);
			}
		}

		private void DrawBackControl(Control c, PaintEventArgs pevent)
		{
			if (c.Width != 0 && c.Height != 0)
			{
				using (Bitmap bitmap = new Bitmap(c.Width, c.Height, PixelFormat.Format32bppArgb))
				{
					c.DrawToBitmap(bitmap, new Rectangle(0, 0, c.Width, c.Height));
					int num = c.Left - base.Left - (int)Math.Floor((double)(base.Bounds.Width - base.ClientRectangle.Width) / 2.0);
					int num2 = c.Top - base.Top - (int)Math.Floor((double)(base.Bounds.Height - base.ClientRectangle.Height) / 2.0);
					pevent.Graphics.DrawImage(bitmap, num, num2, c.Width, c.Height);
				}
			}
		}
	}
}
