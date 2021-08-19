using Open_Newtonsoft_Json.Serialization;
using System;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class DynamicReflectionDelegateFactory : ReflectionDelegateFactory
	{
		public static DynamicReflectionDelegateFactory Instance = new DynamicReflectionDelegateFactory();

		private static DynamicMethod CreateDynamicMethod(string name, Type returnType, Type[] parameterTypes, Type owner)
		{
			return (!TypeExtensions.IsInterface(owner)) ? new DynamicMethod(name, returnType, parameterTypes, owner, skipVisibility: true) : new DynamicMethod(name, returnType, parameterTypes, owner.Module, skipVisibility: true);
		}

		public override ObjectConstructor<object> CreateParametrizedConstructor(MethodBase method)
		{
			DynamicMethod dynamicMethod = CreateDynamicMethod(method.ToString(), typeof(object), new Type[1]
			{
				typeof(object[])
			}, method.DeclaringType);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			GenerateCreateMethodCallIL(method, iLGenerator, 0);
			return (ObjectConstructor<object>)dynamicMethod.CreateDelegate(typeof(ObjectConstructor<object>));
		}

		public override MethodCall<T, object> CreateMethodCall<T>(MethodBase method)
		{
			DynamicMethod dynamicMethod = CreateDynamicMethod(method.ToString(), typeof(object), new Type[2]
			{
				typeof(object),
				typeof(object[])
			}, method.DeclaringType);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			GenerateCreateMethodCallIL(method, iLGenerator, 1);
			return (MethodCall<T, object>)dynamicMethod.CreateDelegate(typeof(MethodCall<T, object>));
		}

		private void GenerateCreateMethodCallIL(MethodBase method, ILGenerator generator, int argsIndex)
		{
			ParameterInfo[] parameters = method.GetParameters();
			Label label = generator.DefineLabel();
			generator.Emit(OpCodes.Ldarg, argsIndex);
			generator.Emit(OpCodes.Ldlen);
			generator.Emit(OpCodes.Ldc_I4, parameters.Length);
			generator.Emit(OpCodes.Beq, label);
			generator.Emit(OpCodes.Newobj, typeof(TargetParameterCountException).GetConstructor(ReflectionUtils.EmptyTypes));
			generator.Emit(OpCodes.Throw);
			generator.MarkLabel(label);
			if (!method.IsConstructor && !method.IsStatic)
			{
				ILGeneratorExtensions.PushInstance(generator, method.DeclaringType);
			}
			int num = 0;
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				Type parameterType = parameterInfo.ParameterType;
				if (parameterType.IsByRef)
				{
					parameterType = parameterType.GetElementType();
					LocalBuilder local = generator.DeclareLocal(parameterType);
					if (!parameterInfo.IsOut)
					{
						ILGeneratorExtensions.PushArrayInstance(generator, argsIndex, i);
						if (TypeExtensions.IsValueType(parameterType))
						{
							Label label2 = generator.DefineLabel();
							Label label3 = generator.DefineLabel();
							generator.Emit(OpCodes.Brtrue_S, label2);
							generator.Emit(OpCodes.Ldloca_S, local);
							generator.Emit(OpCodes.Initobj, parameterType);
							generator.Emit(OpCodes.Br_S, label3);
							generator.MarkLabel(label2);
							ILGeneratorExtensions.PushArrayInstance(generator, argsIndex, i);
							ILGeneratorExtensions.UnboxIfNeeded(generator, parameterType);
							generator.Emit(OpCodes.Stloc, num);
							generator.MarkLabel(label3);
						}
						else
						{
							ILGeneratorExtensions.UnboxIfNeeded(generator, parameterType);
							generator.Emit(OpCodes.Stloc, num);
						}
					}
					generator.Emit(OpCodes.Ldloca_S, local);
					num++;
				}
				else if (TypeExtensions.IsValueType(parameterType))
				{
					ILGeneratorExtensions.PushArrayInstance(generator, argsIndex, i);
					Label label2 = generator.DefineLabel();
					Label label3 = generator.DefineLabel();
					generator.Emit(OpCodes.Brtrue_S, label2);
					LocalBuilder local = generator.DeclareLocal(parameterType);
					generator.Emit(OpCodes.Ldloca_S, local);
					generator.Emit(OpCodes.Initobj, parameterType);
					generator.Emit(OpCodes.Ldloc, num);
					generator.Emit(OpCodes.Br_S, label3);
					generator.MarkLabel(label2);
					ILGeneratorExtensions.PushArrayInstance(generator, argsIndex, i);
					ILGeneratorExtensions.UnboxIfNeeded(generator, parameterType);
					generator.MarkLabel(label3);
					num++;
				}
				else
				{
					ILGeneratorExtensions.PushArrayInstance(generator, argsIndex, i);
					ILGeneratorExtensions.UnboxIfNeeded(generator, parameterType);
				}
			}
			if (method.IsConstructor)
			{
				generator.Emit(OpCodes.Newobj, (ConstructorInfo)method);
			}
			else
			{
				ILGeneratorExtensions.CallMethod(generator, (MethodInfo)method);
			}
			Type type = method.IsConstructor ? method.DeclaringType : ((MethodInfo)method).ReturnType;
			if (type != typeof(void))
			{
				ILGeneratorExtensions.BoxIfNeeded(generator, type);
			}
			else
			{
				generator.Emit(OpCodes.Ldnull);
			}
			ILGeneratorExtensions.Return(generator);
		}

		public override Func<T> CreateDefaultConstructor<T>(Type type)
		{
			DynamicMethod dynamicMethod = CreateDynamicMethod("Create" + type.FullName, typeof(T), ReflectionUtils.EmptyTypes, type);
			dynamicMethod.InitLocals = true;
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			GenerateCreateDefaultConstructorIL(type, iLGenerator);
			return (Func<T>)dynamicMethod.CreateDelegate(typeof(Func<T>));
		}

		private void GenerateCreateDefaultConstructorIL(Type type, ILGenerator generator)
		{
			int num = 11;
			if (TypeExtensions.IsValueType(type))
			{
				generator.DeclareLocal(type);
				generator.Emit(OpCodes.Ldloc_0);
				generator.Emit(OpCodes.Box, type);
			}
			else
			{
				ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, ReflectionUtils.EmptyTypes, null);
				if (constructor == null)
				{
					throw new ArgumentException(StringUtils.FormatWith("Could not get constructor for {0}.", CultureInfo.InvariantCulture, type));
				}
				generator.Emit(OpCodes.Newobj, constructor);
			}
			ILGeneratorExtensions.Return(generator);
		}

		public override Func<T, object> CreateGet<T>(PropertyInfo propertyInfo)
		{
			DynamicMethod dynamicMethod = CreateDynamicMethod("Get" + propertyInfo.Name, typeof(T), new Type[1]
			{
				typeof(object)
			}, propertyInfo.DeclaringType);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			GenerateCreateGetPropertyIL(propertyInfo, iLGenerator);
			return (Func<T, object>)dynamicMethod.CreateDelegate(typeof(Func<T, object>));
		}

		private void GenerateCreateGetPropertyIL(PropertyInfo propertyInfo, ILGenerator generator)
		{
			int num = 16;
			MethodInfo getMethod = propertyInfo.GetGetMethod(nonPublic: true);
			if (getMethod == null)
			{
				throw new ArgumentException(StringUtils.FormatWith("Property '{0}' does not have a getter.", CultureInfo.InvariantCulture, propertyInfo.Name));
			}
			if (!getMethod.IsStatic)
			{
				ILGeneratorExtensions.PushInstance(generator, propertyInfo.DeclaringType);
			}
			ILGeneratorExtensions.CallMethod(generator, getMethod);
			ILGeneratorExtensions.BoxIfNeeded(generator, propertyInfo.PropertyType);
			ILGeneratorExtensions.Return(generator);
		}

		public override Func<T, object> CreateGet<T>(FieldInfo fieldInfo)
		{
			int num = 13;
			if (fieldInfo.IsLiteral)
			{
				object constantValue = fieldInfo.GetValue(null);
				return (T gparam_0) => constantValue;
			}
			DynamicMethod dynamicMethod = CreateDynamicMethod("Get" + fieldInfo.Name, typeof(T), new Type[1]
			{
				typeof(object)
			}, fieldInfo.DeclaringType);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			GenerateCreateGetFieldIL(fieldInfo, iLGenerator);
			return (Func<T, object>)dynamicMethod.CreateDelegate(typeof(Func<T, object>));
		}

		private void GenerateCreateGetFieldIL(FieldInfo fieldInfo, ILGenerator generator)
		{
			if (!fieldInfo.IsStatic)
			{
				ILGeneratorExtensions.PushInstance(generator, fieldInfo.DeclaringType);
				generator.Emit(OpCodes.Ldfld, fieldInfo);
			}
			else
			{
				generator.Emit(OpCodes.Ldsfld, fieldInfo);
			}
			ILGeneratorExtensions.BoxIfNeeded(generator, fieldInfo.FieldType);
			ILGeneratorExtensions.Return(generator);
		}

		public override Action<T, object> CreateSet<T>(FieldInfo fieldInfo)
		{
			DynamicMethod dynamicMethod = CreateDynamicMethod("Set" + fieldInfo.Name, null, new Type[2]
			{
				typeof(T),
				typeof(object)
			}, fieldInfo.DeclaringType);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			GenerateCreateSetFieldIL(fieldInfo, iLGenerator);
			return (Action<T, object>)dynamicMethod.CreateDelegate(typeof(Action<T, object>));
		}

		internal static void GenerateCreateSetFieldIL(FieldInfo fieldInfo, ILGenerator generator)
		{
			if (!fieldInfo.IsStatic)
			{
				ILGeneratorExtensions.PushInstance(generator, fieldInfo.DeclaringType);
			}
			generator.Emit(OpCodes.Ldarg_1);
			ILGeneratorExtensions.UnboxIfNeeded(generator, fieldInfo.FieldType);
			if (!fieldInfo.IsStatic)
			{
				generator.Emit(OpCodes.Stfld, fieldInfo);
			}
			else
			{
				generator.Emit(OpCodes.Stsfld, fieldInfo);
			}
			ILGeneratorExtensions.Return(generator);
		}

		public override Action<T, object> CreateSet<T>(PropertyInfo propertyInfo)
		{
			DynamicMethod dynamicMethod = CreateDynamicMethod("Set" + propertyInfo.Name, null, new Type[2]
			{
				typeof(T),
				typeof(object)
			}, propertyInfo.DeclaringType);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			GenerateCreateSetPropertyIL(propertyInfo, iLGenerator);
			return (Action<T, object>)dynamicMethod.CreateDelegate(typeof(Action<T, object>));
		}

		internal static void GenerateCreateSetPropertyIL(PropertyInfo propertyInfo, ILGenerator generator)
		{
			MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
			if (!setMethod.IsStatic)
			{
				ILGeneratorExtensions.PushInstance(generator, propertyInfo.DeclaringType);
			}
			generator.Emit(OpCodes.Ldarg_1);
			ILGeneratorExtensions.UnboxIfNeeded(generator, propertyInfo.PropertyType);
			ILGeneratorExtensions.CallMethod(generator, setMethod);
			ILGeneratorExtensions.Return(generator);
		}
	}
}
