using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YidanSoft.Library.EmrEditor.Src.Document;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 新增牙齿检查功能
    ///      |
    ///   1  |   2
    /// ------------
    ///      |    
    ///   3  |    4
    /// add by ywk 2012年11月27日11:35:36 
    /// 青龙山精神病院需求
    /// </summary>
    public partial class ToothCheck : DevExpress.XtraEditors.XtraForm
    {

        ZYToothCheck zcheck = null;
        public ToothCheck()
        {
            InitializeComponent();
        }
        public ToothCheck(ZYTextElement zyelement)
        {
            InitializeComponent();
            Point p = Control.MousePosition;
            this.Location = p;
            zcheck = (ZYToothCheck)zyelement;

            this.txtLeftUp.Text = zcheck.LeftUp;
            this.txtleftDown.Text = zcheck.LeftDown;
            this.txtrightup.Text = zcheck.RightUp;
            this.txtrightDown.Text = zcheck.RightDown;
        }
        /// <summary>
        /// 确定按钮 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            zcheck.LeftUp = txtLeftUp.Text;
            zcheck.LeftDown = txtleftDown.Text;
            zcheck.RightUp = txtrightup.Text;
            zcheck.RightDown = txtrightDown.Text;
            
            this.Close();
            zcheck.OwnerDocument.RefreshSize();
            zcheck.OwnerDocument.ContentChanged();
            zcheck.OwnerDocument.OwnerControl.Refresh();
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 同取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToothCheck_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }


        #region 牙齿检查痕迹保留功能处理
        /// <summary>
        /// 左上文本框显示值改变事件处理 add by myc 2014-03-06。
        /// </summary>
        private void txtLeftUp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                zcheck.CreatorIndex = zcheck.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 牙齿检查数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 右上文本框显示值改变事件处理 add by myc 2014-03-06。
        /// </summary>
        private void txtrightup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                zcheck.CreatorIndex = zcheck.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 牙齿检查数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 左下文本框显示值改变事件处理 add by myc 2014-03-06。
        /// </summary>
        private void txtleftDown_TextChanged(object sender, EventArgs e)
        {
            try
            {
                zcheck.CreatorIndex = zcheck.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 牙齿检查数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 右下文本框显示值改变事件处理 add by myc 2014-03-06。
        /// </summary>
        private void txtrightDown_TextChanged(object sender, EventArgs e)
        {
            try
            {
                zcheck.CreatorIndex = zcheck.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 牙齿检查数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion



    }
}