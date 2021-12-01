namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    partial class ToothCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtrightDown = new System.Windows.Forms.TextBox();
            this.txtrightup = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtleftDown = new System.Windows.Forms.TextBox();
            this.labelHR = new System.Windows.Forms.Label();
            this.txtLeftUp = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.simpleButtonCancel);
            this.panel1.Controls.Add(this.simpleButtonOK);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtrightDown);
            this.panel1.Controls.Add(this.txtrightup);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtleftDown);
            this.panel1.Controls.Add(this.labelHR);
            this.panel1.Controls.Add(this.txtLeftUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 133);
            this.panel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(78, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 100);
            this.label3.TabIndex = 13;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(162, 73);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(62, 23);
            this.simpleButtonCancel.TabIndex = 12;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(161, 44);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(62, 23);
            this.simpleButtonOK.TabIndex = 11;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(-2, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 1);
            this.label2.TabIndex = 10;
            // 
            // txtrightDown
            // 
            this.txtrightDown.Location = new System.Drawing.Point(87, 90);
            this.txtrightDown.Name = "txtrightDown";
            this.txtrightDown.Size = new System.Drawing.Size(55, 22);
            this.txtrightDown.TabIndex = 4;
            this.txtrightDown.TextChanged += new System.EventHandler(this.txtrightDown_TextChanged);
            // 
            // txtrightup
            // 
            this.txtrightup.Location = new System.Drawing.Point(85, 43);
            this.txtrightup.Name = "txtrightup";
            this.txtrightup.Size = new System.Drawing.Size(55, 22);
            this.txtrightup.TabIndex = 2;
            this.txtrightup.TextChanged += new System.EventHandler(this.txtrightup_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 23);
            this.panel2.TabIndex = 9;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(66, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 14);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "牙齿检查";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前元素：";
            // 
            // txtleftDown
            // 
            this.txtleftDown.Location = new System.Drawing.Point(15, 89);
            this.txtleftDown.Name = "txtleftDown";
            this.txtleftDown.Size = new System.Drawing.Size(55, 22);
            this.txtleftDown.TabIndex = 3;
            this.txtleftDown.TextChanged += new System.EventHandler(this.txtleftDown_TextChanged);
            // 
            // labelHR
            // 
            this.labelHR.BackColor = System.Drawing.Color.Black;
            this.labelHR.Location = new System.Drawing.Point(14, 75);
            this.labelHR.Name = "labelHR";
            this.labelHR.Size = new System.Drawing.Size(130, 1);
            this.labelHR.TabIndex = 1;
            // 
            // txtLeftUp
            // 
            this.txtLeftUp.Location = new System.Drawing.Point(15, 42);
            this.txtLeftUp.Name = "txtLeftUp";
            this.txtLeftUp.Size = new System.Drawing.Size(55, 22);
            this.txtLeftUp.TabIndex = 1;
            this.txtLeftUp.TextChanged += new System.EventHandler(this.txtLeftUp_TextChanged);
            // 
            // ToothCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 133);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToothCheck";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToothCheck";
            this.Deactivate += new System.EventHandler(this.ToothCheck_Deactivate);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtrightDown;
        private System.Windows.Forms.TextBox txtrightup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtleftDown;
        private System.Windows.Forms.Label labelHR;
        private System.Windows.Forms.TextBox txtLeftUp;
    }
}