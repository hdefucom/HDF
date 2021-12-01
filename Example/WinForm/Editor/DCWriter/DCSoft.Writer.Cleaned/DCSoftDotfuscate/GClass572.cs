using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass572 : GInterface28
	{
		private string string_0;

		public GClass572(string string_1)
		{
			string_0 = string_1;
		}

		public Stream imethod_0()
		{
			return File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read);
		}
	}
}
