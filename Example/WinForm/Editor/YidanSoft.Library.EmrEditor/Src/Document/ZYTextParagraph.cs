using System;
using System.Collections;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Collections.Generic;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// ���������ʽ
    /// </summary>
    public enum ParagraphAlignConst
    {
        /// <summary>
        /// �����
        /// </summary>
        Left = 0,
        /// <summary>
        /// �Ҷ���
        /// </summary>
        Right = 1,
        /// <summary>
        /// ���ж���
        /// </summary>
        Center = 2,
        /// <summary>
        /// ���߶���
        /// </summary>
        Justify = 4,

        /// <summary>
        /// ��ɢ���� mfb
        /// </summary>
        Disperse = 5
    }

    /// <summary>
    /// ����ͷ��Ƕ��� 
    /// </summary>
    public class ZYTextParagraph : ZYTextContainer
    {

        private int firstLineIndent = 0; //�������� mfb
        private int leftIndent = 0;      //�������������� mfb
        private ZYTextEOF eof;

        public ZYTextParagraph()
        {
            eof = new ZYTextEOF();
            eof.Parent = this;
            myChildElements.Add(eof);
        }

        #region ��������

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
        /// �и߱���
        /// 2019.07.03-hdf  ��������и߹���
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
        /// �Ƿ������
        /// </summary>
        public bool LeftAlign
        {
            get { return this.Align == ParagraphAlignConst.Left; }
            set { this.Align = ParagraphAlignConst.Left; }
        }
        /// <summary>
        /// �Ƿ���ж���
        /// </summary>
        public bool CenterAlign
        {
            get { return this.Align == ParagraphAlignConst.Center; }
            set { this.Align = ParagraphAlignConst.Center; }
        }
        /// <summary>
        /// �Ƿ��Ҷ���
        /// </summary>
        public bool RightAlign
        {
            get { return this.Align == ParagraphAlignConst.Right; }
            set { this.Align = ParagraphAlignConst.Right; }
        }

        /// <summary>
        /// �Ƿ����߶���
        /// </summary>
        public bool JustifyAlign
        {
            get { return this.Align == ParagraphAlignConst.Justify; }
            set { this.Align = ParagraphAlignConst.Justify; }
        }

        /// <summary>
        /// �Ƿ��ɢ���� mfb
        /// </summary>
        public bool DisperseAlign
        {
            get { return this.Align == ParagraphAlignConst.Disperse; }
            set { this.Align = ParagraphAlignConst.Disperse; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int FirstLineIndent
        {
            get { return firstLineIndent; }
            set { firstLineIndent = value; }
        }
        /// <summary>
        /// ������
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
        /// ˢ�½���,���»��ƶ���
        /// </summary>
        /// <returns>�Ƿ������ˢ�²���</returns>
        public override bool RefreshView()
        {
            return base.RefreshView();
        }
        /// <summary>
        /// Ԫ�����·���
        /// </summary>
        /// <returns></returns>
        public override ArrayList RefreshLine()
        {
            return base.RefreshLine();
        }
        #endregion


        /// <summary>
        /// ȥ�������еİ�ť���͵�����
        /// edit by ywk �������Ժ��¼�еı�ǩԪ��������д��Ȼ����д����ʱ���ظ���д������Ŀ��BUG
        /// 2012��11��7��8:53:37  �ֿ����� ������������д��
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ToEmrString2()
        {
            if (myChildElements.Count == 0)
                return null;
            System.Collections.ArrayList myElements = this.GetVisibleElements();
            FixForKeyField(myElements);

            //edit by ywk 2012��11��7��9:02:47
            string Findkey = string.Empty;//���ڴ�ű�ǩ�ļ�ֵ
            string FindValue = string.Empty;//��ʱ�������ַ��� ��Ҫ�����ǩ����Ҫ������ı�ǩԪ��
            Dictionary<string, string> myDic = new Dictionary<string, string>();
            ArrayList myKeyArr = new ArrayList();//���ڱ���KEY
            ArrayList myValueArr = new ArrayList();//���ڱ���ֵ
            string ReturnStr = string.Empty;//���շ��ص��ַ���
            System.Text.StringBuilder myStr = new System.Text.StringBuilder(myChildElements.Count);
            foreach (ZYTextElement myElement in myElements)
            {
                if (myElement is ZYButton)
                    continue;
                if (myElement is ZYFixedText)//����Ǳ�ǩ�ͼ�������
                {
                    Findkey = myElement.ToEMRString();
                    myKeyArr.Add(Findkey);
                    myStr.Append("$" + myElement.ToEMRString());//��ǩǰ��������ַ���������
                }
                else
                {
                    myStr.Append(myElement.ToEMRString());
                }
            }
            ReturnStr = myStr.ToString();//���շ��ص��ַ���
            string[] strvalue = ReturnStr.Split('$');
            string tempvalue=string.Empty;//��ʱ����
            for (int k = 1; k < strvalue.Length; k++)
            {
                tempvalue = strvalue[k].ToString().Substring(strvalue[k].ToString().IndexOf(myKeyArr[k-1].ToString()) + myKeyArr[k-1].ToString().Length );
                //strvalue[k].Remove(0, myKeyArr[k].ToString().Trim());
                myValueArr.Add(tempvalue);
            }
         
            for (int j = 0; j < myKeyArr.Count; j++)
            {
                myDic.Add(myKeyArr[j].ToString(), myValueArr[j].ToString());//�ӵ��ֵ���
            }
            return myDic;
            //return ReturnStr;
        }
    }
}
