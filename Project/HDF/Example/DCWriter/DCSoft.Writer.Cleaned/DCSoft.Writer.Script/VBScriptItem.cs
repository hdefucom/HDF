using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       VB脚本项目
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class VBScriptItem
	{
		private string _Name = null;

		private string _ScriptText = null;

		private string _ScriptMethodName = null;

		/// <summary>
		///       名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       脚本名称
		///       </summary>
		[DefaultValue(null)]
		public string ScriptText
		{
			get
			{
				return _ScriptText;
			}
			set
			{
				_ScriptText = value;
				if (_ScriptText != null)
				{
					_ScriptText = _ScriptText.Trim();
					if (_ScriptText.Length == 0)
					{
						_ScriptText = null;
					}
				}
				_ScriptMethodName = null;
			}
		}

		/// <summary>
		///       脚本方法名称
		///       </summary>
		public string ScriptMethodName
		{
			get
			{
				return _ScriptMethodName;
			}
			set
			{
				_ScriptMethodName = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public VBScriptItem Clone()
		{
			return (VBScriptItem)MemberwiseClone();
		}
	}
}
