using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestTable2 : UserControl
    {
        public ctlTestTable2()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            //myWriterControl.ViewMode = DCSoft.Printing.PageViewMode.Normal;
            btnOpenDemoFile_Click(null, null);
        }
          
        private void btnOpenDemoFile_Click(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine( 
                Application.StartupPath , 
                "DemoFile\\无网格护理记录单.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.LoadDocumentFromFile(fileName, null);
            }
        }

        private void btnMirrorView_Click(object sender, EventArgs e)
        {
            XTextTableElement table = ( XTextTableElement ) this.myWriterControl.Document.Body.GetFirstElementByType(typeof(XTextTableElement));
            if (table != null)
            {
                foreach (XTextTableRowElement row in table.Rows)
                {
                    XTextTableCellElement cell = (XTextTableCellElement)row.Cells[0];
                    cell.MirrorViewForCrossPage = btnMirrorView.Checked;
                    cell = (XTextTableCellElement)row.Cells[1];
                    cell.MirrorViewForCrossPage = btnMirrorView.Checked;
                }
                this.myWriterControl.Invalidate(true);
            }
        }

        private void btnNewPage_Click(object sender, EventArgs e)
        {
            XTextTableRowElement row = this.myWriterControl.CurrentTableRow;
            if (row != null)
            {
                row.NewPage = btnNewPage.Checked;
                myWriterControl.RefreshDocument();
            }
        }

        private void btnSplitTable_Click(object sender, EventArgs e)
        {
            XTextTableElement table = myWriterControl.CurrentTable;
            if (table == null)
            {
                return;
            }
            int startRowIndex = 0;
            foreach (XTextTableRowElement row in table.Rows)
            {
                if (row.HeaderStyle)
                {
                    startRowIndex++;
                }
                else
                {
                    break;
                }
            }
            table.SplitRowsByContentLines(startRowIndex, table.Rows.Count - startRowIndex , true);
            int lastPageIndex = 0;
            bool modified = false;
            for( int iCount = startRowIndex ; iCount < table.Rows.Count ; iCount ++ )
            {
                XTextTableRowElement row = (XTextTableRowElement)table.Rows[iCount];
                if (row.OwnerPageIndex != lastPageIndex)
                {
                    // 当前页的第一个表格行
                    row.Cells[0].Text = DateTime.Now.ToString("yyyy-MM-dd");
                    modified = true;
                    lastPageIndex = row.OwnerPageIndex;
                }
            }
            if (modified)
            {
                table.EditorRefreshView();
            }
        }
         
    }
}