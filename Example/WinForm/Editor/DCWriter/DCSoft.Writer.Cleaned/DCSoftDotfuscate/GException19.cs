using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException19 : ApplicationException
	{
		protected GException19(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
			: base(serializationInfo_0, streamingContext_0)
		{
		}

		public GException19()
		{
		}

		public GException19(string string_0)
			: base(string_0)
		{
		}

		public GException19(string string_0, Exception exception_0)
			: base(string_0, exception_0)
		{
		}
	}
}
