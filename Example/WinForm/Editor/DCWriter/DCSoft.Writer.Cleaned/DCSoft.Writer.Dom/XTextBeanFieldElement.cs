using DCSoft.Common;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数据豆元素
	///       </summary>
	[Serializable]
	[XmlType("XBean")]
	
	[ComVisible(false)]
	
	[DebuggerDisplay("Bean:{ID}:{DataSource}")]
	[ToolboxBitmap(typeof(XTextBeanFieldElement))]
	public class XTextBeanFieldElement : XTextFieldElementBase
	{
	}
}
