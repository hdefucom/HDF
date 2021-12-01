using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       Script error information
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ScriptError
	{
		private ScriptErrorStyle intStyle = ScriptErrorStyle.Compile;

		private XVBAEngine myEngine = null;

		private DateTime dtmTime = DateTime.Now;

		private string strMethodName = null;

		private string strMessage = null;

		[NonSerialized]
		private Exception myException = null;

		private string strScriptText = null;

		/// <summary>
		///       script error style
		///       </summary>
		public ScriptErrorStyle Style
		{
			get
			{
				return intStyle;
			}
			set
			{
				intStyle = value;
			}
		}

		/// <summary>
		///       script engine
		///       </summary>
		[XmlIgnore]
		public XVBAEngine Engine
		{
			get
			{
				return myEngine;
			}
			set
			{
				myEngine = value;
			}
		}

		/// <summary>
		///       time when happend error
		///       </summary>
		[XmlIgnore]
		public DateTime Time
		{
			get
			{
				return dtmTime;
			}
			set
			{
				dtmTime = value;
			}
		}

		/// <summary>
		///       Name of script method
		///       </summary>
		public string MethodName
		{
			get
			{
				return strMethodName;
			}
			set
			{
				strMethodName = value;
			}
		}

		/// <summary>
		///       Message
		///       </summary>
		public string Message
		{
			get
			{
				return strMessage;
			}
			set
			{
				strMessage = value;
			}
		}

		/// <summary>
		///       Exception about error
		///       </summary>
		[XmlIgnore]
		public Exception Exception
		{
			get
			{
				return myException;
			}
			set
			{
				myException = value;
			}
		}

		/// <summary>
		///       Script source code about error
		///       </summary>
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

		/// <summary>
		///       Initialize instance
		///       </summary>
		public ScriptError()
		{
		}

		/// <summary>
		///       Initialize instance
		///       </summary>
		/// <param name="engine">script engine</param>
		/// <param name="style">error type</param>
		/// <param name="methodName">Name of script method</param>
		/// <param name="ext">Exception instance</param>
		public ScriptError(XVBAEngine engine, ScriptErrorStyle style, string methodName, Exception exception_0)
		{
			myEngine = engine;
			intStyle = style;
			strMethodName = methodName;
			myException = exception_0;
			if (exception_0 != null)
			{
				strMessage = exception_0.Message;
			}
		}

		public override string ToString()
		{
			if (Style == ScriptErrorStyle.Compile)
			{
				return string.Format(ScriptStrings.CompileError_Message, Message);
			}
			return string.Format(ScriptStrings.RuntimeError_Message, Message);
		}
	}
}
