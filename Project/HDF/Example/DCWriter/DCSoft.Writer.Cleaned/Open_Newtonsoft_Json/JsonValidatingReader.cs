using Open_Newtonsoft_Json.Linq;
using Open_Newtonsoft_Json.Schema;
using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///   <para>
	///       Represents a reader that provides <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchema" /> validation.
	///       </para>
	///   <note type="caution">
	///       JSON Schema validation has been moved to its own package. See <see href="http://www.newtonsoft.com/jsonschema">http://www.newtonsoft.com/jsonschema</see> for more details.
	///       </note>
	/// </summary>
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	[ComVisible(false)]
	public class JsonValidatingReader : JsonReader, IJsonLineInfo
	{
		private class SchemaScope
		{
			private readonly JTokenType _tokenType;

			private readonly IList<JsonSchemaModel> _schemas;

			private readonly Dictionary<string, bool> _requiredProperties;

			public string CurrentPropertyName
			{
				get;
				set;
			}

			public int ArrayItemCount
			{
				get;
				set;
			}

			public bool IsUniqueArray
			{
				get;
				set;
			}

			public IList<JToken> UniqueArrayItems
			{
				get;
				set;
			}

			public JTokenWriter CurrentItemWriter
			{
				get;
				set;
			}

			public IList<JsonSchemaModel> Schemas => _schemas;

			public Dictionary<string, bool> RequiredProperties => _requiredProperties;

			public JTokenType TokenType => _tokenType;

			public SchemaScope(JTokenType tokenType, IList<JsonSchemaModel> schemas)
			{
				_tokenType = tokenType;
				_schemas = schemas;
				_requiredProperties = Enumerable.ToDictionary(Enumerable.Distinct(Enumerable.SelectMany(schemas, GetRequiredProperties)), (string string_0) => string_0, (string string_0) => false);
				if (tokenType == JTokenType.Array && Enumerable.Any(schemas, (JsonSchemaModel jsonSchemaModel_0) => jsonSchemaModel_0.UniqueItems))
				{
					IsUniqueArray = true;
					UniqueArrayItems = new List<JToken>();
				}
			}

			private IEnumerable<string> GetRequiredProperties(JsonSchemaModel schema)
			{
				if (schema == null || schema.Properties == null)
				{
					return Enumerable.Empty<string>();
				}
				return Enumerable.Select(Enumerable.Where(schema.Properties, (KeyValuePair<string, JsonSchemaModel> keyValuePair_0) => keyValuePair_0.Value.Required), (KeyValuePair<string, JsonSchemaModel> keyValuePair_0) => keyValuePair_0.Key);
			}
		}

		private readonly JsonReader _reader;

		private readonly Stack<SchemaScope> _stack;

		private JsonSchema _schema;

		private JsonSchemaModel _model;

		private SchemaScope _currentScope;

		private static readonly IList<JsonSchemaModel> EmptySchemaList = new List<JsonSchemaModel>();

		/// <summary>
		///       Gets the text value of the current JSON token.
		///       </summary>
		/// <value>
		/// </value>
		public override object Value => _reader.Value;

		/// <summary>
		///       Gets the depth of the current token in the JSON document.
		///       </summary>
		/// <value>The depth of the current token in the JSON document.</value>
		public override int Depth => _reader.Depth;

		/// <summary>
		///       Gets the path of the current JSON token. 
		///       </summary>
		public override string Path => _reader.Path;

		/// <summary>
		///       Gets the quotation mark character used to enclose the value of a string.
		///       </summary>
		/// <value>
		/// </value>
		public override char QuoteChar
		{
			get
			{
				return _reader.QuoteChar;
			}
			protected internal set
			{
			}
		}

		/// <summary>
		///       Gets the type of the current JSON token.
		///       </summary>
		/// <value>
		/// </value>
		public override JsonToken TokenType => _reader.TokenType;

		/// <summary>
		///       Gets the Common Language Runtime (CLR) type for the current JSON token.
		///       </summary>
		/// <value>
		/// </value>
		public override Type ValueType => _reader.ValueType;

		private IList<JsonSchemaModel> CurrentSchemas => _currentScope.Schemas;

		private IList<JsonSchemaModel> CurrentMemberSchemas
		{
			get
			{
				int num = 14;
				if (_currentScope == null)
				{
					return new List<JsonSchemaModel>(new JsonSchemaModel[1]
					{
						_model
					});
				}
				if (_currentScope.Schemas == null || _currentScope.Schemas.Count == 0)
				{
					return EmptySchemaList;
				}
				switch (_currentScope.TokenType)
				{
				default:
					throw new ArgumentOutOfRangeException("TokenType", StringUtils.FormatWith("Unexpected token type: {0}", CultureInfo.InvariantCulture, _currentScope.TokenType));
				case JTokenType.None:
					return _currentScope.Schemas;
				case JTokenType.Object:
				{
					if (_currentScope.CurrentPropertyName == null)
					{
						throw new JsonReaderException("CurrentPropertyName has not been set on scope.");
					}
					IList<JsonSchemaModel> list = new List<JsonSchemaModel>();
					foreach (JsonSchemaModel currentSchema in CurrentSchemas)
					{
						if (currentSchema.Properties != null && currentSchema.Properties.TryGetValue(_currentScope.CurrentPropertyName, out JsonSchemaModel value))
						{
							list.Add(value);
						}
						if (currentSchema.PatternProperties != null)
						{
							foreach (KeyValuePair<string, JsonSchemaModel> patternProperty in currentSchema.PatternProperties)
							{
								if (Regex.IsMatch(_currentScope.CurrentPropertyName, patternProperty.Key))
								{
									list.Add(patternProperty.Value);
								}
							}
						}
						if (list.Count == 0 && currentSchema.AllowAdditionalProperties && currentSchema.AdditionalProperties != null)
						{
							list.Add(currentSchema.AdditionalProperties);
						}
					}
					return list;
				}
				case JTokenType.Array:
				{
					IList<JsonSchemaModel> list = new List<JsonSchemaModel>();
					foreach (JsonSchemaModel currentSchema2 in CurrentSchemas)
					{
						if (!currentSchema2.PositionalItemsValidation)
						{
							if (currentSchema2.Items != null && currentSchema2.Items.Count > 0)
							{
								list.Add(currentSchema2.Items[0]);
							}
						}
						else
						{
							if (currentSchema2.Items != null && currentSchema2.Items.Count > 0 && currentSchema2.Items.Count > _currentScope.ArrayItemCount - 1)
							{
								list.Add(currentSchema2.Items[_currentScope.ArrayItemCount - 1]);
							}
							if (currentSchema2.AllowAdditionalItems && currentSchema2.AdditionalItems != null)
							{
								list.Add(currentSchema2.AdditionalItems);
							}
						}
					}
					return list;
				}
				case JTokenType.Constructor:
					return EmptySchemaList;
				}
			}
		}

		/// <summary>
		///       Gets or sets the schema.
		///       </summary>
		/// <value>The schema.</value>
		public JsonSchema Schema
		{
			get
			{
				return _schema;
			}
			set
			{
				int num = 5;
				if (TokenType != 0)
				{
					throw new InvalidOperationException("Cannot change schema while validating JSON.");
				}
				_schema = value;
				_model = null;
			}
		}

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.JsonReader" /> used to construct this <see cref="T:Open_Newtonsoft_Json.JsonValidatingReader" />.
		///       </summary>
		/// <value>The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> specified in the constructor.</value>
		public JsonReader Reader => _reader;

		int IJsonLineInfo.LineNumber => (_reader as IJsonLineInfo)?.LineNumber ?? 0;

		int IJsonLineInfo.LinePosition => (_reader as IJsonLineInfo)?.LinePosition ?? 0;

		/// <summary>
		///       Sets an event handler for receiving schema validation errors.
		///       </summary>
		public event ValidationEventHandler ValidationEventHandler;

		private void Push(SchemaScope scope)
		{
			_stack.Push(scope);
			_currentScope = scope;
		}

		private SchemaScope Pop()
		{
			SchemaScope result = _stack.Pop();
			_currentScope = ((_stack.Count != 0) ? _stack.Peek() : null);
			return result;
		}

		private void RaiseError(string message, JsonSchemaModel schema)
		{
			int num = 0;
			string message2 = ((IJsonLineInfo)this).HasLineInfo() ? (message + StringUtils.FormatWith(" Line {0}, position {1}.", CultureInfo.InvariantCulture, ((IJsonLineInfo)this).LineNumber, ((IJsonLineInfo)this).LinePosition)) : message;
			OnValidationEvent(new JsonSchemaException(message2, null, Path, ((IJsonLineInfo)this).LineNumber, ((IJsonLineInfo)this).LinePosition));
		}

		private void OnValidationEvent(JsonSchemaException exception)
		{
			ValidationEventHandler validationEventHandler = this.ValidationEventHandler;
			if (validationEventHandler == null)
			{
				throw exception;
			}
			validationEventHandler(this, new ValidationEventArgs(exception));
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonValidatingReader" /> class that
		///       validates the content returned from the given <see cref="T:Open_Newtonsoft_Json.JsonReader" />.
		///       </summary>
		/// <param name="reader">The <see cref="T:Open_Newtonsoft_Json.JsonReader" /> to read from while validating.</param>
		public JsonValidatingReader(JsonReader reader)
		{
			ValidationUtils.ArgumentNotNull(reader, "reader");
			_reader = reader;
			_stack = new Stack<SchemaScope>();
		}

		private void ValidateNotDisallowed(JsonSchemaModel schema)
		{
			int num = 8;
			if (schema != null)
			{
				JsonSchemaType? currentNodeSchemaType = GetCurrentNodeSchemaType();
				if (currentNodeSchemaType.HasValue && JsonSchemaGenerator.HasFlag(schema.Disallow, currentNodeSchemaType.Value))
				{
					RaiseError(StringUtils.FormatWith("Type {0} is disallowed.", CultureInfo.InvariantCulture, currentNodeSchemaType), schema);
				}
			}
		}

		private JsonSchemaType? GetCurrentNodeSchemaType()
		{
			switch (_reader.TokenType)
			{
			case JsonToken.StartObject:
				return JsonSchemaType.Object;
			case JsonToken.StartArray:
				return JsonSchemaType.Array;
			default:
				return null;
			case JsonToken.Integer:
				return JsonSchemaType.Integer;
			case JsonToken.Float:
				return JsonSchemaType.Float;
			case JsonToken.String:
				return JsonSchemaType.String;
			case JsonToken.Boolean:
				return JsonSchemaType.Boolean;
			case JsonToken.Null:
				return JsonSchemaType.Null;
			}
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.Nullable`1" />.</returns>
		public override int? ReadAsInt32()
		{
			int? result = _reader.ReadAsInt32();
			ValidateCurrentToken();
			return result;
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Byte" />[].
		///       </summary>
		/// <returns>
		///       A <see cref="T:System.Byte" />[] or a null reference if the next JSON token is null.
		///       </returns>
		public override byte[] ReadAsBytes()
		{
			byte[] result = _reader.ReadAsBytes();
			ValidateCurrentToken();
			return result;
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.Nullable`1" />.</returns>
		public override decimal? ReadAsDecimal()
		{
			decimal? result = _reader.ReadAsDecimal();
			ValidateCurrentToken();
			return result;
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.String" />.
		///       </summary>
		/// <returns>A <see cref="T:System.String" />. This method will return <c>null</c> at the end of an array.</returns>
		public override string ReadAsString()
		{
			string result = _reader.ReadAsString();
			ValidateCurrentToken();
			return result;
		}

		/// <summary>
		///       Reads the next JSON token from the stream as a <see cref="T:System.Nullable`1" />.
		///       </summary>
		/// <returns>A <see cref="T:System.String" />. This method will return <c>null</c> at the end of an array.</returns>
		public override DateTime? ReadAsDateTime()
		{
			DateTime? result = _reader.ReadAsDateTime();
			ValidateCurrentToken();
			return result;
		}

		/// <summary>
		///       Reads the next JSON token from the stream.
		///       </summary>
		/// <returns>
		///       true if the next token was read successfully; false if there are no more tokens to read.
		///       </returns>
		public override bool Read()
		{
			if (!_reader.Read())
			{
				return false;
			}
			if (_reader.TokenType == JsonToken.Comment)
			{
				return true;
			}
			ValidateCurrentToken();
			return true;
		}

		private void ValidateCurrentToken()
		{
			if (_model == null)
			{
				JsonSchemaModelBuilder jsonSchemaModelBuilder = new JsonSchemaModelBuilder();
				_model = jsonSchemaModelBuilder.Build(_schema);
				if (!JsonTokenUtils.IsStartToken(_reader.TokenType))
				{
					Push(new SchemaScope(JTokenType.None, CurrentMemberSchemas));
				}
			}
			switch (_reader.TokenType)
			{
			case JsonToken.None:
				break;
			case JsonToken.StartObject:
			{
				ProcessValue();
				IList<JsonSchemaModel> schemas2 = Enumerable.ToList(Enumerable.Where(CurrentMemberSchemas, ValidateObject));
				Push(new SchemaScope(JTokenType.Object, schemas2));
				WriteToken(CurrentSchemas);
				break;
			}
			case JsonToken.StartArray:
			{
				ProcessValue();
				IList<JsonSchemaModel> schemas = Enumerable.ToList(Enumerable.Where(CurrentMemberSchemas, ValidateArray));
				Push(new SchemaScope(JTokenType.Array, schemas));
				WriteToken(CurrentSchemas);
				break;
			}
			case JsonToken.StartConstructor:
				ProcessValue();
				Push(new SchemaScope(JTokenType.Constructor, null));
				WriteToken(CurrentSchemas);
				break;
			case JsonToken.PropertyName:
				WriteToken(CurrentSchemas);
				foreach (JsonSchemaModel currentSchema in CurrentSchemas)
				{
					ValidatePropertyName(currentSchema);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case JsonToken.Raw:
				ProcessValue();
				break;
			case JsonToken.Integer:
				ProcessValue();
				WriteToken(CurrentMemberSchemas);
				foreach (JsonSchemaModel currentMemberSchema in CurrentMemberSchemas)
				{
					ValidateInteger(currentMemberSchema);
				}
				break;
			case JsonToken.Float:
				ProcessValue();
				WriteToken(CurrentMemberSchemas);
				foreach (JsonSchemaModel currentMemberSchema2 in CurrentMemberSchemas)
				{
					ValidateFloat(currentMemberSchema2);
				}
				break;
			case JsonToken.String:
				ProcessValue();
				WriteToken(CurrentMemberSchemas);
				foreach (JsonSchemaModel currentMemberSchema3 in CurrentMemberSchemas)
				{
					ValidateString(currentMemberSchema3);
				}
				break;
			case JsonToken.Boolean:
				ProcessValue();
				WriteToken(CurrentMemberSchemas);
				foreach (JsonSchemaModel currentMemberSchema4 in CurrentMemberSchemas)
				{
					ValidateBoolean(currentMemberSchema4);
				}
				break;
			case JsonToken.Null:
				ProcessValue();
				WriteToken(CurrentMemberSchemas);
				foreach (JsonSchemaModel currentMemberSchema5 in CurrentMemberSchemas)
				{
					ValidateNull(currentMemberSchema5);
				}
				break;
			case JsonToken.EndObject:
				WriteToken(CurrentSchemas);
				foreach (JsonSchemaModel currentSchema2 in CurrentSchemas)
				{
					ValidateEndObject(currentSchema2);
				}
				Pop();
				break;
			case JsonToken.EndArray:
				WriteToken(CurrentSchemas);
				foreach (JsonSchemaModel currentSchema3 in CurrentSchemas)
				{
					ValidateEndArray(currentSchema3);
				}
				Pop();
				break;
			case JsonToken.EndConstructor:
				WriteToken(CurrentSchemas);
				Pop();
				break;
			case JsonToken.Undefined:
			case JsonToken.Date:
			case JsonToken.Bytes:
				WriteToken(CurrentMemberSchemas);
				break;
			}
		}

		private void WriteToken(IList<JsonSchemaModel> schemas)
		{
			int num = 17;
			foreach (SchemaScope item in _stack)
			{
				bool flag;
				if ((flag = (item.TokenType == JTokenType.Array && item.IsUniqueArray && item.ArrayItemCount > 0)) || Enumerable.Any(schemas, (JsonSchemaModel jsonSchemaModel_0) => jsonSchemaModel_0.Enum != null))
				{
					if (item.CurrentItemWriter == null)
					{
						if (JsonTokenUtils.IsEndToken(_reader.TokenType))
						{
							continue;
						}
						item.CurrentItemWriter = new JTokenWriter();
					}
					item.CurrentItemWriter.WriteToken(_reader, writeChildren: false);
					if (item.CurrentItemWriter.Top == 0 && _reader.TokenType != JsonToken.PropertyName)
					{
						JToken token = item.CurrentItemWriter.Token;
						item.CurrentItemWriter = null;
						if (flag)
						{
							if (Enumerable.Contains(item.UniqueArrayItems, token, JToken.EqualityComparer))
							{
								RaiseError(StringUtils.FormatWith("Non-unique array item at index {0}.", CultureInfo.InvariantCulture, item.ArrayItemCount - 1), Enumerable.First(item.Schemas, (JsonSchemaModel jsonSchemaModel_0) => jsonSchemaModel_0.UniqueItems));
							}
							item.UniqueArrayItems.Add(token);
						}
						else if (Enumerable.Any(schemas, (JsonSchemaModel jsonSchemaModel_0) => jsonSchemaModel_0.Enum != null))
						{
							foreach (JsonSchemaModel schema in schemas)
							{
								if (schema.Enum != null && !CollectionUtils.ContainsValue(schema.Enum, token, JToken.EqualityComparer))
								{
									StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
									token.WriteTo(new JsonTextWriter(stringWriter));
									RaiseError(StringUtils.FormatWith("Value {0} is not defined in enum.", CultureInfo.InvariantCulture, stringWriter.ToString()), schema);
								}
							}
						}
					}
				}
			}
		}

		private void ValidateEndObject(JsonSchemaModel schema)
		{
			int num = 2;
			if (schema == null)
			{
				return;
			}
			Dictionary<string, bool> requiredProperties = _currentScope.RequiredProperties;
			if (requiredProperties != null)
			{
				List<string> list = Enumerable.ToList(Enumerable.Select(Enumerable.Where(requiredProperties, (KeyValuePair<string, bool> keyValuePair_0) => !keyValuePair_0.Value), (KeyValuePair<string, bool> keyValuePair_0) => keyValuePair_0.Key));
				if (list.Count > 0)
				{
					RaiseError(StringUtils.FormatWith("Required properties are missing from object: {0}.", CultureInfo.InvariantCulture, string.Join(", ", list.ToArray())), schema);
				}
			}
		}

		private void ValidateEndArray(JsonSchemaModel schema)
		{
			int num = 5;
			if (schema != null)
			{
				int arrayItemCount = _currentScope.ArrayItemCount;
				if (schema.MaximumItems.HasValue && arrayItemCount > schema.MaximumItems)
				{
					RaiseError(StringUtils.FormatWith("Array item count {0} exceeds maximum count of {1}.", CultureInfo.InvariantCulture, arrayItemCount, schema.MaximumItems), schema);
				}
				if (schema.MinimumItems.HasValue && arrayItemCount < schema.MinimumItems)
				{
					RaiseError(StringUtils.FormatWith("Array item count {0} is less than minimum count of {1}.", CultureInfo.InvariantCulture, arrayItemCount, schema.MinimumItems), schema);
				}
			}
		}

		private void ValidateNull(JsonSchemaModel schema)
		{
			if (schema != null && TestType(schema, JsonSchemaType.Null))
			{
				ValidateNotDisallowed(schema);
			}
		}

		private void ValidateBoolean(JsonSchemaModel schema)
		{
			if (schema != null && TestType(schema, JsonSchemaType.Boolean))
			{
				ValidateNotDisallowed(schema);
			}
		}

		private void ValidateString(JsonSchemaModel schema)
		{
			int num = 11;
			if (schema != null && TestType(schema, JsonSchemaType.String))
			{
				ValidateNotDisallowed(schema);
				string text = _reader.Value.ToString();
				if (schema.MaximumLength.HasValue && text.Length > schema.MaximumLength)
				{
					RaiseError(StringUtils.FormatWith("String '{0}' exceeds maximum length of {1}.", CultureInfo.InvariantCulture, text, schema.MaximumLength), schema);
				}
				if (schema.MinimumLength.HasValue && text.Length < schema.MinimumLength)
				{
					RaiseError(StringUtils.FormatWith("String '{0}' is less than minimum length of {1}.", CultureInfo.InvariantCulture, text, schema.MinimumLength), schema);
				}
				if (schema.Patterns != null)
				{
					foreach (string pattern in schema.Patterns)
					{
						if (!Regex.IsMatch(text, pattern))
						{
							RaiseError(StringUtils.FormatWith("String '{0}' does not match regex pattern '{1}'.", CultureInfo.InvariantCulture, text, pattern), schema);
						}
					}
				}
			}
		}

		private void ValidateInteger(JsonSchemaModel schema)
		{
			int num = 2;
			if (schema == null || !TestType(schema, JsonSchemaType.Integer))
			{
				return;
			}
			ValidateNotDisallowed(schema);
			object value = _reader.Value;
			if (schema.Maximum.HasValue)
			{
				if (JValue.Compare(JTokenType.Integer, value, schema.Maximum) > 0)
				{
					RaiseError(StringUtils.FormatWith("Integer {0} exceeds maximum value of {1}.", CultureInfo.InvariantCulture, value, schema.Maximum), schema);
				}
				if (schema.ExclusiveMaximum && JValue.Compare(JTokenType.Integer, value, schema.Maximum) == 0)
				{
					RaiseError(StringUtils.FormatWith("Integer {0} equals maximum value of {1} and exclusive maximum is true.", CultureInfo.InvariantCulture, value, schema.Maximum), schema);
				}
			}
			if (schema.Minimum.HasValue)
			{
				if (JValue.Compare(JTokenType.Integer, value, schema.Minimum) < 0)
				{
					RaiseError(StringUtils.FormatWith("Integer {0} is less than minimum value of {1}.", CultureInfo.InvariantCulture, value, schema.Minimum), schema);
				}
				if (schema.ExclusiveMinimum && JValue.Compare(JTokenType.Integer, value, schema.Minimum) == 0)
				{
					RaiseError(StringUtils.FormatWith("Integer {0} equals minimum value of {1} and exclusive minimum is true.", CultureInfo.InvariantCulture, value, schema.Minimum), schema);
				}
			}
			if (schema.DivisibleBy.HasValue && !IsZero((double)Convert.ToInt64(value, CultureInfo.InvariantCulture) % schema.DivisibleBy.Value))
			{
				RaiseError(StringUtils.FormatWith("Integer {0} is not evenly divisible by {1}.", CultureInfo.InvariantCulture, JsonConvert.ToString(value), schema.DivisibleBy), schema);
			}
		}

		private void ProcessValue()
		{
			int num = 16;
			if (_currentScope != null && _currentScope.TokenType == JTokenType.Array)
			{
				_currentScope.ArrayItemCount++;
				foreach (JsonSchemaModel currentSchema in CurrentSchemas)
				{
					if (currentSchema != null && currentSchema.PositionalItemsValidation && !currentSchema.AllowAdditionalItems && (currentSchema.Items == null || _currentScope.ArrayItemCount - 1 >= currentSchema.Items.Count))
					{
						RaiseError(StringUtils.FormatWith("Index {0} has not been defined and the schema does not allow additional items.", CultureInfo.InvariantCulture, _currentScope.ArrayItemCount), currentSchema);
					}
				}
			}
		}

		private void ValidateFloat(JsonSchemaModel schema)
		{
			int num = 15;
			if (schema == null || !TestType(schema, JsonSchemaType.Float))
			{
				return;
			}
			ValidateNotDisallowed(schema);
			double num2 = Convert.ToDouble(_reader.Value, CultureInfo.InvariantCulture);
			if (schema.Maximum.HasValue)
			{
				if (num2 > schema.Maximum)
				{
					RaiseError(StringUtils.FormatWith("Float {0} exceeds maximum value of {1}.", CultureInfo.InvariantCulture, JsonConvert.ToString(num2), schema.Maximum), schema);
				}
				if (schema.ExclusiveMaximum && num2 == schema.Maximum)
				{
					RaiseError(StringUtils.FormatWith("Float {0} equals maximum value of {1} and exclusive maximum is true.", CultureInfo.InvariantCulture, JsonConvert.ToString(num2), schema.Maximum), schema);
				}
			}
			if (schema.Minimum.HasValue)
			{
				if (num2 < schema.Minimum)
				{
					RaiseError(StringUtils.FormatWith("Float {0} is less than minimum value of {1}.", CultureInfo.InvariantCulture, JsonConvert.ToString(num2), schema.Minimum), schema);
				}
				if (schema.ExclusiveMinimum && num2 == schema.Minimum)
				{
					RaiseError(StringUtils.FormatWith("Float {0} equals minimum value of {1} and exclusive minimum is true.", CultureInfo.InvariantCulture, JsonConvert.ToString(num2), schema.Minimum), schema);
				}
			}
			if (schema.DivisibleBy.HasValue)
			{
				double value = FloatingPointRemainder(num2, schema.DivisibleBy.Value);
				if (!IsZero(value))
				{
					RaiseError(StringUtils.FormatWith("Float {0} is not evenly divisible by {1}.", CultureInfo.InvariantCulture, JsonConvert.ToString(num2), schema.DivisibleBy), schema);
				}
			}
		}

		private static double FloatingPointRemainder(double dividend, double divisor)
		{
			return dividend - Math.Floor(dividend / divisor) * divisor;
		}

		private static bool IsZero(double value)
		{
			return Math.Abs(value) < 4.4408920985006262E-15;
		}

		private void ValidatePropertyName(JsonSchemaModel schema)
		{
			int num = 10;
			if (schema != null)
			{
				string text = Convert.ToString(_reader.Value, CultureInfo.InvariantCulture);
				if (_currentScope.RequiredProperties.ContainsKey(text))
				{
					_currentScope.RequiredProperties[text] = true;
				}
				if (!schema.AllowAdditionalProperties && !IsPropertyDefinied(schema, text))
				{
					RaiseError(StringUtils.FormatWith("Property '{0}' has not been defined and the schema does not allow additional properties.", CultureInfo.InvariantCulture, text), schema);
				}
				_currentScope.CurrentPropertyName = text;
			}
		}

		private bool IsPropertyDefinied(JsonSchemaModel schema, string propertyName)
		{
			if (schema.Properties != null && schema.Properties.ContainsKey(propertyName))
			{
				return true;
			}
			if (schema.PatternProperties != null)
			{
				foreach (string key in schema.PatternProperties.Keys)
				{
					if (Regex.IsMatch(propertyName, key))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool ValidateArray(JsonSchemaModel schema)
		{
			if (schema == null)
			{
				return true;
			}
			return TestType(schema, JsonSchemaType.Array);
		}

		private bool ValidateObject(JsonSchemaModel schema)
		{
			if (schema == null)
			{
				return true;
			}
			return TestType(schema, JsonSchemaType.Object);
		}

		private bool TestType(JsonSchemaModel currentSchema, JsonSchemaType currentType)
		{
			int num = 1;
			if (!JsonSchemaGenerator.HasFlag(currentSchema.Type, currentType))
			{
				RaiseError(StringUtils.FormatWith("Invalid type. Expected {0} but got {1}.", CultureInfo.InvariantCulture, currentSchema.Type, currentType), currentSchema);
				return false;
			}
			return true;
		}

		bool IJsonLineInfo.HasLineInfo()
		{
			return (_reader as IJsonLineInfo)?.HasLineInfo() ?? false;
		}
	}
}
