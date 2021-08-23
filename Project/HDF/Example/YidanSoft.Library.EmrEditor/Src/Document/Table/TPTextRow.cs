using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 表示表格中的一行,一个行中可能包含多个单元格
    /// </summary>
    public class TPTextRow : ZYTextContainer, IEnumerable<TPTextCell>, IEnumerator<TPTextCell>
    {
        #region 私有变量
        /// <summary> 行中公有多少单元格 </summary>
        protected List<TPTextCell> cells = new List<TPTextCell>();

        /// <summary> 行中的列数 </summary>
        protected int columns;

        /// <summary> 行中的当前列 </summary>
        protected int currentColumn;

        /// <summary>
        /// 行的宽度,默认和表格宽相同
        /// </summary>
        protected int width;
        /// <summary>
        /// 行的高度
        /// </summary>
        protected int height;

        protected int maxHeight;

        /// <summary>
        /// 行中各列的宽度
        /// </summary>
        protected int[] widths;

        //行所属表格
        private TPTextTable ownerTable;

        //因为在使用这个position值前,会先执行一次MoveNext()方法
        //所以这个设置为 -1 是正确的
        private int position = -1;

        #endregion

        #region 索引器

        public TPTextCell this[int index]
        {
            get
            {
                if (index < 0 || index > cells.Count)
                    throw new Exception("索引超出范围");
                return cells[index];
            }
            set
            {
                if (index < 0)
                {
                    cells.Insert(0, value);
                    myChildElements.Insert(0, value);
                }
                else if (index > cells.Count)
                {
                    cells.Add(value);
                    myChildElements.Add(value);
                }
                else
                {
                    cells.Insert(index, value);
                    myChildElements.Insert(index, value);
                }
            }
        }
        #endregion

        #region 公有属性

        public int MaxHeight
        {
            get
            {
                return CalculateMaxHeights();
            }
            set
            {
                this.maxHeight = value;
            }
        }

        /// <summary>
        /// 行中各列的宽度
        /// </summary>
        public int[] Widths
        {
            get
            {
                return this.widths;
            }
            set
            {
                this.widths = value;
            }
        }

        public List<TPTextCell> Cells
        {
            get
            {
                return cells;
            }
            set
            {
                cells = value;
            }
        }
        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        /// <value>a value</value>
        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }

        public override int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public override int Height
        {
            get
            {

                return this.height;
            }
            set
            {
                this.height = value;
            }
        }



        public TPTextTable OwnerTable
        {
            get { return this.ownerTable; }
            set { this.ownerTable = value; }
        }

        #endregion

        #region IEnumerable<TPTextCell> 成员

        IEnumerator<TPTextCell> IEnumerable<TPTextCell>.GetEnumerator()
        {
            return this.cells.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cells.GetEnumerator();
        }

        #endregion

        #region IEnumerator<TPTextCell> 成员

        TPTextCell IEnumerator<TPTextCell>.Current
        {
            get
            {
                try
                {
                    return this.cells[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        #endregion

        #region IDisposable 成员

        void IDisposable.Dispose()
        {
            //
        }

        #endregion

        #region IEnumerator 成员

        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return this.cells[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }

            }
        }

        bool IEnumerator.MoveNext()
        {
            position++;
            return (position < this.cells.Count);
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        #endregion






        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="TPTextRow"/> class.
        /// </summary>
        public TPTextRow(){}

        /// <summary>
        /// Initializes a new instance of the <see cref="TPTextRow"/> class.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="rowWidths">The row widths.</param>
        /// <param name="rowHeight">Height of the row.</param>
        /// <param name="isLastRow">if set to <c>true</c> [is last row].</param>
        public TPTextRow(int columns,int[] rowWidths, int rowHeight, bool isLastRow)
        {
            this.columns = columns;
            this.widths = rowWidths;

            //设置行宽度
            this.width = 0;
            for (int k = 0; k < rowWidths.Length; k++)
            {
                this.width += rowWidths[k];
            }

            for (int i = 0; i < columns; i++)
            {
                TPTextCell someCell = new TPTextCell();
                someCell.Parent = this;
                someCell.Width = rowWidths[i];
                someCell.ContentHeight = rowHeight;
                someCell.OwnerRow = this;
                cells.Add(someCell);

                myChildElements.Add(someCell);
            }
            SetRowsBorderWidth(isLastRow);
            this.height = CalculateMinHeight();
            currentColumn = 0;
        }
        
        public TPTextRow( TPTextRow row )
        {
            this.columns = row.Columns;
            this.widths = row.Widths;

            this.width = row.Width;
            this.height = row.Height;

            for (int i = 0; i < row.Cells.Count; i++)
            {
                TPTextCell tmpCell = new TPTextCell(row.cells[i]);
                tmpCell.Parent = this;
                tmpCell.OwnerRow = this;
                this.cells.Add(tmpCell);
                myChildElements.Add(tmpCell);
            }
            this.height = CalculateMinHeight();
        }

        public TPTextRow Clone()
        {
            TPTextRow newRow = new TPTextRow();
            newRow.OwnerDocument = OwnerDocument;

            newRow.columns = Columns;
            newRow.widths = Widths;

            newRow.width = Width;
            newRow.height = Height;

            for (int i = 0; i < Cells.Count; i++)
            {
                TPTextCell tmpCell = cells[i].Clone();
                tmpCell.Parent = newRow;
                tmpCell.OwnerRow = newRow;
                newRow.cells.Add(tmpCell);
                newRow.myChildElements.Add(tmpCell);
            }
            newRow.height = newRow.CalculateMinHeight();

            return newRow;
        }

        #endregion




        #region 公有方法

        /// <summary>
        /// 计算本行的最高高度,一般由行中最高的那个cell决定的
        /// </summary>
        /// <returns></returns>
        internal int CalculateMaxHeights()
        {
            int tmpHeight = 0;
            foreach (TPTextCell c in this)
            {
                if (tmpHeight < c.Height)
                {
                    tmpHeight = c.Height;
                }
            }
            return tmpHeight;
        }

        internal int CalculateMinHeight()
        {
            int tmpHeight = 0;
            foreach (TPTextCell c in this)
            {
                if (tmpHeight == 0)
                {
                    tmpHeight = c.Height;
                }
                if (tmpHeight > c.Height && c.Height != 0)
                {
                    tmpHeight = c.Height;
                }
            }
            return tmpHeight;
        }

        internal int CalculateMaxLineHeight()
        {
            int tmpHeight = 0;
            foreach (TPTextCell c in this)
            {
                if ( tmpHeight < c.AllLineHeight)
                {
                    tmpHeight = c.AllLineHeight;
                }
            }
            return tmpHeight;
        }

        internal int CalculateMinLineHeight()
        {
            int tmpHeight = 0;
            foreach (TPTextCell c in this)
            {
                if (tmpHeight == 0)
                {
                    tmpHeight = c.AllLineHeight;
                }
                if (c.AllLineHeight < tmpHeight)
                {
                    tmpHeight = c.AllLineHeight;
                }
            }
            return tmpHeight;
        }

        internal int CalculateMaxContentHeight()
        {
            int tmpHeight = 0;
            foreach (TPTextCell c in this)
            {
                if (tmpHeight < c.ContentHeight)
                {
                    tmpHeight = c.ContentHeight;
                }
            }
            return tmpHeight;
        }

        internal int CalculateMinContentHeight()
        {
            int tmpHeight = 0;
            foreach (TPTextCell c in this)
            {
                if (tmpHeight == 0)
                {
                    tmpHeight = c.ContentHeight;
                }
                if (c.ContentHeight < tmpHeight)
                {
                    tmpHeight = c.ContentHeight;
                }
            }
            return tmpHeight;
        }

        /// <summary>
        /// 设置行中每个单元格的边框宽度
        /// </summary>
        /// <param name="isLastRow">是否是最后一行</param>
        internal void SetRowsBorderWidth(bool isLastRow)
        {
            //如果不是最后一行
            if (false == isLastRow)
            {
                for (int i = 0; i < this.columns; i++)
                {
                    if (this.Cells[i].Merged == false)
                    {
                        this.cells[i].BorderWidthTop = 1;
                        this.cells[i].BorderWidthRight = 0;
                        this.cells[i].BorderWidthBottom = 0;
                        this.cells[i].BorderWidthLeft = 1;
                        //最后一格
                        if (i == (this.columns - 1))
                        {
                            this.cells[i].BorderWidthTop = 1;
                            this.cells[i].BorderWidthRight = 1;
                            this.cells[i].BorderWidthBottom = 0;
                            this.cells[i].BorderWidthLeft = 1;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.columns; i++)
                {
                    if (this.Cells[i].Merged == false)
                    {
                        this.cells[i].BorderWidthTop = 1;
                        this.cells[i].BorderWidthRight = 0;
                        this.cells[i].BorderWidthBottom = 1;
                        this.cells[i].BorderWidthLeft = 1;
                        //最后一格
                        if (i == (this.columns - 1))
                        {
                            this.cells[i].BorderWidthTop = 1;
                            this.cells[i].BorderWidthRight = 1;
                            this.cells[i].BorderWidthBottom = 1;
                            this.cells[i].BorderWidthLeft = 1;
                        }
                        //2021-04-13：当光标在最后一行有合并单元格时，合并单元格的下边框就会被刷新为0，
                        if (this.cells[i].OwnerMergeCell != null)
                        {
                            this.cells[i].OwnerMergeCell.BorderWidthBottom = 1;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 在列号处插入一个单元格
        /// </summary>
        /// <param name="columnIndex">列号</param>
        /// <param name="cell">基准单元格</param>
        /// <returns>插入单元格的索引</returns>
        internal void InsertCell(int columnIndex, TPTextCell cell)
        {
            if ((columnIndex < 0) || (columnIndex > columns)) 
                throw new Exception("addCell - 超出索引范围");

            TPTextCell tmpCell = new TPTextCell(cell);
            tmpCell.Parent = this;
            tmpCell.OwnerRow = this;
            cells.Insert(columnIndex, tmpCell);
            myChildElements.Insert(columnIndex, tmpCell);

            SetWidthByTable(this.ownerTable.Widths);
            this.height = CalculateMinHeight();

            tmpCell.OwnerDocument = this.OwnerDocument;

        }

        /// <summary>
        /// 在行末尾添加一个单元格
        /// </summary>
        /// <returns>插入单元格的索引</returns>
        internal void AddCell(TPTextCell cell)
        {
            TPTextCell tmpCell = new TPTextCell(cell);
            tmpCell.Parent = this;
            tmpCell.OwnerRow = this;
            cells.Add(tmpCell);
            myChildElements.Add(tmpCell);

            SetWidthByTable(this.ownerTable.Widths);
            this.height = CalculateMinHeight();

            tmpCell.OwnerDocument = this.OwnerDocument;
        }

        private void SetWidthByTable(int[] tableWidths)
        {
            this.columns = tableWidths.Length;
            this.widths = new int[this.columns];
            this.widths = tableWidths;

            for (int i = 0; i < this.widths.Length; i++)
            {
                this.cells[i].Width = this.widths[i];
            }
        }


        /// <summary>
        /// Checks if the row is empty.
        /// </summary>
        /// <returns>true if none of the columns is reserved.</returns>
        public bool IsEmpty()
        {
            for (int i = 0; i < columns; i++)
            {
                if (cells[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除行中的指定列号的单元格
        /// </summary>
        /// <param name="column"></param>
        public void DeleteColumn(int column)
        {
            if ((column >= columns) || (column < 0))
            {
                throw new Exception("超出列索引范围");
            }

            this.cells.RemoveAt(column);
            this.ChildElements.RemoveAt(column);

            int[] newWidths = new int[--columns];
            System.Array.Copy(widths, 0, newWidths, 0, column);
            System.Array.Copy(widths, column + 1, newWidths, column, columns - column);
            widths = newWidths;

            this.width = 0;
            for (int i = 0; i < widths.Length; i++)
            {
                this.width += widths[i];
            }
            
        }

        #endregion

        

        #region Container继承override方法

        protected override void RefreshClientWidth()
        {
            if (myOwnerDocument != null)
            {
                intClientWidth = myOwnerDocument.Pages.StandardWidth - this.RealLeft - intLeftMargin - intRightMargin;
            }
        }
        public override Rectangle GetContentBounds()
        {
            int x = cells[0].RealLeft;
            int y = cells[0].RealTop;
            return new Rectangle(x, y, this.Width, this.Height);
        }

        public override string GetXMLName()
        {
            return ZYTextConst.c_Row;
        }

        public override void AddElementToList(System.Collections.ArrayList myList, bool ResetFlag)
        {
            if (myList != null)
            {
                foreach (ZYTextElement myElement in myChildElements)
                {
                    if (!ResetFlag)
                    {
                        myElement.Visible = false;
                        myElement.Index = -1;
                    }
                    if (myOwnerDocument.isVisible(myElement) && myElement is ZYTextContainer)
                    {
                        myElement.Visible = true;
                        (myElement as TPTextCell).AddElementToList(myList, ResetFlag);
                    }
                }
            }
        }

        public override bool RefreshView()
        {
            for (int i = 0; i < columns; i++)
            {
                cells[i].RefreshView();
            }
            
            return true;
        }

        public override bool RefreshSize()
        {
            return base.RefreshSize();
        }

        public override System.Collections.ArrayList RefreshLine()
        {
            RefreshClientWidth();

            myLines.Clear();

            ArrayList LastLine = new ArrayList();
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Visible)
                {
                    cells[i].RefreshLine();
                    LastLine.Add(cells[i]);
                }
                else
                {
                    cells[i].OwnerLine = null;
                }
            }

            #region 已注释 add by myc 2014-03-17 旧版表格没有正确处理拆分单元格，合并单元格方法需修正，为后期拖拽单元格奠定基础
        //    #region 这里决定各个cell的最终高度

        //    //几种高度变化的情况:
        //    // 0: 默认为行中没有行合并的cell
        //    // 1: 调整maxRowSpanCell的高度. 
        //    // 2: 合并单元格的情况
        //    // 3: 调整有合并行情况的,非合并cell的cell
        //    int changeSituation = 0;

        //    //当前操作的单元格
        //    TPTextCell currentCell = ownerTable.GetCurrentCell();

        //    //如果有行合并的情况,则这个为合并的那个cell. 否则为null
        //    TPTextCell thatspanCell = ownerTable.IsInRowSpan(currentCell);

        //    if (thatspanCell == null)
        //    {
        //        //当前的行中是否包含正在处理cell
        //        bool trueLine = false;
        //        foreach (TPTextCell cell in this)
        //        {
        //            if (cell == currentCell)
        //            {
        //                trueLine = true;
        //                break;
        //            }
        //        }
        //        //如果包含,则为没有行合并的正常行. 
        //        // 否则为其它的行,基本到了后面都会不进行高度处理
        //        if (trueLine)
        //        {
        //            changeSituation = 0;
        //        }
        //        else
        //        {
        //            changeSituation = 1;
        //        }
        //    }
        //    else if (thatspanCell != null)
        //    {
        //        if (currentCell == thatspanCell)
        //        {
        //            changeSituation = 1;
        //        }
        //        if (currentCell != thatspanCell)
        //        {
        //            changeSituation = 3;
        //        }
        //    }

        //    if (changeSituation == 1)
        //    {
        //        //寻找本行中拥有最大的rowspan的cell
        //        int tmpRowspan = 1;
        //        TPTextCell maxRowSpanCell = null;
        //        foreach (TPTextCell cell in this)
        //        {
        //            if (cell.Rowspan > tmpRowspan)
        //            {
        //                tmpRowspan = cell.Rowspan;
        //                maxRowSpanCell = cell;
        //            }
        //        }

        //        if (maxRowSpanCell == null || tmpRowspan == 1)
        //        {
        //            changeSituation = 2;
        //            goto access;
        //        }
        //        List<TPTextRow> interRows = new List<TPTextRow>(); //用来存储rowspanCell占据的所有行
        //        int rowIndex = ownerTable.IndexOf(this);  //获取本行在表格中的索引
        //        //exceptHeight所包含所有行的总高度.用来判断到底是rowspan的cell增加了高度,还是其他的cell增加了高度d
        //        int exceptHeight = 0;
        //        for (int i = rowIndex; i < (rowIndex + tmpRowspan); i++)
        //        {
        //            interRows.Add(ownerTable.AllRows[i]);
        //            exceptHeight += ownerTable.AllRows[i].CalculateMinHeight();
        //        }
        //        //差的高度, 可能为正,也可能为负.为正时,是增加高度. 为负时,是减少高度.
        //        int loseHeight = maxRowSpanCell.Height - exceptHeight;
        //        if (loseHeight == 0)
        //        {
        //            changeSituation = 2; //行合并的cell的高,和几个行的总高相同. 则为合并的情况
        //            goto access;
        //        }
        //        if (loseHeight != 0)
        //        {
        //            TPTextRow lastInterRow = interRows[interRows.Count - 1];
        //            int newHeight = lastInterRow.CalculateMinHeight() + loseHeight;
        //            foreach (TPTextCell cell in lastInterRow)
        //            {
        //                if (cell.Height != 0)
        //                {
        //                    cell.Height = newHeight;
        //                }
        //            }
        //            lastInterRow.height = lastInterRow.CalculateMinHeight();
        //        }
        //    }
        //    if (changeSituation == 3)
        //    {
        //        //那个合并的cell,是否属于本行
        //        bool inthis = false;
        //        foreach (TPTextCell cell in this)
        //        {
        //            if (cell == thatspanCell)
        //            {
        //                inthis = true;
        //                break;
        //            }
        //        }
        //        if (inthis)
        //        {

        //        }
        //        else
        //        {
        //            //TODO: 被rowspan包含的行,但是又不包含rowspan的那个cell
        //        }
        //    }
        //access:
        //    //设置行的高度
        //    switch (changeSituation)
        //    {
        //        case 0:
        //            //获得当前行的最大行高
        //            int xHeight = CalculateMaxLineHeight();

        //            //TODO  **************Modified by wwj 2012-02-17 修改单元格高度的算法*****************
        //            //int linerow = 1;
        //            //foreach (TPTextCell cell in this)
        //            //{
        //            //    if (linerow < cell.Lines.Count)
        //            //    {
        //            //        linerow = cell.Lines.Count;
        //            //    }
        //            //}
        //            //foreach (TPTextCell cell in this)
        //            //{
        //            //    cell.ContentHeight = xHeight + ((linerow - 1) * (cell.PaddingTop + cell.PaddingBottom));
        //            //}
        //            foreach (TPTextCell cell in this)
        //            {
        //                if (cell.Merged) continue;//Add By wwj 2012-02-20 解决打开表格时原先对单元格的合并操作失效的Bug

        //                //cell.ContentHeight = xHeight;
        //            }
        //            //**************************************END******************************************

        //            this.height = CalculateMinHeight();
        //            break;

        //        case 1:
        //            this.height = CalculateMinHeight();
        //            break;

        //        case 2:

        //            //Modified by wwj 2012-02-19 在进行单元格合并的时候，导致合并后的单元格的大小不正确
        //            //int xHeight2 = CalculateMaxLineHeight();
        //            //int linerow2 = 1;
        //            //foreach (TPTextCell cell in this)
        //            //{
        //            //    if (linerow2 < cell.Lines.Count)
        //            //    {
        //            //        linerow2 = cell.Lines.Count;
        //            //    }
        //            //}
        //            //foreach (TPTextCell cell in this)
        //            //{
        //            //    cell.ContentHeight = xHeight2 + ((linerow2 - 1) * (cell.PaddingTop + cell.PaddingBottom));
        //            //}
        //            //Add By wwj 2012-02-20 解决打开表格时表格全部重叠的Bug
        //            int minheight = CalculateMinHeight();
        //            if (minheight > this.height)
        //            {
        //                this.height = minheight;
        //            }

        //            break;

        //        case 3:
        //            this.height = this.CalculateMinHeight();
        //            break;
        //    }


        //    #endregion
            #endregion

            this.Height = this.CalculateMinHeight(); //新版表格行高度计算 add by myc 2014-03-17
            
            ResetLine(LastLine);
            LastLine.Clear();

            UpdateBounds();

            return myLines;
        }

        


        protected override int ResetLine(ArrayList LineElements)
        {
            // 新增一个行对象
            ZYTextLine NewLine = new ZYTextLine();
            NewLine.Index = myLines.Count;
            NewLine.Container = this;
            NewLine.RealLeft = this.RealLeft;
            NewLine.Elements.AddRange(LineElements);

            NewLine.Height = this.Height;
            NewLine.ContentWidth = this.Width;

            int LineWidth = this.intClientWidth;

            // 向文档对象结构注册当前行
            myLines.Add(NewLine);
            //myOwnerDocument.AddLine(NewLine); //add by myc 2014-06-26 注释原因：新版页眉二期改版需要

            #region add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            if (this.OwnerTable.Parent is ZYTextDiv)
            {
                //myOwnerDocument.AddLine(NewLine);
                //myOwnerDocument.EditingAreaLines[1].Add(NewLine); //add by myc 2014-07-03 添加原因：新版页眉二期改版之保存文档正文区域的所有文本行对象
                (this.OwnerTable.Parent as ZYTextDiv).InnerLines.Add(NewLine); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
            }
            else if (this.OwnerTable.Parent is ZYDocumentHeader)
            {
                (this.OwnerTable.Parent as ZYDocumentHeader).InnerLines.Add(NewLine); //注意InnerLines必须在页眉区域根元素的RefreshLine之前执行Clear
            }
            else if (this.OwnerTable.Parent is ZYDocumentFooter)
            {
                (this.OwnerTable.Parent as ZYDocumentFooter).InnerLines.Add(NewLine); //注意InnerLines必须在页脚区域根元素的RefreshLine之前执行Clear
            }
            #endregion

            int intLeftCount = 0;

            switch (OwnerTable.HorizontalAlignment)
            {
                case 1:
                    intLeftCount = intLeftMargin;
                    break;
                case 2:
                    intLeftCount = intLeftMargin + (LineWidth - NewLine.ContentWidth) / 2;
                    break;
                case 3:
                    intLeftCount = intLeftMargin + (LineWidth - NewLine.ContentWidth);
                    break;
            }

            if (LineElements.Count == columns) //——add by myc 2014-02-28 注意拆分单元格后，这个判断原列数是不变的，但是LineElements.Count会变
            {
                for (int i = 0; i < LineElements.Count; i++)
                {
                    if (LineElements[i] is TPTextCell)
                    {
                        TPTextCell eCell = LineElements[i] as TPTextCell;
                        eCell.OwnerLine = NewLine;
                        eCell.Left = intLeftCount; //cell的相对left位置
                        eCell.Top = 0;// NewLine.Height - eCell.Height; //cell的相对top位置
                        intLeftCount += (NewLine.RealLeft + this.widths[i]);
                    }
                }
            }
            
            return NewLine.Height;
        }

        public override void UpdateBounds()
        {
            base.UpdateBounds();
        }

        public override bool FromXML(  System.Xml.XmlElement myElement )
        {
            if (null != myElement)
            {
                this.cells.Clear();

                foreach ( XmlNode node in myElement.ChildNodes )
                {
                    if (node.Name == "table-cell")
                    {
                        TPTextCell cellEle = OwnerDocument.CreateElementByXML(node as XmlElement) as TPTextCell;
                        cellEle.Parent = this;
                        cellEle.OwnerRow = this;

                        this.cells.Add(cellEle);
                        this.ChildElements.Add(cellEle);
                    }
                }

                this.columns = this.cells.Count;
                widths = new int[this.columns];
                for (int i = 0; i < this.columns; i++)
                {
                    this.widths[i] = this.cells[i].Width;
                }

                return true;
            }
            return false;
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (null != myElement)
            {
                foreach (TPTextCell cell in cells)
                {
                    XmlElement item = myElement.OwnerDocument.CreateElement(cell.GetXMLName());
                    myElement.AppendChild(item);
                    cell.ToXML(item);
                }

                #region add by myc 2014-04-16 为每一个表格行添加占位单元格标记属性
                //string str = string.Empty;
                //for (int i = 0; i < this.Widths.Length; i++)
                //{
                //    str += this.Widths[i].ToString() + "|";
                //}
                //str = str.Substring(0, str.Length - 1);
                //myElement.SetAttribute("widths", str);
                //myElement.SetAttribute("flag", Flag); 
                #endregion
            }
            return true;
        }
        #endregion

        
    }
}
