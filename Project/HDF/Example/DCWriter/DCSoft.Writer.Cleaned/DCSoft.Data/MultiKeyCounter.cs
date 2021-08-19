using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	[ComVisible(false)]
	public class MultiKeyCounter
	{
		private ArrayList myKeys = new ArrayList();

		private int[] myIndexs = null;

		private object[] myValue = null;

		public int[] Indexs
		{
			get
			{
				return myIndexs;
			}
			set
			{
				myIndexs = value;
			}
		}

		public object[] Value => myValue;

		public void AddKeys(object[] keys)
		{
			myKeys.Add(keys);
		}

		public void Reset()
		{
			myIndexs = new int[myKeys.Count];
			myValue = new object[myKeys.Count];
			for (int i = 0; i < myKeys.Count; i++)
			{
				object[] array = (object[])myKeys[i];
				myValue[i] = array[0];
			}
		}

		public bool Increment()
		{
			int num = myKeys.Count - 1;
			while (num >= 0)
			{
				object[] array = (object[])myKeys[num];
				myIndexs[num]++;
				if (myIndexs[num] < array.Length)
				{
					break;
				}
				if (num != 0)
				{
					myIndexs[num] = 0;
					num--;
					continue;
				}
				return false;
			}
			for (num = 0; num < myKeys.Count; num++)
			{
				object[] array = (object[])myKeys[num];
				myValue[num] = array[myIndexs[num]];
			}
			return true;
		}
	}
}
