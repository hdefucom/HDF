using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZYTextDocumentLib;

namespace ZYCommon
{
	public class dlgUnderWriteMarkList : Form
	{
		private Container components = null;

		private Label label1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private Button cmdClose;

		private ListView lvwMarks;

		private UnderWriteMarkCollection myItems = null;

		public UnderWriteMarkCollection Items
		{
			get
			{
				return myItems;
			}
			set
			{
				myItems = value;
			}
		}

		public dlgUnderWriteMarkList()
		{
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
			label1 = new System.Windows.Forms.Label();
			lvwMarks = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			cmdClose = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(91, 17);
			label1.TabIndex = 0;
			label1.Text = "本文档签名层次";
			lvwMarks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
			{
				columnHeader1,
				columnHeader2,
				columnHeader3
			});
			lvwMarks.FullRowSelect = true;
			lvwMarks.GridLines = true;
			lvwMarks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwMarks.HideSelection = false;
			lvwMarks.Location = new System.Drawing.Point(8, 32);
			lvwMarks.Name = "lvwMarks";
			lvwMarks.Size = new System.Drawing.Size(384, 96);
			lvwMarks.TabIndex = 1;
			lvwMarks.View = System.Windows.Forms.View.Details;
			columnHeader1.Text = "用户名";
			columnHeader1.Width = 93;
			columnHeader2.Text = "签名时间";
			columnHeader2.Width = 149;
			columnHeader3.Text = "指定的接受人";
			columnHeader3.Width = 116;
			cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdClose.Location = new System.Drawing.Point(312, 144);
			cmdClose.Name = "cmdClose";
			cmdClose.TabIndex = 2;
			cmdClose.Text = "关闭(&C)";
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdClose;
			base.ClientSize = new System.Drawing.Size(402, 175);
			base.Controls.Add(cmdClose);
			base.Controls.Add(lvwMarks);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgUnderWriteMarkList";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "签名层次";
			base.Load += new System.EventHandler(dlgUnderWriteMarkList_Load);
			ResumeLayout(false);
		}

		private void dlgUnderWriteMarkList_Load(object sender, EventArgs e)
		{
			if (myItems != null)
			{
				foreach (UnderWriteMark myItem in myItems)
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = myItem.UserName;
					listViewItem.SubItems.Add(myItem.MarkTime.ToString("yyyy年MM月dd日 HH:mm:ss"));
					listViewItem.SubItems.Add(myItem.Senior);
					lvwMarks.Items.Add(listViewItem);
				}
			}
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
