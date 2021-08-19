using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       视图数据包
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DCInternal]
	[ComVisible(false)]
	[DocumentComment]
	public class ViewStateBag : IDisposable, IDictionary
	{
		private Dictionary<string, object> _values = new Dictionary<string, object>();

		/// <summary>
		///       设置状态值
		///       </summary>
		/// <param name="key">关键字值</param>
		/// <returns>获得的数据</returns>
		public object this[string string_0]
		{
			get
			{
				if (_values.ContainsKey(string_0))
				{
					return _values[string_0];
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					SerializableAttribute serializableAttribute = (SerializableAttribute)Attribute.GetCustomAttribute(value.GetType(), typeof(SerializableAttribute), inherit: false);
					if (serializableAttribute == null)
					{
						throw new ArgumentException(string.Format(WriterStringsCore.MustMarkSerializableAttribute_TypeName, value.GetType().Name));
					}
				}
				_values[string_0] = value;
			}
		}

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => _values.Keys;

		ICollection IDictionary.Values => _values.Values;

		object IDictionary.this[object object_0]
		{
			get
			{
				return _values[Convert.ToString(object_0)];
			}
			set
			{
				_values[Convert.ToString(object_0)] = value;
			}
		}

		int ICollection.Count => _values.Count;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		/// <summary>
		///       将视图状态数据保存为BASE64格式的文本
		///       </summary>
		/// <returns>生成的文本</returns>
		public string ToViewStateString()
		{
			if (_values.Count == 0)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			foreach (string key in _values.Keys)
			{
				arrayList.Add(key);
				arrayList.Add(_values[key]);
			}
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, arrayList.ToArray());
			memoryStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		/// <summary>
		///       加载BASE64格式的视图状态数据
		///       </summary>
		/// <param name="base64String">视图状态数据文本</param>
		public void LoadViewStateString(string base64String)
		{
			_values.Clear();
			byte[] buffer = Convert.FromBase64String(base64String);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream(buffer);
			object[] array = (object[])binaryFormatter.Deserialize(memoryStream);
			memoryStream.Close();
			if (array != null)
			{
				for (int i = 0; i < array.Length; i += 2)
				{
					_values[(string)array[i]] = array[i + 1];
				}
			}
		}

		/// <summary>
		///       判断是否存在指定关键字的数值
		///       </summary>
		/// <param name="key">
		/// </param>
		/// <returns>
		/// </returns>
		public bool Contains(string string_0)
		{
			return _values.ContainsKey(string_0);
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			try
			{
				foreach (object value in _values.Values)
				{
					if (value != null && value is IDisposable)
					{
						((IDisposable)value).Dispose();
					}
				}
			}
			finally
			{
				Clear();
			}
		}

		void IDictionary.Add(object object_0, object value)
		{
			_values[Convert.ToString(object_0)] = value;
		}

		/// <summary>
		///       清空数据
		///       </summary>
		public void Clear()
		{
			_values.Clear();
		}

		bool IDictionary.Contains(object object_0)
		{
			return _values.ContainsKey(Convert.ToString(object_0));
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return _values.GetEnumerator();
		}

		void IDictionary.Remove(object object_0)
		{
			string key = Convert.ToString(object_0);
			if (_values.ContainsKey(key))
			{
				_values.Remove(key);
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _values.GetEnumerator();
		}
	}
}
