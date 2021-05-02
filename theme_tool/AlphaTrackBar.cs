using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace theme_tool
{
	public class AlphaTrackBar : TrackBar
	{
		private static int m_pad = 3;

		private static int m_barWidth = 14;

		private static int m_arrowOfsY = 14;

		private static int m_arrowWidth = 14;

		private bool m_dragged;

		public AlphaTrackBar()
		{
			base.Orientation = Orientation.Vertical;
			base.Minimum = 0;
			base.Maximum = 255;
			base.Value = 255;
			base.TickStyle = TickStyle.None;
			RightToLeft = RightToLeft.Yes;
			RightToLeftLayout = true;
			base.LargeChange = 0;
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			UpdateStyles();
			base.ValueChanged += valueChanged;
		}

		protected override void OnValueChanged(EventArgs e)
		{
			base.OnValueChanged(e);
		}

		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			base.OnInvalidated(e);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if (e.ClipRectangle != base.ClientRectangle)
			{
				Invalidate();
			}
			else
			{
				DrawClear(ref g);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			DrawBar(ref g);
			DrawBorder(ref g);
			DrawSlider(ref g);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			setMouseY(e.Y);
			m_dragged = true;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (m_dragged)
			{
				setMouseY(e.Y);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			m_dragged = false;
		}

		private void valueChanged(object sender, EventArgs e)
		{
		}

		private void DrawClear(ref Graphics g)
		{
			Brush control = SystemBrushes.Control;
			Rectangle clientRectangle = base.ClientRectangle;
			int left = clientRectangle.Left;
			int num = clientRectangle.Right - clientRectangle.Left;
			int top = clientRectangle.Top;
			int num2 = clientRectangle.Bottom - clientRectangle.Top;
			g.FillRectangle(control, left, top, num, num2);
		}

		private void DrawBar(ref Graphics g)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			LinearGradientBrush brush = new LinearGradientBrush(clientRectangle, Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 0, 0, 0), LinearGradientMode.Vertical);
			int num = clientRectangle.Right - m_pad - m_barWidth;
			int barWidth = m_barWidth;
			int num2 = clientRectangle.Top + m_pad;
			int num3 = clientRectangle.Bottom - clientRectangle.Top - m_pad * 2;
			g.FillRectangle(brush, num, num2, barWidth, num3);
		}

		private void DrawBorder(ref Graphics g)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			Pen pen = new Pen(Color.FromArgb(160, 160, 160));
			int num = clientRectangle.Right - m_pad - m_barWidth;
			int num2 = num + m_barWidth;
			int num3 = clientRectangle.Top + m_pad;
			int num4 = clientRectangle.Bottom - m_pad;
			g.DrawLine(pen, num, num3, num2, num3);
			g.DrawLine(pen, num2, num3, num2, num4);
			pen = new Pen(Color.White);
			g.DrawLine(pen, num, num3, num, num4);
			g.DrawLine(pen, num4, num, num4, num2);
		}

		private void DrawSlider(ref Graphics g)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			int num = clientRectangle.Top + m_pad;
			int num2 = clientRectangle.Bottom - m_pad;
			int num3 = num2 - num;
			int num4 = num + num3 * (255 - base.Value) / 255;
			int num5 = clientRectangle.Left + m_pad + m_arrowWidth;
			int num6 = num5 - m_arrowWidth;
			Point[] points = new Point[4]
			{
				new Point(num5, num4),
				new Point(num6, num4 - m_arrowOfsY),
				new Point(num6, num4 + m_arrowOfsY),
				new Point(num5, num4)
			};
			g.FillPolygon(Brushes.Black, points);
		}

		private void setMouseY(int mouseY)
		{
			Rectangle clientRectangle = base.ClientRectangle;
			int num = clientRectangle.Top + m_pad;
			int num2 = clientRectangle.Bottom - m_pad;
			int num3 = num2 - num;
			int num4 = -1 * ((mouseY - num) * 255) / num3 + 255;
			if (0 > num4)
			{
				num4 = 0;
			}
			else if (255 < num4)
			{
				num4 = 255;
			}
			base.Value = num4;
		}
	}
}
