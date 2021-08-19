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
	internal class ScanFilter : PathFilter
	{
		[CompilerGenerated]
		private sealed class _003CExecuteFilter_003Ed__0 : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public ScanFilter _003C_003E4__this;

			public IEnumerable<JToken> current;

			public IEnumerable<JToken> _003C_003E3__current;

			public bool errorWhenNoMatch;

			public bool _003C_003E3__errorWhenNoMatch;

			public JToken _003Croot_003E5__1;

			public JToken _003Cvalue_003E5__2;

			public JToken _003Ccontainer_003E5__3;

			public JProperty _003Ce_003E5__4;

			public IEnumerator<JToken> _003C_003E7__wrap5;

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
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003C_003E7__wrap5 = current.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_00df;
					case 2:
						_003C_003E1__state = 1;
						goto IL_0116;
					case 3:
						_003C_003E1__state = 1;
						goto IL_01c5;
					case 4:
						_003C_003E1__state = 1;
						goto IL_01c5;
					default:
						{
							return false;
						}
						IL_00df:
						if (_003C_003E7__wrap5.MoveNext())
						{
							_003Croot_003E5__1 = _003C_003E7__wrap5.Current;
							if (_003C_003E4__this.Name == null)
							{
								_003C_003E2__current = _003Croot_003E5__1;
								_003C_003E1__state = 2;
								return true;
							}
							goto IL_0116;
						}
						_003C_003Em__Finally6();
						goto default;
						IL_01c5:
						_003Ccontainer_003E5__3 = (_003Cvalue_003E5__2 as JContainer);
						goto IL_0143;
						IL_0116:
						_003Cvalue_003E5__2 = _003Croot_003E5__1;
						_003Ccontainer_003E5__3 = _003Croot_003E5__1;
						goto IL_0143;
						IL_0143:
						if (_003Ccontainer_003E5__3 == null || !_003Ccontainer_003E5__3.HasValues)
						{
							while (_003Cvalue_003E5__2 != null && _003Cvalue_003E5__2 != _003Croot_003E5__1 && _003Cvalue_003E5__2 == _003Cvalue_003E5__2.Parent.Last)
							{
								_003Cvalue_003E5__2 = _003Cvalue_003E5__2.Parent;
							}
							if (_003Cvalue_003E5__2 == null || _003Cvalue_003E5__2 == _003Croot_003E5__1)
							{
								goto IL_00df;
							}
							_003Cvalue_003E5__2 = _003Cvalue_003E5__2.Next;
						}
						else
						{
							_003Cvalue_003E5__2 = _003Ccontainer_003E5__3.First;
						}
						_003Ce_003E5__4 = (_003Cvalue_003E5__2 as JProperty);
						if (_003Ce_003E5__4 != null)
						{
							if (_003Ce_003E5__4.Name == _003C_003E4__this.Name)
							{
								_003C_003E2__current = _003Ce_003E5__4.Value;
								_003C_003E1__state = 3;
								return true;
							}
						}
						else if (_003C_003E4__this.Name == null)
						{
							_003C_003E2__current = _003Cvalue_003E5__2;
							_003C_003E1__state = 4;
							return true;
						}
						goto IL_01c5;
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
				case 3:
				case 4:
					try
					{
					}
					finally
					{
						_003C_003Em__Finally6();
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

			private void _003C_003Em__Finally6()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap5 != null)
				{
					_003C_003E7__wrap5.Dispose();
				}
			}
		}

		public string Name
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
