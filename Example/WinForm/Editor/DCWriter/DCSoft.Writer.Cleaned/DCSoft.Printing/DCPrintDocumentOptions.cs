using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印选项
	///       </summary>
	
	[ComDefaultInterface(typeof(IDCPrintDocumentOptions))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("4557EA58-A58B-4DE4-9E20-22BB58E95777")]
	[DocumentComment]
	public class DCPrintDocumentOptions : IDCPrintDocumentOptions
	{
		private bool _DisableRefreshDocumentLayout = false;

		private DCPrintMode _PrintMode = DCPrintMode.Normal;

		private bool _PreparePrintJob = false;

		private bool _AsyncPrint = true;

		private float _BodyOffsetY = 0f;

		private bool _CleanMode = false;

		private JumpPrintInfo _JumpPrint = null;

		private BoundsSelectionPrintInfo _BoundsSelection = null;

		private int _GlobalPageIndexFix = 0;

		private bool _AutoFitPageSize = false;

		private bool _ShowDebugMessage = false;

		private PrintRange _PrintRange = PrintRange.AllPages;

		private int _FromPage = 0;

		private int _ToPage = 0;

		private string _PrinterName = null;

		private string _PaperSourceName = null;

		private List<int> _SpecifyPageIndexs = null;

		private int _SpecifyCopies = -1;

		private bool _DrawFirstHeaderFooterWhenJumpPrintMode = false;

		private bool _ManualDuplex = false;

		/// <summary>
		///       手动双面打印标记
		///       </summary>
		private int _ManualDuplexFlag = 0;

		/// <summary>
		///       禁止刷新文档内容排版
		///       </summary>
		public bool DisableRefreshDocumentLayout
		{
			get
			{
				return _DisableRefreshDocumentLayout;
			}
			set
			{
				_DisableRefreshDocumentLayout = value;
			}
		}

		/// <summary>
		///       打印模式
		///       </summary>
		[DefaultValue(DCPrintMode.Normal)]
		public DCPrintMode PrintMode
		{
			get
			{
				return _PrintMode;
			}
			set
			{
				_PrintMode = value;
			}
		}

		/// <summary>
		///       打印文档时是否准备好打印任务对象
		///       </summary>
		[DefaultValue(false)]
		public bool PreparePrintJob
		{
			get
			{
				return _PreparePrintJob;
			}
			set
			{
				_PreparePrintJob = value;
			}
		}

		/// <summary>
		///       异步打印
		///       </summary>
		/// <remarks>
		///       本属性默认为true，执行异步打印，程序向系统提交打印任务后立即返回；
		///       若该属性为false，则执行同步打印，程序向系统提交打印任务后等待打印任务完全完成后才返回。
		///       </remarks>
		[DefaultValue(true)]
		public bool AsyncPrint
		{
			get
			{
				return _AsyncPrint;
			}
			set
			{
				_AsyncPrint = value;
			}
		}

		/// <summary>
		///       正文Y方向偏移量
		///       </summary>
		public float BodyOffsetY
		{
			get
			{
				return _BodyOffsetY;
			}
			set
			{
				_BodyOffsetY = value;
			}
		}

		/// <summary>
		///       整洁打印模式
		///       </summary>
		public bool CleanMode
		{
			get
			{
				return _CleanMode;
			}
			set
			{
				_CleanMode = value;
			}
		}

		/// <summary>
		///       续打信息
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public JumpPrintInfo JumpPrint
		{
			get
			{
				if (_JumpPrint == null)
				{
					_JumpPrint = new JumpPrintInfo();
				}
				return _JumpPrint;
			}
			set
			{
				_JumpPrint = value;
			}
		}

		/// <summary>
		///       区域选择打印信息
		///       </summary>
		public BoundsSelectionPrintInfo BoundsSelection
		{
			get
			{
				if (_BoundsSelection == null)
				{
					_BoundsSelection = new BoundsSelectionPrintInfo();
				}
				return _BoundsSelection;
			}
			set
			{
				_BoundsSelection = value;
			}
		}

		/// <summary>
		///       是否处于区域选择显示模式
		///       </summary>
		public bool HasBoundSelection => _BoundsSelection != null && _BoundsSelection.Enable && _BoundsSelection.Count > 0;

		/// <summary>
		///       全局页码序号修正量
		///       </summary>
		[DefaultValue(0)]
		public int GlobalPageIndexFix
		{
			get
			{
				return _GlobalPageIndexFix;
			}
			set
			{
				_GlobalPageIndexFix = value;
			}
		}

		/// <summary>
		///       自动适应纸张大小
		///       </summary>
		[DefaultValue(false)]
		public bool AutoFitPageSize
		{
			get
			{
				return _AutoFitPageSize;
			}
			set
			{
				_AutoFitPageSize = value;
			}
		}

		/// <summary>
		///       显示调试信息
		///       </summary>
		public bool ShowDebugMessage
		{
			get
			{
				return _ShowDebugMessage;
			}
			set
			{
				_ShowDebugMessage = value;
			}
		}

		/// <summary>
		///       打印区域
		///       </summary>
		public PrintRange PrintRange
		{
			get
			{
				return _PrintRange;
			}
			set
			{
				_PrintRange = value;
			}
		}

		/// <summary>
		///       获取或设置要打印的第一页的从0开始计算的页码。 
		///       </summary>
		public int FromPage
		{
			get
			{
				return _FromPage;
			}
			set
			{
				_FromPage = value;
			}
		}

		/// <summary>
		///       获取或设置要打印的最后一页的从0开始计算的页码。
		///       </summary>
		public int ToPage
		{
			get
			{
				return _ToPage;
			}
			set
			{
				_ToPage = value;
			}
		}

		/// <summary>
		///       指定默认打印机的名称
		///       </summary>
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
		///       指定默认打印纸张来源
		///       </summary>
		[DefaultValue(null)]
		[Category("Behavior")]
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
		///       从0开始计算的指定打印的页码数
		///       </summary>
		[Browsable(false)]
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
		///       在续打模式先是否打印第一页的页眉页脚
		///       </summary>
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
		///       手动双面打印
		///       </summary>
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
		///       手动双面打印标记
		///       </summary>
		internal int ManualDuplexFlag
		{
			get
			{
				return _ManualDuplexFlag;
			}
			set
			{
				_ManualDuplexFlag = value;
			}
		}

		/// <summary>
		///       设置指定打印页码号
		///       </summary>
		/// <param name="specifyPageIndexs">页码号数组字符串，例如“1,4,5,7,9”。</param>
		public void SetSpecifyPageIndexsByString(string specifyPageIndexs)
		{
			if (string.IsNullOrEmpty(specifyPageIndexs))
			{
				throw new ArgumentNullException(specifyPageIndexs);
			}
			PrintRange = PrintRange.SomePages;
			List<int> list = new List<int>();
			string[] array = specifyPageIndexs.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				int item = int.Parse(array[i]);
				list.Add(item);
			}
			SpecifyPageIndexs = list;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCPrintDocumentOptions Clone()
		{
			DCPrintDocumentOptions dCPrintDocumentOptions = (DCPrintDocumentOptions)MemberwiseClone();
			if (_BoundsSelection != null)
			{
				dCPrintDocumentOptions._BoundsSelection = _BoundsSelection.Clone();
			}
			if (_JumpPrint != null)
			{
				dCPrintDocumentOptions._JumpPrint = _JumpPrint.Clone();
			}
			if (_SpecifyPageIndexs != null)
			{
				dCPrintDocumentOptions._SpecifyPageIndexs = new List<int>(_SpecifyPageIndexs);
			}
			return dCPrintDocumentOptions;
		}

		public PrintPageCollection BuildOutputPages(PrintPageCollection pages)
		{
			return new PrintPageCollection();
		}

		/// <summary>
		///       检查是否通过特定页码号的测试
		///       </summary>
		/// <param name="pageIndex">
		/// </param>
		/// <returns>
		/// </returns>
		private bool CheckSpecifyPageIndex(int pageIndex)
		{
			if (SpecifyPageIndexs != null && SpecifyPageIndexs.Count > 0)
			{
				int num = 0;
				while (true)
				{
					if (num < SpecifyPageIndexs.Count)
					{
						if (SpecifyPageIndexs[num] == pageIndex)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
			return true;
		}
	}
}
