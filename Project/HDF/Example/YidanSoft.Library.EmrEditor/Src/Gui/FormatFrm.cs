using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Diagnostics;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    public partial class FormatFrm : Form
    {
        public FormatFrm(ZYTextBlock o)
        {

            InitializeComponent();
            //Point p = Control.MousePosition;
            //this.Location = p;
            num = o;
            string info = "";

            //合理化高度,使列表中不显示空白


            if (o is ZYFormatNumber)
            {
                this.textBox1.Visible = true;
                this.dateTimePicker1.Visible = false;

                length = ((ZYFormatNumber)o).Length;
                maxValue = ((ZYFormatNumber)o).MaxValue;
                minValue = ((ZYFormatNumber)o).MinValue;

                this.labelName.Text = ((ZYFormatNumber)o).Name.ToString();
                this.textBox1.Text = ((ZYFormatNumber)o).Value.ToString();
                info =
    "提示：长度" + ((ZYFormatNumber)num).Length + " 最大值" + ((ZYFormatNumber)num).MaxValue + " 最小值" + ((ZYFormatNumber)num).MinValue + " 小数位" + ((ZYFormatNumber)num).DecimalDigits;
                this.toolTip1.SetToolTip(this.textBox1,info);
            }

            if (o is ZYFormatDatetime)
            {
                this.textBox1.Visible = false;
                this.dateTimePicker1.Visible = true;
                this.labelName.Text = ((ZYFormatDatetime)o).Name.ToString();
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = ((ZYFormatDatetime)o).FormatString.ToString();
                this.dateTimePicker1.Value = Convert.ToDateTime(((ZYFormatDatetime)o).Value);

                info = "提示：选择数字部分，上下箭头改变值，或用键盘输入";
                this.toolTip1.SetToolTip(this.dateTimePicker1,info);
            }

            if (o is ZYFormatString)
            {
                this.textBox1.Visible = true;
                this.dateTimePicker1.Visible = false;
                this.labelName.Text = ((ZYFormatString)o).Name.ToString();
                this.textBox1.Text = ((ZYFormatString)o).Text;
                length = ((ZYFormatString)o).Length;
                info = "提示：字符串最大长度 " + ((ZYFormatString)o).Length; ;
                this.toolTip1.SetToolTip( this.textBox1,info);
            }

            if (o is ZYPromptText)
            {
                this.textBox1.Visible = true;
                this.dateTimePicker1.Visible = false;
                this.textBox1.Multiline = true;
                this.Height += this.textBox1.Height;

                this.Width = this.Width + this.Width / 2;

                this.textBox1.Height += this.textBox1.Height;


                this.labelName.Text = ((ZYPromptText)o).Name.ToString();
                this.textBox1.Text = ((ZYPromptText)o).Text;

                info = "提示：" + ((ZYPromptText)o).Name;
                this.toolTip1.SetToolTip(this.textBox1,info);
            }


            //合理化窗口位置

            //编辑窗口的绝对位置
            Rectangle AbsolutEditorWinRect = o.OwnerDocument.OwnerControl.ClientRectangle;
            AbsolutEditorWinRect.Location = o.OwnerDocument.OwnerControl.PointToScreen(o.OwnerDocument.OwnerControl.ClientRectangle.Location);

            //弹出窗口绝对位置
            Rectangle AbsolutHelpWinRect = this.Bounds;
            AbsolutHelpWinRect.Location = Control.MousePosition;

            //计算合理位置
            //弹出窗口没有超出编辑窗口范围
            if (AbsolutEditorWinRect.Contains(AbsolutHelpWinRect))
            {
            }
            else
            {
                int x = 0;
                int y = 0;
                //调整水平位置
                if (AbsolutHelpWinRect.Right > AbsolutEditorWinRect.Right)
                {
                    x = AbsolutEditorWinRect.Right - AbsolutHelpWinRect.Right;
                }
                //调整垂直位置
                if (AbsolutHelpWinRect.Bottom > AbsolutEditorWinRect.Bottom)
                {
                    y = -AbsolutHelpWinRect.Height;
                }

                AbsolutHelpWinRect.Offset(x, y);
            }

            Debug.WriteLine("EditorWinAbsolutRect " + AbsolutHelpWinRect);
            this.Location = AbsolutHelpWinRect.Location;

            if (dateTimePicker1.CustomFormat == "yyyy年MM月")  //xll 2012-10-31 修改时年月格式是有时会报错的问题
            {
                dateTimePicker1.Value = dateTimePicker1.Value.Date.AddDays(1 - dateTimePicker1.Value.Day);
            }
        }

        public FormatFrm(ZYTextBlock o,  ZYSelectableElement sel,int start,int end):this(o)
        {
            _sel = sel;
            _start = start;
            _end = end;
        }
        ZYSelectableElement _sel;
        int _start = -1;
        int _end = -1;

        uint? length = null;
        decimal? maxValue = null;
        decimal? minValue = null;

        ZYTextBlock num = null;

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            if (num is ZYFormatNumber)
            {
                //先判断范围 ，返回设定的值
                if (this.textBox1.Text.Length == 0)
                {
                    this.toolTip1.Show("内容不能为空", this.textBox1,1000);
                    return;
                }

                decimal d = Convert.ToDecimal(this.textBox1.Text);
                if (d <= maxValue && d >= minValue)
                {
                    ((ZYFormatNumber)num).Value = d;

                    this.Close();
                }
                else
                {
                    this.toolTip1.Show("数值范围应在 " + minValue + "与" + maxValue + " 之间",this.textBox1,1000);
                }
            }

            if (num is ZYFormatDatetime)
            {
                ((ZYFormatDatetime)num).Value = this.dateTimePicker1.Value;
                this.Close();
            }

            if (num is ZYFormatString)
            {
                if (this.textBox1.Text.Length == 0)
                {
                    this.toolTip1.Show("内容不能为空", this.textBox1,1000);
                    return;
                }
                ((ZYFormatString)num).Text = this.textBox1.Text;

                

                this.Close();
            }

            if (num is ZYPromptText)
            {
                if (this.textBox1.Text.Length == 0)
                {
                    PopCannotNull();
                    return;
                }
                ((ZYPromptText)num).Text = this.textBox1.Text;

                if (_sel != null)
                {
                    string str = _sel.text ;
                   
                   string txt = str.Substring(0, _start);
                    txt += this.textBox1.Text;
                    //txt += str.Substring(_end);
                    _sel.Text = txt;
                    _sel.CreatorIndex = _sel.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-05
                }

                num.CreatorIndex = num.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-05 录入提示输入文本保存修改索引号
                
                this.Close();
            }

            #region add by myc 2014-05-21 双击结构化元素更新值时单元格自适应高度调整
            if (num.Parent.Parent is TPTextCell)
            {
                (num.Parent.Parent as TPTextCell).AdjustHeight();
            }
            #endregion

            num.OwnerDocument.RefreshSize();
            //num.OwnerDocument.RefreshLine();
            num.OwnerDocument.ContentChanged();
            num.OwnerDocument.OwnerControl.Refresh();



            //num.OwnerDocument.EndContentChangeLog();
            //num.OwnerDocument.EndUpdate();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (num is ZYFormatNumber)
            {

                string flags = "-+.1234567890";
                if (flags.IndexOf(e.KeyChar) >= 0)
                {
                    //如果无小数位则不允许输入小数点
                    if (((ZYFormatNumber)num).DecimalDigits == 0 && e.KeyChar == '.')
                    {
                        e.Handled = true;
                    }

                    try
                    {
                        string str = this.textBox1.Text + e.KeyChar;
                        if (str.Length > length
                            || (str.IndexOf('.') >= 0 && str.Length - str.IndexOf('.') > ((ZYFormatNumber)num).DecimalDigits + 1)
                            )
                        {

                            e.Handled = true;

                        }
                        else
                        {
                            Convert.ToDecimal(str);
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Handled = true;
                    }
                }
                else if ((Keys)e.KeyChar == Keys.Back || (Keys)e.KeyChar == Keys.Delete || (Keys)e.KeyChar == Keys.Escape)
                {
                }
                else
                {
                    e.Handled = true;
                }

            }

            if (num is ZYFormatString)
            {
                string str = this.textBox1.Text + e.KeyChar;
                if ((Keys)e.KeyChar == Keys.Back || (Keys)e.KeyChar == Keys.Delete)
                {
                }
                else if (str.Length > length)
                {
                    e.Handled = true;
                }
            }
            num.CreatorIndex = num.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-05 格式化数字和格式化字符串保存修改索引号
            
            
        }

        void PopCannotNull()
        {
            Point p = new Point(this.textBox1.Width / 2, this.textBox1.Height / 2);
            this.toolTip1.Show("内容不能为空", this.textBox1, p, 1000);
        }

        private void FormatFrm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 时间控件显示值改变事件处理 add by myc 2014-03-05。
        /// </summary>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                num.CreatorIndex = num.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-05 格式化时间保存修改索引号
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
