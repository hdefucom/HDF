using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	[ComVisible(false)]
	public class XHashtable : IDictionary
	{
		private ArrayList myKeys = new ArrayList();

		private Hashtable myTable = new Hashtable();

		public bool IsFixedSize => myTable.IsFixedSize;

		public bool IsReadOnly => myTable.IsReadOnly;

		public ICollection Keys => myKeys;

		public ICollection Values
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object myKey in myKeys)
				{
					arrayList.Add(myTable[myKey]);
				}
				return arrayList;
			}
		}

		public object this[object object_0]
		{
			get
			{
				return myTable[object_0];
			}
			set
			{
				myTable[object_0] = value;
				foreach (object myKey in myKeys)
				{
					if (myKey.Equals(object_0))
					{
						return;
					}
				}
				myKeys.Add(object_0);
			}
		}

		public int Count => myTable.Count;

		public bool IsSynchronized => myTable.IsSynchronized;

		public object SyncRoot => myTable.SyncRoot;

		public void Add(object object_0, object Value)
		{
			myTable.Add(object_0, Value);
			foreach (object myKey in myKeys)
			{
				if (myKey.Equals(object_0))
				{
					return;
				}
			}
			myKeys.Add(object_0);
		}

		public void Clear()
		{
			myTable.Clear();
			myKeys.Clear();
		}

		public bool Contains(object object_0)
		{
			return myTable.Contains(object_0);
		}

		public IDictionaryEnumerator GetEnumerator()
		{
			return myTable.GetEnumerator();
		}

		public void Remove(object object_0)
		{
			myKeys.Remove(object_0);
			myTable.Remove(object_0);
		}

		public void CopyTo(Array array, int index)
		{
			myTable.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return myTable.GetEnumerator();
		}
	}
}
