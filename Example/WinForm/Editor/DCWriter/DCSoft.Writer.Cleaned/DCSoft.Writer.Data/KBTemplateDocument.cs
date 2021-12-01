using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       知识库中的文档模板信息
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class KBTemplateDocument
	{
		private string _KBID = null;

		private string _Content = null;

		/// <summary>
		///       知识库节点编号
		///       </summary>
		[DefaultValue(null)]
		public string KBID
		{
			get
			{
				return _KBID;
			}
			set
			{
				_KBID = value;
			}
		}

		/// <summary>
		///       文档内容
		///       </summary>
		[DefaultValue(null)]
		public string Content
		{
			get
			{
				return _Content;
			}
			set
			{
				_Content = value;
			}
		}
	}
}
