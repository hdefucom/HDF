using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档节元素
	///       </summary>
	[ComClass("00012345-6789-ABCD-EF01-234567890019", "EEE04FE8-950D-4D23-8F0C-1CE6A0DDFC64")]
	[DocumentComment]
	[ComDefaultInterface(typeof(IXTextSectionElement))]
	[DebuggerDisplay("Section {ID}:{ PreviewString }")]
	[Guid("00012345-6789-ABCD-EF01-234567890019")]
	[XmlType("XTextSection")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[DCPublishAPI]
	public class XTextSectionElement : XTextContentElement, IContentReadonlyable, IXTextSectionElement
	{
		private class Class13 : GClass3
		{
			public Class13(XTextSectionElement xtextSectionElement_0)
			{
				method_21(Cursors.Arrow);
				method_7(xtextSectionElement_0);
				RectangleF absBounds = xtextSectionElement_0.AbsBounds;
				if (xtextSectionElement_0.RuntimeIsCollapsed)
				{
					method_9(xtextSectionElement_0.OwnerDocument.DomImageList.BmpCollapse);
				}
				else
				{
					method_9(xtextSectionElement_0.OwnerDocument.DomImageList.BmpExpand);
				}
				method_15(GraphicsUnitConvert.Convert(method_8().Width, GraphicsUnit.Pixel, xtextSectionElement_0.OwnerDocument.DocumentGraphicsUnit));
				method_17(method_14());
				method_11(absBounds.Left - method_14());
				method_13(absBounds.Top + 10f);
				method_5(xtextSectionElement_0.Title);
				method_21(Cursors.Arrow);
			}

			public override void vmethod_1(WriterMouseEventArgs writerMouseEventArgs_0)
			{
				if (writerMouseEventArgs_0.Button == MouseButtons.Left && method_19(writerMouseEventArgs_0.X, writerMouseEventArgs_0.Y))
				{
					writerMouseEventArgs_0.Handled = true;
					XTextSectionElement xTextSectionElement = (XTextSectionElement)method_6();
					if (xTextSectionElement.IsCollapsed)
					{
						xTextSectionElement.Expand();
					}
					else
					{
						xTextSectionElement.Collapse();
					}
					xTextSectionElement.Focus();
				}
			}
		}

		protected class GClass2
		{
			private string string_0 = null;

			private Color color_0 = Color.Black;

			public string method_0()
			{
				return string_0;
			}

			public void method_1(string string_1)
			{
				string_0 = string_1;
			}

			public Color method_2()
			{
				return color_0;
			}

			public void method_3(Color color_1)
			{
				color_0 = color_1;
			}
		}

		internal const string string_14 = "00012345-6789-ABCD-EF01-234567890019";

		internal const string string_15 = "EEE04FE8-950D-4D23-8F0C-1CE6A0DDFC64";

		private Color color_0 = Color.FromArgb(128, 128, 128);

		private bool bool_22 = false;

		private bool bool_23 = false;

		private string string_16 = null;

		private bool bool_24 = false;

		private float float_9 = 0f;

		private RectangleF rectangleF_1 = RectangleF.Empty;

		private string string_17 = null;

		public override string DomDisplayName => "Section:" + base.ID + " " + Title;

		/// <summary>
		///       收缩时的前景色
		///       </summary>
		[MemberExpressionable]
		[DCPublishAPI]
		[DefaultValue(typeof(Color), "128,128,128")]
		public Color ForeColorForCollapsed
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
		///       收缩时的前景颜色值
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute]
		[XmlElement]
		public string ForeColorValueForCollapsed
		{
			get
			{
				return XMLSerializeHelper.ColorToString(ForeColorForCollapsed, Color.FromArgb(128, 128, 128));
			}
			set
			{
				ForeColorForCollapsed = XMLSerializeHelper.StringToColor(value, Color.FromArgb(128, 128, 128));
			}
		}

		/// <summary>
		///       能否被收缩
		///       </summary>
		[XmlElement]
		[DefaultValue(false)]
		[HtmlAttribute]
		[DCPublishAPI]
		[MemberExpressionable]
		public bool EnableCollapse
		{
			get
			{
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

		/// <summary>
		///       运行时的是否启用收缩功能
		///       </summary>
		internal bool RuntimeEnableCollapse
		{
			get
			{
				if (!EnableCollapse)
				{
					return false;
				}
				if (EnableCollapse && OwnerDocument != null)
				{
					return OwnerDocument.Options.BehaviorOptions.EnableCollapseSection;
				}
				return true;
			}
		}

		internal override bool ContainsUnHandledPageBreak
		{
			get
			{
				if (RuntimeIsCollapsed)
				{
					return false;
				}
				return base.ContainsUnHandledPageBreak;
			}
			set
			{
				base.ContainsUnHandledPageBreak = value;
			}
		}

		/// <summary>
		///       是否处于收缩状态
		///       </summary>
		[DefaultValue(false)]
		[MemberExpressionable]
		[DCPublishAPI]
		[HtmlAttribute]
		[XmlElement]
		public bool IsCollapsed
		{
			get
			{
				return bool_23;
			}
			set
			{
				bool_23 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。运行时的是否处于收缩状态
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		[ComVisible(false)]
		public bool RuntimeIsCollapsed
		{
			get
			{
				if (RuntimeEnableCollapse)
				{
					return IsCollapsed;
				}
				return false;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		[HtmlAttribute]
		[DCPublishAPI]
		[MemberExpressionable]
		public string Title
		{
			get
			{
				return string_16;
			}
			set
			{
				string_16 = value;
			}
		}

		/// <summary>
		///       能否接受制表符，默认true。
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		[DCPublishAPI]
		[MemberExpressionable]
		public override bool AcceptTab
		{
			get
			{
				return base.AcceptTab;
			}
			set
			{
				base.AcceptTab = value;
			}
		}

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "section";

		/// <summary>
		///       压缩所在文档行的行间距
		///       </summary>
		[Category("Layout")]
		[MemberExpressionable(MemberEffectLevel.DocumentLayout)]
		[DCPublishAPI]
		[HtmlAttribute]
		[DefaultValue(false)]
		public bool CompressOwnerLineSpacing
		{
			get
			{
				return bool_24;
			}
			set
			{
				bool_24 = value;
			}
		}

		/// <summary>
		///       用户指定的高度
		///       </summary>
		/// <remarks>
		///       若等于0则对象自动设置高度，
		///       若大于0则对象高度自动设置高度而且高度不小于用户指定的高度，
		///       若小于0则固定设置对象的高度为用户指定的高度。
		///       </remarks>
		[DCPublishAPI]
		[DefaultValue(0f)]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.DocumentLayout)]
		public float SpecifyHeight
		{
			get
			{
				return float_9;
			}
			set
			{
				float_9 = value;
			}
		}

		/// <summary>
		///       第一个在文档正文中的内容元素
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override XTextElement FirstContentElementInPublicContent
		{
			get
			{
				if (RuntimeIsCollapsed)
				{
					return this;
				}
				return base.FirstContentElement;
			}
		}

		/// <summary>
		///       最后一个在文档正文中的内容元素
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override XTextElement LastContentElementInPublicContent
		{
			get
			{
				if (RuntimeIsCollapsed)
				{
					return this;
				}
				return base.LastContentElement;
			}
		}

		/// <summary>
		///       第一个内容元素
		///       </summary>
		[Browsable(false)]
		public override XTextElement FirstContentElement => this;

		/// <summary>
		///       最后一个内容元素
		///       </summary>
		[Browsable(false)]
		public override XTextElement LastContentElement => this;

		public override bool SupportElementViewHandle => RuntimeEnableCollapse;

		/// <summary>
		///       名称
		///       </summary>
		[MemberExpressionable]
		[HtmlAttribute]
		[DCPublishAPI]
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return string_17;
			}
			set
			{
				string_17 = value;
			}
		}

		[Browsable(false)]
		[DCPublishAPI]
		[ComVisible(false)]
		[DCInternal]
		public virtual string HtmlTitle => null;

		public override string PreviewString
		{
			get
			{
				int num = 0;
				string str = base.ID;
				if (string.IsNullOrEmpty(Title))
				{
					str = str + " " + Title + " ";
				}
				return str + base.PreviewString;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XTextSectionElement()
		{
			AcceptTab = true;
		}

		/// <summary>
		///       选择文档节
		///       </summary>
		[DCPublishAPI]
		public override bool Select()
		{
			if (RuntimeIsCollapsed)
			{
				base.DocumentContentElement.Focus();
				return base.DocumentContentElement.SetSelection(base.ViewIndex, 1);
			}
			if (Elements.Count == 0)
			{
				return false;
			}
			int viewIndex = Elements.FirstContentElement.ViewIndex;
			int viewIndex2 = Elements.LastContentElement.ViewIndex;
			base.DocumentContentElement.Focus();
			OwnerDocument.method_124(Elements.FirstContentElement);
			return base.DocumentContentElement.SetSelectionRange(viewIndex, viewIndex2);
		}

		/// <summary>
		///       获得输入焦点
		///       </summary>
		[DCPublishAPI]
		public override void Focus()
		{
			if (OwnerDocument == null || Focused)
			{
				return;
			}
			XTextElement xTextElement = base.PrivateContent.FirstContentElement;
			if (RuntimeIsCollapsed)
			{
				xTextElement = this;
			}
			OwnerDocument.method_124(xTextElement);
			if (xTextElement is XTextTableElement)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)xTextElement;
				if (xTextTableElement.FirstCell != null)
				{
					xTextElement = xTextTableElement.FirstCell.FirstContentElement;
				}
			}
			if (xTextElement != null)
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (OwnerDocument.CurrentContentElement != documentContentElement)
				{
					documentContentElement.Focus();
				}
				documentContentElement.SetSelection(xTextElement.ViewIndex, 0);
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
			}
		}

		/// <summary>
		///       收缩内容
		///       </summary>
		/// <returns>操作是否导致文档视图修改</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		[DocumentComment]
		public virtual bool Collapse()
		{
			if (RuntimeEnableCollapse && !IsCollapsed)
			{
				if (WriterControl != null)
				{
					WriterSectionElementCancelEventArgs writerSectionElementCancelEventArgs = new WriterSectionElementCancelEventArgs(WriterControl, OwnerDocument, this);
					WriterControl.vmethod_6(writerSectionElementCancelEventArgs);
					if (writerSectionElementCancelEventArgs.Cancel)
					{
						return false;
					}
				}
				IsCollapsed = true;
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Elements);
				domTreeNodeEnumerable.ExcludeCharElement = false;
				domTreeNodeEnumerable.ExcludeParagraphFlag = false;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					item.int_2 = -1;
				}
				if (OwnerDocument.ReadyState == DomReadyStates.Complete)
				{
					using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
					{
						DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(dcgraphics_);
						documentPaintEventArgs.Element = this;
						RefreshSize(documentPaintEventArgs);
					}
					base.DocumentContentElement.vmethod_36(bool_22: true);
					method_10(bool_5: false);
					if (WriterControl != null)
					{
						WriterSectionElementEventArgs writerSectionElementEventArgs_ = new WriterSectionElementEventArgs(WriterControl, OwnerDocument, this);
						WriterControl.vmethod_7(writerSectionElementEventArgs_);
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       展开内容
		///       </summary>
		/// <returns>操作是否导致文档视图修改</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		[DocumentComment]
		public virtual bool Expand()
		{
			if (RuntimeEnableCollapse && IsCollapsed)
			{
				if (WriterControl != null)
				{
					WriterSectionElementCancelEventArgs writerSectionElementCancelEventArgs = new WriterSectionElementCancelEventArgs(WriterControl, OwnerDocument, this);
					WriterControl.vmethod_8(writerSectionElementCancelEventArgs);
					if (writerSectionElementCancelEventArgs.Cancel)
					{
						return false;
					}
				}
				vmethod_45();
				IsCollapsed = false;
				EditorRefreshViewExt(fastMode: true);
				if (WriterControl != null)
				{
					WriterSectionElementEventArgs writerSectionElementEventArgs_ = new WriterSectionElementEventArgs(WriterControl, OwnerDocument, this);
					WriterControl.vmethod_9(writerSectionElementEventArgs_);
				}
				return true;
			}
			return false;
		}

		protected virtual void vmethod_45()
		{
		}

		public override GClass3 vmethod_2()
		{
			if (RuntimeEnableCollapse)
			{
				return new Class13(this);
			}
			return null;
		}

		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (RuntimeIsCollapsed)
			{
				args.Cursor = Cursors.Arrow;
			}
			if (args.Style == DocumentEventStyles.MouseDown && args.Button == MouseButtons.Left && RuntimeIsCollapsed)
			{
				Select();
				args.Handled = true;
			}
			else if (args.Style == DocumentEventStyles.MouseDblClick && args.Button == MouseButtons.Left && RuntimeEnableCollapse && IsCollapsed)
			{
				args.Handled = true;
				Expand();
			}
			else
			{
				base.HandleDocumentEvent(args);
			}
		}

		protected virtual GClass2 vmethod_46()
		{
			GClass2 gClass = new GClass2();
			string text = Title;
			if (string.IsNullOrEmpty(text))
			{
				text = Text;
				if (text != null && text.Length > 100)
				{
					text = text.Substring(0, 100);
				}
			}
			gClass.method_1(text);
			gClass.method_3(ForeColorForCollapsed);
			return gClass;
		}

		/// <summary>
		///       绘制文档节
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void Draw(DocumentPaintEventArgs args)
		{
			if (RuntimeIsCollapsed)
			{
				GClass2 gClass = vmethod_46();
				RectangleF viewBounds = args.ViewBounds;
				if (!string.IsNullOrEmpty(gClass.method_0()))
				{
					using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
					{
						drawStringFormatExt.Alignment = StringAlignment.Near;
						drawStringFormatExt.LineAlignment = StringAlignment.Center;
						drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
						drawStringFormatExt.Trimming = StringTrimming.EllipsisCharacter;
						args.Graphics.DrawString(gClass.method_0(), OwnerDocument.DefaultFont, gClass.method_2(), new RectangleF(viewBounds.Left, viewBounds.Top + 6f, viewBounds.Width, viewBounds.Height), drawStringFormatExt);
					}
				}
				args.Graphics.DrawRectangle(gClass.method_2(), viewBounds);
				OwnerDocument.method_114(this, args, GEnum6.const_85);
				return;
			}
			RectangleF viewBounds2 = args.ViewBounds;
			RectangleF rectangleF = viewBounds2;
			if (!args.PageClipRectangle.IsEmpty)
			{
				rectangleF = RectangleF.Intersect(args.PageClipRectangle, viewBounds2);
			}
			if (XTextDocument.smethod_13(GEnum6.const_87))
			{
				args.Render.vmethod_3(this, args);
			}
			bool flag = false;
			if (OwnerDocument.Options.ViewOptions.ShowGridLine)
			{
				flag = true;
				if ((args.RenderMode == DocumentRenderMode.Print || args.RenderMode == DocumentRenderMode.ReadPaint) && !OwnerDocument.Options.ViewOptions.PrintGridLine)
				{
					flag = false;
				}
			}
			bool flag2 = method_55(args, rectangleF);
			DrawContent(args);
			if (flag)
			{
				RectangleF bounds = args.ViewBounds = AbsBounds;
				args.ClientViewBounds = RuntimeStyle.GetClientRectangleF(bounds);
				method_48(args, OwnerDocument.Options.ViewOptions.GridLineColor, bool_22: false, bool_23: true, bool_24: true, OwnerDocument.Options.ViewOptions.SpecifyExtenGridLineStep, 0f, 0f, OwnerDocument.Options.ViewOptions.GridLineStyle, bool_25: false);
			}
			if (args.IsVisible(OwnerDocument.Options.ViewOptions.SectionBorderVisibility) && XTextDocument.smethod_13(GEnum6.const_87))
			{
				args.Render.vmethod_2(this, args, rectangleF);
				if (!flag2)
				{
					method_55(args, rectangleF);
				}
			}
		}

		private bool method_55(DocumentPaintEventArgs documentPaintEventArgs_0, RectangleF rectangleF_2)
		{
			if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && OwnerDocument.Options.ViewOptions.ShowCellNoneBorder)
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				if (!runtimeStyle.BorderLeft || !runtimeStyle.BorderTop || !runtimeStyle.BorderRight || !runtimeStyle.BorderBottom)
				{
					Pen pen_ = GClass438.smethod_1(OwnerDocument.Options.ViewOptions.NoneBorderColor);
					bool bool_ = !runtimeStyle.BorderLeft;
					bool bool_2 = !runtimeStyle.BorderTop;
					bool bool_3 = !runtimeStyle.BorderRight;
					bool bool_4 = !runtimeStyle.BorderBottom;
					ContentStyle.smethod_12(documentPaintEventArgs_0.Graphics, pen_, rectangleF_2, bool_, bool_2, bool_3, bool_4);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       计算元素大小
		///       </summary>
		/// <param name="args">参数</param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			Width = OwnerDocument.Body.Width;
			if (RuntimeIsCollapsed)
			{
				XFontValue defaultFont = OwnerDocument.DefaultFont;
				Height = defaultFont.GetHeight(args.Graphics.GraphisForMeasure) + 10f;
			}
			else
			{
				base.RefreshSize(args);
			}
		}

		public override void vmethod_40()
		{
			if (SpecifyHeight < 0f)
			{
				Height = 0f - SpecifyHeight;
			}
			else if (SpecifyHeight > 0f)
			{
				Height = Math.Max(SpecifyHeight, base.ContentHeight);
			}
			else
			{
				base.vmethod_40();
			}
		}

		public override int vmethod_32(XTextElementList xtextElementList_4, bool bool_25)
		{
			if (RuntimeIsCollapsed)
			{
				return 0;
			}
			return base.vmethod_32(xtextElementList_4, bool_25);
		}

		/// <summary>
		///       执行内容排版
		///       </summary>
		public override void ExecuteLayout()
		{
			base.LayoutInvalidate = false;
			if (!RuntimeEnableCollapse || !IsCollapsed)
			{
				if (OwnerDocument.Options.BehaviorOptions.ParagraphFlagFollowTableOrSection)
				{
					Width = OwnerDocument.Body.Width - 10f;
				}
				else
				{
					Width = OwnerDocument.Body.Width;
				}
				base.ExecuteLayout();
			}
		}

		internal override bool vmethod_42(Class121 class121_0)
		{
			bool result = base.vmethod_42(class121_0);
			if (Height != base.ContentHeight)
			{
				Height = base.ContentHeight;
				if (base.OwnerLine != null)
				{
					base.OwnerLine.InvalidateState = true;
				}
			}
			return result;
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			Visible = readHTMLEventArgs_0.HtmlElement.method_1();
			Style = readHTMLEventArgs_0.CreateContentStyle(readHTMLEventArgs_0.CurrentStyle, this, readHTMLEventArgs_0.HtmlElement);
			base.vmethod_17(readHTMLEventArgs_0);
		}

		public override string ToPlaintString()
		{
			if (Elements.Count == 0)
			{
				return Title;
			}
			string text = Text;
			if (!string.IsNullOrEmpty(text))
			{
				text += Environment.NewLine;
			}
			return text;
		}

		internal bool method_56()
		{
			FixDomState();
			XTextElementList elementsByType = GetElementsByType(typeof(XTextSectionElement));
			if (elementsByType != null && elementsByType.Count > 0)
			{
				XTextSectionElement xTextSectionElement = (XTextSectionElement)elementsByType.LastElement;
				if (xTextSectionElement != this)
				{
					Elements.Clear();
					Elements.AddRange(xTextSectionElement.Elements);
					xTextSectionElement.Elements.Clear();
					foreach (XTextElement element in Elements)
					{
						element.SetParentRaw(this);
					}
					base.LayoutInvalidate = true;
					return true;
				}
			}
			return false;
		}
	}
}
