using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Open_Newtonsoft_Json.Schema
{
	/// <summary>
	///   <para>
	///       Returns detailed information about the schema exception.
	///       </para>
	///   <note type="caution">
	///       JSON Schema validation has been moved to its own package. See <see href="http://www.newtonsoft.com/jsonschema">http://www.newtonsoft.com/jsonschema</see> for more details.
	///       </note>
	/// </summary>
	[Serializable]
	[ComVisible(false)]
	[Obsolete("JSON Schema validation has been moved to its own package. See http://www.newtonsoft.com/jsonschema for more details.")]
	public class JsonSchemaException : JsonException
	{
		/// <summary>
		///       Gets the line number indicating where the error occurred.
		///       </summary>
		/// <value>The line number indicating where the error occurred.</value>
		public int LineNumber
		{
			get;
			private set;
		}

		/// <summary>
		///       Gets the line position indicating where the error occurred.
		///       </summary>
		/// <value>The line position indicating where the error occurred.</value>
		public int LinePosition
		{
			get;
			private set;
		}

		/// <summary>
		///       Gets the path to the JSON where the error occurred.
		///       </summary>
		/// <value>The path to the JSON where the error occurred.</value>
		public string Path
		{
			get;
			private set;
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchemaException" /> class.
		///       </summary>
		public JsonSchemaException()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchemaException" /> class
		///       with a specified error message.
		///       </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public JsonSchemaException(string message)
			: base(message)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchemaException" /> class
		///       with a specified error message and a reference to the inner exception that is the cause of this exception.
		///       </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public JsonSchemaException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.Schema.JsonSchemaException" /> class.
		///       </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info" /> parameter is null. </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
		public JsonSchemaException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		internal JsonSchemaException(string message, Exception innerException, string path, int lineNumber, int linePosition)
			: base(message, innerException)
		{
			Path = path;
			LineNumber = lineNumber;
			LinePosition = linePosition;
		}
	}
}
