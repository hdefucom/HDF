using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    [ToolboxItem(false)]
    public partial class ctlContentLock : UserControl
    {
        public ctlContentLock()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(Application.StartupPath, "Test\\基于用户角色的内容锁定.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.LoadDocumentFromFile(fileName, null);
            }
            //myWriterControl.ViewMode = DCSoft.Printing.PageViewMode.Normal;
        }
         
        private void menuUserZhangSan_Click(object sender, EventArgs e)
        {
            myWriterControl.UserLoginByParameter("zhangsan", "张三", 1);
            menuUserZhangSan.Checked = true;
            menuUserLiSi.Checked = false;
            menuUserWangWu.Checked = false;
        }

        private void menuUserLiSi_Click(object sender, EventArgs e)
        {
            myWriterControl.UserLoginByParameter("lisi", "李四", 1);
            menuUserZhangSan.Checked = false ;
            menuUserLiSi.Checked = true ;
            menuUserWangWu.Checked = false;
        }

        private void menuUserWangWu_Click(object sender, EventArgs e)
        {
            myWriterControl.UserLoginByParameter("wangwu", "王五", 1);
            menuUserZhangSan.Checked = false ;
            menuUserLiSi.Checked = false;
            menuUserWangWu.Checked = true ;
        }

        private void btnLockContainer_Click(object sender, EventArgs e)
        {
            XTextContainerElement c = ( XTextContainerElement ) myWriterControl.GetCurrentElement(typeof(XTextContainerElement));
            if (c != null)
            {
                c.SetContentLockByCurrentUser( );
            }
        }

        private void btnLockTableRow_Click(object sender, EventArgs e)
        {
            if (myWriterControl.CurrentTableRow != null)
            {
                myWriterControl.CurrentTableRow.SetContentLockByCurrentUser();
            }
        }

        private void btnLockTable_Click(object sender, EventArgs e)
        {
            if (myWriterControl.CurrentTable != null)
            {
                myWriterControl.CurrentTable.SetContentLockByCurrentUser();
            }
        }

    }
}