using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass43
	{
		public static void smethod_0(Type type_0, string string_0)
		{
			int num = 5;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			Assembly assembly = type_0.Assembly;
			Type type = null;
			ComSourceInterfacesAttribute comSourceInterfacesAttribute = (ComSourceInterfacesAttribute)Attribute.GetCustomAttribute(type_0, typeof(ComSourceInterfacesAttribute), inherit: false);
			if (comSourceInterfacesAttribute != null)
			{
				type = Type.GetType(comSourceInterfacesAttribute.Value, throwOnError: false);
			}
			Type type2 = Type.GetType(type_0.Namespace + "I" + type_0.Name, throwOnError: false);
			ComDefaultInterfaceAttribute comDefaultInterfaceAttribute = (ComDefaultInterfaceAttribute)Attribute.GetCustomAttribute(type_0, typeof(ComDefaultInterfaceAttribute), inherit: true);
			if (comDefaultInterfaceAttribute != null)
			{
				type2 = comDefaultInterfaceAttribute.Value;
			}
			if (type2 != null)
			{
				using (StreamWriter streamWriter = new StreamWriter(string_0, append: false, Encoding.Default))
				{
					streamWriter.WriteLine("VERSION 5.00");
					Version version = assembly.GetName().Version;
					string name = assembly.GetName().Name;
					name = name.Replace(".", "_") + "Ctl";
					string str = "VB" + type_0.Name;
					streamWriter.WriteLine("Object = \"{" + Marshal.GetTypeLibGuidForAssembly(assembly).ToString() + "}#" + version.Major + "." + version.Minor + "#" + version.Build + "\"; \"mscoree.dll\"");
					streamWriter.WriteLine("Begin VB.UserControl " + str);
					streamWriter.WriteLine("  ClientHeight = 2500");
					streamWriter.WriteLine("  ClientLeft = 0");
					streamWriter.WriteLine("  ClientTop = 0");
					streamWriter.WriteLine("  ClientWidth = 2500");
					string text = "my" + type_0.Name;
					streamWriter.WriteLine("  Begin " + name + "." + type_0.Name + " " + text);
					streamWriter.WriteLine("      Width = 2000");
					streamWriter.WriteLine("      Height = 2000");
					streamWriter.WriteLine("      Name    = \"" + type_0.Name + "\"");
					streamWriter.WriteLine("      Object.TabIndex = \"0\"");
					streamWriter.WriteLine("  End");
					streamWriter.WriteLine("End");
					streamWriter.WriteLine("Attribute VB_Name=\"" + str + "\"");
					streamWriter.WriteLine("Attribute VB_GlobalNameSpace = False");
					streamWriter.WriteLine("Attribute VB_Creatable = True");
					streamWriter.WriteLine("Attribute VB_PredeclaredId = False");
					streamWriter.WriteLine("Attribute VB_Exposed = True");
					streamWriter.WriteLine("Option Explicit");
					List<string> list = new List<string>();
					List<string> list2 = new List<string>();
					MethodInfo[] methods;
					if (type != null)
					{
						streamWriter.WriteLine("'定义事件*************************************");
						methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
						foreach (MethodInfo methodInfo in methods)
						{
							if (!list.Contains(methodInfo.Name))
							{
								list.Add(methodInfo.Name);
								list2.Add(methodInfo.Name);
								ParameterInfo[] parameters = methodInfo.GetParameters();
								if (smethod_1(parameters))
								{
									streamWriter.WriteLine();
									streamWriter.Write("Public Event " + methodInfo.Name + "(");
									smethod_2(streamWriter, parameters, bool_0: true, bool_1: true);
									streamWriter.Write(")");
									streamWriter.WriteLine();
								}
							}
						}
					}
					streamWriter.WriteLine("'映射属性 ***********************************");
					PropertyInfo[] properties = type2.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
					foreach (PropertyInfo propertyInfo in properties)
					{
						if (!list.Contains(propertyInfo.Name))
						{
							list.Add(propertyInfo.Name);
							Type propertyType = propertyInfo.PropertyType;
							if (!propertyType.IsArray)
							{
								if (propertyInfo.CanRead)
								{
									streamWriter.WriteLine("Public Property Get " + propertyInfo.Name + " () As " + smethod_4(propertyType));
									streamWriter.WriteLine("  " + propertyInfo.Name + " = " + text + "." + propertyInfo.Name);
									streamWriter.WriteLine("End Property");
								}
								if (propertyInfo.CanWrite)
								{
									if (propertyType.IsPrimitive || propertyType.Equals(typeof(string)) || propertyType.IsValueType)
									{
										streamWriter.WriteLine("Public Property Let " + propertyInfo.Name + "(ByVal vNewValue As " + smethod_4(propertyType) + ")");
										streamWriter.WriteLine("  " + text + "." + propertyInfo.Name + " = vNewValue");
										streamWriter.WriteLine("End Property");
									}
									else
									{
										streamWriter.WriteLine("Public Property Set " + propertyInfo.Name + "(ByVal vNewValue As " + smethod_4(propertyType) + ")");
										streamWriter.WriteLine("  Set " + text + "." + propertyInfo.Name + " = vNewValue");
										streamWriter.WriteLine("End Property");
									}
								}
							}
						}
					}
					streamWriter.WriteLine("'映射方法 ****************************************");
					methods = type2.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
					foreach (MethodInfo methodInfo in methods)
					{
						if (!string.IsNullOrEmpty(methodInfo.Name) && !methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !list.Contains(methodInfo.Name))
						{
							ParameterInfo[] parameters = methodInfo.GetParameters();
							if (smethod_1(parameters))
							{
								list.Add(methodInfo.Name);
								Type returnType = methodInfo.ReturnType;
								bool flag = returnType.Equals(typeof(void));
								streamWriter.WriteLine();
								streamWriter.Write("Public");
								if (flag)
								{
									streamWriter.Write(" Sub ");
								}
								else
								{
									streamWriter.Write(" Function ");
								}
								streamWriter.Write(methodInfo.Name + "(");
								smethod_2(streamWriter, parameters, bool_0: true, bool_1: false);
								streamWriter.Write(")");
								if (!flag)
								{
									streamWriter.Write(" As  " + smethod_4(methodInfo.ReturnType));
								}
								streamWriter.WriteLine();
								if (flag)
								{
									streamWriter.Write("  Call ");
								}
								else if (smethod_3(methodInfo.ReturnType))
								{
									streamWriter.Write("  Set " + methodInfo.Name + " = ");
								}
								else
								{
									streamWriter.Write("  Let " + methodInfo.Name + " = ");
								}
								streamWriter.Write(text + "." + methodInfo.Name + "(");
								smethod_2(streamWriter, parameters, bool_0: false, bool_1: false);
								streamWriter.Write(")");
								streamWriter.WriteLine();
								if (flag)
								{
									streamWriter.WriteLine("End Sub");
								}
								else
								{
									streamWriter.WriteLine("End Function");
								}
							}
						}
					}
					if (type != null)
					{
						streamWriter.WriteLine("'映射事件*************************************");
						methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
						foreach (MethodInfo methodInfo in methods)
						{
							if (list2.Contains(methodInfo.Name))
							{
								ParameterInfo[] parameters = methodInfo.GetParameters();
								if (smethod_1(parameters))
								{
									streamWriter.WriteLine();
									streamWriter.Write("Private Sub " + text + "_" + methodInfo.Name + "(");
									smethod_2(streamWriter, parameters, bool_0: true, bool_1: false);
									streamWriter.Write(")");
									streamWriter.WriteLine();
									streamWriter.Write("  RaiseEvent " + methodInfo.Name + "(");
									smethod_2(streamWriter, parameters, bool_0: false, bool_1: false);
									streamWriter.WriteLine(")");
									streamWriter.WriteLine("End Sub");
								}
							}
						}
					}
					string text2 = "\r\nPrivate Sub UserControl_Resize()\r\n    Dim cw  As Single\r\n    cw = UserControl.ScaleWidth\r\n    Dim ch As Single\r\n    ch = UserControl.ScaleHeight\r\n    If cw > 100 And ch > 100 Then\r\n        #Name.Left = 0\r\n        #Name.Top = 0\r\n        #Name.Width = cw\r\n        #Name.Height = ch\r\n    End If\r\nEnd Sub";
					text2 = text2.Replace("#Name", text);
					streamWriter.WriteLine(text2);
				}
			}
		}

		private static bool smethod_1(ParameterInfo[] parameterInfo_0)
		{
			if (parameterInfo_0 != null)
			{
				foreach (ParameterInfo parameterInfo in parameterInfo_0)
				{
					if (parameterInfo.ParameterType.IsArray)
					{
						return false;
					}
				}
			}
			return true;
		}

		private static void smethod_2(TextWriter textWriter_0, ParameterInfo[] parameterInfo_0, bool bool_0, bool bool_1)
		{
			int num = 9;
			if (parameterInfo_0 == null || parameterInfo_0.Length == 0)
			{
				return;
			}
			if (bool_0)
			{
				for (int i = 0; i < parameterInfo_0.Length; i++)
				{
					if (i > 0)
					{
						textWriter_0.Write(" , ");
					}
					ParameterInfo parameterInfo = parameterInfo_0[i];
					if (parameterInfo.IsIn || parameterInfo.IsOut || parameterInfo.ParameterType.IsArray)
					{
						textWriter_0.Write("ByRef ");
					}
					else
					{
						textWriter_0.Write("ByVal ");
					}
					string str = smethod_4(parameterInfo.ParameterType);
					if (bool_1)
					{
						str = "Object";
					}
					else
					{
						MarshalAsAttribute marshalAsAttribute = (MarshalAsAttribute)Attribute.GetCustomAttribute(parameterInfo, typeof(MarshalAsAttribute), inherit: false);
						if (marshalAsAttribute != null && marshalAsAttribute.Value == UnmanagedType.AsAny)
						{
							str = "Variant";
						}
					}
					textWriter_0.Write(parameterInfo.Name);
					if (parameterInfo.ParameterType.IsArray)
					{
						textWriter_0.Write("()");
					}
					textWriter_0.Write(" As " + str);
				}
				return;
			}
			for (int i = 0; i < parameterInfo_0.Length; i++)
			{
				ParameterInfo parameterInfo = parameterInfo_0[i];
				if (i > 0)
				{
					textWriter_0.Write(" , ");
				}
				if (parameterInfo.IsIn || parameterInfo.IsOut)
				{
					textWriter_0.Write("ByRef ");
				}
				textWriter_0.Write(parameterInfo.Name);
			}
		}

		private static bool smethod_3(Type type_0)
		{
			if (type_0.IsPrimitive || type_0.Equals(typeof(string)) || type_0.IsValueType)
			{
				return false;
			}
			return true;
		}

		private static string smethod_4(Type type_0)
		{
			int num = 12;
			if (type_0.IsArray)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0.Equals(typeof(string)))
			{
				return "String";
			}
			if (type_0.Equals(typeof(int)) || type_0.Equals(typeof(short)))
			{
				return "Integer";
			}
			if (type_0.Equals(typeof(long)))
			{
				return "Long";
			}
			if (type_0.Equals(typeof(byte)))
			{
				return "Byte";
			}
			if (type_0.Equals(typeof(DateTime)))
			{
				return "Date";
			}
			if (type_0.Equals(typeof(Color)))
			{
				return "OLE_COLOR";
			}
			if (type_0.Equals(typeof(float)))
			{
				return "Single";
			}
			if (type_0.Equals(typeof(double)))
			{
				return "Double";
			}
			if (type_0.Equals(typeof(bool)))
			{
				return "Boolean";
			}
			if (type_0.IsEnum)
			{
				if (type_0.Equals(typeof(BorderStyle)))
				{
					return "Integer";
				}
				return type_0.Name;
			}
			if (type_0.Equals(typeof(object)))
			{
				return "Object";
			}
			if (type_0.Equals(typeof(Rectangle)) || type_0.Equals(typeof(RectangleF)) || type_0.Equals(typeof(Point)) || type_0.Equals(typeof(PointF)) || type_0.Equals(typeof(Size)) || type_0.Equals(typeof(SizeF)))
			{
				return "Object";
			}
			if (!(((ComVisibleAttribute)Attribute.GetCustomAttribute(type_0, typeof(ComVisibleAttribute), inherit: false))?.Value ?? false))
			{
				return "Object";
			}
			return type_0.Name;
		}
	}
}
