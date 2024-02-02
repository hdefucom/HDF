namespace HDF.Framework.Test;

internal class Winform嵌入读取进程窗口
{

    void test()
    {



        //// 启动Chrome浏览器进程
        //Process chromeProcess = Process.Start("chrome.exe", "http://www.example.com");

        //// 等待Chrome浏览器启动
        //chromeProcess.WaitForInputIdle();


        //var ps = Process.GetProcesses();

        //var list = ps.Select(p => p.ProcessName);

        //var p = ps.FirstOrDefault(p => p.ProcessName == "Test.Demo");

        //var chromeHandle = p?.MainWindowHandle
        //    ?? IntPtr.Zero;

        // 查找Chrome浏览器的窗口句柄
        IntPtr aa = FindWindow("Chrome_WidgetWin_1", null);

        // 将Chrome浏览器嵌入到WinForms窗口中
        if (aa != IntPtr.Zero)
        {
            SetParent(aa, default   /*外部窗口句柄*/);

            // 获取Notepad窗口的位置
            RECT notepadRect;
            GetWindowRect(aa, out notepadRect);

            // 调整Notepad窗口位置
            MoveWindow(aa, 0, 0, notepadRect.Right - notepadRect.Left, notepadRect.Bottom - notepadRect.Top, true);



        }
    }



    // 导入MoveWindow函数
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);



    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    // 定义RECT结构体
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }



    // 导入User32.dll中的一些函数
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll")]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    // 定义一些常量
    const int GWL_STYLE = -16;
    const int WS_CHILD = 0x40000000;
    const int WS_VISIBLE = 0x10000000;
    const int WS_OVERLAPPEDWINDOW = 0x00000000 | 0x00C00000 | 0x00080000 | 0x00040000 | 0x00020000 | 0x00010000;













}
