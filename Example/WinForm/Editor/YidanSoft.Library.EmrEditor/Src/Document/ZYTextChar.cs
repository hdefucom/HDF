using System;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;
namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// ���Ӳ����ı��ĵ���һ���ַ��Ķ���
    /// </summary>
    public class ZYTextChar : ZYTextElement
    {
        [DisplayName("�Զ��������С")]
        public float myfontsize
        {
            get { return this.FontSize; }
            set { this.FontSize = value; }
        }

        private char myChar = ' ';	// ������ַ�����
        private System.Drawing.Font myFont = null;	// 

        internal void ClearFont()
        {
            myFont = null;
        }

        /// <summary>
        /// �����ַ�ʹ�õ�������󣬸ö����Ǵ��ĵ������е������б��л�õ�
        /// </summary>
        /// 
        [DisplayName("����"), Browsable(false), Description("�����������"), Category("��ʽ")]
        public System.Drawing.Font Font
        {
            get
            {
                if (myFont == null)
                    myFont = myOwnerDocument.View._CreateFont(this.FontName, this.FontSize, this.FontBold, this.FontItalic, this.FontUnderLine);
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

        /// <summary>
        /// ����д:����Ԫ�����ڵ��ĵ�����
        /// </summary>
        public override ZYTextDocument OwnerDocument
        {
            get
            {
                return base.OwnerDocument;
            }
            set
            {
                base.OwnerDocument = value;
                myFont = null;
            }
        }
        #region ================���������б�================
        /// <summary>
        /// ��������
        /// </summary>
        public string FontName
        {
            get { return myAttributes.GetString(ZYTextConst.c_FontName); }
            set
            {
                myAttributes.SetValue(ZYTextConst.c_FontName, value);
                myFont = null;
            }
        }

        /// <summary>
        /// �����С
        /// </summary>
        public float FontSize
        {
            get
            {
                return myAttributes.GetFloat(ZYTextConst.c_FontSize);
            }
            set
            {
                myAttributes.SetValue(ZYTextConst.c_FontSize, value);
                myFont = null;
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public bool FontBold
        {
            get { return myAttributes.GetBool(ZYTextConst.c_FontBold); }
            set { myAttributes.SetValue(ZYTextConst.c_FontBold, value); myFont = null; }
        }
        /// <summary>
        /// �»���
        /// </summary>
        public bool FontUnderLine
        {
            get { return myAttributes.GetBool(ZYTextConst.c_FontUnderLine); }
            set { myAttributes.SetValue(ZYTextConst.c_FontUnderLine, value); myFont = null; }
        }
        /// <summary>
        /// б��
        /// </summary>
        public bool FontItalic
        {
            get { return myAttributes.GetBool(ZYTextConst.c_FontItalic); }
            set { myAttributes.SetValue(ZYTextConst.c_FontItalic, value); myFont = null; }
        }

        /// <summary>
        /// ˫�»��� mfb
        /// </summary>
        public bool DoubleFontUnderLine
        {
            get { return myAttributes.GetBool(ZYTextConst.c_DoubleFontUnderLine); }
            set { myAttributes.SetValue(ZYTextConst.c_DoubleFontUnderLine, value); myFont = null; }
        }

        /// <summary>
        /// ɾ���� mfb
        /// </summary>
        public bool FontStrikeout
        {
            get { return myAttributes.GetBool(ZYTextConst.c_FontStrikeout); }
            set { myAttributes.SetValue(ZYTextConst.c_FontStrikeout, value); myFont = null; }
        }
        /// <summary>
        /// ˫ɾ���� mfb
        /// </summary>
        public bool DoubleFontStrikeout
        {
            get { return myAttributes.GetBool(ZYTextConst.c_DoubleFontStrikeout); }
            set { myAttributes.SetValue(ZYTextConst.c_DoubleFontStrikeout, value); myFont = null; }
        }
        /// <summary>
        /// ������ mfb
        /// </summary>
        public bool FontWavyLine
        {
            get { return myAttributes.GetBool(ZYTextConst.c_FontWavyLine); }
            set { myAttributes.SetValue(ZYTextConst.c_FontWavyLine, value); myFont = null; }
        }

        /// <summary>
        /// �ϱ�
        /// </summary>
        public bool Sup
        {
            get { return myAttributes.GetBool(ZYTextConst.c_Sup); }
            set { myAttributes.SetValue(ZYTextConst.c_Sup, value); myFont = null; }
        }
        /// <summary>
        /// �±�
        /// </summary>
        public bool Sub
        {
            get { return myAttributes.GetBool(ZYTextConst.c_Sub); }
            set { myAttributes.SetValue(ZYTextConst.c_Sub, value); myFont = null; }
        }

        private System.Drawing.Color intForeColor = System.Drawing.SystemColors.WindowText;
        private System.Drawing.Color intBackgroundColor = System.Drawing.SystemColors.Window;

        /// <summary>
        /// �ı���ɫ
        /// </summary>
        public System.Drawing.Color ForeColor
        {
            get
            {
                //if( myOwnerDocument.Info.Printing )
                //return intForeColor; //add by myc 2014-07-18 ע��ԭ�����ַ�ʽ����ͨ�����Լ��ϵ�SetValue����׼ȷ�趨��ɫ

                return myAttributes.GetColor(ZYTextConst.c_ForeColor); //add by myc 2014-07-18 ���ԭ��׼ȷ��ȡ������ɫֵ��Ҫ

                //if( myOwnerDocument.IsLock( this ))
                //    return ZYTextConst.LockedForeColor ;
                //else
                //    return intForeColor ;
            }
            set
            {
                myAttributes.SetValue(ZYTextConst.c_ForeColor, value);
                intForeColor = value;
            }
        }

        /// <summary>
        /// �ı��ı�����ɫ mfb
        /// </summary>
        public System.Drawing.Color BackgroundColor
        {
            get { return intBackgroundColor; }
            set
            {
                myAttributes.SetValue(ZYTextConst.c_Backgroundcolor, value);
                intBackgroundColor = value;
            }
        }

        /// <summary>
        /// Ȧ�� Add by wwj 2012-05-31
        /// </summary>
        public bool CircleFont
        {
            get { return myAttributes.GetBool(ZYTextConst.c_CircleFont); }
            set { myAttributes.SetValue(ZYTextConst.c_CircleFont, value); myFont = null; }
        }
        #endregion


        /// <summary>
        /// �ַ�����
        /// </summary>
        public char Char
        {
            get { return myChar; }
            set { myChar = value; }
        }

        /// <summary>
        /// ������:���ظö����XML����
        /// </summary>
        /// <returns></returns>
        public override string GetXMLName()
        {
            return ZYTextConst.c_Span;
        }
        /// <summary>
        /// ׷�Ӷ������ݵ�XML�ڵ�
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public bool AppendToXML(System.Xml.XmlElement myElement)
        {
            System.Xml.XmlText myText = myElement.OwnerDocument.CreateTextNode(myChar.ToString());
            myElement.AppendChild(myText);
            return true;
        }

        /// <summary>
        /// ������:��XML�ڵ�����ı���ʽ�͵�һ���ַ�����
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement == null) return false;
            string strValue = myElement.InnerText;
            if (strValue == null || strValue.Length == 0)
                strValue = " ";
            myChar = strValue[0];
            return base.FromXML(myElement);
        }

        public override void UpdateAttrubute()
        {
            intForeColor = myAttributes.GetColor(ZYTextConst.c_ForeColor);
            this.ClearFont();
            base.UpdateAttrubute();
        }


        /// <summary>
        /// ������:��XML�ڵ㱣���ı���ʽ��Ϣ���ַ�����
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement == null) return false;
            switch (myOwnerDocument.Info.SaveMode)
            {
                case 0: // ������������
                    System.Xml.XmlText myText = myElement.OwnerDocument.CreateTextNode(myChar.ToString());
                    myElement.AppendChild(myText);
                    //base.BaseToXML( myElement );
                    myAttributes.ToXML(myElement);
                    break;
                case 1: // ���洿�ı�����
                    System.Xml.XmlText myText2 = myElement.OwnerDocument.CreateTextNode(myChar.ToString());
                    myElement.AppendChild(myText2);
                    return true;
                //break;
                case 2: // ֻ����ṹ������
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override bool CanBeLineHead()
        {
            return (ZYTextConst.c_TailSob.IndexOf(myChar) < 0);
        }

        public override bool CanBeLineEnd()
        {
            return (ZYTextConst.c_BegSob.IndexOf(myChar) < 0);
        }

        /// <summary>
        /// �Ƿ��ʾһ�������ַ�
        /// </summary>
        /// <returns></returns>
        public bool IsSymbol()
        {
            return (ZYTextConst.c_TailSob.IndexOf(myChar) >= 0 || ZYTextConst.c_BegSob.IndexOf(myChar) >= 0);
        }

        //		public void RefreshTabWidth()
        //		{
        //			if( myChar == '\t')
        //				intWidth = myOwnerDocument.View.GetTabWidth( this.RealLeft );
        //		}

        private static System.Drawing.StringFormat myMeasureFormat = null;

        /// <summary>
        /// ����ˢ���壬����ڳ����������Ĺ��������������ָı佫��������� Add by wwj 2013-04-19
        /// </summary>
        private void RefreshMyFont()
        {
            if (myFont == null) return;

            bool bolSup = this.Sup;
            bool bolSub = this.Sub;

            if (myFont.FontFamily.Name != this.FontName
                || myFont.Bold != this.FontBold
                || myFont.Italic != this.FontItalic
                || myFont.Underline != this.FontUnderLine
                || ((bolSup || bolSub) && myFont.Size != (int)(this.FontSize * 0.6))
                || (!(bolSup || bolSub) && myFont.Size != (int)this.FontSize))
            {
                myFont = myOwnerDocument.View._CreateFont
                    (this.FontName,
                    (bolSub || bolSup ? (int)(this.FontSize * 0.6) : this.FontSize),//0.6
                    this.FontBold,
                    this.FontItalic,
                    this.FontUnderLine);
            }
        }

        public override bool RefreshSize()
        {
            try
            {

                if (myMeasureFormat == null)
                {
                    myMeasureFormat = new System.Drawing.StringFormat(System.Drawing.StringFormat.GenericTypographic);
                    myMeasureFormat.FormatFlags = System.Drawing.StringFormatFlags.FitBlackBox | System.Drawing.StringFormatFlags.MeasureTrailingSpaces;
                }

                bool bolSup = this.Sup;
                bool bolSub = this.Sub;

                //Ȧ�� Add by wwj 2012-05-31
                bool bolCircleFont = this.CircleFont;

                if (myFont == null)
                {
                    if (this.FontSize == 0)
                    {
                        this.FontSize = 10.5f; //add by myc 2014-08-19 ���emSize����ֵΪ0ʱ���쳣����
                    }

                    myFont = myOwnerDocument.View._CreateFont
                        (this.FontName,
                        (bolSub || bolSup ? (int)(this.FontSize * 0.6) : this.FontSize),//0.6
                        this.FontBold,
                        this.FontItalic,
                        this.FontUnderLine);
                }
                else
                {
                    //Add by wwj 2013-04-19
                    RefreshMyFont();
                }

                System.Drawing.SizeF CharSize = myOwnerDocument.View.Graph.MeasureString(myChar.ToString(), myFont, 10000, myMeasureFormat);//.MeasureChar(myChar,myFont);

                //Ȧ�� Add by wwj 2012-05-31 ����ʹ��ԲȦ���ַ�������������Ҫ��֤����ʶ�
                if (bolCircleFont)
                {
                    CharSize = myOwnerDocument.View.MeasureChar('Ժ', this.Font);
                    CharSize.Width += 4;
                }

                if (myChar == '\t')
                    intWidth = myOwnerDocument.View.GetTabWidth(this.RealLeft);
                else
                    intWidth = (int)CharSize.Width;
                intHeight = (int)Math.Ceiling(myFont.GetHeight(myOwnerDocument.View.Graph));// CharSize.Height ;// myFont.GetHeight();
                //this.Height =(int) CharSize.Height ;

                if (bolSub || bolSup)
                    this.Height = (int)(intHeight * 1.9);
                //this.Height = (int)(intHeight * 7/4);

               
            }
            catch (Exception  ex)
            {
                throw ex;
            }
            return true;     
        }

        public override bool RefreshView()
        {
            if (myOwnerDocument.isNeedDraw(this) == false)
                return true;
            if (System.Char.IsWhiteSpace(myChar))
                return true;
            int x = this.RealLeft;
            int y = this.RealTop;
            bool bolSub = this.Sub;
            bool bolSup = this.Sup;

            //Ȧ�� Add by wwj 2012-05-31
            bool bolCircleFont = this.CircleFont;

            if (myFont == null)
            {
                myFont = myOwnerDocument.View._CreateFont(this.FontName,
                    (bolSub || bolSup ? (int)(this.FontSize * 0.6) : this.FontSize),
                    this.FontBold, this.FontItalic, this.FontUnderLine);
            }

            if (this.IsNeedPrint())
            {
                if (bolSub || bolSup)
                //if (false)
                {
                    System.Drawing.SizeF CharSize = myOwnerDocument.View.MeasureChar(myChar, myFont);
                    myOwnerDocument.View.DrawChar(myChar, myFont, this.ForeColor, x, 
                        //bolSup ? y:this.OwnerLine.Bottom -this.Height*3/7);
                        //(bolSup ? y : y + this.Height - (int)CharSize.Height));//ԭ
                        (bolSup ? y : y + this.Height - (int)this.Height*10/19));
                }
                else
                {
                    //������Ķ�\����\��ӡ ״̬������ʾ[] {}
                    if (this.OwnerDocument.Info.DocumentModel == DocumentModel.Read || this.OwnerDocument.Info.DocumentModel == DocumentModel.Read || this.OwnerDocument.Info.Printing)
                    {
                        if (this.Char == '[' || this.Char == ']' || this.Char == '{' || this.Char == '}')
                            return false;
                    }

                    //����Ԫ�ص��Ƿ��ӡ��ʶ��ȷ���Ƿ��ӡ
                    if (this.Parent is ZYFixedText && !(this.Parent as ZYFixedText).Print && this.OwnerDocument.Info.Printing
                        //|| this.Parent is ZYButton && !(this.Parent as ZYButton).Print && this.OwnerDocument.Info.Printing
                        )
                    {
                        return true;
                    }

                    //Ȧ�� Add by wwj 2012-05-31
                    if (bolCircleFont)
                    {
                        System.Drawing.SizeF CharSize = myOwnerDocument.View.MeasureChar('Ժ', this.Font);
                        Font circleFont = myOwnerDocument.View._CreateFont(this.FontName, this.FontSize * 0.85f, this.FontBold, this.FontItalic, this.FontUnderLine);
                        myOwnerDocument.View.DrawCircleChar(myChar, circleFont, this.ForeColor, x, y, (int)CharSize.Width);
                    }
                    else
                    {
                        //myOwnerDocument.View.DrawChar(myChar, myFont, this.ForeColor, x, y);

                        var rect = myOwnerDocument.Pages[myOwnerDocument.PageIndex].Bounds;
                        if (!rect.Contains(this.Bounds) && rect.IntersectsWith(this.Bounds))
                        {
                            rect.Intersect(this.Bounds);
                            //�����¡����Ȼ����Ⱦ��̬ʵ���������������ֻ��ƻ���
                            var f = StringFormat.GenericTypographic.Clone() as StringFormat;
                            f.LineAlignment = rect.Top == this.Bounds.Top ? StringAlignment.Near : StringAlignment.Far;
                            myOwnerDocument.View.DrawChar(myChar, myFont, this.ForeColor, rect, f);
                        }
                        else
                            myOwnerDocument.View.DrawChar(myChar, myFont, this.ForeColor, x, y);
                    }
                }
            }
            return true;
        }

        public override string ToEMRString()
        {
            return myChar.ToString();
        }

        public override string ToString()
        {
            return "ZYTextChar:" + myChar.ToString();
        }

        public ZYTextChar()
        {
        }

        /// <summary>
        /// ����һ���ַ�Ԫ�ض���
        /// </summary>
        /// <param name="c">�ö���ʹ�õ��ַ�</param>
        /// <returns>�½����ַ�Ԫ�ض���</returns>
        public static ZYTextChar Create(char c)
        {
            ZYTextChar chr;
            if (c == '\t')
                chr = new ZYTextCharTab();
            else
                chr = new ZYTextChar();
            chr.Char = c;
            return chr;
        }

        public override bool HandleClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            //Debug.WriteLine("ZYTextChar ����:" + this.Char);
            return base.HandleClick(x, y, Button);
        }
    }// class ZYTextChar

    /// <summary>
    /// ��ʾ�Ʊ�����ַ�����
    /// </summary>
    public class ZYTextCharTab : ZYTextChar
    {
        public void RefreshTabWidth()
        {
            intWidth = myOwnerDocument.View.GetTabWidth(this.RealLeft);
        }
        public override string ToEMRString()
        {
            return "\t";
        }
        public override string ToString()
        {
            return "ZYTextCharTab";
        }
    }
}
