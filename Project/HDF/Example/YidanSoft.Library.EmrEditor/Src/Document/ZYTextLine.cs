using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 文档行对象
    /// </summary>
    public class ZYTextLine
    {

        /// <summary>
        /// 本行所包含的元素
        /// </summary>
        public System.Collections.ArrayList Elements = new System.Collections.ArrayList();
        /// <summary>
        /// 文本行所在的容器对象
        /// </summary>
        public ZYTextContainer Container = null;

        /// <summary>
        /// 本行和下一行的间距
        /// </summary>
        public int LineSpacing = 0;

        /// <summary>
        /// 文本行的高度
        /// </summary>
        public int Height = 0;

        /// <summary>
        /// 获得行的全部高度
        /// </summary>
        public int FullHeight
        {
            get { return Height + LineSpacing; }
        }

        /// <summary>
        /// 文本行在容器中的顶端位置
        /// </summary>
        public int Top = 0;
        /// <summary>
        /// 文本行在容器中的底端位置
        /// </summary>
        public int Bottom
        {
            get { return Top + Height; }
        }

        /// <summary>
        /// 本行第一个元素
        /// </summary>
        public ZYTextElement FirstElement
        {
            get
            {
                if (Elements != null && Elements.Count > 0)
                    return (ZYTextElement)Elements[0];
                else
                    return null;
            }
        }
        /// <summary>
        /// 本行最后一个元素
        /// </summary>
        public ZYTextElement LastElement
        {
            get
            {
                if (Elements != null && Elements.Count > 0)
                    return (ZYTextElement)Elements[Elements.Count - 1];
                else
                    return null;
            }
        }
        public string ToEMRString()
        {
            if (Elements != null && Elements.Count > 0)
            {
                System.Text.StringBuilder myStr = new System.Text.StringBuilder();
                foreach (ZYTextElement e in Elements)
                    myStr.Append(e.ToEMRString());
                return myStr.ToString();
            }
            return null;
        }
        /// <summary>
        /// 本文本行尾是否是强制换行的
        /// </summary>
        public bool HasLineEnd
        {
            get
            {
                return Elements != null && Elements.Count > 0 && ((ZYTextElement)Elements[Elements.Count - 1]).isNewLine();
            }
        }

        /// <summary>
        /// 该文本行在文档中的绝对行号
        /// </summary>
        public int RealIndex = 0;
        /// <summary>
        /// 文本行在文档中的绝对左端位置
        /// </summary>
        public int RealLeft = 0;

        private int realTop = 0;

        /// <summary>
        /// 文本行在文档中的绝对顶端位置
        /// </summary>
        public int RealTop
        {
            get
            {
                return this.realTop;
            }
            set
            {
                this.realTop = value;
            }
        }

        /// <summary>
        /// 文本行底部在文档视图中的位置
        /// </summary>
        public int RealBottom
        {
            get { return RealTop + Height; }
        }


        /// <summary>
        /// 行号
        /// </summary>
        public int Index = 0;
        /// <summary>
        /// 文本行中元素的总宽度
        /// </summary>
        public int ContentWidth = 0;


        /// <summary>
        /// 计算该文本行在文档中的绝对行号
        /// </summary>
        public int CalcuteRealIndex()
        {
            int intCount = Index;
            ZYTextContainer myElement = Container;
            while (myElement != null && myElement.OwnerLine != null)
            {
                intCount += (myElement.OwnerLine.Index + myElement.LineSpan - 1);
                myElement = myElement.Parent;
            }
            return intCount;
        }
    }
}
