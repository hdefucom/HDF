using DCSoft.Common;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       打印预览命令参数
	///       </summary>
	
	[DocumentComment]
	public class FilePrintPreviewCommandParameter
	{
		private bool _AllowUserChangePrintArea = true;

		private bool _Maximized = false;

		private bool _CleanPreviewMode = false;

		private PrintPreviewZoomRate _ZoomRate = PrintPreviewZoomRate.Zoom100;

		private bool _AutoTurnToLastPage = false;

		private bool _IsTurnToPage = false;

		private int _TurnToPage = 0;

		/// <summary>
		///       选择续打后在打印预览时是否允许再进行续打选择
		///       </summary>
		[DefaultValue(true)]
		public bool AllowUserChangePrintArea
		{
			get
			{
				return _AllowUserChangePrintArea;
			}
			set
			{
				_AllowUserChangePrintArea = value;
			}
		}

		/// <summary>
		///       窗体最大化
		///       </summary>
		[DefaultValue(false)]
		public bool Maximized
		{
			get
			{
				return _Maximized;
			}
			set
			{
				_Maximized = value;
			}
		}

		/// <summary>
		///       获取或设置是否使用清洁预览模式
		///       </summary>
		[DefaultValue(false)]
		public bool CleanPreviewMode
		{
			get
			{
				return _CleanPreviewMode;
			}
			set
			{
				_CleanPreviewMode = value;
			}
		}

		/// <summary>
		///       缩放比率
		///       </summary>
		[DefaultValue(PrintPreviewZoomRate.Zoom100)]
		public PrintPreviewZoomRate ZoomRate
		{
			get
			{
				return _ZoomRate;
			}
			set
			{
				_ZoomRate = value;
			}
		}

		/// <summary>
		///       自动翻转到最后一页
		///       </summary>
		[DefaultValue(false)]
		public bool AutoTurnToLastPage
		{
			get
			{
				return _AutoTurnToLastPage;
			}
			set
			{
				_AutoTurnToLastPage = value;
			}
		}

		/// <summary>
		///       是否翻转到指定页面 
		///       </summary>
		[DefaultValue(false)]
		[ComVisible(true)]
		public bool IsTurnToPage
		{
			get
			{
				return _IsTurnToPage;
			}
			set
			{
				_IsTurnToPage = value;
			}
		}

		/// <summary>
		///       翻转到指定页面
		///       </summary>
		[DefaultValue(0)]
		[ComVisible(true)]
		public int TurnToPage
		{
			get
			{
				return _TurnToPage;
			}
			set
			{
				_TurnToPage = value;
			}
		}
	}
}
