using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal class FieldMultipleFilter : PathFilter
	{
		[CompilerGenerated]
		private sealed class _003CExecuteFilter_003Ed__2 : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public FieldMultipleFilter _003C_003E4__this;

			public IEnumerable<JToken> current;

			public IEnumerable<JToken> _003C_003E3__current;

			public bool errorWhenNoMatch;

			public bool _003C_003E3__errorWhenNoMatch;

			public JToken _003Ct_003E5__3;

			public JObject _003Co_003E5__4;

			public string _003Cname_003E5__5;

			public JToken _003Cv_003E5__6;

			public IEnumerator<JToken> _003C_003E7__wrap7;

			public List<string>.Enumerator _003C_003E7__wrap9;

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
				_003CExecuteFilter_003Ed__2 _003CExecuteFilter_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CExecuteFilter_003Ed__ = this;
				}
				else
				{
					_003CExecuteFilter_003Ed__ = new _003CExecuteFilter_003Ed__2(0)
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
				int num = 15;
				try
				{
					int num2 = _003C_003E1__state;
					if (num2 == 0)
					{
						_003C_003E1__state = -1;
						_003C_003E7__wrap7 = current.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_00f7;
					}
					if (num2 == 3)
					{
						_003C_003E1__state = 2;
						goto IL_00cc;
					}
					goto IL_010d;
					IL_010d:
					return false;
					IL_0077:
					_003C_003E7__wrap9 = _003C_003E4__this.Names.GetEnumerator();
					_003C_003E1__state = 2;
					goto IL_00d7;
					IL_00cc:
					if (errorWhenNoMatch)
					{
						throw new JsonException(StringUtils.FormatWith("Property '{0}' does not exist on JObject.", CultureInfo.InvariantCulture, _003Cname_003E5__5));
					}
					goto IL_00d7;
					IL_00f7:
					while (_003C_003E7__wrap7.MoveNext())
					{
						_003Ct_003E5__3 = _003C_003E7__wrap7.Current;
						_003Co_003E5__4 = (_003Ct_003E5__3 as JObject);
						if (_003Co_003E5__4 == null)
						{
							if (errorWhenNoMatch)
							{
								throw new JsonException(StringUtils.FormatWith("Properties {0} not valid on {1}.", CultureInfo.InvariantCulture, string.Join(", ", Enumerable.ToArray(Enumerable.Select(_003C_003E4__this.Names, (string string_0) => "'" + string_0 + "'"))), _003Ct_003E5__3.GetType().Name));
							}
							continue;
						}
						goto IL_0077;
					}
					_003C_003Em__Finally8();
					goto IL_010d;
					IL_00d7:
					if (_003C_003E7__wrap9.MoveNext())
					{
						_003Cname_003E5__5 = _003C_003E7__wrap9.Current;
						_003Cv_003E5__6 = _003Co_003E5__4[_003Cname_003E5__5];
						if (_003Cv_003E5__6 != null)
						{
							_003C_003E2__current = _003Cv_003E5__6;
							_003C_003E1__state = 3;
							return true;
						}
						goto IL_00cc;
					}
					_003C_003Em__Finallya();
					goto IL_00f7;
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
								_003C_003Em__Finallya();
							}
							break;
						}
					}
					finally
					{
						_003C_003Em__Finally8();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CExecuteFilter_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally8()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap7 != null)
				{
					_003C_003E7__wrap7.Dispose();
				}
			}

			private void _003C_003Em__Finallya()
			{
				_003C_003E1__state = 1;
				((IDisposable)_003C_003E7__wrap9).Dispose();
			}
		}

		public List<string> Names
		{
			get;
			set;
		}

		public override IEnumerable<JToken> ExecuteFilter(IEnumerable<JToken> current, bool errorWhenNoMatch)
		{
			_003CExecuteFilter_003Ed__2 _003CExecuteFilter_003Ed__ = new _003CExecuteFilter_003Ed__2(-2);
			_003CExecuteFilter_003Ed__._003C_003E4__this = this;
			_003CExecuteFilter_003Ed__._003C_003E3__current = current;
			_003CExecuteFilter_003Ed__._003C_003E3__errorWhenNoMatch = errorWhenNoMatch;
			return _003CExecuteFilter_003Ed__;
		}
	}
}
