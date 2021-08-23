using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 元素的边框样式类
    /// </summary>
    public class ZYTextBorder
    {
        // 定义默认值
        // 边框默认的颜色
        public static System.Drawing.Color DefaultColor = System.Drawing.Color.Black;
        // 边框默认的样式
        public const System.Windows.Forms.ButtonBorderStyle DefaultStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
        // 边框默认的宽度
        public const int DefaultWidth = 0;
        // 模板背景颜色
        public static System.Drawing.Color DefaultBackColor = System.Drawing.Color.White;

        // 定义字符串常量
        public const string c_Border_Top_Color = "border-top-color";
        public const string c_Border_Top_Width = "border-top-width";
        public const string c_Border_Top_Style = "border-top-style";

        public const string c_Border_Right_Color = "border-right-color";
        public const string c_Border_Right_Width = "border-right-width";
        public const string c_Border_Right_Style = "border-right-style";

        public const string c_Border_Bottom_Color = "border-bottom-color";
        public const string c_Border_Bottom_Width = "border-bottom-width";
        public const string c_Border_Bottom_Style = "border-bottom-style";

        public const string c_Border_Left_Color = "border-left-color";
        public const string c_Border_Left_Width = "border-left-width";
        public const string c_Border_Left_Style = "border-left-style";

        

        public const string c_Border_Color = "border-color";
        public const string c_Border_Width = "border-width";
        public const string c_Border_Style = "border-style";

        public const string c_BackGround_Color = "background-color";


        // 定义变量
        public System.Drawing.Color leftColor = DefaultColor;
        public int leftWidth = DefaultWidth;
        public System.Windows.Forms.ButtonBorderStyle leftStyle = DefaultStyle;
        public System.Drawing.Color topColor = DefaultColor;
        public int topWidth = DefaultWidth;
        public System.Windows.Forms.ButtonBorderStyle topStyle = DefaultStyle;
        public System.Drawing.Color rightColor = DefaultColor;
        public int rightWidth = DefaultWidth;
        public System.Windows.Forms.ButtonBorderStyle rightStyle = DefaultStyle;
        public System.Drawing.Color bottomColor = DefaultColor;
        public int bottomWidth = DefaultWidth;
        public System.Windows.Forms.ButtonBorderStyle bottomStyle = DefaultStyle;
        public System.Drawing.Color backColor = DefaultBackColor;
        public bool hasBackGround = false;

        /// <summary>
        /// 所有边框宽度
        /// </summary>
        public int BorderWidth
        {
            get { return leftWidth; }
            set
            {
                leftWidth = value;
                topWidth = value;
                rightWidth = value;
                bottomWidth = value;
            }
        }
        /// <summary>
        /// 所有边框颜色
        /// </summary>
        public System.Drawing.Color BorderColor
        {
            get { return leftColor; }
            set
            {
                leftColor = value;
                topColor = value;
                rightColor = value;
                bottomColor = value;
            }
        }

        /// <summary>
        /// 所有边框样式
        /// </summary>
        public System.Windows.Forms.ButtonBorderStyle BorderStyle
        {
            get { return leftStyle; }
            set
            {
                leftStyle = value;
                topStyle = value;
                rightStyle = value;
                bottomStyle = value;
            }
        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>复制品</returns>
        public ZYTextBorder Clone()
        {
            ZYTextBorder b = new ZYTextBorder();
            b.CopyFrom(this);
            return b;
        }

        /// <summary>
        /// 从其他的边框样式对象拷贝数据
        /// </summary>
        /// <param name="b">数据来源的边框样式对象</param>
        public void CopyFrom(ZYTextBorder b)
        {
            if (b != null)
            {
                leftColor = b.leftColor;
                leftStyle = b.leftStyle;
                leftWidth = b.leftWidth;

                topColor = b.topColor;
                topStyle = b.topStyle;
                topWidth = b.topWidth;

                rightColor = b.rightColor;
                rightStyle = b.rightStyle;
                rightWidth = b.rightWidth;

                bottomColor = b.bottomColor;
                bottomStyle = b.bottomStyle;
                bottomWidth = b.bottomWidth;
            }
        }

        /// <summary>
        /// 比较对象数据是否一致
        /// </summary>
        /// <param name="b">另一个ZYTextBorder 对象</param>
        /// <returns>两者设置是否一样</returns>
        public bool EqualBorder(ZYTextBorder b)
        {
            //ZYTextBorder b = obj as ZYTextBorder ;
            if (this == b)
                return true;
            if (b != null)
            {
                return (
                    // width
                        leftWidth == b.leftWidth
                    && topWidth == b.topWidth
                    && rightWidth == b.rightWidth
                    && bottomWidth == b.bottomWidth
                    // style
                    && leftStyle.Equals(b.leftStyle)
                    && topStyle.Equals(b.topStyle)
                    && rightStyle.Equals(b.rightStyle)
                    && bottomStyle.Equals(b.bottomStyle)
                    // color
                    && leftColor.Equals(b.leftColor)
                    && topColor.Equals(b.topColor)
                    && rightColor.Equals(b.rightColor)
                    && bottomColor.Equals(b.bottomColor)
                    && hasBackGround == b.hasBackGround
                    && backColor == b.backColor
                     );
            }
            else
                return false;
        }

        #region "边框对象和XML节点交换数据使用的函数群*************************"

        /// <summary>
        /// 判断一个XML节点是否存在边框设置的属性
        /// </summary>
        /// <param name="myElement">XML节点</param>
        /// <returns>判断结果</returns>
        public static bool TestXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null
                // all
                || myElement.HasAttribute(c_Border_Color)
                || myElement.HasAttribute(c_Border_Width)
                || myElement.HasAttribute(c_Border_Style)
                // left
                || myElement.HasAttribute(c_Border_Left_Color)
                || myElement.HasAttribute(c_Border_Left_Width)
                || myElement.HasAttribute(c_Border_Left_Style)
                // top
                || myElement.HasAttribute(c_Border_Top_Color)
                || myElement.HasAttribute(c_Border_Top_Width)
                || myElement.HasAttribute(c_Border_Top_Style)
                // right
                || myElement.HasAttribute(c_Border_Right_Color)
                || myElement.HasAttribute(c_Border_Right_Width)
                || myElement.HasAttribute(c_Border_Right_Style)
                // bottom
                || myElement.HasAttribute(c_Border_Bottom_Color)
                || myElement.HasAttribute(c_Border_Bottom_Width)
                || myElement.HasAttribute(c_Border_Bottom_Style)
                || myElement.HasAttribute(c_BackGround_Color))
                return true;
            return false;
        }

        /// <summary>
        /// 从XML节点加载对象数据,在加载对象数据前将重置所有的数据
        /// </summary>
        /// <param name="myElement">XML节点</param>
        /// <returns>加载是否成功</returns>
        public bool FromXML(System.Xml.XmlElement myElement)
        {
            Clear();
            return this.FromXMLWithoutClear(myElement);
        }

        /// <summary>
        /// 向XML节点加载对象数据,该函数不会重置所有的数据
        /// </summary>
        /// <param name="myElement">XML节点对象</param>
        /// <returns>加载是否成功</returns>
        public bool FromXMLWithoutClear(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                // all
                if (myElement.HasAttribute(c_Border_Color))
                    this.BorderColor = StringCommon.ColorFromHtml(myElement.GetAttribute(c_Border_Color), DefaultColor);
                if (myElement.HasAttribute(c_Border_Width))
                    this.BorderWidth = StringCommon.ToInt32Value(myElement.GetAttribute(c_Border_Width), DefaultWidth);
                if (myElement.HasAttribute(c_Border_Style))
                    this.BorderStyle = ToBorderStyle(myElement.GetAttribute(c_Border_Style));

                // left
                if (myElement.HasAttribute(c_Border_Left_Color))
                    leftColor = StringCommon.ColorFromHtml(myElement.GetAttribute(c_Border_Left_Color), DefaultColor);
                if (myElement.HasAttribute(c_Border_Left_Width))
                    leftWidth = StringCommon.ToInt32Value(myElement.GetAttribute(c_Border_Left_Width), DefaultWidth);
                if (myElement.HasAttribute(c_Border_Left_Style))
                    leftStyle = ToBorderStyle(myElement.GetAttribute(c_Border_Left_Style));

                // top
                if (myElement.HasAttribute(c_Border_Top_Color))
                    topColor = StringCommon.ColorFromHtml(myElement.GetAttribute(c_Border_Top_Color), DefaultColor);
                if (myElement.HasAttribute(c_Border_Top_Width))
                    topWidth = StringCommon.ToInt32Value(myElement.GetAttribute(c_Border_Top_Width), DefaultWidth);
                if (myElement.HasAttribute(c_Border_Top_Style))
                    topStyle = ToBorderStyle(myElement.GetAttribute(c_Border_Top_Style));

                // right
                if (myElement.HasAttribute(c_Border_Right_Color))
                    rightColor = StringCommon.ColorFromHtml(myElement.GetAttribute(c_Border_Right_Color), DefaultColor);
                if (myElement.HasAttribute(c_Border_Right_Width))
                    rightWidth = StringCommon.ToInt32Value(myElement.GetAttribute(c_Border_Right_Width), DefaultWidth);
                if (myElement.HasAttribute(c_Border_Right_Style))
                    rightStyle = ToBorderStyle(myElement.GetAttribute(c_Border_Right_Style));

                // bottom
                if (myElement.HasAttribute(c_Border_Bottom_Color))
                    bottomColor = StringCommon.ColorFromHtml(myElement.GetAttribute(c_Border_Bottom_Color), DefaultColor);
                if (myElement.HasAttribute(c_Border_Bottom_Width))
                    bottomWidth = StringCommon.ToInt32Value(myElement.GetAttribute(c_Border_Bottom_Width), DefaultWidth);
                if (myElement.HasAttribute(c_Border_Bottom_Style))
                    bottomStyle = ToBorderStyle(myElement.GetAttribute(c_Border_Bottom_Style));

                // 背景色
                hasBackGround = myElement.HasAttribute(c_BackGround_Color);
                if (hasBackGround)
                    backColor = StringCommon.ColorFromHtml(myElement.GetAttribute(c_BackGround_Color), DefaultBackColor);
                else
                    backColor = DefaultBackColor;
                return true;

            }
            return false;
        }

        /// <summary>
        /// 向XML节点保存对象数据
        /// </summary>
        /// <param name="myElement">XML节点对象</param>
        /// <returns>保存是否成功</returns>
        public bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                // color
                if (leftColor.Equals(topColor) && topColor.Equals(rightColor) && rightColor.Equals(bottomColor))
                {
                    if (leftColor.Equals(DefaultColor) == false)
                    {
                        myElement.SetAttribute(c_Border_Color, StringCommon.ColorToHtml(leftColor));
                    }
                }
                else
                {
                    if (!leftColor.Equals(DefaultColor))
                        myElement.SetAttribute(c_Border_Left_Color, StringCommon.ColorToHtml(leftColor));
                    if (!topColor.Equals(DefaultColor))
                        myElement.SetAttribute(c_Border_Top_Color, StringCommon.ColorToHtml(topColor));
                    if (!rightColor.Equals(DefaultColor))
                        myElement.SetAttribute(c_Border_Right_Color, StringCommon.ColorToHtml(rightColor));
                    if (!bottomColor.Equals(DefaultColor))
                        myElement.SetAttribute(c_Border_Bottom_Color, StringCommon.ColorToHtml(bottomColor));
                }
                // width
                if (leftWidth == topWidth && topWidth == rightWidth && rightWidth == bottomWidth)
                {
                    if (leftWidth != DefaultWidth)
                        myElement.SetAttribute(c_Border_Width, leftWidth.ToString());
                }
                else
                {
                    if (leftWidth != DefaultWidth)
                        myElement.SetAttribute(c_Border_Left_Width, leftWidth.ToString());
                    if (topWidth != DefaultWidth)
                        myElement.SetAttribute(c_Border_Top_Width, topWidth.ToString());
                    if (rightWidth != DefaultWidth)
                        myElement.SetAttribute(c_Border_Right_Width, rightWidth.ToString());
                    if (bottomWidth != DefaultWidth)
                        myElement.SetAttribute(c_Border_Bottom_Width, bottomWidth.ToString());
                }
                // style
                if (leftStyle == topStyle && topStyle == rightStyle && rightStyle == bottomStyle)
                {
                    if (!leftStyle.Equals(DefaultStyle))
                        myElement.SetAttribute(c_Border_Style, leftStyle.ToString().ToLower());
                }
                else
                {
                    if (leftStyle != DefaultStyle)
                        myElement.SetAttribute(c_Border_Left_Style, leftStyle.ToString().ToLower());
                    if (topStyle != DefaultStyle)
                        myElement.SetAttribute(c_Border_Top_Style, topStyle.ToString().ToLower());
                    if (rightStyle != DefaultStyle)
                        myElement.SetAttribute(c_Border_Right_Style, rightStyle.ToString().ToLower());
                    if (bottomStyle != DefaultStyle)
                        myElement.SetAttribute(c_Border_Bottom_Style, bottomStyle.ToString().ToLower());
                }
                if (hasBackGround)
                    myElement.SetAttribute(c_BackGround_Color, StringCommon.ColorToHtml(backColor));

                return true;
            }
            return false;
        }

        /// <summary>
        /// 增量方式向XML节点,本函数只是向XML节点保存和另一个边框对象的不相同的参数设置
        /// 以减少保存的数据量
        /// </summary>
        /// <param name="myElement">XML节点</param>
        /// <param name="b">作为参照物的边框对象</param>
        /// <returns>保存是否成功</returns>
        public bool ToXMLEx(System.Xml.XmlElement myElement, ZYTextBorder b)
        {
            if (myElement != null && b != null && b != this)
            {
                // color
                if (leftColor.Equals(topColor) && topColor.Equals(rightColor) && rightColor.Equals(bottomColor))
                {
                    if (leftColor.Equals(DefaultColor) == false && leftColor.Equals(b.leftColor) == false)
                    {
                        myElement.SetAttribute(c_Border_Color, StringCommon.ColorToHtml(leftColor));
                    }
                }
                else
                {
                    if (!(leftColor.Equals(DefaultColor) || leftColor.Equals(b.leftColor)))
                        myElement.SetAttribute(c_Border_Left_Color, StringCommon.ColorToHtml(leftColor));
                    if (!(topColor.Equals(DefaultColor) || topColor.Equals(b.topColor)))
                        myElement.SetAttribute(c_Border_Top_Color, StringCommon.ColorToHtml(topColor));
                    if (!(rightColor.Equals(DefaultColor) || rightColor.Equals(b.rightColor)))
                        myElement.SetAttribute(c_Border_Right_Color, StringCommon.ColorToHtml(rightColor));
                    if (!(bottomColor.Equals(DefaultColor) || bottomColor.Equals(b.bottomColor)))
                        myElement.SetAttribute(c_Border_Bottom_Color, StringCommon.ColorToHtml(bottomColor));
                }
                // width
                if (leftWidth == topWidth && topWidth == rightWidth && rightWidth == bottomWidth)
                {
                    if (leftWidth != DefaultWidth && leftWidth != b.leftWidth)
                        myElement.SetAttribute(c_Border_Width, leftWidth.ToString());
                }
                else
                {
                    if (leftWidth != DefaultWidth && leftWidth != b.leftWidth)
                        myElement.SetAttribute(c_Border_Left_Width, leftWidth.ToString());
                    if (topWidth != DefaultWidth && topWidth != b.topWidth)
                        myElement.SetAttribute(c_Border_Top_Width, topWidth.ToString());
                    if (rightWidth != DefaultWidth && rightWidth != b.rightWidth)
                        myElement.SetAttribute(c_Border_Right_Width, rightWidth.ToString());
                    if (bottomWidth != DefaultWidth && bottomWidth != b.bottomWidth)
                        myElement.SetAttribute(c_Border_Bottom_Width, bottomWidth.ToString());
                }
                // style
                if (leftStyle == topStyle && topStyle == rightStyle && rightStyle == bottomStyle)
                {
                    if (!leftStyle.Equals(DefaultStyle) && !leftStyle.Equals(b.leftStyle))
                        myElement.SetAttribute(c_Border_Style, leftStyle.ToString().ToLower());
                }
                else
                {
                    if (leftStyle != DefaultStyle && leftStyle != b.leftStyle)
                        myElement.SetAttribute(c_Border_Left_Style, leftStyle.ToString().ToLower());
                    if (topStyle != DefaultStyle && topStyle != b.topStyle)
                        myElement.SetAttribute(c_Border_Top_Style, topStyle.ToString().ToLower());
                    if (rightStyle != DefaultStyle && rightStyle != b.rightStyle)
                        myElement.SetAttribute(c_Border_Right_Style, rightStyle.ToString().ToLower());
                    if (bottomStyle != DefaultStyle && bottomStyle != b.bottomStyle)
                        myElement.SetAttribute(c_Border_Bottom_Style, bottomStyle.ToString().ToLower());
                }
                if (hasBackGround == true && hasBackGround != b.hasBackGround && backColor != b.backColor)
                {
                    myElement.SetAttribute(c_BackGround_Color, StringCommon.ColorToHtml(backColor));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region "内部使用的数据格式转换函数群**********************************"
        /// <summary>
        /// 将字符串转换为边框类型变量
        /// </summary>
        /// <param name="strValue">字符串</param>
        /// <returns>边框类型</returns>
        private static System.Windows.Forms.ButtonBorderStyle ToBorderStyle(string strValue)
        {
            try
            {
                return (System.Windows.Forms.ButtonBorderStyle)System.Enum.Parse(DefaultStyle.GetType(), strValue, true);
            }
            catch
            {
                return DefaultStyle;
            }
        }
        //
        //		/// <summary>
        //		/// 将一个字符串转换为整数
        //		/// </summary>
        //		/// <param name="strData">字符串</param>
        //		/// <param name="DefaultValue">默认值</param>
        //		/// <returns>转换结果</returns>
        //		private static int ToInt32Value(string strData , int DefaultValue)
        //		{
        //			try
        //			{
        //				if(strData == null)
        //					return DefaultValue;
        //				else
        //					return Convert.ToInt32(strData);
        //			}
        //			catch
        //			{
        //				return DefaultValue;
        //			}
        //		}
        //
        //		
        //		/// <summary>
        //		/// 将 #xxxxxx 字符串转换为一个颜色值
        //		/// </summary>
        //		/// <param name="strText">#xxxxxx 格式的字符串</param>
        //		/// <param name="DefaultValue">若转换失败则使用的默认值</param> 
        //		/// <returns>转换结果</returns>
        //		private static System.Drawing.Color  ColorFromHtml(string strText, System.Drawing.Color  DefaultValue )
        //		{
        //			if(strText != null)
        //			{
        //				strText = strText.ToUpper().Trim();
        //				if(strText.StartsWith("#") && strText.Length <= 7 )
        //				{
        //					int iValue  = 0 ;
        //					int Index = 0;
        //					const string c_HexList		= "0123456789ABCDEF";
        //					for(int iCount = 1 ; iCount < strText.Length ; iCount ++ )
        //					{
        //						Index = c_HexList.IndexOf(strText[iCount]);
        //						if( Index >= 0 )
        //							iValue = iValue * 16 + Index   ;
        //						else
        //							return DefaultValue ;
        //					}
        //					System.Drawing.Color myColor = System.Drawing.Color.FromArgb(iValue);
        //					return System.Drawing.Color.FromArgb(255,myColor);
        //				}
        //			}
        //			return DefaultValue;
        //		}
        //
        //		/// <summary>
        //		/// 将一个颜色值转换为 #XXXXXX 格式的字符串
        //		/// </summary>
        //		/// <param name="intValue">整数值</param>
        //		/// <returns>转换后的字符串</returns>
        //		private  static string ColorToHtml(System.Drawing.Color  myColor)
        //		{
        //			return "#" + Convert.ToInt32(myColor.ToArgb() & 0xffffff).ToString("X6");
        //		}

        #endregion


        /// <summary>
        /// 设置所有参数为默认值
        /// </summary>
        public void Clear()
        {
            leftWidth = DefaultWidth;
            leftStyle = DefaultStyle;
            topColor = DefaultColor;
            topWidth = DefaultWidth;
            topStyle = DefaultStyle;
            rightColor = DefaultColor;
            rightWidth = DefaultWidth;
            rightStyle = DefaultStyle;
            bottomColor = DefaultColor;
            bottomWidth = DefaultWidth;
            bottomStyle = DefaultStyle;
            hasBackGround = false;
            backColor = DefaultBackColor;
        }

        public void Draw(DocumentView view, System.Drawing.Rectangle myRect)
        {
            view.DrawBorder
                (myRect,
                leftColor,
                leftWidth,
                leftStyle,
                topColor,
                topWidth,
                topStyle,
                rightColor,
                rightWidth,
                rightStyle,
                bottomColor,
                bottomWidth,
                bottomStyle);
        }

        /// <summary>
        /// 绘制边框底板
        /// </summary>
        /// <param name="myGraph">图象绘制对象</param>
        /// <param name="myRect">边框对象</param>
        /// <returns>是否进行了实际上的绘制操作</returns>
        public bool DrawBackGround(System.Drawing.Graphics myGraph, System.Drawing.Rectangle myRect)
        {
            if (myGraph != null && hasBackGround && myRect.IsEmpty == false)
            {
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(backColor))
                {
                    myGraph.FillRectangle(myBrush, myRect);
                }
                return true;
            }
            return false;
        }

        public void Draw(DocumentView view, int left, int top, int width, int height)
        {
            Draw(view, new System.Drawing.Rectangle(left, top, width, height));
        }

        public ZYTextBorder()
        {
            this.Clear();
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
}
