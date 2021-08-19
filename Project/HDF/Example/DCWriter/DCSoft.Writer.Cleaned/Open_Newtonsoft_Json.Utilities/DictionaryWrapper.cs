using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class DictionaryWrapper<TKey, TValue> : IDictionary<TKey, TValue>, IWrappedDictionary
	{
		[ComVisible(false)]
		private struct DictionaryEnumerator<TEnumeratorKey, TEnumeratorValue> : IDictionaryEnumerator
		{
			private readonly IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e;

			public DictionaryEntry Entry => (DictionaryEntry)Current;

			public object Key => Entry.Key;

			public object Value => Entry.Value;

			public object Current => new DictionaryEntry(_e.Current.Key, _e.Current.Value);

			public DictionaryEnumerator(IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> ienumerator_0)
			{
				ValidationUtils.ArgumentNotNull(ienumerator_0, "e");
				_e = ienumerator_0;
			}

			public bool MoveNext()
			{
				return _e.MoveNext();
			}

			public void Reset()
			{
				_e.Reset();
			}
		}

		private readonly IDictionary _dictionary;

		private readonly IDictionary<TKey, TValue> _genericDictionary;

		private object _syncRoot;

		public ICollection<TKey> Keys
		{
			get
			{
				if (_dictionary != null)
				{
					return Enumerable.ToList(Enumerable.Cast<TKey>(_dictionary.Keys));
				}
				return _genericDictionary.Keys;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				if (_dictionary != null)
				{
					return Enumerable.ToList(Enumerable.Cast<TValue>(_dictionary.Values));
				}
				return _genericDictionary.Values;
			}
		}

		public TValue this[TKey propertyName]
		{
			get
			{
				if (_dictionary != null)
				{
					return (TValue)_dictionary[propertyName];
				}
				return _genericDictionary[propertyName];
			}
			set
			{
				if (_dictionary != null)
				{
					_dictionary[propertyName] = value;
				}
				else
				{
					_genericDictionary[propertyName] = value;
				}
			}
		}

		public int Count
		{
			get
			{
				if (_dictionary != null)
				{
					return _dictionary.Count;
				}
				return _genericDictionary.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				if (_dictionary != null)
				{
					return _dictionary.IsReadOnly;
				}
				return _genericDictionary.IsReadOnly;
			}
		}

		object IDictionary.this[object object_0]
		{
			get
			{
				if (_dictionary != null)
				{
					return _dictionary[object_0];
				}
				return _genericDictionary[(TKey)object_0];
			}
			set
			{
				if (_dictionary != null)
				{
					_dictionary[object_0] = value;
				}
				else
				{
					_genericDictionary[(TKey)object_0] = (TValue)value;
				}
			}
		}

		bool IDictionary.IsFixedSize
		{
			get
			{
				if (_genericDictionary != null)
				{
					return false;
				}
				return _dictionary.IsFixedSize;
			}
		}

		ICollection IDictionary.Keys
		{
			get
			{
				if (_genericDictionary != null)
				{
					return Enumerable.ToList(_genericDictionary.Keys);
				}
				return _dictionary.Keys;
			}
		}

		ICollection IDictionary.Values
		{
			get
			{
				if (_genericDictionary != null)
				{
					return Enumerable.ToList(_genericDictionary.Values);
				}
				return _dictionary.Values;
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				if (_dictionary != null)
				{
					return _dictionary.IsSynchronized;
				}
				return false;
			}
		}

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

		public object UnderlyingDictionary
		{
			get
			{
				if (_dictionary != null)
				{
					return _dictionary;
				}
				return _genericDictionary;
			}
		}

		public DictionaryWrapper(IDictionary dictionary)
		{
			ValidationUtils.ArgumentNotNull(dictionary, "dictionary");
			_dictionary = dictionary;
		}

		public DictionaryWrapper(IDictionary<TKey, TValue> dictionary)
		{
			ValidationUtils.ArgumentNotNull(dictionary, "dictionary");
			_genericDictionary = dictionary;
		}

		public void Add(TKey propertyName, TValue value)
		{
			if (_dictionary != null)
			{
				_dictionary.Add(propertyName, value);
				return;
			}
			if (_genericDictionary != null)
			{
				_genericDictionary.Add(propertyName, value);
				return;
			}
			throw new NotSupportedException();
		}

		public bool ContainsKey(TKey gparam_0)
		{
			if (_dictionary != null)
			{
				return _dictionary.Contains(gparam_0);
			}
			return _genericDictionary.ContainsKey(gparam_0);
		}

		public bool Remove(TKey propertyName)
		{
			if (_dictionary != null)
			{
				if (_dictionary.Contains(propertyName))
				{
					_dictionary.Remove(propertyName);
					return true;
				}
				return false;
			}
			return _genericDictionary.Remove(propertyName);
		}

		public bool TryGetValue(TKey propertyName, out TValue value)
		{
			if (_dictionary != null)
			{
				if (!_dictionary.Contains(propertyName))
				{
					value = default(TValue);
					return false;
				}
				value = (TValue)_dictionary[propertyName];
				return true;
			}
			return _genericDictionary.TryGetValue(propertyName, out value);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			if (_dictionary != null)
			{
				((IList)_dictionary).Add(item);
			}
			else if (_genericDictionary != null)
			{
				_genericDictionary.Add(item);
			}
		}

		public void Clear()
		{
			if (_dictionary != null)
			{
				_dictionary.Clear();
			}
			else
			{
				_genericDictionary.Clear();
			}
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			if (_dictionary != null)
			{
				return ((IList)_dictionary).Contains(item);
			}
			return _genericDictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			if (_dictionary != null)
			{
				foreach (DictionaryEntry item in _dictionary)
				{
					array[arrayIndex++] = new KeyValuePair<TKey, TValue>((TKey)item.Key, (TValue)item.Value);
				}
			}
			else
			{
				_genericDictionary.CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			if (_dictionary != null)
			{
				if (_dictionary.Contains(item.Key))
				{
					object objA = _dictionary[item.Key];
					if (object.Equals(objA, item.Value))
					{
						_dictionary.Remove(item.Key);
						return true;
					}
					return false;
				}
				return true;
			}
			return _genericDictionary.Remove(item);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			if (_dictionary != null)
			{
				return Enumerable.Select(Enumerable.Cast<DictionaryEntry>(_dictionary), (DictionaryEntry dictionaryEntry_0) => new KeyValuePair<TKey, TValue>((TKey)dictionaryEntry_0.Key, (TValue)dictionaryEntry_0.Value)).GetEnumerator();
			}
			return _genericDictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void IDictionary.Add(object object_0, object value)
		{
			if (_dictionary != null)
			{
				_dictionary.Add(object_0, value);
			}
			else
			{
				_genericDictionary.Add((TKey)object_0, (TValue)value);
			}
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			if (_dictionary != null)
			{
				return _dictionary.GetEnumerator();
			}
			return new DictionaryEnumerator<TKey, TValue>(_genericDictionary.GetEnumerator());
		}

		bool IDictionary.Contains(object object_0)
		{
			if (_genericDictionary != null)
			{
				return _genericDictionary.ContainsKey((TKey)object_0);
			}
			return _dictionary.Contains(object_0);
		}

		public void Remove(object object_0)
		{
			if (_dictionary != null)
			{
				_dictionary.Remove(object_0);
			}
			else
			{
				_genericDictionary.Remove((TKey)object_0);
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (_dictionary != null)
			{
				_dictionary.CopyTo(array, index);
			}
			else
			{
				_genericDictionary.CopyTo((KeyValuePair<TKey, TValue>[])array, index);
			}
		}
	}
}
