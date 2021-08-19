using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a JSON array.
	///       </summary>
	/// <example>
	///   <code lang="cs" source="..\Src\Open_Newtonsoft_Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParseArray" title="Parsing a JSON Array from Text" />
	/// </example>
	[ComVisible(false)]
	public class JArray : JContainer, IList<JToken>
	{
		private readonly List<JToken> _values = new List<JToken>();

		/// <summary>
		///       Gets the container's children tokens.
		///       </summary>
		/// <value>The container's children tokens.</value>
		protected override IList<JToken> ChildrenTokens => _values;

		/// <summary>
		///       Gets the node type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <value>The type.</value>
		public override JTokenType Type => JTokenType.Array;

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.
		///       </summary>
		/// <value>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.</value>
		public override JToken this[object object_0]
		{
			get
			{
				int num = 7;
				ValidationUtils.ArgumentNotNull(object_0, "o");
				if (!(object_0 is int))
				{
					throw new ArgumentException(StringUtils.FormatWith("Accessed JArray values with invalid key value: {0}. Array position index expected.", CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(object_0)));
				}
				return GetItem((int)object_0);
			}
			set
			{
				int num = 2;
				ValidationUtils.ArgumentNotNull(object_0, "o");
				if (!(object_0 is int))
				{
					throw new ArgumentException(StringUtils.FormatWith("Set JArray values with invalid key value: {0}. Array position index expected.", CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(object_0)));
				}
				SetItem((int)object_0, value);
			}
		}

		/// <summary>
		///       Gets or sets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> at the specified index.
		///       </summary>
		/// <value>
		/// </value>
		public JToken this[int index]
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

		/// <summary>
		///       Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
		///       </summary>
		/// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.</returns>
		public bool IsReadOnly => false;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> class.
		///       </summary>
		public JArray()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> class from another <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> object.
		///       </summary>
		/// <param name="other">A <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> object to copy from.</param>
		public JArray(JArray other)
			: base(other)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> class with the specified content.
		///       </summary>
		/// <param name="content">The contents of the array.</param>
		public JArray(params object[] content)
			: this((object)content)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> class with the specified content.
		///       </summary>
		/// <param name="content">The contents of the array.</param>
		public JArray(object content)
		{
			Add(content);
		}

		internal override bool DeepEquals(JToken node)
		{
			JArray jArray = node as JArray;
			return jArray != null && ContentsEqual(jArray);
		}

		internal override JToken CloneToken()
		{
			return new JArray(this);
		}

		/// <summary>
		///       Loads an <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> from a <see cref="T:Open_Newtonsoft_Json.JsonReader" />. 
		///       </summary>
		/// <param name="reader">A <see cref="T:Open_Newtonsoft_Json.JsonReader" /> that will be read for the content of the <see cref="T:Open_Newtonsoft_Json.Linq.JArray" />.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> that contains the JSON that was read from the specified <see cref="T:Open_Newtonsoft_Json.JsonReader" />.</returns>
		public new static JArray Load(JsonReader reader)
		{
			int num = 19;
			if (reader.TokenType == JsonToken.None && !reader.Read())
			{
				throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader.");
			}
			while (reader.TokenType == JsonToken.Comment)
			{
				reader.Read();
			}
			if (reader.TokenType != JsonToken.StartArray)
			{
				throw JsonReaderException.Create(reader, StringUtils.FormatWith("Error reading JArray from JsonReader. Current JsonReader item is not an array: {0}", CultureInfo.InvariantCulture, reader.TokenType));
			}
			JArray jArray = new JArray();
			jArray.SetLineInfo(reader as IJsonLineInfo);
			jArray.ReadTokenFrom(reader);
			return jArray;
		}

		/// <summary>
		///       Load a <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> from a string that contains JSON.
		///       </summary>
		/// <param name="json">A <see cref="T:System.String" /> that contains JSON.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> populated from the string that contains JSON.</returns>
		/// <example>
		///   <code lang="cs" source="..\Src\Open_Newtonsoft_Json.Tests\Documentation\LinqToJsonTests.cs" region="LinqToJsonCreateParseArray" title="Parsing a JSON Array from Text" />
		/// </example>
		public new static JArray Parse(string json)
		{
			int num = 18;
			using (JsonReader jsonReader = new JsonTextReader(new StringReader(json)))
			{
				JArray result = Load(jsonReader);
				if (jsonReader.Read() && jsonReader.TokenType != JsonToken.Comment)
				{
					throw JsonReaderException.Create(jsonReader, "Additional text found in JSON string after parsing content.");
				}
				return result;
			}
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> from an object.
		///       </summary>
		/// <param name="o">The object that will be used to create <see cref="T:Open_Newtonsoft_Json.Linq.JArray" />.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> with the values of the specified object</returns>
		public new static JArray FromObject(object object_0)
		{
			return FromObject(object_0, JsonSerializer.CreateDefault());
		}

		/// <summary>
		///       Creates a <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> from an object.
		///       </summary>
		/// <param name="o">The object that will be used to create <see cref="T:Open_Newtonsoft_Json.Linq.JArray" />.</param>
		/// <param name="jsonSerializer">The <see cref="T:Open_Newtonsoft_Json.JsonSerializer" /> that will be used to read the object.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JArray" /> with the values of the specified object</returns>
		public new static JArray FromObject(object object_0, JsonSerializer jsonSerializer)
		{
			int num = 8;
			JToken jToken = JToken.FromObjectInternal(object_0, jsonSerializer);
			if (jToken.Type != JTokenType.Array)
			{
				throw new ArgumentException(StringUtils.FormatWith("Object serialized to {0}. JArray instance expected.", CultureInfo.InvariantCulture, jToken.Type));
			}
			return (JArray)jToken;
		}

		/// <summary>
		///       Writes this token to a <see cref="T:Open_Newtonsoft_Json.JsonWriter" />.
		///       </summary>
		/// <param name="writer">A <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> into which this method will write.</param>
		/// <param name="converters">A collection of <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> which will be used when writing the token.</param>
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
		{
			writer.WriteStartArray();
			for (int i = 0; i < _values.Count; i++)
			{
				_values[i].WriteTo(writer, converters);
			}
			writer.WriteEndArray();
		}

		internal override void MergeItem(object content, JsonMergeSettings settings)
		{
			IEnumerable enumerable = (IsMultiContent(content) || content is JArray) ? ((IEnumerable)content) : null;
			if (enumerable != null)
			{
				JContainer.MergeEnumerableContent(this, enumerable, settings);
			}
		}

		/// <summary>
		///       Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
		///       </summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
		/// <returns>
		///       The index of <paramref name="item" /> if found in the list; otherwise, -1.
		///       </returns>
		public int IndexOf(JToken item)
		{
			return IndexOfItem(item);
		}

		/// <summary>
		///       Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
		///       </summary>
		/// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
		/// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1" /> is read-only.</exception>
		public void Insert(int index, JToken item)
		{
			InsertItem(index, item, skipParentCheck: false);
		}

		/// <summary>
		///       Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
		///       </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1" /> is read-only.</exception>
		public void RemoveAt(int index)
		{
			RemoveItemAt(index);
		}

		/// <summary>
		///       Returns an enumerator that iterates through the collection.
		///       </summary>
		/// <returns>
		///       A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		///       </returns>
		public IEnumerator<JToken> GetEnumerator()
		{
			return Children().GetEnumerator();
		}

		/// <summary>
		///       Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
		///       </summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public void Add(JToken item)
		{
			Add((object)item);
		}

		/// <summary>
		///       Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
		///       </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only. </exception>
		public void Clear()
		{
			ClearItems();
		}

		/// <summary>
		///       Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
		///       </summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
		/// <returns>
		///       true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
		///       </returns>
		public bool Contains(JToken item)
		{
			return ContainsItem(item);
		}

		/// <summary>
		///       Copies to.
		///       </summary>
		/// <param name="array">The array.</param>
		/// <param name="arrayIndex">Index of the array.</param>
		public void CopyTo(JToken[] array, int arrayIndex)
		{
			CopyItemsTo(array, arrayIndex);
		}

		/// <summary>
		///       Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
		///       </summary>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
		/// <returns>
		///       true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
		///       </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
		public bool Remove(JToken item)
		{
			return RemoveItem(item);
		}

		internal override int GetDeepHashCode()
		{
			return ContentsHashCode();
		}
	}
}
