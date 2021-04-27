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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            SetStyle(ControlStyles.Selectable, true);
        }

        private void Form4_Load(object sender, EventArgs e)
        {



        }

        private void Form4_Shown(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /*
         
        //鼠标事件触发链路
         
        MouseDown(按住不放会在此处阻塞此鼠标按键事件，但是不影响其他鼠标按键事件)
        ↓
        Click
        ↓
        MouseClick
        ↓
        MouseUp
        ↓
        MouseMove
        ↓
        单机一次鼠标到此结束
        ↓
        MouseDown
        ↓
        DoubleClick
        ↓
        MouseDoubleClick
        ↓
        MouseUp
        ↓
        MouseMove
        ↓
        双击机鼠标到此结束

         
        1.鼠标点击流程最后都会触发一次Move，哪怕鼠标并没有移动
        2.鼠标进入后首次悬浮不动才会触发Hover，后续移动再次悬浮也不会触发Hove，每次进入只会触发一次Hover
        3.双击事件触发的要求是，在不超出判定时间内点击的坐标一致才能触发双击，并且每点击两次第二次才会触发双击，例如点击三次都是同样坐标，触发是Click->DoubleClick->Click
         
         
         */



        //protected override void OnClick(EventArgs e)
        //{
        //    base.OnClick(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发Click");
        //}
        //protected override void OnDoubleClick(EventArgs e)
        //{
        //    base.OnDoubleClick(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发DoucleClick");
        //}

        //protected override void OnMouseClick(MouseEventArgs e)
        //{
        //    base.OnMouseClick(e);
        //    Console.WriteLine();
        //    Console.WriteLine($"引发MouseClick----->{e.Location}");
        //}

        //protected override void OnMouseDoubleClick(MouseEventArgs e)
        //{
        //    base.OnMouseDoubleClick(e);
        //    Console.WriteLine();
        //    Console.WriteLine($"引发MouseDoubleClick----->{e.Location}");
        //}

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发MouseDown");
        //}
        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发MouseUp");
        //}
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发MouseMove");
        //}
        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发MouseEnter");
        //}
        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发MouseLeave");
        //}
        //protected override void OnMouseHover(EventArgs e)
        //{
        //    base.OnMouseHover(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发MouseHover");
        //}
        //protected override void OnMouseWheel(MouseEventArgs e)
        //{
        //    base.OnMouseWheel(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发MouseWheel");
        //}







        /*
         
        //键盘事件触发链路
         
        OnPreviewKeyDown
        ↓
        OnKeyDown(类似MouseDown)
        ↓
        OnKeyPress(类似Click\MouseClick)
        ↓
        OnKeyUp(类似MouseUp)

        1.按住键盘不放会一直触发OnPreviewKeyDown/OnKeyDown/OnKeyPress，直到松开键盘才会触发KeyUp

        2.当按住一个键不放时，一直触发该键的OnPreviewKeyDown/OnKeyDown/OnKeyPress事件，
        如果同时按下另一个按键，则另一个按键的会中断该键的事件循环，由另一个按键一直触发OnPreviewKeyDown/OnKeyDown/OnKeyPress事件，
        继续按下一个键不放，每次都会替换上一次按键的事件循环，直到最后一次按下的键松开才会终止循环，并按松开顺序依次触发KeyUp
        如果在最后一次按下的键未松开时，松开了之前按下的键，会触发该键的keyUp，但不会中断最后一次按下键的事件循环


        例如

        1.按下A
        
                OnPreviewKeyDown-->AAAAA
                ↓
                OnKeyDown-->AAAAA
                ↓
                OnKeyPress-->AAAAA

                ......循环

        2.不松开A并按下S
        
                OnPreviewKeyDown-->SSSSS
                ↓
                OnKeyDown-->SSSSS
                ↓
                OnKeyPress-->SSSSS

                ......循环

        3.不松开A/S并按下D
        
                OnPreviewKeyDown-->DDDDD
                ↓
                OnKeyDown-->DDDDD
                ↓
                OnKeyPress-->DDDDD

                ......循环

       4. 不松开A/S/D并按下F
        
                OnPreviewKeyDown-->FFFFF
                ↓
                OnKeyDown-->FFFFF
                ↓
                OnKeyPress-->FFFFF

                ......循环
        
        5.不松开A/D/F但是松开S
        
                OnKeyUp-->SSSSS
                ↓
                OnPreviewKeyDown-->FFFFF
                ↓
                OnKeyDown-->FFFFF
                ↓
                OnKeyPress-->FFFFF

                ......循环
        
        6.不松开A/D但是松开F
        
                OnKeyUp-->FFFFF

                最后一次按下的按键松开，事件循环停止
        
        7.不松开D但是松开A
        
                OnKeyUp-->AAAAA

        8.松开D
        
                OnKeyUp-->DDDDD


         
         */

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    Console.WriteLine();
        //    Console.WriteLine($"引发OnKeyDown-->{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}");
        //}
        //protected override void OnKeyUp(KeyEventArgs e)
        //{
        //    base.OnKeyUp(e);
        //    Console.WriteLine();
        //    Console.WriteLine($"OnKeyUp-->{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}{e.KeyCode}");
        //}

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    base.OnKeyPress(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发OnKeyPress");
        //}

        //protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        //{


        //    base.OnPreviewKeyDown(e);
        //    Console.WriteLine();
        //    Console.WriteLine("引发OnPreviewKeyDown");
        //}
















    }
}
