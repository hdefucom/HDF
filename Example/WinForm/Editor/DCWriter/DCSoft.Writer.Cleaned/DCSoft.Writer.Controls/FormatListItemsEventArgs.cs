using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       获得列表项目文本的事件参数
	///       </summary>
	[ComVisible(true)]
	[ComClass("25A73252-2775-4BDB-9124-712D34C50879", "0BE89845-454A-4680-B841-F3847FD44DFD")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("25A73252-2775-4BDB-9124-712D34C50879")]
	[ComDefaultInterface(typeof(IFormatListItemsEventArgs))]
	
	
	public class FormatListItemsEventArgs : EventArgs, IFormatListItemsEventArgs
	{
		internal const string CLASSID = "25A73252-2775-4BDB-9124-712D34C50879";

		internal const string CLASSID_Interface = "0BE89845-454A-4680-B841-F3847FD44DFD";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private string _Separator = ",";

		private string _FormatString = null;

		private string[] _SelectedItems = null;

		private string[] _UnselectedItems = null;

		private string _Result = null;

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
		///       被选中的列表
		///       </summary>
		public string[] SelectedItems => _SelectedItems;

		/// <summary>
		///       没有被选中的列表
		///       </summary>
		public string[] UnselectedItems => _UnselectedItems;

		/// <summary>
		///       计算结果
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
		/// <param name="ctl">
		/// </param>
		/// <param name="formatString">
		/// </param>
		/// <param name="document">
		/// </param>
		/// <param name="element">
		/// </param>
		/// <param name="selectedItems">
		/// </param>
		/// <param name="unSelectedItems">
		/// </param>
		/// <param name="separator">指定的分隔字符</param>
		public FormatListItemsEventArgs(WriterControl writerControl_0, string formatString, XTextDocument document, XTextElement element, string[] selectedItems, string[] unSelectedItems, string separator)
		{
			_WriterControl = writerControl_0;
			_FormatString = formatString;
			_Document = document;
			_Element = element;
			_SelectedItems = selectedItems;
			_UnselectedItems = unSelectedItems;
			_Separator = separator;
		}
	}
}
