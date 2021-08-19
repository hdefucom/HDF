using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.WinFormDemo
{
    internal class DesignerUtils
    {


        /// <summary>
        /// 检测鼠标是否开始执行了拖拽操作
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns>是否开始进行了鼠标拖拽操作</returns>
        public static bool DragDetect(IntPtr hwnd)
        {
            POINT p = new POINT();
            p.x = System.Windows.Forms.Control.MousePosition.X;
            p.y = System.Windows.Forms.Control.MousePosition.Y;
            return DragDetect(hwnd, p);
            //return false;
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DragDetect(System.IntPtr hWnd, POINT pt);


        public static void FillPropertyTreeView( TreeView tvw , Dictionary<string , Type > rootTypes )
        {
            tvw.BeginUpdate();
            foreach (string name in rootTypes.Keys)
            {
                Type type = rootTypes[name];
                TreeNode rootNode = new TreeNode(name);
                tvw.Nodes.Add(rootNode);
                rootNode.Tag = type;
                PropertyDescriptorCollection ps = TypeDescriptor.GetProperties(type);
                foreach (PropertyDescriptor p in ps)
                {
                    TreeNode pNode = new TreeNode(p.Name);
                    if (string.IsNullOrEmpty(p.Description) == false)
                    {
                        pNode.Text = pNode.Text + "[" + p.Description + "]";
                    }
                    pNode.Tag = p;
                    rootNode.Nodes.Add(pNode);
                }
            }
            tvw.EndUpdate();
        }
    }
}
