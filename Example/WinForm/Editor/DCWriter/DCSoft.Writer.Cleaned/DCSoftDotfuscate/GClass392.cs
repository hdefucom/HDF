using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass392 : GClass383
	{
		public GClass392()
		{
			method_13(bool_1: true);
		}

		public override string vmethod_0()
		{
			return Environment.NewLine;
		}

		public override string ToString()
		{
			return "linebreak";
		}
	}
}
