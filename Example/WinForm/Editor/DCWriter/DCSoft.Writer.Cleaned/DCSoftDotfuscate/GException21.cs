using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException21 : GException20
	{
		protected GException21(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
			: base(serializationInfo_0, streamingContext_0)
		{
		}

		public GException21()
		{
		}

		public GException21(string string_0)
			: base(string_0)
		{
		}

		public GException21(string string_0, Exception exception_0)
			: base(string_0, exception_0)
		{
		}
	}
}
