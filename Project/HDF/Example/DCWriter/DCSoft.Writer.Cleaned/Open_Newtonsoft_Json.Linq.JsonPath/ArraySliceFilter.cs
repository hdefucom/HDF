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
	internal class ArraySliceFilter : PathFilter
	{
		[CompilerGenerated]
		private sealed class _003CExecuteFilter_003Ed__0 : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public ArraySliceFilter _003C_003E4__this;

			public IEnumerable<JToken> current;

			public IEnumerable<JToken> _003C_003E3__current;

			public bool errorWhenNoMatch;

			public bool _003C_003E3__errorWhenNoMatch;

			public JToken _003Ct_003E5__1;

			public JArray _003Ca_003E5__2;

			public int _003CstepCount_003E5__3;

			public int _003CstartIndex_003E5__4;

			public int _003CstopIndex_003E5__5;

			public bool _003CpositiveStep_003E5__6;

			public int _003Ci_003E5__7;

			public IEnumerator<JToken> _003C_003E7__wrap8;

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
				int num = 0;
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
					{
						_003C_003E1__state = -1;
						int? step = _003C_003E4__this.Step;
						if (step.GetValueOrDefault() == 0 && step.HasValue)
						{
							throw new JsonException("Step cannot be zero.");
						}
						_003C_003E7__wrap8 = current.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_02ad;
					}
					case 2:
						_003C_003E1__state = 1;
						_003Ci_003E5__7 += _003CstepCount_003E5__3;
						goto IL_02cb;
					default:
						{
							return false;
						}
						IL_02ad:
						while (_003C_003E7__wrap8.MoveNext())
						{
							_003Ct_003E5__1 = _003C_003E7__wrap8.Current;
							_003Ca_003E5__2 = (_003Ct_003E5__1 as JArray);
							if (_003Ca_003E5__2 == null)
							{
								if (errorWhenNoMatch)
								{
									throw new JsonException(StringUtils.FormatWith("Array slice is not valid on {0}.", CultureInfo.InvariantCulture, _003Ct_003E5__1.GetType().Name));
								}
								continue;
							}
							_003CstepCount_003E5__3 = (_003C_003E4__this.Step ?? 1);
							_003CstartIndex_003E5__4 = (_003C_003E4__this.Start ?? ((_003CstepCount_003E5__3 <= 0) ? (_003Ca_003E5__2.Count - 1) : 0));
							_003CstopIndex_003E5__5 = (_003C_003E4__this.End ?? ((_003CstepCount_003E5__3 > 0) ? _003Ca_003E5__2.Count : (-1)));
							if (_003C_003E4__this.Start < 0)
							{
								_003CstartIndex_003E5__4 = _003Ca_003E5__2.Count + _003CstartIndex_003E5__4;
							}
							if (_003C_003E4__this.End < 0)
							{
								_003CstopIndex_003E5__5 = _003Ca_003E5__2.Count + _003CstopIndex_003E5__5;
							}
							_003CstartIndex_003E5__4 = Math.Max(_003CstartIndex_003E5__4, (_003CstepCount_003E5__3 <= 0) ? int.MinValue : 0);
							_003CstartIndex_003E5__4 = Math.Min(_003CstartIndex_003E5__4, (_003CstepCount_003E5__3 > 0) ? _003Ca_003E5__2.Count : (_003Ca_003E5__2.Count - 1));
							_003CstopIndex_003E5__5 = Math.Max(_003CstopIndex_003E5__5, -1);
							_003CstopIndex_003E5__5 = Math.Min(_003CstopIndex_003E5__5, _003Ca_003E5__2.Count);
							_003CpositiveStep_003E5__6 = (_003CstepCount_003E5__3 > 0);
							if (!_003C_003E4__this.IsValid(_003CstartIndex_003E5__4, _003CstopIndex_003E5__5, _003CpositiveStep_003E5__6))
							{
								if (errorWhenNoMatch)
								{
									throw new JsonException(StringUtils.FormatWith("Array slice of {0} to {1} returned no results.", CultureInfo.InvariantCulture, _003C_003E4__this.Start.HasValue ? _003C_003E4__this.Start.Value.ToString(CultureInfo.InvariantCulture) : "*", _003C_003E4__this.End.HasValue ? _003C_003E4__this.End.Value.ToString(CultureInfo.InvariantCulture) : "*"));
								}
								continue;
							}
							goto IL_02bf;
						}
						_003C_003Em__Finally9();
						goto default;
						IL_02cb:
						if (_003C_003E4__this.IsValid(_003Ci_003E5__7, _003CstopIndex_003E5__5, _003CpositiveStep_003E5__6))
						{
							_003C_003E2__current = _003Ca_003E5__2[_003Ci_003E5__7];
							_003C_003E1__state = 2;
							return true;
						}
						goto IL_02ad;
						IL_02bf:
						_003Ci_003E5__7 = _003CstartIndex_003E5__4;
						goto IL_02cb;
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
						_003C_003Em__Finally9();
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

			private void _003C_003Em__Finally9()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap8 != null)
				{
					_003C_003E7__wrap8.Dispose();
				}
			}
		}

		public int? Start
		{
			get;
			set;
		}

		public int? End
		{
			get;
			set;
		}

		public int? Step
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

		private bool IsValid(int index, int stopIndex, bool positiveStep)
		{
			if (positiveStep)
			{
				return index < stopIndex;
			}
			return index > stopIndex;
		}
	}
}
