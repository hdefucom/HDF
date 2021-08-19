using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ComVisible(false)]
	public class GClass368
	{
		private object object_0 = null;

		private int int_0 = 0;

		private int int_1 = 0;

		public GClass368()
		{
		}

		public GClass368(object object_1, int int_2)
		{
			method_1(object_1, int_2);
		}

		public object method_0()
		{
			if (object_0 == null)
			{
				return null;
			}
			if (Environment.TickCount - int_0 > int_1)
			{
				object_0 = null;
				return null;
			}
			return object_0;
		}

		public void method_1(object object_1, int int_2)
		{
			int num = 12;
			if (object_1 == null)
			{
				throw new ArgumentNullException("v");
			}
			if (int_2 <= 0)
			{
				throw new ArgumentOutOfRangeException(" tickDelay=" + int_2);
			}
			object_0 = object_1;
			int_1 = int_2;
			int_0 = Environment.TickCount;
		}

		public void method_2()
		{
			object_0 = null;
			int_0 = 0;
			int_1 = 0;
		}
	}
}
