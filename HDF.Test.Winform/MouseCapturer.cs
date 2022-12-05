using HDF.Common.Windows;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HDF.Test.Winform;

public class MouseCapturer
{
    /// <summary>
    /// 无作为的初始化对象
    /// </summary>
    public MouseCapturer()
    {
    }
    /// <summary>
    /// 初始化对象并设置绑定的控件
    /// </summary>
    /// <param name="ctl">绑定的控件</param>
    public MouseCapturer(Control ctl)
    {
        BindControl = ctl;
    }


    /// <summary>
    /// 对象绑定的控件,若该控件有效则鼠标光标是用控件客户区坐标,否则采用屏幕坐标
    /// </summary>
    public Control BindControl { get; set; }








    /// <summary>
    /// 初始化时的鼠标开始位置
    /// </summary>
    public Point InitStartPosition { get; set; }

    /// <summary>
    /// 开始捕获时的鼠标光标的位置
    /// </summary>
    public Point StartPosition { get; private set; }

    /// <summary>
    /// 结束捕获时鼠标光标位置
    /// </summary>
    public Point EndPosition { get; private set; }

    /// <summary>
    /// 上一次处理时鼠标光标位置
    /// </summary>
    public Point LastPosition { get; private set; }

    /// <summary>
    /// 当前鼠标光标的位置
    /// </summary>
    public Point CurrentPosition { get; private set; }

    /// <summary>
    /// 整个操作中鼠标移动的距离,属性的Width值表示光标横向移动的距离,Height值表示纵向移动距离
    /// </summary>
    public Size MoveSize { get; set; }









    /// <summary>
    /// 整个操作中鼠标横向移动距离
    /// </summary>
    public int DX => this.EndPosition.X - this.StartPosition.X;

    /// <summary>
    /// 整个操作中鼠标纵向移动距离
    /// </summary>
    public int DY => this.EndPosition.Y - this.StartPosition.Y;

    /// <summary>
    /// 鼠标移动起点和终点组成的矩形区域
    /// </summary>
    public Rectangle CaptureRectagle
    {
        get
        {
            Rectangle rect = Rectangle.FromLTRB(StartPosition.X, StartPosition.Y, EndPosition.X, EndPosition.Y);
            rect.Location = this.FixPointForControl(rect.Location);
            return rect;
        }
    }


    /// <summary>
    /// 鼠标光标的活动范围
    /// </summary>
    public Rectangle ClipRectangle { get; set; }

    protected virtual CaptureMouseMoveEventArgs CreateArgs()
    {
        CaptureMouseMoveEventArgs e = new CaptureMouseMoveEventArgs(this, this.StartPosition, this.CurrentPosition);
        return e;
    }


    /// <summary>
    /// 鼠标捕获期间移动时的回调处理事件
    /// </summary>
    public event EventHandler<CaptureMouseMoveEventArgs> MouseMove = null;
    protected virtual void OnMouseMove() => MouseMove?.Invoke(this, this.CreateArgs());

    /// <summary>
    /// 鼠标捕获期间绘制可逆图形的回调处理事件
    /// </summary>
    public event EventHandler<CaptureMouseMoveEventArgs> Draw = null;
    protected virtual void OnDraw() => Draw?.Invoke(this, this.CreateArgs());



    /// <summary>
    /// 鼠标捕获期间绘制可逆图形的回调处理
    /// </summary>
    protected virtual void OnReversibleDrawCallback()
    {
        //Rectangle rect = RectangleCommon.GetRectangle(this.StartPosition, this.CurrentPosition);
        Rectangle rect = Rectangle.FromLTRB(StartPosition.X, StartPosition.Y, CurrentPosition.X, CurrentPosition.Y);

        switch (ReversibleShape)
        {
            case ReversibleShapeStyle.Line:
                ControlPaint.DrawReversibleLine(this.StartPosition, this.CurrentPosition, Color.Black);
                break;
            case ReversibleShapeStyle.Rectangle:
                ControlPaint.DrawReversibleFrame(rect, Color.SkyBlue, FrameStyle.Dashed);
                break;
            case ReversibleShapeStyle.FillRectangle:
                ControlPaint.FillReversibleRectangle(rect, Color.Black);
                break;
            case ReversibleShapeStyle.Custom:
                if (Draw != null)
                    Draw(this, null);
                break;
        }
    }
    /// <summary>
    /// 可逆图形样式
    /// </summary>
    public ReversibleShapeStyle ReversibleShape { get; set; }



    /// <summary>
    /// 对象额外数据
    /// </summary>
    public object Tag { get; set; }


