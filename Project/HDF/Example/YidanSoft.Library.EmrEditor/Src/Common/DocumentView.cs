using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Win32API;
using System.Runtime.InteropServices;
using System.Drawing;
///////////////////////序列化需要的引用
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Microsoft.Win32;
using YidanSoft.Library.EmrEditor.Src.Gui;
using YidanSoft.Library.EmrEditor.Src.Document;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
    /// <summary>
    /// 返回布尔值的没有参数的委托
    /// </summary>
    public delegate bool BoolNoParameterHandler();

    /// <summary>
    /// 绘制文档的处理模块
    /// </summary>
    /// <remarks>
    /// 本类用于在一个System.Drawing.Graph 绘图对象上绘制一个文档的视图
    /// 本类模块定义了一个绘制图形操作的例程
    /// </remarks>
    /// 
    [Serializable]
    public class DocumentView : System.IDisposable
    {
        /// <summary>
        /// 绘制命令列表
        /// </summary>
        public enum GDICommandConst
        {
            /// <summary>
            /// 清除内置GDI对象列表
            /// </summary>
            ClearGDIOjbects = 0,
            /// <summary>
            /// 创建刷子
            /// </summary>
            CreateBrush,
            /// <summary>
            /// 创建字体
            /// </summary>
            CreateFont,
            /// <summary>
            /// 创建画笔
            /// </summary>
            CreatePen,
            /// <summary>
            /// 绘制缩放框
            /// </summary>
            DrawExpendHandle,
            /// <summary>
            /// 绘制矩形
            /// </summary>
            DrawRectangle,
            /// <summary>
            /// 填充矩形
            /// </summary>
            FillRectangle,
            /// <summary>
            /// 绘制并填充矩形
            /// </summary>
            DrawFillRectangle,
            /// <summary>
            /// 绘制单行文本
            /// </summary>
            DrawSingleLine,
            /// <summary>
            /// 绘制单行文本2
            /// </summary>
            DrawSingleLine2,
            /// <summary>
            /// 绘制3角形
            /// </summary>
            DrawTriangle,
            /// <summary>
            /// 绘制选中区域
            /// </summary>
            DrawSelectionFrame,
            /// <summary>
            /// 绘制边框
            /// </summary>
            DrawBorder,
            /// <summary>
            /// 绘制字符
            /// </summary>
            DrawChar,
            /// <summary>
            /// 绘制字符串
            /// </summary>
            DrawString,
            /// <summary>
            /// 画线
            /// </summary>
            DrawLine,
            /// <summary>
            /// 画线2
            /// </summary>
            DrawLine2,
            /// <summary>
            /// 绘制段落标记
            /// </summary>
            DrawParagraphFlag,
            /// <summary>
            /// 绘制行标记
            /// </summary>
            DrawLineFlag,
            /// <summary>
            /// 绘制拖放矩形
            /// </summary>
            DrawDragRect,
            /// <summary>
            /// 绘制图象
            /// </summary>
            DrawImage,

            DrawFieldBackGround,
            DrawDeleteLine,
            DrawBackGround,
            /// <summary>
            /// 绘制高亮度背景
            /// </summary>
            DrawHighlightBackGround,
            /// <summary>
            /// 移动坐标原点
            /// </summary>
            TranslateTransform,
            /// <summary>
            /// 开始新的一页
            /// </summary>
            Page,
        }// enum GDICommandConst
        /*
                public void SwitchCmd()
                {
                    switch( cmd)
                    {
                        case GDICommandConst.ClearGDIOjbects		      : break;     
                        case GDICommandConst.CreateBrush                  : break;  
                        case GDICommandConst.CreateFont                   : break;  
                        case GDICommandConst.CreatePen                    : break;  
                        case GDICommandConst.DrawExpendHandle             : break;  
                        case GDICommandConst.DrawRectangle                : break;  
                        case GDICommandConst.FillRectangle                : break;  
                        case GDICommandConst.DrawFillRectangle            : break;  
                        case GDICommandConst.DrawSingleLine               : break;  
                        case GDICommandConst.DrawSingleLine2              : break;  
                        case GDICommandConst.DrawTriangle                 : break;  
                        case GDICommandConst.DrawSelectionFrame           : break;  
                        case GDICommandConst.DrawBorder                   : break;  
                        case GDICommandConst.DrawChar                     : break;  
                        case GDICommandConst.DrawString                   : break;  
                        case GDICommandConst.DrawLine                     : break;  
                        case GDICommandConst.DrawLine2                    : break;  
                        case GDICommandConst.DrawParagraphFlag            : break;  
                        case GDICommandConst.DrawLineFlag                 : break;  
                        case GDICommandConst.DrawDragRect                 : break;  
                        case GDICommandConst.DrawImage                    : break;  
                        case GDICommandConst.DrawFieldBackGround          : break;  
                        case GDICommandConst.DrawDeleteLine               : break;  
                        case GDICommandConst.DrawBackGround               : break;  
                        case GDICommandConst.DrawHighlightBackGround      : break;  
                        case GDICommandConst.TranslateTransform           : break;  
                        case GDICommandConst.Page                         : break;  
                        default:
                            break;
                    }
                }*/

        /// <summary>
        /// 默认的字体
        /// </summary>
        private System.Drawing.Font myDefaultFont = new System.Drawing.Font(ZYEditorControl.GetDefaultSettings(ZYTextConst.c_FontName), FontCommon.GetFontSizeByName(ZYEditorControl.GetDefaultSettings(ZYTextConst.c_FontSize)));
        /// <summary>
        /// 绘制文本和图形的默认的颜色，目前设置为标准Windows文本的颜色
        /// </summary>
        private System.Drawing.Color myDefaultColor = System.Drawing.SystemColors.WindowText;
        /// <summary>
        /// 绘制电子病历文档中数据域的背景色的画刷对象，目前设置为银灰色
        /// </summary>
        private System.Drawing.Brush myFieldBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Silver);
        /// <summary>
        /// 绘制电子病历文档中新增元素的背景色的画刷对象
        /// </summary>
        private System.Drawing.Brush myNewBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 238, 238));
        /// <summary>
        /// 绘制删除线使用的画笔对象，目前设置为红色
        /// </summary>
        private System.Drawing.Pen myDeletePen = new System.Drawing.Pen(System.Drawing.Color.Red);
        /// <summary>
        /// 绘制单行文本使用的格式化对象，目前该对象设置为单行，结尾带有省略号
        /// </summary>
        private System.Drawing.StringFormat mySingleLineFormat = new System.Drawing.StringFormat();
        /// <summary>
        /// 用于进行图形操作的绘制对象
        /// </summary>
        private System.Drawing.Graphics myGraph = null;
        private System.Drawing.Rectangle myViewRect = System.Drawing.Rectangle.Empty;
        /// <summary>
        /// 当前绘制操作使用的画刷对象
        /// </summary>
        private System.Drawing.Brush myCurrentBrush = null;
        /// <summary>
        /// 内部定义的字体列表
        /// </summary>
        private System.Collections.ArrayList myFontList = new System.Collections.ArrayList();

        /// <summary>
        /// 绘制文本使用的字体对象。
        /// </summary>
        private System.Drawing.Font myCurrentFont = null;

        /// <summary>
        /// 是否绘制全部的对象
        /// </summary>
        private bool bolDrawAll = false;
        /// <summary>
        /// 对象的左端位置
        /// </summary>
        private int intLeft = 0;
        /// <summary>
        /// 对象顶端位置
        /// </summary>
        private int intTop = 0;
        /// <summary>
        /// 对象宽度
        /// </summary>
        private int intWidth = 300;
        /// <summary>
        /// 对象高度
        /// </summary>
        private int intHeight = 100;

        private int intTabStep = 0;
        private int intContainerIndent = 5;
        /// <summary>
        /// 下拉式列表的下拉按钮大小
        /// </summary>
        public const int c_ComBoxSize = 16;
        /// <summary>
        /// 文本框收缩和展开控制框的大小,目前设为8
        /// </summary>
        public const int c_ExpendBoxSize = 8;
        /// <summary>
        /// 当前内容无效矩形
        /// </summary>
        private System.Drawing.Rectangle myInvalidlyRect = System.Drawing.Rectangle.Empty;

        //private CommandLine myCommandOutPut = null;


        /// <summary>
        /// 初始化对象,设置一些内部对象
        /// </summary>
        public DocumentView()
        {
            mySingleLineFormat.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            mySingleLineFormat.FormatFlags = System.Drawing.StringFormatFlags.NoWrap;
        }

        //public CommandLine CommandOutPut
        //{
        //    get { return myCommandOutPut; }
        //    set
        //    {
        //        myCommandOutPut = value;
        //        //				if( myCommandOutPut != null)
        //        //				{
        //        //					myCommandOutPut.TwipsPerPixelX = this.TwipsPerPixelX ;
        //        //					myCommandOutPut.TwipsPerPixelY = this.TwipsPerPixelY ;
        //        //				}
        //    }
        //}


        #region 管理GDI对象的函数群 ***************************************************************

        /// <summary>
        /// 所有的GDI对象列表
        /// </summary>
        private System.Collections.ArrayList myGDIObjects = new System.Collections.ArrayList();

        /// <summary>
        /// 清空GDI对象列表
        /// </summary>
        public void ClearGDIObjects()
        {
            foreach (System.IDisposable d in myGDIObjects)
                d.Dispose();
            myGDIObjects.Clear();
        }

        //public void WriteCreateCommand()
        //{
        //    if (myCommandOutPut != null)
        //    {
        //        for (int iCount = 0; iCount < myGDIObjects.Count; iCount++)
        //        {
        //            object obj = myGDIObjects[iCount];
        //            if (obj is System.Drawing.SolidBrush)
        //            {
        //                System.Drawing.SolidBrush myBrush = (System.Drawing.SolidBrush)obj;
        //                myCommandOutPut.CommandName = "createbrush";
        //                myCommandOutPut.SetColor(myBrush.Color);
        //                myCommandOutPut.Write();
        //            }
        //            else if (obj is System.Drawing.Pen)
        //            {
        //                System.Drawing.Pen myPen = (System.Drawing.Pen)obj;
        //                myCommandOutPut.CommandName = "createpen";
        //                myCommandOutPut.SetColor(myPen.Color);
        //                myCommandOutPut.SetWidth((int)myPen.Width);
        //                myCommandOutPut.Write();
        //            }
        //            else if (obj is System.Drawing.Font)
        //            {
        //                System.Drawing.Font myFont = (System.Drawing.Font)obj;
        //                myCommandOutPut.CommandName = "createfont";
        //                myCommandOutPut.SetValue("name", myFont.Name);
        //                myCommandOutPut.SetValue("size", myFont.Size.ToString());
        //                myCommandOutPut.SetBoolean("bold", myFont.Bold);
        //                myCommandOutPut.SetBoolean("italic", myFont.Italic);
        //                myCommandOutPut.SetBoolean("underline", myFont.Underline);
        //                myCommandOutPut.Write();
        //            }
        //        }// for
        //    }
        //}// void WriteCreateCommand()

        private int GetPenIndex(System.Drawing.Color c)
        {
            return GetPenIndex(c, 1);
        }
        private int GetPenIndex(System.Drawing.Color c, int vWidth)
        {
            int iCount = 0;
            foreach (object o in myGDIObjects)
            {
                if (o is System.Drawing.Pen)
                {
                    System.Drawing.Pen myPen = (System.Drawing.Pen)o;
                    if (myPen.Color == c && (int)myPen.Width == vWidth)
                    {
                        return iCount;
                    }
                }
                iCount++;
            }
            System.Drawing.Pen NewPen = new System.Drawing.Pen(c, vWidth);
            myGDIObjects.Add(NewPen);
            return myGDIObjects.Count - 1;
        }

        private int GetFontIndex(string FontName, float FontSize, bool Bold, bool Italic, bool UnderLine)
        {
            int iCount = 0;
            foreach (object o in myGDIObjects)
            {
                if (o is System.Drawing.Font)
                {
                    System.Drawing.Font myFont = (System.Drawing.Font)o;
                    if (myFont.Name == FontName
                        && myFont.Size == FontSize
                        && myFont.Bold == Bold
                        && myFont.Italic == Italic
                        && myFont.Underline == UnderLine)
                    {
                        return iCount;
                    }
                }
                iCount++;
            }// foreach

            if (FontSize == 0)
            {
                FontSize = 10.5f;
            }

            System.Drawing.Font NewFont = new System.Drawing.Font(FontName, FontSize, GetFontStyle(Bold, Italic, UnderLine));
            myGDIObjects.Add(NewFont);

            return myGDIObjects.Count - 1;
        }

        private int GetBrushIndex(System.Drawing.Color c)
        {
            int iCount = 0;
            foreach (object o in myGDIObjects)
            {
                if (o is System.Drawing.SolidBrush)
                {
                    System.Drawing.SolidBrush myBrush = (System.Drawing.SolidBrush)o;
                    if (myBrush.Color == c)
                    {
                        return iCount;
                    }
                }
                iCount++;
            }// foreach
            System.Drawing.SolidBrush NewBrush = new System.Drawing.SolidBrush(c);
            myGDIObjects.Add(NewBrush);
            return myGDIObjects.Count - 1;
        }

        /// <summary>
        /// 创建指定颜色的画刷对象
        /// </summary>
        /// <param name="c">颜色值</param>
        /// <returns>创建的画刷对象</returns>
        public System.Drawing.SolidBrush _CreateBrush(System.Drawing.Color c)
        {
            return (System.Drawing.SolidBrush)myGDIObjects[this.GetBrushIndex(c)];
        }// System.Drawing.SolidBrush _CreateBrush()


        /// <summary>
        /// 创建指定样式的字体对象
        /// </summary>
        /// <param name="FontName">字体名称</param>
        /// <param name="FontSize">字体大小</param>
        /// <param name="Bold">粗体</param>
        /// <param name="Italic">斜体</param>
        /// <param name="UnderLine">下划线</param>
        /// <returns>创建的字体对象</returns>
        public System.Drawing.Font _CreateFont(string FontName, float FontSize, bool Bold, bool Italic, bool UnderLine)
        {
            return myGDIObjects[this.GetFontIndex(FontName, FontSize, Bold, Italic, UnderLine)] as System.Drawing.Font;
        }// System.Drawing.Font _CreateFont

        /// <summary>
        /// 创建指定颜色和宽度的画笔对象
        /// </summary>
        /// <param name="c">画笔颜色</param>
        /// <param name="Width">画笔宽度</param>
        /// <returns>创建的画笔对象</returns>
        public System.Drawing.Pen _CreatePen(System.Drawing.Color c, int vWidth)
        {
            return (System.Drawing.Pen)myGDIObjects[this.GetPenIndex(c, vWidth)];
        }// _CreatePen

        /// <summary>
        /// 创建指定颜色的宽度为1的画笔对象
        /// </summary>
        /// <param name="c">画笔颜色</param>
        /// <returns>创建的画笔对象</returns>
        public System.Drawing.Pen _CreatePen(System.Drawing.Color c)
        {
            return _CreatePen(c, 1);
        }

        #endregion



        #region 绘制图形的例程群 ******************************************************************

        /// <summary>
        /// 绘制收缩点
        /// </summary>
        /// <remarks>绘制缩放点是模仿传统Windows标准树状列表控件中节点前的缩放控制点的外观
        /// 首先绘制缩放点的边框,然后若绘制展开的样式则在边框中绘制一个横线,若不是展开样式则在边框
        /// 中绘制一个横竖交叉线</remarks>
        /// <param name="x">对象的左端位置</param>
        /// <param name="y">对象的顶端位置</param>
        /// <param name="height">对象的高度</param>
        /// <param name="bolExpended">收缩点是否是展开的样式</param>
        public void DrawExpendHandle(int x, int y, int height, bool bolExpended)
        {
            //DrawExpendHandle( myGraph , x , y , bolExpended );
            if (myGraph != null)
            {
                System.Drawing.Rectangle BoxRect = GetExpendHandleRect(x, y, height);
                StaticDrawExpendHandle(myGraph, BoxRect, bolExpended);
            }
        }

        public static void StaticDrawExpendHandle(System.Drawing.Graphics g, System.Drawing.Rectangle BoxRect, bool bolExpended)
        {
            if (g != null)
            {
                g.FillRectangle(System.Drawing.SystemBrushes.Window, BoxRect);
                g.DrawRectangle(System.Drawing.SystemPens.WindowText, BoxRect);
                g.DrawLine
                    (System.Drawing.SystemPens.WindowText,
                    BoxRect.X + 2,
                    (int)(BoxRect.Y + BoxRect.Height / 2.0),
                    (int)BoxRect.X + BoxRect.Width - 2,
                    (int)(BoxRect.Y + BoxRect.Height / 2.0));
                if (!bolExpended)
                {
                    g.DrawLine
                        (System.Drawing.SystemPens.WindowText,
                        (int)(BoxRect.X + BoxRect.Width / 2.0),
                        BoxRect.Y + 2,
                        (int)(BoxRect.X + BoxRect.Width / 2.0),
                        BoxRect.Y + BoxRect.Height - 2);
                }
            }
        }


        /// <summary>
        /// 用指定颜色绘制一个矩形的边框
        /// </summary>
        /// <param name="vColor">边框颜色</param>
        /// <param name="vRect">矩形区域</param>
        public void DrawRectangle(System.Drawing.Color vColor, System.Drawing.Rectangle vRect)
        {
            if (vRect.Width >= 0 && vRect.Height >= 0)
            {
                int PenIndex = this.GetPenIndex(vColor);
                if (myGraph != null)
                {
                    myGraph.DrawRectangle((System.Drawing.Pen)myGDIObjects[PenIndex], vRect);
                    //					using(System.Drawing.Pen myPen = new System.Drawing.Pen( vColor ))
                    //					{
                    //						myGraph.DrawRectangle( myPen , vRect);
                    //					}
                }
            }
        }

        /// <summary>
        /// 使用指定的颜色填充一个矩形区域
        /// </summary>
        /// <param name="vColor">填充的颜色值</param>
        /// <param name="vRect">矩形区域</param>
        public void FillRectangle(System.Drawing.Color vColor, System.Drawing.Rectangle vRect)
        {
            if (vRect.Width >= 0 && vRect.Height >= 0)
            {
                int BrushIndex = this.GetBrushIndex(vColor);
                if (myGraph != null)
                {
                    myGraph.FillRectangle((System.Drawing.Brush)myGDIObjects[BrushIndex], vRect);
                }
            }
        }// void FillRectangle

        public void FillRectangle(System.Drawing.Color vColor, int vLeft, int vTop, int vWidth, int vHeight)
        {
            FillRectangle(vColor, new System.Drawing.Rectangle(vLeft, vTop, vWidth, vHeight));
        }

        /// <summary>
        /// 用指定的颜色填充一个矩形区域并用指定颜色绘制边框
        /// </summary>
        /// <param name="BorderColor">边框颜色</param>
        /// <param name="FillColor">填充颜色</param>
        /// <param name="vRect">矩形区域</param>
        public void DrawFillRectangle(System.Drawing.Color BorderColor, System.Drawing.Color FillColor, System.Drawing.Rectangle vRect)
        {
            if (vRect.Width >= 0 && vRect.Height >= 0)
            {
                int PenIndex = this.GetPenIndex(BorderColor);
                int BrushIndex = this.GetBrushIndex(FillColor);
                if (myGraph != null)
                {
                    if (vRect.Width > 0 && vRect.Height > 0)
                    {
                        myGraph.FillRectangle((System.Drawing.Brush)myGDIObjects[BrushIndex], vRect);
                    }
                    myGraph.DrawRectangle((System.Drawing.Pen)myGDIObjects[PenIndex], vRect);
                }
            }
        }

        /// <summary>
        /// 在指定位置使用指定颜色和默认字体绘制单行文本,若显示区域不够则在结尾绘制省略号
        /// </summary>
        /// <param name="strText">指定的文本</param>
        /// <param name="ForeColor">文本颜色</param>
        /// <param name="x">绘制文本的开始位置的X坐标</param>
        /// <param name="y">绘制文本的开始位置的Y坐标</param>
        /// <param name="width">绘制区域的宽度</param>
        public void DrawSingleLine(string strText, System.Drawing.Color ForeColor, int x, int y, int width)
        {
            int BrushIndex = this.GetBrushIndex(ForeColor);
            if (myGraph != null && width >= 0)
            {
                System.Drawing.RectangleF f = new System.Drawing.RectangleF((float)x, (float)y, (float)width, 100);
                myGraph.DrawString(strText, myDefaultFont, (System.Drawing.Brush)myGDIObjects[BrushIndex], f, mySingleLineFormat);
            }
        }

        private static System.Drawing.StringFormat mySingleLineFormat2 = null;
        /// <summary>
        /// 在指定位置使用指定颜色和默认字体绘制单行文本
        /// </summary>
        /// <param name="strText">指定的文本</param>
        /// <param name="ForeColor">文本颜色</param>
        /// <param name="x">绘制文本的开始位置的X坐标</param>
        /// <param name="y">绘制文本的开始位置的Y坐标</param>
        /// <param name="width">绘制区域的宽度</param>
        public void DrawSingleLine2(string strText, System.Drawing.Color ForeColor, int x, int y, int width)
        {
            if (myGraph != null && width >= 0)
            {
                if (mySingleLineFormat2 == null)
                {
                    mySingleLineFormat2 = new System.Drawing.StringFormat(System.Drawing.StringFormat.GenericTypographic);
                    mySingleLineFormat2.FormatFlags = System.Drawing.StringFormatFlags.NoWrap;
                    mySingleLineFormat2.Alignment = System.Drawing.StringAlignment.Center;
                }
                System.Drawing.RectangleF f = new System.Drawing.RectangleF((float)x, (float)y, (float)width, 100);
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(ForeColor))
                {
                    myGraph.DrawString(strText, myDefaultFont, myBrush, f, mySingleLineFormat2);
                }
            }
        }

        /// <summary>
        /// 用指定的颜色填充一个三角形区域并用指定颜色绘制边框
        /// </summary>
        /// <param name="x1">三角形第一个顶点的X绝对坐标</param>
        /// <param name="y1">三角形第一个顶点的Y绝对坐标</param>
        /// <param name="x2">三角形第二个顶点的X相对于第一个顶点的坐标</param>
        /// <param name="y2">三角形第二个顶点的Y相对于第一个顶点的坐标</param>
        /// <param name="x3">第三个顶点的相对X坐标</param>
        /// <param name="y3">第三个顶点的相对Y坐标</param>
        /// <param name="BorderColor">边框色</param>
        /// <param name="BackColor">背景色</param>
        public void DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, System.Drawing.Color BorderColor, System.Drawing.Color BackColor)
        {
            System.Drawing.Point[] p = new System.Drawing.Point[4];
            p[0].X = x1;
            p[0].Y = y1;
            p[1].X = x2 + x1;
            p[1].Y = y2 + y1;
            p[2].X = x3 + x1;
            p[2].Y = y3 + y1;
            p[3] = p[0];
            using (System.Drawing.Pen myPen = new System.Drawing.Pen(BorderColor))
            {
                myGraph.DrawLines(myPen, p);
            }
            using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(BackColor))
            {
                myGraph.FillPolygon(myBrush, p);
            }
        }

        /// <summary>
        /// 绘制选择区域
        /// </summary>
        /// <param name="myBounds"></param>
        public void DrawSelectionFrame(System.Drawing.Rectangle myBounds)
        {
            if (myGraph != null)
                System.Windows.Forms.ControlPaint.DrawSelectionFrame
                    (myGraph, false, myBounds, System.Drawing.Rectangle.Empty, System.Drawing.SystemColors.Highlight);
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="myRect"></param>
        /// <param name="leftColor"></param>
        /// <param name="leftWidth"></param>
        /// <param name="leftStyle"></param>
        /// <param name="topColor"></param>
        /// <param name="topWidth"></param>
        /// <param name="topStyle"></param>
        /// <param name="rightColor"></param>
        /// <param name="rightWidth"></param>
        /// <param name="rightStyle"></param>
        /// <param name="bottomColor"></param>
        /// <param name="bottomWidth"></param>
        /// <param name="bottomStyle"></param>
        public void DrawBorder(
            System.Drawing.Rectangle myRect,
            System.Drawing.Color leftColor,
            int leftWidth,
            System.Windows.Forms.ButtonBorderStyle leftStyle,
            System.Drawing.Color topColor,
            int topWidth,
            System.Windows.Forms.ButtonBorderStyle topStyle,
            System.Drawing.Color rightColor,
            int rightWidth,
            System.Windows.Forms.ButtonBorderStyle rightStyle,
            System.Drawing.Color bottomColor,
            int bottomWidth,
            System.Windows.Forms.ButtonBorderStyle bottomStyle)
        {
            System.Windows.Forms.ControlPaint.DrawBorder
                (myGraph, myRect,
                leftColor,
                leftWidth,
                leftStyle,
                topColor,
                topWidth,
                topStyle,
                rightColor,
                rightWidth,
                rightStyle,
                bottomColor,
                bottomWidth,
                bottomStyle);
        }

        /// <summary>
        /// 在指定位置绘制一个字符
        /// </summary>
        /// <param name="myChar"></param>
        /// <param name="myFont"></param>
        /// <param name="ForeColor"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawChar(char myChar, System.Drawing.Font myFont, System.Drawing.Color ForeColor, int x, int y)
        {
            int BrushIndex = this.GetBrushIndex(ForeColor);
            if (myGraph != null && myFont != null)
            {
                myGraph.DrawString(myChar.ToString(), myFont, (System.Drawing.Brush)myGDIObjects[BrushIndex], x, y, System.Drawing.StringFormat.GenericTypographic);
            }
        }

        /// <summary>
        /// 在指定位置绘制一个字符
        /// 2021-04-15：用于分页绘制切割的字符区域
        /// </summary>
        /// <param name="myChar"></param>
        /// <param name="myFont"></param>
        /// <param name="ForeColor"></param>
        /// <param name="rect"></param>
        /// <param name="format"></param>
        public void DrawChar(char myChar, System.Drawing.Font myFont, System.Drawing.Color ForeColor, Rectangle rect, StringFormat format)
        {
            int BrushIndex = this.GetBrushIndex(ForeColor);
            if (myGraph != null && myFont != null)
            {
                myGraph.DrawString(myChar.ToString(), myFont, (System.Drawing.Brush)myGDIObjects[BrushIndex], rect, format);

            }
        }

        /// <summary>
        /// 在指定的位置绘制一个带有圆圈的字符 Add By wwj 2012-05-31
        /// </summary>
        /// <param name="myChar"></param>
        /// <param name="myFont"></param>
        /// <param name="ForeColor"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="diameter">直径</param>
        public void DrawCircleChar(char myChar, System.Drawing.Font myFont, System.Drawing.Color ForeColor, int x, int y, int diameter)
        {
            int BrushIndex = this.GetBrushIndex(ForeColor);
            if (myGraph != null && myFont != null)
            {
                myGraph.DrawEllipse(Pens.Black, x, y, diameter, diameter);

                System.Drawing.SizeF CharSize = this.MeasureChar(myChar, myFont);
                myGraph.DrawString(myChar.ToString(), myFont, (System.Drawing.Brush)myGDIObjects[BrushIndex],
                    x + (diameter - CharSize.Width) / 2,
                    y + (diameter - CharSize.Height) / 2,
                    System.Drawing.StringFormat.GenericTypographic);
            }
        }

        /// <summary>
        /// 在指定位置绘制一个字符串
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="myFont"></param>
        /// <param name="ForeColor"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawString(string strText, System.Drawing.Font myFont, System.Drawing.Color ForeColor, int x, int y)
        {
            if (myFont == null)
                myFont = this.DefaultFont;
            int BrushIndex = this.GetBrushIndex(ForeColor);
            if (myGraph != null)
            {
                try
                {
                    myGraph.DrawString(strText, myFont, (System.Drawing.Brush)myGDIObjects[BrushIndex], x, y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void DrawString(string strText, int x, int y, int width, int height)
        {
            if (myGraph != null)
            {
                myGraph.DrawString(strText, this.DefaultFont, System.Drawing.SystemBrushes.WindowText, new System.Drawing.RectangleF(x, y, width, height));
            }
        }

        public void DrawLine(System.Drawing.Color ForeColor, int x, int y, int x2, int y2)
        {
            int PenIndex = this.GetPenIndex(ForeColor);
            if (myGraph != null)
            {
                myGraph.DrawLine((System.Drawing.Pen)myGDIObjects[PenIndex], x, y, x2, y2);
            }
        }

        public void DrawLine(System.Drawing.Pen myPen, int x, int y, int x2, int y2)
        {
            if (myGraph != null)
            {
                myGraph.DrawLine(myPen, x, y, x2, y2);
            }
        }

        //		/// <summary>
        //		/// 在指定位置绘制一个字符
        //		/// </summary>
        //		/// <param name="myChar">字符对象</param>
        //		/// <param name="x">显示点的X坐标</param>
        //		/// <param name="y">显示点的Y坐标</param>
        //		/// <param name="bolHightLight">是否显示高亮度文本,若为高亮度显示则绘制文本时使用Windows设置的高亮度文本颜色(一般为白色),否则使用标准文本颜色(一般为黑色)</param>
        //		public void DrawChar( char myChar , int x, int y , bool bolHightLight )
        //		{
        //			if( myCommandOutPut != null)
        //			{
        //				myCommandOutPut.CommandName = "drawchar";
        //				myCommandOutPut.SetPoint(x,y);
        //				myCommandOutPut.SetBoolean("heightlight",bolHightLight);
        //				myCommandOutPut.Write();
        //			}
        //			if( myGraph != null && myCurrentFont != null)
        //			{
        //				myGraph.DrawString
        //					( myChar.ToString(), 
        //					myCurrentFont , 
        //					(bolHightLight? System.Drawing.SystemBrushes.HighlightText: System.Drawing.SystemBrushes.WindowText ),
        //					x,
        //					y, 
        //					System.Drawing.StringFormat.GenericTypographic );
        //			}
        //		}

        #region 画回车符(包含软回车符,下箭头. 硬回车符,拐角箭头)
        /// <summary>
        /// 用本对象的DrawParagraphFlag函数绘制的段落标记的宽度
        /// </summary>
        public const int ParaGraphFlagWidth = 11;
        /// <summary>
        /// 在指定位置绘制段落标记,本函数模仿绘制 MS Word 文本编辑器中的段落标记(直接Enter的硬回车)
        /// </summary>
        /// <param name="x">段落标记左端位置</param>
        /// <param name="y">段落标记底端位置</param>
        public void DrawParagraphFlag(int x, int y, double rate)
        {
            if (myGraph != null)
            {
                int[] iPos =
					{
						0,-3 ,	3,0, //  / 0,-3 ,	2,-1, 
						0,-3 ,	3,-6, //  \ 0,-3 ,	2,-5,
						3,0,	3,-6, //   | 2,-1,	2,-5, 不画这个竖线
						3,-3,	7,-3, //  --- 0,-3,	5,-3,
						7,-3,	8,-4, //      /5,-3,	6,-4,
						8,-4,	8,-8  //       |
					};
                for (int iCount = 0; iCount < iPos.Length; iCount++)
                {
                    iPos[iCount] = (int)(iPos[iCount] * rate);
                }




                System.Drawing.Pen myPen = System.Drawing.SystemPens.ControlDark;
                for (int iCount = 0; iCount < iPos.Length; iCount += 4)
                    myGraph.DrawLine(myPen, x + iPos[iCount], y + iPos[iCount + 1], x + iPos[iCount + 2], y + iPos[iCount + 3]);

                #region bwy:再画实心三角形
                PointF[] p = { new PointF(iPos[0] + x, iPos[1] + y), new PointF(iPos[2] + x, iPos[3] + y), new PointF(iPos[6] + x, iPos[7] + y) };
                SolidBrush brush = new SolidBrush(Color.LightGray);
                myGraph.FillPolygon(brush, p);

                #endregion bwy:
            }
        }


        /// <summary>
        /// 用本对象DrawLineFlag绘制的行标记的宽度
        /// </summary>
        public const int LineFlagWidth = 11;

        /// <summary>
        /// 在指定的位置绘制行标记,本函数模仿绘制 MS Word 文本编辑器中的行标记(Ctl+Enter的软回车)
        /// </summary>
        /// <param name="x">行标记的左端位置</param>
        /// <param name="y">行标记的底端位置</param>
        public void DrawLineFlag(int x, int y, double rate)
        {
            if (myGraph != null)
            {
                int[] iPos =
					{
						0,-2,	2,0,	//   \
						0,-2,	4,-2,	//	  -
						2,0,	4,-2,	//	   /
						2,0,	2,-7	//	  |
					};
                for (int iCount = 0; iCount < iPos.Length; iCount++)
                {
                    iPos[iCount] = (int)(iPos[iCount] * rate);
                }
                System.Drawing.Pen myPen = System.Drawing.SystemPens.ControlDark;
                for (int iCount = 0; iCount < iPos.Length; iCount += 4)
                    myGraph.DrawLine(myPen, x + iPos[iCount], y + iPos[iCount + 1] - 2, x + iPos[iCount + 2], y + iPos[iCount + 3] - 2);
            }
        }
        #endregion

        /// <summary>
        /// 绘制拖拽矩形,本函数根据主矩形区域计算8个拖拽矩形区域并用指定的颜色填充和绘制边框,本函数不绘制主矩形区域
        /// </summary>
        /// <param name="myRect">主矩形区域</param>
        /// <param name="DragRectSize">拖拽矩形区域的大小</param>
        /// <param name="InnerDragRect">是否是内嵌的拖拽矩形</param>
        /// <param name="BorderColor">拖拽矩形的边框颜色</param>
        /// <param name="BackColor">拖拽矩形的填充颜色</param>
        public void DrawDragRect(System.Drawing.Rectangle myRect, int DragRectSize, bool InnerDragRect, System.Drawing.Color BorderColor, System.Drawing.Color BackColor)
        {

            if (myGraph != null)
            {
                System.Drawing.Rectangle[] DragRects = GetDragRects(myRect, DragRectSize, InnerDragRect);
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(BackColor))
                {
                    myGraph.FillRectangles(myBrush, DragRects);
                }
                using (System.Drawing.Pen myPen = new System.Drawing.Pen(BorderColor))
                {
                    myGraph.DrawRectangles(myPen, DragRects);
                }
            }
        }// void DrawDragRect()

        /// <summary>
        /// 在指定区域无缩放的绘制指定图象
        /// </summary>
        /// <param name="myImage">图象对象</param>
        /// <param name="x">绘制区域的左端位置</param>
        /// <param name="y">绘制区域的顶端位置</param>
        /// <param name="width">绘图区域的宽度</param>
        /// <param name="height">绘图区域的高度</param>
        public void DrawImage(System.Drawing.Image myImage, int x, int y, int width, int height)
        {
            if (myImage != null)
            {
                if (myGraph != null)
                    myGraph.DrawImage(myImage, x, y, width, height);
            }
        }


        /// <summary>
        /// 绘制结构化数据区域背景
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawFieldBackGround(int x, int y, int width, int height)
        {
            if (myGraph != null && myFieldBrush != null)
            {
                myGraph.FillRectangle(myFieldBrush, x, y, width, height);
            }
        }
        //		/// <summary>
        //		/// 绘制新元素的背景
        //		/// </summary>
        //		/// <param name="x"></param>
        //		/// <param name="y"></param>
        //		/// <param name="width"></param>
        //		/// <param name="height"></param>
        //		public void DrawNewBackGround( int x , int y , int width , int height)
        //		{
        //			if( myGraph != null && myNewBrush != null)
        //			{
        //				myGraph.FillRectangle( myNewBrush , x , y , width , height );
        //			}
        //		}

        double siny(double x)
        {
            return Math.Sin(x);
        }
        /// <summary>
        /// 画波浪线 
        /// TODO: 完善画波浪线 DocumentView
        /// </summary>
        public void DrawWavyLine(int x, int y, int width, int height)
        {
            if (myGraph != null)
            {
                for (int i = 0; i < width; i++)
                {
                    double xx = i * Math.PI / 3;//一个PI周期用五个点坐标表示
                    int j = (int)(siny(xx) * 2);//拉伸Y坐标为2倍
                    myGraph.FillRectangle(Brushes.Red, (i + x), (j + y + height * 2), 1, 1);//画点
                }
            }
        }

        /// <summary>
        /// 画双下划线 
        /// TODO: 完善画双下划线 DocumentView
        /// </summary>
        public void DrawDoubleUnderLine(int x, int y, int width, int height)
        {
            if (null != myGraph)
            {
                myGraph.DrawLine(new Pen(Color.Red, (float)1.5), x, y + height,
                   x + width, y + height);
                myGraph.DrawLine(new Pen(Color.Red, (float)1.5), x, y + (int)(height * 0.8),
                    x + width, y + (int)(height * 0.8));
            }
        }

        /// <summary>
        /// mfb 在指定区域绘制删除线
        /// </summary>
        /// <param name="x">绘制区域的左端位置</param>
        /// <param name="y">绘制区域的顶端位置</param>
        /// <param name="width">绘制区域的宽度</param>
        /// <param name="height">绘制区域的高度</param>
        /// <param name="linenum">删除线的个数 1:一行删除线 2:两行删除线,其他:不进行绘制</param>
        public void DrawDeleteLine(int x, int y, int width, int height, int linenum)
        {
            if (myGraph != null && myDeletePen != null)
            {
                if (linenum == 1)
                {
                    myGraph.DrawLine
                        (myDeletePen,
                        x,
                        y + (int)(height * 0.5),
                        x + width,
                        y + (int)(height * 0.5));
                }
                if (linenum == 2)
                {
                    myGraph.DrawLine
                        (myDeletePen,
                        x,
                        y + (int)(height * 0.3),
                        x + width,
                        y + (int)(height * 0.3));
                    myGraph.DrawLine
                        (myDeletePen,
                        x,
                        y + (int)(height * 0.6),
                        x + width,
                        y + (int)(height * 0.6));
                }
            }
        }
        /// <summary>
        /// 绘制一般元素的背景
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawBackGround(int x, int y, int width, int height)
        {
            if (myGraph != null)
            {
                myGraph.FillRectangle(System.Drawing.SystemBrushes.Window, x, y, width, height);
            }
        }



        //		/// <summary>
        //		/// 在指定区域绘制高亮度显示区域的背景
        //		/// </summary>
        //		/// <remarks>本函数使用Windows设置的高亮度显示背景色填充指定区域,该颜色一般为深蓝色</remarks>
        //		/// <param name="x">绘制区域的左端位置</param>
        //		/// <param name="y">绘制区域的顶端位置</param>
        //		/// <param name="width">绘制区域的宽度</param>
        //		/// <param name="height">绘制区域的高度</param>
        //		public void DrawHighlightBackGround( int x, int y , int width , int height)
        //		{
        //			if( myCommandOutPut != null)
        //			{
        //				myCommandOutPut.CommandName = "drawhightlightback";
        //				myCommandOutPut.SetRectangle(x,y,width , height);
        //				myCommandOutPut.Write();
        //			}
        //			if( myGraph != null)
        //			{
        //				int dx = (int) myGraph.Transform.OffsetX ;
        //				int dy = (int) myGraph.Transform.OffsetY ;
        //				int hDC = (int)myGraph.GetHdc();
        //				Windows32.User32.InvertRect( hDC ,dx + x , dy +  y , width , height );
        //				myGraph.ReleaseHdc( new  System.IntPtr(hDC) );
        //				//myGraph.FillRectangle( System.Drawing.SystemBrushes.Highlight , x, y , width , height);
        //			}
        //		}

        /// <summary>
        /// 将指定区域进行反色处理
        /// </summary>
        /// <param name="x">反色处理区域的左端位置</param>
        /// <param name="y">反色处理区域的顶端位置</param>
        /// <param name="width">反色处理区域的宽度</param>
        /// <param name="height">反色处理区域的高度</param>
        public void InvertRect(int x, int y, int width, int height)
        {

            throw new NotImplementedException("documnetview InvertRect(int x, int y, int width, int height) 还没有实现");
            //if (myGraph != null)
            //{
            //    int dx = (int)myGraph.Transform.OffsetX;
            //    int dy = (int)myGraph.Transform.OffsetY;
            //    int hDC = (int)myGraph.GetHdc();
            //    User32.InvertRect(hDC, dx + x, dy + y, width, height);
            //    myGraph.ReleaseHdc(new System.IntPtr(hDC));
            //    //myGraph.FillRectangle( System.Drawing.SystemBrushes.Highlight , x, y , width , height);
            //}
        }

        /// <summary>
        /// 将指定区域进行反色处理
        /// </summary>
        /// <param name="rect">指定的反色处理区域</param>
        public void InvertRect(System.Drawing.Rectangle rect)
        {
            InvertRect(rect.Left, rect.Top, rect.Width, rect.Height);
        }

        //		public void DrawHighlightBackGround( System.Drawing.Rectangle rect)
        //		{
        //			DrawHighlightBackGround( rect.Left , rect.Top , rect.Width , rect.Height );
        //		}



        /// <summary>
        /// 在一个图片上绘制所有的图形并返回该图片
        /// </summary>
        /// <remarks>本函数首先试图调用CalcuteSize委托来计算需要绘制区域的大小,若该委托计算失败则函数立即返回空引用,
        /// 若该委托不存在则设置对象当前的大小,然后内部建立一个指定大小的BMP图片对象,设置内部的图形绘制对象,然后
        /// 调用DrawAllHandler委托来绘制图形,然后本函数返回该BMP图片对象</remarks>
        /// <param name="CalcuteSize">用于计算视图区域的函数委托，可以为空</param>
        /// <param name="DrawAllHandler">用于绘制所有图象的函数委托,不得为空</param>
        /// <param name="intImgWidth">指定的输出图像的宽度,若小于等于0则自动设置图像宽度</param>
        /// <param name="intImgHeight">指定的输出图像的高度,若小于等于0则自动设置图像宽度</param>
        /// <returns>获得的图片对象，若发生错误则返回空引用</returns>
        public System.Drawing.Bitmap GetBitmap(BoolNoParameterHandler CalcuteSize, BoolNoParameterHandler DrawAllHandler, int intImgWidth, int intImgHeight)
        {
            if (DrawAllHandler == null)
                return null;
            System.Drawing.Graphics gBack = myGraph;
            myGraph = null;
            System.Drawing.Bitmap myBmp = null;
            try
            {
                if (CalcuteSize != null)
                {
                    // 创建一个临时绘图对象用于计算视图区域的大小
                    myBmp = new System.Drawing.Bitmap(10, 10);
                    myGraph = System.Drawing.Graphics.FromImage(myBmp);
                    if (gBack != null)
                    {
                        myGraph.PageUnit = gBack.PageUnit;
                    }
                    if (CalcuteSize() == false)
                    {
                        myGraph.Dispose();
                        myBmp.Dispose();
                        return null;
                    }
                    myGraph.Dispose();
                    myBmp.Dispose();
                }
                if (intImgWidth > 0)
                    intWidth = intImgWidth;
                if (intImgHeight > 0)
                    intHeight = intImgHeight;
                myBmp = new System.Drawing.Bitmap(intWidth, intHeight);
                myGraph = System.Drawing.Graphics.FromImage(myBmp);
                myGraph.Clear(System.Drawing.SystemColors.Window);
                bolDrawAll = true;
                if (DrawAllHandler())
                {
                    myGraph.Dispose();
                    myGraph = gBack;
                    bolDrawAll = false;
                    return myBmp;
                }
            }
            catch (Exception ext)
            {
                if (myGraph != null)
                {
                    using (System.Drawing.Font ErrFont = new System.Drawing.Font("Arial", 13))
                    {
                        myGraph.DrawString(ext.ToString(), ErrFont, System.Drawing.SystemBrushes.WindowText, 0, 0, System.Drawing.StringFormat.GenericTypographic);
                    }
                }
                if (myBmp != null)
                    myBmp.Dispose();
            }
            if (gBack != null)
                myGraph = gBack;
            bolDrawAll = false;
            return null;
        }// 函数 GetBitmap

        /// <summary>
        /// 移动坐标原点
        /// </summary>
        /// <param name="dx">横向移动的距离</param>
        /// <param name="dy">纵向移动的距离</param>
        public void TranslateTransform(int dx, int dy)
        {
            if (myGraph != null)
            {
                myGraph.TranslateTransform(dx, dy);
            }
        }
        //
        //		/// <summary>
        //		/// 将指定区域象素反转
        //		/// </summary>
        //		/// <param name="rect">矩形区域</param>
        //		public void InvertRect( System.Drawing.Rectangle rect )
        //		{
        //			InvertRect( rect.Left , rect.Top , rect.Width , rect.Height );
        //		}
        //
        //		/// <summary>
        //		/// 将指定区域象素反转
        //		/// </summary>
        //		/// <param name="left">矩形区域的左端位置</param>
        //		/// <param name="top">矩形区域的顶端位置</param>
        //		/// <param name="width">矩形区域的宽度</param>
        //		/// <param name="height">矩形区域的高度</param>
        //		public void InvertRect( int left , int top , int width , int height)
        //		{
        //			if( myCommandOutPut != null)
        //			{
        //				myCommandOutPut.CommandName = "invert";
        //				myCommandOutPut.SetRectangle( left , top , width , height );
        //				myCommandOutPut.Write();
        //			}
        //			if( myGraph != null)
        //			{
        //				Windows32.RECT vRect = new Windows32.RECT();
        //				vRect.left		= left ;
        //				vRect.top		= top ;
        //				vRect.right		= left + width ;
        //				vRect.bottom	= top + height;
        //				Windows32.Gdi32.GdiFlush();
        //				Windows32.User32.InvertRect( myGraph.GetHdc().ToInt32() , ref vRect );
        //				Windows32.Gdi32.GdiFlush();
        //			}
        //		}

        #endregion

        //*******************************************************************************************************
        //*******************************************************************************************************
        //*******************************************************************************************************


        /// <summary>
        /// 静态函数:根据字体各个样式获得字体样式
        /// </summary>
        /// <param name="Bold">是否粗体</param>
        /// <param name="Italic">是否斜体</param>
        /// <param name="UnderLine">是否有下划线</param>
        /// <returns>字体综合样式</returns>
        static public System.Drawing.FontStyle GetFontStyle(bool Bold, bool Italic, bool UnderLine)
        {
            System.Drawing.FontStyle intStyle = System.Drawing.FontStyle.Regular;
            if (Bold)
                intStyle = intStyle | System.Drawing.FontStyle.Bold;
            if (Italic)
                intStyle = intStyle | System.Drawing.FontStyle.Italic;
            if (UnderLine)
                intStyle = intStyle | System.Drawing.FontStyle.Underline;
            return intStyle;
        }


        /// <summary>
        /// 追加无效区域
        /// </summary>
        /// <param name="vLeft">无效区域的左端位置</param>
        /// <param name="vTop">无效区域的顶端位置</param>
        /// <param name="vWidth">无效区域的宽度</param>
        /// <param name="vHeight">无效区域的高度</param>
        public void AddInvalidlyRect(int vLeft, int vTop, int vWidth, int vHeight)
        {
            if (myInvalidlyRect.IsEmpty)
                myInvalidlyRect = new System.Drawing.Rectangle(vLeft, vTop, vWidth, vHeight);
            else
                myInvalidlyRect = System.Drawing.Rectangle.Union(myInvalidlyRect, new System.Drawing.Rectangle(vLeft, vTop, vWidth, vHeight));
        }
        /// <summary>
        /// 追加无效区域
        /// </summary>
        /// <param name="vRect">表示无效区域的矩形对象</param>
        public void AddInvalidlyRect(System.Drawing.Rectangle vRect)
        {
            if (myInvalidlyRect.IsEmpty)
                myInvalidlyRect = vRect;
            else
                myInvalidlyRect = System.Drawing.Rectangle.Union(myInvalidlyRect, vRect);
        }


        /// <summary>
        /// 各层容器间的缩进量
        /// </summary>
        public int ContainerIndent
        {
            get { return intContainerIndent; }
            set { intContainerIndent = value; }
        }

        /// <summary>
        /// 是否绘制全部对象,这将影响 isNeedDraw 函数
        /// </summary>
        public bool DrawAll
        {
            get { return bolDrawAll; }
            set { bolDrawAll = value; }
        }

        /// <summary>
        /// 开始绘图区域的左端位置
        /// </summary>
        public int Left
        {
            get { return intLeft; }
            set { intLeft = value; }
        }
        /// <summary>
        /// 开始绘图区域的顶端位置
        /// </summary>
        public int Top
        {
            get { return intTop; }
            set { intTop = value; }
        }

        /// <summary>
        /// 绘图区域的宽度
        /// </summary>
        public int Width
        {
            get { return intWidth; }
            set { intWidth = value; }
        }

        /// <summary>
        /// 绘图区域的高度
        /// </summary>
        public int Height
        {
            get { return intHeight; }
            set { intHeight = value; }
        }

        /// <summary>
        /// 移动视图区域的左上角位置到指定位置
        /// </summary>
        /// <param name="x">指定位置的X坐标</param>
        /// <param name="y">指定位置的Y坐标</param>
        public void MoveTo(int x, int y)
        {
            intLeft = x;
            intTop = y;
        }

        public System.Drawing.GraphicsUnit GraphicsUnit
        {
            get
            {
                if (myGraph == null)
                    return System.Drawing.GraphicsUnit.Display;
                else
                    return myGraph.PageUnit;
            }
            set
            {
                if (myGraph != null)
                    myGraph.PageUnit = value;
            }
        }

        /// <summary>
        /// 绘图对象
        /// </summary>
        /// <remarks>
        /// 在设置绘图对象时会计算制表符的宽度,目前设置为当前字体下连续4个半角下划线的宽度
        /// </remarks>
        public System.Drawing.Graphics Graph
        {
            get { return myGraph; }
            set
            {
                myGraph = value;
                #region bwy
                //解决字体圆润问题，也没看到有啥效果,反而会使字使变虚
                //myGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                //myGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //myGraph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                #endregion bwy


                // 计算制表符的宽度(4个下划线)
                if (myGraph != null)
                    intTabStep = (int)(this.MeasureString("____", myDefaultFont).Width);
            }
        }
        //
        //		private double dblTwipsPerPixelX		= 1.0;
        //		private double dblTwipsPerPixelY		= 1.0;

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetDeviceCaps(int hDC, int index);
        /// <summary>
        /// 每个设备逻辑点的以Twip为单位的宽度
        /// </summary>
        public double TwipsPerPixelX
        {
            get
            {
                if (myGraph == null) return 1;
                int intHDC = (int)myGraph.GetHdc();
                double dblValue = (double)(GetDeviceCaps(
                    intHDC,
                    (int)enumDCConst.DC_LOGPIXELSX));
                myGraph.ReleaseHdc(new System.IntPtr(intHDC));
                if (dblValue > 0)
                    return 1440 / dblValue;
                else
                    return 1;
            }
        }
        /// <summary>
        /// 每个设备逻辑点的以Twip为单位的高度
        /// </summary>
        public double TwipsPerPixelY
        {
            get
            {
                if (myGraph == null) return 1;
                int intHDC = (int)myGraph.GetHdc();
                double dblValue = (double)(GetDeviceCaps(
                    intHDC,
                    (int)enumDCConst.DC_LOGPIXELSY));
                myGraph.ReleaseHdc(new System.IntPtr(intHDC));
                if (dblValue > 0)
                    return 1440 / dblValue;
                else
                    return 1;
            }
        }


        public System.Drawing.Graphics GetInnerGraph()
        {
            return myGraph;
        }


        /// <summary>
        /// 默认字体对象
        /// </summary>
        public System.Drawing.Font DefaultFont
        {
            get
            {
                //Add By wwj 2012-05-29 当默认字体大小有变化的时候需要重新创建默认字体对象
                if (myDefaultFont.Size != FontCommon.GetFontSizeByName(ZYEditorControl.DefaultFontSize))
                {
                    myDefaultFont = new System.Drawing.Font(ZYEditorControl.GetDefaultSettings(ZYTextConst.c_FontName), FontCommon.GetFontSizeByName(ZYEditorControl.GetDefaultSettings(ZYTextConst.c_FontSize)));
                }
                return myDefaultFont;
            }
            set { myDefaultFont = value; }
        }
        /// <summary>
        /// 获得默认的行高
        /// </summary>
        /// <returns></returns>
        public int DefaultRowPixelHeight
        {
            get
            {
                //return (int)myDefaultFont.GetHeight(); //add by myc 2014-08-14 注释原因：行间距依据此默认行高进行设置，此时默认字体大小应该限制为标准五号（可由静态变量全局设置）
                Font baseFont = new Font("宋体", 13.5f, FontStyle.Regular); //add by myc 2014-08-14 添加原因：行间距依据此默认行高进行设置，此时默认字体大小应该限制为标准五号（可由静态变量全局设置）
                return (int)baseFont.GetHeight();
            }
        }
        /// <summary>
        /// 数据域背景样式
        /// </summary>
        public System.Drawing.Brush FieldBrush
        {
            get { return myFieldBrush; }
            set { myFieldBrush = value; }
        }
        /// <summary>
        /// 新元素的背景样式
        /// </summary>
        public System.Drawing.Brush NewBrush
        {
            get { return myNewBrush; }
            set { myNewBrush = value; }
        }
        /// <summary>
        /// 删除线对象
        /// </summary>
        public System.Drawing.Pen DeletePen
        {
            get { return myDeletePen; }
            set { myDeletePen = value; }
        }
        /// <summary>
        /// 绘图区域
        /// </summary>
        public System.Drawing.Rectangle ViewRect
        {
            get { return myViewRect; }
            set
            {
                myViewRect = value;
            }
        }

        //		public System.Drawing.Rectangle GetComboxRect( int x , int y , int width , int height)
        //		{
        //
        //		}

        /// <summary>
        /// 计算对象的收缩和展开点的矩形区域
        /// </summary>
        /// <remarks>
        /// 对象收缩和展开控制点在对象的左边,两者边框间有两个单位的距离,水平中轴线相重
        /// </remarks>
        /// <param name="x">对象的左端位置</param>
        /// <param name="y">对象的顶端位置</param>
        /// <param name="height">对象的高度</param>
        /// <returns>包含收缩点的矩形区域</returns>
        public System.Drawing.Rectangle GetExpendHandleRect(int x, int y, int height)
        {
            if (height <= c_ExpendBoxSize)
                height = c_ExpendBoxSize;
            return new System.Drawing.Rectangle
                (x - intLeft - c_ExpendBoxSize - 2,
                y - intTop + (int)((height - c_ExpendBoxSize) / 2.0),
                c_ExpendBoxSize,
                c_ExpendBoxSize);
        }

        /// <summary>
        /// 计算对象的收缩和展开点的矩形区域
        /// </summary>
        /// <remarks>
        /// 对象收缩和展开控制点在对象的左边,两者边框间有两个单位的距离,水平中轴线相重
        /// </remarks>
        /// <param name="x">对象的左端位置</param>
        /// <param name="y">对象的顶端位置</param>
        /// <param name="height">对象的高度</param>
        /// <returns>包含收缩点的矩形区域</returns>
        public static System.Drawing.Rectangle StaticGetExpendHandleRect(int x, int y, int height)
        {
            if (height <= c_ExpendBoxSize)
                height = c_ExpendBoxSize;
            return new System.Drawing.Rectangle
                (x - c_ExpendBoxSize - 2,
                y - (int)((height - c_ExpendBoxSize) / 2.0),
                c_ExpendBoxSize,
                c_ExpendBoxSize);
        }

        public static System.Drawing.Rectangle StaticGetExpendHandleRect2(int x, int y, int height)
        {
            return new System.Drawing.Rectangle
                (x,
                y + (int)((height - c_ExpendBoxSize) / 2.0),
                c_ExpendBoxSize,
                c_ExpendBoxSize);
        }

        /// <summary>
        /// 计算指定矩形的拖拽控制矩形
        /// </summary>
        /// <param name="myRect">主矩形区域</param>
        /// <param name="DragRectSize">拖拽矩形的大小</param>
        /// <param name="InnerDragRect">拖拽矩形是否在主矩形内部,若为false则拖拽矩形外翻</param>
        /// <remarks>
        /// 拖拽矩形主要用于有用户参与的图形化用户界面,在一个矩形区域的的4个顶点和边框中间点共有8个控制点
        /// 用户使用鼠标拖拽操作来拖动这8个控制点可以用于改变矩形区域的位置和大小,这些控制点可以在区域区域的内部,
        /// 也可在矩形区域的外部,拖拽矩形有8个,分别编号从0至7
        /// <pre>
        ///               内拖拽矩形
        /// ┌─────────────────┐
        /// │■0            1■             2■│
        /// │                                  │
        /// │                                  │
        /// │                                  │
        /// │                                  │
        /// │■7                            3■│
        /// │                                  │
        /// │                                  │
        /// │                                  │
        /// │                                  │
        /// │■6           5■              4■│
        /// └─────────────────┘
        /// 
        ///              外拖拽矩形
        ///              
        /// ■               ■                  ■
        ///   ┌────────────────┐
        ///   │0            1                 2│
        ///   │                                │
        ///   │                                │
        ///   │                                │
        ///   │                                │
        /// ■│7                              3│■ 
        ///   │                                │
        ///   │                                │
        ///   │                                │
        ///   │                                │
        ///   │6             5               4 │
        ///   └────────────────┘
        /// ■                ■                 ■
        /// </pre>
        /// </remarks>
        /// <returns>拖拽矩形的数组,有8个元素</returns>
        public static System.Drawing.Rectangle[] GetDragRects(System.Drawing.Rectangle myRect, int DragRectSize, bool InnerDragRect)
        {
            System.Drawing.Rectangle[] DragRects = new System.Drawing.Rectangle[8];
            if (InnerDragRect)
            {
                DragRects[0] = new System.Drawing.Rectangle(myRect.X, myRect.Y, DragRectSize, DragRectSize);
                DragRects[1] = new System.Drawing.Rectangle(myRect.X + (int)((myRect.Width - DragRectSize) / 2), myRect.Y, DragRectSize, DragRectSize);
                DragRects[2] = new System.Drawing.Rectangle(myRect.Right - DragRectSize, myRect.Y, DragRectSize, DragRectSize);
                DragRects[3] = new System.Drawing.Rectangle(myRect.Right - DragRectSize, myRect.Y + (int)((myRect.Height - DragRectSize) / 2), DragRectSize, DragRectSize);
                DragRects[4] = new System.Drawing.Rectangle(myRect.Right - DragRectSize, myRect.Bottom - DragRectSize, DragRectSize, DragRectSize);
                DragRects[5] = new System.Drawing.Rectangle(myRect.X + (int)((myRect.Width - DragRectSize) / 2), myRect.Bottom - DragRectSize, DragRectSize, DragRectSize);
                DragRects[6] = new System.Drawing.Rectangle(myRect.X, myRect.Bottom - DragRectSize, DragRectSize, DragRectSize);
                DragRects[7] = new System.Drawing.Rectangle(myRect.X, myRect.Y + (int)((myRect.Height - DragRectSize) / 2), DragRectSize, DragRectSize);
            }
            else
            {
                DragRects[0] = new System.Drawing.Rectangle(myRect.X - DragRectSize, myRect.Y - DragRectSize, DragRectSize, DragRectSize);
                DragRects[1] = new System.Drawing.Rectangle(myRect.X + (int)((myRect.Width - DragRectSize) / 2), myRect.Y - DragRectSize, DragRectSize, DragRectSize);
                DragRects[2] = new System.Drawing.Rectangle(myRect.Right, myRect.Y - DragRectSize, DragRectSize, DragRectSize);
                DragRects[3] = new System.Drawing.Rectangle(myRect.Right, myRect.Y + (int)((myRect.Height - DragRectSize) / 2), DragRectSize, DragRectSize);
                DragRects[4] = new System.Drawing.Rectangle(myRect.Right, myRect.Bottom, DragRectSize, DragRectSize);
                DragRects[5] = new System.Drawing.Rectangle(myRect.X + (int)((myRect.Width - DragRectSize) / 2), myRect.Bottom, DragRectSize, DragRectSize);
                DragRects[6] = new System.Drawing.Rectangle(myRect.X - DragRectSize, myRect.Bottom, DragRectSize, DragRectSize);
                DragRects[7] = new System.Drawing.Rectangle(myRect.X - DragRectSize, myRect.Y + (int)((myRect.Height - DragRectSize) / 2), DragRectSize, DragRectSize);
            }
            return DragRects;
        }

        /// <summary>
        /// 计算拖拉矩形上的鼠标光标位置
        /// </summary>
        /// <remarks>
        /// 鼠标设置如下
        /// 西北-东南 SizeNWSE 南北 SizeNS      东北-西南 SizeNESW
        ///	   ■               ■                  ■
        ///     ┌────────────────┐
        ///     │0            1                 2│
        ///     │                                │
        ///     │                                │
        ///     │                                │
        ///     │                                │
        ///   ■│7 西-南 SizeWE                 3│■ 西-南 SizeWE
        ///     │                                │
        ///     │                                │
        ///     │                                │
        ///     │                                │
        ///     │6             5               4 │
        ///     └────────────────┘
        ///   ■                ■                  ■
        /// 东北-西南 SizeNESW  南北 SizeNS        西北-东南 SizeNWSE
        /// </remarks>
        /// <param name="index">拖拽矩形的序号,从0至7</param>
        /// <returns>鼠标光标对象,若序号小于0或大于7则返回空引用</returns>
        public static System.Windows.Forms.Cursor GetDragRectCursor(int index)
        {
            switch (index)
            {
                case 0:
                    return System.Windows.Forms.Cursors.SizeNWSE;
                case 1:
                    return System.Windows.Forms.Cursors.SizeNS;
                case 2:
                    return System.Windows.Forms.Cursors.SizeNESW;
                case 3:
                    return System.Windows.Forms.Cursors.SizeWE;
                case 4:
                    return System.Windows.Forms.Cursors.SizeNWSE;
                case 5:
                    return System.Windows.Forms.Cursors.SizeNS;
                case 6:
                    return System.Windows.Forms.Cursors.SizeNESW;
                case 7:
                    return System.Windows.Forms.Cursors.SizeWE;
            }
            return null;
        }

        public static bool DrawDragRect(System.Drawing.Graphics g, System.Drawing.Rectangle vRect, bool HeightLight)
        {
            if (g != null && vRect.IsEmpty == false)
            {
                if (HeightLight)
                {
                    g.FillRectangle(System.Drawing.Brushes.DarkBlue, vRect);
                    g.DrawRectangle(System.Drawing.Pens.White, vRect);
                }
                else
                {
                    g.FillRectangle(System.Drawing.Brushes.White, vRect);
                    g.DrawRectangle(System.Drawing.Pens.Black, vRect);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 使用当前字体计算一个字符的大小,本函数计算字符的大小,其中不包括GDI+中的字符串额外的修正空白
        /// </summary>
        /// <param name="myChar">字符</param>
        /// <param name="myFont">计算大小使用的字体，若为空则使用默认字体</param>
        /// <returns>字符的大小</returns>
        public System.Drawing.SizeF MeasureChar(char myChar, System.Drawing.Font myFont)
        {
            System.Drawing.SizeF mySize = new System.Drawing.Size(0, 0);
            if (myFont == null)
                myFont = myDefaultFont;
            if (myGraph != null && myFont != null)
            {
                //myGraph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                if ((int)myChar == 32 || (int)myChar == 8)
                    mySize = myGraph.MeasureString(myChar.ToString(), myFont, 10000, System.Drawing.StringFormat.GenericDefault);
                else
                    mySize = myGraph.MeasureString(myChar.ToString(), myFont, 10000, System.Drawing.StringFormat.GenericTypographic);
            }
            return mySize;
        }

        /// <summary>
        /// 使用当前字体计算一个字符串的大小,其中包括GDI+中的字符串额外的修正空白
        /// </summary>
        /// <param name="strText">字符串</param>
        /// <param name="myFont">计算大小使用的字体，若为空则使用默认字体</param>
        /// <returns>字符串的大小</returns>
        public System.Drawing.SizeF MeasureString(string strText, System.Drawing.Font myFont)
        {
            System.Drawing.SizeF mySize = new System.Drawing.SizeF(0, 0);
            if (myGraph != null)
            {
                if (myFont == null)
                    myFont = myDefaultFont;
                mySize = myGraph.MeasureString(strText, myFont, 10000, System.Drawing.StringFormat.GenericTypographic);
            }
            return mySize;
        }


        //
        //		/// <summary>
        //		/// 设置当前画刷
        //		/// </summary>
        //		/// <remarks>本函数修改myCurrentBrush 对象,以此来减少重复创建画刷对象</remarks>
        //		/// <param name="myColor">画刷的颜色</param>
        //		/// <returns>当前画刷对象</returns>
        //		public System.Drawing.Brush SetCurrentBrush(System.Drawing.Color myColor)
        //		{
        //			
        //			if(myCurrentBrush == null )
        //			{
        //				myCurrentBrush = new System.Drawing.SolidBrush(myColor);
        //			}
        //			else
        //			{
        //				System.Drawing.SolidBrush myBrush = myCurrentBrush as System.Drawing.SolidBrush ;
        //				if(myBrush != null && myBrush.Color.Equals(myColor)==false )
        //				{
        //					myCurrentBrush.Dispose();
        //					myCurrentBrush = new System.Drawing.SolidBrush(myColor);
        //				}
        //			}
        //			return myCurrentBrush ;
        //		}

        /// <summary>
        /// 判断指定区域是否位于绘图区域
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public bool isNeedDraw(int x, int y, int width, int height)
        {
            if (bolDrawAll || myViewRect.IsEmpty)
                return true;
            else
            {
                return myViewRect.IntersectsWith(new System.Drawing.Rectangle(x, y, width, height));
            }
        }

        /// <summary>
        /// 在水平方向指定范围是否属于绘图区域
        /// </summary>
        /// <param name="intLeft">指定范围左端的坐标</param>
        /// <param name="intWidth">范围的宽度</param>
        /// <returns></returns>
        public bool isNeedDrawX(int intLeft, int intWidth)
        {
            if (bolDrawAll || myViewRect.IsEmpty)
                return true;
            else
            {
                return (intLeft < myViewRect.Right && myViewRect.Left < intLeft + intWidth);
            }
        }

        #region add by myc 2014-08-01 注释原因：这种判断是否需要绘制方法对于绘制表格存在局限性
        ///// <summary>
        ///// 在垂直方向指定的范围是否属于绘图区域
        ///// </summary>
        ///// <param name="intTop">指定范围的顶端坐标</param>
        ///// <param name="intHeight">范围的高度</param>
        ///// <returns></returns>
        //public bool isNeedDrawY(int intTop, int intHeight)
        //{
        //    if (bolDrawAll || myViewRect.IsEmpty)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return (intTop < myViewRect.Bottom && myViewRect.Top < intTop + intHeight);
        //    }
        //} 
        #endregion

        /// <summary>
        /// 判断指定区域是否位于绘图区域
        /// </summary>
        /// <param name="myRect">指定的矩形区域</param>
        /// <returns>是否在绘制区域</returns>
        public bool isNeedDraw(System.Drawing.Rectangle myRect)
        {
            if (bolDrawAll)
                return true;
            else
            {
                if (myViewRect.IsEmpty)
                    return true;
                else
                    return myViewRect.IntersectsWith(myRect);
            }
        }

        /// <summary>
        /// 计算指定位置处的制表符的宽度
        /// </summary>
        /// <remarks>
        /// 本函数根据作为参数传入的制表符开始的位置,计算制表符的宽度,以保证制表符的右端位置在某个制表位上
        /// 制表位的位置恒定为标准制表符的宽度的整数倍(在此处标准制表符为4个下划线的宽度)
        ///    在下面的标尺上
        ///   0___1___2___3___4___5___6___7___8___9___10
        ///    制表符的位置随意,但制表符右端必须在某个数字下面
        ///    若制表符恰好在制表位上则返回标准制表符宽度
        /// 由于有这样的限制,因此制表符的宽度不固定,而根据其位置而改变,本函数就是计算其宽度
        /// </remarks>
        /// <param name="Pos">制表符开始的位置</param>
        /// <returns>制表符的宽度</returns>
        public int GetTabWidth(int Pos)
        {
            int iWidth = intTabStep;
            if (intTabStep > 0)
            {
                iWidth = intTabStep * (int)System.Math.Ceiling((double)Pos / intTabStep) - Pos;
                if (iWidth == 0)
                    iWidth = intTabStep;
            }
            return iWidth;
        }
        //



        /// <summary>
        /// 填充 IDisposable 接口的成员函数,清空字体列表,删除所有内部对象
        /// </summary>
        public void Dispose()
        {
            myDefaultFont.Dispose();
            myFieldBrush.Dispose();
            myNewBrush.Dispose();
            if (myCurrentBrush != null)
                myCurrentBrush.Dispose();
            ClearGDIObjects();
            mySingleLineFormat.Dispose();
        }




        #region add by myc 2014-08-01 添加原因：修正判断是否属于绘图区域方法，以支持准确绘制表格
        /// <summary>
        /// 判断在垂直方向上指定的坐标范围是否属于当前文档绘图区域。
        /// </summary>
        /// <param name="intTop">指定范围的顶端坐标。</param>
        /// <param name="intHeight">指定范围的高度。</param>
        /// <returns></returns>
        public bool isNeedDrawY(int intTop, int intHeight)
        {
            try
            {
                if (bolDrawAll || myViewRect.IsEmpty)
                {
                    return true;
                }
                else
                {
                    return (intTop < myViewRect.Bottom && myViewRect.Top < intTop + intHeight);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ///// <summary>
        ///// 判断指定的文档行是否属于当前文档绘图区域（剪切矩形）。
        ///// </summary>
        ///// <param name="myLine">指定的文档行对象。</param>
        ///// <returns></returns>
        //public bool isNeedDrawY(ZYTextLine myLine)
        //{
        //    try
        //    {
        //        if (bolDrawAll || myViewRect.IsEmpty)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            bool flag = false;
        //            if (myLine.Container is ZYTextParagraph) //文档行所属容器为段落
        //            {
        //                ZYTextParagraph para = myLine.Container as ZYTextParagraph;
        //                if (para.Parent is TPTextCell) //2014-08-04 反色绘制单元格内的段落必不可少的判定条件
        //                {
        //                    flag = (para.Parent as TPTextCell).GetContentBounds().IntersectsWith(myViewRect);
        //                }
        //                else
        //                {
        //                    flag = myLine.RealTop < myViewRect.Bottom && myViewRect.Top < myLine.RealTop + myLine.Height;
        //                }
        //            }
        //            else if (myLine.Container is TPTextRow) //文档行所属容器为表格行
        //            {
        //                TPTextRow row = myLine.Container as TPTextRow;
        //                foreach (TPTextCell cell in row)
        //                {
        //                    if (cell.GetContentBounds().IntersectsWith(myViewRect))
        //                    {
        //                        flag = true;
        //                        break;
        //                    }
        //                }
        //            }
        //            else if (myLine.Container is TPTextCell) //文档行所属容器为单元格
        //            {
        //                flag = (myLine.Container as TPTextCell).GetContentBounds().IntersectsWith(myViewRect);
        //            }
        //            return flag;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //} 
        #endregion

        #region add by myc 2014-09-17 添加原因：表格跨页第三次改版需要
        /// <summary>
        /// 判断指定的文档行是否属于当前文档绘图区域（剪切矩形）。
        /// </summary>
        /// <param name="myLine">指定的文档行对象。</param>
        /// <returns></returns>
        public bool isNeedDrawY(ZYTextLine myLine)
        {
            try
            {
                if (bolDrawAll || myViewRect.IsEmpty)
                {
                    return true;
                }
                else
                {
                    bool flag = false;
                    if (myLine.Container is ZYTextParagraph) //文档行所属容器为段落
                    {
                        ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                        if (para.Parent is TPTextCell) //2014-08-04 反色绘制单元格内的段落必不可少的判定条件
                        {
                            TPTextCell cell = para.Parent as TPTextCell;
                            if (cell.SplitRects.Count > 0) //跨页情况
                            {
                                Rectangle pageRect = cell.OwnerDocument.Pages[cell.OwnerDocument.PageIndex].Bounds;
                                foreach (Rectangle innerRect in cell.SplitRects)
                                {
                                    if (pageRect.Top <= innerRect.Top && pageRect.Bottom >= innerRect.Bottom)
                                    {
                                        Rectangle rectTemp = new Rectangle(myLine.RealLeft, myLine.RealTop, myLine.ContentWidth, myLine.FullHeight);
                                        flag = innerRect.IntersectsWith(rectTemp);
                                    }
                                }
                            }
                            else //基本情况
                            {
                                flag = cell.GetContentBounds().IntersectsWith(myViewRect);
                            }
                        }
                        else
                        {
                            flag = myLine.RealTop < myViewRect.Bottom && myViewRect.Top < myLine.RealTop + myLine.Height;
                        }
                    }
                    else if (myLine.Container is TPTextRow) //文档行所属容器为表格行
                    {
                        TPTextRow row = myLine.Container as TPTextRow;
                        foreach (TPTextCell cell in row)
                        {
                            if (cell.SplitRects.Count > 0) //跨页情况
                            {
                                Rectangle pageRect = cell.OwnerDocument.Pages[cell.OwnerDocument.PageIndex].Bounds;
                                foreach (Rectangle innerRect in cell.SplitRects)
                                {
                                    if (pageRect.Top <= innerRect.Top && pageRect.Bottom >= innerRect.Bottom)
                                    {
                                        if (innerRect.IntersectsWith(myViewRect))
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            else //基本情况
                            {
                                if (cell.GetContentBounds().IntersectsWith(myViewRect))
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (myLine.Container is TPTextCell) //文档行所属容器为单元格
                    {
                        TPTextCell cell = myLine.Container as TPTextCell;
                        if (cell.SplitRects.Count > 0) //跨页情况
                        {
                            Rectangle pageRect = cell.OwnerDocument.Pages[cell.OwnerDocument.PageIndex].Bounds;
                            foreach (Rectangle innerRect in cell.SplitRects)
                            {
                                if (pageRect.Top <= innerRect.Top && pageRect.Bottom >= innerRect.Bottom)
                                {
                                    if (innerRect.IntersectsWith(myViewRect))
                                    {
                                        flag = true;
                                    }
                                }
                            }
                        }
                        else //基本情况
                        {
                            flag = (myLine.Container as TPTextCell).GetContentBounds().IntersectsWith(myViewRect);
                        }
                    }
                    return flag;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



    }//class DocumentView

    public enum enumDCConst
    {
        /// <summary>
        /// Device driver version
        /// </summary>
        DC_DRIVERVERSION = 0,
        /// <summary>
        /// Device classification
        /// </summary>
        DC_TECHNOLOGY = 2,
        /// <summary>
        /// Horizontal size in millimeters
        /// </summary>
        DC_HORZSIZE = 4,
        /// <summary>
        ///  Vertical size in millimeters
        /// </summary>
        DC_VERTSIZE = 6,
        /// <summary>
        ///  Horizontal width in pixels
        /// </summary>
        DC_HORZRES = 8,
        /// <summary>
        /// Vertical width in pixels
        /// </summary>
        DC_VERTRES = 10,
        /// <summary>
        /// Logical pixels/inch in X
        /// </summary>
        DC_LOGPIXELSX = 88,
        /// <summary>
        /// Logical pixels/inch in Y
        /// </summary>
        DC_LOGPIXELSY = 90,
        /// <summary>
        /// Number of planes
        /// </summary>
        DC_PLANES = 14,
        /// <summary>
        /// Number of brushes the device has
        /// </summary>
        DC_NUMBRUSHES = 16,
        /// <summary>
        /// Number of colors the device supports
        /// </summary>
        DC_NUMCOLORS = 24,
        /// <summary>
        /// Number of fonts the device has
        /// </summary>
        DC_NUMFONTS = 22,
        /// <summary>
        /// Number of pens the device has
        /// </summary>
        DC_NUMPENS = 18,
        /// <summary>
        /// Length of the X leg
        /// </summary>
        DC_ASPECTX = 40,
        /// <summary>
        /// Length of the hypotenuse
        /// </summary>
        DC_ASPECTXY = 44,
        /// <summary>
        /// Length of the Y leg
        /// </summary>
        DC_ASPECTY = 42,
        /// <summary>
        /// Size required for device descriptor
        /// </summary>
        DC_PDEVICESIZE = 26,
        /// <summary>
        /// Clipping capabilities
        /// </summary>
        DC_CLIPCAPS = 36,
        /// <summary>
        /// Number of entries in physical palette
        /// </summary>
        DC_SIZEPALETTE = 104,
        /// <summary>
        /// Number of reserved entries in palette
        /// </summary>
        DC_NUMRESERVED = 106,
        /// <summary>
        /// Actual color resolution
        /// </summary>
        DC_COLORRES = 108,
        /// <summary>
        /// Physical Printable Area x margin
        /// </summary>
        DC_PHYSICALOFFSETX = 112,
        /// <summary>
        /// Physical Printable Area y margin
        /// </summary>
        DC_PHYSICALOFFSETY = 113,
        /// <summary>
        /// Physical Height in device units
        /// </summary>
        DC_PHYSICALHEIGHT = 111,
        /// <summary>
        /// Physical Width in device units
        /// </summary>
        DC_PHYSICALWIDTH = 110,
        /// <summary>
        /// Scaling factor x
        /// </summary>
        DC_SCALINGFACTORX = 114,
        /// <summary>
        /// Scaling factor y
        /// </summary>
        DC_SCALINGFACTORY = 115,
        DC_LISTEN_OUTSTANDING = 1,
        /// <summary>
        ///  Curve capabilities
        /// </summary>
        DC_CURVECAPS = 28,
        /// <summary>
        /// Line capabilities
        /// </summary>
        DC_LINECAPS = 30,
        /// <summary>
        /// Polygonal capabilities
        /// </summary>
        DC_POLYGONALCAPS = 32,
        /// <summary>
        /// Text capabilities
        /// </summary>
        DC_TEXTCAPS = 34,
    }

}
