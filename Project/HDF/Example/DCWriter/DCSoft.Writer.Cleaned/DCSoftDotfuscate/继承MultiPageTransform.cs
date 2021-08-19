using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Drawing;

namespace DCSoftDotfuscate
{
	internal class ¼Ì³ÐMultiPageTransform : MultiPageTransform
	{
		private static bool bool_1 = true;

		public static void smethod_0(PrintPage printPage_0)
		{
			if (printPage_0.HeaderRows != null && printPage_0.HeaderRows.Count > 0)
			{
				XTextElementList xTextElementList = (XTextElementList)printPage_0.HeaderRows;
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList[0];
				float num = 0f;
				foreach (XTextTableRowElement item in xTextElementList)
				{
					num += item.Height;
				}
				XTextDocumentContentElement documentContentElement = xTextTableRowElement.DocumentContentElement;
				printPage_0.HeaderRowsBounds = new RectangleF(documentContentElement.AbsLeft, xTextTableRowElement.AbsTop, documentContentElement.Width, num);
			}
			else
			{
				printPage_0.HeaderRowsBounds = RectangleF.Empty;
			}
		}

		public override void AddPage(PrintPage printPage_0, float float_0, float float_1)
		{
			float val = 30f;
			XPageSettings pageSettings = printPage_0.PageSettings;
			int num = (int)(printPage_0.ViewLeftMargin * float_1);
			int num2 = (int)(printPage_0.ViewTopMargin * float_1);
			_ = (int)(printPage_0.ViewRightMargin * float_1);
			int num3 = (int)(printPage_0.ViewBottomMargin * float_1);
			int num4 = (int)(printPage_0.ViewPaperHeight * float_1);
			float num5 = (int)float_0 + num2;
			val = Math.Min(val, printPage_0.ViewLeftMargin);
			val = Math.Min(val, printPage_0.ViewRightMargin);
			SimpleRectangleTransform gClass = null;
			XTextDocument xTextDocument = (XTextDocument)printPage_0.Document;
			WriterControl editorControl = xTextDocument.EditorControl;
			XTextDocumentContentElement xTextDocumentContentElement = xTextDocument.Header;
			XTextDocumentContentElement xTextDocumentContentElement2 = xTextDocument.Footer;
			if (xTextDocument.PageSettings.RuntimeHeaderFooterDifferentFirstPage && printPage_0 == xTextDocument.Pages.FirstPage)
			{
				xTextDocumentContentElement = xTextDocument.HeaderForFirstPage;
				xTextDocumentContentElement2 = xTextDocument.FooterForFirstPage;
			}
			float num6 = pageSettings.EnableHeaderFooter ? xTextDocumentContentElement.Height : 0f;
			float num7 = pageSettings.EnableHeaderFooter ? xTextDocumentContentElement2.Height : 0f;
			float width = printPage_0.Width;
			float x = 0f;
			GClass543 gClass2 = null;
			if (editorControl != null)
			{
				gClass2 = editorControl.InnerViewControl.CommentSettings;
				if (gClass2 != null)
				{
					gClass2 = gClass2.method_12();
				}
			}
			if (gClass2 != null && gClass2.method_0())
			{
				if (bool_1)
				{
					x = 0f - printPage_0.ViewLeftMargin + val;
					width = printPage_0.Width + printPage_0.ViewLeftMargin + Math.Max(printPage_0.ViewRightMargin, gClass2.method_2()) - val * 2f;
				}
			}
			else if (bool_1)
			{
				x = 0f - printPage_0.ViewLeftMargin + val;
				width = printPage_0.Width + printPage_0.ViewLeftMargin + printPage_0.ViewRightMargin - val * 2f;
			}
			gClass = new SimpleRectangleTransform();
			gClass.method_3(xTextDocument.CurrentContentPartyStyle == xTextDocumentContentElement.ContentPartyStyle);
			gClass.method_13(printPage_0.PageIndex);
			gClass.method_1(xTextDocumentContentElement.ContentPartyStyle);
			gClass.method_9(printPage_0);
			gClass.method_11(printPage_0.Document);
			gClass.set_DescRectF(new RectangleF(x, 0f, width, Math.Max(pageSettings.ViewHeaderHeight - 1f, num6)));
			if (num6 > pageSettings.ViewHeaderHeight)
			{
				num5 += (float)(int)((num6 - pageSettings.ViewHeaderHeight) * float_1);
			}
			if (bool_1)
			{
				method_36(gClass, float_1, (float)printPage_0.ClientLeftFix + val * float_1, float_0 + pageSettings.ViewHeaderDistance * float_1);
			}
			else
			{
				method_36(gClass, float_1, num + printPage_0.ClientLeftFix, float_0 + pageSettings.ViewHeaderDistance * float_1);
			}
			gClass.method_24(new Rectangle(gClass.method_21().Left, gClass.method_21().Top, gClass.method_21().Width, gClass.method_21().Height));
			int num8 = 0;
			float num9 = 0f;
			SimpleRectangleTransform gClass3 = null;
			if (printPage_0.HeaderRows != null && printPage_0.HeaderRows.Count > 0)
			{
				XTextElementList xTextElementList = (XTextElementList)printPage_0.HeaderRows;
				gClass3 = new SimpleRectangleTransform();
				gClass3.method_3(bool_3: false);
				gClass3.method_5(bool_3: false);
				if (DrawerUtil.IsHeaderFooter(xTextDocument.CurrentContentPartyStyle))
				{
					gClass3.method_5(bool_3: true);
				}
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList[0];
				foreach (XTextTableRowElement item in xTextElementList)
				{
					num9 += item.Height;
				}
				gClass3.method_13(printPage_0.PageIndex);
				gClass3.method_1(PageContentPartyStyle.HeaderRows);
				gClass3.method_9(printPage_0);
				gClass3.method_11(printPage_0.Document);
				gClass3.set_DescRectF(new RectangleF(x, xTextTableRowElement.AbsTop, width, num9));
				printPage_0.HeaderRowsBounds = gClass3.method_25();
				if (num6 > pageSettings.ViewHeaderHeight - 10f && num8 == 0)
				{
					num8 = 5;
				}
				if (bool_1)
				{
					num5 = method_36(gClass3, float_1, (float)printPage_0.ClientLeftFix + val * float_1, gClass.method_23().Bottom + num8);
				}
				else
				{
					num5 = method_36(gClass3, float_1, num + printPage_0.ClientLeftFix, gClass.method_23().Bottom + num8);
				}
				gClass3.method_24(new Rectangle(gClass3.method_21().Left, gClass3.method_21().Top, gClass3.method_21().Width, (int)(num9 * float_1)));
			}
			bool flag = printPage_0 == xTextDocument.Pages.LastPage;
			float height = printPage_0.Height;
			if (flag)
			{
				height = printPage_0.StandartPapeBodyHeight - 5f;
			}
			SimpleRectangleTransform gClass4 = new SimpleRectangleTransform();
			gClass4.method_3(xTextDocument.CurrentContentPartyStyle == PageContentPartyStyle.Body);
			gClass4.method_13(printPage_0.PageIndex);
			gClass4.method_1(PageContentPartyStyle.Body);
			gClass4.method_9(printPage_0);
			gClass4.method_11(printPage_0.Document);
			gClass4.set_DescRectF(new RectangleF(x, printPage_0.Top, width, height));
			if (num6 > pageSettings.ViewHeaderHeight - 10f && num8 == 0)
			{
				num8 = 3;
			}
			if (num9 > 0f)
			{
				num8--;
			}
			if (bool_1)
			{
				num5 = method_36(gClass4, float_1, (float)printPage_0.ClientLeftFix + val * float_1, (float)(gClass.method_23().Bottom + num8) + num9 * float_1);
			}
			else
			{
				num5 = method_36(gClass4, float_1, num + printPage_0.ClientLeftFix, (float)Math.Floor((float)(gClass.method_23().Bottom + num8) + num9 * float_1));
			}
			gClass4.method_24(new Rectangle(gClass4.method_21().Left, gClass4.method_21().Top, gClass4.method_21().Width, (int)(printPage_0.StandartPapeBodyHeight * float_1 - num9 * float_1)));
			SimpleRectangleTransform gClass5 = new SimpleRectangleTransform();
			gClass5.method_3(xTextDocument.CurrentContentPartyStyle == xTextDocumentContentElement2.ContentPartyStyle);
			gClass5.method_13(printPage_0.PageIndex);
			gClass5.method_1(xTextDocumentContentElement2.ContentPartyStyle);
			gClass5.method_9(printPage_0);
			gClass5.method_11(printPage_0.Document);
			gClass5.set_DescRectF(new RectangleF(x, 0f, width, num7));
			int num10 = (int)(float_0 + (float)num4 - pageSettings.ViewFooterDistance * float_1 - num7 * float_1);
			if (num10 < gClass4.method_23().Bottom)
			{
				num10 = gClass4.method_23().Bottom;
			}
			if (bool_1)
			{
				method_36(gClass5, float_1, (int)((float)printPage_0.ClientLeftFix + val * float_1), num10);
			}
			else
			{
				method_36(gClass5, float_1, num + printPage_0.ClientLeftFix, num10);
			}
			Rectangle b = gClass5.method_21();
			if (b.Height < 25)
			{
				b.Height = 25;
			}
			Rectangle a = new Rectangle(gClass5.method_21().Left, (int)(float_0 + (float)num4 - (float)num3), gClass5.method_21().Width, gClass5.method_21().Height);
			a = Rectangle.Union(a, b);
			gClass5.method_24(a);
			printPage_0.OwneredTransformItems.Clear();
			bool flag2 = printPage_0.PageSettings.method_3(printPage_0.PageIndex) && pageSettings.EnableHeaderFooter;
			switch (xTextDocument.CurrentContentPartyStyle)
			{
			case PageContentPartyStyle.HeaderRows:
				break;
			case PageContentPartyStyle.Body:
				method_17(gClass4);
				printPage_0.AddOwneredTransformItem(gClass4);
				if (gClass3 != null)
				{
					method_17(gClass3);
					printPage_0.AddOwneredTransformItem(gClass3);
				}
				if (gClass != null && flag2)
				{
					method_17(gClass);
					printPage_0.AddOwneredTransformItem(gClass);
				}
				if (gClass5 != null && flag2)
				{
					method_17(gClass5);
					printPage_0.AddOwneredTransformItem(gClass5);
				}
				break;
			case PageContentPartyStyle.Header:
			case PageContentPartyStyle.HeaderForFirstPage:
				if (gClass != null && flag2)
				{
					method_17(gClass);
					printPage_0.AddOwneredTransformItem(gClass);
				}
				if (gClass3 != null)
				{
					method_17(gClass3);
					printPage_0.AddOwneredTransformItem(gClass3);
				}
				method_17(gClass4);
				printPage_0.AddOwneredTransformItem(gClass4);
				if (gClass5 != null && flag2)
				{
					method_17(gClass5);
					printPage_0.AddOwneredTransformItem(gClass5);
				}
				break;
			case PageContentPartyStyle.Footer:
			case PageContentPartyStyle.FooterForFirstPage:
				if (gClass5 != null && flag2)
				{
					method_17(gClass5);
					printPage_0.AddOwneredTransformItem(gClass5);
				}
				if (gClass != null && flag2)
				{
					method_17(gClass);
					printPage_0.AddOwneredTransformItem(gClass);
				}
				if (gClass3 != null)
				{
					method_17(gClass3);
					printPage_0.AddOwneredTransformItem(gClass3);
				}
				method_17(gClass4);
				printPage_0.AddOwneredTransformItem(gClass4);
				break;
			}
		}

		private float method_36(SimpleRectangleTransform gclass435_1, float float_0, float float_1, float float_2)
		{
			RectangleF rectangleF_ = Rectangle.Empty;
			rectangleF_.X = (int)float_1;
			rectangleF_.Y = float_2;
			rectangleF_.Width = gclass435_1.method_25().Width * float_0;
			rectangleF_.Height = gclass435_1.method_25().Height * float_0;
			gclass435_1.method_17(rectangleF_);
			return rectangleF_.Bottom;
		}
	}
}
