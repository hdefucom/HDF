#define DEBUG
using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       Script engine use VB.NET
	///       </summary>
	/// <remarks>
	///       This engine can dynamic VB.NET source code , and execute the method which define in the source code.
	///       this engine support MS.NET 1.1 , 2.0 or later.
	///       Author yfyuan
	///       </remarks>
	[Serializable]
	[ComVisible(false)]
	public class XVBAEngine : IDisposable
	{
		protected class GClass6
		{
			public Assembly assembly_0 = null;

			public string string_0 = null;

			public string string_1 = null;

			public MethodInfo methodInfo_0 = null;

			public Type type_0 = null;

			public Delegate delegate_0 = null;

			public string string_2 = null;

			public int int_0 = 0;

			public float float_0 = 0f;
		}

		private XVBAOptions xvbaoptions_0 = new XVBAOptions();

		private bool bool_0 = true;

		private bool bool_1 = false;

		private bool bool_2 = true;

		private StringCollection stringCollection_0 = new StringCollection();

		private StringCollection stringCollection_1 = new StringCollection();

		private StringCollection stringCollection_2 = new StringCollection();

		[NonSerialized]
		private Assembly assembly_0 = null;

		[NonSerialized]
		private Type type_0 = null;

		private bool bool_3 = true;

		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		private string string_3 = null;

		private int int_0 = 0;

		[NonSerialized]
		private XVBAScriptGlobalObjectList xvbascriptGlobalObjectList_0 = new XVBAScriptGlobalObjectList();

		[NonSerialized]
		private static AppDomain appDomain_0;

		[NonSerialized]
		private static GClass381 gclass381_0;

		[NonSerialized]
		private List<GClass6> list_0 = new List<GClass6>();

		private bool bool_4 = false;

		private string string_4 = null;

		private CompilerErrorCollection compilerErrorCollection_0 = null;

		private CompilerLanguage compilerLanguage_0 = CompilerLanguage.VB;

		private object object_0 = null;

		protected Hashtable hashtable_0 = new Hashtable();

		private bool bool_5 = false;

		private ScriptErrorList scriptErrorList_0 = new ScriptErrorList();

		private bool bool_6 = false;

		public XVBHost VBHost => HostServices.VBHost as XVBHost;

		public XVBAOptions Options
		{
			get
			{
				if (xvbaoptions_0 == null)
				{
					xvbaoptions_0 = new XVBAOptions();
				}
				return xvbaoptions_0;
			}
			set
			{
				xvbaoptions_0 = value;
			}
		}

		/// <summary>
		///       enbale script engine
		///       </summary>
		public bool Enabled
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       whether throw exception when engine has error.
		///       </summary>
		public bool ThrowException
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       whether script can ouput debug text at runtime.
		///       </summary>
		public bool OutputDebug
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		/// <summary>
		///       engine reference assemblies
		///       </summary>
		public StringCollection ReferencedAssemblies => stringCollection_0;

		/// <summary>
		///       namespace use in source code
		///       </summary>
		public StringCollection SourceImports => stringCollection_1;

		/// <summary>
		///       namespace imported for VB compiler
		///       </summary>
		public StringCollection VBCompilerImports => stringCollection_2;

		/// <summary>
		///       脚本文本发生改变标记
		///       </summary>
		public bool ScriptModified => bool_3;

		/// <summary>
		///       Native script source code.
		///       </summary>
		public string ScriptText
		{
			get
			{
				return string_0;
			}
			set
			{
				if (string_0 != value)
				{
					bool_3 = true;
					string_0 = value;
				}
			}
		}

		/// <summary>
		///       current used script source code
		///       </summary>
		public string RuntimeScriptText => string_1;

		/// <summary>
		///       script in fact and with compiler error message , for user debug.
		///       </summary>
		public string RuntimeScriptTextWithCompilerErrorMessage => string_2;

		/// <summary>
		///       Compiler output.
		///       </summary>
		public string CompilerOutput => string_3;

		/// <summary>
		///       Script version , every user modify script text , this version will increase.
		///       </summary>
		public int ScriptVersion
		{
			get
			{
				CheckReady();
				return int_0;
			}
		}

		/// <summary>
		///       global object list use in script,etc. instance for document, window , event and so on.
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public XVBAScriptGlobalObjectList GlobalObjects
		{
			get
			{
				if (xvbascriptGlobalObjectList_0 == null)
				{
					xvbascriptGlobalObjectList_0 = new XVBAScriptGlobalObjectList();
				}
				return xvbascriptGlobalObjectList_0;
			}
			set
			{
				xvbascriptGlobalObjectList_0 = value;
			}
		}

		/// <summary>
		///       appdomain to contain script assembly.
		///       </summary>
		public static AppDomain AppDomain
		{
			get
			{
				return appDomain_0;
			}
			set
			{
				appDomain_0 = value;
				if (gclass381_0 != null)
				{
					gclass381_0.method_1(appDomain_0);
				}
			}
		}

		/// <summary>
		///       assembly buffer
		///       </summary>
		public static GClass381 AssemblyBuffer
		{
			get
			{
				return gclass381_0;
			}
			set
			{
				gclass381_0 = value;
				if (gclass381_0 != null)
				{
					gclass381_0.method_1(appDomain_0);
				}
			}
		}

		protected List<GClass6> ScriptMethods
		{
			get
			{
				if (list_0 == null)
				{
					list_0 = new List<GClass6>();
				}
				return list_0;
			}
		}

		/// <summary>
		///       编译错误信息
		///       </summary>
		public string CompilerErrorMessage => string_4;

		/// <summary>
		///       Compiler error list
		///       </summary>
		public CompilerErrorCollection CompilerErrors => compilerErrorCollection_0;

		/// <summary>
		///       脚本语言类型
		///       </summary>
		public virtual CompilerLanguage ScriptLanguage
		{
			get
			{
				return compilerLanguage_0;
			}
			set
			{
				compilerLanguage_0 = value;
			}
		}

		private object ScriptMethodCallerInstance
		{
			get
			{
				if (ScriptLanguage == CompilerLanguage.JScript)
				{
					return object_0;
				}
				return null;
			}
		}

		/// <summary>
		///       对象已经关闭了
		///       </summary>
		public bool IsClosed => bool_5;

		/// <summary>
		///       get a string array which contains names of all script method
		///       </summary>
		public string[] ScriptMethodNames
		{
			get
			{
				if (!CheckReady())
				{
					return null;
				}
				ArrayList arrayList = new ArrayList();
				foreach (GClass6 scriptMethod in ScriptMethods)
				{
					arrayList.Add(scriptMethod.string_1);
				}
				return (string[])arrayList.ToArray(typeof(string));
			}
		}

		/// <summary>
		///       Script error list
		///       </summary>
		public ScriptErrorList Errors
		{
			get
			{
				return scriptErrorList_0;
			}
			set
			{
				scriptErrorList_0 = value;
			}
		}

		/// <summary>
		///       the Engine is executing script method
		///       </summary>
		[Browsable(false)]
		public bool Executing => bool_6;

		static XVBAEngine()
		{
			appDomain_0 = AppDomain.CurrentDomain;
			gclass381_0 = GClass381.smethod_0();
			ScriptStrings.Culture = CultureInfo.CurrentUICulture;
		}

		public static object smethod_0(Hashtable hashtable_1, Type type_1)
		{
			int num = 4;
			if (hashtable_1 == null)
			{
				return null;
			}
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = "DCSoftVBScriptEngine_AllObject_Assembly";
			AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("AllObjectModule");
			TypeBuilder typeBuilder = null;
			typeBuilder = ((type_1 != null) ? moduleBuilder.DefineType("AllObject" + Environment.TickCount, TypeAttributes.Public, type_1) : moduleBuilder.DefineType("AllObject" + Environment.TickCount, TypeAttributes.Public));
			ArrayList arrayList = new ArrayList();
			foreach (string key in hashtable_1.Keys)
			{
				if (key != null && key.Length != 0)
				{
					bool flag = false;
					foreach (FieldInfo item in arrayList)
					{
						if (string.Compare(item.Name, key, ignoreCase: true) == 0)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						arrayList.Add(typeBuilder.DefineField(key, typeof(object), FieldAttributes.Public));
					}
				}
			}
			Type type = typeBuilder.CreateType();
			object obj = Activator.CreateInstance(type);
			foreach (FieldInfo item2 in arrayList)
			{
				type.InvokeMember(item2.Name, BindingFlags.SetField, null, obj, new object[1]
				{
					hashtable_1[item2.Name]
				});
			}
			return obj;
		}

		/// <summary>
		///       initialize instance
		///       </summary>
		public XVBAEngine()
		{
			method_0();
		}

		/// <summary>
		///       initialize instance
		///       </summary>
		/// <param name="SourceCode">script source code</param>
		public XVBAEngine(string string_5)
		{
			method_0();
			ScriptText = string_5;
		}

		private void method_0()
		{
			stringCollection_2.Add("Microsoft.VisualBasic");
			HostServices.VBHost = new XVBHost();
		}

		/// <summary>
		///       check script engine state
		///       </summary>
		/// <returns>whether engine is ready</returns>
		public virtual bool CheckReady()
		{
			if (bool_5)
			{
				return false;
			}
			if (!Enabled)
			{
				return false;
			}
			if (!bool_3)
			{
				return assembly_0 != null;
			}
			return Compile();
		}

		/// <summary>
		///       Compile script with debug mode
		///       </summary>
		/// <returns>result</returns>
		public bool DebugCompile()
		{
			AssemblyBuffer.method_8();
			return Compile();
		}

		public Dictionary<string, MethodInfo> method_1(string string_5, Type type_1)
		{
			int num = 7;
			if (string.IsNullOrEmpty(string_5))
			{
				throw new ArgumentNullException("methodNamePrefix");
			}
			if (type_1 == null)
			{
				throw new ArgumentNullException("objType");
			}
			Dictionary<string, MethodInfo> dictionary = new Dictionary<string, MethodInfo>();
			foreach (GClass6 scriptMethod in ScriptMethods)
			{
				if (scriptMethod.string_1.StartsWith(string_5, StringComparison.CurrentCultureIgnoreCase))
				{
					string name = scriptMethod.string_1.Substring(string_5.Length);
					EventInfo @event = type_1.GetEvent(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (@event != null && GClass376.smethod_2(@event.EventHandlerType, scriptMethod.methodInfo_0))
					{
						dictionary[@event.Name] = scriptMethod.methodInfo_0;
					}
				}
			}
			return dictionary;
		}

		/// <summary>
		///       Compile script
		///       </summary>
		/// <returns>Compiler ok or not</returns>
		public virtual bool Compile()
		{
			int num = 4;
			object_0 = null;
			bool_4 = false;
			string_1 = null;
			string_4 = null;
			string_3 = null;
			compilerErrorCollection_0 = null;
			if (bool_5)
			{
				return false;
			}
			bool_3 = false;
			if (string_0 == null || string_0.Trim().Length == 0)
			{
				return false;
			}
			int_0++;
			bool result = false;
			ScriptMethods.Clear();
			assembly_0 = null;
			bool_3 = false;
			string text = "mdlDCSoftVBAScriptEngine";
			string text2 = "mdlDCSoftVBAScriptGlobalValues";
			string text3 = "NameSpaceDCSoftVBAScriptEngine";
			StringBuilder stringBuilder = new StringBuilder();
			if (ScriptLanguage == CompilerLanguage.VB)
			{
				stringBuilder.Append("Option Strict Off");
				foreach (string importNamespace in Options.ImportNamespaces)
				{
					stringBuilder.Append("\r\nImports " + importNamespace);
				}
				stringBuilder.Append("\r\nNamespace " + text3);
				if (xvbascriptGlobalObjectList_0 != null && xvbascriptGlobalObjectList_0.Count > 0)
				{
					stringCollection_2.Add(text3);
					stringBuilder.Append("\r\nModule " + text2);
					stringBuilder.Append("\r\n");
					stringBuilder.Append("\r\n    Public myGlobalValues As Object");
					foreach (XVBAScriptGlobalObject item in xvbascriptGlobalObjectList_0)
					{
						if (!XmlReader.IsName(item.Name))
						{
							if (ThrowException)
							{
								throw new ArgumentException("Script global object name:" + item.Name);
							}
							if (OutputDebug)
							{
								Debug.WriteLine("Script global object name:" + item.Name);
							}
						}
						else if (item.ValueType.Equals(typeof(object)) || !item.ValueType.IsPublic)
						{
							stringBuilder.Append("\r\n    Public ReadOnly Property " + item.Name + "() As Object ");
							stringBuilder.Append("\r\n      Get");
							stringBuilder.Append("\r\n         Return myGlobalValues(\"" + item.Name + "\") ");
							stringBuilder.Append("\r\n      End Get");
							stringBuilder.Append("\r\n    End Property");
						}
						else
						{
							string fullName = item.ValueType.FullName;
							fullName = fullName.Replace("+", ".");
							stringBuilder.Append("\r\n    Public ReadOnly Property " + item.Name + "() As " + fullName);
							stringBuilder.Append("\r\n      Get");
							stringBuilder.Append("\r\n         Return CType( myGlobalValues(\"" + item.Name + "\") , " + fullName + ")");
							stringBuilder.Append("\r\n      End Get");
							stringBuilder.Append("\r\n    End Property");
						}
					}
					stringBuilder.Append("\r\nEnd Module");
				}
				stringBuilder.Append("\r\nModule " + text);
				stringBuilder.Append("\r\n");
				stringBuilder.Append(string_0);
				stringBuilder.Append("\r\nEnd Module");
				stringBuilder.Append("\r\nEnd Namespace");
			}
			else if (ScriptLanguage == CompilerLanguage.JScript)
			{
				text2 = text;
				foreach (string importNamespace2 in Options.ImportNamespaces)
				{
					stringBuilder.AppendLine("import " + importNamespace2);
				}
				stringBuilder.AppendLine("package " + text3);
				stringBuilder.AppendLine("{");
				if (xvbascriptGlobalObjectList_0 != null && xvbascriptGlobalObjectList_0.Count > 0)
				{
					stringCollection_2.Add(text3);
					stringBuilder.AppendLine("class " + text2);
					stringBuilder.AppendLine("{");
					stringBuilder.AppendLine("   var  myGlobalValues = null;");
					foreach (XVBAScriptGlobalObject item2 in xvbascriptGlobalObjectList_0)
					{
						if (!XmlReader.IsName(item2.Name))
						{
							if (ThrowException)
							{
								throw new ArgumentException("Script global object name:" + item2.Name);
							}
							if (OutputDebug)
							{
								Debug.WriteLine("Script global object name:" + item2.Name);
							}
						}
						else if (item2.ValueType.Equals(typeof(object)) || !item2.ValueType.IsPublic)
						{
							stringBuilder.AppendLine("   function get " + item2.Name + "(){ return myGlobalValues == null ? null : myGlobalValues[\"" + item2.Name + "\"];}");
						}
						else
						{
							string fullName = item2.ValueType.FullName;
							fullName = fullName.Replace("+", ".");
							stringBuilder.AppendLine("   function get " + item2.Name + "():" + fullName + "{ return myGlobalValues == null ? null : myGlobalValues[\"" + item2.Name + "\"];}");
						}
					}
					stringBuilder.AppendLine();
					stringBuilder.AppendLine(string_0);
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("}// class");
				}
				stringBuilder.AppendLine("}//package");
			}
			string_1 = stringBuilder.ToString();
			assembly_0 = null;
			if (AssemblyBuffer != null)
			{
				assembly_0 = AssemblyBuffer.method_10(string_1);
			}
			if (assembly_0 == null)
			{
				DynamicCompiler dynamicCompiler = new DynamicCompiler();
				dynamicCompiler.Language = ScriptLanguage;
				dynamicCompiler.AppDomain = appDomain_0;
				dynamicCompiler.PreserveAssemblyFile = false;
				dynamicCompiler.OutputDebug = OutputDebug;
				dynamicCompiler.PreserveAssemblyFile = OutputDebug;
				dynamicCompiler.ThrowException = ThrowException;
				dynamicCompiler.SourceCode = string_1;
				dynamicCompiler.AutoLoadResultAssembly = true;
				DotNetAssemblyInfoList dotNetAssemblyInfoList = Options.ReferenceAssemblies.Clone();
				dotNetAssemblyInfoList.AddByType(GetType());
				if (GlobalObjects.Count > 0)
				{
					foreach (XVBAScriptGlobalObject globalObject in GlobalObjects)
					{
						dotNetAssemblyInfoList.AddByType(globalObject.ValueType);
					}
				}
				foreach (string innerReferenceAssembly in Options.InnerReferenceAssemblies)
				{
					dotNetAssemblyInfoList.AddByName(innerReferenceAssembly);
				}
				foreach (DotNetAssemblyInfo item3 in dotNetAssemblyInfoList)
				{
					if (item3.SourceStyle == AssemblySourceStyle.Standard)
					{
						dynamicCompiler.ReferenceAssemblies.Add(Path.GetFileName(item3.FileName));
					}
					else
					{
						dynamicCompiler.ReferenceAssemblies.Add(item3.FileName);
					}
				}
				if (ScriptLanguage == CompilerLanguage.VB)
				{
					StringEnumerator enumerator2 = VBCompilerImports.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							string current = enumerator2.Current;
							dynamicCompiler.CompilerImports.Add(current);
						}
					}
					finally
					{
						(enumerator2 as IDisposable)?.Dispose();
					}
				}
				if (dynamicCompiler.Compile())
				{
					assembly_0 = dynamicCompiler.ResultAssembly;
					if (AssemblyBuffer != null)
					{
						AssemblyBuffer.method_7(string_1, assembly_0, dynamicCompiler.ResultAssemblyBinary);
					}
					result = true;
					string_2 = dynamicCompiler.SourceCodeWithCompilerErrorMessage;
				}
				else
				{
					bool_4 = true;
					compilerErrorCollection_0 = dynamicCompiler.CompilerErrors;
					string_4 = dynamicCompiler.CompilerErrorMessage;
					foreach (CompilerError item4 in compilerErrorCollection_0)
					{
						if (!item4.IsWarning)
						{
							if (Errors != null)
							{
								ScriptError scriptError = new ScriptError(this, ScriptErrorStyle.Compile, null, null);
								scriptError.Message = item4.ErrorText;
								scriptError.ScriptText = item4.ErrorText;
								Errors.Add(scriptError);
							}
							result = false;
							break;
						}
					}
					string_2 = dynamicCompiler.SourceCodeWithCompilerErrorMessage;
					OnError();
				}
			}
			if (assembly_0 != null)
			{
				Type type = type_0 = assembly_0.GetType(text3 + "." + text2);
				if (ScriptLanguage == CompilerLanguage.JScript)
				{
					object_0 = Activator.CreateInstance(type);
				}
				if (text != null)
				{
					FieldInfo field = type.GetField("myGlobalValues");
					field.SetValue(ScriptMethodCallerInstance, GlobalObjects);
				}
				type = assembly_0.GetType(text3 + "." + text);
				if (type != null)
				{
					ResolveEventHandler value = method_3;
					AppDomain.CurrentDomain.AssemblyResolve += value;
					try
					{
						BindingFlags bindingFlags = BindingFlags.NonPublic;
						bindingFlags = ((ScriptLanguage != CompilerLanguage.JScript) ? (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public));
						MethodInfo[] methods = type.GetMethods(bindingFlags);
						MethodInfo[] array = methods;
						foreach (MethodInfo methodInfo in array)
						{
							if (methodInfo.Name == null || !methodInfo.Name.StartsWith("get_"))
							{
								GClass6 gClass = new GClass6();
								gClass.assembly_0 = assembly_0;
								gClass.string_1 = methodInfo.Name;
								gClass.methodInfo_0 = methodInfo;
								gClass.string_0 = type.Name;
								gClass.type_0 = methodInfo.ReturnType;
								gClass.string_2 = (string)hashtable_0[gClass.string_1];
								ScriptMethods.Add(gClass);
								if (bool_2)
								{
									Debug.WriteLine(string.Format(ScriptStrings.AnalyseVBMethod_Name, methodInfo.Name));
								}
							}
						}
					}
					finally
					{
						AppDomain.CurrentDomain.AssemblyResolve -= value;
					}
					result = true;
				}
			}
			return result;
		}

		public void method_2(string string_5, string string_6)
		{
			hashtable_0[string_5] = string_6;
		}

		private Assembly method_3(object object_1, ResolveEventArgs resolveEventArgs_0)
		{
			AppDomain appDomain = (AppDomain)object_1;
			Assembly[] assemblies = appDomain.GetAssemblies();
			int num = 0;
			Assembly assembly;
			while (true)
			{
				if (num < assemblies.Length)
				{
					assembly = assemblies[num];
					if (assembly.FullName == resolveEventArgs_0.Name)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return assembly;
		}

		public void method_4()
		{
			object_0 = null;
			string_0 = "";
			bool_5 = false;
			bool_3 = false;
			ScriptMethods.Clear();
			if (xvbascriptGlobalObjectList_0 != null)
			{
				xvbascriptGlobalObjectList_0.Clear();
			}
			if (bool_2)
			{
				Debug.WriteLine(ScriptStrings.ClearVBAEngine);
			}
		}

		/// <summary>
		///       Close
		///       </summary>
		public virtual void Close()
		{
			int num = 19;
			bool_5 = true;
			if (GlobalObjects != null)
			{
				GlobalObjects.Clear();
			}
			if (type_0 != null)
			{
				FieldInfo field = type_0.GetField("myGlobalValues");
				if (field != null && (field.IsStatic || ScriptMethodCallerInstance != null))
				{
					field.SetValue(ScriptMethodCallerInstance, null);
				}
			}
			object_0 = null;
			ScriptMethods.Clear();
			assembly_0 = null;
			type_0 = null;
			string_0 = null;
			if (xvbascriptGlobalObjectList_0 != null)
			{
				xvbascriptGlobalObjectList_0.Clear();
			}
			if (bool_2)
			{
				Debug.WriteLine(ScriptStrings.CloseVBAEngine);
			}
		}

		public bool method_5(string string_5)
		{
			if (!CheckReady())
			{
				return false;
			}
			if (ScriptMethods.Count > 0)
			{
				foreach (GClass6 scriptMethod in ScriptMethods)
				{
					if (string.Compare(scriptMethod.string_1, string_5, ignoreCase: true) == 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		public MethodInfo GetScriptMethod(string MethodName)
		{
			if (!CheckReady())
			{
				return null;
			}
			foreach (GClass6 scriptMethod in ScriptMethods)
			{
				if (string.Compare(scriptMethod.string_1, MethodName, ignoreCase: true) == 0)
				{
					return scriptMethod.methodInfo_0;
				}
			}
			return null;
		}

		public void method_6(string string_5)
		{
			Execute(string_5, null, ThrowException: false);
		}

		private object[] method_7(MethodInfo methodInfo_0, object[] object_1)
		{
			ParameterInfo[] parameters = methodInfo_0.GetParameters();
			if (parameters == null || parameters.Length == 0)
			{
				return new object[0];
			}
			object[] array = new object[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				array[i] = ValueTypeHelper.GetDefaultValue(parameterType);
				if (object_1 != null && object_1.Length > i && parameterType.IsInstanceOfType(object_1[i]))
				{
					array[i] = object_1[i];
				}
			}
			return array;
		}

		protected virtual bool CanExecuteScriptMethod(GClass6 method)
		{
			return true;
		}

		/// <summary>
		///       Execute script method
		///       </summary>
		/// <param name="MethodName">method name</param>
		/// <param name="Parameters">parameters</param>
		/// <param name="ThrowException">whether throw exception when happend error</param>
		/// <returns>result of script method</returns>
		public object Execute(string MethodName, object[] Parameters, bool ThrowException)
		{
			return method_8(MethodName, Parameters, ThrowException, bool_8: false);
		}

		public object method_8(string string_5, object[] object_1, bool bool_7, bool bool_8)
		{
			int num = 17;
			if (!CheckReady())
			{
				return null;
			}
			if (bool_7)
			{
				if (string_5 == null)
				{
					throw new ArgumentNullException("MethodName");
				}
				string_5 = string_5.Trim();
				if (string_5.Length == 0)
				{
					throw new ArgumentNullException("MethodName");
				}
				if (ScriptMethods.Count > 0)
				{
					foreach (GClass6 scriptMethod in ScriptMethods)
					{
						if (string.Compare(scriptMethod.string_1, string_5, ignoreCase: true) == 0)
						{
							if (!CanExecuteScriptMethod(scriptMethod))
							{
								break;
							}
							ResolveEventHandler value = method_9;
							object result = null;
							bool_6 = true;
							try
							{
								if (bool_8)
								{
									object_1 = method_7(scriptMethod.methodInfo_0, object_1);
								}
								AppDomain.AssemblyResolve += value;
								result = (((object)scriptMethod.delegate_0 == null) ? scriptMethod.methodInfo_0.Invoke(ScriptMethodCallerInstance, object_1) : scriptMethod.delegate_0.DynamicInvoke(object_1));
							}
							finally
							{
								AppDomain.AssemblyResolve -= value;
								bool_6 = false;
							}
							return result;
						}
					}
				}
			}
			else
			{
				if (string_5 == null)
				{
					return null;
				}
				string_5 = string_5.Trim();
				if (string_5.Length == 0)
				{
					return null;
				}
				if (ScriptMethods.Count > 0)
				{
					foreach (GClass6 scriptMethod2 in ScriptMethods)
					{
						if (string.Compare(scriptMethod2.string_1, string_5, ignoreCase: true) == 0)
						{
							if (!CanExecuteScriptMethod(scriptMethod2))
							{
								break;
							}
							ResolveEventHandler value = method_9;
							if (bool_8)
							{
								object_1 = method_7(scriptMethod2.methodInfo_0, object_1);
							}
							try
							{
								AppDomain.AssemblyResolve += value;
								bool_6 = true;
								object result = scriptMethod2.methodInfo_0.Invoke(ScriptMethodCallerInstance, object_1);
								bool_6 = false;
								return result;
							}
							catch (Exception ex)
							{
								string message = ex.Message;
								if (Errors != null)
								{
									ScriptError scriptError = new ScriptError(this, ScriptErrorStyle.Runtime, string_5, null);
									if (ex is TargetInvocationException && ex.InnerException != null)
									{
										scriptError.Exception = ex.InnerException;
									}
									else
									{
										scriptError.Exception = ex;
									}
									scriptError.Message = scriptError.Exception.Message;
									scriptError.ScriptText = scriptMethod2.string_2;
									message = scriptError.Message;
									Errors.Add(scriptError);
									OnError();
								}
								Debug.WriteLine(string.Format(ScriptStrings.VBARuntimeError_Method_Message, string_5, message));
							}
							finally
							{
								bool_6 = false;
								AppDomain.AssemblyResolve -= value;
							}
							return null;
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		///       当产生脚本错误时的事件处理
		///       </summary>
		protected virtual void OnError()
		{
		}

		/// <summary>
		///       显示脚本错误信息对话框
		///       </summary>
		/// <param name="parent">父窗体</param>
		public void ShowErrorDialog(IWin32Window parent)
		{
			if (Errors != null && Errors.Count > 0)
			{
				using (dlgScriptError dlgScriptError = new dlgScriptError())
				{
					dlgScriptError.VBAEngine = this;
					dlgScriptError.ShowDialog(parent);
				}
			}
		}

		private Assembly method_9(object object_1, ResolveEventArgs resolveEventArgs_0)
		{
			AssemblyName assemblyName = new AssemblyName(resolveEventArgs_0.Name);
			Assembly[] assemblies = AppDomain.GetAssemblies();
			int num = 0;
			Assembly assembly;
			while (true)
			{
				if (num < assemblies.Length)
				{
					assembly = assemblies[num];
					if (string.Compare(assembly.GetName().Name, assemblyName.Name, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				if (string.Compare(assemblyName.Name, GetType().Assembly.GetName().Name, ignoreCase: true) == 0)
				{
					return GetType().Assembly;
				}
				Debug.WriteLine(string.Format(ScriptStrings.ScriptAsmResolveWarring_Msg, resolveEventArgs_0.Name));
				return null;
			}
			return assembly;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			Close();
		}
	}
}
