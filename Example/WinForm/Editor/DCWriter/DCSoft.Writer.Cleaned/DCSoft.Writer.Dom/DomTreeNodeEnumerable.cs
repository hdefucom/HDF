using DCSoft.Common;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档树节点遍历器
	///       </summary>
	[ComVisible(false)]
	
	public class DomTreeNodeEnumerable : TreeNodeEnumerable
	{
		private bool bool_0 = true;

		private bool bool_1 = true;

		/// <summary>
		///       忽略字符元素
		///       </summary>
		
		public bool ExcludeCharElement
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       忽略段落符号元素
		///       </summary>
		
		public bool ExcludeParagraphFlag
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="elements">文档元素列表</param>
		
		public DomTreeNodeEnumerable(XTextElementList xtextElementList_0)
		{
			base.RootNodes = xtextElementList_0;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="rootElement">根节点</param>
		/// <param name="includeRootElement">遍历时是否包含根节点</param>
		
		public DomTreeNodeEnumerable(XTextElement xtextElement_0, bool bool_2 = false)
		{
			if (bool_2)
			{
				base.RootNodes = new XTextElement[1]
				{
					xtextElement_0
				};
				return;
			}
			base.RootNodes = xtextElement_0.Elements;
			base.RootParent = xtextElement_0;
		}

		
		public override object GetParent(object instance)
		{
			return ((XTextElement)instance).Parent;
		}

		
		public override IEnumerable GetChildNodes(object instance)
		{
			return ((XTextElement)instance).Elements;
		}

		
		public override bool IsPublish(object current)
		{
			if (bool_0 && current is XTextCharElement)
			{
				return false;
			}
			if (bool_1 && current is XTextParagraphFlagElement)
			{
				return false;
			}
			return true;
		}
	}
}
