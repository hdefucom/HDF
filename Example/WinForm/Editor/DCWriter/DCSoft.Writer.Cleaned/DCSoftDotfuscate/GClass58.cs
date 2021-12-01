using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass58 : GClass55
	{
		private string string_0;

		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public GClass58(string string_1)
		{
			string_0 = string_1;
		}

		public override void vmethod_0(GClass75 gclass75_0)
		{
			gclass75_0.vmethod_5(this);
		}

		public override string ToString()
		{
			return "Parameter:" + string_0;
		}
	}
}
