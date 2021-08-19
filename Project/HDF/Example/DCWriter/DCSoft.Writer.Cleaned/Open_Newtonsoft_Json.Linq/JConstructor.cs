using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Linq
{
	/// <summary>
	///       Represents a JSON constructor.
	///       </summary>
	[ComVisible(false)]
	public class JConstructor : JContainer
	{
		private string _name;

		private readonly List<JToken> _values = new List<JToken>();

		/// <summary>
		///       Gets the container's children tokens.
		///       </summary>
		/// <value>The container's children tokens.</value>
		protected override IList<JToken> ChildrenTokens => _values;

		/// <summary>
		///       Gets or sets the name of this constructor.
		///       </summary>
		/// <value>The constructor name.</value>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		/// <summary>
		///       Gets the node type for this <see cref="T:Open_Newtonsoft_Json.Linq.JToken" />.
		///       </summary>
		/// <value>The type.</value>
		public override JTokenType Type => JTokenType.Constructor;

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.
		///       </summary>
		/// <value>The <see cref="T:Open_Newtonsoft_Json.Linq.JToken" /> with the specified key.</value>
		public override JToken this[object object_0]
		{
			get
			{
				int num = 9;
				ValidationUtils.ArgumentNotNull(object_0, "o");
				if (!(object_0 is int))
				{
					throw new ArgumentException(StringUtils.FormatWith("Accessed JConstructor values with invalid key value: {0}. Argument position index expected.", CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(object_0)));
				}
				return GetItem((int)object_0);
			}
			set
			{
				int num = 16;
				ValidationUtils.ArgumentNotNull(object_0, "o");
				if (!(object_0 is int))
				{
					throw new ArgumentException(StringUtils.FormatWith("Set JConstructor values with invalid key value: {0}. Argument position index expected.", CultureInfo.InvariantCulture, MiscellaneousUtils.ToString(object_0)));
				}
				SetItem((int)object_0, value);
			}
		}

		internal override void MergeItem(object content, JsonMergeSettings settings)
		{
			JConstructor jConstructor = content as JConstructor;
			if (jConstructor != null)
			{
				if (jConstructor.Name != null)
				{
					Name = jConstructor.Name;
				}
				JContainer.MergeEnumerableContent(this, jConstructor, settings);
			}
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> class.
		///       </summary>
		public JConstructor()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> class from another <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> object.
		///       </summary>
		/// <param name="other">A <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> object to copy from.</param>
		public JConstructor(JConstructor other)
			: base(other)
		{
			_name = other.Name;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> class with the specified name and content.
		///       </summary>
		/// <param name="name">The constructor name.</param>
		/// <param name="content">The contents of the constructor.</param>
		public JConstructor(string name, params object[] content)
			: this(name, (object)content)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> class with the specified name and content.
		///       </summary>
		/// <param name="name">The constructor name.</param>
		/// <param name="content">The contents of the constructor.</param>
		public JConstructor(string name, object content)
			: this(name)
		{
			Add(content);
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> class with the specified name.
		///       </summary>
		/// <param name="name">The constructor name.</param>
		public JConstructor(string name)
		{
			ValidationUtils.ArgumentNotNullOrEmpty(name, "name");
			_name = name;
		}

		internal override bool DeepEquals(JToken node)
		{
			JConstructor jConstructor = node as JConstructor;
			return jConstructor != null && _name == jConstructor.Name && ContentsEqual(jConstructor);
		}

		internal override JToken CloneToken()
		{
			return new JConstructor(this);
		}

		/// <summary>
		///       Writes this token to a <see cref="T:Open_Newtonsoft_Json.JsonWriter" />.
		///       </summary>
		/// <param name="writer">A <see cref="T:Open_Newtonsoft_Json.JsonWriter" /> into which this method will write.</param>
		/// <param name="converters">A collection of <see cref="T:Open_Newtonsoft_Json.JsonConverter" /> which will be used when writing the token.</param>
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
		{
			writer.WriteStartConstructor(_name);
			foreach (JToken item in Children())
			{
				item.WriteTo(writer, converters);
			}
			writer.WriteEndConstructor();
		}

		internal override int GetDeepHashCode()
		{
			return _name.GetHashCode() ^ ContentsHashCode();
		}

		/// <summary>
		///       Loads an <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> from a <see cref="T:Open_Newtonsoft_Json.JsonReader" />. 
		///       </summary>
		/// <param name="reader">A <see cref="T:Open_Newtonsoft_Json.JsonReader" /> that will be read for the content of the <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" />.</param>
		/// <returns>A <see cref="T:Open_Newtonsoft_Json.Linq.JConstructor" /> that contains the JSON that was read from the specified <see cref="T:Open_Newtonsoft_Json.JsonReader" />.</returns>
		public new static JConstructor Load(JsonReader reader)
		{
			int num = 16;
			if (reader.TokenType == JsonToken.None && !reader.Read())
			{
				throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader.");
			}
			while (reader.TokenType == JsonToken.Comment)
			{
				reader.Read();
			}
			if (reader.TokenType != JsonToken.StartConstructor)
			{
				throw JsonReaderException.Create(reader, StringUtils.FormatWith("Error reading JConstructor from JsonReader. Current JsonReader item is not a constructor: {0}", CultureInfo.InvariantCulture, reader.TokenType));
			}
			JConstructor jConstructor = new JConstructor((string)reader.Value);
			jConstructor.SetLineInfo(reader as IJsonLineInfo);
			jConstructor.ReadTokenFrom(reader);
			return jConstructor;
		}
	}
}
