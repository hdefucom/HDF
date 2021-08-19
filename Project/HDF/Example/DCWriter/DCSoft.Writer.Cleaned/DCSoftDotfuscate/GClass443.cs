using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass443
	{
		private float float_0;

		private float float_1;

		private float float_2;

		private FontWidthStyle fontWidthStyle_0;

		private Font font_0;

		private Graphics graphics_0;

		private StringFormat stringFormat_0;

		public GClass443(StringFormat stringFormat_1, Graphics graphics_1, Font font_1)
		{
			int num = 17;
			float_0 = 0f;
			float_1 = 0f;
			float_2 = 0f;
			fontWidthStyle_0 = FontWidthStyle.Monospaced;
			font_0 = null;
			graphics_0 = null;
			stringFormat_0 = null;
			
			if (font_1 == null)
			{
				throw new ArgumentNullException("f");
			}
			if (graphics_1 == null)
			{
				throw new ArgumentNullException("g");
			}
			graphics_0 = graphics_1;
			font_0 = font_1;
			if (stringFormat_1 == null)
			{
				stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
				stringFormat_0.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
			}
			else
			{
				stringFormat_0 = stringFormat_1;
			}
			SizeF sizeF = graphics_1.MeasureString("W", font_0, 10000, stringFormat_0);
			SizeF sizeF2 = graphics_1.MeasureString("i", font_0, 10000, stringFormat_0);
			if (sizeF.Width == sizeF2.Width)
			{
				fontWidthStyle_0 = FontWidthStyle.Monospaced;
			}
			else
			{
				fontWidthStyle_0 = FontWidthStyle.Proportional;
			}
			if (fontWidthStyle_0 == FontWidthStyle.Monospaced)
			{
				float_2 = sizeF.Width;
			}
			float_1 = graphics_1.MeasureString("袁", font_0, 10000, stringFormat_0).Width;
			float_0 = graphics_1.MeasureString(" ", font_0, 1000, stringFormat_0).Width;
			if ((double)float_0 < 0.1)
			{
				float_0 = graphics_1.MeasureString("i", font_0, 1000, stringFormat_0).Width;
			}
		}

		public float method_0(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return 0f;
			}
			bool flag = false;
			if (fontWidthStyle_0 == FontWidthStyle.Monospaced)
			{
				float num = 0f;
				flag = true;
				foreach (char c in string_0)
				{
					if (smethod_0(c))
					{
						num += float_1;
						continue;
					}
					if (c == ' ')
					{
						num += float_0;
						continue;
					}
					if (c <= '\u007f')
					{
						num += float_2;
						continue;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					return num;
				}
			}
			return graphics_0.MeasureString(string_0, font_0, 10000, stringFormat_0).Width;
		}

		private static bool smethod_0(char char_0)
		{
			int num = 17;
			if ('一' <= char_0 && char_0 < '龥')
			{
				return true;
			}
			if ("‘’“”‘、，。？☆★○●◎◇◆□℃‰■△▲※→←↑↓".IndexOf(char_0) >= 0)
			{
				return true;
			}
			return false;
		}
	}
}
