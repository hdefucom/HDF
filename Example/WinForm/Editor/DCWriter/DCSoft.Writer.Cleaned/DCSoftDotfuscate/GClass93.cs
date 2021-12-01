using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass93 : IDictionary
	{
		private sealed class Class80 : IDictionaryEnumerator
		{
			internal enum Enum8
			{
				const_0,
				const_1,
				const_2
			}

			private GClass93 gclass93_0;

			private int int_0;

			private object object_0;

			private Enum8 enum8_0;

			private ArrayList arrayList_0;

			private object object_1;

			private int int_1;

			public object Current
			{
				get
				{
					int num = 0;
					if (object_0 == null)
					{
						throw new InvalidOperationException("Enumeration has either not started or has already finished.");
					}
					if (enum8_0 == Enum8.const_0)
					{
						return object_0;
					}
					if (enum8_0 == Enum8.const_1)
					{
						return object_1;
					}
					return new DictionaryEntry(object_0, object_1);
				}
			}

			public object Key
			{
				get
				{
					int num = 3;
					if (object_0 == null)
					{
						throw new InvalidOperationException("Enumeration has either not started or has already finished.");
					}
					return object_0;
				}
			}

			public object Value
			{
				get
				{
					int num = 9;
					if (object_0 == null)
					{
						throw new InvalidOperationException("Enumeration has either not started or has already finished.");
					}
					return object_1;
				}
			}

			public DictionaryEntry Entry
			{
				get
				{
					int num = 0;
					if (object_0 == null)
					{
						throw new InvalidOperationException("Enumeration has either not started or has already finished.");
					}
					return new DictionaryEntry(object_0, object_1);
				}
			}

			internal Class80()
			{
				int_0 = 0;
				object_0 = null;
				object_1 = null;
			}

			internal Class80(GClass93 gclass93_1, Enum8 enum8_1)
			{
				gclass93_0 = gclass93_1;
				enum8_0 = enum8_1;
				int_1 = gclass93_1.int_0;
				arrayList_0 = gclass93_1.arrayList_0;
				int_0 = 0;
				object_0 = null;
				object_1 = null;
			}

			public bool MoveNext()
			{
				int num = 0;
				if (int_1 != gclass93_0.int_0)
				{
					throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
				if (int_0 < arrayList_0.Count)
				{
					object_0 = arrayList_0[int_0];
					object_1 = gclass93_0[object_0];
					int_0++;
					return true;
				}
				object_0 = null;
				return false;
			}

			public void Reset()
			{
				int num = 5;
				if (int_1 != gclass93_0.int_0)
				{
					throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
				int_0 = 0;
				object_0 = null;
				object_1 = null;
			}
		}

		private sealed class Class81 : ICollection
		{
			private GClass93 gclass93_0;

			public int Count => gclass93_0.Count;

			public object SyncRoot => gclass93_0.SyncRoot;

			public bool IsSynchronized => gclass93_0.IsSynchronized;

			internal Class81()
			{
			}

			internal Class81(GClass93 gclass93_1)
			{
				gclass93_0 = gclass93_1;
			}

			public void CopyTo(Array array, int index)
			{
				gclass93_0.method_0(array, index);
			}

			public override bool Equals(object other)
			{
				if (other is Class81)
				{
					Class81 @class = (Class81)other;
					if (Count == 0 && @class.Count == 0)
					{
						return true;
					}
					if (Count == @class.Count)
					{
						for (int i = 0; i < Count; i++)
						{
							if (gclass93_0.arrayList_0[i] == @class.gclass93_0.arrayList_0[i] || gclass93_0.arrayList_0[i].Equals(@class.gclass93_0.arrayList_0[i]))
							{
								return true;
							}
						}
					}
				}
				return false;
			}

			public IEnumerator GetEnumerator()
			{
				return new Class80(gclass93_0, Class80.Enum8.const_0);
			}

			public override int GetHashCode()
			{
				return gclass93_0.arrayList_0.GetHashCode();
			}

			public override string ToString()
			{
				int num = 16;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("[");
				ArrayList arrayList_ = gclass93_0.arrayList_0;
				for (int i = 0; i < arrayList_.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(arrayList_[i]);
				}
				stringBuilder.Append("]");
				return stringBuilder.ToString();
			}
		}

		private sealed class Class82 : ICollection
		{
			private GClass93 gclass93_0;

			public int Count => gclass93_0.Count;

			public object SyncRoot => gclass93_0.SyncRoot;

			public bool IsSynchronized => gclass93_0.IsSynchronized;

			internal Class82()
			{
			}

			internal Class82(GClass93 gclass93_1)
			{
				gclass93_0 = gclass93_1;
			}

			public void CopyTo(Array array, int index)
			{
				gclass93_0.method_1(array, index);
			}

			public IEnumerator GetEnumerator()
			{
				return new Class80(gclass93_0, Class80.Enum8.const_1);
			}

			public override string ToString()
			{
				int num = 6;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("[");
				IEnumerator enumerator = new Class80(gclass93_0, Class80.Enum8.const_1);
				if (enumerator.MoveNext())
				{
					stringBuilder.Append((enumerator.Current == null) ? "null" : enumerator.Current);
					while (enumerator.MoveNext())
					{
						stringBuilder.Append(", ");
						stringBuilder.Append((enumerator.Current == null) ? "null" : enumerator.Current);
					}
				}
				stringBuilder.Append("]");
				return stringBuilder.ToString();
			}
		}

		private Hashtable hashtable_0;

		private ArrayList arrayList_0;

		private int int_0;

		public int Count => hashtable_0.Count;

		public bool IsReadOnly => hashtable_0.IsReadOnly;

		public object SyncRoot => hashtable_0.SyncRoot;

		public bool IsSynchronized => hashtable_0.IsSynchronized;

		public object this[object object_0]
		{
			get
			{
				return hashtable_0[object_0];
			}
			set
			{
				bool flag = !hashtable_0.Contains(object_0);
				hashtable_0[object_0] = value;
				if (flag)
				{
					arrayList_0.Add(object_0);
				}
				int_0++;
			}
		}

		public ICollection Keys => new Class81(this);

		public ICollection Values => new Class82(this);

		public bool IsFixedSize => hashtable_0.IsFixedSize;

		public GClass93()
			: this(-1)
		{
		}

		public GClass93(int int_1)
		{
			hashtable_0 = new Hashtable();
			arrayList_0 = new ArrayList();
			if (int_1 < 0)
			{
				hashtable_0 = new Hashtable();
				arrayList_0 = new ArrayList();
			}
			else
			{
				hashtable_0 = new Hashtable(int_1);
				arrayList_0 = new ArrayList(int_1);
			}
			int_0 = 0;
		}

		public void Add(object object_0, object value)
		{
			hashtable_0.Add(object_0, value);
			arrayList_0.Add(object_0);
			int_0++;
		}

		public void Clear()
		{
			hashtable_0.Clear();
			arrayList_0.Clear();
			int_0++;
		}

		public bool Contains(object object_0)
		{
			return hashtable_0.Contains(object_0);
		}

		private void method_0(Array array_0, int int_1)
		{
			int count = arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				array_0.SetValue(arrayList_0[i], int_1++);
			}
		}

		public void CopyTo(Array array, int index)
		{
			int count = arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				DictionaryEntry dictionaryEntry = new DictionaryEntry(arrayList_0[i], hashtable_0[arrayList_0[i]]);
				array.SetValue(dictionaryEntry, index++);
			}
		}

		private void method_1(Array array_0, int int_1)
		{
			int count = arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				array_0.SetValue(hashtable_0[arrayList_0[i]], int_1++);
			}
		}

		public IDictionaryEnumerator GetEnumerator()
		{
			return new Class80(this, Class80.Enum8.const_2);
		}

		public void Remove(object object_0)
		{
			hashtable_0.Remove(object_0);
			arrayList_0.Remove(object_0);
			int_0++;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Class80(this, Class80.Enum8.const_2);
		}
	}
}
