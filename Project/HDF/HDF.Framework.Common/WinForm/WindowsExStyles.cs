using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.Framework.Common
{
    public enum WindowsExStyles : long
    {
        /// <summary>
        /// 该窗口接受拖放文件。
        /// </summary>
        WS_EX_ACCEPTFILES = 0x00000010L,
        /// <summary>
        /// 可见时将顶级窗口强制到任务栏上。
        /// </summary>
        WS_EX_APPWINDOW = 0x00040000L,
        /// <summary>
        /// 窗口的边框带有凹陷的边缘。
        /// </summary>
        WS_EX_CLIENTEDGE = 0x00000200L,
        /// <summary>
        /// 使用双缓冲以从下到上的绘制顺序绘制窗口的所有后代。从下到上的绘画顺序允许后代窗口具有半透明（alpha）和透明（color-key）效果，但前提是后代窗口还设置了WS_EX_TRANSPARENT位。双缓冲允许绘制窗口及其后代，而不会闪烁。如果窗口有此不能使用类样式之一CS_OWNDC或CS_CLASSDC。
        /// Windows 2000：不支持此样式。
        /// </summary>
        WS_EX_COMPOSITED = 0x02000000L,
        /// <summary>
        /// 窗口的标题栏包含一个问号。当用户单击问号时，光标将变为带有指针的问号。如果用户随后单击子窗口，则该子窗口会收到WM_HELP消息。子窗口应将消息传递给父窗口过程，该过程应使用HELP_WM_HELP命令调用WinHelp函数。帮助应用程序显示一个弹出窗口，通常包含子窗口的帮助。WS_EX_CONTEXTHELP不能与WS_MAXIMIZEBOX或WS_MINIMIZEBOX样式一起使用。
        /// </summary>
        WS_EX_CONTEXTHELP = 0x00000400L,
        /// <summary>
        /// 窗口本身包含应参与对话框导航的子窗口。如果指定了此样式，则在执行导航操作（例如处理TAB键，箭头键或键盘助记符）时，对话框管理器将循环到此窗口的子级中。
        /// </summary>
        WS_EX_CONTROLPARENT = 0x00010000L,
        /// <summary>
        /// 窗口有一个双边框。该窗口可以任选地用一个标题栏，通过指定所创建的WS_CAPTION在样式dwStyle参数。
        /// </summary>
        WS_EX_DLGMODALFRAME = 0x00000001L,
        /// <summary>
        /// 窗户是一个分层的窗户。如果窗口中有一个不能用这种风格类样式之一CS_OWNDC或CS_CLASSDC。
        /// Windows 8的：该WS_EX_LAYERED样式支持顶级窗口和子窗口。以前的Windows版本仅对顶级窗口支持WS_EX_LAYERED。
        /// </summary>
        WS_EX_LAYERED = 0x00080000L,
        /// <summary>
        /// 如果外壳语言是希伯来语，阿拉伯语或其他支持阅读顺序对齐的语言，则窗口的水平原点在右边缘。水平值增加到左侧。
        /// </summary>
        WS_EX_LAYOUTRTL = 0x00400000L,
        /// <summary>
        /// 该窗口具有通用的左对齐属性。这是默认值。
        /// </summary>
        WS_EX_LEFT = 0x00000000L,
        /// <summary>
        /// 如果外壳语言是希伯来语，阿拉伯语或其他支持阅读顺序对齐的语言，则垂直滚动条（如果有）位于客户区域的左侧。对于其他语言，样式将被忽略。
        /// </summary>
        WS_EX_LEFTSCROLLBAR = 0x00004000L,
        /// <summary>
        /// 使用从左到右的阅读顺序属性显示窗口文本。这是默认值。
        /// </summary>
        WS_EX_LTRREADING = 0x00000000L,
        /// <summary>
        /// 该窗口是MDI子窗口。
        /// </summary>
        WS_EX_MDICHILD = 0x00000040L,
        /// <summary>
        /// 当用户单击它时，以这种样式创建的顶级窗口不会成为前台窗口。当用户最小化或关闭前景窗口时，系统不会将此窗口置于前景。
        /// 不应通过程序访问或使用讲述人等可访问技术通过键盘导航来激活该窗口。
        /// 要激活该窗口，请使用SetActiveWindow或SetForegroundWindow函数。
        /// 默认情况下，该窗口不显示在任务栏上。要强制窗口显示在任务栏上，请使用WS_EX_APPWINDOW样式。
        /// </summary>
        WS_EX_NOACTIVATE = 0x08000000L,
        /// <summary>
        /// 该窗口不会将其窗口布局传递给其子窗口。
        /// </summary>
        WS_EX_NOINHERITLAYOUT = 0x00100000L,
        /// <summary>
        /// 使用此样式创建的子窗口在创建或销毁时不会将WM_PARENTNOTIFY消息发送到其父窗口。
        /// </summary>
        WS_EX_NOPARENTNOTIFY = 0x00000004L,
        /// <summary>
        /// 窗口不呈现到重定向表面。这适用于没有可见内容或使用表面以外的机制提供视觉效果的窗口。
        /// </summary>
        WS_EX_NOREDIRECTIONBITMAP = 0x00200000L,
        /// <summary>
        /// 该窗口是一个重叠的窗口。
        /// </summary>
        WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
        /// <summary>
        /// 该窗口是调色板窗口，这是一个无模式对话框，显示了一系列命令。
        /// </summary>
        WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
        /// <summary>
        /// 该窗口具有通用的“右对齐”属性。这取决于窗口类。仅当外壳语言为希伯来语，阿拉伯语或其他支持阅读顺序对齐的语言时，此样式才有效。否则，样式将被忽略。
        /// 将WS_EX_RIGHT样式用于静态或编辑控件分别具有与使用SS_RIGHT或ES_RIGHT样式相同的效果。通过按钮控件使用此样式与使用BS_RIGHT和BS_RIGHTBUTTON样式具有相同的效果。
        /// </summary>
        WS_EX_RIGHT = 0x00001000L,
        /// <summary>
        /// 垂直滚动条（如果有）在客户区域的右侧。这是默认值。
        /// </summary>
        WS_EX_RIGHTSCROLLBAR = 0x00000000L,
        /// <summary>
        /// 如果外壳语言是希伯来语，阿拉伯语或其他支持阅读顺序对齐的语言，则使用从右到左的阅读顺序属性显示窗口文本。对于其他语言，样式将被忽略。
        /// </summary>
        WS_EX_RTLREADING = 0x00002000L,
        /// <summary>
        /// 该窗口具有三维边框样式，旨在用于不接受用户输入的项目。
        /// </summary>
        WS_EX_STATICEDGE = 0x00020000L,
        /// <summary>
        /// 该窗口旨在用作浮动工具栏。工具窗口的标题栏比普通标题栏短，并且窗口标题使用较小的字体绘制。当用户按下ALT + TAB时，工具窗口将不会出现在任务栏或对话框中。如果工具窗口具有系统菜单，则其图标不会显示在标题栏上。但是，您可以通过右键单击或键入ALT + SPACE来显示系统菜单。
        /// </summary>
        WS_EX_TOOLWINDOW = 0x00000080L,
        /// <summary>
        /// 该窗口应放置在所有非最上面的窗口上方，并且即使在停用该窗口的情况下也应保持在它们之上。若要添加或删除此样式，请使用SetWindowPos函数。
        /// </summary>
        WS_EX_TOPMOST = 0x00000008L,
        /// <summary>
        /// 在绘制窗口下方的兄弟姐妹（由同一线程创建）之前，不应绘制窗口。该窗口显示为透明，因为基础同级窗口的位已被绘制。
        /// </summary>
        WS_EX_TRANSPARENT = 0x00000020L,
        /// <summary>
        /// 窗口的边框带有凸起的边缘。
        /// </summary>
        WS_EX_WINDOWEDGE = 0x00000100L,
    }
}
