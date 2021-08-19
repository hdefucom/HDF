using DCSoft.Design;
using DCSoft.Script;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Services.Protocols;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass31
	{
		private static Dictionary<GClass32, SoapHttpClientProtocol> dictionary_0 = new Dictionary<GClass32, SoapHttpClientProtocol>();

		private static string string_0 = null;

		public static void smethod_0(GClass32 gclass32_0)
		{
			int num = 3;
			if (gclass32_0 == null)
			{
				throw new ArgumentNullException("info");
			}
			dictionary_0[gclass32_0] = null;
		}

		public static bool smethod_1(string string_1)
		{
			foreach (GClass32 key in dictionary_0.Keys)
			{
				if (string.Compare(key.Name, string_1, ignoreCase: true) == 0)
				{
					return true;
				}
			}
			return false;
		}

		public static SoapHttpClientProtocol smethod_2(string string_1)
		{
			smethod_5();
			foreach (GClass32 key in dictionary_0.Keys)
			{
				if (string.Compare(key.Name, string_1, ignoreCase: true) == 0)
				{
					return dictionary_0[key];
				}
			}
			return null;
		}

		public static string smethod_3()
		{
			return string_0;
		}

		public static void smethod_4(string string_1)
		{
			string_0 = string_1;
		}

		private static void smethod_5()
		{
			int num = 12;
			List<GClass32> list = new List<GClass32>();
			List<Type> list2 = new List<Type>();
			foreach (GClass32 key in dictionary_0.Keys)
			{
				if (dictionary_0[key] == null)
				{
					list.Add(key);
				}
			}
			if (list.Count != 0)
			{
				string text = "ns" + Guid.NewGuid().ToString("N");
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("\r\nusing System;\r\nusing System.Diagnostics;\r\nusing System.Xml.Serialization;\r\nusing System.Web.Services.Protocols;\r\nusing System.ComponentModel;\r\nusing System.Web.Services;\r\n\r\nnamespace " + text);
				stringBuilder.AppendLine("{");
				stringBuilder.AppendLine();
				string str = "WebServiceProtocol";
				foreach (GClass32 item in list)
				{
					string str2 = item.Name + str;
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("[System.Diagnostics.DebuggerStepThroughAttribute()]");
					stringBuilder.AppendLine("[System.ComponentModel.DesignerCategoryAttribute(\"code\")]");
					stringBuilder.AppendLine("[System.Web.Services.WebServiceBindingAttribute(Name=\"" + item.Name + "SOAP\", Namespace=\"http://tempuri.org/\")]");
					stringBuilder.AppendLine("public sealed class " + str2 + " : System.Web.Services.Protocols.SoapHttpClientProtocol");
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine("   public " + str2 + " ()");
					stringBuilder.AppendLine("   {");
					stringBuilder.AppendLine("   }");
					stringBuilder.AppendLine();
					foreach (GClass33 item2 in item.method_0())
					{
						if (item2.method_2() != null && item2.method_2().method_0() != null)
						{
							list2.Add(item2.method_2().method_0());
						}
						stringBuilder.AppendLine("[System.Web.Services.Protocols.SoapDocumentMethodAttribute(\"http://tempuri.org/" + item2.Name + "\"  , ");
						stringBuilder.AppendLine("RequestNamespace=\"http://tempuri.org/\", ");
						stringBuilder.AppendLine("ResponseNamespace=\"http://tempuri.org/\", ");
						stringBuilder.AppendLine("Use=System.Web.Services.Description.SoapBindingUse.Literal, ");
						stringBuilder.AppendLine("ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]");
						stringBuilder.AppendLine("public " + DesignUtils.GetCSharpTypeName(item2.method_2().method_0()) + " " + item2.Name + " (");
						if (item2.method_0() != null)
						{
							int num2 = 0;
							foreach (GClass34 item3 in item2.method_0())
							{
								if (item3.method_0() != null)
								{
									list2.Add(item3.method_0());
								}
								stringBuilder.AppendLine();
								stringBuilder.Append(DesignUtils.GetCSharpTypeName(item3.method_0()) + " " + item3.Name);
								if (num2 < item2.method_0().Count - 1)
								{
									stringBuilder.Append(" ,");
								}
								num2++;
							}
						}
						stringBuilder.Append(")");
						stringBuilder.AppendLine();
						stringBuilder.AppendLine("{");
						stringBuilder.AppendLine("object[] results = this.Invoke( \"" + item2.Name + "\" , new object[] { ");
						if (item2.method_0() != null && item2.method_0().Count > 0)
						{
							int num2 = 0;
							foreach (GClass34 item4 in item2.method_0())
							{
								if (num2 > 0)
								{
									stringBuilder.Append(",");
								}
								stringBuilder.Append(item4.Name);
								num2++;
							}
						}
						stringBuilder.AppendLine(" });");
						stringBuilder.AppendLine("return (" + DesignUtils.GetCSharpTypeName(item2.method_2().method_0()) + ")results[0] ;");
						stringBuilder.AppendLine("}");
					}
					stringBuilder.AppendLine("}");
				}
				stringBuilder.AppendLine("}");
				string text2 = stringBuilder.ToString();
				if (!string.IsNullOrEmpty(smethod_3()))
				{
					using (StreamWriter streamWriter = new StreamWriter(smethod_3(), append: false, Encoding.UTF8))
					{
						streamWriter.Write(text2);
					}
				}
				DynamicCompiler dynamicCompiler = new DynamicCompiler(CompilerLanguage.CSharp, text2);
				dynamicCompiler.AddStandardReferenceAssembly("System");
				dynamicCompiler.AddStandardReferenceAssembly("System.Data");
				dynamicCompiler.AddStandardReferenceAssembly("System.Web");
				dynamicCompiler.AddStandardReferenceAssembly("System.Web.Services");
				dynamicCompiler.AddStandardReferenceAssembly("System.Xml");
				dynamicCompiler.AddReferenceAssemblyByType(typeof(GClass31));
				foreach (Type item5 in list2)
				{
					dynamicCompiler.AddReferenceAssemblyByType(item5);
				}
				dynamicCompiler.AutoLoadResultAssembly = true;
				if (!dynamicCompiler.Compile())
				{
					throw new Exception(dynamicCompiler.CompilerErrorMessage);
				}
				Assembly resultAssembly = dynamicCompiler.ResultAssembly;
				Type[] types = resultAssembly.GetTypes();
				foreach (Type current5 in types)
				{
					foreach (GClass32 item6 in list)
					{
						if (current5.Namespace == text && current5.Name == item6.Name + str)
						{
							SoapHttpClientProtocol value = (SoapHttpClientProtocol)Activator.CreateInstance(current5);
							dictionary_0[item6] = value;
						}
					}
				}
			}
		}
	}
}
