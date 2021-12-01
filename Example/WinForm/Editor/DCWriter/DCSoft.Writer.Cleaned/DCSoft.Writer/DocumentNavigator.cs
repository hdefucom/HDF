using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档导航者
	///       </summary>
	/// <remarks>袁永福到此一游</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComClass("EDD3C839-2F43-40D9-BDCF-63C4773AC1EB", "D9642920-1041-4B9A-8EC3-FAE9760D7F08")]
	[DocumentComment]
	[ComDefaultInterface(typeof(IDocumentNavigator))]
	[Guid("EDD3C839-2F43-40D9-BDCF-63C4773AC1EB")]
	[DCPublishAPI]
	public class DocumentNavigator : IDocumentNavigator
	{
		private class MyNodeEnumer : TreeNodeEnumerable
		{
			public MyNodeEnumer(NavigateNodeList navigateNodeList_0)
				: base(navigateNodeList_0)
			{
			}

			public override IEnumerable GetChildNodes(object instance)
			{
				return ((NavigateNode)instance).Nodes;
			}
		}

		internal const string string_0 = "EDD3C839-2F43-40D9-BDCF-63C4773AC1EB";

		internal const string string_1 = "D9642920-1041-4B9A-8EC3-FAE9760D7F08";

		private WriterControl writerControl_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private NavigateNodeList navigateNodeList_0 = new NavigateNodeList();

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		[ComVisible(false)]
		public WriterControl WriterControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		[ComVisible(false)]
		public XTextDocument Document
		{
			get
			{
				if (writerControl_0 == null)
				{
					return xtextDocument_0;
				}
				return writerControl_0.Document;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       根节点对象
		///       </summary>
		[DCPublishAPI]
		public NavigateNodeList Nodes => navigateNodeList_0;

		/// <summary>
		///       根据文档当前插入点的位置获得导航节点对象
		///       </summary>
		[DCPublishAPI]
		public NavigateNode CurrentNode
		{
			get
			{
				if (Nodes.Count > 0)
				{
					int startIndex = Document.Selection.StartIndex;
					MyNodeEnumer myNodeEnumer = new MyNodeEnumer(Nodes);
					NavigateNode navigateNode = null;
					foreach (NavigateNode item in myNodeEnumer)
					{
						if (item.Position > startIndex)
						{
							break;
						}
						navigateNode = item;
					}
					if (navigateNode == null && Nodes.Count > 0)
					{
						navigateNode = Nodes[0];
					}
					return navigateNode;
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public DocumentNavigator()
		{
		}

		/// <summary>
		///       获得节点字符串
		///       </summary>
		/// <returns>字符串</returns>
		[DCPublishAPI]
		public string GetNodeString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			method_1(Nodes, null, stringBuilder);
			return stringBuilder.ToString();
		}

		internal string method_0()
		{
			return XMLHelper.SaveObjectToIndentXMLStringFreedom(Nodes);
		}

		private void method_1(NavigateNodeList navigateNodeList_1, string string_2, StringBuilder stringBuilder_0)
		{
			int num = 1;
			foreach (NavigateNode item in navigateNodeList_1)
			{
				if (stringBuilder_0.Length > 0)
				{
					stringBuilder_0.Append("&");
				}
				stringBuilder_0.Append(item.ID);
				stringBuilder_0.Append("=");
				if (string_2 == null)
				{
					stringBuilder_0.Append(HttpUtility.HtmlAttributeEncode(item.Text));
					if (item.Nodes.Count > 0)
					{
						method_1(item.Nodes, item.Text, stringBuilder_0);
					}
				}
				else
				{
					stringBuilder_0.Append(HttpUtility.HtmlAttributeEncode(string_2 + "." + item.Text));
					if (item.Nodes.Count > 0)
					{
						method_1(item.Nodes, string_2 + "." + item.Text, stringBuilder_0);
					}
				}
			}
		}

		/// <summary>
		///       获得指定编号的节点对象
		///       </summary>
		/// <param name="id">节点编号</param>
		/// <returns>节点对象</returns>
		[DCPublishAPI]
		public NavigateNode GetNodeByID(string string_2)
		{
			if (string.IsNullOrEmpty(string_2))
			{
				return null;
			}
			return method_2(Nodes, string_2);
		}

		private NavigateNode method_2(NavigateNodeList navigateNodeList_1, string string_2)
		{
			if (navigateNodeList_1 == null)
			{
				return null;
			}
			foreach (NavigateNode item in navigateNodeList_1)
			{
				if (item.ID == string_2)
				{
					return item;
				}
				NavigateNode navigateNode = method_2(item.Nodes, string_2);
				if (navigateNode != null)
				{
					return navigateNode;
				}
			}
			return null;
		}

		/// <summary>
		///       刷新导航信息结构
		///       </summary>
		[DCPublishAPI]
		public void Refresh()
		{
			if (XTextDocument.smethod_13(GEnum6.const_83))
			{
				int num = 1;
				XTextDocument document = Document;
				navigateNodeList_0.Clear();
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				foreach (DocumentContentStyle style in document.ContentStyles.Styles)
				{
					if (style.HasTitleLevel)
					{
						dictionary[document.ContentStyles.Styles.IndexOf(style)] = style.TitleLevel;
					}
				}
				if (dictionary.Count > 0)
				{
					Stack<NavigateNode> stack = new Stack<NavigateNode>();
					int num2 = 0;
					foreach (XTextElement item in document.Body.Content)
					{
						if (dictionary.ContainsKey(item.StyleIndex))
						{
							int num3 = dictionary[item.StyleIndex];
							if (num2 > 0)
							{
								num2 = 0;
								while (stack.Count > 0 && stack.Peek().Level >= num3)
								{
									stack.Pop();
								}
							}
							else
							{
								while (stack.Count > 0 && stack.Peek().Level > num3)
								{
									stack.Pop();
								}
							}
							if (stack.Count > 0 && stack.Peek().Level == num3)
							{
								stack.Peek().AppendElement(item);
							}
							else
							{
								NavigateNode navigateNode = new NavigateNode(Convert.ToString(num++));
								navigateNode.Level = num3;
								navigateNode.AppendElement(item);
								if (stack.Count == 0)
								{
									Nodes.Add(navigateNode);
								}
								else
								{
									stack.Peek().AppendNode(navigateNode);
								}
								stack.Push(navigateNode);
							}
						}
						else
						{
							num2++;
						}
					}
				}
			}
		}
	}
}
