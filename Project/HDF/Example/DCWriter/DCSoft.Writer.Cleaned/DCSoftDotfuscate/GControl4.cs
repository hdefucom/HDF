using DCSoft.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class GControl4 : Control
	{
		private class Class179
		{
			public string string_0 = null;

			public Color color_0 = Color.Empty;

			public Color color_1 = Color.Empty;

			public Image image_0 = null;

			public int int_0 = 0;

			public int int_1 = 0;

			public int int_2 = 0;

			public int int_3 = 0;

			public bool bool_0 = true;

			public bool bool_1 = false;

			public bool bool_2 = false;

			public Rectangle method_0()
			{
				return new Rectangle(int_0, int_1, int_2, int_3);
			}
		}

		private Color[,] color_0 = null;

		private bool bool_0 = false;

		private bool bool_1 = true;

		private Color color_1 = Color.Black;

		private int int_0 = 14;

		private Color color_2 = Color.Empty;

		private EventHandler eventHandler_0 = null;

		private bool bool_2 = false;

		private GDelegate10 gdelegate10_0 = null;

		private Size size_0 = Size.Empty;

		private Class179 class179_0 = null;

		private List<Class179> list_0 = null;

		public GControl4()
		{
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
		}

		private void method_0()
		{
			if (color_0 == null)
			{
				color_0 = new Color[10, 7]
				{
					{
						method_1(255, 255, 255),
						method_1(210, 210, 210),
						method_1(186, 186, 186),
						method_1(154, 154, 154),
						method_1(130, 130, 130),
						method_1(114, 114, 114),
						method_1(178, 14, 18)
					},
					{
						method_1(0, 0, 0),
						method_1(114, 114, 114),
						method_1(106, 106, 106),
						method_1(78, 78, 78),
						method_1(54, 54, 54),
						method_1(30, 30, 30),
						method_1(234, 22, 30)
					},
					{
						method_1(246, 234, 210),
						method_1(182, 174, 166),
						method_1(154, 150, 142),
						method_1(114, 110, 106),
						method_1(78, 74, 70),
						method_1(54, 50, 50),
						method_1(254, 186, 10)
					},
					{
						method_1(26, 62, 114),
						method_1(194, 206, 218),
						method_1(134, 154, 182),
						method_1(78, 106, 150),
						method_1(18, 46, 82),
						method_1(10, 30, 54),
						method_1(255, 255, 0)
					},
					{
						method_1(82, 122, 174),
						method_1(210, 222, 243),
						method_1(166, 186, 214),
						method_1(122, 154, 194),
						method_1(58, 86, 126),
						method_1(38, 54, 78),
						method_1(150, 214, 66)
					},
					{
						method_1(186, 70, 66),
						method_1(238, 206, 206),
						method_1(218, 158, 158),
						method_1(202, 114, 110),
						method_1(134, 50, 46),
						method_1(86, 34, 30),
						method_1(26, 170, 66)
					},
					{
						method_1(150, 182, 86),
						method_1(226, 238, 210),
						method_1(202, 218, 170),
						method_1(174, 198, 126),
						method_1(106, 130, 62),
						method_1(66, 82, 38),
						method_1(2, 178, 238)
					},
					{
						method_1(128, 102, 160),
						method_1(223, 216, 231),
						method_1(191, 178, 207),
						method_1(159, 140, 183),
						method_1(96, 76, 120),
						method_1(64, 51, 80),
						method_1(0, 114, 188)
					},
					{
						method_1(75, 172, 198),
						method_1(210, 234, 240),
						method_1(165, 213, 226),
						method_1(120, 192, 212),
						method_1(56, 129, 148),
						method_1(37, 86, 99),
						method_1(47, 54, 153)
					},
					{
						method_1(245, 157, 86),
						method_1(252, 230, 212),
						method_1(250, 206, 170),
						method_1(247, 181, 128),
						method_1(183, 117, 64),
						method_1(122, 78, 43),
						method_1(111, 49, 152)
					}
				};
			}
		}

		private Color method_1(int int_1, int int_2, int int_3)
		{
			return Color.FromArgb(int_1, int_2, int_3);
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_3)
		{
			bool_1 = bool_3;
			if (base.IsHandleCreated)
			{
				list_0 = null;
				Invalidate();
			}
		}

		public Color method_6()
		{
			return color_1;
		}

		public void method_7(Color color_3)
		{
			color_1 = color_3;
			if (base.IsHandleCreated)
			{
				Invalidate();
			}
		}

		public int method_8()
		{
			return int_0;
		}

		public void method_9(int int_1)
		{
			int_0 = int_1;
			if (base.IsHandleCreated)
			{
				list_0 = null;
				Invalidate();
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			base.OnMouseMove(mevent);
			foreach (Class179 item in method_20())
			{
				if (item.bool_0 && item.method_0().Contains(mevent.X, mevent.Y))
				{
					if (class179_0 != item)
					{
						class179_0 = item;
						Invalidate();
					}
					return;
				}
			}
			if (class179_0 != null)
			{
				class179_0 = null;
				Invalidate();
			}
		}

		public Color method_10()
		{
			return color_2;
		}

		public void method_11(Color color_3)
		{
			color_2 = color_3;
		}

		public void method_12(EventHandler eventHandler_1)
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

		public void method_13(EventHandler eventHandler_1)
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

		public void method_14()
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, EventArgs.Empty);
			}
		}

		public bool method_15()
		{
			return bool_2;
		}

		public void method_16(GDelegate10 gdelegate10_1)
		{
			GDelegate10 gDelegate = gdelegate10_0;
			GDelegate10 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate10 value = (GDelegate10)Delegate.Combine(gDelegate2, gdelegate10_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate10_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_17(GDelegate10 gdelegate10_1)
		{
			GDelegate10 gDelegate = gdelegate10_0;
			GDelegate10 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate10 value = (GDelegate10)Delegate.Remove(gDelegate2, gdelegate10_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate10_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_18(GEventArgs6 geventArgs6_0)
		{
			bool_2 = true;
			try
			{
				if (gdelegate10_0 == null)
				{
					using (ColorDialog colorDialog = new ColorDialog())
					{
						colorDialog.Color = geventArgs6_0.method_0();
						if (colorDialog.ShowDialog(this) == DialogResult.OK)
						{
							geventArgs6_0.method_1(colorDialog.Color);
						}
						else
						{
							geventArgs6_0.method_3(bool_1: true);
						}
					}
				}
				else
				{
					gdelegate10_0(this, geventArgs6_0);
				}
			}
			finally
			{
				bool_2 = false;
			}
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			base.OnMouseLeave(eventArgs_0);
			if (class179_0 != null)
			{
				class179_0 = null;
				Invalidate();
			}
		}

		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseClick(mouseEventArgs_0);
			foreach (Class179 item in method_20())
			{
				if (item.bool_0 && item.method_0().Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y))
				{
					if (item.bool_2)
					{
						GEventArgs6 gEventArgs = new GEventArgs6(item.color_0);
						method_18(gEventArgs);
						if (!gEventArgs.method_2())
						{
							if (item.color_0 != gEventArgs.method_0())
							{
								item.color_0 = gEventArgs.method_0();
								if (base.IsHandleCreated)
								{
									Invalidate();
								}
							}
							color_2 = gEventArgs.method_0();
							method_14();
						}
					}
					else
					{
						color_2 = item.color_0;
						method_14();
					}
					break;
				}
			}
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			foreach (Class179 item in method_20())
			{
				if (pevent.ClipRectangle.IntersectsWith(item.method_0()))
				{
					if (!item.color_1.IsEmpty)
					{
						using (SolidBrush brush = new SolidBrush(item.color_1))
						{
							pevent.Graphics.FillRectangle(brush, item.method_0());
						}
					}
					if (string.IsNullOrEmpty(item.string_0))
					{
						using (SolidBrush brush = new SolidBrush(item.color_0))
						{
							pevent.Graphics.FillRectangle(brush, item.int_0, item.int_1, item.int_2, item.int_3);
							pevent.Graphics.DrawRectangle(Pens.LightGray, item.int_0, item.int_1, item.int_2, item.int_3);
						}
					}
					else
					{
						RectangleF rectangleF = new RectangleF(item.int_0, item.int_1, item.int_2, item.int_3);
						if (item.image_0 != null)
						{
							pevent.Graphics.DrawImage(item.image_0, rectangleF.Left + 1f, rectangleF.Top + (rectangleF.Height - (float)item.image_0.Height) / 2f);
							rectangleF.X += item.image_0.Width + 3;
							rectangleF.Width -= item.image_0.Width + 3;
						}
						else if (!item.color_0.IsEmpty)
						{
							using (SolidBrush brush = new SolidBrush(item.color_0))
							{
								Rectangle rect = new Rectangle((int)(rectangleF.Left + 3f), (int)(rectangleF.Top + (rectangleF.Height - (float)method_8()) / 2f), method_8(), method_8());
								pevent.Graphics.FillRectangle(brush, rect);
								pevent.Graphics.DrawRectangle(Pens.LightGray, rect);
							}
							rectangleF.X += method_8() + 5;
							rectangleF.Width -= method_8() + 5;
						}
						using (StringFormat stringFormat = new StringFormat())
						{
							stringFormat.Alignment = StringAlignment.Near;
							stringFormat.LineAlignment = StringAlignment.Near;
							Font font = Font;
							if (item.bool_1)
							{
								font = new Font(font, FontStyle.Bold);
							}
							pevent.Graphics.DrawString(item.string_0, font, Brushes.Black, rectangleF.Left, rectangleF.Top + 4f);
							if (item.bool_1)
							{
								font.Dispose();
							}
						}
					}
					bool flag = false;
					if (item.bool_0)
					{
						if (item == class179_0)
						{
							flag = true;
						}
						else if (item.color_0.ToArgb() == method_10().ToArgb() && !item.bool_2)
						{
							flag = true;
						}
					}
					if (flag)
					{
						pevent.Graphics.DrawRectangle(Pens.Red, item.int_0, item.int_1, item.int_2, item.int_3);
						pevent.Graphics.DrawRectangle(Pens.White, item.int_0 + 1, item.int_1 + 1, item.int_2 - 2, item.int_3 - 2);
					}
				}
			}
		}

		public Size method_19()
		{
			if (size_0.IsEmpty)
			{
				method_21();
			}
			return size_0;
		}

		private List<Class179> method_20()
		{
			if (list_0 == null)
			{
				method_21();
			}
			return list_0;
		}

		public void method_21()
		{
			int num = 18;
			method_0();
			int num2 = 0;
			using (Graphics graphics = CreateGraphics())
			{
				num2 = (int)Math.Ceiling(graphics.MeasureString("#", Font).Height) + 7;
			}
			list_0 = new List<Class179>();
			int num3 = 1;
			int num4 = 1;
			int num5 = method_8() + 4;
			int num6 = 10 * num5;
			Class179 @class = null;
			if (method_4())
			{
				@class = new Class179();
				@class.string_0 = DCColorPlateResource.AutoColor;
				@class.color_0 = method_6();
				@class.int_0 = num3;
				@class.int_1 = num4;
				@class.int_2 = num6;
				@class.int_3 = num2;
				@class.color_1 = SystemColors.Window;
				list_0.Add(@class);
				num4 = num4 + num2 + 2;
			}
			@class = new Class179();
			@class.string_0 = DCColorPlateResource.ThemeColors;
			@class.bool_1 = true;
			@class.int_0 = num3;
			@class.int_1 = num4;
			@class.int_2 = num6;
			@class.int_3 = num2;
			@class.color_1 = Color.FromArgb(221, 231, 238);
			@class.bool_0 = false;
			list_0.Add(@class);
			num4 = @class.int_1 + @class.int_3 + 3;
			int length = color_0.GetLength(0);
			int length2 = color_0.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				@class = new Class179();
				@class.color_0 = color_0[i, 0];
				@class.int_0 = num3 + num5 * i;
				@class.int_1 = num4;
				@class.int_2 = method_8();
				@class.int_3 = method_8();
				@class.color_1 = SystemColors.Window;
				list_0.Add(@class);
			}
			num4 += num5;
			for (int j = 1; j < length2 - 1; j++)
			{
				for (int i = 0; i < length; i++)
				{
					@class = new Class179();
					@class.color_0 = color_0[i, j];
					@class.int_0 = num3 + num5 * i;
					@class.int_1 = num4;
					@class.color_1 = SystemColors.Window;
					@class.int_2 = method_8();
					@class.int_3 = method_8();
					list_0.Add(@class);
				}
				num4 = num4 + method_8() + 1;
			}
			num4 += 4;
			@class = new Class179();
			@class.string_0 = DCColorPlateResource.StandardColors;
			@class.color_1 = Color.FromArgb(221, 231, 238);
			@class.bool_1 = true;
			@class.int_0 = num3;
			@class.int_1 = num4;
			@class.int_2 = num6;
			@class.int_3 = num2;
			@class.bool_0 = false;
			list_0.Add(@class);
			num4 = num4 + num2 + 3;
			for (int i = 0; i < length; i++)
			{
				@class = new Class179();
				@class.color_0 = color_0[i, length2 - 1];
				@class.int_0 = num3 + num5 * i;
				@class.int_1 = num4;
				@class.color_1 = SystemColors.Window;
				@class.int_2 = method_8();
				@class.int_3 = method_8();
				list_0.Add(@class);
			}
			num4 += num5;
			num4 += 3;
			if (method_2())
			{
				@class = new Class179();
				@class.string_0 = DCColorPlateResource.TransparentColor;
				@class.int_0 = num3;
				@class.int_1 = num4;
				@class.int_2 = num6;
				@class.int_3 = num2;
				@class.color_0 = Color.Transparent;
				list_0.Add(@class);
				num4 += @class.int_3;
				num4 += 3;
			}
			@class = new Class179();
			@class.string_0 = DCColorPlateResource.MoreColors;
			@class.int_0 = num3;
			@class.int_1 = num4;
			@class.int_2 = num6;
			@class.int_3 = num2;
			@class.bool_2 = true;
			@class.image_0 = DCColorPlateResource.palette;
			list_0.Add(@class);
			num4 += num2;
			num4 += 2;
			size_0 = new Size(num6, num4);
		}
	}
}
