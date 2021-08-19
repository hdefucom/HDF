using Open_Newtonsoft_Json.Linq;
using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal class JsonSerializerInternalWriter : JsonSerializerInternalBase
	{
		private JsonContract _rootContract;

		private int _rootLevel;

		private readonly List<object> _serializeStack = new List<object>();

		public JsonSerializerInternalWriter(JsonSerializer serializer)
			: base(serializer)
		{
		}

		public void Serialize(JsonWriter jsonWriter, object value, Type objectType)
		{
			int num = 9;
			if (jsonWriter == null)
			{
				throw new ArgumentNullException("jsonWriter");
			}
			_rootContract = ((objectType != null) ? Serializer._contractResolver.ResolveContract(objectType) : null);
			_rootLevel = _serializeStack.Count + 1;
			JsonContract contractSafe = GetContractSafe(value);
			try
			{
				if (ShouldWriteReference(value, null, contractSafe, null, null))
				{
					WriteReference(jsonWriter, value);
				}
				else
				{
					SerializeValue(jsonWriter, value, contractSafe, null, null, null);
				}
			}
			catch (Exception exception_)
			{
				if (!IsErrorHandled(null, contractSafe, null, null, jsonWriter.Path, exception_))
				{
					ClearErrorContext();
					throw;
				}
				HandleError(jsonWriter, 0);
			}
			finally
			{
				_rootContract = null;
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

		private JsonContract GetContractSafe(object value)
		{
			if (value == null)
			{
				return null;
			}
			return Serializer._contractResolver.ResolveContract(value.GetType());
		}

		private void SerializePrimitive(JsonWriter writer, object value, JsonPrimitiveContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			int num = 8;
			if (contract.TypeCode == PrimitiveTypeCode.Bytes && ShouldWriteType(TypeNameHandling.Objects, contract, member, containerContract, containerProperty))
			{
				writer.WriteStartObject();
				WriteTypeProperty(writer, contract.CreatedType);
				writer.WritePropertyName("$value", escape: false);
				JsonWriter.WriteValue(writer, contract.TypeCode, value);
				writer.WriteEndObject();
			}
			else
			{
				JsonWriter.WriteValue(writer, contract.TypeCode, value);
			}
		}

		private void SerializeValue(JsonWriter writer, object value, JsonContract valueContract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}
			object obj;
			if (member == null)
			{
				obj = null;
			}
			else
			{
				obj = member.Converter;
				if (obj != null)
				{
					goto IL_006f;
				}
			}
			if (containerProperty == null)
			{
				obj = null;
			}
			else
			{
				obj = containerProperty.ItemConverter;
				if (obj != null)
				{
					goto IL_006f;
				}
			}
			if (containerContract == null)
			{
				obj = null;
			}
			else
			{
				obj = containerContract.ItemConverter;
				if (obj != null)
				{
					goto IL_006f;
				}
			}
			obj = (valueContract.Converter ?? Serializer.GetMatchingConverter(valueContract.UnderlyingType) ?? valueContract.InternalConverter);
			goto IL_006f;
			IL_006f:
			JsonConverter jsonConverter = (JsonConverter)obj;
			if (jsonConverter != null && jsonConverter.CanWrite)
			{
				SerializeConvertable(writer, jsonConverter, value, valueContract, containerContract, containerProperty);
				return;
			}
			switch (valueContract.ContractType)
			{
			case JsonContractType.Dynamic:
				break;
			case JsonContractType.Object:
				SerializeObject(writer, value, (JsonObjectContract)valueContract, member, containerContract, containerProperty);
				break;
			case JsonContractType.Array:
			{
				JsonArrayContract jsonArrayContract = (JsonArrayContract)valueContract;
				if (!jsonArrayContract.IsMultidimensionalArray)
				{
					SerializeList(writer, (IEnumerable)value, jsonArrayContract, member, containerContract, containerProperty);
				}
				else
				{
					SerializeMultidimensionalArray(writer, (Array)value, jsonArrayContract, member, containerContract, containerProperty);
				}
				break;
			}
			case JsonContractType.Primitive:
				SerializePrimitive(writer, value, (JsonPrimitiveContract)valueContract, member, containerContract, containerProperty);
				break;
			case JsonContractType.String:
				SerializeString(writer, value, (JsonStringContract)valueContract);
				break;
			case JsonContractType.Dictionary:
			{
				JsonDictionaryContract jsonDictionaryContract = (JsonDictionaryContract)valueContract;
				SerializeDictionary(writer, (value is IDictionary) ? ((IDictionary)value) : jsonDictionaryContract.CreateWrapper(value), jsonDictionaryContract, member, containerContract, containerProperty);
				break;
			}
			case JsonContractType.Serializable:
				SerializeISerializable(writer, (ISerializable)value, (JsonISerializableContract)valueContract, member, containerContract, containerProperty);
				break;
			case JsonContractType.Linq:
				((JToken)value).WriteTo(writer, Enumerable.ToArray(Serializer.Converters));
				break;
			}
		}

		private bool? ResolveIsReference(JsonContract contract, JsonProperty property, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			bool? result = null;
			if (property != null)
			{
				result = property.IsReference;
			}
			if (!result.HasValue && containerProperty != null)
			{
				result = containerProperty.ItemIsReference;
			}
			if (!result.HasValue && collectionContract != null)
			{
				result = collectionContract.ItemIsReference;
			}
			if (!result.HasValue)
			{
				result = contract.IsReference;
			}
			return result;
		}

		private bool ShouldWriteReference(object value, JsonProperty property, JsonContract valueContract, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			if (value == null)
			{
				return false;
			}
			if (valueContract.ContractType == JsonContractType.Primitive || valueContract.ContractType == JsonContractType.String)
			{
				return false;
			}
			bool? flag = ResolveIsReference(valueContract, property, collectionContract, containerProperty);
			if (!flag.HasValue)
			{
				flag = ((valueContract.ContractType == JsonContractType.Array) ? new bool?(HasFlag(Serializer._preserveReferencesHandling, PreserveReferencesHandling.Arrays)) : new bool?(HasFlag(Serializer._preserveReferencesHandling, PreserveReferencesHandling.Objects)));
			}
			if (!flag.Value)
			{
				return false;
			}
			return Serializer.GetReferenceResolver().IsReferenced(this, value);
		}

		private bool ShouldWriteProperty(object memberValue, JsonProperty property)
		{
			if (property.NullValueHandling.GetValueOrDefault(Serializer._nullValueHandling) == NullValueHandling.Ignore && memberValue == null)
			{
				return false;
			}
			if (HasFlag(property.DefaultValueHandling.GetValueOrDefault(Serializer._defaultValueHandling), DefaultValueHandling.Ignore) && MiscellaneousUtils.ValueEquals(memberValue, property.GetResolvedDefaultValue()))
			{
				return false;
			}
			return true;
		}

		private bool CheckForCircularReference(JsonWriter writer, object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			int num = 0;
			if (value == null || contract.ContractType == JsonContractType.Primitive || contract.ContractType == JsonContractType.String)
			{
				return true;
			}
			ReferenceLoopHandling? referenceLoopHandling = null;
			if (property != null)
			{
				referenceLoopHandling = property.ReferenceLoopHandling;
			}
			if (!referenceLoopHandling.HasValue && containerProperty != null)
			{
				referenceLoopHandling = containerProperty.ItemReferenceLoopHandling;
			}
			if (!referenceLoopHandling.HasValue && containerContract != null)
			{
				referenceLoopHandling = containerContract.ItemReferenceLoopHandling;
			}
			if ((Serializer._equalityComparer != null) ? CollectionUtils.Contains(_serializeStack, value, Serializer._equalityComparer) : _serializeStack.Contains(value))
			{
				string str = "Self referencing loop detected";
				if (property != null)
				{
					str += StringUtils.FormatWith(" for property '{0}'", CultureInfo.InvariantCulture, property.PropertyName);
				}
				str += StringUtils.FormatWith(" with type '{0}'.", CultureInfo.InvariantCulture, value.GetType());
				switch (referenceLoopHandling.GetValueOrDefault(Serializer._referenceLoopHandling))
				{
				case ReferenceLoopHandling.Error:
					throw JsonSerializationException.Create(null, writer.ContainerPath, str, null);
				case ReferenceLoopHandling.Ignore:
					if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
					{
						TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, str + ". Skipping serializing self referenced value."), null);
					}
					return false;
				case ReferenceLoopHandling.Serialize:
					if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
					{
						TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, str + ". Serializing self referenced value."), null);
					}
					return true;
				}
			}
			return true;
		}

		private void WriteReference(JsonWriter writer, object value)
		{
			int num = 11;
			string reference = GetReference(writer, value);
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("Writing object reference to Id '{0}' for {1}.", CultureInfo.InvariantCulture, reference, value.GetType())), null);
			}
			writer.WriteStartObject();
			writer.WritePropertyName("$ref", escape: false);
			writer.WriteValue(reference);
			writer.WriteEndObject();
		}

		private string GetReference(JsonWriter writer, object value)
		{
			int num = 17;
			try
			{
				return Serializer.GetReferenceResolver().GetReference(this, value);
			}
			catch (Exception exception_)
			{
				throw JsonSerializationException.Create(null, writer.ContainerPath, StringUtils.FormatWith("Error writing object reference for '{0}'.", CultureInfo.InvariantCulture, value.GetType()), exception_);
			}
		}

		internal static bool TryConvertToString(object value, Type type, out string string_0)
		{
			TypeConverter converter = ConvertUtils.GetConverter(type);
			if (converter != null && !(converter is ComponentConverter) && converter.GetType() != typeof(TypeConverter) && converter.CanConvertTo(typeof(string)))
			{
				string_0 = converter.ConvertToInvariantString(value);
				return true;
			}
			if (value is Type)
			{
				string_0 = ((Type)value).AssemblyQualifiedName;
				return true;
			}
			string_0 = null;
			return false;
		}

		private void SerializeString(JsonWriter writer, object value, JsonStringContract contract)
		{
			OnSerializing(writer, contract, value);
			TryConvertToString(value, contract.UnderlyingType, out string string_);
			writer.WriteValue(string_);
			OnSerialized(writer, contract, value);
		}

		private void OnSerializing(JsonWriter writer, JsonContract contract, object value)
		{
			int num = 5;
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("Started serializing {0}", CultureInfo.InvariantCulture, contract.UnderlyingType)), null);
			}
			contract.InvokeOnSerializing(value, Serializer._context);
		}

		private void OnSerialized(JsonWriter writer, JsonContract contract, object value)
		{
			int num = 16;
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
			{
				TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("Finished serializing {0}", CultureInfo.InvariantCulture, contract.UnderlyingType)), null);
			}
			contract.InvokeOnSerialized(value, Serializer._context);
		}

		private void SerializeObject(JsonWriter writer, object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			OnSerializing(writer, contract, value);
			_serializeStack.Add(value);
			WriteObjectStart(writer, value, contract, member, collectionContract, containerProperty);
			int top = writer.Top;
			for (int i = 0; i < contract.Properties.Count; i++)
			{
				JsonProperty jsonProperty = contract.Properties[i];
				try
				{
					if (CalculatePropertyValues(writer, value, contract, member, jsonProperty, out JsonContract memberContract, out object memberValue))
					{
						jsonProperty.WritePropertyName(writer);
						SerializeValue(writer, memberValue, memberContract, jsonProperty, contract, member);
					}
				}
				catch (Exception exception_)
				{
					if (!IsErrorHandled(value, contract, jsonProperty.PropertyName, null, writer.ContainerPath, exception_))
					{
						throw;
					}
					HandleError(writer, top);
				}
			}
			if (contract.ExtensionDataGetter != null)
			{
				IEnumerable<KeyValuePair<object, object>> enumerable = contract.ExtensionDataGetter(value);
				if (enumerable != null)
				{
					foreach (KeyValuePair<object, object> item in enumerable)
					{
						JsonContract contractSafe = GetContractSafe(item.Key);
						JsonContract contractSafe2 = GetContractSafe(item.Value);
						bool escape;
						string propertyName = GetPropertyName(writer, item.Key, contractSafe, out escape);
						if (ShouldWriteReference(item.Value, null, contractSafe2, contract, member))
						{
							writer.WritePropertyName(propertyName);
							WriteReference(writer, item.Value);
						}
						else if (CheckForCircularReference(writer, item.Value, null, contractSafe2, contract, member))
						{
							writer.WritePropertyName(propertyName);
							SerializeValue(writer, item.Value, contractSafe2, null, contract, member);
						}
					}
				}
			}
			writer.WriteEndObject();
			_serializeStack.RemoveAt(_serializeStack.Count - 1);
			OnSerialized(writer, contract, value);
		}

		private bool CalculatePropertyValues(JsonWriter writer, object value, JsonContainerContract contract, JsonProperty member, JsonProperty property, out JsonContract memberContract, out object memberValue)
		{
			int num = 16;
			if (!property.Ignored && property.Readable && ShouldSerialize(writer, property, value) && IsSpecified(writer, property, value))
			{
				if (property.PropertyContract == null)
				{
					property.PropertyContract = Serializer._contractResolver.ResolveContract(property.PropertyType);
				}
				memberValue = property.ValueProvider.GetValue(value);
				memberContract = (property.PropertyContract.IsSealed ? property.PropertyContract : GetContractSafe(memberValue));
				if (ShouldWriteProperty(memberValue, property))
				{
					if (ShouldWriteReference(memberValue, property, memberContract, contract, member))
					{
						property.WritePropertyName(writer);
						WriteReference(writer, memberValue);
						return false;
					}
					if (!CheckForCircularReference(writer, memberValue, property, memberContract, contract, member))
					{
						return false;
					}
					if (memberValue == null)
					{
						JsonObjectContract jsonObjectContract = contract as JsonObjectContract;
						Required required = property._required ?? jsonObjectContract?.ItemRequired ?? Required.Default;
						if (required == Required.Always)
						{
							throw JsonSerializationException.Create(null, writer.ContainerPath, StringUtils.FormatWith("Cannot write a null value for property '{0}'. Property requires a value.", CultureInfo.InvariantCulture, property.PropertyName), null);
						}
					}
					return true;
				}
			}
			memberContract = null;
			memberValue = null;
			return false;
		}

		private void WriteObjectStart(JsonWriter writer, object value, JsonContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			writer.WriteStartObject();
			if ((ResolveIsReference(contract, member, collectionContract, containerProperty) ?? HasFlag(Serializer._preserveReferencesHandling, PreserveReferencesHandling.Objects)) && (member == null || member.Writable))
			{
				WriteReferenceIdProperty(writer, contract.UnderlyingType, value);
			}
			if (ShouldWriteType(TypeNameHandling.Objects, contract, member, collectionContract, containerProperty))
			{
				WriteTypeProperty(writer, contract.UnderlyingType);
			}
		}

		private void WriteReferenceIdProperty(JsonWriter writer, Type type, object value)
		{
			int num = 15;
			string reference = GetReference(writer, value);
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
			{
				TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("Writing object reference Id '{0}' for {1}.", CultureInfo.InvariantCulture, reference, type)), null);
			}
			writer.WritePropertyName("$id", escape: false);
			writer.WriteValue(reference);
		}

		private void WriteTypeProperty(JsonWriter writer, Type type)
		{
			int num = 17;
			string typeName = ReflectionUtils.GetTypeName(type, Serializer._typeNameAssemblyFormat, Serializer._binder);
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
			{
				TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("Writing type name '{0}' for {1}.", CultureInfo.InvariantCulture, typeName, type)), null);
			}
			writer.WritePropertyName("$type", escape: false);
			writer.WriteValue(typeName);
		}

		private bool HasFlag(DefaultValueHandling value, DefaultValueHandling flag)
		{
			return (value & flag) == flag;
		}

		private bool HasFlag(PreserveReferencesHandling value, PreserveReferencesHandling flag)
		{
			return (value & flag) == flag;
		}

		private bool HasFlag(TypeNameHandling value, TypeNameHandling flag)
		{
			return (value & flag) == flag;
		}

		private void SerializeConvertable(JsonWriter writer, JsonConverter converter, object value, JsonContract contract, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			int num = 6;
			if (ShouldWriteReference(value, null, contract, collectionContract, containerProperty))
			{
				WriteReference(writer, value);
			}
			else if (CheckForCircularReference(writer, value, null, contract, collectionContract, containerProperty))
			{
				_serializeStack.Add(value);
				if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
				{
					TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("Started serializing {0} with converter {1}.", CultureInfo.InvariantCulture, value.GetType(), converter.GetType())), null);
				}
				converter.WriteJson(writer, value, GetInternalSerializer());
				if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Info)
				{
					TraceWriter.Trace(TraceLevel.Info, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("Finished serializing {0} with converter {1}.", CultureInfo.InvariantCulture, value.GetType(), converter.GetType())), null);
				}
				_serializeStack.RemoveAt(_serializeStack.Count - 1);
			}
		}

		private void SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			IWrappedCollection wrappedCollection = values as IWrappedCollection;
			object obj = (wrappedCollection != null) ? wrappedCollection.UnderlyingCollection : values;
			OnSerializing(writer, contract, obj);
			_serializeStack.Add(obj);
			bool flag = WriteStartArray(writer, obj, contract, member, collectionContract, containerProperty);
			writer.WriteStartArray();
			int top = writer.Top;
			int num = 0;
			foreach (object value in values)
			{
				try
				{
					JsonContract jsonContract = contract.FinalItemContract ?? GetContractSafe(value);
					if (ShouldWriteReference(value, null, jsonContract, contract, member))
					{
						WriteReference(writer, value);
					}
					else if (CheckForCircularReference(writer, value, null, jsonContract, contract, member))
					{
						SerializeValue(writer, value, jsonContract, null, contract, member);
					}
				}
				catch (Exception exception_)
				{
					if (!IsErrorHandled(obj, contract, num, null, writer.ContainerPath, exception_))
					{
						throw;
					}
					HandleError(writer, top);
				}
				finally
				{
					num++;
				}
			}
			writer.WriteEndArray();
			if (flag)
			{
				writer.WriteEndObject();
			}
			_serializeStack.RemoveAt(_serializeStack.Count - 1);
			OnSerialized(writer, contract, obj);
		}

		private void SerializeMultidimensionalArray(JsonWriter writer, Array values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			OnSerializing(writer, contract, values);
			_serializeStack.Add(values);
			bool flag = WriteStartArray(writer, values, contract, member, collectionContract, containerProperty);
			SerializeMultidimensionalArray(writer, values, contract, member, writer.Top, new int[0]);
			if (flag)
			{
				writer.WriteEndObject();
			}
			_serializeStack.RemoveAt(_serializeStack.Count - 1);
			OnSerialized(writer, contract, values);
		}

		private void SerializeMultidimensionalArray(JsonWriter writer, Array values, JsonArrayContract contract, JsonProperty member, int initialDepth, int[] indices)
		{
			int num = indices.Length;
			int[] array = new int[num + 1];
			for (int i = 0; i < num; i++)
			{
				array[i] = indices[i];
			}
			writer.WriteStartArray();
			for (int i = 0; i < values.GetLength(num); i++)
			{
				array[num] = i;
				if (array.Length == values.Rank)
				{
					object value = values.GetValue(array);
					try
					{
						JsonContract jsonContract = contract.FinalItemContract ?? GetContractSafe(value);
						if (ShouldWriteReference(value, null, jsonContract, contract, member))
						{
							WriteReference(writer, value);
						}
						else if (CheckForCircularReference(writer, value, null, jsonContract, contract, member))
						{
							SerializeValue(writer, value, jsonContract, null, contract, member);
						}
					}
					catch (Exception exception_)
					{
						if (!IsErrorHandled(values, contract, i, null, writer.ContainerPath, exception_))
						{
							throw;
						}
						HandleError(writer, initialDepth + 1);
					}
				}
				else
				{
					SerializeMultidimensionalArray(writer, values, contract, member, initialDepth + 1, array);
				}
			}
			writer.WriteEndArray();
		}

		private bool WriteStartArray(JsonWriter writer, object values, JsonArrayContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			int num = 8;
			bool num2 = ResolveIsReference(contract, member, containerContract, containerProperty) ?? HasFlag(Serializer._preserveReferencesHandling, PreserveReferencesHandling.Arrays);
			bool flag = num2;
			flag = (num2 && (member?.Writable ?? true));
			bool flag2 = ShouldWriteType(TypeNameHandling.Arrays, contract, member, containerContract, containerProperty);
			bool result;
			if (result = (flag || flag2))
			{
				writer.WriteStartObject();
				if (flag)
				{
					WriteReferenceIdProperty(writer, contract.UnderlyingType, values);
				}
				if (flag2)
				{
					WriteTypeProperty(writer, values.GetType());
				}
				writer.WritePropertyName("$values", escape: false);
			}
			if (contract.ItemContract == null)
			{
				contract.ItemContract = Serializer._contractResolver.ResolveContract(contract.CollectionItemType ?? typeof(object));
			}
			return result;
		}

		private void SerializeISerializable(JsonWriter writer, ISerializable value, JsonISerializableContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			int num = 6;
			if (!JsonTypeReflector.FullyTrusted)
			{
				string format = "Type '{0}' implements ISerializable but cannot be serialized using the ISerializable interface because the current application is not fully trusted and ISerializable can expose secure data." + Environment.NewLine + "To fix this error either change the environment to be fully trusted, change the application to not deserialize the type, add JsonObjectAttribute to the type or change the JsonSerializer setting ContractResolver to use a new DefaultContractResolver with IgnoreSerializableInterface set to true." + Environment.NewLine;
				format = StringUtils.FormatWith(format, CultureInfo.InvariantCulture, value.GetType());
				throw JsonSerializationException.Create(null, writer.ContainerPath, format, null);
			}
			OnSerializing(writer, contract, value);
			_serializeStack.Add(value);
			WriteObjectStart(writer, value, contract, member, collectionContract, containerProperty);
			SerializationInfo serializationInfo = new SerializationInfo(contract.UnderlyingType, new FormatterConverter());
			value.GetObjectData(serializationInfo, Serializer._context);
			SerializationInfoEnumerator enumerator = serializationInfo.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				JsonContract contractSafe = GetContractSafe(current.Value);
				if (ShouldWriteReference(current.Value, null, contractSafe, contract, member))
				{
					writer.WritePropertyName(current.Name);
					WriteReference(writer, current.Value);
				}
				else if (CheckForCircularReference(writer, current.Value, null, contractSafe, contract, member))
				{
					writer.WritePropertyName(current.Name);
					SerializeValue(writer, current.Value, contractSafe, null, contract, member);
				}
			}
			writer.WriteEndObject();
			_serializeStack.RemoveAt(_serializeStack.Count - 1);
			OnSerialized(writer, contract, value);
		}

		private bool ShouldWriteDynamicProperty(object memberValue)
		{
			if (Serializer._nullValueHandling == NullValueHandling.Ignore && memberValue == null)
			{
				return false;
			}
			if (HasFlag(Serializer._defaultValueHandling, DefaultValueHandling.Ignore) && (memberValue == null || MiscellaneousUtils.ValueEquals(memberValue, ReflectionUtils.GetDefaultValue(memberValue.GetType()))))
			{
				return false;
			}
			return true;
		}

		private bool ShouldWriteType(TypeNameHandling typeNameHandlingFlag, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerProperty)
		{
			TypeNameHandling value = member?.TypeNameHandling ?? containerProperty?.ItemTypeNameHandling ?? containerContract?.ItemTypeNameHandling ?? Serializer._typeNameHandling;
			if (HasFlag(value, typeNameHandlingFlag))
			{
				return true;
			}
			if (HasFlag(value, TypeNameHandling.Auto))
			{
				if (member != null)
				{
					if (contract.UnderlyingType != member.PropertyContract.CreatedType)
					{
						return true;
					}
				}
				else if (containerContract != null)
				{
					if (containerContract.ItemContract == null || contract.UnderlyingType != containerContract.ItemContract.CreatedType)
					{
						return true;
					}
				}
				else if (_rootContract != null && _serializeStack.Count == _rootLevel && contract.UnderlyingType != _rootContract.CreatedType)
				{
					return true;
				}
			}
			return false;
		}

		private void SerializeDictionary(JsonWriter writer, IDictionary values, JsonDictionaryContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
		{
			IWrappedDictionary wrappedDictionary = values as IWrappedDictionary;
			object obj = (wrappedDictionary != null) ? wrappedDictionary.UnderlyingDictionary : values;
			OnSerializing(writer, contract, obj);
			_serializeStack.Add(obj);
			WriteObjectStart(writer, obj, contract, member, collectionContract, containerProperty);
			if (contract.ItemContract == null)
			{
				contract.ItemContract = Serializer._contractResolver.ResolveContract(contract.DictionaryValueType ?? typeof(object));
			}
			if (contract.KeyContract == null)
			{
				contract.KeyContract = Serializer._contractResolver.ResolveContract(contract.DictionaryKeyType ?? typeof(object));
			}
			int top = writer.Top;
			foreach (DictionaryEntry value2 in values)
			{
				string propertyName = GetPropertyName(writer, value2.Key, contract.KeyContract, out bool escape);
				propertyName = ((contract.DictionaryKeyResolver != null) ? contract.DictionaryKeyResolver(propertyName) : propertyName);
				try
				{
					object value = value2.Value;
					JsonContract jsonContract = contract.FinalItemContract ?? GetContractSafe(value);
					if (ShouldWriteReference(value, null, jsonContract, contract, member))
					{
						writer.WritePropertyName(propertyName, escape);
						WriteReference(writer, value);
					}
					else if (CheckForCircularReference(writer, value, null, jsonContract, contract, member))
					{
						writer.WritePropertyName(propertyName, escape);
						SerializeValue(writer, value, jsonContract, null, contract, member);
					}
				}
				catch (Exception exception_)
				{
					if (!IsErrorHandled(obj, contract, propertyName, null, writer.ContainerPath, exception_))
					{
						throw;
					}
					HandleError(writer, top);
				}
			}
			writer.WriteEndObject();
			_serializeStack.RemoveAt(_serializeStack.Count - 1);
			OnSerialized(writer, contract, obj);
		}

		private string GetPropertyName(JsonWriter writer, object name, JsonContract contract, out bool escape)
		{
			if (contract.ContractType == JsonContractType.Primitive)
			{
				JsonPrimitiveContract jsonPrimitiveContract = (JsonPrimitiveContract)contract;
				if (jsonPrimitiveContract.TypeCode == PrimitiveTypeCode.DateTime || jsonPrimitiveContract.TypeCode == PrimitiveTypeCode.DateTimeNullable)
				{
					escape = false;
					StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
					DateTimeUtils.WriteDateTimeString(stringWriter, (DateTime)name, writer.DateFormatHandling, writer.DateFormatString, writer.Culture);
					return stringWriter.ToString();
				}
				escape = true;
				return Convert.ToString(name, CultureInfo.InvariantCulture);
			}
			if (TryConvertToString(name, name.GetType(), out string string_))
			{
				escape = true;
				return string_;
			}
			escape = true;
			return name.ToString();
		}

		private void HandleError(JsonWriter writer, int initialDepth)
		{
			ClearErrorContext();
			if (writer.WriteState == WriteState.Property)
			{
				writer.WriteNull();
			}
			while (writer.Top > initialDepth)
			{
				writer.WriteEnd();
			}
		}

		private bool ShouldSerialize(JsonWriter writer, JsonProperty property, object target)
		{
			int num = 13;
			if (property.ShouldSerialize == null)
			{
				return true;
			}
			bool flag = property.ShouldSerialize(target);
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
			{
				TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("ShouldSerialize result for property '{0}' on {1}: {2}", CultureInfo.InvariantCulture, property.PropertyName, property.DeclaringType, flag)), null);
			}
			return flag;
		}

		private bool IsSpecified(JsonWriter writer, JsonProperty property, object target)
		{
			int num = 12;
			if (property.GetIsSpecified == null)
			{
				return true;
			}
			bool flag = property.GetIsSpecified(target);
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Verbose)
			{
				TraceWriter.Trace(TraceLevel.Verbose, JsonPosition.FormatMessage(null, writer.Path, StringUtils.FormatWith("IsSpecified result for property '{0}' on {1}: {2}", CultureInfo.InvariantCulture, property.PropertyName, property.DeclaringType, flag)), null);
			}
			return flag;
		}
	}
}
