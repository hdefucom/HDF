using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// add by myc 2014-07-17 09:22
    /// 当前字体属性，这个跟随鼠标点击位置处的文本字符的字体属性设置，用于插入新的文本字符时的字体属性控制。
    /// </summary>
    public class CurrentFontProperty
    {
        #region 字体基本属性
        private string fontName = "宋体";
        /// <summary>
        /// 字体名称。
        /// </summary>
        public string FontName
        {
            get { return fontName; }
            set { fontName = value; }
        }

        private float fontSize = 10.5f;
        /// <summary>
        /// 字体大小。
        /// </summary>
        public float FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        private bool fontBold = false;
        /// <summary>
        /// 字体加粗。
        /// </summary>
        public bool FontBold
        {
            get { return fontBold; }
            set { fontBold = value; }
        }

        private bool fontItalic = false;
        /// <summary>
        /// 字体斜体。
        /// </summary>
        public bool FontItalic
        {
            get { return fontItalic; }
            set { fontItalic = value; }
        }

        private bool fontUnderLine = false;
        /// <summary>
        /// 字体加下划线。
        /// </summary>
        public bool FontUnderLine
        {
            get { return fontUnderLine; }
            set { fontUnderLine = value; }
        } 
        #endregion

        private Font myFont = null;
        /// <summary>
        /// 当前字体。
        /// </summary>
        public Font Font
        {
            get
            {
                if (myFont == null)
                {
                    FontStyle fontStyle = FontStyle.Regular;
                    if (fontBold)
                        fontStyle = fontStyle | FontStyle.Bold;
                    if (fontItalic)
                        fontStyle = fontStyle | FontStyle.Italic;
                    if (fontUnderLine)
                        fontStyle = fontStyle | FontStyle.Underline;
                    myFont = new Font(FontName, FontSize, fontStyle);
                }
                return myFont;
            }
            set
            {
                this.FontName = value.Name;
                this.FontSize = value.Size;
                this.FontBold = value.Bold;
                this.FontItalic = value.Italic;
                this.FontUnderLine = value.Underline;
            }
        }

        private Color foreColor = Color.Black;
        /// <summary>
        /// 文本颜色。
        /// </summary>
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }
    }
}
