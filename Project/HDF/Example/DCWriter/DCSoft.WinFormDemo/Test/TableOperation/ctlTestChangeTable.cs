using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestChangeTable : UserControl
    {
        public ctlTestChangeTable()
        {
            InitializeComponent();
        }


        private void frmTestChangeTable_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            XTextTableElement table =( XTextTableElement ) this.myWriterControl.Document.GetCurrentElement(typeof(XTextTableElement), true);
            if (table == null)
            {
                MessageBox.Show("请将光标移动到一个表格中");
            }
            else
            {
                string fileName = System.IO.Path.Combine( Application.StartupPath, "About.jpg");
                if (System.IO.File.Exists(fileName))
                {
                    Image img = Image.FromFile(fileName);
                    XTextImageElement imgElement = new XTextImageElement();
                    imgElement.ImageValue = img;
                    imgElement.Width = 300;
                    imgElement.Height = 300;
                    XTextTableCellElement cell = table.GetCell(0, 0, true);
                    cell.Elements.Insert( 0 , imgElement);
                    table.EditorRefreshView();
                }
                else
                {
                    MessageBox.Show("未找到文件 " + fileName );
                }
            }
        }

        private void btnAddTableRow_Click(object sender, EventArgs e)
        {
            XTextTableElement table = (XTextTableElement)this.myWriterControl.Document.GetCurrentElement(typeof(XTextTableElement), true);
            if (table == null)
            {
                MessageBox.Show("请将光标移动到一个表格中");
            }
            else
            {
                XTextDocument document = table.OwnerDocument ;
                XTextTableRowElement row = new XTextTableRowElement();
                foreach (XTextTableColumnElement col in table.Columns)
                {
                    XTextTableCellElement cell = new XTextTableCellElement();
                    row.Cells.Add(cell);
                    cell.Elements.AddRange(document.CreateTextElements("表格列" + table.Columns.IndexOf(col), null, null));
                }
                table.Rows.Add(row);
                table.EditorRefreshView();
            }
        }

    }
}
