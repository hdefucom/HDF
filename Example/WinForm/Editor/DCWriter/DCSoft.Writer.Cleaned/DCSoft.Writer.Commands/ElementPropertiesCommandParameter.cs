using DCSoft.Common;
using DCSoft.Writer.Dom;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑文档元素命令参数
	///       </summary>
	
	[ComVisible(false)]
	public class ElementPropertiesCommandParameter
	{
		private bool _SimpleElementProperties = false;

		private XTextElement _Element = null;

		private ElementPropertiesEditor _Editor = null;

		/// <summary>
		///       简洁的编辑元素属性
		///       </summary>
		public bool SimpleElementProperties
		{
			get
			{
				return _SimpleElementProperties;
			}
			set
			{
				_SimpleElementProperties = value;
			}
		}

		/// <summary>
		///       文档元素对象
		///       </summary>
		public XTextElement Element
		{
			get
			{
				return _Element;
			}
			set
			{
				_Element = value;
			}
		}

		/// <summary>
		///       用户指定的编辑器对象
		///       </summary>
		public ElementPropertiesEditor Editor
		{
			get
			{
				return _Editor;
			}
			set
			{
				_Editor = value;
			}
		}
	}
}
