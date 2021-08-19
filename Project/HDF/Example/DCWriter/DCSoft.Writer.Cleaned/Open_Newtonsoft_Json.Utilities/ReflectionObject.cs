using Open_Newtonsoft_Json.Serialization;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class ReflectionObject
	{
		public ObjectConstructor<object> Creator
		{
			get;
			private set;
		}

		public IDictionary<string, ReflectionMember> Members
		{
			get;
			private set;
		}

		public ReflectionObject()
		{
			Members = new Dictionary<string, ReflectionMember>();
		}

		public object GetValue(object target, string member)
		{
			Func<object, object> getter = Members[member].Getter;
			return getter(target);
		}

		public void SetValue(object target, string member, object value)
		{
			Action<object, object> setter = Members[member].Setter;
			setter(target, value);
		}

		public Type GetType(string member)
		{
			return Members[member].MemberType;
		}

		public static ReflectionObject Create(Type type_0, params string[] memberNames)
		{
			return Create(type_0, null, memberNames);
		}

		public static ReflectionObject Create(Type type_0, MethodBase creator, params string[] memberNames)
		{
			int num = 15;
			ReflectionObject reflectionObject = new ReflectionObject();
			ReflectionDelegateFactory reflectionDelegateFactory = JsonTypeReflector.ReflectionDelegateFactory;
			if (creator != null)
			{
				reflectionObject.Creator = reflectionDelegateFactory.CreateParametrizedConstructor(creator);
			}
			else if (ReflectionUtils.HasDefaultConstructor(type_0, nonPublic: false))
			{
				Func<object> ctor = reflectionDelegateFactory.CreateDefaultConstructor<object>(type_0);
				reflectionObject.Creator = ((object[] args) => ctor());
			}
			foreach (string text in memberNames)
			{
				MemberInfo[] member = type_0.GetMember(text, BindingFlags.Instance | BindingFlags.Public);
				MemberInfo memberInfo;
				ReflectionMember reflectionMember;
				if (member.Length == 1)
				{
					memberInfo = Enumerable.Single(member);
					reflectionMember = new ReflectionMember();
					MemberTypes memberTypes = TypeExtensions.MemberType(memberInfo);
					if (memberTypes != MemberTypes.Field)
					{
						if (memberTypes == MemberTypes.Method)
						{
							MethodInfo methodInfo = (MethodInfo)memberInfo;
							if (methodInfo.IsPublic)
							{
								ParameterInfo[] parameters = methodInfo.GetParameters();
								if (parameters.Length == 0 && methodInfo.ReturnType != typeof(void))
								{
									MethodCall<object, object> call2 = reflectionDelegateFactory.CreateMethodCall<object>(methodInfo);
									reflectionMember.Getter = ((object target) => call2(target));
								}
								else if (parameters.Length == 1 && methodInfo.ReturnType == typeof(void))
								{
									MethodCall<object, object> call = reflectionDelegateFactory.CreateMethodCall<object>(methodInfo);
									reflectionMember.Setter = delegate(object target, object object_0)
									{
										call(target, object_0);
									};
								}
							}
							goto IL_01ae;
						}
						if (memberTypes != MemberTypes.Property)
						{
							throw new ArgumentException(StringUtils.FormatWith("Unexpected member type '{0}' for member '{1}'.", CultureInfo.InvariantCulture, TypeExtensions.MemberType(memberInfo), memberInfo.Name));
						}
					}
					if (ReflectionUtils.CanReadMemberValue(memberInfo, nonPublic: false))
					{
						reflectionMember.Getter = reflectionDelegateFactory.CreateGet<object>(memberInfo);
					}
					if (ReflectionUtils.CanSetMemberValue(memberInfo, nonPublic: false, canSetReadOnly: false))
					{
						reflectionMember.Setter = reflectionDelegateFactory.CreateSet<object>(memberInfo);
					}
					goto IL_01ae;
				}
				throw new ArgumentException(StringUtils.FormatWith("Expected a single member with the name '{0}'.", CultureInfo.InvariantCulture, text));
				IL_01ae:
				if (ReflectionUtils.CanReadMemberValue(memberInfo, nonPublic: false))
				{
					reflectionMember.Getter = reflectionDelegateFactory.CreateGet<object>(memberInfo);
				}
				if (ReflectionUtils.CanSetMemberValue(memberInfo, nonPublic: false, canSetReadOnly: false))
				{
					reflectionMember.Setter = reflectionDelegateFactory.CreateSet<object>(memberInfo);
				}
				reflectionMember.MemberType = ReflectionUtils.GetMemberUnderlyingType(memberInfo);
				reflectionObject.Members[text] = reflectionMember;
			}
			return reflectionObject;
		}
	}
}
