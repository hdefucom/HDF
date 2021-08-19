using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass329
	{
		private object object_0 = null;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private bool bool_0 = false;

		private bool bool_1 = true;

		private Cursor cursor_0 = null;

		private int int_0 = -1;

		public GClass329()
		{
		}

		public GClass329(float float_2, float float_3, Cursor cursor_1)
		{
			float_0 = float_2;
			float_1 = float_3;
			cursor_0 = cursor_1;
		}

		public GClass329(float float_2, float float_3, Cursor cursor_1, int int_1)
		{
			float_0 = float_2;
			float_1 = float_3;
			cursor_0 = cursor_1;
			int_0 = int_1;
		}

		public object method_0()
		{
			return object_0;
		}

		public void method_1(object object_1)
		{
			object_0 = object_1;
		}

		public float method_2()
		{
			return float_0;
		}

		public void method_3(float float_2)
		{
			float_0 = float_2;
		}

		public float method_4()
		{
			return float_1;
		}

		public void method_5(float float_2)
		{
			float_1 = float_2;
		}

		public bool method_6()
		{
			return bool_0;
		}

		public void method_7(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_8()
		{
			return bool_1;
		}

		public void method_9(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public Cursor method_10()
		{
			return cursor_0;
		}

		public void method_11(Cursor cursor_1)
		{
			cursor_0 = cursor_1;
		}

		public int method_12()
		{
			return int_0;
		}

		public void method_13(int int_1)
		{
			int_0 = int_1;
		}

		public bool method_14(float float_2, float float_3, float float_4)
		{
			return new RectangleF(method_2() - float_4 / 2f, method_4() - float_4 / 2f, float_4, float_4).Contains(float_2, float_3);
		}

		public GClass329 method_15()
		{
			return (GClass329)MemberwiseClone();
		}
	}
}
