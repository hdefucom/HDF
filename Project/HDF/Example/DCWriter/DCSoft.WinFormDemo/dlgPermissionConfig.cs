using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom ;
using DCSoft.Writer.Security;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class dlgPermissionConfig : Form
    {
        public dlgPermissionConfig()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private XTextDocument _Document = null;

        public XTextDocument Document
        {
            get { return _Document; }
            set { _Document = value; }
        }

        private void dlgPermissionConfig_Load(object sender, EventArgs e)
        {
            if (this.Document != null)
            {
                int iCount = 0 ;
                ListViewItem lastItem = null;
                foreach (UserHistoryInfo info in this.Document.UserHistories)
                {
                    iCount++;
                    ListViewItem item = new ListViewItem(iCount.ToString());
                    item.SubItems.Add(info.ID);
                    item.SubItems.Add(info.Name);
                    item.SubItems.Add(info.PermissionLevel.ToString());
                    if (info.SavedTime == UserHistoryInfo.NullDateTime)
                    {
                        item.SubItems.Add("尚未保存");
                    }
                    else
                    {
                        item.SubItems.Add(info.SavedTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    item.SubItems.Add(info.Description);
                    lvwHistories.Items.Add(item);
                    lastItem = item;
                }
                if (lastItem != null)
                {
                    lastItem.Selected = true;
                    lastItem.EnsureVisible();
                }

                this.chkEnableLogicDelete.Checked = this.Document.Options.SecurityOptions.EnableLogicDelete;
                this.chkShowLogicDeletedContent.Checked = this.Document.Options.SecurityOptions.ShowLogicDeletedContent;
                this.chkShowPermissionMark.Checked = this.Document.Options.SecurityOptions.ShowPermissionMark;
                this.chkShowPermissionTip.Checked = this.Document.Options.SecurityOptions.ShowPermissionTip;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Document != null)
            {
                this.Document.Options.SecurityOptions.EnableLogicDelete = chkEnableLogicDelete.Checked;
                this.Document.Options.SecurityOptions.ShowLogicDeletedContent = chkShowLogicDeletedContent.Checked;
                this.Document.Options.SecurityOptions.ShowPermissionMark = chkShowPermissionMark.Checked;
                this.Document.Options.SecurityOptions.ShowPermissionTip = chkShowPermissionTip.Checked;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
