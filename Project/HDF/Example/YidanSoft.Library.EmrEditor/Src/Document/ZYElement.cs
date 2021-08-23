using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Drawing;
using System.Diagnostics;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 继承自ZYTextElement，增加了元素名称，类型 等内容,用于自画元素的基类
    /// </summary>
    public class ZYElement : ZYTextChar
    {
        public ZYElement()
        {
            strFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.FitBlackBox;
        }
        public StringFormat strFormat = StringFormat.GenericTypographic;
        public string Code = "";
        string name = "";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 是否是必选项
        /// </summary>
        public bool MustClick = false;

        public bool Clicked = false;

        //双击弹出窗口
        public override bool HandleDblClick(int x, int y, MouseButtons Button)
        {
            if (this.Bounds.Contains(x, y))
            {
                if (this is ZYMensesFormula)
                {
                    //MensesFormulaFrm HelpWin = new MensesFormulaFrm(this);
                    //HelpWin.ShowDialog();
                    MensesFormulaFrmNew HelpWin = new MensesFormulaFrmNew(this);
                    HelpWin.Show();
                }
                //如果是牙齿检查 add by ywk 2012年11月27日17:35:10
                if (this is ZYToothCheck)
                {
                    ToothCheck HelpWin = new ToothCheck(this);
                    HelpWin.Show();
                }

                this.Clicked = true;
            }
            return base.HandleDblClick(x, y, Button);
        }

        public override bool HandleClick(int x, int y, MouseButtons Button)
        {
            if (this.Bounds.Contains(x, y))
            {

                if (this is ZYButton)
                {
                    if (((ZYButton)this).Event != null && this.OwnerDocument.Info.DocumentModel != DocumentModel.Design)
                    {
                        //只有在编辑状态，才响应事件
                        string str = this.OwnerDocument.OwnerControl.FireHelpButtonClick(((ZYButton)this).Event);
                        return true;//必需要有这句，否则执行到最后一行时，由于在按钮按下中有删除元素动作，HandleClick 的内部循环选 有元素会出错
                    }
                }

                if (this is ZYCheckBox)
                {
                    (this as ZYCheckBox).Checked = !(this as ZYCheckBox).Checked;
                    this.CreatorIndex = this.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-06 复选框状态改变保存修改索引号
                    this.OwnerDocument.OwnerControl.Refresh();
                }

                this.Clicked = true;
            }

            return base.HandleClick(x, y, Button);
        }


    }
}
