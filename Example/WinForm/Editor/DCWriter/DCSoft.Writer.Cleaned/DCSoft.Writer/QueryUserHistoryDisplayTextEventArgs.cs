using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询用户历史痕迹显示文本事件参数
	///       </summary>
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IQueryUserHistoryDisplayTextEventArgs))]
	[Guid("61FEFE37-46C2-4465-BF7D-25B204B9F6CF")]
	[ComClass("61FEFE37-46C2-4465-BF7D-25B204B9F6CF", "D8F880B4-FEB7-4E32-ADA2-24D603BD5527")]
	
	[ComVisible(true)]
	public class QueryUserHistoryDisplayTextEventArgs : WriterEventArgs, IQueryUserHistoryDisplayTextEventArgs
	{
		internal new const string CLASSID = "61FEFE37-46C2-4465-BF7D-25B204B9F6CF";

		internal new const string CLASSID_Interface = "D8F880B4-FEB7-4E32-ADA2-24D603BD5527";

		private UserHistoryInfo _Info = null;

		private bool _ForLogicDelete = false;

		private string _Result = null;

		/// <summary>
		///       用户历史记录信息对象
		///       </summary>
		
		public UserHistoryInfo Info => _Info;

		/// <summary>
		///       true:逻辑删除内容 ， false:新增内容
		///       </summary>
		
		public bool ForLogicDelete => _ForLogicDelete;

		/// <summary>
		///       返回的结果
		///       </summary>
		
		public string Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素</param>
		/// <param name="info">用户历史记录</param>
		/// <param name="forLogicDelete">是否为逻辑删除内容</param>
		
		public QueryUserHistoryDisplayTextEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, UserHistoryInfo info, bool forLogicDelete)
			: base(writerControl_0, document, element)
		{
			_Info = info;
			_ForLogicDelete = forLogicDelete;
		}
	}
}
