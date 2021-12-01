using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace YidanSoft.Library.EmrEditor.Src.Document.PropertyElement
{
    public partial class TrackBarControl : UserControl
    {
        public TrackBarControl(IWindowsFormsEditorService e, object v)
        {
            InitializeComponent();
            this.edSvc = e;
            this.Value = (int)v;
        }
        public IWindowsFormsEditorService edSvc;

        public int Value
        {
            get
            {
                return this.trackBar1.Value;
            }
            set
            {
                this.trackBar1.Value  = value;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (edSvc != null)
                edSvc.CloseDropDown();
        }

    }
}
