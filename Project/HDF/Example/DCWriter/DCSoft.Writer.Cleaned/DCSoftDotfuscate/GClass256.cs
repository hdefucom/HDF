using DCSoft.WinForms.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class GClass256 : ComboBox
	{
		private const int int_0 = 1024;

		private const int int_1 = 8192;

		private const int int_2 = 273;

		private const int int_3 = 7;

		private IContainer icontainer_0 = null;

		private DCMenuHelper dcmenuHelper_0;

		private EventHandler eventHandler_0;

		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			icontainer_0 = new Container();
		}

		public void method_1(EventHandler eventHandler_1)
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

		public void method_2(EventHandler eventHandler_1)
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

		public Color method_3()
		{
			return dcmenuHelper_0.ColorPlate.method_10();
		}

		public void method_4(Color color_0)
		{
			dcmenuHelper_0.ColorPlate.method_11(color_0);
		}

		public GClass256()
		{
			method_0();
			method_5();
		}

		public GClass256(IContainer icontainer_1)
		{
			icontainer_1.Add(this);
			method_0();
			method_5();
		}

		private void method_5()
		{
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			base.Items.Add("Color");
			SelectedIndex = 0;
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			dcmenuHelper_0 = new DCMenuHelper();
			dcmenuHelper_0.ColorPlate.method_12(method_6);
		}

		private void method_6(object sender, EventArgs e)
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}

		private void method_7()
		{
			if (dcmenuHelper_0 != null)
			{
				dcmenuHelper_0.method_3(this, new Point(0, base.Height));
			}
		}

		protected override void OnBindingContextChanged(EventArgs eventArgs_0)
		{
			int num = 7;
			base.OnBindingContextChanged(eventArgs_0);
			if (base.Items.Count != 1)
			{
				base.Items.Clear();
				base.Items.Add("Color");
				SelectedIndex = 0;
			}
		}

		protected override void OnDrawItem(DrawItemEventArgs args)
		{
			if (args.Index > -1)
			{
				args.Graphics.FillRectangle(new SolidBrush(method_3()), args.Bounds);
				Rectangle rect = new Rectangle(args.Bounds.X, args.Bounds.Y, args.Bounds.Width - 1, args.Bounds.Height - 1);
				if ((args.State & DrawItemState.Focus) == 0)
				{
					using (Pen pen = new Pen(Color.LightGray))
					{
						args.Graphics.DrawRectangle(pen, rect);
					}
					return;
				}
				using (Pen pen2 = new Pen(Color.LightGray, 1f))
				{
					args.Graphics.DrawRectangle(pen2, rect);
				}
				Pen pen3 = new Pen(Color.Gray, 1f);
				pen3.DashStyle = DashStyle.Dot;
				args.Graphics.DrawRectangle(pen3, rect);
				pen3.Dispose();
			}
		}

		protected override void WndProc(ref Message message_0)
		{
			if (message_0.Msg == 8465 && smethod_0((int)message_0.WParam) == 7)
			{
				method_7();
			}
			else
			{
				base.WndProc(ref message_0);
			}
		}

		public static int smethod_0(int int_4)
		{
			return (int_4 >> 16) & 0xFFFF;
		}
	}
}
