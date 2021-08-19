using DCSoft.Printing;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass160 : CollectionBase
	{
		public PrintJob method_0(int int_0)
		{
			return (PrintJob)base.List[int_0];
		}

		public int method_1(PrintJob printJob_0)
		{
			return base.List.Add(printJob_0);
		}
	}
}
