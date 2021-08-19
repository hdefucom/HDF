using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Design
{
	                                                                    /// <summary>
	                                                                    ///       组件DOM结构管理器对象
	                                                                    ///       </summary>
	[Serializable]
	[ComVisible(false)]
	[DocumentComment]
	public class DCTypeDomDocument
	{
		                                                                    /// <summary>
		                                                                    ///       远程组件程序集分析器
		                                                                    ///       </summary>
		[ComVisible(false)]
		public class RemoteComponentAssemblyAnalyser : MarshalByRefObject
		{
			private List<string> _SpecifyBaseTypeNames = null;

			private int _LoadFlags = 0;

			                                                                    /// <summary>
			                                                                    ///       指定的基础类型名称
			                                                                    ///       </summary>
			public List<string> SpecifyBaseTypeNames
			{
				get
				{
					return _SpecifyBaseTypeNames;
				}
				set
				{
					_SpecifyBaseTypeNames = value;
				}
			}

			                                                                    /// <summary>
			                                                                    ///       加载相关类型的模式
			                                                                    ///       </summary>
			public int LoadFlags
			{
				get
				{
					return _LoadFlags;
				}
				set
				{
					_LoadFlags = value;
				}
			}

			public byte[] LoadInfoToBinary(string fileName)
			{
				int num = 16;
				if (string.IsNullOrEmpty(fileName))
				{
					throw new ArgumentNullException("fileName");
				}
				if (!File.Exists(fileName))
				{
					throw new FileNotFoundException(fileName);
				}
				Assembly assembly_ = Assembly.LoadFile(fileName);
				DCTypeDomDocument dCTypeDomDocument = new DCTypeDomDocument();
				dCTypeDomDocument.LoadFlags = (DCTypeLoadFlags)LoadFlags;
				dCTypeDomDocument._SpecifyBaseTypeNames = _SpecifyBaseTypeNames;
				dCTypeDomDocument.Load(assembly_);
				MemoryStream memoryStream = new MemoryStream();
				dCTypeDomDocument.SaveBinary(memoryStream);
				return memoryStream.ToArray();
			}
		}

		private class AssemblyComparer : IComparer<DCAssemblyInfo>
		{
			public int Compare(DCAssemblyInfo dcassemblyInfo_0, DCAssemblyInfo dcassemblyInfo_1)
			{
				return string.Compare(dcassemblyInfo_0.Name, dcassemblyInfo_1.Name, ignoreCase: false);
			}
		}

		private class TypeComparer : IComparer<DCTypeInfo>
		{
			public int Compare(DCTypeInfo dctypeInfo_0, DCTypeInfo dctypeInfo_1)
			{
				int num = string.Compare(dctypeInfo_0.Namespace, dctypeInfo_1.Namespace, ignoreCase: false);
				if (num == 0)
				{
					return string.Compare(dctypeInfo_0.Name, dctypeInfo_1.Name, ignoreCase: false);
				}
				return num;
			}
		}

		private class MemberComparer : IComparer<DCMemberInfo>
		{
			public int Compare(DCMemberInfo dcmemberInfo_0, DCMemberInfo dcmemberInfo_1)
			{
				int num = dcmemberInfo_0.MemberType.CompareTo(dcmemberInfo_1.MemberType);
				if (num == 0)
				{
					return string.Compare(dcmemberInfo_0.Name, dcmemberInfo_1.Name, ignoreCase: false);
				}
				return num;
			}
		}

		private DCTypeLoadFlags _LoadFlags = DCTypeLoadFlags.LoadRelationAssembly | DCTypeLoadFlags.LoadDeclaredOnlyMember;

		private List<string> _SpecifyBaseTypeNames = null;

		[NonSerialized]
		private Type[] _SpecifyBaseTypes = null;

		[NonSerialized]
		private int _AssembliesCount = 0;

		[NonSerialized]
		private int _TypesCount = 0;

		[NonSerialized]
		private int _MembersCount = 0;

		private List<DCAssemblyInfo> _Assemblies = new List<DCAssemblyInfo>();

		                                                                    /// <summary>
		                                                                    ///       加载类型数据时的标记
		                                                                    ///       </summary>
		public DCTypeLoadFlags LoadFlags
		{
			get
			{
				return _LoadFlags;
			}
			set
			{
				_LoadFlags = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       指定的基础类型名称
		                                                                    ///       </summary>
		public List<string> SpecifyBaseTypeNames
		{
			get
			{
				return _SpecifyBaseTypeNames;
			}
			set
			{
				_SpecifyBaseTypeNames = value;
				_SpecifyBaseTypes = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       程序集个数
		                                                                    ///       </summary>
		public int AssembliesCount => _AssembliesCount;

		                                                                    /// <summary>
		                                                                    ///       类型个数
		                                                                    ///       </summary>
		public int TypesCount => _TypesCount;

		                                                                    /// <summary>
		                                                                    ///       类型成员个数
		                                                                    ///       </summary>
		public int MembersCount => _MembersCount;

		                                                                    /// <summary>
		                                                                    ///       程序集信息列表
		                                                                    ///       </summary>
		[XmlArrayItem("Assembly", typeof(DCAssemblyInfo))]
		public List<DCAssemblyInfo> Assemblies
		{
			get
			{
				return _Assemblies;
			}
			set
			{
				_Assemblies = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       文档中所有的类型信息列表
		                                                                    ///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public DCTypeInfoList AllTypes
		{
			get
			{
				DCTypeInfoList dCTypeInfoList = new DCTypeInfoList();
				foreach (DCAssemblyInfo assembly in Assemblies)
				{
					dCTypeInfoList.AddRange(assembly.Types);
				}
				return dCTypeInfoList;
			}
		}

		public static DCTypeDomDocument LoadBinary(Stream stream)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			return (DCTypeDomDocument)binaryFormatter.Deserialize(stream);
		}

		public void SaveBinary(Stream stream)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(stream, this);
		}

		private bool CheckBaseType(Type type_0)
		{
			if (_SpecifyBaseTypeNames != null && _SpecifyBaseTypeNames.Count > 0 && _SpecifyBaseTypes == null)
			{
				List<Type> list = new List<Type>();
				foreach (string specifyBaseTypeName in _SpecifyBaseTypeNames)
				{
					Type typeByName = DesignUtils.GetTypeByName(specifyBaseTypeName);
					if (typeByName != null)
					{
						list.Add(typeByName);
					}
				}
				_SpecifyBaseTypes = list.ToArray();
			}
			if (_SpecifyBaseTypes != null && _SpecifyBaseTypes.Length > 0)
			{
				Type[] specifyBaseTypes = _SpecifyBaseTypes;
				int num = 0;
				while (true)
				{
					if (num < specifyBaseTypes.Length)
					{
						Type typeByName = specifyBaseTypes[num];
						if (typeByName.IsAssignableFrom(type_0))
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       获得类型信息对象
		                                                                    ///       </summary>
		                                                                    /// <param name="fullName">类型全名</param>
		                                                                    /// <param name="ignoreCase">是否区分大小写</param>
		                                                                    /// <returns>获得的类型信息对象</returns>
		public DCTypeInfo GetTypeInfo(string fullName, bool ignoreCase)
		{
			foreach (DCAssemblyInfo assembly in Assemblies)
			{
				foreach (DCTypeInfo type in assembly.Types)
				{
					if (string.Compare(type.FullName, fullName, ignoreCase) == 0)
					{
						return type;
					}
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       刷新统计信息
		                                                                    ///       </summary>
		public void RefreshCount()
		{
			_AssembliesCount = 0;
			_MembersCount = 0;
			_TypesCount = 0;
			if (Assemblies != null)
			{
				_AssembliesCount = Assemblies.Count;
				foreach (DCAssemblyInfo assembly in Assemblies)
				{
					_TypesCount += assembly.Types.Count;
					foreach (DCTypeInfo type in assembly.Types)
					{
						_MembersCount += type.Members.Count;
					}
				}
			}
		}

		public DCAssemblyInfo LoadCrossDemain(string fileName)
		{
			int num = 5;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			AppDomainSetup appDomainSetup = new AppDomainSetup();
			appDomainSetup.ApplicationBase = Path.GetDirectoryName(fileName);
			appDomainSetup.ApplicationName = "DCComponentDomInfo.Load";
			appDomainSetup.PrivateBinPath = Path.GetDirectoryName(fileName);
			if (AppDomain.CurrentDomain.ApplicationTrust != null)
			{
				appDomainSetup.ApplicationTrust = AppDomain.CurrentDomain.ApplicationTrust;
			}
			Evidence securityInfo = null;
			AppDomain appDomain = AppDomain.CreateDomain("Domain.DCComponentDomInfo.Load", securityInfo, appDomainSetup);
			byte[] buffer = null;
			try
			{
				RemoteComponentAssemblyAnalyser remoteComponentAssemblyAnalyser = (RemoteComponentAssemblyAnalyser)appDomain.CreateInstanceFromAndUnwrap(typeof(RemoteComponentAssemblyAnalyser).Assembly.Location, typeof(RemoteComponentAssemblyAnalyser).FullName);
				remoteComponentAssemblyAnalyser.LoadFlags = (int)LoadFlags;
				remoteComponentAssemblyAnalyser.SpecifyBaseTypeNames = _SpecifyBaseTypeNames;
				buffer = remoteComponentAssemblyAnalyser.LoadInfoToBinary(fileName);
			}
			finally
			{
				AppDomain.Unload(appDomain);
				appDomain = null;
				GC.Collect();
			}
			MemoryStream memoryStream = new MemoryStream(buffer);
			DCTypeDomDocument dCTypeDomDocument = LoadBinary(memoryStream);
			memoryStream.Close();
			if (dCTypeDomDocument.Assemblies != null && dCTypeDomDocument.Assemblies.Count > 0)
			{
				foreach (DCAssemblyInfo assembly in dCTypeDomDocument.Assemblies)
				{
					bool flag = false;
					foreach (DCAssemblyInfo assembly2 in Assemblies)
					{
						if (string.Compare(assembly.Name, assembly2.Name, ignoreCase: true) == 0)
						{
							foreach (DCTypeInfo type in assembly.Types)
							{
								bool flag2 = false;
								foreach (DCTypeInfo type2 in assembly2.Types)
								{
									if (string.Compare(type.FullName, type2.FullName, ignoreCase: true) == 0)
									{
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									assembly2.Types.Add(type);
								}
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Assemblies.Add(assembly);
					}
				}
				return dCTypeDomDocument.Assemblies[0];
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       对内容进行排序
		                                                                    ///       </summary>
		public void Sort()
		{
			if (Assemblies != null)
			{
				Assemblies.Sort(new AssemblyComparer());
				foreach (DCAssemblyInfo assembly in Assemblies)
				{
					if (assembly.Types != null)
					{
						assembly.Types.Sort(new TypeComparer());
						foreach (DCTypeInfo type in assembly.Types)
						{
							if (type.Members != null)
							{
								type.Members.Sort(new MemberComparer());
							}
						}
					}
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       加载程序集及其包含的所有的公开类型信息
		                                                                    ///       </summary>
		                                                                    /// <param name="asm">程序集信息对象</param>
		public DCAssemblyInfo Load(Assembly assembly_0)
		{
			int num = 16;
			if (assembly_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			DCAssemblyInfo dCAssemblyInfo = LoadAssemblyInfo(assembly_0);
			if (dCAssemblyInfo == null)
			{
				return null;
			}
			Type[] types = assembly_0.GetTypes();
			Type[] array = types;
			foreach (Type type in array)
			{
				if (!type.IsNotPublic)
				{
					LoadType(assembly_0, type, relationMode: false);
				}
			}
			dCAssemblyInfo.Types.Sort(new TypeComparer());
			RefreshCount();
			return dCAssemblyInfo;
		}

		                                                                    /// <summary>
		                                                                    ///       加载程序集信息对象
		                                                                    ///       </summary>
		                                                                    /// <param name="asm">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		private DCAssemblyInfo LoadAssemblyInfo(Assembly assembly_0)
		{
			if (IsExlude(assembly_0))
			{
				return null;
			}
			string name = assembly_0.GetName().Name;
			foreach (DCAssemblyInfo assembly in _Assemblies)
			{
				if (assembly.Name == name)
				{
					return assembly;
				}
			}
			DCAssemblyInfo dCAssemblyInfo = new DCAssemblyInfo();
			dCAssemblyInfo.Name = name;
			dCAssemblyInfo.FullName = assembly_0.FullName;
			dCAssemblyInfo.Version = assembly_0.GetName().Version.ToString();
			Attribute[] customAttributes = Attribute.GetCustomAttributes(assembly_0);
			foreach (object obj in customAttributes)
			{
				if (string.IsNullOrEmpty(dCAssemblyInfo.Description))
				{
					if (obj is AssemblyDescriptionAttribute)
					{
						dCAssemblyInfo.Description = ((AssemblyDescriptionAttribute)obj).Description;
					}
					if (obj is AssemblyProductAttribute)
					{
						dCAssemblyInfo.Description = ((AssemblyProductAttribute)obj).Product;
					}
					if (obj is AssemblyCompanyAttribute)
					{
						dCAssemblyInfo.Description = ((AssemblyCompanyAttribute)obj).Company;
					}
					if (obj is AssemblyCopyrightAttribute)
					{
						dCAssemblyInfo.Description = ((AssemblyCopyrightAttribute)obj).Copyright;
					}
				}
				if (obj is ComVisibleAttribute)
				{
					dCAssemblyInfo.ComVisible = ((ComVisibleAttribute)obj).Value;
				}
			}
			Assemblies.Add(dCAssemblyInfo);
			return dCAssemblyInfo;
		}

		                                                                    /// <summary>
		                                                                    ///       加载类型及其成员信息
		                                                                    ///       </summary>
		                                                                    /// <param name="t">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		private DCTypeInfo LoadType(Assembly assembly_0, Type type_0, bool relationMode)
		{
			int num = 4;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if ((LoadFlags & DCTypeLoadFlags.LoadPublicProtectOnly) == DCTypeLoadFlags.LoadPublicProtectOnly && (type_0.IsNestedAssembly || type_0.IsNestedFamANDAssem || type_0.IsNestedPrivate))
			{
				return null;
			}
			if (!type_0.Name.EndsWith("`1"))
			{
			}
			if (relationMode && (LoadFlags & DCTypeLoadFlags.LoadRelationAssembly) != DCTypeLoadFlags.LoadRelationAssembly && type_0.Assembly != assembly_0)
			{
				return null;
			}
			if ((LoadFlags & DCTypeLoadFlags.ExcludeEnumType) == DCTypeLoadFlags.ExcludeEnumType && type_0.IsEnum)
			{
				return null;
			}
			if ((LoadFlags & DCTypeLoadFlags.ExcludeWinFormASPControl) == DCTypeLoadFlags.ExcludeWinFormASPControl && (type_0.IsSubclassOf(typeof(System.Windows.Forms.Control)) || type_0.IsSubclassOf(typeof(System.Web.UI.Control))))
			{
				return null;
			}
			if ((LoadFlags & DCTypeLoadFlags.ExcludeInterfaceType) == DCTypeLoadFlags.ExcludeInterfaceType && type_0.IsInterface)
			{
				return null;
			}
			if ((LoadFlags & DCTypeLoadFlags.ExcludeValueType) == DCTypeLoadFlags.ExcludeValueType && type_0.IsValueType)
			{
				return null;
			}
			if ((LoadFlags & DCTypeLoadFlags.ExcludeArrayType) == DCTypeLoadFlags.ExcludeArrayType && type_0.IsArray)
			{
				return null;
			}
			if ((LoadFlags & DCTypeLoadFlags.ExcludeDelegateType) == DCTypeLoadFlags.ExcludeDelegateType && typeof(Delegate).IsAssignableFrom(type_0))
			{
				return null;
			}
			if (!CheckBaseType(type_0))
			{
				return null;
			}
			if (IsExlude(assembly_0))
			{
				return null;
			}
			DCAssemblyInfo dCAssemblyInfo = LoadAssemblyInfo(type_0.Assembly);
			if (dCAssemblyInfo == null)
			{
				return null;
			}
			string fullName = type_0.FullName;
			foreach (DCTypeInfo type2 in dCAssemblyInfo.Types)
			{
				if (type2.FullName == fullName)
				{
					return type2;
				}
			}
			DCTypeInfo dCTypeInfo = new DCTypeInfo();
			dCTypeInfo.ID = type_0.FullName + "," + dCAssemblyInfo.Name;
			dCTypeInfo.Name = type_0.Name;
			dCTypeInfo.Assembly = dCAssemblyInfo;
			dCTypeInfo.FullName = type_0.FullName;
			dCTypeInfo.DispalyName = DesignUtils.GetDisplayName(type_0);
			dCTypeInfo.Description = DesignUtils.GetDescription(type_0);
			dCAssemblyInfo.Types.Add(dCTypeInfo);
			if (type_0.BaseType != null)
			{
				dCTypeInfo.BaseType = LoadType(assembly_0, type_0.BaseType, relationMode: true);
			}
			List<DCTypeInfo> list = new List<DCTypeInfo>();
			Type[] interfaces = type_0.GetInterfaces();
			if (interfaces != null && interfaces.Length > 0)
			{
				Type[] array = interfaces;
				foreach (Type type_ in array)
				{
					DCTypeInfo dCTypeInfo2 = LoadType(assembly_0, type_, relationMode: true);
					if (dCTypeInfo2 != null)
					{
						list.Add(dCTypeInfo2);
					}
				}
			}
			if (list.Count > 0)
			{
				dCTypeInfo.Interfaces = list;
			}
			dCTypeInfo.Namespace = type_0.Namespace;
			dCTypeInfo.GUID = type_0.GUID;
			dCTypeInfo.ComVisible = dCAssemblyInfo.ComVisible;
			Attribute[] customAttributes = Attribute.GetCustomAttributes(type_0);
			foreach (Attribute attribute in customAttributes)
			{
				if (attribute is ComVisibleAttribute)
				{
					dCTypeInfo.ComVisible = ((ComVisibleAttribute)attribute).Value;
				}
				else if (attribute is ComDefaultInterfaceAttribute)
				{
					ComDefaultInterfaceAttribute comDefaultInterfaceAttribute = (ComDefaultInterfaceAttribute)attribute;
					dCTypeInfo.ComDefaultInterfaceType = LoadType(assembly_0, comDefaultInterfaceAttribute.Value, relationMode);
				}
				else if (attribute is ComSourceInterfacesAttribute)
				{
					ComSourceInterfacesAttribute comSourceInterfacesAttribute = (ComSourceInterfacesAttribute)attribute;
					Type type = assembly_0.GetType(comSourceInterfacesAttribute.Value, throwOnError: false, ignoreCase: true);
					if (type == null)
					{
						type = Type.GetType(comSourceInterfacesAttribute.Value, throwOnError: false, ignoreCase: true);
					}
					if (type != null)
					{
						dCTypeInfo.ComSourceInterfacesType = LoadType(assembly_0, type, relationMode);
					}
				}
				else if (attribute is GuidAttribute)
				{
					GuidAttribute guidAttribute = (GuidAttribute)attribute;
					if (!string.IsNullOrEmpty(guidAttribute.Value))
					{
						dCTypeInfo.ComGUID = new Guid(guidAttribute.Value);
					}
				}
			}
			ComVisibleAttribute comVisibleAttribute = (ComVisibleAttribute)Attribute.GetCustomAttribute(type_0, typeof(ComVisibleAttribute));
			if (comVisibleAttribute != null)
			{
				dCTypeInfo.ComVisible = comVisibleAttribute.Value;
			}
			if (DesignUtils.GetCollectionItemType(type_0, checkAddMethod: false) != null)
			{
				dCTypeInfo.IsCollectionType = true;
			}
			dCTypeInfo.CSharpName = DesignUtils.GetCSharpTypeName(type_0);
			dCTypeInfo.PrimitiveType = GetPrimitiveType(type_0);
			dCTypeInfo.IsAbstract = type_0.IsAbstract;
			dCTypeInfo.IsAnsiClass = type_0.IsAnsiClass;
			dCTypeInfo.IsArray = type_0.IsArray;
			dCTypeInfo.IsAutoClass = type_0.IsAutoClass;
			dCTypeInfo.IsAutoLayout = type_0.IsAutoLayout;
			dCTypeInfo.IsByRef = type_0.IsByRef;
			dCTypeInfo.IsClass = type_0.IsClass;
			dCTypeInfo.IsCOMObject = type_0.IsCOMObject;
			dCTypeInfo.IsEnum = type_0.IsEnum;
			dCTypeInfo.IsImport = type_0.IsImport;
			dCTypeInfo.IsInterface = type_0.IsInterface;
			dCTypeInfo.IsMarshalByRef = type_0.IsMarshalByRef;
			dCTypeInfo.IsNested = type_0.IsNested;
			dCTypeInfo.IsNestedAssembly = type_0.IsNestedAssembly;
			dCTypeInfo.IsNestedFamANDAssem = type_0.IsNestedFamANDAssem;
			dCTypeInfo.IsNestedFamily = type_0.IsNestedFamily;
			dCTypeInfo.IsNestedFamORAssem = type_0.IsNestedFamORAssem;
			dCTypeInfo.IsNestedPrivate = type_0.IsNestedPrivate;
			dCTypeInfo.IsNestedPublic = type_0.IsNestedPublic;
			dCTypeInfo.IsPointer = type_0.IsPointer;
			dCTypeInfo.IsPrimitive = type_0.IsPrimitive;
			dCTypeInfo.IsPublic = type_0.IsPublic;
			dCTypeInfo.IsSealed = type_0.IsSealed;
			dCTypeInfo.IsSerializable = type_0.IsSerializable;
			dCTypeInfo.IsSpecialName = type_0.IsSpecialName;
			dCTypeInfo.IsUnicodeClass = type_0.IsUnicodeClass;
			dCTypeInfo.IsValueType = type_0.IsValueType;
			dCTypeInfo.IsVisible = type_0.IsVisible;
			dCTypeInfo.IsGenericType = type_0.IsGenericType;
			if (typeof(Delegate).IsAssignableFrom(type_0))
			{
				dCTypeInfo.IsDelegate = true;
				MethodInfo method = type_0.GetMethod("Invoke");
				if (method != null)
				{
					dCTypeInfo.DelegateReturnType = LoadType(assembly_0, method.ReturnType, relationMode);
					dCTypeInfo.DelegateParameters = new DCParameterInfoList();
					LoadParametersInfo(assembly_0, dCTypeInfo.DelegateParameters, method.GetParameters());
				}
			}
			if (type_0.IsArray)
			{
				dCTypeInfo.CollectionItemType = LoadType(assembly_0, type_0.GetElementType(), relationMode: true);
			}
			else
			{
				Type collectionItemType = DesignUtils.GetCollectionItemType(type_0, checkAddMethod: true);
				if (collectionItemType != null)
				{
					dCTypeInfo.CollectionItemType = LoadType(assembly_0, collectionItemType, relationMode: true);
				}
			}
			dCTypeInfo.Image = DesignUtils.GetToolboxImage(type_0);
			if (!dCTypeInfo.IsArray && !dCTypeInfo.IsDelegate && (LoadFlags & DCTypeLoadFlags.ExcludeTypeMember) != DCTypeLoadFlags.ExcludeTypeMember)
			{
				MemberInfo[] defaultMembers = type_0.GetDefaultMembers();
				MemberInfo[] array2 = null;
				array2 = (((LoadFlags & DCTypeLoadFlags.LoadDeclaredOnlyMember) != DCTypeLoadFlags.LoadDeclaredOnlyMember) ? type_0.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public) : type_0.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public));
				MemberInfo[] array3 = array2;
				foreach (MemberInfo memberInfo in array3)
				{
					if (((LoadFlags & DCTypeLoadFlags.ExcludeMemberEvent) == DCTypeLoadFlags.ExcludeMemberEvent && memberInfo is EventInfo) || ((LoadFlags & DCTypeLoadFlags.ExcludeMemberField) == DCTypeLoadFlags.ExcludeMemberField && memberInfo is FieldInfo) || ((LoadFlags & DCTypeLoadFlags.ExcludeMemberMethod) == DCTypeLoadFlags.ExcludeMemberMethod && memberInfo is MethodInfo) || ((LoadFlags & DCTypeLoadFlags.ExcludeMemberProperty) == DCTypeLoadFlags.ExcludeMemberProperty && memberInfo is PropertyInfo))
					{
						continue;
					}
					bool isDefault = false;
					BooleanValue comVisible = BooleanValue.Default;
					if (!(comVisibleAttribute?.Value ?? true))
					{
						comVisible = BooleanValue.False;
					}
					else
					{
						try
						{
							ComVisibleAttribute comVisibleAttribute2 = (ComVisibleAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(ComVisibleAttribute), inherit: true);
							if (comVisibleAttribute2 != null)
							{
								comVisible = ((!comVisibleAttribute2.Value) ? BooleanValue.False : BooleanValue.True);
							}
						}
						catch
						{
							comVisible = BooleanValue.Default;
						}
					}
					int dISPID = int.MinValue;
					if (comVisibleAttribute?.Value ?? true)
					{
						try
						{
							DispIdAttribute dispIdAttribute = (DispIdAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(DispIdAttribute), inherit: true);
							if (dispIdAttribute != null)
							{
								dISPID = dispIdAttribute.Value;
							}
						}
						catch
						{
							dISPID = int.MinValue;
						}
					}
					if (defaultMembers != null)
					{
						MemberInfo[] array4 = defaultMembers;
						foreach (MemberInfo memberInfo2 in array4)
						{
							if (memberInfo == memberInfo2)
							{
								isDefault = true;
								break;
							}
						}
					}
					if (memberInfo is MethodInfo)
					{
						if (!memberInfo.Name.StartsWith("get_") && !memberInfo.Name.StartsWith("set_") && !memberInfo.Name.StartsWith("add_") && !memberInfo.Name.StartsWith("remove_") && !memberInfo.Name.StartsWith("op_"))
						{
							MethodInfo methodInfo = (MethodInfo)memberInfo;
							DCMethodInfo dCMethodInfo = new DCMethodInfo();
							dCMethodInfo.SetAttributeTypeNames(memberInfo);
							dCMethodInfo.DISPID = dISPID;
							dCMethodInfo.Name = methodInfo.Name;
							dCMethodInfo.IsDefault = isDefault;
							dCMethodInfo.ComVisible = comVisible;
							dCMethodInfo.MetadataToken = memberInfo.MetadataToken;
							dCMethodInfo.DeclaringType = LoadType(assembly_0, memberInfo.DeclaringType, relationMode);
							dCMethodInfo.Description = DesignUtils.GetDescription(memberInfo);
							dCMethodInfo.Browsable = DesignUtils.GetBrowsable(memberInfo);
							dCMethodInfo.DisplayName = DesignUtils.GetDisplayName(memberInfo);
							dCMethodInfo.IsAbstract = methodInfo.IsAbstract;
							dCMethodInfo.IsAssembly = methodInfo.IsAssembly;
							dCMethodInfo.IsConstructor = methodInfo.IsConstructor;
							dCMethodInfo.IsFamily = methodInfo.IsFamily;
							dCMethodInfo.IsFinal = methodInfo.IsFinal;
							dCMethodInfo.IsPrivate = methodInfo.IsPrivate;
							dCMethodInfo.IsPublic = methodInfo.IsPublic;
							dCMethodInfo.IsSpecialName = methodInfo.IsSpecialName;
							dCMethodInfo.IsVirtual = methodInfo.IsVirtual;
							dCMethodInfo.ReturnType = LoadType(assembly_0, methodInfo.ReturnType, relationMode: true);
							dCMethodInfo.Parameters = new DCParameterInfoList();
							LoadParametersInfo(assembly_0, dCMethodInfo.Parameters, methodInfo.GetParameters());
							dCTypeInfo.Members.Add(dCMethodInfo);
						}
					}
					else if (memberInfo is EventInfo)
					{
						EventInfo eventInfo = (EventInfo)memberInfo;
						DCEventInfo dCEventInfo = new DCEventInfo();
						dCEventInfo.SetAttributeTypeNames(memberInfo);
						dCEventInfo.DISPID = dISPID;
						dCEventInfo.Name = eventInfo.Name;
						dCEventInfo.IsDefault = isDefault;
						dCEventInfo.ComVisible = comVisible;
						dCEventInfo.MetadataToken = memberInfo.MetadataToken;
						dCEventInfo.DeclaringType = LoadType(assembly_0, memberInfo.DeclaringType, relationMode);
						dCEventInfo.Description = DesignUtils.GetDescription(eventInfo);
						dCEventInfo.Browsable = DesignUtils.GetBrowsable(eventInfo);
						dCEventInfo.DisplayName = DesignUtils.GetDisplayName(memberInfo);
						dCEventInfo.IsMulticast = eventInfo.IsMulticast;
						dCEventInfo.IsSpecialName = eventInfo.IsSpecialName;
						dCEventInfo.EventHandlerType = LoadType(assembly_0, eventInfo.EventHandlerType, relationMode: true);
						dCTypeInfo.Members.Add(dCEventInfo);
					}
					else if (memberInfo is FieldInfo)
					{
						if (!type_0.IsEnum || !(memberInfo.Name == "value__"))
						{
							FieldInfo fieldInfo = (FieldInfo)memberInfo;
							DCFieldInfo dCFieldInfo = new DCFieldInfo();
							dCFieldInfo.SetAttributeTypeNames(memberInfo);
							dCFieldInfo.DISPID = dISPID;
							dCFieldInfo.Name = fieldInfo.Name;
							dCFieldInfo.IsDefault = isDefault;
							dCFieldInfo.ComVisible = comVisible;
							dCFieldInfo.MetadataToken = memberInfo.MetadataToken;
							dCFieldInfo.DeclaringType = LoadType(assembly_0, memberInfo.DeclaringType, relationMode);
							dCFieldInfo.Description = DesignUtils.GetDescription(memberInfo);
							dCFieldInfo.Browsable = DesignUtils.GetBrowsable(memberInfo);
							dCFieldInfo.DisplayName = DesignUtils.GetDisplayName(memberInfo);
							dCFieldInfo.FieldType = LoadType(assembly_0, fieldInfo.FieldType, relationMode: true);
							dCFieldInfo.IsAssembly = fieldInfo.IsAssembly;
							dCFieldInfo.IsFamily = fieldInfo.IsFamily;
							dCFieldInfo.IsInitOnly = fieldInfo.IsInitOnly;
							dCFieldInfo.IsLiteral = fieldInfo.IsLiteral;
							dCFieldInfo.IsNoSerialized = fieldInfo.IsNotSerialized;
							dCFieldInfo.IsPinvokeImpl = fieldInfo.IsPinvokeImpl;
							dCFieldInfo.IsPrivate = fieldInfo.IsPrivate;
							dCFieldInfo.IsPublic = fieldInfo.IsPublic;
							dCFieldInfo.IsSpecialName = fieldInfo.IsSpecialName;
							dCFieldInfo.IsStatic = fieldInfo.IsStatic;
							if (type_0.IsEnum)
							{
								dCFieldInfo.FieldType = dCTypeInfo;
								try
								{
									dCFieldInfo.EnumItemValue = (int)fieldInfo.GetValue(null);
								}
								catch
								{
									dCFieldInfo.EnumItemValue = -10000;
								}
							}
							else
							{
								dCFieldInfo.FieldType = LoadType(assembly_0, fieldInfo.FieldType, relationMode: true);
							}
							dCTypeInfo.Members.Add(dCFieldInfo);
						}
					}
					else if (memberInfo is PropertyInfo)
					{
						PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
						DCPropertyInfo dCPropertyInfo = new DCPropertyInfo();
						dCPropertyInfo.SetAttributeTypeNames(memberInfo);
						dCPropertyInfo.DISPID = dISPID;
						dCPropertyInfo.IsDefault = isDefault;
						dCPropertyInfo.Name = propertyInfo.Name;
						dCPropertyInfo.MetadataToken = memberInfo.MetadataToken;
						dCPropertyInfo.ComVisible = comVisible;
						dCPropertyInfo.DeclaringType = LoadType(assembly_0, memberInfo.DeclaringType, relationMode);
						dCPropertyInfo.Description = DesignUtils.GetDescription(memberInfo);
						dCPropertyInfo.Browsable = DesignUtils.GetBrowsable(memberInfo);
						dCPropertyInfo.DisplayName = DesignUtils.GetDisplayName(memberInfo);
						dCPropertyInfo.CanRead = propertyInfo.CanRead;
						dCPropertyInfo.CanWrite = propertyInfo.CanWrite;
						dCPropertyInfo.IsSpecialName = propertyInfo.IsSpecialName;
						dCPropertyInfo.PropertyType = LoadType(assembly_0, propertyInfo.PropertyType, relationMode: true);
						dCPropertyInfo.PropertyTypeFullName = DesignUtils.GetTypeFullName(propertyInfo.PropertyType);
						dCPropertyInfo.ValuePrimitiveType = GetPrimitiveType(propertyInfo.PropertyType);
						dCPropertyInfo.IsCollection = DesignUtils.IsCollectionProperty(propertyInfo);
						MethodInfo methodInfo2 = propertyInfo.GetGetMethod();
						if (methodInfo2 == null)
						{
							methodInfo2 = propertyInfo.GetSetMethod();
						}
						dCPropertyInfo.IsPublic = methodInfo2.IsPublic;
						dCPropertyInfo.IsPrivate = methodInfo2.IsPrivate;
						dCPropertyInfo.IsAssembly = methodInfo2.IsAssembly;
						dCPropertyInfo.IsAbstract = methodInfo2.IsAbstract;
						dCPropertyInfo.IsFamily = methodInfo2.IsFamily;
						dCPropertyInfo.IsVirtual = methodInfo2.IsVirtual;
						dCPropertyInfo.IsStatic = methodInfo2.IsStatic;
						dCPropertyInfo.IsFinal = methodInfo2.IsFinal;
						dCPropertyInfo.IndexParameters = new DCParameterInfoList();
						LoadParametersInfo(assembly_0, dCPropertyInfo.IndexParameters, propertyInfo.GetIndexParameters());
						dCTypeInfo.Members.Add(dCPropertyInfo);
					}
				}
				dCTypeInfo.Members.Sort(new MemberComparer());
			}
			return dCTypeInfo;
		}

		                                                                    /// <summary>
		                                                                    ///       判断是否忽略掉该程序集
		                                                                    ///       </summary>
		                                                                    /// <param name="asm">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		private bool IsExlude(Assembly assembly_0)
		{
			int num = 2;
			if ((LoadFlags & DCTypeLoadFlags.ExcludeStdAssembly) == DCTypeLoadFlags.ExcludeStdAssembly && DesignUtils.IsStdAssembly(assembly_0))
			{
				return true;
			}
			if ((LoadFlags & DCTypeLoadFlags.ExcludeResourceAssembly) == DCTypeLoadFlags.ExcludeResourceAssembly)
			{
				string name = assembly_0.GetName().Name;
				if (!string.IsNullOrEmpty(name) && name.EndsWith(".resources", StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		public static PrimitiveTypeConsts GetPrimitiveType(Type type_0)
		{
			if (type_0 == null)
			{
				return PrimitiveTypeConsts.Object;
			}
			if (type_0.Equals(typeof(object)))
			{
				return PrimitiveTypeConsts.Object;
			}
			if (type_0.Equals(typeof(bool)))
			{
				return PrimitiveTypeConsts.Boolean;
			}
			if (type_0.Equals(typeof(char)))
			{
				return PrimitiveTypeConsts.Char;
			}
			if (type_0.Equals(typeof(byte)))
			{
				return PrimitiveTypeConsts.Byte;
			}
			if (type_0.Equals(typeof(sbyte)))
			{
				return PrimitiveTypeConsts.SByte;
			}
			if (type_0.Equals(typeof(short)))
			{
				return PrimitiveTypeConsts.Int16;
			}
			if (type_0.Equals(typeof(ushort)))
			{
				return PrimitiveTypeConsts.UInt16;
			}
			if (type_0.Equals(typeof(int)))
			{
				return PrimitiveTypeConsts.Int32;
			}
			if (type_0.Equals(typeof(uint)))
			{
				return PrimitiveTypeConsts.UInt32;
			}
			if (type_0.Equals(typeof(long)))
			{
				return PrimitiveTypeConsts.Int64;
			}
			if (type_0.Equals(typeof(ulong)))
			{
				return PrimitiveTypeConsts.UInt64;
			}
			if (type_0.Equals(typeof(decimal)))
			{
				return PrimitiveTypeConsts.Decimal;
			}
			if (type_0.Equals(typeof(float)))
			{
				return PrimitiveTypeConsts.Single;
			}
			if (type_0.Equals(typeof(double)))
			{
				return PrimitiveTypeConsts.Double;
			}
			if (type_0.Equals(typeof(void)))
			{
				return PrimitiveTypeConsts.Void;
			}
			if (type_0.Equals(typeof(string)))
			{
				return PrimitiveTypeConsts.String;
			}
			if (type_0.Equals(typeof(object)))
			{
				return PrimitiveTypeConsts.Object;
			}
			if (type_0.Equals(typeof(DateTime)))
			{
				return PrimitiveTypeConsts.DateTime;
			}
			if (type_0.Equals(typeof(byte[])))
			{
				return PrimitiveTypeConsts.Binary;
			}
			return PrimitiveTypeConsts.Custom;
		}

		private DCTypeInfo GetTypeByID(string string_0)
		{
			int num = 15;
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			int num2 = string_0.IndexOf(",");
			if (num2 > 0)
			{
				string strB = string_0.Substring(0, num2);
				string strB2 = string_0.Substring(num2 + 1);
				foreach (DCAssemblyInfo assembly in Assemblies)
				{
					if (string.Compare(assembly.Name, strB2, ignoreCase: true) == 0)
					{
						foreach (DCTypeInfo type in assembly.Types)
						{
							if (string.Compare(type.FullName, strB, ignoreCase: true) == 0)
							{
								return type;
							}
						}
					}
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       加载参数信息
		                                                                    ///       </summary>
		                                                                    /// <param name="infos">
		                                                                    /// </param>
		                                                                    /// <param name="ps">
		                                                                    /// </param>
		private void LoadParametersInfo(Assembly assembly_0, List<DCParameterInfo> infos, ParameterInfo[] parameterInfo_0)
		{
			if (parameterInfo_0 != null && parameterInfo_0.Length > 0)
			{
				foreach (ParameterInfo parameterInfo in parameterInfo_0)
				{
					DCParameterInfo dCParameterInfo = new DCParameterInfo();
					dCParameterInfo.Name = parameterInfo.Name;
					dCParameterInfo.IsIn = parameterInfo.IsIn;
					dCParameterInfo.IsOut = parameterInfo.IsOut;
					dCParameterInfo.IsRetval = parameterInfo.IsRetval;
					dCParameterInfo.IsLcid = parameterInfo.IsLcid;
					dCParameterInfo.ParameterType = LoadType(assembly_0, parameterInfo.ParameterType, relationMode: true);
					dCParameterInfo.Position = parameterInfo.Position;
					infos.Add(dCParameterInfo);
				}
			}
		}
	}
}