    /// <summary>
    /// 重新设置内部数据
    /// </summary>
    public void Reset()
    {
        if (this.InitStartPosition.IsEmpty)
            this.StartPosition = this.CurMousePosition;
        else
            this.StartPosition = this.InitStartPosition;

        this.LastPosition = StartPosition;
        this.CurrentPosition = StartPosition;
        this.EndPosition = StartPosition;
        this.MoveSize = Size.Empty;
    }

    /// <summary>
    /// 捕获鼠标移动
    /// </summary>
    /// <returns>是否成功的完成了操作</returns>
    public bool CaptureMouseMove()
    {
        Reset();
        MSG msg = new MSG();

        //2019.07.18-hdf：为0是获取当前线程的消息，添加个句柄筛选更精确简便
        IntPtr intptr = GetForegroundWindow();

        int MinDragSize = SystemInformation.DragSize.Width;
        bool DragStartFlag = false;

        if (Control.MouseButtons == MouseButtons.None)
            return false;

        Point curPoint = this.CurMousePosition;

        // 开始Windows消息处理
        while (WaitMessage())
        {
            curPoint = this.CurMousePosition;

            if (Control.MouseButtons == MouseButtons.None)
                break;

            if (!PeekMessage(ref msg, intptr.ToInt32(), 0, 0, (int)PeekMessageFlags.PM_NOREMOVE))
                continue;

            // 若当前消息为鼠标按键松开消息则退出循环
            if (isMouseUpMessage(msg.message))
            {
                curPoint.X = (short)((int)msg.lParam);
                curPoint.Y = ((int)msg.lParam) >> 0x10;
                break;
            }

            if (isMouseMoveMessage(msg.message))
            {
                // 若为鼠标移动消息则进行处理
                Point p = new Point(
                    (short)((int)msg.lParam),
                    ((int)msg.lParam) >> 0x10);

                if (p.X != this.CurrentPosition.X || p.Y != this.CurrentPosition.Y)
                {
                    if (DragStartFlag)
                    {
                        this.OnDraw();
                    }
                    this.CurrentPosition = p;
                    if (DragStartFlag == false)
                    {
                        if (System.Math.Abs(this.CurrentPosition.X - this.StartPosition.X) >= MinDragSize
                            || System.Math.Abs(this.CurrentPosition.Y - this.StartPosition.Y) >= MinDragSize)
                            DragStartFlag = true;
                    }
                    if (DragStartFlag)
                    {
                        this.CurrentPosition = p;
                        this.OnDraw();
                        this.OnMouseMove();
                        this.LastPosition = this.CurrentPosition;
                    }
                }
            }
            GetMessage(ref msg, intptr.ToInt32(), 0, 0);
        }// while( User32.WaitMessage() )

        this.CurrentPosition = curPoint;

        if (DragStartFlag)
            this.OnDraw();

        this.EndPosition = this.CurrentPosition;
        this.MoveSize = new Size(EndPosition.X - StartPosition.X, EndPosition.Y - StartPosition.Y);
        if (MoveSize.Width == 0 && MoveSize.Height == 0)
            return false;
        return DragStartFlag;
    }

    public Size CurrentMoveSize
    {
        get
        {
            return new Size(
                CurrentPosition.X - StartPosition.X,
                CurrentPosition.Y - StartPosition.Y);
        }
    }

    private Point GetMousePosition(Point p)
    {
        if (BindControl != null)
            p = BindControl.PointToClient(p);
        return this.ClipRectangle.MoveToArea(p.X, p.Y);
    }
    private Point CurMousePosition
    {
        get
        {
            return GetMousePosition(Control.MousePosition);
        }

    }

    private Point FixPointForControl(Point p)
    {
        if (BindControl != null)
            p = BindControl.PointToClient(p);
        return p;
    }

    #region Win32API函数声明定义代码 **************************************

    /// <summary>
    /// 判断该Windows消息是否是鼠标移动消息
    /// </summary>
    /// <param name="intMessage">消息编码</param>
    /// <returns>判断结果</returns>
    private static bool isMouseMoveMessage(int intMessage)
    {
        return intMessage == 0x0200 || intMessage == 0x00A0;
    }

    /// <summary>
    /// 判断该Windows消息是否是鼠标按键松开消息
    /// </summary>
    /// <param name="intMessage">消息编码</param>
    /// <returns>判断结果</returns>
    private static bool isMouseUpMessage(int intMessage)
    {
        // 鼠标在客户区的按钮松开消息
        if (intMessage == 0x0202
            || intMessage == 0x0208
            || intMessage == 0x0205
            || intMessage == 0x020C)
            return true;

        // 鼠标在非客户区的按键松开消息
        if (intMessage == 0x00A2
            || intMessage == 0x00A8
            || intMessage == 0x00A5
            || intMessage == 0x00AC)
            return true;
        return false;
    }


    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static extern bool WaitMessage();

