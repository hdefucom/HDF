using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a token that can contain other tokens.
	///       </summary>
	[ComVisible(false)]
	public abstract class JContainer : JToken, IList<JToken>, ITypedList, IBindingList
	{
		[ComVisible(false)]
		private class JTokenReferenceEqualityComparer : IEqualityComparer<JToken>
		{
			public static readonly JTokenReferenceEqualityComparer Instance = new JTokenReferenceEqualityComparer();

			public bool Equals(JToken jtoken_0, JToken jtoken_1)
			{
				return object.ReferenceEquals(jtoken_0, jtoken_1);
			}

			public int GetHashCode(JToken jtoken_0)
			{
				return jtoken_0?.GetHashCode() ?? 0;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetDescendants_003Ed__1c : IEnumerable<JToken>, IEnumerator<JToken>
		{
			private JToken _003C_003E2__current;

			private int _003C_003E1__state;

			private int _003C_003El__initialThreadId;

			public JContainer _003C_003E4__this;

			public bool self;

			public bool _003C_003E3__self;

			public JToken _003Co_003E5__1d;

			public JContainer _003Cc_003E5__1e;

			public JToken _003Cd_003E5__1f;

			public IEnumerator<JToken> _003C_003E7__wrap20;

			public IEnumerator<JToken> _003C_003E7__wrap22;

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
				_003CGetDescendants_003Ed__1c _003CGetDescendants_003Ed__1c;
				if (Thread.CurrentThread.ManagedThreadId == _003C_003El__initialThreadId && _003C_003E1__state == -2)
				{
					_003C_003E1__state = 0;
					_003CGetDescendants_003Ed__1c = this;
				}
				else
				{
					_003CGetDescendants_003Ed__1c = new _003CGetDescendants_003Ed__1c(0)
					{
						_003C_003E4__this = _003C_003E4__this
					};
				}
				_003CGetDescendants_003Ed__1c.self = _003C_003E3__self;
				return _003CGetDescendants_003Ed__1c;
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
						if (self)
						{
							_003C_003E2__current = _003C_003E4__this;
							_003C_003E1__state = 1;
							return true;
						}
						goto IL_005d;
					case 1:
						_003C_003E1__state = -1;
						goto IL_005d;
					case 3:
						_003C_003E1__state = 2;
						_003Cc_003E5__1e = (_003Co_003E5__1d as JContainer);
						if (_003Cc_003E5__1e != null)
						{
							_003C_003E7__wrap22 = _003Cc_003E5__1e.Descendants().GetEnumerator();
							_003C_003E1__state = 4;
							goto IL_00c5;
						}
						goto IL_00d8;
					case 5:
						_003C_003E1__state = 4;
						goto IL_00c5;
					default:
						{
							return false;
						}
						IL_00c5:
						if (_003C_003E7__wrap22.MoveNext())
						{
							_003Cd_003E5__1f = _003C_003E7__wrap22.Current;
							_003C_003E2__current = _003Cd_003E5__1f;
							_003C_003E1__state = 5;
							return true;
						}
						_003C_003Em__Finally23();
						goto IL_00d8;
						IL_005d:
						_003C_003E7__wrap20 = _003C_003E4__this.ChildrenTokens.GetEnumerator();
						_003C_003E1__state = 2;
						goto IL_00d8;
						IL_00d8:
						if (_003C_003E7__wrap20.MoveNext())
						{
							_003Co_003E5__1d = _003C_003E7__wrap20.Current;
							_003C_003E2__current = _003Co_003E5__1d;
							_003C_003E1__state = 3;
							return true;
						}
						_003C_003Em__Finally21();
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
				case 2:
				case 3:
				case 4:
				case 5:
					try
					{
						switch (_003C_003E1__state)
						{
						case 4:
						case 5:
							try
							{
							}
							finally
							{
								_003C_003Em__Finally23();
							}
							break;
						}
					}
					finally
					{
						_003C_003Em__Finally21();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CGetDescendants_003Ed__1c(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}

			private void _003C_003Em__Finally21()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap20 != null)
				{
					_003C_003E7__wrap20.Dispose();
				}
			}

			private void _003C_003Em__Finally23()
			{
				_003C_003E1__state = 2;
				if (_003C_003E7__wrap22 != null)
				{
					_003C_003E7__wrap22.Dispose();
				}
			}
		}

		internal ListChangedEventHandler _listChanged;

		internal AddingNewEventHandler _addingNew;

		private object _syncRoot;

		private bool _busy;

		/// <summary>
		///       Gets the container's children tokens.
		///       </summary>
		/// <value>The container's children tokens.</value>
		protected abstract IList<JToken> ChildrenTokens
		{
			get;
		}

		/// <summary>
		///       Gets a value indicating whether this token has child tokens.
		///       </summary>
		/// <value>
		///   <c>true</c> if this token has child values; otherwise, <c>false</c>.
		///       </value>
		public override bool HasValues => ChildrenTokens.Count > 0;

		/// <summary>
		///       Get the first child token of this token.
		///       </summary>
		/// <value>
		///       A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> containing the first child token of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </value>
		public override JToken First => Enumerable.FirstOrDefault(ChildrenTokens);

		/// <summary>
		///       Get the last child token of this token.
		///       </summary>
		/// <value>
		///       A <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> containing the last child token of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </value>
		public override JToken Last => Enumerable.LastOrDefault(ChildrenTokens);

		JToken IList<JToken>.this[int index]
		{
			get
			{
				return GetItem(index);
			}
			set
			{
				SetItem(index, value);
			}
		}

		bool ICollection<JToken>.IsReadOnly => false;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		object IList.this[int index]
		{
			get
			{
				return GetItem(index);
			}
			set
			{
				SetItem(index, EnsureValue(value));
			}
		}

		/// <summary>
		///       Gets the count of child JSON tokens.
		///       </summary>
		/// <value>The count of child JSON tokens</value>
		public int Count => ChildrenTokens.Count;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot
		{
			get
			{
				if (_syncRoot == null)
				{
					Interlocked.CompareExchange(ref _syncRoot, new object(), null);
				}
				return _syncRoot;
			}
		}

		bool IBindingList.AllowEdit => true;

		bool IBindingList.AllowNew => true;

		bool IBindingList.AllowRemove => true;

		bool IBindingList.IsSorted => false;

		ListSortDirection IBindingList.SortDirection => ListSortDirection.Ascending;

		PropertyDescriptor IBindingList.SortProperty => null;

		bool IBindingList.SupportsChangeNotification => true;

		bool IBindingList.SupportsSearching => false;

		bool IBindingList.SupportsSorting => false;

		/// <summary>
		///       Occurs when the list changes or an item in the list changes.
		///       </summary>
		public event ListChangedEventHandler ListChanged
		{
			add
			{
				_listChanged = (ListChangedEventHandler)Delegate.Combine(_listChanged, value);
			}
			remove
			{
				_listChanged = (ListChangedEventHandler)Delegate.Remove(_listChanged, value);
			}
		}

		/// <summary>
		///       Occurs before an item is added to the collection.
		///       </summary>
		public event AddingNewEventHandler AddingNew
		{
			add
			{
				_addingNew = (AddingNewEventHandler)Delegate.Combine(_addingNew, value);
			}
			remove
			{
				_addingNew = (AddingNewEventHandler)Delegate.Remove(_addingNew, value);
			}
		}

		internal JContainer()
		{
		}

		internal JContainer(JContainer other)
			: this()
		{
			ValidationUtils.ArgumentNotNull(other, "c");
			int num = 0;
			foreach (JToken item in (IEnumerable<JToken>)other)
			{
				AddInternal(num, item, skipParentCheck: false);
				num++;
			}
		}

		internal void CheckReentrancy()
		{
			int num = 17;
			if (_busy)
			{
				throw new InvalidOperationException(StringUtils.FormatWith("Cannot change {0} during a collection change event.", CultureInfo.InvariantCulture, GetType()));
			}
		}

		internal virtual IList<JToken> CreateChildrenCollection()
		{
			return new List<JToken>();
		}

		/// <summary>
		///       Raises the <see cref="E:Open_Newtonsoft_Json.Linq.JContainer.AddingNew" /> event.
		///       </summary>
		/// <param name="e">The <see cref="T:System.ComponentModel.AddingNewEventArgs" /> instance containing the event data.</param>
		protected virtual void OnAddingNew(AddingNewEventArgs addingNewEventArgs_0)
		{
			_addingNew?.Invoke(this, addingNewEventArgs_0);
		}

		/// <summary>
		///       Raises the <see cref="E:Open_Newtonsoft_Json.Linq.JContainer.ListChanged" /> event.
		///       </summary>
		/// <param name="e">The <see cref="T:System.ComponentModel.ListChangedEventArgs" /> instance containing the event data.</param>
		protected virtual void OnListChanged(ListChangedEventArgs listChangedEventArgs_0)
		{
			ListChangedEventHandler listChanged = _listChanged;
			if (listChanged != null)
			{
				_busy = true;
				try
				{
					listChanged(this, listChangedEventArgs_0);
				}
				finally
				{
					_busy = false;
				}
			}
		}

		internal bool ContentsEqual(JContainer container)
		{
			if (container == this)
			{
				return true;
			}
			IList<JToken> childrenTokens = ChildrenTokens;
			IList<JToken> childrenTokens2 = container.ChildrenTokens;
			if (childrenTokens.Count != childrenTokens2.Count)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < childrenTokens.Count)
				{
					if (!childrenTokens[num].DeepEquals(childrenTokens2[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       Returns a collection of the child tokens of this token, in document order.
		///       </summary>
		/// <returns>
		///       An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> containing the child tokens of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />, in document order.
		///       </returns>
		public override JEnumerable<JToken> Children()
		{
			return new JEnumerable<JToken>(ChildrenTokens);
		}

		/// <summary>
		///       Returns a collection of the child values of this token, in document order.
		///       </summary>
		/// <typeparam name="T">The type to convert the values to.</typeparam>
		/// <returns>
		///       A <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the child values of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />, in document order.
		///       </returns>
		public override IEnumerable<T> Values<T>()
		{
			return Extensions.Convert<JToken, T>(ChildrenTokens);
		}

		/// <summary>
		///       Returns a collection of the descendant tokens for this token in document order.
		///       </summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing the descendant tokens of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</returns>
		public IEnumerable<JToken> Descendants()
		{
			return GetDescendants(self: false);
		}

		/// <summary>
		///       Returns a collection of the tokens that contain this token, and all descendant tokens of this token, in document order.
		///       </summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing this token, and all the descendant tokens of the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.</returns>
		public IEnumerable<JToken> DescendantsAndSelf()
		{
			return GetDescendants(self: true);
		}

		internal IEnumerable<JToken> GetDescendants(bool self)
		{
			_003CGetDescendants_003Ed__1c _003CGetDescendants_003Ed__1c = new _003CGetDescendants_003Ed__1c(-2);
			_003CGetDescendants_003Ed__1c._003C_003E4__this = this;
			_003CGetDescendants_003Ed__1c._003C_003E3__self = self;
			return _003CGetDescendants_003Ed__1c;
		}

		internal bool IsMultiContent(object content)
		{
			return content is IEnumerable && !(content is string) && !(content is JToken) && !(content is byte[]);
		}

		internal JToken EnsureParentToken(JToken item, bool skipParentCheck)
		{
			if (item == null)
			{
				return JValue.CreateNull();
			}
			if (skipParentCheck)
			{
				return item;
			}
			if (item.Parent != null || item == this || (item.HasValues && base.Root == item))
			{
				item = item.CloneToken();
			}
			return item;
		}

		internal int IndexOfItem(JToken item)
		{
			return CollectionUtils.IndexOf(ChildrenTokens, item, JTokenReferenceEqualityComparer.Instance);
		}

		internal virtual void InsertItem(int index, JToken item, bool skipParentCheck)
		{
			int num = 14;
			if (index > ChildrenTokens.Count)
			{
				throw new ArgumentOutOfRangeException("index", "Index must be within the bounds of the List.");
			}
			CheckReentrancy();
			item = EnsureParentToken(item, skipParentCheck);
			JToken jToken = (index == 0) ? null : ChildrenTokens[index - 1];
			JToken jToken2 = (index == ChildrenTokens.Count) ? null : ChildrenTokens[index];
			ValidateToken(item, null);
			item.Parent = this;
			item.Previous = jToken;
			if (jToken != null)
			{
				jToken.Next = item;
			}
			item.Next = jToken2;
			if (jToken2 != null)
			{
				jToken2.Previous = item;
			}
			ChildrenTokens.Insert(index, item);
			if (_listChanged != null)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
			}
		}

		internal virtual void RemoveItemAt(int index)
		{
			int num = 17;
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", "Index is less than 0.");
			}
			if (index >= ChildrenTokens.Count)
			{
				throw new ArgumentOutOfRangeException("index", "Index is equal to or greater than Count.");
			}
			CheckReentrancy();
			JToken jToken = ChildrenTokens[index];
			JToken jToken2 = (index == 0) ? null : ChildrenTokens[index - 1];
			JToken jToken3 = (index == ChildrenTokens.Count - 1) ? null : ChildrenTokens[index + 1];
			if (jToken2 != null)
			{
				jToken2.Next = jToken3;
			}
			if (jToken3 != null)
			{
				jToken3.Previous = jToken2;
			}
			jToken.Parent = null;
			jToken.Previous = null;
			jToken.Next = null;
			ChildrenTokens.RemoveAt(index);
			if (_listChanged != null)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
			}
		}

		internal virtual bool RemoveItem(JToken item)
		{
			int num = IndexOfItem(item);
			if (num >= 0)
			{
				RemoveItemAt(num);
				return true;
			}
			return false;
		}

		internal virtual JToken GetItem(int index)
		{
			return ChildrenTokens[index];
		}

		internal virtual void SetItem(int index, JToken item)
		{
			int num = 11;
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", "Index is less than 0.");
			}
			if (index >= ChildrenTokens.Count)
			{
				throw new ArgumentOutOfRangeException("index", "Index is equal to or greater than Count.");
			}
			JToken jToken = ChildrenTokens[index];
			if (!IsTokenUnchanged(jToken, item))
			{
				CheckReentrancy();
				item = EnsureParentToken(item, skipParentCheck: false);
				ValidateToken(item, jToken);
				JToken jToken2 = (index == 0) ? null : ChildrenTokens[index - 1];
				JToken jToken3 = (index == ChildrenTokens.Count - 1) ? null : ChildrenTokens[index + 1];
				item.Parent = this;
				item.Previous = jToken2;
				if (jToken2 != null)
				{
					jToken2.Next = item;
				}
				item.Next = jToken3;
				if (jToken3 != null)
				{
					jToken3.Previous = item;
				}
				ChildrenTokens[index] = item;
				jToken.Parent = null;
				jToken.Previous = null;
				jToken.Next = null;
				if (_listChanged != null)
				{
					OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
				}
			}
		}

		internal virtual void ClearItems()
		{
			CheckReentrancy();
			foreach (JToken childrenToken in ChildrenTokens)
			{
				childrenToken.Parent = null;
				childrenToken.Previous = null;
				childrenToken.Next = null;
			}
			ChildrenTokens.Clear();
			if (_listChanged != null)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
			}
		}

		internal virtual void ReplaceItem(JToken existing, JToken replacement)
		{
			if (existing != null && existing.Parent == this)
			{
				int index = IndexOfItem(existing);
				SetItem(index, replacement);
			}
		}

		internal virtual bool ContainsItem(JToken item)
		{
			return IndexOfItem(item) != -1;
		}

		internal virtual void CopyItemsTo(Array array, int arrayIndex)
		{
			int num = 5;
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex is less than 0.");
			}
			if (arrayIndex >= array.Length && arrayIndex != 0)
			{
				throw new ArgumentException("arrayIndex is equal to or greater than the length of array.");
			}
			if (Count > array.Length - arrayIndex)
			{
				throw new ArgumentException("The number of elements in the source JObject is greater than the available space from arrayIndex to the end of the destination array.");
			}
			int num2 = 0;
			foreach (JToken childrenToken in ChildrenTokens)
			{
				array.SetValue(childrenToken, arrayIndex + num2);
				num2++;
			}
		}

		internal static bool IsTokenUnchanged(JToken currentValue, JToken newValue)
		{
			JValue jValue = currentValue as JValue;
			if (jValue != null)
			{
				if (jValue.Type == JTokenType.Null && newValue == null)
				{
					return true;
				}
				return jValue.Equals(newValue);
			}
			return false;
		}

		internal virtual void ValidateToken(JToken jtoken_0, JToken existing)
		{
			int num = 15;
			ValidationUtils.ArgumentNotNull(jtoken_0, "o");
			if (jtoken_0.Type == JTokenType.Property)
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not add {0} to {1}.", CultureInfo.InvariantCulture, jtoken_0.GetType(), GetType()));
			}
		}

		/// <summary>
		///       Adds the specified content as children of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="content">The content to be added.</param>
		public virtual void Add(object content)
		{
			AddInternal(ChildrenTokens.Count, content, skipParentCheck: false);
		}

		internal void AddAndSkipParentCheck(JToken token)
		{
			AddInternal(ChildrenTokens.Count, token, skipParentCheck: true);
		}

		/// <summary>
		///       Adds the specified content as the first children of this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="content">The content to be added.</param>
		public void AddFirst(object content)
		{
			AddInternal(0, content, skipParentCheck: false);
		}

		internal void AddInternal(int index, object content, bool skipParentCheck)
		{
			if (IsMultiContent(content))
			{
				IEnumerable enumerable = (IEnumerable)content;
				int num = index;
				foreach (object item2 in enumerable)
				{
					AddInternal(num, item2, skipParentCheck);
					num++;
				}
			}
			else
			{
				JToken item = CreateFromContent(content);
				InsertItem(index, item, skipParentCheck);
			}
		}

		internal static JToken CreateFromContent(object content)
		{
			if (content is JToken)
			{
				return (JToken)content;
			}
			return new JValue(content);
		}

		/// <summary>
		///       Creates an <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> that can be used to add tokens to the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <returns>An <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> that is ready to have content written to it.</returns>
		public JsonWriter CreateWriter()
		{
			return new JTokenWriter(this);
		}

		/// <summary>
		///       Replaces the children nodes of this token with the specified content.
		///       </summary>
		/// <param name="content">The content.</param>
		public void ReplaceAll(object content)
		{
			ClearItems();
			Add(content);
		}

		/// <summary>
		///       Removes the child nodes from this token.
		///       </summary>
		public void RemoveAll()
		{
			ClearItems();
		}

		internal abstract void MergeItem(object content, JsonMergeSettings settings);

		/// <summary>
		///       Merge the specified content into this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <param name="content">The content to be merged.</param>
		public void Merge(object content)
		{
			MergeItem(content, new JsonMergeSettings());
		}

		/// <summary>
		///       Merge the specified content into this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> using <see cref="T:Open_Newtonsoft_Json.Linq.JsonMergeSettings" />.
		///       </summary>
		/// <param name="content">The content to be merged.</param>
		/// <param name="settings">The <see cref="T:Open_Newtonsoft_Json.Linq.JsonMergeSettings" /> used to merge the content.</param>
		public void Merge(object content, JsonMergeSettings settings)
		{
			MergeItem(content, settings);
		}

		internal void ReadTokenFrom(JsonReader reader)
		{
			int num = 8;
			int depth = reader.Depth;
			if (!reader.Read())
			{
				throw JsonReaderException.Create(reader, StringUtils.FormatWith("Error reading {0} from JsonReader.", CultureInfo.InvariantCulture, GetType().Name));
			}
			ReadContentFrom(reader);
			int depth2 = reader.Depth;
			if (depth2 > depth)
			{
				throw JsonReaderException.Create(reader, StringUtils.FormatWith("Unexpected end of content while loading {0}.", CultureInfo.InvariantCulture, GetType().Name));
			}
		}

		internal void ReadContentFrom(JsonReader jsonReader_0)
		{
			int num = 12;
			ValidationUtils.ArgumentNotNull(jsonReader_0, "r");
			IJsonLineInfo lineInfo = jsonReader_0 as IJsonLineInfo;
			JContainer jContainer = this;
			do
			{
				if (jContainer is JProperty && ((JProperty)jContainer).Value != null)
				{
					if (jContainer == this)
					{
						break;
					}
					jContainer = jContainer.Parent;
				}
				switch (jsonReader_0.TokenType)
				{
				case JsonToken.StartObject:
				{
					JObject jObject = new JObject();
					jObject.SetLineInfo(lineInfo);
					jContainer.Add(jObject);
					jContainer = jObject;
					break;
				}
				case JsonToken.StartArray:
				{
					JArray jArray = new JArray();
					jArray.SetLineInfo(lineInfo);
					jContainer.Add(jArray);
					jContainer = jArray;
					break;
				}
				case JsonToken.StartConstructor:
				{
					JConstructor jConstructor = new JConstructor(jsonReader_0.Value.ToString());
					jConstructor.SetLineInfo(lineInfo);
					jContainer.Add(jConstructor);
					jContainer = jConstructor;
					break;
				}
				case JsonToken.PropertyName:
				{
					string name = jsonReader_0.Value.ToString();
					JProperty jProperty = new JProperty(name);
					jProperty.SetLineInfo(lineInfo);
					JObject jObject2 = (JObject)jContainer;
					JProperty jProperty2 = jObject2.Property(name);
					if (jProperty2 == null)
					{
						jContainer.Add(jProperty);
					}
					else
					{
						jProperty2.Replace(jProperty);
					}
					jContainer = jProperty;
					break;
				}
				case JsonToken.Comment:
				{
					JValue jValue = JValue.CreateComment(jsonReader_0.Value.ToString());
					jValue.SetLineInfo(lineInfo);
					jContainer.Add(jValue);
					break;
				}
				case JsonToken.Null:
				{
					JValue jValue = JValue.CreateNull();
					jValue.SetLineInfo(lineInfo);
					jContainer.Add(jValue);
					break;
				}
				case JsonToken.Undefined:
				{
					JValue jValue = JValue.CreateUndefined();
					jValue.SetLineInfo(lineInfo);
					jContainer.Add(jValue);
					break;
				}
				case JsonToken.EndObject:
					if (jContainer != this)
					{
						jContainer = jContainer.Parent;
						break;
					}
					return;
				case JsonToken.EndArray:
					if (jContainer != this)
					{
						jContainer = jContainer.Parent;
						break;
					}
					return;
				case JsonToken.EndConstructor:
					if (jContainer != this)
					{
						jContainer = jContainer.Parent;
						break;
					}
					return;
				case JsonToken.Integer:
				case JsonToken.Float:
				case JsonToken.String:
				case JsonToken.Boolean:
				case JsonToken.Date:
				case JsonToken.Bytes:
				{
					JValue jValue = new JValue(jsonReader_0.Value);
					jValue.SetLineInfo(lineInfo);
					jContainer.Add(jValue);
					break;
				}
				case JsonToken.None:
					break;
				default:
					throw new InvalidOperationException(StringUtils.FormatWith("The JsonReader should not be on a token of type {0}.", CultureInfo.InvariantCulture, jsonReader_0.TokenType));
				}
			}
			while (jsonReader_0.Read());
		}

		internal int ContentsHashCode()
		{
			int num = 0;
			foreach (JToken childrenToken in ChildrenTokens)
			{
				num ^= childrenToken.GetDeepHashCode();
			}
			return num;
		}

		string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
		{
			return string.Empty;
		}

		PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
		{
			return (First as ICustomTypeDescriptor)?.GetProperties();
		}

		int IList<JToken>.IndexOf(JToken item)
		{
			return IndexOfItem(item);
		}

		void IList<JToken>.Insert(int index, JToken item)
		{
			InsertItem(index, item, skipParentCheck: false);
		}

		void IList<JToken>.RemoveAt(int index)
		{
			RemoveItemAt(index);
		}

		void ICollection<JToken>.Add(JToken item)
		{
			Add(item);
		}

		void ICollection<JToken>.Clear()
		{
			ClearItems();
		}

		bool ICollection<JToken>.Contains(JToken item)
		{
			return ContainsItem(item);
		}

		void ICollection<JToken>.CopyTo(JToken[] array, int arrayIndex)
		{
			CopyItemsTo(array, arrayIndex);
		}

		bool ICollection<JToken>.Remove(JToken item)
		{
			return RemoveItem(item);
		}

		private JToken EnsureValue(object value)
		{
			int num = 7;
			if (value == null)
			{
				return null;
			}
			if (value is JToken)
			{
				return (JToken)value;
			}
			throw new ArgumentException("Argument is not a JToken.");
		}

		int IList.Add(object value)
		{
			Add(EnsureValue(value));
			return Count - 1;
		}

		void IList.Clear()
		{
			ClearItems();
		}

		bool IList.Contains(object value)
		{
			return ContainsItem(EnsureValue(value));
		}

		int IList.IndexOf(object value)
		{
			return IndexOfItem(EnsureValue(value));
		}

		void IList.Insert(int index, object value)
		{
			InsertItem(index, EnsureValue(value), skipParentCheck: false);
		}

		void IList.Remove(object value)
		{
			RemoveItem(EnsureValue(value));
		}

		void IList.RemoveAt(int index)
		{
			RemoveItemAt(index);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			CopyItemsTo(array, index);
		}

		void IBindingList.AddIndex(PropertyDescriptor property)
		{
		}

		object IBindingList.AddNew()
		{
			int num = 0;
			AddingNewEventArgs addingNewEventArgs = new AddingNewEventArgs();
			OnAddingNew(addingNewEventArgs);
			if (addingNewEventArgs.NewObject == null)
			{
				throw new JsonException(StringUtils.FormatWith("Could not determine new value to add to '{0}'.", CultureInfo.InvariantCulture, GetType()));
			}
			if (!(addingNewEventArgs.NewObject is JToken))
			{
				throw new JsonException(StringUtils.FormatWith("New item to be added to collection must be compatible with {0}.", CultureInfo.InvariantCulture, typeof(JToken)));
			}
			JToken jToken = (JToken)addingNewEventArgs.NewObject;
			Add(jToken);
			return jToken;
		}

		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
		{
			throw new NotSupportedException();
		}

		int IBindingList.Find(PropertyDescriptor property, object object_0)
		{
			throw new NotSupportedException();
		}

		void IBindingList.RemoveIndex(PropertyDescriptor property)
		{
		}

		void IBindingList.RemoveSort()
		{
			throw new NotSupportedException();
		}

		internal static void MergeEnumerableContent(JContainer target, IEnumerable content, JsonMergeSettings settings)
		{
			int num = 12;
			switch (settings.MergeArrayHandling)
			{
			default:
				throw new ArgumentOutOfRangeException("settings", "Unexpected merge array handling when merging JSON.");
			case MergeArrayHandling.Concat:
				foreach (JToken item in content)
				{
					target.Add(item);
				}
				break;
			case MergeArrayHandling.Union:
			{
				IDictionary<JToken, bool> dictionary = new Dictionary<JToken, bool>(JToken.EqualityComparer);
				foreach (JToken item2 in (IEnumerable<JToken>)target)
				{
					dictionary[item2] = true;
				}
				foreach (JToken item3 in content)
				{
					if (!dictionary.ContainsKey(item3))
					{
						dictionary[item3] = true;
						target.Add(item3);
					}
				}
				break;
			}
			case MergeArrayHandling.Replace:
				target.ClearItems();
				foreach (JToken item4 in content)
				{
					target.Add(item4);
				}
				break;
			case MergeArrayHandling.Merge:
			{
				int num2 = 0;
				foreach (object item5 in content)
				{
					if (num2 < target.Count)
					{
						JToken jToken = target[num2];
						JContainer jContainer = jToken as JContainer;
						if (jContainer != null)
						{
							jContainer.Merge(item5, settings);
						}
						else if (item5 != null)
						{
							JToken jToken2 = CreateFromContent(item5);
							if (jToken2.Type != JTokenType.Null)
							{
								target[num2] = jToken2;
							}
						}
					}
					else
					{
						target.Add(item5);
					}
					num2++;
				}
				break;
			}
			}
		}
	}
}
