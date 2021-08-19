using DCSoft.WinForms.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[ToolboxBitmap(typeof(GClass304))]
	[ToolboxItem(false)]
	public class GClass304 : Button
	{
		private Color color_0 = Color.Black;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private Color color_1 = Color.Black;

		private DCMenuHelper dcmenuHelper_0;

		private EventHandler eventHandler_0 = null;

		public GClass304()
		{
			base.MouseEnter += GClass304_MouseEnter;
			base.MouseLeave += GClass304_MouseLeave;
			base.MouseUp += GClass304_MouseUp;
			base.Paint += GClass304_Paint;
		}

		public Color method_0()
		{
			return color_0;
		}

		public void method_1(Color color_2)
		{
			color_0 = color_2;
		}

		private void GClass304_MouseEnter(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void GClass304_MouseLeave(object sender, EventArgs e)
		{
			Invalidate();
		}

		private void GClass304_MouseUp(object sender, MouseEventArgs e)
		{
			Invalidate();
		}

		private void GClass304_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle clientRectangle = base.ClientRectangle;
			Rectangle rect = new Rectangle(clientRectangle.Left + 4, clientRectangle.Top + 4, clientRectangle.Width - 4 - 15 - 1, clientRectangle.Height - 8 - 1);
			using (SolidBrush brush = new SolidBrush(color_0))
			{
				graphics.FillRectangle(brush, rect);
			}
			using (Pen pen = new Pen(Color.Black))
			{
				graphics.DrawRectangle(pen, rect);
				Point pt = new Point(clientRectangle.Width - 9, clientRectangle.Height / 2 - 1);
				Point pt2 = new Point(clientRectangle.Width - 5, clientRectangle.Height / 2 - 1);
				graphics.DrawLine(pen, pt, pt2);
				pt = new Point(clientRectangle.Width - 8, clientRectangle.Height / 2);
				pt2 = new Point(clientRectangle.Width - 6, clientRectangle.Height / 2);
				graphics.DrawLine(pen, pt, pt2);
				pt = new Point(clientRectangle.Width - 7, clientRectangle.Height / 2);
				pt2 = new Point(clientRectangle.Width - 7, clientRectangle.Height / 2 + 1);
				graphics.DrawLine(pen, pt, pt2);
			}
			using (Pen pen = new Pen(SystemColors.ControlDark))
			{
				Point pt = new Point(clientRectangle.Width - 12, 4);
				Point pt2 = new Point(clientRectangle.Width - 12, clientRectangle.Height - 5);
				graphics.DrawLine(pen, pt, pt2);
			}
			using (Pen pen = new Pen(SystemColors.ControlLightLight))
			{
				Point pt = new Point(clientRectangle.Width - 11, 4);
				Point pt2 = new Point(clientRectangle.Width - 11, clientRectangle.Height - 5);
				graphics.DrawLine(pen, pt, pt2);
			}
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public Color method_6()
		{
			return color_1;
		}

		public void method_7(Color color_2)
		{
			color_1 = color_2;
			if (base.IsHandleCreated)
			{
				Invalidate();
			}
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			if (dcmenuHelper_0 == null)
			{
				dcmenuHelper_0 = new DCMenuHelper();
				dcmenuHelper_0.ColorPlate.method_5(method_4());
				dcmenuHelper_0.ColorPlate.method_7(method_6());
				dcmenuHelper_0.ColorPlate.method_3(method_2());
				dcmenuHelper_0.ColorPlate.method_12(method_8);
			}
			dcmenuHelper_0.ColorPlate.method_11(method_0());
			dcmenuHelper_0.method_2(this, new Rectangle(0, 0, base.Width, base.Height));
			base.OnClick(eventArgs_0);
		}

		private void method_8(object sender, EventArgs e)
		{
			method_1(dcmenuHelper_0.ColorPlate.method_10());
			Invalidate();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, EventArgs.Empty);
			}
		}

		public void method_9(EventHandler eventHandler_1)
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

		public void method_10(EventHandler eventHandler_1)
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
	}
}
