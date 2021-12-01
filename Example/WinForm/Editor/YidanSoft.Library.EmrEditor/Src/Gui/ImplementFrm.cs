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
using YidanSoft.Library.EmrEditor.Src.Common;
//using WeifenLuo.WinFormsUI.Docking.DockPanel;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    public partial class ImplementFrm : Form
    {
        ZYSelectableElement _ele;
            
        public ImplementFrm(ZYSelectableElement e)
        {
            InitializeComponent();
            //MessageBox.Show("InitializeComponent()OK");
            _ele = e;
            this.labelName.Text = e.Name;

            //初始化选项
            this.listView1.Items.Clear();
            this.listView1.Columns[0].Width = this.Width - 15;

            Graphics graph = this.CreateGraphics();

            ListViewItem item = null;

            if (e.Type == ElementType.SingleElement)
            {
                this.listView1.CheckBoxes = false;
                this.checkBox1.Visible = false;
            }
            else
            {
                this.listView1.CheckBoxes = true;
                this.checkBox1.Visible = true;
            }

            foreach (ZYSelectableElementItem sub in e.SelectList)
            {

                item = new ListViewItem(sub.InnerValue);

                //初始化选中项
                if (e.Type == ElementType.SingleElement)
                {
                    item.Selected = sub.IsSelected;
                }
                else
                {
                    item.Checked = sub.IsSelected;
                }


                string groupName = sub.Group;
                bool exist = false;
            //有分组的情况
                foreach (ListViewGroup g in this.listView1.Groups)
                {
                    if (g.Name == groupName)
                    {
                        item.Group = g;
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    ListViewGroup g = new ListViewGroup(groupName, groupName);
                    this.listView1.Groups.Add(g);
                    item.Group = g;
                }

                    float width = graph.MeasureString(item.Text, this.listView1.Font).Width;

                    //只有在内容超过可显示的范围时，才加ToolTipText，
                    if (width > this.listView1.Columns[0].Width)
                    {
                        item.ToolTipText = item.Text;
                    }

                    this.listView1.Items.Add(item);
            }
            graph.Dispose();
            //MessageBox.Show("初始化所有选项 OK");

            //MessageBox.Show("初始化选中项OK");
            //合理化高度,使列表中不显示空白
            if (this.listView1.Items.Count > 0)
            {
                int opheight = this.listView1.Items.Count * this.listView1.Items[0].Bounds.Height + 100;

                if (opheight > this.MaximumSize.Height)
                {
                    this.listView1.Columns[0].Width = this.Width - SystemInformation.VerticalScrollBarWidth - 15;
                }
                this.Height = opheight;
            }
            else
            {
                this.Height = 100;
            }

            //合理化窗口位置

            //编辑窗口的绝对位置
            Rectangle AbsolutEditorWinRect = e.OwnerDocument.OwnerControl.ClientRectangle;
            AbsolutEditorWinRect.Location = e.OwnerDocument.OwnerControl.PointToScreen(e.OwnerDocument.OwnerControl.ClientRectangle.Location);

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
                    x =   AbsolutEditorWinRect.Right - AbsolutHelpWinRect.Right;
                }
                //调整垂直位置
                if (AbsolutHelpWinRect.Bottom  > AbsolutEditorWinRect.Bottom )
                {
                    y =  -AbsolutHelpWinRect.Height;
                }

                AbsolutHelpWinRect.Offset(x, y);
            }

            Debug.WriteLine("EditorWinAbsolutRect " + AbsolutHelpWinRect);
            this.Location = AbsolutHelpWinRect.Location;

            //MessageBox.Show("ImplementFrm OK");

            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
        }

        public ImplementFrm(string e)
        {
        }
        public static ListViewItem ParseListViewItem(string s,ListView lv)
        {
            int start = s.IndexOf('<');
            int end = s.IndexOf('>');
            ListViewItem item = null;
            //有分组的情况
            if (start >= 0 && end >= 0 && start < end)
            {
                item = new ListViewItem(s.Substring(0, start));

                string groupName = s.Substring(start, end - start + 1);
                bool exist = false;
                if (lv != null)
                {
                    foreach (ListViewGroup g in lv.Groups)
                    {
                        if (g.Name == groupName)
                        {
                            item.Group = g;
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        ListViewGroup g = new ListViewGroup(groupName, groupName);
                        lv.Groups.Add(g);
                        item.Group = g;
                    }
                }

            }
            else
            {
                item = new ListViewItem(s);
                item.Group = null;
            }
            return item;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImplementFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ImplementFrm_Load(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //确定按钮
            //根据选项，生成要插入到文档中的内容
            //_ele.Width = 0;
            //_ele.Value = "";

            foreach (ZYSelectableElementItem item in _ele.SelectList)
            {
                item.IsSelected = false;
            }

            if (_ele.Type == ElementType.SingleElement)
            {
                foreach (int i in this.listView1.SelectedIndices)
                {
                    _ele.SelectList[i].IsSelected = true;
                    _ele.CreatorIndex = _ele.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-04 单选、多选和有无选值改变保存修改索引号
                }
            }
            else
            {
                foreach (int i in this.listView1.CheckedIndices)
                {
                    _ele.SelectList[i].IsSelected = true;
                    _ele.CreatorIndex = _ele.OwnerDocument.SaveLogs.CurrentIndex; //add by myc 2014-03-04 单选、多选和有无选值改变保存修改索引号
                }
            }

            _ele.ChildElements.Clear();
            _ele.text = _ele.Text;
            _ele.UpDateText();
            
            //_ele.CreatorIndex = _ele.OwnerDocument.SaveLogs.CurrentIndex;
            //int intMakLevel = _ele.OwnerDocument.GetMarkLevel(_ele.CreatorIndex);
            //if (intMakLevel > 0)
            //{
            //    if (_ele.CreatorIndex > 0 && _ele.OwnerDocument.SaveLogs[_ele.CreatorIndex].Level > 0)//元素的创建者级别大于1时，才显示修改痕迹，否则不显示修改痕迹 Modified by wwj 2013-05-07
            //    {
            //        _ele.OwnerDocument.DrawUnderLine(intMakLevel, _ele.RealLeft, _ele.RealTop, _ele.Width, _ele.Height);
            //    }
            //}  

            _ele.RefreshSize();

            #region add by myc 2014-05-21 双击结构化元素更新值时单元格自适应高度调整
            if (_ele.Parent.Parent is TPTextCell)
            {
                (_ele.Parent.Parent as TPTextCell).AdjustHeight();
            }
            #endregion

            _ele.OwnerDocument.ContentChanged();
            _ele.OwnerDocument.EndUpdate();

            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                item.Checked = this.checkBox1.Checked;
            }
        }


        private void ImplementFrm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            //如果当前是多选，且分组已经改变，那么选择新的分组中的项
            if (_ele.Type == ElementType.MultiElement)
            {            
                List<ListViewGroup> groups = new List<ListViewGroup>();
                //计算已经选中项的分组
                foreach (ListViewItem item in this.listView1.CheckedItems)
                {
                    if (item.Group != null && !groups.Contains(item.Group))
                    {
                        groups.Add(item.Group);
                    }
                }

                //没有选中项或选中项分组为null
                if (groups.Count == 0)
                {
                    if (this.listView1.Items[e.Index].Group == null)
                    {
                    }
                    else
                    {
                        foreach (ListViewItem item in this.listView1.CheckedItems)
                        {
                            item.Checked = false;
                        }
                    }
                }
                else
                {
                    if (groups.Contains(this.listView1.Items[e.Index].Group))
                    {
                    }
                    else
                    {
                        foreach (ListViewItem item in this.listView1.CheckedItems)
                        {
                            item.Checked = false;
                        }
                    }
                }
                
            }//if多选
        }

    }
}
