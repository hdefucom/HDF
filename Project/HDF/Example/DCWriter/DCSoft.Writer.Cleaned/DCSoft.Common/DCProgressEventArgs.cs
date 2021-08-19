using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       进度事件参数类型
	                                                                    ///       </summary>
	                                                                    /// <remarks>袁永福到此一游</remarks>
	[ComVisible(true)]
	[Guid("15A8F07B-B561-4403-9563-48E6E29D5353")]
	[DocumentComment]
	public class DCProgressEventArgs : EventArgs
	{
		private DCProgressStates dcprogressStates_0 = DCProgressStates.Progress;

		private string string_0 = null;

		private int int_0 = 0;

		private int int_1 = 0;

		private bool bool_0 = false;

		                                                                    /// <summary>
		                                                                    ///       状态
		                                                                    ///       </summary>
		public DCProgressStates State
		{
			get
			{
				return dcprogressStates_0;
			}
			set
			{
				dcprogressStates_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       进度消息
		                                                                    ///       </summary>
		public string Message => string_0;

		                                                                    /// <summary>
		                                                                    ///       最大值
		                                                                    ///       </summary>
		public int Max => int_0;

		                                                                    /// <summary>
		                                                                    ///       当前值
		                                                                    ///       </summary>
		public int Value => int_1;

		                                                                    /// <summary>
		                                                                    ///       用户取消标记
		                                                                    ///       </summary>
		public bool Cancel
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="msg">消息</param>
		                                                                    /// <param name="max">最大值</param>
		                                                                    /// <param name="Value">当前值</param>
		public DCProgressEventArgs(string string_1, int int_2, int int_3)
		{
			string_0 = string_1;
			int_0 = int_2;
			int_1 = int_3;
		}
	}
}
