using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class frmDBFileList : Form
	{
		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private Button cmdOK;

		private Button cmdCancel;

		public ZYDBConnection DBConn;

		private Label lblTitle;

		private ListView lvwFile;

		private Container components = null;

		public ET_Document SelectedRecord = null;

		public void RefreshList()
		{
			ET_Document myRecord = new ET_Document();
			ArrayList arrayList = DBConn.ReadRecords(myRecord);
			lblTitle.Text = "请选择一个文本 , 共 " + arrayList.Count + " 个文档";
			lvwFile.BeginUpdate();
			lvwFile.Items.Clear();
			foreach (ET_Document item in arrayList)
			{
				ListViewItem listViewItem = new ListViewItem(item.ObjectID.ToString());
				listViewItem.SubItems.Add(item.ObjectName);
				listViewItem.Tag = item;
				lvwFile.Items.Add(listViewItem);
			}
			lvwFile.EndUpdate();
		}

		public frmDBFileList()
		{
			base.DialogResult = DialogResult.OK;
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			lblTitle = new System.Windows.Forms.Label();
			lvwFile = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			lblTitle.AutoSize = true;
			lblTitle.Location = new System.Drawing.Point(16, 16);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new System.Drawing.Size(91, 17);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "请选择一个文档";
			lvwFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2]
			{
				columnHeader1,
				columnHeader2
			});
			lvwFile.FullRowSelect = true;
			lvwFile.GridLines = true;
			lvwFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwFile.HideSelection = false;
			lvwFile.LabelWrap = false;
			lvwFile.Location = new System.Drawing.Point(16, 40);
			lvwFile.MultiSelect = false;
			lvwFile.Name = "lvwFile";
			lvwFile.Size = new System.Drawing.Size(480, 272);
			lvwFile.TabIndex = 1;
			lvwFile.View = System.Windows.Forms.View.Details;
			lvwFile.DoubleClick += new System.EventHandler(lvwFile_DoubleClick);
			columnHeader1.Text = "文件编号";
			columnHeader1.Width = 90;
			columnHeader2.Text = "文档标题";
			columnHeader2.Width = 300;
			cmdOK.Location = new System.Drawing.Point(320, 336);
			cmdOK.Name = "cmdOK";
			cmdOK.Size = new System.Drawing.Size(75, 24);
			cmdOK.TabIndex = 2;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(416, 336);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Size = new System.Drawing.Size(75, 24);
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(512, 375);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(lvwFile);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmDBFileList";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "打开文档";
			ResumeLayout(false);
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (lvwFile.SelectedItems.Count > 0)
			{
				SelectedRecord = (lvwFile.SelectedItems[0].Tag as ET_Document);
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show("请选择一个项目");
			}
		}

		private void lvwFile_DoubleClick(object sender, EventArgs e)
		{
			cmdOK_Click(null, null);
		}
	}
}
