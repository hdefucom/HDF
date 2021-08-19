using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass137
	{
		private bool bool_0 = false;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private bool bool_3 = false;

		private string[] string_0 = null;

		public GClass137(int int_0)
		{
			bool_0 = ((int_0 & 1) == 1);
			bool_1 = ((int_0 & 2) == 2);
			bool_2 = ((int_0 & 4) == 4);
			bool_3 = ((int_0 & 8) == 8);
		}

		public bool method_0()
		{
			CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
			string name = currentUICulture.Name;
			if (method_1(name))
			{
				return true;
			}
			if (currentUICulture.Parent != null && method_1(currentUICulture.Parent.Name))
			{
				return true;
			}
			return false;
		}

		private bool method_1(string string_1)
		{
			string[] array = method_11();
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					string strA = array[num];
					if (string.Compare(strA, string_1, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public int method_2()
		{
			int num = 0;
			if (method_3())
			{
				num++;
			}
			if (method_5())
			{
				num += 2;
			}
			if (method_7())
			{
				num += 4;
			}
			if (method_9())
			{
				num += 8;
			}
			return num;
		}

		public bool method_3()
		{
			return bool_0;
		}

		public void method_4(bool bool_4)
		{
			bool_0 = bool_4;
			string_0 = null;
		}

		public bool method_5()
		{
			return bool_1;
		}

		public void method_6(bool bool_4)
		{
			bool_1 = bool_4;
			string_0 = null;
		}

		public bool method_7()
		{
			return bool_2;
		}

		public void method_8(bool bool_4)
		{
			bool_2 = bool_4;
			string_0 = null;
		}

		public bool method_9()
		{
			return bool_3;
		}

		public void method_10(bool bool_4)
		{
			bool_3 = bool_4;
			string_0 = null;
		}

		private string[] method_11()
		{
			if (string_0 == null)
			{
				List<string> list = new List<string>();
				if (bool_0)
				{
					string text = "zh-CN,zh-CHS";
					list.AddRange(text.Split(','));
				}
				if (bool_1)
				{
					string text2 = "zh-HK,zh-MO,zh-SG,zh-TW,zh-CHT";
					list.AddRange(text2.Split(','));
				}
				if (bool_2)
				{
					int[] array = new int[2]
					{
						-194,
						-514
					};
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append((char)(array[0] + 291));
					stringBuilder.Append((char)(array[1] + 628));
					string item = stringBuilder.ToString();
					list.Add(item);
				}
				if (bool_3)
				{
					string item2 = "bo-CN";
					list.Add(item2);
				}
				string_0 = list.ToArray();
			}
			return string_0;
		}

		public override string ToString()
		{
			int num = 17;
			StringBuilder stringBuilder = new StringBuilder();
			if (method_3())
			{
				stringBuilder.Append(Class151.smethod_13() + " ");
			}
			if (bool_1)
			{
				stringBuilder.Append(Class151.smethod_14() + " ");
			}
			if (bool_2)
			{
				stringBuilder.Append(Class151.smethod_11() + " ");
			}
			if (bool_3)
			{
				stringBuilder.Append(Class151.smethod_12() + " ");
			}
			return stringBuilder.ToString();
		}
	}
}
