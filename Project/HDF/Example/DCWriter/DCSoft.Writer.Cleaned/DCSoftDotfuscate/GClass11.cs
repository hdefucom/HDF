using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass11 : GClass9
	{
		public static void smethod_0(ListControl listControl_1)
		{
			int num = 15;
			if (listControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			GClass11 gClass = new GClass11();
			gClass.method_1(listControl_1);
		}

		public override Size vmethod_2()
		{
			if (method_0() is ComboBox)
			{
				ComboBox comboBox = (ComboBox)method_0();
				return new Size(40, comboBox.ItemHeight);
			}
			return new Size(40, 25);
		}

		public override void vmethod_4(Graphics graphics_0, Rectangle rectangle_0, object object_1)
		{
			graphics_0.FillRectangle(Brushes.White, rectangle_0);
			using (Pen pen = new Pen(Color.Black))
			{
				pen.Width = 3f;
				pen.DashStyle = (DashStyle)object_1;
				int num = rectangle_0.Top + rectangle_0.Height / 2;
				graphics_0.DrawLine(pen, rectangle_0.Left, num, rectangle_0.Right, num);
			}
		}

		public override IEnumerable vmethod_3()
		{
			return new object[5]
			{
				DashStyle.Dash,
				DashStyle.DashDot,
				DashStyle.DashDotDot,
				DashStyle.Dot,
				DashStyle.Solid
			};
		}
	}
}
