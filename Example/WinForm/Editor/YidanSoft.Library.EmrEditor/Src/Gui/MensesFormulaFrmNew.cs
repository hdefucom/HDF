using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YidanSoft.Library.EmrEditor.Src.Document;
/* Add By wwj 2011-10-10 增加月经史公式
 * 
 *             经期（天）
 *   初潮年龄 ------------ 末次月经日期（或绝经年龄）
 *             周期（天）
 * 
 */ 


namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    public partial class MensesFormulaFrmNew : DevExpress.XtraEditors.XtraForm
    {
        ZYMensesFormula num = null;

        public MensesFormulaFrmNew(ZYTextElement o)
        {
            InitializeComponent();
            Point p = Control.MousePosition;
            this.Location = p;
            num = (ZYMensesFormula)o;

            this.textBox1.Text = num.Last;
            this.textBox2.Text = num.Period;
            this.textBox3.Text = num.FirstAge;
            this.textBox4.Text = num.FinallyAgeOrdate;
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length == 0)
            {
                this.toolTip1.Show("请输入经期持续天数", this.textBox1, 2000);
                textBox1.Focus();
                return;
            }
            if (this.textBox2.Text.Trim().Length == 0)
            {
                this.toolTip1.Show("请输入周期天数", this.textBox2, 2000);
                textBox2.Focus();
                return;
            }
            //if (this.textBox3.Text.Trim().Length == 0)
            //{
            //    this.toolTip1.Show("请输入初潮年龄", this.textBox3, 2000);
            //    textBox3.Focus();
            //    return;
            //}
            //if (this.textBox4.Text.Trim().Length == 0)
            //{
            //    this.toolTip1.Show("请输入末次月经日期（或绝经年龄）", this.textBox4, 2000);
            //    textBox4.Focus();
            //    return;
            //}

            num.Last = this.textBox1.Text;
            num.Period = this.textBox2.Text;
            num.FirstAge = this.textBox3.Text;
            num.FinallyAgeOrdate = this.textBox4.Text;

            this.Close();

            num.OwnerDocument.RefreshSize();
            num.OwnerDocument.ContentChanged();
            num.OwnerDocument.OwnerControl.Refresh();
        }

        private void MensesFormulaFrmNew_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 月经史公式痕迹保留功能处理 add by myc 2014-03-06
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                num.CreatorIndex = num.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 月经史公式数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                num.CreatorIndex = num.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 月经史公式数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                num.CreatorIndex = num.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 月经史公式数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                num.CreatorIndex = num.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 月经史公式数据修改时保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}