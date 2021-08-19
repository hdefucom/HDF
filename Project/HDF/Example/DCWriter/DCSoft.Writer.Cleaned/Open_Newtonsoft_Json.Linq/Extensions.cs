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

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Contains the LINQ to JSON extension methods.
	///       </summary>
	[ComVisible(false)]
	public static class Extensions
	{
		[CompilerGenerated]
		private sealed class _003CValues_003Ed__6<T, U> : IEnumerable<U>, IEnumerator<U> where T : JToken
		{
			private U _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			public object object_0;

			public object _003C_003E3__key;

			public JToken _003Ctoken_003E5__7;

			public JToken _003Ct_003E5__8;

			public JToken _003Cvalue_003E5__9;

			public IEnumerator<T> _003C_003E7__wrapa;

			public IEnumerator<JToken> _003C_003E7__wrapc;

			U IEnumerator<U>.Current
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
			IEnumerator<U> IEnumerable<U>.GetEnumerator()
			{
				_003CValues_003Ed__6<T, U> _003CValues_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CValues_003Ed__ = this;
				}
				else
				{
					_003CValues_003Ed__ = new _003CValues_003Ed__6<T, U>(0);
				}
				_003CValues_003Ed__.source = _003C_003E3__source;
				_003CValues_003Ed__.object_0 = _003C_003E3__key;
				return _003CValues_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<U>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = 14;
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						ValidationUtils.ArgumentNotNull(source, "source");
						_003C_003E7__wrapa = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0113;
					case 2:
						_003C_003E1__state = 1;
						goto IL_0113;
					case 4:
						_003C_003E1__state = 3;
						goto IL_00dc;
					case 5:
						_003C_003E1__state = 1;
						goto IL_0113;
					default:
						{
							return false;
						}
						IL_0113:
						while (_003C_003E7__wrapa.MoveNext())
						{
							_003Ctoken_003E5__7 = _003C_003E7__wrapa.Current;
							if (object_0 != null)
							{
								_003Cvalue_003E5__9 = _003Ctoken_003E5__7[object_0];
								if (_003Cvalue_003E5__9 != null)
								{
									_003C_003E2__current = Convert<JToken, U>(_003Cvalue_003E5__9);
									_003C_003E1__state = 5;
									return true;
								}
								continue;
							}
							goto IL_00a9;
						}
						_003C_003Em__Finallyb();
						goto default;
						IL_00dc:
						if (_003C_003E7__wrapc.MoveNext())
						{
							_003Ct_003E5__8 = _003C_003E7__wrapc.Current;
							_003C_003E2__current = Convert<JToken, U>(_003Ct_003E5__8);
							_003C_003E1__state = 4;
							return true;
						}
						_003C_003Em__Finallyd();
						goto IL_0113;
						IL_00a9:
						if (_003Ctoken_003E5__7 is JValue)
						{
							_003C_003E2__current = Convert<JValue, U>((JValue)_003Ctoken_003E5__7);
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003E7__wrapc = _003Ctoken_003E5__7.Children().GetEnumerator();
						_003C_003E1__state = 3;
						goto IL_00dc;
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
				case 5:
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
								_003C_003Em__Finallyd();
							}
							break;
						}
					}
					finally
					{
						_003C_003Em__Finallyb();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CValues_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finallyb()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrapa != null)
				{
					_003C_003E7__wrapa.Dispose();
				}
			}

			private void _003C_003Em__Finallyd()
			{
				_003C_003E1__state = 1;
				if (_003C_003E7__wrapc != null)
				{
					_003C_003E7__wrapc.Dispose();
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CConvert_003Ed__11<T, U> : IEnumerable<U>, IEnumerator<U> where T : JToken
		{
			private U _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			public T _003Ctoken_003E5__12;

			public IEnumerator<T> _003C_003E7__wrap13;

			U IEnumerator<U>.Current
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
			IEnumerator<U> IEnumerable<U>.GetEnumerator()
			{
				_003CConvert_003Ed__11<T, U> _003CConvert_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CConvert_003Ed__ = this;
				}
				else
				{
					_003CConvert_003Ed__ = new _003CConvert_003Ed__11<T, U>(0);
				}
				_003CConvert_003Ed__.source = _003C_003E3__source;
				return _003CConvert_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<U>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = 13;
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						ValidationUtils.ArgumentNotNull(source, "source");
						_003C_003E7__wrap13 = source.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0059;
					case 2:
						_003C_003E1__state = 1;
						goto IL_0059;
					default:
						{
							return false;
						}
						IL_0059:
						if (_003C_003E7__wrap13.MoveNext())
						{
							_003Ctoken_003E5__12 = _003C_003E7__wrap13.Current;
							_003C_003E2__current = Convert<JToken, U>(_003Ctoken_003E5__12);
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003Em__Finally14();
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
						_003C_003Em__Finally14();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CConvert_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally14()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap13 != null)
				{
					_003C_003E7__wrap13.Dispose();
				}
			}
		}

		/// <summary>
		///       Returns a collection of tokens that contains the ancestors of every token in the source collection.
		///       </summary>
		/// <typeparam name="T">The type of the objects in source, constrained to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the ancestors of every token in the source collection.</returns>
		public static IJEnumerable<JToken> Ancestors<T>(IEnumerable<T> source) where T : JToken
		{
			ValidationUtils.ArgumentNotNull(source, "source");
			return AsJEnumerable(Enumerable.SelectMany(source, (T gparam_0) => gparam_0.Ancestors()));
		}

		/// <summary>
		///       Returns a collection of tokens that contains every token in the source collection, and the ancestors of every token in the source collection.
		///       </summary>
		/// <typeparam name="T">The type of the objects in source, constrained to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains every token in the source collection, the ancestors of every token in the source collection.</returns>
		public static IJEnumerable<JToken> AncestorsAndSelf<T>(IEnumerable<T> source) where T : JToken
		{
			ValidationUtils.ArgumentNotNull(source, "source");
			return AsJEnumerable(Enumerable.SelectMany(source, (T gparam_0) => gparam_0.AncestorsAndSelf()));
		}

		/// <summary>
		///       Returns a collection of tokens that contains the descendants of every token in the source collection.
		///       </summary>
		/// <typeparam name="T">The type of the objects in source, constrained to <see cref="T:Open_Newtonsoft_Json.Linq.JContainer" />.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the descendants of every token in the source collection.</returns>
		public static IJEnumerable<JToken> Descendants<T>(IEnumerable<T> source) where T : JContainer
		{
			ValidationUtils.ArgumentNotNull(source, "source");
			return AsJEnumerable(Enumerable.SelectMany(source, (T gparam_0) => gparam_0.Descendants()));
		}

		/// <summary>
		///       Returns a collection of tokens that contains every token in the source collection, and the descendants of every token in the source collection.
		///       </summary>
		/// <typeparam name="T">The type of the objects in source, constrained to <see cref="T:Open_Newtonsoft_Json.Linq.JContainer" />.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains every token in the source collection, and the descendants of every token in the source collection.</returns>
		public static IJEnumerable<JToken> DescendantsAndSelf<T>(IEnumerable<T> source) where T : JContainer
		{
			ValidationUtils.ArgumentNotNull(source, "source");
			return AsJEnumerable(Enumerable.SelectMany(source, (T gparam_0) => gparam_0.DescendantsAndSelf()));
		}

		/// <summary>
		///       Returns a collection of child properties of every object in the source collection.
		///       </summary>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JProperty" /> that contains the properties of every object in the source collection.</returns>
		public static IJEnumerable<JProperty> Properties(IEnumerable<JObject> source)
		{
			ValidationUtils.ArgumentNotNull(source, "source");
			return AsJEnumerable(Enumerable.SelectMany(source, (JObject jobject_0) => jobject_0.Properties()));
		}

		/// <summary>
		///       Returns a collection of child values of every object in the source collection with the given key.
		///       </summary>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <param name="key">The token key.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the values of every token in the source collection with the given key.</returns>
		public static IJEnumerable<JToken> Values(IEnumerable<JToken> source, object object_0)
		{
			return AsJEnumerable(Values<JToken, JToken>(source, object_0));
		}

		/// <summary>
		///       Returns a collection of child values of every object in the source collection.
		///       </summary>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the values of every token in the source collection.</returns>
		public static IJEnumerable<JToken> Values(IEnumerable<JToken> source)
		{
			return Values(source, null);
		}

		/// <summary>
		///       Returns a collection of converted child values of every object in the source collection with the given key.
		///       </summary>
		/// <typeparam name="U">The type to convert the values to.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <param name="key">The token key.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the converted values of every token in the source collection with the given key.</returns>
		public static IEnumerable<U> Values<U>(IEnumerable<JToken> source, object object_0)
		{
			return Values<JToken, U>(source, object_0);
		}

		/// <summary>
		///       Returns a collection of converted child values of every object in the source collection.
		///       </summary>
		/// <typeparam name="U">The type to convert the values to.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the converted values of every token in the source collection.</returns>
		public static IEnumerable<U> Values<U>(IEnumerable<JToken> source)
		{
			return Values<JToken, U>(source, null);
		}

		/// <summary>
		///       Converts the value.
		///       </summary>
		/// <typeparam name="U">The type to convert the value to.</typeparam>
		/// <param name="value">A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> cast as a <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</param>
		/// <returns>A converted value.</returns>
		public static U Value<U>(IEnumerable<JToken> value)
		{
			return Value<JToken, U>(value);
		}

		/// <summary>
		///       Converts the value.
		///       </summary>
		/// <typeparam name="T">The source collection type.</typeparam>
		/// <typeparam name="U">The type to convert the value to.</typeparam>
		/// <param name="value">A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> cast as a <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</param>
		/// <returns>A converted value.</returns>
		public static U Value<T, U>(IEnumerable<T> value) where T : JToken
		{
			int num = 16;
			ValidationUtils.ArgumentNotNull(value, "source");
			JToken jToken = value as JToken;
			if (jToken == null)
			{
				throw new ArgumentException("Source value must be a JToken.");
			}
			return Convert<JToken, U>(jToken);
		}

		internal static IEnumerable<U> Values<T, U>(IEnumerable<T> source, object object_0) where T : JToken
		{
			_003CValues_003Ed__6<T, U> _003CValues_003Ed__ = new _003CValues_003Ed__6<T, U>(-2);
			_003CValues_003Ed__._003C_003E3__source = source;
			_003CValues_003Ed__._003C_003E3__key = object_0;
			return _003CValues_003Ed__;
		}

		/// <summary>
		///       Returns a collection of child tokens of every array in the source collection.
		///       </summary>
		/// <typeparam name="T">The source collection type.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the values of every token in the source collection.</returns>
		public static IJEnumerable<JToken> Children<T>(IEnumerable<T> source) where T : JToken
		{
			return AsJEnumerable(Children<T, JToken>(source));
		}

		/// <summary>
		///       Returns a collection of converted child tokens of every array in the source collection.
		///       </summary>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <typeparam name="U">The type to convert the values to.</typeparam>
		/// <typeparam name="T">The source collection type.</typeparam>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the converted values of every token in the source collection.</returns>
		public static IEnumerable<U> Children<T, U>(IEnumerable<T> source) where T : JToken
		{
			ValidationUtils.ArgumentNotNull(source, "source");
			return Convert<JToken, U>(Enumerable.SelectMany(source, (T gparam_0) => gparam_0.Children()));
		}

		internal static IEnumerable<U> Convert<T, U>(IEnumerable<T> source) where T : JToken
		{
			_003CConvert_003Ed__11<T, U> _003CConvert_003Ed__ = new _003CConvert_003Ed__11<T, U>(-2);
			_003CConvert_003Ed__._003C_003E3__source = source;
			return _003CConvert_003Ed__;
		}

		internal static U Convert<T, U>(T token) where T : JToken
		{
			int num = 4;
			if (token == null)
			{
				return default(U);
			}
			if (token is U && typeof(U) != typeof(IComparable) && typeof(U) != typeof(IFormattable))
			{
				return (U)(object)token;
			}
			JValue jValue = token as JValue;
			if (jValue == null)
			{
				throw new InvalidCastException(StringUtils.FormatWith("Cannot cast {0} to {1}.", CultureInfo.InvariantCulture, token.GetType(), typeof(T)));
			}
			if (jValue.Value is U)
			{
				return (U)jValue.Value;
			}
			Type type = typeof(U);
			if (ReflectionUtils.IsNullableType(type))
			{
				if (jValue.Value == null)
				{
					return default(U);
				}
				type = Nullable.GetUnderlyingType(type);
			}
			return (U)System.Convert.ChangeType(jValue.Value, type, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Returns the input typed as <see cref="T:Open_Newtonsoft_Json.Linq.IJEnumerable`1" />.
		///       </summary>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>The input typed as <see cref="T:Open_Newtonsoft_Json.Linq.IJEnumerable`1" />.</returns>
		public static IJEnumerable<JToken> AsJEnumerable(IEnumerable<JToken> source)
		{
			return Extensions.AsJEnumerable<JToken>(source);
		}

		/// <summary>
		///       Returns the input typed as <see cref="T:Open_Newtonsoft_Json.Linq.IJEnumerable`1" />.
		///       </summary>
		/// <typeparam name="T">The source collection type.</typeparam>
		/// <param name="source">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the source collection.</param>
		/// <returns>The input typed as <see cref="T:Open_Newtonsoft_Json.Linq.IJEnumerable`1" />.</returns>
		public static IJEnumerable<T> AsJEnumerable<T>(IEnumerable<T> source) where T : JToken
		{
			if (source == null)
			{
				return null;
			}
			if (source is IJEnumerable<T>)
			{
				return (IJEnumerable<T>)source;
			}
			return new JEnumerable<T>(source);
		}
	}
}
