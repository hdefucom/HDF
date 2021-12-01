using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YidanSoft.Library.EmrEditor.Src.Document.PropertyElement
{
    public partial class ItemInputForm : Form
    {
        public ItemInputForm(bool showgroup, object value)
        {
            InitializeComponent();
            ItemList = (List<ZYSelectableElementItem>)value;
            //初始化选项值
            foreach (ZYSelectableElementItem selectItem in ItemList)
            {
                //temp[i++] = selectItem.InnerValue;
                this.dataGridView1.Rows.Add(selectItem.Code, selectItem.InnerValue, selectItem.Group);

            }
            if (showgroup)
            {
                this.dataGridView1.Columns[2].Visible = true;
                this.labelGroup.Visible = true;
            }
            else
            {
                this.dataGridView1.Columns[2].Visible = false;
                this.labelGroup.Visible = false;
            }
        }

        Image img = global::YidanSoft.Library.EmrEditor.Properties.Resources.delete;
        List<ZYSelectableElementItem> ItemList = null;
        List<ZYSelectableElementItem> ReturnItemList =  new List<ZYSelectableElementItem>();

        public List<ZYSelectableElementItem> Value
        {
            get
            {
                ReturnItemList.Clear();
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    ZYSelectableElementItem item = new ZYSelectableElementItem();
                    item.Code = row.Cells[0].Value!=null ? row.Cells[0].Value.ToString():"";
                    item.InnerValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString():"";
                    item.Group = row.Cells[2].Value != null ? row.Cells[2].Value.ToString():"";


                    ReturnItemList.Add(item);
                }
                return ReturnItemList;
                //return null;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //保存值

            this.Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
            e.Row.Cells[3].Value = img;
        }

        //删除按钮
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >=0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "DeleteRow")
            {
                if(!this.dataGridView1.Rows[e.RowIndex].IsNewRow)
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
