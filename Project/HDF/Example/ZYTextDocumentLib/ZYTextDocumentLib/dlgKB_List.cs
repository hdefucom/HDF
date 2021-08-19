using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class dlgKB_List : Form
	{
		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtParent;

		private Label label3;

		private TextBox txtName;

		private Label label4;

		private TextBox txtDesc;

		private TextBox txtListSQL;

		private Label label5;

		private Button cmdOK;

		private Button cmdCancel;

		private Label label8;

		private TextBox txtGroup;

		private GroupBox groupBox1;

		private CheckBox chkInputBox;

		private CheckBox chkPrepAppend;

		private CheckBox chkAfterAppend;

		private CheckBox chkYesNo;

		private Container components = null;

		public KB_List OwnerList = null;

		public dlgKB_List()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
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
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtParent = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtDesc = new System.Windows.Forms.TextBox();
			txtListSQL = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			txtGroup = new System.Windows.Forms.TextBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			chkYesNo = new System.Windows.Forms.CheckBox();
			chkPrepAppend = new System.Windows.Forms.CheckBox();
			chkInputBox = new System.Windows.Forms.CheckBox();
			chkAfterAppend = new System.Windows.Forms.CheckBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 18);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(35, 17);
			label1.TabIndex = 18;
			label1.Text = "编号:";
			txtID.Location = new System.Drawing.Point(96, 16);
			txtID.Name = "txtID";
			txtID.ReadOnly = true;
			txtID.Size = new System.Drawing.Size(288, 21);
			txtID.TabIndex = 19;
			txtID.Text = "";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(16, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(48, 17);
			label2.TabIndex = 20;
			label2.Text = "父节点:";
			txtParent.Location = new System.Drawing.Point(96, 46);
			txtParent.Name = "txtParent";
			txtParent.ReadOnly = true;
			txtParent.Size = new System.Drawing.Size(288, 21);
			txtParent.TabIndex = 21;
			txtParent.Text = "";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(16, 78);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(54, 17);
			label3.TabIndex = 1;
			label3.Text = "名称(&N):";
			txtName.Location = new System.Drawing.Point(96, 76);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(288, 21);
			txtName.TabIndex = 2;
			txtName.Text = "";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(16, 108);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(79, 17);
			label4.TabIndex = 3;
			label4.Text = "值(单位)(&V):";
			txtDesc.Location = new System.Drawing.Point(96, 106);
			txtDesc.Name = "txtDesc";
			txtDesc.Size = new System.Drawing.Size(288, 21);
			txtDesc.TabIndex = 4;
			txtDesc.Text = "";
			txtListSQL.Location = new System.Drawing.Point(96, 136);
			txtListSQL.Name = "txtListSQL";
			txtListSQL.Size = new System.Drawing.Size(288, 21);
			txtListSQL.TabIndex = 6;
			txtListSQL.Text = "";
			txtListSQL.Visible = false;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(16, 138);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(72, 17);
			label5.TabIndex = 5;
			label5.Text = "SQL语言(&Q):";
			label5.Visible = false;
			cmdOK.Location = new System.Drawing.Point(224, 278);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 16;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.Location = new System.Drawing.Point(312, 278);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 17;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(16, 168);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(79, 17);
			label8.TabIndex = 9;
			label8.Text = "所属组别(&G):";
			label8.Visible = false;
			txtGroup.Location = new System.Drawing.Point(96, 166);
			txtGroup.Name = "txtGroup";
			txtGroup.Size = new System.Drawing.Size(288, 21);
			txtGroup.TabIndex = 10;
			txtGroup.Text = "";
			txtGroup.Visible = false;
			groupBox1.Controls.Add(chkYesNo);
			groupBox1.Controls.Add(chkPrepAppend);
			groupBox1.Controls.Add(chkInputBox);
			groupBox1.Controls.Add(chkAfterAppend);
			groupBox1.Location = new System.Drawing.Point(16, 198);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(368, 72);
			groupBox1.TabIndex = 11;
			groupBox1.TabStop = false;
			groupBox1.Text = "属性";
			chkYesNo.Location = new System.Drawing.Point(8, 40);
			chkYesNo.Name = "chkYesNo";
			chkYesNo.Size = new System.Drawing.Size(120, 24);
			chkYesNo.TabIndex = 14;
			chkYesNo.Text = "症状类型  (&Y)";
			chkPrepAppend.Location = new System.Drawing.Point(168, 16);
			chkPrepAppend.Name = "chkPrepAppend";
			chkPrepAppend.Size = new System.Drawing.Size(176, 24);
			chkPrepAppend.TabIndex = 13;
			chkPrepAppend.Text = "前面插入知识点名称(&P)";
			chkInputBox.Location = new System.Drawing.Point(8, 16);
			chkInputBox.Name = "chkInputBox";
			chkInputBox.Size = new System.Drawing.Size(120, 24);
			chkInputBox.TabIndex = 12;
			chkInputBox.Text = "文本框类型(&I)";
			chkAfterAppend.Location = new System.Drawing.Point(168, 40);
			chkAfterAppend.Name = "chkAfterAppend";
			chkAfterAppend.Size = new System.Drawing.Size(176, 24);
			chkAfterAppend.TabIndex = 15;
			chkAfterAppend.Text = "后面插入知识点名称(&A)";
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(418, 311);
			base.Controls.Add(groupBox1);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(txtParent);
			base.Controls.Add(label3);
			base.Controls.Add(txtName);
			base.Controls.Add(label4);
			base.Controls.Add(txtDesc);
			base.Controls.Add(txtListSQL);
			base.Controls.Add(label5);
			base.Controls.Add(label8);
			base.Controls.Add(txtGroup);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgKB_List";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "知识点属性";
			base.Load += new System.EventHandler(dlgKB_List_Load);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void dlgKB_List_Load(object sender, EventArgs e)
		{
			if (OwnerList != null)
			{
				txtID.Text = OwnerList.SEQ;
				txtParent.Text = ((OwnerList.Parent == null) ? OwnerList.ParentSEQ : (OwnerList.Parent.Name + " (编号" + OwnerList.ParentSEQ + ")"));
				txtName.Text = OwnerList.Name;
				txtDesc.Text = OwnerList.Desc;
				txtListSQL.Text = OwnerList.ListSQL;
				txtGroup.Text = OwnerList.KBGroup;
				chkInputBox.Checked = OwnerList.InputBoxAttribute;
				chkAfterAppend.Checked = OwnerList.AfterAppendNameAttribute;
				chkPrepAppend.Checked = OwnerList.PreAppendNameAttribute;
				chkYesNo.Checked = OwnerList.YesNoAttribute;
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (OwnerList != null)
			{
				OwnerList.Name = txtName.Text;
				OwnerList.Desc = txtDesc.Text;
				OwnerList.ListSQL = txtListSQL.Text;
				OwnerList.InputBoxAttribute = chkInputBox.Checked;
				OwnerList.AfterAppendNameAttribute = chkAfterAppend.Checked;
				OwnerList.PreAppendNameAttribute = chkPrepAppend.Checked;
				OwnerList.YesNoAttribute = chkYesNo.Checked;
				OwnerList.KBGroup = txtGroup.Text;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
