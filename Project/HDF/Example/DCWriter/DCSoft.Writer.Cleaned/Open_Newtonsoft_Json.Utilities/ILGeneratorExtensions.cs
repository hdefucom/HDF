using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class ILGeneratorExtensions
	{
		public static void PushInstance(ILGenerator generator, Type type)
		{
			generator.Emit(OpCodes.Ldarg_0);
			if (TypeExtensions.IsValueType(type))
			{
				generator.Emit(OpCodes.Unbox, type);
			}
			else
			{
				generator.Emit(OpCodes.Castclass, type);
			}
		}

		public static void PushArrayInstance(ILGenerator generator, int argsIndex, int arrayIndex)
		{
			generator.Emit(OpCodes.Ldarg, argsIndex);
			generator.Emit(OpCodes.Ldc_I4, arrayIndex);
			generator.Emit(OpCodes.Ldelem_Ref);
		}

		public static void BoxIfNeeded(ILGenerator generator, Type type)
		{
			if (TypeExtensions.IsValueType(type))
			{
				generator.Emit(OpCodes.Box, type);
			}
			else
			{
				generator.Emit(OpCodes.Castclass, type);
			}
		}

		public static void UnboxIfNeeded(ILGenerator generator, Type type)
		{
			if (TypeExtensions.IsValueType(type))
			{
				generator.Emit(OpCodes.Unbox_Any, type);
			}
			else
			{
				generator.Emit(OpCodes.Castclass, type);
			}
		}

		public static void CallMethod(ILGenerator generator, MethodInfo methodInfo)
		{
			if (methodInfo.IsFinal || !methodInfo.IsVirtual)
			{
				generator.Emit(OpCodes.Call, methodInfo);
			}
			else
			{
				generator.Emit(OpCodes.Callvirt, methodInfo);
			}
		}

		public static void Return(ILGenerator generator)
		{
			generator.Emit(OpCodes.Ret);
		}
	}
}
