using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class91 : Class84
	{
		public Class91(string string_2)
		{
			string_0 = string_2;
		}

		private string method_1()
		{
			string_1 = null;
			if (!string_0.StartsWith("49") || !method_0(string_0))
			{
				string_1 = BarcodeStrings.JAN13InvaliData;
				return null;
			}
			Class89 @class = new Class89(string_0);
			string result = @class.vmethod_0();
			string_1 = @class.string_1;
			return result;
		}

		public override string vmethod_0()
		{
			return method_1();
		}
	}
}
