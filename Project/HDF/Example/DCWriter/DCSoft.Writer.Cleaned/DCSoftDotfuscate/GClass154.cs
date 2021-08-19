#define DEBUG
using DCSoft.Drawing;
using DCSoft.Printing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass154
	{
		private class Class169
		{
			private static List<Class169> list_0 = new List<Class169>();

			private string string_0 = null;

			private string string_1 = null;

			private bool bool_0 = false;

			private RectangleF rectangleF_0 = RectangleF.Empty;

			public static Class169 smethod_0(PageSettings pageSettings_0)
			{
				int num = 14;
				if (pageSettings_0 == null)
				{
					throw new ArgumentNullException("ps");
				}
				string printerName = pageSettings_0.PrinterSettings.PrinterName;
				bool landscape = pageSettings_0.Landscape;
				foreach (Class169 item in list_0)
				{
					if (item.method_0() == printerName && item.method_2() == landscape)
					{
						return item;
					}
				}
				Class169 @class = new Class169();
				@class.bool_0 = landscape;
				@class.string_0 = printerName;
				@class.rectangleF_0 = pageSettings_0.PrintableArea;
				list_0.Add(@class);
				return @class;
			}

			public string method_0()
			{
				return string_0;
			}

			public string method_1()
			{
				return string_1;
			}

			public bool method_2()
			{
				return bool_0;
			}

			public RectangleF method_3()
			{
				return rectangleF_0;
			}
		}

		private static Dictionary<string, string> dictionary_0 = null;

		public static Rectangle smethod_0(PageSettings pageSettings_0)
		{
			int num = 12;
			if (pageSettings_0 == null)
			{
				throw new ArgumentNullException("ps");
			}
			try
			{
				return pageSettings_0.Bounds;
			}
			catch (Exception)
			{
				Size size = XPaperSizeCollection.smethod_1(pageSettings_0.PaperSize.Kind);
				int num2 = size.Width;
				int num3 = size.Height;
				if (pageSettings_0.Landscape)
				{
					int num4 = num2;
					num2 = num3;
					num3 = num4;
				}
				return new Rectangle(0, 0, num2, num3);
			}
		}

		public static RectangleF smethod_1(PageSettings pageSettings_0)
		{
			return Class169.smethod_0(pageSettings_0).method_3();
		}

		public static bool smethod_2(IWin32Window iwin32Window_0, bool bool_0)
		{
			if (!smethod_3())
			{
				if (bool_0)
				{
					MessageBox.Show(iwin32Window_0, PrintingResources.NoPrinter, PrintingResources.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				return false;
			}
			return true;
		}

		public static bool smethod_3()
		{
			return PrinterSettings.InstalledPrinters.Count > 0;
		}

		public static string smethod_4(string string_0)
		{
			int num = 1;
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			if (dictionary_0 != null && !dictionary_0.ContainsKey(string_0))
			{
				dictionary_0 = null;
			}
			if (dictionary_0 == null)
			{
				dictionary_0 = new Dictionary<string, string>();
				try
				{
					using (ManagementClass managementClass = new ManagementClass("Win32_Printer"))
					{
						using (ManagementObjectCollection managementObjectCollection = managementClass.GetInstances())
						{
							foreach (ManagementObject item in managementObjectCollection)
							{
								string text = null;
								string text2 = null;
								foreach (PropertyData property in item.Properties)
								{
									if (property.Value != null)
									{
										if (property.Name == "DriverName")
										{
											text2 = Convert.ToString(property.Value);
										}
										else if (property.Name == "DeviceID")
										{
											text = Convert.ToString(property.Value);
										}
										if (text2 != null && text != null)
										{
											break;
										}
									}
								}
								if (text != null)
								{
									dictionary_0[text] = text2;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
			if (dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			return null;
		}

		public static PointF smethod_5(string string_0, PageSettings pageSettings_0, GraphicsUnit graphicsUnit_0)
		{
			int num = 9;
			if (pageSettings_0 == null)
			{
				return new PointF(0f, 0f);
			}
			if (string.IsNullOrEmpty(string_0))
			{
				string_0 = pageSettings_0.PrinterSettings.PrinterName;
			}
			string text = smethod_4(string_0);
			if (text != null)
			{
				if (pageSettings_0.Landscape && text.IndexOf("EPSON M100", StringComparison.CurrentCultureIgnoreCase) >= 0)
				{
					return GraphicsUnitConvert.Convert(new PointF(0f, -10f), GraphicsUnit.Millimeter, graphicsUnit_0);
				}
				if (text.IndexOf("xerox phaser", StringComparison.CurrentCultureIgnoreCase) >= 0)
				{
					if (pageSettings_0.Landscape)
					{
						return GraphicsUnitConvert.Convert(new PointF(1.4f, 9f), GraphicsUnit.Millimeter, graphicsUnit_0);
					}
					return GraphicsUnitConvert.Convert(new PointF(6.7f, 1.4f), GraphicsUnit.Millimeter, graphicsUnit_0);
				}
			}
			return new PointF(0f, 0f);
		}

		public static int[] smethod_6(string string_0, int int_0)
		{
			int num = 19;
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			List<int> list = new List<int>();
			string[] array = string_0.Split(',');
			foreach (string text in array)
			{
				int num2 = text.IndexOf("-");
				if (num2 > 0)
				{
					string s = text.Substring(0, num2);
					string s2 = text.Substring(num2 + 1);
					int result = -1;
					int result2 = -1;
					if (!int.TryParse(s, out result) || !int.TryParse(s2, out result2))
					{
						continue;
					}
					for (int j = result; j <= result2; j++)
					{
						if (!list.Contains(j))
						{
							list.Add(j);
						}
					}
				}
				else
				{
					int j = -1;
					if (int.TryParse(text, out j) && j >= 0)
					{
						list.Add(j);
					}
				}
			}
			if (int_0 != 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i] += int_0;
				}
			}
			return list.ToArray();
		}

		public static RectangleF smethod_7(PageBorderBackgroundStyle pageBorderBackgroundStyle_0, PrintPage printPage_0, RectangleF rectangleF_0)
		{
			if (pageBorderBackgroundStyle_0.BorderRange == PageBorderRangeTypes.Page)
			{
				float num = pageBorderBackgroundStyle_0.PaddingLeft;
				if (num <= 0f)
				{
					num = printPage_0.ViewLeftMargin / 2f;
				}
				float num2 = pageBorderBackgroundStyle_0.PaddingTop;
				if (num2 <= 0f)
				{
					num2 = printPage_0.ViewTopMargin / 2f;
				}
				float num3 = pageBorderBackgroundStyle_0.PaddingRight;
				if (num3 <= 0f)
				{
					num3 = printPage_0.ViewRightMargin / 2f;
				}
				float num4 = pageBorderBackgroundStyle_0.PaddingBottom;
				if (num4 <= 0f)
				{
					num4 = printPage_0.ViewBottomMargin / 2f;
				}
				return new RectangleF(num, num2, printPage_0.ViewPaperWidth - num - num3, printPage_0.ViewPaperHeight - num2 - num4);
			}
			if (pageBorderBackgroundStyle_0.BorderRange == PageBorderRangeTypes.Body)
			{
				RectangleF result = new RectangleF(printPage_0.ViewLeftMargin, printPage_0.ViewTopMargin, printPage_0.ViewPaperWidth - printPage_0.ViewLeftMargin - printPage_0.ViewRightMargin, printPage_0.ViewPaperHeight - printPage_0.ViewTopMargin - printPage_0.ViewBottomMargin);
				if (!rectangleF_0.IsEmpty)
				{
					result = rectangleF_0;
					result.Y = rectangleF_0.Y;
					result.Height = rectangleF_0.Height;
				}
				return result;
			}
			return RectangleF.Empty;
		}

		public static MetafileFrameUnit smethod_8(GraphicsUnit graphicsUnit_0)
		{
			switch (graphicsUnit_0)
			{
			case GraphicsUnit.Document:
				return MetafileFrameUnit.Document;
			case GraphicsUnit.Inch:
				return MetafileFrameUnit.Inch;
			case GraphicsUnit.Millimeter:
				return MetafileFrameUnit.Millimeter;
			case GraphicsUnit.Pixel:
				return MetafileFrameUnit.Pixel;
			case GraphicsUnit.Point:
				return MetafileFrameUnit.Point;
			default:
				return MetafileFrameUnit.Pixel;
			}
		}

		private GClass154()
		{
		}
	}
}
