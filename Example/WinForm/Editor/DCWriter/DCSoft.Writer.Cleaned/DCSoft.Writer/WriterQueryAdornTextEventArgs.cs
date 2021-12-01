using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器查询文档元素扩展标记文本事件参数类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComClass("FAA96BC5-3D0D-4352-81DB-C43204BAA58E", "55C507A8-806D-4930-BB2B-FE14C20E0765")]
	[ComDefaultInterface(typeof(IWriterQueryAdornTextEventArgs))]
	[DCPublishAPI]
	[DocumentComment]
	[Guid("FAA96BC5-3D0D-4352-81DB-C43204BAA58E")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	public class WriterQueryAdornTextEventArgs : WriterEventArgs, IWriterQueryAdornTextEventArgs
	{
		internal new const string CLASSID = "FAA96BC5-3D0D-4352-81DB-C43204BAA58E";

		internal new const string CLASSID_Interface = "55C507A8-806D-4930-BB2B-FE14C20E0765";

		private string _AdornText = null;

		/// <summary>
		///       扩展标记文字
		///       </summary>
		[DCPublishAPI]
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
		/// <param name="ctl">
		/// </param>
		/// <param name="document">
		/// </param>
		/// <param name="element">
		/// </param>
		[DCInternal]
		public WriterQueryAdornTextEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element)
			: base(writerControl_0, document, element)
		{
		}
	}
}
