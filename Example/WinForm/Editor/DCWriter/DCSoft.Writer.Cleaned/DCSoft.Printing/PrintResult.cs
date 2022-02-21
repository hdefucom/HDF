using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印结果信息对象
	///       </summary>
	/// <remarks>
	///       由于打印机的软硬件原因，本类型反映的数据不一定是绝对正确的。在少数情况下
	///       本对象包含的信息可能不合事实。
	///       编制 袁永福
	///       </remarks>
	[ComDefaultInterface(typeof(IPrintResult))]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890080")]
	public class PrintResult : IPrintResult
	{
		private int _TotalTickSpan = 0;

		private int _InitalizeTickSpan = 0;

		private string _Title = null;

		private string _ClientName = null;

		private string _PrinterName = null;

		private string _PaperSourceName = null;

		private int _Copies = 1;

		private DateTime _StartTime = DateTime.MinValue;

		private DateTime _EndTime = DateTime.MinValue;

		private string _Message = null;

		private bool _JumpPrintMode = false;

		private int _Position = 0;

		internal List<int> _SuccessedPageIndexs = new List<int>();

		private PrintResultStates _State = PrintResultStates.None;

		private bool _UserCancel = true;

		private PrintPageResultList _PageInfos = new PrintPageResultList();

		/// <summary>
		///       总的消耗的毫秒数。
		///       </summary>
		public int TotalTickSpan
		{
			get
			{
				return _TotalTickSpan;
			}
			set
			{
				_TotalTickSpan = value;
			}
		}

		/// <summary>
		///       初始化操作消耗的毫秒数。
		///       </summary>
		public int InitalizeTickSpan
		{
			get
			{
				return _InitalizeTickSpan;
			}
			set
			{
				_InitalizeTickSpan = value;
			}
		}

		/// <summary>
		///       文档标题
		///       </summary>
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}

		/// <summary>
		///       客户端名称
		///       </summary>
		[DefaultValue(null)]
		public string ClientName
		{
			get
			{
				return _ClientName;
			}
			set
			{
				_ClientName = value;
			}
		}

		/// <summary>
		///       打印机名称
		///       </summary>
		[DefaultValue(null)]
		public string PrinterName
		{
			get
			{
				return _PrinterName;
			}
			set
			{
				_PrinterName = value;
			}
		}

		/// <summary>
		///       纸张来源
		///       </summary>
		[DefaultValue(null)]
		public string PaperSourceName
		{
			get
			{
				return _PaperSourceName;
			}
			set
			{
				_PaperSourceName = value;
			}
		}

		/// <summary>
		///       打印的份数
		///       </summary>
		[DefaultValue(1)]
		public int Copies
		{
			get
			{
				return _Copies;
			}
			set
			{
				_Copies = value;
			}
		}

		/// <summary>
		///       打印开始时间
		///       </summary>
		public DateTime StartTime
		{
			get
			{
				return _StartTime;
			}
			set
			{
				_StartTime = value;
			}
		}

		/// <summary>
		///       打印操作结束时间
		///       </summary>
		public DateTime EndTime
		{
			get
			{
				return _EndTime;
			}
			set
			{
				_EndTime = value;
			}
		}

		/// <summary>
		///       一些提示信息
		///       </summary>
		[DefaultValue(null)]
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}

		/// <summary>
		///       共打印的页数
		///       </summary>
		public int NumOfPages => _SuccessedPageIndexs.Count;

		/// <summary>
		///       是否处于续打模式
		///       </summary>
		[DefaultValue(false)]
		public bool JumpPrintMode
		{
			get
			{
				return _JumpPrintMode;
			}
			set
			{
				_JumpPrintMode = value;
			}
		}

		/// <summary>
		///       当前打印位置
		///       </summary>
		[DefaultValue(0)]
		public int Position
		{
			get
			{
				return _Position;
			}
			set
			{
				_Position = value;
			}
		}

		/// <summary>
		///       打印成功的页码数组，页码数是从0开始计算的
		///       </summary>
		[XmlIgnore]
		public int[] SuccessedPageIndexs => _SuccessedPageIndexs.ToArray();

		/// <summary>
		///       状态
		///       </summary>
		public PrintResultStates State
		{
			get
			{
				return _State;
			}
			set
			{
				_State = value;
			}
		}

		/// <summary>
		///       打印任务完全成功
		///       </summary>
		public bool CompleteSuccessed => State == PrintResultStates.CompletePrinted;

		/// <summary>
		///       用户取消标记
		///       </summary>
		public bool UserCancel
		{
			get
			{
				return _UserCancel;
			}
			set
			{
				_UserCancel = value;
				if (value)
				{
					State = PrintResultStates.UserCancel;
				}
			}
		}

		/// <summary>
		///       页码信息对象
		///       </summary>
		public PrintPageResultList PageInfos => _PageInfos;

		/// <summary>
		///       显示状态信息对话框
		///       </summary>
		
		public void ShowDialog()
		{
			ShowDialog(null);
		}

		/// <summary>
		///       显示状态信息对话框
		///       </summary>
		/// <param name="owner">
		/// </param>
		
		public void ShowDialog(IWin32Window owner)
		{
			if (UserCancel)
			{
				string caption = PrintingResources.SystemAlert;
				if (owner is Form)
				{
					Form form = owner as Form;
					caption = form.Text;
				}
				MessageBox.Show(owner, PrintingResources.UserCancelled, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				using (dlgPrintResult dlgPrintResult = new dlgPrintResult())
				{
					dlgPrintResult.PrintResult = this;
					dlgPrintResult.ShowDialog(owner);
				}
			}
		}
	}
}
