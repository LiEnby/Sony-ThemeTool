using System.Runtime.InteropServices;

namespace theme_tool
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct At9Chunk
	{
		public ushort wFormatTag;

		public ushort nChannels;

		public uint nSamplesPerSec;

		public uint nAvgBytesPerSec;

		public ushort nBlockAlign;

		public ushort wBitsPerSample;

		public ushort cbSize;

		public ushort wSamplesPerBlock;

		public uint dwChannelMask;

		public Guid subFormat;

		public uint dwVersionInfo;

		public uint configData;

		public uint reserved;

		public uint factId;

		public uint factSize;

		public uint totalSamples;

		public uint fact0;

		public uint fact1;

		public uint smplId;

		public uint smplSize;

		public uint smplPad0;

		public ulong smplPad1;

		public ulong smplPad2;

		public ulong smplPad3;

		public uint smplLoopValid;

		public uint smplPad4;

		public ulong smplPad5;

		public int loopStartSample;

		public int loopEndSample;
	}
}
