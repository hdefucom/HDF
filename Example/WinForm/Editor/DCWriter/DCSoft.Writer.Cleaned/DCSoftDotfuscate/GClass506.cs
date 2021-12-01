using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass506 : GClass504
	{
		private bool bool_0 = false;

		public GClass506(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public bool method_8()
		{
			return bool_0;
		}

		public void method_9(bool bool_1)
		{
			bool_0 = bool_1;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			int num = 3;
			if (bool_0)
			{
				streamWriter_0.Write("true");
			}
			else
			{
				streamWriter_0.Write("false");
			}
		}

		public override string ToString()
		{
			return "Boolean:" + method_8();
		}
	}
}
