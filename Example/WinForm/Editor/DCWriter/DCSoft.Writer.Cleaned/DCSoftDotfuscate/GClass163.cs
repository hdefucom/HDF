using DCSoft.HtmlDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass163
	{
		protected GClass242 gclass242_0 = new GClass242();

		protected GClass164 gclass164_0;

		protected HTMLDocument htmldocument_0;

		protected GClass222 gclass222_0;

		private GClass222 gclass222_1 = null;

		public virtual string InnerText => vmethod_7();

		public virtual string TagName => null;

		public GClass222 method_0()
		{
			int num = 13;
			if (gclass222_0 == null)
			{
				gclass222_0 = new GClass222();
				gclass222_0.method_14(this);
				gclass222_0.method_12(method_9("style"));
			}
			return gclass222_0;
		}

		public bool method_1()
		{
			int num = 14;
			if (string.Compare(method_2().method_89(), "hidden", ignoreCase: true) == 0)
			{
				return false;
			}
			if (string.Compare(method_2().method_227(), "hidden", ignoreCase: true) == 0)
			{
				return false;
			}
			return true;
		}

		public GClass222 method_2()
		{
			if (gclass222_1 == null)
			{
				method_3();
			}
			return gclass222_1;
		}

		public void method_3()
		{
			int num = 7;
			gclass222_1 = new GClass222();
			HTMLDocument hTMLDocument = method_6();
			List<string> list = null;
			if (!string.IsNullOrEmpty(method_35()))
			{
				string[] array = method_35().Split(' ');
				list = new List<string>();
				string[] array2 = array;
				foreach (string text in array2)
				{
					string text2 = text.Trim();
					if (text2.Length > 0 && list.Contains(text2))
					{
						list.Add(text2);
					}
				}
			}
			foreach (GClass212 allStyle in hTMLDocument.AllStyles)
			{
				foreach (GClass223 item in allStyle.method_46())
				{
					string[] array2 = item.method_245();
					foreach (string strA in array2)
					{
						if (string.Compare(strA, "#" + TagName, ignoreCase: true) == 0)
						{
							gclass222_1.method_9(item, bool_0: true);
							break;
						}
						if (list != null)
						{
							bool flag = false;
							foreach (string item2 in list)
							{
								if (string.Compare(strA, "." + item2, ignoreCase: true) == 0)
								{
									gclass222_1.method_9(item, bool_0: true);
									flag = true;
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
					}
				}
			}
			List<GClass163> list2 = new List<GClass163>();
			GClass163 gClass2 = method_39();
			while (gClass2 != null && gClass2 != hTMLDocument)
			{
				list2.Insert(0, gClass2);
				gClass2 = gClass2.method_39();
			}
			foreach (GClass163 item3 in list2)
			{
				item3.method_2();
				foreach (GClass229 item4 in item3.method_2().method_3())
				{
					if (item4.string_0 != null)
					{
						string text3 = item4.string_0.Trim().ToLower();
						int num2;
						switch (text3)
						{
						default:
							num2 = ((!(text3 == "font-weight")) ? 1 : 0);
							break;
						case "font":
						case "font-family":
						case "font-size":
						case "color":
						case "font-style":
							num2 = 0;
							break;
						}
						if (num2 == 0)
						{
							gclass222_1.method_3().method_6(text3, item4.string_1);
						}
					}
				}
			}
			string text4 = method_9("style");
			if (!string.IsNullOrEmpty(text4))
			{
				gclass222_0 = new GClass222();
				gclass222_0.method_12(text4);
				gclass222_1.method_9(gclass222_0, bool_0: true);
			}
		}

		public string method_4()
		{
			if (gclass222_0 == null)
			{
				return null;
			}
			return gclass222_0.method_11();
		}

		public void method_5(string string_0)
		{
			if (string_0 == null)
			{
				gclass222_0 = null;
			}
			else
			{
				gclass222_0.method_12(string_0);
			}
		}

		public virtual void vmethod_0(string string_0)
		{
			vmethod_8(string_0);
		}

		public HTMLDocument method_6()
		{
			return htmldocument_0;
		}

		public void method_7(HTMLDocument htmldocument_1)
		{
			htmldocument_0 = htmldocument_1;
		}

		public GClass242 method_8()
		{
			return gclass242_0;
		}

		public string method_9(string string_0)
		{
			return gclass242_0.method_5(string_0);
		}

		public string method_10(string string_0)
		{
			string text = method_8().method_5(string_0);
			if (text == null)
			{
				return text;
			}
			return text.Trim();
		}

		public void method_11(string string_0, string string_1)
		{
			if (string_1 == null || string_1.Trim().Length == 0)
			{
				gclass242_0.method_3(string_0);
			}
			else
			{
				gclass242_0.method_6(string_0, string_1);
			}
		}

		public void method_12(string string_0)
		{
			gclass242_0.method_3(string_0);
		}

		public bool method_13(string string_0)
		{
			return gclass242_0.method_2(string_0);
		}

		public bool method_14(string string_0)
		{
			return gclass242_0.method_2(string_0);
		}

		public void method_15(string string_0, bool bool_0)
		{
			int num = 4;
			if (bool_0)
			{
				gclass242_0.method_6(string_0, "1");
			}
			else
			{
				gclass242_0.method_3(string_0);
			}
		}

		public void method_16()
		{
			gclass242_0.Clear();
			gclass222_0 = null;
		}

		public virtual void vmethod_1()
		{
		}

		public virtual bool AppendChild(GClass163 gclass163_0)
		{
			return false;
		}

		public virtual GClass228 vmethod_2()
		{
			return null;
		}

		public string method_17()
		{
			return method_9("onclick");
		}

		public void method_18(string string_0)
		{
			method_11("onclick", string_0);
		}

		public string method_19()
		{
			return method_9("onmousedown");
		}

		public void method_20(string string_0)
		{
			method_11("onmousedown", string_0);
		}

		public string method_21()
		{
			return method_9("onmouseenter");
		}

		public void method_22(string string_0)
		{
			method_11("onmouseenter", string_0);
		}

		public string method_23()
		{
			return method_9("onmouseover");
		}

		public void method_24(string string_0)
		{
			method_11("onmouseover", string_0);
		}

		public string method_25()
		{
			return method_9("onmouseleave");
		}

		public void method_26(string string_0)
		{
			method_11("onmouseleave", string_0);
		}

		public string method_27()
		{
			return method_9("onmouseup");
		}

		public void method_28(string string_0)
		{
			method_11("onmouseup", string_0);
		}

		public string method_29()
		{
			return method_9("onmousewheel");
		}

		public void method_30(string string_0)
		{
			method_11("onmousewheel", string_0);
		}

		public string method_31()
		{
			return method_9("onblur");
		}

		public void method_32(string string_0)
		{
			method_11("onblur", string_0);
		}

		public string method_33()
		{
			return method_9("accesskey");
		}

		public void method_34(string string_0)
		{
			method_11("accesskey", string_0);
		}

		public string method_35()
		{
			return method_9("class");
		}

		public void method_36(string string_0)
		{
			method_11("class", string_0);
		}

		public string method_37()
		{
			return method_9("id");
		}

		public void method_38(string string_0)
		{
			method_11("id", string_0);
		}

		internal virtual bool vmethod_3(GClass164 gclass164_1)
		{
			return true;
		}

		public GClass164 method_39()
		{
			if (gclass164_0 == this)
			{
				return null;
			}
			return gclass164_0;
		}

		public void method_40(GClass164 gclass164_1)
		{
			gclass164_0 = gclass164_1;
			if (gclass164_1 != null)
			{
				htmldocument_0 = gclass164_1.method_6();
			}
		}

		public GClass163 method_41()
		{
			if (gclass164_0 == null)
			{
				return null;
			}
			return gclass164_0.method_48(this);
		}

		public GClass163 method_42()
		{
			if (gclass164_0 == null)
			{
				return null;
			}
			return gclass164_0.method_49(this);
		}

		public string method_43()
		{
			string tagName = TagName;
			if (tagName != null)
			{
				return tagName.Trim().ToLower();
			}
			return tagName;
		}

		public virtual string vmethod_4()
		{
			return null;
		}

		public virtual void vmethod_5(string string_0)
		{
		}

		protected virtual bool vmethod_6()
		{
			return false;
		}

		public virtual string vmethod_7()
		{
			return null;
		}

		public virtual void vmethod_8(string string_0)
		{
		}

		protected virtual bool vmethod_9()
		{
			int num = 17;
			string tagName = TagName;
			int num2;
			switch (tagName)
			{
			default:
				num2 = ((!(tagName == "PARAM")) ? 1 : 0);
				break;
			case "INPUT":
			case "SOURCE":
			case "IMG":
			case "BR":
			case "COL":
			case "AREA":
			case "META":
				num2 = 0;
				break;
			}
			if (num2 == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool Read(Class171 myReader)
		{
			vmethod_10(myReader);
			if (!vmethod_9())
			{
				return true;
			}
			if (!myReader.method_5())
			{
				return vmethod_11(myReader);
			}
			return false;
		}

		internal virtual void vmethod_10(Class171 class171_0)
		{
			int num = 6;
			string text = null;
			string text2 = null;
			while (!class171_0.method_5())
			{
				class171_0.method_25();
				if (!class171_0.method_8("/>"))
				{
					if (class171_0.method_7() != '>')
					{
						if (class171_0.method_7() == '<')
						{
							break;
						}
						text = class171_0.method_29();
						if (text == null)
						{
							break;
						}
						text = text.ToLower();
						class171_0.method_25();
						if (class171_0.method_5() || class171_0.method_7() != '=')
						{
							text2 = "1";
						}
						else
						{
							class171_0.method_17();
							text2 = class171_0.method_31();
						}
						if (XmlReader.IsName(text))
						{
							method_11(text, text2);
						}
						continue;
					}
					class171_0.method_17();
					break;
				}
				class171_0.method_19(2);
				break;
			}
			if (method_13("style"))
			{
				gclass222_0 = new GClass222();
				gclass222_0.method_12(method_9("style"));
			}
			else
			{
				gclass222_0 = null;
			}
		}

		internal virtual bool vmethod_11(Class171 class171_0)
		{
			int num = 11;
			if (vmethod_6())
			{
				string string_ = class171_0.method_34();
				if (class171_0.method_8("</" + TagName))
				{
					class171_0.method_23('>');
				}
				vmethod_8(string_);
			}
			return true;
		}

		public virtual bool Write(XmlWriter myWriter)
		{
			int num = 8;
			if (htmldocument_0.WriteOptions.vmethod_0(this))
			{
				method_11("style", method_4());
				myWriter.WriteStartElement(TagName);
				method_44(myWriter);
				method_45(myWriter);
				vmethod_12(myWriter);
				myWriter.WriteEndElement();
			}
			else if (htmldocument_0.WriteOptions.bool_16)
			{
				vmethod_12(myWriter);
			}
			return true;
		}

		public void method_44(XmlWriter xmlWriter_0)
		{
			if (htmldocument_0.WriteOptions.bool_9)
			{
				foreach (GClass229 item in gclass242_0)
				{
					if (!item.method_2())
					{
						xmlWriter_0.WriteAttributeString(item.string_0, item.method_1());
					}
				}
			}
			else
			{
				foreach (GClass229 item2 in gclass242_0)
				{
					xmlWriter_0.WriteAttributeString(item2.string_0, item2.string_1);
				}
			}
		}

		public void method_45(XmlWriter xmlWriter_0)
		{
			int num = 9;
			if (htmldocument_0.WriteOptions.bool_9)
			{
				foreach (GClass229 item in gclass242_0)
				{
					if (item.method_2())
					{
						xmlWriter_0.WriteStartElement("xsl:attribute");
						xmlWriter_0.WriteAttributeString("name", item.string_0);
						xmlWriter_0.WriteStartElement("xsl:value-of");
						xmlWriter_0.WriteAttributeString("select", item.method_3());
						xmlWriter_0.WriteEndElement();
						xmlWriter_0.WriteEndElement();
					}
				}
			}
		}

		protected virtual bool vmethod_12(XmlWriter xmlWriter_0)
		{
			if (vmethod_6() && vmethod_7() != null)
			{
				xmlWriter_0.WriteString(vmethod_7());
			}
			return false;
		}
	}
}
