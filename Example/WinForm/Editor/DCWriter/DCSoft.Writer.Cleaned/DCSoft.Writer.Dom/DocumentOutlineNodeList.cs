using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档大纲节点列表
	///       </summary>
	[Serializable]
	
	[ComClass("1406C5C0-0A17-4D71-AF7E-32AD55E497F3", "8F4FD322-682A-427A-8157-58766B58BE7C")]
	[Guid("1406C5C0-0A17-4D71-AF7E-32AD55E497F3")]
	[DebuggerDisplay("Count={ Count }")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	
	[ComDefaultInterface(typeof(IDocumentOutlineNodeList))]
	public class DocumentOutlineNodeList : List<DocumentOutlineNode>, IDocumentOutlineNodeList
	{
		private class MyNodeEnumer : TreeNodeEnumerable
		{
			public MyNodeEnumer(DocumentOutlineNodeList list)
				: base(list)
			{
			}

			public override IEnumerable GetChildNodes(object instance)
			{
				return ((DocumentOutlineNode)instance).ChildNodes;
			}
		}

		internal const string CLASSID = "1406C5C0-0A17-4D71-AF7E-32AD55E497F3";

		internal const string CLASSID_Interface = "8F4FD322-682A-427A-8157-58766B58BE7C";

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentOutlineNodeList()
		{
		}

		internal DocumentOutlineNode Search(int viewIndex)
		{
			if (base.Count == 0)
			{
				return null;
			}
			MyNodeEnumer myNodeEnumer = new MyNodeEnumer(this);
			DocumentOutlineNode result = null;
			foreach (DocumentOutlineNode item in myNodeEnumer)
			{
				int viewIndex2 = item.ParagraphFlag.ParagraphFirstContentElement.ViewIndex;
				if (viewIndex2 > viewIndex)
				{
					break;
				}
				result = item;
			}
			return result;
		}

		/// <summary>
		///       填充节点
		///       </summary>
		/// <param name="rootElement">
		/// </param>
		/// <param name="levelText">
		/// </param>
		internal void Fill(XTextParagraphFlagElement rootElement, string levelText)
		{
			int num = 17;
			if (rootElement != null)
			{
				int num2 = 0;
				foreach (XTextParagraphFlagElement childParagraph in rootElement.ChildParagraphs)
				{
					num2++;
					DocumentOutlineNode documentOutlineNode = new DocumentOutlineNode();
					documentOutlineNode.Text = childParagraph.ParagraphText;
					if (documentOutlineNode.Text != null && documentOutlineNode.Text.Length > 15)
					{
						documentOutlineNode.Text = documentOutlineNode.Text.Substring(0, 15);
					}
					documentOutlineNode.LevelText = levelText + num2 + ".";
					documentOutlineNode._ParagraphFlag = childParagraph;
					Add(documentOutlineNode);
					if (childParagraph.ChildParagraphs.Count > 0)
					{
						documentOutlineNode.ChildNodes.Fill(childParagraph, documentOutlineNode.LevelText);
					}
					foreach (DocumentOutlineNode childNode in documentOutlineNode.ChildNodes)
					{
						childNode.Parent = documentOutlineNode;
					}
				}
			}
		}
	}
}
