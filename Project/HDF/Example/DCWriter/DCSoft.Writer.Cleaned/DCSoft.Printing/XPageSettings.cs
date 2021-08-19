using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Printing
{
	/// <summary>
	///       页面设置对象
	///       </summary>
	[Serializable]
	[Guid("E859E92D-DC9A-45C8-B834-9B0B9F8EFD02")]
	[ComDefaultInterface(typeof(IXPageSettings))]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[DCPublishAPI]
	[TypeConverter(typeof(GClass156))]
	[Editor(typeof(GClass155), typeof(UITypeEditor))]
	[ComVisible(true)]
	public class XPageSettings : IDisposable, ICloneable, IXPageSettings
	{
		private GEnum25 genum25_0 = GEnum25.flag_19;

		private static XPageSettings xpageSettings_0;

		private static XPageSettings xpageSettings_1;

		private bool bool_0 = true;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private DCDuplexType dcduplexType_0 = DCDuplexType.NoSpecify;

		private DCGridLineInfo dcgridLineInfo_0 = null;

		private DocumentTerminalTextInfo documentTerminalTextInfo_0 = null;

		private bool bool_3 = true;

		private string string_0 = null;

		private List<int> list_0 = null;

		private PageBorderBackgroundStyle pageBorderBackgroundStyle_0 = null;

		private bool bool_4 = false;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private string string_1 = null;

		public static bool bool_5;

		private WatermarkInfo watermarkInfo_0 = null;

		private XImageValue ximageValue_0 = null;

		private string string_2 = null;

		private PaperKind paperKind_0 = PaperKind.A4;

		private bool bool_6 = false;

		private bool bool_7 = false;

		private int int_0 = 1;

		private int int_1 = 50;

		private int int_2 = 50;

		private int int_3 = 0;

		private int int_4 = 827;

		private int int_5 = 0;

		private int int_6 = 1169;

		private Margins margins_0 = null;

		private bool bool_8 = false;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private static Dictionary<string, PrinterSettings.PaperSizeCollection> dictionary_0;

		/// <summary>
		///       MS Word使用的默认页面设置
		///       </summary>
		[DCInternal]
		public static XPageSettings WordDefault
		{
			get
			{
				if (xpageSettings_0 == null)
				{
					xpageSettings_0 = new XPageSettings();
					xpageSettings_0.PaperKind = PaperKind.A4;
					xpageSettings_0.Landscape = false;
					xpageSettings_0.LeftMargin = 125;
					xpageSettings_0.TopMargin = 100;
					xpageSettings_0.RightMargin = 125;
					xpageSettings_0.BottomMargin = 100;
				}
				return xpageSettings_0;
			}
		}

		/// <summary>
		///       IE使用的默认页面设置
		///       </summary>
		[DCInternal]
		public static XPageSettings IEDefault
		{
			get
			{
				if (xpageSettings_1 == null)
				{
					xpageSettings_1 = new XPageSettings();
					xpageSettings_1.PaperKind = PaperKind.A4;
					xpageSettings_1.Landscape = false;
					xpageSettings_1.LeftMargin = 75;
					xpageSettings_1.TopMargin = 75;
					xpageSettings_1.RightMargin = 75;
					xpageSettings_1.BottomMargin = 75;
				}
				return xpageSettings_1;
			}
		}

		/// <summary>
		///       是否启用页眉页脚功能
		///       </summary>
		[DefaultValue(true)]
		public bool EnableHeaderFooter
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
		///       首页的页眉页脚不同
		///       </summary>
		[DefaultValue(false)]
		public bool HeaderFooterDifferentFirstPage
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

		public bool RuntimeHeaderFooterDifferentFirstPage => bool_1 && method_1(GEnum25.flag_18);

		/// <summary>
		///       互换左右页边距,用于实现装订线功能。
		///       </summary>
		/// <remarks>
		///       对于WEB版，只有客户端为IE8+,Opera浏览器本属性设置才有效。
		///       </remarks>
		[DefaultValue(false)]
		public bool SwapLeftRightMargin
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		public bool RuntimeSwapLeftRightMargin => bool_2 && method_1(GEnum25.flag_11);

		/// <summary>
		///       指定的双面打印模式
		///       </summary>
		[DefaultValue(DCDuplexType.NoSpecify)]
		public DCDuplexType SpecifyDuplex
		{
			get
			{
				return dcduplexType_0;
			}
			set
			{
				dcduplexType_0 = value;
			}
		}

		public DCDuplexType RuntimeSpecifyDuplex
		{
			get
			{
				if (method_1(GEnum25.flag_10))
				{
					return dcduplexType_0;
				}
				return DCDuplexType.Default;
			}
		}

		/// <summary>
		///       文档网格线设置
		///       </summary>
		[DefaultValue(null)]
		[Editor(typeof(DCGridLineInfoForPageSettingsUIEditor), typeof(UITypeEditor))]
		public DCGridLineInfo DocumentGridLine
		{
			get
			{
				return dcgridLineInfo_0;
			}
			set
			{
				dcgridLineInfo_0 = value;
			}
		}

		public DCGridLineInfo RuntimeDocumentGridLine
		{
			get
			{
				if (method_1(GEnum25.flag_4))
				{
					return dcgridLineInfo_0;
				}
				return null;
			}
		}

		/// <summary>
		///       文档终结文本
		///       </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		public DocumentTerminalTextInfo TerminalText
		{
			get
			{
				return documentTerminalTextInfo_0;
			}
			set
			{
				documentTerminalTextInfo_0 = value;
			}
		}

		public DocumentTerminalTextInfo RuntimeTerminalText
		{
			get
			{
				if (documentTerminalTextInfo_0 != null)
				{
					if (!method_1(GEnum25.flag_13) && documentTerminalTextInfo_0.method_2())
					{
						return null;
					}
					if (!method_1(GEnum25.flag_14) && documentTerminalTextInfo_0.method_3())
					{
						return null;
					}
					if (!method_1(GEnum25.flag_15) && documentTerminalTextInfo_0.method_4())
					{
						return null;
					}
					if (!method_1(GEnum25.flag_12) && documentTerminalTextInfo_0.method_5())
					{
						return null;
					}
				}
				return documentTerminalTextInfo_0;
			}
		}

		/// <summary>
		///       自动选择最接近的纸张大小
		///       </summary>
		/// <remarks>
		///       检索当前打印机配置的所有的纸张大小，自动选择最接近的纸张大小。
		///       </remarks>
		[DefaultValue(true)]
		public bool AutoChoosePageSize
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		public bool RuntimeAutoChoosePageSize => bool_3 && method_1(GEnum25.flag_1);

		/// <summary>
		///       隐藏页眉页脚的从0开始计算的页码组成的字符串列表，各个页码直接用逗号分开，比如“0,1,3,4”。
		///       </summary>
		[DefaultValue(null)]
		public string PageIndexsForHideHeaderFooter
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
				list_0 = null;
			}
		}

		public string RuntimePageIndexsForHideHeaderFooter
		{
			get
			{
				if (method_1(GEnum25.flag_9))
				{
					return string_0;
				}
				return null;
			}
		}

		/// <summary>
		///       页面内容边框设置
		///       </summary>
		[DefaultValue(null)]
		[Browsable(true)]
		public PageBorderBackgroundStyle PageBorderBackground
		{
			get
			{
				return pageBorderBackgroundStyle_0;
			}
			set
			{
				pageBorderBackgroundStyle_0 = value;
			}
		}

		public PageBorderBackgroundStyle RuntimePageBorderBackground
		{
			get
			{
				if (method_1(GEnum25.flag_8))
				{
					return pageBorderBackgroundStyle_0;
				}
				return null;
			}
		}

		/// <summary>
		///       使用POS打印机进行打印
		///       </summary>
		[DefaultValue(false)]
		public bool ForPOSPrinter
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		public bool RuntimeForPOSPrinter => bool_4 && method_1(GEnum25.flag_6);

		/// <summary>
		///       X方向总体偏移量,单位1/100英寸
		///       </summary>
		[DefaultValue(0)]
		public float OffsetX
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		public float RuntimeOffsetX
		{
			get
			{
				if (method_1(GEnum25.flag_7))
				{
					return float_0;
				}
				return 0f;
			}
		}

		/// <summary>
		///       X方向总体偏移量,单位1/100英寸
		///       </summary>
		[DefaultValue(0)]
		public float OffsetY
		{
			get
			{
				return float_1;
			}
			set
			{
				float_1 = value;
			}
		}

		public float RuntimeOffsetY
		{
			get
			{
				if (method_1(GEnum25.flag_7))
				{
					return float_1;
				}
				return 0f;
			}
		}

		/// <summary>
		///       使用的打印机的名称
		///       </summary>
		[DefaultValue(null)]
		[Editor("DCSoft.WinForms.Design.PrinterNameEditor", typeof(UITypeEditor))]
		public string PrinterName
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       水印信息对象
		///       </summary>
		[DefaultValue(null)]
		[Browsable(true)]
		public WatermarkInfo Watermark
		{
			get
			{
				return watermarkInfo_0;
			}
			set
			{
				watermarkInfo_0 = value;
			}
		}

		public WatermarkInfo RuntimeWatermark
		{
			get
			{
				if (watermarkInfo_0 != null)
				{
					if (!method_1(GEnum25.flag_16) && watermarkInfo_0.Type == WatermarkType.Text)
					{
						return null;
					}
					if (!method_1(GEnum25.flag_17) && watermarkInfo_0.Type == WatermarkType.Image)
					{
						return null;
					}
				}
				return watermarkInfo_0;
			}
		}

		/// <summary>
		///       编辑时背景图片
		///       </summary>
		[DefaultValue(null)]
		public XImageValue EditTimeBackgroundImage
		{
			get
			{
				return ximageValue_0;
			}
			set
			{
				ximageValue_0 = value;
			}
		}

		public XImageValue RuntimeEditTimeBackgroundImage
		{
			get
			{
				if (method_1(GEnum25.flag_5))
				{
					return ximageValue_0;
				}
				return null;
			}
		}

		/// <summary>
		///       纸张来源
		///       </summary>
		[Editor("DCSoft.WinForms.Design.PaperSourceNameEditor", typeof(UITypeEditor))]
		[DefaultValue(null)]
		public string PaperSource
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		/// <summary>
		///       纸张大小,本属性用于整体的设置纸张大小。不能使用该属性下面的属性。
		///       </summary>
		/// <remarks>
		///       本属性用于整体的设置纸张大小。不能使用该属性下面的属性。
		///       比如 instance.PaperSize.Width = 600,这样做是不对的。
		///       应该使用 instance.PaperWidth = 600。
		///       </remarks>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DCInternal]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public PaperSize PaperSize
		{
			get
			{
				return new PaperSize(PaperKind.ToString(), PaperWidth, PaperHeight);
			}
			set
			{
				paperKind_0 = value.Kind;
				int_4 = value.Width;
				int_6 = value.Height;
			}
		}

		/// <summary>
		///       纸张尺寸类型
		///       </summary>
		[DefaultValue(PaperKind.A4)]
		public PaperKind PaperKind
		{
			get
			{
				return paperKind_0;
			}
			set
			{
				paperKind_0 = value;
			}
		}

		/// <summary>
		///       自动设置纸张宽度
		///       </summary>
		[DefaultValue(false)]
		public bool AutoPaperWidth
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		public bool RuntimeAutoPaperWidth => bool_6 && method_1(GEnum25.flag_3);

		/// <summary>
		///       自动适应纸张大小
		///       </summary>
		[DefaultValue(false)]
		public bool AutoFitPageSize
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		public bool RuntimeAutoFitPageSize => bool_7 && method_1(GEnum25.flag_2);

		/// <summary>
		///       打印份数
		///       </summary>
		[DefaultValue(1)]
		public int Copies
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
		///       页眉顶端距离页面上边缘的距离，,单位百分之一英寸
		///       </summary>
		[DefaultValue(50)]
		public int HeaderDistance
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
				if (int_1 < 0)
				{
					int_1 = 0;
				}
			}
		}

		/// <summary>
		///       采用视图单位的页眉距离
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public float ViewHeaderDistance
		{
			get
			{
				if (EnableHeaderFooter)
				{
					return (float)GraphicsUnitConvert.Convert(HeaderDistance, GraphicsUnit.Document, ViewUnit) * 3f;
				}
				return 0f;
			}
		}

		/// <summary>
		///       获得页眉视图高度
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public float ViewHeaderHeight
		{
			get
			{
				if (EnableHeaderFooter)
				{
					return (float)GraphicsUnitConvert.Convert(TopMargin - HeaderDistance, GraphicsUnit.Document, ViewUnit) * 3f;
				}
				return (float)GraphicsUnitConvert.Convert(TopMargin, GraphicsUnit.Document, ViewUnit) * 3f;
			}
		}

		/// <summary>
		///       页脚低端距离页面下边缘的距离，,单位百分之一英寸
		///       </summary>
		[DefaultValue(50)]
		public int FooterDistance
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
		///       采用视图单位的页眉距离
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public float ViewFooterDistance
		{
			get
			{
				if (EnableHeaderFooter)
				{
					return (float)GraphicsUnitConvert.Convert(FooterDistance, GraphicsUnit.Document, ViewUnit) * 3f;
				}
				return 0f;
			}
		}

		/// <summary>
		///       获得页脚视图高度
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public float ViewFooterHeight
		{
			get
			{
				if (EnableHeaderFooter)
				{
					return (float)GraphicsUnitConvert.Convert(BottomMargin - int_2, GraphicsUnit.Document, graphicsUnit_0) * 3f;
				}
				return 0f;
			}
		}

		/// <summary>
		///       设计器纸张宽度,单位百分之一英寸
		///       </summary>
		[DefaultValue(0)]
		[DCInternal]
		public int DesignerPaperWidth
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
		///       纸张宽度,单位百分之一英寸
		///       </summary>
		[DefaultValue(827)]
		public int PaperWidth
		{
			get
			{
				if (paperKind_0 != 0)
				{
					Size size = XPaperSizeCollection.smethod_1(paperKind_0);
					if (!size.IsEmpty)
					{
						return size.Width;
					}
				}
				return int_4;
			}
			set
			{
				DesignerPaperWidth = value;
				int_4 = value;
			}
		}

		/// <summary>
		///       设计器纸张高度
		///       </summary>
		[DefaultValue(0)]
		[DCInternal]
		public int DesignerPaperHeight
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
		///       纸张高度 单位百分之一英寸
		///       </summary>
		[DefaultValue(1169)]
		public int PaperHeight
		{
			get
			{
				if (paperKind_0 != 0)
				{
					Size size = XPaperSizeCollection.smethod_1(paperKind_0);
					if (!size.IsEmpty)
					{
						return size.Height;
					}
				}
				return int_6;
			}
			set
			{
				DesignerPaperHeight = value;
				int_6 = value;
			}
		}

		/// <summary>
		///       页边距,单位百分之一英寸
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public Margins Margins
		{
			get
			{
				if (margins_0 == null)
				{
					margins_0 = new Margins(100, 100, 100, 100);
				}
				return margins_0;
			}
			set
			{
				margins_0 = value;
			}
		}

		/// <summary>
		///       左页边距 单位百分之一英寸
		///       </summary>
		[DefaultValue(100)]
		public int LeftMargin
		{
			get
			{
				return Margins.Left;
			}
			set
			{
				Margins.Left = value;
			}
		}

		/// <summary>
		///       顶页边距 单位百分之一英寸
		///       </summary>
		[DefaultValue(100)]
		public int TopMargin
		{
			get
			{
				return Margins.Top;
			}
			set
			{
				Margins.Top = value;
			}
		}

		/// <summary>
		///       右页边距 单位百分之一英寸
		///       </summary>
		[DefaultValue(100)]
		public int RightMargin
		{
			get
			{
				return Margins.Right;
			}
			set
			{
				Margins.Right = value;
			}
		}

		/// <summary>
		///       底页边距 单位百分之一英寸
		///       </summary>
		[DefaultValue(100)]
		public int BottomMargin
		{
			get
			{
				return Margins.Bottom;
			}
			set
			{
				Margins.Bottom = value;
			}
		}

		/// <summary>
		///       厘米为单位的下页边距
		///       </summary>
		[DefaultValue(0)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[ComVisible(true)]
		public float BottomMarginInCM
		{
			get
			{
				return GraphicsUnitConvert.ConvertToCM((float)BottomMargin / 100f, GraphicsUnit.Inch);
			}
			set
			{
				BottomMargin = (int)(GraphicsUnitConvert.ConvertFromCM(value, GraphicsUnit.Inch) * 100f);
			}
		}

		/// <summary>
		///       厘米为单位的左页边距
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[DefaultValue(0)]
		public float LeftMarginInCM
		{
			get
			{
				return GraphicsUnitConvert.ConvertToCM((float)LeftMargin / 100f, GraphicsUnit.Inch);
			}
			set
			{
				LeftMargin = (int)(GraphicsUnitConvert.ConvertFromCM(value, GraphicsUnit.Inch) * 100f);
			}
		}

		/// <summary>
		///       厘米为单位的上页边距
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(0)]
		[XmlIgnore]
		public float TopMarginInCM
		{
			get
			{
				return GraphicsUnitConvert.ConvertToCM((float)TopMargin / 100f, GraphicsUnit.Inch);
			}
			set
			{
				TopMargin = (int)(GraphicsUnitConvert.ConvertFromCM(value, GraphicsUnit.Inch) * 100f);
			}
		}

		/// <summary>
		///       厘米为单位的右页边距
		///       </summary>
		[ComVisible(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[DefaultValue(0)]
		public float RightMarginInCM
		{
			get
			{
				return GraphicsUnitConvert.ConvertToCM((float)RightMargin / 100f, GraphicsUnit.Inch);
			}
			set
			{
				RightMargin = (int)(GraphicsUnitConvert.ConvertFromCM(value, GraphicsUnit.Inch) * 100f);
			}
		}

		/// <summary>
		///       横向打印标记
		///       </summary>
		[DefaultValue(false)]
		public bool Landscape
		{
			get
			{
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		/// <summary>
		///       设置或返回标准的页面设置对象
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public PageSettings StdPageSettings
		{
			get
			{
				int num = 19;
				PageSettings pageSettings = new PageSettings();
				if (paperKind_0 == PaperKind.Custom)
				{
					if (!bool_8)
					{
						pageSettings.PaperSize = new PaperSize("Custom", PaperWidth, PaperHeight);
					}
					else
					{
						pageSettings.PaperSize = new PaperSize("Custom", PaperWidth, PaperHeight);
					}
				}
				else
				{
					bool flag = false;
					PrinterSettings printerSettings_ = new PrinterSettings();
					foreach (PaperSize item in smethod_1(printerSettings_))
					{
						if (item.Kind == paperKind_0)
						{
							pageSettings.PaperSize = item;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						if (!bool_8)
						{
							pageSettings.PaperSize = new PaperSize("Custom", PaperWidth, PaperHeight);
						}
						else
						{
							pageSettings.PaperSize = new PaperSize("Custom", PaperWidth, PaperHeight);
						}
					}
				}
				pageSettings.Margins = (Margins)Margins.Clone();
				pageSettings.Landscape = bool_8;
				return pageSettings;
			}
			set
			{
				if (value != null)
				{
					Margins = (Margins)value.Margins.Clone();
					paperKind_0 = value.PaperSize.Kind;
					int_4 = value.PaperSize.Width;
					int_6 = value.PaperSize.Height;
					bool_8 = value.Landscape;
				}
			}
		}

		/// <summary>
		///       视图区域使用的度量单位
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public GraphicsUnit ViewUnit
		{
			get
			{
				return graphicsUnit_0;
			}
			set
			{
				graphicsUnit_0 = value;
			}
		}

		/// <summary>
		///       视图单位的左页边距
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public float ViewLeftMargin
		{
			get
			{
				return (float)GraphicsUnitConvert.Convert(LeftMargin, GraphicsUnit.Document, graphicsUnit_0) * 3f;
			}
			set
			{
				LeftMargin = (int)((double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0);
			}
		}

		/// <summary>
		///       视图单位的顶页边距
		///       </summary>
		[XmlIgnore]
		[DCInternal]
		[Browsable(false)]
		public float ViewTopMargin
		{
			get
			{
				return (float)GraphicsUnitConvert.Convert(TopMargin, GraphicsUnit.Document, ViewUnit) * 3f;
			}
			set
			{
				TopMargin = (int)((double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0);
			}
		}

		/// <summary>
		///       视图单位的右页边距
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCInternal]
		public float ViewRightMargin
		{
			get
			{
				return (float)GraphicsUnitConvert.Convert(RightMargin, GraphicsUnit.Document, ViewUnit) * 3f;
			}
			set
			{
				RightMargin = (int)((double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0);
			}
		}

		/// <summary>
		///       视图单位的下页边距
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public float ViewBottomMargin
		{
			get
			{
				return (float)GraphicsUnitConvert.Convert(BottomMargin, GraphicsUnit.Document, ViewUnit) * 3f;
			}
			set
			{
				BottomMargin = (int)((double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0);
			}
		}

		/// <summary>
		///       纸张的视图宽度
		///       </summary>
		[DCInternal]
		[XmlIgnore]
		[Browsable(false)]
		public float ViewPaperWidth
		{
			get
			{
				return (float)GraphicsUnitConvert.Convert(Landscape ? PaperHeight : PaperWidth, GraphicsUnit.Document, ViewUnit) * 3f;
			}
			set
			{
				if (Landscape)
				{
					PaperHeight = (int)((double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0);
				}
				else
				{
					PaperWidth = (int)((double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0);
				}
			}
		}

		/// <summary>
		///       纸张的视图高度
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		[XmlIgnore]
		public float ViewPaperHeight
		{
			get
			{
				return GraphicsUnitConvert.Convert((float)(Landscape ? PaperWidth : PaperHeight), GraphicsUnit.Document, ViewUnit) * 3f;
			}
			set
			{
				int num = (int)((double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0);
				if (Landscape)
				{
					PaperWidth = num;
				}
				else
				{
					PaperHeight = num;
				}
			}
		}

		/// <summary>
		///       纸张可打印的客户区域的宽度,单位 Document
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCInternal]
		public float ViewClientWidth
		{
			get
			{
				int num = Landscape ? PaperHeight : PaperWidth;
				num = num - LeftMargin - RightMargin;
				return (float)GraphicsUnitConvert.Convert(num, GraphicsUnit.Document, ViewUnit) * 3f;
			}
			set
			{
				double num = (double)GraphicsUnitConvert.Convert(value, ViewUnit, GraphicsUnit.Document) / 3.0;
				num = num + (double)LeftMargin + (double)RightMargin;
				if (Landscape)
				{
					PaperHeight = (int)num;
				}
				else
				{
					PaperWidth = (int)num;
				}
			}
		}

		/// <summary>
		///       纸张可打印的客户区域的高度
		///       </summary>
		[Browsable(false)]
		[DCInternal]
		public float ViewClientHeight
		{
			get
			{
				int num = Landscape ? PaperWidth : PaperHeight;
				num = num - TopMargin - BottomMargin;
				return (float)GraphicsUnitConvert.Convert(num, GraphicsUnit.Document, ViewUnit) * 3f;
			}
		}

		static XPageSettings()
		{
			xpageSettings_0 = null;
			xpageSettings_1 = null;
			bool_5 = true;
			dictionary_0 = new Dictionary<string, PrinterSettings.PaperSizeCollection>();
			GClass380.smethod_4(typeof(PrintingResources));
		}

		[DCInternal]
		public void method_0(GEnum25 genum25_1)
		{
			genum25_0 = genum25_1;
		}

		private bool method_1(GEnum25 genum25_1)
		{
			return (genum25_0 & genum25_1) == genum25_1;
		}

		[DCInternal]
		public void method_2(PrinterSettings printerSettings_0)
		{
			switch (SpecifyDuplex)
			{
			case DCDuplexType.Default:
				printerSettings_0.Duplex = Duplex.Default;
				break;
			case DCDuplexType.Horizontal:
				printerSettings_0.Duplex = Duplex.Horizontal;
				break;
			case DCDuplexType.Simplex:
				printerSettings_0.Duplex = Duplex.Simplex;
				break;
			case DCDuplexType.Vertical:
				printerSettings_0.Duplex = Duplex.Vertical;
				break;
			}
		}

		/// <summary>
		///       设置纸张大小
		///       </summary>
		/// <param name="vPaperWidth">纸张宽度</param>
		/// <param name="vPaperHeight">纸张高度</param>
		/// <param name="vLandscape">是否横向打印</param>
		[DCInternal]
		public void SetPageSize(int vPaperWidth, int vPaperHeight, bool vLandscape)
		{
			Landscape = vLandscape;
			foreach (PaperKind value in Enum.GetValues(typeof(PaperKind)))
			{
				Size size = XPaperSizeCollection.smethod_1(value);
				if (!size.IsEmpty)
				{
					if (vLandscape)
					{
						if ((double)Math.Abs(size.Width - vPaperHeight) < (double)size.Width * 0.02 && (double)Math.Abs(size.Height - vPaperWidth) < (double)size.Height * 0.02)
						{
							PaperKind = value;
							return;
						}
					}
					else if ((double)Math.Abs(size.Width - vPaperWidth) < (double)size.Width * 0.02 && (double)Math.Abs(size.Height - vPaperHeight) < (double)size.Height * 0.02)
					{
						PaperKind = value;
						return;
					}
				}
			}
			PaperKind = PaperKind.Custom;
			if (vLandscape)
			{
				PaperWidth = vPaperHeight;
				PaperHeight = vPaperWidth;
			}
			else
			{
				PaperWidth = vPaperWidth;
				PaperHeight = vPaperHeight;
			}
		}

		[DCInternal]
		public bool method_3(int int_7)
		{
			if (!EnableHeaderFooter)
			{
				return false;
			}
			string runtimePageIndexsForHideHeaderFooter = RuntimePageIndexsForHideHeaderFooter;
			if (string.IsNullOrEmpty(runtimePageIndexsForHideHeaderFooter))
			{
				return true;
			}
			if (list_0 == null)
			{
				list_0 = new List<int>();
				string[] array = runtimePageIndexsForHideHeaderFooter.Split(',');
				string[] array2 = array;
				foreach (string s in array2)
				{
					int result = 0;
					if (int.TryParse(s, out result))
					{
						list_0.Add(result);
					}
				}
			}
			if (list_0.Contains(int_7))
			{
				return false;
			}
			return true;
		}

		[DCInternal]
		object ICloneable.Clone()
		{
			XPageSettings xPageSettings = new XPageSettings();
			method_5(xPageSettings);
			return xPageSettings;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public XPageSettings Clone()
		{
			return (XPageSettings)((ICloneable)this).Clone();
		}

		[DCInternal]
		public void method_4(PageSettings pageSettings_0)
		{
			int num = 9;
			if (pageSettings_0 == null)
			{
				throw new ArgumentNullException("ps");
			}
			string printerName = PrinterName;
			if (printerName != null && printerName.Trim().Length > 0)
			{
				printerName = printerName.Trim();
				foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
				{
					if (string.Compare(printerName, installedPrinter, ignoreCase: true) == 0)
					{
						pageSettings_0.PrinterSettings.PrinterName = installedPrinter;
						break;
					}
				}
			}
			string paperSource = PaperSource;
			if (paperSource != null && paperSource.Trim().Length > 0)
			{
				foreach (PaperSource paperSource2 in pageSettings_0.PrinterSettings.PaperSources)
				{
					if (string.Compare(paperSource2.SourceName, paperSource, ignoreCase: true) == 0)
					{
						pageSettings_0.PaperSource = paperSource2;
						break;
					}
				}
			}
			if (!AutoFitPageSize)
			{
				if (PaperKind == PaperKind.Custom)
				{
					PaperSize paperSize2 = pageSettings_0.PaperSize = smethod_0(pageSettings_0, PaperWidth, PaperHeight, bool_9: false);
				}
				else
				{
					foreach (PaperSize item in smethod_1(pageSettings_0.PrinterSettings))
					{
						if (PaperKind == item.Kind)
						{
							pageSettings_0.PaperSize = item;
							break;
						}
					}
				}
				pageSettings_0.Margins = Margins;
			}
			pageSettings_0.Landscape = Landscape;
		}

		internal static PaperSize smethod_0(PageSettings pageSettings_0, int int_7, int int_8, bool bool_9)
		{
			int num = 13;
			PaperSize result = new PaperSize("Custom", int_7, int_8);
			if (bool_9)
			{
				return result;
			}
			int num2 = 10000;
			foreach (PaperSize item in smethod_1(pageSettings_0.PrinterSettings))
			{
				int num3 = Math.Abs(item.Width - int_7);
				int num4 = Math.Abs(item.Height - int_8);
				if (num3 + num4 < num2)
				{
					result = item;
					num2 = num3 + num4;
				}
			}
			if (num2 > 70)
			{
				result = new PaperSize("Custom", int_7, int_8);
			}
			return result;
		}

		[DCInternal]
		public void method_5(XPageSettings xpageSettings_2)
		{
			if (xpageSettings_2 != null)
			{
				xpageSettings_2.genum25_0 = genum25_0;
				xpageSettings_2.SpecifyDuplex = SpecifyDuplex;
				xpageSettings_2.paperKind_0 = paperKind_0;
				xpageSettings_2.int_4 = int_4;
				xpageSettings_2.int_6 = int_6;
				xpageSettings_2.bool_4 = bool_4;
				xpageSettings_2.margins_0 = (Margins)Margins.Clone();
				xpageSettings_2.bool_8 = bool_8;
				xpageSettings_2.string_2 = string_2;
				xpageSettings_2.graphicsUnit_0 = graphicsUnit_0;
				xpageSettings_2.string_1 = string_1;
				xpageSettings_2.bool_6 = bool_6;
				xpageSettings_2.bool_7 = bool_7;
				xpageSettings_2.int_1 = int_1;
				xpageSettings_2.int_2 = int_2;
				xpageSettings_2.float_0 = float_0;
				xpageSettings_2.float_1 = float_1;
				xpageSettings_2.string_0 = string_0;
				xpageSettings_2.list_0 = null;
				xpageSettings_2.bool_2 = bool_2;
				xpageSettings_2.bool_1 = bool_1;
				if (ximageValue_0 != null)
				{
					xpageSettings_2.ximageValue_0 = ximageValue_0.Clone();
				}
				if (pageBorderBackgroundStyle_0 != null)
				{
					xpageSettings_2.pageBorderBackgroundStyle_0 = (PageBorderBackgroundStyle)pageBorderBackgroundStyle_0.Clone();
				}
				if (watermarkInfo_0 != null)
				{
					xpageSettings_2.watermarkInfo_0 = watermarkInfo_0.Clone();
				}
				if (documentTerminalTextInfo_0 != null)
				{
					xpageSettings_2.documentTerminalTextInfo_0 = documentTerminalTextInfo_0.method_7();
				}
				xpageSettings_2.bool_3 = bool_3;
				if (dcgridLineInfo_0 != null)
				{
					xpageSettings_2.dcgridLineInfo_0 = dcgridLineInfo_0.method_5();
				}
				xpageSettings_2.bool_0 = bool_0;
			}
		}

		[DCInternal]
		public void method_6(string string_3)
		{
			int num = 0;
			if (string_3 == null)
			{
				return;
			}
			string[] array = string_3.Split(',');
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (Enum.IsDefined(typeof(PaperKind), text))
				{
					PaperKind = (PaperKind)Enum.Parse(typeof(PaperKind), text, ignoreCase: true);
					continue;
				}
				string text2 = text.Trim().ToLower();
				string text3 = "";
				int num2 = text.IndexOf("=");
				if (num2 > 0)
				{
					text2 = text.Substring(0, num2).Trim().ToLower();
					text3 = text.Substring(num2 + 1).Trim();
				}
				switch (text2)
				{
				case "landscape":
					if (text3.Length > 0)
					{
						bool result = false;
						if (bool.TryParse(text3, out result))
						{
							Landscape = result;
						}
					}
					else
					{
						Landscape = true;
					}
					break;
				case "swapleftrightmargin":
					if (text3.Length > 0)
					{
						bool result = false;
						if (bool.TryParse(text3, out result))
						{
							SwapLeftRightMargin = result;
						}
					}
					else
					{
						SwapLeftRightMargin = true;
					}
					break;
				case "autopaperwidth":
					if (text3.Length > 0)
					{
						bool result = true;
						if (bool.TryParse(text3, out result))
						{
							AutoPaperWidth = result;
						}
					}
					else
					{
						AutoPaperWidth = true;
					}
					break;
				case "autofitpagesize":
					if (text3.Length > 0)
					{
						bool result = true;
						if (bool.TryParse(text3, out result))
						{
							AutoFitPageSize = result;
						}
					}
					else
					{
						AutoFitPageSize = true;
					}
					break;
				case "paperwidth":
				{
					int result2 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result2))
					{
						PaperWidth = result2;
					}
					break;
				}
				case "paperheight":
				{
					int result6 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result6))
					{
						PaperHeight = result6;
					}
					break;
				}
				case "leftmargin":
				{
					int result8 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result8))
					{
						LeftMargin = result8;
					}
					break;
				}
				case "topmargin":
				{
					int result5 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result5))
					{
						TopMargin = result5;
					}
					break;
				}
				case "rightmargin":
				{
					int result7 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result7))
					{
						RightMargin = result7;
					}
					break;
				}
				case "bottommargin":
				{
					int result3 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result3))
					{
						BottomMargin = result3;
					}
					break;
				}
				case "headerdistance":
				{
					int result4 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result4))
					{
						HeaderDistance = result4;
					}
					break;
				}
				case "footerdistance":
				{
					int result4 = 0;
					if (text3.Length > 0 && int.TryParse(text3, out result4))
					{
						FooterDistance = result4;
					}
					break;
				}
				case "printername":
					PrinterName = text3;
					break;
				case "papersource":
					PaperSource = text3;
					break;
				case "headerfooterdifferentfirstpage":
					if (text3.Length > 0)
					{
						bool result = false;
						if (bool.TryParse(text3, out result))
						{
							HeaderFooterDifferentFirstPage = result;
						}
					}
					else
					{
						HeaderFooterDifferentFirstPage = false;
					}
					break;
				}
			}
		}

		private float method_7(float float_2)
		{
			return GraphicsUnitConvert.ConvertToCM(float_2 * 3f, GraphicsUnit.Document);
		}

		[DCInternal]
		public override string ToString()
		{
			int num = 5;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(paperKind_0.ToString());
			if (PaperKind == PaperKind.Custom)
			{
				stringBuilder.Append(",PaperWidth=" + PaperWidth + "(" + method_7(PaperWidth).ToString("0.00") + "CM)");
				stringBuilder.Append(",PaperHeight=" + PaperHeight + "(" + method_7(PaperHeight).ToString("0.00") + "CM)");
			}
			if (Landscape)
			{
				stringBuilder.Append(",Landscape");
			}
			if (SwapLeftRightMargin)
			{
				stringBuilder.Append(",SwapLeftRightMargin");
			}
			if (LeftMargin != 100)
			{
				stringBuilder.Append(",LeftMargin=" + LeftMargin + "(" + method_7(LeftMargin).ToString("0.00") + "CM)");
			}
			if (TopMargin != 100)
			{
				stringBuilder.Append(",TopMargin=" + TopMargin + "(" + method_7(TopMargin).ToString("0.00") + "CM)");
			}
			if (RightMargin != 100)
			{
				stringBuilder.Append(",RightMargin=" + RightMargin + "(" + method_7(RightMargin).ToString("0.00") + "CM)");
			}
			if (BottomMargin != 100)
			{
				stringBuilder.Append(",BottomMargin=" + BottomMargin + "(" + method_7(BottomMargin).ToString("0.00") + "CM)");
			}
			if (PrinterName != null && PrinterName.Length > 0)
			{
				stringBuilder.Append(",PrinterName=" + PrinterName);
			}
			if (PaperSource != null && PaperSource.Length > 0)
			{
				stringBuilder.Append(",PaperSource=" + PaperSource);
			}
			if (AutoPaperWidth)
			{
				stringBuilder.Append(",AutoPaperWidth");
			}
			if (AutoFitPageSize)
			{
				stringBuilder.Append(",AutoFitPageSize");
			}
			if (HeaderDistance > 0)
			{
				stringBuilder.Append(",HeaderDistance=" + HeaderDistance);
			}
			if (FooterDistance > 0)
			{
				stringBuilder.Append(",FooterDistance=" + FooterDistance);
			}
			if (HeaderFooterDifferentFirstPage)
			{
				stringBuilder.Append(",HeaderFooterDifferentFirstPage=" + FooterDistance);
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		[DCInternal]
		public void Dispose()
		{
			if (ximageValue_0 != null)
			{
				ximageValue_0.Dispose();
			}
			if (watermarkInfo_0 != null)
			{
				watermarkInfo_0.Dispose();
			}
			if (pageBorderBackgroundStyle_0 != null)
			{
				pageBorderBackgroundStyle_0.Dispose();
			}
		}

		internal static PrinterSettings.PaperSizeCollection smethod_1(PrinterSettings printerSettings_0)
		{
			int num = 5;
			if (printerSettings_0 == null)
			{
				throw new ArgumentNullException("ps");
			}
			string text = printerSettings_0.PrinterName;
			if (text == null)
			{
				text = "";
			}
			if (dictionary_0.ContainsKey(text))
			{
				return dictionary_0[text];
			}
			PrinterSettings.PaperSizeCollection paperSizes = printerSettings_0.PaperSizes;
			dictionary_0[text] = paperSizes;
			return paperSizes;
		}
	}
}
