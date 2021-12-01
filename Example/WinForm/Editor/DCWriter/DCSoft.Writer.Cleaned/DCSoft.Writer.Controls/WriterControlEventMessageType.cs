using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器事件类型
	///       </summary>
	[Guid("66DBBBBB-8B44-456B-A263-5223916A0CD9")]
	[ComVisible(true)]
	[DocumentComment]
	public enum WriterControlEventMessageType
	{
		/// <summary>
		///       无事件
		///       </summary>
		None,
		/// <summary>
		///       鼠标按下消息
		///       </summary>
		MouseDown,
		/// <summary>
		///       鼠标移动消息
		///       </summary>
		MouseMove,
		/// <summary>
		///       鼠标按键松开消息
		///       </summary>
		MouseUp,
		/// <summary>
		///       鼠标点击消息
		///       </summary>
		MouseClick,
		/// <summary>
		///       鼠标双击消息
		///       </summary>
		MouseDblClick,
		/// <summary>
		///       按键按下消息
		///       </summary>
		KeyDown,
		/// <summary>
		///       按键字符消息
		///       </summary>
		KeyPress,
		/// <summary>
		///       按键松开消息
		///       </summary>
		KeyUp,
		/// <summary>
		///       元素获得焦点消息
		///       </summary>
		ElementFocus,
		/// <summary>
		///       元素失去焦点消息
		///       </summary>
		ElementLostFocus,
		/// <summary>
		///       文档内容发生改变消息
		///       </summary>
		DocumentContentChanged,
		/// <summary>
		///       文档加载消息
		///       </summary>
		DocumentLoad,
		/// <summary>
		///       文档导航内容发生改变消息
		///       </summary>
		DocumentNavigateContentChanged,
		/// <summary>
		///       文档打印消息
		///       </summary>
		DocumentPrinted,
		/// <summary>
		///       加载文档DOM底层结构消息
		///       </summary>
		AfterLoadRawDOM,
		/// <summary>
		///       播放媒体前消息
		///       </summary>
		BeforePlayMedia,
		/// <summary>
		///       文档元素内容校验消息
		///       </summary>
		ElementValidating,
		/// <summary>
		///       键盘输入字符串消息
		///       </summary>
		BeforeUIKeyboardInputString,
		/// <summary>
		///       导航树改变消息
		///       </summary>
		OutlineTreeChanged,
		/// <summary>
		///       元素勾选改变消息
		///       </summary>
		ElementCheckedChanged,
		/// <summary>
		///       插入辅助输入字符列表消息
		///       </summary>
		QueryAssistInputItems,
		/// <summary>
		///       表格行改变消息
		///       </summary>
		TableRowHeightChanged,
		/// <summary>
		///       状态栏发生改变消息
		///       </summary>
		StatusTextChanged,
		/// <summary>
		///       报错消息
		///       </summary>
		ReportError,
		/// <summary>
		///       按钮元素点击消息
		///       </summary>
		ButtonClick,
		/// <summary>
		///       超链接点击消息
		///       </summary>
		LinkClick,
		/// <summary>
		///       视图缩放消息
		///       </summary>
		ZoomChanged,
		/// <summary>
		///       提示内容包含信息消息
		///       </summary>
		PromptProtectedContent,
		/// <summary>
		///       由于按下Tab键而新增表格行的消息
		///       </summary>
		TableAddNewRowWhenPressTabKey,
		/// <summary>
		///       结束Tab切换焦点消息
		///       </summary>
		EndTabStop,
		/// <summary>
		///       内容修改事件
		///       </summary>
		ContentChanged,
		/// <summary>
		///       自定义命令事件
		///       </summary>
		CustomCommand,
		/// <summary>
		///       加载文档DOM结构后的事件
		///       </summary>
		AfterLoadDocumentDom,
		/// <summary>
		///       刷新页面后事件
		///       </summary>
		AfterRefreshPages,
		/// <summary>
		///       未知命令事件
		///       </summary>
		UnknowCommand,
		/// <summary>
		///       当前鼠标悬停元素改变事件
		///       </summary>
		HoverElementChanged,
		/// <summary>
		///       控件只读状态改变事件
		///       </summary>
		ReadonlyChanged,
		/// <summary>
		///       选择区域发生改变事件
		///       </summary>
		SelectionChanged,
		/// <summary>
		///       用户痕迹列表发生改变事件
		///       </summary>
		UserTrackListChanged,
		/// <summary>
		///       执行命令后事件
		///       </summary>
		AfterExecuteCommand,
		/// <summary>
		///       脚本错误消息
		///       </summary>
		ScriptError,
		/// <summary>
		///       执行命令错误消息
		///       </summary>
		CommandError,
		/// <summary>
		///       文档批注点击事件
		///       </summary>
		DocumentCommentClick,
		/// <summary>
		///       文档批注双击事件
		///       </summary>
		DocumentCommentDblClick,
		/// <summary>
		///       鼠标进入事件
		///       </summary>
		MouseLeave,
		/// <summary>
		///       鼠标离开事件
		///       </summary>
		MouseEnter,
		EventBeforeFieldContentEdit,
		EventAfterFieldContentEdit,
		EventBeforeCollapseSection,
		EventAfterCollapseSection,
		EventBeforeExpandSection,
		EventAfterExpandSection,
		EventBeginPrint,
		EventPrintQueryPageSettings,
		EventPrintPage,
		EventEndPrint,
		EventElementMouseClick,
		EventElementMouseDblClick,
		EventElementMouseDown,
		EventElementMouseMove,
		EventElementMouseUp,
		EventRefreshDomTree,
		EventElementGotFocus,
		EventElementLostFocus,
		EventUpdateToolarState
	}
}
