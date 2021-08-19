using Open_Newtonsoft_Json.Utilities;
using System;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Schema
{
	/// <summary>
	///   <para>
	///       Returns detailed information related to the <see cref="T:Open_Newtonsoft_Json.Schema.ValidationEventHandler" />.
	///       </para>
	///   <note type="caution">
	///       JSON Schema validation has been moved to its own package. See <see href="http://www.newtonsoft.com/jsonschema">http://www.newtonsoft.com/jsonschema</see> for more details.
	///       </note>
	/// </summary>
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	[ComVisible(false)]
	public class ValidationEventArgs : EventArgs
	{
		private readonly JsonSchemaException _ex;

		/// <summary>
		///       Gets the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchemaException" /> associated with the validation error.
		///       </summary>
		/// <value>The JsonSchemaException associated with the validation error.</value>
		public JsonSchemaException Exception => _ex;

		/// <summary>
		///       Gets the path of the JSON location where the validation error occurred.
		///       </summary>
		/// <value>The path of the JSON location where the validation error occurred.</value>
		public string Path => _ex.Path;

		/// <summary>
		///       Gets the text description corresponding to the validation error.
		///       </summary>
		/// <value>The text description.</value>
		public string Message => _ex.Message;

		internal ValidationEventArgs(JsonSchemaException jsonSchemaException_0)
		{
			ValidationUtils.ArgumentNotNull(jsonSchemaException_0, "ex");
			_ex = jsonSchemaException_0;
		}
	}
}
