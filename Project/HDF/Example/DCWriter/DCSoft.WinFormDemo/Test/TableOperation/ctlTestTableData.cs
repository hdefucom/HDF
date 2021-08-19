using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestTableData : UserControl
    {
        public ctlTestTableData()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
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
            table.OwnerDocument = this.myWriterControl.Document;
            // 创建表格列
            for (int iCount = 0; iCount < dt.Columns.Count; iCount++)
            {
                XTextTableColumnElement col = table.CreateColumnInstance();
                col.Width = myWriterControl.Document.Body.Width / dt.Columns.Count - 10;
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
                cell.Style.BackgroundColor = Color.LightGray;
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
                cell.ValueBinding = new XDataBinding();
                cell.ValueBinding.BindingPath = dt.Columns[iCount].ColumnName;
                //XTextInputFieldElement field = new XTextInputFieldElement();
                //field.ValueBinding = new XDataBinding();
                //field.ValueBinding.BindingPath = dt.Columns[iCount].ColumnName;
                //cell.Elements.Add(field);
            }//for
            this.myWriterControl.ExecuteCommand("FileNew", false, null);
            this.myWriterControl.ExecuteCommand("Table_InsertTable", false, table);
            MessageBox.Show("插入表格,将要执行表格行数据源绑定。");
            this.myWriterControl.SetDocumentParameterValue("dt", dt);
            this.myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();
       
        }
        private void btnSortTable_Click(object sender, EventArgs e)
        {
            XTextTableElement table = myWriterControl.CurrentTable;
            if (table != null)
            {
                MyTableRowComparer com = new MyTableRowComparer();
                com.ColumIndex = myWriterControl.CurrentTableCell.ColIndex;
                // 表格首行是标题行，不参与排序。
                int tick = Environment.TickCount;
                bool result = table.SortRows(1, table.Rows.Count-1, com, true);
                tick = Environment.TickCount - tick;
                if (result)
                {
                    MessageBox.Show("操作修改了文档内容,耗时 " + tick + " 毫秒.");
                }
                else
                {
                    MessageBox.Show("操作没修改内容,耗时 " + tick + " 毫秒.");
                }
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

        private void btnList_Click(object sender, EventArgs e)
        {
            System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.Test.医嘱单模板.xml");
            myWriterControl.LoadDocument(stream, null);
            stream.Close();
            MessageBox.Show("加载的模板");
           
            DataTable table = new DataTable();
            stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.Test.医嘱数据表.xml");
            table.ReadXml(stream);
            stream.Close();
            MessageBox.Show("加载了医嘱数据，准备填充.");

            myWriterControl.SetDocumentParameterValue("医嘱列表", table);
            int tick = System.Environment.TickCount;
            myWriterControl.WriteDataFromDataSourceToDocument();//.UpdateViewForDataSource();
            tick = Environment.TickCount - tick;
            MessageBox.Show("操作完成，耗时 " + tick + " 毫秒。");
        }

        private void btnBindingXML_Click(object sender, EventArgs e)
        {
            System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.Test.医嘱单模板.xml");
            myWriterControl.LoadDocument(stream, null);
            stream.Close();
            MessageBox.Show("加载的模板");

            stream = this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.Test.医嘱数据表.xml");
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(stream);
            stream.Close();
            doc.DocumentElement.RemoveChild(doc.DocumentElement.FirstChild);
            string xml = doc.DocumentElement.OuterXml ;

            MessageBox.Show("加载了XML字符串：" + xml.Substring( 0 , 1000) );

            myWriterControl.SetDocumentParameterValueXml("医嘱列表", xml);
            int tick = System.Environment.TickCount;
            myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();
            tick = Environment.TickCount - tick;
            MessageBox.Show("操作完成，耗时 " + tick + " 毫秒。");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            myWriterControl.WriteDataFromDocumentToDataSource();
            DataTable table = new DataTable();
            table = myWriterControl.GetDocumnetParameterValue("医嘱列表") as DataTable;
            string xx = this.myWriterControl.FormValuesString;
        }

        private void btnLeftRightAndUpDown2_Click(object sender, EventArgs e)
        {
            XTextTableElement table = this.myWriterControl.CurrentTable;
            if (table != null)
            {
                int tick = System.Environment.TickCount;
                table.SubfieldSpecify(TableSubfieldMode.LeftRightAndUpDown, 2, true);
                tick = System.Environment.TickCount - tick;
                MessageBox.Show("完成拆分，耗时" + tick + "毫秒");
            }
        }

        private void btnUpDownAndLeftRight3_Click(object sender, EventArgs e)
        {
            XTextTableElement table = this.myWriterControl.CurrentTable;
            if (table != null)
            {
                int tick = System.Environment.TickCount;
                table.SubfieldSpecify(TableSubfieldMode.UpDownAndLeftRight, 3, true);
                tick = System.Environment.TickCount - tick;
                MessageBox.Show("完成拆分，耗时" + tick + "毫秒");
            }
        }
    }
}