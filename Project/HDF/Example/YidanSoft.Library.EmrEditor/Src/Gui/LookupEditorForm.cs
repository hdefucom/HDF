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
    public partial class LookupEditorForm : Form
    {
        ZYLookupEditor zy = null;


        public LookupEditorForm(ZYTextBlock o)
        {
            InitializeComponent();

            labelName.Text = o.Text;
            if (o is ZYLookupEditor)
            {
                zy = (ZYLookupEditor)o;
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


        public string DisplayValues
        {
            get { return lookUpEditor1.DisplayValue; }

        }


        public string NormalWordBook { 
            get {
                if (zy.Wordbook == null || zy.Wordbook == "")
                    return "";
                else
                {
                    Wordbook.BaseWordbook wordbook = Wordbook.WordbookStaticHandle.GetWordbookByName(zy.Wordbook);
                    if (wordbook == null)
                        return "";
                    else
                        return wordbook.ToString();
                }
            } 
        }

        //public void CallWordBook()
        //{

        //    if (lookUpWindow1.SqlHelper == null)
        //        lookUpWindow1.SqlHelper = YidanSoft.Core.DataAccessFactory.DefaultDataAccess;

        //    try
        //    {
        //        Wordbook.BaseWordbook wordbook = Wordbook.WordbookStaticHandle.GetWordbook(wordbookName);
        //        lookUpEditor1.NormalWordbook = wordbook;
        //        this.ShowDialog();
        //    }
        //    catch
        //    {


        //    }

        //}



        private void buttonOK_Click(object sender, EventArgs e)
        {
            zy.CodeValue = lookUpEditor1.CodeValue;
            zy.Text = lookUpEditor1.DisplayValue;
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
            if (string.IsNullOrEmpty(zy.Wordbook))
            {
                return;
            }
           

            try
            {
                if (zy.Multi)//默认可以最多选择20个记录
                    lookUpEditor1.MaxCount = 20;
                Wordbook.BaseWordbook wordbook = Wordbook.WordbookStaticHandle.GetWordbookByName(zy.Wordbook);
                lookUpEditor1.NormalWordbook = wordbook;
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
