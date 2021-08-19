#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass445 : IDisposable
	{
		private static Dictionary<Control, GClass445> dictionary_0 = new Dictionary<Control, GClass445>();

		private int int_0 = 0;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private volatile Thread thread_0 = null;

		private bool bool_0 = true;

		private bool bool_1 = false;

		private string string_0 = DrawingStrings.WaittingMessage;

		private Image image_0 = null;

		private XFontValue xfontValue_0 = null;

		private int int_1 = Environment.TickCount;

		private int int_2 = 0;

		private static Image image_1 = null;

		private static Color color_0 = Color.FromArgb(169, 223, 232);

		private static int int_3 = 32;

		private Bitmap bitmap_0 = null;

		private WinTaskBarProgressInfo winTaskBarProgressInfo_0 = null;

		private Control control_0 = null;

		private bool bool_2 = false;

		private Rectangle rectangle_1 = Rectangle.Empty;

		private Size size_0 = Size.Empty;

		private int int_4 = 0;

		private GClass445()
		{
		}

		public static GClass445 smethod_0(Control control_1, int int_5 = 400)
		{
			int num = 4;
			if (control_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (control_1.IsDisposed)
			{
				throw new ObjectDisposedException("ctl");
			}
			lock (dictionary_0)
			{
				GClass445 gClass;
				if (dictionary_0.ContainsKey(control_1))
				{
					gClass = dictionary_0[control_1];
					gClass.int_0++;
					return gClass;
				}
				gClass = new GClass445();
				gClass.control_0 = control_1;
				gClass.method_0();
				dictionary_0[control_1] = gClass;
				gClass.winTaskBarProgressInfo_0 = new WinTaskBarProgressInfo(control_1, supportCrossUIThread: true);
				gClass.method_1(int_5);
				return gClass;
			}
		}

		private static GClass445 smethod_1(Control control_1)
		{
			int num = 2;
			if (control_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (control_1.IsDisposed)
			{
				throw new ObjectDisposedException("ctl");
			}
			lock (dictionary_0)
			{
				if (dictionary_0.ContainsKey(control_1))
				{
					return dictionary_0[control_1];
				}
				return null;
			}
		}

		private void method_0()
		{
			if (control_0 != null && control_0.IsHandleCreated && !control_0.InvokeRequired)
			{
				rectangle_0.Size = control_0.ClientSize;
				rectangle_0.Location = control_0.PointToScreen(new Point(0, 0));
			}
		}

		private void method_1(int int_5)
		{
			if (int_5 > 0)
			{
				lock (this)
				{
					if (thread_0 == null)
					{
						thread_0 = new Thread(method_2);
					}
					thread_0.Start(int_5);
				}
			}
			else if (winTaskBarProgressInfo_0 != null)
			{
				winTaskBarProgressInfo_0.SetIndeterminate();
			}
		}

		private void method_2(object object_0)
		{
			try
			{
				if (winTaskBarProgressInfo_0 != null)
				{
					winTaskBarProgressInfo_0.SetIndeterminate();
				}
				int num = (int)object_0;
				if (num > 0)
				{
					Thread.Sleep(num);
				}
				if (thread_0 != null)
				{
					thread_0 = null;
					method_16();
				}
			}
			catch (ThreadAbortException)
			{
			}
			finally
			{
				thread_0 = null;
			}
		}

		public bool method_3()
		{
			return bool_0;
		}

		public void method_4(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public bool method_5()
		{
			return bool_1;
		}

		public void method_6(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public string method_7()
		{
			return string_0;
		}

		public void method_8(string string_1)
		{
			if (!method_5())
			{
				string_0 = string_1;
			}
		}

		public Image method_9()
		{
			return image_0;
		}

		public void method_10(Image image_2)
		{
			if (!method_5())
			{
				image_0 = image_2;
			}
		}

		public XFontValue method_11()
		{
			return xfontValue_0;
		}

		public void method_12(XFontValue xfontValue_1)
		{
			if (!method_5())
			{
				xfontValue_0 = xfontValue_1;
			}
		}

		public int method_13()
		{
			return int_2;
		}

		public void method_14(int int_5)
		{
			if (!method_5())
			{
				int_2 = int_5;
			}
		}

		public void method_15()
		{
			if (int_2 > 0)
			{
				int num = int_2 - (Environment.TickCount - int_1);
				if (num > 0)
				{
					Thread.Sleep(num);
				}
			}
		}

		public static Image smethod_2()
		{
			return image_1;
		}

		public static void smethod_3(Image image_2)
		{
			image_1 = image_2;
		}

		public static Color smethod_4()
		{
			return color_0;
		}

		public static void smethod_5(Color color_1)
		{
			color_0 = color_1;
		}

		public static int smethod_6()
		{
			return int_3;
		}

		public static void smethod_7(int int_5)
		{
			int_3 = int_5;
		}

		public void Dispose()
		{
			if (int_0 > 0)
			{
				int_0--;
				return;
			}
			method_15();
			bool_2 = true;
			if (winTaskBarProgressInfo_0 != null)
			{
				winTaskBarProgressInfo_0.Dispose();
				winTaskBarProgressInfo_0 = null;
			}
			if (dictionary_0.ContainsKey(control_0))
			{
				lock (dictionary_0)
				{
					dictionary_0.Remove(control_0);
				}
			}
			lock (this)
			{
				if (thread_0 != null)
				{
					Thread thread = thread_0;
					thread_0 = null;
					thread.Abort();
				}
			}
			if (bitmap_0 != null)
			{
				Bitmap bitmap = bitmap_0;
				bitmap_0 = null;
				if (control_0 != null && control_0.IsHandleCreated)
				{
					using (Graphics graphics = control_0.CreateGraphics())
					{
						graphics.DrawImage(bitmap, 0, 0);
					}
				}
				bitmap.Dispose();
			}
			if (control_0 != null && control_0.IsHandleCreated && method_3())
			{
				control_0.Invalidate();
			}
		}

		public static bool smethod_8(Control control_1)
		{
			int num = 16;
			if (control_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			lock (dictionary_0)
			{
				return dictionary_0.ContainsKey(control_1);
			}
		}

		public static void smethod_9(Control control_1, string string_1)
		{
			GClass445 gClass = smethod_1(control_1);
			if (gClass != null)
			{
				gClass.method_8(string_1);
				if (gClass.thread_0 == null && control_1 != null && !control_1.IsDisposed && control_1.Visible && gClass.method_3())
				{
					gClass.Paint();
				}
			}
		}

		public static bool smethod_10(Control control_1, PaintEventArgs paintEventArgs_0)
		{
			GClass445 gClass = smethod_1(control_1);
			if (gClass == null)
			{
				return false;
			}
			if (!gClass.method_3())
			{
				return false;
			}
			if (control_1 == null || control_1.IsDisposed || !control_1.IsHandleCreated)
			{
				return false;
			}
			gClass.method_17(paintEventArgs_0);
			return true;
		}

		public void Paint()
		{
			if (thread_0 == null)
			{
				method_16();
			}
		}

		private void method_16()
		{
			if (!bool_2 && control_0 != null && !control_0.IsDisposed && control_0.IsHandleCreated && method_3())
			{
				using (Graphics graphics = control_0.CreateGraphics())
				{
					PaintEventArgs paintEventArgs_ = new PaintEventArgs(graphics, control_0.ClientRectangle);
					method_17(paintEventArgs_);
					graphics.Flush();
				}
			}
		}

		public void method_17(PaintEventArgs paintEventArgs_0)
		{
			if (!bool_2 && control_0 != null && control_0.IsHandleCreated && !control_0.IsDisposed && control_0.Visible && method_3() && Monitor.TryEnter(this))
			{
				try
				{
					if (size_0.IsEmpty)
					{
						size_0 = control_0.ClientSize;
					}
					if (int_4 == 0)
					{
						int_4++;
						if (bitmap_0 == null)
						{
							method_0();
							if (!rectangle_0.IsEmpty)
							{
								bitmap_0 = new Bitmap(rectangle_0.Width, rectangle_0.Height);
								using (Graphics graphics = Graphics.FromImage(bitmap_0))
								{
									graphics.CopyFromScreen(rectangle_0.Location, new Point(0, 0), rectangle_0.Size);
								}
							}
						}
						if (bitmap_0 != null)
						{
							paintEventArgs_0.Graphics.DrawImage(bitmap_0, 0, 0);
							using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, Color.Gray)))
							{
								paintEventArgs_0.Graphics.FillRectangle(brush, paintEventArgs_0.ClipRectangle);
							}
						}
						else
						{
							SolidBrush brush2 = GClass438.smethod_0(control_0.BackColor);
							paintEventArgs_0.Graphics.FillRectangle(brush2, paintEventArgs_0.ClipRectangle);
						}
					}
					Rectangle rectangle = new Rectangle(0, 0, Math.Min(400, size_0.Width - 10), Math.Min(100, size_0.Height - 10));
					rectangle.X = (size_0.Width - rectangle.Width) / 2;
					rectangle.Y = (size_0.Height - rectangle.Height) / 2;
					if (rectangle.X < 0)
					{
						rectangle.X = 0;
					}
					if (rectangle.Y < 0)
					{
						rectangle.Height = 0;
					}
					if (!Rectangle.Intersect(paintEventArgs_0.ClipRectangle, rectangle).IsEmpty)
					{
						GraphicsPath graphicsPath = ShapeDrawer.CreateRoundRectanglePath(rectangle, 10);
						try
						{
							using (SolidBrush brush = new SolidBrush(smethod_4()))
							{
								paintEventArgs_0.Graphics.FillPath(brush, graphicsPath);
							}
						}
						catch (Exception ex)
						{
							Debug.WriteLine(ex.Message);
						}
						RectangleF layoutRectangle = new RectangleF(rectangle.Left + 4, rectangle.Top, rectangle.Width - 6, rectangle.Height);
						Image image = method_9();
						if (image == null)
						{
							image = smethod_2();
						}
						if (image != null && smethod_6() > 0)
						{
							try
							{
								paintEventArgs_0.Graphics.DrawImage(image, new Rectangle((int)layoutRectangle.Left + 1, rectangle.Top + (rectangle.Height - smethod_6()) / 2, smethod_6(), smethod_6()));
								layoutRectangle.X += smethod_6() + 5;
								layoutRectangle.Width -= smethod_6() + 5;
							}
							catch (Exception)
							{
							}
						}
						if (!string.IsNullOrEmpty(method_7()))
						{
							using (StringFormat stringFormat = new StringFormat())
							{
								stringFormat.Alignment = StringAlignment.Near;
								stringFormat.LineAlignment = StringAlignment.Center;
								if (control_0.RightToLeft == RightToLeft.Yes)
								{
									stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
								}
								using (SolidBrush brush = new SolidBrush(Color.FromArgb(89, 87, 87)))
								{
									paintEventArgs_0.Graphics.DrawString(method_7(), (method_11() == null) ? control_0.Font : method_11().Value, brush, layoutRectangle, stringFormat);
								}
							}
						}
						paintEventArgs_0.Graphics.DrawPath(Pens.Black, graphicsPath);
						graphicsPath.Dispose();
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
				finally
				{
					Monitor.Exit(this);
				}
			}
		}
	}
}
