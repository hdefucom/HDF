namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    partial class ctlTestGlobalEventTemplate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestGlobalEventTemplate));
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.eetCell = new DCSoft.Writer.ElementEventTemplate();
            this.eetField = new DCSoft.Writer.ElementEventTemplate();
            this.eetImage = new DCSoft.Writer.ElementEventTemplate();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnClearField = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myWriterControl, "myWriterControl");
            this.myWriterControl.GlobalEventTemplate_Cell = this.eetCell;
            this.myWriterControl.GlobalEventTemplate_Field = this.eetField;
            this.myWriterControl.GlobalEventTemplate_Image = this.eetImage;
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            // 
            // eetCell
            // 
            this.eetCell.Name = "eetCell";
            this.eetCell.ContentChanged += new DCSoft.Writer.ContentChangedEventHandler(this.eetCell_ContentChanged);
            this.eetCell.MouseEnter += new DCSoft.Writer.ElementEventHandler(this.eetCell_MouseEnter);
            this.eetCell.MouseLeave += new DCSoft.Writer.ElementEventHandler(this.eetCell_MouseLeave);
            // 
            // eetField
            // 
            this.eetField.Name = "eetField";
            this.eetField.ContentChanged += new DCSoft.Writer.ContentChangedEventHandler(this.eetField_ContentChanged);
            this.eetField.ContentChanging += new DCSoft.Writer.ContentChangingEventHandler(this.eetField_ContentChanging);
            this.eetField.GotFocus += new DCSoft.Writer.ElementEventHandler(this.eetField_GotFocus);
            this.eetField.LostFocus += new DCSoft.Writer.ElementEventHandler(this.eetField_LostFocus);
            // 
            // eetImage
            // 
            this.eetImage.Name = "eetImage";
            this.eetImage.MouseDblClick += new DCSoft.Writer.ElementMouseEventHandler(this.eetImage_MouseDblClick);
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtLog
            // 
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.Name = "txtLog";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.btnClearField});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButton1
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton1, "InsertImage");
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // btnClearField
            // 
            this.btnClearField.CheckOnClick = true;
            this.btnClearField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnClearField, "btnClearField");
            this.btnClearField.Name = "btnClearField";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // ctlTestGlobalEventTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestGlobalEventTemplate";
            this.Load += new System.EventHandler(this.frmTestGlobalEventTemplate_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.TextBox txtLog;
        private ElementEventTemplate eetField;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Splitter splitter1;
        private ElementEventTemplate eetCell;
        private ElementEventTemplate eetImage;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnClearField;
    }
}