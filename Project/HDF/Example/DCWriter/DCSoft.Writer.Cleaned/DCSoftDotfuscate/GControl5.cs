using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	[ToolboxBitmap(typeof(GControl5))]
	public class GControl5 : ContainerControl, IMessageFilter
	{
		public delegate float GDelegate14(string string_0, XFontValue xfontValue_0, Graphics graphics_0);

		public const int int_0 = 8;

		private static Image image_0 = WinFormsResources.CheckBoxChecked;

		private static Image image_1 = WinFormsResources.CheckBoxUnChecked;

		private bool bool_0;

		private bool bool_1;

		private char char_0;

		private List<float> list_0;

		private float float_0;

		private GClass289 gclass289_0;

		private Panel panel_0;

		private Label label_0;

		private Label label_1;

		private int int_1;

		private int int_2;

		private int int_3;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private bool bool_5;

		private GDelegate15 gdelegate15_0;

		private EventHandler eventHandler_0;

		private EventHandler eventHandler_1;

		private EventHandler eventHandler_2;

		private EventHandler eventHandler_3;

		private bool bool_6;

		private int int_4;

		private int int_5;

		private string string_0;

		private string string_1;

		private ImageList imageList_0;

		private int int_6;

		private int int_7;

		private bool bool_7;

		private int int_8;

		private bool bool_8;

		private GDelegate16 gdelegate16_0;

		private bool bool_9;

		private int int_9;

		private Size size_0;

		public GDelegate14 gdelegate14_0;

		private int int_10;

		private StringFormat stringFormat_0;

		private static int int_11 = 0;

		private Point point_0;

		private bool bool_10;

		private GClass290 gclass290_0;

		private bool bool_11;

		private bool bool_12;

		private bool bool_13;

		private CancelEventHandler cancelEventHandler_0;

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			base.OnFontChanged(eventArgs_0);
			int_8 = (int)Font.GetHeight() + 3;
			label_0.Font = Font;
		}

		public GControl5()
		{
			EventHandler eventHandler = null;
			EventHandler eventHandler2 = null;
			bool_0 = false;
			bool_1 = false;
			char_0 = ',';
			list_0 = null;
			float_0 = 0f;
			gclass289_0 = new GClass289();
			panel_0 = null;
			label_0 = null;
			label_1 = null;
			int_1 = 0;
			int_2 = 0;
			int_3 = 0;
			bool_2 = false;
			bool_3 = false;
			bool_4 = false;
			bool_5 = false;
			gdelegate15_0 = null;
			eventHandler_0 = null;
			eventHandler_1 = null;
			eventHandler_2 = null;
			eventHandler_3 = null;
			bool_6 = true;
			int_4 = 9;
			int_5 = 15;
			string_0 = null;
			string_1 = ",";
			imageList_0 = null;
			int_6 = 8;
			int_7 = 8;
			bool_7 = true;
			int_8 = 0;
			bool_8 = false;
			gdelegate16_0 = null;
			bool_9 = false;
			int_9 = -1;
			size_0 = Size.Empty;
			gdelegate14_0 = null;
			int_10 = 0;
			stringFormat_0 = null;
			point_0 = new Point(-100, -100);
			bool_10 = true;
			gclass290_0 = null;
			bool_11 = true;
			bool_12 = false;
			bool_13 = false;
			cancelEventHandler_0 = null;
			
			BackColor = SystemColors.Window;
			int_8 = (int)Font.GetHeight() + 3;
			panel_0 = new Panel();
			panel_0.BorderStyle = BorderStyle.Fixed3D;
			panel_0.AutoScroll = true;
			panel_0.Dock = DockStyle.Fill;
			panel_0.Visible = true;
			panel_0.Font = Font;
			panel_0.Paint += panel_0_Paint;
			panel_0.MouseMove += panel_0_MouseMove;
			panel_0.MouseDown += panel_0_MouseDown;
			panel_0.MouseUp += panel_0_MouseUp;
			panel_0.MouseLeave += panel_0_MouseLeave;
			panel_0.DoubleClick += panel_0_DoubleClick;
			base.Controls.Add(panel_0);
			label_0 = new Label();
			label_0.Dock = DockStyle.Top;
			label_0.BorderStyle = BorderStyle.Fixed3D;
			label_0.BackColor = SystemColors.Control;
			label_0.TextAlign = ContentAlignment.MiddleLeft;
			label_0.Font = new Font("宋体", 10f);
			label_1 = new Label();
			label_1.Size = new Size(16, 14);
			label_1.Visible = false;
			label_1.Font = new Font("Arial", 9f);
			label_1.BorderStyle = BorderStyle.FixedSingle;
			label_1.BackColor = Color.Gainsboro;
			label_1.ForeColor = Color.Black;
			label_1.Text = "...";
			Label label = label_1;
			eventHandler = delegate
			{
				label_1.BackColor = Color.WhiteSmoke;
			};
			label.MouseEnter += eventHandler;
			Label label2 = label_1;
			eventHandler2 = delegate
			{
				label_1.BackColor = Color.Gainsboro;
			};
			label2.MouseLeave += eventHandler2;
			label_1.Click += label_1_Click;
			panel_0.Controls.Add(label_1);
			base.Controls.Add(label_0);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_14)
		{
			bool_0 = bool_14;
		}

		public bool method_2()
		{
			return bool_1;
		}

		public void method_3(bool bool_14)
		{
			bool_1 = bool_14;
		}

		public char method_4()
		{
			return char_0;
		}

		public void method_5(char char_1)
		{
			char_0 = char_1;
		}

		public string method_6()
		{
			return label_0.Text;
		}

		public void method_7(string string_2)
		{
			label_0.Text = string_2;
			label_0.Refresh();
		}

		public GClass289 method_8()
		{
			return gclass289_0;
		}

		public void method_9(GClass289 gclass289_1)
		{
			if (gclass289_1 != gclass289_0)
			{
				gclass289_0 = gclass289_1;
				if (gclass289_0 == null)
				{
					gclass289_0 = new GClass289();
				}
				method_97();
				method_98();
			}
		}

		public bool method_10()
		{
			return bool_2;
		}

		public void method_11(bool bool_14)
		{
			bool_2 = bool_14;
		}

		public bool method_12()
		{
			return bool_3;
		}

		public void method_13(bool bool_14)
		{
			bool_3 = bool_14;
		}

		public bool method_14()
		{
			return bool_4;
		}

		public void method_15(bool bool_14)
		{
			bool_4 = bool_14;
		}

		public bool method_16()
		{
			return bool_5;
		}

		private void label_1_Click(object sender, EventArgs e)
		{
			GClass290 gclass290_ = (GClass290)label_1.Tag;
			GEventArgs8 gEventArgs = new GEventArgs8();
			gEventArgs.method_1(gclass290_);
			try
			{
				bool_5 = true;
				vmethod_0(gEventArgs);
			}
			finally
			{
				bool_5 = false;
			}
		}

		public void method_17(GDelegate15 gdelegate15_1)
		{
			GDelegate15 gDelegate = gdelegate15_0;
			GDelegate15 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate15 value = (GDelegate15)Delegate.Combine(gDelegate2, gdelegate15_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate15_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_18(GDelegate15 gdelegate15_1)
		{
			GDelegate15 gDelegate = gdelegate15_0;
			GDelegate15 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate15 value = (GDelegate15)Delegate.Remove(gDelegate2, gdelegate15_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate15_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		protected virtual void vmethod_0(GEventArgs8 geventArgs8_0)
		{
			try
			{
				bool_5 = true;
				if (gdelegate15_0 != null)
				{
					gdelegate15_0(this, geventArgs8_0);
					Invalidate();
				}
			}
			finally
			{
				bool_5 = false;
			}
		}

		public void method_19(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_20(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		protected virtual void vmethod_1(EventArgs eventArgs_0)
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, eventArgs_0);
			}
		}

		public void method_21(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_22(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		protected virtual void vmethod_2(EventArgs eventArgs_0)
		{
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, eventArgs_0);
			}
		}

		public void method_23(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_24(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		protected virtual void vmethod_3(EventArgs eventArgs_0)
		{
			if (eventHandler_2 != null)
			{
				eventHandler_2(this, eventArgs_0);
			}
		}

		public void method_25(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		public void method_26(EventHandler eventHandler_4)
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_4);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}

		protected virtual void vmethod_4(EventArgs eventArgs_0)
		{
			if (eventHandler_3 != null)
			{
				eventHandler_3(this, eventArgs_0);
			}
		}

		public bool method_27()
		{
			return bool_6;
		}

		public void method_28(bool bool_14)
		{
			bool_6 = bool_14;
		}

		public int method_29()
		{
			return int_4;
		}

		public void method_30(int int_12)
		{
			int_4 = int_12;
		}

		public int method_31()
		{
			return int_5;
		}

		public void method_32(int int_12)
		{
			int_5 = int_12;
		}

		public string method_33()
		{
			return string_0;
		}

		public void method_34(string string_2)
		{
			if (string_2 != null && string_0 != string_2)
			{
				string_0 = string_2;
				label_0.Text = string_0;
			}
		}

		public string method_35()
		{
			return string_1;
		}

		public void method_36(string string_2)
		{
			string_1 = string_2;
		}

		public ImageList method_37()
		{
			return imageList_0;
		}

		public void method_38(ImageList imageList_1)
		{
			imageList_0 = imageList_1;
		}

		public int method_39()
		{
			return int_6;
		}

		public void method_40(int int_12)
		{
			int_6 = int_12;
		}

		public int method_41()
		{
			return int_7;
		}

		public void method_42(int int_12)
		{
			int_7 = int_12;
		}

		public bool method_43()
		{
			return bool_7;
		}

		public void method_44(bool bool_14)
		{
			bool_7 = bool_14;
		}

		public int method_45()
		{
			return int_8;
		}

		public void method_46(int int_12)
		{
			int_8 = int_12;
		}

		private int method_47(GClass290 gclass290_1)
		{
			if (gclass290_1.method_45() > 0)
			{
				return gclass290_1.method_45();
			}
			int num = method_45();
			if (num <= 0)
			{
				num = (int)Math.Ceiling(Font.GetHeight() + 3f);
			}
			return num;
		}

		public virtual string vmethod_5(GClass290 gclass290_1)
		{
			return gclass290_1.method_2();
		}

		public virtual bool vmethod_6()
		{
			return bool_8;
		}

		public virtual void vmethod_7(bool bool_14)
		{
			bool_8 = bool_14;
			if (base.Visible)
			{
				Invalidate();
			}
		}

		public void method_48(GDelegate16 gdelegate16_1)
		{
			GDelegate16 gDelegate = gdelegate16_0;
			GDelegate16 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate16 value = (GDelegate16)Delegate.Combine(gDelegate2, gdelegate16_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate16_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		public void method_49(GDelegate16 gdelegate16_1)
		{
			GDelegate16 gDelegate = gdelegate16_0;
			GDelegate16 gDelegate2;
			do
			{
				gDelegate2 = gDelegate;
				GDelegate16 value = (GDelegate16)Delegate.Remove(gDelegate2, gdelegate16_1);
				gDelegate = Interlocked.CompareExchange(ref gdelegate16_0, value, gDelegate2);
			}
			while ((object)gDelegate != gDelegate2);
		}

		protected virtual void vmethod_8(GClass290 gclass290_1, List<GClass290> list_1)
		{
			if (gdelegate16_0 != null)
			{
				GEventArgs9 gEventArgs = new GEventArgs9(gclass290_1);
				gEventArgs.method_2(new List<GClass290>());
				gdelegate16_0(this, gEventArgs);
				if (gEventArgs.method_1() != null && gEventArgs.method_1().Count > 0)
				{
					list_1.AddRange(gEventArgs.method_1());
				}
			}
		}

		private bool method_50()
		{
			foreach (GClass290 item in method_8())
			{
				if (!char.IsWhiteSpace(item.method_37()))
				{
					return true;
				}
			}
			return false;
		}

		private bool method_51()
		{
			foreach (GClass290 item in method_8())
			{
				if (item.method_41())
				{
					return true;
				}
			}
			return false;
		}

		private bool method_52()
		{
			foreach (GClass290 item in method_8())
			{
				if (item.method_29() != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool method_53()
		{
			foreach (GClass290 item in method_8())
			{
				if (item.method_17())
				{
					return true;
				}
			}
			return false;
		}

		public void method_54()
		{
			if (!vmethod_6() || method_8().Count <= 14)
			{
				return;
			}
			GClass290[] array = method_74();
			if (array != null && array.Length > 1)
			{
				GClass290[] array2 = array;
				foreach (GClass290 item in array2)
				{
					method_8().Remove(item);
				}
				method_8().InsertRange(0, array);
				method_97();
				method_68(0);
				Refresh();
			}
		}

		public void method_55(bool bool_14)
		{
			if (bool_14)
			{
				foreach (GClass290 item in method_8())
				{
					item.method_32(StringConvertHelper.ToChineseSpell(item.method_2()));
				}
			}
			else
			{
				foreach (GClass290 item2 in method_8())
				{
					if (string.IsNullOrEmpty(item2.method_31()))
					{
						item2.method_32(StringConvertHelper.ToChineseSpell(item2.method_2()));
					}
				}
			}
		}

		public GClass290 method_56(string string_2, bool bool_14)
		{
			if (string_2 == null)
			{
				return null;
			}
			foreach (GClass290 item in method_8())
			{
				if (item.method_2() != null && item.method_0() == GEnum69.const_0)
				{
					if (item.method_2() == string_2)
					{
						return item;
					}
					if (bool_14 && item.method_2().StartsWith(string_2))
					{
						return item;
					}
				}
			}
			return null;
		}

		public GClass290 method_57(string string_2)
		{
			if (string.IsNullOrEmpty(string_2))
			{
				return null;
			}
			foreach (GClass290 item in method_8())
			{
				if (item.method_0() == GEnum69.const_0)
				{
					if (!string.IsNullOrEmpty(item.method_31()) && item.method_31().StartsWith(string_2))
					{
						return item;
					}
					if (!string.IsNullOrEmpty(item.method_33()) && item.method_33().StartsWith(string_2))
					{
						return item;
					}
					if (!string.IsNullOrEmpty(item.method_35()) && item.method_35().StartsWith(string_2))
					{
						return item;
					}
				}
			}
			return null;
		}

		public GClass290 method_58()
		{
			GClass290 gClass = method_59(null);
			gClass.method_1(GEnum69.const_1);
			return gClass;
		}

		public GClass290 method_59(string string_2)
		{
			GClass290 gClass = method_60(string_2);
			gClass.method_50(method_96().Height);
			method_8().Add(gClass);
			size_0.Height += method_47(gClass);
			if (!method_102())
			{
				method_98();
				panel_0.Invalidate();
			}
			return gClass;
		}

		public GClass290 method_60(string string_2)
		{
			GClass290 gClass = new GClass290();
			gClass.method_3(string_2);
			gClass.method_24(ForeColor);
			gClass.method_26(BackColor);
			return gClass;
		}

		public void method_61(string[] string_2)
		{
			int num = 18;
			if (string_2 == null)
			{
				throw new ArgumentNullException("strItems");
			}
			foreach (string string_3 in string_2)
			{
				GClass290 gClass = new GClass290();
				gClass.method_3(string_3);
				gClass.method_24(ForeColor);
				gClass.method_26(BackColor);
				gClass.method_50(method_96().Height);
				method_8().Add(gClass);
				size_0.Height += method_47(gClass);
			}
			if (!method_102())
			{
				method_98();
				panel_0.Invalidate();
			}
		}

		public void method_62(object[] object_0)
		{
			int num = 0;
			if (object_0 == null)
			{
				throw new ArgumentNullException("objItems");
			}
			foreach (object obj in object_0)
			{
				GClass290 gClass = new GClass290();
				gClass.method_24(ForeColor);
				gClass.method_26(BackColor);
				gClass.method_50(size_0.Height);
				if (obj == null)
				{
					gClass.method_3("<NULL>");
				}
				else
				{
					gClass.method_3(obj.ToString());
					gClass.method_28(obj);
				}
				method_8().Add(gClass);
				size_0.Height += method_47(gClass);
			}
			if (!method_102())
			{
				method_98();
				panel_0.Invalidate();
			}
		}

		public void method_63(GClass290 gclass290_1)
		{
			int num = 0;
			if (gclass290_1 == null)
			{
				throw new ArgumentNullException("item");
			}
			method_8().Remove(gclass290_1);
			method_97();
			if (int_9 >= method_8().Count)
			{
				int_9 = method_8().Count - 1;
				vmethod_1(EventArgs.Empty);
			}
			if (!method_102())
			{
				method_98();
				panel_0.Invalidate();
			}
		}

		public void method_64()
		{
			label_1.Visible = false;
			method_8().Clear();
			size_0 = Size.Empty;
			int_9 = -1;
			if (!method_102())
			{
				method_98();
				panel_0.Invalidate();
			}
		}

		public GClass290 method_65(int int_12, int int_13)
		{
			if (int_12 >= 0 && int_12 < panel_0.ClientSize.Width && int_13 >= 0 && int_13 <= panel_0.ClientSize.Height)
			{
				int_13 -= panel_0.AutoScrollPosition.Y;
				foreach (GClass290 item in method_8())
				{
					int num = method_47(item);
					if (int_13 <= item.method_49() + num && item.method_0() == GEnum69.const_0)
					{
						return item;
					}
				}
			}
			return null;
		}

		private void method_66(int int_12)
		{
			if (int_12 >= 0 && int_12 < method_8().Count)
			{
				int_9 = int_12;
				if (!vmethod_6())
				{
					foreach (GClass290 item in method_8())
					{
						item.method_18(bool_5: false);
					}
					GClass290 gClass = method_8()[int_9];
					gClass.method_18(bool_5: true);
				}
			}
		}

		public int method_67()
		{
			return int_9;
		}

		public void method_68(int int_12)
		{
			bool_9 = true;
			if (int_12 < 0 || int_12 >= method_8().Count)
			{
				int_9 = -1;
				if (!vmethod_6())
				{
					foreach (GClass290 item in method_8())
					{
						item.method_18(bool_5: false);
					}
				}
				panel_0.Invalidate();
			}
			else if (int_9 != int_12)
			{
				GClass290 gclass290_ = method_78();
				method_66(int_12);
				if (int_10 <= 0)
				{
					GClass290 current = method_8()[int_9];
					method_70(current);
					method_103(gclass290_);
					method_103(method_78());
				}
				method_13(bool_14: true);
				vmethod_1(EventArgs.Empty);
			}
			bool_9 = false;
		}

		public void method_69(GClass290 gclass290_1)
		{
			if (gclass290_1 != null)
			{
				int y = gclass290_1.method_49() - (panel_0.ClientSize.Height - method_47(gclass290_1)) / 2;
				panel_0.AutoScrollPosition = new Point(0, y);
			}
		}

		public void method_70(GClass290 gclass290_1)
		{
			int num = 6;
			if (gclass290_1 == null)
			{
				throw new ArgumentNullException("item");
			}
			if (int_10 <= 0)
			{
				Rectangle rectangle = method_105(gclass290_1);
				if (rectangle.Top < 0)
				{
					panel_0.AutoScrollPosition = new Point(0, rectangle.Top - panel_0.AutoScrollPosition.Y);
				}
				else if (rectangle.Bottom > panel_0.ClientSize.Height)
				{
					panel_0.AutoScrollPosition = new Point(0, rectangle.Bottom - panel_0.ClientSize.Height - panel_0.AutoScrollPosition.Y);
				}
			}
		}

		public void method_71(int int_12)
		{
			if (method_8() != null && int_12 >= 0 && int_12 < method_8().Count)
			{
				bool_9 = true;
				method_66(int_12);
				GClass290 gClass = method_8()[int_12];
				int num = method_47(gClass);
				panel_0.AutoScrollPosition = new Point(0, gClass.method_49() - (panel_0.ClientSize.Height - num) / 2);
				panel_0.Invalidate();
				method_13(bool_14: true);
				vmethod_1(EventArgs.Empty);
				bool_9 = false;
			}
		}

		public int[] method_72()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < method_8().Count; i++)
			{
				if (method_8()[i].method_17())
				{
					list.Add(i);
				}
			}
			return list.ToArray();
		}

		public void method_73(int[] int_12)
		{
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < method_8().Count; i++)
			{
				bool flag3 = false;
				if ((vmethod_6() || method_10() || !flag2) && int_12 != null && int_12.Length > 0)
				{
					for (int j = 0; j < int_12.Length; j++)
					{
						if (int_12[j] == i)
						{
							flag3 = true;
							flag2 = true;
							break;
						}
					}
				}
				if (method_10())
				{
					if (method_8()[i].method_15() != flag3)
					{
						method_8()[i].method_16(flag3);
						method_13(bool_14: true);
						flag = true;
					}
				}
				else if (method_8()[i].method_17() != flag3)
				{
					method_8()[i].method_18(flag3);
					method_13(bool_14: true);
					flag = true;
				}
			}
			if (flag)
			{
				vmethod_1(EventArgs.Empty);
			}
		}

		public GClass290[] method_74()
		{
			List<GClass290> list = new List<GClass290>();
			foreach (GClass290 item in method_8())
			{
				if (item.method_17())
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public void method_75(GClass290[] gclass290_1)
		{
			bool flag = false;
			foreach (GClass290 item in method_8())
			{
				item.method_18(bool_5: false);
				if (gclass290_1 != null)
				{
					foreach (GClass290 gClass in gclass290_1)
					{
						if (gClass == item)
						{
							item.method_18(bool_5: true);
							method_13(bool_14: true);
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				vmethod_1(EventArgs.Empty);
			}
		}

		public object[] method_76()
		{
			ArrayList arrayList = new ArrayList();
			foreach (GClass290 item in method_8())
			{
				if (item.method_17() && item.method_0() == GEnum69.const_0)
				{
					arrayList.Add(item.method_27());
				}
			}
			return arrayList.ToArray();
		}

		public object method_77()
		{
			if (method_78() != null)
			{
				return method_78().method_27();
			}
			return null;
		}

		public GClass290 method_78()
		{
			if (int_9 >= 0 && int_9 < method_8().Count)
			{
				return method_8()[int_9];
			}
			return null;
		}

		public void method_79(GClass290 gclass290_1)
		{
			method_68(method_8().IndexOf(gclass290_1));
		}

		public string method_80()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (GClass290 item in method_8())
			{
				if (item.method_15())
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(method_35());
					}
					if (item.method_5() != null)
					{
						stringBuilder.Append(Convert.ToString(item.method_5()));
					}
				}
			}
			return stringBuilder.ToString();
		}

		public void method_81(string string_2)
		{
			if (string_2 == null)
			{
				return;
			}
			GClass290 gClass = null;
			string[] array = StringConvertHelper.Split(string_2, method_35());
			if (array != null)
			{
				foreach (GClass290 item in method_8())
				{
					item.method_16(bool_5: false);
					string[] array2 = array;
					foreach (string b in array2)
					{
						if (item.method_5() != null)
						{
							string a = Convert.ToString(item.method_5());
							if (a == b)
							{
								method_13(bool_14: true);
								item.method_16(bool_5: true);
								if (gClass == null)
								{
									gClass = item;
								}
								break;
							}
						}
					}
				}
				if (gClass != null)
				{
					method_71(method_8().IndexOf(gClass));
				}
			}
		}

		public string[] method_82()
		{
			List<string> list = new List<string>();
			foreach (GClass290 item in method_8())
			{
				if (item.method_15() && item.method_5() != null)
				{
					list.Add(Convert.ToString(item.method_5()));
				}
			}
			return list.ToArray();
		}

		public void method_83(string[] string_2)
		{
			GClass290 gClass = null;
			foreach (GClass290 item in method_8())
			{
				bool flag = false;
				if (item.method_5() != null && string_2 != null)
				{
					string a = Convert.ToString(item.method_5());
					foreach (string b in string_2)
					{
						if (a == b)
						{
							flag = true;
							break;
						}
					}
				}
				if (item.method_15() != flag)
				{
					item.method_16(flag);
					method_13(bool_14: true);
				}
				if (flag && gClass == null)
				{
					gClass = item;
					method_71(method_8().IndexOf(item));
				}
			}
		}

		public string method_84()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (GClass290 item in method_8())
			{
				if (item.method_15())
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(method_35());
					}
					stringBuilder.Append(item.method_2());
				}
			}
			return stringBuilder.ToString();
		}

		public void method_85(string string_2)
		{
			if (string_2 == null)
			{
				return;
			}
			GClass290 gClass = null;
			string[] array = StringConvertHelper.Split(string_2, method_35());
			if (array != null)
			{
				foreach (GClass290 item in method_8())
				{
					item.method_18(bool_5: false);
					string[] array2 = array;
					foreach (string string_3 in array2)
					{
						if (vmethod_9(item, string_3))
						{
							method_13(bool_14: true);
							item.method_16(bool_5: true);
							if (gClass == null)
							{
								gClass = item;
							}
							break;
						}
					}
				}
				if (gClass != null)
				{
					method_71(method_8().IndexOf(gClass));
				}
			}
		}

		public string method_86()
		{
			if (vmethod_6())
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (GClass290 item in method_8())
				{
					if (item.method_17())
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(method_35());
						}
						if (item.method_5() != null)
						{
							stringBuilder.Append(Convert.ToString(item.method_5()));
						}
					}
				}
				return stringBuilder.ToString();
			}
			if (int_9 >= 0 && int_9 < method_8().Count)
			{
				return Convert.ToString(method_8()[int_9].method_5());
			}
			return null;
		}

		public void method_87(string string_2)
		{
			if (string_2 == null)
			{
				return;
			}
			if (vmethod_6())
			{
				GClass290 gClass = null;
				string[] array = StringConvertHelper.Split(string_2, method_35());
				if (array != null)
				{
					foreach (GClass290 item in method_8())
					{
						item.method_18(bool_5: false);
						string[] array2 = array;
						foreach (string b in array2)
						{
							if (item.method_5() != null)
							{
								string a = Convert.ToString(item.method_5());
								if (a == b)
								{
									method_13(bool_14: true);
									item.method_18(bool_5: true);
									if (gClass == null)
									{
										gClass = item;
									}
									break;
								}
							}
						}
					}
					if (gClass != null)
					{
						method_71(method_8().IndexOf(gClass));
					}
				}
			}
			else
			{
				foreach (GClass290 item2 in method_8())
				{
					if (item2.method_5() != null)
					{
						string a = Convert.ToString(item2.method_5());
						if (a == string_2)
						{
							method_13(bool_14: true);
							method_95(method_8().IndexOf(item2));
							break;
						}
					}
				}
			}
		}

		public string[] method_88()
		{
			if (vmethod_6())
			{
				List<string> list = new List<string>();
				foreach (GClass290 item in method_8())
				{
					if (item.method_17() && item.method_5() != null)
					{
						list.Add(Convert.ToString(item.method_5()));
					}
				}
				return list.ToArray();
			}
			if (int_9 >= 0 && int_9 < method_8().Count)
			{
				return new string[1]
				{
					Convert.ToString(method_8()[int_9].method_5())
				};
			}
			return null;
		}

		public void method_89(string[] string_2)
		{
			if (vmethod_6())
			{
				GClass290 gClass = null;
				foreach (GClass290 item in method_8())
				{
					bool flag = false;
					if (item.method_5() != null && string_2 != null)
					{
						string a = Convert.ToString(item.method_5());
						foreach (string b in string_2)
						{
							if (a == b)
							{
								flag = true;
								break;
							}
						}
					}
					if (item.method_17() != flag)
					{
						item.method_18(flag);
						method_13(bool_14: true);
					}
					if (flag && gClass == null)
					{
						gClass = item;
						method_71(method_8().IndexOf(gClass));
					}
				}
			}
			else if (string_2 != null && string_2.Length > 0)
			{
				method_87(string_2[0]);
			}
		}

		public string method_90()
		{
			if (vmethod_6())
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (GClass290 item in method_8())
				{
					if (item.method_17())
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(method_35());
						}
						stringBuilder.Append(item.method_2());
					}
				}
				return stringBuilder.ToString();
			}
			if (int_9 >= 0 && int_9 < method_8().Count)
			{
				return method_8()[int_9].method_2();
			}
			return null;
		}

		public void method_91(string string_2)
		{
			if (string_2 == null)
			{
				return;
			}
			if (vmethod_6())
			{
				GClass290 gClass = null;
				string[] array = StringConvertHelper.Split(string_2, method_35());
				if (array != null)
				{
					foreach (GClass290 item in method_8())
					{
						item.method_18(bool_5: false);
						string[] array2 = array;
						foreach (string string_3 in array2)
						{
							if (vmethod_9(item, string_3))
							{
								method_13(bool_14: true);
								item.method_18(bool_5: true);
								if (gClass == null)
								{
									gClass = item;
								}
								break;
							}
						}
					}
					if (gClass != null)
					{
						method_71(method_8().IndexOf(gClass));
					}
				}
			}
			else
			{
				GClass290 current = method_56(string_2, bool_14: false);
				if (current != null)
				{
					method_13(bool_14: true);
					method_71(method_8().IndexOf(current));
				}
			}
		}

		protected virtual bool vmethod_9(GClass290 gclass290_1, string string_2)
		{
			return gclass290_1.method_2() == string_2;
		}

		public string method_92()
		{
			if (int_9 >= 0 && int_9 < method_8().Count)
			{
				return method_8()[int_9].method_31();
			}
			return null;
		}

		public void method_93(string string_2)
		{
			method_79(method_57(string_2));
		}

		public void method_94(string string_2, bool bool_14)
		{
			GClass290 gClass = method_56(string_2, bool_14);
			if (gClass != null)
			{
				method_68(method_8().IndexOf(gClass));
			}
		}

		private void method_95(int int_12)
		{
			if (method_8().Count > 0)
			{
				if (int_12 < 0)
				{
					int_12 = 0;
				}
				if (int_12 >= method_8().Count)
				{
					int_12 = method_8().Count - 1;
				}
				method_68(int_12);
			}
		}

		public Size method_96()
		{
			return size_0;
		}

		public Size method_97()
		{
			int num = 18;
			Size empty = Size.Empty;
			if (base.IsDisposed)
			{
				return empty;
			}
			int num2 = 0;
			foreach (GClass290 item in method_8())
			{
				item.method_50(num2);
				num2 += method_47(item);
			}
			empty.Height = num2;
			if (empty.Height < 20)
			{
				empty.Height = 20;
			}
			int_2 = 0;
			if (method_43() && method_50())
			{
				using (Graphics graphics = CreateGraphics())
				{
					int_2 = (int)graphics.MeasureString("(H)", Font).Width + 4;
				}
			}
			int_3 = (method_52() ? 19 : 0);
			int_1 = ((method_27() && method_51()) ? 12 : 0);
			int num3 = 0;
			using (Graphics graphics = panel_0.CreateGraphics())
			{
				num3 = (int)graphics.MeasureString("H", Font, 1000, StringFormat.GenericTypographic).Width;
			}
			int num4 = 0;
			if (method_2())
			{
				list_0 = new List<float>();
				int num5 = 0;
				using (Graphics graphics2 = panel_0.CreateGraphics())
				{
					XFontValue xfontValue_ = new XFontValue(Font);
					GClass443 gClass = new GClass443(null, graphics2, Font);
					foreach (GClass290 item2 in method_8())
					{
						if (item2.method_0() == GEnum69.const_0)
						{
							num5 = Math.Max(num5, item2.method_51());
							string[] array = item2.method_4(this);
							if (array != null && array.Length > 0)
							{
								if (list_0.Count < array.Length)
								{
									for (int i = list_0.Count; i < array.Length; i++)
									{
										list_0.Add(5f);
									}
								}
								for (int i = 0; i < array.Length; i++)
								{
									string value = array[i];
									if (!string.IsNullOrEmpty(value))
									{
										float num6 = 0f;
										num6 = ((gdelegate14_0 != null) ? gdelegate14_0(value, xfontValue_, graphics2) : (gClass.method_0(value) + 4f));
										if (list_0[i] < num6)
										{
											list_0[i] = num6;
										}
									}
								}
							}
						}
					}
					for (int i = 0; i < list_0.Count - 1; i++)
					{
						list_0[i] += 5f;
					}
				}
				float_0 = 0f;
				for (int i = 0; i < list_0.Count; i++)
				{
					float_0 += list_0[i];
				}
				num4 = (int)float_0 + num5 * method_29() + 7;
			}
			else
			{
				using (Graphics graphics2 = panel_0.CreateGraphics())
				{
					XFontValue xfontValue_ = new XFontValue(Font);
					GClass443 gClass = new GClass443(null, graphics2, xfontValue_.Value);
					foreach (GClass290 item3 in method_8())
					{
						if (item3.method_0() == GEnum69.const_0)
						{
							string value = vmethod_5(item3);
							if (value == null || value.Length == 0)
							{
								value = " ";
							}
							float num7 = 0f;
							num7 = ((gdelegate14_0 != null) ? gdelegate14_0(value, xfontValue_, graphics2) : gClass.method_0(value));
							int num8 = (int)num7 + item3.method_51() * method_29();
							if (num8 > num4)
							{
								num4 = num8;
							}
						}
					}
				}
			}
			int num9 = int_6 + int_3 + int_1 + num4 + num3 + 3;
			if (method_14())
			{
				num9 += 20;
			}
			if (num9 < 150)
			{
				num9 = 150;
			}
			empty.Width = num9;
			size_0 = empty;
			return empty;
		}

		private void method_98()
		{
			panel_0.AutoScrollMinSize = new Size(10, method_96().Height);
		}

		private int method_99(GClass290 gclass290_1)
		{
			return method_39() + gclass290_1.method_51() * method_29();
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			if (base.IsDisposed)
			{
				return Size.Empty;
			}
			Size result = method_97();
			method_98();
			if (result.Height > panel_0.Height)
			{
				int num = GClass247.smethod_20();
				result.Width += num;
			}
			int num2 = base.Width - panel_0.ClientSize.Width;
			int num3 = base.Height - panel_0.ClientSize.Height;
			result.Width += num2;
			result.Height += num3;
			if (method_14())
			{
				result.Width += label_1.Width;
			}
			if (method_10())
			{
				result.Width += image_0.Width;
			}
			if (proposedSize.IsEmpty)
			{
				return result;
			}
			if (proposedSize.Width > 0 && proposedSize.Width < result.Width)
			{
				result.Width = proposedSize.Width;
			}
			if (proposedSize.Height > 0 && proposedSize.Height < result.Height)
			{
				result.Height = proposedSize.Height;
			}
			result.Width = Math.Min(result.Width, (int)((double)Screen.PrimaryScreen.WorkingArea.Width * 0.8));
			return result;
		}

		public void method_100()
		{
			int_10++;
		}

		public void method_101()
		{
			int_10--;
			if (int_10 <= 0)
			{
				int_10 = 0;
				method_98();
				panel_0.Invalidate();
				vmethod_4(EventArgs.Empty);
			}
		}

		public bool method_102()
		{
			return int_10 > 0;
		}

		public void method_103(GClass290 gclass290_1)
		{
			if (gclass290_1 != null)
			{
				panel_0.Invalidate(method_105(gclass290_1));
			}
		}

		private Rectangle method_104(GClass290 gclass290_1)
		{
			int num = 8;
			if (gclass290_1 == null)
			{
				throw new ArgumentNullException("myItem");
			}
			if (method_27() && gclass290_1 != null && gclass290_1.method_41())
			{
				return GClass257.smethod_2(method_39() + gclass290_1.method_51() * int_4, gclass290_1.method_49() + panel_0.AutoScrollPosition.Y, method_47(gclass290_1));
			}
			return Rectangle.Empty;
		}

		public Rectangle method_105(GClass290 gclass290_1)
		{
			int num = 15;
			if (gclass290_1 == null)
			{
				throw new ArgumentNullException("item");
			}
			Rectangle empty = Rectangle.Empty;
			empty.X = 0;
			empty.Y = gclass290_1.method_49() + panel_0.AutoScrollPosition.Y;
			empty.Width = base.ClientSize.Width;
			empty.Height = method_47(gclass290_1);
			return empty;
		}

		private void panel_0_Paint(object sender, PaintEventArgs e)
		{
			int num = 4;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			bool flag = RightToLeft == RightToLeft.Yes;
			if (stringFormat_0 == null)
			{
				stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
				stringFormat_0.Alignment = StringAlignment.Near;
			}
			if (flag)
			{
				stringFormat_0.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
			}
			if (method_8() != null && !method_102())
			{
				Graphics graphics = e.Graphics;
				float num2 = Font.GetHeight() + 1f;
				using (StringFormat stringFormat = new StringFormat())
				{
					Brush windowText = SystemBrushes.WindowText;
					stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
					Rectangle clipRectangle = e.ClipRectangle;
					SolidBrush solidBrush = null;
					int width = panel_0.ClientSize.Width;
					for (int i = 0; i < method_8().Count; i++)
					{
						GClass290 gClass = method_8()[i];
						int num3 = gClass.method_49() + panel_0.AutoScrollPosition.Y;
						if (num3 > clipRectangle.Bottom)
						{
							break;
						}
						int num4 = method_47(gClass);
						if (num3 + num4 >= clipRectangle.Top && num3 <= clipRectangle.Bottom)
						{
							int num5 = method_39() + gClass.method_51() * method_29();
							int num6 = num5 + int_3 + int_1;
							if (method_10())
							{
								num6 += image_0.Width;
							}
							RectangleF rectangleF_ = new RectangleF(num6, (float)num3 + ((float)num4 - num2) / 2f, width - num6 - 5, num2);
							if (gClass.method_0() == GEnum69.const_0)
							{
								int num7 = num5;
								if (int_1 > 0)
								{
									if (gClass.method_41())
									{
										Rectangle rectangle_ = GClass257.smethod_2(num5, num3, num4);
										GClass257.smethod_0(graphics, rectangle_, gClass.method_43());
									}
									num7 += int_1;
								}
								if (method_10())
								{
									if (gClass.method_15())
									{
										graphics.DrawImage(image_0, num5, num3 + (num4 - image_0.Height) / 2);
									}
									else
									{
										graphics.DrawImage(image_1, num5, num3 + (num4 - image_0.Height) / 2);
									}
									num7 += image_0.Width;
								}
								if (gClass.method_29() != null)
								{
									graphics.DrawImage(gClass.method_29(), num7, rectangleF_.Top + (rectangleF_.Height - 16f) / 2f, 16f, 16f);
								}
								if (gClass.method_17())
								{
									graphics.FillRectangle(SystemBrushes.Highlight, rectangleF_.Left - 2f, rectangleF_.Top - 1f, rectangleF_.Width + 2f, rectangleF_.Height);
									if (!char.IsWhiteSpace(gClass.method_37()))
									{
										graphics.DrawString("(&" + gClass.method_37() + ")", Font, SystemBrushes.HighlightText, rectangleF_.Left, rectangleF_.Top, stringFormat);
									}
									rectangleF_.X += int_2;
									rectangleF_.Width -= int_2;
									method_106(gClass, rectangleF_, graphics, SystemBrushes.HighlightText);
								}
								else
								{
									if (!char.IsWhiteSpace(gClass.method_37()))
									{
										graphics.DrawString("(&" + gClass.method_37() + ")", Font, windowText, rectangleF_.Left, rectangleF_.Top, stringFormat);
									}
									rectangleF_.X += int_2;
									rectangleF_.Width -= int_2;
									method_106(gClass, rectangleF_, graphics, windowText);
								}
								if (gClass == method_111() && int_11 < 3)
								{
									try
									{
										using (Pen pen = new Pen(vmethod_6() ? Color.Red : Color.Blue))
										{
											graphics.DrawRectangle(pen, num5 - 2, num3, width - num5 - 2, num4 - 1);
										}
									}
									catch (Exception)
									{
										int_11++;
									}
								}
							}
							else if (gClass.method_0() == GEnum69.const_1)
							{
								using (Pen pen2 = new Pen(Color.Black, 2f))
								{
									int num8 = num3 + (int)((double)num4 / 2.0);
									graphics.DrawLine(pen2, num5 + 5, num8, width - 10, num8);
								}
							}
						}
					}
					solidBrush?.Dispose();
				}
			}
		}

		private void method_106(GClass290 gclass290_1, RectangleF rectangleF_0, Graphics graphics_0, Brush brush_0)
		{
			if (method_2())
			{
				string[] array = gclass290_1.method_4(this);
				if (array == null || array.Length <= 0 || list_0 == null)
				{
					return;
				}
				float num = rectangleF_0.Left;
				for (int i = 0; i < array.Length && i < list_0.Count; i++)
				{
					float num2 = list_0[i];
					string text = array[i];
					if (!string.IsNullOrEmpty(text))
					{
						if (method_107(text))
						{
							stringFormat_0.FormatFlags = (StringFormatFlags.DirectionRightToLeft | StringFormatFlags.NoWrap);
						}
						else
						{
							stringFormat_0.FormatFlags = StringFormatFlags.NoWrap;
						}
						graphics_0.DrawString(text, Font, brush_0, new RectangleF(num, rectangleF_0.Top, num2, rectangleF_0.Height), stringFormat_0);
					}
					num += num2;
				}
				return;
			}
			string text2 = vmethod_5(gclass290_1);
			if (!string.IsNullOrEmpty(text2))
			{
				if (method_107(text2))
				{
					stringFormat_0.FormatFlags = (StringFormatFlags.DirectionRightToLeft | StringFormatFlags.NoWrap);
				}
				else
				{
					stringFormat_0.FormatFlags = StringFormatFlags.NoWrap;
				}
				graphics_0.DrawString(text2, Font, brush_0, rectangleF_0, stringFormat_0);
			}
		}

		private bool method_107(string string_2)
		{
			if (string.IsNullOrEmpty(string_2))
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < string_2.Length)
				{
					char c = string_2[num];
					if (c >= '\u0600' && c <= 'ۿ')
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		private bool method_108(GClass290 gclass290_1)
		{
			if (gclass290_1 != null && gclass290_1.method_41())
			{
				bool flag = false;
				if (gclass290_1.method_43())
				{
					int num = 0;
					GClass290 gClass = gclass290_1;
					for (int i = method_8().IndexOf(gclass290_1) + 1; i < method_8().Count; i++)
					{
						GClass290 gClass2 = method_8()[i];
						if (gClass2.method_53() != gClass)
						{
							gClass = gClass2.method_53();
							while (gClass != null && gClass != gclass290_1)
							{
								gClass = gClass.method_53();
							}
							if (gClass != gclass290_1)
							{
								break;
							}
						}
						num++;
					}
					if (num > 0)
					{
						method_8().RemoveRange(method_8().IndexOf(gclass290_1) + 1, num);
						flag = true;
					}
				}
				else
				{
					List<GClass290> list = new List<GClass290>();
					vmethod_8(gclass290_1, list);
					if (list.Count > 0)
					{
						foreach (GClass290 item in list)
						{
							item.method_52(gclass290_1.method_51() + 1);
							item.method_54(gclass290_1);
						}
						method_8().InsertRange(method_8().IndexOf(gclass290_1) + 1, list);
						flag = true;
					}
					else
					{
						gclass290_1.method_42(bool_5: false);
					}
				}
				gclass290_1.method_44(!gclass290_1.method_43());
				if (flag)
				{
					method_55(bool_14: false);
					method_97();
					method_98();
					vmethod_4(EventArgs.Empty);
					panel_0.Refresh();
				}
				else
				{
					method_103(gclass290_1);
				}
				return flag;
			}
			return false;
		}

		private void panel_0_DoubleClick(object sender, EventArgs e)
		{
			if (method_78() == null)
			{
				return;
			}
			Rectangle rectangle = method_104(method_78());
			if (!rectangle.IsEmpty)
			{
				Point mousePosition = Control.MousePosition;
				if (panel_0.PointToClient(mousePosition).X <= rectangle.Left + int_1)
				{
					return;
				}
			}
			vmethod_2(EventArgs.Empty);
		}

		public bool method_109()
		{
			return bool_10;
		}

		public void method_110(bool bool_14)
		{
			bool_10 = bool_14;
		}

		public GClass290 method_111()
		{
			if (gclass290_0 != null && !method_8().Contains(gclass290_0))
			{
				gclass290_0 = null;
			}
			return gclass290_0;
		}

		public void method_112(GClass290 gclass290_1)
		{
			if (gclass290_0 != gclass290_1)
			{
				if (gclass290_0 != null)
				{
					method_103(gclass290_0);
				}
				gclass290_0 = gclass290_1;
				if (gclass290_0 != null)
				{
					method_103(gclass290_0);
					method_70(gclass290_0);
				}
			}
		}

		private void panel_0_MouseLeave(object sender, EventArgs e)
		{
			method_112(null);
		}

		private void panel_0_MouseMove(object sender, MouseEventArgs e)
		{
			if (bool_9 || (point_0.X == e.X && point_0.Y == e.Y))
			{
				return;
			}
			point_0 = new Point(e.X, e.Y);
			bool bool_ = method_12();
			GClass290 gClass = method_65(e.X, e.Y);
			if (vmethod_6())
			{
				method_112(gClass);
			}
			else if (!method_109())
			{
				method_112(gClass);
			}
			else
			{
				method_79(gClass);
			}
			if (gClass != null && gClass.method_0() != GEnum69.const_1)
			{
				if (method_14())
				{
					label_1.Left = panel_0.ClientSize.Width - label_1.Width - 1;
					label_1.Top = gClass.method_49() + (method_47(gClass) - label_1.Height) / 2 + panel_0.AutoScrollPosition.Y;
					label_1.Visible = true;
					label_1.Tag = gClass;
				}
				else
				{
					label_1.Visible = false;
				}
				method_13(bool_);
			}
		}

		public bool method_113()
		{
			return bool_11;
		}

		public void method_114(bool bool_14)
		{
			bool_11 = bool_14;
		}

		private void panel_0_MouseUp(object sender, MouseEventArgs e)
		{
			if (base.Visible && e.Button == MouseButtons.Right && (vmethod_6() || method_10()))
			{
				vmethod_2(EventArgs.Empty);
			}
		}

		private bool method_115(GClass290 gclass290_1, bool bool_14)
		{
			if (gclass290_1.method_15() == bool_14)
			{
				return true;
			}
			bool flag = false;
			if (bool_14 && !string.IsNullOrEmpty(gclass290_1.method_7()) && method_0())
			{
				foreach (GClass290 item in method_8())
				{
					if (item.method_7() != gclass290_1.method_7() && item.method_15())
					{
						item.method_16(bool_5: false);
						item.method_20(DateTime.Now);
						flag = true;
					}
				}
			}
			bool flag2;
			if (gclass290_1.method_13())
			{
				gclass290_1.method_16(bool_14);
				gclass290_1.method_20(DateTime.Now);
				if (bool_14)
				{
					flag2 = false;
					foreach (GClass290 item2 in method_8())
					{
						if (item2 != gclass290_1 && item2.method_0() == GEnum69.const_0 && item2.method_15() && item2.method_7() == gclass290_1.method_7())
						{
							item2.method_16(bool_5: false);
							item2.method_20(DateTime.Now);
							flag = true;
							flag2 = true;
						}
					}
					if (flag2 || flag)
					{
						panel_0.Invalidate();
					}
				}
				return true;
			}
			flag2 = false;
			foreach (GClass290 item3 in method_8())
			{
				if (item3.method_0() == GEnum69.const_0 && item3.method_13() && item3 != gclass290_1 && item3.method_7() == gclass290_1.method_7() && item3.method_15())
				{
					item3.method_16(bool_5: false);
					flag2 = true;
				}
			}
			if (flag2 || flag)
			{
				panel_0.Invalidate();
			}
			gclass290_1.method_16(bool_14);
			gclass290_1.method_20(DateTime.Now);
			return true;
		}

		private void panel_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (!base.Visible || (e.Button == MouseButtons.Right && (vmethod_6() || method_10())))
			{
				return;
			}
			GClass290 gClass = method_65(e.X, e.Y);
			if (gClass == null || gClass.method_0() != 0)
			{
				return;
			}
			if (method_113() && gClass.method_41())
			{
				method_108(gClass);
				return;
			}
			Rectangle rectangle = method_104(gClass);
			if (!rectangle.IsEmpty && e.X <= rectangle.Left + int_1)
			{
				if (rectangle.Contains(e.X, e.Y))
				{
					method_108(gClass);
				}
			}
			else if (vmethod_6())
			{
				if (method_115(gClass, !gClass.method_15()))
				{
					if (gClass.method_17())
					{
						method_68(method_8().IndexOf(gClass));
					}
					method_13(bool_14: true);
					vmethod_1(EventArgs.Empty);
					panel_0.Refresh();
				}
			}
			else
			{
				method_13(bool_14: true);
				method_68(method_8().IndexOf(gClass));
				panel_0.Refresh();
				if (method_10())
				{
					method_118(gClass, !gClass.method_15());
					method_103(gClass);
				}
				else
				{
					vmethod_2(EventArgs.Empty);
				}
			}
		}

		public bool method_116()
		{
			return bool_13;
		}

		public void method_117(bool bool_14)
		{
			bool_12 = false;
			bool_13 = bool_14;
		}

		public bool PreFilterMessage(ref Message message_0)
		{
			bool result = false;
			if (base.IsDisposed || base.Disposing || !base.Visible || !base.IsHandleCreated)
			{
				return false;
			}
			_ = base.Bounds;
			if (method_116())
			{
				if (message_0.Msg == 522)
				{
					Point p = new Point((int)message_0.LParam);
					p = PointToClient(p);
					if (panel_0.Bounds.Contains(p))
					{
						GClass262.SendMessage(panel_0.Handle, message_0.Msg, (uint)(int)message_0.WParam, (uint)(int)message_0.LParam);
					}
					return true;
				}
				if (message_0.Msg == 256)
				{
					GClass290 gClass = method_78();
					result = true;
					switch ((int)message_0.WParam)
					{
					case 32:
						if (bool_12)
						{
							result = true;
							if (vmethod_6())
							{
								GClass290 gClass2 = method_111();
								if (gClass2 != null)
								{
									gClass2.method_18(!gClass2.method_17());
									vmethod_1(EventArgs.Empty);
									method_103(gClass2);
								}
							}
							else if (method_10())
							{
								GClass290 gClass3 = method_78();
								if (gClass3 != null)
								{
									method_118(gClass3, !gClass3.method_15());
									vmethod_1(EventArgs.Empty);
									method_103(gClass3);
								}
							}
							else
							{
								vmethod_2(EventArgs.Empty);
							}
						}
						else
						{
							result = false;
						}
						break;
					case 33:
						method_119(-10);
						bool_12 = true;
						break;
					case 34:
						method_119(10);
						bool_12 = true;
						break;
					case 38:
						method_119(-1);
						bool_12 = true;
						break;
					default:
						result = false;
						break;
					case 40:
						method_119(1);
						bool_12 = true;
						break;
					case 13:
						if (bool_12)
						{
							vmethod_2(EventArgs.Empty);
							result = true;
						}
						else
						{
							result = false;
						}
						break;
					}
					return result;
				}
				return false;
			}
			if (message_0.Msg == 522)
			{
				Point p = new Point((int)message_0.LParam);
				p = PointToClient(p);
				if (panel_0.Bounds.Contains(p))
				{
					GClass262.SendMessage(panel_0.Handle, message_0.Msg, (uint)(int)message_0.WParam, (uint)(int)message_0.LParam);
				}
				return true;
			}
			if (message_0.Msg == 513)
			{
				Console.WriteLine("");
			}
			if (message_0.Msg == 256 && message_0.WParam.ToInt32() == 8)
			{
				message_0.Msg = 258;
				message_0.WParam = new IntPtr(8);
			}
			if (message_0.Msg == 258 && label_0.Visible)
			{
				bool flag = false;
				if (string_0 != null && label_0.Text == string_0)
				{
					label_0.Text = "";
				}
				int num = (int)message_0.WParam;
				if (num != 8)
				{
					if (!char.IsWhiteSpace((char)(int)message_0.WParam))
					{
						int num2 = (int)message_0.WParam;
						if ((num2 > 47 && num2 < 58) || (num2 > 64 && num2 < 91) || (num2 > 96 && num2 < 123))
						{
							label_0.Text += ((char)(int)message_0.WParam).ToString().ToUpper();
							flag = true;
						}
					}
				}
				else if (label_0.Text.Length > 0)
				{
					label_0.Text = label_0.Text.Substring(0, label_0.Text.Length - 1);
					flag = true;
				}
				else if (!vmethod_11())
				{
					vmethod_3(EventArgs.Empty);
				}
				if (flag)
				{
					vmethod_10(label_0.Text);
				}
				if (string_0 != null && label_0.Text == "")
				{
					label_0.Text = string_0;
				}
				return true;
			}
			if (message_0.Msg == 256)
			{
				GClass290 gClass = method_78();
				result = true;
				switch ((int)message_0.WParam)
				{
				case 27:
					vmethod_3(EventArgs.Empty);
					result = true;
					break;
				default:
					result = false;
					if (bool_7)
					{
						int num3 = message_0.WParam.ToInt32();
						foreach (GClass290 item in method_8())
						{
							if (!char.IsWhiteSpace(item.method_37()) && item.method_37() == num3)
							{
								method_79(item);
								vmethod_2(EventArgs.Empty);
								result = true;
								break;
							}
						}
					}
					break;
				case 32:
					result = true;
					if (vmethod_6())
					{
						GClass290 gClass2 = method_111();
						if (gClass2 != null)
						{
							gClass2.method_18(!gClass2.method_17());
							vmethod_1(EventArgs.Empty);
							method_103(gClass2);
						}
					}
					else if (method_10())
					{
						GClass290 gClass3 = method_78();
						if (gClass3 != null)
						{
							method_118(gClass3, !gClass3.method_15());
							vmethod_1(EventArgs.Empty);
							method_103(gClass3);
						}
					}
					else
					{
						vmethod_2(EventArgs.Empty);
					}
					break;
				case 33:
					method_119(-10);
					break;
				case 34:
					method_119(10);
					break;
				case 35:
					method_119(100000);
					break;
				case 36:
					method_119(-100000);
					break;
				case 37:
					result = false;
					if (method_27() && gClass != null)
					{
						if (gClass.method_41() && gClass.method_43())
						{
							method_108(gClass);
							result = true;
						}
						else if (gClass.method_53() != null)
						{
							method_79(gClass.method_53());
							result = true;
						}
					}
					result = true;
					break;
				case 38:
					method_119(-1);
					break;
				case 39:
					result = false;
					if (method_27() && gClass != null)
					{
						if (gClass.method_41() && !gClass.method_43())
						{
							method_108(gClass);
							result = true;
						}
						else
						{
							_ = method_67() + 1;
							if (method_67() >= 0 && method_67() < method_8().Count - 1)
							{
								GClass290 gClass4 = method_8()[method_67() + 1];
								if (gClass4.method_53() == method_78())
								{
									method_79(gClass4);
									result = true;
								}
							}
						}
					}
					result = true;
					break;
				case 40:
					method_119(1);
					break;
				case 17:
					if (method_27())
					{
						GClass290 gClass2 = method_78();
						method_108(gClass2);
					}
					break;
				case 13:
					vmethod_2(EventArgs.Empty);
					result = true;
					break;
				}
			}
			return result;
		}

		private bool method_118(GClass290 gclass290_1, bool bool_14)
		{
			if (bool_14)
			{
				if (method_10())
				{
					return method_115(gclass290_1, bool_14);
				}
				return method_115(gclass290_1, bool_14);
			}
			return method_115(gclass290_1, bool_14);
		}

		private void method_119(int int_12)
		{
			if (vmethod_6())
			{
				if (method_111() == null)
				{
					method_112(method_8()[0]);
					return;
				}
				int num = method_8().IndexOf(method_111()) + int_12;
				if (num < 0)
				{
					num = 0;
				}
				else if (num >= method_8().Count)
				{
					num = method_8().Count - 1;
				}
				method_112(method_8()[num]);
			}
			else
			{
				int num = method_67() + int_12;
				if (num < 0)
				{
					num = 0;
				}
				else if (num >= method_8().Count)
				{
					num = method_8().Count - 1;
				}
				method_95(num);
			}
		}

		public string method_120()
		{
			return label_0.Text;
		}

		public void method_121(string string_2)
		{
			label_0.Text = string_2;
		}

		public void method_122(CancelEventHandler cancelEventHandler_1)
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_0;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, cancelEventHandler_1);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}

		public void method_123(CancelEventHandler cancelEventHandler_1)
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_0;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, cancelEventHandler_1);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}

		protected virtual void vmethod_10(string string_2)
		{
			if (cancelEventHandler_0 != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				cancelEventArgs.Cancel = false;
				cancelEventHandler_0(this, cancelEventArgs);
				if (cancelEventArgs.Cancel)
				{
					return;
				}
			}
			bool_9 = true;
			foreach (GClass290 item in method_8())
			{
				if (item.method_51() == 0 && item.method_31() != null && (item.method_31().StartsWith(string_2) || item.method_2().StartsWith(string_2)))
				{
					if (vmethod_6())
					{
						method_112(item);
					}
					else
					{
						method_71(method_8().IndexOf(item));
					}
					break;
				}
			}
			bool_9 = false;
		}

		protected virtual bool vmethod_11()
		{
			return false;
		}

		protected override void Dispose(bool disposing)
		{
			Application.RemoveMessageFilter(this);
			if (imageList_0 != null)
			{
				imageList_0.Dispose();
				imageList_0 = null;
			}
			base.Dispose(disposing);
		}

		public bool method_124()
		{
			return label_0.Visible;
		}

		public void method_125(bool bool_14)
		{
			label_0.Visible = bool_14;
			if (bool_14)
			{
				panel_0.BorderStyle = BorderStyle.Fixed3D;
			}
			else
			{
				panel_0.BorderStyle = BorderStyle.None;
			}
		}

		[CompilerGenerated]
		private void method_126(object sender, EventArgs e)
		{
			label_1.BackColor = Color.WhiteSmoke;
		}

		[CompilerGenerated]
		private void method_127(object sender, EventArgs e)
		{
			label_1.BackColor = Color.Gainsboro;
		}
	}
}
