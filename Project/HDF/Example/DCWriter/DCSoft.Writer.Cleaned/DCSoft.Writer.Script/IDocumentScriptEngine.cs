using DCSoft.Common;
using DCSoft.Script;
using DCSoft.Writer.Dom;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Script
{
	[DCInternal]
	[ComVisible(false)]
	public interface IDocumentScriptEngine : IDisposable
	{
		/// <summary>
		///       script in fact and with compiler error message , for user debug.
		///       </summary>
		string RuntimeScriptTextWithCompilerErrorMessage
		{
			get;
		}

		/// <summary>
		///       Native script source code.
		///       </summary>
		string ScriptText
		{
			get;
			set;
		}

		/// <summary>
		///       Script error list
		///       </summary>
		ScriptErrorList Errors
		{
			get;
			set;
		}

		/// <summary>
		///       编译错误信息
		///       </summary>
		string CompilerErrorMessage
		{
			get;
		}

		/// <summary>
		///       Compiler error list
		///       </summary>
		CompilerErrorCollection CompilerErrors
		{
			get;
		}

		/// <summary>
		///       当前元素对象
		///       </summary>
		XTextElement CurrentElement
		{
			get;
			set;
		}

		/// <summary>
		///       事件参数
		///       </summary>
		object EventArgs
		{
			get;
			set;
		}

		/// <summary>
		///       脚本中使用的全局上下文对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		Hashtable ScriptSession
		{
			get;
		}

		/// <summary>
		///       Execute script method
		///       </summary>
		/// <param name="MethodName">method name</param>
		/// <param name="Parameters">parameters</param>
		/// <param name="ThrowException">whether throw exception when happend error</param>
		/// <returns>result of script method</returns>
		object Execute(string MethodName, object[] Parameters, bool ThrowException);

		/// <summary>
		///       Compile script with debug mode
		///       </summary>
		/// <returns>result</returns>
		bool DebugCompile();

		/// <summary>
		///       显示脚本错误信息对话框
		///       </summary>
		/// <param name="parent">父窗体</param>
		void ShowErrorDialog(IWin32Window parent);

		/// <summary>
		///       更新脚本
		///       </summary>
		void UpdateScriptText();

		/// <summary>
		///       检测VB脚本是否无效
		///       </summary>
		/// <param name="element">
		/// </param>
		/// <returns>
		/// </returns>
		bool CheckVBScriptInvalidte(XTextElement element);

		/// <summary>
		///       根据脚本文本获得脚本方法名称
		///       </summary>
		/// <param name="txt">文本</param>
		/// <returns>名称</returns>
		string GetMethodNameByScriptText(string string_0);

		/// <summary>
		///       针对一个文档元素执行脚本方法
		///       </summary>
		/// <param name="element">文档元素名称</param>
		/// <param name="subName">方法名称</param>
		void ExecuteSub(XTextElement element, string subName);

		/// <summary>
		///       启动脚本引擎
		///       </summary>
		/// <returns>启动是否成功</returns>
		bool Start();

		/// <summary>
		///       触发文档元素事件
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="eventName">事件名称</param>
		/// <param name="parameters">参数列表</param>
		void RaiseElementEventHandler(XTextElement element, string eventName, object[] parameters);

		/// <summary>
		///       触发文档事件
		///       </summary>
		/// <param name="eventName">事件名称</param>
		/// <param name="parameters">参数</param>
		void RaiseDocumentEventHandler(string eventName, object[] parameters);

		/// <summary>
		///       Close
		///       </summary>
		void Close();

		MethodInfo GetScriptMethod(string MethodName);
	}
}
