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
	                                                                    ///       成员属性信息
	                                                                    ///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DCPropertyInfo : DCMemberInfo
	{
		private bool bolCanRead = true;

		private bool bolCanWrite = true;

		private bool bolIsSpecialName = false;

		private PrimitiveTypeConsts _ValuePrimitiveType = PrimitiveTypeConsts.Object;

		private DCTypeInfo myPropertyType = null;

		private bool _IsCollection = false;

		private string _PropertyTypeFullName = null;

		private string _PropertyTypeID = null;

		private DCParameterInfoList myIndexParameters = null;

		private bool _IsPublic = true;

		private bool _IsPrivate = false;

		private bool _IsAssembly = false;

		private bool _IsAbstract = false;

		private bool _IsFamily = false;

		private bool _IsVirtual = false;

		private bool _IsStatic = false;

		private bool _IsFinal = false;

		[Browsable(false)]
		public bool HasIndexParameter => IndexParameters != null && IndexParameters.Count > 0;

		                                                                    /// <summary>
		                                                                    ///       能读取
		                                                                    ///       </summary>
		[DefaultValue(true)]
		public bool CanRead
		{
			get
			{
				return bolCanRead;
			}
			set
			{
				bolCanRead = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       能写入
		                                                                    ///       </summary>
		[DefaultValue(true)]
		public bool CanWrite
		{
			get
			{
				return bolCanWrite;
			}
			set
			{
				bolCanWrite = value;
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

		public override MemberTypes MemberType => MemberTypes.Property;

		                                                                    /// <summary>
		                                                                    ///       数值数据类型
		                                                                    ///       </summary>
		[DefaultValue(PrimitiveTypeConsts.Object)]
		public PrimitiveTypeConsts ValuePrimitiveType
		{
			get
			{
				return _ValuePrimitiveType;
			}
			set
			{
				_ValuePrimitiveType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       属性的数据类型
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[XmlIgnore]
		public DCTypeInfo PropertyType
		{
			get
			{
				return myPropertyType;
			}
			set
			{
				myPropertyType = value;
			}
		}

		[DefaultValue(false)]
		[XmlAttribute]
		public bool IsCollection
		{
			get
			{
				return _IsCollection;
			}
			set
			{
				_IsCollection = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       属性数据类型全名
		                                                                    ///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string PropertyTypeFullName
		{
			get
			{
				return _PropertyTypeFullName;
			}
			set
			{
				_PropertyTypeFullName = value;
			}
		}

		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string PropertyTypeID
		{
			get
			{
				if (myPropertyType == null)
				{
					return _PropertyTypeID;
				}
				return myPropertyType.ID;
			}
			set
			{
				_PropertyTypeID = value;
			}
		}

		[DefaultValue(null)]
		[XmlArrayItem("Parameter", typeof(DCParameterInfo))]
		public DCParameterInfoList IndexParameters
		{
			get
			{
				return myIndexParameters;
			}
			set
			{
				myIndexParameters = value;
			}
		}

		[DefaultValue(true)]
		public bool IsPublic
		{
			get
			{
				return _IsPublic;
			}
			set
			{
				_IsPublic = value;
			}
		}

		[DefaultValue(false)]
		public bool IsPrivate
		{
			get
			{
				return _IsPrivate;
			}
			set
			{
				_IsPrivate = value;
			}
		}

		[DefaultValue(false)]
		public bool IsAssembly
		{
			get
			{
				return _IsAssembly;
			}
			set
			{
				_IsAssembly = value;
			}
		}

		[DefaultValue(false)]
		public bool IsAbstract
		{
			get
			{
				return _IsAbstract;
			}
			set
			{
				_IsAbstract = value;
			}
		}

		[DefaultValue(false)]
		public bool IsFamily
		{
			get
			{
				return _IsFamily;
			}
			set
			{
				_IsFamily = value;
			}
		}

		[DefaultValue(false)]
		public bool IsVirtual
		{
			get
			{
				return _IsVirtual;
			}
			set
			{
				_IsVirtual = value;
			}
		}

		[DefaultValue(false)]
		public bool IsStatic
		{
			get
			{
				return _IsStatic;
			}
			set
			{
				_IsStatic = value;
			}
		}

		[DefaultValue(false)]
		public bool IsFinal
		{
			get
			{
				return _IsFinal;
			}
			set
			{
				_IsFinal = value;
			}
		}

		public override bool EqualsMark(DCMemberInfo member)
		{
			DCPropertyInfo dCPropertyInfo = member as DCPropertyInfo;
			if (dCPropertyInfo != null)
			{
				if (dCPropertyInfo.CanRead != CanRead)
				{
					return false;
				}
				if (dCPropertyInfo.CanWrite != CanWrite)
				{
					return false;
				}
				if (dCPropertyInfo.PropertyType != PropertyType)
				{
					return false;
				}
				return DCParameterInfoList.EqualsMark(IndexParameters, dCPropertyInfo.IndexParameters, equalsParameterName: false);
			}
			return false;
		}

		public override string ToString()
		{
			return "Property:" + base.Name;
		}

		public override string ToShortString()
		{
			return _Name;
		}

		public override string ToLongString()
		{
			return ToLongString(includeParameter: false, includeParameterName: false);
		}

		public string ToLongString(bool includeParameter, bool includeParameterName)
		{
			int num = 14;
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
			if (IsStatic)
			{
				stringBuilder.Append("static ");
			}
			if (IsFinal)
			{
				stringBuilder.Append("sealed ");
			}
			if (IsVirtual)
			{
				stringBuilder.Append("virtual ");
			}
			if (IsAbstract)
			{
				stringBuilder.Append("abstract ");
			}
			if (PropertyType == null)
			{
				stringBuilder.Append("[VOID] " + _Name);
			}
			else
			{
				stringBuilder.Append(PropertyType.CSharpName + " " + _Name);
			}
			if (includeParameter && HasIndexParameter)
			{
				stringBuilder.Append("[");
				for (int i = 0; i < IndexParameters.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					if (IndexParameters[i].ParameterType == null)
					{
						stringBuilder.Append("[VOID]");
					}
					else
					{
						stringBuilder.Append(IndexParameters[i].ParameterType.CSharpName);
					}
					if (includeParameterName)
					{
						stringBuilder.Append(" " + IndexParameters[i].Name);
					}
				}
				stringBuilder.Append("]");
			}
			stringBuilder.Append("{ ");
			if (CanRead)
			{
				stringBuilder.Append("get; ");
			}
			if (CanWrite)
			{
				stringBuilder.Append("set; ");
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}
}
