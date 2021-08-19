using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass508 : GClass504
	{
		private double double_0 = 0.0;

		public GClass508(double double_1)
		{
			double_0 = double_1;
		}

		public double method_8()
		{
			return double_0;
		}

		public void method_9(double double_1)
		{
			double_0 = double_1;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			streamWriter_0.Write(double_0);
		}

		public override string ToString()
		{
			return "Double:" + method_8();
		}
	}
}
