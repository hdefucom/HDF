using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       列表的反向遍历器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class ListReverseEnumrable : IEnumerable
	{
		private class Class32 : IEnumerator
		{
			private int int_0 = 0;

			private IList ilist_0 = null;

			public object Current
			{
				get
				{
					int num = 18;
					if (int_0 < 0 || int_0 >= ilist_0.Count)
					{
						throw new IndexOutOfRangeException("index:" + int_0 + ",count:" + ilist_0.Count);
					}
					return ilist_0[int_0];
				}
			}

			public Class32(IList ilist_1)
			{
				ilist_0 = ilist_1;
				int_0 = ilist_1.Count;
			}

			public bool MoveNext()
			{
				int_0--;
				return int_0 >= 0;
			}

			public void Reset()
			{
				int_0 = ilist_0.Count;
			}
		}

		private IList ilist_0;

		public ListReverseEnumrable(IList ilist_1)
		{
			int num = 17;
			ilist_0 = null;
			
			if (ilist_1 == null)
			{
				throw new ArgumentNullException("srcList");
			}
			ilist_0 = ilist_1;
		}

		public IEnumerator GetEnumerator()
		{
			return new Class32(ilist_0);
		}
	}
}
