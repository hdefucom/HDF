using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       边框命令参数对象
	///       </summary>
	[Serializable]
	[DocumentComment]
	[ComClass("B2916388-F487-4031-BF1C-499330DC0AD9", "685ABB26-D0E5-414C-8ED3-EC6F349D7966")]
	[ComDefaultInterface(typeof(IBorderBackgroundCommandParameter))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("B2916388-F487-4031-BF1C-499330DC0AD9")]
	
	public class BorderBackgroundCommandParameter : IBorderBackgroundCommandParameter
	{
		internal const string CLASSID = "B2916388-F487-4031-BF1C-499330DC0AD9";

		internal const string CLASSID_Interface = "685ABB26-D0E5-414C-8ED3-EC6F349D7966";

		private XTextElementList _Elements = null;

		private bool _TopBorder = true;

		private bool _MiddleHorizontalBorder = true;

		private bool _BottomBorder = true;

		private bool _LeftBorder = true;

		private bool _CenterVerticalBorder = true;

		private bool _RightBorder = true;

		private Color _BorderLeftColor = Color.Black;

		private Color _BorderTopColor = Color.Black;

		private Color _BorderRightColor = Color.Black;

		private Color _BorderBottomColor = Color.Black;

		private DashStyle _BorderStyle = DashStyle.Solid;

		private float _BorderWidth = 1f;

		private Color _BackgroundColor = Color.Transparent;

		private StyleApplyRanges _ApplyRange = StyleApplyRanges.Text;

		private BorderSettingsStyle _BorderSettingsStyle = BorderSettingsStyle.None;

		/// <summary>
		///       指定参与处理的文档元素列表 
		///       </summary>
		
		public XTextElementList Elements
		{
			get
			{
				return _Elements;
			}
			set
			{
				_Elements = value;
			}
		}

		/// <summary>
		///       是否显示顶端边框线
		///       </summary>
		
		public bool TopBorder
		{
			get
			{
				return _TopBorder;
			}
			set
			{
				_TopBorder = value;
			}
		}

		/// <summary>
		///       是否显示水平中间的边框线
		///       </summary>
		
		public bool MiddleHorizontalBorder
		{
			get
			{
				return _MiddleHorizontalBorder;
			}
			set
			{
				_MiddleHorizontalBorder = value;
			}
		}

		/// <summary>
		///       是否显示低端边框线
		///       </summary>
		
		public bool BottomBorder
		{
			get
			{
				return _BottomBorder;
			}
			set
			{
				_BottomBorder = value;
			}
		}

		/// <summary>
		///       是否显示左端边框线
		///       </summary>
		
		public bool LeftBorder
		{
			get
			{
				return _LeftBorder;
			}
			set
			{
				_LeftBorder = value;
			}
		}

		/// <summary>
		///       是否显示垂直居中的边框线
		///       </summary>
		
		public bool CenterVerticalBorder
		{
			get
			{
				return _CenterVerticalBorder;
			}
			set
			{
				_CenterVerticalBorder = value;
			}
		}

		/// <summary>
		///       是否显示右边的边框线
		///       </summary>
		
		public bool RightBorder
		{
			get
			{
				return _RightBorder;
			}
			set
			{
				_RightBorder = value;
			}
		}

		/// <summary>
		///       边框线颜色
		///       </summary>
		
		public Color BorderLeftColor
		{
			get
			{
				return _BorderLeftColor;
			}
			set
			{
				_BorderLeftColor = value;
			}
		}

		/// <summary>
		///       边框线颜色
		///       </summary>
		
		public Color BorderTopColor
		{
			get
			{
				return _BorderTopColor;
			}
			set
			{
				_BorderTopColor = value;
			}
		}

		/// <summary>
		///       边框线颜色
		///       </summary>
		
		public Color BorderRightColor
		{
			get
			{
				return _BorderRightColor;
			}
			set
			{
				_BorderRightColor = value;
			}
		}

		/// <summary>
		///       边框线颜色
		///       </summary>
		
		public Color BorderBottomColor
		{
			get
			{
				return _BorderBottomColor;
			}
			set
			{
				_BorderBottomColor = value;
			}
		}

		/// <summary>
		///       边框线样式
		///       </summary>
		
		public DashStyle BorderStyle
		{
			get
			{
				return _BorderStyle;
			}
			set
			{
				_BorderStyle = value;
			}
		}

		/// <summary>
		///       边框线宽度
		///       </summary>
		
		public float BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = value;
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		
		public Color BackgroundColor
		{
			get
			{
				return _BackgroundColor;
			}
			set
			{
				_BackgroundColor = value;
			}
		}

		/// <summary>
		///       设置应用范围
		///       </summary>
		
		public StyleApplyRanges ApplyRange
		{
			get
			{
				return _ApplyRange;
			}
			set
			{
				_ApplyRange = value;
			}
		}

		/// <summary>
		///       边框设置样式
		///       </summary>
		
		public BorderSettingsStyle BorderSettingsStyle
		{
			get
			{
				return _BorderSettingsStyle;
			}
			set
			{
				_BorderSettingsStyle = value;
			}
		}

		/// <summary>
		///       设置边框样式
		///       </summary>
		
		public void SetBorderSettingsStyle()
		{
			if (LeftBorder && TopBorder && RightBorder && BottomBorder)
			{
				if (CenterVerticalBorder && MiddleHorizontalBorder)
				{
					BorderSettingsStyle = BorderSettingsStyle.Both;
				}
				else if (!CenterVerticalBorder && !MiddleHorizontalBorder)
				{
					BorderSettingsStyle = BorderSettingsStyle.Rectangle;
				}
				else
				{
					BorderSettingsStyle = BorderSettingsStyle.Custom;
				}
			}
			else if (!LeftBorder && !TopBorder && !RightBorder && !BottomBorder && !CenterVerticalBorder && !MiddleHorizontalBorder)
			{
				BorderSettingsStyle = BorderSettingsStyle.None;
			}
			else
			{
				BorderSettingsStyle = BorderSettingsStyle.Custom;
			}
		}

		/// <summary>
		///       清空设置
		///       </summary>
		
		public void Clear()
		{
			TopBorder = true;
			MiddleHorizontalBorder = true;
			BottomBorder = true;
			LeftBorder = true;
			CenterVerticalBorder = true;
			RightBorder = true;
			BorderBottomColor = Color.Black;
			BorderTopColor = Color.Black;
			BorderRightColor = Color.Black;
			BorderLeftColor = Color.Black;
			BorderWidth = 1f;
			BorderStyle = DashStyle.Solid;
			BackgroundColor = Color.Transparent;
			BorderSettingsStyle = BorderSettingsStyle.None;
			ApplyRange = StyleApplyRanges.Text;
		}

		/// <summary>
		///       读取温度样式信息对象
		///       </summary>
		/// <param name="style">样式信息对象</param>
		
		public void ReadContentStyle(ContentStyle style)
		{
			if (style != null)
			{
				LeftBorder = style.BorderLeft;
				TopBorder = style.BorderTop;
				RightBorder = style.BorderRight;
				BottomBorder = style.BorderBottom;
				BorderBottomColor = style.BorderBottomColor;
				BorderLeftColor = style.BorderLeftColor;
				BorderRightColor = style.BorderRightColor;
				BorderTopColor = style.BorderTopColor;
				BorderWidth = style.BorderWidth;
				BorderStyle = style.BorderStyle;
				BackgroundColor = style.BackgroundColor;
			}
		}

		/// <summary>
		///       设置文档样式信息对象
		///       </summary>
		/// <param name="style">样式信息</param>
		/// <returns>操作是否修改了样式信息内容</returns>
		
		public bool SetContentStyle(ContentStyle style)
		{
			bool result = false;
			if (style.BorderLeft != LeftBorder)
			{
				style.BorderLeft = LeftBorder;
				result = true;
			}
			if (style.BorderTop != TopBorder)
			{
				style.BorderTop = TopBorder;
				result = true;
			}
			if (style.BorderRight != RightBorder)
			{
				style.BorderRight = RightBorder;
				result = true;
			}
			if (style.BorderBottom != BottomBorder)
			{
				style.BorderBottom = BottomBorder;
				result = true;
			}
			if (style.BorderTopColor != BorderTopColor)
			{
				style.BorderTopColor = BorderTopColor;
				result = true;
			}
			if (style.BorderLeftColor != BorderLeftColor)
			{
				style.BorderLeftColor = BorderLeftColor;
				result = true;
			}
			if (style.BorderRightColor != BorderRightColor)
			{
				style.BorderRightColor = BorderRightColor;
				result = true;
			}
			if (style.BorderBottomColor != BorderBottomColor)
			{
				style.BorderBottomColor = BorderBottomColor;
				result = true;
			}
			if (style.BorderStyle != BorderStyle)
			{
				style.BorderStyle = BorderStyle;
				result = true;
			}
			if (style.BorderWidth != BorderWidth)
			{
				style.BorderWidth = BorderWidth;
				result = true;
			}
			if (style.BackgroundColor != BackgroundColor)
			{
				style.BackgroundColor = BackgroundColor;
				result = true;
			}
			return result;
		}
	}
}
