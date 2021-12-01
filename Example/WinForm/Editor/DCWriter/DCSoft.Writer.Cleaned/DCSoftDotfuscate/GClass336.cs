using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass336
	{
		private const string string_0 = "----=_NextPart_000_00";

		private Encoding encoding_0 = Encoding.Default;

		private string string_1 = null;

		private string string_2 = null;

		private List<GClass337> list_0 = new List<GClass337>();

		private string string_3 = null;

		private TextWriter textWriter_0 = null;

		public GClass336(TextWriter textWriter_1)
		{
			textWriter_0 = textWriter_1;
		}

		public Encoding method_0()
		{
			return encoding_0;
		}

		public void method_1(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public string method_2()
		{
			return string_1;
		}

		public void method_3(string string_4)
		{
			string_1 = string_4;
		}

		public string method_4()
		{
			return string_2;
		}

		public void method_5(string string_4)
		{
			string_2 = string_4;
		}

		public List<GClass337> method_6()
		{
			return list_0;
		}

		public void method_7(List<GClass337> list_1)
		{
			list_0 = list_1;
		}

		public string method_8()
		{
			return string_3;
		}

		public void method_9(string string_4)
		{
			string_3 = string_4;
		}

		public void method_10()
		{
			int num = 16;
			string str = "";
			if (!string.IsNullOrEmpty(method_2()))
			{
				str = "<Base Href=\"" + method_2() + "\">";
			}
			if (method_2() == null || !(method_2() != ""))
			{
			}
			str += method_8();
			GClass337 gClass = new GClass337();
			gClass.method_11(method_0());
			gClass.method_1(method_0().GetBytes(str));
			gClass.method_5("text/html");
			gClass.method_13(method_4());
			gClass.method_3(bool_2: false);
			gClass.method_7(method_2() + "dcosoft.html");
			method_11(gClass);
			foreach (GClass337 item in method_6())
			{
				method_17(item);
			}
			method_13();
		}

		private void method_11(GClass337 gclass337_0)
		{
			method_14("From:  Saved by DCSoft MHT Writer");
			method_14("Subject:" + gclass337_0.method_12());
			method_14("Date: " + method_12());
			method_14("MIME-Version: 1.0");
			method_14("Content-Type: multipart/related;");
			method_14(Convert.ToChar(9) + "type=\"text/html\";");
			method_14(Convert.ToChar(9) + "boundary=\"----=_NextPart_000_00\"");
			method_14("X-MimeOLE: Produced By DCSoft");
			method_15();
			method_14("This is a multi-part message in MIME format.");
			method_17(gclass337_0);
		}

		private string method_12()
		{
			DateTime now = DateTime.Now;
			return now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" + now.Minute + ":" + now.Second + " " + now.Millisecond;
		}

		private void method_13()
		{
			method_15();
			method_14("------=_NextPart_000_00--");
		}

		private void method_14(string string_4)
		{
			textWriter_0.Write(string_4);
			textWriter_0.WriteLine();
		}

		private void method_15()
		{
			method_14("");
		}

		private void method_16()
		{
			method_15();
			method_14("------=_NextPart_000_00");
		}

		private void method_17(GClass337 gclass337_0)
		{
			if (!gclass337_0.method_8())
			{
				if (gclass337_0.method_2())
				{
					method_19(gclass337_0);
				}
				else
				{
					method_18(gclass337_0);
				}
			}
			gclass337_0.method_9(bool_2: true);
		}

		private void method_18(GClass337 gclass337_0)
		{
			method_16();
			method_14("Content-Type: " + gclass337_0.method_4() + ";");
			method_14(Convert.ToChar(9) + "charset=\"" + gclass337_0.method_10().WebName + "\"");
			method_14("Content-Transfer-Encoding: quoted-printable");
			method_14("Content-Location: " + gclass337_0.method_6());
			method_15();
			method_14(method_20(gclass337_0.ToString(), gclass337_0.method_10()));
		}

		private void method_19(GClass337 gclass337_0)
		{
			method_16();
			method_14("Content-Type: " + gclass337_0.method_4());
			method_14("Content-Transfer-Encoding: base64");
			method_14("Content-Location: " + gclass337_0.method_6());
			method_15();
			int num = gclass337_0.method_0().Length;
			if (num <= 57)
			{
				method_14(Convert.ToBase64String(gclass337_0.method_0(), 0, num));
				return;
			}
			int i;
			for (i = 0; i + 57 < num; i += 57)
			{
				method_14(Convert.ToBase64String(gclass337_0.method_0(), i, 57));
			}
			if (i != num)
			{
				method_14(Convert.ToBase64String(gclass337_0.method_0(), i, num - i));
			}
		}

		private string method_20(string string_4, Encoding encoding_1)
		{
			int num = 2;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			StringBuilder stringBuilder = new StringBuilder();
			if (string_4 == null || string_4.Length == 0)
			{
				return "";
			}
			for (int i = 0; i < string_4.Length; i++)
			{
				char value = string_4[i];
				num2 = Convert.ToInt32(value);
				if (num2 == 61 || num2 > 126)
				{
					if (num2 <= 255)
					{
						stringBuilder.Append("=");
						stringBuilder.Append(Convert.ToString(num2, 16).ToUpper());
						num4 += 3;
					}
					else
					{
						byte[] bytes = encoding_1.GetBytes(value.ToString());
						foreach (byte value2 in bytes)
						{
							stringBuilder.Append("=");
							stringBuilder.Append(Convert.ToString(value2, 16).ToUpper());
							num4 += 3;
						}
					}
				}
				else
				{
					stringBuilder.Append(value);
					num4++;
					if (num2 == 32)
					{
						num3 = stringBuilder.Length;
					}
				}
				if (num4 >= 73)
				{
					if (num3 == 0)
					{
						stringBuilder.Insert(stringBuilder.Length, "=" + Environment.NewLine);
						num4 = 0;
					}
					else
					{
						stringBuilder.Insert(num3, "=" + Environment.NewLine);
						num4 = stringBuilder.Length - num3 - 1;
					}
					num5++;
					num3 = 0;
				}
			}
			if (num5 > 0 && stringBuilder[stringBuilder.Length - 1] == ' ')
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("=20");
			}
			return stringBuilder.ToString();
		}
	}
}
