using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       表格命令的指定参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(ITableCommandArgs))]
	
	
	[Guid("5152B8CA-C29B-4609-A2EA-79BBE8B99667")]
	[ComClass("5152B8CA-C29B-4609-A2EA-79BBE8B99667", "EC482230-315B-42F4-9ABF-58A573F70AF8")]
	[ComVisible(true)]
	public class TableCommandArgs : ITableCommandArgs
	{
		internal const string CLASSID = "5152B8CA-C29B-4609-A2EA-79BBE8B99667";

		internal const string CLASSID_Interface = "EC482230-315B-42F4-9ABF-58A573F70AF8";

		private string _TableID = null;

		private XTextTableElement _TableElement = null;

		private int _RowIndex = -1;

		private int _ColIndex = -1;

		private int _RowsCount = 1;

		private int _ColsCount = 1;

		private bool _Result = false;

		/// <summary>
		///       要操作的表格编号
		///       </summary>
		public string TableID
		{
			get
			{
				return _TableID;
			}
			set
			{
				_TableID = value;
			}
		}

		/// <summary>
		///       要操作的表格对象
		///       </summary>
		public XTextTableElement TableElement
		{
			get
			{
				return _TableElement;
			}
			set
			{
				_TableElement = value;
			}
		}

		/// <summary>
		///       指定的行号
		///       </summary>
		public int RowIndex
		{
			get
			{
				return _RowIndex;
			}
			set
			{
				_RowIndex = value;
			}
		}

		/// <summary>
		///       指定的列号
		///       </summary>
		public int ColIndex
		{
			get
			{
				return _ColIndex;
			}
			set
			{
				_ColIndex = value;
			}
		}

		/// <summary>
		///       新增或删除的行数
		///       </summary>
		public int RowsCount
		{
			get
			{
				return _RowsCount;
			}
			set
			{
				_RowsCount = value;
			}
		}

		/// <summary>
		///       新增或删除的列数
		///       </summary>
		public int ColsCount
		{
			get
			{
				return _ColsCount;
			}
			set
			{
				_ColsCount = value;
			}
		}

		/// <summary>
		///       操作执行结果
		///       </summary>
		public bool Result
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
	}
}
