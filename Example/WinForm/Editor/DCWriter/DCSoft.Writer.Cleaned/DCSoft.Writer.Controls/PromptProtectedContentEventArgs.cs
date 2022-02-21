using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       提示内容保护事件参数
	///       </summary>
	[Guid("0ED2A2B5-189C-4CCC-A5F1-93D333254B0A")]
	
	[DocumentComment]
	[ComDefaultInterface(typeof(IPromptProtectedContentEventArgs))]
	[ComClass("0ED2A2B5-189C-4CCC-A5F1-93D333254B0A", "E1D27491-21C8-44EF-B44D-3DFE63E3CBEB")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public class PromptProtectedContentEventArgs : WriterEventArgs, IPromptProtectedContentEventArgs
	{
		internal new const string CLASSID = "0ED2A2B5-189C-4CCC-A5F1-93D333254B0A";

		internal new const string CLASSID_Interface = "E1D27491-21C8-44EF-B44D-3DFE63E3CBEB";

		private string _Message = null;

		private PromptProtectedContentMode _PromptMode = PromptProtectedContentMode.Details;

		private bool _Handled = false;

		/// <summary>
		///       提示信息
		///       </summary>
		public string Message => _Message;

		/// <summary>
		///       提示模式
		///       </summary>
		public PromptProtectedContentMode PromptMode => _PromptMode;

		/// <summary>
		///       事件被处理了
		///       </summary>
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="doc">
		/// </param>
		/// <param name="ele">
		/// </param>
		/// <param name="msg">
		/// </param>
		/// <param name="mode">模式</param>
		public PromptProtectedContentEventArgs(WriterControl writerControl_0, XTextDocument xtextDocument_0, XTextElement xtextElement_0, string string_0, PromptProtectedContentMode mode)
			: base(writerControl_0, xtextDocument_0, xtextElement_0)
		{
			_Message = string_0;
			_PromptMode = mode;
		}
	}
}
