using DCSoft.Common;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器控件事件模板
	///       </summary>
	[ComVisible(false)]
	
	public class WriterControlEventTemplate
	{
		private bool _Enabled = true;

		private bool _EnabledEventReadSaveFileContent = true;

		/// <summary>
		///       是否启用SelectionChanging事件
		///       </summary>
		private bool _EnableOnSelectionChanging = true;

		/// <summary>
		///       是否启用对象
		///       </summary>
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       触发刷新执行元素事件表达式功能
		///       </summary>
		
		public event WriterAfterExecuteEventExpressionEventHandler EventAfterExecuteEventExpression = null;

		/// <summary>
		///       触发刷新DOM树事件
		///       </summary>
		
		public event WriterEventHandler EventRefreshDomTree = null;

		/// <summary>
		///       展开文档节前触发的事件
		///       </summary>
		
		public event WriterSectionElementCancelEventHandler EventBeforeCollapseSection = null;

		/// <summary>
		///       收缩文档节后触发的事件
		///       </summary>
		
		public event WriterSectionElementEventHandler EventAfterCollapseSection = null;

		/// <summary>
		///       展开文档节前触发的事件
		///       </summary>
		
		public event WriterSectionElementCancelEventHandler EventBeforeExpandSection = null;

		/// <summary>
		///       展开文档节后触发的事件
		///       </summary>
		
		public event WriterSectionElementEventHandler EventAfterExpandSection = null;

		/// <summary>
		///       开始打印事件
		///       </summary>
		
		[field: NonSerialized]
		public event WriterPrintEventHandler EventBeginPrint = null;

		/// <summary>
		///       打印时查询页面设置事件
		///       </summary>
		
		[field: NonSerialized]
		public event WriterPrintQueryPageSettingsEventHandler EventPrintQueryPageSettings = null;

		/// <summary>
		///       打印页面事件
		///       </summary>
		
		[field: NonSerialized]
		public event WriterPrintPageEventHandler EventPrintPage = null;

		/// <summary>
		///       结束打印事件
		///       </summary>
		
		[field: NonSerialized]
		public event WriterPrintEventHandler EventEndPrint = null;

		/// <summary>
		///       通过数值编辑器修改输入域内容前触发的事件
		///       </summary>
		
		public event WriterBeforeFieldContentEditEventHandler EventBeforeFieldContentEdit = null;

		/// <summary>
		///       通过数值编辑器修改输入域内容前触发的事件
		///       </summary>
		
		public event WriterAfterFieldContentEditEventHandler EventAfterFieldContentEdit = null;

		/// <summary>
		///       文档元素内容校验事件
		///       </summary>
		
		public event ElementValidatingEventHandler EventElementValidating = null;

		/// <summary>
		///       准备播放媒体事件
		///       </summary>
		
		public event WriterBeforePlayMediaEventHandler EventBeforePlayMedia = null;

		/// <summary>
		///       文档大纲树状结构发生改变事件
		///       </summary>
		
		public event WriterEventHandler EventOutlineTreeChanged = null;

		/// <summary>
		///       元素勾选状态发生改变事件
		///       </summary>
		
		public event WriterElementCheckedChangedEventHandler EventElementCheckedChanged = null;

		/// <summary>
		///       查询辅助录入使用的字符串列表事件,注意：这个事件不是在UI线程中触发。不能在本事件处理中直接操作用UI控件。
		///       </summary>
		
		public event WriterQueryAssistInputItemsEventHandler EventQueryAssistInputItems = null;

		/// <summary>
		///       键盘输入字符串事件
		///       </summary>
		
		public event WriterBeforeUIKeyboardInputStringEventHandler EventBeforeUIKeyboardInputString = null;

		/// <summary>
		///       表格行高度发生改变事件
		///       </summary>
		
		public event WriterTableRowHeightChangedEventHandler EventTableRowHeightChanged = null;

		/// <summary>
		///       表格行高度正在发生改变事件，在这个事件中可以取消表格行高度修改操作
		///       </summary>
		
		public event WriterTableRowHeightChangingEventHandler EventTableRowHeightChanging = null;

		/// <summary>
		///       文档内容的导航数据发生改变事件
		///       </summary>
		
		[Description("文档内容的导航数据发生改变事件")]
		public event WriterEventHandler DocumentNavigateContentChanged = null;

		/// <summary>
		///       状态栏文本发生改变事件
		///       </summary>
		
		[Description("状态栏文本发生改变事件")]
		public event StatusTextChangedEventHandler StatusTextChanged = null;

		/// <summary>
		///       自定义绘制图形内容事件
		///       </summary>
		
		public event WriterDrawShapeContentEventHandler EventDrawShapeContent = null;

		/// <summary>
		///       报告错误内容的事件
		///       </summary>
		
		public event WriterReportErrorEventHandler EventReportError = null;

		/// <summary>
		///       加载文档DOM结构后的事件
		///       </summary>
		
		public event WriterEventHandler EventAfterLoadRawDOM = null;

		/// <summary>
		///       执行表达式函数功能事件
		///       </summary>
		
		public event WriterExpressionFunctionEventHandler EventExpressionFunction = null;

		/// <summary>
		///       获得文档元素的扩展文本内容事件
		///       </summary>
		
		public event WriterGetAdornTextEventHandler EventGetAdornText = null;

		/// <summary>
		///       编辑文档元素数值事件
		///       </summary>
		
		public event WriterEditElementValueEventHandler EventEditElementValue = null;

		/// <summary>
		///       为自动保存功能而设置的保存文件内容事件
		///       </summary>
		
		public event WriterSaveFileContentEventHandler EventSaveFileContentForAutoSave = null;

		/// <summary>
		///       保存文件内容事件
		///       </summary>
		
		public event WriterSaveFileContentEventHandler EventSaveFileContent = null;

		/// <summary>
		///       读取文件内容事件
		///       </summary>
		
		public event WriterReadFileContentEventHandler EventReadFileContent = null;

		/// <summary>
		///       文档元素鼠标点击事件
		///       </summary>
		
		public event ElementMouseEventHandler EventElementMouseClick = null;

		/// <summary>
		///       文档元素获取焦点事件
		///       </summary>
		
		public event ElementEventHandler EventElementGotFocus = null;

		/// <summary>
		///       文档元素获取焦点事件
		///       </summary>
		
		public event ElementEventHandler EventElementLostFocus = null;

		/// <summary>
		///       文档元素鼠标双击事件
		///       </summary>
		
		public event ElementMouseEventHandler EventElementMouseDblClick = null;

		/// <summary>
		///       文档元素鼠标双击事件
		///       </summary>
		
		public event ElementMouseEventHandler EventElementMouseDown = null;

		/// <summary>
		///       文档元素鼠标移动事件
		///       </summary>
		
		public event ElementMouseEventHandler EventElementMouseMove = null;

		/// <summary>
		///       文档元素鼠标按键松开事件
		///       </summary>
		
		public event ElementMouseEventHandler EventElementMouseUp = null;

		/// <summary>
		///       按钮点击事件
		///       </summary>
		
		public event WriterButtonClickEventHandler EventButtonClick = null;

		/// <summary>
		///       超链接点击事件
		///       </summary>
		
		public event WriterLinkEventHandler EventLinkClick = null;

		/// <summary>
		///       获得联动下拉列表事件
		///       </summary>
		
		public event GetLinkListItemsEventHandler EventGetLinkListItems = null;

		/// <summary>
		///       收集内容保护信息事件
		///       </summary>
		
		public event CollectProtectedElementsEventHandler EventCollectProtectedElements = null;

		/// <summary>
		///       控件缩放事件
		///       </summary>
		
		public event WriterEventHandler EventZoomChanged = null;

		/// <summary>
		///       提示内容受保护的事件
		///       </summary>
		
		public event PromptProtectedContentEventHandler EventPromptProtectedContent = null;

		/// <summary>
		///       使用TAB键新增表格行触发的事件
		///       </summary>
		
		public event WriterEventHandler EventTableAddNewRowWhenPressTabKey = null;

		/// <summary>
		///       结束切换输入焦点事件
		///       </summary>
		
		public event WriterEventHandler EventEndTabStop = null;

		/// <summary>
		///       内容正在改变事件
		///       </summary>
		
		public event ContentChangingEventHandler EventContentChanging = null;

		/// <summary>
		///       内容已经改变事件
		///       </summary>
		
		public event ContentChangedEventHandler EventContentChanged = null;

		/// <summary>
		///       在显示对话框之前触发的事件
		///       </summary>
		[Description("在显示对话框之前触发的事件")]
		
		public event WriterShowDialogEventHandler EventBeforeShowDialog = null;

		/// <summary>
		///       自定义命令事件
		///       </summary>
		
		[Description("自定义功能命令事件")]
		public event CustomCommandEventHandler ComCustomCommand = null;

		/// <summary>
		///       用户界面层的开始编辑文档内容事件
		///       </summary>
		
		[Description("开始编辑文档内容事件")]
		public event WriterStartEditEventHandler EventUIStartEditContent = null;

		/// <summary>
		///       成功加载文档DOM结构触发的事件，此时文档虽然加载了DOM结构，但没有排版和显示。
		///       </summary>
		
		[Description("成功加载文档DOM结构触发的事件")]
		public event WriterEventHandler AfterLoadDocumentDom = null;

		/// <summary>
		///       创建对象实例事件
		///       </summary>
		[Description("创建对象实例事件")]
		
		public event CreateInstanceEventHandler EventCreateInstance = null;

		/// <summary>
		///       刷新分页后事件
		///       </summary>
		
		[Description("刷新分页后事件")]
		public event WriterEventHandler AfterRefreshPages = null;

		/// <summary>
		///       查询用户历史记录显示文本事件
		///       </summary>
		[Description("查询用户历史记录显示文本事件")]
		
		public event QueryUserHistoryDisplayTextEventHandler QueryUserHistoryDisplayText = null;

		/// <summary>
		///       解释列表项目的事件
		///       </summary>
		
		[Description("解释列表项目的事件")]
		public event ParseSelectedItemsEventHandler EventParseSelectedItems = null;

		/// <summary>
		///       获得列表显示文本事件
		///       </summary>
		
		[Description("格式化输出列表显示文本事件")]
		public event FormatListItemsEventHandler EventFormatListItems = null;

		/// <summary>
		///       未知编辑器命令事件
		///       </summary>
		
		[Description("未知编辑器命令事件")]
		public event WriterCommandEventHandler EventUnknowCommand = null;

		/// <summary>
		///       查询知识库节点列表事件
		///       </summary>
		
		[Description("查询知识库节点列表事件")]
		public event QueryKBEntriesEventHandler QueryKBEntries = null;

		/// <summary>
		///       增强型鼠标按下事件
		///       </summary>
		
		[Description("增强型鼠标按下事件")]
		public event WriterMouseEventHandler EventMouseDownExt = null;

		/// <summary>
		///       增强型鼠标移动事件
		///       </summary>
		
		[Description("增强型鼠标移动事件")]
		public event WriterMouseEventHandler EventMouseMoveExt = null;

		/// <summary>
		///       增强型鼠标按键松开事件
		///       </summary>
		[Description("增强型鼠标按键松开事件")]
		
		public event WriterMouseEventHandler EventMouseUpExt = null;

		/// <summary>
		///       扩展的键盘按键按下事件
		///       </summary>
		
		public event WriterControl.WriterKeyEventExtHandler EventKeyDownExt = null;

		/// <summary>
		///       扩展的键盘按键松开事件
		///       </summary>
		
		public event WriterControl.WriterKeyEventExtHandler EventKeyUpExt = null;

		/// <summary>
		///       扩展的键盘按键按下事件
		///       </summary>
		
		public event WriterControl.WriterKeyPressEventExtHandler EventKeyPressExt = null;

		/// <summary>
		///       增强型鼠标按键单击事件
		///       </summary>
		
		[Description("增强型鼠标按键单击事件")]
		public event WriterMouseEventHandler EventMouseClickExt = null;

		/// <summary>
		///       增强型鼠标按键双击事件
		///       </summary>
		[Description("增强型鼠标按键双击事件")]
		
		public event WriterMouseEventHandler EventMouseDblClickExt = null;

		/// <summary>
		///       数据过滤事件
		///       </summary>
		
		[Description("数据过滤事件")]
		public event FilterValueEventHandler FilterValue = null;

		/// <summary>
		///       根据知识库节点创建文档元素对象的事件
		///       </summary>
		[Description("根据知识库节点创建文档元素对象的事件")]
		
		public event CreateElementsByKBEntryEventHandler EventCreateElementsByKBEntry = null;

		/// <summary>
		///       当前鼠标悬浮的元素改变事件
		///       </summary>
		
		[Description("当前鼠标悬浮的元素改变事件")]
		public event WriterEventHandler HoverElementChanged = null;

		/// <summary>
		///       控件Readonly属性值发生改变事件
		///       </summary>
		
		public event WriterEventHandler EventReadonlyChanged = null;

		/// <summary>
		///       仅供COM调用的事件，一般不要使用
		///       </summary>
		public event ComVoidHandler VOIDCOMDocumentLoad = null;

		/// <summary>
		///       文档加载事件
		///       </summary>
		
		[Description("文档加载事件")]
		public event WriterEventHandler DocumentLoad = null;

		/// <summary>
		///       向文档插入对象事件
		///       </summary>
		[Description("向文档插入对象事件")]
		
		public event InsertObjectEventHandler EventInsertObject = null;

		/// <summary>
		///       判断能否插入对象事件
		///       </summary>
		
		[Description("判断能否插入对象事件")]
		public event CanInsertObjectEventHandler EventCanInsertObject = null;

		/// <summary>
		///       文档选择状态正在发生改变事件
		///       </summary>
		[Description("文档选择状态正在发生改变事件")]
		
		public event SelectionChangingEventHandler SelectionChanging = null;

		/// <summary>
		///       文档选择状态发生改变后的事件
		///       </summary>
		
		[Description("文档选择状态发生改变后的事件")]
		public event WriterEventHandler SelectionChanged = null;

		/// <summary>
		///       文档内容发生改变事件
		///       </summary>
		[Description("文档内容发生改变事件")]
		
		public event WriterEventHandler DocumentContentChanged = null;

		/// <summary>
		///       仅供COM调用的事件，一般不要使用
		///       </summary>
		public event ComVoidHandler VOIDCOMDocumentContentChanged = null;

		/// <summary>
		///       查询下拉列表项目事件
		///       </summary>
		
		[Description("查询下拉列表项目事件")]
		public event QueryListItemsEventHandler QueryListItems = null;

		/// <summary>
		///       文档内容中的用户修改痕迹列表信息发生改变事件
		///       </summary>
		
		[Description("文档内容中的用户修改痕迹列表信息发生改变事件")]
		public event WriterEventHandler UserTrackListChanged = null;

		/// <summary>
		///       结束执行编辑器命令事件
		///       </summary>
		
		[Description("结束执行编辑器命令事件")]
		public event WriterCommandEventHandler AfterExecuteCommand = null;

		/// <summary>
		///       开始执行编辑器命令事件
		///       </summary>
		[Description("开始执行编辑器命令事件")]
		
		public event WriterCommandEventHandler BeforeExecuteCommand = null;

		/// <summary>
		///       脚本发生错误事件
		///       </summary>
		[Description("脚本发生错误事件")]
		
		public event WriterEventHandler ScriptError = null;

		/// <summary>
		///       自定义处理命令错误的事件
		///       </summary>
		
		[Description("自定义处理命令错误的事件")]
		public event CommandErrorEventHandler CommandError = null;

		/// <summary>
		///       文档打印事件
		///       </summary>
		[Description("文档打印事件")]
		
		public event WriterDocumentPrintedEventHandler DocumentPrinted = null;

		public virtual void vmethod_0(object sender, WriterAfterExecuteEventExpressionEventArgs e)
		{
			if (Enabled && Enabled && this.EventAfterExecuteEventExpression != null)
			{
				this.EventAfterExecuteEventExpression(sender, e);
			}
		}

		public virtual void vmethod_1(object sender, WriterEventArgs e)
		{
			if (Enabled && this.EventRefreshDomTree != null)
			{
				this.EventRefreshDomTree(sender, e);
			}
		}

		public virtual void vmethod_2(object sender, WriterSectionElementCancelEventArgs e)
		{
			if (Enabled && this.EventBeforeCollapseSection != null)
			{
				this.EventBeforeCollapseSection(sender, e);
			}
		}

		public virtual void vmethod_3(object sender, WriterSectionElementEventArgs e)
		{
			if (Enabled && this.EventAfterCollapseSection != null)
			{
				this.EventAfterCollapseSection(sender, e);
			}
		}

		public virtual void vmethod_4(object sender, WriterSectionElementCancelEventArgs e)
		{
			if (Enabled && this.EventBeforeExpandSection != null)
			{
				this.EventBeforeExpandSection(sender, e);
			}
		}

		public virtual void vmethod_5(object sender, WriterSectionElementEventArgs e)
		{
			if (Enabled && this.EventAfterExpandSection != null)
			{
				this.EventAfterExpandSection(sender, e);
			}
		}

		/// <summary>
		///       触发开始打印事件
		///       </summary>
		public void OnEventBeginPrint(object sender, WriterPrintEventEventArgs e)
		{
			if (Enabled && this.EventBeginPrint != null)
			{
				this.EventBeginPrint(sender, e);
			}
		}

		/// <summary>
		///       触发打印时查询页面设置事件
		///       </summary>
		public void OnEventPrintQueryPageSettings(object sender, WriterPrintQueryPageSettingsEventArgs e)
		{
			if (Enabled && this.EventPrintQueryPageSettings != null)
			{
				this.EventPrintQueryPageSettings(sender, e);
			}
		}

		/// <summary>
		///       触发打印页面事件
		///       </summary>
		public void OnEventPrintPage(object sender, WriterPrintPageEventEventArgs e)
		{
			if (Enabled && this.EventPrintPage != null)
			{
				this.EventPrintPage(sender, e);
			}
		}

		/// <summary>
		///       触发结束打印事件
		///       </summary>
		public void OnEventEndPrint(object sender, WriterPrintEventEventArgs e)
		{
			if (Enabled && this.EventEndPrint != null)
			{
				this.EventEndPrint(sender, e);
			}
		}

		
		public void method_0(object sender, WriterBeforeFieldContentEditEventArgs e)
		{
			if (Enabled && this.EventBeforeFieldContentEdit != null)
			{
				this.EventBeforeFieldContentEdit(sender, e);
			}
		}

		
		public void method_1(object sender, WriterAfterFieldContentEditEventArgs e)
		{
			if (Enabled && this.EventAfterFieldContentEdit != null)
			{
				this.EventAfterFieldContentEdit(sender, e);
			}
		}

		public virtual void vmethod_6(object sender, ElementValidatingEventArgs e)
		{
			if (Enabled && this.EventElementValidating != null)
			{
				this.EventElementValidating(sender, e);
			}
		}

		
		public virtual void vmethod_7(object sender, WriterBeforePlayMediaEventArgs e)
		{
			if (Enabled && this.EventBeforePlayMedia != null)
			{
				this.EventBeforePlayMedia(sender, e);
			}
		}

		
		public virtual void vmethod_8(object sender, WriterEventArgs e)
		{
			if (Enabled && this.EventOutlineTreeChanged != null)
			{
				this.EventOutlineTreeChanged(sender, e);
			}
		}

		public virtual void vmethod_9(string string_0, string string_1, string string_2, XTextElement xtextElement_0)
		{
			if (Enabled && this.EventElementCheckedChanged != null)
			{
				this.EventElementCheckedChanged(string_0, string_1, string_2, xtextElement_0);
			}
		}

		
		public void method_2(object sender, WriterQueryAssistInputItemsEventArgs e)
		{
			if (Enabled && this.EventQueryAssistInputItems != null)
			{
				this.EventQueryAssistInputItems(sender, e);
			}
		}

		public virtual void vmethod_10(object sender, WriterBeforeUIKeyboardInputStringEventArgs e)
		{
			if (Enabled && this.EventBeforeUIKeyboardInputString != null)
			{
				this.EventBeforeUIKeyboardInputString(sender, e);
			}
		}

		public virtual void vmethod_11(object sender, WriterTableRowHeightChangedEventArgs e)
		{
			if (Enabled && this.EventTableRowHeightChanged != null)
			{
				this.EventTableRowHeightChanged(sender, e);
			}
		}

		public virtual void vmethod_12(object sender, WriterTableRowHeightChangingEventArgs e)
		{
			if (Enabled && this.EventTableRowHeightChanging != null)
			{
				this.EventTableRowHeightChanging(sender, e);
			}
		}

		/// <summary>
		///       DCWriter内部使用。触发文档导航数据发生改变事件
		///       </summary>
		/// <param name="args">参数</param>
		
		public virtual void OnDocumentNavigateContentChanged(object sender, WriterEventArgs e)
		{
			if (Enabled && this.DocumentNavigateContentChanged != null)
			{
				this.DocumentNavigateContentChanged(sender, e);
			}
		}

		public virtual void vmethod_13(object sender, StatusTextChangedEventArgs e)
		{
			if (Enabled && this.StatusTextChanged != null)
			{
				this.StatusTextChanged(sender, e);
			}
		}

		public virtual void vmethod_14(object sender, WriterDrawShapeContentEventArgs e)
		{
			if (Enabled && this.EventDrawShapeContent != null)
			{
				this.EventDrawShapeContent(sender, e);
			}
		}

		public virtual void vmethod_15(object sender, WriterReportErrorEventArgs e)
		{
			if (Enabled && this.EventReportError != null)
			{
				this.EventReportError(sender, e);
			}
		}

		
		public virtual void vmethod_16(object sender, WriterEventArgs e)
		{
			if (Enabled && this.EventAfterLoadRawDOM != null)
			{
				this.EventAfterLoadRawDOM(sender, e);
			}
		}

		
		public void method_3(object sender, WriterExpressionFunctionEventArgs e)
		{
			if (Enabled && this.EventExpressionFunction != null)
			{
				this.EventExpressionFunction(sender, e);
			}
		}

		public virtual void vmethod_17(object sender, WriterGetAdornTextEventArgs e)
		{
			if (Enabled && this.EventGetAdornText != null)
			{
				this.EventGetAdornText(sender, e);
			}
		}

		public virtual void vmethod_18(object sender, WriterEditElementValueEventArgs e)
		{
			if (Enabled && this.EventEditElementValue != null)
			{
				this.EventEditElementValue(sender, e);
			}
		}

		/// <summary>
		///       触发EventSaveFileContentForAutoSave事件
		///       </summary>
		/// <param name="args">事件参数</param>
		public virtual void OnEventSaveFileContentForAutoSave(object sender, WriterSaveFileContentEventArgs e)
		{
			if (Enabled && this.EventSaveFileContentForAutoSave != null)
			{
				this.EventSaveFileContentForAutoSave(sender, e);
			}
		}

		public virtual void vmethod_19(object sender, WriterSaveFileContentEventArgs e)
		{
			if (Enabled && this.EventSaveFileContent != null)
			{
				this.EventSaveFileContent(sender, e);
			}
		}

		public virtual void vmethod_20(object sender, WriterReadFileContentEventArgs e)
		{
			if (Enabled && this.EventReadFileContent != null)
			{
				this.EventReadFileContent(sender, e);
			}
		}

		public virtual void vmethod_21(object sender, ElementMouseEventArgs e)
		{
			if (Enabled && this.EventElementMouseClick != null)
			{
				this.EventElementMouseClick(sender, e);
			}
		}

		public virtual void vmethod_22(object sender, ElementEventArgs e)
		{
			if (Enabled && this.EventElementGotFocus != null)
			{
				this.EventElementGotFocus(sender, e);
			}
		}

		public virtual void vmethod_23(object sender, ElementEventArgs e)
		{
			if (Enabled && this.EventElementLostFocus != null)
			{
				this.EventElementLostFocus(sender, e);
			}
		}

		public virtual void vmethod_24(object sender, ElementMouseEventArgs e)
		{
			if (Enabled && this.EventElementMouseDblClick != null)
			{
				this.EventElementMouseDblClick(sender, e);
			}
		}

		public virtual void vmethod_25(object sender, ElementMouseEventArgs e)
		{
			if (Enabled && this.EventElementMouseDown != null)
			{
				this.EventElementMouseDown(sender, e);
			}
		}

		public virtual void vmethod_26(object sender, ElementMouseEventArgs e)
		{
			if (Enabled && this.EventElementMouseMove != null)
			{
				this.EventElementMouseMove(sender, e);
			}
		}

		public virtual void vmethod_27(object sender, ElementMouseEventArgs e)
		{
			if (Enabled && this.EventElementMouseUp != null)
			{
				this.EventElementMouseUp(sender, e);
			}
		}

		public virtual void vmethod_28(object sender, WriterButtonClickEventArgs e)
		{
			if (Enabled && this.EventButtonClick != null)
			{
				this.EventButtonClick(sender, e);
			}
		}

		public virtual void vmethod_29(object sender, WriterLinkEventArgs e)
		{
			if (Enabled && this.EventLinkClick != null)
			{
				this.EventLinkClick(sender, e);
			}
		}

		public virtual void vmethod_30(object sender, GetLinkListItemsEventArgs e)
		{
			if (Enabled && this.EventGetLinkListItems != null)
			{
				this.EventGetLinkListItems(sender, e);
			}
		}

		
		public virtual void vmethod_31(object sender, CollectProtectedElementsEventArgs e)
		{
			if (Enabled && this.EventCollectProtectedElements != null)
			{
				this.EventCollectProtectedElements(sender, e);
			}
		}

		
		public virtual void vmethod_32(object sender, WriterEventArgs e)
		{
			if (Enabled && this.EventZoomChanged != null)
			{
				this.EventZoomChanged(sender, e);
			}
		}

		public virtual void vmethod_33(object sender, PromptProtectedContentEventArgs e)
		{
			if (Enabled && this.EventPromptProtectedContent != null)
			{
				this.EventPromptProtectedContent(sender, e);
			}
		}

		
		public void method_4(object sender, WriterEventArgs e)
		{
			if (Enabled && this.EventTableAddNewRowWhenPressTabKey != null)
			{
				this.EventTableAddNewRowWhenPressTabKey(sender, e);
			}
		}

		public virtual void vmethod_34(object sender, ContentChangingEventArgs e)
		{
			if (Enabled && this.EventContentChanging != null)
			{
				this.EventContentChanging(sender, e);
			}
		}

		public virtual void vmethod_35(object sender, WriterEventArgs e)
		{
			if (Enabled && this.EventEndTabStop != null)
			{
				this.EventEndTabStop(sender, e);
			}
		}

		public virtual void vmethod_36(object sender, ContentChangedEventArgs e)
		{
			if (Enabled && this.EventContentChanged != null)
			{
				this.EventContentChanged(sender, e);
			}
		}

		public virtual void vmethod_37(object sender, CustomCommandEventArgs e)
		{
			if (this.ComCustomCommand != null)
			{
				this.ComCustomCommand(sender, e);
			}
		}

		/// <summary>
		///       触发EventUIStartEditContent事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public virtual void OnEventUIStartEditContent(object sender, WriterStartEditEventArgs e)
		{
			if (Enabled && this.EventUIStartEditContent != null)
			{
				this.EventUIStartEditContent(sender, e);
			}
		}

		public virtual void vmethod_38(object sender, WriterEventArgs e)
		{
			if (Enabled && this.AfterLoadDocumentDom != null)
			{
				this.AfterLoadDocumentDom(sender, e);
			}
		}

		
		public virtual void vmethod_39(object sender, CreateInstanceEventArgs e)
		{
			if (Enabled && this.EventCreateInstance != null)
			{
				this.EventCreateInstance(sender, e);
			}
		}

		public virtual void vmethod_40(object sender, WriterEventArgs e)
		{
			if (Enabled && this.AfterRefreshPages != null)
			{
				this.AfterRefreshPages(sender, e);
			}
		}

		public virtual void vmethod_41(object sender, QueryUserHistoryDisplayTextEventArgs e)
		{
			if (Enabled && this.QueryUserHistoryDisplayText != null)
			{
				this.QueryUserHistoryDisplayText(sender, e);
			}
		}

		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void method_5(object sender, ParseSelectedItemsEventArgs e)
		{
			if (Enabled && this.EventParseSelectedItems != null)
			{
				this.EventParseSelectedItems(sender, e);
			}
		}

		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void method_6(object sender, FormatListItemsEventArgs e)
		{
			if (Enabled && this.EventFormatListItems != null)
			{
				this.EventFormatListItems(sender, e);
			}
		}

		public virtual void vmethod_42(object sender, WriterCommandEventArgs e)
		{
			if (Enabled && this.EventUnknowCommand != null)
			{
				this.EventUnknowCommand(sender, e);
			}
		}

		
		public void method_7(object sender, QueryKBEntriesEventArgs e)
		{
			if (Enabled && this.QueryKBEntries != null)
			{
				this.QueryKBEntries(sender, e);
			}
		}

		public void method_8(object sender, WriterMouseEventArgs e)
		{
			if (Enabled && this.EventMouseDownExt != null)
			{
				this.EventMouseDownExt(sender, e);
			}
		}

		public void method_9(object sender, WriterMouseEventArgs e)
		{
			if (Enabled && this.EventMouseMoveExt != null)
			{
				this.EventMouseMoveExt(sender, e);
			}
		}

		public void method_10(object sender, WriterMouseEventArgs e)
		{
			if (Enabled && this.EventMouseUpExt != null)
			{
				this.EventMouseUpExt(sender, e);
			}
		}

		/// <summary>
		///       触发EventKeyDownExt事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public void OnEventKeyDownExt(object eventSender, int keyCode, int keyModifiers)
		{
			if (Enabled && this.EventKeyDownExt != null)
			{
				this.EventKeyDownExt(eventSender, keyCode, keyModifiers);
			}
		}

		/// <summary>
		///       触发EventKeyUpExt事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public void OnEventKeyUpExt(object eventSender, int keyCode, int keyModifiers)
		{
			if (Enabled && this.EventKeyUpExt != null)
			{
				this.EventKeyUpExt(eventSender, keyCode, keyModifiers);
			}
		}

		/// <summary>
		///       触发EventKeyPressExt事件
		///       </summary>
		/// <param name="args">
		/// </param>
		public void OnEventKeyPressExt(object eventSender, int keyChar)
		{
			if (Enabled && this.EventKeyPressExt != null)
			{
				this.EventKeyPressExt(eventSender, keyChar);
			}
		}

		public void method_11(object sender, WriterMouseEventArgs e)
		{
			if (Enabled && this.EventMouseClickExt != null)
			{
				this.EventMouseClickExt(sender, e);
			}
		}

		public void method_12(object sender, WriterMouseEventArgs e)
		{
			if (Enabled && this.EventMouseClickExt != null)
			{
				this.EventMouseDblClickExt(sender, e);
			}
		}

		public virtual void vmethod_43(object sender, FilterValueEventArgs e)
		{
			if (Enabled && this.FilterValue != null)
			{
				this.FilterValue(sender, e);
			}
		}

		
		public virtual void vmethod_44(object sender, CreateElementsByKBEntryEventArgs e)
		{
			if (Enabled && this.EventCreateElementsByKBEntry != null)
			{
				this.EventCreateElementsByKBEntry(sender, e);
			}
		}

		public void method_13(object sender, WriterEventArgs e)
		{
			if (Enabled && this.HoverElementChanged != null)
			{
				this.HoverElementChanged(sender, e);
			}
		}

		public virtual void vmethod_45(object sender, WriterEventArgs e)
		{
			if (Enabled && this.EventReadonlyChanged != null)
			{
				this.EventReadonlyChanged(sender, e);
			}
		}

		/// <summary>
		///       DCWriter内部使用。触发文档加载事件，触发此事件时，文档已经加载成功，但尚未显示出来。
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public virtual void OnDocumentLoad(object sender, WriterEventArgs e)
		{
			if (Enabled && this.DocumentLoad != null)
			{
				this.DocumentLoad(sender, e);
			}
		}

		/// <summary>
		///       DCWriter内部使用。向文档插入对象数据
		///       </summary>
		/// <param name="args">参数</param>
		
		public virtual void OnEventInsertObject(object sender, InsertObjectEventArgs e)
		{
			if (Enabled && this.EventInsertObject != null)
			{
				this.EventInsertObject(sender, e);
			}
		}

		/// <summary>
		///       DCWriter内部使用。判断能否插入对象
		///       </summary>
		/// <param name="args">参数</param>
		
		public virtual void OnEventCanInsertObject(object sender, CanInsertObjectEventArgs e)
		{
			if (Enabled && this.EventCanInsertObject != null)
			{
				this.EventCanInsertObject(sender, e);
			}
		}

		public virtual void vmethod_46(object sender, SelectionChangingEventArgs e)
		{
			if (Enabled && this.SelectionChanging != null)
			{
				this.SelectionChanging(sender, e);
			}
		}

		/// <summary>
		///       DCWriter内部使用。触发文档选择状态发生改变后的事件
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public virtual void OnSelectionChanged(object sender, WriterEventArgs e)
		{
			if (Enabled && this.SelectionChanged != null)
			{
				this.SelectionChanged(sender, e);
			}
		}

		/// <summary>
		///       触发文档内容发生改变事件
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public virtual void OnDocumentContentChanged(object sender, WriterEventArgs e)
		{
			if (Enabled && this.DocumentContentChanged != null)
			{
				this.DocumentContentChanged(sender, e);
			}
		}

		/// <summary>
		///       查询下拉列表项目
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>查询的内容</returns>
		
		public virtual void OnQueryListItems(object sender, QueryListItemsEventArgs e)
		{
			if (Enabled && this.QueryListItems != null)
			{
				this.QueryListItems(sender, e);
			}
		}

		public virtual void vmethod_47(object sender, WriterEventArgs e)
		{
			if (Enabled && this.UserTrackListChanged != null)
			{
				this.UserTrackListChanged(sender, e);
			}
		}

		/// <summary>
		///       DCWriter内部使用。执行编辑器命令后的事件
		///       </summary>
		/// <param name="args">事件参数</param>
		
		public virtual void OnAfterExecuteCommand(object sender, WriterCommandEventArgs e)
		{
			if (Enabled && this.AfterExecuteCommand != null)
			{
				this.AfterExecuteCommand(sender, e);
			}
		}

		
		public virtual void vmethod_48(object sender, WriterCommandEventArgs e)
		{
			if (Enabled && this.BeforeExecuteCommand != null)
			{
				this.BeforeExecuteCommand(sender, e);
			}
		}

		
		public void method_14(object sender, WriterEventArgs e)
		{
			if (Enabled && this.ScriptError != null)
			{
				this.ScriptError(sender, e);
			}
		}

		
		public virtual void vmethod_49(object sender, CommandErrorEventArgs e)
		{
			if (Enabled && this.CommandError != null)
			{
				this.CommandError(sender, e);
			}
		}

		public virtual void vmethod_50(object sender, WriterDocumentPrintedEventArgs e)
		{
			if (Enabled && this.DocumentPrinted != null)
			{
				this.DocumentPrinted(sender, e);
			}
		}
	}
}
