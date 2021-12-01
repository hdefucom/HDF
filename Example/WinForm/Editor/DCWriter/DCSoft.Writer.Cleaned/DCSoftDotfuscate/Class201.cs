using DCSoft.RTF;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class201
	{
		private GClass413 gclass413_0 = new GClass413();

		private GClass386 gclass386_0 = null;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		private int int_0 = 0;

		public Class201(GClass386 gclass386_1)
		{
			gclass386_0 = gclass386_1;
		}

		public GClass386 method_0()
		{
			return gclass386_0;
		}

		public void method_1(GClass386 gclass386_1)
		{
			gclass386_0 = gclass386_1;
		}

		public void method_2(string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				method_9();
				stringBuilder_0.Append(string_0);
			}
		}

		public bool method_3(GClass412 gclass412_0, GClass410 gclass410_0)
		{
			int num = 5;
			if (gclass412_0 == null)
			{
				return false;
			}
			if (gclass412_0.method_0() == RTFTokenType.Text)
			{
				if (gclass410_0 != null && gclass412_0.method_2()[0] == '?' && gclass410_0.method_14() != null && gclass410_0.method_14().method_0() == RTFTokenType.Keyword && gclass410_0.method_14().method_2() == "u" && gclass410_0.method_14().method_4())
				{
					if (gclass412_0.method_2().Length > 0)
					{
						gclass410_0.method_21().method_3(0);
						method_9();
						if (gclass412_0.method_2().Length > 1)
						{
							stringBuilder_0.Append(gclass412_0.method_2().Substring(1));
						}
					}
					return true;
				}
				method_9();
				stringBuilder_0.Append(gclass412_0.method_2());
				return true;
			}
			if (gclass412_0.method_0() == RTFTokenType.Control && gclass412_0.method_2() == "'" && gclass412_0.method_4())
			{
				if (gclass410_0.method_21().method_4())
				{
					gclass413_0.method_3((byte)gclass412_0.method_6());
				}
				return true;
			}
			if (gclass412_0.method_2() == "u" && gclass412_0.method_4())
			{
				method_9();
				stringBuilder_0.Append((char)gclass412_0.method_6());
				gclass410_0.method_21().method_3(gclass410_0.method_21().method_0());
				return true;
			}
			if (gclass412_0.method_2() == "tab")
			{
				method_9();
				stringBuilder_0.Append("\t");
				return true;
			}
			if (gclass412_0.method_2() == "emdash")
			{
				method_9();
				stringBuilder_0.Append('—');
				return true;
			}
			if (gclass412_0.method_2() == "")
			{
				method_9();
				stringBuilder_0.Append('-');
				return true;
			}
			return false;
		}

		public bool method_4()
		{
			method_9();
			return stringBuilder_0.Length > 0;
		}

		public string method_5()
		{
			method_9();
			return stringBuilder_0.ToString();
		}

		public int method_6()
		{
			return int_0;
		}

		public void method_7(int int_1)
		{
			int_0 = int_1;
		}

		public void method_8()
		{
			gclass413_0.vmethod_0();
			stringBuilder_0 = new StringBuilder();
		}

		private void method_9()
		{
			if (gclass413_0.vmethod_1() > 0)
			{
				Encoding encoding_ = gclass386_0.method_23();
				string value = gclass413_0.method_7(encoding_);
				stringBuilder_0.Append(value);
				gclass413_0.vmethod_0();
			}
		}
	}
}
