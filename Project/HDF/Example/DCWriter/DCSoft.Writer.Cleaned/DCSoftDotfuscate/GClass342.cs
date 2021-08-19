using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass342
	{
		private TextWriter textWriter_0;

		private bool bool_0;

		private string string_0;

		private GEnum77 genum77_0;

		private int int_0;

		private bool bool_1;

		public static GClass342 smethod_0()
		{
			StringWriter textWriter_ = new StringWriter();
			return new GClass342(textWriter_);
		}

		public GClass342(StringBuilder stringBuilder_0)
		{
			int num = 14;
			textWriter_0 = null;
			bool_0 = true;
			string_0 = "   ";
			genum77_0 = GEnum77.const_0;
			int_0 = 0;
			bool_1 = false;
			
			if (stringBuilder_0 == null)
			{
				throw new ArgumentNullException("builder");
			}
			textWriter_0 = new StringWriter(stringBuilder_0);
		}

		public GClass342(TextWriter textWriter_1)
		{
			int num = 7;
			textWriter_0 = null;
			bool_0 = true;
			string_0 = "   ";
			genum77_0 = GEnum77.const_0;
			int_0 = 0;
			bool_1 = false;
			
			if (textWriter_1 == null)
			{
				throw new ArgumentNullException("writer");
			}
			textWriter_0 = textWriter_1;
		}

		public GClass342(string string_1, Encoding encoding_0)
		{
			int num = 15;
			textWriter_0 = null;
			bool_0 = true;
			string_0 = "   ";
			genum77_0 = GEnum77.const_0;
			int_0 = 0;
			bool_1 = false;
			
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("fileName");
			}
			textWriter_0 = new StreamWriter(string_1, append: false, encoding_0);
		}

		public TextWriter method_0()
		{
			return textWriter_0;
		}

		public bool method_1()
		{
			return bool_0;
		}

		public void method_2(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public string method_3()
		{
			return string_0;
		}

		public void method_4(string string_1)
		{
			string_0 = string_1;
		}

		public GEnum77 method_5()
		{
			return genum77_0;
		}

		public void method_6(GEnum77 genum77_1)
		{
			genum77_0 = genum77_1;
		}

		public void method_7()
		{
			textWriter_0.WriteLine();
			bool_1 = true;
		}

		private void method_8()
		{
			if (!bool_1)
			{
				return;
			}
			bool_1 = false;
			if (method_1() && !string.IsNullOrEmpty(method_3()))
			{
				for (int i = 0; i < int_0; i++)
				{
					textWriter_0.Write(method_3());
				}
			}
		}

		public void method_9(string string_1)
		{
			method_8();
			textWriter_0.Write(string_1);
			method_7();
		}

		public void method_10(string string_1)
		{
			method_8();
			textWriter_0.Write(string_1);
		}

		public void method_11()
		{
			int_0++;
		}

		public void method_12()
		{
			int_0--;
		}

		public void method_13()
		{
			int num = 3;
			if (method_5() == GEnum77.const_0)
			{
				method_7();
				method_10("{");
			}
			else if (method_5() == GEnum77.const_1)
			{
				method_10("{");
				method_7();
			}
			else if (method_5() == GEnum77.const_2)
			{
				method_7();
			}
			int_0++;
		}

		public void method_14()
		{
			method_15(null);
		}

		public void method_15(string string_1)
		{
			int num = 12;
			if (int_0 == 0)
			{
				throw new Exception("层级状态不对");
			}
			int_0--;
			if (method_5() == GEnum77.const_0)
			{
				method_7();
				method_10("}");
				if (!string.IsNullOrEmpty(string_1))
				{
					textWriter_0.Write("//" + string_1);
				}
			}
			else if (method_5() == GEnum77.const_1)
			{
				method_10("}");
				if (!string.IsNullOrEmpty(string_1))
				{
					textWriter_0.Write("//" + string_1);
				}
				method_7();
			}
			else if (method_5() == GEnum77.const_2)
			{
				method_7();
			}
		}
	}
}
