#define DEBUG
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
	///       Provides a set of static (Shared in Visual Basic) methods for 
	///       querying objects that implement <see cref="T:System.Collections.Generic.IEnumerable`1" />.
	///       </summary>
	[ComVisible(false)]
	internal static class Enumerable
	{
		[ComVisible(false)]
		private static class Futures<T>
		{
			public static readonly Func<T> Default = () => default(T);

			public static readonly Func<T> Undefined = delegate
			{
				throw new InvalidOperationException();
			};
		}

		[ComVisible(false)]
		private static class Sequence<T>
		{
			public static readonly IEnumerable<T> Empty = new T[0];
		}

		[ComVisible(false)]
		private sealed class Grouping<K, V> : List<V>, IGrouping<K, V>
		{
			public K Key
			{
				get;
				private set;
			}

			internal Grouping(K gparam_0)
			{
				Key = gparam_0;
			}
		}

		[CompilerGenerated]
		private sealed class _003CCastYield_003Ed__0<TResult> : IEnumerable<TResult>, IEnumerator<TResult>
		{
			private TResult _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable source;

			public IEnumerable _003C_003E3__source;

			public object _003Citem_003E5__1;

			public IEnumerator _003C_003E7__wrap2;

			public IDisposable _003C_003E7__wrap3;

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
				_003CCastYield_003Ed__0<TResult> _003CCastYield_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CCastYield_003Ed__ = this;
				}
				else
				{
					_003CCastYield_003Ed__ = new _003CCastYield_003Ed__0<TResult>(0);
				}
				_003CCastYield_003Ed__.source = _003C_003E3__source;
				return _003CCastYield_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TResult>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003C_003E7__wrap2 = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0043;
					case 2:
						_003C_003E1__state = 1;
						goto IL_0043;
					default:
						{
							return false;
						}
						IL_0043:
						if (_003C_003E7__wrap2.MoveNext())
						{
							_003Citem_003E5__1 = _003C_003E7__wrap2.Current;
							_003C_003E2__current = (TResult)_003Citem_003E5__1;
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003Em__Finally4();
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
						_003C_003Em__Finally4();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CCastYield_003Ed__0(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally4()
			{
				_003C_003E1__state = -1;
				_003C_003E7__wrap3 = (_003C_003E7__wrap2 as IDisposable);
				if (_003C_003E7__wrap3 != null)
				{
					_003C_003E7__wrap3.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003COfTypeYield_003Ed__7<TResult> : IEnumerable<TResult>, IEnumerator<TResult>
		{
			private TResult _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable source;

			public IEnumerable _003C_003E3__source;

			public object _003Citem_003E5__8;

			public IEnumerator _003C_003E7__wrap9;

			public IDisposable _003C_003E7__wrapa;

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
				_003COfTypeYield_003Ed__7<TResult> _003COfTypeYield_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003COfTypeYield_003Ed__ = this;
				}
				else
				{
					_003COfTypeYield_003Ed__ = new _003COfTypeYield_003Ed__7<TResult>(0);
				}
				_003COfTypeYield_003Ed__.source = _003C_003E3__source;
				return _003COfTypeYield_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TResult>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003C_003E7__wrap9 = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0069;
					case 2:
						{
							_003C_003E1__state = 1;
							goto IL_0069;
						}
						IL_0069:
						while (_003C_003E7__wrap9.MoveNext())
						{
							_003Citem_003E5__8 = _003C_003E7__wrap9.Current;
							if (_003Citem_003E5__8 is TResult)
							{
								_003C_003E2__current = (TResult)_003Citem_003E5__8;
								_003C_003E1__state = 2;
								return true;
							}
						}
						_003C_003Em__Finallyb();
						break;
					}
					return false;
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
						_003C_003Em__Finallyb();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003COfTypeYield_003Ed__7(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finallyb()
			{
				_003C_003E1__state = -1;
				_003C_003E7__wrapa = (_003C_003E7__wrap9 as IDisposable);
				if (_003C_003E7__wrapa != null)
				{
					_003C_003E7__wrapa.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CRangeYield_003Ed__e : IEnumerable<int>, IEnumerator<int>
		{
			private int _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public int start;

			public int _003C_003E3__start;

			public long long_0;

			public long _003C_003E3__end;

			public int _003Ci_003E5__f;

			int IEnumerator<int>.Current
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
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				_003CRangeYield_003Ed__e _003CRangeYield_003Ed__e;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CRangeYield_003Ed__e = this;
				}
				else
				{
					_003CRangeYield_003Ed__e = new _003CRangeYield_003Ed__e(0);
				}
				_003CRangeYield_003Ed__e.start = _003C_003E3__start;
				_003CRangeYield_003Ed__e.long_0 = _003C_003E3__end;
				return _003CRangeYield_003Ed__e;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003Ci_003E5__f = start;
					goto IL_0041;
				case 1:
					_003C_003E1__state = -1;
					_003Ci_003E5__f++;
					goto IL_0041;
				default:
					{
						return false;
					}
					IL_0041:
					if (_003Ci_003E5__f < long_0)
					{
						_003C_003E2__current = _003Ci_003E5__f;
						_003C_003E1__state = 1;
						return true;
					}
					goto default;
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
			}

			[DebuggerHidden]
			public _003CRangeYield_003Ed__e(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CompilerGenerated]
		private sealed class _003CRepeatYield_003Ed__12<TResult> : IEnumerable<TResult>, IEnumerator<TResult>
		{
			private TResult _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public TResult element;

			public TResult _003C_003E3__element;

			public int count;

			public int _003C_003E3__count;

			public int _003Ci_003E5__13;

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
				_003CRepeatYield_003Ed__12<TResult> _003CRepeatYield_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CRepeatYield_003Ed__ = this;
				}
				else
				{
					_003CRepeatYield_003Ed__ = new _003CRepeatYield_003Ed__12<TResult>(0);
				}
				_003CRepeatYield_003Ed__.element = _003C_003E3__element;
				_003CRepeatYield_003Ed__.count = _003C_003E3__count;
				return _003CRepeatYield_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TResult>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003Ci_003E5__13 = 0;
					goto IL_003c;
				case 1:
					_003C_003E1__state = -1;
					_003Ci_003E5__13++;
					goto IL_003c;
				default:
					{
						return false;
					}
					IL_003c:
					if (_003Ci_003E5__13 < count)
					{
						_003C_003E2__current = element;
						_003C_003E1__state = 1;
						return true;
					}
					goto default;
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
			}

			[DebuggerHidden]
			public _003CRepeatYield_003Ed__12(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CompilerGenerated]
		private sealed class _003CWhereYield_003Ed__19<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
		{
			private TSource _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public Func<TSource, int, bool> predicate;

			public Func<TSource, int, bool> _003C_003E3__predicate;

			public int _003Ci_003E5__1a;

			public TSource _003Citem_003E5__1b;

			public IEnumerator<TSource> _003C_003E7__wrap1c;

			TSource IEnumerator<TSource>.Current
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
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				_003CWhereYield_003Ed__19<TSource> _003CWhereYield_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CWhereYield_003Ed__ = this;
				}
				else
				{
					_003CWhereYield_003Ed__ = new _003CWhereYield_003Ed__19<TSource>(0);
				}
				_003CWhereYield_003Ed__.source = _003C_003E3__source;
				_003CWhereYield_003Ed__.predicate = _003C_003E3__predicate;
				return _003CWhereYield_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TSource>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003Ci_003E5__1a = 0;
						_003C_003E7__wrap1c = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0084;
					case 2:
						{
							_003C_003E1__state = 1;
							goto IL_0084;
						}
						IL_0084:
						while (_003C_003E7__wrap1c.MoveNext())
						{
							_003Citem_003E5__1b = _003C_003E7__wrap1c.Current;
							if (predicate(_003Citem_003E5__1b, _003Ci_003E5__1a++))
							{
								_003C_003E2__current = _003Citem_003E5__1b;
								_003C_003E1__state = 2;
								return true;
							}
						}
						_003C_003Em__Finally1d();
						break;
					}
					return false;
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
						_003C_003Em__Finally1d();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CWhereYield_003Ed__19(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally1d()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap1c != null)
				{
					_003C_003E7__wrap1c.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CSelectYield_003Ed__23<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult>
		{
			private TResult _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public Func<TSource, int, TResult> selector;

			public Func<TSource, int, TResult> _003C_003E3__selector;

			public int _003Ci_003E5__24;

			public TSource _003Citem_003E5__25;

			public IEnumerator<TSource> _003C_003E7__wrap26;

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
				_003CSelectYield_003Ed__23<TSource, TResult> _003CSelectYield_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CSelectYield_003Ed__ = this;
				}
				else
				{
					_003CSelectYield_003Ed__ = new _003CSelectYield_003Ed__23<TSource, TResult>(0);
				}
				_003CSelectYield_003Ed__.source = _003C_003E3__source;
				_003CSelectYield_003Ed__.selector = _003C_003E3__selector;
				return _003CSelectYield_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TResult>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003Ci_003E5__24 = 0;
						_003C_003E7__wrap26 = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_004a;
					case 2:
						_003C_003E1__state = 1;
						goto IL_004a;
					default:
						{
							return false;
						}
						IL_004a:
						if (_003C_003E7__wrap26.MoveNext())
						{
							_003Citem_003E5__25 = _003C_003E7__wrap26.Current;
							_003C_003E2__current = selector(_003Citem_003E5__25, _003Ci_003E5__24++);
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003Em__Finally27();
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
						_003C_003Em__Finally27();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CSelectYield_003Ed__23(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally27()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap26 != null)
				{
					_003C_003E7__wrap26.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CSelectManyYield_003Ed__31<TSource, TCollection, TResult> : IEnumerable<TResult>, IEnumerator<TResult>
		{
			private TResult _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public Func<TSource, int, IEnumerable<TCollection>> collectionSelector;

			public Func<TSource, int, IEnumerable<TCollection>> _003C_003E3__collectionSelector;

			public Func<TSource, TCollection, TResult> resultSelector;

			public Func<TSource, TCollection, TResult> _003C_003E3__resultSelector;

			public int _003Ci_003E5__32;

			public TSource _003Citem_003E5__33;

			public TCollection _003Csubitem_003E5__34;

			public IEnumerator<TSource> _003C_003E7__wrap35;

			public IEnumerator<TCollection> _003C_003E7__wrap37;

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
				_003CSelectManyYield_003Ed__31<TSource, TCollection, TResult> _003CSelectManyYield_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CSelectManyYield_003Ed__ = this;
				}
				else
				{
					_003CSelectManyYield_003Ed__ = new _003CSelectManyYield_003Ed__31<TSource, TCollection, TResult>(0);
				}
				_003CSelectManyYield_003Ed__.source = _003C_003E3__source;
				_003CSelectManyYield_003Ed__.collectionSelector = _003C_003E3__collectionSelector;
				_003CSelectManyYield_003Ed__.resultSelector = _003C_003E3__resultSelector;
				return _003CSelectManyYield_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TResult>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num = _003C_003E1__state;
					if (num == 0)
					{
						_003C_003E1__state = -1;
						_003Ci_003E5__32 = 0;
						_003C_003E7__wrap35 = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_009d;
					}
					if (num == 3)
					{
						_003C_003E1__state = 2;
						goto IL_008a;
					}
					goto IL_00b0;
					IL_009d:
					if (_003C_003E7__wrap35.MoveNext())
					{
						_003Citem_003E5__33 = _003C_003E7__wrap35.Current;
						_003C_003E7__wrap37 = collectionSelector(_003Citem_003E5__33, _003Ci_003E5__32++).GetEnumerator();
						_003C_003E1__state = 2;
						goto IL_008a;
					}
					_003C_003Em__Finally36();
					goto IL_00b0;
					IL_00b0:
					return false;
					IL_008a:
					if (_003C_003E7__wrap37.MoveNext())
					{
						_003Csubitem_003E5__34 = _003C_003E7__wrap37.Current;
						_003C_003E2__current = resultSelector(_003Citem_003E5__33, _003Csubitem_003E5__34);
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally38();
					goto IL_009d;
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
				case 3:
					try
					{
						switch (_003C_003E1__state)
						{
						case 2:
						case 3:
							try
							{
							}
							finally
							{
								_003C_003Em__Finally38();
							}
							break;
						}
					}
					finally
					{
						_003C_003Em__Finally36();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CSelectManyYield_003Ed__31(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally36()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap35 != null)
				{
					_003C_003E7__wrap35.Dispose();
				}
			}

			private void _003C_003Em__Finally38()
			{
				_003C_003E1__state = 1;
				if (_003C_003E7__wrap37 != null)
				{
					_003C_003E7__wrap37.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CTakeWhileYield_003Ed__3e<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
		{
			private TSource _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public Func<TSource, int, bool> predicate;

			public Func<TSource, int, bool> _003C_003E3__predicate;

			public int _003Ci_003E5__3f;

			public TSource _003Citem_003E5__40;

			public IEnumerator<TSource> _003C_003E7__wrap41;

			TSource IEnumerator<TSource>.Current
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
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				_003CTakeWhileYield_003Ed__3e<TSource> _003CTakeWhileYield_003Ed__3e;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CTakeWhileYield_003Ed__3e = this;
				}
				else
				{
					_003CTakeWhileYield_003Ed__3e = new _003CTakeWhileYield_003Ed__3e<TSource>(0);
				}
				_003CTakeWhileYield_003Ed__3e.source = _003C_003E3__source;
				_003CTakeWhileYield_003Ed__3e.predicate = _003C_003E3__predicate;
				return _003CTakeWhileYield_003Ed__3e;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TSource>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003Ci_003E5__3f = 0;
						_003C_003E7__wrap41 = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_004d;
					case 2:
						{
							_003C_003E1__state = 1;
							goto IL_004d;
						}
						IL_004d:
						if (_003C_003E7__wrap41.MoveNext())
						{
							_003Citem_003E5__40 = _003C_003E7__wrap41.Current;
							if (predicate(_003Citem_003E5__40, _003Ci_003E5__3f++))
							{
								_003C_003E2__current = _003Citem_003E5__40;
								_003C_003E1__state = 2;
								return true;
							}
						}
						_003C_003Em__Finally42();
						break;
					}
					return false;
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
						_003C_003Em__Finally42();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CTakeWhileYield_003Ed__3e(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally42()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap41 != null)
				{
					_003C_003E7__wrap41.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CReverseYield_003Ed__4c<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
		{
			private TSource _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public Stack<TSource> _003Cstack_003E5__4d;

			public TSource _003Citem_003E5__4e;

			public Stack<TSource>.Enumerator _003C_003E7__wrap4f;

			TSource IEnumerator<TSource>.Current
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
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				_003CReverseYield_003Ed__4c<TSource> _003CReverseYield_003Ed__4c;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CReverseYield_003Ed__4c = this;
				}
				else
				{
					_003CReverseYield_003Ed__4c = new _003CReverseYield_003Ed__4c<TSource>(0);
				}
				_003CReverseYield_003Ed__4c.source = _003C_003E3__source;
				return _003CReverseYield_003Ed__4c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TSource>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num = _003C_003E1__state;
					if (num != 0)
					{
						if (num != 3)
						{
							goto IL_0090;
						}
						_003C_003E1__state = 2;
					}
					else
					{
						_003C_003E1__state = -1;
						_003Cstack_003E5__4d = new Stack<TSource>();
						foreach (TSource item in source)
						{
							_003Cstack_003E5__4d.Push(item);
						}
						_003C_003E7__wrap4f = _003Cstack_003E5__4d.GetEnumerator();
						_003C_003E1__state = 2;
					}
					if (_003C_003E7__wrap4f.MoveNext())
					{
						_003Citem_003E5__4e = _003C_003E7__wrap4f.Current;
						_003C_003E2__current = _003Citem_003E5__4e;
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally50();
					goto IL_0090;
					IL_0090:
					return false;
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
				case 2:
				case 3:
					try
					{
					}
					finally
					{
						_003C_003Em__Finally50();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CReverseYield_003Ed__4c(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally50()
			{
				_003C_003E1__state = -1;
				((IDisposable)_003C_003E7__wrap4f).Dispose();
			}
		}

		[CompilerGenerated]
		private sealed class _003CSkipWhileYield_003Ed__5c<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
		{
			private TSource _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public Func<TSource, int, bool> predicate;

			public Func<TSource, int, bool> _003C_003E3__predicate;

			public IEnumerator<TSource> _003Ce_003E5__5d;

			TSource IEnumerator<TSource>.Current
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
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				_003CSkipWhileYield_003Ed__5c<TSource> _003CSkipWhileYield_003Ed__5c;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CSkipWhileYield_003Ed__5c = this;
				}
				else
				{
					_003CSkipWhileYield_003Ed__5c = new _003CSkipWhileYield_003Ed__5c<TSource>(0);
				}
				_003CSkipWhileYield_003Ed__5c.source = _003C_003E3__source;
				_003CSkipWhileYield_003Ed__5c.predicate = _003C_003E3__predicate;
				return _003CSkipWhileYield_003Ed__5c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TSource>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
					{
						_003C_003E1__state = -1;
						_003Ce_003E5__5d = source.GetEnumerator();
						_003C_003E1__state = 1;
						int num = 0;
						while (_003Ce_003E5__5d.MoveNext())
						{
							if (!predicate(_003Ce_003E5__5d.Current, num))
							{
								goto end_IL_0008;
							}
							num++;
						}
						((IDisposable)this).Dispose();
						goto default;
					}
					case 2:
						_003C_003E1__state = 1;
						if (_003Ce_003E5__5d.MoveNext())
						{
							break;
						}
						_003C_003Em__Finally5e();
						goto default;
					default:
						{
							return false;
						}
						end_IL_0008:
						break;
					}
					_003C_003E2__current = _003Ce_003E5__5d.Current;
					_003C_003E1__state = 2;
					return true;
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
						_003C_003Em__Finally5e();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CSkipWhileYield_003Ed__5c(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally5e()
			{
				_003C_003E1__state = -1;
				if (_003Ce_003E5__5d != null)
				{
					_003Ce_003E5__5d.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CConcatYield_003Ed__63<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
		{
			private TSource _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> first;

			public IEnumerable<TSource> _003C_003E3__first;

			public IEnumerable<TSource> second;

			public IEnumerable<TSource> _003C_003E3__second;

			public TSource _003Citem_003E5__64;

			public TSource _003Citem_003E5__65;

			public IEnumerator<TSource> _003C_003E7__wrap66;

			public IEnumerator<TSource> _003C_003E7__wrap68;

			TSource IEnumerator<TSource>.Current
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
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				_003CConcatYield_003Ed__63<TSource> _003CConcatYield_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CConcatYield_003Ed__ = this;
				}
				else
				{
					_003CConcatYield_003Ed__ = new _003CConcatYield_003Ed__63<TSource>(0);
				}
				_003CConcatYield_003Ed__.first = _003C_003E3__first;
				_003CConcatYield_003Ed__.second = _003C_003E3__second;
				return _003CConcatYield_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TSource>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003C_003E7__wrap66 = first.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_004e;
					case 2:
						_003C_003E1__state = 1;
						goto IL_004e;
					case 4:
						_003C_003E1__state = 3;
						goto IL_00aa;
					default:
						{
							return false;
						}
						IL_004e:
						if (_003C_003E7__wrap66.MoveNext())
						{
							_003Citem_003E5__64 = _003C_003E7__wrap66.Current;
							_003C_003E2__current = _003Citem_003E5__64;
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003Em__Finally67();
						_003C_003E7__wrap68 = second.GetEnumerator();
						_003C_003E1__state = 3;
						goto IL_00aa;
						IL_00aa:
						if (_003C_003E7__wrap68.MoveNext())
						{
							_003Citem_003E5__65 = _003C_003E7__wrap68.Current;
							_003C_003E2__current = _003Citem_003E5__65;
							_003C_003E1__state = 4;
							return true;
						}
						_003C_003Em__Finally69();
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
						_003C_003Em__Finally67();
					}
					break;
				}
				switch (_003C_003E1__state)
				{
				case 3:
				case 4:
					try
					{
					}
					finally
					{
						_003C_003Em__Finally69();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CConcatYield_003Ed__63(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally67()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap66 != null)
				{
					_003C_003E7__wrap66.Dispose();
				}
			}

			private void _003C_003Em__Finally69()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap68 != null)
				{
					_003C_003E7__wrap68.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CDistinctYield_003Ed__6c<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
		{
			private TSource _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public IEqualityComparer<TSource> comparer;

			public IEqualityComparer<TSource> _003C_003E3__comparer;

			public Dictionary<TSource, object> _003Cset_003E5__6d;

			public bool _003CgotNull_003E5__6e;

			public TSource _003Citem_003E5__6f;

			public IEnumerator<TSource> _003C_003E7__wrap70;

			TSource IEnumerator<TSource>.Current
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
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				_003CDistinctYield_003Ed__6c<TSource> _003CDistinctYield_003Ed__6c;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CDistinctYield_003Ed__6c = this;
				}
				else
				{
					_003CDistinctYield_003Ed__6c = new _003CDistinctYield_003Ed__6c<TSource>(0);
				}
				_003CDistinctYield_003Ed__6c.source = _003C_003E3__source;
				_003CDistinctYield_003Ed__6c.comparer = _003C_003E3__comparer;
				return _003CDistinctYield_003Ed__6c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TSource>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003Cset_003E5__6d = new Dictionary<TSource, object>(comparer);
						_003CgotNull_003E5__6e = false;
						_003C_003E7__wrap70 = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_00a7;
					case 2:
						{
							_003C_003E1__state = 1;
							goto IL_00a7;
						}
						IL_00a7:
						while (_003C_003E7__wrap70.MoveNext())
						{
							_003Citem_003E5__6f = _003C_003E7__wrap70.Current;
							if (_003Citem_003E5__6f == null)
							{
								if (_003CgotNull_003E5__6e)
								{
									continue;
								}
								_003CgotNull_003E5__6e = true;
							}
							else
							{
								if (_003Cset_003E5__6d.ContainsKey(_003Citem_003E5__6f))
								{
									continue;
								}
								_003Cset_003E5__6d.Add(_003Citem_003E5__6f, null);
							}
							_003C_003E2__current = _003Citem_003E5__6f;
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003Em__Finally71();
						break;
					}
					return false;
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
						_003C_003Em__Finally71();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CDistinctYield_003Ed__6c(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally71()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap70 != null)
				{
					_003C_003E7__wrap70.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CDefaultIfEmptyYield_003Ed__7e<TSource> : IEnumerable<TSource>, IEnumerator<TSource>
		{
			private TSource _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			public TSource defaultValue;

			public TSource _003C_003E3__defaultValue;

			public IEnumerator<TSource> _003Ce_003E5__7f;

			TSource IEnumerator<TSource>.Current
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
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				_003CDefaultIfEmptyYield_003Ed__7e<TSource> _003CDefaultIfEmptyYield_003Ed__7e;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CDefaultIfEmptyYield_003Ed__7e = this;
				}
				else
				{
					_003CDefaultIfEmptyYield_003Ed__7e = new _003CDefaultIfEmptyYield_003Ed__7e<TSource>(0);
				}
				_003CDefaultIfEmptyYield_003Ed__7e.source = _003C_003E3__source;
				_003CDefaultIfEmptyYield_003Ed__7e.defaultValue = _003C_003E3__defaultValue;
				return _003CDefaultIfEmptyYield_003Ed__7e;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TSource>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003Ce_003E5__7f = source.GetEnumerator();
						_003C_003E1__state = 1;
						if (!_003Ce_003E5__7f.MoveNext())
						{
							_003C_003E2__current = defaultValue;
							_003C_003E1__state = 2;
							return true;
						}
						break;
					case 2:
						_003C_003E1__state = 1;
						goto IL_007f;
					case 3:
						_003C_003E1__state = 1;
						if (_003Ce_003E5__7f.MoveNext())
						{
							break;
						}
						goto IL_007f;
					default:
						{
							return false;
						}
						IL_007f:
						_003C_003Em__Finally80();
						goto default;
					}
					_003C_003E2__current = _003Ce_003E5__7f.Current;
					_003C_003E1__state = 3;
					return true;
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
				case 3:
					try
					{
					}
					finally
					{
						_003C_003Em__Finally80();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CDefaultIfEmptyYield_003Ed__7e(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally80()
			{
				_003C_003E1__state = -1;
				if (_003Ce_003E5__7f != null)
				{
					_003Ce_003E5__7f.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CRenumerable_003Ed__92<T> : IEnumerable<T>, IEnumerator<T>
		{
			private T _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerator<T> ienumerator_0;

			public IEnumerator<T> _003C_003E3__e;

			T IEnumerator<T>.Current
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
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				_003CRenumerable_003Ed__92<T> _003CRenumerable_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CRenumerable_003Ed__ = this;
				}
				else
				{
					_003CRenumerable_003Ed__ = new _003CRenumerable_003Ed__92<T>(0);
				}
				_003CRenumerable_003Ed__.ienumerator_0 = _003C_003E3__e;
				return _003CRenumerable_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<T>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					Debug.Assert(ienumerator_0 != null);
					break;
				case 1:
					_003C_003E1__state = -1;
					if (ienumerator_0.MoveNext())
					{
						break;
					}
					goto default;
				default:
					return false;
				}
				_003C_003E2__current = ienumerator_0.Current;
				_003C_003E1__state = 1;
				return true;
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
			}

			[DebuggerHidden]
			public _003CRenumerable_003Ed__92(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		/// <summary>
		///       Returns the input typed as <see cref="T:System.Collections.Generic.IEnumerable`1" />.
		///       </summary>
		public static IEnumerable<TSource> AsEnumerable<TSource>(IEnumerable<TSource> source)
		{
			return source;
		}

		/// <summary>
		///       Returns an empty <see cref="T:System.Collections.Generic.IEnumerable`1" /> that has the 
		///       specified type argument.
		///       </summary>
		public static IEnumerable<TResult> Empty<TResult>()
		{
			return Sequence<TResult>.Empty;
		}

		/// <summary>
		///       Converts the elements of an <see cref="T:System.Collections.IEnumerable" /> to the 
		///       specified type.
		///       </summary>
		public static IEnumerable<TResult> Cast<TResult>(IEnumerable source)
		{
			CheckNotNull(source, "source");
			return CastYield<TResult>(source);
		}

		private static IEnumerable<TResult> CastYield<TResult>(IEnumerable source)
		{
			_003CCastYield_003Ed__0<TResult> _003CCastYield_003Ed__ = new _003CCastYield_003Ed__0<TResult>(-2);
			_003CCastYield_003Ed__._003C_003E3__source = source;
			return _003CCastYield_003Ed__;
		}

		/// <summary>
		///       Filters the elements of an <see cref="T:System.Collections.IEnumerable" /> based on a specified type.
		///       </summary>
		public static IEnumerable<TResult> OfType<TResult>(IEnumerable source)
		{
			CheckNotNull(source, "source");
			return OfTypeYield<TResult>(source);
		}

		private static IEnumerable<TResult> OfTypeYield<TResult>(IEnumerable source)
		{
			_003COfTypeYield_003Ed__7<TResult> _003COfTypeYield_003Ed__ = new _003COfTypeYield_003Ed__7<TResult>(-2);
			_003COfTypeYield_003Ed__._003C_003E3__source = source;
			return _003COfTypeYield_003Ed__;
		}

		/// <summary>
		///       Generates a sequence of integral numbers within a specified range.
		///       </summary>
		/// <param name="start">The value of the first integer in the sequence.</param>
		/// <param name="count">The number of sequential integers to generate.</param>
		public static IEnumerable<int> Range(int start, int count)
		{
			int num = 0;
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, null);
			}
			long num2 = (long)start + (long)count;
			if (num2 - 1L >= 2147483647L)
			{
				throw new ArgumentOutOfRangeException("count", count, null);
			}
			return RangeYield(start, num2);
		}

		private static IEnumerable<int> RangeYield(int start, long long_0)
		{
			_003CRangeYield_003Ed__e _003CRangeYield_003Ed__e = new _003CRangeYield_003Ed__e(-2);
			_003CRangeYield_003Ed__e._003C_003E3__start = start;
			_003CRangeYield_003Ed__e._003C_003E3__end = long_0;
			return _003CRangeYield_003Ed__e;
		}

		/// <summary>
		///       Generates a sequence that contains one repeated value.
		///       </summary>
		public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
		{
			int num = 13;
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, null);
			}
			return RepeatYield(element, count);
		}

		private static IEnumerable<TResult> RepeatYield<TResult>(TResult element, int count)
		{
			_003CRepeatYield_003Ed__12<TResult> _003CRepeatYield_003Ed__ = new _003CRepeatYield_003Ed__12<TResult>(-2);
			_003CRepeatYield_003Ed__._003C_003E3__element = element;
			_003CRepeatYield_003Ed__._003C_003E3__count = count;
			return _003CRepeatYield_003Ed__;
		}

		/// <summary>
		///       Filters a sequence of values based on a predicate.
		///       </summary>
		public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			CheckNotNull(predicate, "predicate");
			return Where(source, (TSource item, int int_0) => predicate(item));
		}

		/// <summary>
		///       Filters a sequence of values based on a predicate. 
		///       Each element's index is used in the logic of the predicate function.
		///       </summary>
		public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			CheckNotNull(source, "source");
			CheckNotNull(predicate, "predicate");
			return WhereYield(source, predicate);
		}

		private static IEnumerable<TSource> WhereYield<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			_003CWhereYield_003Ed__19<TSource> _003CWhereYield_003Ed__ = new _003CWhereYield_003Ed__19<TSource>(-2);
			_003CWhereYield_003Ed__._003C_003E3__source = source;
			_003CWhereYield_003Ed__._003C_003E3__predicate = predicate;
			return _003CWhereYield_003Ed__;
		}

		/// <summary>
		///       Projects each element of a sequence into a new form.
		///       </summary>
		public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			CheckNotNull(selector, "selector");
			return Select(source, (TSource item, int int_0) => selector(item));
		}

		/// <summary>
		///       Projects each element of a sequence into a new form by 
		///       incorporating the element's index.
		///       </summary>
		public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
		{
			CheckNotNull(source, "source");
			CheckNotNull(selector, "selector");
			return SelectYield(source, selector);
		}

		private static IEnumerable<TResult> SelectYield<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
		{
			_003CSelectYield_003Ed__23<TSource, TResult> _003CSelectYield_003Ed__ = new _003CSelectYield_003Ed__23<TSource, TResult>(-2);
			_003CSelectYield_003Ed__._003C_003E3__source = source;
			_003CSelectYield_003Ed__._003C_003E3__selector = selector;
			return _003CSelectYield_003Ed__;
		}

		/// <summary>
		///       Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1" /> 
		///       and flattens the resulting sequences into one sequence.
		///       </summary>
		public static IEnumerable<TResult> SelectMany<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
		{
			CheckNotNull(selector, "selector");
			return SelectMany(source, (TSource item, int int_0) => selector(item));
		}

		/// <summary>
		///       Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1" />, 
		///       and flattens the resulting sequences into one sequence. The 
		///       index of each source element is used in the projected form of 
		///       that element.
		///       </summary>
		public static IEnumerable<TResult> SelectMany<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
		{
			CheckNotNull(selector, "selector");
			return SelectMany(source, selector, (TSource item, TResult subitem) => subitem);
		}

		/// <summary>
		///       Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1" />, 
		///       flattens the resulting sequences into one sequence, and invokes 
		///       a result selector function on each element therein.
		///       </summary>
		public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			CheckNotNull(collectionSelector, "collectionSelector");
			return SelectMany(source, (TSource item, int int_0) => collectionSelector(item), resultSelector);
		}

		/// <summary>
		///       Projects each element of a sequence to an <see cref="T:System.Collections.Generic.IEnumerable`1" />, 
		///       flattens the resulting sequences into one sequence, and invokes 
		///       a result selector function on each element therein. The index of 
		///       each source element is used in the intermediate projected form 
		///       of that element.
		///       </summary>
		public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			CheckNotNull(source, "source");
			CheckNotNull(collectionSelector, "collectionSelector");
			CheckNotNull(resultSelector, "resultSelector");
			return SelectManyYield(source, collectionSelector, resultSelector);
		}

		private static IEnumerable<TResult> SelectManyYield<TSource, TCollection, TResult>(IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			_003CSelectManyYield_003Ed__31<TSource, TCollection, TResult> _003CSelectManyYield_003Ed__ = new _003CSelectManyYield_003Ed__31<TSource, TCollection, TResult>(-2);
			_003CSelectManyYield_003Ed__._003C_003E3__source = source;
			_003CSelectManyYield_003Ed__._003C_003E3__collectionSelector = collectionSelector;
			_003CSelectManyYield_003Ed__._003C_003E3__resultSelector = resultSelector;
			return _003CSelectManyYield_003Ed__;
		}

		/// <summary>
		///       Returns elements from a sequence as long as a specified condition is true.
		///       </summary>
		public static IEnumerable<TSource> TakeWhile<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			CheckNotNull(predicate, "predicate");
			return TakeWhile(source, (TSource item, int int_0) => predicate(item));
		}

		/// <summary>
		///       Returns elements from a sequence as long as a specified condition is true.
		///       The element's index is used in the logic of the predicate function.
		///       </summary>
		public static IEnumerable<TSource> TakeWhile<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			CheckNotNull(source, "source");
			CheckNotNull(predicate, "predicate");
			return TakeWhileYield(source, predicate);
		}

		private static IEnumerable<TSource> TakeWhileYield<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			_003CTakeWhileYield_003Ed__3e<TSource> _003CTakeWhileYield_003Ed__3e = new _003CTakeWhileYield_003Ed__3e<TSource>(-2);
			_003CTakeWhileYield_003Ed__3e._003C_003E3__source = source;
			_003CTakeWhileYield_003Ed__3e._003C_003E3__predicate = predicate;
			return _003CTakeWhileYield_003Ed__3e;
		}

		/// <summary>
		///       Base implementation of First operator.
		///       </summary>
		private static TSource FirstImpl<TSource>(IEnumerable<TSource> source, Func<TSource> empty)
		{
			CheckNotNull(source, "source");
			Debug.Assert(empty != null);
			IList<TSource> list = source as IList<TSource>;
			if (list != null)
			{
				return (list.Count > 0) ? list[0] : empty();
			}
			using (IEnumerator<TSource> enumerator = source.GetEnumerator())
			{
				return enumerator.MoveNext() ? enumerator.Current : empty();
			}
		}

		/// <summary>
		///       Returns the first element of a sequence.
		///       </summary>
		public static TSource First<TSource>(IEnumerable<TSource> source)
		{
			return FirstImpl(source, Futures<TSource>.Undefined);
		}

		/// <summary>
		///       Returns the first element in a sequence that satisfies a specified condition.
		///       </summary>
		public static TSource First<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return First(Where(source, predicate));
		}

		/// <summary>
		///       Returns the first element of a sequence, or a default value if 
		///       the sequence contains no elements.
		///       </summary>
		public static TSource FirstOrDefault<TSource>(IEnumerable<TSource> source)
		{
			return FirstImpl(source, Futures<TSource>.Default);
		}

		/// <summary>
		///       Returns the first element of the sequence that satisfies a 
		///       condition or a default value if no such element is found.
		///       </summary>
		public static TSource FirstOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return FirstOrDefault(Where(source, predicate));
		}

		/// <summary>
		///       Base implementation of Last operator.
		///       </summary>
		private static TSource LastImpl<TSource>(IEnumerable<TSource> source, Func<TSource> empty)
		{
			CheckNotNull(source, "source");
			IList<TSource> list = source as IList<TSource>;
			if (list != null)
			{
				return (list.Count > 0) ? list[list.Count - 1] : empty();
			}
			using (IEnumerator<TSource> enumerator = source.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					return empty();
				}
				TSource current = enumerator.Current;
				while (enumerator.MoveNext())
				{
					current = enumerator.Current;
				}
				return current;
			}
		}

		/// <summary>
		///       Returns the last element of a sequence.
		///       </summary>
		public static TSource Last<TSource>(IEnumerable<TSource> source)
		{
			return LastImpl(source, Futures<TSource>.Undefined);
		}

		/// <summary>
		///       Returns the last element of a sequence that satisfies a 
		///       specified condition.
		///       </summary>
		public static TSource Last<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return Last(Where(source, predicate));
		}

		/// <summary>
		///       Returns the last element of a sequence, or a default value if 
		///       the sequence contains no elements.
		///       </summary>
		public static TSource LastOrDefault<TSource>(IEnumerable<TSource> source)
		{
			return LastImpl(source, Futures<TSource>.Default);
		}

		/// <summary>
		///       Returns the last element of a sequence that satisfies a 
		///       condition or a default value if no such element is found.
		///       </summary>
		public static TSource LastOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return LastOrDefault(Where(source, predicate));
		}

		/// <summary>
		///       Base implementation of Single operator.
		///       </summary>
		private static TSource SingleImpl<TSource>(IEnumerable<TSource> source, Func<TSource> empty)
		{
			CheckNotNull(source, "source");
			using (IEnumerator<TSource> enumerator = source.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					TSource current = enumerator.Current;
					if (enumerator.MoveNext())
					{
						throw new InvalidOperationException();
					}
					return current;
				}
				return empty();
			}
		}

		/// <summary>
		///       Returns the only element of a sequence, and throws an exception 
		///       if there is not exactly one element in the sequence.
		///       </summary>
		public static TSource Single<TSource>(IEnumerable<TSource> source)
		{
			return SingleImpl(source, Futures<TSource>.Undefined);
		}

		/// <summary>
		///       Returns the only element of a sequence that satisfies a 
		///       specified condition, and throws an exception if more than one 
		///       such element exists.
		///       </summary>
		public static TSource Single<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return Single(Where(source, predicate));
		}

		/// <summary>
		///       Returns the only element of a sequence, or a default value if 
		///       the sequence is empty; this method throws an exception if there 
		///       is more than one element in the sequence.
		///       </summary>
		public static TSource SingleOrDefault<TSource>(IEnumerable<TSource> source)
		{
			return SingleImpl(source, Futures<TSource>.Default);
		}

		/// <summary>
		///       Returns the only element of a sequence that satisfies a 
		///       specified condition or a default value if no such element 
		///       exists; this method throws an exception if more than one element 
		///       satisfies the condition.
		///       </summary>
		public static TSource SingleOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return SingleOrDefault(Where(source, predicate));
		}

		/// <summary>
		///       Returns the element at a specified index in a sequence.
		///       </summary>
		public static TSource ElementAt<TSource>(IEnumerable<TSource> source, int index)
		{
			int num = 18;
			CheckNotNull(source, "source");
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", index, null);
			}
			IList<TSource> list = source as IList<TSource>;
			if (list != null)
			{
				return list[index];
			}
			try
			{
				return First(SkipWhile(source, (TSource item, int int_0) => int_0 < index));
			}
			catch (InvalidOperationException)
			{
				throw new ArgumentOutOfRangeException("index", index, null);
			}
		}

		/// <summary>
		///       Returns the element at a specified index in a sequence or a 
		///       default value if the index is out of range.
		///       </summary>
		public static TSource ElementAtOrDefault<TSource>(IEnumerable<TSource> source, int index)
		{
			CheckNotNull(source, "source");
			if (index < 0)
			{
				return default(TSource);
			}
			IList<TSource> list = source as IList<TSource>;
			if (list != null)
			{
				return (index < list.Count) ? list[index] : default(TSource);
			}
			return FirstOrDefault(SkipWhile(source, (TSource item, int int_0) => int_0 < index));
		}

		/// <summary>
		///       Inverts the order of the elements in a sequence.
		///       </summary>
		public static IEnumerable<TSource> Reverse<TSource>(IEnumerable<TSource> source)
		{
			CheckNotNull(source, "source");
			return ReverseYield(source);
		}

		private static IEnumerable<TSource> ReverseYield<TSource>(IEnumerable<TSource> source)
		{
			_003CReverseYield_003Ed__4c<TSource> _003CReverseYield_003Ed__4c = new _003CReverseYield_003Ed__4c<TSource>(-2);
			_003CReverseYield_003Ed__4c._003C_003E3__source = source;
			return _003CReverseYield_003Ed__4c;
		}

		/// <summary>
		///       Returns a specified number of contiguous elements from the start 
		///       of a sequence.
		///       </summary>
		public static IEnumerable<TSource> Take<TSource>(IEnumerable<TSource> source, int count)
		{
			return Where(source, (TSource item, int int_0) => int_0 < count);
		}

		/// <summary>
		///       Bypasses a specified number of elements in a sequence and then 
		///       returns the remaining elements.
		///       </summary>
		public static IEnumerable<TSource> Skip<TSource>(IEnumerable<TSource> source, int count)
		{
			return Where(source, (TSource item, int int_0) => int_0 >= count);
		}

		/// <summary>
		///       Bypasses elements in a sequence as long as a specified condition 
		///       is true and then returns the remaining elements.
		///       </summary>
		public static IEnumerable<TSource> SkipWhile<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			CheckNotNull(predicate, "predicate");
			return SkipWhile(source, (TSource item, int int_0) => predicate(item));
		}

		/// <summary>
		///       Bypasses elements in a sequence as long as a specified condition 
		///       is true and then returns the remaining elements. The element's 
		///       index is used in the logic of the predicate function.
		///       </summary>
		public static IEnumerable<TSource> SkipWhile<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			CheckNotNull(source, "source");
			CheckNotNull(predicate, "predicate");
			return SkipWhileYield(source, predicate);
		}

		private static IEnumerable<TSource> SkipWhileYield<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			_003CSkipWhileYield_003Ed__5c<TSource> _003CSkipWhileYield_003Ed__5c = new _003CSkipWhileYield_003Ed__5c<TSource>(-2);
			_003CSkipWhileYield_003Ed__5c._003C_003E3__source = source;
			_003CSkipWhileYield_003Ed__5c._003C_003E3__predicate = predicate;
			return _003CSkipWhileYield_003Ed__5c;
		}

		/// <summary>
		///       Returns the number of elements in a sequence.
		///       </summary>
		public static int Count<TSource>(IEnumerable<TSource> source)
		{
			CheckNotNull(source, "source");
			return (source as ICollection)?.Count ?? Aggregate(source, 0, (int count, TSource item) => checked(count + 1));
		}

		/// <summary>
		///       Returns a number that represents how many elements in the 
		///       specified sequence satisfy a condition.
		///       </summary>
		public static int Count<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return Count(Where(source, predicate));
		}

		/// <summary>
		///       Returns an <see cref="T:System.Int64" /> that represents the total number 
		///       of elements in a sequence.
		///       </summary>
		public static long LongCount<TSource>(IEnumerable<TSource> source)
		{
			CheckNotNull(source, "source");
			return (source as Array)?.LongLength ?? Aggregate(source, 0L, (long count, TSource item) => count + 1L);
		}

		/// <summary>
		///       Returns an <see cref="T:System.Int64" /> that represents how many elements 
		///       in a sequence satisfy a condition.
		///       </summary>
		public static long LongCount<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return LongCount(Where(source, predicate));
		}

		/// <summary>
		///       Concatenates two sequences.
		///       </summary>
		public static IEnumerable<TSource> Concat<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			CheckNotNull(first, "first");
			CheckNotNull(second, "second");
			return ConcatYield(first, second);
		}

		private static IEnumerable<TSource> ConcatYield<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			_003CConcatYield_003Ed__63<TSource> _003CConcatYield_003Ed__ = new _003CConcatYield_003Ed__63<TSource>(-2);
			_003CConcatYield_003Ed__._003C_003E3__first = first;
			_003CConcatYield_003Ed__._003C_003E3__second = second;
			return _003CConcatYield_003Ed__;
		}

		/// <summary>
		///       Creates a <see cref="T:System.Collections.Generic.List`1" /> from an <see cref="T:System.Collections.Generic.IEnumerable`1" />.
		///       </summary>
		public static List<TSource> ToList<TSource>(IEnumerable<TSource> source)
		{
			CheckNotNull(source, "source");
			return new List<TSource>(source);
		}

		/// <summary>
		///       Creates an array from an <see cref="T:System.Collections.Generic.IEnumerable`1" />.
		///       </summary>
		public static TSource[] ToArray<TSource>(IEnumerable<TSource> source)
		{
			return ToList(source).ToArray();
		}

		/// <summary>
		///       Returns distinct elements from a sequence by using the default 
		///       equality comparer to compare values.
		///       </summary>
		public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source)
		{
			return Distinct(source, null);
		}

		/// <summary>
		///       Returns distinct elements from a sequence by using a specified 
		///       <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> to compare values.
		///       </summary>
		public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
		{
			CheckNotNull(source, "source");
			return DistinctYield(source, comparer);
		}

		private static IEnumerable<TSource> DistinctYield<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
		{
			_003CDistinctYield_003Ed__6c<TSource> _003CDistinctYield_003Ed__6c = new _003CDistinctYield_003Ed__6c<TSource>(-2);
			_003CDistinctYield_003Ed__6c._003C_003E3__source = source;
			_003CDistinctYield_003Ed__6c._003C_003E3__comparer = comparer;
			return _003CDistinctYield_003Ed__6c;
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.Lookup`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key 
		///       selector function.
		///       </summary>
		public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return ToLookup(source, keySelector, (TSource gparam_0) => gparam_0, null);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.Lookup`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key 
		///       selector function and a key comparer.
		///       </summary>
		public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return ToLookup(source, keySelector, (TSource gparam_0) => gparam_0, comparer);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.Lookup`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to specified key 
		///       and element selector functions.
		///       </summary>
		public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return ToLookup(source, keySelector, elementSelector, null);
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Utilities.LinqBridge.Lookup`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key 
		///       selector function, a comparer and an element selector function.
		///       </summary>
		public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			CheckNotNull(keySelector, "keySelector");
			CheckNotNull(elementSelector, "elementSelector");
			Lookup<TKey, TElement> lookup = new Lookup<TKey, TElement>(comparer);
			foreach (TSource item in source)
			{
				TKey gparam_ = keySelector(item);
				Grouping<TKey, TElement> grouping = (Grouping<TKey, TElement>)lookup.Find(gparam_);
				if (grouping == null)
				{
					grouping = new Grouping<TKey, TElement>(gparam_);
					lookup.Add(grouping);
				}
				grouping.Add(elementSelector(item));
			}
			return lookup;
		}

		/// <summary>
		///       Groups the elements of a sequence according to a specified key 
		///       selector function.
		///       </summary>
		public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return GroupBy(source, keySelector, null);
		}

		/// <summary>
		///       Groups the elements of a sequence according to a specified key 
		///       selector function and compares the keys by using a specified 
		///       comparer.
		///       </summary>
		public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return GroupBy(source, keySelector, (TSource gparam_0) => gparam_0, comparer);
		}

		/// <summary>
		///       Groups the elements of a sequence according to a specified key 
		///       selector function and projects the elements for each group by 
		///       using a specified function.
		///       </summary>
		public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return GroupBy(source, keySelector, elementSelector, null);
		}

		/// <summary>
		///       Groups the elements of a sequence according to a specified key 
		///       selector function and creates a result value from each group and 
		///       its key.
		///       </summary>
		public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			CheckNotNull(keySelector, "keySelector");
			CheckNotNull(elementSelector, "elementSelector");
			return ToLookup(source, keySelector, elementSelector, comparer);
		}

		/// <summary>
		///       Groups the elements of a sequence according to a key selector 
		///       function. The keys are compared by using a comparer and each 
		///       group's elements are projected by using a specified function.
		///       </summary>
		public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
		{
			return GroupBy(source, keySelector, resultSelector, null);
		}

		/// <summary>
		///       Groups the elements of a sequence according to a specified key 
		///       selector function and creates a result value from each group and 
		///       its key. The elements of each group are projected by using a 
		///       specified function.
		///       </summary>
		public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			CheckNotNull(keySelector, "keySelector");
			CheckNotNull(resultSelector, "resultSelector");
			return Select(ToLookup(source, keySelector, comparer), (IGrouping<TKey, TSource> igrouping_0) => resultSelector(igrouping_0.Key, igrouping_0));
		}

		/// <summary>
		///       Groups the elements of a sequence according to a specified key 
		///       selector function and creates a result value from each group and 
		///       its key. The keys are compared by using a specified comparer.
		///       </summary>
		public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
		{
			return GroupBy(source, keySelector, elementSelector, resultSelector, null);
		}

		/// <summary>
		///       Groups the elements of a sequence according to a specified key 
		///       selector function and creates a result value from each group and 
		///       its key. Key values are compared by using a specified comparer, 
		///       and the elements of each group are projected by using a 
		///       specified function.
		///       </summary>
		public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			CheckNotNull(keySelector, "keySelector");
			CheckNotNull(elementSelector, "elementSelector");
			CheckNotNull(resultSelector, "resultSelector");
			return Select(ToLookup(source, keySelector, elementSelector, comparer), (IGrouping<TKey, TElement> igrouping_0) => resultSelector(igrouping_0.Key, igrouping_0));
		}

		/// <summary>
		///       Applies an accumulator function over a sequence.
		///       </summary>
		public static TSource Aggregate<TSource>(IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
		{
			CheckNotNull(source, "source");
			CheckNotNull(func, "func");
			using (IEnumerator<TSource> enumerator = source.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					throw new InvalidOperationException();
				}
				return Aggregate(Skip(Renumerable(enumerator), 1), enumerator.Current, func);
			}
		}

		/// <summary>
		///       Applies an accumulator function over a sequence. The specified 
		///       seed value is used as the initial accumulator value.
		///       </summary>
		public static TAccumulate Aggregate<TSource, TAccumulate>(IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
		{
			return Aggregate(source, seed, func, (TAccumulate gparam_0) => gparam_0);
		}

		/// <summary>
		///       Applies an accumulator function over a sequence. The specified 
		///       seed value is used as the initial accumulator value, and the 
		///       specified function is used to select the result value.
		///       </summary>
		public static TResult Aggregate<TSource, TAccumulate, TResult>(IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		{
			CheckNotNull(source, "source");
			CheckNotNull(func, "func");
			CheckNotNull(resultSelector, "resultSelector");
			TAccumulate val = seed;
			foreach (TSource item in source)
			{
				val = func(val, item);
			}
			return resultSelector(val);
		}

		/// <summary>
		///       Produces the set union of two sequences by using the default 
		///       equality comparer.
		///       </summary>
		public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			return Union(first, second, null);
		}

		/// <summary>
		///       Produces the set union of two sequences by using a specified 
		///       <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
		///       </summary>
		public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		{
			return Distinct(Concat(first, second), comparer);
		}

		/// <summary>
		///       Returns the elements of the specified sequence or the type 
		///       parameter's default value in a singleton collection if the 
		///       sequence is empty.
		///       </summary>
		public static IEnumerable<TSource> DefaultIfEmpty<TSource>(IEnumerable<TSource> source)
		{
			return DefaultIfEmpty(source, default(TSource));
		}

		/// <summary>
		///       Returns the elements of the specified sequence or the specified 
		///       value in a singleton collection if the sequence is empty.
		///       </summary>
		public static IEnumerable<TSource> DefaultIfEmpty<TSource>(IEnumerable<TSource> source, TSource defaultValue)
		{
			CheckNotNull(source, "source");
			return DefaultIfEmptyYield(source, defaultValue);
		}

		private static IEnumerable<TSource> DefaultIfEmptyYield<TSource>(IEnumerable<TSource> source, TSource defaultValue)
		{
			_003CDefaultIfEmptyYield_003Ed__7e<TSource> _003CDefaultIfEmptyYield_003Ed__7e = new _003CDefaultIfEmptyYield_003Ed__7e<TSource>(-2);
			_003CDefaultIfEmptyYield_003Ed__7e._003C_003E3__source = source;
			_003CDefaultIfEmptyYield_003Ed__7e._003C_003E3__defaultValue = defaultValue;
			return _003CDefaultIfEmptyYield_003Ed__7e;
		}

		/// <summary>
		///       Determines whether all elements of a sequence satisfy a condition.
		///       </summary>
		public static bool All<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			CheckNotNull(source, "source");
			CheckNotNull(predicate, "predicate");
			foreach (TSource item in source)
			{
				if (!predicate(item))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///       Determines whether a sequence contains any elements.
		///       </summary>
		public static bool Any<TSource>(IEnumerable<TSource> source)
		{
			CheckNotNull(source, "source");
			using (IEnumerator<TSource> enumerator = source.GetEnumerator())
			{
				return enumerator.MoveNext();
			}
		}

		/// <summary>
		///       Determines whether any element of a sequence satisfies a 
		///       condition.
		///       </summary>
		public static bool Any<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return Any(Where(source, predicate));
		}

		/// <summary>
		///       Determines whether a sequence contains a specified element by 
		///       using the default equality comparer.
		///       </summary>
		public static bool Contains<TSource>(IEnumerable<TSource> source, TSource value)
		{
			return Contains(source, value, null);
		}

		/// <summary>
		///       Determines whether a sequence contains a specified element by 
		///       using a specified <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
		///       </summary>
		public static bool Contains<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
		{
			CheckNotNull(source, "source");
			if (comparer == null)
			{
				ICollection<TSource> collection = source as ICollection<TSource>;
				if (collection != null)
				{
					return collection.Contains(value);
				}
			}
			comparer = (comparer ?? EqualityComparer<TSource>.Default);
			return Any(source, (TSource item) => comparer.Equals(item, value));
		}

		/// <summary>
		///       Determines whether two sequences are equal by comparing the 
		///       elements by using the default equality comparer for their type.
		///       </summary>
		public static bool SequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			return SequenceEqual(first, second, null);
		}

		/// <summary>
		///       Determines whether two sequences are equal by comparing their 
		///       elements by using a specified <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
		///       </summary>
		public static bool SequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		{
			CheckNotNull(first, "frist");
			CheckNotNull(second, "second");
			comparer = (comparer ?? EqualityComparer<TSource>.Default);
			using (IEnumerator<TSource> enumerator = first.GetEnumerator())
			{
				using (IEnumerator<TSource> enumerator2 = second.GetEnumerator())
				{
					do
					{
						if (!enumerator.MoveNext())
						{
							return !enumerator2.MoveNext();
						}
						if (!enumerator2.MoveNext())
						{
							return false;
						}
					}
					while (comparer.Equals(enumerator.Current, enumerator2.Current));
				}
			}
			return false;
		}

		/// <summary>
		///       Base implementation for Min/Max operator.
		///       </summary>
		private static TSource MinMaxImpl<TSource>(IEnumerable<TSource> source, Func<TSource, TSource, bool> lesser)
		{
			CheckNotNull(source, "source");
			Debug.Assert(lesser != null);
			return Aggregate(source, (TSource gparam_0, TSource item) => lesser(gparam_0, item) ? gparam_0 : item);
		}

		/// <summary>
		///       Base implementation for Min/Max operator for nullable types.
		///       </summary>
		private static TSource? MinMaxImpl<TSource>(IEnumerable<TSource?> source, TSource? seed, Func<TSource?, TSource?, bool> lesser) where TSource : struct
		{
			CheckNotNull(source, "source");
			Debug.Assert(lesser != null);
			return Aggregate(source, seed, (TSource? nullable_0, TSource? item) => lesser(nullable_0, item) ? nullable_0 : item);
		}

		/// <summary>
		///       Returns the minimum value in a generic sequence.
		///       </summary>
		public static TSource Min<TSource>(IEnumerable<TSource> source)
		{
			Comparer<TSource> comparer = Comparer<TSource>.Default;
			return MinMaxImpl(source, (TSource gparam_0, TSource gparam_1) => comparer.Compare(gparam_0, gparam_1) < 0);
		}

		/// <summary>
		///       Invokes a transform function on each element of a generic 
		///       sequence and returns the minimum resulting value.
		///       </summary>
		public static TResult Min<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			return Min(Select(source, selector));
		}

		/// <summary>
		///       Returns the maximum value in a generic sequence.
		///       </summary>
		public static TSource Max<TSource>(IEnumerable<TSource> source)
		{
			Comparer<TSource> comparer = Comparer<TSource>.Default;
			return MinMaxImpl(source, (TSource gparam_0, TSource gparam_1) => comparer.Compare(gparam_0, gparam_1) > 0);
		}

		/// <summary>
		///       Invokes a transform function on each element of a generic 
		///       sequence and returns the maximum resulting value.
		///       </summary>
		public static TResult Max<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			return Max(Select(source, selector));
		}

		/// <summary>
		///       Makes an enumerator seen as enumerable once more.
		///       </summary>
		/// <remarks>
		///       The supplied enumerator must have been started. The first element
		///       returned is the element the enumerator was on when passed in.
		///       DO NOT use this method if the caller must be a generator. It is
		///       mostly safe among aggregate operations.
		///       </remarks>
		private static IEnumerable<T> Renumerable<T>(IEnumerator<T> ienumerator_0)
		{
			_003CRenumerable_003Ed__92<T> _003CRenumerable_003Ed__ = new _003CRenumerable_003Ed__92<T>(-2);
			_003CRenumerable_003Ed__._003C_003E3__e = ienumerator_0;
			return _003CRenumerable_003Ed__;
		}

		/// <summary>
		///       Sorts the elements of a sequence in ascending order according to a key.
		///       </summary>
		public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return OrderBy(source, keySelector, null);
		}

		/// <summary>
		///       Sorts the elements of a sequence in ascending order by using a 
		///       specified comparer.
		///       </summary>
		public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			CheckNotNull(keySelector, "keySelector");
			return new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, descending: false);
		}

		/// <summary>
		///       Sorts the elements of a sequence in descending order according to a key.
		///       </summary>
		public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return OrderByDescending(source, keySelector, null);
		}

		/// <summary>
		///        Sorts the elements of a sequence in descending order by using a 
		///       specified comparer. 
		///       </summary>
		public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			CheckNotNull(source, "keySelector");
			return new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, descending: true);
		}

		/// <summary>
		///       Performs a subsequent ordering of the elements in a sequence in 
		///       ascending order according to a key.
		///       </summary>
		public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return ThenBy(source, keySelector, null);
		}

		/// <summary>
		///       Performs a subsequent ordering of the elements in a sequence in 
		///       ascending order by using a specified comparer.
		///       </summary>
		public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			return source.CreateOrderedEnumerable(keySelector, comparer, descending: false);
		}

		/// <summary>
		///       Performs a subsequent ordering of the elements in a sequence in 
		///       descending order, according to a key.
		///       </summary>
		public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return ThenByDescending(source, keySelector, null);
		}

		/// <summary>
		///       Performs a subsequent ordering of the elements in a sequence in 
		///       descending order by using a specified comparer.
		///       </summary>
		public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			return source.CreateOrderedEnumerable(keySelector, comparer, descending: true);
		}

		/// <summary>
		///       Base implementation for Intersect and Except operators.
		///       </summary>
		private static IEnumerable<TSource> IntersectExceptImpl<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer, bool flag)
		{
			CheckNotNull(first, "first");
			CheckNotNull(second, "second");
			List<TSource> list = new List<TSource>();
			Dictionary<TSource, bool> flags = new Dictionary<TSource, bool>(comparer);
			foreach (TSource item in Where(first, (TSource gparam_0) => !flags.ContainsKey(gparam_0)))
			{
				flags.Add(item, !flag);
				list.Add(item);
			}
			foreach (TSource item2 in Where(second, flags.ContainsKey))
			{
				flags[item2] = flag;
			}
			return Where(list, (TSource item) => flags[item]);
		}

		/// <summary>
		///       Produces the set intersection of two sequences by using the 
		///       default equality comparer to compare values.
		///       </summary>
		public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			return Intersect(first, second, null);
		}

		/// <summary>
		///       Produces the set intersection of two sequences by using the 
		///       specified <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> to compare values.
		///       </summary>
		public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		{
			return IntersectExceptImpl(first, second, comparer, flag: true);
		}

		/// <summary>
		///       Produces the set difference of two sequences by using the 
		///       default equality comparer to compare values.
		///       </summary>
		public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			return Except(first, second, null);
		}

		/// <summary>
		///       Produces the set difference of two sequences by using the 
		///       specified <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> to compare values.
		///       </summary>
		public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		{
			return IntersectExceptImpl(first, second, comparer, flag: false);
		}

		/// <summary>
		///       Creates a <see cref="T:System.Collections.Generic.Dictionary`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key 
		///       selector function.
		///       </summary>
		public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return ToDictionary(source, keySelector, null);
		}

		/// <summary>
		///       Creates a <see cref="T:System.Collections.Generic.Dictionary`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key 
		///       selector function and key comparer.
		///       </summary>
		public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return ToDictionary(source, keySelector, (TSource gparam_0) => gparam_0);
		}

		/// <summary>
		///       Creates a <see cref="T:System.Collections.Generic.Dictionary`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to specified key 
		///       selector and element selector functions.
		///       </summary>
		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return ToDictionary(source, keySelector, elementSelector, null);
		}

		/// <summary>
		///       Creates a <see cref="T:System.Collections.Generic.Dictionary`2" /> from an 
		///       <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key 
		///       selector function, a comparer, and an element selector function.
		///       </summary>
		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			CheckNotNull(source, "source");
			CheckNotNull(keySelector, "keySelector");
			CheckNotNull(elementSelector, "elementSelector");
			Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(comparer);
			foreach (TSource item in source)
			{
				dictionary.Add(keySelector(item), elementSelector(item));
			}
			return dictionary;
		}

		/// <summary>
		///       Correlates the elements of two sequences based on matching keys. 
		///       The default equality comparer is used to compare keys.
		///       </summary>
		public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		{
			return Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);
		}

		/// <summary>
		///       Correlates the elements of two sequences based on matching keys. 
		///       The default equality comparer is used to compare keys. A 
		///       specified <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> is used to compare keys.
		///       </summary>
		public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			CheckNotNull(outer, "outer");
			CheckNotNull(inner, "inner");
			CheckNotNull(outerKeySelector, "outerKeySelector");
			CheckNotNull(innerKeySelector, "innerKeySelector");
			CheckNotNull(resultSelector, "resultSelector");
			ToLookup(inner, innerKeySelector, comparer);
			return null;
		}

		/// <summary>
		///       Correlates the elements of two sequences based on equality of 
		///       keys and groups the results. The default equality comparer is 
		///       used to compare keys.
		///       </summary>
		public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		{
			return GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, null);
		}

		/// <summary>
		///       Correlates the elements of two sequences based on equality of 
		///       keys and groups the results. The default equality comparer is 
		///       used to compare keys. A specified <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> 
		///       is used to compare keys.
		///       </summary>
		public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			CheckNotNull(outer, "outer");
			CheckNotNull(inner, "inner");
			CheckNotNull(outerKeySelector, "outerKeySelector");
			CheckNotNull(innerKeySelector, "innerKeySelector");
			CheckNotNull(resultSelector, "resultSelector");
			ILookup<TKey, TInner> lookup = ToLookup(inner, innerKeySelector, comparer);
			return Select(outer, (TOuter gparam_0) => resultSelector(gparam_0, lookup[outerKeySelector(gparam_0)]));
		}

		[DebuggerStepThrough]
		private static void CheckNotNull<T>(T value, string name) where T : class
		{
			if (value == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Int32" /> values.
		///       </summary>
		public static int Sum(IEnumerable<int> source)
		{
			CheckNotNull(source, "source");
			int num = 0;
			foreach (int item in source)
			{
				num = checked(num + item);
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Int32" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static int Sum<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Int32" /> values.
		///       </summary>
		public static double Average(IEnumerable<int> source)
		{
			CheckNotNull(source, "source");
			long num = 0L;
			long num2 = 0L;
			checked
			{
				foreach (int item in source)
				{
					num += item;
					num2++;
				}
				if (num2 == 0L)
				{
					throw new InvalidOperationException();
				}
				return (double)num / (double)num2;
			}
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Int32" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static double Average<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Int32" /> values.
		///       </summary>
		public static int? Sum(IEnumerable<int?> source)
		{
			CheckNotNull(source, "source");
			int num = 0;
			foreach (int? item in source)
			{
				num = checked(num + (item ?? 0));
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Int32" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static int? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, int?> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Int32" /> values.
		///       </summary>
		public static double? Average(IEnumerable<int?> source)
		{
			CheckNotNull(source, "source");
			long num = 0L;
			long num2 = 0L;
			checked
			{
				foreach (int? item in Where(source, (int? nullable_0) => nullable_0.HasValue))
				{
					num += item.Value;
					num2++;
				}
				if (num2 == 0L)
				{
					return null;
				}
				return new double?(num) / (double)num2;
			}
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Int32" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static double? Average<TSource>(IEnumerable<TSource> source, Func<TSource, int?> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Returns the minimum value in a sequence of nullable 
		///       <see cref="T:System.Int32" /> values.
		///       </summary>
		public static int? Min(IEnumerable<int?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (int? nullable_0) => nullable_0.HasValue), null, (int? nullable_0, int? nullable_1) => nullable_0 < nullable_1);
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the minimum nullable <see cref="T:System.Int32" /> value.
		///       </summary>
		public static int? Min<TSource>(IEnumerable<TSource> source, Func<TSource, int?> selector)
		{
			return Min(Select(source, selector));
		}

		/// <summary>
		///       Returns the maximum value in a sequence of nullable 
		///       <see cref="T:System.Int32" /> values.
		///       </summary>
		public static int? Max(IEnumerable<int?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (int? nullable_0) => nullable_0.HasValue), null, (int? nullable_0, int? nullable_1) => !nullable_1.HasValue || (nullable_0.HasValue && nullable_1.Value < nullable_0.Value));
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the maximum nullable <see cref="T:System.Int32" /> value.
		///       </summary>
		public static int? Max<TSource>(IEnumerable<TSource> source, Func<TSource, int?> selector)
		{
			return Max(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Int64" /> values.
		///       </summary>
		public static long Sum(IEnumerable<long> source)
		{
			CheckNotNull(source, "source");
			long num = 0L;
			foreach (long item in source)
			{
				num = checked(num + item);
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Int64" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static long Sum<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Int64" /> values.
		///       </summary>
		public static double Average(IEnumerable<long> source)
		{
			CheckNotNull(source, "source");
			long num = 0L;
			long num2 = 0L;
			checked
			{
				foreach (long item in source)
				{
					num += item;
					num2++;
				}
				if (num2 == 0L)
				{
					throw new InvalidOperationException();
				}
				return (double)num / (double)num2;
			}
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Int64" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static double Average<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Int64" /> values.
		///       </summary>
		public static long? Sum(IEnumerable<long?> source)
		{
			CheckNotNull(source, "source");
			long num = 0L;
			foreach (long? item in source)
			{
				num = checked(num + (item ?? 0L));
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Int64" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static long? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, long?> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Int64" /> values.
		///       </summary>
		public static double? Average(IEnumerable<long?> source)
		{
			CheckNotNull(source, "source");
			long num = 0L;
			long num2 = 0L;
			checked
			{
				foreach (long? item in Where(source, (long? nullable_0) => nullable_0.HasValue))
				{
					num += item.Value;
					num2++;
				}
				if (num2 == 0L)
				{
					return null;
				}
				return new double?(num) / (double)num2;
			}
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Int64" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static double? Average<TSource>(IEnumerable<TSource> source, Func<TSource, long?> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Returns the minimum value in a sequence of nullable 
		///       <see cref="T:System.Int64" /> values.
		///       </summary>
		public static long? Min(IEnumerable<long?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (long? nullable_0) => nullable_0.HasValue), null, (long? nullable_0, long? nullable_1) => nullable_0 < nullable_1);
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the minimum nullable <see cref="T:System.Int64" /> value.
		///       </summary>
		public static long? Min<TSource>(IEnumerable<TSource> source, Func<TSource, long?> selector)
		{
			return Min(Select(source, selector));
		}

		/// <summary>
		///       Returns the maximum value in a sequence of nullable 
		///       <see cref="T:System.Int64" /> values.
		///       </summary>
		public static long? Max(IEnumerable<long?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (long? nullable_0) => nullable_0.HasValue), null, (long? nullable_0, long? nullable_1) => !nullable_1.HasValue || (nullable_0.HasValue && nullable_1.Value < nullable_0.Value));
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the maximum nullable <see cref="T:System.Int64" /> value.
		///       </summary>
		public static long? Max<TSource>(IEnumerable<TSource> source, Func<TSource, long?> selector)
		{
			return Max(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Single" /> values.
		///       </summary>
		public static float Sum(IEnumerable<float> source)
		{
			CheckNotNull(source, "source");
			float num = 0f;
			foreach (float item in source)
			{
				float num2 = item;
				num += num2;
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Single" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static float Sum<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Single" /> values.
		///       </summary>
		public static float Average(IEnumerable<float> source)
		{
			CheckNotNull(source, "source");
			float num = 0f;
			long num2 = 0L;
			foreach (float item in source)
			{
				float num3 = item;
				num += num3;
				num2 = checked(num2 + 1L);
			}
			if (num2 == 0L)
			{
				throw new InvalidOperationException();
			}
			return num / (float)num2;
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Single" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static float Average<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Single" /> values.
		///       </summary>
		public static float? Sum(IEnumerable<float?> source)
		{
			CheckNotNull(source, "source");
			float num = 0f;
			foreach (float? item in source)
			{
				num += (item ?? 0f);
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Single" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static float? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, float?> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Single" /> values.
		///       </summary>
		public static float? Average(IEnumerable<float?> source)
		{
			CheckNotNull(source, "source");
			float num = 0f;
			long num2 = 0L;
			foreach (float? item in Where(source, (float? nullable_0) => nullable_0.HasValue))
			{
				num += item.Value;
				num2 = checked(num2 + 1L);
			}
			if (num2 == 0L)
			{
				return null;
			}
			return new float?(num) / (float)num2;
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Single" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static float? Average<TSource>(IEnumerable<TSource> source, Func<TSource, float?> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Returns the minimum value in a sequence of nullable 
		///       <see cref="T:System.Single" /> values.
		///       </summary>
		public static float? Min(IEnumerable<float?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (float? nullable_0) => nullable_0.HasValue), null, (float? nullable_0, float? nullable_1) => nullable_0 < nullable_1);
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the minimum nullable <see cref="T:System.Single" /> value.
		///       </summary>
		public static float? Min<TSource>(IEnumerable<TSource> source, Func<TSource, float?> selector)
		{
			return Min(Select(source, selector));
		}

		/// <summary>
		///       Returns the maximum value in a sequence of nullable 
		///       <see cref="T:System.Single" /> values.
		///       </summary>
		public static float? Max(IEnumerable<float?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (float? nullable_0) => nullable_0.HasValue), null, (float? nullable_0, float? nullable_1) => !nullable_1.HasValue || (nullable_0.HasValue && nullable_1.Value < nullable_0.Value));
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the maximum nullable <see cref="T:System.Single" /> value.
		///       </summary>
		public static float? Max<TSource>(IEnumerable<TSource> source, Func<TSource, float?> selector)
		{
			return Max(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Double" /> values.
		///       </summary>
		public static double Sum(IEnumerable<double> source)
		{
			CheckNotNull(source, "source");
			double num = 0.0;
			foreach (double item in source)
			{
				double num2 = item;
				num += num2;
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Double" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static double Sum<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Double" /> values.
		///       </summary>
		public static double Average(IEnumerable<double> source)
		{
			CheckNotNull(source, "source");
			double num = 0.0;
			long num2 = 0L;
			foreach (double item in source)
			{
				double num3 = item;
				num += num3;
				num2 = checked(num2 + 1L);
			}
			if (num2 == 0L)
			{
				throw new InvalidOperationException();
			}
			return num / (double)num2;
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Double" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static double Average<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Double" /> values.
		///       </summary>
		public static double? Sum(IEnumerable<double?> source)
		{
			CheckNotNull(source, "source");
			double num = 0.0;
			foreach (double? item in source)
			{
				num += (item ?? 0.0);
			}
			return num;
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Double" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static double? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, double?> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Double" /> values.
		///       </summary>
		public static double? Average(IEnumerable<double?> source)
		{
			CheckNotNull(source, "source");
			double num = 0.0;
			long num2 = 0L;
			foreach (double? item in Where(source, (double? nullable_0) => nullable_0.HasValue))
			{
				num += item.Value;
				num2 = checked(num2 + 1L);
			}
			if (num2 == 0L)
			{
				return null;
			}
			return new double?(num) / (double)num2;
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Double" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static double? Average<TSource>(IEnumerable<TSource> source, Func<TSource, double?> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Returns the minimum value in a sequence of nullable 
		///       <see cref="T:System.Double" /> values.
		///       </summary>
		public static double? Min(IEnumerable<double?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (double? nullable_0) => nullable_0.HasValue), null, (double? nullable_0, double? nullable_1) => nullable_0 < nullable_1);
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the minimum nullable <see cref="T:System.Double" /> value.
		///       </summary>
		public static double? Min<TSource>(IEnumerable<TSource> source, Func<TSource, double?> selector)
		{
			return Min(Select(source, selector));
		}

		/// <summary>
		///       Returns the maximum value in a sequence of nullable 
		///       <see cref="T:System.Double" /> values.
		///       </summary>
		public static double? Max(IEnumerable<double?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (double? nullable_0) => nullable_0.HasValue), null, (double? nullable_0, double? nullable_1) => !nullable_1.HasValue || (nullable_0.HasValue && nullable_1.Value < nullable_0.Value));
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the maximum nullable <see cref="T:System.Double" /> value.
		///       </summary>
		public static double? Max<TSource>(IEnumerable<TSource> source, Func<TSource, double?> selector)
		{
			return Max(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Decimal" /> values.
		///       </summary>
		public static decimal Sum(IEnumerable<decimal> source)
		{
			CheckNotNull(source, "source");
			decimal result = 0m;
			foreach (decimal item in source)
			{
				result += item;
			}
			return result;
		}

		/// <summary>
		///       Computes the sum of a sequence of nullable <see cref="T:System.Decimal" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static decimal Sum<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Decimal" /> values.
		///       </summary>
		public static decimal Average(IEnumerable<decimal> source)
		{
			CheckNotNull(source, "source");
			decimal d = 0m;
			long num = 0L;
			foreach (decimal item in source)
			{
				d += item;
				num = checked(num + 1L);
			}
			if (num == 0L)
			{
				throw new InvalidOperationException();
			}
			return d / (decimal)num;
		}

		/// <summary>
		///       Computes the average of a sequence of nullable <see cref="T:System.Decimal" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static decimal Average<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Decimal" /> values.
		///       </summary>
		public static decimal? Sum(IEnumerable<decimal?> source)
		{
			CheckNotNull(source, "source");
			decimal value = 0m;
			foreach (decimal? item in source)
			{
				value += (item ?? 0m);
			}
			return value;
		}

		/// <summary>
		///       Computes the sum of a sequence of <see cref="T:System.Decimal" /> 
		///       values that are obtained by invoking a transform function on 
		///       each element of the input sequence.
		///       </summary>
		public static decimal? Sum<TSource>(IEnumerable<TSource> source, Func<TSource, decimal?> selector)
		{
			return Sum(Select(source, selector));
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Decimal" /> values.
		///       </summary>
		public static decimal? Average(IEnumerable<decimal?> source)
		{
			CheckNotNull(source, "source");
			decimal value = 0m;
			long num = 0L;
			foreach (decimal? item in Where(source, (decimal? nullable_0) => nullable_0.HasValue))
			{
				value += item.Value;
				num = checked(num + 1L);
			}
			if (num == 0L)
			{
				return null;
			}
			return (decimal?)value / (decimal?)num;
		}

		/// <summary>
		///       Computes the average of a sequence of <see cref="T:System.Decimal" /> values 
		///       that are obtained by invoking a transform function on each 
		///       element of the input sequence.
		///       </summary>
		public static decimal? Average<TSource>(IEnumerable<TSource> source, Func<TSource, decimal?> selector)
		{
			return Average(Select(source, selector));
		}

		/// <summary>
		///       Returns the minimum value in a sequence of nullable 
		///       <see cref="T:System.Decimal" /> values.
		///       </summary>
		public static decimal? Min(IEnumerable<decimal?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (decimal? nullable_0) => nullable_0.HasValue), null, (decimal? nullable_0, decimal? nullable_1) => nullable_0 < nullable_1);
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the minimum nullable <see cref="T:System.Decimal" /> value.
		///       </summary>
		public static decimal? Min<TSource>(IEnumerable<TSource> source, Func<TSource, decimal?> selector)
		{
			return Min(Select(source, selector));
		}

		/// <summary>
		///       Returns the maximum value in a sequence of nullable 
		///       <see cref="T:System.Decimal" /> values.
		///       </summary>
		public static decimal? Max(IEnumerable<decimal?> source)
		{
			CheckNotNull(source, "source");
			return MinMaxImpl(Where(source, (decimal? nullable_0) => nullable_0.HasValue), null, (decimal? nullable_0, decimal? nullable_1) => !nullable_1.HasValue || (nullable_0.HasValue && nullable_1.Value < nullable_0.Value));
		}

		/// <summary>
		///       Invokes a transform function on each element of a sequence and 
		///       returns the maximum nullable <see cref="T:System.Decimal" /> value.
		///       </summary>
		public static decimal? Max<TSource>(IEnumerable<TSource> source, Func<TSource, decimal?> selector)
		{
			return Max(Select(source, selector));
		}
	}
}
