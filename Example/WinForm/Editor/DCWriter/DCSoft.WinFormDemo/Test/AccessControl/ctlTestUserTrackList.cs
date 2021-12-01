using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls ;

namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    [ToolboxItem(false)]
    public partial class ctlTestUserTrackList : UserControl
    {
        public ctlTestUserTrackList()
        {
            InitializeComponent();
        }

        private TrackListBoxControler _Controler = null;

        private void frmTestChangeTable_Load(object sender, EventArgs e)
        {
            // 实例化用户痕迹列表控制器
            _Controler = new TrackListBoxControler(this.lstUserTrack, this.myWriterControl);
            // 启用控制器
            _Controler.Start();

            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();

            myWriterControl.ExecuteCommand("ComplexViewMode", false, null);
            //string fileName = System.IO.Path.Combine(
            //    Application.StartupPath,
            //    "DemoFile\\demo.xml");            
                string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, fileName);
        }

        /// <summary>
        /// 文档当前位置发生改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myWriterControl_SelectionChanged(object sender, EventArgs e)
        {
            // 当文档当前位置发生改变时设置当前列表项目
            //_Controler.HandleWriterControlSelectionChanged();
        }

        private void btnRefreshTrackList_Click(object sender, EventArgs e)
        {
            // 刷新用户痕迹列表内容
            _Controler.Refresh();
        }

        private void myWriterControl_DocumentContentChanged(object sender, EventArgs e)
        {
            // 当文档导航内容发生改变时刷新用户痕迹列表内容
            _Controler.Refresh();
        }
    }
}