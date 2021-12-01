using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       执行拆分单元格命令参数
	///       </summary>
	[ComVisible(true)]
	[Guid("FA8E10DB-F4BC-4EE3-B4A4-9E7D53954124")]
	[ComDefaultInterface(typeof(ISplitCellExtCommandParameter))]
	[ComClass("FA8E10DB-F4BC-4EE3-B4A4-9E7D53954124", "4CF17461-1E5F-4301-B22D-C9B5F7AB48A1")]
	[DCPublishAPI]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	public class SplitCellExtCommandParameter : ISplitCellExtCommandParameter
	{
		internal const string CLASSID = "FA8E10DB-F4BC-4EE3-B4A4-9E7D53954124";

		internal const string CLASSID_Interface = "4CF17461-1E5F-4301-B22D-C9B5F7AB48A1";

		private string _CellID = null;

		private XTextTableCellElement _CellElement = null;

		private int _NewRowSpan = -1;

		private int _NewColSpan = -1;

		/// <summary>
		///       指定的单元格编号
		///       </summary>
		public string CellID
		{
			get
			{
				return _CellID;
			}
			set
			{
				_CellID = value;
			}
		}

		/// <summary>
		///       指定的单元格对象
		///       </summary>
		public XTextTableCellElement CellElement
		{
			get
			{
				return _CellElement;
			}
			set
			{
				_CellElement = value;
			}
		}

		/// <summary>
		///       新的跨行数
		///       </summary>
		public int NewRowSpan
		{
			get
			{
				return _NewRowSpan;
			}
			set
			{
				_NewRowSpan = value;
			}
		}

		/// <summary>
		///       新的跨列数
		///       </summary>
		public int NewColSpan
		{
			get
			{
				return _NewColSpan;
			}
			set
			{
				_NewColSpan = value;
			}
		}
	}
}
