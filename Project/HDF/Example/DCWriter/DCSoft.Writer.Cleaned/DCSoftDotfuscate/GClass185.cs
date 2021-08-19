using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass185 : GClass164
	{
		private GClass228 gclass228_1 = new GClass228();

		public override string TagName => "TABLE";

		public override void vmethod_1()
		{
			GClass228 gClass = new GClass228();
			GClass228 gClass2 = new GClass228();
			foreach (GClass163 item in vmethod_2())
			{
				if (item is GClass190)
				{
					gClass.method_6(item);
				}
				else if (item is GClass173)
				{
					GClass173 gClass4 = (GClass173)item;
					foreach (GClass163 item2 in gClass4.vmethod_2())
					{
						if (item2 is GClass203)
						{
							gClass2.method_6(item2);
						}
						else if (item2 is GClass190)
						{
							gClass.method_6(item2);
						}
					}
				}
				else if (item is GClass192)
				{
					GClass192 gClass6 = (GClass192)item;
					foreach (GClass163 item3 in gClass6.vmethod_2())
					{
						if (item3 is GClass203)
						{
							gClass2.method_6(item3);
						}
					}
				}
			}
			foreach (GClass163 item4 in gclass228_1)
			{
				if (item4 is GClass203)
				{
					gClass2.method_6(item4);
				}
			}
			gclass228_0 = gClass;
			gclass228_1 = gClass2;
			foreach (GClass163 item5 in vmethod_2())
			{
				item5.vmethod_1();
			}
		}

		public string method_50()
		{
			return method_9("border");
		}

		public void method_51(string string_0)
		{
			method_11("border", string_0);
		}

		public string method_52()
		{
			return method_9("bordercolor");
		}

		public void method_53(string string_0)
		{
			method_11("bordercolor", string_0);
		}

		public string method_54()
		{
			return method_9("bgcolor");
		}

		public void method_55(string string_0)
		{
			method_11("bgcolor", string_0);
		}

		public string method_56()
		{
			return method_9("cellpadding");
		}

		public void method_57(string string_0)
		{
			method_11("cellpadding", string_0);
		}

		public string method_58()
		{
			return method_9("cellspacing");
		}

		public void method_59(string string_0)
		{
			method_11("cellspacing", string_0);
		}

		public string method_60()
		{
			return method_9("rules");
		}

		public void method_61(string string_0)
		{
			method_11("rules", string_0);
		}

		public string method_62()
		{
			return method_9("align");
		}

		public void method_63(string string_0)
		{
			method_11("align", string_0);
		}

		public string method_64()
		{
			return method_9("background");
		}

		public void method_65(string string_0)
		{
			method_11("background", string_0);
		}

		public string method_66()
		{
			return method_9("width");
		}

		public void method_67(string string_0)
		{
			method_11("width", string_0);
		}

		public string method_68()
		{
			return method_9("height");
		}

		public void method_69(string string_0)
		{
			method_11("height", string_0);
		}

		public int method_70()
		{
			return gclass228_0.Count;
		}

		public int method_71()
		{
			return gclass228_1.Count;
		}

		public GClass228 method_72()
		{
			return gclass228_0;
		}

		public GClass228 method_73()
		{
			return gclass228_1;
		}

		public override bool AppendChild(GClass163 gclass163_0)
		{
			int num = 5;
			if (gclass163_0.TagName == "TR" || gclass163_0.TagName == "TBODY" || gclass163_0.TagName == "COLGROUP")
			{
				gclass228_0.method_6(gclass163_0);
			}
			else
			{
				gclass228_1.method_6(gclass163_0);
			}
			gclass163_0.method_40(this);
			gclass163_0.method_7(htmldocument_0);
			return true;
		}

		protected override bool vmethod_12(XmlWriter xmlWriter_0)
		{
			foreach (GClass203 item in gclass228_1)
			{
				item.Write(xmlWriter_0);
			}
			foreach (GClass163 item2 in gclass228_0)
			{
				item2.Write(xmlWriter_0);
			}
			return true;
		}

		internal override bool CheckChildTagName(string strName)
		{
			int num = 8;
			int result;
			switch (strName)
			{
			default:
				result = ((strName == "COLGROUP") ? 1 : 0);
				break;
			case "TR":
			case "COL":
			case "TBODY":
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}
}
