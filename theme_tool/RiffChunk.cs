using System.Runtime.InteropServices;

namespace theme_tool
{
	[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 12)]
	public struct RiffChunk
	{
		public uint m_id;

		public uint m_size;

		public uint m_type;
	}
}
