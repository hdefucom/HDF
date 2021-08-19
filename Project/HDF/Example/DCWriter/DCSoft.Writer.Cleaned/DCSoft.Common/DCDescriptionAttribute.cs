using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       成员说明特性
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class DCDescriptionAttribute : DescriptionAttribute
	{
		private static bool _ShowMemberName = false;

		private bool _CheckMemberExist = true;

		private Type _Type = null;

		private string _MemberName = null;

		private bool _Initalized = false;

		private string _ResourceItemName = null;

		private string _Value = null;

		                                                                    /// <summary>
		                                                                    ///       显示成员名称
		                                                                    ///       </summary>
		public static bool ShowMemberName
		{
			get
			{
				return _ShowMemberName;
			}
			set
			{
				_ShowMemberName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       检查类型成员是否存在
		                                                                    ///       </summary>
		public bool CheckMemberExist
		{
			get
			{
				return _CheckMemberExist;
			}
			set
			{
				_CheckMemberExist = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       内部的名称
		                                                                    ///       </summary>
		public string ResourceItemName
		{
			get
			{
				CheckInitalized();
				return _ResourceItemName;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       说明文字
		                                                                    ///       </summary>
		public override string Description
		{
			get
			{
				CheckInitalized();
				if (_Value == null)
				{
					_Value = "";
				}
				return _Value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="type">类型</param>
		                                                                    /// <param name="memberName">成员名称</param>
		public DCDescriptionAttribute(Type type, string memberName)
		{
			_Type = type;
			_MemberName = memberName;
		}

		private void CheckInitalized()
		{
			int num = 14;
			if (_Initalized)
			{
				return;
			}
			_Initalized = true;
			if (DCDisplayNameAttribute.CheckParameter(_Type, _MemberName, CheckMemberExist))
			{
				_ResourceItemName = GClass359.smethod_6(_Type.FullName + "." + _MemberName + "_Description");
				_Value = GClass359.smethod_7(_ResourceItemName, bool_0: false);
				if (ShowMemberName)
				{
					_Value = "(" + _MemberName + ")" + _Value;
				}
			}
			if (_Value == null)
			{
				_Value = "";
			}
		}
	}
}
