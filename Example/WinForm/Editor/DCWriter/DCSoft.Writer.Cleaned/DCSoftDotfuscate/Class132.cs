using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DCSoftDotfuscate
{
	internal class Class132
	{
		private XTextDocumentList xtextDocumentList_0 = new XTextDocumentList();

		private GClass519 gclass519_0 = null;

		public XTextDocumentList method_0()
		{
			return xtextDocumentList_0;
		}

		public void method_1(XTextDocumentList xtextDocumentList_1)
		{
			xtextDocumentList_0 = xtextDocumentList_1;
		}

		public GClass519 method_2()
		{
			return gclass519_0;
		}

		public void method_3(GClass519 gclass519_1)
		{
			gclass519_0 = gclass519_1;
		}

		public void method_4(float float_0)
		{
			PrintPageCollection allPages = method_0().AllPages;
			XTextDocument firstDocument = method_0().FirstDocument;
			method_2().method_8().method_18(firstDocument.Info.RuntimeTitle);
			method_2().method_8().method_20("DCWriter");
			for (int i = 0; i < allPages.Count; i++)
			{
				PrintPage printPage = allPages[i];
				XTextDocument xTextDocument = (XTextDocument)printPage.Document;
				using (xTextDocument.Options.SaveState())
				{
					xTextDocument.Options.ViewOptions.ShowParagraphFlag = false;
					xTextDocument.Options.ViewOptions.ShowInputFieldStateTag = false;
					Bitmap bitmap = xTextDocument.CreatePageBmp(xTextDocument.Pages.IndexOf(printPage), showMarginLine: false, float_0);
					MemoryStream stream = new MemoryStream();
					bitmap.Save(stream, ImageFormat.Jpeg);
					Image image_ = Image.FromStream(stream);
					bitmap.Dispose();
					method_2().method_60(printPage.ViewPaperWidth, printPage.ViewPaperHeight);
					method_2().method_7(xTextDocument.DocumentGraphicsUnit);
					method_2().method_58(image_, new RectangleF(0f, 0f, printPage.ViewPaperWidth, printPage.ViewPaperHeight), bool_3: true)?.vmethod_2();
				}
			}
		}

		public void method_5()
		{
			DocumentPaintEventArgs documentPaintEventArgs = new DocumentPaintEventArgs(null, RectangleF.Empty);
			documentPaintEventArgs.RenderMode = DocumentRenderMode.PDF;
			documentPaintEventArgs.Graphics = DCGraphics.smethod_1(method_2());
			PrintPageCollection allPages = method_0().AllPages;
			XTextDocument firstDocument = method_0().FirstDocument;
			method_2().method_8().method_18(firstDocument.Info.RuntimeTitle);
			method_2().method_8().method_20("DCWriter");
			for (int i = 0; i < allPages.Count; i++)
			{
				PrintPage printPage = allPages[i];
				XTextDocument xTextDocument = (XTextDocument)printPage.Document;
				xTextDocument.States.RenderMode = DocumentRenderMode.PDF;
				XPageSettings pageSettings = printPage.PageSettings;
				method_2().method_60(printPage.ViewPaperWidth, printPage.ViewPaperHeight);
				method_2().method_7(xTextDocument.DocumentGraphicsUnit);
				if (pageSettings.Watermark != null && pageSettings.Watermark.method_3())
				{
					RectangleF rectangleF = new RectangleF(printPage.ViewLeftMargin, printPage.ViewTopMargin, printPage.ViewPaperWidth - printPage.ViewLeftMargin - printPage.ViewRightMargin, printPage.ViewPaperHeight - printPage.ViewTopMargin - printPage.ViewBottomMargin);
					pageSettings.Watermark.method_4(rectangleF, documentPaintEventArgs.Graphics, rectangleF);
				}
				printPage.GlobalIndex = i;
				xTextDocument.CurrentPage = printPage;
				documentPaintEventArgs.Document = xTextDocument;
				documentPaintEventArgs.Render = xTextDocument.Render;
				documentPaintEventArgs.PageIndex = printPage.PageIndex;
				float val = 0f;
				bool flag = true;
				if (!pageSettings.method_3(printPage.PageIndex))
				{
					flag = false;
				}
				XTextDocumentContentElement xTextDocumentContentElement = printPage.FirstPageFlag ? ((XTextDocumentContentElement)xTextDocument.HeaderForFirstPage) : ((XTextDocumentContentElement)xTextDocument.Header);
				XTextDocumentContentElement xTextDocumentContentElement2 = printPage.FirstPageFlag ? ((XTextDocumentContentElement)xTextDocument.FooterForFirstPage) : ((XTextDocumentContentElement)xTextDocument.Footer);
				if (xTextDocumentContentElement.HasContentElement && pageSettings.EnableHeaderFooter)
				{
					method_2().method_3(new PointF(0f - xTextDocument.Left + printPage.ViewLeftMargin, 0f - xTextDocument.Top + pageSettings.ViewHeaderDistance));
					documentPaintEventArgs.ClientViewBounds = new RectangleF(xTextDocument.Left, xTextDocument.Top, xTextDocument.Width, xTextDocumentContentElement.Height);
					documentPaintEventArgs.ClipRectangle = documentPaintEventArgs.ClientViewBounds;
					documentPaintEventArgs.PageClipRectangle = documentPaintEventArgs.ClientViewBounds;
					documentPaintEventArgs.DocumentContentElement = xTextDocumentContentElement;
					RectangleF absBounds = xTextDocumentContentElement.AbsBounds;
					if (flag)
					{
						WriterUtils.smethod_29(this, xTextDocumentContentElement, documentPaintEventArgs);
						xTextDocumentContentElement.DrawContent(documentPaintEventArgs);
						if (xTextDocumentContentElement.HasContentElement && xTextDocument.RuntimeShowHeaderBottomLine)
						{
							using (Pen pen_ = new Pen(Color.Black, xTextDocument.Options.ViewOptions.HeaderBottomLineWidth))
							{
								method_2().method_56(pen_, absBounds.Left, absBounds.Bottom, absBounds.Right, absBounds.Bottom);
							}
						}
					}
					val = absBounds.Bottom + pageSettings.ViewHeaderDistance;
				}
				val = Math.Max(val, printPage.ViewTopMargin);
				if (printPage.HeaderRowsBounds.Height > 0f)
				{
					RectangleF rectangleF2 = new RectangleF(xTextDocument.Left, val, xTextDocument.Width, printPage.HeaderRowsBounds.Height);
					method_2().method_3(new PointF(0f - xTextDocument.Left + printPage.ViewLeftMargin, 0f - xTextDocument.Body.Top + val));
					documentPaintEventArgs.DocumentContentElement = xTextDocument.Body;
					documentPaintEventArgs.ClientViewBounds = new RectangleF(xTextDocument.Left, printPage.HeaderRowsBounds.Top, xTextDocument.Width, printPage.HeaderRowsBounds.Height);
					documentPaintEventArgs.ClipRectangle = documentPaintEventArgs.ClientViewBounds;
					documentPaintEventArgs.PageClipRectangle = documentPaintEventArgs.ClipRectangle;
					documentPaintEventArgs.Page = printPage;
					WriterUtils.smethod_29(this, xTextDocument.Body, documentPaintEventArgs);
					xTextDocument.Body.DrawContent(documentPaintEventArgs);
					val += printPage.HeaderRowsBounds.Height + 3f;
				}
				RectangleF rectangleF_ = RectangleF.Empty;
				if (!xTextDocument.Body.IsEmpty)
				{
					rectangleF_ = new RectangleF(xTextDocument.Left, val, xTextDocument.Width, printPage.Height);
					rectangleF_.Height = printPage.StandartPapeBodyHeight;
					method_2().method_3(new PointF(0f - xTextDocument.Left + printPage.ViewLeftMargin, 0f - xTextDocument.Top + val - printPage.Top));
					documentPaintEventArgs.DocumentContentElement = xTextDocument.Body;
					documentPaintEventArgs.ClientViewBounds = new RectangleF(xTextDocument.Left, xTextDocument.Top, xTextDocument.Width, xTextDocument.Body.Height);
					documentPaintEventArgs.ClipRectangle = new RectangleF(xTextDocument.Left, printPage.Top, xTextDocument.Width, printPage.Height);
					documentPaintEventArgs.PageClipRectangle = documentPaintEventArgs.ClipRectangle;
					documentPaintEventArgs.Page = printPage;
					WriterUtils.smethod_29(this, xTextDocument.Body, documentPaintEventArgs);
					xTextDocument.Body.DrawContent(documentPaintEventArgs);
				}
				DocumentTerminalTextInfo runtimeTerminalText = xTextDocument.PageSettings.RuntimeTerminalText;
				if (runtimeTerminalText != null)
				{
					if (i == allPages.Count - 1)
					{
						if (!string.IsNullOrEmpty(runtimeTerminalText.Text))
						{
							runtimeTerminalText.method_1(rectangleF_0: new RectangleF(0f, printPage.Bottom, printPage.Width, printPage.StandartPapeBodyHeight - printPage.Height), dcgraphics_0: documentPaintEventArgs.Graphics, rectangleF_1: RectangleF.Empty);
						}
					}
					else if (!string.IsNullOrEmpty(runtimeTerminalText.TextInMiddlePage))
					{
						runtimeTerminalText.method_0(rectangleF_0: new RectangleF(0f, printPage.Bottom, printPage.Width, printPage.StandartPapeBodyHeight - printPage.Height), dcgraphics_0: documentPaintEventArgs.Graphics, rectangleF_1: RectangleF.Empty);
					}
				}
				if (xTextDocumentContentElement2.HasContentElement && pageSettings.EnableHeaderFooter)
				{
					float num = Math.Max(printPage.ViewBottomMargin, printPage.PageSettings.ViewFooterDistance + printPage.FooterContentHeight);
					num = 0f - xTextDocument.Top + printPage.ViewPaperHeight - num;
					method_2().method_3(new PointF(0f - xTextDocument.Left + printPage.ViewLeftMargin, num));
					documentPaintEventArgs.ClientViewBounds = new RectangleF(xTextDocument.Left, xTextDocument.Top, xTextDocument.Width, xTextDocumentContentElement2.Height);
					documentPaintEventArgs.PageClipRectangle = documentPaintEventArgs.ClientViewBounds;
					documentPaintEventArgs.ClipRectangle = documentPaintEventArgs.ClientViewBounds;
					documentPaintEventArgs.DocumentContentElement = xTextDocumentContentElement2;
					if (flag)
					{
						WriterUtils.smethod_29(this, xTextDocumentContentElement2, documentPaintEventArgs);
						xTextDocumentContentElement2.DrawContent(documentPaintEventArgs);
					}
				}
				if (xTextDocument.PageSettings.RuntimePageBorderBackground != null && xTextDocument.PageSettings.RuntimePageBorderBackground.HasVisibleBorder)
				{
					RectangleF rectangleF_4 = GClass154.smethod_7(xTextDocument.PageSettings.RuntimePageBorderBackground, printPage, rectangleF_);
					if (!rectangleF_4.IsEmpty)
					{
						using (Pen pen_ = xTextDocument.PageSettings.RuntimePageBorderBackground.method_15())
						{
							method_2().method_3(new PointF(0f, 0f));
							method_2().method_45(pen_, rectangleF_4);
						}
					}
				}
				xTextDocument.States.RenderMode = DocumentRenderMode.Paint;
			}
		}
	}
}
