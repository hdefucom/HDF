using System;
using System.Collections;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Collections.Generic;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 段落对齐样式
    /// </summary>
    public enum ParagraphAlignConst
    {
        /// <summary>
        /// 左对齐
        /// </summary>
        Left = 0,
        /// <summary>
        /// 右对齐
        /// </summary>
        Right = 1,
        /// <summary>
        /// 居中对齐
        /// </summary>
        Center = 2,
        /// <summary>
        /// 两边对齐
        /// </summary>
        Justify = 4,

        /// <summary>
        /// 分散对齐 mfb
        /// </summary>
        Disperse = 5
    }

    /// <summary>
    /// 段落头标记对象 
    /// </summary>
    public class ZYTextParagraph : ZYTextContainer
    {

        private int firstLineIndent = 0; //首行缩进 mfb
        private int leftIndent = 0;      //增加左缩进的量 mfb
        private ZYTextEOF eof;

        public ZYTextParagraph()
        {
            eof = new ZYTextEOF();
            eof.Parent = this;
            myChildElements.Add(eof);
        }

        #region 公有属性

        #region  height, width
        public override int Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
            }
        }
        public override int Width
        {
            get
            {
                if (myParent == null)
                    return myOwnerDocument.Pages.StandardWidth;
                else
                    return myParent.Width - this.Left;
            }
            set
            {
                base.Width = value;
            }
        }
        #endregion

        //private double lineHeightMultiple = 1;
        /// <summary>
        /// 行高倍数
        /// 2019.07.03-hdf  添加设置行高功能
        /// </summary>
        public double LineHeightMultiple
        {
            //get { return lineHeightMultiple; }
            //set { lineHeightMultiple = value; }
            get { return myAttributes.GetFloat(ZYTextConst.c_LineHeightMultiple); }
            set { myAttributes.SetValue(ZYTextConst.c_LineHeightMultiple, (double)value); }
        }

        public ParagraphAlignConst Align
        {
            get { return (ParagraphAlignConst)myAttributes.GetInt32(ZYTextConst.c_Align); }
            set { myAttributes.SetValue(ZYTextConst.c_Align, (int)value); }
        }
        /// <summary>
        /// 是否左对齐
        /// </summary>
        public bool LeftAlign
        {
            get { return this.Align == ParagraphAlignConst.Left; }
            set { this.Align = ParagraphAlignConst.Left; }
        }
        /// <summary>
        /// 是否居中对齐
        /// </summary>
        public bool CenterAlign
        {
            get { return this.Align == ParagraphAlignConst.Center; }
            set { this.Align = ParagraphAlignConst.Center; }
        }
        /// <summary>
        /// 是否右对齐
        /// </summary>
        public bool RightAlign
        {
            get { return this.Align == ParagraphAlignConst.Right; }
            set { this.Align = ParagraphAlignConst.Right; }
        }

        /// <summary>
        /// 是否两边对齐
        /// </summary>
        public bool JustifyAlign
        {
            get { return this.Align == ParagraphAlignConst.Justify; }
            set { this.Align = ParagraphAlignConst.Justify; }
        }

        /// <summary>
        /// 是否分散对齐 mfb
        /// </summary>
        public bool DisperseAlign
        {
            get { return this.Align == ParagraphAlignConst.Disperse; }
            set { this.Align = ParagraphAlignConst.Disperse; }
        }

        /// <summary>
        /// 首行缩进
        /// </summary>
        public int FirstLineIndent
        {
            get { return firstLineIndent; }
            set { firstLineIndent = value; }
        }
        /// <summary>
        /// 左缩进
        /// </summary>
        public int LeftIndent
        {
            get { return leftIndent; }
            set { leftIndent = value; }
        }

        public ZYTextEOF PEOF
        {
            get
            {
                return eof;
            }
        }


        #endregion

        public override string GetXMLName()
        {
            return ZYTextConst.c_P;
        }
        public override bool isNewLine()
        {
            return true;
        }
        public override bool isField()
        {
            return true;
        }
        public override bool OwnerWholeLine()
        {
            return true;
        }
        #region RefreshView, RefreshLine

        /// <summary>
        /// 刷新界面,重新绘制对象
        /// </summary>
        /// <returns>是否进行了刷新操作</returns>
        public override bool RefreshView()
        {
            return base.RefreshView();
        }
        /// <summary>
        /// 元素重新分行
        /// </summary>
        /// <returns></returns>
        public override ArrayList RefreshLine()
        {
            return base.RefreshLine();
        }
        #endregion


        /// <summary>
        /// 去除容器中的按钮类型的文字
        /// edit by ywk 解决在入院记录中的标签元素连续书写，然后书写病程时的重复书写复用项目的BUG
        /// 2012年11月7日8:53:37  浦口需求 大病历是连着书写的
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ToEmrString2()
        {
            if (myChildElements.Count == 0)
                return null;
            System.Collections.ArrayList myElements = this.GetVisibleElements();
            FixForKeyField(myElements);

            //edit by ywk 2012年11月7日9:02:47
            string Findkey = string.Empty;//用于存放标签的键值
            string FindValue = string.Empty;//暂时保留的字符串 主要保存标签后面要处理掉的标签元素
            Dictionary<string, string> myDic = new Dictionary<string, string>();
            ArrayList myKeyArr = new ArrayList();//用于保存KEY
            ArrayList myValueArr = new ArrayList();//用于保存值
            string ReturnStr = string.Empty;//最终返回的字符串
            System.Text.StringBuilder myStr = new System.Text.StringBuilder(myChildElements.Count);
            foreach (ZYTextElement myElement in myElements)
            {
                if (myElement is ZYButton)
                    continue;
                if (myElement is ZYFixedText)//如果是标签就加以区分
                {
                    Findkey = myElement.ToEMRString();
                    myKeyArr.Add(Findkey);
                    myStr.Append("$" + myElement.ToEMRString());//标签前面加特殊字符用于区分
                }
                else
                {
                    myStr.Append(myElement.ToEMRString());
                }
            }
            ReturnStr = myStr.ToString();//最终返回的字符串
            string[] strvalue = ReturnStr.Split('$');
            string tempvalue=string.Empty;//临时变量
            for (int k = 1; k < strvalue.Length; k++)
            {
                tempvalue = strvalue[k].ToString().Substring(strvalue[k].ToString().IndexOf(myKeyArr[k-1].ToString()) + myKeyArr[k-1].ToString().Length );
                //strvalue[k].Remove(0, myKeyArr[k].ToString().Trim());
                myValueArr.Add(tempvalue);
            }
         
            for (int j = 0; j < myKeyArr.Count; j++)
            {
                myDic.Add(myKeyArr[j].ToString(), myValueArr[j].ToString());//加到字典中
            }
            return myDic;
            //return ReturnStr;
        }
    }
}
