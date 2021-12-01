using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass513 : GClass504
	{
		protected ArrayList arrayList_0 = new ArrayList();

		protected int int_2 = -1;

		public int method_8(GClass504 gclass504_0)
		{
			if (gclass504_0 == null)
			{
				return -1;
			}
			return arrayList_0.IndexOf(gclass504_0);
		}

		public void method_9(GClass504 gclass504_0)
		{
			if (gclass504_0 != null && !arrayList_0.Contains(gclass504_0))
			{
				arrayList_0.Add(gclass504_0);
			}
		}

		public void method_10(string string_0)
		{
			method_9(new GClass509(string_0));
		}

		public void method_11(int int_3)
		{
			method_9(new GClass507(int_3));
		}

		public void method_12(bool bool_0)
		{
			method_9(new GClass506(bool_0));
		}

		public void method_13(double double_0)
		{
			method_9(new GClass508(double_0));
		}

		public void method_14()
		{
			arrayList_0.Clear();
		}

		public int method_15()
		{
			return int_2;
		}

		public void method_16(int int_3)
		{
			int_2 = int_3;
		}

		public int method_17()
		{
			return arrayList_0.Count;
		}

		public GClass504 method_18(int int_3)
		{
			return (GClass504)arrayList_0[int_3];
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			int num = 2;
			streamWriter_0.Write("[");
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				GClass504 gClass = (GClass504)arrayList_0[i];
				gClass.vmethod_0(streamWriter_0);
				if (int_2 > 0 && (i + 1) % int_2 == 0)
				{
					streamWriter_0.WriteLine();
				}
				if (i < arrayList_0.Count - 1)
				{
					streamWriter_0.Write(" ");
				}
			}
			streamWriter_0.Write("]");
		}

		public override void Dispose()
		{
			base.Dispose();
			if (arrayList_0 != null)
			{
				ArrayList arrayList = arrayList_0;
				arrayList_0 = null;
				foreach (GClass504 item in arrayList)
				{
					item.Dispose();
				}
			}
		}
	}
}
