using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       查询知识库列表的事件参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("FA368EE3-71FC-439F-AE18-0D99E7CA8783", "12D0A287-D6D3-4C7F-94B9-A9D8405FE2B3")]
	[ComVisible(true)]
	
	[ComDefaultInterface(typeof(IQueryKBEntriesEventArgs))]
	[Guid("FA368EE3-71FC-439F-AE18-0D99E7CA8783")]
	public class QueryKBEntriesEventArgs : EventArgs, IQueryKBEntriesEventArgs
	{
		internal const string CLASSID = "FA368EE3-71FC-439F-AE18-0D99E7CA8783";

		internal const string CLASSID_Interface = "12D0A287-D6D3-4C7F-94B9-A9D8405FE2B3";

		private WriterControl _WriterControl;

		private XTextDocument _Document;

		private string _SpellCode;

		private KBEntryList _Result;

		private bool _Cancel;

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document => _Document;

		/// <summary>
		///       拼音码
		///       </summary>
		
		public string SpellCode => _SpellCode;

		/// <summary>
		///       查询结果
		///       </summary>
		
		public KBEntryList Result
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
		///       取消相关操作
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
		/// <param name="ctl">
		/// </param>
		/// <param name="spellCode">
		/// </param>
		
		public QueryKBEntriesEventArgs(WriterControl writerControl_0, string spellCode)
		{
			int num = 14;
			_WriterControl = null;
			_Document = null;
			_SpellCode = null;
			_Result = null;
			_Cancel = false;
			
			if (writerControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			_WriterControl = writerControl_0;
			_Document = writerControl_0.Document;
			_SpellCode = spellCode;
		}
	}
}
