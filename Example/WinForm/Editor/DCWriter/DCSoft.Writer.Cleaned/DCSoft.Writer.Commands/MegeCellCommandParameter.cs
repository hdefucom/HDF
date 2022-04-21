using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       合并单元格命令参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComDefaultInterface(typeof(IMegeCellCommandParameter))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("C4AF866C-5004-4591-8453-DEC639D99923", "656D6F74-BFE0-4C7E-9B9B-829FA3270DBC")]
	
	
	[ComVisible(true)]
	[Guid("C4AF866C-5004-4591-8453-DEC639D99923")]
	public class MegeCellCommandParameter : IMegeCellCommandParameter
	{
		internal const string CLASSID = "C4AF866C-5004-4591-8453-DEC639D99923";

		internal const string CLASSID_Interface = "656D6F74-BFE0-4C7E-9B9B-829FA3270DBC";

		private string _CellID = null;

		private XTextTableCellElement _Cell = null;

		private int _NewRowSpan = 0;

		private int _NewColSpan = 0;

		/// <summary>
		///       要处理的单元格编号
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
		///       要处理的单元格对象
		///       </summary>
		public XTextTableCellElement Cell
		{
			get
			{
				return _Cell;
			}
			set
			{
				_Cell = value;
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
