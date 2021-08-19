using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestDateTimeService : UserControl
    {
        public ctlTestDateTimeService()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode == false)
            {
                myWriterControl.CommandControler = this.writerCommandControler1;
                myWriterControl.CommandControler.Start();
            }
        }

        private void btnSetLocalDateTime_Click(object sender, EventArgs e)
        {
            myWriterControl.SynchroServerTime(DateTime.Now);
        }
         
        private void btnOldDateTime_Click(object sender, EventArgs e)
        {
            DateTime dtm = new DateTime(1949, 10, 1, 15, 0, 0);
            myWriterControl.SynchroServerTime(dtm);
        }
    }
}