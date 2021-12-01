using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class dlgKB_Item : Form
	{
		private Label label1;

		private TextBox txtSEQ;

		private Label label2;

		private TextBox txtText;

		private Label label3;

		private Label label4;

		private Button cmdOK;

		private Button cmdCancel;

		private ListBox lstStyle;

		private DBComboBox cboTemplate;

		private TextBox txtValue;

		private Container components = null;

		public KB_Item OwnerItem = null;

		public dlgKB_Item()
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
			txtSEQ = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			cboTemplate = new ZYCommon.DBComboBox();
			label4 = new System.Windows.Forms.Label();
			lstStyle = new System.Windows.Forms.ListBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			txtValue = new System.Windows.Forms.TextBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(35, 17);
			label1.TabIndex = 0;
			label1.Text = "编号:";
			txtSEQ.Location = new System.Drawing.Point(64, 16);
			txtSEQ.Name = "txtSEQ";
			txtSEQ.ReadOnly = true;
			txtSEQ.Size = new System.Drawing.Size(296, 21);
			txtSEQ.TabIndex = 100;
			txtSEQ.Text = "";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(16, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(35, 17);
			label2.TabIndex = 0;
			label2.Text = "文本:";
			txtText.Location = new System.Drawing.Point(64, 48);
			txtText.Name = "txtText";
			txtText.Size = new System.Drawing.Size(296, 21);
			txtText.TabIndex = 1;
			txtText.Text = "";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(16, 80);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(23, 17);
			label3.TabIndex = 0;
			label3.Text = "值:";
			cboTemplate.AutoLoad = true;
			cboTemplate.Connection = null;
			cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboTemplate.Location = new System.Drawing.Point(64, 80);
			cboTemplate.MaxDropDownItems = 10;
			cboTemplate.Name = "cboTemplate";
			cboTemplate.SelectedValue = null;
			cboTemplate.Size = new System.Drawing.Size(296, 20);
			cboTemplate.SQL = null;
			cboTemplate.TabIndex = 2;
			cboTemplate.Visible = false;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(16, 112);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(35, 17);
			label4.TabIndex = 2;
			label4.Text = "类型:";
			lstStyle.ItemHeight = 12;
			lstStyle.Location = new System.Drawing.Point(64, 112);
			lstStyle.Name = "lstStyle";
			lstStyle.Size = new System.Drawing.Size(296, 148);
			lstStyle.TabIndex = 4;
			lstStyle.SelectedIndexChanged += new System.EventHandler(lstStyle_SelectedIndexChanged);
			cmdOK.Location = new System.Drawing.Point(232, 272);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 5;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(320, 272);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 6;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			txtValue.Location = new System.Drawing.Point(64, 80);
			txtValue.Name = "txtValue";
			txtValue.ReadOnly = true;
			txtValue.Size = new System.Drawing.Size(296, 21);
			txtValue.TabIndex = 3;
			txtValue.Text = "";
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(418, 303);
			base.Controls.Add(txtValue);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(lstStyle);
			base.Controls.Add(label4);
			base.Controls.Add(txtSEQ);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(txtText);
			base.Controls.Add(label3);
			base.Controls.Add(cboTemplate);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgKB_Item";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "列表项目";
			base.Load += new System.EventHandler(dlgKB_Item_Load);
			ResumeLayout(false);
		}

		private void dlgKB_Item_Load(object sender, EventArgs e)
		{
			string[] kBItemStyleDescList = KB_Item.GetKBItemStyleDescList();
			lstStyle.Items.AddRange(kBItemStyleDescList);
			if (OwnerItem != null)
			{
				txtSEQ.Text = OwnerItem.ItemSEQ.ToString();
				txtText.Text = OwnerItem.ItemText;
				txtValue.Text = OwnerItem.ItemValue;
				lstStyle.SelectedIndex = KB_Item.KBItemStyleToIndex(OwnerItem.ItemStyle);
				if (OwnerItem.isTemplate())
				{
					cboTemplate.SelectedValue = OwnerItem.ItemValue;
				}
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (OwnerItem != null)
			{
				OwnerItem.ItemText = txtText.Text;
				OwnerItem.ItemValue = (txtValue.Visible ? txtText.Text : cboTemplate.SelectedValue);
				OwnerItem.ItemStyle = KB_Item.IndexToKBItemStyle(lstStyle.SelectedIndex);
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lstStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			cboTemplate.Visible = (KB_Item.IndexToKBItemStyle(lstStyle.SelectedIndex) == 100);
			txtValue.Visible = !cboTemplate.Visible;
		}
	}
}
