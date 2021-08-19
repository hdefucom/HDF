using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       字段信息对象
	                                                                    ///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCFieldInfo : DCMemberInfo
	{
		private DCTypeInfo myFieldType = null;

		private string _FieldTypeID = null;

		private bool bolIsAssembly = false;

		private bool bolIsFamily = true;

		private bool bolIsInitOnly = false;

		private bool bolIsLiteral = false;

		private bool bolIsNoSerialized = false;

		private bool bolIsPinvokeImpl = false;

		private bool bolIsPrivate = true;

		private bool bolIsPublic = false;

		private bool bolIsSpecialName = false;

		private bool bolIsStatic = false;

		                                                                    /// <summary>
		                                                                    ///       字段数据类型
		                                                                    ///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		public DCTypeInfo FieldType
		{
			get
			{
				return myFieldType;
			}
			set
			{
				myFieldType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       字段数据类型编号
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string FieldTypeID
		{
			get
			{
				if (myFieldType == null)
				{
					return _FieldTypeID;
				}
				return myFieldType.ID;
			}
			set
			{
				_FieldTypeID = value;
			}
		}

		[DefaultValue(false)]
		public bool IsAssembly
		{
			get
			{
				return bolIsAssembly;
			}
			set
			{
				bolIsAssembly = value;
			}
		}

		[DefaultValue(true)]
		public bool IsFamily
		{
			get
			{
				return bolIsFamily;
			}
			set
			{
				bolIsFamily = value;
			}
		}

		public bool IsFamilyAndAssembly => bolIsFamily && bolIsAssembly;

		public bool IsFamilyOrAssembly => bolIsFamily || bolIsAssembly;

		[DefaultValue(false)]
		public bool IsInitOnly
		{
			get
			{
				return bolIsInitOnly;
			}
			set
			{
				bolIsInitOnly = value;
			}
		}

		[DefaultValue(false)]
		public bool IsLiteral
		{
			get
			{
				return bolIsLiteral;
			}
			set
			{
				bolIsLiteral = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNoSerialized
		{
			get
			{
				return bolIsNoSerialized;
			}
			set
			{
				bolIsNoSerialized = value;
			}
		}

		[DefaultValue(false)]
		public bool IsPinvokeImpl
		{
			get
			{
				return bolIsPinvokeImpl;
			}
			set
			{
				bolIsPinvokeImpl = value;
			}
		}

		[DefaultValue(true)]
		public bool IsPrivate
		{
			get
			{
				return bolIsPrivate;
			}
			set
			{
				bolIsPrivate = value;
			}
		}

		[DefaultValue(false)]
		public bool IsPublic
		{
			get
			{
				return bolIsPublic;
			}
			set
			{
				bolIsPublic = value;
			}
		}

		[DefaultValue(false)]
		public bool IsSpecialName
		{
			get
			{
				return bolIsSpecialName;
			}
			set
			{
				bolIsSpecialName = value;
			}
		}

		[DefaultValue(false)]
		public bool IsStatic
		{
			get
			{
				return bolIsStatic;
			}
			set
			{
				bolIsStatic = value;
			}
		}

		public override MemberTypes MemberType => MemberTypes.Field;

		public override string ToString()
		{
			return "Field:" + base.Name;
		}

		public override bool EqualsMark(DCMemberInfo member)
		{
			DCFieldInfo dCFieldInfo = member as DCFieldInfo;
			if (dCFieldInfo == this)
			{
				return true;
			}
			return dCFieldInfo != null && dCFieldInfo.FieldType == FieldType;
		}

		public override string ToShortString()
		{
			return _Name;
		}

		public override string ToLongString()
		{
			int num = 8;
			StringBuilder stringBuilder = new StringBuilder();
			if (IsPublic)
			{
				stringBuilder.Append("public ");
			}
			else if (IsAssembly)
			{
				stringBuilder.Append("internal ");
			}
			else if (IsFamily)
			{
				stringBuilder.Append("protected ");
			}
			else
			{
				stringBuilder.Append("private ");
			}
			if (IsLiteral)
			{
				stringBuilder.Append("const ");
			}
			else
			{
				if (IsStatic)
				{
					stringBuilder.Append("static ");
				}
				if (IsInitOnly)
				{
					stringBuilder.Append("readonly ");
				}
			}
			if (FieldType == null)
			{
				stringBuilder.Append("[VOID] " + _Name);
			}
			else
			{
				stringBuilder.Append(FieldType.CSharpName + " " + _Name);
			}
			return stringBuilder.ToString();
		}
	}
}
