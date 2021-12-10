using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class Form4 : Form
{
    public Form4()
    {
        InitializeComponent();



        listBox1.DisplayMember = "Text";
        listBox1.ValueMember = "Value";
        listBox1.DataSource = new ObservableCollection<TestItem>(
            Enumerable.Range(1, 10).Select(i => i.ToString())
            .Select(i => new TestItem() { Text = i, Value = i })
            );




        _dropDown = new ToolStripDropDown();
        _dropDown.Padding = Padding.Empty;


        //_dropDown.Items.AddRange(
        //    Enumerable.Range(1, 10)
        //    .Select(i => new ToolStripSplitButton(i.ToString()) { Tag = i, /*CheckOnClick = true,*/ })
        //    .ToArray()
        //    );


        box = new ListBox()
        {
            Margin = Padding.Empty,
            //BorderStyle = BorderStyle.None,
            Dock = DockStyle.Fill,
            SelectionMode = SelectionMode.MultiSimple
        };

        box.DataSourceChanged += (_, _) =>
        {
            var a = box.Items;

        };

        //box.Items.AddRange(Enumerable.Range(10000000, 20)
        //    .Select(i => i.ToString())
        //    .Select(i=>new TestItem() { Text = i, Value = i })
        //    .OfType<object>().ToArray());

        box.DisplayMember = "Text";
        box.ValueMember = "Value";
        box.DataSource = new ObservableCollection<TestItem>(
            Enumerable.Range(1, 10).Select(i => i.ToString())
            .Select(i => new TestItem() { Text = i, Value = i })
            );

        box.SelectedIndexChanged += (sender, e) =>
        {
            if (box.SelectionMode == SelectionMode.One)
                _dropDown.Close();
        };

        host = new ToolStripControlHost(box) { Padding = Padding.Empty, Margin = Padding.Empty };


        _dropDown.Items.Add(host);




    }

    ListBox box;
    ToolStripControlHost host;

    private readonly ToolStripDropDown _dropDown;

    private void button1_Click(object sender, EventArgs e)
    {


        _dropDown.Show(Control.MousePosition);
    }

    private void Form4_Load(object sender, EventArgs e)
    {
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




public class TestDropDown : ToolStripDropDown
{

    protected override void OnBindingContextChanged(EventArgs e)
    {
        base.OnBindingContextChanged(e);

        foreach (ToolStripItem item in Items)
        {
            if (item is ToolStripControlHost host)
            {

            }
        }


    }







}