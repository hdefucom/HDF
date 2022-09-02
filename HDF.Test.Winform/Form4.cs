using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace HDF.Test.Winform
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            list.CollectionChanged += (_, _) => label1.Text = list.Count.ToString();
        }



        ObservableCollection<int> list = new ObservableCollection<int>();


        private void button1_Click(object sender, EventArgs e)
        {
            int count = list.Count;
            for (int i = count; i < count + 1000; i++)
            {
                list.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = list.Count - 1;

            for (int i = count; i > count - 1000; i--)
            {
                list.RemoveAt(i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            list.Clear();
            list = null;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
