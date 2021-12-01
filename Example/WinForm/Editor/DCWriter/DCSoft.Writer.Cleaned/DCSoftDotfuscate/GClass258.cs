using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class UpdateLock
	{
		private Control control_0 = null;

		private int int_0 = 0;

		private object object_0 = null;

		private EventHandler eventHandler_0 = null;

		public Control method_0()
		{
			return control_0;
		}

		public void method_1(Control control_1)
		{
			control_0 = control_1;
		}

		public void BeginUpdate()
		{
			int_0++;
		}

		public void EndUpdate()
		{
			int_0--;
			if (int_0 < 0)
			{
				int_0 = 0;
			}
			if (int_0 <= 0)
			{
				if (control_0 != null)
				{
					control_0.Update();
				}
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, null);
				}
			}
		}

		public bool CanUpdate()
		{
			return int_0 <= 0;
		}

		public bool IsUpdating()
		{
			return int_0 > 0;
		}

		public void method_6()
		{
			int_0 = 0;
		}

		public object method_7()
		{
			return object_0;
		}

		public void method_8(object object_1)
		{
			object_0 = object_1;
		}

		public void method_9(EventHandler eventHandler_1)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_10(EventHandler eventHandler_1)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}
}
