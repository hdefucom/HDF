using DCSoft.Common;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       网格线设置
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IGridLineSettings))]
	[DocumentComment]
	[Guid("FF0166D8-6E3A-4ADB-BD81-BF83C078B4DA")]
	[ComVisible(true)]
	[ComClass("FF0166D8-6E3A-4ADB-BD81-BF83C078B4DA", "18A4C37F-F6AC-4617-B27F-DAE378CE8E13")]
	
	public class GridLineSettings : IGridLineSettings
	{
		internal const string CLASSID = "FF0166D8-6E3A-4ADB-BD81-BF83C078B4DA";

		internal const string CLASSID_Interface = "18A4C37F-F6AC-4617-B27F-DAE378CE8E13";

		private bool _ShowGridLine = false;

		private Color _GridLineColor = Color.Gray;

		private bool _PrintGridLine = true;

		private DashStyle _LineStyle = DashStyle.Solid;

		/// <summary>
		///       是否显示网格线
		///       </summary>
		
		[DefaultValue(false)]
		public bool ShowGridLine
		{
			get
			{
				return _ShowGridLine;
			}
			set
			{
				_ShowGridLine = value;
			}
		}

		/// <summary>
		///       网格线颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Gray")]
		
		[XmlIgnore]
		public Color GridLineColor
		{
			get
			{
				return _GridLineColor;
			}
			set
			{
				_GridLineColor = value;
			}
		}

		/// <summary>
		///       网格线颜色值
		///       </summary>
		[XmlElement]
		[Browsable(false)]
		[DefaultValue("Gray")]
		public string GridLineColorValue
		{
			get
			{
				return ColorTranslator.ToHtml(GridLineColor);
			}
			set
			{
				GridLineColor = ColorTranslator.FromHtml(value);
			}
		}

		/// <summary>
		///       是否打印网格线
		///       </summary>
		
		[DefaultValue(true)]
		public bool PrintGridLine
		{
			get
			{
				return _PrintGridLine;
			}
			set
			{
				_PrintGridLine = value;
			}
		}

		/// <summary>
		///       线条样式
		///       </summary>
		[DefaultValue(DashStyle.Solid)]
		
		public DashStyle LineStyle
		{
			get
			{
				return _LineStyle;
			}
			set
			{
				_LineStyle = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public GridLineSettings()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public GridLineSettings Clone()
		{
			return (GridLineSettings)MemberwiseClone();
		}
	}
}
