using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Script
{
	/// <summary>
	///       string list , would not contains empty , null or same text, ignore case.
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class MyStringList : CollectionBase
	{
		public string this[int index] => (string)base.List[index];

		public int Add(string item)
		{
			if (item == null || item.Length == 0)
			{
				return -1;
			}
			if (IndexOf(item) >= 0)
			{
				return -1;
			}
			return base.List.Add(item);
		}

		public bool Contains(string item)
		{
			return IndexOf(item) >= 0;
		}

		public MyStringList Clone()
		{
			MyStringList myStringList = new MyStringList();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string value = (string)enumerator.Current;
					myStringList.List.Add(value);
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
			return myStringList;
		}

		public int IndexOf(string item)
		{
			int num = 0;
			while (true)
			{
				if (num < base.List.Count)
				{
					if (string.Compare((string)base.List[num], item, ignoreCase: true) == 0)
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
	}
}
