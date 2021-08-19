using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs16 : GEventArgs15
	{
		private bool bool_1;

		public GEventArgs16(string string_1, bool bool_2)
			: base(string_1)
		{
			bool_1 = bool_2;
		}

		public bool method_2()
		{
			return bool_1;
		}
	}
}
