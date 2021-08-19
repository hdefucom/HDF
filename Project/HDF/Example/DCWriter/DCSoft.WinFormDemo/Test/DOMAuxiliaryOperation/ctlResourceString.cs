using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlResourceString : UserControl
    {
        public ctlResourceString()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            Dictionary<string, string> table = myWriterControl.GetAllResourceStringValue();
            foreach (string name in table.Keys)
            {
                this.dgvStringResource.Rows.Add(name, table[name]);
            }
            dgvStringResource.Sort(dgvStringResource.Columns[0], ListSortDirection.Ascending);
            
        }
          
        private void dgvStringResource_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStringResource.Rows[e.RowIndex];
                string strName = Convert.ToString(row.Cells[0].Value);
                string strValue = Convert.ToString(row.Cells[1].Value);
                this.myWriterControl.SetResourceStringValue(
                    strName,
                    strValue);
                row.Cells[1].Style.ForeColor = Color.Red;
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.myWriterControl.DocumentOptions.BehaviorOptions.MaxTextLengthForPaste = 10;
            this.myWriterControl.SetResourceStringValue(
                "PromptMaxTextLengthForPaste_Length",
                "您好，在本界面中设置为粘贴或插入内容时不能接收超过{0}个字符。");
            this.myWriterControl.SetResourceStringValue(
                "SystemWarring",
                "南京都昌信息科技有限公司提醒您");
        }
    }
}