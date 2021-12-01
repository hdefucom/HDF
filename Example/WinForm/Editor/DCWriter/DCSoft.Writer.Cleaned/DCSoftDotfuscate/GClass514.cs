using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass514 : GClass504
	{
		private ArrayList arrayList_0 = new ArrayList();

		public void method_8(string string_0, GClass504 gclass504_0)
		{
			method_12(string_0);
			method_11(new GClass518(string_0, gclass504_0));
		}

		public void method_9(string string_0, string string_1)
		{
			method_12(string_0);
			method_11(new GClass518(string_0, new GClass509(string_1)));
		}

		public void method_10(string string_0, int int_2)
		{
			method_12(string_0);
			method_11(new GClass518(string_0, new GClass507(int_2)));
		}

		public void method_11(GClass518 gclass518_0)
		{
			if (gclass518_0 != null)
			{
				arrayList_0.Add(gclass518_0);
			}
		}

		public void method_12(string string_0)
		{
			method_13(method_17(string_0));
		}

		public void method_13(GClass518 gclass518_0)
		{
			if (gclass518_0 != null)
			{
				arrayList_0.Remove(gclass518_0);
			}
		}

		public void method_14()
		{
			arrayList_0.Clear();
		}

		public int method_15()
		{
			return arrayList_0.Count;
		}

		public GClass518 method_16(int int_2)
		{
			return (GClass518)arrayList_0[int_2];
		}

		public GClass518 method_17(string string_0)
		{
			foreach (GClass518 item in arrayList_0)
			{
				if (item.method_0().method_8() == string_0)
				{
					return item;
				}
			}
			return null;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			int num = 3;
			streamWriter_0.Write("<< ");
			if (arrayList_0.Count > 0)
			{
				streamWriter_0.WriteLine();
			}
			foreach (GClass518 item in arrayList_0)
			{
				item.method_2(streamWriter_0);
				streamWriter_0.WriteLine();
			}
			streamWriter_0.Write(">>");
		}

		public override void Dispose()
		{
			base.Dispose();
			if (arrayList_0 != null)
			{
				ArrayList arrayList = arrayList_0;
				arrayList_0 = null;
				foreach (GClass518 item in arrayList)
				{
					if (item.method_1() != null)
					{
						item.method_1().Dispose();
					}
				}
			}
		}
	}
}
