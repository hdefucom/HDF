using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    [ToolboxItem(false)]
    public partial class ctlTestFileLock : UserControl
    {
        public ctlTestFileLock()
        {
            InitializeComponent();
        }



        private void ctlTestFileLock_Load(object sender, EventArgs e)
        {
            // 启用内容修改操作检测
            this.writerControl1.EnableUIEventStartEditContent = true;
            this.writerControl1.EventUIStartEditContent += new WriterStartEditEventHandler(writerControl1_EventUIStartEditContent);
            // 启用内容修改操作检测
            this.writerControl2.EnableUIEventStartEditContent = true;
            this.writerControl2.EventUIStartEditContent += new WriterStartEditEventHandler(writerControl2_EventUIStartEditContent);

            this.Disposed += new EventHandler(ctlTestFileLock_Disposed);
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\文件内容锁定.xml");
            if (System.IO.File.Exists(fileName))
            {
                writerControl1.ExecuteCommand("FileOpen", false, fileName);
                writerControl2.ExecuteCommand("FileOpen", false, fileName);
            }
        }

        void ctlTestFileLock_Disposed(object sender, EventArgs e)
        {
            // 开发者可以在关闭界面时操作数据库来释放对文件的锁定
            this._FileLockFlag = false;
        }

        /// <summary>
        /// 文件锁定标记
        /// </summary>
        private bool _FileLockFlag = false;
        /// <summary>
        /// 第一个编辑器内容第一次修改时的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void writerControl1_EventUIStartEditContent(object sender, WriterStartEditEventArgs args)
        {
            // 此处开发者可以查询数据库获得文件的锁定状态。
            if (_FileLockFlag == false)
            {
                // 文件没有锁定，我来锁定，别的控件无法修改内容了。
                // 开发者可以在此操作数据库来设置文档锁定状态。
                _FileLockFlag = true;
                // 控件内容不只读
                args.Readonly = false;
                // 控件无需后续在此检测锁定状态
                args.CanDetectAgain = false;
                Color cb = writerControl1.BackColor;
                writerControl1.BackColor = Color.Blue;
                MessageBox.Show("呵呵，文件被我占用了，别人不能改了。");
                writerControl1.BackColor = cb;
            }
            else
            {
                // 文件已经被其他控件锁定了。
                // 控件内容只读
                args.Readonly = true;
                // 控件后续可以继续检测锁定状态
                args.CanDetectAgain = true;
                MessageBox.Show("文档被其他控件锁定了,无法修改!!!");
            }
        }
        /// <summary>
        /// 第二个编辑器内容第一次修改时的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void writerControl2_EventUIStartEditContent(object sender, WriterStartEditEventArgs args)
        {
            // 此处开发者可以查询数据库获得文件的锁定状态。
            if (_FileLockFlag == false)
            {
                // 文件没有锁定，我来锁定，别的控件无法修改内容了。
                // 开发者可以在此操作数据库来设置文档锁定状态。
                _FileLockFlag = true;
                // 控件内容不只读
                args.Readonly = false;
                // 控件无需后续在此检测锁定状态
                args.CanDetectAgain = false;
                Color cb = writerControl2.BackColor;
                writerControl2.BackColor = Color.Blue;
                MessageBox.Show("呵呵，文件被我占用了，别人不能改了。");
                writerControl2.BackColor = cb;
            }
            else
            {
                // 文件已经被其他控件锁定了。
                // 控件内容只读
                args.Readonly = true;
                // 控件后续可以继续检测锁定状态
                args.CanDetectAgain = true;
                MessageBox.Show("文档被其他控件锁定了,无法修改!!!");
            }
        }

         

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.writerControl1.LoadDocumentFromFile(dlg.FileName, null);
                    this.writerControl2.LoadDocumentFromFile(dlg.FileName, null);
                    this._FileLockFlag = false;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // 重置控件状态，使得又能触发EventUIStartEditContent事件。
            this.writerControl1.ResetUIStartEditContentState();
            this.writerControl2.ResetUIStartEditContentState();
            // 重置文档锁定状态
            this._FileLockFlag = false;
        }
    }
}
