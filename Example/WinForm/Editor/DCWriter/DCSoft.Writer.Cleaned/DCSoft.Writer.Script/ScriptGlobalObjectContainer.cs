using DCSoft.Common;
using DCSoft.Script;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       脚本使用的全局对象列表
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[DCInternal]
	[DocumentComment]
	[ComVisible(false)]
	public class ScriptGlobalObjectContainer : XVBAScriptGlobalObjectList
	{
		/// <summary>
		///       编辑器控件对象
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return (WriterControl)base["WriterControl"];
			}
			set
			{
				SetValue("WriterControl", value, typeof(WriterControl));
			}
		}

		/// <summary>
		///       窗体对象
		///       </summary>
		public WriterWindow Window
		{
			get
			{
				return (WriterWindow)base["window"];
			}
			set
			{
				SetValue("window", value, typeof(WriterWindow));
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return (XTextDocument)base["document"];
			}
			set
			{
				SetValue("document", value, typeof(XTextDocument));
			}
		}

		/// <summary>
		///       当前处理的文档元素对象
		///       </summary>
		public object CurrentElement
		{
			get
			{
				return (XTextElement)base["currentElement"];
			}
			set
			{
				SetValue("currentElement", value, typeof(object));
			}
		}

		/// <summary>
		///       事件参数
		///       </summary>
		public object EventArgs
		{
			get
			{
				return base["eventArgs"];
			}
			set
			{
				SetValue("eventArgs", value, typeof(object));
			}
		}

		/// <summary>
		///       上下文对象
		///       </summary>
		public Hashtable Session
		{
			get
			{
				return (Hashtable)base["session"];
			}
			set
			{
				SetValue("session", value, typeof(Hashtable));
			}
		}

		/// <summary>
		///       服务器对象
		///       </summary>
		public object Server
		{
			get
			{
				return base["server"];
			}
			set
			{
				base["server"] = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public ScriptGlobalObjectContainer()
		{
			Window = new WriterWindow();
			WriterControl = null;
			Document = null;
			EventArgs = null;
			CurrentElement = null;
			Session = null;
			Server = null;
		}
	}
}
