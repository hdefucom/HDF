using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询扩展文本事件参数
	///       </summary>
	[ComClass("97C93BCE-E2CA-4A4D-A24C-97391F30DCC7", "610763F6-2E8C-4B1C-8528-31B7AE863009")]
	
	[ComVisible(true)]
	
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("97C93BCE-E2CA-4A4D-A24C-97391F30DCC7")]
	[ComDefaultInterface(typeof(IWriterGetAdornTextEventArgs))]
	public class WriterGetAdornTextEventArgs : WriterEventArgs, IWriterGetAdornTextEventArgs
	{
		internal new const string CLASSID = "97C93BCE-E2CA-4A4D-A24C-97391F30DCC7";

		internal new const string CLASSID_Interface = "610763F6-2E8C-4B1C-8528-31B7AE863009";

		private string _AdornText = null;

		/// <summary>
		///       扩展文本
		///       </summary>
		
		public string AdornText
		{
			get
			{
				return _AdornText;
			}
			set
			{
				_AdornText = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="txt">文本</param>
		
		public WriterGetAdornTextEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string string_0)
			: base(writerControl_0, document, element)
		{
			_AdornText = string_0;
		}
	}
}
