using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.TemperatureChart;

namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    public partial class frmCustomDesigner : Form
    {
        public frmCustomDesigner()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.myDesignerControl.EventOKButtonClick += new EventHandler(myDesignerControl_EventOKButtonClick);
            this.myDesignerControl.EventCancelButtonClick += new EventHandler(myDesignerControl_EventCancelButtonClick);
        }

        void myDesignerControl_EventCancelButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        void myDesignerControl_EventOKButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public TemperatureDocument SourceDocument
        {
            get
            {
                return this.myDesignerControl.SourceDocument;
            }
            set
            {
                this.myDesignerControl.SourceDocument = value;
            }
        }

    }
}
