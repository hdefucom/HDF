using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       在WEB页面中显示文档内容的WEB控件
	///       </summary>
	[Designer(typeof(WebFriedmanCurveControlDesigner))]
	[ControlBuilder(typeof(WebFriedmanCurveControlBuilder))]
	[DocumentComment]
	[ToolboxBitmap(typeof(WebFriedmanCurveControl))]
	[ComVisible(false)]
	public class WebFriedmanCurveControl : WebControl
	{
		private const string string_0 = "fdjia8324";

		private const string string_1 = "getpageimage";

		private const string string_2 = "serviceflag";

		private const string string_3 = "method";

		private const string string_4 = "pageindex";

		private const string string_5 = "sessionname";

		private const string string_6 = "showmarginline";

		private int int_0 = 500;

		private FCDocumentViewMode fcdocumentViewMode_0 = FCDocumentViewMode.Page;

		private bool bool_0 = true;

		private string string_7 = "DCFriedmanCurveDocument";

		private FriedmanCurveDocument friedmanCurveDocument_0 = null;

		private string string_8 = null;

		private string string_9 = null;

		private bool bool_1 = true;

		private int int_1 = 0;

		private static string string_10 = null;

		private static int int_2 = Environment.TickCount;

		/// <summary>
		///       内容像素高度
		///       </summary>
		[DefaultValue(500)]
		[Category("Layout")]
		public int ContentPixelHeight
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       文档视图模式
		///       </summary>
		[DefaultValue(FCDocumentViewMode.Page)]
		[Category("Layout")]
		public FCDocumentViewMode ViewMode
		{
			get
			{
				return fcdocumentViewMode_0;
			}
			set
			{
				fcdocumentViewMode_0 = value;
				if (value == FCDocumentViewMode.Normal)
				{
					fcdocumentViewMode_0 = FCDocumentViewMode.Page;
				}
			}
		}

		/// <summary>
		///       HTML代码文本是否缩进
		///       </summary>
		[DefaultValue(false)]
		public bool Indent
		{
			get
			{
				int num = 10;
				if (ViewState["Indent"] == null)
				{
					return false;
				}
				return Convert.ToBoolean(ViewState["Indent"]);
			}
			set
			{
				ViewState["Indent"] = value;
			}
		}

		/// <summary>
		///       是否使用纸张阴影效果
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool PageShadow
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       缓存报表文档使用的名称
		///       </summary>
		[Category("Data")]
		[DefaultValue("DCFriedmanCurveDocument")]
		public string DocumentBufferedName
		{
			get
			{
				return string_7;
			}
			set
			{
				string_7 = value;
			}
		}

		private string RuntimeDocumentBufferedName
		{
			get
			{
				int num = 12;
				if (string.IsNullOrEmpty(DocumentBufferedName))
				{
					return "DCFriedmanCurveDocument";
				}
				return DocumentBufferedName;
			}
		}

		/// <summary>
		///       控件要显示的报表文档对象列表
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public FriedmanCurveDocument Document
		{
			get
			{
				if (friedmanCurveDocument_0 == null)
				{
					friedmanCurveDocument_0 = new FriedmanCurveDocument();
				}
				return friedmanCurveDocument_0;
			}
			set
			{
				friedmanCurveDocument_0 = value;
			}
		}

		/// <summary>
		///       文档配置信息XML字符串
		///       </summary>
		[Browsable(false)]
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string DocumentConfigXml
		{
			get
			{
				return Document.ConfigXml;
			}
			set
			{
				Document.ConfigXml = value;
			}
		}

		/// <summary>
		///       文档配置对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ComVisible(false)]
		[Browsable(false)]
		public FriedmanCurveDocumentConfig DocumentConfig
		{
			get
			{
				return Document.Config;
			}
			set
			{
				Document.Config = value;
			}
		}

		/// <summary>
		///       服务页面地址
		///       </summary>
		[Editor(typeof(UrlEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string ServicePageURL
		{
			get
			{
				return string_8;
			}
			set
			{
				string_8 = value;
				string_9 = null;
			}
		}

		/// <summary>
		///       实际使用的服务页面地址
		///       </summary>
		[Browsable(false)]
		public string RuntimeServicePageURL
		{
			get
			{
				if (string_8 == null)
				{
					return "";
				}
				if (string_9 == null)
				{
					string_9 = ResolveClientUrl(ServicePageURL);
				}
				return string_9;
			}
		}

		/// <summary>
		///       自动清除保存在Session中的文档对象
		///       </summary>
		[DefaultValue(true)]
		[Category("Data")]
		public bool AutoClearSession
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       像素为单位的页面间距
		///       </summary>
		[DefaultValue(20)]
		public int PixelPageSpacing
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

		/// <summary>
		///       注册码
		///       </summary>
		[Browsable(false)]
		[Obsolete("本方法已经作废，请使用SetRegisterCode().")]
		[DefaultValue(null)]
		public string RegisterCode
		{
			get
			{
				return FriedmanCurveDocument.StaticRegisterCode;
			}
			set
			{
			}
		}

		/// <summary>
		///       HTML标签名
		///       </summary>
		protected override HtmlTextWriterTag TagKey => HtmlTextWriterTag.Div;

		/// <summary>
		///       处理页面服务
		///       </summary>
		/// <returns>是否执行了操作，无需后续处理</returns>
		public static bool HandleService()
		{
			return smethod_0(HttpContext.Current.Request, HttpContext.Current.Response, HttpContext.Current.Session);
		}

		/// <summary>
		///       执行编辑器WEB控件配套的服务器页面功能
		///       </summary>
		/// <param name="page">页面对象</param>
		/// <returns>是否执行了操作，无需后续处理</returns>
		public static bool HandleServicePage(Page page)
		{
			return smethod_0(page.Request, page.Response, page.Session);
		}

		private static bool smethod_0(HttpRequest httpRequest_0, HttpResponse httpResponse_0, HttpSessionState httpSessionState_0)
		{
			int num = 7;
			if (httpRequest_0 == null)
			{
				throw new ArgumentNullException("WebFriedmanCurveControl.InnerHandleService.request");
			}
			if (httpResponse_0 == null)
			{
				throw new ArgumentNullException("WebFriedmanCurveControl.InnerHandleService.response");
			}
			if (httpSessionState_0 == null)
			{
				throw new ArgumentNullException("WebFriedmanCurveControl.InnerHandleService.session");
			}
			if (httpRequest_0.QueryString["serviceflag"] != "fdjia8324")
			{
				return false;
			}
			string a = httpRequest_0.QueryString["method"];
			if (a == "getpageimage")
			{
				string text = httpRequest_0.QueryString["sessionname"];
				if (string.IsNullOrEmpty(text))
				{
					return true;
				}
				FriedmanCurveDocument friedmanCurveDocument = httpSessionState_0[text] as FriedmanCurveDocument;
				if (friedmanCurveDocument == null)
				{
					return true;
				}
				string s = httpRequest_0.QueryString["pageindex"];
				int result = 0;
				if (!string.IsNullOrEmpty(text) && int.TryParse(s, out result) && result >= 0 && result < friedmanCurveDocument.NumOfPages)
				{
					MemoryStream memoryStream = new MemoryStream();
					using (Bitmap bitmap2 = friedmanCurveDocument.CreatePageBmp(result))
					{
						if (!string.IsNullOrEmpty(httpRequest_0.QueryString["SmallImg"]) && !string.IsNullOrEmpty(httpRequest_0.QueryString["SmallImgHeight"]) && !string.IsNullOrEmpty(httpRequest_0.QueryString["SmallImgWidth"]))
						{
							string text2 = httpRequest_0.QueryString["SmallImgWidth"].ToString();
							if (text2.IndexOf(".") > 0)
							{
								text2 = text2.Substring(0, text2.IndexOf("."));
							}
							int width = int.Parse(text2);
							string text3 = httpRequest_0.QueryString["SmallImgHeight"].ToString();
							if (text3.IndexOf("px") > 0)
							{
								text3 = text3.Substring(0, text3.IndexOf("px"));
							}
							int height = int.Parse(text3);
							Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(bitmap);
							graphics.DrawImage(bitmap2, 0, 0, new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
							graphics.Dispose();
							bitmap.Save(memoryStream, ImageFormat.Png);
						}
						else
						{
							bitmap2.Save(memoryStream, ImageFormat.Png);
						}
					}
					httpResponse_0.ContentType = "png/image";
					memoryStream.WriteTo(httpResponse_0.OutputStream);
					httpResponse_0.End();
				}
			}
			return true;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WebFriedmanCurveControl()
			: base("span")
		{
		}

		/// <summary>
		///       从指定的文件地址中加载文档
		///       </summary>
		/// <param name="strUrl">文件地址</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		public bool LoadDocument(string strUrl, string format)
		{
			int num = 4;
			if (string.IsNullOrEmpty(strUrl))
			{
				throw new ArgumentNullException("strUrl");
			}
			if (Document == null)
			{
				Document = new FriedmanCurveDocument();
			}
			using (FileStream stream = new FileStream(strUrl, FileMode.Open, FileAccess.Read))
			{
				Document.Load(stream);
			}
			return true;
		}

		/// <summary>
		///       从指定的文件流中加载文档
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		/// <returns>是否成功加载文档</returns>
		public bool LoadDocument(Stream stream, string format)
		{
			int num = 6;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (Document == null)
			{
				Document = new FriedmanCurveDocument();
			}
			Document.Load(stream);
			return true;
		}

		/// <summary>
		///       清除数据
		///       </summary>
		public void ClearData()
		{
			Document.ClearData();
			Document.Parameters.Clear();
		}

		/// <summary>
		///       修改指定时间区域的范围
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="startTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>操作是否修改了数据</returns>
		public bool SetFriedmanCurveZoneRange(string zoneName, DateTime startTime, DateTime endTime)
		{
			return Document.SetFriedmanCurveZoneRange(zoneName, startTime, endTime);
		}

		/// <summary>
		///       设置指定时间区域中的数据点颜色
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="valueName">数据序列名称</param>
		/// <param name="colorValue">颜色值，比如"#ff00ff"</param>
		/// <returns>操作修改的数据点个数</returns>
		public int SetSymbolStyleByTimeZone(string zoneName, string valueName, string colorValue)
		{
			return Document.SetSymbolStyleByTimeZone(zoneName, valueName, colorValue);
		}

		/// <summary>
		///       设置指定时间区域中的数据点样式
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="valueName">数据序列名称</param>
		/// <param name="style">新的数据点图标样式</param>
		/// <returns>操作修改的数据点个数</returns>
		public int SetSymbolStyleByTimeZone(string zoneName, string valueName, FCValuePointSymbolStyle style)
		{
			return Document.SetSymbolStyleByTimeZone(zoneName, valueName, style);
		}

		/// <summary>
		///       设置页眉标题文本
		///       </summary>
		/// <param name="title">标题</param>
		/// <param name="text">文本</param>
		public void SetHeaderLableValue(string title, string text)
		{
			Document.SetHeaderLableValue(title, text);
		}

		/// <summary>
		///       设置文档参数值
		///       </summary>
		/// <param name="pName">参数名</param>
		/// <param name="pValue">参数值</param>
		public void SetParameterValue(string pName, string pValue)
		{
			Document.SetParameterValue(pName, pValue);
		}

		/// <summary>
		///       根据序号设置页眉标题文本
		///       </summary>
		/// <param name="index">从0开始计算的序号</param>
		/// <param name="text">文本</param>
		public void SetHeaderLableValueByIndex(int index, string text)
		{
			Document.SetHeaderLableValueByIndex(index, text);
		}

		/// <summary>
		///       创建一个数据点对象实例
		///       </summary>
		/// <returns>创建的对象实例</returns>
		public FCValuePoint CreateValuePoint()
		{
			return new FCValuePoint();
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列的名称</param>
		/// <param name="point">数据点</param>
		public void AddPoint(string name, FCValuePoint point)
		{
			Document.AddPoint(name, point);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="Value">数值</param>
		public void AddPointByTimeValue(string name, DateTime dateTime_0, float Value)
		{
			Document.AddPointByTimeValue(name, dateTime_0, Value);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">数值</param>
		public void AddPointByTimeText(string name, DateTime dateTime_0, string text)
		{
			Document.AddPointByTimeText(name, dateTime_0, text);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">文本</param>
		/// <param name="Value">数值</param>
		public void AddPointByTimeTextValue(string name, DateTime dateTime_0, string text, float Value)
		{
			Document.AddPointByTimeTextValue(name, dateTime_0, text, Value);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">文本</param>
		/// <param name="htmlColorValue">HTML格式的颜色值</param>
		public void AddPointByTimeTextColor(string name, DateTime dateTime_0, string text, string htmlColorValue)
		{
			Document.AddPointByTimeTextColor(name, dateTime_0, text, htmlColorValue);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="Value">数值</param>
		/// <param name="landernValue">灯笼数值</param>
		public void AddPointByTimeValueLandernValue(string name, DateTime dateTime_0, float Value, float landernValue)
		{
			Document.AddPointByTimeValueLandernValue(name, dateTime_0, Value, landernValue);
		}

		/// <summary>
		///       本方法无任何作用，只是为了和WinForm报表显示控件XPreviewControl的RefreshView方法保持一只，以方便进行代码的移植。
		///       </summary>
		public void RefreshView()
		{
		}

		/// <summary>
		///       设置注册码
		///       </summary>
		/// <param name="registerCode">
		/// </param>
		[DocumentComment]
		public void SetRegisterCode(string registerCode)
		{
			FriedmanCurveDocument.StaticRegisterCode = registerCode;
		}

		/// <summary>
		///       设置注册码的静态方法
		///       </summary>
		/// <param name="registerCode">
		/// </param>
		[DocumentComment]
		public static void StaticSetRegisterCode(string registerCode)
		{
			FriedmanCurveDocument.StaticRegisterCode = registerCode;
		}

		/// <summary>
		///        呈现内容
		///       </summary>
		/// <param name="writer">
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
			int num = 16;
			if (string_10 != null)
			{
				writer.WriteLine("Render:" + string_10);
			}
			try
			{
				if (Page.Site != null && Page.Site.DesignMode)
				{
				}
				base.Render(writer);
			}
			catch (Exception ex)
			{
				writer.WriteLine(ex.ToString());
			}
		}

		private string method_0()
		{
			return null;
		}

		/// <summary>
		/// </summary>
		/// <param name="writer">
		/// </param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			int num = 3;
			base.AddAttributesToRender(writer);
			if (Page == null || Page.Site == null || !Page.Site.DesignMode)
			{
				writer.AddAttribute("documentbuffername", DocumentBufferedName);
				writer.AddAttribute("servicepageurl", RuntimeServicePageURL);
				writer.AddStyleAttribute("overflow", "hidden");
				writer.AddStyleAttribute("position", "relative");
				writer.AddAttribute("align", "center");
				if (base.Page != null && base.Page.Form != null)
				{
					writer.AddAttribute("FormID", base.Page.Form.ClientID);
				}
				writer.AddAttribute("license", FriedmanCurveDocument.LicenseTitle);
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="writer">
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			int num = 9;
			if (Page.Site != null && Page.Site.DesignMode)
			{
				Type type = GetType();
				writer.WriteLine("<b>" + ID + "</b>");
				writer.WriteLine("<br />Width = " + Width);
				writer.WriteLine("<br />Height = " + Height);
				writer.WriteLine("<br />Type = " + type.FullName);
				writer.WriteLine("<br />Version = " + type.Assembly.FullName);
				writer.WriteLine("<br />PageShadow = " + PageShadow);
				writer.WriteLine("<br />ServicePageURL = " + RuntimeServicePageURL);
				writer.WriteLine("<br />DocumentBuffered = :" + DocumentBufferedName);
				writer.WriteLine("<br />南京都昌信息科技有限公司，发布时间：2014-5-20");
				return;
			}
			base.RenderContents(writer);
			string text = method_0();
			if (text != null)
			{
				writer.Write(text);
				return;
			}
			FriedmanCurveDocument document = Document;
			Page.Session[RuntimeDocumentBufferedName] = document;
			if (ViewMode != FCDocumentViewMode.FriedmanCurve)
			{
				writer.WriteLine("<div style='height:" + PixelPageSpacing + "px' ></div>");
			}
			string str = "border:1 solid black";
			if (PageShadow)
			{
				str += ";progid:DXImageTransform.Microsoft.Shadow(color='black', Direction=135, Strength=5)";
			}
			document.ViewMode = ViewMode;
			document.UpdateNumOfPage();
			if (document.ViewMode == FCDocumentViewMode.FriedmanCurve)
			{
				using (Bitmap image = new Bitmap(1, 1))
				{
					using (Graphics graphics_ = Graphics.FromImage(image))
					{
						SizeF sizeF = document.method_51(graphics_);
						document.Width = sizeF.Width;
						document.Height = sizeF.Height;
						if (ContentPixelHeight > 0)
						{
							document.Height = GraphicsUnitConvert.Convert(ContentPixelHeight, GraphicsUnit.Pixel, document.GraphicsUnit);
						}
					}
				}
			}
			Random random = new Random();
			int num2 = random.Next(1, 999988);
			for (int i = 0; i < document.NumOfPages; i++)
			{
				string text2 = "map" + Convert.ToString(int_2++);
				writer.WriteLine(string.Concat("<div id=\"DCFriedmanCurveimgcontent", num2, "\"  style=\"text-align:center;width:100%;overflow:auto;height:", Height, "\">"));
				writer.WriteLine("<img  class=\"DCFriedmanCurvebigimg" + num2 + "\"  src=\"" + RuntimeServicePageURL + "?serviceflag=fdjia8324&sessionname=" + HttpUtility.HtmlAttributeEncode(RuntimeDocumentBufferedName) + "&method=getpageimage&pageindex=" + i + "&NoneFlag=" + Convert.ToString(int_2++) + "\" border='1' usemap='#" + text2 + "' ");
				writer.WriteLine("/>");
				writer.WriteLine(string.Concat("<div style=\"z-index:5;left:0px;top:0px;width:", document.LeftHeaderPixelWidth + 2f, "px;overflow:hidden;height:", Height, ";position:absolute;\">"));
				writer.WriteLine(string.Concat("<img src=\"", RuntimeServicePageURL, "?serviceflag=fdjia8324&sessionname=", HttpUtility.HtmlAttributeEncode(RuntimeDocumentBufferedName), "&method=getpageimage&pageindex=", i, "&NoneFlag=", Convert.ToString(int_2++), "&SmallImg=smallimg&SmallImgHeight=", Height, "&SmallImgWidth=", document.LeftHeaderPixelWidth + 2f, "\" border='1' style=\"z-index:99;left:0px;top:0px;position:absolute;\"  "));
				writer.WriteLine("/>");
				writer.WriteLine("</div>");
				writer.WriteLine("</div>");
				document.dictionary_0 = new Dictionary<FCValuePoint, RectangleF>();
				using (document.CreatePageBmp(i))
				{
				}
				if (document.dictionary_0.Count > 0)
				{
					writer.WriteLine("<map name='" + text2 + "'>");
					foreach (FCValuePoint key in document.dictionary_0.Keys)
					{
						if (!string.IsNullOrEmpty(key.Link))
						{
							RectangleF rect = document.dictionary_0[key];
							rect = GraphicsUnitConvert.Convert(rect, document.GraphicsUnit, GraphicsUnit.Pixel);
							writer.Indent++;
							writer.WriteLine("<area shape='rect' coords='" + rect.Left + "," + rect.Top + "," + rect.Right + "," + rect.Bottom + "' href=\"" + HttpUtility.HtmlAttributeEncode(key.Link) + "\" title=\"" + HttpUtility.HtmlAttributeEncode(key.RuntimeTitle) + "\" target=\"" + HttpUtility.HtmlAttributeEncode(key.LinkTarget) + "\" >");
							writer.Indent--;
						}
					}
					writer.WriteLine("</map>");
					document.dictionary_0 = null;
				}
				if (ViewMode != FCDocumentViewMode.FriedmanCurve)
				{
					writer.WriteLine("<div style='height:" + PixelPageSpacing + "px' ></div>");
				}
				writer.WriteLine("<script type=\"text/javascript\">");
				writer.WriteLine("var browser = document.getElementById && !document.all; var isdrag = false; var x, y; var scrolllefts;var fatherobj;");
				writer.WriteLine("function DCFriedmanCurveselection(e) {");
				writer.WriteLine("var fobj = browser ? e.target : event.srcElement;");
				writer.WriteLine("if (fobj.className == \"DCFriedmanCurvebigimg" + num2 + "\") {");
				writer.WriteLine("fatherobj = browser ? fobj.parentNode : fobj.parentElement;");
				writer.WriteLine("var obj = browser ? e.target : event.srcElement; isdrag = true; scrolllefts = fatherobj.scrollLeft;");
				writer.WriteLine("x = browser ? e.clientX : event.clientX; y = browser ? e.clientY : event.clientY;");
				writer.WriteLine("document.onmousemove = DCFriedmanCurvemovemouse;return false;}}");
				writer.WriteLine("function DCFriedmanCurvemovemouse(e) {");
				writer.WriteLine("if (isdrag) {");
				writer.WriteLine("fatherobj.scrollLeft = browser ? x - e.clientX + scrolllefts : x - event.clientX + scrolllefts; return false;");
				writer.WriteLine("}}");
				writer.WriteLine("document.getElementById(\"DCFriedmanCurveimgcontent" + num2 + "\").onmousedown = DCFriedmanCurveselection; document.getElementById(\"DCFriedmanCurveimgcontent" + num2 + "\").onmouseup = new Function(\"isdrag=false\");");
				writer.WriteLine("</script>");
			}
		}
	}
}
