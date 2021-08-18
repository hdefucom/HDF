
namespace WindowsFormsApp2
{
    partial class Form10
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.panel_info = new System.Windows.Forms.Panel();
            this.gCardListControl1 = new GHIS.Ctrl.GCardListControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 47);
            this.panel1.TabIndex = 2;
            // 
            // panel_info
            // 
            this.panel_info.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_info.Location = new System.Drawing.Point(395, 58);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(160, 158);
            this.panel_info.TabIndex = 0;
            this.panel_info.Visible = false;
            // 
            // gCardListControl1
            // 
            this.gCardListControl1.CardSelectionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.gCardListControl1.CardSize = new System.Drawing.Size(200, 200);
            this.gCardListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCardListControl1.Location = new System.Drawing.Point(0, 47);
            this.gCardListControl1.Name = "gCardListControl1";
            this.gCardListControl1.Size = new System.Drawing.Size(800, 403);
            this.gCardListControl1.TabIndex = 3;
            this.gCardListControl1.Text = "gCardListControl1";
            this.gCardListControl1.CardMouseLeave += new System.Action<GHIS.Ctrl.GCardListControl.Card, System.EventArgs>(this.gCardListControl1_CardMouseLeave);
            this.gCardListControl1.CardMouseHover += new System.Action<GHIS.Ctrl.GCardListControl.Card, System.EventArgs>(this.gCardListControl1_CardMouseHover);
            this.gCardListControl1.CardPaint += new System.Action<GHIS.Ctrl.GCardListControl.Card, System.Windows.Forms.PaintEventArgs>(this.cardListControl2_CardPaint);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_info);
            this.Controls.Add(this.gCardListControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.Name = "Form10";
            this.Text = "Form10";
            this.Load += new System.EventHandler(this.Form10_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form10_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form10_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private GHIS.Ctrl.GCardListControl gCardListControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel_info;
    }
}