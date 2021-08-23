using System;
using System.Collections;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Diagnostics;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// <name>Emr文本文档页眉区域的文本块对象，继承自文本容器ZYTextContainer，为一个容器类型。</name>
    /// <auth>myc</auth>
    /// <date>2014-06-26</date>
    /// </summary>
    public class ZYDocumentHeader : ZYTextContainer
    {
        #region 基本属性或方法
        /// <summary>
        /// 构造函数，初始化此文本块对象，内部包含一个段落元素。
        /// </summary>
        public ZYDocumentHeader()
        {
            try
            {
                ZYTextParagraph para = new ZYTextParagraph();
                para.Parent = this;
                myChildElements.Add(para);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 提取此文本块容器的所有元素内部的文本字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToEMRString()
        {
            try
            {
                return base.ToEMRString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 重写ToString()方法。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            try
            {
                return "ZYDocumentHeader Name:" + myAttributes.GetString(ZYTextConst.c_Name)
                + " Childs:" + myChildElements.Count
                + " [" + this.RealLeft
                + "-:" + this.RealTop
                + " " + this.Width
                + "-" + this.Height + " ]";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 此文本块容器的左端位置。
        /// </summary>
        public override int Left
        {
            get
            {
                return 0;
            }
            set
            {
                if (myParent == null)
                {
                    intLeft = value;
                }
                else
                {
                    intLeft = 0;
                }
            }
        }

        /// <summary>
        /// 此文本块容器的宽度。
        /// </summary>
        public override int Width
        {
            get
            {
                if (myParent == null)
                {
                    return myOwnerDocument.Pages.StandardWidth; //文档打印页标准显示宽度
                }
                else
                {
                    return myParent.Width - this.Left;
                }
            }
            set
            {
                base.Width = value;
            }
        }

        /// <summary>
        /// 此文本块容器的高度。
        /// </summary>
        public override int Height
        {
            get
            {
                return base.Height;
            }
        }

        /// <summary>
        /// 标识是否可以包含文档内容。
        /// </summary>
        public bool NoContent
        {
            get { return myAttributes.GetBool(ZYTextConst.c_NoContent); }
            set { myAttributes.SetValue(ZYTextConst.c_NoContent, value); }
        }

        /// <summary>
        /// 此文本块容器是否锁定。
        /// </summary>
        public override bool Locked
        {
            get
            {
                if (myOwnerDocument.Loading) return false;
                if (this.NoContent == true && myOwnerDocument.Info.DesignMode == false) return true;
                return false;
            }
            set
            {
                base.Locked = value;
            }
        }

        Rectangle BoxRect = Rectangle.Empty;
        /// <summary>
        /// 重置此文本块容器的（折叠开关）包围边框（矩形）。
        /// </summary>
        private void ResetBoxRect()
        {
            try
            {
                BoxRect = myOwnerDocument.View.GetExpendHandleRect(this.RealLeft, this.RealTop, myOwnerDocument.DefaultRowHeight);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到完全包含此文本块容器的最小外切矩形区域。
        /// </summary>
        /// <returns></returns>
        public override Rectangle GetContentBounds()
        {
            try
            {
                ResetBoxRect();
                Rectangle rect = new Rectangle(this.RealLeft, this.RealTop, base.intClientWidth, this.Height);
                int dx = rect.Left - BoxRect.Left;
                rect.X -= dx;
                rect.Width += dx;
                return rect;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到指定元素的顶级（文本块）容器。
        /// </summary>
        /// <param name="myElement">指定文档元素。</param>
        /// <returns></returns>
        public static ZYDocumentHeader GetOwnerDiv(ZYTextElement myElement)
        {
            try
            {
                ZYDocumentHeader myOwnerDiv = null;
                while (myElement != null)
                {
                    myOwnerDiv = myElement as ZYDocumentHeader;
                    if (myOwnerDiv == null)
                    {
                        myElement = myElement.Parent;
                    }
                    else
                    {
                        return myOwnerDiv;
                    }
                }
                return myOwnerDiv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回对应的Xml节点名称。
        /// </summary>
        /// <returns></returns>
        public override string GetXMLName()
        {
            try
            {
                return ZYTextConst.c_Header;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 是否为整个文本行。
        /// </summary>
        /// <returns></returns>
        public override bool OwnerWholeLine()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 容器对象默认进行强制换行。
        /// </summary>
        /// <returns></returns>
        public override bool isNewLine()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 本对象是否强制开始新段落。
        /// </summary>
        /// <returns></returns>
        public override bool isNewParagraph()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 本对象是否为数据域。
        /// </summary>
        /// <returns></returns>
        public override bool isField()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 本对象是否为文本元素。
        /// </summary>
        /// <returns></returns>
        public override bool isTextElement()
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region 重绘对象
        /// <summary>
        /// 将容器内所有的元素添加到列表对象中。
        /// </summary>
        /// <param name="myList">列表对象引用传参。</param>
        /// <param name="ResetFlag">是否重置标志。</param>
        public override void AddElementToList(System.Collections.ArrayList myList, bool ResetFlag)
        {
            try
            {
                if (myList != null)
                {
                    foreach (ZYTextElement myElement in myChildElements)
                    {
                        if (!ResetFlag)
                        {
                            myElement.Visible = false;
                            myElement.Index = -1;
                        }
                        if (myOwnerDocument.isVisible(myElement) && myElement is ZYTextContainer)
                        {
                            myElement.Visible = true;
                            if (myElement is ZYTextParagraph)
                            {
                                (myElement as ZYTextParagraph).AddElementToList(myList, ResetFlag);
                            }
                            if (myElement is TPTextTable)
                            {
                                (myElement as TPTextTable).AddElementToList(myList, ResetFlag);
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
        /// 元素重新分行。
        /// </summary>
        /// <returns></returns>
        public override ArrayList RefreshLine()
        {
            try
            {
                return base.RefreshLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 刷新界面，重新绘制对象。
        /// </summary>
        /// <returns>是否进行了刷新操作</returns>
        public override bool RefreshView()
        {
            try
            {
                return base.RefreshView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region 鼠标事件
        /// <summary>
        /// 处理鼠标点击事件。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Button"></param>
        /// <returns></returns>
        public override bool HandleClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            try
            {
                return base.HandleClick(x, y, Button);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 处理鼠标按下事件。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Button"></param>
        /// <returns></returns>
        public override bool HandleMouseDown(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            try
            {
                return base.HandleMouseDown(x, y, Button);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 处理鼠标移动事件。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Button"></param>
        /// <returns></returns>
        public override bool HandleMouseMove(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            try
            {
                return base.HandleMouseMove(x, y, Button);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region 光标定位与元素操作相关
        private ArrayList innerElements = new ArrayList();
        /// <summary>
        /// 页眉区域的可见元素列表，存储内部的所有文本类型元素。
        /// </summary>
        public ArrayList InnerElements
        {
            get { return innerElements; }
            set { innerElements = value; }
        }

        private ArrayList innerLines = new ArrayList();
        /// <summary>
        /// 页眉区域的文本行列表，存储内部的所有文本行对象。
        /// </summary>
        public ArrayList InnerLines
        {
            get { return innerLines; }
            set { innerLines = value; }
        } 
        #endregion

    }
}
