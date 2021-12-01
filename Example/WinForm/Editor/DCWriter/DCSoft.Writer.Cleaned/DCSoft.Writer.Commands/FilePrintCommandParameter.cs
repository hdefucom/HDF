using DCSoft.Common;
using DCSoft.Printing;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       打印功能命令参数
	///       </summary>
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IFilePrintCommandParameter))]
	[Guid("EEB8F948-7465-4EE8-BA0E-90DBCA2A89E7")]
	[ComClass("EEB8F948-7465-4EE8-BA0E-90DBCA2A89E7", "4840FBE8-F48F-4D45-8ED9-E9915FCE0D9D")]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	public class FilePrintCommandParameter : IFilePrintCommandParameter
	{
		internal const string CLASSID = "EEB8F948-7465-4EE8-BA0E-90DBCA2A89E7";

		internal const string CLASSID_Interface = "4840FBE8-F48F-4D45-8ED9-E9915FCE0D9D";

		private bool _DrawFirstHeaderFooterWhenJumpPrintMode = false;

		private bool _CleanPrintMode = false;

		private bool _ManualDuplex = false;

		private JumpPrintInfo _JumpPrintInfo = null;

		private List<int> _SpecifyPageIndexs = null;

		private int _SpecifyCopies = -1;

		private string _SpecifyPrinterName = null;

		/// <summary>
		///       在续打模式先是否打印第一页的页眉页脚
		///       </summary>
		[DefaultValue(false)]
		public bool DrawFirstHeaderFooterWhenJumpPrintMode
		{
			get
			{
				return _DrawFirstHeaderFooterWhenJumpPrintMode;
			}
			set
			{
				_DrawFirstHeaderFooterWhenJumpPrintMode = value;
			}
		}

		/// <summary>
		///       清洁打印模式
		///       </summary>
		public bool CleanPrintMode
		{
			get
			{
				return _CleanPrintMode;
			}
			set
			{
				_CleanPrintMode = value;
			}
		}

		/// <summary>
		///       手动双面打印
		///       </summary>
		[DefaultValue(false)]
		public bool ManualDuplex
		{
			get
			{
				return _ManualDuplex;
			}
			set
			{
				_ManualDuplex = value;
			}
		}

		/// <summary>
		///       续打信息对象
		///       </summary>
		public JumpPrintInfo JumpPrintInfo
		{
			get
			{
				return _JumpPrintInfo;
			}
			set
			{
				_JumpPrintInfo = value;
			}
		}

		/// <summary>
		///       从0开始计算的指定打印的页码数
		///       </summary>
		[ComVisible(false)]
		public List<int> SpecifyPageIndexs
		{
			get
			{
				return _SpecifyPageIndexs;
			}
			set
			{
				_SpecifyPageIndexs = value;
			}
		}

		/// <summary>
		///       强制指定的打印份数,小于等于0则不强制指定
		///       </summary>
		[ComVisible(true)]
		public int SpecifyCopies
		{
			get
			{
				return _SpecifyCopies;
			}
			set
			{
				_SpecifyCopies = value;
			}
		}

		/// <summary>
		///       指定的打印机名称
		///       </summary>
		public string SpecifyPrinterName
		{
			get
			{
				return _SpecifyPrinterName;
			}
			set
			{
				_SpecifyPrinterName = value;
			}
		}

		/// <summary>
		///       添加指定的从0开始计算的页码
		///       </summary>
		/// <param name="pageIndex">页码</param>
		[ComVisible(true)]
		public void AddSpecifyPageIndex(int pageIndex)
		{
			if (_SpecifyPageIndexs == null)
			{
				_SpecifyPageIndexs = new List<int>();
			}
			_SpecifyPageIndexs.Add(pageIndex);
		}

		/// <summary>
		///       设置指定的页码数
		///       </summary>
		/// <param name="indexs">页码数组成的字符串，比如“1,3,5,7,9”。</param>
		public void SetSpecifyPageIndexs(string indexs)
		{
			if (string.IsNullOrEmpty(indexs))
			{
				return;
			}
			List<int> list = new List<int>();
			string[] array = indexs.Split(',');
			foreach (string s in array)
			{
				int result = 0;
				if (int.TryParse(s, out result))
				{
					list.Add(result);
				}
			}
			_SpecifyPageIndexs = list;
		}
	}
}
