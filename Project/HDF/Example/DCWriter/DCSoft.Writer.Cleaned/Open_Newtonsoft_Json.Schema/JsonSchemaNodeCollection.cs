using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Schema
{
	[ComVisible(false)]
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	internal class JsonSchemaNodeCollection : KeyedCollection<string, JsonSchemaNode>
	{
		protected override string GetKeyForItem(JsonSchemaNode item)
		{
			return item.Id;
		}
	}
}
