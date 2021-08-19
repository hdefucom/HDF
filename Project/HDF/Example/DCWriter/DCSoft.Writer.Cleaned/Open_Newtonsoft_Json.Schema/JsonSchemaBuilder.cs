using Open_Newtonsoft_Json.Linq;
using Open_Newtonsoft_Json.Utilities;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	[ComVisible(false)]
	internal class JsonSchemaBuilder
	{
		private readonly IList<JsonSchema> _stack;

		private readonly JsonSchemaResolver _resolver;

		private readonly IDictionary<string, JsonSchema> _documentSchemas;

		private JsonSchema _currentSchema;

		private JObject _rootSchema;

		private JsonSchema CurrentSchema => _currentSchema;

		public JsonSchemaBuilder(JsonSchemaResolver resolver)
		{
			_stack = new List<JsonSchema>();
			_documentSchemas = new Dictionary<string, JsonSchema>();
			_resolver = resolver;
		}

		private void Push(JsonSchema value)
		{
			_currentSchema = value;
			_stack.Add(value);
			_resolver.LoadedSchemas.Add(value);
			_documentSchemas.Add(value.Location, value);
		}

		private JsonSchema Pop()
		{
			JsonSchema currentSchema = _currentSchema;
			_stack.RemoveAt(_stack.Count - 1);
			_currentSchema = Enumerable.LastOrDefault(_stack);
			return currentSchema;
		}

		internal JsonSchema Read(JsonReader reader)
		{
			JToken jToken = JToken.ReadFrom(reader);
			_rootSchema = (jToken as JObject);
			JsonSchema jsonSchema = BuildSchema(jToken);
			ResolveReferences(jsonSchema);
			return jsonSchema;
		}

		private string UnescapeReference(string reference)
		{
			return Uri.UnescapeDataString(reference).Replace("~1", "/").Replace("~0", "~");
		}

		private JsonSchema ResolveReferences(JsonSchema schema)
		{
			int num = 6;
			if (schema.DeferredReference != null)
			{
				string text = schema.DeferredReference;
				bool flag;
				if (flag = text.StartsWith("#", StringComparison.Ordinal))
				{
					text = UnescapeReference(text);
				}
				JsonSchema jsonSchema = _resolver.GetSchema(text);
				if (jsonSchema == null)
				{
					if (flag)
					{
						string[] array = schema.DeferredReference.TrimStart('#').Split(new char[1]
						{
							'/'
						}, StringSplitOptions.RemoveEmptyEntries);
						JToken jToken = _rootSchema;
						string[] array2 = array;
						foreach (string reference in array2)
						{
							string text2 = UnescapeReference(reference);
							if (jToken.Type == JTokenType.Object)
							{
								jToken = jToken[text2];
							}
							else if (jToken.Type == JTokenType.Array || jToken.Type == JTokenType.Constructor)
							{
								jToken = ((!int.TryParse(text2, out int result) || result < 0 || result >= Enumerable.Count(jToken)) ? null : jToken[result]);
							}
							if (jToken == null)
							{
								break;
							}
						}
						if (jToken != null)
						{
							jsonSchema = BuildSchema(jToken);
						}
					}
					if (jsonSchema == null)
					{
						throw new JsonException(StringUtils.FormatWith("Could not resolve schema reference '{0}'.", CultureInfo.InvariantCulture, schema.DeferredReference));
					}
				}
				schema = jsonSchema;
			}
			if (schema.ReferencesResolved)
			{
				return schema;
			}
			schema.ReferencesResolved = true;
			if (schema.Extends != null)
			{
				for (int j = 0; j < schema.Extends.Count; j++)
				{
					schema.Extends[j] = ResolveReferences(schema.Extends[j]);
				}
			}
			if (schema.Items != null)
			{
				for (int j = 0; j < schema.Items.Count; j++)
				{
					schema.Items[j] = ResolveReferences(schema.Items[j]);
				}
			}
			if (schema.AdditionalItems != null)
			{
				schema.AdditionalItems = ResolveReferences(schema.AdditionalItems);
			}
			if (schema.PatternProperties != null)
			{
				foreach (KeyValuePair<string, JsonSchema> item in Enumerable.ToList(schema.PatternProperties))
				{
					schema.PatternProperties[item.Key] = ResolveReferences(item.Value);
				}
			}
			if (schema.Properties != null)
			{
				foreach (KeyValuePair<string, JsonSchema> item2 in Enumerable.ToList(schema.Properties))
				{
					schema.Properties[item2.Key] = ResolveReferences(item2.Value);
				}
			}
			if (schema.AdditionalProperties != null)
			{
				schema.AdditionalProperties = ResolveReferences(schema.AdditionalProperties);
			}
			return schema;
		}

		private JsonSchema BuildSchema(JToken token)
		{
			int num = 16;
			JObject jObject = token as JObject;
			if (jObject == null)
			{
				throw JsonException.Create(token, token.Path, StringUtils.FormatWith("Expected object while parsing schema object, got {0}.", CultureInfo.InvariantCulture, token.Type));
			}
			if (jObject.TryGetValue("$ref", out JToken value))
			{
				JsonSchema jsonSchema = new JsonSchema();
				jsonSchema.DeferredReference = (string)value;
				return jsonSchema;
			}
			string text = token.Path.Replace(".", "/").Replace("[", "/").Replace("]", string.Empty);
			if (!string.IsNullOrEmpty(text))
			{
				text = "/" + text;
			}
			text = "#" + text;
			if (_documentSchemas.TryGetValue(text, out JsonSchema value2))
			{
				return value2;
			}
			Push(new JsonSchema
			{
				Location = text
			});
			ProcessSchemaProperties(jObject);
			return Pop();
		}

		private void ProcessSchemaProperties(JObject schemaObject)
		{
			int num = 7;
			foreach (KeyValuePair<string, JToken> item in schemaObject)
			{
				switch (item.Key)
				{
				case "type":
					CurrentSchema.Type = ProcessType(item.Value);
					break;
				case "id":
					CurrentSchema.Id = (string)item.Value;
					break;
				case "title":
					CurrentSchema.Title = (string)item.Value;
					break;
				case "description":
					CurrentSchema.Description = (string)item.Value;
					break;
				case "properties":
					CurrentSchema.Properties = ProcessProperties(item.Value);
					break;
				case "items":
					ProcessItems(item.Value);
					break;
				case "additionalProperties":
					ProcessAdditionalProperties(item.Value);
					break;
				case "additionalItems":
					ProcessAdditionalItems(item.Value);
					break;
				case "patternProperties":
					CurrentSchema.PatternProperties = ProcessProperties(item.Value);
					break;
				case "required":
					CurrentSchema.Required = (bool)item.Value;
					break;
				case "requires":
					CurrentSchema.Requires = (string)item.Value;
					break;
				case "minimum":
					CurrentSchema.Minimum = (double)item.Value;
					break;
				case "maximum":
					CurrentSchema.Maximum = (double)item.Value;
					break;
				case "exclusiveMinimum":
					CurrentSchema.ExclusiveMinimum = (bool)item.Value;
					break;
				case "exclusiveMaximum":
					CurrentSchema.ExclusiveMaximum = (bool)item.Value;
					break;
				case "maxLength":
					CurrentSchema.MaximumLength = (int)item.Value;
					break;
				case "minLength":
					CurrentSchema.MinimumLength = (int)item.Value;
					break;
				case "maxItems":
					CurrentSchema.MaximumItems = (int)item.Value;
					break;
				case "minItems":
					CurrentSchema.MinimumItems = (int)item.Value;
					break;
				case "divisibleBy":
					CurrentSchema.DivisibleBy = (double)item.Value;
					break;
				case "disallow":
					CurrentSchema.Disallow = ProcessType(item.Value);
					break;
				case "default":
					CurrentSchema.Default = item.Value.DeepClone();
					break;
				case "hidden":
					CurrentSchema.Hidden = (bool)item.Value;
					break;
				case "readonly":
					CurrentSchema.ReadOnly = (bool)item.Value;
					break;
				case "format":
					CurrentSchema.Format = (string)item.Value;
					break;
				case "pattern":
					CurrentSchema.Pattern = (string)item.Value;
					break;
				case "enum":
					ProcessEnum(item.Value);
					break;
				case "extends":
					ProcessExtends(item.Value);
					break;
				case "uniqueItems":
					CurrentSchema.UniqueItems = (bool)item.Value;
					break;
				}
			}
		}

		private void ProcessExtends(JToken token)
		{
			IList<JsonSchema> list = new List<JsonSchema>();
			if (token.Type == JTokenType.Array)
			{
				foreach (JToken item in (IEnumerable<JToken>)token)
				{
					list.Add(BuildSchema(item));
				}
			}
			else
			{
				JsonSchema jsonSchema = BuildSchema(token);
				if (jsonSchema != null)
				{
					list.Add(jsonSchema);
				}
			}
			if (list.Count > 0)
			{
				CurrentSchema.Extends = list;
			}
		}

		private void ProcessEnum(JToken token)
		{
			int num = 4;
			if (token.Type != JTokenType.Array)
			{
				throw JsonException.Create(token, token.Path, StringUtils.FormatWith("Expected Array token while parsing enum values, got {0}.", CultureInfo.InvariantCulture, token.Type));
			}
			CurrentSchema.Enum = new List<JToken>();
			foreach (JToken item in (IEnumerable<JToken>)token)
			{
				CurrentSchema.Enum.Add(item.DeepClone());
			}
		}

		private void ProcessAdditionalProperties(JToken token)
		{
			if (token.Type == JTokenType.Boolean)
			{
				CurrentSchema.AllowAdditionalProperties = (bool)token;
			}
			else
			{
				CurrentSchema.AdditionalProperties = BuildSchema(token);
			}
		}

		private void ProcessAdditionalItems(JToken token)
		{
			if (token.Type == JTokenType.Boolean)
			{
				CurrentSchema.AllowAdditionalItems = (bool)token;
			}
			else
			{
				CurrentSchema.AdditionalItems = BuildSchema(token);
			}
		}

		private IDictionary<string, JsonSchema> ProcessProperties(JToken token)
		{
			int num = 13;
			IDictionary<string, JsonSchema> dictionary = new Dictionary<string, JsonSchema>();
			if (token.Type != JTokenType.Object)
			{
				throw JsonException.Create(token, token.Path, StringUtils.FormatWith("Expected Object token while parsing schema properties, got {0}.", CultureInfo.InvariantCulture, token.Type));
			}
			foreach (JProperty item in (IEnumerable<JToken>)token)
			{
				if (dictionary.ContainsKey(item.Name))
				{
					throw new JsonException(StringUtils.FormatWith("Property {0} has already been defined in schema.", CultureInfo.InvariantCulture, item.Name));
				}
				dictionary.Add(item.Name, BuildSchema(item.Value));
			}
			return dictionary;
		}

		private void ProcessItems(JToken token)
		{
			int num = 11;
			CurrentSchema.Items = new List<JsonSchema>();
			switch (token.Type)
			{
			default:
				throw JsonException.Create(token, token.Path, StringUtils.FormatWith("Expected array or JSON schema object, got {0}.", CultureInfo.InvariantCulture, token.Type));
			case JTokenType.Object:
				CurrentSchema.Items.Add(BuildSchema(token));
				CurrentSchema.PositionalItemsValidation = false;
				break;
			case JTokenType.Array:
				CurrentSchema.PositionalItemsValidation = true;
				foreach (JToken item in (IEnumerable<JToken>)token)
				{
					CurrentSchema.Items.Add(BuildSchema(item));
				}
				break;
			}
		}

		private JsonSchemaType? ProcessType(JToken token)
		{
			int num = 11;
			switch (token.Type)
			{
			default:
				throw JsonException.Create(token, token.Path, StringUtils.FormatWith("Expected array or JSON schema type string token, got {0}.", CultureInfo.InvariantCulture, token.Type));
			case JTokenType.String:
				return MapType((string)token);
			case JTokenType.Array:
			{
				JsonSchemaType? jsonSchemaType = JsonSchemaType.None;
				foreach (JToken item in (IEnumerable<JToken>)token)
				{
					if (item.Type != JTokenType.String)
					{
						throw JsonException.Create(item, item.Path, StringUtils.FormatWith("Exception JSON schema type string token, got {0}.", CultureInfo.InvariantCulture, token.Type));
					}
					jsonSchemaType |= MapType((string)item);
				}
				return jsonSchemaType;
			}
			}
		}

		internal static JsonSchemaType MapType(string type)
		{
			int num = 16;
			if (!JsonSchemaConstants.JsonSchemaTypeMapping.TryGetValue(type, out JsonSchemaType value))
			{
				throw new JsonException(StringUtils.FormatWith("Invalid JSON schema type: {0}", CultureInfo.InvariantCulture, type));
			}
			return value;
		}

		internal static string MapType(JsonSchemaType type)
		{
			return Enumerable.Single(JsonSchemaConstants.JsonSchemaTypeMapping, (KeyValuePair<string, JsonSchemaType> keyValuePair_0) => keyValuePair_0.Value == type).Key;
		}
	}
}
