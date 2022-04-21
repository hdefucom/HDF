using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       解释被选中项目的事件参数
	///       </summary>
	[ComClass("C97D2F61-FAA0-4677-9C1B-275BB4A21EC5", "63AD7DC7-897B-420C-A8D9-71DF8B01AD6D")]
	[ComDefaultInterface(typeof(IParseSelectedItemsEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("C97D2F61-FAA0-4677-9C1B-275BB4A21EC5")]
	[ComVisible(true)]
	
	
	public class ParseSelectedItemsEventArgs : EventArgs, IParseSelectedItemsEventArgs
	{
		internal const string CLASSID = "C97D2F61-FAA0-4677-9C1B-275BB4A21EC5";

		internal const string CLASSID_Interface = "63AD7DC7-897B-420C-A8D9-71DF8B01AD6D";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private string _Separator = ",";

		private string _FormatString = null;

		private string _Text = null;

		private string[] _Items = null;

		private string[] _Result = null;

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document => _Document;

		/// <summary>
		///       相关的文档元素对象
		///       </summary>
		public XTextElement Element => _Element;

		/// <summary>
		///       各个项目之间的分隔字符
		///       </summary>
		public string Separator => _Separator;

		/// <summary>
		///       各个项目之间的分隔字符
		///       </summary>
		public char SeparatorChar
		{
			get
			{
				if (_Separator != null && _Separator.Length > 0)
				{
					return _Separator[0];
				}
				return '\0';
			}
		}

		/// <summary>
		///       格式化字符串
		///       </summary>
		public string FormatString => _FormatString;

		/// <summary>
		///       文本
		///       </summary>
		public string Text => _Text;

		/// <summary>
		///       项目列表
		///       </summary>
		public string[] Items => _Items;

		/// <summary>
		///       计算结果
		///       </summary>
		public string[] Result
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
		/// <param name="ctl">
		/// </param>
		/// <param name="formatString">
		/// </param>
		/// <param name="document">
		/// </param>
		/// <param name="element">
		/// </param>
		/// <param name="text">
		/// </param>
		/// <param name="items">
		/// </param>
		/// <param name="separator">
		/// </param>
		public ParseSelectedItemsEventArgs(WriterControl writerControl_0, string formatString, XTextDocument document, XTextElement element, string text, string[] items, string separator)
		{
			_WriterControl = writerControl_0;
			_FormatString = formatString;
			_Document = document;
			_Element = element;
			_Text = text;
			_Items = items;
			_Separator = separator;
			if (document == null && element != null)
			{
				document = element.OwnerDocument;
			}
		}
	}
}
