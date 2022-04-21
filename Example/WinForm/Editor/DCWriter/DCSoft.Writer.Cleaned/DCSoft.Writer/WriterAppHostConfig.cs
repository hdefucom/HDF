using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       应用程序宿主配置信息对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	
	public class WriterAppHostConfig
	{
		private bool _EnableScript = true;

		/// <summary>
		///       启用文档脚本
		///       </summary>
		[DefaultValue(true)]
		public bool EnableScript
		{
			get
			{
				return _EnableScript;
			}
			set
			{
				_EnableScript = value;
			}
		}
	}
}
