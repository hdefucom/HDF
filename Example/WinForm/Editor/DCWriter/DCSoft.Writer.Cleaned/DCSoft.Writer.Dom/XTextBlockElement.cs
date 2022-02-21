using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文本块
	///       </summary>
	[Serializable]
	
	public class XTextBlockElement : XTextObjectElement
	{
		private string string_9 = null;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		/// <summary>
		///       文本值
		///       </summary>
		[DefaultValue(null)]
		public override string Text
		{
			get
			{
				return string_9;
			}
			set
			{
				string_9 = value;
			}
		}

		/// <summary>
		///       返回表示纯文本内容的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToPlaintString()
		{
			return string_9;
		}

		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			int num = 18;
			if (drawStringFormatExt_0 == null)
			{
				drawStringFormatExt_0 = DrawStringFormatExt.GenericTypographic.Clone();
				drawStringFormatExt_0.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
			}
			RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
			string text = Text;
			if (text == null || text.Length == 0)
			{
				text = "  ";
			}
			Width = args.Graphics.MeasureString(text, runtimeStyle.Font, 10000, drawStringFormatExt_0).Width;
			Height = args.Graphics.GetFontHeight(runtimeStyle.Font);
			SizeInvalid = false;
		}

		public override void DrawContent(DocumentPaintEventArgs args)
		{
			if (Text != null && Text.Length > 0)
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				RectangleF absBounds = AbsBounds;
				Color black = Color.Black;
				if (args.RenderMode == DocumentRenderMode.Paint)
				{
					HighlightInfo highlightInfo = (OwnerDocument.HighlightManager == null) ? null : OwnerDocument.HighlightManager.imethod_10(this);
					black = ((highlightInfo == null || highlightInfo.Color.A == 0) ? runtimeStyle.Color : highlightInfo.Color);
				}
				else
				{
					black = method_4(runtimeStyle.Color);
				}
				runtimeStyle.Font.Clone();
				args.Graphics.DrawString(Text, runtimeStyle.Font, black, absBounds.Left, absBounds.Top, args.Render.method_11());
			}
		}
	}
}
