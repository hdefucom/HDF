using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Drawing;
using System.Diagnostics;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Data;

using System.Runtime.InteropServices;
using ZYTextDocumentLib; //add by myc 2014-05-27 添加原因：导入外部动态运行库

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 表示一个表格,一个表格中可能包含多个行
    /// </summary>
    public class TPTextTable : ZYTextContainer, IEnumerable<TPTextRow>, IEnumerator<TPTextRow>
    {
        #region 私有变量

        /// <summary>表格包含多少列</summary>
        private int columns;

        /// <summary>表格包含的行列表</summary>
        private List<TPTextRow> allRows = new List<TPTextRow>();

        /// <summary>表格的宽度</summary>
        private int totalWidth = -1;
        private int totalHeight = -1;

        /// <summary>各列的百分比宽度(也可能是绝对宽度,此时和absoluteWidths相同)</summary>
        private int[] relativeWidths;

        /// <summary> 各列的绝对宽度 </summary>
        private int[] absoluteWidths;

        ///<summary> This is cellpadding. </summary>
        private int cellpadding = 20;

        ///<summary> This is cellspacing. </summary>
        private int cellspacing = 20;

        ///<summary>
        ///表格水平对齐方式 
        ///1 左对齐
        ///2 居中对齐
        ///3 右对齐
        ///</summary>
        private int horizontalAlignment = 1;

        /// <summary>
        /// true 固定列宽
        /// false 自动列宽
        /// </summary>
        private bool isFixWidth = true;

        private int defaultRowHeight = 0;
        private int defaultTableWidth = 0;

        /// <summary>
        /// 表格标题
        /// </summary>
        private string header;
        /// <summary>
        /// 是否隐藏所有边框
        /// </summary>
        private bool hiddenAllBorder = false;

        private int position = -1;

        #endregion

        #region 索引器
        /// <summary>
        /// Gets or sets the <see cref="YidanSoft.Library.EmrEditor.Src.Document.TPTextRow"/> at the specified index.
        /// </summary>
        /// <value></value>
        public TPTextRow this[int index]
        {
            get
            {
                return allRows[Index];
            }
            set
            {
                allRows.Insert(index, value);
                myChildElements.Insert(index, value);
            }
        }
        public TPTextCell this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.allRows.Count)
                {
                    throw new IndexOutOfRangeException("超出行索引范围");
                }
                if (col < 0 || col >= this.columns)
                {
                    throw new IndexOutOfRangeException("超出列索引范围");
                }
                return allRows[row].Cells[col];
            }
            set
            {
                if ((row < 0 || row >= this.allRows.Count) || (col < 0 || col >= this.columns))
                {
                    throw new IndexOutOfRangeException("超索引范围,不存在这样的单元格");
                }
                allRows[row].Cells[col] = value;
                allRows[row].Cells[col].ChildElements = value.ChildElements;
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// Initializes a new instance of the <see cref="TPTextTable"/> class.
        /// </summary>
        public TPTextTable() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TPTextTable"/> class.
        /// </summary>
        /// <param name="header">表格总标题</param>
        /// <param name="columns">列数</param>
        /// <param name="rows">行数</param>
        /// <param name="columnWidth">每一列的宽</param>
        /// <param name="defaultRowHeight">默认的行高</param>
        /// <param name="defaultTableWidth">默认的表格宽度</param>
        public TPTextTable(string header, int columns, int rows, int columnWidth, int defaultRowHeight, int defaultTableWidth)
        {
            if (columns <= 0) { throw new Exception("列数不能小于零"); }
            if (rows <= 0) { throw new Exception("行数不能小于零"); }

            //int limitColWidthMax = defaultTableWidth / columns;
            //int limitColWidthMin = GraphicsUnitConvert.Convert(11, GraphicsUnit.Pixel, GraphicsUnit.Document);

            //if (columnWidth < limitColWidthMin || columnWidth > limitColWidthMax)
            //{
            //    double min = GraphicsUnitConvert.Convert(limitColWidthMin, GraphicsUnit.Document, GraphicsUnit.Millimeter) * 10;
            //    double max = GraphicsUnitConvert.Convert(limitColWidthMax, GraphicsUnit.Document, GraphicsUnit.Millimeter) * 10;
            //    MessageBox.Show("度量值必须介于 "+ min.ToString()+" 厘米和 "+max.ToString()+" 厘米之间");
            //    return;
            //}

            this.header = header;
            this.columns = columns;

            this.defaultRowHeight = defaultRowHeight;

            this.defaultTableWidth = defaultTableWidth;
            this.totalWidth = defaultTableWidth;

            SetTotalWidth(columnWidth);

            for (int i = 0; i < rows; i++)
            {
                TPTextRow someRow = new TPTextRow(columns, absoluteWidths, defaultRowHeight, false);
                if (i == rows - 1)
                {
                    someRow = new TPTextRow(columns, absoluteWidths, defaultRowHeight, true);
                }
                someRow.Parent = this;
                someRow.OwnerTable = this;
                this.allRows.Add(someRow);
                myChildElements.Add(someRow);
            }

            CalculateHeights();
        }
        #endregion

        #region 私有方法


        #endregion

        #region 公有方法

        /// <summary>
        /// 重新设置表格中所有单元格的边框大小
        /// </summary>
        //public void SetEveryCellBorderWidth()
        //{
        //    for (int i = 0; i < this.allRows.Count; i++)
        //    {
        //        allRows[i].SetRowsBorderWidth(false);
        //        if (i == (this.allRows.Count - 1))
        //        {
        //            allRows[i].SetRowsBorderWidth(true);
        //        }
        //    }
        //}

        /// <summary>
        /// 根据指定的列宽设置表格的总宽
        /// 当<code>columnWidth</code>为0时,则是根据总宽算各个列宽
        /// </summary>
        /// <param name="columnWidth">列宽,如果为0,则根据表格总宽设置各列宽度</param>
        public void SetTotalWidth(int columnWidth)
        {
            this.relativeWidths = new int[columns];
            this.absoluteWidths = new int[columns];

            if (columnWidth == 0 && this.totalWidth > 0)
            {
                int tmpWidth = this.totalWidth / this.columns;
                for (int i = 0; i < columns; i++)
                {
                    if (i == columns - 1)
                    {
                        //最后一列为前面分配完后剩余的宽度
                        this.relativeWidths[i] = (this.totalWidth - (tmpWidth * (this.columns - 1)));
                    }
                    else
                    {
                        this.relativeWidths[i] = tmpWidth;
                    }
                }
            }
            if (columnWidth > 0)
            {
                this.totalWidth = 0;
                for (int i = 0; i < columns; i++)
                {
                    this.relativeWidths[i] = columnWidth;
                    this.totalWidth += columnWidth;
                }
            }
            this.CalculateWidths();
        }

        /// <summary>
        /// 设置各列的宽度
        /// </summary>
        /// <param name="relativeWidths">百分比宽度(绝对宽度)</param>
        public void SetWidth(int[] relativeWidths)
        {
            if (this.relativeWidths.Length != relativeWidths.Length)
            {
                throw new Exception("相对宽度的列数不符");
            }
            for (int k = 0; k < relativeWidths.Length; k++)
            {
                this.relativeWidths[k] = relativeWidths[k];
            }
            this.absoluteWidths = new int[relativeWidths.Length];
            CalculateWidths();
            CalculateHeights();
        }

        /// <summary>
        /// 计算各列的绝对宽度
        /// </summary>
        private void CalculateWidths()
        {
            int total = 0;
            for (int k = 0; k < this.absoluteWidths.Length; k++)
            {
                total += this.relativeWidths[k];
            }
            for (int k = 0; k < this.absoluteWidths.Length; k++)
            {
                absoluteWidths[k] = totalWidth * relativeWidths[k] / total;
            }
        }

        ///// <summary>
        ///// 设置表格的整体高度
        ///// </summary>
        //private void CalculateHeights()
        //{
        //    int tmpHeight = 0;
        //    foreach (TPTextRow row in allRows)
        //    {
        //        tmpHeight += row.Height;
        //    }
        //    this.totalHeight = tmpHeight;
        //}


        /// <summary>
        /// 设置表格的整体高度
        /// </summary>
        public void CalculateHeights()
        {
            int tmpHeight = 0;
            foreach (TPTextRow row in allRows)
            {
                tmpHeight += row.Height;
            }
            this.totalHeight = tmpHeight;
        }



        /// <summary>
        /// 向表格的末尾添加一列
        /// </summary>
        /// <param name="aColumns"></param>
        public void AddColumns(TPTextCell cell)
        {
            this.columns = this.absoluteWidths.Length + 1;
            this.absoluteWidths = new int[this.columns];
            SetTotalWidth(0);

            for (int i = 0; i < allRows.Count; i++)
            {
                allRows[i].AddCell(cell);
            }
        }

        /// <summary>
        /// 在指定列处插入一个新列
        /// </summary>
        /// <param name="colIndex">Index of the col.</param>
        /// <param name="cell">The cell.</param>
        public void InsertColumns(int colIndex, TPTextCell cell)
        {
            this.columns = this.absoluteWidths.Length + 1;
            this.absoluteWidths = new int[this.columns];
            SetTotalWidth(0);

            for (int i = 0; i < allRows.Count; i++)
            {
                allRows[i].InsertCell(colIndex, cell);
            }
        }

        /// <summary>
        /// 在指定索引处添加一行
        /// </summary>
        /// <param name="index"></param>
        /// <param name="row"></param>
        public void InsertRow(int index, TPTextRow row)
        {
            TPTextRow tmpRow = new TPTextRow(row);
            tmpRow.Parent = this;
            tmpRow.OwnerTable = this;

            #region  2021-04-15 --> 表格复杂单元格插入行修复


            var rind = allRows.IndexOf(row);

            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (rind < index && row.Cells[i].HasFlagCells != null && row.Cells[i].HasFlagCells.Count > 0)
                {//如果在模板行下面插入，并且模板行存在合并单元格
                    tmpRow.Cells[i].ContentHeight = defaultRowHeight;
                    tmpRow.Cells[i].OwnerMergeCell = row.Cells[i];
                    tmpRow.Cells[i].ChildElements.Clear();

                    row.Cells[i].HasFlagCells.Add(tmpRow.Cells[i]);
                    row.Cells[i].ContentHeight += tmpRow.Cells[i].Height;
                }
                if (rind < index && row.Cells[i].OwnerMergeCell != null && allRows.Count > rind + 1 && allRows[rind + 1][i].OwnerMergeCell != null)
                {//如果在合并单元格的行中间插入

                    tmpRow.Cells[i].ContentHeight = defaultRowHeight;
                    tmpRow.Cells[i].OwnerMergeCell = row.Cells[i].OwnerMergeCell;
                    tmpRow.Cells[i].ChildElements.Clear();

                    row.Cells[i].OwnerMergeCell.HasFlagCells.Insert(row.Cells[i].OwnerMergeCell.HasFlagCells.IndexOf(row.Cells[i]), tmpRow.Cells[i]);
                    row.Cells[i].OwnerMergeCell.ContentHeight += tmpRow.Cells[i].Height;
                }


                if (rind >= index && row.Cells[i].HasFlagCells != null && row.Cells[i].HasFlagCells.Count > 0)
                {
                    tmpRow.Cells[i].ContentHeight = defaultRowHeight;
                    //tmpRow.Cells[i].ChildElements.Clear();
                }
                if (rind >= index && row.Cells[i].OwnerMergeCell != null && rind - 1 >= 0 && allRows[rind - 1][i].OwnerMergeCell != null)
                {//如果在合并单元格的行中间插入

                    tmpRow.Cells[i].ContentHeight = defaultRowHeight;
                    tmpRow.Cells[i].OwnerMergeCell = row.Cells[i].OwnerMergeCell;
                    tmpRow.Cells[i].ChildElements.Clear();

                    row.Cells[i].OwnerMergeCell.HasFlagCells.Insert(row.Cells[i].OwnerMergeCell.HasFlagCells.IndexOf(row.Cells[i]), tmpRow.Cells[i]);
                    row.Cells[i].OwnerMergeCell.ContentHeight += tmpRow.Cells[i].Height;
                }




            }



            #endregion


            this.allRows.Insert(index, tmpRow);
            this.myChildElements.Insert(index, tmpRow);

            tmpRow.OwnerDocument = row.OwnerDocument;
            CalculateHeights();
        }

        /// <summary>
        /// 在末尾添加一行
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(TPTextRow row)
        {
            TPTextRow tmpRow = new TPTextRow(row);
            tmpRow.Parent = this;
            tmpRow.OwnerTable = this;

            this.allRows.Add(tmpRow);
            this.myChildElements.Add(tmpRow);

            tmpRow.OwnerDocument = row.OwnerDocument;
            CalculateHeights();
        }
        /// <summary>
        /// 在末尾添加若干行
        /// </summary>
        /// <param name="rowNum">要添加的行数</param>
        public void AddRow(int rowNum)
        {
            TPTextRow row = this.allRows[this.allRows.Count - 1];
            for (int k = 0; k < rowNum; k++)
            {
                this.AddRow(row);
            }
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="row">行号</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteRow(int row)
        {
            if (row < 0 || row >= this.allRows.Count)
            {
                return false;
            }
            allRows.RemoveAt(row);
            return true;
        }

        /// <summary>
        /// 删除所有的行
        /// </summary>
        public void DeleteAllRows()
        {
            allRows.Clear();
            //allRows.Add(new TPTextRow(columns));
        }

        /// <summary>
        /// 删除最后一行
        /// </summary>
        /// <returns></returns>
        public bool DeleteLastRow()
        {
            return DeleteRow(allRows.Count - 1);
        }

        /// <summary>
        /// 删除一列
        /// </summary>
        /// <param name="column">列号</param>
        public void DeleteColumn(int column)
        {
            if ((column >= columns) || (column < 0))
            {
                throw new Exception("超出列索引范围");
            }
            foreach (TPTextRow row in this)
            {
                row.DeleteColumn(column);
            }

            int[] newWidths = new int[--columns];
            System.Array.Copy(absoluteWidths, 0, newWidths, 0, column);
            System.Array.Copy(absoluteWidths, column + 1, newWidths, column, columns - column);
            absoluteWidths = newWidths;
            relativeWidths = absoluteWidths;

            this.totalWidth = 0;
            for (int i = 0; i < absoluteWidths.Length; i++)
            {
                this.totalWidth += absoluteWidths[i];
            }
        }

        /// <summary>
        /// 获得当前元素所在的单元格(当前正在操作的cell)
        /// </summary>
        /// <returns></returns>
        internal TPTextCell GetCurrentCell()
        {
            //获取当前元素
            ZYTextElement currentEle = OwnerDocument.Content.CurrentElement;
            TPTextCell cell = OwnerDocument.Content.GetParentByElement(currentEle, ZYTextConst.c_Cell) as TPTextCell;
            if (cell != null)
            {
                return cell;
            }
            return null;
        }

        /// <summary>
        /// <para>获取当前单元格是否在被合并的cell所跨越行的范围内</para>
        /// <para>如果是则返回那个被行合并的cell,否则返回null</para>
        /// </summary>
        /// <returns></returns>
        internal TPTextCell IsInRowSpan(TPTextCell cell)
        {
            for (int row = 0; row < allRows.Count; row++)
            {
                int rowSpan = 0;
                TPTextCell spanCell = null;
                for (int col = 0; col < allRows[row].Cells.Count; col++)
                {
                    if (allRows[row].Cells[col].Rowspan > 1)
                    {
                        rowSpan = allRows[row].Cells[col].Rowspan;
                        spanCell = allRows[row].Cells[col];
                        break;
                    }
                }
                for (int i = row; i < row + rowSpan; i++)
                {
                    for (int j = 0; j < allRows[i].Cells.Count; j++)
                    {
                        if (cell == allRows[i].Cells[j])
                        {
                            return spanCell;
                        }
                    }
                }
                if (rowSpan != 0)
                {
                    row = row + rowSpan - 1;
                }
            }
            return null;
        }

        /// <summary>
        /// 获得cell在表格中的列号.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        internal int GetColNum(TPTextCell cell)
        {
            return cell.OwnerRow.IndexOf(cell);
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 是否隐藏所有边框
        /// </summary>
        public bool HiddenAllBorder
        {
            get
            {
                return hiddenAllBorder;
            }
            set
            {
                hiddenAllBorder = value;
                if (value == true)
                {
                    foreach (TPTextRow row in this)
                    {
                        foreach (TPTextCell cell in row)
                        {
                            cell.BorderWidth = 0;
                        }
                    }
                }
                else
                {
                    SetEveryCellBorderWidth();
                }
            }
        }
        /// <summary>
        /// 各列的百分比宽度(也可能是绝对宽度,此时和absoluteWidths相同)
        /// </summary>
        internal int[] RelativeWidths
        {
            get { return relativeWidths; }
            set { relativeWidths = value; }
        }

        /// <summary>
        /// 表格各列的绝对宽度
        /// </summary>
        /// <value>The widths.</value>
        public int[] Widths
        {
            get
            {
                return this.absoluteWidths;
            }
            set
            {
                if (value.Length != columns)
                {
                    throw new Exception("列数不相符.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    this.absoluteWidths[i] = value[i];
                }
            }
        }
        /// <summary>
        /// 水平对齐方式
        /// <para>1 左对齐</para>
        /// <para>2 居中对齐</para>
        /// <para>3 右对齐</para>
        /// </summary>
        public int HorizontalAlignment
        {
            get { return horizontalAlignment; }
            set { horizontalAlignment = value; }
        }

        /// <summary>
        /// Get/set the cellpadding.
        /// </summary>
        /// <value>the cellpadding</value>
        public int Cellpadding
        {
            get
            {
                return cellpadding;
            }

            set
            {
                this.cellpadding = value;
            }
        }

        /// <summary>
        /// Get/set the cellspacing.
        /// </summary>
        /// <value>the cellspacing</value>
        public int Cellspacing
        {
            get
            {
                return cellspacing;
            }

            set
            {
                this.cellspacing = value;
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Header
        {
            get { return header; }
            set { header = value; }
        }
        /// <summary>
        /// 列数
        /// </summary>
        public int IntColumns
        {
            get { return columns; }
            set { columns = value; }
        }
        /// <summary>
        /// 行数
        /// </summary>
        public int IntRows
        {
            get { return this.allRows.Count; }
        }
        /// <summary>
        /// 表示所有的行对象
        /// </summary>
        public List<TPTextRow> AllRows
        {
            get
            {
                return allRows;
            }
            set
            {
                allRows = value;
            }
        }
        /// <summary>
        /// 是否固定列宽
        /// </summary>
        public bool IsFixWidth
        {
            get { return isFixWidth; }
            set { isFixWidth = value; }
        }


        public override int Width
        {
            get
            {
                return this.totalWidth;
            }
            set
            {
                if (this.totalWidth == value)
                    return;
                this.totalWidth = value;
                //CalculateWidths();
                //CalculateHeights();
            }
        }

        public override int Height
        {
            get
            {
                CalculateHeights();
                return this.totalHeight;
            }
            set
            {
                this.totalHeight = value;
            }
        }

        #endregion

        #region Container继承override方法

        /// <summary>
        /// 获得对象保存的XML节点的名称
        /// </summary>
        /// <returns></returns>
        public override string GetXMLName()
        {
            return ZYTextConst.c_Table;
        }

        public override Rectangle GetContentBounds()
        {
            //删除表格会出错 add by ywk 2012年10月16日 15:12:26 
            if (allRows.Count > 0)
            {
                if (allRows[0].Cells.Count > 0)
                {
                    int x = allRows[0].Cells[0].RealLeft;
                    int y = allRows[0].Cells[0].RealTop;
                    return new Rectangle(x, y, this.Width, this.Height);
                }
                else
                {
                    return new Rectangle(0, 0, this.Width, this.Height);
                }
            }
            else
            {
                return new Rectangle(0, 0, this.Width, this.Height);
            }
            //int x = allRows[0].Cells[0].RealLeft;
            //int y = allRows[0].Cells[0].RealTop;
            //return new Rectangle(x, y, this.Width, this.Height);
        }

        #region IsNewLine
        public override bool OwnerWholeLine()
        {
            return true;
        }
        public override bool isNewLine()
        {
            return true;
        }
        public override bool isNewParagraph()
        {
            return true;
        }

        public override bool isField()
        {
            return true;
        }

        public override bool isTextElement()
        {
            return false;
        }
        #endregion

        /// <summary>
        /// 将容器内所有的元素添加到列表对象中
        /// </summary>
        /// <param name="myList">列表对象</param>
        /// <param name="ResetFlag">是否重置元素的状态</param>
        public override void AddElementToList(ArrayList myList, bool ResetFlag)
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
                        (myElement as TPTextRow).AddElementToList(myList, ResetFlag);
                    }
                }
            }
        }



        /// <summary>
        /// 刷新界面,重新绘制对象
        /// </summary>
        /// <returns>是否进行了刷新操作</returns>
        public override bool RefreshView()
        {
            return base.RefreshView();
        }

        /// <summary>
        /// 刷新内部元素的大小
        /// </summary>
        /// <returns></returns>
        public override bool RefreshSize()
        {
            return base.RefreshSize();
        }
        /// <summary>
        /// 元素重新分行
        /// </summary>
        /// <returns></returns>
        public override System.Collections.ArrayList RefreshLine()
        {
            base.RefreshLine();
            return myLines;
        }

        /// <summary>
        /// Froms the XML.
        /// </summary>
        /// <param name="myElement">My element.</param>
        /// <returns></returns>
        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (null != myElement)
            {
                myAttributes.FromXML(myElement);



                if (myElement.HasAttribute("offsetX")) //add by myc 2014-05-06 添加原因 记录水平拖拽表格偏移量
                {
                    this.OffsetX = Convert.ToInt32(myElement.GetAttribute("offsetX"));
                }
                else
                {
                    this.OffsetX = 0;
                }



                this.Width = myAttributes.GetInt32("width");
                //this.Height = myAttributes.GetInt32("height");
                this.Header = myAttributes.GetString("title");
                this.horizontalAlignment = myAttributes.GetInt32("align");
                this.IsFixWidth = myAttributes.GetInt32("fixwidth") == 1 ? true : false;
                this.HiddenAllBorder = (myAttributes.GetInt32("hidden-all-border") == 1) ? true : false;

                this.allRows.Clear();
                this.ChildElements.Clear();

                for (int i = 0; i < myElement.ChildNodes.Count; i++)
                {
                    XmlElement ele = myElement.ChildNodes.Item(i) as XmlElement;
                    if (ele != null)
                    {
                        if (ele.Name == "table-column")
                        {
                            this.columns = Convert.ToInt32(ele.GetAttribute("columns-number"));
                            List<int> relwidths = new List<int>();
                            for (int j = 0; j < ele.ChildNodes.Count; j++)
                            {
                                XmlElement colwidthEle = ele.ChildNodes.Item(j) as XmlElement;
                                if (colwidthEle != null)
                                {
                                    if (colwidthEle.Name == "column-width")
                                    {
                                        relwidths.Add(Convert.ToInt32(colwidthEle.GetAttribute("width")));
                                    }
                                }
                            }
                            this.relativeWidths = new int[relwidths.Count];
                            for (int k = 0; k < relwidths.Count; k++)
                            {
                                relativeWidths[k] = relwidths[k];
                            }
                            SetWidth(relativeWidths);
                        }
                        if (ele.Name == "table-row")
                        {
                            TPTextRow row = OwnerDocument.CreateElementByXML(ele) as TPTextRow;

                            #region 已注释 add by myc 2014-05-15 旧版表格没有正确处理拆分单元格，合并单元格方法需修正，为后期拖拽单元格奠定基础
                            //row.Widths = this.absoluteWidths;
                            //row.Columns = this.IntColumns; 
                            #endregion

                            SetOwnerTable(row); //add by myc 2014-04-04 添加原因：解决FromXML时拆分单元格的内部嵌套表格行设置所属表格属性

                            row.Width = this.Width;
                            row.Parent = this;
                            this.allRows.Add(row);
                            this.ChildElements.Add(row);
                        }
                    }
                }
                CalculateHeights();


                #region add by myc 2014-05-15 添加原因：解析旧版表格Xml存储结构为新版表格Xml存储结构
                TransformOldTBXmlToNewTBXml();
                #endregion


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
            if (null != myElement)
            {
                myAttributes.SetValue("align", this.horizontalAlignment.ToString());
                myAttributes.SetValue("title", this.Header);
                myAttributes.SetValue("fixwidth", (this.IsFixWidth ? 1 : 0).ToString());
                myAttributes.SetValue("width", this.Width);
                myAttributes.SetValue("hidden-all-border", this.HiddenAllBorder ? 1 : 0);

                XmlElement itemColumn = myElement.OwnerDocument.CreateElement("table-column");
                itemColumn.SetAttribute("columns-number", columns.ToString());
                for (int i = 0; i < this.absoluteWidths.Length; i++)
                {
                    XmlElement item = itemColumn.OwnerDocument.CreateElement("column-width");
                    item.SetAttribute("width", absoluteWidths[i].ToString());
                    itemColumn.AppendChild(item);
                }
                myElement.AppendChild(itemColumn);

                foreach (TPTextRow row in this)
                {
                    XmlElement item = myElement.OwnerDocument.CreateElement(row.GetXMLName());
                    myElement.AppendChild(item);
                    row.ToXML(item);
                }
            }
            myAttributes.ToXML(myElement);


            myElement.SetAttribute("offsetX", this.OffsetX.ToString()); //add by myc 2014-05-06 添加原因 记录水平拖拽表格偏移量


            return true;
        }


        #endregion

        #region 鼠标事件处理,例如选择单元格,行和表格本身

        #region  add by myc 2014-04-30 注释原因：下述程序不支持拆分与合并单元格，并且没有正确实现拖拽单元格
        ///*
        // * 这里要说明一点知识: 有关鼠标划选的执行顺序.
        // *  1. MouseMove 事件。
        // * 	2. MouseDown 事件。
        // * 	3. MouseMove 事件。
        // * 	   --这里有个状态,判断是否是点击状态下的移动,也就是划选.(myOwnerControl.CaptureMouse)
        // * 	4. MouseClick 事件。
        // * 	5. MouseUp 事件。
        // */

        ////用来保存上一次鼠标点击的位置.
        //private Point LastMousePosition = new Point(-1, -1);

        ////鼠标在表格中首次单击时,所处的单元格
        //private TPTextCell currentCell;

        //private TPTextCell dragCell;
        //private List<TPTextCell> leftColCells = new List<TPTextCell>();
        //private List<TPTextCell> rightColCells = new List<TPTextCell>(); 

        //public override bool HandleMouseDown(int x, int y, MouseButtons Button)
        //{
        //    //应该得到鼠标单击时,是单击的那个单元格.以便在MouseMove事件里,判断是否划选出了当前单元格边界
        //    if (Button == MouseButtons.Left)
        //    {
        //        LastMousePosition = new Point(x, y);
        //        //Debug.WriteLine("● Table大小=" + this.GetContentBounds().ToString()); 
        //        //如果是在表格内点击
        //        if (this.GetContentBounds().Contains(LastMousePosition) && OwnerDocument.OwnerControl.Cursor == Cursors.IBeam)
        //        {
        //            for (int i = 0; i < this.allRows.Count; i++)
        //            {
        //                for (int k = 0; k < this.allRows[i].Cells.Count; k++)
        //                {
        //                    //将已经选中的cell添加到无效区域内
        //                    if (this.allRows[i][k].Selected == true || this.allRows[i][k].CanAccess == true)
        //                    {
        //                        OwnerDocument.OwnerControl.AddInvalidateRect(this.allRows[i][k].GetContentBounds());
        //                        //使所有已经选中的cell设为没有选中的状态
        //                        this.allRows[i][k].Selected = false;
        //                        this.allRows[i][k].CanAccess = false;
        //                    }

        //                    //找到当前点击的那个cell
        //                    if (this.allRows[i][k].IsContain(x, y))
        //                    {
        //                        currentCell = this.allRows[i][k];
        //                        currentCell.CanAccess = true;
        //                        //Debug.WriteLine("● (" + i + "," + k +")被选择");
        //                        //Debug.WriteLine(IsInRowSpan(currentCell) ? "●在rowspan●" : "●no inside●");
        //                    } 
        //                }
        //            }

        //            //刷新无效区域
        //            myOwnerDocument.OwnerControl.UpdateInvalidateRect();

        //            return false;

        //        }
        //        else if (this.GetContentBounds().Contains(LastMousePosition) && OwnerDocument.OwnerControl.Cursor == Cursors.VSplit)
        //        {
        //            //得到要拖拽的单元格，在按下鼠标的时候记录下拖拽的单元格 Modified by wwj 2012-02-16
        //            SetRecordDragCell(x, y);

        //            //TODO: 当鼠标出于cell的边界处时.此时点击,应该显示一条全页范围内的的纵向虚线,用来拖拽. [ 虚线暂时弄不出来,以后再改 ]

        //            //down时,根绝dragCell得到要调整的两列的所有格子(点击处左右两处的列)
        //            int rightNum = GetColNum(dragCell);
        //            int leftNum = rightNum - 1;
        //            foreach (TPTextRow row in this)
        //            {
        //                //在这i代表列号
        //                for (int i = 0; i < row.Cells.Count; i++)
        //                {
        //                    if (i == leftNum)
        //                    {
        //                        leftColCells.Add(row.Cells[i]);
        //                    }
        //                    if (i == rightNum)
        //                    {
        //                        rightColCells.Add(row.Cells[i]);
        //                    }
        //                }
        //            }
        //            Debug.WriteLine("●调整列宽前●");
        //            for (int i = 0; i < absoluteWidths.Length; i++)
        //            {
        //                Debug.WriteLine("第" + i + "列:" + absoluteWidths[i]);
        //            }
        //            //Rectangle drec = new Rectangle(dragCell.RealLeft, 0, 5, OwnerDocument.OwnerControl.CurrentPage.Height); 
        //        }
        //        else // 在表格外点击
        //        {
        //            foreach (TPTextRow row in this)
        //            {
        //                foreach (TPTextCell cell in row)
        //                {
        //                    myOwnerDocument.OwnerControl.AddInvalidateRect(cell.GetContentBounds());
        //                    cell.Selected = false;
        //                    cell.CanAccess = false;
        //                }
        //            }
        //            currentCell = null;
        //            myOwnerDocument.OwnerControl.UpdateInvalidateRect();
        //        }
        //    }

        //    return false;
        //}

        //public override bool HandleMouseMove(int x, int y, MouseButtons Button)
        //{

        //    //鼠标移动时的坐标位置,随着鼠标的移动不断的变化
        //    Point p = new Point(x, y);

        //    //如果鼠标还在表格中
        //    if (this.GetContentBounds().Contains(p))
        //    {
        //        //如果是划选
        //        if (myOwnerDocument.OwnerControl.CaptureMouse && currentCell != null)
        //        {
        //            //获取当前鼠标点击处单元格的位置和大小
        //            Rectangle currentRec = currentCell.GetContentBounds();

        //            #region 获得一个选择的橡皮筋矩形区域 SelectRect

        //            Rectangle SelectRect = Rectangle.Empty;
        //            if (p.X > LastMousePosition.X)
        //            {
        //                SelectRect.X = LastMousePosition.X;
        //                SelectRect.Width = p.X - LastMousePosition.X;
        //            }
        //            else
        //            {
        //                SelectRect.X = p.X;
        //                SelectRect.Width = LastMousePosition.X - p.X;
        //            }
        //            if (p.Y > LastMousePosition.Y)
        //            {
        //                SelectRect.Y = LastMousePosition.Y;
        //                SelectRect.Height = p.Y - LastMousePosition.Y;
        //            }
        //            else
        //            {
        //                SelectRect.Y = p.Y;
        //                SelectRect.Height = LastMousePosition.Y - p.Y;
        //            }
        //            #endregion

        //            //Debug.WriteLine("●●●●●");

        //            if (currentRec.Contains(p))
        //            {
        //                myOwnerDocument.Content.AutoClearSelection = false;
        //                myOwnerDocument.Content.MoveTo(x, y);
        //                ZYTextElement myElement = myOwnerDocument.Content.CurrentElement;
        //                myOwnerDocument.OwnerControl.MoveCaretWithScroll = false;
        //                myOwnerDocument.OwnerControl.UpdateTextCaret();
        //                myOwnerDocument.OwnerControl.MoveCaretWithScroll = true;

        //                return true;
        //            }
        //            else
        //            {
        //                for (int i = 0; i < this.allRows.Count; i++)
        //                {
        //                    ArrayList selectIndex = new ArrayList();
        //                    for (int k = 0; k < this.allRows[i].Cells.Count; k++)
        //                    {
        //                        //取得选择的区域和单元格的交集,用来确定那些单元格被选中了.
        //                        bool flag = SelectRect.IntersectsWith(this.allRows[i][k].GetContentBounds());
        //                        if (this.allRows[i][k].Selected != flag)
        //                        {
        //                            this.allRows[i][k].Selected = flag;
        //                            this.allRows[i][k].CanAccess = flag;

        //                            //add by myc 2014-04-03 添加原因：鼠标划选单元格过程中应该设置内容对象的选择区域长度属性为0，
        //                            //让单元格拖选时只对选中的单元格进行反色背景处理，而不对内部的选中元素进行反色背景处理，避免反色干扰。
        //                            myOwnerDocument.Content.SelectLength = 0;

        //                            //将此单元格添加到无效区域
        //                            myOwnerDocument.OwnerControl.AddInvalidateRect(this.allRows[i][k].GetContentBounds());
        //                            //马上更新无效区域
        //                            myOwnerDocument.OwnerControl.UpdateInvalidateRect();
        //                        } 
        //                    }
        //                }


        //                //此处加入测试几个单元格被选中的代码

        //                return true;
        //            }
        //        }
        //        else if (myOwnerDocument.OwnerControl.CaptureMouse && currentCell == null && OwnerDocument.OwnerControl.Cursor == Cursors.VSplit)
        //        {
        //            //TODO: 此时是调整表格列宽的时候,应该让纵穿整个页面的虚线随着鼠标移动
        //            ResizeToRectangle();
        //            return true;
        //        }
        //        else if (myOwnerDocument.OwnerControl.CaptureMouse == false)
        //        {
        //            //设置光标状态 Modified By wwj 2012-02-16
        //            SetCursorStatus(p.X, p.Y);
        //        }
        //    }
        //    return false;
        //}

        //public override bool HandleMouseUp(int x, int y, MouseButtons Button)
        //{
        //    bool isDragDone = false;//表示是否处理过拖拽操作 是：返回true 否：返回false
        //    if (OwnerDocument.OwnerControl.Cursor == Cursors.VSplit)
        //    {
        //        if (dragCell != null)
        //        {
        //            isDragDone = true;
        //            //确定鼠标要调整的宽度,为正数则是向右拖拽,为负数则是向左拖拽
        //            int moveWidth = x - dragCell.RealLeft;
        //            Debug.WriteLine("●●●●调整的宽度: " + moveWidth);
        //            int acol = GetColNum(dragCell);
        //            int[] tmpWidth = new int[absoluteWidths.Length];
        //            for (int i = 0; i < absoluteWidths.Length; i++)
        //            {
        //                if (i == (acol - 1))
        //                {
        //                    tmpWidth[i] = absoluteWidths[i] + moveWidth;
        //                }
        //                else if (i == acol)
        //                {
        //                    tmpWidth[i] = absoluteWidths[i] - moveWidth;
        //                }
        //                else
        //                {
        //                    tmpWidth[i] = absoluteWidths[i];
        //                }
        //            }
        //            SetWidth(tmpWidth);
        //            foreach (TPTextRow row in this)
        //            {
        //                row.Widths = tmpWidth;
        //            }
        //            foreach (TPTextCell cell in leftColCells)
        //            {
        //                if (cell.Width != 0)
        //                {
        //                    cell.Width = cell.Width + moveWidth;
        //                }
        //            }
        //            foreach (TPTextCell cell in rightColCells)
        //            {
        //                if (cell.Width != 0)
        //                {
        //                    cell.Width = cell.Width - moveWidth;
        //                }
        //            }
        //            Debug.WriteLine("●调整列宽后●");
        //            for (int i = 0; i < absoluteWidths.Length; i++)
        //            {
        //                Debug.WriteLine("第" + i + "列:" + absoluteWidths[i]);
        //            }

        //            OwnerDocument.ContentChanged();
        //            OwnerDocument.Refresh(); 
        //        }
        //    }

        //    LastMousePosition = new Point(-1, -1);
        //    currentCell = null;

        //    dragCell = null;
        //    leftColCells.Clear();
        //    rightColCells.Clear();

        //    return isDragDone;
        //} 
        #endregion

        public override void HandleEnter()
        {
            base.HandleEnter();
        }

        public override void HandleLeave()
        {
            base.HandleLeave();
        }

        public override bool HandleClick(int x, int y, MouseButtons Button)
        {
            return base.HandleClick(x, y, Button);
        }

        public override bool HandleDblClick(int x, int y, MouseButtons Button)
        {
            return base.HandleDblClick(x, y, Button);
        }
        #endregion

        #region IEnumerable<TPTextRow> 成员

        IEnumerator<TPTextRow> IEnumerable<TPTextRow>.GetEnumerator()
        {
            return this.allRows.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.allRows.GetEnumerator();
        }

        #endregion

        #region IEnumerator<TPTextRow> 成员

        TPTextRow IEnumerator<TPTextRow>.Current
        {
            get
            {
                try
                {
                    return this.allRows[position];
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
                    return this.allRows[position];
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
            return (position < this.allRows.Count);
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        #endregion

        #region Add By wwj 2012-02-16 表格拖拽相关

        #region 用于表格拖拽的判断，已经记录需要拖拽的单元格

        const string s_CursorVSplit = "VSplit";//用于拖拽竖向的光标
        const string s_CursorHSplit = "HSplit";//用于拖拽横向的光标

        /// <summary>
        /// 设置光标状态，return：是否需要记录拖拽的单元格
        /// </summary>
        /// <param name="x">鼠标X轴方向上的坐标</param>
        /// <param name="y">鼠标Y轴方向上的坐标</param>
        /// <returns>是否需要记录拖拽的单元格</returns>
        private void SetCursorStatus(int x, int y)
        {
            TPTextCell cell;
            string cursorStatus = GetCursorNeedStatus(x, y, out cell);
            if (cursorStatus == s_CursorVSplit)
            {
                if (myOwnerDocument.OwnerControl.Cursor != Cursors.VSplit)
                {
                    myOwnerDocument.OwnerControl.SetCursor(Cursors.VSplit);
                }
            }
            else if (cursorStatus == s_CursorHSplit)
            {
                //TODO: 鼠标调整高度,暂无实现;
                //myOwnerDocument.OwnerControl.SetCursor(Cursors.HSplit); 
            }
        }

        /// <summary>
        /// 设置需要记录拖拽的单元格
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetRecordDragCell(int x, int y)
        {
            TPTextCell cell;
            string cursorStatus = GetCursorNeedStatus(x, y, out cell);
            if (cursorStatus == s_CursorVSplit)
            {
                dragCell = cell;
            }
            else if (cursorStatus == s_CursorHSplit)
            {
                //TODO: 鼠标调整高度,暂无实现;
            }
        }

        /// <summary>
        /// 得到光标需要的状态VSplit或HSplit
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private string GetCursorNeedStatus(int x, int y, out TPTextCell dragCell)
        {
            Point p = new Point(x, y);
            dragCell = new TPTextCell();
            string cursorStatus = string.Empty;
            for (int i = 0; i < this.allRows.Count; i++)
            {
                //从第二列开始.cell的左边的边框总是存在的.
                for (int k = 1; k < this.allRows[i].Cells.Count; k++)
                {
                    TPTextCell cell = this.allRows[i].Cells[k];
                    if (cell.Merged == false)
                    {
                        if (p.X >= (cell.RealLeft - 5) && p.X <= (cell.RealLeft + 5) && p.Y >= (cell.RealTop) && p.Y <= (cell.RealTop + cell.Height))
                        {
                            cursorStatus = s_CursorVSplit;
                            dragCell = cell;
                        }
                        if (p.X >= (cell.RealLeft) && p.X <= (cell.RealLeft + cell.Width) && p.Y >= (cell.RealTop - 5) && p.Y <= (cell.RealTop + 5))
                        {
                            cursorStatus = s_CursorHSplit;

                            //TODO: 鼠标调整高度,暂无实现;
                        }
                    }
                }
            }
            return cursorStatus;
        }

        #endregion

        #region 绘制用来拖拽的纵向虚线

        //绘制虚线的矩形
        Rectangle m_MouseDownRect = Rectangle.Empty;

        private void ResizeToRectangle()
        {
            //绘制虚线前将原先的虚线擦除
            DrawRectangle();

            Point p = this.OwnerDocument.OwnerControl.PointToScreen(new Point(0, 0));//得到编辑器在Screen中的坐标

            //设置竖直虚线的位置
            m_MouseDownRect.X = Cursor.Position.X;
            m_MouseDownRect.Y = p.Y;
            m_MouseDownRect.Width = 1;
            m_MouseDownRect.Height = this.OwnerDocument.OwnerControl.Height;

            //绘制新的虚线
            DrawRectangle();
        }
        private void DrawRectangle()
        {
            ControlPaint.DrawReversibleFrame(m_MouseDownRect, Color.White, FrameStyle.Dashed);
        }

        #endregion

        #endregion

        /// <summary>
        /// 克隆TPTextTable，得到深层次的副本
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public TPTextTable Clone()
        {
            TPTextTable newTable = new TPTextTable();
            newTable.OwnerDocument = OwnerDocument;
            newTable.header = header;
            newTable.columns = columns;

            int defRowHeight = this.OwnerDocument.Content.CurrentElement.Height;
            int defTableWidth = totalWidth; ;

            newTable.defaultRowHeight = defRowHeight;
            newTable.defaultTableWidth = defTableWidth;
            newTable.totalWidth = totalWidth;

            newTable.SetTotalWidth(0);//自动扩展

            newTable.absoluteWidths = absoluteWidths;

            for (int i = 0; i < AllRows.Count; i++)
            {
                TPTextRow someRow = AllRows[i].Clone();
                someRow.Parent = newTable;
                someRow.OwnerTable = newTable;
                newTable.allRows.Add(someRow);
                newTable.myChildElements.Add(someRow);
            }

            newTable.CalculateHeights();
            return newTable;
        }

        /// <summary>
        /// 重新设置表格中所有单元格的边框大小。
        /// </summary>
        public void SetEveryCellBorderWidth()
        {
            for (int i = 0; i < this.allRows.Count; i++)
            {
                allRows[i].SetRowsBorderWidth(false);
                if (i == (this.allRows.Count - 1))
                {
                    allRows[i].SetRowsBorderWidth(true);
                }
            }
        }









        #region 新版表格处理程序 add by myc 2014-05-12 finish by myc 2014-05-16
        #region 合并单元格（已修订完毕） add by myc 2014-05-12
        /// <summary>
        /// 鼠标拖选时得到的能完全覆盖选中单元格的最小外围矩形。
        /// </summary>
        private Rectangle MinOuterRect = Rectangle.Empty;

        /// <summary>
        /// 鼠标拖选时得到的选中合并单元格集合，
        /// 用于将其覆盖的占位单元格添加到选中单元格集合中，消除差异性，实现有序合并。
        /// </summary>
        private List<TPTextCell> SelectedMergeCells = new List<TPTextCell>();

        /// <summary>
        /// 鼠标拖选时得到的选中单元格的父级拆分单元格集合。
        /// </summary>
        private List<TPTextCell> SelectedSplitCells = new List<TPTextCell>();

        /// <summary>
        /// 存储遍历表格内部单元格时，到达的最深递归遍历层次，初始值为1对应于基本表格。
        /// </summary>
        public int RecusiveTraversalLevel = 1;

        /// <summary>
        /// 判断某个表格行是否为占位表格行，对应于其内部的所有单元格都为占位单元格。
        /// </summary>
        public bool IsFlagRow(TPTextRow row)
        {
            try
            {
                bool flag = false;
                foreach (TPTextCell cell in row)
                {
                    if (cell.ChildCount == 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查当前操作表格内部的顶级表格行元素或拆分单元格中是否存在占位行，存在时则判断是否需要删除以便于维护表格形态结构。
        /// </summary>
        public void CheckFlagRow(TPTextCell mergeCell)
        {
            try
            {
                //得到表格直属孩子或拆分单元格内部中要删除的占位表格行
                List<TPTextRow> flagRows = new List<TPTextRow>();
                if (mergeCell.OwnerRow.Parent is TPTextCell) //合并单元格所属表格行包含在父级拆分单元格内部
                {
                    #region 拆分单元格内部直属表格行元素处理
                    TPTextCell parentCell = mergeCell.OwnerRow.Parent as TPTextCell;
                    foreach (TPTextRow row in parentCell.ChildElements)
                    {
                        if (!this.IsFlagRow(row)) continue;
                        int checkTop = row[0].OwnerMergeCell.GetContentBounds().Top;
                        bool isDelete = true;
                        foreach (TPTextCell cell in row)
                        {
                            TPTextCell tempCell = cell.OwnerMergeCell;
                            if (tempCell.RealTop == checkTop) continue;
                            isDelete = false;
                            break;
                        }

                        if (!isDelete) return;
                        flagRows.Add(row);
                    }
                    foreach (TPTextRow flagRow in flagRows)
                    {
                        //移除占位表格行内的占位单元格与合并掉它的合并单元格的对应关系
                        foreach (TPTextCell flagCell in flagRow)
                        {
                            flagCell.OwnerMergeCell.HasFlagCells.Remove(flagCell);
                        }
                        parentCell.ChildElements.Remove(flagRow);
                        parentCell.Lines.Remove(flagRow);
                    }
                    #endregion
                }
                else //合并单元格所属表格行为表格的直属孩子
                {
                    #region 表格内部直属表格行元素处理
                    TPTextTable currTB = mergeCell.OwnerRow.OwnerTable;
                    foreach (TPTextRow row in currTB)
                    {
                        if (!this.IsFlagRow(row)) continue;
                        int checkTop = row[0].OwnerMergeCell.GetContentBounds().Top;
                        bool isDelete = true;
                        foreach (TPTextCell cell in row)
                        {
                            TPTextCell tempCell = cell.OwnerMergeCell;
                            if (tempCell.GetContentBounds().Top == checkTop) continue;
                            isDelete = false;
                            break;
                        }

                        if (!isDelete) return;
                        flagRows.Add(row);
                    }
                    foreach (TPTextRow flagRow in flagRows)
                    {
                        //移除占位表格行内的占位单元格与合并掉它的合并单元格的对应关系
                        foreach (TPTextCell flagCell in flagRow)
                        {
                            flagCell.OwnerMergeCell.HasFlagCells.Remove(flagCell);
                        }

                        currTB.AllRows.Remove(flagRow);
                        currTB.ChildElements.Remove(flagRow);
                        currTB.Lines.Remove(flagRow);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查鼠标拖选时得到的选中单元格集合内的单元格组成的区域是否为规则矩形。
        /// 如果是则表示可以进行合并单元格操作并返回最小外围矩形，反之则返回空矩形。
        /// 注意采用最小外围矩形和面积定理时，必须确保拆分单元格算法真正实现边界对齐。
        /// </summary>
        public bool CheckIsCanMerge()
        {
            try
            {
                //初始化最小外围矩形的边界位置
                Rectangle firstRect = myOwnerDocument.SelectedCells[0].GetContentBounds();
                int cLeft = firstRect.Left;
                int cTop = firstRect.Top;
                int cRight = firstRect.Left + firstRect.Width;
                int cBottom = firstRect.Top + firstRect.Height;
                int allArea = 0; //存储选中单元格集合内非占位单元格的面积之和

                //遍历选中单元格集合，比较非占位单元格的边界位置，最终得到能完全包含它们的最小外围矩形
                foreach (TPTextCell cell in myOwnerDocument.SelectedCells)
                {
                    if (cell.ChildCount == 0) continue;
                    Rectangle rect = cell.GetContentBounds();
                    if (rect.Left < cLeft)
                    {
                        cLeft = rect.Left;
                    }
                    if (rect.Top < cTop)
                    {
                        cTop = rect.Top;
                    }
                    if (rect.Left + rect.Width > cRight)
                    {
                        cRight = rect.Left + rect.Width;
                    }
                    if (rect.Top + rect.Height > cBottom)
                    {
                        cBottom = rect.Top + rect.Height;
                    }
                    allArea += rect.Width * rect.Height;
                }
                //Rectangle outerRect = new Rectangle(cLeft, cTop, cRight - cLeft, cBottom - cTop);
                MinOuterRect = new Rectangle(cLeft, cTop, cRight - cLeft, cBottom - cTop);

                //比较最小外围矩形面积与累加计算得到的面积是否相等
                return MinOuterRect.Width * MinOuterRect.Height == allArea;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查是否为复杂情况下的合并单元格操作，如果是则不继续向下执行有序合并例程。
        /// </summary>
        public bool IsComplexMerge()
        {
            try
            {
                bool flag = false;

                foreach (TPTextCell splitCell in SelectedSplitCells)
                {
                    Rectangle rect = splitCell.GetContentBounds();
                    //检查最小外围矩形是否被完全包围在拆分单元格内部
                    //如果是，则表明也可以进行合并操作，此时为拆分单元格内部的合并单元格操作
                    if (MinOuterRect.Left >= rect.Left && MinOuterRect.Top >= rect.Top
                    && MinOuterRect.Left + MinOuterRect.Width <= rect.Left + rect.Width && MinOuterRect.Top + MinOuterRect.Height <= rect.Top + rect.Height)
                    {
                        flag = false;
                    }
                    else if (rect.Left >= MinOuterRect.Left && rect.Top >= MinOuterRect.Top
                    && rect.Left + rect.Width <= MinOuterRect.Left + MinOuterRect.Width && rect.Top + rect.Height <= MinOuterRect.Top + MinOuterRect.Height)
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 合并单元格的核心处理算法——遍历选中单元格集合内指定递归层次的单元格，构建属于这个指定递归层次的待(纵向)合并的表格行集合的集合。
        /// </summary>
        /// <param name="level">指定递归层次。</param>
        public List<List<List<TPTextCell>>> RecusiveMergeRowsList(int level)
        {
            try
            {
                //同一递归层次的表格行集合
                List<List<TPTextCell>> levelRows = new List<List<TPTextCell>>();
                //同一递归层次的单元格组成的表格行
                List<TPTextCell> lastRow = new List<TPTextCell>();
                //当前递归层次的单元格集合
                List<TPTextCell> levelCells = new List<TPTextCell>();
                foreach (TPTextCell cell in myOwnerDocument.SelectedCells)
                {
                    if (cell.ChildCount > 0) //单元格内容处理
                    {
                        for (int i = 0; i < cell.ChildCount; i++)
                        {
                            ZYTextParagraph para = cell.ChildElements[i] as ZYTextParagraph;
                            if (para != null && para.ChildCount > 1) //段落内只有一个换行符时不参与单元格内容合并
                            {
                                if (!myOwnerDocument.mergeParas.Contains(para))
                                {
                                    myOwnerDocument.mergeParas.Add(para);
                                }
                            }
                        }
                    }

                    if (lastRow.Count == 0) //初始化单元格集合
                    {
                        if (cell.Level == level)
                        {
                            lastRow.Add(cell);
                            //当前遍历的单元格已是选中单元格集合内最后一个单元格
                            if (myOwnerDocument.SelectedCells.IndexOf(cell) == myOwnerDocument.SelectedCells.Count - 1)
                            {
                                levelRows.Add(lastRow);
                            }
                            levelCells.Add(cell);
                        }
                    }
                    else //进行比较
                    {
                        if (cell.Level == level) //遇到同一递归层次的单元格时
                        {
                            //判断两个单元格是否处于同一表格行内
                            if (cell.OwnerRow.GetContentBounds() == lastRow[0].OwnerRow.GetContentBounds())
                            {
                                lastRow.Add(cell);
                                //当前遍历的单元格已是选中单元格集合内最后一个单元格
                                if (myOwnerDocument.SelectedCells.IndexOf(cell) == myOwnerDocument.SelectedCells.Count - 1)
                                {
                                    levelRows.Add(lastRow);
                                }
                            }
                            else
                            {
                                levelRows.Add(lastRow);
                                lastRow = new List<TPTextCell>();
                                lastRow.Add(cell);
                                //当前遍历的单元格已是选中单元格集合内最后一个单元格
                                if (myOwnerDocument.SelectedCells.IndexOf(cell) == myOwnerDocument.SelectedCells.Count - 1)
                                {
                                    levelRows.Add(lastRow);
                                }
                            }
                            levelCells.Add(cell);
                        }
                        else //遇到其他递归层次的单元格时
                        {
                            levelRows.Add(lastRow);
                            lastRow = new List<TPTextCell>();
                        }
                    }
                }

                //同一递归层次的待纵向合并的表格行集合的集合
                List<List<List<TPTextCell>>> mergeRowsList = new List<List<List<TPTextCell>>>();
                //同一递归层次的待纵向合并的表格行集合
                List<List<TPTextCell>> lastRows = new List<List<TPTextCell>>();
                //注意领头的单元格(合并单元格的规则决定+对象引用类型)不能移除，需要参与上层合并单元格操作
                List<TPTextCell> leadCells = new List<TPTextCell>();
                foreach (List<TPTextCell> row in levelRows)
                {
                    if (lastRows.Count == 0) //初始化待纵向合并的表格行集合
                    {
                        lastRows.Add(row);
                        //当前遍历表格行已是同一递归层次的表格行集合内最后一个表格行
                        if (levelRows.IndexOf(row) == levelRows.Count - 1)
                        {
                            mergeRowsList.Add(lastRows);
                        }
                        if (!leadCells.Contains(lastRows[0][0]))
                        {
                            leadCells.Add(lastRows[0][0]);
                        }
                    }
                    else //进行比较
                    {
                        //判断两个表格行是否处于同一父容器内
                        if (row[0].OwnerRow.Parent.GetContentBounds() == lastRows[0][0].OwnerRow.Parent.GetContentBounds())
                        {
                            lastRows.Add(row);
                            //当前遍历表格行已是同一递归层次的表格行集合内最后一个表格行
                            if (levelRows.IndexOf(row) == levelRows.Count - 1)
                            {
                                mergeRowsList.Add(lastRows);
                            }
                        }
                        else
                        {
                            mergeRowsList.Add(lastRows);
                            lastRows = new List<List<TPTextCell>>();
                            lastRows.Add(row);
                            //当前遍历表格行已是同一递归层次的表格行集合内最后一个表格行
                            if (levelRows.IndexOf(row) == levelRows.Count - 1)
                            {
                                mergeRowsList.Add(lastRows);
                            }
                        }
                        if (!leadCells.Contains(lastRows[0][0]))
                        {
                            leadCells.Add(lastRows[0][0]);
                        }
                    }
                }

                //将当前递归层次的被合并掉的若干个单元格从选中单元格集合内移除
                foreach (TPTextCell cell in levelCells)
                {
                    if (leadCells.Contains(cell)) continue;
                    myOwnerDocument.SelectedCells.Remove(cell);
                }

                return mergeRowsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 导入外部表格Xml（已修订完毕） add by myc 2014-04-04 update by myc 2014-05-16
        /// <summary>
        /// 从某个表格行向孩子层次递归设置内部嵌套表格行的所属表格属性。
        /// </summary>
        /// <param name="row">待处理的某个表格行。</param>
        private bool SetOwnerTable(TPTextRow row)
        {
            try
            {
                foreach (TPTextCell cell in row)
                {
                    if (cell.ChildCount == 0) continue; //占位单元格
                    if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                    {
                        foreach (TPTextRow innerRow in cell.ChildElements)
                        {
                            if (SetOwnerTable(innerRow)) continue; //递归调用
                        }
                    }
                }
                row.OwnerTable = this;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 旧版表格之计算某一个表格行的高度。
        /// </summary>
        /// <param name="row">待计算高度的表格行。</param>
        /// <returns></returns>
        private int GetRowHeightOld(TPTextRow row)
        {
            try
            {
                bool isInit = false; //是否初始化表格行高度
                int resultHeight = 0; //保存最终计算所得的表格行高度
                foreach (TPTextCell cell in row)
                {
                    if (cell.ChildCount == 0) //占位单元格（新版表格采用）
                    {
                        if (cell.Attributes.Count == 0) continue; //计数单元格（旧版表格采用）
                    }

                    if (!isInit)
                    {
                        resultHeight = cell.Height;
                        isInit = true;
                    }
                    else
                    {
                        resultHeight = resultHeight > cell.Height ? cell.Height : resultHeight;
                    }
                }
                return resultHeight;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新版表格之计算某一个表格行的高度。
        /// </summary>
        /// <param name="row">待计算高度的表格行。</param>
        /// <returns></returns>
        private int GetRowHeightNew(TPTextRow row)
        {
            try
            {
                bool isInit = false; //是否初始化表格行高度
                int resultHeight = 0; //保存最终计算所得的表格行高度
                foreach (TPTextCell cell in row)
                {
                    if (!isInit)
                    {
                        resultHeight = cell.Height;
                        isInit = true;
                    }
                    else
                    {
                        resultHeight = resultHeight > cell.Height ? cell.Height : resultHeight;
                    }
                }
                return resultHeight;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否已初始化表格内的合并单元格与占位单元格的关联关系。
        /// </summary>
        public bool IsInitRelevance = false;

        /// <summary>
        /// 存储导入外部表格Xml时的表格内原有合并单元格。
        /// </summary>
        public List<TPTextCell> InitMergeCells = new List<TPTextCell>();

        /// <summary>
        /// 通过计算得到某个占位单元格的合并单元格。
        /// </summary>
        /// <returns></returns>
        private TPTextCell GetMergeCell(TPTextCell flagCell)
        {
            try
            {
                TPTextCell mergeCell = null;
                Rectangle flagRect = flagCell.GetContentBounds();
                foreach (TPTextCell cell in InitMergeCells)
                {
                    Rectangle mergeRect = cell.GetContentBounds();
                    //比较单元格内容边界
                    if (mergeRect.Left <= flagRect.Left && mergeRect.Top <= flagRect.Top
                        && mergeRect.Right >= flagRect.Right && mergeRect.Bottom >= flagRect.Bottom)
                    {
                        mergeCell = cell;
                        break;
                    }
                }
                return mergeCell;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 解析旧版表格Xml存储结构，并正确转换为新版表格Xml存储结构。
        /// </summary>
        private void TransformOldTBXmlToNewTBXml()
        {
            try
            {
                #region 检查是否为旧版表格Xml——这个必须先执行，新版表格Xml无须进行解析了
                bool isNeedTransform = false; //标志当前导入的Xml是旧版表格，需要解析此旧版表格Xml，用于兼容旧版表格Xml存储结构。
                foreach (TPTextRow row in this)
                {
                    foreach (TPTextCell cell in row)
                    {
                        if (cell.ChildCount == 0) //占位单元格
                        {
                            if (cell.Attributes.Count == 0) //非计数单元格
                            {
                                isNeedTransform = true;
                                break;
                            }
                        }
                    }
                    if (isNeedTransform) break;
                }

                if (!isNeedTransform) return;
                #endregion

                #region 处理旧版表格Xml中出现的计数单元格混杂新版表格Xml占位单元格的情况——解决 2014-05-15 出现的打开部分病历异常情况
                foreach (TPTextRow row in this)
                {
                    foreach (TPTextCell cell in row)
                    {
                        if (cell.ChildCount == 0) //占位单元格
                        {
                            if (cell.Attributes.Count > 0) //非计数单元格
                            {
                                cell.Attributes.Clear();
                            }
                        }
                    }
                }
                #endregion

                #region 开始解析旧版表格Xml
                foreach (TPTextRow row in this)
                {
                    int currRowHeight = GetRowHeightOld(row); //计算当前遍历的row的行高度

                    #region 先不删除计数单元格，维持单元格在表格行内的索引顺序，在特定位置插入占位单元格
                    List<TPTextCell> countCells = new List<TPTextCell>(); //存储当前遍历表格行内的计数单元格
                    int rowIndex = this.IndexOf(row); //当前遍历表格行在其所属表格内的行索引号
                    int j = 0; //计数器——对应旧版表格Xml分割列属性
                    foreach (TPTextCell cell in row)
                    {
                        #region 修正当前遍历非计数单元格宽度
                        if (cell.ChildCount > 0)
                        {
                            int tempWidth = 0;
                            int minFixWidth = this.absoluteWidths[j]; //出错异常根本原因在此处
                            for (int i = j; i < j + cell.Colspan; i++)
                            {
                                tempWidth += this.absoluteWidths[i];
                                minFixWidth = minFixWidth > this.absoluteWidths[j] ? this.absoluteWidths[j] : minFixWidth; //正确处理医嘱
                            }

                            if (cell.Width - tempWidth >= minFixWidth)
                            {
                                //cell.Width = tempWidth;
                            }
                            else
                            {
                                cell.Width = tempWidth;
                            }
                        }
                        #endregion

                        j++; //累加计数器

                        if (cell.ChildCount == 0 && cell.Attributes.Count == 0) //计数单元格
                        {
                            countCells.Add(cell); //必须放在这里执行
                            continue;
                        }

                        #region 处理遍历到的合并单元格
                        if (cell.Height > currRowHeight)
                        {
                            int cellIndex = row.IndexOf(cell); //当前遍历单元格在其所属表格行内的索引号
                            for (int i = 1; i < cell.Rowspan; i++)
                            {
                                TPTextRow newRow = this.AllRows[rowIndex + i];
                                TPTextCell flagCell = new TPTextCell();
                                flagCell.Width = cell.Width;
                                flagCell.Attributes.SetValue("width", flagCell.Width);
                                flagCell.Height = GetRowHeightOld(newRow);
                                flagCell.Attributes.SetValue("height", flagCell.Height);
                                flagCell.ChildElements.Clear();
                                flagCell.Lines.Clear();

                                flagCell.OwnerRow = newRow;
                                flagCell.Parent = newRow;
                                newRow.Cells.Insert(cellIndex, flagCell);
                                newRow.ChildElements.Insert(cellIndex, flagCell);
                                newRow.Cells.RemoveAt(cellIndex + 1);
                                newRow.ChildElements.RemoveAt(cellIndex + 1);
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region 遍历完当前遍历的row后，移除row内的计数单元格并更新单元格宽度数组属性
                    foreach (TPTextCell cell in countCells)
                    {
                        row.Cells.Remove(cell);
                        row.ChildElements.Remove(cell);
                    }

                    row.Columns = row.Cells.Count;
                    int[] updateWidths = new int[row.Columns];
                    for (int i = 0; i < updateWidths.Length; i++)
                    {
                        updateWidths[i] = row[i].Width;
                    }
                    row.Widths = updateWidths;
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个表格行向孩子层次递归设置内部合并单元格与占位单元格的对应关系。
        /// </summary>
        /// <param name="row">指定的某个表格行。</param>
        public bool RelevanceMergeCellAndFlagCell(TPTextRow row)
        {
            try
            {
                int currRowHeight = GetRowHeightNew(row); //计算当前遍历的row的行高度

                foreach (TPTextCell cell in row)
                {
                    if (cell.ChildCount == 0) //占位单元格
                    {
                        if (InitMergeCells.Count == 0) continue; //第一次检查——>表格内不存在合并单元格
                        TPTextCell mergeCell = GetMergeCell(cell);
                        if (mergeCell == null) continue; //第二次检查——>mergeCell是否为null
                        cell.OwnerMergeCell = mergeCell;
                        mergeCell.HasFlagCells.Add(cell);
                    }
                    else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                    {
                        if (cell.Height > GetRowHeightNew(cell.OwnerRow))
                        {
                            InitMergeCells.Add(cell);
                        }

                        foreach (TPTextRow innerRow in cell.ChildElements)
                        {
                            if (RelevanceMergeCellAndFlagCell(innerRow)) continue;
                        }
                    }
                    else //基本单元格或普通（非拆分的）合并单元格
                    {
                        if (cell.Height > GetRowHeightNew(cell.OwnerRow)) //兼容旧版表格中的合并单元格与占位单元格
                        {
                            InitMergeCells.Add(cell);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 拖拽单元格（需增加针对单个单元格的拖拽） add by myc 2014-04-25 update by myc 2014-05-16
        /// <summary>
        /// 单元格的最小高度——回车符默认宽度为21，中文五号汉字默认宽度为43，单元格左右边距默认宽度都为20。
        /// </summary>
        public static int MinCellWidth = 43 + 21 + 20 + 2; //最大允许插入表格列数为24列——对应视图区最大宽度2064

        /// <summary>
        /// 单元格的最小高度——回车符高度默认为43，中文五号汉字默认宽度为50，单元格顶边距默认高度为20，底边距默认宽度为10。
        /// </summary>
        public static int MinCellHeight = 50 + 30;

        /// <summary>
        /// 记录当前表格是否正在进行打印预览操作。
        /// </summary>
        public static bool IsPrinting;

        #region 设置水平（或垂直）拆分条（已修订完毕）
        /// <summary>
        /// 保存当前水平拆分条在Y轴方向上的坐标或垂直拆分条在X轴方向上的坐标。
        /// </summary>
        private int currBarPos = 0;

        /// <summary>
        /// 拖动水平（或垂直）拆分条时，记录下当前拖拽单元格。
        /// </summary>
        private TPTextCell dragCell;

        /// <summary>
        /// 与横直（或竖直）拖拽虚线对应的窄高（或窄宽）矩形区域。
        /// </summary>
        Rectangle dragRect = Rectangle.Empty;

        /// <summary>
        /// 绘制与水平拆分条处于同一水平位置上的横直拖拽虚线，
        /// 或与垂直拆分条处于同一垂直位置上的竖直拖拽虚线。
        /// </summary>
        private void DrawDragDottedLine()
        {
            try
            {
                //绘制虚线前将原先的虚线擦除
                ControlPaint.DrawReversibleFrame(dragRect, Color.White, FrameStyle.Dashed);
                //得到编辑器控件在屏幕中的坐标
                Point p = myOwnerDocument.OwnerControl.PointToScreen(new Point(0, 0));
                if (myOwnerDocument.OwnerControl.Cursor == Cursors.VSplit)
                {
                    //设置竖直虚线的位置
                    dragRect.X = Cursor.Position.X;
                    if (dragRect.X < p.X || dragRect.X > p.X + myOwnerDocument.OwnerControl.ClientRectangle.Width)
                    {
                        dragRect = Rectangle.Empty;
                        return; //超出编辑器左右边界则不画竖直拖拽虚线
                    }
                    dragRect.Y = p.Y;
                    dragRect.Width = 1;
                    dragRect.Height = myOwnerDocument.OwnerControl.ClientRectangle.Width;
                    //绘制新的虚线
                    ControlPaint.DrawReversibleFrame(dragRect, Color.White, FrameStyle.Dashed);
                }
                else if (myOwnerDocument.OwnerControl.Cursor == Cursors.HSplit)
                {
                    //设置横直虚线的位置
                    dragRect.X = p.X;
                    dragRect.Y = Cursor.Position.Y;
                    dragRect.Height = 1;
                    dragRect.Width = myOwnerDocument.OwnerControl.ClientRectangle.Width;
                    //绘制新的虚线
                    ControlPaint.DrawReversibleFrame(dragRect, Color.White, FrameStyle.Dashed);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个单元格向孩子层次递归计算出是否需要显示水平（或垂直）拆分条，
        /// 如需显示则设置相应的鼠标形状，并记录下当前拆分条的位置坐标。
        /// </summary>
        /// <param name="cell">当前遍历的单元格。</param>
        /// <param name="p">当前鼠标移动位置。</param>
        /// <returns></returns>
        private bool InnerShowSplitBar(TPTextCell cell, Point p)
        {
            try
            {
                if (cell.ChildCount > 0 && cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    foreach (TPTextRow innerRow in cell.ChildElements)
                    {
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            if (InnerShowSplitBar(innerCell, p)) continue;
                        }
                    }
                    return true;
                }
                else //基本单元格或占位单元格或普通（非拆分的）合并单元格
                {
                    #region 判断是否显示垂直拆分条——>默认判断遍历单元格的左边界
                    //以垂直拆分条右侧第一个单元格为拖拽单元格
                    if (p.X >= (cell.RealLeft - 5) && p.X <= (cell.RealLeft + 5) //比较单元格左边界与当前光标位置
                        && p.Y >= (cell.RealTop) && p.Y <= (cell.RealTop + cell.Height))
                    {
                        currBarPos = cell.RealLeft;
                        dragCell = cell;
                        if (myOwnerDocument.OwnerControl.Cursor != Cursors.VSplit)
                        {
                            myOwnerDocument.OwnerControl.SetCursor(Cursors.VSplit);
                        }
                        return true;
                    }
                    else //检查是否为表格最右侧的单元格
                    {
                        if (cell.RealLeft + cell.Width == this.GetContentBounds().Right)
                        {
                            if (p.X >= (cell.RealLeft + cell.Width - 5) && p.X <= (cell.RealLeft + cell.Width + 5) //比较单元格右边界与当前光标位置
                             && p.Y >= (cell.RealTop) && p.Y <= (cell.RealTop + cell.Height))
                            {
                                currBarPos = cell.RealLeft + cell.Width;
                                dragCell = cell;
                                if (myOwnerDocument.OwnerControl.Cursor != Cursors.VSplit)
                                {
                                    myOwnerDocument.OwnerControl.SetCursor(Cursors.VSplit);
                                }
                                return true;
                            }
                        }
                    }
                    #endregion

                    #region 判断是否显示水平拆分条——>默认判断遍历单元格的上边界
                    if (cell.ChildCount == 0) return true; //占位单元格不参与水平拆分条的显示及位置计算

                    //以水平拆分条下侧第一个单元格为拖拽单元格
                    if (p.X >= (cell.RealLeft) && p.X <= (cell.RealLeft + cell.Width) //比较单元格上边界与当前光标位置
                        && p.Y >= (cell.RealTop - 5) && p.Y <= (cell.RealTop + 5))
                    {
                        currBarPos = cell.RealTop;
                        dragCell = cell;
                        if (currBarPos != this.GetContentBounds().Top) //暂时先禁用表格顶端边界显示水平拆分条
                        {
                            if (myOwnerDocument.OwnerControl.Cursor != Cursors.HSplit)
                            {
                                myOwnerDocument.OwnerControl.SetCursor(Cursors.HSplit);
                            }
                        }
                        return true;
                    }
                    else //检查是否为表格最底端的单元格
                    {
                        if (cell.RealTop + cell.Height == this.GetContentBounds().Bottom)
                        {
                            if (p.X >= (cell.RealLeft) && p.X <= (cell.RealLeft + cell.Width) //比较单元格下边界与当前光标位置
                                 && p.Y >= (cell.RealTop + cell.Height - 5) && p.Y <= (cell.RealTop + cell.Height + 5))
                            {
                                currBarPos = cell.RealTop + cell.Height;
                                dragCell = cell;
                                if (myOwnerDocument.OwnerControl.Cursor != Cursors.HSplit)
                                {
                                    myOwnerDocument.OwnerControl.SetCursor(Cursors.HSplit);
                                }
                                return true;
                            }
                        }
                    }
                    #endregion

                    return false; //其他情况不显示拆分条并返回false
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 水平方向左右拖拽（已修订完毕）
        /// <summary>
        /// 当垂直拆分条位于表格最左端时，水平拖拽时需要计算表格整体在X轴方向上的偏移量。
        /// </summary>
        public int OffsetX = 0;

        /// <summary>
        /// 位于当前垂直拆分条左侧的基本单元格（或普通合并单元格）集合。
        /// </summary>
        private List<TPTextCell> LeftBasicCells = new List<TPTextCell>();

        /// <summary>
        /// 位于当前垂直拆分条左侧的拆分单元格集合。
        /// </summary>
        private List<TPTextCell> LeftSplitCells = new List<TPTextCell>();

        /// <summary>
        /// 位于当前垂直拆分条右侧的基本单元格（或普通合并单元格）集合。
        /// </summary>
        private List<TPTextCell> RightBasicCells = new List<TPTextCell>();

        /// <summary>
        /// 位于当前垂直拆分条右侧的拆分单元格集合。
        /// </summary>
        private List<TPTextCell> RightSplitCells = new List<TPTextCell>();

        /// <summary>
        /// 计算需要减小宽度的单元格集合中的最小单元格宽度。
        /// </summary>
        /// <param name="cells">待检查的单元格列表。</param>
        /// <returns></returns>
        private int GetMinCellWidth(List<TPTextCell> cells)
        {
            try
            {
                int minWidth = cells[0].Width;
                foreach (TPTextCell cell in cells)
                {
                    minWidth = cell.Width >= minWidth ? minWidth : cell.Width;
                }
                return minWidth;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个单元格向孩子层次递归设置所属表格行的单元格宽度数组属性。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        /// <returns></returns>
        private bool InnerSetRowWidths(TPTextCell cell)
        {
            try
            {
                if (cell.ChildCount == 0) return true; //占位单元格
                if (!(cell.ChildElements[0] is TPTextRow)) return true; //基本单元格或普通（非拆分的）合并单元格
                foreach (TPTextRow innerRow in cell.ChildElements) //拆分单元格
                {
                    int[] updateWidths = new int[innerRow.Columns];
                    for (int i = 0; i < updateWidths.Length; i++)
                    {
                        updateWidths[i] = innerRow[i].Width;
                    }
                    innerRow.Widths = updateWidths;

                    foreach (TPTextCell innerCell in innerRow)
                    {
                        if (InnerSetRowWidths(innerCell)) continue;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个单元格向孩子层次递归得到拖动垂直拆分条时需要调整的单元格集合。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        /// <returns></returns>
        private bool InnerAdjustCellsV(TPTextCell cell)
        {
            try
            {
                if (cell.ChildCount != 0 && cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    foreach (TPTextRow innerRow in cell.ChildElements)
                    {
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            if (InnerAdjustCellsV(innerCell)) continue;
                        }
                    }
                    return true;
                }
                else //基本单元格或普通（非拆分的）合并单元格或占位单元格
                {
                    if (currBarPos == this.GetContentBounds().Left) //当前垂直拆分条位于表格最左端位置
                    {
                        if (cell.GetContentBounds().Left == currBarPos)
                        {
                            RightBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(RightSplitCells.Contains(splitCell)))
                                {
                                    RightSplitCells.Add(splitCell);
                                }
                            }
                        }

                        return true;
                    }
                    else if (currBarPos == this.GetContentBounds().Right) //当前垂直拆分条位于表格最右端位置
                    {
                        if (cell.GetContentBounds().Right == currBarPos)
                        {
                            LeftBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(LeftSplitCells.Contains(splitCell)))
                                {
                                    LeftSplitCells.Add(splitCell);
                                }
                            }
                        }

                        return true;
                    }
                    else //当前垂直拆分条位于表格中间位置
                    {
                        if (cell.GetContentBounds().Right == currBarPos)
                        {
                            LeftBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(LeftSplitCells.Contains(splitCell)))
                                {
                                    LeftSplitCells.Add(splitCell);
                                }
                            }
                        }

                        if (cell.GetContentBounds().Left == currBarPos)
                        {
                            RightBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(RightSplitCells.Contains(splitCell)))
                                {
                                    RightSplitCells.Add(splitCell);
                                }
                            }
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 鼠标拖拽垂直拆分条时，释放鼠标后的单元格自适应宽度动态调整。
        /// </summary>
        private void AdjustCellWidthV(int x)
        {
            try
            {
                if (IsPrinting) return; //文档正在打印预览时，禁用鼠标拖拽表格内的单元格
                if (this.OwnerDocument.Info.DocumentModel != DocumentModel.Design
                    && this.OwnerDocument.Info.DocumentModel != DocumentModel.Edit) return;

                int moveWidth = 0;
                if (LeftBasicCells.Count == 0 && RightBasicCells.Count > 0) //当前垂直拆分条位于表格左端边界
                {
                    #region 检查是否越界，若越界则修正
                    if (x <= myOwnerDocument.RootDocumentElement.Left)
                    {
                        moveWidth = myOwnerDocument.RootDocumentElement.Left - dragCell.GetContentBounds().Left;
                        this.OffsetX = 0; //鼠标移动位置越过表格左边界则重置偏移量为默认值0
                    }
                    else
                    {
                        moveWidth = x - dragCell.GetContentBounds().Left;
                        if (moveWidth > 0) //向右拖拽时检查RightBasicCells
                        {
                            if (RightBasicCells.Count == 0) return;
                            int minWidth = GetMinCellWidth(RightBasicCells);
                            if (minWidth - moveWidth < MinCellWidth)
                            {
                                moveWidth = minWidth - MinCellWidth;
                            }
                        }
                        //备注：向左拖拽时因为肯定是增加右侧单元格宽度，所以无需检查RightBasicCells
                        this.OffsetX += moveWidth;
                    }
                    this.Width -= moveWidth;
                    #endregion

                    #region 垂直拆分条右侧单元格调整宽度
                    foreach (TPTextCell cell in RightBasicCells)
                    {
                        cell.Width -= moveWidth;
                        cell.AdjustHeight();
                    }

                    foreach (TPTextCell cell in RightSplitCells)
                    {
                        cell.Width -= moveWidth;
                    }
                    #endregion
                }
                else if (LeftBasicCells.Count > 0 && RightBasicCells.Count == 0) //当前垂直拆分条位于表格右端边界
                {
                    #region 检查是否越界，若越界则修正
                    if (x >= myOwnerDocument.RootDocumentElement.Width)
                    {
                        moveWidth = myOwnerDocument.RootDocumentElement.Width - dragCell.GetContentBounds().Right;
                    }
                    else
                    {
                        moveWidth = x - dragCell.GetContentBounds().Right;
                        if (moveWidth < 0) //向左拖拽时检查LeftBasicCells
                        {
                            if (LeftBasicCells.Count == 0) return;
                            int minWidth = GetMinCellWidth(LeftBasicCells);
                            if (minWidth + moveWidth < MinCellWidth)
                            {
                                moveWidth = MinCellWidth - minWidth;
                            }
                        }
                        //备注：向右拖拽时因为肯定是增加左侧单元格宽度，所以无需检查LeftBasicCells
                    }
                    this.Width += moveWidth;
                    #endregion

                    #region 垂直拆分条左侧单元格调整宽度
                    foreach (TPTextCell cell in LeftBasicCells)
                    {
                        cell.Width += moveWidth;
                        cell.AdjustHeight();
                    }

                    foreach (TPTextCell cell in LeftSplitCells)
                    {
                        cell.Width += moveWidth;
                    }
                    #endregion
                }
                else //当前垂直拆分条位于表格中间区域
                {
                    moveWidth = x - dragCell.GetContentBounds().Left;

                    if (moveWidth > 0) //向右拖拽时检查RightBasicCells
                    {
                        if (RightBasicCells.Count == 0) return;

                        int minWidth = GetMinCellWidth(RightBasicCells);
                        if (minWidth - moveWidth < MinCellWidth) //检查是否超出单元格默认最小宽度限制
                        {
                            moveWidth = minWidth - MinCellWidth;
                        }

                        #region 垂直拆分条两侧单元格调整宽度
                        foreach (TPTextCell cell in RightBasicCells)
                        {
                            cell.Width -= moveWidth;
                            cell.AdjustHeight();
                        }

                        foreach (TPTextCell cell in RightSplitCells)
                        {
                            cell.Width -= moveWidth;
                        }

                        foreach (TPTextCell cell in LeftBasicCells)
                        {
                            int saveSH = cell.Height - cell.AllLineHeight - cell.PaddingTop - cell.PaddingBottom;
                            cell.Width += moveWidth;
                            cell.AdjustHeightV(saveSH);
                        }

                        foreach (TPTextCell cell in LeftSplitCells)
                        {
                            cell.Width += moveWidth;
                        }
                        #endregion
                    }
                    else //向左拖拽时检查LeftBasicCells
                    {
                        if (LeftBasicCells.Count == 0) return;

                        int minWidth = GetMinCellWidth(LeftBasicCells);
                        if (minWidth + moveWidth < MinCellWidth) //检查是否超出单元格默认最小宽度限制
                        {
                            moveWidth = MinCellWidth - minWidth;
                        }

                        #region 垂直拆分条两侧单元格调整宽度
                        foreach (TPTextCell cell in LeftBasicCells)
                        {
                            cell.Width += moveWidth;
                            cell.AdjustHeight();
                        }

                        foreach (TPTextCell cell in LeftSplitCells)
                        {
                            cell.Width += moveWidth;
                        }

                        foreach (TPTextCell cell in RightBasicCells)
                        {
                            int saveSH = cell.Height - cell.AllLineHeight - cell.PaddingTop - cell.PaddingBottom;
                            cell.Width -= moveWidth;
                            cell.AdjustHeightV(saveSH);
                        }

                        foreach (TPTextCell cell in RightSplitCells)
                        {
                            cell.Width -= moveWidth;
                        }
                        #endregion
                    }
                }

                #region 更新表格行的单元格宽度数组属性
                //先从内部更新Widths属性
                foreach (TPTextRow row in this)
                {
                    foreach (TPTextCell cell in row)
                    {
                        InnerSetRowWidths(cell);
                    }
                }

                //再更新表格直属孩子的Widths属性
                foreach (TPTextRow row in this)
                {
                    int[] updateWidths = new int[row.Columns];
                    for (int i = 0; i < updateWidths.Length; i++)
                    {
                        updateWidths[i] = row[i].Width;
                    }
                    row.Widths = updateWidths;
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 垂直方向上下拖拽（已修订完毕）
        /// <summary>
        /// 当水平拆分条位于表格最顶端时，垂直拖拽时需要计算表格整体在Y轴方向上的偏移量。
        /// </summary>
        public int OffsetY = 0;

        /// <summary>
        /// 位于当前水平拆分条上侧的基本单元格（或普通合并单元格）集合。
        /// </summary>
        private List<TPTextCell> TopBasicCells = new List<TPTextCell>();

        /// <summary>
        /// 位于当前水平拆分条上侧的拆分单元格集合。
        /// </summary>
        private List<TPTextCell> TopSplitCells = new List<TPTextCell>();

        /// <summary>
        /// 位于当前水平拆分条下侧的基本单元格（或普通合并单元格）集合。
        /// </summary>
        private List<TPTextCell> BottomBasicCells = new List<TPTextCell>();

        /// <summary>
        /// 位于当前水平拆分条下侧的拆分单元格集合。
        /// </summary>
        private List<TPTextCell> BottomSplitCells = new List<TPTextCell>();

        /// <summary>
        /// 计算拖拽单元格时需要减小高度的单元格列表中单元格的最小高度。
        /// </summary>
        /// <param name="cells">待处理的单元格列表。</param>
        /// <returns></returns>
        private int GetMinCellHeight(List<TPTextCell> cells)
        {
            try
            {
                int minH = cells[0].Height; //初始化最小高度
                foreach (TPTextCell cell in cells)
                {
                    minH = cell.Height >= minH ? minH : cell.Height;
                }
                return minH;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 计算需要减小高度的单元格列表中单元格的最小剩余空白高度。
        /// </summary>
        /// <param name="cells">待处理的单元格列表。</param>
        /// <returns></returns>
        private int GetMinSpaceHeight(List<TPTextCell> cells)
        {
            try
            {
                //初始化最小剩余空白高度 
                int minSH = 0;
                if (cells[0].ChildCount == 0) //维护占位单元格最小形态
                {
                    minSH = cells[0].Height - MinCellHeight;
                }
                else
                {
                    minSH = cells[0].Height - cells[0].AllLineHeight - cells[0].PaddingTop - cells[0].PaddingBottom;
                }

                foreach (TPTextCell cell in cells)
                {
                    int tempSH = 0;
                    if (cell.ChildCount == 0) //维护占位单元格最小形态
                    {
                        tempSH = cell.Height - MinCellHeight;
                    }
                    else
                    {
                        tempSH = cell.Height - cell.AllLineHeight - cell.PaddingTop - cell.PaddingBottom;
                    }
                    minSH = tempSH >= minSH ? minSH : tempSH;
                }

                return minSH;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// （下侧单元格）计算当前水平拆分条的宽度，用于判断水平拆分条下侧所有单元格是否只需要整体下移。
        /// </summary>
        /// <param name="cells">待处理的单元格列表。</param>
        /// <returns></returns>
        private int GetHSplitBarWidth(List<TPTextCell> cells)
        {
            try
            {
                //注意必须使用右边界和左边界之差来计算，这样做是为了确保精确
                Rectangle firstRect = cells[0].GetContentBounds();
                int vLeft = firstRect.Left; //初始化水平拆分条的最左边界
                int vRight = firstRect.Right; //初始化水平拆分条的最右边界

                foreach (TPTextCell cell in cells)
                {
                    Rectangle currRect = cell.GetContentBounds();
                    if (currRect.Left < vLeft) //比较左边界
                    {
                        vLeft = currRect.Left;
                    }

                    if (currRect.Right > vRight) //比较右边界
                    {
                        vRight = currRect.Right;
                    }
                }

                return vRight - vLeft;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个单元格向孩子层次递归得到拖动水平拆分条时需要调整的单元格集合。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        /// <returns></returns>
        private bool InnerAdjustCellsH(TPTextCell cell)
        {
            try
            {

                if (cell.ChildCount != 0 && cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    foreach (TPTextRow innerRow in cell.ChildElements)
                    {
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            if (InnerAdjustCellsH(innerCell)) continue;
                        }
                    }
                    return true;
                }
                else //基本单元格或普通（非拆分的）合并单元格
                {
                    if (currBarPos == this.GetContentBounds().Top) //当前水平拆分条位于表格最顶端位置
                    {
                        if (cell.GetContentBounds().Top == currBarPos)
                        {
                            BottomBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(BottomSplitCells.Contains(splitCell)))
                                {
                                    BottomSplitCells.Add(splitCell);
                                }
                            }
                        }
                        return true;
                    }
                    else if (currBarPos == this.GetContentBounds().Bottom) //当前水平拆分条位于表格最底端位置
                    {
                        if (cell.GetContentBounds().Bottom == currBarPos)
                        {
                            TopBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(TopSplitCells.Contains(splitCell)))
                                {
                                    TopSplitCells.Add(splitCell);
                                }
                            }
                        }
                        return true;
                    }
                    else //当前水平拆分条位于表格中间位置
                    {
                        if (cell.GetContentBounds().Bottom == currBarPos)
                        {
                            TopBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(TopSplitCells.Contains(splitCell)))
                                {
                                    TopSplitCells.Add(splitCell);
                                }
                            }
                        }

                        if (cell.GetContentBounds().Top == currBarPos)
                        {
                            BottomBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(BottomSplitCells.Contains(splitCell)))
                                {
                                    BottomSplitCells.Add(splitCell);
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 鼠标拖拽水平拆分条时，释放鼠标后的单元格自适应高度动态调整。
        /// </summary>
        private void AdjustCellHeightH(int y)
        {
            try
            {
                if (IsPrinting) return; //文档正在打印预览时，禁用鼠标拖拽表格内的单元格
                if (this.OwnerDocument.Info.DocumentModel != DocumentModel.Design
                    && this.OwnerDocument.Info.DocumentModel != DocumentModel.Edit) return;

                #region 计算高度变化量moveHeight，并进行越界检查以修正moveHeight
                int moveHeight = 0;
                if (TopBasicCells.Count == 0 && BottomBasicCells.Count > 0) //当前水平拆分条位于表格顶端边界
                {
                    #region 待编辑器坐标系修正后再处理
                    //YidanSoft.Library.EmrEditor.Src.Print.PrintPage currPage = myOwnerDocument.Pages[myOwnerDocument.PageIndex];
                    //if (y > currBarPos)
                    //{
                    //    y -= myOwnerDocument.Pages.TopMargin - myOwnerDocument.Pages.TopMargin - 40;
                    //}
                    //编辑器坐标系计算存在缺陷，暂时不作处理
                    //int pageTop = myOwnerDocument.Pages[myOwnerDocument.PageIndex].Top; //当前文档页面绝对顶端边界位置
                    //if (y < pageTop)
                    //{
                    //    y = pageTop;
                    //}
                    //moveHeight = y - dragCell.GetContentBounds().Top;
                    //this.OffsetY += moveHeight;
                    return;
                    //备注：此处还要考虑在表格上方腾出的空白处插入文本行或表格行
                    //绘制表格时有部分未绘制出来，点击鼠标时才重新绘制出来，待后续修正 
                    #endregion
                }
                else if (TopBasicCells.Count > 0 && BottomBasicCells.Count == 0) //当前水平拆分条位于表格底端边界
                {
                    moveHeight = y - dragCell.GetContentBounds().Bottom;

                    if (moveHeight < 0) //向上拖拽时检查TopBasicCells
                    {
                        if (TopBasicCells.Count == 0) return;

                        #region 检查是否越界，若越界则修正
                        int minHeight = GetMinCellHeight(TopBasicCells);

                        if (minHeight + moveHeight < 0) //已越界时处理
                        {
                            moveHeight = -GetMinSpaceHeight(TopBasicCells);
                        }
                        else //非越界时处理
                        {
                            int minSpaceHeight = GetMinSpaceHeight(TopBasicCells);

                            if (-moveHeight > minSpaceHeight) //先检查最小剩余空白高度
                            {
                                moveHeight = -minSpaceHeight;
                            }

                            if (minHeight + moveHeight < MinCellHeight) //再检查单元格默认最小高度
                            {
                                moveHeight = MinCellHeight - minHeight;
                            }
                        }
                        #endregion
                    }
                }
                else //当前水平拆分条位于表格中间区域
                {
                    moveHeight = y - dragCell.GetContentBounds().Top;

                    if (moveHeight > 0) //向下拖拽时检查BottomBasicCells
                    {
                        if (BottomBasicCells.Count == 0) return; //消除不进行拖拽时的鼠标释放事件报出异常问题

                        #region 计算当前水平拆分条的宽度
                        List<TPTextCell> allBasicCells = new List<TPTextCell>();
                        allBasicCells.AddRange(TopBasicCells.GetRange(0, TopBasicCells.Count));
                        allBasicCells.AddRange(BottomBasicCells.GetRange(0, BottomBasicCells.Count));
                        int hBarWidth = GetHSplitBarWidth(allBasicCells);
                        #endregion

                        //当水平拆分条宽度等于表格宽度时，水平拆分条下侧所有单元格高度不变，只更新其上侧所有单元格高度即可，跳过检查是否越界
                        if (hBarWidth == this.Width)
                        {
                            #region 水平拆分条与表格宽度相等时的特殊处理
                            foreach (TPTextCell cell in BottomBasicCells) //检查占位单元格，调整合并掉其的合并单元格高度
                            {
                                if (cell.ChildCount != 0) continue; //如果不是占位单元格，则直接跳出继续下一个循环
                                TPTextCell mergeCell = cell.OwnerMergeCell;
                                if (mergeCell != null) //必须检查是否为空引用
                                {
                                    if (mergeCell.ChildElements[0] is TPTextRow) //拆分单元格
                                    {
                                        if (TopSplitCells.Contains(mergeCell)) continue;
                                    }
                                    else
                                    {
                                        mergeCell.InnerUpdateHeight(mergeCell, moveHeight);  //必须递归处理
                                    }
                                }
                            }

                            BottomBasicCells.Clear();
                            BottomSplitCells.Clear();
                            #endregion
                        }
                        else //当水平拆分条宽度不等于表格宽度时，必须检查BottomBasicCells和清空TopSplitCells和BottomSplitCells
                        {
                            #region 检查是否越界，若越界则修正
                            int minHeight = GetMinCellHeight(BottomBasicCells);

                            if (minHeight - moveHeight < 0) //已越界时处理
                            {
                                moveHeight = GetMinSpaceHeight(BottomBasicCells);
                            }
                            else //非越界时处理
                            {
                                int minSpaceHeight = GetMinSpaceHeight(BottomBasicCells); //先检查最小剩余空白高度

                                if (moveHeight > minSpaceHeight)
                                {
                                    moveHeight = minSpaceHeight;
                                }

                                if (minHeight - moveHeight < MinCellHeight) //再检查单元格默认最小高度
                                {
                                    moveHeight = minHeight - MinCellHeight;
                                }
                            }

                            TopSplitCells.Clear();
                            BottomSplitCells.Clear();
                            #endregion
                        }
                    }
                    else //向上拖拽时检查TopBasicCells
                    {
                        if (TopBasicCells.Count == 0) return; //消除不进行拖拽时的鼠标释放事件报出异常问题

                        #region 检查是否越界，若越界则修正
                        int minHeight = GetMinCellHeight(TopBasicCells);

                        //向上拖拽时的最小剩余空白高度必须将BottomBasicCells中的占位单元格对应的合并单元格一同计算
                        List<TPTextCell> minSHBasicCells = new List<TPTextCell>();
                        minSHBasicCells.AddRange(TopBasicCells.GetRange(0, TopBasicCells.Count));
                        foreach (TPTextCell cell in BottomBasicCells)
                        {
                            if (cell.ChildCount == 0) //占位单元格
                            {
                                if (cell.OwnerMergeCell != null) //合并单元格
                                {
                                    minSHBasicCells.Add(cell.OwnerMergeCell);
                                }
                            }
                        }

                        if (minHeight + moveHeight < 0) //已越界时处理
                        {
                            moveHeight = -GetMinSpaceHeight(minSHBasicCells);
                        }
                        else //非越界时处理
                        {
                            int minSpaceHeight = GetMinSpaceHeight(minSHBasicCells);

                            if (-moveHeight > minSpaceHeight) //先检查最小剩余空白高度
                            {
                                moveHeight = -minSpaceHeight;
                            }

                            if (minHeight + moveHeight < MinCellHeight) //再检查单元格默认最小高度
                            {
                                moveHeight = MinCellHeight - minHeight;
                            }
                        }
                        #endregion

                        #region 计算当前水平拆分条的宽度
                        List<TPTextCell> allBasicCells = new List<TPTextCell>();
                        allBasicCells.AddRange(TopBasicCells.GetRange(0, TopBasicCells.Count));
                        allBasicCells.AddRange(BottomBasicCells.GetRange(0, BottomBasicCells.Count));
                        int hBarWidth = GetHSplitBarWidth(allBasicCells);
                        #endregion

                        //当水平拆分条宽度等于表格宽度时，水平拆分条下侧所有单元格高度不变，只更新其上侧所有单元格高度即可
                        if (hBarWidth == this.Width)
                        {
                            #region 水平拆分条与表格宽度相等时的特殊处理
                            foreach (TPTextCell cell in BottomBasicCells) //检查占位单元格，调整合并掉其的合并单元格高度
                            {
                                if (cell.ChildCount != 0) continue; //如果不是占位单元格，则直接跳出继续下一个循环
                                TPTextCell mergeCell = cell.OwnerMergeCell;
                                if (mergeCell != null) //必须检查是否为空引用
                                {
                                    if (mergeCell.ChildElements[0] is TPTextRow) //拆分单元格
                                    {
                                        if (TopSplitCells.Contains(mergeCell)) continue;
                                    }
                                    else
                                    {
                                        mergeCell.InnerUpdateHeight(mergeCell, moveHeight);  //必须递归处理
                                    }
                                }
                            }

                            BottomBasicCells.Clear();
                            BottomSplitCells.Clear();
                            #endregion
                        }
                        else //当水平拆分条宽度不等于表格宽度时，必须清空TopSplitCells和BottomSplitCells
                        {
                            TopSplitCells.Clear();
                            BottomSplitCells.Clear();
                        }
                    }
                }
                #endregion

                #region 水平拆分条两侧单元格调整高度
                //上侧
                foreach (TPTextCell cell in TopBasicCells)
                {
                    cell.Height += moveHeight;
                }
                foreach (TPTextCell cell in TopSplitCells)
                {
                    cell.Height += moveHeight;
                }

                //下侧
                foreach (TPTextCell cell in BottomBasicCells)
                {
                    cell.Height -= moveHeight;

                }
                foreach (TPTextCell cell in BottomSplitCells)
                {
                    cell.Height -= moveHeight;
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从某个单元格向孩子层次递归得到拖动水平拆分条时需要调整的单元格集合。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        /// <returns></returns>
        private bool InnerAdjustCellsHEx(TPTextCell cell)
        {
            try
            {
                //if (cell.ChildCount == 0) return true; //占位单元格不参与，交由其对应的合并单元格更新高度时处理
                //if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                if (cell.ChildCount > 0 && cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    foreach (TPTextRow innerRow in cell.ChildElements)
                    {
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            if (InnerAdjustCellsHEx(innerCell)) continue;
                        }
                    }
                    return true;
                }
                else //基本单元格或普通（非拆分的）合并单元格
                {
                    if (currBarPos == this.GetContentBounds().Top) //当前水平拆分条位于表格最顶端位置
                    {
                        #region 需修改代码
                        if (cell.GetContentBounds().Top == currBarPos)
                        {
                            BottomBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(BottomSplitCells.Contains(splitCell)))
                                {
                                    BottomSplitCells.Add(splitCell);
                                }
                            }
                        }
                        #endregion
                        return true;
                    }
                    else if (currBarPos == this.GetContentBounds().Bottom) //当前水平拆分条位于表格最底端位置
                    {
                        #region 需修改代码
                        if (cell.GetContentBounds().Bottom == currBarPos)
                        {
                            TopBasicCells.Add(cell);
                            if (cell.OwnerRow.Parent is TPTextCell)
                            {
                                TPTextCell splitCell = cell.OwnerRow.Parent as TPTextCell;
                                if (!(TopSplitCells.Contains(splitCell)))
                                {
                                    TopSplitCells.Add(splitCell);
                                }
                            }
                        }
                        #endregion
                        return true;
                    }
                    else //当前水平拆分条位于表格中间位置
                    {
                        if (cell.GetContentBounds().Top < currBarPos
                            && cell.GetContentBounds().Bottom >= currBarPos) //特殊之处
                        {
                            TopBasicCells.Add(cell);
                        }

                        if (cell.GetContentBounds().Top == currBarPos)
                        {
                            BottomBasicCells.Add(cell);
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 鼠标拖拽水平拆分条时，释放鼠标后的单元格自适应高度动态调整。
        /// </summary>
        private void AdjustCellHeightHEx(int y)
        {
            try
            {
                if (IsPrinting) return; //文档正在打印预览时，禁用鼠标拖拽表格内的单元格
                if (this.OwnerDocument.Info.DocumentModel != DocumentModel.Design
                    && this.OwnerDocument.Info.DocumentModel != DocumentModel.Edit) return;

                #region 计算高度变化量moveHeight，并进行越界检查以修正moveHeight
                int moveHeight = 0;
                if (TopBasicCells.Count == 0 && BottomBasicCells.Count > 0) //当前水平拆分条位于表格顶端边界
                {
                    return;
                }
                else if (TopBasicCells.Count > 0 && BottomBasicCells.Count == 0) //当前水平拆分条位于表格底端边界
                {
                    moveHeight = y - dragCell.GetContentBounds().Bottom;

                    if (moveHeight < 0) //向上拖拽时检查TopBasicCells
                    {
                        if (TopBasicCells.Count == 0) return;

                        #region 检查是否越界，若越界则修正
                        int minHeight = GetMinCellHeight(TopBasicCells);

                        if (minHeight + moveHeight < 0) //已越界时处理
                        {
                            moveHeight = -GetMinSpaceHeight(TopBasicCells);
                        }
                        else //非越界时处理
                        {
                            int minSpaceHeight = GetMinSpaceHeight(TopBasicCells);

                            if (-moveHeight > minSpaceHeight) //先检查最小剩余空白高度
                            {
                                moveHeight = -minSpaceHeight;
                            }

                            if (minHeight + moveHeight < MinCellHeight) //再检查单元格默认最小高度
                            {
                                moveHeight = MinCellHeight - minHeight;
                            }
                        }
                        #endregion
                    }
                }
                else //当前水平拆分条位于表格中间区域
                {
                    moveHeight = y - dragCell.GetContentBounds().Top;

                    if (moveHeight > 0) //向下拖拽时检查BottomBasicCells
                    {
                        if (BottomBasicCells.Count == 0) return; //消除不进行拖拽时的鼠标释放事件报出异常问题

                        int hBarWidth = GetHSplitBarWidth(BottomBasicCells); //当前水平拆分条的宽度

                        //当水平拆分条宽度等于表格宽度时，水平拆分条下侧所有单元格高度不变，只更新其上侧所有单元格高度即可，跳过检查是否越界
                        if (hBarWidth == this.Width)
                        {
                            BottomBasicCells.Clear();
                        }
                        else //当水平拆分条宽度不等于表格宽度时，必须检查BottomBasicCells，同时计算上侧单元格的最小剩余空白高度要移除其中的跨越水平拆分条的单元格
                        {
                            #region 检查是否越界，若越界则修正
                            int minHeight = GetMinCellHeight(BottomBasicCells);

                            if (minHeight - moveHeight < 0) //已越界时处理
                            {
                                moveHeight = GetMinSpaceHeight(BottomBasicCells);
                            }
                            else //非越界时处理
                            {
                                int minSpaceHeight = GetMinSpaceHeight(BottomBasicCells); //先检查最小剩余空白高度

                                if (moveHeight > minSpaceHeight)
                                {
                                    moveHeight = minSpaceHeight;
                                }

                                if (minHeight - moveHeight < MinCellHeight) //再检查单元格默认最小高度
                                {
                                    moveHeight = minHeight - MinCellHeight;
                                }
                            }

                            List<TPTextCell> delTopCells = new List<TPTextCell>();
                            foreach (TPTextCell cell in TopBasicCells)
                            {
                                if (cell.GetContentBounds().Bottom == currBarPos) continue;
                                delTopCells.Add(cell);
                            }
                            foreach (TPTextCell cell in delTopCells)
                            {
                                TopBasicCells.Remove(cell);
                            }
                            #endregion
                        }
                    }
                    else //向上拖拽时检查TopBasicCells
                    {
                        if (TopBasicCells.Count == 0) return; //消除不进行拖拽时的鼠标释放事件报出异常问题

                        #region 检查是否越界，若越界则修正
                        int hBarWidth = GetHSplitBarWidth(BottomBasicCells); //当前水平拆分条的宽度

                        if (hBarWidth != this.Width) //当前水平拆分条宽度不等于表格宽度时，计算上侧单元格的最小剩余空白高度要移除其中的跨越水平拆分条的单元格
                        {
                            List<TPTextCell> delTopCells = new List<TPTextCell>();
                            foreach (TPTextCell cell in TopBasicCells)
                            {
                                if (cell.GetContentBounds().Bottom == currBarPos) continue;
                                delTopCells.Add(cell);
                            }
                            foreach (TPTextCell cell in delTopCells)
                            {
                                TopBasicCells.Remove(cell);
                            }
                        }
                        else //当水平拆分条宽度等于表格宽度时，水平拆分条下侧所有单元格高度不变，只更新其上侧所有单元格高度即可
                        {
                            BottomBasicCells.Clear();
                        }

                        List<TPTextCell> NoFlagCells = new List<TPTextCell>(); //存储非占位单元格
                        List<TPTextCell> FlagCells = new List<TPTextCell>(); //存储占位单元格
                        foreach (TPTextCell cell in TopBasicCells)
                        {
                            if (cell.ChildCount == 0)
                            {
                                FlagCells.Add(cell);
                            }
                            else
                            {
                                NoFlagCells.Add(cell);
                            }
                        }

                        int minHeight = GetMinCellHeight(TopBasicCells);
                        //int minHeight = GetMinCellHeight(NoFlagCells);

                        if (minHeight + moveHeight < 0) //已越界时处理
                        {
                            moveHeight = -GetMinSpaceHeight(TopBasicCells);
                            //moveHeight = -GetMinSpaceHeight(NoFlagCells);
                            //if (FlagCells.Count > 0)
                            //{
                            //    int minHeightEx = GetMinCellHeight(FlagCells);
                            //    if (-moveHeight > minHeightEx - MinCellHeight)
                            //    {
                            //        moveHeight = MinCellHeight - minHeightEx;
                            //    }
                            //}
                        }
                        else //非越界时处理
                        {
                            int minSpaceHeight = GetMinSpaceHeight(TopBasicCells);
                            //int minSpaceHeight = GetMinSpaceHeight(NoFlagCells);

                            if (-moveHeight > minSpaceHeight) //先检查最小剩余空白高度
                            {
                                moveHeight = -minSpaceHeight;
                            }

                            if (minHeight + moveHeight < MinCellHeight) //再检查单元格默认最小高度
                            {
                                moveHeight = MinCellHeight - minHeight;
                            }

                            //if (FlagCells.Count > 0)
                            //{
                            //    int minHeightEx = GetMinCellHeight(FlagCells);
                            //    if (-moveHeight > minHeightEx - MinCellHeight)
                            //    {
                            //        moveHeight = MinCellHeight - minHeightEx;
                            //    }
                            //}
                        }
                        #endregion
                    }
                }
                #endregion

                #region 水平拆分条两侧单元格调整高度
                //上侧
                foreach (TPTextCell cell in TopBasicCells)
                {
                    //if (hBarWidth != this.Width)
                    //{
                    //    if (cell.GetContentBounds().Bottom == currBarPos)
                    //    {
                    //        cell.Height += moveHeight;
                    //    }
                    //}
                    //else
                    //{
                    //    cell.Height += moveHeight;
                    //}
                    cell.Height += moveHeight;
                }

                //下侧
                foreach (TPTextCell cell in BottomBasicCells)
                {
                    cell.Height -= moveHeight;
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region 鼠标事件（已修订完毕） add by myc 2014-05-12
        /// <summary>
        /// 光标闪烁时间。
        /// </summary>
        public static int CursorBlinkTime = 530;

        /// <summary>
        /// 上一次鼠标点击的位置。
        /// </summary>
        private Point LastMousePos = new Point(-1, -1);

        /// <summary>
        /// 鼠标在表格内首次点击时，鼠标所在处的单元格。
        /// </summary>
        private TPTextCell FirstClickCell = null;

        /// <summary>
        /// 鼠标按下事件，先重置所有单元格选中状态为非选中，再将鼠标点击处的单元格设置为选中状态；
        /// 若进行拖拽单元格操作，则构建下水平或垂直拆分条两侧的单元格集合。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Button"></param>
        /// <returns></returns>
        public override bool HandleMouseDown(int x, int y, MouseButtons Button)
        {
            try
            {
                if (Button == MouseButtons.Left)
                {
                    LastMousePos = new Point(x, y);

                    Rectangle rect = this.GetContentBounds();
                    if (myOwnerDocument.PageIndex == myOwnerDocument.Pages.Count - 1) //表格跨页时，表格的外切矩形要重新更正
                    {
                        rect = new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height + ZYTextDocument.PageBodyHeightIncrement);
                    }

                    //if (this.GetContentBounds().Contains(LastMousePos) && myOwnerDocument.OwnerControl.Cursor == Cursors.IBeam)
                    //if (rect.Contains(LastMousePos) && myOwnerDocument.OwnerControl.Cursor == Cursors.IBeam) //add by myc 2014-08-01 注释原因：这种判断方式将对表格右下边界点无效
                    if (myOwnerDocument.Contains(LastMousePos, rect) && myOwnerDocument.OwnerControl.Cursor == Cursors.IBeam) //add by myc 2014-08-01 修正表格底端边界判断
                    {
                        myOwnerDocument.SelectedCells.Clear();

                        for (int i = 0; i < this.AllRows.Count; i++)
                        {
                            for (int j = 0; j < this.AllRows[i].Cells.Count; j++)
                            {
                                TPTextCell cell = this.AllRows[i][j];
                                ClearSelectedCell(cell);
                                InitSelectedCell(cell, x, y);
                            }
                        }
                        myOwnerDocument.OwnerControl.UpdateInvalidateRect();
                        //return false; //改成true，就无法正确拖选单元格，反色处理单元格了，为什么呢？——>因为有人在ZYTextDocument的鼠标按下事件中乱加了一句代码myOwnerControl.CaptureMouse = false;
                        //return true;
                        return false;
                    }
                    //else if (this.GetContentBounds().Contains(LastMousePos) && OwnerDocument.OwnerControl.Cursor == Cursors.VSplit)
                    //else if (rect.Contains(LastMousePos) && OwnerDocument.OwnerControl.Cursor == Cursors.VSplit) //add by myc 2014-08-01 注释原因：这种判断方式将对表格右下边界点无效
                    else if (myOwnerDocument.Contains(LastMousePos, rect) && myOwnerDocument.OwnerControl.Cursor == Cursors.VSplit) //add by myc 2014-08-01 修正表格底端边界判断
                    {
                        LeftBasicCells.Clear();
                        RightBasicCells.Clear();
                        LeftSplitCells.Clear();
                        RightSplitCells.Clear();
                        foreach (TPTextRow row in this)
                        {
                            foreach (TPTextCell cell in row)
                            {
                                InnerAdjustCellsV(cell);
                            }
                        }
                        dragRect = Rectangle.Empty;
                    }
                    //else if (this.GetContentBounds().Contains(LastMousePos) && OwnerDocument.OwnerControl.Cursor == Cursors.HSplit)
                    //else if (rect.Contains(LastMousePos) && OwnerDocument.OwnerControl.Cursor == Cursors.HSplit) //add by myc 2014-08-01 注释原因：这种判断方式将对表格右下边界点无效
                    else if (myOwnerDocument.Contains(LastMousePos, rect) && myOwnerDocument.OwnerControl.Cursor == Cursors.HSplit) //add by myc 2014-08-01 修正表格底端边界判断
                    {
                        TopBasicCells.Clear();
                        BottomBasicCells.Clear();
                        TopSplitCells.Clear();
                        BottomSplitCells.Clear();
                        foreach (TPTextRow row in this)
                        {
                            foreach (TPTextCell cell in row)
                            {
                                //InnerAdjustCellsH(cell);
                                InnerAdjustCellsHEx(cell);
                            }
                        }
                    }
                    else //鼠标在表格外点击时
                    {
                        //if (myOwnerDocument.SelectedCells.Count > 1)
                        {

                            for (int i = 0; i < this.AllRows.Count; i++)
                            {
                                for (int j = 0; j < this.AllRows[i].Cells.Count; j++)
                                {
                                    TPTextCell cell = this.AllRows[i][j];
                                    ClearSelectedCell(cell);
                                }
                            }

                            myOwnerDocument.SelectedCells.Clear(); //add by myc 2014-08-04 这个非常关键，必须清除SelectedCells以通知文档绘制例程调用单元格内反色绘制判定

                            FirstClickCell = null;
                            myOwnerDocument.OwnerControl.UpdateInvalidateRect();
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 鼠标移动事件，判断是否显示水平或垂直拆分条并绘制相应拖拽直线，或构建需要进行合并操作的单元格集合。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Button"></param>
        /// <returns></returns>
        public override bool HandleMouseMove(int x, int y, MouseButtons Button)
        {
            try
            {
                #region 核心代码
                //鼠标移动时的坐标位置，随着鼠标的移动不断的变化
                Point p = new Point(x, y);

                Rectangle rect = this.GetContentBounds();
                if (myOwnerDocument.PageIndex == myOwnerDocument.Pages.Count - 1) //表格跨页时，表格的外切矩形要重新更正
                {
                    rect = new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height + ZYTextDocument.PageBodyHeightIncrement);
                }

                //如果鼠标还在表格中
                //if (this.GetContentBounds().Contains(p))
                //if (rect.Contains(p)) //add by myc 2014-07-30 注释原因：注意矩形的Contains方法判断点时不包含其边界上的点
                if (rect.Left <= x && rect.Right >= x
                    && rect.Top <= y && rect.Bottom >= y)
                {
                    //如果是划选
                    if (myOwnerDocument.OwnerControl.CaptureMouse && FirstClickCell != null)
                    {
                        #region 同一个表格内的鼠标拖选单元格处理核心代码
                        //获取当前鼠标点击处单元格的位置和大小
                        Rectangle currentRect = FirstClickCell.GetContentBounds();

                        //获得一个选择的橡皮筋矩形区域 SelectRect
                        Rectangle SelectRect = Rectangle.Empty;
                        if (p.X > LastMousePos.X)
                        {
                            SelectRect.X = LastMousePos.X;
                            SelectRect.Width = p.X - LastMousePos.X;
                        }
                        else
                        {
                            SelectRect.X = p.X;
                            SelectRect.Width = LastMousePos.X - p.X;
                        }
                        if (p.Y > LastMousePos.Y)
                        {
                            SelectRect.Y = LastMousePos.Y;
                            SelectRect.Height = p.Y - LastMousePos.Y;
                        }
                        else
                        {
                            SelectRect.Y = p.Y;
                            SelectRect.Height = LastMousePos.Y - p.Y;
                        }

                        if (currentRect.Contains(p))
                        //if(currentRect.Left <= p.X && currentRect.Right > p.X 
                        //    && currentRect.Top <= p.Y && currentRect.Bottom > p.Y)
                        {
                            #region 鼠标拖选单元格内部文本必须确保光标在单元格中
                            //myOwnerDocument.Content.AutoClearSelection = false;
                            //myOwnerDocument.Content.MoveTo(x, y);
                            //ZYTextElement myElement = myOwnerDocument.Content.CurrentElement;
                            //myOwnerDocument.OwnerControl.MoveCaretWithScroll = false;
                            //myOwnerDocument.OwnerControl.UpdateTextCaret();
                            //myOwnerDocument.OwnerControl.HideOwnerCaret();
                            //myOwnerDocument.OwnerControl.MoveCaretWithScroll = true;
                            #endregion

                            myOwnerDocument.SelectedCells.Clear(); //2014-08-06 注释原因：对交叉拖选单元格的反色绘制会产生干扰，记住SelectedCells只用来针对表格内的拖选单元格实现合并单元格操作处理用的
                            for (int i = 0; i < this.allRows.Count; i++)
                            {
                                for (int j = 0; j < this.AllRows[i].Cells.Count; j++)
                                {
                                    TPTextCell cell = this.AllRows[i][j];
                                    ClearSelectedCell(cell);
                                }
                            }

                            //return true;
                            return false;
                        }
                        else
                        {
                            #region 鼠标拖选单元格内部文本必须确保光标在单元格中
                            //myOwnerDocument.Content.AutoClearSelection = false;
                            //myOwnerDocument.Content.MoveTo(x, y);
                            //ZYTextElement myElement = myOwnerDocument.Content.CurrentElement;
                            //myOwnerDocument.OwnerControl.MoveCaretWithScroll = false;
                            //myOwnerDocument.OwnerControl.UpdateTextCaret();
                            //myOwnerDocument.OwnerControl.HideOwnerCaret();
                            //myOwnerDocument.OwnerControl.MoveCaretWithScroll = true;
                            #endregion

                            myOwnerDocument.SelectedCells.Clear();
                            this.SelectedMergeCells.Clear();
                            this.SelectedSplitCells.Clear();
                            this.RecusiveTraversalLevel = 1; //复位遍历递归层次

                            for (int i = 0; i < this.allRows.Count; i++)
                            {
                                for (int j = 0; j < this.AllRows[i].Cells.Count; j++)
                                {
                                    TPTextCell cell = this.AllRows[i][j];
                                    int level = 1;
                                    SetSelectedCell(cell, SelectRect, level);
                                }
                            }

                            //return true;
                            return false;
                        }
                        #endregion
                    }
                    else if (myOwnerDocument.OwnerControl.CaptureMouse && FirstClickCell == null
                        && (myOwnerDocument.OwnerControl.Cursor == Cursors.VSplit || myOwnerDocument.OwnerControl.Cursor == Cursors.HSplit))
                    {
                        SetCaretBlinkTime(-1);

                        //此时是调整表格列宽的时候，应该让纵穿整个页面的虚线随着鼠标移动
                        DrawDragDottedLine();
                        return true;
                    }
                    else if (myOwnerDocument.OwnerControl.CaptureMouse == false)
                    {
                        for (int i = 0; i < this.AllRows.Count; i++)
                        {
                            for (int j = 0; j < this.AllRows[i].Cells.Count; j++)
                            {
                                TPTextCell cell = this.allRows[i].Cells[j];
                                InnerShowSplitBar(cell, new Point(x, y));
                            }
                        }
                    }
                    else if (myOwnerDocument.OwnerControl.CaptureMouse && FirstClickCell == null) //add by myc 2014-07-30 添加原因：鼠标拖选文档元素（交叉表格）——>这个非常关键
                    {
                        for (int i = 0; i < this.AllRows.Count; i++) //add by myc 2014-07-30 添加原因：鼠标拖选文档元素（交叉表格）时的移出表格时需重置表格内的所有单元格为非选中状态——>取消反色高亮绘制
                        {
                            for (int j = 0; j < this.AllRows[i].Cells.Count; j++)
                            {
                                TPTextCell cell = this.AllRows[i][j];
                                ClearSelectedCell(cell);
                            }
                        }

                    }
                }
                else //附加超出边界时的拖拽虚线绘制
                {
                    //if (FirstClickCell == null && !myOwnerDocument.Content.CheckSelectingAreaInOneTable()) //add by myc 2014-07-30 添加原因：这个判断非常关键——>同一个表格内的拖选单元格释放鼠标之后，移出表格时不能丢失原先选定的单元格（合并单元格操作的基础前提）

                    if (myOwnerDocument.OwnerControl.CaptureMouse && FirstClickCell == null && !myOwnerDocument.Content.SelectingAreaInOneTable) //add by myc 2014-07-30 添加原因：这个判断非常关键——>同一个表格内的拖选单元格释放鼠标之后，移出表格时不能丢失原先选定的单元格（合并单元格操作的基础前提）
                    {
                        for (int i = 0; i < this.AllRows.Count; i++) //add by myc 2014-07-30 添加原因：鼠标拖选文档元素（交叉表格）时的移出表格时需重置表格内的所有单元格为非选中状态——>取消反色高亮绘制
                        {
                            for (int j = 0; j < this.AllRows[i].Cells.Count; j++)
                            {
                                TPTextCell cell = this.AllRows[i][j];
                                ClearSelectedCell(cell);
                            }
                        }
                        //myOwnerDocument.OwnerControl.UpdateInvalidateRect();
                        //myOwnerDocument.SelectedCells.Clear(); //add by myc 2014-08-04 这个非常关键，必须清除SelectedCells以通知文档绘制例程调用单元格内反色绘制判定
                    } //——>2014-08-01 不能这样清除单元格的选中状态——>鼠标滚轮重绘反色高亮丢失部分,必须加上myOwnerDocument.OwnerControl.CaptureMouse条件


                    //FirstClickCell = null; //2014-08-01 注释原因：这里不能这样设置它为null，影响交叉选定文档元素的准确反色绘制（交叉选定文档元素起始点在表格内）
                    myOwnerDocument.OwnerControl.UpdateInvalidateRect();

                    if (myOwnerDocument.OwnerControl.CaptureMouse && FirstClickCell == null
                        && (myOwnerDocument.OwnerControl.Cursor == Cursors.VSplit || myOwnerDocument.OwnerControl.Cursor == Cursors.HSplit))
                    {
                        //此时是调整表格列宽的时候，应该让纵穿整个页面的虚线随着鼠标移动
                        DrawDragDottedLine();
                        return true;
                    }
                }
                #endregion
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 鼠标释放事件，若进行拖拽单元格操作，则计算水平或垂直拆分条两侧的单元格在拖拽之后的新宽度或新高度。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Button"></param>
        /// <returns></returns>
        public override bool HandleMouseUp(int x, int y, MouseButtons Button)
        {
            bool isDragDone = false;//表示是否处理过拖拽操作 是：返回true 否：返回false
            if (OwnerDocument.OwnerControl.Cursor == Cursors.VSplit)
            {
                if (dragCell != null)
                {
                    isDragDone = true;
                    AdjustCellWidthV(x);

                    myOwnerDocument.ContentChanged();
                    myOwnerDocument.Refresh();

                    LeftBasicCells.Clear();
                    RightBasicCells.Clear();
                    LeftSplitCells.Clear();
                    RightSplitCells.Clear();
                    dragRect = Rectangle.Empty;
                    dragCell = null;
                }
            }
            else if (OwnerDocument.OwnerControl.Cursor == Cursors.HSplit)
            {
                if (dragCell != null)
                {
                    isDragDone = true;
                    //AdjustCellHeightH(y);
                    AdjustCellHeightHEx(y);

                    myOwnerDocument.ContentChanged();
                    myOwnerDocument.Refresh();

                    TopBasicCells.Clear();
                    BottomBasicCells.Clear();
                    TopSplitCells.Clear();
                    BottomSplitCells.Clear();
                    dragRect = Rectangle.Empty;
                    dragCell = null;
                }
            }
            //2020.06.06-hdf:表格中选择图片，会导致SelectedCells里包含图片所在的单元格，然后导致删除逻辑会删除该单元格所有元素
            if (OwnerDocument.Content.SelectLength == 1 && OwnerDocument.Content.CurrentSelectElement is ZYTextElement)
            {
                OwnerDocument.SelectedCells.Clear();
            }

            LastMousePos = new Point(-1, -1);
            FirstClickCell = null;
            dragCell = null;
            SetCaretBlinkTime(CursorBlinkTime);
            return isDragDone;
        }

        /// <summary>
        /// （鼠标按下事件）从某个单元格向孩子层次递归清除内部嵌套单元格的选中状态。
        /// </summary>
        /// <param name="cell">待处理的某个单元格。</param>
        public bool ClearSelectedCell(TPTextCell cell)
        {
            try
            {
                if (cell.ChildCount == 0) return true; //占位单元格
                if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    foreach (TPTextRow innerRow in cell.ChildElements)
                    {
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            if (ClearSelectedCell(innerCell)) continue;
                        }
                    }
                    return true;
                }
                else //非拆分单元格
                {
                    //将已经选中的cell添加到无效区域内
                    if (cell.CanAccess == true || cell.Selected == true)
                    {
                        myOwnerDocument.OwnerControl.AddInvalidateRect(cell.GetContentBounds());
                        cell.CanAccess = false; //2014-08-08 添加原因：ZYContent类的HighlightSelectingArea完成单个单元格内部的选定文本反色绘制需要——>有缺陷，已在反色绘制方法中改用新方式判定
                        cell.Selected = false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// （鼠标按下事件）从某个单元格向孩子层次递归初始化内部嵌套单元格的选中状态。
        /// </summary>
        /// <param name="cell">待处理的某个单元格。</param>
        private bool InitSelectedCell(TPTextCell cell, int x, int y)
        {
            try
            {
                if (cell.ChildElements.Count == 0) return true; //占位单元格
                if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    cell.CanAccess = false;
                    cell.Selected = false;
                    foreach (TPTextRow innerRow in cell.ChildElements)
                    {
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            if (InitSelectedCell(innerCell, x, y)) continue;
                        }
                    }
                    return true;
                }
                else //非拆分单元格
                {
                    if (cell.IsContain(x, y))
                    {
                        FirstClickCell = cell;
                        FirstClickCell.CanAccess = true;
                        myOwnerDocument.SelectedCells.Add(cell);
                        //if (cell.ChildElements[0] is ZYTextParagraph)
                        //{
                        //    myOwnerDocument.Content.AutoClearSelection = false;
                        //    myOwnerDocument.Content.MoveTo(x, y);
                        //    ZYTextElement myElement = myOwnerDocument.Content.CurrentElement;
                        //    myOwnerDocument.OwnerControl.MoveCaretWithScroll = false;
                        //    myOwnerDocument.OwnerControl.UpdateTextCaret();
                        //    myOwnerDocument.OwnerControl.MoveCaretWithScroll = true;
                        //}
                    }
                    else
                    {
                        cell.CanAccess = false;
                        cell.Selected = false;
                        //将此单元格添加到无效区域
                        myOwnerDocument.OwnerControl.AddInvalidateRect(cell.GetContentBounds());
                        //马上更新无效区域
                        myOwnerDocument.OwnerControl.UpdateInvalidateRect();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// （鼠标移动事件）从某个单元格向孩子层次递归设置内部嵌套单元格的选中状态。
        /// </summary>
        /// <param name="cell">待处理的某个单元格。</param>
        private bool SetSelectedCell(TPTextCell cell, Rectangle selectRect, int level)
        {
            try
            {
                if (cell.ChildCount == 0) //占位单元格
                {
                    cell.Level = level;
                    if (SelectedMergeCells.Contains(cell.OwnerMergeCell))
                    {
                        myOwnerDocument.SelectedCells.Add(cell);
                    }
                    return true;
                }
                else if (cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    cell.Selected = false;
                    level++; //递归层次+1
                    foreach (TPTextRow innerRow in cell.ChildElements)
                    {
                        foreach (TPTextCell innerCell in innerRow)
                        {
                            if (SetSelectedCell(innerCell, selectRect, level)) continue;
                        }
                    }

                    return true;
                }
                else //基本单元格和普通（非拆分的）合并单元格
                {
                    //取得鼠标拖选选择的区域和单元格的交集，用来确定那些单元格被选中了
                    bool flag = selectRect.IntersectsWith(cell.GetContentBounds());

                    if (flag) //如果被选中
                    {
                        cell.Level = level;
                        myOwnerDocument.SelectedCells.Add(cell);
                        if (level > RecusiveTraversalLevel)
                        {
                            RecusiveTraversalLevel = level;
                        }

                        if (cell.Height > cell.OwnerRow.Height) //合并单元格
                        {
                            SelectedMergeCells.Add(cell);
                        }

                        TPTextCell outerCell = cell.Parent.Parent as TPTextCell;
                        if (outerCell != null) //当前单元格cell位于父级拆分单元格的内部
                        {
                            outerCell.Level = level - 1;
                            if (!SelectedSplitCells.Contains(outerCell))
                            {
                                SelectedSplitCells.Add(outerCell);
                            }
                        }
                    }

                    if (cell.Selected != flag)
                    {
                        cell.Selected = flag;
                        cell.CanAccess = flag;

                        //鼠标划选单元格过程中应该设置内容对象的选择区域长度属性为0，
                        //让单元格拖选时只对选中的单元格进行反色背景处理，而不对内部的选中元素进行反色背景处理，避免反色干扰。
                        //myOwnerDocument.Content.SelectLength = 0;
                        //将此单元格添加到无效区域
                        myOwnerDocument.OwnerControl.AddInvalidateRect(cell.GetContentBounds());
                        //马上更新无效区域
                        myOwnerDocument.OwnerControl.UpdateInvalidateRect();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 拖拽单元格时的静止光标 add by myc 2014-05-27
        [DllImport("user32", EntryPoint = "SetCaretBlinkTime")]
        public extern static int SetCaretBlinkTime(int uMSeconds);

        [DllImport("user32", EntryPoint = "GetCaretBlinkTime")]
        public extern static int GetCaretBlinkTime();
        #endregion

        public bool FinishPaging = false;
        #endregion



        #region 重构表格本身鼠标事件处理例程 add by myc 2014-07-30

        #endregion
    }
}
