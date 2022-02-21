using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印任务对象
	///       </summary>
	
	[ComVisible(false)]
	public class PrintJob
	{
		private int intJobId = 0;

		private string strPrinterName = null;

		private string strNativePrinterName = null;

		private string strMachineName = null;

		private string strUserName = null;

		private string strDocument = null;

		private string strDatatype = null;

		private string strStatusText = null;

		private GEnum26 intStatus = GEnum26.flag_0;

		private int intPriority = 0;

		private int intPosition = 0;

		private int intTotalPages = 0;

		private int intPagesPrinted = 0;

		private DateTime dtmSubmitted = DateTime.MinValue;

		/// <summary>
		///       任务编号
		///       </summary>
		public int JobId
		{
			get
			{
				return intJobId;
			}
			set
			{
				intJobId = value;
			}
		}

		/// <summary>
		///       打印机名称
		///       </summary>
		public string PrinterName
		{
			get
			{
				return strPrinterName;
			}
			set
			{
				strPrinterName = value;
			}
		}

		/// <summary>
		///       原始的打印机名称
		///       </summary>
		public string NativePrinterName
		{
			get
			{
				return strNativePrinterName;
			}
			set
			{
				strNativePrinterName = value;
			}
		}

		/// <summary>
		///       机器名称
		///       </summary>
		public string MachineName
		{
			get
			{
				return strMachineName;
			}
			set
			{
				strMachineName = value;
			}
		}

		/// <summary>
		///       用户名
		///       </summary>
		public string UserName
		{
			get
			{
				return strUserName;
			}
			set
			{
				strUserName = value;
			}
		}

		/// <summary>
		///       文档标题
		///       </summary>
		public string Document
		{
			get
			{
				return strDocument;
			}
			set
			{
				strDocument = value;
			}
		}

		/// <summary>
		///       数据类型
		///       </summary>
		public string Datatype
		{
			get
			{
				return strDatatype;
			}
			set
			{
				strDatatype = value;
			}
		}

		/// <summary>
		///       状态文本
		///       </summary>
		public string StatusText
		{
			get
			{
				return strStatusText;
			}
			set
			{
				strStatusText = value;
			}
		}

		/// <summary>
		///       任务状态
		///       </summary>
		public GEnum26 Status
		{
			get
			{
				return intStatus;
			}
			set
			{
				intStatus = value;
			}
		}

		/// <summary>
		///       优先级
		///       </summary>
		public int Priority
		{
			get
			{
				return intPriority;
			}
			set
			{
				intPriority = value;
			}
		}

		/// <summary>
		///       任务位置
		///       </summary>
		public int Position
		{
			get
			{
				return intPosition;
			}
			set
			{
				intPosition = value;
			}
		}

		/// <summary>
		///       总页数
		///       </summary>
		public int TotalPages
		{
			get
			{
				return intTotalPages;
			}
			set
			{
				intTotalPages = value;
			}
		}

		/// <summary>
		///       打印页数
		///       </summary>
		public int PagesPrinted
		{
			get
			{
				return intPagesPrinted;
			}
			set
			{
				intPagesPrinted = value;
			}
		}

		/// <summary>
		///       提交时间
		///       </summary>
		public DateTime Submitted
		{
			get
			{
				return dtmSubmitted;
			}
			set
			{
				dtmSubmitted = value;
			}
		}

		/// <summary>
		///       是否正在执行任务
		///       </summary>
		public bool IsRunning
		{
			get
			{
				if (!GClass158.smethod_1(this, bool_0: false))
				{
					return false;
				}
				if (Status == GEnum26.flag_9)
				{
					return false;
				}
				if (Status == GEnum26.flag_8)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       是否处于成功完成任务的状态
		///       </summary>
		public bool IsSuccessStatus
		{
			get
			{
				if ((Status & GEnum26.flag_2) == GEnum26.flag_2)
				{
					return false;
				}
				if ((Status & GEnum26.flag_3) == GEnum26.flag_3)
				{
					return false;
				}
				if ((Status & GEnum26.flag_9) == GEnum26.flag_9)
				{
					return false;
				}
				if ((Status & GEnum26.flag_6) == GEnum26.flag_6)
				{
					return false;
				}
				if ((Status & GEnum26.flag_5) == GEnum26.flag_5 || (Status & GEnum26.flag_8) == GEnum26.flag_8)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       刷新状态
		///       </summary>
		public void Refresh()
		{
			GClass158.smethod_1(this, bool_0: true);
		}

		/// <summary>
		///       取消任务
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool Cancel()
		{
			return GClass158.smethod_0(this, GEnum27.const_2, bool_0: false);
		}

		/// <summary>
		///       暂停任务
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool Pause()
		{
			return GClass158.smethod_0(this, GEnum27.const_0, bool_0: false);
		}

		/// <summary>
		///       重新启动打印任务
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool Restart()
		{
			return GClass158.smethod_0(this, GEnum27.const_3, bool_0: false);
		}

		/// <summary>
		///       恢复打印任务
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool Resume()
		{
			return GClass158.smethod_0(this, GEnum27.const_1, bool_0: false);
		}

		/// <summary>
		///       删除任务
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool Delete()
		{
			return GClass158.smethod_0(this, GEnum27.const_4, bool_0: false);
		}

		/// <summary>
		///       发送到镜像打印端口
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool SendToPrinter()
		{
			return GClass158.smethod_0(this, GEnum27.const_5, bool_0: false);
		}

		/// <summary>
		/// </summary>
		/// <returns>操作是否成功</returns>
		public bool LastPageEjected()
		{
			return GClass158.smethod_0(this, GEnum27.const_6, bool_0: false);
		}

		/// <summary>
		///       等待任务完成
		///       </summary>
		/// <param name="callBack">
		/// </param>
		/// <returns>
		/// </returns>
		public bool WaitForExit(CancelEventHandler callBack)
		{
			while (IsRunning)
			{
				if (callBack != null)
				{
					CancelEventArgs cancelEventArgs = new CancelEventArgs();
					cancelEventArgs.Cancel = false;
					callBack(this, cancelEventArgs);
					if (cancelEventArgs.Cancel)
					{
						Cancel();
						break;
					}
				}
				Thread.Sleep(100);
			}
			if ((Status & GEnum26.flag_2) == GEnum26.flag_2)
			{
				return false;
			}
			if ((Status & GEnum26.flag_3) == GEnum26.flag_3)
			{
				return false;
			}
			if ((Status & GEnum26.flag_9) == GEnum26.flag_9)
			{
				return false;
			}
			if ((Status & GEnum26.flag_6) == GEnum26.flag_6)
			{
				return false;
			}
			if ((Status & GEnum26.flag_5) == GEnum26.flag_5 || (Status & GEnum26.flag_8) == GEnum26.flag_8)
			{
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return PrinterName + "#" + Document + "#" + Status;
		}
	}
}
