using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass574 : GInterface30
	{
		private GEnum100 genum100_0;

		protected GClass574(GEnum100 genum100_1)
		{
			genum100_0 = genum100_1;
		}

		public abstract Stream imethod_1();

		public abstract Stream imethod_2();

		public abstract Stream imethod_3(Stream stream_0);

		public abstract Stream imethod_4(Stream stream_0);

		public abstract void imethod_5();

		public GEnum100 imethod_0()
		{
			return genum100_0;
		}
	}
}
