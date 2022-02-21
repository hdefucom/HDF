#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页码文档元素对象
	///       </summary>
	[Serializable]
	
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("00012345-6789-ABCD-EF01-23456789001C", "632AB5E7-D689-4E60-BF9B-CE86E24C39A5")]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-23456789001C")]
	[DebuggerDisplay("PageInfo:{ValueType}")]
	[XmlType("XPageInfo")]
	[ComDefaultInterface(typeof(IXTextPageInfoElement))]
	public sealed class XTextPageInfoElement : XTextObjectElement, IXTextPageInfoElement
	{
		internal const string string_9 = "00012345-6789-ABCD-EF01-23456789001C";

		internal const string string_10 = "632AB5E7-D689-4E60-BF9B-CE86E24C39A5";

		private SpecifyPageIndexInfoList specifyPageIndexInfoList_0 = null;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		private bool bool_9 = false;

		private int int_8 = 0;

		private bool bool_10 = true;

		private PageInfoValueType pageInfoValueType_0 = PageInfoValueType.PageIndex;

		private ParagraphListStyle paragraphListStyle_0 = ParagraphListStyle.ListNumberStyle;

		private string string_11 = null;

		private string string_12 = null;

		
		public override string DomDisplayName
		{
			get
			{
				int num = 7;
				if (string.IsNullOrEmpty(FormatString))
				{
					return "PageInfo:" + ValueType;
				}
				return "PageInfo:" + FormatString;
			}
		}

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		
		public override string ElementIDPrefix => "pi";

		/// <summary>
		///       指定页码值信息列表
		///       </summary>
		[XmlArrayItem("Index", typeof(SpecifyPageIndexInfo))]
		
		[ComVisible(true)]
		[HtmlAttribute]
		[DefaultValue(null)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public SpecifyPageIndexInfoList SpecifyPageIndexs
		{
			get
			{
				return specifyPageIndexInfoList_0;
			}
			set
			{
				specifyPageIndexInfoList_0 = value;
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		
		[XmlElement]
		[Browsable(true)]
		[HtmlAttribute]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       自动高度
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(false)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		
		public bool AutoHeight
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		internal bool RuntimeAutoHeight
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_199))
				{
					return bool_9;
				}
				return false;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[Browsable(true)]
		
		[XmlElement]
		[HtmlAttribute]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       用户能否改变对象大小
		///       </summary>
		
		[XmlIgnore]
		[Browsable(false)]
		public override ResizeableType Resizeable
		{
			get
			{
				if (RuntimeAutoHeight)
				{
					return ResizeableType.Width;
				}
				return ResizeableType.WidthAndHeight;
			}
			set
			{
			}
		}

		/// <summary>
		///       页码数的修正量
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		[DefaultValue(0)]
		public int PageIndexFix
		{
			get
			{
				return int_8;
			}
			set
			{
				int_8 = value;
			}
		}

		/// <summary>
		///       允许中途修改页码
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		
		[DefaultValue(true)]
		public bool ChangePageIndexMidway
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		/// <summary>
		///       内容样式
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		
		[DefaultValue(PageInfoValueType.PageIndex)]
		public PageInfoValueType ValueType
		{
			get
			{
				return pageInfoValueType_0;
			}
			set
			{
				pageInfoValueType_0 = (PageInfoValueType)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       显示样式
		///       </summary>
		[HtmlAttribute]
		
		[DefaultValue(ParagraphListStyle.ListNumberStyle)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public ParagraphListStyle DisplayFormat
		{
			get
			{
				return paragraphListStyle_0;
			}
			set
			{
				paragraphListStyle_0 = value;
			}
		}

		/// <summary>
		///       格式化字符串，比如“[%PageIndex%] / [%NumOfPages%]”。
		///       </summary>
		/// <remarks>
		///       这是一个可选的字符串设置，使用“[%%]”来包含页码数值，区域之外的文本原样输出。
		///       支持[%PageIndex%]表示从1开始计算的页码，[%NumOfPages%]表示总页数。
		///       </remarks>
		[DefaultValue(null)]
		
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public string FormatString
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		/// <summary>
		///       指定的页码编号文本列表，比如“1,2,3,8,9,10,11”，各个编号之间用半角逗号分开。
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(null)]
		public string SpecifyPageIndexTextList
		{
			get
			{
				return string_12;
			}
			set
			{
				string_12 = value;
			}
		}

		/// <summary>
		///       获得文本宽度
		///       </summary>
		[Browsable(false)]
		internal string MaxDisplayText
		{
			get
			{
				string result = "0";
				XTextDocument ownerDocument = OwnerDocument;
				switch (ValueType)
				{
				case PageInfoValueType.PageIndex:
					result = ((ownerDocument != null && ownerDocument.GlobalPages != null && ownerDocument.GlobalPages.Count != 0) ? method_16(ownerDocument.GlobalPages.Count + PageIndexFix + ownerDocument.PageIndexfix) : method_16(0));
					break;
				case PageInfoValueType.NumOfPages:
					result = ((ownerDocument != null) ? ((ownerDocument.GlobalPages == null || ownerDocument.GlobalPages.Count <= 0) ? ((ownerDocument.Info == null) ? method_16(1) : method_16(ownerDocument.Info.NumOfPage + ownerDocument.PageIndexfix)) : method_16(ownerDocument.GlobalPages.Count + ownerDocument.PageIndexfix)) : method_16(0));
					break;
				case PageInfoValueType.LocalPageIndex:
					result = ((ownerDocument != null && ownerDocument.Pages != null && ownerDocument.Pages.Count != 0) ? method_16(ownerDocument.Pages.Count + PageIndexFix + ownerDocument.PageIndexfix) : method_16(0));
					break;
				case PageInfoValueType.LocalNumOfPages:
					result = ((ownerDocument != null) ? ((ownerDocument.Pages == null || ownerDocument.Pages.Count <= 0) ? ((ownerDocument.Info == null) ? method_16(0) : method_16(ownerDocument.Info.NumOfPage + ownerDocument.PageIndexfix)) : method_16(ownerDocument.Pages.Count + ownerDocument.PageIndexfix)) : method_16(0));
					break;
				}
				return result;
			}
		}

		/// <summary>
		///       内容文本
		///       </summary>
		
		[Browsable(false)]
		public string ContentText
		{
			get
			{
				int num = 3;
				if (!XTextDocument.smethod_13(GEnum6.const_201))
				{
					return method_17(ValueType);
				}
				XTextDocument ownerDocument = OwnerDocument;
				if (!string.IsNullOrEmpty(FormatString))
				{
					string[] array = VariableString.AnalyseVariableString(FormatString, "[%", "%]");
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < array.Length; i++)
					{
						if (i % 2 == 0)
						{
							stringBuilder.Append(array[i]);
						}
						else if (ownerDocument.Options.BehaviorOptions.WeakMode)
						{
							PageInfoValueType pageInfoValueType_ = (PageInfoValueType)Enum.Parse(typeof(PageInfoValueType), array[i], ignoreCase: true);
							string value = method_17(pageInfoValueType_);
							stringBuilder.Append(value);
						}
						else
						{
							try
							{
								PageInfoValueType pageInfoValueType_ = (PageInfoValueType)Enum.Parse(typeof(PageInfoValueType), array[i], ignoreCase: true);
								string value = method_17(pageInfoValueType_);
								stringBuilder.Append(value);
							}
							catch (Exception ex)
							{
								Debug.WriteLine(ex.Message);
							}
						}
					}
					return stringBuilder.ToString();
				}
				return method_17(ValueType);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextPageInfoElement()
		{
			Width = 100f;
			Height = 100f;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)base.Clone(Deeply);
			if (specifyPageIndexInfoList_0 != null && specifyPageIndexInfoList_0.Count > 0)
			{
				xTextPageInfoElement.specifyPageIndexInfoList_0 = specifyPageIndexInfoList_0.Clone();
			}
			else
			{
				xTextPageInfoElement.specifyPageIndexInfoList_0 = null;
			}
			return xTextPageInfoElement;
		}

		public override void OnViewMouseDblClick(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 11;
			base.OnViewMouseDblClick(elementMouseEventArgs_0);
			if (elementMouseEventArgs_0.Button == MouseButtons.Left && !RuntimeContentReadonly && XTextDocument.smethod_13(GEnum6.const_200))
			{
				object obj = OwnerDocument.EditorControl.ExecuteCommand("SpecifyPageIndex", showUI: true, this);
				if (obj is bool && (bool)obj)
				{
					elementMouseEventArgs_0.Handled = true;
				}
			}
		}

		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			if (RuntimeAutoHeight)
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				Height = args.Graphics.GetFontHeight(runtimeStyle.Font) * 1.1f;
			}
			SizeInvalid = false;
		}

		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (XTextDocument.smethod_13(GEnum6.const_198))
			{
				if (drawStringFormatExt_0 == null)
				{
					drawStringFormatExt_0 = new DrawStringFormatExt();
					drawStringFormatExt_0.Alignment = StringAlignment.Center;
					drawStringFormatExt_0.LineAlignment = StringAlignment.Center;
					drawStringFormatExt_0.FormatFlags = StringFormatFlags.NoWrap;
				}
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				_ = OwnerDocument;
				RectangleF absBounds = AbsBounds;
				absBounds.Y = absBounds.Y;
				string contentText = ContentText;
				if (OwnerDocument != null && OwnerDocument.States.GenerateLongBmp)
				{
					contentText = method_18();
					using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
					{
						args.Graphics.ResetClip();
						drawStringFormatExt.Alignment = StringAlignment.Near;
						drawStringFormatExt.LineAlignment = StringAlignment.Center;
						drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
						args.Graphics.DrawString(contentText, runtimeStyle.Font, method_4(runtimeStyle.Color), absBounds, drawStringFormatExt);
					}
				}
				else
				{
					args.Graphics.DrawString(contentText, runtimeStyle.Font, method_4(runtimeStyle.Color), absBounds, drawStringFormatExt_0);
				}
			}
		}

		public string method_16(int int_9)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_201))
			{
				return int_9.ToString();
			}
			if (SpecifyPageIndexs != null && SpecifyPageIndexs.Count > 0)
			{
				SpecifyPageIndexs.SortItems();
				int num = SpecifyPageIndexs.Count - 1;
				SpecifyPageIndexInfo specifyPageIndexInfo;
				while (true)
				{
					if (num >= 0)
					{
						specifyPageIndexInfo = SpecifyPageIndexs[num];
						if (specifyPageIndexInfo.RawPageIndex <= int_9 && specifyPageIndexInfo.SpecifyPageIndex >= 0)
						{
							break;
						}
						num--;
						continue;
					}
					return GClass470.smethod_4(int_9, DisplayFormat);
				}
				int int_10 = specifyPageIndexInfo.SpecifyPageIndex + (int_9 - specifyPageIndexInfo.RawPageIndex);
				return GClass470.smethod_4(int_10, DisplayFormat);
			}
			if (!string.IsNullOrEmpty(SpecifyPageIndexTextList))
			{
				int_9--;
				string[] array = SpecifyPageIndexTextList.Split(',');
				if (int_9 >= 0 && int_9 < array.Length)
				{
					return array[int_9];
				}
				return null;
			}
			return GClass470.smethod_4(int_9, DisplayFormat);
		}

		private string method_17(PageInfoValueType pageInfoValueType_1)
		{
			XTextDocument ownerDocument = OwnerDocument;
			switch (pageInfoValueType_1)
			{
			default:
				return method_16(0);
			case PageInfoValueType.PageIndex:
				return method_16(ownerDocument.GlobalPageIndex + 1 + PageIndexFix + ownerDocument.PageIndexfix);
			case PageInfoValueType.NumOfPages:
				if (ownerDocument == null)
				{
					return method_16(0);
				}
				if (ownerDocument.GlobalPages != null && ownerDocument.GlobalPages.Count > 0)
				{
					return method_16(ownerDocument.GlobalPages.Count + ownerDocument.PageIndexfix);
				}
				if (ownerDocument.Info != null)
				{
					return method_16(ownerDocument.Info.NumOfPage + ownerDocument.PageIndexfix);
				}
				return method_16(0);
			case PageInfoValueType.LocalPageIndex:
				return method_16(ownerDocument.PageIndex + 1 + PageIndexFix + ownerDocument.PageIndexfix);
			case PageInfoValueType.LocalNumOfPages:
				if (ownerDocument == null)
				{
					return method_16(0);
				}
				if (ownerDocument.Pages != null && ownerDocument.Pages.Count > 0)
				{
					return method_16(ownerDocument.Pages.Count + ownerDocument.PageIndexfix);
				}
				if (ownerDocument.Info != null)
				{
					return method_16(ownerDocument.Info.NumOfPage + ownerDocument.PageIndexfix);
				}
				return method_16(0);
			}
		}

		/// <summary>
		///       返回纯文本数据
		///       </summary>
		/// <returns>文本数据</returns>
		public override string ToPlaintString()
		{
			if (OwnerDocument != null)
			{
				return ContentText;
			}
			return "";
		}

		/// <summary>
		///       获得调试信息字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToDebugString()
		{
			return "PageIndex:" + ToPlaintString();
		}

		
		public string method_18()
		{
			int num = 7;
			string text = "";
			text = ((!string.IsNullOrEmpty(FormatString)) ? FormatString : string.Concat("[%", ValueType, "%]"));
			text = text.Replace("[%PageIndex%]", "{" + WriterStringsCore.PageIndexText + "}");
			text = text.Replace("[%NumOfPages%]", "{" + WriterStringsCore.NumOfPagesText + "}");
			text = text.Replace("[%LocalPageIndex%]", "{" + WriterStringsCore.LocalPageIndexText + "}");
			return text.Replace("[%LocalNumOfPages%]", "{" + WriterStringsCore.LocalNumOfPagesText + "}");
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			int num = 1;
			int num2 = gclass103_0.method_22();
			gclass103_0.method_23();
			gclass103_0.method_28("field");
			gclass103_0.method_23();
			gclass103_0.method_25("fldinst", bool_5: true);
			gclass103_0.method_23();
			if (ValueType == PageInfoValueType.PageIndex || ValueType == PageInfoValueType.LocalPageIndex)
			{
				gclass103_0.method_10().method_16("PAGE");
			}
			else
			{
				gclass103_0.method_10().method_16("NUMPAGES");
			}
			gclass103_0.method_24();
			gclass103_0.method_24();
			gclass103_0.method_23();
			gclass103_0.method_28("fldrslt");
			gclass103_0.method_23();
			gclass103_0.method_40(ContentText, RuntimeStyle);
			gclass103_0.method_41();
			gclass103_0.method_24();
			gclass103_0.method_24();
			gclass103_0.method_24();
			num2 = gclass103_0.method_22() - num2;
		}
	}
}
