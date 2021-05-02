using System.IO;

namespace theme_tool
{
	public class BgmChecker
	{
		public static bool bgmFileCheck(string filepath)
		{
			try
			{
				FileStream input = new FileStream(filepath, FileMode.Open, FileAccess.Read);
				BinaryReader reader = new BinaryReader(input);
				At9FileHeader at9FileHeader = reader.ReadStruct<At9FileHeader>();
				if (1179011410 != at9FileHeader.m_riffChunk.m_id)
				{
					return false;
				}
				if (1163280727 != at9FileHeader.m_riffChunk.m_type)
				{
					return false;
				}
				if (544501094 != at9FileHeader.m_formatChunk.m_id)
				{
					return false;
				}
				if (65534 != at9FileHeader.m_at9Chunk.wFormatTag)
				{
					return false;
				}
				if (2 != at9FileHeader.m_at9Chunk.nChannels)
				{
					return false;
				}
				if (48000 != at9FileHeader.m_at9Chunk.nSamplesPerSec)
				{
					return false;
				}
				if (18000 != at9FileHeader.m_at9Chunk.nAvgBytesPerSec)
				{
					return false;
				}
				if (18000 != at9FileHeader.m_at9Chunk.nAvgBytesPerSec)
				{
					return false;
				}
				if (at9FileHeader.m_at9Chunk.wBitsPerSample != 0)
				{
					return false;
				}
				if (34 != at9FileHeader.m_at9Chunk.cbSize)
				{
					return false;
				}
				if (1205945042 != at9FileHeader.m_at9Chunk.subFormat.data1)
				{
					return false;
				}
				if (14010 != at9FileHeader.m_at9Chunk.subFormat.data2)
				{
					return false;
				}
				if (19853 != at9FileHeader.m_at9Chunk.subFormat.data3)
				{
					return false;
				}
				if (7819247650676538504L != at9FileHeader.m_at9Chunk.subFormat.data4)
				{
					return false;
				}
				if (1952670054 != at9FileHeader.m_at9Chunk.factId)
				{
					return false;
				}
				if (1819307379 != at9FileHeader.m_at9Chunk.smplId)
				{
					return false;
				}
				if (52 > at9FileHeader.m_at9Chunk.smplSize)
				{
					return false;
				}
				if (at9FileHeader.m_at9Chunk.smplLoopValid == 0)
				{
					return false;
				}
				if (at9FileHeader.m_at9Chunk.loopStartSample > at9FileHeader.m_at9Chunk.loopEndSample)
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
