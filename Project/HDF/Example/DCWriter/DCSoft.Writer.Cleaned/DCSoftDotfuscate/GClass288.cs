using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass288
	{
		private static GClass288[] gclass288_0 = null;

		private static GClass288[] gclass288_1 = null;

		private string string_0 = null;

		private float float_0 = 9f;

		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public static string smethod_0(float float_1, bool bool_0)
		{
			if (bool_0)
			{
				GClass288[] array = smethod_2();
				foreach (GClass288 gClass in array)
				{
					if ((double)Math.Abs(float_1 - gClass.method_0()) < 0.01)
					{
						return gClass.Name;
					}
				}
			}
			else
			{
				GClass288[] array = smethod_3();
				foreach (GClass288 gClass in array)
				{
					if ((double)Math.Abs(float_1 - gClass.method_0()) < 0.01)
					{
						return gClass.Name;
					}
				}
			}
			return float_1.ToString();
		}

		public static float smethod_1(string string_1, float float_1)
		{
			GClass288[] array = smethod_2();
			int num = 0;
			GClass288 gClass;
			while (true)
			{
				if (num < array.Length)
				{
					gClass = array[num];
					if (string.Compare(string_1, gClass.Name, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				float result = 0f;
				if (float.TryParse(string_1, out result))
				{
					return result;
				}
				return float_1;
			}
			return gClass.method_0();
		}

		public static GClass288[] smethod_2()
		{
			int num = 1;
			if (gclass288_0 == null)
			{
				ArrayList arrayList = new ArrayList();
				if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "zh")
				{
					arrayList.Add(new GClass288("初号", 42f));
					arrayList.Add(new GClass288("小初", 36f));
					arrayList.Add(new GClass288("一号", 26.25f));
					arrayList.Add(new GClass288("小一", 24f));
					arrayList.Add(new GClass288("二号", 21.75f));
					arrayList.Add(new GClass288("小二", 18f));
					arrayList.Add(new GClass288("三号", 15.75f));
					arrayList.Add(new GClass288("小三", 15f));
					arrayList.Add(new GClass288("四号", 14.25f));
					arrayList.Add(new GClass288("小四", 12f));
					arrayList.Add(new GClass288("五号", 10.5f));
					arrayList.Add(new GClass288("小五", 9f));
					arrayList.Add(new GClass288("六号", 7.5f));
					arrayList.Add(new GClass288("小六", 6.75f));
					arrayList.Add(new GClass288("七号", 5.25f));
					arrayList.Add(new GClass288("八号", 5.25f));
				}
				arrayList.Add(new GClass288(8f));
				arrayList.Add(new GClass288(9f));
				arrayList.Add(new GClass288(10f));
				arrayList.Add(new GClass288(11f));
				arrayList.Add(new GClass288(12f));
				arrayList.Add(new GClass288(14f));
				arrayList.Add(new GClass288(16f));
				arrayList.Add(new GClass288(18f));
				arrayList.Add(new GClass288(20f));
				arrayList.Add(new GClass288(22f));
				arrayList.Add(new GClass288(24f));
				arrayList.Add(new GClass288(26f));
				arrayList.Add(new GClass288(28f));
				arrayList.Add(new GClass288(36f));
				arrayList.Add(new GClass288(48f));
				arrayList.Add(new GClass288(72f));
				gclass288_0 = (GClass288[])arrayList.ToArray(typeof(GClass288));
			}
			return gclass288_0;
		}

		public static GClass288[] smethod_3()
		{
			if (gclass288_1 == null)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.Add(new GClass288(8f));
				arrayList.Add(new GClass288(9f));
				arrayList.Add(new GClass288(10f));
				arrayList.Add(new GClass288(11f));
				arrayList.Add(new GClass288(12f));
				arrayList.Add(new GClass288(14f));
				arrayList.Add(new GClass288(16f));
				arrayList.Add(new GClass288(18f));
				arrayList.Add(new GClass288(20f));
				arrayList.Add(new GClass288(22f));
				arrayList.Add(new GClass288(24f));
				arrayList.Add(new GClass288(26f));
				arrayList.Add(new GClass288(28f));
				arrayList.Add(new GClass288(36f));
				arrayList.Add(new GClass288(48f));
				arrayList.Add(new GClass288(72f));
				gclass288_1 = (GClass288[])arrayList.ToArray(typeof(GClass288));
			}
			return gclass288_1;
		}

		public GClass288(string string_1, float float_1)
		{
			string_0 = string_1;
			float_0 = float_1;
		}

		public GClass288(float float_1)
		{
			string_0 = float_1.ToString();
			float_0 = float_1;
		}

		public float method_0()
		{
			return float_0;
		}

		public void method_1(float float_1)
		{
			float_0 = float_1;
		}

		public override string ToString()
		{
			return string_0;
		}
	}
}
