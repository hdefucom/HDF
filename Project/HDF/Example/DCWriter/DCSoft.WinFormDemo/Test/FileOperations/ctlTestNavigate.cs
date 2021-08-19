using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls ;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestNavigate : UserControl
    {
        public ctlTestNavigate()
        {
            InitializeComponent();
        }

        private NavigateTreeViewControler _Controler = null;

        private void frmTestChangeTable_Load(object sender, EventArgs e)
        {
            _Controler = new NavigateTreeViewControler(this.tvwNavigate, this.myWriterControl);
            _Controler.Start();

            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, fileName);

            foreach (object obj in Enum.GetValues(typeof(DCSoft.Writer.MoveTarget)))
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = obj.ToString();
                item.Tag = obj;
                this.btnMoveTarget.DropDownItems.Add(item);
                item.Click += new EventHandler(item_Click);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ( ToolStripMenuItem ) sender ;
            MoveTarget target = (MoveTarget)item.Tag;
            this.myWriterControl.MoveTo(target);
            
        }

        /// <summary>
        /// 文档导航状态信息改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myWriterControl_DocumentNavigateContentChanged(object sender, EventArgs e)
        {
            _Controler.Refresh(FunctionControlVisibility.Visible);
        }
        
        /// <summary>
        /// 文档当前位置发生改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myWriterControl_SelectionChanged(object sender, EventArgs e)
        {
            _Controler.HandleWriterControlSelectionChanged();
        }

        private void btnGetNodeString_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myWriterControl.GetNavigateNodesString());
        }

        private void btnNavagite_Click(object sender, EventArgs e)
        {
            myWriterControl.NavigateByNodeID(txtNodeID.Text);
        }

        private void btnGetXMLString_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myWriterControl.GetNavigateNodesXMLString());
        }

        private void btnCurrentNode_Click(object sender, EventArgs e)
        {
            NavigateNode node = myWriterControl.Navigator.CurrentNode;
            if (node != null)
            {
                MessageBox.Show(
                    "ID=" + node.ID
                    + "\r\nLevel=" + node.Level
                    + "\r\nPosition=" + node.Position
                    + "\r\nText=" + node.Text);

            }
        }
    }
}
