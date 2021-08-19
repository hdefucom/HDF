#define DEBUG
using DCSoft.Common;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       多文档拼接模式的病程记录文档控制器对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComDefaultInterface(typeof(ICourseRecordDocumentController))]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("1C310423-D2B1-477A-8823-0CAB48F70F24")]
	[ComVisible(true)]
	[ComSourceInterfaces(typeof(ICourseRecordDocumentControllerComEvents))]
	[ComClass("1C310423-D2B1-477A-8823-0CAB48F70F24", "D4233D0C-373E-4B70-A044-2144E6577ADB", "D9D124CA-C208-4089-9DF2-3858F01D217F")]
	public class CourseRecordDocumentController : ICourseRecordDocumentController
	{
		internal const string CLASSID = "1C310423-D2B1-477A-8823-0CAB48F70F24";

		internal const string CLASSID_Interface = "D4233D0C-373E-4B70-A044-2144E6577ADB";

		internal const string CLASSID_ComEventInterface = "D9D124CA-C208-4089-9DF2-3858F01D217F";

		private WriterControl _ViewControl = null;

		private bool _ShowGridLine = true;

		private Color _ReadonlyBackColor = Color.WhiteSmoke;

		private XTextContainerElement _LastContentContainerElement = null;

		private Dictionary<string, string> _AttributeNamesLabelIDMaps = new Dictionary<string, string>();

		private string _ContactString = "->";

		private string _AuthorNameAttributeName = "AuthorName";

		private string _TitleAttributeName = "Title";

		private string _FileNameAttributeName = "FileName";

		private string _FileFormatAttributeName = "FileFormat";

		private Dictionary<XTextLabelElement, Dictionary<int, string>> _LabelTexts = null;

		private Dictionary<XTextContainerElement, int> _ContentVersions = new Dictionary<XTextContainerElement, int>();

		/// <summary>
		///       查看文档内容的编辑器控件对象
		///       </summary>
		public WriterControl ViewControl
		{
			get
			{
				return _ViewControl;
			}
			set
			{
				_ViewControl = value;
			}
		}

		/// <summary>
		///       针对COM的接口
		///       </summary>
		[Browsable(false)]
		public IAxWriterControl ComViewControl
		{
			get
			{
				if (_ViewControl is AxWriterControl)
				{
					return (AxWriterControl)_ViewControl;
				}
				return null;
			}
			set
			{
				_ViewControl = (WriterControl)value;
			}
		}

		/// <summary>
		///       是否显示网格线
		///       </summary>
		[DefaultValue(true)]
		public bool ShowGridLine
		{
			get
			{
				return _ShowGridLine;
			}
			set
			{
				_ShowGridLine = value;
			}
		}

		/// <summary>
		///       只读区域背景色
		///       </summary>
		public Color ReadonlyBackColor
		{
			get
			{
				return _ReadonlyBackColor;
			}
			set
			{
				_ReadonlyBackColor = value;
			}
		}

		/// <summary>
		///       各个数据之间的连接字符串
		///       </summary>
		public string ContactString
		{
			get
			{
				return _ContactString;
			}
			set
			{
				_ContactString = value;
			}
		}

		/// <summary>
		///       文档创建者名称的属性名
		///       </summary>
		public string AuthorNameAttributeName
		{
			get
			{
				return _AuthorNameAttributeName;
			}
			set
			{
				_AuthorNameAttributeName = value;
			}
		}

		/// <summary>
		///       标题属性名称
		///       </summary>
		public string TitleAttributeName
		{
			get
			{
				return _TitleAttributeName;
			}
			set
			{
				_TitleAttributeName = value;
			}
		}

		/// <summary>
		///       文件名属性名
		///       </summary>
		public string FileNameAttributeName
		{
			get
			{
				return _FileNameAttributeName;
			}
			set
			{
				_FileNameAttributeName = value;
			}
		}

		/// <summary>
		///       文件格式属性名
		///       </summary>
		public string FileFormatAttributeName
		{
			get
			{
				return _FileFormatAttributeName;
			}
			set
			{
				_FileFormatAttributeName = value;
			}
		}

		/// <summary>
		///       根表格对象
		///       </summary>
		public XTextTableElement RootTable => (XTextTableElement)ViewControl.Document.Body.Elements.method_5(typeof(XTextTableElement));

		/// <summary>
		///       获得当前插入点所在的根单元格对象
		///       </summary>
		public XTextTableCellElement CurrentRootCell
		{
			get
			{
				XTextElement xTextElement = ViewControl.CurrentElement;
				XTextTableCellElement xTextTableCellElement;
				while (true)
				{
					if (xTextElement != null)
					{
						if (xTextElement is XTextTableCellElement)
						{
							xTextTableCellElement = (XTextTableCellElement)xTextElement;
							if (xTextTableCellElement.OwnerTable.Parent == ViewControl.Document.Body)
							{
								break;
							}
						}
						xTextElement = xTextElement.Parent;
						continue;
					}
					return null;
				}
				return xTextTableCellElement;
			}
		}

		/// <summary>
		///       当前文档正文的容器元素对象
		///       </summary>
		public XTextContainerElement CurrentContentContainerElement
		{
			get
			{
				int num = 1;
				XTextElement xTextElement = ViewControl.CurrentElement;
				while (true)
				{
					if (xTextElement != null)
					{
						if (xTextElement.ID != null && xTextElement.ID.StartsWith("RecordContent_"))
						{
							break;
						}
						xTextElement = xTextElement.Parent;
						continue;
					}
					return null;
				}
				return (XTextContainerElement)xTextElement;
			}
		}

		/// <summary>
		///       判断能否编辑当前记录
		///       </summary>
		public bool CanEditCurrentRecord => CurrentContentContainerElement.RuntimeContentReadonly;

		/// <summary>
		///       是否存在被修改尚未保存的记录
		///       </summary>
		[Browsable(false)]
		public bool HasModifiedRecord
		{
			get
			{
				foreach (XTextInputFieldElement key in _ContentVersions.Keys)
				{
					if (_ContentVersions[key] != key.ContentVersion)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       当前记录发生改变事件
		///       </summary>
		public event WriterEventHandler CurrentRecordChanged = null;

		/// <summary>
		///       记录删除事件
		///       </summary>
		public event WriterCancelEventHandler BeforeRecordDeleted = null;

		/// <summary>
		///       启动控制器
		///       </summary>
		public void Start()
		{
			int num = 2;
			if (_ViewControl == null)
			{
				throw new ArgumentNullException("ViewControl");
			}
			ElementEventTemplate elementEventTemplate = new ElementEventTemplate();
			elementEventTemplate.BeforePaint += eet_BeforePaint;
			ViewControl.GlobalEventTemplates[typeof(XTextLabelElement)] = elementEventTemplate;
			ViewControl.SelectionChanged += ViewControl_SelectionChanged;
			ViewControl.FormView = FormViewMode.Strict;
		}

		private void ViewControl_SelectionChanged(object sender, WriterEventArgs e)
		{
			XTextContainerElement currentContentContainerElement = CurrentContentContainerElement;
			if (currentContentContainerElement != _LastContentContainerElement)
			{
				_LastContentContainerElement = currentContentContainerElement;
				if (this.CurrentRecordChanged != null)
				{
					WriterEventArgs e2 = new WriterEventArgs(ViewControl, ViewControl.Document, currentContentContainerElement);
					this.CurrentRecordChanged(this, e2);
				}
			}
		}

		/// <summary>
		///       设置属性名称和页眉标题Label元素编号对应关系
		///       </summary>
		/// <param name="attributeName">文档属性名称</param>
		/// <param name="labelID">标题label元素编号</param>
		public void SetAttributeNameLabelIDMap(string attributeName, string labelID)
		{
			_AttributeNamesLabelIDMaps[attributeName] = labelID;
		}

		/// <summary>
		///       刷新标题文本内容
		///       </summary>
		public void RefreshHeaderText()
		{
			_LabelTexts = null;
			ViewControl.Invalidate();
		}

		private void eet_BeforePaint(object sender, ElementPaintEventArgs e)
		{
			try
			{
				if (_LabelTexts != null)
				{
					goto IL_01c3;
				}
				XTextContainerElement[] allContentField = GetAllContentField(modifiedOnly: false);
				if (allContentField != null && allContentField.Length != 0)
				{
					_LabelTexts = new Dictionary<XTextLabelElement, Dictionary<int, string>>();
					foreach (string key in _AttributeNamesLabelIDMaps.Keys)
					{
						XTextLabelElement xTextLabelElement = ViewControl.Document.GetElementById(_AttributeNamesLabelIDMaps[key]) as XTextLabelElement;
						if (xTextLabelElement != null)
						{
							Dictionary<int, string> dictionary = new Dictionary<int, string>();
							_LabelTexts[xTextLabelElement] = dictionary;
							for (int i = 0; i < ViewControl.Document.Pages.Count; i++)
							{
								PrintPage printPage = ViewControl.Document.Pages[i];
								StringBuilder stringBuilder = new StringBuilder();
								string text = null;
								XTextContainerElement[] array = allContentField;
								foreach (XTextContainerElement xTextContainerElement in array)
								{
									if (xTextContainerElement.Attributes != null && xTextContainerElement.FirstContentElement.OwnerLine.OwnerPage == printPage)
									{
										string value = xTextContainerElement.Attributes.GetValue(key);
										if (!string.IsNullOrEmpty(value) && (text == null || text != value))
										{
											text = value;
											if (stringBuilder.Length > 0)
											{
												stringBuilder.Append(ContactString);
											}
											stringBuilder.Append(value);
										}
									}
								}
								dictionary[i + 1] = stringBuilder.ToString();
							}
						}
					}
					goto IL_01c3;
				}
				goto end_IL_0001;
				IL_01c3:
				XTextLabelElement xTextLabelElement2 = e.Element as XTextLabelElement;
				if (_LabelTexts.ContainsKey(xTextLabelElement2))
				{
					Dictionary<int, string> dictionary2 = _LabelTexts[xTextLabelElement2];
					if (dictionary2.ContainsKey(xTextLabelElement2.OwnerDocument.PageIndex))
					{
						xTextLabelElement2.Text = dictionary2[xTextLabelElement2.OwnerDocument.PageIndex];
					}
					else
					{
						xTextLabelElement2.Text = null;
					}
				}
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		/// <summary>
		///       刷新视图
		///       </summary>
		/// <param name="documents">
		/// </param>
		public void RefreshView(XTextDocument[] documents)
		{
			int num = 0;
			RefreshHeaderText();
			_ContentVersions.Clear();
			_LastContentContainerElement = null;
			if (documents == null || documents.Length == 0)
			{
				return;
			}
			if (RootTable == null)
			{
				XTextTableElement xTextTableElement = new XTextTableElement();
				xTextTableElement.ID = "rootTable";
				XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
				xTextTableColumnElement.Width = ViewControl.Document.Body.ClientWidth - 3f;
				xTextTableElement.Columns.Add(xTextTableColumnElement);
				ViewControl.Document.Body.ContentBuilder.Append(xTextTableElement);
			}
			WriterControlState writerControlState = new WriterControlState(ViewControl);
			int num2 = 0;
			foreach (XTextDocument xTextDocument in documents)
			{
				if (xTextDocument.Body.HasContentElement)
				{
					InsertRecordRow(num2, xTextDocument, readOnly: true);
					num2++;
				}
			}
			if (RootTable.Rows.Count == 0)
			{
				ViewControl.Document.Body.Elements.Remove(RootTable);
			}
			ViewControl.RefreshDocument();
			writerControlState.Restore();
			ViewControl.UpdateTextCaret();
		}

		/// <summary>
		///       插入记录行
		///       </summary>
		/// <param name="recordIndex">
		/// </param>
		/// <param name="document">
		/// </param>
		/// <param name="readOnly">
		/// </param>
		/// <returns>
		/// </returns>
		public virtual XTextContainerElement InsertRecordRow(int recordIndex, XTextDocument document, bool readOnly)
		{
			int num = 19;
			XTextTableElement rootTable = RootTable;
			if (rootTable == null)
			{
				return null;
			}
			int num2 = recordIndex * 3;
			XTextTableRowElement xTextTableRowElement = rootTable.CreateRowInstance();
			rootTable.InsertChildElement(num2, xTextTableRowElement);
			XTextTableCellElement xTextTableCellElement = rootTable.CreateCellInstance();
			xTextTableRowElement.AppendChildElement(xTextTableCellElement);
			xTextTableCellElement.Style.PaddingLeft = 15f;
			xTextTableCellElement.Style.PaddingTop = 15f;
			xTextTableCellElement.Style.PaddingRight = 15f;
			xTextTableCellElement.Style.PaddingBottom = 15f;
			if (ShowGridLine)
			{
				xTextTableCellElement.Style.BorderWidth = 1f;
				xTextTableCellElement.Style.BorderTop = true;
				xTextTableCellElement.Style.BorderBottom = true;
			}
			xTextTableCellElement.ContentBuilder.AppendRawMode = true;
			if (document != null && document.Info != null)
			{
				xTextTableCellElement.ContentBuilder.AppendTextWithStyleString(document.Info.Title, "Bold:True");
			}
			XTextTableRowElement xTextTableRowElement2 = rootTable.CreateRowInstance();
			xTextTableRowElement2.SpecifyHeight = 300f;
			rootTable.InsertChildElement(num2 + 1, xTextTableRowElement2);
			xTextTableCellElement = rootTable.CreateCellInstance();
			xTextTableRowElement2.AppendChildElement(xTextTableCellElement);
			xTextTableCellElement.ContentBuilder.AppendRawMode = true;
			xTextTableCellElement.Style.PaddingLeft = 15f;
			xTextTableCellElement.Style.PaddingTop = 15f;
			xTextTableCellElement.Style.PaddingRight = 15f;
			xTextTableCellElement.Style.PaddingBottom = 15f;
			if (ShowGridLine)
			{
				xTextTableCellElement.Style.GridLineType = ContentGridLineType.ExtentToBottom;
				xTextTableCellElement.Style.BorderWidth = 1f;
				xTextTableCellElement.Style.BorderTop = true;
				xTextTableCellElement.Style.BorderBottom = true;
			}
			if (readOnly)
			{
				xTextTableCellElement.Style.BackgroundColor = Color.WhiteSmoke;
				xTextTableCellElement.Style.PrintBackColor = Color.Transparent;
			}
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextTableCellElement.ContentBuilder.Append(xTextInputFieldElement);
			xTextInputFieldElement.BackgroundText = "病程记录内容";
			xTextInputFieldElement.ID = "RecordContent_" + recordIndex;
			xTextInputFieldElement.ContentReadonly = ((!readOnly) ? ContentReadonlyState.Inherit : ContentReadonlyState.True);
			xTextInputFieldElement.EnableHighlight = EnableState.Disabled;
			if (document != null)
			{
				if (document.Body.HasContentElement)
				{
					XTextElementList xTextElementList = document.Body.Elements.Clone();
					document.Body.Elements.Clear();
					ViewControl.Document.ImportElements(xTextElementList);
					if (xTextElementList.LastElement is XTextParagraphFlagElement)
					{
						xTextElementList.RemoveAt(xTextElementList.Count - 1);
					}
					xTextInputFieldElement.ContentBuilder.AppendRange(xTextElementList);
				}
				if (document.Attributes != null)
				{
					xTextInputFieldElement.Attributes = document.Attributes;
				}
				else
				{
					xTextInputFieldElement.Attributes = new XAttributeList();
				}
				xTextInputFieldElement.Attributes.SetValue(FileNameAttributeName, document.FileName);
				xTextInputFieldElement.Attributes.SetValue(FileFormatAttributeName, document.FileFormat);
				xTextInputFieldElement.Attributes.SetValue(TitleAttributeName, document.Info.Title);
			}
			XTextTableRowElement xTextTableRowElement3 = rootTable.CreateRowInstance();
			rootTable.InsertChildElement(num2 + 2, xTextTableRowElement3);
			xTextTableCellElement = rootTable.CreateCellInstance();
			xTextTableRowElement3.AppendChildElement(xTextTableCellElement);
			xTextTableCellElement.Style.PaddingLeft = 15f;
			xTextTableCellElement.Style.PaddingTop = 15f;
			xTextTableCellElement.Style.PaddingRight = 15f;
			xTextTableCellElement.Style.PaddingBottom = 15f;
			if (ShowGridLine)
			{
				xTextTableCellElement.Style.BorderWidth = 1f;
				xTextTableCellElement.Style.BorderTop = true;
				xTextTableCellElement.Style.BorderBottom = true;
			}
			xTextTableCellElement.ContentBuilder.AppendRawMode = true;
			xTextTableCellElement.ContentBuilder.AppendTextWithStyleString("医生:", "Bold:True");
			if (document != null && document.Attributes != null)
			{
				xTextTableCellElement.ContentBuilder.AppendTextWithStyleString(document.Attributes.GetValue(AuthorNameAttributeName), "Bold:True");
			}
			xTextTableCellElement.ContentBuilder.AppendParagraphFlagWithStyleString("Align:Right");
			_ContentVersions[xTextInputFieldElement] = xTextInputFieldElement.ContentVersion;
			return xTextInputFieldElement;
		}

		/// <summary>
		///       追加新的文档
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>操作是否成功</returns>
		public bool AppendNewRecord(XTextDocument document)
		{
			int num = 3;
			if (document == null)
			{
				throw new ArgumentNullException("templateDocument");
			}
			XTextTableElement rootTable = RootTable;
			XTextContainerElement xTextContainerElement = InsertRecordRow(rootTable.Rows.Count / 3, document, readOnly: false);
			if (xTextContainerElement != null)
			{
				ViewControl.RefreshDocument();
				xTextContainerElement.Focus();
				return true;
			}
			return false;
		}

		/// <summary>
		///       在当前位置插入新的记录
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="downward">向下插入</param>
		/// <returns>
		/// </returns>
		public bool InsertNewRecordAtCurrentPosition(XTextDocument document, bool downward)
		{
			int num = 2;
			if (document == null)
			{
				throw new ArgumentNullException("templateDocument");
			}
			XTextTableElement rootTable = RootTable;
			XTextTableCellElement currentRootCell = CurrentRootCell;
			if (rootTable != null && currentRootCell != null)
			{
				int num2 = rootTable.Rows.IndexOf(currentRootCell.OwnerRow);
				if (num2 >= 0)
				{
					int num3 = (num2 - num2 % 3) / 3;
					if (downward)
					{
						num3++;
					}
					XTextContainerElement xTextContainerElement = InsertRecordRow(num3, document, readOnly: false);
					if (xTextContainerElement != null)
					{
						ViewControl.RefreshDocument();
						xTextContainerElement.Focus();
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       删除当前光标所在的病程记录对象
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool DeleteCurrentRecord()
		{
			XTextContainerElement currentContentContainerElement = CurrentContentContainerElement;
			if (currentContentContainerElement != null)
			{
				if (this.BeforeRecordDeleted != null)
				{
					WriterCancelEventArgs writerCancelEventArgs = new WriterCancelEventArgs(ViewControl, ViewControl.Document, currentContentContainerElement);
					this.BeforeRecordDeleted(this, writerCancelEventArgs);
					if (writerCancelEventArgs.Cancel)
					{
						return false;
					}
				}
				XTextTableRowElement ownerRow = currentContentContainerElement.OwnerCell.OwnerRow;
				RootTable.Rows.RemoveRange(ownerRow.Index - 1, 3);
				RootTable.EditorRefreshView();
				return true;
			}
			return false;
		}

		/// <summary>
		///       锁定所有的记录
		///       </summary>
		public void LockAllRecord()
		{
			XTextTableElement rootTable = RootTable;
			for (int i = 0; i < rootTable.Rows.Count; i += 3)
			{
				XTextTableCellElement cell = rootTable.GetCell(i + 1, 0, throwException: false);
				if (cell != null)
				{
					cell.Style.BackgroundColor = Color.WhiteSmoke;
					cell.Style.PrintBackColor = Color.Transparent;
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)cell.Elements.method_5(typeof(XTextInputFieldElement));
					if (xTextInputFieldElement != null)
					{
						xTextInputFieldElement.ContentReadonly = ContentReadonlyState.True;
					}
				}
			}
			ViewControl.Document.OnDocumentContentChanged();
			ViewControl.Document.OnSelectionChanged();
			ViewControl.Invalidate();
		}

		/// <summary>
		///       开始编辑当前记录
		///       </summary>
		/// <returns>
		/// </returns>
		public bool EditCurrentRecord()
		{
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)CurrentContentContainerElement;
			if (!(xTextInputFieldElement?.RuntimeContentReadonly ?? false))
			{
				return false;
			}
			ViewControl.Document.CancelLogUndo();
			ViewControl.Document.UndoList.Clear();
			xTextInputFieldElement.ContentReadonly = ContentReadonlyState.False;
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextInputFieldElement.Parent;
			xTextTableCellElement.Style.BackgroundColor = Color.Transparent;
			xTextInputFieldElement.Focus();
			ViewControl.Invalidate();
			return true;
		}

		/// <summary>
		///       获取所有内容输入域
		///       </summary>
		/// <param name="modifiedOnly">
		/// </param>
		/// <returns>
		/// </returns>
		public XTextContainerElement[] GetAllContentField(bool modifiedOnly)
		{
			int num = 9;
			List<XTextContainerElement> list = new List<XTextContainerElement>();
			XTextTableElement rootTable = RootTable;
			if (RootTable == null)
			{
				return null;
			}
			for (int i = 0; i < rootTable.Rows.Count; i++)
			{
				XTextTableCellElement cell = rootTable.GetCell(i, 0, throwException: true);
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)cell.Elements.method_5(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement == null || xTextInputFieldElement.ID == null || !xTextInputFieldElement.ID.StartsWith("RecordContent_"))
				{
					continue;
				}
				if (modifiedOnly)
				{
					if (!_ContentVersions.ContainsKey(xTextInputFieldElement) || _ContentVersions[xTextInputFieldElement] != xTextInputFieldElement.ContentVersion)
					{
						list.Add(xTextInputFieldElement);
					}
				}
				else
				{
					list.Add(xTextInputFieldElement);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		///       返还内容被修改的文档对象列表
		///       </summary>
		/// <returns>文档对象列表</returns>
		public XTextDocument[] GetModifiedDocuments()
		{
			return InnerGetDocumentss(modifiedOnly: true);
		}

		/// <summary>
		///       获得所有的文档对象列表
		///       </summary>
		/// <returns>文档对象列表</returns>
		public XTextDocument[] GetAllDocuments()
		{
			return InnerGetDocumentss(modifiedOnly: false);
		}

		/// <summary>
		///       返还内容被修改的文档对象列表
		///       </summary>
		/// <returns>文档对象列表</returns>
		private XTextDocument[] InnerGetDocumentss(bool modifiedOnly)
		{
			XTextContainerElement[] allContentField = GetAllContentField(modifiedOnly);
			if (allContentField != null && allContentField.Length > 0)
			{
				List<XTextDocument> list = new List<XTextDocument>();
				XTextContainerElement[] array = allContentField;
				for (int i = 0; i < array.Length; i++)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)array[i];
					XTextDocument xTextDocument = xTextInputFieldElement.CreateContentDocument(includeThis: false);
					xTextDocument.Attributes = xTextInputFieldElement.Attributes.Clone();
					xTextDocument.FileName = xTextInputFieldElement.Attributes.GetValue(FileNameAttributeName);
					xTextDocument.FileFormat = xTextInputFieldElement.Attributes.GetValue(FileFormatAttributeName);
					xTextDocument.Info.Title = xTextInputFieldElement.Attributes.GetValue(TitleAttributeName);
					list.Add(xTextDocument);
				}
				return list.ToArray();
			}
			return null;
		}

		/// <summary>
		///       清除内部的文档标记，声明所有的文档记录都已经保存成功了
		///       </summary>
		public void ClearModifiedFlags()
		{
			XTextContainerElement[] allContentField = GetAllContentField(modifiedOnly: false);
			XTextContainerElement[] array = allContentField;
			foreach (XTextContainerElement xTextContainerElement in array)
			{
				_ContentVersions[xTextContainerElement] = xTextContainerElement.ContentVersion;
			}
		}
	}
}
