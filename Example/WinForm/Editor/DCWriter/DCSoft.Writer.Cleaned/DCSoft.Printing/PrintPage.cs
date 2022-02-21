using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印页对象
	///       </summary>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IPrintPage))]
	[ComVisible(true)]
	[DocumentComment]
	[DCPublishAPI(ApplyToMembers = false)]
	[Guid("ACF76829-6768-439A-A792-672A8DE377EA")]
	public class PrintPage : IPrintPage
	{
		private bool _FirstPageFlag = false;

		private List<SimpleRectangleTransform> _OwneredTransformItems = null;

		[NonSerialized]
		private IList _HeaderRows = null;

		private RectangleF _HeaderRowsBounds = RectangleF.Empty;

		private XPageSettings myPageSettings = null;

		private float intDocumentHeight = 0f;

		[NonSerialized]
		private IPageDocument myDocument = null;

		private PrintPageCollection myOwnerPages = null;

		private Point _ClientLocation = Point.Empty;

		private float intHeaderContentHeight = 0f;

		private float intFooterContentHeight = 0f;

		protected float intLeft = 0f;

		private float _Top = -1f;

		private float intWidth = 0f;

		private float intHeight = 0f;

		/// <summary>
		///       从0开始计算的全局页码
		///       </summary>
		private int _GlobalIndex = 0;

		private Margins _Margins = null;

		private Margins _RuntimeMargins = null;

		private Margins myClientMargins = new Margins();

		protected Rectangle myClientBounds = Rectangle.Empty;

		private int _ClientLeftFix = 0;

		private bool _ForNewPage = false;

		/// <summary>
		///       首页标记
		///       </summary>
		
		public bool FirstPageFlag
		{
			get
			{
				return _FirstPageFlag;
			}
			set
			{
				_FirstPageFlag = value;
			}
		}

		/// <summary>
		///       页面所拥有的坐标转换项目
		///       </summary>
		
		public List<SimpleRectangleTransform> OwneredTransformItems
		{
			get
			{
				if (_OwneredTransformItems == null)
				{
					_OwneredTransformItems = new List<SimpleRectangleTransform>();
				}
				return _OwneredTransformItems;
			}
			set
			{
				_OwneredTransformItems = value;
			}
		}

		/// <summary>
		///       标题行
		///       </summary>
		public IList HeaderRows
		{
			get
			{
				return _HeaderRows;
			}
			set
			{
				_HeaderRows = value;
			}
		}

		/// <summary>
		///       标题行的边界,采用文档视图坐标
		///       </summary>
		public RectangleF HeaderRowsBounds
		{
			get
			{
				return _HeaderRowsBounds;
			}
			set
			{
				_HeaderRowsBounds = value;
			}
		}

		/// <summary>
		///       页面设置对象
		///       </summary>
		[XmlIgnore]
		public XPageSettings PageSettings
		{
			get
			{
				return myPageSettings;
			}
			set
			{
				myPageSettings = value;
			}
		}

		/// <summary>
		///       文档高度
		///       </summary>
		public float DocumentHeight
		{
			get
			{
				return intDocumentHeight;
			}
			set
			{
				intDocumentHeight = value;
			}
		}

		/// <summary>
		///       页面所属文档对象
		///       </summary>
		public IPageDocument Document
		{
			get
			{
				return myDocument;
			}
			set
			{
				myDocument = value;
			}
		}

		/// <summary>
		///       对象所属页面集合
		///       </summary>
		public PrintPageCollection OwnerPages
		{
			get
			{
				return myOwnerPages;
			}
			set
			{
				myOwnerPages = value;
				if (myOwnerPages != null && intHeight < (float)myOwnerPages.MinPageHeight)
				{
					intHeight = myOwnerPages.MinPageHeight;
				}
			}
		}

		/// <summary>
		///       在控件客户区域中的位置
		///       </summary>
		public Point ClientLocation
		{
			get
			{
				return _ClientLocation;
			}
			set
			{
				_ClientLocation = value;
			}
		}

		/// <summary>
		///       页眉内容高度
		///       </summary>
		public float HeaderContentHeight
		{
			get
			{
				return intHeaderContentHeight;
			}
			set
			{
				intHeaderContentHeight = value;
			}
		}

		/// <summary>
		///       采用视图单位的标准的页面正文内容区域高度,DCWriter内部使用。
		///       </summary>
		public float StandartPapeBodyHeight
		{
			get
			{
				XPageSettings pageSettings = PageSettings;
				float num = pageSettings.ViewClientHeight;
				if (pageSettings.EnableHeaderFooter)
				{
					if (HeaderContentHeight > pageSettings.ViewHeaderHeight)
					{
						num -= HeaderContentHeight - pageSettings.ViewHeaderHeight;
					}
					if (FooterContentHeight > pageSettings.ViewFooterHeight)
					{
						num -= FooterContentHeight - pageSettings.ViewFooterHeight;
					}
				}
				return num;
			}
		}

		/// <summary>
		///       页脚内容高度
		///       </summary>
		public float FooterContentHeight
		{
			get
			{
				return intFooterContentHeight;
			}
			set
			{
				intFooterContentHeight = value;
			}
		}

		public float Left
		{
			get
			{
				return intLeft;
			}
			set
			{
				intLeft = value;
			}
		}

		/// <summary>
		///       获得打印页的顶端位置
		///       </summary>
		
		public float Top => _Top;

		/// <summary>
		///       页面对象的宽度
		///       </summary>
		public float Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				intWidth = value;
			}
		}

		/// <summary>
		///       页高
		///       </summary>
		
		public float Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
				FixHeight();
			}
		}

		/// <summary>
		///       标准页高
		///       </summary>
		public float ViewStandardHeight => myPageSettings.ViewClientHeight - intHeaderContentHeight - intFooterContentHeight;

		public float Right => intLeft + intWidth;

		/// <summary>
		///       设置,返回页面对象的底线
		///       </summary>
		
		public float Bottom
		{
			get
			{
				return Top + intHeight;
			}
			set
			{
				intHeight = value - Top;
				FixHeight();
			}
		}

		/// <summary>
		///       从0开始计算的全局页码
		///       </summary>
		public int GlobalIndex
		{
			get
			{
				return _GlobalIndex;
			}
			set
			{
				_GlobalIndex = value;
			}
		}

		/// <summary>
		///       页面本地使用的页边距信息对象
		///       </summary>
		public Margins Margins
		{
			get
			{
				return _Margins;
			}
			set
			{
				_Margins = value;
			}
		}

		/// <summary>
		///       运行时使用的页边距设置
		///       </summary>
		public Margins RuntimeMargins
		{
			get
			{
				if (_Margins != null)
				{
					return _Margins;
				}
				return myPageSettings.Margins;
			}
		}

		public float ViewLeftMargin => (float)GraphicsUnitConvert.Convert(RuntimeMargins.Left, GraphicsUnit.Document, myPageSettings.ViewUnit) * 3f;

		public float ViewTopMargin => (float)GraphicsUnitConvert.Convert(RuntimeMargins.Top, GraphicsUnit.Document, myPageSettings.ViewUnit) * 3f;

		public float ViewRightMargin => (float)GraphicsUnitConvert.Convert(RuntimeMargins.Right, GraphicsUnit.Document, myPageSettings.ViewUnit) * 3f;

		public float ViewBottomMargin => (float)GraphicsUnitConvert.Convert(RuntimeMargins.Bottom, GraphicsUnit.Document, myPageSettings.ViewUnit) * 3f;

		public float ViewPaperWidth => myPageSettings.ViewPaperWidth;

		public float ViewPaperHeight => myPageSettings.ViewPaperHeight;

		/// <summary>
		///       页面对象在未分割的文档视图中的边框
		///       </summary>
		/// <returns>
		/// </returns>
		public RectangleF Bounds => new RectangleF(0f, Top, intWidth, intHeight);

		public Margins ClientMargins
		{
			get
			{
				return myClientMargins;
			}
			set
			{
				myClientMargins = value;
			}
		}

		public Rectangle ClientBounds
		{
			get
			{
				return myClientBounds;
			}
			set
			{
				myClientBounds = value;
			}
		}

		public int ClientLeftFix
		{
			get
			{
				return _ClientLeftFix;
			}
			set
			{
				_ClientLeftFix = value;
			}
		}

		/// <summary>
		///       由于文档元素设置了强制分页而导致了分页
		///       </summary>
		public bool ForNewPage
		{
			get
			{
				return _ForNewPage;
			}
			set
			{
				_ForNewPage = value;
			}
		}

		/// <summary>
		///       获得从0开始的页号
		///       </summary>
		public int PageIndex
		{
			get
			{
				if (myOwnerPages == null)
				{
					return -1;
				}
				return myOwnerPages.IndexOf(this);
			}
		}

		
		public PrintPage(IPageDocument document, XPageSettings pageSettings, PrintPageCollection pages, float headerHeight, float footerHeight)
		{
			myDocument = document;
			myPageSettings = pageSettings;
			myOwnerPages = pages;
			intHeaderContentHeight = headerHeight;
			intFooterContentHeight = footerHeight;
			intWidth = (int)myPageSettings.ViewClientWidth;
			intHeight = ViewStandardHeight - 10f;
			ResetTop();
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		
		public override string ToString()
		{
			return "Page " + PageIndex;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public PrintPage Clone()
		{
			return (PrintPage)MemberwiseClone();
		}

		public void AddOwneredTransformItem(SimpleRectangleTransform item)
		{
			if (_OwneredTransformItems == null)
			{
				_OwneredTransformItems = new List<SimpleRectangleTransform>();
			}
			_OwneredTransformItems.Add(item);
		}

		/// <summary>
		///       获得实时的顶端位置
		///       </summary>
		private float GetRealtimeTop()
		{
			float num = myOwnerPages.Top;
			foreach (PrintPage myOwnerPage in myOwnerPages)
			{
				if (myOwnerPage == this)
				{
					break;
				}
				num += myOwnerPage.Height;
			}
			return num;
		}

		public void ResetTop()
		{
			_Top = GetRealtimeTop();
		}

		private void FixHeight()
		{
			if (intHeight < (float)myOwnerPages.MinPageHeight)
			{
				intHeight = myOwnerPages.MinPageHeight;
			}
			if (!PageSettings.ForPOSPrinter)
			{
				float standartPapeBodyHeight = StandartPapeBodyHeight;
				if (intHeight > standartPapeBodyHeight)
				{
					intHeight = standartPapeBodyHeight;
				}
			}
		}
	}
}
