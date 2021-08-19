using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DebuggerDisplay("Count={Count}")]
	[DebuggerTypeProxy(typeof(GClass421))]
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass418
	{
		private ArrayList arrayList_0 = new ArrayList();

		private bool bool_0 = true;

		public Color method_0(int int_0)
		{
			return (Color)arrayList_0[int_0];
		}

		public Color method_1(int int_0, Color color_0)
		{
			int_0--;
			if (int_0 >= 0 && int_0 < arrayList_0.Count)
			{
				return (Color)arrayList_0[int_0];
			}
			return color_0;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public void method_4(Color color_0)
		{
			if (color_0.IsEmpty || color_0.A == 0)
			{
				return;
			}
			if (color_0.A != byte.MaxValue)
			{
				color_0 = Color.FromArgb(255, color_0);
			}
			if (bool_0)
			{
				if (method_6(color_0) < 0)
				{
					arrayList_0.Add(color_0);
				}
			}
			else
			{
				arrayList_0.Add(color_0);
			}
		}

		public void method_5(Color color_0)
		{
			int num = method_6(color_0);
			if (num >= 0)
			{
				arrayList_0.RemoveAt(num);
			}
		}

		public int method_6(Color color_0)
		{
			if (color_0.A == 0)
			{
				return -1;
			}
			if (color_0.A != byte.MaxValue)
			{
				color_0 = Color.FromArgb(255, color_0);
			}
			int num = 0;
			while (true)
			{
				if (num < arrayList_0.Count)
				{
					if (((Color)arrayList_0[num]).ToArgb() == color_0.ToArgb())
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public int method_7(Color color_0)
		{
			int num = method_6(color_0);
			return num + 1;
		}

		public void method_8()
		{
			arrayList_0.Clear();
		}

		public int method_9()
		{
			return arrayList_0.Count;
		}

		public void method_10(GClass414 gclass414_0)
		{
			int num = 6;
			gclass414_0.method_10();
			gclass414_0.method_13("colortbl");
			gclass414_0.method_12(";");
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Color color = (Color)arrayList_0[i];
				gclass414_0.method_13("red" + color.R);
				gclass414_0.method_13("green" + color.G);
				gclass414_0.method_13("blue" + color.B);
				gclass414_0.method_12(";");
			}
			gclass414_0.method_11();
		}

		public GClass418 method_11()
		{
			GClass418 gClass = new GClass418();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Color color = (Color)arrayList_0[i];
				gClass.arrayList_0.Add(color);
			}
			return gClass;
		}
	}
}
