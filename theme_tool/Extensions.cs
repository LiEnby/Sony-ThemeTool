using System.IO;
using System.Runtime.InteropServices;

namespace theme_tool
{
	internal static class Extensions
	{
		public static T ReadStruct<T>(this BinaryReader reader) where T : struct
		{
			byte[] array = new byte[Marshal.SizeOf(typeof(T))];
			reader.Read(array, 0, array.Length);
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			try
			{
				return (T)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(T));
			}
			finally
			{
				gCHandle.Free();
			}
		}
	}
}
