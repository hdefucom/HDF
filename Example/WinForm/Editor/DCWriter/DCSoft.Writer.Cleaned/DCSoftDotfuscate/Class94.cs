using DCSoft.Barcode;

namespace DCSoftDotfuscate
{
	internal class Class94 : Class84
	{
		public Class94(string string_2)
		{
			string_0 = string_2;
		}

		private string method_1()
		{
			int num = 2;
			string_1 = null;
			if (!method_0(string_0))
			{
				string_1 = BarcodeStrings.ISBNInvaliData;
				return null;
			}
			if (string_0.Length == 10 || string_0.Length == 9)
			{
				if (string_0.Length == 10)
				{
					string_0 = string_0.Remove(9, 1);
				}
				string_0 = "978" + string_0;
			}
			else if (string_0.Length != 12 || !string_0.StartsWith("978"))
			{
				if (string_0.Length != 13 || !string_0.StartsWith("978"))
				{
					string_1 = BarcodeStrings.ISBNInvaliData;
					return null;
				}
				string_0 = string_0.Remove(12, 1);
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
