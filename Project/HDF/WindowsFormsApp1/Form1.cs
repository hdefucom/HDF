using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.VisualStudio2013Light);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            var skin = new OfficeSkins();

            var d = new DockingSkins();


            



        }
    }
}
