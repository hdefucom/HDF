using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GForm0 : Form, IMessageFilter
	{
		private long long_0 = 0L;

		private long long_1 = 0L;

		private bool bool_0 = true;

		private bool bool_1 = false;

		private Control control_0 = null;

		private bool bool_2 = true;

		private bool bool_3 = false;

		private Control control_1 = null;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private Message message_0 = default(Message);

		protected override CreateParams CreateParams
		{
			get
			{
				SetStyle(ControlStyles.Selectable, method_7());
				return base.CreateParams;
			}
		}

		public GForm0()
		{
			base.TopMost = true;
			base.ShowInTaskbar = false;
			base.ControlBox = false;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.StartPosition = FormStartPosition.Manual;
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.Leave += GForm0_Deactivate;
			base.Deactivate += GForm0_Deactivate;
			base.OnLoad(eventArgs_0);
		}

		protected override void OnClosing(CancelEventArgs cancelEventArgs_0)
		{
			base.OnClosing(cancelEventArgs_0);
		}

		public long method_0()
		{
			return long_0;
		}

		public void method_1(long long_2)
		{
			long_0 = long_2;
		}

		public long method_2()
		{
			return long_1;
		}

		public void method_3(long long_2)
		{
			long_1 = long_2;
		}

		private bool method_4()
		{
			if (long_1 > 0L && Environment.TickCount - long_0 < long_1)
			{
				return false;
			}
			return true;
		}

		private void GForm0_Deactivate(object sender, EventArgs e)
		{
			if (method_4() && method_7())
			{
				Hide();
				if (base.Owner != null)
				{
					base.Owner.Activate();
				}
				else if (method_14() != null)
				{
					method_14().Focus();
				}
			}
		}

		protected override void OnVisibleChanged(EventArgs eventArgs_0)
		{
			base.OnVisibleChanged(eventArgs_0);
			if (!base.Visible)
			{
			}
		}

		public bool method_5()
		{
			return bool_0;
		}

		public void method_6(bool bool_4)
		{
			bool_0 = bool_4;
		}

		public bool method_7()
		{
			return bool_1;
		}

		public void method_8(bool bool_4)
		{
			bool_1 = bool_4;
		}

		public Control method_9()
		{
			return control_0;
		}

		public void method_10(Control control_2)
		{
			control_0 = control_2;
		}

		public Control method_11()
		{
			if (control_0 == null)
			{
				if (base.Controls.Count > 0)
				{
					return base.Controls[0];
				}
				return null;
			}
			return control_0;
		}

		public bool method_12()
		{
			return !bool_2;
		}

		public void method_13(bool bool_4)
		{
			bool_2 = !bool_4;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		public Control method_14()
		{
			return control_1;
		}

		public void method_15(Control control_2)
		{
			control_1 = control_2;
		}

		public Rectangle method_16()
		{
			return rectangle_0;
		}

		public void method_17(Rectangle rectangle_1)
		{
			rectangle_0 = rectangle_1;
		}

		public void method_18()
		{
			Rectangle rectangle = method_16();
			if (!rectangle_0.IsEmpty)
			{
				if (method_14() != null)
				{
					rectangle.Location = method_14().PointToScreen(rectangle.Location);
				}
				Point point2 = base.Location = method_19(rectangle.Left, rectangle.Top, rectangle.Height);
			}
		}

		public Point method_19(int int_0, int int_1, int int_2)
		{
			Screen screen = Screen.FromPoint(new Point(int_0, int_1));
			if (screen == null)
			{
				screen = Screen.PrimaryScreen;
			}
			Rectangle workingArea = screen.WorkingArea;
			if (control_1 != null)
			{
				workingArea = Screen.GetWorkingArea(new Point(int_0, int_1));
			}
			Point result = new Point(int_0, int_1 + int_2);
			int num = int_1 - workingArea.Top;
			int num2 = workingArea.Bottom - int_1 - int_2;
			if ((double)num > (double)num2 * 1.3)
			{
				result.Y = int_1 - base.Height;
			}
			if (result.X < workingArea.Left)
			{
				result.X = workingArea.Left;
			}
			if (result.Y < workingArea.Top)
			{
				result.Y = workingArea.Top;
			}
			if (int_1 + int_2 + base.Height > workingArea.Bottom)
			{
				result.Y = int_1 - base.Height;
			}
			if (int_0 + base.Width > workingArea.Right)
			{
				result.X = workingArea.Right - base.Width;
			}
			return result;
		}

		public void method_20(Control control_2, int int_0, int int_1, int int_2)
		{
			method_15(control_2);
			method_17(new Rectangle(int_0, int_1, 0, int_2));
			method_18();
			Show();
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			if (base.Visible)
			{
				method_18();
			}
		}

		public int method_21(int int_0, int int_1, Form form_0)
		{
			base.Location = new Point(int_0, int_1);
			Show();
			form_0?.Activate();
			return 0;
		}

		public virtual void vmethod_0()
		{
			bool_3 = false;
			GClass253.smethod_0().method_1(bool_1: true);
			GClass245.smethod_1();
			GClass253.smethod_0().method_1(bool_1: false);
			new GClass244(this);
			Application.AddMessageFilter(this);
			bool_2 = false;
			while (base.Visible && !bool_2)
			{
				Application.DoEvents();
				GClass262.MsgWaitForMultipleObjectsEx(0, IntPtr.Zero, 250, 255, 4);
			}
			Application.RemoveMessageFilter(this);
			if (base.Visible && method_4() && method_5())
			{
				Hide();
				if (base.Owner != null)
				{
					base.Owner.Activate();
				}
			}
			if (message_0.HWnd != IntPtr.Zero)
			{
				GClass262.PostMessage(message_0.HWnd, message_0.Msg, (uint)(int)message_0.WParam, (uint)(int)message_0.LParam);
				message_0.HWnd = IntPtr.Zero;
			}
		}

		public void method_22(bool bool_4)
		{
			if (!base.Visible)
			{
				return;
			}
			if (!bool_4)
			{
				if (!method_4())
				{
					return;
				}
			}
			else
			{
				long_1 = 0L;
			}
			bool_2 = true;
			base.Visible = false;
			if (base.Owner != null)
			{
			}
		}

		protected override void WndProc(ref Message message_1)
		{
			switch (message_1.Msg)
			{
			default:
				base.WndProc(ref message_1);
				break;
			case 33:
				if (!method_7())
				{
					message_1.Result = (IntPtr)3L;
				}
				break;
			case 28:
				method_22(bool_4: true);
				break;
			}
		}

		public virtual bool PreFilterMessage(ref Message message_1)
		{
			bool result = false;
			if (base.IsDisposed || base.Disposing || !base.Visible)
			{
				return false;
			}
			GClass245 gClass = new GClass245(message_1);
			Rectangle bounds = base.Bounds;
			if (gClass.method_14())
			{
				if (gClass.method_2() == 513 || gClass.method_2() == 519 || gClass.method_2() == 516 || gClass.method_2() == 523)
				{
					Point pt = gClass.method_18();
					bool_2 = !bounds.Contains(pt);
					message_0 = message_1;
					result = bool_2;
					if (bool_2)
					{
						if (method_23(message_1.HWnd))
						{
							bool_2 = false;
						}
						GClass244 gClass2 = new GClass244(base.Handle);
						if (!gClass2.method_10())
						{
							bool_2 = false;
						}
						return true;
					}
				}
				if (message_1.Msg == 161 || message_1.Msg == 167 || message_1.Msg == 164 || message_1.Msg == 171)
				{
					Point pt = gClass.method_19();
					bool_2 = !bounds.Contains(pt);
					message_0 = message_1;
					result = bool_2;
					if (bool_2)
					{
						if (method_23(message_1.HWnd))
						{
							bool_2 = false;
						}
						GClass244 gClass2 = new GClass244(base.Handle);
						if (!gClass2.method_10())
						{
							bool_2 = false;
						}
						return true;
					}
				}
			}
			if (method_11() is IMessageFilter)
			{
				GClass244 gClass2 = new GClass244(base.Handle);
				IMessageFilter messageFilter = (IMessageFilter)method_11();
				bool result2;
				if (result2 = messageFilter.PreFilterMessage(ref message_1))
				{
					return result2;
				}
				if (message_1.Msg == 256 && message_1.WParam.ToInt32() == 27)
				{
					bool_2 = true;
					bool_3 = false;
					return true;
				}
			}
			return result;
		}

		[DllImport("user32.dll")]
		private static extern bool IsChild(IntPtr intptr_0, IntPtr intptr_1);

		private bool method_23(IntPtr intptr_0)
		{
			if (IsChild(base.Handle, intptr_0))
			{
				return true;
			}
			Form[] ownedForms = base.OwnedForms;
			if (ownedForms != null && ownedForms.Length > 0)
			{
				Form[] array = ownedForms;
				foreach (Form form in array)
				{
					if (form.Handle == intptr_0)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
