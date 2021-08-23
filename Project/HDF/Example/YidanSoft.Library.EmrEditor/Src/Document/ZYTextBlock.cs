using System;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Drawing;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// ��ʾһ��Ԫ�ؼ��ϵ���������
    /// 
    /// </summary>
    public class ZYTextBlock : ZYTextContainer
    {
        #region bwy :
        string name = "";

        private string _code = "";

        /// <summary>
        /// ����ԪID ԭ���õ�code  һֱ����
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; 
            }
        }



        //�Ȳ���WholeElement����ʹ������Ӹ���
        public ZYTextBlock()
        {
            //���Ҽ��˵�ѡ��
            //contextMenu.Items.Clear();
            //contextMenu.Items.Add("�༭����");
            
        }
        //public override bool WholeElement
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}

        /// <summary>
        /// �Ƿ��Ǳ�ѡ��
        /// </summary>
        public bool MustClick = false;

        /// <summary>
        /// �Ƿ�����ɾ��
        /// </summary>
        public bool CanDelete = true; 

        /// <summary>
        /// �Ƿ񱻵����ע��
        /// </summary>
        public bool Clicked = false;

        public new virtual string Name
        {
            get { return name; }
            set
            {
                name = value;
                //if (this.Text.Length == 0)
                //{
                //��������Text��set�¼�,ѡ��Ԫ����Ҫ��������Ϊ��ѡ�����ֵ�ʱ�򣬲�Ӧ������ʾԭ����ѡ�����ݡ�
                this.Text = value;
                //}
            }
        }

        public string text = "";
        public virtual string Text
        {
            get
            {
                //if (text.Length == 0)
                //{
                //    return this.Name;
                //}
                //else
                //{
                return text;
                //}
            }

            set
            {
                this.ChildElements.Clear();
                foreach (char myc in value)
                {
                    ZYTextChar c = new ZYTextChar();
                    c.Char = myc;
                    Attributes.CopyTo(c.Attributes);
                    c.UpdateAttrubute();

                    c.Parent = this;
                    c.OwnerDocument = this.OwnerDocument;
                    this.ChildElements.Add(c);


                }
                text = value;
            }
        }

        #endregion bwy :

        /// <summary>
        /// �Ƿ��ǹؼ�����
        /// </summary>
        public bool KeyField
        {
            get { return myAttributes.GetString(ZYTextConst.c_KeyField) != "0"; }
            set { myAttributes.SetValue(ZYTextConst.c_KeyField, (value ? "1" : "0")); }
        }

        /// <summary>
        /// �Ƿ���ʾͻ����ʾ����
        /// </summary>
        protected bool bolStandOutBack = false;
        //
        //		/// <summary>
        //		/// �Ƿ�����»���
        //		/// </summary>
        //		protected bool bolUnderLine = false;


        /// <summary>
        /// ��������������־Ϊ��������������־
        /// </summary>
        public override bool Locked
        {
            //get { return myParent.Locked; }
            //set { base.Locked = value; }
            get
            {
                if (OwnerDocument.Loading)
                {
                    return false;
                }
                return bolChildElementsLocked;
            }
            set { bolChildElementsLocked = value; }
        }
        /// <summary>
        /// block����Ϊ��
        /// </summary>
        public override bool Block
        {
            get { return true; }
        }

        private bool isFocus = false;
        /// <summary>
        /// ��Ԫ���Ƿ��ȡ����
        /// 2019.8.6-hdf
        /// </summary>
        public bool IsFocus
        {
            get { return isFocus; }
            set
            {
                if (isFocus == value) return;
                isFocus = value;
                if (this is ZYMacro || this is ZYFormatString || this is ZYReplace || this is ZYDiag || this is ZYSubject)
                {
                    Rectangle rect = Rectangle.Empty;
                    foreach (ZYTextElement ele in ChildElements)
                    {
                        rect = System.Drawing.Rectangle.Union(rect, ele.Bounds);
                    }
                    this.OwnerDocument.OwnerControl.AddInvalidateRect(rect);
                    this.OwnerDocument.OwnerControl.UpdateInvalidateRect();
                }
                //Ϊʲô�������淽������Ϊ���淽��ͨ��ZYTextBlock����� GetContentBounds()������ȡ����Ҫˢ�¾���ʼ��Ϊ��
                //this.OwnerDocument.RefreshElement(this);
            }
        }

        /// <summary>
        /// �����أ������ǿ�Ʒ���
        /// </summary>
        /// <returns></returns>
        public override bool isNewLine()
        {
            return false;
        }
        /// <summary>
        /// �����أ������ǿ�Ʒֶ���
        /// </summary>
        /// <returns></returns>
        public override bool isNewParagraph()
        {
            return false;
        }
        /// <summary>
        /// �����أ������ռһ��
        /// </summary>
        /// <returns></returns>
        public override bool OwnerWholeLine()
        {
            return false;
        }
        /// <summary>
        /// ������:ˢ����ͼ״̬,�ж��Ƿ���Ҫ���Ʊ���
        /// </summary>
        /// <remarks>���ı����ж��Ƿ���Ʊ���������Ϊ
        /// 1.�ĵ������ڴ�ӡģʽ
        /// 2.û��ѡ�е�����
        /// 3.�ĵ��ĵ�ǰ���������Ԫ��Ϊ���ı���������ı�����</remarks>
        public override void ResetViewState()
        {
            bolStandOutBack = false;
            if (myOwnerDocument.Content.SelectLength != 0)
                return;
            if (myOwnerDocument.Content.CurrentElement == this
                || myChildElements.Contains(myOwnerDocument.Content.CurrentElement)
                || myOwnerDocument.CurrentHoverElement == this)
                bolStandOutBack = true;
        }//void ResetViewState()

        /// <summary>
        /// �����أ���ð����������С����
        /// </summary>
        /// <returns></returns>
        public override System.Drawing.Rectangle GetContentBounds()
        {
            System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;
            foreach (ZYTextElement myElement in myChildElements)
            {
                if (rect.IsEmpty)
                    rect = Bounds;
                else
                    rect = System.Drawing.Rectangle.Union(rect, myElement.Bounds);
            }
            return System.Drawing.Rectangle.Union(rect, this.Bounds);
        }


        /// <summary>
        /// �����������е�Ԫ����ӵ��б������
        /// </summary>
        /// <param name="myList">�б����</param>
        /// <param name="ResetFlag">�Ƿ�����Ԫ�ص�״̬</param>
        //public override void AddElementToList(System.Collections.ArrayList myList, bool ResetFlag)
        //{
        //    if (ResetFlag)
        //    {
        //        this.Visible = false;
        //        this.Index = -1;
        //    }
        //    if (myOwnerDocument.isVisible(this))
        //    {
        //        this.Visible = true;
        //        //				if( this.WholeElement == false)
        //        myList.Add(this);
        //        base.AddElementToList(myList, ResetFlag);
        //    }
        //}
        /// <summary>
        /// ������:�����������ı����¼�,���»��ƶ���
        /// </summary>
        public override void HandleEnter()
        {
            RefreshForSelect();
        }
        /// <summary>
        /// ������:��������뿪�ı����¼�,���»��ƶ���
        /// </summary>
        public override void HandleLeave()
        {
            RefreshForSelect();
        }

        private void RefreshForSelect()
        {
            bool bolBack = this.bolStandOutBack;
            this.ResetViewState();
            if (bolBack != this.bolStandOutBack)
            {
                myOwnerDocument.RefreshElement(this);
            }
        }

        public override bool isTextElement()
        {
            return true;
        }
        StringFormat strFormat = StringFormat.GenericTypographic;
        Pen pen = new Pen(Color.Black);
        public override void DrawBackGround(ZYTextElement myElement)
        {
            if (myElement.Parent is ZYFixedText && this.OwnerDocument.Info.DocumentModel == DocumentModel.Edit)
            {
                return;
            }

            Rectangle rect = myElement.Bounds;

            if (myElement.Parent is ZYTextBlock)
            {
                if (myElement.Parent.LastElement == myElement)
                    rect.Width -= 10;
            }


            //��ӡ״̬�����Ʊ���������״̬���Ʊ����������ܱ�����͸����
            if (this.OwnerDocument.Info.Printing || this.OwnerDocument.OwnerControl.bolLockingUI)
            {

            }
            else
            {
                switch (ZYEditorControl.ElementStyle)
                {
                    case "�»���":
                        pen.Color = ZYEditorControl.ElementBackColor;

                        pen.Width = 1;//YidanSoft.Library.EmrEditor.Src.Gui.GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel,GraphicsUnit.Document );
                        this.OwnerDocument.View.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);

                        if (myElement.Parent is ZYTextBlock)
                        {
                            if (myElement.Parent.LastElement == myElement)
                            {
                                this.OwnerDocument.View.DrawLine(pen, rect.Right, rect.Bottom - 5, rect.Right, rect.Bottom + 5);
                            }

                        }

                        break;
                    case "����ɫ":
                        if ((this is ZYMacro || this is ZYFormatString || this is ZYReplace || this is ZYDiag || this is ZYSubject) && this.IsFocus)
                        {
                            this.OwnerDocument.View.FillRectangle(Color.FromArgb(200, 220, 230), rect);
                        }
                        else
                        {
                            this.OwnerDocument.View.FillRectangle(ZYEditorControl.ElementBackColor, rect);
                        }
                        break;
                }
                //base.DrawBackGround(myElement);
            }


            //��ʹ��ֻ��״̬����������ڼ��������У���ͬ�༭״̬
            if (this.OwnerDocument.OwnerControl.ActiveEditArea != null)
            {
                if (this.OwnerDocument.OwnerControl.ActiveEditArea.Top <= myElement.RealTop && myElement.RealTop + this.Height <= this.OwnerDocument.OwnerControl.ActiveEditArea.End)
                {
                    switch (ZYEditorControl.ElementStyle)
                    {
                        case "�»���":
                            pen.Color = ZYEditorControl.ElementBackColor;
                            pen.Width = 2;
                            this.OwnerDocument.View.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                            break;
                        case "����ɫ":
                            this.OwnerDocument.View.FillRectangle(ZYEditorControl.ElementBackColor, rect);
                            break;
                    }
                }
            }
        }

        public override bool HandleClick(int x, int y, MouseButtons Button)
        {
            //foreach (ZYTextElement ele in this.ChildElements)
            //{
            //    if (ele.Bounds.Contains(x, y))
            //    {
            //        if (this is xxxx)
            //        {

            //        }
            //    }
            //}
            return base.HandleClick(x, y, Button);
        }

        

        //˫����������
        public override bool HandleDblClick(int x, int y, MouseButtons Button)
        {
            this.Clicked = true;

            //��ǰ�ַ��������ж��Ƿ���[]{}��
            ZYTextElement curChar = this.OwnerDocument.GetElementByPos(x, y);
            //Debug.WriteLine("block handledbclick ��ǰԪ�� " + curChar);

            //ѡ����ַ���
            StringBuilder str = new StringBuilder();
            this.GetFinalText(str);
            int m = this.ChildElements.IndexOf(curChar);

            int tmpindex = -1;

            //������[]���������
            List<int> start = new List<int>();
            List<int> end = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '[')
                {
                    start.Add(i);
                }
                if (str[i] == ']')
                {
                    end.Add(i);
                }
            }

            //������{}���������
            List<int> startm = new List<int>();
            List<int> endm = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{')
                {
                    startm.Add(i);
                }
                if (str[i] == '}')
                {
                    endm.Add(i);
                }
            }

            foreach (ZYTextElement ele in this.ChildElements)
            {
                if (ele.Bounds.Contains(x, y))
                {
                    this.Clicked = true;

                    if (this is ZYSelectableElement)
                    {
                        //�����ǰ����ѡ��ģ���е�һ�������滻ģ��
                        //�滻��ģ��
                        //����ԭ��ѡ��������չ������[xxx]ת����������ģ��Ԫ��
                        ArrayList al = new ArrayList();

                        /*2019.11.1-hdf��ѡ���ѡ���д����ſɵ��������
                         * ���������Ԫ���Ұ벿��curChar��������ȡ���ǹ���ұߵ�Ԫ�أ�
                         * �����ϱ�ѭ���������ߵ�Ԫ�أ����λ���ڹ�����Ԫ�ر߿��ڵ����ֲ���curChar����
                         * ���Ե���˫�������ŵ����������������������ֵ���벿�֡�
                         * 
                         * �����ɸѡ��������ѡ��Ԫ���ǿ�Ԫ�ص���Ԫ���Ҳ��ǵ�һ����
                         * ���ж�ѭ�����ַ��Ƿ����curChar��ǰһ��Ԫ�أ����ڵĻ�Ҳ����
                         */
                        ZYTextElement curCharUp = new ZYTextElement();
                        if (m >= 1) curCharUp = this.ChildElements[m - 1] as ZYTextElement;

                        if (ele == curChar || ele == curCharUp)
                        {
                            #region bwy //ѭ��[]ƥ�����
                            for (int i = 0; i < start.Count; i++)
                            {
                                if (start[i] < m && m < end[i])
                                {
                                    //������Ҫչ��ģ��ľ��� 
                                    if (MessageBox.Show("ȷ��Ҫ��ѡ��չ��Ϊģ����", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        this.OwnerDocument.BeginUpdate();
                                        this.OwnerDocument.BeginContentChangeLog();

                                        tmpindex = i;
                                        //չ��
                                        this.OwnerDocument._Delete();
                                        string f = "[]";
                                        bool isintmp = false;
                                        string tmpname = "";
                                        foreach (char c in str.ToString())
                                        {
                                            if (f.IndexOf(c) == 0)
                                            {
                                                isintmp = true;
                                                tmpname = "";
                                                continue;
                                            }
                                            if (f.IndexOf(c) == 1)
                                            {
                                                isintmp = false;
                                                //������Ϊtmpname��ģ��
                                                ZYTemplate tmp = new ZYTemplate();
                                                tmp.Name = tmpname;
                                                tmp.Parent = this.Parent;
                                                tmp.OwnerDocument = this.OwnerDocument;
                                                this.OwnerDocument._InsertBlock(tmp);

                                                al.Add(tmp);

                                                continue;
                                            }
                                            if (isintmp)
                                            {
                                                tmpname += c;
                                            }
                                            else
                                            {
                                                this.OwnerDocument.Content.InsertString(c.ToString());
                                            }
                                        }
                                        ZYTemplate tmp2 = al[tmpindex] as ZYTemplate;
                                        this.OwnerDocument.Content.CurrentElement = tmp2.FirstElement;
                                        tmp2.HandleDblClick(tmp2.FirstElement.RealLeft, tmp2.FirstElement.RealTop, Button);

                                        this.OwnerDocument.Content.SelectLength = 0;
                                        this.OwnerDocument.EndContentChangeLog();
                                        this.OwnerDocument.EndUpdate();

                                        Debug.WriteLine("Ӧ��չ��ģ�� " + (al[tmpindex] as ZYTemplate).Name);
                                        return true;
                                    }
                                }
                            }
                            #endregion bwy

                            #region bwy ѭ��{}ƥ���ÿһ��
                            for (int j = 0; j < startm.Count; j++)
                            {
                                //�����ǰԪ����ĳ����ʾ�м�
                                if (startm[j] < m && m < endm[j])
                                {
                                    //����¼����ʾ
                                    string tmpname = str.ToString().Substring(startm[j] + 1, endm[j] - startm[j] - 1);
                                    //������Ϊtmpname��¼����ʾ
                                    ZYPromptText p = new ZYPromptText();
                                    p.Name = tmpname;
                                    p.Parent = this.Parent;
                                    p.OwnerDocument = this.OwnerDocument;

                                    FormatFrm HelpWinx = new FormatFrm(p, this as ZYSelectableElement, startm[j], endm[j]);
                                    HelpWinx.Show();
                                    return true;
                                }
                            }
                            #endregion bwy



                        }

                        ImplementFrm HelpWin = new ImplementFrm((ZYSelectableElement)this);
                        HelpWin.Show();
                        //Debug.WriteLine("��ʾ��������OK");
                        return true;
                    }
                    if (this is ZYFormatDatetime || this is ZYFormatNumber || this is ZYFormatString || this is ZYPromptText)
                    {
                        FormatFrm HelpWin = new FormatFrm(this);
                        HelpWin.Show();
                        return true;
                    }

                    if (this is ZYTemplate)
                    {
                        this.OwnerDocument.ReplaceTemplate(this.Type, this.Name);
                        return true;
                    }

                    if (this is ZYReplace)
                    {
                        TextBoxFrm TextWin = new TextBoxFrm(this);
                        TextWin.ShowDialog();
                        return true;
                    }
                    if (this is ZYLookupEditor)
                    {
                        LookupEditorForm TextWin = new LookupEditorForm(this);
                        if (TextWin.NormalWordBook==null||TextWin.NormalWordBook == "")
                            return false;
                        TextWin.ShowDialog();
                        return true;
                    }
                    if (this is ZYDataElementLookupEditor)
                    {
                        //MessageBox.Show("��δʵ������Ԫ�ֵ书��");

                        DataElementLookupEditorForm TextWin = new DataElementLookupEditorForm(this);
                        if (TextWin.ValuesRange == null || TextWin.ValuesRange == "")
                            return false;
                        TextWin.ShowDialog();

                        return true;
                    }
                    if (this is ZYDiag)
                    {
                        if (OwnerDocument.Info.DocumentModel != DocumentModel.Edit) { MessageBox.Show("ֻ��������¼��ʱ�༭���"); return true; }

                        DiagForm diagform = new DiagForm(this as ZYDiag);
                        diagform.ShowDialog();
                        return true;
                    }

                    //if (this is ZYSubject)
                    //{
                    //    if (OwnerDocument.Info.DocumentModel != DocumentModel.Edit) { MessageBox.Show("ֻ��������¼��ʱ�༭���"); return true; }
                    //    if (this.Name == "����")
                    //    {
                    //        SubjectForm subjectForm = new SubjectForm((ZYSubject)this);
                    //        if (subjectForm.LoadZZ())
                    //        {
                    //            subjectForm.Show();
                    //            subjectForm.SetFocus();
                    //        }
                    //    }
                    //    return true;
                    //}
                }
            }

            return base.HandleDblClick(x, y, Button);

        }

        public override bool HandleMouseDown(int x, int y, System.Windows.Forms.MouseButtons Button)
        {
            //MessageBox.Show("HandleMouseDown");
            if (Button == MouseButtons.Right)
            {
                contextMenu.Show(Control.MousePosition);
            }
            return base.HandleMouseDown(x, y, Button);
        }

        //public override void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    switch (e.ClickedItem.Text)
        //    {
        //        case "�༭����":
        //            this.EditContent();
        //            this.OwnerDocument.OwnerControl.Refresh();//add by bwy
        //            break;
        //        default:
        //            break;
        //    }
        //    base.contextMenu_ItemClicked(sender, e);
        //}

        //public bool EditContent()
        //{
        //    if (this.Type == ElementType.Replace)
        //    {
        //        using (TextBoxFrm dlg = new TextBoxFrm())
        //        {
        //            dlg.ShowInTaskbar = false;
        //            dlg.MinimizeBox = false;

        //            //dlg.textBox1.Text = this.Text;
        //            dlg.richTextBox1.Text = this.Text;

        //            DialogResult r = dlg.ShowDialog();

        //            if (r == DialogResult.OK)
        //            {

        //                //��������
        //                //this.Text = dlg.textBox1.Text;
        //                this.Text = dlg.richTextBox1.Text;

        //                this.OwnerDocument.RefreshSize();
        //                this.OwnerDocument.ContentChanged();
        //                this.OwnerDocument.OwnerControl.Refresh();
        //                this.OwnerDocument.UpdateCaret();
        //                return true;
        //            }

        //        }
        //    }

        //    return false;
        //}

        public override bool ToXML(XmlElement myElement)
        {
            myElement.SetAttribute("mustclick", this.MustClick.ToString());
            myElement.SetAttribute("code", this.Code);
            myElement.SetAttribute("candelete", this.CanDelete.ToString());

            //2019.8.14-hdf����Ԫ�ء���ʽ���ַ�����Ӳ��뻻�з����ܣ���س���
            //����������Ԫ�ز�����text�����ı�������ʹ��ChildElement�����ַ�����Ԫ��
            //����������Ԫ�ض��Ǽ̳�ZyTextBlock������ֱ���ڸ����ToXML��FromXML�������޸��߼�
            if (this is ZYMacro || this is ZYReplace || this is ZYFormatString || this is ZYDiag || this is ZYSubject)
            {
                System.Xml.XmlElement NewElement = null;
                ZYTextChar LastChar = null;
                foreach (ZYTextElement ele in ChildElements)
                {
                    if (ele is ZYTextChar)
                    {
                        if (LastChar != null && LastChar.Attributes.EqualsValue(ele.Attributes))
                        {
                            (ele as ZYTextChar).AppendToXML(NewElement);
                        }
                        else
                        {
                            NewElement = myElement.OwnerDocument.CreateElement(ele.GetXMLName());
                            ele.ToXML(NewElement);
                            LastChar = ele as ZYTextChar;
                        }
                    }
                    else
                    {
                        LastChar = null;
                        NewElement = myElement.OwnerDocument.CreateElement(ele.GetXMLName());
                        ele.ToXML(NewElement);
                    }
                    myElement.AppendChild(NewElement);
                }
            }


            //myElement.SetAttribute("clicked", this.Clicked.ToString());
            return true;
            //return base.ToXML(myElement);
        }

        public override bool FromXML(XmlElement myElement)
        {
            this.MustClick = myElement.GetAttribute("mustclick") != "" ? bool.Parse(myElement.GetAttribute("mustclick")) : false;
            this.Code = myElement.GetAttribute("code");
            if (myElement.HasAttribute("candelete"))
            {
                this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
            }

            //2019.8.14-hdf����Ԫ�ء���ʽ���ַ�����Ӳ��뻻�з����ܣ���س���
            //����������Ԫ�ز�����text�����ı�������ʹ��ChildElement�����ַ�����Ԫ��
            //����������Ԫ�ض��Ǽ̳�ZyTextBlock������ֱ���ڸ����ToXML��FromXML�������޸��߼�
            if (this is ZYMacro || this is ZYReplace || this is ZYFormatString || this is ZYDiag || this is ZYSubject)
            {
                myChildElements.Clear();
                System.Collections.ArrayList NewList = new System.Collections.ArrayList();
                myOwnerDocument.LoadElementsToList(myElement, NewList);
                this.InsertRangeBefore(NewList, null);
                foreach (ZYTextElement e in myChildElements)
                    e.Parent = this;
            }

            //this.Clicked = bool.Parse(myElement.GetAttribute("clicked"));
            return true;
            //return base.FromXML(myElement);
        }
    }// class ZYTextBlock
}