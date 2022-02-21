using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       插入RTF文本的命令参数对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	
	public class InsertRTFCommandParameter
	{
		private string _RTFText = null;

		/// <summary>
		///       RTF文本
		///       </summary>
		public string RTFText
		{
			get
			{
				return _RTFText;
			}
			set
			{
				_RTFText = value;
			}
		}
	}
}
