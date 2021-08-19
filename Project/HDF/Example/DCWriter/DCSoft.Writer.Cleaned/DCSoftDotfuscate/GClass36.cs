#define DEBUG
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass36 : GInterface9
	{
		private WriterViewControl writerViewControl_0;

		private GClass543 gclass543_0;

		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		private bool bool_0;

		private bool bool_1;

		private DocumentComment documentComment_0;

		internal GClass36(WriterViewControl writerViewControl_1)
		{
			int num = 6;
			writerViewControl_0 = null;
			gclass543_0 = new GClass543();
			float_0 = 20f;
			float_1 = 10f;
			float_2 = 200f;
			float_3 = 500f;
			bool_0 = false;
			bool_1 = false;
			documentComment_0 = null;
			
			if (writerViewControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			writerViewControl_0 = writerViewControl_1;
		}

		public XTextDocument method_0()
		{
			return writerViewControl_0.Document;
		}

		public WriterViewControl method_1()
		{
			return writerViewControl_0;
		}

		public GClass543 imethod_0()
		{
			return gclass543_0;
		}

		public void imethod_1(GClass543 gclass543_1)
		{
			if (gclass543_0 != gclass543_1)
			{
				gclass543_0 = gclass543_1;
			}
		}

		public float method_2()
		{
			return float_0;
		}

		public void method_3(float float_4)
		{
			float_0 = float_4;
		}

		public float method_4()
		{
			return float_1;
		}

		public void method_5(float float_4)
		{
			float_1 = float_4;
		}

		public float method_6()
		{
			return float_2;
		}

		public void method_7(float float_4)
		{
			float_2 = float_4;
		}

		public float method_8()
		{
			return float_3;
		}

		public void method_9(float float_4)
		{
			float_3 = float_4;
		}

		private RectangleF method_10(PrintPage printPage_0)
		{
			return new RectangleF(printPage_0.Left + printPage_0.Width - imethod_0().method_2(), printPage_0.Top, imethod_0().method_2(), printPage_0.ViewStandardHeight);
		}

		public void imethod_2()
		{
			using (DCGraphics dcgraphics_ = method_1().method_186())
			{
				if (imethod_3(dcgraphics_))
				{
					method_1().Invalidate(invalidateChildren: true);
				}
			}
		}

		private XFontValue method_11(XTextDocument xtextDocument_0)
		{
			string text = xtextDocument_0.Options.ViewOptions.CommentFontName;
			if (string.IsNullOrEmpty(text))
			{
				text = Control.DefaultFont.Name;
			}
			return new XFontValue(text, xtextDocument_0.Options.ViewOptions.CommentFontSize);
		}

		public bool imethod_3(DCGraphics dcgraphics_0)
		{
			int num = 1;
			if (!XTextDocument.smethod_13(GEnum6.const_148))
			{
				return false;
			}
			GClass543 gClass = imethod_0();
			XTextDocument xTextDocument = method_0();
			DocumentCommentList runtimeComments = xTextDocument.RuntimeComments;
			if (runtimeComments == null || runtimeComments.Count == 0)
			{
				if (method_1() != null && method_1().HasCommentArea)
				{
					method_1().UpdatePages();
				}
				return false;
			}
			method_15(runtimeComments, bool_2: false);
			XFontValue font = method_11(xTextDocument);
			dcgraphics_0.MeasureString("#", font);
			float num2 = dcgraphics_0.GetFontHeight(font) + 10f;
			float num3 = gClass.method_2() - gClass.method_8() * 4f;
			foreach (DocumentComment item in runtimeComments)
			{
				item.RuntimeVisible = (item.AnchorElement != null && !item.AnchorElement.IsInCollapsedSection);
				if (item.RuntimeVisible)
				{
					if (item.ContentHeight <= 0f)
					{
						if (string.IsNullOrEmpty(item.Text))
						{
							item.ContentHeight = num2;
						}
						else
						{
							item.ContentHeight = dcgraphics_0.MeasureString(item.Text, font, (int)(num3 - gClass.method_8() * 2f), DrawStringFormatExt.GenericDefault).Height;
						}
						item.ContentHeight += num2;
					}
					XTextElement anchorElement = item.AnchorElement;
					if (anchorElement != null && anchorElement.OwnerLine != null)
					{
						item.AnchorPosition = anchorElement.OwnerLine.AbsTop;
					}
					else
					{
						item.AnchorPosition = 0f;
					}
					item.Top = item.AnchorPosition;
					item.NewHeight = item.ContentHeight + gClass.method_8() * 2f + method_4();
				}
			}
			foreach (PrintPage page in xTextDocument.Pages)
			{
				RectangleF rectangleF = method_10(page);
				List<DocumentComment> list = new List<DocumentComment>();
				foreach (DocumentComment item2 in runtimeComments)
				{
					if (item2.OwnerPage == page)
					{
						list.Add(item2);
					}
				}
				if (list.Count != 0)
				{
					float num4 = 0f;
					foreach (DocumentComment item3 in list)
					{
						if (item3.RuntimeVisible)
						{
							num4 += item3.NewHeight;
							if (num4 >= rectangleF.Height)
							{
								item3.RuntimeVisible = false;
							}
						}
					}
					float num5 = num4;
					float val = page.Top;
					foreach (DocumentComment item4 in list)
					{
						item4.Top = Math.Min(item4.AnchorPosition, rectangleF.Bottom - num5);
						item4.Top = Math.Max(item4.Top, val);
						val = item4.Top + item4.NewHeight;
						num5 -= item4.NewHeight;
					}
					float left = rectangleF.Right + gClass.method_8() * 2f;
					foreach (DocumentComment item5 in list)
					{
						item5.Left = left;
						item5.Width = num3;
						item5.Height = item5.NewHeight - method_4();
					}
				}
			}
			bool flag = false;
			foreach (DocumentComment item6 in runtimeComments)
			{
				if (item6.Invalidate)
				{
					flag = true;
					item6.Invalidate = false;
				}
			}
			if (flag)
			{
				method_1().UpdatePages();
				method_1().Invalidate();
			}
			return flag;
		}

		private void method_12(DocumentComment documentComment_1)
		{
		}

		public bool method_13()
		{
			return bool_1;
		}

		public void method_14(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public bool imethod_4(int int_0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			foreach (DocumentContentStyle style in method_0().ContentStyles.Styles)
			{
				if (style.CommentIndex == int_0)
				{
					XTextElementList elementsByStyleIndex = method_0().Body.GetElementsByStyleIndex(method_0().ContentStyles.Styles.IndexOf(style));
					if (elementsByStyleIndex != null && elementsByStyleIndex.Count > 0)
					{
						foreach (XTextElement item in elementsByStyleIndex)
						{
							XTextElement xTextElement = item;
							if (item is XTextCharElement)
							{
								xTextElement = item.Parent;
							}
							if (!xTextElementList.Contains(xTextElement))
							{
								xTextElementList.Add(xTextElement);
							}
						}
					}
					break;
				}
			}
			bool result = false;
			if (xTextElementList.Count > 0)
			{
				foreach (XTextElement item2 in xTextElementList)
				{
					item2.UpdateContentVersion();
					XTextContainerElement xTextContainerElement = null;
					xTextContainerElement = ((!(item2 is XTextContainerElement)) ? item2.Parent : ((XTextContainerElement)item2));
					if (xTextContainerElement != null)
					{
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.Document = method_0();
						contentChangedEventArgs.Element = xTextContainerElement;
						xTextContainerElement.vmethod_34(contentChangedEventArgs);
						result = true;
					}
				}
				return result;
			}
			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool imethod_5(DocumentCommentList documentCommentList_0, DocumentCommentList documentCommentList_1)
		{
			if (documentCommentList_0 == documentCommentList_1)
			{
				return false;
			}
			new List<int>();
			List<int> list = new List<int>();
			if (documentCommentList_0 != null)
			{
				foreach (DocumentComment item in documentCommentList_0)
				{
					if (documentCommentList_1 == null)
					{
						list.Add(item.Index);
					}
					else
					{
						bool flag = false;
						foreach (DocumentComment item2 in documentCommentList_1)
						{
							if (item2.Index == item.Index)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list.Add(item.Index);
						}
					}
				}
			}
			if (documentCommentList_1 != null)
			{
				foreach (DocumentComment item3 in documentCommentList_1)
				{
					if (documentCommentList_0 == null)
					{
						list.Add(item3.Index);
					}
					else
					{
						bool flag = false;
						foreach (DocumentComment item4 in documentCommentList_0)
						{
							if (item4.Index == item3.Index)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list.Add(item3.Index);
						}
					}
				}
			}
			bool result = false;
			if (list.Count > 0)
			{
				foreach (int item5 in list)
				{
					if (imethod_4(item5))
					{
						result = true;
					}
				}
			}
			return result;
		}

		public bool imethod_6(bool bool_2)
		{
			return method_15(method_0().RuntimeComments, bool_2);
		}

		private bool method_15(DocumentCommentList documentCommentList_0, bool bool_2)
		{
			int num = 7;
			if (documentCommentList_0 == null || documentCommentList_0.Count == 0)
			{
				return false;
			}
			bool result = false;
			DocumentCommentList documentCommentList = null;
			if (bool_2 && method_0().CanLogUndo)
			{
				documentCommentList = method_0().Comments.Clone(deeply: false);
			}
			XTextDocument xTextDocument = method_0();
			XTextContent content = xTextDocument.Body.Content;
			_ = xTextDocument.Comments;
			int[] array = new int[xTextDocument.ContentStyles.Styles.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ((DocumentContentStyle)xTextDocument.ContentStyles.Styles[i]).CommentIndex;
			}
			Dictionary<int, XTextElement> dictionary = new Dictionary<int, XTextElement>();
			for (int num2 = content.Count - 1; num2 >= 0; num2--)
			{
				int styleIndex = content[num2].StyleIndex;
				if (styleIndex >= 0 && styleIndex < array.Length)
				{
					int num3 = array[styleIndex];
					if (num3 >= 0 && !dictionary.ContainsKey(num3))
					{
						dictionary[num3] = content[num2];
					}
				}
			}
			for (int i = 0; i < documentCommentList_0.Count; i++)
			{
				DocumentComment documentComment = documentCommentList_0[i];
				documentComment.Document = xTextDocument;
				if (documentComment.IsInternal)
				{
					continue;
				}
				documentComment.ReferenceElements = null;
				XTextElement value = null;
				if (dictionary.TryGetValue(documentComment.Index, out value))
				{
					if (documentComment.AnchorElement != value)
					{
						documentComment.AnchorElement = value;
						documentComment.Invalidate = true;
						method_12(documentComment);
						result = true;
					}
				}
				else
				{
					method_16(documentComment);
					result = true;
					i--;
				}
			}
			documentCommentList_0.SortForView();
			if (documentCommentList_0 != method_0().Comments)
			{
				method_0().Comments.SortForView();
			}
			if (bool_2 && documentCommentList != null && documentCommentList.Count != method_0().Comments.Count)
			{
				method_0().UndoList.AddProperty("Comments", documentCommentList, method_0().Comments, method_0());
				if ((documentCommentList == null || documentCommentList.Count == 0) != (method_0().Comments == null || method_0().Comments.Count == 0))
				{
					method_0().UndoList.AddMethod(UndoMethodTypes.RefreshComment);
					method_1().method_188(bool_47: false, bool_48: true);
				}
				method_14(bool_2: true);
				result = true;
			}
			return result;
		}

		private void method_16(DocumentComment documentComment_1)
		{
			method_12(documentComment_1);
			int num = method_0().Comments.IndexOf(documentComment_1);
			if (num >= 0)
			{
				method_0().Comments.RemoveAt(num);
			}
		}

		public void imethod_7(DCGraphics dcgraphics_0, RectangleF rectangleF_0, PrintPage printPage_0, bool bool_2)
		{
			int num = 0;
			if (!XTextDocument.smethod_13(GEnum6.const_148))
			{
				return;
			}
			GClass543 gClass = imethod_0();
			DocumentCommentList runtimeComments = method_0().RuntimeComments;
			if (runtimeComments != null && runtimeComments.Count != 0)
			{
				SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
				dcgraphics_0.SmoothingMode = SmoothingMode.HighQuality;
				RectangleF a = method_10(printPage_0);
				RectangleF.Intersect(a, rectangleF_0);
				if (bool_2)
				{
					foreach (DocumentComment item in runtimeComments)
					{
						if (item.RuntimeVisible && item.OwnerPage == printPage_0)
						{
							Color color_ = imethod_8(item);
							Color color = smethod_0(color_);
							RectangleF rectangleF = new RectangleF(item.Left, item.Top, item.Width, item.Height);
							using (XPenStyle xPenStyle = new XPenStyle(color))
							{
								if (item != imethod_9())
								{
									xPenStyle.DashStyle = DashStyle.Dash;
								}
								else
								{
									xPenStyle.Width = 7f;
								}
								XTextElement anchorElement = item.AnchorElement;
								float num2 = anchorElement.AbsLeft + anchorElement.Width;
								float num3 = anchorElement.OwnerLine.AbsBottom + 7f;
								float num4 = printPage_0.Left + printPage_0.Width + gClass.method_8() / 2f;
								dcgraphics_0.DrawLine(xPenStyle, num2, num3, num4, num3);
								dcgraphics_0.DrawLine(xPenStyle, num4, num3, rectangleF.Left, rectangleF.Top + 40f);
							}
						}
					}
				}
				foreach (DocumentComment item2 in runtimeComments)
				{
					if (item2.RuntimeVisible && item2.OwnerPage == printPage_0 && rectangleF_0.IntersectsWith(new Rectangle((int)item2.Left, (int)item2.Top, (int)item2.Width, (int)item2.Height)))
					{
						Color color_ = imethod_8(item2);
						Color color = smethod_0(color_);
						RectangleF rectangleF = new RectangleF(item2.Left, item2.Top, item2.Width, item2.Height);
						dcgraphics_0.FillRoundRectangle(color_, rectangleF, method_2());
						XFontValue xFontValue = method_11(method_0());
						string text = item2.Title;
						if (string.IsNullOrEmpty(text))
						{
							try
							{
								text = item2.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
								if (!string.IsNullOrEmpty(method_0().Options.ViewOptions.CommentDateFormatString))
								{
									text = item2.CreationTime.ToString(method_0().Options.ViewOptions.CommentDateFormatString);
								}
							}
							catch (Exception ex)
							{
								text = "";
								Debug.WriteLine(ex.Message);
							}
						}
						if (!string.IsNullOrEmpty(item2.Author))
						{
							text = item2.Author + "," + text;
						}
						RectangleF rect = new RectangleF(rectangleF.Left + gClass.method_8(), rectangleF.Top + gClass.method_8(), rectangleF.Width - gClass.method_8() * 2f, xFontValue.GetHeight(dcgraphics_0) + 10f);
						using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
						{
							drawStringFormatExt.Alignment = StringAlignment.Near;
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
							drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap);
							xFontValue.Bold = true;
							dcgraphics_0.DrawString(text, xFontValue, item2.ForeColor, rect, drawStringFormatExt);
						}
						if (!string.IsNullOrEmpty(item2.Text))
						{
							RectangleF rect2 = new RectangleF(rectangleF.Left + gClass.method_8(), rect.Bottom, rectangleF.Width - gClass.method_8() * 2f + 0.5f, rectangleF.Height - gClass.method_8() * 2f - rect.Height);
							using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
							{
								xFontValue.Bold = false;
								drawStringFormatExt.Alignment = StringAlignment.Near;
								drawStringFormatExt.LineAlignment = StringAlignment.Near;
								drawStringFormatExt.FormatFlags = StringFormatFlags.FitBlackBox;
								dcgraphics_0.DrawString(item2.Text, xFontValue, item2.ForeColor, rect2, drawStringFormatExt);
							}
						}
						float lineWidth = 1f;
						if (item2 == imethod_9())
						{
							lineWidth = 7f;
						}
						dcgraphics_0.DrawRoundRectangle(color, lineWidth, rectangleF, method_2());
						if (!bool_2)
						{
							using (XPenStyle xPenStyle = new XPenStyle(color))
							{
								if (item2 != imethod_9())
								{
									xPenStyle.DashStyle = DashStyle.Dash;
								}
								else
								{
									xPenStyle.Width = 7f;
								}
								XTextElement anchorElement = item2.AnchorElement;
								float num2 = anchorElement.AbsLeft + anchorElement.Width;
								float num3 = anchorElement.OwnerLine.AbsBottom;
								float num4 = printPage_0.Left + printPage_0.Width + gClass.method_8() / 2f;
								dcgraphics_0.DrawLine(xPenStyle, num2, num3, num4, num3);
								dcgraphics_0.DrawLine(xPenStyle, num4, num3, rectangleF.Left, rectangleF.Top + 40f);
							}
						}
					}
				}
				dcgraphics_0.SmoothingMode = smoothingMode;
			}
		}

		public Color imethod_8(DocumentComment documentComment_1)
		{
			if (documentComment_1 == imethod_9())
			{
				return documentComment_1.BackColor;
			}
			return Color.FromArgb(100, documentComment_1.BackColor);
		}

		public static Color smethod_0(Color color_0)
		{
			return ControlPaint.Dark(color_0, 0.1f);
		}

		public DocumentComment imethod_9()
		{
			return documentComment_0;
		}

		public void imethod_10(DocumentComment documentComment_1)
		{
			documentComment_0 = documentComment_1;
		}
	}
}
