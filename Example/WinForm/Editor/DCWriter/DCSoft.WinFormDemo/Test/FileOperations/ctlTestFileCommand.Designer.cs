namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    partial class ctlTestFileCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlTestFileCommand));
            this.myWriterControl = new DCSoft.Writer.Controls.WriterControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.btnOpenSpecifyFile = new System.Windows.Forms.ToolStripButton();
            this.btnOpenStream = new System.Windows.Forms.ToolStripButton();
            this.btnOpenTextReader = new System.Windows.Forms.ToolStripButton();
            this.btnOpenFormat = new System.Windows.Forms.ToolStripButton();
            this.btnOpenRTFStream = new System.Windows.Forms.ToolStripButton();
            this.btnOpenHtml = new System.Windows.Forms.ToolStripButton();
            this.btnOpenURL = new System.Windows.Forms.ToolStripButton();
            this.btnOpenTextReaderDir = new System.Windows.Forms.ToolStripButton();
            this.btnOpen2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnViewSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveSpecifyFile = new System.Windows.Forms.ToolStripButton();
            this.btnSaveStream = new System.Windows.Forms.ToolStripButton();
            this.btnSaveWriter = new System.Windows.Forms.ToolStripButton();
            this.btnSaveRTF = new System.Windows.Forms.ToolStripButton();
            this.btnSaveRTFStream = new System.Windows.Forms.ToolStripButton();
            this.btnSaveHtml = new System.Windows.Forms.ToolStripButton();
            this.btnSaveSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnFilePrintPreview = new System.Windows.Forms.ToolStripButton();
            this.btnPageIndexFix = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnFilePrintWidthManualDuplex = new System.Windows.Forms.ToolStripButton();
            this.btnPrintJiShu = new System.Windows.Forms.ToolStripButton();
            this.btnSetJumpPosition = new System.Windows.Forms.ToolStripButton();
            this.btnCancelJumpPrint = new System.Windows.Forms.ToolStripButton();
            this.btnSavePageImage = new System.Windows.Forms.ToolStripButton();
            this.btnSavePDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.writerCommandControler1 = new DCSoft.Writer.Commands.WriterCommandControler(this.components);
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).BeginInit();
            this.SuspendLayout();
            // 
            // myWriterControl
            // 
            this.myWriterControl.BackColor = System.Drawing.Color.Gray;
            this.myWriterControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.myWriterControl, "myWriterControl");
            this.myWriterControl.Name = "myWriterControl";
            this.myWriterControl.RuleVisible = true;
            this.myWriterControl.StatusTextChanged += new DCSoft.Writer.Controls.StatusTextChangedEventHandler(this.myWriterControl_StatusTextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.toolStripSeparator1,
            this.btnOpenFile,
            this.btnOpenSpecifyFile,
            this.btnOpenStream,
            this.btnOpenTextReader,
            this.btnOpenFormat,
            this.btnOpenRTFStream,
            this.btnOpenHtml,
            this.btnOpenURL,
            this.btnOpenTextReaderDir,
            this.btnOpen2});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenFile, "btnOpenFile");
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnOpenSpecifyFile
            // 
            this.btnOpenSpecifyFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenSpecifyFile, "btnOpenSpecifyFile");
            this.btnOpenSpecifyFile.Name = "btnOpenSpecifyFile";
            this.btnOpenSpecifyFile.Click += new System.EventHandler(this.btnOpenSpecifyFile_Click);
            // 
            // btnOpenStream
            // 
            this.btnOpenStream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenStream, "btnOpenStream");
            this.btnOpenStream.Name = "btnOpenStream";
            this.btnOpenStream.Click += new System.EventHandler(this.btnOpenStream_Click);
            // 
            // btnOpenTextReader
            // 
            this.btnOpenTextReader.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenTextReader, "btnOpenTextReader");
            this.btnOpenTextReader.Name = "btnOpenTextReader";
            this.btnOpenTextReader.Click += new System.EventHandler(this.btnOpenTextReader_Click);
            // 
            // btnOpenFormat
            // 
            this.btnOpenFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenFormat, "btnOpenFormat");
            this.btnOpenFormat.Name = "btnOpenFormat";
            this.btnOpenFormat.Click += new System.EventHandler(this.btnOpenRTF_Click);
            // 
            // btnOpenRTFStream
            // 
            this.btnOpenRTFStream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenRTFStream, "btnOpenRTFStream");
            this.btnOpenRTFStream.Name = "btnOpenRTFStream";
            this.btnOpenRTFStream.Click += new System.EventHandler(this.btnOpenRTFStream_Click);
            // 
            // btnOpenHtml
            // 
            this.btnOpenHtml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenHtml, "btnOpenHtml");
            this.btnOpenHtml.Name = "btnOpenHtml";
            this.btnOpenHtml.Click += new System.EventHandler(this.btnOpenHtml_Click);
            // 
            // btnOpenURL
            // 
            this.btnOpenURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenURL, "btnOpenURL");
            this.btnOpenURL.Name = "btnOpenURL";
            this.btnOpenURL.Click += new System.EventHandler(this.btnOpenURL_Click);
            // 
            // btnOpenTextReaderDir
            // 
            this.btnOpenTextReaderDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpenTextReaderDir, "btnOpenTextReaderDir");
            this.btnOpenTextReaderDir.Name = "btnOpenTextReaderDir";
            this.btnOpenTextReaderDir.Click += new System.EventHandler(this.btnOpenTextReaderDir_Click);
            // 
            // btnOpen2
            // 
            this.btnOpen2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnOpen2, "btnOpen2");
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewSource,
            this.toolStripSeparator2,
            this.btnSave,
            this.btnSaveSpecifyFile,
            this.btnSaveStream,
            this.btnSaveWriter,
            this.btnSaveRTF,
            this.btnSaveRTFStream,
            this.btnSaveHtml,
            this.btnSaveSelection,
            this.toolStripSeparator3,
            this.btnPrint,
            this.btnFilePrintPreview,
            this.btnPageIndexFix,
            this.toolStripButton1,
            this.btnFilePrintWidthManualDuplex,
            this.btnPrintJiShu,
            this.btnSetJumpPosition,
            this.btnCancelJumpPrint,
            this.btnSavePageImage,
            this.btnSavePDF,
            this.toolStripButton2});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.ShowItemToolTips = false;
            // 
            // btnViewSource
            // 
            this.btnViewSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnViewSource, "btnViewSource");
            this.btnViewSource.Name = "btnViewSource";
            this.btnViewSource.Click += new System.EventHandler(this.btnViewSource_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveSpecifyFile
            // 
            this.btnSaveSpecifyFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSaveSpecifyFile, "btnSaveSpecifyFile");
            this.btnSaveSpecifyFile.Name = "btnSaveSpecifyFile";
            this.btnSaveSpecifyFile.Click += new System.EventHandler(this.btnSaveSpecifyFile_Click);
            // 
            // btnSaveStream
            // 
            this.btnSaveStream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSaveStream, "btnSaveStream");
            this.btnSaveStream.Name = "btnSaveStream";
            this.btnSaveStream.Click += new System.EventHandler(this.btnSaveStream_Click);
            // 
            // btnSaveWriter
            // 
            this.btnSaveWriter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSaveWriter, "btnSaveWriter");
            this.btnSaveWriter.Name = "btnSaveWriter";
            this.btnSaveWriter.Click += new System.EventHandler(this.btnSaveWriter_Click);
            // 
            // btnSaveRTF
            // 
            this.btnSaveRTF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSaveRTF, "btnSaveRTF");
            this.btnSaveRTF.Name = "btnSaveRTF";
            this.btnSaveRTF.Click += new System.EventHandler(this.btnSaveRTF_Click);
            // 
            // btnSaveRTFStream
            // 
            this.btnSaveRTFStream.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSaveRTFStream, "btnSaveRTFStream");
            this.btnSaveRTFStream.Name = "btnSaveRTFStream";
            this.btnSaveRTFStream.Click += new System.EventHandler(this.btnSaveRTFStream_Click);
            // 
            // btnSaveHtml
            // 
            this.btnSaveHtml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSaveHtml, "btnSaveHtml");
            this.btnSaveHtml.Name = "btnSaveHtml";
            this.btnSaveHtml.Click += new System.EventHandler(this.btnSaveHtml_Click);
            // 
            // btnSaveSelection
            // 
            this.btnSaveSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSaveSelection, "btnSaveSelection");
            this.btnSaveSelection.Name = "btnSaveSelection";
            this.btnSaveSelection.Click += new System.EventHandler(this.btnSaveSelection_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnFilePrintPreview
            // 
            this.btnFilePrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnFilePrintPreview, "btnFilePrintPreview");
            this.btnFilePrintPreview.Name = "btnFilePrintPreview";
            this.btnFilePrintPreview.Click += new System.EventHandler(this.btnFilePrintPreview_Click);
            // 
            // btnPageIndexFix
            // 
            this.btnPageIndexFix.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnPageIndexFix, "btnPageIndexFix");
            this.btnPageIndexFix.Name = "btnPageIndexFix";
            this.btnPageIndexFix.Click += new System.EventHandler(this.btnPageIndexFix_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnFilePrintWidthManualDuplex
            // 
            this.btnFilePrintWidthManualDuplex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnFilePrintWidthManualDuplex, "btnFilePrintWidthManualDuplex");
            this.btnFilePrintWidthManualDuplex.Name = "btnFilePrintWidthManualDuplex";
            this.btnFilePrintWidthManualDuplex.Click += new System.EventHandler(this.btnFilePrintWidthManualDuplex_Click);
            // 
            // btnPrintJiShu
            // 
            this.btnPrintJiShu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnPrintJiShu, "btnPrintJiShu");
            this.btnPrintJiShu.Name = "btnPrintJiShu";
            this.btnPrintJiShu.Click += new System.EventHandler(this.btnPrintJiShu_Click);
            // 
            // btnSetJumpPosition
            // 
            this.btnSetJumpPosition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSetJumpPosition, "btnSetJumpPosition");
            this.btnSetJumpPosition.Name = "btnSetJumpPosition";
            this.btnSetJumpPosition.Click += new System.EventHandler(this.btnSetJumpPosition_Click);
            // 
            // btnCancelJumpPrint
            // 
            this.btnCancelJumpPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnCancelJumpPrint, "btnCancelJumpPrint");
            this.btnCancelJumpPrint.Name = "btnCancelJumpPrint";
            this.btnCancelJumpPrint.Click += new System.EventHandler(this.btnCancelJumpPrint_Click);
            // 
            // btnSavePageImage
            // 
            this.btnSavePageImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSavePageImage, "btnSavePageImage");
            this.btnSavePageImage.Name = "btnSavePageImage";
            this.btnSavePageImage.Click += new System.EventHandler(this.btnSavePageImage_Click);
            // 
            // btnSavePDF
            // 
            this.btnSavePDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnSavePDF, "btnSavePDF");
            this.btnSavePDF.Name = "btnSavePDF";
            this.btnSavePDF.Click += new System.EventHandler(this.btnSavePDF_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // ctlTestFileCommand
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myWriterControl);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ctlTestFileCommand";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writerCommandControler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpenFile;
        private Controls.WriterControl myWriterControl;
        private System.Windows.Forms.ToolStripButton btnOpenSpecifyFile;
        private System.Windows.Forms.ToolStripButton btnOpenStream;
        private System.Windows.Forms.ToolStripButton btnOpenTextReader;
        private System.Windows.Forms.ToolStripButton btnOpenFormat;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpenRTFStream;
        private System.Windows.Forms.ToolStripButton btnOpenHtml;
        private System.Windows.Forms.ToolStripButton btnOpenURL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveSpecifyFile;
        private System.Windows.Forms.ToolStripButton btnSaveStream;
        private System.Windows.Forms.ToolStripButton btnSaveWriter;
        private System.Windows.Forms.ToolStripButton btnSaveRTF;
        private System.Windows.Forms.ToolStripButton btnSaveRTFStream;
        private System.Windows.Forms.ToolStripButton btnSaveHtml;
        private System.Windows.Forms.ToolStripButton btnViewSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnOpenTextReaderDir;
        private System.Windows.Forms.ToolStripButton btnSaveSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnOpen2;
        private System.Windows.Forms.ToolStripButton btnFilePrintPreview;
        private System.Windows.Forms.ToolStripButton btnPageIndexFix;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnFilePrintWidthManualDuplex;
        private System.Windows.Forms.ToolStripButton btnPrintJiShu;
        private Commands.WriterCommandControler writerCommandControler1;
        private System.Windows.Forms.ToolStripButton btnSetJumpPosition;
        private System.Windows.Forms.ToolStripButton btnCancelJumpPrint;
        private System.Windows.Forms.ToolStripButton btnSavePageImage;
        private System.Windows.Forms.ToolStripButton btnSavePDF;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}