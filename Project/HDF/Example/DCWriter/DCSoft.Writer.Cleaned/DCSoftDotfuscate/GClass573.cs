using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass573 : GInterface29
	{
		public Stream imethod_0(GClass577 gclass577_0, string string_0)
		{
			Stream result = null;
			if (string_0 != null)
			{
				result = File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read);
			}
			return result;
		}
	}
}
