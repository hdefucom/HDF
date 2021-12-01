using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass132
	{
		private bool bool_0 = false;

		private MouseButtons mouseButtons_0 = MouseButtons.None;

		private int int_0 = 0;

		private int int_1 = 0;

		private int int_2 = 0;

		private int int_3 = 0;

		public GClass132(DocumentEventArgs documentEventArgs_0)
		{
			mouseButtons_0 = documentEventArgs_0.Button;
			int_0 = documentEventArgs_0.X;
			int_1 = documentEventArgs_0.Y;
			int_2 = documentEventArgs_0.X;
			int_3 = documentEventArgs_0.Y;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public MouseButtons method_2()
		{
			return mouseButtons_0;
		}

		public void method_3(MouseButtons mouseButtons_1)
		{
			mouseButtons_0 = mouseButtons_1;
		}

		public int method_4()
		{
			return int_0;
		}

		public void method_5(int int_4)
		{
			int_0 = int_4;
		}

		public int method_6()
		{
			return int_1;
		}

		public void method_7(int int_4)
		{
			int_1 = int_4;
		}

		public int method_8()
		{
			return int_2;
		}

		public void method_9(int int_4)
		{
			int_2 = int_4;
		}

		public int method_10()
		{
			return int_3;
		}

		public void method_11(int int_4)
		{
			int_3 = int_4;
		}
	}
}
