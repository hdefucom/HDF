using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    public partial class frmSelectTemplate : Form
    {
        ctlTestMulCourse6 ctl6 = null;
        ListItemCollection list = new ListItemCollection();
        public frmSelectTemplate(ctlTestMulCourse6 ctl)
        {
            InitializeComponent();
            this.ctl6 = ctl;
        }

        private void frmSelectTemplate_Load(object sender, EventArgs e)
        {
            try
            {
                using (IDbConnection conn = Utils.CreateConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        //加载记录名称
                        cmd.CommandText = "Select RecordMark,RecordContent,RecordID From  CourseRecord ";
                        IDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            dgvSubTemplate.Rows.Add(false, reader.GetValue(0));

                            ListItem item = new ListItem();
                            item.ID = Convert.ToString(reader.GetValue(0));
                            item.Text = Convert.ToString(reader.GetValue(1));
                            item.Tag = Convert.ToString(reader.GetValue(2));//保存需要
                            list.Add(item);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接Access数据库错误，请检查Sql服务是否打开。" + ex.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSubTemplate.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvSubTemplate.Rows[i].Cells[0].Value) == true)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].ID == dgvSubTemplate.Rows[i].Cells[1].Value.ToString())
                        {
                            list[j].Text2 = "1";
                        }
                    }
                }
            }
            ctl6.list = list;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                for (int i = 0; i < dgvSubTemplate.Rows.Count; i++)
                {
                    dgvSubTemplate.Rows[i].Cells[0].Value = true;
                }
            else
                for (int i = 0; i < dgvSubTemplate.Rows.Count; i++)
                {
                    dgvSubTemplate.Rows[i].Cells[0].Value = false;
                }
        }
    }
}
