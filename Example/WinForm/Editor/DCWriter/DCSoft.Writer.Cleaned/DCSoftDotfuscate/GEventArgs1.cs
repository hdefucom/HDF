using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs1 : EventArgs
	{
		private object object_0;

		private bool bool_0 = false;

		private object[] object_1 = new object[0];

		public object method_0()
		{
			return object_0;
		}

		public void method_1(object object_2)
		{
			object_0 = object_2;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public object[] method_4()
		{
			return object_1;
		}

		public void method_5(object[] object_2)
		{
			object_1 = object_2;
		}
	}
}
