using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       动作方法声明特性
	///       </summary>
	
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
	[ComVisible(false)]
	public class WriterCommandDescriptionAttribute : Attribute
	{
		private GEnum6 _FunctionID = GEnum6.const_0;

		private string _Name = null;

		private int _Priority = 10;

		private bool _CanModifyContent = false;

		private Keys _ShortcutKey = Keys.None;

		private string _ImageResource = null;

		private string _Description = null;

		private Type _ReturnValueType = null;

		private object _DefaultResultValue = null;

		/// <summary>
		///       功能编号
		///       </summary>
		public GEnum6 FunctionID
		{
			get
			{
				return _FunctionID;
			}
			set
			{
				_FunctionID = value;
			}
		}

		/// <summary>
		///       动作名称
		///       </summary>
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
		///       优先级，值越低则越优先
		///       </summary>
		public int Priority
		{
			get
			{
				return _Priority;
			}
			set
			{
				_Priority = value;
			}
		}

		/// <summary>
		///       本命令能否可以导致文档内容修改
		///       </summary>
		public bool CanModifyContent
		{
			get
			{
				return _CanModifyContent;
			}
			set
			{
				_CanModifyContent = value;
			}
		}

		/// <summary>
		///       快捷键
		///       </summary>
		public Keys ShortcutKey
		{
			get
			{
				return _ShortcutKey;
			}
			set
			{
				_ShortcutKey = value;
			}
		}

		/// <summary>
		///       动作图标来源
		///       </summary>
		public string ImageResource
		{
			get
			{
				return _ImageResource;
			}
			set
			{
				_ImageResource = value;
			}
		}

		/// <summary>
		///       动作说明
		///       </summary>
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		/// <summary>
		///       返回值的数据类型
		///       </summary>
		public Type ReturnValueType
		{
			get
			{
				return _ReturnValueType;
			}
			set
			{
				_ReturnValueType = value;
			}
		}

		/// <summary>
		///       默认的结果返回值
		///       </summary>
		public object DefaultResultValue
		{
			get
			{
				return _DefaultResultValue;
			}
			set
			{
				_DefaultResultValue = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public WriterCommandDescriptionAttribute()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">动作名称</param>
		public WriterCommandDescriptionAttribute(string name)
		{
			_Name = name;
		}
	}
}
