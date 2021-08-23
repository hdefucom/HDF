/******************************************************************************
 
		C# 编制的调用微软Windows32操作系统的底层API相关的常量,结构体和函数的声明
		
		本源代码部分来自 crownwood 公司提供的 DotNet Magic Library 
		
		并经过一些处理并添加了自己的一些函数
		
        关于 crownwood 公司,可查看网站 http://www.dotnetmagic.com/
		
			
******************************************************************************/
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Windows32
{
	 
	/// <summary>
	/// 调用Win32API函数时发生错误抛出的异常对象
	/// </summary>
	public class Win32APIException : System.Exception 
	{
		private int intLastDllError	= 0 ;
		private int intReturnValue  = 0 ;
		private string strAPIName	= "";
		private string strErrorMsg	= "";

		/// <summary>
		/// 错误信息
		/// </summary>
		public string ErrorMsg 
		{
			get{ return strErrorMsg ;}
			set{ strErrorMsg = value;}
		}

		/// <summary>
		/// API函数返回值
		/// </summary>
		public int ReturnValue 
		{
			get{ return intReturnValue ;}
		}
		/// <summary>
		/// 发送错误时的操作系统错误代码
		/// </summary>
		public int LastDllError
		{
			get{ return intLastDllError ;}
		}
		/// <summary>
		/// 发送错误时调用的API函数名称
		/// </summary>
		public string APIName
		{
			get{ return strAPIName ;}
		}
		public override string ToString()
		{
			return "Win32APIException:调用Win32API函数"	+ strAPIName 
				+ " 错误，返回:"		+ intReturnValue 
				+ " 系统错误号"			+ intLastDllError + Kernel32.FormatErrorMessage( intLastDllError )
				+ " 错误信息: " + this.strErrorMsg 
				+ "\r\n" + this.StackTrace ;
		}
		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="vAPIName">API函数的名称</param>
		/// <param name="vReturnValue">函数返回值</param>
		/// <param name="vDllError">发生错误时的操作系统错误代码</param>
		/// <param name="msg">错误信息</param>
		public Win32APIException( string vAPIName , int vReturnValue , int vDllError , string msg )
		{
			strAPIName		= vAPIName;
			intLastDllError = vDllError;
			intReturnValue	= vReturnValue ;
			strErrorMsg = msg ;
		}
		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="vAPIName">API函数的名称</param>
		/// <param name="vReturnValue">函数返回值</param>
		/// <param name="vDllError">发生错误时的操作系统错误代码</param>
		public Win32APIException( string vAPIName , int vReturnValue , int vDllError )
		{
			strAPIName		= vAPIName;
			intLastDllError = vDllError;
			intReturnValue	= vReturnValue ;
		}
		/// <summary>
		/// 初始化对象
		/// </summary>
		/// <param name="vAPIName">API函数的名称</param>
		/// <param name="vReturnValue">函数返回值</param>
		public Win32APIException( string vAPIName , int vReturnValue )
		{
			strAPIName		= vAPIName;
			intLastDllError = (int)Kernel32.GetLastError();
			intReturnValue	= vReturnValue ;
		}
		public Win32APIException()
		{
		}

	}//public class Wind32Exception

	public enum PeekMessageFlags
	{
		PM_NOREMOVE		= 0,
		PM_REMOVE		= 1,
		PM_NOYIELD		= 2
	}

	public enum SetWindowPosFlags : uint
	{
		SWP_NOSIZE          = 0x0001,
		SWP_NOMOVE          = 0x0002,
		SWP_NOZORDER        = 0x0004,
		SWP_NOREDRAW        = 0x0008,
		SWP_NOACTIVATE      = 0x0010,
		SWP_FRAMECHANGED    = 0x0020,
		SWP_SHOWWINDOW      = 0x0040,
		SWP_HIDEWINDOW      = 0x0080,
		SWP_NOCOPYBITS      = 0x0100,
		SWP_NOOWNERZORDER   = 0x0200, 
		SWP_NOSENDCHANGING  = 0x0400,
		SWP_DRAWFRAME       = 0x0020,
		SWP_NOREPOSITION    = 0x0200,
		SWP_DEFERERASE      = 0x2000,
		SWP_ASYNCWINDOWPOS  = 0x4000
	}

	public enum SetWindowPosZ 
	{
		HWND_TOP        = 0,
		HWND_BOTTOM     = 1,
		HWND_TOPMOST    = -1,
		HWND_NOTOPMOST  = -2
	}

	public enum ShowWindowStyles : short
	{
		SW_HIDE             = 0,
		SW_SHOWNORMAL       = 1,
		SW_NORMAL           = 1,
		SW_SHOWMINIMIZED    = 2,
		SW_SHOWMAXIMIZED    = 3,
		SW_MAXIMIZE         = 3,
		SW_SHOWNOACTIVATE   = 4,
		SW_SHOW             = 5,
		SW_MINIMIZE         = 6,
		SW_SHOWMINNOACTIVE  = 7,
		SW_SHOWNA           = 8,
		SW_RESTORE          = 9,
		SW_SHOWDEFAULT      = 10,
		SW_FORCEMINIMIZE    = 11,
		SW_MAX              = 11
	}

	/// <summary>
	/// Class Style 
	/// </summary>
	public enum ClassStyle
	{
		CS_VREDRAW         = 0x0001     ,         
		CS_HREDRAW         = 0x0002     ,
		CS_DBLCLKS         = 0x0008     ,
		CS_OWNDC           = 0x0020     ,
		CS_CLASSDC         = 0x0040     ,
		CS_PARENTDC        = 0x0080     ,
		CS_NOCLOSE         = 0x0200     ,
		CS_SAVEBITS        = 0x0800     ,
		CS_BYTEALIGNCLIENT = 0x1000     ,
		CS_BYTEALIGNWINDOW = 0x2000     ,
		CS_GLOBALCLASS     = 0x4000     ,
		CS_IME             = 0x00010000 
	}

	public enum WindowStyles : uint
	{
		WS_OVERLAPPED       = 0x00000000,
		WS_POPUP            = 0x80000000,
		WS_CHILD            = 0x40000000,
		WS_MINIMIZE         = 0x20000000,
		WS_VISIBLE          = 0x10000000,
		WS_DISABLED         = 0x08000000,
		WS_CLIPSIBLINGS     = 0x04000000,
		WS_CLIPCHILDREN     = 0x02000000,
		WS_MAXIMIZE         = 0x01000000,
		WS_CAPTION          = 0x00C00000,
		WS_BORDER           = 0x00800000,
		WS_DLGFRAME         = 0x00400000,
		WS_VSCROLL          = 0x00200000,
		WS_HSCROLL          = 0x00100000,
		WS_SYSMENU          = 0x00080000,
		WS_THICKFRAME       = 0x00040000,
		WS_GROUP            = 0x00020000,
		WS_TABSTOP          = 0x00010000,
		WS_MINIMIZEBOX      = 0x00020000,
		WS_MAXIMIZEBOX      = 0x00010000,
		WS_TILED            = 0x00000000,
		WS_ICONIC           = 0x20000000,
		WS_SIZEBOX          = 0x00040000,
		WS_POPUPWINDOW      = 0x80880000,
		WS_OVERLAPPEDWINDOW = 0x00CF0000,
		WS_TILEDWINDOW      = 0x00CF0000,
		WS_CHILDWINDOW      = 0x40000000
	}

	public enum WindowExStyles
	{
		WS_EX_DLGMODALFRAME     = 0x00000001,
		WS_EX_NOPARENTNOTIFY    = 0x00000004,
		WS_EX_TOPMOST           = 0x00000008,
		WS_EX_ACCEPTFILES       = 0x00000010,
		WS_EX_TRANSPARENT       = 0x00000020,
		WS_EX_MDICHILD          = 0x00000040,
		WS_EX_TOOLWINDOW        = 0x00000080,
		WS_EX_WINDOWEDGE        = 0x00000100,
		WS_EX_CLIENTEDGE        = 0x00000200,
		WS_EX_CONTEXTHELP       = 0x00000400,
		WS_EX_RIGHT             = 0x00001000,
		WS_EX_LEFT              = 0x00000000,
		WS_EX_RTLREADING        = 0x00002000,
		WS_EX_LTRREADING        = 0x00000000,
		WS_EX_LEFTSCROLLBAR     = 0x00004000,
		WS_EX_RIGHTSCROLLBAR    = 0x00000000,
		WS_EX_CONTROLPARENT     = 0x00010000,
		WS_EX_STATICEDGE        = 0x00020000,
		WS_EX_APPWINDOW         = 0x00040000,
		WS_EX_OVERLAPPEDWINDOW  = 0x00000300,
		WS_EX_PALETTEWINDOW     = 0x00000188,
		WS_EX_LAYERED			= 0x00080000
	}

	public enum VirtualKeys
	{
		VK_LBUTTON		= 0x01,
		VK_CANCEL		= 0x03,
		VK_BACK			= 0x08,
		VK_TAB			= 0x09,
		VK_CLEAR		= 0x0C,
		VK_RETURN		= 0x0D,
		VK_SHIFT		= 0x10,
		VK_CONTROL		= 0x11,
		VK_MENU			= 0x12,
		VK_CAPITAL		= 0x14,
		VK_ESCAPE		= 0x1B,
		VK_SPACE		= 0x20,
		VK_PRIOR		= 0x21,
		VK_NEXT			= 0x22,
		VK_END			= 0x23,
		VK_HOME			= 0x24,
		VK_LEFT			= 0x25,
		VK_UP			= 0x26,
		VK_RIGHT		= 0x27,
		VK_DOWN			= 0x28,
		VK_SELECT		= 0x29,
		VK_EXECUTE		= 0x2B,
		VK_SNAPSHOT		= 0x2C,
		VK_HELP			= 0x2F,
		VK_0			= 0x30,
		VK_1			= 0x31,
		VK_2			= 0x32,
		VK_3			= 0x33,
		VK_4			= 0x34,
		VK_5			= 0x35,
		VK_6			= 0x36,
		VK_7			= 0x37,
		VK_8			= 0x38,
		VK_9			= 0x39,
		VK_A			= 0x41,
		VK_B			= 0x42,
		VK_C			= 0x43,
		VK_D			= 0x44,
		VK_E			= 0x45,
		VK_F			= 0x46,
		VK_G			= 0x47,
		VK_H			= 0x48,
		VK_I			= 0x49,
		VK_J			= 0x4A,
		VK_K			= 0x4B,
		VK_L			= 0x4C,
		VK_M			= 0x4D,
		VK_N			= 0x4E,
		VK_O			= 0x4F,
		VK_P			= 0x50,
		VK_Q			= 0x51,
		VK_R			= 0x52,
		VK_S			= 0x53,
		VK_T			= 0x54,
		VK_U			= 0x55,
		VK_V			= 0x56,
		VK_W			= 0x57,
		VK_X			= 0x58,
		VK_Y			= 0x59,
		VK_Z			= 0x5A,
		VK_NUMPAD0		= 0x60,
		VK_NUMPAD1		= 0x61,
		VK_NUMPAD2		= 0x62,
		VK_NUMPAD3		= 0x63,
		VK_NUMPAD4		= 0x64,
		VK_NUMPAD5		= 0x65,
		VK_NUMPAD6		= 0x66,
		VK_NUMPAD7		= 0x67,
		VK_NUMPAD8		= 0x68,
		VK_NUMPAD9		= 0x69,
		VK_MULTIPLY		= 0x6A,
		VK_ADD			= 0x6B,
		VK_SEPARATOR	= 0x6C,
		VK_SUBTRACT		= 0x6D,
		VK_DECIMAL		= 0x6E,
		VK_DIVIDE		= 0x6F,
		VK_ATTN			= 0xF6,
		VK_CRSEL		= 0xF7,
		VK_EXSEL		= 0xF8,
		VK_EREOF		= 0xF9,
		VK_PLAY			= 0xFA,  
		VK_ZOOM			= 0xFB,
		VK_NONAME		= 0xFC,
		VK_PA1			= 0xFD,
		VK_OEM_CLEAR	= 0xFE,
		VK_LWIN			= 0x5B,
		VK_RWIN			= 0x5C,
		VK_APPS			= 0x5D,   
		VK_LSHIFT		= 0xA0,   
		VK_RSHIFT		= 0xA1,   
		VK_LCONTROL		= 0xA2,   
		VK_RCONTROL		= 0xA3,   
		VK_LMENU		= 0xA4,   
		VK_RMENU		= 0xA5
	}

	public enum Msgs
	{
		WM_NULL                   = 0x0000,
		WM_CREATE                 = 0x0001,
		WM_DESTROY                = 0x0002,
		WM_MOVE                   = 0x0003,
		WM_SIZE                   = 0x0005,
		WM_ACTIVATE               = 0x0006,
		WM_SETFOCUS               = 0x0007,
		WM_KILLFOCUS              = 0x0008,
		WM_ENABLE                 = 0x000A,
		WM_SETREDRAW              = 0x000B,
		WM_SETTEXT                = 0x000C,
		WM_GETTEXT                = 0x000D,
		WM_GETTEXTLENGTH          = 0x000E,
		WM_PAINT                  = 0x000F,
		WM_CLOSE                  = 0x0010,
		WM_QUERYENDSESSION        = 0x0011,
		WM_QUIT                   = 0x0012,
		WM_QUERYOPEN              = 0x0013,
		WM_ERASEBKGND             = 0x0014,
		WM_SYSCOLORCHANGE         = 0x0015,
		WM_ENDSESSION             = 0x0016,
		WM_SHOWWINDOW             = 0x0018,
		WM_WININICHANGE           = 0x001A,
		WM_SETTINGCHANGE          = 0x001A,
		WM_DEVMODECHANGE          = 0x001B,
		WM_ACTIVATEAPP            = 0x001C,
		WM_FONTCHANGE             = 0x001D,
		WM_TIMECHANGE             = 0x001E,
		WM_CANCELMODE             = 0x001F,
		WM_SETCURSOR              = 0x0020,
		WM_MOUSEACTIVATE          = 0x0021,
		WM_CHILDACTIVATE          = 0x0022,
		WM_QUEUESYNC              = 0x0023,
		WM_GETMINMAXINFO          = 0x0024,
		WM_PAINTICON              = 0x0026,
		WM_ICONERASEBKGND         = 0x0027,
		WM_NEXTDLGCTL             = 0x0028,
		WM_SPOOLERSTATUS          = 0x002A,
		WM_DRAWITEM               = 0x002B,
		WM_MEASUREITEM            = 0x002C,
		WM_DELETEITEM             = 0x002D,
		WM_VKEYTOITEM             = 0x002E,
		WM_CHARTOITEM             = 0x002F,
		WM_SETFONT                = 0x0030,
		WM_GETFONT                = 0x0031,
		WM_SETHOTKEY              = 0x0032,
		WM_GETHOTKEY              = 0x0033,
		WM_QUERYDRAGICON          = 0x0037,
		WM_COMPAREITEM            = 0x0039,
		WM_GETOBJECT              = 0x003D,
		WM_COMPACTING             = 0x0041,
		WM_COMMNOTIFY             = 0x0044 ,
		WM_WINDOWPOSCHANGING      = 0x0046,
		WM_WINDOWPOSCHANGED       = 0x0047,
		WM_POWER                  = 0x0048,
		WM_COPYDATA               = 0x004A,
		WM_CANCELJOURNAL          = 0x004B,
		WM_NOTIFY                 = 0x004E,
		WM_INPUTLANGCHANGEREQUEST = 0x0050,
		WM_INPUTLANGCHANGE        = 0x0051,
		WM_TCARD                  = 0x0052,
		WM_HELP                   = 0x0053,
		WM_USERCHANGED            = 0x0054,
		WM_NOTIFYFORMAT           = 0x0055,
		WM_CONTEXTMENU            = 0x007B,
		WM_STYLECHANGING          = 0x007C,
		WM_STYLECHANGED           = 0x007D,
		WM_DISPLAYCHANGE          = 0x007E,
		WM_GETICON                = 0x007F,
		WM_SETICON                = 0x0080,
		WM_NCCREATE               = 0x0081,
		WM_NCDESTROY              = 0x0082,
		WM_NCCALCSIZE             = 0x0083,
		WM_NCHITTEST              = 0x0084,
		WM_NCPAINT                = 0x0085,
		WM_NCACTIVATE             = 0x0086,
		WM_GETDLGCODE             = 0x0087,
		WM_SYNCPAINT              = 0x0088,
		WM_NCMOUSEMOVE            = 0x00A0,
		WM_MOUSEWHEEL             = 0x020A,
		WM_NCLBUTTONDOWN          = 0x00A1,
		WM_NCLBUTTONUP            = 0x00A2,
		WM_NCLBUTTONDBLCLK        = 0x00A3,
		WM_NCRBUTTONDOWN          = 0x00A4,
		WM_NCRBUTTONUP            = 0x00A5,
		WM_NCRBUTTONDBLCLK        = 0x00A6,
		WM_NCMBUTTONDOWN          = 0x00A7,
		WM_NCMBUTTONUP            = 0x00A8,
		WM_NCMBUTTONDBLCLK        = 0x00A9,
		WM_NCXBUTTONDOWN          = 0x00AB,
		WM_NCXBUTTONUP            = 0x00AC,
		WM_KEYDOWN                = 0x0100,
		WM_KEYUP                  = 0x0101,
		WM_CHAR                   = 0x0102,
		WM_DEADCHAR               = 0x0103,
		WM_SYSKEYDOWN             = 0x0104,
		WM_SYSKEYUP               = 0x0105,
		WM_SYSCHAR                = 0x0106,
		WM_SYSDEADCHAR            = 0x0107,
		WM_KEYLAST                = 0x0108,
		WM_IME_STARTCOMPOSITION   = 0x010D,
		WM_IME_ENDCOMPOSITION     = 0x010E,
		WM_IME_COMPOSITION        = 0x010F,
		WM_IME_KEYLAST            = 0x010F,
		WM_INITDIALOG             = 0x0110,
		WM_COMMAND                = 0x0111,
		WM_SYSCOMMAND             = 0x0112,
		WM_TIMER                  = 0x0113,
		WM_HSCROLL                = 0x0114,
		WM_VSCROLL                = 0x0115,
		WM_INITMENU               = 0x0116,
		WM_INITMENUPOPUP          = 0x0117,
		WM_MENUSELECT             = 0x011F,
		WM_MENUCHAR               = 0x0120,
		WM_ENTERIDLE              = 0x0121,
		WM_MENURBUTTONUP          = 0x0122,
		WM_MENUDRAG               = 0x0123,
		WM_MENUGETOBJECT          = 0x0124,
		WM_UNINITMENUPOPUP        = 0x0125,
		WM_MENUCOMMAND            = 0x0126,
		WM_CTLCOLORMSGBOX         = 0x0132,
		WM_CTLCOLOREDIT           = 0x0133,
		WM_CTLCOLORLISTBOX        = 0x0134,
		WM_CTLCOLORBTN            = 0x0135,
		WM_CTLCOLORDLG            = 0x0136,
		WM_CTLCOLORSCROLLBAR      = 0x0137,
		WM_CTLCOLORSTATIC         = 0x0138,
		WM_MOUSEMOVE              = 0x0200,
		WM_LBUTTONDOWN            = 0x0201,
		WM_LBUTTONUP              = 0x0202,
		WM_LBUTTONDBLCLK          = 0x0203,
		WM_RBUTTONDOWN            = 0x0204,
		WM_RBUTTONUP              = 0x0205,
		WM_RBUTTONDBLCLK          = 0x0206,
		WM_MBUTTONDOWN            = 0x0207,
		WM_MBUTTONUP              = 0x0208,
		WM_MBUTTONDBLCLK          = 0x0209,
		WM_XBUTTONDOWN            = 0x020B,
		WM_XBUTTONUP              = 0x020C,
		WM_XBUTTONDBLCLK          = 0x020D,
		WM_PARENTNOTIFY           = 0x0210,
		WM_ENTERMENULOOP          = 0x0211,
		WM_EXITMENULOOP           = 0x0212,
		WM_NEXTMENU               = 0x0213,
		WM_SIZING                 = 0x0214,
		WM_CAPTURECHANGED         = 0x0215,
		WM_MOVING                 = 0x0216,
		WM_DEVICECHANGE           = 0x0219,
		WM_MDICREATE              = 0x0220,
		WM_MDIDESTROY             = 0x0221,
		WM_MDIACTIVATE            = 0x0222,
		WM_MDIRESTORE             = 0x0223,
		WM_MDINEXT                = 0x0224,
		WM_MDIMAXIMIZE            = 0x0225,
		WM_MDITILE                = 0x0226,
		WM_MDICASCADE             = 0x0227,
		WM_MDIICONARRANGE         = 0x0228,
		WM_MDIGETACTIVE           = 0x0229,
		WM_MDISETMENU             = 0x0230,
		WM_ENTERSIZEMOVE          = 0x0231,
		WM_EXITSIZEMOVE           = 0x0232,
		WM_DROPFILES              = 0x0233,
		WM_MDIREFRESHMENU         = 0x0234,
		WM_IME_SETCONTEXT         = 0x0281,
		WM_IME_NOTIFY             = 0x0282,
		WM_IME_CONTROL            = 0x0283,
		WM_IME_COMPOSITIONFULL    = 0x0284,
		WM_IME_SELECT             = 0x0285,
		WM_IME_CHAR               = 0x0286,
		WM_IME_REQUEST            = 0x0288,
		WM_IME_KEYDOWN            = 0x0290,
		WM_IME_KEYUP              = 0x0291,
		WM_MOUSEHOVER             = 0x02A1,
		WM_MOUSELEAVE             = 0x02A3,
		WM_CUT                    = 0x0300,
		WM_COPY                   = 0x0301,
		WM_PASTE                  = 0x0302,
		WM_CLEAR                  = 0x0303,
		WM_UNDO                   = 0x0304,
		WM_RENDERFORMAT           = 0x0305,
		WM_RENDERALLFORMATS       = 0x0306,
		WM_DESTROYCLIPBOARD       = 0x0307,
		WM_DRAWCLIPBOARD          = 0x0308,
		WM_PAINTCLIPBOARD         = 0x0309,
		WM_VSCROLLCLIPBOARD       = 0x030A,
		WM_SIZECLIPBOARD          = 0x030B,
		WM_ASKCBFORMATNAME        = 0x030C,
		WM_CHANGECBCHAIN          = 0x030D,
		WM_HSCROLLCLIPBOARD       = 0x030E,
		WM_QUERYNEWPALETTE        = 0x030F,
		WM_PALETTEISCHANGING      = 0x0310,
		WM_PALETTECHANGED         = 0x0311,
		WM_HOTKEY                 = 0x0312,
		WM_PRINT                  = 0x0317,
		WM_PRINTCLIENT            = 0x0318,
		WM_HANDHELDFIRST          = 0x0358,
		WM_HANDHELDLAST           = 0x035F,
		WM_AFXFIRST               = 0x0360,
		WM_AFXLAST                = 0x037F,
		WM_PENWINFIRST            = 0x0380,
		WM_PENWINLAST             = 0x038F,
		WM_APP                    = 0x8000,
		WM_USER                   = 0x0400
	}

	public enum Cursors : uint
	{
		IDC_ARROW		= 32512U,
		IDC_IBEAM       = 32513U,
		IDC_WAIT        = 32514U,
		IDC_CROSS       = 32515U,
		IDC_UPARROW     = 32516U,
		IDC_SIZE        = 32640U,
		IDC_ICON        = 32641U,
		IDC_SIZENWSE    = 32642U,
		IDC_SIZENESW    = 32643U,
		IDC_SIZEWE      = 32644U,
		IDC_SIZENS      = 32645U,
		IDC_SIZEALL     = 32646U,
		IDC_NO          = 32648U,
		IDC_HAND        = 32649U,
		IDC_APPSTARTING = 32650U,
		IDC_HELP        = 32651U
	}

	public enum TrackerEventFlags : uint
	{
		TME_HOVER	= 0x00000001,
		TME_LEAVE	= 0x00000002,
		TME_QUERY	= 0x40000000,
		TME_CANCEL	= 0x80000000
	}

	public enum MouseActivateFlags
	{
		MA_ACTIVATE			= 1,
		MA_ACTIVATEANDEAT   = 2,
		MA_NOACTIVATE       = 3,
		MA_NOACTIVATEANDEAT = 4
	}

	public enum DialogCodes
	{
		DLGC_WANTARROWS			= 0x0001,
		DLGC_WANTTAB			= 0x0002,
		DLGC_WANTALLKEYS		= 0x0004,
		DLGC_WANTMESSAGE		= 0x0004,
		DLGC_HASSETSEL			= 0x0008,
		DLGC_DEFPUSHBUTTON		= 0x0010,
		DLGC_UNDEFPUSHBUTTON	= 0x0020,
		DLGC_RADIOBUTTON		= 0x0040,
		DLGC_WANTCHARS			= 0x0080,
		DLGC_STATIC				= 0x0100,
		DLGC_BUTTON				= 0x2000
	}
	public enum UpdateLayeredWindowsFlags
	{
		ULW_COLORKEY = 0x00000001,
		ULW_ALPHA    = 0x00000002,
		ULW_OPAQUE   = 0x00000004
	}

	public enum AlphaFlags : byte
	{
		AC_SRC_OVER  = 0x00,
		AC_SRC_ALPHA = 0x01
	}

	/// <summary>
	/// 图形设备上下文字节运算掩码
	/// </summary>
	public enum DCRasterOperations
	{
		R2_BLACK            = 1   , /*  0       */
		R2_NOTMERGEPEN      = 2   , /* DPon     */
		R2_MASKNOTPEN       = 3   , /* DPna     */
		R2_NOTCOPYPEN       = 4   , /* PN       */
		R2_MASKPENNOT       = 5   , /* PDna     */
		R2_NOT              = 6   , /* Dn       */
		R2_XORPEN           = 7   , /* DPx      */
		R2_NOTMASKPEN       = 8   , /* DPan     */
		R2_MASKPEN          = 9   , /* DPa      */
		R2_NOTXORPEN        = 10  , /* DPxn     */
		R2_NOP              = 11  , /* D        */
		R2_MERGENOTPEN      = 12  , /* DPno     */
		R2_COPYPEN          = 13  , /* P        */
		R2_MERGEPENNOT      = 14  , /* PDno     */
		R2_MERGEPEN         = 15  , /* DPo      */
		R2_WHITE            = 16  , /*  1       */
		R2_LAST             = 16
	}

	public enum RasterOperations : uint
	{
		SRCCOPY		= 0x00CC0020,
		SRCPAINT	= 0x00EE0086,
		SRCAND		= 0x008800C6,
		SRCINVERT	= 0x00660046,
		SRCERASE	= 0x00440328,
		NOTSRCCOPY	= 0x00330008,
		NOTSRCERASE = 0x001100A6,
		MERGECOPY	= 0x00C000CA,
		MERGEPAINT	= 0x00BB0226,
		PATCOPY		= 0x00F00021,
		PATPAINT	= 0x00FB0A09,
		PATINVERT	= 0x005A0049,
		DSTINVERT	= 0x00550009,
		BLACKNESS	= 0x00000042,
		WHITENESS	= 0x00FF0062
	}

	public enum BrushStyles
	{
		BS_SOLID			= 0,
		BS_NULL             = 1,
		BS_HOLLOW           = 1,
		BS_HATCHED          = 2,
		BS_PATTERN          = 3,
		BS_INDEXED          = 4,
		BS_DIBPATTERN       = 5,
		BS_DIBPATTERNPT     = 6,
		BS_PATTERN8X8       = 7,
		BS_DIBPATTERN8X8    = 8,
		BS_MONOPATTERN      = 9
	}

	public enum HatchStyles
	{
		HS_HORIZONTAL       = 0,
		HS_VERTICAL         = 1,
		HS_FDIAGONAL        = 2,
		HS_BDIAGONAL        = 3,
		HS_CROSS            = 4,
		HS_DIAGCROSS        = 5
	}

	public enum CombineFlags
	{
		RGN_AND		= 1,
		RGN_OR		= 2,
		RGN_XOR		= 3,
		RGN_DIFF	= 4,
		RGN_COPY	= 5
	}

	public enum HitTest
	{
		HTERROR			= -2,
		HTTRANSPARENT   = -1,
		HTNOWHERE		= 0,
		HTCLIENT		= 1,
		HTCAPTION		= 2,
		HTSYSMENU		= 3,
		HTGROWBOX		= 4,
		HTSIZE			= 4,
		HTMENU			= 5,
		HTHSCROLL		= 6,
		HTVSCROLL		= 7,
		HTMINBUTTON		= 8,
		HTMAXBUTTON		= 9,
		HTLEFT			= 10,
		HTRIGHT			= 11,
		HTTOP			= 12,
		HTTOPLEFT		= 13,
		HTTOPRIGHT		= 14,
		HTBOTTOM		= 15,
		HTBOTTOMLEFT	= 16,
		HTBOTTOMRIGHT	= 17,
		HTBORDER		= 18,
		HTREDUCE		= 8,
		HTZOOM			= 9 ,
		HTSIZEFIRST		= 10,
		HTSIZELAST		= 17,
		HTOBJECT		= 19,
		HTCLOSE			= 20,
		HTHELP			= 21
	}

	public enum AnimateFlags
	{
		AW_HOR_POSITIVE = 0x00000001,
		AW_HOR_NEGATIVE = 0x00000002,
		AW_VER_POSITIVE = 0x00000004,
		AW_VER_NEGATIVE = 0x00000008,
		AW_CENTER		= 0x00000010,
		AW_HIDE			= 0x00010000,
		AW_ACTIVATE		= 0x00020000,
		AW_SLIDE		= 0x00040000,
		AW_BLEND		= 0x00080000
	}

	public enum GetWindowLongFlags
	{
		GWL_WNDPROC         = -4,
		GWL_HINSTANCE       = -6,
		GWL_HWNDPARENT      = -8,
		GWL_STYLE           = -16,
		GWL_EXSTYLE         = -20,
		GWL_USERDATA        = -21,
		GWL_ID              = -12
	}
    
	public enum SPIActions
	{
		SPI_GETBEEP                         = 0x0001,
		SPI_SETBEEP                         = 0x0002,
		SPI_GETMOUSE                        = 0x0003,
		SPI_SETMOUSE                        = 0x0004,
		SPI_GETBORDER                       = 0x0005,
		SPI_SETBORDER                       = 0x0006,
		SPI_GETKEYBOARDSPEED                = 0x000A,
		SPI_SETKEYBOARDSPEED                = 0x000B,
		SPI_LANGDRIVER                      = 0x000C,
		SPI_ICONHORIZONTALSPACING           = 0x000D,
		SPI_GETSCREENSAVETIMEOUT            = 0x000E,
		SPI_SETSCREENSAVETIMEOUT            = 0x000F,
		SPI_GETSCREENSAVEACTIVE             = 0x0010,
		SPI_SETSCREENSAVEACTIVE             = 0x0011,
		SPI_GETGRIDGRANULARITY              = 0x0012,
		SPI_SETGRIDGRANULARITY              = 0x0013,
		SPI_SETDESKWALLPAPER                = 0x0014,
		SPI_SETDESKPATTERN                  = 0x0015,
		SPI_GETKEYBOARDDELAY                = 0x0016,
		SPI_SETKEYBOARDDELAY                = 0x0017,
		SPI_ICONVERTICALSPACING             = 0x0018,
		SPI_GETICONTITLEWRAP                = 0x0019,
		SPI_SETICONTITLEWRAP                = 0x001A,
		SPI_GETMENUDROPALIGNMENT            = 0x001B,
		SPI_SETMENUDROPALIGNMENT            = 0x001C,
		SPI_SETDOUBLECLKWIDTH               = 0x001D,
		SPI_SETDOUBLECLKHEIGHT              = 0x001E,
		SPI_GETICONTITLELOGFONT             = 0x001F,
		SPI_SETDOUBLECLICKTIME              = 0x0020,
		SPI_SETMOUSEBUTTONSWAP              = 0x0021,
		SPI_SETICONTITLELOGFONT             = 0x0022,
		SPI_GETFASTTASKSWITCH               = 0x0023,
		SPI_SETFASTTASKSWITCH               = 0x0024,
		SPI_SETDRAGFULLWINDOWS              = 0x0025,
		SPI_GETDRAGFULLWINDOWS              = 0x0026,
		SPI_GETNONCLIENTMETRICS             = 0x0029,
		SPI_SETNONCLIENTMETRICS             = 0x002A,
		SPI_GETMINIMIZEDMETRICS             = 0x002B,
		SPI_SETMINIMIZEDMETRICS             = 0x002C,
		SPI_GETICONMETRICS                  = 0x002D,
		SPI_SETICONMETRICS                  = 0x002E,
		SPI_SETWORKAREA                     = 0x002F,
		SPI_GETWORKAREA                     = 0x0030,
		SPI_SETPENWINDOWS                   = 0x0031,
		SPI_GETHIGHCONTRAST                 = 0x0042,
		SPI_SETHIGHCONTRAST                 = 0x0043,
		SPI_GETKEYBOARDPREF                 = 0x0044,
		SPI_SETKEYBOARDPREF                 = 0x0045,
		SPI_GETSCREENREADER                 = 0x0046,
		SPI_SETSCREENREADER                 = 0x0047,
		SPI_GETANIMATION                    = 0x0048,
		SPI_SETANIMATION                    = 0x0049,
		SPI_GETFONTSMOOTHING                = 0x004A,
		SPI_SETFONTSMOOTHING                = 0x004B,
		SPI_SETDRAGWIDTH                    = 0x004C,
		SPI_SETDRAGHEIGHT                   = 0x004D,
		SPI_SETHANDHELD                     = 0x004E,
		SPI_GETLOWPOWERTIMEOUT              = 0x004F,
		SPI_GETPOWEROFFTIMEOUT              = 0x0050,
		SPI_SETLOWPOWERTIMEOUT              = 0x0051,
		SPI_SETPOWEROFFTIMEOUT              = 0x0052,
		SPI_GETLOWPOWERACTIVE               = 0x0053,
		SPI_GETPOWEROFFACTIVE               = 0x0054,
		SPI_SETLOWPOWERACTIVE               = 0x0055,
		SPI_SETPOWEROFFACTIVE               = 0x0056,
		SPI_SETCURSORS                      = 0x0057,
		SPI_SETICONS                        = 0x0058,
		SPI_GETDEFAULTINPUTLANG             = 0x0059,
		SPI_SETDEFAULTINPUTLANG             = 0x005A,
		SPI_SETLANGTOGGLE                   = 0x005B,
		SPI_GETWINDOWSEXTENSION             = 0x005C,
		SPI_SETMOUSETRAILS                  = 0x005D,
		SPI_GETMOUSETRAILS                  = 0x005E,
		SPI_SETSCREENSAVERRUNNING           = 0x0061,
		SPI_SCREENSAVERRUNNING              = 0x0061,
		SPI_GETFILTERKEYS                   = 0x0032,
		SPI_SETFILTERKEYS                   = 0x0033,
		SPI_GETTOGGLEKEYS                   = 0x0034,
		SPI_SETTOGGLEKEYS                   = 0x0035,
		SPI_GETMOUSEKEYS                    = 0x0036,
		SPI_SETMOUSEKEYS                    = 0x0037,
		SPI_GETSHOWSOUNDS                   = 0x0038,
		SPI_SETSHOWSOUNDS                   = 0x0039,
		SPI_GETSTICKYKEYS                   = 0x003A,
		SPI_SETSTICKYKEYS                   = 0x003B,
		SPI_GETACCESSTIMEOUT                = 0x003C,
		SPI_SETACCESSTIMEOUT                = 0x003D,
		SPI_GETSERIALKEYS                   = 0x003E,
		SPI_SETSERIALKEYS                   = 0x003F,
		SPI_GETSOUNDSENTRY                  = 0x0040,
		SPI_SETSOUNDSENTRY                  = 0x0041,
		SPI_GETSNAPTODEFBUTTON              = 0x005F,
		SPI_SETSNAPTODEFBUTTON              = 0x0060,
		SPI_GETMOUSEHOVERWIDTH              = 0x0062,
		SPI_SETMOUSEHOVERWIDTH              = 0x0063,
		SPI_GETMOUSEHOVERHEIGHT             = 0x0064,
		SPI_SETMOUSEHOVERHEIGHT             = 0x0065,
		SPI_GETMOUSEHOVERTIME               = 0x0066,
		SPI_SETMOUSEHOVERTIME               = 0x0067,
		SPI_GETWHEELSCROLLLINES             = 0x0068,
		SPI_SETWHEELSCROLLLINES             = 0x0069,
		SPI_GETMENUSHOWDELAY                = 0x006A,
		SPI_SETMENUSHOWDELAY                = 0x006B,
		SPI_GETSHOWIMEUI                    = 0x006E,
		SPI_SETSHOWIMEUI                    = 0x006F,
		SPI_GETMOUSESPEED                   = 0x0070,
		SPI_SETMOUSESPEED                   = 0x0071,
		SPI_GETSCREENSAVERRUNNING           = 0x0072,
		SPI_GETDESKWALLPAPER                = 0x0073,
		SPI_GETACTIVEWINDOWTRACKING         = 0x1000,
		SPI_SETACTIVEWINDOWTRACKING         = 0x1001,
		SPI_GETMENUANIMATION                = 0x1002,
		SPI_SETMENUANIMATION                = 0x1003,
		SPI_GETCOMBOBOXANIMATION            = 0x1004,
		SPI_SETCOMBOBOXANIMATION            = 0x1005,
		SPI_GETLISTBOXSMOOTHSCROLLING       = 0x1006,
		SPI_SETLISTBOXSMOOTHSCROLLING       = 0x1007,
		SPI_GETGRADIENTCAPTIONS             = 0x1008,
		SPI_SETGRADIENTCAPTIONS             = 0x1009,
		SPI_GETKEYBOARDCUES                 = 0x100A,
		SPI_SETKEYBOARDCUES                 = 0x100B,
		SPI_GETMENUUNDERLINES               = 0x100A,
		SPI_SETMENUUNDERLINES               = 0x100B,
		SPI_GETACTIVEWNDTRKZORDER           = 0x100C,
		SPI_SETACTIVEWNDTRKZORDER           = 0x100D,
		SPI_GETHOTTRACKING                  = 0x100E,
		SPI_SETHOTTRACKING                  = 0x100F,
		SPI_GETMENUFADE                     = 0x1012,
		SPI_SETMENUFADE                     = 0x1013,
		SPI_GETSELECTIONFADE                = 0x1014,
		SPI_SETSELECTIONFADE                = 0x1015,
		SPI_GETTOOLTIPANIMATION             = 0x1016,
		SPI_SETTOOLTIPANIMATION             = 0x1017,
		SPI_GETTOOLTIPFADE                  = 0x1018,
		SPI_SETTOOLTIPFADE                  = 0x1019,
		SPI_GETCURSORSHADOW                 = 0x101A,
		SPI_SETCURSORSHADOW                 = 0x101B,
		SPI_GETMOUSESONAR                   = 0x101C,
		SPI_SETMOUSESONAR                   = 0x101D,
		SPI_GETMOUSECLICKLOCK               = 0x101E,
		SPI_SETMOUSECLICKLOCK               = 0x101F,
		SPI_GETMOUSEVANISH                  = 0x1020,
		SPI_SETMOUSEVANISH                  = 0x1021,
		SPI_GETFLATMENU                     = 0x1022,
		SPI_SETFLATMENU                     = 0x1023,
		SPI_GETDROPSHADOW                   = 0x1024,
		SPI_SETDROPSHADOW                   = 0x1025,
		SPI_GETUIEFFECTS                    = 0x103E,
		SPI_SETUIEFFECTS                    = 0x103F,
		SPI_GETFOREGROUNDLOCKTIMEOUT        = 0x2000,
		SPI_SETFOREGROUNDLOCKTIMEOUT        = 0x2001,
		SPI_GETACTIVEWNDTRKTIMEOUT          = 0x2002,
		SPI_SETACTIVEWNDTRKTIMEOUT          = 0x2003,
		SPI_GETFOREGROUNDFLASHCOUNT         = 0x2004,
		SPI_SETFOREGROUNDFLASHCOUNT         = 0x2005,
		SPI_GETCARETWIDTH                   = 0x2006,
		SPI_SETCARETWIDTH                   = 0x2007,
		SPI_GETMOUSECLICKLOCKTIME           = 0x2008,
		SPI_SETMOUSECLICKLOCKTIME           = 0x2009,
		SPI_GETFONTSMOOTHINGTYPE            = 0x200A,
		SPI_SETFONTSMOOTHINGTYPE            = 0x200B,
		SPI_GETFONTSMOOTHINGCONTRAST        = 0x200C,
		SPI_SETFONTSMOOTHINGCONTRAST        = 0x200D,
		SPI_GETFOCUSBORDERWIDTH             = 0x200E,
		SPI_SETFOCUSBORDERWIDTH             = 0x200F,
		SPI_GETFOCUSBORDERHEIGHT            = 0x2010,
		SPI_SETFOCUSBORDERHEIGHT            = 0x2011
	}

	/// <summary>
	/// 获得系统信息的编号,本变量传送给Win32API GetSystemMetrics
	/// </summary>
	public enum SystemMetricsConst : int
	{
		SM_CXSCREEN             = 0 , 
		SM_CYSCREEN             = 1 ,
		SM_CXVSCROLL            = 2 ,
		SM_CYHSCROLL            = 3 ,
		SM_CYCAPTION            = 4 ,
		SM_CXBORDER             = 5 ,
		SM_CYBORDER             = 6 ,
		SM_CXDLGFRAME           = 7 ,
		SM_CYDLGFRAME           = 8 ,
		SM_CYVTHUMB             = 9 ,
		SM_CXHTHUMB             = 10,
		SM_CXICON               = 11,
		SM_CYICON               = 12,
		SM_CXCURSOR             = 13,
		SM_CYCURSOR             = 14,
		SM_CYMENU               = 15,
		SM_CXFULLSCREEN         = 16,
		SM_CYFULLSCREEN         = 17,
		SM_CYKANJIWINDOW        = 18,
		SM_MOUSEPRESENT         = 19,
		SM_CYVSCROLL            = 20,
		SM_CXHSCROLL            = 21,
		SM_DEBUG                = 22,
		SM_SWAPBUTTON           = 23,
		SM_RESERVED1            = 24,
		SM_RESERVED2            = 25,
		SM_RESERVED3            = 26,
		SM_RESERVED4            = 27,
		SM_CXMIN                = 28,
		SM_CYMIN                = 29,
		SM_CXSIZE               = 30,
		SM_CYSIZE               = 31,
		SM_CXFRAME              = 32,
		SM_CYFRAME              = 33,
		SM_CXMINTRACK           = 34,
		SM_CYMINTRACK           = 35,
		SM_CXDOUBLECLK          = 36,
		SM_CYDOUBLECLK          = 37,
		SM_CXICONSPACING        = 38,
		SM_CYICONSPACING        = 39,
		SM_MENUDROPALIGNMENT    = 40,
		SM_PENWINDOWS           = 41,
		SM_DBCSENABLED          = 42,
		SM_CMOUSEBUTTONS        = 43,
		SM_SECURE               = 44,
		SM_CXEDGE               = 45,
		SM_CYEDGE               = 46,
		SM_CXMINSPACING         = 47,
		SM_CYMINSPACING         = 48,
		SM_CXSMICON             = 49,
		SM_CYSMICON             = 50,
		SM_CYSMCAPTION          = 51,
		SM_CXSMSIZE             = 52,
		SM_CYSMSIZE             = 53,
		SM_CXMENUSIZE           = 54,
		SM_CYMENUSIZE           = 55,
		SM_ARRANGE              = 56,
		SM_CXMINIMIZED          = 57,
		SM_CYMINIMIZED          = 58,
		SM_CXMAXTRACK           = 59,
		SM_CYMAXTRACK           = 60,
		SM_CXMAXIMIZED          = 61,
		SM_CYMAXIMIZED          = 62,
		SM_NETWORK              = 63,
		SM_CLEANBOOT            = 67,
		SM_CXDRAG               = 68,
		SM_CYDRAG               = 69,
		SM_SHOWSOUNDS           = 70,
		SM_CXMENUCHECK          = 71,   /* Use instead of GetMenuCheckMarkDimensions()! */
		SM_CYMENUCHECK          = 72,
		SM_SLOWMACHINE          = 73,
		SM_MIDEASTENABLED       = 74,
		SM_MOUSEWHEELPRESENT    = 75,
		SM_XVIRTUALSCREEN       = 76,
		SM_YVIRTUALSCREEN       = 77,
		SM_CXVIRTUALSCREEN      = 78,
		SM_CYVIRTUALSCREEN      = 79,
		SM_CMONITORS            = 80,
		SM_SAMEDISPLAYFORMAT    = 81,
		//SM_CMETRICS             = 76, // (WINVER < 0x0500) && (!defined(_WIN32_WINNT) || (_WIN32_WINNT < 0x0400))
		SM_CMETRICS             = 83
	}// public enum SystemMetricsConst : int

	public enum SPIWinINIFlags
	{
		SPIF_UPDATEINIFILE		= 0x0001,
		SPIF_SENDWININICHANGE	= 0x0002,
		SPIF_SENDCHANGE			= 0x0002
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MSG 
	{
		public int hwnd;
		public int message;
		public int wParam;
		public int lParam;
		public int time;
		public int pt_x;
		public int pt_y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PAINTSTRUCT
	{
		public int hdc;
		public int fErase;
		public Rectangle rcPaint;
		public int fRestore;
		public int fIncUpdate;
		public int Reserved1;
		public int Reserved2;
		public int Reserved3;
		public int Reserved4;
		public int Reserved5;
		public int Reserved6;
		public int Reserved7;
		public int Reserved8;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int left;
		public int top;
		public int right;
		public int bottom;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int x;
		public int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SIZE
	{
		public int cx;
		public int cy;
	}

	[StructLayout(LayoutKind.Sequential, Pack=1)]
	public struct BLENDFUNCTION
	{
		public byte BlendOp;
		public byte BlendFlags;
		public byte SourceConstantAlpha;
		public byte AlphaFormat;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct TRACKMOUSEEVENTS
	{
		public uint cbSize;
		public uint dwFlags;
		public int hWnd;
		public uint dwHoverTime;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct LOGBRUSH
	{
		public uint lbStyle; 
		public uint lbColor; 
		public uint lbHatch; 
	}

	/// <summary>
	/// 为Win32API函数GetDeviceCaps的第二个参数配备的枚举变量
	/// </summary>
	public enum enumDCConst
	{
		/// <summary>
		/// Device driver version
		/// </summary>
		DC_DRIVERVERSION = 0      ,   
		/// <summary>
		/// Device classification
		/// </summary>
		DC_TECHNOLOGY = 2         ,  
		/// <summary>
		/// Horizontal size in millimeters
		/// </summary>
		DC_HORZSIZE = 4           , 
		/// <summary>
		///  Vertical size in millimeters
		/// </summary>
		DC_VERTSIZE = 6           , 
		/// <summary>
		///  Horizontal width in pixels
		/// </summary>
		DC_HORZRES = 8            , 
		/// <summary>
		/// Vertical width in pixels
		/// </summary>
		DC_VERTRES = 10           , 
		/// <summary>
		/// Logical pixels/inch in X
		/// </summary>
		DC_LOGPIXELSX = 88        , 
		/// <summary>
		/// Logical pixels/inch in Y
		/// </summary>
		DC_LOGPIXELSY = 90        , 
		/// <summary>
		/// Number of planes
		/// </summary>
		DC_PLANES = 14            , 
		/// <summary>
		/// Number of brushes the device has
		/// </summary>
		DC_NUMBRUSHES = 16        , 
		/// <summary>
		/// Number of colors the device supports
		/// </summary>
		DC_NUMCOLORS = 24         , 
		/// <summary>
		/// Number of fonts the device has
		/// </summary>
		DC_NUMFONTS = 22          , 
		/// <summary>
		/// Number of pens the device has
		/// </summary>
		DC_NUMPENS = 18           , 
		/// <summary>
		/// Length of the X leg
		/// </summary>
		DC_ASPECTX = 40           , 
		/// <summary>
		/// Length of the hypotenuse
		/// </summary>
		DC_ASPECTXY = 44          , 
		/// <summary>
		/// Length of the Y leg
		/// </summary>
		DC_ASPECTY = 42           , 
		/// <summary>
		/// Size required for device descriptor
		/// </summary>
		DC_PDEVICESIZE = 26       , 
		/// <summary>
		/// Clipping capabilities
		/// </summary>
		DC_CLIPCAPS = 36          , 
		/// <summary>
		/// Number of entries in physical palette
		/// </summary>
		DC_SIZEPALETTE = 104      , 
		/// <summary>
		/// Number of reserved entries in palette
		/// </summary>
		DC_NUMRESERVED = 106      , 
		/// <summary>
		/// Actual color resolution
		/// </summary>
		DC_COLORRES = 108         ,  
		/// <summary>
		/// Physical Printable Area x margin
		/// </summary>
		DC_PHYSICALOFFSETX = 112  , 
		/// <summary>
		/// Physical Printable Area y margin
		/// </summary>
		DC_PHYSICALOFFSETY = 113  , 
		/// <summary>
		/// Physical Height in device units
		/// </summary>
		DC_PHYSICALHEIGHT = 111   , 
		/// <summary>
		/// Physical Width in device units
		/// </summary>
		DC_PHYSICALWIDTH = 110   , 
		/// <summary>
		/// Scaling factor x
		/// </summary>
		DC_SCALINGFACTORX = 114   , 
		/// <summary>
		/// Scaling factor y
		/// </summary>
		DC_SCALINGFACTORY = 115   , 
		DC_LISTEN_OUTSTANDING = 1 ,
		/// <summary>
		///  Curve capabilities
		/// </summary>
		DC_CURVECAPS = 28         , 
		/// <summary>
		/// Line capabilities
		/// </summary>
		DC_LINECAPS = 30          , 
		/// <summary>
		/// Polygonal capabilities
		/// </summary>
		DC_POLYGONALCAPS = 32     , 
		/// <summary>
		/// Text capabilities
		/// </summary>
		DC_TEXTCAPS = 34          , 
	}

	public class Gdi32
	{
		/// <summary>
		/// draws an elliptical arc
		/// </summary>
		/// <param name="hdc">handle to device context</param>
		/// <param name="LeftRect">x-coord of rectangle's upper-left corner</param>
		/// <param name="TopRect">y-coord of rectangle's upper-left corner</param>
		/// <param name="RightRect">x-coord of rectangle's lower-left corner</param>
		/// <param name="BottomRect">y-coord of rectangle's lower-left corner</param>
		/// <param name="XStartArc">x-coord of first radial ending point</param>
		/// <param name="YStartArc">y-coord of first radial ending point</param>
		/// <param name="XEndArc">x-coord of secend radial ending point</param>
		/// <param name="YEndArc">y-coord of secend radial ending point</param>
		/// <returns>ir tha arc is drawn , return nonzero else return zero</returns>
		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern bool Arc( int hdc , int LeftRect ,int TopRect , int RightRect , int BottomRect , int XStartArc , int YStartArc , int XEndArc , int YEndArc );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int CombineRgn(int dest, int src1, int src2, int flags);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int CreateRectRgnIndirect(ref RECT rect); 

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int GetClipBox(int hDC, ref RECT rectBox); 

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int CreatePen( int PenStyle , int Width , int Color );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int SelectClipRgn(int hDC, int hRgn); 

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int CreateBrushIndirect(ref LOGBRUSH brush); 

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern bool PatBlt(int hDC, int x, int y, int width, int height, uint flags); 

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int DeleteObject(int hObject);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern bool DeleteDC(int hDC);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int SelectObject(int hDC, int hObject);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int CreateCompatibleDC(int hDC);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int GdiFlush();

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int GetDeviceCaps(int hDC , int index );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int GetPixel ( int hDC , int x , int y );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int SetROP2( int hDC , int DrawMode );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern int GetROP2 ( int hDC );
		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern bool LineTo( int hDC , int X , int Y );

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern bool MoveToEx ( int hDC , int X , int Y , int lpPoint );

		/// <summary>
		/// 获得屏幕上指定点的象素
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static int GetScreenPixel ( int x , int y )
		{
			int hDC = User32.GetDC( 0 );
			int iReturn = GetPixel( hDC , x , y );
			User32.ReleaseDC( 0 , hDC );
			return iReturn ;
		}
		/// <summary>
		/// 获得屏幕上指定点的象素
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static int GetScreenPixel( System.Drawing.Point p )
		{
			int hDC = User32.GetDC( 0 );
			int iReturn = GetPixel( hDC , p.X  , p.Y  );
			User32.ReleaseDC( 0 , hDC );
			return iReturn ;
		}

	}//public class Gdi32

	public class User32
	{
		
		public static System.Drawing.Point MousePositionFromMSG( int hwnd ,uint lParam)
		{
			POINT pt = new POINT();
			pt.x  = (short)( lParam & 0x0000FFFFU);
			pt.y  = (short)(( lParam & 0xFFFF0000U) >> 16);
			User32.ClientToScreen( hwnd ,ref pt);
			return new System.Drawing.Point(pt.x , pt.y);
		}

		public static System.Drawing.Point MousePositionFromMSG(MSG msg)
		{
			POINT pt = new POINT();
			pt.x  = (short)((uint)msg.lParam & 0x0000FFFFU);
			pt.y  = (short)(((uint)msg.lParam & 0xFFFF0000U) >> 16);
			User32.ClientToScreen( msg.hwnd ,ref pt);
			return new System.Drawing.Point(pt.x , pt.y);
		}

		/// <summary>
		/// 根据Windows消息内容计算鼠标光标在屏幕中的位置
		/// </summary>
		/// <param name="intMessage">Windows消息编号</param>
		/// <param name="Hwnd">Windows消息中的窗体句柄</param>
		/// <param name="lParam">Windows消息的Param参数</param>
		/// <returns>鼠标光标在屏幕中的位置</returns>
		public static System.Drawing.Point MousePosFromMessage(int intMessage , int Hwnd, uint lParam)
		{
			bool bolClient = true;
			
			if (// 鼠标在非客户区的按键按下消息
				(intMessage  == (int)Msgs.WM_NCLBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_NCMBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_NCRBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_NCXBUTTONDOWN) ||
				// 鼠标在非客户区的按键松开消息
				(intMessage  == (int)Msgs.WM_NCLBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_NCMBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_NCRBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_NCXBUTTONUP) ||
				// 鼠标在非客户区的移动消息
				(intMessage  == (int)Msgs.WM_NCMOUSEMOVE) )
				bolClient = false;
			POINT pt = new POINT();
			pt.x  = (short)( lParam & 0x0000FFFFU);
			pt.y  = (short)(( lParam & 0xFFFF0000U) >> 16);
			if( bolClient )
				User32.ClientToScreen( Hwnd ,ref pt);
			return new System.Drawing.Point(pt.x , pt.y);
		}

		/// <summary>
		/// 判断该Windows消息是否是鼠标按键按下消息
		/// </summary>
		/// <param name="intMessage">消息编码</param>
		/// <returns>判断结果</returns>
		public static bool isMouseDownMessage(int intMessage)
		{
			// 鼠标在客户区的按钮按下消息
			if((intMessage   == (int)Msgs.WM_LBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_MBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_RBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_XBUTTONDOWN) )
				return true;
		 
			// 鼠标在非客户区的按键按下消息
			if ((intMessage  == (int)Msgs.WM_NCLBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_NCMBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_NCRBUTTONDOWN) ||
				(intMessage  == (int)Msgs.WM_NCXBUTTONDOWN))
				return true;
			return false;
		}
		/// <summary>
		/// 判断该Windows消息是否是鼠标移动消息
		/// </summary>
		/// <param name="intMessage">消息编码</param>
		/// <returns>判断结果</returns>
		public static bool isMouseMoveMessage(int intMessage)
		{
			if((intMessage  == (int)Msgs.WM_MOUSEMOVE) ||
				(intMessage  == (int)Msgs.WM_NCMOUSEMOVE)  )
				return true;
			return false;
		}
		/// <summary>
		/// 判断该Windows消息是否是鼠标按键松开消息
		/// </summary>
		/// <param name="intMessage">消息编码</param>
		/// <returns>判断结果</returns>
		public static bool isMouseUpMessage(int intMessage)
		{
			// 鼠标在客户区的按钮松开消息
			if((intMessage   == (int)Msgs.WM_LBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_MBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_RBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_XBUTTONUP) )
				return true;
		 
			// 鼠标在非客户区的按键松开消息
			if ((intMessage  == (int)Msgs.WM_NCLBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_NCMBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_NCRBUTTONUP) ||
				(intMessage  == (int)Msgs.WM_NCXBUTTONUP))
				return true;
			return false;
		}
		/// <summary>
		/// 判断Windows消息是否是键盘消息
		/// </summary>
		/// <param name="intMessage">消息编码</param>
		/// <returns>判断结果</returns>
		public static bool isKeyMessage(int intMessage)
		{
			if( intMessage == (int)Msgs.WM_KEYDOWN ||
				intMessage == (int)Msgs.WM_KEYUP ||
				intMessage == (int)Msgs.WM_CHAR )
				return true;
			return false;
		}


		/// <summary>
		/// 获得高8位字节数值
		/// </summary>
		/// <param name="intValue"></param>
		/// <returns></returns>
		public static int GetHeightOrder( uint intValue)
		{
			return (int)( (intValue & 0xFFFF0000U) >> 16 );
		}
		/// <summary>
		/// 获得低8位字节数值
		/// </summary>
		/// <param name="intValue"></param>
		/// <returns></returns>
		public static int GetLowOrder( uint intValue)
		{
			return (int) ( intValue & 0x0000FFFFU );
		}

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int GetWindowLong(int hWnd, int nIndex);
            
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetWindowLong(int hWnd, int nIndex, int newLong);
            
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int bRetValue, uint fWinINI);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool AnimateWindow(int hWnd, uint dwTime, uint dwFlags);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool InvalidateRect(int hWnd, ref RECT rect, bool erase);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int LoadCursor(int hInstance, uint cursor);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetCursor(int hCursor);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int GetFocus();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetFocus(int hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ReleaseCapture();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool WaitMessage();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool TranslateMessage(ref MSG msg);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool DispatchMessage(ref MSG msg);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PostMessage(int hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern uint SendMessage(int hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);
	
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int BeginPaint(int hWnd, ref PAINTSTRUCT ps);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool EndPaint(int hWnd, ref PAINTSTRUCT ps);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int GetDC(int hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int ReleaseDC(int hWnd, int hDC);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int ShowWindow(int hWnd, short cmdShow);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool MoveWindow(int hWnd, int x, int y, int width, int height, bool repaint);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetWindowPos(int hWnd, int hWndAfter, int X, int Y, int Width, int Height, uint flags);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool UpdateLayeredWindow(int hwnd, int hdcDst, ref POINT pptDst, ref SIZE psize, int hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetWindowRect(int hWnd, ref RECT rect);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ClientToScreen(int hWnd, ref POINT pt);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ScreenToClient(int hWnd, ref POINT pt);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool SetWindowRgn(int hWnd, int hRgn, bool redraw);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern ushort GetKeyState(int virtKey);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetInputState( );

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int GetParent(int hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool DrawFocusRect(int hWnd, ref RECT rect);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool HideCaret(int hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ShowCaret(int hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int InvertRect( int hdc , ref RECT vRect );

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int SetActiveWindow( int hWnd);
		
//		[DllImport("User32.dll", CharSet=CharSet.Auto)]
//		public static extern int SetFocus( int hWnd);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern int GetSystemMetrics( int nIndex );

		public static int InvertRect( int hdc , int x , int y , int width , int height)
		{
			RECT rect = new RECT();
			rect.left = x ;
			rect.top = y ;
			rect.right = x + width;
			rect.bottom = y + height ;
			return InvertRect( hdc , ref rect );
		}
	}

	/// <summary>
	/// 在Win32环境下处理输入法的模块
	/// </summary>
	public class Imm32
	{

		#region 声明处理输入法的Win32API函数及类型 ************************************************

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern int ImmCreateContext();

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImmDestroyContext(int hImc);

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImmSetCandidateWindow( int hImc , ref CandidateForm frm );

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImmSetStatusWindowPos( int hImc , ref POINT pos);

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern int ImmGetContext( int hwnd );

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImmReleaseContext( int hwnd , int hImc );

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImmGetOpenStatus(int hImc );

		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImmSetCompositionWindow( int hImc , ref CompositionForm frm );

	    
		public struct CandidateForm
		{
			public int		dwIndex ;
			public int		dwStyle ;
			public POINT	ptCurrentPos ;
			public RECT		rcArea;
		}

		public enum CandidateFormStyle
		{
			CFS_DEFAULT                    = 0x0000,
			CFS_RECT                       = 0x0001,
			CFS_POINT                      = 0x0002,
			CFS_FORCE_POSITION             = 0x0020,
			CFS_CANDIDATEPOS               = 0x0040,
			CFS_EXCLUDE                    = 0x0080
		}
		public struct CompositionForm
		{
			public int		Style ;
			public POINT	CurrentPos ;
			public RECT		Area;
		}


		#endregion


	  
		/// <summary>
		/// 判断指定的窗口中输入法是否打开
		/// </summary>
		/// <param name="hWnd">窗口句柄</param>
		/// <returns>输入法是否打开</returns>
		public static bool isImmOpen( int hWnd)
		{
			int hImc = ImmGetContext( hWnd );
			if( hImc == 0 )
				return false;
			bool bolReturn = ImmGetOpenStatus( hImc );
			ImmReleaseContext( hWnd , hImc );
			return bolReturn ;
		}
		
		/// <summary>
		/// 为指定的窗口设置输入法的位置
		/// </summary>
		/// <param name="hWnd">窗体句柄</param>
		/// <param name="x">输入法位置的X坐标</param>
		/// <param name="y">输入法位置的Y坐标</param>
		public static void SetImmPos( int hWnd , int x , int y )
		{
			bool bolReturn = false;
			uint iError = 0 ;
			int hImc = ImmGetContext( hWnd );
			if( hImc != 0 )
			{
				CompositionForm frm2 = new CompositionForm();
				frm2.CurrentPos.x = x ;
				frm2.CurrentPos.y = y ;
				frm2.Style = (int)CandidateFormStyle.CFS_POINT ;
				bolReturn = ImmSetCompositionWindow( hImc , ref frm2 );
				iError = Kernel32.GetLastError();
				ImmReleaseContext( hWnd , hImc );
			}
		}// void SetImmPos
	}// public class Imm32
	public class Kernel32
	{
		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern uint GetLastError( );
		[DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
		public static extern int FormatMessage( int Flags , int PSource , int MessageID , int LanguageID , char[] CharBuffer , int BufferSize , int Arguments);

		
		public const int   FORMAT_MESSAGE_ALLOCATE_BUFFER  = 0x00000100  ; 
		public const int   FORMAT_MESSAGE_IGNORE_INSERTS   = 0x00000200  ; 
		public const int   FORMAT_MESSAGE_FROM_STRING      = 0x00000400  ; 
		public const int   FORMAT_MESSAGE_FROM_HMODULE     = 0x00000800  ; 
		public const int   FORMAT_MESSAGE_FROM_SYSTEM      = 0x00001000  ; 
		public const int   FORMAT_MESSAGE_ARGUMENT_ARRAY   = 0x00002000  ; 
		public const int   FORMAT_MESSAGE_MAX_WIDTH_MASK   = 0x000000FF  ; 

		public static string FormatErrorMessage( int ErrorCode)
		{
			char[] chrBuffer = new char[2048];
			int intSize = FormatMessage( FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS , 0 , ErrorCode , 0 , chrBuffer , chrBuffer.Length , 0 );
			if( intSize > 1 )
			{
				string strMsg = new string( chrBuffer , 0 , intSize-1);
				return strMsg ;
			}
			return null;
		}
	}
 
	/// <summary>
	/// 调用Win32的Internet网络处理API来下载网络文件的类
	/// </summary>
	public class WinInet : System.IDisposable
	{
		#region 表示调用API时的标志位的常量群 *****************************************************
		
		//public const int   INTERNET_FLAG_RELOAD            = 0x80000000  ;// retrieve the original item
                                                    
		//                                                  
		// flags for InternetOpenUrl():                     
		//                                                  
                                                    
		public const int   INTERNET_FLAG_RAW_DATA          = 0x40000000  ;// FTP/gopher find: receive the item as raw (structured) data
		public const int   INTERNET_FLAG_EXISTING_CONNECT  = 0x20000000  ;// FTP: use existing InternetConnect handle for server if possible
                                                    
		//                                                  
		// flags for InternetOpen():                        
		//                                                  
                                                    
		public const int   INTERNET_FLAG_ASYNC             = 0x10000000  ;// this request is asynchronous (where supported)
                                                    
		//                                                  
		// protocol-specific flags:                         
		//                                                  
                                                    
		public const int   INTERNET_FLAG_PASSIVE           = 0x08000000  ;// used for FTP connections
                                                    
		//                                                  
		// additional cache flags                           
		//                                                  
                                                    
		public const int   INTERNET_FLAG_NO_CACHE_WRITE    = 0x04000000  ;// don't write this item to the cache
		public const int   INTERNET_FLAG_DONT_CACHE        = INTERNET_FLAG_NO_CACHE_WRITE;
		public const int   INTERNET_FLAG_MAKE_PERSISTENT   = 0x02000000  ;// make this item persistent in cache
		public const int   INTERNET_FLAG_FROM_CACHE        = 0x01000000  ;// use offline semantics
		public const int   INTERNET_FLAG_OFFLINE           = INTERNET_FLAG_FROM_CACHE;
                                                    
		//                                                  
		// additional flags                                 
		//                                                  
                                                    
		public const int   INTERNET_FLAG_SECURE            = 0x00800000  ;// use PCT/SSL if applicable (HTTP)
		public const int   INTERNET_FLAG_KEEP_CONNECTION   = 0x00400000  ;// use keep-alive semantics
		public const int   INTERNET_FLAG_NO_AUTO_REDIRECT  = 0x00200000  ;// don't handle redirections automatically
		public const int   INTERNET_FLAG_READ_PREFETCH     = 0x00100000  ;// do background read prefetch
		public const int   INTERNET_FLAG_NO_COOKIES        = 0x00080000  ;// no automatic cookie handling
		public const int   INTERNET_FLAG_NO_AUTH           = 0x00040000  ;// no automatic authentication handling
		public const int   INTERNET_FLAG_CACHE_IF_NET_FAIL = 0x00010000  ;// return cache file if net request fails

		//
		// Security Ignore Flags, Allow HttpOpenRequest to overide
		//  Secure Channel (SSL/PCT) failures of the following types.
		//

		public const int   INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP   = 0x00008000 ;// ex: https:// to http://
		public const int   INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS  = 0x00004000 ;// ex: http:// to https://
		public const int   INTERNET_FLAG_IGNORE_CERT_DATE_INVALID  = 0x00002000 ;// expired X509 Cert.
		public const int   INTERNET_FLAG_IGNORE_CERT_CN_INVALID    = 0x00001000 ;// bad common name in X509 Cert.

		//
		// more caching flags
		//

		public const int   INTERNET_FLAG_RESYNCHRONIZE      = 0x00000800  ;// asking wininet to update an item if it is newer
		public const int   INTERNET_FLAG_HYPERLINK          = 0x00000400  ;// asking wininet to do hyperlinking semantic which works right for scripts
		public const int   INTERNET_FLAG_NO_UI              = 0x00000200  ;// no cookie popup
		public const int   INTERNET_FLAG_PRAGMA_NOCACHE     = 0x00000100  ;// asking wininet to add "pragma: no-cache"
		public const int   INTERNET_FLAG_CACHE_ASYNC        = 0x00000080  ;// ok to perform lazy cache-write
		public const int   INTERNET_FLAG_FORMS_SUBMIT       = 0x00000040  ;// this is a forms submit
		public const int   INTERNET_FLAG_NEED_FILE          = 0x00000010  ;// need a file for this request
		public const int   INTERNET_FLAG_MUST_CACHE_REQUEST = INTERNET_FLAG_NEED_FILE;

		//
		// flags for FTP
		//
//
//		public const int   INTERNET_FLAG_TRANSFER_ASCII    = FTP_TRANSFER_TYPE_ASCII     ;// 0x00000001
//		public const int   INTERNET_FLAG_TRANSFER_BINARY   = FTP_TRANSFER_TYPE_BINARY    ;// 0x00000002

		#endregion
		#region 表示查询HTTP状态的标志位常量群 ****************************************************

		public const int  HTTP_QUERY_MIME_VERSION                 = 0  ;                          
		public const int  HTTP_QUERY_CONTENT_TYPE                 = 1  ;
		public const int  HTTP_QUERY_CONTENT_TRANSFER_ENCODING    = 2  ;
		public const int  HTTP_QUERY_CONTENT_ID                   = 3  ;
		public const int  HTTP_QUERY_CONTENT_DESCRIPTION          = 4  ;
		public const int  HTTP_QUERY_CONTENT_LENGTH               = 5  ;
		public const int  HTTP_QUERY_CONTENT_LANGUAGE             = 6  ;
		public const int  HTTP_QUERY_ALLOW                        = 7  ;
		public const int  HTTP_QUERY_PUBLIC                       = 8  ;
		public const int  HTTP_QUERY_DATE                         = 9  ;
		public const int  HTTP_QUERY_EXPIRES                      = 10 ;
		public const int  HTTP_QUERY_LAST_MODIFIED                = 11 ;
		public const int  HTTP_QUERY_MESSAGE_ID                   = 12 ;
		public const int  HTTP_QUERY_URI                          = 13 ;
		public const int  HTTP_QUERY_DERIVED_FROM                 = 14 ;
		public const int  HTTP_QUERY_COST                         = 15 ;
		public const int  HTTP_QUERY_LINK                         = 16 ;
		public const int  HTTP_QUERY_PRAGMA                       = 17 ;
		public const int  HTTP_QUERY_VERSION                      = 18 ;  // special: part of status line
		public const int  HTTP_QUERY_STATUS_CODE                  = 19 ;  // special: part of status line
		public const int  HTTP_QUERY_STATUS_TEXT                  = 20 ;  // special: part of status line
		public const int  HTTP_QUERY_RAW_HEADERS                  = 21 ;  // special: all headers as ASCIIZ
		public const int  HTTP_QUERY_RAW_HEADERS_CRLF             = 22 ;  // special: all headers
		public const int  HTTP_QUERY_CONNECTION                   = 23 ;
		public const int  HTTP_QUERY_ACCEPT                       = 24 ;
		public const int  HTTP_QUERY_ACCEPT_CHARSET               = 25 ;
		public const int  HTTP_QUERY_ACCEPT_ENCODING              = 26 ;
		public const int  HTTP_QUERY_ACCEPT_LANGUAGE              = 27 ;
		public const int  HTTP_QUERY_AUTHORIZATION                = 28 ;
		public const int  HTTP_QUERY_CONTENT_ENCODING             = 29 ;
		public const int  HTTP_QUERY_FORWARDED                    = 30 ;
		public const int  HTTP_QUERY_FROM                         = 31 ;
		public const int  HTTP_QUERY_IF_MODIFIED_SINCE            = 32 ;
		public const int  HTTP_QUERY_LOCATION                     = 33 ;
		public const int  HTTP_QUERY_ORIG_URI                     = 34 ;
		public const int  HTTP_QUERY_REFERER                      = 35 ;
		public const int  HTTP_QUERY_RETRY_AFTER                  = 36 ;
		public const int  HTTP_QUERY_SERVER                       = 37 ;
		public const int  HTTP_QUERY_TITLE                        = 38 ;
		public const int  HTTP_QUERY_USER_AGENT                   = 39 ;
		public const int  HTTP_QUERY_WWW_AUTHENTICATE             = 40 ;
		public const int  HTTP_QUERY_PROXY_AUTHENTICATE           = 41 ;
		public const int  HTTP_QUERY_ACCEPT_RANGES                = 42 ;
		public const int  HTTP_QUERY_SET_COOKIE                   = 43 ;
		public const int  HTTP_QUERY_COOKIE                       = 44 ;
		public const int  HTTP_QUERY_REQUEST_METHOD               = 45 ;  // special: GET/POST etc.
		public const int  HTTP_QUERY_REFRESH                      = 46 ;
		public const int  HTTP_QUERY_CONTENT_DISPOSITION          = 47 ;

		#endregion

		#region 标志HTTP状态的常量群 **************************************************************
		
		/// <summary>
		/// OK to continue with request
		/// </summary>
		public const int  HTTP_STATUS_CONTINUE            = 100 ;  
		/// <summary>
		/// server has switched protocols in upgrade header
		/// </summary>
		public const int  HTTP_STATUS_SWITCH_PROTOCOLS    = 101 ;  
		/// <summary>
		/// request completed
		/// </summary>
		public const int  HTTP_STATUS_OK                  = 200 ;  
		/// <summary>
		/// object created, reason = new URI
		/// </summary>
		public const int  HTTP_STATUS_CREATED             = 201 ;  
		/// <summary>
		/// async completion (TBS)
		/// </summary>
		public const int  HTTP_STATUS_ACCEPTED            = 202 ;  
		/// <summary>
		/// partial completion
		/// </summary>
		public const int  HTTP_STATUS_PARTIAL             = 203 ; 
		/// <summary>
		/// no info to return
		/// </summary>
		public const int  HTTP_STATUS_NO_CONTENT          = 204 ;
		/// <summary>
		/// request completed, but clear form
		/// </summary>
		public const int  HTTP_STATUS_RESET_CONTENT       = 205 ; 
		/// <summary>
		/// partial GET furfilled
		/// </summary>
		public const int  HTTP_STATUS_PARTIAL_CONTENT     = 206 ; 
		/// <summary>
		/// server couldn't decide what to return
		/// </summary>
		public const int  HTTP_STATUS_AMBIGUOUS           = 300 ; 
		/// <summary>
		/// object permanently moved
		/// </summary>
		public const int  HTTP_STATUS_MOVED               = 301 ; 
		/// <summary>
		/// object temporarily moved
		/// </summary>
		public const int  HTTP_STATUS_REDIRECT            = 302 ; 
		/// <summary>
		/// redirection w/ new access method
		/// </summary>
		public const int  HTTP_STATUS_REDIRECT_METHOD     = 303 ; 
		/// <summary>
		/// if-modified-since was not modified
		/// </summary>
		public const int  HTTP_STATUS_NOT_MODIFIED        = 304 ; 
		/// <summary>
		/// redirection to proxy, location header specifies proxy to use
		/// </summary>
		public const int  HTTP_STATUS_USE_PROXY           = 305 ; 
		/// <summary>
		/// HTTP/1.1: keep same verb
		/// </summary>
		public const int  HTTP_STATUS_REDIRECT_KEEP_VERB  = 307 ; 
		/// <summary>
		/// invalid syntax
		/// </summary>
		public const int  HTTP_STATUS_BAD_REQUEST         = 400 ; 
		/// <summary>
		/// access denied
		/// </summary>
		public const int  HTTP_STATUS_DENIED              = 401 ; 
		/// <summary>
		/// payment required
		/// </summary>
		public const int  HTTP_STATUS_PAYMENT_REQ         = 402 ; 
		/// <summary>
		/// request forbidden
		/// </summary>
		public const int  HTTP_STATUS_FORBIDDEN           = 403 ; 
		/// <summary>
		/// object not found
		/// </summary>
		public const int  HTTP_STATUS_NOT_FOUND           = 404 ; 
		/// <summary>
		/// method is not allowed
		/// </summary>
		public const int  HTTP_STATUS_BAD_METHOD          = 405 ; 
		/// <summary>
		/// no response acceptable to client found
		/// </summary>
		public const int  HTTP_STATUS_NONE_ACCEPTABLE     = 406 ; 
		/// <summary>
		/// proxy authentication required
		/// </summary>
		public const int  HTTP_STATUS_PROXY_AUTH_REQ      = 407 ; 
		/// <summary>
		/// server timed out waiting for request
		/// </summary>
		public const int  HTTP_STATUS_REQUEST_TIMEOUT     = 408 ; 
		/// <summary>
		/// user should resubmit with more info
		/// </summary>
		public const int  HTTP_STATUS_CONFLICT            = 409 ; 
		/// <summary>
		/// the resource is no longer available
		/// </summary>
		public const int  HTTP_STATUS_GONE                = 410 ; 
		/// <summary>
		/// the server refused to accept request w/o a length
		/// </summary>
		public const int  HTTP_STATUS_LENGTH_REQUIRED     = 411 ; 
		/// <summary>
		/// precondition given in request failed
		/// </summary>
		public const int  HTTP_STATUS_PRECOND_FAILED      = 412 ; 
		/// <summary>
		/// request entity was too large
		/// </summary>
		public const int  HTTP_STATUS_REQUEST_TOO_LARGE   = 413 ; 
		/// <summary>
		/// request URI too long
		/// </summary>
		public const int  HTTP_STATUS_URI_TOO_LONG        = 414 ; 
		/// <summary>
		/// unsupported media type
		/// </summary>
		public const int  HTTP_STATUS_UNSUPPORTED_MEDIA   = 415 ; 
		/// <summary>
		/// internal server error
		/// </summary>
		public const int  HTTP_STATUS_SERVER_ERROR        = 500 ; 
		/// <summary>
		/// required not supported
		/// </summary>
		public const int  HTTP_STATUS_NOT_SUPPORTED       = 501 ; 
		/// <summary>
		/// error response received from gateway
		/// </summary>
		public const int  HTTP_STATUS_BAD_GATEWAY         = 502 ; 
		/// <summary>
		/// temporarily overloaded
		/// </summary>
		public const int  HTTP_STATUS_SERVICE_UNAVAIL     = 503 ; 
		/// <summary>
		/// timed out waiting for gateway
		/// </summary>
		public const int  HTTP_STATUS_GATEWAY_TIMEOUT     = 504 ; 
		/// <summary>
		/// HTTP version not supported
		/// </summary>
		public const int  HTTP_STATUS_VERSION_NOT_SUP     = 505 ; 

		#endregion

		public const uint  INTERNET_FLAG_RELOAD            = 0x80000000;
		public const uint HTTP_ADDREQ_INDEX_MASK      =0x0000FFFF;
		public const uint HTTP_ADDREQ_FLAGS_MASK      =0xFFFF0000;
		/// <summary>
		/// the header will only be added if it doesn't already exist
		/// </summary>
		public const uint HTTP_ADDREQ_FLAG_ADD_IF_NEW =0x10000000;

		/// <summary>
		/// if HTTP_ADDREQ_FLAG_REPLACE is set but the header is
		/// not found then if this flag is set, the header is added anyway, so long as
		/// there is a valid header-value
		/// </summary>
		public const uint HTTP_ADDREQ_FLAG_ADD       = 0x20000000;
		public const uint HTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA       =0x40000000;
		public const uint HTTP_ADDREQ_FLAG_COALESCE_WITH_SEMICOLON   =0x01000000;
		/// <summary>
		/// HTTP_ADDREQ_FLAG_COALESCE - coalesce headers with same name. e.g.
		/// "Accept: text/*" and "Accept: audio/*" with this flag results in a single
		/// header: "Accept: text/*, audio/*"
		/// </summary>
		public const uint HTTP_ADDREQ_FLAG_COALESCE                  =HTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA;

		/// <summary>
		///  HTTP_ADDREQ_FLAG_REPLACE - replaces the specified header. Only one header can
		/// be supplied in the buffer. If the header to be replaced is not the first
		/// in a list of headers with the same name, then the relative index should be
		/// supplied in the low 8 bits of the dwModifiers parameter. If the header-value
		/// part is missing, then the header is removed
		/// </summary>
		public const uint HTTP_ADDREQ_FLAG_REPLACE    =0x80000000;

		#region 声明 wininet 的API ****************************************************************
		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int InternetOpen( string sAgent , int lAccessType ,string  sProxyName , string sProxyBypass , uint lFlags);

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int InternetOpenUrl( int hOpen , string sUrl , string sHeaders , int lLength , int lFlags , int lContext );

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int HttpOpenRequest( long hInternetSession , string sVerb , string sObjectName , string sVersion , string sReferer , char[] sAcceptTypes , long lFlags , int lContext );

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int InternetConnect( int iInternetSession , string sServerName , int iProxyProt , string sUserName , string sPassword , int iService , int lFlags , int iContext );

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int HttpSendRequest( int hHttpRequest ,  string sHeaders , int lHeadersLength ,byte[] sOptional , int lOptionalLength );

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int InternetReadFile(int hFile , byte[] sBuffer , int lNumbytesToRead , ref int lNumberOfBytesRead );

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int InternetCloseHandle( int iInet );

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern int HttpAddRequestHeaders( int iHttpRequest , string sHeaders , int lHeadersLength , uint lModifiers);

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern bool HttpQueryInfo(int hRequest , int iInfoLevel , byte[] Buffer ,ref int BufferLength ,int pwdIndex );

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern bool InternetSetCookie( string strURL , string strCookieName , string strCookieData);

		[DllImport("wininet.dll", CharSet=CharSet.Auto)]
		public static extern bool InternetGetLastResponseInfo(ref int ErrorCode , byte[] Buffer , ref int BufferLength );

		#endregion

		#region 定义静态函数 **********************************************************************

		public static string GetHttpErrorText()
		{
			byte[] bytBuffer = new byte[4028];
			int BufferLength = bytBuffer.Length ;
			int ErrorCode = 0 ;
			if( InternetGetLastResponseInfo(ref ErrorCode , bytBuffer, ref BufferLength ))
			{
				char[] txtChar = System.Text.Encoding.Unicode.GetChars(bytBuffer , 0 , BufferLength );
				string strText = new string( txtChar );
				return strText;
			}
			return null;
		}

		/// <summary>
		/// 获得HTTP错误文本信息
		/// </summary>
		/// <param name="intErrorCode">错误编码</param>
		/// <returns>错误文本信息</returns>
		public static string GetHttpErrorText( int intErrorCode)
		{
			string strText = null;
			switch( intErrorCode)
			{
				//case 12000: //INTERNET_ERROR_BASE
				case 12001: //ERROR_INTERNET_OUT_OF_HANDLES
					strText = "No more Internet handles can be allocated";
					break;
				case 12002: //ERROR_INTERNET_TIMEOUT
					strText = "The operation timed out";
					break;
				case 12003: //ERROR_INTERNET_EXTENDED_ERROR
					strText = "The server returned extended information";
					break;
				case 12004: //ERROR_INTERNET_INTERNAL_ERROR
					strText = "An internal error occurred in the Microsoft Internet extensions";
					break;
				case 12005: //ERROR_INTERNET_INVALID_URL
					strText = "The URL is invalid";
					break;
				case 12006: //ERROR_INTERNET_UNRECOGNIZED_SCHEME
					strText = "The URL does not use a recognized protocol";
					break;
				case 12007: //ERROR_INTERNET_NAME_NOT_RESOLVED
					strText = "The server name or address could not be resolved";
					break;
				case 12008: //ERROR_INTERNET_PROTOCOL_NOT_FOUND
					strText = "A protocol with the required capabilities was not found";
					break;
				case 12009: //ERROR_INTERNET_INVALID_OPTION
					strText = "The option is invalid";
					break;
				case 12010: //ERROR_INTERNET_BAD_OPTION_LENGTH
					strText = "The length is incorrect for the option type";
					break;
				case 12011: //ERROR_INTERNET_OPTION_NOT_SETTABLE
					strText = "The option value cannot be set";
					break;
				case 12012: //ERROR_INTERNET_SHUTDOWN
					strText = "Microsoft Internet Extension support has been shut down";
					break;
				case 12013: //ERROR_INTERNET_INCORRECT_USER_NAME
					strText = "The user name was not allowed";
					break;
				case 12014: //ERROR_INTERNET_INCORRECT_PASSWORD
					strText = "The password was not allowed";
					break;
				case 12015: //ERROR_INTERNET_LOGIN_FAILURE
					strText = "The login request was denied";
					break;
				case 12106: //ERROR_INTERNET_INVALID_OPERATION
					strText = "The requested operation is invalid";
					break;
				case 12017: //ERROR_INTERNET_OPERATION_CANCELLED
					strText = "The operation has been canceled";
					break;
				case 12018: //ERROR_INTERNET_INCORRECT_HANDLE_TYPE
					strText = "The supplied handle is the wrong type for the requested operation";
					break;
				case 12019: //ERROR_INTERNET_INCORRECT_HANDLE_STATE
					strText = "The handle is in the wrong state for the requested operation";
					break;
				case 12020: //ERROR_INTERNET_NOT_PROXY_REQUEST
					strText = "The request cannot be made on a Proxy session";
					break;
				case 12021: //ERROR_INTERNET_REGISTRY_VALUE_NOT_FOUND
					strText = "The registry value could not be found";
					break;
				case 12022: //ERROR_INTERNET_BAD_REGISTRY_PARAMETER
					strText = "The registry parameter is incorrect";
					break;
				case 12023: //ERROR_INTERNET_NO_DIRECT_ACCESS
					strText = "Direct Internet access is not available";
					break;
				case 12024: //ERROR_INTERNET_NO_CONTEXT
					strText = "No context value was supplied";
					break;
				case 12025: //ERROR_INTERNET_NO_CALLBACK
					strText = "No status callback was supplied";
					break;
				case 12026: //ERROR_INTERNET_REQUEST_PENDING
					strText = "There are outstanding requests";
					break;
				case 12027: //ERROR_INTERNET_INCORRECT_FORMAT
					strText = "The information format is incorrect";
					break;
				case 12028: //ERROR_INTERNET_ITEM_NOT_FOUND
					strText = "The requested item could not be found";
					break;
				case 12029: //ERROR_INTERNET_CANNOT_CONNECT
					strText = "A connection with the server could not be established";
					break;
				case 12030: //ERROR_INTERNET_CONNECTION_ABORTED
					strText = "The connection with the server was terminated abnormally";
					break;
				case 12031: //ERROR_INTERNET_CONNECTION_RESET
					strText = "The connection with the server was reset";
					break;
				case 12032: //ERROR_INTERNET_FORCE_RETRY
					strText = "The action must be retried";
					break;
				case 12033: //ERROR_INTERNET_INVALID_PROXY_REQUEST
					strText = "The proxy request is invalid";
					break;
				case 12034: //ERROR_INTERNET_NEED_UI
					strText = "User interaction is required to complete the operation";
					break;
				case 12036: //ERROR_INTERNET_HANDLE_EXISTS
					strText = "The handle already exists";
					break;
				case 12037: //ERROR_INTERNET_SEC_CERT_DATE_INVALID
					strText = "The date in the certificate is invalid or has expired";
					break;
				case 12038: //ERROR_INTERNET_SEC_CERT_CN_INVALID
					strText = "The host name in the certificate is invalid or does not match";
					break;
				case 12039: //ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR
					strText = "A redirect request will change a non-secure to a secure connection";
					break;
				case 12040: //ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR
					strText = "A redirect request will change a secure to a non-secure connection";
					break;
				case 12041: //ERROR_INTERNET_MIXED_SECURITY
					strText = "Mixed secure and non-secure connections";
					break;
				case 12042: //ERROR_INTERNET_CHG_POST_IS_NON_SECURE
					strText = "Changing to non-secure post";
					break;
				case 12043: //ERROR_INTERNET_POST_IS_NON_SECURE
					strText = "Data is being posted on a non-secure connection";
					break;
				case 12044: //ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED
					strText = "A certificate is required to complete client authentication";
					break;
				case 12045: //ERROR_INTERNET_INVALID_CA
					strText = "The certificate authority is invalid or incorrect";
					break;
				case 12046: //ERROR_INTERNET_CLIENT_AUTH_NOT_SETUP
					strText = "Client authentication has not been correctly installed";
					break;
				case 12047: //ERROR_INTERNET_ASYNC_THREAD_FAILED
					strText = "An error has occurred in a Wininet asynchronous thread. You may need to restart";
					break;
				case 12048: //ERROR_INTERNET_REDIRECT_SCHEME_CHANGE
					strText = "The protocol scheme has changed during a redirect operaiton";
					break;
				case 12049: //ERROR_INTERNET_DIALOG_PENDING
					strText = "There are operations awaiting retry";
					break;
				case 12050: //ERROR_INTERNET_RETRY_DIALOG
					strText = "The operation must be retried";
					break;
				case 12051: //ERROR_INTERNET_NO_NEW_CONTAINERS
					strText = "There are no new cache containers";
					break;
				case 12052: //ERROR_INTERNET_HTTPS_HTTP_SUBMIT_REDIR
					strText = "A security zone check indicates the operation must be retried";
					break;
				case 12157: //ERROR_INTERNET_SECURITY_CHANNEL_ERROR
					strText = "An error occurred in the secure channel support";
					break;
				case 12158: //ERROR_INTERNET_UNABLE_TO_CACHE_FILE
					strText = "The file could not be written to the cache";
					break;
				case 12159: //ERROR_INTERNET_TCPIP_NOT_INSTALLED
					strText = "The TCP/IP protocol is not installed properly";
					break;
				case 12163: //ERROR_INTERNET_DISCONNECTED
					strText = "The computer is disconnected from the network";
					break;
				case 12164: //ERROR_INTERNET_SERVER_UNREACHABLE
					strText = "The server is unreachable";
					break;
				case 12165: //ERROR_INTERNET_PROXY_SERVER_UNREACHABLE
					strText = "The proxy server is unreachable";
					break;
				case 12166: //ERROR_INTERNET_BAD_AUTO_PROXY_SCRIPT
					strText = "The proxy auto-configuration script is in error";
					break;
				case 12167: //ERROR_INTERNET_UNABLE_TO_DOWNLOAD_SCRIPT
					strText = "Could not download the proxy auto-configuration script file";
					break;
				case 12169: //ERROR_INTERNET_SEC_INVALID_CERT
					strText = "The supplied certificate is invalid";
					break;
				case 12170: //ERROR_INTERNET_SEC_CERT_REVOKED
					strText = "The supplied certificate has been revoked";
					break;
				case 12171: //ERROR_INTERNET_FAILED_DUETOSECURITYCHECK
					strText = "The Dialup failed because file sharing was turned on and a failure was requested if security check was needed";
					break;
				case 12110: //ERROR_FTP_TRANSFER_IN_PROGRESS
					strText = "There is already an FTP request in progress on this session";
					break;
				case 12111: //ERROR_FTP_DROPPED
					strText = "The FTP session was terminated";
					break;
				case 12112: //ERROR_FTP_NO_PASSIVE_MODE
					strText = "FTP Passive mode is not available";
					break;
				case 12130: //ERROR_GOPHER_PROTOCOL_ERROR
					strText = "A gopher protocol error occurred";
					break;
				case 12131: //ERROR_GOPHER_NOT_FILE
					strText = "The locator must be for a file";
					break;
				case 12132: //ERROR_GOPHER_DATA_ERROR
					strText = "An error was detected while parsing the data";
					break;
				case 12133: //ERROR_GOPHER_END_OF_DATA
					strText = "There is no more data";
					break;
				case 12134: //ERROR_GOPHER_INVALID_LOCATOR
					strText = "The locator is invalid";
					break;
				case 12135: //ERROR_GOPHER_INCORRECT_LOCATOR_TYPE
					strText = "The locator type is incorrect for this operation";
					break;
				case 12136: //ERROR_GOPHER_NOT_GOPHER_PLUS
					strText = "The request must be for a gopher+ item";
					break;
				case 12137: //ERROR_GOPHER_ATTRIBUTE_NOT_FOUND
					strText = "The requested attribute was not found";
					break;
				case 12138: //ERROR_GOPHER_UNKNOWN_LOCATOR
					strText = "The locator type is not recognized";
					break;
				case 12150: //ERROR_HTTP_HEADER_NOT_FOUND
					strText = "The requested header was not found";
					break;
				case 12151: //ERROR_HTTP_DOWNLEVEL_SERVER
					strText = "The server does not support the requested protocol level";
					break;
				case 12152: //ERROR_HTTP_INVALID_SERVER_RESPONSE
					strText = "The server returned an invalid or unrecognized response";
					break;
				case 12153: //ERROR_HTTP_INVALID_HEADER
					strText = "The supplied HTTP header is invalid";
					break;
				case 12154: //ERROR_HTTP_INVALID_QUERY_REQUEST
					strText = "The request for a HTTP header is invalid";
					break;
				case 12155: //ERROR_HTTP_HEADER_ALREADY_EXISTS
					strText = "The HTTP header already exists";
					break;
				case 12156: //ERROR_HTTP_REDIRECT_FAILED
					strText = "The HTTP redirect request failed";
					break;
				case 12160: //ERROR_HTTP_NOT_REDIRECTED
					strText = "The HTTP request was not redirected";
					break;
				case 12161: //ERROR_HTTP_COOKIE_NEEDS_CONFIRMATION
					strText = "A cookie from the server must be confirmed by the user";
					break;
				case 12162: //ERROR_HTTP_COOKIE_DECLINED
					strText = "A cookie from the server has been declined acceptance";
					break;
				case 12168: //ERROR_HTTP_REDIRECT_NEEDS_CONFIRMATION
					strText = "The HTTP redirect request must be confirmed by the user";
					break;
				default:
					strText = "not Support ErrorCode ";
					break;
			}
			return strText ;
		}//public static string GetHttpErrorText( int intErrorCode)

		/// <summary>
		/// 获得Http状态字符串
		/// </summary>
		/// <param name="InfoLevel">要查询的状态类别</param>
		/// <param name="hRequest">HTTP请求句柄</param>
		/// <returns>获得的HTTP状态字符串</returns>
		public static string GetHttpStatus( int InfoLevel , int hRequest)
		{
			byte[] bytStatus = new byte[1024];
			int iStatusSize = bytStatus.Length ;
			HttpQueryInfo(hRequest , InfoLevel , bytStatus , ref iStatusSize , 0 );
			System.Text.StringBuilder myStr = new System.Text.StringBuilder();
			for(int iCount = 0 ; iCount < iStatusSize ; iCount ++ )
				if( bytStatus[iCount] > 0 )
					myStr.Append((char) bytStatus[iCount]);
			string strData = myStr.ToString();
			return strData ;
		}

		/// <summary>
		/// 检查Http请求状态是否是成功的
		/// </summary>
		/// <param name="hRequest"></param>
		/// <returns></returns>
		public static bool IsHttpStatusOK( int hRequest)
		{
			return GetHttpStatus(HTTP_QUERY_STATUS_CODE, hRequest) == "200";
		}
		
		/// <summary>
		/// 向指定URL发送数据并接受页面返回的数据
		/// </summary>
		/// <param name="strURL">URL字符串</param>
		/// <param name="bytFormData">要发送的字节数据</param>
		/// <returns>接受到的数据</returns>
		public static byte[] GetBytesFromPost( string strURL , byte[] bytFormData )
		{
			//byte[] bythdrs = System.Text.Encoding.ASCII.GetBytes("Content-Type: application/x-www-form-urlencoded");
			string hdrs ="Content-Type: application/x-www-form-urlencoded";
			string accept = "Accept: */*";
			byte[] bytReturn = null;
			System.Uri myUrl = new Uri( strURL );
			//string strData = null;
			int hInet = InternetOpen( "htinc", 0 , null , null, INTERNET_FLAG_RELOAD );
			if( hInet != 0 )
			{
				int hConn = InternetConnect( hInet , myUrl.Host   , myUrl.Port , null,null,3,0,0);
				if( hConn != 0 )
				{
					char[] chrAccept = accept.ToCharArray();
					string strPath = myUrl.AbsolutePath + "\0";
					byte[] bytPath = System.Text.Encoding.GetEncoding(936).GetBytes( strPath );
					int hRequest = HttpOpenRequest( hConn , strPath , "POST\0" , null , null , null  , 0 , 1);
					if( hRequest != 0 )
					{
						int  intSend = HttpSendRequest( hRequest, hdrs , hdrs.Length  , bytFormData , bytFormData.Length);
						if( intSend != 0  && IsHttpStatusOK( hRequest )  )
						{
							System.IO.MemoryStream myBuffer = new System.IO.MemoryStream();
							byte[] bytBuf = new byte[2048];
							int lSize = 0 ;
							while(true)
							{
								int intRet = InternetReadFile( hRequest , bytBuf , 2048 , ref lSize );
								if( lSize > 0 && intRet != 0 )
									myBuffer.Write( bytBuf , 0 , lSize  );
								else
									break;
							}
							bytReturn = myBuffer.ToArray();
							myBuffer.Close();
						}
						InternetCloseHandle( hRequest );
					}
					InternetCloseHandle( hConn );
				}
				InternetCloseHandle( hInet );
			}
			return bytReturn ;
		}// byte[] GetBytesFromPost()

		#endregion

		#region 本类模块的内容 ********************************************************************

		private string	strURLString	= null;
		private int		hInternetHandle = 0 ;
		private string	strCookies		= null;
		private int		iContentLength	= 0 ;
		private int		iReserveLength	= 0 ;
		private System.Collections.Specialized.NameValueCollection myHeads = new System.Collections.Specialized.NameValueCollection();
		private System.Uri myUri		= null;
		
		/// <summary>
		/// 是否抛出异常
		/// </summary>
		public  bool  ThrowException	= true;

		/// <summary>
		/// 正在下载数据事件
		/// </summary>
		public event System.EventHandler Downloading = null;

		
		/// <summary>
		/// Http请求头数据
		/// </summary>
		public System.Collections.Specialized.NameValueCollection Heads
		{
			get{ return myHeads;}
		}

		/// <summary>
		/// 该对象使用的Uri
		/// </summary>
		public System.Uri Uri
		{
			get{ return myUri;}
		}

		/// <summary>
		/// 内部产生的Internet连接句柄
		/// </summary>
		public int InternetHandle
		{
			get{ return hInternetHandle ;}
		}
//
//		public string Cookies
//		{
//			get{ return strCookies;}
//			set{ strCookies = value;}
//		}
		/// <summary>
		/// 接受的数据长度
		/// </summary>
		public int ContentLength
		{
			get{ return iContentLength;}
		}

		/// <summary>
		/// 已接受的数据字节数
		/// </summary>
		public int ReserveLength
		{
			get{ return iReserveLength;}
		}

		/// <summary>
		/// URL字符串
		/// </summary>
		public string URLString
		{
			get{ return strURLString ;}
		}
		
		/// <summary>
		/// 设置Cookie值
		/// </summary>
		/// <param name="strName">名称</param>
		/// <param name="strValue">值</param>
		/// <returns>操作是否成功</returns>
		public bool SetCookie( string strName , string strValue)
		{
			return InternetSetCookie( myUri.AbsoluteUri , strName , strValue );
		}
		
		/// <summary>
		/// 打开对象,创建一个连接句柄
		/// </summary>
		/// <param name="strURL"></param>
		public void Open( string strURL )
		{
			this.Close();
			myUri = new Uri( strURL );
			hInternetHandle = InternetOpen( "htinc", 0 , null , null, INTERNET_FLAG_RELOAD );
			myHeads.Set("Host", myUri.Host + ":" + myUri.Port.ToString());
		}

		/// <summary>
		/// 关闭对象
		/// </summary>
		public void Close()
		{
			if( hInternetHandle!= 0 )
			{
				InternetCloseHandle( hInternetHandle);
				hInternetHandle = 0 ;
			}
		}

		/// <summary>
		/// 使用POST方法发送数据
		/// </summary>
		/// <param name="bytPostData">要发送的二进制数据</param>
		/// <returns>接受到的字节数据</returns>
		public byte[] PostData( byte[] bytPostData  )
		{
			bool bolCancel = false ;
			return PostData( bytPostData ,ref bolCancel );
		}

		/// <summary>
		/// 使用POST方法发送数据
		/// </summary>
		/// <param name="bytPostData">要发送的二进制数据</param>
		/// <param name="CancelFlag">取消操作标记变量</param>
		/// <returns>接受到的字节数据</returns>
		public byte[] PostData( byte[] bytPostData , ref bool CancelFlag )
		{
			iReserveLength			= 0 ;
			iContentLength			= 0 ;
			byte[] bytReturn		= null;
			Win32APIException ext	= null;
			if( CancelFlag ) 
				return null;
			if( hInternetHandle == 0 )
			{
				// 打开Ineternet连接对象
				hInternetHandle = InternetOpen( "htinc", 0 , null , null, INTERNET_FLAG_RELOAD );
			}
			if( CancelFlag ) return null;
			if( hInternetHandle != 0 )
			{
				// 连接服务器
				int hConn = InternetConnect( hInternetHandle , myUri.Host   , myUri.Port , null,null,3,0,0);
				if( CancelFlag )
				{
					InternetCloseHandle( hConn );
					return null;
				}
				if( hConn != 0 )
				{
					string strPath = myUri.AbsolutePath + "\0";
					// 打开页面
					int hRequest = HttpOpenRequest( hConn ,strPath , "POST\0" , null , null , null  , 0 , 1);
					if( CancelFlag )
					{
						InternetCloseHandle( hRequest );
						InternetCloseHandle( hConn );
						return null;
					}
					if( hRequest != 0 )
					{
						System.Text.StringBuilder myStr = new System.Text.StringBuilder();
						if( myHeads.Count > 0 )
						{
							for(int iCount = 0 ; iCount < myHeads.Count ; iCount ++ )
							{
								if( myStr.Length > 0 )
									myStr.Append("\r\n");
								myStr.Append(myHeads.Keys[iCount]);
								myStr.Append(": ");
								myStr.Append( myHeads[iCount]);
							}
						}
						string strHeaders = myStr.ToString();
						// 发送HTTP请求头
						HttpAddRequestHeaders( hRequest , strHeaders , strHeaders.Length  ,HTTP_ADDREQ_FLAG_REPLACE );
						// 发送数据
						int  intSend = HttpSendRequest( hRequest, null  ,  0 , bytPostData , bytPostData.Length);
						if( CancelFlag )
						{
							InternetCloseHandle( hRequest );
							InternetCloseHandle( hConn );
							return null;
						}
						if( intSend != 0  && IsHttpStatusOK( hRequest ) )
						{
							strCookies = GetHttpStatus( HTTP_QUERY_SET_COOKIE , hRequest );
							string strData =  GetHttpStatus(HTTP_QUERY_CONTENT_LENGTH,hRequest) ;
							try
							{
								if( strData != null && strData.Trim().Length > 0 )
									iContentLength = Convert.ToInt32( strData );
							}
							catch{}
							// 接受数据
							System.IO.MemoryStream myBuffer = new System.IO.MemoryStream();
							byte[] bytBuf = new byte[ 1024 * 16 ];
							int lSize = 0 ;
							while( CancelFlag == false )
							{
								int intRet = InternetReadFile( hRequest , bytBuf , bytBuf.Length , ref lSize );
								if( lSize > 0 && intRet != 0 )
								{
									myBuffer.Write( bytBuf , 0 , lSize  );
									iReserveLength += lSize ;
								}
								else
								{
									if( intRet != 0 && lSize == 0 )
										break;
									if( intRet == 0)
										break;
//									if( intRet == 0 )
//										continue;
//									else
//										break;
//									if( intRet != 0 && lSize == 0 )
//										break;
//									if( intRet == 0 )
//									{
//										break;
//									}
								}
								// 触发下载数据事件
								if( Downloading != null)
									Downloading( this , null);
							}
							bytReturn = myBuffer.ToArray();
							myBuffer.Close();
						}
						InternetCloseHandle( hRequest );
					}
					else
					{
						if( this.ThrowException )
						{
							ext = new Win32APIException("HttpOpenRequest", hRequest  );
							ext.ErrorMsg = GetHttpErrorText();
							InternetCloseHandle( hConn );
							throw ext ;
						}
					}
					InternetCloseHandle( hConn );
				}
				else 
				{
					if( this.ThrowException )
					{
						ext = new Win32APIException("InternetConnect" , hConn );
						ext.ErrorMsg = GetHttpErrorText();
						throw ext ;
					}
				}
			}
			else
			{ 
				if( this.ThrowException )
				{
					ext = new Win32APIException("InternetOpen" , hInternetHandle );
					ext.ErrorMsg = GetHttpErrorText();
					throw ext ;
				}
			}
			// if( hInternetHandle != 0 )
			return bytReturn ;
		}// byte[] PostData()

		#endregion

		#region IDisposable 成员 ******************************************************************

		public void Dispose()
		{
			if( hInternetHandle != 0)
			{
				InternetCloseHandle( hInternetHandle );
				hInternetHandle = 0 ;
			}
		}

		#endregion
	}// class WinInet

}//namespace Windows32
