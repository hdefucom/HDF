using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Document;

namespace YidanSoft.Library.EmrEditor.Src.Actions
{
    ///// <summary>
    ///// 设置续打动作
    ///// </summary>
    //public class A_EnableJumpPrint : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "enablejumpprint";
    //    }
    //    public override bool Execute()
    //    {
    //        myOwnerDocument.EnableJumpPrint = !myOwnerDocument.EnableJumpPrint;
    //        myOwnerDocument.Refresh();
    //        return true;
    //    }
    //    public override int CheckState()
    //    {
    //        if (myOwnerDocument.EnableJumpPrint)
    //            return 1;
    //        return 0;
    //    }
    //}

    /// <summary>
    /// 打印文档动作
    /// </summary>
    public class A_PrintDocument : ZYEditorAction
    {
        //public override string ActionName()
        //{
        //    return "printdocument";
        //}
        public override bool Execute()
        {
            return myOwnerDocument._Print();
        }
    }

    ///// <summary>
    ///// 设置文档页面设置动作
    ///// </summary>
    //public class A_PageSetting : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "pagesetting";
    //    }
    //    public override bool Execute()
    //    {
    //        using (XDesignerPrinting.dlgPageSetup dlg = new XDesignerPrinting.dlgPageSetup())
    //        {
    //            dlg.PageSettings = myOwnerDocument.Pages.PageSettings;
    //            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    //            {
    //                myOwnerDocument.Pages.PageSettings = dlg.PageSettings;
    //                myOwnerDocument.RefreshLine();
    //                myOwnerDocument.RefreshPages();
    //                myOwnerDocument.OwnerControl.UpdatePages();
    //                myOwnerDocument.Refresh();
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //}
    ///// <summary>
    ///// 设置文档显示区域的以象素为单位打大小，动作名称 setpagesize ,
    ///// </summary>
    //public class A_SetPageSize : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "setpagesize";
    //    }
    //    public override bool Execute()
    //    {
    //        myOwnerDocument.Pages.CustomPageSize = true;
    //        myOwnerDocument.Pages.LeftMargin = 0;
    //        myOwnerDocument.Pages.TopMargin = 0;
    //        myOwnerDocument.Pages.RightMargin = 0;
    //        myOwnerDocument.Pages.BottomMargin = 0;
    //        myOwnerDocument.Pages.PaperWidth = Convert.ToInt32(Param1);
    //        myOwnerDocument.Pages.PaperHeight = Convert.ToInt32(Param2);
    //        myOwnerDocument.RefreshLine();
    //        myOwnerDocument.UpdateView();
    //        return true;
    //    }
    //}

    ///// <summary>
    ///// 删除文档中空白行,动作名称 removeblankline
    ///// </summary>
    //public class A_RemoveBlankLine : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "removeblankline";
    //    }
    //    public override bool Execute()
    //    {
    //        myOwnerDocument.RemoveBlankLine();
    //        return true;
    //    }
    //}

    ///// <summary>
    ///// 删除文档中所有的空白关键输入域及其周围的字符,动作名称 removeblankkeyfield
    ///// </summary>
    //public class A_RemoveBlankKeyField : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "removeblankkeyfield";
    //    }
    //    public override bool isEnable()
    //    {
    //        return myOwnerDocument.CanModify();
    //    }
    //    public override bool UIExecute()
    //    {
    //        if (System.Windows.Forms.MessageBox.Show(null, "是否真的删除空白的数据域及其周围的字符?", "系统提问", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
    //        {
    //            myOwnerDocument.RemoveBlankKeyField(true);
    //            return true;
    //        }
    //        return false;
    //    }
    //    public override bool Execute()
    //    {
    //        myOwnerDocument.RemoveBlankKeyField(true);
    //        return true;
    //    }
    //}

    ///// <summary>
    ///// 设置纸张大小的动作,动作名称 pagesize
    ///// </summary>
    //public class A_PageSize : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "pagesize";
    //    }

    //}

    ///// <summary>
    ///// 设置当前科室编号,命令名为ownersection，参数1为当前科室的编号
    ///// </summary>
    //public class A_OwnerSection : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "ownersection";
    //    }
    //    public override bool Execute()
    //    {
    //        if (StringCommon.isBlankString(Param1))
    //            Param1 = null;
    //        else
    //            Param1 = Param1.Trim();
    //        if (OwnerDocument.KBBuffer != null)
    //        {
    //            OwnerDocument.KBBuffer.OwnerSection = Param1;
    //        }
    //        return true;
    //    }
    //}// class A_OwnerSection




    ///// <summary>
    ///// 设置文本编辑器背景颜色的动作对象,命令名称setbackcolor,参数1为Hxxxxxx格式的表示颜色的字符串
    ///// </summary>
    //public class A_SetBackColor : ZYEditorAction
    //{
    //    public override bool Execute()
    //    {
    //        myOwnerDocument.OwnerControl.BackColor = StringCommon.ColorFromHtml(Param1, System.Drawing.SystemColors.Window);
    //        myOwnerDocument.OwnerControl.Refresh();
    //        return true;
    //    }
    //}// class A_SetBackColor

    /// <summary>
    /// 切换文档的设计，运行模式的动作对象,动作名称designmode
    /// </summary>
    public class A_DesignMode : ZYEditorAction
    {
        //public override string ActionName()
        //{
        //    return "designmode";
        //}
        public override bool isEnable()
        {
            return true;
        }
        public override bool Execute()
        {
            myOwnerDocument.Info.DesignMode = !myOwnerDocument.Info.DesignMode;
            myOwnerDocument.RefreshElements();
            myOwnerDocument.RefreshLine();
            myOwnerDocument.UpdateView();
            return true;
        }
        public override int CheckState()
        {
            return myOwnerDocument.Info.DesignMode ? 1 : 0;
        }
    }// class A_DesignMode

    ///// <summary>
    ///// 向文档当前位置插入字符串的动作对象,动作名称insertstring
    ///// </summary>
    //public class A_InsertString : ZYEditorAction
    //{
    //    public override string ActionName()
    //    {
    //        return "insertstring";
    //    }
    //    public override bool isEnable()
    //    {
    //        if (myOwnerDocument.CanModify())
    //            return base.isEnable();
    //        else
    //            return false;
    //    }
    //    public override bool Execute()
    //    {
    //        //myOwnerDocument.BeginContentChangeLog();
    //        myOwnerDocument.BeginUpdate();
    //        myOwnerDocument.Content.InsertString(this.Param1);
    //        myOwnerDocument.EndUpdate();
    //        //myOwnerDocument.EndContentChangeLog();
    //        return true;
    //    }
    //}//class A_InsertString

