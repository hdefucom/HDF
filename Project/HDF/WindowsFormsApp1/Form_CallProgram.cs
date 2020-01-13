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
            process.StartInfo.Arguments = txt_Parameter.Text;
            process.Start();

        }
    }
}
