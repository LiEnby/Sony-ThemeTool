using System.Runtime.InteropServices;

namespace theme_tool
{
	[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
	public struct FormatChunk
	{
		public uint m_id;

		public uint m_size;
	}
}
