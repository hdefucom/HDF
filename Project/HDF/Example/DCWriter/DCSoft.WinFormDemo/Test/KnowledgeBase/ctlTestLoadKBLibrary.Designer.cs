﻿namespace DCSoft.Writer.WinFormDemo.Test.KnowledgeBase
{
    partial class ctlTestLoadKBLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestLoadKBLibrary));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLoadKBLibraryInstance = new System.Windows.Forms.ToolStripButton();
            this.btnLoadFile = new System.Windows.Forms.ToolStripButton();
            this.btnLoadStream = new System.Windows.Forms.ToolStripButton();
            this.btnLoadTextReader = new System.Windows.Forms.ToolStripButton();
            this.btnCreateInstance = new System.Windows.Forms.ToolStripButton();
            this.btnLoadURL = new System.Windows.Forms.ToolStripButton();
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripSeparator3,
            this.btnLoadKBLibraryInstance,
            this.btnLoadFile,
            this.btnLoadStream,
            this.btnLoadTextReader,
            this.btnCreateInstance,
            this.btnLoadURL});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // toolStripButton1
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton1, "FileNew");
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton2, "FileOpen");
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButton3
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton3, "Undo");
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton4, "Redo");
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButton5
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton5, "Cut");
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton6, "Copy");
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.Name = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.writerCommandControler1.SetCommandName(this.toolStripButton7, "Paste");
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            this.toolStripButton7.Name = "toolStripButton7";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // btnLoadKBLibraryInstance
            // 
            this.btnLoadKBLibraryInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnLoadKBLibraryInstance, "btnLoadKBLibraryInstance");
            this.btnLoadKBLibraryInstance.Name = "btnLoadKBLibraryInstance";
            this.btnLoadKBLibraryInstance.Click += new System.EventHandler(this.btnLoadKBLibraryInstance_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnLoadFile, "btnLoadFile");
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnLoadStream
            // 
            this.btnLoadStream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnLoadStream, "btnLoadStream");
            this.btnLoadStream.Name = "btnLoadStream";
            this.btnLoadStream.Click += new System.EventHandler(this.btnLoadStream_Click);
            // 
            // btnLoadTextReader
            // 
            this.btnLoadTextReader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnLoadTextReader, "btnLoadTextReader");
            this.btnLoadTextReader.Name = "btnLoadTextReader";
            this.btnLoadTextReader.Click += new System.EventHandler(this.btnLoadTextReader_Click);
            // 
            // btnCreateInstance
            // 
            this.btnCreateInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnCreateInstance, "btnCreateInstance");
            this.btnCreateInstance.Name = "btnCreateInstance";
            this.btnCreateInstance.Click += new System.EventHandler(this.btnCreateInstance_Click);
            // 
            // btnLoadURL
            // 
            this.btnLoadURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnLoadURL, "btnLoadURL");
            this.btnLoadURL.Name = "btnLoadURL";
            this.btnLoadURL.Click += new System.EventHandler(this.btnLoadURL_Click);
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Silver;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myWriterControl, "myWriterControl");
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            // 
            // ctlTestLoadKBLibrary
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestLoadKBLibrary";
            this.Load += new System.EventHandler(this.frmTestLoadKBLibrary_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStripButton btnLoadKBLibraryInstance;
        private System.Windows.Forms.ToolStripButton btnLoadFile;
        private System.Windows.Forms.ToolStripButton btnLoadStream;
        private System.Windows.Forms.ToolStripButton btnLoadTextReader;
        private System.Windows.Forms.ToolStripButton btnCreateInstance;
        private System.Windows.Forms.ToolStripButton btnLoadURL;
    }
}