using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass447
	{
		private XFontValue xfontValue_0 = new XFontValue();

		private int int_0 = 11;

		private AccountingNumberUnitMode accountingNumberUnitMode_0 = AccountingNumberUnitMode.LowerCaseChinese;

		private bool bool_0 = true;

		private Color color_0 = Color.Black;

		private int int_1 = 0;

		private static string string_0 = "分角元十百千万十百千亿十百千兆十百千";

		private static string string_1 = "分角元拾佰仟万拾佰仟亿拾佰仟兆拾佰仟";

		public XFontValue method_0()
		{
			return xfontValue_0;
		}

		public void method_1(XFontValue xfontValue_1)
		{
			xfontValue_0 = xfontValue_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_2)
		{
			int_0 = int_2;
		}

		public AccountingNumberUnitMode method_4()
		{
			return accountingNumberUnitMode_0;
		}

		public void method_5(AccountingNumberUnitMode accountingNumberUnitMode_1)
		{
			accountingNumberUnitMode_0 = accountingNumberUnitMode_1;
		}

		public bool method_6()
		{
			return bool_0;
		}

		public void method_7(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public Color method_8()
		{
			return color_0;
		}

		public void method_9(Color color_1)
		{
			color_0 = color_1;
		}

		public int method_10()
		{
			return int_1;
		}

		public void method_11(int int_2)
		{
			int_1 = int_2;
		}

		public void method_12(DCGraphics dcgraphics_0, double double_0, RectangleF rectangleF_0)
		{
			int num = 17;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			float fontHeight = dcgraphics_0.GetFontHeight(method_0());
			float num2 = rectangleF_0.Width / (float)method_2();
			if (method_6())
			{
				dcgraphics_0.DrawRectangle(method_8(), rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width, rectangleF_0.Height);
				dcgraphics_0.DrawLine(method_8(), rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height / 2f, rectangleF_0.Right, rectangleF_0.Top + rectangleF_0.Height / 2f);
				for (int i = 1; i < method_2(); i++)
				{
					dcgraphics_0.DrawLine(method_8(), rectangleF_0.Left + num2 * (float)i, rectangleF_0.Top, rectangleF_0.Left + num2 * (float)i, rectangleF_0.Bottom);
				}
				string text = null;
				text = ((method_4() != 0) ? string_1 : string_0);
				int num3 = Math.Min(text.Length, method_2());
				for (int i = 0; i < num3; i++)
				{
					float float_ = rectangleF_0.Right - num2 * (float)i - num2 + 1f;
					float float_2 = rectangleF_0.Top + (rectangleF_0.Height / 2f - fontHeight) / 2f;
					dcgraphics_0.DrawString(text[i].ToString(), method_0(), method_8(), float_, float_2);
				}
			}
			string text2 = Convert.ToInt64(double_0 * 100.0).ToString();
			Math.Min(text2.Length, method_2() + 1);
			using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
			{
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				int num4 = method_2() - text2.Length;
				for (int i = 0; i < text2.Length; i++)
				{
					dcgraphics_0.DrawString(rect: new RectangleF(rectangleF_0.Left + num2 * (float)(i + num4), rectangleF_0.Top + rectangleF_0.Height / 2f, num2, rectangleF_0.Height / 2f), string_0: text2[i].ToString(), font: method_0(), color_0: method_8(), format: drawStringFormatExt);
				}
			}
		}
	}
}
