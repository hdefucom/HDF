#define DEBUG
using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       成员信息对象
	                                                                    ///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public abstract class DCMemberInfo
	{
		protected string _Name = null;

		private string _AttributeTypeNames = null;

		private string _DisplayName = null;

		private int _MetadataToken = 0;

		private BooleanValue _ComVisible = BooleanValue.Default;

		private int _DISPID = int.MinValue;

		[NonSerialized]
		private int _RuntimeDispID = int.MinValue;

		protected string _Description = null;

		private DCTypeInfo _DeclaringType = null;

		private bool _IsDefault = false;

		protected bool _Browsable = true;

		private int _EnumItemValue = 0;

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
		                                                                    ///       成员附加的属性名称列表
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string AttributeTypeNames
		{
			get
			{
				return _AttributeTypeNames;
			}
			set
			{
				_AttributeTypeNames = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       显示的名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string DisplayName
		{
			get
			{
				return _DisplayName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_DisplayName = null;
				}
				else
				{
					_DisplayName = value;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       内部的编号
		                                                                    ///       </summary>
		[DefaultValue(0)]
		public int MetadataToken
		{
			get
			{
				return _MetadataToken;
			}
			set
			{
				_MetadataToken = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象是否COM可见
		                                                                    ///       </summary>
		[DefaultValue(BooleanValue.Default)]
		public BooleanValue ComVisible
		{
			get
			{
				return _ComVisible;
			}
			set
			{
				_ComVisible = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       COM的DISP ID值
		                                                                    ///       </summary>
		[DefaultValue(int.MinValue)]
		public int DISPID
		{
			get
			{
				return _DISPID;
			}
			set
			{
				_DISPID = value;
			}
		}

		public bool HasDISPID => _DISPID != int.MinValue;

		                                                                    /// <summary>
		                                                                    ///       运行时使用的DISPID值
		                                                                    ///       </summary>
		[Browsable(false)]
		public int RuntimeDispID
		{
			get
			{
				if (_RuntimeDispID != int.MinValue)
				{
					return _RuntimeDispID;
				}
				return _DISPID;
			}
			set
			{
				_RuntimeDispID = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       说明
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_Description = null;
				}
				else
				{
					_Description = value;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       声明成员的类型
		                                                                    ///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		public DCTypeInfo DeclaringType
		{
			get
			{
				return _DeclaringType;
			}
			set
			{
				_DeclaringType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       默认属性
		                                                                    ///       </summary>
		[DefaultValue(false)]
		public bool IsDefault
		{
			get
			{
				return _IsDefault;
			}
			set
			{
				_IsDefault = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       是否可见
		                                                                    ///       </summary>
		[DefaultValue(true)]
		public bool Browsable
		{
			get
			{
				return _Browsable;
			}
			set
			{
				_Browsable = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       枚举项目值
		                                                                    ///       </summary>
		[DefaultValue(0)]
		public int EnumItemValue
		{
			get
			{
				return _EnumItemValue;
			}
			set
			{
				_EnumItemValue = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       成员类型
		                                                                    ///       </summary>
		public abstract MemberTypes MemberType
		{
			get;
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public DCMemberInfo()
		{
		}

		internal void SetAttributeTypeNames(MemberInfo info)
		{
			int num = 19;
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				Attribute[] customAttributes = Attribute.GetCustomAttributes(info);
				foreach (Attribute attribute in customAttributes)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(attribute.GetType().FullName);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(info.Name + ":" + ex.Message);
			}
			if (stringBuilder.Length == 0)
			{
				AttributeTypeNames = null;
			}
			else
			{
				AttributeTypeNames = stringBuilder.ToString();
			}
		}

		                                                                    /// <summary>
		                                                                    ///       进行成员签名匹配判断,但不匹配成员名称
		                                                                    ///       </summary>
		                                                                    /// <param name="member">要判断的成员</param>
		                                                                    /// <returns>签名匹配判断通过</returns>
		public virtual bool EqualsMark(DCMemberInfo member)
		{
			return false;
		}

		public virtual string ToShortString()
		{
			return null;
		}

		public virtual string ToLongString()
		{
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       复制对象
		                                                                    ///       </summary>
		                                                                    /// <returns>复制品</returns>
		public virtual DCMemberInfo Clone()
		{
			return (DCMemberInfo)MemberwiseClone();
		}
	}
}
