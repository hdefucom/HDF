using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HDF.Test.Winform;

public class TestDropDownView : Component
{



    public TestDropDownView()
    {
        //_dropdown = new TableDropDown();
    }


    TextBox attachtextbox;

    public TextBox AttachTextBox
    {
        get
        {
            return attachtextbox;
        }
        set
        {
            if (attachtextbox == value)
                return;

            attachtextbox = value;
            if (attachtextbox != null)
            {
                _dropdown ??= new TableDropDown(attachtextbox);
                attachtextbox.GotFocus += (_, _) =>
                {
                    System.Console.WriteLine("123456");
                    _dropdown.Show(attachtextbox, 0, attachtextbox.Height);
                };
                attachtextbox.Click += (_, _) =>
                {
                    if (!_dropdown.Visible)
                        _dropdown.Show(attachtextbox, 0, attachtextbox.Height);
                };
            }
        }
    }



    TableDropDown _dropdown;

    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public int pt_x;
        public int pt_y;
    }

    [DllImport("user32")]
    public static extern int PeekMessage(ref MSG lpMsg, IntPtr hwnd, int wMsgFilterMin, int wMsgFilterMax, int wRemoveMsg);

    private class TableDropDown : ToolStripDropDown
    {
        private class Dto
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (_attch != null && !DesignMode)
                {
                    cp.Style = (int)(((long)cp.Style & 0xffff) | 0x80000000 | 0x10000000);
                    //cp.ClassStyle |= 0x20000;//阴影边框
                    cp.ExStyle |= /*0x08000000 |*/ 0x00000008;
                    //Point pos = mParent.PointToScreen(new Point(0, mParent.Height));
                    //cp.X = pos.X;
                    //cp.Y = pos.Y;
                    //cp.Width = base.DefaultSize.Width;
                    //cp.Height = base.DefaultSize.Height;
                }
                return cp;
            }
        }
        TextBox _attch;
        DataGridView view;

        public TableDropDown(TextBox attach)
        {

            _attch = attach;
            this.Padding = Padding.Empty;
            this.Margin = Padding.Empty;

            view = new DataGridView();

            this.view.BindingContext = attach.BindingContext;

            this.view.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view.Name = "dataGridView1";
            this.view.RowTemplate.Height = 23;


            this.view.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { Name = "col_Name", HeaderText = "姓名", DataPropertyName = "Name" },
            new DataGridViewTextBoxColumn { Name = "col_Age", HeaderText = "年龄", DataPropertyName = "Age" }
        });
            this.view.DataSource = new List<Dto>() {
        new Dto{Name="a",Age=18,},
        new Dto{Name="b",Age=19 },
        new Dto{Name="c",Age=28 },
        };

            this.Items.Add(new ToolStripControlHost(view) { Padding = Padding.Empty, Margin = Padding.Empty });


            view.Click += (_, _) =>
            {
                //MonthCalendar
                //DateTimePicker

            };

            this.Closing += (_, e) =>
            {
                System.Console.WriteLine(e.CloseReason);
                System.Console.WriteLine(this.Parent == null);
            };




        }

        [DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        private const int WM_ACTIVATE = 6;
        private const int WA_INACTIVE = 0;

        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATEANDEAT = 0x0004;
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WM_MOUSEACTIVATE)
            //{
            //    //m.Result = (IntPtr)MA_NOACTIVATEANDEAT; // prevent the form from being clicked and gaining focus
            //    m.Result = (IntPtr)3; // prevent the form from being clicked and gaining focus
            //    Console.WriteLine("xxx");
            //    return;
            //}
            //if (m.Msg == WM_ACTIVATE) // if a message gets through to activate the form somehow
            //{
            //    if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
            //    {

            //        if (m.LParam != IntPtr.Zero)
            //        {
            //            SetActiveWindow(m.LParam);
            //        }
            //        else
            //        {
            //            // Could not find sender, just in-activate it.
            //            SetActiveWindow(IntPtr.Zero);
            //        }

            //    }
            //}
            base.WndProc(ref m);
        }






    }







}
