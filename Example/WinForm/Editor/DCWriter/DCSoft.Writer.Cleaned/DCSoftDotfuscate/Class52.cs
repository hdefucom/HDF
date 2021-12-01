using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[Serializable]
	internal class Class52
	{
		internal enum Enum6
		{
			const_0,
			const_1,
			const_2
		}

		private string string_0 = null;

		private int int_0 = 0;

		private Class61 class61_0 = new Class61();

		private int int_1 = -1;

		private bool bool_0 = false;

		private WebWriterControlLoadDocumentOptions webWriterControlLoadDocumentOptions_0 = WebWriterControlLoadDocumentOptions.None;

		private bool bool_1 = true;

		private bool bool_2 = false;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private XWebBrowsersStyle xwebBrowsersStyle_0 = XWebBrowsersStyle.InternetExplorer;

		private string string_1 = "gb2312";

		private string string_2 = null;

		private string string_3 = null;

		private bool bool_5 = false;

		private Hashtable hashtable_0 = new Hashtable();

		private string string_4 = null;

		public QueryListItemsEventHandler queryListItemsEventHandler_0 = null;

		private Class57 class57_0 = null;

		private Enum6 enum6_0 = Enum6.const_0;

		private Dictionary<XTextDocument, string> dictionary_0 = new Dictionary<XTextDocument, string>();

		private Dictionary<XTextDocument, string> dictionary_1 = new Dictionary<XTextDocument, string>();

		private DocumentOptions documentOptions_0 = null;

		private bool bool_6 = false;

		private int int_2 = 0;

		private string string_5 = null;

		[NonSerialized]
		public GDelegate21 gdelegate21_0 = null;

		private static int int_3 = 0;

		[DefaultValue(null)]
		[Category("Appearance")]
		public string AdditionPageTitle
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		[Browsable(false)]
		public int CurrentDocumentIndex
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_4)
		{
			int_0 = int_4;
		}

		public Class61 method_2()
		{
			if (class61_0 == null)
			{
				class61_0 = new Class61();
			}
			return class61_0;
		}

		public void method_3(Class61 class61_1)
		{
			class61_0 = class61_1;
		}

		private bool method_4()
		{
			return method_2().FormView == FormViewMode.Normal || method_2().FormView == FormViewMode.Strict;
		}

		public bool method_5()
		{
			return method_2().ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable;
		}

		public bool method_6()
		{
			return bool_0;
		}

		public void method_7(bool bool_7)
		{
			bool_0 = bool_7;
		}

		public WebWriterControlLoadDocumentOptions method_8()
		{
			return webWriterControlLoadDocumentOptions_0;
		}

		public void method_9(WebWriterControlLoadDocumentOptions webWriterControlLoadDocumentOptions_1)
		{
			webWriterControlLoadDocumentOptions_0 = webWriterControlLoadDocumentOptions_1;
		}

		public bool method_10()
		{
			return bool_1;
		}

		public void method_11(bool bool_7)
		{
			bool_1 = bool_7;
		}

		public bool method_12()
		{
			return bool_2;
		}

		public void method_13(bool bool_7)
		{
			bool_2 = bool_7;
		}

		public bool method_14()
		{
			return bool_3;
		}

		public void method_15(bool bool_7)
		{
			bool_3 = bool_7;
		}

		public bool method_16()
		{
			return bool_4;
		}

		public void method_17(bool bool_7)
		{
			bool_4 = bool_7;
		}

		public XWebBrowsersStyle method_18()
		{
			return xwebBrowsersStyle_0;
		}

		public void method_19(XWebBrowsersStyle xwebBrowsersStyle_1)
		{
			xwebBrowsersStyle_0 = xwebBrowsersStyle_1;
		}

		public string method_20()
		{
			return string_1;
		}

		public void method_21(string string_6)
		{
			string_1 = string_6;
		}

		public string method_22()
		{
			return string_2;
		}

		public void method_23(string string_6)
		{
			string_2 = string_6;
		}

		public string method_24()
		{
			return string_3;
		}

		public void method_25(string string_6)
		{
			string_3 = string_6;
		}

		public bool method_26()
		{
			return bool_5;
		}

		public void method_27(bool bool_7)
		{
			bool_5 = bool_7;
		}

		public Hashtable method_28()
		{
			return hashtable_0;
		}

		public void method_29(Hashtable hashtable_1)
		{
			hashtable_0 = hashtable_1;
		}

		public string method_30()
		{
			return string_4;
		}

		public void method_31(string string_6)
		{
			string_4 = string_6;
		}

		public GClass357 method_32(Image image_0, string string_6)
		{
			if (class57_0 == null)
			{
				return null;
			}
			return class57_0.method_66(image_0, string_6);
		}

		private bool method_33()
		{
			if (method_26())
			{
				return false;
			}
			return method_2().method_16();
		}

		internal Enum6 method_34()
		{
			return enum6_0;
		}

		internal void method_35(Enum6 enum6_1)
		{
			enum6_0 = enum6_1;
		}

		public string method_36(XTextDocument xtextDocument_0)
		{
			xtextDocument_0.PageRefreshed = false;
			xtextDocument_0.CheckPageRefreshed();
			class57_0 = method_52(xtextDocument_0);
			class57_0.method_134(xtextDocument_0);
			xtextDocument_0.Body.vmethod_18(class57_0);
			return class57_0.method_34();
		}

		private void method_37(XTextDocumentList xtextDocumentList_0)
		{
			dictionary_0.Clear();
			dictionary_1.Clear();
			foreach (XTextDocument item in xtextDocumentList_0)
			{
				XPageSettings pageSettings = item.PageSettings;
				WatermarkInfo runtimeWatermark = pageSettings.RuntimeWatermark;
				if (runtimeWatermark != null && runtimeWatermark.Type == WatermarkType.Image && runtimeWatermark.RuntimeImage != null)
				{
					Image runtimeImage = runtimeWatermark.RuntimeImage;
					int num = class57_0.imethod_44(pageSettings.ViewPaperWidth - pageSettings.ViewLeftMargin - pageSettings.ViewRightMargin);
					int height = num * runtimeImage.Height / runtimeImage.Width;
					Bitmap bitmap = new Bitmap(num, height);
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.Clear(Color.White);
						graphics.DrawImage(runtimeImage, 0, 0, num, height);
					}
					GClass357 gClass = class57_0.method_66(bitmap, null);
					class57_0.method_72(gClass.method_0());
					dictionary_0[item] = gClass.method_0();
				}
				if (pageSettings.RuntimeEditTimeBackgroundImage != null && pageSettings.RuntimeEditTimeBackgroundImage.Value != null)
				{
					GClass357 gClass2 = class57_0.method_66(pageSettings.RuntimeEditTimeBackgroundImage.Value, null);
					dictionary_1[item] = gClass2.method_0();
				}
			}
		}

		private void method_38(XTextDocument xtextDocument_0)
		{
			int num = 10;
			class57_0.imethod_0("table");
			class57_0.method_19("id", "dctable_AllContent");
			class57_0.method_19("border", "0");
			class57_0.method_19("cellpadding", "0");
			class57_0.method_19("cellspacing", "0");
			class57_0.method_39();
			if (method_2().ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable)
			{
				class57_0.method_40("height", "100%");
			}
			if (method_2().ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml && xtextDocument_0.PageSettings.Landscape)
			{
				float num2 = class57_0.imethod_44(xtextDocument_0.PageSettings.ViewPaperWidth);
				float num3 = class57_0.imethod_44(xtextDocument_0.PageSettings.ViewPaperHeight);
				float num4 = (num2 - num3) / 2f;
				float num5 = 0f - num4;
				Matrix matrix = new Matrix();
				matrix.Translate(0f - num4, num4);
				matrix.RotateAt(-90f, new PointF(0f, 0f));
				string text = "matrix(" + matrix.Elements[0] + "," + matrix.Elements[1] + "," + matrix.Elements[2] + "," + matrix.Elements[3] + "," + matrix.Elements[4] + "," + matrix.Elements[5] + ")";
				text = "matrix(0,-1,1,0," + num5 + "," + num4 + ")";
				class57_0.method_40("transform", text);
				class57_0.method_40("-webkit-transform", text);
				class57_0.method_40("filter", "progid:DXImageTransform.Microsoft.BasicImage(rotation=3)");
			}
			bool flag = false;
			PageBorderBackgroundStyle runtimePageBorderBackground = xtextDocument_0.PageSettings.RuntimePageBorderBackground;
			if (runtimePageBorderBackground != null && runtimePageBorderBackground.HasVisibleBorder && runtimePageBorderBackground.BorderRange == PageBorderRangeTypes.Page)
			{
				class57_0.method_54(runtimePageBorderBackground.BorderLeft, runtimePageBorderBackground.BorderTop, runtimePageBorderBackground.BorderRight, runtimePageBorderBackground.BorderBottom, runtimePageBorderBackground.BorderColor, (int)runtimePageBorderBackground.BorderWidth, runtimePageBorderBackground.BorderStyle);
				flag = true;
			}
			if (!flag)
			{
				class57_0.method_40("border", "1px solid black");
			}
			class57_0.method_40("background-color", class57_0.method_61(method_2().method_24()));
			if (!method_33())
			{
				class57_0.method_40("border-radius", "5px");
			}
			if (!class57_0.imethod_34())
			{
				class57_0.method_40("cursor", "auto");
			}
			if (!method_2().AutoLine)
			{
				method_39(xtextDocument_0);
			}
			class57_0.method_63();
			if (flag)
			{
				class57_0.method_19("haspageborder", "true");
			}
		}

		private void method_39(XTextDocument xtextDocument_0)
		{
			int num = 8;
			string text = dictionary_1.ContainsKey(xtextDocument_0) ? dictionary_1[xtextDocument_0] : null;
			_ = xtextDocument_0.PageSettings;
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = "url(" + text + ")";
				if (class57_0.imethod_34())
				{
					text2 += " !important";
				}
				class57_0.method_40("background-image", text2);
				class57_0.method_40("background-attachment", "scroll");
				class57_0.method_40("background-repeat", "repeat");
			}
		}

		private void method_40(XTextDocument xtextDocument_0)
		{
			int num = 10;
			string text = dictionary_0.ContainsKey(xtextDocument_0) ? dictionary_0[xtextDocument_0] : null;
			_ = xtextDocument_0.PageSettings;
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = "url(" + text + ")";
				if (class57_0.imethod_34())
				{
					text2 += "!important";
				}
				class57_0.method_40("background-image", text2);
				class57_0.method_40("background-repeat", "no-repeat");
				if (class57_0.imethod_34())
				{
					class57_0.method_40("background-attachment", "scroll");
					class57_0.method_40("background-position", "center center");
				}
				else
				{
					class57_0.method_40("background-attachment", "fixed");
					class57_0.method_40("background-position", "top center");
				}
			}
		}

		private void method_41(XTextDocument xtextDocument_0, PrintPage printPage_0)
		{
			int num = 16;
			int num2 = class57_0.imethod_44(xtextDocument_0.Body.Width);
			XTextDocumentContentElement xTextDocumentContentElement = xtextDocument_0.Footer;
			if (printPage_0.FirstPageFlag)
			{
				xTextDocumentContentElement = xtextDocument_0.FooterForFirstPage;
			}
			if (!xTextDocumentContentElement.HasContentElement)
			{
				return;
			}
			class57_0.imethod_30(bool_24: true);
			class57_0.method_142(0);
			class57_0.imethod_0("div");
			class57_0.method_19("id", "divFooter");
			class57_0.imethod_33();
			class57_0.method_140(typeof(XTextDocumentFooterElement));
			class57_0.method_19("party", "footer");
			class57_0.method_143(bool_24: true);
			class57_0.method_144(bool_24: false);
			class57_0.method_39();
			if (!method_2().AutoLine && !method_26())
			{
				class57_0.method_40("width", num2 + "px");
			}
			if (xtextDocument_0.Options.BehaviorOptions.SpecifyDebugMode)
			{
				class57_0.method_40("border", "1px solid blue");
			}
			if (method_2().AutoLine)
			{
				string text = dictionary_1.ContainsKey(xtextDocument_0) ? dictionary_1[xtextDocument_0] : null;
				if (!string.IsNullOrEmpty(text))
				{
					class57_0.method_40("background-image", "url(" + text + ")");
					class57_0.method_40("background-repeat", "repeat");
					class57_0.method_40("background-attachment", "scroll");
				}
			}
			method_48();
			class57_0.method_63();
			xTextDocumentContentElement.vmethod_18(class57_0);
			class57_0.imethod_2();
		}

		private void method_42(XTextDocumentList xtextDocumentList_0)
		{
			int num = 3;
			class57_0.imethod_0("td");
			class57_0.method_19("id", "dcmContainer");
			GClass543 gClass = new GClass543();
			class57_0.method_19("width", class57_0.imethod_44(gClass.method_2() + 20f - gClass.method_8()) + "px");
			class57_0.method_39();
			class57_0.method_40("background-color", class57_0.method_61(gClass.method_6()));
			class57_0.method_40("padding-left", class57_0.imethod_44(gClass.method_8()) + "px");
			class57_0.method_63();
			for (int i = 0; i < xtextDocumentList_0.Count; i++)
			{
				XTextDocument xTextDocument = xtextDocumentList_0[i];
				class57_0.method_142(i);
				foreach (DocumentComment comment in xTextDocument.Comments)
				{
					class57_0.imethod_0("div");
					class57_0.method_19("id", class57_0.method_139(comment));
					class57_0.method_140(comment.GetType());
					class57_0.method_145(comment);
					class57_0.method_19("documentindex", i.ToString());
					class57_0.method_19("commentindex", comment.Index.ToString());
					class57_0.method_19("bkcolor", class57_0.method_61(comment.BackColor));
					class57_0.method_19("darkbkcolor", class57_0.method_61(GClass36.smethod_0(comment.BackColor)));
					class57_0.method_19("onclick", "DCDocumentCommentManager.ActiveDocumentComment(event,this,true);");
					class57_0.method_39();
					class57_0.method_40("border", "1px solid " + class57_0.method_61(comment.BorderColor));
					class57_0.method_40("background-color", class57_0.method_61(comment.BackColor));
					class57_0.method_40("border-radius", "5px");
					class57_0.method_40("font-size", xTextDocument.Options.ViewOptions.CommentFontSize + "pt");
					if (string.IsNullOrEmpty(xTextDocument.Options.ViewOptions.CommentFontName))
					{
						class57_0.method_40("font-family", Control.DefaultFont.Name);
					}
					else
					{
						class57_0.method_40("font-family", xTextDocument.Options.ViewOptions.CommentFontName);
					}
					class57_0.method_40("cursor", "default");
					class57_0.method_40("padding", class57_0.imethod_44(gClass.method_8()) + "px");
					class57_0.method_40("opacity", "0.6");
					class57_0.method_40("filter", "progid:DXImageTransform.Microsoft.Alpha(opacity=60)");
					class57_0.method_40("width", class57_0.imethod_44(gClass.method_4()) + "px");
					class57_0.method_63();
					class57_0.imethod_0("div");
					class57_0.method_19("style", "font-weight:bold;word-break:keep-all;white-space:nowrap");
					if (string.IsNullOrEmpty(xTextDocument.Options.ViewOptions.CommentDateFormatString))
					{
						class57_0.method_3(comment.Author + "," + comment.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"));
					}
					else
					{
						class57_0.method_3(comment.Author + "," + comment.CreationTime.ToString(xTextDocument.Options.ViewOptions.CommentDateFormatString));
					}
					class57_0.imethod_2();
					class57_0.imethod_0("div");
					class57_0.method_19("id", "dcmcontent" + comment.Index);
					class57_0.method_19("style", "cursor:auto");
					class57_0.method_144(!method_2().Readonly);
					class57_0.method_3(comment.Text);
					class57_0.imethod_2();
					class57_0.imethod_2();
				}
			}
			class57_0.imethod_2();
		}

		private void method_43()
		{
			class57_0.imethod_0("script");
			class57_0.method_19("language", "javascript");
			class57_0.method_3("\r\nif( window.GlobalStartDCWriterWebControlJS != null )\r\n{\r\n    GlobalStartDCWriterWebControlJS();\r\n}\r\nelse\r\n{\r\n    window.frameElement.parentNode.dcondocumentload_1 = function()\r\n    {\r\n        // 处理异步加载JS的情况\r\n        if( window.GlobalStartDCWriterWebControlJS != null ){\r\n            GlobalStartDCWriterWebControlJS();\r\n        }\r\n        else{\r\n            alert('未能加载编辑器JS功能模块(GlobalStartDCWriterWebControlJS)。');\r\n        }\r\n    };\r\n}\r\n\r\n\r\n");
			class57_0.imethod_2();
		}

		private void method_44(XTextDocument xtextDocument_0, bool bool_7, bool bool_8, int int_4, PrintPage printPage_0)
		{
			int num = 5;
			int num2 = class57_0.imethod_44(xtextDocument_0.Body.Width);
			float num3 = 0f;
			class57_0.imethod_30(bool_24: true);
			class57_0.method_142(0);
			class57_0.imethod_0("div");
			class57_0.imethod_33();
			class57_0.method_39();
			if (class57_0.method_114())
			{
				float viewHeaderDistance = xtextDocument_0.PageSettings.ViewHeaderDistance;
				class57_0.method_40("height", class57_0.imethod_44(viewHeaderDistance) + "px");
			}
			if (class57_0.imethod_34() && bool_7)
			{
				if (printPage_0 == null)
				{
					class57_0.method_40("width", class57_0.imethod_44(xtextDocument_0.Body.Width + xtextDocument_0.PageSettings.ViewRightMargin) + "px");
				}
				else
				{
					class57_0.method_40("width", class57_0.imethod_44(xtextDocument_0.Body.Width + printPage_0.ViewRightMargin) + "px");
				}
			}
			method_48();
			class57_0.method_63();
			class57_0.method_19("name", "dcHiddenElementForPrint");
			class57_0.imethod_0("span");
			class57_0.method_19("id", "lblDCWebWriterControlControlInfo");
			class57_0.imethod_33();
			class57_0.method_39();
			class57_0.method_40("position", "relative");
			class57_0.method_40("left", Convert.ToString(4f - num3) + "px");
			class57_0.method_40("top", "1px");
			class57_0.method_63();
			class57_0.method_153(AdditionPageTitle);
			if (bool_7 && method_58() > 0)
			{
				class57_0.imethod_0("span");
				class57_0.method_19("id", "divAlertSessionTimeout");
				class57_0.imethod_33();
				class57_0.method_19("timeout", method_58().ToString());
				class57_0.method_19("style", "display:none;color:red;border:1 solid black;background-color:yellow;font-size:9pt");
				class57_0.method_3(WriterStrings.AlertSessionTimeout);
				class57_0.imethod_2();
			}
			class57_0.imethod_2();
			class57_0.imethod_2();
			bool flag;
			if (flag = (!method_6() && method_16() && method_2().ContentRenderMode == WebWriterControlRenderMode.NormalHtmlEditable))
			{
				class57_0.imethod_0("div");
			}
			class57_0.imethod_0("div");
			class57_0.method_19("id", "divHeader");
			class57_0.method_19("pageindex", int_4.ToString());
			class57_0.method_140(typeof(XTextDocumentHeaderElement));
			class57_0.method_19("party", "header");
			class57_0.method_143(bool_24: true);
			class57_0.method_144(bool_24: false);
			class57_0.method_39();
			XTextDocumentContentElement xTextDocumentContentElement = xtextDocument_0.Header;
			if (printPage_0.FirstPageFlag)
			{
				xTextDocumentContentElement = xtextDocument_0.HeaderForFirstPage;
			}
			if (class57_0.method_114())
			{
				float float_ = Math.Max(xTextDocumentContentElement.Height, xtextDocument_0.PageSettings.ViewTopMargin - xtextDocument_0.PageSettings.ViewHeaderDistance);
				class57_0.method_40("height", class57_0.imethod_44(float_) + "px");
			}
			string _;
			if (dictionary_0.ContainsKey(xtextDocument_0))
			{
				_ = dictionary_0[xtextDocument_0];
			}
			else
				_ = null;
			string text = dictionary_1.ContainsKey(xtextDocument_0) ? dictionary_1[xtextDocument_0] : null;
			if (method_33() && xTextDocumentContentElement.HasContentElement)
			{
				if (flag)
				{
					class57_0.method_40("position", "fixed");
					class57_0.method_40("top", "-1px");
				}
				else
				{
					class57_0.method_40("position", "relative");
				}
				string string_ = class57_0.method_61(method_2().method_24());
				class57_0.method_40("background-color", string_);
				class57_0.method_40("z-index", "100");
				method_40(xtextDocument_0);
			}
			if (!method_2().AutoLine && !method_26())
			{
				class57_0.method_40("width", num2 + "px");
			}
			if (method_2().AutoLine && !string.IsNullOrEmpty(text))
			{
				class57_0.method_40("background-image", "url(" + text + ")");
				class57_0.method_40("background-repeat", "repeat");
				class57_0.method_40("background-attachment", "scroll");
			}
			class57_0.method_40("margin-bottom", "2px");
			method_48();
			class57_0.method_63();
			if (bool_8)
			{
			}
			class57_0.imethod_0("div");
			class57_0.method_39();
			if (xtextDocument_0.Header.HasContentElement && xtextDocument_0.Options.ViewOptions.ShowHeaderBottomLine)
			{
				class57_0.method_40("border-bottom", xtextDocument_0.Options.ViewOptions.HeaderBottomLineWidth + "px solid #888888");
			}
			class57_0.method_40("height", class57_0.imethod_44(xTextDocumentContentElement.Height) + "px");
			class57_0.method_63();
			if (xTextDocumentContentElement.HasContentElement)
			{
				xTextDocumentContentElement.vmethod_18(class57_0);
			}
			class57_0.imethod_2();
			class57_0.imethod_2();
			if (flag)
			{
				class57_0.imethod_2();
			}
		}

		private void method_45(XTextDocument xtextDocument_0, XTextDocument xtextDocument_1, int int_4, PrintPage printPage_0)
		{
			int num = 2;
			int num2 = class57_0.imethod_44(xtextDocument_0.Body.Width);
			class57_0.imethod_30(method_2().Readonly);
			class57_0.method_142(int_4);
			class57_0.imethod_0("div");
			class57_0.method_19("id", "divDocumentBody_" + int_4);
			class57_0.method_19("documenttitle", xtextDocument_1.Title);
			class57_0.method_140(typeof(XTextDocumentBodyElement));
			class57_0.method_39();
			if (method_6())
			{
				foreach (XTextElement element in xtextDocument_1.Body.Elements)
				{
					if (element is XTextSectionElement)
					{
						break;
					}
				}
			}
			if (!method_2().ShowMainDocumentBodyWhenMultiDocument && int_4 == 0)
			{
				class57_0.method_40("display", "none");
				if (xtextDocument_1.Info != null && xtextDocument_1.Info.SubDocumentSettings != null)
				{
					xtextDocument_1.Info.SubDocumentSettings.AllowSave = false;
				}
			}
			if (method_2().AutoLine || method_26())
			{
				method_39(xtextDocument_1);
				method_40(xtextDocument_1);
			}
			else
			{
				class57_0.method_40("width", num2 + "px");
			}
			bool flag = method_2().Readonly;
			if (method_2().MultiDocument && xtextDocument_1.Info.SubDocumentSettings != null)
			{
				if (xtextDocument_1.Info.SubDocumentSettings.BorderColor.A > 0)
				{
					class57_0.method_40("border", "1px solid " + class57_0.method_61(xtextDocument_1.Info.SubDocumentSettings.BorderColor));
				}
				if (xtextDocument_1.Info.SubDocumentSettings.BackColor.A > 0)
				{
					class57_0.method_40("background-color", class57_0.method_61(xtextDocument_1.Info.SubDocumentSettings.BackColor));
				}
				if (xtextDocument_1.Info.SubDocumentSettings.Readonly || xtextDocument_1.Info.SubDocumentSettings.Locked)
				{
					flag = true;
				}
				if (xtextDocument_1.Info.SubDocumentSettings.SubDocumentSpacing > 0f)
				{
					class57_0.method_40("padding-bottom", class57_0.imethod_45(xtextDocument_1.Info.SubDocumentSettings.SubDocumentSpacing) + "px");
				}
			}
			class57_0.method_63();
			if (method_2().MultiDocument && xtextDocument_1.Info.SubDocumentSettings != null)
			{
				if (xtextDocument_1.Info.SubDocumentSettings.Readonly)
				{
					class57_0.method_19("readonly", "true");
					flag = true;
				}
				if (xtextDocument_1.Info.SubDocumentSettings.Locked)
				{
					class57_0.method_19("locked", "true");
				}
			}
			if (!method_2().Readonly && !method_4() && !xtextDocument_1.Info.Readonly && !flag)
			{
				if (xtextDocument_1.Body.ContentReadonly != 0)
				{
					class57_0.method_19("contentEditable", "true");
				}
				if (method_2().method_18())
				{
					class57_0.method_19("ondragenter", "DCMultiDocumentManager.handleDocumentDragEvent(event,'ondragenter');");
					class57_0.method_19("ondragleave", "DCMultiDocumentManager.handleDocumentDragEvent(event,'ondragleave');");
					class57_0.method_19("ondragover", "DCMultiDocumentManager.handleDocumentDragEvent(event,'ondragover');");
					class57_0.method_19("ondrop", "DCMultiDocumentManager.handleDocumentDragEvent(event,'ondrop');");
				}
				else
				{
					class57_0.method_19("ondragenter", "DCDomTools.completeEvent(event);");
					class57_0.method_19("ondragleave", "DCDomTools.completeEvent(event);");
					class57_0.method_19("ondragover", "DCDomTools.completeEvent(event);");
					class57_0.method_19("ondrop", "DCDomTools.completeEvent(event);");
				}
			}
			if (method_2().AutoPostBack && printPage_0 == null)
			{
				xtextDocument_1.SerializeParameterValue = method_2().SerializeParameterValue;
				string viewStateString = DocumentViewState.GetViewStateString(xtextDocument_1);
				if (!string.IsNullOrEmpty(viewStateString))
				{
					class57_0.method_19("DCDocumentViewState", viewStateString);
				}
			}
			class57_0.method_19("currentloadoptions", method_8().ToString());
			class57_0.method_19("baseurl", method_30());
			xtextDocument_1.CurrentPage = printPage_0;
			if (printPage_0 == null)
			{
				class57_0.imethod_51(Rectangle.Empty);
				class57_0.imethod_53(RectangleF.Empty);
			}
			else
			{
				if (printPage_0.HeaderRows != null)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)printPage_0.HeaderRows[0];
					class57_0.imethod_51(Rectangle.Ceiling(printPage_0.HeaderRowsBounds));
					XTextTableElement ownerTable = xTextTableRowElement.OwnerTable;
					ownerTable.vmethod_18(class57_0);
				}
				class57_0.imethod_51(new Rectangle((int)printPage_0.Left, (int)printPage_0.Top, (int)printPage_0.Width, (int)printPage_0.Height));
				class57_0.imethod_53(new RectangleF(printPage_0.Left, printPage_0.Top, printPage_0.Width, printPage_0.StandartPapeBodyHeight));
			}
			xtextDocument_1.Body.vmethod_18(class57_0);
			class57_0.imethod_2();
		}

		private void method_46(XTextDocument xtextDocument_0)
		{
			int num = 5;
			class57_0.imethod_0("body");
			if (CurrentDocumentIndex >= 0)
			{
				class57_0.method_19("currentdocumentindex", CurrentDocumentIndex.ToString());
			}
			if (method_2().ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml)
			{
				class57_0.method_19("printhtml", "true");
				class57_0.method_19("pagesettingstylecontent", method_63(xtextDocument_0));
				if (xtextDocument_0.PageSettings.Landscape)
				{
					class57_0.method_19("landscape", "true");
				}
			}
			class57_0.method_19("controlinstanceid", method_0().ToString());
			class57_0.method_39();
			if (method_2().ContentRenderMode != WebWriterControlRenderMode.PagePreviewHtml || !xtextDocument_0.PageSettings.Landscape)
			{
			}
			if (method_26())
			{
				class57_0.method_40("margin", "0px");
				class57_0.method_40("padding", "0px");
			}
			else if (method_33())
			{
				class57_0.method_40("margin-top", "0px");
				class57_0.method_40("margin-bottom", "0px");
			}
			if (!method_2().AutoLine && !method_26())
			{
				if (method_2().method_22().A > 0)
				{
					class57_0.method_40("background-color", class57_0.method_61(method_2().method_22()));
				}
				if (!string.IsNullOrEmpty(method_2().WorkspaceBackgroundImage))
				{
					bool flag = true;
					if (method_26())
					{
						flag = false;
					}
					if (method_6())
					{
						flag = false;
					}
					if (flag)
					{
						string text = "url(" + method_2().WorkspaceBackgroundImage + ")";
						if (class57_0.imethod_34())
						{
							text += " !important";
						}
						class57_0.method_40("background-image", text);
						class57_0.method_40("background-attachment", "fixed");
						class57_0.method_40("background-repeat", "no-repeat");
						class57_0.method_40("background-size", "cover");
						class57_0.method_40("background-position", "top center");
					}
				}
			}
			if (method_2().AutoLine)
			{
				method_39(xtextDocument_0);
				method_40(xtextDocument_0);
			}
			if (!class57_0.imethod_34())
			{
				class57_0.method_40("cursor", "default");
			}
			class57_0.method_63();
			if (method_2().AutoZoom)
			{
				class57_0.method_19("autozoom", "true");
			}
			class57_0.method_19("printzoomrate", method_2().method_2().ToString());
			if (!method_2().Readonly)
			{
				foreach (DocumentParameter parameter in xtextDocument_0.Parameters)
				{
					if (!string.IsNullOrEmpty(parameter.Name))
					{
						class57_0.method_19(" dcvar_" + parameter.Name.Trim().ToLower(), parameter.StringValue);
					}
				}
				if (!string.IsNullOrEmpty(class57_0.method_135()))
				{
					class57_0.method_19("effectexpression", class57_0.method_135());
				}
				if (!string.IsNullOrEmpty(method_60()))
				{
					class57_0.method_19("servereventnamelist", method_60());
				}
				class57_0.method_19("pagename", method_22());
				class57_0.method_19("controlname", method_24());
				class57_0.method_19("documentloadoptions", method_8().ToString());
				class57_0.method_19("browser", method_18().ToString());
			}
			else
			{
				class57_0.method_19("readonly", "true");
			}
			class57_0.method_19("ismobiledevice", method_26().ToString().ToLower());
			if (method_2().AutoHeightInMobileDevice)
			{
				class57_0.method_19("autoheightinmobiledevice", "true");
			}
			class57_0.method_19("excludekeywords", method_2().ExcludeKeywords);
			class57_0.method_19("servicepageurl", method_2().ServicePageURL);
			if (method_2().method_14())
			{
				class57_0.method_19("freeselection", "true");
			}
			if (!method_2().EnabledClientContextMenu)
			{
				class57_0.method_19("oncontextmenu", "return false ;");
			}
			if (!method_2().method_4())
			{
				class57_0.method_19("oncopy", "return false ;");
			}
		}

		private void method_47(XTextDocumentList xtextDocumentList_0)
		{
			int num = 5;
			XTextDocument xTextDocument = null;
			if (xtextDocumentList_0 != null && xtextDocumentList_0.Count > 0)
			{
				xTextDocument = xtextDocumentList_0.FirstDocument;
			}
			class57_0.imethod_0("head");
			class57_0.imethod_0("meta");
			class57_0.method_19("http-equiv", "content-type");
			class57_0.method_19("content", "text/html;charset=" + method_20());
			class57_0.imethod_1();
			if (method_26())
			{
				class57_0.imethod_0("meta");
				class57_0.method_19("name", "viewport");
				class57_0.method_19("content", "width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0");
				class57_0.imethod_1();
			}
			class57_0.imethod_0("title");
			class57_0.method_3(xTextDocument.RuntimeTitle);
			class57_0.imethod_2();
			if (!method_2().Readonly)
			{
				class57_0.imethod_0("link");
				class57_0.method_19("rel", "stylesheet");
				class57_0.method_19("type", "text/css");
				class57_0.method_19("href", method_65("DCSoft.Writer.Controls.Resources.laydate.css"));
				class57_0.imethod_1();
			}
			if (!class57_0.imethod_34())
			{
				class57_0.imethod_0("style");
				class57_0.method_3(method_64(xTextDocument));
				class57_0.imethod_2();
			}
			else
			{
				class57_0.imethod_0("style");
				class57_0.method_3("\r\n.leftline{white-space:nowrap;word-break:keep-all;text-align:justify;text-justify:distribute-all-lines;layout-grid:char loose 10pt none}\r\n.centerline{white-space:nowrap;word-break:keep-all;text-align:center}\r\n.rightline{white-space:nowrap;word-break:keep-all;text-align:right}\r\n.justifyline{white-space:nowrap;word-break:keep-all;text-align:justify;text-justify:distribute-all-lines;layout-grid:char loose 10pt none}\r\n.distributeline{white-space:nowrap;word-break:keep-all;text-align:justify;text-justify:distribute-all-lines;layout-grid:char loose 10pt none}");
				class57_0.imethod_2();
			}
			if (method_16())
			{
				List<string> list = new List<string>();
				if (smethod_0())
				{
					list.Add("DCSoft.Writer.Controls.Resources.dcwriter_mini.js");
				}
				else
				{
					list.Add("DCSoft.Writer.Controls.Resources.DCBrowserCompabitility.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCDomTools.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCExpression.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCStringUtils.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCValueValidate.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCValueFormater.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCWriterControlEditor.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCDocumentCommentManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCDropdownControlManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCFileUploadManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCSelectionManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCWriterCommandMananger.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCWriterExpressionManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.WriterCommandModuleTools.js");
					list.Add("DCSoft.Writer.Controls.Resources.WriterCommandModuleFile.js");
					list.Add("DCSoft.Writer.Controls.Resources.WriterCommandModuleTable.js");
					list.Add("DCSoft.Writer.Controls.Resources.laydate.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCDragResizeManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCMedicalExpressionManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCInputFieldManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCMultiDocumentManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.DCSubDocumentManager.js");
					list.Add("DCSoft.Writer.Controls.Resources.WriterCommandModuleFormat.js");
					list.Add("DCSoft.Writer.Controls.Resources.ueditor_config.js");
					list.Add("DCSoft.Writer.Controls.Resources.ueditor_all.js");
					list.Add("DCSoft.Writer.Controls.Resources.ueditor_zhcn.js");
				}
				foreach (string item in list)
				{
					class57_0.imethod_0("script");
					class57_0.method_19("src", method_55(item));
					class57_0.method_19("type", "text/javascript");
					class57_0.method_19("language", "javascript");
					class57_0.imethod_2();
				}
			}
			class57_0.imethod_2();
		}

		private void method_48()
		{
			int num = 18;
			if (method_26())
			{
				class57_0.method_40("width", "100%");
			}
		}

		public string method_49(XTextDocumentList xtextDocumentList_0)
		{
			int num = 12;
			XTextDocument xTextDocument = null;
			if (xtextDocumentList_0 != null && xtextDocumentList_0.Count > 0)
			{
				xTextDocument = xtextDocumentList_0.FirstDocument;
			}
			class57_0 = method_52(xTextDocument);
			if (xtextDocumentList_0 == null || xtextDocumentList_0.Count == 0)
			{
				return "<html><body><b>" + WriterStrings.NoDocument + "</b></body></html>";
			}
			if (string.IsNullOrEmpty(method_2().ServicePageURL))
			{
				return "<html><body><b>" + WriterStrings.RequireServicePageURL + "</b></body></html>";
			}
			class57_0.method_117(bool_24: true);
			class57_0.method_35();
			class57_0.vmethod_1();
			class57_0.imethod_0("html");
			class57_0.method_19("flag", "dcwritereditablehtml");
			method_37(xtextDocumentList_0);
			method_47(xtextDocumentList_0);
			method_46(xTextDocument);
			foreach (XTextDocument item in xtextDocumentList_0)
			{
				class57_0.method_134(item);
			}
			int num2 = class57_0.imethod_44(xTextDocument.Body.Width);
			float num3 = 0f;
			if (!method_2().AutoLine && !method_26())
			{
				if (method_2().AutoZoom)
				{
					class57_0.imethod_0("div");
					class57_0.method_19("id", "divRoot");
				}
				else
				{
					class57_0.imethod_0("center");
				}
				method_38(xTextDocument);
				class57_0.imethod_0("tr");
				class57_0.method_19("valign", "top");
				if (method_2().method_20() > 0)
				{
					class57_0.method_19("height", method_2().method_20() + "px");
				}
				class57_0.imethod_0("td");
				num3 = ((!method_2().NarrowBorder) ? ((float)class57_0.imethod_44(xTextDocument.PageSettings.ViewLeftMargin)) : ((float)Math.Min(class57_0.imethod_44(xTextDocument.PageSettings.ViewLeftMargin), 4)));
				class57_0.method_19("width", num3 + "px");
				class57_0.imethod_2();
				class57_0.imethod_0("td");
				class57_0.method_19("width", num2 + "px");
				class57_0.method_19("id", "dcGlobalRootElement");
				class57_0.method_39();
				class57_0.method_40("padding-bottom", "3px");
				method_40(xTextDocument);
				class57_0.method_63();
				class57_0.method_19("valign", "top");
			}
			method_44(xTextDocument, bool_7: true, bool_8: false, 0, xTextDocument.Pages.FirstPage);
			class57_0.imethod_0("div");
			class57_0.method_19("id", "divAllContainer");
			class57_0.method_39();
			if (method_6())
			{
				class57_0.method_40("width", num2 + "px");
			}
			if (method_26())
			{
				method_48();
			}
			class57_0.method_63();
			int num4 = 0;
			int val = xtextDocumentList_0.Count - 1;
			if (!method_2().MultiDocument)
			{
				num4 = 0;
				val = Math.Min(0, val);
			}
			for (int i = num4; i < xtextDocumentList_0.Count; i++)
			{
				XTextDocument current = xtextDocumentList_0[i];
				method_45(xTextDocument, current, i, null);
			}
			class57_0.imethod_2();
			if (xTextDocument.Footer.HasContentElement)
			{
				method_41(xTextDocument, xTextDocument.Pages.FirstPage);
			}
			if (!method_2().AutoLine && !method_26())
			{
				class57_0.imethod_2();
				if (method_56())
				{
					method_42(xtextDocumentList_0);
				}
				else
				{
					class57_0.imethod_0("td");
					if (method_2().NarrowBorder)
					{
						int num5 = Math.Min(class57_0.imethod_44(xTextDocument.PageSettings.ViewRightMargin), 4);
						class57_0.method_19("width", num5 + "px");
					}
					else
					{
						class57_0.method_19("width", class57_0.imethod_44(xTextDocument.PageSettings.ViewRightMargin) + "px");
					}
					class57_0.imethod_2();
				}
				class57_0.imethod_2();
				class57_0.imethod_2();
				class57_0.imethod_2();
			}
			method_43();
			class57_0.imethod_2();
			class57_0.method_162();
			class57_0.imethod_2();
			class57_0.vmethod_2();
			return class57_0.method_34();
		}

		public string method_50(XTextDocumentList xtextDocumentList_0, bool bool_7)
		{
			int num = 4;
			XTextDocument xTextDocument = null;
			if (xtextDocumentList_0 != null && xtextDocumentList_0.Count > 0)
			{
				xTextDocument = xtextDocumentList_0.FirstDocument;
			}
			class57_0 = method_52(xTextDocument);
			if (xtextDocumentList_0 == null || xtextDocumentList_0.Count == 0)
			{
				return "<html><body><b>" + WriterStrings.NoDocument + "</b></body></html>";
			}
			if (string.IsNullOrEmpty(method_2().ServicePageURL))
			{
				return "<html><body><b>" + WriterStrings.RequireServicePageURL + "</b></body></html>";
			}
			class57_0.method_117(bool_24: true);
			class57_0.method_35();
			class57_0.imethod_37(bool_24: false);
			class57_0.imethod_35(bool_24: true);
			class57_0.imethod_56(DCBackgroundTextOutputMode.Output);
			class57_0.method_115(bool_24: true);
			class57_0.vmethod_1();
			class57_0.imethod_0("html");
			class57_0.method_19("flag", "pagehtml");
			method_37(xtextDocumentList_0);
			method_47(xtextDocumentList_0);
			class57_0.method_51(method_18() != XWebBrowsersStyle.InternetExplorer7);
			method_46(xTextDocument);
			XTextDocumentList xTextDocumentList = new XTextDocumentList();
			if (method_2().MultiDocument)
			{
				xTextDocumentList.AddRange(xtextDocumentList_0);
			}
			else
			{
				xTextDocumentList.Add(xtextDocumentList_0[0]);
			}
			PrintPageCollection printPageCollection = new PrintPageCollection();
			foreach (XTextDocument item in xTextDocumentList)
			{
				foreach (PrintPage page in item.Pages)
				{
					if (page == item.Pages.LastPage)
					{
						if (!item.LastPageIsEmpty)
						{
							printPageCollection.Add(page);
						}
					}
					else
					{
						printPageCollection.Add(page);
					}
				}
			}
			if (method_2().AutoZoom)
			{
				class57_0.imethod_0("div");
				class57_0.method_19("id", "divRoot");
			}
			else
			{
				class57_0.imethod_0("center");
				class57_0.method_19("id", "dcRootCenter");
			}
			GClass157 gClass = new GClass157();
			gClass.method_7(method_2().method_12());
			gClass.method_3(method_2().method_10());
			gClass.method_11(method_2().method_8());
			gClass.method_13(method_2().method_6());
			PrintPageCollection printPageCollection2 = gClass.method_23(printPageCollection);
			foreach (PrintPage item2 in printPageCollection2)
			{
				XTextDocument current = (XTextDocument)item2.Document;
				if (current != null)
				{
					current.PageIndex = current.Pages.IndexOf(item2);
					if (item2 != printPageCollection[0])
					{
						class57_0.imethod_0("div");
						class57_0.method_19("name", "dcHiddenElementForPrint");
						class57_0.method_19("style", "height:" + method_2().PixelPageSpacing + "px");
						class57_0.imethod_2();
					}
					int num2 = class57_0.imethod_44(current.Body.Width);
					float num3 = 0f;
					class57_0.imethod_0("div");
					class57_0.method_19("pageindex", printPageCollection.IndexOf(item2).ToString());
					class57_0.method_39();
					if (item2 != printPageCollection2.LastPage)
					{
						class57_0.method_40("page-break-after", "always");
					}
					class57_0.method_40("page-break-inside", "avoid");
					if (xTextDocument.PageSettings.Landscape)
					{
						class57_0.method_40("height", class57_0.imethod_44(xTextDocument.PageSettings.ViewPaperWidth) + "px");
						class57_0.method_40("width", class57_0.imethod_44(xTextDocument.PageSettings.ViewPaperHeight) + "px");
					}
					class57_0.method_63();
					method_38(current);
					class57_0.imethod_0("tr");
					class57_0.method_19("valign", "top");
					if (!bool_7)
					{
						class57_0.method_19("height", class57_0.imethod_44(current.PageSettings.ViewPaperHeight) + "px");
					}
					if (!bool_7)
					{
						class57_0.imethod_0("td");
						num3 = class57_0.imethod_44(item2.ViewLeftMargin);
						class57_0.method_19("name", "dcHiddenElementForPrint");
						class57_0.method_19("width", num3 + "px");
						class57_0.method_19("style", "width:" + num3 + "px");
						class57_0.imethod_0("div");
						class57_0.method_19("style", "width:" + Convert.ToString(num3 - 1f) + "px");
						class57_0.imethod_2();
						class57_0.imethod_2();
					}
					class57_0.imethod_0("td");
					int num4 = num2 + class57_0.imethod_44(item2.ViewRightMargin);
					class57_0.method_19("width", num4 + "px");
					class57_0.method_19("bodywidth", num2 + "px");
					class57_0.method_19("id", "dcGlobalRootElement");
					class57_0.method_39();
					if (!method_2().AutoLine)
					{
						method_40(current);
					}
					class57_0.method_40("padding-bottom", "3px");
					class57_0.method_63();
					class57_0.method_19("valign", "top");
					class57_0.imethod_51(Rectangle.Empty);
					method_44(xTextDocument, bool_7: true, bool_7, printPageCollection.IndexOf(item2), item2);
					bool flag = false;
					if (method_2().ContentRenderMode == WebWriterControlRenderMode.PagePreviewHtml)
					{
						PageBorderBackgroundStyle runtimePageBorderBackground = xTextDocument.PageSettings.RuntimePageBorderBackground;
						if (runtimePageBorderBackground != null && runtimePageBorderBackground.HasVisibleBorder && runtimePageBorderBackground.BorderRange == PageBorderRangeTypes.Body)
						{
							flag = true;
							class57_0.imethod_0("div");
							class57_0.method_39();
							class57_0.method_54(runtimePageBorderBackground.BorderLeft, runtimePageBorderBackground.BorderTop, runtimePageBorderBackground.BorderRight, runtimePageBorderBackground.BorderBottom, runtimePageBorderBackground.BorderColor, (int)runtimePageBorderBackground.BorderWidth, runtimePageBorderBackground.BorderStyle);
							class57_0.method_63();
						}
					}
					class57_0.imethod_0("div");
					class57_0.method_19("id", "divAllContainer");
					class57_0.method_39();
					if (method_6())
					{
						class57_0.method_40("width", num2 + "px");
					}
					if (current.Footer.HasContentElement)
					{
						class57_0.method_40("height", class57_0.imethod_44(item2.StandartPapeBodyHeight - 4f) + "px");
					}
					class57_0.method_63();
					method_45(xTextDocument, current, 0, item2);
					DocumentTerminalTextInfo runtimeTerminalText = current.PageSettings.RuntimeTerminalText;
					if (item2 == current.Pages.LastPage && runtimeTerminalText != null && !string.IsNullOrEmpty(runtimeTerminalText.Text))
					{
						float num5 = class57_0.imethod_44(item2.StandartPapeBodyHeight - item2.Height);
						class57_0.imethod_0("table");
						class57_0.method_19("border", "0");
						class57_0.method_39();
						class57_0.method_40("color", class57_0.method_61(runtimeTerminalText.Color));
						class57_0.method_40("text-align", "center");
						class57_0.method_40("width", num2 + "px");
						class57_0.method_40("vertial-align", "middle");
						XFontValue runtimeFont = runtimeTerminalText.RuntimeFont;
						class57_0.method_45(runtimeFont.Value);
						class57_0.method_63();
						float num6 = num5 / (float)runtimeTerminalText.Text.Length;
						for (int i = 0; i < runtimeTerminalText.Text.Length; i++)
						{
							class57_0.imethod_0("tr");
							class57_0.method_39();
							class57_0.method_40("height", num6 + "px");
							class57_0.method_63();
							class57_0.imethod_0("td");
							class57_0.method_3(runtimeTerminalText.Text[i].ToString());
							class57_0.imethod_2();
							class57_0.imethod_2();
						}
						class57_0.imethod_2();
					}
					class57_0.imethod_2();
					if (current.Footer.HasContentElement)
					{
						float viewFooterHeight = current.PageSettings.ViewFooterHeight;
						viewFooterHeight = ((!(viewFooterHeight > current.Footer.Height)) ? 0f : (viewFooterHeight - current.Footer.Height - 10f));
						viewFooterHeight = Math.Max(viewFooterHeight, 8f);
						class57_0.imethod_0("div");
						class57_0.imethod_33();
						class57_0.method_19("style", "height:" + class57_0.imethod_44(viewFooterHeight) + "px;width:" + num2 + "px");
						class57_0.method_143(bool_24: true);
						class57_0.method_144(bool_24: false);
						class57_0.imethod_2();
					}
					if (flag)
					{
						class57_0.imethod_2();
					}
					if (xTextDocument.Footer.HasContentElement)
					{
						class57_0.imethod_51(Rectangle.Empty);
						method_41(xTextDocument, item2);
					}
					class57_0.imethod_2();
					class57_0.imethod_2();
					class57_0.imethod_2();
					class57_0.imethod_2();
				}
			}
			class57_0.imethod_2();
			method_43();
			class57_0.imethod_2();
			class57_0.method_162();
			class57_0.imethod_2();
			class57_0.vmethod_2();
			return class57_0.method_34();
		}

		public void method_51()
		{
			if (class57_0 != null)
			{
				class57_0.vmethod_0();
				class57_0 = null;
			}
			if (hashtable_0 != null)
			{
				hashtable_0.Clear();
			}
			GC.Collect();
		}

		private Class57 method_52(XTextDocument xtextDocument_0)
		{
			class57_0 = new Class57();
			class57_0.method_155(bool_24: true);
			class57_0.gdelegate21_0 = gdelegate21_0;
			class57_0.imethod_37(method_5());
			class57_0.vmethod_5(method_2().IndentHtmlCode);
			class57_0.imethod_32(method_2().ServicePageURL);
			if (xtextDocument_0 != null)
			{
				class57_0.method_148(xtextDocument_0);
				class57_0.imethod_58(xtextDocument_0.Options.ViewOptions.EnableEncryptView);
			}
			class57_0.imethod_46().method_15(bool_9: false);
			class57_0.imethod_46().method_17(bool_9: false);
			class57_0.imethod_46().method_3(bool_9: false);
			class57_0.imethod_46().method_5(bool_9: true);
			class57_0.imethod_46().method_11(method_2().method_0());
			class57_0.vmethod_7(bool_24: false);
			class57_0.imethod_56(method_2().BackgroundTextOutputMode);
			class57_0.method_150(method_2().FormView == FormViewMode.Normal || method_2().FormView == FormViewMode.Strict);
			class57_0.method_29(method_18());
			class57_0.imethod_30(method_2().Readonly);
			class57_0.method_125(method_2().AutoPostBack);
			class57_0.queryListItemsEventHandler_0 = queryListItemsEventHandler_0;
			class57_0.method_119(method_14());
			class57_0.method_129(method_26());
			if (method_2().Readonly)
			{
				class57_0.method_129(bool_24: false);
			}
			else
			{
				class57_0.method_129(method_26());
			}
			return class57_0;
		}

		public DocumentOptions method_53()
		{
			return documentOptions_0;
		}

		public void method_54(DocumentOptions documentOptions_1)
		{
			documentOptions_0 = documentOptions_1;
		}

		internal static bool smethod_0()
		{
			return typeof(Class52).Assembly.GetManifestResourceInfo("DCSoft.Writer.Controls.Resources.dcwriter_mini.js") != null;
		}

		internal string method_55(string string_6)
		{
			int num = 7;
			if (smethod_0())
			{
				return method_2().ServicePageURL + "?" + Class65.string_19 + "=" + string_6 + "&flag=" + Class65.int_0;
			}
			string text = HttpContext.Current.Server.MapPath("debugjs");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = 0;
			for (int num3 = string_6.Length - 1; num3 >= 0; num3--)
			{
				if (string_6[num3] == '.')
				{
					num2++;
				}
				if (num2 == 2)
				{
					break;
				}
				stringBuilder.Insert(0, string_6[num3]);
			}
			string text2 = stringBuilder.ToString();
			FileHelper.ReleaseResourceFile(GetType(), string_6, Path.Combine(text, text2), overWrite: false, throwException: true);
			return "debugjs/" + text2;
		}

		public bool method_56()
		{
			return bool_6;
		}

		public void method_57(bool bool_7)
		{
			bool_6 = bool_7;
		}

		public int method_58()
		{
			return int_2;
		}

		public void method_59(int int_4)
		{
			int_2 = int_4;
		}

		public string method_60()
		{
			return string_5;
		}

		public void method_61(string string_6)
		{
			string_5 = string_6;
		}

		private string method_62(float float_0)
		{
			return GraphicsUnitConvert.ToCSSLength(float_0, GraphicsUnit.Document, GEnum87.const_0);
		}

		private string method_63(XTextDocument xtextDocument_0)
		{
			int num = 2;
			StringBuilder stringBuilder = new StringBuilder();
			XPageSettings pageSettings = xtextDocument_0.PageSettings;
			if (!pageSettings.Landscape)
			{
			}
			if (pageSettings.Landscape)
			{
				if (pageSettings.RuntimeSwapLeftRightMargin)
				{
					stringBuilder.Append("@page:left{  margin-left:" + method_62(pageSettings.ViewHeaderDistance) + "; margin-top:" + method_62(pageSettings.ViewLeftMargin) + "; margin-right:" + method_62(0f) + "; margin-bottom:" + method_62(0f) + ";}");
					stringBuilder.Append("@page:right{  margin-left:" + method_62(pageSettings.ViewHeaderDistance) + "; margin-top:" + method_62(pageSettings.ViewRightMargin) + "; margin-right:" + method_62(0f) + "; margin-bottom:" + method_62(0f) + ";}");
				}
				else
				{
					stringBuilder.Append("@page{  margin-left:" + method_62(pageSettings.ViewHeaderDistance) + "; margin-top:" + method_62(pageSettings.ViewLeftMargin) + "; margin-right:" + method_62(0f) + "; margin-bottom:" + method_62(0f) + ";}");
				}
			}
			else if (pageSettings.RuntimeSwapLeftRightMargin)
			{
				stringBuilder.Append("@page:left{  margin-left:" + method_62(pageSettings.ViewRightMargin) + "; margin-top:" + method_62(pageSettings.ViewHeaderDistance) + "; margin-right:" + method_62(0f) + "; margin-bottom:" + method_62(0f) + ";}");
				stringBuilder.Append("@page:right{  margin-left:" + method_62(pageSettings.ViewLeftMargin) + "; margin-top:" + method_62(pageSettings.ViewHeaderDistance) + "; margin-right:" + method_62(0f) + "; margin-bottom:" + method_62(0f) + ";}");
			}
			else
			{
				stringBuilder.Append("@page{  margin-left:" + method_62(pageSettings.ViewLeftMargin) + "; margin-top:" + method_62(pageSettings.ViewHeaderDistance) + "; margin-right:" + method_62(0f) + "; margin-bottom:" + method_62(0f) + ";}");
			}
			if (!pageSettings.Landscape)
			{
			}
			return stringBuilder.ToString();
		}

		private string method_64(XTextDocument xtextDocument_0)
		{
			int num = 17;
			Class57 @class = new Class57();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("P{margin:0px}");
			stringBuilder.AppendLine("INPUT{border:1px solid white;border-radius:4px}");
			string text = "border:1px solid red;border-radius:3px;color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldInvalidateValueForeColor) + ";";
			if (xtextDocument_0.Options.ViewOptions.FieldInvalidateValueBackColor.A > 0)
			{
				text = text + ";background-color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldInvalidateValueBackColor);
			}
			else if (xtextDocument_0.Options.ViewOptions.FieldBackColor.A > 0)
			{
				text = text + ";background-color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldBackColor);
			}
			if (xtextDocument_0.Options.ViewOptions.ShowInputFieldStateTag && xtextDocument_0.Options.ViewOptions.TagColorForValueInvalidateField.A > 0)
			{
				text = text + ";background-image:url(" + method_2().ServicePageURL + "?" + Class65.string_26 + "=" + HttpUtility.UrlEncode(@class.method_61(xtextDocument_0.Options.ViewOptions.TagColorForValueInvalidateField)) + ");background-position:bottom right;background-repeat:no-repeat;";
			}
			stringBuilder.AppendLine(".InputFieldInvalidateValue{" + text + "}");
			text = "";
			if (xtextDocument_0.Options.ViewOptions.FieldBackColor.A > 0)
			{
				text = text + ";background-color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldBackColor);
			}
			if (xtextDocument_0.Options.ViewOptions.ShowInputFieldStateTag && xtextDocument_0.Options.ViewOptions.TagColorForReadonlyField.A > 0)
			{
				text = text + ";background-image:url(" + method_2().ServicePageURL + "?" + Class65.string_26 + "=" + HttpUtility.UrlEncode(@class.method_61(xtextDocument_0.Options.ViewOptions.TagColorForReadonlyField)) + ");background-position:bottom right;background-repeat:no-repeat;";
			}
			stringBuilder.AppendLine(".InputFieldReadonly{" + text + "}");
			text = "";
			if (xtextDocument_0.Options.ViewOptions.FieldBackColor.A > 0)
			{
				text = text + ";background-color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldBackColor);
			}
			if (xtextDocument_0.Options.ViewOptions.ShowInputFieldStateTag && xtextDocument_0.Options.ViewOptions.TagColorForModifiedField.A > 0)
			{
				text = text + ";background-image:url(" + method_2().ServicePageURL + "?" + Class65.string_26 + "=" + HttpUtility.UrlEncode(@class.method_61(xtextDocument_0.Options.ViewOptions.TagColorForModifiedField)) + ");background-position:bottom right;background-repeat:no-repeat;";
			}
			stringBuilder.AppendLine(".InputFieldModified{" + text + "}");
			text = "";
			if (xtextDocument_0.Options.ViewOptions.FieldBackColor.A > 0)
			{
				text = text + ";background-color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldBackColor);
			}
			if (xtextDocument_0.Options.ViewOptions.ShowInputFieldStateTag && xtextDocument_0.Options.ViewOptions.TagColorForNormalField.A > 0)
			{
				text = text + ";background-image:url(" + method_2().ServicePageURL + "?" + Class65.string_26 + "=" + HttpUtility.UrlEncode(@class.method_61(xtextDocument_0.Options.ViewOptions.TagColorForNormalField)) + ");background-position:bottom right;background-repeat:no-repeat;";
			}
			stringBuilder.AppendLine(".InputFieldNormal{" + text + "}");
			stringBuilder.AppendLine(".FieldFocusedBackColor{background-color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldFocusedBackColor) + "}");
			stringBuilder.AppendLine(".FieldHoverBackColor{background-color:" + @class.method_61(xtextDocument_0.Options.ViewOptions.FieldHoverBackColor) + "}");
			return stringBuilder.ToString();
		}

		internal string method_65(string string_6)
		{
			int num = 7;
			string text = method_2().ServicePageURL + "?" + Class65.string_19 + "=" + string_6;
			if (method_10())
			{
				int_3++;
				text = text + "&flag=" + int_3;
			}
			return text;
		}
	}
}
