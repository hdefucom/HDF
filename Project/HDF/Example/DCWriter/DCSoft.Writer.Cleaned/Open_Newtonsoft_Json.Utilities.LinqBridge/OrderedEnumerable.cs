using Open_Newtonsoft_Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities.LinqBridge
{
	[ComVisible(false)]
	internal sealed class OrderedEnumerable<T, K> : IOrderedEnumerable<T>
	{
		private readonly IEnumerable<T> _source;

		private readonly List<Comparison<T>> _comparisons;

		public OrderedEnumerable(IEnumerable<T> source, Func<T, K> keySelector, IComparer<K> comparer, bool descending)
			: this(source, (List<Comparison<T>>)null, keySelector, comparer, descending)
		{
		}

		private OrderedEnumerable(IEnumerable<T> source, List<Comparison<T>> comparisons, Func<T, K> keySelector, IComparer<K> comparer, bool descending)
		{
			int num = 13;
			
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (keySelector == null)
			{
				throw new ArgumentNullException("keySelector");
			}
			_source = source;
			comparer = (comparer ?? Comparer<K>.Default);
			if (comparisons == null)
			{
				comparisons = new List<Comparison<T>>(4);
			}
			comparisons.Add((T gparam_0, T gparam_1) => ((!descending) ? 1 : (-1)) * comparer.Compare(keySelector(gparam_0), keySelector(gparam_1)));
			_comparisons = comparisons;
		}

		public IOrderedEnumerable<T> CreateOrderedEnumerable<KK>(Func<T, KK> keySelector, IComparer<KK> comparer, bool descending)
		{
			return new OrderedEnumerable<T, KK>(_source, _comparisons, keySelector, comparer, descending);
		}

		public IEnumerator<T> GetEnumerator()
		{
			List<Tuple<T, int>> list = Enumerable.ToList(Enumerable.Select(_source, TagPosition));
			list.Sort(delegate(Tuple<T, int> tuple_0, Tuple<T, int> tuple_1)
			{
				List<Comparison<T>> comparisons = _comparisons;
				int num = 0;
				int num2;
				while (true)
				{
					if (num >= comparisons.Count)
					{
						return tuple_0.Second.CompareTo(tuple_1.Second);
					}
					num2 = comparisons[num](tuple_0.First, tuple_1.First);
					if (num2 != 0)
					{
						break;
					}
					num++;
				}
				return num2;
			});
			return Enumerable.Select(list, GetFirst).GetEnumerator();
		}

		/// <remarks>
		///       See <a href="http://code.google.com/p/linqbridge/issues/detail?id=11">issue #11</a>
		///       for why this method is needed and cannot be expressed as a 
		///       lambda at the call site.
		///       </remarks>
		private static Tuple<T, int> TagPosition(T gparam_0, int int_0)
		{
			return new Tuple<T, int>(gparam_0, int_0);
		}

		/// <remarks>
		///       See <a href="http://code.google.com/p/linqbridge/issues/detail?id=11">issue #11</a>
		///       for why this method is needed and cannot be expressed as a 
		///       lambda at the call site.
		///       </remarks>
		private static T GetFirst(Tuple<T, int> tuple_0)
		{
			return tuple_0.First;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
