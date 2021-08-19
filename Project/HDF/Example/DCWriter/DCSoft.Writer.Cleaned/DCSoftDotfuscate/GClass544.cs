using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass544 : GInterface24
	{
		private GClass581 gclass581_0;

		public GClass544(string string_0)
		{
			gclass581_0 = new GClass581(string_0);
		}

		public virtual bool imethod_0(string string_0)
		{
			bool result = false;
			if (string_0 != null)
			{
				string string_ = (string_0.Length > 0) ? Path.GetFullPath(string_0) : "";
				result = gclass581_0.imethod_0(string_);
			}
			return result;
		}
	}
}
