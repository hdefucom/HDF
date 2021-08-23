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
using YidanSoft.Library.EmrEditor.Src.DataElement;
using YidanSoft.Common.Library;
using YidanSoft.Wordbook;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    public partial class DataElementLookupEditorForm : Form
    {
        ZYDataElementLookupEditor zy = null;


        public DataElementLookupEditorForm(ZYTextBlock o)
        {
            InitializeComponent();

            labelName.Text = o.Text;
            if (o is ZYDataElementLookupEditor)
            {
                zy = (ZYDataElementLookupEditor)o;
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
        }

        public string CodeValues
        {
            get
            {
                return lookUpEditor1.CodeValue;
            }
        }

        /// <summary>
        /// 
        /// 2019.06.27-hdf
        /// 数据元字典不使用工作簿查询，直接使用数据元代码属性查询数据库数据
        /// 
        /// 存储数据元代码值范围
        /// </summary>
        public string ValuesRange
        {
            get
            {
                return zy.Wordbook;
            }
        }


        public string DisplayValues
        {
            get { return lookUpEditor1.DisplayValue; }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            zy.CodeValue = this.lookUpEditor1.CodeValue;
            zy.Text = this.lookUpEditor1.DisplayValue;
            if (string.IsNullOrEmpty(zy.Text))
                zy.Text = zy.Name;
            zy.OwnerDocument.RefreshSize();

            #region add by myc 2014-05-21 双击结构化元素更新值时单元格自适应高度调整
            if (zy.Parent.Parent is TPTextCell)
            {
                (zy.Parent.Parent as TPTextCell).AdjustHeight();
            }
            #endregion

            //num.OwnerDocument.RefreshLine();
            zy.OwnerDocument.ContentChanged();
            zy.OwnerDocument.OwnerControl.Refresh();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LookupEditorForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (zy.Multi)//默认可以最多选择20个记录
                    lookUpEditor1.MaxCount = 20;

                #region 2019.06.28-hdf，LookUpEditor控件绑定数据
                //由之前的传递数据字典名称改为绑定DataTable数据
                DataTable dataTable = STD_DataElement_Value_RangeBiz.GetSTD_DataElement_Value_RangeDataTableByValueRangeCode(zy.Wordbook);
                Dictionary<string, int> columnwidth = new Dictionary<String, Int32>();
                if (dataTable.Columns.Contains("VALUE_CODE"))
                {
                    dataTable.Columns["VALUE_CODE"].Caption = "编号";
                }
                if (dataTable.Columns.Contains("VALUE_NAME"))
                {
                    dataTable.Columns["VALUE_NAME"].Caption = "名称";
                }
                columnwidth.Add("VALUE_CODE", 70);
                columnwidth.Add("VALUE_NAME", this.lookUpEditor1.Width);
                //2019.10.10-hdf：数据元字典增加品应五笔筛选功能
                SqlWordbook sqlWordBook = new SqlWordbook("valueRange_book", dataTable.Copy(), "VALUE_CODE", "VALUE_NAME", columnwidth, "VALUE_CODE//VALUE_NAME//PY//WB");

                lookUpEditor1.SqlWordbook = sqlWordBook;

                #endregion 

                //初始化绑定数据
                this.lookUpEditor1.CodeValue = zy.CodeValue;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

        }

        private void LookupEditorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
        }


    }
}
