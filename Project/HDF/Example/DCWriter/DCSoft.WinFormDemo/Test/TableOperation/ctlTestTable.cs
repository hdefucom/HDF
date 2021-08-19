using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data ;
using DCSoft.Writer.Commands;

namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestTable : UserControl
    {
        public ctlTestTable()
        {
            InitializeComponent();
        }

        private void ctlQueryKBEntries_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        /// <summary>
        /// 根据一个DataTable创建表格元素对象
        /// </summary>
        /// <param name="document">文档对象</param>
        /// <param name="dt">数据表对象</param>
        /// <param name="columnWidths">指定的各个表格列宽度</param>
        /// <param name="headerCellStyle">标题行单元格样式</param>
        /// <param name="dataCellStyle">数据行单元格格式</param>
        /// <returns>创建的表格文档元素对象</returns>
        private XTextTableElement CreateTableElement(
            XTextDocument document,
            DataTable dt, 
            float[] columnWidths, 
            DocumentContentStyle headerCellStyle, 
            DocumentContentStyle dataCellStyle)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }
            if (dt == null)
            {
                throw new ArgumentNullException("dt");
            }
            if (columnWidths == null)
            {
                throw new ArgumentNullException("columnWidths");
            }
            float specifyWidth = -1;
            if (columnWidths.Length == 1)
            {
                // 若宽度数组只有一个元素，则认为是指定了所有表格列的宽度
                specifyWidth = columnWidths[0];
            }
            else
            {
                if (dt.Columns.Count != columnWidths.Length)
                {
                    throw new ArgumentException("宽度个数不对");
                }
            }
            XTextTableElement table = new XTextTableElement();
            table.OwnerDocument = document;
            // 创建表格列
            for (int iCount = 0; iCount < dt.Columns.Count; iCount++)
            {
                XTextTableColumnElement col = table.CreateColumnInstance();
                if (specifyWidth > 0)
                {
                    col.Width = specifyWidth;
                }
                else
                {
                    col.Width = columnWidths[iCount];
                }
                table.Columns.Add(col);
            }
            // 创建标题行
            XTextTableRowElement headerRow = table.CreateRowInstance();
            table.AppendChildElement(headerRow);
            for (int iCount = 0; iCount < dt.Columns.Count; iCount++)
            {
                DataColumn col = dt.Columns[iCount];
                XTextTableCellElement cell = table.CreateCellInstance();
                headerRow.AppendChildElement(cell);
                cell.ContentBuilder.AppendText(col.ColumnName);
                if (headerCellStyle != null)
                {
                    cell.StyleIndex = document.ContentStyles.GetStyleIndex(headerCellStyle);
                }
            }
            // 创建数据行
            foreach (DataRow row in dt.Rows)
            {
                XTextTableRowElement dRow = table.CreateRowInstance();
                table.AppendChildElement(dRow);
                for (int iCount = 0; iCount < dt.Columns.Count; iCount++)
                {
                    // 获得原始数据
                    object v = row[iCount];
                    string cellText = "";
                    if (v == null || DBNull.Value.Equals(v))
                    {
                        cellText = "";
                    }
                    else
                    {
                        cellText = Convert.ToString(v);
                    }
                    // 创建单元格对象
                    XTextTableCellElement cell = table.CreateCellInstance();
                    dRow.AppendChildElement(cell);
                    if (dataCellStyle != null)
                    {
                        cell.StyleIndex = document.ContentStyles.GetStyleIndex(dataCellStyle);
                    }
                    cell.ContentBuilder.AppendText(cellText);
                }//for
            }//foreach

            return table;
        }
         
        private void btnInsertDataTable_Click(object sender, EventArgs e)
        {
            // 判断当前能否插入表格
            if (myWriterControl.IsCommandEnabled("Table_InsertTable"))
            {
                // 显示数据表对话框
                using (dlgBrowseDOCEXTable dlg = new dlgBrowseDOCEXTable())
                {
                    if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        DataTable table = dlg.SelectedDataTable;
                        if (table != null)
                        {
                            // 根据选择的数据表创建表格文档元素
                            float[] colWidths = new float[table.Columns.Count];
                            for (int iCount = 0; iCount < table.Columns.Count; iCount++)
                            {
                                colWidths[ iCount ] = this.myWriterControl.Document.Body.ClientWidth / table.Columns.Count;
                            }
                            // 设置标题行单元格样式
                            DocumentContentStyle headerCellStyle = new DocumentContentStyle();
                            headerCellStyle.BackgroundColor = Color.LightBlue;
                            headerCellStyle.BorderLeft = true;
                            headerCellStyle.BorderTop = true;
                            headerCellStyle.BorderRight = true;
                            headerCellStyle.BorderBottom = true;
                            headerCellStyle.BorderWidth = 1;
                            headerCellStyle.BorderColor = Color.Black;
                            headerCellStyle.PaddingTop = 10;
                            headerCellStyle.PaddingBottom = 10;
                            // 设置数据单元格样式
                            DocumentContentStyle dataCellStyle = new DocumentContentStyle();
                            dataCellStyle.BorderLeft = true;
                            dataCellStyle.BorderTop = true;
                            dataCellStyle.BorderRight = true;
                            dataCellStyle.BorderBottom = true;
                            dataCellStyle.BorderWidth = 1;
                            dataCellStyle.BorderColor = Color.Black;
                            dataCellStyle.PaddingTop = 10;
                            dataCellStyle.PaddingBottom = 10;
                            // 调用CreateTableElement创建表格对象
                            XTextTableElement tableElement = CreateTableElement(
                                this.myWriterControl.Document, 
                                table,
                                colWidths,
                                headerCellStyle, 
                                dataCellStyle);
                            if (tableElement != null)
                            {
                                tableElement.ID = "myTable";
                            }
                            // 调用命令将表格文档元素插入到文档中
                            myWriterControl.ExecuteCommand(
                                "Table_InsertTable",
                                false,
                                tableElement);
                        }
                    }
                }
            }
        }

        private void btnDeleteSpecifyRow_Click(object sender, EventArgs e)
        {
            TableCommandArgs args = new TableCommandArgs();
            args.TableID = "myTable";
            args.RowIndex = 3;
            args.RowsCount = 2;
            myWriterControl.ExecuteCommand(
                "Table_DeleteRow",
                false,
                args);

        }

        private void btnSpecifyNewRow_Click(object sender, EventArgs e)
        {
            XTextElementList list = myWriterControl.Document.GetElementsByType(
                typeof(XTextTableElement));
            if (list != null && list.Count > 0)
            {
                XTextTableElement table = (XTextTableElement)list[0];
                DCSoft.Writer.Commands.TableCommandArgs args
                    = new DCSoft.Writer.Commands.TableCommandArgs();
                args.TableElement = table;
                XTextTableRowElement oldLast = (XTextTableRowElement)table.Rows.LastElement;
                if (oldLast.OwnerPageIndex < 0)
                {
                    MessageBox.Show("bbb");
                }
                args.RowIndex = table.Rows.Count - 1;
                args.RowsCount = 10;
                myWriterControl.ExecuteCommand(
                    "Table_InsertRowDown",
                    false,
                    args);
                XTextTableRowElement lastRow = (XTextTableRowElement)table.Rows.LastElement;
                if (lastRow.OwnerPageIndex < 0)
                {
                    MessageBox.Show("aaa");
                }
            }
        }

        private void btnCloneRow_Click(object sender, EventArgs e)
        {
            XTextTableElement table = (XTextTableElement)myWriterControl.Document.GetCurrentElement(typeof(XTextTableElement));
            if (table != null)
            {
                if (table.Rows.Count > 4)
                {
                    // 复制指定表格的指定的表格行
                    DCSoft.Writer.Commands.TableCommandArgs args
                        = new DCSoft.Writer.Commands.TableCommandArgs();
                    args.TableElement = table;// 设置要操作的表格对象
                    args.RowIndex = 2;// 设置要操作的表格行号，从0开始计算
                    args.RowsCount = 3;
                    // 执行在下面插入表格行命令
                    myWriterControl.ExecuteCommand("Table_InsertRowDown", false, args);
                }
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            //myWriterControl.ExecuteCommand("FormViewMode", false, false);

            myWriterControl.ExecuteCommand(
               "Table_DeleteRow",
               false,
               "null");

            //myWriterControl.ExecuteCommand("FormViewMode", true, "Strict");
        }

        private void btnCellGridLine_Click(object sender, EventArgs e)
        {
            XTextTableCellElement cell = (XTextTableCellElement)myWriterControl.GetCurrentElementByTypeName(
                "XTextTableCellElement");
            if (cell != null)
            {
                cell.Style.GridLineType = ContentGridLineType.ExtentToBottom;
                cell.InvalidateView();
            }
        }

        private void btnSplitSpecifyCell_Click(object sender, EventArgs e)
        {
            XTextTableCellElement cell = (XTextTableCellElement)myWriterControl.GetCurrentElement(typeof(XTextTableCellElement));
            if (cell != null)
            {
                cell = cell.LeftVisibleCell;
                if (cell != null)
                {
                    SplitCellExtCommandParameter parameter = new SplitCellExtCommandParameter();
                    // 指定要拆分的单元格对象
                    parameter.CellElement = cell;
                    // 指定要拆分成2行
                    parameter.NewRowSpan = 2;
                    // 指定要拆分成3列
                    parameter.NewColSpan = 3;
                    // 执行拆分单元格命令
                    myWriterControl.ExecuteCommand("Table_SplitCellExt", false, parameter);
                }
            }
        }

        private void btnSplitCurrentCell_Click(object sender, EventArgs e)
        {
            // 将当前单元格拆分成2行3列
            // 当用户参数为字符串时，采用“新行数,新列数”的格式，中间为英文逗号。
            myWriterControl.ExecuteCommand("Table_SplitCellExt", false, "2,3");
        }

        private void btnSetCenter_Click(object sender, EventArgs e)
        {
            XTextTableCellElement cell = (XTextTableCellElement)myWriterControl.GetCurrentElement(
                typeof(XTextTableCellElement));
            if (cell != null)
            {
                XTextTableRowElement row = cell.OwnerRow;
                row.Style.BackgroundColor = Color.Yellow;
                cell.FixElements();
                foreach (XTextElement element in cell.Elements)
                {
                    if (element is XTextParagraphFlagElement)
                    {
                        XTextParagraphFlagElement p = (XTextParagraphFlagElement)element;
                        p.Style.Align = Drawing.DocumentContentAlignment.Center;
                    }
                }
                myWriterControl.RefreshDocument();
            }
        }

        private void btnMegeCell2_Click(object sender, EventArgs e)
        {
            // 创建参数对象
            MegeCellCommandParameter cp = new MegeCellCommandParameter();
            // 设置要合并的单元格对象
            cp.Cell = (XTextTableCellElement)myWriterControl.GetCurrentElement(typeof(XTextTableCellElement));
            if (cp.Cell != null)
            {
                // 设置新的跨行数
                cp.NewRowSpan = 3;
                // 设置新的跨列数
                cp.NewColSpan = 2;
                // 执行合并单元格命令
                myWriterControl.ExecuteCommand("Table_MergeCell", false, cp);
            }
        }

        private void btnSetCellTextColor_Click(object sender, EventArgs e)
        {
            XTextTableCellElement cell = (XTextTableCellElement)myWriterControl.GetCurrentElement(typeof(XTextTableCellElement));
            if (cell != null)
            {
                cell.Select();
                myWriterControl.ExecuteCommand("Color", false, "red");
            }
        }

        private void btnTestTable2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //文件位置在上层目录，调整NameSpace
            string fileName = string.Empty;
            string nameSpace = this.GetType().Namespace;
            string[] spaceList = nameSpace.Split('.');
            for (int i = 0; i < spaceList.Length - 1; i++)
            {
                fileName = fileName + spaceList[i]+".";
            }

            System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream(fileName + "datatable2.xml");
            ds.ReadXml( stream );
            DataTable dt = ds.Tables[0];
            XTextTableElement table = CreateTableElement(dt, myWriterControl.Document);
            if (table != null)
            {
                table.EditorRefreshView();
                //myWriterControl.RefreshDocument();
            }
        }
        /// <summary>
        /// 插入表格
        /// </summary>
        private void InsertTable(DataTable dtReport)
        {
            if (dtReport != null)
            {
                //根据选择的数据表创建表格文档元素
                XTextTableElement tableElement = CreateTableElement(dtReport, this.myWriterControl.Document);
                if (tableElement != null)
                {
                    tableElement.EditorRefreshView();
                }
            }
        }

        /// <summary>
        /// 根据一个数据表创建一个表格文档元素对象
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <param name="document">文档对象</param>
        /// <returns>创建的文档元素对象</returns>
        private XTextTableElement CreateTableElement(DataTable dt, XTextDocument document)
        {
            XTextTableElement tableElement = myWriterControl.GetElementById("Table") as XTextTableElement;
            if (tableElement == null)
            {
                return null ;
            }
            tableElement.OwnerDocument = document;

            // 数据行单元格样式
            DocumentContentStyle dataCellStyle = new DocumentContentStyle();
            dataCellStyle.BorderLeft = true;
            dataCellStyle.BorderTop = true;
            dataCellStyle.BorderRight = true;
            dataCellStyle.BorderBottom = true;
            dataCellStyle.BorderWidth = 1;
            dataCellStyle.BorderColor = Color.Black;
            dataCellStyle.PaddingTop = 10;
            dataCellStyle.PaddingBottom = 10;
            dataCellStyle.PaddingLeft = 20;
            dataCellStyle.FontSize = 5;
            dataCellStyle.GridLineType = ContentGridLineType.ExtentToBottom;
            dataCellStyle.GridLineColor = System.Drawing.Color.Black;
            // 遍历所有的数据行，添加表格行
            foreach (DataRow row in dt.Rows)
            {
                // 添加数据行
                XTextTableRowElement rowElement = new XTextTableRowElement();
                tableElement.Rows.Add(rowElement);
                int count = 0;
                foreach (DataColumn col in dt.Columns)
                {
                    count++;
                    if (count > 31) continue;
                    // 添加单元格
                    string text = Convert.ToString(row[col]);
                    XTextTableCellElement cell = new XTextTableCellElement();
                    // 向数据行添加单元格
                    rowElement.Cells.Add(cell);
                    // 设置单元格文本
                    cell.Elements.AddRange(
                    document.CreateTextElements(text, null, null));
                    // 设置单元格样式
                    //cell.Style = dataCellStyle;

                    if (dataCellStyle != null)
                    {
                        cell.StyleIndex = document.ContentStyles.GetStyleIndex(dataCellStyle);
                    }
                    cell.SpecifyFixedLineHeight = 67.125f;
                }
            }
            return tableElement;
        }

        private void btnSetColor2_Click(object sender, EventArgs e)
        {
            XTextTableElement table = ( XTextTableElement ) this.myWriterControl.GetCurrentElement(typeof(XTextTableElement));
            if (table != null)
            {
                int iCount = 0;
                foreach (XTextTableCellElement cell in table.VisibleCells )
                {
                    if( (( iCount ++ ) % 3  == 0 ))
                    {
                        DocumentContentStyle style = new DocumentContentStyle();
                        style.Color = Color.Red ;
                        style.Bold = true ;
                        style.BackgroundColor = Color.Blue;
                        cell.EditorSetContentStyleFast(style);
                    }
                }
                this.myWriterControl.RefreshDocument();
            }
        }


        private void btnCopyRows2_Click(object sender, EventArgs e)
        {
            bool result = CopyMultiRows(" ", "A1", 2, "A3");
            MessageBox.Show(result.ToString());
        }

        public virtual bool CopyMultiRows(string tableN, string cellCopyStartN, int count, string cellPasteStartN)
        {
            if (string.IsNullOrEmpty(tableN))
            {
                return false;
            }
            XTextTableElement table = this.myWriterControl.GetElementById(tableN) as XTextTableElement;
            table = (XTextTableElement)this.myWriterControl.GetCurrentElement(typeof(XTextTableElement));
            if (table == null)
            {
                // 没找到表格
                return false;
            }

            if (string.IsNullOrEmpty(cellCopyStartN)
                || cellCopyStartN.StartsWith("A") == false)
            {
                return false;
            }
            int copyStartRowIndex = Convert.ToInt32(cellCopyStartN.Substring(1))-1;
            if (count <= 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(cellPasteStartN)
                || cellPasteStartN.StartsWith("A") == false )
            {
                return false;
            }
            int pasteStartIndex = Convert.ToInt32(cellPasteStartN.Substring(1))-1;
            if (pasteStartIndex < 0)
            {
                pasteStartIndex = 0;
            }
            if (pasteStartIndex >  table.Rows.Count)
            {
                pasteStartIndex = table.Rows.Count ;
            }
           
            List<XTextTableRowElement> sourceRows = new List<XTextTableRowElement>();
            for (int i = 0; i < count; i++)
            {
                int index = copyStartRowIndex + i;
                if (index >= table.Rows.Count)
                {
                    break;
                }
                XTextTableRowElement row = ( XTextTableRowElement ) table.Rows[index];
                sourceRows.Add(row.EditorCloneSpecifyCloneType(TableRowCloneType.Complete));
            }//for
            if (sourceRows.Count > 0)
            {
                int insertIndex = pasteStartIndex;
                foreach (XTextTableRowElement row in sourceRows)
                {
                    table.Rows.Insert(insertIndex, row);
                    insertIndex++;
                }
                table.EditorRefreshView();
                //sourceRows[0].Focus();
                table.OwnerDocument.Modified = true;
                table.OwnerDocument.UndoList.Clear();
                table.OwnerDocument.OnDocumentContentChanged();
                table.OwnerDocument.OnSelectionChanged();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnTestRowReadonly_Click(object sender, EventArgs e)
        {
            XTextTableElement table = myWriterControl.CurrentTable;
            if (table != null)
            {
                foreach (XTextTableRowElement row in table.Rows)
                {
                    row.ContentReadonly = ContentReadonlyState.True;
                }
            }
        }

        private void btnSelectColumn_Click(object sender, EventArgs e)
        {
            XTextTableCellElement cell = this.myWriterControl.CurrentTableCell;
            if (cell != null)
            {
                cell.OwnerColumn.Select();
            }
        }

        private void btnSelectRow_Click(object sender, EventArgs e)
        {
            XTextTableRowElement row = this.myWriterControl.CurrentTableRow;
            if (row != null)
            {
                row.Select();
            }
        }

        private void btnSetCellNoPrintable_Click(object sender, EventArgs e)
        {
            if (myWriterControl.Selection.Cells != null)
            {
                foreach (XTextTableCellElement cell in myWriterControl.Selection.Cells)
                {
                    cell.Style.Visibility = Drawing.RenderVisibility.Hidden;
                }
            }
        }

        private void btnSetTopBorderColor_Click(object sender, EventArgs e)
        {
            XTextTableCellElement cell =( XTextTableCellElement ) myWriterControl.GetCurrentElement(typeof(XTextTableCellElement));
            if (cell != null)
            {
                cell.EditorSetBorderColor(Drawing.DCDirection.Top, true, Color.Red);
            }
        }

        private void btnInsertTableAndBindingDataTable_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            using (dlgBrowseDOCEXTable dlg = new dlgBrowseDOCEXTable())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    dt = dlg.SelectedDataTable;
                }
                else
                {
                    return;
                }
            }
            XTextTableElement table = new XTextTableElement();
            table.OwnerDocument = this.myWriterControl.Document ;
            // 创建表格列
            for (int iCount = 0; iCount < dt.Columns.Count; iCount++)
            {
                XTextTableColumnElement col = table.CreateColumnInstance();
                col.Width = myWriterControl.Document.Body.Width / dt.Columns.Count - 10 ;
                table.Columns.Add(col);
            }
            // 创建标题行
            XTextTableRowElement headerRow = table.CreateRowInstance();
            headerRow.HeaderStyle = true;
            table.AppendChildElement(headerRow);
            for (int iCount = 0; iCount < dt.Columns.Count; iCount++)
            {
                DataColumn col = dt.Columns[iCount];
                XTextTableCellElement cell = table.CreateCellInstance();
                headerRow.AppendChildElement(cell);
                cell.ContentBuilder.AppendText(col.ColumnName);
            }
            // 创建数据行
            XTextTableRowElement dRow = table.CreateRowInstance();
            table.AppendChildElement(dRow);
            dRow.ValueBinding = new XDataBinding();
            dRow.ValueBinding.DataSource = "dt";
            dRow.ExpendForDataBinding = true;
            for (int iCount = 0; iCount < dt.Columns.Count; iCount++)
            {
                // 创建单元格对象
                XTextTableCellElement cell = table.CreateCellInstance();
                dRow.Cells.Add(cell);
                XTextInputFieldElement field = new XTextInputFieldElement();
                field.ValueBinding = new XDataBinding();
                field.ValueBinding.BindingPath = dt.Columns[iCount].ColumnName;
                cell.Elements.Add(field);
            }//for

            this.myWriterControl.ExecuteCommand(StandardCommandNames.Table_InsertTable, false, table);
            MessageBox.Show("插入表格");
            this.myWriterControl.SetDocumentParameterValue("dt", dt);
            this.myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();// .ExecuteCommand(StandardCommandNames.UpdateViewForDataSource, false, null);
        }

        private void btnSetGridLine_Click(object sender, EventArgs e)
        {
            if (this.myWriterControl.CurrentTableRow != null)
            {
                this.myWriterControl.CurrentTableRow.EditorSetSpecifyFixedLineHeight(70, true, false);
            }
        }

        private void btnSetCellBorder2_Click(object sender, EventArgs e)
        {
            BorderBackgroundCommandParameter p = new BorderBackgroundCommandParameter();
            p.ApplyRange = StyleApplyRanges.Cell;
            p.BorderTopColor = Color.Red;
            p.BorderLeftColor = Color.Red;
            p.BorderRightColor = Color.Red;
            p.BorderBottomColor = Color.Red;
            p.TopBorder = true;
            p.LeftBorder = true;
            p.TopBorder = true;
            p.RightBorder = true;
            p.BottomBorder = true;
            p.MiddleHorizontalBorder = false;
            p.CenterVerticalBorder = false;
            p.BorderWidth = 3;
            p.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.myWriterControl.ExecuteCommand(StandardCommandNames.BorderBackgroundFormat, false, p);
        }

        private void btnSortTable_Click(object sender, EventArgs e)
        {
            XTextTableElement table = myWriterControl.CurrentTable;
            if (table != null)
            {
                MyTableRowComparer com = new MyTableRowComparer();
                com.ColumIndex = myWriterControl.CurrentTableCell.ColIndex ;
                table.SortRows(0, table.Rows.Count, com, true); 
            }
        }

        private class MyTableRowComparer : DCSoft.Writer.Dom.IDCTableRowComparer
        {
            public int ColumIndex = 0;
            public int CompareTableRow(XTextTableRowElement row1, XTextTableRowElement row2)
            {
                string txt = row1.Cells[this.ColumIndex].Text;
                string txt2 = row2.Cells[this.ColumIndex].Text;
                return string.Compare(txt, txt2);
            }
        }



    }
}