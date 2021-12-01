using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Commands;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestSearchReplace : UserControl
    {
        public ctlTestSearchReplace()
        {
            InitializeComponent();
        }

        private void frmTestSearchReplace_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            //小伍添加的代码：自动加载一个演示文件
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            //代码结束
        }

        private void btnCustomSearch_Click(object sender, EventArgs e)
        {
            // 创建参数
            SearchReplaceCommandArgs args = new SearchReplaceCommandArgs();
            // 不是进行替换操作
            args.EnableReplaceString = false;
            // 设置要查找的内容
            args.SearchString = txtSearch.Text;
            // 查找时忽略大小写
            args.IgnoreCase = true;
            // 调用查找替换命令
            int result = (int)myWriterControl.ExecuteCommand("SearchReplace", false, args);
            if (result < 0)
            {
                MessageBox.Show("没有找到指定的内容");
            }
        }

        private void btnReplaceAs_Click(object sender, EventArgs e)
        {
            // 创建参数对象
            SearchReplaceCommandArgs args = new SearchReplaceCommandArgs();
            // 设置要查找的字符串
            args.SearchString = txtSearch.Text;
            // 设置要替换的字符串
            args.ReplaceString = txtReplace.Text;
            // 查找时不忽略大小写
            args.IgnoreCase = false;
            // 执行替换操作
            args.EnableReplaceString = true;
            // 调用查找替换命令
            int result = (int)myWriterControl.ExecuteCommand("SearchReplace", false, args);
            if (result == -1)
            {
                MessageBox.Show("没有找到指定的内容");
            }
            else if (result == -2)
            {
                MessageBox.Show("未能完成操作，可能内容只读。");
            }
        }
    }
}