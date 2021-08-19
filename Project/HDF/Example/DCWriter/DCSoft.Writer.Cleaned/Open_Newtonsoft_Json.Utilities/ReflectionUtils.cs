using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class ReflectionUtils
	{
		public static readonly Type[] EmptyTypes;

		static ReflectionUtils()
		{
			EmptyTypes = Type.EmptyTypes;
		}

		public static bool IsVirtual(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			MethodInfo getMethod = propertyInfo.GetGetMethod();
			if (getMethod != null && getMethod.IsVirtual)
			{
				return true;
			}
			getMethod = propertyInfo.GetSetMethod();
			if (getMethod != null && getMethod.IsVirtual)
			{
				return true;
			}
			return false;
		}

		public static MethodInfo GetBaseDefinition(PropertyInfo propertyInfo)
		{
			ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
			MethodInfo getMethod = propertyInfo.GetGetMethod();
			if (getMethod != null)
			{
				return getMethod.GetBaseDefinition();
			}
			return propertyInfo.GetSetMethod()?.GetBaseDefinition();
		}

		public static bool IsPublic(PropertyInfo property)
		{
			if (property.GetGetMethod() != null && property.GetGetMethod().IsPublic)
			{
				return true;
			}
			if (property.GetSetMethod() != null && property.GetSetMethod().IsPublic)
			{
				return true;
			}
			return false;
		}

		public static Type GetObjectType(object object_0)
		{
			return object_0?.GetType();
		}

		public static string GetTypeName(Type type_0, FormatterAssemblyStyle assemblyFormat, SerializationBinder binder)
		{
			string assemblyQualifiedName = type_0.AssemblyQualifiedName;
			switch (assemblyFormat)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case FormatterAssemblyStyle.Simple:
				return RemoveAssemblyDetails(assemblyQualifiedName);
			case FormatterAssemblyStyle.Full:
				return assemblyQualifiedName;
			}
		}

		private static string RemoveAssemblyDetails(string fullyQualifiedTypeName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			bool flag2 = false;
			foreach (char c in fullyQualifiedTypeName)
			{
				switch (c)
				{
				case '[':
					flag = false;
					flag2 = false;
					stringBuilder.Append(c);
					break;
				default:
					if (!flag2)
					{
						stringBuilder.Append(c);
					}
					break;
				case ']':
					flag = false;
					flag2 = false;
					stringBuilder.Append(c);
					break;
				case ',':
					if (!flag)
					{
						flag = true;
						stringBuilder.Append(c);
					}
					else
					{
						flag2 = true;
					}
					break;
				}
			}
			return stringBuilder.ToString();
		}

		public static bool HasDefaultConstructor(Type type_0, bool nonPublic)
		{
			ValidationUtils.ArgumentNotNull(type_0, "t");
			if (TypeExtensions.IsValueType(type_0))
			{
				return true;
			}
			return GetDefaultConstructor(type_0, nonPublic) != null;
		}

		public static ConstructorInfo GetDefaultConstructor(Type type_0)
		{
			return GetDefaultConstructor(type_0, nonPublic: false);
		}

		public static ConstructorInfo GetDefaultConstructor(Type type_0, bool nonPublic)
		{
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
			if (nonPublic)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			return Enumerable.SingleOrDefault(type_0.GetConstructors(bindingFlags), (ConstructorInfo constructorInfo_0) => !Enumerable.Any(constructorInfo_0.GetParameters()));
		}

		public static bool IsNullable(Type type_0)
		{
			ValidationUtils.ArgumentNotNull(type_0, "t");
			if (TypeExtensions.IsValueType(type_0))
			{
				return IsNullableType(type_0);
			}
			return true;
		}

		public static bool IsNullableType(Type type_0)
		{
			ValidationUtils.ArgumentNotNull(type_0, "t");
			return TypeExtensions.IsGenericType(type_0) && type_0.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		public static Type EnsureNotNullableType(Type type_0)
		{
			return IsNullableType(type_0) ? Nullable.GetUnderlyingType(type_0) : type_0;
		}

		public static bool IsGenericDefinition(Type type, Type genericInterfaceDefinition)
		{
			if (!TypeExtensions.IsGenericType(type))
			{
				return false;
			}
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			return genericTypeDefinition == genericInterfaceDefinition;
		}

		public static bool ImplementsGenericDefinition(Type type, Type genericInterfaceDefinition)
		{
			Type implementingType;
			return ImplementsGenericDefinition(type, genericInterfaceDefinition, out implementingType);
		}

		public static bool ImplementsGenericDefinition(Type type, Type genericInterfaceDefinition, out Type implementingType)
		{
			int num = 11;
			ValidationUtils.ArgumentNotNull(type, "type");
			ValidationUtils.ArgumentNotNull(genericInterfaceDefinition, "genericInterfaceDefinition");
			if (!TypeExtensions.IsInterface(genericInterfaceDefinition) || !TypeExtensions.IsGenericTypeDefinition(genericInterfaceDefinition))
			{
				throw new ArgumentNullException(StringUtils.FormatWith("'{0}' is not a generic interface definition.", CultureInfo.InvariantCulture, genericInterfaceDefinition));
			}
			if (TypeExtensions.IsInterface(type) && TypeExtensions.IsGenericType(type))
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				if (genericInterfaceDefinition == genericTypeDefinition)
				{
					implementingType = type;
					return true;
				}
			}
			Type[] interfaces = type.GetInterfaces();
			int num2 = 0;
			Type type2;
			while (true)
			{
				if (num2 < interfaces.Length)
				{
					type2 = interfaces[num2];
					if (TypeExtensions.IsGenericType(type2))
					{
						Type genericTypeDefinition = type2.GetGenericTypeDefinition();
						if (genericInterfaceDefinition == genericTypeDefinition)
						{
							break;
						}
					}
					num2++;
					continue;
				}
				implementingType = null;
				return false;
			}
			implementingType = type2;
			return true;
		}

		public static bool InheritsGenericDefinition(Type type, Type genericClassDefinition)
		{
			Type implementingType;
			return InheritsGenericDefinition(type, genericClassDefinition, out implementingType);
		}

		public static bool InheritsGenericDefinition(Type type, Type genericClassDefinition, out Type implementingType)
		{
			int num = 3;
			ValidationUtils.ArgumentNotNull(type, "type");
			ValidationUtils.ArgumentNotNull(genericClassDefinition, "genericClassDefinition");
			if (!TypeExtensions.IsClass(genericClassDefinition) || !TypeExtensions.IsGenericTypeDefinition(genericClassDefinition))
			{
				throw new ArgumentNullException(StringUtils.FormatWith("'{0}' is not a generic class definition.", CultureInfo.InvariantCulture, genericClassDefinition));
			}
			return InheritsGenericDefinitionInternal(type, genericClassDefinition, out implementingType);
		}

		private static bool InheritsGenericDefinitionInternal(Type currentType, Type genericClassDefinition, out Type implementingType)
		{
			if (TypeExtensions.IsGenericType(currentType))
			{
				Type genericTypeDefinition = currentType.GetGenericTypeDefinition();
				if (genericClassDefinition == genericTypeDefinition)
				{
					implementingType = currentType;
					return true;
				}
			}
			if (TypeExtensions.BaseType(currentType) == null)
			{
				implementingType = null;
				return false;
			}
			return InheritsGenericDefinitionInternal(TypeExtensions.BaseType(currentType), genericClassDefinition, out implementingType);
		}

		/// <summary>
		///       Gets the type of the typed collection's items.
		///       </summary>
		/// <param name="type">The type.</param>
		/// <returns>The type of the typed collection's items.</returns>
		public static Type GetCollectionItemType(Type type)
		{
			int num = 9;
			ValidationUtils.ArgumentNotNull(type, "type");
			if (type.IsArray)
			{
				return type.GetElementType();
			}
			if (ImplementsGenericDefinition(type, typeof(IEnumerable<>), out Type implementingType))
			{
				if (TypeExtensions.IsGenericTypeDefinition(implementingType))
				{
					throw new Exception(StringUtils.FormatWith("Type {0} is not a collection.", CultureInfo.InvariantCulture, type));
				}
				return implementingType.GetGenericArguments()[0];
			}
			if (typeof(IEnumerable).IsAssignableFrom(type))
			{
				return null;
			}
			throw new Exception(StringUtils.FormatWith("Type {0} is not a collection.", CultureInfo.InvariantCulture, type));
		}

		public static void GetDictionaryKeyValueTypes(Type dictionaryType, out Type keyType, out Type valueType)
		{
			int num = 2;
			ValidationUtils.ArgumentNotNull(dictionaryType, "type");
			if (ImplementsGenericDefinition(dictionaryType, typeof(IDictionary<, >), out Type implementingType))
			{
				if (TypeExtensions.IsGenericTypeDefinition(implementingType))
				{
					throw new Exception(StringUtils.FormatWith("Type {0} is not a dictionary.", CultureInfo.InvariantCulture, dictionaryType));
				}
				Type[] genericArguments = implementingType.GetGenericArguments();
				keyType = genericArguments[0];
				valueType = genericArguments[1];
			}
			else
			{
				if (!typeof(IDictionary).IsAssignableFrom(dictionaryType))
				{
					throw new Exception(StringUtils.FormatWith("Type {0} is not a dictionary.", CultureInfo.InvariantCulture, dictionaryType));
				}
				keyType = null;
				valueType = null;
			}
		}

		/// <summary>
		///       Gets the member's underlying type.
		///       </summary>
		/// <param name="member">The member.</param>
		/// <returns>The underlying type of the member.</returns>
		public static Type GetMemberUnderlyingType(MemberInfo member)
		{
			int num = 17;
			ValidationUtils.ArgumentNotNull(member, "member");
			switch (TypeExtensions.MemberType(member))
			{
			case MemberTypes.Property:
				return ((PropertyInfo)member).PropertyType;
			case MemberTypes.Method:
				return ((MethodInfo)member).ReturnType;
			case MemberTypes.Event:
				return ((EventInfo)member).EventHandlerType;
			default:
				throw new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo, EventInfo or MethodInfo", "member");
			case MemberTypes.Field:
				return ((FieldInfo)member).FieldType;
			}
		}

		/// <summary>
		///       Determines whether the member is an indexed property.
		///       </summary>
		/// <param name="member">The member.</param>
		/// <returns>
		///   <c>true</c> if the member is an indexed property; otherwise, <c>false</c>.
		///       </returns>
		public static bool IsIndexedProperty(MemberInfo member)
		{
			ValidationUtils.ArgumentNotNull(member, "member");
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				return IsIndexedProperty(propertyInfo);
			}
			return false;
		}

		/// <summary>
		///       Determines whether the property is an indexed property.
		///       </summary>
		/// <param name="property">The property.</param>
		/// <returns>
		///   <c>true</c> if the property is an indexed property; otherwise, <c>false</c>.
		///       </returns>
		public static bool IsIndexedProperty(PropertyInfo property)
		{
			ValidationUtils.ArgumentNotNull(property, "property");
			return property.GetIndexParameters().Length > 0;
		}

		/// <summary>
		///       Gets the member's value on the object.
		///       </summary>
		/// <param name="member">The member.</param>
		/// <param name="target">The target object.</param>
		/// <returns>The member's value on the object.</returns>
		public static object GetMemberValue(MemberInfo member, object target)
		{
			int num = 8;
			ValidationUtils.ArgumentNotNull(member, "member");
			ValidationUtils.ArgumentNotNull(target, "target");
			switch (TypeExtensions.MemberType(member))
			{
			default:
				throw new ArgumentException(StringUtils.FormatWith("MemberInfo '{0}' is not of type FieldInfo or PropertyInfo", CultureInfo.InvariantCulture, CultureInfo.InvariantCulture, member.Name), "member");
			case MemberTypes.Property:
				try
				{
					return ((PropertyInfo)member).GetValue(target, null);
				}
				catch (TargetParameterCountException innerException)
				{
					throw new ArgumentException(StringUtils.FormatWith("MemberInfo '{0}' has index parameters", CultureInfo.InvariantCulture, member.Name), innerException);
				}
			case MemberTypes.Field:
				return ((FieldInfo)member).GetValue(target);
			}
		}

		/// <summary>
		///       Sets the member's value on the target object.
		///       </summary>
		/// <param name="member">The member.</param>
		/// <param name="target">The target.</param>
		/// <param name="value">The value.</param>
		public static void SetMemberValue(MemberInfo member, object target, object value)
		{
			int num = 6;
			ValidationUtils.ArgumentNotNull(member, "member");
			ValidationUtils.ArgumentNotNull(target, "target");
			switch (TypeExtensions.MemberType(member))
			{
			default:
				throw new ArgumentException(StringUtils.FormatWith("MemberInfo '{0}' must be of type FieldInfo or PropertyInfo", CultureInfo.InvariantCulture, member.Name), "member");
			case MemberTypes.Property:
				((PropertyInfo)member).SetValue(target, value, null);
				break;
			case MemberTypes.Field:
				((FieldInfo)member).SetValue(target, value);
				break;
			}
		}

		/// <summary>
		///       Determines whether the specified MemberInfo can be read.
		///       </summary>
		/// <param name="member">The MemberInfo to determine whether can be read.</param>
		///       /// <param name="nonPublic">if set to <c>true</c> then allow the member to be gotten non-publicly.</param><returns><c>true</c> if the specified MemberInfo can be read; otherwise, <c>false</c>.
		///       </returns>
		public static bool CanReadMemberValue(MemberInfo member, bool nonPublic)
		{
			switch (TypeExtensions.MemberType(member))
			{
			default:
				return false;
			case MemberTypes.Property:
			{
				PropertyInfo propertyInfo = (PropertyInfo)member;
				if (!propertyInfo.CanRead)
				{
					return false;
				}
				if (nonPublic)
				{
					return true;
				}
				return propertyInfo.GetGetMethod(nonPublic) != null;
			}
			case MemberTypes.Field:
			{
				FieldInfo fieldInfo = (FieldInfo)member;
				if (nonPublic)
				{
					return true;
				}
				if (fieldInfo.IsPublic)
				{
					return true;
				}
				return false;
			}
			}
		}

		/// <summary>
		///       Determines whether the specified MemberInfo can be set.
		///       </summary>
		/// <param name="member">The MemberInfo to determine whether can be set.</param>
		/// <param name="nonPublic">if set to <c>true</c> then allow the member to be set non-publicly.</param>
		/// <param name="canSetReadOnly">if set to <c>true</c> then allow the member to be set if read-only.</param>
		/// <returns>
		///   <c>true</c> if the specified MemberInfo can be set; otherwise, <c>false</c>.
		///       </returns>
		public static bool CanSetMemberValue(MemberInfo member, bool nonPublic, bool canSetReadOnly)
		{
			switch (TypeExtensions.MemberType(member))
			{
			default:
				return false;
			case MemberTypes.Property:
			{
				PropertyInfo propertyInfo = (PropertyInfo)member;
				if (!propertyInfo.CanWrite)
				{
					return false;
				}
				if (nonPublic)
				{
					return true;
				}
				return propertyInfo.GetSetMethod(nonPublic) != null;
			}
			case MemberTypes.Field:
			{
				FieldInfo fieldInfo = (FieldInfo)member;
				if (fieldInfo.IsLiteral)
				{
					return false;
				}
				if (fieldInfo.IsInitOnly && !canSetReadOnly)
				{
					return false;
				}
				if (nonPublic)
				{
					return true;
				}
				if (fieldInfo.IsPublic)
				{
					return true;
				}
				return false;
			}
			}
		}

		public static List<MemberInfo> GetFieldsAndProperties(Type type, BindingFlags bindingAttr)
		{
			int num = 9;
			List<MemberInfo> list = new List<MemberInfo>();
			CollectionUtils.AddRange(list, GetFields(type, bindingAttr));
			CollectionUtils.AddRange(list, GetProperties(type, bindingAttr));
			List<MemberInfo> list2 = new List<MemberInfo>(list.Count);
			foreach (IGrouping<string, MemberInfo> item in Enumerable.GroupBy(list, (MemberInfo memberInfo_0) => memberInfo_0.Name))
			{
				int num2 = Enumerable.Count(item);
				IList<MemberInfo> list3 = Enumerable.ToList(item);
				if (num2 == 1)
				{
					list2.Add(Enumerable.First(list3));
				}
				else
				{
					IList<MemberInfo> list4 = new List<MemberInfo>();
					foreach (MemberInfo item2 in list3)
					{
						if (list4.Count == 0)
						{
							list4.Add(item2);
						}
						else if (!IsOverridenGenericMember(item2, bindingAttr) || item2.Name == "Item")
						{
							list4.Add(item2);
						}
					}
					list2.AddRange(list4);
				}
			}
			return list2;
		}

		private static bool IsOverridenGenericMember(MemberInfo memberInfo, BindingFlags bindingAttr)
		{
			if (TypeExtensions.MemberType(memberInfo) != MemberTypes.Property)
			{
				return false;
			}
			PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
			if (!IsVirtual(propertyInfo))
			{
				return false;
			}
			Type declaringType = propertyInfo.DeclaringType;
			if (!TypeExtensions.IsGenericType(declaringType))
			{
				return false;
			}
			Type genericTypeDefinition = declaringType.GetGenericTypeDefinition();
			if (genericTypeDefinition == null)
			{
				return false;
			}
			MemberInfo[] member = genericTypeDefinition.GetMember(propertyInfo.Name, bindingAttr);
			if (member.Length == 0)
			{
				return false;
			}
			Type memberUnderlyingType = GetMemberUnderlyingType(member[0]);
			if (!memberUnderlyingType.IsGenericParameter)
			{
				return false;
			}
			return true;
		}

		public static T GetAttribute<T>(object attributeProvider) where T : Attribute
		{
			return GetAttribute<T>(attributeProvider, inherit: true);
		}

		public static T GetAttribute<T>(object attributeProvider, bool inherit) where T : Attribute
		{
			T[] attributes = GetAttributes<T>(attributeProvider, inherit);
			return (attributes != null) ? Enumerable.FirstOrDefault(attributes) : null;
		}

		public static T[] GetAttributes<T>(object attributeProvider, bool inherit) where T : Attribute
		{
			Attribute[] attributes = GetAttributes(attributeProvider, typeof(T), inherit);
			T[] array = attributes as T[];
			if (array != null)
			{
				return array;
			}
			return Enumerable.ToArray(Enumerable.Cast<T>(attributes));
		}

		public static Attribute[] GetAttributes(object attributeProvider, Type attributeType, bool inherit)
		{
			ValidationUtils.ArgumentNotNull(attributeProvider, "attributeProvider");
			if (attributeProvider is Type)
			{
				Type type = (Type)attributeProvider;
				object[] source = (attributeType != null) ? type.GetCustomAttributes(attributeType, inherit) : type.GetCustomAttributes(inherit);
				Attribute[] array = Enumerable.ToArray(Enumerable.Cast<Attribute>(source));
				if (inherit && type.BaseType != null)
				{
					array = Enumerable.ToArray(Enumerable.Union(array, GetAttributes(type.BaseType, attributeType, inherit)));
				}
				return array;
			}
			if (attributeProvider is Assembly)
			{
				Assembly element = (Assembly)attributeProvider;
				return (attributeType != null) ? Attribute.GetCustomAttributes(element, attributeType) : Attribute.GetCustomAttributes(element);
			}
			if (attributeProvider is MemberInfo)
			{
				MemberInfo element2 = (MemberInfo)attributeProvider;
				return (attributeType != null) ? Attribute.GetCustomAttributes(element2, attributeType, inherit) : Attribute.GetCustomAttributes(element2, inherit);
			}
			if (attributeProvider is Module)
			{
				Module element3 = (Module)attributeProvider;
				return (attributeType != null) ? Attribute.GetCustomAttributes(element3, attributeType, inherit) : Attribute.GetCustomAttributes(element3, inherit);
			}
			if (attributeProvider is ParameterInfo)
			{
				ParameterInfo element4 = (ParameterInfo)attributeProvider;
				return (attributeType != null) ? Attribute.GetCustomAttributes(element4, attributeType, inherit) : Attribute.GetCustomAttributes(element4, inherit);
			}
			ICustomAttributeProvider customAttributeProvider = (ICustomAttributeProvider)attributeProvider;
			object[] array2 = (attributeType != null) ? customAttributeProvider.GetCustomAttributes(attributeType, inherit) : customAttributeProvider.GetCustomAttributes(inherit);
			return (Attribute[])array2;
		}

		public static void SplitFullyQualifiedTypeName(string fullyQualifiedTypeName, out string typeName, out string assemblyName)
		{
			int? assemblyDelimiterIndex = GetAssemblyDelimiterIndex(fullyQualifiedTypeName);
			if (assemblyDelimiterIndex.HasValue)
			{
				typeName = fullyQualifiedTypeName.Substring(0, assemblyDelimiterIndex.Value).Trim();
				assemblyName = fullyQualifiedTypeName.Substring(assemblyDelimiterIndex.Value + 1, fullyQualifiedTypeName.Length - assemblyDelimiterIndex.Value - 1).Trim();
			}
			else
			{
				typeName = fullyQualifiedTypeName;
				assemblyName = null;
			}
		}

		private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName)
		{
			int num = 0;
			for (int i = 0; i < fullyQualifiedTypeName.Length; i++)
			{
				switch (fullyQualifiedTypeName[i])
				{
				case '[':
					num++;
					break;
				case ']':
					num--;
					break;
				case ',':
					if (num == 0)
					{
						return i;
					}
					break;
				}
			}
			return null;
		}

		public static MemberInfo GetMemberInfoFromType(Type targetType, MemberInfo memberInfo)
		{
			MemberTypes memberTypes = TypeExtensions.MemberType(memberInfo);
			if (memberTypes != MemberTypes.Property)
			{
				return Enumerable.SingleOrDefault(targetType.GetMember(memberInfo.Name, TypeExtensions.MemberType(memberInfo), BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
			}
			PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
			Type[] types = Enumerable.ToArray(Enumerable.Select(propertyInfo.GetIndexParameters(), (ParameterInfo parameterInfo_0) => parameterInfo_0.ParameterType));
			return targetType.GetProperty(propertyInfo.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, propertyInfo.PropertyType, types, null);
		}

		public static IEnumerable<FieldInfo> GetFields(Type targetType, BindingFlags bindingAttr)
		{
			ValidationUtils.ArgumentNotNull(targetType, "targetType");
			List<MemberInfo> list = new List<MemberInfo>(targetType.GetFields(bindingAttr));
			GetChildPrivateFields(list, targetType, bindingAttr);
			return Enumerable.Cast<FieldInfo>(list);
		}

		private static void GetChildPrivateFields(IList<MemberInfo> initialFields, Type targetType, BindingFlags bindingAttr)
		{
			if ((bindingAttr & BindingFlags.NonPublic) != 0)
			{
				BindingFlags bindingAttr2 = RemoveFlag(bindingAttr, BindingFlags.Public);
				while ((targetType = TypeExtensions.BaseType(targetType)) != null)
				{
					IEnumerable<MemberInfo> collection = Enumerable.Cast<MemberInfo>(Enumerable.Where(targetType.GetFields(bindingAttr2), (FieldInfo fieldInfo_0) => fieldInfo_0.IsPrivate));
					CollectionUtils.AddRange(initialFields, collection);
				}
			}
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type targetType, BindingFlags bindingAttr)
		{
			ValidationUtils.ArgumentNotNull(targetType, "targetType");
			List<PropertyInfo> list = new List<PropertyInfo>(targetType.GetProperties(bindingAttr));
			if (TypeExtensions.IsInterface(targetType))
			{
				Type[] interfaces = targetType.GetInterfaces();
				foreach (Type type in interfaces)
				{
					list.AddRange(type.GetProperties(bindingAttr));
				}
			}
			GetChildPrivateProperties(list, targetType, bindingAttr);
			for (int j = 0; j < list.Count; j++)
			{
				PropertyInfo propertyInfo = list[j];
				if (propertyInfo.DeclaringType != targetType)
				{
					PropertyInfo propertyInfo3 = list[j] = (PropertyInfo)GetMemberInfoFromType(propertyInfo.DeclaringType, propertyInfo);
				}
			}
			return list;
		}

		public static BindingFlags RemoveFlag(BindingFlags bindingAttr, BindingFlags flag)
		{
			return ((bindingAttr & flag) == flag) ? (bindingAttr ^ flag) : bindingAttr;
		}

		private static void GetChildPrivateProperties(IList<PropertyInfo> initialProperties, Type targetType, BindingFlags bindingAttr)
		{
			while ((targetType = TypeExtensions.BaseType(targetType)) != null)
			{
				PropertyInfo[] properties = targetType.GetProperties(bindingAttr);
				foreach (PropertyInfo propertyInfo in properties)
				{
					PropertyInfo subTypeProperty = propertyInfo;
					if (!IsPublic(subTypeProperty))
					{
						int num = CollectionUtils.IndexOf(initialProperties, (PropertyInfo propertyInfo_0) => propertyInfo_0.Name == subTypeProperty.Name);
						if (num == -1)
						{
							initialProperties.Add(subTypeProperty);
							continue;
						}
						PropertyInfo property = initialProperties[num];
						if (!IsPublic(property))
						{
							initialProperties[num] = subTypeProperty;
						}
					}
					else if (!IsVirtual(subTypeProperty))
					{
						int num = CollectionUtils.IndexOf(initialProperties, (PropertyInfo propertyInfo_0) => propertyInfo_0.Name == subTypeProperty.Name && propertyInfo_0.DeclaringType == subTypeProperty.DeclaringType);
						if (num == -1)
						{
							initialProperties.Add(subTypeProperty);
						}
					}
					else
					{
						int num = CollectionUtils.IndexOf(initialProperties, (PropertyInfo propertyInfo_0) => propertyInfo_0.Name == subTypeProperty.Name && IsVirtual(propertyInfo_0) && GetBaseDefinition(propertyInfo_0) != null && GetBaseDefinition(propertyInfo_0).DeclaringType.IsAssignableFrom(subTypeProperty.DeclaringType));
						if (num == -1)
						{
							initialProperties.Add(subTypeProperty);
						}
					}
				}
			}
		}

		public static bool IsMethodOverridden(Type currentType, Type methodDeclaringType, string method)
		{
			return Enumerable.Any(currentType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), (MethodInfo info) => info.Name == method && info.DeclaringType != methodDeclaringType && info.GetBaseDefinition().DeclaringType == methodDeclaringType);
		}

		public static object GetDefaultValue(Type type)
		{
			if (!TypeExtensions.IsValueType(type))
			{
				return null;
			}
			switch (ConvertUtils.GetTypeCode(type))
			{
			case PrimitiveTypeCode.Decimal:
				return 0m;
			case PrimitiveTypeCode.Guid:
				return default(Guid);
			case PrimitiveTypeCode.Boolean:
				return false;
			case PrimitiveTypeCode.Char:
			case PrimitiveTypeCode.SByte:
			case PrimitiveTypeCode.Int16:
			case PrimitiveTypeCode.UInt16:
			case PrimitiveTypeCode.Int32:
			case PrimitiveTypeCode.Byte:
			case PrimitiveTypeCode.UInt32:
				return 0;
			case PrimitiveTypeCode.Int64:
			case PrimitiveTypeCode.UInt64:
				return 0L;
			case PrimitiveTypeCode.Single:
				return 0f;
			case PrimitiveTypeCode.Double:
				return 0.0;
			default:
				if (IsNullable(type))
				{
					return null;
				}
				return Activator.CreateInstance(type);
			case PrimitiveTypeCode.DateTime:
				return default(DateTime);
			}
		}
	}
}
