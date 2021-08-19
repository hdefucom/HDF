using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Serialization
{
	[ComVisible(false)]
	internal abstract class JsonSerializerInternalBase
	{
		[ComVisible(false)]
		private class ReferenceEqualsEqualityComparer : IEqualityComparer<object>
		{
			bool IEqualityComparer<object>.Equals(object object_0, object object_1)
			{
				return object.ReferenceEquals(object_0, object_1);
			}

			int IEqualityComparer<object>.GetHashCode(object object_0)
			{
				return RuntimeHelpers.GetHashCode(object_0);
			}
		}

		private ErrorContext _currentErrorContext;

		private BidirectionalDictionary<string, object> _mappings;

		internal readonly JsonSerializer Serializer;

		internal readonly ITraceWriter TraceWriter;

		protected JsonSerializerProxy InternalSerializer;

		internal BidirectionalDictionary<string, object> DefaultReferenceMappings
		{
			get
			{
				int num = 12;
				if (_mappings == null)
				{
					_mappings = new BidirectionalDictionary<string, object>(EqualityComparer<string>.Default, new ReferenceEqualsEqualityComparer(), "A different value already has the Id '{0}'.", "A different Id has already been assigned for value '{0}'.");
				}
				return _mappings;
			}
		}

		protected JsonSerializerInternalBase(JsonSerializer serializer)
		{
			ValidationUtils.ArgumentNotNull(serializer, "serializer");
			Serializer = serializer;
			TraceWriter = serializer.TraceWriter;
		}

		private ErrorContext GetErrorContext(object currentObject, object member, string path, Exception error)
		{
			int num = 9;
			if (_currentErrorContext == null)
			{
				_currentErrorContext = new ErrorContext(currentObject, member, path, error);
			}
			if (_currentErrorContext.Error != error)
			{
				throw new InvalidOperationException("Current error context error is different to requested error.");
			}
			return _currentErrorContext;
		}

		protected void ClearErrorContext()
		{
			int num = 16;
			if (_currentErrorContext == null)
			{
				throw new InvalidOperationException("Could not clear error context. Error context is already null.");
			}
			_currentErrorContext = null;
		}

		protected bool IsErrorHandled(object currentObject, JsonContract contract, object keyValue, IJsonLineInfo lineInfo, string path, Exception exception_0)
		{
			int num = 15;
			ErrorContext errorContext = GetErrorContext(currentObject, keyValue, path, exception_0);
			if (TraceWriter != null && TraceWriter.LevelFilter >= TraceLevel.Error && !errorContext.Traced)
			{
				errorContext.Traced = true;
				string text = (GetType() == typeof(JsonSerializerInternalWriter)) ? "Error serializing" : "Error deserializing";
				if (contract != null)
				{
					text = text + " " + contract.UnderlyingType;
				}
				text = text + ". " + exception_0.Message;
				if (!(exception_0 is JsonException))
				{
					text = JsonPosition.FormatMessage(lineInfo, path, text);
				}
				TraceWriter.Trace(TraceLevel.Error, text, exception_0);
			}
			if (contract != null && currentObject != null)
			{
				contract.InvokeOnError(currentObject, Serializer.Context, errorContext);
			}
			if (!errorContext.Handled)
			{
				Serializer.OnError(new ErrorEventArgs(currentObject, errorContext));
			}
			return errorContext.Handled;
		}
	}
}
