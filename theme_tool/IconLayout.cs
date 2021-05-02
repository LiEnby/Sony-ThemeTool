using System.Drawing;

namespace theme_tool
{
	public class IconLayout
	{
		public static readonly Point[] m_pointTbl = new Point[10]
		{
			new Point(180, 28),
			new Point(409, 28),
			new Point(638, 28),
			new Point(74, 181),
			new Point(298, 181),
			new Point(522, 181),
			new Point(746, 181),
			new Point(180, 337),
			new Point(409, 337),
			new Point(638, 337)
		};

		public int m_pagePos;

		public int m_iconPos;

		public IconLayout(int pagePos, int iconPos)
		{
			m_pagePos = pagePos;
			m_iconPos = iconPos;
		}
	}
}
