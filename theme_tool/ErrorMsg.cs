using System.Reflection;
using System.Resources;

namespace theme_tool
{
	public class ErrorMsg
	{
		public enum DEFINES
		{
			NON_CONTIGUOUS_PAGE,
			NOT_FOUND_FILE,
			OVER_IMAGE_WIDTH,
			OVER_IMAGE_HEIGHT,
			NOT_INDEX_COLOR256,
			EMPTY_STRING,
			OVER_PAGE_INDEX,
			LESS_PAGE_INDEX,
			OVER_STRING_BYTE_SIZE,
			OVER_PATH_LENGTH,
			NOT_PNG_FILE,
			INVALID_CHARS_IN_FILEPATH,
			MUST_PARAMETER,
			READ_FILE_FAILURE,
			INVALID_FILE_PATH,
			OVER_FILE_SIZE,
			CAN_NOT_BOOT,
			CHECK_TM_PATH_OR_INSRALLED,
			INVALID_BGM_FILE,
			MAX
		}

		private const string ERROR_MSG_PREFIX = "ERROR_MSG_";

		public static string GetString(DEFINES error)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			ResourceManager resourceManager = new ResourceManager("theme_tool.Properties.Resources", executingAssembly);
			int num = (int)error;
			if (num < 0)
			{
				return resourceManager.GetString("ERROR_MSG_INVALID_ERROR_VALUE : " + num);
			}
			if (19 < num)
			{
				return resourceManager.GetString("ERROR_MSG_INVALID_ERROR_VALUE : " + num);
			}
			return resourceManager.GetString("ERROR_MSG_" + error);
		}
	}
}
