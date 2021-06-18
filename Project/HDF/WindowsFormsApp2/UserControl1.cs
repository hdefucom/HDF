using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        [Category("Editor")]
        [DefaultValue(typeof(Color), "128,128,128,128")]
        public Color SelectionColor { get; set; } = Color.FromArgb(0x80, 128, 128, 128);



    }
}
