using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档正文对象
	///       </summary>
	[Serializable]
	[Guid("0E4176E5-848F-4ECA-A911-47354EDBABD2")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXTextDocumentBodyElement))]
	[DCPublishAPI]
	[DebuggerDisplay("Body :{ PreviewString }")]
	[ComClass("0E4176E5-848F-4ECA-A911-47354EDBABD2", "8E21E3CD-581D-4A91-947F-DEFE29EDEE04")]
	[XmlType("XTextBody")]
	[DocumentComment]
	public sealed class XTextDocumentBodyElement : XTextDocumentContentElement, IXTextDocumentBodyElement
	{
		internal const string string_14 = "0E4176E5-848F-4ECA-A911-47354EDBABD2";

		internal const string string_15 = "8E21E3CD-581D-4A91-947F-DEFE29EDEE04";

		[DCInternal]
		public override string DomDisplayName => "Body";

		[DCPublishAPI]
		public override PageContentPartyStyle ContentPartyStyle => PageContentPartyStyle.Body;

		/// <summary>
		///       返回页面设置中的网格线设置
		///       </summary>
		[XmlIgnore]
		[Editor(typeof(DCGridLineInfoForPageSettingsUIEditor), typeof(UITypeEditor))]
		[Browsable(false)]
		[DCInternal]
		public override DCGridLineInfo GridLine
		{
			get
			{
				if (OwnerDocument != null)
				{
					return OwnerDocument.PageSettings.RuntimeDocumentGridLine;
				}
				return null;
			}
			set
			{
			}
		}

		internal override DCGridLineInfo RuntimeGridLine
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_33))
				{
					return null;
				}
				if (OwnerDocument != null)
				{
					return OwnerDocument.PageSettings.RuntimeDocumentGridLine;
				}
				return null;
			}
		}

		public override float AbsTop
		{
			get
			{
				XTextDocument ownerDocument = OwnerDocument;
				if (ownerDocument == null)
				{
					return 0f;
				}
				return ownerDocument.BodyLayoutOffset + ownerDocument.Top;
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (base.Height != value)
				{
					base.Height = value;
				}
			}
		}

		/// <summary>
		///       获得预览文本
		///       </summary>
		[DCInternal]
		public override string PreviewString => "Body:" + base.PreviewString;

		/// <summary>
		///       所有的文档节列表
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextElementList Sections
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				foreach (XTextElement element in Elements)
				{
					if (element is XTextSectionElement)
					{
						xTextElementList.Add(element);
					}
				}
				return xTextElementList;
			}
		}

		/// <summary>
		///       返回BODY样式
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public override PageContentPartyStyle PagePartyStyle => PageContentPartyStyle.Body;

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public XTextDocumentBodyElement()
		{
		}

		/// <summary>
		///       获得最后一页中剩余的空白高度，单位是1/300英寸。
		///       </summary>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public float GetRemainSpacingInLastPage()
		{
			PrintPage lastPage = OwnerDocument.Pages.LastPage;
			return lastPage.Top + lastPage.StandartPapeBodyHeight - base.Bottom;
		}

		[DCInternal]
		public bool method_75(DocumentRenderMode documentRenderMode_0)
		{
			if (RuntimeGridLine != null && RuntimeGridLine.Visible && RuntimeGridLine.RuntimeGridSpan > 0f)
			{
				return true;
			}
			bool result = false;
			if (OwnerDocument.Options.ViewOptions.ShowGridLine)
			{
				result = true;
				if ((documentRenderMode_0 == DocumentRenderMode.Print || documentRenderMode_0 == DocumentRenderMode.ReadPaint) && !OwnerDocument.Options.ViewOptions.PrintGridLine)
				{
					result = false;
				}
			}
			return result;
		}

		/// <summary>
		///       绘制内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (base.PrivateLines == null || base.PrivateLines.Count == 0)
			{
				return;
			}
			bool flag = method_75(args.RenderMode);
			base.LineNumberDisplayArea = RectangleF.Empty;
			if (args.RenderMode == DocumentRenderMode.Paint && OwnerDocument.Options.ViewOptions.ShowLineNumber)
			{
				float num = 150f;
				RectangleF rectangleF = new RectangleF(-150f, args.ClipRectangle.Top, num, args.ClipRectangle.Height);
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
					XFontValue font = OwnerDocument.ContentStyles.Default.Font;
					PrintPage printPage = null;
					int num2 = 0;
					foreach (XTextLine privateLine in base.PrivateLines)
					{
						RectangleF rectangleF2 = new RectangleF(0f - num, privateLine.AbsTop, num, privateLine.Height);
						if (!args.PageClipRectangle.IsEmpty)
						{
							if (args.PageClipRectangle.Top > rectangleF2.Top + 20f)
							{
								continue;
							}
							float num3 = Math.Min(args.PageClipRectangle.Bottom, rectangleF2.Bottom);
							float num5 = rectangleF2.Y = Math.Max(args.PageClipRectangle.Top, rectangleF2.Top);
							rectangleF2.Height = num3 - num5;
						}
						if (RectangleF.Intersect(args.ClipRectangle, rectangleF2).Height > 5f)
						{
							if (printPage != privateLine.OwnerPage)
							{
								num2 = 0;
								printPage = privateLine.OwnerPage;
							}
							int privateIndexInPage = privateLine.PrivateIndexInPage;
							if (privateLine.IsPageBreakLine)
							{
								num2++;
							}
							else
							{
								args.Graphics.DrawString(Convert.ToString(privateIndexInPage - num2), font, Color.Black, rectangleF2, drawStringFormatExt);
							}
						}
					}
				}
			}
			DocumentPaintEventArgs args2 = args.Clone();
			if (flag)
			{
				RectangleF absBounds = AbsBounds;
				if (args.ViewMode == PageViewMode.Page)
				{
					PrintPage printPage = args.Page;
					float top = args.ClipRectangle.Top;
					float num6 = printPage.StandartPapeBodyHeight;
					if (OwnerDocument.Footer.Height > OwnerDocument.PageSettings.ViewFooterHeight)
					{
						num6 -= OwnerDocument.Footer.Height - OwnerDocument.PageSettings.ViewFooterHeight;
					}
					float num7 = printPage.Top + num6;
					if (args.RenderMode == DocumentRenderMode.Print)
					{
						JumpPrintInfo jumpPrintInfo = null;
						if (args.Options != null)
						{
							jumpPrintInfo = args.Options.JumpPrint;
						}
						if (jumpPrintInfo != null && jumpPrintInfo.NativeEndPosition > 0f)
						{
							num7 = Math.Min(jumpPrintInfo.NativeEndPosition, num7);
						}
					}
					absBounds.Height = num7 - absBounds.Top;
					args.ClipRectangle = new RectangleF(absBounds.Left, top + 3f, absBounds.Width, num7 - top - 3f);
					if (args.Graphics != null)
					{
						args.Graphics.ResetClip();
					}
				}
				args.ViewBounds = absBounds;
				args.ClientViewBounds = RuntimeStyle.GetClientRectangleF(absBounds);
				if (!base.HasVisibleDCGridLine)
				{
					method_48(args, OwnerDocument.Options.ViewOptions.GridLineColor, bool_22: false, args.ViewMode == PageViewMode.Page, bool_24: true, OwnerDocument.Options.ViewOptions.SpecifyExtenGridLineStep, 0f, 0f, OwnerDocument.Options.ViewOptions.GridLineStyle, bool_25: false);
				}
			}
			base.DrawContent(args2);
		}

		/// <summary>
		///       获得指定页中包含的文档行对象集合
		///       </summary>
		/// <param name="page">文档页对象</param>
		/// <returns>文档行对象集合</returns>
		public XTextLineList GetLinesInPage(PrintPage page)
		{
			XTextLineList xTextLineList = new XTextLineList();
			foreach (XTextLine line in base.Lines)
			{
				if (line.OwnerPage == page)
				{
					xTextLineList.Add(line);
				}
			}
			return xTextLineList;
		}

		/// <summary>
		///       获得指定页中包含的文档行对象集合
		///       </summary>
		/// <param name="pageIndex">页码数，从1开始计算</param>
		/// <returns>文档行对象集合</returns>
		public XTextLineList GetLinesInPageIndex(int pageIndex)
		{
			pageIndex--;
			if (pageIndex >= 0 && pageIndex < OwnerDocument.Pages.Count)
			{
				return GetLinesInPage(OwnerDocument.Pages[pageIndex]);
			}
			return null;
		}

		/// <summary>
		///       返回调试时显示的文本
		///       </summary>
		/// <returns>文本</returns>
		[DCInternal]
		public override string ToDebugString()
		{
			int num = 1;
			string text = "Body";
			if (OwnerDocument != null)
			{
				text = text + ":" + OwnerDocument.RuntimeTitle;
			}
			return text;
		}
	}
}
