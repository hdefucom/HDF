using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       段落列表元素
	///       </summary>
	[ComVisible(false)]
	public class XTextParagraphListItemElement : XTextElement
	{
		[ComVisible(false)]
		[DCInternal]
		public class GClass5
		{
			public string string_0;

			public XFontValue xfontValue_0;

			public SizeF sizeF_0;

			public Color color_0;

			public GClass5(DocumentContentStyle documentContentStyle_0, int int_0)
			{
				int num = 12;
				string_0 = null;
				xfontValue_0 = null;
				sizeF_0 = new SizeF(0f, 0f);
				color_0 = Color.Black;
				
				color_0 = documentContentStyle_0.Color;
				if (documentContentStyle_0.IsBulletedList)
				{
					string_0 = documentContentStyle_0.BulletedString;
					xfontValue_0 = new XFontValue("Wingdings", documentContentStyle_0.FontSize);
				}
				else
				{
					string text = string_0 = documentContentStyle_0.method_26(int_0);
					xfontValue_0 = new XFontValue(XFontValue.DefaultFontName, documentContentStyle_0.FontSize);
				}
			}

			public GClass5(XTextParagraphListItemElement xtextParagraphListItemElement_0, bool bool_0, bool bool_1)
			{
				int num = 18;
				string_0 = null;
				xfontValue_0 = null;
				sizeF_0 = new SizeF(0f, 0f);
				color_0 = Color.Black;
				
				RuntimeDocumentContentStyle runtimeStyle = xtextParagraphListItemElement_0.ParagraphFlagElement.RuntimeStyle;
				color_0 = xtextParagraphListItemElement_0.method_4(runtimeStyle.Color);
				if (runtimeStyle.IsBulletedList)
				{
					string_0 = runtimeStyle.BulletedString;
					xfontValue_0 = new XFontValue("Wingdings", runtimeStyle.FontSize);
					if (bool_1)
					{
						char[] array = string_0.ToCharArray();
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = (char)(array[i] & 0xFF);
						}
						string_0 = new string(array);
					}
					return;
				}
				string text = null;
				if (!runtimeStyle.ParagraphMultiLevel)
				{
					text = ((!bool_0) ? runtimeStyle.GetParagraphListText(xtextParagraphListItemElement_0.ParagraphFlagElement.ListIndex) : runtimeStyle.GetParagraphListText(xtextParagraphListItemElement_0.ParagraphFlagElement.MaxListIndex));
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					XTextParagraphFlagElement xTextParagraphFlagElement = xtextParagraphListItemElement_0.ParagraphFlagElement;
					while (xTextParagraphFlagElement != null && !xTextParagraphFlagElement.IsRootLevelElement)
					{
						if (GClass470.smethod_7(xTextParagraphFlagElement.ListStyle))
						{
							if (bool_0)
							{
								stringBuilder.Insert(0, runtimeStyle.GetParagraphListText(xTextParagraphFlagElement.MaxListIndex));
							}
							else
							{
								stringBuilder.Insert(0, runtimeStyle.GetParagraphListText(xTextParagraphFlagElement.ListIndex));
							}
						}
						xTextParagraphFlagElement = xTextParagraphFlagElement.ParentParagraph;
					}
					text = stringBuilder.ToString();
				}
				ContentLayoutDirectionStyle contentLayoutDirectionStyle = ContentLayoutDirectionStyle.LeftToRight;
				if (xtextParagraphListItemElement_0.ParagraphFlagElement != null && xtextParagraphListItemElement_0.ParagraphFlagElement.OwnerLine != null)
				{
					contentLayoutDirectionStyle = xtextParagraphListItemElement_0.ParagraphFlagElement.OwnerLine.RuntimeLayoutDirection;
				}
				if (contentLayoutDirectionStyle == ContentLayoutDirectionStyle.RightToLeft && text.EndsWith("."))
				{
					text = "." + text.Substring(0, text.Length - 1);
				}
				string_0 = text;
				xfontValue_0 = new XFontValue(XFontValue.DefaultFontName, runtimeStyle.FontSize);
			}

			public void method_0(DCGraphics dcgraphics_0)
			{
				if (string.IsNullOrEmpty(string_0))
				{
					sizeF_0 = new SizeF(100f, 0f);
				}
				else
				{
					sizeF_0 = dcgraphics_0.MeasureString(string_0, xfontValue_0, 100000, DrawStringFormatExt.GenericTypographic);
					if (sizeF_0.Width < 100f)
					{
						sizeF_0.Width = 100f;
					}
					else
					{
						sizeF_0.Width += 20f;
					}
				}
				sizeF_0.Height = dcgraphics_0.GetFontHeight(xfontValue_0) + 3.125f;
			}
		}

		private XTextParagraphFlagElement xtextParagraphFlagElement_0 = null;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		public override string DomDisplayName => "LI:" + Text;

		/// <summary>
		///       本对象所对应的段落标记元素
		///       </summary>
		internal XTextParagraphFlagElement ParagraphFlagElement
		{
			get
			{
				return xtextParagraphFlagElement_0;
			}
			set
			{
				xtextParagraphFlagElement_0 = value;
				if (xtextParagraphFlagElement_0 != null)
				{
					xtextParagraphFlagElement_0.ListItemElement = this;
				}
			}
		}

		/// <summary>
		///       返回表示对象的文本
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override string Text
		{
			get
			{
				int num = 5;
				RuntimeDocumentContentStyle runtimeStyle = ParagraphFlagElement.RuntimeStyle;
				if (runtimeStyle.IsBulletedList)
				{
					switch (runtimeStyle.ParagraphListStyle)
					{
					default:
						return "●";
					case ParagraphListStyle.BulletedList:
						return "●";
					case ParagraphListStyle.BulletedListBlock:
						return "■";
					case ParagraphListStyle.BulletedListDiamond:
						return "◆";
					case ParagraphListStyle.BulletedListCheck:
						return "√";
					case ParagraphListStyle.BulletedListRightArrow:
						return "＞";
					case ParagraphListStyle.BulletedListHollowStar:
						return "◇";
					}
				}
				if (runtimeStyle.IsListNumberStyle)
				{
					GClass5 gClass = new GClass5(this, bool_0: false, bool_1: false);
					return gClass.string_0;
				}
				return "";
			}
			set
			{
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		internal XTextParagraphListItemElement()
		{
		}

		/// <summary>
		///       重新计算对象大小
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			method_13(args.Graphics);
		}

		internal void method_13(DCGraphics dcgraphics_0)
		{
			GClass5 gClass = new GClass5(this, bool_0: true, bool_1: false);
			gClass.method_0(dcgraphics_0);
			Width = gClass.sizeF_0.Width;
			Height = gClass.sizeF_0.Height;
		}

		public static SizeF smethod_0(DocumentContentStyle documentContentStyle_1, DCGraphics dcgraphics_0, int int_6)
		{
			GClass5 gClass = new GClass5(documentContentStyle_1, int_6);
			gClass.method_0(dcgraphics_0);
			return gClass.sizeF_0;
		}

		/// <summary>
		///       绘制对象
		///       </summary>
		/// <param name="args">
		/// </param>
		public override void Draw(DocumentPaintEventArgs args)
		{
			if (drawStringFormatExt_0 == null)
			{
				drawStringFormatExt_0 = new DrawStringFormatExt();
				drawStringFormatExt_0.Alignment = StringAlignment.Near;
				drawStringFormatExt_0.LineAlignment = StringAlignment.Far;
				drawStringFormatExt_0.FormatFlags = StringFormatFlags.NoWrap;
			}
			GClass5 gClass = new GClass5(this, bool_0: false, args.Graphics.IsPDFMode);
			if (!string.IsNullOrEmpty(gClass.string_0))
			{
				if (args.RenderMode == DocumentRenderMode.PDF)
				{
					args.Graphics.DrawString(gClass.string_0, gClass.xfontValue_0, gClass.color_0, args.ViewBounds, drawStringFormatExt_0);
				}
				else
				{
					args.Graphics.DrawString(gClass.string_0, gClass.xfontValue_0, gClass.color_0, args.ViewBounds.X, args.ViewBounds.Y);
				}
			}
		}
	}
}
