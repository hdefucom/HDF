using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GException24 : GException19
	{
		protected GException24(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
			: base(serializationInfo_0, streamingContext_0)
		{
		}

		public GException24()
		{
		}

		public GException24(string string_0)
			: base(string_0)
		{
		}

		public GException24(string string_0, Exception exception_0)
			: base(string_0, exception_0)
		{
		}
	}
}
