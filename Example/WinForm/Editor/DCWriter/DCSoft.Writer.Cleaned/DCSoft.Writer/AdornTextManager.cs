using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       扩展文字管理器
	///       </summary>
	/// <remarks>袁永福到此一游</remarks>
	[ComVisible(false)]
	public class AdornTextManager
	{
		private class Class44
		{
			public XTextElement xtextElement_0 = null;

			public RectangleF rectangleF_0 = RectangleF.Empty;

			public string string_0 = null;
		}

		private WriterControl writerControl_0;

		private XTextDocument xtextDocument_0;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		private XFontValue xfontValue_0;

		private Dictionary<XTextElement, Class44> dictionary_0;

		private Dictionary<string, SizeF> dictionary_1;

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		public WriterControl WriterControl => writerControl_0;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document => xtextDocument_0;

		/// <summary>
		///       绘制文字使用的字体
		///       </summary>
		public XFontValue Font
		{
			get
			{
				return xfontValue_0;
			}
			set
			{
				xfontValue_0 = value;
				dictionary_1.Clear();
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		public AdornTextManager(WriterControl writerControl_1, XTextDocument xtextDocument_1)
		{
			int num = 8;
			writerControl_0 = null;
			xtextDocument_0 = null;
			xfontValue_0 = new XFontValue();
			dictionary_0 = new Dictionary<XTextElement, Class44>();
			dictionary_1 = new Dictionary<string, SizeF>();
			
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			writerControl_0 = writerControl_1;
			xtextDocument_0 = xtextDocument_1;
			if (drawStringFormatExt_0 == null)
			{
				drawStringFormatExt_0 = DrawStringFormatExt.GenericTypographic.Clone();
				drawStringFormatExt_0.FormatFlags = StringFormatFlags.NoWrap;
				drawStringFormatExt_0.Alignment = StringAlignment.Center;
				drawStringFormatExt_0.LineAlignment = StringAlignment.Center;
			}
		}

		public void method_0()
		{
			dictionary_0.Clear();
			dictionary_1.Clear();
		}

		public bool method_1(XTextElement xtextElement_0)
		{
			int num = 1;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (xtextDocument_0.Options.ViewOptions.AdornTextVisibility == DCAdornTextVisibility.Hidden)
			{
				return false;
			}
			if (xtextDocument_0.Options.ViewOptions.AdornTextVisibility != DCAdornTextVisibility.Actived || xtextElement_0 != xtextDocument_0.CurrentElement)
			{
			}
			string runtimeAdornText = xtextElement_0.RuntimeAdornText;
			if (!string.IsNullOrEmpty(runtimeAdornText))
			{
				return true;
			}
			return false;
		}

		public void method_2(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (xtextDocument_0.Options.ViewOptions.AdornTextVisibility == DCAdornTextVisibility.Actived)
			{
				for (XTextElement xTextElement = xtextDocument_0.CurrentElement; xTextElement != null; xTextElement = xTextElement.Parent)
				{
					xTextElementList.Add(xTextElement);
				}
			}
			else if (xtextDocument_0.Options.ViewOptions.AdornTextVisibility == DCAdornTextVisibility.Both)
			{
				xTextElementList = xtextDocument_0.CurrentContentElement.GetAllElementsWithoutCharElement();
			}
			foreach (XTextElement item in xTextElementList)
			{
				string runtimeAdornText = GetRuntimeAdornText(item);
				if (!string.IsNullOrEmpty(runtimeAdornText) && xtextDocument_0.IsVisible(item))
				{
					Class44 @class = method_8(documentPaintEventArgs_0.Graphics, item, documentPaintEventArgs_0.PageClipRectangle, runtimeAdornText);
					if (@class != null && !@class.rectangleF_0.IsEmpty && @class.rectangleF_0.IntersectsWith(documentPaintEventArgs_0.ClipRectangle))
					{
						dictionary_0[item] = @class;
						method_7(documentPaintEventArgs_0.Graphics, runtimeAdornText, @class.rectangleF_0);
					}
				}
			}
		}

		protected virtual string GetRuntimeAdornText(XTextElement element)
		{
			int num = 13;
			string runtimeAdornText = element.RuntimeAdornText;
			if (!string.IsNullOrEmpty(runtimeAdornText))
			{
				return runtimeAdornText;
			}
			switch (xtextDocument_0.Options.ViewOptions.DefaultAdornTextType)
			{
			case InputFieldAdornTextType.DataSource:
			{
				XDataBinding xDataBinding = null;
				if (element is XTextContainerElement)
				{
					xDataBinding = ((XTextContainerElement)element).ValueBinding;
				}
				else if (element is XTextLabelElementBase)
				{
					xDataBinding = ((XTextLabelElementBase)element).ValueBinding;
				}
				else if (element is XTextCheckBoxElementBase)
				{
					xDataBinding = ((XTextCheckBoxElementBase)element).ValueBinding;
				}
				if (xDataBinding != null && xDataBinding.Enabled && !xDataBinding.IsEmptyBinding)
				{
					if (string.IsNullOrEmpty(xDataBinding.DataSource))
					{
						return xDataBinding.DataSource + "#" + xDataBinding.BindingPath;
					}
					return xDataBinding.BindingPath;
				}
				break;
			}
			case InputFieldAdornTextType.ToolTip:
				if (element is XTextContainerElement)
				{
					return ((XTextInputFieldElement)element).ToolTip;
				}
				if (element is XTextImageElement)
				{
					return ((XTextImageElement)element).Title;
				}
				break;
			case InputFieldAdornTextType.ValidateMessage:
				if (element is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
					if (xTextInputFieldElement.LastValidateResult != null)
					{
						return xTextInputFieldElement.LastValidateResult.Message;
					}
				}
				break;
			case InputFieldAdornTextType.ID:
				return element.ID;
			case InputFieldAdornTextType.Name:
				if (element is XTextObjectElement)
				{
					return ((XTextObjectElement)element).Name;
				}
				if (element is XTextInputFieldElement)
				{
					return ((XTextInputFieldElement)element).Name;
				}
				break;
			case InputFieldAdornTextType.TabIndex:
				if (element is XTextInputFieldElementBase)
				{
					return ((XTextInputFieldElementBase)element).TabIndex.ToString();
				}
				break;
			}
			return null;
		}

		public bool method_3(XTextElement xtextElement_0)
		{
			return dictionary_0.ContainsKey(xtextElement_0);
		}

		public RectangleF method_4(XTextElement xtextElement_0)
		{
			if (xtextElement_0 == null)
			{
				return RectangleF.Empty;
			}
			if (xtextElement_0 is XTextFieldBorderElement)
			{
				xtextElement_0 = xtextElement_0.Parent;
			}
			if (xtextElement_0 == null)
			{
				return RectangleF.Empty;
			}
			if (dictionary_0.ContainsKey(xtextElement_0))
			{
				return dictionary_0[xtextElement_0].rectangleF_0;
			}
			return RectangleF.Empty;
		}

		public SizeF method_5(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return SizeF.Empty;
			}
			if (dictionary_1.ContainsKey(string_0))
			{
				return dictionary_1[string_0];
			}
			using (DCGraphics dcgraphics_ = xtextDocument_0.CreateDCGraphics())
			{
				return method_6(dcgraphics_, string_0);
			}
		}

		public SizeF method_6(DCGraphics dcgraphics_0, string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return SizeF.Empty;
			}
			if (dictionary_1.ContainsKey(string_0))
			{
				return dictionary_1[string_0];
			}
			if (dcgraphics_0 != null)
			{
				SizeF sizeF = dcgraphics_0.MeasureString(string_0, Font, 100000, drawStringFormatExt_0);
				sizeF.Height = dcgraphics_0.GetFontHeight(Font);
				sizeF.Width += 10f;
				sizeF.Height += 8f;
				dictionary_1[string_0] = sizeF;
				return sizeF;
			}
			return SizeF.Empty;
		}

		private void method_7(DCGraphics dcgraphics_0, string string_0, RectangleF rectangleF_0)
		{
			if (!string.IsNullOrEmpty(string_0) && !rectangleF_0.IsEmpty)
			{
				dcgraphics_0.FillRoundRectangle(Document.Options.ViewOptions.AdornTextBackColor, rectangleF_0, rectangleF_0.Height / 5f);
				dcgraphics_0.DrawString(string_0, Font, Color.Black, rectangleF_0, drawStringFormatExt_0);
				dcgraphics_0.DrawRoundRectangle(Color.Black, rectangleF_0, rectangleF_0.Height / 5f);
			}
		}

		private Class44 method_8(DCGraphics dcgraphics_0, XTextElement xtextElement_0, RectangleF rectangleF_0, string string_0)
		{
			if (writerControl_0 != null)
			{
				WriterGetAdornTextEventArgs writerGetAdornTextEventArgs = new WriterGetAdornTextEventArgs(writerControl_0, xtextDocument_0, xtextElement_0, string_0);
				writerControl_0.vmethod_21(writerGetAdornTextEventArgs);
				string_0 = writerGetAdornTextEventArgs.AdornText;
			}
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			SizeF sizeF = method_6(dcgraphics_0, string_0);
			if (sizeF.IsEmpty)
			{
				return null;
			}
			if (xtextElement_0 is XTextFieldElementBase)
			{
				xtextElement_0 = ((XTextFieldElementBase)xtextElement_0).StartElement;
			}
			RectangleF absBounds = xtextElement_0.AbsBounds;
			RectangleF rectangleF_ = new RectangleF(absBounds.Left, absBounds.Top - sizeF.Height, sizeF.Width, sizeF.Height);
			if (!rectangleF_0.IsEmpty && rectangleF_.Top < rectangleF_0.Top - 2f)
			{
				rectangleF_.Y = absBounds.Bottom;
			}
			if (rectangleF_.Top < 0f)
			{
				rectangleF_.Y = absBounds.Bottom;
			}
			if (rectangleF_.Right > xtextDocument_0.Left + xtextDocument_0.Body.Width)
			{
				rectangleF_.X = xtextDocument_0.Left + xtextDocument_0.Body.Width - rectangleF_.Width;
			}
			Class44 @class = new Class44();
			@class.xtextElement_0 = xtextElement_0;
			@class.string_0 = string_0;
			@class.rectangleF_0 = rectangleF_;
			return @class;
		}
	}
}
