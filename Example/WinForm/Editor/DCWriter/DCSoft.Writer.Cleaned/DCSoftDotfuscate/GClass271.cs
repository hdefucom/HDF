using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass271
	{
		private IntPtr intptr_0 = IntPtr.Zero;

		private IntPtr intptr_1 = IntPtr.Zero;

		private DockStyle dockStyle_0 = DockStyle.Fill;

		public IntPtr method_0()
		{
			return intptr_0;
		}

		public void method_1(IntPtr intptr_2)
		{
			intptr_0 = intptr_2;
		}

		public IntPtr method_2()
		{
			return intptr_1;
		}

		public void method_3(IntPtr intptr_2)
		{
			intptr_1 = intptr_2;
		}

		public DockStyle method_4()
		{
			return dockStyle_0;
		}

		public void method_5(DockStyle dockStyle_1)
		{
			dockStyle_0 = dockStyle_1;
		}

		public bool method_6()
		{
			GClass244 gClass = new GClass244(method_0());
			GClass244 gClass2 = new GClass244(method_2());
			if (!gClass.method_37() || !gClass2.method_37())
			{
				return false;
			}
			if (gClass.method_19() != gClass2.Handle && !gClass.method_29(gClass2.Handle))
			{
				return false;
			}
			Rectangle rectangle = gClass2.method_5();
			Rectangle rectangle2 = gClass.method_8();
			Rectangle rectangle3 = rectangle2;
			switch (method_4())
			{
			case DockStyle.Top:
				rectangle3 = new Rectangle(0, 0, rectangle.Width, rectangle2.Height);
				break;
			case DockStyle.Bottom:
				rectangle3 = new Rectangle(0, rectangle.Height - rectangle2.Height, rectangle.Width, rectangle2.Height);
				break;
			case DockStyle.Left:
				rectangle3 = new Rectangle(0, 0, rectangle2.Width, rectangle.Height);
				break;
			case DockStyle.Right:
				rectangle3 = new Rectangle(rectangle.Width - rectangle2.Width, 0, rectangle2.Width, rectangle.Height);
				break;
			case DockStyle.Fill:
				rectangle3 = rectangle;
				break;
			}
			if (rectangle3 != rectangle2)
			{
				gClass.method_9(rectangle3);
			}
			return true;
		}
	}
}
