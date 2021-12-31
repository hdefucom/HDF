using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Test
{
    public partial class Form_CallProgram : Form
    {
        public Form_CallProgram()
        {
            InitializeComponent();
        }


        string path = "";

        private void btn_Selection_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;//该值确定是否可以选择多个文件
                dialog.Title = "请选择文件";
                dialog.Filter = "程序文件(*.exe,*.dll)|*.exe;*.dll";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.FileName;
                    lbl_Path.Text = "路径："+ path;
                }
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("选择文件不存在！");
                return;
            }
            Process process = new Process();
            process.StartInfo.FileName = path;

            string funcid = "1001";

            string basexml = @"<base_xml>
                             <hosp_code>1563</hosp_code>
                             <dept_code>1141</dept_code>
                             <dept_name>北京西路门诊部</dept_name>
                             <doct>
                             <code>0084</code>
                             <name>黄淑华</name>
                             <type>03</type>
                             </doct>
                           </base_xml> ";
            string detailsxml = "<details_xml><doct_pwd></doct_pwd></details_xml>";
            basexml = basexml.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            detailsxml = detailsxml.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            process.StartInfo.Arguments = $"{funcid} {basexml} {detailsxml}";
            process.Start();

        }
    }
}
