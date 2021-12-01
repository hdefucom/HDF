using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs6 : EventArgs
	{
		private Color color_0 = Color.Empty;

		private bool bool_0 = false;

		public GEventArgs6(Color color_1)
		{
			color_0 = color_1;
		}

		public Color method_0()
		{
			return color_0;
		}

		public void method_1(Color color_1)
		{
			color_0 = color_1;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}
