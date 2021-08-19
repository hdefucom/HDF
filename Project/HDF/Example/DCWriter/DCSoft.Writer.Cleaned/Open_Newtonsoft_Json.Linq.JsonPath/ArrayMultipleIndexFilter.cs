using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal class ArrayMultipleIndexFilter : PathFilter
	{
		[CompilerGenerated]
		private sealed class _003CExecuteFilter_003Ed__0 : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public ArrayMultipleIndexFilter _003C_003E4__this;

			public IEnumerable<JToken> current;

			public IEnumerable<JToken> _003C_003E3__current;

			public bool errorWhenNoMatch;

			public bool _003C_003E3__errorWhenNoMatch;

			public JToken _003Ct_003E5__1;

			public int _003Ci_003E5__2;

			public JToken _003Cv_003E5__3;

			public IEnumerator<JToken> _003C_003E7__wrap4;

			public List<int>.Enumerator _003C_003E7__wrap6;

			JToken IEnumerator<JToken>.Current
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
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator()
			{
				_003CExecuteFilter_003Ed__0 _003CExecuteFilter_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CExecuteFilter_003Ed__ = this;
				}
				else
				{
					_003CExecuteFilter_003Ed__ = new _003CExecuteFilter_003Ed__0(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				_003CExecuteFilter_003Ed__.current = _003C_003E3__current;
				_003CExecuteFilter_003Ed__.errorWhenNoMatch = _003C_003E3__errorWhenNoMatch;
				return _003CExecuteFilter_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JToken>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num = _003C_003E1__state;
					if (num == 0)
					{
						_003C_003E1__state = -1;
						_003C_003E7__wrap4 = current.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_00bd;
					}
					if (num == 3)
					{
						_003C_003E1__state = 2;
						goto IL_00aa;
					}
					goto IL_00d3;
					IL_00bd:
					if (_003C_003E7__wrap4.MoveNext())
					{
						_003Ct_003E5__1 = _003C_003E7__wrap4.Current;
						_003C_003E7__wrap6 = _003C_003E4__this.Indexes.GetEnumerator();
						_003C_003E1__state = 2;
						goto IL_00aa;
					}
					_003C_003Em__Finally5();
					goto IL_00d3;
					IL_00d3:
					return false;
					IL_00aa:
					while (_003C_003E7__wrap6.MoveNext())
					{
						_003Ci_003E5__2 = _003C_003E7__wrap6.Current;
						_003Cv_003E5__3 = PathFilter.GetTokenIndex(_003Ct_003E5__1, errorWhenNoMatch, _003Ci_003E5__2);
						if (_003Cv_003E5__3 != null)
						{
							_003C_003E2__current = _003Cv_003E5__3;
							_003C_003E1__state = 3;
							return true;
						}
					}
					_003C_003Em__Finally7();
					goto IL_00bd;
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
								_003C_003Em__Finally7();
							}
							break;
						}
					}
					finally
					{
						_003C_003Em__Finally5();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CExecuteFilter_003Ed__0(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally5()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap4 != null)
				{
					_003C_003E7__wrap4.Dispose();
				}
			}

			private void _003C_003Em__Finally7()
			{
				_003C_003E1__state = 1;
				((IDisposable)_003C_003E7__wrap6).Dispose();
			}
		}

		public List<int> Indexes
		{
			get;
			set;
		}

		public override IEnumerable<JToken> ExecuteFilter(IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			_003CExecuteFilter_003Ed__0 _003CExecuteFilter_003Ed__ = new _003CExecuteFilter_003Ed__0(-2);
			_003CExecuteFilter_003Ed__._003C_003E4__this = this;
			_003CExecuteFilter_003Ed__._003C_003E3__current = current;
			_003CExecuteFilter_003Ed__._003C_003E3__errorWhenNoMatch = errorWhenNoMatch;
			return _003CExecuteFilter_003Ed__;
		}
	}
}
