using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Text
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (DesignMode)
                File.AppendAllText("E://1.txt", "ffffffffffffff");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                File.AppendAllText("E://1.txt", "aaaaaaaaaaaaaaa");
        }
    }
}
