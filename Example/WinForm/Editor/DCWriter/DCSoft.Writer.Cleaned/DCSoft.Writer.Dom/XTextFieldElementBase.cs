using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       字段元素
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[XmlType("XField")]
	[DCInternal]
	[DebuggerDisplay("Field")]
	[Guid("00012345-6789-ABCD-EF01-234567890055")]
	public class XTextFieldElementBase : XTextContainerElement
	{
		private string string_14 = null;

		private string string_15 = null;

		private Color color_0 = Color.Empty;

		private XTextFieldBorderElement xtextFieldBorderElement_0 = null;

		private XTextFieldBorderElement xtextFieldBorderElement_1 = null;

		[Browsable(false)]
		[XmlIgnore]
		private static TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(Color));

		private Color color_1 = Color.Transparent;

		private DCBooleanValueHasDefault dcbooleanValueHasDefault_0 = DCBooleanValueHasDefault.Default;

		private Color color_2 = Color.Transparent;

		[NonSerialized]
		private XTextElementList xtextElementList_2 = null;

		/// <summary>
		///       运行时使用的背景文字
		///       </summary>
		internal virtual string RuntimeBackgroundText => null;

		/// <summary>
		///       开始边框元素文本
		///       </summary>
		[HtmlAttribute]
		[DCPublishAPI]
		[ComVisible(true)]
		[XmlElement]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[DefaultValue(null)]
		public string StartBorderText
		{
			get
			{
				return string_14;
			}
			set
			{
				string_14 = value;
			}
		}

		internal string RuntimeStartBorderText
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_164))
				{
					return string_14;
				}
				return null;
			}
		}

		/// <summary>
		///       结束边框元素文本
		///       </summary>
		[XmlElement]
		[HtmlAttribute]
		[ComVisible(true)]
		[DCPublishAPI]
		[DefaultValue(null)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public string EndBorderText
		{
			get
			{
				return string_15;
			}
			set
			{
				string_15 = value;
			}
		}

		internal string RuntimeEndBorderText
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_164))
				{
					return string_15;
				}
				return null;
			}
		}

		/// <summary>
		///       边框元素颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Empty")]
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[HtmlAttribute]
		public Color BorderElementColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       边框元素颜色
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[Browsable(false)]
		public string BorderElementColorValue
		{
			get
			{
				if (color_0.IsEmpty)
				{
					return null;
				}
				return ColorTranslator.ToHtml(color_0);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					color_0 = Color.Empty;
				}
				else
				{
					color_0 = ColorTranslator.FromHtml(value);
				}
			}
		}

		/// <summary>
		///       元素大小无效标记
		///       </summary>
		/// <remarks>若设置该属性,则元素的大小发生改变,系统需要从该元素
		///       开始重新进行文档排版和分页</remarks>
		[XmlIgnore]
		[Browsable(false)]
		public override bool SizeInvalid
		{
			get
			{
				return base.SizeInvalid;
			}
			set
			{
				base.SizeInvalid = value;
				if (xtextFieldBorderElement_0 != null)
				{
					xtextFieldBorderElement_0.SizeInvalid = value;
				}
				if (xtextFieldBorderElement_1 != null)
				{
					xtextFieldBorderElement_1.SizeInvalid = value;
				}
			}
		}

		/// <summary>
		///       文档元素所属的文档对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[XmlIgnore]
		public override XTextDocument OwnerDocument
		{
			get
			{
				return base.ElementOwnerDocument;
			}
			set
			{
				if (base.OwnerDocument != value)
				{
					base.OwnerDocument = value;
					if (xtextFieldBorderElement_0 != null)
					{
						xtextFieldBorderElement_0.OwnerDocument = value;
					}
					if (xtextFieldBorderElement_1 != null)
					{
						xtextFieldBorderElement_1.OwnerDocument = value;
					}
				}
			}
		}

		/// <summary>
		///       起始元素
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		public XTextFieldBorderElement StartElement
		{
			get
			{
				vmethod_36();
				if (xtextFieldBorderElement_0 != null)
				{
					xtextFieldBorderElement_0.Parent = this;
				}
				return xtextFieldBorderElement_0;
			}
			set
			{
				xtextFieldBorderElement_0 = value;
			}
		}

		/// <summary>
		///       结束元素
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextFieldBorderElement EndElement
		{
			get
			{
				vmethod_36();
				if (xtextFieldBorderElement_1 != null)
				{
					xtextFieldBorderElement_1.Parent = this;
				}
				return xtextFieldBorderElement_1;
			}
			set
			{
				xtextFieldBorderElement_1 = value;
			}
		}

		/// <summary>
		///       判断所有的内容是否都处于被选择区域
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public virtual bool IsFullSelect
		{
			get
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (documentContentElement.Content.IndexOf(StartElement) >= documentContentElement.Selection.AbsStartIndex && documentContentElement.Content.IndexOf(EndElement) <= documentContentElement.Selection.AbsEndIndex)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       文档域文本值
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public string TextValue
		{
			get
			{
				return Text;
			}
			set
			{
			}
		}

		/// <summary>
		///       文字颜色
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[DefaultValue(typeof(Color), "Transparent")]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		public Color TextColor
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
			}
		}

		/// <summary>
		///       字符串格式的背景色
		///       </summary>
		[XmlElement("TextColor")]
		[DefaultValue(null)]
		[Browsable(false)]
		public string TextColorString
		{
			get
			{
				if (TextColor.A == 0)
				{
					return null;
				}
				return typeConverter_0.ConvertToString(TextColor);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					TextColor = Color.Transparent;
				}
				else
				{
					TextColor = (Color)typeConverter_0.ConvertFrom(value);
				}
			}
		}

		/// <summary>
		///       背景文本采用斜体样式
		///       </summary>
		[XmlElement]
		[DCPublishAPI]
		[DefaultValue(DCBooleanValueHasDefault.Default)]
		[Browsable(true)]
		[ComVisible(true)]
		[HtmlAttribute]
		[MemberExpressionable]
		public DCBooleanValueHasDefault BackgroundTextItalic
		{
			get
			{
				return dcbooleanValueHasDefault_0;
			}
			set
			{
				dcbooleanValueHasDefault_0 = value;
			}
		}

		/// <summary>
		///       运行时的背景文字颜色
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[HtmlAttribute]
		public Color RuntimeBackgroundTextColor
		{
			get
			{
				if (BackgroundTextColor.A == 0)
				{
					return OwnerDocument.Options.ViewOptions.BackgroundTextColor;
				}
				return BackgroundTextColor;
			}
			set
			{
			}
		}

		/// <summary>
		///       背景文字颜色
		///       </summary>
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
		[HtmlAttribute]
		public Color BackgroundTextColor
		{
			get
			{
				return color_2;
			}
			set
			{
				if (color_2 != value)
				{
					color_2 = value;
				}
			}
		}

		/// <summary>
		///       字符串格式的背景色
		///       </summary>
		[Browsable(false)]
		[XmlElement("BackgroundTextColor")]
		[DefaultValue(null)]
		public string BackgroundTextColorString
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BackgroundTextColor, Color.Transparent);
			}
			set
			{
				BackgroundTextColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       背景文档元素
		///       </summary>
		protected XTextElementList InnerBackgroundTextElements
		{
			get
			{
				return xtextElementList_2;
			}
			set
			{
				if (xtextElementList_2 != value)
				{
					xtextElementList_2 = value;
				}
			}
		}

		/// <summary>
		///       运行时的是否打印背景文本
		///       </summary>
		public virtual bool RuntimePrintBackgroundText
		{
			get
			{
				if (OwnerDocument == null)
				{
					return true;
				}
				return OwnerDocument.Options.ViewOptions.PrintBackgroundText;
			}
		}

		/// <summary>
		///       文档中第一个内容元素
		///       </summary>
		[Browsable(false)]
		public override XTextElement FirstContentElement
		{
			get
			{
				XTextElement xTextElement = xtextFieldBorderElement_0;
				if (xTextElement == null)
				{
					return base.FirstContentElement;
				}
				return xTextElement;
			}
		}

		/// <summary>
		///       文档中最后一个内容元素
		///       </summary>
		[Browsable(false)]
		public override XTextElement LastContentElement
		{
			get
			{
				XTextElement xTextElement = xtextFieldBorderElement_1;
				if (xTextElement == null)
				{
					return base.LastContentElement;
				}
				return xTextElement;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		protected XTextFieldElementBase()
		{
		}

		internal void method_26()
		{
			int styleIndex = StyleIndex;
			if (xtextFieldBorderElement_0 != null)
			{
				xtextFieldBorderElement_0.StyleIndex = styleIndex;
			}
			if (xtextFieldBorderElement_1 != null)
			{
				xtextFieldBorderElement_1.StyleIndex = styleIndex;
			}
			if (xtextElementList_2 != null)
			{
				foreach (XTextElement item in xtextElementList_2)
				{
					item.StyleIndex = styleIndex;
				}
			}
		}

		public override void vmethod_0(bool bool_17)
		{
			base.vmethod_0(bool_17);
			if (xtextFieldBorderElement_0 != null)
			{
				xtextFieldBorderElement_0.vmethod_0(bool_17);
			}
			if (xtextFieldBorderElement_1 != null)
			{
				xtextFieldBorderElement_1.vmethod_0(bool_17);
			}
			if (xtextElementList_2 != null)
			{
				xtextElementList_2.method_0(bool_17);
			}
		}

		[DCInternal]
		public XTextElementList method_27()
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (StartElement != null)
			{
				xTextElementList.AddRaw(StartElement);
			}
			if (Elements.Count == 0)
			{
				if (InnerBackgroundTextElements != null)
				{
					xTextElementList.AddRangeRaw(InnerBackgroundTextElements);
				}
			}
			else
			{
				xTextElementList.AddRangeRaw(Elements);
			}
			if (EndElement != null)
			{
				xTextElementList.AddRaw(EndElement);
			}
			return xTextElementList;
		}

		/// <summary>
		///       判断指定元素是否是本元素的父节点或者更高层次的父节点。
		///       </summary>
		/// <param name="element">要判断的元素</param>
		/// <returns>是否是父节点或者更高级的父节点</returns>
		public override bool IsParentOrSupParent(XTextElement element)
		{
			if (element == xtextFieldBorderElement_0 || element == xtextFieldBorderElement_1)
			{
				return true;
			}
			return base.IsParentOrSupParent(element);
		}

		protected virtual void vmethod_36()
		{
			if (xtextFieldBorderElement_0 == null)
			{
				XTextFieldBorderElement xTextFieldBorderElement = new XTextFieldBorderElement();
				xTextFieldBorderElement.Parent = this;
				xTextFieldBorderElement.Position = BorderElementPosition.Start;
				xtextFieldBorderElement_0 = xTextFieldBorderElement;
				if (Elements.Count > 0)
				{
					xtextFieldBorderElement_0.StyleIndex = Elements[0].StyleIndex;
				}
			}
			xtextFieldBorderElement_0.StyleIndex = StyleIndex;
			if (xtextFieldBorderElement_1 == null)
			{
				XTextFieldBorderElement xTextFieldBorderElement = new XTextFieldBorderElement();
				xTextFieldBorderElement.Parent = this;
				xTextFieldBorderElement.Position = BorderElementPosition.End;
				xtextFieldBorderElement_1 = xTextFieldBorderElement;
				if (Elements.Count > 0)
				{
					xtextFieldBorderElement_1.StyleIndex = Elements[Elements.Count - 1].StyleIndex;
				}
			}
			xtextFieldBorderElement_1.StyleIndex = StyleIndex;
		}

		/// <summary>
		///       选择文档元素
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public override bool Select()
		{
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			if (documentContentElement == null)
			{
				return false;
			}
			method_7();
			int num = documentContentElement.Content.IndexOf(StartElement);
			int num2 = documentContentElement.Content.IndexOf(EndElement);
			if (num >= 0 && num2 > 0)
			{
				documentContentElement.SetSelection(num, num2 - num + 1);
				if (documentContentElement.Content.IndexOf(StartElement) != num && num2 != documentContentElement.Content.IndexOf(EndElement))
				{
					num = documentContentElement.Content.IndexOf(StartElement);
					num2 = documentContentElement.Content.IndexOf(EndElement);
					if (num >= 0 && num2 > 0)
					{
						documentContentElement.SetSelection(num, num2 - num + 1);
					}
				}
				return true;
			}
			return base.Select();
		}

		/// <summary>
		///       选择输入域的正文内容，但不选中两边的边界元素
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		public bool SelectWithoutBorderElement()
		{
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			int num = documentContentElement.Content.IndexOf(StartElement);
			int num2 = documentContentElement.Content.IndexOf(EndElement);
			if (num >= 0 && num2 > 0)
			{
				documentContentElement.SetSelection(num + 1, num2 - num - 1);
				return true;
			}
			return base.Select();
		}

		public override bool vmethod_3(GInterface5 ginterface5_0)
		{
			if (StartElement != null && StartElement.vmethod_3(ginterface5_0))
			{
				return true;
			}
			if (EndElement != null && EndElement.vmethod_3(ginterface5_0))
			{
				return true;
			}
			if (!base.vmethod_3(ginterface5_0))
			{
				if (Elements.Count == 0 && InnerBackgroundTextElements != null && ginterface5_0.imethod_34() && (RuntimePrintBackgroundText || OwnerDocument.Options.ViewOptions.PreserveBackgroundTextWhenPrint))
				{
					foreach (XTextElement innerBackgroundTextElement in InnerBackgroundTextElements)
					{
						if (innerBackgroundTextElement.vmethod_3(ginterface5_0))
						{
							return true;
						}
					}
				}
				return false;
			}
			return true;
		}

		internal void method_28()
		{
			method_8(bool_5: false);
			if (InnerBackgroundTextElements == null)
			{
				XTextDocument ownerDocument = OwnerDocument;
				string runtimeBackgroundText = RuntimeBackgroundText;
				if (!string.IsNullOrEmpty(runtimeBackgroundText))
				{
					InnerBackgroundTextElements = new XTextElementList();
					ownerDocument.method_59(runtimeBackgroundText, -1, -1, InnerBackgroundTextElements);
					foreach (XTextElement innerBackgroundTextElement in InnerBackgroundTextElements)
					{
						innerBackgroundTextElement.vmethod_0(base.IsNewInputContent);
						innerBackgroundTextElement.SetParentRaw(this);
						innerBackgroundTextElement.StyleIndex = StyleIndex;
					}
				}
				else
				{
					InnerBackgroundTextElements = new XTextElementList();
				}
			}
		}

		/// <summary>
		///       判断是否是背景文本元素
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>是否是背景文本元素</returns>
		[DCInternal]
		internal bool FastIsBackgroundTextElement(XTextElement element)
		{
			if (Elements == null || Elements.Count == 0)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       判断是否是背景文本元素
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>是否是背景文本元素</returns>
		[DCInternal]
		public virtual bool IsBackgroundTextElement(XTextElement element)
		{
			return InnerBackgroundTextElements?.Contains(element) ?? false;
		}

		/// <summary>
		///       重新计算文档元素内容大小
		///       </summary>
		/// <param name="args">参数</param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			base.RefreshSize(args);
			vmethod_36();
			if (StartElement != null)
			{
				StartElement.RefreshSize(args);
			}
			if (EndElement != null)
			{
				EndElement.RefreshSize(args);
			}
			method_28();
			if (InnerBackgroundTextElements != null)
			{
				foreach (XTextElement innerBackgroundTextElement in InnerBackgroundTextElements)
				{
					innerBackgroundTextElement.RefreshSize(args);
				}
			}
		}

		public override void vmethod_4()
		{
			base.vmethod_4();
			if (StartElement != null)
			{
				StartElement.StyleIndex = StyleIndex;
			}
			if (EndElement != null)
			{
				EndElement.StyleIndex = StyleIndex;
			}
			if (InnerBackgroundTextElements != null)
			{
				foreach (XTextElement innerBackgroundTextElement in InnerBackgroundTextElements)
				{
					innerBackgroundTextElement.StyleIndex = StyleIndex;
				}
			}
		}

		/// <summary>
		///       修复文档DOM结构数据
		///       </summary>
		public override void FixDomState()
		{
			base.FixDomState();
			if (InnerBackgroundTextElements != null)
			{
				foreach (XTextElement innerBackgroundTextElement in InnerBackgroundTextElements)
				{
					innerBackgroundTextElement.Parent = this;
					innerBackgroundTextElement.OwnerDocument = OwnerDocument;
					innerBackgroundTextElement.StyleIndex = StyleIndex;
				}
			}
		}

		/// <summary>
		///       获得输入焦点
		///       </summary>
		[DCPublishAPI]
		public override void Focus()
		{
			if (!BelongToDocumentDom(OwnerDocument, checkLogicDelete: false))
			{
				return;
			}
			if (StartElement != null)
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (OwnerDocument.CurrentContentElement != documentContentElement)
				{
					documentContentElement.Focus();
				}
				int num = StartElement.ViewIndex + 1;
				documentContentElement.Content.MoveToPosition(num);
				if (num != StartElement.ViewIndex + 1)
				{
					num = StartElement.ViewIndex + 1;
					documentContentElement.Content.MoveToPosition(num);
				}
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
			}
			else
			{
				base.Focus();
			}
		}

		/// <summary>
		///       文档加载后的处理
		///       </summary>
		/// <param name="args">参数</param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override int vmethod_32(XTextElementList xtextElementList_3, bool bool_17)
		{
			int num = 0;
			bool flag;
			if (!(flag = (OwnerDocument.PrintingViewMode && OwnerDocument.Options.ViewOptions.IgnoreFieldBorderWhenPrint)) && StartElement != null)
			{
				StartElement.Parent = this;
				xtextElementList_3.Add(StartElement);
				num++;
			}
			int num2 = base.vmethod_32(xtextElementList_3, bool_17);
			bool_13 = (num2 > 0);
			num += num2;
			if (!flag && EndElement != null)
			{
				EndElement.Parent = this;
				xtextElementList_3.Add(EndElement);
				num++;
			}
			if (StartElement != null)
			{
				StartElement.method_13();
			}
			if (EndElement != null)
			{
				EndElement.method_13();
			}
			return num;
		}

		protected internal int method_29(XTextElementList xtextElementList_3, bool bool_17)
		{
			return base.vmethod_32(xtextElementList_3, bool_17);
		}

		/// <summary>
		///       声明用户界面无效，需要重新绘制
		///       </summary>
		[DCPublishAPI]
		public override void InvalidateView()
		{
			if (Parent != null && !UIIsUpdating && OwnerDocument != null && OwnerDocument.EditorControl != null && base.DocumentContentElement != null)
			{
				RectangleF rectangleF = RectangleF.Empty;
				if (StartElement != null)
				{
					rectangleF = StartElement.AbsBounds;
				}
				if (EndElement != null)
				{
					rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(rectangleF, EndElement.AbsBounds) : EndElement.AbsBounds);
				}
				XTextElementList xTextElementList = new XTextElementList();
				vmethod_32(xTextElementList, bool_17: false);
				XTextLine xTextLine = null;
				foreach (XTextElement item in xTextElementList)
				{
					RectangleF absBounds = item.AbsBounds;
					if (item.OwnerLine != xTextLine)
					{
						xTextLine = item.OwnerLine;
						if (xTextLine != null)
						{
							absBounds.Y = xTextLine.AbsTop;
							absBounds.Height = xTextLine.Height;
						}
					}
					rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(rectangleF, absBounds) : absBounds);
				}
				OwnerDocument.EditorControl.ViewInvalidate(Rectangle.Ceiling(rectangleF), base.DocumentContentElement.ContentPartyStyle);
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">复制品</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextDocument ownerDocument = OwnerDocument;
			XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)base.Clone(Deeply);
			xTextFieldElementBase.OwnerDocument = ownerDocument;
			if (xtextFieldBorderElement_0 != null)
			{
				xTextFieldElementBase.xtextFieldBorderElement_0 = (XTextFieldBorderElement)xtextFieldBorderElement_0.Clone(Deeply);
				xTextFieldElementBase.xtextFieldBorderElement_0.Parent = xTextFieldElementBase;
				xTextFieldElementBase.OwnerDocument = ownerDocument;
				xtextFieldBorderElement_0.Parent = this;
				xtextFieldBorderElement_0.OwnerDocument = ownerDocument;
			}
			if (xtextFieldBorderElement_1 != null)
			{
				xTextFieldElementBase.xtextFieldBorderElement_1 = (XTextFieldBorderElement)xtextFieldBorderElement_1.Clone(Deeply);
				xTextFieldElementBase.xtextFieldBorderElement_1.Parent = xTextFieldElementBase;
				xTextFieldElementBase.OwnerDocument = ownerDocument;
				xtextFieldBorderElement_1.Parent = this;
				xtextFieldBorderElement_1.OwnerDocument = ownerDocument;
			}
			xTextFieldElementBase.InnerBackgroundTextElements = null;
			if (Deeply && InnerBackgroundTextElements != null)
			{
				xTextFieldElementBase.InnerBackgroundTextElements = new XTextElementList();
				foreach (XTextElement innerBackgroundTextElement in InnerBackgroundTextElements)
				{
					XTextElement xTextElement = innerBackgroundTextElement.Clone(Deeply);
					xTextElement.Parent = xTextFieldElementBase;
					xTextElement.OwnerDocument = ownerDocument;
					xTextFieldElementBase.InnerBackgroundTextElements.Add(xTextElement);
				}
			}
			return xTextFieldElementBase;
		}

		public override void Dispose()
		{
			base.Dispose();
			string_15 = null;
			if (xtextElementList_2 != null)
			{
				xtextElementList_2.Clear();
				xtextElementList_2 = null;
			}
			string_14 = null;
			xtextFieldBorderElement_0 = null;
			xtextFieldBorderElement_1 = null;
		}
	}
}
