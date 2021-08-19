namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    partial class frmCustomDesigner
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
            this.label1 = new System.Windows.Forms.Label();
            this.myDesignerControl = new DCSoft.TemperatureChart.TimeLineDesignerControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(726, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "本窗体演示使用都昌时间轴包含的时间轴样式设计器控件。该控件类型全名为DCSoft.TemperatureChartTimeLineDesignerControl。" +
                "";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // myDesignerControl
            // 
            this.myDesignerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDesignerControl.Location = new System.Drawing.Point(0, 43);
            this.myDesignerControl.Name = "myDesignerControl";
            this.myDesignerControl.Size = new System.Drawing.Size(726, 350);
            this.myDesignerControl.TabIndex = 1;
            // 
            // frmCustomDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 393);
            this.Controls.Add(this.myDesignerControl);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "frmCustomDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义的时间轴设计器";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TemperatureChart.TimeLineDesignerControl myDesignerControl;
    }
}