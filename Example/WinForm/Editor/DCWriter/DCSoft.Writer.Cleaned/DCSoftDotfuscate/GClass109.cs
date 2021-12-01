using DCSoft.Common;
using DCSoft.Design;
using DCSoft.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass109
	{
		private class Class120
		{
			public Type type_0 = null;

			public Type type_1 = null;

			public Type type_2 = null;

			public string string_0 = null;
		}

		[ComVisible(false)]
		public class GClass110
		{
			public EventHandler eventHandler_0 = null;

			public CancelEventHandler method_0()
			{
				return method_1;
			}

			public void method_1(object sender, CancelEventArgs e)
			{
				if (eventHandler_0 != null)
				{
					eventHandler_0(null, null);
				}
			}
		}

		private static readonly Type type_0 = typeof(string);

		private static List<Class120> list_0 = new List<Class120>();

		private static int int_0 = 0;

		public static Delegate smethod_0(Delegate delegate_0, Type type_1)
		{
			int num = 5;
			if ((object)delegate_0 == null)
			{
				return null;
			}
			if (type_1 == null)
			{
				throw new ArgumentNullException("descHandlerTyper");
			}
			if (type_1.IsInstanceOfType(delegate_0))
			{
				return delegate_0;
			}
			Type type = null;
			lock (list_0)
			{
				Class120 @class = null;
				foreach (Class120 item in list_0)
				{
					if (item.type_0.Equals(type_1) && item.type_1.Equals(delegate_0.GetType()))
					{
						@class = item;
						break;
					}
				}
				if (@class == null)
				{
					@class = new Class120();
					@class.type_0 = type_1;
					@class.type_1 = delegate_0.GetType();
					list_0.Add(@class);
					smethod_1();
				}
				else if (@class.type_2 == null)
				{
					smethod_1();
				}
				type = @class.type_2;
				if (type == null || type == type_0)
				{
					return null;
				}
				object obj = Activator.CreateInstance(type);
				FieldInfo field = type.GetField("DescHandler");
				field.SetValue(obj, delegate_0);
				PropertyInfo property = type.GetProperty("SourceHandler");
				return (Delegate)property.GetValue(obj, null);
			}
		}

		private static void smethod_1()
		{
			string string_ = "DelegateConverterNS" + Convert.ToString(int_0++);
			List<Type> list = new List<Type>();
			string text = smethod_2(string_, list);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			DynamicCompiler dynamicCompiler = new DynamicCompiler();
			foreach (Type item in list)
			{
				dynamicCompiler.AddReferenceAssemblyByType(item);
			}
			dynamicCompiler.AutoLoadResultAssembly = true;
			dynamicCompiler.Language = CompilerLanguage.CSharp;
			dynamicCompiler.SourceCode = text;
			if (!dynamicCompiler.Compile())
			{
				return;
			}
			Assembly resultAssembly = dynamicCompiler.ResultAssembly;
			if (resultAssembly != null)
			{
				Type[] types = resultAssembly.GetTypes();
				foreach (Type current in types)
				{
					foreach (Class120 item2 in list_0)
					{
						if (current.Name == item2.string_0)
						{
							item2.type_2 = current;
							break;
						}
					}
				}
			}
			foreach (Class120 item3 in list_0)
			{
				if (item3.type_2 == null)
				{
					item3.type_2 = type_0;
				}
			}
		}

		private static string smethod_2(string string_0, List<Type> list_1)
		{
			int num = 3;
			new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("using System;");
			stringBuilder.AppendLine("namespace " + string_0);
			stringBuilder.AppendLine("{");
			bool flag = false;
			foreach (Class120 item in list_0)
			{
				if (item.type_2 == null && item.type_0 != null && item.type_1 != null)
				{
					flag = true;
					if (!list_1.Contains(item.type_0))
					{
						list_1.Add(item.type_0);
					}
					if (!list_1.Contains(item.type_1))
					{
						list_1.Add(item.type_1);
					}
					MethodInfo method = item.type_0.GetMethod("Invoke");
					MethodInfo method2 = item.type_1.GetMethod("Invoke");
					item.string_0 = "ConvertType_" + Convert.ToString(int_0++);
					stringBuilder.AppendLine("public class " + item.string_0);
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine("    public " + item.type_0.FullName + " SourceHandler");
					stringBuilder.AppendLine("    {");
					stringBuilder.AppendLine("        get{ return new " + item.type_0.FullName + "(this.HandleEvent);}");
					stringBuilder.AppendLine("    }");
					stringBuilder.AppendLine("    public " + item.type_1.FullName + " DescHandler = null;");
					stringBuilder.AppendLine("");
					stringBuilder.Append("    public ");
					stringBuilder.Append(DesignUtils.GetCSharpTypeName(method.ReturnType));
					if (!list_1.Contains(method.ReturnType))
					{
						list_1.Add(method.ReturnType);
					}
					stringBuilder.Append(" HandleEvent ( ");
					ParameterInfo[] parameters = method.GetParameters();
					for (int i = 0; i < parameters.Length; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append(",");
						}
						ParameterInfo parameterInfo = parameters[i];
						if (parameterInfo.IsIn && parameterInfo.IsOut)
						{
							stringBuilder.Append(" ref ");
						}
						else if (parameterInfo.IsOut)
						{
							stringBuilder.Append(" out ");
						}
						stringBuilder.Append(DesignUtils.GetCSharpTypeName(parameterInfo.ParameterType) + " " + parameterInfo.Name);
					}
					stringBuilder.Append(")");
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("    {");
					stringBuilder.AppendLine("        if( DescHandler != null )");
					stringBuilder.AppendLine("        {");
					stringBuilder.Append("            DescHandler(");
					ParameterInfo[] parameters2 = method2.GetParameters();
					for (int i = 0; i < parameters2.Length; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append(",");
						}
						bool flag2 = false;
						ParameterInfo parameterInfo = parameters2[i];
						if (i < parameters.Length)
						{
							ParameterInfo parameterInfo2 = parameters[i];
							if (parameterInfo.ParameterType.Equals(parameterInfo2.ParameterType) || parameterInfo.ParameterType.IsAssignableFrom(parameterInfo2.ParameterType))
							{
								flag2 = true;
								if (parameterInfo.IsOut && parameterInfo.IsIn)
								{
									stringBuilder.Append(" ref ");
								}
								else if (parameterInfo.IsOut)
								{
									stringBuilder.Append(" out ");
								}
								stringBuilder.Append(parameterInfo2.Name);
							}
						}
						if (!flag2)
						{
							object defaultValue = ValueTypeHelper.GetDefaultValue(parameterInfo.ParameterType);
							stringBuilder.Append(DesignUtils.ToCShaprValueString(defaultValue));
						}
					}
					stringBuilder.Append(");");
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("        }");
					stringBuilder.AppendLine("    }");
					stringBuilder.AppendLine("}//public class");
				}
			}
			if (flag)
			{
				stringBuilder.AppendLine("}");
				return stringBuilder.ToString();
			}
			return null;
		}
	}
}
