using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestInjectCommand : UserControl
    {
        public ctlTestInjectCommand()
        {
            InitializeComponent();
        }

        private void frmTestInjectCommand_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.CommandControler.InjectHandlers.AddBefore(
                "InsertImage",
                new WriterCommandEventHandler(this.BeforeInsertImage));
            myWriterControl.CommandControler.InjectHandlers.AddAfter(
                "InsertImage",
                new WriterCommandEventHandler(this.AfterInsertImage));
        }

        /// <summary>
        /// 在插入图片命令前执行的代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BeforeInsertImage(object sender, WriterCommandEventArgs args)
        {
            // 创建图片库选择对话框
            using (dlgBrowseImageLibrary dlg = new dlgBrowseImageLibrary())
            {
                // 显示图片库选择对话框
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // 根据用户从图片库中选择的图片创建一个图片文档元素对象
                    XTextImageElement imgElement = new XTextImageElement();
                    imgElement.ImageValue = dlg.SelectedImage;
                    imgElement.Name = "注入方式插入的图片";
                    imgElement.Attributes = new XAttributeList();
                    imgElement.Attributes.SetValue("插入时间", DateTime.Now.ToString());
                    // 设置用户参数为新创建的图片元素对象
                    args.Parameter = imgElement;
                    // 隐藏编辑器默认的用户界面
                    args.ShowUI = false;
                    // 完成操作，退出处理
                    return;
                }
            }
            // 取消命令。
            args.Cancel = true;
        }
        private void AfterInsertImage(object sender, WriterCommandEventArgs args)
        {
            if (args.Result != null)
            {
                MessageBox.Show("成功的插入图片了!");
            }
        }

        /// <summary>
        /// 插入数据表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertTable_Click(object sender, EventArgs e)
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
                            XTextTableElement tableElement = CreateTableElement(
                                table,
                                myWriterControl.Document);
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

        /// <summary>
        /// 根据一个数据表创建一个表格文档元素对象
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <param name="document">文档对象</param>
        /// <returns>创建的文档元素对象</returns>
        private XTextTableElement CreateTableElement(DataTable dt, XTextDocument document)
        {
            XTextTableElement tableElement = new XTextTableElement();
            tableElement.OwnerDocument = document;
            foreach (DataColumn col in dt.Columns)
            {
                XTextTableColumnElement colElement = new XTextTableColumnElement();
                colElement.Width = 800;
                tableElement.Columns.Add(colElement);
            }

            // 添加首行
            XTextTableRowElement firstRow = new XTextTableRowElement();
            tableElement.Rows.Add(firstRow);
            // 设置为标题行样式
            firstRow.HeaderStyle = true;
            // 标题栏文本样式
            DocumentContentStyle headerTextStyle = new DocumentContentStyle();
            // 标题行文本为粗体
            headerTextStyle.Bold = true;
            foreach (DataColumn col in dt.Columns)
            {
                XTextTableCellElement cell = new XTextTableCellElement();
                // 将新增的单元格添加到标题行中
                firstRow.Cells.Add(cell);
                // 设置单元格文本内容
                cell.Elements.AddRange(document.CreateTextElements(
                    col.ColumnName,
                    null,
                    headerTextStyle));
                // 设置单元格样式
                cell.Style.BackgroundColor = Color.LightBlue;
                cell.Style.BorderLeft = true;
                cell.Style.BorderTop = true;
                cell.Style.BorderRight = true;
                cell.Style.BorderBottom = true;
                cell.Style.BorderWidth = 1;
                cell.Style.BorderColor = Color.Black;
                cell.Style.PaddingTop = 10;
                cell.Style.PaddingBottom = 10;
                cell.Style.FontSize = 12;
            }



            // 遍历所有的数据行，添加表格行
            foreach (DataRow row in dt.Rows)
            {
                // 添加数据行
                XTextTableRowElement rowElement = new XTextTableRowElement();
                tableElement.Rows.Add(rowElement);
                foreach (DataColumn col in dt.Columns)
                {
                    // 添加单元格
                    string text = Convert.ToString(row[col]);
                    XTextTableCellElement cell = new XTextTableCellElement();
                    // 向数据行添加单元格
                    rowElement.Cells.Add(cell);
                    // 设置单元格文本
                    cell.Elements.AddRange(
                        document.CreateTextElements(text, null, null));
                    // 设置单元格样式
                    cell.Style.BorderLeft = true;
                    cell.Style.BorderTop = true;
                    cell.Style.BorderRight = true;
                    cell.Style.BorderBottom = true;
                    cell.Style.BorderWidth = 1;
                    cell.Style.BorderColor = Color.Black;
                    cell.Style.PaddingTop = 10;
                    cell.Style.PaddingBottom = 10;
                    cell.Style.PaddingLeft = 20;
                    cell.Style.FontSize = 12;
                }
            }
            return tableElement;
        }

        private void btnInsertTable2_Click(object sender, EventArgs e)
        {
            XTextTableElement table = new XTextTableElement();
            table.Columns.Add(new XTextTableColumnElement());
            XTextTableRowElement row = new XTextTableRowElement();
            table.Rows.Add(row);
            XTextTableCellElement cell = new XTextTableCellElement();
            row.Cells.Add(cell);
            cell.SetInnerTextFast(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            myWriterControl.ExecuteCommand("Table_InsertTable", false, table);
        }
    }
}