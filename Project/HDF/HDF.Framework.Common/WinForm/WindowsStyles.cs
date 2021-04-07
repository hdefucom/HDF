using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.Framework.Common
{
    public enum WindowsStyles : long
    {
        /// <summary>
        /// 窗口具有细线边框。
        /// </summary>
        WS_BORDER = 0x00800000L,
        /// <summary>
        /// 该窗口具有标题栏（包括WS_BORDER样式）。
        /// </summary>
        WS_CAPTION = 0x00C00000L,
        /// <summary>
        /// 该窗口是子窗口。具有这种样式的窗口不能具有菜单栏。此样式不能与WS_POPUP样式一起使用。
        /// </summary>
        WS_CHILD = 0x40000000L,
        /// <summary>
        /// 与WS_CHILD样式相同。
        /// </summary>
        WS_CHILDWINDOW = 0x40000000L,
        /// <summary>
        /// 在父窗口内进行绘制时，不包括子窗口所占的区域。创建父窗口时使用此样式。
        /// </summary>
        WS_CLIPCHILDREN = 0x02000000L,
        /// <summary>
        /// 相对于彼此剪辑子窗口；也就是说，当特定的子窗口接收到WM_PAINT消息时，WS_CLIPSIBLINGS样式会将所有其他重叠的子窗口剪切到要更新的子窗口区域之外。如果未指定WS_CLIPSIBLINGS并且子窗口重叠，则在子窗口的客户区域内进行绘制时，可以在相邻子窗口的客户区域内进行绘制。
        /// </summary>
        WS_CLIPSIBLINGS = 0x04000000L,
        /// <summary>
        /// 该窗口最初是禁用的。禁用的窗口无法接收来自用户的输入。要在创建窗口后更改此设置，请使用EnableWindow函数。
        /// </summary>
        WS_DISABLED = 0x08000000L,
        /// <summary>
        /// 窗口的边框通常与对话框一起使用。具有这种样式的窗口不能具有标题栏。
        /// </summary>
        WS_DLGFRAME = 0x00400000L,
        /// <summary>
        /// 该窗口是一组控件中的第一个控件。该组由该第一个控件和在其后定义的所有控件组成，直到下一个具有WS_GROUP样式的下一个控件。每个组中的第一个控件通常具有WS_TABSTOP样式，以便用户可以在组之间移动。用户随后可以使用方向键将键盘焦点从组中的一个控件更改为组中的下一个控件。
        /// 您可以打开和关闭此样式以更改对话框导航。若要在创建窗口后更改此样式，请使用SetWindowLong函数。
        /// </summary>
        WS_GROUP = 0x00020000L,
        /// <summary>
        /// 该窗口具有水平滚动条。
        /// </summary>
        WS_HSCROLL = 0x00100000L,
        /// <summary>
        /// 最初将窗口最小化。与WS_MINIMIZE样式相同。
        /// </summary>
        WS_ICONIC = 0x20000000L,
        /// <summary>
        /// 该窗口最初被最大化。
        /// </summary>
        WS_MAXIMIZE = 0x01000000L,
        /// <summary>
        /// 该窗口有一个最大化按钮。不能与WS_EX_CONTEXTHELP样式结合使用。该WS_SYSMENU风格也必须指定。
        /// </summary>
        WS_MAXIMIZEBOX = 0x00010000L,
        /// <summary>
        /// 最初将窗口最小化。与WS_ICONIC样式相同。
        /// </summary>
        WS_MINIMIZE = 0x20000000L,
        /// <summary>
        /// 该窗口有一个最小化按钮。不能与WS_EX_CONTEXTHELP样式结合使用。该WS_SYSMENU风格也必须指定。
        /// </summary>
        WS_MINIMIZEBOX = 0x00020000L,
        /// <summary>
        /// 该窗口是一个重叠的窗口。重叠的窗口具有标题栏和边框。与WS_TILED样式相同。
        /// </summary>
        WS_OVERLAPPED = 0x00000000L,
        /// <summary>
        /// 该窗口是一个重叠的窗口。与WS_TILEDWINDOW样式相同。
        /// </summary>
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        /// <summary>
        /// 该窗口是一个弹出窗口。此样式不能与WS_CHILD样式一起使用。
        /// </summary>
        WS_POPUP = 0x80000000L,
        /// <summary>
        /// 该窗口是一个弹出窗口。该WS_CAPTION和WS_POPUPWINDOW风格一定要结合使窗口菜单可见。
        /// </summary>
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        /// <summary>
        /// 窗口具有大小调整边框。与WS_THICKFRAME样式相同。
        /// </summary>
        WS_SIZEBOX = 0x00040000L,
        /// <summary>
        /// 该窗口的标题栏上有一个窗口菜单。该WS_CAPTION风格也必须指定。
        /// </summary>
        WS_SYSMENU = 0x00080000L,
        /// <summary>
        /// 该窗口是一个控件，当用户按下TAB键时可以接收键盘焦点。按下TAB键可将键盘焦点更改为WS_TABSTOP样式的下一个控件。
        /// 您可以打开和关闭此样式以更改对话框导航。若要在创建窗口后更改此样式，请使用SetWindowLong函数。为了使用户创建的窗口和无模式对话框能够与制表符一起使用，请更改消息循环以调用IsDialogMessage函数。
        /// </summary>
        WS_TABSTOP = 0x00010000L,
        /// <summary>
        /// 窗口具有大小调整边框。与WS_SIZEBOX样式相同。
        /// </summary>
        WS_THICKFRAME = 0x00040000L,
        /// <summary>
        /// 该窗口是一个重叠的窗口。重叠的窗口具有标题栏和边框。与WS_OVERLAPPED样式相同。
        /// </summary>
        WS_TILED = 0x00000000L,
        /// <summary>
        /// 该窗口是一个重叠的窗口。与WS_OVERLAPPEDWINDOW样式相同。
        /// </summary>
        WS_TILEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        /// <summary>
        /// 该窗口最初是可见的。
        /// 可以使用ShowWindow或SetWindowPos函数打开和关闭此样式。
        /// </summary>
        WS_VISIBLE = 0x10000000L,
        /// <summary>
        /// 该窗口具有垂直滚动条。
        /// </summary>
        WS_VSCROLL = 0x00200000L,
    }
}
