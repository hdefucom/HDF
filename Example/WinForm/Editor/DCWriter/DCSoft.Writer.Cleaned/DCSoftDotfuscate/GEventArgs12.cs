using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs12 : EventArgs
	{
		private XDependencyObject xdependencyObject_0 = null;

		private GClass371 gclass371_0 = null;

		private object object_0 = null;

		private object object_1 = null;

		private bool bool_0 = false;

		internal GEventArgs12(XDependencyObject xdependencyObject_1, GClass371 gclass371_1, object object_2, object object_3)
		{
			xdependencyObject_0 = xdependencyObject_1;
			gclass371_0 = gclass371_1;
			object_0 = object_2;
			object_1 = object_3;
		}

		public XDependencyObject method_0()
		{
			return xdependencyObject_0;
		}

		public GClass371 method_1()
		{
			return gclass371_0;
		}

		public object method_2()
		{
			return object_0;
		}

		public object method_3()
		{
			return object_1;
		}

		public void method_4(object object_2)
		{
			object_1 = object_2;
		}

		public bool method_5()
		{
			return bool_0;
		}

		public void method_6(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}
