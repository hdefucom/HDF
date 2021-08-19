using DCSoft.RTF;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass408 : GClass407
	{
		protected GClass418 gclass418_0 = new GClass418();

		protected GClass430 gclass430_0 = new GClass430();

		protected GClass424 gclass424_0 = new GClass424();

		private Encoding encoding_0 = null;

		private Encoding encoding_1 = null;

		private Encoding encoding_2 = null;

		internal static void smethod_0()
		{
			GClass408 gClass = new GClass408();
			gClass.method_22("d:\\abc.rtf");
			GClass414 gClass2 = new GClass414("d:\\a.rtf");
			gClass2.method_3(bool_1: true);
			gClass.vmethod_10(gClass2);
			gClass2.method_7();
		}

		public GClass408()
		{
			gclass408_0 = this;
			gclass407_0 = null;
			gclass418_0.method_3(bool_1: false);
		}

		public override GClass408 vmethod_2()
		{
			return this;
		}

		public override void vmethod_3(GClass408 gclass408_1)
		{
		}

		public override GClass407 vmethod_0()
		{
			return null;
		}

		public override void vmethod_1(GClass407 gclass407_1)
		{
		}

		public GClass418 method_14()
		{
			return gclass418_0;
		}

		public GClass430 method_15()
		{
			return gclass430_0;
		}

		public GClass424 method_16()
		{
			return gclass424_0;
		}

		private void method_17(GClass407 gclass407_1)
		{
			int num = 4;
			gclass430_0.Clear();
			foreach (GClass406 item in gclass407_1.vmethod_9())
			{
				if (item is GClass407)
				{
					int num2 = -1;
					string text = null;
					int int_ = 0;
					foreach (GClass406 item2 in item.vmethod_9())
					{
						if (item2.vmethod_4() == "f" && item2.vmethod_6())
						{
							num2 = item2.vmethod_8();
						}
						else if (item2.vmethod_4() == "fcharset")
						{
							int_ = item2.vmethod_8();
						}
						else if (item2.method_1() == GEnum82.const_4 && item2.vmethod_4() != null && item2.vmethod_4().Length > 0)
						{
							text = item2.vmethod_4();
							break;
						}
					}
					if (num2 >= 0 && text != null)
					{
						if (text.EndsWith(";"))
						{
							text = text.Substring(0, text.Length - 1);
						}
						text = text.Trim();
						GClass431 gClass3 = new GClass431(num2, text);
						gClass3.method_5(int_);
						gclass430_0.method_6(gClass3);
					}
				}
			}
		}

		private void method_18(GClass407 gclass407_1)
		{
			int num = 17;
			gclass418_0.method_8();
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			foreach (GClass406 item in gclass407_1.vmethod_9())
			{
				if (item.vmethod_4() == "red")
				{
					num2 = item.vmethod_8();
				}
				else if (item.vmethod_4() == "green")
				{
					num3 = item.vmethod_8();
				}
				else if (item.vmethod_4() == "blue")
				{
					num4 = item.vmethod_8();
				}
				if (item.vmethod_4() == ";" && num2 >= 0 && num3 >= 0 && num4 >= 0)
				{
					Color color_ = Color.FromArgb(255, num2, num3, num4);
					gclass418_0.method_4(color_);
					num2 = -1;
					num3 = -1;
					num4 = -1;
				}
			}
			if (num2 >= 0 && num3 >= 0 && num4 >= 0)
			{
				Color color_ = Color.FromArgb(255, num2, num3, num4);
				gclass418_0.method_4(color_);
			}
		}

		private void method_19(GClass407 gclass407_1)
		{
			int num = 1;
			gclass424_0.method_47();
			gclass407_1.method_4(bool_1: false);
			foreach (GClass406 item in gclass407_1.vmethod_9())
			{
				if (item is GClass407)
				{
					if (item.vmethod_4() == "creatim")
					{
						gclass424_0.method_39(method_20(item));
					}
					else if (item.vmethod_4() == "revtim")
					{
						gclass424_0.method_41(method_20(item));
					}
					else if (item.vmethod_4() == "printim")
					{
						gclass424_0.method_43(method_20(item));
					}
					else if (item.vmethod_4() == "buptim")
					{
						gclass424_0.method_45(method_20(item));
					}
					else if (item.vmethod_6())
					{
						gclass424_0.method_1(item.vmethod_4(), item.vmethod_8().ToString());
					}
					else
					{
						gclass424_0.method_1(item.vmethod_4(), item.vmethod_9().method_4());
					}
				}
			}
		}

		private DateTime method_20(GClass406 gclass406_0)
		{
			int year = gclass406_0.vmethod_9().method_3("yr", 1900);
			int month = gclass406_0.vmethod_9().method_3("mo", 1);
			int day = gclass406_0.vmethod_9().method_3("dy", 1);
			int hour = gclass406_0.vmethod_9().method_3("hr", 0);
			int minute = gclass406_0.vmethod_9().method_3("min", 0);
			int second = gclass406_0.vmethod_9().method_3("sec", 0);
			return new DateTime(year, month, day, hour, minute, second);
		}

		public void method_21(string string_1)
		{
			encoding_0 = null;
			using (GClass410 gClass = new GClass410())
			{
				if (gClass.method_3(string_1))
				{
					method_26(gClass);
					gClass.method_4();
				}
				gClass.method_4();
			}
		}

		public void method_22(string string_1)
		{
			encoding_0 = null;
			using (GClass410 gClass = new GClass410())
			{
				if (gClass.method_1(string_1))
				{
					method_26(gClass);
					gClass.method_4();
				}
				gClass.method_4();
			}
		}

		public Encoding method_23()
		{
			int num = 19;
			if (encoding_0 == null)
			{
				GClass406 gClass = gclass415_0.method_1("ansicpg");
				if (gClass != null && gClass.vmethod_6())
				{
					encoding_0 = Encoding.GetEncoding(gClass.vmethod_8());
				}
			}
			if (encoding_0 == null)
			{
				encoding_0 = Encoding.Default;
			}
			return encoding_0;
		}

		internal Encoding method_24()
		{
			if (encoding_1 != null)
			{
				return encoding_1;
			}
			if (encoding_2 != null)
			{
				return encoding_2;
			}
			return method_23();
		}

		public void method_25(TextReader textReader_0)
		{
			GClass410 gClass = new GClass410();
			gClass.method_2(textReader_0);
			method_26(gClass);
		}

		public void method_26(GClass410 gclass410_0)
		{
			int num = 7;
			gclass415_0.Clear();
			Stack stack = new Stack();
			GClass407 gClass = null;
			GClass406 gClass2 = null;
			while (gclass410_0.method_22() != null)
			{
				if (gclass410_0.method_6() == RTFTokenType.GroupStart)
				{
					if (gClass == null)
					{
						gClass = this;
					}
					else
					{
						gClass = new GClass407();
						gClass.vmethod_3(this);
					}
					if (gClass != this)
					{
						GClass407 gClass3 = (GClass407)stack.Peek();
						gClass3.method_10(gClass);
					}
					stack.Push(gClass);
					continue;
				}
				if (gclass410_0.method_6() == RTFTokenType.GroupEnd)
				{
					gClass = (GClass407)stack.Pop();
					gClass.method_7();
					if (gClass.method_6() != null)
					{
						switch (gClass.vmethod_4())
						{
						case "info":
							method_19(gClass);
							break;
						case "colortbl":
							method_18(gClass);
							break;
						case "fonttbl":
							method_17(gClass);
							break;
						}
					}
					if (stack.Count <= 0)
					{
						break;
					}
					gClass = (GClass407)stack.Peek();
					continue;
				}
				gClass2 = new GClass406(gclass410_0.method_5());
				gClass2.vmethod_3(this);
				gClass.method_10(gClass2);
				if (gClass2.vmethod_4() == "f")
				{
					GClass431 gClass4 = method_15().method_0(gClass2.vmethod_8());
					if (gClass4 != null)
					{
						encoding_1 = gClass4.method_6();
					}
					else
					{
						encoding_1 = null;
					}
				}
				else if (gClass2.vmethod_4() == "af")
				{
					GClass431 gClass4 = method_15().method_0(gClass2.vmethod_8());
					if (gClass4 != null)
					{
						encoding_2 = gClass4.method_6();
					}
					else
					{
						encoding_2 = null;
					}
				}
			}
			while (stack.Count > 0)
			{
				gClass = (GClass407)stack.Pop();
				gClass.method_7();
			}
		}

		public override void vmethod_10(GClass414 gclass414_0)
		{
			gclass414_0.method_1(method_23());
			base.vmethod_10(gclass414_0);
		}

		public void method_27(string string_1)
		{
			using (GClass414 gClass = new GClass414(string_1))
			{
				vmethod_10(gClass);
				gClass.method_7();
			}
		}

		public void method_28(Stream stream_0)
		{
			using (GClass414 gClass = new GClass414(new StreamWriter(stream_0, method_23())))
			{
				vmethod_10(gClass);
				gClass.method_7();
			}
		}
	}
}
