using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException10 : GException4
	{
		public int int_4;

		public GException10()
		{
		}

		public GException10(int int_5, GInterface17 ginterface17_0)
			: base(ginterface17_0)
		{
			GInterface11 gInterface = (GInterface11)ginterface17_0.imethod_10(1);
			if (ginterface17_0.imethod_10(1) is GInterface11)
			{
				method_9(gInterface.imethod_8());
				method_3(gInterface.imethod_5());
			}
			int_4 = int_5;
		}

		public override string ToString()
		{
			return "MismatchedTreeNodeException(" + vmethod_0() + "!=" + int_4 + ")";
		}
	}
}
