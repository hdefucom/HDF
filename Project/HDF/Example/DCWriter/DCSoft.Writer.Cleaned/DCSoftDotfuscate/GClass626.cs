using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass626 : GClass620
	{
		private string string_0;

		private double double_0;

		private double double_1;

		private double double_2;

		public string method_0()
		{
			return string_0;
		}

		public double method_1()
		{
			return double_0;
		}

		public double method_2()
		{
			return double_1;
		}

		public double method_3()
		{
			return double_2;
		}

		public override string vmethod_1()
		{
			int num = 11;
			StringBuilder stringBuilder = new StringBuilder(50);
			stringBuilder.Append(double_0);
			stringBuilder.Append(", ");
			stringBuilder.Append(double_1);
			if (double_2 > 0.0)
			{
				stringBuilder.Append(", ");
				stringBuilder.Append(double_2);
				stringBuilder.Append('m');
			}
			return stringBuilder.ToString();
		}

		internal GClass626(string string_1, double double_3, double double_4, double double_5)
			: base(GClass660.gclass660_6)
		{
			string_0 = string_1;
			double_0 = double_3;
			double_1 = double_4;
			double_2 = double_5;
		}
	}
}
