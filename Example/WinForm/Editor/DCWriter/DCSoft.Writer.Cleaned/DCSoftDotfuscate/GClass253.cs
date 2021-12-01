using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass253 : IMessageFilter
	{
		private static GClass253 gclass253_0 = null;

		private bool bool_0 = false;

		private List<IntPtr> list_0 = new List<IntPtr>();

		private List<int> list_1 = new List<int>();

		public static GClass253 smethod_0()
		{
			if (gclass253_0 == null)
			{
				gclass253_0 = new GClass253();
				gclass253_0.list_1.Add(15);
				gclass253_0.list_1.Add(777);
				gclass253_0.list_1.Add(38);
				gclass253_0.list_1.Add(785);
				gclass253_0.list_1.Add(784);
				gclass253_0.list_1.Add(528);
				gclass253_0.list_1.Add(133);
				gclass253_0.list_1.Add(136);
			}
			return gclass253_0;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			if (bool_0 != bool_1)
			{
				bool_0 = bool_1;
				if (bool_0)
				{
					Application.AddMessageFilter(this);
				}
				else
				{
					Application.RemoveMessageFilter(this);
				}
			}
		}

		public List<IntPtr> method_2()
		{
			return list_0;
		}

		public void method_3(List<IntPtr> list_2)
		{
			list_0 = list_2;
		}

		public List<int> method_4()
		{
			return list_1;
		}

		public void method_5(List<int> list_2)
		{
			list_1 = list_2;
		}

		bool IMessageFilter.PreFilterMessage(ref Message message_0)
		{
			if (list_0 != null && list_0.Count > 0)
			{
				foreach (IntPtr item in list_0)
				{
					if (message_0.HWnd == item)
					{
						return false;
					}
				}
			}
			if (list_1 != null && list_1.Count > 0)
			{
				foreach (int item2 in list_1)
				{
					if (item2 == message_0.Msg)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
