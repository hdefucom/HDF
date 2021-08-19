using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	public class GClass0 : CollectionBase
	{
		private Image image_0 = null;

		private object object_0 = null;

		private bool bool_0 = true;

		private string string_0 = null;

		private Hashtable hashtable_0 = new Hashtable();

		private EventHandler eventHandler_0 = null;

		private bool bool_1 = false;

		private int int_0 = 0;

		public Image method_0()
		{
			return image_0;
		}

		public void method_1(Image image_1)
		{
			image_0 = image_1;
		}

		public object method_2()
		{
			return object_0;
		}

		public void method_3(object object_1)
		{
			object_0 = object_1;
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public string method_6()
		{
			return string_0;
		}

		public void method_7()
		{
			method_8(bool_2: false);
		}

		public void method_8(bool bool_2)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(base.InnerList);
			if (bool_2)
			{
				arrayList.Sort();
			}
			hashtable_0.Clear();
			EventHandler eventHandler = method_11;
			if (object_0 is MenuItem)
			{
				MenuItem menuItem = (MenuItem)object_0;
				menuItem.MenuItems.Clear();
				foreach (string item in arrayList)
				{
					string text2 = item;
					if (!method_4())
					{
						text2 = Path.GetFileName(text2);
					}
					MenuItem menuItem2 = new MenuItem(text2, eventHandler);
					menuItem.MenuItems.Add(menuItem2);
					hashtable_0[menuItem2] = item;
				}
			}
			if (object_0 is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)object_0;
				toolStripMenuItem.DropDownItems.Clear();
				foreach (string item2 in arrayList)
				{
					string text2 = item2;
					if (!method_4())
					{
						text2 = Path.GetFileName(text2);
					}
					ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
					toolStripMenuItem2.Text = text2;
					toolStripMenuItem2.Image = method_0();
					toolStripMenuItem2.Click += eventHandler;
					toolStripMenuItem.DropDownItems.Add(toolStripMenuItem2);
					hashtable_0[toolStripMenuItem2] = item2;
				}
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

		protected virtual void vmethod_0(string string_1)
		{
			string_0 = string_1;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, null);
			}
		}

		private void method_11(object sender, EventArgs e)
		{
			string text = (string)hashtable_0[sender];
			if (text != null)
			{
				vmethod_0(text);
			}
		}

		public bool method_12()
		{
			return bool_1;
		}

		public void method_13(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public void method_14(string string_1, string string_2)
		{
			string[] files = Directory.GetFiles(string_1, string_2);
			if (files != null)
			{
				string[] array = files;
				foreach (string string_3 in array)
				{
					method_20(string_3);
				}
			}
		}

		public int method_15()
		{
			return int_0;
		}

		public void method_16(int int_1)
		{
			int_0 = int_1;
		}

		public string method_17(int int_1)
		{
			return (string)base.List[int_1];
		}

		public void method_18(IEnumerable ienumerable_0)
		{
			if (ienumerable_0 != null)
			{
				foreach (string item in ienumerable_0)
				{
					method_20(item);
				}
			}
		}

		protected void method_19(string string_1)
		{
			int num = 7;
			if (string_1 == null)
			{
				throw new ArgumentNullException("strName", "文件名不得为空");
			}
			string_1 = Path.GetFullPath(string_1);
			if (string_1 == null || (bool_1 && !File.Exists(string_1)))
			{
				return;
			}
			int num2 = method_22(string_1);
			if (num2 >= 0)
			{
				RemoveAt(num2);
			}
			if (int_0 > 0 && base.Count > int_0)
			{
				for (int num3 = base.Count - 1; num3 >= int_0; num3--)
				{
					base.List.RemoveAt(num3);
				}
			}
			base.List.Add(string_1);
		}

		public void method_20(string string_1)
		{
			int num = 9;
			if (string_1 == null)
			{
				throw new ArgumentNullException("strName", "文件名不得为空");
			}
			string_1 = Path.GetFullPath(string_1);
			if (bool_1 && !File.Exists(string_1))
			{
				return;
			}
			int num2 = method_22(string_1);
			if (num2 >= 0)
			{
				RemoveAt(num2);
			}
			if (int_0 > 0 && base.Count > int_0)
			{
				for (int num3 = base.Count - 1; num3 >= int_0; num3--)
				{
					base.List.RemoveAt(num3);
				}
			}
			base.List.Insert(0, string_1);
		}

		public void method_21(string string_1)
		{
			int num = method_22(string_1);
			if (num >= 0)
			{
				base.List.RemoveAt(num);
			}
		}

		public int method_22(string string_1)
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					if (string.Compare((string)base.List[num], string_1, ignoreCase: true) == 0)
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

		public bool method_23(string string_1)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string strA = (string)enumerator.Current;
					if (string.Compare(strA, string_1, ignoreCase: true) == 0)
					{
						return true;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return false;
		}
	}
}
