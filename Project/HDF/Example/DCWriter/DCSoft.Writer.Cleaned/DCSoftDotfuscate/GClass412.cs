using DCSoft.RTF;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass412
	{
		private RTFTokenType rtftokenType_0 = RTFTokenType.None;

		private string string_0 = null;

		private bool bool_0 = false;

		private int int_0 = 0;

		private GClass412 gclass412_0 = null;

		public RTFTokenType method_0()
		{
			return rtftokenType_0;
		}

		public void method_1(RTFTokenType rtftokenType_1)
		{
			rtftokenType_0 = rtftokenType_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public int method_6()
		{
			return int_0;
		}

		public void method_7(int int_1)
		{
			int_0 = int_1;
		}

		public GClass412 method_8()
		{
			return gclass412_0;
		}

		public void method_9(GClass412 gclass412_1)
		{
			gclass412_0 = gclass412_1;
		}

		public bool method_10()
		{
			int num = 18;
			if (rtftokenType_0 == RTFTokenType.Text)
			{
				return true;
			}
			if (rtftokenType_0 == RTFTokenType.Control && string_0 == "'" && bool_0)
			{
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			int num = 8;
			if (rtftokenType_0 == RTFTokenType.Keyword)
			{
				return method_2() + method_6();
			}
			if (rtftokenType_0 == RTFTokenType.GroupStart)
			{
				return "{";
			}
			if (rtftokenType_0 == RTFTokenType.GroupEnd)
			{
				return "}";
			}
			if (rtftokenType_0 == RTFTokenType.Text)
			{
				return "Text:" + method_6();
			}
			return rtftokenType_0.ToString() + ":" + method_2() + " " + method_6();
		}
	}
}
