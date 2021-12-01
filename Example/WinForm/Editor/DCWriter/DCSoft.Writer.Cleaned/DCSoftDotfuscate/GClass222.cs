using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass222
	{
		private GClass242 gclass242_0 = new GClass242();

		public static readonly string[] string_0 = new string[7]
		{
			"font",
			"font-family",
			"font-size",
			"font-style",
			"font-variant",
			"font-weight",
			"color"
		};

		public static readonly string[] string_1 = new string[16]
		{
			"border",
			"border-color",
			"border-style",
			"border-width",
			"border-left-color",
			"border-left-style",
			"border-left-width",
			"border-top-color",
			"border-top-style",
			"border-top-width",
			"border-right-color",
			"border-right-style",
			"border-right-width",
			"border-bottom-color",
			"border-bottom-style",
			"border-bottom-width"
		};

		public static readonly string[] string_2 = new string[5]
		{
			"padding",
			"padding-left",
			"padding-top",
			"padding-right",
			"padding-bottom"
		};

		public static readonly string[] string_3 = new string[5]
		{
			"margin",
			"margin-left",
			"margin-top",
			"margin-right",
			"margin-bottom"
		};

		public static readonly string[] string_4 = new string[8]
		{
			"background",
			"background-attachment",
			"background-color",
			"background-image",
			"background-position",
			"background-position-x",
			"background-position-y",
			"background-repeat"
		};

		protected GClass163 gclass163_0 = null;

		public GClass222 method_0()
		{
			GClass222 gClass = new GClass222();
			gClass.gclass242_0 = gclass242_0.method_0();
			gClass.gclass163_0 = gclass163_0;
			return gClass;
		}

		public string method_1(string string_5)
		{
			return method_5(string_5);
		}

		public void method_2(string string_5, string string_6)
		{
			method_10(string_5, string_6);
		}

		public GClass242 method_3()
		{
			return gclass242_0;
		}

		public bool method_4(string string_5)
		{
			return method_3().method_2(string_5);
		}

		public string method_5(string string_5)
		{
			return method_3().method_5(string_5);
		}

		public void method_6(string string_5)
		{
			method_3().method_3(string_5);
		}

		public void method_7(string[] string_5)
		{
			method_3().method_4(string_5);
		}

		public void method_8(GClass222 gclass222_0, bool bool_0, string[] string_5)
		{
			if (gclass222_0 != null && gclass222_0 != this)
			{
				foreach (GClass229 item in gclass222_0.method_3())
				{
					if (string_5 != null)
					{
						bool flag = false;
						foreach (string a in string_5)
						{
							if (string.Equals(a, item.string_0, StringComparison.CurrentCultureIgnoreCase))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
					}
					if (bool_0)
					{
						method_10(item.string_0, item.string_1);
					}
					else if (!method_3().method_2(item.string_0))
					{
						method_3().method_6(item.string_0, item.string_1);
					}
				}
			}
		}

		public void method_9(GClass222 gclass222_0, bool bool_0)
		{
			if (gclass222_0 != null && gclass222_0 != this)
			{
				foreach (GClass229 item in gclass222_0.method_3())
				{
					if (bool_0)
					{
						method_10(item.string_0, item.string_1);
					}
					else if (!method_3().method_2(item.string_0))
					{
						method_3().method_6(item.string_0, item.string_1);
					}
				}
			}
		}

		public void method_10(string string_5, string string_6)
		{
			if (string_6 == null || string_6.Trim().Length == 0)
			{
				gclass242_0.method_3(string_5);
			}
			else
			{
				gclass242_0.method_6(string_5, string_6);
			}
		}

		public string method_11()
		{
			int num = 13;
			if (gclass242_0.Count == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (GClass229 item in gclass242_0)
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(" ; ");
				}
				stringBuilder.Append(item.string_0);
				stringBuilder.Append(':');
				stringBuilder.Append(item.string_1);
			}
			return stringBuilder.ToString();
		}

		public void method_12(string string_5)
		{
			int num = 18;
			gclass242_0.Clear();
			if (string_5 == null)
			{
				return;
			}
			string[] array = string_5.Split(";".ToCharArray());
			string[] array2 = array;
			foreach (string text in array2)
			{
				int num2 = text.IndexOf(":");
				if (num2 > 0 && num2 < text.Length - 1)
				{
					gclass242_0.method_6(text.Substring(0, num2).Trim().ToLower(), text.Substring(num2 + 1));
				}
			}
		}

		public GClass163 method_13()
		{
			return gclass163_0;
		}

		public void method_14(GClass163 gclass163_1)
		{
			gclass163_0 = gclass163_1;
		}

		public string method_15()
		{
			return method_5("accelerator");
		}

		public void method_16(string string_5)
		{
			method_10("accelerator", string_5);
		}

		public string method_17()
		{
			return method_5("background");
		}

		public void method_18(string string_5)
		{
			method_10("background", string_5);
		}

		public string method_19()
		{
			return method_5("background-attachment");
		}

		public void method_20(string string_5)
		{
			method_10("background-attachment", string_5);
		}

		public string method_21()
		{
			return method_5("background-color");
		}

		public void method_22(string string_5)
		{
			method_10("background-color", string_5);
		}

		public string method_23()
		{
			return method_5("background-image");
		}

		public void method_24(string string_5)
		{
			method_10("background-image", string_5);
		}

		public string method_25()
		{
			return method_5("background-position");
		}

		public void method_26(string string_5)
		{
			method_10("background-position", string_5);
		}

		public string method_27()
		{
			return method_5("background-position-x");
		}

		public void method_28(string string_5)
		{
			method_10("background-position-x", string_5);
		}

		public string method_29()
		{
			return method_5("background-position-y");
		}

		public void method_30(string string_5)
		{
			method_10("background-position-y", string_5);
		}

		public string method_31()
		{
			return method_5("background-repeat");
		}

		public void method_32(string string_5)
		{
			method_10("background-repeat", string_5);
		}

		public string method_33()
		{
			return method_5("behavior");
		}

		public void method_34(string string_5)
		{
			method_10("behavior", string_5);
		}

		public string method_35()
		{
			return method_5("border");
		}

		public void method_36(string string_5)
		{
			method_10("border", string_5);
		}

		public string method_37()
		{
			return method_5("border-bottom");
		}

		public void method_38(string string_5)
		{
			method_10("border-bottom", string_5);
		}

		public string method_39()
		{
			return method_5("border-bottom-color");
		}

		public void method_40(string string_5)
		{
			method_10("border-bottom-color", string_5);
		}

		public string method_41()
		{
			return method_5("border-bottom-style");
		}

		public void method_42(string string_5)
		{
			method_10("border-bottom-style", string_5);
		}

		public string method_43()
		{
			return method_5("border-bottom-width");
		}

		public void method_44(string string_5)
		{
			method_10("border-bottom-width", string_5);
		}

		public string method_45()
		{
			return method_5("border-collapse");
		}

		public void method_46(string string_5)
		{
			method_10("border-collapse", string_5);
		}

		public string method_47()
		{
			return method_5("border-color");
		}

		public void method_48(string string_5)
		{
			method_10("border-color", string_5);
		}

		public string method_49()
		{
			return method_5("border-left");
		}

		public void method_50(string string_5)
		{
			method_10("border-left", string_5);
		}

		public string method_51()
		{
			return method_5("border-left-color");
		}

		public void method_52(string string_5)
		{
			method_10("border-left-color", string_5);
		}

		public string method_53()
		{
			return method_5("border-left-style");
		}

		public void method_54(string string_5)
		{
			method_10("border-left-style", string_5);
		}

		public string method_55()
		{
			return method_5("border-left-width");
		}

		public void method_56(string string_5)
		{
			method_10("border-left-width", string_5);
		}

		public string method_57()
		{
			return method_5("border-right");
		}

		public void method_58(string string_5)
		{
			method_10("border-right", string_5);
		}

		public string method_59()
		{
			return method_5("border-right-color");
		}

		public void method_60(string string_5)
		{
			method_10("border-right-color", string_5);
		}

		public string method_61()
		{
			return method_5("border-right-style");
		}

		public void method_62(string string_5)
		{
			method_10("border-right-style", string_5);
		}

		public string method_63()
		{
			return method_5("border-right-width");
		}

		public void method_64(string string_5)
		{
			method_10("border-right-width", string_5);
		}

		public string method_65()
		{
			return method_5("border-style");
		}

		public void method_66(string string_5)
		{
			method_10("border-style", string_5);
		}

		public string method_67()
		{
			return method_5("border-top");
		}

		public void method_68(string string_5)
		{
			method_10("border-top", string_5);
		}

		public string method_69()
		{
			return method_5("border-top-color");
		}

		public void method_70(string string_5)
		{
			method_10("border-top-color", string_5);
		}

		public string method_71()
		{
			return method_5("border-top-style");
		}

		public void method_72(string string_5)
		{
			method_10("border-top-style", string_5);
		}

		public string method_73()
		{
			return method_5("border-top-width");
		}

		public void method_74(string string_5)
		{
			method_10("border-top-width", string_5);
		}

		public string method_75()
		{
			return method_5("border-width");
		}

		public void method_76(string string_5)
		{
			method_10("border-width", string_5);
		}

		public string method_77()
		{
			return method_5("bottom");
		}

		public void method_78(string string_5)
		{
			method_10("bottom", string_5);
		}

		public string method_79()
		{
			return method_5("clear");
		}

		public void method_80(string string_5)
		{
			method_10("clear", string_5);
		}

		public string method_81()
		{
			return method_5("clip");
		}

		public void method_82(string string_5)
		{
			method_10("clip", string_5);
		}

		public string method_83()
		{
			return method_5("color");
		}

		public void method_84(string string_5)
		{
			method_10("color", string_5);
		}

		public string method_85()
		{
			return method_5("cursor");
		}

		public void method_86(string string_5)
		{
			method_10("cursor", string_5);
		}

		public string method_87()
		{
			return method_5("direction");
		}

		public void method_88(string string_5)
		{
			method_10("direction", string_5);
		}

		public string method_89()
		{
			return method_5("display");
		}

		public void method_90(string string_5)
		{
			method_10("display", string_5);
		}

		public string method_91()
		{
			return method_5("filter");
		}

		public void method_92(string string_5)
		{
			method_10("filter", string_5);
		}

		public string method_93()
		{
			return method_5("font");
		}

		public void method_94(string string_5)
		{
			method_10("font", string_5);
		}

		public string method_95()
		{
			return method_5("font-family");
		}

		public void method_96(string string_5)
		{
			method_10("font-family", string_5);
		}

		public string method_97()
		{
			return method_5("font-size");
		}

		public void method_98(string string_5)
		{
			method_10("font-size", string_5);
		}

		public string method_99()
		{
			return method_5("font-style");
		}

		public void method_100(string string_5)
		{
			method_10("font-style", string_5);
		}

		public string method_101()
		{
			return method_5("font-variant");
		}

		public void method_102(string string_5)
		{
			method_10("font-variant", string_5);
		}

		public string method_103()
		{
			return method_5("font-weight");
		}

		public void method_104(string string_5)
		{
			method_10("font-weight", string_5);
		}

		public string method_105()
		{
			return method_5("height");
		}

		public void method_106(string string_5)
		{
			method_10("height", string_5);
		}

		public string method_107()
		{
			return method_5("ime-mode");
		}

		public void method_108(string string_5)
		{
			method_10("ime-mode", string_5);
		}

		public string method_109()
		{
			return method_5("layout-flow");
		}

		public void method_110(string string_5)
		{
			method_10("layout-flow", string_5);
		}

		public string method_111()
		{
			return method_5("layout-grid");
		}

		public void method_112(string string_5)
		{
			method_10("layout-grid", string_5);
		}

		public string method_113()
		{
			return method_5("layout-grid-char");
		}

		public void method_114(string string_5)
		{
			method_10("layout-grid-char", string_5);
		}

		public string method_115()
		{
			return method_5("layout-grid-line");
		}

		public void method_116(string string_5)
		{
			method_10("layout-grid-line", string_5);
		}

		public string method_117()
		{
			return method_5("layout-grid-mode");
		}

		public void method_118(string string_5)
		{
			method_10("layout-grid-mode", string_5);
		}

		public string method_119()
		{
			return method_5("layout-grid-type");
		}

		public void method_120(string string_5)
		{
			method_10("layout-grid-type", string_5);
		}

		public string method_121()
		{
			return method_5("left");
		}

		public void method_122(string string_5)
		{
			method_10("left", string_5);
		}

		public string method_123()
		{
			return method_5("letter-spacing");
		}

		public void method_124(string string_5)
		{
			method_10("letter-spacing", string_5);
		}

		public string method_125()
		{
			return method_5("line-break");
		}

		public void method_126(string string_5)
		{
			method_10("line-break", string_5);
		}

		public string method_127()
		{
			return method_5("line-height");
		}

		public void method_128(string string_5)
		{
			method_10("line-height", string_5);
		}

		public string method_129()
		{
			return method_5("list-style");
		}

		public void method_130(string string_5)
		{
			method_10("list-style", string_5);
		}

		public string method_131()
		{
			return method_5("list-style-image");
		}

		public void method_132(string string_5)
		{
			method_10("list-style-image", string_5);
		}

		public string method_133()
		{
			return method_5("list-style-position");
		}

		public void method_134(string string_5)
		{
			method_10("list-style-position", string_5);
		}

		public string method_135()
		{
			return method_5("list-style-type");
		}

		public void method_136(string string_5)
		{
			method_10("list-style-type", string_5);
		}

		public string method_137()
		{
			return method_5("margin");
		}

		public void method_138(string string_5)
		{
			method_10("margin", string_5);
		}

		public string method_139()
		{
			return method_5("margin-bottom");
		}

		public void method_140(string string_5)
		{
			method_10("margin-bottom", string_5);
		}

		public string method_141()
		{
			return method_5("margin-left");
		}

		public void method_142(string string_5)
		{
			method_10("margin-left", string_5);
		}

		public string method_143()
		{
			return method_5("margin-right");
		}

		public void method_144(string string_5)
		{
			method_10("margin-right", string_5);
		}

		public string method_145()
		{
			return method_5("margin-top");
		}

		public void method_146(string string_5)
		{
			method_10("margin-top", string_5);
		}

		public string method_147()
		{
			return method_5("media");
		}

		public void method_148(string string_5)
		{
			method_10("media", string_5);
		}

		public string method_149()
		{
			return method_5("min-height");
		}

		public void method_150(string string_5)
		{
			method_10("min-height", string_5);
		}

		public string method_151()
		{
			return method_5("overflow");
		}

		public void method_152(string string_5)
		{
			method_10("overflow", string_5);
		}

		public string method_153()
		{
			return method_5("overflow-x");
		}

		public void method_154(string string_5)
		{
			method_10("overflow-x", string_5);
		}

		public string method_155()
		{
			return method_5("overflow-y");
		}

		public void method_156(string string_5)
		{
			method_10("overflow-y", string_5);
		}

		public string method_157()
		{
			return method_5("padding");
		}

		public void method_158(string string_5)
		{
			method_10("padding", string_5);
		}

		public string method_159()
		{
			return method_5("padding-bottom");
		}

		public void method_160(string string_5)
		{
			method_10("padding-bottom", string_5);
		}

		public string method_161()
		{
			return method_5("padding-left");
		}

		public void method_162(string string_5)
		{
			method_10("padding-left", string_5);
		}

		public string method_163()
		{
			return method_5("padding-right");
		}

		public void method_164(string string_5)
		{
			method_10("padding-right", string_5);
		}

		public string method_165()
		{
			return method_5("padding-top");
		}

		public void method_166(string string_5)
		{
			method_10("padding-top", string_5);
		}

		public string method_167()
		{
			return method_5("pageBreakAfter");
		}

		public void method_168(string string_5)
		{
			method_10("pageBreakAfter", string_5);
		}

		public string method_169()
		{
			return method_5("pageBreakBefore");
		}

		public void method_170(string string_5)
		{
			method_10("pageBreakBefore", string_5);
		}

		public string method_171()
		{
			return method_5("position");
		}

		public void method_172(string string_5)
		{
			method_10("position", string_5);
		}

		public string method_173()
		{
			return method_5("right");
		}

		public void method_174(string string_5)
		{
			method_10("right", string_5);
		}

		public string method_175()
		{
			return method_5("ruby-align");
		}

		public void method_176(string string_5)
		{
			method_10("ruby-align", string_5);
		}

		public string method_177()
		{
			return method_5("ruby-overhang");
		}

		public void method_178(string string_5)
		{
			method_10("ruby-overhang", string_5);
		}

		public string method_179()
		{
			return method_5("ruby-position");
		}

		public void method_180(string string_5)
		{
			method_10("ruby-position", string_5);
		}

		public string method_181()
		{
			return method_5("scrollbar-3dlight-color");
		}

		public void method_182(string string_5)
		{
			method_10("scrollbar-3dlight-color", string_5);
		}

		public string method_183()
		{
			return method_5("scrollbar-arrow-color");
		}

		public void method_184(string string_5)
		{
			method_10("scrollbar-arrow-color", string_5);
		}

		public string method_185()
		{
			return method_5("scrollbar-base-color");
		}

		public void method_186(string string_5)
		{
			method_10("scrollbar-base-color", string_5);
		}

		public string method_187()
		{
			return method_5("scrollbar-darkshadow-color");
		}

		public void method_188(string string_5)
		{
			method_10("scrollbar-darkshadow-color", string_5);
		}

		public string method_189()
		{
			return method_5("scrollbar-face-color");
		}

		public void method_190(string string_5)
		{
			method_10("scrollbar-face-color", string_5);
		}

		public string method_191()
		{
			return method_5("scrollbar-highlight-color");
		}

		public void method_192(string string_5)
		{
			method_10("scrollbar-highlight-color", string_5);
		}

		public string method_193()
		{
			return method_5("scrollbar-shadow-color");
		}

		public void method_194(string string_5)
		{
			method_10("scrollbar-shadow-color", string_5);
		}

		public string method_195()
		{
			return method_5("scrollbar-track-color");
		}

		public void method_196(string string_5)
		{
			method_10("scrollbar-track-color", string_5);
		}

		public string method_197()
		{
			return method_5("float");
		}

		public void method_198(string string_5)
		{
			method_10("float", string_5);
		}

		public string method_199()
		{
			return method_5("table-layout");
		}

		public void method_200(string string_5)
		{
			method_10("table-layout", string_5);
		}

		public string method_201()
		{
			return method_5("text-align");
		}

		public void method_202(string string_5)
		{
			method_10("text-align", string_5);
		}

		public string method_203()
		{
			return method_5("text-align-last");
		}

		public void method_204(string string_5)
		{
			method_10("text-align-last", string_5);
		}

		public string method_205()
		{
			return method_5("text-autospace");
		}

		public void method_206(string string_5)
		{
			method_10("text-autospace", string_5);
		}

		public string method_207()
		{
			return method_5("text-decoration");
		}

		public void method_208(string string_5)
		{
			method_10("text-decoration", string_5);
		}

		public string method_209()
		{
			return method_5("text-indent");
		}

		public void method_210(string string_5)
		{
			method_10("text-indent", string_5);
		}

		public string method_211()
		{
			return method_5("text-justify");
		}

		public void method_212(string string_5)
		{
			method_10("text-justify", string_5);
		}

		public string method_213()
		{
			return method_5("text-kashida-space");
		}

		public void method_214(string string_5)
		{
			method_10("text-kashida-space", string_5);
		}

		public string method_215()
		{
			return method_5("text-overflow");
		}

		public void method_216(string string_5)
		{
			method_10("text-overflow", string_5);
		}

		public string method_217()
		{
			return method_5("text-transform");
		}

		public void method_218(string string_5)
		{
			method_10("text-transform", string_5);
		}

		public string method_219()
		{
			return method_5("text-underline-position");
		}

		public void method_220(string string_5)
		{
			method_10("text-underline-position", string_5);
		}

		public string method_221()
		{
			return method_5("top");
		}

		public void method_222(string string_5)
		{
			method_10("top", string_5);
		}

		public string method_223()
		{
			return method_5("unicode-bidi");
		}

		public void method_224(string string_5)
		{
			method_10("unicode-bidi", string_5);
		}

		public string method_225()
		{
			return method_5("vertical-align");
		}

		public void method_226(string string_5)
		{
			method_10("vertical-align", string_5);
		}

		public string method_227()
		{
			return method_5("visibility");
		}

		public void method_228(string string_5)
		{
			method_10("visibility", string_5);
		}

		public string method_229()
		{
			return method_5("white-space");
		}

		public void method_230(string string_5)
		{
			method_10("white-space", string_5);
		}

		public string method_231()
		{
			return method_5("width");
		}

		public void method_232(string string_5)
		{
			method_10("width", string_5);
		}

		public string method_233()
		{
			return method_5("word-break");
		}

		public void method_234(string string_5)
		{
			method_10("word-break", string_5);
		}

		public string method_235()
		{
			return method_5("word-spacing");
		}

		public void method_236(string string_5)
		{
			method_10("word-spacing", string_5);
		}

		public string method_237()
		{
			return method_5("word-wrap");
		}

		public void method_238(string string_5)
		{
			method_10("word-wrap", string_5);
		}

		public string method_239()
		{
			return method_5("writing-mode");
		}

		public void method_240(string string_5)
		{
			method_10("writing-mode", string_5);
		}

		public string method_241()
		{
			return method_5("z-index");
		}

		public void method_242(string string_5)
		{
			method_10("z-index", string_5);
		}

		public string method_243()
		{
			return method_5("zoom");
		}

		public void method_244(string string_5)
		{
			method_10("zoom", string_5);
		}
	}
}
