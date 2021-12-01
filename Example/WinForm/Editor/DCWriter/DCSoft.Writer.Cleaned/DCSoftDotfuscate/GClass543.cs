using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass543
	{
		private bool bool_0 = false;

		private float float_0 = 734f;

		private float float_1 = 625f;

		private Color color_0 = Color.FromArgb(244, 244, 244);

		private float float_2 = 30f;

		private float float_3 = 9f;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public float method_2()
		{
			return float_0;
		}

		public void method_3(float float_4)
		{
			float_0 = float_4;
		}

		public float method_4()
		{
			return float_1;
		}

		public void method_5(float float_4)
		{
			float_1 = float_4;
		}

		public Color method_6()
		{
			return color_0;
		}

		public void method_7(Color color_1)
		{
			color_0 = color_1;
		}

		public float method_8()
		{
			return float_2;
		}

		public void method_9(float float_4)
		{
			float_2 = float_4;
		}

		public float method_10()
		{
			return float_3;
		}

		public void method_11(float float_4)
		{
			float_3 = float_4;
		}

		public GClass543 method_12()
		{
			return (GClass543)MemberwiseClone();
		}
	}
}
