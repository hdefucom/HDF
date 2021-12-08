using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _dropDown = new ToolStripDropDown();
            _dropDown.Padding = Padding.Empty;

            box = new ListBox()
            {
                Margin = Padding.Empty,
                Dock = DockStyle.Fill,
                SelectionMode = SelectionMode.MultiSimple
            };

            //*******************************************************  Can display
            //box.Items.AddRange(Enumerable.Range(10000000, 20)
            //    .Select(i => i.ToString())
            //    .Select(i => new TestItem() { Text = i, Value = i })
            //    .OfType<object>().ToArray());
            //*************************************************************************

            //*******************************************************  Cannot display
            box.DisplayMember = "Text";
            box.ValueMember = "Value";
            box.DataSource = new ObservableCollection<TestItem>(
                Enumerable.Range(1, 10).Select(i => i.ToString())
                .Select(i => new TestItem() { Text = i, Value = i })
                );
            //*************************************************************************


            host = new ToolStripControlHost(box) { Padding = Padding.Empty, Margin = Padding.Empty };
            _dropDown.Items.Add(host);
        }

        ListBox box;
        ToolStripControlHost host;
        ToolStripDropDown _dropDown;


        private void button1_Click(object sender, EventArgs e)
        {
            _dropDown.Show(Control.MousePosition);
        }
        private class TestItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
