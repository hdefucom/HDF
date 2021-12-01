using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass428
	{
		private bool bool_0 = false;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private bool bool_3 = false;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private Color color_0 = Color.Black;

		private bool bool_4 = false;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_5)
		{
			bool_0 = bool_5;
		}

		public bool method_2()
		{
			return bool_1;
		}

		public void method_3(bool bool_5)
		{
			bool_1 = bool_5;
		}

		public bool method_4()
		{
			return bool_2;
		}

		public void method_5(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public bool method_6()
		{
			return bool_3;
		}

		public void method_7(bool bool_5)
		{
			bool_3 = bool_5;
		}

		public DashStyle method_8()
		{
			return dashStyle_0;
		}

		public void method_9(DashStyle dashStyle_1)
		{
			dashStyle_0 = dashStyle_1;
		}

		public Color method_10()
		{
			return color_0;
		}

		public void method_11(Color color_1)
		{
			color_0 = color_1;
		}

		public bool method_12()
		{
			return bool_4;
		}

		public void method_13(bool bool_5)
		{
			bool_4 = bool_5;
		}

		public GClass428 method_14()
		{
			GClass428 gClass = new GClass428();
			gClass.bool_3 = bool_3;
			gClass.color_0 = color_0;
			gClass.bool_0 = bool_0;
			gClass.bool_2 = bool_2;
			gClass.dashStyle_0 = dashStyle_0;
			gClass.bool_1 = bool_1;
			gClass.bool_4 = bool_4;
			return gClass;
		}

		public bool method_15(GClass428 gclass428_0)
		{
			if (gclass428_0 == this)
			{
				return true;
			}
			if (gclass428_0 == null)
			{
				return false;
			}
			if (gclass428_0.bool_3 != bool_3 || gclass428_0.color_0 != color_0 || gclass428_0.bool_0 != bool_0 || gclass428_0.bool_2 != bool_2 || gclass428_0.dashStyle_0 != dashStyle_0 || gclass428_0.bool_1 != bool_1 || gclass428_0.bool_4 != bool_4)
			{
				return false;
			}
			return true;
		}
	}
}
