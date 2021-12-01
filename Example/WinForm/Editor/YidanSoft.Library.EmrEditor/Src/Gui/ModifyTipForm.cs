using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using YidanSoft.Library.EmrEditor.Src.Document;
using ZYTextDocumentLib;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// Add by wwj 
    /// 修改痕迹显示界面，在三级检诊中对于被删除或新增的元素显示详细的修改人和修改时间。
    /// 左键双击修改痕迹处，即在其下方显示修改人，修改时间，修改类型等信息
    /// 例如： 
    ///     【张三】增加，时间：2011-11-11 11:34:04 或 【张三】删除，时间：2011-11-11 11:34:04
    /// </summary>
    public partial class ModifyTipForm : Form
    {
        ZYTextElement m_ele = null;
        /// <summary>
        /// 提示信息
        /// </summary>
        string m_MessageContent = string.Empty;

        Color m_ShowColor;

        public ModifyTipForm(ZYTextElement e, ZYTextSaveLog saveLog)
        {
            InitializeComponent();
            m_ele = e;
            if (e.DeleterIndex != -1)//被删除的元素提示
            {
                m_MessageContent = "【" + saveLog.UserName + "】" + "删除，时间：" + saveLog.DisplayDateTime;
                m_ShowColor = Color.FromKnownColor(KnownColor.Red);//“删除”用红色显示
            }
            else //被新增的元素提示
            {
                //m_MessageContent = "【" + saveLog.UserName + "】" + "新增，时间：" + saveLog.DisplayDateTime;
                m_ShowColor = Color.FromKnownColor(KnownColor.Blue);//“新增”用蓝色显示
            }
            this.Width = TextRenderer.MeasureText(m_MessageContent, this.Font).Width + 20;
            SetShowPosition();
        }

        /// <summary>
        /// 合理化窗口位置
        /// </summary>
        private void SetShowPosition()
        {
            ZYTextElement e = m_ele;

            //编辑窗口的绝对位置
            Rectangle AbsolutEditorWinRect = e.OwnerDocument.OwnerControl.ClientRectangle;
            AbsolutEditorWinRect.Location = e.OwnerDocument.OwnerControl.PointToScreen(e.OwnerDocument.OwnerControl.ClientRectangle.Location);

            //弹出窗口绝对位置
            Rectangle AbsolutHelpWinRect = this.Bounds;
            
            AbsolutHelpWinRect.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y + 10);
            
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

            this.Location = AbsolutHelpWinRect.Location;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            if (m_MessageContent == string.Empty) return;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(m_MessageContent, this.Font, new SolidBrush(m_ShowColor), new RectangleF(0f, 2f, this.Width, this.Height), sf);
        }

        private void ModifyTipForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 判断是否显示修改痕迹详细信息的逻辑,供外部调用。
        /// 现在供ZYTextChar、ZTTextBlock调用，ZYTextChar类中用于对自由文本的逻辑判断，ZYTextBlock类中用于结构化元素的逻辑判断
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool ShowModifyTipFormLogic(ZYTextElement ele, int x, int y)
        {
            //Add By wwj 2011-09-30 在三级检诊中对于被删除或新增的元素显示详细的修改人和修改时间
            if ((ele.Deleteted || ele.DeleterIndex != -1 || ele.CreatorIndex != -1) /*元素有变更*/ && ele.Bounds.Contains(x, y) /*鼠标点击的当前元素*/)
            {
                ZYTextSaveLogCollection saveLogs = ele.OwnerDocument.SaveLogs;
                if (saveLogs.Count > ele.DeleterIndex && saveLogs.Count > ele.CreatorIndex)
                {
                    ZYTextSaveLog saveLog;
                    if (ele.DeleterIndex != -1)
                    {
                        saveLog = saveLogs[ele.DeleterIndex];
                    }
                    else
                    {
                        saveLog = saveLogs[ele.CreatorIndex];
                    }
                    if (saveLog.Level > 0)
                    {
                        ModifyTipForm modifyTipForm = new ModifyTipForm(ele, saveLog);
                        modifyTipForm.Show();
                        return true;
                    }
                }
            }
            return false;
        }


        #region 三级检诊痕迹保留功能提示界面新配置 add by myc 2014-03-05
        public ModifyTipForm(ZYTextElement e, ZYTextSaveLog saveLog, Point pMouse)
        {
            InitializeComponent();
            m_ele = e;
            if (e.DeleterIndex != -1)//被删除的元素提示
            {
                m_MessageContent = "【" + saveLog.UserName + "】" + "删除，时间：" + saveLog.DisplayDateTime;
                m_ShowColor = Color.FromKnownColor(KnownColor.Red);//“删除”用红色显示
            }
            else //被新增的元素提示
            {
                //m_MessageContent = "【" + saveLog.UserName + "】" + "新增，时间：" + saveLog.DisplayDateTime;

                if (e.Parent is ZYTextBlock || e is ZYCheckBox || e is ZYMensesFormula || e is ZYToothCheck) //add by myc 2014-03-04
                {
                    m_MessageContent = "【" + saveLog.UserName + "】" + "修改，时间：" + saveLog.DisplayDateTime;
                }
                else
                {
                    m_MessageContent = "【" + saveLog.UserName + "】" + "新增，时间：" + saveLog.DisplayDateTime;
                }

                m_ShowColor = Color.FromKnownColor(KnownColor.Blue);//“新增”用蓝色显示
            }
            this.Width = TextRenderer.MeasureText(m_MessageContent, this.Font).Width + 20;
            SetLocationPosition(pMouse);
        }

        /// <summary>
        /// 合理化窗口位置
        /// </summary>
        private void SetLocationPosition(Point pMouse)
        {
            ZYTextElement e = m_ele;

            //编辑窗口的绝对位置
            Rectangle AbsolutEditorWinRect = e.OwnerDocument.OwnerControl.ClientRectangle;
            AbsolutEditorWinRect.Location = e.OwnerDocument.OwnerControl.PointToScreen(e.OwnerDocument.OwnerControl.ClientRectangle.Location);

            //弹出窗口绝对位置
            Rectangle AbsolutHelpWinRect = this.Bounds;

            AbsolutHelpWinRect.Location = new Point(pMouse.X, pMouse.Y + 10);

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

            this.Location = AbsolutHelpWinRect.Location;
        }


        public static bool ShowModifyTipFrmLogic(ZYTextElement ele, Point pMouse, Point pElement)
        {
            //Add By wwj 2011-09-30 在三级检诊中对于被删除或新增的元素显示详细的修改人和修改时间
            if ((ele.Deleteted || ele.DeleterIndex != -1 || ele.CreatorIndex != -1) /*元素有变更*/ && ele.Bounds.Contains(pElement.X, pElement.Y) /*鼠标点击的当前元素*/)
            {
                ZYTextSaveLogCollection saveLogs = ele.OwnerDocument.SaveLogs;
                if (saveLogs.Count > ele.DeleterIndex && saveLogs.Count > ele.CreatorIndex)
                {
                    ZYTextSaveLog saveLog;
                    if (ele.DeleterIndex != -1)
                    {
                        saveLog = saveLogs[ele.DeleterIndex];
                    }
                    else
                    {
                        saveLog = saveLogs[ele.CreatorIndex];
                    }
                    if (saveLog.Level > 0)
                    {
                        ModifyTipForm modifyTipForm = new ModifyTipForm(ele, saveLog, pMouse);
                        modifyTipForm.Show();
                        return true;
                    }
                }
            }
            return false;
        } 
        #endregion



    }
}