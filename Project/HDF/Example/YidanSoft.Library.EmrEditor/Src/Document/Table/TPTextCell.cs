using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Diagnostics;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 表示一个单元格.
    /// </summary>
    public class TPTextCell : ZYTextContainer
    {
        #region 私有变量

        ///<summary> 列分割数 </summary>
        protected int colspan = 1;

        ///<summary> 行分割数 </summary>
        protected int rowspan = 1;

        ///<summary> 单元格水平对齐方式 </summary>
        protected int horizontalAlignment = -1;

        ///<summary> 单元格垂直对齐方式 </summary>
        protected int verticalAlignment = -1;

        ///<summary> 单元格选择状态 </summary>
        protected bool bolSelected = false;
        ///<summary> 是否可以操作 </summary>
        protected bool canAccess = false;

        ///<summary> 单元格宽度 </summary>
        private int cellWidth;

        ///<summary> 单元格高度 </summary>
        private int cellHeight;

        //内容宽度,除去padding的宽度
        private int contentWidth;
        //内容高度,除去padding的高度
        private int contentHeight;

        //是否是被合并了的单元格
        private bool merged = false;


        ///<summary> 单元格背景色 </summary>
        private Color backgroundColor = Color.White;


        private int paddingLeft = 20;
        private int paddingRight = 20;
        private int paddingTop = 20;
        private int paddingBottom = 10;

        #region 预留的几个字段,以防将来变化

        private string key1 = "";

        public string Key1
        {
            get { return key1; }
            set { key1 = value; }
        }
        private string key2 = "";

        public string Key2
        {
            get { return key2; }
            set { key2 = value; }
        }
        private string key3 = "";

        public string Key3
        {
            get { return key3; }
            set { key3 = value; }
        }

        #endregion

        //单元格所属行
        private TPTextRow ownerRow;

        private ZYTextParagraph para;

        private ItalicLineStyle m_ItalicLineStyle = ItalicLineStyle.NoLine;//默认其中没有斜线

        private bool m_CanInsertEnter = true;//默认单元格内可以换行 Add By wwj 2012-06-06
        public bool CanInsertEnter
        {
            get { return m_CanInsertEnter; }
            set { m_CanInsertEnter = value; }
        }
        #endregion

        #region 构造函数

        public TPTextCell()
        {
            //初始化边框
            this.BorderWidth = 1;
            this.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.BorderColor = Color.Black;

            para = new ZYTextParagraph();
            para.Parent = this;
            myChildElements.Add(para);
        }


        public TPTextCell(TPTextCell cell)
        {
            this.colspan = cell.Colspan;
            this.rowspan = cell.Rowspan;
            this.horizontalAlignment = cell.HorizontalAlignment;
            this.verticalAlignment = cell.VerticalAlignment;

            this.bolSelected = cell.Selected;

            this.Width = cell.Width;
            this.Height = cell.Height;

            this.backgroundColor = cell.backgroundColor;

            this.PaddingTop = cell.PaddingTop;
            this.PaddingRight = cell.PaddingRight;
            this.PaddingBottom = cell.PaddingBottom;
            this.PaddingLeft = cell.PaddingLeft;

            this.BorderWidth = cell.BorderWidth;
            this.BorderWidthTop = cell.BorderWidthTop;
            this.BorderWidthRight = cell.BorderWidthRight;
            this.BorderWidthBottom = cell.BorderWidthBottom;
            this.BorderWidthLeft = cell.BorderWidthLeft;

            this.BorderColor = cell.BorderColor;
            this.BorderColorTop = cell.BorderColorTop;
            this.BorderColorRight = cell.BorderColorRight;
            this.BorderColorBottom = cell.BorderColorBottom;
            this.BorderColorLeft = cell.BorderColorLeft;
            //this.BorderColor = Color.Red; //测试用.过后删除

            this.BorderStyle = cell.BorderStyle;
            this.BorderStyleTop = cell.BorderStyleTop;
            this.BorderStyleRight = cell.BorderStyleRight;
            this.BorderStyleBottom = cell.BorderStyleBottom;
            this.BorderStyleLeft = cell.BorderStyleLeft;

            this.ItalicLineStyleInCell = cell.ItalicLineStyleInCell;//Add by wwj 2012-05-29

            this.para = new ZYTextParagraph();
            para.Parent = this;
            myChildElements.Add(para);
        }

        /// <summary>
        /// 单元格深度复制 Add by wwj 2012-05-30
        /// </summary>
        /// <returns></returns>
        public TPTextCell Clone()
        {
            TPTextCell newCell = new TPTextCell();
            newCell.myOwnerDocument = this.myOwnerDocument;

            newCell.myChildElements.Clear();

            newCell.colspan = Colspan;
            newCell.rowspan = Rowspan;
            newCell.horizontalAlignment = HorizontalAlignment;
            newCell.verticalAlignment = VerticalAlignment;

            newCell.bolSelected = Selected;

            newCell.Width = Width;
            newCell.Height = Height;

            newCell.backgroundColor = backgroundColor;

            newCell.PaddingTop = PaddingTop;
            newCell.PaddingRight = PaddingRight;
            newCell.PaddingBottom = PaddingBottom;
            newCell.PaddingLeft = PaddingLeft;

            newCell.BorderWidth = BorderWidth;
            newCell.BorderWidthTop = BorderWidthTop;
            newCell.BorderWidthRight = BorderWidthRight;
            newCell.BorderWidthBottom = BorderWidthBottom;
            newCell.BorderWidthLeft = BorderWidthLeft;

            newCell.BorderColor = BorderColor;
            newCell.BorderColorTop = BorderColorTop;
            newCell.BorderColorRight = BorderColorRight;
            newCell.BorderColorBottom = BorderColorBottom;
            newCell.BorderColorLeft = BorderColorLeft;
            //this.BorderColor = Color.Red; //测试用.过后删除

            newCell.BorderStyle = BorderStyle;
            newCell.BorderStyleTop = BorderStyleTop;
            newCell.BorderStyleRight = BorderStyleRight;
            newCell.BorderStyleBottom = BorderStyleBottom;
            newCell.BorderStyleLeft = BorderStyleLeft;

            newCell.ContentHeight = ContentHeight;

            newCell.ItalicLineStyleInCell = ItalicLineStyleInCell;//Add by wwj 2012-05-29
            //newCell.Text = Text.TrimEnd('\n', '\r');

            //***************************************
            newCell.ChildElements.Clear();

            #region 作废
            //foreach (ZYTextParagraph para in myChildElements)
            //{
            //    ZYTextParagraph newPara = new ZYTextParagraph();
            //    newPara.Parent = newCell;
            //    newPara.OwnerDocument = newCell.OwnerDocument;
            //    newCell.myChildElements.Add(newPara);
            //    StringBuilder sb = new StringBuilder();
            //    para.GetFinalText(sb);
            //    newPara.Align = para.Align;

            //    foreach (ZYTextElement ele in para.ChildElements)
            //    {
            //        if (ele is ZYTextChar)
            //        {
            //            Font charFont = ((ZYTextChar)ele).Font;//找到字符的字体

            //            foreach (char c in sb.ToString().TrimEnd('\n', '\r'))
            //            {
            //                ZYTextChar NewChar = ZYTextChar.Create(c);
            //                NewChar.OwnerDocument = newCell.OwnerDocument;
            //                NewChar.Parent = newPara;
            //                newPara.InsertBefore(NewChar, newPara.LastElement);
            //                NewChar.Font = charFont;
            //            }
            //            newPara.OwnerDocument = newCell.OwnerDocument;
            //            break;
            //        }
            //    }
            //}
            #endregion

            for (int i = 0; i < myChildElements.Count; i++)//遍历单元格中的段落
            {
                ZYTextParagraph para = myChildElements[i] as ZYTextParagraph;
                if (para != null)
                {
                    ZYTextParagraph newPara = new ZYTextParagraph();
                    newPara.Parent = newCell;
                    newPara.OwnerDocument = newCell.OwnerDocument;
                    newCell.myChildElements.Add(newPara);
                    StringBuilder sb = new StringBuilder();
                    para.GetFinalText(sb);
                    newPara.Align = para.Align;

                    foreach (ZYTextElement myElement in para.ChildElements)//遍历段落中的没有元素
                    {
                        if (myElement is ZYTextChar)//如果文本元素
                        {
                            ZYTextChar oldChar = myElement as ZYTextChar;
                            ZYTextChar NewChar = ZYTextChar.Create(oldChar.Char);
                            NewChar.OwnerDocument = newCell.OwnerDocument;
                            NewChar.Parent = newPara;
                            newPara.InsertBefore(NewChar, newPara.LastElement);
                            NewChar.FontName = oldChar.FontName;
                            NewChar.FontSize = oldChar.FontSize;
                            //NewChar.ForeColor = oldChar.ForeColor;
                            NewChar.Height = oldChar.Height;
                            NewChar.Width = oldChar.Width;
                            NewChar.Sub = oldChar.Sub;
                            NewChar.Sup = oldChar.Sup;
                        }
                    }
                }
            }

            //***************************************

            newCell.UpdateBounds();
            return newCell;
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// Determines whether the specified x is contain.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// 	<c>true</c> if the specified x is contain; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsContain(int x, int y)
        {
            if (x >= this.RealLeft && x <= this.RealLeft + this.Width && y >= this.RealTop && y <= this.RealTop + this.Height)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 处理输入的字符，现在的情况是单元格中需要控制是否需要可以换行
        /// 如果输入的字符导致行数大于输入之前的行数，则需要删除输入的字符
        /// Add By wwj 2012-06-06
        /// </summary>
        /// <param name="PreLineCount">输入字符前的行数</param>
        /// <returns>false:表示不用处理 true:表示已经处理过了</returns>
        public override bool ProcessInsertChar(int preLineCount)
        {
            int lineCount = this.Lines.Count;
            if (!this.CanInsertEnter && preLineCount < lineCount)
            {
                while (preLineCount < lineCount)
                {
                    this.OwnerDocument._BackSpace();
                    lineCount = this.Lines.Count;
                }
                return true;
            }
            return false;
        }

        #endregion

        #region 私有方法



        #endregion

        #region 公有属性

        public int PaddingLeft
        {
            get
            {
                return paddingLeft;
            }
            set
            {
                paddingLeft = value;
            }
        }
        public int PaddingRight
        {
            get
            {
                return paddingRight;
            }
            set
            {
                paddingRight = value;
            }
        }
        public int PaddingTop
        {
            get
            {
                return paddingTop;
            }
            set
            {
                paddingTop = value;
            }
        }
        public int PaddingBottom
        {
            get
            {
                return paddingBottom;
            }
            set
            {
                paddingBottom = value;
            }
        }
        public int Padding
        {
            set
            {
                paddingBottom = value;
                paddingTop = value;
                paddingLeft = value;
                paddingRight = value;
            }
        }

        /// <summary>
        /// 获取/设置水平对齐方式
        /// </summary>
        /// <value>a value</value>
        public int HorizontalAlignment
        {
            get
            {
                return horizontalAlignment;
            }

            set
            {
                horizontalAlignment = value;
            }
        }

        /// <summary>
        /// 获取/设置垂直对齐方式
        /// </summary>
        /// <value>a value</value>
        public int VerticalAlignment
        {
            get
            {
                return verticalAlignment;
            }

            set
            {
                verticalAlignment = value;
            }
        }

        /// <summary>
        /// 获取/设置colspan.
        /// </summary>
        /// <value>a value</value>
        public int Colspan
        {
            get
            {
                return colspan;
            }

            set
            {
                colspan = value;
            }
        }

        /// <summary>
        /// 获取/设置rowspan.
        /// </summary>
        /// <value>a value</value>
        public int Rowspan
        {
            get
            {
                return rowspan;
            }

            set
            {
                rowspan = value;
            }
        }

        public bool Merged
        {
            get
            {
                return this.merged;
            }
            set
            {
                this.merged = value;
            }
        }

        /// <summary>
        /// 单元格选择标志,主要用来表示高亮的.
        /// 此值为true时,CanAccess的值也为true
        /// </summary>
        public bool Selected
        {
            get { return bolSelected; }
            set { bolSelected = value; }
        }

        /// <summary>
        /// 表示当前单元格是否可以操作,一般和Selected一样.
        /// 在单击cell时,此值为true,但是Selected为false
        /// </summary>
        public bool CanAccess
        {
            get
            {
                return canAccess;
            }
            set
            {
                canAccess = value;
            }
        }

        /// <summary>
        /// cell的总宽度
        /// </summary>
        /// <value></value>
        public override int Width
        {
            get
            {
                if (this.contentWidth == 0)
                {
                    return 0;
                }
                return this.ContentWidth + paddingLeft + paddingRight;
            }
            set
            {
                this.cellWidth = value;
                this.contentWidth = value - (paddingLeft + paddingRight);
            }
        }

        /// <summary>
        /// cell的总高度
        /// </summary>
        /// <value></value>
        public override int Height
        {
            get
            {
                if (this.contentHeight < 0 || this.contentHeight == 0/*TODO Add By wwj 2012-02-19*/)
                {
                    return 0;
                }
                return this.ContentHeight + paddingTop + paddingBottom;
            }
            set
            {
                this.cellHeight = value;

                //TODO Modified By wwj 2012-02-19
                //this.contentHeight = value - (paddingTop + paddingBottom);
                if (value - (paddingTop + paddingBottom) < 0)
                {
                    this.contentHeight = 0;
                }
                else
                {
                    this.contentHeight = value - (paddingTop + paddingBottom);
                }
            }
        }

        /// <summary>
        /// 内容宽度
        /// </summary>
        public int ContentWidth
        {
            get
            {
                return contentWidth;
            }
            set
            {
                contentWidth = value;
            }
        }

        /// <summary>
        /// 内容高度
        /// </summary>
        public int ContentHeight
        {
            get
            {
                if (this.contentHeight < 0 || this.contentHeight == 0/*TODO Add By wwj 2012-02-19*/)
                {
                    return 0;
                }

                //根据rowspan,或者lines.Count算的内容高.
                int cHeight = 0;
                int lineCount = Lines.Count;

                if (rowspan > lineCount && rowspan > 1)
                {
                    cHeight = AllLineHeight + ((rowspan - 1) * (paddingTop + paddingBottom));
                }
                else
                {
                    //TODO  **************Modified by wwj 2012-02-17 修改单元格高度的算法*****************
                    //cHeight = AllLineHeight + ((lineCount - 1) * (paddingTop + paddingBottom));
                    cHeight = AllLineHeight;
                    //**************************************END******************************************
                }

                if (cHeight > contentHeight)
                {
                    return cHeight;
                }
                else
                {
                    //遇到拆分单元格时，不能与contentHeight进行比较处理
                    if (this.ChildCount != 0 && this.ChildElements[0] is TPTextRow)
                    {
                        return cHeight;
                    }
                    else
                    {
                        return contentHeight;
                    }
                }

            }
            set
            {
                contentHeight = value;
            }
        }

        #region 已注释 add by myc 2014-03-18 新版表格拆分合并绘制需要
        ///// <summary>
        ///// 获取当前单元格内所有行的总高度
        ///// </summary>
        //internal int AllLineHeight
        //{
        //    get
        //    {
        //        int tmpHeight = 0;
        //        if (myLines.Count > 0)
        //        {
        //            //最后一行
        //            ZYTextLine LastLine = (ZYTextLine)myLines[myLines.Count - 1];

        //            //TODO  **************Modified by wwj 2012-02-17 修改单元格高度的算法*****************
        //            //tmpHeight = LastLine.Top + LastLine.Height;
        //            ZYTextLine FirstLine = (ZYTextLine)myLines[0];
        //            tmpHeight = LastLine.Top + LastLine.Height - FirstLine.Top;
        //            //**************************************END***************************************** 
        //        }
        //        return tmpHeight;
        //    }
        //}
        #endregion

        #region add by myc 2014-03-18 新版表格拆分合并绘制需要新增属性
        private int allLineHeight = 0;
        /// <summary>
        /// 获取当前单元格内所有行的总高度。
        /// </summary>
        public int AllLineHeight
        {
            get
            {
                int tempHeight = 0;
                if (myLines.Count == 0)
                {
                    tempHeight = 0;
                }
                if (myLines.Count > 0)
                {
                    //this.ChildCount>0 && 
                    if (this.ChildCount > 0 && this.ChildElements[0] is TPTextRow) //add by myc 2014-03-18 新版表格拆分合并绘制需要
                    {
                        foreach (TPTextRow row in this.ChildElements)
                        {
                            tempHeight += row.Height;
                        }
                    }
                    else
                    {
                        ZYTextLine LastLine = (ZYTextLine)myLines[myLines.Count - 1];
                        ZYTextLine FirstLine = (ZYTextLine)myLines[0];
                        tempHeight = LastLine.Top + Convert.ToInt32((LastLine.Height * ((ZYTextParagraph)LastLine.Container).LineHeightMultiple)) - FirstLine.Top;
                        //foreach (ZYTextLine line in myLines)
                        //{
                        //    if (((ZYTextParagraph)line.Container).LineHeightMultiple > 1)
                        //    {
                        //        tempHeight += Convert.ToInt32(line.Height * ((ZYTextParagraph)line.Container).LineHeightMultiple);
                        //    }
                        //    else
                        //    {
                        //        tempHeight += line.Height;
                        //    }
                        //}
                    }
                }
                return tempHeight;
            }
            set
            {
                allLineHeight = value;
            }
        }
        #endregion


        /// <summary>
        /// 当前cell所属的row
        /// </summary>
        public TPTextRow OwnerRow
        {
            get
            {
                return this.ownerRow;
            }
            set
            {
                this.ownerRow = value;
            }
        }

        public string Text
        {
            get
            {
                System.Collections.ArrayList myFinalList = new System.Collections.ArrayList();
                this.AddFinalElementToList(myFinalList);
                string strText = ZYTextElement.GetElementsText(myFinalList);
                return strText;
            }
            set
            {
                this.ChildElements.Clear();
                ZYTextParagraph para = new ZYTextParagraph();
                para.Parent = this;
                para.OwnerDocument = this.OwnerDocument;
                myChildElements.Add(para);
                foreach (char a in value)
                {
                    ZYTextChar NewChar = ZYTextChar.Create(a);
                    NewChar.OwnerDocument = this.OwnerDocument;
                    NewChar.Parent = para;
                    para.InsertBefore(NewChar, para.LastElement);
                }
                para.OwnerDocument = OwnerDocument;

            }
        }

        /// <summary>
        /// 单元格斜线
        /// </summary>
        public ItalicLineStyle ItalicLineStyleInCell
        {
            get
            {
                return m_ItalicLineStyle;
            }
            set
            {
                m_ItalicLineStyle = value;
            }
        }
        #endregion

        #region 公有的边框属性

        #region width

        public int BorderWidth
        {
            get { return this.Border.BorderWidth; }
            set { this.Border.BorderWidth = value; }
        }

        public int BorderWidthTop
        {
            get { return this.Border.topWidth; }
            set { this.Border.topWidth = value; }
        }
        public int BorderWidthRight
        {
            get { return this.Border.rightWidth; }
            set { this.Border.rightWidth = value; }
        }
        public int BorderWidthBottom
        {
            get { return this.Border.bottomWidth; }
            set { this.Border.bottomWidth = value; }
        }
        public int BorderWidthLeft
        {
            get { return this.Border.leftWidth; }
            set { this.Border.leftWidth = value; }
        }
        #endregion

        #region color

        public Color BorderColor
        {
            get { return this.Border.BorderColor; }
            set { this.Border.BorderColor = value; }
        }

        public Color BorderColorTop
        {
            get { return this.Border.topColor; }
            set { this.Border.topColor = value; }
        }
        public Color BorderColorRight
        {
            get { return this.Border.rightColor; }
            set { this.Border.rightColor = value; }
        }
        public Color BorderColorBottom
        {
            get { return this.Border.bottomColor; }
            set { this.Border.bottomColor = value; }
        }
        public Color BorderColorLeft
        {
            get { return this.Border.leftColor; }
            set { this.Border.leftColor = value; }
        }
        #endregion

        #region style

        public ButtonBorderStyle BorderStyle
        {
            get { return this.Border.BorderStyle; }
            set { this.Border.BorderStyle = value; }
        }

        public ButtonBorderStyle BorderStyleTop
        {
            get { return this.Border.topStyle; }
            set { this.Border.topStyle = value; }
        }
        public ButtonBorderStyle BorderStyleRight
        {
            get { return this.Border.rightStyle; }
            set { this.Border.rightStyle = value; }
        }
        public ButtonBorderStyle BorderStyleBottom
        {
            get { return this.Border.bottomStyle; }
            set { this.Border.bottomStyle = value; }
        }
        public ButtonBorderStyle BorderStyleLeft
        {
            get { return this.Border.leftStyle; }
            set { this.Border.leftStyle = value; }
        }
        #endregion

        #endregion

        #region Container继承override方法

        /// <summary>
        /// 获取完整的包含对象的最小矩形
        /// </summary>
        /// <returns>矩形对象</returns>
        public override Rectangle GetContentBounds()
        {
            return new Rectangle(this.RealLeft, this.RealTop, this.Width, this.Height);
        }

        /// <summary>
        /// 获得对象保存的XML节点的名称
        /// </summary>
        /// <returns></returns>
        public override string GetXMLName()
        {
            return ZYTextConst.c_Cell;
        }

        /// <summary>
        /// 该元素单独的占有一行
        /// </summary>
        /// <returns></returns>
        public override bool OwnerWholeLine()
        {
            return false;
        }
        /// <summary>
        /// 容器对象默认进行强制换行
        /// </summary>
        /// <returns></returns>
        public override bool isNewLine()
        {
            return false;
        }

        /*
         2021-04-01
        合并单元格跨页时，选中区域需要进行反色绘制，当单元格跨页时，上一页绘制了，下一页在绘制一次，就会导致无效果
        第一版解决方案：使用字段判断进行拦截一次绘制，问题：当文字存在跨页切割显示时，无法切割绘制反色区域
        第二版解决方案：跨页多次绘制，每页只绘制当前页切割的反色区域
         */
        //public bool 跨页绘制反色区域是否已绘制 = false;


        /// <summary>
        /// 刷新界面,重新绘制对象
        /// </summary>
        /// <returns>是否进行了刷新操作</returns>
        public override bool RefreshView()
        {
            if (this.ChildElements.Count == 0) return true; //add by myc 2014-03-17 如果当前待画单元格占位符属性为真，则直接返回，不然纵向合并单元格出现线条粗线不一致。

            //Debug.WriteLine("*****cell's selected*****: " + this.Selected.ToString());

            base.RefreshView();


            #region add by myc 2014-09-15 添加原因：青龙山医院的表格跨页需求（表格跨页的第三次改版需要）
            if (splitRects.Count > 0)
            {
                Rectangle rec = myOwnerDocument.Pages[myOwnerDocument.PageIndex].Bounds;
                foreach (Rectangle innerRect in splitRects)
                {
                    if (rec.Top <= innerRect.Top && rec.Bottom >= innerRect.Bottom)
                    {
                        if (innerRect.Height == 0) return true;
                        //2014-09-18 后续需判定是否需要画底端跨页边线

                        //int temp = 1;
                        //if (rec.Bottom - innerRect.Bottom > 15)
                        //{
                        //    temp = 0;
                        //}
                        //if (innerRect.Top > 0)
                        //{
                        //    Rectangle adjustRec = new Rectangle(innerRect.Left, innerRect.Top - 10, innerRect.Width, innerRect.Height + 10);
                        //    myOwnerDocument.View.DrawBorder(adjustRec,
                        //    this.Border.leftColor, this.Border.leftWidth, this.Border.leftStyle, //左
                        //    this.Border.topColor, this.Border.topWidth, this.Border.topStyle,   //上
                        //    this.Border.rightColor, this.Border.rightWidth, this.Border.rightStyle, //右
                        //        //this.Border.bottomColor, this.Border.bottomWidth, this.Border.bottomStyle); //下
                        //    this.Border.bottomColor, 1, this.Border.bottomStyle); //下
                        //    return true;
                        //}

                        myOwnerDocument.View.DrawBorder(innerRect,
                            this.Border.leftColor, this.Border.leftWidth, this.Border.leftStyle, //左
                            this.Border.topColor, this.Border.topWidth, this.Border.topStyle,   //上
                            this.Border.rightColor, this.Border.rightWidth, this.Border.rightStyle, //右
                            //this.Border.bottomColor, this.Border.bottomWidth, this.Border.bottomStyle); //下
                            this.Border.bottomColor, 1, this.Border.bottomStyle); //下
                        return true;
                    }
                }
            }
            #endregion


            Rectangle rect = GetContentBounds();


            //myOwnerDocument.View.DrawBorder(rect,
            //            this.Border.leftColor, this.Border.leftWidth, this.Border.leftStyle, //左
            //            this.Border.topColor, this.Border.topWidth, this.Border.topStyle,   //上
            //            this.Border.rightColor, this.Border.rightWidth, this.Border.rightStyle, //右
            //            this.Border.bottomColor, this.Border.bottomWidth, this.Border.bottomStyle); //下


            Rectangle pagerect = myOwnerDocument.Pages[myOwnerDocument.PageIndex].Bounds;
            if (!pagerect.IntersectsWith(rect))
                return true;

            //当存在合并单元格、并且合并单元格-->跨页（rect不完全包含在pagerect）
            if (HasFlagCells != null && HasFlagCells.Count > 0 && !pagerect.Contains(rect))
            {
                //当前绘制单元格是否为跨页的上一页部分，并且截取当前页部分的内容绘制
                rect.Intersect(pagerect);
                bool isPrePage = rect.Bottom == pagerect.Bottom;
                myOwnerDocument.View.DrawBorder(rect,
                            this.Border.leftColor, this.Border.leftWidth, this.Border.leftStyle, //左
                            this.Border.topColor, this.Border.topWidth, isPrePage ? this.Border.topStyle : ButtonBorderStyle.Dashed,   //上
                            this.Border.rightColor, this.Border.rightWidth, this.Border.rightStyle, //右
                            this.Border.bottomColor, isPrePage ? 1 : this.Border.bottomWidth, isPrePage ? ButtonBorderStyle.Dashed : this.Border.rightStyle); //下
                //跨页绘制反色区域是否已绘制 = !跨页绘制反色区域是否已绘制;
            }
            else
            {
                myOwnerDocument.View.DrawBorder(rect,
                            this.Border.leftColor, this.Border.leftWidth, this.Border.leftStyle, //左
                            this.Border.topColor, this.Border.topWidth, this.Border.topStyle,   //上
                            this.Border.rightColor, this.Border.rightWidth, this.Border.rightStyle, //右
                            this.Border.bottomColor, this.Border.bottomWidth, this.Border.bottomStyle); //下
            }







            #region add by myc 2014-06-09 注释原因：单元格反色处理移至ZYTextContainer类的RefreshView方法中与文档段落统一处理，避免干扰
            if (this.Selected == true)
            {
                if (!myOwnerDocument.EnableSelectAreaPrint) //Add By wwj 2012-04-17 开启选中区域打印时关闭元素选中颜色翻转效果
                {
                    //myOwnerDocument.OwnerControl.ReversibleViewFillRect(this.GetContentBounds(), myOwnerDocument.View.Graph);
                    myOwnerDocument.OwnerControl.ReversibleViewFillRect(myOwnerDocument.GetReversibleRect(this.GetContentBounds()), myOwnerDocument.View.Graph); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理方式下的高亮度背景绘制  
                }
            }
            #endregion

            #region 已注释 add by myc 2014-05-14 新版绘制单元格斜线需要
            //非合并单元格，且需要绘制斜线
            //if (!this.Merged && this.ItalicLineStyleInCell != ItalicLineStyle.NoLine)
            //{
            //    if (this.ItalicLineStyleInCell == ItalicLineStyle.LeftTop2RightBottom)
            //        myOwnerDocument.View.DrawLine(this.BorderColor, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
            //    else if (this.ItalicLineStyleInCell == ItalicLineStyle.RightTop2LeftBottom)
            //        myOwnerDocument.View.DrawLine(this.BorderColor, rect.X + rect.Width, rect.Y, rect.X, rect.Y + rect.Height);
            //    else if (this.ItalicLineStyleInCell == ItalicLineStyle.LeftTop2RightBottom2)
            //    {
            //        myOwnerDocument.View.DrawLine(this.BorderColor, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height / 2);
            //        myOwnerDocument.View.DrawLine(this.BorderColor, rect.X, rect.Y, rect.X + rect.Width / 2, rect.Y + rect.Height);
            //    }
            //} 
            #endregion

            #region add by myc 2014-05-14 添加原因：新版绘制单元格斜线
            if (this.ItalicLineStyleInCell != ItalicLineStyle.NoLine)
            {
                myOwnerDocument.View.Graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (this.ItalicLineStyleInCell == ItalicLineStyle.LeftTop2RightBottom)
                {
                    myOwnerDocument.View.DrawLine(this.BorderColor, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                }
                else if (this.ItalicLineStyleInCell == ItalicLineStyle.RightTop2LeftBottom)
                {
                    myOwnerDocument.View.DrawLine(this.BorderColor, rect.X + rect.Width, rect.Y, rect.X, rect.Y + rect.Height);
                }
                else if (this.ItalicLineStyleInCell == ItalicLineStyle.LeftTop2RightBottom2)
                {
                    myOwnerDocument.View.DrawLine(this.BorderColor, rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height / 2);
                    myOwnerDocument.View.DrawLine(this.BorderColor, rect.X, rect.Y, rect.X + rect.Width / 2, rect.Y + rect.Height);
                }
                myOwnerDocument.View.Graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            }
            #endregion

            #region test code
            //测试: 实际的cell内的内容大小.这里画背景色来显示
            //myOwnerDocument.View.DrawFillRectangle(Color.Red, Color.Transparent, new Rectangle(this.RealLeft + this.paddingLeft, this.RealTop + this.paddingTop, this.ContentWidth, this.ContentHeight));


            //myOwnerDocument.View.DrawString("X:" + this.RealLeft.ToString() + ",Y:" + this.RealTop.ToString(), new Font("宋体", 9), Color.Green, this.RealLeft + this.paddingLeft, this.RealTop + this.paddingTop);

            //myOwnerDocument.View.DrawString("width:" + this.Width.ToString() + "Height:" + this.Height.ToString(), new Font("宋体", 9), Color.Green, this.RealLeft + this.paddingLeft, this.RealTop + this.paddingTop);

            //myOwnerDocument.View.DrawString("ContentHeight:" + this.ContentHeight + ",ContentWidth:" + this.ContentWidth.ToString(), new Font("宋体", 9), Color.Green, this.RealLeft + this.paddingLeft, this.RealTop + this.paddingTop);




            #endregion

            return true;
        }


        protected override void RefreshClientWidth()
        {
            if (myOwnerDocument != null && myOwnerDocument.Info.WordWrap)
            {
                intClientWidth = this.contentWidth;
            }
        }

        /// <summary>
        /// 重载此方法,主要是为了做padding位置的调整.
        /// 其它的东西和Contontainer中的一致
        /// </summary>
        public override void UpdateBounds()
        {
            int iLineTop = this.paddingTop; //上间距

            System.Drawing.Rectangle NewBounds = System.Drawing.Rectangle.Empty;

            foreach (ZYTextLine myLine in myLines)
            {
                myLine.Top = iLineTop;
                myLine.RealTop = this.RealTop + iLineTop;

                myLine.RealLeft = this.RealLeft + this.paddingLeft; //左间距

                if (myLine.LastElement != null && myLine.LastElement.isNewParagraph())
                {
                    myLine.LineSpacing = myOwnerDocument.Info.ParagraphSpacing;
                }
                else
                {
                    myLine.LineSpacing = myOwnerDocument.Info.LineSpacing;
                }

                if (this.ChildElements[0] is TPTextRow) //当前单元格进行了纵向拆分，内部嵌套了若干表格行
                {
                    myLine.LineSpacing = 0;
                }

                iLineTop += myLine.FullHeight;

                foreach (ZYTextElement myElement in myLine.Elements)
                {

                    NewBounds = new System.Drawing.Rectangle
                        (myElement.RealLeft,
                        myElement.RealTop,
                        myElement.Width + myElement.WidthFix,
                        myElement.Height);

                    if (NewBounds.Equals(myElement.Bounds) == false)
                    {
                        if (myOwnerDocument.OwnerControl != null && !(myElement is ZYTextContainer))
                        {
                            if (myElement.Bounds.IsEmpty == false)
                                myOwnerDocument.OwnerControl.AddInvalidateRect(myElement.Bounds);
                            myOwnerDocument.OwnerControl.AddInvalidateRect(NewBounds);
                        }
                        myElement.myBounds = NewBounds;
                    }
                    if (myElement is ZYTextContainer)
                    {
                        ZYTextContainer c = (ZYTextContainer)myElement;
                        c.UpdateBounds();
                    }
                }
            }

        }



        /// <summary>
        /// Froms the XML.
        /// </summary>
        /// <param name="myElement">My element.</param>
        /// <returns></returns>
        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                if (myElement.Attributes.Count == 0)
                {
                    this.Width = 0;
                    this.Height = 0;
                    this.ContentHeight = 0;
                    this.ContentWidth = 0;
                    this.BorderWidth = 0;
                    this.Padding = 0;
                    //this.Merged = true; //add by myc 2014-05-16 注释原因：新版表格之合并单元格采用占位单元格辅助，需要记录属性值
                    this.ChildElements.Clear();
                }
                else
                {
                    base.FromXML(myElement);

                    //myAttributes.FromXML(myElement);

                    //Add By wwj 2012-03-22 单元格斜线保存的功能
                    if (myAttributes.Contains("line-style"))
                    {
                        this.ItalicLineStyleInCell = (ItalicLineStyle)Enum.Parse(typeof(ItalicLineStyle), myAttributes.GetString("line-style"));
                    }

                    //Add By wwj 2012-06-06 是否可以换行
                    if (myAttributes.Contains("caninsertenter"))
                    {
                        this.CanInsertEnter = bool.Parse(myElement.GetAttribute("caninsertenter"));
                    }

                    this.Colspan = myAttributes.GetInt32("colspan");
                    this.Rowspan = myAttributes.GetInt32("rowspan");

                    this.HorizontalAlignment = myAttributes.GetInt32("halign");
                    this.VerticalAlignment = myAttributes.GetInt32("valign");

                    this.BorderWidthTop = myAttributes.GetInt32("border-width-top");
                    this.BorderWidthRight = myAttributes.GetInt32("border-width-right");
                    this.BorderWidthBottom = myAttributes.GetInt32("border-width-bottom");
                    this.BorderWidthLeft = myAttributes.GetInt32("border-width-left");

                    this.Width = myAttributes.GetInt32("width");

                    this.Height = myAttributes.GetInt32("height");

                    this.ContentWidth = myAttributes.GetInt32("contentwidth");
                    this.ContentHeight = myAttributes.GetInt32("contentheight");

                    this.PaddingTop = myAttributes.GetInt32("padding-top");
                    this.PaddingRight = myAttributes.GetInt32("padding-right");
                    this.PaddingBottom = myAttributes.GetInt32("padding-bottom");
                    this.PaddingLeft = myAttributes.GetInt32("padding-left");

                    //this.backgroundColor = myAttributes.GetColor("background-color");

                    this.Key1 = myAttributes.GetString("key1");
                    this.Key2 = myAttributes.GetString("key2");
                    this.Key3 = myAttributes.GetString("key3");

                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 已重载:从XML节点加载对象数据
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                myAttributes.Clear();//Add By wwj 2012-02-20 解决合并单元格后再次打开无效的Bug
                if (merged != true)
                {
                    myAttributes.SetValue("width", this.Width);
                    myAttributes.SetValue("height", this.Height);

                    //Add By wwj 2012-03-22 单元格斜线保存的功能
                    myAttributes.SetValue("line-style", Convert.ToInt32(this.ItalicLineStyleInCell));

                    //Add By wwj 2012-06-06 是否可以换行
                    myElement.SetAttribute("caninsertenter", this.CanInsertEnter.ToString());

                    myAttributes.SetValue("colspan", this.Colspan);
                    myAttributes.SetValue("rowspan", this.Rowspan);

                    myAttributes.SetValue("halign", this.HorizontalAlignment);
                    myAttributes.SetValue("valign", this.VerticalAlignment);

                    myAttributes.SetValue("border-width-top", this.BorderWidthTop);
                    myAttributes.SetValue("border-width-right", this.BorderWidthRight);
                    myAttributes.SetValue("border-width-bottom", this.BorderWidthBottom);
                    myAttributes.SetValue("border-width-left", this.BorderWidthLeft);



                    myAttributes.SetValue("contentwidth", this.ContentWidth);
                    myAttributes.SetValue("contentheight", this.ContentHeight);

                    myAttributes.SetValue("padding-top", this.PaddingTop);
                    myAttributes.SetValue("padding-right", this.PaddingRight);
                    myAttributes.SetValue("padding-bottom", this.PaddingBottom);
                    myAttributes.SetValue("padding-left", this.PaddingLeft);

                    //myAttributes.SetValue("background-color", this.backgroundColor);

                    myAttributes.SetValue("key1", this.Key1);
                    myAttributes.SetValue("key2", this.Key2);
                    myAttributes.SetValue("key3", this.Key3);
                }
                myAttributes.ToXML(myElement);

                base.ToXML(myElement);
                return true;
            }
            return false;
        }

        #endregion

        #region 鼠标事件处理,例如选择单元格,行和表格本身

        public override bool HandleMouseDown(int x, int y, MouseButtons Button)
        {
            return base.HandleMouseDown(x, y, Button);
        }


        public override bool HandleMouseMove(int x, int y, MouseButtons Button)
        {
            return base.HandleMouseMove(x, y, Button);
        }

        public override bool HandleMouseUp(int x, int y, MouseButtons Button)
        {
            return base.HandleMouseUp(x, y, Button);
        }
        #endregion








        #region 新版表格处理程序 add by myc 2014-05-12
        #region 合并单元格所需重要属性 add by myc 2014-05-12
        private int level = 1; //默认值为1，表示是基本表格
        /// <summary>
        /// 单元格所处的遍历递归层次。
        /// </summary>
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private TPTextCell ownerMergeCell = null;
        /// <summary>
        /// 记录合并掉占位单元格的合并单元格。
        /// </summary>
        public TPTextCell OwnerMergeCell
        {
            get { return ownerMergeCell; }
            set { ownerMergeCell = value; }
        }

        private List<TPTextCell> hasFlagCells = new List<TPTextCell>();
        /// <summary>
        /// 记录合并单元格合并掉的占位单元格列表。
        /// </summary>
        public List<TPTextCell> HasFlagCells
        {
            get { return hasFlagCells; }
            set { hasFlagCells = value; }
        }
        #endregion

        #region 单元格自适应高度递归调整 add by myc 2014-04-19 update by myc 2014-04-25
        /// <summary>
        /// 递归设置结构化元素显示属性Visible为true，以便于重新分行时准确计算单元格的新高度。
        /// </summary>
        /// <param name="element">指定的结构化元素。</param>
        /// <returns></returns>
        private bool SetElementsVisble(ZYTextElement element)
        {
            try
            {
                if (element is ZYTextContainer)
                {
                    ZYTextContainer myContainer = element as ZYTextContainer;
                    foreach (ZYTextElement myEle in myContainer.ChildElements)
                    {
                        if (SetElementsVisble(myEle)) continue;
                    }
                    return true;
                }
                else
                {
                    element.Visible = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 单元格的自适应高度动态调整——在单元格内部插入或删除元素时，动态调整自身的高度以适应单元格内容的改变。
        /// 同时，还要对影响到的其他单元格作类似的高度调整，为后续文档分行奠定基础。
        /// </summary>
        public void AdjustHeight()
        {
            try
            {
                #region 预处理
                int oldALH = this.AllLineHeight; //当前操作单元格的旧文本行总高度——用于判断是高度增加还是高度减小
                int oldH = this.Height; //当前操作单元格的旧高度——用于最后修正其高度
                int oldSH = oldH - oldALH - this.PaddingTop - this.PaddingBottom; //当前操作单元格的旧剩余空白高度

                //设置内部元素可见性
                if (this.ChildCount > 0)
                {
                    for (int i = 0; i < this.ChildCount; i++)
                    {
                        if (this.ChildElements[i] is ZYTextParagraph)
                        {
                            ZYTextParagraph myPara = this.ChildElements[i] as ZYTextParagraph;
                            foreach (ZYTextElement myEle in myPara.ChildElements)
                            {
                                SetElementsVisble(myEle);
                            }
                        }
                    }
                }

                this.RefreshSize();
                this.RefreshLine(); //当前操作单元格的分行处理
                if (this.AllLineHeight == oldALH) return; //当前操作单元格高度没有发生变化，则直接返回 
                TPTextRow row = this.OwnerRow;
                #endregion

                #region 计算高度增量upperH（需要修正以维护表格形态结构）
                int upperH = this.AllLineHeight - oldALH; //初始化高度增量
                if (upperH > 0) //单元格内文本行总高度增加时
                {
                    if (oldSH >= upperH) //这里要比较原来的剩余空白高度与高度增量
                    {
                        upperH = 0;
                        return; //高度增量为0时不再往下继续执行，减小算法复杂度
                    }
                    else
                    {
                        upperH -= oldSH;
                    }
                }
                else //单元格内文本行总高度减小时
                {
                    #region 构建用于计算最小剩余空白高度minSH的单元格列表
                    List<TPTextCell> minSHCells = new List<TPTextCell>(); //用于计算最小剩余空白高度的单元格列表
                    //当前操作单元格只可能是基本单元格或普通（非拆分的）合并单元格，但是可以位于父级拆分单元格内部
                    if (this.HasFlagCells.Count == 0) //基本单元格
                    {
                        foreach (TPTextCell cell in row)
                        {
                            if (cell.ChildCount == 0) //占位单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else //基本单元格或普通（非拆分的）合并单元格
                            {
                                if (cell.HasFlagCells.Count >= 0)
                                {
                                    minSHCells.Add(cell);
                                }
                            }
                        }
                    }
                    else //普通（非拆分的）合并单元格
                    {
                        foreach (TPTextCell cell in row)
                        {
                            if (cell.ChildCount == 0) //占位单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else //基本单元格或普通（非拆分的）合并单元格
                            {
                                if (cell.HasFlagCells.Count >= this.HasFlagCells.Count)
                                {
                                    minSHCells.Add(cell);
                                }
                            }
                        }

                        TPTextRow innerRow = this.HasFlagCells[this.HasFlagCells.Count - 1].OwnerRow;
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            minSHCells.Add(innerCell);
                        }
                    }
                    minSHCells.Remove(this);
                    #endregion

                    int minSH = GetInnerMinSpaceHeight(minSHCells, upperH);
                    OuterMinSpaceHeight(this, ref minSH);
                    //如果cell的高度减小值(-upperH)超过minSH，则置upperH为minSH
                    if (-upperH > minSH)
                    {
                        upperH = -minSH;
                    }
                }
                #endregion

                #region 递归更新当前操作单元格及其影响到的单元格的高度
                if (this.HasFlagCells.Count == 0) //当前操作单元格的类别为基本单元格时
                {
                    foreach (TPTextCell innerCell in row)
                    {
                        InnerUpdateHeight(innerCell, upperH);
                    }
                }
                else //当前操作单元格的类别为普通（非拆分的）合并单元格时
                {
                    AssistUpdateHeight(this, upperH);
                }
                //这个例程只能在InnerUpdateHeight例程处理完毕才能调用
                OuterUpdateHeight(this, upperH);
                //考虑到InnerUpdateHeight例程与OuterUpdateHeight例程会对当前操作单元格重叠处理两次，所以当前操作单元格的高度调整在最后要进行重新修正
                this.Height = oldH + upperH;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 单元格的自适应高度动态调整——对应拖动垂直拆分条左右拖拽单元格宽度减小不够容纳单元格内容时的情况。
        /// </summary>
        /// <param name="saveSH">左右拖拽单元格之前的单元格剩余空白高度。</param>
        public void AdjustHeightV(int saveSH)
        {
            try
            {
                #region 预处理
                int oldALH = this.AllLineHeight; //当前操作单元格的旧文本行总高度——用于判断是高度增加还是高度减小
                int oldH = this.Height; //当前操作单元格的旧高度——用于最后修正其高度
                int oldSH = oldH - oldALH - this.PaddingTop - this.PaddingBottom; //当前操作单元格的旧剩余空白高度
                this.RefreshLine(); //当前操作单元格的分行处理
                if (this.AllLineHeight == oldALH) return; //当前操作单元格高度没有发生变化，则直接返回 
                TPTextRow row = this.OwnerRow;
                #endregion

                #region 计算高度增量upperH（需要修正以维护表格形态结构）
                int upperH = this.AllLineHeight - oldALH; //初始化高度增量
                if (upperH > 0) //单元格内文本行总高度增加时
                {
                    if (oldSH >= upperH) //这里要比较原来的剩余空白高度与高度增量
                    {
                        upperH = 0;
                        return; //高度增量为0时不再往下继续执行，减小算法复杂度
                    }
                    else
                    {
                        upperH -= oldSH;
                    }
                }
                else //单元格内文本行总高度减小时
                {
                    #region 构建用于计算最小剩余空白高度minSH的单元格列表
                    List<TPTextCell> minSHCells = new List<TPTextCell>(); //用于计算最小剩余空白高度的单元格列表
                    //当前操作单元格只可能是基本单元格或普通（非拆分的）合并单元格，但是可以位于父级拆分单元格内部
                    if (this.HasFlagCells.Count == 0) //基本单元格
                    {
                        foreach (TPTextCell cell in row)
                        {
                            if (cell.ChildCount == 0) //占位单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else //基本单元格或普通（非拆分的）合并单元格
                            {
                                if (cell.HasFlagCells.Count >= 0)
                                {
                                    minSHCells.Add(cell);
                                }
                            }
                        }
                    }
                    else //普通（非拆分的）合并单元格
                    {
                        foreach (TPTextCell cell in row)
                        {
                            if (cell.ChildCount == 0) //占位单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                            {
                                minSHCells.Add(cell);
                            }
                            else //基本单元格或普通（非拆分的）合并单元格
                            {
                                if (cell.HasFlagCells.Count >= this.HasFlagCells.Count)
                                {
                                    minSHCells.Add(cell);
                                }
                            }
                        }

                        TPTextRow innerRow = this.HasFlagCells[this.HasFlagCells.Count - 1].OwnerRow;
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            minSHCells.Add(innerCell);
                        }
                    }
                    minSHCells.Remove(this);
                    #endregion

                    int minSH = GetInnerMinSpaceHeight(minSHCells, upperH);
                    OuterMinSpaceHeight(this, ref minSH);
                    //如果cell的高度减小值(-upperH)超过minSH，则置upperH为minSH
                    if (-upperH > minSH)
                    {
                        upperH = -minSH;
                    }

                    //保留拖拽之前的单元格剩余空白高度saveSH
                    if (-upperH > saveSH)
                    {
                        upperH += saveSH;
                    }
                }
                #endregion

                #region 递归更新当前操作单元格及其影响到的单元格的高度
                if (this.HasFlagCells.Count == 0) //当前操作单元格的类别为基本单元格时
                {
                    foreach (TPTextCell innerCell in row)
                    {
                        InnerUpdateHeight(innerCell, upperH);
                    }
                }
                else //当前操作单元格的类别为普通（非拆分的）合并单元格时
                {
                    AssistUpdateHeight(this, upperH);
                }
                //这个例程只能在InnerUpdateHeight例程处理完毕才能调用
                OuterUpdateHeight(this, upperH);
                //考虑到InnerUpdateHeight例程与OuterUpdateHeight例程会对当前操作单元格重叠处理两次，所以当前操作单元格的高度调整在最后要进行重新修正
                this.Height = oldH + upperH;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 单元格的自适应高度动态调整——对应拖动水平拆分条上下拖拽单元格的情况。
        /// </summary>
        /// <param name="upperH">上下拖拽单元格时的单元格高度增量。</param>
        public void AdjustHeightH(int upperH)
        {
            try
            {
                //留给单元格单独上下拖拽时使用
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 计算最小剩余空白高度核心递归算法
        /// <summary>
        /// 从某个单元格（包括本身）向孩子层次递归计算出内部嵌套单元格的最小剩余空白高度。
        /// </summary>
        /// <param name="cell">要计算minSH的单元格。</param>
        /// <param name="minSH">最小剩余空白高度形参传值，初始值为高度增量。</param>
        /// <returns></returns>
        private bool InnerMinSpaceHeight(TPTextCell cell, ref int minSH)
        {
            try
            {
                if (cell.ChildCount == 0) //占位单元格
                {
                    minSH = cell.Height - TPTextTable.MinCellHeight; //维护占位单元格的最小高度

                    if (cell.OwnerMergeCell != null)
                    {
                        return InnerMinSpaceHeight(cell.OwnerMergeCell, ref minSH);
                    }
                    return true;
                }
                else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    //找到拆分单元格内部最底端的表格行，因为拆分单元格调整高度是以最底端表格行内部的单元格高度调整作基准的
                    TPTextRow lastRow = cell.ChildElements[cell.ChildCount - 1] as TPTextRow;
                    foreach (TPTextCell innerCell in lastRow) //比较minSH
                    {
                        if (InnerMinSpaceHeight(innerCell, ref minSH)) continue;
                    }
                    return true;
                }
                else //基本单元格或普通（非拆分的）合并单元格
                {
                    int tempSH = cell.Height - cell.AllLineHeight - cell.PaddingTop - cell.PaddingBottom;
                    minSH = tempSH >= minSH ? minSH : tempSH;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个单元格（不包括本身）向父亲层次递归计算出外部包裹单元格的最小剩余空白高度。
        /// </summary>
        /// <param name="cell">要计算minSH的单元格。</param>
        /// <param name="minSH">最小剩余空白高度形参传值，初始值为高度增量。</param>
        /// <returns></returns>
        private bool OuterMinSpaceHeight(TPTextCell cell, ref int minSH)
        {
            try
            {
                //当前处理单元格所属表格行是表格的直属孩子，指示已处理完所有父级单元格，到达最外层了
                if (cell.OwnerRow.Parent is TPTextTable)
                {
                    if (cell.HasFlagCells.Count == 0)
                    {
                        //标记InnerUpdateHeight例程已处理过的父级拆分单元格
                        Rectangle markRect = cell.GetContentBounds();
                        TPTextRow row = cell.OwnerRow;
                        foreach (TPTextCell innerCell in row) //比较minSH
                        {
                            //这句代码特别重要，遇到已处理过的父级拆分单元格则直接跳出，继续下一个循环
                            if (innerCell.GetContentBounds() == markRect) continue;
                            if (innerCell.ChildCount == 0) //占位单元格
                            {
                                //父级拆分单元内部的占位单元格只能调用InnerMinSpaceHeight例程处理
                                if (innerCell.OwnerMergeCell != null) //必须加非空判断 2014-10-22
                                {
                                    if (InnerMinSpaceHeight(innerCell.OwnerMergeCell, ref minSH)) continue;
                                }
                            }
                            else //非占位单元格
                            {
                                //父级拆分单元内部的非占位单元格只能调用InnerMinSpaceHeight例程处理
                                if (InnerMinSpaceHeight(innerCell, ref minSH)) continue;
                            }
                        }
                        return true;
                    }
                    else //如果单元格合并属性大于零
                    {
                        return AssistMinSpaceHeight(cell, ref minSH);
                    }
                }
                else //当前处理单元格所属表格行位于父级拆分单元格内部
                {
                    TPTextCell parentCell = cell.OwnerRow.Parent as TPTextCell;
                    TPTextRow parentRow = parentCell.OwnerRow;
                    //标记InnerUpdateHeight例程已处理过的父级拆分单元格
                    Rectangle markRect = parentCell.GetContentBounds();

                    foreach (TPTextCell innerCell in parentRow) //比较minSH
                    {
                        //这句代码特别重要，遇到已处理过的父级拆分单元格则直接跳出，继续下一个循环
                        if (innerCell.GetContentBounds() == markRect) continue;
                        if (innerCell.ChildCount == 0) //占位单元格
                        {
                            //父级拆分单元内部的占位单元格只能调用InnerMinSpaceHeight例程处理
                            if (innerCell.OwnerMergeCell != null) //必须加非空判断 2014-10-22
                            {
                                if (InnerMinSpaceHeight(innerCell.OwnerMergeCell, ref minSH)) continue;
                            }
                        }
                        else //非占位单元格
                        {
                            if (innerCell.HasFlagCells.Count < parentCell.HasFlagCells.Count) continue; //只有合并属性HasFlagCells大于等于parentCell的单元格才参与minSH计算

                            //父级拆分单元内部的非占位单元格只能调用InnerMinSpaceHeight例程处理
                            if (InnerMinSpaceHeight(innerCell, ref minSH)) continue;
                        }
                    }
                    return OuterMinSpaceHeight(parentCell, ref minSH);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 如果当前操作单元格为合并单元格（包括拆分的与不拆分的），则要调整它合并掉的单元格所属表格行内部所有单元格的最小剩余空白高度。
        /// </summary>
        /// <param name="cell">要计算minSH的单元格。</param>
        /// <param name="minSH">最小剩余空白高度形参传值，初始值为高度增量。</param>
        /// <returns></returns>
        private bool AssistMinSpaceHeight(TPTextCell cell, ref int minSH)
        {
            try
            {
                TPTextRow row = cell.HasFlagCells[cell.HasFlagCells.Count - 1].OwnerRow;
                foreach (TPTextCell innerCell in row)
                {
                    //如果遇到占位单元格，则判断是否为cell合并掉的占位单元格，是则直接更新此占位单元格的高度，然后跳出继续下一个循环
                    if (innerCell.ChildCount == 0 && innerCell.OwnerMergeCell != null
                        && innerCell.OwnerMergeCell.GetContentBounds() == cell.GetContentBounds()) continue;
                    if (InnerMinSpaceHeight(innerCell, ref minSH)) continue;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 向孩子层次计算指定单元格列表内所有单元格的最小剩余空白高度。
        /// </summary>
        /// <param name="minSHCells">待处理的单元格列表。</param>
        /// <returns></returns>
        private int GetInnerMinSpaceHeight(List<TPTextCell> minSHCells, int upperH)
        {
            try
            {
                int lastMinSH = -upperH; //初始化最终的minSH
                foreach (TPTextCell cell in minSHCells)
                {
                    int minSH = -upperH; //初始化minSH
                    InnerMinSpaceHeight(cell, ref minSH);
                    lastMinSH = lastMinSH >= minSH ? minSH : lastMinSH;
                }
                return lastMinSH;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 更新单元格高度核心递归算法
        /// <summary>
        /// 从某个单元格（包括本身）向孩子层次递归更新内部嵌套单元格的高度。
        /// </summary>
        /// <param name="cell">要更新高度的单元格。</param>
        /// <param name="upperH">当前操作单元格的高度增量。</param>
        /// <returns></returns>
        public bool InnerUpdateHeight(TPTextCell cell, int upperH)
        {
            try
            {
                if (cell.ChildCount == 0) //占位单元格
                {
                    cell.Height += upperH;
                    if (cell.OwnerMergeCell != null)
                    {
                        return InnerUpdateHeight(cell.OwnerMergeCell, upperH);
                    }
                    return true;
                }
                else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    //拆分单元格内部最后一个表格行
                    TPTextRow lastRow = cell.ChildElements[cell.ChildCount - 1] as TPTextRow;
                    foreach (TPTextCell innerCell in lastRow)
                    {
                        if (InnerUpdateHeight(innerCell, upperH)) continue;
                    }
                    return true;
                }
                else //基本单元格或普通（非拆分的）合并单元格
                {
                    cell.Height += upperH;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个单元格（不包括本身）向父亲层次递归更新外部包裹单元格的高度。
        /// </summary>
        /// <param name="cell">要更新高度的单元格。</param>
        /// <param name="upperH">当前操作单元格高度增量。</param>
        /// <returns></returns>
        private bool OuterUpdateHeight(TPTextCell cell, int upperH)
        {
            try
            {
                //当前处理单元格所属表格行是表格的直属孩子，指示已处理完所有父级单元格，可以递归返回了
                if (cell.OwnerRow.Parent is TPTextTable) return true;

                //当前处理单元格所属表格行位于父级拆分单元格内部
                TPTextCell parentCell = cell.OwnerRow.Parent as TPTextCell;
                //如果父级单元格合并属性大于零并且所属表格行是表格的直属孩子
                if (parentCell.HasFlagCells.Count > 0 && parentCell.OwnerRow.Parent is TPTextTable)
                {
                    return AssistUpdateHeight(parentCell, upperH);
                }
                else
                {
                    TPTextRow parentRow = parentCell.OwnerRow;
                    //标记InnerUpdateHeight例程已处理过的子级拆分单元格
                    Rectangle markRect = parentCell.GetContentBounds();
                    foreach (TPTextCell innerCell in parentRow)
                    {
                        //这句代码特别重要，遇到已处理过的子级拆分单元格则直接跳出，继续下一个循环
                        if (innerCell.GetContentBounds() == markRect) continue;
                        if (innerCell.ChildCount == 0) //占位单元格
                        {
                            if (innerCell.OwnerMergeCell != null) //必须加非空判断 2014-10-22
                            {
                                if (InnerUpdateHeight(innerCell.OwnerMergeCell, upperH))
                                {
                                    innerCell.Height += upperH;
                                }
                            }
                        }
                        else //非占位单元格
                        {
                            //父级拆分单元内部的非占位单元格只能调用InnerUpdateHeight例程处理
                            if (InnerUpdateHeight(innerCell, upperH)) continue;
                        }
                    }
                }
                return OuterUpdateHeight(parentCell, upperH);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 如果当前操作单元格为合并单元格（包括拆分的与不拆分的），则要调整它合并掉的单元格所属表格行内部所有单元格的高度。
        /// </summary>
        /// <param name="cell">当前操作单元格为合并单元格。</param>
        /// <param name="upperH">当前操作单元格高度增量。</param>
        /// <returns></returns>
        private bool AssistUpdateHeight(TPTextCell cell, int upperH)
        {
            try
            {
                TPTextRow row = cell.HasFlagCells[cell.HasFlagCells.Count - 1].OwnerRow;
                foreach (TPTextCell innerCell in row)
                {
                    //如果遇到占位单元格，则判断是否为cell合并掉的占位单元格，是则直接更新此占位单元格的高度，然后跳出继续下一个循环
                    if (innerCell.ChildCount == 0 && innerCell.OwnerMergeCell != null
                        && innerCell.OwnerMergeCell.GetContentBounds() == cell.GetContentBounds())
                    {
                        innerCell.Height += upperH;
                        continue;
                    }
                    if (InnerUpdateHeight(innerCell, upperH)) continue;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region 表格跨页辅助直线 add by myc 2014-05-28
        private bool isDrawPageLine = false;
        /// <summary>
        /// 标识当前单元格是否要画辅助跨页直线。
        /// </summary>
        public bool IsDrawPageLine
        {
            get { return isDrawPageLine; }
            set { isDrawPageLine = value; }
        }
        #endregion
        #endregion


        #region 表格跨页第三次改版需要 add by myc 2014-09-15
        private List<Rectangle> splitRects = new List<Rectangle>();
        /// <summary>
        /// 单元格跨页时记录切割的上下两页需分别绘制的矩形区域。
        /// </summary>
        public List<Rectangle> SplitRects
        {
            get { return splitRects; }
            set { splitRects = value; }
        }
        #endregion


    }

    /// <summary>
    /// 单元格中斜线的枚举
    /// </summary>
    public enum ItalicLineStyle : int
    {
        /// <summary>
        /// 没有线
        /// </summary>
        NoLine = 0,

        /// <summary>
        /// 左上到右下的斜线
        /// </summary>
        LeftTop2RightBottom = 1,

        /// <summary>
        /// 右上到左下的斜线
        /// </summary>
        RightTop2LeftBottom = 2,

        /// <summary>
        /// 左上到右下的2条斜线
        /// </summary>
        LeftTop2RightBottom2 = 3
    }
}
