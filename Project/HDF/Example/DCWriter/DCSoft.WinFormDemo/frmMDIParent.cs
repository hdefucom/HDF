using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class frmMDIParent : Form
    {
        private int childFormNumber = 0;

        public frmMDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmMDIChild childForm = new frmMDIChild();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML文件|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = dlg.FileName;
                    frmMDIChild frm = new frmMDIChild();
                    frm.MdiParent = this;
                    frm.Text = fileName;
                    frm.Show();
                    frm.myEditControl.ExecuteCommand("FileOpen", false, fileName);
                }
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMDIParent_MdiChildActivate(object sender, EventArgs e)
        {
            frmMDIChild frm = this.ActiveMdiChild as frmMDIChild;
            if (frm != null)
            {
                frm.myEditControl.CommandControler = this.myCommandControler;
                frm.myEditControl.CommandControler.InvalidateCommandState();
            }
            else
            {
                this.myCommandControler.EditControl = null;
                this.myCommandControler.InvalidateCommandState();
            }
        }

        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            this.myCommandControler.Start();
        }

        private void mWindows1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                this.ActivateMdiChild(this.MdiChildren[0]);
            }
        }
    }
}
