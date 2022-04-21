using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       用户界面键盘输入的字符串之前的事件参数
	///       </summary>
	
	[ComClass("B1B4A42B-B0EE-438C-B380-65DFD9937A07", "E2FBA882-B5E9-4B78-BFD5-5278268C5F04")]
	[Guid("B1B4A42B-B0EE-438C-B380-65DFD9937A07")]
	[ComVisible(true)]
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IWriterBeforeUIKeyboardInputStringEventArgs))]
	public class WriterBeforeUIKeyboardInputStringEventArgs : WriterEventArgs, IWriterBeforeUIKeyboardInputStringEventArgs
	{
		internal new const string CLASSID = "B1B4A42B-B0EE-438C-B380-65DFD9937A07";

		internal new const string CLASSID_Interface = "E2FBA882-B5E9-4B78-BFD5-5278268C5F04";

		private string _InputString = null;

		private string _OutputString = null;

		private bool _Cancel = false;

		/// <summary>
		///       输入的字符串
		///       </summary>
		
		public string InputString => _InputString;

		/// <summary>
		///       输出的字符串
		///       </summary>
		
		public string OutputString
		{
			get
			{
				return _OutputString;
			}
			set
			{
				_OutputString = value;
			}
		}

		/// <summary>
		///       取消输入字符串操作标记
		///       </summary>
		
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="inputString">原始输入的字符串对象</param>
		/// <param name="outputString">预计输出的字符串对象</param>
		
		public WriterBeforeUIKeyboardInputStringEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string inputString, string outputString)
			: base(writerControl_0, document, element)
		{
			_InputString = inputString;
			_OutputString = outputString;
		}
	}
}
