using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass376
	{
		public static bool smethod_0(MethodInfo methodInfo_0, object[] object_0)
		{
			int num = 15;
			if (methodInfo_0 == null)
			{
				throw new ArgumentNullException("method");
			}
			ParameterInfo[] parameters = methodInfo_0.GetParameters();
			int num2 = (parameters != null) ? parameters.Length : 0;
			int num3 = (object_0 != null) ? object_0.Length : 0;
			if (num2 != num3)
			{
				return false;
			}
			if (num2 == 0)
			{
				return true;
			}
			int num4 = 0;
			while (true)
			{
				if (num4 < parameters.Length)
				{
					if (!parameters[num4].ParameterType.IsInstanceOfType(object_0[num4]))
					{
						break;
					}
					num4++;
					continue;
				}
				return true;
			}
			return false;
		}

		public static bool smethod_1(Delegate delegate_0, MethodInfo methodInfo_0)
		{
			int num = 13;
			if ((object)delegate_0 == null)
			{
				throw new ArgumentNullException("handler");
			}
			if (methodInfo_0 == null)
			{
				throw new ArgumentNullException("method");
			}
			return smethod_3(delegate_0.Method, methodInfo_0, bool_0: true);
		}

		public static bool smethod_2(Type type_0, MethodInfo methodInfo_0)
		{
			int num = 5;
			if (type_0 == null)
			{
				throw new ArgumentNullException("delegateType");
			}
			if (methodInfo_0 == null)
			{
				throw new ArgumentNullException("method");
			}
			MethodInfo method = type_0.GetMethod("Invoke");
			if (method != null)
			{
				return smethod_3(method, methodInfo_0, bool_0: true);
			}
			return false;
		}

		public static bool smethod_3(MethodInfo methodInfo_0, MethodInfo methodInfo_1, bool bool_0)
		{
			int num = 13;
			if (methodInfo_0 == null)
			{
				throw new ArgumentNullException("m1");
			}
			if (methodInfo_1 == null)
			{
				throw new ArgumentNullException("m2");
			}
			if (methodInfo_0 == methodInfo_1)
			{
				return true;
			}
			if (methodInfo_0.ReturnType != methodInfo_1.ReturnType)
			{
				if (!bool_0)
				{
					return false;
				}
				if (!methodInfo_1.ReturnType.IsAssignableFrom(methodInfo_0.ReturnType))
				{
					return false;
				}
			}
			ParameterInfo[] parameters = methodInfo_0.GetParameters();
			ParameterInfo[] parameters2 = methodInfo_1.GetParameters();
			if (parameters.Length != parameters2.Length)
			{
				return false;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < parameters.Length)
				{
					ParameterInfo parameterInfo = parameters[num2];
					ParameterInfo parameterInfo2 = parameters2[num2];
					if (parameterInfo.ParameterType != parameterInfo2.ParameterType)
					{
						if (!bool_0)
						{
							return false;
						}
						if (!parameterInfo2.ParameterType.IsAssignableFrom(parameterInfo.ParameterType))
						{
							return false;
						}
					}
					if (parameterInfo.IsIn == parameterInfo2.IsIn && parameterInfo.IsOut == parameterInfo2.IsOut && parameterInfo.IsOptional == parameterInfo2.IsOptional && parameterInfo.IsRetval == parameterInfo2.IsRetval)
					{
						if (parameterInfo.DefaultValue != parameterInfo2.DefaultValue)
						{
							break;
						}
						num2++;
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
