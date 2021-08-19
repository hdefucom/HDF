using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       脚本引擎信息对象
	///       </summary>
	[ComVisible(false)]
	[XmlType]
	public class XEngingInfo
	{
		private XVBAEngine _Engine;

		public string ScriptText => _Engine.ScriptText;

		public string RuntimeScriptText => _Engine.RuntimeScriptText;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="engine">
		/// </param>
		public XEngingInfo(XVBAEngine engine)
		{
			int num = 6;
			_Engine = null;
			
			if (engine == null)
			{
				throw new ArgumentNullException("engine");
			}
			_Engine = engine;
		}
	}
}
