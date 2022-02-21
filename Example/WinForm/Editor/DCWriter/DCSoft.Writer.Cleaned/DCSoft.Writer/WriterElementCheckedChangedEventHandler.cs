using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       元素勾选状态发生改变事件
	///       </summary>
	/// <param name="elementID">文档元素编号</param>
	/// <param name="elementName">文档元素名称</param>
	/// <param name="elementValue">文档元素值</param>
	/// <param name="element">文档元素对象</param>
	[Guid("999FC432-FBB2-4D41-91D2-E7FE9BE0CFC9")]
	[ComVisible(true)]
	
	[DocumentComment]
	public delegate void WriterElementCheckedChangedEventHandler(string elementID, string elementName, string elementValue, XTextElement element);
}
