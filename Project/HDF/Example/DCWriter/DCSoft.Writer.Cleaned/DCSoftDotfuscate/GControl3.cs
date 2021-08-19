using DCSoft.WinForms.Native;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[ToolboxItem(false)]
	public class GControl3 : UserControl
	{
		private class Class176
		{
			public int int_0 = 0;

			public int int_1 = 0;
		}

		private GEnum30 genum30_0 = GEnum30.const_1;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private Image image_0 = null;

		private EventHandler eventHandler_0 = null;

		private Class176 class176_0 = null;

		private Class176 class176_1 = null;

		public GControl3()
		{
			SetStyle(ControlStyles.Selectable, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			AutoScroll = true;
			BackColor = Color.Black;
		}

		public GEnum30 method_0()
		{
			return genum30_0;
		}

		public void method_1(GEnum30 genum30_1)
		{
			genum30_0 = genum30_1;
			if (genum30_0 == GEnum30.const_0 || genum30_0 == GEnum30.const_2)
			{
				Cursor = Cursors.Default;
			}
			else
			{
				Cursor = Cursors.SizeAll;
			}
		}

		public Bitmap method_2()
		{
			if (method_5() == null)
			{
				return null;
			}
			if (!rectangle_0.IsEmpty)
			{
				rectangle_0 = Rectangle.Intersect(rectangle_0, new Rectangle(0, 0, method_5().Width, method_5().Height));
				if (!rectangle_0.IsEmpty)
				{
					Bitmap bitmap = new Bitmap(rectangle_0.Width, rectangle_0.Height);
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.DrawImage(method_5(), -rectangle_0.X, -rectangle_0.Y);
					}
					return bitmap;
				}
			}
			return null;
		}

		public Rectangle method_3()
		{
			return rectangle_0;
		}

		public void method_4(Rectangle rectangle_1)
		{
			rectangle_0 = rectangle_1;
		}

		public Image method_5()
		{
			return image_0;
		}

		public void method_6(Image image_1)
		{
			image_0 = image_1;
			method_14();
		}

		public bool method_7(Stream stream_0)
		{
			image_0 = Image.FromStream(stream_0);
			method_14();
			return image_0 != null;
		}

		public bool method_8(byte[] byte_0)
		{
			using (MemoryStream stream_ = new MemoryStream(byte_0))
			{
				return method_7(stream_);
			}
		}

		public bool method_9(string string_0)
		{
			image_0 = Image.FromFile(string_0);
			method_14();
			return image_0 != null;
		}

		public bool method_10(string string_0)
		{
			int num = 6;
			if (image_0 == null)
			{
				return false;
			}
			string extension = Path.GetExtension(string_0);
			extension = ((extension == null) ? ".bmp" : extension.Trim().ToLower());
			image_0.Save(string_0, method_13(extension));
			return true;
		}

		public bool method_11()
		{
			if (image_0 == null)
			{
				return false;
			}
			DataObject dataObject = new DataObject();
			Bitmap bitmap = method_2();
			if (bitmap == null)
			{
				bitmap = new Bitmap(image_0);
			}
			dataObject.SetData(DataFormats.Bitmap, bitmap);
			Clipboard.SetDataObject(dataObject);
			return true;
		}

		public bool method_12()
		{
			IDataObject dataObject = Clipboard.GetDataObject();
			if (dataObject.GetDataPresent(DataFormats.Bitmap))
			{
				Image image = (Image)dataObject.GetData(DataFormats.Bitmap);
				if (image != null)
				{
					image_0 = image;
					rectangle_0 = Rectangle.Empty;
					method_14();
					return true;
				}
			}
			return false;
		}

		private ImageFormat method_13(string string_0)
		{
			int num = 18;
			ImageFormat imageFormat = null;
			switch (string_0)
			{
			case ".png":
				return ImageFormat.Png;
			case ".jpg":
				return ImageFormat.Jpeg;
			case ".jpeg":
				return ImageFormat.Jpeg;
			case ".emf":
				return ImageFormat.Emf;
			case ".gif":
				return ImageFormat.Gif;
			case ".tiff":
				return ImageFormat.Tiff;
			default:
				return ImageFormat.Bmp;
			}
		}

		protected void method_14()
		{
			if (image_0 == null)
			{
				base.AutoScrollMinSize = new Size(0, 0);
			}
			else
			{
				base.AutoScrollMinSize = image_0.Size;
			}
			Invalidate();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, null);
			}
		}

		public void method_15(EventHandler eventHandler_1)
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

		public void method_16(EventHandler eventHandler_1)
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

		public Rectangle method_17()
		{
			if (image_0 != null)
			{
				Rectangle result = new Rectangle(0, 0, image_0.Size.Width, image_0.Size.Height);
				Size clientSize = base.ClientSize;
				if (clientSize.Width > result.Width)
				{
					result.X = (clientSize.Width - result.Width) / 2;
				}
				if (clientSize.Height > result.Height)
				{
					result.Y = (clientSize.Height - result.Height) / 2;
				}
				return result;
			}
			return Rectangle.Empty;
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			if (image_0 != null)
			{
				Point autoScrollPosition = base.AutoScrollPosition;
				Rectangle b = method_17();
				Point location = b.Location;
				Rectangle clipRectangle = pevent.ClipRectangle;
				clipRectangle.Offset(-autoScrollPosition.X, -autoScrollPosition.Y);
				b = Rectangle.Intersect(clipRectangle, b);
				if (b.Width > 0 || b.Height > 0)
				{
					pevent.Graphics.DrawImage(image_0, new Rectangle(b.Left + autoScrollPosition.X, b.Top + autoScrollPosition.Y, b.Width, b.Height), new Rectangle(b.Left - location.X, b.Top - location.Y, b.Width, b.Height), GraphicsUnit.Pixel);
				}
			}
			if (method_0() == GEnum30.const_2)
			{
				using (GClass249 gClass = new GClass249(pevent.Graphics))
				{
					gClass.method_23(Color.White);
					gClass.method_21(GEnum64.const_0);
					gClass.method_8(1);
					Rectangle rectangle = method_3();
					if (!rectangle.IsEmpty)
					{
						rectangle.Offset(base.AutoScrollPosition.X, base.AutoScrollPosition.Y);
						rectangle.Offset(method_17().Location);
						gClass.DrawRectangle(rectangle);
					}
					if (class176_1 != null)
					{
						gClass.method_11(0, class176_1.int_1, base.ClientSize.Width, class176_1.int_1);
						gClass.method_11(class176_1.int_0, 0, class176_1.int_0, base.ClientSize.Height);
						class176_1 = null;
					}
				}
			}
			base.OnPaint(pevent);
		}

		private GClass249 method_18()
		{
			GClass249 gClass = GClass249.smethod_0(base.Handle);
			gClass.method_23(Color.White);
			gClass.method_21(GEnum64.const_0);
			gClass.method_8(1);
			return gClass;
		}

		private Rectangle method_19(Point point_0, Point point_1)
		{
			Rectangle empty = Rectangle.Empty;
			empty.X = Math.Min(point_0.X, point_1.X);
			empty.Y = Math.Min(point_0.Y, point_1.Y);
			empty.Width = Math.Max(point_0.X, point_1.X) - empty.Left;
			empty.Height = Math.Max(point_0.Y, point_1.Y) - empty.Top;
			return empty;
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			class176_1 = null;
			if (method_0() == GEnum30.const_1)
			{
				if (method_17().Contains(mevent.X - base.AutoScrollPosition.X, mevent.Y - base.AutoScrollPosition.Y))
				{
					class176_0 = new Class176();
					class176_0.int_0 = mevent.X;
					class176_0.int_1 = mevent.Y;
				}
			}
			else if (method_0() == GEnum30.const_2 && mevent.Button == MouseButtons.Left)
			{
				MouseCapturer mouseCapturer = new MouseCapturer(this);
				mouseCapturer.ReversibleShape = GEnum68.const_1;
				Cursor = Cursors.Cross;
				base.Capture = true;
				Refresh();
				if (mouseCapturer.method_1())
				{
					rectangle_0 = method_19(mouseCapturer.StartPosition, mouseCapturer.EndPosition);
					rectangle_0.Offset(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y);
					Point location = method_17().Location;
					rectangle_0.Offset(-location.X, -location.Y);
					class176_1 = null;
					Refresh();
				}
				Cursor = Cursors.Default;
				base.Capture = false;
			}
			base.OnMouseDown(mevent);
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			if (method_0() == GEnum30.const_1)
			{
				if (class176_0 != null)
				{
					Point autoScrollPosition = new Point(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y);
					autoScrollPosition.Offset(-mevent.X + class176_0.int_0, -mevent.Y + class176_0.int_1);
					class176_0.int_0 = mevent.X;
					class176_0.int_1 = mevent.Y;
					base.AutoScrollPosition = autoScrollPosition;
				}
				else if (image_0 != null)
				{
					int x = mevent.X - base.AutoScrollPosition.X;
					int y = mevent.Y - base.AutoScrollPosition.Y;
					if (image_0.Size.Width > base.ClientSize.Width || image_0.Size.Height > base.ClientSize.Height)
					{
						if (method_17().Contains(x, y))
						{
							Cursor = Cursors.SizeAll;
						}
						else
						{
							Cursor = Cursors.Default;
						}
					}
					else
					{
						Cursor = Cursors.Default;
					}
				}
			}
			else if (method_0() == GEnum30.const_2)
			{
				using (GClass249 gClass = method_18())
				{
					if (class176_1 != null)
					{
						gClass.method_11(0, class176_1.int_1, base.ClientSize.Width, class176_1.int_1);
						gClass.method_11(class176_1.int_0, 0, class176_1.int_0, base.ClientSize.Height);
					}
					else
					{
						class176_1 = new Class176();
					}
					if (method_17().Contains(mevent.X, mevent.Y))
					{
						class176_1.int_0 = mevent.X;
						class176_1.int_1 = mevent.Y;
						gClass.method_11(0, class176_1.int_1, base.ClientSize.Width, class176_1.int_1);
						gClass.method_11(class176_1.int_0, 0, class176_1.int_0, base.ClientSize.Height);
					}
					else
					{
						class176_1 = null;
					}
				}
			}
			base.OnMouseMove(mevent);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			class176_1 = null;
			base.Capture = false;
			class176_0 = null;
			base.OnMouseUp(mevent);
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			if (class176_1 != null)
			{
				using (GClass249 gClass = method_18())
				{
					gClass.method_11(0, class176_1.int_1, base.ClientSize.Width, class176_1.int_1);
					gClass.method_11(class176_1.int_0, 0, class176_1.int_0, base.ClientSize.Height);
					class176_1 = null;
				}
			}
			base.OnMouseLeave(eventArgs_0);
		}
	}
}
