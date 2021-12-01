using System.Runtime.InteropServices;

namespace Windows32
{
	public class Kernel32
	{
		public const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 256;

		public const int FORMAT_MESSAGE_IGNORE_INSERTS = 512;

		public const int FORMAT_MESSAGE_FROM_STRING = 1024;

		public const int FORMAT_MESSAGE_FROM_HMODULE = 2048;

		public const int FORMAT_MESSAGE_FROM_SYSTEM = 4096;

		public const int FORMAT_MESSAGE_ARGUMENT_ARRAY = 8192;

		public const int FORMAT_MESSAGE_MAX_WIDTH_MASK = 255;

		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
		public static extern uint GetLastError();

		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
		public static extern int FormatMessage(int Flags, int PSource, int MessageID, int LanguageID, char[] CharBuffer, int BufferSize, int Arguments);

		public static string FormatErrorMessage(int ErrorCode)
		{
			char[] array = new char[2048];
			int num = FormatMessage(4608, 0, ErrorCode, 0, array, array.Length, 0);
			if (num > 1)
			{
				return new string(array, 0, num - 1);
			}
			return null;
		}
	}
}
