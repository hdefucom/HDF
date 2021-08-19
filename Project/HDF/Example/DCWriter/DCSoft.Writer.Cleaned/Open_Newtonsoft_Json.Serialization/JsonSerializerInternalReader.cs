using Open_Newtonsoft_Json.Linq;
using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal class JsonSerializerInternalReader : JsonSerializerInternalBase
	{
		[ComVisible(false)]
		internal enum PropertyPresence
		{
			None,
			Null,
			Value
		}

		public JsonSerializerInternalReader(JsonSerializer serializer)
			: base(serializer)
		{
		}

		public void Populate(JsonReader reader, object target)
		{
			int num = 15;
			ValidationUtils.ArgumentNotNull(target, "target");
			Type type = target.GetType();
			JsonContract jsonContract = Serializer._contractResolver.ResolveContract(type);
			if (reader.TokenType == JsonToken.None)
			{
				reader.Read();
			}
			if (reader.TokenType == JsonToken.StartArray)
			{
				if (jsonContract.ContractType == JsonContractType.Array)
				{
					JsonArrayContract jsonArrayContract = (JsonArrayContract)jsonContract;
					PopulateList(jsonArrayContract.ShouldCreateWrapper ? jsonArrayContract.CreateWrapper(target) : ((IList)target), reader, jsonArrayContract, null, null);
					return;
				}
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot populate JSON array onto type '{0}'.", CultureInfo.InvariantCulture, type));
			}
			if (reader.TokenType == JsonToken.StartObject)
			{
				CheckedRead(reader);
				string string_ = null;
				if (Serializer.MetadataPropertyHandling != MetadataPropertyHandling.Ignore && reader.TokenType == JsonToken.PropertyName && string.Equals(reader.Value.ToString(), "$id", StringComparison.Ordinal))
				{
					CheckedRead(reader);
					string_ = ((reader.Value != null) ? reader.Value.ToString() : null);
					CheckedRead(reader);
				}
				if (jsonContract.ContractType == JsonContractType.Dictionary)
				{
					JsonDictionaryContract jsonDictionaryContract = (JsonDictionaryContract)jsonContract;
					PopulateDictionary(jsonDictionaryContract.ShouldCreateWrapper ? jsonDictionaryContract.CreateWrapper(target) : ((IDictionary)target), reader, jsonDictionaryContract, null, string_);
					return;
				}
				if (jsonContract.ContractType == JsonContractType.Object)
				{
					PopulateObject(target, reader, (JsonObjectContract)jsonContract, null, string_);
					return;
				}
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot populate JSON object onto type '{0}'.", CultureInfo.InvariantCulture, type));
			}
			throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected initial token '{0}' when populating object. Expected JSON object or array.", CultureInfo.InvariantCulture, reader.TokenType));
		}

		private JsonContract GetContractSafe(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return Serializer._contractResolver.ResolveContract(type);
		}

		public object Deserialize(JsonReader reader, Type objectType, bool checkAdditionalContent)
		{
			int num = 12;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			JsonContract contractSafe = GetContractSafe(objectType);
			try
			{
				JsonConverter converter = GetConverter(contractSafe, null, null, null);
				if (reader.TokenType == JsonToken.None && !ReadForType(reader, contractSafe, converter != null))
				{
					if (!(contractSafe?.IsNullable ?? true))
					{
						throw JsonSerializationException.Create(reader, StringUtils.FormatWith("No JSON content found and type '{0}' is not nullable.", CultureInfo.InvariantCulture, contractSafe.UnderlyingType));
					}
					return null;
				}
				object result = (converter == null || !converter.CanRead) ? CreateValueInternal(reader, objectType, contractSafe, null, null, null, null) : DeserializeConvertable(converter, reader, objectType, null);
				if (checkAdditionalContent && reader.Read() && reader.TokenType != JsonToken.Comment)
				{
					throw new JsonSerializationException("Additional text found in JSON string after finishing deserializing object.");
				}
				return result;
			}
			catch (Exception exception_)
			{
				if (!IsErrorHandled(null, contractSafe, null, reader as IJsonLineInfo, reader.Path, exception_))
				{
					ClearErrorContext();
					throw;
				}
				HandleError(reader, readPastError: false, 0);
				return null;
			}
		}

		private JsonSerializerProxy GetInternalSerializer()
		{
			if (InternalSerializer == null)
			{
				InternalSerializer = new JsonSerializerProxy(this);
			}
			return InternalSerializer;
		}

		private JToken CreateJToken(JsonReader reader, JsonContract contract)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			if (contract != null)
			{
				if (contract.UnderlyingType == typeof(JRaw))
				{
					return JRaw.Create(reader);
				}
				if (reader.TokenType == JsonToken.Null && contract.UnderlyingType != typeof(JValue) && contract.UnderlyingType != typeof(JToken))
				{
					return null;
				}
			}
			JToken token;
			using (JTokenWriter jTokenWriter = new JTokenWriter())
			{
				jTokenWriter.WriteToken(reader);
				token = jTokenWriter.Token;
			}
			return token;
		}

		private JToken CreateJObject(JsonReader reader)
		{
			int num = 2;
			ValidationUtils.ArgumentNotNull(reader, "reader");
			using (JTokenWriter jTokenWriter = new JTokenWriter())
			{
				jTokenWriter.WriteStartObject();
				while (true)
				{
					if (reader.TokenType != JsonToken.PropertyName)
					{
						if (reader.TokenType != JsonToken.Comment)
						{
							break;
						}
					}
					else
					{
						string text = (string)reader.Value;
						while (reader.Read() && reader.TokenType == JsonToken.Comment)
						{
						}
						if (!CheckPropertyName(reader, text))
						{
							jTokenWriter.WritePropertyName(text);
							jTokenWriter.WriteToken(reader, writeChildren: true, writeDateConstructorAsDate: true);
						}
					}
					if (!reader.Read())
					{
						throw JsonSerializationException.Create(reader, "Unexpected end when deserializing object.");
					}
				}
				jTokenWriter.WriteEndObject();
				return jTokenWriter.Token;
			}
		}

		private object CreateValueInternal(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue)
		{
			int num = 11;
			if (contract != null && contract.ContractType == JsonContractType.Linq)
			{
				return CreateJToken(reader, contract);
			}
			do
			{
				switch (reader.TokenType)
				{
				case JsonToken.Comment:
					break;
				case JsonToken.StartObject:
					return CreateObject(reader, objectType, contract, member, containerContract, containerMember, existingValue);
				case JsonToken.StartArray:
					return CreateList(reader, objectType, contract, member, existingValue, null);
				case JsonToken.StartConstructor:
				{
					string value = reader.Value.ToString();
					return EnsureType(reader, value, CultureInfo.InvariantCulture, contract, objectType);
				}
				case JsonToken.Raw:
					return new JRaw((string)reader.Value);
				case JsonToken.String:
				{
					string text = (string)reader.Value;
					if (CoerceEmptyStringToNull(objectType, contract, text))
					{
						return null;
					}
					if (objectType == typeof(byte[]))
					{
						return Convert.FromBase64String(text);
					}
					return EnsureType(reader, text, CultureInfo.InvariantCulture, contract, objectType);
				}
				case JsonToken.Null:
				case JsonToken.Undefined:
					if (objectType == typeof(DBNull))
					{
						return DBNull.Value;
					}
					return EnsureType(reader, reader.Value, CultureInfo.InvariantCulture, contract, objectType);
				default:
					throw JsonSerializationException.Create(reader, "Unexpected token while deserializing object: " + reader.TokenType);
				case JsonToken.Integer:
				case JsonToken.Float:
				case JsonToken.Boolean:
				case JsonToken.Date:
				case JsonToken.Bytes:
					return EnsureType(reader, reader.Value, CultureInfo.InvariantCulture, contract, objectType);
				}
			}
			while (reader.Read());
			throw JsonSerializationException.Create(reader, "Unexpected end when deserializing object.");
		}

		private static bool CoerceEmptyStringToNull(Type objectType, JsonContract contract, string string_0)
		{
			return string.IsNullOrEmpty(string_0) && objectType != null && objectType != typeof(string) && objectType != typeof(object) && contract != null && contract.IsNullable;
		}

		internal string GetExpectedDescription(JsonContract contract)
		{
			int num = 7;
			switch (contract.ContractType)
			{
			case JsonContractType.Array:
				return "JSON array (e.g. [1,2,3])";
			case JsonContractType.Primitive:
				return "JSON primitive value (e.g. string, number, boolean, null)";
			case JsonContractType.String:
				return "JSON string value";
			default:
				throw new ArgumentOutOfRangeException();
			case JsonContractType.Object:
			case JsonContractType.Dictionary:
			case JsonContractType.Serializable:
				return "JSON object (e.g. {\"name\":\"value\"})";
			}
		}

		private JsonConverter GetConverter(JsonContract contract, JsonConverter memberConverter, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			JsonConverter result = null;
			if (memberConverter != null)
			{
				result = memberConverter;
			}
			else if (containerProperty != null && containerProperty.ItemConverter != null)
			{
				result = containerProperty.ItemConverter;
			}
			else if (containerContract != null && containerContract.ItemConverter != null)
			{
				result = containerContract.ItemConverter;
			}
			else if (contract != null)
			{
				JsonConverter matchingConverter;
				if (contract.Converter != null)
				{
					result = contract.Converter;
				}
				else if ((matchingConverter = Serializer.GetMatchingConverter(contract.UnderlyingType)) != null)
				{
					result = matchingConverter;
				}
				else if (contract.InternalConverter != null)
				{
					result = contract.InternalConverter;
				}
			}
			return result;
		}

		private object CreateObject(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue)
		{
			int num = 7;
			Type objectType2 = objectType;
			string string_;
			object newValue;
			if (Serializer.MetadataPropertyHandling == MetadataPropertyHandling.Ignore)
			{
				CheckedRead(reader);
				string_ = null;
			}
			else if (Serializer.MetadataPropertyHandling == MetadataPropertyHandling.ReadAhead)
			{
				JTokenReader jTokenReader = reader as JTokenReader;
				if (jTokenReader == null)
				{
					JToken jToken = JToken.ReadFrom(reader);
					jTokenReader = (JTokenReader)jToken.CreateReader();
					jTokenReader.Culture = reader.Culture;
					jTokenReader.DateFormatString = reader.DateFormatString;
					jTokenReader.DateParseHandling = reader.DateParseHandling;
					jTokenReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
					jTokenReader.FloatParseHandling = reader.FloatParseHandling;
					jTokenReader.SupportMultipleContent = reader.SupportMultipleContent;
					CheckedRead(jTokenReader);
					reader = jTokenReader;
				}
				if (ReadMetadataPropertiesToken(jTokenReader, ref objectType2, ref contract, member, containerContract, containerMember, existingValue, out newValue, out string_))
				{
					return newValue;
				}
			}
			else
			{
				CheckedRead(reader);
				if (ReadMetadataProperties(reader, ref objectType2, ref contract, member, containerContract, containerMember, existingValue, out newValue, out string_))
				{
					return newValue;
				}
			}
			if (HasNoDefinedType(contract))
			{
				return CreateJObject(reader);
			}
			switch (contract.ContractType)
			{
			case JsonContractType.Object:
			{
				bool createdFromNonDefaultCreator = false;
				JsonObjectContract jsonObjectContract = (JsonObjectContract)contract;
				object obj = (existingValue == null || (objectType2 != objectType && !objectType2.IsAssignableFrom(existingValue.GetType()))) ? CreateNewObject(reader, jsonObjectContract, member, containerMember, string_, out createdFromNonDefaultCreator) : existingValue;
				if (createdFromNonDefaultCreator)
				{
					return obj;
				}
				return PopulateObject(obj, reader, jsonObjectContract, member, string_);
			}
			case JsonContractType.Primitive:
			{
				JsonPrimitiveContract contract3 = (JsonPrimitiveContract)contract;
				if (Serializer.MetadataPropertyHandling != MetadataPropertyHandling.Ignore && reader.TokenType == JsonToken.PropertyName && string.Equals(reader.Value.ToString(), "$value", StringComparison.Ordinal))
				{
					CheckedRead(reader);
					if (reader.TokenType == JsonToken.StartObject)
					{
						throw JsonSerializationException.Create(reader, "Unexpected token when deserializing primitive value: " + reader.TokenType);
					}
					object result2 = CreateValueInternal(reader, objectType2, contract3, member, null, null, existingValue);
					CheckedRead(reader);
					return result2;
				}
				goto default;
			}
			case JsonContractType.Dictionary:
			{
				JsonDictionaryContract jsonDictionaryContract = (JsonDictionaryContract)contract;
				object result;
				if (existingValue == null)
				{
					bool createdFromNonDefaultCreator;
					IDictionary dictionary = CreateNewDictionary(reader, jsonDictionaryContract, out createdFromNonDefaultCreator);
					if (createdFromNonDefaultCreator)
					{
						if (string_ != null)
						{
							throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot preserve reference to readonly dictionary, or dictionary created from a non-default constructor: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
						}
						if (contract.OnSerializingCallbacks.Count > 0)
						{
							throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot call OnSerializing on readonly dictionary, or dictionary created from a non-default constructor: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
						}
						if (contract.OnErrorCallbacks.Count > 0)
						{
							throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot call OnError on readonly list, or dictionary created from a non-default constructor: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
						}
						if (!jsonDictionaryContract.HasParametrizedCreator)
						{
							throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot deserialize readonly or fixed size dictionary: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
						}
					}
					PopulateDictionary(dictionary, reader, jsonDictionaryContract, member, string_);
					if (createdFromNonDefaultCreator)
					{
						return jsonDictionaryContract.ParametrizedCreator(dictionary);
					}
					if (dictionary is IWrappedDictionary)
					{
						return ((IWrappedDictionary)dictionary).UnderlyingDictionary;
					}
					result = dictionary;
				}
				else
				{
					result = PopulateDictionary(jsonDictionaryContract.ShouldCreateWrapper ? jsonDictionaryContract.CreateWrapper(existingValue) : ((IDictionary)existingValue), reader, jsonDictionaryContract, member, string_);
				}
				return result;
			}
			default:
			{
				string format = "Cannot deserialize the current JSON object (e.g. {{\"name\":\"value\"}}) into type '{0}' because the type requires a {1} to deserialize correctly." + Environment.NewLine + "To fix this error either change the JSON to a {1} or change the deserialized type so that it is a normal .NET type (e.g. not a primitive type like integer, not a collection type like an array or List<T>) that can be deserialized from a JSON object. JsonObjectAttribute can also be added to the type to force it to deserialize from a JSON object." + Environment.NewLine;
				format = StringUtils.FormatWith(format, CultureInfo.InvariantCulture, objectType2, GetExpectedDescription(contract));
				throw JsonSerializationException.Create(reader, format);
			}
			case JsonContractType.Serializable:
			{
				JsonISerializableContract contract2 = (JsonISerializableContract)contract;
				return CreateISerializable(reader, contract2, member, string_);
			}
			}
		}

		private bool ReadMetadataPropertiesToken(JTokenReader reader, ref Type objectType, ref JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue, out object newValue, out string string_0)
		{
			int num = 13;
			string_0 = null;
			newValue = null;
			if (reader.TokenType == JsonToken.StartObject)
			{
				JObject jObject = (JObject)reader.CurrentToken;
				JToken jToken = jObject["$ref"];
				if (jToken != null)
				{
					if (jToken.Type != JTokenType.String && jToken.Type != JTokenType.Null)
					{
						throw JsonSerializationException.Create(jToken, jToken.Path, StringUtils.FormatWith("JSON reference {0} property must have a string or null value.", CultureInfo.InvariantCulture, "$ref"), null);
					}
					JToken parent = jToken.Parent;
					JToken jToken2 = null;
					if (parent.Next != null)
					{
						jToken2 = parent.Next;
					}
					else if (parent.Previous != null)
					{
						jToken2 = parent.Previous;
					}
					string text = (string)jToken;
					if (text != null)
					{
						if (jToken2 != null)
						{
							throw JsonSerializationException.Create(jToken2, jToken2.Path, StringUtils.FormatWith("Additional content found in JSON reference object. A JSON reference object should only have a {0} property.", CultureInfo.InvariantCulture, "$ref"), null);
						}
						newValue = Serializer.GetReferenceResolver().ResolveReference(this, text);
						if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
						{
							TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader, reader.Path, StringUtils.FormatWith("Resolved object reference '{0}' to {1}.", CultureInfo.InvariantCulture, text, newValue.GetType())), null);
						}
						reader.Skip();
						return true;
					}
				}
				JToken jToken3 = jObject["$type"];
				if (jToken3 != null)
				{
					string qualifiedTypeName = (string)jToken3;
					JsonReader reader2 = jToken3.CreateReader();
					CheckedRead(reader2);
					ResolveTypeName(reader2, ref objectType, ref contract, member, containerContract, containerMember, qualifiedTypeName);
					JToken jToken4 = jObject["$value"];
					if (jToken4 != null)
					{
						while (true)
						{
							CheckedRead(reader);
							if (reader.TokenType != JsonToken.PropertyName || !((string)reader.Value == "$value"))
							{
								CheckedRead(reader);
								reader.Skip();
								continue;
							}
							break;
						}
						return false;
					}
				}
				JToken jToken5 = jObject["$id"];
				if (jToken5 != null)
				{
					string_0 = (string)jToken5;
				}
				JToken jToken6 = jObject["$values"];
				if (jToken6 != null)
				{
					JsonReader reader3 = jToken6.CreateReader();
					CheckedRead(reader3);
					newValue = CreateList(reader3, objectType, contract, member, existingValue, string_0);
					reader.Skip();
					return true;
				}
			}
			CheckedRead(reader);
			return false;
		}

		private bool ReadMetadataProperties(JsonReader reader, ref Type objectType, ref JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, object existingValue, out object newValue, out string string_0)
		{
			int num = 19;
			string_0 = null;
			newValue = null;
			if (reader.TokenType == JsonToken.PropertyName)
			{
				string text = reader.Value.ToString();
				if (text.Length > 0 && text[0] == '$')
				{
					bool flag;
					do
					{
						text = reader.Value.ToString();
						if (!string.Equals(text, "$ref", StringComparison.Ordinal))
						{
							if (string.Equals(text, "$type", StringComparison.Ordinal))
							{
								CheckedRead(reader);
								string qualifiedTypeName = reader.Value.ToString();
								ResolveTypeName(reader, ref objectType, ref contract, member, containerContract, containerMember, qualifiedTypeName);
								CheckedRead(reader);
								flag = true;
								continue;
							}
							if (string.Equals(text, "$id", StringComparison.Ordinal))
							{
								CheckedRead(reader);
								string_0 = ((reader.Value != null) ? reader.Value.ToString() : null);
								CheckedRead(reader);
								flag = true;
								continue;
							}
							if (!string.Equals(text, "$values", StringComparison.Ordinal))
							{
								flag = false;
								continue;
							}
							CheckedRead(reader);
							object obj = CreateList(reader, objectType, contract, member, existingValue, string_0);
							CheckedRead(reader);
							newValue = obj;
							return true;
						}
						CheckedRead(reader);
						if (reader.TokenType == JsonToken.String || reader.TokenType == JsonToken.Null)
						{
							string text2 = (reader.Value != null) ? reader.Value.ToString() : null;
							CheckedRead(reader);
							if (text2 == null)
							{
								flag = true;
								continue;
							}
							if (reader.TokenType == JsonToken.PropertyName)
							{
								throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Additional content found in JSON reference object. A JSON reference object should only have a {0} property.", CultureInfo.InvariantCulture, "$ref"));
							}
							newValue = Serializer.GetReferenceResolver().ResolveReference(this, text2);
							if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
							{
								TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Resolved object reference '{0}' to {1}.", CultureInfo.InvariantCulture, text2, newValue.GetType())), null);
							}
							return true;
						}
						throw JsonSerializationException.Create(reader, StringUtils.FormatWith("JSON reference {0} property must have a string or null value.", CultureInfo.InvariantCulture, "$ref"));
					}
					while (flag && reader.TokenType == JsonToken.PropertyName);
				}
			}
			return false;
		}

		private void ResolveTypeName(JsonReader reader, ref Type objectType, ref JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, string qualifiedTypeName)
		{
			int num = 19;
			if ((member?.TypeNameHandling ?? containerContract?.ItemTypeNameHandling ?? containerMember?.ItemTypeNameHandling ?? Serializer._typeNameHandling) != 0)
			{
				ReflectionUtils.SplitFullyQualifiedTypeName(qualifiedTypeName, out string typeName, out string assemblyName);
				Type type;
				try
				{
					type = Serializer._binder.BindToType(assemblyName, typeName);
				}
				catch (Exception exception_)
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Error resolving type specified in JSON '{0}'.", CultureInfo.InvariantCulture, qualifiedTypeName), exception_);
				}
				if (type == null)
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Type specified in JSON '{0}' was not resolved.", CultureInfo.InvariantCulture, qualifiedTypeName));
				}
				if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
				{
					TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Resolved type '{0}' to {1}.", CultureInfo.InvariantCulture, qualifiedTypeName, type)), null);
				}
				if (objectType != null && !objectType.IsAssignableFrom(type))
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Type specified in JSON '{0}' is not compatible with '{1}'.", CultureInfo.InvariantCulture, type.AssemblyQualifiedName, objectType.AssemblyQualifiedName));
				}
				objectType = type;
				contract = GetContractSafe(type);
			}
		}

		private JsonArrayContract EnsureArrayContract(JsonReader reader, Type objectType, JsonContract contract)
		{
			int num = 3;
			if (contract == null)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Could not resolve type '{0}' to a JsonContract.", CultureInfo.InvariantCulture, objectType));
			}
			JsonArrayContract jsonArrayContract = contract as JsonArrayContract;
			if (jsonArrayContract == null)
			{
				string format = "Cannot deserialize the current JSON array (e.g. [1,2,3]) into type '{0}' because the type requires a {1} to deserialize correctly." + Environment.NewLine + "To fix this error either change the JSON to a {1} or change the deserialized type to an array or a type that implements a collection interface (e.g. ICollection, IList) like List<T> that can be deserialized from a JSON array. JsonArrayAttribute can also be added to the type to force it to deserialize from a JSON array." + Environment.NewLine;
				format = StringUtils.FormatWith(format, CultureInfo.InvariantCulture, objectType, GetExpectedDescription(contract));
				throw JsonSerializationException.Create(reader, format);
			}
			return jsonArrayContract;
		}

		private void CheckedRead(JsonReader reader)
		{
			int num = 18;
			if (!reader.Read())
			{
				throw JsonSerializationException.Create(reader, "Unexpected end when deserializing object.");
			}
		}

		private object CreateList(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, object existingValue, string string_0)
		{
			int num = 18;
			if (HasNoDefinedType(contract))
			{
				return CreateJToken(reader, contract);
			}
			JsonArrayContract jsonArrayContract = EnsureArrayContract(reader, objectType, contract);
			object result;
			if (existingValue == null)
			{
				bool createdFromNonDefaultCreator;
				IList list = CreateNewList(reader, jsonArrayContract, out createdFromNonDefaultCreator);
				if (createdFromNonDefaultCreator)
				{
					if (string_0 != null)
					{
						throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot preserve reference to array or readonly list, or list created from a non-default constructor: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
					}
					if (contract.OnSerializingCallbacks.Count > 0)
					{
						throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot call OnSerializing on an array or readonly list, or list created from a non-default constructor: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
					}
					if (contract.OnErrorCallbacks.Count > 0)
					{
						throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot call OnError on an array or readonly list, or list created from a non-default constructor: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
					}
					if (!jsonArrayContract.HasParametrizedCreator && !jsonArrayContract.IsArray)
					{
						throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot deserialize readonly or fixed size list: {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
					}
				}
				if (!jsonArrayContract.IsMultidimensionalArray)
				{
					PopulateList(list, reader, jsonArrayContract, member, string_0);
				}
				else
				{
					PopulateMultidimensionalArray(list, reader, jsonArrayContract, member, string_0);
				}
				if (createdFromNonDefaultCreator)
				{
					if (jsonArrayContract.IsMultidimensionalArray)
					{
						list = CollectionUtils.ToMultidimensionalArray(list, jsonArrayContract.CollectionItemType, contract.CreatedType.GetArrayRank());
					}
					else
					{
						if (!jsonArrayContract.IsArray)
						{
							return jsonArrayContract.ParametrizedCreator(list);
						}
						Array array = Array.CreateInstance(jsonArrayContract.CollectionItemType, list.Count);
						list.CopyTo(array, 0);
						list = array;
					}
				}
				else if (list is IWrappedCollection)
				{
					return ((IWrappedCollection)list).UnderlyingCollection;
				}
				result = list;
			}
			else
			{
				if (!jsonArrayContract.CanDeserialize)
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot populate list type {0}.", CultureInfo.InvariantCulture, contract.CreatedType));
				}
				result = PopulateList(jsonArrayContract.ShouldCreateWrapper ? jsonArrayContract.CreateWrapper(existingValue) : ((IList)existingValue), reader, jsonArrayContract, member, string_0);
			}
			return result;
		}

		private bool HasNoDefinedType(JsonContract contract)
		{
			return contract == null || contract.UnderlyingType == typeof(object) || contract.ContractType == JsonContractType.Linq;
		}

		private object EnsureType(JsonReader reader, object value, CultureInfo culture, JsonContract contract, Type targetType)
		{
			int num = 1;
			if (targetType == null)
			{
				return value;
			}
			Type objectType = ReflectionUtils.GetObjectType(value);
			if (objectType != targetType)
			{
				if (value == null && contract.IsNullable)
				{
					return null;
				}
				try
				{
					if (contract.IsConvertable)
					{
						JsonPrimitiveContract jsonPrimitiveContract = (JsonPrimitiveContract)contract;
						if (contract.IsEnum)
						{
							if (value is string)
							{
								return Enum.Parse(contract.NonNullableUnderlyingType, value.ToString(), ignoreCase: true);
							}
							if (ConvertUtils.IsInteger(jsonPrimitiveContract.TypeCode))
							{
								return Enum.ToObject(contract.NonNullableUnderlyingType, value);
							}
						}
						return Convert.ChangeType(value, contract.NonNullableUnderlyingType, culture);
					}
					return ConvertUtils.ConvertOrCast(value, culture, contract.NonNullableUnderlyingType);
				}
				catch (Exception exception_)
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Error converting value {0} to type '{1}'.", CultureInfo.InvariantCulture, MiscellaneousUtils.FormatValueForPrint(value), targetType), exception_);
				}
			}
			return value;
		}

		private bool SetPropertyValue(JsonProperty property, JsonConverter propertyConverter, JsonContainerContract containerContract, JsonProperty containerProperty, JsonReader reader, object target)
		{
			int num = 14;
			if (CalculatePropertyDetails(property, ref propertyConverter, containerContract, containerProperty, reader, target, out bool useExistingValue, out object currentValue, out JsonContract propertyContract, out bool gottenCurrentValue))
			{
				return false;
			}
			object obj;
			if (propertyConverter != null && propertyConverter.CanRead)
			{
				if (!gottenCurrentValue && target != null && property.Readable)
				{
					currentValue = property.ValueProvider.GetValue(target);
				}
				obj = DeserializeConvertable(propertyConverter, reader, property.PropertyType, currentValue);
			}
			else
			{
				obj = CreateValueInternal(reader, property.PropertyType, propertyContract, property, containerContract, containerProperty, useExistingValue ? currentValue : null);
			}
			if ((!useExistingValue || obj != currentValue) && ShouldSetPropertyValue(property, obj))
			{
				property.ValueProvider.SetValue(target, obj);
				if (property.SetIsSpecified != null)
				{
					if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
					{
						TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("IsSpecified for property '{0}' on {1} set to true.", CultureInfo.InvariantCulture, property.PropertyName, property.DeclaringType)), null);
					}
					property.SetIsSpecified(target, true);
				}
				return true;
			}
			return useExistingValue;
		}

		private bool CalculatePropertyDetails(JsonProperty property, ref JsonConverter propertyConverter, JsonContainerContract containerContract, JsonProperty containerProperty, JsonReader reader, object target, out bool useExistingValue, out object currentValue, out JsonContract propertyContract, out bool gottenCurrentValue)
		{
			currentValue = null;
			useExistingValue = false;
			propertyContract = null;
			gottenCurrentValue = false;
			if (property.Ignored)
			{
				return true;
			}
			JsonToken tokenType = reader.TokenType;
			if (property.PropertyContract == null)
			{
				property.PropertyContract = GetContractSafe(property.PropertyType);
			}
			ObjectCreationHandling valueOrDefault = property.ObjectCreationHandling.GetValueOrDefault(Serializer._objectCreationHandling);
			if (valueOrDefault != ObjectCreationHandling.Replace && (tokenType == JsonToken.StartArray || tokenType == JsonToken.StartObject) && property.Readable)
			{
				currentValue = property.ValueProvider.GetValue(target);
				gottenCurrentValue = true;
				if (currentValue != null)
				{
					propertyContract = GetContractSafe(currentValue.GetType());
					useExistingValue = (!propertyContract.IsReadOnlyOrFixedSize && !TypeExtensions.IsValueType(propertyContract.UnderlyingType));
				}
			}
			if (!property.Writable && !useExistingValue)
			{
				return true;
			}
			if (property.NullValueHandling.GetValueOrDefault(Serializer._nullValueHandling) == NullValueHandling.Ignore && tokenType == JsonToken.Null)
			{
				return true;
			}
			if (HasFlag(property.DefaultValueHandling.GetValueOrDefault(Serializer._defaultValueHandling), DefaultValueHandling.Ignore) && !HasFlag(property.DefaultValueHandling.GetValueOrDefault(Serializer._defaultValueHandling), DefaultValueHandling.Populate) && JsonTokenUtils.IsPrimitiveToken(tokenType) && MiscellaneousUtils.ValueEquals(reader.Value, property.GetResolvedDefaultValue()))
			{
				return true;
			}
			if (currentValue == null)
			{
				propertyContract = property.PropertyContract;
			}
			else
			{
				propertyContract = GetContractSafe(currentValue.GetType());
				if (propertyContract != property.PropertyContract)
				{
					propertyConverter = GetConverter(propertyContract, property.MemberConverter, containerContract, containerProperty);
				}
			}
			return false;
		}

		private void AddReference(JsonReader reader, string string_0, object value)
		{
			int num = 18;
			try
			{
				if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
				{
					TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Read object reference Id '{0}' for {1}.", CultureInfo.InvariantCulture, string_0, value.GetType())), null);
				}
				Serializer.GetReferenceResolver().AddReference(this, string_0, value);
			}
			catch (Exception exception_)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Error reading object reference '{0}'.", CultureInfo.InvariantCulture, string_0), exception_);
			}
		}

		private bool HasFlag(DefaultValueHandling value, DefaultValueHandling flag)
		{
			return (value & flag) == flag;
		}

		private bool ShouldSetPropertyValue(JsonProperty property, object value)
		{
			if (property.NullValueHandling.GetValueOrDefault(Serializer._nullValueHandling) == NullValueHandling.Ignore && value == null)
			{
				return false;
			}
			if (HasFlag(property.DefaultValueHandling.GetValueOrDefault(Serializer._defaultValueHandling), DefaultValueHandling.Ignore) && !HasFlag(property.DefaultValueHandling.GetValueOrDefault(Serializer._defaultValueHandling), DefaultValueHandling.Populate) && MiscellaneousUtils.ValueEquals(value, property.GetResolvedDefaultValue()))
			{
				return false;
			}
			if (!property.Writable)
			{
				return false;
			}
			return true;
		}

		private IList CreateNewList(JsonReader reader, JsonArrayContract contract, out bool createdFromNonDefaultCreator)
		{
			int num = 5;
			if (!contract.CanDeserialize)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Cannot create and populate list type {0}.", CultureInfo.InvariantCulture, contract.CreatedType));
			}
			if (contract.IsReadOnlyOrFixedSize)
			{
				createdFromNonDefaultCreator = true;
				IList list = contract.CreateTemporaryCollection();
				if (contract.ShouldCreateWrapper)
				{
					list = contract.CreateWrapper(list);
				}
				return list;
			}
			if (contract.DefaultCreator != null && (!contract.DefaultCreatorNonPublic || Serializer._constructorHandling == ConstructorHandling.AllowNonPublicDefaultConstructor))
			{
				object obj = contract.DefaultCreator();
				if (contract.ShouldCreateWrapper)
				{
					obj = contract.CreateWrapper(obj);
				}
				createdFromNonDefaultCreator = false;
				return (IList)obj;
			}
			if (contract.HasParametrizedCreator)
			{
				createdFromNonDefaultCreator = true;
				return contract.CreateTemporaryCollection();
			}
			if (!contract.IsInstantiable)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Could not create an instance of type {0}. Type is an interface or abstract class and cannot be instantiated.", CultureInfo.InvariantCulture, contract.UnderlyingType));
			}
			throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unable to find a constructor to use for type {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
		}

		private IDictionary CreateNewDictionary(JsonReader reader, JsonDictionaryContract contract, out bool createdFromNonDefaultCreator)
		{
			int num = 8;
			if (contract.IsReadOnlyOrFixedSize)
			{
				createdFromNonDefaultCreator = true;
				return contract.CreateTemporaryDictionary();
			}
			if (contract.DefaultCreator != null && (!contract.DefaultCreatorNonPublic || Serializer._constructorHandling == ConstructorHandling.AllowNonPublicDefaultConstructor))
			{
				object obj = contract.DefaultCreator();
				if (contract.ShouldCreateWrapper)
				{
					obj = contract.CreateWrapper(obj);
				}
				createdFromNonDefaultCreator = false;
				return (IDictionary)obj;
			}
			if (contract.HasParametrizedCreator)
			{
				createdFromNonDefaultCreator = true;
				return contract.CreateTemporaryDictionary();
			}
			if (!contract.IsInstantiable)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Could not create an instance of type {0}. Type is an interface or abstract class and cannot be instantiated.", CultureInfo.InvariantCulture, contract.UnderlyingType));
			}
			throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unable to find a default constructor to use for type {0}.", CultureInfo.InvariantCulture, contract.UnderlyingType));
		}

		private void OnDeserializing(JsonReader reader, JsonContract contract, object value)
		{
			int num = 15;
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Started deserializing {0}", CultureInfo.InvariantCulture, contract.UnderlyingType)), null);
			}
			contract.InvokeOnDeserializing(value, Serializer._context);
		}

		private void OnDeserialized(JsonReader reader, JsonContract contract, object value)
		{
			int num = 2;
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Finished deserializing {0}", CultureInfo.InvariantCulture, contract.UnderlyingType)), null);
			}
			contract.InvokeOnDeserialized(value, Serializer._context);
		}

		private object PopulateDictionary(IDictionary dictionary, JsonReader reader, JsonDictionaryContract contract, JsonProperty containerProperty, string string_0)
		{
			int num = 9;
			IWrappedDictionary wrappedDictionary = dictionary as IWrappedDictionary;
			object obj = (wrappedDictionary != null) ? wrappedDictionary.UnderlyingDictionary : dictionary;
			if (string_0 != null)
			{
				AddReference(reader, string_0, obj);
			}
			OnDeserializing(reader, contract, obj);
			int depth = reader.Depth;
			if (contract.KeyContract == null)
			{
				contract.KeyContract = GetContractSafe(contract.DictionaryKeyType);
			}
			if (contract.ItemContract == null)
			{
				contract.ItemContract = GetContractSafe(contract.DictionaryValueType);
			}
			JsonConverter jsonConverter = contract.ItemConverter ?? GetConverter(contract.ItemContract, null, contract, containerProperty);
			PrimitiveTypeCode primitiveTypeCode = (contract.KeyContract is JsonPrimitiveContract) ? ((JsonPrimitiveContract)contract.KeyContract).TypeCode : PrimitiveTypeCode.Empty;
			bool flag = false;
			bool num2;
			do
			{
				switch (reader.TokenType)
				{
				case JsonToken.PropertyName:
				{
					object obj2 = reader.Value;
					if (!CheckPropertyName(reader, obj2.ToString()))
					{
						try
						{
							try
							{
								DateParseHandling dateParseHandling;
								switch (primitiveTypeCode)
								{
								default:
									dateParseHandling = DateParseHandling.None;
									break;
								case PrimitiveTypeCode.DateTime:
								case PrimitiveTypeCode.DateTimeNullable:
									dateParseHandling = DateParseHandling.DateTime;
									break;
								}
								obj2 = ((dateParseHandling == DateParseHandling.None || !DateTimeUtils.TryParseDateTime(obj2.ToString(), dateParseHandling, reader.DateTimeZoneHandling, reader.DateFormatString, reader.Culture, out object object_)) ? EnsureType(reader, obj2, CultureInfo.InvariantCulture, contract.KeyContract, contract.DictionaryKeyType) : object_);
							}
							catch (Exception exception_)
							{
								throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Could not convert string '{0}' to dictionary key type '{1}'. Create a TypeConverter to convert from the string to the key type object.", CultureInfo.InvariantCulture, reader.Value, contract.DictionaryKeyType), exception_);
							}
							if (!ReadForType(reader, contract.ItemContract, jsonConverter != null))
							{
								throw JsonSerializationException.Create(reader, "Unexpected end when deserializing object.");
							}
							object obj4 = dictionary[obj2] = ((jsonConverter == null || !jsonConverter.CanRead) ? CreateValueInternal(reader, contract.DictionaryValueType, contract.ItemContract, null, contract, containerProperty, null) : DeserializeConvertable(jsonConverter, reader, contract.DictionaryValueType, null));
						}
						catch (Exception exception_)
						{
							if (!IsErrorHandled(obj, contract, obj2, reader as IJsonLineInfo, reader.Path, exception_))
							{
								throw;
							}
							HandleError(reader, readPastError: true, depth);
						}
					}
					goto case JsonToken.Comment;
				}
				case JsonToken.EndObject:
					flag = true;
					goto case JsonToken.Comment;
				case JsonToken.Comment:
					num2 = (!flag && reader.Read());
					break;
				default:
					throw JsonSerializationException.Create(reader, "Unexpected token when deserializing object: " + reader.TokenType);
				}
			}
			while (num2);
			if (!flag)
			{
				ThrowUnexpectedEndException(reader, contract, obj, "Unexpected end when deserializing object.");
			}
			OnDeserialized(reader, contract, obj);
			return obj;
		}

		private object PopulateMultidimensionalArray(IList list, JsonReader reader, JsonArrayContract contract, JsonProperty containerProperty, string string_0)
		{
			int num = 3;
			int arrayRank = contract.UnderlyingType.GetArrayRank();
			if (string_0 != null)
			{
				AddReference(reader, string_0, list);
			}
			OnDeserializing(reader, contract, list);
			JsonContract contractSafe = GetContractSafe(contract.CollectionItemType);
			JsonConverter converter = GetConverter(contractSafe, null, contract, containerProperty);
			int? num2 = null;
			Stack<IList> stack = new Stack<IList>();
			stack.Push(list);
			IList list2 = list;
			bool flag = false;
			do
			{
				int depth = reader.Depth;
				if (stack.Count != arrayRank)
				{
					if (!reader.Read())
					{
						break;
					}
					switch (reader.TokenType)
					{
					case JsonToken.EndArray:
						stack.Pop();
						if (stack.Count > 0)
						{
							list2 = stack.Peek();
						}
						else
						{
							flag = true;
						}
						break;
					case JsonToken.StartArray:
					{
						IList list3 = new List<object>();
						list2.Add(list3);
						stack.Push(list3);
						list2 = list3;
						break;
					}
					case JsonToken.Comment:
						break;
					default:
						throw JsonSerializationException.Create(reader, "Unexpected token when deserializing multidimensional array: " + reader.TokenType);
					}
					continue;
				}
				try
				{
					if (ReadForType(reader, contractSafe, converter != null))
					{
						switch (reader.TokenType)
						{
						default:
						{
							object value = (converter == null || !converter.CanRead) ? CreateValueInternal(reader, contract.CollectionItemType, contractSafe, null, contract, containerProperty, null) : DeserializeConvertable(converter, reader, contract.CollectionItemType, null);
							list2.Add(value);
							break;
						}
						case JsonToken.EndArray:
							stack.Pop();
							list2 = stack.Peek();
							num2 = null;
							break;
						case JsonToken.Comment:
							break;
						}
						continue;
					}
				}
				catch (Exception exception_)
				{
					JsonPosition position = reader.GetPosition(depth);
					if (!IsErrorHandled(list, contract, position.Position, reader as IJsonLineInfo, reader.Path, exception_))
					{
						throw;
					}
					HandleError(reader, readPastError: true, depth);
					if (num2.HasValue && num2 == position.Position)
					{
						throw JsonSerializationException.Create(reader, "Infinite loop detected from error handling.", exception_);
					}
					num2 = position.Position;
					continue;
				}
				break;
			}
			while (!flag);
			if (!flag)
			{
				ThrowUnexpectedEndException(reader, contract, list, "Unexpected end when deserializing array.");
			}
			OnDeserialized(reader, contract, list);
			return list;
		}

		private void ThrowUnexpectedEndException(JsonReader reader, JsonContract contract, object currentObject, string message)
		{
			try
			{
				throw JsonSerializationException.Create(reader, message);
			}
			catch (Exception exception_)
			{
				if (!IsErrorHandled(currentObject, contract, null, reader as IJsonLineInfo, reader.Path, exception_))
				{
					throw;
				}
				HandleError(reader, readPastError: false, 0);
			}
		}

		private object PopulateList(IList list, JsonReader reader, JsonArrayContract contract, JsonProperty containerProperty, string string_0)
		{
			int num = 11;
			IWrappedCollection wrappedCollection = list as IWrappedCollection;
			object obj = (wrappedCollection != null) ? wrappedCollection.UnderlyingCollection : list;
			if (string_0 != null)
			{
				AddReference(reader, string_0, obj);
			}
			if (list.IsFixedSize)
			{
				reader.Skip();
				return obj;
			}
			OnDeserializing(reader, contract, obj);
			int depth = reader.Depth;
			if (contract.ItemContract == null)
			{
				contract.ItemContract = GetContractSafe(contract.CollectionItemType);
			}
			JsonConverter converter = GetConverter(contract.ItemContract, null, contract, containerProperty);
			int? num2 = null;
			bool flag = false;
			do
			{
				try
				{
					if (ReadForType(reader, contract.ItemContract, converter != null))
					{
						switch (reader.TokenType)
						{
						default:
						{
							object value = (converter == null || !converter.CanRead) ? CreateValueInternal(reader, contract.CollectionItemType, contract.ItemContract, null, contract, containerProperty, null) : DeserializeConvertable(converter, reader, contract.CollectionItemType, null);
							list.Add(value);
							break;
						}
						case JsonToken.EndArray:
							flag = true;
							break;
						case JsonToken.Comment:
							break;
						}
						continue;
					}
				}
				catch (Exception exception_)
				{
					JsonPosition position = reader.GetPosition(depth);
					if (!IsErrorHandled(obj, contract, position.Position, reader as IJsonLineInfo, reader.Path, exception_))
					{
						throw;
					}
					HandleError(reader, readPastError: true, depth);
					if (num2.HasValue && num2 == position.Position)
					{
						throw JsonSerializationException.Create(reader, "Infinite loop detected from error handling.", exception_);
					}
					num2 = position.Position;
					continue;
				}
				break;
			}
			while (!flag);
			if (!flag)
			{
				ThrowUnexpectedEndException(reader, contract, obj, "Unexpected end when deserializing array.");
			}
			OnDeserialized(reader, contract, obj);
			return obj;
		}

		private object CreateISerializable(JsonReader reader, JsonISerializableContract contract, JsonProperty member, string string_0)
		{
			int num = 3;
			Type underlyingType = contract.UnderlyingType;
			if (!JsonTypeReflector.FullyTrusted)
			{
				string format = "Type '{0}' implements ISerializable but cannot be deserialized using the ISerializable interface because the current application is not fully trusted and ISerializable can expose secure data." + Environment.NewLine + "To fix this error either change the environment to be fully trusted, change the application to not deserialize the type, add JsonObjectAttribute to the type or change the JsonSerializer setting ContractResolver to use a new DefaultContractResolver with IgnoreSerializableInterface set to true." + Environment.NewLine;
				format = StringUtils.FormatWith(format, CultureInfo.InvariantCulture, underlyingType);
				throw JsonSerializationException.Create(reader, format);
			}
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Deserializing {0} using ISerializable constructor.", CultureInfo.InvariantCulture, contract.UnderlyingType)), null);
			}
			SerializationInfo serializationInfo = new SerializationInfo(contract.UnderlyingType, new JsonFormatterConverter(this, contract, member));
			bool flag = false;
			bool num2;
			do
			{
				switch (reader.TokenType)
				{
				case JsonToken.Comment:
					num2 = (!flag && reader.Read());
					break;
				case JsonToken.PropertyName:
				{
					string text = reader.Value.ToString();
					if (reader.Read())
					{
						serializationInfo.AddValue(text, JToken.ReadFrom(reader));
						goto case JsonToken.Comment;
					}
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected end when setting {0}'s value.", CultureInfo.InvariantCulture, text));
				}
				case JsonToken.EndObject:
					flag = true;
					goto case JsonToken.Comment;
				default:
					throw JsonSerializationException.Create(reader, "Unexpected token when deserializing object: " + reader.TokenType);
				}
			}
			while (num2);
			if (!flag)
			{
				ThrowUnexpectedEndException(reader, contract, serializationInfo, "Unexpected end when deserializing object.");
			}
			if (contract.ISerializableCreator == null)
			{
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("ISerializable type '{0}' does not have a valid constructor. To correctly implement ISerializable a constructor that takes SerializationInfo and StreamingContext parameters should be present.", CultureInfo.InvariantCulture, underlyingType));
			}
			object obj = contract.ISerializableCreator(serializationInfo, Serializer._context);
			if (string_0 != null)
			{
				AddReference(reader, string_0, obj);
			}
			OnDeserializing(reader, contract, obj);
			OnDeserialized(reader, contract, obj);
			return obj;
		}

		internal object CreateISerializableItem(JToken token, Type type, JsonISerializableContract contract, JsonProperty member)
		{
			JsonContract contractSafe = GetContractSafe(type);
			JsonConverter converter = GetConverter(contractSafe, null, contract, member);
			JsonReader reader = token.CreateReader();
			CheckedRead(reader);
			if (converter != null && converter.CanRead)
			{
				return DeserializeConvertable(converter, reader, type, null);
			}
			return CreateValueInternal(reader, type, contractSafe, null, contract, member, null);
		}

		private object CreateObjectUsingCreatorWithParameters(JsonReader reader, JsonObjectContract contract, JsonProperty containerProperty, ObjectConstructor<object> creator, string string_0)
		{
			int num = 1;
			ValidationUtils.ArgumentNotNull(creator, "creator");
			Dictionary<JsonProperty, PropertyPresence> dictionary = (contract.HasRequiredOrDefaultValueProperties || HasFlag(Serializer._defaultValueHandling, DefaultValueHandling.Populate)) ? Enumerable.ToDictionary(contract.Properties, (JsonProperty jsonProperty_0) => jsonProperty_0, (JsonProperty jsonProperty_0) => PropertyPresence.None) : null;
			Type underlyingType = contract.UnderlyingType;
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				string arg = string.Join(", ", Enumerable.ToArray(Enumerable.Select(contract.CreatorParameters, (JsonProperty jsonProperty_0) => jsonProperty_0.PropertyName)));
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Deserializing {0} using creator with parameters: {1}.", CultureInfo.InvariantCulture, contract.UnderlyingType, arg)), null);
			}
			IDictionary<string, object> extensionData;
			IDictionary<JsonProperty, object> dictionary2 = ResolvePropertyAndCreatorValues(contract, containerProperty, reader, underlyingType, out extensionData);
			object[] array = new object[contract.CreatorParameters.Count];
			IDictionary<JsonProperty, object> dictionary3 = new Dictionary<JsonProperty, object>();
			foreach (KeyValuePair<JsonProperty, object> item in dictionary2)
			{
				JsonProperty key = item.Key;
				JsonProperty jsonProperty = (!contract.CreatorParameters.Contains(key)) ? StringUtils.ForgivingCaseSensitiveFind(contract.CreatorParameters, (JsonProperty jsonProperty_0) => jsonProperty_0.PropertyName, key.UnderlyingName) : key;
				if (jsonProperty != null)
				{
					int num2 = contract.CreatorParameters.IndexOf(jsonProperty);
					array[num2] = item.Value;
				}
				else
				{
					dictionary3.Add(item);
				}
				if (dictionary != null)
				{
					JsonProperty jsonProperty2 = StringUtils.ForgivingCaseSensitiveFind(dictionary.Keys, (JsonProperty jsonProperty_0) => jsonProperty_0.PropertyName, key.PropertyName);
					if (jsonProperty2 != null)
					{
						object value = item.Value;
						PropertyPresence propertyPresence2 = dictionary[jsonProperty2] = ((value == null) ? PropertyPresence.Null : ((!(value is string)) ? PropertyPresence.Value : (CoerceEmptyStringToNull(key.PropertyType, key.PropertyContract, (string)value) ? PropertyPresence.Null : PropertyPresence.Value)));
					}
				}
			}
			if (dictionary != null)
			{
				foreach (KeyValuePair<JsonProperty, PropertyPresence> item2 in dictionary)
				{
					JsonProperty property = item2.Key;
					PropertyPresence value2 = item2.Value;
					if (!property.Ignored && (value2 == PropertyPresence.None || value2 == PropertyPresence.Null))
					{
						if (property.PropertyContract == null)
						{
							property.PropertyContract = GetContractSafe(property.PropertyType);
						}
						if (HasFlag(property.DefaultValueHandling.GetValueOrDefault(Serializer._defaultValueHandling), DefaultValueHandling.Populate))
						{
							int num2 = CollectionUtils.IndexOf(contract.CreatorParameters, (JsonProperty jsonProperty_0) => jsonProperty_0.PropertyName == property.PropertyName);
							if (num2 != -1)
							{
								array[num2] = EnsureType(reader, property.GetResolvedDefaultValue(), CultureInfo.InvariantCulture, property.PropertyContract, property.PropertyType);
							}
						}
					}
				}
			}
			object obj = creator(array);
			if (string_0 != null)
			{
				AddReference(reader, string_0, obj);
			}
			OnDeserializing(reader, contract, obj);
			foreach (KeyValuePair<JsonProperty, object> item3 in dictionary3)
			{
				JsonProperty key = item3.Key;
				object value3 = item3.Value;
				if (ShouldSetPropertyValue(key, value3))
				{
					key.ValueProvider.SetValue(obj, value3);
				}
				else if (!key.Writable && value3 != null)
				{
					JsonContract jsonContract = Serializer._contractResolver.ResolveContract(key.PropertyType);
					if (jsonContract.ContractType == JsonContractType.Array)
					{
						JsonArrayContract jsonArrayContract = (JsonArrayContract)jsonContract;
						object value4 = key.ValueProvider.GetValue(obj);
						if (value4 != null)
						{
							IWrappedCollection wrappedCollection = jsonArrayContract.CreateWrapper(value4);
							IWrappedCollection wrappedCollection2 = jsonArrayContract.CreateWrapper(value3);
							foreach (object item4 in wrappedCollection2)
							{
								wrappedCollection.Add(item4);
							}
						}
					}
					else if (jsonContract.ContractType == JsonContractType.Dictionary)
					{
						JsonDictionaryContract jsonDictionaryContract = (JsonDictionaryContract)jsonContract;
						object value5 = key.ValueProvider.GetValue(obj);
						if (value5 != null)
						{
							IDictionary dictionary4 = jsonDictionaryContract.ShouldCreateWrapper ? jsonDictionaryContract.CreateWrapper(value5) : ((IDictionary)value5);
							IDictionary dictionary5 = jsonDictionaryContract.ShouldCreateWrapper ? jsonDictionaryContract.CreateWrapper(value3) : ((IDictionary)value3);
							foreach (DictionaryEntry item5 in dictionary5)
							{
								dictionary4.Add(item5.Key, item5.Value);
							}
						}
					}
				}
			}
			if (extensionData != null)
			{
				foreach (KeyValuePair<string, object> item6 in extensionData)
				{
					contract.ExtensionDataSetter(obj, item6.Key, item6.Value);
				}
			}
			EndObject(obj, reader, contract, reader.Depth, dictionary);
			OnDeserialized(reader, contract, obj);
			return obj;
		}

		private object DeserializeConvertable(JsonConverter converter, JsonReader reader, Type objectType, object existingValue)
		{
			int num = 13;
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Started deserializing {0} with converter {1}.", CultureInfo.InvariantCulture, objectType, converter.GetType())), null);
			}
			object result = converter.ReadJson(reader, objectType, existingValue, GetInternalSerializer());
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Finished deserializing {0} with converter {1}.", CultureInfo.InvariantCulture, objectType, converter.GetType())), null);
			}
			return result;
		}

		private IDictionary<JsonProperty, object> ResolvePropertyAndCreatorValues(JsonObjectContract contract, JsonProperty containerProperty, JsonReader reader, Type objectType, out IDictionary<string, object> extensionData)
		{
			int num = 3;
			extensionData = ((contract.ExtensionDataSetter != null) ? new Dictionary<string, object>() : null);
			IDictionary<JsonProperty, object> dictionary = new Dictionary<JsonProperty, object>();
			bool flag = false;
			bool num2;
			do
			{
				switch (reader.TokenType)
				{
				case JsonToken.Comment:
					num2 = (!flag && reader.Read());
					break;
				case JsonToken.PropertyName:
				{
					string text = reader.Value.ToString();
					JsonProperty jsonProperty = contract.CreatorParameters.GetClosestMatchProperty(text) ?? contract.Properties.GetClosestMatchProperty(text);
					if (jsonProperty != null)
					{
						if (jsonProperty.PropertyContract == null)
						{
							jsonProperty.PropertyContract = GetContractSafe(jsonProperty.PropertyType);
						}
						JsonConverter converter = GetConverter(jsonProperty.PropertyContract, jsonProperty.MemberConverter, contract, containerProperty);
						if (!ReadForType(reader, jsonProperty.PropertyContract, converter != null))
						{
							throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected end when setting {0}'s value.", CultureInfo.InvariantCulture, text));
						}
						if (!jsonProperty.Ignored)
						{
							object obj2 = dictionary[jsonProperty] = ((converter == null || !converter.CanRead) ? CreateValueInternal(reader, jsonProperty.PropertyType, jsonProperty.PropertyContract, jsonProperty, contract, containerProperty, null) : DeserializeConvertable(converter, reader, jsonProperty.PropertyType, null));
							goto case JsonToken.Comment;
						}
					}
					else
					{
						if (!reader.Read())
						{
							throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected end when setting {0}'s value.", CultureInfo.InvariantCulture, text));
						}
						if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
						{
							TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Could not find member '{0}' on {1}.", CultureInfo.InvariantCulture, text, contract.UnderlyingType)), null);
						}
						if (Serializer._missingMemberHandling == MissingMemberHandling.Error)
						{
							throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Could not find member '{0}' on object of type '{1}'", CultureInfo.InvariantCulture, text, objectType.Name));
						}
					}
					if (extensionData != null)
					{
						object value = CreateValueInternal(reader, null, null, null, contract, containerProperty, null);
						extensionData[text] = value;
					}
					else
					{
						reader.Skip();
					}
					goto case JsonToken.Comment;
				}
				case JsonToken.EndObject:
					flag = true;
					goto case JsonToken.Comment;
				default:
					throw JsonSerializationException.Create(reader, "Unexpected token when deserializing object: " + reader.TokenType);
				}
			}
			while (num2);
			return dictionary;
		}

		private bool ReadForType(JsonReader reader, JsonContract contract, bool hasConverter)
		{
			if (hasConverter)
			{
				return reader.Read();
			}
			switch (contract?.InternalReadType ?? ReadType.Read)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case ReadType.Read:
				do
				{
					if (!reader.Read())
					{
						return false;
					}
				}
				while (reader.TokenType == JsonToken.Comment);
				return true;
			case ReadType.ReadAsInt32:
				reader.ReadAsInt32();
				break;
			case ReadType.ReadAsBytes:
				reader.ReadAsBytes();
				break;
			case ReadType.ReadAsString:
				reader.ReadAsString();
				break;
			case ReadType.ReadAsDecimal:
				reader.ReadAsDecimal();
				break;
			case ReadType.ReadAsDateTime:
				reader.ReadAsDateTime();
				break;
			}
			return reader.TokenType != JsonToken.None;
		}

		public object CreateNewObject(JsonReader reader, JsonObjectContract objectContract, JsonProperty containerMember, JsonProperty containerProperty, string string_0, out bool createdFromNonDefaultCreator)
		{
			int num = 19;
			object obj = null;
			if (objectContract.OverrideCreator != null)
			{
				if (objectContract.CreatorParameters.Count > 0)
				{
					createdFromNonDefaultCreator = true;
					return CreateObjectUsingCreatorWithParameters(reader, objectContract, containerMember, objectContract.OverrideCreator, string_0);
				}
				obj = objectContract.OverrideCreator();
			}
			else if (objectContract.DefaultCreator != null && (!objectContract.DefaultCreatorNonPublic || Serializer._constructorHandling == ConstructorHandling.AllowNonPublicDefaultConstructor || objectContract.ParametrizedCreator == null))
			{
				obj = objectContract.DefaultCreator();
			}
			else if (objectContract.ParametrizedCreator != null)
			{
				createdFromNonDefaultCreator = true;
				return CreateObjectUsingCreatorWithParameters(reader, objectContract, containerMember, objectContract.ParametrizedCreator, string_0);
			}
			if (obj == null)
			{
				if (!objectContract.IsInstantiable)
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Could not create an instance of type {0}. Type is an interface or abstract class and cannot be instantiated.", CultureInfo.InvariantCulture, objectContract.UnderlyingType));
				}
				throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unable to find a constructor to use for type {0}. A class should either have a default constructor, one constructor with arguments or a constructor marked with the JsonConstructor attribute.", CultureInfo.InvariantCulture, objectContract.UnderlyingType));
			}
			createdFromNonDefaultCreator = false;
			return obj;
		}

		private object PopulateObject(object newObject, JsonReader reader, JsonObjectContract contract, JsonProperty member, string string_0)
		{
			int num = 5;
			OnDeserializing(reader, contract, newObject);
			Dictionary<JsonProperty, PropertyPresence> dictionary = (contract.HasRequiredOrDefaultValueProperties || HasFlag(Serializer._defaultValueHandling, DefaultValueHandling.Populate)) ? Enumerable.ToDictionary(contract.Properties, (JsonProperty jsonProperty_0) => jsonProperty_0, (JsonProperty jsonProperty_0) => PropertyPresence.None) : null;
			if (string_0 != null)
			{
				AddReference(reader, string_0, newObject);
			}
			int depth = reader.Depth;
			bool flag = false;
			bool num2;
			do
			{
				switch (reader.TokenType)
				{
				case JsonToken.PropertyName:
				{
					string text = reader.Value.ToString();
					if (!CheckPropertyName(reader, text))
					{
						try
						{
							JsonProperty closestMatchProperty = contract.Properties.GetClosestMatchProperty(text);
							if (closestMatchProperty == null)
							{
								if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
								{
									TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(reader as IJsonLineInfo, reader.Path, StringUtils.FormatWith("Could not find member '{0}' on {1}", CultureInfo.InvariantCulture, text, contract.UnderlyingType)), null);
								}
								if (Serializer._missingMemberHandling == MissingMemberHandling.Error)
								{
									throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Could not find member '{0}' on object of type '{1}'", CultureInfo.InvariantCulture, text, contract.UnderlyingType.Name));
								}
								if (reader.Read())
								{
									SetExtensionData(contract, member, reader, text, newObject);
								}
							}
							else
							{
								if (closestMatchProperty.PropertyContract == null)
								{
									closestMatchProperty.PropertyContract = GetContractSafe(closestMatchProperty.PropertyType);
								}
								JsonConverter jsonConverter = null;
								if (!closestMatchProperty.Ignored)
								{
									jsonConverter = GetConverter(closestMatchProperty.PropertyContract, closestMatchProperty.MemberConverter, contract, member);
								}
								if (!ReadForType(reader, closestMatchProperty.PropertyContract, jsonConverter != null))
								{
									throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Unexpected end when setting {0}'s value.", CultureInfo.InvariantCulture, text));
								}
								SetPropertyPresence(reader, closestMatchProperty, dictionary);
								if (!SetPropertyValue(closestMatchProperty, jsonConverter, contract, member, reader, newObject))
								{
									SetExtensionData(contract, member, reader, text, newObject);
								}
							}
						}
						catch (Exception exception_)
						{
							if (!IsErrorHandled(newObject, contract, text, reader as IJsonLineInfo, reader.Path, exception_))
							{
								throw;
							}
							HandleError(reader, readPastError: true, depth);
						}
					}
					goto case JsonToken.Comment;
				}
				case JsonToken.EndObject:
					flag = true;
					goto case JsonToken.Comment;
				case JsonToken.Comment:
					num2 = (!flag && reader.Read());
					break;
				default:
					throw JsonSerializationException.Create(reader, "Unexpected token when deserializing object: " + reader.TokenType);
				}
			}
			while (num2);
			if (!flag)
			{
				ThrowUnexpectedEndException(reader, contract, newObject, "Unexpected end when deserializing object.");
			}
			EndObject(newObject, reader, contract, depth, dictionary);
			OnDeserialized(reader, contract, newObject);
			return newObject;
		}

		private bool CheckPropertyName(JsonReader reader, string memberName)
		{
			int num = 0;
			if (Serializer.MetadataPropertyHandling == MetadataPropertyHandling.ReadAhead)
			{
				switch (memberName)
				{
				case "$id":
				case "$ref":
				case "$type":
				case "$values":
					reader.Skip();
					return true;
				}
			}
			return false;
		}

		private void SetExtensionData(JsonObjectContract contract, JsonProperty member, JsonReader reader, string memberName, object object_0)
		{
			int num = 0;
			if (contract.ExtensionDataSetter != null)
			{
				try
				{
					object value = CreateValueInternal(reader, null, null, null, contract, member, null);
					contract.ExtensionDataSetter(object_0, memberName, value);
				}
				catch (Exception exception_)
				{
					throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Error setting value in extension data for type '{0}'.", CultureInfo.InvariantCulture, contract.UnderlyingType), exception_);
				}
			}
			else
			{
				reader.Skip();
			}
		}

		private void EndObject(object newObject, JsonReader reader, JsonObjectContract contract, int initialDepth, Dictionary<JsonProperty, PropertyPresence> propertiesPresence)
		{
			int num = 1;
			if (propertiesPresence != null)
			{
				foreach (KeyValuePair<JsonProperty, PropertyPresence> item in propertiesPresence)
				{
					JsonProperty key = item.Key;
					PropertyPresence value = item.Value;
					if (value == PropertyPresence.None || value == PropertyPresence.Null)
					{
						try
						{
							Required required = key._required ?? contract.ItemRequired ?? Required.Default;
							switch (value)
							{
							case PropertyPresence.None:
								if (required == Required.AllowNull || required == Required.Always)
								{
									throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Required property '{0}' not found in JSON.", CultureInfo.InvariantCulture, key.PropertyName));
								}
								if (!key.Ignored)
								{
									if (key.PropertyContract == null)
									{
										key.PropertyContract = GetContractSafe(key.PropertyType);
									}
									if (HasFlag(key.DefaultValueHandling.GetValueOrDefault(Serializer._defaultValueHandling), DefaultValueHandling.Populate) && key.Writable)
									{
										key.ValueProvider.SetValue(newObject, EnsureType(reader, key.GetResolvedDefaultValue(), CultureInfo.InvariantCulture, key.PropertyContract, key.PropertyType));
									}
								}
								break;
							case PropertyPresence.Null:
								if (required == Required.Always)
								{
									throw JsonSerializationException.Create(reader, StringUtils.FormatWith("Required property '{0}' expects a value but got null.", CultureInfo.InvariantCulture, key.PropertyName));
								}
								break;
							}
						}
						catch (Exception exception_)
						{
							if (!IsErrorHandled(newObject, contract, key.PropertyName, reader as IJsonLineInfo, reader.Path, exception_))
							{
								throw;
							}
							HandleError(reader, readPastError: true, initialDepth);
						}
					}
				}
			}
		}

		private void SetPropertyPresence(JsonReader reader, JsonProperty property, Dictionary<JsonProperty, PropertyPresence> requiredProperties)
		{
			if (property != null && requiredProperties != null)
			{
				PropertyPresence value;
				switch (reader.TokenType)
				{
				case JsonToken.String:
					value = (CoerceEmptyStringToNull(property.PropertyType, property.PropertyContract, (string)reader.Value) ? PropertyPresence.Null : PropertyPresence.Value);
					break;
				default:
					value = PropertyPresence.Value;
					break;
				case JsonToken.Null:
				case JsonToken.Undefined:
					value = PropertyPresence.Null;
					break;
				}
				requiredProperties[property] = value;
			}
		}

		private void HandleError(JsonReader reader, bool readPastError, int initialDepth)
		{
			ClearErrorContext();
			if (readPastError)
			{
				reader.Skip();
				while (reader.Depth > initialDepth + 1 && reader.Read())
				{
				}
			}
		}
	}
}
