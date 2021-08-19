using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Schema
{
	/// <summary>
	///   <para>
	///       Specifies undefined schema Id handling options for the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchemaGenerator" />.
	///       </para>
	///   <note type="caution">
	///       JSON Schema validation has been moved to its own package. See <see href="http://www.newtonsoft.com/jsonschema">http://www.newtonsoft.com/jsonschema</see> for more details.
	///       </note>
	/// </summary>
	[ComVisible(false)]
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	public enum UndefinedSchemaIdHandling
	{
		/// <summary>
		///       Do not infer a schema Id.
		///       </summary>
		None,
		/// <summary>
		///       Use the .NET type name as the schema Id.
		///       </summary>
		UseTypeName,
		/// <summary>
		///       Use the assembly qualified .NET type name as the schema Id.
		///       </summary>
		UseAssemblyQualifiedName
	}
}
