using DCSoft.Common;
using DCSoft.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档状态
	///       </summary>
	[ComVisible(false)]
	[DCPublishAPI]
	[DocumentComment]
	public class DocumentStates
	{
		private JumpPrintMode _JumpPrintModeForCurrentPage = JumpPrintMode.Disable;

		private bool _Layouted = false;

		private DocumentRenderMode _RenderMode = DocumentRenderMode.Paint;

		private bool _Printing = false;

		private bool _PrintPreviewing = false;

		private bool _ExecuteingGlobalLayout = false;

		private bool _ExecutingUndo = false;

		private bool _ExecutingRedo = false;

		private bool _GenerateLongBmp = false;

		private bool _GenerateBmp = false;

		/// <summary>
		///       当前页使用的续打方式
		///       </summary>
		[DCPublishAPI]
		public JumpPrintMode JumpPrintModeForCurrentPage
		{
			get
			{
				return _JumpPrintModeForCurrentPage;
			}
			set
			{
				_JumpPrintModeForCurrentPage = value;
			}
		}

		/// <summary>
		///       文档内容已经经过排版了
		///       </summary>
		[DCPublishAPI]
		public bool Layouted
		{
			get
			{
				return _Layouted;
			}
			set
			{
				_Layouted = value;
			}
		}

		/// <summary>
		///       文档当前使用的呈现模式
		///       </summary>
		[DCPublishAPI]
		public DocumentRenderMode RenderMode
		{
			get
			{
				return _RenderMode;
			}
			set
			{
				_RenderMode = value;
			}
		}

		/// <summary>
		///       文档正在打印中
		///       </summary>
		[DCPublishAPI]
		public bool Printing
		{
			get
			{
				return _Printing;
			}
			set
			{
				_Printing = value;
			}
		}

		/// <summary>
		///       文档正在生成打印预览内容
		///       </summary>
		[DCPublishAPI]
		public bool PrintPreviewing
		{
			get
			{
				return _PrintPreviewing;
			}
			set
			{
				_PrintPreviewing = value;
			}
		}

		/// <summary>
		///       正在执行全局文档内容布局
		///       </summary>
		[DCPublishAPI]
		public bool ExecuteingGlobalLayout
		{
			get
			{
				return _ExecuteingGlobalLayout;
			}
			set
			{
				_ExecuteingGlobalLayout = value;
			}
		}

		/// <summary>
		///       正在执行UNDO操作
		///       </summary>
		[DCPublishAPI]
		public bool ExecutingUndo
		{
			get
			{
				return _ExecutingUndo;
			}
			set
			{
				_ExecutingUndo = value;
			}
		}

		/// <summary>
		///       正在执行REDO操作
		///       </summary>
		[DCPublishAPI]
		public bool ExecutingRedo
		{
			get
			{
				return _ExecutingRedo;
			}
			set
			{
				_ExecutingRedo = value;
			}
		}

		/// <summary>
		///       正在生成长图片
		///       </summary>
		[DCPublishAPI]
		public bool GenerateLongBmp
		{
			get
			{
				return _GenerateLongBmp;
			}
			set
			{
				_GenerateLongBmp = value;
			}
		}

		/// <summary>
		///       正在生成文档内容图片
		///       </summary>
		[DCPublishAPI]
		public bool GenerateBmp
		{
			get
			{
				return _GenerateBmp;
			}
			set
			{
				_GenerateBmp = value;
			}
		}

		/// <summary>
		///       文档状态
		///       </summary>
		[DCInternal]
		public DocumentStates()
		{
		}
	}
}
