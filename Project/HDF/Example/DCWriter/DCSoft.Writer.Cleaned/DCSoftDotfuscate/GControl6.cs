using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	public class GControl6 : UserControl
	{
		protected SimpleRectangleTransform gclass435_0 = new SimpleRectangleTransform();

		protected bool bool_0 = false;

		protected Image image_0 = null;

		protected double double_0 = 1.0;

		protected Color color_0 = SystemColors.AppWorkspace;

		protected Color color_1 = Color.Red;

		protected bool bool_1 = false;

		public Rectangle method_0()
		{
			return gclass435_0.method_21();
		}

		public void method_1(Rectangle rectangle_0)
		{
			gclass435_0.set_SourceRect(rectangle_0);
			vmethod_0();
		}

		public Rectangle method_2()
		{
			return gclass435_0.method_27();
		}

		public Image method_3()
		{
			return image_0;
		}

		public void method_4(Image image_1)
		{
			image_0 = image_1;
		}

		public double method_5()
		{
			return double_0;
		}

		public virtual bool vmethod_0()
		{
			double_0 = 1.0;
			Rectangle rectangle = method_0();
			Rectangle clientRectangle = base.ClientRectangle;
			if (rectangle.Width * clientRectangle.Height > rectangle.Height * clientRectangle.Width)
			{
				double_0 = (double)clientRectangle.Width / (double)rectangle.Width;
			}
			else
			{
				double_0 = (double)clientRectangle.Height / (double)rectangle.Height;
			}
			double_0 *= 0.9;
			Rectangle empty = Rectangle.Empty;
			empty.Width = (int)((double)rectangle.Width * double_0);
			empty.Height = (int)((double)rectangle.Height * double_0);
			empty.X = (clientRectangle.Width - empty.Width) / 2;
			empty.Y = (clientRectangle.Height - empty.Height) / 2;
			gclass435_0.method_28(empty);
			return true;
		}

		public Color method_6()
		{
			return color_0;
		}

		public void method_7(Color color_2)
		{
			color_0 = color_2;
		}

		public Color method_8()
		{
			return color_1;
		}

		public void method_9(Color color_2)
		{
			color_1 = color_2;
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			bool_0 = true;
			using (SolidBrush brush = new SolidBrush(color_0))
			{
				pevent.Graphics.FillRectangle(brush, method_2());
				if (image_0 != null)
				{
					pevent.Graphics.DrawImage(image_0, new Rectangle(0, 0, image_0.Size.Width, image_0.Size.Height), method_2(), GraphicsUnit.Pixel);
					using (Pen pen = new Pen(color_1))
					{
						pevent.Graphics.DrawRectangle(pen, method_2());
					}
					Rectangle rectangle_ = method_10();
					if (rectangle_.Width > 0 && rectangle_.Height > 0)
					{
						IntPtr hdc = pevent.Graphics.GetHdc();
						GClass262.smethod_12(hdc, rectangle_);
						pevent.Graphics.ReleaseHdc(hdc);
					}
				}
			}
		}

		protected Rectangle method_10()
		{
			Point autoScrollPosition = base.AutoScrollPosition;
			Rectangle rectangle_ = new Rectangle(autoScrollPosition.X, autoScrollPosition.Y, base.ClientSize.Width, base.ClientSize.Height);
			rectangle_ = gclass435_0.vmethod_9(rectangle_);
			return RectangleCommon.MoveInto(rectangle_, method_2());
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (image_0 != null && method_2().Contains(mevent.X, mevent.Y))
			{
				if (!method_10().Contains(mevent.X, mevent.Y))
				{
					method_11(mevent.X, mevent.Y);
				}
				bool_1 = true;
			}
		}

		protected void method_11(int int_0, int int_1)
		{
			Size clientSize = base.ClientSize;
			clientSize = gclass435_0.vmethod_5(clientSize);
			int_0 -= clientSize.Width / 2;
			int_1 -= clientSize.Height / 2;
			Point point = gclass435_0.UnTransformPoint(int_0, int_1);
			Point autoScrollPosition = base.AutoScrollPosition;
			autoScrollPosition.X = -autoScrollPosition.X;
			autoScrollPosition.Y = -autoScrollPosition.Y;
			if (!autoScrollPosition.Equals(point))
			{
				base.AutoScrollPosition = new Point(point.X, point.Y);
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			base.OnMouseMove(mevent);
			if (image_0 != null && bool_1)
			{
				method_11(mevent.X, mevent.Y);
			}
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			bool_1 = false;
		}
	}
}
