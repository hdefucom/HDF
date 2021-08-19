using DCSoft.RTF;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass405
	{
		private int int_0 = 1;

		private LevelNumberType levelNumberType_0 = LevelNumberType.None;

		private int int_1 = 0;

		private int int_2 = 0;

		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_3)
		{
			int_0 = int_3;
		}

		public LevelNumberType method_2()
		{
			return levelNumberType_0;
		}

		public void method_3(LevelNumberType levelNumberType_1)
		{
			levelNumberType_0 = levelNumberType_1;
		}

		public int method_4()
		{
			return int_1;
		}

		public void method_5(int int_3)
		{
			int_1 = int_3;
		}

		public int method_6()
		{
			return int_2;
		}

		public void method_7(int int_3)
		{
			int_2 = int_3;
		}

		public string method_8()
		{
			return string_0;
		}

		public void method_9(string string_3)
		{
			string_0 = string_3;
		}

		public string method_10()
		{
			return string_1;
		}

		public void method_11(string string_3)
		{
			string_1 = string_3;
		}

		public string method_12()
		{
			return string_2;
		}

		public void method_13(string string_3)
		{
			string_2 = string_3;
		}

		public override string ToString()
		{
			int num = 3;
			StringBuilder stringBuilder = new StringBuilder();
			if (method_2() == LevelNumberType.Bullet)
			{
				stringBuilder.Append("Bullet:");
				if (!string.IsNullOrEmpty(method_10()))
				{
					stringBuilder.Append("(" + Convert.ToString((short)method_10()[0]) + ")");
				}
			}
			else
			{
				stringBuilder.Append(method_2().ToString() + " Start:" + method_0());
			}
			if (!string.IsNullOrEmpty(method_10()))
			{
				stringBuilder.Append(" LevelText:" + GClass414.smethod_3(method_10()));
			}
			if (!string.IsNullOrEmpty(method_12()))
			{
				stringBuilder.Append(" LevelNumbers:" + GClass414.smethod_3(method_12()));
			}
			return stringBuilder.ToString();
		}
	}
}
