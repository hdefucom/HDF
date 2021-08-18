using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {





        }

        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            label_Msg.Text = "lable key";
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            label_Msg.Text = "panel key";
        }




        private void button1_Click(object sender, EventArgs e)
        {





        }



    }








}
