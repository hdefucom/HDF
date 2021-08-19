using DCSoft.WinForms.Native;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class CaptureMouseMoveEventArgs : EventArgs
	{
		private object object_0 = null;

		private MouseCapturer mouseCapturer_0 = null;

		private Point point_0 = Point.Empty;

		private Point point_1 = Point.Empty;

		private bool bool_0 = false;

		public CaptureMouseMoveEventArgs(MouseCapturer mouseCapturer_1, Point point_2, Point point_3)
		{
			mouseCapturer_0 = mouseCapturer_1;
			point_0 = point_2;
			point_1 = point_3;
			if (mouseCapturer_1 != null)
			{
				object_0 = mouseCapturer_1.Tag;
			}
		}

		public object method_0()
		{
			return object_0;
		}

		public void method_1(object object_1)
		{
			object_0 = object_1;
		}

		public MouseCapturer method_2()
		{
			return mouseCapturer_0;
		}

		public Point method_3()
		{
			return point_0;
		}

		public void method_4(Point point_2)
		{
			point_0 = point_2;
		}

		public Point method_5()
		{
			return point_1;
		}

		public void method_6(Point point_2)
		{
			point_1 = point_2;
		}

		public int method_7()
		{
			return point_1.X - point_0.X;
		}

		public int method_8()
		{
			return point_1.Y - point_0.Y;
		}

		public bool method_9()
		{
			return bool_0;
		}

		public void method_10(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public bool method_11()
		{
			return mouseCapturer_0.CancelFlag;
		}

		public void method_12(bool bool_1)
		{
			mouseCapturer_0.CancelFlag = bool_1;
		}
	}
}
