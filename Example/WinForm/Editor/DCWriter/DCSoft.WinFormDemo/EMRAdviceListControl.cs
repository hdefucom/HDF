using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls;
 

namespace DCSoft.Writer.WinFormDemo
{
    /// <summary>
    /// 医嘱查看和编辑器
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
    public partial class EMRAdviceListControl : UserControl, IDocumentHostedObject
    {
        public EMRAdviceListControl()
        {
            InitializeComponent();
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode == false)
            {
                if (dgvAdvice.DataSource == null)
                {
                    dgvAdvice.DataSource = new BindingList<EMRAdvice>();
                }
                //MessageBox.Show("Load");
            }
        }


        /// <summary>
        /// 加载控件视图状态
        /// </summary>
        /// <param name="args">参数</param>
        void IDocumentHostedObject.LoadViewState( DocumentHostElementEventArgs args)
        {
            EMRAdviceList list = null;
            if (args.ViewState != null)
            {
                list = (EMRAdviceList)args.ViewState.GetValue("advices");
            }
            if (list == null)
            {
                list = new EMRAdviceList();
            }
            BindingList<EMRAdvice> bl = new System.ComponentModel.BindingList<EMRAdvice>();
            foreach (EMRAdvice item in list)
            {
                bl.Add(item);
            }
            dgvAdvice.DataSource = bl;
        }

        /// <summary>
        /// 保存控件视图状态
        /// </summary>
        /// <param name="args">参数</param>
        void IDocumentHostedObject.SaveViewState(DCSoft.Writer.Dom.DocumentHostElementEventArgs args)
        {
            dgvAdvice.CommitEdit(DataGridViewDataErrorContexts.Display);
            if (args.ViewState != null)
            {
                BindingList<EMRAdvice> bl = (BindingList<EMRAdvice>)dgvAdvice.DataSource;
                if (bl != null)
                {
                    EMRAdviceList list = new EMRAdviceList();
                    list.AddRange(bl);
                    if (list != null)
                    {
                        args.ViewState.SetValue("advices",list);
                    }
                }
            }
        }

        /// <summary>
        /// 返回表示控件内容的图片
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Image IDocumentHostedObject.CreatePreviewImage(DCSoft.Writer.Dom.DocumentHostElementEventArgs args)
        {
            return null;
        }

        /// <summary>
        /// 添加记录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvAdvice.CurrentCell = dgvAdvice.Rows[dgvAdvice.NewRowIndex].Cells[0];
        }
        /// <summary>
        /// 删除记录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ( dgvAdvice.CurrentRow != null &&
                dgvAdvice.CurrentRow.Index != dgvAdvice.NewRowIndex)
            {
                dgvAdvice.Rows.Remove(dgvAdvice.CurrentRow);
            }
        }



        /// <summary>
        /// 医嘱信息列表
        /// </summary>
        [Serializable]
        public class EMRAdviceList : List<EMRAdvice>
        {

        }

        /// <summary>
        /// 医嘱信息对象
        /// </summary>
        [Serializable]
        public class EMRAdvice
        {
            /// <summary>
            /// 初始化对象
            /// </summary>
            public EMRAdvice()
            {
            }

            private string _药品名称 = null;

            public string 药品名称
            {
                get { return _药品名称; }
                set { _药品名称 = value; }
            }

            private string _剂量 = null;

            public string 剂量
            {
                get { return _剂量; }
                set { _剂量 = value; }
            }

            private string _单位 = null;

            public string 单位
            {
                get { return _单位; }
                set { _单位 = value; }
            }

            private string _给药途径 = null;

            public string 给药途径
            {
                get { return _给药途径; }
                set { _给药途径 = value; }
            }
        }
    }
}