    /// <summary>
    /// 撤销操作对象
    /// </summary>
    public class A_Undo : ZYEditorAction
    {
        /// <summary>
        /// 对象命令名称 undo
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// 已重载:文档可改变且文档对象撤销操作列表不为空则动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            if (myOwnerDocument.CanModify() && myOwnerDocument.UndoStack.UndoItemCount > 0)
                return base.isEnable();
            else
                return false;
        }
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument._Undo();
            return true;
        }
 

    }// class A_Undo

    /// <summary>
    /// 重复操作对象
    /// </summary>
    public class A_Redo : ZYEditorAction
    {

        /// <summary>
        /// 当文档可以修改且重复列表不为空则动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            if (myOwnerDocument.CanModify() && myOwnerDocument.UndoStack.RedoItemCount > 0)
                return base.isEnable();
            else
                return false;
        }
        /// <summary>
        /// 已重载:执行重复操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            return myOwnerDocument._Redo();
        }

    }// class A_Redo
    /// <summary>
    /// 显示段落标记动作
    /// </summary>
    /// <remarks>本动作设置文档对象<link>ZYTextDocumentLib.ZYTextDocument.ShowParagraphFlag</link>属性并重绘文档</remarks>
    /// <desc command="showparagraphflag">可显示或隐藏文档中段落标记和行标记</desc>
    public class A_ShowParagraphFlag : ZYEditorAction
    {
        public A_ShowParagraphFlag(bool showParagraphFlag)
        {
            isShowParagraphFlag = showParagraphFlag;
        }
        private bool isShowParagraphFlag = true;

        public bool IsShowParagraphFlag
        {
            get { return isShowParagraphFlag; }
            set { isShowParagraphFlag = value; }
        }
       
        ///// <summary>
        ///// 动作没把命令名称 showparagraphflag
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "showparagraphflag";
        //}
        /// <summary>
        /// 设置文档对象的ShowParagraphFlag属性，然后重新绘制文档
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1显示段落标记
            //myOwnerDocument.Info.ShowParagraphFlag = (Param1 == "1");
            myOwnerDocument.Info.ShowParagraphFlag = (isShowParagraphFlag);
            myOwnerDocument.Refresh();
            return true;
        }
        /// <summary>
        /// 返回文档对象的ShowParagraphFlag属性
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            return myOwnerDocument.Info.ShowParagraphFlag ? 1 : 0;
        }
    }

    /// <summary>
    /// 设置用户界面为页面视图方式的动作
    /// </summary>
    /// <remarks>本动作设置文档所在的编辑控件的页面显示模式标记,并重新分页,绘制文档</remarks>
    /// <desc command="pageviewmode">让编辑框在普通显示模式和页面显示模式间切换</desc>
    public class A_PageViewMode : ZYEditorAction
    {
        ///// <summary>
        ///// 动作内部命令名称 pageviewmode
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "pageviewmode";
        //}
        
        public A_PageViewMode(bool mode)
        {
            bolMode = mode;
        }
        private bool bolMode = true;

        public bool BolMode
        {
            get { return bolMode; }
            set { bolMode = value; }
        }

        /// <summary>
        /// 设置编辑器的页面视图模式,重新分页和绘制
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (myOwnerDocument.OwnerControl != null)
            {
                //TODO: Param1 设置编辑器的页面视图模式,重新分页和绘制
                //bool bolMode = (Param1 == "1");
                //bool bolMode = true;
                //myOwnerDocument.OwnerControl.PageViewMode = bolMode ;
                myOwnerDocument.RefreshLine();
                if (bolMode)
                    myOwnerDocument.OwnerControl.UpdatePages();
                else
                    myOwnerDocument.UpdateView();
                myOwnerDocument.Refresh();
                myOwnerDocument.OwnerControl.UpdateTextCaret();
            }
            return true;
        }
        /// <summary>
        /// 返回编辑器的页面视图模式状态
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            return 1;
            //			if( myOwnerDocument.OwnerControl != null)
            //				return myOwnerDocument.OwnerControl.PageViewMode ? 1: 0;
            //			else
            //				return -1 ;
        }
    }




    /// <summary>
    /// 上翻页动作
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._PageUp</seealso>
    public class A_PageUp : ZYEditorAction
    {
        ///// <summary>
        ///// 动作内部名称 pageup
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "pageup";
        //}
        /// <summary>
        /// 将插入点向上移动一页
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._PageUp();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 PageUp 键
        /// </summary>
        //public A_PageUp()
        //{
        //    HotKey = System.Windows.Forms.Keys.PageUp;
        //}
    }

    /// <summary>
    /// 带 Shift 键的上翻页动作
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._PageUp</seealso>
    public class A_ShiftPageUp : ZYEditorAction
    {
        ///// <summary>
        ///// 命令名称 shiftpageup
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftpageup";
        //}
        /// <summary>
        /// 执行不带清除选择区域的上翻页
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._PageUp();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 Shfit+PageUp
        /// </summary>
        //public A_ShiftPageUp()
        //{
        //    HotKey = System.Windows.Forms.Keys.PageUp | System.Windows.Forms.Keys.Shift;
        //}
    }

    /// <summary>
    /// 下翻页动作对象
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._PageDown</seealso>
    public class A_PageDown : ZYEditorAction
    {
        ///// <summary>
        ///// 命令名称 pagedown
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "pagedown";
        //}

        /// <summary>
        /// 执行带清除选择状态的下翻页
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._PageDown();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为PageDown
        /// </summary>
        //public A_PageDown()
        //{
        //    HotKey = System.Windows.Forms.Keys.PageDown;
        //}
    }
    /// <summary>
    /// 带 shift 键的下翻页动作
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._PageDown</seealso>
    public class A_ShiftPageDown : ZYEditorAction
    {
        ///// <summary>
        ///// 名称名称 shiftpagedown
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftpagedown";
        //}
        /// <summary>
        /// 执行带选择状态的下翻页
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._PageDown();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 Shift+PageDown
        /// </summary>
        //public A_ShiftPageDown()
        //{
        //    HotKey = System.Windows.Forms.Keys.PageDown | System.Windows.Forms.Keys.Shift;
        //}
    }

    /// <summary>
    /// 上移动作
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._MoveUp</seealso>
    public class A_MoveUp : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称名称 moveup
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "moveup";
        //}
        /// <summary>
        /// 若当前选择元素为下拉列表则弹出下拉列表,否则插入点下移一行
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            ZYTextElement myElement = (myOwnerDocument.Content.SelectLength < 0) ? myOwnerDocument.Content.PreElement : myOwnerDocument.Content.CurrentElement;
            //ZYTextSelect mySelect = myElement as ZYTextSelect;
            //if (mySelect == null)
            //    mySelect = myElement.Parent as ZYTextSelect;
            //if (mySelect != null)
            //{
            //    if (mySelect.ContainsElements(myOwnerDocument.Content.GetSelectElements()))
            //    {
            //        mySelect.PopupList();
            //        return true;
            //    }
            //}
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._MoveUp();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为上光标键
        /// </summary>
        //public A_MoveUp()
        //{
        //    HotKey = System.Windows.Forms.Keys.Up;
        //}
    }
    /// <summary>
    /// 移动到行首动作
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._MoveHome</seealso>
    public class A_MoveHome : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 movehome
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "movehome";
        //}
        /// <summary>
        /// 移动插入点到当前的行首
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._MoveHome();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 home 键
        /// </summary>
        //public A_MoveHome()
        //{
        //    HotKey = System.Windows.Forms.Keys.Home;
        //}
    }
    /// <summary>
    /// 带 Shift 的移动到行尾
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._MoveHome</seealso>
    public class A_ShiftMoveHome : ZYEditorAction
    {
        ///// <summary>
        ///// 动作命令名称 shiftmovehome
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftmovehome";
        //}
        /// <summary>
        /// 带选择的将插入点移到行首
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._MoveHome();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 Shift+Home
        /// </summary>
        //public A_ShiftMoveHome()
        //{
        //    HotKey = System.Windows.Forms.Keys.Home | System.Windows.Forms.Keys.Shift;
        //}
    }
    /// <summary>
    /// 移动到行尾动作对象
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._MoveEnd</seealso>
    public class A_MoveEnd : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 moveend
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "moveend";
        //}
        /// <summary>
        /// 移动插入点到行尾
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._MoveEnd();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为end
        /// </summary>
        //public A_MoveEnd()
        //{
        //    HotKey = System.Windows.Forms.Keys.End;
        //}
    }

    /// <summary>
    /// 带 Shift 键的移动到行尾的动作对象
    /// </summary>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument._MoveEnd</seealso>
    public class A_ShiftMoveEnd : ZYEditorAction
    {
        ///// <summary>
        ///// 动作命令名称 shiftmoveend
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftmoveend";
        //}
        /// <summary>
        /// 带选择的将插入点移动到行尾
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._MoveEnd();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 shift+end
        /// </summary>
        //public A_ShiftMoveEnd()
        //{
        //    HotKey = System.Windows.Forms.Keys.End | System.Windows.Forms.Keys.Shift;
        //}
    }
    /// <summary>
    /// 带shift键的上移一行的动作
    /// </summary>
    public class A_ShiftMoveUp : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 shiftmoveup
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftmoveup";
        //}
        /// <summary>
        /// 将插入点上一一行
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._MoveUp();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 Shift+上光标键
        /// </summary>
        //public A_ShiftMoveUp()
        //{
        //    HotKey = System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Shift;
        //}
    }

    /// <summary>
    /// 带有Ctl键的下光标键
    /// </summary>
    public class A_CtlMoveDown : ZYEditorAction
    {
    //    public override string ActionName()
    //    {
    //        return "ctlmovedown";
    //    }
        public override bool isEnable()
        {
            if (myOwnerDocument.Content.CurrentElement != null)
            {
                //ZYTextSelect mySelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
                //if (mySelect == null)
                //    mySelect = myOwnerDocument.Content.CurrentElement.Parent as ZYTextSelect;
                //if (mySelect != null && mySelect.Parent.Locked == false)
                //    return true;
            }
            return false;
        }
        public override bool Execute()
        {
            if (myOwnerDocument.Content.CurrentElement != null)
            {
                //ZYTextSelect mySelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
                //if (mySelect == null)
                //    mySelect = myOwnerDocument.Content.CurrentElement.Parent as ZYTextSelect;
                //if (mySelect != null)
                //{
                //    mySelect.PopupList();
                //    return true;
                //}
            }
            return false;
        }
        //public A_CtlMoveDown()
        //{
        //    HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down;
        //}
    }// class A_CtlMoveDown



    /// <summary>
    /// 带有Ctl键的下光标键
    /// </summary>
    public class A_CtlMoveUp : ZYEditorAction
    {
        //public override string ActionName()
        //{
        //    return "ctlmoveup";
        //}
        public override bool isEnable()
        {
            if (myOwnerDocument.Content.CurrentElement != null)
            {
                //ZYTextSelect mySelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
                //if (mySelect == null)
                //    mySelect = myOwnerDocument.Content.CurrentElement.Parent as ZYTextSelect;
                //if (mySelect != null && mySelect.Parent.Locked == false)
                //    return true;
            }
            return false;
        }
        public override bool Execute()
        {
            if (myOwnerDocument.Content.CurrentElement != null)
            {
                //ZYTextSelect mySelect = myOwnerDocument.Content.CurrentElement as ZYTextSelect;
                //if (mySelect == null)
                //    mySelect = myOwnerDocument.Content.CurrentElement.Parent as ZYTextSelect;
                //if (mySelect != null)
                //{
                //    mySelect.PopupList();
                //    return true;
                //}
            }
            return false;
        }
        //public A_CtlMoveUp()
        //{
        //    HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up;
        //}
    }// class A_CtlMoveUp

    /// <summary>
    /// 下移动作
    /// </summary>
    public class A_MoveDown : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称  movedown
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "movedown";
        //}
        /// <summary>
        /// 若当前选择的元素为下拉式列表则弹出下拉式列表,否则移动插入点到下一行
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            ZYTextElement myElement = (myOwnerDocument.Content.SelectLength < 0) ? myOwnerDocument.Content.PreElement : myOwnerDocument.Content.CurrentElement;
            //ZYTextSelect mySelect = myElement as ZYTextSelect;
            //if (mySelect == null)
            //    mySelect = myElement.Parent as ZYTextSelect;
            //if (mySelect != null)
            //{
            //    if (mySelect.ContainsElements(myOwnerDocument.Content.GetSelectElements()))
            //    {
            //        mySelect.PopupList();
            //        return true;
            //    }
            //}
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._MoveDown();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 下光标键
        /// </summary>
        //public A_MoveDown()
        //{
        //    HotKey = System.Windows.Forms.Keys.Down;
        //}
    }
    /// <summary>
    /// 带 shift 键的下移一行的动作
    /// </summary>
    public class A_ShiftMoveDown : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 shiftmovedown
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftmovedown";
        //}
        /// <summary>
        /// 指定带选择的移动插入点到下一行
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._MoveDown();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 Shift+下光标键
        /// </summary>
        //public A_ShiftMoveDown()
        //{
        //    HotKey = System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Shift;
        //}
    }
    /// <summary>
    /// 向左移动动作
    /// </summary>
    public class A_MoveLeft : ZYEditorAction
    {
        ///// <summary>
        ///// 命令名称 moveleft
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "moveleft";
        //}
        /// <summary>
        /// 将插入点将前移动一个元素
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._MoveLeft();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 左光标键
        /// </summary>
        //public A_MoveLeft()
        //{
        //    HotKey = System.Windows.Forms.Keys.Left;
        //}
    }
    /// <summary>
    /// 带 shift 键的向左移动作
    /// </summary>
    public class A_ShiftMoveLeft : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 shiftmoveleft
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftmoveleft";
        //}
        /// <summary>
        /// 带选择的向前移动插入点
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._MoveLeft();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 Shift+左光标键
        /// </summary>
        //public A_ShiftMoveLeft()
        //{
        //    HotKey = System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Shift;
        //}
    }
    /// <summary>
    /// 向右移动动作
    /// </summary>
    public class A_MoveRight : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 moveright
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "moveright";
        //}
        /// <summary>
        /// 向后移动插入点
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = true;
            myOwnerDocument._MoveRight();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为 右光标键
        /// </summary>
        //public A_MoveRight()
        //{
        //    HotKey = System.Windows.Forms.Keys.Right;
        //}
    }
    /// <summary>
    /// 带 shift 键的向右移动动作
    /// </summary>
    public class A_ShiftMoveRight : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 shiftmoveright
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "shiftmoveright";
        //}
        /// <summary>
        /// 带选择的向后移动插入点
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.AutoClearSelection = false;
            myOwnerDocument._MoveRight();
            return true;
        }

        /// <summary>
        /// 初始化对象,设置快捷键为Shift+右光标键
        /// </summary>
        //public A_ShiftMoveRight()
        //{
        //    HotKey = System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Shift;
        //}
    }

    /// <summary>
    /// 删除选择区域的动作
    /// </summary>
    public class A_Delete : ZYEditorAction
    {
        ///// <summary>
        ///// 命令名称 delete
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "delete";
        //}
        /// <summary>
        /// 文档可改变动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 删除当前选中的元素或者插入点后的元素
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            #region add by myc 2014-06-12 注释和添加原因：没有考虑到选中区域边界上的回车符删除和一个字符时也能被选中的问题
            ////add by wwj 2012-04-24 如果选中多个元素，在按下Delete按钮后执行Backspace同样的操作
            //if (Math.Abs(myOwnerDocument.Content.SelectLength) > 1)
            //{
            //    myOwnerDocument._BackSpace(true);
            //}
            //else
            //{
            //    myOwnerDocument._Delete(true);
            //} 

            if (Math.Abs(myOwnerDocument.Content.SelectLength) >= 1)
            {
                myOwnerDocument._BackSpace(true);
            }
            else
            {
                myOwnerDocument._Delete(true);
            } 
            #endregion
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 Delete键
        /// </summary>
        //public A_Delete()
        //{
        //    HotKey = System.Windows.Forms.Keys.Delete;
        //}
    }
    /// <summary>
    /// 退格键处理
    /// </summary>
    public class A_BackSpace : ZYEditorAction
    {
        /// <summary>
        /// 本动作只能在键盘按下事件中调用
        /// </summary>
        /// <returns></returns>
        //public override bool CanHandleKeyDown()
        //{
        //    return false;
        //}

        ///// <summary>
        ///// 动作名称 backspace
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "backspace";
        //}
        /// <summary>
        /// 文档可改变时该动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        public string UsId = null;//签名图片对应的用户id
        /// <summary>
        /// 删除当前选择的元素或者删除插入点前的元素
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument._BackSpace(true);
            UsId = myOwnerDocument.UsId;
            return true;
        }

        /// <summary>
        /// UsId
        /// </summary>
        /// <returns></returns>
        public  string GetUsId()
        {
            return UsId;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 退格键
        /// </summary>
        //public A_BackSpace()
        //{
        //    HotKey = System.Windows.Forms.Keys.Back;
        //}
    }
    /// <summary>
    /// 选择所有内容的动作
    /// </summary>
    public class A_SelectAll : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 selectall
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "selectall";
        //}
        /// <summary>
        /// 选择文档中所有的内容
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument._SelectAll();
            return true;
        }

        /// <summary> 
        /// 初始化对象,设置快捷键为Ctl+A
        /// </summary>
        //public A_SelectAll()
        //{
        //    HotKey = System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control;
        //}
    }
    /// <summary>
    /// 剪切动作
    /// </summary>
    /// <desc command="cut">剪切文档中的纯文本</desc>
    public class A_Cut : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 cut
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "cut";
        //}
        /// <summary>
        /// 文档可改变且有选择的元素
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify() && (myOwnerDocument.Content.HasSelected());
        }
        /// <summary>
        /// 复制并删除选择的元素
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument._Cut();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 Ctl+X
        /// </summary>
        //public A_Cut()
        //{
        //    HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X;
        //}
    }
    /// <summary>
    /// 复制动作
    /// </summary>
    /// <desc command="copy">复制文档中的纯文本数据</desc>
    public class A_Copy : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 copy
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "copy";
        //}
        /// <summary>
        /// 文档中存在选择区域则该动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return (myOwnerDocument.Content.HasSelectedText());
        }

        /// <summary>
        /// 执行复制操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument._Copy();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为 Ctl+C
        /// </summary>
        //public A_Copy()
        //{
        //    HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
        //}
    }
    /// <summary>
    /// 粘贴操作
    /// </summary>
    /// <desc command="paste">粘贴纯文本数据</desc>
    public class A_Paste : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称paste
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "paste";
        //}
        /// <summary>
        /// 文档可修改且系统剪切板中有纯文本数据可使用
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify() && ClipboardHandler.CanGetText();
        }
        /// <summary>
        /// 执行粘贴操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument._Paste();
            return true;
        }
        /// <summary>
        /// 初始化对象,设置快捷键为Ctl+V
        /// </summary>
        //public A_Paste()
        //{
        //    HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V;
        //}
    }

    /// <summary>
    /// 设置字体名称
    /// </summary>
    /// <desc command="fontname">设置字体名称</desc>
    public class A_FontName : ZYEditorAction
    {
        public A_FontName() { }
        public A_FontName(string fontname)
        {
            fontName = fontname;
        }
        private string fontName = "";

        public string FontName
        {
            get { return fontName; }
            set { fontName = value; }
        }
       

        /// <summary>
        /// 文档可修改该动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        ///// <summary>
        ///// 动作名称 fontname
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "fontname";
        //}
        /// <summary>
        /// 根据Param1参数设置选择的文本的字体名称
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1 设置字体名称
            //myOwnerDocument.SetSelectioinFontName(Param1);
            myOwnerDocument.SetSelectioinFontName(fontName);
            return true;
        }
        /// <summary>
        /// 复制该对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_FontName f = new A_FontName();//TODO: 这里注意
            f.BaseCloneFrom(this);
            return f;
        }
    }
    /// <summary>
    /// 修改字体大小动作
    /// </summary>
    /// <desc command="fontsize">设置字体大小</desc>
    public class A_FontSize : ZYEditorAction
    {
        public A_FontSize() { }
        public A_FontSize(int fontsize)
        {
            fontSize = fontsize;
        }
        private int fontSize = 0;
        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }
        /// <summary>
        /// 文档可改变时该动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        ///// <summary>
        ///// 动作名称 fontsize
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "fontsize";
        //}
        /// <summary>
        /// 根据Param1参数设置字体大小
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            try
            {
                //TODO: Param1 设置字体大小
                //myOwnerDocument.SetSelectionFontSize(Convert.ToInt32(Param1));
                myOwnerDocument.SetSelectionFontSize(fontSize);
                return true;
            }
            catch
            { }
            return false;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_FontSize f = new A_FontSize();//TODO: 这里注意
            f.BaseCloneFrom(this);
            return f;
        }
    }
    /// <summary>
    /// 设置粗体动作
    /// </summary>
    /// <desc command="bold">设置字体为粗体</desc>
    public class A_FontBold : ZYEditorAction
    {
        private bool boolIsBold = false;
        public bool IsBold
        {
            get { return boolIsBold; }
            set { boolIsBold = value; }
        }
        public A_FontBold(bool isbold)
        {
            boolIsBold = isbold;
        }
        /// <summary>
        /// 文档可改变时该动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        ///// <summary>
        ///// 动作名称bold
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "bold";
        //}
        /// <summary>
        /// 根据参数Param1设置选择区域的字体的粗体属性
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1 设置选择区域的字体的粗体属性
            //myOwnerDocument.SetSelectionFontBold(Param1 == "1");
            myOwnerDocument.SetSelectionFontBold(boolIsBold);
            return true;
        }
        /// <summary>
        /// 返回文档插入点当前元素的字体粗体属性状态
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextChar myChar = myOwnerDocument.Content.GetPreChar();
            if (myChar != null)
                return (myChar.FontBold ? 1 : 0);
            else
                return -1;
        }

        public A_FontBold()
        {
            //HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B ;
        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_FontBold f = new A_FontBold();
            f.BaseCloneFrom(this);
            return f;
        }
    }

    /// <summary>
    /// 设置字体斜体动作
    /// </summary>
    /// <desc command="italic">设置字体为斜体</desc>
    public class A_FontItalic : ZYEditorAction
    {
        private bool boolItalic = false;

        public bool BoolItalic
        {
            get { return boolItalic; }
            set { boolItalic = value; }
        }
        public A_FontItalic(bool isItalic)
        {
            boolItalic = isItalic;
        }
        /// <summary>
        /// 文档可修改时对象有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        ///// <summary>
        ///// 动作名称 italic
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "italic";
        //}
        /// <summary>
        /// 根据 Param1 参数设置文档中选择的文本的字体斜体属性
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1 设置文档中选择的文本的字体斜体属性
            //myOwnerDocument.SetSelectionFontItalic(Param1 == "1");
            myOwnerDocument.SetSelectionFontItalic(boolItalic);
            return true;
        }
        /// <summary>
        /// 返回插入点所在文本元素的字体斜体属性的状态
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextChar myChar = myOwnerDocument.Content.GetPreChar();
            if (myChar != null)
                return (myChar.FontItalic ? 1 : 0);
            else
                return -1;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_FontItalic f = new A_FontItalic();
            f.BaseCloneFrom(this);
            return f;
        }

        public A_FontItalic()
        {
            //HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I ;
        }
    }

    /// <summary>
    /// 设置下划线动作
    /// </summary>
    /// <desc command="bold">设置字体为粗体</desc>
    public class A_FontUnderline : ZYEditorAction
    {
        private bool boolIsUnderLine = false;

        public bool BoolIsUnderLine
        {
            get { return boolIsUnderLine; }
            set { boolIsUnderLine = value; }
        }
        public A_FontUnderline(bool isUnderline)
        {
            boolIsUnderLine = isUnderline;
        }
        
        /// <summary>
        /// 文档可改变时该动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        ///// <summary>
        ///// 动作名称underline
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "underline";
        //}
        /// <summary>
        /// 根据参数Param1设置选择区域的字体的下划线属性
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1 设置选择区域的字体的下划线属性
            //myOwnerDocument.SetSelectionUnderLine(Param1 == "1");
            myOwnerDocument.SetSelectionUnderLine(boolIsUnderLine);
            return true;
        }
        /// <summary>
        /// 返回文档插入点当前元素的字体粗体属性状态
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextChar myChar = myOwnerDocument.Content.GetPreChar();
            if (myChar != null)
                return (myChar.FontUnderLine ? 1 : 0);
            else
                return -1;
        }

        public A_FontUnderline()
        {
            //HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B ;
        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_FontUnderline f = new A_FontUnderline();
            f.BaseCloneFrom(this);
            return f;
        }
    }


    /// <summary>
    /// 设置文本颜色的动作
    /// </summary>
    /// <desc command="forecolor">设置文本颜色</desc>
    public class A_SetForeColor : ZYEditorAction
    {
        /// <summary>
        /// 文档可改变时对象有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        ///// <summary>
        ///// 动作名称 forecolor
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "forecolor";
        //}
        /// <summary>
        /// 根据Param1参数设置选择区域的文本颜色
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //myOwnerDocument.SetSelectionColor(StringCommon.ColorFromHtml(Param1, System.Drawing.SystemColors.WindowText));
            //return true;

            using (System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog())
            {
                dlgColor.FullOpen = true;
                if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    myOwnerDocument.SetSelectionColor(dlgColor.Color);
                }
            }
            return true;
        }

        ///// <summary>
        ///// 弹出一个颜色选择框,根据用户的选择设置选中区域的文本颜色
        ///// </summary>
        ///// <returns></returns>
        //public override bool UIExecute()
        //{
        //    using (System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog())
        //    {
        //        dlgColor.FullOpen = true;
        //        if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            myOwnerDocument.SetSelectionColor(dlgColor.Color);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_SetForeColor f = new A_SetForeColor();
            f.BaseCloneFrom(this);
            return f;
        }
    }
    /// <summary>
    /// 设置为下标动作
    /// </summary>
    public class A_SetSub : ZYEditorAction
    {
        private bool newSub = false;

        public bool NewSub
        {
            get { return newSub; }
            set { newSub = value; }
        }
        public A_SetSub() { }
        public A_SetSub(bool isSub)
        {
            newSub = isSub;
        }
        
        /// <summary>
        /// 文档可改变时对象有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        ///// <summary>
        ///// 动作名称 sub
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "sub";
        //}
        /// <summary>
        /// 根据 Param1 参数设置选择区域的下标属性
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1 设置选择区域的下标属性
            //myOwnerDocument.SetSelectionSub((Param1 == "1"));
            myOwnerDocument.SetSelectionSub(newSub);
            return true;
        }
        /// <summary>
        /// 返回插入点所在元素的下标属性状体
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextChar myChar = myOwnerDocument.Content.CurrentElement as ZYTextChar;
            if (myChar != null)
                return (myChar.Sub ? 1 : 0);
            else
                return -1;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_SetSub f = new A_SetSub();
            f.BaseCloneFrom(this);
            return f;
        }
    }
    /// <summary>
    /// 设置上标动作
    /// </summary>
    public class A_SetSup : ZYEditorAction
    {
        private bool newSup = true;

        public bool NewSup
        {
            get { return newSup; }
            set { newSup = value; }
        }
        public A_SetSup() { }
        public A_SetSup(bool isSup)
        {
            newSup = isSup;
        }

        ///// <summary>
        ///// 对象名称 sup
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "sup";
        //}

        /// <summary>
        /// 文档可改变时对象有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 根据Param1参数设置选择区域的上标属性
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1 设置选择区域的上标属性
            //myOwnerDocument.SetSelectionSup((Param1 == "1"));
            myOwnerDocument.SetSelectionSup(newSup);
            return true;
        }
        /// <summary>
        /// 返回插入点所在的元素的上标属性的状态
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextChar myChar = myOwnerDocument.Content.CurrentElement as ZYTextChar;
            if (myChar != null)
                return (myChar.Sup ? 1 : 0);
            else
                return -1;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_SetSup f = new A_SetSup();
            f.BaseCloneFrom(this);
            return f;
        }
    }

    #region 左,右,居中,两边对齐*******************************************************
    /// <summary>
    /// 设置左对齐动作
    /// </summary>
    /// <desc command="alignleft">设置左对齐</desc>
    public class A_AlignLeft : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 alignleft
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "alignleft";
        //}
        /// <summary>
        /// 文档可改变时动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 设置选择区域覆盖的段落左对齐
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.SetAlign(ParagraphAlignConst.Left);
            return true;
        }
        /// <summary>
        /// 返回插入点所在段落的是否是左对齐
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextParagraph myp = myOwnerDocument.GetOwnerParagraph();
            if (myp != null && myp.Align == ParagraphAlignConst.Left)
                return 1;
            else
                return 0;
        }
    }
    /// <summary>
    /// 设置文档居中对齐动作
    /// </summary>
    /// <desc command="aligncenter">设置居中对齐</desc>
    public class A_AlignCenter : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 aligncenter
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "aligncenter";
        //}
        /// <summary>
        /// 文档可改变是对象有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 设置选择区域覆盖的段落为居中对齐
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.SetAlign(ParagraphAlignConst.Center);
            return true;
        }
        /// <summary>
        /// 返回插入点所在段落是否是居中对齐
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextParagraph myp = myOwnerDocument.GetOwnerParagraph();
            if (myp != null && myp.Align == ParagraphAlignConst.Center)
                return 1;
            else
                return 0;
        }
    }
    /// <summary>
    /// 设置文档右对齐动作
    /// </summary>
    /// <desc command="alignright">设置右对齐</desc>
    public class A_AlignRight : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 alignright
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "alignright";
        //}
        /// <summary>
        /// 文档可修改时对象有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 设置选择区域覆盖的段落为右对齐
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.SetAlign(ParagraphAlignConst.Right);
            return true;
        }
        /// <summary>
        /// 返回当前插入点所在的段落是否是右对齐样式
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextParagraph myp = myOwnerDocument.GetOwnerParagraph();
            if (myp != null && myp.Align == ParagraphAlignConst.Right)
                return 1;
            else
                return 0;
        }
    }// class A_AlignRight
    /// <summary>
    /// 设置文档两边对齐动作
    /// </summary>
    /// <desc command="alignright">设置右对齐</desc>
    public class A_AlignJustify : ZYEditorAction
    {
        ///// <summary>
        ///// 动作名称 alignright
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "alignjustify";
        //}
        /// <summary>
        /// 文档可修改时对象有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 设置选择区域覆盖的段落为右对齐
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.SetAlign(ParagraphAlignConst.Justify);
            return true;
        }
        /// <summary>
        /// 返回当前插入点所在的段落是否是右对齐样式
        /// </summary>
        /// <returns></returns>
        public override int CheckState()
        {
            ZYTextParagraph myp = myOwnerDocument.GetOwnerParagraph();
            if (myp != null && myp.Align == ParagraphAlignConst.Justify)
                return 1;
            else
                return 0;
        }
    }// class A_AlignJustify
    #endregion

    /// <summary>
    /// 执行插入文本块命令
    /// </summary>
    /// <desc command="insertdiv">插入带缩放的文本块</desc>
    public class A_InsertDiv : ZYEditorAction
    {

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public A_InsertDiv() { }
        public A_InsertDiv(string strName)
        {
            name = strName;
        }
        ///// <summary>
        ///// 动作名称 insertdiv
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "insertdiv";
        //}
        /// <summary>
        /// 文档可改变时动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 插入文本块
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //TODO: Param1 插入文本块
            //myOwnerDocument._InsertDiv(Param1);
            myOwnerDocument._InsertDiv(name);
            return true;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_InsertDiv f = new A_InsertDiv(); 
            f.BaseCloneFrom(this);
            return f;
        }
    }
    /// <summary>
    /// 插入字符后进行的动作,动作名称 afterinsertchar
    /// </summary>
    public class A_ContentChanged : ZYEditorAction
    {
        //public static string AfterInsertCharActionName
        //{
        //    get { return "contentchanged"; }
        //}
        //public override string ActionName()
        //{
        //    return AfterInsertCharActionName;
        //}
        //public A_ContentChanged()
        //{
        //    HotKey = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
        //}
        public override bool Execute()
        {
            ZYTextChar myCharElement = myOwnerDocument.Content.PreElement as ZYTextChar;
            if (myCharElement == null || myCharElement.Parent is ZYTextBlock)
                return false;
            //if (myCharElement.Char == '有')
            //{
                //myOwnerDocument.OwnerControl.StaticToolTip = true;
                //myOwnerDocument.OwnerControl.ShowInnerToolTip(2, "按Tab键开始输入症状信息", myCharElement.RealLeft, myCharElement.RealTop, myCharElement.Height);
                //System.Windows.Forms.Application.DoEvents();
                //myOwnerDocument.OwnerControl.UpdateInnerToolTip();
                //if (myOwnerDocument.OwnerControl.WaitForKeyDown((int)System.Windows.Forms.Keys.Tab, true) && myOwnerDocument.OwnerControl.InnerToolTipVisible)
                //{
                //    myOwnerDocument.OwnerControl.HideInnerToolTip();
                //    System.Collections.ArrayList myKBLists = new System.Collections.ArrayList();
                //    myKBLists.AddRange(ZYKBBuffer.Instance.RootList.ChildNodes);
                //    ZYKBBuffer.Instance.OnlyCheckYesNoAttribute = true;
                //    System.Collections.ArrayList myYesNoKB = new System.Collections.ArrayList();
                //    int iCount = 0;
                //    OwnerDocument.OwnerControl.InitKBPopupList();
                //    OwnerDocument.OwnerControl.KBPopupList.EnableSearchKBDynamic = false;
                //    while (true)
                //    {
                //        int intResult = -1;
                //        myYesNoKB.Clear();
                //        ZYKBBuffer.Instance.GetKBListsByName("-", myYesNoKB, false);
                //        object objReturn = OwnerDocument.OwnerControl.ShowKBPopupList(myOwnerDocument.Content.CurrentElement, myYesNoKB, "[正在选取症状]", false, false);
                //        KB_Item myItem = objReturn as KB_Item;
                //        if (myItem != null)
                //        {
                //            if (iCount > 0)
                //                OwnerDocument._InsertChar('、');
                //            intResult = OwnerDocument._InsertKB(myItem.OwnerList, myItem);
                //        }
                //        else
                //        {
                //            KB_List myList = objReturn as KB_List;
                //            if (myList != null)
                //            {
                //                if (iCount > 0)
                //                    OwnerDocument._InsertChar('、');
                //                intResult = OwnerDocument._InsertKB(myList);
                //            }
                //        }
                //        if (intResult != 2)
                //        {
                //            break;
                //        }
                //        iCount++;
                //    }//while
                //    OwnerDocument.OwnerControl.KBPopupList.EnableSearchKBDynamic = true;
                //    ZYKBBuffer.Instance.OnlyCheckYesNoAttribute = false;
                //}
                //myOwnerDocument.OwnerControl.HideInnerToolTip();
                //myOwnerDocument.OwnerControl.StaticToolTip = false;
            //    return true;
            //}
            string strWord = myOwnerDocument.Content.GetPreWord(myCharElement);
            if (StringCommon.HasContent(strWord))
            {
                //if (myCharElement.Char == ':' || myCharElement.Char == '：')
                //{
                //    //KB_List myList = ZYKBBuffer.Instance.GetKBListByName(strWord, false);
                //    //myOwnerDocument.OwnerControl.StaticToolTip = true;
                //    if (myList == null)
                //        myOwnerDocument.OwnerControl.ShowInnerToolTip(12, "按Tab键添加名称为[" + strWord + "]的输入框", myCharElement.RealLeft, myCharElement.RealTop, myCharElement.Height);
                //    else
                //        myOwnerDocument.OwnerControl.ShowInnerToolTip(2, "按Tab键添加名称为[" + myList.Name + "]的列表框", myCharElement.RealLeft, myCharElement.RealTop, myCharElement.Height);
                //    System.Windows.Forms.Application.DoEvents();
                //    myOwnerDocument.OwnerControl.UpdateInnerToolTip();
                //    if (myOwnerDocument.OwnerControl.WaitForKeyDown((int)System.Windows.Forms.Keys.Tab, true) && myOwnerDocument.OwnerControl.InnerToolTipVisible)
                //    {
                //        myOwnerDocument.OwnerControl.HideInnerToolTip();
                //        if (myList == null)
                //            myOwnerDocument._InsertInput(strWord, strWord);
                //        else
                //        {
                //            ZYTextSelect mySelect = new ZYTextSelect();
                //            mySelect.OwnerDocument = OwnerDocument;
                //            mySelect.Name = myList.Name;
                //            mySelect.ListSource = myList.SEQ;
                //            mySelect.Text = "[" + myList.Name + "]";
                //            //mySelect.UpdateText();
                //            myOwnerDocument.BeginUpdate();
                //            myOwnerDocument.Content.InsertElement(mySelect);
                //            myOwnerDocument.EndUpdate();
                //            mySelect.PopupList();
                //        }
                //    }
                //    myOwnerDocument.OwnerControl.HideInnerToolTip();
                //    myOwnerDocument.OwnerControl.StaticToolTip = false;
                //}
            }
            return true;
        }
    }
    /// <summary>
    /// 插入字符动作
    /// </summary>
    public class A_InsertChar : ZYEditorAction
    {
        /// <summary>
        /// 本动作 不处理KeyDown事件
        /// </summary>
        /// <returns></returns>
        //public override bool CanHandleKeyDown()
        //{
        //    return false;
        //}
        /// <summary>
        /// 已重载:所有的一般字符和制表符和回车符都可触发该动作 
        /// </summary>
        /// <param name="vKeyCode"></param>
        /// <param name="vShift"></param>
        /// <param name="vControl"></param>
        /// <param name="vAlt"></param>
        /// <returns></returns>
        //public override bool TestHotKey(System.Windows.Forms.Keys vKeyCode, bool vShift, bool vControl, bool vAlt)
        //{
        //    if (vShift || vControl || vAlt)
        //        return false;
        //    char intChar = (char)vKeyCode;
        //    if (char.IsControl(intChar))
        //    {
        //        if (intChar == '\t' || intChar == '\r')
        //            return true;
        //        else
        //            return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 动作名称 insertchar
        ///// </summary>
        ///// <returns></returns>
        //public override string ActionName()
        //{
        //    return "insertchar";
        //}
        /// <summary>
        /// 文档可修改动作有效
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 根据KeyCode参数插入字符元素
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument._InsertChar((char)KeyCode);
            return true;
            //			if( (char)KeyCode == ':' || (char)KeyCode == '：')
            //			{
            //				ZYTextElement NewElement = myOwnerDocument._InsertChar( (char) KeyCode );
            //				string strWord = myOwnerDocument.Content.GetPreWord(NewElement);
            //				if( strWord != null)
            //				{
            //					if(strWord.Length > 10 )
            //						strWord = strWord.Substring( strWord.Length - 10 ,10);
            //					//System.Windows.Forms.Application.DoEvents();
            //					ZYTextElement myElement = myOwnerDocument.Content.CurrentElement;
            //					KB_List myList = ZYKBBuffer.Instance.GetKBListByName( strWord , false);
            //					myOwnerDocument.OwnerControl.StaticToolTip = true;
            //					if( myList == null)
            //						myOwnerDocument.OwnerControl.ShowInnerToolTip(12, "按Tab键添加名称为[" + strWord + "]的输入框",myElement.RealLeft , myElement.RealTop , myElement.Height );
            //					else
            //						myOwnerDocument.OwnerControl.ShowInnerToolTip(2 ,"按Tab键添加名称为[" + myList.Name + "]的列表框",myElement.RealLeft , myElement.RealTop , myElement.Height );
            //					myOwnerDocument.OwnerControl.UpdateInnerToolTip();
            //					System.Windows.Forms.Application.DoEvents();
            //					if( myOwnerDocument.OwnerControl.WaitForKeyDown( (int)System.Windows.Forms.Keys.Tab , true ) && myOwnerDocument.OwnerControl.InnerToolTipVisible )
            //					{
            //						myOwnerDocument.OwnerControl.HideInnerToolTip();
            //						if( myList == null)
            //							myOwnerDocument._InsertInput(strWord);
            //						else
            //						{
            //							ZYTextSelect mySelect =  new ZYTextSelect();
            //							mySelect.OwnerDocument = OwnerDocument;
            //							mySelect.Name = myList.Name ;
            //							mySelect.ListSource = myList.SEQ ;
            //							mySelect.Text = "[" + myList.Name + "]";
            //							//mySelect.UpdateText();
            //							myOwnerDocument.BeginUpdate();
            //							myOwnerDocument.Content.InsertElement(mySelect);
            //							myOwnerDocument.EndUpdate();
            //							mySelect.PopupList();
            //						}
            //					}
            //					myOwnerDocument.OwnerControl.HideInnerToolTip();
            //					myOwnerDocument.OwnerControl.StaticToolTip = false;
            //				}
            //			}
            //			else
            //			{
            //				myOwnerDocument._InsertChar( (char) KeyCode );
            //			}
            //			return true;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            A_InsertChar f = new A_InsertChar();
            f.BaseCloneFrom(this);
            return f;
        }

    }

    public class A_DoNothing : ZYEditorAction
    {

    }

    /// <summary>
    /// Add By wwj 2011-09-23 弹出查询框
    /// </summary>
    public class A_ShowFindForm : ZYEditorAction
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return true;
        }
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.ShowFindForm();
            return true;
        }
    }// class A_ShowFindForm

    /// <summary>
    /// Add By wwj 2011-09-23 保存病历
    /// </summary>
    public class A_SaveEMR : ZYEditorAction
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myOwnerDocument.CanModify();
        }
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            myOwnerDocument.SaveEMR();
            return true;
        }
    }

    /// <summary>
    /// 编辑器动作对象,本对象实现了<link>ZYCommon.ZYToolBarGroup.IZYToolBarButtonAction</link>接口
    /// </summary>
    /// <remarks>在本文档对象模型中采用动作来实现文档的编辑操作,
    /// 对用户或应用程序对文档的任何操作都建议采用动作的方式来完成,
    /// 每一种动作类型对能完成对文档的一种特定的操作.程序调用动作的过程
    /// 一般是:首先确定该动作的内部名称,然后调用<link>ZYTextDocumentLib.ZYTextDocument.GetActionByName</link>
    /// 函数来获得动作对象,然后调用动作对象的<a href="#ZYTextDocumentLib.ZYEditorAction.isEnable">isEnable</a>函数来
    /// 确认动作在当前是否可用,若可用则调用<a href="#ZYTextDocumentLib.ZYEditorAction.Execute">Execute</a>函数
    /// 来执行该动作,此外还可设置对象的 HotKey 来设置在文档编辑器中的快捷键
    /// 用户可以在此基础上构造自定义的命令对象</remarks>
    /// <example>以下使用动作来实现复制和粘贴操作
    ///     ZYTextDocument myDoc =  获得某个文档对象实例 ;
    ///		// 获得所有支持的命令名称
    ///		string[] strActions = myDoc.GetCommandList();
    ///		foreach( string strAction in strActions )
    ///			System.Console.WriteLine( strAction);
    ///		// 试图进行复制
    ///		ZYEditorAction myAction = myDoc.GetActionByName("copy");
    ///		// 修改复制动作的快捷键为 Ctl+F
    ///		myAction.HotKey = = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F ;
    ///		if( myAction.isEnable())
    ///			myAction.Execute(); // 进行了复制
    ///		else
    ///			System.Console.WriteLine("目前不能复制,文档中没有内容被选择");
    ///		// 试图进行粘贴
    ///		myAction = myDoc.GetActionByName("paste");
    ///		if( myAction.isEnable())
    ///			myAction.Execute(); // 进行粘贴操作
    ///		else
    ///			System.Console.WriteLine("目前不能粘贴,可能因为系统剪切版中没有文本数据或者文档内容不能修改");
    ///			</example>
    /// <seealso>ZYTextDocumentLib.ZYTextDocument.GetActionByName</seealso>
    public abstract class ZYEditorAction// : ZYToolBarGroup.IZYToolBarButtonAction
    {
        /// <summary>
        /// 当执行动作时插入点的位置
        /// </summary>
        internal int SelectStart = -1;
        /// <summary>
        /// 当执行动作时选择区域的长度
        /// </summary>
        internal int SelectLength = -1;
        internal int SelectStart2 = -1;
        internal int SelectLength2 = -1;
        /// <summary>
        /// 本动作所涉及到的所有元素的列表
        /// </summary>
        internal System.Collections.ArrayList Elements = null;
        /// <summary>
        /// 本动作所涉及到的元素
        /// </summary>
        internal ZYTextElement SingleElement = null;

        /// <summary>
        /// 本动作对应的文档对象
        /// </summary>
        protected ZYTextDocument myOwnerDocument = null;
 #region bwy : 
        ///// <summary>
        ///// 本动作对应的热键
        ///// </summary>
        //public System.Windows.Forms.Keys HotKey = System.Windows.Forms.Keys.None;
        /// <summary>
        /// 触发动作时的键盘按键
        /// </summary>
        public System.Windows.Forms.Keys KeyCode = System.Windows.Forms.Keys.None;
        ///// <summary>
        ///// 触发动作时的键盘 Shift 键状态
        ///// </summary>
        //public bool ShiftKey = false;
        ///// <summary>
        ///// 触发动作时 Control 键的状态
        ///// </summary>
        //public bool ControlKey = false;
        ///// <summary>
        ///// 触发动作时的 Alt 键的状态
        ///// </summary>
        //public bool AltKey = false;

#endregion bwy : 

        /// <summary>
        /// 触发动作时的鼠标光标X坐标
        /// </summary>
        public int MouseX = 0;
        /// <summary>
        /// 触发动作时的鼠标光标Y坐标
        /// </summary>
        public int MouseY = 0;
        /// <summary>
        /// 触发动作时的鼠标按键状态
        /// </summary>
        public System.Windows.Forms.MouseButtons MouseButton = System.Windows.Forms.MouseButtons.None;

        ///// <summary>
        ///// 命令参数1
        ///// </summary>
        //public string Param1 = null;
        ///// <summary>
        ///// 命令参数2
        ///// </summary>
        //public string Param2 = null;
        ///// <summary>
        ///// 命令参数3
        ///// </summary>
        //public string Param3 = null;

        /// <summary>
        /// 复制对象数据到另一个动作对象
        /// </summary>
        /// <param name="a">另一个动作对象</param>
        /// <returns>另一个动作对象</returns>
        protected ZYEditorAction BaseCloneFrom(ZYEditorAction a)
        {
            if (a != null && a != this)
            {
                myOwnerDocument = a.OwnerDocument;
 #region bwy : 
                //HotKey = a.HotKey;
                KeyCode = a.KeyCode;
                //ShiftKey = a.ShiftKey;
                //ControlKey = a.ControlKey;
                //AltKey = a.AltKey;
#endregion bwy : 
                MouseX = a.MouseX;
                MouseY = a.MouseY;
                MouseButton = a.MouseButton;
                //Param1 = a.Param1;
                //Param2 = a.Param2;
                //Param3 = a.Param3;
                if (a.Elements != null)
                {
                    Elements = new System.Collections.ArrayList();
                    Elements.AddRange(a.Elements);
                }
                SingleElement = a.SingleElement;
                return this;
            }
            return null;
        }

 #region bwy : 
        ///// <summary>
        ///// 该动作是否可以处理KeyDown事件
        ///// </summary>
        ///// <returns></returns>
        //public virtual bool CanHandleKeyDown()
        //{
        //    return true;
        //}

        ///// <summary>
        ///// 测试热键
        ///// </summary>
        ///// <param name="vKeyCode">按键值</param>
        ///// <param name="vShift">键盘Shift键状态</param>
        ///// <param name="vControl">键盘Control键状态</param>
        ///// <param name="vAlt">键盘Alt键状态</param>
        ///// <returns>测试是否成功</returns>
        //public virtual bool TestHotKey(System.Windows.Forms.Keys vKeyCode, bool vShift, bool vControl, bool vAlt)
        //{
        //    if (HotKey == System.Windows.Forms.Keys.None)
        //        return false;
        //    if (vShift)
        //        vKeyCode = vKeyCode | System.Windows.Forms.Keys.Shift;
        //    if (vControl)
        //        vKeyCode = vKeyCode | System.Windows.Forms.Keys.Control;
        //    if (vAlt)
        //        vKeyCode = vKeyCode | System.Windows.Forms.Keys.Alt;
        //    return (vKeyCode == HotKey);
        //}
#endregion bwy : 

        ///// <summary>
        ///// 返回动作对象的类型名称
        ///// </summary>
        ///// <returns>类型名称</returns>
        //public virtual string ActionName()
        //{
        //    return null;
        //}

        /// <summary>
        ///// 该动作对象对应的文档对象
        /// </summary>
        public ZYTextDocument OwnerDocument
        {
            get { return myOwnerDocument; }
            set { myOwnerDocument = value; }
        }
        /// <summary>
        /// 该动作是否可用
        /// </summary>
        /// <returns>True:对象可用 False:对象不可用,默认true</returns>
        public virtual bool isEnable()
        {
            return true;
        }


        /// <summary>
        /// 执行该动作
        /// </summary>
        /// <returns>操作是否成功,默认true</returns>
        public virtual bool Execute()
        {
            return true;
        }

        ///// <summary>
        ///// 在用户界面上执行改动作,默认转而执行Execute函数
        ///// </summary>
        ///// <returns>操作是否成功</returns>
        //public virtual bool UIExecute()
        //{
        //    return Execute();
        //}

        /// <summary>
        /// 该动作的选择状态 0:没选择 1:选择 其他:该设置无效
        /// </summary>
        /// <returns>0:没选择 1:选择 其他:该设置无效</returns>
        public virtual int CheckState()
        {
            return -1; ;
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>复制品,默认空引用</returns>
        public virtual ZYEditorAction Clone()
        {
            return null;
        }

        ///// <summary>
        ///// 实现<link>ZYToolBarGroup.IZYToolBarButtonAction.SetText</link>接口,设置对象的文本内容
        ///// </summary>
        ///// <param name="strText">要设置的文本</param>
        ///// <returns>操作是否成功</returns>
        //public bool SetText(string strText)
        //{
        //    Param1 = strText;
        //    return true;
        //}
        ///// <summary>
        ///// 实现<link>ZYToolBarGroup.IZYToolBarButtonAction.GetText</link>接口,获得对象的文本内容
        ///// </summary>
        ///// <returns>获得的文本内容</returns>
        //public virtual string GetText()
        //{
        //    //return Param1;
        //    return "";
        //}

        /// <summary>
        /// 暂未支持:该动作是否可以加入取消操作列表
        /// </summary>
        /// <returns>操作是否成功,默认false</returns>
        public virtual bool isUndoable()
        {
            return false;
        }

        /// <summary>
        /// 暂未支持:该动作在操作列表中的名称
        /// </summary>
        /// <returns>操作是否成功</returns>
        public virtual string UndoName()
        {
            return null;
        }
        /// <summary>
        /// 进行撤销操作
        /// </summary>
        /// <returns>操作是否成功,默认true</returns>
        public virtual bool Undo()
        {
            return true;
        }
        /// <summary>
        /// 进行重复操作,默认调用自己的Execute函数
        /// </summary>
        /// <returns>操作是否成功</returns>
        public virtual bool Redo()
        {
            return Execute();
        }
    }
}