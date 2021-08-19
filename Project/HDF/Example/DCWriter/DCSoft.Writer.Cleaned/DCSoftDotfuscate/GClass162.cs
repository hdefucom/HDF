using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass162
	{
		private Control control_0;

		private PropertyInfo propertyInfo_0;

		private Point point_0;

		public GClass162(Control control_1)
		{
			int num = 2;
			control_0 = null;
			propertyInfo_0 = null;
			point_0 = Point.Empty;
			
			if (control_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			control_0 = control_1;
			if (control_0 is PrintPreviewControl)
			{
				propertyInfo_0 = control_0.GetType().GetProperty("Position", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (propertyInfo_0 != null)
				{
					control_0.MouseDown += control_0_MouseDown;
					control_0.MouseMove += control_0_MouseMove;
					control_0.MouseUp += control_0_MouseUp;
					control_0.MouseWheel += control_0_MouseWheel;
					control_0.Cursor = GClass291.smethod_4();
				}
			}
			else
			{
				control_0.MouseDown += control_0_MouseDown;
				control_0.MouseMove += control_0_MouseMove;
				control_0.MouseUp += control_0_MouseUp;
				control_0.MouseWheel += control_0_MouseWheel;
				control_0.Cursor = GClass291.smethod_4();
			}
		}

		private Point method_0()
		{
			if (control_0 is ScrollableControl)
			{
				return ((ScrollableControl)control_0).AutoScrollPosition;
			}
			if (propertyInfo_0 == null)
			{
				return Point.Empty;
			}
			return (Point)propertyInfo_0.GetValue(control_0, null);
		}

		private void method_1(Point point_1)
		{
			if (control_0 is ScrollableControl)
			{
				((ScrollableControl)control_0).AutoScrollPosition = point_1;
			}
			if (propertyInfo_0 != null)
			{
				propertyInfo_0.SetValue(control_0, point_1, null);
			}
		}

		private void control_0_MouseWheel(object sender, MouseEventArgs e)
		{
			Point point_ = method_0();
			if (e.Delta > 0)
			{
				point_.Y -= 30;
			}
			else
			{
				point_.Y += 30;
			}
			method_1(point_);
		}

		private void control_0_MouseUp(object sender, MouseEventArgs e)
		{
			point_0 = new Point(-1, -1);
			control_0.Cursor = GClass291.smethod_4();
		}

		private void control_0_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (point_0.X >= 0)
				{
					int num = e.X - point_0.X;
					int num2 = e.Y - point_0.Y;
					Point point_ = method_0();
					point_.X -= num;
					point_.Y -= num2;
					method_1(point_);
					point_0 = new Point(e.X, e.Y);
				}
			}
			else
			{
				point_0.X = -1;
			}
		}

		private void control_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				point_0 = new Point(e.X, e.Y);
				control_0.Cursor = GClass291.smethod_5();
			}
			else
			{
				point_0 = new Point(-1, -1);
			}
		}
	}
}
