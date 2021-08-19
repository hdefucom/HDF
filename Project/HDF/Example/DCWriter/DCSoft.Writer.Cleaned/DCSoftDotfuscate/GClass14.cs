using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass14 : CollectionBase
	{
		protected int int_0 = 100;

		protected int int_1 = 0;

		private EventHandler eventHandler_0 = null;

		private bool bool_0 = false;

		private ArrayList arrayList_0 = null;

		protected virtual bool ForceUseGroup => false;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
		}

		public int method_2()
		{
			return int_1;
		}

		public GInterface1 method_3(int int_2)
		{
			return (GInterface1)base.List[int_2];
		}

		public GInterface1 method_4()
		{
			if (int_1 >= 0 && int_1 < base.Count)
			{
				return (GInterface1)base.List[int_1];
			}
			return null;
		}

		public void method_5(EventHandler eventHandler_1)
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

		public void method_6(EventHandler eventHandler_1)
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

		protected virtual void vmethod_0()
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, null);
			}
		}

		public bool method_7(GEventArgs3 geventArgs3_0)
		{
			if (int_1 < 0)
			{
				return false;
			}
			bool flag = bool_0;
			bool_0 = true;
			try
			{
				GInterface1 gInterface = method_4();
				int_1--;
				if (gInterface != null)
				{
					gInterface.Undo(geventArgs3_0);
					vmethod_0();
					return true;
				}
			}
			finally
			{
				bool_0 = flag;
			}
			return false;
		}

		public bool method_8(GEventArgs3 geventArgs3_0)
		{
			if (int_1 >= base.Count)
			{
				return false;
			}
			bool flag = bool_0;
			bool_0 = true;
			try
			{
				int_1++;
				GInterface1 gInterface = method_4();
				if (gInterface != null)
				{
					gInterface.Redo(geventArgs3_0);
					vmethod_0();
					return true;
				}
			}
			finally
			{
				bool_0 = flag;
			}
			return false;
		}

		public bool method_9()
		{
			return method_4() != null;
		}

		public bool method_10()
		{
			return int_1 + 1 >= 0 && int_1 + 1 < base.Count;
		}

		protected override void OnClearComplete()
		{
			base.OnClearComplete();
			int_1 = 0;
			bool_0 = false;
			arrayList_0 = null;
			vmethod_0();
		}

		public bool method_11()
		{
			return bool_0;
		}

		public void method_12(bool bool_1)
		{
			bool_0 = bool_1;
		}

		protected ArrayList method_13()
		{
			return arrayList_0;
		}

		public virtual bool vmethod_1()
		{
			if (bool_0)
			{
				arrayList_0 = null;
				return false;
			}
			arrayList_0 = new ArrayList();
			return true;
		}

		public virtual void vmethod_2()
		{
			arrayList_0 = null;
		}

		protected virtual GClass113 vmethod_3()
		{
			return new GClass113();
		}

		public virtual bool vmethod_4()
		{
			if (bool_0)
			{
				arrayList_0 = null;
				return false;
			}
			bool flag = false;
			if (arrayList_0 != null && arrayList_0.Count > 0)
			{
				flag = true;
				int num = base.Count - 1;
				while (num > int_1 && num >= 0)
				{
					RemoveAt(num);
					num--;
				}
				if (arrayList_0.Count == 1 && !ForceUseGroup)
				{
					base.List.Add((GInterface1)arrayList_0[0]);
				}
				else
				{
					GClass113 gClass = vmethod_3();
					foreach (GInterface1 item in arrayList_0)
					{
						gClass.vmethod_0(item);
					}
					base.List.Add(gClass);
				}
				int_1 = base.Count - 1;
			}
			arrayList_0 = null;
			if (int_0 > 0)
			{
				while (base.Count > int_0)
				{
					flag = true;
					base.List.RemoveAt(0);
					int_1 = base.Count - 1;
				}
			}
			if (flag)
			{
				vmethod_0();
			}
			return flag;
		}

		public void method_14(GInterface1 ginterface1_0)
		{
			if (ginterface1_0 != null && arrayList_0 != null && !arrayList_0.Contains(ginterface1_0) && arrayList_0 != null)
			{
				arrayList_0.Add(ginterface1_0);
			}
		}

		public bool method_15()
		{
			return !bool_0 && arrayList_0 != null;
		}
	}
}
