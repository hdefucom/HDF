using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       插入字符串的命令参数对象
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[ComClass("2B1E25B5-25B4-4DC5-8E4F-1B460A22FE72", "1AEBE7BB-F83D-4CCF-B698-D6067332E1B5")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IInsertStringCommandParameter))]
	
	
	[Guid("2B1E25B5-25B4-4DC5-8E4F-1B460A22FE72")]
	public class InsertStringCommandParameter : IInsertStringCommandParameter
	{
		internal const string CLASSID = "2B1E25B5-25B4-4DC5-8E4F-1B460A22FE72";

		internal const string CLASSID_Interface = "1AEBE7BB-F83D-4CCF-B698-D6067332E1B5";

		private string _Text = null;

		private DocumentContentStyle _Style = null;

		private DocumentContentStyle _ParagraphStyle = null;

		/// <summary>
		///       要插入的文本
		///       </summary>
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		/// <summary>
		///       文本样式
		///       </summary>
		public DocumentContentStyle Style
		{
			get
			{
				return _Style;
			}
			set
			{
				_Style = value;
			}
		}

		/// <summary>
		///       段落样式
		///       </summary>
		public DocumentContentStyle ParagraphStyle
		{
			get
			{
				return _ParagraphStyle;
			}
			set
			{
				_ParagraphStyle = value;
			}
		}
	}
}
