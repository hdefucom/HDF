using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;
using ZYTextDocumentLib;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 电子病历文本文档对象模型元素容器基础类
    /// 本类 型用于包含其他元素
    /// 本对象包含一个列表,该列表,包含了所有直接属于该容器的子元素
    /// 子元素可以是任意类型的元素,甚至是另外一个容器元素
    /// </summary>
    public class ZYTextContainer : ZYTextElement
    {
        /// <summary>
        /// 实例化一个容器对象
        /// </summary>
        public ZYTextContainer()
        {
            myBorder = new ZYTextBorder();
            Visible = true;
            Index = 0;
        }

        #region 对象变量定义 **********************************************************************
        /// <summary>
        /// 行集合
        /// </summary>
        protected System.Collections.ArrayList myLines = new System.Collections.ArrayList();

        protected int intMaxWidth = 0;
        protected int intLineSpan = 1;
        //protected EMRTextBlank		myBlank						= null;

        protected int intLeftMargin = 0;	// 左边距
        protected int intTopMargin = 0;	// 顶边距
        protected int intRightMargin = 0;	// 右边距
        protected int intBottomMargin = 0;	// 地边距
        /// <summary>
        /// 子元素对象
        /// </summary>
        protected System.Collections.ArrayList myChildElements = new System.Collections.ArrayList();
        //protected ZYTextElement myLastElement = null; //mfb
        /// <summary>
        /// 是否绘制背景色
        /// </summary>
        protected bool bolDrawBackGround = true;
        //protected System.Drawing.Rectangle myContentBounds  = new System.Drawing.Rectangle();

        /// <summary>
        /// 文本颜色
        /// </summary>
        protected System.Drawing.Color intForeColor = System.Drawing.SystemColors.WindowText;

        /// <summary>
        /// 使用使用文本颜色设置
        /// </summary>
        protected bool bolEnableForeColor = false;

        /// <summary>
        /// 本容器只能包含字符类型元素
        /// </summary>
        protected bool bolContainTextOnly = false;

        /// <summary>
        /// 子元素列表内容不能修改的标记
        /// </summary>
        protected bool bolChildElementsLocked = false;

        /// <summary>
        /// 容器内容不可改变
        /// </summary>
        protected bool bolLocked = false;

        #endregion

        #region 对象的属性群 **********************************************************************

        /// <summary>
        /// 本文本块是否整体作为一个元素来处理
        /// </summary>
        public virtual bool WholeElement
        {
            get { return false; }
        }

        /// <summary>
        /// 元素是否参与排版
        /// </summary>
        public virtual bool EnableTypeSet
        {
            get { return false; }
        }

        ///// <summary>
        ///// 本容器中最后一个元素
        ///// </summary>
        //internal ZYTextElement vLastElement
        //{
        //    get { return myLastElement; }
        //}

        /// <summary>
        /// 用户登录或者签名后更新文档
        /// </summary>
        public virtual void UpdateUserLogin()
        {
            foreach (ZYTextElement e in myChildElements)
            {
                if (e is ZYTextContainer)
                {
                    (e as ZYTextContainer).UpdateUserLogin();
                }
            }
        }

        /// <summary>
        /// 容器内容用于不可改变
        /// </summary>
        public virtual bool Locked
        {
            get
            {
                if (myOwnerDocument.Loading)
                    return false;
                //if (myOwnerDocument.Locked)
                //    return true;
                return bolLocked;
            }
            set { bolLocked = value; }
        }

        /// <summary>
        /// 判断该容器对象是不是表示一个文本块，文本块不会重新占有一行,其中的子元素参与父元素的分行
        /// </summary>
        public virtual bool Block
        {
            get { return false; }
        }

        #region 标题 Title (考虑放到div中实现,暂时注释 mfb)

        ///// <summary>
        ///// 标题是否占据了一行
        ///// </summary>
        //public bool TitleLine
        //{
        //    get { return myAttributes.GetBool(ZYTextConst.c_TitleLine); }
        //    set { myAttributes.SetValue(ZYTextConst.c_TitleLine, value); }
        //}

        ///// <summary>
        ///// 文本块标题
        ///// </summary>
        //public string Title
        //{
        //    get { return myAttributes.GetString(ZYTextConst.c_Title); }
        //    set { myAttributes.SetValue(ZYTextConst.c_Title, value); }
        //}
        ///// <summary>
        ///// 是否显示标题
        ///// </summary>
        //public bool HideTitle
        //{
        //    get { return myAttributes.GetBool(ZYTextConst.c_HideTitle); }
        //    set { myAttributes.SetValue(ZYTextConst.c_HideTitle, value); }
        //}
        ///// <summary>
        ///// 标题对齐方式
        ///// </summary>
        //public string TitleAlign
        //{
        //    get { return myAttributes.GetString(ZYTextConst.c_TitleAlign); }
        //    set { myAttributes.SetValue(ZYTextConst.c_TitleAlign, value); }
        //}


        /// <summary>
        /// 标题字体
        /// </summary>
        public string FontName
        {
            get { return myAttributes.GetString(ZYTextConst.c_FontName); }
            set { myAttributes.SetValue(ZYTextConst.c_FontName, value); }
        }

        /// <summary>
        /// 标题字号
        /// </summary>
        public float FontSize
        {
            get { return myAttributes.GetFloat(ZYTextConst.c_FontSize); }
            set { myAttributes.SetValue(ZYTextConst.c_FontSize, value); }
        }
        #endregion

        ///// <summary>
        ///// 缩进区域宽度,(针对标题的首行缩进).
        ///// </summary>
        //public float indentWidth
        //{
        //    get
        //    {
        //        System.Drawing.Font myFont = new System.Drawing.Font(this.FontName, this.FontSize + 2f, System.Drawing.FontStyle.Bold);
        //        System.Drawing.SizeF mySize = myOwnerDocument.View.MeasureString("____", myFont);
        //        myFont.Dispose();
        //        return mySize.Width;
        //    }
        //}

        /// <summary>
        /// 对象数据的来源
        /// </summary>
        public string ValueSource
        {
            get { return myAttributes.GetString(ZYTextConst.c_ValueSource); }
            set { myAttributes.SetValue(ZYTextConst.c_ValueSource, value); }
        }

        private string strID;
        /// <summary>
        /// 对象内部编号
        /// </summary>
        public string ID
        {
            get { return strID; }
            set { myAttributes.SetValue(ZYTextConst.c_ID, value); strID = value; }
        }

        private string strName;
        /// <summary>
        /// 对象名称
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { myAttributes.SetValue(ZYTextConst.c_Name, value); strName = value; }
        }


        /// <summary>
        /// 返回行集合
        /// </summary>
        public System.Collections.ArrayList Lines
        {
            get { return myLines; }
        }
        public ZYTextElement FirstElement
        {
            get
            {
                if (this.myChildElements != null && myChildElements.Count > 0)
                    return (ZYTextElement)myChildElements[0];
                else
                    return null;
            }
        }
        public ZYTextElement LastElement
        {
            get
            {
                if (this.myChildElements != null && myChildElements.Count > 0)
                    return (ZYTextElement)myChildElements[myChildElements.Count - 1];
                else
                    return null;
            }
        }

        /// <summary>
        /// 已重载:元素所在的文档对象
        /// </summary>
        public override ZYTextDocument OwnerDocument
        {
            get { return myOwnerDocument; }
            set
            {
                myOwnerDocument = value;
                //if (myLastElement != null)
                //{
                //    myLastElement.OwnerDocument = value;
                //}
                foreach (ZYTextElement myElement in myChildElements)
                {
                    myElement.OwnerDocument = value;
                }
            }
        }


        /// <summary>
        /// 对象所占的行数
        /// </summary>
        public int LineSpan
        {
            get { return intLineSpan; }
            set { intLineSpan = value; }
        }

        /// <summary>
        /// 对象最大宽度
        /// </summary>
        public int MaxWidth
        {
            get { return intMaxWidth; }
            set { intMaxWidth = value; }
        }

        public override bool Deleteted
        {
            get
            {
                return base.Deleteted;
            }
            set
            {
                base.Deleteted = value;
                foreach (ZYTextElement e in myChildElements)
                    e.Deleteted = value;
            }
        }

        #endregion

        #region 进行元素坐标位置计算和分页处理的函数群 RefreshSize, RefreshLine

        /// <summary>
        /// 判断指定坐标是否在本容器中
        /// </summary>
        /// <param name="x">指定点的Ｘ坐标</param>
        /// <param name="y">指定点的Ｙ坐标</param>
        /// <returns></returns>
        public virtual bool Contains(int x, int y)
        {
            return myChildElements.Contains(myOwnerDocument.Content.GetElementAt(x, y));
        }

        /// <summary>
        /// 已重载:返回对象的高度,行高度 + intTopMargin + intBottomMargin
        /// </summary>
        public override int Height
        {
            get
            {
                if (myLines.Count > 0)
                {
                    ZYTextLine LastLine = (ZYTextLine)myLines[myLines.Count - 1];
                    return LastLine.Top + LastLine.Height + intTopMargin + intBottomMargin;
                }
                else
                {
                    //return myOwnerDocument.DefaultRowHeight + intTopMargin + intBottomMargin; //add by myc 2014-07-08 注释原因：新版页眉二期改版（页脚）需要
                    return 0; //add by myc 2014-07-08 添加原因：新版页眉二期改版（页脚）需要
                }
            }
        }


        /// <summary>
        /// 刷新内部元素的大小
        /// </summary>
        /// <returns></returns>
        public override bool RefreshSize()
        {
            foreach (ZYTextElement myElement in myChildElements)
                myElement.RefreshSize();
            //this.RefreshLine();
            return true;
        }
        #region intClientWidth

        /// <summary>
        /// 客户区的宽度
        /// </summary>
        protected int intClientWidth = 0;
        /// <summary>
        /// 重新计算客户区的宽度
        /// </summary>
        protected virtual void RefreshClientWidth()
        {
            if (myParent == null)
            {
                if (myOwnerDocument != null && myOwnerDocument.Info.WordWrap)
                    intClientWidth = myOwnerDocument.Pages.StandardWidth - this.RealLeft - intLeftMargin - intRightMargin;
                else
                    intClientWidth = 0;
            }
            else
            {
                intClientWidth = this.Width - intLeftMargin - intRightMargin;
                //7-6 add
                if (this.Parent is TPTextCell)
                {
                    intClientWidth = (this.Parent as TPTextCell).ContentWidth;
                }
            }
        }
        /// <summary>
        /// 获得客户区的宽度
        /// </summary>
        /// <returns></returns>
        internal int GetClientWidth()
        {
            return intClientWidth;
        }

        #endregion

        /// <summary>
        /// 元素重新分行
        /// </summary>
        public virtual ArrayList RefreshLine()
        {
            if (myParent == null)
                intWidth = 0;
            this.RefreshLineFast(0);
            return myLines;
        }

        /// <summary>
        /// 内部的保存参与本对象分行的所有的元素的列表
        /// </summary>
        System.Collections.ArrayList myContentList = new System.Collections.ArrayList();

        /// <summary>
        /// ------------------------------进行重新分行处理----------------------------------------
        /// 以最小元素为计算单位进行分行处理.
        /// </summary>
        /// <param name="StartIndex">开始进行分行的元素序号,默认传入0,重头开始分行</param>
        public virtual void RefreshLineFast(int StartIndex)
        {
            // 保存上一行所有元素的列表
            System.Collections.ArrayList LastLine = new System.Collections.ArrayList();

            int OldHeight = this.Height;
            //重新计算客户区宽度
            RefreshClientWidth();

            int intLeftCount = 0;

            //元素开始索引编号
            if (StartIndex < 0 || StartIndex > myChildElements.Count - 1)
            {
                StartIndex = 0;
            }

            //清空行集合
            if (StartIndex == 0)
            {
                myLines.Clear();
            }

            #region mfb comment
            //else //else 基本无用
            //{
            //    // 准备循环处理，根据开始分行的元素编号修正参数
            //    ZYTextElement StartElement = myChildElements[StartIndex] as ZYTextElement;
            //    LineIndex = StartElement.LineIndex;
            //    //清空指定行号处开始的所有行集合
            //    myLines.RemoveRange(LineIndex, myLines.Count - LineIndex);
            //    foreach (ZYTextElement myElement in myChildElements)
            //    {
            //        if (myElement == StartElement)
            //            break;
            //        if (myElement.LineIndex == LineIndex)
            //        {
            //            LastLine.Add(myElement);
            //            intLeftCount += myElement.Width;
            //        }
            //    }
            //}
            #endregion

            // 如果为false则换行,如果为true则继续添加元素不换行. 向当前行添加元素的标志 mfb
            bool bolAddElement = false;
            ZYTextElement LastElement = null;
            myContentList.Clear();
            
            myContentList.AddRange(myChildElements);
            
            // 循环处理所有的元素
            for (int Index = StartIndex; Index < myContentList.Count; Index++)
            {
                ZYTextElement currentElement = (ZYTextElement)myContentList[Index];
                // 若元素不可见则不参与分行
                if (currentElement.Visible) //(myOwnerDocument.isVisible( myElement ))
                {
                    // 若当前元素为字符类型在针对制表符进行宽度计算
                    if (currentElement is ZYTextCharTab)
                    {
                        (currentElement as ZYTextCharTab).RefreshTabWidth();
                    }

                    //按单元格为最小元素值,来分行.
                    //if (currentElement is TPTextTable)
                    //{
                    //    LastLine.Add(currentElement);
                    //    ResetLine(LastLine);
                    //    LastLine.Clear();
                    //    intLeftCount = intLeftMargin;
                    //    goto tableend;
                    //}

                    bolAddElement = true;

                    // 若当前元素为一个容器元素则进行内部的换行处理
                    if (currentElement is ZYTextContainer)
                    {
                        ZYTextContainer c = (ZYTextContainer)currentElement;

                        //如果不用换行
                        if (!(c.isNewLine()))
                        {
                            myContentList.InsertRange(myContentList.IndexOf(c) + 1, c.ChildElements);
                        }
                        else
                        {
                            myLines.AddRange(c.RefreshLine());
                        }
                    }
                    else
                    {
                        // 若当前元素或上一个元素单独的占有一行则进行强制换行
                        if (currentElement.OwnerWholeLine() || (LastElement != null && LastElement.OwnerWholeLine()))
                        {
                            bolAddElement = false;
                        }
                        else if (currentElement.isNewLine() == false)
                        {
                            // 若当前元素不进行强制换行则根据当前行的宽度来判断是否将元素添加到当前行中
                            if (intClientWidth > 0)
                            {
                                // 若当前行宽度 + 当前元素宽度 > 文档限制宽度(客户区宽度). 则不追加当前元素
                                // 
                                //
                                #region bwy或者当前元素后面为英文单词，如果单词总宽度 > 文档限制宽度(客户区宽度). 则不追加当前元素,zycontent.cs又被签出了，写在这里先
                                int addwidth = 0;
                                //如果当前元素是char 且是单词前缀，且前一个元素是空格
                                if (
                                    (Index == 0 || (myContentList[Index - 1] is ZYTextChar) && char.IsWhiteSpace((myContentList[Index - 1] as ZYTextChar).Char))
                                    && currentElement is ZYTextChar && StringCommon.IsABC123((currentElement as ZYTextChar).Char))
                                {

                                    int iCount = Index + 1;
                                    for (; iCount < myContentList.Count; iCount++)
                                    {
                                        if (myContentList[iCount] is ZYTextChar)
                                        {
                                            if (!StringCommon.IsABC123((myContentList[iCount] as ZYTextChar).Char))
                                                break;
                                            else
                                                addwidth += (myContentList[iCount] as ZYTextElement).Width;
                                        }
                                        else
                                            break;
                                    }
                                    //如果单词》页面宽，换行也没用，所以不换
                                    if (currentElement.Width + addwidth > intClientWidth)
                                    {
                                        addwidth = 0;//设置为o不
                                    }

                                }

                                #endregion bwy
                                if (
                                    //intLeftCount + currentElement.Width > intClientWidth
                                    //||
                                    //intLeftCount + currentElement.Width + addwidth > intClientWidth
                                    intLeftCount + currentElement.Width + addwidth >= intClientWidth //add by myc 2014-07-16 添加原因：这个等于判断非常重要，文档行中文字符填满整行时，删除后回车符没有画出来，导致光标进入不了回车符前面的位置。文档行不能以纯粹的回车符结束来确定。
                                    )
                                {
                                    bolAddElement = false;
                                }
                                else
                                {
                                    //mfb 原来为myContentList.Count - 2, 因为最后一个元素不再是<p />结尾了所以应该减1
                                    if (Index < myContentList.Count - 1)
                                    {
                                        // 若下一个元素不能出现在行首或当前元素不能出现在行尾则不追加(提前换行)
                                        ZYTextElement NextElement = (ZYTextElement)myContentList[Index + 1];
                                        if ((NextElement.CanBeLineHead() == false || currentElement.CanBeLineEnd() == false) && intLeftCount + currentElement.Width + NextElement.Width > intClientWidth)
                                        {
                                            bolAddElement = false;
                                        }
                                    }
                                }
                            }
                        }

                        //如果还可以继续添加新元素,则不换行,继续添加
                        if (bolAddElement)
                        {
                            // 向当前行添加元素
                            LastLine.Add(currentElement);
                            intLeftCount += currentElement.Width;
                        }
                        else
                        {
                            // 若不追加则认为当前行不能再发展,需要进行产生新文本行的处理(在这里换行)
                            ResetLine(LastLine);
                            LastLine.Clear();
                            intLeftCount = intLeftMargin;
                            // 向下一行追加元素
                            LastLine.Add(currentElement);
                            intLeftCount += currentElement.Width;
                        }
                        // 若当前元素强制换行则进行换行处理
                        if (currentElement.isNewLine())
                        {
                            ResetLine(LastLine);
                            LastLine.Clear();
                            intLeftCount = intLeftMargin;
                        }
                    }
                    //tableend: ;
                }
                else
                {
                    currentElement.OwnerLine = null;
                }
                LastElement = currentElement;
            }

            //if (LastLine.Count > 0)
            //{
            //    ResetLine(LastLine);
            //}
            // 重新计算对象宽度
            // 若不存在父对象且文档对象不是自动换行的则该容器的宽度是算出来的
            if (myParent == null && myOwnerDocument != null && myOwnerDocument.Info.WordWrap == false)
            {
                foreach (ZYTextLine myLine in myLines)
                {
                    if (intWidth < intLeftMargin + intRightMargin + myLine.ContentWidth)
                    {
                        intWidth = intLeftMargin + intRightMargin + myLine.ContentWidth;
                    }
                }
            }

            //更新内部子元素的边框
            UpdateBounds();

            // 若对象高度大于０且文档不处于加载模式
            if (this.Height != OldHeight && myOwnerDocument.Loading == false)
            {
                myOwnerDocument.RefreshAllFlag = true;
            }


            #region add by myc 2014-05-12 添加原因：导入外部表格Xml时关联表格内的合并单元格与占位单元格
            //特别注意，在此关联之前必须在表格的FromXml方法中调用TransformOldTBXmlToNewTBXml方法首先对旧版表格进行Xml存储结构的正确解析
            if (this is TPTextTable)
            {
                TPTextTable currTB = this as TPTextTable;
                if (!currTB.IsInitRelevance)
                {
                    foreach (TPTextRow row in currTB)
                    {
                        currTB.RelevanceMergeCellAndFlagCell(row);
                    }
                    currTB.IsInitRelevance = true;
                }
            } 
            #endregion


        }// public virtual void  RefreshLineFast( int StartIndex )

        /// <summary>
        /// 计算行本身的坐标位置,以及其中元素的边框
        /// </summary>
        public virtual void UpdateBounds()
        {
            // 计算行的起始位置
            int iLineTop = 0;
            
            //if (this.TitleLine)
            //    //iLineTop = (int)this.GetTitleSize().Height ;//2007-9-15 耿国栋
            //    iLineTop = (int)this.TitleSize.Height;
            System.Drawing.Rectangle NewBounds = System.Drawing.Rectangle.Empty;
            // 遍历所有的文本行对象
            foreach (ZYTextLine myLine in myLines)
            {
                myLine.Top = iLineTop;
                myLine.RealTop = this.RealTop + iLineTop;
                myLine.RealLeft = this.RealLeft;

                #region add by myc 2014-05-06 添加原因 鼠标拖拽表格整体水平或垂直偏移
                if (myLine.Container is TPTextRow)
                {
                    myLine.RealLeft += (myLine.Container as TPTextRow).OwnerTable.OffsetX;
                    myLine.RealTop += (myLine.Container as TPTextRow).OwnerTable.OffsetY;
                }
                #endregion

                // System.Windows.Forms.MessageBox.Show(i.ToString());

                // 若当前行最后一个元素为断落标记则设置和下行间距为段落间距
                // 否则设置为行间距
                if (myLine.LastElement != null && myLine.LastElement.isNewParagraph())
                {
                    myLine.LineSpacing = myOwnerDocument.Info.ParagraphSpacing;
                }
                else
                {
                    myLine.LineSpacing = myOwnerDocument.Info.LineSpacing; //2014-08-05 单元格走这一步的行间距设置
                }

                //********************* Modified By wwj 2012-02-21 解决表格与其下面段落行的行距过短的问题 *************************
                ////如果行内元素为单元格,则忽略行距
                //if (myLine.FirstElement is TPTextCell)
                //{
                //    myLine.LineSpacing = 0;
                //}

                //当前行不是表格的最后一行时，需要将行间距置为零。
                if (myLine.Container is TPTextRow && myLine.FirstElement is TPTextCell)
                {
                    //判断当前行是否是表格中的最后一行
                    if (myLine.Container.Parent is TPTextTable && myLine.Container == myLine.Container.Parent.ChildElements[myLine.Container.Parent.ChildElements.Count - 1])
                    {
                        //暂无操作
                    }
                    else
                    {
                        myLine.LineSpacing = 0;
                    }
                }
                //***************************************************************************************************************


                
                
                #region add by myc 2014-07-18 添加原因：处理页眉区域水平线与上一文档行距离过高，导致的续打问题
                if (myLine.Container is ZYTextParagraph) //当前文本行对象所属容器为段落
                {
                    ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                    if (para.Parent is TPTextCell) //当前段落位于单元格内部
                    {
                        TPTextCell cell = para.Parent as TPTextCell;
                        if (cell.OwnerRow.OwnerTable.Parent is ZYDocumentHeader)
                        {
                            ZYDocumentHeader RootDocumentHeaderElement = cell.OwnerRow.OwnerTable.Parent as ZYDocumentHeader;
                            if (RootDocumentHeaderElement.ChildElements.IndexOf(para) + 1 < RootDocumentHeaderElement.ChildCount)
                            {
                                ZYTextParagraph nextPara = RootDocumentHeaderElement.ChildElements[RootDocumentHeaderElement.ChildElements.IndexOf(para) + 1] as ZYTextParagraph;
                                if (nextPara != null && nextPara.ChildCount == 2 && nextPara.ChildElements[0] is ZYHorizontalLine) //检查是否为包含水平线元素的段落
                                {
                                    myLine.LineSpacing = 0; //设置行间距为0
                                    ZYHorizontalLine myHEle = nextPara.ChildElements[0] as ZYHorizontalLine;
                                    myHEle.Top = 0;
                                }
                            }
                        }
                    }
                    else //当前段落不位于单元格内部
                    {
                        if (para.Parent is ZYDocumentHeader)
                        {
                            ZYDocumentHeader RootDocumentHeaderElement = para.Parent as ZYDocumentHeader;
                            if (RootDocumentHeaderElement.ChildElements.IndexOf(para) + 1 < RootDocumentHeaderElement.ChildCount)
                            { 
                                ZYTextParagraph nextPara = RootDocumentHeaderElement.ChildElements[RootDocumentHeaderElement.ChildElements.IndexOf(para) + 1] as ZYTextParagraph;
                                if (nextPara != null && nextPara.ChildCount == 2 && nextPara.ChildElements[0] is ZYHorizontalLine) //检查是否为包含水平线元素的段落
                                {
                                    myLine.LineSpacing = 0; //设置行间距为0
                                    ZYHorizontalLine myHEle = nextPara.ChildElements[0] as ZYHorizontalLine;
                                    myHEle.Top = 0;
                                }
                            }
                        }
                    }
                }
                #endregion




                
                //-----------这句非常重要,行的Top就靠下面这句了----------
                iLineTop += myLine.FullHeight;

                #region add by myc 2014-05-06 添加原因 鼠标拖拽表格整体垂直偏移时需修正iLineTop
                if (myLine.Container is TPTextRow)
                {
                    TPTextRow row = myLine.Container as TPTextRow;
                    int rowIndex = row.OwnerTable.IndexOf(row);
                    if (rowIndex == row.OwnerTable.AllRows.Count - 1) //遍历到当前表格中最后一行时，iLineTop要进行垂直方向偏移量修正
                    {
                        iLineTop += row.OwnerTable.OffsetY;
                    }
                }
                #endregion

                // 遍历当前行中所有的元素，计算这些元素的坐标和边框
                foreach (ZYTextElement myElement in myLine.Elements)
                {
                    // 计算元素新的边框
                    NewBounds = new System.Drawing.Rectangle
                        (myElement.RealLeft,
                        myElement.RealTop,
                        myElement.Width + myElement.WidthFix,
                        myElement.Height);
                    
                    // 若新的元素边框和旧的元素边框不一样则设置要重新绘制的区域
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
                    // 若当前元素为容器对象则调用容器对象的计算子元素位置的函数
                    if (myElement is ZYTextContainer)
                    {
                        ZYTextContainer c = (ZYTextContainer)myElement;
                        c.UpdateBounds();
                    }
                }
            }
        }//protected virtual void UpdateLinePos()

        /// <summary>
        /// 格式化行数据,包括向文档注册该行,设置行中元素的位置大小以及对齐方式.
        /// 用于配合 RefreshLineFast
        /// </summary>
        /// <param name="LineElements">该文本行所包括的元素</param>
        /// <returns>行高</returns>
        protected virtual int ResetLine(System.Collections.ArrayList LineElements)
        {
            ZYTextLine NewLine = new ZYTextLine();
            NewLine.Index = myLines.Count;
            NewLine.Container = this;
            NewLine.RealLeft = this.RealLeft;
            NewLine.Elements.AddRange(LineElements);

            if (this.OwnerDocument.EnableFixedLineHeigh)
            {
                NewLine.Height = this.OwnerDocument.FixedLineHeigh;
            }
            // 确定行的高度和宽度
            foreach (ZYTextElement myElement in LineElements)
            {
                //行高由行里最高的元素所决定
                if (this.OwnerDocument.EnableFixedLineHeigh)
                {
                    if (myElement.Height > this.OwnerDocument.FixedLineHeigh)
                    {
                        myElement.Height = this.OwnerDocument.FixedLineHeigh;
                    }
                }
                else if (NewLine.Height < myElement.Height)
                {
                    #region bwy 回车符也是有高度的，但不能让它影响行的高度
                    //if (myElement is ZYTextEOF && myElement.Parent.ChildCount > 1) //add by myc 2014-07-17 注释原因：新版字体属性控制需要
                    //{
                    //    continue;
                    //}
                    #endregion bwy
                    NewLine.Height = myElement.Height;
                }
            }

            #region 2019.07.03-hdf 添加原因：添加电子病历模板编辑器行高编辑功能
            if (this is ZYTextParagraph)
            {
                    NewLine.Height = Convert.ToInt32(NewLine.Height * ((ZYTextParagraph)this).LineHeightMultiple);
            } 

            #endregion            

            NewLine.ContentWidth = this.Width;

            // 向文档对象结构注册当前行
            myLines.Add(NewLine);
            //myOwnerDocument.AddLine(NewLine); //add by myc 2014-06-26 注释原因：新版页眉二期改版需要

            #region add by myc 2014-07-02 添加原因：新版页眉二期改版需要
            if (NewLine.Container is ZYTextParagraph) //当前文本行对象所属容器为段落
            {
                ZYTextParagraph para = NewLine.Container as ZYTextParagraph;
                if (para.Parent is TPTextCell) //当前段落位于单元格内部
                {
                    TPTextCell cell = para.Parent as TPTextCell;
                    if (cell.OwnerRow.OwnerTable.Parent is ZYTextDiv)
                    {
                        //myOwnerDocument.AddLine(NewLine);
                        //myOwnerDocument.EditingAreaLines[1].Add(NewLine); //add by myc 2014-07-03 添加原因：新版页眉二期改版之保存文档正文区域的所有文本行对象
                        (cell.OwnerRow.OwnerTable.Parent as ZYTextDiv).InnerLines.Add(NewLine); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
                    }
                    else if (cell.OwnerRow.OwnerTable.Parent is ZYDocumentHeader)
                    {
                        (cell.OwnerRow.OwnerTable.Parent as ZYDocumentHeader).InnerLines.Add(NewLine); //注意InnerLines必须在页眉区域根元素的RefreshLine之前执行Clear
                    }
                    else if (cell.OwnerRow.OwnerTable.Parent is ZYDocumentFooter)
                    {
                        (cell.OwnerRow.OwnerTable.Parent as ZYDocumentFooter).InnerLines.Add(NewLine); //注意InnerLines必须在页脚区域根元素的RefreshLine之前执行Clear
                    }
                }
                else //当前段落不位于单元格内部
                {
                    if (para.Parent is ZYTextDiv)
                    {
                        //myOwnerDocument.AddLine(NewLine);
                        //myOwnerDocument.EditingAreaLines[1].Add(NewLine); //add by myc 2014-07-03 添加原因：新版页眉二期改版之保存文档正文区域的所有文本行对象
                        (para.Parent as ZYTextDiv).InnerLines.Add(NewLine); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
                    }
                    else if (para.Parent is ZYDocumentHeader)
                    {
                        (para.Parent as ZYDocumentHeader).InnerLines.Add(NewLine); //注意InnerLines必须在页眉区域根元素的RefreshLine之前执行Clear
                    }
                    else if (para.Parent is ZYDocumentFooter)
                    {
                        (para.Parent as ZYDocumentFooter).InnerLines.Add(NewLine); //注意InnerLines必须在页脚区域根元素的RefreshLine之前执行Clear
                    }
                }
            }
            #endregion
            
            // 计算行的标准宽度
            int LineWidth = this.intClientWidth;

            int allEleWidth = 0;
            foreach (ZYTextElement myElement in LineElements)
            {
                allEleWidth += myElement.Width;
            }

            ParagraphAlignConst intAlign = ParagraphAlignConst.Left;
            // 计算对齐方式，若当前行不是以强制换行符结尾的则使用左对齐
            if (this is ZYTextParagraph)
            {
                intAlign = (this as ZYTextParagraph).Align;
            }

            // 行内最左端离页面的距离
            int intLeftCount = 0;

            //int intLeftCount = intLeftMargin + ( myLines.Count == 1 ? (int)TitleSize.Width : 0 ) ;
            //根据对齐方式来设置当前行的左端位置
            switch (intAlign)
            {
                case ParagraphAlignConst.Left:
                    intLeftCount = intLeftMargin;
                    break;
                case ParagraphAlignConst.Center:
                    intLeftCount = intLeftMargin + (LineWidth - allEleWidth) / 2;
                    break;
                case ParagraphAlignConst.Right:
                    intLeftCount = intLeftMargin + LineWidth - allEleWidth;
                    break;
                case ParagraphAlignConst.Justify:
                    intLeftCount = intLeftMargin;
                    break;
            }

            int intSpaceFix = 0; //每个字符间的距离
            int intSpaceFixCount = 0; //行剩余空白的总宽度

            //TODO: mfb 数字,英文自动折行,前一行分散对齐.  插入横线避免前一行分散对齐
            // 若本行中最后一个元素不是强制换行则将当前行的剩余空间平均分配到各个元素间的间距
            // -------------------(这里用来做两端分散对齐的功能)--------------------mfb
            if (LineElements.Count > 0 && (NewLine.HasLineEnd == false || intAlign == ParagraphAlignConst.Justify))
            {
                intSpaceFixCount = LineWidth - allEleWidth; // 总行宽-内容宽 = 空白宽               
                //空白款 / 元素个数 = 每个元素间的间距
                intSpaceFix = (int)System.Math.Ceiling((double)intSpaceFixCount / (double)(LineElements.Count - 1));
                //如果平均算下来,每个间距不足1,则设为1
                if (intSpaceFixCount > 0 && intSpaceFix < 1)
                    intSpaceFix = 1;
            }

            // 遍历所有的元素，计算元素在文本行内的左端位置和顶端位置
            foreach (ZYTextElement myElement in LineElements)
            {
                myElement.OwnerLine = NewLine;
                myElement.Left = intLeftCount;
                //--------计算每个元素的Y坐标位置,因为行的高度是由高度最高的元素决定的,
                //--------所以当碰到元素高度比行高度小的元素时,就需要减一下.
                myElement.Top = NewLine.Height - myElement.Height;


                #region add by myc 2014-07-18 添加原因：同一个文档行中的所有文本字符及回车符应该保持底端对齐（确保下划线处于同一水平位置）——>add by myc 2014-07-24 但是这种方式对ZYCheckBox无效，导致位置紊乱
                //if (myElement is ZYTextChar)
                //{
                //    Size charSize = TextRenderer.MeasureText(myElement.ToEMRString(), (myElement as ZYTextChar).Font);
                //    int realHeight = (int)Math.Ceiling(myOwnerDocument.OwnerControl.ClientToViewXRate * charSize.Height);
                //    if (myElement.Top + realHeight < NewLine.Height)
                //    {
                //        myElement.Top = NewLine.Height - realHeight;
                //    }

                //    //double realHeight = myOwnerDocument.OwnerControl.ClientToViewXRate * charSize.Height;
                //    //if (myElement.Top + realHeight < NewLine.Height)
                //    //{
                //    //    myElement.Top = (int)Math.Ceiling((double)NewLine.Height - realHeight);
                //    //}
                //}
                //else if (myElement is ZYTextEOF)
                //{
                //    Size charSize = TextRenderer.MeasureText("_", (myElement as ZYTextEOF).Font);
                //    int realHeight = (int)Math.Ceiling(myOwnerDocument.OwnerControl.ClientToViewXRate * charSize.Height);
                //    if (myElement.Top + realHeight < NewLine.Height)
                //    {
                //        myElement.Top = NewLine.Height - realHeight;
                //    }

                //    //double realHeight = myOwnerDocument.OwnerControl.ClientToViewXRate * charSize.Height;
                //    //if (myElement.Top + realHeight < NewLine.Height)
                //    //{
                //    //    myElement.Top = (int)Math.Ceiling((double)NewLine.Height - realHeight);
                //    //}
                //} 
                #endregion



                //修正，如果当前元素是一个回车符，且行高比它小，那么它的Top=0
                if (NewLine.Height < myElement.Height)
                {
                    myElement.Top = 0;
                }
                //myElement.Top		=  (NewLine.Height - myElement.Height)/2 ;
                myElement.WidthFix = 0;

                // ----------这里通过累加元素的宽度来计算每个元素的X坐标位置----------
                // 详见上面三行处的: myElement.Left = intLeftCount;
                intLeftCount += myElement.Width;

                if (intSpaceFix > 0 && myElement is ZYTextChar)
                {
                    intLeftCount += intSpaceFix;
                    myElement.WidthFix = intSpaceFix;
                    intSpaceFixCount -= intSpaceFix;
                    if (intSpaceFixCount <= 0)
                        intSpaceFix = 0;
                }
            }
            if (myParent == null && myOwnerDocument.Info.WordWrap == false && intWidth < intLeftCount)
                intWidth = intLeftCount;
            NewLine.RealIndex = NewLine.CalcuteRealIndex();

            return NewLine.Height;
        }

        #endregion

        #region 绘制文档的函数群 主要是RefreshView方法

        /// <summary>
        /// 刷新绘制文档的状态信息
        /// </summary>
        public virtual void ResetViewState()
        {
        }

        /// <summary>
        /// 绘制元素的背景
        /// </summary>
        /// <param name="myElement">要绘制背景的元素</param>
        public virtual void DrawBackGround(ZYTextElement myElement)
        {
            //myOwnerDocument.View.DrawBackGround(myElement.Left, myElement.Top + myElement.Height, myElement.Width, myElement.Height);
        }

        /// <summary>
        /// 获取完整的包含对象的最小矩形
        /// </summary>
        /// <returns>矩形对象</returns>
        public virtual System.Drawing.Rectangle GetContentBounds()
        {
            return new System.Drawing.Rectangle(this.RealLeft, this.RealTop, this.intClientWidth, this.Height);
        }

        /// <summary>
        /// 刷新界面,重新绘制对象
        /// </summary>
        /// <returns>是否进行了刷新操作</returns>
        public override bool RefreshView()
        {
            System.Drawing.Rectangle myRect = GetContentBounds();

            if (myOwnerDocument.isNeedDraw(myRect) && this.HasVisibleElement())
            {
                //遍历子容器的绘制状态
                foreach (ZYTextElement myElement in myChildElements)
                {
                    if (myElement is ZYTextContainer)
                    {
                        ((ZYTextContainer)myElement).ResetViewState();
                    }
                }

                System.Collections.ArrayList DrawList = new System.Collections.ArrayList();
                this.RefreshClientWidth();
                int intRealTop = this.RealTop; //容器的y坐标,基本不变
                int intRealLeft = this.RealLeft; //容器的x坐标,也基本不变
                //System.Drawing.Rectangle myViewRect = myOwnerDocument.View.ViewRect ;

                // 遍历所有的文本行对象
                foreach (ZYTextLine myLine in myLines)
                {
                    //myOwnerDocument.AutoPagingForTable(myLine, myLines, intRealTop); //add by myc 2014-05-29 添加原因：调用表格自动分页处理程序，实现表格跨页绘制——>2014-07-29 这种跨页应对复杂表格等等很难控制，毕竟分行、分页和建立坐标系都是一连串的连锁反应
                    //add by myc 2014-08-01 最终确立的二期表格跨页方案是在文档正文分页计算分页线时进行源头上的调整，RefreshView只负责绘制工作，不负责坐标以及位置修订工作

                    if (myLine.Container is ZYTextParagraph
                        && (myLine.Container as ZYTextParagraph).Parent is ZYTextDiv
                        && myLines.IndexOf(myLine) == myLines.Count - 1) //add by myc 2014-09-16 测试跳转用
                    {
                        int kk = 0;
                    }

                    // 计算文本行 的位置和大小
                    int vLineTop = intRealTop + myLine.Top;

                    //int vLineTop = myLine.RealTop; //add by myc 2014-09-19 表格跨页第三次改版需要——>绘制视图只做绘制工作，不再参与计算<——UpdateLinePosAfterNewPage
                    
                    int vLineHeight = myLine.Height;
                    int vLineLeft = myLine.RealLeft;

                    // 设置要高亮度绘制的区域的矩形对象
                    //System.Drawing.Rectangle HeightLightRect = new System.Drawing.Rectangle(0, vLineTop, 0, vLineHeight);
                    System.Drawing.Rectangle HeightLightRect = new System.Drawing.Rectangle(0, vLineTop, 0, myLine.FullHeight); //add by myc 2014-07-28 添加原因：文档行反色处理
                    
                    // 若当前行属于要绘制的区域则进行绘制
                    //if (myOwnerDocument.View.isNeedDrawY(vLineTop, vLineHeight))
                    if(myOwnerDocument.View.isNeedDrawY(myLine)) //add by myc 2014-08-01 添加原因：针对表格修正的判断绘制方法
                    {
                        foreach (ZYTextElement myElement in myLine.Elements)
                        {
                            bool bolDraw = false;

                            // 计算元素在视图区域中的位置和大小
                            int vLeft = vLineLeft + myElement.Left;
                            int vTop = vLineTop + myElement.Top;
                            int vWidth = myElement.Width + myElement.WidthFix;
                            int vHeight = myElement.Height;
                            // 若元素的水平位置在绘制区域中则绘制元素
                            if (myOwnerDocument.View.isNeedDrawX(vLeft, vWidth))
                            {
                                bolDraw = true;
                            }
                            if (myElement is ZYTextContainer)
                            {
                                System.Drawing.Rectangle br = (myElement as ZYTextContainer).GetContentBounds();
                                if (br.IsEmpty == false && myOwnerDocument.View.isNeedDrawX(br.Left, br.Width))
                                    bolDraw = true;
                            }
                            if (bolDraw)
                            {
                                myElement.Parent.DrawBackGround(myElement);
                                // 若对象为选中的元素则设置高亮度背景边框
                                if (myOwnerDocument.isSelected(myElement) && !(myElement is ZYTextImage))//#region bwy : 如果是图片，则不用绘制高亮度背
                                {
                                    if (HeightLightRect.Width == 0)
                                    {
                                        HeightLightRect.X = vLeft;
                                        HeightLightRect.Width = myElement.Width + myElement.WidthFix;

                                        //if (myElement is ZYTextEOF) //add by myc 2014-06-09 添加原因：如果当前（段落）文本行对象仅有一个回车符元素，则需更新高亮度背景宽度为默认的一个五号中文字符宽度
                                        //{
                                        //    HeightLightRect.Width = 43;
                                        //}
                                    }
                                    else
                                    {
                                        if (HeightLightRect.Left > vLeft)
                                            HeightLightRect.X = vLeft;
                                        if (HeightLightRect.Right < vLeft + myElement.Width + myElement.WidthFix)
                                            HeightLightRect.Width = vLeft + myElement.Width + myElement.WidthFix - HeightLightRect.Left;
                                    }
                                }
                                else
                                {
                                    // 若对象要绘制背景且文档设置允许绘制背景则绘制背景
                                    if (bolDrawBackGround && myOwnerDocument.Info.ShowMark)
                                    {
                                        // 绘制普通元素的背景
                                        //if( (myElement is ZYTextContainer)==false )
                                        //    myOwnerDocument.View.DrawBackGround( vLeft , vLineTop , vWidth ,  vLineHeight);
                                        //若对象的作者不是第一个作者则认为是新增的元素,用新增画刷绘制背景
                                        int intMakLevel = myOwnerDocument.GetMarkLevel(myElement.CreatorIndex);
                                        if (intMakLevel > 0)
                                        {
                                            if (myElement.CreatorIndex > 0 && myOwnerDocument.SaveLogs[myElement.CreatorIndex].Level > 0)//元素的创建者级别大于1时，才显示修改痕迹，否则不显示修改痕迹 Modified by wwj 2013-05-07
                                            {
                                                myOwnerDocument.DrawUnderLine(intMakLevel, vLeft, vTop, vWidth, vHeight);
                                            }
                                        }
                                        //else 
                                        if (myElement.isField() && myElement is ZYTextChar)
                                        {
                                            // 若对象是数据域则用数据域画刷绘制背景
                                            myOwnerDocument.View.DrawFieldBackGround(vLeft, vTop, vWidth, vHeight);
                                        }
                                    }
                                }
                                //myElement.Parent.DrawBackGround(myElement); //add by myc 2014-03-04 修改
                                //-------------------------调用每个元素的绘制方法,进行绘制.mfb---------------------
                                myElement.RefreshView();

                                if (myElement.Deleteted)
                                {
                                    myOwnerDocument.DrawDeleteLine(myOwnerDocument.GetMarkLevel(myElement.DeleterIndex), myElement.RealLeft, myElement.RealTop, myElement.Width, myElement.Height);
                                }
                            }
                        }

                        #region add by myc 2014-06-06 注释原因：单元格被选中时，内部元素不能再反色处理，干扰单元格本身反色处理
                        ////绘制高亮度背景
                        //if (HeightLightRect.Width > 0)
                        //{
                        //    if (myOwnerDocument.OwnerControl != null)
                        //    {
                        //        if (!myOwnerDocument.EnableSelectAreaPrint)//Add By wwj 2012-04-17 开启选中区域打印时关闭元素选中颜色翻转效果
                        //        {
                        //            myOwnerDocument.OwnerControl.ReversibleViewFillRect(HeightLightRect, myOwnerDocument.View.Graph);
                        //        }
                        //    }
                        //} 
                        #endregion

                        #region add by myc 2014-06-06 添加原因：拖选单元格（包括与其他文档元素或另一表格交叉）时的反色处理——>与Word类似
                        //if (!(this is TPTextCell) || (this is TPTextCell cell && !cell.跨页绘制反色区域是否已绘制))
                        myOwnerDocument.Content.HighlightSelectingArea(myLine, HeightLightRect);
                        #endregion

                    }// if
                }//foreach

                // 绘制边框
                //myBorder.Draw(myOwnerDocument.View, myRect); //add by myc 2014-09-16 注释原因：干扰表格内的单元格跨页绘制

                return true;
            }// if
            return false;
        }//bool RefreshView()
        #endregion

        #region 子元素列表操作的函数群 ************************************************************

        //		/// <summary>
        //		/// 获得指定元素的下一个元素
        //		/// </summary>
        //		/// <param name="refElement"></param>
        //		/// <returns></returns>
        //		public ZYTextElement NextElement( ZYTextElement refElement)
        //		{
        //			int Index = myChildElements.IndexOf( refElement );
        //			if( Index >= 0 && Index < myChildElements.Count -1 )
        //				return ( ZYTextElement ) myChildElements[Index + 1];
        //			else
        //				return null;
        //		}

        /// <summary>
        /// 清除所有的子元素
        /// </summary>
        public void ClearChild()
        {
            myChildElements.Clear();
            //AddLastElement();
        }// void ClearChild()

        /// <summary>
        /// 清除内部所有元素的保存记录
        /// </summary>
        public void ClearSaveLog()
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                myElement.Visible = true;
                if (myElement is ZYTextContainer)
                    (myElement as ZYTextContainer).ClearSaveLog();
                else
                {
                    myElement.DeleterIndex = -1;
                    //myElement.CreatorIndex = myOwnerDocument.SaveLogs.CurrentIndex;
                }
            }
        }
        /// <summary>
        /// 子元素集合
        /// </summary>
        public System.Collections.ArrayList ChildElements
        {
            get { return myChildElements; }
            set { myChildElements = value; }
        }

        /// <summary>
        /// 返回子元素集合的个数
        /// </summary>
        public int ChildCount
        {
            get { return myChildElements.Count; }
        }

        /// <summary>
        /// 获得元素在子元素集合中的从0开始的序号
        /// </summary>
        /// <param name="myElement">元素对象</param>
        /// <returns>序号</returns>
        public int IndexOf(ZYTextElement myElement)
        {
            return myChildElements.IndexOf(myElement);
        }
        /// <summary>
        /// 遍历所有子元素
        /// </summary>
        /// <param name="vHandler">遍历使用的委托</param>
        /// <param name="bolPreEnum">是否采用前序遍历</param>
        /// <returns></returns>
        public bool EnumChildElements(EnumElementHandler vHandler, bool bolPreEnum)
        {
            if (vHandler != null)
            {
                if (bolPreEnum) // 前序遍历
                {
                    if (vHandler(base.myParent, this) == false)
                        return false;
                }
                // 遍历子元素
                foreach (ZYTextElement myElement in myChildElements)
                {
                    if (myElement is ZYTextContainer) // 若子元素为容器元素则跳入其内部进行遍历
                    {
                        if ((myElement as ZYTextContainer).EnumChildElements(vHandler, bolPreEnum) == false)
                            return false;
                    }
                    else
                    {
                        if (vHandler(this, myElement) == false)
                            return false;
                    }
                }
                if (bolPreEnum == false) // 后序遍历
                {
                    if (vHandler(base.myParent, this) == false)
                        return false;
                }
                return true;
            }
            return false;
        }

        #region Contains
        /// <summary>
        /// 判断指定元素是否属于本容器
        /// </summary>
        /// <param name="vElement">指定的元素对象</param>
        /// <param name="Deep">是否进行子孙迭代查找</param>
        /// <returns>判断结果</returns>
        public bool Contains(ZYTextElement vElement, bool Deep)
        {
            if (vElement == null)
                return false;
            if (myChildElements.Contains(vElement))
                return true;
            if (Deep)
            {
                foreach (ZYTextElement myElement in myChildElements)
                {
                    if ((myElement as ZYTextContainer) != null)
                    {
                        if ((myElement as ZYTextContainer).Contains(vElement, Deep))
                            return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 判断指定的若干个元素是否都属于本容器
        /// </summary>
        /// <param name="myList">保存元素的列表对象</param>
        /// <returns>是否都属于本容器</returns>
        public bool ContainsElements(System.Collections.ArrayList myList)
        {
            if (myList != null && myList.Count > 0)
            {
                foreach (ZYTextElement obj in myList)
                    if (myChildElements.Contains(obj) == false && obj != this)
                        return false;
                return true;
            }
            return false;
        }// bool ContainsElements()

        #endregion

        #region virtual method

        #region 添加(Add)
        /// <summary>
        /// 无条件的将所有子元素添加到列表中
        /// </summary>
        /// <param name="myList"></param>
        public virtual void AddElementToListAbs(System.Collections.ArrayList myList)
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                myList.Add(myElement);
                if (myElement is ZYTextContainer)
                    (myElement as ZYTextContainer).AddElementToListAbs(myList);
            }
        }

        /// <summary>
        /// 将容器内所有的元素添加到列表对象中
        /// </summary>
        /// <param name="myList">列表对象</param>
        /// <param name="ResetFlag">是否重置元素的状态</param>
        public virtual void AddElementToList(System.Collections.ArrayList myList, bool ResetFlag)
        {
            if (myList != null)
            {
                //myList.Add(myBlank);
                foreach (ZYTextElement myElement in myChildElements)
                {
                    if (ResetFlag)
                    {
                        myElement.Visible = false;
                        myElement.Index = -1;
                    }
                    if (myOwnerDocument.isVisible(myElement))
                    {
                        if (!(myElement is ZYTextContainer))
                        {
                            myList.Add(myElement);
                        }
                        else
                        {
                            myElement.Visible = true;
                            (myElement as ZYTextContainer).AddElementToList(myList, ResetFlag);
                        }
                    }
                }
            }
        }

        





        /// <summary>
        /// 保存所有最终元素(没有标记为逻辑删除的元素)到一个列表中
        /// </summary>
        /// <param name="myList"></param>
        public virtual void AddFinalElementToList(System.Collections.ArrayList myList)
        {
            if (myList != null)
            {
                foreach (ZYTextElement myElement in myChildElements)
                {
                    if (myElement.Deleteted == false)
                    {
                        if (myElement is ZYTextContainer)
                            (myElement as ZYTextContainer).AddFinalElementToList(myList);
                        else
                            myList.Add(myElement);
                    }
                }
            }
        }
        /// <summary>
        /// 添加一个子元素
        /// </summary>
        /// <param name="newElement">新增的元素</param>
        public virtual bool AppendChild(ZYTextElement newElement)
        {
            if (bolChildElementsLocked) return false;
            if (newElement != null && myChildElements.Contains(newElement) == false)
            {
                if (newElement.Parent != null)
                    newElement.Parent.RemoveChild(newElement);
                myChildElements.Add(newElement);
                newElement.Parent = this;
                newElement.OwnerDocument = myOwnerDocument;
                this.OnChildElementsChange();
                return true;
            }
            return false;
        }

        #endregion

        #region 删除(Remove)
        /// <summary>
        /// 删除一个子元素
        /// </summary>
        /// <param name="refElement">要删除的子元素</param>
        /// <returns>删除操作是否成功</returns>
        public virtual bool RemoveChild(ZYTextElement refElement)
        {
            if (bolChildElementsLocked) return false;
            //if (this.Locked == false && refElement != null && myChildElements.Contains(refElement) && refElement != myLastElement)

            /**********Modified by wwj 2013-01-19***********
            if (this.Locked == false && refElement != null && myChildElements.Contains(refElement))
            {
                if (myOwnerDocument.CanContentChangeLog)
                {
                    myOwnerDocument.ContentChangeLog.Container = this;
                    #region bwy 如果元素是段
                    int myindex = myChildElements.IndexOf(refElement);
                    //if (refElement is ZYTextParagraph)
                    //{
                    //    myindex++;
                    //}

                    #endregion bwy
                    myOwnerDocument.ContentChangeLog.LogRemove(myindex, refElement);
                }
                myChildElements.Remove(refElement);
                this.OnChildElementsChange();
                //refElement.Parent = null;
                return true;
            }
            return false;
            ***********************************************/

            /**********Add by wwj 2013-01-21***********/
            if (this.Locked == false && refElement != null)
            {
                m_IsContainElements = false;//判断标志位，确定refElement是否包含在myChildElements集合中
                CheckContainElements(myChildElements, refElement);
                if (m_IsContainElements)
                {
                    if (myOwnerDocument.CanContentChangeLog)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        int myindex = myChildElements.IndexOf(refElement);
                        myOwnerDocument.ContentChangeLog.LogRemove(myindex, refElement);
                    }
                    RemoveElement(myChildElements, refElement);
                    this.OnChildElementsChange();
                    return true;
                }
            }
            return false;
            /**********************************************/
        }

        #region 使用递归方式判断和删除子孙节点 Add by wwj 2013-01-21
        /// <summary>
        /// 判断element节点是否是elements节点的子孙节点
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="element"></param>
        public void CheckContainElements(ArrayList elements, ZYTextElement element)
        {
            if (elements.Contains(element))
            {
                m_IsContainElements = true;
            }
            else
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    ZYTextContainer container = elements[i] as ZYTextContainer;
                    if (container != null)
                    {
                        CheckContainElements(container.ChildElements, element);
                    }
                }
            }
        }
        bool m_IsContainElements;//只提供给CheckContainElements函数使用，使用前注意重置，即m_IsContainElements = false;

        /// <summary>
        /// 移除elements节点下的element节点
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="element"></param>
        public void RemoveElement(ArrayList elements, ZYTextElement element)
        {
            if (elements.Contains(element))
            {
                elements.Remove(element);
                return;
            }
            else
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    ZYTextContainer container = elements[i] as ZYTextContainer;
                    if (container != null)
                    {
                        RemoveElement(container.ChildElements, element);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 删除对象中的空白行
        /// </summary>
        /// <returns>删除的元素个数</returns>
        public virtual int RemoveBlankLine()
        {
            int DeleteCount = 0;
            for (int iCount = 0; iCount < myChildElements.Count - 1; iCount++)
            {
                ZYTextElement myElement = (ZYTextElement)myChildElements[iCount];
                if (myElement is ZYTextParagraph && myElement.OwnerLine.Elements.Count == 1)
                {
                    //myOwnerDocument.BeginContentChangeLog();
                    //myOwnerDocument.ContentChangeLog.Container = this;
                    //myOwnerDocument.ContentChangeLog.LogRemove(iCount, myElement);
                    //myOwnerDocument.EndContentChangeLog();
                    DeleteCount++;
                    iCount--;
                }
                else if (myElement is ZYTextContainer)
                {
                    DeleteCount += (myElement as ZYTextContainer).RemoveBlankLine();
                }
            }//for
            return DeleteCount;
        }// public virtual int RemoveBlankLine( )

        /// <summary>
        /// 删除无内容的关键字数据域及其周围的字符
        /// </summary>
        /// <param name="ContentLog">是否保存删除记录</param>
        /// <returns>删除的元素个数</returns>
        public virtual int RemoveBlankKeyField2(bool ContentLog)
        {
            System.Collections.ArrayList myKeyField = new System.Collections.ArrayList();
            System.Collections.ArrayList vElements = new System.Collections.ArrayList();
            int DeleteCount = 0;
            bool EnableFix = true;
            int FieldCount = 0;
            for (int ElementCount = 0; ElementCount < myChildElements.Count; ElementCount++)
            {
                // 进行判别修正的标志位
                bool bolFix = false;
                ZYTextElement myElement = (ZYTextElement)myChildElements[ElementCount];

                if (IsLastElement(myElement))
                {
                    bolFix = true;
                }
                else if (myElement is ZYTextChar)
                {
                    // 若当前元素为一个字符且表示一个符号则进行修正
                    ZYTextChar myChar = (ZYTextChar)myElement;
                    if (myChar.IsSymbol())
                    {
                        if (vElements.Count > 0)
                        {
                            bolFix = true;
                        }
                    }
                    vElements.Add(myElement);
                }
                else if (myElement is ZYTextBlock)
                {
                    // 若当前为一个数据输入域则判别是否允许修正
                    // 若数据输入域不为关键字域或有实际内容则不会修正
                    ZYTextBlock myBlock = (ZYTextBlock)myElement;
                    if (myBlock.KeyField == false || StringCommon.HasContent(myBlock.ToEMRString()))
                    {
                        EnableFix = false;
                    }
                    FieldCount++;
                    vElements.Add(myElement);
                }
                else if (myElement is ZYTextContainer)
                {
                    // 若为容器对象则进入对象进行处理
                    DeleteCount += ((ZYTextContainer)myElement).RemoveBlankKeyField2(ContentLog);
                    continue;
                }
                else // 若为其他类型的元素则进行修正
                    bolFix = true;

                if (bolFix)
                {
                    if (vElements.Count > 0 && EnableFix && FieldCount > 0)
                    {
                        ZYTextChar StartChar = vElements[0] as ZYTextChar;
                        ZYTextChar EndChar = vElements[vElements.Count - 1] as ZYTextChar;
                        if (vElements.Count > 1)
                        {
                            if (StartChar != null && EndChar != null)
                            {
                                int L1 = StringCommon.GetSymbolSplitLevel(StartChar.Char);
                                int L2 = StringCommon.GetSymbolSplitLevel(EndChar.Char);
                                if (L1 != 0 && L2 != 0)
                                {
                                    vElements.RemoveAt(L1 < L2 ? vElements.Count - 1 : 0);
                                }
                            }
                        }
                        if (vElements.Count > 0)
                        {
                            int StartIndex = myChildElements.IndexOf(vElements[0]);
                            if (ContentLog)
                            {
                                myOwnerDocument.BeginContentChangeLog();
                                myOwnerDocument.ContentChangeLog.Container = this;
                                myOwnerDocument.ContentChangeLog.LogRemoveRange(StartIndex, vElements);
                                myOwnerDocument.EndContentChangeLog();
                            }
                            myChildElements.RemoveRange(StartIndex, vElements.Count);
                            DeleteCount += vElements.Count;
                            ElementCount = StartIndex - 1;
                        }
                    }//if
                    FieldCount = 0;
                    vElements.Clear();
                    EnableFix = true;
                }
            }//for
            return DeleteCount;
        }//public virtual int RemoveBlankKeyField2( bool ContentLog )

        /// <summary>
        /// 删除所有的空白的关键字数据域及其周围的字符
        /// </summary>
        /// <param name="ContentLog">是否记录删除操作</param>
        /// <returns>删除的元素个数</returns>
        public virtual int RemoveBlankKeyField(bool ContentLog)
        {
            System.Collections.ArrayList myKeyField = new System.Collections.ArrayList();
            int DeleteCount = 0;
            for (int ElementCount = 0; ElementCount < myChildElements.Count; ElementCount++)
            {
                ZYTextElement myElement = (ZYTextElement)myChildElements[ElementCount];
                if (myElement.Deleteted == false && myElement is ZYTextBlock)
                {
                    ZYTextBlock myBlock = (ZYTextBlock)myElement;
                    // 该数据域为关键数据域且内容为空则进行删除
                    if (myBlock.KeyField && StringCommon.isBlankString(myBlock.ToEMRString()))
                    {
                        // 计算该关键字域周围的字符的起始和终止序号
                        int StartIndex = 0;
                        int EndIndex = myChildElements.Count - 2;
                        // 要删除区域的起始字符对象和结尾字符对象
                        ZYTextChar StartChar = null;
                        ZYTextChar EndChar = null;
                        for (int iCount = myChildElements.IndexOf(myBlock); iCount < myChildElements.Count; iCount++)
                        {
                            if (myChildElements[iCount] is ZYTextChar && ((ZYTextChar)myChildElements[iCount]).IsSymbol())
                            {
                                EndIndex = iCount;
                                EndChar = (ZYTextChar)myChildElements[iCount];
                                break;
                            }
                        }//for
                        for (int iCount = myChildElements.IndexOf(myBlock); iCount >= 0; iCount--)
                        {
                            if (myChildElements[iCount] is ZYTextChar && ((ZYTextChar)myChildElements[iCount]).IsSymbol())
                            {
                                StartIndex = iCount;
                                StartChar = (ZYTextChar)myChildElements[iCount];
                                break;
                            }
                        }//for
                        bool bolDeleteEnd = true;
                        if (StartChar != null && EndChar != null)
                        {
                            if (StringCommon.GetSymbolSplitLevel(StartChar.Char) < StringCommon.GetSymbolSplitLevel(EndChar.Char))
                                bolDeleteEnd = false;
                        }
                        if (bolDeleteEnd)
                            StartIndex++;
                        else
                            EndIndex--;
                        if (EndIndex >= StartIndex)
                        {
                            if (ContentLog)
                                myOwnerDocument.BeginContentChangeLog();
                            if (myOwnerDocument.CanContentChangeLog)
                                myOwnerDocument.ContentChangeLog.Container = this;
                            for (int iCount = StartIndex; iCount <= EndIndex; iCount++)
                            {
                                if (myOwnerDocument.CanContentChangeLog)
                                {
                                    myOwnerDocument.ContentChangeLog.LogRemove(StartIndex, (ZYTextElement)myChildElements[StartIndex]);
                                }
                                myChildElements.RemoveAt(StartIndex);
                                DeleteCount++;
                            }
                            if (ContentLog)
                                myOwnerDocument.EndContentChangeLog();
                            ElementCount = StartIndex - 1;
                        }
                    }//if
                }//if
                else if (myElement is ZYTextContainer)
                {
                    DeleteCount += ((ZYTextContainer)myElement).RemoveBlankKeyField(ContentLog);
                }
            }//for
            return DeleteCount;
        }//public int RemoveBlankKeyField( bool ContentLog)

        /// <summary>
        /// 删除一批子元素
        /// </summary>
        /// <param name="myList">包含元素的列表对象</param>
        /// <returns>删除的元素个数</returns>
        public virtual int RemoveChildRange(System.Collections.ArrayList myList)
        {
            if (bolChildElementsLocked) return 0;
            int DeleteCount = 0;
            if (this.Locked == false && myList != null && myList.Count > 0)
            {
                //ZYTextElement ele;
                //int length = myList.Count;
                //foreach (ZYTextElement myElement in myList)
                //for (int i = length -1; i >=0; i--)
                //{
                //    ele = myList[i] as ZYTextElement;
                //    //if (myChildElements.Contains(myElement) && myElement != myLastElement)
                //    if (myChildElements.Contains(ele))
                //    {
                if (myOwnerDocument.CanContentChangeLog)
                {
                    myOwnerDocument.ContentChangeLog.Container = this;
                    //myOwnerDocument.ContentChangeLog.LogRemove(myChildElements.IndexOf(myElement), myElement);
                    myOwnerDocument.ContentChangeLog.LogRemoveRange(myChildElements.IndexOf(myList[0]), myList);

                }
                //        myChildElements.Remove(ele);
                //        DeleteCount++;
                //    }
                //}// foreach

                //add  by zhouhui
                if (myChildElements.IndexOf(myList[0]) > -1)
                {
                    //add by wwj 2012-04-24 增加长度判断的限制，防止出错
                    myChildElements.RemoveRange(myChildElements.IndexOf(myList[0]), myChildElements.Count < myList.Count ? myChildElements.Count : myList.Count);
                }

                //if (DeleteCount > 0)
                //{
                this.OnChildElementsChange();
                //}
            }
            // add by myc 2014-06-16 添加原因：执行删除动作时，即便没有删除任何元素，也要记录下此动作，进入撤销堆栈
            else if (this.Locked == false && myList != null && myList.Count == 0 && System.Math.Abs(myOwnerDocument.Content.SelectLength) >= 1)
            {
                if (myOwnerDocument.CanContentChangeLog)
                {
                    myOwnerDocument.ContentChangeLog.Container = this;
                    //myOwnerDocument.ContentChangeLog.LogRemove(myChildElements.IndexOf(myElement), myElement);
                    //myOwnerDocument.ContentChangeLog.LogRemoveRange();

                }
            }



            return DeleteCount;
        }// bool RemoveChildRange

        #endregion

        #region 插入(Insert)
        /// <summary>
        /// 在插入子元素前对将要插入的元素进行检查来判断是否可以插入
        /// </summary>
        /// <param name="NewElement">将要插入的元素对象</param>
        /// <returns>是否可以插入新元素</returns>
        protected virtual bool BeforeInsert(ZYTextElement NewElement)
        {
            if (bolChildElementsLocked) return false;
            if (bolContainTextOnly && !(NewElement is ZYTextChar))
                return false;
            return myOwnerDocument.BeforeInsertElemnt(this, NewElement);
        }//bool BeforeInsert()

        /// <summary>
        /// 在指定元素前插入新的元素
        /// </summary>
        /// <param name="NewElement">新增的元素</param>
        /// <param name="refElement">旧的元素</param>
        /// <returns>操作是否成功</returns>
        public virtual bool InsertBefore(ZYTextElement NewElement, ZYTextElement refElement)
        {
            #region bwy 如果是在回车符前插入元素，那么清空它的字体大小属性
            //if (refElement is ZYTextEOF) //add by myc 2014-07-17 注释原因：新版字体属性控制需要
            //{
            //    (refElement as ZYTextEOF).FontSize = this.OwnerDocument.View.DefaultFont.Size;
            //    (refElement as ZYTextEOF).Attributes.Clear();
            //    refElement.RefreshSize();
            //}

            #endregion bwy
            if (bolChildElementsLocked) return false;
            if (NewElement == null || this.Locked)
                return false;
            if (BeforeInsert(NewElement))
            {
                if (myChildElements.Contains(NewElement))
                    myChildElements.Remove(NewElement);
                if (refElement != null && myChildElements.Contains(refElement))
                {
                    int index = myChildElements.IndexOf(refElement);
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        myOwnerDocument.ContentChangeLog.LogInsert(index, NewElement);
                    }
                    myChildElements.Insert(index, NewElement);
                }
                else
                {
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        myOwnerDocument.ContentChangeLog.LogAdd(NewElement);
                    }
                    myChildElements.Add(NewElement);
                }
                NewElement.Parent = this;
                NewElement.OwnerDocument = myOwnerDocument;
                NewElement.RefreshSize();
                NewElement.Visible = true;
                this.OnChildElementsChange();
                return true;
            }
            return false;
        }// bool InsertBefore
        public virtual bool InsertAfter(ZYTextElement NewElement, ZYTextElement refElement)
        {
            if (bolChildElementsLocked) return false;
            if (NewElement == null || this.Locked)
                return false;
            if (BeforeInsert(NewElement))
            {
                if (myChildElements.Contains(NewElement))
                    myChildElements.Remove(NewElement);
                if (refElement != null && myChildElements.Contains(refElement))
                {
                    int index = myChildElements.IndexOf(refElement);
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        //myOwnerDocument.ContentChangeLog.LogInsert(index, NewElement);
                        #region bwy
                        myOwnerDocument.ContentChangeLog.LogInsert(index + 1, NewElement);
                        #endregion bwy
                    }

                    myChildElements.Insert(index + 1, NewElement);
                }
                else
                {
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        myOwnerDocument.ContentChangeLog.LogAdd(NewElement);
                    }
                    myChildElements.Add(NewElement);
                }

                #region 2019.7.30-hdf-添加原因：宏元素在文书录入时需要允许修改
                if (this is ZYMacro || this is ZYReplace || this is ZYFormatString || this is ZYDiag || this is ZYSubject)
                {
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        myOwnerDocument.ContentChangeLog.LogField(this, this.GetType().GetField("text"), (this as ZYTextBlock).text, ZYTextElement.GetElementsText(this.ChildElements));
                    }
                    (this as ZYTextBlock).text = ZYTextElement.GetElementsText(this.ChildElements);
                }
                #endregion

                NewElement.Parent = this;
                NewElement.OwnerDocument = myOwnerDocument;
                NewElement.RefreshSize();
                NewElement.Visible = true;
                this.OnChildElementsChange();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 在指定的元素后插入一些新的元素
        /// </summary>
        /// <param name="myList">保存新插入的元素的列表对象</param>
        /// <param name="refElement">从参照的对象</param>
        /// <returns>操作是否成功</returns>
        public virtual bool InsertRangeBefore(System.Collections.ArrayList myList, ZYTextElement refElement)
        {
            if (bolChildElementsLocked) return false;
            if (myList == null || this.Locked)
                return false;
            //将可以插入的元素全部添加到 InsertList 中.
            System.Collections.ArrayList InsertList = new System.Collections.ArrayList();
            foreach (ZYTextElement myElement in myList)
            {
                if (this.BeforeInsert(myElement))
                {
                    InsertList.Add(myElement);
                    myElement.Visible = true;
                }
            }
            //如果不为空
            if (InsertList.Count > 0)
            {

                //if (refElement == null)
                //    refElement = myLastElement;

                //如果refElement不为空,则插入到该元素的前面. 否则如果为空,则添加到末尾
                if (refElement != null && myChildElements.Contains(refElement))
                {
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        myOwnerDocument.ContentChangeLog.LogInsertRange(myChildElements.IndexOf(refElement), InsertList);
                    }
                    myChildElements.InsertRange(myChildElements.IndexOf(refElement), InsertList);
                }
                else
                {
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        myOwnerDocument.ContentChangeLog.LogAddRang(InsertList);
                    }
                    myChildElements.AddRange(InsertList);
                }
                foreach (ZYTextElement myElement in InsertList)
                {
                    myElement.Parent = this;
                    myElement.OwnerDocument = myOwnerDocument;
                    //if (myOwnerDocument.Loading == false)
                    //{
                    //myElement.CreatorIndex = myOwnerDocument.UserList.CurrentIndex;
                    //myElement.CreateTime = StringCommon.GetNowString12();
                    //}
                    myElement.RefreshSize();
                }

                #region 2019.7.30-hdf-添加原因：宏元素在文书录入时需要允许修改
                if (this is ZYMacro || this is ZYReplace || this is ZYFormatString || this is ZYDiag || this is ZYSubject)
                {
                    if (myOwnerDocument.ContentChangeLog != null)
                    {
                        myOwnerDocument.ContentChangeLog.Container = this;
                        myOwnerDocument.ContentChangeLog.LogField(this, this.GetType().GetField("text"), (this as ZYTextBlock).text, ZYTextElement.GetElementsText(this.ChildElements));
                    }
                    (this as ZYTextBlock).text = ZYTextElement.GetElementsText(this.ChildElements);
                }
                #endregion

                this.OnChildElementsChange();
            }

            return true;
        }// bool InsertRangeBefore
        #endregion

        #region 添加结构化的名称和值数据
        /// <summary>
        /// 添加结构化的名称和值数据
        /// </summary>
        /// <param name="myKeyValues"></param>
        /// <returns>新增的名称和值对的个数</returns>
        public virtual int AppendKeyValueList(System.Collections.ArrayList myKeyValues)
        {
            return 0;
        }
        #endregion
        #region 内容改变事件
        /// <summary>
        /// 触发元素内容修改事件
        /// </summary>
        public virtual void RaiseOnChangeEvent()
        {
            if (myOwnerDocument.OwnerControl != null && myOwnerDocument.Loading == false)
            {
                //myOwnerDocument.InitEventObject(ZYVBEventType.OnChange);
                //myOwnerDocument.EventObj.Source = this;
                //myOwnerDocument.RunEventScript(this, "onchange");
            }
        }

        /// <summary>
        /// 子元素集合发生改变时的处理
        /// </summary>
        protected virtual void OnChildElementsChange()
        {
            this.RaiseOnChangeEvent();
        }
        #region
        #endregion
        #endregion

        #region 获取(Get)
        /// <summary>
        /// 获取所有的可见元素
        /// </summary>
        /// <returns></returns>
        public virtual System.Collections.ArrayList GetVisibleElements()
        {
            System.Collections.ArrayList myElements = new System.Collections.ArrayList();
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (myElement.Visible)
                    myElements.Add(myElement);
            }
            return myElements;
        }

        /// <summary>
        /// 获取容器中所有的元素的文本EMRString
        /// </summary>
        /// <param name="myStr"></param>
        public virtual void GetFinalText(System.Text.StringBuilder myStr)
        {
            System.Collections.ArrayList myElements = new System.Collections.ArrayList();
            foreach (ZYTextElement myElement in myChildElements)
                if (myElement.Deleteted == false)
                    myElements.Add(myElement);
            FixForKeyField(myElements);
            foreach (ZYTextElement myElement in myElements)
            {
                if (myElement.isTextElement())
                    myStr.Append(myElement.ToEMRString());
                else if (myElement is ZYTextContainer)
                {
                    (myElement as ZYTextContainer).GetFinalText(myStr);
                }
            }
        }
        /// <summary>
        /// 获得本容器中第一个非容器元素
        /// </summary>
        /// <returns></returns>
        public virtual ZYTextElement GetFirstElement()
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                if ((myElement as ZYTextContainer) == null)
                    return myElement;
                else
                {
                    ZYTextElement first = (myElement as ZYTextContainer).GetFirstElement();
                    if (first != null)
                        return first;
                }
            }
            return null;
        }
        /// <summary>
        /// 获得本容器中最后一个元素
        /// </summary>
        /// <returns></returns>
        public virtual ZYTextElement GetLastElement()
        {
            //return myLastElement;
            for (int iCount = myChildElements.Count - 1; iCount >= 0; iCount--)
            {
                ZYTextElement myElement = myChildElements[iCount] as ZYTextElement;
                if ((myElement as ZYTextContainer) != null)
                {
                    return (myElement as ZYTextContainer).GetLastElement();
                }
                else
                {
                    return myElement;
                }
            }
            return null;
        }
        #endregion


        #endregion

        /// <summary>
        /// 判断指定元素是否为本容器的最后一个元素
        /// </summary>
        /// <param name="vElement">元素对象</param>
        /// <returns>是否是最后一个元素,该元素一般是不能删除的</returns>
        protected virtual bool IsLastElement(ZYTextElement vElement)
        {
            return (vElement == myChildElements[myChildElements.Count - 1]);
        }

        /// <summary>
        /// 判断是否存在可以显示的元素
        /// </summary>
        /// <returns></returns>
        public bool HasVisibleElement()
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (myElement.Visible)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据关键预的内容删除不需要的元素
        /// </summary>
        /// <param name="myElements">元素列表</param>
        /// <returns>根据需要删除的元素个数</returns>
        public int FixForKeyField(System.Collections.ArrayList myElements)
        {
            int DeleteCount = 0;
            for (int iCount = 0; iCount < myElements.Count; iCount++)
            {
                if (myElements[iCount] is ZYTextBlock)
                {
                    ZYTextBlock myBlock = (ZYTextBlock)myElements[iCount];
                    if (myBlock.KeyField)
                    {
                        if (StringCommon.isBlankString(myBlock.ToEMRString()))
                        {
                            for (int iCount2 = iCount + 1; iCount2 < myElements.Count; iCount2++)
                            {
                                if (myElements[iCount2] is ZYTextChar)
                                {
                                    if (((ZYTextChar)myElements[iCount2]).IsSymbol())
                                    {
                                        myElements.RemoveRange(iCount + 1, iCount2 - iCount);
                                        DeleteCount += iCount2 - iCount - 1;
                                        break;
                                    }
                                }
                                else
                                    break;
                            }//for
                            for (int iCount2 = iCount - 1; iCount2 >= 0; iCount2--)
                            {
                                if (myElements[iCount2] is ZYTextChar)
                                {
                                    if (((ZYTextChar)myElements[iCount2]).IsSymbol())
                                    {
                                        myElements.RemoveRange(iCount2 + 1, iCount - iCount2 - 1);
                                        DeleteCount += iCount - iCount2 + 1;
                                        break;
                                    }
                                }
                                else
                                    break;
                            }//for
                        }
                    }//if
                }//if
            }//for
            return DeleteCount;
        }

        #endregion

        #region 对象和XML节点交流数据的函数群 *****************************************************

        /// <summary>
        /// 已重载:从XML节点加载对象数据
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            System.Xml.XmlElement NewElement = null;
            //if (StringCommon.isBlankString(myAttributes.GetString(ZYTextConst.c_ID)))
            //{
            //    myAttributes.SetValue(ZYTextConst.c_ID, StringCommon.AllocObjectName());
            //}
            switch (myOwnerDocument.Info.SaveMode)
            {
                case 0: // 保存所有数据
                    ZYTextElement LastElement = null;
                    ZYTextChar LastChar = null;
                    ZYTextChar myChar = null;
                    myAttributes.ToXML(myElement); //为text元素设置属性
                    //保存所有元素的文本形式,这里先注释
                    //if (myOwnerDocument.Info.SavePreViewText) 
                    //{
                    //    System.Collections.ArrayList myFinalList2 = new System.Collections.ArrayList();
                    //    this.AddFinalElementToList(myFinalList2);
                    //    string strText2 = ZYTextElement.GetElementsText(myFinalList2);
                    //    NewElement = myElement.OwnerDocument.CreateElement(ZYTextConst.c_Text);
                    //    myElement.AppendChild(NewElement);
                    //    NewElement.InnerText = strText2;
                    //}
                    bool bolAdd;
                    foreach (ZYTextElement myE in myChildElements)
                    {
                        #region bwy : 如果是除字符之外的元素 0----新增的牙齿检查 , Modified By wwj 2013-08-01 增加导出ZYFlag类型的XML
                        if (myE is ZYMensesFormula || myE is ZYHorizontalLine || myE is ZYButton || myE is ZYCheckBox || myE is ZYPageEnd || myE is ZYToothCheck || myE is ZYFlag)
                        {
                            NewElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                            myElement.AppendChild(NewElement);
                            myE.ToXML(NewElement);
                            LastChar = null;
                            continue;
                        }

                        #endregion bwy :
                        bolAdd = false;
                        myChar = myE as ZYTextChar;
                        if (myChar == null)
                        {
                            LastChar = null;
                        }
                        else
                        {
                            //如果前后两个字符的属性相同,则将此次的字符加入到上一个字符所在的span里
                            //否则创建一个新的span元素
                            if (LastChar != null && LastChar.Attributes.EqualsValue(myChar.Attributes))
                            {
                                myChar.AppendToXML(NewElement);
                                bolAdd = true;
                            }
                            LastChar = myChar;
                        }
                        if (bolAdd == false)
                        {
                            string strName = myE.GetXMLName();
                            if (strName != null)
                            {
                                NewElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                                myElement.AppendChild(NewElement);
                                myE.ToXML(NewElement);
                                LastElement = myE;
                            }
                        }
                    }
                    break;
                #region case 1 2 3
                case 1: // 保存纯文本数据
                    //myElement.SetAttribute(ZYTextConst.c_Name, myAttributes.GetString(ZYTextConst.c_Name));
                    //foreach (ZYTextElement myE in myChildElements)
                    //{
                    //    if (myE.DeleterIndex < 0)
                    //    {
                    //        if (myE is ZYTextChar || myE is ZYTextParagraph || myE is ZYTextLineEnd)
                    //        {
                    //            myElement.AppendChild(myElement.OwnerDocument.CreateTextNode(myE.ToEMRString()));
                    //            //myE.ToXML( myElement );
                    //        }
                    //        else if (myE.isField() && myE.GetXMLName() != null)
                    //        {
                    //            NewElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                    //            myElement.AppendChild(NewElement);
                    //            myE.ToXML(NewElement);
                    //        }
                    //    }
                    //}
                    break;
                case 2: // 只保存结构化数据
                    //myElement.SetAttribute(ZYTextConst.c_Name, myAttributes.GetString(ZYTextConst.c_Name));
                    //foreach (ZYTextElement myE in myChildElements)
                    //{
                    //    if (myE.DeleterIndex < 0)
                    //    {
                    //        if (myE.isField() && myE.GetXMLName() != null)
                    //        {
                    //            NewElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                    //            myElement.AppendChild(NewElement);
                    //            myE.ToXML(NewElement);
                    //        }
                    //    }
                    //}
                    break;
                case 3: // 保存纯文本数据
                    System.Collections.ArrayList myFinalList = new System.Collections.ArrayList();
                    this.AddFinalElementToList(myFinalList);
                    string strText = ZYTextElement.GetElementsText(myFinalList);
                    NewElement = myElement.OwnerDocument.CreateElement(ZYTextConst.c_Text);
                    myElement.AppendChild(NewElement);
                    NewElement.InnerText = strText;
                    foreach (ZYTextElement myE in myChildElements)
                    {
                        if (myE.DeleterIndex < 0)
                        {
                            if (myE.isField())
                            {
                                if (StringCommon.isBlankString(myE.Attributes.GetString(ZYTextConst.c_ID)))
                                    myE.Attributes.SetValue(ZYTextConst.c_ID, StringCommon.AllocObjectName());
                                NewElement = myElement.OwnerDocument.CreateElement(myE.Attributes.GetString(ZYTextConst.c_ID));
                                myElement.AppendChild(NewElement);
                                myE.ToXML(NewElement);
                            }
                        }
                    }
                    //					myElement.SetAttribute(ZYTextConst.c_Name , myAttributes.GetString(ZYTextConst.c_Name ));
                    //					foreach(ZYTextElement myE in myChildElements)
                    //					{
                    //						if( myE.Deleter < 0 )
                    //						{
                    //							if( myE is ZYTextChar || myE is ZYTextParagraph || myE is ZYTextLineEnd )
                    //							{
                    //								myElement.AppendChild( myElement.OwnerDocument.CreateTextNode( myE.ToEMRString()));
                    //								//myE.ToXML( myElement );
                    //							}
                    //							else if( myE.isField() && myE.GetXMLName() != null)
                    //							{
                    //								NewElement = myElement.OwnerDocument.CreateElement( myE.GetXMLName());
                    //								myElement.AppendChild( NewElement );
                    //								myE.ToXML( NewElement );
                    //							}
                    //						}
                    //					}
                    break;
                #endregion
                default:
                    return false;
            }
            return true;
        }

        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (base.FromXML(myElement))
            {
                myChildElements.Clear();
                System.Collections.ArrayList NewList = new System.Collections.ArrayList();
                myOwnerDocument.LoadElementsToList(myElement, NewList);
                this.InsertRangeBefore(NewList, null);
                //AddLastElement();
                foreach (ZYTextElement e in myChildElements)
                    e.Parent = this;
                strID = myAttributes.GetString(ZYTextConst.c_ID);
                strName = myAttributes.GetString(ZYTextConst.c_Name);
                return true;
            }
            return false;
        }

        public override void UpdateAttrubute()
        {
            strID = myAttributes.GetString(ZYTextConst.c_ID);
            strName = myAttributes.GetString(ZYTextConst.c_Name);
        }

        #endregion

        #region 用户界面上的鼠标事件处理 **********************************************************

        /// <summary>
        /// 已重载:处理鼠标单击事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的Y坐标</param>
        /// <param name="Button">鼠标按钮</param>
        /// <returns>是否处理了本次事件</returns>
        public override bool HandleClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (myElement.Visible && myElement.Deleteted == false && myElement.HandleClick(x, y, Button))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 已重载:处理鼠标双击事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的Y坐标</param>
        /// <param name="Button">鼠标按钮</param>
        /// <returns>是否处理了本次事件</returns>
        public override bool HandleDblClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            //MessageBox.Show("Container HandleDblClick");
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (myElement.Visible && myElement.Deleteted == false && myElement.HandleDblClick(x, y, Button))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 已重载:处理鼠标按钮按下事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的Y坐标</param>
        /// <param name="Button">鼠标按钮</param>
        /// <returns>是否处理了本次事件</returns>
        public override bool HandleMouseDown(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (myElement.Visible && myElement.Deleteted == false && myElement.HandleMouseDown(x, y, Button))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 已重载:处理鼠标移动事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的Y坐标</param>
        /// <param name="Button">鼠标按钮</param>
        /// <returns>是否处理了本次事件</returns>
        public override bool HandleMouseMove(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (myElement.Visible && myElement.Deleteted == false && myElement.HandleMouseMove(x, y, Button))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 已重载:处理鼠标按钮松开事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的Y坐标</param>
        /// <param name="Button">鼠标按钮</param>
        /// <returns>是否处理了本次事件</returns>
        public override bool HandleMouseUp(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (myElement.Visible && myElement.Deleteted == false && myElement.HandleMouseUp(x, y, Button))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region other override
        /// <summary>
        /// 容器对象默认进行强制换行
        /// </summary>
        /// <returns></returns>
        public override bool isNewLine()
        {
            return true;
        }
        /// <summary>
        /// 已重载:容器元素不是文本类型元素
        /// </summary>
        /// <returns></returns>
        public override bool isTextElement()
        {
            return false;
        }
        /// <summary>
        /// 已重写:本容器内是否存在字段类型的元素
        /// </summary>
        /// <returns></returns>
        public override bool isField()
        {
            foreach (ZYTextElement myElement in myChildElements)
            {
                if ((myElement as ZYTextContainer) == null)
                {
                    if (myElement.isField())
                        return true;
                }
                else
                    return myElement.isField();
            }
            return false;
        }

        public override string ToEMRString()
        {
            if (myChildElements.Count == 0)
                return "";
            System.Collections.ArrayList myElements = this.GetVisibleElements();
            FixForKeyField(myElements);
            System.Text.StringBuilder myStr = new System.Text.StringBuilder(myChildElements.Count);
            foreach (ZYTextElement myElement in myElements)
                myStr.Append(myElement.ToEMRString());
            return myStr.ToString();
        }
        #endregion



        #region 单独处理页眉模板文档 add by myc 2013-01-15
        /// <summary>
        /// 针对页眉模板的文档内容保存到XML节点中，新增的ToHeadXML方法。
        /// add by myc 2013-01-15 13:40:28。
        /// </summary>
        /// <param name="RootElement">文档中的body元素节点。</param>
        /// <returns>操作是否成功。</returns>
        public bool ToHeadXML(XmlElement myElement)
        {
            try
            {
                myElement.SetAttribute("sx_flag","new"); //兼容医院本身已存在的页眉数据，直接在页眉XML中加入特殊标志属性，不用改变数据库
                int HeadHeight = 0;
                int IncrementY = 0;
                XmlElement RowElment = null; //行元素节点p
                ZYTextChar CurrentChar = null; //保存当前正在访问的文本字符元素
                ZYTextChar BeforeChar = null; //保存上一次访问的文本字符元素
                XmlElement SpanElement = null; //文本节点span
                foreach (ZYTextElement myP in myChildElements)
                {
                    string strName = myP.GetXMLName();
                    if (strName != null)
                    {
                        RowElment = myElement.OwnerDocument.CreateElement(myP.GetXMLName()); //创建段落头节点p
                        RowElment.SetAttribute("align", (Convert.ToInt32((myP as ZYTextParagraph).Align)).ToString());
                    }
                    foreach (ZYTextElement myE in (myP as ZYTextContainer).ChildElements)
                    {
                        if (myE is ZYMacro) //创建宏元素节点macro
                        {
                            #region 具体代码
                            BeforeChar = null;
                            XmlElement MacroElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                            MacroElement.SetAttribute("type", StringCommon.GetNameByType((myE as ZYMacro).Type));
                            MacroElement.SetAttribute("name", (myE as ZYMacro).Name);
                            MacroElement.InnerText = (myE as ZYMacro).Text;
                            MacroElement.SetAttribute("left", (myE as ZYTextContainer).FirstElement.Bounds.Left.ToString());
                            MacroElement.SetAttribute("top", (myE as ZYTextContainer).FirstElement.Bounds.Top.ToString());
                            MacroElement.SetAttribute("width", ((myE as ZYTextContainer).LastElement.Bounds.Right - (myE as ZYTextContainer).FirstElement.Bounds.Left).ToString());
                            MacroElement.SetAttribute("fontname", ((myE as ZYTextContainer).FirstElement as ZYTextChar).FontName);
                            MacroElement.SetAttribute("fontsize", ((myE as ZYTextContainer).FirstElement as ZYTextChar).FontSize.ToString());

                            if (((myE as ZYTextContainer).FirstElement as ZYTextChar).FontBold)
                            {
                                MacroElement.SetAttribute("fontbold", "1");
                            }
                            if (((myE as ZYTextContainer).FirstElement as ZYTextChar).FontItalic)
                            {
                                MacroElement.SetAttribute("fontitalic", "1");
                            }
                            if (((myE as ZYTextContainer).FirstElement as ZYTextChar).FontUnderLine)
                            {
                                MacroElement.SetAttribute("fontunderline", "1");
                            }
                            //MacroElement.SetAttribute("fontbold", ((myE as ZYTextContainer).FirstElement as ZYTextChar).FontBold.ToString().ToLower());
                            //MacroElement.SetAttribute("fontitalic", ((myE as ZYTextContainer).FirstElement as ZYTextChar).FontItalic.ToString().ToLower());
                            //MacroElement.SetAttribute("fontunderline", ((myE as ZYTextContainer).FirstElement as ZYTextChar).FontUnderLine.ToString().ToLower());

                            MacroElement.SetAttribute("forecolor", ColorTranslator.ToHtml(((myE as ZYTextContainer).FirstElement as ZYTextChar).ForeColor));

                            RowElment.AppendChild(MacroElement); 
                            #endregion
                            IncrementY = myE.Bounds.Height > IncrementY ? myE.Bounds.Height : IncrementY; //取元素中最大高度的
                        }
                        else if (myE is ZYTextEOF) //创建回车符eof节点
                        {
                            XmlElement EofElement = myElement.OwnerDocument.CreateElement("eof");
                            RowElment.AppendChild(EofElement);
                            BeforeChar = null; //一行结束置上一次访问的文本字符对象为空
                        }
                        else if (myE is ZYTextChar && myE.GetXMLName() != "horizontalLine") //创建文本元素span节点
                        {
                            #region 具体代码
                            CurrentChar = myE as ZYTextChar;
                            if (CurrentChar != null && BeforeChar == null) //第一个文本字符元素，创建span节点，并设置位置属性
                            {
                                SpanElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                                SpanElement.SetAttribute("left", myE.Bounds.Left.ToString());
                                SpanElement.SetAttribute("top", myE.Bounds.Top.ToString());
                                SpanElement.SetAttribute("fontname", CurrentChar.FontName);
                                SpanElement.SetAttribute("fontsize", CurrentChar.FontSize.ToString());

                                if (CurrentChar.FontBold)
                                {
                                    SpanElement.SetAttribute("fontbold", "1");
                                }
                                if (CurrentChar.FontItalic)
                                {
                                    SpanElement.SetAttribute("fontitalic", "1");
                                }
                                if (CurrentChar.FontUnderLine)
                                {
                                    SpanElement.SetAttribute("fontunderline", "1");
                                }
                                //SpanElement.SetAttribute("fontbold", CurrentChar.FontBold.ToString().ToLower());
                                //SpanElement.SetAttribute("fontitalic", CurrentChar.FontItalic.ToString().ToLower());
                                //SpanElement.SetAttribute("fontunderline", CurrentChar.FontUnderLine.ToString().ToLower());
                                SpanElement.SetAttribute("forecolor", ColorTranslator.ToHtml(CurrentChar.ForeColor));
                            }
                            XmlText myText = myElement.OwnerDocument.CreateTextNode(CurrentChar.ToEMRString());
                            if (BeforeChar == null) //第一个文本字符元素时，BeforChar肯定为null
                            {
                                SpanElement.AppendChild(myText);
                            }
                            else
                            {
                                //前后两次访问的文本字符元素属性一致，添加到同一个文本节点span中
                                if (CurrentChar.FontName == BeforeChar.FontName 
                                    && CurrentChar.FontSize == BeforeChar.FontSize
                                    && CurrentChar.FontBold == BeforeChar.FontBold
                                    && CurrentChar.FontItalic == BeforeChar.FontItalic
                                    && CurrentChar.FontUnderLine == BeforeChar.FontUnderLine
                                    && CurrentChar.ForeColor == BeforeChar.ForeColor)
                                {
                                    SpanElement.AppendChild(myText);
                                }
                                else
                                {
                                    SpanElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                                    SpanElement.SetAttribute("left", myE.Bounds.Left.ToString());
                                    SpanElement.SetAttribute("top", myE.Bounds.Top.ToString());
                                    SpanElement.SetAttribute("fontname", CurrentChar.FontName);
                                    SpanElement.SetAttribute("fontsize", CurrentChar.FontSize.ToString());

                                    if (CurrentChar.FontBold)
                                    {
                                        SpanElement.SetAttribute("fontbold", "1");
                                    }
                                    if (CurrentChar.FontItalic)
                                    {
                                        SpanElement.SetAttribute("fontitalic", "1");
                                    }
                                    if (CurrentChar.FontUnderLine)
                                    {
                                        SpanElement.SetAttribute("fontunderline", "1");
                                    }
                                    //SpanElement.SetAttribute("fontbold", CurrentChar.FontBold.ToString().ToLower());
                                    //SpanElement.SetAttribute("fontitalic", CurrentChar.FontItalic.ToString().ToLower());
                                    //SpanElement.SetAttribute("fontunderline", CurrentChar.FontUnderLine.ToString().ToLower());
                                    SpanElement.SetAttribute("forecolor", ColorTranslator.ToHtml(CurrentChar.ForeColor));
                                    XmlText NewText = SpanElement.OwnerDocument.CreateTextNode(CurrentChar.ToEMRString());
                                    SpanElement.AppendChild(NewText);
                                    RowElment.AppendChild(SpanElement);
                                    BeforeChar = CurrentChar;
                                    continue;
                                }
                            }
                            BeforeChar = CurrentChar;
                            RowElment.AppendChild(SpanElement); 
                            #endregion
                            IncrementY = myE.Bounds.Height > IncrementY ? myE.Bounds.Height : IncrementY; //取元素中最大高度的
                        }
                        else if (myE.GetXMLName() == "horizontalLine") //创建水平线horizontalLine节点(ZYHorizontalLine：ZYElement : ZYTextChar)
                        {
                            #region 具体代码
                            XmlElement LineElement = myElement.OwnerDocument.CreateElement(myE.GetXMLName());
                            LineElement.SetAttribute("type", StringCommon.GetNameByType((myE as ZYHorizontalLine).Type));
                            LineElement.SetAttribute("name", (myE as ZYHorizontalLine).Name);
                            LineElement.SetAttribute("lineHeight", (myE as ZYHorizontalLine).LineHeight.ToString());
                            LineElement.SetAttribute("percent", (myE as ZYHorizontalLine).Percent.ToString());
                            LineElement.SetAttribute("top", myE.Bounds.Top.ToString());
                            RowElment.AppendChild(LineElement); 
                            #endregion
                        }
                    }
                    myElement.AppendChild(RowElment);
                    HeadHeight += IncrementY;
                }
                //注意页眉实际高度是所有行的高度与行距之和
                //myElement.SetAttribute("height", (HeadHeight + myChildElements.Count * this.OwnerDocument.Info.LineSpacing).ToString()); 
                myElement.SetAttribute("height", OwnerDocument.RootDocumentElement.Height.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        




    }// class  ZYTextContainer
}
