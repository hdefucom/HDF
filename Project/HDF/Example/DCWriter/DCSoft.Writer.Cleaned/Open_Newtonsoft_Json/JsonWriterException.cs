using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Open_Newtonsoft_Json
{
	/// <summary>
	///       The exception thrown when an error occurs while reading JSON text.
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class JsonWriterException : JsonException
	{
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
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonWriterException" /> class.
		///       </summary>
		public JsonWriterException()
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonWriterException" /> class
		///       with a specified error message.
		///       </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public JsonWriterException(string message)
			: base(message)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonWriterException" /> class
		///       with a specified error message and a reference to the inner exception that is the cause of this exception.
		///       </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public JsonWriterException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		///       Initializes a new instance of the <see cref="T:Open_Newtonsoft_Json.JsonWriterException" /> class.
		///       </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info" /> parameter is null. </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
		public JsonWriterException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		internal JsonWriterException(string message, Exception innerException, string path)
			: base(message, innerException)
		{
			Path = path;
		}

		internal static JsonWriterException Create(JsonWriter writer, string message, Exception exception_0)
		{
			return Create(writer.ContainerPath, message, exception_0);
		}

		internal static JsonWriterException Create(string path, string message, Exception exception_0)
		{
			message = JsonPosition.FormatMessage(null, path, message);
			return new JsonWriterException(message, exception_0, path);
		}
	}
}
