using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass299
	{
		private Timer timer_0 = null;

		private EventHandler eventHandler_0 = null;

		public EventHandler method_0()
		{
			return eventHandler_0;
		}

		public void method_1(EventHandler eventHandler_1)
		{
			eventHandler_0 = eventHandler_1;
		}

		public void method_2(int int_0)
		{
			method_3(null, int_0);
		}

		public void method_3(EventHandler eventHandler_1, int int_0)
		{
			int num = 11;
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("millisecend=" + int_0);
			}
			if (eventHandler_1 != null)
			{
				method_1(eventHandler_1);
			}
			if (int_0 == 0)
			{
				eventHandler_1(this, null);
				return;
			}
			method_4();
			timer_0 = new Timer();
			timer_0.Interval = int_0;
			timer_0.Tick += timer_0_Tick;
			timer_0.Start();
		}

		public void method_4()
		{
			if (timer_0 != null)
			{
				timer_0.Stop();
				timer_0.Dispose();
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			timer_0.Stop();
			timer_0.Dispose();
			if (eventHandler_0 != null)
			{
				eventHandler_0(null, null);
			}
		}
	}
}
