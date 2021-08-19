using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	[DCInternal]
	[ComVisible(false)]
	[DocumentComment]
	public class DOMTreeManager : IDisposable
	{
		private TreeViewCancelEventHandler _HandlerBeforeExpand;

		private TreeView _TreeView;

		private XTextDocument _Document;

		private WriterControl _WriterControl;

		private bool _DynamicLoadChildNodes;

		private TreeNode _DocumentNode;

		private bool _ExactMode;

		private static readonly object _LoadingFlag = new object();

		private TreeNode _CurrentLineNode;

		private TreeNode _MatchNode;

		public TreeView TreeView => _TreeView;

		public XTextDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				_Document = value;
			}
		}

		public WriterControl WriterControl
		{
			get
			{
				return _WriterControl;
			}
			set
			{
				_WriterControl = value;
			}
		}

		/// <summary>
		///       动态加载子节点
		///       </summary>
		public bool DynamicLoadChildNodes
		{
			get
			{
				return _DynamicLoadChildNodes;
			}
			set
			{
				_DynamicLoadChildNodes = value;
			}
		}

		/// <summary>
		///       精确显示模式
		///       </summary>
		public bool ExactMode
		{
			get
			{
				return _ExactMode;
			}
			set
			{
				_ExactMode = value;
			}
		}

		public DOMTreeManager(TreeView treeView_0)
		{
			int num = 3;
			_HandlerBeforeExpand = null;
			_TreeView = null;
			_Document = null;
			_WriterControl = null;
			_DynamicLoadChildNodes = false;
			_DocumentNode = null;
			_ExactMode = false;
			_CurrentLineNode = null;
			_MatchNode = null;
			
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			_TreeView = treeView_0;
			_HandlerBeforeExpand = _TreeView_BeforeExpand;
		}

		public void Dispose()
		{
			if (_TreeView != null)
			{
				_TreeView.BeforeExpand -= _HandlerBeforeExpand;
			}
			_HandlerBeforeExpand = null;
			_CurrentLineNode = null;
			_Document = null;
			_DocumentNode = null;
			_MatchNode = null;
			_TreeView = null;
			_WriterControl = null;
		}

		public void BindingTreeViewEvent()
		{
			if (_TreeView != null)
			{
				_TreeView.BeforeExpand += _HandlerBeforeExpand;
			}
		}

		private void _TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if (DynamicLoadChildNodes)
			{
				CheckChildNodes(e.Node);
			}
		}

		private void CheckChildNodes(TreeNode rootNode)
		{
			int num = 7;
			if (rootNode == null)
			{
				throw new ArgumentNullException("rootNode");
			}
			bool flag = false;
			if (rootNode.LastNode != null && rootNode.LastNode.Tag == _LoadingFlag)
			{
				rootNode.LastNode.Remove();
				flag = true;
			}
			else if (rootNode.FirstNode != null && rootNode.FirstNode.Tag == _LoadingFlag)
			{
				rootNode.FirstNode.Remove();
				flag = true;
			}
			if (flag)
			{
				if (rootNode.Tag is XTextElement)
				{
					XTextElement xTextElement = (XTextElement)rootNode.Tag;
					FillDomTreeNode(rootNode.Nodes, xTextElement.Elements, forLineMode: false);
				}
				else if (rootNode.Tag is DataSourceTreeNode)
				{
					DataSourceTreeNode dataSourceTreeNode = (DataSourceTreeNode)rootNode.Tag;
					FillDataSourceTree(rootNode.Nodes, dataSourceTreeNode.Nodes);
				}
			}
		}

		private void AddLoadingFlagNode(TreeNode rootNode)
		{
			TreeNode treeNode = new TreeNode("Loading");
			treeNode.Tag = _LoadingFlag;
			rootNode.Nodes.Add(treeNode);
		}

		public void RefreshViewDocumentAsRoot()
		{
			_TreeView.BeginUpdate();
			try
			{
				_TreeView.Nodes.Clear();
				_DocumentNode = new TreeNode();
				_TreeView.Nodes.Add(_DocumentNode);
				_CurrentLineNode = null;
				if (_Document != null)
				{
					RefreshDOMTree(_DocumentNode, _Document);
					_DocumentNode.Expand();
				}
				_TreeView.EndUpdate();
			}
			finally
			{
				_TreeView.EndUpdate();
			}
		}

		public void RefreshViewWriterControlAsRoot()
		{
			int num = 3;
			_TreeView.BeginUpdate();
			try
			{
				_TreeView.Nodes.Clear();
				TreeNode treeNode = new TreeNode("WriterControl:" + _WriterControl.Name);
				treeNode.Tag = _WriterControl;
				_TreeView.Nodes.Add(treeNode);
				TreeNode treeNode2 = new TreeNode("ViewControl");
				treeNode2.Tag = _WriterControl.InnerViewControl;
				treeNode.Nodes.Add(treeNode2);
				if (_WriterControl.InnerViewControl.Controls.Count > 0)
				{
					TreeNode treeNode3 = new TreeNode("HostedControls");
					treeNode.Nodes.Add(treeNode3);
					foreach (Control control in _WriterControl.InnerViewControl.Controls)
					{
						TreeNode treeNode4 = new TreeNode(control.GetType().FullName);
						treeNode4.Tag = control;
						treeNode3.Nodes.Add(treeNode4);
					}
				}
				TreeNode treeNode5 = new TreeNode("Options");
				treeNode5.Tag = _WriterControl.DocumentOptions;
				treeNode.Nodes.Add(treeNode5);
				_CurrentLineNode = new TreeNode("CurrentLine");
				treeNode.Nodes.Add(_CurrentLineNode);
				RefreshCurrentLine();
				XTextDocument document = _WriterControl.Document;
				TreeNode treeNode6 = new TreeNode("Pages");
				treeNode.Nodes.Add(treeNode6);
				for (int i = 0; i < _WriterControl.Pages.Count; i++)
				{
					PrintPage printPage = _WriterControl.Pages[i];
					TreeNode treeNode7 = new TreeNode("Page" + i + " Top:" + printPage.Top + " Height:" + printPage.Height + " Bottom:" + printPage.Bottom);
					treeNode7.Tag = printPage;
					treeNode6.Nodes.Add(treeNode7);
				}
				TreeNode treeNode8 = new TreeNode("Document:" + document.RuntimeTitle);
				treeNode8.Tag = document;
				treeNode.Nodes.Add(treeNode8);
				_DocumentNode = treeNode8;
				RefreshDOMTree(treeNode8, _WriterControl.Document);
				treeNode8.EnsureVisible();
				treeNode8.Expand();
				_TreeView.EndUpdate();
			}
			finally
			{
				_TreeView.EndUpdate();
			}
		}

		private void FillDataSourceTree(TreeNodeCollection nodes, DataSourceTreeNodeList dsNodes)
		{
			int num = 14;
			if (nodes != null && dsNodes != null)
			{
				foreach (DataSourceTreeNode dsNode in dsNodes)
				{
					TreeNode treeNode = new TreeNode(dsNode.Name);
					if (!string.IsNullOrEmpty(dsNode.FieldName))
					{
						treeNode.Text = dsNode.Name + "#" + dsNode.FieldName;
					}
					treeNode.Tag = dsNode;
					nodes.Add(treeNode);
					if (dsNode.HasChildNode)
					{
						if (DynamicLoadChildNodes)
						{
							AddLoadingFlagNode(treeNode);
						}
						else
						{
							FillDataSourceTree(treeNode.Nodes, dsNode.Nodes);
						}
					}
				}
			}
		}

		private void RefreshDOMTree(TreeNode docNode, XTextDocument document)
		{
			int num = 0;
			docNode.Text = "Document:" + document.RuntimeTitle;
			docNode.Tag = document;
			TreeNode treeNode = new TreeNode("Parameters:共" + document.Parameters.Count + "个");
			treeNode.Tag = document.Parameters;
			docNode.Nodes.Add(treeNode);
			foreach (DocumentParameter parameter in document.Parameters)
			{
				string text = parameter.ValueTypeFullName;
				if (string.IsNullOrEmpty(text) && parameter.Value != null)
				{
					text = parameter.Value.GetType().FullName;
				}
				TreeNode treeNode2 = new TreeNode(parameter.Name + ":" + text);
				if (parameter.Value == null)
				{
					treeNode2.Tag = parameter;
				}
				else
				{
					treeNode2.Tag = parameter.Value;
				}
				treeNode.Nodes.Add(treeNode2);
			}
			if (document.RuntimeDataSourceTree != null && document.RuntimeDataSourceTree.HasChildNode)
			{
				TreeNode treeNode3 = new TreeNode("DataSourceTree");
				treeNode3.Tag = document.RuntimeDataSourceTree;
				docNode.Nodes.Add(treeNode3);
				FillDataSourceTree(treeNode3.Nodes, document.RuntimeDataSourceTree.Nodes);
			}
			TreeNode treeNode4 = new TreeNode("PageSettings");
			treeNode4.Tag = document.PageSettings;
			docNode.Nodes.Add(treeNode4);
			TreeNode treeNode5 = new TreeNode("Styles");
			treeNode5.Tag = document.ContentStyles.Default;
			docNode.Nodes.Add(treeNode5);
			ContentStyleList styles = document.ContentStyles.Styles;
			for (int i = 0; i < styles.Count; i++)
			{
				TreeNode treeNode6 = new TreeNode("style" + i);
				treeNode6.Tag = styles[i];
				treeNode5.Nodes.Add(treeNode6);
			}
			TreeNode treeNode7 = new TreeNode("RepeatedImages");
			treeNode7.Tag = document.RepeatedImages;
			docNode.Nodes.Add(treeNode7);
			document.RepeatedImages.method_1(document);
			foreach (RepeatedImageValue repeatedImage in document.RepeatedImages)
			{
				TreeNode treeNode8 = new TreeNode(repeatedImage.ValueIndex + " | " + repeatedImage.ToString());
				treeNode8.Tag = repeatedImage;
				treeNode7.Nodes.Add(treeNode8);
			}
			if (document.UserHistories.Count > 0)
			{
				UserHistoryInfoList userHistories = document.UserHistories;
				TreeNode treeNode9 = new TreeNode("Histories");
				treeNode9.Tag = userHistories;
				docNode.Nodes.Add(treeNode9);
				for (int i = 0; i < userHistories.Count; i++)
				{
					TreeNode treeNode10 = new TreeNode("History" + i);
					treeNode10.Tag = userHistories[i];
					treeNode9.Nodes.Add(treeNode10);
				}
			}
			if (document.Comments.Count > 0)
			{
				DocumentCommentList comments = document.Comments;
				TreeNode treeNode11 = new TreeNode("Comments");
				treeNode11.Tag = comments;
				docNode.Nodes.Add(treeNode11);
				for (int i = 0; i < comments.Count; i++)
				{
					DocumentComment documentComment = comments[i];
					TreeNode treeNode12 = new TreeNode(documentComment.Text);
					treeNode12.Tag = documentComment;
					treeNode11.Nodes.Add(treeNode12);
				}
			}
			if (document.Body.RootParagraphFlag != null && document.Body.RootParagraphFlag.ChildParagraphs.Count > 0)
			{
				TreeNode treeNode13 = new TreeNode(WriterStrings.DocumentOutline);
				docNode.Nodes.Add(treeNode13);
				FillOutlineNode(document.Body.RootParagraphFlag, treeNode13, "");
			}
			FillDomTreeNode(docNode.Nodes, document.Elements, forLineMode: false);
		}

		/// <summary>
		///       填充DOM树
		///       </summary>
		/// <param name="nodes">根节点列表</param>
		/// <param name="elements">文档元素对象列表</param>
		/// <param name="forLineMode">文档行模式</param>
		/// <param name="extMode">精细模式</param>
		private void FillDomTreeNode(TreeNodeCollection nodes, XTextElementList elements, bool forLineMode)
		{
			int num = 4;
			StringBuilder stringBuilder = new StringBuilder();
			XTextCharElement xTextCharElement = null;
			foreach (XTextElement element in elements)
			{
				if (!forLineMode)
				{
					if (element is XTextCharElement)
					{
						if (xTextCharElement == null)
						{
							xTextCharElement = (XTextCharElement)element;
						}
						if (stringBuilder.Length == 0 || xTextCharElement.StyleIndex == element.StyleIndex)
						{
							stringBuilder.Append(((XTextCharElement)element).CharValue);
						}
						else
						{
							string text = stringBuilder.ToString();
							if (text.Length > 50)
							{
								text = text.Substring(0, 50);
							}
							TreeNode treeNode = new TreeNode(GClass369.smethod_2(text));
							SetForeColor(treeNode, xTextCharElement);
							treeNode.Tag = xTextCharElement;
							nodes.Add(treeNode);
							stringBuilder = new StringBuilder();
							stringBuilder.Append(((XTextCharElement)element).CharValue);
							xTextCharElement = (XTextCharElement)element;
						}
						continue;
					}
					if (stringBuilder.Length > 0)
					{
						TreeNode treeNode = new TreeNode(GClass369.smethod_2(stringBuilder.ToString()));
						SetForeColor(treeNode, xTextCharElement);
						treeNode.Tag = xTextCharElement;
						nodes.Add(treeNode);
						stringBuilder = new StringBuilder();
						xTextCharElement = null;
					}
				}
				if (element is XTextCharElement)
				{
					TreeNode treeNode2 = new TreeNode(element.Text);
					treeNode2.Tag = element;
					SetForeColor(treeNode2, element);
					nodes.Add(treeNode2);
				}
				else if (element is XTextParagraphFlagElement)
				{
					TreeNode treeNode3 = new TreeNode(element.DomDisplayName);
					treeNode3.Tag = element;
					SetForeColor(treeNode3, element);
					nodes.Add(treeNode3);
				}
				else if (element is XTextButtonElement)
				{
					TreeNode treeNode4 = new TreeNode(element.DomDisplayName);
					treeNode4.Tag = element;
					SetForeColor(treeNode4, element);
					nodes.Add(treeNode4);
				}
				else if (element is XTextFieldBorderElement)
				{
					XTextFieldBorderElement tag = (XTextFieldBorderElement)element;
					TreeNode treeNode4 = new TreeNode(element.DomDisplayName);
					treeNode4.Tag = tag;
					SetForeColor(treeNode4, element);
					nodes.Add(treeNode4);
				}
				else
				{
					TreeNode treeNode5 = new TreeNode(element.DomDisplayName);
					treeNode5.Tag = element;
					SetForeColor(treeNode5, element);
					nodes.Add(treeNode5);
					if (element is XTextTableCellElement)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)element;
						if (xTextTableCellElement.IsOverrided)
						{
							treeNode5.ForeColor = Color.Gray;
						}
					}
					else if (element is XTextTableElement)
					{
						XTextTableElement xTextTableElement = (XTextTableElement)element;
						for (int i = 0; i < xTextTableElement.Columns.Count; i++)
						{
							TreeNode treeNode6 = new TreeNode();
							treeNode6.Text = "Col" + i + " Width:" + xTextTableElement.Columns[i].Width;
							treeNode6.Tag = xTextTableElement.Columns[i];
							SetForeColor(treeNode6, element);
							treeNode5.Nodes.Add(treeNode6);
						}
					}
					else if (element is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
						treeNode5.Text = element.DomDisplayName;
					}
					else if (element is XTextShadowElement)
					{
						XTextElement shadowElement = ((XTextShadowElement)element).ShadowElement;
						TreeNode treeNode7 = new TreeNode(element.DomDisplayName);
						treeNode7.Tag = shadowElement;
						treeNode5.Nodes.Add(treeNode7);
					}
					else if (element is XTextControlHostElement)
					{
						treeNode5.Text = element.DomDisplayName;
					}
					if ((!forLineMode || ExactMode) && element is XTextContainerElement && element.Elements != null && element.Elements.Count > 0)
					{
						if (DynamicLoadChildNodes)
						{
							AddLoadingFlagNode(treeNode5);
						}
						else
						{
							FillDomTreeNode(treeNode5.Nodes, element.Elements, forLineMode);
						}
					}
					if (element is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
						if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.EditStyle == InputFieldEditStyle.DropdownList && xTextInputFieldElement.FieldSettings.ListSource != null && xTextInputFieldElement.FieldSettings.ListSource.Items != null)
						{
							foreach (ListItem item in xTextInputFieldElement.FieldSettings.ListSource.Items)
							{
								string text2 = item.Text;
								if (!string.IsNullOrEmpty(item.TextInList))
								{
									text2 = item.TextInList;
								}
								if (!string.IsNullOrEmpty(item.Value) && item.Value != text2)
								{
									text2 = text2 + "=" + item.Value;
								}
								TreeNode treeNode8 = new TreeNode("->" + text2);
								treeNode8.Tag = item;
								if (!xTextInputFieldElement.RuntimeVisible)
								{
									treeNode8.ForeColor = Color.DarkGray;
								}
								treeNode5.Nodes.Add(treeNode8);
							}
						}
					}
				}
			}
			if (stringBuilder.Length > 0)
			{
				TreeNode treeNode = new TreeNode(GClass369.smethod_2(stringBuilder.ToString()));
				treeNode.Tag = xTextCharElement;
				SetForeColor(treeNode, xTextCharElement);
				nodes.Add(treeNode);
				stringBuilder = new StringBuilder();
				xTextCharElement = null;
			}
		}

		private void SetForeColor(TreeNode node, XTextElement element)
		{
			if (!element.RuntimeVisible)
			{
				node.ForeColor = Color.DarkGray;
			}
		}

		private void FillOutlineNode(XTextParagraphFlagElement rootElement, TreeNode rootNode, string levelText)
		{
			int num = 7;
			int num2 = 1;
			foreach (XTextParagraphFlagElement childParagraph in rootElement.ChildParagraphs)
			{
				TreeNode treeNode = new TreeNode();
				if (childParagraph.ListItemElement != null)
				{
					treeNode.Text = childParagraph.ListItemElement.Text;
				}
				if (string.IsNullOrEmpty(treeNode.Text))
				{
					treeNode.Text = levelText + num2 + ".";
				}
				string text = childParagraph.ParagraphText;
				if (text != null && text.Length > 15)
				{
					text = text.Substring(0, 15);
				}
				if (text == null)
				{
					text = "";
				}
				if (text.StartsWith(treeNode.Text))
				{
					treeNode.Text = text;
				}
				else
				{
					treeNode.Text = treeNode.Text + "|" + text;
				}
				rootNode.Nodes.Add(treeNode);
				treeNode.Tag = childParagraph;
				if (childParagraph.ChildParagraphs != null && childParagraph.ChildParagraphs.Count > 0)
				{
					FillOutlineNode(childParagraph, treeNode, levelText + num2 + ".");
				}
				num2++;
			}
		}

		public bool RefreshCurrentLine()
		{
			if (_WriterControl != null && _CurrentLineNode != null)
			{
				XTextLine currentLine = _WriterControl.CurrentLine;
				if (currentLine != null)
				{
					_TreeView.BeginUpdate();
					_CurrentLineNode.Tag = currentLine;
					_CurrentLineNode.Nodes.Clear();
					FillDomTreeNode(_CurrentLineNode.Nodes, currentLine, forLineMode: true);
					_TreeView.EndUpdate();
					return true;
				}
			}
			return false;
		}

		public void SelectTreeNodeByCurrentElement()
		{
			int startIndex = _WriterControl.Selection.StartIndex;
			if (startIndex >= 0)
			{
				XTextDocumentContentElement currentContentElement = _WriterControl.Document.CurrentContentElement;
				XTextElement element = currentContentElement.Content[startIndex];
				SelectTreeNodeByElement(element);
			}
		}

		public void SelectTreeNodeByElement(XTextElement element)
		{
			int num = 11;
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			XTextDocumentContentElement documentContentElement = element.DocumentContentElement;
			if (documentContentElement == null)
			{
				return;
			}
			int viewIndex = documentContentElement.Content.IndexOf(element);
			if (element.Parent is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)element.Parent;
				if (xTextFieldElementBase.IsBackgroundTextElement(element) || element is XTextFieldBorderElement)
				{
					viewIndex = xTextFieldElementBase.StartElement.ViewIndex;
					if (xTextFieldElementBase.Elements.Count == 0)
					{
						element = xTextFieldElementBase;
						viewIndex = -1;
					}
				}
			}
			if (_DocumentNode == null)
			{
				return;
			}
			if (DynamicLoadChildNodes)
			{
				XTextElementList xTextElementList = new XTextElementList();
				XTextContainerElement parent = element.Parent;
				while (parent != null && parent != _Document)
				{
					xTextElementList.method_13(0, parent);
					parent = parent.Parent;
				}
				TreeNode treeNode = _DocumentNode;
				while (xTextElementList.Count > 0)
				{
					XTextElement xTextElement = xTextElementList[0];
					xTextElementList.RemoveAt(0);
					bool flag = false;
					CheckChildNodes(treeNode);
					foreach (TreeNode node in treeNode.Nodes)
					{
						if (node.Tag == xTextElement)
						{
							treeNode = node;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return;
					}
				}
				if (treeNode != null)
				{
					CheckChildNodes(treeNode);
				}
			}
			foreach (TreeNode node2 in _DocumentNode.Nodes)
			{
				if (node2.Tag == documentContentElement)
				{
					_MatchNode = null;
					SelectNode(node2, viewIndex, element);
					if (_MatchNode != null)
					{
						_TreeView.SelectedNode = _MatchNode;
						_TreeView.SelectedNode.EnsureVisible();
					}
					break;
				}
			}
		}

		private bool SelectNode(TreeNode rootNode, int viewIndex, XTextElement specifyElement)
		{
			XTextElement xTextElement = rootNode.Tag as XTextElement;
			if (xTextElement == null)
			{
				return false;
			}
			if (xTextElement is XTextTableColumnElement)
			{
				return false;
			}
			if (viewIndex < 0)
			{
				if (specifyElement != null)
				{
					foreach (TreeNode node in rootNode.Nodes)
					{
						if (node.Tag == specifyElement)
						{
							_MatchNode = node;
							return true;
						}
						if (SelectNode(node, viewIndex, specifyElement))
						{
							return true;
						}
					}
				}
				return false;
			}
			if (xTextElement is XTextCharElement)
			{
				if (viewIndex >= xTextElement.ViewIndex && viewIndex < xTextElement.ViewIndex + rootNode.Text.Length)
				{
					_MatchNode = rootNode;
					return true;
				}
				return false;
			}
			if (!xTextElement.RuntimeVisible)
			{
				return false;
			}
			int viewIndex2 = xTextElement.ViewIndex;
			if (viewIndex2 < 0)
			{
				if (xTextElement is XTextFieldElementBase)
				{
					viewIndex2 = xTextElement.FirstContentElementInPublicContent.ViewIndex;
				}
				else if (xTextElement is XTextTableElement)
				{
					viewIndex2 = xTextElement.FirstContentElementInPublicContent.ViewIndex;
				}
				else if (xTextElement.FirstContentElement != null && !(xTextElement is XTextDocumentContentElement))
				{
					viewIndex2 = xTextElement.FirstContentElementInPublicContent.ViewIndex;
				}
			}
			if (viewIndex2 == viewIndex)
			{
				_MatchNode = rootNode;
				return true;
			}
			if (rootNode.Nodes.Count > 0)
			{
				if (xTextElement is XTextSectionElement && ((XTextSectionElement)xTextElement).RuntimeIsCollapsed)
				{
					return false;
				}
				foreach (TreeNode node2 in rootNode.Nodes)
				{
					if (specifyElement != null && node2.Tag == specifyElement)
					{
						_MatchNode = node2;
						return true;
					}
					if (SelectNode(node2, viewIndex, specifyElement))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       根据树状列表中的当前节点设置文档中的当前元素
		///       </summary>
		public void SelectElementBySelectedNode()
		{
			if (_TreeView.SelectedNode == null || !(_TreeView.SelectedNode.Tag is XTextElement))
			{
				return;
			}
			XTextElement xTextElement = (XTextElement)_TreeView.SelectedNode.Tag;
			if (!xTextElement.RuntimeVisible)
			{
				return;
			}
			_WriterControl.Focus();
			if (xTextElement is XTextCharElement)
			{
				XTextCharElement xTextCharElement = (XTextCharElement)_TreeView.SelectedNode.Tag;
				int length = _TreeView.SelectedNode.Text.Length;
				XTextDocumentContentElement documentContentElement = xTextCharElement.DocumentContentElement;
				if (documentContentElement != null)
				{
					documentContentElement.Focus();
					documentContentElement.SetSelection(xTextCharElement.ViewIndex, length);
				}
			}
			else if (xTextElement is XTextParagraphFlagElement)
			{
				xTextElement.Focus();
			}
			else
			{
				xTextElement.Select();
				_WriterControl.InnerViewControl.Update();
				_WriterControl.FlashElement(xTextElement, autoScroll: true);
			}
		}

		/// <summary>
		///       删除目前选择的节点
		///       </summary>
		/// <returns>
		/// </returns>
		public bool DeleteSelectedNode()
		{
			if (_TreeView.SelectedNode == null)
			{
				return false;
			}
			if (_TreeView.SelectedNode.Tag is XTextElement && !(_TreeView.SelectedNode.Tag is XTextCharElement) && !(_TreeView.SelectedNode.Tag is XTextParagraphFlagElement))
			{
				if (_TreeView.SelectedNode.Tag is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)_TreeView.SelectedNode.Tag;
					xTextContainerElement.EditorDelete(logUndo: false);
					if (_WriterControl != null)
					{
						_WriterControl.RefreshDocument();
						return true;
					}
				}
				else if (_TreeView.SelectedNode.Tag is XTextObjectElement)
				{
					XTextObjectElement xTextObjectElement = (XTextObjectElement)_TreeView.SelectedNode.Tag;
					xTextObjectElement.Parent.RemoveChild(xTextObjectElement);
					if (_WriterControl != null)
					{
						_WriterControl.RefreshDocument();
						return true;
					}
				}
			}
			return false;
		}
	}
}
