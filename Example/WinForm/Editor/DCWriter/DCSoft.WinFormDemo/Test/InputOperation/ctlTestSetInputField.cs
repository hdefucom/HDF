using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestSetInputField : UserControl
    {
        public ctlTestSetInputField()
        {
            InitializeComponent();
        }

        private void frmTestSetInputField_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }


        private XTextInputFieldElement GetCurrentField()
        {
            XTextInputFieldElement field = (XTextInputFieldElement)myWriterControl.GetCurrentElement(typeof(XTextInputFieldElement));
            if (field == null)
            {
                MessageBox.Show("请将光标放在一个文本输入域中");
            }
            return field;
        }

        private void btnSetFieldValue_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = GetCurrentField();
            if (field != null)
            {
                field.EditorText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }


        private void btnSetFieldValueExt_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = GetCurrentField();
            if (field != null)
            {
                field.EditorTextExt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void btnSetMulLineText_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = GetCurrentField();
            if (field != null)
            {
                field.EditorText = "张三\r\n李四\r\n王五";
                //field.EditorRefreshView();
            }
        }

        private void btnSetInputFieldProperty_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = GetCurrentField();
            if (field != null)
            {
                using (dlgMyInputFieldEditor dlg = new dlgMyInputFieldEditor())
                {
                    dlg.InputFieldElement = field;
                    dlg.ShowDialog(this);
                }
            }
        }

        private void btnSetFieldBackColor_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = GetCurrentField();
            if (field != null)
            {
                using (ColorDialog dlg = new ColorDialog())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        Color c = dlg.Color;
                        c = Color.Transparent;
                        DocumentContentStyle style = new DocumentContentStyle();
                        style.DisableDefaultValue = true;
                        style.BackgroundColor = c;
                        field.EditorSetContentStyle(style, false );
                        field.Style.BackgroundColor = c;
                        field.InvalidateView();
                    }
                }
            }

        }

        private void btnImportDocument_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = GetCurrentField();
            if (field != null)
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "*.xml|*.xml";
                    dlg.CheckFileExists = true;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        string fileName = dlg.FileName;
                        XTextDocument document = new XTextDocument();
                        document.Load(fileName, null);
                        if (field.ContentBuilder.AppendDocumentContent(
                            document,
                            true,
                            true,
                            true,
                            true ) > 0)
                        {
                            field.EditorRefreshView();
                        }
                    }
                }
            }
        }
    }
}
