using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestFileFormat : UserControl
    {
        public ctlTestFileFormat()
        {
            InitializeComponent();
        }

        private void btnOpenOldXML1_Click(object sender, EventArgs e)
        {
            string resName = "DCSoft.Writer.WinFormDemo.Test.OldXML.xml";
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resName);
            if (stream != null)
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                myWriterControl.LoadDocument(reader, "OldXml");
                reader.Close();
            }
        }
    }
}
