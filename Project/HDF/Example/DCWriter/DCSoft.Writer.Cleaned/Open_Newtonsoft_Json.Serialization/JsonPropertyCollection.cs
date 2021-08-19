using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	/// <summary>
	///       A collection of <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> objects.
	///       </summary>
	[ComVisible(false)]
	public class JsonPropertyCollection : KeyedCollection<string, JsonProperty>
	{
		private readonly Type _type;

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Serialization.JsonPropertyCollection" /> class.
		///       </summary>
		/// <param name="type">The type.</param>
		public JsonPropertyCollection(Type type)
			: base((IEqualityComparer<string>)StringComparer.Ordinal)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			_type = type;
		}

		/// <summary>
		///       When implemented in a derived class, extracts the key from the specified element.
		///       </summary>
		/// <param name="item">The element from which to extract the key.</param>
		/// <returns>The key for the specified element.</returns>
		protected override string GetKeyForItem(JsonProperty item)
		{
			return item.PropertyName;
		}

		/// <summary>
		///       Adds a <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> object.
		///       </summary>
		/// <param name="property">The property to add to the collection.</param>
		public void AddProperty(JsonProperty property)
		{
			int num = 12;
			if (Contains(property.PropertyName))
			{
				if (property.Ignored)
				{
					return;
				}
				JsonProperty jsonProperty = base[property.PropertyName];
				bool flag = true;
				if (jsonProperty.Ignored)
				{
					Remove(jsonProperty);
					flag = false;
				}
				else if (property.DeclaringType != null && jsonProperty.DeclaringType != null)
				{
					if (property.DeclaringType.IsSubclassOf(jsonProperty.DeclaringType))
					{
						Remove(jsonProperty);
						flag = false;
					}
					if (jsonProperty.DeclaringType.IsSubclassOf(property.DeclaringType))
					{
						return;
					}
				}
				if (flag)
				{
					throw new JsonSerializationException(StringUtils.FormatWith("A member with the name '{0}' already exists on '{1}'. Use the JsonPropertyAttribute to specify another name.", CultureInfo.InvariantCulture, property.PropertyName, _type));
				}
			}
			Add(property);
		}

		/// <summary>
		///       Gets the closest matching <see cref="T:Open_Newtonsoft_Json.Serialization.JsonProperty" /> object.
		///       First attempts to get an exact case match of propertyName and then
		///       a case insensitive match.
		///       </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>A matching property if found.</returns>
		public JsonProperty GetClosestMatchProperty(string propertyName)
		{
			JsonProperty property = GetProperty(propertyName, StringComparison.Ordinal);
			if (property == null)
			{
				property = GetProperty(propertyName, StringComparison.OrdinalIgnoreCase);
			}
			return property;
		}

		private bool TryGetValue(string string_0, out JsonProperty item)
		{
			if (base.Dictionary == null)
			{
				item = null;
				return false;
			}
			return base.Dictionary.TryGetValue(string_0, out item);
		}

		/// <summary>
		///       Gets a property by property name.
		///       </summary>
		/// <param name="propertyName">The name of the property to get.</param>
		/// <param name="comparisonType">Type property name string comparison.</param>
		/// <returns>A matching property if found.</returns>
		public JsonProperty GetProperty(string propertyName, StringComparison comparisonType)
		{
			if (comparisonType == StringComparison.Ordinal)
			{
				if (TryGetValue(propertyName, out JsonProperty item))
				{
					return item;
				}
				return null;
			}
			using (IEnumerator<JsonProperty> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					JsonProperty item = enumerator.Current;
					if (string.Equals(propertyName, item.PropertyName, comparisonType))
					{
						return item;
					}
				}
			}
			return null;
		}
	}
}
