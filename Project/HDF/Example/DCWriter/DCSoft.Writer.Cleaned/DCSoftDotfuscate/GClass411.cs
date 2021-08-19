using DCSoft.RTF;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass411
	{
		private const int int_0 = -1;

		private TextReader textReader_0 = null;

		public GClass411(TextReader textReader_1)
		{
			textReader_0 = textReader_1;
		}

		public RTFTokenType method_0()
		{
			int num = textReader_0.Peek();
			while (num == 13 || num == 10 || num == 9 || num == 0)
			{
				num = textReader_0.Read();
				num = textReader_0.Peek();
			}
			if (num == -1)
			{
				return RTFTokenType.Eof;
			}
			switch (num)
			{
			case 123:
				return RTFTokenType.GroupStart;
			default:
				return RTFTokenType.Text;
			case 125:
				return RTFTokenType.GroupEnd;
			case 92:
				return RTFTokenType.Control;
			}
		}

		public GClass412 method_1()
		{
			int num = 10;
			int num2 = 0;
			GClass412 gClass = new GClass412();
			num2 = textReader_0.Read();
			if (num2 == 34)
			{
				gClass.method_1(RTFTokenType.Text);
				gClass.method_3("\"");
				return gClass;
			}
			while (num2 == 13 || num2 == 10 || num2 == 9 || num2 == 0)
			{
				num2 = textReader_0.Read();
			}
			if (num2 != -1)
			{
				switch (num2)
				{
				case 123:
					gClass.method_1(RTFTokenType.GroupStart);
					break;
				default:
					gClass.method_1(RTFTokenType.Text);
					method_3(num2, gClass);
					break;
				case 125:
					gClass.method_1(RTFTokenType.GroupEnd);
					break;
				case 92:
					method_2(gClass);
					break;
				}
			}
			else
			{
				gClass.method_1(RTFTokenType.Eof);
			}
			return gClass;
		}

		private void method_2(GClass412 gclass412_0)
		{
			int num = 2;
			int num2 = 0;
			bool flag = false;
			num2 = textReader_0.Peek();
			if (!char.IsLetter((char)num2))
			{
				textReader_0.Read();
				if (num2 != 42)
				{
					if (num2 == 92 || num2 == 123 || num2 == 125)
					{
						gclass412_0.method_1(RTFTokenType.Text);
						gclass412_0.method_3(((char)num2).ToString());
						return;
					}
					gclass412_0.method_1(RTFTokenType.Control);
					gclass412_0.method_3(((char)num2).ToString());
					if (gclass412_0.method_2() == "'")
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append((char)textReader_0.Read());
						stringBuilder.Append((char)textReader_0.Read());
						gclass412_0.method_5(bool_1: true);
						gclass412_0.method_7(Convert.ToInt32(stringBuilder.ToString().ToLower(), 16));
						if (gclass412_0.method_6() == 0)
						{
							gclass412_0.method_7(0);
						}
					}
					return;
				}
				gclass412_0.method_1(RTFTokenType.Keyword);
				textReader_0.Read();
				flag = true;
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			num2 = textReader_0.Peek();
			while (char.IsLetter((char)num2))
			{
				textReader_0.Read();
				stringBuilder2.Append((char)num2);
				num2 = textReader_0.Peek();
			}
			if (flag)
			{
				gclass412_0.method_1(RTFTokenType.ExtKeyword);
			}
			else
			{
				gclass412_0.method_1(RTFTokenType.Keyword);
			}
			gclass412_0.method_3(stringBuilder2.ToString());
			if (char.IsDigit((char)num2) || num2 == 45)
			{
				gclass412_0.method_5(bool_1: true);
				bool flag2 = false;
				if (num2 == 45)
				{
					flag2 = true;
					textReader_0.Read();
				}
				num2 = textReader_0.Peek();
				StringBuilder stringBuilder = new StringBuilder();
				while (char.IsDigit((char)num2))
				{
					textReader_0.Read();
					stringBuilder.Append((char)num2);
					num2 = textReader_0.Peek();
				}
				int num3 = Convert.ToInt32(stringBuilder.ToString());
				if (flag2)
				{
					num3 = -num3;
				}
				gclass412_0.method_7(num3);
			}
			if (num2 == 32)
			{
				textReader_0.Read();
			}
		}

		private void method_3(int int_1, GClass412 gclass412_0)
		{
			StringBuilder stringBuilder = new StringBuilder(((char)int_1).ToString());
			int_1 = method_4();
			while (int_1 != 92 && int_1 != 125 && int_1 != 123 && int_1 != -1)
			{
				textReader_0.Read();
				stringBuilder.Append((char)int_1);
				int_1 = method_4();
			}
			gclass412_0.method_3(stringBuilder.ToString());
		}

		private int method_4()
		{
			int num = textReader_0.Peek();
			while (num == 13 || num == 10 || num == 9 || num == 0)
			{
				textReader_0.Read();
				num = textReader_0.Peek();
			}
			return num;
		}
	}
}
