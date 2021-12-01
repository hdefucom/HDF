using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass542
	{
		private ArrayList arrayList_0 = new ArrayList();

		public void method_0(string string_0)
		{
			method_1(string_0, bool_0: true);
		}

		public void method_1(string string_0, bool bool_0)
		{
			if (bool_0)
			{
				string_0 += '\n';
			}
			if (arrayList_0.Count == 0)
			{
				arrayList_0.Add(new MemoryStream());
			}
			MemoryStream memoryStream = method_7() as MemoryStream;
			for (int i = 0; i < string_0.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(string_0[i]);
				if (BitConverter.IsLittleEndian)
				{
					memoryStream.WriteByte(bytes[0]);
				}
				else
				{
					memoryStream.WriteByte(bytes[1]);
				}
			}
		}

		public void method_2(string string_0, GClass476 gclass476_0)
		{
			arrayList_0.Add(string_0);
			arrayList_0.Add(gclass476_0);
			arrayList_0.Add(new MemoryStream());
		}

		public void method_3()
		{
			arrayList_0.Clear();
		}

		public void method_4(GClass515 gclass515_0)
		{
			for (int i = 0; i < method_5(); i++)
			{
				if (method_6(i) is MemoryStream)
				{
					((MemoryStream)method_6(i)).WriteTo(gclass515_0.method_13());
					continue;
				}
				string text = method_6(i++) as string;
				GClass476 gClass = method_6(i) as GClass476;
				gclass515_0.method_8((gClass != null) ? gClass.method_14(text) : text);
			}
		}

		public int method_5()
		{
			return arrayList_0.Count;
		}

		public object method_6(int int_0)
		{
			return arrayList_0[int_0];
		}

		public object method_7()
		{
			return method_6(method_5() - 1);
		}
	}
}
