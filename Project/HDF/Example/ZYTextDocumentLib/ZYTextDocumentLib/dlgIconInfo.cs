using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class dlgIconInfo : Form
	{
		internal Label lblNode;

		internal Label lblKB;

		internal Label label2;

		internal Label label3;

		internal Label label4;

		internal Label label1;

		internal Label lblNormalItem;

		internal Label lblTemplate;

		private Button cmdClose;

		private Container components = null;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		internal Label label5;

		internal Label lblUnit;

		private ImageList myImageList = null;

		public dlgIconInfo()
		{
			InitializeComponent();
			myImageList = ZYKBTreeView.GetKBImageList();
			lblNode.Image = myImageList.Images[10];
			lblKB.Image = myImageList.Images[2];
			lblNormalItem.Image = myImageList.Images[3];
			lblTemplate.Image = myImageList.Images[4];
			lblUnit.Image = myImageList.Images[12];
			Text = "知识库列表图例 版本:" + StringCommon.GetTypeVersion(GetType());
		}

		protected override void Dispose(bool disposing)
		{
			if (myImageList != null)
			{
				myImageList.Dispose();
				myImageList = null;
			}
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			lblNode = new System.Windows.Forms.Label();
			lblKB = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			lblNormalItem = new System.Windows.Forms.Label();
			lblTemplate = new System.Windows.Forms.Label();
			cmdClose = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			lblUnit = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label5 = new System.Windows.Forms.Label();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			lblNode.BackColor = System.Drawing.SystemColors.Window;
			lblNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblNode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblNode.Location = new System.Drawing.Point(8, 16);
			lblNode.Name = "lblNode";
			lblNode.Size = new System.Drawing.Size(168, 20);
			lblNode.TabIndex = 0;
			lblNode.Text = "   带有子节点的知识点";
			lblNode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			lblKB.BackColor = System.Drawing.SystemColors.Window;
			lblKB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblKB.Location = new System.Drawing.Point(8, 41);
			lblKB.Name = "lblKB";
			lblKB.Size = new System.Drawing.Size(168, 20);
			lblKB.TabIndex = 0;
			lblKB.Text = "   带有子项目的知识点";
			lblKB.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			label2.BackColor = System.Drawing.Color.Gold;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			label2.Location = new System.Drawing.Point(8, 16);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(168, 20);
			label2.TabIndex = 0;
			label2.Text = "   新增的记录";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			label3.BackColor = System.Drawing.Color.LightGreen;
			label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			label3.Location = new System.Drawing.Point(8, 41);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(168, 20);
			label3.TabIndex = 0;
			label3.Text = "   修改过的记录";
			label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			label4.BackColor = System.Drawing.Color.Salmon;
			label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			label4.Location = new System.Drawing.Point(8, 66);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(168, 20);
			label4.TabIndex = 0;
			label4.Text = "   标记为删除的记录";
			label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			label1.BackColor = System.Drawing.SystemColors.Window;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			label1.Location = new System.Drawing.Point(8, 91);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(168, 20);
			label1.TabIndex = 0;
			label1.Text = "   未修改或已经保存的记录";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			lblNormalItem.BackColor = System.Drawing.SystemColors.Window;
			lblNormalItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblNormalItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblNormalItem.Location = new System.Drawing.Point(8, 64);
			lblNormalItem.Name = "lblNormalItem";
			lblNormalItem.Size = new System.Drawing.Size(168, 20);
			lblNormalItem.TabIndex = 0;
			lblNormalItem.Text = "   普通列表项目";
			lblNormalItem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			lblTemplate.BackColor = System.Drawing.SystemColors.Window;
			lblTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblTemplate.Location = new System.Drawing.Point(8, 88);
			lblTemplate.Name = "lblTemplate";
			lblTemplate.Size = new System.Drawing.Size(168, 20);
			lblTemplate.TabIndex = 0;
			lblTemplate.Text = "   模板";
			lblTemplate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdClose.Location = new System.Drawing.Point(312, 152);
			cmdClose.Name = "cmdClose";
			cmdClose.TabIndex = 1;
			cmdClose.Text = "关闭(&C)";
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			groupBox1.Controls.Add(lblNormalItem);
			groupBox1.Controls.Add(lblTemplate);
			groupBox1.Controls.Add(lblNode);
			groupBox1.Controls.Add(lblKB);
			groupBox1.Controls.Add(lblUnit);
			groupBox1.Location = new System.Drawing.Point(0, 0);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(192, 144);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "节点图标";
			lblUnit.BackColor = System.Drawing.SystemColors.Window;
			lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblUnit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblUnit.Location = new System.Drawing.Point(8, 112);
			lblUnit.Name = "lblUnit";
			lblUnit.Size = new System.Drawing.Size(168, 20);
			lblUnit.TabIndex = 0;
			lblUnit.Text = "   文本框知识点";
			lblUnit.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(label2);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label5);
			groupBox2.Location = new System.Drawing.Point(200, 0);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(208, 144);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "节点背景色";
			label5.BackColor = System.Drawing.SystemColors.Window;
			label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label5.ForeColor = System.Drawing.Color.Blue;
			label5.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			label5.Location = new System.Drawing.Point(8, 116);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(168, 20);
			label5.TabIndex = 0;
			label5.Text = "   没有子节点或项目的记录";
			label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(410, 183);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(cmdClose);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgIconInfo";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "知识库图例";
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void cmdClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
