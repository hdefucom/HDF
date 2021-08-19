using Open_Newtonsoft_Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Open_Newtonsoft_Json.Utilities.LinqBridge
{
	/// <summary>
	///       Represents a collection of keys each mapped to one or more values.
	///       </summary>
	[ComVisible(false)]
	internal sealed class Lookup<TKey, TElement> : ILookup<TKey, TElement>
	{
		[CompilerGenerated]
		private sealed class _003CApplyResultSelector_003Ed__0<TResult> : IEnumerable<TResult>, IEnumerator<TResult>
		{
			private TResult _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public Lookup<TKey, TElement> _003C_003E4__this;

			public Func<TKey, IEnumerable<TElement>, TResult> resultSelector;

			public Func<TKey, IEnumerable<TElement>, TResult> _003C_003E3__resultSelector;

			public KeyValuePair<TKey, IGrouping<TKey, TElement>> _003Cpair_003E5__1;

			public Dictionary<TKey, IGrouping<TKey, TElement>>.Enumerator _003C_003E7__wrap2;

			TResult IEnumerator<TResult>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
			{
				_003CApplyResultSelector_003Ed__0<TResult> _003CApplyResultSelector_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CApplyResultSelector_003Ed__ = this;
				}
				else
				{
					_003CApplyResultSelector_003Ed__ = new _003CApplyResultSelector_003Ed__0<TResult>(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				_003CApplyResultSelector_003Ed__.resultSelector = _003C_003E3__resultSelector;
				return _003CApplyResultSelector_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TResult>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = 0;
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						if (resultSelector == null)
						{
							throw new ArgumentNullException("resultSelector");
						}
						_003C_003E7__wrap2 = _003C_003E4__this._map.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0067;
					case 2:
						_003C_003E1__state = 1;
						goto IL_0067;
					default:
						{
							return false;
						}
						IL_0067:
						if (_003C_003E7__wrap2.MoveNext())
						{
							_003Cpair_003E5__1 = _003C_003E7__wrap2.Current;
							Func<TKey, IEnumerable<TElement>, TResult> func = resultSelector;
							KeyValuePair<TKey, IGrouping<TKey, TElement>> keyValuePair = _003Cpair_003E5__1;
							TKey key = keyValuePair.Key;
							keyValuePair = _003Cpair_003E5__1;
							_003C_003E2__current = func(key, keyValuePair.Value);
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003Em__Finally3();
						goto default;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (_003C_003E1__state)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						_003C_003Em__Finally3();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CApplyResultSelector_003Ed__0(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally3()
			{
				_003C_003E1__state = -1;
				((IDisposable)_003C_003E7__wrap2).Dispose();
			}
		}

		private readonly Dictionary<TKey, IGrouping<TKey, TElement>> _map;

		/// <summary>
		///       Gets the number of key/value collection pairs in the <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.Lookup`2" />.
		///       </summary>
		public int Count => _map.Count;

		/// <summary>
		///       Gets the collection of values indexed by the specified key.
		///       </summary>
		public IEnumerable<TElement> this[TKey gparam_0]
		{
			get
			{
				IGrouping<TKey, TElement> value;
				return _map.TryGetValue(gparam_0, out value) ? value : Enumerable.Empty<TElement>();
			}
		}

		internal Lookup(IEqualityComparer<TKey> comparer)
		{
			_map = new Dictionary<TKey, IGrouping<TKey, TElement>>(comparer);
		}

		internal void Add(IGrouping<TKey, TElement> item)
		{
			_map.Add(item.Key, item);
		}

		internal IEnumerable<TElement> Find(TKey gparam_0)
		{
			IGrouping<TKey, TElement> value;
			return _map.TryGetValue(gparam_0, out value) ? value : null;
		}

		/// <summary>
		///       Determines whether a specified key is in the <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.Lookup`2" />.
		///       </summary>
		public bool Contains(TKey gparam_0)
		{
			return _map.ContainsKey(gparam_0);
		}

		/// <summary>
		///       Applies a transform function to each key and its associated 
		///       values and returns the results.
		///       </summary>
		public IEnumerable<TResult> ApplyResultSelector<TResult>(Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
		{
			_003CApplyResultSelector_003Ed__0<TResult> _003CApplyResultSelector_003Ed__ = new _003CApplyResultSelector_003Ed__0<TResult>(-2);
			_003CApplyResultSelector_003Ed__._003C_003E4__this = this;
			_003CApplyResultSelector_003Ed__._003C_003E3__resultSelector = resultSelector;
			return _003CApplyResultSelector_003Ed__;
		}

		/// <summary>
		///       Returns a generic enumerator that iterates through the <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.Lookup`2" />.
		///       </summary>
		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
		{
			return _map.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
