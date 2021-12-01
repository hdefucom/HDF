using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass337
	{
		private byte[] byte_0 = new byte[0];

		private bool bool_0 = false;

		private string string_0 = "";

		private string string_1 = "";

		private bool bool_1 = false;

		private Encoding encoding_0 = Encoding.Default;

		private string string_2 = "";

		public byte[] method_0()
		{
			return byte_0;
		}

		public void method_1(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public string method_4()
		{
			return string_0;
		}

		public void method_5(string string_3)
		{
			string_0 = string_3;
		}

		public string method_6()
		{
			return string_1;
		}

		public void method_7(string string_3)
		{
			string_1 = string_3;
		}

		public bool method_8()
		{
			return bool_1;
		}

		public void method_9(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public Encoding method_10()
		{
			return encoding_0;
		}

		public void method_11(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public string method_12()
		{
			return string_2;
		}

		public void method_13(string string_3)
		{
			string_2 = string_3;
		}

		public override string ToString()
		{
			return method_10().GetString(byte_0);
		}
	}
}
