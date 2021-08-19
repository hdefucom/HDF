using Microsoft.VisualBasic.Vsa;
using Microsoft.Vsa;
using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYVBScriptEngine : VsaEngine
	{
		public class EMRTextDocumentVsaSite : IVsaSite
		{
			private Hashtable myObjects = new Hashtable();

			public bool ShowErrorMsg = true;

			public ZYTextDocument Document = null;

			public ZYVBEventObject EventObject = new ZYVBEventObject();

			public ZYVBSystem EMRVB = null;

			public ZYVBConnection DBConnection = null;

			public Hashtable Objects => myObjects;

			private object GetInnerObject(string strName)
			{
				switch (strName)
				{
				case "document":
					return Document;
				case "eventobj":
					return EventObject;
				case "emrvb":
					return EMRVB;
				case "dbconnection":
					return DBConnection;
				default:
					return myObjects[strName];
				}
			}

			public object GetEventSourceInstance(string itemName, string eventSourceName)
			{
				return GetInnerObject(itemName);
			}

			public object GetGlobalInstance(string name)
			{
				return GetInnerObject(name);
			}

			public void Notify(string notify, object info)
			{
			}

			public bool OnCompilerError(IVsaError error)
			{
				string text = "第 " + Convert.ToString(error.Line - 10) + " 行脚本发生编译错误:" + error.Description + "\r\n该行代码为:" + error.LineText.Trim();
				ZYErrorReport.Instance.DebugPrint("编译错误:" + text);
				if (ShowErrorMsg)
				{
					MessageBox.Show(null, text, "编译错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				return false;
			}

			public void GetCompiledState(out byte[] pe, out byte[] debugInfo)
			{
				pe = null;
				debugInfo = null;
			}
		}

		private EMRTextDocumentVsaSite myVsaSite = new EMRTextDocumentVsaSite();

		private Hashtable myMethodTable = new Hashtable();

		public ZYTextDocument myOwnerDocument = null;

		private string strScriptText = null;

		private IVsaCodeItem myCodeItem = null;

		private IVsaCodeItem myGlobalCodeItem = null;

		public bool HasUserInterface = false;

		public ZYVBEventObject EventObj => myVsaSite.EventObject;

		public ZYTextDocument OwnerDocument
		{
			get
			{
				return myOwnerDocument;
			}
			set
			{
				myOwnerDocument = value;
			}
		}

		public string ScriptText
		{
			get
			{
				return strScriptText;
			}
			set
			{
				strScriptText = value;
			}
		}

		public void AppendScript(string strScript)
		{
			if (strScriptText == null)
			{
				strScriptText = strScript;
			}
			else
			{
				strScriptText += strScript;
			}
		}

		public MethodInfo GetScriptMethod(string strName)
		{
			if (strName != null)
			{
				strName = strName.Trim().ToLower();
				if (strName.Length > 0)
				{
					return myMethodTable[strName] as MethodInfo;
				}
			}
			return null;
		}

		public object InvokeScriptMethod(MethodInfo myMethod, object obj, object[] Parameters)
		{
			if (myMethod == null)
			{
				return null;
			}
			try
			{
				if (myOwnerDocument != null)
				{
					myOwnerDocument.BeginUpdate();
					myOwnerDocument.BeginContentChangeLog();
				}
				object result = null;
				try
				{
					ZYErrorReport.Instance.DebugPrint("执行脚本 " + myMethod.Name);
					result = myMethod.Invoke(obj, Parameters);
				}
				catch (Exception ex)
				{
					string text = "运行脚本[" + myMethod.Name + "]错误!\r\n" + ex.ToString();
					if (myOwnerDocument == null || myOwnerDocument.Info.ShowScriptError)
					{
						MessageBox.Show(null, text, "脚本错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						HasUserInterface = true;
					}
					ZYErrorReport.Instance.DebugPrint(text);
				}
				if (myOwnerDocument != null)
				{
					myOwnerDocument.EndContentChangeLog();
					myOwnerDocument.EndUpdate();
				}
				return result;
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = this;
				ZYErrorReport.Instance.MemberName = "InvokeScriptMethod";
				ZYErrorReport.Instance.UserMessage = "运行脚本[" + myMethod.Name + "]错误!";
				ZYErrorReport.Instance.ShowErrorDialog();
				HasUserInterface = true;
			}
			return null;
		}

		public object InvokeScriptMethod(string strMethodName, object obj, object[] Parameters)
		{
			return InvokeScriptMethod(GetScriptMethod(strMethodName), obj, Parameters);
		}

		private void AddRefrence(string strDllName)
		{
			try
			{
				ZYErrorReport.Instance.DebugPrint("向脚本引擎添加引用" + strDllName);
				IVsaReferenceItem vsaReferenceItem = base.Items.CreateItem(strDllName, VsaItemType.Reference, VsaItemFlag.None) as IVsaReferenceItem;
				vsaReferenceItem.AssemblyName = strDllName;
			}
			catch (Exception sourceException)
			{
				ZYErrorReport.Instance.SourceException = sourceException;
				ZYErrorReport.Instance.SourceObject = this;
				ZYErrorReport.Instance.UserMessage = "向脚本引擎添加引用 " + strDllName + " 错误";
				ZYErrorReport.Instance.MemberName = "ZYVBScriptEngine.AddRefrence";
				ZYErrorReport.Instance.ReportError();
			}
		}

		private void AddGlobalItem(string strName, string strTypeName)
		{
			IVsaGlobalItem vsaGlobalItem = base.Items.CreateItem(strName, VsaItemType.AppGlobal, VsaItemFlag.None) as IVsaGlobalItem;
			vsaGlobalItem.TypeString = strTypeName;
		}

		public ZYVBScriptEngine()
		{
			base.RootMoniker = "zyinc://ZYTextDocument//script";
			base.Site = myVsaSite;
			InitNew();
			base.RootNamespace = "ZYTextDocumentLib";
			base.GenerateDebugInfo = true;
			AddRefrence("system.dll");
			AddRefrence("mscorlib.dll");
			AddRefrence("system.drawing.dll");
			AddRefrence("system.xml.dll");
			AddRefrence("system.data.dll");
			AddRefrence("system.windows.forms.dll");
			AddRefrence("Microsoft.VisualBasic.dll");
			AddGlobalItem("document", "object");
			AddGlobalItem("eventobj", "object");
			AddGlobalItem("emrvb", "object");
			AddGlobalItem("dbconnection", "object");
			myCodeItem = (base.Items.CreateItem("UserCode", VsaItemType.Code, VsaItemFlag.None) as IVsaCodeItem);
			myGlobalCodeItem = (base.Items.CreateItem("GlobalCode", VsaItemType.Code, VsaItemFlag.None) as IVsaCodeItem);
		}

		public void SetGolbalScriptCode(string strCode)
		{
			myGlobalCodeItem.SourceText = "Option Strict Off\r\nImports System \r\nImports System.Xml \r\nImports System.Data\r\nImports System.Windows.Forms\r\nImports System.Drawing \r\nImports Microsoft.VisualBasic\r\n'Imports ZYCommon\r\n'Imports ZYTextDocumentLib \r\nModule GlobalCode\r\n" + strCode + "\r\nEnd Module";
		}

		public bool CompileEMRVB()
		{
			if (StringCommon.isBlankString(strScriptText))
			{
				StopScript();
				return false;
			}
			myCodeItem.SourceText = "Option Strict Off\r\nImports System \r\nImports System.Xml \r\nImports System.Data\r\nImports System.Windows.Forms\r\nImports System.Drawing \r\nImports Microsoft.VisualBasic\r\n'Imports ZYCommon\r\n'Imports ZYTextDocumentLib \r\nModule UserCode\r\n" + strScriptText + "\r\nEnd Module";
			if (Compile())
			{
				ZYErrorReport.Instance.DebugPrint("编译EMRVB代码成功，代码为\r\n" + myCodeItem.SourceText);
				return true;
			}
			ZYErrorReport.Instance.DebugPrint("编译EMRVB代码失败，代码为\r\n" + myCodeItem.SourceText);
			return false;
		}

		public bool StartScript()
		{
			try
			{
				StopScript();
				myVsaSite.EMRVB = new ZYVBSystem(myOwnerDocument);
				myVsaSite.EMRVB.EMRVBEngine = this;
				myVsaSite.Document = myOwnerDocument;
				if (myOwnerDocument != null)
				{
					myVsaSite.ShowErrorMsg = myOwnerDocument.Info.ShowScriptCompileError;
				}
				else
				{
					myVsaSite.ShowErrorMsg = true;
				}
				if (myOwnerDocument != null)
				{
					myVsaSite.DBConnection = new ZYVBConnection(myOwnerDocument.DataSource.DBConn);
				}
				else
				{
					myVsaSite.DBConnection = null;
				}
				if (CompileEMRVB())
				{
					Run();
					Assembly assembly = base.Assembly;
					if (assembly != null)
					{
						Type type = assembly.GetType(base.RootNamespace + ".UserCode");
						if (type != null)
						{
							MethodInfo[] methods = type.GetMethods(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
							MethodInfo[] array = methods;
							foreach (MethodInfo methodInfo in array)
							{
								myMethodTable.Add(methodInfo.Name.Trim().ToLower(), methodInfo);
							}
						}
						type = assembly.GetType(base.RootNamespace + ".GlobalCode");
						if (type != null)
						{
							MethodInfo[] methods = type.GetMethods(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
							MethodInfo[] array = methods;
							foreach (MethodInfo methodInfo in array)
							{
								myMethodTable.Add(methodInfo.Name.Trim().ToLower(), methodInfo);
							}
						}
					}
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				if (myOwnerDocument == null || myOwnerDocument.Info.ShowScriptError)
				{
					MessageBox.Show(null, "运行脚本错误\r\n" + ex.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			return false;
		}

		public void StopScript()
		{
			myMethodTable.Clear();
			if (base.IsRunning)
			{
				Reset();
			}
			if (base.IsCompiled)
			{
				RevokeCache();
			}
		}
	}
}
