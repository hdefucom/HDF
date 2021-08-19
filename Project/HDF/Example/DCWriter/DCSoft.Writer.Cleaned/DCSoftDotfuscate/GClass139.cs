using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass139 : CollectionBase
	{
		public GClass138 method_0(int int_0)
		{
			return (GClass138)base.List[int_0];
		}

		public int method_1(GClass138 gclass138_0)
		{
			return base.List.Add(gclass138_0);
		}
	}
}
