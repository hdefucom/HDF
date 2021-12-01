using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass254
	{
		private long long_0 = 0L;

		private int int_0 = 0;

		private int int_1 = 0;

		public bool method_0(MouseEventArgs mouseEventArgs_0)
		{
			bool result = false;
			if (mouseEventArgs_0.Button == MouseButtons.Left)
			{
				long ticks = DateTime.Now.Ticks;
				if (ticks - long_0 <= SystemInformation.DoubleClickTime * 10000 && Math.Abs(mouseEventArgs_0.X - int_0) <= SystemInformation.DoubleClickSize.Width && Math.Abs(mouseEventArgs_0.Y - int_1) <= SystemInformation.DoubleClickSize.Height)
				{
					result = true;
				}
				long_0 = ticks;
				int_0 = mouseEventArgs_0.X;
				int_1 = mouseEventArgs_0.Y;
			}
			return result;
		}
	}
}
