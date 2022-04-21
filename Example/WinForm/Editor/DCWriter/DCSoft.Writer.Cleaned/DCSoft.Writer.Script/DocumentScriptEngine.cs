using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Script;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       文档脚本引擎
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	
	[ComVisible(false)]
	
	public class DocumentScriptEngine : XVBAEngine, IDocumentScriptEngine
	{
		/// <summary>
		///       立即执行的脚本的方法名称
		///       </summary>
		public const string ImmediatelyScriptMethodName = "ImmediatelyScriptMethod";

		private bool _ImmediatelyMode;

		private string _ImmediatelyScript;

		[NonSerialized]
		private static Hashtable _ScriptSession = null;

		private Dictionary<string, string> _scriptItems;

		public override CompilerLanguage ScriptLanguage
		{
			get
			{
				if (Document != null)
				{
					if (Document.ScriptLanguage == ScriptLanguageType.JScript)
					{
						return CompilerLanguage.JScript;
					}
					return CompilerLanguage.VB;
				}
				return base.ScriptLanguage;
			}
			set
			{
				base.ScriptLanguage = value;
			}
		}

		/// <summary>
		///       立即执行脚本模式
		///       </summary>
		public bool ImmediatelyMode => _ImmediatelyMode;

		/// <summary>
		///       用于立即执行的脚本代码
		///       </summary>
		public string ImmediatelyScript => _ImmediatelyScript;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document => DocumentGlobalObjects.Document;

		/// <summary>
		///       当前元素对象
		///       </summary>
		public XTextElement CurrentElement
		{
			get
			{
				return (XTextElement)DocumentGlobalObjects.CurrentElement;
			}
			set
			{
				DocumentGlobalObjects.CurrentElement = value;
			}
		}

		/// <summary>
		///       事件参数
		///       </summary>
		public object EventArgs
		{
			get
			{
				return DocumentGlobalObjects.EventArgs;
			}
			set
			{
				DocumentGlobalObjects.EventArgs = value;
			}
		}

		/// <summary>
		///       脚本中使用的全局上下文对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public Hashtable ScriptSession
		{
			get
			{
				if (_ScriptSession == null)
				{
					_ScriptSession = new Hashtable();
				}
				return _ScriptSession;
			}
		}

		/// <summary>
		///       脚本全局对象列表
		///       </summary>
		public ScriptGlobalObjectContainer DocumentGlobalObjects
		{
			get
			{
				return (ScriptGlobalObjectContainer)base.GlobalObjects;
			}
			set
			{
				base.GlobalObjects = value;
			}
		}

		string IDocumentScriptEngine.RuntimeScriptTextWithCompilerErrorMessage => base.RuntimeScriptTextWithCompilerErrorMessage;

		string IDocumentScriptEngine.ScriptText
		{
			get
			{
				return base.ScriptText;
			}
			set
			{
				base.ScriptText = value;
			}
		}

		ScriptErrorList IDocumentScriptEngine.Errors
		{
			get
			{
				return base.Errors;
			}
			set
			{
				base.Errors = value;
			}
		}

		string IDocumentScriptEngine.CompilerErrorMessage => base.CompilerErrorMessage;

		CompilerErrorCollection IDocumentScriptEngine.CompilerErrors => base.CompilerErrors;

		/// <summary>
		///       初始化对象
		///       </summary>
		public DocumentScriptEngine(XTextDocument document)
		{
			int num = 17;
			_ImmediatelyMode = false;
			_ImmediatelyScript = null;
			_scriptItems = new Dictionary<string, string>();
			
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			DocumentGlobalObjects = new ScriptGlobalObjectContainer();
			base.Options.ImportNamespaces.Add("DCSoft.Writer");
			base.Options.ImportNamespaces.Add("DCSoft.Writer.Controls");
			base.Options.ImportNamespaces.Add("DCSoft.Writer.Dom");
			base.Options.ImportNamespaces.Add("DCSoft.Writer.Script");
			base.Options.ImportNamespaces.Add("DCSoft.Writer.Commands");
			base.Options.ImportNamespaces.Add("DCSoft.Writer.Data");
			base.Options.ImportNamespaces.Add("DCSoft.Drawing");
			base.Options.ImportNamespaces.Add("DCSoft.Common");
			base.Options.ImportNamespaces.Add("DCSoft.Printing");
			base.Options.ImportNamespaces.Add("System");
			base.Options.ImportNamespaces.Add("System.Drawing");
			base.Options.ImportNamespaces.Add("System.ComponentModel");
			base.Options.ImportNamespaces.Add("System.Text");
			base.Options.ImportNamespaces.Add("System.Collections.Generic");
			base.Options.ImportNamespaces.Add("System.Windows.Forms");
			base.Options.ImportNamespaces.Add("System.Data");
			base.Options.ReferenceAssemblies.AddByType(typeof(XFontValue));
			base.Options.ReferenceAssemblies.AddByType(typeof(XPageSettings));
			base.Options.ReferenceAssemblies.AddByType(typeof(DocumentCommentAttribute));
			base.VBHost.WindowTitle = WriterStrings.DCWriterProductName;
			DocumentGlobalObjects.Document = document;
		}

		/// <summary>
		///       设置为立即执行脚本的模式
		///       </summary>
		/// <param name="immediatelyMode">是否是立即执行模式</param>
		/// <param name="script">立即执行的脚本代码</param>
		public void SetImmediatelyMode(bool immediatelyMode, string script)
		{
			_ImmediatelyMode = immediatelyMode;
			_ImmediatelyScript = script;
		}

		/// <summary>
		///       更新脚本
		///       </summary>
		public void UpdateScriptText()
		{
			if (base.Enabled && !base.IsClosed && Document != null)
			{
				base.ScriptText = GetRuntimeScript();
			}
		}

		/// <summary>
		///       检查脚本引擎的状态
		///       </summary>
		/// <returns>脚本引擎是否成功启动</returns>
		public override bool CheckReady()
		{
			if (!base.Enabled || base.IsClosed)
			{
				return false;
			}
			if (Document == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(base.ScriptText))
			{
				if (!base.ScriptModified)
				{
					return false;
				}
				base.ScriptText = GetRuntimeScript();
			}
			if (DocumentGlobalObjects.Window == null)
			{
				DocumentGlobalObjects.Window = new WriterWindow();
			}
			DocumentGlobalObjects.Window.parentWindow = Document.EditorControl;
			DocumentGlobalObjects.Window.WriterControl = Document.EditorControl;
			DocumentGlobalObjects.Server = Document.ServerObject;
			return base.CheckReady();
		}

		/// <summary>
		///       编译脚本
		///       </summary>
		/// <returns>
		/// </returns>
		public override bool Compile()
		{
			if (Document != null)
			{
				DocumentGlobalObjects.Session = ScriptSession;
				DocumentGlobalObjects.Window.engine = this;
				DocumentGlobalObjects.Window.parentWindow = Document.EditorControl;
				DocumentGlobalObjects.WriterControl = Document.EditorControl;
				if (base.Compile())
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       触发文档元素事件
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="eventName">事件名称</param>
		/// <param name="parameters">参数列表</param>
		public void RaiseElementEventHandler(XTextElement element, string eventName, object[] parameters)
		{
			int num = 8;
			if (!CheckReady())
			{
				return;
			}
			MethodInfo scriptMethod = GetScriptMethod(element.ID + "_" + eventName);
			if (scriptMethod == null && element is XTextInputFieldElement)
			{
				scriptMethod = GetScriptMethod(((XTextInputFieldElement)element).Name + "_" + eventName);
			}
			if (scriptMethod != null)
			{
				InnerRaiseEventHandler(scriptMethod, parameters);
			}
			Type type = element.GetType();
			while (type != null && typeof(XTextElement).IsAssignableFrom(type))
			{
				scriptMethod = GetScriptMethod("_" + type.Name + "_" + eventName);
				if (scriptMethod != null)
				{
					InnerRaiseEventHandler(scriptMethod, parameters);
				}
				type = type.BaseType;
			}
		}

		/// <summary>
		///       触发文档事件
		///       </summary>
		/// <param name="eventName">事件名称</param>
		/// <param name="parameters">参数</param>
		public void RaiseDocumentEventHandler(string eventName, object[] parameters)
		{
			int num = 11;
			if (CheckReady())
			{
				MethodInfo scriptMethod = GetScriptMethod("Document_" + eventName);
				if (scriptMethod != null)
				{
					InnerRaiseEventHandler(scriptMethod, parameters);
				}
			}
		}

		private void InnerRaiseEventHandler(MethodInfo method, object[] parameterValues)
		{
			if (parameterValues != null)
			{
				if (parameterValues.Length == 1)
				{
					DocumentGlobalObjects.EventArgs = parameterValues[0];
				}
				else if (parameterValues.Length == 2)
				{
					DocumentGlobalObjects.EventArgs = parameterValues[1];
				}
			}
			try
			{
				method_8(method.Name, parameterValues, bool_7: true, bool_8: true);
			}
			catch (Exception ex)
			{
				if (Document.Options.BehaviorOptions.DebugMode && Document.AppHost.Debuger != null)
				{
					Document.AppHost.Debuger.WriteLine(string.Format(WriterStrings.EventScriptError_Event_Message, method.Name, (ex.InnerException == null) ? ex.Message : ex.InnerException.Message));
				}
			}
			finally
			{
				DocumentGlobalObjects.EventArgs = null;
			}
		}

		protected override bool CanExecuteScriptMethod(GClass6 method)
		{
			if (ImmediatelyMode)
			{
				return true;
			}
			if (!XTextDocument.smethod_13(GEnum6.const_124))
			{
				return false;
			}
			return base.CanExecuteScriptMethod(method);
		}

		/// <summary>
		///       脚本发生错误时的处理
		///       </summary>
		protected override void OnError()
		{
			if (Document != null && Document.Options.BehaviorOptions.AutoShowScriptErrorMessage)
			{
				ShowErrorDialog(Document.EditorControl);
			}
			if (Document != null && Document.EditorControl != null)
			{
				Document.EditorControl.method_78();
			}
			base.OnError();
		}

		/// <summary>
		///       启动脚本引擎
		///       </summary>
		/// <returns>启动是否成功</returns>
		public bool Start()
		{
			base.ScriptText = GetRuntimeScript();
			return Compile();
		}

		/// <summary>
		///       针对一个文档元素执行脚本方法
		///       </summary>
		/// <param name="element">文档元素名称</param>
		/// <param name="subName">方法名称</param>
		public void ExecuteSub(XTextElement element, string subName)
		{
			if (CheckReady())
			{
				CurrentElement = element;
				method_6(subName);
			}
		}

		/// <summary>
		///       根据脚本文本获得脚本方法名称
		///       </summary>
		/// <param name="txt">文本</param>
		/// <returns>名称</returns>
		public string GetMethodNameByScriptText(string string_5)
		{
			if (CheckReady() && _scriptItems.ContainsKey(string_5))
			{
				return _scriptItems[string_5];
			}
			return null;
		}

		private string GetRuntimeScript()
		{
			int num = 17;
			_scriptItems.Clear();
			hashtable_0.Clear();
			if (ImmediatelyMode)
			{
				if (_ImmediatelyScript == null || _ImmediatelyScript.Trim().Length == 0)
				{
					return null;
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine();
				if (ScriptLanguage == CompilerLanguage.JScript)
				{
					stringBuilder.AppendLine("function ImmediatelyScriptMethod( ){");
					stringBuilder.AppendLine();
					stringBuilder.AppendLine(ImmediatelyScript);
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("}");
				}
				else
				{
					stringBuilder.AppendLine("Sub ImmediatelyScriptMethod( )");
					stringBuilder.AppendLine();
					stringBuilder.AppendLine(ImmediatelyScript);
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("End Sub");
				}
				method_2("ImmediatelyScriptMethod", ImmediatelyScript);
				return stringBuilder.ToString();
			}
			int num2 = Document.ElementInstanceIndex;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(Document, bool_2: true);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				VBScriptItemList runtimeScriptItems = item.RuntimeScriptItems;
				if (runtimeScriptItems != null && runtimeScriptItems.Count > 0)
				{
					foreach (VBScriptItem item2 in runtimeScriptItems)
					{
						string scriptText = item2.ScriptText;
						if (scriptText != null)
						{
							scriptText = scriptText.Trim();
							if (scriptText.Length != 0 && !_scriptItems.ContainsKey(scriptText))
							{
								string text = "N" + num2;
								num2++;
								if (!string.IsNullOrEmpty(item2.Name))
								{
									text = item2.Name;
								}
								_scriptItems[item2.ScriptText] = text;
								item2.ScriptMethodName = text;
							}
						}
					}
				}
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			if (_scriptItems.Count > 0)
			{
				foreach (string key in _scriptItems.Keys)
				{
					stringBuilder2.AppendLine();
					if (ScriptLanguage == CompilerLanguage.JScript)
					{
						stringBuilder2.AppendLine("function " + _scriptItems[key] + "( ){");
						stringBuilder2.AppendLine(key);
						stringBuilder2.AppendLine("}");
					}
					else
					{
						stringBuilder2.AppendLine("Sub " + _scriptItems[key] + "( )");
						stringBuilder2.AppendLine(key);
						stringBuilder2.AppendLine("End sub");
					}
					stringBuilder2.AppendLine();
					method_2(_scriptItems[key], key);
				}
			}
			if (!string.IsNullOrEmpty(Document.ScriptText))
			{
				stringBuilder2.AppendLine(Document.ScriptText);
			}
			return stringBuilder2.ToString();
		}

		/// <summary>
		///       检测VB脚本是否无效
		///       </summary>
		/// <param name="element">
		/// </param>
		/// <returns>
		/// </returns>
		public bool CheckVBScriptInvalidte(XTextElement element)
		{
			VBScriptItemList vBScriptItems = GetVBScriptItems(element);
			if (vBScriptItems != null && vBScriptItems.Count > 0)
			{
				foreach (VBScriptItem item in vBScriptItems)
				{
					string text = item.ScriptText;
					if (text != null)
					{
						text = text.Trim();
					}
					if (text.Length > 0)
					{
						UpdateScriptText();
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       获得支持事件脚本的文档元素
		///       </summary>
		/// <param name="element">文档元素</param>
		/// <returns>获得的文档元素</returns>
		public static XTextElement GetElementSupportEventVBScript(XTextElement element)
		{
			while (true)
			{
				if (element != null)
				{
					if (element is XTextContainerElement)
					{
						break;
					}
					element = element.Parent;
					continue;
				}
				return null;
			}
			return element;
		}

		/// <summary>
		///       获得文本脚本信息
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <returns>获得的信息</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public static VBScriptItemList GetVBScriptItems(XTextElement element)
		{
			if (element is XTextContainerElement)
			{
				return ((XTextContainerElement)element).ScriptItems;
			}
			return null;
		}

		/// <summary>
		///       设置脚本信息
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="items">脚本信息</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		public static bool SetVBScriptItems(XTextElement element, VBScriptItemList items, bool logUndo)
		{
			int num = 16;
			XTextDocument ownerDocument = element.OwnerDocument;
			logUndo &= ownerDocument.CanLogUndo;
			if (element is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)element;
				if (logUndo)
				{
					ownerDocument.UndoList.AddProperty("ScriptItems", xTextContainerElement.ScriptItems, items, xTextContainerElement);
				}
				xTextContainerElement.ScriptItems = items;
				return true;
			}
			return false;
		}

		object IDocumentScriptEngine.Execute(string param0, object[] param1, bool param2)
		{
			return Execute(param0, param1, param2);
		}

		bool IDocumentScriptEngine.DebugCompile()
		{
			return DebugCompile();
		}

		void IDocumentScriptEngine.ShowErrorDialog(IWin32Window param0)
		{
			ShowErrorDialog(param0);
		}

		MethodInfo IDocumentScriptEngine.GetScriptMethod(string param0)
		{
			return GetScriptMethod(param0);
		}
	}
}
