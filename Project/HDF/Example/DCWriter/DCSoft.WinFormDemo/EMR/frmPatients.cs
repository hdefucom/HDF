using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.EMR
{
    public partial class frmPatients :Form 
    {
        public frmPatients()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private Model.EMR_Patients _PatientsInstance = null;

        public Model.EMR_Patients PatientsInstance
        {
            get
            {
                return _PatientsInstance; 
            }
            set
            {
                _PatientsInstance = value; 
            }
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            myWriterControl.DocumentOptions.ViewOptions.ShowParagraphFlag = false;
            myWriterControl.DocumentOptions.ViewOptions.ShowFormButton = true;
            myWriterControl.DocumentOptions.BehaviorOptions.RaiseQueryListItemsWhenUserEditText = true;
            myWriterControl.QueryListItems += new QueryListItemsEventHandler(myWriterControl_QueryListItems);
            myWriterControl.CommandControler = writerCommandControler1;
            writerCommandControler1.Start();
            //// 设置列表相同提供者
            //myWriterControl.AppHost.Services.AddService(
            //    typeof(DCSoft.Writer.Data.IListItemsProvider),
            //    new MyListItemsProvider());
            // 加载知识库
            string fileName = System.IO.Path.Combine(Application.StartupPath, "kblibrary");
            if (System.IO.File.Exists(fileName))
            {
                 KBLibrary lib = ( KBLibrary ) myWriterControl.ExecuteCommand("LoadKBLibrary", false, fileName);
            }
          
            // 加载模板
            fileName = System.IO.Path.Combine(
                Application.StartupPath, 
                "EMR\\TemplateDocument\\InpatientInfo.xml");

            //XTextDocument doc = new XTextDocument();
            //doc.Load(fileName, null);
            //doc.Parameters.SetValue("EMR_Patients", this.PatientsInstance);
            //int result = doc.FillDataSource( true );

            //myWriterControl.Document = doc;
            //myWriterControl.RefreshDocument();
            //return;

            myWriterControl.LoadDocument( fileName , "xml" );
            // 设置参数
            myWriterControl.SetDocumentParameterValue("EMR_Patients", this.PatientsInstance);
            //myWriterControl.SetDocumentParameterEnabled("EMR_Patients", false);
            myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();// .ExecuteCommand("UpdateViewForDataSource", false, null);
            this.Text = this.Text + "模板:" + fileName;
            // 绑定用户修改文档内容事件
            myWriterControl.DocumentContentChanged +=new WriterEventHandler(myWriterControl_DocumentContentChanged);
            RefreshView();
        }

        void myWriterControl_QueryListItems(object eventSender, QueryListItemsEventArgs args)
        {
            Utils.QueryListItems(args);
        }

        

        private void btnOK_Click(object sender, EventArgs e)
        {
            int result = ( int ) myWriterControl.UpdateDataSourceForView();// .ExecuteCommand("UpdateDataSourceForView", false, null);
            // 这个 result 值就是用户修改的数据点个数
            if (result > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("数据未发生改变!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void myWriterControl_DocumentContentChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            if (this.Text.StartsWith("*") == false)
            {
                this.Text = "*" + this.Text;
            }
        }


        private void RefreshView()
        {
            MytabControl.SelectedIndex = 0;
           // string path = System.IO.Path.Combine("../WinFormDemo", "EMR");
            string path = System.IO.Path.Combine(Application.StartupPath, "EMR");
            string soucePath = System.IO.Path.Combine(path, "frmPatients" + ".cs");
            string sourceCode = null;
            if (System.IO.File.Exists(soucePath))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(soucePath, Encoding.Default, true))
                {
                    sourceCode = reader.ReadToEnd();
                    if (sourceCode != null)
                    {
                        sourceCode = sourceCode.Replace("\t", "    ");
                    }
                }

                XtractPro.Text.CSharpSyntaxHighlighter hi =
                new XtractPro.Text.CSharpSyntaxHighlighter();
                hi.ShowCollapsibleBlocks = false;
                hi.ShowComments = true;
                hi.ShowHyperlinks = true;
                hi.ShowLineNumbers = true;
                hi.ShowRtf = true;
                hi.AddCssSourceCode = true;
                sourceCode = hi.Process(sourceCode);

            }
            else
            {
                sourceCode = " can not find file" + soucePath;
            }
            this.Cursor = Cursors.WaitCursor;
            myWebBrowser.DocumentText = "<html><body leftmargin=0 topmargin=0>" + sourceCode + "</body></html>";
            this.Cursor = Cursors.Default;
        }
         
    }
}
