using System.Runtime.InteropServices;

namespace theme_tool
{
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	public struct Guid
	{
		public uint data1;

		public ushort data2;

		public ushort data3;

		public ulong data4;
	}
}
