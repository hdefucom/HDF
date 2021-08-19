using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass164 : GClass163, IEnumerable
	{
		protected GClass228 gclass228_0 = new GClass228();

		public override string InnerText
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				vmethod_20(stringBuilder);
				string s = stringBuilder.ToString();
				return HttpUtility.HtmlDecode(s);
			}
		}

		public override void vmethod_1()
		{
			foreach (GClass163 item in vmethod_2())
			{
				item.vmethod_1();
			}
		}

		public override GClass228 vmethod_2()
		{
			return gclass228_0;
		}

		public override bool AppendChild(GClass163 gclass163_0)
		{
			if (gclass228_0.method_5(gclass163_0))
			{
				return true;
			}
			if (vmethod_13(gclass163_0))
			{
				return true;
			}
			if (gclass164_0 != null && gclass164_0 != this)
			{
				gclass164_0.AppendChild(gclass163_0);
			}
			return false;
		}

		internal virtual bool vmethod_13(GClass163 gclass163_0)
		{
			if (CheckChildTagName(gclass163_0.TagName) && gclass163_0.vmethod_3(this))
			{
				gclass228_0.method_6(gclass163_0);
				gclass163_0.method_40(this);
				gclass163_0.method_7(htmldocument_0);
				if (gclass163_0 is Interface0)
				{
					GClass163 gClass = this;
					while (gClass != null && !(gClass is GClass165))
					{
						gClass = gClass.method_39();
					}
					if (gClass is GClass165)
					{
						((GClass165)gClass).method_51((Interface0)gclass163_0);
					}
				}
				return true;
			}
			return false;
		}

		public virtual bool vmethod_14(GClass163 gclass163_0)
		{
			gclass228_0.method_7(gclass163_0);
			return true;
		}

		public virtual void vmethod_15()
		{
			gclass228_0.method_8();
		}

		public GClass163 method_46()
		{
			return gclass228_0.method_0();
		}

		public GClass163 method_47()
		{
			return gclass228_0.method_1();
		}

		internal GClass163 method_48(GClass163 gclass163_0)
		{
			return gclass228_0.method_2(gclass163_0);
		}

		internal GClass163 method_49(GClass163 gclass163_0)
		{
			return gclass228_0.method_3(gclass163_0);
		}

		internal virtual int vmethod_16(string string_0, GClass228 gclass228_1)
		{
			int num = 0;
			foreach (GClass163 item in gclass228_0)
			{
				if (item.TagName == string_0)
				{
					gclass228_1.method_6(item);
					num++;
				}
				if (item is GClass164)
				{
					num += ((GClass164)item).vmethod_16(string_0, gclass228_1);
				}
			}
			return num;
		}

		internal virtual int vmethod_17(string string_0, GClass228 gclass228_1)
		{
			int num = 17;
			int num2 = 0;
			foreach (GClass163 item in gclass228_0)
			{
				if (item.method_9("name") == string_0)
				{
					gclass228_1.method_6(item);
					num2++;
				}
				if (item is GClass164)
				{
					num2 += ((GClass164)item).vmethod_17(string_0, gclass228_1);
				}
			}
			return num2;
		}

		internal virtual void vmethod_18(GClass228 gclass228_1)
		{
			foreach (GClass163 item in gclass228_0)
			{
				gclass228_1.method_6(item);
				if (item is GClass164)
				{
					((GClass164)item).vmethod_18(gclass228_1);
				}
			}
		}

		internal virtual GClass163 vmethod_19(string string_0)
		{
			GClass163 gClass = null;
			foreach (GClass163 item in gclass228_0)
			{
				if (item.method_37() == string_0)
				{
					return item;
				}
				if (item is GClass164)
				{
					gClass = ((GClass164)item).vmethod_19(string_0);
					if (gClass != null)
					{
						return gClass;
					}
				}
			}
			return null;
		}

		internal virtual bool CheckChildTagName(string strName)
		{
			int num = 16;
			if (strName == "TR" || strName == "TD" || strName == "LI")
			{
				return false;
			}
			return true;
		}

		public override void vmethod_0(string string_0)
		{
			GClass216 gClass = new GClass216();
			gClass.vmethod_8(string_0);
			if (gClass.vmethod_3(this))
			{
				gClass.vmethod_8(string_0);
				gclass228_0.method_8();
				AppendChild(gClass);
			}
		}

		public virtual void vmethod_20(StringBuilder stringBuilder_0)
		{
			foreach (GClass163 item in gclass228_0)
			{
				if (item is GClass164)
				{
					((GClass164)item).vmethod_20(stringBuilder_0);
				}
				else
				{
					stringBuilder_0.Append(item.InnerText);
				}
			}
		}

		internal override bool vmethod_11(Class171 class171_0)
		{
			int num = 3;
			while (!class171_0.method_5())
			{
				string text = class171_0.method_34();
				if (text != null && CheckChildTagName("#text") && !string.IsNullOrEmpty(text))
				{
					string text2 = method_6().CompressWhitespace(text);
					if (!string.IsNullOrEmpty(text2))
					{
						GClass216 gClass = new GClass216();
						gClass.vmethod_8(text2);
						AppendChild(gClass);
					}
				}
				if (class171_0.method_5())
				{
					break;
				}
				if (class171_0.method_10() == '!')
				{
					if (class171_0.method_8("<!--"))
					{
						class171_0.method_19(4);
						text = class171_0.method_33("-->");
						if (text != null && CheckChildTagName("#comment"))
						{
							GClass215 gClass2 = new GClass215();
							gClass2.vmethod_8(text);
							AppendChild(gClass2);
						}
						class171_0.method_19(3);
					}
					else
					{
						class171_0.method_23('>');
						class171_0.method_25();
					}
					continue;
				}
				if (class171_0.method_10() == '/')
				{
					class171_0.method_19(2);
					string text3 = class171_0.method_27();
					class171_0.method_19(-2);
					if (text3 != null && vmethod_21(class171_0, text3.ToUpper()))
					{
						break;
					}
					class171_0.method_23('>');
					continue;
				}
				if (class171_0.method_10() == '?')
				{
					class171_0.method_23('>');
					continue;
				}
				class171_0.method_17();
				string text4 = class171_0.method_29();
				if (text4 == null)
				{
					continue;
				}
				text4 = text4.ToUpper();
				if (text4 == "COLGROUP")
				{
					class171_0.method_23('>');
					continue;
				}
				if (vmethod_22(text4))
				{
					if (CheckChildTagName(text4))
					{
						GClass163 gClass3 = htmldocument_0.InnerCreateElement(text4, this);
						if (gClass3 != null)
						{
							class171_0.method_25();
							AppendChild(gClass3);
							gClass3.Read(class171_0);
						}
						else
						{
							class171_0.method_32(text4);
						}
					}
					continue;
				}
				class171_0.method_20('<');
				break;
			}
			return true;
		}

		internal virtual bool vmethod_21(Class171 class171_0, string string_0)
		{
			if (string_0 == TagName || !CheckChildTagName(string_0))
			{
				class171_0.method_23('>');
				return true;
			}
			return false;
		}

		protected virtual bool vmethod_22(string string_0)
		{
			return true;
		}

		protected override bool vmethod_12(XmlWriter xmlWriter_0)
		{
			int num = 7;
			if (gclass228_0.Count > 0)
			{
				foreach (GClass163 item in gclass228_0)
				{
					item.Write(xmlWriter_0);
				}
				return true;
			}
			if (vmethod_23())
			{
				xmlWriter_0.WriteString(" ");
			}
			return false;
		}

		public IEnumerator GetEnumerator()
		{
			return gclass228_0.GetEnumerator();
		}

		protected virtual bool vmethod_23()
		{
			return true;
		}
	}
}
