using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass539 : IDisposable
	{
		private GClass537 gclass537_0 = new GClass537();

		private GClass540 gclass540_0 = new GClass540();

		private GClass538 gclass538_0;

		private GClass465 gclass465_0 = new GClass465();

		private GClass469 gclass469_0 = new GClass469();

		private GClass477 gclass477_0 = new GClass477();

		private GClass514 gclass514_0 = new GClass514();

		private string string_0;

		private string string_1;

		private bool bool_0 = true;

		public GClass539()
		{
			method_0();
		}

		public GClass539(string string_2)
		{
			string_0 = string_2;
			method_0();
		}

		public GClass539(string string_2, string string_3)
		{
			string_0 = string_2;
			string_1 = string_3;
			method_0();
		}

		private void method_0()
		{
			gclass538_0 = new GClass538(gclass540_0);
			gclass514_0.method_1(GEnum89.const_1);
		}

		private void method_1()
		{
			int num = 9;
			gclass514_0.method_8("Author", new GClass512("DCSoft"));
			if (string_1 != null)
			{
				gclass514_0.method_8("Creator", new GClass512(string_1));
			}
			gclass514_0.method_8("Producer", new GClass512("DCSoft"));
			if (string_0 != null)
			{
				gclass514_0.method_8("Title", new GClass512(string_0));
			}
			gclass514_0.method_8("CreationDate", new GClass517(DateTime.Now));
		}

		private void method_2()
		{
			gclass540_0.method_2(gclass514_0);
			gclass465_0.method_1(gclass540_0);
			gclass469_0.method_6(gclass540_0);
			gclass477_0.method_8(gclass540_0);
		}

		private void method_3()
		{
			if (method_21())
			{
				method_1();
			}
			gclass465_0.vmethod_2();
			gclass469_0.method_5();
			gclass477_0.method_7();
		}

		private void method_4()
		{
			int num = 7;
			gclass477_0.method_2();
			method_2();
			method_3();
			gclass538_0.method_2().method_8("Size", new GClass507(gclass540_0.method_5()));
			if (method_21())
			{
				gclass538_0.method_2().method_8("Info", gclass514_0);
			}
			gclass538_0.method_2().method_8("Root", gclass465_0.method_3());
		}

		public void method_5(StreamWriter streamWriter_0)
		{
			method_4();
			gclass537_0.method_0(streamWriter_0);
			gclass514_0.method_6(streamWriter_0);
			gclass465_0.method_2(streamWriter_0);
			gclass469_0.method_7(streamWriter_0);
			gclass477_0.method_9(streamWriter_0);
			gclass540_0.method_1(streamWriter_0);
			gclass538_0.method_1(streamWriter_0);
		}

		public GClass468 method_6(int int_0)
		{
			if (int_0 < 0)
			{
				return null;
			}
			return gclass465_0.method_4().method_14(ref int_0);
		}

		public GClass455 method_7(GClass455 gclass455_0)
		{
			return gclass469_0.method_2(gclass455_0);
		}

		public GClass476 method_8(Font font_0)
		{
			int num = 0;
			while (true)
			{
				if (num < gclass477_0.method_0())
				{
					if (gclass477_0.method_1(num).method_4() == font_0 || gclass477_0.method_1(num).method_4().Equals(font_0) || Class211.smethod_2(gclass477_0.method_1(num).method_4(), font_0))
					{
						break;
					}
					num++;
					continue;
				}
				return gclass477_0.method_5(new GClass476(font_0));
			}
			return gclass477_0.method_1(num);
		}

		public GClass476 method_9(string string_2, float float_0, FontStyle fontStyle_0)
		{
			int num = 0;
			while (true)
			{
				if (num < gclass477_0.method_0())
				{
					Font font = gclass477_0.method_1(num).method_4();
					if (font.Name == string_2 && font.Size == float_0 && font.Style == fontStyle_0)
					{
						break;
					}
					num++;
					continue;
				}
				return gclass477_0.method_5(new GClass476(new Font(string_2, float_0, fontStyle_0)));
			}
			return gclass477_0.method_1(num);
		}

		public GClass456 method_10(Image image_0)
		{
			int num = 7;
			int num2 = 0;
			int num3 = 0;
			GClass456 gClass;
			while (true)
			{
				if (num3 < gclass469_0.method_8())
				{
					if (gclass469_0.method_9(num3) is GClass456)
					{
						gClass = (gclass469_0.method_9(num3) as GClass456);
						if (gClass.method_7() == image_0)
						{
							break;
						}
						num2++;
					}
					num3++;
					continue;
				}
				return gclass469_0.method_3(new GClass456(image_0, "Img" + Convert.ToString(num2))) as GClass456;
			}
			return gClass;
		}

		public GClass456 method_11(Image image_0, float float_0, float float_1)
		{
			int num = 18;
			int num2 = 0;
			int num3 = 0;
			GClass456 gClass;
			while (true)
			{
				if (num3 < gclass469_0.method_8())
				{
					if (gclass469_0.method_9(num3) is GClass456)
					{
						gClass = (gclass469_0.method_9(num3) as GClass456);
						if (gClass.method_7() == image_0 && gClass.method_10() == float_1 && gClass.method_8() == float_0)
						{
							break;
						}
						num2++;
					}
					num3++;
					continue;
				}
				GClass456 gClass2 = new GClass456(image_0, "Image" + Convert.ToString(num2));
				gClass2.method_9(float_0);
				gClass2.method_11(float_1);
				return gclass469_0.method_3(gClass2) as GClass456;
			}
			return gClass;
		}

		public GClass537 method_12()
		{
			return gclass537_0;
		}

		public GClass465 method_13()
		{
			return gclass465_0;
		}

		public GClass540 method_14()
		{
			return gclass540_0;
		}

		public GClass538 method_15()
		{
			return gclass538_0;
		}

		public int method_16()
		{
			return gclass465_0.method_4().method_8();
		}

		public string method_17()
		{
			return string_0;
		}

		public void method_18(string string_2)
		{
			string_0 = string_2;
		}

		public string method_19()
		{
			return string_1;
		}

		public void method_20(string string_2)
		{
			string_1 = string_2;
		}

		public bool method_21()
		{
			return bool_0;
		}

		public void method_22(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public void Dispose()
		{
			if (gclass465_0 != null)
			{
				gclass465_0.Dispose();
				gclass465_0 = null;
			}
			if (gclass477_0 != null)
			{
				gclass477_0.Dispose();
				gclass477_0 = null;
			}
			if (gclass514_0 != null)
			{
				gclass514_0.Dispose();
				gclass514_0 = null;
			}
			if (gclass538_0 != null)
			{
				gclass538_0.Dispose();
				gclass538_0 = null;
			}
			if (gclass469_0 != null)
			{
				gclass469_0.Dispose();
				gclass469_0 = null;
			}
			if (gclass540_0 != null)
			{
				gclass540_0.Dispose();
				gclass540_0 = null;
			}
		}
	}
}
