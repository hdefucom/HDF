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
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       基于文档节和输入域的多文档拼接模式的病程记录文档控制器对象
	///       </summary>
	/// <remarks>
	///       本对象的使用过程
	///       1. 设置ViewControl属性，绑定编辑器控件。
	///       2. 调用Start()方法启动控制器。
	///       3. 调用LoadDocumentInfoFromXMLString() 加载病程记录文件信息，如果不调用这个方法
	///          则无法处理超长时间段的病程记录。
	///       4. 确定显示范围，比如按周显示或按月显示。过期则翻页显示。
	///       5. 多次调用AddDocumentFromSourceRecord() 加载文件内容
	///       编制 袁永福
	///       </remarks>
	[DocumentComment]
	[ComVisible(true)]
	[ComSourceInterfaces(typeof(ISectionCourseRecordDocumentControllerComEvents))]
	[ComClass("87EDC519-FAE7-4912-BF81-EE144E39D97D", "9ADF3486-1428-4EA2-BFD3-C92C728CBE09", "38138D28-31D1-42BB-8BF0-0103723BAF78")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("87EDC519-FAE7-4912-BF81-EE144E39D97D")]
	[ComDefaultInterface(typeof(ISectionCourseRecordDocumentController))]
	[DCPublishAPI]
	public class SectionCourseRecordDocumentController : ISectionCourseRecordDocumentController
	{
		private const string RecordBodyPrefix = "RecordBody_";

		internal const string CLASSID = "87EDC519-FAE7-4912-BF81-EE144E39D97D";

		internal const string CLASSID_Interface = "9ADF3486-1428-4EA2-BFD3-C92C728CBE09";

		internal const string CLASSID_ComEventInterface = "38138D28-31D1-42BB-8BF0-0103723BAF78";

		private WriterControl _ViewControl = null;

		private bool _IsRefreshDocumentAfterAppendingRecord = false;

		private bool _IsFocusRecordAfterAppending = false;

		private Color _ReadonlyRecordBackColor = Color.LightGray;

		private bool _ImportUserTrack = true;

		private bool _GenerateTitleAndMark = false;

		private bool _ClearContentWhenRefreshView = false;

		private Color _ReadonlyBackColor = Color.WhiteSmoke;

		private bool _AutoSetEnablePermission = true;

		private XTextContainerElement _LastContentContainerElement = null;

		private Dictionary<string, string> _AttributeNamesLabelIDMaps = new Dictionary<string, string>();

		private string _ContactString = "->";

		private string _NewPageFlagAttributeName = "NewPageFlag";

		private string _AuthorNameAttributeName = "AuthorName";

		private List<SectionCourseRecordSource> _SourceRecords = new List<SectionCourseRecordSource>();

		private SectionCourseDocumentInfo _DocumentInfo = new SectionCourseDocumentInfo();

		private Color _ActivedRecordBorderColor = Color.Blue;

		private Dictionary<XTextContainerElement, int> _ContentVersions = new Dictionary<XTextContainerElement, int>();

		private SectionCourseRecord[] _Records = null;

		/// <summary>
		///       查看文档内容的编辑器控件对象
		///       </summary>
		[ComVisible(false)]
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
		///        获取或设置是否在执行AppendRecord之后刷新文档
		///       </summary>
		public bool IsRefreshDocumentAfterAppendingRecord
		{
			get
			{
				return _IsRefreshDocumentAfterAppendingRecord;
			}
			set
			{
				_IsRefreshDocumentAfterAppendingRecord = value;
			}
		}

		/// <summary>
		///        获取或设置是否在执行AppendRecord之后对Record给予焦点
		///       </summary>
		public bool IsFocusRecordAfterAppending
		{
			get
			{
				return _IsFocusRecordAfterAppending;
			}
			set
			{
				_IsFocusRecordAfterAppending = value;
			}
		}

		/// <summary>
		///       只读的记录的背景色
		///       </summary>
		public Color ReadonlyRecordBackColor
		{
			get
			{
				return _ReadonlyRecordBackColor;
			}
			set
			{
				_ReadonlyRecordBackColor = value;
			}
		}

		/// <summary>
		///       加载文档时导入权限及用户痕迹信息
		///       </summary>
		public bool ImportUserTrack
		{
			get
			{
				return _ImportUserTrack;
			}
			set
			{
				_ImportUserTrack = value;
			}
		}

		/// <summary>
		///       输出标题和签名
		///       </summary>
		public bool GenerateTitleAndMark
		{
			get
			{
				return _GenerateTitleAndMark;
			}
			set
			{
				_GenerateTitleAndMark = value;
			}
		}

		/// <summary>
		///       刷新时是否清空文档正文内容
		///       </summary>
		public bool ClearContentWhenRefreshView
		{
			get
			{
				return _ClearContentWhenRefreshView;
			}
			set
			{
				_ClearContentWhenRefreshView = value;
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
				if (ViewControl != null)
				{
					return ViewControl.DocumentOptions.ViewOptions.ShowGridLine;
				}
				return false;
			}
			set
			{
				if (ViewControl != null)
				{
					ViewControl.DocumentOptions.ViewOptions.ShowGridLine = true;
				}
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
		///       自动启用授权控制
		///       </summary>
		public bool AutoSetEnablePermission
		{
			get
			{
				return _AutoSetEnablePermission;
			}
			set
			{
				_AutoSetEnablePermission = value;
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
		///       是否强制分页标记属性名
		///       </summary>
		public string NewPageFlagAttributeName
		{
			get
			{
				return _NewPageFlagAttributeName;
			}
			set
			{
				_NewPageFlagAttributeName = value;
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
		///       刷新文档时使用的病程记录文档信息对象
		///       </summary>
		public SectionCourseDocumentInfo DocumentInfo
		{
			get
			{
				return _DocumentInfo;
			}
			set
			{
				_DocumentInfo = value;
			}
		}

		/// <summary>
		///       当前被激活的记录的边框色
		///       </summary>
		public Color ActivedRecordBorderColor
		{
			get
			{
				return _ActivedRecordBorderColor;
			}
			set
			{
				_ActivedRecordBorderColor = value;
			}
		}

		/// <summary>
		///       记录个数
		///       </summary>
		public int RecordCount => Records.Length;

		/// <summary>
		///       当前文档正文的容器元素对象
		///       </summary>
		public XTextContainerElement CurrentContentContainerElement => CurrentRecord?.ContentElement;

		/// <summary>
		///       是否存在被修改尚未保存的记录
		///       </summary>
		[Browsable(false)]
		public bool HasModifiedRecord
		{
			get
			{
				SectionCourseRecord[] records = Records;
				int num = 0;
				while (true)
				{
					if (num < records.Length)
					{
						SectionCourseRecord sectionCourseRecord = records[num];
						if (sectionCourseRecord.Modified)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       控制器操作的病程记录对象数组
		///       </summary>
		public SectionCourseRecord[] Records
		{
			get
			{
				if (_Records == null)
				{
					List<SectionCourseRecord> list = new List<SectionCourseRecord>();
					int num = 0;
					foreach (XTextSectionElement section in ViewControl.Document.Sections)
					{
						SectionCourseRecord sectionCourseRecord = (SectionCourseRecord)section.TagValue;
						sectionCourseRecord._Index = num;
						num++;
						list.Add(sectionCourseRecord);
					}
					_Records = list.ToArray();
				}
				return _Records;
			}
		}

		/// <summary>
		///       当前光标所在的记录对象
		///       </summary>
		public SectionCourseRecord CurrentRecord
		{
			get
			{
				XTextSectionElement xTextSectionElement = (XTextSectionElement)ViewControl.GetCurrentElement(typeof(XTextSectionElement));
				if (xTextSectionElement == null)
				{
					return null;
				}
				SectionCourseRecord sectionCourseRecord = (SectionCourseRecord)xTextSectionElement.TagValue;
				ViewControl.CollectOuterReference(sectionCourseRecord);
				return sectionCourseRecord;
			}
			set
			{
				value?.ContentElement.Focus();
			}
		}

		/// <summary>
		///       当前记录正在改变事件
		///       </summary>
		public event SelectionChangingEventHandler CurrentRecordChanging = null;

		/// <summary>
		///       当前记录发生改变事件
		///       </summary>
		public event WriterEventHandler CurrentRecordChanged = null;

		/// <summary>
		///       记录删除事件
		///       </summary>
		public event WriterCancelEventHandler BeforeRecordDeleted = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		public SectionCourseRecordDocumentController()
		{
		}

		public SectionCourseRecordDocumentController(WriterControl writerControl_0)
		{
			ViewControl = writerControl_0;
			_IsRefreshDocumentAfterAppendingRecord = ViewControl.IsUpdating;
			_IsFocusRecordAfterAppending = ViewControl.IsUpdating;
		}

		/// <summary>
		///       启动控制器
		///       </summary>
		public void Start()
		{
			int num = 7;
			if (_ViewControl == null)
			{
				throw new ArgumentNullException("ViewControl");
			}
			ViewControl.SelectionChanged += ViewControl_SelectionChanged;
			ViewControl.SelectionChanging += ViewControl_SelectionChanging;
			ViewControl.AfterRefreshPages += ViewControl_AfterRefreshPages;
			if (GenerateTitleAndMark)
			{
				ViewControl.FormView = FormViewMode.Strict;
			}
			else
			{
				ViewControl.FormView = FormViewMode.Disable;
			}
		}

		private void ViewControl_AfterRefreshPages(object sender, WriterEventArgs e)
		{
			InitLabelPageTexts();
		}

		private void ViewControl_SelectionChanging(object sender, SelectionChangingEventArgs e)
		{
			if (this.CurrentRecordChanging != null)
			{
				this.CurrentRecordChanging(this, e);
			}
		}

		private void ViewControl_SelectionChanged(object sender, WriterEventArgs e)
		{
			XTextContainerElement currentContentContainerElement = CurrentContentContainerElement;
			if (currentContentContainerElement == _LastContentContainerElement)
			{
				return;
			}
			_LastContentContainerElement = currentContentContainerElement;
			if (AutoSetEnablePermission)
			{
				SectionCourseRecord currentRecord = CurrentRecord;
				if (currentRecord != null)
				{
					ViewControl.DocumentOptions.SecurityOptions.EnablePermission = currentRecord.RecordSource.EnablePermission;
				}
			}
			if (this.CurrentRecordChanged != null)
			{
				WriterEventArgs e2 = new WriterEventArgs(ViewControl, ViewControl.Document, currentContentContainerElement);
				this.CurrentRecordChanged(this, e2);
			}
		}

		/// <summary>
		///       设置属性名称和页眉标题Label元素编号对应关系
		///       </summary>
		/// <param name="attributeName">文档属性名称</param>
		/// <param name="labelID">标题label元素编号</param>
		public void SetAttributeNameLabelIDMap(string attributeName, string labelID)
		{
			XTextLabelElement xTextLabelElement = ViewControl.GetElementById(labelID) as XTextLabelElement;
			if (xTextLabelElement != null)
			{
				xTextLabelElement.AttributeNameForContactAction = attributeName;
				xTextLabelElement.LinkTextForContactAction = ContactString;
				if (xTextLabelElement.ContactAction == LabelTextContactActionMode.Disable)
				{
					xTextLabelElement.ContactAction = LabelTextContactActionMode.Normal;
				}
			}
			else
			{
				_AttributeNamesLabelIDMaps[attributeName] = labelID;
			}
		}

		/// <summary>
		///       刷新标题文本内容
		///       </summary>
		public void RefreshHeaderText()
		{
			InitLabelPageTexts();
			ViewControl.Invalidate();
		}

		private void InitLabelPageTexts()
		{
			try
			{
				if (Records.Length != 0)
				{
					ViewControl.Document.RefreshLabelContactString();
					foreach (string key in _AttributeNamesLabelIDMaps.Keys)
					{
						XTextLabelElement xTextLabelElement = ViewControl.Document.GetElementById(_AttributeNamesLabelIDMaps[key]) as XTextLabelElement;
						if (xTextLabelElement != null)
						{
							if (xTextLabelElement.ContactAction == LabelTextContactActionMode.Disable)
							{
								xTextLabelElement.ContactAction = LabelTextContactActionMode.Normal;
							}
							xTextLabelElement.AttributeNameForContactAction = key;
							xTextLabelElement.LinkTextForContactAction = ContactString;
							xTextLabelElement.StrictMatchPageIndex = true;
							xTextLabelElement.UpdateContactAction();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		/// <summary>
		///       加载病程记录框架模板
		///       </summary>
		/// <param name="fileName">文件名</param>
		public void LoadFrameTemplateByFileName(string fileName)
		{
			ViewControl.ExecuteCommand("FileOpen", showUI: false, fileName);
		}

		/// <summary>
		///       从一个字符串加载病程记录框架模板
		///       </summary>
		/// <param name="text">字符串</param>
		/// <param name="format">文件格式</param>
		public void LoadFrameTemplateByString(string text, string format)
		{
			ViewControl.LoadDocumentFromString(text, format);
		}

		/// <summary>
		///       从一个文本读取器加载病程记录框架模板
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="format">文件格式</param>
		[ComVisible(false)]
		public void LoadFrameTemplateByReader(TextReader reader, string format)
		{
			ViewControl.LoadDocument(reader, format);
		}

		/// <summary>
		///       从一个文件流中加载病程记录框架模板
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <param name="format">文件格式</param>
		[ComVisible(false)]
		public void LoadFrameTemplateByStream(Stream stream, string format)
		{
			ViewControl.LoadDocument(stream, format);
		}

		/// <summary>
		///       添加文档对象
		///       </summary>
		/// <param name="document">
		/// </param>
		[Obsolete("建议使用AddDocumentFromSourceRecord()")]
		public void AddDocument(XTextDocument document)
		{
			int num = 7;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			_SourceRecords.Add(new SectionCourseRecordSource(document, this));
		}

		/// <summary>
		///       从病程记录来源添加文档对象
		///       </summary>
		/// <param name="sourceRecord">
		/// </param>
		public void AddDocumentFromSourceRecord(SectionCourseRecordSource sourceRecord)
		{
			int num = 10;
			if (sourceRecord == null)
			{
				throw new ArgumentNullException("sourceRecord");
			}
			_SourceRecords.Add(sourceRecord);
		}

		/// <summary>
		///       根据文件名加载文档
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="format">文件格式</param>
		[Obsolete("建议使用AddDocumentFromSourceRecord()")]
		public void AddDocumentFromFile(string fileName, string format)
		{
			int num = 12;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.LoadFromFile(fileName, format);
			AddDocument(xTextDocument);
		}

		/// <summary>
		///       根据字符串数据加载文档
		///       </summary>
		/// <param name="strData">文本数据</param>
		/// <param name="format">文件格式</param>
		[Obsolete("建议使用AddDocumentFromSourceRecord()")]
		public void AddDocumentFromString(string strData, string format)
		{
			int num = 9;
			if (string.IsNullOrEmpty(strData))
			{
				throw new ArgumentNullException("strData");
			}
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.LoadFromString(strData, format);
			AddDocument(xTextDocument);
		}

		/// <summary>
		///       根据添加的文档来刷新内容
		///       </summary>
		public void RefreshViewWithDocuments()
		{
			if (_SourceRecords.Count > 0)
			{
				SectionCourseRecordSource[] records = _SourceRecords.ToArray();
				_SourceRecords.Clear();
				RefreshView(records);
			}
		}

		/// <summary>
		///       从一个XML字符串加载文档信息
		///       </summary>
		/// <param name="xmlText">XML字符串</param>
		public void LoadDocumentInfoFromXMLString(string xmlText)
		{
			SectionCourseDocumentInfo sectionCourseDocumentInfo = new SectionCourseDocumentInfo();
			sectionCourseDocumentInfo.LoadFromXMLString(xmlText);
			_DocumentInfo = sectionCourseDocumentInfo;
		}

		/// <summary>
		///       设置要显示的文件记录起始编号。
		///       </summary>
		/// <param name="startFileIndex">起始的文件记录编号</param>
		/// <returns>最终确认的起始文件记录编号</returns>
		public int SetStartFileIndex(int startFileIndex)
		{
			ViewControl.StartPageIndex = 0;
			foreach (SectionCourseFileInfo file in DocumentInfo.Files)
			{
				file.NeedLoadDocumentContent = false;
			}
			if (startFileIndex < 0 || startFileIndex >= DocumentInfo.Files.Count)
			{
				return 0;
			}
			int num = 0;
			SectionCourseFileInfo sectionCourseFileInfo = DocumentInfo.Files[startFileIndex];
			for (int i = 0; i < DocumentInfo.PageLinePositions.Count; i++)
			{
				float num2 = DocumentInfo.PageLinePositions[i];
				if (!(num2 > sectionCourseFileInfo.Top))
				{
					continue;
				}
				float num3 = 0f;
				if (i > 0)
				{
					num3 = DocumentInfo.PageLinePositions[i - 1];
					ViewControl.StartPageIndex = i - 1;
				}
				int num4 = startFileIndex;
				while (num4 >= 0)
				{
					SectionCourseFileInfo sectionCourseFileInfo2 = DocumentInfo.Files[num4];
					if (!(sectionCourseFileInfo2.Top <= num3))
					{
						num4--;
						continue;
					}
					num = num4;
					break;
				}
				break;
			}
			for (int i = num; i < DocumentInfo.Files.Count; i++)
			{
				DocumentInfo.Files[i].NeedLoadDocumentContent = true;
			}
			return num;
		}

		/// <summary>
		///       判断是否需要加载指定文件名的文档内容
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>是否要加载文档内容</returns>
		public bool NeedLoadDocumentContent(string fileName)
		{
			foreach (SectionCourseFileInfo file in DocumentInfo.Files)
			{
				if (file.FileName == fileName)
				{
					return file.NeedLoadDocumentContent;
				}
			}
			return true;
		}

		/// <summary>
		///       保存文档信息到XML字符串
		///       </summary>
		/// <returns>XML字符串</returns>
		public string SaveDocumentInfoToXMLString()
		{
			return GetLastestDocumentInfo()?.SaveToXMLString();
		}

		/// <summary>
		///       获得最新版本的病程记录文档信息对象
		///       </summary>
		/// <returns>获得的信息对象</returns>
		private SectionCourseDocumentInfo GetLastestDocumentInfo()
		{
			SectionCourseDocumentInfo sectionCourseDocumentInfo = new SectionCourseDocumentInfo();
			sectionCourseDocumentInfo.PageLinePositions = new List<float>();
			foreach (PrintPage page in ViewControl.Pages)
			{
				sectionCourseDocumentInfo.PageLinePositions.Add(page.Bottom);
			}
			foreach (XTextElement element in ViewControl.Document.Body.Elements)
			{
				if (element is XTextSectionElement)
				{
					XTextSectionElement xTextSectionElement = (XTextSectionElement)element;
					if (xTextSectionElement.TagValue is SectionCourseFileInfoList)
					{
						SectionCourseFileInfoList collection = (SectionCourseFileInfoList)xTextSectionElement.TagValue;
						sectionCourseDocumentInfo.Files.AddRange(collection);
					}
					else if (xTextSectionElement.TagValue is SectionCourseRecord)
					{
						SectionCourseRecord sectionCourseRecord = (SectionCourseRecord)xTextSectionElement.TagValue;
						SectionCourseFileInfo sectionCourseFileInfo = new SectionCourseFileInfo();
						sectionCourseFileInfo.FileName = sectionCourseRecord.FileName;
						sectionCourseFileInfo.Top = xTextSectionElement.AbsTop;
						sectionCourseFileInfo.Height = xTextSectionElement.Height;
						sectionCourseDocumentInfo.Files.Add(sectionCourseFileInfo);
					}
				}
			}
			return sectionCourseDocumentInfo;
		}

		/// <summary>
		///       刷新视图
		///       </summary>
		/// <param name="records">
		/// </param>
		public void RefreshView(SectionCourseRecordSource[] records)
		{
			ViewControl.Document.SpecifyPageLinePosition = null;
			RefreshHeaderText();
			_ContentVersions.Clear();
			_LastContentContainerElement = null;
			if (records == null || records.Length == 0)
			{
				return;
			}
			if (ClearContentWhenRefreshView)
			{
				ViewControl.Document.Body.Elements.Clear();
			}
			ViewControl.Document.Body.FixDomState();
			ViewControl.Document.Body.ContentReadonly = ContentReadonlyState.True;
			WriterControlState writerControlState = new WriterControlState(ViewControl);
			SectionCourseRecordSource[] array;
			if (DocumentInfo != null)
			{
				SectionCourseFileInfoList sectionCourseFileInfoList = new SectionCourseFileInfoList();
				for (int i = 0; i < DocumentInfo.Files.Count; i++)
				{
					SectionCourseFileInfo sectionCourseFileInfo = DocumentInfo.Files[i];
					bool flag = false;
					array = records;
					foreach (SectionCourseRecordSource sectionCourseRecordSource in array)
					{
						if (sectionCourseFileInfo.FileName == sectionCourseRecordSource.FileName || sectionCourseRecordSource.Document != null)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						sectionCourseFileInfoList.Add(sectionCourseFileInfo);
						continue;
					}
					if (i > 0)
					{
						float num = sectionCourseFileInfo.Top + sectionCourseFileInfo.Height - DocumentInfo.Files[0].Top;
						XTextSectionElement xTextSectionElement = new XTextSectionElement();
						xTextSectionElement.OwnerDocument = ViewControl.Document;
						xTextSectionElement.TagValue = sectionCourseFileInfoList;
						xTextSectionElement.SpecifyHeight = 0f - num;
						ViewControl.Document.Body.ContentBuilder.Append(xTextSectionElement);
						xTextSectionElement.OwnerDocument = ViewControl.Document;
						xTextSectionElement.Style.BorderWidth = 0f;
						xTextSectionElement.Style.BorderColor = ActivedRecordBorderColor;
						xTextSectionElement.Style.PrintBackColor = Color.Transparent;
						xTextSectionElement.Style.BackgroundColor = ReadonlyBackColor;
						if (DocumentInfo.PageLinePositions != null)
						{
							List<float> list = new List<float>();
							foreach (float pageLinePosition in DocumentInfo.PageLinePositions)
							{
								float num2 = pageLinePosition;
								if (!(num2 < sectionCourseFileInfo.Top))
								{
									break;
								}
								list.Add(num2);
							}
							ViewControl.Document.SpecifyPageLinePosition = list.ToArray();
						}
					}
					break;
				}
			}
			int num3 = 0;
			array = records;
			foreach (SectionCourseRecordSource sectionCourseRecordSource in array)
			{
				InsertRecordRow(num3, sectionCourseRecordSource);
				num3++;
			}
			ViewControl.RefreshDocument();
			writerControlState.Restore();
			if (!GenerateTitleAndMark)
			{
				ViewControl.FormView = FormViewMode.Disable;
			}
			ViewControl.UpdateTextCaret();
		}

		internal virtual SectionCourseRecord InsertRecordRow(int recordIndex, SectionCourseRecordSource sourceRecord)
		{
			int num = 13;
			if (!GenerateTitleAndMark && ViewControl != null)
			{
				ViewControl.FormView = FormViewMode.Disable;
			}
			int num2 = 0;
			XTextDocumentBodyElement body = ViewControl.Document.Body;
			if (recordIndex > 0)
			{
				int num3 = 0;
				num2 = body.Elements.Count - 1;
				for (int i = 0; i < body.Elements.Count; i++)
				{
					if (!(body.Elements[i] is XTextSectionElement))
					{
						continue;
					}
					XTextSectionElement xTextSectionElement = (XTextSectionElement)body.Elements[i];
					if (xTextSectionElement.TagValue is SectionCourseRecord)
					{
						if (num3 == recordIndex - 1)
						{
							num2 = i + 1;
							break;
						}
						num3++;
					}
				}
			}
			bool enablePermission = ViewControl.DocumentOptions.SecurityOptions.EnablePermission;
			ViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
			if (sourceRecord.NewPage)
			{
				XTextPageBreakElement xtextElement_ = new XTextPageBreakElement();
				ViewControl.Document.Body.Elements.method_13(num2, xtextElement_);
				num2++;
			}
			XTextSectionElement xTextSectionElement2 = new XTextSectionElement();
			ViewControl.Document.Body.Elements.method_13(num2, xTextSectionElement2);
			xTextSectionElement2.OwnerDocument = ViewControl.Document;
			xTextSectionElement2.Style.BorderWidth = 0f;
			if (sourceRecord.RecordBorderColor.A != 0)
			{
				xTextSectionElement2.Style.BorderColor = sourceRecord.RecordBorderColor;
				xTextSectionElement2.Style.BorderWidth = 1f;
				xTextSectionElement2.Style.BorderLeft = true;
				xTextSectionElement2.Style.BorderTop = true;
				xTextSectionElement2.Style.BorderRight = true;
				xTextSectionElement2.Style.BorderBottom = true;
			}
			else
			{
				xTextSectionElement2.Style.BorderColor = ActivedRecordBorderColor;
			}
			xTextSectionElement2.Style.PrintBackColor = Color.Transparent;
			if (sourceRecord.SpecifyBackgroundCololr.A != 0)
			{
				xTextSectionElement2.Style.BackgroundColor = sourceRecord.SpecifyBackgroundCololr;
			}
			else if (sourceRecord.Readonly)
			{
				xTextSectionElement2.Style.BackgroundColor = ReadonlyBackColor;
			}
			xTextSectionElement2.Style.PaddingBottom = sourceRecord.RecordSpacing;
			xTextSectionElement2.ContentBuilder.AppendRawMode = true;
			xTextSectionElement2.ContentReadonly = ((!sourceRecord.Readonly) ? ContentReadonlyState.False : ContentReadonlyState.True);
			XTextContainerElement xTextContainerElement = null;
			if (!GenerateTitleAndMark)
			{
				xTextContainerElement = xTextSectionElement2;
				if (sourceRecord.Document != null && sourceRecord.Document.Body.HasContentElement)
				{
					ViewControl.DocumentOptions.SecurityOptions.EnablePermission = sourceRecord.EnablePermission;
					XTextElementList elements = sourceRecord.Document.Body.Elements.Clone();
					sourceRecord.Document.Body.Elements.Clear();
					ViewControl.Document.ImportElementsSpceifyImportPermssion(elements, ImportUserTrack, ImportUserTrack);
					xTextSectionElement2.ContentBuilder.AppendRange(elements);
					ViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
				}
				xTextSectionElement2.FixElements();
			}
			else
			{
				xTextSectionElement2.ContentBuilder.AppendTextWithStyleString(sourceRecord.Title, "bold:true");
				xTextSectionElement2.ContentBuilder.AppendParagraphFlagWithStyleString("Align:Center");
				XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
				xTextSectionElement2.ContentBuilder.Append(xTextInputFieldElement);
				xTextInputFieldElement.BackgroundText = "病程记录内容";
				xTextInputFieldElement.ID = "RecordBody_" + recordIndex;
				xTextInputFieldElement.EnableHighlight = EnableState.Disabled;
				xTextContainerElement = xTextInputFieldElement;
				bool flag = true;
				if (sourceRecord.Document != null && sourceRecord.Document.Body.HasContentElement)
				{
					ViewControl.DocumentOptions.SecurityOptions.EnablePermission = sourceRecord.EnablePermission;
					XTextElementList elements = sourceRecord.Document.Body.Elements.Clone();
					sourceRecord.Document.Body.Elements.Clear();
					ViewControl.Document.ImportElements(elements);
					xTextInputFieldElement.ContentBuilder.AppendRange(elements);
					if (elements.LastElement is XTextParagraphFlagElement)
					{
						flag = false;
					}
					ViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
				}
				if (flag)
				{
					xTextSectionElement2.ContentBuilder.AppendParagraphFlag();
				}
				xTextSectionElement2.ContentBuilder.AppendTextWithStyleString("医生:", "Bold:True");
				if (!string.IsNullOrEmpty(sourceRecord.Author))
				{
					xTextSectionElement2.ContentBuilder.AppendTextWithStyleString(sourceRecord.Author, "Bold:True");
				}
				xTextSectionElement2.ContentBuilder.AppendParagraphFlagWithStyleString("Align:Right");
				_ContentVersions[xTextInputFieldElement] = xTextInputFieldElement.ContentVersion;
			}
			ViewControl.DocumentOptions.SecurityOptions.EnablePermission = enablePermission;
			SectionCourseRecord sectionCourseRecord2 = (SectionCourseRecord)(xTextSectionElement2.TagValue = new SectionCourseRecord(this, xTextSectionElement2, xTextContainerElement, sourceRecord.Document, sourceRecord));
			sectionCourseRecord2.Modified = sourceRecord.Modified;
			_Records = null;
			return sectionCourseRecord2;
		}

		/// <summary>
		///       根据病程记录来源追加新的记录
		///       </summary>
		/// <param name="recordSource">
		/// </param>
		/// <returns>
		/// </returns>
		public bool AppendNewRecordByRecordSource(SectionCourseRecordSource recordSource)
		{
			int num = 12;
			if (recordSource == null)
			{
				throw new ArgumentNullException("recordSource");
			}
			if (recordSource.Document == null)
			{
				throw new ArgumentNullException("recordSource.Document");
			}
			SectionCourseRecord sectionCourseRecord = InsertRecordRow(RecordCount, recordSource);
			if (sectionCourseRecord != null)
			{
				if (_IsRefreshDocumentAfterAppendingRecord)
				{
					ViewControl.RefreshDocument();
				}
				if (_IsFocusRecordAfterAppending)
				{
					sectionCourseRecord.ContentElement.Focus();
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       追加新的文档
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>操作是否成功</returns>
		[Obsolete("已过时，请使用 AppendNewRecordByRecordSource（）")]
		public bool AppendNewRecord(XTextDocument document)
		{
			int num = 10;
			if (document == null)
			{
				throw new ArgumentNullException("templateDocument");
			}
			SectionCourseRecordSource sectionCourseRecordSource = new SectionCourseRecordSource(document, this);
			sectionCourseRecordSource.Readonly = false;
			sectionCourseRecordSource.Modified = true;
			SectionCourseRecord sectionCourseRecord = InsertRecordRow(RecordCount, sectionCourseRecordSource);
			if (sectionCourseRecord != null)
			{
				if (!ViewControl.IsUpdating)
				{
					ViewControl.RefreshDocument();
					sectionCourseRecord.ContentElement.Focus();
				}
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
		public bool InsertNewRecordAtCurrentPositionByRecordSource(SectionCourseRecordSource recordSource, bool downward)
		{
			int num = 14;
			if (recordSource == null)
			{
				throw new ArgumentNullException("recordSource");
			}
			if (recordSource.Document == null)
			{
				throw new ArgumentNullException("recordSource.Document");
			}
			int num2 = 0;
			XTextDocumentBodyElement body = ViewControl.Document.Body;
			XTextSectionElement xTextSectionElement = (XTextSectionElement)body.CurrentElement.GetOwnerParent(typeof(XTextSectionElement), includeThis: true);
			if (xTextSectionElement != null)
			{
				num2 = body.Sections.IndexOf(xTextSectionElement);
				if (downward)
				{
					num2++;
				}
			}
			SectionCourseRecord sectionCourseRecord = InsertRecordRow(num2, recordSource);
			if (sectionCourseRecord != null)
			{
				if (!ViewControl.IsUpdating)
				{
					ViewControl.RefreshDocument();
					sectionCourseRecord.ContentElement.Focus();
				}
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
		[Obsolete("已过时，请使用 InsertNewRecordAtCurrentPositionByRecordSource()")]
		public bool InsertNewRecordAtCurrentPosition(XTextDocument document, bool downward)
		{
			int num = 10;
			if (document == null)
			{
				throw new ArgumentNullException("templateDocument");
			}
			int num2 = 0;
			XTextDocumentBodyElement body = ViewControl.Document.Body;
			XTextSectionElement xTextSectionElement = (XTextSectionElement)body.CurrentElement.GetOwnerParent(typeof(XTextSectionElement), includeThis: true);
			if (xTextSectionElement != null)
			{
				num2 = body.Sections.IndexOf(xTextSectionElement);
				if (downward)
				{
					num2++;
				}
			}
			SectionCourseRecordSource sectionCourseRecordSource = new SectionCourseRecordSource(document, this);
			sectionCourseRecordSource.Readonly = false;
			sectionCourseRecordSource.Modified = true;
			SectionCourseRecord sectionCourseRecord = InsertRecordRow(num2, new SectionCourseRecordSource(document, this));
			if (sectionCourseRecord != null)
			{
				if (!ViewControl.IsUpdating)
				{
					ViewControl.RefreshDocument();
					sectionCourseRecord.ContentElement.Focus();
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       删除当前光标所在的病程记录对象
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool DeleteCurrentRecord()
		{
			return DeleteRecord(CurrentRecord);
		}

		/// <summary>
		///       删除指定的病程记录对象
		///       </summary>
		/// <param name="record">指定的记录</param>
		/// <returns>操作是否成功</returns>
		internal bool DeleteRecord(SectionCourseRecord record)
		{
			if (record != null)
			{
				XTextContainerElement contentElement = record.ContentElement;
				if (contentElement != null)
				{
					if (this.BeforeRecordDeleted != null)
					{
						WriterCancelEventArgs writerCancelEventArgs = new WriterCancelEventArgs(ViewControl, ViewControl.Document, contentElement);
						this.BeforeRecordDeleted(this, writerCancelEventArgs);
						if (writerCancelEventArgs.Cancel)
						{
							return false;
						}
					}
					XTextSectionElement sectionElement = record.SectionElement;
					ViewControl.Document.Body.Elements.Remove(sectionElement);
					_Records = null;
					if (!ViewControl.IsUpdating)
					{
						ViewControl.RefreshDocumentExt(refreshSize: false, executeLayout: true);
					}
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       开始编辑当前记录
		///       </summary>
		/// <returns>
		/// </returns>
		public bool EditCurrentRecord()
		{
			SectionCourseRecord currentRecord = CurrentRecord;
			if (currentRecord != null)
			{
				return SetReadonly(currentRecord, recordReadonly: false);
			}
			return false;
		}

		/// <summary>
		///       设置记录只读状态
		///       </summary>
		/// <param name="record">记录对象</param>
		/// <param name="recordReadonly">是否为只读状态</param>
		/// <returns>操作是否成功</returns>
		internal bool SetReadonly(SectionCourseRecord record, bool recordReadonly)
		{
			if (record.Locked)
			{
				return false;
			}
			record.SectionElement.ContentReadonly = ((!recordReadonly) ? ContentReadonlyState.False : ContentReadonlyState.True);
			if (record.RecordSource.SpecifyBackgroundCololr.A == 0)
			{
				if (recordReadonly)
				{
					record.SectionElement.Style.BorderColor = ReadonlyBackColor;
					record.SectionElement.Style.BackgroundColor = ReadonlyBackColor;
				}
				else
				{
					record.SectionElement.Style.BorderColor = Color.Transparent;
					record.SectionElement.Style.BackgroundColor = Color.Transparent;
				}
			}
			if (record.RecordSource.RecordBorderColor.A != 0)
			{
				record.SectionElement.Style.BorderColor = record.RecordSource.RecordBorderColor;
			}
			ViewControl.Document.OnSelectionChanged();
			ViewControl.InnerViewControl.Invalidate();
			return true;
		}

		/// <summary>
		///       获得指定元素所对应的病程记录对象
		///       </summary>
		/// <param name="element">
		/// </param>
		/// <returns>
		/// </returns>
		public SectionCourseRecord GetRecordByElement(XTextElement element)
		{
			XTextSectionElement xTextSectionElement = (XTextSectionElement)element.GetOwnerParent(typeof(XTextSectionElement), includeThis: true);
			if (xTextSectionElement != null)
			{
				SectionCourseRecord sectionCourseRecord = xTextSectionElement.TagValue as SectionCourseRecord;
				ViewControl.CollectOuterReference(sectionCourseRecord);
				return sectionCourseRecord;
			}
			return null;
		}

		/// <summary>
		///       获得指定的记录对象
		///       </summary>
		/// <param name="index">从0开始的序号</param>
		/// <returns>获得的记录对象</returns>
		public SectionCourseRecord GetRecord(int index)
		{
			return Records[index];
		}
	}
}
