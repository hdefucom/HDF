using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass365 : IDisposable
	{
		public EventHandler eventHandler_0 = null;

		public EventHandler eventHandler_1 = null;

		private int int_0 = 0;

		private Hashtable hashtable_0 = new Hashtable();

		private object object_0 = null;

		public virtual void vmethod_0()
		{
			int_0 = 1;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, EventArgs.Empty);
			}
		}

		public virtual void vmethod_1()
		{
			if (int_0 == 1)
			{
				int_0 = 0;
				if (eventHandler_1 != null)
				{
					eventHandler_1(this, EventArgs.Empty);
				}
			}
		}

		public void Dispose()
		{
			vmethod_1();
		}

		public Hashtable method_0()
		{
			return hashtable_0;
		}

		public object method_1()
		{
			return object_0;
		}

		public void method_2(object object_1)
		{
			object_0 = object_1;
		}
	}
}
