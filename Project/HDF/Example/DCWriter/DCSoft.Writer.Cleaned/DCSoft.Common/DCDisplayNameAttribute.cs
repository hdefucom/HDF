using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       显示名称特性
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class DCDisplayNameAttribute : DisplayNameAttribute
	{
		private Type _Type = null;

		private string _MemberName = null;

		private bool _Initalized = false;

		private string _ResourceItemName = null;

		private string _Value = null;

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
		                                                                    ///       获得的显示名称
		                                                                    ///       </summary>
		public override string DisplayName
		{
			get
			{
				if (GClass360.smethod_0())
				{
					CheckInitalized();
					if (_Value == null)
					{
						_Value = _MemberName;
					}
					if (_Value == null)
					{
						_Value = "";
					}
					return _Value;
				}
				string text = _MemberName;
				if (text == null)
				{
					text = "";
				}
				return text;
			}
		}

		internal static bool CheckParameter(Type type, string memberName, bool checkMemberExist)
		{
			if (type == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(memberName))
			{
				return false;
			}
			if (!(memberName == type.Name) && checkMemberExist)
			{
				MemberInfo[] member = type.GetMember(memberName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
				if (member == null || member.Length == 0)
				{
					return false;
				}
			}
			return GClass359.smethod_12(type.Assembly);
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="type">类型</param>
		                                                                    /// <param name="memberName">成员名称</param>
		public DCDisplayNameAttribute(Type type, string memberName)
		{
			_Type = type;
			_MemberName = memberName;
		}

		private void CheckInitalized()
		{
			int num = 18;
			if (!_Initalized)
			{
				_Initalized = true;
				if (CheckParameter(_Type, _MemberName, checkMemberExist: true))
				{
					_ResourceItemName = GClass359.smethod_6(_Type.FullName + "." + _MemberName);
					_Value = GClass359.smethod_7(_ResourceItemName, bool_0: false);
				}
				if (string.IsNullOrEmpty(_Value))
				{
					_Value = _MemberName;
				}
			}
		}
	}
}
