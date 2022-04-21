using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public struct GStruct20
	{
		private bool bool_0;

		private float float_0;

		private float float_1;

		private int int_0;

		public GStruct20(bool bool_1)
		{
			int_0 = 0;
			bool_0 = bool_1;
			float_0 = 0f;
			float_1 = 0f;
		}

		public void method_0()
		{
			float_1 = 0f;
			int_0 = 0;
		}

		public bool method_1()
		{
			return bool_0;
		}

		public void method_2(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public void method_3()
		{
			if (bool_0)
			{
				float_0 = CountDown.GetTickCountFloat();
			}
		}

		public void method_4()
		{
			if (bool_0)
			{
				float float_ = CountDown.GetTickCountFloat() - float_0;
				method_5(float_);
			}
		}

		public void method_5(float float_2)
		{
			float_1 += float_2;
			int_0++;
		}

		public float method_6()
		{
			return float_1;
		}

		public void method_7(float float_2)
		{
			float_1 = float_2;
		}

		public int method_8()
		{
			return int_0;
		}

		public void method_9(int int_1)
		{
			int_0 = int_1;
		}

		public float method_10()
		{
			if (int_0 > 0)
			{
				return float_1 / (float)int_0;
			}
			return 0f;
		}

		public override string ToString()
		{
			return "Tick:" + float_1 + " Count:" + int_0 + " Average:" + method_10();
		}
	}
}