    [StructLayout(LayoutKind.Sequential)]
    private struct MSG
    {
        public IntPtr hwnd;
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public int pt_x;
        public int pt_y;
    }



    #endregion








}






/// <summary>
/// 绘制矩形的鼠标拖拽对象
/// </summary>
public class RectangleMouseCapturer : MouseCapturer
{
    /// <summary>
    /// 初始化对象
    /// </summary>
    public RectangleMouseCapturer()
    {
    }
    /// <summary>
    /// 初始化对象
    /// </summary>
    /// <param name="ctl">进行鼠标拖拽的控件对象</param>
    public RectangleMouseCapturer(Control ctl)
    {
        BindControl = ctl;
    }

    /// <summary>
    /// 拖拽类型
    /// </summary>
    public int DragStyle { get; set; }

    public Rectangle SourceRectangle { get; set; }

    public Rectangle DescRectangle { get; set; }

    public bool CustomAction { get; set; }


    public Rectangle UpdateRectangle(Rectangle rect, int dx, int dy)
    {
        // 中间
        if (DragStyle == -1)
            rect.Offset(dx, dy);
        // 左边
        if (DragStyle == 0 || DragStyle == 7 || DragStyle == 6)
        {
            rect.Offset(dx, 0);
            rect.Width = rect.Width - dx;
        }
        // 顶边
        if (DragStyle == 0 || DragStyle == 1 || DragStyle == 2)
        {
            rect.Offset(0, dy);
            rect.Height = rect.Height - dy;
        }
        // 右边
        if (DragStyle == 2 || DragStyle == 3 || DragStyle == 4)
        {
            rect.Width = rect.Width + dx;
        }
        // 底边
        if (DragStyle == 4 || DragStyle == 5 || DragStyle == 6)
        {
            rect.Height = rect.Height + dy;
        }
        return rect;
    }

    protected override void OnDraw()
    {
        base.OnDraw();
        if (CustomAction)
            return;

        ControlPaint.DrawReversibleFrame(DescRectangle, Color.Black, FrameStyle.Dashed);


        //ReversibleDrawer drawer = null;
        //if (BindControl != null)
        //    drawer = ReversibleDrawer.FromHwnd(BindControl.Handle);
        //else
        //    drawer = ReversibleDrawer.FromScreen();
        //drawer.DrawRectangle(DescRectangle);
        //drawer.Dispose();
    }
    public Rectangle CurrentRectangle
    {
        get
        {
            Rectangle rect = Rectangle.FromLTRB(StartPosition.X, StartPosition.Y, CurrentPosition.X, CurrentPosition.Y);
            return rect;
        }
    }

    protected override void OnMouseMove()
    {
        base.OnMouseMove();
        if (CustomAction)
            return;
        int dx = base.CurrentPosition.X - base.StartPosition.X;
        int dy = base.CurrentPosition.Y - base.StartPosition.Y;
        this.DescRectangle = UpdateRectangle(this.SourceRectangle, dx, dy);
    }
}




















#region class/enum



public enum PeekMessageFlags
{
    PM_NOREMOVE = 0,
    PM_REMOVE = 1,
    PM_NOYIELD = 2
}


/// <summary>
/// 可逆图形样式
/// </summary>
public enum ReversibleShapeStyle
{
    /// <summary>
    /// 可逆的直线
    /// </summary>
    Line,
    /// <summary>
    /// 可逆矩形边框
    /// </summary>
    Rectangle,
    /// <summary>
    /// 可逆的填充的矩形
    /// </summary>
    FillRectangle,
    /// <summary>
    /// 自定义
    /// </summary>
    Custom
}



/// <summary>
/// 鼠标拖拽事件消息对象
/// </summary>
public class CaptureMouseMoveEventArgs : EventArgs
{
    /// <summary>
    /// 初始化对象
    /// </summary>
    /// <param name="sender">消息发送者</param>
    /// <param name="sp">开始点坐标</param>
    /// <param name="cp">当前点坐标</param>
    public CaptureMouseMoveEventArgs(MouseCapturer sender, Point sp, Point cp)
    {
        this.Sender = sender;
        this.StartPosition = sp;
        this.CurrentPosition = cp;
    }


    /// <summary>
    /// 消息发送者
    /// </summary>
    public MouseCapturer Sender { get; }

    /// <summary>
    /// 鼠标开始拖拽的点坐标
    /// </summary>
    public Point StartPosition { get; }

    /// <summary>
    /// 鼠标当前点坐标
    /// </summary>
    public Point CurrentPosition { get; }


    public int DX => CurrentPosition.X - StartPosition.X;

    public int DY => CurrentPosition.Y - StartPosition.Y;


    /// <summary>
    /// 是否取消拖拽
    /// </summary>
    public bool Cancel { get; set; }
}

#endregion

