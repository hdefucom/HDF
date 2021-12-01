using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class GControl7 : Control
	{
		private bool bool_0 = true;

		private IntPtr intptr_0 = IntPtr.Zero;

		public GControl7()
		{
		}

		public GControl7(IntPtr intptr_1)
		{
			method_3(intptr_1);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			method_4();
		}

		public IntPtr method_2()
		{
			return intptr_0;
		}

		public void method_3(IntPtr intptr_1)
		{
			intptr_0 = intptr_1;
			method_4();
		}

		public void method_4()
		{
			if (base.IsHandleCreated)
			{
				GClass244 gClass = new GClass244(method_2());
				if (gClass.method_37())
				{
					gClass.method_20(base.Handle);
					gClass.method_13(bool_2: true);
					gClass.method_9(new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height));
				}
			}
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			method_4();
			GClass244 gClass = new GClass244(method_2());
			if (gClass.method_37())
			{
				gClass.method_9(new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height));
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		protected override void OnHandleDestroyed(EventArgs eventArgs_0)
		{
			base.OnHandleDestroyed(eventArgs_0);
			if (method_0())
			{
				GClass244 gClass = new GClass244(method_2());
				if (gClass.method_37())
				{
					gClass.method_32();
					gClass.method_14();
				}
			}
		}
	}
}
