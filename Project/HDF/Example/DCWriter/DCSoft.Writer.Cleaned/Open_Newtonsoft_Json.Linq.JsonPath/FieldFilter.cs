using Open_Newtonsoft_Json.Utilities;
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
	internal class FieldFilter : PathFilter
	{
		[CompilerGenerated]
		private sealed class _003CExecuteFilter_003Ed__0 : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public FieldFilter _003C_003E4__this;

			public IEnumerable<JToken> current;

			public IEnumerable<JToken> _003C_003E3__current;

			public bool errorWhenNoMatch;

			public bool _003C_003E3__errorWhenNoMatch;

			public JToken _003Ct_003E5__1;

			public JObject _003Co_003E5__2;

			public JToken _003Cv_003E5__3;

			public KeyValuePair<string, JToken> _003Cp_003E5__4;

			public IEnumerator<JToken> _003C_003E7__wrap5;

			public IEnumerator<KeyValuePair<string, JToken>> _003C_003E7__wrap7;

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
				int num = 1;
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003C_003E7__wrap5 = current.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0119;
					case 2:
						_003C_003E1__state = 1;
						goto IL_0119;
					case 4:
						_003C_003E1__state = 3;
						goto IL_0063;
					default:
						{
							return false;
						}
						IL_0119:
						while (_003C_003E7__wrap5.MoveNext())
						{
							_003Ct_003E5__1 = _003C_003E7__wrap5.Current;
							_003Co_003E5__2 = (_003Ct_003E5__1 as JObject);
							if (_003Co_003E5__2 == null)
							{
								if (errorWhenNoMatch)
								{
									throw new JsonException(StringUtils.FormatWith("Property '{0}' not valid on {1}.", CultureInfo.InvariantCulture, _003C_003E4__this.Name ?? "*", _003Ct_003E5__1.GetType().Name));
								}
								continue;
							}
							if (_003C_003E4__this.Name != null)
							{
								_003Cv_003E5__3 = _003Co_003E5__2[_003C_003E4__this.Name];
								if (_003Cv_003E5__3 != null)
								{
									_003C_003E2__current = _003Cv_003E5__3;
									_003C_003E1__state = 2;
									return true;
								}
								if (errorWhenNoMatch)
								{
									throw new JsonException(StringUtils.FormatWith("Property '{0}' does not exist on JObject.", CultureInfo.InvariantCulture, _003C_003E4__this.Name));
								}
								continue;
							}
							goto IL_00fc;
						}
						_003C_003Em__Finally6();
						goto default;
						IL_0063:
						if (_003C_003E7__wrap7.MoveNext())
						{
							_003Cp_003E5__4 = _003C_003E7__wrap7.Current;
							KeyValuePair<string, JToken> keyValuePair = _003Cp_003E5__4;
							_003C_003E2__current = keyValuePair.Value;
							_003C_003E1__state = 4;
							return true;
						}
						_003C_003Em__Finally8();
						goto IL_0119;
						IL_00fc:
						_003C_003E7__wrap7 = _003Co_003E5__2.GetEnumerator();
						_003C_003E1__state = 3;
						goto IL_0063;
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
						switch (_003C_003E1__state)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								_003C_003Em__Finally8();
							}
							break;
						}
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

			private void _003C_003Em__Finally8()
			{
				_003C_003E1__state = 1;
				if (_003C_003E7__wrap7 != null)
				{
					_003C_003E7__wrap7.Dispose();
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
