using HDF.Common;
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

        /*
         如果需要实现自定义控件popup

        框架自带的ToolStripDropDown和ToolStripControlHost非常方便，
        但是这两个控件有一个问题，因为ToolStripControlHost不是从Control派生的，
        导致控件在BindingContextChange时，Host中的控件数据源不会发生改变，
        然后导致Host中的控件无法以DataSource的方式绑定数据源
         
         下面是解决方案，手动在数据源改变时刷新控件的BindingContext
         
        

        //popup实现方式版本

        // 1. 使用事件手动控制 （不推荐，复杂且焦点状态容易导致bug）
        // 2. Form.Deactivate 事件（必须使用无边框form）
        // 3. WindowsApi（未调通）
        // 4. ToolStripDropDown和ToolStripControlHost（当前）

        //后面如果有更好的popup实现方式再更新

         */

        listBox1.DisplayMember = "Text";
        listBox1.ValueMember = "Value";
        listBox1.DataSource = Enumerable.Range(1, 10).Select(i => i.ToString())
            .Select(i => new TestItem() { Text = i, Value = i }).ToList();


        _dropDown = new ToolStripDropDown();
        _dropDown.Padding = Padding.Empty;



        box = new ListBox()
        {
            Margin = Padding.Empty,
            Dock = DockStyle.Fill,
            SelectionMode = SelectionMode.MultiSimple
        };

        //box.Items.AddRange(Enumerable.Range(10000000, 20)
        //    .Select(i => i.ToString())
        //    .Select(i=>new TestItem() { Text = i, Value = i })
        //    .OfType<object>().ToArray());

        box.DisplayMember = "Text";
        box.ValueMember = "Value";
        box.DataSource = Enumerable.Range(1, 10).Select(i => i.ToString())
            .Select(i => new TestItem() { Text = i, Value = i }).ToList();
        box.BindingContext = this.BindingContext;
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



    private class TestItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        //改变数据源刷新 BindingContext 以触发刷新数据源，否则Host中的控件无法刷新数据源
        box.DataSource.As<List<TestItem>>().Add(new TestItem()
        {
            Text = DateTime.Now.Second.ToString(),
            Value = DateTime.Now.Second.ToString()
        });

        box.BindingContext = null;
        box.BindingContext = this.BindingContext;
    }
}


