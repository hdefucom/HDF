using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       输入域边界元素
	///       </summary>
	[Serializable]
	[Guid("CA5222A8-8BA7-4D20-AB00-EFE3C2865400")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextFieldBorderElement))]
	
	
	[ComClass("CA5222A8-8BA7-4D20-AB00-EFE3C2865400", "7D241B15-732B-42D4-8C46-D37365E00837")]
	[ComVisible(true)]
	public class XTextFieldBorderElement : XTextElement, IXTextFieldBorderElement
	{
		internal const string string_3 = "CA5222A8-8BA7-4D20-AB00-EFE3C2865400";

		internal const string string_4 = "7D241B15-732B-42D4-8C46-D37365E00837";

		public static float float_5 = 4f;

		internal float float_6 = 0f;

		internal float float_7 = 0f;

		internal float float_8 = 0f;

		internal bool bool_5 = false;

		private BorderElementPosition borderElementPosition_0 = BorderElementPosition.Start;

		[NonSerialized]
		private float float_9 = 0f;

		private string string_5 = null;

		private float float_10 = 0f;

		[NonSerialized]
		internal RectangleF rectangleF_0 = RectangleF.Empty;

		private float float_11 = 0f;

		public override string DomDisplayName
		{
			get
			{
				int num = 15;
				string text = ToPlaintString();
				if (string.IsNullOrEmpty(text))
				{
					return "[FieldBorder]" + Position;
				}
				return text;
			}
		}

		[ComVisible(false)]
		[Browsable(false)]
		public Color RuntimeBorderColor
		{
			get
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)Parent;
				Color result = xTextFieldElementBase.BorderElementColor;
				if (result.A == 0)
				{
					result = Color.Blue;
					DocumentViewOptions viewOptions = OwnerDocument.Options.ViewOptions;
					if (!viewOptions.FieldBorderColor.IsEmpty)
					{
						result = viewOptions.FieldBorderColor;
					}
					else if (xTextFieldElementBase.RuntimeContentReadonly)
					{
						result = viewOptions.ReadonlyFieldBorderColor;
					}
					else if (Parent is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)Parent;
						result = (xTextInputFieldElement.RuntimeUserEditable ? viewOptions.NormalFieldBorderColor : viewOptions.UnEditableFieldBorderColor);
					}
				}
				return result;
			}
		}

		/// <summary>
		///       表单按钮样式
		///       </summary>
		internal FormButtonStyle ButtonStyle
		{
			get
			{
				XTextInputFieldElement xTextInputFieldElement = Parent as XTextInputFieldElement;
				if (xTextInputFieldElement == null)
				{
					return FormButtonStyle.None;
				}
				if (xTextInputFieldElement.EndElement == this)
				{
					return xTextInputFieldElement.RuntimeFormButtonStyle;
				}
				return FormButtonStyle.None;
			}
		}

		/// <summary>
		///       元素宽度
		///       </summary>
		[Browsable(true)]
		[XmlIgnore]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				float width = base.Width;
				if (width != value)
				{
					base.Width = value;
				}
			}
		}

		/// <summary>
		///       视图宽度
		///       </summary>
		[Browsable(false)]
		public override float ViewWidth => Math.Max(Width, 12.5f);

		/// <summary>
		///       位置
		///       </summary>
		public BorderElementPosition Position
		{
			get
			{
				return borderElementPosition_0;
			}
			set
			{
				borderElementPosition_0 = value;
			}
		}

		/// <summary>
		///       对象所属的文档域对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public XTextFieldElementBase OwnerField
		{
			get
			{
				if (Parent is XTextFieldElementBase)
				{
					return (XTextFieldElementBase)Parent;
				}
				return null;
			}
		}

		/// <summary>
		///       对象所属文档对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override XTextDocument OwnerDocument
		{
			get
			{
				if (Parent != null)
				{
					return Parent.OwnerDocument;
				}
				return base.OwnerDocument;
			}
			set
			{
				base.OwnerDocument = value;
			}
		}

		/// <summary>
		///       本元素的影子元素就是其所处的输入域容器对象
		///       </summary>
		[Browsable(false)]
		public override XTextElement ShadowElement => Parent;

		/// <summary>
		///       内容宽度
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public float ContentWidth
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
		///       文本
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override string Text
		{
			get
			{
				if (string_5 == null && Parent is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)Parent;
					if (xTextInputFieldElementBase.EndElement == this)
					{
						return xTextInputFieldElementBase.RuntimeUnitText;
					}
					if (xTextInputFieldElementBase.StartElement == this)
					{
						return xTextInputFieldElementBase.RuntimeLabelText;
					}
				}
				return string_5;
			}
			set
			{
				string_5 = value;
			}
		}

		/// <summary>
		///       运行时的边框宽度
		///       </summary>
		internal float RuntimeBorderWidth
		{
			get
			{
				return float_10;
			}
			set
			{
				float_10 = value;
			}
		}

		/// <summary>
		///       边框文本
		///       </summary>
		internal string BorderText
		{
			get
			{
				XTextFieldElementBase xTextFieldElementBase = Parent as XTextFieldElementBase;
				if (xTextFieldElementBase != null)
				{
					if (this == xTextFieldElementBase.StartElement)
					{
						return xTextFieldElementBase.RuntimeStartBorderText;
					}
					if (this == xTextFieldElementBase.EndElement)
					{
						return xTextFieldElementBase.RuntimeEndBorderText;
					}
				}
				return null;
			}
		}

		/// <summary>
		///       标准高度
		///       </summary>
		internal float StandardHeight
		{
			get
			{
				if (OwnerDocument == null)
				{
					return GraphicsUnitConvert.Convert(16, GraphicsUnit.Pixel, GraphicsUnit.Document);
				}
				return GraphicsUnitConvert.Convert(16, GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
			}
		}

		/// <summary>
		///       文档域边框元素不能处理事件
		///       </summary>
		public override ElementEventTemplateList Events => null;

		internal void method_13()
		{
			if (!bool_5)
			{
				XTextFieldElementBase xTextFieldElementBase = Parent as XTextFieldElementBase;
				if (xTextFieldElementBase != null && !xTextFieldElementBase.HasContentElement && string.IsNullOrEmpty(Text) && string.IsNullOrEmpty(BorderText))
				{
					Width = 12.5f;
				}
				else
				{
					Width = ContentWidth;
				}
			}
		}

		/// <summary>
		///       判断元素是否挂在指定文档的DOM结构中
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="checkLogicDelete">检查逻辑删除标记</param>
		/// <returns>是否挂在DOM结构中</returns>
		public override bool BelongToDocumentDom(XTextDocument document, bool checkLogicDelete)
		{
			if (Parent == null)
			{
				return false;
			}
			return Parent.BelongToDocumentDom(document, checkLogicDelete);
		}

		public override bool vmethod_3(GInterface5 ginterface5_0)
		{
			if (base.vmethod_3(ginterface5_0) && (!string.IsNullOrEmpty(Text) || !string.IsNullOrEmpty(BorderText)))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       文档域边框元素不能处理事件
		///       </summary>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.MouseClick)
			{
				if (ButtonStyle != 0 && args.Button == MouseButtons.Left)
				{
					RectangleF rectangleF = rectangleF_0;
					InvalidateView();
					if (rectangleF.Contains(args.ViewX, args.ViewY))
					{
						OwnerDocument.EditorControl.method_21(Parent, bool_12: false, ValueEditorActiveMode.F2, bool_13: false, bool_14: true);
						args.Cursor = Cursors.Arrow;
						args.Handled = true;
						args.CancelBubble = true;
					}
				}
			}
			else if ((args.Style == DocumentEventStyles.MouseMove || args.Style == DocumentEventStyles.MouseDown || args.Style == DocumentEventStyles.MouseUp) && ButtonStyle != 0 && rectangleF_0.Contains(args.ViewX, args.ViewY))
			{
				args.Cursor = Cursors.Arrow;
				args.Handled = true;
				args.CancelBubble = true;
			}
		}

		/// <summary>
		///       返回空
		///       </summary>
		/// <param name="includeThis">
		/// </param>
		/// <returns>
		/// </returns>
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			return null;
		}

		/// <summary>
		///       返回纯文本数据
		///       </summary>
		/// <returns>文本数据</returns>
		public override string ToPlaintString()
		{
			if (OwnerDocument != null && OwnerDocument.Options.BehaviorOptions.OutputFieldBorderTextToContentText)
			{
				if (Position == BorderElementPosition.Start)
				{
					return BorderText + Text;
				}
				return Text + BorderText;
			}
			return Text;
		}

		/// <summary>
		///       返回表示对象的文本
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			int num = 11;
			if (Position == BorderElementPosition.Start)
			{
				return "【";
			}
			if (Position == BorderElementPosition.End)
			{
				return "】";
			}
			return "FieldBorder";
		}

		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			float_6 = 0f;
			float_7 = 0f;
			float_11 = 0f;
			XTextDocument ownerDocument = OwnerDocument;
			SizeF sizeF = System.Drawing.Size.Empty;
			RuntimeBorderWidth = ownerDocument.PixelToDocumentUnit(ownerDocument.Info.FieldBorderElementWidth);
			if (!string.IsNullOrEmpty(Text) || !string.IsNullOrEmpty(BorderText))
			{
				if (!string.IsNullOrEmpty(BorderText))
				{
					bool flag = true;
					if (args.RenderMode == DocumentRenderMode.Print && ownerDocument.Options.ViewOptions.IgnoreFieldBorderWhenPrint)
					{
						flag = false;
					}
					else if (!ownerDocument.Options.ViewOptions.ShowFieldBorderElement)
					{
						flag = false;
					}
					if (flag)
					{
						RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
						SizeF sizeF2 = args.Graphics.MeasureString(BorderText, runtimeStyle.Font, 10000, args.Render.method_12());
						RuntimeBorderWidth = sizeF2.Width;
						Height = Math.Max(Height, args.Graphics.GetFontHeight(runtimeStyle.Font));
						float_11 = sizeF2.Width;
						sizeF.Height = Height;
					}
				}
				sizeF.Height = Math.Max(sizeF.Height, ownerDocument.PixelToDocumentUnit(16f));
				float num = RuntimeBorderWidth;
				Height = sizeF.Height;
				ContentWidth = 0f;
				string text = Text;
				if (!string.IsNullOrEmpty(text))
				{
					RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
					SizeF sizeF2 = args.Graphics.MeasureString(text, runtimeStyle.Font, 10000, args.Render.method_10());
					float_8 = sizeF2.Width;
					float_6 = sizeF2.Height;
					num += sizeF2.Width;
					Height = Math.Max(Height, args.Graphics.GetFontHeight(runtimeStyle.Font));
				}
				if (ButtonStyle != 0 && OwnerDocument.Options.ViewOptions.ShowFormButton)
				{
					num += ownerDocument.PixelToDocumentUnit(18f);
				}
				Width = num;
			}
			else
			{
				float num = RuntimeBorderWidth;
				if (ButtonStyle != 0 && OwnerDocument.Options.ViewOptions.ShowFormButton)
				{
					num += ownerDocument.PixelToDocumentUnit(18f);
				}
				Width = num;
			}
			SizeInvalid = false;
			ContentWidth = Width;
		}

		public override void Draw(DocumentPaintEventArgs args)
		{
			XTextDocument ownerDocument = OwnerDocument;
			XTextFieldElementBase ownerField = OwnerField;
			if (ownerField == null)
			{
				return;
			}
			args.Render.vmethod_3(this, args);
			ownerDocument.PixelToDocumentUnit(1f);
			RectangleF absBounds = AbsBounds;
			absBounds.Y += args.Render.method_9().method_0();
			int num = 0;
			if (base.OwnerLine.RuntimeLayoutDirection != ContentLayoutDirectionStyle.RightToLeft)
			{
				num = ((ownerField.StartElement != this) ? 1 : 0);
			}
			else if (ownerField.StartElement == this)
			{
				num = 1;
			}
			else if (ownerField.StartElement == this)
			{
				num = 0;
			}
			switch (num)
			{
			case 0:
				absBounds.Width = RuntimeBorderWidth;
				break;
			case 1:
				absBounds.X = absBounds.Right - RuntimeBorderWidth;
				absBounds.Width = RuntimeBorderWidth;
				break;
			}
			RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
			RectangleF rectangleF = new RectangleF(AbsLeft + float_11, absBounds.Top, 0f, float_6 * 1.5f);
			if (num == 1)
			{
				rectangleF.X = AbsLeft;
			}
			if (float_6 <= 0f)
			{
				rectangleF.Y = absBounds.Top;
			}
			if (!string.IsNullOrEmpty(Text))
			{
				rectangleF.Width = float_8;
				if (num != 0)
				{
				}
				using (DrawStringFormatExt drawStringFormatExt = args.Render.method_12().Clone())
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = (drawStringFormatExt.FormatFlags | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
					args.Graphics.DrawString(Text, runtimeStyle.Font, runtimeStyle.Color, new RectangleF(rectangleF.Left, rectangleF.Top + float_7, rectangleF.Width, rectangleF.Height - float_7), drawStringFormatExt);
				}
			}
			if (ButtonStyle != 0 && ownerDocument.Options.ViewOptions.ShowFormButton)
			{
				bool bool_ = false;
				if (ownerField.HasSelection)
				{
					bool_ = true;
				}
				GClass502.smethod_1(ButtonStyle, bool_);
				float num2 = ownerDocument.PixelToDocumentUnit(16f);
				RectangleF rectangleF2 = new RectangleF(absBounds.Right - num2 - 1f - RuntimeBorderWidth, rectangleF.Top, num2, num2);
				if (rectangleF2.Height > absBounds.Height - 1f)
				{
					rectangleF2.Height = absBounds.Height - 1f;
				}
				if (Parent is XTextInputFieldElementBase)
				{
					switch (((XTextInputFieldElementBase)Parent).BorderTextPosition)
					{
					case DCBorderTextPosition.Top:
						rectangleF2.Y = absBounds.Top;
						break;
					case DCBorderTextPosition.Middle:
						rectangleF2.Y = absBounds.Top + (absBounds.Height - rectangleF2.Height) / 2f;
						break;
					case DCBorderTextPosition.Bottom:
						rectangleF2.Y = absBounds.Bottom - rectangleF2.Height - 3f;
						break;
					case DCBorderTextPosition.LeftTopRightBottom:
						rectangleF2.Y = absBounds.Bottom - rectangleF2.Height - 3f;
						break;
					case DCBorderTextPosition.LeftBottomRightTop:
						rectangleF2.Y = absBounds.Top;
						break;
					}
					if (rectangleF2.Bottom > absBounds.Bottom - 5f)
					{
						rectangleF2.Y = absBounds.Bottom - rectangleF2.Height - 5f;
					}
				}
				rectangleF_0 = rectangleF2;
				GClass502.smethod_0(args.Graphics, rectangleF2, ButtonStyle, bool_);
			}
			if (!ownerDocument.Options.ViewOptions.ShowFieldBorderElement || args.RenderMode != 0)
			{
				return;
			}
			Color runtimeBorderColor = RuntimeBorderColor;
			if (string.IsNullOrEmpty(BorderText))
			{
				bool flag = true;
				if (ownerField is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)ownerField;
					if (xTextInputFieldElementBase.BorderVisible == DCVisibleState.Hidden)
					{
						flag = false;
					}
					else if (xTextInputFieldElementBase.BorderVisible == DCVisibleState.Default && !ownerDocument.Options.ViewOptions.ShowFieldBorderElement)
					{
						flag = false;
					}
				}
				if (flag && args.RenderMode == DocumentRenderMode.Paint)
				{
					bool flag2;
					if (!(flag2 = (!ownerDocument.Options.ViewOptions.HiddenFieldBorderWhenLostFocus || ownerField.Focused || OwnerDocument.IsHover(ownerField))) && ownerField is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)ownerField;
						if (xTextInputFieldElement.BorderVisible == DCVisibleState.AlwaysVisible)
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						PointF[] array = new PointF[4];
						switch (num)
						{
						case 0:
							array[0].X = absBounds.Right;
							array[0].Y = absBounds.Top;
							array[1].X = absBounds.Left;
							array[1].Y = absBounds.Top;
							array[2].X = absBounds.Left;
							array[2].Y = absBounds.Bottom;
							array[3].X = absBounds.Right;
							array[3].Y = absBounds.Bottom;
							break;
						case 1:
							array[0].X = absBounds.Left;
							array[0].Y = absBounds.Top;
							array[1].X = absBounds.Right;
							array[1].Y = absBounds.Top;
							array[2].X = absBounds.Right;
							array[2].Y = absBounds.Bottom;
							array[3].X = absBounds.Left;
							array[3].Y = absBounds.Bottom;
							break;
						}
						args.Graphics.DrawLines(runtimeBorderColor, 1f, array);
					}
				}
			}
			else
			{
				using (DrawStringFormatExt drawStringFormatExt = args.Render.method_12().Clone())
				{
					drawStringFormatExt.Alignment = StringAlignment.Near;
					drawStringFormatExt.LineAlignment = StringAlignment.Near;
					drawStringFormatExt.FormatFlags = (StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
					XTextInputFieldElementBase xTextInputFieldElementBase2 = Parent as XTextInputFieldElementBase;
					if (xTextInputFieldElementBase2 != null)
					{
						switch (xTextInputFieldElementBase2.BorderTextPosition)
						{
						case DCBorderTextPosition.Top:
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
							break;
						case DCBorderTextPosition.Middle:
							drawStringFormatExt.LineAlignment = StringAlignment.Center;
							break;
						case DCBorderTextPosition.Bottom:
							drawStringFormatExt.LineAlignment = StringAlignment.Far;
							break;
						case DCBorderTextPosition.LeftTopRightBottom:
							if (ownerField.StartElement == this)
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Near;
							}
							else
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Far;
							}
							break;
						case DCBorderTextPosition.LeftBottomRightTop:
							if (ownerField.StartElement == this)
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Far;
							}
							else
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Near;
							}
							break;
						}
					}
					args.Graphics.DrawString(BorderText, ownerField.RuntimeStyle.Font, runtimeBorderColor, absBounds, drawStringFormatExt);
				}
			}
			if (args.RenderMode != 0)
			{
				return;
			}
			XTextInputFieldElement xTextInputFieldElement2 = Parent as XTextInputFieldElement;
			if (xTextInputFieldElement2 != null && xTextInputFieldElement2.EndElement == this && xTextInputFieldElement2.RuntimeShowInputFieldStateTag)
			{
				float num3 = OwnerDocument.PixelToDocumentUnit(4f);
				RectangleF rect = new RectangleF(absBounds.Right - num3, absBounds.Bottom - num3, num3, num3);
				Color empty = Color.Empty;
				empty = (xTextInputFieldElement2.RuntimeContentReadonly ? ownerDocument.Options.ViewOptions.TagColorForReadonlyField : ((xTextInputFieldElement2.LastValidateResult != null) ? ownerDocument.Options.ViewOptions.TagColorForValueInvalidateField : ((!xTextInputFieldElement2.Modified) ? ownerDocument.Options.ViewOptions.TagColorForNormalField : ownerDocument.Options.ViewOptions.TagColorForModifiedField)));
				if (empty.A != 0)
				{
					SmoothingMode smoothingMode = args.Graphics.SmoothingMode;
					args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
					args.Graphics.FillRectangle(empty, rect);
					args.Graphics.SmoothingMode = smoothingMode;
				}
			}
		}
	}
}
