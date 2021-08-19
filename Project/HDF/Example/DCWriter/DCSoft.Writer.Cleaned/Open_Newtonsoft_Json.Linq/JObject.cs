using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a JSON object.
	///       </summary>
	/// <example>
	///   <code lang="cs" source="..\Src\Open_Newtonsoft_Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParse" title="Parsing a JSON Object from Text" />
	/// </example>
	[ComVisible(false)]
	public class JObject : JContainer, IDictionary<string, JToken>, ICustomTypeDescriptor, INotifyPropertyChanged
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__2 : IEnumerator<KeyValuePair<string, JToken>>
		{
			private KeyValuePair<string, JToken> _003C_003E2__current;

			private int _003C_003E1__state;

			public JObject _003C_003E4__this;

			public JProperty _003Cproperty_003E5__3;

			public IEnumerator<JToken> _003C_003E7__wrap4;

			KeyValuePair<string, JToken> IEnumerator<KeyValuePair<string, JToken>>.Current
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

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 0:
						_003C_003E1__state = -1;
						_003C_003E7__wrap4 = _003C_003E4__this._properties.GetEnumerator();
						_003C_003E1__state = 1;
						goto IL_0048;
					case 2:
						_003C_003E1__state = 1;
						goto IL_0048;
					default:
						{
							return false;
						}
						IL_0048:
						if (_003C_003E7__wrap4.MoveNext())
						{
							_003Cproperty_003E5__3 = (JProperty)_003C_003E7__wrap4.Current;
							_003C_003E2__current = new KeyValuePair<string, JToken>(_003Cproperty_003E5__3.Name, _003Cproperty_003E5__3.Value);
							_003C_003E1__state = 2;
							return true;
						}
						_003C_003Em__Finally5();
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
						_003C_003Em__Finally5();
					}
					break;
				}
			}

			[DebuggerHidden]
			public _003CGetEnumerator_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			private void _003C_003Em__Finally5()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap4 != null)
				{
					_003C_003E7__wrap4.Dispose();
				}
			}
		}

		private readonly JPropertyKeyedCollection _properties = new JPropertyKeyedCollection();

		/// <summary>
		///       Gets the container's children tokens.
		///       </summary>
		/// <value>The container's children tokens.</value>
		protected override IList<JToken> ChildrenTokens => _properties;

		/// <summary>
		///       Gets the node type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <value>The type.</value>
		public override JTokenType Type => JTokenType.Object;

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.
		///       </summary>
		/// <value>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.</value>
		public override JToken this[object object_0]
		{
			get
			{
				int num = 10;
				ValidationUtils.ArgumentNotNull(object_0, "o");
				string text = object_0 as string;
				if (text == null)
				{
					throw new ArgumentException(StringUtils.FormatWith("Accessed JObject values with invalid key value: {0}. Object property name expected.", CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(object_0)));
				}
				return this[text];
			}
			set
			{
				int num = 3;
				ValidationUtils.ArgumentNotNull(object_0, "o");
				string text = object_0 as string;
				if (text == null)
				{
					throw new ArgumentException(StringUtils.FormatWith("Set JObject values with invalid key value: {0}. Object property name expected.", CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(object_0)));
				}
				this[text] = value;
			}
		}

		/// <summary>
		///       Gets or sets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified property name.
		///       </summary>
		/// <value>
		/// </value>
		public JToken this[string propertyName]
		{
			get
			{
				ValidationUtils.ArgumentNotNull(propertyName, "propertyName");
				return Property(propertyName)?.Value;
			}
			set
			{
				JProperty jProperty = Property(propertyName);
				if (jProperty != null)
				{
					jProperty.Value = value;
					return;
				}
				Add(new JProperty(propertyName, value));
				OnPropertyChanged(propertyName);
			}
		}

		ICollection<string> IDictionary<string, JToken>.Keys => _properties.Keys;

		ICollection<JToken> IDictionary<string, JToken>.Values
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		bool ICollection<KeyValuePair<string, JToken>>.IsReadOnly => false;

		/// <summary>
		///       Occurs when a property value changes.
		///       </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> class.
		///       </summary>
		public JObject()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> class from another <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> object.
		///       </summary>
		/// <param name="other">A <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> object to copy from.</param>
		public JObject(JObject other)
			: base(other)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> class with the specified content.
		///       </summary>
		/// <param name="content">The contents of the object.</param>
		public JObject(params object[] content)
			: this((object)content)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> class with the specified content.
		///       </summary>
		/// <param name="content">The contents of the object.</param>
		public JObject(object content)
		{
			Add(content);
		}

		internal override bool DeepEquals(JToken node)
		{
			JObject jObject = node as JObject;
			if (jObject == null)
			{
				return false;
			}
			return _properties.Compare(jObject._properties);
		}

		internal override void InsertItem(int index, JToken item, bool skipParentCheck)
		{
			if (item == null || item.Type != JTokenType.Comment)
			{
				base.InsertItem(index, item, skipParentCheck);
			}
		}

		internal override void ValidateToken(JToken jtoken_0, JToken existing)
		{
			int num = 19;
			ValidationUtils.ArgumentNotNull(jtoken_0, "o");
			if (jtoken_0.Type != JTokenType.Property)
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not add {0} to {1}.", CultureInfo.InvariantCulture, jtoken_0.GetType(), GetType()));
			}
			JProperty jProperty = (JProperty)jtoken_0;
			if (existing != null)
			{
				JProperty jProperty2 = (JProperty)existing;
				if (jProperty.Name == jProperty2.Name)
				{
					return;
				}
			}
			if (_properties.TryGetValue(jProperty.Name, out existing))
			{
				throw new ArgumentException(StringUtils.FormatWith("Can not add property {0} to {1}. Property with the same name already exists on object.", CultureInfo.InvariantCulture, jProperty.Name, GetType()));
			}
		}

		internal override void MergeItem(object content, JsonMergeSettings settings)
		{
			JObject jObject = content as JObject;
			if (jObject != null)
			{
				foreach (KeyValuePair<string, JToken> item in jObject)
				{
					JProperty jProperty = Property(item.Key);
					if (jProperty == null)
					{
						Add(item.Key, item.Value);
					}
					else if (item.Value != null)
					{
						JContainer jContainer = jProperty.Value as JContainer;
						if (jContainer == null)
						{
							if (item.Value.Type != JTokenType.Null)
							{
								jProperty.Value = item.Value;
							}
						}
						else if (jContainer.Type != item.Value.Type)
						{
							jProperty.Value = item.Value;
						}
						else
						{
							jContainer.Merge(item.Value, settings);
						}
					}
				}
			}
		}

		internal void InternalPropertyChanged(JProperty childProperty)
		{
			OnPropertyChanged(childProperty.Name);
			if (_listChanged != null)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOfItem(childProperty)));
			}
		}

		internal void InternalPropertyChanging(JProperty childProperty)
		{
		}

		internal override JToken CloneToken()
		{
			return new JObject(this);
		}

		/// <summary>
		///       Gets an <see cref="T:System.Collections.Generic.IEnumerable`1" /> of this object's properties.
		///       </summary>
		/// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of this object's properties.</returns>
		public IEnumerable<JProperty> Properties()
		{
			return Enumerable.Cast<JProperty>(_properties);
		}

		/// <summary>
		///       Gets a <see cref="T:Open_Newtonsoft_Json.Linq.JProperty" /> the specified name.
		///       </summary>
		/// <param name="name">The property name.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JProperty" /> with the specified name or null.</returns>
		public JProperty Property(string name)
		{
			if (name == null)
			{
				return null;
			}
			_properties.TryGetValue(name, out JToken value);
			return (JProperty)value;
		}

		/// <summary>
		///       Gets an <see cref="T:Open_Newtonsoft_Json.Linq.JEnumerable`1" /> of this object's property values.
		///       </summary>
		/// <returns>An <see cref="T:Open_Newtonsoft_Json.Linq.JEnumerable`1" /> of this object's property values.</returns>
		public JEnumerable<JToken> PropertyValues()
		{
			return new JEnumerable<JToken>(Enumerable.Select(Properties(), (JProperty jproperty_0) => jproperty_0.Value));
		}

		/// <summary>
		///       Loads an <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> from a <see cref="T:Open_Newtonsoft_Json.JsonReader" />. 
		///       </summary>
		/// <param name="reader">A <see cref="T:Open_Newtonsoft_Json.JsonReader" /> that will be read for the content of the <see cref="T:Open_Newtonsoft_Json.Linq.JObject" />.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> that contains the JSON that was read from the specified <see cref="T:Open_Newtonsoft_Json.JsonReader" />.</returns>
		public new static JObject Load(JsonReader reader)
		{
			int num = 19;
			ValidationUtils.ArgumentNotNull(reader, "reader");
			if (reader.TokenType == JsonToken.None && !reader.Read())
			{
				throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader.");
			}
			while (reader.TokenType == JsonToken.Comment)
			{
				reader.Read();
			}
			if (reader.TokenType != JsonToken.StartObject)
			{
				throw JsonReaderException.Create(reader, StringUtils.FormatWith("Error reading JObject from JsonReader. Current JsonReader item is not an object: {0}", CultureInfo.InvariantCulture, reader.TokenType));
			}
			JObject jObject = new JObject();
			jObject.SetLineInfo(reader as IJsonLineInfo);
			jObject.ReadTokenFrom(reader);
			return jObject;
		}

		/// <summary>
		///       Load a <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> from a string that contains JSON.
		///       </summary>
		/// <param name="json">A <see cref="T:System.String" /> that contains JSON.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> populated from the string that contains JSON.</returns>
		/// <example>
		///   <code lang="cs" source="..\Src\Open_Newtonsoft_Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParse" title="Parsing a JSON Object from Text" />
		/// </example>
		public new static JObject Parse(string json)
		{
			int num = 7;
			using (JsonReader jsonReader = new JsonTextReader(new StringReader(json)))
			{
				JObject result = Load(jsonReader);
				if (jsonReader.Read() && jsonReader.TokenType != JsonToken.Comment)
				{
					throw JsonReaderException.Create(jsonReader, "Additional text found in JSON string after parsing content.");
				}
				return result;
			}
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> from an object.
		///       </summary>
		/// <param name="o">The object that will be used to create <see cref="T:Open_Newtonsoft_Json.Linq.JObject" />.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> with the values of the specified object</returns>
		public new static JObject FromObject(object object_0)
		{
			return FromObject(object_0, JsonSerializer.CreateDefault());
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> from an object.
		///       </summary>
		/// <param name="o">The object that will be used to create <see cref="T:Open_Newtonsoft_Json.Linq.JObject" />.</param>
		/// <param name="jsonSerializer">The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> that will be used to read the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JObject" /> with the values of the specified object</returns>
		public new static JObject FromObject(object object_0, JsonSerializer jsonSerializer)
		{
			int num = 5;
			JToken jToken = JToken.FromObjectInternal(object_0, jsonSerializer);
			if (jToken != null && jToken.Type != JTokenType.Object)
			{
				throw new ArgumentException(StringUtils.FormatWith("Object serialized to {0}. JObject instance expected.", CultureInfo.InvariantCulture, jToken.Type));
			}
			return (JObject)jToken;
		}

		/// <summary>
		///       Writes this token to a <see cref="T:Open_Newtonsoft_Json.JsonWriter" />.
		///       </summary>
		/// <param name="writer">A <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> into which this method will write.</param>
		/// <param name="converters">A collection of <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> which will be used when writing the token.</param>
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
		{
			writer.WriteStartObject();
			for (int i = 0; i < _properties.Count; i++)
			{
				_properties[i].WriteTo(writer, converters);
			}
			writer.WriteEndObject();
		}

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified property name.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified property name.</returns>
		public JToken GetValue(string propertyName)
		{
			return GetValue(propertyName, StringComparison.Ordinal);
		}

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified property name.
		///       The exact property name will be searched for first and if no matching property is found then
		///       the <see cref="T:System.StringComparison" /> will be used to match a property.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="comparison">One of the enumeration values that specifies how the strings will be compared.</param>
		/// <returns>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified property name.</returns>
		public JToken GetValue(string propertyName, StringComparison comparison)
		{
			if (propertyName == null)
			{
				return null;
			}
			JProperty jProperty = Property(propertyName);
			if (jProperty != null)
			{
				return jProperty.Value;
			}
			if (comparison != StringComparison.Ordinal)
			{
				foreach (JProperty property in _properties)
				{
					if (string.Equals(property.Name, propertyName, comparison))
					{
						return property.Value;
					}
				}
			}
			return null;
		}

		/// <summary>
		///       Tries to get the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified property name.
		///       The exact property name will be searched for first and if no matching property is found then
		///       the <see cref="T:System.StringComparison" /> will be used to match a property.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparison">One of the enumeration values that specifies how the strings will be compared.</param>
		/// <returns>true if a value was successfully retrieved; otherwise, false.</returns>
		public bool TryGetValue(string propertyName, StringComparison comparison, out JToken value)
		{
			value = GetValue(propertyName, comparison);
			return value != null;
		}

		/// <summary>
		///       Adds the specified property name.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="value">The value.</param>
		public void Add(string propertyName, JToken value)
		{
			Add(new JProperty(propertyName, value));
		}

		bool IDictionary<string, JToken>.ContainsKey(string string_0)
		{
			return _properties.Contains(string_0);
		}

		/// <summary>
		///       Removes the property with the specified name.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>true if item was successfully removed; otherwise, false.</returns>
		public bool Remove(string propertyName)
		{
			JProperty jProperty = Property(propertyName);
			if (jProperty == null)
			{
				return false;
			}
			jProperty.Remove();
			return true;
		}

		/// <summary>
		///       Tries the get value.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="value">The value.</param>
		/// <returns>true if a value was successfully retrieved; otherwise, false.</returns>
		public bool TryGetValue(string propertyName, out JToken value)
		{
			JProperty jProperty = Property(propertyName);
			if (jProperty == null)
			{
				value = null;
				return false;
			}
			value = jProperty.Value;
			return true;
		}

		void ICollection<KeyValuePair<string, JToken>>.Add(KeyValuePair<string, JToken> item)
		{
			Add(new JProperty(item.Key, item.Value));
		}

		void ICollection<KeyValuePair<string, JToken>>.Clear()
		{
			RemoveAll();
		}

		bool ICollection<KeyValuePair<string, JToken>>.Contains(KeyValuePair<string, JToken> item)
		{
			JProperty jProperty = Property(item.Key);
			if (jProperty == null)
			{
				return false;
			}
			return jProperty.Value == item.Value;
		}

		void ICollection<KeyValuePair<string, JToken>>.CopyTo(KeyValuePair<string, JToken>[] array, int arrayIndex)
		{
			int num = 19;
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
			if (base.Count > array.Length - arrayIndex)
			{
				throw new ArgumentException("The number of elements in the source JObject is greater than the available space from arrayIndex to the end of the destination array.");
			}
			int num2 = 0;
			foreach (JProperty property in _properties)
			{
				array[arrayIndex + num2] = new KeyValuePair<string, JToken>(property.Name, property.Value);
				num2++;
			}
		}

		bool ICollection<KeyValuePair<string, JToken>>.Remove(KeyValuePair<string, JToken> item)
		{
			if (!((ICollection<KeyValuePair<string, JToken>>)this).Contains(item))
			{
				return false;
			}
			((IDictionary<string, JToken>)this).Remove(item.Key);
			return true;
		}

		internal override int GetDeepHashCode()
		{
			return ContentsHashCode();
		}

		/// <summary>
		///       Returns an enumerator that iterates through the collection.
		///       </summary>
		/// <returns>
		///       A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		///       </returns>
		public IEnumerator<KeyValuePair<string, JToken>> GetEnumerator()
		{
			_003CGetEnumerator_003Ed__2 _003CGetEnumerator_003Ed__ = new _003CGetEnumerator_003Ed__2(0);
			_003CGetEnumerator_003Ed__._003C_003E4__this = this;
			return _003CGetEnumerator_003Ed__;
		}

		/// <summary>
		///       Raises the <see cref="E:Open_Newtonsoft_Json.Linq.JObject.PropertyChanged" /> event with the provided arguments.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return ((ICustomTypeDescriptor)this).GetProperties((Attribute[])null);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			using (IEnumerator<KeyValuePair<string, JToken>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					propertyDescriptorCollection.Add(new JPropertyDescriptor(enumerator.Current.Key));
				}
			}
			return propertyDescriptorCollection;
		}

		AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return AttributeCollection.Empty;
		}

		string ICustomTypeDescriptor.GetClassName()
		{
			return null;
		}

		string ICustomTypeDescriptor.GetComponentName()
		{
			return null;
		}

		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return new TypeConverter();
		}

		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return null;
		}

		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			return null;
		}

		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return null;
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return EventDescriptorCollection.Empty;
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return EventDescriptorCollection.Empty;
		}

		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor propertyDescriptor_0)
		{
			return null;
		}
	}
}
