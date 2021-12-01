using DCSoft.RTF;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass414 : IDisposable
	{
		private const string string_0 = "0123456789abcdef";

		private Encoding encoding_0 = Encoding.Default;

		private TextWriter textWriter_0 = null;

		private bool bool_0 = false;

		private string string_1 = "   ";

		private int int_0 = 0;

		private Encoding encoding_1 = Encoding.Unicode;

		private int int_1 = 0;

		private int int_2 = 0;

		internal static void smethod_0()
		{
			GClass414 gClass = new GClass414("c:\\a.rtf");
			smethod_2(gClass);
			gClass.method_7();
			MessageBox.Show("OK , you can open file c:\\a.rtf 了.");
		}

		internal static void smethod_1()
		{
			StringWriter stringWriter = new StringWriter();
			GClass414 gClass = new GClass414(stringWriter);
			smethod_2(gClass);
			gClass.method_7();
			DataObject dataObject = new DataObject();
			dataObject.SetData(DataFormats.Rtf, stringWriter.ToString());
			Clipboard.SetDataObject(dataObject, copy: true);
			MessageBox.Show("OK, you can paste words in MS Word.");
		}

		private static void smethod_2(GClass414 gclass414_0)
		{
			gclass414_0.method_1(Encoding.GetEncoding(936));
			gclass414_0.method_10();
			gclass414_0.method_13("rtf1");
			gclass414_0.method_13("ansi");
			gclass414_0.method_13("ansicpg" + gclass414_0.method_0().CodePage);
			gclass414_0.method_10();
			gclass414_0.method_13("fonttbl");
			gclass414_0.method_10();
			gclass414_0.method_13("f0");
			gclass414_0.method_15("Arial;");
			gclass414_0.method_11();
			gclass414_0.method_10();
			gclass414_0.method_13("f1");
			gclass414_0.method_15("Times New Roman;");
			gclass414_0.method_11();
			gclass414_0.method_11();
			gclass414_0.method_10();
			gclass414_0.method_13("colortbl");
			gclass414_0.method_15(";");
			gclass414_0.method_13("red0");
			gclass414_0.method_13("green0");
			gclass414_0.method_13("blue255");
			gclass414_0.method_15(";");
			gclass414_0.method_11();
			gclass414_0.method_13("qc");
			gclass414_0.method_13("f0");
			gclass414_0.method_13("fs30");
			gclass414_0.method_15("This is the first paragraph text ");
			gclass414_0.method_13("cf1");
			gclass414_0.method_15("Arial ");
			gclass414_0.method_13("cf0");
			gclass414_0.method_13("f1");
			gclass414_0.method_15("Align center ABC12345");
			gclass414_0.method_13("par");
			gclass414_0.method_13("pard");
			gclass414_0.method_13("f1");
			gclass414_0.method_13("fs20");
			gclass414_0.method_13("cf1");
			gclass414_0.method_15("This is the secend paragraph Arial left alignment ABC12345");
			gclass414_0.method_11();
		}

		public GClass414(TextWriter textWriter_1)
		{
			textWriter_0 = textWriter_1;
		}

		public GClass414(string string_2)
		{
			textWriter_0 = new StreamWriter(string_2, append: false, Encoding.ASCII);
		}

		public Encoding method_0()
		{
			return encoding_0;
		}

		public void method_1(Encoding encoding_2)
		{
			encoding_0 = encoding_2;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public string method_4()
		{
			return string_1;
		}

		public void method_5(string string_2)
		{
			string_1 = string_2;
		}

		public int method_6()
		{
			return int_0;
		}

		public void method_7()
		{
			if (int_0 > 0)
			{
				throw new Exception(RTFResource.GroupNotFinish);
			}
			if (textWriter_0 != null)
			{
				textWriter_0.Close();
				textWriter_0 = null;
			}
		}

		public void method_8()
		{
			if (textWriter_0 != null)
			{
				textWriter_0.Flush();
			}
		}

		public void method_9(string string_2)
		{
			method_10();
			method_13(string_2);
			method_11();
		}

		public void method_10()
		{
			int num = 18;
			if (bool_0)
			{
				method_24();
				textWriter_0.Write("{");
			}
			else
			{
				textWriter_0.Write("{");
			}
			int_0++;
		}

		public void method_11()
		{
			int num = 8;
			int_0--;
			if (int_0 < 0)
			{
				throw new Exception(RTFResource.GroupLevelError);
			}
			if (bool_0)
			{
				method_24();
				method_22("}");
			}
			else
			{
				method_22("}");
			}
		}

		public void method_12(string string_2)
		{
			if (string_2 != null && string_2.Length > 0)
			{
				method_22(string_2);
			}
		}

		public void method_13(string string_2)
		{
			method_14(string_2, bool_1: false);
		}

		public void method_14(string string_2, bool bool_1)
		{
			int num = 3;
			if (string_2 == null || string_2.Length == 0)
			{
				throw new ArgumentNullException("keyword");
			}
			if (!bool_0 && (string_2 == "par" || string_2 == "pard"))
			{
				method_22(Environment.NewLine);
			}
			if (bool_0 && (string_2 == "par" || string_2 == "pard"))
			{
				method_24();
			}
			if (bool_1)
			{
				method_22("\\*\\");
			}
			else
			{
				method_22("\\");
			}
			method_22(string_2);
		}

		public void method_15(string string_2)
		{
			if (string_2 != null && string_2.Length != 0)
			{
				method_17(string_2, bool_1: true);
			}
		}

		public void method_16(string string_2)
		{
			int num = 19;
			if (string.IsNullOrEmpty(string_2))
			{
				return;
			}
			method_13("uc1");
			foreach (char c in string_2)
			{
				if (c > '\u007f')
				{
					int num2 = c;
					method_13("u" + (short)num2);
					method_12(" ?");
				}
				else
				{
					method_18(c);
				}
			}
		}

		public void method_17(string string_2, bool bool_1)
		{
			if (string_2 != null && string_2.Length != 0)
			{
				if (bool_1)
				{
					method_21(' ');
				}
				foreach (char char_ in string_2)
				{
					method_18(char_);
				}
			}
		}

		private void method_18(char char_0)
		{
			int num = 6;
			if (char_0 == '\t')
			{
				method_13("tab");
				method_21(' ');
				return;
			}
			if (char_0 > ' ' && char_0 < '\u007f')
			{
				if (char_0 == '\\' || char_0 == '{' || char_0 == '}')
				{
					method_21('\\');
				}
				method_21(char_0);
				return;
			}
			byte[] bytes = encoding_0.GetBytes(char_0.ToString());
			if (bytes.Length == 1 && bytes[0] == 63 && char_0 != '?')
			{
				method_13("u" + Convert.ToString((int)char_0));
				method_12(" ?");
				return;
			}
			for (int i = 0; i < bytes.Length; i++)
			{
				method_22("\\'");
				method_20(bytes[i]);
			}
		}

		public static string smethod_3(string string_2)
		{
			int num = 12;
			if (string.IsNullOrEmpty(string_2))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < string_2.Length; i++)
			{
				char c = string_2[i];
				if (c == '\t')
				{
					stringBuilder.Append("\\'20\\'20\\'20\\'20");
					continue;
				}
				if (c > ' ' && c < '\u007f')
				{
					if (c == '\\' || c == '{' || c == '}')
					{
						stringBuilder.Append('\\');
					}
					stringBuilder.Append(c);
					continue;
				}
				byte[] bytes = Encoding.Default.GetBytes(c.ToString());
				for (int j = 0; j < bytes.Length; j++)
				{
					stringBuilder.Append("\\'");
					byte b = bytes[j];
					int index = (b & 0xF0) >> 4;
					int index2 = b & 0xF;
					stringBuilder.Append("0123456789abcdef"[index]);
					stringBuilder.Append("0123456789abcdef"[index2]);
				}
			}
			return stringBuilder.ToString();
		}

		public void method_19(byte[] byte_0)
		{
			int num = 18;
			if (byte_0 == null || byte_0.Length == 0)
			{
				return;
			}
			method_12(" ");
			for (int i = 0; i < byte_0.Length; i++)
			{
				if (i % 32 == 0)
				{
					method_12(Environment.NewLine);
					method_25();
				}
				else if (i % 8 == 0)
				{
					method_12(" ");
				}
				byte b = byte_0[i];
				int index = (b & 0xF0) >> 4;
				int index2 = b & 0xF;
				textWriter_0.Write("0123456789abcdef"[index]);
				textWriter_0.Write("0123456789abcdef"[index2]);
				int_1 += 2;
			}
		}

		public void method_20(byte byte_0)
		{
			int index = (byte_0 & 0xF0) >> 4;
			int index2 = byte_0 & 0xF;
			textWriter_0.Write("0123456789abcdef"[index]);
			textWriter_0.Write("0123456789abcdef"[index2]);
			int_1 += 2;
		}

		private void method_21(char char_0)
		{
			int_1++;
			textWriter_0.Write(char_0);
		}

		private void method_22(string string_2)
		{
			int_1 += string_2.Length;
			textWriter_0.Write(string_2);
		}

		private void method_23()
		{
			if (bool_0 && int_1 - int_2 > 100)
			{
				method_24();
			}
		}

		private void method_24()
		{
			if (bool_0 && int_1 > 0)
			{
				method_22(Environment.NewLine);
				int_2 = int_1;
				method_25();
			}
		}

		private void method_25()
		{
			if (bool_0)
			{
				for (int i = 0; i < int_0; i++)
				{
					method_22(string_1);
				}
			}
		}

		public void Dispose()
		{
			method_7();
		}
	}
}
