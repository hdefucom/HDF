using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	internal class Class104 : DocumentPageDrawer
	{
		private RectangleF rectangleF_0 = RectangleF.Empty;

		public override PrintPageResult vmethod_1(PrintPage printPage_0, Graphics graphics_0, Rectangle rectangle_0, bool bool_2)
		{
			rectangleF_0 = RectangleF.Empty;
			PrintPageResult printPageResult = new PrintPageResult();
			printPageResult.Page = printPage_0;
			printPageResult.ContentHeight = printPage_0.Height;
			printPageResult.StartPositionInPage = printPage_0.ViewStandardHeight;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (bool_2)
			{
				num = (int)printPage_0.ViewLeftMargin;
				num2 = (int)printPage_0.ViewTopMargin;
				num3 = (int)printPage_0.ViewRightMargin;
				_ = (int)printPage_0.ViewBottomMargin;
				rectangle_0.X -= num;
				rectangle_0.Width = rectangle_0.Width + num + num3;
			}
			vmethod_0(printPage_0, graphics_0);
			IntPtr hdc = graphics_0.GetHdc();
			new GClass294(hdc);
			graphics_0.ReleaseHdc();
			XTextDocument xTextDocument = (XTextDocument)method_8();
			if (xTextDocument.BodyLayoutOffset > 0f && printPage_0 == xTextDocument.Pages.FirstPage)
			{
				printPageResult.ContentHeightPrinted = printPage_0.Height - xTextDocument.BodyLayoutOffset;
				printPageResult.StartPositionInPage = xTextDocument.BodyLayoutOffset;
			}
			else
			{
				printPageResult.ContentHeightPrinted = printPage_0.Height;
			}
			XPageSettings pageSettings = printPage_0.PageSettings;
			if (pageSettings == null)
			{
				pageSettings = xTextDocument.PageSettings;
			}
			graphics_0.PageUnit = xTextDocument.DocumentGraphicsUnit;
			Rectangle rectangle = Rectangle.Empty;
			if (method_14() != null)
			{
				graphics_0.DrawString(method_14(), Control.DefaultFont, Brushes.Red, 20f, 20f, StringFormat.GenericDefault);
			}
			float num4 = (float)GraphicsUnitConvert.Convert((double)method_28().X / 100.0, GraphicsUnit.Inch, xTextDocument.DocumentGraphicsUnit);
			float num5 = (float)GraphicsUnitConvert.Convert((double)method_28().Y / 100.0, GraphicsUnit.Inch, xTextDocument.DocumentGraphicsUnit);
			if (xTextDocument.Options.BehaviorOptions.IgnorePrintableAreaOffset)
			{
				num4 = 0f;
				num5 = 0f;
			}
			if (method_4() != null)
			{
				PointF pointF = GClass154.smethod_5(method_2(), method_4(), xTextDocument.DocumentGraphicsUnit);
				num4 += pointF.X;
				num5 += pointF.Y;
			}
			float num6 = Math.Max(pageSettings.ViewHeaderHeight, printPage_0.HeaderContentHeight);
			int num7 = 0;
			if (printPage_0.HeaderContentHeight > pageSettings.ViewHeaderHeight - 10f)
			{
				num7 = (int)(printPage_0.HeaderContentHeight - (pageSettings.ViewHeaderHeight - 10f));
			}
			if (method_18())
			{
				graphics_0.ResetTransform();
				graphics_0.ResetClip();
				rectangle = new Rectangle(-num, 0, (int)Math.Ceiling(printPage_0.Width + (float)num + (float)num3), (int)Math.Ceiling(num6));
				graphics_0.ScaleTransform(method_10(), method_12());
				graphics_0.TranslateTransform((float)num - num4, pageSettings.ViewHeaderDistance - num5);
				graphics_0.SetClip(new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width + 1, rectangle.Height + 2));
				PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(graphics_0, rectangle, xTextDocument, printPage_0, printPage_0.FirstPageFlag ? PageContentPartyStyle.HeaderForFirstPage : PageContentPartyStyle.Header, null);
				pageDocumentPaintEventArgs.RenderMode = method_0();
				pageDocumentPaintEventArgs.ContentBounds = rectangle;
				pageDocumentPaintEventArgs.PageClipRectangle = rectangle;
				pageDocumentPaintEventArgs.Options = method_37();
				if (pageSettings.method_3(printPage_0.PageIndex))
				{
					xTextDocument.DrawContent(pageDocumentPaintEventArgs);
					method_40(xTextDocument, pageDocumentPaintEventArgs.Graphics);
				}
				graphics_0.ResetClip();
				graphics_0.ResetTransform();
				if (!printPage_0.HeaderRowsBounds.IsEmpty)
				{
					graphics_0.ResetTransform();
					graphics_0.ResetClip();
					rectangle = new Rectangle((int)printPage_0.HeaderRowsBounds.Left - num, (int)printPage_0.HeaderRowsBounds.Top - 2, (int)printPage_0.HeaderRowsBounds.Width + num + num3, (int)printPage_0.HeaderRowsBounds.Height + 4);
					printPageResult.StartPositionInPage = Math.Min(printPageResult.StartPositionInPage, (float)num2 - num5);
					graphics_0.ScaleTransform(method_10(), method_12());
					graphics_0.TranslateTransform((float)num - num4, (float)num2 - num5 - printPage_0.HeaderRowsBounds.Top + (float)num7);
					graphics_0.SetClip(new Rectangle(rectangle.Left, rectangle.Top - 1, rectangle.Width + 1, rectangle.Height + 2));
					PageDocumentPaintEventArgs pageDocumentPaintEventArgs2 = new PageDocumentPaintEventArgs(graphics_0, rectangle, xTextDocument, printPage_0, PageContentPartyStyle.HeaderRows, null);
					pageDocumentPaintEventArgs2.ContentBounds = rectangle;
					pageDocumentPaintEventArgs2.PageIndex = printPage_0.GlobalIndex;
					pageDocumentPaintEventArgs2.NumberOfPages = method_16().Count;
					pageDocumentPaintEventArgs2.ContentBounds = rectangle;
					pageDocumentPaintEventArgs2.PageClipRectangle = rectangle;
					pageDocumentPaintEventArgs2.RenderMode = method_0();
					pageDocumentPaintEventArgs2.Options = method_37();
					xTextDocument.DrawContent(pageDocumentPaintEventArgs2);
					method_40(xTextDocument, pageDocumentPaintEventArgs.Graphics);
					graphics_0.ResetClip();
					graphics_0.ResetTransform();
				}
			}
			rectangle = new Rectangle(-num, (int)Math.Floor(printPage_0.Top), (int)Math.Ceiling(printPage_0.Width + (float)num + (float)num3), (int)Math.Ceiling(printPage_0.StandartPapeBodyHeight));
			if (!rectangle_0.IsEmpty)
			{
				rectangle = Rectangle.Intersect(rectangle, rectangle_0);
			}
			if (!rectangle.IsEmpty)
			{
				graphics_0.ScaleTransform(method_10(), method_12());
				graphics_0.TranslateTransform((float)num - num4, (float)num2 - printPage_0.Top + (float)num7 - num5 + printPage_0.HeaderRowsBounds.Height);
				PointF[] array = new PointF[3]
				{
					new PointF(printPage_0.Left, printPage_0.Top),
					new PointF(printPage_0.Left + printPage_0.Width, printPage_0.Top + printPage_0.Height),
					new PointF(printPage_0.Left + printPage_0.Width, printPage_0.Top + printPage_0.StandartPapeBodyHeight)
				};
				graphics_0.Transform.TransformPoints(array);
				printPageResult.StartPositionInPage = Math.Min(printPageResult.StartPositionInPage, array[0].Y);
				gclass435_0 = new SimpleRectangleTransform();
				gclass435_0.setSourceRectF(new RectangleF(array[0].X, array[0].Y, array[1].X - array[0].X, array[1].Y - array[0].Y));
				gclass435_0.set_DescRectF(new RectangleF(printPage_0.Left, printPage_0.Top, printPage_0.Width, printPage_0.Height));
				gclass435_0.method_24(new Rectangle((int)array[0].X, (int)array[0].Y, (int)(array[2].X - array[0].X), (int)(array[2].Y - array[0].Y)));
				RectangleF clip = DrawerUtil.FixClipBounds(graphics_0, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
				clip.Offset(-4f, -4f);
				clip.Width += 8f;
				clip.Height += 8f;
				graphics_0.SetClip(clip);
				PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(graphics_0, rectangle, xTextDocument, printPage_0, PageContentPartyStyle.Body, null);
				pageDocumentPaintEventArgs.RenderMode = method_0();
				pageDocumentPaintEventArgs.ContentBounds = rectangle;
				pageDocumentPaintEventArgs.PageClipRectangle = rectangle;
				pageDocumentPaintEventArgs.PageClipRectangle = new RectangleF(rectangle.Left, printPage_0.Top, Math.Max(rectangle.Width, printPage_0.Width), printPage_0.StandartPapeBodyHeight);
				pageDocumentPaintEventArgs.Options = method_37();
				xTextDocument.DrawContent(pageDocumentPaintEventArgs);
				method_40(xTextDocument, pageDocumentPaintEventArgs.Graphics);
			}
			if (method_20())
			{
				graphics_0.ResetClip();
				graphics_0.ResetTransform();
				_ = printPage_0.DocumentHeight;
				float num8 = Math.Max(printPage_0.FooterContentHeight, pageSettings.ViewFooterHeight);
				rectangle = new Rectangle(-num, 0, (int)Math.Ceiling(printPage_0.Width + (float)num + (float)num3), (int)Math.Ceiling(num8));
				int num9 = 0;
				num9 = (int)(printPage_0.ViewPaperHeight - pageSettings.ViewFooterDistance - printPage_0.FooterContentHeight);
				graphics_0.ScaleTransform(method_10(), method_12());
				graphics_0.TranslateTransform((float)num - num4, (float)num9 - num5);
				graphics_0.SetClip(new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width + 1, rectangle.Height + 1));
				PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(graphics_0, rectangle, xTextDocument, printPage_0, (!printPage_0.FirstPageFlag) ? PageContentPartyStyle.Footer : PageContentPartyStyle.FooterForFirstPage, null);
				pageDocumentPaintEventArgs.RenderMode = method_0();
				pageDocumentPaintEventArgs.ContentBounds = rectangle;
				pageDocumentPaintEventArgs.PageClipRectangle = rectangle;
				pageDocumentPaintEventArgs.Options = method_37();
				if (pageSettings.method_3(printPage_0.PageIndex))
				{
					xTextDocument.DrawContent(pageDocumentPaintEventArgs);
					method_40(xTextDocument, pageDocumentPaintEventArgs.Graphics);
				}
			}
			_ = xTextDocument.PageSettings.RuntimePageBorderBackground;
			if (method_26() != null && method_26().HasVisibleBorder)
			{
				RectangleF rectangleF = GClass154.smethod_7(method_26(), printPage_0, gclass435_0.method_23());
				graphics_0.ResetTransform();
				graphics_0.ResetClip();
				method_26().method_19(graphics_0, rectangleF);
			}
			if (!rectangleF_0.IsEmpty)
			{
				printPageResult.StartPositionInPage = rectangleF_0.Top;
				printPageResult.EndPositionInPage = rectangleF_0.Bottom;
				printPageResult.ContentHeightPrinted = rectangleF_0.Height;
			}
			return printPageResult;
		}

		private void method_40(XTextDocument xtextDocument_0, Graphics graphics_0)
		{
			RectangleF enclosingBoundsForDrawContent = xtextDocument_0.EnclosingBoundsForDrawContent;
			if (!enclosingBoundsForDrawContent.IsEmpty)
			{
				PointF[] array = new PointF[1]
				{
					enclosingBoundsForDrawContent.Location
				};
				graphics_0.Transform.TransformPoints(array);
				enclosingBoundsForDrawContent = new RectangleF(array[0], enclosingBoundsForDrawContent.Size);
				if (rectangleF_0.IsEmpty)
				{
					rectangleF_0 = enclosingBoundsForDrawContent;
				}
				else
				{
					rectangleF_0 = RectangleF.Union(rectangleF_0, enclosingBoundsForDrawContent);
				}
			}
		}
	}
}
