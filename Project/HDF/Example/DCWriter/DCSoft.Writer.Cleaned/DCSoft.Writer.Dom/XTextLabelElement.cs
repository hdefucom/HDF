#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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
	///       简单文本标签元素
	///       </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComClass("00012345-6789-ABCD-EF01-23456789008F", "AB8B3F31-C36E-4EF5-8A73-84397555E16C")]
	[Guid("00012345-6789-ABCD-EF01-23456789008F")]
	[DCPublishAPI]
	[DocumentComment]
	[ComDefaultInterface(typeof(IXTextLabelElement))]
	[DebuggerDisplay("Label:{Text}")]
	public sealed class XTextLabelElement : XTextLabelElementBase, IXTextLabelElement
	{
		internal const string string_10 = "00012345-6789-ABCD-EF01-23456789008F";

		internal const string string_11 = "AB8B3F31-C36E-4EF5-8A73-84397555E16C";

		private bool bool_11 = false;

		private int int_8 = -1;

		private LabelTextContactActionMode labelTextContactActionMode_0 = LabelTextContactActionMode.Disable;

		private string string_12 = null;

		private string string_13 = null;

		private DCContentAlignment dccontentAlignment_0 = DCContentAlignment.MiddleCenter;

		private bool bool_12 = true;

		private bool bool_13 = true;

		[DCInternal]
		public override string DomDisplayName => "Label:" + base.ID;

		/// <summary>
		///       允许用户编辑当前页标签文本
		///       </summary>
		[XmlElement]
		[MemberExpressionable]
		[HtmlAttribute]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(false)]
		[DCPublishAPI]
		public bool AllowUserEditCurrentPageLabelText
		{
			get
			{
				return bool_11;
			}
			set
			{
				bool_11 = value;
			}
		}

		/// <summary>
		///       引用的主题编号,DCWriter内部使用.
		///       </summary>
		[DefaultValue(-1)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[HtmlAttribute]
		[XmlElement]
		public int ReferencedTopicID
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
		///       文本连接模式
		///       </summary>
		[ComVisible(true)]
		[DCPublishAPI]
		[DefaultValue(LabelTextContactActionMode.Disable)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		public LabelTextContactActionMode ContactAction
		{
			get
			{
				return labelTextContactActionMode_0;
			}
			set
			{
				labelTextContactActionMode_0 = value;
			}
		}

		/// <summary>
		///       执行连接动作使用的属性名
		///       </summary>
		[MemberExpressionable]
		[ComVisible(true)]
		[DefaultValue(null)]
		[DCPublishAPI]
		[HtmlAttribute]
		public string AttributeNameForContactAction
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
		///       各个项目之间的连接字符串
		///       </summary>
		[ComVisible(true)]
		[HtmlAttribute]
		[DefaultValue(null)]
		[DCPublishAPI]
		public string LinkTextForContactAction
		{
			get
			{
				return string_13;
			}
			set
			{
				string_13 = value;
			}
		}

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "label";

		/// <summary>
		///       内容对齐方式
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[DCPublishAPI]
		[HtmlAttribute]
		[DefaultValue(DCContentAlignment.MiddleCenter)]
		public DCContentAlignment Alignment
		{
			get
			{
				return dccontentAlignment_0;
			}
			set
			{
				dccontentAlignment_0 = value;
			}
		}

		/// <summary>
		///       多行文本
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public bool Multiline
		{
			get
			{
				return bool_12;
			}
			set
			{
				bool_12 = value;
			}
		}

		internal bool RuntimeMultiline
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_196))
				{
					return bool_12;
				}
				return true;
			}
		}

		/// <summary>
		///       自动计算大小
		///       </summary>
		[DefaultValue(true)]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		[DCPublishAPI]
		public bool AutoSize
		{
			get
			{
				return bool_13;
			}
			set
			{
				bool_13 = value;
			}
		}

		/// <summary>
		///       运行时的是否自动设置大小
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public override bool RuntimeAutoSize
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_194))
				{
					return bool_13;
				}
				return true;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextLabelElement()
		{
			Width = 100f;
			Height = 100f;
		}

		protected override bool vmethod_26()
		{
			return true;
		}

		[DCInternal]
		public override void OnViewMouseDblClick(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			base.OnViewMouseDblClick(elementMouseEventArgs_0);
			if (elementMouseEventArgs_0.Button == MouseButtons.Left && !elementMouseEventArgs_0.Handled && AllowUserEditCurrentPageLabelText && !RuntimeContentReadonly && WriterControl != null && WriterControl.EditLabelPageText(this))
			{
				elementMouseEventArgs_0.Handled = true;
			}
		}

		[DCInternal]
		public bool UpdateContactAction()
		{
			if (!XTextDocument.smethod_13(GEnum6.const_197))
			{
				return false;
			}
			if (ContactAction == LabelTextContactActionMode.Disable)
			{
				return false;
			}
			if (string.IsNullOrEmpty(AttributeNameForContactAction))
			{
				return false;
			}
			try
			{
				XTextDocument ownerDocument = OwnerDocument;
				base.PageTexts.Clear();
				if (ContactAction == LabelTextContactActionMode.TableRow)
				{
					XTextElementList elementsByType = ownerDocument.Body.GetElementsByType(typeof(XTextTableRowElement));
					for (int i = 0; i < ownerDocument.Pages.Count; i++)
					{
						StringBuilder stringBuilder = new StringBuilder();
						string text = null;
						new List<XTextTableRowElement>();
						for (int num = elementsByType.Count - 1; num >= 0; num--)
						{
							XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)elementsByType[num];
							if (xTextTableRowElement.OwnerPageIndex == i)
							{
								elementsByType.RemoveAt(num);
								string attribute = xTextTableRowElement.GetAttribute(AttributeNameForContactAction);
								if (!string.IsNullOrEmpty(attribute) && (text == null || text != attribute))
								{
									text = attribute;
									if (stringBuilder.Length > 0 && !string.IsNullOrEmpty(LinkTextForContactAction))
									{
										stringBuilder.Insert(0, LinkTextForContactAction);
									}
									stringBuilder.Insert(0, attribute);
								}
							}
						}
						base.PageTexts.SetPageText(i, stringBuilder.ToString());
					}
					return true;
				}
				if (ContactAction == LabelTextContactActionMode.FirstTableRowInPage)
				{
					XTextElementList elementsByType = ownerDocument.Body.GetElementsByType(typeof(XTextTableRowElement));
					for (int i = 0; i < ownerDocument.Pages.Count; i++)
					{
						PrintPage printPage = ownerDocument.Pages[i];
						foreach (XTextTableRowElement item in elementsByType)
						{
							if (item.OwnerPageIndex == i)
							{
								string attribute = item.GetAttribute(AttributeNameForContactAction);
								if (!string.IsNullOrEmpty(attribute))
								{
									base.PageTexts.SetPageText(i, attribute);
									break;
								}
							}
						}
					}
					return true;
				}
				if (ContactAction == LabelTextContactActionMode.LastTableRowInPage)
				{
					XTextElementList elementsByType = ownerDocument.Body.GetElementsByType(typeof(XTextTableRowElement));
					for (int i = 0; i < ownerDocument.Pages.Count; i++)
					{
						PrintPage printPage = ownerDocument.Pages[i];
						for (int num2 = elementsByType.Count - 1; num2 >= 0; num2--)
						{
							XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)elementsByType[num2];
							if (xTextTableRowElement.OwnerPageIndex == i)
							{
								string attribute = xTextTableRowElement.GetAttribute(AttributeNameForContactAction);
								if (!string.IsNullOrEmpty(attribute))
								{
									base.PageTexts.SetPageText(i, attribute);
									break;
								}
							}
						}
					}
					return true;
				}
				if (ContactAction == LabelTextContactActionMode.Normal)
				{
					XTextLineList allLines = ownerDocument.Body.GetAllLines();
					for (int i = 0; i < ownerDocument.Pages.Count; i++)
					{
						PrintPage printPage = ownerDocument.Pages[i];
						StringBuilder stringBuilder = new StringBuilder();
						string text = null;
						List<XTextSectionElement> list = new List<XTextSectionElement>();
						int num3 = 0;
						int num2 = 0;
						while (i < allLines.Count)
						{
							if (allLines[num2].OwnerPage != printPage)
							{
								num3 = num2 - 1;
								break;
							}
							num2++;
						}
						if (num3 >= 0)
						{
							for (num2 = num3; num2 >= 0; num2--)
							{
								XTextLine xTextLine = allLines[num2];
								if ((!xTextLine.IsSectionLine || xTextLine.SectionElement.RuntimeIsCollapsed) && !xTextLine.IsPageBreakLine)
								{
									XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextLine[0].GetOwnerParent(typeof(XTextSectionElement), includeThis: true);
									if (xTextSectionElement != null && !list.Contains(xTextSectionElement))
									{
										list.Add(xTextSectionElement);
										string attribute = xTextSectionElement.GetAttribute(AttributeNameForContactAction);
										if (!string.IsNullOrEmpty(attribute) && (text == null || text != attribute))
										{
											text = attribute;
											if (stringBuilder.Length > 0 && !string.IsNullOrEmpty(LinkTextForContactAction))
											{
												stringBuilder.Insert(0, LinkTextForContactAction);
											}
											stringBuilder.Insert(0, attribute);
										}
									}
								}
							}
							allLines.RemoveRange(0, num3 + 1);
						}
						base.PageTexts.SetPageText(i, stringBuilder.ToString());
					}
					return true;
				}
				if (ContactAction == LabelTextContactActionMode.FirstSectionInPage)
				{
					XTextLineList allLines = ownerDocument.Body.GetAllLines();
					for (int i = 0; i < ownerDocument.Pages.Count; i++)
					{
						PrintPage printPage = ownerDocument.Pages[i];
						foreach (XTextLine item2 in allLines)
						{
							if (!item2.IsSectionLine && !item2.IsPageBreakLine && item2.OwnerPage == printPage)
							{
								XTextSectionElement xTextSectionElement = (XTextSectionElement)item2[0].GetOwnerParent(typeof(XTextSectionElement), includeThis: true);
								if (xTextSectionElement != null)
								{
									string attribute = xTextSectionElement.GetAttribute(AttributeNameForContactAction);
									if (!string.IsNullOrEmpty(attribute))
									{
										base.PageTexts.SetPageText(i, attribute);
										break;
									}
								}
							}
						}
					}
					return true;
				}
				if (ContactAction == LabelTextContactActionMode.LastSectionInPage)
				{
					XTextLineList allLines = ownerDocument.Body.GetAllLines();
					for (int i = 0; i < ownerDocument.Pages.Count; i++)
					{
						PrintPage printPage = ownerDocument.Pages[i];
						for (int num2 = allLines.Count - 1; num2 >= 0; num2--)
						{
							XTextLine xTextLine = allLines[num2];
							if (!xTextLine.IsSectionLine && !xTextLine.IsPageBreakLine && xTextLine.OwnerPage == printPage)
							{
								XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextLine[0].GetOwnerParent(typeof(XTextSectionElement), includeThis: true);
								if (xTextSectionElement != null)
								{
									string attribute = xTextSectionElement.GetAttribute(AttributeNameForContactAction);
									if (!string.IsNullOrEmpty(attribute))
									{
										base.PageTexts.SetPageText(i, attribute);
										break;
									}
								}
							}
						}
					}
					return true;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
			return false;
		}

		/// <summary>
		///       文档元素加载后处理
		///       </summary>
		/// <param name="args">事件参数</param>
		[DCInternal]
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			base.AfterLoad(args);
			if (OwnerDocument != null && OwnerDocument.ExpressionExecuter != null)
			{
				OwnerDocument.ExpressionExecuter.imethod_4(this);
			}
		}

		[DCInternal]
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			if (RuntimeAutoSize)
			{
				XTextDocument ownerDocument = OwnerDocument;
				List<string> list = new List<string>();
				list.Add(Text);
				foreach (PageLabelText pageText in base.PageTexts)
				{
					list.Add(pageText.Text);
				}
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				SizeF sizeF = GraphicsUnitConvert.Convert(new Size(5, 15), GraphicsUnit.Pixel, ownerDocument.DocumentGraphicsUnit);
				foreach (string item in list)
				{
					if (!string.IsNullOrEmpty(item))
					{
						SizeF sizeF2 = GraphicsUnitConvert.Convert(new Size(5, 15), GraphicsUnit.Pixel, ownerDocument.DocumentGraphicsUnit);
						sizeF2.Width = args.Graphics.MeasureString(item, runtimeStyle.Font, (int)(runtimeStyle.Multiline ? Width : 10000f), args.Render.method_10()).Width;
						sizeF2.Height = Math.Max(sizeF2.Height, args.Graphics.GetFontHeight(runtimeStyle.Font));
						sizeF.Width = Math.Max(sizeF.Width, sizeF2.Width);
						sizeF.Height = Math.Max(sizeF.Height, sizeF2.Height);
					}
				}
				Width = sizeF.Width;
				Height = sizeF.Height;
			}
			SizeInvalid = false;
		}

		[DCInternal]
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			_ = AbsBounds;
			string text = method_16(args.Document.PageIndex);
			if (!string.IsNullOrEmpty(text))
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				DrawStringFormatExt drawStringFormatExt = args.Render.method_10().Clone();
				RectangleF clientViewBounds = args.ClientViewBounds;
				clientViewBounds.Y += args.Render.method_9().method_0();
				clientViewBounds.X += 3f;
				drawStringFormatExt.SetStringFormatAlignment((ContentAlignment)Alignment);
				if (RuntimeAutoSize)
				{
					drawStringFormatExt.LineAlignment = StringAlignment.Near;
					drawStringFormatExt.Alignment = StringAlignment.Near;
					drawStringFormatExt.FormatFlags |= StringFormatFlags.NoClip;
				}
				else
				{
					drawStringFormatExt.FormatFlags &= ~StringFormatFlags.NoClip;
				}
				if (!RuntimeMultiline)
				{
					drawStringFormatExt.FormatFlags |= StringFormatFlags.NoWrap;
				}
				if (args.RenderMode == DocumentRenderMode.Paint)
				{
					float offsetX = args.Graphics.Transform.OffsetX;
					float num = GraphicsUnitConvert.Convert(1f, GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
					clientViewBounds.X = (float)(int)((clientViewBounds.X + offsetX) / num) * num - offsetX;
				}
				if (args.RenderMode == DocumentRenderMode.PDF)
				{
					clientViewBounds.Width += text.Length;
				}
				drawStringFormatExt.Font = runtimeStyle.Font;
				drawStringFormatExt.Color = method_4(runtimeStyle.Color);
				drawStringFormatExt.SetBounds(clientViewBounds);
				args.Graphics.method_2(text, drawStringFormatExt);
			}
		}
	}
}
