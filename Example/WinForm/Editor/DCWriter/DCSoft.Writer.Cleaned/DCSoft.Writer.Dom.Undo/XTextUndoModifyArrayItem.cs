using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Threading;

namespace DCSoft.Writer.Dom.Undo
{
	internal class XTextUndoModifyArrayItem : XTextUndoBase
	{
		private GEnum9 genum9_0 = GEnum9.const_2;

		private IList ilist_0 = null;

		private object object_0 = null;

		private object object_1 = null;

		private int int_0 = -1;

		private EventHandler eventHandler_0 = null;

		private EventHandler eventHandler_1 = null;

		public GEnum9 Action
		{
			get
			{
				return genum9_0;
			}
			set
			{
				genum9_0 = value;
			}
		}

		public IList ListInstance
		{
			get
			{
				return ilist_0;
			}
			set
			{
				ilist_0 = value;
			}
		}

		public object OldValue
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		public object NewValue
		{
			get
			{
				return object_1;
			}
			set
			{
				object_1 = value;
			}
		}

		public int Index
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       撤销完成后事件
		///       </summary>
		public event EventHandler AfterUndo
		{
			add
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       重复操作完成后事件
		///       </summary>
		public event EventHandler AfterRedo
		{
			add
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public XTextUndoModifyArrayItem()
		{
		}

		public XTextUndoModifyArrayItem(GEnum9 genum9_1, IList ilist_1, int int_1, object object_2, object object_3)
		{
			genum9_0 = genum9_1;
			ilist_0 = ilist_1;
			int_0 = int_1;
			object_0 = object_2;
			object_1 = object_3;
		}

		public override void Undo(GEventArgs3 args)
		{
			int num = 15;
			if (ilist_0 == null)
			{
				throw new ArgumentNullException("ListInstance");
			}
			switch (Action)
			{
			case GEnum9.const_0:
				if (int_0 >= 0 && int_0 < ilist_0.Count)
				{
					ilist_0.RemoveAt(int_0);
				}
				else
				{
					ilist_0.Remove(object_1);
				}
				break;
			case GEnum9.const_1:
				ilist_0.Insert(int_0, object_0);
				break;
			case GEnum9.const_2:
				if (int_0 >= 0 && int_0 < ilist_0.Count)
				{
					ilist_0[int_0] = object_0;
				}
				break;
			case GEnum9.const_3:
				if (object_1 is IEnumerable)
				{
					int num2 = int_0;
					foreach (object item in (IEnumerable)object_1)
					{
						ilist_0.RemoveAt(num2);
					}
				}
				break;
			case GEnum9.const_4:
				if (object_0 is IEnumerable)
				{
					int num2 = int_0;
					foreach (object item2 in (IEnumerable)object_0)
					{
						ilist_0.Insert(num2, item2);
						num2++;
					}
				}
				break;
			case GEnum9.const_5:
				if (object_0 is IEnumerable)
				{
					int num2 = int_0;
					foreach (object item3 in (IEnumerable)object_0)
					{
						ilist_0[num2] = item3;
						num2++;
					}
				}
				break;
			}
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, EventArgs.Empty);
			}
		}

		public override void Redo(GEventArgs3 args)
		{
			int num = 8;
			if (ilist_0 == null)
			{
				throw new ArgumentNullException("ListInstance");
			}
			switch (Action)
			{
			case GEnum9.const_0:
				ilist_0.Insert(int_0, object_1);
				break;
			case GEnum9.const_1:
				if (object_0 != null)
				{
					if (int_0 >= 0 && int_0 < ilist_0.Count)
					{
						ilist_0.RemoveAt(int_0);
					}
					else
					{
						ilist_0.Remove(object_0);
					}
				}
				break;
			case GEnum9.const_2:
				if (int_0 >= 0 && int_0 < ilist_0.Count)
				{
					ilist_0[int_0] = object_1;
				}
				break;
			case GEnum9.const_3:
				if (object_0 is IEnumerable)
				{
					int num2 = int_0;
					foreach (object item in (IEnumerable)object_0)
					{
						ilist_0.Insert(num2, item);
						num2++;
					}
				}
				break;
			case GEnum9.const_4:
				if (object_1 is IEnumerable)
				{
					int num2 = int_0;
					foreach (object item2 in (IEnumerable)object_1)
					{
						ilist_0.RemoveAt(num2);
					}
				}
				break;
			case GEnum9.const_5:
				if (object_1 is IEnumerable)
				{
					int num2 = int_0;
					foreach (object item3 in (IEnumerable)object_1)
					{
						ilist_0[num2] = item3;
						num2++;
					}
				}
				break;
			}
			if (eventHandler_1 != null)
			{
				eventHandler_1(this, EventArgs.Empty);
			}
		}
	}
}
