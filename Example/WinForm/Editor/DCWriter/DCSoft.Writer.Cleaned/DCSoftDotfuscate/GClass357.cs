using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass357
	{
		private string string_0 = Guid.NewGuid().ToString("N");

		private string string_1 = null;

		private Encoding encoding_0 = Encoding.Default;

		private bool bool_0 = true;

		private string string_2 = null;

		private byte[] byte_0 = null;

		[NonSerialized]
		private object object_0 = null;

		[NonSerialized]
		private object object_1 = null;

		public string Name
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_3)
		{
			string_0 = string_3;
		}

		public Encoding method_2()
		{
			return encoding_0;
		}

		public void method_3(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public string method_6()
		{
			return string_2;
		}

		public void method_7(string string_3)
		{
			string_2 = string_3;
		}

		public byte[] method_8()
		{
			return byte_0;
		}

		public void method_9(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		public object method_10()
		{
			return object_0;
		}

		public void method_11(object object_2)
		{
			object_0 = object_2;
		}

		public object method_12()
		{
			return object_1;
		}

		public void method_13(object object_2)
		{
			object_1 = object_2;
		}
	}
}
