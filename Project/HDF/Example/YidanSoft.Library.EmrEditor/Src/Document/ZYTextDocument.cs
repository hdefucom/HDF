using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using YidanSoft.Library.EmrEditor.Src.Actions;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Gui;
using YidanSoft.Library.EmrEditor.Src.Print;
using YidanSoft.Library.EmrEditor.Src.Undo;
using YidanSoft.Library.EmrEditor.Src.Win32API;
using ZYTextDocumentLib;
using XDesignerPrinting;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Web.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using YidanSoft.Library.EmrEditor.Src.Clipboard;
using System.Threading;
using System.Drawing.Imaging;
using YiDanCommon.YiDanService;
using YidanSoft.Library.EmrEditor.Src.Document.Table;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    #region  EnumElementHandler  JumpDivHandler
    ///// <summary>
    ///// 光标在文本块间跳跃时的处理委托
    ///// </summary>
    ///// <param name="DivForm" type="ZYTextDocumentLib.ZYTextDiv">开始离开的文本块对象</param>
    ///// <param name="DivTo" type="ZYTextDocumentLib.ZYTextDiv">到达的文本块对象</param>
    //public delegate void JumpDivHandler(ZYTextDiv DivFrom, ZYTextDiv DivTo);
    /// <summary>
    /// 遍历文档中所有元素的处理委托
    /// </summary>
    /// <param name="Parent" type="ZYTextDocumentLib.ZYTextContainer">当前遍历的元素的父元素对象</param>
    /// <param name="Element" type="ZYTextDocumentLib.ZYTextElement">当前遍历的元素</param>
    /// <returns>是否继续遍历</returns>
    public delegate bool EnumElementHandler(ZYTextContainer Parent, ZYTextElement Element);
    /// <summary>
    /// 光标在文本块间跳跃时的处理委托
    /// </summary>
    /// <param name="DivForm" type="ZYTextDocumentLib.ZYTextDiv">开始离开的文本块对象</param>
    /// <param name="DivTo" type="ZYTextDocumentLib.ZYTextDiv">到达的文本块对象</param>
    public delegate void JumpDivHandler(ZYTextDiv DivFrom, ZYTextDiv DivTo);
    /// <summary>
    /// Add By wwj 2011-09-23 调用外部“查找”窗体
    /// </summary>
    /// <param name="selectedText"></param>
    public delegate void ShowFindFormHandler();
    /// <summary>
    /// Add By wwj 2011-09-23 调用外部“保存”功能
    /// </summary>
    public delegate void SaveEMRHandler();

    /// <summary>
    /// add by lhl 2015-06-29 外部调用获取该用户是否拥有编辑页眉权限
    /// </summary>
    /// <returns></returns>
    public delegate bool IsPageHeaderEditor();

    /// <summary>
    /// add by lhl 2015-07-21 外部调用是否启用剪切板(默认启用)
    /// </summary>
    /// <returns></returns>
    public delegate bool IsUseShearPlate();
    #endregion

    [Serializable]
    public class ZYTextDocument : System.IDisposable, IPageDocument, ICloneable
    {
        #region add by myc 2014-06-26 添加原因：新版页眉二期改版需要——>已于 2014-07-24 被注释：页眉、正文和页脚统一管理下封装处理例程需要
        ///// <summary>
        ///// 标识当前正在编辑的文档区域所属类别，分为文档页眉区（数值0代表）、文档正文区（数值1代表）和文档页脚区（数值2代表）。
        ///// </summary>
        //public static int CurrentEditingArea = 1;

        ///// <summary>
        ///// 编辑区内部可见元素列表的集合，包含三个数组列表，分别存储当前正在编辑的文档页眉区、文档正文区和文档页脚区的所有文本类型元素。
        ///// </summary>
        //private List<ArrayList> editingAreaElements = new List<ArrayList>();
        /// <summary>
        /// 编辑区内部可见元素列表的集合，包含三个数组列表，分别存储当前正在编辑的文档页眉区、文档正文区和文档页脚区的所有文本类型元素。
        /// </summary>
        //public List<ArrayList> EditingAreaElements
        //{
        //    get { return editingAreaElements; }
        //    set { editingAreaElements = value; }
        //}

        ///// <summary>
        ///// 编辑区内部文档行列表的集合，包含三个数组列表，分别存储当前正在编辑的文档页眉区、文档正文区和文档页脚区的所有文档行对象。
        ///// </summary>
        //private List<ArrayList> editingAreaLines = new List<ArrayList>();
        /// <summary>
        /// 编辑区内部文档行列表的集合，包含三个数组列表，分别存储当前正在编辑的文档页眉区、文档正文区和文档页脚区的所有文档行对象。
        /// </summary>
        //public List<ArrayList> EditingAreaLines
        //{
        //    get { return editingAreaLines; }
        //    set { editingAreaLines = value; }
        //} 

        ///// <summary>
        ///// 所有文档页的页眉区域根元素列表。
        ///// </summary>
        //public ArrayList RootDocumentElementsInHeader = new ArrayList();

        ///// <summary>
        ///// 所有文档页的页眉区域对应的（原始区域和目标区域的）坐标系转换关系列表。
        ///// </summary>
        //public static ArrayList HeaderTransforms = new ArrayList();
        #endregion

        #region add by myc 2014-07-07 添加原因：新版页脚需要——>已于 2014-07-24 被注释：页眉、正文和页脚统一管理下封装处理例程需要
        ///// <summary>
        ///// 所有文档页的页脚区域根元素列表。
        ///// </summary>
        //public ArrayList RootDocumentElementsInFooter = new ArrayList();

        ///// <summary>
        ///// 所有文档页的页脚区域对应的（原始区域和目标区域的）坐标系转换关系列表。
        ///// </summary>
        //public static ArrayList FooterTransforms = new ArrayList();
        #endregion

        #region 构造函数,初始化一个文档对象,并自动添加一个根元素
        /// <summary>
        /// 构造函数,初始化一个文档对象,并自动添加一个根元素
        /// </summary>
        public ZYTextDocument()
        {
            myContent.Document = this;
            //myContent.Elements = myElements; //add by myc 2014-07-03 注释原因：新版页眉二期改版需要

            #region add by myc 2014-07-03 添加原因：新版页眉二期改版之页眉与正文统一管理
            for (int i = 0; i < 3; i++)
            {
                ArrayList innerElements = null;
                editingAreaElements.Add(innerElements);

                ArrayList innerLines = null;
                editingAreaLines.Add(innerLines);

                ZYTextContainer innerRootElement = null;
                editingAreaRootElements.Add(innerRootElement); //add by myc 2014-07-24 添加原因：页眉、正文和页脚鼠标事件统一管理需要
            }
            //myContent.EditingAreaElements = editingAreaElements; 
            editingAreaFlag = 1;
            #endregion

            RootDocumentElement = new ZYTextDiv();
            RootDocumentElement.OwnerDocument = this;

            Info.OwnerDocument = this;

            //加载xml到文档对象模型中
            this.RefreshElements();
            myView.Width = myPages.StandardWidth;
            mySaveLogs.OwnerDocument = this;

            myPages.OwnerDocument = this; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        }
        #endregion

        #region ----------------------变量列表-----------------------------
        //internal int FirstMarkSaveLogIndex = 0 ;
        private System.Drawing.GraphicsUnit intDocumentGraphicsUnit = System.Drawing.GraphicsUnit.Document;
        /// <summary>
        /// 是否允许选择打印
        /// </summary>
        protected bool bolEnableSelectionPrint = false;

        /// <summary>
        /// 视图对象
        /// </summary>
        private DocumentView myView = new DocumentView();
        /// <summary>
        /// 文档内容对象
        /// </summary>
        private ZYContent myContent = new ZYContent();
        /// <summary>
        /// 视图控件对象
        /// </summary>
        public ZYEditorControl myOwnerControl = null;
        /// <summary>
        /// 根元素
        /// </summary>
        public ZYTextContainer RootDocumentElement = null;

        /// <summary>
        /// 元素列表
        /// </summary>
        private System.Collections.ArrayList myElements = new System.Collections.ArrayList();

        private ZYTextSaveLogCollection mySaveLogs = new ZYTextSaveLogCollection();
        /// <summary>
        /// 文档信息及设置对象
        /// </summary>
        private ZYDocumentInfo myInfo = new ZYDocumentInfo();

        protected System.Windows.Forms.Cursor myCursor = System.Windows.Forms.Cursors.Default;//null;
        /// <summary>
        /// 正在加载文档
        /// </summary>
        protected bool bolLoading = false;

        /// <summary>
        /// 当前处于鼠标悬浮状态的元素
        /// </summary>
        protected ZYTextElement myCurrentHoverElement = null;

        /// <summary>
        /// 所有的文本行对象的集合
        /// </summary>
        protected System.Collections.ArrayList myLines = new System.Collections.ArrayList();

        /// <summary>
        /// 文档参数列表对象
        /// </summary>
        protected NameValueList myVariables = new NameValueList();

        /// <summary>
        /// 文档元素对象树中所有的容器对象
        /// </summary>
        protected System.Collections.ArrayList myContainters = new System.Collections.ArrayList();

        /// <summary>
        /// 当前支持的文档格式的版本号
        /// </summary>
        protected const string c_EditorVersion = "1.0";

        /// <summary>
        /// 刷新全部用户界面的标志
        /// </summary>
        public bool RefreshAllFlag = false;

        /// <summary>
        /// 隐藏的元素的名称
        /// </summary>
        protected string[] strHideElementNames = null;
        /// <summary>
        /// 纸张设置
        /// </summary>
        protected System.Drawing.Printing.PageSettings myPageSettings = new System.Drawing.Printing.PageSettings();

        /// <summary>
        /// 元素列表发生改变标志，需要重新分行
        /// </summary>
        public bool ElementsDirty = false;

        /// <summary>
        /// 当选择区域发生改变时的事件处理
        /// </summary>
        public event System.EventHandler OnSelectionChanged = null;
        /// <summary>
        /// 当文档内容发生改变时的事件处理
        /// </summary>
        public event System.EventHandler OnContentChanged = null;

        /// <summary>
        /// 当光标在文本块中跳跃时的时间处理
        /// </summary>
        public event JumpDivHandler OnJumpDiv = null;

        /// <summary>
        /// Add By wwj 2011-09-23 调用外部“查找”窗体
        /// </summary>
        public event ShowFindFormHandler OnShowFindForm = null;

        /// <summary>
        /// Add By wwj 2011-09-23 调用外部“保存”功能
        /// </summary>
        public event SaveEMRHandler OnSaveEMR = null;

        /// <summary>
        /// add by lhl 2015-06-29 外部调用获取该用户是否拥有编辑页眉权限
        /// </summary>
        public event IsPageHeaderEditor OnIsPageHeaderEditor = null;

        /// <summary>
        /// add by lhl 2015-07-21 外部调用获取是否启用剪切板功能
        /// </summary>
        public event IsUseShearPlate OnIsUseShearPlate = null;

        /// <summary>
        /// 页眉高度
        /// </summary>
        protected int intHeadHeight = 300;
        /// <summary>
        /// 页脚高度
        /// </summary>
        protected int intFooterHeight = 100;

        bool showHeader = true;
        bool showFooter = true;

        /// <summary>
        /// 页面对象集合
        /// </summary>
        protected PrintPageCollection myPages = new PrintPageCollection();
        /// <summary>
        /// 页号修正量
        /// </summary>
        private int intPageIndexFix = 1;
        /// <summary>
        /// 当前打印的页面序号
        /// </summary>
        private int intPageIndex = 0;

        /// <summary>
        /// 起始页码
        /// </summary>
        private int startPageIndex = 0;

        /// <summary>
        /// 是否允许续打
        /// </summary>
        protected bool bolEnableJumpPrint = false;
        /// <summary>
        /// 续打位置
        /// </summary>
        protected int intJumpPrintPosition = 0;

        /// <summary>
        /// 签名对象集合
        /// </summary>
        protected UnderWriteMarkCollection myMarks = new UnderWriteMarkCollection();
        /// <summary>
        /// 撤销操作状态 0:正常编辑状态 1:正在撤销操作 2:正在重复操作
        /// </summary>
        protected int intUndoState = 0;
        /// 文档内容是否被锁定
        /// </summary>
        private bool bolLocked = false;

        private int intLockLevel = -1;
        /// <summary>
        /// 页脚字符串
        /// </summary>
        //protected string strFooterString = "<footer><p><horizontalLine lineHeight='1'></horizontalLine></p><p align='2'><span fontname='宋体' fontsize='10' >第[%pageindex%]页 / 共[%pagecount%]页</span></p></footer>";
        //add by myc 2014-07-07 添加原因：新版页脚之初始化页脚字符串
        protected string strFooterString = @"<footer><p><horizontalLine lineHeight='1'></horizontalLine><eof /></p>
                                                     <p align='2'><span fontname='宋体' fontsize='10' >第[%pageindex%]页 / 共[%pagecount%]页</span><eof /></p>
                                             </footer>";
        /// <summary>
        /// 页眉字符串
        /// </summary>
        //protected string strHeadString = @"<header><p align='2'><span fontname='宋体' fontsize='14'>医院名称</span><eof /></p><p align='2'><span fontname='宋体' fontsize='14' fontbold='1'>子标题</span><eof /></p><p align='0'><span fontname='宋体' fontsize='14'>姓名：</span><macro fontname='宋体' fontsize='14' type='macro' name='姓名'>姓名</macro><span fontname='宋体' fontsize='14'>　　性别：</span><macro fontname='宋体' fontsize='14' type='macro' name='性别'>性别</macro><span fontname='宋体' fontsize='14'>　　年龄：</span><macro fontname='宋体' fontsize='14' type='macro' name='年龄'>年龄</macro><span fontname='宋体' fontsize='14'>　　民族：</span><macro fontname='宋体' fontsize='14' type='macro' name='民族'>民族</macro><eof /></p><p align='0'><horizontalLine type='' name='水平线' lineHeight='2' percent='100' /><eof /></p></header>";
        //add by myc 2014-07-04 添加原因：新版页眉二期改版之初始化页眉字符串
        protected string strHeadString = @"<header><p align='2'><span fontname='宋体' fontsize='14'>医院名称</span><eof /></p>
                                                   <p align='2'><span fontname='宋体' fontsize='14' fontbold='1'>子标题</span><eof /></p>
                                                   <p align='4'><span fontname='宋体' fontsize='14'>姓名：</span><macro fontname='宋体' fontsize='14' type='macro' name='姓名'>姓名</macro><span fontname='宋体' fontsize='14'>　　性别：</span><macro fontname='宋体' fontsize='14' type='macro' name='性别'>性别</macro><span fontname='宋体' fontsize='14'>　　年龄：</span><macro fontname='宋体' fontsize='14' type='macro' name='年龄'>年龄</macro><span fontname='宋体' fontsize='14'>　　民族：</span><macro fontname='宋体' fontsize='14' type='macro' name='民族'>民族</macro><eof /></p><p align='0'><horizontalLine type='' name='水平线' lineHeight='2' percent='100' /><eof /></p>
                                           </header>";

        UndoStack undoStack = new UndoStack();
        private A_ContentChangeLog myContentChangeLog = null;
        private int intLogLevel = 0;

        /// <summary>
        /// 页脚显示的页数
        /// </summary>
        public string PageIndexForNurse
        {
            set
            {
                if (!string.IsNullOrEmpty(value.Trim()) && value != "-1")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(strFooterString);
                    if (doc.InnerText.Trim() == "")
                    {
                        strFooterString = "<footer><p align='0'><horizontalLine type='' name='水平线' lineHeight='2' percent='100' /><eof /></p><p align='2'><span fontname='宋体' fontsize='10' >第 " + value + " 页</span></p></footer>";
                    }
                }
            }
        }

        #endregion ----------------------变量列表-----------------------------

        #region ----------------------属性列表-----------------------------

        /// <summary>
        /// 是否允许选择打印
        /// </summary>
        public bool EnableSelectionPrint
        {
            get { return bolEnableSelectionPrint; }
            set { bolEnableSelectionPrint = value; }
        }

        /// <summary>
        /// 文档使用的绘图单位
        /// </summary>
        public System.Drawing.GraphicsUnit DocumentGraphicsUnit
        {
            get { return intDocumentGraphicsUnit; }
            set { intDocumentGraphicsUnit = value; }
        }
        #region 页面

        /// <summary>
        /// 页面对象集合
        /// </summary>
        public PrintPageCollection Pages
        {
            get { return myPages; }
            set { myPages = value; }
        }

        /// <summary>
        /// 页号修正量
        /// </summary>
        public int PageIndexFix
        {
            get { return intPageIndexFix; }
            set { intPageIndexFix = value; }
        }

        /// <summary>
        /// 当前打印的页面序号
        /// </summary>
        public int PageIndex
        {
            get { return intPageIndex; }
            set { intPageIndex = value; }
        }

        /// <summary>
        /// 起始页码
        /// </summary>
        public int StartpageIndexs
        {
            get { return startPageIndex; }
            set { startPageIndex = value; }
        }
        #endregion

        #region 续打

        /// <summary>
        /// 是否允许续打
        /// </summary>
        public bool EnableJumpPrint
        {
            get { return bolEnableJumpPrint; }
            set { bolEnableJumpPrint = value; }
        }

        /// <summary>
        /// 续打位置
        /// </summary>
        public int JumpPrintPosition
        {
            get { return intJumpPrintPosition; }
            set { intJumpPrintPosition = this.FixPageLine(value); }
        }
        #endregion

        #region 选中区域打印 Add By wwj 2012-04-17  【注意：不同于上面的选择打印】

        /// <summary>
        /// 是否允许选中区域打印
        /// </summary>
        public bool EnableSelectAreaPrint
        {
            get { return bolEnableSelectAreaPrint; }
            set { bolEnableSelectAreaPrint = value; }
        }
        private bool bolEnableSelectAreaPrint = false;

        /// <summary>
        /// 选中区域打印左上角的坐标
        /// </summary>
        public Point SelectAreaPrintLeftTopPoint { get; set; }
        /// <summary>
        /// 选中区域打印右下角的坐标
        /// </summary>
        public Point SelectAreaPrintRightBottomPoint { get; set; }

        #endregion

        /// <summary>
        /// 保存记录的对象集合
        /// </summary>
        public ZYTextSaveLogCollection SaveLogs
        {
            get { return mySaveLogs; }
        }
        /// <summary>
        /// 纸张设置
        /// </summary>
        public System.Drawing.Printing.PageSettings PageSettings
        {
            get { return myPageSettings; }
            set { myPageSettings = value; }
        }
        public int HeadHeight
        {
            get
            {
                if (this.showHeader)
                    return intHeadHeight;
                else
                    return 0;
            }
            set
            {

                intHeadHeight = value;
            }
        }
        public int FooterHeight
        {
            get
            {
                if (this.ShowFooter)
                    return intFooterHeight;
                else
                    return 0;
            }
            set
            {
                intFooterHeight = value;
            }
        }
        public bool ShowHeader
        {
            get { return showHeader; }
            set
            {
                showHeader = value;
                #region add by myc 2014-07-07 添加原因：新版页眉二期改版需要——>不能随便刷新视图界面
                //OwnerControl.DrawTopMargin = !value;
                ////this.RefreshSize();
                //this.RefreshLine();
                //this.Refresh();
                //UpdateTextCaret(); 
                #endregion
            }
        }

        bool showHeaderLine = true;
        public bool ShowHeaderLine
        {
            get { return showHeaderLine; }
            set
            {
                showHeaderLine = value;
                this.OwnerControl.Refresh();
            }
        }

        bool showFooterLine = true;
        public bool ShowFooterLine
        {
            get { return showFooterLine; }
            set
            {
                showFooterLine = value;
                this.OwnerControl.Refresh();
            }
        }

        public bool ShowFooter
        {
            get { return showFooter; }
            set
            {
                showFooter = value;
                #region add by myc 2014-07-07 添加原因：新版页眉二期改版需要——>不能随便刷新视图界面
                //OwnerControl.DrawBottomMargin = !value;
                //showFooter = value;
                ////this.RefreshSize();
                //this.RefreshLine();
                //this.Refresh();
                //UpdateTextCaret();
                #endregion

            }
        }
        /// <summary>
        /// 签名对象集合
        /// </summary>
        public UnderWriteMarkCollection Marks
        {
            get { return myMarks; }
        }
        /// <summary>
        /// 返回文档参数列表对象
        /// </summary>
        public NameValueList Variables
        {
            get { return myVariables; }
            set { myVariables = value; }
        }
        /// <summary>
        /// 隐藏的元素
        /// </summary>
        public string HideElementNames
        {
            get
            {
                if (strHideElementNames == null)
                    return null;
                System.Text.StringBuilder myStr = new System.Text.StringBuilder();
                foreach (string strName in strHideElementNames)
                {
                    if (myStr.Length == 0)
                        myStr.Append(strName);
                    else
                        myStr.Append(strName + ",");
                }
                return myStr.ToString();
            }
            set { strHideElementNames = value.Split(",".ToCharArray()); }
        }

        /// <summary>
        /// 设置获得当前处于鼠标悬浮状态的元素
        /// </summary>
        public ZYTextElement CurrentHoverElement
        {
            get { return myCurrentHoverElement; }
            set
            {
                //				if( value == null)
                //					System.Console.WriteLine("aaaaaaa");
                if (myCurrentHoverElement != value)
                {
                    ZYTextElement oldElement = myCurrentHoverElement;
                    myCurrentHoverElement = value;
                    if (oldElement != null)
                        this.RefreshElement(oldElement);
                    if (myCurrentHoverElement != null)
                        this.RefreshElement(myCurrentHoverElement);
                }
            }
        }

        /// <summary>
        /// 文档中所有的文本行对象的集合
        /// </summary>
        public System.Collections.ArrayList Lines
        {
            get { return myLines; }
            set { myLines = value; }
        }
        /// <summary>
        /// 只读,文档正在加载标志
        /// </summary>
        public bool Loading
        {
            get { return bolLoading; }
            set { bolLoading = value; }
        }


        public UndoStack UndoStack
        {
            get
            {
                return undoStack;
            }
        }
        /// <summary>
        /// 返回文档对象处理撤销,重复操作的状态 0:正常编辑状态 1:正在撤销操作 2:正在重复操作
        /// </summary>
        public int UndoState
        {
            get { return intUndoState; }
        }
        /// <summary>
        /// 是否可以进行内容修改的记录
        /// </summary>
        public bool CanContentChangeLog
        {
            get
            {
                return myContentChangeLog != null && myContentChangeLog.CanLog;
            }
        }

        /// <summary>
        /// 当前用于记录元素新增或删除操作的对象
        /// </summary>
        public A_ContentChangeLog ContentChangeLog
        {
            get { return myContentChangeLog; }
        }

        public int LockLevel
        {
            get { return intLockLevel; }
        }
        /// <summary>
        /// 文档内容是否被锁住不能修改
        /// </summary>
        public bool Locked
        {
            get
            {
                //				if( myContent.GetMaxLockLevel() >= mySaveLogs.CurrentSaveLog.Level )
                //					return true;
                //				else
                return bolLocked;
            }
            set
            {
                bolLocked = value;
            }
        }
        /// <summary>
        /// 文档内容是否改变
        /// </summary>
        public bool Modified
        {
            get { return myContent.Modified; }
            set { myContent.Modified = value; }
        }

        /// <summary>
        /// 文档内容对象
        /// </summary>
        public ZYContent Content
        {
            get { return myContent; }
            set { myContent = value; }
        }

        /// <summary>
        /// 是否自动清除选中状态
        /// </summary>
        public bool AutoClearSelection
        {
            get { return myContent.AutoClearSelection; }
            set { myContent.AutoClearSelection = value; }
        }

        /// <summary>
        /// 文档对象的文档信息设置对象
        /// </summary>
        public ZYDocumentInfo Info
        {
            get { return myInfo; }
            set { myInfo = value; }
        }

        public int DefaultRowHeight
        {
            get
            {
                return this.PixelToDocumentUnit(myView.DefaultRowPixelHeight);
            }
        }
        /// <summary>
        /// 绘制文档使用的视图对象
        /// </summary>
        public DocumentView View
        {
            get { return myView; }
            set { myView = value; }
        }

        /// <summary>
        /// 页脚字符串
        /// </summary>
        public string FooterString
        {
            get { return strFooterString; }
            set
            {
                strFooterString = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// 页眉字符串
        /// </summary>
        public string HeadString
        {
            get { return strHeadString; }
            set
            {
                strHeadString = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// 设置页眉xmldoc文档
        /// </summary>
        public XmlDocument HeadDocument
        {
            set
            {

                XmlElement head = value.SelectSingleNode("document/body") as XmlElement;
                string str = head.OuterXml;
                str = str.Replace("<body", "<header");
                str = str.Replace("body>", "header>");

                //if (str.Contains("<img"))
                //{
                //    string imgcontent = value.SelectSingleNode("document//body/p [@align=0]/img").InnerText;
                //    byte[] bytBuf = Convert.FromBase64String(imgcontent);
                //    _InsertImage(bytBuf);
                //    this.HeadString = str.Replace(imgcontent, "");
                //}
                //else
                //{
                this.HeadString = str;
                //}


                this.Refresh();
            }
        }
        /// <summary>
        /// 设置页脚xmldoc文档
        /// </summary>
        public XmlDocument FootDocument
        {
            set
            {
                XmlElement foot = value.SelectSingleNode("document/body") as XmlElement;
                string str = foot.OuterXml;
                str = str.Replace("<body", "<footer");
                str = str.Replace("body>", "footer>");
                this.FooterString = str;
                this.Refresh();
            }
        }

        public string RuntimeHeadString
        {
            get { return ExecuteVariable(strHeadString); }
        }
        public string RuntimeFooterString
        {
            get { return ExecuteVariable(strFooterString); }
        }
        /// <summary>
        /// 设置返回根元素
        /// </summary>
        public ZYTextContainer DocumentElement
        {
            get { return RootDocumentElement; }
            //set { RootDocumentElement = value; myElements.Clear(); } //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            set { RootDocumentElement = value; editingAreaElements[1].Clear(); } //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        }

        /// <summary>
        /// 返回所有显示的元素集合
        /// </summary>
        public System.Collections.ArrayList Elements
        {
            get { return myElements; }
            set { myElements = value; }
        }
        /// <summary>
        /// 返回编辑该文档的视图用户界面控件
        /// </summary>
        public ZYEditorControl OwnerControl
        {
            get { return myOwnerControl; }
            set
            {
                if (myOwnerControl != value)
                {
                    myOwnerControl = value;
                    if (myOwnerControl != null)
                    {
                        myOwnerControl.Document = this;
                        myView.Graph = myOwnerControl.CreateViewGraphics();
                        myOwnerControl.Pages = this.myPages;
                    }
                }
            }
        }



        #endregion ----------------------属性列表-----------------------------

        public Object Clone()
        {
            return new object();
        }
        public ZYTextElement GetElementByPos(int x, int y)
        {
            return myContent.GetElementAt(x, y);
        }

        internal void UpdateUserName()
        {
            if (myMarks.CanMark(mySaveLogs.CurrentUserName))
                bolLocked = false;
            else
                bolLocked = myInfo.LockForMark;
            this.Refresh();
        }

        public int GetMarkLevel(int savelogindex)
        {
            if (savelogindex >= 0 && savelogindex < mySaveLogs.Count)
                return mySaveLogs[savelogindex].Level;
            else
                return 0;
        }

        /// <summary>
        /// 向文本行集合添加文本行对象
        /// </summary>
        /// <param name="myLine">要添加的文本行对象</param>
        public void AddLine(ZYTextLine myLine)
        {
            myLines.Add(myLine);
        }

        /// <summary>
        /// 设置用户界面的鼠标光标
        /// </summary>
        /// <param name="vCursor">新的鼠标光标对象</param>
        internal void SetCursor(System.Windows.Forms.Cursor vCursor)
        {
            myCursor = vCursor;
            this.OwnerControl.Cursor = vCursor;
        }



        /// <summary>
        /// 向文档对象注册用于取消操作的动作对象
        /// </summary>
        /// <param name="a"></param>
        public void RegisteUndo(ZYEditorAction a)
        {
            if (intUndoState == 0 && a != null && a.isUndoable())
            {
                ZYEditorAction NewA = a.Clone();
                if (NewA != null)
                {
                    //myUndoList.Add(NewA);
                    //myRedoList.Clear();

                    UndoStack.Push(NewA);
                    UndoStack.ClearRedoStack();
                }
            }
        }

        #region 用于记录内容改变信息的函数群 **********************************************
        /// <summary>
        /// 开始记录内容的改变
        /// </summary>
        public void BeginContentChangeLog()
        {
            if (intLogLevel <= 0)
            {
                myContentChangeLog = new A_ContentChangeLog();
                myContentChangeLog.OwnerDocument = this;
                myContentChangeLog.SelectStart = myContent.SelectStart;
                myContentChangeLog.SelectLength = myContent.SelectLength;
            }
            intLogLevel++;
        }
        /// <summary>
        /// 结束记录内容的改变
        /// </summary>
        public void EndContentChangeLog()
        {
            intLogLevel--;
            if (intLogLevel <= 0)
            {
                if (myContentChangeLog != null && myContentChangeLog.isEnable())
                {
                    myContentChangeLog.SelectStart2 = myContent.SelectStart;
                    myContentChangeLog.SelectLength2 = myContent.SelectLength;

                    this.RegisteUndo(myContentChangeLog);
                    myContentChangeLog = null;
                }
                intLogLevel = 0;
            }
        }
        #endregion

        /// <summary>
        /// 判断文档内容是否可以修改
        /// </summary>
        /// <returns></returns>
        public bool CanModify()
        {
            //return !this.Locked;
            return true;
        }

        private string ExecuteVariable(string txt)
        {
            XDesignerCommon.VariableString str = new XDesignerCommon.VariableString(txt);
            str.SetVariable("pageindex", Convert.ToString(this.intPageIndex + this.intPageIndexFix));
            //str.SetVariable("pagecount", (this.myPages.Count + this.intPageIndexFix - 1).ToString());//Modified by wwj 2013-03-29 总页数需要与页号修正量“intPageIndexFix”联动

            str.SetVariable("pagecount", (this.myPages.Count + 1 + this.intPageIndexFix - 1).ToString()); //add by myc 2014-07-07 添加原因：新版页脚需要

            System.DateTime dtm = ZYTime.GetServerTime();//System.DateTime.Now ;
            str.SetVariable("year", dtm.Year.ToString());
            str.SetVariable("month", dtm.Month.ToString());
            str.SetVariable("dy", dtm.Day.ToString());
            str.SetVariable("hour", dtm.Hour.ToString());
            str.SetVariable("minute", dtm.Minute.ToString());
            str.SetVariable("secend", dtm.Second.ToString());
            return str.Execute();

            //return "返回运行时动态值";
        }

        //
        //		/// <summary>
        //		/// 获得图形绘制对象
        //		/// </summary>
        //		public System.Drawing.Graphics Graph
        //		{
        //			get{ return myView.Graph  ;}
        //		}

        //		/// <summary>
        //		/// 文档对象使用的用户信息列表
        //		/// </summary>
        //		public ZYUserList UserList
        //		{
        //			get{ return myUserList ;}
        //			set{ myUserList = value;}
        //		}



        /// <summary>
        /// 获得元素在文档元素列表中从0开始的序号
        /// </summary>
        /// <param name="myElement">元素对象</param>
        /// <returns>从0开始的序号</returns>
        public int IndexOf(ZYTextElement myElement)
        {
            //return myElements.IndexOf(myElement); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            return HBFElements.IndexOf(myElement); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        }

        public int PixelToDocumentUnit(int len)
        {
            return YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert(len, System.Drawing.GraphicsUnit.Pixel, this.intDocumentGraphicsUnit);
        }
        public System.Drawing.Size PixelToDocumentUnit(System.Drawing.Size size)
        {
            return YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert(size, System.Drawing.GraphicsUnit.Pixel, this.intDocumentGraphicsUnit);
        }
        public System.Drawing.Point PixelToDocumentUnit(System.Drawing.Point p)
        {
            return YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert(p, System.Drawing.GraphicsUnit.Pixel, this.intDocumentGraphicsUnit);
        }



        #region 实现 IDisposable 接口,销毁对象,释放所占据的资源
        /// <summary>
        /// 实现 IDisposable 接口,销毁对象,释放所占据的资源
        /// </summary>
        public void Dispose()
        {
            if (myView != null)
                myView.Dispose();
            //if (myDataSource != null && myDataSource.DBConn != null)
            //    myDataSource.DBConn.Dispose();
            //if (myEMRVBEngine != null)
            //    myEMRVBEngine.Close();
            //foreach (ZYTextElement myElement in myElements) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            foreach (ZYTextElement myElement in HBFElements) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                if (myElement is System.IDisposable)
                {
                    (myElement as System.IDisposable).Dispose();
                }
            }
        }
        #endregion

        #region 电子病历文本文档对象树操作函数群 **************************************************

        //		public bool ClearAllField( ZYTextContainer myRoot )
        //		{
        //			foreach( ZYTextElement myElement in myRoot.ChildElements )
        //			{
        //				if( myElement.Deleteted == false && myElement is ZYTextBlock )
        //				{
        //
        //				}
        //			}
        //			
        //		}

        /// <summary>
        /// 判断元素是否处于选择状态,若处于打印状态则永远返回false
        /// </summary>
        /// <param name="myElement">元素对象</param>
        /// <returns>true 该元素处于选择状态, false 不处于选择状态</returns>
        public bool isSelected(ZYTextElement myElement)
        {
            if (myInfo.Printing || myElement == null)
                return false;
            else
            {
                if (myContent.isSelected(myElement))
                    return true;
                else if (myElement.Parent is ZYTextBlock && myContent.isSelected(myElement.Parent))
                    return true;
                else
                    return false;
            }
            //
            //			if( myContent.isSelected( myElement ))
            //				return true;
            //			if( myElement.Parent != null && myContent.isSelected( myElement.Parent))
            //				return true;
            //			return false;
            //return myContent.isSelected( myElement);
        }

        /// <summary>
        /// 判断元素是否可以显示和打印
        /// </summary>
        /// <remarks>本文档对象支持显示文本层次,设置的文本层次和对象的创建或逻辑删除者编号有关系
        /// 当显示文本层次有效时,当元素的创建者序号大于该文本层次则不显示,
        /// 当元素的逻辑删除者序号大于该文本层次大于该文本层次则显示
        /// 若显示文本层次无效则根据ShowAll设置和元素是否标记的逻辑删除来处理
        /// 当设置了ShowAll 属性或者 元素没有逻辑删除则显示该元素,否则不显示</remarks>
        /// <param name="myElement">元素对象</param>
        /// <returns>是否可以显示和打印</returns>
        /// <seealso>ZYTextDocumentLib.ZYTextDocument.VisibleUserLevel</seealso>
        /// <seealso>ZYTextDocumentLib.ZYTextDocument.ShowAll</seealso>
        public bool isVisible(ZYTextElement myElement)
        {
            //if( bolDesignMode == false && myElement.Parent == myDocumentElement && ! (myElement is ZYTextContainer) )				return false;
            if (myElement.CreatorIndex == -1)
                return true;
            if (myInfo.VisibleUserLevel >= 0)
            {
                if (myElement.CreatorIndex > myInfo.VisibleUserLevel)
                    return false;
                if (myElement.DeleterIndex > myInfo.VisibleUserLevel)
                    return true;
            }
            else if (myInfo.ShowAll)
            {
                return true;
            }
            return !myElement.Deleteted;
        }



        //private void FixForNative(System.Collections.ArrayList elements)
        //{
        //    ZYTextLock Lock = null;
        //    for (int iCount = elements.Count - 1; iCount >= 0; iCount--)
        //    {
        //        ZYTextElement element = (ZYTextElement)elements[iCount];
        //        if (element is ZYTextLock)
        //        {
        //            Lock = (ZYTextLock)element;
        //        }
        //        else
        //        {
        //            if (Lock == null)
        //                element.Visible = true;
        //            else
        //            {
        //                ZYTextSaveLog log = mySaveLogs.SafeGet(element.CreatorIndex);
        //                if (log != null)
        //                {
        //                    if (log.Level != Lock.Level)
        //                    {
        //                        elements.RemoveAt(iCount);
        //                    }
        //                }
        //                else
        //                    element.Visible = true;
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 使用指定的委托进行元素的遍历
        /// </summary>
        /// <param name="vHandler">遍历元素使用的委托</param>
        public void EnumElements(EnumElementHandler vHandler)
        {
            if (RootDocumentElement != null && vHandler != null)
            {
                RootDocumentElement.EnumChildElements(vHandler, true);
            }
        }

        /// <summary>
        /// 获得所有最终可显示的元素的集合,最终可显示元素就是无用户显示层次设置且不显示逻辑删除的元素时可显示的元素
        /// </summary>
        /// <returns>保存最终可显示的元素的列表</returns>
        public System.Collections.ArrayList GetFinalElements()
        {
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            int iBack = myInfo.VisibleUserLevel;
            myInfo.VisibleUserLevel = -1;
            bool bBack = myInfo.ShowAll;
            myInfo.ShowAll = false;
            RootDocumentElement.AddElementToList(myList, false);
            myInfo.ShowAll = bBack;
            myInfo.VisibleUserLevel = iBack;
            return myList;
        }
        /// <summary>
        /// 获得最终可显示的文本
        /// </summary>
        /// <returns>文本数据</returns>
        public string GetFinalText()
        {
            return ZYTextElement.GetElementsText(this.GetFinalElements());
        }

        /// <summary>
        /// 获得从指定序号开始遍历可见元素列表,返回第一个没有删除标记的元素
        /// </summary>
        /// <param name="index">开始的序号，若小于0则为当前插入点的序号</param>
        /// <returns>找到的元素，若没找到则返回空</returns>
        public ZYTextElement GetLastNotDeletedElement(int index)
        {
            //if (index < 0 || index >= myElements.Count) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (index < 0 || index >= HBFElements.Count) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                index = myContent.SelectStart;
            //for (int iCount = index; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            for (int iCount = index; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                //ZYTextElement myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                ZYTextElement myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                if (myElement.Deleteted == false)
                    return myElement;
            }
            return null;
        }

        /// <summary>
        /// 删除文档中所有的空白行
        /// </summary>
        /// <returns>删除的元素个数</returns>
        public int RemoveBlankLine()
        {
            int DeleteCount = RootDocumentElement.RemoveBlankLine();
            if (DeleteCount > 0)
            {
                this.Modified = true;
                this.RefreshElements();
                this.RefreshLine();
                this.UpdateView();
            }
            return DeleteCount;
        }

        /// <summary>
        /// 删除所有的空白的关键字数据域及其周围的字符
        /// </summary>
        /// <param name="ContentLog"></param>
        /// <returns></returns>
        public int RemoveBlankKeyField(bool ContentLog)
        {
            int DeleteCount = RootDocumentElement.RemoveBlankKeyField2(ContentLog);
            if (DeleteCount > 0)
            {
                this.Modified = true;
                this.RefreshElements();
                this.RefreshLine();
                this.UpdateView();
            }
            return DeleteCount;
        }//public int RemoveBlankKeyField( bool ContentLog)

        #endregion



        /// <summary>
        /// 内部的向文档插入新元素前的预处理
        /// </summary>
        /// <remarks>本函数用于进行新增元素的预处理,若正在加载文档则立即返回true
        /// 否则对将要新增的元素进行信息设置,设置它的创建者为当用户,设置它的创建时间,
        /// 若新增的元素为字符元素,若创建者序号为1则设置文本为深蓝色,若为2则设置深红色</remarks>
        /// <param name="container">将要插入元素的父元素</param>
        /// <param name="NewElement">新插入的元素</param>
        /// <returns>是否插入新元素,若为false则取消插入</returns>
        internal bool BeforeInsertElemnt(ZYTextContainer container, ZYTextElement NewElement)
        {
            if (bolLoading == false)
            {
                //if (myContentChangeLog != null)
                //    this.myContentChangeLog.CanLog = false;
                NewElement.DeleterIndex = -1;
                //NewElement.DeleteTime = null;
                //NewElement.CreatorIndex = mySaveLogs.CurrentIndex;
                //NewElement.CreateTime = StringCommon.GetNowString12();
                //ZYTextChar myChar = NewElement as ZYTextChar;
                //if (myChar != null)
                //{
                //    if (myMarks.Count == 1)
                //    {
                //        myChar.ForeColor = System.Drawing.Color.DarkBlue;
                //    }
                //    if (myMarks.Count >= 2)
                //    {
                //        myChar.ForeColor = System.Drawing.Color.DarkRed;
                //    }
                //}
                //if (myContentChangeLog != null)
                //    this.myContentChangeLog.CanLog = true;
            }
            return true;
        }

        #region 编辑文档的通用例程 ****************************************************************

        /// <summary>
        /// 更新光标区域,暂无作用
        /// </summary>
        public void UpdateCaret()
        {
            //ZYTextElement myElement = myContent.CurrentElement;
            //myOwnerControl.MoveTextCaretTo(myElement.RealLeft, myElement.RealTop + myElement.Height, myElement.Height);

        }

        /// <summary>
        /// 查找字符
        /// </summary>
        /// <remarks></remarks>
        /// <param name="strFind">要查找的字符串</param>
        public bool _Find(string strFind)
        {
            return myContent.FindText(strFind);
        }
        /// <summary>
        /// 替换
        /// </summary>
        /// <param name="strFind">要查找的字符串</param>
        /// <param name="strReplace">替换后的字符串</param>
        public bool _Replace(string strFind, string strReplace)
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            string msg = "";
            bool isOK = myContent.ReplaceText(strFind, strReplace, out msg);
            myContentChangeLog.strUndoName = "替换";
            this.EndContentChangeLog();
            this.EndUpdate();

            //Add by wwj 2013-04-18 在替换方法结束后提醒，如果在myContent.ReplaceText方法中提醒会出现编辑器刷新的问题
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "警告");
            }

            return isOK;
        }
        /// <summary>
        /// 替换文档中所有的字符串
        /// </summary>
        /// <param name="strFind">要查找的字符串</param>
        /// <param name="strReplace">替换后的字符串</param>
        public void _ReplaceAll(string strFind, string strReplace)
        {
            //this.BeginUpdate();
            //this.BeginContentChangeLog();
            //myContent.ReplaceTextAll(strFind, strReplace);
            //myContentChangeLog.strUndoName = "替换所有";
            //this.EndContentChangeLog();
            //this.EndUpdate();
        }
        /// <summary>
        /// 选中所有的内容
        /// </summary>
        public void _SelectAll()
        {
            myContent.SelectAll();
        }
        /// <summary>
        /// 向下翻页
        /// </summary>
        public void _PageDown()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            //myContent.MoveStep(myOwnerControl.ClientSize.Height); //add by myc 2014-08-13 注释原因：翻页时光标定位不准确

            #region add by myc 2014-08-13 移动当前光标至下一页首行
            if (editingAreaFlag != 1) return;
            ZYTextElement currEle = HBFElements[myContent.SelectStart] as ZYTextElement;
            int resultIndex = this.ContainsDescPoint(currEle.RealLeft, currEle.RealTop);
            if (resultIndex != -1
                && resultIndex + 1 < this.OwnerControl.PagesTransform.GetHBFTransforms(1).Count)
            {
                SimpleRectangleTransform nextPageTransform = this.OwnerControl.PagesTransform.GetHBFTransforms(1)[resultIndex + 1] as SimpleRectangleTransform;
                myContent.MoveToNoSelectingArea(currEle.RealLeft, nextPageTransform.DescRect.Top + 1);

                //滚动视图以便当前光标显示位置可见
                ZYTextLine currLine = myContent.CurrentLine;
                int nextLineBottomInClient = nextPageTransform.UnTransformPoint(currLine.RealLeft, currLine.RealTop + currLine.FullHeight).Y;
                int scrollHeight = nextLineBottomInClient - this.OwnerControl.ClientSize.Height; //视图控件滚动条需向下滚动的高度增量（正值）
                this.OwnerControl.SetAutoScrollPosition(new Point(-this.OwnerControl.AutoScrollPosition.X,
                                                     scrollHeight - this.OwnerControl.AutoScrollPosition.Y));
                this.OwnerControl.OnScroll();
            }
            #endregion

            UpdateCaret();
        }
        /// <summary>
        /// 向上翻页
        /// </summary>
        public void _PageUp()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            //myContent.MoveStep(0 - myOwnerControl.ClientSize.Height);  //add by myc 2014-08-13 注释原因：翻页时光标定位不准确

            #region add by myc 2014-08-13 移动当前光标至上一页首行
            if (editingAreaFlag != 1) return;
            ZYTextElement currEle = HBFElements[myContent.SelectStart] as ZYTextElement;
            int resultIndex = this.ContainsDescPoint(currEle.RealLeft, currEle.RealTop);
            if (resultIndex != -1
                && resultIndex - 1 >= 0)
            {
                SimpleRectangleTransform prePageTransform = this.OwnerControl.PagesTransform.GetHBFTransforms(1)[resultIndex - 1] as SimpleRectangleTransform;
                myContent.MoveToNoSelectingArea(currEle.RealLeft, prePageTransform.DescRect.Top);

                //滚动视图以便当前光标显示位置可见
                ZYTextLine currLine = myContent.CurrentLine;
                int nextLineBottomInClient = prePageTransform.UnTransformPoint(currLine.RealLeft, currLine.RealTop - this.Info.LineSpacing).Y;
                int scrollHeight = nextLineBottomInClient - 0; //视图控件滚动条需向下滚动的高度增量（负值）
                this.OwnerControl.SetAutoScrollPosition(new Point(-this.OwnerControl.AutoScrollPosition.X,
                                                     scrollHeight - this.OwnerControl.AutoScrollPosition.Y));
                this.OwnerControl.OnScroll();
            }
            #endregion

            UpdateCaret();
        }
        /// <summary>
        /// 移动到行首
        /// </summary>
        public void _MoveHome()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            myContent.MoveHome();
            UpdateCaret();
        }
        /// <summary>
        /// 移动到行尾
        /// </summary>
        public void _MoveEnd()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            myContent.MoveEnd();
            UpdateCaret();
        }
        /// <summary>
        /// 向上移动一行
        /// </summary>
        public void _MoveUp()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            myContent.MoveUpOneLine();
            UpdateCaret();
        }
        /// <summary>
        /// 向下移动一行
        /// </summary>
        public void _MoveDown()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            myContent.MoveDownOneLine();
            UpdateCaret();
        }
        /// <summary>
        /// 向左移动一个元素
        /// </summary>
        public void _MoveLeft()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            myContent.MoveLeft();
            UpdateCaret();
        }
        /// <summary>
        /// 向右移动一个元素
        /// </summary>
        public void _MoveRight()
        {
            //myContent.AutoClearSelection = ! myOwnerControl.HasShiftPressing ;
            myContent.MoveRight();
            UpdateCaret();
        }

        #region bwy 撤销 重做 :
        ///// <summary>
        ///// 执行撤销操作
        ///// </summary>
        ///// <returns></returns>
        public bool _Undo()
        {

            if (intUndoState == 0 && UndoStack.UndoItemCount > 0)
            {
                intUndoState = 1;

                ZYEditorAction a = UndoStack.undostack.Pop();

                //ZYEditorAction a = (ZYEditorAction)myUndoList[myUndoList.Count - 1];
                //myUndoList.RemoveAt(myUndoList.Count - 1);
                if (a.Undo())
                {
                    if (a.SelectStart >= 0)
                    {
                        myContent.SetSelection(a.SelectStart, a.SelectLength);
                    }
                    //myRedoList.Add(a);
                    UndoStack.redostack.Push(a);
                    intUndoState = 0;
                    return true;
                }
                intUndoState = 0;
            }
            return false;
        }

        ///// <summary>
        ///// 执行重复操作
        ///// </summary>
        ///// <returns></returns>
        public bool _Redo()
        {
            if (intUndoState == 0 && UndoStack.RedoItemCount > 0)
            {
                intUndoState = 2;
                //UndoStack.Redo();

                ZYEditorAction a = (ZYEditorAction)UndoStack.redostack.Pop();
                //myRedoList[myRedoList.Count - 1];
                //myRedoList.RemoveAt(myRedoList.Count - 1);
                a.Redo();
                if (a.SelectStart2 >= 0)
                {
                    myContent.SetSelection(a.SelectStart2, a.SelectLength2);
                }
                //myUndoList.Add(a);
                UndoStack.undostack.Push(a);
                intUndoState = 0;
            }
            return true;
        }

        #endregion bwy :
        /// <summary>
        /// 获得当前插入点所在的段落元素
        /// </summary>
        /// <returns>获得的段落元素对象，若没有则返回空</returns>
        public ZYTextParagraph GetOwnerParagraph()
        {
            //for (int iCount = myContent.SelectStart; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            for (int iCount = myContent.SelectStart; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                //if ((myElements[iCount] as ZYTextElement).Parent is ZYTextParagraph) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                if ((HBFElements[iCount] as ZYTextElement).Parent is ZYTextParagraph) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                {
                    //return ((myElements[iCount] as ZYTextElement).Parent as ZYTextParagraph); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    return ((HBFElements[iCount] as ZYTextElement).Parent as ZYTextParagraph); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                }
            }
            return null;
        }


        #region Insert 方法群
        /// <summary>
        /// 在文档最后添加锁定标记
        /// </summary>
        /// <returns>新增的锁定标记对象</returns>
        public ZYTextLock _InsertLock()
        {
            //判断是否已经签名，如果已经签名，则不允许重复签名
            //			bool BLock=false;
            //			for(int i=myContent.Elements.Count-2;i>=0;i--)
            //			{
            //				if (myContent.Elements[i] is ZYTextLock )
            //				{
            //					if (BLock==false)
            //					{
            //						return null;
            //					}
            //					break;
            //				}
            //				else
            //				{
            //					BLock=true;
            //				}
            //			}
            //==================================================
            if (this.Locked) return null;
            this.BeginUpdate();
            this.BeginContentChangeLog();
            ZYTextLock Lock = new ZYTextLock();
            Lock.UserName = mySaveLogs.CurrentSaveLog.UserName;
            Lock.DateTime = ZYTime.GetServerTime();//DateTime.Now ;
            Lock.Level = mySaveLogs.CurrentSaveLog.Level;

            //myContent.MoveSelectStart(myContent.Elements.Count - 1); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            myContent.MoveSelectStart(myContent.HBFElements.Count - 1); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

            //myContent.InsertElement( Lock );
            myContent.InsertLock(Lock);
            this.EndContentChangeLog();
            this.EndUpdate();
            return Lock;
        }
        /// <summary>
        /// 插入文本块
        /// </summary>
        /// <param name="strName">文本块名称</param>
        public void _InsertDiv(string strName)
        {
            if (this.Locked) return;
            this.BeginUpdate();
            //this.BeginContentChangeLog();
            if (myContent.HasSelected())
                //myContent.DeleteSeleciton();
                myContent.DeleteSelectedElements(); //add by myc 2014-06-16 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
            else if (myOwnerControl.InsertMode == false)
                myContent.DeleteCurrentElement();
            ZYTextDiv myDiv = new ZYTextDiv();
            myDiv.Name = strName;
            //myDiv.Title = strName;
            //myDiv.HideTitle = false;
            myContent.AutoClearSelection = true;
            if ((myContent.PreElement is ZYTextParagraph) == false)
                myContent.InsertElement(new ZYTextParagraph());
            myContent.InsertElement(myDiv);
            //myContentChangeLog.strUndoName = "插入文本层";
            myContent.MoveSelectStart(myContent.SelectStart - 1);
            //this.EndContentChangeLog();
            this.EndUpdate();
        }
        /// <summary>
        /// 插入一个字符
        /// </summary>
        /// <param name="vChar">要插入的字符</param>
        /// <remarks>若要插入的字符为回车键则插入一个段落元素,否则插入一个字符元素</remarks>
        /// <returns>本操作新增的元素对象</returns>
        public ZYTextElement _InsertChar(char vChar)
        {
            #region add by myc 2014-05-20 添加原因：处理在表格中按下TAB键时的移动光标问题
            if (vChar == '\t')
            {
                InsertTABMoveCaret();
                return null;
            }
            #endregion

            //if (this.Content.CurrentElement.Parent is ZYMacro)
            //{
            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("宏元素无法插入内容");
            //    return null;
            //}
            //if (this.Content.CurrentElement.Parent is ZYSelectableElement)
            //{
            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("复用元素请双击编辑");
            //    return null;
            //}

            //myOwnerControl.SaveScrollPos();
            ZYTextElement NewElement = null;
            //if (this.Locked) return null;
            this.BeginUpdate();

            this.BeginContentChangeLog();
            if (myContent.HasSelected())
            {
                //if (!myContent.DeleteSeleciton())//Add by wwj 2013-02-01 删除失败后退出，防止操作失败后进行其他的操作
                if (!(myContent.DeleteSelectedElements())) //add by myc 2014-05-27 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
                {
                    this.EndContentChangeLog();
                    this.EndUpdate();
                    return null;
                }
            }
            else
            {
                if (myOwnerControl.InsertMode == false && (int)vChar != 13)
                    myContent.DeleteCurrentElement();
            }

            //记录改变前的行数 add by wwj 2012-06-06
            //ZYTextContainer grandParent = this.Content.CurrentElement.Parent.Parent;
            //int preLineCount = grandParent.Lines.Count; //add by myc 2014-05-08 注释原因 CurrentElement不存在怎么办？其父容器假如不存在又怎么办，导致了系统级异常你发现了吗？ 应该修正为如下代码段：
            ZYTextContainer grandParent = null;
            int preLineCount = 0;
            if (this.Content.CurrentElement != null)
            {
                if (this.Content.CurrentElement.Parent.Parent != null)
                {
                    grandParent = this.Content.CurrentElement.Parent.Parent;
                }
            }




            //如果为回车符
            if ((int)vChar == 13)//'\r'
            {
                //************Add by wwj 2012-04-16 移除段落缩进***********************
                //string strBlank = myContent.GetCurrentLineHeadBlank();
                string strBlank = string.Empty;
                //********************************************************************

                if (myOwnerControl.HasShiftPressing())
                {
                    ZYTextLineEnd myL = new ZYTextLineEnd();
                    myL.OwnerDocument = this;
                    myContent.InsertElement(myL);
                    myContentChangeLog.strUndoName = "输入软回车";
                    NewElement = myL;
                }
                else
                {
                    //2019.8.15-hdf：当焦点在块元素内进行换行时，向div插入硬回车改为向块元素内插入软回车
                    ZYTextElement eleRight = this.Content.CurrentElement;
                    ZYTextElement eleLeft = new ZYTextElement();
                    if (this.Content.SelectStart > 0)
                    {
                        eleLeft = this.Content.HBFElements[this.Content.SelectStart - 1] as ZYTextElement;
                    }
                    if (((eleRight.Parent is ZYMacro || eleRight.Parent is ZYReplace || eleRight.Parent is ZYFormatString || eleRight.Parent is ZYDiag || eleRight.Parent is ZYSubject) && (eleRight.Parent as ZYTextBlock).IsFocus)
                        || ((eleLeft.Parent is ZYMacro || eleLeft.Parent is ZYReplace || eleLeft.Parent is ZYFormatString || eleLeft.Parent is ZYDiag || eleLeft.Parent is ZYSubject) && (eleLeft.Parent as ZYTextBlock).IsFocus)
                        )
                    {
                        //光标左或右为块元素的那三个子类，并且获取了焦点，则向块元素插入软回车元素
                        ZYTextLineEnd myL = new ZYTextLineEnd();
                        myL.OwnerDocument = this;
                        myContent.InsertElement(myL);
                        myContentChangeLog.strUndoName = "输入软回车";
                        NewElement = myL;
                    }
                    else
                    {
                        ZYTextParagraph myP = new ZYTextParagraph();
                        myP.OwnerDocument = this;
                        ZYTextParagraph CurrentP = this.GetOwnerParagraph();
                        if (CurrentP != null)
                            myP.Align = CurrentP.Align;
                        myContent.InsertParagraph(myP);

                        myContentChangeLog.strUndoName = "输入硬回车";
                        NewElement = myP;
                    }
                }
                if (strBlank != null && strBlank.Length > 0)
                    myContent.InsertString(strBlank);
            }
            else
            {
                myContent.AutoClearSelection = true;
                NewElement = myContent.InsertChar(vChar);
                myContentChangeLog.strUndoName = "输入字符 " + vChar;
            }

            //add by wwj 2012-06-06 处理输入的字符，如果单元格内限定了不能换行，则对刚刚输入的字符进行处理
            //grandParent.ProcessInsertChar(preLineCount); //add by myc 2014-05-08 注释原因 grandParent假如不存在又怎么办，导致了系统级异常你发现了吗？ 应该修正为如下代码段：
            if (grandParent != null)
            {
                grandParent.ProcessInsertChar(preLineCount);
            }

            myContent.SelectLength = 0;
            this.EndContentChangeLog();
            this.EndUpdate();
            return NewElement;
        }

        public void _InsertImage(byte[] data)
        {
            MemoryStream ms = new System.IO.MemoryStream(data);
            Image img = System.Drawing.Image.FromStream(ms);
            _InsertImage(img);
        }

        /// <summary>
        /// 插入一个图片
        /// </summary>
        /// <param name="strSrc">图片来源</param>
        /// <param name="strType">图片类型</param>
        public void _InsertImage(string imgPath)
        {
            Image img = ZYTextConst.ImageFromURL(imgPath);
            _InsertImage(img);
        }

        public void _InsertImage(Image img)
        {
            ZYTextImage myImg = new ZYTextImage();
            myImg.Image = img;

            myImg.SaveInFile = true;
            if (myImg.Image != null)
            {
                int innerWidth = Pages.StandardWidth;
                myImg.Width = PixelToDocumentUnit(myImg.Image.Width);
                myImg.Height = PixelToDocumentUnit(myImg.Image.Height);

                if (myImg.Width > innerWidth)
                {
                    double d1 = innerWidth;
                    double d2 = myImg.Width;
                    double n = d1 / d2;//比例因数
                    myImg.Width = (int)(myImg.Width * n) - 2;
                    myImg.Height = (int)(myImg.Height * n);
                }
            }
            _InsertElement(myImg);
        }

        public void _InsertImage(Image img, string userid)
        {
            ZYTextImage myImg = new ZYTextImage();
            myImg.Image = img;
            myImg.ImageByUserID = userid;
            myImg.SaveInFile = true;
            if (myImg.Image != null)
            {
                int innerWidth = Pages.StandardWidth;
                myImg.Width = PixelToDocumentUnit(myImg.Image.Width);
                myImg.Height = PixelToDocumentUnit(myImg.Image.Height);

                if (myImg.Width > innerWidth)
                {
                    double d1 = innerWidth;
                    double d2 = myImg.Width;
                    double n = d1 / d2;//比例因数
                    myImg.Width = (int)(myImg.Width * n) - 2;
                    myImg.Height = (int)(myImg.Height * n);
                }
            }
            _InsertElement(myImg);
        }

        public void _InsertImage(Image img, string userid, int imageWidth, int imageHeight)
        {
            ZYTextImage myImg = new ZYTextImage();
            myImg.Image = img;
            myImg.ImageByUserID = userid;
            myImg.SaveInFile = true;
            if (myImg.Image != null)
            {
                int innerWidth = Pages.StandardWidth;
                myImg.Width = PixelToDocumentUnit(imageWidth);
                myImg.Height = PixelToDocumentUnit(imageHeight);

                //if (myImg.Width > innerWidth)
                //{
                //    double d1 = innerWidth;
                //    double d2 = myImg.Width;
                //    double n = d1 / d2;//比例因数
                //    myImg.Width = (int)(myImg.Width * n) - 2;
                //    myImg.Height = (int)(myImg.Height * n);
                //}
            }
            _InsertElement(myImg);
        }



        /// <summary>
        /// 插入一个元素
        /// </summary>
        /// <param name="NewElement">新的元素</param>
        public void _InsertElement(ZYTextElement NewElement)
        {
            if (this.Locked) return;
            this.BeginUpdate();
            this.BeginContentChangeLog();
            if (myContent.HasSelected())
                //myContent.DeleteSeleciton();
                myContent.DeleteSelectedElements(); //add by myc 2014-06-16 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
            else if (myOwnerControl.InsertMode == false)
                myContent.DeleteCurrentElement();
            myContent.AutoClearSelection = true;
            myContent.InsertElement(NewElement); //--- insert
            myContentChangeLog.strUndoName = "插入元素";
            //myContent.MoveSelectStart(myContent.SelectStart + 1);
            this.EndContentChangeLog();
            this.EndUpdate();
        }
        /// <summary>
        /// 插入一个块元素
        /// </summary>
        /// <param name="NewElement"></param>
        public void _InsertBlock(ZYTextBlock NewElement)
        {

            _InsertElement(NewElement);
            int intMoveStep = (NewElement as ZYTextBlock).ChildCount;
            myContent.MoveSelectStart(myContent.SelectStart + intMoveStep - 1);
            //myContent.MoveSelectStart(myContent.SelectStart + intMoveStep - 1);//因为_InsertElement->InsertElement已经进行了加1的操作，所以这里要减1

            //因为Block中要显示的值是char，在进行插入char的方法中，已经进行 加1操作

        }
        /// <summary>
        /// 插入字符串,主要用来接受外来的字符串数据
        /// </summary>
        /// <param name="str"></param>
        public void _InserString(string str)
        {
            if (this.Locked) return;
            if (string.IsNullOrEmpty(str)) return;

            //if (this.Content.CurrentElement.Parent is ZYMacro)
            //{
            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("宏元素无法插入内容");
            //    return;
            //}
            //if (this.Content.CurrentElement.Parent is ZYSelectableElement)
            //{
            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("复用元素请双击编辑");
            //    return;
            //}


            this.BeginUpdate();
            this.BeginContentChangeLog();
            if (myContent.HasSelected())
            {
                //if (!myContent.DeleteSeleciton())//Add by wwj 2013-02-01 删除失败后退出，防止操作失败后进行其他的操作
                if (!(myContent.DeleteSelectedElements())) //add by myc 2014-05-27 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
                {
                    this.EndContentChangeLog();
                    this.EndUpdate();
                    return;
                }
            }
            else
            {
                if (myOwnerControl.InsertMode == false)
                    myContent.DeleteCurrentElement();
            }
            //控制单元格中是否可以换行，可以换行则走原有的路线，否则需要一个个字符的录入 add by wwj 2012-06-07
            //ZYTextElement myElement = (ZYTextElement)myElements[this.Content.SelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[this.Content.SelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

            TPTextCell cell = this.Content.GetParentByElement(myElement, ZYTextConst.c_Cell) as TPTextCell;
            if (cell != null && !cell.CanInsertEnter)
            {
                foreach (char c in str)
                {
                    this._InsertChar(c);
                }
            }
            else
            {

                this.Content.InsertString(str);
            }

            this.EndContentChangeLog();
            this.EndUpdate();
        }

        #endregion

        /// <summary>
        /// 删除元素,若存在选中元素则删除选中的元素,否则删除当前元素
        /// </summary>
        public void _Delete(params object[] flag)
        {
            if (this.Locked) return;

            //只有首尾都在范围内才继续执行
            if (this.OwnerControl.IsInActiveEditArea(this.Content.CurrentElement))
            {
                ZYTextElement endele = null;

                //endele = this.Content.Elements[this.Content.SelectStart + this.Content.SelectLength] as ZYTextElement; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                endele = this.Content.HBFElements[this.Content.SelectStart + this.Content.SelectLength] as ZYTextElement; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                //endele 在范围内，且不是最后一个元素
                if (this.OwnerControl.IsInActiveEditArea(endele) && endele != this.Content.GetPreElement(this.OwnerControl.ActiveEditArea.EndElement))
                {
                }
                else
                {
                    return;
                }
            }

            this.BeginUpdate();
            this.BeginContentChangeLog();
            if (myContent.HasSelected())
                //myContent.DeleteSeleciton();
                myContent.DeleteSelectedElements(); //add by myc 2014-06-16 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
            else
            {
                int OldSelectStart = myContent.SelectStart;
                int intDeleteFlag = myContent.DeleteCurrentElement(flag);
                if (intDeleteFlag == 2 && myInfo.ShowAll)
                {
                    this.Content.SetSelection(OldSelectStart + 1, 0);
                }
            }
            myContentChangeLog.strUndoName = "删除元素";
            this.EndContentChangeLog();



            this.EndUpdate();
        }
        public string UsId = null;//签名图片对应的用户id
        /// <summary>
        /// 处理退格键,删除插入点前的元素
        /// </summary>
        public void _BackSpace(params object[] flag)
        {
            if (this.Locked) return;

            //如果是在编辑部分区域，如果它的前一个字符不在范围内，退出
            if (this.OwnerControl.ActiveEditArea != null)
            {
                ZYTextElement preEle = this.Content.PreElement;
                ZYTextElement topEle = this.OwnerControl.ActiveEditArea.TopElement;
                //ZYTextElement endEle = this.OwnerControl.ActiveEditArea.EndElement;

                if (topEle.RealTop + topEle.Height <= preEle.RealTop && preEle.RealTop + preEle.Height <= this.OwnerControl.ActiveEditArea.End)
                {
                    //前一个元素也在范围内，继续操作
                }
                else
                {
                    //前一个元素超出范围，不操作
                    return;
                }
            }

            //判断是否可以删除选中元素,如果选中多个单元格的内容则不允许删除 Add By wwj 2012-04-24
            //if (!this.Content.CanDeleteSelectElement())
            //{
            //    return;
            //}

            this.BeginUpdate();
            this.BeginContentChangeLog();
            if (myContent.HasSelected())
            {  //myContent.DeleteSeleciton();
                myContent.DeleteSelectedElements(); //add by myc 2014-06-16 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
                UsId = myContent.UsId;
            }
            else
            {
                int OldSelectStart = myContent.SelectStart;
                int intDeleteFlag = myContent.DeletePreElement(flag);
                if (intDeleteFlag == 2 && myInfo.ShowAll)
                {
                    myContent.SetSelection(OldSelectStart - 1, 0);
                }
            }
            myContentChangeLog.strUndoName = "退格删除";
            this.EndContentChangeLog();



            this.EndUpdate();
        }
        /// <summary>
        /// mfb是否是逻辑删除
        /// </summary>
        /// <returns></returns>
        public bool IsLogicDelete()
        {
            if (myInfo.AutoLogicDelete == false)
            {
                return false;
            }
            //如果当前用户的级别大于0,则是逻辑删除
            if (0 < mySaveLogs.CurrentSaveLog.Level)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// mfb确认进行删除操作
        /// </summary>
        /// <param name="myElement">将要删除的元素</param>
        /// <returns>0:确认删除元素 1:不删除该元素 2:对该元素进行逻辑删除</returns>
        public int isDeleteElement(ZYTextElement myElement)
        {
            bool ld = IsLogicDelete();
            if (ld && myElement.Parent.Locked == false)
            {
                if (ld)
                {
                    if (myElement.CreatorIndex == mySaveLogs.CurrentIndex)
                        return 0;
                }

                if (myElement.Parent != null && myElement.Parent is ZYTextBlock) //add by myc 2014-03-05
                {
                    if (myElement.Parent is ZYMacro) return -1;
                    (myElement.Parent as ZYTextBlock).Deleteted = true;
                    if (myOwnerControl != null)
                    {
                        foreach (ZYTextElement e in (myElement.Parent as ZYTextBlock).ChildElements)
                            myOwnerControl.AddInvalidateRect(e.Bounds);
                    }
                }
                else if (myElement.Parent != null && myElement is ZYElement) //add by myc 2014-03-05
                {
                    //(myElement.Parent as ZYTextBlock).Deleteted = true;
                    //if (myOwnerControl != null)
                    //{
                    //    foreach (ZYTextElement e in (myElement.Parent as ZYTextBlock).ChildElements)
                    //        myOwnerControl.AddInvalidateRect(e.Bounds);
                    //}
                }
                else
                {
                    if (myElement.Parent is ZYMacro) return -1;
                    myElement.Deleteted = true;
                    if (myOwnerControl != null)
                        myOwnerControl.AddInvalidateRect(myElement.Bounds);
                }

                //myElement.Deleteted = true; //add by myc 2014-03-05已被注释掉，痕迹保留支持结构化元素需要
                //if (myOwnerControl != null)
                //    myOwnerControl.AddInvalidateRect(myElement.Bounds);
                return 2;
            }
            return 0;
        }

        ///// <summary>
        ///// 修改对象大小
        ///// </summary>
        ///// <param name="myObj">要修改的对象</param>
        ///// <param name="NewWidth">新的宽度</param>
        ///// <param name="NewHeight">新的高度</param>
        ///// <returns>本操作是否成功,若没有进行修改操作则返回false</returns>
        //public bool _Resize(ZYTextObject myObj, int NewWidth, int NewHeight)
        //{
        //    if (myObj != null && myObj.CanResize && myObj.Width != NewWidth && myObj.Height != NewHeight)
        //    {
        //        myObj.Width = NewWidth;
        //        myObj.Height = NewHeight;
        //        this.RefreshLine();
        //        this.UpdateView();
        //        myContent.CurrentSelectElement = myObj;
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// 剪切文本
        /// </summary>
        public void _Cut()
        {
            if (this.Locked) return;
            if (OnIsUseShearPlate != null && OnIsUseShearPlate() == false)//add by lhl 2015-07-21 禁用剪切板
            {
                return;
            }
            this._Copy();
            this._Delete();
            //			string strText = myContent.GetSelectText();
            //			ClipboardHandler.SetTextToClipboard( strText);
            //			this.BeginContentChangeLog();
            //			myContent.DeleteSeleciton();
            //			myContentChangeLog.strUndoName = "剪切";
            //			this.EndContentChangeLog();
        }
        /// <summary>
        /// 复制文本
        /// </summary>
        public bool _Copy()
        {
            try
            {
                if (OnIsUseShearPlate() != null && OnIsUseShearPlate() == false)//add by lhl 2015-07-21 禁用剪切板
                {
                    return false;
                }
                System.Collections.ArrayList myList = myContent.GetSelectElements();
                ZYTextElement.FixElementsForParent(myList);
                if (myList != null && myList.Count > 0)
                {
                    System.Windows.Forms.DataObject myDataObject = new System.Windows.Forms.DataObject();
                    string selText = ZYTextElement.GetElementsText(myList);
                    myDataObject.SetData(System.Windows.Forms.DataFormats.UnicodeText, selText);

                    //不允许把编辑器的文档格式粘贴到外部剪切板，如果这样就泄漏了机密
                    //myInfo.SaveMode = 0;
                    //System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
                    //myDoc.PreserveWhitespace = true;
                    //myDoc.AppendChild(myDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));

                    //if (ZYTextElement.ElementsToXML(GetRealElements(myList), myDoc.DocumentElement))
                    //{
                    //    string strXML = myDoc.DocumentElement.OuterXml;
                    //    myDataObject.SetData(ZYTextConst.c_ClipboardDataFormat, strXML);
                    //}

                    //放在内部剪切板中
                    //如果是设计模式，复制结构化数据
                    System.Windows.Forms.DataObject myInnerDataObject = new System.Windows.Forms.DataObject();
                    //if (this.Info.DocumentModel == DocumentModel.Design)   *********Modified by wwj 2012-07-24*********
                    {
                        System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
                        myDoc.PreserveWhitespace = true;
                        myDoc.AppendChild(myDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));

                        string strXML = string.Empty;
                        if (ZYTextElement.ElementsToXML(GetRealElements(myList), myDoc.DocumentElement))
                        {
                            strXML = myDoc.DocumentElement.OuterXml;
                            myInnerDataObject.SetData(ZYTextConst.c_ClipboardDataFormat, strXML);
                        }

                        //*********Modified by wwj 2012-07-24*********
                        if (this.Info.DocumentModel == DocumentModel.Design || strXML.IndexOf("<img") >= 0)
                        {
                            EmrClipboard.Data = myInnerDataObject;
                        }
                        else
                        {
                            EmrClipboard.Data = myDataObject;
                        }
                    }
                    //否则，复制文本数据

                    //*********Modified by wwj 2012-07-24*********
                    //else
                    //{
                    //    //要记录当前内容是哪个病人的
                    //    EmrClipboard.PatientID = this.Info.PatientID;
                    //    EmrClipboard.Data = myDataObject;
                    //}

                    System.Windows.Forms.Clipboard.SetDataObject(myDataObject, true);
                    return true;
                }
            }
            catch (Exception ext)
            {
                //ZYErrorReport.Instance.SourceException = ext;
                //ZYErrorReport.Instance.SourceObject = this;
                //ZYErrorReport.Instance.UserMessage = "复制数据错误";
                //ZYErrorReport.Instance.ReportError();
            }
            return false;
        }

        /// <summary>
        /// 把基于单个字符的列表，转换为基于元素的列表 bwy 加
        /// </summary>
        /// <param name="elements">基于单个字符的列表</param>
        /// <returns>基于元素的列表</returns>
        public ArrayList GetRealElements(ArrayList elements)
        {
            ArrayList al = new ArrayList();
            foreach (ZYTextElement ele in elements)
            {
                if (ele.Parent is ZYTextBlock)
                {
                    if (al.Contains(ele.Parent))
                    {
                        continue;
                    }
                    else
                    {
                        al.Add(ele.Parent);
                    }
                }
                else
                {
                    al.Add(ele);
                }
            }
            return al;
        }
        /// <summary>
        /// 粘贴文本
        /// </summary>
        public void _Paste()
        {
            //TODO:需要在此先判断粘贴权限
            if (this.Locked) return;
            if (OnIsUseShearPlate() != null && OnIsUseShearPlate() == false)//add by lhl 2015-07-21 禁用剪切板
            {
                return;
            }
            //Modified by wwj 2012-06-19 应老板要求此处删掉
            //if (!CanPase)
            //{
            //    MessageBox.Show("当前状态：" + this.Info.DocumentModel + "无数据，或非同一人数据不允许粘贴操作。");
            //    return;
            //}

            //优先使用内部剪切板，如果为空，才使用系统剪切板来粘贴文本
            if (EmrClipboard.Data != null)
            {
                try
                {
                    System.Windows.Forms.IDataObject myData = EmrClipboard.Data as System.Windows.Forms.IDataObject;//System.Windows.Forms.Clipboard.GetDataObject();
                    //只有编辑状态才可以粘贴格式化数据
                    if (myData.GetDataPresent(ZYTextConst.c_ClipboardDataFormat)
                        /*&& this.Info.DocumentModel == DocumentModel.Design *********Modified by wwj 2012-07-24********* */)
                    {
                        System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
                        myDoc.PreserveWhitespace = true;
                        string strXML = (string)myData.GetData(ZYTextConst.c_ClipboardDataFormat);
                        myDoc.LoadXml(strXML);
                        System.Collections.ArrayList myList = new System.Collections.ArrayList();
                        this.LoadElementsToList(myDoc.DocumentElement, myList);
                        if (myList.Count > 0)
                        {
                            foreach (ZYTextElement myElement in myList)
                            {
                                if (myElement is ZYTextContainer)
                                    (myElement as ZYTextContainer).ClearSaveLog();
                                #region bwy
                                //myElement.RefreshSize();
                                //因为 ZYEOF的RefreshSize 出错了，所以把它注释掉了，也没发现有什么问题
                                #endregion bwy

                            }
                            this.BeginUpdate();
                            this.BeginContentChangeLog();
                            if (myContent.HasSelected())
                                //myContent.DeleteSeleciton();
                                myContent.DeleteSelectedElements(); //add by myc 2014-06-16 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
                            myContent.InsertRangeElements(myList);

                            this.EndContentChangeLog();
                            this.EndUpdate();
                        }
                    }
                    else
                    {
                        string strText = ClipboardHandler.GetTextFromClipboard();
                        if (strText != null)
                        {
                            //控制单元格中是否可以换行，可以换行则走原有的路线，否则需要一个个字符的录入 add by wwj 2012-06-07
                            //ZYTextElement myElement = (ZYTextElement)myElements[this.Content.SelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                            ZYTextElement myElement = (ZYTextElement)HBFElements[this.Content.SelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                            TPTextCell cell = this.Content.GetParentByElement(myElement, ZYTextConst.c_Cell) as TPTextCell;
                            if (cell != null && !cell.CanInsertEnter)
                            {
                                foreach (char c in strText)
                                {
                                    this._InsertChar(c);
                                }
                            }
                            else
                            {
                                this.BeginUpdate();
                                this.BeginContentChangeLog();
                                myContent.ReplaceSelection(strText);
                                //myContentChangeLog.strUndoName = "粘贴";
                                this.EndContentChangeLog();
                                this.EndUpdate();
                            }
                        }
                    }

                }//try
                catch (Exception ext)
                {
                    //ZYErrorReport.Instance.DebugPrint("试图粘贴数据错误:" + ext.ToString());
                    MessageBox.Show(ext.Message);
                }
            }
            //使用系统剪切板粘贴文本数据
            else
            {
                string strText = ClipboardHandler.GetTextFromClipboard();
                if (strText != null)
                {
                    this.BeginUpdate();
                    this.BeginContentChangeLog();
                    myContent.ReplaceSelection(strText);
                    //myContentChangeLog.strUndoName = "粘贴";
                    this.EndContentChangeLog();
                    this.EndUpdate();
                }
            }
        }

        //打印旧的实现方式，现在请改用_Print,有参考价值，不要删除源码
        public bool _PrintOld()
        {
            using (XDesignerPrinting.XPrintDocument doc = new XDesignerPrinting.XPrintDocument())
            {
                doc.Document = this;

                doc.EnableJumpPrint = this.EnableJumpPrint;
                doc.JumpPrintPosition = this.JumpPrintPosition;

                bool bUnderline = this.Info.FieldUnderLine;

                this.Pages.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                using (System.Windows.Forms.PrintDialog dlg = new System.Windows.Forms.PrintDialog())
                {

                    dlg.PrinterSettings = this.Pages.PrinterSettings;


                    dlg.PrinterSettings.MinimumPage = 1;
                    dlg.PrinterSettings.MaximumPage = this.Pages.Count;
                    dlg.PrinterSettings.FromPage = 1;
                    dlg.PrinterSettings.ToPage = this.Pages.Count;
                    dlg.PrinterSettings.Duplex = Duplex.Default;
                    bool b = dlg.PrinterSettings.CanDuplex;

                    dlg.AllowSomePages = true;
                    dlg.AllowPrintToFile = true;
                    dlg.AllowCurrentPage = true;
                    dlg.AllowSelection = true;
                    dlg.ShowNetwork = true;
                    #region bwy:
                    dlg.UseEXDialog = true;

                    #endregion bwy:

                    //如果续打，不显示其它按钮
                    if (this.EnableJumpPrint || this.Content.SelectLength == 0)
                    {
                        dlg.AllowSelection = false;
                    }


                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        try
                        {
                            this.Info.FieldUnderLine = false;
                            //如果是打印所有页
                            if (dlg.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages)
                            {
                                this.Info.Printing = true;
                                doc.Print();
                                this.Info.Printing = false;

                            }
                            //打印页范围
                            else if (dlg.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                            {
                                if (dlg.PrinterSettings.FromPage >= 1 && dlg.PrinterSettings.ToPage <= this.Pages.Count)
                                {
                                    this.Info.Printing = true;
                                    for (int i = dlg.PrinterSettings.FromPage; i <= dlg.PrinterSettings.ToPage; i++)
                                    {
                                        doc.PrintSpecialPage(i - 1);
                                    }

                                    this.Info.Printing = false;
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("页码范围不正确！");
                                }
                            }
                            //打印当前页
                            else if (dlg.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.CurrentPage)
                            {
                                //Debug.WriteLine("打印当前页");
                                this.Info.Printing = true;
                                doc.PrintSpecialPage(this.PageIndex);
                                this.Info.Printing = false;
                            }
                            //打印选择的内容
                            else if (dlg.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.Selection)
                            {
                                //Debug.WriteLine("打印选择的内容");
                                //设置打印页面范围
                                //要计算选择范围内的元素所在的页

                                if (this.Content.SelectLength == 0)
                                {
                                    MessageBox.Show("没有选中任何内容。");
                                    return false;
                                }
                                int selstart = this.Content.SelectStart;
                                int selend = 0;
                                int sellength = this.Content.SelectLength;
                                if (sellength < 0)
                                {
                                    selend = selstart;
                                    selstart = selstart + sellength;
                                }
                                else
                                {
                                    selend = selstart + sellength - 1;
                                }


                                int pagestart = -1;
                                int pageend = -1;


                                //Rectangle rectcharstart = (this.Elements[selstart] as ZYTextElement).Bounds;
                                //Rectangle rectcharend = (this.Elements[selend] as ZYTextElement).Bounds; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                                Rectangle rectcharstart = (this.HBFElements[selstart] as ZYTextElement).Bounds;
                                Rectangle rectcharend = (this.HBFElements[selend] as ZYTextElement).Bounds; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

                                Point sp = this.OwnerControl.ViewPointToClient(rectcharstart.Location);
                                Point ep = this.OwnerControl.ViewPointToClient(rectcharend.Location);
                                int pagecount = this.Pages.Count;
                                foreach (PrintPage p in this.Pages)
                                {
                                    //Debug.WriteLine("PrintPage Bounds " + p.Bounds);

                                    //Rectangle rect1 = p.Bounds;
                                    Rectangle rectp = p.ClientBounds;
                                    int left = p.Left;
                                    int top = p.Top;

                                    if (p.Bounds.Contains(rectcharstart))
                                    {
                                        pagestart = p.Index;
                                    }

                                    if (p.Bounds.Contains(rectcharend))
                                    {
                                        pageend = p.Index;
                                    }
                                }

                                this.Info.Printing = true;
                                this.EnableSelectionPrint = true;
                                for (int i = pagestart; i <= pageend; i++)
                                {
                                    doc.PrintSpecialPage(i);
                                }
                                this.EnableSelectionPrint = false;
                                this.Info.Printing = false;

                            }
                        }

                        catch (Exception ext)
                        {
                            //throw ext;
                        }
                        finally
                        {
                            this.Info.FieldUnderLine = bUnderline;
                            this.Info.Printing = false;
                        }
                    }
                }
            }

            ////恢复全部内容
            //if (this.EnableSelectionPrint)
            //{
            //    if (!innerSelectionPrintEnd()) return true;
            //}

            return true;
        }

        CustomPrintDialog.CustomPrintDialog PrintDlgProxy = null;
        //打印
        public bool _Print()
        {
            using (XDesignerPrinting.XPrintDocument doc = new XDesignerPrinting.XPrintDocument())
            {
                doc.Document = this;
                doc.EnableJumpPrint = this.EnableJumpPrint;
                doc.JumpPrintPosition = this.JumpPrintPosition;
                bool bUnderline = this.Info.FieldUnderLine;
                this.Pages.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

                doc.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                doc.PrinterSettings = this.Pages.PrinterSettings;
                doc.PrinterSettings.MinimumPage = 1;
                doc.PrinterSettings.MaximumPage = this.Pages.Count;
                doc.PrinterSettings.FromPage = 1;
                doc.PrinterSettings.ToPage = this.Pages.Count;


                using (CustomPrintDialog.CustomPrintDialog dlg = new CustomPrintDialog.CustomPrintDialog())
                {
                    PrintDlgProxy = dlg;

                    dlg.ShrinkOutputToFitOnOnePage = true;
                    dlg.AllowSelection = true;
                    dlg.AllowSomePages = true;

                    dlg.pdlg.nFromPage = 1;
                    dlg.pdlg.nToPage = (ushort)this.Pages.Count;
                    dlg.pdlg.nMinPage = 1;
                    dlg.pdlg.nMaxPage = (ushort)this.Pages.Count;

                    dlg.m_Panel.checkBoxHeader.CheckedChanged += new EventHandler(CheckedChanged);
                    dlg.m_Panel.checkBoxFooter.CheckedChanged += new EventHandler(CheckedChanged);

                    //doc.PrinterSettings = this.Pages.PrinterSettings;
                    //doc.PrinterSettings.MinimumPage = 1;
                    //doc.PrinterSettings.MaximumPage = this.Pages.Count;
                    //doc.PrinterSettings.FromPage = 1;
                    //doc.PrinterSettings.ToPage = this.Pages.Count;
                    //dlg.Document = doc;
                    //dlg.AllowCurrentPage = true;

                    //如果续打，不显示其它按钮
                    if (this.EnableJumpPrint || this.Content.SelectLength == 0)
                    {
                        dlg.AllowSelection = false;
                    }

                    const Int32 PD_ALLPAGES = 0x00000000;
                    const Int32 PD_SELECTION = 0x00000001;
                    const Int32 PD_PAGENUMS = 0x00000002;
                    const Int32 PD_NOSELECTION = 0x00000004;
                    const Int32 PD_NOPAGENUMS = 0x00000008;



                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //打印份数
                        for (int i = 1; i <= dlg.pdlg.nCopies; i++)
                        {
                            Debug.WriteLine("打印份数 " + dlg.pdlg.nCopies);
                            try
                            {
                                this.Info.FieldUnderLine = false;

                                //打印页范围
                                //if (doc.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                                if ((dlg.pdlg.Flags & PD_PAGENUMS) == PD_PAGENUMS)
                                {
                                    Debug.WriteLine("页码范围");
                                    if (dlg.pdlg.nFromPage >= 1 && dlg.pdlg.nToPage <= this.Pages.Count)
                                    {
                                        this.Info.Printing = true;
                                        PrintEx(dlg.pdlg.nFromPage - 1, dlg.pdlg.nToPage - 1, dlg.m_Panel.comboBox1.SelectedIndex, doc);
                                        this.Info.Printing = false;
                                    }
                                    else
                                    {
                                        System.Windows.Forms.MessageBox.Show("页码范围不正确！");
                                    }
                                }
                                ////打印当前页
                                //else if (doc.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.CurrentPage)
                                //{
                                //    Debug.WriteLine("打印当前页");
                                //    this.Info.Printing = true;
                                //    doc.PrintSpecialPage(this.PageIndex);
                                //    this.Info.Printing = false;
                                //}
                                //打印选择的内容
                                //else if (doc.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.Selection)
                                else if ((dlg.pdlg.Flags & PD_SELECTION) == PD_SELECTION)
                                {
                                    Debug.WriteLine("打印选择的内容");
                                    //设置打印页面范围
                                    //要计算选择范围内的元素所在的页

                                    if (this.Content.SelectLength == 0)
                                    {
                                        MessageBox.Show("没有选中任何内容。");
                                        return false;
                                    }
                                    int selstart = this.Content.SelectStart;
                                    int selend = 0;
                                    int sellength = this.Content.SelectLength;
                                    if (sellength < 0)
                                    {
                                        selend = selstart;
                                        selstart = selstart + sellength;
                                    }
                                    else
                                    {
                                        selend = selstart + sellength - 1;
                                    }


                                    int pagestart = -1;
                                    int pageend = -1;


                                    //Rectangle rectcharstart = (this.Elements[selstart] as ZYTextElement).Bounds;
                                    //Rectangle rectcharend = (this.Elements[selend] as ZYTextElement).Bounds; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                                    Rectangle rectcharstart = (this.HBFElements[selstart] as ZYTextElement).Bounds;
                                    Rectangle rectcharend = (this.HBFElements[selend] as ZYTextElement).Bounds; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

                                    Point sp = this.OwnerControl.ViewPointToClient(rectcharstart.Location);
                                    Point ep = this.OwnerControl.ViewPointToClient(rectcharend.Location);
                                    int pagecount = this.Pages.Count;
                                    foreach (PrintPage p in this.Pages)
                                    {
                                        Debug.WriteLine("PrintPage Bounds " + p.Bounds);

                                        //Rectangle rect1 = p.Bounds;
                                        Rectangle rectp = p.ClientBounds;
                                        int left = p.Left;
                                        int top = p.Top;

                                        if (p.Bounds.Contains(rectcharstart))
                                        {
                                            pagestart = p.Index;
                                        }

                                        if (p.Bounds.Contains(rectcharend))
                                        {
                                            pageend = p.Index;
                                        }
                                    }

                                    this.Info.Printing = true;
                                    this.EnableSelectionPrint = true;

                                    PrintEx(pagestart, pageend, dlg.m_Panel.comboBox1.SelectedIndex, doc);

                                    this.EnableSelectionPrint = false;
                                    this.Info.Printing = false;

                                }
                                //如果是打印所有页
                                else //(doc.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages)
                                {
                                    this.Info.Printing = true;
                                    PrintEx(0, this.Pages.Count - 1, dlg.m_Panel.comboBox1.SelectedIndex, doc);
                                    this.Info.Printing = false;
                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                this.Info.FieldUnderLine = bUnderline;
                                this.Info.Printing = false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        #region Add By wwj 2011-08-25 for 打印
        /// <summary>
        /// Add By wwj 2011-08-25 todo 全部打印 
        /// </summary>
        /// <param name="printerName">打印机</param>
        /// <returns>打印是否成功</returns>
        public bool _PrintAll(string printerName)
        {
            using (XDesignerPrinting.XPrintDocument doc = new XDesignerPrinting.XPrintDocument())
            {
                #region 初始化XPrintDocument
                doc.Document = this;
                doc.EnableJumpPrint = false;
                doc.JumpPrintPosition = 0;
                this.Pages.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                doc.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                doc.PrinterSettings = this.Pages.PrinterSettings;
                doc.PrinterSettings.PrinterName = printerName;
                doc.PrinterSettings.MinimumPage = 1;
                doc.PrinterSettings.MaximumPage = this.Pages.Count;
                doc.PrinterSettings.FromPage = 1;
                doc.PrinterSettings.ToPage = this.Pages.Count;
                #endregion

                try
                {
                    this.Info.FieldUnderLine = false;

                    //打印页范围
                    this.Info.Printing = true;
                    doc.Print();
                   // PrintEx(0, this.Pages.Count - 1, 0, doc);
                    this.Info.Printing = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Info.Printing = false;
                }
            }
            return true;
        }

        /// <summary>
        /// 是否正在生成图片，导出图片前为true，导出完成后为false
        /// </summary>
        public bool IsPrintImage = false;

        /// <summary>
        /// 生成打印的图片  edit by tj 2012-11-06
        /// </summary>
        public List<Bitmap> GeneratePrintImage()
        {
            IsPrintImage = true;
            List<Bitmap> imagePages = new List<Bitmap>();
            imagePages.Clear();
            DocumentPageDrawer drawer = new DocumentPageDrawer(this, this.Pages);
            drawer.DrawFooter = true;
            drawer.DrawHead = true;
            foreach (PrintPage page in this.Pages)
            {
                imagePages.Add(drawer.GetPageBmp(page, true));
            }
            IsPrintImage = false;
            return imagePages;
        }
        /// <summary>
        /// 生成打印的图片  edit by ywk 二次修改
        /// </summary>
        public List<Metafile> GeneratePrintImage2()
        {
            IsPrintImage = true;
            List<Metafile> imagePages = new List<Metafile>();
            imagePages.Clear();
            DocumentPageDrawer drawer = new DocumentPageDrawer(this, this.Pages);
            drawer.DrawFooter = true;
            drawer.DrawHead = true;
            foreach (PrintPage page in this.Pages)
            {
                imagePages.Add(drawer.GetPageBmp2(page, true));
            }
            IsPrintImage = false;
            return imagePages;
        }

        /// <summary>
        /// Add By wwj 2011-08-25 todo 打印指定页
        /// </summary>
        /// <param name="printerName">打印机</param>
        /// <param name="pageBegin"></param>
        /// <param name="pageEnd"></param>
        /// <returns></returns>
        public bool _PrintPageFromTo(string printerName, int pageBegin, int pageEnd)
        {
            using (XDesignerPrinting.XPrintDocument doc = new XDesignerPrinting.XPrintDocument())
            {
                #region 初始化XPrintDocument
                doc.Document = this;
                doc.EnableJumpPrint = false;
                doc.JumpPrintPosition = 0;
                this.Pages.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                doc.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                doc.PrinterSettings = this.Pages.PrinterSettings;
                doc.PrinterSettings.PrinterName = printerName;
                doc.PrinterSettings.MinimumPage = 1;
                doc.PrinterSettings.MaximumPage = this.Pages.Count;
                doc.PrinterSettings.FromPage = 1;
                doc.PrinterSettings.ToPage = this.Pages.Count;
                #endregion

                if (pageBegin > this.Pages.Count)
                {
                    pageBegin = this.Pages.Count;
                }
                if (pageEnd > this.Pages.Count)
                {
                    pageEnd = this.Pages.Count;
                }
                if (pageBegin > pageEnd)
                {
                    int temp = pageBegin;
                    pageBegin = pageEnd;
                    pageEnd = temp;
                }

                try
                {
                    this.Info.FieldUnderLine = false;

                    //打印页范围
                    this.Info.Printing = true;
                    PrintEx(pageBegin - 1, pageEnd - 1, 0, doc);
                    this.Info.Printing = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Info.Printing = false;
                }
            }
            return true;
        }

        /// <summary>
        /// Add By wwj 2011-08-25 todo 打印选中的文字
        /// </summary>
        /// <param name="printerName">打印机</param>
        /// <returns></returns>
        public bool _PrintSelection(string printerName)
        {
            using (XDesignerPrinting.XPrintDocument doc = new XDesignerPrinting.XPrintDocument())
            {
                #region 初始化XPrintDocument
                doc.Document = this;
                doc.EnableJumpPrint = false;
                doc.JumpPrintPosition = 0;
                this.Pages.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                doc.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                doc.PrinterSettings = this.Pages.PrinterSettings;
                doc.PrinterSettings.PrinterName = printerName;
                doc.PrinterSettings.MinimumPage = 1;
                doc.PrinterSettings.MaximumPage = this.Pages.Count;
                doc.PrinterSettings.FromPage = 1;
                doc.PrinterSettings.ToPage = this.Pages.Count;
                #endregion

                try
                {
                    this.Info.FieldUnderLine = false;
                    //设置打印页面范围
                    //要计算选择范围内的元素所在的页

                    if (this.Content.SelectLength == 0)
                    {
                        //MessageBox.Show("没有选中任何内容。");
                        return false;
                    }

                    int selstart = this.Content.SelectStart;
                    int selend = 0;
                    int sellength = this.Content.SelectLength;
                    if (sellength < 0)
                    {
                        //selend = selstart;
                        selend = selstart - 1; //add by myc 2014-08-25 添加原因：处理宜昌中心医院选中元素打印跨页交汇处的多余一张空白打印页问题
                        selstart = selstart + sellength;
                    }
                    else
                    {
                        selend = selstart + sellength - 1;
                    }

                    int pagestart = -1;
                    int pageend = -1;

                    //Rectangle rectcharstart = (this.Elements[selstart] as ZYTextElement).Bounds;
                    //Rectangle rectcharend = (this.Elements[selend] as ZYTextElement).Bounds; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    Rectangle rectcharstart = (this.HBFElements[selstart] as ZYTextElement).Bounds;
                    Rectangle rectcharend = (this.HBFElements[selend] as ZYTextElement).Bounds; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

                    Point sp = this.OwnerControl.ViewPointToClient(rectcharstart.Location);
                    Point ep = this.OwnerControl.ViewPointToClient(rectcharend.Location);
                    int pagecount = this.Pages.Count;
                    foreach (PrintPage p in this.Pages)
                    {
                        Debug.WriteLine("PrintPage Bounds " + p.Bounds);

                        Rectangle rectp = p.ClientBounds;
                        int left = p.Left;
                        int top = p.Top;

                        if (p.Bounds.Contains(rectcharstart))
                        {
                            pagestart = p.Index;
                        }

                        if (p.Bounds.Contains(rectcharend))
                        {
                            pageend = p.Index;
                        }
                    }

                    this.Info.Printing = true;
                    this.EnableSelectionPrint = true;

                    //选择区域打印的时候不打印页眉和页脚
                    //this.PrintHeader = false;
                    //this.PrintFooter = false;

                    PrintEx(pagestart, pageend, 0, doc);

                    //this.PrintHeader = true;
                    //this.PrintFooter = true;

                    this.EnableSelectionPrint = false;
                    this.Info.Printing = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Info.Printing = false;
                }
            }
            return true;
        }

        /// <summary>
        /// Add By wwj 2011-08-25 todo 续打
        /// </summary>
        /// <param name="printerName">打印机</param>
        /// <returns></returns>
        public bool _PrintJump(string printerName)
        {
            XPrintDocument doc = new XPrintDocument();
            doc.Document = this;
            doc.EnableJumpPrint = this.EnableJumpPrint;
            doc.JumpPrintPosition = this.JumpPrintPosition;
            this.Info.Printing = true;
            doc.Print();
            this.Info.Printing = false;
            return true;
        }

        /// <summary>
        /// Add By wwj 2012-04-17 打印选中区域
        /// </summary>
        /// <param name="printerName">打印机</param>
        /// <returns></returns>
        public bool _PrintSelectArea(string printerName)
        {
            XPrintDocument doc = new XPrintDocument();
            doc.Document = this;

            doc.EnableSelectAreaPrint = this.EnableSelectAreaPrint;
            doc.SelectAreaPrintLeftTopPoint = this.SelectAreaPrintLeftTopPoint;
            doc.SelectAreaPrintRightBottomPoint = this.SelectAreaPrintRightBottomPoint;

            this.Info.Printing = true;
            doc.Print();
            this.Info.Printing = false;

            return true;
        }
        #endregion

        public bool PrintHeader = true;
        public bool PrintFooter = true;
        void CheckedChanged(object sender, EventArgs e)
        {
            if (PrintDlgProxy != null)
            {
                this.PrintHeader = PrintDlgProxy.m_Panel.checkBoxHeader.Checked;
                this.PrintFooter = PrintDlgProxy.m_Panel.checkBoxFooter.Checked;
            }
        }

        /// <summary>
        /// 打印一定页范围内的文档，索引从0开始
        /// </summary>
        /// <param name="start">开始页</param>
        /// <param name="end">结束页</param>
        /// <param name="flag">0全部，1奇数页，2偶页</param>
        void PrintEx(int start, int end, int flag, XPrintDocument doc)
        {
            for (int i = start; i <= end; i++)
            {
                if (flag == 0)
                {
                    doc.PrintSpecialPage(i);
                }
                else if (i % 2 == 0 && flag == 1) //奇数页，因为索引从0开始
                {
                    doc.PrintSpecialPage(i);
                }

                else if (i % 2 == 1 && flag == 2)//偶数页，因为索引从0开始
                {
                    doc.PrintSpecialPage(i);
                }
                else if (i % 2 == 1 && flag == 3)//偶数页，双面打印，左右边距互换
                {
                    XPageSettings setOld = this.Pages.PageSettings;
                    XPageSettings set = this.Pages.PageSettings;

                    int tmp = set.Margins.Left;
                    set.Margins.Left = set.Margins.Right;
                    set.Margins.Right = tmp;

                    this.Pages.PageSettings = set;

                    doc.PrintSpecialPage(i);
                    this.Pages.PageSettings = setOld;
                }

            }


        }


        //打印预览
        System.Windows.Forms.DataObject myDataObject = new System.Windows.Forms.DataObject();
        public bool _PrintPreview()
        {

            PrintPreviewDialog printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            XPrintDocument doc = new XPrintDocument();
            doc.Document = this;

            //if (this.EnableSelectionPrint)
            //{
            //    if (!innerSelectionPrintStart()) return false;
            //}
            //else
            //{
            //    this.myContent.SetSelection(0, 0);
            //}

            doc.EnableJumpPrint = this.EnableJumpPrint;
            doc.JumpPrintPosition = this.JumpPrintPosition;

            printPreviewDialog1.Document = doc;
            this.Info.Printing = true;
            printPreviewDialog1.ShowDialog();
            this.Info.Printing = false;


            return true;
        }

        //页面设置 
        public bool _PageSetting()
        {
            using (XDesignerPrinting.dlgPageSetup dlg = new XDesignerPrinting.dlgPageSetup())
            {
                dlg.PageSettings = this.Pages.PageSettings;

                //add by myc 2014-06-23 添加原因：暂时限制修改纸张大小和横纵向打印——>后期调整
                //dlg.cboPage.Enabled = false; //设置纸张大小为默认的A4纸张
                //dlg.PageSettings.Landscape = false; //设置纵向打印

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //计算出新纸张大小和旧纸张大小的换算比率
                    double paperRate = (double)dlg.PageSettings.PaperSize.Width / (double)this.Pages.PageSettings.PaperSize.Width;

                    #region 2014-09-01 变更页眉设置参数时，需要重置空白页眉的IsConfigHeaderHeightInYiChan属性值
                    foreach (ZYDocumentHeader objHeader in this.RootDocumentElementsInHeader)
                    {
                        foreach (ZYAttribute zyAttribute in objHeader.Attributes)
                        {
                            if (zyAttribute.Name == "IsConfigHeaderHeightInYiChan")
                            {
                                zyAttribute.SetValue("0");
                            }
                        }
                    }
                    #endregion

                    this.Pages.PageSettings = dlg.PageSettings;

                    CheckHeaderXMLInPageSetting();

                    this.RefreshLine();
                    this.RefreshPages();
                    this.OwnerControl.UpdatePages();
                    this.Refresh();
                    return true;
                }
            }
            return false;
        }

        //九江初始化设置
        public bool _PageSettingByJJ()
        {
            using (XDesignerPrinting.dlgPageSetup dlg = new XDesignerPrinting.dlgPageSetup())
            {
                dlg.PageSettings = this.Pages.PageSettings;
                //计算出新纸张大小和旧纸张大小的换算比率
                double paperRate = (double)dlg.PageSettings.PaperSize.Width / (double)this.Pages.PageSettings.PaperSize.Width;

                #region 2014-09-01 变更页眉设置参数时，需要重置空白页眉的IsConfigHeaderHeightInYiChan属性值
                foreach (ZYDocumentHeader objHeader in this.RootDocumentElementsInHeader)
                {
                    foreach (ZYAttribute zyAttribute in objHeader.Attributes)
                    {
                        if (zyAttribute.Name == "IsConfigHeaderHeightInYiChan")
                        {
                            zyAttribute.SetValue("0");
                        }
                    }
                }
                #endregion

                this.Pages.PageSettings = dlg.PageSettings;

                CheckHeaderXMLInPageSetting();

                this.RefreshLine();
                this.RefreshPages();
                this.OwnerControl.UpdatePages();
                this.Refresh();
                return true;

            }
            return false;
        }

        #region 设置文本属性

        /// <summary>
        /// 设置选中文本的字体名称
        /// </summary>
        /// <param name="NewFontName">要设置的字体名称</param>
        public void SetSelectioinFontName(string NewFontName)
        {
            SetSelectionAttribute(0, NewFontName);
        }
        /// <summary>
        /// 设置选中文本的字体大小
        /// </summary>
        /// <param name="NewSize">字体大小</param>
        public void SetSelectionFontSize(float NewSize)
        {
            SetSelectionAttribute(1, NewSize.ToString());
        }
        /// <summary>
        /// 设置选中文本的字体粗体
        /// </summary>
        /// <param name="NewBold">是否为粗体</param>
        public void SetSelectionFontBold(bool NewBold)
        {
            SetSelectionAttribute(2, (NewBold ? "1" : "0"));
        }
        /// <summary>
        /// 设置选中文本的字体斜体属性
        /// </summary>
        /// <param name="NewItalic">是否为斜体</param>
        public void SetSelectionFontItalic(bool NewItalic)
        {
            SetSelectionAttribute(3, (NewItalic ? "1" : "0"));
        }
        /// <summary>
        /// 设置选中文本的下划线属性
        /// </summary>
        /// <param name="UnderLine">是否有下划线</param>
        public void SetSelectionUnderLine(bool UnderLine)
        {
            SetSelectionAttribute(4, (UnderLine ? "1" : "0"));
        }
        /// <summary>
        /// 设置选中文本的文本颜色
        /// </summary>
        /// <param name="NewColor">文本颜色</param>
        public void SetSelectionColor(System.Drawing.Color NewColor)
        {
            SetSelectionAttribute(5, NewColor.ToArgb().ToString());
        }

        /// <summary>
        /// 设置选中文本的文本颜色
        /// </summary>
        /// <param name="NewColor">文本颜色</param>
        public void SetSelectionBackGroundColor(System.Drawing.Color NewColor)
        {
            SetSelectionAttribute(9, NewColor.ToArgb().ToString());
        }

        //		/// <summary>
        //		/// 设置选中文本的数据名称属性
        //		/// </summary>
        //		/// <param name="NewName">文本名称</param>
        //		public void SetSelectionName( string NewName)
        //		{
        //			SetSelectionAttribute(6, NewName);
        //		}

        /// <summary>
        /// 设置选中文本的下标属性,暂未实现
        /// </summary>
        /// <param name="NewSub">是否是下标</param>
        public void SetSelectionSub(bool NewSub)
        {
            SetSelectionAttribute(7, (NewSub ? "1" : "0"));
        }
        /// <summary>
        /// 设置选中文本的上标属性,暂未实现
        /// </summary>
        /// <param name="NewSup">是否是上标</param>
        public void SetSelectionSup(bool NewSup)
        {
            SetSelectionAttribute(8, (NewSup ? "1" : "0"));
        }
        /// <summary>
        /// 不能同时为上标或下标，所以在设置上标或下标时，应该先清空
        /// </summary>
        void ResetSupsub()
        {
            SetSelectionAttribute(7, "0");
            SetSelectionAttribute(8, "0");
        }

        #region add by myc 2014-07-17 注释原因：新版字体属性控制需要
        ///// <summary>
        ///// 设置选中的文本元素的属性
        ///// </summary>
        ///// <param name="index">属性的内部序号</param>
        ///// <param name="strValue">属性值</param>
        //private void SetSelectionAttribute(int index, string strValue)
        //{
        //    bool bolChange = false;
        //    if (this.Locked) return;
        //    System.Collections.ArrayList myList = myContent.GetSelectElements();

        //    if (myList.Count == 0) return; //add by myc 2014-06-05 添加原因：没有选中任何元素时不允许设置字体大小

        //    ZYTextChar myChar = null;
        //    ZYTextContainer myParent = null;
        //    //ZYTextFlag myflag = null;
        //    this.BeginContentChangeLog();

        //    //如果是一个空行，且是设置字体大小，那么，设置回车符的高度为字体高
        //    if (myList.Count == 0 && index == 1 && this.Content.CurrentElement is ZYTextEOF && this.Content.CurrentElement == this.Content.CurrentElement.Parent.FirstElement && this.Content.CurrentElement == this.Content.CurrentElement.Parent.LastElement)
        //    {
        //        (this.Content.CurrentElement as ZYTextEOF).FontSize = float.Parse(strValue);
        //        this.Content.CurrentElement.RefreshSize();
        //        bolChange = true;
        //    }

        //    for (int iCount = 0; iCount < myList.Count; iCount++)
        //    {

        //        myChar = myList[iCount] as ZYTextChar;
        //        if (myChar != null)
        //        {

        //            if (myParent != null && myParent != myChar.Parent)
        //                myParent.RefreshLine();
        //            myParent = myChar.Parent;
        //            switch (index)
        //            {
        //                case 0: // 字体名称
        //                    myChar.FontName = strValue;
        //                    break;
        //                case 1: // 字体大小
        //                    myChar.FontSize = float.Parse(strValue);
        //                    break;
        //                case 2: // 粗体
        //                    myChar.FontBold = strValue.Equals("1");
        //                    break;
        //                case 3: // 斜体
        //                    myChar.FontItalic = strValue.Equals("1");
        //                    break;
        //                case 4: // 下划线
        //                    myChar.FontUnderLine = strValue.Equals("1");
        //                    break;
        //                case 5: // 文本颜色
        //                    myChar.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
        //                    break;
        //                case 6: // 元素的数据名称
        //                    //myChar.Name = strValue ;
        //                    break;
        //                case 7: // 下标
        //                    myChar.Sub = strValue.Equals("1");
        //                    break;
        //                case 8: // 上标
        //                    myChar.Sup = strValue.Equals("1");
        //                    break;
        //                case 9: // 文本背景颜色
        //                    myChar.BackgroundColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
        //                    break;
        //                case 10: // 圈字
        //                    myChar.CircleFont = strValue.Equals("1");
        //                    break;
        //                default:
        //                    return;
        //            }
        //            myChar.RefreshSize();
        //            bolChange = true;

        //            #region bwy :
        //            //如果是ZYBlock中的字符，同时设置ZYBlock的属性
        //            if (myChar.Parent is ZYTextBlock)
        //            {
        //                ZYTextBlock parent = (ZYTextBlock)myChar.Parent;
        //                myChar.Attributes.CopyTo(parent.Attributes);
        //                parent.UpdateAttrubute();
        //            }

        //            //if (myChar is ZYElement)
        //            //{
        //            //    ((ZYElement)myChar).Attributes.SetValue(ZYTextConst.c_FontName,strValue);

        //            //}
        //            #endregion bwy :
        //        }
        //        //如果不是ZYTextChar，可能是ZYTextBlock,ZYElement

        //    }
        //    myContentChangeLog.strUndoName = "设置属性" + strValue;

        //    if (bolChange)
        //    {
        //        #region add by myc 2014-05-20 新版表格绘制之单元格内部元素改变字体大小时的自适应高度调整
        //        if (myList.Count > 0)
        //        {
        //            //第一次检查祖父层次容器
        //            TPTextCell currCell = (myList[0] as ZYTextElement).Parent.Parent as TPTextCell;
        //            if (currCell != null)
        //            {
        //                currCell.AdjustHeight();
        //            }

        //            //第二次检查曾祖父层次容器
        //            TPTextCell newCell = (myList[0] as ZYTextElement).Parent.Parent.Parent as TPTextCell;
        //            if (newCell != null)
        //            {
        //                newCell.AdjustHeight();
        //            }
        //        }
        //        #endregion

        //        this.RefreshLine();
        //        //this.UpdateView();//原来有，现在注释了,因为设置字体本光标位置跑到最左上角了
        //        this.Refresh();
        //        //myContent.Modified  = true;
        //    }


        //    //this.ContentChanged();
        //    this.EndContentChangeLog();


        //    this.UpdateTextCaret();

        //} 
        #endregion

        /// <summary>
        /// 设置圈字 Add By wwj 2012-05-31
        /// </summary>
        public void SetCircleFont(bool NewCircle)
        {
            SetSelectionAttribute(10, (NewCircle ? "1" : "0"));
        }
        #endregion

        /// <summary>
        /// 设置当前插入点所在的段落的对齐方式
        /// </summary>
        /// <param name="intAlign">对齐样式</param>
        /// <returns>本操作是否导致文档内容的修改</returns>
        public bool SetAlign(ParagraphAlignConst intAlign)
        {
            //if (this.Locked) return false;
            bool bolChange = false;
            System.Collections.ArrayList myList = myContent.GetSelectParagraph();
            this.BeginContentChangeLog();
            #region bwy :
            if (myList.Count == 0)
            {
                ZYTextParagraph p = this.Content.CurrentElement.Parent as ZYTextParagraph;
                if (p == null)
                {
                    p = this.Content.CurrentElement.Parent.Parent as ZYTextParagraph;
                }
                myList.Add(p);
            }
            #endregion bwy :
            foreach (ZYTextParagraph myP in myList)
            {
                if (myP.Align != intAlign)
                {
                    myP.Align = intAlign;
                    bolChange = true;
                }
            }

            //myContentChangeLog.strUndoName = "设置对齐方式";
            this.EndContentChangeLog();
            if (bolChange)
            {
                this.RefreshLine();
                this.UpdateView();
                this.Refresh();
                myContent.Modified = true;
            }
            return bolChange;
        }

        /// <summary>
        /// 2019.07.09-hdf
        /// 设置当前插入点所在的段落的行高
        /// </summary>
        /// <param name="lineHeightMultiple"></param>
        /// <returns></returns>
        public bool SetLineHeight(double lineHeightMultiple)
        {
            bool bolChange = false;
            System.Collections.ArrayList myList = myContent.GetSelectParagraph();
            this.BeginContentChangeLog();
            if (myList.Count == 0)
            {
                ZYTextParagraph p = this.Content.CurrentElement.Parent as ZYTextParagraph;
                if (p == null)
                {
                    p = this.Content.CurrentElement.Parent.Parent as ZYTextParagraph;
                }
                myList.Add(p);
            }
            foreach (ZYTextParagraph myP in myList)
            {
                //2019.07.10-hdf
                //由于表格底层绘制，设置行高后表格边框绘制混乱，暂时不实现表格内行高功能
                if (myP.Parent is TPTextCell)
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("表格行高功能暂未实现");
                    return bolChange;
                }
                if (myP.LineHeightMultiple != lineHeightMultiple)
                {
                    myP.LineHeightMultiple = lineHeightMultiple;
                    bolChange = true;
                }
            }
            this.EndContentChangeLog();
            if (bolChange)
            {
                this.RefreshLine();
                this.UpdateView();
                this.Refresh();
                myContent.Modified = true;
            }
            return bolChange;
        }



        /// <summary>
        /// 根据一段XML字符串在文档的插入点插入新的元素
        /// </summary>
        /// <param name="strXML">XML字符串</param>
        /// <returns>操作是否成功</returns>
        public bool InsertByXML(string strXML)
        {
            //if (this.Locked) return false;
            System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
            myDoc.LoadXml(strXML);
            ZYTextElement e = this.CreateElementByXML(myDoc.DocumentElement);
            if (e != null)
                myContent.InsertElement(e);
            return true;
        }

        /// <summary>
        /// 创建一个字符对象
        /// </summary>
        /// <param name="vChar">字符</param>
        /// <returns>新建的字符对象</returns>
        public ZYTextChar CreateChar(char vChar)
        {
            ZYTextChar NewChar = ZYTextChar.Create(vChar);
            NewChar.OwnerDocument = this;
            if (!char.IsWhiteSpace(vChar))
                NewChar.CreatorIndex = mySaveLogs.CurrentIndex;
            NewChar.Deleteted = false;
            NewChar.Font = myView.DefaultFont;
            NewChar.Visible = true;
            return NewChar;
        }

        /// <summary>
        /// 根据一个字符串创建一个字符对象集合
        /// </summary>
        /// <param name="strText">字符串</param>
        /// <param name="vParent">新增的字符元素的父元素</param>
        /// <returns></returns>
        public System.Collections.ArrayList CreateChars(string strText, ZYTextContainer vParent)
        {
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            ZYTextChar NewChar = null;
            foreach (char c in strText)
            {
                if (c != '\r' || c != '\n')
                {
                    NewChar = this.CreateChar(c);
                    if (NewChar != null)
                    {
                        NewChar.Parent = vParent;
                        myList.Add(NewChar);
                    }
                    //myList.Add( this.CreateChar( c ));
                }
            }
            return myList;
        }

        /// <summary>
        /// 清除内容,删除所有元素,重置文档的设置,可用于新增文档做准备
        /// </summary>
        public void ClearContent()
        {
            //myMarks.Clear();
            //myUndoList.Clear();
            //myRedoList.Clear();
            UndoStack.ClearAll();

            //myContentChangeLog = null;
            myInfo.FileName = null;
            //foreach (ZYTextElement myElement in myElements) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            foreach (ZYTextElement myElement in HBFElements) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                if (myElement is System.IDisposable)
                {
                    (myElement as System.IDisposable).Dispose();
                }
            }


            RootDocumentElementsInHeader.Clear(); //add by myc 2014-07-01 添加原因：新版页眉二期改版需要
            RootDocumentElementsInFooter.Clear(); //add by myc 2014-07-07 添加原因：新版页脚需要

            RootDocumentElement = new ZYTextDiv();
            RootDocumentElement.OwnerDocument = this;
            //mySaveLogs.Clear();
            //myDataSource.ClearQueryNames();
            //myDataSource.ClearQueryVariables();
            myInfo.Title = "";
            myInfo.ID = "";

            #region add by myc 2014-07-08 注释原因：清除文档数据之后不应该去重复刷新视图，这会导致每加载一次病历文档（或保存）出现多次闪烁——>但考虑新建模板需要，暂时放开
            this.RefreshElements();
            this.RefreshSize();
            this.RefreshLine();
            myContent.SetSelection(0, 0);
            #region bwy :
            UpdateView();
            #endregion bwy :
            this.Refresh();
            #endregion

        }

        #endregion

        #region 对象从纯文本数据加载文档的函数群 **************************************************
        /// <summary>
        /// 从一个字符串加载文档内容
        /// </summary>
        /// <param name="strText">字符串对象</param>
        /// <returns>操作是否成功</returns>
        public bool FromText(string strText)
        {
            RootDocumentElement = new ZYTextDiv();
            RootDocumentElement.OwnerDocument = this;
            LoadTextElementsToList(strText, RootDocumentElement.ChildElements);
            return true;
        }

        /// <summary>
        /// 根据一段纯文本数据加载元素列表
        /// </summary>
        /// <param name="strText">文本数据</param>
        /// <param name="myList">保存新增的元素的列表</param>
        /// <returns>加载的元素个数，若参数错误则返回-1</returns>
        public int LoadTextElementsToList(string strText, System.Collections.ArrayList myList)
        {
            int iCount = 0;
            if (strText == null || myList == null)
                return -1;

            foreach (char vChar in strText)
            {
                if (vChar == '\n')
                {
                    myList.Add(new ZYTextParagraph());
                    iCount++;
                }
                else if (vChar != '\r')
                {
                    myList.Add(this.CreateChar(vChar));
                    iCount++;
                }
            }
            return iCount;
        }
        #endregion

        #region 对象和XML文档交换数据的函数群 *****************************************************
        /// <summary>
        /// 加载若干元素到列表中
        /// </summary>
        /// <remarks>本函数遍历XML节点,碰到文本节点则对其中每一个字符新建一个字符元素对象,
        /// 对于XML子节点则尝试新增一个元素,然后调用元素的FromXML函数加载XML数据</remarks>
        /// <param name="myElement">根XML节点</param>_
        /// <param name="myList">保存加载的元素的列表</param>
        /// <returns>加载是否成功</returns>
        /// <seealso>ZYTextDocumentLib.ZYTextDocument.CreateElement</seealso>
        public bool LoadElementsToList(System.Xml.XmlElement myElement, System.Collections.ArrayList myList)
        {
            //myList.Clear();
            //myList.Add(myBlank);
            ZYTextElement NewElement = null;
            foreach (System.Xml.XmlNode myXMLNode in myElement.ChildNodes)
            {
                // 加载文本数据
                if (myXMLNode.Name == ZYTextConst.c_XMLText || myXMLNode.Name == ZYTextConst.c_Span)
                {
                    string strText = myXMLNode.InnerText;
                    if (strText != null && strText.Length > 0)
                    {
                        strText = System.Web.HttpUtility.HtmlDecode(strText);
                        strText = strText.Replace("\r", "");
                        strText = strText.Replace("\n", "");
                        if (strText.Length > 0)
                        {
                            ZYTextChar FirstChar = ZYTextChar.Create(' ');// new ZYTextChar();
                            myList.Add(FirstChar);

                            // 加载格式化文本
                            #region 已注释 by myc 2014-03-24 15:19:20 因页眉区域字体属性更改需求，修改为如下代码段
                            //if (myXMLNode is System.Xml.XmlElement)
                            //    FirstChar.FromXML(myXMLNode as System.Xml.XmlElement); 
                            #endregion

                            if (myXMLNode is System.Xml.XmlElement)
                            {
                                #region add by myc 2014-03-24 添加原因：东池医院页眉字体样式需求，此为通用处理，其他医院也可使用
                                FirstChar.FromXML(myXMLNode as System.Xml.XmlElement);
                                System.Xml.XmlElement ele = myXMLNode as System.Xml.XmlElement;
                                if (ele.HasAttribute("fontbold"))
                                {
                                    FirstChar.FontBold = true;
                                }
                                if (ele.HasAttribute("fontitalic"))
                                {
                                    FirstChar.FontItalic = true;
                                }
                                if (ele.HasAttribute("fontunderline"))
                                {
                                    FirstChar.FontUnderLine = true;
                                }

                                if (ele.HasAttribute("forecolor"))
                                {
                                    FirstChar.ForeColor = ColorTranslator.FromHtml(ele.GetAttribute("forecolor"));
                                }
                                else
                                {
                                    FirstChar.ForeColor = Color.Black;
                                }
                                #endregion
                            }
                            else
                            {
                                if (myElement.Name == ZYTextConst.c_Replace || myElement.Name == ZYTextConst.c_FStrElement || myElement.Name == ZYTextConst.c_Macro || myElement.Name == ZYTextConst.c_Diag)
                                {
                                    //2019.8.15-hdf
                                    //当文档为旧版，宏元素、格式化字符串、服用项目内还是文本不是字符元素标签
                                    //则筛选出块元素的字体属性，把这些属性赋给字符对象
                                    List<XmlAttribute> fontList = myElement.Attributes.Cast<XmlAttribute>().Where(attr =>
                                        attr.Name == ZYTextConst.c_FontName ||
                                        attr.Name == ZYTextConst.c_FontSize ||
                                        attr.Name == ZYTextConst.c_FontBold ||
                                        attr.Name == ZYTextConst.c_FontUnderLine ||
                                        attr.Name == ZYTextConst.c_DoubleFontUnderLine ||
                                        attr.Name == ZYTextConst.c_FontItalic ||
                                        attr.Name == ZYTextConst.c_FontWavyLine ||
                                        attr.Name == ZYTextConst.c_FontStrikeout ||
                                        attr.Name == ZYTextConst.c_DoubleFontStrikeout ||
                                        attr.Name == ZYTextConst.c_ForeColor
                                        ).ToList();
                                    XmlElement parentFont = myElement.OwnerDocument.CreateElement("fontattr");
                                    fontList.ForEach(attr => parentFont.SetAttribute(attr.Name, attr.Value));
                                    FirstChar.Attributes.FromXML(parentFont);
                                }
                                // 加载纯文本
                                FirstChar.Char = strText[0];
                            }
                            ZYTextChar newChar = null;
                            for (int iCount = 1; iCount < strText.Length; iCount++)
                            {
                                newChar = ZYTextChar.Create(strText[iCount]);// new ZYTextChar();
                                FirstChar.Attributes.CopyTo(newChar.Attributes);

                                newChar.UpdateAttrubute();
                                newChar.CreatorIndex = FirstChar.CreatorIndex;
                                //newChar.CreateTime		= FirstChar.CreateTime ;
                                newChar.DeleterIndex = FirstChar.DeleterIndex;
                                //newChar.DeleteTime		= FirstChar.DeleteTime ;
                                //newChar.Char			= strText[iCount];
                                myList.Add(newChar);
                            }//for
                        }//if
                    }//if
                }//if

                else
                {
                    System.Xml.XmlElement myXMLE = myXMLNode as System.Xml.XmlElement;
                    if (myXMLE != null)
                    {
                        //if (myXMLE.Name == "eof")
                        //{
                        //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("剪切板无内容");
                        //    return false;
                        //}
                        // 根据子XML节点创建一个对象
                        NewElement = this.CreateElement(myXMLE.Name);
                        if (NewElement != null)
                        {
                            // 加载对象数据
                            if (NewElement.FromXML(myXMLE))
                            {
                                myList.Add(NewElement);
                                // 拆分对象
                                //NewElement.SplitElement(myList ,-1);
                            }//if
                        }//if
                    }//if
                }//else
            }//foreach
            foreach (ZYTextElement vElement in myList)
                vElement.OwnerDocument = this;
            return true;
        }

        /// <summary>
        /// 从一个XML文档加载对象数据
        /// </summary>
        /// <param name="strURL">XML文件的URL</param>
        /// <returns>加载是否成功</returns>
        /// <seealso>ZYTextDocumentLib.ZYTextDocument.FromXML</seealso>
        public bool FromXMLFile(string strURL)
        {
            System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
            myDoc.PreserveWhitespace = true;
            myDoc.Load(strURL);

            if (FromXML(myDoc.DocumentElement))
            {
                myInfo.FileName = strURL;
                return true;
            }
            return false;
        }


        //add by myc 2014-10-14 添加原因：解决东石医院特殊隐藏表格规定复用项目导致的换页空白问题
        private bool isConfigSpecialPagingInDongShi = false;

        /// <summary>
        /// 从一个XML节点加载文档数据
        /// </summary>
        /// <remarks>本函数加载文档的用户列表,文档参数,文档设置信息,并从根节点开始加载文档显示内容</remarks>
        /// <param name="RootElement">XML节点</param>
        /// <returns>加载是否成功</returns>
        /// <seealso>ZYTextDocumentLib.ZYTextDocument.CreateElementByXML</seealso>
        public bool FromXML(System.Xml.XmlElement RootElement)
        {
            // 清空对象数据
            bolLoading = true;
            UndoStack.ClearAll();
            RootElement.OwnerDocument.PreserveWhitespace = true;
            mySaveLogs.Clear();
            myMarks.Clear();
            //this.ClearContent(); mfb注释
            RootDocumentElement = null;
            if (myInfo.EnableSaveLog)
            {
                //myMarks.FromXML(XMLCommon.CreateChildElement(RootElement, myMarks.GetXMLName(), false));
                mySaveLogs.FromXML(XMLCommon.CreateChildElement(RootElement, mySaveLogs.GetXMLName(), false));
            }
            else
            {
                //myMarks.FromXML(null);
                mySaveLogs.FromXML(null);
            }
            myInfo.VisibleUserLevel = -1;

            // 加载文档信息 (mfb 2009-8-6 add)
            XmlElement mInfoEle = XMLCommon.GetElementByName(RootElement, ZYDocumentInfo.GetXMLName(), false);
            if (mInfoEle != null)
            {
                myInfo.FromXML(mInfoEle);
            }

            //加载页面设置
            XmlNode pagesetting = RootElement.SelectSingleNode("pagesettings");
            if (pagesetting != null)
            {
                XmlElement ele = (pagesetting as XmlElement).SelectSingleNode("page") as XmlElement;
                XPageSettings ps = new XPageSettings();
                ps.PaperSize.Kind = (PaperKind)Enum.Parse(typeof(PaperKind), ele.GetAttribute("kind"));

                if (ps.PaperSize.Kind == PaperKind.Custom)
                {
                    ps.PaperSize.Height = int.Parse(ele.GetAttribute("height"));
                    ps.PaperSize.Width = int.Parse(ele.GetAttribute("width"));
                }

                ele = (pagesetting as XmlElement).SelectSingleNode("margins") as XmlElement;
                ps.Margins.Left = int.Parse(ele.GetAttribute("left"));
                ps.Margins.Right = int.Parse(ele.GetAttribute("right"));
                ps.Margins.Top = int.Parse(ele.GetAttribute("top"));
                ps.Margins.Bottom = int.Parse(ele.GetAttribute("bottom"));

                ele = (pagesetting as XmlElement).SelectSingleNode("landscape") as XmlElement;
                ps.Landscape = bool.Parse(ele.GetAttribute("value"));

                this.Pages.PageSettings = ps;
            }

            #region bwy :
            //加载页眉模板
            //XmlNode header = RootElement.SelectSingleNode("header"); //add by myc 2014-06-30 注释原因：新版页眉二期改版需要
            //if (header != null)
            //{
            //    this.HeadString = header.OuterXml;
            //}


            #region add by myc 2014-07-01 添加原因：新版页眉二期改版之导入外部Xml文档时更新页眉区域根元素列表
            editingAreaFlag = 1; //设置文档默认可编辑区为文档正文区域
            RootDocumentElementsInHeader.Clear();

            //xll  部分xml body部分什么都没有 无法展示  2014-07-24
            XmlNode bodyOne = RootElement.SelectSingleNode("body");
            if (bodyOne != null && (bodyOne.InnerXml == null || bodyOne.InnerXml.Trim() == ""))
            {
                bodyOne.InnerXml = @"<p><eof /></p>";
            }


            #region add by myc 2014-08-26 添加原因：处理宜昌中心医院的空白页眉不能解析又想正文留出一定空白高度的问题
            bool isChuFang = false;
            //bool isChuZhiDan = false;
            bool isConfigXmlInYiChan = false;
            foreach (XmlNode oneNode in bodyOne.ChildNodes)
            {
                if (oneNode is XmlElement)
                {
                    XmlElement oneEle = oneNode as XmlElement;
                    //针对医嘱——>杨伟康等在模板正文加的临时回车符兼容处理 2014-08-28
                    if (oneEle.Name == "p" && oneEle.HasAttribute("align") && oneEle.GetAttribute("align").ToString() == "2")
                    {
                        if (oneNode.ChildNodes.Count == 1 && oneNode.FirstChild.Name == "eof")
                        {
                            if (bodyOne.InnerText.Contains("医") && bodyOne.InnerText.Contains("嘱"))
                            {
                                bodyOne.RemoveChild(oneNode);
                                continue;
                            }
                        }
                    }
                    //针对处方 2014-08-28
                    if (oneEle.Name == "p" && oneEle.InnerText.Contains("处") && oneEle.InnerText.Contains("方"))
                    {
                        isChuFang = true;
                    }

                    //判断是否为宜昌中心人民医院的Xml文档 2014-08-28
                    //foreach (XmlNode secondNode in oneNode.ChildNodes)
                    //{
                    //    if (secondNode.Name == "span" && secondNode.InnerText.Contains("宜") && secondNode.InnerText.Contains("昌")
                    //        && secondNode.InnerText.Contains("医") && secondNode.InnerText.Contains("院"))
                    //    {
                    //        isConfigXmlInYiChan = true;
                    //    }
                    //}

                    if (YD_SqlService.GetHospitalName() == "宜昌市中心人民医院")
                    {
                        isConfigXmlInYiChan = true;
                    }
                }
            }
            XmlNodeList headerList = RootElement.SelectNodes("header");
            if (isConfigXmlInYiChan) //2014-09-01 针对宜昌中心医院
            {
                if (headerList != null && headerList.Count > 0)
                {
                    foreach (XmlNode header in headerList)
                    {
                        if (header is XmlElement)
                        {
                            XmlElement xmlHeader = header as XmlElement;

                            if (isChuFang)
                            {
                                xmlHeader.SetAttribute("    ", "100"); //设置配置标识
                                continue;
                            }

                            if (xmlHeader.HasAttribute("SX_UseDrawDocumentMode")) //新版页眉第三次改版标志
                            {
                                if (!xmlHeader.HasChildNodes) //处理原始版本页眉Xml错误<p><eof>宜昌中心人民医院之类</eof><p>保存之后变成<header/>
                                {
                                    xmlHeader.SetAttribute("IsConfigHeaderHeightInYiChan", "0"); //设置配置标识
                                }
                            }
                            else //原始旧版页眉与第二次页眉改版标志
                            {
                                if (!xmlHeader.InnerXml.Contains("<span")
                                    && !string.IsNullOrEmpty(xmlHeader.InnerText)) //处理原始版本页眉Xml错误<p><eof>宜昌中心人民医院之类</eof><p>
                                {
                                    xmlHeader.SetAttribute("IsConfigHeaderHeightInYiChan", "0"); //设置配置标识
                                }
                            }
                        }
                    }
                }
            }
            #endregion


            CheckHeaderXMLInLoadDocument(headerList);


            #region 针对江西九江2014-07-17
            if (headerList != null && headerList.Count > 0)
            {
                foreach (XmlNode header in headerList)
                {
                    if (header is XmlElement && (!(header as XmlElement).HasAttribute("SX_UseDrawDocumentMode"))) //add by myc 2014-07-17 添加原因：兼容旧版页眉空行单回车符不绘制情况——>江西九江
                    {
                        for (int i = 0; i < header.ChildNodes.Count; i++)
                        {
                            XmlNode node = header.ChildNodes[i] as XmlNode;
                            if (node != null)
                            {
                                if (i == 0 && node.Name == "p")
                                {
                                    XmlNodeList nodeList = node.SelectNodes("span");
                                    if (nodeList != null && nodeList.Count == 2) //add by myc 2014-07-23 添加原因：处理医院页眉区域的垃圾数据
                                    {
                                        node.RemoveChild(nodeList[1]);
                                    }
                                }
                                if (node.Name == "p" && node.ChildNodes.Count == 1 && node.ChildNodes[0].Name == "eof")
                                {
                                    header.RemoveChild(node);
                                }
                            }
                        }
                    }

                    ZYDocumentHeader RootDocumentElementInHeader = this.CreateElementByXML(header as System.Xml.XmlElement) as ZYDocumentHeader;
                    if (RootDocumentElementInHeader != null)
                    {
                        RootDocumentElementInHeader.Attributes.FromXML(header as System.Xml.XmlElement); //add by myc 2014-07-24 添加原因：兼容旧版页眉主标题替换医院名称需要（同时兼容之前的一期页眉改版）
                        //添加至页眉区域的文档根元素列表
                        RootDocumentElementsInHeader.Add(RootDocumentElementInHeader);
                    }
                }
            }
            #endregion
            #endregion


            //加载页脚模板
            //XmlNode footer = RootElement.SelectSingleNode("footer"); //add by myc 2014-07-07 注释原因：新版页脚改版需要
            //if (footer != null)
            //{
            //    this.FooterString = footer.OuterXml;
            //}

            #region add by myc 2014-07-07 添加原因：新版页脚之导入外部Xml文档时更新页脚区域根元素列表
            editingAreaFlag = 1; //设置文档默认可编辑区为文档正文区域
            RootDocumentElementsInFooter.Clear();
            XmlNodeList footerList = RootElement.SelectNodes("footer");
            if (footerList != null && footerList.Count > 0)
            {
                foreach (XmlNode footer in footerList)
                {
                    ZYDocumentFooter RootDocumentElementInFooter = this.CreateElementByXML(footer as System.Xml.XmlElement) as ZYDocumentFooter;
                    if (RootDocumentElementInFooter != null)
                    {
                        //添加至页脚区域的文档根元素列表
                        RootDocumentElementsInFooter.Add(RootDocumentElementInFooter);
                    }
                    else //2014-08-28 处理宜昌中心医院页脚Xml错误代码
                    {
                        if (footer.InnerXml.Contains("<p>"))
                        {
                            footer.InnerXml = "<p><eof></eof></p>";
                            RootDocumentElementInFooter = this.CreateElementByXML(footer as System.Xml.XmlElement) as ZYDocumentFooter;
                            //添加至页脚区域的文档根元素列表
                            RootDocumentElementsInFooter.Add(RootDocumentElementInFooter);
                        }
                    }
                }
            }
            #endregion




            //行距 
            if (RootElement.HasAttribute("linespacing"))
            {
                this.Info.LineSpacing = int.Parse(RootElement.GetAttribute("linespacing"));
            }
            //加载页面设置
            //XmlNode pagesettings = 

            //XPageSettings ps = new XPageSettings();
            //double rate = XPaperSize.GetRate(this.intGraphicsUnit);
            //ps.Margins = new System.Drawing.Printing.Margins(
            //    (int)(this.intLeftMargin * rate),
            //    (int)(this.intRightMargin * rate),
            //    (int)(this.intTopMargin * rate),
            //    (int)(this.intBottomMargin * rate));
            //ps.Landscape = this.bolLanscape;
            //ps.PaperSize = this.PaperSize;

            //this.Pages.PageSettings = ps; 
            #endregion bwy :

            //遍历document里面的所有子节点
            foreach (System.Xml.XmlNode myNode in RootElement.ChildNodes)
            {
                if (myNode.Name == ZYTextConst.c_Div || myNode.Name == ZYTextConst.c_Body)
                {
                    //add by myc 2014-07-29 暂时开放基本表格跨页功能，但是注意文档最后一个元素是表格时，那么需要在这个表格之后加上一个回车符（灌南医院）才能确保最后一页的坐标系准确——>这个非常重要
                    if (myNode is XmlElement)
                    {
                        if ((myNode as XmlElement).LastChild.Name != "p")
                        {
                            //(myNode as XmlElement).InnerXml = (myNode as XmlElement).InnerXml + @"<p><eof /></p>"; //2014-08-28 处理宜昌医院之页眉空白高度则需取消
                        }
                    }

                    #region 针对东石医院之入院记录（采用隐藏表格规范格式）的换页问题 2014-10-14 myc

                    isConfigSpecialPagingInDongShi = false; //add by myc 2014-10-14 添加原因：重置东石医院特殊换页标志为false
                    if (YD_SqlService.GetHospitalName().Contains("东石"))
                    {
                        foreach (XmlNode oneNode in bodyOne.ChildNodes)
                        {
                            if (oneNode.Name.ToLower() == "table") //表格节点
                            {
                                foreach (XmlNode secondNode in oneNode.ChildNodes)
                                {
                                    if (secondNode.Name.ToLower() == "table-row") //表格行节点
                                    {
                                        foreach (XmlNode thirdNode in secondNode.ChildNodes)
                                        {
                                            if (thirdNode.Name.ToLower() == "table-cell") //单元格节点
                                            {
                                                foreach (XmlNode fourNode in thirdNode.ChildNodes)
                                                {
                                                    if (fourNode.Name.ToLower() == "p") //段落节点
                                                    {
                                                        foreach (XmlNode fiveNode in fourNode.ChildNodes)
                                                        {
                                                            if (fiveNode.Name.ToLower() == "text"
                                                                && fiveNode is XmlElement
                                                                && (fiveNode as XmlElement).HasAttribute("name")
                                                                && ((fiveNode as XmlElement).GetAttribute("name").ToString().Contains("既往史")
                                                                   || (fiveNode as XmlElement).GetAttribute("name").ToString().Contains("月经史")
                                                                   || (fiveNode as XmlElement).GetAttribute("name").ToString().Contains("现病史")))
                                                            {
                                                                this.isConfigSpecialPagingInDongShi = true; //配置特殊换页标志
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    RootDocumentElement = this.CreateElementByXML(myNode as System.Xml.XmlElement) as ZYTextContainer;
                    if (RootDocumentElement != null)
                    {
                        RootDocumentElement.OwnerDocument = this;
                        RootDocumentElement.UpdateUserLogin();

                        //myDocumentElement.UpdateBounds();

                        break;
                    }
                }
            }
            myContent.SetSelection(0, 0);
            this.RefreshElements();
            bolLoading = false;
            this.Modified = false;

            isImportXml = true; //add by myc 2014-09-17 表格跨页第三次改版需要

            return true;
        }
        /// <summary>
        /// 根据一个XML节点创建一个文本文档元素,并填充结构化数据
        /// </summary>
        /// <param name="myElement">XML节点</param>
        /// <returns>新增的文本文档元素,若不支持该XML格式则返回空引用</returns>
        public ZYTextElement CreateElementByXML(System.Xml.XmlElement myElement)
        {
            if (myElement == null)
                return null;
            ZYTextElement NewElement = this.CreateElement(myElement.Name);
            if (NewElement != null)
            {
                //FillDataSource(myElement);
                NewElement.FromXML(myElement);
                NewElement.OwnerDocument = this;
                return NewElement;
            }
            return null;
        }
        /// <summary>
        /// 根据类型名称创建一个元素
        /// </summary>
        /// <remarks>目前支持类型名称为
        /// br		行对象 ZYTextLineEnd 
        /// p		段落对象 ZYTextParagraph
        /// div		文本块对象 ZYTextDiv
        /// select  下拉列表 ZYTextSelect
        /// img		图象对象 ZYTextImage
        /// input	输入域对象 ZYTextInput
        /// hr		水平线对象 ZYTextHRule
        /// keyword 关键字对象 ZYTextKeyWord
        /// 新增的元素将设置它的创建者为当前用户
        /// </remarks>
        /// <param name="strName">类型名称</param>
        /// <returns>新建的元素,若不支持该类型的返回空引用</returns>
        public virtual ZYTextElement CreateElement(string strName)
        {
            ZYTextElement NewElement = null;
            if (strName == null || strName.Trim().Length == 0)
                return null;
            strName = strName.Trim();
            switch (strName)
            {
                case ZYTextConst.c_Br:
                    NewElement = new ZYTextLineEnd();
                    break;
                case ZYTextConst.c_P:
                    NewElement = new ZYTextParagraph();
                    break;
                case ZYTextConst.c_Body:
                    NewElement = new ZYTextDiv();
                    break;
                case ZYTextConst.c_Div:
                    NewElement = new ZYTextDiv();
                    break;
                case ZYTextConst.c_Img:
                    NewElement = new ZYTextImage();
                    break;
                case ZYTextConst.c_PEOF:
                    NewElement = new ZYTextEOF();
                    break;
                case ZYTextConst.c_Selement:
                    NewElement = new ZYSelectableElement();
                    break;
                case ZYTextConst.c_FTimeElement:
                    NewElement = new ZYFormatDatetime();
                    break;
                case ZYTextConst.c_FNumElement:
                    NewElement = new ZYFormatNumber();
                    break;
                case ZYTextConst.c_FStrElement:
                    NewElement = new ZYFormatString();
                    break;
                case ZYTextConst.c_RoElement:
                    NewElement = new ZYFixedText();
                    break;
                case ZYTextConst.c_EMRText:
                    NewElement = new ZYText();
                    break;
                case ZYTextConst.c_BtnElement:
                    NewElement = new ZYButton();
                    break;
                case ZYTextConst.c_Helement:
                    NewElement = new ZYPromptText();
                    break;
                case ZYTextConst.c_MensesFormula://月经史公式
                    NewElement = new ZYMensesFormula();
                    break;

                case ZYTextConst.c_ToothCheck://牙齿检查 add by ywk 2012年11月27日16:55:40
                    NewElement = new ZYToothCheck();
                    break;

                case ZYTextConst.c_HorizontalLine://水平线
                    NewElement = new ZYHorizontalLine();
                    break;
                case ZYTextConst.c_Macro://宏
                    NewElement = new ZYMacro();
                    break;
                case ZYTextConst.c_Replace://可替换项
                    NewElement = new ZYReplace();
                    break;

                case ZYTextConst.c_Template://子模板
                    NewElement = new ZYTemplate();
                    break;
                case ZYTextConst.c_CheckBox://复选框
                    NewElement = new ZYCheckBox();
                    break;
                case ZYTextConst.c_PageEnd://分页符
                    NewElement = new ZYPageEnd();
                    break;
                case ZYTextConst.c_Flag://定位符
                    NewElement = new ZYFlag();
                    break;
                case ZYTextConst.c_Table://表格
                    NewElement = new TPTextTable();
                    break;
                case ZYTextConst.c_Row:
                    NewElement = new TPTextRow();
                    break;
                case ZYTextConst.c_Cell:
                    NewElement = new TPTextCell();
                    break;
                case ZYTextConst.c_LookupEditor:
                    NewElement = new ZYLookupEditor(); //字典
                    break;
                case ZYTextConst.c_DataElementLookupEditor:
                    NewElement = new ZYDataElementLookupEditor(); //数据元元素字典
                    break;
                case ZYTextConst.c_Diag:
                    NewElement = new ZYDiag(); //2019.10.10-hdf：新增诊断元素
                    break;
                case ZYTextConst.c_Subject:
                    NewElement = new ZYSubject(); //2020-12-9 ：新增辅助录入元素
                    break;
                case ZYTextConst.c_TableSum:
                    NewElement = new ZYTableSum(); //2020-12-9 ：新增辅助录入元素
                    break;
                case ZYTextConst.c_Header: //add by myc 2014-06-24 添加原因：新版页眉二期改版需要
                    //NewElement = new ZYTextDiv();
                    NewElement = new ZYDocumentHeader();
                    break;

                case ZYTextConst.c_Footer: //add by myc 2014-07-07 添加原因：新版页脚需要
                    //NewElement = new ZYTextDiv();
                    NewElement = new ZYDocumentFooter();
                    break;
            }
            if (NewElement != null)
            {
                NewElement.OwnerDocument = this;
                //NewElement.CreatorIndex = mySaveLogs.CurrentIndex;
            }
            return NewElement;
        }

        /// <summary>
        /// 保存文档内容到根XML节点中
        /// </summary>
        /// <remarks>本函数保存文档的用户列表,文档信息和配置信息以及文档内容到一个XML节点下</remarks>
        /// <param name="RootElement">XML节点</param>
        /// <returns>操作是否成功</returns>
        public bool ToXML(System.Xml.XmlElement RootElement)
        {
            if (RootElement != null)
            {
                RootElement.OwnerDocument.PreserveWhitespace = true;
                #region bwy :
                //保存文档相关信息
                //this.Info.ToXML(RootElement);
                //保存页面设置
                XmlElement pageSettings = RootElement.OwnerDocument.CreateElement("pagesettings");
                this.Pages.PageSettings.ToXML(pageSettings);
                RootElement.AppendChild(pageSettings);


                #region add by myc 2014-06-30 注释原因：新版页眉二期改版需要
                ////保存页眉模板
                //if (this.HeadString.Length > 0)
                //{
                //    XmlElement header = RootElement.OwnerDocument.CreateElement("header");
                //    XmlDocument headerdoc = new XmlDocument();
                //    //需要这句，否则设置新页眉时有间距，保存再打开后就没间距了
                //    headerdoc.PreserveWhitespace = true;
                //    headerdoc.LoadXml(this.HeadString);
                //    header.InnerXml = headerdoc.DocumentElement.InnerXml;

                //    if (this.HeadString.Contains("left"))
                //    {
                //        header.SetAttribute("sx_flag", "new"); //add by myc 2014-01-16 这里特别重要，这个是新旧页眉的标志，为了与老数据兼容
                //        header.SetAttribute("height", headerdoc.DocumentElement.GetAttribute("height").ToString()); //文档页眉自适应高度值保存
                //    }

                //    RootElement.AppendChild(header);
                //} 
                #endregion

                #region add by myc 2014-06-30 添加原因：新版页眉二期改版需要
                if (RootDocumentElementsInHeader != null && RootDocumentElementsInHeader.Count > 0)
                {
                    for (int i = 0; i < RootDocumentElementsInHeader.Count; i++)
                    {
                        XmlElement header = RootElement.OwnerDocument.CreateElement("header");
                        System.Xml.XmlDocument headerDocument = new System.Xml.XmlDocument();
                        headerDocument.PreserveWhitespace = true;
                        headerDocument.AppendChild(headerDocument.CreateElement(ZYTextConst.c_Header));
                        ZYTextElement.ElementsToXML((RootDocumentElementsInHeader[i] as ZYTextContainer).ChildElements, headerDocument.DocumentElement);
                        header.InnerXml = headerDocument.DocumentElement.InnerXml;
                        header.SetAttribute("SX_UseDrawDocumentMode", "true"); //add by myc 2014-07-17 添加原因：兼容旧版页眉空行时的美观处理——>解决江西九江出现的问题
                        (RootDocumentElementsInHeader[i] as ZYTextContainer).Attributes.ToXML(header); //add by myc 2014-07-24 添加原因：兼容旧版页眉主标题替换医院名称需要（同时兼容之前的一期页眉改版）
                        RootElement.AppendChild(header);
                    }
                }
                #endregion

                #region add by myc 2014-07-07 注释原因：新版页脚需要
                ////保存页脚模板
                //if (this.FooterString.Length > 0)
                //{
                //    XmlElement footer = RootElement.OwnerDocument.CreateElement("footer");
                //    XmlDataDocument footerdoc = new XmlDataDocument();
                //    footerdoc.LoadXml(this.FooterString);
                //    footer.InnerXml = footerdoc.DocumentElement.InnerXml;
                //    RootElement.AppendChild(footer);
                //}
                #endregion

                #region add by myc 2014-07-07 添加原因：新版页脚需要
                if (RootDocumentElementsInFooter != null && RootDocumentElementsInFooter.Count > 0)
                {
                    for (int i = 0; i < RootDocumentElementsInFooter.Count; i++)
                    {
                        XmlElement footer = RootElement.OwnerDocument.CreateElement("footer");
                        System.Xml.XmlDocument footerDocument = new System.Xml.XmlDocument();
                        footerDocument.PreserveWhitespace = true;
                        footerDocument.AppendChild(footerDocument.CreateElement(ZYTextConst.c_Header));
                        ZYTextElement.ElementsToXML((RootDocumentElementsInFooter[i] as ZYTextContainer).ChildElements, footerDocument.DocumentElement);
                        footer.InnerXml = footerDocument.DocumentElement.InnerXml;
                        RootElement.AppendChild(footer);
                    }
                }
                #endregion

                #endregion bwy :
                if (myInfo.SaveMode == 3)
                {
                    //这里的RootDocumentElement是ZYTextContainer的一个对象
                    if (RootDocumentElement != null)
                    {
                        RootDocumentElement.ToXML(RootElement);
                    }
                }
                else
                {
                    #region mfb
                    //RootElement.SetAttribute(ZYTextConst.c_Version, c_EditorVersion);
                    //RootElement.SetAttribute("checkcount", myMarks.Count.ToString());
                    //RootElement.SetAttribute("senior", myMarks.LastSenior);
                    mySaveLogs.CurrentSaveLog.SaveDateTime = ZYTime.GetServerTime();//System.DateTime.Now ;
                    if (myMarks.NewMark != null)
                        myMarks.NewMark.MarkTime = mySaveLogs.CurrentSaveLog.SaveDateTime;
                    if (myInfo.EnableSaveLog)
                    {
                        // 保存签名信息
                        myMarks.ToXML(XMLCommon.CreateChildElement(RootElement, myMarks.GetXMLName(), true));
                        // 保存保存文档记录
                        mySaveLogs.ToXML(XMLCommon.CreateChildElement(RootElement, mySaveLogs.GetXMLName(), true));

                    }
                    // 保存用户列表
                    //myUserList.ToXML( XMLCommon.CreateChildElement(RootElement , ZYUserList.c_RootXMLName ,true));
                    // 保存文档信息
                    //myInfo.ModifyTime = StringCommon.GetNowString14();
                    myInfo.ModifyTime = ZYTime.GetServerTime().ToString("yyyyMMddHHmmss");
                    myInfo.Version = c_EditorVersion;
                    myInfo.Modifier = mySaveLogs.CurrentIndex.ToString();
                    myInfo.ToXML(XMLCommon.CreateChildElement(RootElement, ZYDocumentInfo.GetXMLName(), true));
                    // 保存参数
                    //if (myVariables.Count > 0)
                    //{
                    //    System.Xml.XmlElement myValueElement = XMLCommon.CreateChildElement(RootElement, "values", true);
                    //    for (int iCount = 0; iCount < myVariables.Count; iCount++)
                    //    {
                    //        System.Xml.XmlElement myElement = RootElement.OwnerDocument.CreateElement("value");
                    //        myElement.SetAttribute("name", myVariables.GetName(iCount));
                    //        myElement.InnerText = myVariables.GetValue(iCount);
                    //        myValueElement.AppendChild(myElement);
                    //    }
                    //}
                    // 保存脚本对象
                    //myScript.ToXML(XMLCommon.CreateChildElement(RootElement, myScript.GetXMLName(), true));

                    //if (myInfo.SaveMode == 0)
                    //{
                    //    System.Xml.XmlElement TextElement = XMLCommon.CreateChildElement(RootElement, ZYTextConst.c_Text, true);
                    //    System.Text.StringBuilder myStr = new System.Text.StringBuilder();
                    //    RootDocumentElement.GetFinalText(myStr);
                    //    TextElement.InnerText = myStr.ToString();
                    //}
                    #endregion
                    if (RootDocumentElement != null)
                    {
                        RootDocumentElement.ToXML(XMLCommon.CreateChildElement(RootElement, ZYTextConst.c_Body, true));
                        //XmlElement bodyEle = XMLCommon.CreateChildElement(RootElement, ZYTextConst.c_Body, true);
                        //RootDocumentElement.ToXML(XMLCommon.CreateChildElement(bodyEle, ZYTextConst.c_BodyText, true));
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 保存文档到一个XML文件中
        /// </summary>
        /// <param name="strURL">一个XML文件名</param>
        /// <returns>操作是否成功</returns>
        public bool ToXMLFile(string strURL)
        {
            System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
            //myDoc.AppendChild(myDoc.CreateElement(ZYTextConst.c_EMRTextDoc));
            CreateRootElement(ref myDoc);

            if (ToXML(myDoc.DocumentElement))
            {
                myDoc.PreserveWhitespace = false;
                myDoc.Save(strURL);
                myInfo.FileName = strURL;
                return true;
            }
            return false;
        }

        //文档以字节数组方式返回
        public byte[] GetBinaryFile()
        {
            //获得xmldoc文档
            //System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
            //pnlText.EMRDoc.CreateRootElement(ref myDoc);
            //ToXML(myDoc.DocumentElement);
            return new Byte[10000];
        }

        /// <summary>
        /// 保存文档对象到一个XML文档对象中
        /// </summary>
        /// <param name="myDoc">XML文档对象</param>
        /// <returns>操作是否成功</returns>
        public bool ToXMLDocument(System.Xml.XmlDocument myDoc)
        {
            //TODO: 这里改为了新的构建根元素
            myDoc.PreserveWhitespace = true;

            CreateRootElement(ref myDoc);

            return ToXML(myDoc.DocumentElement);
        }
        //mfb 添加一个根节点元素
        public void CreateRootElement(ref XmlDocument myDoc)
        {
            myDoc.LoadXml("<" + ZYTextConst.c_EMRTextDoc + "/>");
        }

        #endregion

        #region 绘制图形相关的函数群 **************************************************************

        /// <summary>
        /// 隐藏编辑器的光标
        /// </summary>
        public void HideCaret()
        {
            if (myOwnerControl != null)
                myOwnerControl.HideOwnerCaret();
        }

        /// <summary>
        /// 开始更新内容
        /// </summary>
        public void BeginUpdate()
        {
            if (myOwnerControl != null)
                myOwnerControl.BeginUpdate();
        }
        /// <summary>
        /// 结束更新内容
        /// </summary>
        public void EndUpdate()
        {
            if (myOwnerControl != null)
            {
                if (this.ElementsDirty)
                {
                    this.RefreshElements();
                    this.RefreshLine();
                }
                myOwnerControl.EndUpdate();
                if (myOwnerControl.Updating == false)
                {
                    UpdateView();
                }
            }
        }

        /// <summary>
        /// 更新视图区域
        /// </summary>
        public void UpdateView()
        {
            if (this.UpdateViewNoScroll())
            {
                UpdateTextCaret();
            }
        }

        /// <summary>
        /// 更新光标位置
        /// </summary>
        public void UpdateTextCaret()
        {
            if (myOwnerControl != null)
            {
                myOwnerControl.UpdateTextCaret();
            }
        }
        /// <summary>
        /// 更新视图区域
        /// </summary>
        public bool UpdateViewNoScroll()
        {
            if (myOwnerControl != null && myOwnerControl.Updating == false)
            {
                myOwnerControl.UpdatePages();
                myOwnerControl.UpdateInvalidateRect();
                if (RefreshAllFlag)
                {
                    myOwnerControl.Refresh();
                    RefreshAllFlag = false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断一个元素是否需要重新绘制
        /// </summary>
        /// <param name="myElement">元素对象</param>
        /// <returns>元素是否需要重绘</returns>
        public bool isNeedDraw(ZYTextElement myElement)
        {
            if (myElement == null)
                return false;
            else
                return myView.isNeedDraw(myElement.RealLeft, myElement.RealTop, myElement.Width, myElement.Height);
        }

        /// <summary>
        /// 判断一个矩形是否处于无效区域,是否需要进行重新绘制
        /// </summary>
        /// <param name="myRect">矩形对象</param>
        /// <returns>是否需要进行重绘</returns>
        public bool isNeedDraw(System.Drawing.Rectangle myRect)
        {
            //return true;
            return myView.isNeedDraw(myRect);
        }

        /// <summary>
        /// 判断一个矩形是否处于无效区域,是否需要重新进行绘制
        /// </summary>
        /// <param name="vLeft">矩形区域的左端位置</param>
        /// <param name="vTop">矩形区域的顶端位置</param>
        /// <param name="vWidth">矩形区域的宽度</param>
        /// <param name="vHeight">矩形区域的高度</param>
        /// <returns>是否需要进行重绘</returns>
        public bool isNeedDraw(int vLeft, int vTop, int vWidth, int vHeight)
        {
            return myView.isNeedDraw(vLeft, vTop, vWidth, vHeight);
        }



        public void UpdatePageSetting()
        {
            myPages.HeadHeight = this.HeadHeight;
            myPages.FooterHeight = this.FooterHeight;
        }


        internal int FixPageLine(int Pos)
        {
            //********todo 解决含有分页符的病历续打不能选中超出分页符部分的问题 Modified By wwj 2011-10-13 ***********
            /*
            PageLineInfo info = new PageLineInfo(0, 0, Pos, 0);
            FixPageLine(info);
            return info.Pos;
            */
            return Pos;
            //****************************************************************************************************
        }

        #region add by myc 2014-07-28 重构表格跨页例程需要
        public void FixPageLine(PageLineInfo info)
        {
            int pos = info.Pos;
            int min = 10000;
            ZYTextLine MinLine = null;
            //foreach (ZYTextLine myLine in myLines) //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
            foreach (ZYTextLine myLine in editingAreaLines[1]) //add by myc 2014-07-03 添加原因：新版页眉二期改版之文档正文分页线计算，这个非常重要
            {
                int intRealTop = myLine.RealTop;
                if (pos >= intRealTop
                    && pos - intRealTop < min
                    && pos < intRealTop + myLine.FullHeight)
                {
                    MinLine = myLine;
                    min = pos - intRealTop;
                }
                #region bwy
                if (info.LastPos <= myLine.RealTop && myLine.RealTop + myLine.FullHeight <= info.Pos && myLine.FirstElement is ZYPageEnd)
                {
                    MinLine = myLine;
                    min = pos - intRealTop;
                    info.Pos = MinLine.RealTop + myLine.FullHeight;
                    return;
                }
                #endregion bwy


            }
            if (MinLine != null)
                info.Pos = MinLine.RealTop;
            else
                info.Pos = RootDocumentElement.Top + RootDocumentElement.Height;
        }
        #endregion


        //		/// <summary>
        //		/// 重新进行分页
        //		/// </summary>
        //		public void RefreshPages()
        //		{
        //			myPages.Clear();
        //			myPages.Top = 0 ;//myDocumentElement.Top ;
        //			//myPages.UpdatePageSettings();
        //			while(myPages.BodyHeight + myPages.HeadHeight + myPages.TailHeight <  myDocumentElement.Height )
        //			{
        //				PrintPage NewPage = myPages.NewPage();
        //				int intBottom = NewPage.Bottom ;
        //				int intMin = 100000 ;
        //				//int LastLineBottom = (( ZYTextLine ) myLines[0]).RealTop ;
        //				ZYTextLine MinLine = null;
        //				// 获得和分页线最近且在顶端位置在分页线上面的文本行对象
        //				foreach(ZYTextLine myLine in myLines)
        //				{
        //					int intRealTop = myLine.RealTop ;
        //					if(    intBottom >= intRealTop					// 分页符高于当前行的顶端
        //						&& intBottom - intRealTop < intMin			// 分页符和当前行的顶端的距离小于最小距离
        //						&& intBottom < intRealTop + myLine.FullHeight ) // 分页符低于当前行的底部
        //					{
        //						MinLine = myLine ;
        //						intMin = intBottom - intRealTop ;
        //					}
        //					//LastLineBottom = intRealTop + myLine.FullHeight ;
        //				}
        //				// 若找到这样的文本行则重新设置分页线位置,否则退出分页
        //				if( MinLine != null)
        //				{
        //					myPages.AddPage( NewPage );
        //					NewPage.Bottom = MinLine.RealTop ;
        //					NewPage.Height -= 1;
        //				}
        //				else
        //				{
        //					NewPage.Bottom = myDocumentElement.Top + myDocumentElement.Height ;
        //					myPages.AddPage( NewPage );
        //					//break;
        //				}
        //			}
        //			if( myOwnerControl != null)
        //			{
        //				//myOwnerControl.Pages = myPages ;
        //				if( myOwnerControl.PageViewMode)
        //					myOwnerControl.RefreshPages();
        //			}
        //		}


        /// <summary>
        /// 绘制全部内容
        /// </summary>
        /// <returns>操作是否成功</returns>
        private bool DrawAll()
        {
            RootDocumentElement.RefreshView();
            return true;
        }
        #region Refresh相关方法
        /// <summary>
        /// 重新绘制整个文档
        /// </summary>
        public void Refresh()
        {
            if (myOwnerControl != null)
                myOwnerControl.Invalidate();//.Refresh();
        }

        /// <summary>
        /// 重新绘制一个元素
        /// </summary>
        /// <param name="myElement">元素对象</param>
        public void RefreshElement(ZYTextElement myElement)
        {
            if (myOwnerControl != null)
            {
                if (myElement is ZYTextContainer)
                {
                    myOwnerControl.AddInvalidateRect((myElement as ZYTextContainer).GetContentBounds());
                }
                else
                    myOwnerControl.AddInvalidateRect(myElement.RealLeft, myElement.RealTop, myElement.Width + myElement.WidthFix, myElement.OwnerLine.Height);
                myOwnerControl.UpdateInvalidateRect();
            }
        }
        public void RefreshElements()
        {
            RefreshElements(false);
        }
        /// <summary>
        /// 刷新文档全体元素列表,将所有的文本类型元素添加到元素列表中
        /// </summary>
        public void RefreshElements(bool FixNative)
        {
            //myElements.Clear(); //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
            //editingAreaElements[1].Clear(); //add by myc 2014-07-03 添加原因：新版页眉二期改版之清除文档正文区域的所有文本类型元素
            if (RootDocumentElement != null)
            {
                //RootDocumentElement.AddElementToList(myElements, true); //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
                //RootDocumentElement.AddElementToList(editingAreaElements[1], true); //add by myc 2014-07-03 添加原因：新版页眉二期改版之保存文档正文区域的所有文本类型元素
                (RootDocumentElement as ZYTextDiv).InnerElements.Clear();
                RootDocumentElement.AddElementToList((RootDocumentElement as ZYTextDiv).InnerElements, true); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要

                //if (FixNative)
                //FixForNative(myElements);
                int index = 0;

                //foreach (ZYTextElement myElement in myElements) //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
                //foreach (ZYTextElement myElement in editingAreaElements[1]) //add by myc 2014-07-03 添加原因：新版页眉二期改版之保存文档正文区域的所有文本类型元素
                foreach (ZYTextElement myElement in (RootDocumentElement as ZYTextDiv).InnerElements) //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
                {
                    myElement.Visible = true;
                    myElement.Index = index;
                    index++;
                }

                editingAreaElements[1] = (RootDocumentElement as ZYTextDiv).InnerElements; //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要

                myContent.AutoClearSelection = true;
                myContent.MoveSelectStart(myContent.SelectStart);
                myContainters.Clear();
                //SetContainers(myDocumentElement);
                //myAllElement = null;
            }
        }

        /// <summary>
        /// 对全部文档重新进行排布和分行,并进行分页处理
        /// </summary>
        /// <returns></returns>
        public bool RefreshLine()
        {
            //myPages.UpdatePageSettings();
            //myLines.Clear(); //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
            //editingAreaLines[1].Clear(); //add by myc 2014-07-03 添加原因：新版页眉二期改版之清除文档正文区域的所有文本行对象
            (RootDocumentElement as ZYTextDiv).InnerLines.Clear(); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要

            //this.UpdatePageSetting(); //add by myc 2014-07-08 注释原因：新版页眉二期改版（新版页脚）无须设置页眉和页脚高度，后续由程序内部自适应准确计算
            if (RootDocumentElement != null)
            {
                RootDocumentElement.RefreshLine();

                editingAreaLines[1] = (RootDocumentElement as ZYTextDiv).InnerLines; //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要

                RefreshPages();
                if (this.myOwnerControl != null)
                {
                    this.myOwnerControl.UpdatePages();
                }
                this.ElementsDirty = false;
            }
            return true;
        }


        /// <summary>
        /// 重新进行分页
        /// </summary>
        public void RefreshPages()
        {
            #region add by myc 2014-07-01 添加原因：新版页眉二期改版之初始化页眉区域根元素列表
            if (!showHeader) //页眉模板不显示文档页眉页脚
            {
                RootDocumentElementsInHeader.Clear();
                RootDocumentElementsInFooter.Clear();
            }
            else
            {
                if (RootDocumentElementsInHeader.Count == 0) //对应编辑器初始化时的页眉区域构建
                {
                    XmlDocument headerDocument = new XmlDocument();
                    string str = @"<header><p align='2'><span fontname='宋体' fontsize='14'>医院名称</span><eof /></p>
                                                   <p align='2'><span fontname='宋体' fontsize='14' fontbold='1'>子标题</span><eof /></p>
                                                   <p align='4'><span fontname='宋体' fontsize='14'>姓名：</span><macro fontname='宋体' fontsize='14' type='macro' name='姓名'>姓名</macro><span fontname='宋体' fontsize='14'>　　性别：</span><macro fontname='宋体' fontsize='14' type='macro' name='性别'>性别</macro><span fontname='宋体' fontsize='14'>　　年龄：</span><macro fontname='宋体' fontsize='14' type='macro' name='年龄'>年龄</macro><span fontname='宋体' fontsize='14'>　　民族：</span><macro fontname='宋体' fontsize='14' type='macro' name='民族'>民族</macro><eof /></p><p align='0'><horizontalLine type='' name='水平线' lineHeight='2' percent='100' /><eof /></p>
                                           </header>";
                    headerDocument.LoadXml(str);
                    if (headerDocument.DocumentElement != null)
                    {
                        //添加至页眉区域的文档根元素列表
                        ZYDocumentHeader RootHeaderDocumentElement = this.CreateElementByXML(headerDocument.DocumentElement as System.Xml.XmlElement) as ZYDocumentHeader;
                        if (RootHeaderDocumentElement != null)
                        {
                            RootDocumentElementsInHeader.Add(RootHeaderDocumentElement);
                        }
                    }
                }
            }
            #endregion

            #region add by myc 2014-07-07 添加原因：新版页脚改版之初始化页脚区域根元素列表
            if (!showFooter) //页脚模板不显示文档页眉页脚
            {
                RootDocumentElementsInHeader.Clear();
                RootDocumentElementsInFooter.Clear();
            }
            else
            {
                if (RootDocumentElementsInFooter.Count == 0) //对应编辑器初始化时的页脚区域构建
                {
                    XmlDocument footerDocument = new XmlDocument();
                    string str = @"<footer><p><horizontalLine lineHeight='1'></horizontalLine><eof /></p>
                                   <p align='2'><span fontname='宋体' fontsize='10' >第[%pageindex%]页 / 共[%pagecount%]页</span><eof /></p>
                                   </footer>";
                    footerDocument.LoadXml(str);
                    if (footerDocument.DocumentElement != null)
                    {
                        //构建页脚区域的文档根元素
                        ZYDocumentFooter RootFooterDocumentElement = this.CreateElementByXML(footerDocument.DocumentElement as System.Xml.XmlElement) as ZYDocumentFooter;
                        if (RootFooterDocumentElement != null)
                        {
                            //添加至页脚区域的文档根元素列表
                            RootDocumentElementsInFooter.Add(RootFooterDocumentElement);
                        }
                    }
                }
            }
            #endregion

            myPages.Clear();
            myPages.DocumentHeight = RootDocumentElement.Height;
            //myPages.Reset( g );
            //myPages.HeadHeight = this.HeadHeight; //add by myc 2014-06-30 注释原因：新版页眉二期改版需要
            //myPages.FooterHeight = this.FooterHeight; //add by myc 2014-07-07 注释原因：新版页脚需要

            myPages.Top = 0; //this.Top + this.HeadHeight ;

            int BodyHeight = RootDocumentElement.Height;
            int LastPos = myPages.Top;
            myPages.MinPageHeight = 15;

            GetConfigPageHeightInYiChan(); //add by myc 2014-08-29 宜昌中心人民医院页眉Xml错误解析（空白高度）


            ClearSplitRectsInCell(); //add by myc 2014-09-17 表格跨页第三次改版需要

            while (myPages.Height < BodyHeight)
            {
                PrintPage page = myPages.NewPage();
                PageLineInfo info = new PageLineInfo(
                    myPages.Top,
                    LastPos,
                    page.Bottom,
                    myPages.Count);
                info.MinPageHeight = myPages.MinPageHeight;
                //this.FixPageLine(info); //add by myc 2014-08-05 注释原因：已采用表格跨页第二次改版处理例程

                //add by myc 2014-08-26 添加原因：处理宜昌中心医院页眉区与正文间隔空白高度问题
                if (!isConfigHeaderHeightInYiChan)
                {
                    if (isConfigSpecialPagingInDongShi) //myc 2014-10-14 东石医院特殊换页标志
                    {
                        this.FixPageLine(info); //纯文档行换页模式
                    }
                    else
                    {
                        this.FixPageLineSecondEditon(info); //2014-08-05 myc 表格跨页第二次改版处理例程入口点 
                        //this.FixPageLineThirdEditon(info); //2014-09-15 myc 表格跨页第三次改版处理例程入口点
                    }
                }
                else
                {
                    if (myPages.Count == ConfigPageHeightInYiChan.Count)
                    {
                        isConfigHeaderHeightInYiChan = false;
                    }
                }

                page.Height = info.Pos - page.Top;
                if (page.Height < myPages.MinPageHeight)
                    page.Height = myPages.StandardHeight;
                LastPos = page.Bottom;
                myPages.Add(page);
            }//while
            if (myPages.Count > 0)
            {
                //myPages.LastPage.Height =
                //    myPages.LastPage.Height - (myPages.Height - BodyHeight); //add by myc 2014-08-01 注释原因：这句代码将导致最后一页的页高永远只是最后一页文档实际内容高度，但对于拖拽表格坐标系空间明显不够

                #region add by myc 2014-07-25 添加原因：页眉、正文和页脚统一管理下的校正页眉根元素列表和页脚根元素列表与页面集合数量同步——>针对删除一个文档页
                if (RootDocumentElementsInHeader.Count > myPages.Count)
                {
                    int delCount = RootDocumentElementsInHeader.Count - myPages.Count;
                    RootDocumentElementsInHeader.RemoveRange(myPages.Count, delCount);
                    RootDocumentElementsInFooter.RemoveRange(myPages.Count, delCount);
                    this.CorrectPageNumberInFooter(true);
                }
                #endregion
                this.CorrectPageNumberInFooter(false);
                editingAreaRootElements[1] = RootDocumentElement; //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
            }

            isImportXml = false; //add by myc 2014-09-17 表格跨页第三次改版需要

            //isConfigSpecialPagingInDongShi = false; //add by myc 2014-10-14 添加原因：分页完毕重置东石医院特殊换页标志为false
        }

        /// <summary>
        /// 重新计算文档元素的大小
        /// </summary>
        /// <returns>操作是否成功</returns>
        public bool RefreshSize()
        {
            if (RootDocumentElement != null)
            {
                RootDocumentElement.Left = 0;
                RootDocumentElement.Top = 0;
                RootDocumentElement.RefreshSize();
                //RootDocumentElement.RefreshLine(); mfb注释
                myView.Height = RootDocumentElement.Top + RootDocumentElement.Height;
            }
            return true;
        }

        #endregion
        /// <summary>
        /// 获得预览用的图片对象
        /// </summary>
        /// <returns>获得当前文档的BMP预览图片</returns>
        public System.Drawing.Bitmap GetPreViewImage()
        {
            return GetPreViewImage(0, 0);
        }

        /// <summary>
        /// 获得预览用的图片对象
        /// </summary>
        /// <param name="ImgWidth">指定的输出图像的宽度,若小于等于0则自动设置图像宽度</param>
        /// <param name="ImgHeight">指定的输出图像的高度,若小于等于0则自动设置图像宽度</param>
        /// <returns>获得当前文档的BMP预览图片</returns>
        public System.Drawing.Bitmap GetPreViewImage(int ImgWidth, int ImgHeight)
        {
            bool bolFlag = myInfo.ShowParagraphFlag;
            myInfo.ShowParagraphFlag = false;
            myInfo.Printing = true;
            System.Drawing.Bitmap mybmp = myView.GetBitmap(new BoolNoParameterHandler(RefreshSize), new BoolNoParameterHandler(DrawAll), ImgWidth, ImgHeight);
            myInfo.ShowParagraphFlag = bolFlag;
            myInfo.Printing = false;
            return mybmp;
        }

        ///// <summary>
        ///// 获得指定页码的预览图片
        ///// </summary>
        ///// <param name="PageIndex">从1开始的页码</param>
        ///// <returns>该页码的预览图片</returns>
        //public System.Drawing.Bitmap GetPreViewImage(int PageIndex)
        //{
        //    DocumentPageDrawer drawer = new DocumentPageDrawer();
        //    drawer.Document = this;
        //    drawer.Pages = this.Pages;
        //    bool bolFlag = myInfo.ShowParagraphFlag;
        //    myInfo.ShowParagraphFlag = false;
        //    myInfo.Printing = true;
        //    System.Drawing.Bitmap bmp = drawer.GetPageBmp(PageIndex, false);
        //    myInfo.ShowParagraphFlag = bolFlag;
        //    myInfo.Printing = false;

        //    return bmp;
        //}

        ///// <summary>
        ///// 显示弹出式项目列表并返回选中项目的序号
        ///// </summary>
        ///// <param name="items">项目列表的内容</param>
        ///// <param name="bolMulitSelect">是否多选</param>
        ///// <returns>用户选中的项目的从0开始的序号，－1表示没有选中</returns>
        //public int ShowPopupList(int x, int y, int height, object[] items, string strDefaultText)
        //{
        //    if (CheckKBLoaded() == false) return -1;
        //    return myOwnerControl.ShowPopupList(x, y, height, items, strDefaultText);
        //}

        ///// <summary>
        ///// 显示弹出式知识库列表并返回选中的知识库项目
        ///// </summary>
        ///// <param name="myElement">元素</param>
        ///// <returns>用户选择的知识库项目的集合</returns>
        ///// <seealso>ZYTextDocumentLib.ZYEditorControl.ShowKBPopupList</seealso>
        //public object ShowKBPopupList(ZYTextElement myElement)
        //{
        //    if (CheckKBLoaded() == false) return null;
        //    object obj = myOwnerControl.ShowKBPopupList(myElement);
        //    if (myOwnerControl != null)
        //        myOwnerControl.HidePopupList();
        //    return obj;
        //}

        /// <summary>
        /// 绘制新增的元素的背景色,目前为Windows提示文本背景色,一般为淡黄色
        /// </summary>
        /// <param name="intLevel">元素的显示层次</param>
        /// <param name="vLeft">元素左端位置</param>
        /// <param name="vTop">元素顶端位置</param>
        /// <param name="vWidth">元素宽度</param>
        /// <param name="vHeight">元素高度</param>
        public void DrawNewBackGround(int intLevel, int vLeft, int vTop, int vWidth, int vHeight)
        {
            if (myInfo.ShowMark == false) return;
            switch (intLevel)
            {
                case 0:
                    myView.FillRectangle(System.Drawing.SystemColors.Info, vLeft, vTop, vWidth, vHeight);
                    break;
                case 1:
                    myView.FillRectangle(System.Drawing.SystemColors.Info, vLeft, vTop, vWidth, vHeight);
                    myView.DrawLine(System.Drawing.SystemColors.Highlight, vLeft, vTop + vHeight - 1, vLeft + vWidth, vTop + vHeight - 1);
                    break;
                default:
                    myView.FillRectangle(System.Drawing.SystemColors.Info, vLeft, vTop, vWidth, vHeight);
                    myView.DrawLine(System.Drawing.SystemColors.Highlight, vLeft, vTop + vHeight - 1, vLeft + vWidth, vTop + vHeight - 1);
                    myView.DrawLine(System.Drawing.SystemColors.Highlight, vLeft, vTop + vHeight - 3, vLeft + vWidth, vTop + vHeight - 3);
                    break;
            }
        }

        public void DrawUnderLine(int intLevel, int vLeft, int vTop, int vWidth, int vHeight)
        {
            if (myInfo.ShowMark == false) return;
            switch (intLevel)
            {
                case 0:
                    break;
                case 1:
                    myView.DrawLine(System.Drawing.Color.Red, vLeft, vTop + vHeight - 5, vLeft + vWidth, vTop + vHeight - 5);
                    break;
                case 2:
                    //myView.DrawLine(System.Drawing.SystemColors.Highlight, vLeft, vTop + vHeight - 1, vLeft + vWidth, vTop + vHeight - 1);
                    //myView.DrawLine(System.Drawing.SystemColors.Highlight, vLeft, vTop + vHeight - 3, vLeft + vWidth, vTop + vHeight - 3);
                    myView.DrawDoubleUnderLine(vLeft, vTop, vWidth, vHeight);
                    break;
            }
        }






        /// <summary>
        /// 绘制被逻辑删除的元素的删除线
        /// </summary>
        /// <param name="intLevel">元素的显示层次</param>
        /// <param name="vLeft">元素左端位置</param>
        /// <param name="vTop">元素顶端位置</param>
        /// <param name="vWidth">元素宽度</param>
        /// <param name="vHeight">元素高度</param>
        /// <seealso>ZYCommon.DocumentView.DrawDeleteLine</seealso>
        public void DrawDeleteLine(int intLevel, int vLeft, int vTop, int vWidth, int vHeight)
        {
            if (myInfo.ShowMark == false) return;
            //System.Drawing.Rectangle rect = new System.Drawing.Rectangle( vLeft , vTop , vWidth , vHeight );
            myView.DrawDeleteLine(vLeft, vTop, vWidth, vHeight, (intLevel <= 1 ? 1 : 2));
        }

        #endregion

        #region 实现 IEMRViewDocument 成员,以便向用户界面负责 *************************************

        /// <summary>
        /// 定时器处理
        /// </summary>
        /// <returns>是否进行了处理</returns>
        public bool ViewTimer()
        {
            if (bolLastContentChangedFlag)
            {
                bolLastContentChangedFlag = false;
                //ZYEditorAction a = this.GetActionByName("contentchanged");
                ZYEditorAction a = new A_ContentChanged();
                if (a != null && a.isEnable())
                {
                    a.Execute();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 绘制页眉
        /// </summary>
        /// <param name="g"></param>
        /// <param name="ClipRectangle"></param>
        public void DrawHead(System.Drawing.Graphics g, System.Drawing.Rectangle ClipRectangle)
        {
            try
            {
                #region add by myc 2014-06-26 注释原因：页眉绘制将采用新版页眉二期改版方式
                ////DrawExtString(this.RuntimeHeadString, g, ClipRectangle);

                ////xll 2014-05-21
                //if (this.RuntimeHeadString.Length <= 0) return;
                //if (this.RuntimeHeadString.Contains("sx_flag"))
                //{
                // DrawMacroAndText(this.RuntimeHeadString, g, ClipRectangle);
                //}
                //else
                //{
                //    DrawExtString(this.RuntimeHeadString, g, ClipRectangle);
                //} 
                #endregion

                #region add by myc 2014-06-26 添加原因：新版页眉二期改版与文档正文统一绘制方式
                myView.ViewRect = ClipRectangle;
                Graphics gBack = myView.GetInnerGraph();
                myView.Graph = g;

                if (RootDocumentElementsInHeader != null && RootDocumentElementsInHeader.Count > 0)
                {
                    for (int i = 0; i < RootDocumentElementsInHeader.Count; i++)
                    {
                        ZYTextContainer RootHeaderDocumentElement = RootDocumentElementsInHeader[i] as ZYTextContainer;
                        if (RootHeaderDocumentElement.Top >= ClipRectangle.Top
                            && RootHeaderDocumentElement.Top + RootHeaderDocumentElement.Height <= ClipRectangle.Bottom)
                        {
                            RootHeaderDocumentElement.RefreshView();
                        }
                    }
                }

                //if (CurrentEditingArea == 0) //写在这里会有延迟，必须等到触发重绘事件时才能绘制页眉区域编辑框，所在要在ZYEditorControl.OnDoubleClick中加入this.Invalidate()发送重绘消息
                if (editingAreaFlag == 0) //写在这里会有延迟，必须等到触发重绘事件时才能绘制页眉区域编辑框，所在要在ZYEditorControl.OnDoubleClick中加入this.Invalidate()发送重绘消息
                {
                    Pen pen = new Pen(Color.Red);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; //由线段组成的直线
                    myView.Graph.DrawRectangle(pen, ClipRectangle);
                    SizeF strSize = myView.Graph.MeasureString("页眉", new Font("宋体", 10.5f), Int32.MaxValue, new StringFormat(StringFormat.GenericTypographic));
                    myView.Graph.DrawString("页眉", new Font("宋体", 10.5f), new SolidBrush(Color.Red), ClipRectangle.Left - (int)strSize.Width - 5, ClipRectangle.Top + 5);
                }

                myView.Graph = gBack;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // DrawExtString(this.RuntimeHeadString, g, ClipRectangle);
        }

        #region add by myc 2014-06-26 添加原因：新版页眉二期改版需要
        /// <summary>
        /// 标志用户是否正在编辑文档页眉。
        /// </summary>
        public static bool IsEditingDocumentHeader = false;

        /// <summary>
        /// 递归设置结构化元素显示属性Visible为true，以便于重新分行时准确计算单元格的新高度。
        /// </summary>
        /// <param name="element">指定的结构化元素。</param>
        /// <returns></returns>
        private bool SetElementsVisble(ZYTextElement element)
        {
            try
            {
                if (element is ZYTextContainer)
                {
                    ZYTextContainer myContainer = element as ZYTextContainer;
                    foreach (ZYTextElement myEle in myContainer.ChildElements)
                    {
                        if (SetElementsVisble(myEle)) continue;
                    }
                    return true;
                }
                else
                {
                    element.Visible = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// 绘制页脚
        /// </summary>
        /// <param name="g"></param>
        /// <param name="ClipRectangle"></param>
        public void DrawFooter(System.Drawing.Graphics g, System.Drawing.Rectangle ClipRectangle)
        {
            //MessageBox.Show("绘制页脚" + this.RuntimeFooterString);
            //DrawExtString(this.RuntimeFooterString, g, ClipRectangle); //add by myc 2014-07-07 注释原因：页脚绘制将采用新版页脚方式
            //Rectangle rect = new Rectangle(0,0,ClipRectangle.Width,ClipRectangle.Height);
            //DrawExtString(this.RuntimeFooterString, g, rect);

            #region add by myc 2014-07-07 添加原因：新版页脚与文档正文统一绘制方式
            myView.ViewRect = ClipRectangle;
            Graphics gBack = myView.GetInnerGraph();
            myView.Graph = g;

            if (RootDocumentElementsInFooter != null && RootDocumentElementsInFooter.Count > 0)
            {
                for (int i = 0; i < RootDocumentElementsInFooter.Count; i++)
                {
                    ZYTextContainer RootFooterDocumentElement = RootDocumentElementsInFooter[i] as ZYTextContainer;
                    if (RootFooterDocumentElement.Top >= ClipRectangle.Top
                        && RootFooterDocumentElement.Top + RootFooterDocumentElement.Height <= ClipRectangle.Bottom)
                    {
                        RootFooterDocumentElement.RefreshView();
                    }
                }
            }

            //if (CurrentEditingArea == 2) //写在这里会有延迟，必须等到触发重绘事件时才能绘制页脚区域编辑框，所在要在ZYEditorControl.OnDoubleClick中加入this.Invalidate()发送重绘消息
            if (editingAreaFlag == 2) //写在这里会有延迟，必须等到触发重绘事件时才能绘制页脚区域编辑框，所在要在ZYEditorControl.OnDoubleClick中加入this.Invalidate()发送重绘消息
            {
                Pen pen = new Pen(Color.Red);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; //由线段组成的直线
                myView.Graph.DrawRectangle(pen, ClipRectangle);
                SizeF strSize = myView.Graph.MeasureString("页脚", new Font("宋体", 10.5f), Int32.MaxValue, new StringFormat(StringFormat.GenericTypographic));
                myView.Graph.DrawString("页脚", new Font("宋体", 10.5f), new SolidBrush(Color.Red), ClipRectangle.Left - (int)strSize.Width - 5, ClipRectangle.Top + 5);
            }

            myView.Graph = gBack;
            #endregion
        }

        //绘制页眉页脚时用此方法
        private void DrawExtString(string txt, System.Drawing.Graphics g, System.Drawing.Rectangle ClipRectangle)
        {
            //Debug.WriteLine("页眉页脚字符串 "+txt);
            if (txt.Length == 0)
            {
                return;
            }

            System.Drawing.Font DefaultFont = System.Windows.Forms.Control.DefaultFont;
            //if (txt.IndexOf("<") == -1 || txt.IndexOf(">") == -1)
            //{
            //    using (System.Drawing.StringFormat format = new System.Drawing.StringFormat())
            //    {
            //        format.Alignment = System.Drawing.StringAlignment.Near;
            //        format.LineAlignment = System.Drawing.StringAlignment.Near;
            //        g.DrawString(txt, DefaultFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(ClipRectangle.Left, ClipRectangle.Top, ClipRectangle.Width, ClipRectangle.Height), format);
            //    }
            //    return;
            //}
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(txt);

            bool header = true;
            XmlNodeList nodes = doc.SelectNodes("header/p");
            if (nodes.Count == 0)
            {
                //Debug.WriteLine("画页脚");
                nodes = doc.SelectNodes("footer/p");
                header = false;
            }
            int TopCount = ClipRectangle.Top;
            using (System.Drawing.StringFormat format = new System.Drawing.StringFormat())
            {
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                format.FormatFlags = System.Drawing.StringFormatFlags.NoWrap | StringFormatFlags.MeasureTrailingSpaces;
                bool resetName = false;
                int lineIndex = 0;
                float maxWidth = 0f;//存储页眉中最长字符串的宽度
                float maxX = 0f;
                foreach (System.Xml.XmlNode node in nodes)//doc.DocumentElement.ChildNodes)
                {
                    lineIndex++;
                    if (node is System.Xml.XmlElement)
                    {
                        System.Xml.XmlElement element = (System.Xml.XmlElement)node;

                        //if (element.Name == "line")
                        XmlElement realnode = element.SelectSingleNode("horizontalLine") as XmlElement;
                        //是水平线节点
                        if (realnode != null)
                        {
                            using (System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black))
                            {
                                if (realnode.HasAttribute("lineHeight")) ;//("thick"))
                                pen.Width = Convert.ToInt32(realnode.GetAttribute("lineHeight"));
                                #region bwy : 是否显示页眉线，如不显示，用页面背景色画线

                                if (doc.DocumentElement.Name == "header" && !this.ShowHeaderLine)
                                {
                                    pen.Color = this.OwnerControl.PageBackColor;
                                }

                                if (doc.DocumentElement.Name == "footer" && !this.ShowFooterLine)
                                {
                                    pen.Color = this.OwnerControl.PageBackColor;
                                }

                                #endregion bwy :

                                g.DrawLine(pen, ClipRectangle.Left, TopCount, ClipRectangle.Right, TopCount);
                                TopCount = TopCount + (int)pen.Width + 20;
                            }
                        }
                        //不是水平线节点
                        else //if (element.Name == "text")
                        {
                            XmlElement span = element.SelectSingleNode("span") as XmlElement;

                            if (span == null)
                            {
                                continue;
                            }


                            string FontName = DefaultFont.Name;
                            if (span.HasAttribute("fontname"))
                                FontName = span.GetAttribute("fontname");
                            float FontSize = (float)DefaultFont.Size;
                            if (span.HasAttribute("fontsize"))
                                FontSize = float.Parse(span.GetAttribute("fontsize"));
                            System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular;
                            if (span.HasAttribute("fontbold"))
                                style = style | System.Drawing.FontStyle.Bold;
                            if (span.HasAttribute("fontitalic"))
                                style = style | System.Drawing.FontStyle.Italic;
                            if (span.HasAttribute("fontunderline"))
                                style = style | System.Drawing.FontStyle.Underline;

                            format.Alignment = System.Drawing.StringAlignment.Near;
                            if (element.HasAttribute("align") && Convert.ToInt32(element.GetAttribute("align")) == 1)
                                format.Alignment = System.Drawing.StringAlignment.Near;
                            if (element.HasAttribute("align") && Convert.ToInt32(element.GetAttribute("align")) == 2)
                                format.Alignment = System.Drawing.StringAlignment.Center;
                            if (element.HasAttribute("align") && Convert.ToInt32(element.GetAttribute("align")) == 3)
                                format.Alignment = System.Drawing.StringAlignment.Far;

                            SolidBrush brush = new SolidBrush(Color.Black);
                            if (span.HasAttribute("forecolor"))
                            {
                                System.Drawing.ColorConverter a = new System.Drawing.ColorConverter();
                                System.Drawing.Color c = (System.Drawing.Color)a.ConvertFromString(span.GetAttribute("forecolor"));
                                brush.Color = c;
                            }
                            //using (System.Drawing.Font font = new System.Drawing.Font(FontName, FontSize, style))
                            //{
                            Font font = new System.Drawing.Font(FontName, FontSize, style);
                            float h = g.MeasureString("#", font, 10000, format).Height + 10;
                            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(ClipRectangle.Left, TopCount, ClipRectangle.Width, h);
                            if (rect.Bottom > ClipRectangle.Bottom)
                                break;
                            string txt2 = element.InnerText;

                            if (header && !resetName)
                            {
                                if (this.Info.DocumentModel != DocumentModel.Test)
                                {
                                    //txt2 = "秦皇岛市第二医院                      ";//此处 要30个符号位置，字母、汉字都算一个
                                    txt2 = span.InnerText;//此处 要30个符号位置，字母、汉字都算一个
                                    txt2 = txt2.Trim();
                                }
                                resetName = true;
                            }

                            if (txt2 != null && txt2.Length > 0)
                            {
                                //如果是个人信息，那么分散对齐false)
                                if (lineIndex == 3)
                                //if(false)
                                {
                                    //把字符串以空格分割成数组,  姓名：姓名　　性别：性别　　年龄：年龄　　民族：民族
                                    //txt2 = txt2.Replace("\r\n","");
                                    string[] parts = txt2.Trim().Split(new char[] { ' ', ' ', '　', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    List<Size> elesize = new List<Size>();
                                    List<Rectangle> elebounds = new List<Rectangle>();

                                    //总长度
                                    int length = 0;

                                    //如果内容总长度大于页面宽度，那么缩小字体大小，以显示全部内容
                                    while ((length = GetTotalWidth(parts, g, font, format, elesize)) > this.Pages.StandardWidth)
                                    {
                                        font = new Font(font.FontFamily.Name, font.Size - 0.5f, font.Style);
                                    }
                                    //如果内容总长度小于页面宽度，那么计算要插入的空白
                                    int space = this.Pages.StandardWidth - length;
                                    if (parts.Length > 1)
                                    {
                                        space = space / (parts.Length - 1);
                                    }
                                    //修正所有元素的左边界
                                    int curleft = (int)rect.Left;
                                    for (int k = 0; k < elesize.Count; k++)
                                    {
                                        curleft = curleft + (k == 0 ? 0 : space);
                                        Rectangle r = new Rectangle(curleft, (int)rect.Y, elesize[k].Width + 5, elesize[k].Height + 5);
                                        elebounds.Add(r);
                                        curleft = curleft + elesize[k].Width;
                                    }

                                    //画各部分
                                    for (int k = 0; k < elebounds.Count; k++)
                                    {
                                        g.DrawString(parts[k], font, brush, elebounds[k], format);
                                        //g.DrawString(txt2, font, brush, rect, format);
                                    }


                                }
                                else
                                {
                                    //g.DrawString(txt2, font, brush, rect, format); //add by myc 2014-07-01 注释原因：txt2中包含回车换行符时没处理
                                    g.DrawString(span.InnerText, font, brush, rect, format); //add by myc 2014-07-01 添加原因：txt2中包含回车换行符时处理
                                }
                            }

                            TopCount += (int)Math.Ceiling(h);


                            if (element.InnerXml.IndexOf("<macro") >= 0) //存在<macro>节点 跳过
                            {
                                continue;
                            }
                            float _width = g.MeasureString(element.InnerText, font).Width;
                            maxWidth = maxWidth < _width ? _width : maxWidth;
                            maxX = (rect.Width - maxWidth) / 2;

                            //}//using font
                        }
                    }
                }
                //若用AutoUpdate程序运行此处，将调取不到XML及LOGO图片
                //edit by ywk 2013年2月5日13:24:22 修改
                string currentsoftpath = System.AppDomain.CurrentDomain.BaseDirectory;
                //绘制医院logo edit by tj 2012-11-5
                //if (File.Exists("HospitalLogo.xml"))
                if (File.Exists(currentsoftpath + "\\HospitalLogo.xml"))
                {
                    XmlDocument _doc = new XmlDocument();
                    _doc.Load(currentsoftpath + "\\HospitalLogo.xml");
                    XmlNode node = _doc.GetElementsByTagName("Image")[0];

                    if (node != null)
                    {
                        //edit by ywk 路径修改 2013年2月5日13:42:46 
                        if (File.Exists(currentsoftpath + node.Attributes["src"].Value))
                        {
                            float curX = float.Parse(node.Attributes["x"].Value.ToString() == "" ? "0.00" : node.Attributes["x"].Value);
                            if (node.Attributes["align"].Value.ToLower() == "center")
                            {
                                curX = maxX - float.Parse(node.Attributes["w"].Value.ToString() == "" ? "0" : node.Attributes["w"].Value.ToString());
                            }
                            //edit by ywk 路径修改 2013年2月5日13:42:46 
                            g.DrawImage(Image.FromFile(currentsoftpath + node.Attributes["src"].Value),
                               curX,
                                float.Parse(node.Attributes["y"].Value.ToString() == "" ? "0.00" : node.Attributes["y"].Value),
                                float.Parse(node.Attributes["w"].Value.ToString() == "" ? "0.00" : node.Attributes["w"].Value),
                                float.Parse(node.Attributes["h"].Value.ToString() == "" ? "0.00" : node.Attributes["h"].Value)
                               );
                        }
                    }
                }
                //-----------------------------------------------------
            }
        }
        /// <summary>
        /// 测量各部分长度
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="format"></param>
        /// <param name="elesize"></param>
        /// <returns></returns>
        int GetTotalWidth(string[] parts, Graphics g, Font font, StringFormat format, List<Size> elesize)
        {
            elesize.Clear();
            //总长度
            int length = 0;
            //测量各部分长度
            foreach (string str in parts)
            {
                SizeF sf = g.MeasureString(str, font, 10000, format);
                Size s = new Size((int)sf.Width, (int)sf.Height);
                elesize.Add(s);
                length += s.Width;
            }

            return length;
        }
        /// <summary>
        /// 绘制文档
        /// </summary>
        /// <param name="g"></param>
        /// <param name="ClipRectangle"></param>
        public void DrawDocument(System.Drawing.Graphics g, System.Drawing.Rectangle ClipRectangle)
        {
            myView.ViewRect = ClipRectangle;

            //add by myc 2014-06-05 添加原因：表格跨页时，最后一页的文档视图对象的绘图（矩形）区域需要更正
            if (this.PageIndex == this.Pages.Count - 1)
            {
                this.View.ViewRect = new Rectangle(this.View.ViewRect.Left, this.View.ViewRect.Top, this.View.ViewRect.Width, this.View.ViewRect.Height + PageBodyHeightIncrement);
            }

            System.Drawing.Graphics gBack = myView.GetInnerGraph();
            myView.Graph = g;

            //InitEventObject(ZYVBEventType.Paint);
            if (RootDocumentElement != null)
            {
                RootDocumentElement.RefreshView();
            }
            //			if(myInfo.ShowPageLine && myOwnerControl != null && myOwnerControl.PageViewMode == false)
            //			{
            //				// 绘制分页线
            //				using(System.Drawing.Pen myPen = new System.Drawing.Pen( System.Drawing.Color.Gray ,1))
            //				{
            //					myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot ;
            //					foreach(PrintPage myPage in myPages)
            //					{
            //						if( myPage.Bottom >= ClipRectangle.Top && myPage.Bottom <= ClipRectangle.Bottom )
            //						{
            //							g.DrawLine( myPen , ClipRectangle.Left , myPage.Bottom , ClipRectangle.Right , myPage.Bottom );
            //						}
            //					}
            //				}
            //			}

            //if (!bigRect.IsEmpty)
            //{
            //    g.DrawRectangle(new Pen(Color.Red), bigRect);
            //}

            myView.Graph = gBack;
        }

        /// <summary>
        /// 实现<link>ZYCommon.IEMRViewDocument.ViewPaint</link>接口,重新绘制文档的一部分
        /// </summary>
        /// <remarks>本函数设置当前无效矩形,并重新绘制文档,若编辑控件不是分页模式则绘制分页线</remarks>
        /// <param name="g">用于绘制的图形操作对象</param>
        /// <param name="ClipRect">包含文档中需要绘制的区域的矩形</param>
        /// <returns>操作是否成功</returns>
        public bool ViewPaint(System.Drawing.Graphics g, System.Drawing.Rectangle ClipRect)
        {
            myView.ViewRect = ClipRect;
            System.Drawing.Graphics gBack = myView.GetInnerGraph();
            myView.Graph = g;
            //InitEventObject(ZYVBEventType.Paint);
            if (RootDocumentElement != null)
            {
                RootDocumentElement.RefreshView();
            }
            //			if(myInfo.ShowPageLine && myOwnerControl != null && myOwnerControl.PageViewMode == false)
            //			{
            //				// 绘制分页线
            //				using(System.Drawing.Pen myPen = new System.Drawing.Pen( System.Drawing.Color.Gray ,1))
            //				{
            //					myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot ;
            //					foreach(PrintPage myPage in myPages)
            //					{
            //						if( myPage.Bottom >= ClipRect.Top && myPage.Bottom <= ClipRect.Bottom)
            //						{
            //							g.DrawLine( myPen , ClipRect.Left , myPage.Bottom  , ClipRect.Right , myPage.Bottom  );
            //						}
            //					}
            //				}
            //			}
            myView.Graph = gBack;
            return true;
        }

        /// <summary>
        /// 实现 <link>ZYCommon.IEMRViewDocument.ViewMouseDown</link> 接口,鼠标按键按下事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>操作是否成功</returns>
        public bool ViewMouseDown(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            //InitEventObject(ZYVBEventType.MouseDown);

            if (Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (myContent.SelectLength == 0)
                {
                    myContent.AutoClearSelection = true;
                    myContent.MoveToNoSelectingArea(x, y);
                }
                //return true;不能返回，否则 不能执行光标修正操作
            }

            //if (RootDocumentElement != null && Button == System.Windows.Forms.MouseButtons.Left) //add by myc 2014-07-24 注释原因：页眉、正文和页脚统一管理需要
            if (HBFDocumentElement != null && Button == System.Windows.Forms.MouseButtons.Left) //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
            {
                //if (RootDocumentElement.HandleMouseDown(x, y, Button)) //add by myc 2014-07-24 注释原因：页眉、正文和页脚统一管理需要
                if (HBFDocumentElement.HandleMouseDown(x, y, Button)) //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
                {
                    //myOwnerControl.CaptureMouse = false; //add by myc 2014-06-04 注释原因：谁说了鼠标按下事件中能将鼠标捕捉标志重置为false，你能拖选单元格还怎么处理，应该只能由鼠标释放事件重置此标志才对
                    //return true;不能返回，否则 不能执行光标修正操作
                }
            }

            myContent.AutoClearSelection = !myOwnerControl.HasShiftPressing();

            #region bwy:
            #region add by myc 2014-06-23 注释原因：鼠标拖选ZYTextBlock与ZYElement类型元素应该支持正反双向拖选
            ////如果当前字符在元素内，则光标应放在元素之前
            //ZYTextElement ele = this.GetElementByPos(x, y);
            //if (ele != null && ele.Parent is ZYTextBlock)
            //{
            //    myOwnerControl.CaptureMouse = false;
            //    x = ele.Parent.FirstElement.RealLeft;
            //    y = ele.Parent.FirstElement.RealTop;
            //}
            //if (ele is ZYElement)
            //{
            //    myOwnerControl.CaptureMouse = false;
            //    x = ele.RealLeft;
            //    y = ele.RealTop;
            //} 
            #endregion
            #endregion bwy:

            myContent.MoveToNoSelectingArea(x, y);

            myOwnerControl.UpdateTextCaret();
            myOwnerControl.UseAbsTransformPoint = true;
            return true;
        }

        /// <summary>
        /// 实现<link>ZYCommon.IEMRViewDocument.ViewMouseMove</link>接口,鼠标移动事件
        /// 2009-7-4 00:58 孟凡博改
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的Y坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>操作是否成功</returns>
        public bool ViewMouseMove(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            //Debug.WriteLine("◆◆◆◆" + RootDocumentElement.HandleMouseMove(x, y, Button).ToString() + "◆◆◆◆");
            //if (RootDocumentElement.HandleMouseMove(x, y, Button) == false) //add by myc 2014-07-24 注释原因：页眉、正文和页脚统一管理需要
            if (HBFDocumentElement != null && HBFDocumentElement.HandleMouseMove(x, y, Button) == false) //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要 edit by lhl 2015-06-30作非空判断
            {
                //Debug.WriteLine("◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆");
                //这里判断是否是划选,否则为普通的移动
                if (myOwnerControl.CaptureMouse)
                {
                    Debug.WriteLine("zytextdocument ViewMouseMove myOwnerControl.CaptureMouse=true ");
                    myContent.AutoClearSelection = false;

                    ZYTextElement ele = this.GetElementByPos(x, y);

                    //if (!(myCursor == Cursors.HSplit || myCursor == Cursors.VSplit))
                    //{
                    myContent.MoveToInSelectingArea(x, y);
                    //}

                    myOwnerControl.MoveCaretWithScroll = false;
                    myOwnerControl.MoveCaretWithScroll = true;
                    //myOwnerControl.Invalidate(); //2014-08-04 暂时处理交叉选定表格的特殊边界（从一个回车符反向选定表格内单元格开始）——>处理完表格鼠标移动事件之后再次重绘表格

                }
                else
                {
                    if (Button != System.Windows.Forms.MouseButtons.None)
                        return false;

                    myCursor = System.Windows.Forms.Cursors.IBeam;//bwy Default

                    if (myCurrentHoverElement != null)
                    {
                        if (Button != System.Windows.Forms.MouseButtons.None)
                            return false;

                        myCursor = System.Windows.Forms.Cursors.IBeam;//bwy Default

                        //RootDocumentElement.HandleMouseMove(x, y, Button);

                        if (myCurrentHoverElement != null)
                        {
                            if (myCurrentHoverElement is ZYTextContainer)
                            {
                                if ((myCurrentHoverElement as ZYTextContainer).Contains(x, y) == false)
                                    this.CurrentHoverElement = null;
                            }
                            else if (myCurrentHoverElement.Bounds.Contains(x, y) == false)
                            {
                                this.CurrentHoverElement = null;
                            }
                        }
                        myOwnerControl.SetCursor(myCursor);

                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 实现<link>ZYCommon.IEMRViewDocument.ViewMouseUp</link>接口,鼠标按键松开事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>操作是否成功</returns>
        public bool ViewMouseUp(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            myOwnerControl.UseAbsTransformPoint = false;
            //mfb 添加.2009-7-4 00:25
            myContent.AutoClearSelection = true;
            //RootDocumentElement.HandleMouseUp(x, y, Button); //add by myc 2014-07-24 注释原因：页眉、正文和页脚统一管理需要
            if (HBFDocumentElement != null)//add by lhl 2015-06-30 作非空判断
            {
                HBFDocumentElement.HandleMouseUp(x, y, Button); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
            }
            //InitEventObject(ZYVBEventType.MouseUp);
            return true;
        }

        /// <summary>
        /// 实现 <link>ZYCommon.IEMRViewDocument.ViewMouseClick</link> 接口,鼠标单击事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>操作是否成功</returns>
        public bool ViewMouseClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            //RootDocumentElement.HandleClick(x, y, Button); //add by myc 2014-07-24 注释原因：页眉、正文和页脚统一管理需要
            if (HBFDocumentElement != null)// edit by lhl 2015-06-30作非空判断
            {
                HBFDocumentElement.HandleClick(x, y, Button); //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要
            }
            return true;
        }

        /// <summary>
        /// 实现 <link>ZYCommon.IEMRViewDocument.ViewMouseDoubleClick</link> 接口,鼠标双击事件
        /// </summary>
        /// <param name="x">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="y">鼠标光标在文档视图区域中的X坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>操作是否成功</returns>
        public bool ViewMouseDoubleClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            //InitEventObject(ZYVBEventType.DblClick);
            //if (RootDocumentElement.HandleDblClick(x, y, Button) == false) //add by myc 2014-07-24 注释原因：页眉、正文和页脚统一管理需要
            if (HBFDocumentElement != null && HBFDocumentElement.HandleDblClick(x, y, Button) == false) //add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要 edit by lhl 2015-06-30 作非空判断
            {
                //Add by wwj 2013-05-29 解决在平板上使用，将单击操作模拟成双击操作时，会选中当前选中元素所在语句的问题
                if (this.myOwnerControl.IsSingleClickAsDoubleClick) return true;

                if (myContent.CurrentElement is ZYTextChar || myContent.PreElement is ZYTextChar)
                {
                    ZYTextChar myChar;
                    int NewStart = -1;
                    ZYTextContainer ctr = myContent.CurrentElement.Parent;
                    for (int index = (myContent.CurrentElement is ZYTextChar ? myContent.SelectStart : myContent.SelectStart - 1); index >= 0; index--)
                    {
                        //myChar = myElements[index] as ZYTextChar; //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
                        myChar = HBFElements[index] as ZYTextChar; //add by myc 2014-07-03 添加原因：新版页眉二期改版需要
                        if (myChar == null || char.IsLetter(myChar.Char) == false || myChar.Parent != ctr)
                        {
                            break;
                        }
                        NewStart = index;
                    }
                    if (NewStart >= 0)
                    {
                        //for (int index = NewStart; index < myElements.Count; index++) //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
                        for (int index = NewStart; index < HBFElements.Count; index++) //add by myc 2014-07-03 添加原因：新版页眉二期改版需要
                        {
                            //myChar = myElements[index] as ZYTextChar; //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
                            myChar = HBFElements[index] as ZYTextChar; //add by myc 2014-07-03 添加原因：新版页眉二期改版需要
                            if (myChar == null || char.IsLetter(myChar.Char) == false)
                            {
                                //myContent.SetSelection(index, NewStart - index); //add by myc 2014-07-24 注释原因：取消双击页眉或页脚导致的选定文本
                                break;
                            }
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 实现<link>ZYCommon.IEMRViewDocument.ViewMouseLeave</link>接口,鼠标离开文档对象
        /// </summary>
        public bool ViewMouseLeave()
        {
            //InitEventObject(ZYVBEventType.MouseLeave);
            this.CurrentHoverElement = null;
            return true;
        }
        /// <summary>
        /// 实现 <link>ZYCommon.IEMRViewDocument.ViewInsertModeChange</link> 接口,插入模式修改事件
        /// </summary>
        public void ViewInsertModeChange()
        {
            ZYTextElement myElement = myContent.CurrentElement;
            myOwnerControl.UpdateTextCaret();
        }

        #endregion

        #region ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅ 表格相关函数群 ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅

        /// <summary>
        /// mfb 插入一个表格.
        /// 列宽如果为0,则为自动列宽,则此时列宽是表格总宽度的平均值.
        /// </summary>
        /// <param name="header">表格名称</param>
        /// <param name="rows">行数</param>
        /// <param name="columns">列数</param>
        /// <param name="columnWidth">列宽(厘米)</param>
        public void TableInsert(string header, int rows, int columns, decimal columnWidth)
        {
            if (this.Info.DocumentModel == DocumentModel.Design || this.Info.DocumentModel == DocumentModel.Edit)
            {
                #region add by myc 2014-05-13 添加原因：插入表格时会检查表格是否越出编辑器边界，并给出精确的提示
                if (rows <= 0)
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("插入表格的行数必须大于0");
                    return;
                }
                else if (columns <= 0)
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("插入表格的列数必须大于0");
                    return;
                }


                //用来保存列宽
                int sColumn = 0;
                //如果有固定列宽,则转换为文档的单位
                if (0 != columnWidth)
                {
                    //将厘米单位的列宽转换为文档单位,然后再乘以列数,即为表格总宽
                    sColumn = (int)GraphicsUnitConvert.Convert((Convert.ToDouble(columnWidth * 10)), System.Drawing.GraphicsUnit.Millimeter, System.Drawing.GraphicsUnit.Document);
                }

                if (columnWidth == 0) //自动列宽
                {
                    int tempWidth = this.RootDocumentElement.Width / columns;
                    if (tempWidth < TPTextTable.MinCellWidth)
                    {
                        YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("当前允许插入表格的最大列数为：" + (this.RootDocumentElement.Width / TPTextTable.MinCellWidth).ToString() + "列");
                        return;
                    }
                }
                else //非自动列宽
                {
                    if (sColumn * columns > this.RootDocumentElement.Width)
                    {
                        double tempWidth = (double)this.RootDocumentElement.Width / columns;
                        double maxWidth = GraphicsUnitConvert.Convert(tempWidth / 10, System.Drawing.GraphicsUnit.Document, System.Drawing.GraphicsUnit.Millimeter);
                        YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("当前允许插入表格的最大列宽为：" + maxWidth.ToString() + "厘米");
                        return;
                    }
                }
                #endregion

                #region add by myc 2014-05-22 添加原因：当前表格内或结构化元素中部不允许再插入表格，后期可以修改此限制
                if (myContent.CurrentElement != null)
                {
                    if (myContent.CurrentElement.Parent.Parent is TPTextCell)
                    {
                        YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("当前光标位于一个表格中，不能再在此光标位置处插入新的表格");
                        return;
                    }
                    else //特别重要——>当前元素的父容器（段落）的父容器不是ZYTextDiv根容器，则不允许插入表格，避免病历内容丢失
                    {
                        if (!CanInsertTable())
                        {
                            YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("不允许在此处插入新的表格");
                            return;
                        }
                    }
                }
                #endregion

                this.BeginUpdate();

                this.BeginContentChangeLog(); //add by myc 2014-05-26 添加原因：插入表格后也要能支持撤销操作

                if (myContent.HasSelected())
                    //myContent.DeleteSeleciton();
                    myContent.DeleteSelectedElements(); //add by myc 2014-06-16 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
                else if (myOwnerControl.InsertMode == false)
                    myContent.DeleteCurrentElement();

                ////用来保存列宽
                //int sColumn = 0;
                ////如果有固定列宽,则转换为文档的单位
                //if (0 != columnWidth)
                //{
                //    //将厘米单位的列宽转换为文档单位,然后再乘以列数,即为表格总宽
                //    sColumn = (int)GraphicsUnitConvert.Convert((Convert.ToDouble(columnWidth * 10)), System.Drawing.GraphicsUnit.Millimeter, System.Drawing.GraphicsUnit.Document);
                //}

                //根据行,列,表格宽,初始化表格.
                TPTextTable table = new TPTextTable(header, columns, rows, sColumn, myContent.CurrentElement.Height, this.Pages.StandardWidth);


                //设置表格所属的文档对象模型,为RefreshView准备
                table.OwnerDocument = this;

                myContent.AutoClearSelection = true;

                myContent.InsertTable(table);

                this.EndContentChangeLog(); //add by myc 2014-05-26 添加原因：插入表格后也要能支持撤销操作

                this.EndUpdate();
            }
        }
        /// <summary>
        /// 根据表格标题获取指定的表格,如果多个表格具有相同的名称,则会返回所有具有相同名称的表格列表
        /// </summary>
        /// <param name="name">表格标题</param>
        /// <returns>表格列表</returns>
        public List<TPTextTable> GetTableByName(string name)
        {
            ArrayList divAL = RootDocumentElement.ChildElements;
            List<TPTextTable> listTable = new List<TPTextTable>();

            foreach (ZYTextElement ele in divAL)
            {
                if (ele is TPTextTable)
                {
                    TPTextTable findTalbe = ele as TPTextTable;
                    if (findTalbe.Header == name)
                    {
                        listTable.Add(findTalbe);
                    }
                }
            }
            return listTable;
        }

        /// <summary>
        /// 获取文档中所有的表格集合
        /// </summary>
        /// <returns>表格集合</returns>
        public List<TPTextTable> GetAllTables()
        {
            ArrayList divAL = RootDocumentElement.ChildElements;
            List<TPTextTable> listTable = new List<TPTextTable>();

            foreach (ZYTextElement ele in divAL)
            {
                if (ele is TPTextTable)
                {
                    TPTextTable findTalbe = ele as TPTextTable;
                    listTable.Add(findTalbe);
                }
            }
            return listTable;
        }


        /// <summary>
        /// mfb 在光标处插入行
        /// </summary>
        /// <param name="RowNum">要插入行的数目</param>
        /// <param name="IsAfter">是否在光标所在行的后面插入</param>
        public void RowInsert(int RowNum, bool IsAfter)
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;
            myContent.InsertRows(RowNum, IsAfter);
            this.EndContentChangeLog();
            this.EndUpdate();
        }


        /// <summary>
        /// mfb 在光标处插入列
        /// </summary>
        /// <param name="columnNum">要插入列的数目</param>
        /// <param name="IsAfter">是否在光标所在列的后面插入</param>
        public void ColumnInsert(int columnNum, bool IsAfter)
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;
            myContent.InsertColumns(columnNum, IsAfter);
            this.EndContentChangeLog();
            this.EndUpdate();
        }

        /// <summary>
        /// mfb 删除插入点所在表格
        /// </summary>
        public void TableDelete()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;
            myContent.DeleteTable();
            this.EndContentChangeLog();
            this.EndUpdate();
        }

        /// <summary>
        /// mfb 删除插入点所在列
        /// </summary>
        public void TableDeleteCol()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;
            myContent.DeleteColumns();
            this.EndContentChangeLog();
            this.EndUpdate();
        }

        /// <summary>
        /// mfb 删除插入点所在行
        /// </summary>
        public void TableDeleteRow()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;
            myContent.DeleteRows();
            this.EndContentChangeLog();
            this.EndUpdate();
        }

        /// <summary>
        /// TODO: 选定表格
        /// </summary>
        public void TableSelect()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;
            //获取当前元素所在的表格
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                foreach (TPTextRow row in currentTable)
                {
                    foreach (TPTextCell cell in row)
                    {
                        cell.Selected = true;
                        OwnerControl.AddInvalidateRect(cell.GetContentBounds());
                    }
                }
            }

            this.EndContentChangeLog();
            this.EndUpdate();
        }

        /// <summary>
        /// TODO: 选定行
        /// </summary>
        public void TableSelectRow()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;

            //获取当前元素所在的表格
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;

            if (currentTable != null)
            {
                bool isSelectRow = false;
                foreach (TPTextRow row in currentTable)
                {
                    isSelectRow = false;
                    foreach (TPTextCell cell in row)
                    {
                        if (cell.CanAccess == true)
                        {
                            isSelectRow = true;
                            break;
                        }
                    }
                    if (isSelectRow)
                    {
                        foreach (TPTextCell cell in row)
                        {
                            cell.Selected = true;
                            cell.CanAccess = true;
                            OwnerControl.AddInvalidateRect(cell.GetContentBounds());
                        }
                    }
                }
            }

            this.EndContentChangeLog();
            this.EndUpdate();
        }

        /// <summary>
        /// TODO: 选定列
        /// </summary>
        public void TableSelectCol()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;

            //获取当前元素所在的表格
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;

            if (currentTable != null)
            {
                //用来标示被选中的cell所在的列.
                int[] colNum = null;

                // 如果所在的行中有被选中的cell, 则为true.
                bool isFind;

                foreach (TPTextRow row in currentTable)
                {
                    isFind = false;
                    colNum = new int[row.Cells.Count];
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row[i].CanAccess == true)
                        {
                            colNum[i] = 1;
                            isFind = true;
                        }
                    }
                    if (isFind)
                    {
                        //只要找到第一行的就行了,剩下的其他行于第一行的情况相同.
                        //及时跳出,也可以减少循环次数
                        goto wefinded;
                    }
                }
            wefinded: // 根据有选中cell的记录, 遍历所有的行,将其中所属同样列号的cell选中
                foreach (TPTextRow row in currentTable)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (colNum[i] == 1 && colNum != null)
                        {
                            row[i].Selected = true;
                            row[i].CanAccess = true;
                            OwnerControl.AddInvalidateRect(row[i].GetContentBounds());
                        }
                    }
                }
            }

            this.EndContentChangeLog();
            this.EndUpdate();
        }

        /// <summary>
        /// 合并选中的单元格
        /// </summary>
        public void TableMergeCell()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;

            //获取当前元素所在的表格
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;

            if (currentTable != null)
            {
                int colSpan = 0;
                int rowSpan = 0;

                //用来存储被选中的单元格所属的行号和列号
                int[][] needCells = new int[currentTable.IntRows][];

                //所有被选中的单元格,按先行后列的顺序排列
                List<TPTextCell> needMergeCells = new List<TPTextCell>();

                for (int k = 0; k < currentTable.AllRows.Count; k++)
                {
                    bool findRow = false;
                    needCells[k] = new int[currentTable.AllRows[k].Cells.Count];

                    for (int e = 0; e < currentTable.AllRows[k].Cells.Count; e++)
                    {
                        if (currentTable.AllRows[k].Cells[e].CanAccess == true)
                        {
                            findRow = true;
                            needCells[k][e] = 1;
                            needMergeCells.Add(currentTable.AllRows[k].Cells[e]);
                        }
                    }
                    //如果本行中有被选中的cell,则rowspan加一
                    if (findRow == true)
                    {
                        rowSpan += 1;
                    }
                }
                //用来存储所选cell所属的列号
                List<int> colNum = new List<int>();
                bool findit = false;
                for (int i = 0; i < needCells.Length; i++)
                {
                    for (int j = 0; j < needCells[i].Length; j++)
                    {
                        if (needCells[i][j] == 1)
                        {
                            findit = true;
                            colNum.Add(j);
                        }
                    }
                    if (findit)
                    {
                        //如果找到某一行则不用再找其他行了,因为每一行的列数都是一样的
                        //直接跳到外面,计算列数就行了.
                        goto setcolSpan;
                    }
                }
            setcolSpan:
                colSpan = colNum.Count;

                //合并后cell的高度
                int Mergeheight = 0;
                //合并后cell的宽度
                int Mergewidth = 0;

                //int leavePadding = 0;

                for (int index = 0; index < needMergeCells.Count; index++)
                {
                    if (index < colSpan)
                    {
                        Mergewidth += needMergeCells[index].Width;
                    }
                    if (index % colSpan == 0)
                    {
                        Mergeheight += needMergeCells[index].ContentHeight;
                    }
                }
                //重新对合并后的表格内发生改变的cell进行设置
                for (int index = 0; index < needMergeCells.Count; index++)
                {
                    TPTextCell cell = needMergeCells[index];
                    //发生合并的格子一定是第一个
                    if (0 == index)
                    {
                        cell.ContentHeight = Mergeheight + ((rowSpan - 1) * (cell.PaddingTop + cell.PaddingBottom));

                        cell.Width = Mergewidth;
                        cell.Colspan = colSpan;
                        cell.Rowspan = rowSpan;
                        //设置合并后的cell的边框和最后一个cell相同
                        cell.BorderWidthTop = needMergeCells[needMergeCells.Count - 1].BorderWidthTop;
                        cell.BorderWidthRight = needMergeCells[needMergeCells.Count - 1].BorderWidthRight;
                        cell.BorderWidthBottom = needMergeCells[needMergeCells.Count - 1].BorderWidthBottom;
                        cell.BorderWidthLeft = needMergeCells[needMergeCells.Count - 1].BorderWidthLeft;
                        //将其他格子里的ChildElements加入到新的合并cell里.
                        //TODO: 加入进来可以,但是鼠标好像不能定位. 还需要检查
                        //for (int i = 1; i < needMergeCells.Count; i++)
                        //{
                        //    cell.ChildElements.AddRange(needMergeCells[i].ChildElements);
                        //}
                    }
                    else
                    {
                        cell.ChildElements.Clear();
                        cell.ContentHeight = 0;
                        cell.ContentWidth = 0;
                        cell.Height = 0;
                        cell.Width = 0;
                        cell.Padding = 0;
                        cell.BorderWidth = 0;
                        cell.Merged = true;

                    }
                }
                //刷新整个表格状态
                foreach (TPTextRow row in currentTable)
                {
                    foreach (TPTextCell cell in row)
                    {
                        cell.Selected = false;
                        cell.CanAccess = false;
                        if (cell == needMergeCells[0])
                        {
                            cell.CanAccess = true;
                        }
                        OwnerControl.AddInvalidateRect(cell.GetContentBounds());
                    }
                }
            }
            this.RefreshSize();
            this.ContentChanged();

            this.EndContentChangeLog();
            this.EndUpdate();
        }


        /// <summary>
        /// 拆分某个单元格
        /// 从最后的结果来说,拆分也可以看做是合并.
        /// 所以拆分使用合并来做.
        /// </summary>
        /// <param name="row">要拆分的行数</param>
        /// <param name="column">要拆分的列数</param>
        public void TableSplitCell(int row, int column)
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;

            //获取当前元素所在的表格
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;
            //当前要拆分的cell
            TPTextCell CurrCell = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Cell) as TPTextCell;


            #region 原代码现注释掉，暂做测试用
            //if (currentTable != null)
            //{
            //    //当前要拆分的cell
            //    TPTextCell specell = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Cell) as TPTextCell;
            //    //找到要拆分的cell所属的行
            //    TPTextRow specRow = specell.Parent as TPTextRow;

            //    //要拆分的cell在table中所在的行号
            //    int specellRowNum = currentTable.IndexOf(specRow);
            //    //要拆分的cell在table中所在的列号
            //    int specellColNum = specRow.IndexOf(specell);

            //    //要拆分的cell所占的行数
            //    int m = specell.Rowspan;
            //    //要拆分的cell所占的列数
            //    int n = specell.Colspan;

            //    //表格总行数
            //    int tableRowCount = currentTable.AllRows.Count;
            //    //表格总列数
            //    int tableColCount = currentTable.IntColumns;

            //    //拆分后,表格应该有的总行数
            //    int newRow = (tableRowCount + row) - m;
            //    if (row == 1)
            //    {
            //        newRow = tableRowCount;
            //    }
            //    //拆分后,表格应该有的总列数
            //    int newCol = (tableColCount + column) - n;
            //    if (column == 1)
            //    {
            //        newCol = tableColCount;
            //    }
            //    //for( int i = 0; i < column; i++)
            //    //    currentTable.InsertColumns(specellColNum, specell);

            //    currentTable.IntColumns = newCol; //设置表格为最新的列数
            //    int[] newWidths = new int[newCol]; //一个临时的int数组,用来存储最新的每列的宽度
            //    for (int k = 0; k < currentTable.Widths.Length; k++)
            //    {
            //        if (k < n)
            //        {
            //            newWidths[k] = currentTable.Widths[k];
            //        }
            //        else if (k == n)
            //        {
            //            int tmpwidth = currentTable.Widths[k] / column;
            //            for (int e = n; e < n + column; e++)
            //            {
            //                newWidths[e] = tmpwidth;
            //                if (e == n + column - 1)
            //                {
            //                    newWidths[e] = currentTable.Widths[k] - (tmpwidth * (column - 1));
            //                }
            //            }
            //        }
            //        else
            //        {
            //            newWidths[k + column - 1] = currentTable.Widths[k];
            //        }
            //    }
            //    currentTable.RelativeWidths = new int[newWidths.Length];
            //    //将最新的列宽设置到表格中
            //    currentTable.SetWidth(newWidths);

            //    //设置每一个单元格的变化后的宽高度和合并情况
            //    for (int i = 0; i < currentTable.AllRows.Count; i++)
            //    {
            //        TPTextRow tmpRow = currentTable.AllRows[i];

            //        if (i == m)
            //        {
            //            for (int j = 0; j < tmpRow.Cells.Count; j++)
            //            {
            //                TPTextCell tmpCell = tmpRow.Cells[j];
            //                if (j == n)
            //                {
            //                    tmpCell.Colspan = column;
            //                    for (int k = 0; k < column; k++)
            //                    {

            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            for (int j = 0; j < tmpRow.Cells.Count; j++)
            //            {
            //                TPTextCell tmpCell = tmpRow.Cells[j];
            //                if (j == n)
            //                {
            //                    tmpCell.Colspan = column;
            //                    for (int k = 0; k < column; k++)
            //                    {

            //                    }
            //                }
            //            }
            //        }

            //    }

            //} 
            #endregion


            this.RefreshSize();
            this.ContentChanged();
            this.EndContentChangeLog();
            this.EndUpdate();
        }


        /// <summary>
        /// 在拆分前,要确定当前拆分的格子最多能分成多少行,多少列.
        /// <para>为0则能分成无限行,如果大于0,则最多能拆分成返回的行数</para>
        /// <para></para>
        /// </summary>
        /// <returns>("row",0),("col",0)</returns>
        public Dictionary<string, int> TableBeforeSplitCell()
        {
            Dictionary<string, int> dic = null;
            //获取当前元素所在的表格
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                dic = new Dictionary<string, int>();
                TPTextCell cell = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Cell) as TPTextCell;
                int row = (cell.Rowspan > 1) ? cell.Rowspan : 1;
                int col = (cell.Colspan > 1) ? cell.Colspan : 1;
                dic.Add("row", row);
                dic.Add("col", col);
            }
            return dic;
        }

        /// <summary>
        /// 判断当前选中的格子是否可以合并 
        /// <para>1 正确,可以合并</para>
        /// <para>2 不在表格中</para>
        /// <para>3 没有选中任何单元格</para>
        /// <para>4 当前只有一个单元格</para>
        /// <para>5 选中的单元格不是正规的矩形状</para>
        /// </summary>
        /// <returns>int</returns>
        public int TableIsCanMerge()
        {
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                List<int> rowNum = new List<int>();
                List<int> colNum = new List<int>();

                for (int k = 0; k < currentTable.AllRows.Count; k++)
                {
                    bool find = false;
                    for (int e = 0; e < currentTable.AllRows[k].Cells.Count; e++)
                    {
                        if (currentTable.AllRows[k].Cells[e].CanAccess == true)
                        {
                            find = true;
                            colNum.Add(e);
                        }
                    }
                    if (find)
                    {
                        rowNum.Add(k);
                    }
                }
                if (rowNum.Count == 0 || colNum.Count == 0)
                {
                    return 3;
                }
                //只有一行一列.也就是只有一个单元格, 则不能合并
                if (rowNum.Count == 1 && colNum.Count == 1)
                {
                    return 4;
                }
                else
                {
                    //如果不为0
                    if (colNum.Count % rowNum.Count != 0)
                    {
                        return 5;
                    }
                }
                return 1;
            }
            return 2;
        }

        /// <summary>
        /// 判断当前选中的cell是否可以进行拆分
        /// </summary>
        /// <returns></returns>
        public bool TableIsCanSplit()
        {
            //TODO: 判断当前选中的cell是否可以进行拆分
            return true;
        }

        public void SetTableProperty()
        {
            //TODO: 设置表格的各种属性,并刷新整个表格
        }

        /// <summary>
        /// 判断cell在table中所处的位置,主要是为了设置边框.
        /// TODO: 貌似有点没用的方法,暂时留着吧
        /// <para>主要有四种情况:</para>
        /// <para>1 不在最后一行,也不在最后一列</para>
        /// <para>2 不在最后一行,但是在最后一列</para>
        /// <para>3 在最后一行,但是不在最后一列</para>
        /// <para>4 在最后一行,也在最后一列</para>
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        internal void SetCellBorderWidth(TPTextCell cell)
        {
            if (cell == null) return;
            TPTextRow row = cell.OwnerRow;
            TPTextTable table = row.OwnerTable;

            int columns = table.IntColumns;
            int rows = table.IntRows;

            //不在最后一行
            if (table.IndexOf(row) < (rows - 1))
            {
                //不在最后一列
                if (row.IndexOf(cell) < (columns - 1))
                {
                    cell.BorderWidthTop = 1;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthBottom = 0;
                    cell.BorderWidthLeft = 1;
                }
                else if (row.IndexOf(cell) == (columns - 1)) //在最后一列
                {
                    cell.BorderWidthTop = 1;
                    cell.BorderWidthRight = 1;
                    cell.BorderWidthBottom = 0;
                    cell.BorderWidthLeft = 1;
                }
            }
            else if (table.IndexOf(row) == (rows - 1)) //在最后一行
            {
                //不在最后一列
                if (row.IndexOf(cell) < (columns - 1))
                {
                    cell.BorderWidthTop = 1;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthBottom = 1;
                    cell.BorderWidthLeft = 1;
                }
                else if (row.IndexOf(cell) == (columns - 1)) //在最后一列
                {
                    cell.BorderWidthTop = 1;
                    cell.BorderWidthRight = 1;
                    cell.BorderWidthBottom = 1;
                    cell.BorderWidthLeft = 1;
                }
            }

        }

        /// <summary>
        /// 获取当前表格
        /// </summary>
        /// <returns></returns>
        public TPTextTable GetCurrentTable()
        {
            return myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;

        }
        /// <summary>
        /// 获取当前单元格
        /// </summary>
        /// <returns></returns>
        public TPTextCell GetCurrentCell()
        {
            return myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Cell) as TPTextCell;
        }


        #endregion ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅ 表格相关函数群 ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅

        public void ResetNative()
        {
            myInfo.ShowAll = true;
            this.RefreshElements(true);
            this.RefreshLine();
            myContent.AutoClearSelection = true;
            myContent.MoveSelectStart(0);
            myContainters.Clear();
            //SetContainers(myDocumentElement);
            //myAllElement = null;
            this.UpdateView();
        }


        #region add by myc 2014-07-01 注释原因：新版页眉二期改版之光标定位（选定区域）需要
        ///// <summary>
        ///// 重载 <link>ZYCommon.IEMRContentDocument.SelectionChanged</link>接口,文档选择区域发生改变时的处理
        ///// </summary>
        ///// <param name="s1">发生改变的第一个区域的开始序号</param>
        ///// <param name="e1">发生改变的第一个区域的结束序号</param>
        ///// <param name="s2">发生改变的第二个区域的开始序号</param>
        ///// <param name="e2">发生改变的第二个区域的结束序号</param>
        //public void SelectionChanged(int s1, int e1, int s2, int e2)
        //{
        //    if (myOwnerControl != null)
        //    {
        //        //myOwnerControl.HidePopupList();
        //        ZYTextElement myElement = null;

        //        // 这种情况表示,点击了另外一个位置,但并未划选
        //        if (e1 == 0 && e2 == 0 && s1 != s2)
        //        {
        //            if (s1 >= 0 && s1 < myElements.Count && s2 >= 0 && s2 < myElements.Count)
        //            {
        //                ZYTextElement OldElement = (ZYTextElement)myElements[s1];
        //                ZYTextElement NewElement = (ZYTextElement)myElements[s2];
        //                if (OnJumpDiv != null && ZYTextDiv.GetOwnerDiv(OldElement) != ZYTextDiv.GetOwnerDiv(NewElement))
        //                {
        //                    OnJumpDiv(ZYTextDiv.GetOwnerDiv(OldElement), ZYTextDiv.GetOwnerDiv(NewElement));
        //                }
        //            }
        //        }
        //        //往前选
        //        if (s1 != s2)
        //        {
        //            #region bwy:为了避免出错
        //            if (s1 < 0) s1 = 0;
        //            #endregion bwy:

        //            for (int iCount = s1; iCount <= s2; iCount++)
        //            {
        //                if (myContent.SelectLength != 0 && iCount == myElements.Count) continue; //add by myc 2014-06-16 添加原因：鼠标选定元素操作时特殊处理
        //                if (iCount >= myElements.Count) continue;

        //                myElement = (ZYTextElement)myElements[iCount];
        //                //Debug.WriteLine("██s1 != s2时, myElement:" + myElement);
        //                //if( myElement.HandleSelectedChange()) return ;
        //                //						if( myElement is ZYTextContainer )
        //                //							myOwnerControl.AddInvalidateRect( ( myElement as ZYTextContainer).ContentBounds );
        //                //						else
        //                if (myElement is ZYTextBlock)
        //                    myOwnerControl.AddInvalidateRect((myElement as ZYTextBlock).GetContentBounds());
        //                else
        //                {
        //                    try
        //                    {
        //                        myOwnerControl.AddInvalidateRect(
        //                            myElement.RealLeft,
        //                            myElement.OwnerLine.RealTop,
        //                            myElement.Width + myElement.WidthFix,
        //                            myElement.OwnerLine.Height);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Debug.WriteLine("SelectionChanged()方法出错了:" + ex.Message);
        //                    }
        //                }
        //            }
        //        }
        //        //往后选
        //        if (e1 != e2)
        //        {
        //            for (int iCount = e1; iCount <= e2; iCount++)
        //            {
        //                if (myContent.SelectLength != 0 && iCount == myElements.Count) continue; //add by myc 2014-06-16 添加原因：鼠标选定元素操作时特殊处理


        //                myElement = (ZYTextElement)myElements[iCount];
        //                //Debug.WriteLine("██e1 != e2时, myElement:" + myElement);
        //                //if( myElement.HandleSelectedChange()) return ;
        //                //						if( myElement is ZYTextContainer )
        //                //							myOwnerControl.AddInvalidateRect( ( myElement as ZYTextContainer).ContentBounds );
        //                //						else
        //                if (myElement is ZYTextBlock)
        //                    myOwnerControl.AddInvalidateRect((myElement as ZYTextBlock).GetContentBounds());
        //                else
        //                {
        //                    try
        //                    {
        //                        myOwnerControl.AddInvalidateRect(
        //                            myElement.RealLeft,
        //                            myElement.OwnerLine.RealTop,
        //                            myElement.Width + myElement.WidthFix,
        //                            myElement.OwnerLine.Height);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Debug.WriteLine("SelectionChanged()方法出错了:" + ex.Message);
        //                    }
        //                }
        //            }
        //        }
        //        //myOwnerControl.UpdateInvalidateRect();
        //        //if( s1 != e1 || s2 != e2 )
        //        //	myOwnerControl.Refresh();
        //        myOwnerControl.UpdateInvalidateRect();
        //        myOwnerControl.UpdateTextCaret();
        //        if (this.OnSelectionChanged != null)
        //            this.OnSelectionChanged(this, null);
        //    }
        //} 
        #endregion

        public bool bolLastContentChangedFlag = false;
        /// <summary>
        /// 重载 <link>ZYCommon.IEMRContentDocument.ContentChanged</link>接口,文档内容发生改变时的处理
        /// </summary>
        public void ContentChanged()
        {
            bolLastContentChangedFlag = true;
            this.Modified = true;
            this.RefreshElements();
            //if (myElements.Count == 0) //add by myc 2014-07-03 注释原因：新版页眉二期改版需要
            if (editingAreaElements[1].Count == 0) //add by myc 2014-07-03 添加原因：新版页眉二期改版需要
            {
                RootDocumentElement.ClearChild();
                RootDocumentElement.RefreshSize();
                this.RefreshElements();
            }
            //this.RefreshElements();

            this.RefreshLine();

            myView.Height = RootDocumentElement.Top + RootDocumentElement.Height;
            //myOwnerControl.SetViewSize( myView.Width , myView.Height);
            //myOwnerControl.Refresh();
            if (this.OnContentChanged != null)
                this.OnContentChanged(this, null);
        }

        /// <summary>
        /// 判断文档中指定位置是否锁定
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IsLock(int index)
        {
            if (this.Locked)
                return true;
            return myContent.IsLock(index);
        }

        /// <summary>
        /// 判断指定元素是否锁定
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsLock(ZYTextElement element)
        {
            if (this.Locked)
                return true;
            return myContent.IsLock(element);
        }

        /// <summary>
        /// 查找文档中的所有元素.为什么不返回一个al ，因为这个方法是递归的。
        /// </summary>
        /// <param name="al">返回的列表</param>
        /// <param name="element">根元素</param>
        /// <param name="type">类型</param>
        /// <param name="name">元素名称，可为null </param>
        public void GetAllSpecElement(ArrayList al, ZYTextContainer element, ElementType type, string name)
        {

            foreach (ZYTextElement textElement in element.ChildElements)
            {
                if (textElement is ZYTextContainer && !(textElement is ZYTextBlock))
                {
                    GetAllSpecElement(al, (ZYTextContainer)textElement, type, name);
                }
                else if (type == ElementType.All)
                {
                    if (textElement is ZYTextBlock || textElement is ZYElement)
                    {
                        if (name == null || (name != null && GetElementName(textElement) == name))
                        {
                            al.Add(textElement);
                        }
                    }
                }
                else if (type == textElement.Type && (name == null || (name != null && GetElementName(textElement) == name)))
                {

                    al.Add(textElement);
                    //al.
                }
                //else
                //{
                //    if (type == ElementType.Replace)
                //    {
                //        al.Add(textElement);
                //    }

                //}
            }
        }

        string GetElementName(ZYTextElement ele)
        {
            string name = null;
            if (ele is ZYTextBlock)
            {
                name = (ele as ZYTextBlock).Name;
            }
            if (ele is ZYElement)
            {
                name = (ele as ZYElement).Name;
            }
            return name;
        }
        /// <summary>
        /// 获得可替换项数据
        /// </summary>
        /// <returns></returns>
        public string GetReplaceText(string name)
        {
            ArrayList al = new ArrayList();
            string str = name;
            GetAllSpecElement(al, RootDocumentElement, ElementType.FixedText, name);

            #region Deleted By wwj 2013-08-05
            //GetAllSpecElement(al, RootDocumentElement, ElementType.Flag, name);
            #endregion

            if (al.Count > 0)
            {
                //目标元素
                ZYTextElement ele = al[0] as ZYTextElement;

                //元素所在段
                ZYTextParagraph p = ele.Parent as ZYTextParagraph;
                //todo add by zhouhui 解决宏替换的时候将按钮文字也替换过来！ 
                //待确认此功能是否会带来连带bug
                //str = p.ToEmrString2();
                //str = str.Trim();
                //原来是直接返回String字符串，现在改为返回字典和当前目标元素进行对比
                //add by ywk  2012年11月7日8:55:14 浦口大病历要连续书写
                Dictionary<string, string> myDic = p.ToEmrString2();
                foreach (var item in myDic.Keys)
                {
                    if (ele.ToEMRString().TrimStart(':').TrimStart('：') == item)
                    {
                        str = myDic[item].ToString();
                    }
                }


                //Modified By wwj 2012-04-18 复用项目数据的处理
                ////str = str.Substring(ele.ToEMRString().TrimStart().Length);

                //string eleStr = ele.ToEMRString().TrimStart();
                //str = str.Substring(str.IndexOf(eleStr) + eleStr.Length).TrimStart(':').TrimStart('：');

                //str = str.Trim();

                //如果是固定文本，那么替换整段
                if (ele is ZYFixedText)
                {
                    int index1 = str.IndexOf(':');
                    int index2 = str.IndexOf('：');

                    if (index1 == 0 || index2 == 0)
                    {
                        str = str.Substring(1);
                    }
                }

                #region Deleted By wwj 2013-08-05
                ////如果是标题定位符，替换它所在的一句话
                //if (ele is ZYFlag)
                //{
                //    str = str.Substring(str.IndexOf('§') + 1);
                //    int indexo = str.IndexOf('。');
                //    if (indexo >= 0)
                //    {
                //        str = str.Substring(0, indexo + 1);
                //    }
                //} 
                #endregion
            }
            return str;
        }

        #region 由于导出的文档结构不正确，暂时作废 Modified By wwj 2013-08-05
        ///// <summary>
        ///// 导出电子病历结构化文档
        ///// </summary>
        ///// <returns></returns>
        //public XmlDocument ToEMRXml()
        //{
        //    //获取所有元素列表
        //    XmlDocument doc = new XmlDocument();
        //    XmlElement root = doc.CreateElement("电子病历结构化文档");
        //    root.SetAttribute("level", "0");
        //    doc.AppendChild(root);

        //    XmlElement currentelement = root;

        //    //当前元素level
        //    int curlevel = 0;
        //    ArrayList al = new ArrayList();
        //    GetAllSpecElement(al, this.RootDocumentElement, ElementType.All, null);
        //    string name = "";

        //    ArrayList alparent = new ArrayList();
        //    ArrayList alinflag = new ArrayList();

        //    XmlElement ele = null;
        //    foreach (object o in al)
        //    {
        //        ele = null;

        //        //如果遇到了定位符，则查找它后一句话中的元素，如果元素在该范围内，插入；否则 ，插入它的父级
        //        if (o is ZYFlag)
        //        {
        //            name = (o as ZYFlag).Name;
        //            name = StringCommon.GetXmlElementName(name);
        //            ele = doc.CreateElement(name);
        //            ele.SetAttribute("flag", "1");
        //            ele.SetAttribute("code", (o as ZYFlag).Code);
        //            // alinflag 里边的元素是要在定位符范围内的
        //            alparent = (o as ZYTextElement).Parent.ChildElements;
        //            alinflag.Clear();
        //            int start = alparent.IndexOf(o);
        //            for (int i = start; i < alparent.Count; i++)
        //            {
        //                if (alparent[i] is ZYTextEOF || alparent[i] is ZYTextLineEnd)
        //                {
        //                    break;
        //                }
        //                if (alparent[i] is ZYTextChar)
        //                {
        //                    if ((alparent[i] as ZYTextChar).Char == '。')
        //                        break;
        //                }

        //                if (alparent[i] is ZYTextBlock)
        //                    alinflag.Add(alparent[i]);
        //            }
        //        }
        //        else if (o is ZYFixedText)
        //        {

        //            name = (o as ZYFixedText).Text;

        //            name = StringCommon.GetXmlElementName(name);

        //            ele = doc.CreateElement(name);
        //            ele.SetAttribute("code", (o as ZYFixedText).Code);

        //            if ((o as ZYFixedText).Level != null)
        //            {
        //                curlevel = (int)(o as ZYFixedText).Level;
        //                ele.SetAttribute("level", curlevel.ToString());
        //            }

        //        }
        //        else if (o is ZYTextBlock)
        //        {
        //            name = (o as ZYTextBlock).Name;
        //            name = StringCommon.GetXmlElementName(name);
        //            ele = doc.CreateElement(name);
        //            ele.SetAttribute("code", (o as ZYTextBlock).Code);



        //            //如果是单选、多选、有无选,记录选中的项目的值域代码
        //            if (o is ZYSelectableElement)
        //            {
        //                foreach (ZYSelectableElementItem item in (o as ZYSelectableElement).SelectList)
        //                {
        //                    if (item.IsSelected)
        //                    {
        //                        XmlElement itemele = doc.CreateElement("选项");
        //                        itemele.SetAttribute("code", item.Code);
        //                        itemele.InnerText = item.InnerValue;
        //                        ele.AppendChild(itemele);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ele.InnerText = (o as ZYTextBlock).ToEMRString();
        //            }
        //        }

        //        else if (o is ZYElement)
        //        {
        //            name = (o as ZYElement).Name;
        //            name = StringCommon.GetXmlElementName(name);
        //            ele = doc.CreateElement(name);
        //            ele.SetAttribute("code", (o as ZYElement).Code);
        //            ele.InnerText = (o as ZYElement).ToEMRString();
        //        }

        //        if (ele != null)
        //        {
        //            if (ele.GetAttribute("level") == "")
        //            {
        //                if (currentelement.GetAttribute("flag") == "1")
        //                {
        //                    if (alinflag.Contains(o))
        //                    {

        //                    }
        //                    else
        //                    {
        //                        currentelement = currentelement.ParentNode as XmlElement;
        //                    }

        //                }
        //                currentelement.AppendChild(ele);


        //                //如果当前节点无级别，它不可能做为父节点
        //                if (o is ZYFlag)
        //                {
        //                    currentelement.AppendChild(ele);
        //                    currentelement = ele;
        //                }

        //                continue;
        //            }

        //            if (int.Parse(currentelement.GetAttribute("level")) < int.Parse(ele.GetAttribute("level")))
        //            {
        //                currentelement.AppendChild(ele);
        //                currentelement = ele;
        //                continue;
        //            }

        //            if (int.Parse(currentelement.GetAttribute("level")) >= int.Parse(ele.GetAttribute("level")))
        //            {
        //                //找到上一个和它同级元素的你节点
        //                XmlElement parent = null;
        //                parent = currentelement.ParentNode as XmlElement;
        //                while (parent != null)
        //                {

        //                    if (int.Parse(parent.GetAttribute("level")) < int.Parse(ele.GetAttribute("level")))
        //                    {
        //                        parent.AppendChild(ele);
        //                        currentelement = ele;
        //                        break;
        //                    }
        //                    parent = parent.ParentNode as XmlElement;
        //                }

        //                if (parent == null)
        //                {
        //                    root.AppendChild(ele);
        //                    currentelement = ele;
        //                }
        //            }
        //        }
        //    }
        //    return doc;
        //} 
        #endregion

        /// <summary>
        /// 获得文档大纲结构
        /// </summary>
        /// <returns></returns>
        public void GetBrief(TreeView tv)
        {
            tv.Nodes.Clear();
            TreeNode currentnode = null;
            ArrayList al = new ArrayList();
            GetAllSpecElement(al, this.RootDocumentElement, ElementType.FixedText, null);
            foreach (object o in al)
            {
                string name = (o as ZYFixedText).Text;
                TreeNode node;
                if ((o as ZYFixedText).Level == null)
                {
                    continue;
                }

                else
                {
                    int curlevel = (int)(o as ZYFixedText).Level;
                    node = new TreeNode(name);
                    string pre = "";
                    for (int i = 1; i < curlevel; i++)
                    {
                        pre += " ";
                    }
                    node.Text = pre + node.Text;

                    //用这个属性保存级别
                    node.ToolTipText = curlevel.ToString();
                    node.Tag = o;


                    if (tv.Nodes.Count == 0)
                    {
                        tv.Nodes.Add(node);
                        currentnode = node;
                        continue;
                    }
                }

                if ((o as ZYFixedText).FirstElement == this.Content.CurrentElement)
                {
                    tv.SelectedNode = node;
                }

                if (int.Parse(currentnode.ToolTipText) < int.Parse(node.ToolTipText))
                {
                    currentnode.Nodes.Add(node);
                    currentnode = node;
                    continue;
                }
                else
                {
                    //找到上一个和它同级元素的节点
                    TreeNode parent = currentnode.Parent;
                    if (parent != null)
                    {
                        if (int.Parse(parent.ToolTipText) < int.Parse(node.ToolTipText))
                        {
                            parent.Nodes.Add(node);
                            currentnode = node;
                            continue;
                        }
                    }

                    tv.Nodes.Add(node);
                    currentnode = node;
                }


            }
            tv.ExpandAll();

        }

        /// <summary>
        /// 是否固定行高
        /// </summary>
        public bool EnableFixedLineHeigh = false;

        int fixedLineHeigh = 80;
        /// <summary>
        /// 固定行高度，只有值>0时才有效，默认为80 
        /// </summary>
        public int FixedLineHeigh
        {
            get { return fixedLineHeigh; }
            set
            {
                if (value > 0)
                {
                    fixedLineHeigh = value;
                }
                else
                {
                    this.EnableFixedLineHeigh = false;
                }
            }
        }
        /// <summary>
        /// 插入模板文件，在当前段之后
        /// </summary>
        /// <param name="data"></param>
        public void InsertTemplateFile(byte[] data)
        {
            XmlDocument doc = this.OwnerControl.BinaryToXml(data);
            InsertTemplateFile(doc);
        }
        /// <summary>
        /// 插入模板文件，在当前段之后
        /// </summary>
        /// <param name="path"></param>
        public void InsertTemplateFile(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            InsertTemplateFile(doc);

        }

        public void InsertTemplateByteFile(string path)
        {
            //读取byte[]文件

            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);
            fs.Close();
            fs.Dispose();
            InsertTemplateFile(data);
        }
        /// <summary>
        /// 插入模板文件，在当前段之后
        /// </summary>
        /// <param name="doc"></param>
        public void InsertTemplateFile(XmlDocument doc)
        {
            //获得xml,转换成元素列表

            XmlNode node = doc.SelectSingleNode("document/body");
            ArrayList myList = new ArrayList();
            this.LoadElementsToList(node as XmlElement, myList);

            //当前元素(这里为一个eof符)
            ZYTextElement myElement = this.Content.CurrentElement;

            //当前元素所属的段落对象
            ZYTextElement Paraparent = myElement.Parent;
            while (!(Paraparent is ZYTextParagraph))
            {
                Paraparent = Paraparent.Parent;
            }

            //当前元素所属的容器的容器,(这里为div)
            ZYTextContainer divParent = (Paraparent as ZYTextParagraph).Parent;

            //将元素插入到文档中
            if (myList.Count > 0)
            {
                foreach (ZYTextElement myParagraph in myList)
                {
                    myParagraph.RefreshSize();
                    divParent.InsertAfter(myParagraph, Paraparent);
                    Paraparent = myParagraph as ZYTextParagraph;
                }


            }
            this.AutoClearSelection = true;
            this.ContentChanged();
            this.EndUpdate();

            this.Content.CurrentElement = (Paraparent as ZYTextParagraph).LastElement;
        }


        public void ReplaceTemplate(ElementType type, string tname)
        {
            //打开模板文件，获得xml,参考_past方法，插入到文档
            //调用事件

            XmlDocument doc = this.OwnerControl.FireGetOuterData(type, tname);

            if (doc != null)
            {
                this.BeginUpdate();
                this.BeginContentChangeLog();

                //删除当前选项
                this._Delete();
                InsertTemplate(doc);

                myContent.SelectLength = 0;
                this.EndContentChangeLog();
                this.EndUpdate();
            }
            else
            {
                MessageBox.Show("目标不存在");
            }


        }

        /// <summary>
        /// 插入模板在内容之中
        /// </summary>
        /// <param name="data"></param>
        public void InsertTemplate(byte[] data)
        {
            XmlDocument doc = this.OwnerControl.BinaryToXml(data);
            InsertTemplate(doc);
        }

        /// <summary>
        /// 插入病程专用
        /// 待测试
        /// </summary>
        /// <param name="data"></param>
        /// <param name="daily"></param>
        public void InsertDaliyTemplate(byte[] data)
        {
            XmlDocument doc = this.OwnerControl.BinaryToXml(data);
            InsetDaliyTemplate(doc);
        }

        public void InsetDaliyTemplate(XmlDocument doc)
        {
            try
            {
                XmlNode node = doc.SelectSingleNode("document/body");
                ArrayList myList = new ArrayList();
                this.LoadElementsToList(node as XmlElement, myList);

                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i] is ZYTextEOF)
                    {
                        myList.Remove(myList[i]);
                    }
                }
                if (myList.Count > 0)
                {
                    foreach (ZYTextElement myElement in myList)
                    {
                        if (myElement is ZYTextContainer)
                            (myElement as ZYTextContainer).ClearSaveLog();
                        myElement.RefreshSize();
                    }

                    this.Content.InsertRangeElements(myList);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 插入模板在内容之中
        /// </summary>
        /// <param name="doc"></param>
        public void InsertTemplate(XmlDocument doc)
        {
            try
            {
                XmlNode node = doc.SelectSingleNode("document/body/p");
                ArrayList myList = new ArrayList();
                this.LoadElementsToList(node as XmlElement, myList);

                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i] is ZYTextEOF)
                    {
                        myList.Remove(myList[i]);
                    }
                }
                if (myList.Count > 0)
                {
                    foreach (ZYTextElement myElement in myList)
                    {
                        if (myElement is ZYTextContainer)
                            (myElement as ZYTextContainer).ClearSaveLog();
                        myElement.RefreshSize();
                    }

                    this.Content.InsertRangeElements(myList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CanPase
        {
            get
            {
                //设计状态可以粘贴
                if (this.Info.DocumentModel == DocumentModel.Design)
                {
                    return true;
                }
                //编辑状态只能从内部剪切板。 粘贴同一病人的数据，且应为文本
                else if (this.Info.DocumentModel == DocumentModel.Edit
                    /*&& EmrClipboard.PatientID == this.Info.PatientID && EmrClipboard.PatientID != ""   *********Modified by wwj 2012-07-24********* */)
                {
                    return true;
                }
                else if (this.Info.DocumentModel == DocumentModel.Read
                    /*&& EmrClipboard.PatientID == this.Info.PatientID && EmrClipboard.PatientID != ""   *********Modified by wwj 2012-07-24********* */
                    && this.OwnerControl.ActiveEditArea != null)
                {
                    int index = this.Content.IndexOf(this.Content.CurrentElement);
                    int start = this.Content.IndexOf(this.OwnerControl.ActiveEditArea.TopElement);
                    int end = this.Content.IndexOf(this.OwnerControl.ActiveEditArea.EndElement);
                    if (this.OwnerControl.ActiveEditArea.Top >= this.Content.CurrentElement.RealTop
                        || this.Content.CurrentElement.RealTop + this.Content.CurrentElement.Height <= this.OwnerControl.ActiveEditArea.End
                        )
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    //要检查patientID
                    return false;
                }
            }
        }

        public bool DeleteFlag = false;//false 不删除固定文本， true 即使是固定文本，照样删除，根据删除病程记录的需求原则问题而增加

        /// <summary>
        /// Add By wwj 2011-09-23 调用外部“查找”窗体
        /// </summary>
        public void ShowFindForm()
        {
            if (OnShowFindForm != null)
            {
                OnShowFindForm();
            }
        }

        public void SaveEMR()
        {
            if (OnSaveEMR != null)
            {
                OnSaveEMR();
            }
        }

        #region Add By wwj 2012-02-16 单元格中设置斜线

        /// <summary>
        /// 单元格中设置斜线
        /// </summary>
        /// <param name="italicLineStyle"></param>
        /// <returns></returns>
        public string SetItalicLineInCell(int italicLineStyle)
        {
            #region 找到选中的单元格
            //获取当前元素所在的表格
            TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;

            if (currentTable == null) return "请选中单元格";

            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;

            if (currentTable != null)
            {
                for (int k = 0; k < currentTable.AllRows.Count; k++)
                {
                    for (int e = 0; e < currentTable.AllRows[k].Cells.Count; e++)
                    {
                        if (currentTable.AllRows[k].Cells[e].CanAccess == true)
                        {
                            TPTextCell selectedCell = currentTable.AllRows[k].Cells[e];
                            SetItalicLineInCellInner(selectedCell, italicLineStyle);
                        }
                    }
                }
            }

            this.RefreshSize();
            this.ContentChanged();
            this.EndContentChangeLog();
            this.EndUpdate();

            return string.Empty;
            #endregion
        }

        private void SetItalicLineInCellInner(TPTextCell cell, int italicLineStyle)
        {
            #region 设置单元格的斜线
            if (cell == null) return;

            //0:没有线 1:左上到右下的斜线 2:右上到左下的斜线 3:左上到右下的两条斜线
            cell.ItalicLineStyleInCell = (ItalicLineStyle)Enum.Parse(typeof(ItalicLineStyle), italicLineStyle.ToString());
            #endregion
        }

        #endregion

        #region Add By wwj 2012-02-16 设置页眉和页脚的高度

        /// <summary>
        /// 设置页眉的高度
        /// </summary>
        /// <param name="height"></param>
        public int DocumentHeaderHeight
        {
            get
            {
                return intHeadHeight;
            }
            set
            {
                if (intHeadHeight != value)
                {
                    this.BeginUpdate();
                    this.BeginContentChangeLog();
                    myContent.AutoClearSelection = true;

                    //intHeadHeight = value < 200 ? 200 : (value > 600 ? 600 : value);
                    intHeadHeight = value; //add by myc 2014-01-16 文档页眉高度自适应

                    this.RefreshSize();
                    this.ContentChanged();
                    this.EndContentChangeLog();
                    this.EndUpdate();
                }
            }
        }

        /// <summary>
        /// 设置页脚的高度
        /// </summary>
        /// <param name="height"></param>
        public int DocumentFooterHeight
        {
            get
            {
                return intFooterHeight;
            }
            set
            {
                if (intFooterHeight != value)
                {
                    this.BeginUpdate();
                    this.BeginContentChangeLog();
                    myContent.AutoClearSelection = true;

                    intFooterHeight = value < 20 ? 20 : (value > 200 ? 200 : value);

                    this.RefreshSize();
                    this.ContentChanged();
                    this.EndContentChangeLog();
                    this.EndUpdate();
                }
            }
        }

        #endregion

        #region Add By wwj 2012-02-21 重新计算并绘制界面元素

        /// <summary>
        /// 重新计算并绘制界面元素
        /// </summary>
        public void Refresh2()
        {
            this.BeginUpdate();
            this.BeginContentChangeLog();
            myContent.AutoClearSelection = true;

            this.RefreshSize();
            this.ContentChanged();
            this.EndContentChangeLog();
            this.EndUpdate();
        }

        #endregion

        /// <summary>
        /// 针对护理记录单的插入表格 Add By wwj 2012年5月
        /// </summary>
        public void TableInsertForNurseTable()
        {
            if (this.Info.DocumentModel == DocumentModel.Design || this.Info.DocumentModel == DocumentModel.Edit)
            {
                TPTextTable currentTable = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Table) as TPTextTable;
                if (currentTable == null)
                {
                    this.BeginUpdate();
                    if (myContent.HasSelected())
                        //myContent.DeleteSeleciton();
                        myContent.DeleteSelectedElements(); //add by myc 2014-06-16 删除选中区域若干个元素新处理方法，支持表格元素操作的撤销
                    else if (myOwnerControl.InsertMode == false)
                        myContent.DeleteCurrentElement();

                    myContent.AutoClearSelection = true;

                    TPTextTable table = myContent.GetFirstTable();
                    if (table != null)
                    {
                        myContent.InsertTable(table);
                    }


                    this.EndUpdate();
                }
            }
        }

        /// <summary>
        /// 设置单元格是否可以换行 Add By wwj 2012-06-06
        /// </summary>
        public void SetTableCellCanInsertEnter(bool canEnter)
        {
            this.Content.SetTableCellCanInsertEnter(canEnter);
        }














        #region 新版页眉一期改版处理程序 add by myc 2014-01-15
        /// <summary>
        /// 保存页眉模板文档对象到一个XML文档对象中。
        /// add by myc 2014-01-15 13:15:28。
        /// </summary>
        /// <param name="myDoc">XML文档对象。</param>
        /// <returns>操作是否成功。</returns>
        public bool ToHeadXMLDocument(XmlDocument myDoc)
        {
            try
            {
                myDoc.PreserveWhitespace = true;
                CreateRootElement(ref myDoc);
                return ToHeadXML(myDoc.DocumentElement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存页眉模板文档对象到一个XM文件中。
        /// add by myc 2014-01-15 13:20:28。
        /// </summary>
        /// <param name="strURL">一个XML文件名</param>
        /// <returns>操作是否成功</returns>
        public bool ToHeadXMLFile(string strURL)
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();
                CreateRootElement(ref myDoc);
                if (ToHeadXML(myDoc.DocumentElement))
                {
                    myDoc.PreserveWhitespace = false;
                    myDoc.Save(strURL);
                    myInfo.FileName = strURL;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 针对页眉模板的文档内容保存到XML节点中，新增的ToHeadXML方法。
        /// add by myc 2014-01-15 13:15:28。
        /// </summary>
        /// <param name="RootElement">文档根元素节点，即document节点。</param>
        /// <returns>操作是否成功。</returns>
        public bool ToHeadXML(XmlElement RootElement)
        {
            try
            {
                if (RootElement != null)
                {
                    RootElement.OwnerDocument.PreserveWhitespace = true;
                    //保存页面设置
                    XmlElement pageSettings =
                    RootElement.OwnerDocument.CreateElement("pagesettings");
                    this.Pages.PageSettings.ToXML(pageSettings);
                    RootElement.AppendChild(pageSettings);
                    if (myInfo.SaveMode == 3)
                    {
                        //这里的RootDocumentElement是ZYTextContainer的一个对象
                        if (RootDocumentElement != null)
                        {
                            RootDocumentElement.ToXML(RootElement);
                        }
                    }
                    else
                    {
                        mySaveLogs.CurrentSaveLog.SaveDateTime = ZYTime.GetServerTime();
                        if (myMarks.NewMark != null)
                            myMarks.NewMark.MarkTime = mySaveLogs.CurrentSaveLog.SaveDateTime;
                        if (myInfo.EnableSaveLog)
                        {
                            // 保存签名信息
                            myMarks.ToXML(XMLCommon.CreateChildElement(RootElement, myMarks.GetXMLName(), true));
                            // 保存保存文档记录
                            mySaveLogs.ToXML(XMLCommon.CreateChildElement(RootElement, mySaveLogs.GetXMLName(), true));
                        }
                        myInfo.ModifyTime = ZYTime.GetServerTime().ToString("yyyy-MM-dd HH:mm:ss");
                        myInfo.Version = c_EditorVersion;
                        myInfo.Modifier = mySaveLogs.CurrentIndex.ToString();
                        myInfo.ToXML(XMLCommon.CreateChildElement(RootElement, ZYDocumentInfo.GetXMLName(), true));
                        if (RootDocumentElement != null)
                        {
                            RootDocumentElement.ToHeadXML(XMLCommon.CreateChildElement(RootElement, ZYTextConst.c_Body, true));
                        }
                    }
                    return true;
                }

                RootDocumentElement.ToHeadXML(XMLCommon.CreateChildElement(RootElement, ZYTextConst.c_Body, true));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 画页眉页脚，支持宏元素和文本元素。
        /// add by myc 2014-01-12 10:12:45。
        /// </summary>
        private void DrawMacroAndText(string str, Graphics g, Rectangle ClipRectangle)
        {
            try
            {
                if (str.Length == 0) return;
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                doc.LoadXml(str);
                XmlNodeList HeaderNodes = doc.SelectNodes("header/p"); //得到header节点下的所有儿子节点p集合，即页眉区域的所有数据行
                if (HeaderNodes == null || HeaderNodes.Count == 0) return;

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.MeasureTrailingSpaces;
                Font f = null;
                foreach (XmlNode LineNode in HeaderNodes) //遍历header节点下的每一个儿子节点p
                {
                    if (!(LineNode is XmlElement)) continue; //如果不是xml元素节点，则继续循环判断下一个节点类型
                    foreach (XmlNode SubNode in LineNode.ChildNodes)
                    {
                        if (!(SubNode is XmlElement)) continue; //如果不是xml元素节点，则继续循环判断下一个节点类型
                        XmlElement ele = (SubNode as XmlElement);
                        if (ele.Name == "macro") //画宏元素节点
                        {
                            #region 具体代码
                            string fn = Control.DefaultFont.Name;
                            float fs = (float)Control.DefaultFont.Size;
                            FontStyle style = FontStyle.Regular;
                            if (ele.HasAttribute("fontname")) fn = ele.GetAttribute("fontname");
                            if (ele.HasAttribute("fontsize")) fs = float.Parse(ele.GetAttribute("fontsize"));
                            if (ele.HasAttribute("fontbold")) style |= FontStyle.Bold;
                            if (ele.HasAttribute("fontitalic")) style |= FontStyle.Italic;
                            if (ele.HasAttribute("fontunderline")) style |= FontStyle.Underline;
                            f = new Font(fn, fs, style);
                            //Rectangle rect = new Rectangle(Convert.ToInt32(ele.GetAttribute("left")),
                            //                               Convert.ToInt32(ele.GetAttribute("top")),
                            //                               Convert.ToInt32(ele.GetAttribute("width")),
                            //                               Convert.ToInt32(ele.GetAttribute("height")));
                            //处理中文字符宽度时，需要用画布的MeasureString方法计算才能准确画出所有中文字符
                            RectangleF rect = new RectangleF(Convert.ToInt32(ele.GetAttribute("left")),
                                                           Convert.ToInt32(ele.GetAttribute("top")),
                                                           g.MeasureString(ele.InnerText, f, 10000).Width,
                                                           g.MeasureString(ele.InnerText, f, 10000).Height);
                            if (!this.Info.Printing) //打印时不能显示宏元素的背景色
                            {
                                g.FillRectangle(new SolidBrush(ZYEditorControl.ElementBackColor), rect);
                            }
                            //g.DrawString(ele.InnerText, f, new SolidBrush(Color.Black), rect, sf); 
                            g.DrawString(ele.InnerText, f,
                                new SolidBrush((ele.HasAttribute("forecolor")) ? (ColorTranslator.FromHtml(ele.GetAttribute("forecolor"))) : (Color.Black)), rect, sf);
                            #endregion
                        }
                        else if (ele.Name == "span") //画文本元素节点
                        {
                            #region 具体代码
                            if (ele.InnerText == " ") continue;
                            string fn = Control.DefaultFont.Name;
                            float fs = (float)Control.DefaultFont.Size;
                            FontStyle style = FontStyle.Regular;
                            if (ele.HasAttribute("fontname")) fn = ele.GetAttribute("fontname");
                            if (ele.HasAttribute("fontsize")) fs = float.Parse(ele.GetAttribute("fontsize"));
                            if (ele.HasAttribute("fontbold")) style |= FontStyle.Bold;
                            if (ele.HasAttribute("fontitalic")) style |= FontStyle.Italic;
                            if (ele.HasAttribute("fontunderline")) style |= FontStyle.Underline;
                            f = new Font(fn, fs, style);
                            RectangleF rect = new RectangleF(Convert.ToInt32(ele.GetAttribute("left")),
                                                           Convert.ToInt32(ele.GetAttribute("top")),
                                                           g.MeasureString(ele.InnerText, f, 10000).Width,
                                                           g.MeasureString(ele.InnerText, f, 10000).Height);
                            //g.DrawString(ele.InnerText, f, new SolidBrush(Color.Black), rect, sf);
                            g.DrawString(ele.InnerText, f,
                                new SolidBrush((ele.HasAttribute("forecolor")) ? (ColorTranslator.FromHtml(ele.GetAttribute("forecolor"))) : (Color.Black)), rect, sf);
                            #endregion
                        }
                        else if (ele.Name == "horizontalLine") //水平线节点
                        {
                            if (ele.HasAttribute("lineHeight"))
                            {
                                Pen LinePen = new Pen(Color.Black);
                                LinePen.Width = Convert.ToInt32(ele.GetAttribute("lineHeight"));
                                g.DrawLine(LinePen, ClipRectangle.Left, Convert.ToInt32(ele.GetAttribute("top")), ClipRectangle.Right, Convert.ToInt32(ele.GetAttribute("top")));
                                //StartY = StartY + (int)LinePen.Width + 20;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 绘制页眉新方法。
        /// add by myc 2014-01-12 08:45:16。
        /// </summary>
        public void DrawHeadNew(System.Drawing.Graphics g, System.Drawing.Rectangle ClipRectangle)
        {
            try
            {
                if (this.RuntimeHeadString.Length <= 0) return;
                if (this.RuntimeHeadString.Contains("sx_flag"))
                {
                    DrawMacroAndText(this.RuntimeHeadString, g, ClipRectangle);
                }
                else
                {
                    DrawExtString(this.RuntimeHeadString, g, ClipRectangle);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 新版表格处理程序 add by myc 2014-02-28 finish by myc 2014-05-16
        #region 合并单元格（已修订完毕） add by myc 2014-02-28 update by myc 2014-04-19
        /// <summary>
        /// 鼠标拖选时得到的选中单元格集合。
        /// </summary>
        public List<TPTextCell> SelectedCells = new List<TPTextCell>();

        /// <summary>
        /// 合并鼠标拖选时选中的若干个（小）单元格为一个（大）单元格。
        /// </summary>
        public void MergeTBCells()
        {
            try
            {
                #region 判断能够合并
                if (SelectedCells.Count <= 1) return; //禁止用户只选中一个单元格就执行合并这种操作
                TPTextTable currTB = SelectedCells[0].OwnerRow.OwnerTable;
                if (currTB == null) return;

                if (currTB.CheckIsCanMerge())
                {
                    if (currTB.IsComplexMerge())
                    {
                        YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("当前选中区域内单元格结构过于复杂，无法进行合并操作");
                        SelectedCells.Clear();
                        //后期此处需要调整，毕竟用户视觉效果是看不出底层绘制的复杂结构处理的
                        return;
                    }
                }
                else
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("您没有选择单元格或选择的区域不是合法矩形，都不能进行单元格的合并操作");
                    SelectedCells.Clear();
                    return;
                }
                #endregion

                #region 锁定用户界面
                this.BeginUpdate();
                this.BeginContentChangeLog();
                myContent.AutoClearSelection = true;
                #endregion

                #region 由最深递归层次开始直至最顶层次，一层层地进行有序合并
                mergeParas.Clear();
                TPTextCell mergeCell = null;
                for (int level = currTB.RecusiveTraversalLevel; level >= 1; level--)
                {
                    List<List<List<TPTextCell>>> mergeRowsList = currTB.RecusiveMergeRowsList(level);
                    if (mergeRowsList == null || mergeRowsList.Count == 0) break;

                    //待纵向合并的单元格集合
                    List<TPTextCell> ToVMC = new List<TPTextCell>();
                    foreach (List<List<TPTextCell>> rows in mergeRowsList)
                    {
                        ToVMC.Clear();
                        foreach (List<TPTextCell> innerRow in rows)
                        {
                            ToVMC.Add(HMerge(innerRow));
                        }
                        mergeCell = VMerge(ToVMC);
                    }
                }

                //检查选中单元格集合中的剩余单元格数量
                if (SelectedCells.Count > 1)
                {
                    //复杂情况下的合并单元格操作，留待后续修正并逐步完善
                }

                currTB.CheckFlagRow(mergeCell);
                MergeContent(mergeCell);
                SelectedCells.Clear();
                #endregion

                #region 更新用户界面
                this.RefreshSize();
                this.ContentChanged();
                this.EndContentChangeLog();
                this.EndUpdate();
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在水平方向上将位于同一个表格行内部的若干个（小）单元格合并为一个同级的（大）单元格，
        /// 并且这个合并后的（大）单元格由第一个（小）单元格而来。
        /// </summary>
        /// <param name="smallCells">指定的若干个（小）单元格。</param>
        /// <returns></returns>
        public TPTextCell HMerge(List<TPTextCell> smallCells)
        {
            try
            {
                if (smallCells.Count == 1) return smallCells[0]; //此时不进行横向上的合并单元格操作，直接返回

                //通过累加计算得到合并之后的同级（大）单元格的宽度
                int allWidth = 0;
                foreach (TPTextCell smallCell in smallCells)
                {
                    allWidth += smallCell.Width;
                }
                smallCells[0].Width = allWidth;

                //将除第一个（小）单元格之外的其他（小）单元格从其所属表格行内部移除
                TPTextRow row = smallCells[0].OwnerRow; //要横向合并的第一个（小）单元格所属的表格行
                int cellIndex = row.IndexOf(smallCells[0]) + 1;
                row.Cells.RemoveRange(cellIndex, smallCells.Count - 1);
                row.ChildElements.RemoveRange(cellIndex, smallCells.Count - 1);
                row.Columns -= smallCells.Count - 1; //更新（小）单元格所属表格行的列个数

                //更新（小）单元格所属表格行内部包含的（小）单元格宽度数组属性
                int[] widths = new int[row.Columns];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    widths[j] = row[j].Width;
                }
                row.Widths = widths;

                //如果在待横向合并的（小）单元格列表中，最后一个（小）单元格位于表格最右侧，则合并后的（大）单元格要设置其右边框宽度为1
                if (smallCells[smallCells.Count - 1].BorderWidthRight == 1)
                {
                    smallCells[0].BorderWidthRight = 1;
                }

                return smallCells[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在垂直方向将位于若干个表格行内部的（小）单元格合并为一个（大）单元格，注意此时每一个表格行内部有且仅有一个（小）单元格，
        /// 并且这个合并后的（大）单元格由第一个（小）单元格而来，其他（小）单元格将调整为占位单元格。
        /// </summary>
        /// <param name="smallCells">指定的若干个（小）单元格。</param>
        /// <returns></returns>
        public TPTextCell VMerge(List<TPTextCell> smallCells)
        {
            try
            {
                if (smallCells.Count == 1) return smallCells[0]; //此时不进行纵向上的合并单元格操作，直接返回

                TPTextRow row = smallCells[0].OwnerRow; //要纵向合并的第一个（小）单元格所属的表格行
                TPTextCell parentCell = row.Parent as TPTextCell; //检测是否为拆分单元格内部的合并单元格操作

                int allHeight = 0;
                smallCells[0].HasFlagCells.Clear();
                foreach (TPTextCell smallCell in smallCells)
                {
                    //同过累加计算得到合并之后的（大）单元格高度
                    if (smallCell.Height > smallCell.OwnerRow.Height)
                    {
                        allHeight += smallCell.OwnerRow.Height;
                    }
                    else
                    {
                        allHeight += smallCell.Height;
                    }

                    //非第一个（小）单元格需要设置为占位单元格
                    if (smallCells.IndexOf(smallCell) == 0) continue;
                    smallCell.CanAccess = false;
                    smallCell.Selected = false;
                    smallCell.ChildElements.Clear();
                    smallCell.Lines.Clear();

                    smallCells[0].HasFlagCells.Add(smallCell);
                    smallCell.OwnerMergeCell = smallCells[0];
                }

                row.OwnerTable.CheckFlagRow(smallCells[0]); //非常重要——拆分单元格高度由内部嵌套表格行总高度决定
                smallCells[0].Height = allHeight;

                //如果在待纵向合并的（小）单元格列表中，最后一个（小）单元格位于表格最底端，则设置合并后的（大）单元格底边框宽度为1
                if (smallCells[smallCells.Count - 1].BorderWidthBottom == 1)
                {
                    smallCells[0].BorderWidthBottom = 1;
                }

                //拆分单元格内部的合并单元格操作时，检查是否需要修正遍历递归层次
                if (parentCell != null)
                {
                    if (parentCell.ChildCount == 1 && row.ChildCount == 1)
                    {
                        TPTextRow parentRow = parentCell.OwnerRow;
                        int cellIndex = parentRow.IndexOf(parentCell);
                        parentRow.ChildElements.Remove(parentCell);
                        parentRow.Cells.Remove(parentCell);
                        parentRow.ChildElements.Insert(cellIndex, smallCells[0]);
                        parentRow.Cells.Insert(cellIndex, smallCells[0]);
                        smallCells[0].OwnerRow = parentRow; //修改合并之后的（大）单元格的所属表格行指向，非常重要
                        smallCells[0].Parent = parentRow; //修改合并之后的（大）单元格的父容器指向，非常重要
                        smallCells[0].Level -= 1; //遍历递归层次减1
                    }
                }

                return smallCells[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 存储待合并的所有单元格的内部段落。
        /// </summary>
        public List<ZYTextParagraph> mergeParas = new List<ZYTextParagraph>();

        /// <summary>
        /// 合并单元格之后，将合并之前的若干个（小）单元格中的内容添加至合并之后的（大）单元格中。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        private void MergeContent(TPTextCell cell)
        {
            try
            {
                if (mergeParas.Count == 0) return;
                cell.ChildElements.Clear();
                foreach (ZYTextParagraph para in mergeParas)
                {
                    cell.ChildElements.Add(para);
                    para.Parent = cell;
                }
                cell.AdjustHeight();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 拆分单元格（已修订完毕） add by myc 2014-02-28 update by myc 2014-04-09
        /// <summary>
        /// 拆分鼠标点击（选中）的某一个（大）单元格为若干个（小）单元格。
        /// </summary>
        /// <param name="splitRows">此单元格内部要拆分成的行数。</param>
        /// <param name="splitColumns">此单元格内部要拆分成的列数。</param>
        public void SplitTBCell(int splitRows, int splitColumns)
        {
            try
            {
                #region 判断能否拆分
                if (SelectedCells.Count > 1)
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("拆分单元格的操作针对的是一个单元格");
                    SelectedCells.Clear();
                    return;
                }

                //待拆分的（父级）单元格
                TPTextCell parentCell = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Cell) as TPTextCell;
                if (parentCell == null) return;

                int tempHeight = parentCell.Height / splitRows; //计算拆分之后的（子级）单元格高度;
                if (tempHeight < TPTextTable.MinCellHeight)
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("拆分之后的单元格高度小于规定的最小值，不能进行拆分单元格操作，请减小拆分的行数");
                    SelectedCells.Clear();
                    return;
                }
                else
                {
                    int tempWidth = parentCell.Width / splitColumns; //计算拆分之后的（子级）单元格宽度;
                    if (tempWidth < TPTextTable.MinCellWidth)
                    {
                        YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("拆分之后的单元格宽度小于规定的最小值，不能进行拆分单元格操作，请减小拆分的列数");
                        SelectedCells.Clear();
                        return;
                    }
                }
                #endregion

                #region 锁定用户界面
                this.BeginUpdate();
                this.BeginContentChangeLog();
                myContent.AutoClearSelection = true;
                #endregion

                #region 执行拆分
                splitParas.Clear();
                if (parentCell.ChildCount > 0)
                {
                    for (int i = 0; i < parentCell.ChildCount; i++)
                    {
                        ZYTextParagraph para = parentCell.ChildElements[i] as ZYTextParagraph;
                        if (para != null && para.ChildCount > 1) //段落内只有一个换行符时不要参与单元格内容拆分
                        {
                            splitParas.Add(para);
                        }
                    }
                }

                List<TPTextRow> childRows = VSplit(parentCell, splitRows);
                if (childRows == null) //splitRows = 1时，纵向上未进行拆分单元格操作
                {
                    List<TPTextCell> smallCells = HSplit(parentCell, splitColumns);
                    SplitContent(smallCells[0]);

                    #region 特殊处理
                    //如果当前单元格为合并单元格，并只是拆分成几列结构，则它合并掉的占位单元格也必须参与拆分
                    if (parentCell.Height > parentCell.OwnerRow.Height)
                    {
                        List<TPTextCell> flagCells = new List<TPTextCell>();
                        flagCells.AddRange(parentCell.HasFlagCells);

                        foreach (TPTextCell smallCell in smallCells)
                        {
                            smallCell.HasFlagCells.Clear();
                        }

                        foreach (TPTextCell flagCell in flagCells)
                        {
                            List<TPTextCell> resultCells = HSplit(flagCell, splitColumns); //拆分占位单元格
                            for (int i = 0; i < resultCells.Count; i++)
                            {
                                smallCells[i].HasFlagCells.Add(resultCells[i]);
                                resultCells[i].OwnerMergeCell = smallCells[i];
                            }
                        }
                    }
                    #endregion
                }
                else //splitRows > 1时，纵向上进行了拆分单元格操作
                {
                    foreach (TPTextRow childRow in childRows)
                    {
                        HSplit(childRow[0], splitColumns);
                    }
                    SplitContent(childRows[0][0]);
                }
                #endregion

                #region 更新用户界面
                this.RefreshSize();
                this.ContentChanged();
                this.EndContentChangeLog();
                this.EndUpdate();
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在垂直方向上将某一个（父级）单元格的内部拆分成若干个嵌套的（子级）表格行，
        /// 并且此时的每一个（子级）表格行的内部仅仅包含一个（子级）单元格。
        /// </summary>
        /// <param name="parentCell">要纵向拆分的（父级）单元格。</param>
        /// <param name="splitRows">此（父级）单元格内部要拆分成的（子级）表格行数。</param>
        public List<TPTextRow> VSplit(TPTextCell parentCell, int splitRows)
        {
            try
            {
                if (splitRows == 1) return null; //此时不进行纵向上的拆分单元格操作，直接返回null作为一个判断标志

                List<TPTextRow> childRows = new List<TPTextRow>(); //存储拆分之后的若干个（子级）表格行
                int tempHeight = parentCell.Height / splitRows; //计算拆分之后的（子级）单元格的高度

                for (int i = 0; i < splitRows; i++)
                {
                    #region 拆分之后的（子级）单元格
                    TPTextCell childCell = new TPTextCell(); //创建新的单元格(左上右下边框宽度都为默认值1)
                    childCell.Width = parentCell.Width;
                    childCell.Selected = parentCell.Selected;
                    childCell.OwnerDocument = this;

                    //拆分之后的最后一个（子级）单元格高度作特殊调整，确保其与拆分之前的（父级）单元格在底端上保持边界对齐
                    if (i == splitRows - 1)
                    {
                        childCell.Height = parentCell.Height - tempHeight * (splitRows - 1);
                    }
                    else
                    {
                        childCell.Height = tempHeight;
                    }

                    //非表格最右侧的（父级）单元格要调整拆分之后的（子级）单元格的右边框宽度为0
                    if (parentCell.BorderWidthRight == 0)
                    {
                        childCell.BorderWidthRight = 0;
                    }

                    //非表格最底端的（父级）单元格要调整拆分之后的（子级）单元格的底边框宽度为0，反之则要调整拆分之后的非最后一个（子级）单元格的底边框宽度为0
                    if (parentCell.BorderWidthBottom == 1)
                    {
                        if (i != splitRows - 1)
                        {
                            childCell.BorderWidthBottom = 0;
                        }
                    }
                    else
                    {
                        childCell.BorderWidthBottom = 0;
                    }
                    #endregion

                    #region 拆分之后的（子级）表格行
                    TPTextRow childRow = new TPTextRow();
                    childRow.Cells.Add(childCell);
                    childRow.ChildElements.Add(childCell);
                    childRow.Parent = parentCell;
                    childRow.OwnerDocument = this;
                    childRow.OwnerTable = parentCell.OwnerRow.OwnerTable;
                    childRow.Height = childCell.Height;
                    childRow.Width = childCell.Width;
                    childRow.Columns = 1;

                    //更新（子级）表格行的内部包含的（子级）单元格宽度数组属性
                    int[] widths = new int[childRow.Columns];
                    for (int j = 0; j < childRow.Cells.Count; j++)
                    {
                        widths[j] = childRow[j].Width;
                    }
                    childRow.Widths = widths;
                    #endregion

                    //关联（子级）单元格与（子级）表格行
                    childCell.Parent = childRow;
                    childCell.OwnerRow = childRow;
                    childRows.Add(childRow);
                }

                #region 拆分之后的（父级）单元格
                parentCell.ChildElements.Clear();
                parentCell.ChildElements.InsertRange(0, childRows);
                parentCell.ContentWidth += parentCell.PaddingLeft + parentCell.PaddingRight;
                parentCell.PaddingTop = 0;
                parentCell.PaddingBottom = 0;
                parentCell.PaddingLeft = 0;
                parentCell.PaddingRight = 0;
                #endregion

                return childRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在水平方向上将某一个（大）单元格的内部拆分成若干个同级的（小）单元格，
        /// 并将此（大）单元格从其所属表格行内移除。
        /// </summary>
        /// <param name="bigCell">要横向拆分的（大）单元格。</param>
        /// <param name="splitColumns">此（大）单元格内部要拆分成的列数。</param>
        public List<TPTextCell> HSplit(TPTextCell bigCell, int splitColumns)
        {
            try
            {
                List<TPTextCell> smallCells = new List<TPTextCell>(); //存储拆分之后的若干个（小）单元格
                if (splitColumns == 1)
                {
                    smallCells.Add(bigCell);
                    return smallCells; //此时不进行横向上的拆分单元格操作，直接返回
                }

                int tempWidth = bigCell.Width / splitColumns; //计算拆分之后的（小）单元格的宽度

                for (int i = 0; i < splitColumns; i++)
                {
                    #region 拆分之后的同级（小）单元格
                    TPTextCell smallCell = new TPTextCell(); //创建新的单元格(左上右下边框宽度都为默认值1)
                    smallCell.Height = bigCell.Height;
                    smallCell.Selected = bigCell.Selected;
                    smallCell.OwnerDocument = this;

                    //拆分之后的最后一个（小）单元格宽度作特殊调整，确保其与拆分之前的（大）单元格在右侧上保持边界对齐
                    if (i == splitColumns - 1)
                    {
                        smallCell.Width = bigCell.Width - tempWidth * (splitColumns - 1);
                    }
                    else
                    {
                        smallCell.Width = tempWidth;
                    }

                    //非表格最底端的（大）单元格要调整拆分之后的同级（小）单元格的底边框宽度为0
                    if (bigCell.BorderWidthBottom == 0)
                    {
                        smallCell.BorderWidthBottom = 0;
                    }

                    //非表格最右侧的（大）单元格要调整拆分之后的同级（小）单元格的右边框宽度为0，反之则要调整拆分之后的非最后一个（小）单元格的右边框宽度为0
                    if (bigCell.BorderWidthRight == 0)
                    {
                        smallCell.BorderWidthRight = 0;
                    }
                    else
                    {
                        if (i != splitColumns - 1)
                        {
                            smallCell.BorderWidthRight = 0;
                        }
                    }
                    #endregion

                    if (bigCell.ChildCount == 0) //特殊情况下的占位单元格拆分
                    {
                        smallCell.ChildElements.Clear();
                        smallCell.Lines.Clear();
                    }

                    //关联（小）单元格与（大）单元格所属表格行
                    smallCell.Parent = bigCell.OwnerRow;
                    smallCell.OwnerRow = bigCell.OwnerRow;
                    smallCells.Add(smallCell);
                }

                #region 拆分之后的同级（大）单元格所属表格行
                TPTextRow bigRow = bigCell.OwnerRow;
                int cellIndex = bigRow.IndexOf(bigCell); //（大）单元格在其所属表格行中的索引号
                bigRow.Cells.RemoveAt(cellIndex);
                bigRow.Cells.InsertRange(cellIndex, smallCells);
                bigRow.ChildElements.RemoveAt(cellIndex);
                bigRow.ChildElements.InsertRange(cellIndex, smallCells);
                bigRow.Columns += splitColumns - 1;

                //设置（大）单元格所属表格行的内部包含的（小）单元格宽度数组属性
                int[] widths = new int[bigRow.Columns];
                for (int j = 0; j < bigRow.Cells.Count; j++)
                {
                    widths[j] = bigRow[j].Width;
                }
                bigRow.Widths = widths;
                #endregion

                return smallCells;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 存储待拆分的单元格的内部段落。
        /// </summary>
        List<ZYTextParagraph> splitParas = new List<ZYTextParagraph>();

        /// <summary>
        /// 拆分单元格之后，将拆分之前的（大）单元格中的内容平摊添加至拆分之后第一行内各个（小）单元格中。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        private void SplitContent(TPTextCell cell)
        {
            try
            {
                if (splitParas.Count == 0) return;
                cell.ChildElements.Clear();
                foreach (ZYTextParagraph para in splitParas)
                {
                    cell.ChildElements.Add(para);
                    para.Parent = cell;
                }
                cell.AdjustHeight();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 绘制单元格斜线（已修订完毕） add by myc 2014-05-14
        /// <summary>
        /// 在某个单元格内绘制指定样式的斜线。
        /// </summary>
        /// <param name="lineStyle">待绘制的斜线样式代号。</param>
        /// <returns></returns>
        public string DrawItalicLine(int lineStyle)
        {
            try
            {
                TPTextCell currCell = myContent.GetParentByElement(myContent.CurrentElement, ZYTextConst.c_Cell) as TPTextCell;
                if (currCell == null) return "光标必须在表格内的单元格中";

                #region 锁定用户界面
                this.BeginUpdate();
                this.BeginContentChangeLog();
                myContent.AutoClearSelection = true;
                #endregion

                //斜线类别具体说明：0表示没有线；1表示左上到右下的斜线；2表示右上到左下的斜线；3表示左上到右下的两条斜线
                currCell.ItalicLineStyleInCell = (ItalicLineStyle)Enum.Parse(typeof(ItalicLineStyle), lineStyle.ToString());

                #region 更新用户界面
                this.RefreshSize();
                this.ContentChanged();
                this.EndContentChangeLog();
                this.EndUpdate();
                #endregion

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 检查能否插入表格（已修订完毕） add by myc 2014-05-22
        /// <summary>
        /// 文书录入中的结构化元素内部禁止插入表格，避免文书数据丢失。
        /// </summary>
        /// <returns></returns>
        private bool CanInsertTable()
        {
            try
            {
                bool flag = true;
                if (myContent.CurrentElement != null)
                {
                    if (myContent.CurrentElement.Parent is ZYTextParagraph)
                    {
                        ZYTextParagraph para = myContent.CurrentElement.Parent as ZYTextParagraph;
                        foreach (ZYTextElement myEle in para.ChildElements)
                        {
                            if (myEle is ZYTextBlock || myEle is ZYElement)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 处理表格跨页绘制 add by myc 2014-05-29
        /// <summary>
        /// 当前页底端有表格跨页时，下一页的文档正文区域高度增量。
        /// </summary>
        public static int PageBodyHeightIncrement = 0;

        /// <summary>
        /// （未处理合并与拆分单元格）编辑器视图区域绘制文档时，遇到表格跨页自动进行表格分页处理——>基于Windows操作系统底层绘制滚动图形原理。
        /// </summary>
        /// <param name="myLine">当前遍历的ZYTextDiv的文本行。</param>
        /// <param name="myLines">ZYTextDiv的文本行列表。</param>
        /// <param name="divRealTop">ZYTextDiv的绝对顶端位置</param>
        public void AutoPagingForTable(ZYTextLine myLine, ArrayList myLines, int divRealTop)
        {
            try
            {
                if (myLine.Container is TPTextRow) //如果当前文本行对象的所属容器为表格行，则判断它是否跨页并作相应处理
                {
                    int currPageBottom = this.Pages[this.PageIndex].Bottom; //当前页的底端

                    if (this.PageIndex == this.Pages.Count - 1) //如果是最后一页则需调整currPageBottom之后才能往下判断是否跨页
                    {
                        currPageBottom += PageBodyHeightIncrement;
                    }

                    if (myLine.RealTop < currPageBottom) //当前文本行对象在当前绘制页内
                    {
                        if (myLine.RealBottom >= currPageBottom) //如果当前文本行对象的底端溢出，则要将它移至下一页绘制，注意这种情况下肯定有下一页
                        {
                            #region 当前文本行对象——>下一页的第一个文本行对象
                            int oldRealTop = myLine.RealTop;
                            myLine.Top = currPageBottom; //当前绘制页底端也是下一页的顶端（文档分割坐标系分割文档区域，但Y轴方向上的坐标是连续的）
                            myLine.RealTop = divRealTop + myLine.Top; //（表格行）文本行的绝对顶端位置等于ZYTextDiv绝对顶端位置 + 相对偏移高度
                            PageBodyHeightIncrement = myLine.RealTop - oldRealTop;
                            //MessageBox.Show(PageBodyHeightIncrement.ToString());
                            TPTextRow currRow = myLine.Container as TPTextRow;
                            foreach (TPTextCell cell in currRow)
                            {
                                foreach (ZYTextLine line in cell.Lines) //单元格的文本行列表存储段落——>注意段落在单元格内的相对偏移高度为内间距
                                {
                                    line.RealTop += myLine.RealTop - oldRealTop; //——>调整单元格内段落内部元素所属文本行对象相对单元格的偏移高度，表格跨页时的单元格内光标正确定位
                                    foreach (ZYTextElement ele in line.Elements) //遍历段落内部元素 
                                    {
                                        //ele.Top = myLine.RealTop - oldRealTop; //调整段落内部元素在段落中的相对偏移高度
                                    }
                                }
                            }

                            //分页辅助线对于基本表格暂用底边框宽度处理，后期再作调整
                            if (currRow.OwnerTable.IndexOf(currRow) != 0) //表格第一个表格行跨页时不作单元格分页辅助线绘制
                            {
                                TPTextRow preRow = currRow.OwnerTable.AllRows[currRow.OwnerTable.IndexOf(currRow) - 1];
                                foreach (TPTextCell cell in preRow)
                                {
                                    cell.BorderWidthBottom = 1;
                                }
                            }
                            #endregion

                            #region 下一页文本行对象——>从下一页的第二个文本行对象开始
                            int currLineIndex = myLines.IndexOf(myLine);
                            for (int i = currLineIndex + 1; i < myLines.Count; i++)
                            {
                                ZYTextLine innerLine = myLines[i] as ZYTextLine;
                                if (innerLine.Container is TPTextRow) //当前文本行所属容器为表格行
                                {
                                    innerLine.Top += myLine.RealTop - oldRealTop;
                                    innerLine.RealTop = divRealTop + innerLine.Top;
                                    TPTextRow row = innerLine.Container as TPTextRow;
                                    foreach (TPTextCell cell in row)
                                    {
                                        foreach (ZYTextLine line in cell.Lines) //单元格的文本行列表存储段落——>注意段落在单元格内的相对偏移高度为内间距
                                        {
                                            line.RealTop += myLine.RealTop - oldRealTop; //——>调整单元格内段落内部元素所属文本行对象相对单元格的偏移高度，表格跨页时的单元格内光标正确定位
                                            foreach (ZYTextElement ele in line.Elements) //遍历段落内部元素
                                            {
                                                //ele.Top = myLine.RealTop - oldRealTop; //调整段落内部元素在段落中的相对偏移高度
                                            }
                                        }
                                    }
                                    //如果下一页中底端有表格行跨页，等到滚动条滚动到下一页时，在绘制时会以同样的方式进行表格分页处理
                                }
                                else if (innerLine.Container is ZYTextParagraph) //文档根元素的直属段落
                                {
                                    innerLine.Top += myLine.RealTop - oldRealTop;
                                    innerLine.RealTop = divRealTop + innerLine.Top; //（段落）文本行的绝对顶端位置等于ZYTextDiv绝对顶端位置 + 相对偏移高度
                                    //无须进行下一页底端判断
                                }
                            }
                            #endregion
                        }
                        else //当前绘制页内的不跨页文本行对象消除分页辅助线
                        {
                            #region 判断是否需要绘制或消除分页辅助线
                            int nextPageTop = 0;
                            ZYTextLine nextLine = null;
                            if (this.Pages.Count - 1 > this.PageIndex) //存在下一页
                            {
                                nextPageTop = this.Pages[this.PageIndex + 1].Top; //下一页的顶端位置
                                if (myLines.IndexOf(myLine) + 1 < myLines.Count) //防止越界异常
                                {
                                    nextLine = myLines[myLines.IndexOf(myLine) + 1] as ZYTextLine;
                                }
                            }

                            TPTextRow currRow = myLine.Container as TPTextRow;
                            TPTextTable currTB = currRow.OwnerTable;

                            if (!currTB.HiddenAllBorder)
                            {
                                foreach (TPTextCell cell in currRow)
                                {
                                    if (currTB.IndexOf(currRow) != currTB.ChildCount - 1) //非表格最后一行
                                    {
                                        if (this.Pages.Count <= 1) continue;
                                        cell.BorderWidthBottom = 0;
                                        if (nextLine != null && nextLine.Container is TPTextRow)
                                        {
                                            //分页线位置是以段落文本行计算出来的，而有的段落是包裹在表格中的单元格内的
                                            //注意一个顺序——>如果myLine需要绘制分页辅助线，则nextLine一定跨页，又nextLine是在遍历myLine之后，
                                            //并且遍历myLine时，nextLine的RealBottom仍是原来的值，所以可与currPageBottom比较
                                            if (nextLine.RealBottom >= currPageBottom)
                                            {
                                                cell.BorderWidthBottom = 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        cell.BorderWidthBottom = 1; //直接这么写会导致设置表格属性中的全部隐藏边框不正确
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 单元格内光标移动控制——>Tab键 add by myc 2014-06-05
        /// <summary>
        /// 当在某一个单元格中按下键盘上的TAB键时，将在当前表格中依次移动光标至下一个单元格内，
        /// 到表格内的最后一个单元格时又跳回至表格内的第一个单元格中。
        /// ——>本方法依据文档对象的myElements存储的文本字符是严格按照顺序来的。
        /// </summary>
        private void InsertTABMoveCaret()
        {
            try
            {
                ZYTextElement currEle = this.Content.CurrentElement;
                if (currEle != null)
                {
                    if (currEle.Parent.Parent is TPTextCell)
                    {
                        TPTextCell currCell = currEle.Parent.Parent as TPTextCell;
                        int index = HBFElements.IndexOf(currEle);
                        for (int i = index; i < HBFElements.Count; i++) //注意文档对象的myElements存储的是所有可见的文本字符元素
                        {
                            ZYTextParagraph para = (HBFElements[i] as ZYTextElement).Parent as ZYTextParagraph;
                            if (currCell.ChildElements.IndexOf(para) == currCell.ChildCount - 1) //最后一个段落
                            {
                                if ((HBFElements[i] is ZYTextEOF)) //最后一个元素肯定是回车符
                                {
                                    if ((HBFElements[i + 1] as ZYTextElement).Parent.Parent is TPTextCell)
                                    {
                                        TPTextCell nextCell = (HBFElements[i + 1] as ZYTextElement).Parent.Parent as TPTextCell;
                                        if (nextCell.OwnerRow.OwnerTable.GetContentBounds() != currCell.OwnerRow.OwnerTable.GetContentBounds())
                                        {
                                            TPTextTable currTB = currCell.OwnerRow.OwnerTable;
                                            TPTextCell firstCell = currTB.AllRows[0][0];
                                            ZYTextElement element = null;
                                            InnerGetFirstElement(firstCell, ref element);
                                            this.Content.MoveSelectStart(element);
                                        }
                                        else //下一个文本字符元素仍然在当前表格中
                                        {
                                            this.Content.MoveSelectStart((HBFElements[i + 1] as ZYTextElement));
                                        }
                                    }
                                    else //下一个文本字符元素不在当前表格中
                                    {
                                        TPTextTable currTB = currCell.OwnerRow.OwnerTable;
                                        TPTextCell firstCell = currTB.AllRows[0][0];
                                        ZYTextElement element = null;
                                        InnerGetFirstElement(firstCell, ref element);
                                        this.Content.MoveSelectStart(element);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从指定单元格向孩子层次递归得到它内部容纳的第一个文档基本元素。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        /// <param name="element">文档基本元素引用传参。</param>
        /// <returns></returns>
        private bool InnerGetFirstElement(TPTextCell cell, ref ZYTextElement element)
        {
            try
            {
                if (cell.ChildElements[0] is TPTextRow) //拆分单元格递归调用
                {
                    TPTextCell innerCell = (cell.ChildElements[0] as TPTextRow)[0];
                    if (InnerGetFirstElement(innerCell, ref element)) return true;
                    return false;
                }
                else //基本单元格或普通（非拆分的）合并单元格
                {
                    element = (cell.ChildElements[0] as ZYTextParagraph).FirstElement;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion





        #region 重构并优化新版页眉、页脚与正文统一管理例程 add by myc 2014-07-22
        //——>于 2014-07-29 封装页眉页脚对外接口
        /// <summary>
        /// 存储所有文档页的页眉根元素。
        /// </summary>
        private List<ZYDocumentHeader> RootDocumentElementsInHeader = new List<ZYDocumentHeader>();

        /// <summary>
        /// 存储所有文档页的页脚根元素。
        /// </summary>
        private List<ZYDocumentFooter> RootDocumentElementsInFooter = new List<ZYDocumentFooter>();

        /// <summary>
        /// 标识当前正在编辑的文档区域所属类别，分为文档页眉区（数值0代表）、文档正文区（数值1代表）和文档页脚区（数值2代表）。
        /// </summary>
        private int editingAreaFlag = 1;
        /// <summary>
        /// 返回当前正在编辑的文档区域所属类别，分为文档页眉区（数值0代表）、文档正文区（数值1代表）和文档页脚区（数值2代表）。
        /// </summary>
        public int EditingAreaFlag
        {
            get { return editingAreaFlag; }
        }

        /// <summary>
        /// 存储文档编辑区的根元素对象——>在鼠标按下和双击事件处理例程中构建此列表。
        /// </summary>
        private List<ZYTextContainer> editingAreaRootElements = new List<ZYTextContainer>();
        /// <summary>
        /// 返回当前文档编辑区的内容管理根元素。
        /// </summary>
        public ZYTextContainer HBFDocumentElement
        {
            get { return editingAreaRootElements[editingAreaFlag]; }
        }

        /// <summary>
        /// 文档编辑区内部所有文本类型元素列表的集合，包含三个数组列表，分别存储当前正在编辑的文档页眉区、文档正文区和文档页脚区的所有文本类型元素。
        /// </summary>
        private List<ArrayList> editingAreaElements = new List<ArrayList>();
        /// <summary>
        /// 返回当前文档编辑区内的所有文本类型元素。
        /// </summary>
        public ArrayList HBFElements
        {
            get { return editingAreaElements[editingAreaFlag]; }
        }

        /// <summary>
        /// 文档编辑区内部文档行列表的集合，包含三个数组列表，分别存储当前正在编辑的文档页眉区、文档正文区和文档页脚区的所有文档行对象。
        /// </summary>
        private List<ArrayList> editingAreaLines = new List<ArrayList>();
        /// <summary>
        /// 返回当前文档编辑区内的所有文档行对象。
        /// </summary>
        public ArrayList HBFLines
        {
            get { return editingAreaLines[editingAreaFlag]; }
        }

        /// <summary>
        /// 向当前文档页中插入新的空白页眉。
        /// </summary>
        public void InsertHeader()
        {
            try
            {
                int currPageIndex = this.PageIndex;
                ZYDocumentHeader RootDocumentElementInHeader = this.RootDocumentElementsInHeader[currPageIndex];
                ZYTextParagraph para = new ZYTextParagraph();
                RootDocumentElementInHeader.ChildElements.Add(para);
                para.Parent = RootDocumentElementInHeader;
                this.ContentChanged();
                editingAreaFlag = 0;
                editingAreaElements[0] = RootDocumentElementInHeader.InnerElements;
                editingAreaLines[0] = RootDocumentElementInHeader.InnerLines;
                this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                UpdateTextCaret(); //更新光标至页眉区域
                this.OwnerControl.Focus();
                this.OwnerControl.Invalidate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 向当前文档页中插入新的空白页脚。
        /// </summary>
        public void InsertFooter()
        {
            try
            {
                int currPageIndex = this.PageIndex;
                ZYDocumentFooter RootDocumentElementInFooter = this.RootDocumentElementsInFooter[currPageIndex];
                ZYTextParagraph para = new ZYTextParagraph();
                RootDocumentElementInFooter.ChildElements.Add(para);
                para.Parent = RootDocumentElementInFooter;
                this.ContentChanged();
                editingAreaFlag = 2;
                editingAreaElements[2] = RootDocumentElementInFooter.InnerElements;
                editingAreaLines[2] = RootDocumentElementInFooter.InnerLines;
                this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                UpdateTextCaret(); //更新光标至页脚区域
                this.OwnerControl.Focus();
                this.OwnerControl.Invalidate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 加载页眉模板，替换文档中所有的页眉区域。
        /// </summary>
        public void LoadHeaderTemplet(XmlDocument doc)
        {
            try
            {
                XmlElement header = doc.SelectSingleNode("document/body") as XmlElement;
                string str = header.OuterXml;
                str = str.Replace("<body", "<header");
                str = str.Replace("body>", "header>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.LoadXml(str);
                for (int k = 0; k < this.RootDocumentElementsInHeader.Count; k++)
                {
                    //重新构建页眉区域的文档根元素
                    this.RootDocumentElementsInHeader[k] = this.CreateElementByXML(xmlDoc.DocumentElement as System.Xml.XmlElement) as ZYDocumentHeader;
                }
                this.ContentChanged();
                this.OwnerControl.Invalidate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 加载页脚模板，替换文档中的所有页脚区域。
        /// </summary>
        public void LoadFooterTemplet(XmlDocument doc)
        {
            try
            {
                XmlElement footer = doc.SelectSingleNode("document/body") as XmlElement;
                string str = footer.OuterXml;
                str = str.Replace("<body", "<footer");
                str = str.Replace("body>", "footer>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.LoadXml(str);
                for (int k = 0; k < this.RootDocumentElementsInFooter.Count; k++)
                {
                    //重新构建页脚区域的文档根元素
                    this.RootDocumentElementsInFooter[k] = this.CreateElementByXML(xmlDoc.DocumentElement as System.Xml.XmlElement) as ZYDocumentFooter;
                }
                this.ContentChanged();
                this.OwnerControl.Invalidate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 为当前正在创建的文档页分配页眉根元素，并对此页眉根元素内的所有文档元素重新进行排布和分行，从而得到创建当前文档页的所需页眉实际高度，为文档正文分页提供条件。
        /// </summary>
        /// <param name="currPageCount">当前文档页集合中的已创建好的文档页数量。</param>
        /// <returns>返回当前正在创建的文档页的页眉高度。</returns>
        public int RefreshLineInHeader(int currPageCount)
        {
            try
            {
                if (RootDocumentElementsInHeader.Count == 0) return 0; //页眉根元素列表为空，直接返回0

                #region 构建页眉区域的根元素
                ZYDocumentHeader RootDocumentElementInHeader = null;
                int top = 0; //页眉根元素顶端位置
                if (currPageCount + 1 > RootDocumentElementsInHeader.Count) //需要创建新的页眉根元素
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_Header));
                    //以上一个文档页的页眉作为新建文档页的页眉参考
                    ZYTextElement.ElementsToXML((RootDocumentElementsInHeader[RootDocumentElementsInHeader.Count - 1] as ZYTextContainer).ChildElements, xmlDoc.DocumentElement);
                    top = RootDocumentElementsInHeader[RootDocumentElementsInHeader.Count - 1].Top
                        + RootDocumentElementsInHeader[RootDocumentElementsInHeader.Count - 1].Height;

                    if (xmlDoc.DocumentElement != null)
                    {
                        //构建新的页眉根元素
                        RootDocumentElementInHeader = this.CreateElementByXML(xmlDoc.DocumentElement as XmlElement) as ZYDocumentHeader;

                        //2014-08-26 add by myc 添加原因：解决宜昌中心人民医院页眉区空白显示问题——>属性传递
                        RootDocumentElementsInHeader[RootDocumentElementsInHeader.Count - 1].Attributes.CopyTo(RootDocumentElementInHeader.Attributes);
                        RootDocumentElementsInHeader.Add(RootDocumentElementInHeader);

                        //2014-08-27 add by myc 添加原因：解决宜昌中心人民医院页眉区空白显示问题——>判断属性
                        if (RootDocumentElementInHeader.Attributes.Count > 0)
                        {
                            foreach (ZYAttribute zyAttribute in RootDocumentElementInHeader.Attributes)
                            {
                                if (zyAttribute.Name == "IsConfigHeaderHeightInYiChan")
                                {
                                    //新建文档页时需要重新配置空白页眉高度
                                    //if (zyAttribute.ValueString != "0") return Convert.ToInt32(zyAttribute.ValueString); //已配置空白高度属性直接返回值
                                    int resultHeight = myPages.StandardHeight - footerHeightInYiChan - ConfigPageHeightInYiChan[currPageCount];
                                    zyAttribute.SetValue(resultHeight.ToString()); //保存这个精确计算出来的空白页眉高度值
                                    return resultHeight;
                                }
                            }
                        }
                    }
                }
                else //不需要创建新的页眉根元素
                {
                    //得到页眉区域或页脚区域的文档根元素
                    if (currPageCount >= 1)
                    {
                        top = RootDocumentElementsInHeader[currPageCount - 1].Top
                            + RootDocumentElementsInHeader[currPageCount - 1].Height;
                    }
                    RootDocumentElementInHeader = RootDocumentElementsInHeader[currPageCount];

                    //2014-08-27 add by myc 添加原因：解决宜昌中心人民医院页眉区空白显示问题
                    if (RootDocumentElementInHeader.Attributes.Count > 0)
                    {
                        foreach (ZYAttribute zyAttribute in RootDocumentElementInHeader.Attributes)
                        {
                            if (zyAttribute.Name == "IsConfigHeaderHeightInYiChan")
                            {
                                if (zyAttribute.ValueString != "0") return Convert.ToInt32(zyAttribute.ValueString); //已配置空白高度属性直接返回值
                                int resultHeight = myPages.StandardHeight - footerHeightInYiChan - ConfigPageHeightInYiChan[currPageCount];
                                zyAttribute.SetValue(resultHeight.ToString()); //保存这个精确计算出来的空白页眉高度值
                                return resultHeight;
                            }
                        }
                    }
                }
                #endregion

                #region 对页眉根元素内的所有文档元素重新进行分行
                if (RootDocumentElementInHeader != null)
                {
                    RootDocumentElementInHeader.OwnerDocument = this;
                    RootDocumentElementInHeader.UpdateUserLogin();

                    //构建当前页眉根元素的可见元素列表——>光标定位
                    int index = 0;
                    RootDocumentElementInHeader.InnerElements.Clear();
                    RootDocumentElementInHeader.AddElementToList(RootDocumentElementInHeader.InnerElements, true);
                    foreach (ZYTextElement myElement in RootDocumentElementInHeader.InnerElements)
                    {
                        myElement.Visible = true;
                        myElement.Index = index;
                        index++;
                    }

                    //设置页眉根元素的左上角位置
                    RootDocumentElementInHeader.Left = 0;
                    RootDocumentElementInHeader.Top = top;
                    RootDocumentElementInHeader.RefreshSize();
                    RootDocumentElementInHeader.InnerLines.Clear();
                    RootDocumentElementInHeader.RefreshLine();

                    isConfigHeaderHeightInYiChan = false; //2014-08-29 设置此标志，以告知后续需要准确计算分页线位置（非宜昌中心人民医院单独空白页眉配置）

                    return RootDocumentElementInHeader.Height;
                }
                #endregion

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int footerHeightInYiChan = 0; //add by myc 2014-08-27 添加原因：处理宜昌中心医院正文上端空白问题
        /// <summary>
        /// 宜昌中心医院处理正文上端空白问题时必须使用的页脚高度。
        /// </summary>
        public int FooterHeightInYiChan
        {
            get { return footerHeightInYiChan; }
            set { footerHeightInYiChan = value; }
        }


        /// <summary>
        /// 为当前正在创建的文档页分配页脚根元素，并对此页脚根元素内的所有文档元素重新进行排布和分行，从而得到创建当前文档页的所需页脚实际高度，为文档正文分页提供条件。
        /// </summary>
        /// <param name="currPageCount">当前文档页集合中的已创建好的文档页数量。</param>
        /// <returns>返回当前正在创建的文档页的页脚高度。</returns>
        public int RefreshLineInFooter(int currPageCount)
        {
            try
            {
                if (RootDocumentElementsInFooter.Count == 0) return 0; //页脚根元素列表为空，直接返回0

                #region 构建页脚区域的根元素
                ZYDocumentFooter RootDocumentElementInFooter = null;
                int top = 0; //页脚根元素顶端位置
                bool flag = false; //新创建的文档页分配的页脚根元素需要对所有文档页进行页码校正
                if (currPageCount + 1 > RootDocumentElementsInFooter.Count) //需要创建新的页脚根元素
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_Footer));
                    //以上一个文档页的页脚作为新建文档页的页脚参考
                    ZYTextElement.ElementsToXML((RootDocumentElementsInFooter[RootDocumentElementsInFooter.Count - 1] as ZYTextContainer).ChildElements, xmlDoc.DocumentElement);
                    top = RootDocumentElementsInFooter[RootDocumentElementsInFooter.Count - 1].Top
                        + RootDocumentElementsInFooter[RootDocumentElementsInFooter.Count - 1].Height;

                    if (xmlDoc.DocumentElement != null)
                    {
                        //构建新的页脚根元素
                        RootDocumentElementInFooter = this.CreateElementByXML(xmlDoc.DocumentElement as XmlElement) as ZYDocumentFooter;
                        RootDocumentElementsInFooter.Add(RootDocumentElementInFooter);
                    }
                    flag = true;
                }
                else //不需要创建新的页脚根元素
                {
                    //得到页脚区域或页脚区域的文档根元素
                    if (currPageCount >= 1)
                    {
                        top = RootDocumentElementsInFooter[currPageCount - 1].Top
                            + RootDocumentElementsInFooter[currPageCount - 1].Height;
                    }
                    RootDocumentElementInFooter = RootDocumentElementsInFooter[currPageCount];
                }
                #endregion

                #region 对页脚根元素内的所有文档元素重新进行分行
                if (RootDocumentElementInFooter != null)
                {
                    RootDocumentElementInFooter.OwnerDocument = this;
                    RootDocumentElementInFooter.UpdateUserLogin();

                    //构建当前页脚根元素的可见元素列表——>光标定位
                    int index = 0;
                    RootDocumentElementInFooter.InnerElements.Clear();
                    RootDocumentElementInFooter.AddElementToList(RootDocumentElementInFooter.InnerElements, true);
                    foreach (ZYTextElement myElement in RootDocumentElementInFooter.InnerElements)
                    {
                        myElement.Visible = true;
                        myElement.Index = index;
                        index++;
                    }

                    //设置页脚根元素的左上角位置
                    RootDocumentElementInFooter.Left = 0;
                    RootDocumentElementInFooter.Top = top;
                    RootDocumentElementInFooter.RefreshSize();
                    RootDocumentElementInFooter.InnerLines.Clear();
                    RootDocumentElementInFooter.RefreshLine();

                    if (flag)
                    {
                        this.CorrectPageNumberInFooter(true);
                    }
                    return RootDocumentElementInFooter.Height;
                }
                #endregion

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在文档正文重新进行分页后，并在重新建立页眉、正文和页脚矩形坐标系转换关系之前对页脚区域显示的文档页码执行校正。
        /// 另外，在保存（或打印）文档以及双击鼠标切换页脚编辑区（支持撤销重做栈操作）时也要执行文档页码的校正操作。
        /// <param name="checkFlag">是否进行严格检查（也就是是否检查0~9数字）。</param>
        /// </summary>
        public void CorrectPageNumberInFooter(bool checkFlag)
        {
            try
            {
                if (this.startPageIndex != 0)//如果指定页码，都进入严格检查
                {
                    checkFlag = true;
                }
                for (int i = 0; i < RootDocumentElementsInFooter.Count; i++)
                {
                    ZYDocumentFooter RootDocumentElementInFooter = RootDocumentElementsInFooter[i];
                    if (RootDocumentElementInFooter != null)
                    {
                        if (RootDocumentElementInFooter.ChildCount == 0) continue;
                        int oldTop = RootDocumentElementInFooter.Top; //保存此页脚区域旧顶端位置（为了确保对应的矩形坐标系转换关系不会变）

                        #region 校正页脚区域的文档页码
                        List<ZYTextParagraph> allParas = new List<ZYTextParagraph>();
                        foreach (ZYTextLine innerLine in RootDocumentElementInFooter.InnerLines)
                        {
                            if (innerLine.Container is ZYTextParagraph)
                            {
                                allParas.Add(innerLine.Container as ZYTextParagraph); //从页脚根元素的InnerLines中提取所有的段落元素至allParas中
                            }
                        }
                        if (checkFlag) //严格检查
                        {
                            foreach (ZYTextParagraph para in allParas)
                            {
                                StringBuilder strBuilder = new StringBuilder();
                                para.GetFinalText(strBuilder);
                                if (strBuilder.ToString().Contains("[%pageindex%]")
                                    || strBuilder.ToString().Contains("[%pagecount%]")
                                    || (strBuilder.ToString().Contains("第") && strBuilder.ToString().Contains("页"))
                                    || (strBuilder.ToString().Contains("共") && strBuilder.ToString().Contains("页")))
                                {
                                    #region 2019.11.27-hdf：第一页页码修改后，后面页数相应改变
                                    if (i == 0 && (strBuilder.ToString().Contains("第") && strBuilder.ToString().Contains("页")))
                                    {
                                        string str = strBuilder.ToString();
                                        int start = str.IndexOf("第") + 1;
                                        int end = str.IndexOf("页");
                                        string aaaa = str.Substring(start, end - start);
                                        try
                                        {
                                            this.PageIndexFix = Convert.ToInt32(aaaa);
                                        }
                                        catch (Exception exxxx)
                                        {

                                        }

                                    }
                                    #endregion

                                    ZYTextLine myLine = para.LastElement.OwnerLine;
                                    ArrayList myChars = myLine.Elements;
                                    //2014-08-14 特别注意文档总页数需要与页号修正量PageIndexFix联动设置

                                    if (this.startPageIndex != 0)//2021.01.15 cb 指定页码开始
                                    {
                                        this.PageIndexFix = startPageIndex;
                                        UpdateCharValueInParagraph(UpdateCharValueInParagraph(myChars, '第', '页', "[%pageindex%]", (i + this.PageIndexFix).ToString()),
                                            '共', '页', "[%pagecount%]", (RootDocumentElementsInFooter.Count + this.PageIndexFix - 1).ToString());
                                        UpdateCharValueInParagraph(UpdateCharValueInParagraph(myChars, '第', '页', "0123456789", (i + this.PageIndexFix).ToString()),
                                            '共', '页', "0123456789", (RootDocumentElementsInFooter.Count + this.PageIndexFix - 1).ToString());
                                    }
                                    else
                                    {
                                        UpdateCharValueInParagraph(UpdateCharValueInParagraph(myChars, '第', '页', "[%pageindex%]", (i + this.PageIndexFix).ToString()),
                                            '共', '页', "[%pagecount%]", (RootDocumentElementsInFooter.Count + this.PageIndexFix - 1).ToString());
                                        UpdateCharValueInParagraph(UpdateCharValueInParagraph(myChars, '第', '页', "0123456789", (i + this.PageIndexFix).ToString()),
                                            '共', '页', "0123456789", (RootDocumentElementsInFooter.Count + this.PageIndexFix - 1).ToString());
                                    }

                                }
                            }
                        }
                        else //非严格检查
                        {
                            foreach (ZYTextParagraph para in allParas)
                            {
                                StringBuilder strBuilder = new StringBuilder();
                                para.GetFinalText(strBuilder);
                                if (strBuilder.ToString().Contains("[%pageindex%]")
                                    || strBuilder.ToString().Contains("[%pagecount%]"))
                                {
                                    #region 2019.11.27-hdf：第一页页码修改后，后面页数相应改变
                                    if (i == 0 && (strBuilder.ToString().Contains("第") && strBuilder.ToString().Contains("页")))
                                    {
                                        string str = strBuilder.ToString();
                                        int start = str.IndexOf("第") + 1;
                                        int end = str.IndexOf("页");

                                        string aaaa = str.Substring(start, end - start);
                                        try
                                        {
                                            this.PageIndexFix = Convert.ToInt32(aaaa);
                                        }
                                        catch (Exception exxxx)
                                        {

                                        }

                                    }
                                    #endregion

                                    ZYTextLine myLine = para.LastElement.OwnerLine;
                                    ArrayList myChars = myLine.Elements;
                                    //2014-08-14 特别注意文档总页数需要与页号修正量PageIndexFix联动设置
                                    if (this.startPageIndex != 0)
                                    {
                                        this.PageIndexFix = startPageIndex;
                                        UpdateCharValueInParagraph(UpdateCharValueInParagraph(myChars, '第', '页', "0123456789", (i + this.PageIndexFix).ToString()),
                                            '共', '页', "0123456789", (RootDocumentElementsInFooter.Count + this.PageIndexFix - 1).ToString());
                                    }
                                    else
                                    {
                                        UpdateCharValueInParagraph(UpdateCharValueInParagraph(myChars, '第', '页', "0123456789", (i + this.PageIndexFix).ToString()),
                                            '共', '页', "0123456789", (RootDocumentElementsInFooter.Count + this.PageIndexFix - 1).ToString());
                                    }
                                    //UpdateCharValueInParagraph(UpdateCharValueInParagraph(myChars, '第', '页', "[%pageindex%]", (i + this.PageIndexFix).ToString()),
                                    //    '共', '页', "[%pagecount%]", (RootDocumentElementsInFooter.Count + this.PageIndexFix - 1).ToString());
                                }
                            }
                        }
                        #endregion

                        #region 更新页脚区域的显示内容
                        RootDocumentElementInFooter.OwnerDocument = this;
                        RootDocumentElementInFooter.UpdateUserLogin();

                        //构建页脚区域的可见元素列表——>光标定位
                        int index = 0;
                        RootDocumentElementInFooter.InnerElements.Clear();
                        RootDocumentElementInFooter.AddElementToList(RootDocumentElementInFooter.InnerElements, true);
                        foreach (ZYTextElement myElement in RootDocumentElementInFooter.InnerElements)
                        {
                            myElement.Visible = true;
                            myElement.Index = index;
                            index++;
                        }

                        //设置页脚区域的文档根元素的左上角位置
                        RootDocumentElementInFooter.Left = 0;
                        RootDocumentElementInFooter.Top = oldTop;
                        RootDocumentElementInFooter.RefreshSize();
                        RootDocumentElementInFooter.InnerLines.Clear();
                        RootDocumentElementInFooter.RefreshLine();
                        this.RefreshAllFlag = true; //元素变换位置后会将其Bounds添加至无效区域列表，还有RefreshAllFlag，这些都是控制是否重绘的相关条件

                        if (checkFlag) //2014-07-29 保存（或打印）以及双击鼠标切换页脚编辑区时执行下述操作——>注意保存时的校正文档页码不处理撤销栈操作
                        {
                            editingAreaFlag = 1;
                            this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                            this.OwnerControl.Invalidate();
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新指定段落内满足指定条件的若干文本字符对象的显示值。
        /// </summary>
        /// <param name="myChars">要查找的文本字符对象列表。</param>
        /// <param name="startChar">查找的第一个文本字符。</param>
        /// <param name="endChar">查找的最后一个文本字符</param>
        /// <param name="oldStr">匹配字符串。</param>
        /// <param name="newStr">更新字符串。</param>
        /// <returns></returns>
        private ArrayList UpdateCharValueInParagraph(ArrayList myChars, char startChar, char endChar, string oldStr, string newStr)
        {
            try
            {
                ZYTextParagraph para = (myChars[0] as ZYTextChar).Parent as ZYTextParagraph;
                for (int k = 0; k < myChars.Count; k++)
                {
                    if (myChars[k] is ZYTextChar
                        && (myChars[k] as ZYTextChar).Char == startChar)
                    {
                        int m = k;
                        while (m + 1 < myChars.Count) //遍历查找startChar和endChar在myChars中的具体位置
                        {
                            if (myChars[m + 1] is ZYTextChar
                                && (myChars[m + 1] as ZYTextChar).Char == endChar) break;
                            m++;
                        }

                        bool flag = true;
                        if (m + 1 < myChars.Count && m + 1 - k > 1) //判断myChars[k+1]和myChars[m]是否全被包含在oldStr中
                        {
                            for (int n = k + 1; n < m + 1; n++)
                            {
                                if (!oldStr.Contains((myChars[n] as ZYTextChar).Char))
                                {
                                    if ((myChars[n] as ZYTextChar).Char.ToString().Trim() != "")//edit by lhl 页脚错误格式（过滤掉空格）
                                    {
                                        flag = false;
                                        break;
                                    }

                                }
                            }
                        }
                        else
                        {
                            flag = false;
                        }

                        if (flag) //执行页码校正操作
                        {
                            ArrayList insertChars = this.CreateChars(newStr, para);
                            foreach (ZYTextChar myChar in insertChars)
                            {
                                (myChars[k + 1] as ZYTextChar).Attributes.CopyTo(myChar.Attributes);
                            }

                            if (insertChars.Count > m - k)
                            {
                                for (int n = k + 1; n < m + 1; n++)
                                {
                                    (myChars[n] as ZYTextChar).Char = (insertChars[n - k - 1] as ZYTextChar).Char;
                                }
                                //para.ChildElements.InsertRange(m + 1, insertChars.GetRange(m - k, insertChars.Count - (m - k)));
                                para.InsertRangeBefore(insertChars.GetRange(m - k, insertChars.Count - (m - k)), myChars[m + 1] as ZYTextElement); //支持撤销重做栈——>这里非常重要，模拟更新页码所需多余位数字符的插入动作
                                myChars.InsertRange(m + 1, insertChars.GetRange(m - k, insertChars.Count - (m - k)));
                            }
                            else
                            {
                                int index = 0;
                                for (int i = 0; i < insertChars.Count; i++)
                                {
                                    (myChars[k + 1 + i] as ZYTextChar).Char = (insertChars[i] as ZYTextChar).Char;
                                    if (i == insertChars.Count - 1)
                                    {
                                        index = k + 1 + i + 1;
                                    }
                                }

                                ArrayList delChars = new ArrayList();
                                for (int n = index; n < m + 1; n++)
                                {
                                    //(myChars[n] as ZYTextChar).Parent.ChildElements.Remove(myChars[n] as ZYTextChar);
                                    delChars.Add(myChars[n] as ZYTextChar);
                                }

                                para.RemoveChildRange(delChars); //支持撤销重做栈——>这里非常重要，模拟选定不正确页码多余位数字符执行Delete键删除操作

                                foreach (ZYTextChar myChar in delChars)
                                {
                                    myChars.Remove(myChar);
                                }
                            }
                        }
                        break;
                    }
                }
                return myChars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置文档页眉区域的主标题——>仅针对医院使用的旧版页眉作此处理，医院名称从IYidanEmrHost获取，其实最好写在FromXML中不需要多次刷新视图消耗内存资源。
        /// </summary>
        /// <param name="hospitalName">指定的医院名称。</param>
        public void SetTitle(string hospitalName)
        {
            try
            {
                for (int i = 0; i < RootDocumentElementsInHeader.Count; i++)
                {
                    ZYDocumentHeader RootDocumentElementInHeader = RootDocumentElementsInHeader[i];
                    if (RootDocumentElementInHeader != null && RootDocumentElementInHeader.ChildCount > 0)
                    {
                        System.Xml.XmlDocument headerDocument = new System.Xml.XmlDocument();
                        headerDocument.PreserveWhitespace = true;
                        headerDocument.AppendChild(headerDocument.CreateElement(ZYTextConst.c_Header));
                        ZYTextElement.ElementsToXML(RootDocumentElementInHeader.ChildElements, headerDocument.DocumentElement);
                        RootDocumentElementInHeader.Attributes.ToXML(headerDocument.DocumentElement); //add by myc 2014-07-24 添加原因：兼容旧版页眉主标题替换医院名称需要（同时兼容之前的一期页眉改版）

                        if (headerDocument.DocumentElement.Attributes.Count == 0
                            || (!headerDocument.DocumentElement.HasAttribute("sx_flag")
                                && !headerDocument.DocumentElement.HasAttribute("SX_UseDrawDocumentMode"))) //SX_UseDrawDocumentMode为处理江西九江的页眉空回车符问题
                        {
                            XmlNodeList nodeList = headerDocument.SelectNodes("header/p");
                            for (int j = 0; j < nodeList.Count; j++)
                            {
                                XmlNode node = nodeList[j] as XmlNode;
                                if (j == 0 && node.Name == "p") //页眉区域第一个段落节点
                                {
                                    XmlNodeList spanNodes = node.SelectNodes("span");
                                    if (spanNodes[0] is XmlElement) //找到医院名称这个文本节点进行替换
                                    {
                                        (spanNodes[0] as XmlElement).InnerText = hospitalName;
                                        RootDocumentElementInHeader.FromXML(headerDocument.DocumentElement);
                                        RootDocumentElementInHeader.OwnerDocument = this;
                                        RootDocumentElementInHeader.UpdateUserLogin();
                                        this.ContentChanged();
                                        this.Refresh();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //——>于 2014-07-28 封装字体属性对外接口
        /// <summary>
        /// 编辑器字体属性管理对象。
        /// </summary>
        private CurrentFontProperty fontPropertyManager = new CurrentFontProperty(); //add by myc 2014-07-17 添加原因：新版字体属性控制
        /// <summary>
        /// 返回编辑器字体属性管理对象。
        /// </summary>
        public CurrentFontProperty FontPropertyManager
        {
            get { return fontPropertyManager; }
        }

        /// <summary>
        /// 封装编辑器文档的当前字体属性，提供给【模板工厂】和【文书录入】的【工具栏】中的字体控制区使用。
        /// </summary>
        /// <returns>返回当前字体属性管理对象。</returns>
        public void UpdateCurrentFontProperty()
        {
            try
            {
                if (this.Content.CurrentElement == null) return;
                if (this.Content.SelectLength == 0) //鼠标点击视图界面
                {
                    #region 非选定文本时的字体属性封装
                    ZYTextElement currEle = this.Content.CurrentElement;
                    ZYTextLine currLine = currEle.OwnerLine;
                    if (currLine.Elements.IndexOf(currEle) > 0) //当前光标位置不在段落首部
                    {
                        currEle = currLine.Elements[currLine.Elements.IndexOf(currEle) - 1] as ZYTextElement;
                    }
                    if (!(currEle is ZYTextLineEnd))
                    {
                        this.FontPropertyManager.FontName = currEle is ZYTextChar ? (currEle as ZYTextChar).FontName : (currEle as ZYTextEOF).FontName;
                        this.FontPropertyManager.FontSize = currEle is ZYTextChar ? (currEle as ZYTextChar).FontSize : (currEle as ZYTextEOF).FontSize;
                        this.FontPropertyManager.FontBold = currEle is ZYTextChar ? (currEle as ZYTextChar).FontBold : (currEle as ZYTextEOF).FontBold;
                        this.FontPropertyManager.FontItalic = currEle is ZYTextChar ? (currEle as ZYTextChar).FontItalic : (currEle as ZYTextEOF).FontItalic;
                        this.FontPropertyManager.FontUnderLine = currEle is ZYTextChar ? (currEle as ZYTextChar).FontUnderLine : (currEle as ZYTextEOF).FontUnderLine;
                        this.FontPropertyManager.ForeColor = currEle is ZYTextChar ? (currEle as ZYTextChar).ForeColor : (currEle as ZYTextEOF).ForeColor;
                    }
                    #endregion
                }
                else //鼠标拖选文档元素
                {
                    #region 选定文本时的字体属性封装
                    //可见元素列表中存储的是文本字符Char类型元素或回车符
                    System.Collections.ArrayList currEles = this.Content.GetSelectElements();
                    if (CheckElementsFontProperty(currEles, "FontName")) //字体
                    {
                        this.FontPropertyManager.FontName = currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontName : (currEles[0] as ZYTextEOF).FontName;
                    }
                    else
                    {
                        this.FontPropertyManager.FontName = string.Empty;
                    }

                    if (CheckElementsFontProperty(currEles, "FontSize")) //字号
                    {
                        this.FontPropertyManager.FontSize = currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontSize : (currEles[0] as ZYTextEOF).FontSize;
                    }
                    else
                    {
                        this.FontPropertyManager.FontSize = 0f;
                    }

                    if (CheckElementsFontProperty(currEles, "FontBold")) //加粗
                    {
                        this.FontPropertyManager.FontBold = currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontBold : (currEles[0] as ZYTextEOF).FontBold;
                    }
                    else
                    {
                        this.FontPropertyManager.FontBold = false;
                    }

                    if (CheckElementsFontProperty(currEles, "FontItalic")) //斜体
                    {
                        this.FontPropertyManager.FontItalic = currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontItalic : (currEles[0] as ZYTextEOF).FontItalic;
                    }
                    else
                    {
                        this.FontPropertyManager.FontItalic = false;
                    }

                    if (CheckElementsFontProperty(currEles, "FontUnderLine")) //下划线
                    {
                        this.FontPropertyManager.FontUnderLine = currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontUnderLine : (currEles[0] as ZYTextEOF).FontUnderLine;
                    }
                    else
                    {
                        this.FontPropertyManager.FontUnderLine = false;
                    }

                    if (CheckElementsFontProperty(currEles, "ForeColor")) //文本颜色
                    {
                        this.FontPropertyManager.ForeColor = currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).ForeColor : (currEles[0] as ZYTextEOF).ForeColor;
                    }
                    else
                    {
                        this.FontPropertyManager.ForeColor = Color.Black;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查选定区域内的文本字符某一个字体属性是否一致。
        /// </summary>
        /// <param name="currEles">当前选定区域内的所有文本类型元素。</param>
        /// <param name="checkItem">检查项名称。</param>
        /// <returns></returns>
        private bool CheckElementsFontProperty(System.Collections.ArrayList currEles, string checkItem)
        {
            try
            {
                bool flag = true;
                switch (checkItem)
                {
                    case "FontName":
                        for (int i = 0; i < currEles.Count; i++)
                        {
                            if ((currEles[i] is ZYTextChar ? (currEles[i] as ZYTextChar).FontName : (currEles[i] as ZYTextEOF).FontName)
                                != (currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontName : (currEles[0] as ZYTextEOF).FontName))
                            {
                                flag = false;
                                break;
                            }
                        }
                        break;
                    case "FontSize":
                        for (int i = 0; i < currEles.Count; i++)
                        {
                            if ((currEles[i] is ZYTextChar ? (currEles[i] as ZYTextChar).FontSize : (currEles[i] as ZYTextEOF).FontSize)
                                != (currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontSize : (currEles[0] as ZYTextEOF).FontSize))
                            {
                                flag = false;
                                break;
                            }
                        }
                        break;
                    case "FontBold":
                        for (int i = 0; i < currEles.Count; i++)
                        {
                            if ((currEles[i] is ZYTextChar ? (currEles[i] as ZYTextChar).FontBold : (currEles[i] as ZYTextEOF).FontBold)
                                != (currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontBold : (currEles[0] as ZYTextEOF).FontBold))
                            {
                                flag = false;
                                break;
                            }
                        }
                        break;
                    case "FontItalic":
                        for (int i = 0; i < currEles.Count; i++)
                        {
                            if ((currEles[i] is ZYTextChar ? (currEles[i] as ZYTextChar).FontItalic : (currEles[i] as ZYTextEOF).FontItalic)
                                != (currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontItalic : (currEles[0] as ZYTextEOF).FontItalic))
                            {
                                flag = false;
                                break;
                            }
                        }
                        break;
                    case "FontUnderLine":
                        for (int i = 0; i < currEles.Count; i++)
                        {
                            if ((currEles[i] is ZYTextChar ? (currEles[i] as ZYTextChar).FontUnderLine : (currEles[i] as ZYTextEOF).FontUnderLine)
                                != (currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).FontUnderLine : (currEles[0] as ZYTextEOF).FontUnderLine))
                            {
                                flag = false;
                                break;
                            }
                        }
                        break;
                    case "ForeColor":
                        for (int i = 0; i < currEles.Count; i++)
                        {
                            if ((currEles[i] is ZYTextChar ? (currEles[i] as ZYTextChar).ForeColor : (currEles[i] as ZYTextEOF).ForeColor)
                                != (currEles[0] is ZYTextChar ? (currEles[0] as ZYTextChar).ForeColor : (currEles[0] as ZYTextEOF).ForeColor))
                            {
                                flag = false;
                                break;
                            }
                        }
                        break;
                }

                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置当前鼠标选定区域内的所有文本类型元素的字体属性。
        /// </summary>
        /// <param name="index">属性的内部序号。</param>
        /// <param name="strValue">属性值。</param>
        private void SetSelectionAttributeOld(int index, string strValue)
        {
            try
            {
                if (this.Locked) return;
                this.BeginUpdate();
                this.BeginContentChangeLog();

                System.Collections.ArrayList myList = myContent.GetSelectElements();
                if (myList.Count == 0) //没有选中任何文本类型元素
                {
                    if (this.Content.CurrentElement is ZYTextLineEnd
                        && this.Content.CurrentElement.Parent.ChildCount == 1) return;

                    if (this.Content.CurrentElement is ZYTextEOF
                        && this.Content.CurrentElement.Parent.ChildCount == 1)
                    {
                        myList.Add(this.Content.CurrentElement);
                    }
                }

                #region 开始更新字体属性
                for (int iCount = 0; iCount < myList.Count; iCount++)
                {
                    if (myList[iCount] is ZYTextLineEnd) continue; //跳过软回车符

                    switch (index)
                    {
                        case 0: //字体名称
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontName = strValue;
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontName = strValue;
                            }
                            break;
                        case 1: //字体大小
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontSize = float.Parse(strValue);
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontSize = float.Parse(strValue);
                            }
                            break;
                        case 2: //粗体
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontBold = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontBold = strValue.Equals("1");
                            }
                            break;
                        case 3: //斜体
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontItalic = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontItalic = strValue.Equals("1");
                            }
                            break;
                        case 4: //下划线
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontUnderLine = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontUnderLine = strValue.Equals("1");
                            }
                            break;
                        case 5: //文本颜色
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            break;
                        case 6: //元素的数据名称
                            //myChar.Name = strValue ;
                            break;
                        case 7: //下标
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).Sub = strValue.Equals("1");
                            }
                            break;
                        case 8: //上标
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).Sup = strValue.Equals("1");
                            }
                            break;
                        case 9: //文本背景颜色
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).BackgroundColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            break;
                        case 10: //圈字
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).CircleFont = strValue.Equals("1");
                            }
                            break;
                        default:
                            return;
                    }

                    if (myList[iCount] is ZYTextChar)
                    {
                        ZYTextChar currChar = myList[iCount] as ZYTextChar;
                        currChar.RefreshSize();
                        //如果是ZYTextBlock中的字符，同时设置ZYTextBlock的属性
                        if (currChar.Parent is ZYTextBlock)
                        {
                            ZYTextBlock parent = currChar.Parent as ZYTextBlock;
                            currChar.Attributes.CopyTo(parent.Attributes);
                            parent.UpdateAttrubute();
                        }
                    }
                    else
                    {
                        (myList[iCount] as ZYTextEOF).RefreshSize();
                    }
                }
                #endregion

                myContentChangeLog.strUndoName = "设置属性" + strValue;

                #region add by myc 2014-05-20 新版表格绘制之单元格内部元素改变字体大小时的自适应高度调整
                if (myList.Count > 0)
                {
                    //第一次检查祖父层次容器
                    TPTextCell currCell = (myList[0] as ZYTextElement).Parent.Parent as TPTextCell;
                    if (currCell != null)
                    {
                        currCell.AdjustHeight();
                    }

                    //第二次检查曾祖父层次容器
                    TPTextCell newCell = (myList[0] as ZYTextElement).Parent.Parent.Parent as TPTextCell;
                    if (newCell != null)
                    {
                        newCell.AdjustHeight();
                    }
                }
                #endregion

                this.RefreshLine();
                this.EndContentChangeLog();
                this.EndUpdate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置当前鼠标选定区域内的所有文本类型元素的字体属性。
        /// </summary>
        /// <param name="index">属性的内部序号。</param>
        /// <param name="strValue">属性值。</param>
        private void SetSelectionAttribute(int index, string strValue)
        {
            try
            {
                if (this.Locked) return;

                System.Collections.ArrayList myList = myContent.GetSelectElements();
                if (myList.Count == 0) //没有选中任何文本类型元素
                {
                    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("没有选中任何文本字符，不能进行设置字体属性操作");
                    return;
                }

                this.BeginUpdate();
                this.BeginContentChangeLog();

                if (this.SelectedCells.Count == 0
                    && this.GetOwnerCell(HBFElements[this.Content.SelectStart + this.Content.SelectLength] as ZYTextElement) != null)
                {
                    //选定元素所处位置具体说明——>
                    // 1）选定元素位于同一个表格内并且只有一个单元格被点击（此时selectingAreaInOneTable = true && myDocument.SelectedCells.Count == 0）
                    this.Content.SetSelectingAreaAttribute(index, strValue, true);
                }
                else
                {
                    //选定元素所处位置具体说明——>
                    // 1）选定元素不位于任何一个表格内（此时selectingAreaInOneTable = false）
                    // 2）选定元素位于同一个表格内并且有若干个单元格被选中（此时selectingAreaInOneTable = true && myDocument.SelectedCells.Count > 1）
                    // 3）选定元素不位于同一个表格内（存在交叉选定文档元素，此时selectingAreaInOneTable = false）
                    this.Content.SetSelectingAreaAttribute(index, strValue, false);
                }

                myContentChangeLog.strUndoName = "设置属性" + strValue;
                this.RefreshLine();
                this.EndContentChangeLog();
                this.EndUpdate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //——>于 2014-07-29 封装坐标转换对外接口
        /// <summary>
        /// 确定指定的点是否包含在当前文档编辑区内某一个矩形坐标转换关系对象的原始矩形区域中。
        /// </summary>
        /// <param name="x">指定点的X坐标。</param>
        /// <param name="y">指定点的Y坐标。</param>
        /// <returns>返回找到的原始矩形区域的索引序号。</returns>
        public int ContainsSourcePoint(int x, int y)
        {
            try
            {
                List<SimpleRectangleTransform> currTransforms = myOwnerControl.PagesTransform.GetHBFTransforms(editingAreaFlag);
                for (int i = 0; i < currTransforms.Count; i++)
                {
                    SimpleRectangleTransform transform = currTransforms[i];
                    Rectangle rect = transform.SourceRect;

                    //2014-07-29 类似Word中的文档视图外围边界溢出控制——>为后期实现不连续选定区域或段落等提供前提
                    if (myOwnerControl.CaptureMouse)
                    //&& (myOwnerControl.Cursor == Cursors.HSplit || myOwnerControl.Cursor == Cursors.VSplit)) //2014-07-30 鼠标拖拽单元格情况
                    {
                        //2014-07-30 指定的点溢出文档视图区时，需要修正指定点的X坐标以确保之前的鼠标拖拽单元格操作不丢失
                        if (x < rect.Left)
                        {
                            x = rect.Left;
                        }
                        if (x > rect.Right)
                        {
                            x = rect.Right;
                        }

                        //2014-08-01 指定的点溢出文档视图区时，需要修正指定点的Y坐标以确保之前的鼠标拖拽单元格操作不丢失
                        //if (i == currTransforms.Count - 1 && y > rect.Bottom)
                        //{
                        //    //y = rect.Bottom;
                        //}

                        if (i == currTransforms.Count - 1) //2014-08-04 上下两页之间的间隔区域
                        {
                            if (y >= rect.Bottom)
                            {
                                if (myOwnerControl.Cursor == Cursors.HSplit) //如果正在进行鼠标拖拽表格内的单元格操作，则不能修改鼠标形状——>这个非常重要
                                {
                                    y = rect.Bottom - this.Info.LineSpacing;
                                }
                                else
                                {
                                    y = rect.Bottom;
                                    //return -1;
                                }
                            }
                        }
                        else
                        {
                            if (y >= rect.Bottom && y < (currTransforms[i + 1] as SimpleRectangleTransform).SourceRect.Top)
                            {
                                if (myOwnerControl.Cursor == Cursors.HSplit) //如果正在进行鼠标拖拽表格内的单元格操作，则不能修改鼠标形状——>这个非常重要
                                {
                                    y = rect.Bottom - this.Info.LineSpacing;
                                }
                                else
                                {
                                    y = rect.Bottom;
                                    //return -1;
                                }
                            }
                        }
                    }
                    else //非鼠标拖拽单元格情况
                    {
                        if (x < rect.Left - 0.5 * myPages.LeftMargin / myOwnerControl.PagesTransform.Rate
                            || x > rect.Right + myPages.RightMargin / myOwnerControl.PagesTransform.Rate) continue;

                        //2014-07-29 指定的点溢出文档视图区时，需要修正指定点的X坐标以确保之前的鼠标选定区域不丢失
                        if (x >= rect.Left / 2
                            && x < rect.Left)
                        //if(x < rect.Left) //2014-08-01
                        {
                            x = rect.Left;
                        }
                        if (x > rect.Right)
                        {
                            x = rect.Right;
                        }



                        if (i == currTransforms.Count - 1) //2014-08-04 上下两页之间的间隔区域
                        {
                            if (y >= rect.Bottom)
                            {
                                y = rect.Bottom;
                                //return -1;
                            }
                        }
                        else
                        {
                            if (y >= rect.Bottom && y < (currTransforms[i + 1] as SimpleRectangleTransform).SourceRect.Top)
                            {
                                y = rect.Bottom;
                                //return -1;
                            }
                        }
                    }

                    //if (transform.SourceRect.Contains(x, y)) return i; //注意矩形的Contains方法判断点时不包含其边界上的点
                    if (rect.Left <= x && rect.Right >= x
                        && rect.Top <= y && rect.Bottom >= y)
                    //&& rect.Top <= y && rect.Bottom > y) //2014-08-04 表格内有单元格底端刚巧处于上下两个文档页分页线上
                    {
                        return i;
                    }

                    //2014-07-28 当文档编辑区为正文，并且指定的点位于最后一个文档页内时，需要检查是否溢出正文坐标系边界——>拖拽表格最低端边界线——>已交由上面的 2014-08-01 修正
                    //if (editingAreaFlag == 1
                    //    && i == currTransforms.Count - 1
                    //    && y >= rect.Bottom)
                    //{
                    //    return i;
                    //}
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将（当前文档编辑区域）客户区内的点坐标转换为视图区内的点坐标。
        /// </summary>
        /// <param name="x">客户区内的点X坐标。</param>
        /// <param name="y">客户区内的点Y坐标。</param>
        /// <returns>返回视图区内的点坐标。</returns>
        public Point ClientPointToView(int x, int y)
        {
            try
            {
                int resultIndex = this.ContainsSourcePoint(x, y);
                if (resultIndex != -1)
                {
                    List<SimpleRectangleTransform> currTransforms = myOwnerControl.PagesTransform.GetHBFTransforms(editingAreaFlag);
                    SimpleRectangleTransform transform = currTransforms[resultIndex];
                    Rectangle rect = transform.SourceRect;

                    //2014-07-29 类似Word中的文档视图外围边界溢出控制——>为后期实现不连续选定区域或段落等提供前提
                    if (myOwnerControl.CaptureMouse)
                    //&& (myOwnerControl.Cursor == Cursors.HSplit || myOwnerControl.Cursor == Cursors.VSplit)) //2014-07-30 鼠标拖拽单元格情况
                    {
                        //2014-07-30 指定的点溢出文档视图区时，需要修正指定点的X坐标以确保之前的鼠标拖拽单元格操作不丢失
                        if (x < rect.Left)
                        {
                            x = rect.Left;
                        }
                        if (x > rect.Right)
                        {
                            x = rect.Right;
                        }

                        //2014-08-01 指定的点溢出文档视图区时，需要修正指定点的Y坐标以确保之前的鼠标拖拽单元格操作不丢失
                        //if (currTransforms.IndexOf(transform) == currTransforms.Count - 1 && y > rect.Bottom)
                        //{
                        //    //y = rect.Bottom;
                        //}

                        if (currTransforms.IndexOf(transform) == currTransforms.Count - 1) //2014-08-04 上下两页之间的间隔区域
                        {
                            if (y >= rect.Bottom)
                            {
                                if (myOwnerControl.Cursor == Cursors.HSplit) //如果正在进行鼠标拖拽表格内的单元格操作，则不能修改鼠标形状——>这个非常重要
                                {
                                    y = rect.Bottom - this.Info.LineSpacing;
                                }
                                else
                                {
                                    y = rect.Bottom;
                                    //y = rect.Bottom - this.Info.LineSpacing;
                                }
                            }
                        }
                        else
                        {
                            if (y >= rect.Bottom && y < (currTransforms[currTransforms.IndexOf(transform) + 1] as SimpleRectangleTransform).SourceRect.Top)
                            {
                                if (myOwnerControl.Cursor == Cursors.HSplit) //如果正在进行鼠标拖拽表格内的单元格操作，则不能修改鼠标形状——>这个非常重要
                                {
                                    y = rect.Bottom - this.Info.LineSpacing;
                                }
                                else
                                {
                                    y = rect.Bottom;
                                    //y = rect.Bottom - this.Info.LineSpacing;
                                }
                            }
                        }
                    }
                    else //非鼠标拖拽单元格情况
                    {
                        if (x < rect.Left - 0.5 * myPages.LeftMargin / myOwnerControl.PagesTransform.Rate
                            || x > rect.Right + myPages.RightMargin / myOwnerControl.PagesTransform.Rate) return Point.Empty;

                        //2014-07-29 指定的点溢出文档视图区时，需要修正指定点的X坐标以确保之前的鼠标选定区域不丢失
                        if (x >= rect.Left / 2
                            && x < rect.Left)
                        //if(x < rect.Left)
                        {
                            x = rect.Left;
                        }
                        if (x > rect.Right)
                        {
                            x = rect.Right;
                        }


                        if (currTransforms.IndexOf(transform) == currTransforms.Count - 1) //2014-08-04 上下两页之间的间隔区域
                        {
                            if (y >= rect.Bottom)
                            {
                                y = rect.Bottom;
                                //y = rect.Bottom - this.Info.LineSpacing;
                            }
                        }
                        else
                        {
                            if (y >= rect.Bottom && y < (currTransforms[currTransforms.IndexOf(transform) + 1] as SimpleRectangleTransform).SourceRect.Top)
                            {
                                y = rect.Bottom;
                                //y = rect.Bottom - this.Info.LineSpacing;
                            }
                        }
                    }

                    //2014-07-28 当文档编辑区为正文，并且指定的点位于最后一个文档页内时，需要检查是否溢出正文坐标系边界——>拖拽表格最低端边界线——>已交由上面的 2014-08-01 修正
                    //int lastFooterBottom = (myOwnerControl.PagesTransform.GetHBFTransforms(2)[myPages.Count - 1] as SimpleRectangleTransform).SourceRect.Bottom;
                    //if (editingAreaFlag == 1
                    //    && currTransforms.IndexOf(transform) == currTransforms.Count - 1
                    //    && y >= lastFooterBottom - 65)
                    //{
                    //    y = lastFooterBottom - 65; //留出一个回车符的整行高度
                    //}

                    return transform.TransformPoint(x, y);
                }
                return Point.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 确定指定的点是否包含在当前文档编辑区域内某一个矩形坐标转换关系对象的目标矩形区域中。
        /// </summary>
        /// <param name="x">指定点的X坐标。</param>
        /// <param name="y">指定点的Y坐标。</param>
        /// <returns>返回找到的原始矩形区域的索引序号。</returns>
        public int ContainsDescPoint(int x, int y)
        {
            try
            {
                List<SimpleRectangleTransform> currTransforms = myOwnerControl.PagesTransform.GetHBFTransforms(editingAreaFlag);
                for (int i = 0; i < currTransforms.Count; i++)
                {
                    SimpleRectangleTransform transform = currTransforms[i];
                    Rectangle rect = transform.DescRect;
                    //if (transform.DescRect.Contains(x, y)) return i; //注意矩形的Contains方法判断点时不包含其右下边界上的点
                    //if (rect.Left <= x && rect.Right >= x
                    //    && rect.Top <= y && rect.Bottom >= y)
                    if (rect.Left <= x && rect.Right >= x
                        && rect.Top <= y && rect.Bottom > y) //2014-07-31 特别注意上一页底端与下一页顶端，这个边界交汇处的光标显示位置（TextPageViewControl）是依据下一页的矩形坐标系转换得到——>原因在于目标坐标系视觉上分割，物理上连续
                    {
                        return i;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将（当前文档编辑区域）视图区内的点坐标转换为客户区内的点坐标——>由ZYEditorControl类的ViewPointToClient方法调用。
        /// </summary>
        /// <param name="x">视图区内的点X坐标。</param>
        /// <param name="y">视图区内的点Y坐标。</param>
        /// <returns>返回客户区内的点坐标。</returns>
        public Point ViewPointToClient(int x, int y)
        {
            try
            {
                int resultIndex = this.ContainsDescPoint(x, y);
                if (resultIndex != -1)
                {
                    List<SimpleRectangleTransform> currTransforms = myOwnerControl.PagesTransform.GetHBFTransforms(editingAreaFlag);
                    SimpleRectangleTransform transform = currTransforms[resultIndex];
                    return transform.UnTransformPoint(x, y);
                }
                return Point.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 确定指定的点是否包含在指定文档区域内某一个矩形坐标转换关系对象的原始矩形区域中。
        /// </summary>
        /// <param name="x">指定点的X坐标。</param>
        /// <param name="y">指定点的Y坐标。</param>
        /// <param name="doucumentAreaFlag">标识指定的文档区域所属类别，分为文档页眉区（数值0代表）、文档正文区（数值1代表）和文档页脚区（数值2代表）。</param>
        /// <returns>返回找到的原始矩形区域的索引序号。</returns>
        public int ContainsSourcePoint(int x, int y, int doucumentAreaFlag)
        {
            try
            {
                List<SimpleRectangleTransform> currTransforms = this.OwnerControl.PagesTransform.GetHBFTransforms(doucumentAreaFlag);
                for (int i = 0; i < currTransforms.Count; i++)
                {
                    SimpleRectangleTransform transform = currTransforms[i];
                    Rectangle rect = transform.SourceRect;


                    //2014-07-29 指定的点溢出文档视图区时，需要修正指定点的X坐标以确保鼠标双击文档视图区之外的位置也能切换文档编辑区
                    if (x < rect.Left)
                    {
                        x = rect.Left;
                    }
                    if (x > rect.Right)
                    {
                        x = rect.Right;
                    }

                    //if (transform.SourceRect.Contains(x, y)) return i; //注意矩形的Contains方法判断点时不包含其边界上的点
                    if (rect.Left <= x && rect.Right >= x
                        && rect.Top <= y && rect.Bottom >= y)
                    {
                        return i;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在不同文档页的页眉区或页脚区进行切换，由编辑器控件的鼠标按下事件处理例程调用；
        /// 在文档的页眉区、正文区和页脚区之间进行切换，由编辑器控件的双击事件处理例程调用；
        /// 默认切换当前可编辑区至文档正文区，由全选页眉或页脚区域内容执行删除操作例程调用（X=-1，Y=-1）。
        /// </summary>
        /// <param name="x">当前鼠标按下或双击的位置X坐标。</param>
        /// <param name="y">当前鼠标按下或双击的位置Y坐标。</param>
        /// <param name="flag">标识哪种方式下的文档编辑区切换，true表示双击事件，false表示鼠标按下事件。</param>
        public void ToggleEditingArea(int x, int y, bool flag)
        {
            try
            {
                if (x == -1 && y == -1) //默认切换当前可编辑区至文档正文区
                {
                    editingAreaFlag = 1;
                    this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement); //重新定位光标至文档正文区
                }
                else //其他情况下X坐标与Y坐标必定为非负值
                {
                    if (!flag) //鼠标按下事件
                    {
                        #region 在不同的页眉区（或页脚区）切换
                        int resultIndex = this.ContainsSourcePoint(x, y);
                        if (resultIndex != -1)
                        {
                            if (editingAreaFlag == 0) //页眉区域为可编辑状态
                            {
                                editingAreaElements[0] = RootDocumentElementsInHeader[resultIndex].InnerElements;
                                editingAreaLines[0] = RootDocumentElementsInHeader[resultIndex].InnerLines;
                                editingAreaRootElements[0] = RootDocumentElementsInHeader[resultIndex];
                            }
                            else if (editingAreaFlag == 2) //页脚区域为可编辑状态
                            {
                                //ZYEditorControl _ZYEditorControl = ((ZYEditorControl)this.OwnerControl);
                                //EditorForm 
                                editingAreaElements[2] = RootDocumentElementsInFooter[resultIndex].InnerElements;
                                editingAreaLines[2] = RootDocumentElementsInFooter[resultIndex].InnerLines;
                                editingAreaRootElements[2] = RootDocumentElementsInFooter[resultIndex];
                            }
                        }
                        #endregion
                    }
                    else //鼠标双击事件
                    {
                        if (editingAreaFlag == 0) //页眉区域为可编辑状态
                        {
                            int resultIndex = this.ContainsSourcePoint(x, y, 0);
                            if (resultIndex == -1) //如果当前鼠标双击位置不在页眉区域
                            {
                                #region 应用当前页眉区域内容改变
                                if (YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("确定要将当前页眉区域内容更改应用到当前文档（将替换此文档中的所有页眉区域）吗", "提示", YiDanCommon.Ctrs.DLG.YiDanMessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    //这里写上所有文档区的页眉区域更改代码段——>
                                    System.Xml.XmlDocument headerDocument = new System.Xml.XmlDocument();
                                    headerDocument.PreserveWhitespace = true;
                                    headerDocument.AppendChild(headerDocument.CreateElement(ZYTextConst.c_Header));
                                    ZYTextElement currHeaderElement = HBFElements[0] as ZYTextElement;
                                    ZYDocumentHeader editingAreaDocumentElement = ZYDocumentHeader.GetOwnerDiv(currHeaderElement);
                                    if (editingAreaDocumentElement.InnerElements.Count == 1
                                        && editingAreaDocumentElement.InnerElements[0] is ZYTextEOF)
                                    {
                                        editingAreaDocumentElement.ChildElements.Clear();
                                    }

                                    ZYTextElement.ElementsToXML(editingAreaDocumentElement.ChildElements, headerDocument.DocumentElement);

                                    if (headerDocument.DocumentElement != null)
                                    {
                                        this.BeginContentChangeLog(); //更新所有页眉区域也支持撤销操作
                                        if (this.UndoStack.UndoItemCount > 0)
                                        {
                                            ZYEditorAction a = this.UndoStack.undostack.Pop();
                                            ZYTextDocumentLib.A_ContentChangeLog.UndoStep myStep = (a as A_ContentChangeLog).UndoSteps[(a as A_ContentChangeLog).UndoSteps.Count - 1] as ZYTextDocumentLib.A_ContentChangeLog.UndoStep;
                                            this.ContentChangeLog.UndoSteps.Add(myStep);
                                        }

                                        for (int k = 0; k < RootDocumentElementsInHeader.Count; k++)
                                        {
                                            if (k == RootDocumentElementsInHeader.IndexOf(editingAreaDocumentElement)) continue;
                                            //重新构建页眉区域的文档根元素
                                            RootDocumentElementsInHeader[k].RemoveChildRange(RootDocumentElementsInHeader[k].ChildElements);
                                            RootDocumentElementsInHeader[k].FromXML(headerDocument.DocumentElement as System.Xml.XmlElement);
                                            if (RootDocumentElementsInHeader[k] != null)
                                            {
                                                RootDocumentElementsInHeader[k].OwnerDocument = this;
                                                RootDocumentElementsInHeader[k].UpdateUserLogin();
                                            }
                                        }
                                        this.ContentChanged();
                                        this.EndContentChangeLog();
                                    }
                                }
                                this.CorrectPageNumberInFooter(true); //点击否的时候也需要校验文档页码 2014-08-21
                                #endregion

                                #region 切换文档编辑区至正文或页脚
                                resultIndex = this.ContainsSourcePoint(x, y, 2);
                                if (resultIndex == -1) //当前鼠标双击位于也不在页脚区域
                                {
                                    editingAreaFlag = 1;
                                    this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                                }
                                else //当前鼠标双击位于在页脚区域
                                {
                                    editingAreaFlag = 2;
                                    editingAreaElements[2] = (RootDocumentElementsInFooter[resultIndex] as ZYDocumentFooter).InnerElements;
                                    editingAreaLines[2] = (RootDocumentElementsInFooter[resultIndex] as ZYDocumentFooter).InnerLines;
                                    this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                                }
                                this.UpdateTextCaret();
                                this.OwnerControl.Invalidate();
                                #endregion
                            }
                        }
                        else if (editingAreaFlag == 2) //页脚区域为可编辑状态
                        {
                            int resultIndex = this.ContainsSourcePoint(x, y, 2);
                            if (resultIndex == -1) //如果当前鼠标双击位置不在页脚区域
                            {
                                #region 应用当前页脚区域内容改变
                                if (YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("确定要将当前页脚区域内容更改应用到当前文档（将替换此文档中的所有页脚区域）吗", "提示", YiDanCommon.Ctrs.DLG.YiDanMessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    //这里写上所有文档区的页脚区域更改代码段——>
                                    System.Xml.XmlDocument footerDocument = new System.Xml.XmlDocument();
                                    footerDocument.PreserveWhitespace = true;
                                    footerDocument.AppendChild(footerDocument.CreateElement(ZYTextConst.c_Footer));
                                    ZYTextElement currFooterElement = HBFElements[0] as ZYTextElement;
                                    ZYDocumentFooter editingAreaDocumentElement = ZYDocumentFooter.GetOwnerDiv(currFooterElement);
                                    if (editingAreaDocumentElement.InnerElements.Count == 1
                                        && editingAreaDocumentElement.InnerElements[0] is ZYTextEOF)
                                    {
                                        editingAreaDocumentElement.ChildElements.Clear();
                                    }

                                    ZYTextElement.ElementsToXML(editingAreaDocumentElement.ChildElements, footerDocument.DocumentElement);

                                    if (footerDocument.DocumentElement != null)
                                    {
                                        //this.BeginContentChangeLog(); //更新所有页脚区域也支持撤销操作
                                        for (int k = 0; k < RootDocumentElementsInFooter.Count; k++)
                                        {
                                            if (k == RootDocumentElementsInFooter.IndexOf(editingAreaDocumentElement)) continue;
                                            //重新构建页脚区域的文档根元素
                                            //if (this.ContentChangeLog.UndoSteps.Count == 0 && this.UndoStack.UndoItemCount > 0)
                                            //{
                                            //    ZYEditorAction a = this.UndoStack.undostack.Pop();
                                            //    ZYTextDocumentLib.A_ContentChangeLog.UndoStep myStep = (a as A_ContentChangeLog).UndoSteps[(a as A_ContentChangeLog).UndoSteps.Count - 1] as ZYTextDocumentLib.A_ContentChangeLog.UndoStep;
                                            //    this.ContentChangeLog.UndoSteps.Add(myStep);
                                            //}

                                            RootDocumentElementsInFooter[k].RemoveChildRange(RootDocumentElementsInFooter[k].ChildElements);
                                            RootDocumentElementsInFooter[k].FromXML(footerDocument.DocumentElement as System.Xml.XmlElement);
                                            if (RootDocumentElementsInFooter[k] != null)
                                            {
                                                RootDocumentElementsInFooter[k].OwnerDocument = this;
                                                RootDocumentElementsInFooter[k].UpdateUserLogin();
                                            }
                                        }
                                        this.ContentChanged();
                                        this.BeginContentChangeLog(); //更新所有页脚区域也支持撤销操作
                                        this.CorrectPageNumberInFooter(true);
                                        this.EndContentChangeLog();
                                    }
                                }
                                this.CorrectPageNumberInFooter(true); //点击否的时候也需要校验文档页码 2014-08-21
                                #endregion

                                #region 切换文档编辑区至正文或页眉
                                resultIndex = this.ContainsSourcePoint(x, y, 0);
                                if (resultIndex == -1) //当前鼠标双击位于也不在页眉区域
                                {
                                    editingAreaFlag = 1;
                                    this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                                }
                                else //当前鼠标双击位于在页眉区域
                                {
                                    if (OnIsPageHeaderEditor != null && OnIsPageHeaderEditor())//add by lhl 2015-06-30用户具有编辑页眉权限
                                    {
                                        editingAreaFlag = 0;
                                    }
                                    editingAreaElements[0] = RootDocumentElementsInHeader[resultIndex].InnerElements;
                                    editingAreaLines[0] = RootDocumentElementsInHeader[resultIndex].InnerLines;
                                    this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                                }

                                this.UpdateTextCaret();
                                this.OwnerControl.Invalidate(); //不执行这个，则不能及时更新页脚编辑外矩形框
                                #endregion
                            }
                        }
                        else //正文区域为可编辑状态
                        {
                            //打印状态时不允许编辑页眉或页脚
                            if (this.Info.DocumentModel == DocumentModel.Design || this.Info.DocumentModel == DocumentModel.Edit)
                            {
                                #region 是否切换至页眉区（或页脚区）
                                //先判断当前鼠标双击位置是否位于某一个页眉区域
                                int resultIndex = this.ContainsSourcePoint(x, y, 0);
                                if (resultIndex != -1)
                                {
                                    //2014-08-28 页眉根元素没有子对象（段落等），却有高度，肯定是配置宜昌中心医院需要，直接返回，页眉区不可编辑
                                    if (RootDocumentElementsInHeader[resultIndex].ChildCount == 0) return;
                                    if (OnIsPageHeaderEditor != null && OnIsPageHeaderEditor())//add by lhl 2015-06-30用户具有编辑页眉权限
                                    {
                                        editingAreaFlag = 0;
                                    }
                                    editingAreaElements[0] = RootDocumentElementsInHeader[resultIndex].InnerElements;
                                    editingAreaLines[0] = RootDocumentElementsInHeader[resultIndex].InnerLines;
                                    editingAreaRootElements[0] = RootDocumentElementsInHeader[resultIndex];
                                    ZYContent.IsMoveCaretToLineEnd = false;
                                    this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                                    UpdateTextCaret();
                                    this.OwnerControl.Invalidate();
                                }

                                //再判断当前鼠标双击位置是否位于某一个页脚区域
                                resultIndex = this.ContainsSourcePoint(x, y, 2);
                                if (resultIndex != -1)
                                {
                                    editingAreaFlag = 2;
                                    editingAreaElements[2] = RootDocumentElementsInFooter[resultIndex].InnerElements;
                                    editingAreaLines[2] = RootDocumentElementsInFooter[resultIndex].InnerLines;
                                    editingAreaRootElements[2] = RootDocumentElementsInFooter[resultIndex];
                                    ZYContent.IsMoveCaretToLineEnd = false;
                                    this.Content.MoveSelectStart(HBFElements[0] as ZYTextElement);
                                    UpdateTextCaret();
                                    this.OwnerControl.Invalidate();
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断指定点是否在指定的矩形区域内。
        /// </summary>
        /// <param name="p">指定的点。</param>
        /// <param name="rect">指定的矩形。</param>
        /// <returns>返回一个布尔值，true表示在，false表示不在。</returns>
        public bool Contains(Point p, Rectangle rect)
        {
            try
            {
                if (rect.Left <= p.X && rect.Right >= p.X
                    && rect.Top <= p.Y && rect.Bottom >= p.Y) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存当前页眉编辑区的内容改变。
        /// </summary>
        public void SaveHeader()
        {
            try
            {
                #region 应用当前页眉区域内容改变
                if (YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("确定要将当前页眉区域内容更改应用到当前文档（将替换此文档中的所有页眉区域）吗", "提示", YiDanCommon.Ctrs.DLG.YiDanMessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //这里写上所有文档区的页眉区域更改代码段——>
                    System.Xml.XmlDocument headerDocument = new System.Xml.XmlDocument();
                    headerDocument.PreserveWhitespace = true;
                    headerDocument.AppendChild(headerDocument.CreateElement(ZYTextConst.c_Header));
                    ZYTextElement currHeaderElement = HBFElements[0] as ZYTextElement;
                    ZYDocumentHeader editingAreaDocumentElement = ZYDocumentHeader.GetOwnerDiv(currHeaderElement);
                    if (editingAreaDocumentElement.InnerElements.Count == 1
                        && editingAreaDocumentElement.InnerElements[0] is ZYTextEOF)
                    {
                        editingAreaDocumentElement.ChildElements.Clear();
                    }

                    ZYTextElement.ElementsToXML(editingAreaDocumentElement.ChildElements, headerDocument.DocumentElement);

                    if (headerDocument.DocumentElement != null)
                    {
                        this.BeginContentChangeLog(); //更新所有页眉区域也支持撤销操作
                        if (this.UndoStack.UndoItemCount > 0)
                        {
                            ZYEditorAction a = this.UndoStack.undostack.Pop();
                            ZYTextDocumentLib.A_ContentChangeLog.UndoStep myStep = (a as A_ContentChangeLog).UndoSteps[(a as A_ContentChangeLog).UndoSteps.Count - 1] as ZYTextDocumentLib.A_ContentChangeLog.UndoStep;
                            this.ContentChangeLog.UndoSteps.Add(myStep);
                        }

                        for (int k = 0; k < RootDocumentElementsInHeader.Count; k++)
                        {
                            if (k == RootDocumentElementsInHeader.IndexOf(editingAreaDocumentElement)) continue;
                            //重新构建页眉区域的文档根元素
                            RootDocumentElementsInHeader[k].RemoveChildRange(RootDocumentElementsInHeader[k].ChildElements);
                            RootDocumentElementsInHeader[k].FromXML(headerDocument.DocumentElement as System.Xml.XmlElement);
                            if (RootDocumentElementsInHeader[k] != null)
                            {
                                RootDocumentElementsInHeader[k].OwnerDocument = this;
                                RootDocumentElementsInHeader[k].UpdateUserLogin();
                            }
                        }

                        editingAreaFlag = 1; //2014-08-13 恢复默认编辑区为文档正文

                        this.ContentChanged();
                        this.EndContentChangeLog();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存当前页脚编辑区的内容改变。
        /// </summary>
        public void SaveFooter()
        {
            try
            {
                #region 应用当前页脚区域内容改变
                if (YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("确定要将当前页脚区域内容更改应用到当前文档（将替换此文档中的所有页脚区域）吗", "提示", YiDanCommon.Ctrs.DLG.YiDanMessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //这里写上所有文档区的页脚区域更改代码段——>
                    System.Xml.XmlDocument footerDocument = new System.Xml.XmlDocument();
                    footerDocument.PreserveWhitespace = true;
                    footerDocument.AppendChild(footerDocument.CreateElement(ZYTextConst.c_Footer));
                    ZYTextElement currFooterElement = HBFElements[0] as ZYTextElement;
                    ZYDocumentFooter editingAreaDocumentElement = ZYDocumentFooter.GetOwnerDiv(currFooterElement);
                    if (editingAreaDocumentElement.InnerElements.Count == 1
                        && editingAreaDocumentElement.InnerElements[0] is ZYTextEOF)
                    {
                        editingAreaDocumentElement.ChildElements.Clear();
                    }

                    ZYTextElement.ElementsToXML(editingAreaDocumentElement.ChildElements, footerDocument.DocumentElement);

                    if (footerDocument.DocumentElement != null)
                    {
                        //this.BeginContentChangeLog(); //更新所有页脚区域也支持撤销操作
                        for (int k = 0; k < RootDocumentElementsInFooter.Count; k++)
                        {
                            if (k == RootDocumentElementsInFooter.IndexOf(editingAreaDocumentElement)) continue;
                            //重新构建页脚区域的文档根元素
                            //if (this.ContentChangeLog.UndoSteps.Count == 0 && this.UndoStack.UndoItemCount > 0)
                            //{
                            //    ZYEditorAction a = this.UndoStack.undostack.Pop();
                            //    ZYTextDocumentLib.A_ContentChangeLog.UndoStep myStep = (a as A_ContentChangeLog).UndoSteps[(a as A_ContentChangeLog).UndoSteps.Count - 1] as ZYTextDocumentLib.A_ContentChangeLog.UndoStep;
                            //    this.ContentChangeLog.UndoSteps.Add(myStep);
                            //}

                            RootDocumentElementsInFooter[k].RemoveChildRange(RootDocumentElementsInFooter[k].ChildElements);
                            RootDocumentElementsInFooter[k].FromXML(footerDocument.DocumentElement as System.Xml.XmlElement);
                            if (RootDocumentElementsInFooter[k] != null)
                            {
                                RootDocumentElementsInFooter[k].OwnerDocument = this;
                                RootDocumentElementsInFooter[k].UpdateUserLogin();
                            }
                        }

                        editingAreaFlag = 1; //2014-08-13 恢复默认编辑区为文档正文

                        this.ContentChanged();
                        this.BeginContentChangeLog(); //更新所有页脚区域也支持撤销操作
                        this.CorrectPageNumberInFooter(true);
                        this.EndContentChangeLog();
                    }
                }
                editingAreaFlag = 1; //2014-08-13 恢复默认编辑区为文档正文
                this.CorrectPageNumberInFooter(true); //点击否的时候也需要校验文档页码 2014-08-21
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //——>于 2014-07-29 重构光标定位及反色高亮
        /// <summary>
        /// 将（当前文档编辑区域）视图区内的需反色（高亮绘制）处理的矩形区域坐标转换为客户区内的坐标表示形式。
        /// </summary>
        /// <returns>返回将被反转（InvertRect）的矩形逻辑坐标的RECT结构。</returns>
        public Rectangle GetReversibleRect(Rectangle heightLightRect)
        {
            try
            {
                int resultIndex = this.ContainsDescPoint(heightLightRect.Left, heightLightRect.Top);
                if (resultIndex != -1)
                {
                    List<SimpleRectangleTransform> currTransforms = myOwnerControl.PagesTransform.GetHBFTransforms(editingAreaFlag);
                    SimpleRectangleTransform transform = currTransforms[resultIndex];
                    return transform.UnTransformRectangle(heightLightRect);
                }
                return Rectangle.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 文档中的鼠标点击以及鼠标选定区域发生改变时的处理。
        /// </summary>
        /// <param name="sourceStart">原选定区域的开始位置。</param>
        /// <param name="sourceEnd">原始选定区域的结束位置。</param>
        /// <param name="descStart">新选定区域的开始位置。</param>
        /// <param name="descEnd">新选定区域的结束位置。</param>
        public void SelectionChanged(int sourceStart, int sourceEnd, int descStart, int descEnd)
        {
            try
            {
                if (myOwnerControl != null)
                {
                    ZYTextElement myElement = null;
                    //鼠标点击了另外一个位置，非选定文本操作
                    if (sourceEnd == 0 && descEnd == 0 && sourceStart != descStart)
                    {
                        if (sourceStart >= 0 && sourceStart < HBFElements.Count && descStart >= 0
                            && descStart < HBFElements.Count)
                        {
                            ZYTextElement OldElement = (ZYTextElement)HBFElements[sourceStart];
                            ZYTextElement NewElement = (ZYTextElement)HBFElements[descStart];
                            if (OnJumpDiv != null && ZYTextDiv.GetOwnerDiv(OldElement) != ZYTextDiv.GetOwnerDiv(NewElement))
                            {
                                OnJumpDiv(ZYTextDiv.GetOwnerDiv(OldElement), ZYTextDiv.GetOwnerDiv(NewElement));
                            }
                        }
                    }
                    else if (sourceStart != descStart) //鼠标由右向左往（光标）前拖选
                    {
                        for (int iCount = sourceStart; iCount <= descStart; iCount++)
                        {
                            if (myContent.SelectLength != 0 && iCount == HBFElements.Count) continue;
                            if (iCount >= HBFElements.Count) continue;

                            myElement = (ZYTextElement)HBFElements[iCount];
                            if (myElement is ZYTextBlock)
                                myOwnerControl.AddInvalidateRect((myElement as ZYTextBlock).GetContentBounds());
                            else
                            {
                                myOwnerControl.AddInvalidateRect(
                                        myElement.RealLeft,
                                    //myElement.OwnerLine.RealTop,
                                        myElement.RealTop,
                                        myElement.Width + myElement.WidthFix,
                                    //myElement.OwnerLine.Height
                                        myElement.Height);
                            }
                        }
                    }
                    else if (sourceEnd != descEnd) //鼠标由左向右往（光标）后拖选
                    {
                        for (int iCount = sourceEnd; iCount <= descEnd; iCount++)
                        {
                            if (myContent.SelectLength != 0 && iCount == HBFElements.Count) continue;
                            if (iCount >= HBFElements.Count) continue;

                            myElement = (ZYTextElement)HBFElements[iCount];

                            if (myElement is ZYTextBlock)
                                myOwnerControl.AddInvalidateRect((myElement as ZYTextBlock).GetContentBounds());
                            else
                            {
                                myOwnerControl.AddInvalidateRect(
                                         myElement.RealLeft,
                                    //myElement.OwnerLine.RealTop,
                                         myElement.RealTop,
                                         myElement.Width + myElement.WidthFix,
                                    //myElement.OwnerLine.Height
                                         myElement.Height);
                            }
                        }
                    }
                    myOwnerControl.UpdateInvalidateRect();
                    myOwnerControl.UpdateTextCaret();
                    if (this.OnSelectionChanged != null)
                        this.OnSelectionChanged(this, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //——>于 2014-08-06
        /// <summary>
        /// 得到指定元素的单元格容器。
        /// </summary>
        /// <param name="myElement">指定文档元素。</param>
        /// <returns></returns>
        public TPTextCell GetOwnerCell(ZYTextElement myElement)
        {
            try
            {
                TPTextCell myOwnerCell = null;
                while (myElement != null)
                {
                    myOwnerCell = myElement as TPTextCell;
                    if (myOwnerCell == null)
                    {
                        myElement = myElement.Parent;
                    }
                    else
                    {
                        return myOwnerCell;
                    }
                }
                return myOwnerCell;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定元素的所属段落容器。
        /// </summary>
        /// <param name="myElement">指定文档元素。</param>
        /// <returns></returns>
        public ZYTextParagraph GetOwnerPara(ZYTextElement myElement)
        {
            try
            {
                ZYTextParagraph myOwnerPara = null;
                while (myElement != null)
                {
                    myOwnerPara = myElement as ZYTextParagraph;
                    if (myOwnerPara == null)
                    {
                        myElement = myElement.Parent;
                    }
                    else
                    {
                        return myOwnerPara;
                    }
                }
                return myOwnerPara;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定元素的所属顶级容器。
        /// </summary>
        /// <param name="myElement">指定文档元素。</param>
        /// <returns></returns>
        public ZYTextContainer GetOwnerRoot(ZYTextElement myElement)
        {
            try
            {
                ZYTextContainer myOwnerRoot = null;
                while (myElement.Parent != null)
                {
                    myOwnerRoot = myElement.Parent;
                    if (myOwnerRoot == null)
                    {
                        return myOwnerRoot;
                    }
                    else
                    {
                        myElement = myElement.Parent;
                    }
                }
                return myOwnerRoot;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //——>于 2014-08-04 重构表格跨页（第二次改版）（2014-08-05 实现复杂表格跨页前期方案）
        /// <summary>
        /// 通过与所有的文档行对象进行比较，准确计算出当前文档页的真正分页线位置——>牵涉ZYTextContainer的RefreshView方法与TextPageViewContrl类的OnPaint方法。
        /// </summary>
        /// <param name="info">指定的分页线信息。</param>
        public void FixPageLineSecondEditon(PageLineInfo info)
        {
            try
            {
                ZYTextLine findLine = null; //保存最终找到的确定分页线位置的文档行
                //foreach (ZYTextLine myLine in editingAreaLines[1]) //editingAreaLines[1]存储文档正文区所有文档行对象
                foreach (ZYTextLine myLine in RootDocumentElement.Lines) //Lines存储基本段落和表格内直属表格行——>表格整体结构考虑
                {
                    if (myLine.Container is ZYTextParagraph) //当前文档行所在容器为段落
                    {
                        int vLineTop = myLine.RealTop; //存储文档行在文档视图区的绝对顶端位置
                        int vLineHeight = myLine.FullHeight; //存储文档行的自身高度+行间距
                        if (info.LastPos <= vLineTop && vLineTop + vLineHeight <= info.Pos && myLine.FirstElement is ZYPageEnd)
                        {
                            findLine = myLine;
                            info.Pos = vLineTop + vLineHeight;
                            return; //确定分页线之后直接返回不再往下执行
                        }

                        if (vLineTop <= info.Pos
                            && info.Pos < vLineTop + vLineHeight)
                        {
                            findLine = myLine;
                            info.Pos = vLineTop;
                            return; //确定分页线之后直接返回不再往下执行
                        }
                    }
                    else if (myLine.Container is TPTextRow) //当前文档行所在容器为表格行
                    {
                        int vLineTop = myLine.RealTop; //存储文档行在文档视图区的绝对顶端位置
                        int vLineHeight = myLine.FullHeight; //存储文档行的自身高度+行间距
                        if (info.LastPos <= vLineTop && vLineTop + vLineHeight <= info.Pos && myLine.FirstElement is ZYPageEnd)
                        {
                            findLine = myLine;
                            info.Pos = vLineTop + vLineHeight;
                            return; //确定分页线之后直接返回不再往下执行
                        }

                        TPTextRow currRow = myLine.Container as TPTextRow;
                        TPTextTable currTB = currRow.OwnerTable;
                        foreach (TPTextCell cell in currRow) //遍历表格内直属表格行
                        {
                            Rectangle rect = cell.GetContentBounds();
                            int vHeight = 0;
                            if (currTB.IndexOf(currRow) == currTB.ChildCount - 1) //表格最后一个表格行时必须加上行间距LineSpacing
                            {
                                vHeight = this.Info.LineSpacing;
                            }

                            if (rect.Top <= info.Pos && info.Pos < rect.Bottom + vHeight)
                            {
                                findLine = myLine;
                                info.Pos = rect.Top;

                                ////2014-08-15 分割单元格方案测试，暂时不通过——>如果换成拆分单元格的思想又会怎么样呢？
                                //if (info.Pos - rect.Top < TPTextTable.MinCellHeight)
                                //{
                                //    info.Pos = rect.Top;
                                //}
                                //else
                                //{
                                //    info.Pos = rect.Top + TPTextTable.MinCellHeight;

                                //    foreach (TPTextCell innerCell in currRow) //遍历表格内直属表格行
                                //    {
                                //        //innerCell.Height = TPTextTable.MinCellHeight;
                                //        //innerCell.ContentHeight = innerCell.Height - innerCell.PaddingBottom - innerCell.PaddingTop;
                                //    }
                                //}

                                if (currTB.IndexOf(currRow) > 0 && !currTB.HiddenAllBorder)
                                {
                                    for (int i = 0; i < currTB.IndexOf(currRow); i++)
                                    {
                                        TPTextRow innerRow = currTB.AllRows[i] as TPTextRow;
                                        foreach (TPTextCell innerCell in innerRow)
                                        {
                                            SetCellByBottomInPageLine(innerCell, info.Pos);
                                        }
                                    }
                                }

                                return;
                            }
                            else if (rect.Top >= info.LastPos) //2014-08-05 这个非常关键——>因为创建每一页时都会从头到尾遍历RootDocumentElement.Lines
                            {
                                if ((currTB.IndexOf(currRow) == currTB.AllRows.Count - 1 && currTB.HiddenAllBorder)
                                    || (currTB.IndexOf(currRow) != currTB.AllRows.Count - 1 && !currTB.HiddenAllBorder))
                                {
                                    foreach (TPTextCell innerCell in currRow)
                                    {
                                        if (innerCell.GetContentBounds().Bottom != currTB.GetContentBounds().Bottom) //合并单元格底端有可能与表格底端重合
                                        {
                                            ResetCellByBottomInPageLine(innerCell);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                info.Pos = info.Pos - this.Info.ParagraphSpacing; //如果之前都没能确定分页线，则执行此行修正分页线位置（针对最后一个文档页）
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 递归重置处于分页线之上的单元格底端边框为无。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        /// <returns></returns>
        private bool ResetCellByBottomInPageLine(TPTextCell cell)
        {
            try
            {
                if (cell.ChildCount > 0 && cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    //foreach (TPTextRow innerRow in cell.ChildElements)
                    //{
                    //    foreach (TPTextCell innerCell in innerRow)
                    //    {
                    //        if (innerCell.ChildCount == 0) continue;
                    //        if (ResetCellByBottomInPageLine(innerCell)) continue;
                    //    }
                    //}

                    TPTextRow lastRow = cell.ChildElements[cell.ChildCount - 1] as TPTextRow; //取拆分单元格内最后一个表格行
                    foreach (TPTextCell innerCell in lastRow)
                    {
                        if (innerCell.ChildCount == 0) continue;
                        if (ResetCellByBottomInPageLine(innerCell)) continue;
                    }
                    return true;
                }
                else
                {
                    if (cell.GetContentBounds().Bottom != cell.OwnerRow.OwnerTable.GetContentBounds().Bottom)
                    {
                        cell.BorderWidthBottom = 0;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 递归设置处于分页线位置的单元格显示底端边框1。
        /// </summary>
        /// <param name="cell">指定单元格。</param>
        /// <param name="pos">指定分页线位置。</param>
        /// <returns></returns>
        private bool SetCellByBottomInPageLine(TPTextCell cell, int pos)
        {
            try
            {
                if (cell.ChildCount > 0 && cell.ChildElements[0] is TPTextRow) //拆分单元格
                {
                    //foreach (TPTextRow innerRow in cell.ChildElements)
                    //{
                    //    foreach (TPTextCell innerCell in innerRow)
                    //    {
                    //        if (innerCell.ChildCount == 0) continue;
                    //        if (SetCellByBottomInPageLine(innerCell)) continue;
                    //    }
                    //}

                    TPTextRow lastRow = cell.ChildElements[cell.ChildCount - 1] as TPTextRow; //取拆分单元格内最后一个表格行
                    foreach (TPTextCell innerCell in lastRow)
                    {
                        if (innerCell.ChildCount == 0) continue;
                        if (SetCellByBottomInPageLine(innerCell, pos)) continue;
                    }
                    return true;
                }
                else
                {
                    if (cell.GetContentBounds().Bottom == pos)
                    {
                        cell.BorderWidthBottom = 1;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool isImportXml = false;
        #endregion


        #region 宜昌中心人民医院旧版页眉Xml错误解析并配置空白页眉高度 add by myc 2014-08-26
        /// <summary>
        /// 标识是否需要配置空白页眉高度，用于判断文档分页时是否需要计算分页线位置。
        /// </summary>
        private bool isConfigHeaderHeightInYiChan = false;

        /// <summary>
        /// 保存精确计算出来的分页之后每一页文档内容高度。
        /// </summary>
        List<int> ConfigPageHeightInYiChan = new List<int>();

        /// <summary>
        /// 精确计算出来的分页之后每一页高度。
        /// </summary>
        /// <returns></returns>
        private void GetConfigPageHeightInYiChan()
        {
            try
            {
                //计算可能的文档分页界线处的文档行对象
                List<ZYTextLine> configLines = new List<ZYTextLine>();
                foreach (ZYTextLine myLine in RootDocumentElement.Lines)
                {
                    if (myLine.Container is ZYTextParagraph)
                    {
                        ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                        if (IsPageHeaderTitle(para, myLine))
                        {
                            configLines.Add(myLine);
                        }
                    }
                }

                //计算分页之后应该达到的每一页高度
                ConfigPageHeightInYiChan.Clear();
                if (configLines.Count > 0)
                {
                    if (configLines.Count == 1) //2014-08-29 对照科室单独处理：妇产科——>妇科——>知情文件，免疫细胞治疗知情同意书，报出异常
                    {
                        ConfigPageHeightInYiChan.Add(RootDocumentElement.Height);
                        isConfigHeaderHeightInYiChan = true;
                        return;
                    }

                    int startPos = configLines[0].RealTop;
                    int endPos = 0;
                    for (int i = 1; i < configLines.Count; i++)
                    {
                        if (configLines[i].RealTop - configLines[i - 1].RealTop > configLines[i - 1].FullHeight)
                        {
                            endPos = configLines[i].RealTop;
                            ConfigPageHeightInYiChan.Add(endPos - startPos);
                            startPos = endPos;
                        }
                    }
                    ConfigPageHeightInYiChan.Add(RootDocumentElement.Height - startPos);
                    isConfigHeaderHeightInYiChan = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断此段落是否有可能为宜昌中心医院的文档新页分界文档行。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private bool IsPageHeaderTitle(ZYTextParagraph para, ZYTextLine myLine)
        {
            try
            {
                if (para.Align != ParagraphAlignConst.Center) return false;
                ZYTextElement myElement = myLine.FirstElement;
                while (myElement is ZYTextChar)
                {
                    ZYTextChar currChar = myElement as ZYTextChar;
                    if (currChar.Char != ' ' && currChar.FontSize > 10.5) //处理临床路径护理记录单与医嘱页头
                    {
                        if (currChar.Char == '年' || currChar.Char == '月' || currChar.Char == '日') //处理聘请会诊同意书与邀请函日期行
                        {
                            return false;
                        }
                        return true;
                    }
                    if (myLine.Elements.IndexOf(myElement) < myLine.Elements.Count - 1)
                    {
                        myElement = myLine.Elements[myLine.Elements.IndexOf(myElement) + 1] as ZYTextElement;
                    }
                    if (myLine.Elements.IndexOf(myElement) == myLine.Elements.Count - 1) break;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region 表格跨页第三次改版 add by myc 2014-09-15
        /// <summary>
        /// 在文档正文重新分页之前，清空所有表格内单元格的切割矩形属性列表。
        /// </summary>
        private void ClearSplitRectsInCell()
        {
            try
            {
                foreach (ZYTextLine myLine in editingAreaLines[1])
                {
                    if (myLine.Container is ZYTextParagraph)
                    {
                        ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                        TPTextCell cell = this.GetOwnerCell(para.LastElement);
                        if (cell != null)
                        {
                            cell.SplitRects.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到所有跨越当前文档页标准分页线位置的单元格内文档行位置最低的那个单元格，并对其作跨页处理。
        /// </summary>
        /// <param name="info">标准分页线位置。</param>
        /// <returns></returns>
        private TPTextCell GetCellByMaxLineBottom(PageLineInfo info)
        {
            try
            {
                #region 获取跨页单元格列表
                List<TPTextCell> cells = new List<TPTextCell>();
                int maxLineBottom = 0;
                ZYTextLine pageLine = null; //保存基于文档行的分页线位置
                foreach (ZYTextLine myLine in editingAreaLines[1]) //add by myc 2014-07-03 添加原因：新版页眉二期改版之文档正文分页线计算，这个非常重要
                {
                    if (myLine.Container is ZYTextParagraph)
                    {
                        ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                        TPTextCell cell = this.GetOwnerCell(para.LastElement);
                        if (cell != null) //此时分页线位置是以myLine的顶端，也就是preLine的底端作为标准
                        {
                            if (myLine.RealTop <= info.Pos && myLine.RealTop + myLine.FullHeight > info.Pos)
                            {
                                cells.Add(cell);
                                ZYTextLine lastLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine;
                                maxLineBottom = maxLineBottom > lastLine.RealTop + lastLine.FullHeight ? maxLineBottom : lastLine.RealTop + lastLine.FullHeight;
                                pageLine = myLine;
                            }
                            else if (cell.Lines.IndexOf(myLine) == cell.Lines.Count - 1) //单元格内最后一个文档行需要特殊处理
                            {
                                if (myLine.RealTop <= info.Pos && myLine.RealTop + myLine.FullHeight + cell.PaddingBottom >= info.Pos)
                                {
                                    cells.Add(cell);
                                    ZYTextLine lastLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine;
                                    maxLineBottom = maxLineBottom > lastLine.RealTop + lastLine.FullHeight ? maxLineBottom : lastLine.RealTop + lastLine.FullHeight;
                                    pageLine = myLine;
                                }
                            }
                        }
                    }
                }
                #endregion

                if (cells.Count > 0)
                {
                    foreach (TPTextCell cell in cells)
                    {
                        ZYTextLine lastLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine;
                        if (lastLine.RealTop + lastLine.FullHeight == maxLineBottom) //找到单元格内文档行底端跨页最深的那个单元格
                        {
                            CreateSplitRectsInCell(cell, pageLine, info);
                            info.Pos = pageLine.RealTop; //更新当前文档页的分页线位置
                            return cell;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 依据通过计算得到的跨页层次最深的单元格和分页线位置基准文档行，共同创建跨页单元格的切割矩形属性列表。
        /// </summary>
        /// <returns></returns>
        private void CreateSplitRectsInCell(TPTextCell cell, ZYTextLine pageLine, PageLineInfo info)
        {
            try
            {
                //在单元格内操作文档元素后，已对表格内所有单元格作过自适应高度动态调整
                Rectangle cellRect = cell.GetContentBounds();
                ZYTextLine lastLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine; //单元格内最后一个文档行对象

                if (info.PageIndex == 0 && cell.SplitRects.Count > 0)
                {
                    cell.SplitRects.Clear();
                }

                #region 当前跨页单元格
                if (info.PageIndex == 0) //第1个文档页
                {
                    if (pageLine.RealTop - cellRect.Top == cell.PaddingTop)
                    {
                        cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, 0));
                        cell.SplitRects.Add(new Rectangle(cellRect.Left, pageLine.RealTop, cellRect.Width, cellRect.Height));
                    }
                    else
                    {
                        cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, pageLine.RealTop - cellRect.Top));
                        cell.SplitRects.Add(new Rectangle(cellRect.Left, pageLine.RealTop, cellRect.Width,
                            lastLine.RealTop + lastLine.FullHeight - pageLine.RealTop));
                    }
                }
                else //第2个文档页至第n个文档页
                {
                    if (cell.SplitRects.Count > 0)
                    {
                        int count = info.PageIndex + 1 - cell.SplitRects.Count; //当前页索引和切割矩形属性列表最大索引之差
                        int top = cell.SplitRects[info.PageIndex - count].Top;
                        cell.SplitRects.RemoveAt(info.PageIndex - count);
                        cell.SplitRects.Insert(info.PageIndex - count, new Rectangle(cellRect.Left,
                            top, cellRect.Width, pageLine.RealTop - top));
                        cell.SplitRects.Add(new Rectangle(cellRect.Left, cell.SplitRects[info.PageIndex - count].Bottom, cellRect.Width,
                            lastLine.RealTop + lastLine.FullHeight - cell.SplitRects[info.PageIndex - count].Bottom));
                    }
                    else
                    {
                        if (pageLine.RealTop - cellRect.Top == cell.PaddingTop)
                        {
                            cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, 0));
                            cell.SplitRects.Add(new Rectangle(cellRect.Left, pageLine.RealTop, cellRect.Width, cellRect.Height));
                        }
                        else
                        {
                            cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, pageLine.RealTop - cellRect.Top));
                            cell.SplitRects.Add(new Rectangle(cellRect.Left, pageLine.RealTop, cellRect.Width,
                                lastLine.RealTop + lastLine.FullHeight - pageLine.RealTop));
                        }
                    }
                }
                #endregion

                #region 当前单元格所属表格行的其他单元格
                TPTextRow row = cell.OwnerRow;
                foreach (TPTextCell innerCell in row)
                {
                    Rectangle innerRect = innerCell.GetContentBounds();
                    if (innerRect != cell.GetContentBounds() && innerCell.SplitRects.Count > 0)
                    {
                        innerCell.SplitRects.Clear();
                    }

                    if (innerRect != cell.GetContentBounds())
                    {
                        foreach (Rectangle rect in cell.SplitRects)
                        {
                            if (innerCell.SplitRects.Count == 0) //未初始化切割矩形
                            {
                                innerCell.SplitRects.Add(new Rectangle(innerRect.Left, innerRect.Top, innerRect.Width, rect.Bottom - innerRect.Top));
                            }
                            else //已初始化切割矩形
                            {
                                if (innerCell.SplitRects[innerCell.SplitRects.Count - 1].Height == 0) //特殊情况跨页
                                {
                                    innerCell.SplitRects.Add(new Rectangle(innerRect.Left,
                                        cell.SplitRects[innerCell.SplitRects.Count].Top, innerRect.Width,
                                        rect.Bottom - cell.SplitRects[innerCell.SplitRects.Count].Top));
                                }
                                else //非特殊情况跨页
                                {
                                    innerCell.SplitRects.Add(new Rectangle(innerRect.Left,
                                        innerCell.SplitRects[innerCell.SplitRects.Count - 1].Bottom, innerRect.Width,
                                        rect.Bottom - innerCell.SplitRects[innerCell.SplitRects.Count - 1].Bottom));
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新版计算分页线例程，以文档行段落作为分页标准的表格跨页。
        /// </summary>
        /// <param name="info"></param>
        public void FixPageLineThirdEditon(PageLineInfo info)
        {
            try
            {
                TPTextCell PagingCell = GetCellByMaxLineBottom(info); //add myc 2014-09-17 添加原因：这一步非常关键，针对一个表格内存在多个单元格跨页的情况，取单元格内容跨度最深的那个单元格作为基准
                if (PagingCell != null) return; //2014-09-18 交由GetCellByMaxLineBottom方法先前处理

                int pos = info.Pos;
                int min = 10000;
                ZYTextLine MinLine = null;
                foreach (ZYTextLine myLine in editingAreaLines[1]) //add by myc 2014-07-03 添加原因：新版页眉二期改版之文档正文分页线计算，这个非常重要
                {
                    int intRealTop = myLine.RealTop;
                    if (pos >= intRealTop
                        && pos - intRealTop < min
                        && pos < intRealTop + myLine.FullHeight)
                    {
                        MinLine = myLine;

                        #region add by myc 2014-09-16 表格跨页第三次改版需要
                        if (myLine.Container is ZYTextParagraph)
                        {
                            ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                            TPTextCell cell = this.GetOwnerCell(para.LastElement);
                            if (cell != null) //此时分页线位置是以myLine的顶端，也就是preLine的底端作为标准
                            {
                                cell = PagingCell;

                                #region 当前单元格
                                //在单元格内操作文档元素后，已对表格内所有单元格作过自适应高度动态调整
                                Rectangle cellRect = cell.GetContentBounds();
                                if (info.PageIndex == 0 && cell.SplitRects.Count > 0)
                                {
                                    cell.SplitRects.Clear();
                                }
                                ZYTextLine lastLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine;
                                if (info.PageIndex == 0) //第1个文档页
                                {
                                    if (isImportXml) //这个判定条件非常关键，由FromXML例程设置为真
                                    {
                                        cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, myLine.RealTop - cellRect.Top));
                                        cell.SplitRects.Add(new Rectangle(cellRect.Left, myLine.RealTop, cellRect.Width,
                                            lastLine.RealTop + lastLine.FullHeight - myLine.RealTop));
                                    }
                                    else
                                    {
                                        //TPTextCell currCell = this.GetOwnerCell(this.Content.CurrentElement); //当前光标所在单元格
                                        //if (currCell == cell) //这种判断方式不准确
                                        {
                                            if (myLine.RealTop - cellRect.Top == cell.PaddingTop)
                                            {
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, 0));
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, myLine.RealTop, cellRect.Width, cellRect.Height));
                                            }
                                            else
                                            {
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, myLine.RealTop - cellRect.Top));
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, myLine.RealTop, cellRect.Width,
                                                    lastLine.RealTop + lastLine.FullHeight - myLine.RealTop));
                                            }
                                        }
                                        //else
                                        //{
                                        //    cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, 0));
                                        //    cell.SplitRects.Add(new Rectangle(cellRect.Left, myLine.RealTop, cellRect.Width, cellRect.Height));
                                        //}
                                    }
                                }
                                else //第2个文档页至第n个文档页
                                {
                                    if (cell.SplitRects.Count > 0)
                                    {
                                        cell.SplitRects.RemoveAt(info.PageIndex);
                                        cell.SplitRects.Insert(info.PageIndex, new Rectangle(cellRect.Left,
                                            cell.SplitRects[info.PageIndex - 1].Bottom, cellRect.Width, myLine.RealTop - cell.SplitRects[info.PageIndex - 1].Bottom));
                                        cell.SplitRects.Add(new Rectangle(cellRect.Left, cell.SplitRects[info.PageIndex].Bottom, cellRect.Width,
                                            lastLine.RealTop + lastLine.FullHeight - cell.SplitRects[info.PageIndex].Bottom));
                                    }
                                    else
                                    {
                                        if (isImportXml) //这个判定条件非常关键，由FromXML例程设置为真
                                        {
                                            cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, myLine.RealTop - cellRect.Top));
                                            cell.SplitRects.Add(new Rectangle(cellRect.Left, myLine.RealTop, cellRect.Width,
                                                lastLine.RealTop + lastLine.FullHeight - myLine.RealTop));
                                        }
                                        else
                                        {
                                            if (myLine.RealTop - cellRect.Top == cell.PaddingTop)
                                            {
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, 0));
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, myLine.RealTop, cellRect.Width, cellRect.Height));
                                            }
                                            else
                                            {
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, cellRect.Top, cellRect.Width, myLine.RealTop - cellRect.Top));
                                                cell.SplitRects.Add(new Rectangle(cellRect.Left, myLine.RealTop, cellRect.Width,
                                                    lastLine.RealTop + lastLine.FullHeight - myLine.RealTop));
                                            }
                                        }
                                    }
                                }
                                #endregion

                                #region 当前单元格所属表格行的其他单元格
                                TPTextRow row = cell.OwnerRow;
                                foreach (TPTextCell innerCell in row)
                                {
                                    Rectangle innerRect = innerCell.GetContentBounds();
                                    if (innerRect != cell.GetContentBounds() && innerCell.SplitRects.Count > 0)
                                    {
                                        innerCell.SplitRects.Clear();
                                    }

                                    if (innerRect != cell.GetContentBounds())
                                    {
                                        foreach (Rectangle rect in cell.SplitRects)
                                        {
                                            if (innerCell.SplitRects.Count == 0) //未初始化切割矩形
                                            {
                                                innerCell.SplitRects.Add(new Rectangle(innerRect.Left, innerRect.Top, innerRect.Width, rect.Bottom - innerRect.Top));
                                            }
                                            else //已初始化切割矩形
                                            {
                                                if (innerCell.SplitRects[innerCell.SplitRects.Count - 1].Height == 0) //特殊情况跨页
                                                {
                                                    innerCell.SplitRects.Add(new Rectangle(innerRect.Left,
                                                        cell.SplitRects[innerCell.SplitRects.Count].Top, innerRect.Width,
                                                        rect.Bottom - cell.SplitRects[innerCell.SplitRects.Count].Top));
                                                }
                                                else //非特殊情况跨页
                                                {
                                                    innerCell.SplitRects.Add(new Rectangle(innerRect.Left,
                                                        innerCell.SplitRects[innerCell.SplitRects.Count - 1].Bottom, innerRect.Width,
                                                        rect.Bottom - innerCell.SplitRects[innerCell.SplitRects.Count - 1].Bottom));
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion

                        min = pos - intRealTop;
                    }

                    if (info.LastPos <= myLine.RealTop && myLine.RealTop + myLine.FullHeight <= info.Pos && myLine.FirstElement is ZYPageEnd)
                    {
                        MinLine = myLine;
                        min = pos - intRealTop;
                        info.Pos = MinLine.RealTop + myLine.FullHeight;
                        return;
                    }
                }

                if (MinLine != null)
                    info.Pos = MinLine.RealTop;
                else
                    info.Pos = RootDocumentElement.Top + RootDocumentElement.Height;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        /// <summary>
        /// (第一次加载文档时)自动校正页眉Xml，使得存在宏元素的文档行在文书录入界面进行宏值替换后也能一行显示。
        /// 特殊情况：如果替换值太大，超出编辑器视图区域，则允许换行。add by myc 2014-10-27。
        /// </summary>
        /// <param name="headerList"></param>
        private void CheckHeaderXMLInLoadDocument(XmlNodeList headerList)
        {
            try
            {
                if (headerList != null && headerList.Count > 0)
                {
                    foreach (XmlNode header in headerList)
                    {
                        bool flag = false; //保存是否需要处理水平线节点标志
                        string tempXml = string.Empty; //保存水平线节点Xml字符串

                        foreach (XmlNode oneNode in header.ChildNodes)
                        {
                            #region 处理水平线元素节点
                            if (oneNode.Name == "p" && oneNode.InnerXml.Contains("<horizontalLine")
                                && (oneNode.InnerXml.Contains("<span") || oneNode.InnerXml.Contains("<macro"))
                                && oneNode is XmlElement)
                            {
                                foreach (XmlNode secondNode in oneNode.ChildNodes)
                                {
                                    if (secondNode is XmlElement && secondNode.Name == "horizontalLine")
                                    {
                                        oneNode.RemoveChild(secondNode); //
                                        tempXml = secondNode.OuterXml;
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                            #endregion

                            #region 处理宏元素
                            if (oneNode.Name == "p" && oneNode.InnerXml.Contains("macro") && oneNode is XmlElement)
                            {
                                #region 判定是否需要检查Xml
                                ZYTextParagraph para = this.CreateElementByXML(oneNode as XmlElement) as ZYTextParagraph;
                                if (para != null)
                                {
                                    SetElementsVisble(para);
                                    para.RefreshSize();
                                    para.RefreshLine();
                                    int viewWidth = myPages.StandardWidth; //编辑器文档视图显示区域宽度
                                    if (para.Lines.Count > 0)
                                    {
                                        int allEleWidth = 0; //段落内所有元素宽度
                                        foreach (ZYTextLine myLine in para.Lines) //对段落内所有文档行元素重新累加宽度
                                        {
                                            foreach (ZYTextElement myElement in myLine.Elements)
                                            {
                                                allEleWidth += myElement.Width;
                                            }
                                        }
                                        if (allEleWidth < viewWidth) break; //如果没有超出文档视图区域显示宽度
                                    }
                                }
                                #endregion

                                #region 检查所有Xml元素节点
                                List<XmlNode> removeNodes = new List<XmlNode>();
                                foreach (XmlNode node in oneNode.ChildNodes)
                                {
                                    if (node.Name == "eof") continue;
                                    if (node.Name == "#whitespace") //Xml文档辅助空白标记需从段落节点p移除
                                    {
                                        removeNodes.Add(node);
                                    }
                                    else
                                    {
                                        string str = node.InnerText.TrimStart().TrimEnd(); //去除首尾空格
                                        if (str.Length == 0) //内部内容全部是空格的元素节点从段落节点p移除
                                        {
                                            removeNodes.Add(node);
                                        }
                                        else
                                        {
                                            node.InnerText = str;
                                        }
                                    }
                                }
                                foreach (XmlNode node in removeNodes)
                                {
                                    oneNode.RemoveChild(node);
                                }
                                #endregion

                                #region 计算并添加间隔空白
                                XmlNodeList macroNodes = oneNode.SelectNodes("macro");
                                if (macroNodes.Count == 0) break;
                                //第一个macro节点前面加一个空格，作为后续计算空白间隔数目标准
                                macroNodes[0].InnerText = " " + macroNodes[0].InnerText;

                                para = this.CreateElementByXML(oneNode as XmlElement) as ZYTextParagraph;
                                if (para != null)
                                {
                                    SetElementsVisble(para);
                                    para.RefreshSize();
                                    para.RefreshLine();
                                    int viewWidth = myPages.StandardWidth; //编辑器文档视图显示区域宽度
                                    if (para.Lines.Count > 0)
                                    {
                                        int allEleWidth = 0; //所有元素(非空格)宽度
                                        int spaceWidth = 0; //保存空格标准计算宽度
                                        foreach (ZYTextLine myLine in para.Lines) //对段落内所有文档行元素重新累加宽度
                                        {
                                            foreach (ZYTextElement myElement in myLine.Elements)
                                            {
                                                if (myElement is ZYTextChar && (myElement as ZYTextChar).Char == ' ')
                                                {
                                                    spaceWidth = myElement.Width;
                                                    continue;
                                                }
                                                allEleWidth += myElement.Width;
                                            }
                                        }

                                        if (allEleWidth < viewWidth) //如果没有超出文档视图区域显示宽度
                                        {
                                            int allSpaceWidth = viewWidth - allEleWidth; //计算剩余空白总宽度
                                            XmlNodeList nodes = oneNode.SelectNodes("macro");
                                            if (nodes.Count == 1)
                                            {
                                                nodes[0].InnerText = nodes[0].InnerText.TrimStart().TrimEnd(); //去除首尾空格
                                                if (oneNode.ChildNodes.Count > 2) //此时至少存在一个eof节点和macro节点
                                                {
                                                    //创建一个span元素节点
                                                    XmlNode spanNode = header.OwnerDocument.CreateElement("span");
                                                    spanNode.InnerText = " ";
                                                    oneNode.InsertBefore(spanNode, nodes[0]);
                                                }
                                            }
                                            else
                                            {
                                                int countSpan = (allSpaceWidth / spaceWidth) / (nodes.Count - 1); //每个span节点之前应该准确添加的空格数目
                                                for (int i = 0; i < nodes.Count; i++)
                                                {
                                                    nodes[i].InnerText = nodes[i].InnerText.TrimStart().TrimEnd(); //去除宏元素节点首尾空格
                                                    string str = string.Empty;
                                                    //if (i != 0)
                                                    if (i != nodes.Count - 1)
                                                    {
                                                        for (int j = 0; j < countSpan; j++)
                                                        {
                                                            str = " " + str;
                                                        }
                                                    }
                                                    if (!string.IsNullOrEmpty(str)) //重新创建span元素节点
                                                    {
                                                        XmlNode spanNode = header.OwnerDocument.CreateElement("span");
                                                        spanNode.InnerText = str;
                                                        //oneNode.InsertBefore(spanNode, nodes[i]);
                                                        oneNode.InsertAfter(spanNode, nodes[i]);
                                                    }
                                                }
                                            }
                                        }
                                        else //超出文档视图区域显示宽度时必须进行换行处理
                                        {
                                            XmlNodeList nodes = oneNode.SelectNodes("macro");
                                            for (int i = 0; i < nodes.Count; i++)
                                            {
                                                string str = nodes[i].InnerText.TrimStart().TrimEnd(); //去除首尾空格
                                                //if (i != 0)
                                                //{
                                                //    str = " " + str;
                                                //}
                                                nodes[i].InnerText = str;
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion
                        }

                        if (flag) //flag=="true"表示需要重置水平线节点为新的段落
                        {
                            XmlElement newEle = headerList[0].OwnerDocument.CreateElement("p");
                            newEle.InnerXml = tempXml + "<eof/>";
                            header.AppendChild(newEle);
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// 递归设置结构化元素显示属性Visible为true，以便于重新分行时准确计算结构化元素(尤其是单元格的新高度)。
        ///// </summary>
        ///// <param name="element">指定的结构化元素。</param>
        ///// <returns></returns>
        //private bool SetElementsVisble(ZYTextElement element)
        //{
        //    try
        //    {
        //        if (element is ZYTextContainer)
        //        {
        //            ZYTextContainer myContainer = element as ZYTextContainer;
        //            foreach (ZYTextElement myEle in myContainer.ChildElements)
        //            {
        //                if (SetElementsVisble(myEle)) continue;
        //            }
        //            return true;
        //        }
        //        else
        //        {
        //            element.Visible = true;
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// (页面设置后重绘视图时)自动校正页眉Xml，使得存在宏元素的文档行在文书录入界面进行宏值替换后也能一行显示。
        /// 特殊情况：如果替换值太大，超出编辑器视图区域，则允许换行。add by myc 2014-11-14。
        /// </summary>
        /// <param name="headerList"></param>
        public void CheckHeaderXMLInPageSetting()
        {
            try
            {
                List<ZYDocumentHeader> NewDocumentHeaderList = new List<ZYDocumentHeader>();
                foreach (ZYDocumentHeader zyDocumentHeader in this.RootDocumentElementsInHeader)
                {
                    XmlDocument headerDocument = new XmlDocument();
                    headerDocument.PreserveWhitespace = true;
                    headerDocument.AppendChild(headerDocument.CreateElement(ZYTextConst.c_Header));
                    ZYTextElement.ElementsToXML(zyDocumentHeader.ChildElements, headerDocument.DocumentElement);
                    CheckHeaderXMLInLoadDocument(headerDocument.SelectNodes("header"));
                    ZYDocumentHeader newDoocumentHeader = this.CreateElementByXML(headerDocument.DocumentElement) as ZYDocumentHeader;
                    NewDocumentHeaderList.Add(newDoocumentHeader);
                }

                this.RootDocumentElementsInHeader.Clear();
                this.RootDocumentElementsInHeader.AddRange(NewDocumentHeaderList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
