using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[DefaultProperty("Items")]
	[DefaultEvent("SelectedIndexChagned")]
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class GControl8 : UserControl
	{
		private int int_0 = 0;

		private bool bool_0 = true;

		private int int_1 = 0;

		private GClass308 gclass308_0 = new GClass308();

		private ImageList imageList_0 = null;

		private bool bool_1 = false;

		private EventHandler eventHandler_0 = null;

		public GControl8()
		{
			AutoScroll = true;
			base.BorderStyle = BorderStyle.Fixed3D;
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
			int_1 = 0;
			bool_0 = true;
		}

		public void method_2()
		{
			if (bool_0)
			{
				method_3();
			}
		}

		public void method_3()
		{
			bool_0 = false;
			base.AutoScrollMinSize = new Size(1, method_4() * method_5().Count);
		}

		public int method_4()
		{
			if (int_0 > 0)
			{
				return int_0;
			}
			if (int_1 <= 0)
			{
				int_1 = (int)Font.GetHeight();
				foreach (GClass309 item in method_5())
				{
					if (item.method_0() != null)
					{
						int_1 = Math.Max(int_1, item.method_0().Height + 3);
					}
					else if (method_7() != null)
					{
						int_1 = Math.Max(int_1, method_7().ImageSize.Height + 3);
					}
				}
			}
			return int_1;
		}

		public GClass308 method_5()
		{
			if (gclass308_0 == null)
			{
				gclass308_0 = new GClass308();
			}
			return gclass308_0;
		}

		public void method_6(GClass308 gclass308_1)
		{
			gclass308_0 = gclass308_1;
			bool_0 = true;
		}

		public ImageList method_7()
		{
			return imageList_0;
		}

		public void method_8(ImageList imageList_1)
		{
			imageList_0 = imageList_1;
		}

		public bool method_9()
		{
			return bool_1;
		}

		public void method_10(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public void method_11(EventHandler eventHandler_1)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_12(EventHandler eventHandler_1)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public virtual void vmethod_0(EventArgs eventArgs_0)
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, eventArgs_0);
			}
		}

		public int method_13()
		{
			int num = 0;
			while (true)
			{
				if (num < method_5().Count)
				{
					if (method_5()[num].method_6())
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public void method_14(int int_2)
		{
			bool flag = false;
			for (int i = 0; i < method_5().Count; i++)
			{
				if (method_5()[i].method_6() != (i == int_2))
				{
					flag = true;
					method_5()[i].method_7(i == int_2);
					method_17(method_5()[i]);
				}
			}
			if (flag)
			{
				vmethod_0(EventArgs.Empty);
			}
		}

		public GClass309 method_15()
		{
			foreach (GClass309 item in method_5())
			{
				if (item.method_6())
				{
					return item;
				}
			}
			return null;
		}

		public void method_16(GClass309 gclass309_0)
		{
			bool flag = false;
			foreach (GClass309 item in method_5())
			{
				if (item.method_6() != (item == gclass309_0))
				{
					flag = true;
					item.method_7(item == gclass309_0);
					method_17(item);
				}
			}
			if (flag)
			{
				vmethod_0(EventArgs.Empty);
			}
		}

		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			method_2();
			if (mouseEventArgs_0.Button == MouseButtons.Left)
			{
				bool flag = false;
				GClass309 gClass = method_19(mouseEventArgs_0.X, mouseEventArgs_0.Y);
				if (method_9())
				{
					if (gClass != null)
					{
						gClass.method_7(!gClass.method_6());
						method_17(gClass);
						flag = true;
					}
				}
				else
				{
					foreach (GClass309 item in method_5())
					{
						if (item.method_6() != (item == gClass))
						{
							item.method_7(item == gClass);
							method_17(item);
							flag = true;
						}
					}
				}
				if (flag)
				{
					vmethod_0(EventArgs.Empty);
				}
			}
			base.OnMouseClick(mouseEventArgs_0);
		}

		private void method_17(GClass309 gclass309_0)
		{
			method_2();
			if (gclass309_0 != null)
			{
				Invalidate(method_18(gclass309_0));
			}
		}

		public Rectangle method_18(GClass309 gclass309_0)
		{
			int num = 2;
			method_2();
			if (gclass309_0 == null)
			{
				throw new ArgumentNullException("item");
			}
			int num2 = method_5().IndexOf(gclass309_0);
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("item not in list");
			}
			return new Rectangle(1, base.AutoScrollPosition.Y + method_4() * num2, base.ClientSize.Width - 2, method_4());
		}

		public GClass309 method_19(int int_2, int int_3)
		{
			method_2();
			int num = method_4();
			int num2 = (int)Math.Floor((double)int_3 * 1.0 / (double)num);
			if (num2 >= 0 && num2 < method_5().Count)
			{
				return method_5()[num2];
			}
			return null;
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			method_2();
			method_4();
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.FormatFlags = StringFormatFlags.NoWrap;
				using (SolidBrush brush = new SolidBrush(ForeColor))
				{
					foreach (GClass309 item in method_5())
					{
						Rectangle rect = method_18(item);
						if (rect.IntersectsWith(pevent.ClipRectangle))
						{
							if (item.method_6())
							{
								pevent.Graphics.FillRectangle(SystemBrushes.Highlight, rect);
							}
							Size size = Size.Empty;
							if (item.method_0() != null)
							{
								size = item.method_0().Size;
								pevent.Graphics.DrawImage(item.method_0(), rect.Left, rect.Top + (rect.Height - size.Height) / 2);
							}
							else if (method_7() != null)
							{
								size = method_7().ImageSize;
								if (item.method_2() >= 0 && item.method_2() < method_7().Images.Count)
								{
									method_7().Draw(pevent.Graphics, rect.Left, rect.Top + (rect.Height - size.Height) / 2, item.method_2());
								}
							}
							if (item.method_4() != null && item.method_4().Length > 0)
							{
								RectangleF layoutRectangle = new RectangleF(rect.Left + size.Width + 2, rect.Top, rect.Width - size.Width - 2, rect.Height);
								if (item.method_6())
								{
									pevent.Graphics.DrawString(item.method_4(), Font, SystemBrushes.HighlightText, layoutRectangle, stringFormat);
								}
								else
								{
									pevent.Graphics.DrawString(item.method_4(), Font, brush, layoutRectangle, stringFormat);
								}
							}
						}
					}
				}
			}
			base.OnPaint(pevent);
		}
	}
}
