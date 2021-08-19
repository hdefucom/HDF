using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       组件类型信息对象
	                                                                    ///       </summary>
	[Serializable]
	[DocumentComment]
	[ComVisible(false)]
	public class DCTypeInfo
	{
		private DCAssemblyInfo _Assembly = null;

		private string _AssemblyName = null;

		private DCMemberInfoList _Members = new DCMemberInfoList();

		internal string ID = null;

		private string _CSharpName = null;

		private DCTypeInfo _ComDefaultInterfaceType = null;

		private DCTypeInfo _ComSourceInterfacesType = null;

		private DCTypeInfo _CollectionItemType = null;

		private string _CollectionItemTypeID = null;

		private List<DCTypeInfo> _Interfaces = null;

		private string _InterfacesID = null;

		private DCTypeInfo _BaseType = null;

		private string _BaseTypeID = null;

		private string _Name = null;

		private string _Namespace = null;

		private string _FullName = null;

		private string _Description = null;

		private string _DispalyName = null;

		private Image _Image = null;

		private bool _ComVisible = false;

		private Guid _ComGUID = Guid.Empty;

		private Guid myGUID = Guid.Empty;

		private bool bolIsAbstract = false;

		private bool bolIsAnsiClass = true;

		private bool bolIsArray = false;

		private bool bolIsAutoClass = false;

		private bool bolIsAutoLayout = true;

		private bool bolIsByRef = false;

		private bool bolIsClass = true;

		private bool _IsCollectionType = false;

		private bool bolIsCOMObject = false;

		private bool bolIsEnum = false;

		private bool bolIsImport = false;

		private bool bolIsInterface = false;

		private bool bolIsMarshalByRef = false;

		private bool bolIsNested = false;

		private bool bolIsNestedAssembly = false;

		private bool bolIsNestedFamANDAssem = false;

		private bool bolIsNestedFamily = false;

		private bool bolIsNestedFamORAssem = false;

		private bool bolIsNestedPrivate = false;

		private bool bolIsNestedPublic = false;

		private bool bolIsPointer = false;

		private bool bolIsPrimitive = false;

		private PrimitiveTypeConsts _PrimitiveType = PrimitiveTypeConsts.Custom;

		private bool bolIsPublic = true;

		private bool bolIsSealed = false;

		private bool bolIsSerializable = false;

		private bool bolIsSpecialName = false;

		private bool bolIsUnicodeClass = false;

		private bool bolIsValueType = false;

		private bool bolIsVisible = true;

		private bool _IsGenericType = false;

		private bool _IsDelegate = false;

		private DCTypeInfo _DelegateReturnType = null;

		private DCParameterInfoList _DelegateParameters = null;

		                                                                    /// <summary>
		                                                                    ///       类型所属的程序集对象
		                                                                    ///       </summary>
		[XmlIgnore]
		public DCAssemblyInfo Assembly
		{
			get
			{
				return _Assembly;
			}
			set
			{
				_Assembly = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       类型所属的程序集名称
		                                                                    ///       </summary>
		[XmlIgnore]
		public string AssemblyName
		{
			get
			{
				return _AssemblyName;
			}
			set
			{
				_AssemblyName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       成员信息对象
		                                                                    ///       </summary>
		[XmlArrayItem("Property", typeof(DCPropertyInfo))]
		[XmlArrayItem("Method", typeof(DCMethodInfo))]
		[XmlArrayItem("Event", typeof(DCEventInfo))]
		[XmlArrayItem("Field", typeof(DCFieldInfo))]
		public DCMemberInfoList Members
		{
			get
			{
				return _Members;
			}
			set
			{
				_Members = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       C#中的类型名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string CSharpName
		{
			get
			{
				if (string.IsNullOrEmpty(_CSharpName))
				{
					return FullName;
				}
				return _CSharpName;
			}
			set
			{
				_CSharpName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public DCTypeInfo ComDefaultInterfaceType
		{
			get
			{
				return _ComDefaultInterfaceType;
			}
			set
			{
				_ComDefaultInterfaceType = value;
			}
		}

		[Browsable(false)]
		[XmlIgnore]
		public DCTypeInfo ComSourceInterfacesType
		{
			get
			{
				return _ComSourceInterfacesType;
			}
			set
			{
				_ComSourceInterfacesType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       集合成员类型
		                                                                    ///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public DCTypeInfo CollectionItemType
		{
			get
			{
				return _CollectionItemType;
			}
			set
			{
				_CollectionItemType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       集合成员类型编号
		                                                                    ///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string CollectionItemTypeID
		{
			get
			{
				if (_CollectionItemType == null)
				{
					return _CollectionItemTypeID;
				}
				return _CollectionItemType.ID;
			}
			set
			{
				_CollectionItemTypeID = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public List<DCTypeInfo> Interfaces
		{
			get
			{
				return _Interfaces;
			}
			set
			{
				_Interfaces = value;
			}
		}

		[XmlElement]
		[Browsable(false)]
		[DefaultValue(null)]
		public string InterfacesID
		{
			get
			{
				return _InterfacesID;
			}
			set
			{
				_InterfacesID = value;
			}
		}

		[Browsable(false)]
		[XmlIgnore]
		public DCTypeInfo BaseType
		{
			get
			{
				return _BaseType;
			}
			set
			{
				_BaseType = value;
			}
		}

		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string BaseTypeID
		{
			get
			{
				if (_BaseType == null)
				{
					return _BaseTypeID;
				}
				return _BaseType.ID;
			}
			set
			{
				_BaseTypeID = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       类型名称
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
		                                                                    ///       命名空间
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string Namespace
		{
			get
			{
				return _Namespace;
			}
			set
			{
				_Namespace = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       类型全名
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string FullName
		{
			get
			{
				return _FullName;
			}
			set
			{
				_FullName = value;
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
				_Description = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       显示的名称
		                                                                    ///       </summary>
		[DefaultValue(null)]
		public string DispalyName
		{
			get
			{
				return _DispalyName;
			}
			set
			{
				_DispalyName = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       图片对象
		                                                                    ///       </summary>
		[DefaultValue(null)]
		[XmlIgnore]
		[Browsable(false)]
		public Image Image
		{
			get
			{
				return _Image;
			}
			set
			{
				_Image = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       图片对象的二进制数据
		                                                                    ///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[Browsable(false)]
		public byte[] ImageBinary
		{
			get
			{
				if (_Image == null)
				{
					return null;
				}
				MemoryStream memoryStream = new MemoryStream();
				_Image.Save(memoryStream, ImageFormat.Bmp);
				return memoryStream.ToArray();
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					_Image = null;
					return;
				}
				MemoryStream stream = new MemoryStream(value);
				_Image = Image.FromStream(stream);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象是否COM可见
		                                                                    ///       </summary>
		[DefaultValue(false)]
		public bool ComVisible
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

		[XmlIgnore]
		public Guid ComGUID
		{
			get
			{
				return _ComGUID;
			}
			set
			{
				_ComGUID = value;
			}
		}

		[XmlElement]
		[Browsable(false)]
		[DefaultValue("00000000-0000-0000-0000-000000000000")]
		public string ComString
		{
			get
			{
				return _ComGUID.ToString();
			}
			set
			{
				_ComGUID = new Guid(value);
			}
		}

		[XmlIgnore]
		public Guid GUID
		{
			get
			{
				return myGUID;
			}
			set
			{
				myGUID = value;
			}
		}

		[DefaultValue("00000000-0000-0000-0000-000000000000")]
		[Browsable(false)]
		[XmlElement]
		public string GUIDString
		{
			get
			{
				return myGUID.ToString();
			}
			set
			{
				myGUID = new Guid(value);
			}
		}

		[DefaultValue(false)]
		public bool IsAbstract
		{
			get
			{
				return bolIsAbstract;
			}
			set
			{
				bolIsAbstract = value;
			}
		}

		[DefaultValue(true)]
		public bool IsAnsiClass
		{
			get
			{
				return bolIsAnsiClass;
			}
			set
			{
				bolIsAnsiClass = value;
			}
		}

		[DefaultValue(false)]
		public bool IsArray
		{
			get
			{
				return bolIsArray;
			}
			set
			{
				bolIsArray = value;
			}
		}

		[DefaultValue(false)]
		public bool IsAutoClass
		{
			get
			{
				return bolIsAutoClass;
			}
			set
			{
				bolIsAutoClass = value;
			}
		}

		[DefaultValue(true)]
		public bool IsAutoLayout
		{
			get
			{
				return bolIsAutoLayout;
			}
			set
			{
				bolIsAutoLayout = value;
			}
		}

		[DefaultValue(false)]
		public bool IsByRef
		{
			get
			{
				return bolIsByRef;
			}
			set
			{
				bolIsByRef = value;
			}
		}

		[DefaultValue(true)]
		public bool IsClass
		{
			get
			{
				return bolIsClass;
			}
			set
			{
				bolIsClass = value;
			}
		}

		[DefaultValue(false)]
		public bool IsCollectionType
		{
			get
			{
				return _IsCollectionType;
			}
			set
			{
				_IsCollectionType = value;
			}
		}

		[DefaultValue(false)]
		public bool IsCOMObject
		{
			get
			{
				return bolIsCOMObject;
			}
			set
			{
				bolIsCOMObject = value;
			}
		}

		[DefaultValue(false)]
		public bool IsEnum
		{
			get
			{
				return bolIsEnum;
			}
			set
			{
				bolIsEnum = value;
			}
		}

		[DefaultValue(false)]
		public bool IsImport
		{
			get
			{
				return bolIsImport;
			}
			set
			{
				bolIsImport = value;
			}
		}

		[DefaultValue(false)]
		public bool IsInterface
		{
			get
			{
				return bolIsInterface;
			}
			set
			{
				bolIsInterface = value;
			}
		}

		[DefaultValue(false)]
		public bool IsMarshalByRef
		{
			get
			{
				return bolIsMarshalByRef;
			}
			set
			{
				bolIsMarshalByRef = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNested
		{
			get
			{
				return bolIsNested;
			}
			set
			{
				bolIsNested = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNestedAssembly
		{
			get
			{
				return bolIsNestedAssembly;
			}
			set
			{
				bolIsNestedAssembly = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNestedFamANDAssem
		{
			get
			{
				return bolIsNestedFamANDAssem;
			}
			set
			{
				bolIsNestedFamANDAssem = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNestedFamily
		{
			get
			{
				return bolIsNestedFamily;
			}
			set
			{
				bolIsNestedFamily = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNestedFamORAssem
		{
			get
			{
				return bolIsNestedFamORAssem;
			}
			set
			{
				bolIsNestedFamORAssem = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNestedPrivate
		{
			get
			{
				return bolIsNestedPrivate;
			}
			set
			{
				bolIsNestedPrivate = value;
			}
		}

		[DefaultValue(false)]
		public bool IsNestedPublic
		{
			get
			{
				return bolIsNestedPublic;
			}
			set
			{
				bolIsNestedPublic = value;
			}
		}

		[DefaultValue(false)]
		public bool IsPointer
		{
			get
			{
				return bolIsPointer;
			}
			set
			{
				bolIsPointer = value;
			}
		}

		[DefaultValue(false)]
		public bool IsPrimitive
		{
			get
			{
				return bolIsPrimitive;
			}
			set
			{
				bolIsPrimitive = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       基础类型
		                                                                    ///       </summary>
		[DefaultValue(PrimitiveTypeConsts.Custom)]
		public PrimitiveTypeConsts PrimitiveType
		{
			get
			{
				return _PrimitiveType;
			}
			set
			{
				_PrimitiveType = value;
			}
		}

		[DefaultValue(true)]
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
		public bool IsSealed
		{
			get
			{
				return bolIsSealed;
			}
			set
			{
				bolIsSealed = value;
			}
		}

		[DefaultValue(false)]
		public bool IsSerializable
		{
			get
			{
				return bolIsSerializable;
			}
			set
			{
				bolIsSerializable = value;
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
		public bool IsUnicodeClass
		{
			get
			{
				return bolIsUnicodeClass;
			}
			set
			{
				bolIsUnicodeClass = value;
			}
		}

		[DefaultValue(false)]
		public bool IsValueType
		{
			get
			{
				return bolIsValueType;
			}
			set
			{
				bolIsValueType = value;
			}
		}

		[DefaultValue(true)]
		public bool IsVisible
		{
			get
			{
				return bolIsVisible;
			}
			set
			{
				bolIsVisible = value;
			}
		}

		[DefaultValue(false)]
		public bool IsGenericType
		{
			get
			{
				return _IsGenericType;
			}
			set
			{
				_IsGenericType = value;
			}
		}

		[DefaultValue(false)]
		public bool IsDelegate
		{
			get
			{
				return _IsDelegate;
			}
			set
			{
				_IsDelegate = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       委托的返回值类型
		                                                                    ///       </summary>
		public DCTypeInfo DelegateReturnType
		{
			get
			{
				return _DelegateReturnType;
			}
			set
			{
				_DelegateReturnType = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       委托的参数列表
		                                                                    ///       </summary>
		[XmlArrayItem("Parameter", typeof(DCParameterInfo))]
		[DefaultValue(null)]
		public DCParameterInfoList DelegateParameters
		{
			get
			{
				return _DelegateParameters;
			}
			set
			{
				_DelegateParameters = value;
			}
		}

		public DCMemberInfo GetMember(string name)
		{
			if (_Members != null)
			{
				foreach (DCMemberInfo member in _Members)
				{
					if (string.Compare(member.Name, name, ignoreCase: true) == 0)
					{
						return member;
					}
				}
			}
			return null;
		}

		public bool ContainsMember(string name)
		{
			return GetMember(name) != null;
		}

		public bool EqualsDelegateMethodMark(DCMethodInfo method)
		{
			if (method == null)
			{
				return false;
			}
			if (method.ReturnType != DelegateReturnType)
			{
				return false;
			}
			return DCParameterInfoList.EqualsMark(DelegateParameters, method.Parameters, equalsParameterName: false);
		}

		public DCTypeInfo Clone()
		{
			DCTypeInfo dCTypeInfo = (DCTypeInfo)MemberwiseClone();
			dCTypeInfo._Members = new DCMemberInfoList();
			foreach (DCMemberInfo member in _Members)
			{
				dCTypeInfo._Members.Add(member.Clone());
			}
			if (_DelegateParameters != null && _DelegateParameters.Count > 0)
			{
				dCTypeInfo._DelegateParameters = new DCParameterInfoList();
				foreach (DCParameterInfo delegateParameter in _DelegateParameters)
				{
					dCTypeInfo._DelegateParameters.Add(delegateParameter);
				}
			}
			return dCTypeInfo;
		}

		public override string ToString()
		{
			return FullName;
		}
	}
}
