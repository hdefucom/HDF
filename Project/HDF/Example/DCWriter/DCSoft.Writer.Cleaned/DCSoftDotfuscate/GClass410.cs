using DCSoft.RTF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass410 : IDisposable
	{
		private GClass411 gclass411_0 = null;

		private TextReader textReader_0 = null;

		private Stream stream_0 = null;

		private GClass412 gclass412_0 = null;

		private bool bool_0 = false;

		private GClass412 gclass412_1 = null;

		private int int_0 = 0;

		private int int_1 = 0;

		private bool bool_1 = true;

		private Stack<GClass429> stack_0 = new Stack<GClass429>();

		public EventHandler eventHandler_0 = null;

		public EventHandler eventHandler_1 = null;

		public static string smethod_0(string string_0)
		{
			StringReader textReader_ = new StringReader(string_0);
			GClass410 gClass = new GClass410(textReader_);
			GClass386 gclass386_ = new GClass386();
			Class201 @class = new Class201(gclass386_);
			while (gClass.method_22() != null)
			{
				@class.method_3(gClass.method_5(), gClass);
			}
			return @class.method_5();
		}

		public GClass410()
		{
		}

		public GClass410(string string_0)
		{
			method_1(string_0);
		}

		public GClass410(Stream stream_1)
		{
			StreamReader textReader_ = new StreamReader(stream_1, Encoding.ASCII);
			method_2(textReader_);
			stream_0 = stream_1;
		}

		public GClass410(TextReader textReader_1)
		{
			method_2(textReader_1);
		}

		public TextReader method_0()
		{
			return textReader_0;
		}

		public bool method_1(string string_0)
		{
			gclass412_0 = null;
			if (File.Exists(string_0))
			{
				FileStream stream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
				textReader_0 = new StreamReader(stream, Encoding.ASCII);
				stream_0 = stream;
				gclass411_0 = new GClass411(textReader_0);
				return true;
			}
			return false;
		}

		public bool method_2(TextReader textReader_1)
		{
			gclass412_0 = null;
			if (textReader_1 != null)
			{
				textReader_0 = textReader_1;
				gclass411_0 = new GClass411(textReader_0);
				return true;
			}
			return false;
		}

		public bool method_3(string string_0)
		{
			gclass412_0 = null;
			if (string_0 != null && string_0.Length > 3)
			{
				textReader_0 = new StringReader(string_0);
				gclass411_0 = new GClass411(textReader_0);
				return true;
			}
			return false;
		}

		public void method_4()
		{
			if (textReader_0 != null)
			{
				textReader_0.Close();
				textReader_0 = null;
			}
		}

		public GClass412 method_5()
		{
			return gclass412_0;
		}

		public RTFTokenType method_6()
		{
			if (gclass412_0 == null)
			{
				return RTFTokenType.None;
			}
			return gclass412_0.method_0();
		}

		public string method_7()
		{
			if (gclass412_0 == null)
			{
				return null;
			}
			return gclass412_0.method_2();
		}

		public bool method_8()
		{
			if (gclass412_0 == null)
			{
				return false;
			}
			return gclass412_0.method_4();
		}

		public int method_9()
		{
			if (gclass412_0 == null)
			{
				return 0;
			}
			return gclass412_0.method_6();
		}

		public int method_10()
		{
			if (stream_0 == null)
			{
				return 0;
			}
			return (int)stream_0.Position;
		}

		public int method_11()
		{
			if (stream_0 == null)
			{
				return 0;
			}
			return (int)stream_0.Length;
		}

		public RTFTokenType method_12()
		{
			return gclass411_0.method_0();
		}

		public bool method_13()
		{
			return bool_0;
		}

		public GClass412 method_14()
		{
			return gclass412_1;
		}

		public int method_15()
		{
			return int_0;
		}

		public int method_16()
		{
			return int_1;
		}

		public void method_17(int int_2)
		{
			int_1 = int_2;
		}

		public bool method_18()
		{
			return bool_1;
		}

		public void method_19(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public void method_20()
		{
			int num = 5;
			if (method_5() != null)
			{
				string text = method_5().method_2();
				if (text != null && text == "uc")
				{
					method_21().method_1(method_9());
				}
			}
		}

		public GClass429 method_21()
		{
			if (stack_0.Count == 0)
			{
				stack_0.Push(new GClass429());
			}
			return stack_0.Peek();
		}

		public GClass412 method_22()
		{
			bool_0 = false;
			gclass412_1 = gclass412_0;
			if (gclass412_1 != null && gclass412_1.method_0() == RTFTokenType.GroupStart)
			{
				bool_0 = true;
			}
			gclass412_0 = gclass411_0.method_1();
			if (gclass412_0 == null || gclass412_0.method_0() == RTFTokenType.Eof)
			{
				gclass412_0 = null;
				return null;
			}
			int_1++;
			if (gclass412_0.method_0() == RTFTokenType.GroupStart)
			{
				if (stack_0.Count == 0)
				{
					stack_0.Push(new GClass429());
				}
				else
				{
					GClass429 gClass = stack_0.Peek();
					stack_0.Push(gClass.method_5());
				}
				int_0++;
			}
			else if (gclass412_0.method_0() == RTFTokenType.GroupEnd)
			{
				if (stack_0.Count > 0)
				{
					stack_0.Pop();
				}
				int_0--;
			}
			if (method_18())
			{
				method_20();
			}
			return gclass412_0;
		}

		public void method_23()
		{
			int num = 0;
			while (true)
			{
				switch (textReader_0.Peek())
				{
				case -1:
					return;
				case 123:
					num++;
					break;
				case 125:
					num--;
					if (num < 0)
					{
						return;
					}
					break;
				}
				int num2 = textReader_0.Read();
			}
		}

		public void Dispose()
		{
			method_4();
		}

		public override string ToString()
		{
			return "RTFReader Level:" + int_0 + " " + method_7();
		}
	}
}
