using Open_Newtonsoft_Json.Linq.JsonPath;
using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents an abstract JSON token.
	///       </summary>
	[ComVisible(false)]
	public abstract class JToken : IJEnumerable<JToken>, ICloneable, IJsonLineInfo
	{
		[ComVisible(false)]
		private class LineInfoAnnotation
		{
			internal readonly int LineNumber;

			internal readonly int LinePosition;

			public LineInfoAnnotation(int lineNumber, int linePosition)
			{
				LineNumber = lineNumber;
				LinePosition = linePosition;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAncestors_003Ed__2 : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public JToken _003C_003E4__this;

			public bool self;

			public bool _003C_003E3__self;

			public JToken _003Ccurrent_003E5__3;

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
				_003CGetAncestors_003Ed__2 _003CGetAncestors_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CGetAncestors_003Ed__ = this;
				}
				else
				{
					_003CGetAncestors_003Ed__ = new _003CGetAncestors_003Ed__2(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				_003CGetAncestors_003Ed__.self = _003C_003E3__self;
				return _003CGetAncestors_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JToken>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003Ccurrent_003E5__3 = (self ? _003C_003E4__this : _003C_003E4__this.Parent);
					goto IL_0059;
				case 1:
					_003C_003E1__state = -1;
					_003Ccurrent_003E5__3 = _003Ccurrent_003E5__3.Parent;
					goto IL_0059;
				default:
					{
						return false;
					}
					IL_0059:
					if (_003Ccurrent_003E5__3 != null)
					{
						_003C_003E2__current = _003Ccurrent_003E5__3;
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
			public _003CGetAncestors_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CompilerGenerated]
		private sealed class _003CAfterSelf_003Ed__6 : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public JToken _003C_003E4__this;

			public JToken _003Co_003E5__7;

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
				_003CAfterSelf_003Ed__6 result;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					result = this;
				}
				else
				{
					result = new _003CAfterSelf_003Ed__6(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				return result;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JToken>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					if (_003C_003E4__this.Parent != null)
					{
						_003Co_003E5__7 = _003C_003E4__this.Next;
						goto IL_005c;
					}
					goto default;
				case 1:
					_003C_003E1__state = -1;
					_003Co_003E5__7 = _003Co_003E5__7.Next;
					goto IL_005c;
				default:
					{
						return false;
					}
					IL_005c:
					if (_003Co_003E5__7 != null)
					{
						_003C_003E2__current = _003Co_003E5__7;
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
			public _003CAfterSelf_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CompilerGenerated]
		private sealed class _003CBeforeSelf_003Ed__a : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public JToken _003C_003E4__this;

			public JToken _003Co_003E5__b;

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
				_003CBeforeSelf_003Ed__a result;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					result = this;
				}
				else
				{
					result = new _003CBeforeSelf_003Ed__a(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				return result;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JToken>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					_003Co_003E5__b = _003C_003E4__this.Parent.First;
					goto IL_004e;
				case 1:
					_003C_003E1__state = -1;
					_003Co_003E5__b = _003Co_003E5__b.Next;
					goto IL_004e;
				default:
					{
						return false;
					}
					IL_004e:
					if (_003Co_003E5__b != _003C_003E4__this)
					{
						_003C_003E2__current = _003Co_003E5__b;
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
			public _003CBeforeSelf_003Ed__a(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CompilerGenerated]
		private sealed class _003CAnnotations_003Ed__e<T> : IEnumerable<T>, IEnumerator<T> where T : class
		{
			private T _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public JToken _003C_003E4__this;

			public object[] _003Cannotations_003E5__f;

			public int _003Ci_003E5__10;

			public object _003Co_003E5__11;

			public T _003Ccasted_003E5__12;

			public T _003Cannotation_003E5__13;

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
				_003CAnnotations_003Ed__e<T> result;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					result = this;
				}
				else
				{
					result = new _003CAnnotations_003Ed__e<T>(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				return result;
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
					if (_003C_003E4__this._annotations == null)
					{
						break;
					}
					_003Cannotations_003E5__f = (_003C_003E4__this._annotations as object[]);
					if (_003Cannotations_003E5__f != null)
					{
						_003Ci_003E5__10 = 0;
						goto IL_00b9;
					}
					_003Cannotation_003E5__13 = (_003C_003E4__this._annotations as T);
					if (_003Cannotation_003E5__13 != null)
					{
						_003C_003E2__current = _003Cannotation_003E5__13;
						_003C_003E1__state = 2;
						return true;
					}
					break;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0112;
				case 2:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_00b9:
					if (_003Ci_003E5__10 >= _003Cannotations_003E5__f.Length)
					{
						break;
					}
					_003Co_003E5__11 = _003Cannotations_003E5__f[_003Ci_003E5__10];
					if (_003Co_003E5__11 == null)
					{
						break;
					}
					_003Ccasted_003E5__12 = (_003Co_003E5__11 as T);
					if (_003Ccasted_003E5__12 != null)
					{
						_003C_003E2__current = _003Ccasted_003E5__12;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0112;
					IL_0112:
					_003Ci_003E5__10++;
					goto IL_00b9;
				}
				return false;
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
			public _003CAnnotations_003Ed__e(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CompilerGenerated]
		private sealed class _003CAnnotations_003Ed__16 : IEnumerable<object>, IEnumerator<object>
		{
			private object _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public JToken _003C_003E4__this;

			public Type type;

			public Type _003C_003E3__type;

			public object[] _003Cannotations_003E5__17;

			public int _003Ci_003E5__18;

			public object _003Co_003E5__19;

			object IEnumerator<object>.Current
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
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				_003CAnnotations_003Ed__16 _003CAnnotations_003Ed__;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CAnnotations_003Ed__ = this;
				}
				else
				{
					_003CAnnotations_003Ed__ = new _003CAnnotations_003Ed__16(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				_003CAnnotations_003Ed__.type = _003C_003E3__type;
				return _003CAnnotations_003Ed__;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<object>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = 13;
				switch (_003C_003E1__state)
				{
				case 0:
					_003C_003E1__state = -1;
					if (type == null)
					{
						throw new ArgumentNullException("type");
					}
					if (_003C_003E4__this._annotations == null)
					{
						break;
					}
					_003Cannotations_003E5__17 = (_003C_003E4__this._annotations as object[]);
					if (_003Cannotations_003E5__17 != null)
					{
						_003Ci_003E5__18 = 0;
						goto IL_00c7;
					}
					if (type.IsInstanceOfType(_003C_003E4__this._annotations))
					{
						_003C_003E2__current = _003C_003E4__this._annotations;
						_003C_003E1__state = 2;
						return true;
					}
					break;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0110;
				case 2:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_00c7:
					if (_003Ci_003E5__18 >= _003Cannotations_003E5__17.Length)
					{
						break;
					}
					_003Co_003E5__19 = _003Cannotations_003E5__17[_003Ci_003E5__18];
					if (_003Co_003E5__19 == null)
					{
						break;
					}
					if (type.IsInstanceOfType(_003Co_003E5__19))
					{
						_003C_003E2__current = _003Co_003E5__19;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0110;
					IL_0110:
					_003Ci_003E5__18++;
					goto IL_00c7;
				}
				return false;
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
			public _003CAnnotations_003Ed__16(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private static JTokenEqualityComparer _equalityComparer;

		private JContainer _parent;

		private JToken _previous;

		private JToken _next;

		private object _annotations;

		private static readonly JTokenType[] BooleanTypes = new JTokenType[6]
		{
			JTokenType.Integer,
			JTokenType.Float,
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw,
			JTokenType.Boolean
		};

		private static readonly JTokenType[] NumberTypes = new JTokenType[6]
		{
			JTokenType.Integer,
			JTokenType.Float,
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw,
			JTokenType.Boolean
		};

		private static readonly JTokenType[] StringTypes = new JTokenType[11]
		{
			JTokenType.Date,
			JTokenType.Integer,
			JTokenType.Float,
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw,
			JTokenType.Boolean,
			JTokenType.Bytes,
			JTokenType.Guid,
			JTokenType.TimeSpan,
			JTokenType.Uri
		};

		private static readonly JTokenType[] GuidTypes = new JTokenType[5]
		{
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw,
			JTokenType.Guid,
			JTokenType.Bytes
		};

		private static readonly JTokenType[] TimeSpanTypes = new JTokenType[4]
		{
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw,
			JTokenType.TimeSpan
		};

		private static readonly JTokenType[] UriTypes = new JTokenType[4]
		{
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw,
			JTokenType.Uri
		};

		private static readonly JTokenType[] CharTypes = new JTokenType[5]
		{
			JTokenType.Integer,
			JTokenType.Float,
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw
		};

		private static readonly JTokenType[] DateTimeTypes = new JTokenType[4]
		{
			JTokenType.Date,
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw
		};

		private static readonly JTokenType[] BytesTypes = new JTokenType[5]
		{
			JTokenType.Bytes,
			JTokenType.String,
			JTokenType.Comment,
			JTokenType.Raw,
			JTokenType.Integer
		};

		/// <summary>
		///       Gets a comparer that can compare two tokens for value equality.
		///       </summary>
		/// <value>A <see cref="T:Open_Newtonsoft_Json.Linq.JTokenEqualityComparer" /> that can compare two nodes for value equality.</value>
		public static JTokenEqualityComparer EqualityComparer
		{
			get
			{
				if (_equalityComparer == null)
				{
					_equalityComparer = new JTokenEqualityComparer();
				}
				return _equalityComparer;
			}
		}

		/// <summary>
		///       Gets or sets the parent.
		///       </summary>
		/// <value>The parent.</value>
		public JContainer Parent
		{
			[DebuggerStepThrough]
			get
			{
				return _parent;
			}
			internal set
			{
				_parent = value;
			}
		}

		/// <summary>
		///       Gets the root <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <value>The root <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</value>
		public JToken Root
		{
			get
			{
				JContainer parent = Parent;
				if (parent == null)
				{
					return this;
				}
				while (parent.Parent != null)
				{
					parent = parent.Parent;
				}
				return parent;
			}
		}

		/// <summary>
		///       Gets the node type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <value>The type.</value>
		public abstract JTokenType Type
		{
			get;
		}

		/// <summary>
		///       Gets a value indicating whether this token has child tokens.
		///       </summary>
		/// <value>
		///   <c>true</c> if this token has child values; otherwise, <c>false</c>.
		///       </value>
		public abstract bool HasValues
		{
			get;
		}

		/// <summary>
		///       Gets the next sibling token of this node.
		///       </summary>
		/// <value>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the next sibling token.</value>
		public JToken Next
		{
			get
			{
				return _next;
			}
			internal set
			{
				_next = value;
			}
		}

		/// <summary>
		///       Gets the previous sibling token of this node.
		///       </summary>
		/// <value>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the previous sibling token.</value>
		public JToken Previous
		{
			get
			{
				return _previous;
			}
			internal set
			{
				_previous = value;
			}
		}

		/// <summary>
		///       Gets the path of the JSON token. 
		///       </summary>
		public string Path
		{
			get
			{
				if (Parent == null)
				{
					return string.Empty;
				}
				IList<JToken> list = Enumerable.ToList(Enumerable.Reverse(AncestorsAndSelf()));
				IList<JsonPosition> list2 = new List<JsonPosition>();
				for (int i = 0; i < list.Count; i++)
				{
					JToken jToken = list[i];
					JToken jToken2 = null;
					if (i + 1 < list.Count)
					{
						jToken2 = list[i + 1];
					}
					else if (list[i].Type == JTokenType.Property)
					{
						jToken2 = list[i];
					}
					if (jToken2 != null)
					{
						switch (jToken.Type)
						{
						case JTokenType.Array:
						case JTokenType.Constructor:
						{
							int position = ((IList<JToken>)jToken).IndexOf(jToken2);
							list2.Add(new JsonPosition(JsonContainerType.Array)
							{
								Position = position
							});
							break;
						}
						case JTokenType.Property:
						{
							JProperty jProperty = (JProperty)jToken;
							list2.Add(new JsonPosition(JsonContainerType.Object)
							{
								PropertyName = jProperty.Name
							});
							break;
						}
						}
					}
				}
				return JsonPosition.BuildPath(list2);
			}
		}

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.
		///       </summary>
		/// <value>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.</value>
		public virtual JToken this[object object_0]
		{
			get
			{
				throw new InvalidOperationException(StringUtils.FormatWith("Cannot access child value on {0}.", CultureInfo.InvariantCulture, GetType()));
			}
			set
			{
				throw new InvalidOperationException(StringUtils.FormatWith("Cannot set child value on {0}.", CultureInfo.InvariantCulture, GetType()));
			}
		}

		/// <summary>
		///       Get the first child token of this token.
		///       </summary>
		/// <value>A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> containing the first child token of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</value>
		public virtual JToken First
		{
			get
			{
				throw new InvalidOperationException(StringUtils.FormatWith("Cannot access child value on {0}.", CultureInfo.InvariantCulture, GetType()));
			}
		}

		/// <summary>
		///       Get the last child token of this token.
		///       </summary>
		/// <value>A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> containing the last child token of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</value>
		public virtual JToken Last
		{
			get
			{
				throw new InvalidOperationException(StringUtils.FormatWith("Cannot access child value on {0}.", CultureInfo.InvariantCulture, GetType()));
			}
		}

		IJEnumerable<JToken> IJEnumerable<JToken>.this[object object_0] => this[object_0];

		int IJsonLineInfo.LineNumber => Annotation<LineInfoAnnotation>()?.LineNumber ?? 0;

		int IJsonLineInfo.LinePosition => Annotation<LineInfoAnnotation>()?.LinePosition ?? 0;

		internal abstract JToken CloneToken();

		internal abstract bool DeepEquals(JToken node);

		/// <summary>
		///       Compares the values of two tokens, including the values of all descendant tokens.
		///       </summary>
		/// <param name="t1">The first <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to compare.</param>
		/// <param name="t2">The second <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to compare.</param>
		/// <returns>true if the tokens are equal; otherwise false.</returns>
		public static bool DeepEquals(JToken jtoken_0, JToken jtoken_1)
		{
			return jtoken_0 == jtoken_1 || (jtoken_0 != null && jtoken_1 != null && jtoken_0.DeepEquals(jtoken_1));
		}

		internal JToken()
		{
		}

		/// <summary>
		///       Adds the specified content immediately after this token.
		///       </summary>
		/// <param name="content">A content object that contains simple content or a collection of content objects to be added after this token.</param>
		public void AddAfterSelf(object content)
		{
			int num = 4;
			if (_parent == null)
			{
				throw new InvalidOperationException("The parent is missing.");
			}
			int num2 = _parent.IndexOfItem(this);
			_parent.AddInternal(num2 + 1, content, skipParentCheck: false);
		}

		/// <summary>
		///       Adds the specified content immediately before this token.
		///       </summary>
		/// <param name="content">A content object that contains simple content or a collection of content objects to be added before this token.</param>
		public void AddBeforeSelf(object content)
		{
			int num = 16;
			if (_parent == null)
			{
				throw new InvalidOperationException("The parent is missing.");
			}
			int index = _parent.IndexOfItem(this);
			_parent.AddInternal(index, content, skipParentCheck: false);
		}

		/// <summary>
		///       Returns a collection of the ancestor tokens of this token.
		///       </summary>
		/// <returns>A collection of the ancestor tokens of this token.</returns>
		public IEnumerable<JToken> Ancestors()
		{
			return GetAncestors(self: false);
		}

		/// <summary>
		///       Returns a collection of tokens that contain this token, and the ancestors of this token.
		///       </summary>
		/// <returns>A collection of tokens that contain this token, and the ancestors of this token.</returns>
		public IEnumerable<JToken> AncestorsAndSelf()
		{
			return GetAncestors(self: true);
		}

		internal IEnumerable<JToken> GetAncestors(bool self)
		{
			_003CGetAncestors_003Ed__2 _003CGetAncestors_003Ed__ = new _003CGetAncestors_003Ed__2(-2);
			_003CGetAncestors_003Ed__._003C_003E4__this = this;
			_003CGetAncestors_003Ed__._003C_003E3__self = self;
			return _003CGetAncestors_003Ed__;
		}

		/// <summary>
		///       Returns a collection of the sibling tokens after this token, in document order.
		///       </summary>
		/// <returns>A collection of the sibling tokens after this tokens, in document order.</returns>
		public IEnumerable<JToken> AfterSelf()
		{
			_003CAfterSelf_003Ed__6 _003CAfterSelf_003Ed__ = new _003CAfterSelf_003Ed__6(-2);
			_003CAfterSelf_003Ed__._003C_003E4__this = this;
			return _003CAfterSelf_003Ed__;
		}

		/// <summary>
		///       Returns a collection of the sibling tokens before this token, in document order.
		///       </summary>
		/// <returns>A collection of the sibling tokens before this token, in document order.</returns>
		public IEnumerable<JToken> BeforeSelf()
		{
			_003CBeforeSelf_003Ed__a _003CBeforeSelf_003Ed__a = new _003CBeforeSelf_003Ed__a(-2);
			_003CBeforeSelf_003Ed__a._003C_003E4__this = this;
			return _003CBeforeSelf_003Ed__a;
		}

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key converted to the specified type.
		///       </summary>
		/// <typeparam name="T">The type to convert the token to.</typeparam>
		/// <param name="key">The token key.</param>
		/// <returns>The converted token value.</returns>
		public virtual T Value<T>(object object_0)
		{
			JToken jToken = this[object_0];
			return (jToken == null) ? default(T) : Extensions.Convert<JToken, T>(jToken);
		}

		/// <summary>
		///       Returns a collection of the child tokens of this token, in document order.
		///       </summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> containing the child tokens of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />, in document order.</returns>
		public virtual JEnumerable<JToken> Children()
		{
			return JEnumerable<JToken>.Empty;
		}

		/// <summary>
		///       Returns a collection of the child tokens of this token, in document order, filtered by the specified type.
		///       </summary>
		/// <typeparam name="T">The type to filter the child tokens on.</typeparam>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JEnumerable`1" /> containing the child tokens of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />, in document order.</returns>
		public JEnumerable<T> Children<T>() where T : JToken
		{
			return new JEnumerable<T>(Enumerable.OfType<T>(Children()));
		}

		/// <summary>
		///       Returns a collection of the child values of this token, in document order.
		///       </summary>
		/// <typeparam name="T">The type to convert the values to.</typeparam>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the child values of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />, in document order.</returns>
		public virtual IEnumerable<T> Values<T>()
		{
			throw new InvalidOperationException(StringUtils.FormatWith("Cannot access child value on {0}.", CultureInfo.InvariantCulture, GetType()));
		}

		/// <summary>
		///       Removes this token from its parent.
		///       </summary>
		public void Remove()
		{
			int num = 3;
			if (_parent == null)
			{
				throw new InvalidOperationException("The parent is missing.");
			}
			_parent.RemoveItem(this);
		}

		/// <summary>
		///       Replaces this token with the specified token.
		///       </summary>
		/// <param name="value">The value.</param>
		public void Replace(JToken value)
		{
			int num = 8;
			if (_parent == null)
			{
				throw new InvalidOperationException("The parent is missing.");
			}
			_parent.ReplaceItem(this, value);
		}

		/// <summary>
		///       Writes this token to a <see cref="T:Open_Newtonsoft_Json.JsonWriter" />.
		///       </summary>
		/// <param name="writer">A <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> into which this method will write.</param>
		/// <param name="converters">A collection of <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> which will be used when writing the token.</param>
		public abstract void WriteTo(JsonWriter writer, params JsonConverter[] converters);

		/// <summary>
		///       Returns the indented JSON for this token.
		///       </summary>
		/// <returns>
		///       The indented JSON for this token.
		///       </returns>
		public override string ToString()
		{
			return ToString(Formatting.Indented);
		}

		/// <summary>
		///       Returns the JSON for this token using the given formatting and converters.
		///       </summary>
		/// <param name="formatting">Indicates how the output is formatted.</param>
		/// <param name="converters">A collection of <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> which will be used when writing the token.</param>
		/// <returns>The JSON for this token using the given formatting and converters.</returns>
		public string ToString(Formatting formatting, params JsonConverter[] converters)
		{
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter);
				jsonTextWriter.Formatting = formatting;
				WriteTo(jsonTextWriter, converters);
				return stringWriter.ToString();
			}
		}

		private static JValue EnsureValue(JToken value)
		{
			int num = 6;
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value is JProperty)
			{
				value = ((JProperty)value).Value;
			}
			return value as JValue;
		}

		private static string GetType(JToken token)
		{
			ValidationUtils.ArgumentNotNull(token, "token");
			if (token is JProperty)
			{
				token = ((JProperty)token).Value;
			}
			return token.Type.ToString();
		}

		private static bool ValidateToken(JToken jtoken_0, JTokenType[] validTypes, bool nullable)
		{
			return Array.IndexOf(validTypes, jtoken_0.Type) != -1 || (nullable && (jtoken_0.Type == JTokenType.Null || jtoken_0.Type == JTokenType.Undefined));
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Boolean" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator bool(JToken value)
		{
			int num = 7;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, BooleanTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Boolean.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToBoolean(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator bool?(JToken value)
		{
			int num = 0;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, BooleanTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Boolean.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new bool?(Convert.ToBoolean(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Int64" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator long(JToken value)
		{
			int num = 12;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Int64.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToInt64(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator DateTime?(JToken value)
		{
			int num = 9;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, DateTimeTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to DateTime.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new DateTime?(Convert.ToDateTime(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator decimal?(JToken value)
		{
			int num = 8;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Decimal.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new decimal?(Convert.ToDecimal(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator double?(JToken value)
		{
			int num = 2;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Double.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new double?(Convert.ToDouble(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator char?(JToken value)
		{
			int num = 1;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, CharTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Char.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new char?(Convert.ToChar(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Int32" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator int(JToken value)
		{
			int num = 2;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Int32.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToInt32(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Int16" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator short(JToken value)
		{
			int num = 18;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Int16.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToInt16(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.UInt16" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator ushort(JToken value)
		{
			int num = 17;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to UInt16.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToUInt16(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Char" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator char(JToken value)
		{
			int num = 1;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, CharTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Char.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToChar(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Byte" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator byte(JToken value)
		{
			int num = 0;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Byte.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToByte(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.SByte" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator sbyte(JToken value)
		{
			int num = 7;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to SByte.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToSByte(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator int?(JToken value)
		{
			int num = 4;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Int32.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new int?(Convert.ToInt32(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator short?(JToken value)
		{
			int num = 6;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Int16.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new short?(Convert.ToInt16(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator ushort?(JToken value)
		{
			int num = 18;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to UInt16.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new ushort?(Convert.ToUInt16(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator byte?(JToken value)
		{
			int num = 2;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Byte.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new byte?(Convert.ToByte(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator sbyte?(JToken value)
		{
			int num = 9;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to SByte.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new sbyte?(Convert.ToSByte(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.DateTime" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator DateTime(JToken value)
		{
			int num = 16;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, DateTimeTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to DateTime.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToDateTime(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator long?(JToken value)
		{
			int num = 18;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Int64.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new long?(Convert.ToInt64(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator float?(JToken value)
		{
			int num = 0;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Single.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new float?(Convert.ToSingle(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Decimal" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator decimal(JToken value)
		{
			int num = 14;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Decimal.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToDecimal(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator uint?(JToken value)
		{
			int num = 9;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to UInt32.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new uint?(Convert.ToUInt32(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator ulong?(JToken value)
		{
			int num = 18;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to UInt64.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value != null) ? new ulong?(Convert.ToUInt64(jValue.Value, CultureInfo.InvariantCulture)) : null;
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Double" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator double(JToken value)
		{
			int num = 10;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Double.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToDouble(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Single" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator float(JToken value)
		{
			int num = 0;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Single.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToSingle(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.String" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator string(JToken value)
		{
			int num = 13;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, StringTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to String.", CultureInfo.InvariantCulture, GetType(value)));
			}
			if (jValue.Value == null)
			{
				return null;
			}
			if (jValue.Value is byte[])
			{
				return Convert.ToBase64String((byte[])jValue.Value);
			}
			return Convert.ToString(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.UInt32" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator uint(JToken value)
		{
			int num = 12;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to UInt32.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToUInt32(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.UInt64" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		[CLSCompliant(false)]
		public static explicit operator ulong(JToken value)
		{
			int num = 7;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, NumberTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to UInt64.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return Convert.ToUInt64(jValue.Value, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Byte" />[].
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator byte[](JToken value)
		{
			int num = 8;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, BytesTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to byte array.", CultureInfo.InvariantCulture, GetType(value)));
			}
			if (jValue.Value is string)
			{
				return Convert.FromBase64String(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
			}
			if (jValue.Value is byte[])
			{
				return (byte[])jValue.Value;
			}
			throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to byte array.", CultureInfo.InvariantCulture, GetType(value)));
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Guid" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator Guid(JToken value)
		{
			int num = 14;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, GuidTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Guid.", CultureInfo.InvariantCulture, GetType(value)));
			}
			if (jValue.Value is byte[])
			{
				return new Guid((byte[])jValue.Value);
			}
			return (jValue.Value is Guid) ? ((Guid)jValue.Value) : new Guid(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Guid" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator Guid?(JToken value)
		{
			int num = 7;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, GuidTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Guid.", CultureInfo.InvariantCulture, GetType(value)));
			}
			if (jValue.Value == null)
			{
				return null;
			}
			if (jValue.Value is byte[])
			{
				return new Guid((byte[])jValue.Value);
			}
			return (jValue.Value is Guid) ? ((Guid)jValue.Value) : new Guid(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.TimeSpan" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator TimeSpan(JToken value)
		{
			int num = 15;
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, TimeSpanTypes, nullable: false))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to TimeSpan.", CultureInfo.InvariantCulture, GetType(value)));
			}
			return (jValue.Value is TimeSpan) ? ((TimeSpan)jValue.Value) : ConvertUtils.ParseTimeSpan(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.TimeSpan" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator TimeSpan?(JToken value)
		{
			int num = 1;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, TimeSpanTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to TimeSpan.", CultureInfo.InvariantCulture, GetType(value)));
			}
			if (jValue.Value == null)
			{
				return null;
			}
			return (jValue.Value is TimeSpan) ? ((TimeSpan)jValue.Value) : ConvertUtils.ParseTimeSpan(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}

		/// <summary>
		///       Performs an explicit conversion from <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> to <see cref="T:System.Uri" />.
		///       </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator Uri(JToken value)
		{
			int num = 17;
			if (value == null)
			{
				return null;
			}
			JValue jValue = EnsureValue(value);
			if (jValue == null || !ValidateToken(jValue, UriTypes, nullable: true))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not convert {0} to Uri.", CultureInfo.InvariantCulture, GetType(value)));
			}
			if (jValue.Value == null)
			{
				return null;
			}
			return (jValue.Value is Uri) ? ((Uri)jValue.Value) : new Uri(Convert.ToString(jValue.Value, CultureInfo.InvariantCulture));
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Boolean" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(bool value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Byte" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(byte value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(byte? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.SByte" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(sbyte value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(sbyte? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(bool? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(long value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(DateTime? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(decimal? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(double? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Int16" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(short value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.UInt16" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(ushort value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Int32" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(int value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(int? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.DateTime" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(DateTime value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(long? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(float? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Decimal" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(decimal value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(short? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(ushort? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(uint? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(ulong? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Double" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(double value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Single" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(float value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(string value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.UInt32" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(uint value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.UInt64" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		[CLSCompliant(false)]
		public static implicit operator JToken(ulong value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Byte" />[] to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(byte[] value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Uri" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(Uri value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.TimeSpan" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(TimeSpan value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(TimeSpan? value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Guid" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(Guid value)
		{
			return new JValue(value);
		}

		/// <summary>
		///       Performs an implicit conversion from <see cref="T:System.Nullable`1" /> to <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="value">The value to create a <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> from.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JValue" /> initialized with the specified value.</returns>
		public static implicit operator JToken(Guid? value)
		{
			return new JValue(value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<JToken>)this).GetEnumerator();
		}

		IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator()
		{
			return Children().GetEnumerator();
		}

		internal abstract int GetDeepHashCode();

		/// <summary>
		///       Creates an <see cref="T:Open_Newtonsoft_Json.JsonReader" /> for this token.
		///       </summary>
		/// <returns>An <see cref="T:Open_Newtonsoft_Json.JsonReader" /> that can be used to read this token and its descendants.</returns>
		public JsonReader CreateReader()
		{
			return new JTokenReader(this, Path);
		}

		internal static JToken FromObjectInternal(object object_0, JsonSerializer jsonSerializer)
		{
			ValidationUtils.ArgumentNotNull(object_0, "o");
			ValidationUtils.ArgumentNotNull(jsonSerializer, "jsonSerializer");
			using (JTokenWriter jTokenWriter = new JTokenWriter())
			{
				jsonSerializer.Serialize(jTokenWriter, object_0);
				return jTokenWriter.Token;
			}
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> from an object.
		///       </summary>
		/// <param name="o">The object that will be used to create <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the value of the specified object</returns>
		public static JToken FromObject(object object_0)
		{
			return FromObjectInternal(object_0, JsonSerializer.CreateDefault());
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> from an object using the specified <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
		///       </summary>
		/// <param name="o">The object that will be used to create <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</param>
		/// <param name="jsonSerializer">The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> that will be used when reading the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the value of the specified object</returns>
		public static JToken FromObject(object object_0, JsonSerializer jsonSerializer)
		{
			return FromObjectInternal(object_0, jsonSerializer);
		}

		/// <summary>
		///       Creates the specified .NET type from the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <typeparam name="T">The object type that the token will be deserialized to.</typeparam>
		/// <returns>The new object created from the JSON value.</returns>
		public T ToObject<T>()
		{
			return (T)ToObject(typeof(T));
		}

		/// <summary>
		///       Creates the specified .NET type from the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="objectType">The object type that the token will be deserialized to.</param>
		/// <returns>The new object created from the JSON value.</returns>
		public object ToObject(Type objectType)
		{
			int num = 0;
			if (JsonConvert.DefaultSettings == null)
			{
				bool isEnum;
				PrimitiveTypeCode typeCode = ConvertUtils.GetTypeCode(objectType, out isEnum);
				if (isEnum && Type == JTokenType.String)
				{
					Type type = TypeExtensions.IsEnum(objectType) ? objectType : Nullable.GetUnderlyingType(objectType);
					try
					{
						return Enum.Parse(type, (string)this, ignoreCase: true);
					}
					catch (Exception innerException)
					{
						throw new ArgumentException(StringUtils.FormatWith("Could not convert '{0}' to {1}.", CultureInfo.InvariantCulture, (string)this, type.Name), innerException);
					}
				}
				switch (typeCode)
				{
				case PrimitiveTypeCode.Char:
					return (char)this;
				case PrimitiveTypeCode.CharNullable:
					return (char?)this;
				case PrimitiveTypeCode.Boolean:
					return (bool)this;
				case PrimitiveTypeCode.BooleanNullable:
					return (bool?)this;
				case PrimitiveTypeCode.SByte:
					return (sbyte?)this;
				case PrimitiveTypeCode.SByteNullable:
					return (sbyte)this;
				case PrimitiveTypeCode.Int16:
					return (short)this;
				case PrimitiveTypeCode.Int16Nullable:
					return (short?)this;
				case PrimitiveTypeCode.UInt16:
					return (ushort)this;
				case PrimitiveTypeCode.UInt16Nullable:
					return (ushort?)this;
				case PrimitiveTypeCode.Int32:
					return (int)this;
				case PrimitiveTypeCode.Int32Nullable:
					return (int?)this;
				case PrimitiveTypeCode.Byte:
					return (byte)this;
				case PrimitiveTypeCode.ByteNullable:
					return (byte?)this;
				case PrimitiveTypeCode.UInt32:
					return (uint)this;
				case PrimitiveTypeCode.UInt32Nullable:
					return (uint?)this;
				case PrimitiveTypeCode.Int64:
					return (long)this;
				case PrimitiveTypeCode.Int64Nullable:
					return (long?)this;
				case PrimitiveTypeCode.UInt64:
					return (ulong)this;
				case PrimitiveTypeCode.UInt64Nullable:
					return (ulong?)this;
				case PrimitiveTypeCode.Single:
					return (float)this;
				case PrimitiveTypeCode.SingleNullable:
					return (float?)this;
				case PrimitiveTypeCode.Double:
					return (double)this;
				case PrimitiveTypeCode.DoubleNullable:
					return (double?)this;
				case PrimitiveTypeCode.DateTime:
					return (DateTime)this;
				case PrimitiveTypeCode.DateTimeNullable:
					return (DateTime?)this;
				case PrimitiveTypeCode.Decimal:
					return (decimal)this;
				case PrimitiveTypeCode.DecimalNullable:
					return (decimal?)this;
				case PrimitiveTypeCode.Guid:
					return (Guid)this;
				case PrimitiveTypeCode.GuidNullable:
					return (Guid?)this;
				case PrimitiveTypeCode.TimeSpan:
					return (TimeSpan)this;
				case PrimitiveTypeCode.TimeSpanNullable:
					return (TimeSpan?)this;
				case PrimitiveTypeCode.Uri:
					return (Uri)this;
				case PrimitiveTypeCode.String:
					return (string)this;
				}
			}
			return ToObject(objectType, JsonSerializer.CreateDefault());
		}

		/// <summary>
		///       Creates the specified .NET type from the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> using the specified <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
		///       </summary>
		/// <typeparam name="T">The object type that the token will be deserialized to.</typeparam>
		/// <param name="jsonSerializer">The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> that will be used when creating the object.</param>
		/// <returns>The new object created from the JSON value.</returns>
		public T ToObject<T>(JsonSerializer jsonSerializer)
		{
			return (T)ToObject(typeof(T), jsonSerializer);
		}

		/// <summary>
		///       Creates the specified .NET type from the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> using the specified <see cref="T:Open_Newtonsoft_Json.JsonSerializer" />.
		///       </summary>
		/// <param name="objectType">The object type that the token will be deserialized to.</param>
		/// <param name="jsonSerializer">The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> that will be used when creating the object.</param>
		/// <returns>The new object created from the JSON value.</returns>
		public object ToObject(Type objectType, JsonSerializer jsonSerializer)
		{
			ValidationUtils.ArgumentNotNull(jsonSerializer, "jsonSerializer");
			using (JTokenReader reader = new JTokenReader(this))
			{
				return jsonSerializer.Deserialize(reader, objectType);
			}
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> from a <see cref="T:Open_Newtonsoft_Json.JsonReader" />.
		///       </summary>
		/// <param name="reader">An <see cref="T:Open_Newtonsoft_Json.JsonReader" /> positioned at the token to read into this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</param>
		/// <returns>
		///       An <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the token and its descendant tokens
		///       that were read from the reader. The runtime type of the token is determined
		///       by the token type of the first token encountered in the reader.
		///       </returns>
		public static JToken ReadFrom(JsonReader reader)
		{
			int num = 14;
			ValidationUtils.ArgumentNotNull(reader, "reader");
			if (reader.TokenType == JsonToken.None && !reader.Read())
			{
				throw JsonReaderException.Create(reader, "Error reading JToken from JsonReader.");
			}
			IJsonLineInfo lineInfo = reader as IJsonLineInfo;
			switch (reader.TokenType)
			{
			case JsonToken.StartObject:
				return JObject.Load(reader);
			case JsonToken.StartArray:
				return JArray.Load(reader);
			case JsonToken.StartConstructor:
				return JConstructor.Load(reader);
			case JsonToken.PropertyName:
				return JProperty.Load(reader);
			case JsonToken.Comment:
			{
				JValue jValue = JValue.CreateComment(reader.Value.ToString());
				jValue.SetLineInfo(lineInfo);
				return jValue;
			}
			case JsonToken.Null:
			{
				JValue jValue = JValue.CreateNull();
				jValue.SetLineInfo(lineInfo);
				return jValue;
			}
			case JsonToken.Undefined:
			{
				JValue jValue = JValue.CreateUndefined();
				jValue.SetLineInfo(lineInfo);
				return jValue;
			}
			default:
				throw JsonReaderException.Create(reader, StringUtils.FormatWith("Error reading JToken from JsonReader. Unexpected token: {0}", CultureInfo.InvariantCulture, reader.TokenType));
			case JsonToken.Integer:
			case JsonToken.Float:
			case JsonToken.String:
			case JsonToken.Boolean:
			case JsonToken.Date:
			case JsonToken.Bytes:
			{
				JValue jValue = new JValue(reader.Value);
				jValue.SetLineInfo(lineInfo);
				return jValue;
			}
			}
		}

		/// <summary>
		///       Load a <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> from a string that contains JSON.
		///       </summary>
		/// <param name="json">A <see cref="T:System.String" /> that contains JSON.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> populated from the string that contains JSON.</returns>
		public static JToken Parse(string json)
		{
			int num = 14;
			using (JsonReader jsonReader = new JsonTextReader(new StringReader(json)))
			{
				JToken result = Load(jsonReader);
				if (jsonReader.Read() && jsonReader.TokenType != JsonToken.Comment)
				{
					throw JsonReaderException.Create(jsonReader, "Additional text found in JSON string after parsing content.");
				}
				return result;
			}
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> from a <see cref="T:Open_Newtonsoft_Json.JsonReader" />.
		///       </summary>
		/// <param name="reader">An <see cref="T:Open_Newtonsoft_Json.JsonReader" /> positioned at the token to read into this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</param>
		/// <returns>
		///       An <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> that contains the token and its descendant tokens
		///       that were read from the reader. The runtime type of the token is determined
		///       by the token type of the first token encountered in the reader.
		///       </returns>
		public static JToken Load(JsonReader reader)
		{
			return ReadFrom(reader);
		}

		internal void SetLineInfo(IJsonLineInfo lineInfo)
		{
			if (lineInfo?.HasLineInfo() ?? false)
			{
				SetLineInfo(lineInfo.LineNumber, lineInfo.LinePosition);
			}
		}

		internal void SetLineInfo(int lineNumber, int linePosition)
		{
			AddAnnotation(new LineInfoAnnotation(lineNumber, linePosition));
		}

		bool IJsonLineInfo.HasLineInfo()
		{
			return Annotation<LineInfoAnnotation>() != null;
		}

		/// <summary>
		///       Selects a <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> using a JPath expression. Selects the token that matches the object path.
		///       </summary>
		/// <param name="path">
		///       A <see cref="T:System.String" /> that contains a JPath expression.
		///       </param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />, or null.</returns>
		public JToken SelectToken(string path)
		{
			return SelectToken(path, errorWhenNoMatch: false);
		}

		/// <summary>
		///       Selects a <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> using a JPath expression. Selects the token that matches the object path.
		///       </summary>
		/// <param name="path">
		///       A <see cref="T:System.String" /> that contains a JPath expression.
		///       </param>
		/// <param name="errorWhenNoMatch">A flag to indicate whether an error should be thrown if no tokens are found when evaluating part of the expression.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</returns>
		public JToken SelectToken(string path, bool errorWhenNoMatch)
		{
			int num = 3;
			JPath jPath = new JPath(path);
			JToken jToken = null;
			foreach (JToken item in jPath.Evaluate(this, errorWhenNoMatch))
			{
				if (jToken != null)
				{
					throw new JsonException("Path returned multiple tokens.");
				}
				jToken = item;
			}
			return jToken;
		}

		/// <summary>
		///       Selects a collection of elements using a JPath expression.
		///       </summary>
		/// <param name="path">
		///       A <see cref="T:System.String" /> that contains a JPath expression.
		///       </param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the selected elements.</returns>
		public IEnumerable<JToken> SelectTokens(string path)
		{
			return SelectTokens(path, errorWhenNoMatch: false);
		}

		/// <summary>
		///       Selects a collection of elements using a JPath expression.
		///       </summary>
		/// <param name="path">
		///       A <see cref="T:System.String" /> that contains a JPath expression.
		///       </param>
		/// <param name="errorWhenNoMatch">A flag to indicate whether an error should be thrown if no tokens are found when evaluating part of the expression.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains the selected elements.</returns>
		public IEnumerable<JToken> SelectTokens(string path, bool errorWhenNoMatch)
		{
			JPath jPath = new JPath(path);
			return jPath.Evaluate(this, errorWhenNoMatch);
		}

		object ICloneable.Clone()
		{
			return DeepClone();
		}

		/// <summary>
		///       Creates a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />. All child tokens are recursively cloned.
		///       </summary>
		/// <returns>A new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</returns>
		public JToken DeepClone()
		{
			return CloneToken();
		}

		/// <summary>
		///       Adds an object to the annotation list of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="annotation">The annotation to add.</param>
		public void AddAnnotation(object annotation)
		{
			int num = 12;
			if (annotation == null)
			{
				throw new ArgumentNullException("annotation");
			}
			if (_annotations == null)
			{
				_annotations = ((annotation is object[]) ? new object[1]
				{
					annotation
				} : annotation);
				return;
			}
			object[] array = _annotations as object[];
			if (array == null)
			{
				_annotations = new object[2]
				{
					_annotations,
					annotation
				};
				return;
			}
			int i;
			for (i = 0; i < array.Length && array[i] != null; i++)
			{
			}
			if (i == array.Length)
			{
				Array.Resize(ref array, i * 2);
				_annotations = array;
			}
			array[i] = annotation;
		}

		/// <summary>
		///       Get the first annotation object of the specified type from this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <typeparam name="T">The type of the annotation to retrieve.</typeparam>
		/// <returns>The first annotation object that matches the specified type, or <c>null</c> if no annotation is of the specified type.</returns>
		public T Annotation<T>() where T : class
		{
			if (_annotations != null)
			{
				object[] array = _annotations as object[];
				if (array == null)
				{
					return _annotations as T;
				}
				foreach (object obj in array)
				{
					if (obj == null)
					{
						break;
					}
					T val = obj as T;
					if (val != null)
					{
						return val;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       Gets the first annotation object of the specified type from this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="type">The <see cref="P:Open_Newtonsoft_Json.Linq.JToken.Type" /> of the annotation to retrieve.</param>
		/// <returns>The first annotation object that matches the specified type, or <c>null</c> if no annotation is of the specified type.</returns>
		public object Annotation(Type type)
		{
			int num = 16;
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (_annotations != null)
			{
				object[] array = _annotations as object[];
				if (array == null)
				{
					if (type.IsInstanceOfType(_annotations))
					{
						return _annotations;
					}
				}
				else
				{
					foreach (object obj in array)
					{
						if (obj == null)
						{
							break;
						}
						if (type.IsInstanceOfType(obj))
						{
							return obj;
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		///       Gets a collection of annotations of the specified type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <typeparam name="T">The type of the annotations to retrieve.</typeparam>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" />  that contains the annotations for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</returns>
		public IEnumerable<T> Annotations<T>() where T : class
		{
			_003CAnnotations_003Ed__e<T> _003CAnnotations_003Ed__e = new _003CAnnotations_003Ed__e<T>(-2);
			_003CAnnotations_003Ed__e._003C_003E4__this = this;
			return _003CAnnotations_003Ed__e;
		}

		/// <summary>
		///       Gets a collection of annotations of the specified type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="type">The <see cref="P:Open_Newtonsoft_Json.Linq.JToken.Type" /> of the annotations to retrieve.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:System.Object" /> that contains the annotations that match the specified type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</returns>
		public IEnumerable<object> Annotations(Type type)
		{
			_003CAnnotations_003Ed__16 _003CAnnotations_003Ed__ = new _003CAnnotations_003Ed__16(-2);
			_003CAnnotations_003Ed__._003C_003E4__this = this;
			_003CAnnotations_003Ed__._003C_003E3__type = type;
			return _003CAnnotations_003Ed__;
		}

		/// <summary>
		///       Removes the annotations of the specified type from this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <typeparam name="T">The type of annotations to remove.</typeparam>
		public void RemoveAnnotations<T>() where T : class
		{
			if (_annotations == null)
			{
				return;
			}
			object[] array = _annotations as object[];
			if (array == null)
			{
				if (_annotations is T)
				{
					_annotations = null;
				}
				return;
			}
			int i = 0;
			int num = 0;
			for (; i < array.Length; i++)
			{
				object obj = array[i];
				if (obj == null)
				{
					break;
				}
				if (!(obj is T))
				{
					array[num++] = obj;
				}
			}
			if (num != 0)
			{
				while (num < i)
				{
					array[num++] = null;
				}
			}
			else
			{
				_annotations = null;
			}
		}

		/// <summary>
		///       Removes the annotations of the specified type from this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="type">The <see cref="P:Open_Newtonsoft_Json.Linq.JToken.Type" /> of annotations to remove.</param>
		public void RemoveAnnotations(Type type)
		{
			int num = 4;
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (_annotations == null)
			{
				return;
			}
			object[] array = _annotations as object[];
			if (array == null)
			{
				if (type.IsInstanceOfType(_annotations))
				{
					_annotations = null;
				}
				return;
			}
			int i = 0;
			int num2 = 0;
			for (; i < array.Length; i++)
			{
				object obj = array[i];
				if (obj == null)
				{
					break;
				}
				if (!type.IsInstanceOfType(obj))
				{
					array[num2++] = obj;
				}
			}
			if (num2 != 0)
			{
				while (num2 < i)
				{
					array[num2++] = null;
				}
			}
			else
			{
				_annotations = null;
			}
		}
	}
}
