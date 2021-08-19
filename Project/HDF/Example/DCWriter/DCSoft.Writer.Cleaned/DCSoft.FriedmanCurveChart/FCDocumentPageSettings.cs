using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       页面设置
	///       </summary>
	[Serializable]
	[DocumentComment]
	[ComDefaultInterface(typeof(IDocumentPageSettings))]
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[Guid("3E082D03-C2B7-4136-B79A-DE83FE4C8F93")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	public class FCDocumentPageSettings : IDocumentPageSettings
	{
		private string string_0 = "A4";

		private int int_0 = 827;

		private int int_1 = 1169;

		private int int_2 = 100;

		private int int_3 = 100;

		private int int_4 = 100;

		private int int_5 = 100;

		private bool bool_0 = false;

		private bool bool_1 = false;

		/// <summary>
		///       纸张大小名称
		///       </summary>
		[DCDisplayName(typeof(FCDocumentPageSettings), "PaperSizeName")]
		[DefaultValue("A4")]
		public string PaperSizeName
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       纸张宽度,单位百分之一英寸
		///       </summary>
		[DefaultValue(827)]
		[DCDisplayName(typeof(FCDocumentPageSettings), "PaperWidth")]
		public int PaperWidth
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       纸张高度 单位百分之一英寸
		///       </summary>
		[DCDisplayName(typeof(FCDocumentPageSettings), "PaperHeight")]
		[DefaultValue(1169)]
		public int PaperHeight
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
		///       左页边距 单位百分之一英寸
		///       </summary>
		[DCDisplayName(typeof(FCDocumentPageSettings), "LeftMargin")]
		[DefaultValue(100)]
		public int LeftMargin
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		/// <summary>
		///       顶页边距 单位百分之一英寸
		///       </summary>
		[DefaultValue(100)]
		[DCDisplayName(typeof(FCDocumentPageSettings), "TopMargin")]
		public int TopMargin
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		/// <summary>
		///       右页边距 单位百分之一英寸
		///       </summary>
		[DefaultValue(100)]
		[DCDisplayName(typeof(FCDocumentPageSettings), "RightMargin")]
		public int RightMargin
		{
			get
			{
				return int_4;
			}
			set
			{
				int_4 = value;
			}
		}

		/// <summary>
		///       底页边距 单位百分之一英寸
		///       </summary>
		[DefaultValue(100)]
		[DCDisplayName(typeof(FCDocumentPageSettings), "BottomMargin")]
		public int BottomMargin
		{
			get
			{
				return int_5;
			}
			set
			{
				int_5 = value;
			}
		}

		/// <summary>
		///       横向打印标记
		///       </summary>
		[DefaultValue(false)]
		[DCDisplayName(typeof(FCDocumentPageSettings), "Landscape")]
		public bool Landscape
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       打印是否自适应缩放
		///       </summary>
		[DefaultValue(false)]
		[DCDisplayName(typeof(FCDocumentPageSettings), "AutoFitPageSize")]
		public bool AutoFitPageSize
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       页面边界
		///       </summary>
		[Browsable(false)]
		public Rectangle Bounds
		{
			get
			{
				if (Landscape)
				{
					return new Rectangle(0, 0, PaperHeight, PaperWidth);
				}
				return new Rectangle(0, 0, PaperWidth, PaperHeight);
			}
		}

		public void method_0(PageSettings pageSettings_0)
		{
			if (pageSettings_0 != null)
			{
				pageSettings_0.PaperSize = new PaperSize(PaperSizeName, PaperWidth, PaperHeight);
				pageSettings_0.Landscape = Landscape;
				pageSettings_0.Margins = new Margins(LeftMargin, RightMargin, TopMargin, BottomMargin);
			}
		}

		public void method_1(PageSettings pageSettings_0)
		{
			if (pageSettings_0 != null)
			{
				PaperSizeName = pageSettings_0.PaperSize.PaperName;
				PaperWidth = pageSettings_0.PaperSize.Width;
				PaperHeight = pageSettings_0.PaperSize.Height;
				LeftMargin = pageSettings_0.Margins.Left;
				TopMargin = pageSettings_0.Margins.Top;
				RightMargin = pageSettings_0.Margins.Right;
				BottomMargin = pageSettings_0.Margins.Bottom;
				Landscape = pageSettings_0.Landscape;
			}
		}
	}
}
