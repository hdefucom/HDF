using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Schema
{
	/// <summary>
	///   <para>
	///       The value types allowed by the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchema" />.
	///       </para>
	///   <note type="caution">
	///       JSON Schema validation has been moved to its own package. See <see href="http://www.newtonsoft.com/jsonschema">http://www.newtonsoft.com/jsonschema</see> for more details.
	///       </note>
	/// </summary>
	[Flags]
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	[ComVisible(false)]
	public enum JsonSchemaType
	{
		/// <summary>
		///       No type specified.
		///       </summary>
		None = 0x0,
		/// <summary>
		///       String type.
		///       </summary>
		String = 0x1,
		/// <summary>
		///       Float type.
		///       </summary>
		Float = 0x2,
		/// <summary>
		///       Integer type.
		///       </summary>
		Integer = 0x4,
		/// <summary>
		///       Boolean type.
		///       </summary>
		Boolean = 0x8,
		/// <summary>
		///       Object type.
		///       </summary>
		Object = 0x10,
		/// <summary>
		///       Array type.
		///       </summary>
		Array = 0x20,
		/// <summary>
		///       Null type.
		///       </summary>
		Null = 0x40,
		/// <summary>
		///       Any type.
		///       </summary>
		Any = 0x7F
	}
}
