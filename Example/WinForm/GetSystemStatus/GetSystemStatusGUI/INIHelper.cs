using System.Runtime.InteropServices;
using System.Text;

namespace GetSystemStatusGUI;

public static class INIHelper
{
	[DllImport("kernel32")]
	private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

	[DllImport("kernel32")]
	private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

	public static string Read(string section, string key, string def, string filePath)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		GetPrivateProfileString(section, key, def, stringBuilder, 1024, filePath);
		return stringBuilder.ToString();
	}

	public static int Write(string section, string key, string value, string filePath)
	{
		return WritePrivateProfileString(section, key, value, filePath);
	}

	public static int DeleteSection(string section, string filePath)
	{
		return Write(section, null, null, filePath);
	}

	public static int DeleteKey(string section, string key, string filePath)
	{
		return Write(section, key, null, filePath);
	}
}
