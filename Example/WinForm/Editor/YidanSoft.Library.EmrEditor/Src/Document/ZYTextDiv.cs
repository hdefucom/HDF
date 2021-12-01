using System;
using System.Collections;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Diagnostics;
using System.Drawing;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// mfb
    /// ���Ӳ����ı��ĵ����ı������.
    /// ��Ϊ�̳���<c>ZYTextContainer</c>,Ϊһ����������.
    /// <para>��Ҫ�����������б���(Title),�۵�����(bolExpended),ToolTip,��Χ�߿�(BoxRect)</para>
    /// </summary>
    public class ZYTextDiv : ZYTextContainer
    {
        //private string	strKey			= null;
        ///// <summary>
        ///// �Ƿ��۵�
        ///// </summary>
        //private bool bolExpended = true;

        
        //System.Drawing.Rectangle BoxRect = System.Drawing.Rectangle.Empty;
        //private string strToolTip = null;

        ///// <summary>
        ///// div�ı������
        ///// </summary>
        //private string strTitle = null;
        private ZYTextParagraph para;
        public ZYTextDiv()
        {
            para = new ZYTextParagraph();
            para.Parent = this;
            myChildElements.Add(para);

            #region mfb ���Ե�Ԫ��
            //TPTextTable table = new TPTextTable();
            //table.Parent = this;
            //table.Width = 2000;
            //table.Height = 500;


            //TPTextRow rows = new TPTextRow();
            //rows.Parent = table;

            //rows[0] = new TPTextCell();
            //rows[0].Parent = rows;
            //rows[1] = rows[0];
            //rows[2] = rows[0];
            //rows[3] = rows[0];


            //table[0] = rows;
            //table[1] = rows;
            //table[2] = rows;
            //table[3] = rows;
            //table[4] = rows;

            //myChildElements.Add(table);

            #endregion
        }

        /// <summary>
        /// Gets the owner div.
        /// </summary>
        /// <param name="myElement">My element.</param>
        /// <returns></returns>
        public static ZYTextDiv GetOwnerDiv( ZYTextElement myElement )
        {
            ZYTextDiv myDiv = null;
            while (myElement != null)
            {
                myDiv = myElement as ZYTextDiv;
                if (myDiv == null)
                    myElement = myElement.Parent;
                else
                    return myDiv;
            }
            return myDiv;
        }
        /// <summary>
        /// ���԰����ĵ�����
        /// </summary>
        public bool NoContent
        {
            get { return myAttributes.GetBool(ZYTextConst.c_NoContent); }
            set { myAttributes.SetValue(ZYTextConst.c_NoContent, value); }
        }
         
        //protected override System.Drawing.SizeF GetTitleSize()
        //{
        //    string strText = this.Title;
        //    if (this.HideTitle || StringCommon.isBlankString(strText))
        //        return new System.Drawing.SizeF(0, 0);
        //    else
        //    {
        //        using (System.Drawing.Font myFont = new System.Drawing.Font(this.FontName, this.FontSize + 2f, System.Drawing.FontStyle.Bold))
        //        {
        //            System.Drawing.SizeF mySize = myOwnerDocument.View.MeasureString(strText, myFont);
        //            mySize.Width += 8;
        //            if (this.TitleLine)
        //                mySize.Width = 0;

        //            return mySize;
        //        }
        //    }
        //}

        //protected System.Drawing.SizeF GetRealTitleSize()
        //{
        //    string strText = this.Title;
        //    if (this.HideTitle || StringCommon.isBlankString(strText))
        //        return new System.Drawing.SizeF(0, 0);
        //    else
        //    {
        //        //using(System.Drawing.Font myFont = new System.Drawing.Font("����_GB2312",14,System.Drawing.FontStyle.Bold))
        //        using (System.Drawing.Font myFont = new System.Drawing.Font(this.FontName, this.FontSize + 2f, System.Drawing.FontStyle.Bold))
        //        {
        //            System.Drawing.SizeF mySize = myOwnerDocument.View.MeasureString(strText, myFont);
        //            return mySize;
        //        }
        //    }
        //}
        ///// <summary>
        ///// ���ı����Ƿ�չ��
        ///// </summary>
        //public bool Expanded
        //{
        //    get { return bolExpended; }
        //    set
        //    {
        //        if (bolExpended != value)
        //        {
        //            bolExpended = value;
        //            if (bolExpended == false)
        //                strTitle = this.ToEMRString();
        //        }
        //    }
        //}

        //private void ResetBoxRect()
        //{
        //    BoxRect = myOwnerDocument.View.GetExpendHandleRect(this.RealLeft, this.RealTop, myOwnerDocument.DefaultRowHeight);
        //}

        #region override ���෽��������Ⱥ

        #region left, height, width
        public override int Left
        {
            get
            {
                return 0;//myOwnerDocument.ContainerIndent;
            }
            set
            {
                if (myParent == null)
                    intLeft = value;
                else
                    intLeft = 0;
                //base.Left = value;
            }
        }

        #region �޸Ĺ�

        public override int Height
        {
            get
            {
                //if (bolExpended)
                return base.Height;
                //else

                //return myOwnerDocument.DefaultRowHeight;
                //return (int) myLineHeight[0] ;
            }
        }

        public override System.Drawing.Rectangle GetContentBounds()
        {
            ResetBoxRect();
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(this.RealLeft, this.RealTop, base.intClientWidth, this.Height);
            int dx = rect.Left - BoxRect.Left;
            rect.X -= dx;
            rect.Width += dx;
            return rect;
        }

        /// <summary>
        /// Resets the box rect.
        /// </summary>
        private void ResetBoxRect()
        {
            BoxRect = myOwnerDocument.View.GetExpendHandleRect(this.RealLeft, this.RealTop, myOwnerDocument.DefaultRowHeight);
        }

        System.Drawing.Rectangle BoxRect = System.Drawing.Rectangle.Empty;

    #endregion

        public override int Width
        {
            get
            {
                //if( bolExpended )
                //	return base.Width ;
                //else
                if (myParent == null)
                    return myOwnerDocument.Pages.StandardWidth;// .View.Width ;// - this.Left - 5 ;
                else
                    return myParent.Width - this.Left;
            }
            set
            {
                base.Width = value;
            }
        }
        #endregion


        public override void AddElementToList(System.Collections.ArrayList myList, bool ResetFlag)
        {
            if (myList != null)
            {
                foreach ( ZYTextElement myElement in myChildElements )
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

        public override bool Locked
        {
            get
            {
                if (myOwnerDocument.Loading)
                    return false;
                //if( myOwnerDocument.Locked)
                //    return true;
                if (this.NoContent == true && myOwnerDocument.Info.DesignMode == false)
                    return true;
                return false;
            }
            set
            {
                base.Locked = value;
            }
        }

        /// <summary>
        /// ������,����XML����
        /// </summary>
        /// <returns></returns>
        public override string GetXMLName()
        {
            return ZYTextConst.c_Div;
        }

        public override bool OwnerWholeLine()
        {
            return true;
        }
        /// <summary>
        /// ��������Ĭ�Ͻ���ǿ�ƻ���
        /// </summary>
        /// <returns></returns>
        public override bool isNewLine()
        {
            return true;
        }
        /// <summary>
        /// �������Ƿ�ǿ�ƿ�ʼ�¶���
        /// </summary>
        /// <returns></returns>
        public override bool isNewParagraph()
        {
            return true;
        }

        public override bool isField()
        {
            return true;
        }

        public override bool isTextElement()
        {
            return false;
        }

        #region RefreshView, RefreshLine

        /// <summary>
        /// ˢ�½���,���»��ƶ���
        /// </summary>
        /// <returns>�Ƿ������ˢ�²���</returns>
        public override bool RefreshView()
        {
            //return 
                base.RefreshView();

                //�����ֱ༭����,��ɫ��,
                if (this.OwnerDocument.OwnerControl.ActiveEditArea != null)
                {
                    Debug.WriteLine("���༭���� ����� ");
                    Rectangle rectx = new Rectangle();
                    //rectx.Location = this.OwnerDocument.OwnerControl.ActiveEditArea.TopElement.Bounds.Location;
                    rectx.Location = new Point(0, this.OwnerDocument.OwnerControl.ActiveEditArea.Top);
                    rectx.Width = this.OwnerDocument.OwnerControl.Pages.StandardWidth + 40;
                    rectx.Height = this.OwnerDocument.OwnerControl.ActiveEditArea.End - this.OwnerDocument.OwnerControl.ActiveEditArea.Top;
                    rectx.Offset(-20, 0);

                    Pen p = new Pen(Brushes.Red);
                    p.Width = 1;

                    this.OwnerDocument.OwnerControl.EMRDoc.View.Graph.DrawRectangle(p, rectx);
                }

            return true;
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

        public override bool HandleClick(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            return base.HandleClick(x, y, Button);
        }

        public override bool HandleMouseDown(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
                return base.HandleMouseDown(x, y, Button);
        }

        public override bool HandleMouseMove(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            return base.HandleMouseMove(x, y, Button);
        }


        public override string ToEMRString()
        {
            //if (StringCommon.isBlankString(this.Title) == false)
            //    return this.Title + base.ToEMRString();
            //else
                return base.ToEMRString();
        }
        public override string ToString()
        {
            return "ZYTextDiv Name:" + myAttributes.GetString(ZYTextConst.c_Name)
                + " Childs:" + myChildElements.Count
                + " [" + this.RealLeft
                + "-:" + this.RealTop
                + " " + this.Width
                + "-" + this.Height;
        }

        #endregion




        #region add by myc 2014-07-24 ���ԭ�򣺹�궨λ��Ԫ�ز�����ء���>ҳü�����ĺ�ҳ������¼�ͳһ������Ҫ
        private ArrayList innerElements = new ArrayList();
        /// <summary>
        /// ҳü����Ŀɼ�Ԫ���б��洢�ڲ��������ı�����Ԫ�ء�
        /// </summary>
        public ArrayList InnerElements
        {
            get { return innerElements; }
            set { innerElements = value; }
        }

        private ArrayList innerLines = new ArrayList();
        /// <summary>
        /// ҳü������ı����б��洢�ڲ��������ı��ж���
        /// </summary>
        public ArrayList InnerLines
        {
            get { return innerLines; }
            set { innerLines = value; }
        }
        #endregion
    }
}