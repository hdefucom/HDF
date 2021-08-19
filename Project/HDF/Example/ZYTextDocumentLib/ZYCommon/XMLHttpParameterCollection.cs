using System;
using System.Collections;
using System.Data;

namespace ZYCommon
{
	public class XMLHttpParameterCollection : IDataParameterCollection, IList, ICollection, IEnumerable
	{
		private ArrayList myParams = new ArrayList();

		public object this[string parameterName]
		{
			get
			{
				foreach (XMLHttpParameter myParam in myParams)
				{
					if (myParam.ParameterName == parameterName)
					{
						return myParam;
					}
				}
				return null;
			}
			set
			{
			}
		}

		public bool IsReadOnly => false;

		object IList.this[int index]
		{
			get
			{
				return myParams[index];
			}
			set
			{
				myParams[index] = value;
			}
		}

		public bool IsFixedSize => false;

		public bool IsSynchronized => false;

		public int Count => myParams.Count;

		public object SyncRoot => null;

		public void RemoveAt(string parameterName)
		{
			object obj = this[parameterName];
			if (obj != null)
			{
				myParams.Remove(obj);
			}
		}

		public bool Contains(string parameterName)
		{
			return this[parameterName] != null;
		}

		public int IndexOf(string parameterName)
		{
			foreach (XMLHttpParameter myParam in myParams)
			{
				if (myParam.ParameterName == parameterName)
				{
					return myParams.IndexOf(myParam);
				}
			}
			return -1;
		}

		void IList.RemoveAt(int index)
		{
			myParams.RemoveAt(index);
		}

		public void Insert(int index, object obj)
		{
			myParams.Insert(index, obj);
		}

		int IList.IndexOf(object obj)
		{
			return myParams.IndexOf(obj);
		}

		public void Remove(object obj)
		{
			myParams.Remove(obj);
		}

		bool IList.Contains(object obj)
		{
			return myParams.Contains(obj);
		}

		public void Clear()
		{
			myParams.Clear();
		}

		public int Add(object obj)
		{
			myParams.Add(obj);
			return 0;
		}

		public void CopyTo(Array array, int index)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return myParams.GetEnumerator();
		}
	}
}
