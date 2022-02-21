using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页码标签文本
	///       </summary>
	[Serializable]
	
	[ComClass("E960B21E-3731-43F5-9AB2-3BA46E67463F", "2B691831-D0C3-42C3-9FE3-43B7BD23AAFB")]
	[ComDefaultInterface(typeof(IPageLabelText))]
	[Guid("E960B21E-3731-43F5-9AB2-3BA46E67463F")]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComVisible(true)]
	public class PageLabelText : IPageLabelText
	{
		internal const string string_0 = "E960B21E-3731-43F5-9AB2-3BA46E67463F";

		internal const string string_1 = "2B691831-D0C3-42C3-9FE3-43B7BD23AAFB";

		private int int_0 = 0;

		private string string_2 = null;

		/// <summary>
		///       从0开始计算的页码
		///       </summary>
		[ComVisible(true)]
		
		[DefaultValue(0)]
		public int PageIndex
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       文本值
		///       </summary>
		[DefaultValue(null)]
		
		[ComVisible(true)]
		public string Text
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public PageLabelText()
		{
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public PageLabelText Clone()
		{
			return (PageLabelText)MemberwiseClone();
		}

		public override string ToString()
		{
			return PageIndex + "|" + Text;
		}
	}
}
