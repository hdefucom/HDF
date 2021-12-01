using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Windows.Forms;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 电子病历文本文档基本元素
    /// </summary>
    public class ZYTextElement
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ZYTextElement()
        {
            myAttributes.OwnerElement = this;

            //右键菜单的委托
            contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenu_ItemClicked);
        }

        ElementType type;
        public ElementType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 确定元素是否需要打印,用于选择打印
        /// </summary>
        /// <returns></returns>
        public virtual bool IsNeedPrint()
        {
            //如果是选择打印，则判断是否在范围之内
            if (this.OwnerDocument.EnableSelectionPrint && this.OwnerDocument.Info.Printing)
            {
                //add by myc 2014-08-25 添加原因：处理宜昌中心医院打印选中元素时的页眉和页脚打印与不打印问题
                if (this.OwnerDocument.GetOwnerRoot(this) is ZYDocumentHeader || this.OwnerDocument.GetOwnerRoot(this) is ZYDocumentFooter) return true;
                
                int selstart = this.OwnerDocument.Content.SelectStart;
                int sellength = this.OwnerDocument.Content.SelectLength;
                int selend = selstart + sellength;
                if (selstart > selend)
                {
                    selstart = selstart + selend;
                    selend = selstart - selend;
                    selstart = selstart - selend;
                }
                
                //int index = this.OwnerDocument.Elements.IndexOf(this); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                int index = this.OwnerDocument.HBFElements.IndexOf(this); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                
                if (selstart <= index && index < selend)
                {
                    //打印
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public virtual void  contextMenu_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public int WidthFix = 0; //这个代表元素与元素之间的间距宽度. 在分散对齐时有用.

        //右键菜单，可以在此类的派生类的初始化时，为它添加左键菜单选项。并重写contextMenu_ItemClicked以处理不同操作。
        public   System.Windows.Forms.ContextMenuStrip contextMenu = new System.Windows.Forms.ContextMenuStrip();

        #region  普通属性群

        #region left, top, width, height
        /// <summary>
        /// 元素的左端位置(相对于元素所在行的)
        /// </summary>
        protected int intLeft = 0;
        /// <summary>
        /// 元素左端位置(相对于元素所在行的)
        /// </summary>
        public virtual int Left
        {
            get { return intLeft; }
            set { intLeft = value; }
        }
        /// <summary>
        /// 元素的顶端位置(相对于元素所在行的)
        /// </summary>
        protected int intTop = 0;		//
        /// <summary>
        /// 元素顶端位置(相对于元素所在行的)
        /// </summary>
        public virtual int Top
        {
            get { return intTop; }
            set { intTop = value; }
        }

        /// <summary>
        /// 元素宽度
        /// </summary>
        protected int intWidth = 0;		// 
        /// <summary>
        /// 元素宽度
        /// </summary>
        public virtual int Width
        {
            get { return intWidth; }
            set { intWidth = value; }
        }
        
        /// <summary>
        /// 元素高度
        /// </summary>
        protected int intHeight = 0;		// 
        /// <summary>
        /// 元素高度，返回对象的高度,如果是container行高度 + intTopMargin + intBottomMargin
        /// </summary>
        public virtual int Height
        {
            get { return intHeight; }
            set { intHeight = value; }
        }
        #endregion

        /// <summary>
        /// 元素是否是绝对定位,暂未支持
        /// </summary>
        protected bool bolAbsolutePos = false;	// 
        /// <summary>
        /// 元素是否采用绝对坐标
        /// </summary>
        public bool AbsolutePos
        {
            get { return bolAbsolutePos; }
            set { bolAbsolutePos = value; }
        }

        #region intDeleter, intCreatorIndex

        /// <summary>
        /// 内部的删除该元素的保存日志的记录编号
        /// </summary>
        private int intDeleter = -1;
        
        /// <summary>
        /// 删除该元素的保存记录的编号
        /// </summary>
        public int DeleterIndex
        {
            get { return intDeleter; }
            set
            {
                intDeleter = value;
                if (value >= 0)
                    myAttributes.SetValue(ZYTextConst.c_Deleter, intDeleter.ToString());
                else
                    myAttributes.RemoveAttribute(ZYTextConst.c_Deleter);
            }
        }
        /// <summary>
        /// 设置,返回删除标志
        /// </summary>
        public virtual bool Deleteted
        {
            get { return intDeleter >= 0; }
            set
            {
                if (value)
                    this.DeleterIndex = myOwnerDocument.SaveLogs.CurrentIndex;
                else
                this.DeleterIndex = -1;
            }
        }
        /// <summary>
        /// 内部的元素的保存日志记录的编号
        /// </summary>
        private int intCreatorIndex = -1;
        /// <summary>
        /// 元素创建者
        /// </summary>
        public int CreatorIndex
        {
            get { return intCreatorIndex; }
            set
            {
                intCreatorIndex = value;
                if (value > 0)
                    myAttributes.SetValue(ZYTextConst.c_Creator, value.ToString());
                else
                    myAttributes.RemoveAttribute(ZYTextConst.c_Creator);

            }
        }
        #endregion

        /// <summary>
        /// 元素在文档的可见元素列表中的序号(此属性是以空间换时间,提高文档处理速度)
        /// </summary>
        internal int Index = -1;
        private bool bolVisible = false;
        /// <summary>
        ///  元素是否可见(此属性是以空间换时间,提高文档处理速度)
        /// </summary>
        internal bool Visible
        {
            get { return bolVisible; }
            set { bolVisible = value; }
        }

        /// <summary>
        /// 元素在文档视图区域中的边框
        /// </summary>
        internal System.Drawing.Rectangle myBounds = System.Drawing.Rectangle.Empty;
        /// <summary>
        /// 获得元素的位置和大小
        /// </summary>
        public virtual System.Drawing.Rectangle Bounds
        {
            get { return myBounds; }
        }

        #endregion

        #region  对象属性群

        /// <summary>
        /// 边框对象
        /// </summary>
        protected ZYTextBorder myBorder = null;
        /// <summary>
        /// 对象的边框
        /// </summary>
        public ZYTextBorder Border
        {
            get { return myBorder; }
            set { myBorder = value; }
        }

        //TODO: | ZYTextElement | 属性集合改为.net自带的XmlAttributeCollection
        /// <summary>
        /// 属性列表
        /// </summary>
        protected ZYAttributeCollection myAttributes = new ZYAttributeCollection();
        /// <summary>
        /// return attribute set colleciton object
        /// </summary>
        public ZYAttributeCollection Attributes
        {
            get { return myAttributes; }
        }

        /// <summary>
        /// 元素所在文档对象
        /// </summary>
        protected ZYTextDocument myOwnerDocument = null;
        /// <summary>
        /// 元素所属文档对象
        /// </summary>
        public virtual ZYTextDocument OwnerDocument
        {
            get { return myOwnerDocument; }
            set
            {
                myOwnerDocument = value;
                #region comment
                //				// 从旧的文档对象中脱离关系
                //				if(myOwnerDocument != null && myOwnerDocument.Elements.IndexOf(this) >=0 )
                //					myOwnerDocument.Elements.Remove(this);
                //
                //				myOwnerDocument = value;
                //				if(myOwnerDocument != null && myOwnerDocument.Elements.IndexOf(this) < 0 )
                //					myOwnerDocument.Elements.Add(this);
                //
                //				if(this.isContainer() && myOwnerDocument != null)
                //				{
                //					foreach(ZYTextElement myElement in myChildElements)
                //						myElement.OwnerDocument = myOwnerDocument ;
                //					intLeft = myOwnerDocument.ContainerIndent ;
                //				}
                #endregion
            }
        }

        /// <summary>
        /// 父容器对象
        /// </summary>
        protected ZYTextContainer myParent = null;
        /// <summary>
        /// 父元素
        /// </summary>
        public virtual ZYTextContainer Parent
        {
            get { return myParent; }
            set { myParent = value; }
        }

        /// <summary>
        /// 元素所在的文本行对象
        /// </summary>
        protected ZYTextLine myOwnerLine = null;
        /// <summary>
        /// 本元素所在的文本行
        /// </summary>
        public ZYTextLine OwnerLine
        {
            get { return myOwnerLine; }
            set { myOwnerLine = value; }
        }

        #endregion

        #region ZYTextLine运算相关,行号
        /// <summary>
        /// 进行分页处理
        /// </summary>
        /// <param name="LinePos">旧的分页符位置</param>
        /// <returns>修正后的分页符位置,为-1表示没有进行处理</returns>
        public virtual int FixPageLinePos(int LinePos)
        {
            int vTop = this.RealTop;
            if (LinePos > vTop && LinePos < vTop + intHeight)
                return vTop;
            else
                return -1;
        }

        /// <summary>
        /// 该元素所在的文本行号
        /// </summary>
        public int LineIndex
        {
            get { return (myOwnerLine == null ? 0 : myOwnerLine.Index); }
        }
        /// <summary>
        /// 该元素在文档中的绝对行号
        /// </summary>
        public int RealLineIndex
        {
            get { return (myOwnerLine == null ? 0 : myOwnerLine.RealIndex); }
        }
        #endregion

        #region realTop,realLeft
        /// <summary>
        /// 获得元素在文档中的顶端位置
        /// </summary>
        public virtual int RealTop
        {
            get
            {
                if (myOwnerLine == null || bolAbsolutePos)
                    return intTop;
                else
                    return intTop + myOwnerLine.RealTop;
            }
        }

        /// <summary>
        /// 获得元素在文档中的左端位置
        /// </summary>
        public virtual int RealLeft
        {
            get
            {
                if (myOwnerLine == null || bolAbsolutePos)
                    return intLeft;
                //if (myOwnerLine == null || bolAbsolutePos)
                //{
                //    if (myOwnerLine.Container is TPTextRow)
                //    {
                //        return intLeft + (myOwnerLine.Container as TPTextRow).OwnerTable.OffsetX;
                //    }
                //    else
                //    {
                //        return intLeft;
                //    }
                //}
                else
                    return intLeft + myOwnerLine.RealLeft;
            }
        }
        #endregion

        #region RefreshSize,RefreshView,RefreshLine
        /// <summary>
        /// 重新计算对象大小
        /// </summary>
        /// <returns>操作是否成功</returns>
        public virtual bool RefreshSize()
        {
            return true;
        }
        /// <summary>
        /// 重新绘制对象
        /// </summary>
        /// <returns>操作是否成功</returns>
        public virtual bool RefreshView()
        {
            return true;
        }
        ///// <summary>
        ///// 重新分行 mfb
        ///// </summary>
        ///// <returns></returns>
        //public virtual bool RefreshLine()
        //{
        //    return true;
        //}
        #endregion

        #region ---------------------Handle Method
        /// <summary>
        /// 元素为当前元素时的处理
        /// </summary>
        public virtual void HandleEnter()
        {
            if (myParent != null) myParent.HandleEnter();
        }
        /// <summary>
        /// 元素从当前元素变成不是当前元素时的处理
        /// </summary>
        public virtual void HandleLeave()
        {
            if (myParent != null) myParent.HandleLeave();
        }


        /// <summary>
        /// 当元素选择状态发生改变时的处理
        /// </summary>
        /// <returns>当元素重新设置了选择区域时返回True </returns>
        public virtual bool HandleSelectedChange() { return false; }

        /// <summary>
        /// 处理鼠标按键单击事件
        /// </summary>
        /// <param name="x">鼠标在文档中的X坐标</param>
        /// <param name="y">鼠标在文档中的Y坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>是否进行了处理,若进行了处理则其他元素则不必进行鼠标事件处理</returns>
        public virtual bool HandleClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            return false;
        }

        /// <summary>
        /// 处理鼠标按键双击事件
        /// </summary>
        /// <param name="x">鼠标在文档中的X坐标</param>
        /// <param name="y">鼠标在文档中的Y坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>是否进行了处理,若进行了处理则其他元素则不必进行鼠标事件处理</returns>
        public virtual bool HandleDblClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            return false;
        }
        /// <summary>
        /// 处理鼠标移动事件
        /// </summary>
        /// <param name="x">鼠标在文档中的X坐标</param>
        /// <param name="y">鼠标在文档中的Y坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>是否进行了处理,若进行了处理则其他元素则不必进行鼠标事件处理</returns>
        public virtual bool HandleMouseMove(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            return false;
        }
        /// <summary>
        /// 处理鼠标按键按下事件
        /// </summary>
        /// <param name="x">鼠标在文档中的X坐标</param>
        /// <param name="y">鼠标在文档中的Y坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>是否进行了处理,若进行了处理则其他元素则不必进行鼠标事件处理</returns>
        public virtual bool HandleMouseDown(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            return false;
        }
        /// <summary>
        /// 处理鼠标按键松开事件
        /// </summary>
        /// <param name="x">鼠标在文档中的X坐标</param>
        /// <param name="y">鼠标在文档中的Y坐标</param>
        /// <param name="Button">鼠标按键</param>
        /// <returns>是否进行了处理,若进行了处理则其他元素则不必进行鼠标事件处理</returns>
        public virtual bool HandleMouseUp(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            return false;
        }
        #endregion

        #region ---------------- FromXML,ToXML

        /// <summary>
        /// 获得对象保存的XML节点的名称
        /// </summary>
        /// <returns></returns>
        public virtual string GetXMLName()
        {
            return null;
        }

        /// <summary>
        /// convert object to emr doc content 
        /// </summary>
        /// <returns>content</returns>
        public virtual string ToEMRString()
        {
            return "";
        }



        /// <summary>
        /// 向XML节点保存对象数据
        /// </summary>
        /// <param name="myElement">XML节点</param>
        /// <returns>保存是否成功</returns>
        public virtual bool ToXML(System.Xml.XmlElement myElement)
        {
            switch (myOwnerDocument.Info.SaveMode)
            {
                case 0: // 保存所有数据
                    myAttributes.ToXML(myElement);
                    break;
                case 1: // 只保存文本数据
                    if (this.isField())
                    {
                        myElement.SetAttribute(ZYTextConst.c_Name, myAttributes.GetString(ZYTextConst.c_Name));
                        if (StringCommon.isBlankString(myAttributes.GetString(ZYTextConst.c_ID)))
                        {
                            myAttributes.SetValue(ZYTextConst.c_ID, StringCommon.AllocObjectName());
                        }
                        myElement.SetAttribute(ZYTextConst.c_ID, myAttributes.GetString(ZYTextConst.c_ID));
                        myElement.InnerText = this.ToEMRString();
                    }
                    break;
                case 2: // 只保存结构化数据
                    if (this.isField())
                    {
                        myElement.SetAttribute(ZYTextConst.c_Name, myAttributes.GetString(ZYTextConst.c_Name));
                        if (StringCommon.isBlankString(myAttributes.GetString(ZYTextConst.c_ID)))
                        {
                            myAttributes.SetValue(ZYTextConst.c_ID, StringCommon.AllocObjectName());
                        }
                        myElement.SetAttribute(ZYTextConst.c_ID, myAttributes.GetString(ZYTextConst.c_ID));
                        myElement.InnerText = this.ToEMRString();
                    }
                    break;
            }
            return true;
        }

        //
        //		/// <summary>
        //		/// 向XML节点追加对象数据的函数
        //		/// </summary>
        //		/// <param name="myElement">XML节点</param>
        //		/// <returns>追加是否成功</returns>
        //		public virtual bool AppendToXML(System.Xml.XmlElement myElement)
        //		{
        //			return true;
        //		}
        //	
        

        /// <summary>
        /// 对元素数据进行基础的加载
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        protected bool BaseFromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                myAttributes.FromXML(myElement);
                //myAttributes.RemoveAttribute(ZYTextConst.c_Creator);
                //myAttributes.RemoveAttribute(ZYTextConst.c_Deleter);
                myAttributes.RemoveAttribute("createtime");
                myAttributes.RemoveAttribute("deletetime");
                if (myElement.HasAttribute(ZYTextConst.c_Creator))
                    this.CreatorIndex = StringCommon.ToInt32Value(myElement.GetAttribute(ZYTextConst.c_Creator), 0);
                else
                    this.CreatorIndex = 0;
                if (myElement.HasAttribute(ZYTextConst.c_Deleter))
                    this.DeleterIndex = StringCommon.ToInt32Value(myElement.GetAttribute(ZYTextConst.c_Deleter), -1);
                else
                    this.DeleterIndex = -1;
                //intDeleter = myAttributes.GetInt32( ZYTextConst.c_Deleter );
                //intCreatorIndex = myAttributes.GetInt32( ZYTextConst.c_Creator);
                if (myBorder != null)
                    myBorder.FromXML(myElement);
                UpdateAttrubute();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 从XML节点加载对象数据,该方法在重载的方法中必须被调用
        /// </summary>
        /// <param name="myElement">XML节点</param>
        /// <returns>加载是否成功</returns>
        public virtual bool FromXML(System.Xml.XmlElement myElement)
        {
            //myAttributes.Clear();
            return BaseFromXML(myElement);
            //
            //			myAttributes.FromXML(myElement);
            //			intDeleter = myAttributes.GetInt32( ZYTextConst.c_Deleter );
            //			intCreatorIndex = myAttributes.GetInt32( ZYTextConst.c_Creator);
            //			bolDeleted = (this.DeleterIndex >=0 );
            //			if(myBorder != null)
            //				myBorder.FromXML(myElement);
            //			// 进行扩展加载
            //			return true;
        }

        public static bool ElementsToXML(System.Collections.ArrayList myList, System.Xml.XmlElement RootElement)
        {
            if (myList != null && RootElement != null)
            {
                foreach (ZYTextElement myElement in myList)
                {
                    string strName = myElement.GetXMLName();
                    if (strName != null && System.Xml.XmlReader.IsName(strName))
                    {
                        System.Xml.XmlElement myXMLElement = RootElement.OwnerDocument.CreateElement(strName);
                        myElement.ToXML(myXMLElement);
                        RootElement.AppendChild(myXMLElement);
                    }
                }
                return true;
            }
            return false;
        }

        #endregion

        #region 判断方法群,isTextElement, isField, isNewLine, isNewParagraph | CanBeLineHead, CanBeLineEnd
        /// <summary>
        /// 是否为纯文本元素
        /// </summary>
        /// <returns></returns>
        public virtual bool isTextElement()
        {
            return true;
        }

        /// <summary>
        /// 该元素是否是一个域
        /// 这里域的概念指的是块的概念,容器的概念
        /// </summary>
        /// <returns></returns>
        public virtual bool isField()
        {
            return false;
        }

        /// <summary>
        /// 本对象是否强制开始新行
        /// </summary>
        /// <returns></returns>
        public virtual bool isNewLine()
        {
            return false;
        }

        

        /// <summary>
        /// 本对象是否强制开始新段落
        /// </summary>
        /// <returns></returns>
        public virtual bool isNewParagraph()
        {
            return false;
        }

        /// <summary>
        /// 对象是否可以在行首
        /// </summary>
        /// <returns></returns>
        public virtual bool CanBeLineHead()
        {
            return true;
        }

        /// <summary>
        /// 对象是否可以在行尾
        /// </summary>
        /// <returns></returns>
        public virtual bool CanBeLineEnd()
        {
            return true;
        }
        #endregion 

        /// <summary>
        /// 更新属性值
        /// </summary>
        public virtual void UpdateAttrubute()
        {
            intDeleter = StringCommon.ToInt32Value(myAttributes.GetString(ZYTextConst.c_Deleter), -1);
            intCreatorIndex = StringCommon.ToInt32Value(myAttributes.GetString(ZYTextConst.c_Creator), -1);
        }

        /// <summary>
        /// 该元素单独的占有一行
        /// </summary>
        /// <returns></returns>
        public virtual bool OwnerWholeLine()
        {
            return false;
        }
        public static bool FixElementsForParent(System.Collections.ArrayList myList)
        {
            if (myList != null && myList.Count > 0)
            {
                for (int iCount = myList.Count - 1; iCount >= 0; iCount--)
                {
                    if (iCount >= myList.Count)
                        iCount = myList.Count - 1;
                    ZYTextElement myElement = (ZYTextElement)myList[iCount];
                    if (myList.Contains(myElement.Parent))
                    {
                        myList.Remove(myElement);
                    }
                }//for
                return true;
            }
            return false;
        }//public static bool FixElementsForParent(System.Collections.ArrayList myList )

        /// <summary>
        /// 获得某个元素列表中所有元素的文本
        /// </summary>
        /// <param name="myList">元素列表</param>
        /// <returns>元素的文本,若不可转换文本则返回空</returns>
        public static string GetElementsText(System.Collections.ArrayList myList)
        {
            if (myList == null)
            {
                return null;
            }
            else
            {
                System.Text.StringBuilder myStr = new System.Text.StringBuilder();
                foreach (ZYTextElement myElement in myList)
                {
                    if (myElement.isTextElement() || myElement is ZYElement)
                    {
                        string strText = myElement.ToEMRString();
                        if (strText != null)
                        {
                            //Add by wwj 2013-02-01 筛选掉\r和\n  
                            //由于这两个字符在编辑器中不显示，但是在粘贴进编辑器中之后会变成回车符
                            //这样就会出现多余的回车符，导致不必要的换行，所以这里要进行筛选
                            if (strText != "\r" && strText != "\n")
                            {
                                myStr.Append(strText);
                            }
                        }
                    }

                }
                return myStr.ToString();
            }
        }

        /// <summary>
        /// 处理输入的字符
        /// Add By wwj 2012-06-06
        /// </summary>
        /// <param name="preLineCount">输入字符前的行数</param>
        /// <returns>false:表示不用处理 true:表示已经处理过了</returns>
        public virtual bool ProcessInsertChar(int preLineCount)
        {
            return false;
        }
    }
}
