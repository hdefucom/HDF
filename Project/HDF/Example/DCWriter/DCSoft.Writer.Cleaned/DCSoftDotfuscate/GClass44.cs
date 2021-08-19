using System;
using System.Runtime.InteropServices;
using System.Web;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass44
	{
		private string string_0;

		public GClass44(HttpRequest httpRequest_0)
		{
			int num = 7;
			string_0 = null;
			
			if (httpRequest_0 == null)
			{
				throw new ArgumentNullException("request");
			}
			string_0 = httpRequest_0.UserAgent;
		}

		public string method_0()
		{
			return string_0;
		}
	}
}
