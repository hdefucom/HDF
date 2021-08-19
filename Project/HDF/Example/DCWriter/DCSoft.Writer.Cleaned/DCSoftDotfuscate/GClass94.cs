using DCSoft.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ToolboxItem(false)]
	[ComVisible(false)]
	public class GClass94
	{
		private static Dictionary<BarcodeStyle, string> dictionary_0 = null;

		private int int_0 = 0;

		private bool bool_0 = false;

		private string string_0 = "";

		private string string_1 = "";

		private string string_2 = null;

		private string string_3 = "N/A";

		private BarcodeStyle barcodeStyle_0 = BarcodeStyle.Code39;

		private Color color_0 = Color.Black;

		private float float_0 = 2f;

		private bool bool_1 = true;

		private Font font_0 = Control.DefaultFont;

		private StringAlignment stringAlignment_0 = StringAlignment.Center;

		private float float_1 = 0f;

		private bool bool_2 = false;

		public static Dictionary<BarcodeStyle, string> smethod_0()
		{
			int num = 17;
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<BarcodeStyle, string>();
				dictionary_0[BarcodeStyle.BOOKLAND] = "9787121143137";
				dictionary_0[BarcodeStyle.Codabar] = "A123456B";
				dictionary_0[BarcodeStyle.CODE11] = "1234-5678";
				dictionary_0[BarcodeStyle.Code128A] = "01234ABCDE";
				dictionary_0[BarcodeStyle.Code128B] = "01234ABCDE";
				dictionary_0[BarcodeStyle.Code128C] = "0123456789";
				dictionary_0[BarcodeStyle.Code39] = "01234ABCDE";
				dictionary_0[BarcodeStyle.Code39Extended] = "01234ABCDE";
				dictionary_0[BarcodeStyle.Code93] = "01234ABCDE";
				dictionary_0[BarcodeStyle.EAN13] = "012345678912";
				dictionary_0[BarcodeStyle.EAN8] = "1234567";
				dictionary_0[BarcodeStyle.I2of5] = "123456789";
				dictionary_0[BarcodeStyle.Interleaved2of5] = "123456";
				dictionary_0[BarcodeStyle.ISBN] = "9787121143137";
				dictionary_0[BarcodeStyle.JAN13] = "491234567890";
				dictionary_0[BarcodeStyle.LOGMARS] = "01234ABCDE";
				dictionary_0[BarcodeStyle.Modified_Plessey] = "0123456789";
				dictionary_0[BarcodeStyle.MSI_2Mod10] = "0123456789";
				dictionary_0[BarcodeStyle.MSI_Mod10] = "0123456789";
				dictionary_0[BarcodeStyle.MSI_Mod11] = "0123456789";
				dictionary_0[BarcodeStyle.MSI_Mod11_Mod10] = "0123456789";
				dictionary_0[BarcodeStyle.PostNet] = "123456789";
				dictionary_0[BarcodeStyle.Standard2of5] = "123456789";
				dictionary_0[BarcodeStyle.SUPP2] = "12";
				dictionary_0[BarcodeStyle.SUPP5] = "12345";
				dictionary_0[BarcodeStyle.UCC12] = "012345678912";
				dictionary_0[BarcodeStyle.UCC13] = "0123456789123";
				dictionary_0[BarcodeStyle.UNSPECIFIED] = "000000000";
				dictionary_0[BarcodeStyle.UPCA] = "012345678912";
				dictionary_0[BarcodeStyle.UPCE] = "01234567";
				dictionary_0[BarcodeStyle.USD8] = "1234-5678";
			}
			return dictionary_0;
		}

		public static string smethod_1(BarcodeStyle barcodeStyle_1)
		{
			int num = 3;
			if (smethod_0().ContainsKey(barcodeStyle_1))
			{
				return smethod_0()[barcodeStyle_1];
			}
			return "0000000000";
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_1)
		{
			int_0 = int_1;
		}

		public GClass94()
		{
		}

		public GClass94(string string_4)
		{
			string_0 = string_4;
		}

		public GClass94(string string_4, BarcodeStyle barcodeStyle_1)
		{
			string_0 = string_4;
			barcodeStyle_0 = barcodeStyle_1;
		}

		public GClass94(BarcodeStyle barcodeStyle_1)
		{
			barcodeStyle_0 = barcodeStyle_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_4)
		{
			string_0 = string_4;
			bool_0 = false;
		}

		public string method_4()
		{
			return string_1;
		}

		public string method_5()
		{
			return string_2;
		}

		public string method_6()
		{
			return string_3;
		}

		public void method_7(BarcodeStyle barcodeStyle_1)
		{
			barcodeStyle_0 = barcodeStyle_1;
		}

		public BarcodeStyle method_8()
		{
			return barcodeStyle_0;
		}

		public Color method_9()
		{
			return color_0;
		}

		public void method_10(Color color_1)
		{
			color_0 = color_1;
		}

		public float method_11()
		{
			return float_0;
		}

		public void method_12(float float_2)
		{
			float_0 = float_2;
			bool_0 = false;
		}

		public bool method_13()
		{
			return bool_1;
		}

		public void method_14(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public Font method_15()
		{
			return font_0;
		}

		public void method_16(Font font_1)
		{
			font_0 = font_1;
		}

		public StringAlignment method_17()
		{
			return stringAlignment_0;
		}

		public void method_18(StringAlignment stringAlignment_1)
		{
			stringAlignment_0 = stringAlignment_1;
		}

		public float method_19()
		{
			return float_1;
		}

		public bool method_20()
		{
			int num = 7;
			string_2 = null;
			if (string_0 == null || string_0.Trim().Length == 0)
			{
				string_2 = BarcodeStrings.TextMustNotNull;
				string_1 = "";
				return false;
			}
			string_1 = "";
			string_3 = "N/A";
			Class84 @class;
			switch (barcodeStyle_0)
			{
			default:
				string_2 = BarcodeStrings.InvaliBarcodeStyle;
				return false;
			case BarcodeStyle.UPCE:
				@class = new Class99(string_0);
				break;
			case BarcodeStyle.SUPP2:
				@class = new Class90(string_0);
				break;
			case BarcodeStyle.SUPP5:
				@class = new Class100(string_0);
				break;
			case BarcodeStyle.EAN8:
				@class = new Class92(string_0);
				break;
			case BarcodeStyle.Interleaved2of5:
				@class = new Class101(string_0);
				break;
			case BarcodeStyle.Standard2of5:
			case BarcodeStyle.I2of5:
				@class = new Class88(string_0);
				break;
			case BarcodeStyle.Code39Extended:
				@class = new Class95(string_0, bool_1: true);
				break;
			case BarcodeStyle.Code93:
				@class = new Class87(string_0);
				break;
			case BarcodeStyle.Codabar:
				@class = new Class96(string_0);
				break;
			case BarcodeStyle.PostNet:
				@class = new Class93(string_0);
				break;
			case BarcodeStyle.BOOKLAND:
			case BarcodeStyle.ISBN:
				@class = new Class94(string_0);
				break;
			case BarcodeStyle.JAN13:
				@class = new Class91(string_0);
				break;
			case BarcodeStyle.MSI_Mod10:
			case BarcodeStyle.MSI_2Mod10:
			case BarcodeStyle.MSI_Mod11:
			case BarcodeStyle.MSI_Mod11_Mod10:
			case BarcodeStyle.Modified_Plessey:
				@class = new Class98(string_0, barcodeStyle_0);
				break;
			case BarcodeStyle.CODE11:
			case BarcodeStyle.USD8:
				@class = new Class86(string_0);
				break;
			case BarcodeStyle.UPCA:
			case BarcodeStyle.UCC12:
				@class = new Class85(string_0);
				break;
			case BarcodeStyle.EAN13:
			case BarcodeStyle.UCC13:
				@class = new Class89(string_0);
				break;
			case BarcodeStyle.Code39:
			case BarcodeStyle.LOGMARS:
				@class = new Class95(string_0);
				break;
			case BarcodeStyle.Code128A:
				@class = new Class97(string_0, Class97.Enum9.const_1);
				break;
			case BarcodeStyle.Code128B:
				@class = new Class97(string_0, Class97.Enum9.const_2);
				break;
			case BarcodeStyle.Code128C:
				@class = new Class97(string_0, Class97.Enum9.const_3);
				break;
			}
			@class.string_1 = null;
			string_1 = @class.vmethod_0();
			string_2 = @class.string_1;
			bool_0 = true;
			if (string_1 != null)
			{
				switch (barcodeStyle_0)
				{
				default:
					float_1 = 0f;
					return false;
				case BarcodeStyle.PostNet:
					float_1 = (float)string_1.Length * float_0 * 2f;
					break;
				case BarcodeStyle.UPCA:
				case BarcodeStyle.UPCE:
				case BarcodeStyle.SUPP2:
				case BarcodeStyle.SUPP5:
				case BarcodeStyle.EAN13:
				case BarcodeStyle.EAN8:
				case BarcodeStyle.Interleaved2of5:
				case BarcodeStyle.Standard2of5:
				case BarcodeStyle.I2of5:
				case BarcodeStyle.Code39:
				case BarcodeStyle.Code39Extended:
				case BarcodeStyle.Code93:
				case BarcodeStyle.Codabar:
				case BarcodeStyle.BOOKLAND:
				case BarcodeStyle.ISBN:
				case BarcodeStyle.JAN13:
				case BarcodeStyle.MSI_Mod10:
				case BarcodeStyle.MSI_2Mod10:
				case BarcodeStyle.MSI_Mod11:
				case BarcodeStyle.MSI_Mod11_Mod10:
				case BarcodeStyle.Modified_Plessey:
				case BarcodeStyle.CODE11:
				case BarcodeStyle.USD8:
				case BarcodeStyle.UCC12:
				case BarcodeStyle.UCC13:
				case BarcodeStyle.LOGMARS:
				case BarcodeStyle.Code128A:
				case BarcodeStyle.Code128B:
				case BarcodeStyle.Code128C:
					float_1 = (float)string_1.Length * float_0;
					break;
				}
				return true;
			}
			return false;
		}

		public bool method_21()
		{
			return bool_2;
		}

		public void method_22(bool bool_3)
		{
			bool_2 = bool_3;
		}

		public List<RectangleF> method_23(RectangleF rectangleF_0)
		{
			if (!bool_0)
			{
				method_20();
			}
			if (string_1 == null || string_1.Trim().Length == 0)
			{
				return null;
			}
			List<RectangleF> list = new List<RectangleF>();
			float num = 0f;
			switch (barcodeStyle_0)
			{
			default:
				return null;
			case BarcodeStyle.PostNet:
				using (new SolidBrush(method_9()))
				{
					if (method_21())
					{
						float_0 = 0.5f * rectangleF_0.Width / (float)string_1.Length;
						float_1 = rectangleF_0.Width;
					}
					for (int i = 0; i < string_1.Length; i++)
					{
						if (string_1[i] == '1')
						{
							list.Add(new RectangleF(rectangleF_0.Left + (float)i * float_0 * 2f, rectangleF_0.Top, float_0, rectangleF_0.Height - num));
						}
						else
						{
							list.Add(new RectangleF(rectangleF_0.Left + (float)i * float_0 * 2f, rectangleF_0.Top, float_0, (rectangleF_0.Height - num) / 2f));
						}
					}
				}
				break;
			case BarcodeStyle.UPCA:
			case BarcodeStyle.UPCE:
			case BarcodeStyle.SUPP2:
			case BarcodeStyle.SUPP5:
			case BarcodeStyle.EAN13:
			case BarcodeStyle.EAN8:
			case BarcodeStyle.Interleaved2of5:
			case BarcodeStyle.Standard2of5:
			case BarcodeStyle.I2of5:
			case BarcodeStyle.Code39:
			case BarcodeStyle.Code39Extended:
			case BarcodeStyle.Code93:
			case BarcodeStyle.Codabar:
			case BarcodeStyle.BOOKLAND:
			case BarcodeStyle.ISBN:
			case BarcodeStyle.JAN13:
			case BarcodeStyle.MSI_Mod10:
			case BarcodeStyle.MSI_2Mod10:
			case BarcodeStyle.MSI_Mod11:
			case BarcodeStyle.MSI_Mod11_Mod10:
			case BarcodeStyle.Modified_Plessey:
			case BarcodeStyle.CODE11:
			case BarcodeStyle.USD8:
			case BarcodeStyle.UCC12:
			case BarcodeStyle.UCC13:
			case BarcodeStyle.LOGMARS:
			case BarcodeStyle.Code128A:
			case BarcodeStyle.Code128B:
			case BarcodeStyle.Code128C:
			{
				_ = string_1.Length * 2;
				using (new SolidBrush(method_9()))
				{
					if (method_21())
					{
						float_0 = rectangleF_0.Width / (float)string_1.Length;
						float_1 = rectangleF_0.Width;
					}
				}
				float num2 = rectangleF_0.Left;
				for (int i = 0; i < string_1.Length; i++)
				{
					if (string_1[i] == '1')
					{
						list.Add(new RectangleF(num2, rectangleF_0.Top, float_0, rectangleF_0.Height - num));
					}
					num2 += float_0;
				}
				break;
			}
			}
			return list;
		}

		public void method_24(Graphics graphics_0, RectangleF rectangleF_0)
		{
			if (!bool_0)
			{
				method_20();
			}
			if (string_1 == null || string_1.Trim().Length == 0)
			{
				if (string_2 != null)
				{
					using (SolidBrush brush = new SolidBrush(method_9()))
					{
						using (StringFormat stringFormat = new StringFormat())
						{
							stringFormat.Alignment = StringAlignment.Center;
							stringFormat.LineAlignment = StringAlignment.Center;
							graphics_0.DrawString(string_2, font_0, brush, rectangleF_0, stringFormat);
						}
					}
				}
				return;
			}
			float num = 0f;
			if (bool_1)
			{
				num = font_0.GetHeight(graphics_0);
			}
			switch (barcodeStyle_0)
			{
			default:
				return;
			case BarcodeStyle.PostNet:
			{
				using (SolidBrush solidBrush = new SolidBrush(method_9()))
				{
					if (method_21())
					{
						float_0 = 0.5f * rectangleF_0.Width / (float)string_1.Length;
						float_1 = rectangleF_0.Width;
					}
					for (int i = 0; i < string_1.Length; i++)
					{
						if (string_1[i] == '1')
						{
							graphics_0.FillRectangle(solidBrush, new RectangleF(rectangleF_0.Left + (float)i * float_0 * 2f, rectangleF_0.Top, float_0, rectangleF_0.Height - num));
						}
						else
						{
							graphics_0.FillRectangle(solidBrush, new RectangleF(rectangleF_0.Left + (float)i * float_0 * 2f, rectangleF_0.Top, float_0, (rectangleF_0.Height - num) / 2f));
						}
					}
				}
				break;
			}
			case BarcodeStyle.UPCA:
			case BarcodeStyle.UPCE:
			case BarcodeStyle.SUPP2:
			case BarcodeStyle.SUPP5:
			case BarcodeStyle.EAN13:
			case BarcodeStyle.EAN8:
			case BarcodeStyle.Interleaved2of5:
			case BarcodeStyle.Standard2of5:
			case BarcodeStyle.I2of5:
			case BarcodeStyle.Code39:
			case BarcodeStyle.Code39Extended:
			case BarcodeStyle.Code93:
			case BarcodeStyle.Codabar:
			case BarcodeStyle.BOOKLAND:
			case BarcodeStyle.ISBN:
			case BarcodeStyle.JAN13:
			case BarcodeStyle.MSI_Mod10:
			case BarcodeStyle.MSI_2Mod10:
			case BarcodeStyle.MSI_Mod11:
			case BarcodeStyle.MSI_Mod11_Mod10:
			case BarcodeStyle.Modified_Plessey:
			case BarcodeStyle.CODE11:
			case BarcodeStyle.USD8:
			case BarcodeStyle.UCC12:
			case BarcodeStyle.UCC13:
			case BarcodeStyle.LOGMARS:
			case BarcodeStyle.Code128A:
			case BarcodeStyle.Code128B:
			case BarcodeStyle.Code128C:
			{
				_ = string_1.Length * 2;
				using (SolidBrush solidBrush = new SolidBrush(method_9()))
				{
					SolidBrush brush2 = solidBrush;
					if (method_21())
					{
						float_0 = rectangleF_0.Width / (float)string_1.Length;
						float_1 = rectangleF_0.Width;
					}
					float num2 = rectangleF_0.Left;
					for (int i = 0; i < string_1.Length; i++)
					{
						if (string_1[i] == '1')
						{
							graphics_0.FillRectangle(brush2, num2, rectangleF_0.Top, float_0, rectangleF_0.Height - num);
						}
						num2 += float_0;
					}
				}
				break;
			}
			}
			if (bool_1)
			{
				using (SolidBrush solidBrush = new SolidBrush(method_9()))
				{
					using (StringFormat stringFormat2 = new StringFormat())
					{
						stringFormat2.FormatFlags = StringFormatFlags.NoWrap;
						stringFormat2.Alignment = stringAlignment_0;
						graphics_0.DrawString(method_2(), font_0, solidBrush, new RectangleF(rectangleF_0.Left, rectangleF_0.Bottom - num, float_1, num), stringFormat2);
					}
				}
			}
		}

		public Bitmap method_25(Color color_1)
		{
			if (string_1 == null || string_1.Trim().Length == 0)
			{
				return null;
			}
			Bitmap bitmap = null;
			switch (barcodeStyle_0)
			{
			case BarcodeStyle.PostNet:
			{
				bitmap = new Bitmap(string_1.Length * 4, 20);
				for (int num = bitmap.Height - 1; num > 0; num--)
				{
					int j = 0;
					if (num < bitmap.Height / 2)
					{
						for (; j < bitmap.Width; j += 4)
						{
							if (string_1[j / 4] == '1')
							{
								bitmap.SetPixel(j, num, method_9());
								bitmap.SetPixel(j + 1, num, method_9());
								bitmap.SetPixel(j + 2, num, color_1);
								bitmap.SetPixel(j + 3, num, color_1);
							}
							else
							{
								bitmap.SetPixel(j, num, color_1);
								bitmap.SetPixel(j + 1, num, color_1);
								bitmap.SetPixel(j + 2, num, color_1);
								bitmap.SetPixel(j + 3, num, color_1);
							}
						}
					}
					else
					{
						for (; j < bitmap.Width; j += 4)
						{
							bitmap.SetPixel(j, num, method_9());
							bitmap.SetPixel(j + 1, num, method_9());
							bitmap.SetPixel(j + 2, num, color_1);
							bitmap.SetPixel(j + 3, num, color_1);
						}
					}
				}
				break;
			}
			default:
				return null;
			case BarcodeStyle.UPCA:
			case BarcodeStyle.UPCE:
			case BarcodeStyle.SUPP2:
			case BarcodeStyle.SUPP5:
			case BarcodeStyle.EAN13:
			case BarcodeStyle.EAN8:
			case BarcodeStyle.Interleaved2of5:
			case BarcodeStyle.Standard2of5:
			case BarcodeStyle.I2of5:
			case BarcodeStyle.Code39:
			case BarcodeStyle.Code39Extended:
			case BarcodeStyle.Code93:
			case BarcodeStyle.Codabar:
			case BarcodeStyle.BOOKLAND:
			case BarcodeStyle.ISBN:
			case BarcodeStyle.JAN13:
			case BarcodeStyle.MSI_Mod10:
			case BarcodeStyle.MSI_2Mod10:
			case BarcodeStyle.MSI_Mod11:
			case BarcodeStyle.Modified_Plessey:
			case BarcodeStyle.CODE11:
			case BarcodeStyle.USD8:
			case BarcodeStyle.UCC12:
			case BarcodeStyle.UCC13:
			case BarcodeStyle.LOGMARS:
			case BarcodeStyle.Code128A:
			case BarcodeStyle.Code128B:
			case BarcodeStyle.Code128C:
			{
				bitmap = new Bitmap(string_1.Length * 2, string_1.Length);
				int i = 0;
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					using (Pen pen2 = new Pen(method_9(), 2f))
					{
						using (Pen pen3 = new Pen(color_1, 2f))
						{
							Pen pen = null;
							for (; i * 2 + 1 < bitmap.Width; i++)
							{
								if (i < string_1.Length)
								{
									if (string_1[i] == '1')
									{
										pen = pen2;
									}
									if (string_1[i] == '0')
									{
										pen = pen3;
									}
								}
								graphics.DrawLine(pen, new Point(i * 2 + 1, 0), new Point(i * 2 + 1, bitmap.Height));
							}
						}
					}
				}
				break;
			}
			}
			bool_0 = true;
			return bitmap;
		}

		public Image method_26(Image image_0)
		{
			int num = 8;
			if (bool_0)
			{
				switch (barcodeStyle_0)
				{
				default:
					throw new Exception("EGENERATE_LABELS-1: Invalid type.");
				case BarcodeStyle.UPCA:
				case BarcodeStyle.UCC12:
					return method_27(image_0);
				case BarcodeStyle.UPCE:
				case BarcodeStyle.SUPP2:
				case BarcodeStyle.SUPP5:
				case BarcodeStyle.EAN13:
				case BarcodeStyle.EAN8:
				case BarcodeStyle.Interleaved2of5:
				case BarcodeStyle.Standard2of5:
				case BarcodeStyle.I2of5:
				case BarcodeStyle.Code39:
				case BarcodeStyle.Code39Extended:
				case BarcodeStyle.Code93:
				case BarcodeStyle.Codabar:
				case BarcodeStyle.BOOKLAND:
				case BarcodeStyle.ISBN:
				case BarcodeStyle.JAN13:
				case BarcodeStyle.MSI_Mod10:
				case BarcodeStyle.MSI_2Mod10:
				case BarcodeStyle.MSI_Mod11:
				case BarcodeStyle.CODE11:
				case BarcodeStyle.USD8:
				case BarcodeStyle.UCC13:
				case BarcodeStyle.LOGMARS:
				case BarcodeStyle.Code128A:
				case BarcodeStyle.Code128B:
				case BarcodeStyle.Code128C:
					return method_28(image_0);
				}
			}
			throw new Exception("EGENERATE_LABELS-2: Encode the image first.");
		}

		private Image method_27(Image image_0)
		{
			int num = 14;
			Font font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			Graphics graphics = Graphics.FromImage(image_0);
			graphics.DrawImage(image_0, 0f, 0f);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(image_0.Width / 16, image_0.Height - 12, (int)((double)image_0.Width * 0.42), image_0.Height / 2));
			graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle((int)((double)image_0.Width * 0.52), image_0.Height - 12, (int)((double)image_0.Width * 0.42), image_0.Height / 2));
			string text = "";
			string text2 = "";
			string text3 = string_0.Substring(1, 5);
			for (int i = 0; i < text3.Length; i++)
			{
				text = text + text3[i] + "  ";
			}
			text3 = string_0.Substring(6, 5);
			for (int i = 0; i < text3.Length; i++)
			{
				text2 = text2 + text3[i] + "  ";
			}
			text = text.Substring(0, text.Length - 1);
			text2 = text2.Substring(0, text2.Length - 1);
			graphics.DrawString(text, font, new SolidBrush(method_9()), new Rectangle(image_0.Width / 14, image_0.Height - 13, (int)((double)image_0.Width * 0.5), image_0.Height / 2));
			graphics.DrawString(text2, font, new SolidBrush(method_9()), new Rectangle((int)((double)image_0.Width * 0.55), image_0.Height - 13, (int)((double)image_0.Width * 0.5), image_0.Height / 2));
			graphics.Save();
			graphics.Dispose();
			Bitmap bitmap = new Bitmap((int)((double)image_0.Width * 1.12), (int)((double)image_0.Height * 1.12));
			for (int j = 0; j < bitmap.Height; j++)
			{
				for (int k = 0; k < bitmap.Width; k++)
				{
					bitmap.SetPixel(k, j, Color.White);
				}
			}
			Graphics graphics2 = Graphics.FromImage(bitmap);
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.CompositingQuality = CompositingQuality.HighQuality;
			graphics2.DrawImage(image_0, (float)((double)(float)image_0.Width * 0.06), (float)((double)(float)image_0.Height * 0.06), image_0.Width, image_0.Height);
			font = new Font("MS Sans Serif", 9f, FontStyle.Regular);
			graphics2.DrawString(string_0[0].ToString(), font, new SolidBrush(method_9()), new Rectangle(-1, image_0.Height + (int)((double)image_0.Height * 0.07) - 13, (int)((double)image_0.Width * 0.35), image_0.Height / 2));
			graphics2.DrawString(string_0[string_0.Length - 1].ToString(), font, new SolidBrush(method_9()), new Rectangle((int)((double)bitmap.Width * 0.96), image_0.Height + (int)((double)image_0.Height * 0.07) - 13, (int)((double)image_0.Width * 0.35), image_0.Height / 2));
			graphics2.Save();
			graphics2.Dispose();
			return bitmap;
		}

		private Image method_28(Image image_0)
		{
			Font font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
			using (Graphics graphics = Graphics.FromImage(image_0))
			{
				graphics.DrawImage(image_0, 0f, 0f);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, image_0.Height - 16, image_0.Width, 16));
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Center;
				graphics.DrawString(string_0, font, new SolidBrush(method_9()), image_0.Width / 2, image_0.Height - 16, stringFormat);
				graphics.Save();
			}
			return image_0;
		}

		public override string ToString()
		{
			int num = 4;
			string text = string.Concat(method_8(), ":", method_2());
			if (string_2 != null && string_2.Trim().Length > 0)
			{
				text = text + "#" + string_2;
			}
			return text;
		}
	}
}
