using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass388 : GClass383
	{
		private bool bool_1 = false;

		private bool bool_2 = false;

		private GClass425 gclass425_0 = new GClass425();

		public bool method_17()
		{
			return bool_1;
		}

		public void method_18(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public bool method_19()
		{
			return bool_2;
		}

		public void method_20(bool bool_3)
		{
			bool_2 = bool_3;
		}

		public GClass425 method_21()
		{
			return gclass425_0;
		}

		public void method_22(GClass425 gclass425_1)
		{
			gclass425_0 = gclass425_1;
		}

		public override string vmethod_0()
		{
			return base.vmethod_0() + Environment.NewLine;
		}

		public override string ToString()
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Paragraph");
			if (method_21() != null)
			{
				stringBuilder.Append(string.Concat("(", method_21().method_39(), ")"));
				if (method_21().method_71() >= 0)
				{
					stringBuilder.Append("ListID:" + method_21().method_71());
				}
				if (method_21().method_1() >= 0)
				{
					stringBuilder.Append(" OutLineLevel:" + method_21().method_1());
				}
			}
			return stringBuilder.ToString();
		}
	}
}
