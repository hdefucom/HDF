using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       体温单打印文档
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DCPublishAPI]
	[ToolboxItem(false)]
	public class FriedmanCurvePrintDocument : PrintDocument
	{
		private FriedmanCurveDocument friedmanCurveDocument_0;

		private int int_0;

		private int int_1;

		/// <summary>
		///       打印指定的页码
		///       </summary>
		[DefaultValue(-1)]
		public int SpecifyPageIndex
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		public FriedmanCurvePrintDocument(FriedmanCurveDocument friedmanCurveDocument_1)
		{
			int num = 5;
			friedmanCurveDocument_0 = null;
			int_0 = 0;
			int_1 = -1;
			
			if (friedmanCurveDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			friedmanCurveDocument_0 = friedmanCurveDocument_1;
			if (friedmanCurveDocument_0.Config.PageSettings == null)
			{
			}
			base.DocumentName = "DCFriedmanCurve " + friedmanCurveDocument_1.Title;
		}

		/// <summary>
		///       查询文档页面设置
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnQueryPageSettings(QueryPageSettingsEventArgs queryPageSettingsEventArgs_0)
		{
			if (friedmanCurveDocument_0.Config.PageSettings != null)
			{
				friedmanCurveDocument_0.Config.PageSettings.method_0(queryPageSettingsEventArgs_0.PageSettings);
			}
			base.OnQueryPageSettings(queryPageSettingsEventArgs_0);
		}

		/// <summary>
		///       开始打印任务
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnBeginPrint(PrintEventArgs printEventArgs_0)
		{
			DateTime maxDate = FriedmanCurveDocument.NullDate;
			DateTime minDate = FriedmanCurveDocument.NullDate;
			int_0 = 0;
			friedmanCurveDocument_0.UpdateNumOfPage(out maxDate, out minDate);
			base.OnBeginPrint(printEventArgs_0);
		}

		/// <summary>
		///       打印结束
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnEndPrint(PrintEventArgs printEventArgs_0)
		{
			base.OnEndPrint(printEventArgs_0);
		}

		/// <summary>
		///       打印一页
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnPrintPage(PrintPageEventArgs printPageEventArgs_0)
		{
			base.OnPrintPage(printPageEventArgs_0);
			if (int_1 >= 0)
			{
				int_0 = int_1;
			}
			int pageIndex = friedmanCurveDocument_0.PageIndex;
			friedmanCurveDocument_0.PageIndex = int_0;
			printPageEventArgs_0.Graphics.PageUnit = GraphicsUnit.Document;
			RectangleF bounds = friedmanCurveDocument_0.Bounds;
			friedmanCurveDocument_0.Left = printPageEventArgs_0.PageSettings.Margins.Left * 3;
			friedmanCurveDocument_0.Top = printPageEventArgs_0.PageSettings.Margins.Top * 3;
			friedmanCurveDocument_0.Width = (float)(printPageEventArgs_0.PageSettings.Bounds.Width * 3) - friedmanCurveDocument_0.Left - (float)(printPageEventArgs_0.PageSettings.Margins.Right * 3);
			friedmanCurveDocument_0.Height = (float)(printPageEventArgs_0.PageSettings.Bounds.Height * 3) - friedmanCurveDocument_0.Top - (float)(printPageEventArgs_0.PageSettings.Margins.Bottom * 3);
			friedmanCurveDocument_0.ViewMode = FCDocumentViewMode.Page;
			Graphics graphics = printPageEventArgs_0.Graphics;
			if (friedmanCurveDocument_0.Config.PageSettings.AutoFitPageSize)
			{
				float num = 1f;
				float sy = 1f;
				float num2 = base.DefaultPageSettings.PaperSize.Width;
				float num3 = base.DefaultPageSettings.PaperSize.Height;
				float num4 = printPageEventArgs_0.PageSettings.Bounds.Width;
				float num5 = printPageEventArgs_0.PageSettings.Bounds.Height;
				if (printPageEventArgs_0.PageSettings.Landscape)
				{
					num4 = printPageEventArgs_0.PageSettings.Bounds.Height;
					num5 = printPageEventArgs_0.PageSettings.Bounds.Width;
				}
				if (((double)Math.Abs((num2 - num4) / num4) > 0.04 || (double)Math.Abs((num3 - num5) / num5) > 0.04) && num4 > 0f && num5 > 0f)
				{
					float num6 = Math.Min(num2 / num4, num3 / num5);
					num = num6;
					sy = num6;
				}
				if (num != 1f)
				{
					graphics.ScaleTransform(num, sy);
				}
				if (printPageEventArgs_0.PageSettings.Landscape && num < 1f)
				{
					float num7 = (num4 - num4 * num) * 3f - 50f;
					if (num7 > 1100f)
					{
						num7 = 1100f;
					}
					if (num7 < 700f)
					{
						num7 = 700f;
					}
					friedmanCurveDocument_0.Left += num7;
				}
			}
			try
			{
				friedmanCurveDocument_0.PrintingMode = true;
				friedmanCurveDocument_0.method_13(new DCGraphics(graphics), new RectangleF(0f, 0f, 10000f, 10000f), GEnum23.const_2);
			}
			finally
			{
				friedmanCurveDocument_0.PrintingMode = false;
				friedmanCurveDocument_0.Bounds = bounds;
				friedmanCurveDocument_0.PageIndex = pageIndex;
			}
			int_0++;
			if (int_1 >= 0 || int_0 >= friedmanCurveDocument_0.NumOfPages)
			{
				printPageEventArgs_0.HasMorePages = false;
			}
			else
			{
				printPageEventArgs_0.HasMorePages = true;
			}
		}
	}
}
