using DCSoft.Common;
using DCSoft.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档大纲节点
	///       </summary>
	[Serializable]
	[DocumentComment]
	[Guid("D8CF88BA-5B56-4FB8-BCD1-5F2F58A2E607")]
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDocumentOutlineNode))]
	[ComVisible(true)]
	[ComClass("D8CF88BA-5B56-4FB8-BCD1-5F2F58A2E607", "D43A5956-6F5E-4672-A27F-074324A86328")]
	public class DocumentOutlineNode : IDocumentOutlineNode
	{
		internal const string CLASSID = "D8CF88BA-5B56-4FB8-BCD1-5F2F58A2E607";

		internal const string CLASSID_Interface = "D43A5956-6F5E-4672-A27F-074324A86328";

		private string _LevelText = null;

		private string _Text = null;

		internal XTextParagraphFlagElement _ParagraphFlag = null;

		private DocumentOutlineNode _Parent = null;

		private DocumentOutlineNodeList _ChildNodes = null;

		/// <summary>
		///       节点是否可见
		///       </summary>
		
		public bool Visible
		{
			get
			{
				if (_ParagraphFlag != null)
				{
					return _ParagraphFlag.RuntimeStyle.VisibleInDirectory;
				}
				return false;
			}
		}

		/// <summary>
		///       节点等级，根节点的Level值为0。
		///       </summary>
		
		public int Level
		{
			get
			{
				int num = 0;
				DocumentOutlineNode parent = _Parent;
				while (parent != null)
				{
					parent = parent._Parent;
					num++;
				}
				return num;
			}
		}

		/// <summary>
		///       表示层次的文本
		///       </summary>
		
		public string LevelText
		{
			get
			{
				return _LevelText;
			}
			set
			{
				_LevelText = value;
			}
		}

		/// <summary>
		///       文本
		///       </summary>
		
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		/// <summary>
		///       所属段落符号元素
		///       </summary>
		
		public XTextParagraphFlagElement ParagraphFlag => _ParagraphFlag;

		/// <summary>
		///       开始元素
		///       </summary>
		
		public XTextElement StartElement
		{
			get
			{
				if (_ParagraphFlag == null)
				{
					return null;
				}
				return _ParagraphFlag.ParagraphFirstContentElement;
			}
		}

		/// <summary>
		///       父节点
		///       </summary>
		
		public DocumentOutlineNode Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				_Parent = value;
			}
		}

		/// <summary>
		///       子节点列表
		///       </summary>
		
		public DocumentOutlineNodeList ChildNodes
		{
			get
			{
				if (_ChildNodes == null)
				{
					_ChildNodes = new DocumentOutlineNodeList();
				}
				return _ChildNodes;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentOutlineNode()
		{
		}

		/// <summary>
		///       让节点获得焦点
		///       </summary>
		
		public void Focus()
		{
			if (_ParagraphFlag != null)
			{
				_ParagraphFlag.Focus();
				if (_ParagraphFlag.WriterControl != null)
				{
					_ParagraphFlag.WriterControl.ScrollToCaretExt(ScrollToViewStyle.Top);
					_ParagraphFlag.WriterControl.Focus();
				}
			}
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		
		public override string ToString()
		{
			int num = 9;
			if (!string.IsNullOrEmpty(Text))
			{
				if (!string.IsNullOrEmpty(LevelText) && Text.StartsWith(LevelText))
				{
					return Text;
				}
				return LevelText + "|" + Text;
			}
			return LevelText;
		}
	}
}
