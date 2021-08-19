using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	[ComVisible(false)]
	internal class JsonSchemaNode
	{
		public string Id
		{
			get;
			private set;
		}

		public ReadOnlyCollection<JsonSchema> Schemas
		{
			get;
			private set;
		}

		public Dictionary<string, JsonSchemaNode> Properties
		{
			get;
			private set;
		}

		public Dictionary<string, JsonSchemaNode> PatternProperties
		{
			get;
			private set;
		}

		public List<JsonSchemaNode> Items
		{
			get;
			private set;
		}

		public JsonSchemaNode AdditionalProperties
		{
			get;
			set;
		}

		public JsonSchemaNode AdditionalItems
		{
			get;
			set;
		}

		public JsonSchemaNode(JsonSchema schema)
		{
			Schemas = new ReadOnlyCollection<JsonSchema>(new JsonSchema[1]
			{
				schema
			});
			Properties = new Dictionary<string, JsonSchemaNode>();
			PatternProperties = new Dictionary<string, JsonSchemaNode>();
			Items = new List<JsonSchemaNode>();
			Id = GetId(Schemas);
		}

		private JsonSchemaNode(JsonSchemaNode source, JsonSchema schema)
		{
			Schemas = new ReadOnlyCollection<JsonSchema>(Enumerable.ToList(Enumerable.Union(source.Schemas, new JsonSchema[1]
			{
				schema
			})));
			Properties = new Dictionary<string, JsonSchemaNode>(source.Properties);
			PatternProperties = new Dictionary<string, JsonSchemaNode>(source.PatternProperties);
			Items = new List<JsonSchemaNode>(source.Items);
			AdditionalProperties = source.AdditionalProperties;
			AdditionalItems = source.AdditionalItems;
			Id = GetId(Schemas);
		}

		public JsonSchemaNode Combine(JsonSchema schema)
		{
			return new JsonSchemaNode(this, schema);
		}

		public static string GetId(IEnumerable<JsonSchema> schemata)
		{
			return string.Join("-", Enumerable.ToArray(Enumerable.OrderBy(Enumerable.Select(schemata, (JsonSchema jsonSchema_0) => jsonSchema_0.InternalId), (string string_0) => string_0, StringComparer.Ordinal)));
		}
	}
}
