using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Script
{
	/// <summary>
	///       script global object information
	///       </summary>
	/// <remarks>
	///       global object just like document,window,event in javascript.
	///       </remarks>
	[ComVisible(false)]
	[XmlType]
	public class XVBAScriptGlobalObject
	{
		private string strName = null;

		private object objValue = null;

		private Type objValueType = typeof(object);

		/// <summary>
		///       name
		///       </summary>
		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		/// <summary>
		///       value
		///       </summary>
		public object Value
		{
			get
			{
				return objValue;
			}
			set
			{
				objValue = value;
			}
		}

		/// <summary>
		///       value type
		///       </summary>
		public Type ValueType
		{
			get
			{
				return objValueType;
			}
			set
			{
				objValueType = value;
			}
		}

		public override string ToString()
		{
			return Name + ":" + ValueType.FullName;
		}
	}
}
