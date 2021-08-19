using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Schema
{
	/// <summary>
	///   <para>
	///       Represents the callback method that will handle JSON schema validation events and the <see cref="T:Open_Newtonsoft_Json.Schema.ValidationEventArgs" />.
	///       </para>
	///   <note type="caution">
	///       JSON Schema validation has been moved to its own package. See <see href="http://www.newtonsoft.com/jsonschema">http://www.newtonsoft.com/jsonschema</see> for more details.
	///       </note>
	/// </summary>
	[ComVisible(false)]
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	public delegate void ValidationEventHandler(object sender, ValidationEventArgs e);
}
