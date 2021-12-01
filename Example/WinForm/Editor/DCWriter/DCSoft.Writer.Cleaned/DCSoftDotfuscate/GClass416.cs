using DCSoft.RTF;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass416
	{
		private GClass414 gclass414_0 = null;

		private Hashtable hashtable_0 = new Hashtable();

		private GClass430 gclass430_0 = new GClass430();

		private GClass403 gclass403_0 = new GClass403();

		private GClass419 gclass419_0 = new GClass419();

		private GClass418 gclass418_0 = new GClass418();

		private bool bool_0 = true;

		private bool bool_1 = true;

		private GClass425 gclass425_0 = null;

		private bool bool_2 = true;

		public GClass416()
		{
			gclass418_0.method_3(bool_1: true);
		}

		public GClass416(TextWriter textWriter_0)
		{
			gclass418_0.method_3(bool_1: true);
			vmethod_0(textWriter_0);
		}

		public GClass416(string string_0)
		{
			gclass418_0.method_3(bool_1: true);
			vmethod_1(string_0);
		}

		public GClass416(Stream stream_0)
		{
			gclass418_0.method_3(bool_1: true);
			StreamWriter textWriter_ = new StreamWriter(stream_0, Encoding.ASCII);
			vmethod_0(textWriter_);
		}

		public virtual bool vmethod_0(TextWriter textWriter_0)
		{
			gclass414_0 = new GClass414(textWriter_0);
			gclass414_0.method_1(Encoding.GetEncoding(936));
			gclass414_0.method_3(bool_1: false);
			return true;
		}

		public virtual bool vmethod_1(string string_0)
		{
			gclass414_0 = new GClass414(string_0);
			gclass414_0.method_1(Encoding.GetEncoding(936));
			gclass414_0.method_3(bool_1: false);
			return true;
		}

		public virtual void vmethod_2()
		{
			gclass414_0.method_7();
		}

		public GClass414 method_0()
		{
			return gclass414_0;
		}

		public void method_1(GClass414 gclass414_1)
		{
			gclass414_0 = gclass414_1;
		}

		public Hashtable method_2()
		{
			return hashtable_0;
		}

		public GClass430 method_3()
		{
			return gclass430_0;
		}

		public GClass403 method_4()
		{
			return gclass403_0;
		}

		public void method_5(GClass403 gclass403_1)
		{
			gclass403_0 = gclass403_1;
		}

		public GClass419 method_6()
		{
			return gclass419_0;
		}

		public void method_7(GClass419 gclass419_1)
		{
			gclass419_0 = gclass419_1;
		}

		public GClass418 method_8()
		{
			return gclass418_0;
		}

		public bool method_9()
		{
			return bool_0;
		}

		public void method_10(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public int method_11()
		{
			return gclass414_0.method_6();
		}

		public void method_12()
		{
			if (!bool_0)
			{
				gclass414_0.method_10();
			}
		}

		public void method_13()
		{
			if (!bool_0)
			{
				gclass414_0.method_11();
			}
		}

		public void method_14(string string_0)
		{
			if (!bool_0)
			{
				gclass414_0.method_13(string_0);
			}
		}

		public void method_15(string string_0, bool bool_3)
		{
			if (!bool_0)
			{
				gclass414_0.method_14(string_0, bool_3);
			}
		}

		public void method_16(string string_0)
		{
			if (!bool_0 && string_0 != null)
			{
				gclass414_0.method_12(string_0);
			}
		}

		public void method_17(DashStyle dashStyle_0)
		{
			int num = 15;
			if (!bool_0)
			{
				switch (dashStyle_0)
				{
				case DashStyle.Dot:
					method_14("brdrdot");
					break;
				case DashStyle.DashDot:
					method_14("brdrdashd");
					break;
				case DashStyle.DashDotDot:
					method_14("brdrdashdd");
					break;
				case DashStyle.Dash:
					method_14("brdrdash");
					break;
				default:
					method_14("brdrs");
					break;
				}
			}
		}

		public bool method_18()
		{
			return bool_1;
		}

		public void method_19(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public void method_20()
		{
			int num = 6;
			gclass425_0 = null;
			bool_2 = true;
			if (bool_0)
			{
				hashtable_0.Clear();
				gclass430_0.Clear();
				gclass418_0.method_8();
				gclass430_0.method_3(Control.DefaultFont.Name);
				return;
			}
			gclass414_0.method_10();
			gclass414_0.method_13("rtf");
			gclass414_0.method_13("ansi");
			gclass414_0.method_13("ansicpg" + gclass414_0.method_0().CodePage);
			if (hashtable_0.Count > 0)
			{
				gclass414_0.method_10();
				gclass414_0.method_13("info");
				foreach (string key in hashtable_0.Keys)
				{
					gclass414_0.method_10();
					object obj = hashtable_0[key];
					if (obj is string)
					{
						gclass414_0.method_13(key);
						gclass414_0.method_15((string)obj);
					}
					else if (obj is int)
					{
						gclass414_0.method_13(key + obj);
					}
					else if (obj is DateTime)
					{
						DateTime dateTime = (DateTime)obj;
						gclass414_0.method_13(key);
						gclass414_0.method_13("yr" + dateTime.Year);
						gclass414_0.method_13("mo" + dateTime.Month);
						gclass414_0.method_13("dy" + dateTime.Day);
						gclass414_0.method_13("hr" + dateTime.Hour);
						gclass414_0.method_13("min" + dateTime.Minute);
						gclass414_0.method_13("sec" + dateTime.Second);
					}
					else
					{
						gclass414_0.method_13(key);
					}
					gclass414_0.method_11();
				}
				gclass414_0.method_11();
			}
			gclass414_0.method_10();
			gclass414_0.method_13("fonttbl");
			for (int i = 0; i < gclass430_0.Count; i++)
			{
				gclass414_0.method_10();
				gclass414_0.method_13("f" + i);
				GClass431 gClass = gclass430_0.method_0(i);
				gclass414_0.method_15(gClass.Name);
				if (gClass.method_4() != 1)
				{
					gclass414_0.method_13("fcharset" + gClass.method_4());
				}
				gclass414_0.method_11();
			}
			gclass414_0.method_11();
			gclass414_0.method_10();
			gclass414_0.method_13("colortbl");
			gclass414_0.method_12(";");
			for (int i = 0; i < gclass418_0.method_9(); i++)
			{
				Color color = gclass418_0.method_0(i);
				gclass414_0.method_13("red" + color.R);
				gclass414_0.method_13("green" + color.G);
				gclass414_0.method_13("blue" + color.B);
				gclass414_0.method_12(";");
			}
			gclass414_0.method_11();
			if (method_4() != null && method_4().Count > 0)
			{
				if (method_18())
				{
					gclass414_0.method_12(Environment.NewLine);
				}
				gclass414_0.method_10();
				gclass414_0.method_14("listtable", bool_1: true);
				foreach (GClass404 item in method_4())
				{
					if (method_18())
					{
						gclass414_0.method_12(Environment.NewLine);
					}
					gclass414_0.method_10();
					gclass414_0.method_13("list");
					gclass414_0.method_13("listtemplateid" + item.method_2());
					if (item.method_6())
					{
						gclass414_0.method_13("listhybrid");
					}
					if (method_18())
					{
						gclass414_0.method_12(Environment.NewLine);
					}
					foreach (GClass405 item2 in item.method_12())
					{
						gclass414_0.method_10();
						gclass414_0.method_13("listlevel");
						if (item2.method_2() != LevelNumberType.None)
						{
							gclass414_0.method_13("levelnfc" + Convert.ToInt32(item2.method_2()));
							gclass414_0.method_13("levelnfcn" + Convert.ToInt32(item2.method_2()));
						}
						gclass414_0.method_13("levelstartat" + item2.method_0());
						gclass414_0.method_13("levelfollow" + item2.method_6());
						gclass414_0.method_13("leveljc" + item2.method_4());
						if (!string.IsNullOrEmpty(item2.method_10()))
						{
							gclass414_0.method_10();
							gclass414_0.method_13("leveltext");
							gclass414_0.method_13("'0" + item2.method_10().Length);
							if (item2.method_2() == LevelNumberType.Bullet)
							{
								gclass414_0.method_16(item2.method_10());
							}
							else
							{
								gclass414_0.method_17(item2.method_10(), bool_1: false);
							}
							gclass414_0.method_11();
							if (item2.method_2() == LevelNumberType.Bullet)
							{
								GClass431 gClass = method_3().method_1("Wingdings");
								if (gClass != null)
								{
									gclass414_0.method_13("f" + gClass.method_0());
								}
							}
							else
							{
								gclass414_0.method_10();
								gclass414_0.method_13("levelnumbers");
								if (string.IsNullOrEmpty(item2.method_12()))
								{
									gclass414_0.method_13("'01");
								}
								else
								{
									gclass414_0.method_17(item2.method_12(), bool_1: false);
								}
								gclass414_0.method_11();
							}
						}
						gclass414_0.method_11();
					}
					gclass414_0.method_13("listid" + item.method_0());
					gclass414_0.method_11();
				}
				gclass414_0.method_11();
			}
			if (method_6() != null && method_6().Count > 0)
			{
				if (method_18())
				{
					gclass414_0.method_12(Environment.NewLine);
				}
				gclass414_0.method_10();
				gclass414_0.method_13("listoverridetable");
				foreach (GClass420 item3 in method_6())
				{
					if (method_18())
					{
						gclass414_0.method_12(Environment.NewLine);
					}
					gclass414_0.method_10();
					gclass414_0.method_13("listoverride");
					gclass414_0.method_13("listid" + item3.method_0());
					gclass414_0.method_13("listoverridecount" + item3.method_2());
					gclass414_0.method_13("ls" + item3.method_4());
					gclass414_0.method_11();
				}
				gclass414_0.method_11();
			}
			if (method_18())
			{
				gclass414_0.method_12(Environment.NewLine);
			}
			gclass414_0.method_13("viewkind1");
		}

		public void method_21()
		{
			if (!bool_0)
			{
				gclass414_0.method_11();
			}
			gclass414_0.method_8();
		}

		public void method_22()
		{
			int num = 4;
			if (!bool_0)
			{
				gclass414_0.method_10();
				gclass414_0.method_13("header");
			}
		}

		public void method_23()
		{
			int num = 10;
			if (!bool_0)
			{
				gclass414_0.method_10();
				gclass414_0.method_13("headerf");
			}
		}

		public void method_24()
		{
			if (!bool_0)
			{
				gclass414_0.method_11();
			}
		}

		public void method_25()
		{
			int num = 19;
			if (!bool_0)
			{
				gclass414_0.method_10();
				gclass414_0.method_13("footer");
			}
		}

		public void method_26()
		{
			int num = 6;
			if (!bool_0)
			{
				gclass414_0.method_10();
				gclass414_0.method_13("footerf");
			}
		}

		public void method_27()
		{
			if (!bool_0)
			{
				gclass414_0.method_11();
			}
		}

		public void method_28()
		{
			method_29(new GClass425());
		}

		public void method_29(GClass425 gclass425_1)
		{
			int num = 15;
			if (!bool_0)
			{
				if (bool_2)
				{
					bool_2 = false;
					gclass414_0.method_12(Environment.NewLine);
				}
				else
				{
					gclass414_0.method_13("par");
				}
				if (gclass425_1.method_71() >= 0)
				{
					gclass414_0.method_13("pard");
					gclass414_0.method_13("ls" + gclass425_1.method_71());
				}
				if (gclass425_0 != null && gclass425_0.method_71() >= 0)
				{
					gclass414_0.method_13("pard");
				}
				switch (gclass425_1.method_39())
				{
				case GEnum80.const_0:
					gclass414_0.method_13("ql");
					break;
				case GEnum80.const_1:
					gclass414_0.method_13("qc");
					break;
				case GEnum80.const_2:
					gclass414_0.method_13("qr");
					break;
				case GEnum80.const_3:
					gclass414_0.method_13("qj");
					break;
				}
				if (gclass425_1.method_25() != 0)
				{
					gclass414_0.method_13("fi" + Convert.ToInt32(gclass425_1.method_25() * 400 / gclass425_1.method_23()));
				}
				else
				{
					gclass414_0.method_13("fi0");
				}
				if (gclass425_1.method_27() != 0)
				{
					gclass414_0.method_13("li" + Convert.ToInt32(gclass425_1.method_27() * 400 / gclass425_1.method_23()));
				}
				else
				{
					gclass414_0.method_13("li0");
				}
				gclass414_0.method_13("plain");
			}
			gclass425_0 = gclass425_1;
		}

		public void method_30()
		{
		}

		public void method_31(string string_0)
		{
			if (string_0 != null && !bool_0)
			{
				gclass414_0.method_15(string_0);
			}
		}

		public void method_32(Font font_0)
		{
			int num = 9;
			if (font_0 == null)
			{
				throw new ArgumentNullException("font");
			}
			if (bool_0)
			{
				gclass430_0.method_3(font_0.Name);
				return;
			}
			int num2 = gclass430_0.method_8(font_0.Name);
			if (num2 >= 0)
			{
				gclass414_0.method_13("f" + num2);
			}
			if (font_0.Bold)
			{
				gclass414_0.method_13("b");
			}
			if (font_0.Italic)
			{
				gclass414_0.method_13("i");
			}
			if (font_0.Underline)
			{
				gclass414_0.method_13("ul");
			}
			if (font_0.Strikeout)
			{
				gclass414_0.method_13("strike");
			}
			gclass414_0.method_13("fs" + Convert.ToInt32(font_0.Size * 2f));
		}

		public void method_33(GClass425 gclass425_1)
		{
			int num = 1;
			if (bool_0)
			{
				gclass430_0.method_3(gclass425_1.method_45());
				gclass418_0.method_4(gclass425_1.method_61());
				gclass418_0.method_4(gclass425_1.method_63());
				if (gclass425_1.method_11().A != 0)
				{
					gclass418_0.method_4(gclass425_1.method_11());
				}
				return;
			}
			if (gclass425_1.method_65() != null && gclass425_1.method_65().Length > 0)
			{
				gclass414_0.method_10();
				gclass414_0.method_13("field");
				gclass414_0.method_10();
				gclass414_0.method_14("fldinst", bool_1: true);
				gclass414_0.method_10();
				gclass414_0.method_13("hich");
				gclass414_0.method_15(" HYPERLINK \"" + gclass425_1.method_65() + "\"");
				gclass414_0.method_11();
				gclass414_0.method_11();
				gclass414_0.method_10();
				gclass414_0.method_13("fldrslt");
				gclass414_0.method_10();
			}
			switch (gclass425_1.method_39())
			{
			case GEnum80.const_0:
				gclass414_0.method_13("ql");
				break;
			case GEnum80.const_1:
				gclass414_0.method_13("qc");
				break;
			case GEnum80.const_2:
				gclass414_0.method_13("qr");
				break;
			case GEnum80.const_3:
				gclass414_0.method_13("qj");
				break;
			}
			gclass414_0.method_13("plain");
			int num2 = 0;
			num2 = gclass430_0.method_8(gclass425_1.method_45());
			if (num2 >= 0)
			{
				gclass414_0.method_13("f" + num2);
			}
			if (gclass425_1.method_51())
			{
				gclass414_0.method_13("b");
			}
			if (gclass425_1.method_53())
			{
				gclass414_0.method_13("i");
			}
			if (gclass425_1.method_55())
			{
				gclass414_0.method_13("ul");
			}
			if (gclass425_1.method_57())
			{
				gclass414_0.method_13("strike");
			}
			gclass414_0.method_13("fs" + Convert.ToInt32(gclass425_1.method_47() * 2f));
			num2 = gclass418_0.method_6(gclass425_1.method_63());
			if (num2 >= 0)
			{
				gclass414_0.method_13("chcbpat" + Convert.ToString(num2 + 1));
			}
			num2 = gclass418_0.method_6(gclass425_1.method_61());
			if (num2 >= 0)
			{
				gclass414_0.method_13("cf" + Convert.ToString(num2 + 1));
			}
			if (gclass425_1.method_69())
			{
				gclass414_0.method_13("sub");
			}
			if (gclass425_1.method_67())
			{
				gclass414_0.method_13("super");
			}
			if (gclass425_1.method_75())
			{
				gclass414_0.method_13("nowwrap");
			}
			if ((gclass425_1.method_3() || gclass425_1.method_5() || gclass425_1.method_7() || gclass425_1.method_9()) && gclass425_1.method_11().A != 0)
			{
				gclass414_0.method_13("chbrdr");
				gclass414_0.method_13("brdrs");
				gclass414_0.method_13("brdrw10");
				num2 = gclass418_0.method_6(gclass425_1.method_11());
				if (num2 >= 0)
				{
					gclass414_0.method_13("brdrcf" + Convert.ToString(num2 + 1));
				}
			}
		}

		public void method_34(GClass425 gclass425_1)
		{
			int num = 19;
			if (!bool_0)
			{
				if (gclass425_1.method_69())
				{
					gclass414_0.method_13("sub0");
				}
				if (gclass425_1.method_67())
				{
					gclass414_0.method_13("super0");
				}
				if (gclass425_1.method_51())
				{
					gclass414_0.method_13("b0");
				}
				if (gclass425_1.method_53())
				{
					gclass414_0.method_13("i0");
				}
				if (gclass425_1.method_55())
				{
					gclass414_0.method_13("ul0");
				}
				if (gclass425_1.method_57())
				{
					gclass414_0.method_13("strike0");
				}
				if (gclass425_1.method_65() != null && gclass425_1.method_65().Length > 0)
				{
					gclass414_0.method_11();
					gclass414_0.method_11();
					gclass414_0.method_11();
				}
			}
		}

		public void method_35(string string_0, GClass425 gclass425_1)
		{
			int num = 9;
			if (bool_0)
			{
				gclass430_0.method_3(gclass425_1.method_45());
				gclass418_0.method_4(gclass425_1.method_61());
				gclass418_0.method_4(gclass425_1.method_63());
				return;
			}
			method_33(gclass425_1);
			if (gclass425_1.method_21())
			{
				if (string_0 != null)
				{
					string_0 = string_0.Replace("\n", "");
					StringReader stringReader = new StringReader(string_0);
					string text = stringReader.ReadLine();
					int num2 = 0;
					while (text != null)
					{
						if (num2 > 0)
						{
							gclass414_0.method_13("line");
						}
						num2++;
						gclass414_0.method_15(text);
						text = stringReader.ReadLine();
					}
					stringReader.Close();
				}
			}
			else
			{
				gclass414_0.method_15(string_0);
			}
			method_34(gclass425_1);
		}

		public void method_36()
		{
		}

		public void method_37(string string_0)
		{
			int num = 11;
			if (!bool_0)
			{
				gclass414_0.method_10();
				gclass414_0.method_14("bkmkstart", bool_1: true);
				gclass414_0.method_13("f0");
				gclass414_0.method_15(string_0);
				gclass414_0.method_11();
				gclass414_0.method_10();
				gclass414_0.method_14("bkmkend", bool_1: true);
				gclass414_0.method_13("f0");
				gclass414_0.method_15(string_0);
				gclass414_0.method_11();
			}
		}

		public void method_38(string string_0)
		{
		}

		public void method_39()
		{
			int num = 3;
			if (!bool_0)
			{
				gclass414_0.method_13("line");
			}
		}

		public void method_40(Image image_0, int int_0, int int_1, byte[] byte_0)
		{
			int num = 8;
			if (!bool_0 && byte_0 != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				image_0.Save(memoryStream, ImageFormat.Jpeg);
				memoryStream.Close();
				byte[] byte_ = memoryStream.ToArray();
				gclass414_0.method_10();
				gclass414_0.method_13("pict");
				gclass414_0.method_13("jpegblip");
				gclass414_0.method_13("picscalex" + Convert.ToInt32((double)int_0 * 100.0 / (double)image_0.Size.Width));
				gclass414_0.method_13("picscaley" + Convert.ToInt32((double)int_1 * 100.0 / (double)image_0.Size.Height));
				gclass414_0.method_13("picwgoal" + Convert.ToString(image_0.Size.Width * 15));
				gclass414_0.method_13("pichgoal" + Convert.ToString(image_0.Size.Height * 15));
				gclass414_0.method_19(byte_);
				gclass414_0.method_11();
			}
		}
	}
}
