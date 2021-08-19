using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass373 : GInterface22
	{
		private class Class197
		{
			public XDependencyObject xdependencyObject_0 = null;

			public GClass371 gclass371_0 = null;

			public object object_0 = null;

			public object object_1 = null;
		}

		private bool bool_0 = true;

		private List<Class197> list_0 = new List<Class197>();

		public bool imethod_0()
		{
			return bool_0;
		}

		public void method_0(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public int method_1()
		{
			return list_0.Count;
		}

		public void imethod_1(XDependencyObject xdependencyObject_0, GClass371 gclass371_0, object object_0, object object_1)
		{
			if (imethod_0())
			{
				foreach (Class197 item in list_0)
				{
					if (item.xdependencyObject_0 == xdependencyObject_0 && item.gclass371_0 == gclass371_0)
					{
						item.object_1 = object_1;
						return;
					}
				}
				Class197 @class = new Class197();
				@class.xdependencyObject_0 = xdependencyObject_0;
				@class.gclass371_0 = gclass371_0;
				@class.object_0 = object_0;
				@class.object_1 = object_1;
				list_0.Add(@class);
			}
		}

		public void method_2()
		{
			for (int num = list_0.Count - 1; num >= 0; num--)
			{
				Class197 @class = list_0[num];
				@class.xdependencyObject_0.vmethod_1(@class.gclass371_0, @class.object_0);
			}
		}

		public void method_3()
		{
			foreach (Class197 item in list_0)
			{
				item.xdependencyObject_0.vmethod_1(item.gclass371_0, item.object_1);
			}
		}
	}
}
