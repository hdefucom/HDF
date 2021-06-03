
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static WindowsFormsApp2.Program;

namespace WindowsFormsApp2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            Log.Push += log;
            Log.Push += log;
        }

        private void Form6_Load(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("aaaaaaaaaaaaaaa");
        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);


            Log.Push -= log;
            Log.Push -= log;
        }



        private void log(string log) => MessageBox.Show(log);



    }




}
