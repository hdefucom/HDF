using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass457 : GClass454
	{
		private GClass460 gclass460_0;

		public GClass457(GClass460 gclass460_1)
		{
			gclass460_0 = gclass460_1;
		}

		public GClass460 method_5()
		{
			return gclass460_0;
		}

		private string method_6()
		{
			return Class211.string_0 + "+" + method_5().Name;
		}

		public override void vmethod_2()
		{
			int num = 19;
			GClass515 gClass = method_3();
			gClass.method_9("/CIDInit /ProcSet findresource begin");
			gClass.method_9("12 dict begin");
			gClass.method_9("begincmap");
			gClass.method_9("/CIDSystemInfo");
			gClass.method_9("<<");
			gClass.method_9("/Registry (Adobe)");
			gClass.method_9("/Ordering (" + method_6() + ")");
			gClass.method_9("/Supplement 0");
			gClass.method_9(">> def");
			gClass.method_9("/CMapName /" + method_6() + " def");
			gClass.method_9("/CMapType 2 def");
			gClass.method_9("1 begincodespacerange");
			gClass.method_9("<0000> <FFFF>");
			gClass.method_9("endcodespacerange");
			char[] array = method_5().method_4().method_3().method_4();
			if (array.Length > 0)
			{
				gClass.method_9(Convert.ToString(array.Length) + " beginbfchar");
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = new string[5]
					{
						"<",
						method_5().method_6().method_9(array[i]).ToString("X4"),
						"> <",
						null,
						null
					};
					ushort num2 = array[i];
					array2[3] = num2.ToString("X4");
					array2[4] = ">";
					gClass.method_9(string.Concat(array2));
				}
				gClass.method_9("endbfchar");
			}
			gClass.method_9("endcmap");
			gClass.method_9("CMapName currentdict /CMap defineresource pop");
			gClass.method_9("end");
			gClass.method_9("end");
		}
	}
}
