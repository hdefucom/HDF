using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class NameValueListControl : UserControl
	{
		private Button cmdAdd;

		private Button cmdDelete;

		private Panel pnlToolBar;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ListView lvwItem;

		private Button cmdCopy;

		private Button cmdPaste;

		private Container components = null;

		private bool bolCanEditName = true;

		private bool bolCanEditValue = true;

		private bool bolCanAdd = true;

		private bool bolCanDelete = true;

		public bool CanEditName
		{
			get
			{
				return bolCanEditName;
			}
			set
			{
				bolCanEditName = value;
			}
		}

		public bool CanEditValue
		{
			get
			{
				return bolCanEditValue;
			}
			set
			{
				bolCanEditValue = value;
			}
		}

		public bool CanAdd
		{
			get
			{
				return bolCanAdd;
			}
			set
			{
				bolCanAdd = value;
			}
		}

		public bool CanDelete
		{
			get
			{
				return bolCanDelete;
			}
			set
			{
				bolCanDelete = value;
			}
		}

		public NameValueListControl()
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
			cmdAdd = new System.Windows.Forms.Button();
			cmdDelete = new System.Windows.Forms.Button();
			pnlToolBar = new System.Windows.Forms.Panel();
			lvwItem = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			cmdCopy = new System.Windows.Forms.Button();
			cmdPaste = new System.Windows.Forms.Button();
			pnlToolBar.SuspendLayout();
			SuspendLayout();
			cmdAdd.Location = new System.Drawing.Point(8, 3);
			cmdAdd.Name = "cmdAdd";
			cmdAdd.TabIndex = 0;
			cmdAdd.Text = "添加(&A)";
			cmdDelete.Location = new System.Drawing.Point(88, 3);
			cmdDelete.Name = "cmdDelete";
			cmdDelete.TabIndex = 1;
			cmdDelete.Text = "删除(&D)";
			pnlToolBar.Controls.Add(cmdPaste);
			pnlToolBar.Controls.Add(cmdCopy);
			pnlToolBar.Controls.Add(cmdAdd);
			pnlToolBar.Controls.Add(cmdDelete);
			pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			pnlToolBar.Location = new System.Drawing.Point(0, 0);
			pnlToolBar.Name = "pnlToolBar";
			pnlToolBar.Size = new System.Drawing.Size(424, 32);
			pnlToolBar.TabIndex = 2;
			lvwItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2]
			{
				columnHeader1,
				columnHeader2
			});
			lvwItem.Dock = System.Windows.Forms.DockStyle.Fill;
			lvwItem.FullRowSelect = true;
			lvwItem.GridLines = true;
			lvwItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwItem.Location = new System.Drawing.Point(0, 32);
			lvwItem.Name = "lvwItem";
			lvwItem.Size = new System.Drawing.Size(424, 184);
			lvwItem.TabIndex = 3;
			lvwItem.View = System.Windows.Forms.View.Details;
			columnHeader1.Text = "名称";
			columnHeader1.Width = 100;
			columnHeader2.Text = "值";
			columnHeader2.Width = 150;
			cmdCopy.Location = new System.Drawing.Point(168, 3);
			cmdCopy.Name = "cmdCopy";
			cmdCopy.TabIndex = 2;
			cmdCopy.Text = "复制";
			cmdPaste.Location = new System.Drawing.Point(248, 3);
			cmdPaste.Name = "cmdPaste";
			cmdPaste.TabIndex = 3;
			cmdPaste.Text = "粘贴(&P)";
			base.Controls.Add(lvwItem);
			base.Controls.Add(pnlToolBar);
			base.Name = "NameValueListControl";
			base.Size = new System.Drawing.Size(424, 216);
			pnlToolBar.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
