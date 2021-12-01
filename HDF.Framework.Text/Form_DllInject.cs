using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinFormsApp1;

public partial class Form_DllInject : Form
{
    public Form_DllInject()
    {
        InitializeComponent();

        myTestDelegate = new WndProc(MyWndProc);
    }

    private void Form4_Load(object sender, EventArgs e)
    {












        //var process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "WeChat");
        //if (process == null)
        //    return;


        {

            var dllname = "E:\\项目\\WeChatRobot\\Release\\WeChatHelper.dll";
            int dlllength;
            dlllength = dllname.Length + 1;



            var process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "WeChat");
            if (process == null)
                return;


            var baseaddress = VirtualAllocEx(process.Handle, 0, dlllength, 4096, 4);   //申请内存空间
            if (baseaddress == 0) //返回0则操作失败，下面都是
            {
                MessageBox.Show("申请内存空间失败！！");
                Application.Exit();
            }

            var ok1 = WriteProcessMemory(process.Handle, baseaddress, dllname, dlllength, 0); //写内存
            if (ok1 == 0)
            {
                MessageBox.Show("写内存失败！！");
                Application.Exit();
            }


            //int module = GetModuleHandleA("Kernel32.dll");
            //int LoadLibraryAddress = GetProcAddress(module, "LoadLibraryA");
            //if (LoadLibraryAddress == 0)
            //{
            //    MessageBox.Show("查找LoadLibraryA地址失败！");
            //    return;
            //}

            var hack = GetProcAddress(GetModuleHandle("Kernel32.dll"), "LoadLibraryA"); //取得loadlibarary在kernek32.dll地址

            if (hack == IntPtr.Zero)
            {
                MessageBox.Show("无法取得函数的入口点！！");
                Application.Exit();
            }

            var yan = CreateRemoteThread(process.Handle, 0, 0, hack, baseaddress, 0, 0); //创建远程线程。

            if (yan == 0)
            {
                MessageBox.Show("创建远程线程失败！！");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("已成功注入dll!!");
            }





        }







        var wxform = FindWindow("TrayNotifyWnd", "微信");//通过getclassname获取微信类名

        prevWndFunc = new IntPtr(GetWindowLong(wxform, -4));


        var func = Marshal.GetFunctionPointerForDelegate(myTestDelegate);

        var r = SetWindowLongPtr(wxform, -4, func);


    }

    private WndProc myTestDelegate;

    private IntPtr prevWndFunc;


    IntPtr MyWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
    {
        IntPtr oldProc = default;
        return CallWindowProc(oldProc, hWnd, msg, wParam, lParam);
    }



    //获取窗口标题
    [DllImport("user32", SetLastError = true)]
    public static extern int GetWindowText(
        IntPtr hWnd,//窗口句柄
        StringBuilder lpString,//标题
        int nMaxCount //最大值
        );

    //获取类的名字
    [DllImport("user32.dll")]
    private static extern int GetClassName(
        IntPtr hWnd,//句柄
        StringBuilder lpString, //类名
        int nMaxCount //最大值
        );




    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);




    [DllImport("user32.dll")]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);






    [DllImport("user32.dll")]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


    [DllImport("Kernel32.dll")]
    public extern static int FormatMessage(int flag, ref IntPtr source, int msgid, int langid, ref string buf, int size, ref IntPtr args);



    public static string GetSysErrMsg(int errCode)
    {
        IntPtr tempptr = IntPtr.Zero;
        string msg = null;
        FormatMessage(0x1300, ref tempptr, errCode, 0, ref msg, 255, ref tempptr);
        return msg;
    }



    private static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
    {
        if (IntPtr.Size == 8)
        {
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }
        else
        {
            return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }
    }

    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
    private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll")]
    static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);




    [DllImport("kernel32.dll")] //声明API函数
    public static extern int VirtualAllocEx(IntPtr hwnd, int lpaddress, int size, int type, int tect);

    [DllImport("kernel32.dll")]
    public static extern int WriteProcessMemory(IntPtr hwnd, int baseaddress, string buffer, int nsize, int filewriten);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetProcAddress(IntPtr hwnd, string lpname);

    [DllImport("kernel32.dll")]
    public static extern int GetModuleHandleA(string name);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpLibFileNmae);

    [DllImport("kernel32.dll")]
    public static extern int CreateRemoteThread(IntPtr hwnd, int attrib, int size, IntPtr address, int par, int flags, int threadid);


}





public partial class Form5 : Form
{
    private readonly HookProc _mouseHook;
    private IntPtr _hMouseHook;

    public Form5()
    {
        _mouseHook = OnMouseHook;
        this.Load += OnLoad;
    }

    private void OnLoad(object sender, EventArgs e)
    {
        var hModule = GetModuleHandle(null);
        // 你可能会在网上搜索到下面注释掉的这种代码，但实际上已经过时了。
        //   下面代码在 .NET Core 3.x 以上可正常工作，在 .NET Framework 4.0 以下可正常工作。
        //   如果不满足此条件，你也可能可以正常工作，详情请阅读本文后续内容。
        // var hModule = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);

        _hMouseHook = SetWindowsHookEx(
            HookType.WH_MOUSE_LL,
            _mouseHook,
            hModule,
            0);
        if (_hMouseHook == IntPtr.Zero)
        {
            int errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode);
        }
    }

    private IntPtr OnMouseHook(int nCode, IntPtr wParam, IntPtr lParam)
    {
        // 在这里，你可以处理全局鼠标消息。
        return CallNextHookEx(new IntPtr(0), nCode, wParam, lParam);
    }





    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32", SetLastError = true)]
    static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("user32.dll")]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll")]
    static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

    public enum HookType : int
    {
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14
    }






}























