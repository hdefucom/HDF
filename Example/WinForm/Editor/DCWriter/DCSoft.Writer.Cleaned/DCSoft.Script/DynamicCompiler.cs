#define DEBUG
using Microsoft.CSharp;
using Microsoft.JScript;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       dynamic source code compiler
	///       </summary>
	/// <remarks>
	///       This type can dynamic compile program source code at runtime 
	///       and genereate .net assembly, this type support VB.NET and C#.
	///       Author yfyuan
	///       </remarks>
	[Serializable]
	[ComVisible(false)]
	public class DynamicCompiler
	{
		private CompilerLanguage intLanguage = CompilerLanguage.CSharp;

		/// <summary>
		///       namespaces import to VB compiler
		///       </summary>
		private MyStringList myCompilerImports = new MyStringList();

		private MyStringList myReferenceAssemblies = new MyStringList();

		private bool bolAutoLoadResultAssembly = true;

		private string strSourceCode = null;

		[NonSerialized]
		private AppDomain myAppDomain = AppDomain.CurrentDomain;

		[NonSerialized]
		private Assembly myResultAssembly = null;

		private byte[] bsResultAssemblyBinary = null;

		private CompilerErrorCollection myCompilerErrors = null;

		private string strCompilerOutput = null;

		private CompilerParameters _myCompilerParameters = null;

		private string strAssemblyFileName = null;

		private string strRuntimeAssemblyFileName = null;

		private bool bolPreserveAssemblyFile = false;

		private bool bolOutputDebug = true;

		private bool bolHasError = false;

		private bool bolThrowException = false;

		/// <summary>
		///       programming language
		///       </summary>
		[DefaultValue(CompilerLanguage.CSharp)]
		public CompilerLanguage Language
		{
			get
			{
				return intLanguage;
			}
			set
			{
				intLanguage = value;
			}
		}

		/// <summary>
		///       namespaces import to VB compiler
		///       </summary>
		public MyStringList CompilerImports => myCompilerImports;

		/// <summary>
		///       reference assemblys for compile
		///       </summary>
		[XmlArrayItem("Name", typeof(string))]
		public MyStringList ReferenceAssemblies
		{
			get
			{
				return myReferenceAssemblies;
			}
			set
			{
				myReferenceAssemblies = value;
			}
		}

		/// <summary>
		///       Whether load result assebly automatic
		///       </summary>
		[DefaultValue(true)]
		public bool AutoLoadResultAssembly
		{
			get
			{
				return bolAutoLoadResultAssembly;
			}
			set
			{
				bolAutoLoadResultAssembly = value;
			}
		}

		/// <summary>
		///       programming source code text
		///       </summary>
		[DefaultValue(null)]
		public string SourceCode
		{
			get
			{
				return strSourceCode;
			}
			set
			{
				strSourceCode = value;
			}
		}

		/// <summary>
		///       domain for compile
		///       </summary>
		public AppDomain AppDomain
		{
			get
			{
				return myAppDomain;
			}
			set
			{
				myAppDomain = value;
			}
		}

		/// <summary>
		///       the result assembly of compile
		///       </summary>
		public Assembly ResultAssembly => myResultAssembly;

		/// <summary>
		///       the binary of result assembly
		///       </summary>
		public byte[] ResultAssemblyBinary
		{
			get
			{
				return bsResultAssemblyBinary;
			}
			set
			{
				bsResultAssemblyBinary = value;
			}
		}

		/// <summary>
		///       compile error list
		///       </summary>
		public CompilerErrorCollection CompilerErrors => myCompilerErrors;

		/// <summary>
		///       compiler output text
		///       </summary>
		public string CompilerOutput => strCompilerOutput;

		/// <summary>
		///       compile parameters
		///       </summary>
		public CompilerParameters CompilerParameters
		{
			get
			{
				if (_myCompilerParameters == null)
				{
					_myCompilerParameters = new CompilerParameters();
				}
				return _myCompilerParameters;
			}
		}

		/// <summary>
		///       result assembly file name
		///       </summary>
		public string AssemblyFileName
		{
			get
			{
				return strAssemblyFileName;
			}
			set
			{
				strAssemblyFileName = value;
			}
		}

		/// <summary>
		///       result assembly file name in fact.
		///       </summary>
		public string RuntimeAssemblyFileName => strRuntimeAssemblyFileName;

		/// <summary>
		///       Whether preserve result assembly file
		///       </summary>
		[DefaultValue(false)]
		public bool PreserveAssemblyFile
		{
			get
			{
				return bolPreserveAssemblyFile;
			}
			set
			{
				bolPreserveAssemblyFile = value;
			}
		}

		/// <summary>
		///       whether output debug text
		///       </summary>
		public bool OutputDebug
		{
			get
			{
				return bolOutputDebug;
			}
			set
			{
				bolOutputDebug = value;
			}
		}

		/// <summary>
		///       has compile error.
		///       </summary>
		public bool HasError
		{
			get
			{
				return bolHasError;
			}
			set
			{
				bolHasError = value;
			}
		}

		public string CompilerErrorMessage
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (CompilerErrors != null)
				{
					foreach (CompilerError compilerError in CompilerErrors)
					{
						stringBuilder.AppendLine(compilerError.ErrorText);
					}
				}
				return stringBuilder.ToString();
			}
		}

		public string SourceCodeWithCompilerErrorMessage
		{
			get
			{
				int num = 14;
				StringReader stringReader = new StringReader(strSourceCode);
				string text = stringReader.ReadLine();
				ArrayList arrayList = new ArrayList();
				while (text != null)
				{
					arrayList.Add(text);
					text = stringReader.ReadLine();
				}
				stringReader.Close();
				string format = new string('0', (int)Math.Ceiling(Math.Log10(arrayList.Count + 1)));
				StringBuilder stringBuilder = new StringBuilder();
				ArrayList arrayList2 = new ArrayList(myCompilerErrors);
				for (int i = 1; i <= arrayList.Count; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(Environment.NewLine);
					}
					stringBuilder.Append(i.ToString(format)).Append(":").Append((string)arrayList[i - 1]);
					if (myCompilerErrors == null || myCompilerErrors.Count <= 0)
					{
						continue;
					}
					for (int num2 = arrayList2.Count - 1; num2 >= 0; num2--)
					{
						CompilerError compilerError = (CompilerError)arrayList2[num2];
						if (compilerError.Line == i)
						{
							stringBuilder.Append(Environment.NewLine);
							if (compilerError.IsWarning)
							{
								stringBuilder.Append("  " + ScriptStrings.Warring + ":");
							}
							else
							{
								stringBuilder.Append("  " + ScriptStrings.Error + ":");
							}
							stringBuilder.Append(compilerError.ErrorText);
							arrayList2.RemoveAt(num2);
						}
					}
				}
				if (arrayList2.Count > 0)
				{
					foreach (CompilerError item in arrayList2)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(Environment.NewLine);
						}
						if (item.IsWarning)
						{
							stringBuilder.Append("   " + ScriptStrings.Warring + ":");
						}
						else
						{
							stringBuilder.Append("   " + ScriptStrings.Error + ":");
						}
						stringBuilder.Append(item.ErrorText);
					}
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       throw exception when happend error.
		///       </summary>
		[DefaultValue(false)]
		public bool ThrowException
		{
			get
			{
				return bolThrowException;
			}
			set
			{
				bolThrowException = value;
			}
		}

		/// <summary>
		///       initialize instance
		///       </summary>
		public DynamicCompiler()
		{
		}

		/// <summary>
		///       initialize instance
		///       </summary>
		/// <param name="language">programming language type</param>
		/// <param name="sourceCode">source code text</param>
		public DynamicCompiler(CompilerLanguage language, string sourceCode)
		{
			intLanguage = language;
			strSourceCode = sourceCode;
		}

		public string AddStandardReferenceAssembly(string name)
		{
			string standardAssemblyFileName = DotNetAssemblyInfo.GetStandardAssemblyFileName(name);
			if (standardAssemblyFileName != null && !myReferenceAssemblies.Contains(standardAssemblyFileName))
			{
				myReferenceAssemblies.Add(standardAssemblyFileName);
				return standardAssemblyFileName;
			}
			return null;
		}

		public string AddReferenceAssemblyByType(Type type_0)
		{
			int num = 2;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			string location = type_0.Assembly.Location;
			if (!myReferenceAssemblies.Contains(location))
			{
				myReferenceAssemblies.Add(location);
				return location;
			}
			return null;
		}

		public string AddReferenceAssembly(Assembly assembly_0)
		{
			int num = 18;
			if (assembly_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			string location = assembly_0.Location;
			if (!myReferenceAssemblies.Contains(location))
			{
				myReferenceAssemblies.Add(location);
				return location;
			}
			return null;
		}

		private void AddAssemblyFile(StringCollection asms, string fileName)
		{
			int num = 3;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			string fileName2 = Path.GetFileName(fileName);
			StringEnumerator enumerator = asms.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					string fileName3 = Path.GetFileName(current);
					if (string.Compare(fileName2, fileName3, ignoreCase: true) == 0)
					{
						return;
					}
				}
			}
			finally
			{
				(enumerator as IDisposable)?.Dispose();
			}
			asms.Add(fileName);
		}

		/// <summary>
		///       compile source code
		///       </summary>
		/// <returns>whether compile is ok</returns>
		public bool Compile()
		{
			int num = 13;
			bool result = false;
			bolHasError = false;
			strCompilerOutput = null;
			myCompilerErrors = new CompilerErrorCollection();
			myResultAssembly = null;
			bsResultAssemblyBinary = null;
			CompilerParameters.ReferencedAssemblies.Clear();
			foreach (string referenceAssembly in ReferenceAssemblies)
			{
				AddAssemblyFile(CompilerParameters.ReferencedAssemblies, referenceAssembly);
			}
			ResolveEventHandler value = myAppDomain_AssemblyResolve;
			if (myAppDomain != null)
			{
				myAppDomain.AssemblyResolve += value;
			}
			try
			{
				CompilerParameters.GenerateExecutable = false;
				CompilerParameters.GenerateInMemory = false;
				CompilerParameters.IncludeDebugInformation = false;
				strRuntimeAssemblyFileName = AssemblyFileName;
				if (strRuntimeAssemblyFileName == null || strRuntimeAssemblyFileName.Trim().Length == 0)
				{
					strRuntimeAssemblyFileName = Path.GetTempFileName() + ".dll";
				}
				CompilerParameters.OutputAssembly = strRuntimeAssemblyFileName;
				if (CompilerImports != null && CompilerImports.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (string compilerImport in CompilerImports)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(compilerImport.Trim());
					}
					stringBuilder.Insert(0, " /imports:");
					CompilerParameters.CompilerOptions = stringBuilder.ToString();
				}
				StringEnumerator enumerator2;
				if (bolOutputDebug)
				{
					Debug.WriteLine(ScriptStrings.StartDynamicCompile + "\r\n" + strSourceCode);
					enumerator2 = CompilerParameters.ReferencedAssemblies.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							string current = enumerator2.Current;
							Debug.WriteLine(ScriptStrings.Reference + ":" + current);
						}
					}
					finally
					{
						(enumerator2 as IDisposable)?.Dispose();
					}
				}
				CompilerResults compilerResults = null;
				if (Language == CompilerLanguage.VB)
				{
					VBCodeProvider vBCodeProvider = new VBCodeProvider();
					compilerResults = vBCodeProvider.CompileAssemblyFromSource(CompilerParameters, strSourceCode);
					vBCodeProvider.Dispose();
				}
				else if (Language == CompilerLanguage.CSharp)
				{
					CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
					compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(CompilerParameters, strSourceCode);
					cSharpCodeProvider.Dispose();
				}
				else
				{
					if (Language != CompilerLanguage.JScript)
					{
						throw new Exception(string.Format(ScriptStrings.NotSupportLanguage_Language, Language));
					}
					JScriptCodeProvider jScriptCodeProvider = new JScriptCodeProvider();
					compilerResults = jScriptCodeProvider.CompileAssemblyFromSource(CompilerParameters, strSourceCode);
					jScriptCodeProvider.Dispose();
				}
				StringBuilder stringBuilder2 = new StringBuilder();
				enumerator2 = compilerResults.Output.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						string current2 = enumerator2.Current;
						stringBuilder2.Append("\r\n" + current2);
					}
				}
				finally
				{
					(enumerator2 as IDisposable)?.Dispose();
				}
				strCompilerOutput = stringBuilder2.ToString();
				if (OutputDebug && strCompilerOutput.Length > 0)
				{
					Debug.WriteLine(ScriptStrings.DymamicCompilerResult + strCompilerOutput);
				}
				myCompilerErrors = compilerResults.Errors;
				if (compilerResults.Errors.HasErrors)
				{
					result = false;
					bolHasError = true;
				}
				else
				{
					if (AutoLoadResultAssembly)
					{
						if (CompilerParameters.GenerateInMemory)
						{
							myResultAssembly = compilerResults.CompiledAssembly;
						}
						else
						{
							bsResultAssemblyBinary = null;
							using (FileStream fileStream = new FileStream(CompilerParameters.OutputAssembly, FileMode.Open, FileAccess.Read))
							{
								bsResultAssemblyBinary = new byte[fileStream.Length];
								fileStream.Read(bsResultAssemblyBinary, 0, bsResultAssemblyBinary.Length);
							}
							myResultAssembly = myAppDomain.Load(bsResultAssemblyBinary, null, CompilerParameters.Evidence);
						}
					}
					result = true;
				}
				if (!PreserveAssemblyFile && File.Exists(strRuntimeAssemblyFileName))
				{
					File.Delete(strRuntimeAssemblyFileName);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(string.Format(ScriptStrings.CompileError_Message, ex.Message));
				if (bolThrowException)
				{
					throw ex;
				}
			}
			if (myAppDomain != null)
			{
				myAppDomain.AssemblyResolve -= value;
			}
			return result;
		}

		private Assembly myAppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			AppDomain appDomain = (AppDomain)sender;
			Assembly[] assemblies = appDomain.GetAssemblies();
			int num = 0;
			Assembly assembly;
			while (true)
			{
				if (num < assemblies.Length)
				{
					assembly = assemblies[num];
					if (assembly.FullName == args.Name)
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
	}
}
