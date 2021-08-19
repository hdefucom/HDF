using DCSoft.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       DCWriter内部使用。影子文档元素对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DebuggerDisplay("Shadow:{EntryElementTypeName}")]
	[DCInternal]
	public class XTextShadowElement : XTextElement
	{
		private XTextElement xtextElement_0 = null;

		public override string DomDisplayName
		{
			get
			{
				int num = 1;
				if (EntryElement == null)
				{
					return "Shadow";
				}
				return "Shadow:" + EntryElement.DomDisplayName;
			}
		}

		/// <summary>
		///       影子元素所对应的实体元素
		///       </summary>
		public XTextElement EntryElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
			}
		}

		public string EntryElementTypeName
		{
			get
			{
				int num = 15;
				if (xtextElement_0 == null)
				{
					return "null";
				}
				return xtextElement_0.GetType().Name;
			}
		}

		public override XTextContainerElement Parent
		{
			get
			{
				if (xtextElement_0 == null)
				{
					return base.Parent;
				}
				return xtextElement_0.Parent;
			}
			set
			{
				base.Parent = value;
			}
		}

		public override XTextDocument OwnerDocument
		{
			get
			{
				if (xtextElement_0 == null)
				{
					return base.OwnerDocument;
				}
				return xtextElement_0.OwnerDocument;
			}
			set
			{
				base.OwnerDocument = value;
			}
		}

		public override float Left
		{
			get
			{
				if (xtextElement_0 == null)
				{
					return base.Left;
				}
				return xtextElement_0.Left;
			}
			set
			{
				base.Left = value;
			}
		}

		public override float Top
		{
			get
			{
				if (xtextElement_0 == null)
				{
					return base.Top;
				}
				return xtextElement_0.Top;
			}
			set
			{
				base.Top = value;
			}
		}

		public override float Width
		{
			get
			{
				if (xtextElement_0 == null)
				{
					return base.Width;
				}
				return xtextElement_0.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		public override float Height
		{
			get
			{
				if (xtextElement_0 == null)
				{
					return base.Height;
				}
				return xtextElement_0.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		internal XTextShadowElement()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="entryElement">对应的实体文档元素对象</param>
		internal XTextShadowElement(XTextElement xtextElement_1)
		{
			xtextElement_0 = xtextElement_1;
		}
	}
}
