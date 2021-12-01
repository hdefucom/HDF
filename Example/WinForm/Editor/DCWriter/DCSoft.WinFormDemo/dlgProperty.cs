using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class dlgProperty : Form
    {
        public dlgProperty()
        {
            InitializeComponent();
        }

        public object InstanceToShow
        {
            get
            {
                return myPropertyGrid.SelectedObject;
            }
            set
            {
                myPropertyGrid.SelectedObject = value;
                myPropertyGrid.Refresh();
            }
        }

        private void dlgProperty_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
