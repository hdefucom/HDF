using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    [ToolboxItem(false)]
    public partial class ctlTestMulCourse : UserControl
    {
        public ctlTestMulCourse()
        {
            InitializeComponent();
        }

        private void frmTestMulSection_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "DemoFile");
            myWriterControl.ExecuteCommand("FileOpen", false, path + "\\模板-病程记录.xml");
            string[] fns = Directory.GetFiles(path, "病程记录*.xml");
            if (fns.Length > 0)
            {
                //myWriterControl.Document.Clear();
                List<string> fileNames = new List<string>();
                fileNames.AddRange(fns);
                fileNames.Sort();
                foreach (string fileName in fileNames)
                {
                    XTextDocument document = new XTextDocument();
                    myWriterControl.Document.LoadDocumentInstance(fileName, "xml", document);
                    if( document != null && document.Body.HasContentElement)
                    {
                        XTextSectionElement section = (XTextSectionElement)myWriterControl.Document.CreateElementByType(
                            typeof(XTextSectionElement));
                        section.Attributes = new XAttributeList();
                        section.Attributes.SetValue("FileName", fileName);
                        //section.Elements.Clear();
                        XTextElementList elements = document.Body.Elements.Clone();
                        myWriterControl.Document.ImportElements(elements);
                        //section.Elements.AddRange(elements);
                        //section.FixElements();
                        section.ContentBuilder.AppendRawMode = true;
                        section.ContentBuilder.AppendTextWithStyleString(
                            System.IO.Path.GetFileNameWithoutExtension(fileName), 
                            "Bold:True");
                        section.ContentBuilder.AppendParagraphFlagWithStyleString("Align:left");
                        section.ContentBuilder.AppendRange(elements);
                        section.ContentBuilder.AppendParagraphFlagWithStyleString("Align:left");
                        section.ContentBuilder.AppendTextWithStyleString(
                            "医生:", "Bold:True");
                        if( document.Attributes != null )
                        {
                            section.ContentBuilder.AppendTextWithStyleString(
                                document.Attributes.GetValue("作者"), "Bold:True");
                        }
                        section.ContentBuilder.AppendParagraphFlagWithStyleString("Align:Right");
                        myWriterControl.Document.Body.AppendContentElement( section );
                        myWriterControl.Document.Body.AppendContentElement(new XTextParagraphFlagElement());
                    }
                }//foreach
                myWriterControl.RefreshDocument();
            }
        }
         
        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            XTextSectionElement section = myWriterControl.Document.CurrentSection;
            if (section != null)
            {
                if (section.Attributes != null && section.Attributes.ContainsByName("FileName"))
                {
                    string fileName = section.Attributes.GetValue("FileName");
                    using (frmEditOneDocument frm = new frmEditOneDocument())
                    {
                        frm.FileName = fileName;
                        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            btnRefresh_Click(null, null);
                        }
                    }
                }
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            using (frmEditOneDocument frm = new frmEditOneDocument())
            {
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    btnRefresh_Click(null, null);
                }
            }

        }

    }
}
