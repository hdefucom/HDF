using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 矩形区域累计对象
    /// </summary>
    public class RectangleCounter
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public RectangleCounter()
        {
        }
        private System.Drawing.Rectangle myRect = System.Drawing.Rectangle.Empty;
        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            myRect = System.Drawing.Rectangle.Empty;
        }
        /// <summary>
        /// 添加矩形区域
        /// </summary>
        /// <param name="rect">矩形区域对象</param>
        public void Add(System.Drawing.Rectangle rect)
        {
            if (myRect.IsEmpty)
                myRect = rect;
            else
                myRect = System.Drawing.Rectangle.Union(myRect, rect);
        }
        /// <summary>
        /// 添加矩形区域
        /// </summary>
        /// <param name="left">左端位置</param>
        /// <param name="top">顶端位置</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public void Add(int left, int top, int width, int height)
        {
            Add(new System.Drawing.Rectangle(left, top, width, height));
        }
        /// <summary>
        /// 对象数据是否为空
        /// </summary>
        public bool IsEmpty
        {
            get { return myRect.IsEmpty; }
        }
        /// <summary>
        /// 当前数值
        /// </summary>
        public System.Drawing.Rectangle Value
        {
            get { return myRect; }
        }
    }//public class RectangleCounter
}
