using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	[TypeConverter(typeof(GClass311))]
	public class GClass309
	{
		private Image image_0 = null;

		private int int_0 = 0;

		private string string_0 = null;

		private bool bool_0 = false;

		private string string_1 = null;

		private object object_0 = null;

		public Image method_0()
		{
			return image_0;
		}

		public void method_1(Image image_1)
		{
			image_0 = image_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_1)
		{
			int_0 = int_1;
		}

		public string method_4()
		{
			return string_0;
		}

		public void method_5(string string_2)
		{
			string_0 = string_2;
		}

		public bool method_6()
		{
			return bool_0;
		}

		public void method_7(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public string method_8()
		{
			return string_1;
		}

		public void method_9(string string_2)
		{
			string_1 = string_2;
		}

		public object method_10()
		{
			return object_0;
		}

		public void method_11(object object_1)
		{
			object_0 = object_1;
		}

		public override string ToString()
		{
			return method_4();
		}
	}
}
