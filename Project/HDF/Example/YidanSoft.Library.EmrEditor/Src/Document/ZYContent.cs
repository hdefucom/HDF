using System;
///////////////////////���л���Ҫ������
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using YidanSoft.Library.EmrEditor.Src.Clipboard;
using System.Windows.Forms;
using System.Collections.Generic;
using YidanSoft.Library.EmrEditor.Src.Gui; //add by myc 2014-07-01 ���ԭ���°�ҳü���ڸİ���Ҫ
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Xml;
using System.Linq;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// ��Ȼ���Ե��Ӳ����ĵ����ݹ�����
    /// </summary>
    /// <remarks>����������ά��һ���б����б���ȫ��Ϊ<link>ZYTextDocumentLib.ZYTextElement</link>���ͣ�
    /// ����ɾ���޸ĺͲ���Ԫ�أ����Ӳ����ı��ĵ�������Խ�������ά���Լ��Ŀ���ʾԪ�ص��б�
    /// ��Ԫ�ػ�ʹ��<a href="#ZYTextDocumentLib.ZYContent.SelectStart">SelectStart</a>���Ժ�<a href="#ZYTextDocumentLib.ZYContent.SelectLength">SelectLength</a>����
    /// �������ĵ��еĲ�����ѡ�����򣬲��ṩһϵ�к�����������������������
    /// ���⻹�ṩ��һЩ�����ĵ����ݵ�ͨ������
    /// ������ʹ��<link>ZYTextDocumentLib.IEMRContentDocument</link>�ӿ��������ĵ�������
    /// </remarks>
    /// 
    [Serializable]
    public class ZYContent
    {
        private ZYTextDocument myDocument = null;
        /// <summary>
        /// ������ʾ��Ԫ�ؼ���,��ZYDocument�Ĺ��캯���г�ʼ��
        /// </summary>
        private System.Collections.ArrayList myElements = null;

        /// <summary>
        /// mfb ����������һ��������ڵ�����λ��
        /// ����ǵ�һ�δ��ĵ�,���λ��Ĭ���ڵ�һ��Ԫ�ش�,��ȻΪ0
        /// </summary>
        private int intSelectStart = 0;
        /// <summary>
        /// mfb ����������һ�����ѡ��ĳ���,���߽в���
        /// ���Ϊ0, ������,��û�л�ѡ.
        /// </summary>
        private int intSelectLength = 0;

        private string strFixLenText = null;

        /// <summary>
        /// AI֢״����
        /// </summary>
        private SubjectForm subjectForm = null;

        private bool bolModified = false;
        private bool bolAutoClearSelection = true;

        private int intLastXPos = -1;

        private bool bolLineEndFlag = false;


        public bool LineEndFlag
        {
            get { return bolLineEndFlag; }
        }

        //		private bool	bolLogicDelete		= false;
        //		//private bool	bolUpdading			= false;
        //
        //
        //		/// <summary>
        //		/// �߼�ɾ��
        //		/// </summary>
        //		public bool LogicDelete
        //		{
        //			get{ return bolLogicDelete ;}
        //			set{ bolLogicDelete = value;}
        //		}

        /// <summary>
        /// �������������ĵ�����
        /// </summary>
        public ZYTextDocument Document
        {
            get { return myDocument; }
            set { myDocument = value; }
        }

        /// <summary>
        /// �Ƿ��Զ����ѡ��״̬,��ΪTrue������λ���޸�ʱ���Զ�����SelectLength���ԣ��������ݾɵĲ�����λ�ü���SelectLength����
        /// </summary>
        public bool AutoClearSelection
        {
            get { return bolAutoClearSelection; }
            set
            {
                bolAutoClearSelection = value;
            }
        }

        /// <summary>
        /// ������ʾ��Ԫ���б�
        /// </summary>
        public System.Collections.ArrayList Elements
        {
            get { return myElements; }
            set
            {
                myElements = value;
                bolModified = false;
                strFixLenText = null;
                this.SetSelection(0, 0);
            }
        }

        public int IndexOf(ZYTextElement e)
        {
            //return myElements.IndexOf(e); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            return HBFElements.IndexOf(e); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        }

        /// <summary>
        /// ����,�����ĵ������Ƿ�ı�
        /// </summary>
        public bool Modified
        {
            get { return bolModified; }
            set { bolModified = value; }
        }

        /// <summary>
        /// ������λ��
        /// </summary>
        public int SelectStart
        {
            get { return intSelectStart; }
            set
            {
                if (bolAutoClearSelection)
                    this.SetSelection(value, 0);
                else
                    this.SetSelection(value, intSelectStart - value);
            }
        }

        public delegate void DelChangeSubjectStr();

        public DelChangeSubjectStr delChangeSubjectStr;

        /// <summary>
        /// ���ǰһ��
        /// </summary>
        public ZYTextLine PreLine
        {
            get
            {
                try
                {
                    ZYTextLine myLine = this.CurrentLine;
                    //if (myDocument.Lines.IndexOf(myLine) > 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    if (myDocument.HBFLines.IndexOf(myLine) > 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    {
                        for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
                        {
                            //ZYTextElement myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                            ZYTextElement myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                            if (myElement.OwnerLine != myLine)
                                return myElement.OwnerLine;
                        }
                        return null;
                    }
                    else
                        return myLine;
                }
                catch { }
                return null;
            }
        }

        /// <summary>
        /// �����һ��
        /// </summary>
        public ZYTextLine NextLine
        {
            get
            {
                try
                {
                    ZYTextLine myLine = this.CurrentLine;
                    //if (myDocument.Lines.IndexOf(myLine) < myDocument.Lines.Count - 1) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    if (myDocument.HBFLines.IndexOf(myLine) < myDocument.HBFLines.Count - 1) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    {
                        //for (int iCount = intSelectStart + 1; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                        //{
                        //    ZYTextElement myElement = (ZYTextElement)myElements[iCount];
                        //    if (myElement.OwnerLine != myLine)
                        //        return myElement.OwnerLine;
                        //}

                        for (int iCount = intSelectStart + 1; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                        {
                            ZYTextElement myElement = (ZYTextElement)HBFElements[iCount];
                            if (myElement.OwnerLine != myLine)
                                return myElement.OwnerLine;
                        }
                        return null;
                    }
                    else
                        return myLine;
                }
                catch { }
                return null;
            }
        }

        /// <summary>
        /// ��õ�ǰ��
        /// </summary>
        public ZYTextLine CurrentLine
        {
            get
            {
                //if (myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                if (HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    return null;
                else
                {
                    //if (myElements != null && intSelectStart >= 0 && intSelectStart < myElements.Count) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    if (HBFElements != null && intSelectStart >= 0 && intSelectStart < HBFElements.Count) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    {
                        //ZYTextLine myLine = ((ZYTextElement)myElements[intSelectStart]).OwnerLine; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                        ZYTextLine myLine = ((ZYTextElement)HBFElements[intSelectStart]).OwnerLine; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

                        //if (this.bolLineEndFlag && myDocument.Lines.IndexOf(myLine) > 0)
                        //    return (ZYTextLine)myDocument.Lines[myDocument.Lines.IndexOf(myLine) - 1]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                        if (this.bolLineEndFlag && myDocument.HBFLines.IndexOf(myLine) > 0)
                            return (ZYTextLine)myDocument.HBFLines[myDocument.HBFLines.IndexOf(myLine) - 1]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                        else
                            return myLine;
                    }
                    else
                        //return ((ZYTextElement)myElements[myElements.Count - 1]).OwnerLine; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                        return ((ZYTextElement)HBFElements[HBFElements.Count - 1]).OwnerLine; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                }
            }
        }// CurrenLine 

        #region add by myc 2014-07-03 ע��ԭ���°�ҳü���ڸİ���Ҫ
        ///// <summary>
        ///// ��õ�ǰԪ��
        ///// </summary>
        //public ZYTextElement CurrentElement
        //{
        //    get
        //    {
        //        ZYTextElement myElement = null;
        //        if (myElements.Count == 0)
        //            return null;
        //        else
        //        {

        //            if (myElements != null && intSelectStart >= 0 && intSelectStart < myElements.Count)
        //            {
        //                myElement = (ZYTextElement)myElements[intSelectStart];
        //                //�����Ԫ�أ���
        //                #region bwy :
        //                //if (myElement.Parent != null && myElement.Parent is ZYTextBlock)
        //                //{
        //                //    myElement = myElement.Parent.FirstElement;
        //                //    //ͬʱҲҪ�޸�intSelectStart,��Ϊɾ�������Ǹ������ֵȥ��Ԫ�ص�
        //                //    intSelectStart = this.IndexOf(myElement);
        //                //    intSelectLength = 0;
        //                //}
        //                #endregion bwy :
        //            }

        //            else
        //            {
        //                myElement = (ZYTextElement)myElements[myElements.Count - 1];
        //            }
        //            //if (myElement.Parent.WholeElement)
        //            //    myElement = myElement.Parent;
        //            //Debug.WriteLine("CurrentElement��ȡ��ǰԪ���� " + myElement);
        //            return myElement;
        //        }
        //    }
        //    set
        //    {
        //        if (myElements.Contains(value))
        //            this.MoveSelectStart(myElements.IndexOf(value));
        //        intSelectStart = this.FixIndex(intSelectStart);
        //        Debug.WriteLine("���õ�ǰԪ�� " + value + " value.RealTop:" + value.RealTop);
        //    }
        //} 
        #endregion

        /// <summary>
        /// ��õ�ǰѡ�е�Ԫ��,��û��ѡ��Ԫ�ػ�ѡ�ж��Ԫ���򷵻ؿ�
        /// </summary>
        public ZYTextElement CurrentSelectElement
        {
            get
            {
                //if (myElements.Count == 0 || (intSelectLength != 1 && intSelectLength != -1)) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                if (HBFElements.Count == 0 || (intSelectLength != 1 && intSelectLength != -1)) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    return null;
                else
                    //return (ZYTextElement)myElements[this.AbsSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    return (ZYTextElement)HBFElements[this.AbsSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            }
            set
            {
                //if (myElements.Contains(value)) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                //{
                //    this.SetSelection(myElements.IndexOf(value) + 1, -1);
                //}

                if (HBFElements.Contains(value)) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                {
                    this.SetSelection(HBFElements.IndexOf(value) + 1, -1);
                }
            }
        }
        /// <summary>
        /// ��õ�ǰλ�õ�ǰһ��Ԫ��
        /// </summary>
        public ZYTextElement PreElement
        {
            get
            {
                //if (myElements != null && myElements.Count > 0 && intSelectStart > 0 && intSelectStart < myElements.Count) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                //    return (ZYTextElement)myElements[intSelectStart - 1];

                if (HBFElements != null && HBFElements.Count > 0
                    && intSelectStart > 0 && intSelectStart < HBFElements.Count) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    return (ZYTextElement)HBFElements[intSelectStart - 1];
                else
                    return null;
            }
        }

        /// <summary>
        /// ���ָ��Ԫ�ص�ǰһ��Ԫ��
        /// </summary>
        /// <param name="refElement">ָ����Ԫ��</param>
        /// <returns>��Ԫ�ص�ǰһ��Ԫ����û�ҵ��򷵻ؿ�</returns>
        public ZYTextElement GetPreElement(ZYTextElement refElement)
        {
            //int index = myElements.IndexOf(refElement); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            int index = HBFElements.IndexOf(refElement); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            if (index >= 1)
                //return (ZYTextElement)myElements[index - 1]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                return (ZYTextElement)HBFElements[index - 1]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            else
                return null;
        }

        /// <summary>
        /// ���ָ��Ԫ�صĺ�һ��Ԫ��
        /// </summary>
        /// <param name="refElement">ָ����Ԫ��</param>
        /// <returns>��Ԫ�ص�ǰһ��Ԫ�أ���û���ҵ��򷵻ؿ�</returns>
        public ZYTextElement GetNextElement(ZYTextElement refElement)
        {
            //int index = myElements.IndexOf(refElement); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            //if (index >= 0 && index < myElements.Count - 1)
            //    return (ZYTextElement)myElements[index + 1];

            int index = HBFElements.IndexOf(refElement);  //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            if (index >= 0 && index < HBFElements.Count - 1)
                return (ZYTextElement)HBFElements[index + 1];
            else
                return null;
        }

        //public int GetMaxLockLevel()
        //{
        //    int level = -1 ;
        //    for( int iCount = 0 ; iCount < myElements.Count ; iCount ++ )
        //    {
        //        if( myElements[ iCount ] is ZYTextLock )
        //        {
        //            ZYTextLock Lock = ( ZYTextLock ) myElements[ iCount ] ;
        //            if( level < Lock.Level )
        //                level = Lock.Level ;
        //        }
        //    }
        //    return level ;
        //}

        protected int intUserLevel = 0;
        /// <summary>
        /// ��ǰ�û��ȼ�
        /// </summary>
        public int UserLevel
        {
            get { return intUserLevel; }
            set { intUserLevel = value; }
        }

        #region add by myc 2014-06-12 ע��ԭ�򣺴˷�����û�ж�ѡ������߽��Ϻ��лس���ʱ������ȷ����
        //public bool IsLock(int index)
        //{
        //    if (index >= 0)
        //    {
        //        for (int iCount = index; iCount < myElements.Count; iCount++)
        //        {
        //            if (myElements[iCount] is ZYTextLock)
        //            {
        //                ZYTextLock Lock = (ZYTextLock)myElements[iCount];
        //                if (Lock.Level >= intUserLevel)
        //                    return true;
        //            }


        //        }

        //        #region bwy : �̶��ı�����ɾ
        //        if (myElements[index] is ZYFixedText || myElements[index] is ZYText)
        //        {
        //            return true;
        //        }
        //        #endregion bwy :
        //    }
        //    return false;
        //}
        #endregion

        public bool IsLock(ZYTextElement element)
        {
            //			if( element is ZYTextFlag )
            //				return ! myDocument.Info.DesignMode ;
            //			if( element is ZYTextLock )
            //				return ! myDocument.Info.DesignMode ;
            //			int index = myElements.IndexOf( element );
            //			if( index >= 0 )
            //			{
            //				return IsLock( index );
            //			}
            return false;
        }

        /// <summary>
        /// �ж�һ��Ԫ���Ƿ�ǰԪ��
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public bool isCurrentElement(ZYTextElement myElement)
        {
            return (this.CurrentElement == myElement && intSelectLength == 0);
        }

        /// <summary>
        /// ��ò���������е����е�Ԫ��
        /// </summary>
        /// <returns>Ԫ���б�</returns>
        public System.Collections.ArrayList GetCurrentLineElements()
        {
            intSelectStart = this.FixIndex(intSelectStart);
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            int LineIndex = myElement.LineIndex;
            // ��õ�ǰ�е�һ��Ԫ�صı��
            int StartIndex = 0;
            for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
            {
                //myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                if (myElement.LineIndex != LineIndex)
                {
                    StartIndex = iCount + 1;
                    break;
                }
            }
            // ��䵱ǰ��Ԫ���б�
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            //for (int iCount = StartIndex; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            for (int iCount = StartIndex; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            {
                //myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                if (myElement.LineIndex == LineIndex)
                {
                    myList.Add(myElement);
                }
                else
                    break;
            }
            return myList;
        }

        /// <summary>
        /// ���ص�ǰ�����׵Ŀհ��ַ���
        /// </summary>
        /// <returns>���׵Ŀհ��ַ���</returns>
        public string GetCurrentLineHeadBlank()
        {
            intSelectStart = this.FixIndex(intSelectStart);
            System.Collections.ArrayList myList = this.GetCurrentLineElements();
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            for (int iCount = 0; iCount < myList.Count; iCount++)
            {
                ZYTextChar myChar = myList[iCount] as ZYTextChar;
                if (myChar == null)
                    break;
                else
                {
                    if (char.IsWhiteSpace(myChar.Char))
                        myStr.Append(myChar.Char);
                    else
                        break;
                }
            }
            return myStr.ToString();
        }

        #region ********************* ѡ������ *********************

        /// <summary>
        /// ѡ������ĳ���,��С��0
        /// </summary>
        public int SelectLength
        {
            get { return intSelectLength; }
            set { intSelectLength = value; }
        }

        #region add by myc 2014-06-12 ע��ԭ�����·�����δ����ѡ������߽��ϵĻس�����һ���ַ���ѡ�����
        ///// <summary>
        ///// ѡ������ľ��Կ�ʼλ��
        ///// </summary>
        //public int AbsSelectStart
        //{
        //    get { return (intSelectLength > 0 ? intSelectStart : intSelectStart + intSelectLength); }
        //}
        ///// <summary>
        ///// ѡ������ľ��Խ���λ��
        ///// </summary>
        //public int AbsSelectEnd
        //{
        //    get
        //    {
        //        int intValue;
        //        if (intSelectLength >= 0)
        //            intValue = intSelectStart + intSelectLength;//- 1;
        //        else
        //            intValue = intSelectStart;// -1;

        //        if (intValue >= myElements.Count - 1)
        //            intValue = myElements.Count - 1;
        //        return intValue;
        //    }
        //}
        #endregion

        //		public void ResetNative()
        //		{
        //			this.MoveSelectStart( 0 );
        //			ZYTextLock Lock = null;
        //			for( int iCount = myElements.Count-1 ; iCount >= 0 ; iCount -- )
        //			{
        //				ZYTextElement element = ( ZYTextElement ) myElements[ iCount ] ;
        //				if( element is ZYTextLock )
        //				{
        //					Lock = ( ZYTextLock ) element ;
        //				}
        //				else
        //				{
        //					if( Lock == null )
        //						element.Visible = true;
        //					else
        //					{
        //						ZYTextSaveLog log = myDocument.SaveLogs.SafeGet( element.CreatorIndex );
        //						if( log != null )
        //						{
        //							element.Visible = ( log.Level == Lock.Level );
        //						}
        //						else
        //							element.Visible = true;
        //					}
        //				}
        //			}
        //		}

        #region add by myc 2014-06-09 ע��ԭ�����·�����δ����ѡ������߽��ϵĻس���
        /// <summary>
        /// �ж�ָ����Ԫ���Ƿ���ѡ������
        /// </summary>
        /// <param name="myElement">�ĵ�Ԫ�ض���</param>
        /// <returns>�Ƿ���ѡ������</returns>
        //public bool isSelected(ZYTextElement myElement)
        //{
        //    if (intSelectLength == 0 || myElement == null)
        //        return false;
        //    else
        //    {
        //        int index = myElement.Index;// myElements.IndexOf( myElement);
        //        if (intSelectLength > 0 && index >= intSelectStart && index < intSelectStart + intSelectLength)
        //            return true;
        //        if (intSelectLength < 0 && index >= intSelectStart + intSelectLength && index < intSelectStart)
        //            return true;

        //        return false;
        //    }
        //} 
        #endregion

        #region add by myc 2014-06-12 ע��ԭ�����·�����δ����ѡ������߽��ϵĻس�����һ���ַ���ѡ�����
        ///// <summary>
        ///// �ж��Ƿ����ѡ�����Ŀ
        ///// </summary>
        ///// <returns></returns>
        //public bool HasSelected()
        //{
        //    return (intSelectLength != 0);
        //} 
        #endregion

        /// <summary>
        /// �ж��Ƿ�ѡ�����ı�
        /// </summary>
        /// <returns></returns>
        public bool HasSelectedText()
        {
            System.Collections.ArrayList myList = this.GetSelectElements();
            if (myList != null && myList.Count > 0)
            {
                foreach (ZYTextElement myElement in myList)
                {
                    if (myElement.isTextElement())
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���ѡ�е��ı�
        /// </summary>
        /// <returns></returns>
        public string GetSelectedText()
        {
            System.Collections.ArrayList myList = this.GetSelectElements();
            if (myList != null && myList.Count > 0)
                return ZYTextElement.GetElementsText(myList);
            return null;
        }

        /// <summary>
        /// �ж��Ƿ�ѡ�����ı�
        /// </summary>
        /// <returns></returns>
        public bool HasSelectedChar()
        {
            System.Collections.ArrayList myList = this.GetSelectElements();
            if (myList != null && myList.Count > 0)
            {
                foreach (object obj in myList)
                {
                    if (obj is ZYTextChar)
                        return true;
                }
            }
            return false;
        }


        #region add by myc 2014-06-09 ע��ԭ�򣺴˷���û�жԵ�Ԫ��Ԫ�������������ƣ�����Ӱ�쵽����ڱ���ڵ���ȷ�ƶ�
        ///// <summary>
        ///// ������㾡���ƶ���ָ��λ��
        ///// </summary>
        ///// <param name="x">ָ��λ�õ�X����</param>
        ///// <param name="y">ָ��λ�õ�Y����</param>
        //public void MoveTo(int x, int y)
        //{
        //    //intLastXPos = -1;
        //    if (myDocument != null)
        //    {
        //        ZYTextLine CurrentLine = null;

        //        //mfb 2009-7-14 ���˶�λ�еķ���
        //        foreach (ZYTextLine myLine in myDocument.Lines)
        //        {
        //            Rectangle lineRec = new Rectangle(myLine.RealLeft, myLine.RealTop, myLine.ContentWidth, myLine.FullHeight);
        //            if (lineRec.Contains(new Point(x, y)))
        //            {
        //                CurrentLine = myLine;
        //                break;
        //            }
        //        }

        //        //Debug.WriteLine("��������" + CurrentLine.Elements.Count);
        //        // ��û���ҵ���ǰ�����������һ��Ϊ��ǰ��
        //        if (CurrentLine == null && myDocument.Lines.Count > 0)
        //        {
        //            CurrentLine = (ZYTextLine)myDocument.Lines[myDocument.Lines.Count - 1];
        //        }

        //        // �������û���ҵ���ǰ����������ʧ�ܣ���������
        //        if (CurrentLine == null)
        //            return;

        //        bool bolFlag = false;
        //        int index = 0;
        //        x -= CurrentLine.RealLeft;

        //        // ȷ����ǰԪ��,��ǰԪ���ǵ�ǰ�����ұ�Ե����ָ���ģ������Ԫ��
        //        ZYTextElement CurrentElement = null;
        //        //��ǰ����һ������,��һ���յ�PԪ��
        //        if (CurrentLine.Elements.Count == 0)
        //        {
        //            CurrentElement = CurrentLine.Container;
        //        }
        //        foreach (ZYTextElement myElement in CurrentLine.Elements)
        //        {
        //            if (x < myElement.Left + myElement.Width)
        //            {
        //                if (x > (myElement.Left + myElement.Width / 2))
        //                {
        //                    continue;
        //                }
        //                if (myElement.Parent.WholeElement)
        //                    return;
        //                CurrentElement = myElement;
        //                break;
        //            }
        //        }

        //        if (CurrentElement == null)
        //        {
        //            // ��û�ҵ���ǰԪ�����ʾ��ǰλ�������ҳ�����ǰ�еķ�Χ
        //            // ����ǰ���ѻ��з���β�����øû��з�Ϊ��ǰԪ��
        //            // ��������Ϊ��ǰ�����һ��Ԫ�ص���һ��Ԫ��,��������β��־
        //            CurrentElement = CurrentLine.LastElement;

        //            if (CurrentLine.HasLineEnd)
        //            {
        //                index = myElements.IndexOf(CurrentLine.LastElement);
        //            }
        //            else
        //            {
        //                index = myElements.IndexOf(CurrentLine.LastElement) + 1;
        //                bolFlag = true;
        //            }
        //        }
        //        else
        //        {
        //            //�ҵ��������ַ�
        //            index = myElements.IndexOf(CurrentElement);
        //            bolFlag = false;
        //        }
        //        // ������ǰԪ�����
        //        if (index > myElements.Count)
        //        {
        //            index = myElements.Count - 1;
        //            bolFlag = false;
        //        }
        //        if (index < 0)
        //        {
        //            index = 0;
        //            bolFlag = false;
        //        }
        //        this.MoveSelectStart(index);

        //        if (bolLineEndFlag != bolFlag)
        //        {
        //            bolLineEndFlag = bolFlag;
        //            ((ZYTextDocument)myDocument).UpdateTextCaret();
        //        }
        //    }
        //    #region comment
        //    // if

        //    //			
        //    //			intLastXPos = -1 ;
        //    //			ZYTextElement myElement = null;
        //    //			ZYTextElement LastParent = null;
        //    //			ZYTextLine LastLine = null;
        //    //			bool bolFirst = true;
        //    //			int LastLineIndex = -1 ;
        //    //			//int LastLineTop = 0 ;
        //    //			bool bolCorrectLine = false;
        //    //			// �������е�Ԫ��
        //    //			for( int iCount = myElements.Count -1 ; iCount >=0 ; iCount -- )
        //    //			{
        //    //				myElement = ( ZYTextElement) myElements[iCount];
        //    //				if( bolCorrectLine )
        //    //				{
        //    //					if( myElement.LineIndex == LastLineIndex )
        //    //					{
        //    //						if( x > (myElement.RealLeft   + myElement.Width / 2 ) )
        //    //						{
        //    //							// ����ǰԪ�ص���������ָ���������򽫲���㶨�ڸ�Ԫ�ص��ұ�(���ø�Ԫ�ص���һ��Ԫ��Ϊ��ǰԪ��)
        //    //							// ����Ԫ��Ϊ��һ���߶�ƥ���Ԫ�������ø�Ԫ��Ϊ��ǰԪ��
        //    //							if( bolFirst )
        //    //								this.MoveSelectStart( iCount + 1);
        //    //							else
        //    //								this.MoveSelectStart( iCount );
        //    //							return;
        //    //						}
        //    //					}
        //    //					else
        //    //					{
        //    //						this.MoveSelectStart( iCount + 1 );
        //    //						return;
        //    //					}
        //    //				}
        //    //				else
        //    //				{
        //    //					if( myElement.LineIndex != LastLineIndex || myElement.Parent != LastParent )
        //    //					{
        //    //						LastLineIndex = myElement.LineIndex ;
        //    //						// ��Ԫ�������ı��еľ��Զ���λ��С��ָ��λ�õ�Y����,������λ�ڸ���
        //    //						if( y >= myElement.OwnerLine.RealTop )
        //    //						{
        //    //							bolCorrectLine = true;
        //    //							if( x > myElement.RealLeft || myElement.OwnerLine.Elements.Count  == 1 )
        //    //							{
        //    //								this.MoveSelectStart( iCount);
        //    //								return ;
        //    //							}
        //    //						}
        //    //						else
        //    //							bolCorrectLine = false;
        //    //					}
        //    //				}
        //    //				LastParent = myElement.Parent ;
        //    //			}
        //    //			this.MoveSelectStart(0);
        //    #endregion
        //}
        #endregion

        #region add by myc 2014-06-12 ע��ԭ�򣺴˷�����û�ж�ѡ������߽��Ϻ��лس���ʱ������ȷ����
        ///// <summary>
        ///// ����ѡ�������С
        ///// </summary>
        ///// <param name="NewSelectStart">�µ�ѡ������ʼ�����</param>
        ///// <param name="NewSelectLength">��ѡ������ĳ���</param>
        ///// <returns>�����Ƿ�ɹ�</returns>
        //public bool SetSelection(int NewSelectStart, int NewSelectLength)
        //{
        //    bolLineEndFlag = false;
        //    if (myElements == null || myElements.Count == 0)
        //    {
        //        return false;
        //    }

        //    int sourceIndex = 0; //ԭ��������λ��
        //    int sourceLength = 0; //ԭ����ѡ�񳤶�,δѡ����Ϊ0

        //    int newIndex = 0; //���µ�����λ��
        //    int newLength = 0; //���µ�ѡ�񳤶�

        //    int intTemp = 0;

        //    NewSelectStart = FixIndex(NewSelectStart);
        //    int iStep = (NewSelectStart > intSelectStart ? 1 : -1);

        //    bool bolZeroSelection = (NewSelectLength == 0);

        //    // ���ݵ�ǰԪ�صĸ������Ƿ���һ��������в���������
        //    //for (int iCount = NewSelectStart; iCount >= 0 && iCount < myElements.Count; iCount += iStep)
        //    //{
        //    //    ZYTextElement vElement = (ZYTextElement)myElements[iCount];
        //    //    if (vElement is ZYTextContainer || vElement.Parent.WholeElement == false)
        //    //    {
        //    //        NewSelectStart = iCount;
        //    //        break;
        //    //    }
        //    //    if ( !bolZeroSelection )
        //    //        NewSelectLength -= iStep;
        //    //}

        //    //��ѡ������δ�����ı���ֱ���˳�����
        //    if (intSelectStart == NewSelectStart && intSelectLength == NewSelectLength)
        //        return true;

        //    int OldSelectStart = intSelectStart;

        //    //ZYTextElement OldElement = ( ZYTextElement  )myElements[OldSelectStart] ;

        //    // ���û��ѡ����Ԫ��,����˵δ���� "������" ѡ
        //    // ֻ��������һ�¶���,ûʲô��С�ֵ�.
        //    if (NewSelectLength == 0 && intSelectLength == 0)
        //    {
        //        //���汾�ε��������λ��
        //        intSelectStart = NewSelectStart;

        //        //���������Χ,��զ��զ��.�������Ƕ�λ����һ��Ԫ��,���Ƕ�λ�����һ��Ԫ��
        //        if (intSelectStart < 0)
        //        {
        //            intSelectStart = 0;
        //        }
        //        if (intSelectStart >= myElements.Count)
        //        {
        //            intSelectStart = myElements.Count - 1;
        //        }
        //        //��ȡ�������Ԫ��
        //        ZYTextElement NewElement = (ZYTextElement)myElements[intSelectStart];

        //        if (myDocument != null)
        //        {
        //            myDocument.SelectionChanged(OldSelectStart, 0, intSelectStart, 0);
        //        }
        //        if (OldSelectStart >= 0 && OldSelectStart < myElements.Count)
        //        {
        //            ((ZYTextElement)myElements[OldSelectStart]).HandleLeave();
        //        }
        //        //Debug.WriteLine("HandleEnter");
        //        ((ZYTextElement)myElements[intSelectStart]).HandleEnter();
        //        return true;
        //    }
        //    if (intSelectLength > 0)
        //    {
        //        sourceIndex = intSelectStart;
        //        sourceLength = intSelectStart + intSelectLength;
        //    }
        //    else //�ѵ�����С��0�����?
        //    {
        //        sourceIndex = intSelectStart + intSelectLength;
        //        sourceLength = intSelectStart;
        //    }
        //    if (NewSelectLength > 0)
        //    {
        //        newIndex = NewSelectStart;
        //        newLength = NewSelectStart + NewSelectLength;
        //    }
        //    else
        //    {
        //        newIndex = NewSelectStart + NewSelectLength;
        //        newLength = NewSelectStart;
        //    }
        //    if (sourceIndex > newIndex)
        //    {
        //        intTemp = sourceIndex;
        //        sourceIndex = newIndex;
        //        newIndex = intTemp;
        //    }
        //    if (sourceLength > newLength)
        //    {
        //        intTemp = sourceLength;
        //        sourceLength = newLength;
        //        newLength = intTemp;
        //    }
        //    if (newIndex > sourceLength)
        //    {
        //        intTemp = newIndex;
        //        newIndex = sourceLength;
        //        sourceLength = intTemp;
        //    }
        //    // [s1->s2] �� [e1->e2] Ϊ�ĵ���ѡ��״̬�����ı��Ԫ�ص���ŷ�Χ
        //    //
        //    //			// �������е��ı��н���ѡ��״̬�ı����
        //    //			for(int iCount = s1 ; iCount <= e1 ; iCount ++ )
        //    //				(myElements[iCount] as ZYTextElement ).Invalidly = true;
        //    //			for(int iCount = s2 ; iCount <= e2 ; iCount ++ )
        //    //				(myElements[iCount] as ZYTextElement ).Invalidly = true;

        //    intSelectStart = NewSelectStart;
        //    intSelectLength = NewSelectLength;
        //    //Debug.WriteLine("before fix ");

        //    FixSelection();


        //    sourceIndex = FixIndex(sourceIndex);
        //    sourceLength = FixIndex(sourceLength);
        //    newIndex = FixIndex(newIndex);
        //    newLength = FixIndex(newLength);
        //    if (sourceIndex != newIndex)
        //    {
        //        for (int iCount = sourceIndex; iCount <= newIndex; iCount++)
        //            if (((ZYTextElement)myElements[iCount]).HandleSelectedChange())
        //                return false;
        //    }
        //    if (sourceLength != newLength)
        //    {
        //        for (int iCount = sourceLength; iCount <= newLength; iCount++)
        //            if (((ZYTextElement)myElements[iCount]).HandleSelectedChange())
        //                return false;
        //    }

        //    if (myDocument != null)
        //    {
        //        myDocument.SelectionChanged(sourceIndex, sourceLength, newIndex, newLength);
        //    }
        //    if (OldSelectStart >= 0 && OldSelectStart < myElements.Count)
        //    {
        //        ((ZYTextElement)myElements[OldSelectStart]).HandleLeave();
        //    }
        //    ((ZYTextElement)myElements[intSelectStart]).HandleEnter();
        //    return true;
        //} 
        #endregion

        #region add by myc 2014-07-03 ע��ԭ���°�ҳü���ڸİ���Ҫ
        ///// <summary>
        ///// ����Ԫ������Ա�֤��Ҫ��Ԫ���б�ķ�Χ��
        ///// </summary>
        ///// <param name="index">ԭʼ�����</param>
        ///// <returns>����������</returns>
        //private int FixIndex(int index)
        //{
        //    if (index <= 0)
        //    {
        //        return 0;
        //    }

        //    if (index >= myElements.Count)
        //    {
        //        return myElements.Count - 1;
        //    }
        //    return index;
        //} 
        #endregion

        /// <summary>
        /// ѡ�����е�Ԫ��
        /// </summary>
        public void SelectAll()
        {
            //this.SetSelection(0, myElements.Count);
            //this.SetSelection(myElements.Count, -myElements.Count); //add by myc 2014-06-17 ���ԭ��Ctrl+Aȫѡ�ĵ�Ԫ�ز���
            this.SetSelection(HBFElements.Count, -HBFElements.Count); //add by myc 2014-06-17 ���ԭ��Ctrl+Aȫѡ�ĵ�Ԫ�ز���
        }

        #endregion

        #region add by myc 2014-06-12 ע��ԭ�򣺴˷�����û�ж�ѡ������߽��Ϻ��лس���ʱ������ȷ����
        ///// <summary>
        ///// �ƶ���ǰ������λ��
        ///// </summary>
        ///// <param name="index">�������µ�λ��</param>
        ///// <returns>�����Ƿ�ɹ�</returns>
        //public bool MoveSelectStart(int index)
        //{
        //    index = this.FixIndex(index);
        //    int length = bolAutoClearSelection ? 0 : intSelectLength + intSelectStart - index;

        //    //Debug.WriteLine("zycontent MoveSelectStart ����ѡ��Χ " + index + "-" + length);

        //    return SetSelection(index, length);
        //}
        #endregion

        #region add by myc 2014-07-03 ע��ԭ���°�ҳü���ڸİ���Ҫ
        ///// <summary>
        ///// ��������ƶ���ָ��Ԫ��ǰ��
        ///// </summary>
        ///// <param name="refElement">ָ����Ԫ��</param>
        ///// <returns>�����Ƿ�ɹ�</returns>
        //public bool MoveSelectStart(ZYTextElement refElement)
        //{
        //    if (myElements.IndexOf(refElement) >= 0)
        //    {
        //        return MoveSelectStart(myElements.IndexOf(refElement));
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// �������ѡ�������Ԫ��
        ///// </summary>
        ///// <returns>��������ѡ�������Ԫ�ص��б�</returns>
        //public System.Collections.ArrayList GetSelectElements()
        //{
        //    if (myElements == null)
        //        return null;
        //    else
        //    {
        //        System.Collections.ArrayList myList = new System.Collections.ArrayList();
        //        int intEnd = this.AbsSelectEnd;
        //        for (int iCount = this.AbsSelectStart; iCount < intEnd; iCount++)
        //            myList.Add(myElements[iCount]);
        //        return myList;
        //    }
        //} 
        #endregion

        #region add by myc 2014-06-23 ע��ԭ�򣺴˷�����û�ж�ѡ������߽��Ϻ��лس���ʱ��ֻ���ı�����ѡ��Ŀ�Ƚṹ��Ԫ��������ȷ����
        ///// <summary>
        ///// �������ѡ������Ķ���Ԫ��mfb
        ///// </summary>
        ///// <returns>����ѡ�����������ж���Ԫ�ص��б�,������ʧ���򷵻ؿ�����</returns>
        //public System.Collections.ArrayList GetSelectParagraph()
        //{
        //    if (myElements == null)
        //        return null;
        //    else
        //    {
        //        System.Collections.ArrayList myList = new System.Collections.ArrayList();
        //        int intEnd = this.AbsSelectEnd;
        //        for (int iCount = this.AbsSelectStart; iCount <= intEnd; iCount++)
        //        {
        //            if ((myElements[iCount] as ZYTextElement).Parent is ZYTextParagraph)
        //            {
        //                if (!myList.Contains((myElements[iCount] as ZYTextElement).Parent))
        //                {
        //                    myList.Add((myElements[iCount] as ZYTextElement).Parent);
        //                }
        //            }
        //        }
        //        return myList;
        //    }
        //}
        #endregion

        /// <summary>
        /// ����������֮�������Ԫ��
        /// </summary>
        /// <param name="Index1">���1</param>
        /// <param name="Index2">���2</param>
        /// <returns>���������ָ�����������֮�������Ԫ�ص��б����</returns>
        public System.Collections.ArrayList GetElementsRange(int Index1, int Index2)
        {
            //if (myElements == null) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return null;
            else
            {
                System.Collections.ArrayList myList = new System.Collections.ArrayList();
                int Temp = 0;
                if (Index1 > Index2)
                {
                    Temp = Index1;
                    Index1 = Index2;
                    Index2 = Temp;
                }
                Index1 = this.FixIndex(Index1);
                Index2 = this.FixIndex(Index2);

                for (int iCount = Index1; iCount < Index2; iCount++)
                    //myList.Add(myElements[iCount]); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    myList.Add(HBFElements[iCount]); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return myList;
            }
        }

        /// <summary>
        /// ����ǰѡ�е�һ��Ԫ���򷵻ص�ǰѡ���Ԫ��,���򷵻ؿ�����
        /// </summary>
        /// <returns></returns>
        public ZYTextElement GetSelectElement()
        {
            if (intSelectLength == 1)
                //return (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                return (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            if (intSelectLength == -1)
                //return (ZYTextElement)myElements[intSelectStart - 1]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                return (ZYTextElement)HBFElements[intSelectStart - 1]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ 
            return null;
        }

        /// <summary>
        /// ���ѡ��������ı�����
        /// </summary>
        /// <returns></returns>
        public string GetSelectText()
        {
            return ZYTextElement.GetElementsText(this.GetSelectElements());
        }

        /// <summary>
        /// ʹ��ָ���ı��滻ѡ������
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns> 
        public bool ReplaceSelection(string strText)
        {
            if (strText == null || strText.Length == 0)
                return false;
            //this.DeleteSeleciton();

            //this.DeleteSelectedElements(); //add by myc 2014-08-07 ע��ԭ�򣺼��а����ʱ��������̶��ı�Ԫ�����ܽ���ԭλ��ճ������
            //this.InsertString(strText);


            if (this.DeleteSelectedElements()) //add by myc 2014-08-07 ���ԭ�򣺼��а����ʱ�����ȼ���Ƿ������ȷ��ɾ��ѡ������Ԫ�ز���
            {
                this.InsertString(strText);
            }


            bolModified = true;
            return true;
        }

        /// <summary>
        /// ����һ��Ԫ��
        /// </summary>
        /// <param name="myList"></param>
        public void InsertRangeElements(System.Collections.ArrayList myList)
        {
            //if (myElements == null || myElements.Count == 0 || myList == null || myList.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0 || myList == null || myList.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (IsLock(intSelectStart))
                return;

            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextContainer myParent = myElement.Parent;
            //������ZYTextBlock������Ԫ��
            if (myParent is ZYTextBlock)
            {
                myElement = myParent;
                myParent = myParent.Parent;
            }

            // ��ǰԪ�����ڵĸ���������������ַ�Ԫ��
            #region bwy
            //Ҫ�޸Ĵ˴����������EOFҪ�����µĶ��䣬����δ��
            ArrayList templist = new ArrayList();
            foreach (object o in myList)
            {
                if (o is ZYTextEOF)
                {
                    myParent.InsertRangeBefore(templist, myElement);
                    myParent.RefreshLine();

                    templist.Clear();
                    this.Document._InsertChar('\r');

                    //myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    myParent = myElement.Parent;
                    //������ZYTextBlock������Ԫ��
                    if (myParent is ZYTextBlock)
                    {
                        myElement = myParent;
                        myParent = myParent.Parent;
                    }
                }
                else
                {
                    templist.Add(o);
                }
            }
            myParent.InsertRangeBefore(templist, myElement);

            if ((myList[0] as ZYTextElement).Parent != null)//�ų�ֻ���ƻ��з������ edit by ld 2015-12-08
            {
                #region add by myc 2014-05-21 �ɸ�����Ŀ����ģ���滻ʱ�ĵ�Ԫ������Ӧ�߶ȵ���
                if ((myList[0] as ZYTextElement).Parent.Parent is TPTextCell) //��һ�μ�鵱ǰԪ�ص��游�������
                {
                    ((myList[0] as ZYTextElement).Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if ((myList[0] as ZYTextElement).Parent.Parent.Parent is TPTextCell) //�ڶ��μ�鵱ǰԪ�ص����游�������
                {
                    ((myList[0] as ZYTextElement).Parent.Parent.Parent as TPTextCell).AdjustHeight();
                }
                #endregion
            }
            myParent.RefreshLine();

            #endregion bwy
            //myParent.InsertRangeBefore(myList, myElement);//ԭ
            //myParent.RefreshLine();
            bolModified = true;
            // �ƶ���ǰ����㵽�������ַ�����ĩβ
            if (myDocument != null) myDocument.ContentChanged();
            this.AutoClearSelection = true;

            //this.MoveSelectStart(intSelectStart + myList.Count);
            #region bwy : ������һ���Ϊ����
            this.MoveSelectStart(myElement);
            #endregion bwy :
        }

        public void SetSubjectFormNull()
        {
            if (this.subjectForm != null)
            {
                this.subjectForm = null;
            }
        }


        /// <summary>
        /// �ڵ�ǰλ�ò���һ���ַ���
        /// </summary>
        /// <param name="strText">�ַ���</param>
        public void InsertString(string strText)
        {
            bool isNeedRefreshLine = true; //���������ߵ����������ʱ������Ҫˢ���У�����ʷ�ã�

            //if (myElements == null || myElements.Count == 0) return; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) return; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            if (IsLock(intSelectStart))
                return;

            this.Document.BeginUpdate();
            this.Document.BeginContentChangeLog();

            ZYTextChar NewChar = null;
            ZYTextChar defChar = null;

            //*********************Modified by wwj 2012-05-29 ����ץȡǰһ���ַ��Ĺ���**********************
            //ZYTextFlag defFlag = null;
            // ������ͼ�ҵ���ǰ�����һ���ַ����͵�����
            //for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
            //{
            //    if (myElements[iCount] is ZYTextChar)
            //    {
            //        defChar = (ZYTextChar)myElements[iCount];
            //        break;
            //    }
            //    //else if( myElements[iCount] is ZYTextFlag )
            //    //{
            //    //    defFlag = 	( ZYTextFlag ) myElements[iCount];
            //    //}
            //}
            defChar = GetPreChar();
            //*********************************************************************************************

            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextContainer myParent = myElement.Parent;

            //2019.8.6-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ�ı�¼���Ż������ݹ�����ҿ�Ԫ�ؽ����ж��Ƿ��Ƿ�¼�뵽��Ԫ����
            ZYTextContainer myParentLeft = new ZYTextContainer();
            if (intSelectStart > 0)
            {
                myParentLeft = ((ZYTextElement)HBFElements[intSelectStart - 1]).Parent;
            }

            if ((myParent is ZYMacro || myParent is ZYFormatString || myParent is ZYReplace || myParent is ZYDiag) && (myParent as ZYTextBlock).IsFocus)
            {
            }
            else if ((myParentLeft is ZYMacro || myParentLeft is ZYFormatString || myParentLeft is ZYReplace || myParentLeft is ZYDiag) && (myParentLeft as ZYTextBlock).IsFocus)
            {
                myParent = myParentLeft;
            }
            else if (myParentLeft is ZYSubject)
            {
                myParent = myParentLeft;
                if (!new string[] { "��ҽ���", "��ҽ���", "֤�����" }.Contains((myParent as ZYSubject).Name))
                {
                    if (strText == "��" || strText == "," || strText == "��")
                    {
                        if (subjectForm == null || subjectForm.DialogResult == DialogResult.Abort)
                        {
                            subjectForm = new SubjectForm(myParent as ZYSubject);
                        }

                        if (subjectForm.LoadZZ())
                        {
                            subjectForm.Show();
                            subjectForm.SetFocus();
                        }
                        else
                        {
                            subjectForm.Close();
                            subjectForm = null;
                        }
                    }

                }
            }
            else if (myParentLeft is ZYTextParagraph)
            {
                var app = myParentLeft as ZYTextParagraph;

                bool isFixedText = false;
                foreach (var item in app.ChildElements)
                {
                    isFixedText = item is ZYFixedText;

                    //�жϱ�ǩ�Ƿ�����������
                    if (isFixedText && (item as ZYFixedText).AssistDecision)
                    {
                        break;
                    }
                    else
                    {
                        isFixedText = false;
                    }
                }
                if (isFixedText)
                {
                    isNeedRefreshLine = false;

                    if (strText == "��" || strText == "," || strText == "��")
                    {
                        if (subjectForm == null || subjectForm.DialogResult == DialogResult.Abort)
                        {
                            subjectForm = new SubjectForm(myParent as ZYTextParagraph);
                        }

                        if (subjectForm.LoadZZ())
                        {
                            subjectForm.Show();
                            subjectForm.SetFocus();
                        }
                        else
                        {
                            subjectForm.Close();
                            subjectForm = null;
                        }
                    }
                }

            }


            else
            {

                //Add by wwj 2013-01-23
                //����ڽṹ��Ԫ��ǰճ�����ݵ�ʱ�򣬱�ճ����������ṹ��Ԫ�ص������ں�Ϊһ���Bug
                //�磺{a,b,{d,e,f}} -------���� a��bΪ�����ı��� d��e��f�ǽṹ��Ԫ�ص�����
                //���ʱ����b��d���м���������ı�c���������Ч��Ӧ���� {a,b,c,{d,e,f}} ������ {a,b,{c,d,e,f}}
                //ע�⣺ȷ����ǰԪ�����丸Ԫ���µĵ�һ����Ԫ��ʱ�Ž�����߼�
                if (myParent != null && !(myParent is ZYTextParagraph) && myParent.Parent is ZYTextParagraph && myParent.ChildElements.IndexOf(myElement) == 0)
                {
                    myElement = myParent;
                    myParent = myParent.Parent;
                }

            }
            //2019.8.12-hdf����Ӹ�ʽ���ַ�������У��
            if (myParent is ZYFormatString && (myParent as ZYTextBlock).IsFocus && (myParent as ZYFormatString).ChildCount + strText.Length > (myParent as ZYFormatString).Length)
            {
                this.SelectLength = 0;
                this.Document.EndContentChangeLog();
                this.Document.EndUpdate();
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("���ȳ���������ƣ�");
                return;
            }



            // �����ַ�������һϵ���ַ�Ԫ�ض���
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            //myElement.OwnerDocument.ContentChangeLog.CanLog = false;
            for (int iCount = 0; iCount < strText.Length; iCount++)
            {
                if (strText[iCount] == '\n')
                {
                    //myList.Add(new ZYTextParagraph());
                    myList.Add(new ZYTextLineEnd());
                }
                else if (strText[iCount] != '\r')
                {
                    NewChar = myElement.OwnerDocument.CreateChar(strText[iCount]);

                    #region add by myc 2014-07-17 ע��ԭ���°��������Կ�����Ҫ
                    //if (defChar != null)
                    //    defChar.Attributes.CopyTo(NewChar.Attributes);

                    ////�������һ���նδ�����ô��Ĭ�������СΪ׼ add by wwj 2012-05-29
                    //if (myElement is ZYTextEOF && myElement == myParent.FirstElement)
                    //{
                    //    NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, myElement.OwnerDocument.OwnerControl.GetDefaultFontSize());
                    //} 
                    #endregion

                    #region add by myc 2017-07-17 ���ԭ���°��������Կ���
                    NewChar.Attributes.SetValue(ZYTextConst.c_FontName, myDocument.FontPropertyManager.FontName);
                    NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, myDocument.FontPropertyManager.FontSize);
                    NewChar.Attributes.SetValue(ZYTextConst.c_FontBold, myDocument.FontPropertyManager.FontBold);
                    NewChar.Attributes.SetValue(ZYTextConst.c_FontItalic, myDocument.FontPropertyManager.FontItalic);
                    NewChar.Attributes.SetValue(ZYTextConst.c_FontUnderLine, myDocument.FontPropertyManager.FontUnderLine);
                    NewChar.Attributes.SetValue(ZYTextConst.c_ForeColor, ColorTranslator.FromHtml(ColorTranslator.ToHtml(myDocument.FontPropertyManager.ForeColor)));
                    #endregion

                    //else if( defFlag != null)
                    //{
                    //    NewChar.Attributes.SetValue(ZYTextConst.c_FontSize,defFlag.Attributes.GetFloat(ZYTextConst.c_FontSize));
                    //}
                    myList.Add(NewChar);
                }
            }

            //Add by wwj 2013-02-01 �Ƴ�ArrayListĩβ��ZYTextLineEndԪ��,��ֹ����Ӳ�س�����س����ӵ�����
            RemoveTheEndOFZYTextLineEnd(myList);

            //myElement.OwnerDocument.ContentChangeLog.CanLog = true;
            // ��ǰԪ�����ڵĸ���������������ַ�Ԫ��


            myParent.InsertRangeBefore(myList, myElement);


            if (myList.Count > 0)//�ų�ֻ���ƻ��з������ edit by ld 2015-12-08
            {
                #region add by myc 2014-03-18 �°������֮��Ԫ���ڲ�������ɾ��Ԫ��ʱ������Ӧ�߶ȵ���
                if ((myList[0] as ZYTextElement).Parent.Parent is TPTextCell)
                {
                    ((myList[0] as ZYTextElement).Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if ((myList[0] as ZYTextElement).Parent.Parent.Parent is TPTextCell)
                {
                    ((myList[0] as ZYTextElement).Parent.Parent.Parent as TPTextCell).AdjustHeight();
                }
                #endregion
            }


            if (isNeedRefreshLine)
            {
                myParent.RefreshLine();
            }

            bolModified = true;

            this.SelectLength = 0;
            this.Document.EndContentChangeLog();
            this.Document.EndUpdate();

            if (myParent is ZYSubject && (myParent as ZYSubject).Name == "����" && null != delChangeSubjectStr)
            {
                delChangeSubjectStr();
            }

            // �ƶ���ǰ����㵽�������ַ�����ĩβ
            if (myDocument != null) myDocument.ContentChanged();
            this.AutoClearSelection = true;
            this.MoveSelectStart(intSelectStart + myList.Count);//Modify by wwj 2013-02-01 �ƶ��������ȷ��λ��

        }

        /// <summary>
        /// �Ƴ�ArrayListĩβ��ZYTextLineEndԪ�� Add by wwj 2013-02-01
        /// </summary>
        /// <param name="list"></param>
        void RemoveTheEndOFZYTextLineEnd(ArrayList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[list.Count - 1] is ZYTextLineEnd)
                {
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// ��õ�ǰ�����ǰ�����һ���ַ�Ԫ��
        /// </summary>
        /// <returns>������ַ�Ԫ�أ���û�ҵ��򷵻ؿ�����</returns>
        public ZYTextChar GetPreChar()
        {
            //for (int iCount = (intSelectStart == 0 && myElements.Count > 1 ? 1 : intSelectStart - 1); iCount >= 0; iCount--)
            //    if (myElements[iCount] is ZYTextChar)
            //    {
            //        return (ZYTextChar)myElements[iCount];
            //        //break;
            //    } //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            for (int iCount = (intSelectStart == 0 && HBFElements.Count > 1 ? 1 : intSelectStart - 1); iCount >= 0; iCount--)
                if (HBFElements[iCount] is ZYTextChar)
                {
                    return (ZYTextChar)HBFElements[iCount];
                    //break;
                } //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            return null;
        }

        /// <summary>
        /// �ڵ�ǰλ�ò���һ���ַ���
        /// </summary>
        /// <param name="vChar">�ַ�</param>
        /// <returns>�������ַ�����</returns>
        public ZYTextChar InsertChar(char vChar)
        {
            //if (myElements == null || myElements.Count == 0) return null; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) return null; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            if (IsLock(intSelectStart))
            {
                return null;
            }

            if (intSelectStart < 0) intSelectStart = 0;
            //if (intSelectStart >= myElements.Count) intSelectStart = myElements.Count - 1; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (intSelectStart >= HBFElements.Count) intSelectStart = HBFElements.Count - 1; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

            ZYTextChar NewChar = null;
            // ������ͼ�ҵ���ǰ�����һ���ַ����͵�����
            ZYTextChar defChar = GetPreChar();
            //			
            //			for(int iCount = intSelectStart - 1 ; iCount >=0 ; iCount -- )
            //				if( myElements[iCount] is ZYTextChar )
            //				{
            //					defChar = ( ZYTextChar ) myElements[iCount];
            //					break;
            //				}
            ZYTextElement myElement = this.CurrentElement;// ( ZYTextElement ) myElements[intSelectStart];
            ZYTextContainer myParent = myElement.Parent;
            ZYTextContainer grandParent = myElement.Parent.Parent;

            bool bolSetParent = false;
            if ((myParent is ZYTextBlock && myElement == myParent.GetFirstElement()) || myParent.WholeElement)
            {
                bolSetParent = true;
            }

            #region 2019.8.6-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ�ı�¼���Ż������ݹ�����ҿ�Ԫ�ؽ����ж��Ƿ��Ƿ�¼�뵽��Ԫ����
            ZYTextContainer myParentLeft = new ZYTextContainer();
            if (intSelectStart > 0)
            {
                myParentLeft = ((ZYTextElement)HBFElements[intSelectStart - 1]).Parent;
            }
            if ((myParent is ZYMacro || myParent is ZYFormatString || myParent is ZYReplace || myParent is ZYDiag) && (myParent as ZYTextBlock).IsFocus)
            {
                bolSetParent = false;
            }
            else if ((myParentLeft is ZYMacro || myParentLeft is ZYFormatString || myParentLeft is ZYReplace || myParentLeft is ZYDiag) && (myParentLeft as ZYTextBlock).IsFocus)
            {
                bolSetParent = false;
                myParent = myParentLeft;
            }
            else if (myParentLeft is ZYSubject)
            {
                myParent = myParentLeft;

                if (!new string[] { "��ҽ���", "��ҽ���", "֤�����" }.Contains((myParent as ZYSubject).Name))
                {
                    if (vChar == '��' || vChar == ',' || vChar == '��')
                    {
                        if (subjectForm == null || subjectForm.DialogResult == DialogResult.Abort)
                        {
                            subjectForm = new SubjectForm(myParent as ZYSubject);
                        }

                        if (subjectForm.LoadZZ())
                        {
                            subjectForm.Show();
                            subjectForm.SetFocus();
                        }
                        else
                        {
                            subjectForm.Close();
                            subjectForm = null;
                        }
                    }
                }
            }
            else if (myParentLeft is ZYTextParagraph)
            {
                var app = myParentLeft as ZYTextParagraph;

                bool isFixedText = false;
                foreach (var item in app.ChildElements)
                {
                    isFixedText = item is ZYFixedText;

                    if (isFixedText && (item as ZYFixedText).AssistDecision)
                    {
                        break;
                    }
                    else
                    {
                        isFixedText = false;
                    }
                }
                if (isFixedText)
                {
                    if (vChar == '��' || vChar == ',' || vChar == '��')
                    {
                        if (subjectForm == null || subjectForm.DialogResult == DialogResult.Abort)
                        {
                            subjectForm = new SubjectForm(myParent as ZYTextParagraph);
                        }

                        if (subjectForm.LoadZZ())
                        {
                            subjectForm.Show();
                            subjectForm.SetFocus();
                        }
                        else
                        {
                            subjectForm.Close();
                            subjectForm = null;
                        }

                    }
                }

            }


            //2019.8.12-hdf����Ӹ�ʽ���ַ�������У��
            if (myParent is ZYFormatString && (myParent as ZYTextBlock).IsFocus && (myParent as ZYFormatString).ChildCount + 1 > (myParent as ZYFormatString).Length)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("���ȳ���������ƣ�");
                return null;
            }
            #endregion

            if (myElement.OwnerDocument.ContentChangeLog != null)
            {
                myElement.OwnerDocument.ContentChangeLog.CanLog = false;
            }
            NewChar = myElement.OwnerDocument.CreateChar(vChar);

            if (defChar != null)
            {
                //defChar.Attributes.CopyTo(NewChar.Attributes); //add by myc 2017-07-17 ע��ԭ���°��������Կ���

                //���̳����±�
                NewChar.Attributes.SetValue(ZYTextConst.c_Sup, false);
                NewChar.Attributes.SetValue(ZYTextConst.c_Sub, false);

                //NewChar.ForeColor = ColorTranslator.FromHtml(ColorTranslator.ToHtml(defChar.ForeColor)); //add by myc 2014-03-24 ҳü������������֮��ɫ���ø�����Ҫ
            }

            #region add by myc 2017-07-17 ע��ԭ���°��������Կ���
            NewChar.Attributes.SetValue(ZYTextConst.c_FontName, myDocument.FontPropertyManager.FontName);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, myDocument.FontPropertyManager.FontSize);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontBold, myDocument.FontPropertyManager.FontBold);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontItalic, myDocument.FontPropertyManager.FontItalic);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontUnderLine, myDocument.FontPropertyManager.FontUnderLine);
            NewChar.Attributes.SetValue(ZYTextConst.c_ForeColor, ColorTranslator.FromHtml(ColorTranslator.ToHtml(myDocument.FontPropertyManager.ForeColor)));
            #endregion

            NewChar.CreatorIndex = this.Document.SaveLogs.CurrentIndex;

            //**************************Modified by wwj 2012-05-29**********************************
            //#region bwy �������һ���նδ����������˻س����������С����ôӦ�������Ϊ׼
            //if (myElement is ZYTextEOF && myElement == myParent.FirstElement && (myElement as ZYTextEOF).FontSize != 0)
            //{
            //    NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, (myElement as ZYTextEOF).FontSize);
            //}
            //#endregion bwy

            #region �������һ���նδ�����ô��Ĭ�������СΪ׼
            //if (myElement is ZYTextEOF && myElement == myParent.FirstElement) //add by myc 2017-07-17 ע��ԭ���°��������Կ���
            //{
            //    NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, myElement.OwnerDocument.OwnerControl.GetDefaultFontSize());
            //}
            #endregion
            //**************************************************************************************

            //NewChar.UpdateAttrubute();



            //NewChar.Attributes.RemoveAttribute(ZYTextConst.c_FontBold);
            //NewChar.Attributes.RemoveAttribute(ZYTextConst.c_FontItalic);
            //NewChar.Attributes.RemoveAttribute(ZYTextConst.c_FontUnderLine);
            //NewChar.ForeColor = Color.Black;



            if (myElement.OwnerDocument.ContentChangeLog != null)
            {
                myElement.OwnerDocument.ContentChangeLog.CanLog = true;
            }

            if (bolSetParent)
            {
                grandParent.InsertBefore(NewChar, myParent);
            }
            else
            {

                myParent.InsertBefore(NewChar, myElement);


            }

            bolModified = true;


            #region add by myc 2014-03-18 �°������֮��Ԫ���ڲ�������ɾ��Ԫ��ʱ������Ӧ�߶ȵ���
            if (this.CurrentElement.Parent.Parent is TPTextCell)
            {
                (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
            }
            else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell)
            {
                (this.CurrentElement.Parent.Parent.Parent as TPTextCell).AdjustHeight();
            }



            //TPTextCell currCell = this.CurrentElement.Parent.Parent as TPTextCell;
            //if (currCell != null)
            //{
            //    currCell.AdjustHeight();
            //}
            #endregion


            if (myDocument != null)
            {
                myDocument.ContentChanged();
            }

            if (myParent is ZYSubject && (myParent as ZYSubject).Name == "����" && null != delChangeSubjectStr)
            {
                delChangeSubjectStr();
            }

            this.AutoClearSelection = true;
            // �ƶ���ǰ����㵽�������ַ�����ĩβ
            this.MoveSelectStart(intSelectStart + 1);



            return NewChar;
        }

        /// <summary>
        /// �ڵ�ǰλ�ò���һ��Ԫ��
        /// </summary>
        /// <param name="NewElement"></param>
        public void InsertElement(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) return null; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextContainer myParent = myElement.Parent;

            //2019.8.15-hdf���������߻��ұ��Ǻ�Ԫ�ء���ʽ���ַ�����������Ŀ�����ҽ�������˿�Ԫ�أ����Ҳ����Ԫ������س�
            //�����س�Ԫ�ز��뵽��Ԫ���ڲ�
            ZYTextElement eleLeft = new ZYTextElement();
            if (intSelectStart > 0)
            {
                eleLeft = HBFElements[intSelectStart - 1] as ZYTextElement;
            }
            if (((myElement.Parent is ZYMacro || myElement.Parent is ZYReplace || myElement.Parent is ZYFormatString || myElement.Parent is ZYDiag) && (myElement.Parent as ZYTextBlock).IsFocus && NewElement is ZYTextLineEnd))
            {
                //�������ұߵĿ�Ԫ���ڲ�����س�
            }
            else if ((eleLeft.Parent is ZYMacro || eleLeft.Parent is ZYReplace || eleLeft.Parent is ZYFormatString || eleLeft.Parent is ZYDiag) && (eleLeft.Parent as ZYTextBlock).IsFocus && NewElement is ZYTextLineEnd)
            {
                //��������ߵĿ�Ԫ���ڲ�����س�
                //��myParent���ɻ�ý���Ŀ�Ԫ�أ���myELement����null�����Ԫ����������س�
                myElement = null;
                myParent = eleLeft.Parent;
            }
            //������ZYTextBlock������Ԫ��
            else if (myParent is ZYTextBlock)
            {
                myElement = myParent;
                myParent = myParent.Parent;
            }


            if (myParent.InsertBefore(NewElement, myElement))
            {
                bolModified = true;



                #region add by myc 2014-03-18 �°������֮��Ԫ���ڲ�������ɾ��Ԫ��ʱ������Ӧ�߶ȵ���
                if (this.CurrentElement.Parent.Parent is TPTextCell)
                {
                    (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell)
                {
                    (this.CurrentElement.Parent.Parent.Parent as TPTextCell).AdjustHeight();
                }


                //TPTextCell currCell = this.CurrentElement.Parent.Parent as TPTextCell;
                //if (currCell != null)
                //{
                //    currCell.AdjustHeight();
                //}
                #endregion



                if (myDocument != null)
                {
                    myDocument.ContentChanged();
                }
                this.AutoClearSelection = true;
                this.MoveSelectStart(intSelectStart + 1);
            }
        }

        /// <summary>
        /// �س�ʱ����һ������
        /// </summary>
        /// <param name="NewElement">һ���µĿն���Ԫ��</param>
        public void InsertParagraph(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) return null; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            {
                return;
            }

            bool isContentChange = false;

            //��ǰԪ��(����Ϊһ��eof��)
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            if (myElement.Parent is ZYTextBlock)
            {
                myElement = myElement.Parent;
            }
            //��ǰԪ�������Ķ������

            ZYTextElement parent = myElement.Parent;
            while (!(parent is ZYTextParagraph))
            {
                parent = parent.Parent;
            }
            ZYTextParagraph Paraparent = parent as ZYTextParagraph;//myElement.Parent as ZYTextParagraph;

            //��ǰԪ������������������
            //ZYTextContainer divParent = myElement.Parent.Parent;
            ZYTextContainer divParent = Paraparent.Parent;

            if (myElement == Paraparent.LastElement)//��ǰԪ��Ϊ���������һ��Ԫ��
            {
                divParent.InsertAfter(NewElement, Paraparent);
                myElement = (NewElement as ZYTextParagraph).FirstElement;

                #region add by myc 2017-07-17 ע��ԭ���°��������Կ���
                myElement.Attributes.SetValue(ZYTextConst.c_FontName, myDocument.FontPropertyManager.FontName);
                myElement.Attributes.SetValue(ZYTextConst.c_FontSize, myDocument.FontPropertyManager.FontSize);
                myElement.Attributes.SetValue(ZYTextConst.c_FontBold, myDocument.FontPropertyManager.FontBold);
                myElement.Attributes.SetValue(ZYTextConst.c_FontItalic, myDocument.FontPropertyManager.FontItalic);
                myElement.Attributes.SetValue(ZYTextConst.c_FontUnderLine, myDocument.FontPropertyManager.FontUnderLine);
                myElement.Attributes.SetValue(ZYTextConst.c_ForeColor, ColorTranslator.FromHtml(ColorTranslator.ToHtml(myDocument.FontPropertyManager.ForeColor)));
                myElement.OwnerDocument = this.Document;
                myElement.RefreshSize();
                #endregion

                isContentChange = true;
            }
            else if (myElement == Paraparent.FirstElement)//��ǰԪ��Ϊ�����е�һ��Ԫ��
            {
                divParent.InsertBefore(NewElement, Paraparent);
                myElement = (Paraparent as ZYTextParagraph).FirstElement;

                #region add by myc 2017-07-17 ע��ԭ���°��������Կ���
                ZYTextElement myEle = (NewElement as ZYTextParagraph).FirstElement;
                myEle.Attributes.SetValue(ZYTextConst.c_FontName, myDocument.FontPropertyManager.FontName);
                myEle.Attributes.SetValue(ZYTextConst.c_FontSize, myDocument.FontPropertyManager.FontSize);
                myEle.Attributes.SetValue(ZYTextConst.c_FontBold, myDocument.FontPropertyManager.FontBold);
                myEle.Attributes.SetValue(ZYTextConst.c_FontItalic, myDocument.FontPropertyManager.FontItalic);
                myEle.Attributes.SetValue(ZYTextConst.c_FontUnderLine, myDocument.FontPropertyManager.FontUnderLine);
                myEle.Attributes.SetValue(ZYTextConst.c_ForeColor, ColorTranslator.FromHtml(ColorTranslator.ToHtml(myDocument.FontPropertyManager.ForeColor)));
                myEle.OwnerDocument = this.Document;
                myEle.RefreshSize();
                #endregion

                isContentChange = true;
            }
            else//��ǰԪ��Ϊ�����е�Ԫ��
            {
                int currentIndex = Paraparent.IndexOf(myElement);

                #region bwy
                ArrayList myList = new ArrayList();
                myList = Paraparent.ChildElements.GetRange(currentIndex, Paraparent.ChildElements.Count - currentIndex - 1);
                //copy ��ǰ��������Ԫ��
                System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
                myDoc.PreserveWhitespace = true;
                myDoc.AppendChild(myDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                ZYTextElement.ElementsToXML(myList, myDoc.DocumentElement);

                //ɾ�������е�ǰԪ�غ��Ԫ��

                Paraparent.RemoveChildRange(myList);

                ZYTextParagraph secondPara = new ZYTextParagraph();

                #region add by myc 2017-07-17 ע��ԭ���°��������Կ���
                //ZYTextChar myEle = HBFElements[currentIndex - 1] as ZYTextChar;
                //if (myEle != null)
                //{
                //    secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontName, myEle.FontName);
                //    secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontSize, myEle.FontSize);
                //    secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontBold, myEle.FontBold);
                //    secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontItalic, myEle.FontItalic);
                //    secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontUnderLine, myEle.FontUnderLine);
                //    secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_ForeColor, ColorTranslator.FromHtml(ColorTranslator.ToHtml(myEle.ForeColor)));
                //}
                secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontName, myDocument.FontPropertyManager.FontName);
                secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontSize, myDocument.FontPropertyManager.FontSize);
                secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontBold, myDocument.FontPropertyManager.FontBold);
                secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontItalic, myDocument.FontPropertyManager.FontItalic);
                secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_FontUnderLine, myDocument.FontPropertyManager.FontUnderLine);
                secondPara.LastElement.Attributes.SetValue(ZYTextConst.c_ForeColor, ColorTranslator.FromHtml(ColorTranslator.ToHtml(myDocument.FontPropertyManager.ForeColor)));
                secondPara.LastElement.OwnerDocument = this.Document;
                secondPara.LastElement.RefreshSize();
                #endregion

                divParent.InsertAfter(secondPara, Paraparent);

                //��ԭcopy�����뵽��һ��,past
                ArrayList newList = new ArrayList();

                this.Document.LoadElementsToList(myDoc.DocumentElement, newList);

                if (newList.Count > 0)
                {
                    foreach (ZYTextElement ele in newList)
                    {
                        ele.RefreshSize();
                    }
                    //this.InsertRangeElements(myList);
                    secondPara.InsertRangeBefore(newList, secondPara.LastElement);
                    myElement = newList[0] as ZYTextElement;

                }

                #endregion bwy

                //    ZYTextParagraph firstPara = new ZYTextParagraph();
                //    ArrayList firstChild = new ArrayList();
                //    for (int i = 0; i < currentIndex; i++)
                //    {
                //        (Paraparent.ChildElements[i] as ZYTextElement).Parent = firstPara;
                //        firstChild.Add(Paraparent.ChildElements[i]);
                //    }

                //    //firstChild.AddRange(Paraparent.ChildElements.GetRange(0, currentIndex));
                //    firstPara.ChildElements = firstChild;
                //    ZYTextEOF firstEof = new ZYTextEOF();
                //    firstEof.Parent = firstPara;
                //    firstPara.ChildElements.Add(firstEof);

                //    ZYTextParagraph secondPara = new ZYTextParagraph();
                //    ArrayList secondChild = new ArrayList();
                //    for (int i = currentIndex; i < Paraparent.ChildElements.Count - 1; i++)
                //    {
                //        (Paraparent.ChildElements[i] as ZYTextElement).Parent = secondPara;
                //        secondChild.Add(Paraparent.ChildElements[i]);
                //    }
                //    //secondChild.AddRange(Paraparent.ChildElements.GetRange(currentIndex, (Paraparent.ChildElements.Count - currentIndex-1)));
                //    secondPara.ChildElements = secondChild;
                //    ZYTextEOF secondEof = new ZYTextEOF();
                //    secondEof.Parent = secondPara;
                //    secondPara.ChildElements.Add(secondEof);

                //    ArrayList twoPara = new ArrayList();
                //    twoPara.Add(firstPara);
                //    twoPara.Add(secondPara);

                //    divParent.InsertRangeBefore(twoPara, Paraparent);
                //    divParent.RemoveChild(Paraparent);

                //    isContentChange = true;
                //}

            }
            isContentChange = true;
            if (isContentChange)
            {
                bolModified = true;



                #region add by myc 2014-03-18 �°������֮��Ԫ���ڲ�������ɾ��Ԫ��ʱ������Ӧ�߶ȵ���
                if (this.CurrentElement.Parent.Parent is TPTextCell)  //��һ�μ�鵱ǰԪ�ص��游�������
                {
                    (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //�ڶ��μ�鵱ǰԪ�ص����游�������
                {
                    (this.CurrentElement.Parent.Parent.Parent as TPTextCell).AdjustHeight();
                }



                //TPTextCell currCell = this.CurrentElement.Parent.Parent as TPTextCell;
                //if (currCell != null)
                //{
                //    currCell.AdjustHeight();
                //}


                //TPTextCell newCell = this.CurrentElement.Parent.Parent.Parent as TPTextCell;
                //if (newCell != null)
                //{
                //    newCell.AdjustHeight();
                //}
                #endregion




                if (myDocument != null)
                {
                    myDocument.ContentChanged();
                }
            }
            this.AutoClearSelection = true;

            if (myElement is ZYTextBlock)
            {
                myElement = (myElement as ZYTextBlock).FirstElement;
            }

            //this.MoveSelectStart(intSelectStart + 1);
            this.MoveSelectStart(myElement);


            myDocument.OwnerControl.ScrollViewToCaretVisibleDown(this.PreLine, this.CurrentLine); //add by myc 2014-08-08 ����ScrollViewToCaretVisibleDown����ʹ������س���ʱ���ɼ�

        }

        #region �|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�| �����ط��� �|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|

        /// <summary>
        /// �ڵ�ǰ����㴦����һ�����
        /// </summary>
        /// <param name="NewElement">��ʾһ�����Ԫ��</param>
        public void InsertTable(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

            //��õ�ǰԪ�����ڵĶ���
            ZYTextContainer secondaryParent = GetParentByElement(myElement, ZYTextConst.c_P) as ZYTextContainer;

            //ZYTextContainer rootParent = GetParentByElement(myElement, ZYTextConst.c_Div) as ZYTextDiv; add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ

            #region add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ�֮ҳü���������
            ZYTextContainer rootParent = null;
            //if (ZYTextDocument.CurrentEditingArea == 0)
            if (myDocument.EditingAreaFlag == 0)
            {
                rootParent = GetParentByElement(myElement, ZYTextConst.c_Header) as ZYDocumentHeader;
            }
            //else if (ZYTextDocument.CurrentEditingArea == 1)
            else if (myDocument.EditingAreaFlag == 1)
            {
                rootParent = GetParentByElement(myElement, ZYTextConst.c_Div) as ZYTextDiv;
            }
            //else if (ZYTextDocument.CurrentEditingArea == 2)
            else if (myDocument.EditingAreaFlag == 2)
            {
                rootParent = GetParentByElement(myElement, ZYTextConst.c_Footer) as ZYDocumentFooter;
            }
            #endregion

            //��Ԫ�������Ķ�������һ�����.
            rootParent.InsertAfter(NewElement, secondaryParent);

            //Ȼ���ٱ����ٲ���һ���µĶ���Ԫ��.
            //rootParent.InsertAfter(secondaryParent, new ZYTextParagraph());
            rootParent.InsertAfter(new ZYTextParagraph(), NewElement);

            bolModified = true;
            if (myDocument != null)
            {
                myDocument.ContentChanged();
            }
            this.AutoClearSelection = true;
        }

        /// <summary>
        /// mfb �ڲ���㴦����������
        /// </summary>
        /// <param name="RowNum">Ҫ���������</param>
        /// <param name="IsAfter">�Ƿ��ڲ��������</param>
        public void InsertRows(int RowNum, bool IsAfter)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;
            //��õ�ǰԪ��
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

            //��õ�ǰ���
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                //��õ�ǰ��
                TPTextRow currentRow = GetParentByElement(myElement, ZYTextConst.c_Row) as TPTextRow;


                //��õ�ǰ�����ڱ�������
                int rowIndex = currentTable.IndexOf(currentRow);

                //����ڵ�ǰ��ǰ����
                for (int k = 0; k < RowNum; k++)
                {
                    if (!IsAfter)
                    {
                        currentTable.InsertRow(rowIndex, currentRow);
                    }
                    else
                    {
                        //�����һ��֮�����
                        if (rowIndex == currentTable.AllRows.Count - 1)
                        {
                            currentTable.AddRow(currentRow);
                        }
                        else
                        {
                            currentTable.InsertRow(rowIndex + 1, currentRow);
                        }
                    }
                }
                //�������ñ�������е�Ԫ��ı߿���
                currentTable.SetEveryCellBorderWidth();
            }
            bolModified = true;
            if (myDocument != null)
            {
                myDocument.RefreshSize();
                myDocument.ContentChanged();
            }
            this.AutoClearSelection = true;
        }

        /// <summary>
        /// mfb �ڲ���㴦�������ɸ���
        /// </summary>
        /// <param name="columnNum">Ҫ���������</param>
        /// <param name="IsAfter">�Ƿ��ڲ����֮�����</param>
        public void InsertColumns(int columnNum, bool IsAfter)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;

            //��õ�ǰԪ��
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

            //��õ�ǰ���
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                //��õ�ǰ��
                TPTextRow currentRow = GetParentByElement(myElement, ZYTextConst.c_Row) as TPTextRow;

                //��õ�ǰ��Ԫ��
                TPTextCell currentCell = GetParentByElement(myElement, ZYTextConst.c_Cell) as TPTextCell;

                //��õ�ǰ�����ڱ�������
                int rowIndex = currentTable.IndexOf(currentRow);

                //��õ�ǰ��Ԫ�������е�����
                int cellIndex = currentRow.IndexOf(currentCell);

                for (int k = 0; k < columnNum; k++)
                {
                    //����ڵ�ǰ��ǰ����
                    if (!IsAfter)
                    {
                        currentTable.InsertColumns(cellIndex, currentCell);
                    }
                    else
                    {
                        //��������һ����Ԫ��
                        if (cellIndex == currentRow.Cells.Count - 1)
                        {
                            currentTable.AddColumns(currentCell);
                        }
                        else
                        {
                            currentTable.InsertColumns(cellIndex + 1, currentCell);
                        }
                    }
                }
                //�������ñ�������е�Ԫ��ı߿���
                currentTable.SetEveryCellBorderWidth();
            }
            bolModified = true;
            if (myDocument != null)
            {
                myDocument.RefreshSize();
                myDocument.ContentChanged();
            }
            this.AutoClearSelection = true;

        }

        /// <summary>
        /// mfb ɾ��ѡ��Ԫ�����ڵı��
        /// </summary>
        public void DeleteTable()
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;
            //�������ѡ���˶�������,���ж���Щ�����ǲ��Ƕ��ڱ���ڵ�.
            //�������ɾ�����,��������򲻽��ж���
            if (HasSelected())
            {
                int StartIndex = this.AbsSelectStart;
                int EndIndex = this.AbsSelectEnd;
                int iLen = (intSelectLength > 0 ? intSelectLength : 0 - intSelectLength);

                System.Collections.ArrayList myList = this.GetSelectElements();

                //�Ƿ�����ѡ���Ԫ�ض���table��
                bool isParentTable = true;

                foreach (ZYTextElement ele in myList)
                {
                    if (GetParentByElement(ele, ZYTextConst.c_Table) == null)
                    {
                        isParentTable = false;
                        break;
                    }
                }
                if (isParentTable)
                {
                    //���ѡ��Ԫ���б�ĵ�һ��Ԫ��
                    //ZYTextElement myElement = (ZYTextElement)myElements[StartIndex]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    ZYTextElement myElement = (ZYTextElement)HBFElements[StartIndex]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    ZYTextElement currentTable = GetParentByElement(myElement, ZYTextConst.c_Table);

                    ZYTextContainer bodyElement = GetRootElement(myElement) as ZYTextContainer;

                    bodyElement.RemoveChild(currentTable);
                }
            }
            else
            {
                //��õ�ǰԪ��
                //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

                //��õ�ǰ���
                TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;

                if (currentTable != null)
                {
                    ZYTextContainer bodyElement = GetRootElement(myElement) as ZYTextContainer;
                    bodyElement.RemoveChild(currentTable);
                }
            }

            bolModified = true;
            if (myDocument != null)
            {
                myDocument.RefreshSize();
                myDocument.ContentChanged();
            }
            this.AutoClearSelection = true;
        }

        /// <summary>
        /// mfb ɾ��ѡ��Ԫ�����ڵ���
        /// </summary>
        public void DeleteRows()
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;

            //��õ�ǰԪ��
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            //��õ�ǰ���
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                //��������ѡ���Ԫ�����������б�
                ArrayList rowList = new ArrayList();
                foreach (TPTextRow row in currentTable)
                {
                    foreach (TPTextCell cell in row)
                    {
                        if (true == cell.CanAccess)
                        {
                            rowList.Add(row);
                            break;
                        }
                    }
                }

                //��������ѡ�����,��ɾ��֮
                foreach (TPTextRow rowElement in rowList)
                {
                    currentTable.AllRows.Remove(rowElement);
                    currentTable.RemoveChild(rowElement);

                    #region 2021-04-13:��ɾ����ʱ���ںϲ���Ԫ��ʱ����ɾ��ѡ���еĲ��֣��ϲ��ĵ�Ԫ��������ø߶ȣ����ϲ��ĵ�Ԫ����лָ�
                    
                    foreach (var cell in rowElement)
                    {
                        if (cell.OwnerMergeCell != null)
                        {//����Ԫ���Ǳ��ϲ��ģ����������ϲ����Եĸ߶ȣ���ȥ��ǰɾ�����ӵĸ߶ȣ�
                            if (Document.CanContentChangeLog)
                            {
                                Document.ContentChangeLog.Container = cell.OwnerMergeCell;
                                Document.ContentChangeLog.LogProperty(cell.OwnerMergeCell, cell.OwnerMergeCell.GetType().GetProperty("ContentHeight"), cell.OwnerMergeCell.ContentHeight, cell.OwnerMergeCell.ContentHeight - cell.Height);
                            }
                            cell.OwnerMergeCell.ContentHeight -= cell.Height;

                            foreach (var c in cell.OwnerMergeCell.OwnerRow)
                            {
                                if (c == cell.OwnerMergeCell)
                                    continue;
                                //���㵥Ԫ�񴿴ⵥ�еĸ߶�
                                var ch = c.HasFlagCells.Count > 0 ? c.Height - c.HasFlagCells.Sum(a => a.Height) : c.Height;

                                //����������̫�ർ��ɾ���к�Ԫ��ĸ߶�С�����ݸ߶ȣ�������߶Ȳˢ��ͬ�е�������Ԫ��
                                var �߶Ȳ� = ch - (cell.OwnerMergeCell.Height - cell.OwnerMergeCell.HasFlagCells.Where(a => a != cell).Sum(a => a.Height));
                                if (�߶Ȳ� != 0)
                                {
                                    if (Document.CanContentChangeLog)
                                    {
                                        Document.ContentChangeLog.Container = c;
                                        Document.ContentChangeLog.LogProperty(c, c.GetType().GetProperty("ContentHeight"), c.ContentHeight, c.ContentHeight - �߶Ȳ�);
                                    }
                                    c.ContentHeight -= �߶Ȳ�;
                                }
                            }



                            if (Document.CanContentChangeLog)
                            {
                                Document.ContentChangeLog.Container = cell;
                                Document.ContentChangeLog.LogProperty(cell, cell.GetType().GetProperty("OwnerMergeCell"), cell.OwnerMergeCell, null);
                            }
                            cell.OwnerMergeCell = null;
                        }

                        if (cell.HasFlagCells != null && cell.HasFlagCells.Count > 0)
                        {//����Ԫ���Ǻϲ���Ԫ����ɾ�����ӣ����ָ����ϲ��ĸ���
                            cell.HasFlagCells.ForEach(c =>
                            {
                                if (c.ChildElements.Count == 0)
                                {
                                    var p = new ZYTextParagraph();
                                    c.AppendChild(p);
                                    if (Document.CanContentChangeLog)
                                    {
                                        Document.ContentChangeLog.Container = c;
                                        Document.ContentChangeLog.LogInsert(0, p);
                                    }
                                }
                                if (Document.CanContentChangeLog)
                                {
                                    Document.ContentChangeLog.Container = c;
                                    Document.ContentChangeLog.LogProperty(c, c.GetType().GetProperty("OwnerMergeCell"), c.OwnerMergeCell, null);
                                }
                                c.OwnerMergeCell = null;
                            });

                        }
                    }


                    #endregion

                }

                currentTable.SetEveryCellBorderWidth();
            }

            bolModified = true;
            if (myDocument != null)
            {
                myDocument.RefreshSize();
                myDocument.ContentChanged();
            }
            this.AutoClearSelection = true;
        }

        /// <summary>
        /// mfb ɾ��ѡ��Ԫ�����ڵ���
        /// </summary>
        public void DeleteColumns()
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;

            //��õ�ǰԪ��
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            //��õ�ǰ���
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                bool isFind = false;
                List<int> needDelCol = new List<int>();
                foreach (TPTextRow row in currentTable)
                {
                    foreach (TPTextCell cell in row)
                    {
                        if (true == cell.CanAccess)
                        {
                            isFind = true;
                            needDelCol.Add(row.IndexOf(cell));
                        }
                    }
                    if (isFind)
                    {
                        goto DeleteColumn;
                    }
                }
            DeleteColumn:
                foreach (int column in needDelCol)
                {
                    //TODO: ���ﻹ��Ҫ����һ��.
                    //��ΪҪɾ�����ж��ǽ����ŵ�,ɾ�����һ����. ������е�����
                    //��֮Ҳ��仯(�Զ���1),����ʼ���õ�һ���к�Ӧ������ȷ��.
                    //������Ȼ��ʱ�ﵽ,���Ǹо����ǻ���,�߼����Ͻ�.
                    currentTable.DeleteColumn(needDelCol[0]);
                }
                currentTable.SetEveryCellBorderWidth();
            }
            bolModified = true;
            if (myDocument != null)
            {
                myDocument.RefreshSize();
                myDocument.ContentChanged();
            }
            this.AutoClearSelection = true;
        }

        /// <summary>
        /// mfb �жϵ�ǰԪ��(������)�Ƿ���һ��cell��
        /// </summary>
        /// <returns></returns>
        public bool IsParaInCell(ZYTextElement CurrentElement)
        {
            //if (CurrentElement.GetXMLName() == ZYTextConst.c_Div) //add by myc 2014-07-10 ע��ԭ�������жϲ������°�ҳü���°�ҳ��
            //{
            //    return false;
            //}

            #region add by myc 2014-07-10 ���ԭ�򣺼����°�ҳü���°�ҳ��
            //if (ZYTextDocument.CurrentEditingArea == 0) //ҳü
            if (myDocument.EditingAreaFlag == 0) //ҳü
            {
                if (CurrentElement.GetXMLName() == ZYTextConst.c_Header)
                {
                    return false;
                }
            }
            //else if (ZYTextDocument.CurrentEditingArea == 1) //����
            else if (myDocument.EditingAreaFlag == 1) //����
            {
                if (CurrentElement.GetXMLName() == ZYTextConst.c_Div)
                {
                    return false;
                }
            }
            //else if (ZYTextDocument.CurrentEditingArea == 2) //ҳ��
            else if (myDocument.EditingAreaFlag == 2) //ҳ��
            {
                if (CurrentElement.GetXMLName() == ZYTextConst.c_Footer)
                {
                    return false;
                }
            }
            #endregion

            if (CurrentElement.Parent.GetXMLName() == ZYTextConst.c_Cell)
            {
                return true;
            }
            return IsParaInCell(CurrentElement.Parent);
        }

        /// <summary>
        /// mfb ��ȡ��ǰԪ�������ĸ���Ԫ��
        /// </summary>
        /// <param name="currentElement">��ǰԪ��</param>
        /// <param name="findName">Ҫ�ҵĸ���Ԫ�ص�xmlName</param>
        /// <returns></returns>
        public ZYTextElement GetParentByElement(ZYTextElement currentElement, string findName)
        {
            if (currentElement == null)
            {
                return null;
            }
            if (currentElement.GetXMLName() == findName)
            {
                return currentElement;
            }
            return GetParentByElement(currentElement.Parent, findName);
        }


        #endregion �|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�| end �����ز��뷽�� end �|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|�|


        /// <summary>
        ///  mfb ���Ҷ���bodyԪ��
        /// </summary>
        /// <param name="CurrentElement">The current element.</param>
        /// <returns></returns>
        public ZYTextElement GetRootElement(ZYTextElement CurrentElement)
        {
            if (CurrentElement.Parent != null)
            {
                return GetRootElement(CurrentElement.Parent);
            }
            return CurrentElement;
        }


        /// <summary>
        /// mfb ��õ�ǰԪ�����������������Ԫ��
        /// </summary>
        /// <param name="CurrentElement">The current element.</param>
        /// <returns></returns>
        public ZYTextElement GetSecondaryElement(ZYTextElement CurrentElement)
        {
            if (CurrentElement.Parent.Parent.GetXMLName() != "div")
            {
                return GetRootElement(CurrentElement.Parent);
            }
            return CurrentElement.Parent;
        }



        /// <summary>
        /// ����ǩ��
        /// </summary>
        /// <param name="NewElement"></param>
        public void InsertLock(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextContainer myParent = myElement.Parent;
            if (this.CurrentLine.Elements.Count > 1)
            {
                ZYTextParagraph myP = new ZYTextParagraph();
                myP.OwnerDocument = this.myDocument;
                this.InsertElement(myP);
            }
            //int i = 0;
            this.InsertString("                             ");
            if (myParent.InsertBefore(NewElement, myElement))
            {
                //myParent.RefreshLineFast( myParent.IndexOf( NewElement)); 
                bolModified = true;
                if (myDocument != null)
                {
                    myDocument.ContentChanged();
                }
                this.AutoClearSelection = true;
                //this.myDocument.SetAlign(ParagraphAlignConst.Right);

                this.MoveSelectStart(intSelectStart + 1);
            }
        }

        /// <summary>
        /// ɾ��ѡ�������Ԫ��
        /// </summary>
        /// <param name="flag">ɾ����ʶ��true ȫ��ɾ����false �̶��ı���ɾ��</param>
        public void DeleteSeleciton(bool flag)
        {
            this.Document.DeleteFlag = flag;
            //DeleteSeleciton();
            DeleteSelectedElements();
            this.Document.DeleteFlag = false;
        }
        /// <summary>
        /// ɾ��ѡ�������Ԫ��  
        /// </summary>
        public bool DeleteSeleciton()//Modify by wwj 2013-02-01 ���ӷ���ֵ
        {
            //һ��Ҫ����Undo/redo �ļ�����������
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ 
                return false;
            if (IsLock(intSelectStart))
                return false;

            ArrayList alp = this.GetSelectParagraph();

            //���ԵĿ�ʼ�����λ�ã�һ����ǰС���

            int StartIndex = this.AbsSelectStart;
            int EndIndex = this.AbsSelectEnd;

            int iLen = (intSelectLength > 0 ? intSelectLength : 0 - intSelectLength);
            bool bolChanged = false;

            ///ѡ����ַ��б�
            System.Collections.ArrayList mySelList = this.GetSelectElements();
            //ɾ���б�
            System.Collections.ArrayList myRemoveList = new System.Collections.ArrayList();
            //ɾ��������Ԫ���б�
            System.Collections.ArrayList myRealRemoveList = new System.Collections.ArrayList();

            myRealRemoveList = this.Document.GetRealElements(mySelList);

            int intDelete = 0;
            foreach (ZYTextElement ele in myRealRemoveList)
            {
                intDelete = myDocument.isDeleteElement(ele);
            }
            if (intDelete == 0)
            {
                //myRealRemoveList = this.Document.GetRealElements(mySelList);
                if (!this.Document.DeleteFlag)
                {
                    //if (this.Document.Info.DocumentModel != DocumentModel.Design)
                    //{
                    foreach (ZYTextElement ele in mySelList)
                    {
                        //if (ele.Parent is ZYFixedText || ele.Parent is ZYText)
                        //{
                        //    MessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return false;
                        //}
                        ////Add By wwj 2012-03-30 �ж϶�ZYButton��ɾ������
                        //if (ele is ZYButton && !((ZYButton)ele).CanDelete)
                        //{
                        //    MessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return false;
                        //}
                        ////Add By wwj 2013-08-01 �ж϶�ZYFlag��ɾ������
                        //if (ele is ZYFlag && !((ZYFlag)ele).CanDelete)
                        //{
                        //    MessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return false;
                        //}
                        bool canDelete = CanDeleteElement(ele);
                        if (!canDelete) return false;
                    }
                    //}
                }

                #region ��ȡ��ǰ��ѡ�еı��,��ѡ�б��������Ǵӱ��ͷѡ�����β Add by wwj 2013-01-21
                Dictionary<ZYTextElement, TPTextTable> selectionTableDict = new Dictionary<ZYTextElement, TPTextTable>();
                foreach (ZYTextElement ele in mySelList)
                {
                    ZYTextElement element = GetParentByElement(ele, ZYTextConst.c_Table);
                    if (element != null)
                    {
                        TPTextTable tb = element as TPTextTable;
                        if (tb != null && !selectionTableDict.ContainsValue(tb))
                        {
                            ZYTextElement lastElement = tb.GetLastElement();
                            if (mySelList.Contains(lastElement))
                            {
                                selectionTableDict.Add(ele, tb);
                            }
                        }
                    }
                }
                #endregion

                for (int i = 0; i < alp.Count; i++)
                {
                    ZYTextParagraph p = alp[i] as ZYTextParagraph;

                    int pIndexStart = p.FirstElement.Index;

                    if (p.FirstElement is ZYTextBlock)
                    {
                        pIndexStart = (p.FirstElement as ZYTextBlock).FirstElement.Index;
                    }

                    //p.LastElement ��ԶӦ�� EOF 
                    int pIndexEnd = p.LastElement.Index;

                    if (StartIndex <= pIndexStart && pIndexEnd <= EndIndex)
                    {
                        //���Ҫɾ���Ķ����ڵ�Ԫ���ڣ�����ɾ�����еĶ���,ÿ����Ԫ�������ٱ���һ���س����������ٱ���һ������ Add By wwj 2012-04-24 �����Ԫ������ɾ����Bug
                        ZYTextElement textElement = this.GetParentByElement(p, ZYTextConst.c_Cell);
                        if (textElement != null)
                        {
                            if (((ZYTextContainer)textElement).ChildCount > 1)
                            {
                                //����ɾ��
                                p.Parent.RemoveChild(p);
                                //p.Parent.RefreshLine(); 
                                StartIndex += p.ChildCount;
                            }
                            else
                            {
                                //ɾ��ѡ�񲿷�Ԫ��
                                myRemoveList = Elements.GetRange(StartIndex, EndIndex - StartIndex);
                                //ת��Ϊ����Ԫ��
                                myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                                p.RemoveChildRange(myRealRemoveList);
                                //p.RefreshLine(); //add by myc 2014-05-26 ע��ԭ��ɾ��ѡ������Ԫ��ʱ�ĵ�Ԫ������Ӧ�߶ȵ���
                            }
                        }
                        else
                        {
                            //Add by wwj 2013-02-01 ���Ӷ���ɾ��ǰ���ж�
                            //������ճ������֮ǰ�����ѡ�е����ݣ������ǰΪ��������ɾ������
                            //���Ӵ��ж�Ϊ�˷�ֹ������ճ�����ݺ���ֳ��е����
                            if (StartIndex != EndIndex)
                            {
                                //����ɾ��
                                p.Parent.RemoveChild(p);
                                //p.Parent.RefreshLine(); //add by myc 2014-05-26 ע��ԭ��ɾ��ѡ������Ԫ��ʱ�ĵ�Ԫ������Ӧ�߶ȵ���
                            }
                        }
                    }
                    //ѡ���ڶ��м�
                    else if (pIndexStart <= StartIndex && EndIndex <= pIndexEnd)
                    {
                        //ɾ��ѡ�񲿷�Ԫ��
                        myRemoveList = Elements.GetRange(StartIndex, EndIndex - StartIndex);
                        //ת��Ϊ����Ԫ��
                        myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                        p.RemoveChildRange(myRealRemoveList);
                        //p.RefreshLine(); //add by myc 2014-05-26 ע��ԭ��ɾ��ѡ������Ԫ��ʱ�ĵ�Ԫ������Ӧ�߶ȵ���
                    }

                    //�ǵ�һ����ѡ��� 
                    else if (StartIndex > pIndexStart)
                    {
                        //ɾ��ѡ�񲿷�Ԫ��
                        myRemoveList = Elements.GetRange(StartIndex, p.LastElement.Index - StartIndex);
                        //ת��Ϊ����Ԫ��
                        myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                        p.RemoveChildRange(myRealRemoveList);
                        //p.RefreshLine(); //add by myc 2014-05-26 ע��ԭ��ɾ��ѡ������Ԫ��ʱ�ĵ�Ԫ������Ӧ�߶ȵ���
                    }
                    //�����һ����ѡ���
                    else if (pIndexEnd > EndIndex)
                    {
                        myRemoveList = Elements.GetRange(pIndexStart, EndIndex - pIndexStart);
                        myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                        p.RemoveChildRange(myRealRemoveList);
                        //p.RefreshLine(); //add by myc 2014-05-26 ע��ԭ��ɾ��ѡ������Ԫ��ʱ�ĵ�Ԫ������Ӧ�߶ȵ���
                    }

                }

                //��ԭStartIndex������ֵ Add By wwj 2012-04-24
                StartIndex = this.AbsSelectStart;

                #region add by myc 2014-05-26 ע��ԭ�򣺴˶μ�����Ӧ�÷���ɾ�����֮��ȷ��ѡ���ĵ����б��ֱ�Ӱ���Enter��ʱ�������쳣
                ////����ĵ���һ���ζ�û���ˣ���Ҫnewһ���¶Σ������ĵ��У������޷�����
                //if (this.Document.RootDocumentElement.ChildCount == 0)
                //{
                //    //MessageBox.Show("һ���նζ�û���ˣ��������һ��");
                //    ZYTextParagraph myP = new ZYTextParagraph();
                //    myP.OwnerDocument = this.Document;
                //    this.InsertParagraph(myP);
                //} 
                #endregion

                #region ɾ��ѡ�еı�� Add by wwj 2013-01-21
                if (selectionTableDict.Count > 0)
                {
                    foreach (KeyValuePair<ZYTextElement, TPTextTable> pair in selectionTableDict)
                    {
                        ZYTextContainer bodyElement = GetRootElement(pair.Key) as ZYTextContainer;
                        bodyElement.RemoveChild(pair.Value);
                    }
                }
                #endregion

                #region add by myc 2014-05-26 ע��ԭ�򣺴˶μ�����Ӧ�÷���ɾ�����֮��ȷ��ѡ���ĵ����б��ֱ�Ӱ���Enter��ʱ�������쳣
                //����ĵ���һ���ζ�û���ˣ���Ҫnewһ���¶Σ������ĵ��У������޷�����
                if (this.Document.RootDocumentElement.ChildCount == 0)
                {
                    ZYTextParagraph myP = new ZYTextParagraph();
                    myP.OwnerDocument = this.Document;
                    this.InsertParagraph(myP);
                }
                #endregion
            }
            bolChanged = true;
            if (bolChanged)
            {
                bolModified = true;
                FixSelection();

                #region add by myc 2014-03-18 �°������֮��Ԫ���ڲ�������ɾ��Ԫ��ʱ������Ӧ�߶ȵ���
                if (this.CurrentElement.Parent.Parent is TPTextCell)  //��һ�μ�鵱ǰԪ�ص��游�������
                {
                    (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //�ڶ��μ�鵱ǰԪ�ص����游�������
                {
                    (this.CurrentElement.Parent.Parent.Parent as TPTextCell).AdjustHeight();
                }

                //TPTextCell currCell = this.CurrentElement.Parent.Parent as TPTextCell;
                //if (currCell != null)
                //{
                //    currCell.AdjustHeight();
                //}
                #endregion

                if (myDocument != null)
                    myDocument.ContentChanged();
                this.SetSelection(StartIndex, 0);
                FixSelection();
            }
            #region bwy : ����ɾ����ĩβ�ı���������»��߻��ϻ��ߣ�ˢ���������
            this.Document.OwnerControl.Invalidate();
            #endregion bwy :

            return true;
        }

        #region add by myc 2014-07-03 ע��ԭ���°�ҳü���ڸİ���Ҫ
        ///// <summary>
        ///// ���ѡ����������,�����ݴ������޸�֮
        ///// </summary>
        //private void FixSelection()
        //{
        //    if (intSelectStart >= myElements.Count)
        //        intSelectStart = myElements.Count - 1;
        //    if (intSelectStart < 0)
        //        intSelectStart = 0;
        //    if (intSelectLength > 0 && (intSelectStart + intSelectLength > myElements.Count))
        //        intSelectLength = 0;
        //    if (intSelectLength < 0 && (intSelectStart + intSelectLength < 0))
        //        intSelectLength = 0;
        //} 
        #endregion

        #region add by myc 2014-08-06 ע��ԭ���ع�Deleteɾ��Ԫ�ز���������Ҫ
        ///// <summary>
        ///// ɾ����ǰԪ��,��������0:ȷ��ɾ��Ԫ�� 1:��ɾ����Ԫ�� 2:�Ը�Ԫ�ؽ����߼�ɾ��
        ///// </summary>
        ///// <param name="flag">���ݴ˲�������ɾ���̶�Ԫ��ʱ���Ƿ���Ҫ������ʾ</param>
        ///// <returns>�������</returns>
        //public int DeleteCurrentElement(params object[] flag)
        //{
        //    //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //    if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ 
        //        return 1;
        //    if (IsLock(intSelectStart)) return 1;

        //    if (this.CheckSelectStart())
        //    {
        //        ZYTextElement myElement = this.CurrentElement;
        //        //����ǹ̶��ı���ɾ��
        //        //����ǹ̶��ı������ڱ༭״����ɾ��
        //        if ((myElement.Parent is ZYFixedText || myElement.Parent is ZYText) && this.Document.Info.DocumentModel != DocumentModel.Design)
        //        {
        //            if (flag.Length > 0)
        //            {
        //                MessageBox.Show("ɾ����Χ�а����̶����ݣ�����ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //            return 1;
        //        }

        //        #region Add By wwj 2013-08-01 ����ڲ���ɾ����Ԫ��ZYButton��ZYFlag֮ǰ��λ���󣬰���Delete����Ԫ�ر�ɾ��������
        //        if (myElement is ZYButton)
        //        {
        //            if (!((ZYButton)myElement).CanDelete)
        //            {
        //                MessageBox.Show("ɾ����Χ�а����̶����ݣ�����ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                return 1;
        //            }
        //        }
        //        else if (myElement is ZYFlag)
        //        {
        //            if (!((ZYFlag)myElement).CanDelete)
        //            {
        //                MessageBox.Show("ɾ����Χ�а����̶����ݣ�����ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                return 1;
        //            }
        //        }
        //        #endregion

        //        // ����ǰԪ�ز������һ��Ԫ����ɾ��֮
        //        //if (myElement != myElements[myElements.Count - 1]) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //        if (myElement != HBFElements[HBFElements.Count - 1]) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        //        {

        //            //ZYTextElement afterElement = (ZYTextElement)myElements[intSelectStart + 1]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //            ZYTextElement afterElement = (ZYTextElement)HBFElements[intSelectStart + 1]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

        //            ZYTextParagraph parentPara = myElement.Parent as ZYTextParagraph;

        //            ZYTextContainer parentDiv = myElement.Parent.Parent;
        //            #region bwy :
        //            if (myElement.Parent is ZYTextBlock)
        //            {
        //                //if (myElements.Count > intSelectStart + myElement.Parent.ChildCount)//Add by wwj 2013-05-07 �����ɾ���ĵ�ĩβ�Ľṹ��Ԫ�س��������
        //                //{
        //                //    afterElement = (ZYTextElement)myElements[intSelectStart + myElement.Parent.ChildCount];
        //                //} //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ

        //                if (HBFElements.Count > intSelectStart + myElement.Parent.ChildCount) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        //                {
        //                    afterElement = (ZYTextElement)HBFElements[intSelectStart + myElement.Parent.ChildCount];
        //                }

        //                parentPara = myElement.Parent.Parent as ZYTextParagraph;
        //                parentDiv = myElement.Parent.Parent.Parent;
        //            }
        //            #endregion bwy :

        //            int intDelete = myDocument.isDeleteElement(myElement);
        //            if (intDelete == 0)
        //            {
        //                //bool isEndOfLine = false;

        //                //���������ڴ�Ϊһ���ն���,��ɾ���������
        //                if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF)
        //                //if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF && !IsParaInCell(myElement))
        //                {
        //                    #region add by myc 2014-05-09 ��Ԫ���ڵ�Deleteɾ���س�������
        //                    if (IsParaInCell(myElement))
        //                    {
        //                        if (parentDiv.IndexOf(parentPara) == parentDiv.ChildCount - 1)
        //                        {
        //                            return 1;
        //                        }
        //                    }
        //                    #endregion

        //                    //��ȡ��ǰ�������һ������.
        //                    object tmpEle = parentDiv.ChildElements[parentDiv.ChildElements.IndexOf(parentPara) + 1];
        //                    //�������table,����������,����ִ���κζ���.
        //                    if (!(tmpEle is TPTextTable))
        //                    {
        //                        myElement = (tmpEle as ZYTextParagraph).FirstElement;
        //                        parentDiv.RemoveChild(parentPara);
        //                        Document.RefreshElements();
        //                    }

        //                }
        //                //�������ڶ�������Ԫ�ش�,�Ҷ��䲻Ϊ��,��ϲ�������䵽�ϸ�������.
        //                else if (myElement == parentPara.LastElement && parentPara.ChildCount > 1)
        //                {
        //                    int currentParaIndex = parentDiv.IndexOf(parentPara);

        //                    //���������еĵ�һ��Ԫ��
        //                    if (currentParaIndex < parentDiv.ChildCount - 1)
        //                    {
        //                        for (int i = 0; i < parentPara.ChildCount - 1; i++)
        //                        {
        //                            #region ����ڶ����ĩβ����Delete��ʱ�����ֽṹ��Ԫ�غϲ������ 2013-05-17
        //                            //Add by wwj 2013-05-17
        //                            ZYTextElement paragraph = null;
        //                            ZYTextElement afterElementNew = null;
        //                            GetParagraph(afterElement, out paragraph, out afterElementNew);
        //                            (parentPara.ChildElements[i] as ZYTextElement).Parent = (ZYTextParagraph)paragraph;
        //                            ((ZYTextParagraph)paragraph).InsertBefore((parentPara.ChildElements[i] as ZYTextElement), afterElementNew);

        //                            //Delete by wwj 2013-05-17
        //                            //(parentPara.ChildElements[i] as ZYTextElement).Parent = afterElement.Parent;
        //                            //afterElement.Parent.InsertBefore((parentPara.ChildElements[i] as ZYTextElement), afterElement); 
        //                            #endregion

        //                            //(afterElement.Parent.ChildElements[i] as ZYTextElement).Parent = parentPara;
        //                            //parentPara.InsertBefore((afterElement.Parent.ChildElements[i] as ZYTextElement), parentPara.LastElement);
        //                        }
        //                        parentDiv.RemoveChild(parentPara);
        //                    }
        //                }
        //                else if (myElement != parentPara.LastElement && !(myElement is ZYTextContainer))
        //                {
        //                    bool bolSetParent = false;
        //                    if (myElement.Parent.WholeElement)
        //                    {
        //                        bolSetParent = true;
        //                    }
        //                    if (myElement.Parent is ZYTextBlock && myElement == myElement.Parent.GetLastElement())
        //                    {
        //                        bolSetParent = true;
        //                    }
        //                    if (bolSetParent)
        //                    {
        //                        myElement = myElement.Parent;
        //                    }
        //                    parentPara.RemoveChild(myElement);
        //                }

        //                #region bwy :
        //                if (myElement != parentPara.LastElement && myElement.Parent is ZYTextBlock)
        //                {
        //                    parentPara.RemoveChild(myElement.Parent);
        //                }
        //                #endregion bwy :




        //                #region add by myc 2014-03-18 �°������֮��Ԫ���ڲ�������ɾ��Ԫ��ʱ������Ӧ�߶ȵ���
        //                if (this.CurrentElement.Parent.Parent is TPTextCell)  //��һ�μ�鵱ǰԪ�ص��游�������
        //                {
        //                    (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
        //                }
        //                else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //�ڶ��μ�鵱ǰԪ�ص����游�������
        //                {
        //                    (this.CurrentElement.Parent.Parent.Parent as TPTextCell).AdjustHeight();
        //                }

        //                //TPTextCell currCell = this.CurrentElement.Parent.Parent as TPTextCell;
        //                //if (currCell != null)
        //                //{
        //                //    currCell.AdjustHeight();
        //                //}
        //                #endregion



        //                bolModified = true;
        //                myDocument.ContentChanged();

        //                this.SetSelection(intSelectStart, 0);
        //            }
        //            else if (intDelete == 2)
        //            {
        //                this.SetSelection(intSelectStart + 1, 0);
        //            }
        //            return intDelete;
        //        }
        //    }
        //    return 1;
        //} 
        #endregion

        /// <summary>
        /// Add by wwj 2013-05-17
        /// ��ȡԪ��element���ڵĶ���paragraph���Լ�Ԫ��element�ڶ���paragraph�е�Ԫ��textElement
        /// ��Ԫ��elementΪ�����ı�ʱ��element == textElement
        /// ��Ԫ��elementΪ�ṹ��Ԫ���е�ĳ������ʱ��element != textElement
        /// </summary>
        /// <param name="element"></param>
        /// <param name="paragraph"></param>
        /// <param name="textElement"></param>
        public void GetParagraph(ZYTextElement element, out ZYTextElement paragraph, out ZYTextElement textElement)
        {
            paragraph = element.Parent;
            textElement = element;
            if (!(paragraph is ZYTextParagraph))
            {
                paragraph = element.Parent.Parent;
                textElement = element.Parent;
            }
        }

        #region add by myc 2014-08-06 ע��ԭ���ع�Backspaceɾ��Ԫ�ز���������Ҫ
        ///// <summary>
        ///// ɾ����ǰԪ��ǰһ��Ԫ��,��������0:ȷ��ɾ��Ԫ�� 1:��ɾ����Ԫ�� 2:�Ը�Ԫ�ؽ����߼�ɾ��
        ///// </summary>
        ///// <returns>�������</returns>
        //public int DeletePreElement(params object[] flag)
        //{
        //    //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //    if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        //    {
        //        return 1;
        //    }
        //    if (IsLock(intSelectStart - 1))
        //    {
        //        return 1;
        //    }
        //    //�������Ƭ�ĵ����м�,�����ٿ�ʼ,Ҳ����ĩβ.
        //    //if (intSelectStart > 0 && intSelectStart < myElements.Count) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //    if (intSelectStart > 0 && intSelectStart < HBFElements.Count) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        //    {
        //        //�ж��Ƿ������ĵ��Ľ�β,�ж��������Ϊ.
        //        //��������һ��Ԫ��,��ô��ɾ�����Ԫ��ʱmyElements.Count��ֵ��仯.
        //        //��֮intSelectStartҲ����ű�,�����������������.
        //        //bool isLastElement = (intSelectStart == (myElements.Count - 1)) ? true : false; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //        bool isLastElement = (intSelectStart == (HBFElements.Count - 1)) ? true : false; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

        //        //������Ǹ�Ԫ��
        //        //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //        ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        //        //���ǰ���Ǹ�Ԫ��
        //        //ZYTextElement preElement = (ZYTextElement)myElements[intSelectStart - 1]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //        ZYTextElement preElement = (ZYTextElement)HBFElements[intSelectStart - 1]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        //        //����ǹ̶��ı������ڱ༭״����ɾ��
        //        if ((preElement.Parent is ZYFixedText || preElement.Parent is ZYText) && this.Document.Info.DocumentModel != DocumentModel.Design)
        //        {
        //            if (flag.Length > 0)
        //            {
        //                MessageBox.Show("ɾ����Χ�а����̶����ݣ�����ɾ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //            return 1;
        //        }
        //        //Add By wwj 2012-03-30 �ж϶�ZYButton��ɾ������
        //        if (preElement is ZYButton) if (!((ZYButton)preElement).CanDelete) return 1;

        //        //Add By wwj 2013-08-01 �ж϶�ZYFlag��ɾ������
        //        if (preElement is ZYFlag) if (!((ZYFlag)preElement).CanDelete) return 1;

        //        //��ǰԪ�صĸ�Ԫ��
        //        ZYTextParagraph parentPara = null;
        //        //��ǰԪ�صĸ�Ԫ�صĸ�Ԫ��(�ڱ����Ϊcell,����ͨ�ĵ���Ϊbody)
        //        ZYTextContainer parentDiv = null;


        //        //�����ǰԪ����ZYTextBlock, ��ZYTextBlock��Ϊһ�����崦��
        //        if (myElement.Parent is ZYTextBlock)
        //        {
        //            myElement = myElement.Parent;
        //            parentPara = myElement.Parent as ZYTextParagraph;
        //            parentDiv = parentPara.Parent;
        //        }
        //        else
        //        {
        //            parentPara = myElement.Parent as ZYTextParagraph;
        //            parentDiv = myElement.Parent.Parent;
        //        }

        //        int intDelete = myDocument.isDeleteElement(preElement);

        //        //int OldIndex = myElements.IndexOf(preElement); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
        //        int OldIndex = HBFElements.IndexOf(preElement); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

        //        if (intDelete == 0)
        //        {
        //            //����ǿ��кϲ�����һ��,��myElement����preElement.
        //            //����Ǵ����ݵ��кϲ�����һ��, ��myElementҪ�ϲ��еĵ�һ��Ԫ��,��preElementΪ�ϲ����е����һ��Ԫ��
        //            #region �ϲ���������

        //            //���������ڴ�Ϊһ���ն���,�Ҳ���cell��.��ɾ���������
        //            if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF && !IsParaInCell(myElement))
        //            {
        //                //��ȡ��ǰ�������һ������.
        //                object tmpEle = parentDiv.ChildElements[parentDiv.ChildElements.IndexOf(parentPara) - 1];
        //                //�������table,����������,����ִ���κζ���.
        //                if (!(tmpEle is TPTextTable))
        //                {
        //                    myElement = (tmpEle as ZYTextParagraph).LastElement;
        //                    parentDiv.RemoveChild(parentPara);
        //                    myDocument.RefreshElements();
        //                }
        //            }

        //            //���������ڴ�Ϊһ���ն���,����cell��.
        //            //�ҵ�ǰ���䲻��cell�ĵ�һ��Ԫ��
        //            else if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF &&
        //                IsParaInCell(myElement) && parentPara != parentDiv.FirstElement)
        //            {
        //                myElement = (parentDiv.ChildElements[parentDiv.ChildElements.IndexOf(parentPara) - 1] as ZYTextParagraph).LastElement;
        //                parentDiv.RemoveChild(parentPara);
        //                myDocument.RefreshElements();
        //            }

        //            //�������ڶ���ĵ�һ��Ԫ�ش�,�Ҷ��䲻Ϊ��,��ϲ�������䵽�ϸ�������.
        //            else if (myElement == parentPara.FirstElement && parentPara.ChildCount > 1 && !(parentPara.FirstElement is ZYTextEOF))
        //            {
        //                int currentParaIndex = parentDiv.IndexOf(parentPara);

        //                //Add by wwj 2012-05-29 �������ڱ��ĵ�Ԫ���У����λ����ǰ�棬����ɾ������������һ���лᱨ��������������жϣ����ⱨ�� todo
        //                if (currentParaIndex - 1 < 0) return 1;

        //                object tmpEle = parentDiv.ChildElements[currentParaIndex - 1];
        //                //���������еĵ�һ��Ԫ��
        //                if (currentParaIndex > 0 && !(tmpEle is TPTextTable))
        //                {
        //                    //����һ���ڴ�����
        //                    System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
        //                    myDoc.PreserveWhitespace = true;
        //                    myDoc.AppendChild(myDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));

        //                    //copy ��ǰ��������Ԫ�ص�һ���б��У�EOF����
        //                    ArrayList myList = new ArrayList();
        //                    for (int i = 0; i < parentPara.ChildCount - 1; i++)
        //                    {
        //                        myList.Add(parentPara.ChildElements[i]);
        //                    }
        //                    //���б��е�����Ԫ����xml����ʽ�浽�ڴ���
        //                    ZYTextElement.ElementsToXML(this.Document.GetRealElements(myList), myDoc.DocumentElement);

        //                    //��ԭcopy�����뵽��һ��,past
        //                    parentDiv.RemoveChild(parentPara);
        //                    myList.Clear();
        //                    this.Document.LoadElementsToList(myDoc.DocumentElement, myList);
        //                    if (myList.Count > 0)
        //                    {
        //                        foreach (ZYTextElement ele in myList)
        //                        {
        //                            ele.RefreshSize();
        //                        }
        //                        preElement.Parent.InsertRangeBefore(myList, preElement.Parent.LastElement);
        //                        myDocument.RefreshElements();
        //                        myElement = preElement.Parent.ChildElements[preElement.Parent.ChildElements.Count - myList.Count - 1] as ZYTextElement;
        //                    }
        //                }
        //            }
        //            #endregion


        //            //�����ǰԪ�ز��ǵ�ǰ����ĵ�һ��Ԫ��, ��ǰһ��Ԫ�ز�������
        //            else if (myElement != parentPara.FirstElement && !(preElement is ZYTextContainer))
        //            {
        //                bool bolSetParent = false;
        //                if (preElement.Parent.WholeElement)
        //                {
        //                    bolSetParent = true;
        //                }
        //                if (preElement.Parent is ZYTextBlock && preElement == preElement.Parent.GetLastElement())
        //                {
        //                    bolSetParent = true;
        //                }
        //                if (bolSetParent)
        //                {
        //                    preElement = preElement.Parent;
        //                }
        //                parentPara.RemoveChild(preElement);

        //                #region bwy
        //                myDocument.RefreshElements();
        //                parentPara.RefreshLine();
        //                #endregion bwy
        //            }

        //            bolModified = true;

        //            #region add by myc 2014-07-04 ���ԭ���ƶ�����������ĵ����ݸ������֮��
        //            ////���������ĵ��Ľ�β
        //            //if (isLastElement)
        //            //{
        //            //    //this.SetSelection(intSelectStart, 0); //add by myc 2014-06-23 ע��ԭ��ɾ��һ���ַ�֮�����Ӧ��ǰ��һλ������Ӱ�������BackSpace����
        //            //    this.SetSelection(intSelectStart - 1, 0);
        //            //}
        //            //else
        //            //{
        //            //    //������Ԫ����һ�ο�ͷ���˸�ʱ�����λ�ò��Ե�����
        //            //    if (myElement is ZYTextBlock)
        //            //    {
        //            //        this.MoveSelectStart((myElement as ZYTextBlock).FirstElement);
        //            //    }
        //            //    else
        //            //    {
        //            //        this.MoveSelectStart(myElement);
        //            //    }
        //            //}
        //            #endregion

        //            #region add by myc 2014-07-04 ���ԭ���ƶ�����������ĵ����ݸ������֮��
        //            ////���������ĵ��Ľ�β
        //            //if (isLastElement)
        //            //{
        //            //    //this.SetSelection(intSelectStart, 0); //add by myc 2014-06-23 ע��ԭ��ɾ��һ���ַ�֮�����Ӧ��ǰ��һλ������Ӱ�������BackSpace����
        //            //    this.SetSelection(intSelectStart - 1, 0);
        //            //    //this.MoveSelectStart(myElement); //add by myc 2014-07-10 ���ԭ����������ɾ��һ���ַ�֮�����Ӧ��ǰ��һλ������Ӱ�������BackSpace����
        //            //}
        //            //else
        //            //{
        //            //    //������Ԫ����һ�ο�ͷ���˸�ʱ�����λ�ò��Ե�����
        //            //    if (myElement is ZYTextBlock)
        //            //    {
        //            //        this.MoveSelectStart((myElement as ZYTextBlock).FirstElement);
        //            //    }
        //            //    else
        //            //    {
        //            //        this.MoveSelectStart(myElement);
        //            //    }
        //            //}

        //            this.MoveSelectStart(preElement); //add by myc 2014-08-06 ���ԭ������ҳü��ҳ������Backspaceɾ����겻����ȷ��λ

        //            #endregion
        //            //this.SetSelection(OldIndex, 0); //add by myc 2014-07-11 ��ע����������Խ�����λ�����⣬���滻ҳ��������ջ������

        //            #region add by myc 2014-03-18 �°������֮��Ԫ���ڲ�������ɾ��Ԫ��ʱ������Ӧ�߶ȵ���
        //            if (this.CurrentElement.Parent.Parent is TPTextCell)  //��һ�μ�鵱ǰԪ�ص��游�������
        //            {
        //                (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
        //            }
        //            else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //�ڶ��μ�鵱ǰԪ�ص����游�������
        //            {
        //                (this.CurrentElement.Parent.Parent.Parent as TPTextCell).AdjustHeight();
        //            }

        //            //TPTextCell currCell = this.CurrentElement.Parent.Parent as TPTextCell;
        //            //if (currCell != null)
        //            //{
        //            //    currCell.AdjustHeight();
        //            //}
        //            #endregion


        //            myDocument.ContentChanged();



        //        }
        //        else if (intDelete == 2)
        //        {
        //            this.SetSelection(OldIndex, 0);
        //        }
        //        return intDelete;

        //    }
        //    return 1;
        //}// void DeletePreElement
        #endregion

        /// <summary>
        /// ��������ı�����
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            //return ZYTextElement.GetElementsText(myElements); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            return ZYTextElement.GetElementsText(HBFElements); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        }


        /// <summary>
        /// ��ò����ǰ��һ�����ʵ���ʼλ��
        /// </summary>
        /// <returns></returns>
        public int GetPreWordIndex()
        {
            //intSelectStart = this.FixIndex( intSelectStart );
            int index = -1;
            ZYTextLine myLine = this.CurrentLine;
            for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
            {
                //if (myElements[iCount] is ZYTextChar) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                if (HBFElements[iCount] is ZYTextChar) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                {
                    //ZYTextChar myChar = (ZYTextChar)myElements[iCount]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    ZYTextChar myChar = (ZYTextChar)HBFElements[iCount]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    if (char.IsLetter(myChar.Char) && myChar.OwnerLine == myLine)
                        index = iCount;
                    else
                        break;
                }
                else
                    break;
            }
            return index;
        }// int GetPreWordIndex()

        /// <summary>
        /// ��ò����ǰ��һ�����ʵ���ʼλ��
        /// </summary>
        /// <param name="myElement">ָ����Ԫ�ض���</param>
        /// <returns></returns>
        public int GetPreWordIndex(ZYTextElement myElement)
        {
            //intSelectStart = this.FixIndex( intSelectStart );
            int index = -1;
            //if (myElement == null || myElements.Contains(myElement) == false) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (myElement == null || HBFElements.Contains(myElement) == false) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return -1;
            //for (int iCount = myElements.IndexOf(myElement) - 1; iCount >= 0; iCount--) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            for (int iCount = HBFElements.IndexOf(myElement) - 1; iCount >= 0; iCount--) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            {
                //if (myElements[iCount] is ZYTextChar) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                if (HBFElements[iCount] is ZYTextChar) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                {
                    //if (char.IsLetter((myElements[iCount] as ZYTextChar).Char)) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    if (char.IsLetter((HBFElements[iCount] as ZYTextChar).Char)) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                        index = iCount;
                    else
                        break;
                }
                else
                    break;
            }
            return index;
        }// int GetPreWordIndex()


        /// <summary>
        /// ��ò����ǰ�ĵ���
        /// </summary>
        /// <returns>��õĵ��ʣ����������򷵻ؿ�����</returns>
        public string GetPreWord()
        {
            int index = this.GetPreWordIndex();
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            ZYTextChar myChar = null;
            if (index >= 0)
            {
                for (int iCount = index; iCount < intSelectStart; iCount++)
                {
                    //myChar = myElements[iCount] as ZYTextChar; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    myChar = (ZYTextChar)HBFElements[iCount] as ZYTextChar; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    if (myChar != null)
                    {
                        if (char.IsLetter(myChar.Char))
                        {
                            myStr.Append(myChar.Char);
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
            }
            if (myStr.Length == 0)
                return null;
            else
                return myStr.ToString();
        }// string GetPreWord()

        /// <summary>
        /// ���ָ��Ԫ��ǰ�ĵ���
        /// </summary>
        /// <param name="myElement">ָ����Ԫ�ض���</param>
        /// <returns>��õĵ��ʣ����������򷵻ؿ�����</returns>
        public string GetPreWord(ZYTextElement myElement)
        {
            int index = this.GetPreWordIndex(myElement);
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            ZYTextChar myChar = null;
            if (index >= 0)
            {
                //for (int iCount = index; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                for (int iCount = index; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                {
                    //myChar = myElements[iCount] as ZYTextChar; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    myChar = (ZYTextChar)HBFElements[iCount] as ZYTextChar; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    if (myChar != null)
                    {
                        if (char.IsLetter(myChar.Char))
                            myStr.Append(myChar.Char);
                        else
                            break;
                    }
                    else
                        break;
                }
            }
            if (myStr.Length == 0)
                return null;
            else
                return myStr.ToString();
        }// string GetPreWord()

        /// <summary>
        /// ���ָ����Χ�ڵ�Ԫ�ص��ı�
        /// </summary>
        /// <param name="intStartIndex">ѡ������Ŀ�ʼ���</param>
        /// <param name="intEndIndex">ѡ������Ľ������</param>
        /// <returns>ѡ�����������е�Ԫ�ص��ı�</returns>
        public string GetRangeText(int intStartIndex, int intEndIndex)
        {
            intStartIndex = FixIndex(intStartIndex);
            intEndIndex = FixIndex(intEndIndex);
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            for (int iCount = intStartIndex; iCount <= intEndIndex; iCount++)
            {
                //myStr.Append(((ZYTextElement)myElements[iCount]).ToEMRString()); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                myStr.Append(((ZYTextElement)HBFElements[iCount]).ToEMRString()); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            }
            return myStr.ToString();
        }

        /// <summary>
        /// �ڲ�ʹ�õĻ��ͬԪ���б�����ȵ��ַ����ı�
        /// </summary>
        /// <returns></returns>
        internal string GetFixLenText()
        {
            //if (myElements == null) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return null;
            else
            {
                if (bolModified == false && strFixLenText != null)
                    return strFixLenText;
                else
                {
                    //char[] vChar = new char[myElements.Count]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    char[] vChar = new char[HBFElements.Count]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    ZYTextChar myChar = null;
                    //for (int iCount = 0; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    for (int iCount = 0; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    {
                        //myChar = myElements[iCount] as ZYTextChar; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                        myChar = HBFElements[iCount] as ZYTextChar; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                        if (myChar == null)
                            vChar[iCount] = (char)1;
                        else
                            vChar[iCount] = myChar.Char;
                    }
                    strFixLenText = new string(vChar);
                    return strFixLenText;
                }
            }
        }

        /// <summary>
        /// �����ַ���,���ҵ�������ѡ������Ϊ�ҵ����ַ���
        /// </summary>
        /// <param name="strText">��Ҫ���ҵ��ַ���</param>
        /// <returns>�Ƿ��ҵ��ַ���</returns>
        public bool FindText(string strText)
        {
            if (strText != null && strText.Length != 0)
            {

                GetFixLenText();
                if (strFixLenText != null)
                {
                    int Index = strFixLenText.IndexOf(strText, this.SelectStart);
                    if (Index >= 0)
                    {
                        this.Document.Content.MoveSelectStart(Index);
                        this.Document.OwnerControl.ScrollViewtopToCurrentElement();
                        this.SetSelection(Index + strText.Length, 0 - strText.Length);
                    }
                    return (Index >= 0);
                }
            }
            return false;
        }

        /// <summary>
        /// �滻�ַ���
        /// </summary>
        /// <param name="strFind">��Ҫ���ҵ��ַ���</param>
        /// <param name="strReplace">��Ҫ�滻���ַ���</param>
        /// <returns>�Ƿ��滻���ַ���</returns>
        public bool ReplaceText(string strFind, string strReplace, out string msg)
        {
            msg = "";
            if (this.GetSelectText() == strFind)
            {
                //���Ҫ�滻��������Ԫ���У������滻
                bool flag = true;
                foreach (ZYTextElement ele in this.GetSelectElements())
                {
                    if (ele.Parent is ZYTextBlock || ele is ZYElement)
                    {
                        //MessageBox.Show("ֻ���滻���ı��������滻Ԫ���ڲ��ı���", "����"); Modified by wwj 2013-04-18
                        msg = "ֻ���滻���ı��������滻Ԫ���ڲ��ı���";
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    this.ReplaceSelection(strReplace);
                }
            }
            //FindText(strFind); Modified by wwj 2013-04-18
            return true;
        }

        /// <summary>
        /// �滻���е��ַ���
        /// </summary>
        /// <param name="strFind">���ҵ��ַ���</param>
        /// <param name="strReplace">�滻���ַ���</param>
        /// <returns>�滻�Ĵ���</returns>
        public int ReplaceTextAll(string strFind, string strReplace)
        {
            int iCount = 0;
            this.SetSelection(0, 0);
            while (FindText(strFind))
            {
                this.ReplaceSelection(strReplace);
                //ReplaceText( strReplace );
                //FindText( strFind );
                iCount++;
            }
            return iCount;
        }

        #region �ƶ���ǰ�����λ�õĺ���Ⱥ ************************************
        /// <summary>
        /// ������������ƶ�һ��,����û�еط����õ���
        /// </summary>
        public void MoveUpOneLine2()
        {
            //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

            int TargetLineIndex = StartElement.RealLineIndex - 1;
            int OldLeft = StartElement.RealLeft;
            ZYTextElement myElement = null;
            for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
            {
                //myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                if (myElement.RealLineIndex == TargetLineIndex)
                {
                    if (myElement.RealLeft <= OldLeft)
                    {
                        //int index = myElements.IndexOf( myElement );
                        this.MoveSelectStart(iCount);
                        break;
                    }
                }
                if (myElement.RealLineIndex < TargetLineIndex)
                {
                    this.MoveSelectStart(iCount + 1);
                    break;
                }
            }
        }

        /// <summary>
        /// ������������ƶ�һ��
        /// </summary>
        public void MoveUpOneLine()
        {
            #region 2019.8.6-hdf�������п�Ԫ�صĽ���ʧȥ
            List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
            elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
            {
                if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                return ele;
            }).ToList();
            #endregion
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 ���ԭ���������ҷ�����ƶ����ʱ����IsMoveCaretToLineEnd

            myDocument.OwnerControl.ScrollViewToCaretVisibleUp(this.CurrentLine, this.PreLine); //add by myc 2014-08-08 ����ScrollViewToCaretVisibleUp����ʹ�ð������Ϸ����ʱ�ƶ���겢�ɼ�


            ZYTextLine myLine = this.PreLine;
            if (myLine != null)
            {
                if (intLastXPos <= 0)
                {
                    //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    intLastXPos = StartElement.RealLeft;
                }
                for (int i = 0; i < myLine.Elements.Count; i++)//foreach (ZYTextElement myElement in myLine.Elements)
                {
                    ZYTextElement myElement = myLine.Elements[i] as ZYTextElement;
                    if (myElement.RealLeft >= intLastXPos)
                    {
                        #region bwy:
                        //�����Ԫ����//2019.8.16-hdf����Ԫ�ؼ����ܲ��뻻�й��ܣ�����Ԫ�����ж�����ʱ������ƶ���Ҫ�ܽ����Ԫ��
                        if (myElement.Parent is ZYTextBlock && !(myElement.Parent is ZYMacro || myElement.Parent is ZYReplace || myElement.Parent is ZYFormatString || myElement.Parent is ZYDiag || myElement.Parent is ZYSubject))
                        {
                            myElement = (myElement.Parent as ZYTextBlock).FirstElement;
                        }
                        #endregion bwy:
                        this.MoveSelectStart(myElement);
                        //2019.8.16-hdf������ƶ����ж��Ƿ��ڿ�Ԫ�����޸Ŀ�Ԫ�صĽ����ȡ״̬
                        if ((this.CurrentElement.Parent is ZYMacro || this.CurrentElement.Parent is ZYReplace || this.CurrentElement.Parent is ZYFormatString || this.CurrentElement.Parent is ZYDiag || myElement.Parent is ZYSubject)
                            && this.CurrentElement != this.CurrentElement.Parent.FirstElement)
                        {
                            (this.CurrentElement.Parent as ZYTextBlock).IsFocus = true;
                        }
                        return;
                    }
                }
                this.MoveSelectStart(myLine.LastElement);
                //2019.8.16-hdf������ƶ����ж��Ƿ��ڿ�Ԫ�����޸Ŀ�Ԫ�صĽ����ȡ״̬
                if (this.CurrentElement.Parent is ZYMacro || this.CurrentElement.Parent is ZYReplace || this.CurrentElement.Parent is ZYFormatString || this.CurrentElement.Parent is ZYDiag || this.CurrentElement.Parent is ZYSubject)
                {
                    (this.CurrentElement.Parent as ZYTextBlock).IsFocus = true;
                }
            }
            #region comment
            // MoveDownOneLine

            //
            //			ZYTextElement StartElement =(ZYTextElement) myElements[intSelectStart];
            //			//int OldLineIndex = StartElement.LineIndex ;
            //			int OldLeft	 = intLastXPos ;
            //			if( intLastXPos <= 0 )
            //			{
            //				OldLeft = StartElement.RealLeft + StartElement.Width  ;
            //				intLastXPos = OldLeft ;
            //			}
            //
            //			ZYTextElement myElement = null;
            //			bool bolLineChanged = false;
            //			ZYTextElement LastParent = StartElement.Parent ;
            //			//int LineIndex = 0 ;
            //			ZYTextLine OldLine = StartElement.OwnerLine ;
            //			for( int iCount = intSelectStart - 1 ; iCount >= 0  ; iCount -- )
            //			{
            //				myElement = ( ZYTextElement ) myElements[iCount];
            //				if( bolLineChanged == false && ( myElement.OwnerLine != OldLine  ))
            //				{
            //					bolLineChanged = true;
            //					OldLine = myElement.OwnerLine ;
            //				}
            //				if( bolLineChanged)
            //				{
            //					if( myElement.OwnerLine != OldLine  )
            //					{
            //						this.MoveSelectStart( iCount +1 );
            //						break;
            //					}
            //
            //					if( myElement.RealLeft <= OldLeft )
            //					{
            //						this.MoveSelectStart( iCount ) ;
            //						break;
            //					}
            //				}
            //				LastParent = myElement.Parent ;
            //			}
            //this.MoveSelectStart(0);
            #endregion
        }

        /// <summary>
        /// ������������ƶ�һ��
        /// </summary>
        public void MoveDownOneLine()
        {
            #region 2019.8.6-hdf�������п�Ԫ�صĽ���ʧȥ
            List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
            elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
            {
                if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                return ele;
            }).ToList();
            #endregion
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 ���ԭ���������ҷ�����ƶ����ʱ����IsMoveCaretToLineEnd

            ZYTextLine myLine = this.NextLine;
            if (myLine != null)
            {
                myDocument.OwnerControl.ScrollViewToCaretVisibleDown(this.CurrentLine, this.NextLine); //add by myc 2014-08-08 ����ScrollViewToCaretVisibleDown����ʹ�ð������·����ʱ�ƶ���겢�ɼ�


                if (intLastXPos <= 0)
                {
                    //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    intLastXPos = StartElement.RealLeft;
                }
                for (int i = 0; i < myLine.Elements.Count; i++)//foreach (ZYTextElement myElement in myLine.Elements)
                {
                    ZYTextElement myElement = myLine.Elements[i] as ZYTextElement;
                    if (myElement.RealLeft >= intLastXPos)
                    {
                        #region bwy:
                        //�����Ԫ����//2019.8.16-hdf����Ԫ�ؼ����ܲ��뻻�й��ܣ�����Ԫ�����ж�����ʱ������ƶ���Ҫ�ܽ����Ԫ��
                        if (myElement.Parent is ZYTextBlock && !(myElement.Parent is ZYMacro || myElement.Parent is ZYReplace || myElement.Parent is ZYFormatString || myElement.Parent is ZYDiag || myElement.Parent is ZYSubject))
                        {
                            myElement = this.GetNextElement((myElement.Parent as ZYTextBlock).LastElement);
                        }
                        #endregion bwy:
                        this.MoveSelectStart(myElement);
                        //2019.8.16-hdf������ƶ����ж��Ƿ��ڿ�Ԫ�����޸Ŀ�Ԫ�صĽ����ȡ״̬
                        if ((this.CurrentElement.Parent is ZYMacro || this.CurrentElement.Parent is ZYReplace || this.CurrentElement.Parent is ZYFormatString || this.CurrentElement.Parent is ZYDiag || this.CurrentElement.Parent is ZYSubject)
                            && this.CurrentElement != this.CurrentElement.Parent.FirstElement)
                        {
                            (this.CurrentElement.Parent as ZYTextBlock).IsFocus = true;
                        }
                        return;
                    }
                }
                this.MoveSelectStart(myLine.LastElement);
                //2019.8.16-hdf������ƶ����ж��Ƿ��ڿ�Ԫ�����޸Ŀ�Ԫ�صĽ����ȡ״̬
                if (this.CurrentElement.Parent is ZYMacro || this.CurrentElement.Parent is ZYReplace || this.CurrentElement.Parent is ZYFormatString || this.CurrentElement.Parent is ZYDiag || this.CurrentElement.Parent is ZYSubject)
                {
                    (this.CurrentElement.Parent as ZYTextBlock).IsFocus = true;
                }
            }// MoveDownOneLine
        }

        /// <summary>
        /// ������������ƶ�һ��Ԫ��
        /// </summary>
        public void MoveLeft()
        {
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 ���ԭ���������ҷ�����ƶ����ʱ����IsMoveCaretToLineEnd


            if (this.CurrentLine.Elements.IndexOf(CurrentElement) == 0) //add by myc 2014-08-08 ��ǰ���λ�ڵ�ǰ�ĵ������һ��Ԫ��֮ǰ���������ScrollViewToCaretVisibleUp����
            {
                myDocument.OwnerControl.ScrollViewToCaretVisibleUp(this.CurrentLine, this.PreLine); //add by myc 2014-08-08 ����ScrollViewToCaretVisibleUp����ʹ�ð������Ϸ����ʱ�ƶ���겢�ɼ�
            }


            intLastXPos = -1;
            if (intSelectStart > 0)
            {
                //����ƶ�����Ԫ���ڲ���������
                //ZYTextElement ele = this.Elements[intSelectStart - 1] as ZYTextElement; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                ZYTextElement ele = this.HBFElements[intSelectStart - 1] as ZYTextElement; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ

                //2019.8.6-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ�ı�¼���Ż��������Ҽ�ʹ��������Ԫ�ؽ����ı�¼��
                ZYTextElement cele = new ZYTextElement();
                if (intSelectStart < this.HBFElements.Count)
                {
                    cele = this.HBFElements[intSelectStart] as ZYTextElement;
                }
                if (ele.Parent is ZYMacro || ele.Parent is ZYFormatString || ele.Parent is ZYReplace || ele.Parent is ZYDiag || ele.Parent is ZYSubject)
                {
                    if (cele.Parent is ZYTextBlock && (cele.Parent as ZYTextBlock).IsFocus && ele.Parent != cele.Parent)
                    {
                        (cele.Parent as ZYTextBlock).IsFocus = false;
                    }
                    else if ((ele.Parent as ZYTextBlock).IsFocus)
                    {
                        this.MoveSelectStart(intSelectStart - 1);
                    }
                    else
                    {
                        (ele.Parent as ZYTextBlock).IsFocus = true;
                    }
                }
                else if (cele.Parent is ZYMacro || cele.Parent is ZYFormatString || cele.Parent is ZYReplace || cele.Parent is ZYDiag || cele.Parent is ZYSubject)
                {
                    if (cele == cele.Parent.FirstElement && (cele.Parent as ZYTextBlock).IsFocus)
                    {
                        (cele.Parent as ZYTextBlock).IsFocus = false;
                    }
                    else
                    {
                        this.MoveSelectStart(intSelectStart - 1);
                    }
                }
                else if (ele.Parent is ZYTextBlock)
                {
                    //intSelectStart = this.Elements.IndexOf((ele.Parent as ZYTextBlock).FirstElement); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    int newSelectStart = this.HBFElements.IndexOf((ele.Parent as ZYTextBlock).FirstElement); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    this.MoveSelectStart(newSelectStart); //2014-08-07 myc ������ƶ�
                }
                else
                {
                    this.MoveSelectStart(intSelectStart - 1);
                }
            }
            else
            {
                //2019.8.6-hdf�������п�Ԫ�صĽ���ʧȥ
                List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
                elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
                {
                    if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                    return ele;
                }).ToList();
            }

        }

        /// <summary>
        /// ������������ƶ�һ��Ԫ��
        /// </summary>
        public void MoveRight()
        {
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 ���ԭ���������ҷ�����ƶ����ʱ����IsMoveCaretToLineEnd

            if (this.CurrentLine.Elements.IndexOf(CurrentElement) == this.CurrentLine.Elements.Count - 1) //add by myc 2014-08-08 ��ǰ���λ�ڵ�ǰ�ĵ������һ��Ԫ��֮ǰ���������ScrollViewToCaretVisible����
            {
                myDocument.OwnerControl.ScrollViewToCaretVisibleDown(this.CurrentLine, this.NextLine); //add by myc 2014-08-08 ����ScrollViewToCaretVisibleDown����ʹ�ð������·����ʱ�ƶ���겢�ɼ�
            }


            intLastXPos = -1;
            //if (intSelectStart < myElements.Count - 1) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (intSelectStart < HBFElements.Count - 1) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            {
                //����ƶ�����Ԫ���ڲ���������
                //ZYTextElement ele = this.Elements[intSelectStart - 1] as ZYTextElement; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                ZYTextElement ele = this.HBFElements[intSelectStart] as ZYTextElement; //add by myc 2014-07-16 ���ԭ�򣺹�궨λ��Word����

                //2019.8.6-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ�ı�¼���Ż��������Ҽ�ʹ��������Ԫ�ؽ����ı�¼��
                ZYTextElement cele = new ZYTextElement();
                if (intSelectStart > 0)
                {
                    cele = this.HBFElements[intSelectStart - 1] as ZYTextElement;
                }
                if ((ele.Parent is ZYMacro || ele.Parent is ZYFormatString || ele.Parent is ZYReplace || ele.Parent is ZYDiag || ele.Parent is ZYSubject))
                {
                    if (cele.Parent is ZYTextBlock && (cele.Parent as ZYTextBlock).IsFocus && ele.Parent != cele.Parent)
                    {
                        (cele.Parent as ZYTextBlock).IsFocus = false;
                    }
                    else if ((ele.Parent as ZYTextBlock).IsFocus)
                    {
                        this.MoveSelectStart(intSelectStart + 1);
                    }
                    else
                    {
                        (ele.Parent as ZYTextBlock).IsFocus = true;
                    }
                }
                else if (cele.Parent is ZYMacro || cele.Parent is ZYFormatString || cele.Parent is ZYReplace || cele.Parent is ZYDiag || cele.Parent is ZYSubject)
                {
                    if (cele == cele.Parent.LastElement && (cele.Parent as ZYTextBlock).IsFocus)
                    {
                        (cele.Parent as ZYTextBlock).IsFocus = false;
                    }
                    else
                    {
                        this.MoveSelectStart(intSelectStart + 1);
                    }
                }
                else if (ele.Parent is ZYTextBlock)
                {
                    //intSelectStart = this.Elements.IndexOf((ele.Parent as ZYTextBlock).LastElement); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                    int newSelectStart = this.HBFElements.IndexOf((ele.Parent as ZYTextBlock).LastElement); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                    this.MoveSelectStart(newSelectStart + 1); //2014-08-07 myc �ҹ����ƶ�
                }
                else
                {
                    this.MoveSelectStart(intSelectStart + 1);
                }
            }
            else
            {
                //2019.8.6-hdf�������п�Ԫ�صĽ���ʧȥ
                List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
                elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
                {
                    if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                    return ele;
                }).ToList();
            }
        }

        /// <summary>
        /// ��������ƶ�����ǰ�е����һ��Ԫ�ش�
        /// </summary>
        public void MoveEnd()
        {
            try
            {
                IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 ���ԭ���������ҷ�����ƶ����ʱ����IsMoveCaretToLineEnd

                ZYTextLine myLine = this.CurrentLine;
                if (myLine != null && bolLineEndFlag == false)
                {
                    intLastXPos = -1;
                    //this.CurrentElement = myLine.LastElement;
                    ZYTextElement ele = myLine.LastElement;
                    if (ele.Parent is ZYTextBlock)
                    {
                        ele = (ele.Parent as ZYTextBlock).FirstElement;
                        this.MoveSelectStart(ele);
                        return;
                    }

                    if (ele.isNewLine())//(myLine.LastElement.isNewLine())
                    {
                        this.MoveSelectStart(ele);//(myLine.LastElement);
                    }
                    else
                    {
                        //this.MoveSelectStart(myElements.IndexOf(myLine.LastElement) + 1);

                        //this.MoveSelectStart(myElements.IndexOf(ele) + 1); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                        IsMoveCaretToLineEnd = true;
                        this.MoveSelectStart(HBFElements.IndexOf(ele) + 1); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                        //bolLineEndFlag = true; //add by myc 2014-07-16 ���ԭ�򣺹�궨λ��Word������Ҫ

                        ((ZYTextDocument)myDocument).UpdateTextCaret();
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// �ƶ���ǰ����㵽��ǰ�е�����
        /// </summary>
        public void MoveHome()
        {
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 ���ԭ���������ҷ�����ƶ����ʱ����IsMoveCaretToLineEnd

            ZYTextLine myLine = null;
            myLine = this.CurrentLine;
            if (myLine != null)
            {
                intLastXPos = -1;

                #region bwy:
                ZYTextElement ele = myLine.FirstElement;
                if (ele.Parent is ZYTextBlock && ele != ele.Parent.FirstElement)
                {
                    ele = this.GetNextElement((ele.Parent as ZYTextBlock).LastElement);
                }
                //int FirstIndex = myElements.IndexOf(ele); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                int FirstIndex = HBFElements.IndexOf(ele); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                #endregion bwy:
                // ��õ�һ���ǿհ��ַ�Ԫ�ص����
                int FirstNBlank = 0;

                foreach (ZYTextElement myElement in myLine.Elements)
                {
                    ZYTextChar myChar = myElement as ZYTextChar;
                    if (myChar == null || char.IsWhiteSpace(myChar.Char) == false)
                    {
                        FirstNBlank = myLine.Elements.IndexOf(myElement);
                        break;
                    }
                }
                if (FirstNBlank == 0 || intSelectStart == (FirstIndex + FirstNBlank))
                {
                    this.MoveSelectStart(FirstIndex);
                }
                else
                {
                    this.MoveSelectStart(FirstIndex + FirstNBlank);
                }
            }
        }// void MoveHome



        #region add by myc 2014-06-09 ע��ԭ�򣺴˷���û�жԵ�Ԫ��Ԫ�������������ƣ�����Ӱ�쵽����ڱ���ڵ���ȷ�ƶ�
        ///// <summary>
        ///// ���ָ��λ�ô���Ԫ��
        ///// 2009-7-2 22:00 mfb����ʵ��. ������MoveTo(x,y)
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <returns></returns>
        //public ZYTextElement GetElementAt(int x, int y)
        //{
        //    if (myDocument != null && myDocument.Lines != null && myDocument.Lines.Count > 0)
        //    {
        //        ZYTextLine CurrentLine = null;

        //        foreach (ZYTextLine myLine in myDocument.Lines)
        //        {
        //            if (myLine.RealTop + myLine.Height >= y)
        //            {
        //                if (myLine.RealLeft <= x && (myLine.RealLeft + myLine.ContentWidth) >= x)
        //                {
        //                    CurrentLine = myLine;
        //                    break;
        //                }
        //            }
        //        }
        //        if (CurrentLine == null && myDocument.Lines.Count > 0)
        //            CurrentLine = (ZYTextLine)myDocument.Lines[myDocument.Lines.Count - 1];

        //        if (CurrentLine == null)
        //            return null;
        //        x -= CurrentLine.RealLeft;


        //        ZYTextElement CurrentElement = null;

        //        if (CurrentLine.Elements.Count == 0)
        //        {
        //            CurrentElement = CurrentLine.Container;
        //        }
        //        foreach (ZYTextElement myElement in CurrentLine.Elements)
        //        {
        //            if (x < myElement.Left + myElement.Width)
        //            {
        //                if (x > (myElement.Left + myElement.Width))
        //                {
        //                    continue;
        //                }
        //                if (myElement.Parent.WholeElement)
        //                    return null;
        //                CurrentElement = myElement;
        //                break;
        //            }
        //        }

        //        if (CurrentElement == null)
        //        {
        //            CurrentElement = CurrentLine.LastElement;
        //        }
        //        return CurrentElement;

        //    }
        //    return null;
        //} 
        #endregion



        /// <summary>
        /// ��⵱ǰ�Ĳ����λ���Ƿ���ȷ
        /// </summary>
        /// <returns></returns>
        private bool CheckSelectStart()
        {
            //if (myElements == null) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return false;
            else
                //return (intSelectStart >= 0 && intSelectStart <= myElements.Count - 1); //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                return (intSelectStart >= 0 && intSelectStart <= HBFElements.Count - 1); //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
        }



        /// <summary>
        /// �ƶ���ǰ�����
        /// </summary>
        /// <param name="iStep">������ƶ�����</param>
        public void MoveStep(int iStep)
        {
            //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            //this.MoveTo(StartElement.RealLeft, StartElement.RealTop + iStep); //ע�� add by myc 2014-07-30
            this.MoveToNoSelectingArea(StartElement.RealLeft, StartElement.RealTop + iStep); //��� add by myc 2014-07-30 �¹�궨λ
        }


        #endregion

        /// <summary>
        /// ��ʼ������
        /// </summary>
        public ZYContent()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// �ж��Ƿ����ɾ��ѡ��Ԫ��,���ѡ�ж����Ԫ�������������ɾ�� Add By wwj 2012-04-24
        /// </summary>
        /// <returns></returns>
        public bool CanDeleteSelectElement()
        {
            //��ʾ�Ƿ���Ԫ���ڵ�Ԫ����ⲿ
            bool isHasElementOutCell = false;

            System.Collections.ArrayList myList = this.GetSelectElements();
            List<ZYTextElement> cellList = new List<ZYTextElement>();
            foreach (ZYTextElement ele in myList)
            {
                ZYTextElement textElement = this.GetParentByElement(ele, ZYTextConst.c_Cell);
                if (textElement != null)
                {
                    //�����ڵ�Ԫ���ڵģ������ڵ�Ԫ����ģ�������ɾ��Ԫ��
                    if (isHasElementOutCell) return false;

                    if (!cellList.Contains(textElement))
                    {
                        cellList.Add(textElement);
                        if (cellList.Count > 1)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    isHasElementOutCell = true;//��ʾ��Ԫ���ڵ�Ԫ����ⲿ

                    //����ѡ�б�����Ԫ�أ���ѡ���˱���е�Ԫ��������ɾ������
                    if (cellList.Count > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// �õ��༭���е�һ����� Add by wwj 2012-05-29
        /// </summary>
        /// <returns></returns>
        public TPTextTable GetFirstTable()
        {
            //ArrayList list = myElements; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ 
            ArrayList list = HBFElements; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            for (int i = 0; i < list.Count; i++)
            {
                //ZYTextElement myElement = (ZYTextElement)myElements[i]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
                ZYTextElement myElement = (ZYTextElement)HBFElements[i]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                ZYTextElement table = GetParentByElement(myElement, ZYTextConst.c_Table);
                if (table != null && table is TPTextTable)
                {
                    return ((TPTextTable)table).Clone();
                }
            }
            return null;
        }

        /// <summary>
        /// ���õ�Ԫ���Ƿ���Ի��� Add By wwj 2012-06-06
        /// </summary>
        public void SetTableCellCanInsertEnter(bool canEnter)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
                return;
            if (this.IsLock(intSelectStart))
                return;

            //��õ�ǰԪ��
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 ע��ԭ���°�ҳü���ڸİ���Ҫ
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 ���ԭ���°�ҳü���ڸİ���Ҫ
            //��õ�ǰ���
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                List<TPTextCell> listCells = new List<TPTextCell>();
                foreach (TPTextRow row in currentTable)
                {
                    foreach (TPTextCell cell in row)
                    {
                        if (true == cell.CanAccess)
                        {
                            cell.CanInsertEnter = canEnter;
                        }
                    }
                }
            }
        }






        #region add by myc 2014-07-03 ���ԭ���°�ҳü���ڸİ�֮��궨λ
        /// <summary>
        /// ��ʶ����Ƿ��ƶ����ı��ַ�ĩβ��
        /// </summary>
        public static bool IsMoveCaretToLineEnd = false;
        #endregion




        #region �°�ҳüҳ�ź�����ͳһ�������� add by myc 2014-07-22
        #region ��궨λ����>�����޶���2014-08-05
        /// <summary>
        /// ���ص�ǰ�ĵ��༭���ڵ������ı�����Ԫ�ء�
        /// </summary>
        public ArrayList HBFElements
        {
            get
            {
                return this.Document.HBFElements;
            }
        }

        /// <summary>
        /// ����intSelectStartֵ�Ա�֤���ڿɼ�Ԫ���б��������Χ�ڡ�
        /// </summary>
        /// <param name="index">ԭʼ����š�</param>
        /// <returns>���������š�</returns>
        private int FixIndex(int index)
        {
            try
            {
                if (index <= 0)
                {
                    return 0;
                }
                if (index >= HBFElements.Count)
                {
                    return HBFElements.Count - 1;
                }
                return index;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��鲢У��ѡ�������ڵ�intSelectStart��intSelectLength���Ա�֤���ڿɼ�Ԫ���б��������Χ�ڡ�
        /// </summary>
        private void FixSelection()
        {
            try
            {
                if (intSelectStart >= HBFElements.Count)
                    intSelectStart = HBFElements.Count - 1;
                if (intSelectStart < 0)
                    intSelectStart = 0;
                if (intSelectLength > 0 && (intSelectStart + intSelectLength > HBFElements.Count))
                    intSelectLength = 0;
                if (intSelectLength < 0 && (intSelectStart + intSelectLength < 0))
                    intSelectLength = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ȡ�ĵ���ͼ����ָ����λ�ô����ĵ�Ԫ�ض���
        /// </summary>
        /// <param name="x">ָ�����X���ꡣ</param>
        /// <param name="y">ָ�����Y���ꡣ</param>
        /// <returns></returns>
        public ZYTextElement GetElementAt(int x, int y)
        {
            try
            {
                if (myDocument == null || myDocument.HBFLines == null || myDocument.HBFLines.Count == 0) return null;

                #region ���ҵ�������ǰָ������ĵ��ж���
                //ָ��˼�롪��>�����ĵ����·��еĵݹ��㷨����֪��Ԫ���ڵ��ĵ��ж���һ�����ڱ�����ڵ��ĵ��ж���֮ǰ
                //ͬʱ��Ҳ��֪��ֵ�Ԫ���ڲ���Ƕ�ױ�����ڵ��ĵ��ж���һ�������ڲ�ֵ�Ԫ�������ڱ�����ڵ��ĵ��ж���֮ǰ
                //���⣬����еĸ߶��������ڲ����е�Ԫ�����С�߶�ֵ��Ϊ��׼���ʶ��ںϲ���Ԫ���е��ĵ��ж���Ҳ�赥������

                ZYTextLine findLine = null;
                for (int i = 0; i < myDocument.HBFLines.Count; i++)
                {
                    ZYTextLine myLine = myDocument.HBFLines[i] as ZYTextLine;
                    if (myLine.Container is ZYTextParagraph)
                    {
                        ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                        if (para.Parent is TPTextCell) //��ǰ�ĵ��ж���������������Ϊ��Ԫ��
                        {
                            #region ��Ԫ���ڵĶ���
                            TPTextRow row = (para.Parent as TPTextCell).OwnerRow;
                            Rectangle rect1 = row.OwnerTable.GetContentBounds();
                            foreach (TPTextCell cell in row)
                            {
                                if (cell.ChildCount == 0) continue; //ռλ��Ԫ��
                                if (cell.ChildCount > 0
                                    && cell.ChildElements[0] is TPTextRow) continue; //��ֵ�Ԫ��

                                Rectangle rect = cell.GetContentBounds(); //��ǰ��Ԫ������о���

                                int vHeight = 0;
                                if (rect.Bottom == rect1.Bottom)
                                {
                                    vHeight = myDocument.Info.LineSpacing; //2014-08-05 ������ҳ֮�ڵ��ĵ�����Ҫ����߽��жϣ���һҳ֮�ڵķ�ɫ���Ʋ��ܿ�Խ����һҳ��һ���ĵ��У�
                                }

                                //if (y >= rect.Top //�ɵ�Ԫ�񶥶��������򡪡�>�������ƶ�����һ���ĵ��е׶��������Ԫ�񶥶�֮�䣬����ô�жϻ�����쳣
                                if (y >= rect.Top - myDocument.Info.LineSpacing //2014-07-30 ����һ���ĵ��е׶�����Ԫ��׶�����
                                    //&& y <= rect.Top + rect.Height)
                                    && y <= rect.Top + rect.Height + vHeight) //2014-08-05 ������ҳ֮�ڵ��ĵ�����Ҫ����߽��жϣ���һҳ֮�ڵķ�ɫ���Ʋ��ܿ�Խ����һҳ��һ���ĵ��У�
                                {
                                    //if (x >= rect.Left &&
                                    //        x <= rect.Left + rect.Width)
                                    //{
                                    //    findLine = MoveCaretInCell(cell, x, y);
                                    //    break;
                                    //} //����>���ַ�ʽ�ж϶��ڱ������Ҷ����ĵ���ͼ�����ڼ��ʱ��Ч

                                    #region add by myc 2014-08-01 ���ԭ�򣺴�����߽�����ͼ�����ڼ��ʱ�Ĺ�궨λ����ѡ��Ԫ��
                                    if (rect.Left == rect1.Left)
                                    {
                                        if (x <= rect.Right)
                                        {
                                            findLine = MoveCaretInCell(cell, x, y);
                                            break;
                                        }
                                    }
                                    else if (rect.Right == rect1.Right)
                                    {
                                        if (x >= rect.Left)
                                        {
                                            findLine = MoveCaretInCell(cell, x, y);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (x >= rect.Left &&
                                              x <= rect.Left + rect.Width)
                                        {
                                            findLine = MoveCaretInCell(cell, x, y);
                                            break;
                                        }
                                    }
                                    #endregion
                                }
                            }
                            if (findLine != null) break; //����ǳ��ؼ����ҵ���Ԫ���ڵ��ı��ж���֮������˳�ѭ��
                            #endregion
                        }
                        else //��ǰ�ĵ��ж�����������������Ϊ��Ԫ��
                        {
                            #region �ĵ��ڻ�������
                            if (i == 0) //��һ���ĵ��ж���
                            {
                                //if (y <= myLine.RealTop + myLine.Height) //���ĵ��е׶���������
                                if (y <= myLine.RealTop + myLine.FullHeight) //2014-08-07 ���ĵ��ж����������׶�����
                                {
                                    findLine = myLine;
                                    break;
                                }

                                if (myDocument.HBFLines.Count == 1) //ֻ��һ���ĵ��ж���ʱ�����⴦��
                                {
                                    if (y >= myLine.RealTop) //���ĵ��ж�����������
                                    {
                                        findLine = myLine;
                                        break;
                                    }
                                }
                            }
                            else if (i == myDocument.HBFLines.Count - 1) //���һ���ĵ��ж���
                            {
                                //if (y >= myLine.RealTop) //���ĵ��ж����������򡪡�>�������ƶ�����һ���ĵ��е׶�������ĵ��ж���֮�䣬����ô�жϻ�����쳣
                                if (y >= myLine.RealTop - myDocument.Info.LineSpacing) //2014-07-30 ����һ���ĵ��е׶���������
                                {
                                    findLine = myLine;
                                    break;
                                }
                            }
                            //else if (y >= myLine.RealTop - myDocument.Info.LineSpacing
                            //    && y <= myLine.RealTop + myLine.Height) //�м���ĵ��ж��󣨲���Word�������ĵ��е׶���������һ�ĵ��ж���׶����򣩡���2014-08-04 ������ҳ֮�ڵ��ĵ�����Ҫ����߽��ж�(���ڴ���)
                            else if (y >= myLine.RealTop
                                && y <= myLine.RealTop + myLine.FullHeight) //�м���ĵ��ж��󣨲���Word�������ĵ��ж�����������һ�ĵ��ж��󶥶����򣩡���2014-08-05 ������ҳ֮�ڵ��ĵ�����Ҫ����߽��жϣ���һҳ֮�ڵķ�ɫ���Ʋ��ܿ�Խ����һҳ��һ���ĵ��У�
                            {
                                findLine = myLine;
                                break;
                            }
                            #endregion
                        }
                    }
                }
                if (findLine == null) return null;
                #endregion

                #region ���ҵ������ǰָ������ĵ�Ԫ��
                ZYTextElement findElement = null;
                x -= findLine.RealLeft; //��X���껻��������findLine��˵�X���ꡪ��>��Ϊ�����λ�ñȽϲ��������findLine��ˣ���ΪX=0����λ��
                if (findLine.Elements.Count == 0)
                {
                    findElement = findLine.Container;
                    return findElement; //2014-08-21 ������ֿ�ֵ�쳣
                }

                if (x < findLine.FirstElement.Left)
                {
                    return findLine.FirstElement;
                }
                if (x > findLine.LastElement.Left + findLine.LastElement.Width)
                {
                    return findLine.LastElement;
                }

                for (int i = 0; i < findLine.Elements.Count; i++)
                {
                    ZYTextElement myElement = findLine.Elements[i] as ZYTextElement;
                    if (x >= myElement.Left
                        && x < myElement.Left + myElement.Width / 2) //X����λ��myElementǰһ��������
                    {
                        findElement = myElement;
                        break;
                    }
                    else if (x >= myElement.Left + myElement.Width / 2
                        && x <= myElement.Left + myElement.Width + myElement.WidthFix) //X����λ��myElement��һ�������ڡ���>2014-07-29 ע��������WidthFix�����ڷ�ɢ���룩
                    {
                        //2014-07-30 ���ַ�ʽ��������ڵ�Ԫ�����һ���س����������Ծ����һ����Ԫ���ڣ�������
                        //if (HBFElements.IndexOf(myElement) < HBFElements.Count - 1)
                        //{
                        //    findElement = HBFElements[HBFElements.IndexOf(myElement) + 1] as ZYTextElement;
                        //    break;
                        //}
                        if (findLine.Elements.IndexOf(myElement) < findLine.Elements.Count - 1)
                        {
                            if (myElement is ZYTextDocumentLib.ZYTextImage) //2014-07-25 �����ر�ؼ�����>����ͼƬ�Ҽ��༭�ͱ��湦��
                            {
                                findElement = myElement;
                                break;
                            }
                            else
                            {
                                findElement = findLine.Elements[findLine.Elements.IndexOf(myElement) + 1] as ZYTextElement;
                                break;
                            }
                        }
                        else
                        {
                            findElement = myElement; //2014-07-30 ���ѡ���ĵ�Ԫ��ʱ����MoveToInSelectingArea�����µ������ݵ�������
                            break;
                        }
                    }
                }
                #endregion

                return findElement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ȡ�ĵ���ͼ����ָ����λ�ô��ĵ�Ԫ���ڲ��ĵ��ж���
        /// </summary>
        /// <param name="cell">����ָ����ĵ�Ԫ��</param>
        /// <param name="x">ָ�����X���ꡣ</param>
        /// <param name="y">ָ�����Y���ꡣ</param>
        /// <returns></returns>
        private ZYTextLine MoveCaretInCell(TPTextCell cell, int x, int y)
        {
            try
            {
                Rectangle rect = cell.GetContentBounds(); //��ǰ��Ԫ������о���
                ZYTextLine firstLine = cell.Lines[0] as ZYTextLine; //��ǰ��Ԫ���ڵ�һ���ı��ж��󣬼���һ������Ԫ��
                ZYTextLine lastLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine; //��ǰ��Ԫ�������һ���ı��ж��󣬼����һ������Ԫ��

                ZYTextLine findLine = null;
                if (y >= rect.Top
                    && y < firstLine.RealTop) //��Ԫ����Ͽհ״�����>��Ԫ�񶥶����ڲ���һ���ı��ж���֮��Ŀհ������ϲ��ڱ߾ࣩ
                {
                    findLine = cell.Lines[0] as ZYTextLine; //��Ԫ����ڲ���һ���ı��ж���
                }
                else if (y > lastLine.RealTop + lastLine.Height
                    && y <= rect.Bottom) //��Ԫ����¿հ״�����>��һ�����²��ڱ߾࣬׼ȷ��˵�ǵ�Ԫ��׶����ڲ����һ���ı��ж���֮��Ŀհ�����
                {
                    findLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine; //��Ԫ����ڲ����һ���ı��ж���
                }
                else //��Ԫ����ڲ���������
                {
                    foreach (ZYTextLine paraLine in cell.Lines) //��Ԫ���Lines�洢�����ڲ�Ԫ��
                    {
                        if (y < paraLine.RealTop) //Y����λ�ڵ�ǰ�����ı��ж���Ķ�������һ�������ı��ж���֮��Ŀհ����򣨶��������֮������м�ࣩ
                        {
                            findLine = paraLine;
                            break;
                        }
                        else if (y >= paraLine.RealTop
                            && y <= paraLine.RealTop + paraLine.Height) //Y����λ�ڵ�ǰ�����ı��ж�����ڲ�����
                        {
                            findLine = paraLine;
                            break;
                        }
                    }
                }

                if (findLine == null) //�������>����ڴ˵�Ԫ���ڻ�û���ҵ������ı��ж�������findLineΪ�˵�Ԫ���ڵ�һ���ı��ж���
                {
                    findLine = cell.Lines[0] as ZYTextLine;
                }

                return findLine;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����ǰ��꣨��������ƶ����ĵ���ͼ���ڵ�ָ����λ�ã���갴���¼����ã���
        /// </summary>
        /// <param name="x">ָ�����X���ꡣ</param>
        /// <param name="y">ָ�����Y���ꡣ</param>
        public void MoveToNoSelectingArea(int x, int y)
        {
            try
            {
                if (myDocument == null) return;
                ZYTextElement findElement = GetElementAt(x, y);

                if (findElement == null) return; //2014-08-21 ���findElementΪnull����ֱ�ӷ��ر�������쳣

                int index = HBFElements.IndexOf(findElement);
                this.MoveSelectStart(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����ǰ��꣨��������ƶ����ĵ���ͼ���ڵ�ָ����λ�ã�����ƶ��¼����ã�����ֻ���ѡ���ĵ�Ԫ�أ���
        /// </summary>
        /// <param name="x">ָ�����X���ꡣ</param>
        /// <param name="y">ָ�����Y���ꡣ</param>
        public void MoveToInSelectingArea(int x, int y)
        {
            try
            {
                if (myDocument == null) return;
                ZYTextElement findElement = GetElementAt(x, y);

                if (findElement == null) return; //2014-08-21 ���findElementΪnull����ֱ�ӷ��ر�������쳣

                int index = HBFElements.IndexOf(findElement);

                ZYTextLine findLine = findElement.OwnerLine;
                x -= findLine.RealLeft; //��X���껻��������findLine��˵�X����
                if (x > findElement.Left + findElement.Width / 2
                    && findLine.Elements.IndexOf(findElement) == findLine.Elements.Count - 1) //X����λ��findElement��һ����������findLine�����һ���ĵ�Ԫ��
                {
                    index += 1; //����ƶ����س��������Ԫ�أ�ע���ĵ����һ���س���Ҫ����Խ�磬���ں�������������Խ���жϣ�
                }

                this.MoveSelectStart(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����ǰ��꣨��������ƶ����ĵ���ͼ���ڵ�ָ���ĵ�Ԫ��ǰ�档
        /// </summary>
        /// <param name="refElement">ָ�����ĵ�Ԫ�ء�</param>
        /// <returns>�����Ƿ�ɹ���</returns>
        public bool MoveSelectStart(ZYTextElement refElement)
        {
            try
            {
                if (HBFElements.IndexOf(refElement) >= 0)
                {
                    return MoveSelectStart(HBFElements.IndexOf(refElement));
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����ǰ��꣨��������ƶ����ĵ���ͼ���ڵ�ָ�������ŵ��ĵ�Ԫ��ǰ�档
        /// </summary>
        /// <param name="index">ָ�����ĵ�Ԫ�������š�</param>
        /// <returns>�����Ƿ�ɹ���</returns>
        public bool MoveSelectStart(int index)
        {
            try
            {
                if (index != HBFElements.Count) //���index == HBFElements.Count�����ʾѡ���ĵ����һ���س�������ʱ������Խ���顪��>���ǵ��ĵ�����һ���س�����ѡ�����
                {
                    index = FixIndex(index);
                }
                int length = bolAutoClearSelection ? 0 : intSelectLength + intSelectStart - index;
                return SetSelection(index, length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ������ѡ������Ŀ�ʼλ�ú�ѡ�����ȡ�
        /// </summary>
        /// <param name="NewSelectStart">��ѡ������Ŀ�ʼλ�á���>�ĵ��ɼ�Ԫ���б��е������š�</param>
        /// <param name="NewSelectLength">��ѡ�������ѡ�񳤶ȡ�</param>
        /// <returns>�����Ƿ�ɹ���</returns>
        public bool SetSelection(int NewSelectStart, int NewSelectLength)
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return false;

                if (NewSelectStart != HBFElements.Count) //ѡ���ĵ����һ���س���ʱ������Խ����
                {
                    NewSelectStart = FixIndex(NewSelectStart);
                }

                //��ѡ������δ�����ı䣬��ִ�к��������
                if (intSelectStart == NewSelectStart && intSelectLength == NewSelectLength) return true;

                #region ���⴦��
                //������δ���Ϊ�����û�ֻѡ���ĵ����һ���س����ֻص���ѡ��ʱ���������
                if (intSelectStart == HBFElements.Count && NewSelectLength - intSelectLength == 1)
                {
                    if (myDocument != null && myDocument.OwnerControl != null)
                    {
                        intSelectStart = FixIndex(NewSelectStart);
                        intSelectLength = NewSelectLength;
                        FixSelection();
                        myDocument.OwnerControl.Invalidate();
                        return true;
                    }
                }
                #endregion

                int OldSelectStart = intSelectStart; //��꣨����������ڵľ�λ��

                #region �����ѡ��Ԫ�ز���
                //���û��ѡ�����ɸ�Ԫ�أ�����˵δ������갴�²��ƶ�����ѡ�ı�Ԫ�ز���
                //��ʱ��ʾ����ƶ���ĳһԪ�أ������һ��
                if (intSelectLength == 0 && NewSelectLength == 0)
                {
                    intSelectStart = NewSelectStart; //���¹���������µ�λ�ã�NewSelectStart����FixIndex��������λ���Ƿ�Խ��

                    if (myDocument != null)
                    {
                        myDocument.SelectionChanged(OldSelectStart, 0, intSelectStart, 0);
                    }

                    if (OldSelectStart >= 0 && OldSelectStart < HBFElements.Count) //���������Խ����
                    {
                        ((ZYTextElement)HBFElements[OldSelectStart]).HandleLeave(); //������Ԫ���뿪�¼�
                    }
                    if (intSelectStart >= 0 && intSelectStart < HBFElements.Count) //���������Խ����
                    {
                        ((ZYTextElement)HBFElements[intSelectStart]).HandleEnter(); //������Ԫ�ؽ����¼�
                    }

                    return true;
                }
                #endregion

                #region ���ѡ��Ԫ�ز���
                int SourceStart = 0; //ԭѡ������Ŀ�ʼλ��
                int SourceEnd = 0; //ԭʼѡ������Ľ���λ��
                int DescStart = 0; //��ѡ������Ŀ�ʼλ��
                int DescEnd = 0; //��ѡ������Ľ���λ��

                //���þ�ѡ������Ŀ�ʼ�����λ��
                if (intSelectLength > 0) //����ѡ��
                {
                    SourceStart = intSelectStart;
                    SourceEnd = intSelectStart + intSelectLength;
                }
                else //����ѡ��
                {
                    SourceStart = intSelectStart + intSelectLength;
                    SourceEnd = intSelectStart;
                }

                //������ѡ������Ŀ�ʼ�����λ��
                if (NewSelectLength > 0) //����ѡ��
                {
                    DescStart = NewSelectStart;
                    DescEnd = NewSelectStart + NewSelectLength;
                }
                else //����ѡ��
                {
                    DescStart = NewSelectStart + NewSelectLength;
                    DescEnd = NewSelectStart;
                }

                //����λ��
                int temp = 0;
                if (SourceStart > DescStart) //ʹ�þ�ѡ������Ŀ�ʼλ��λ����ѡ������Ŀ�ʼλ����ࣨ��Ϊ����λ�ô�С�������У�
                {
                    temp = SourceStart;
                    SourceStart = DescStart;
                    DescStart = temp;
                }
                if (SourceEnd > DescEnd) //ʹ�þ�ѡ������Ľ���λ��λ����ѡ������Ľ���λ����ࣨ��Ϊ����λ�ô�С�������У�
                {
                    temp = SourceEnd;
                    SourceEnd = DescEnd;
                    DescEnd = temp;
                }
                //��ע��[SourceStart->DescStart] �� [DescStart->DescEnd] Ϊ�ĵ���ѡ��״̬�����ı��Ԫ�ص���ŷ�Χ

                intSelectStart = NewSelectStart; //�����µĲ������ʼλ��
                intSelectLength = NewSelectLength; //�����µ����ѡ������

                if (NewSelectStart != HBFElements.Count) //ѡ���ĵ����һ���س���ʱ������Խ����
                {
                    FixSelection();
                    SourceStart = FixIndex(SourceStart);
                    SourceEnd = FixIndex(SourceEnd);
                    DescStart = FixIndex(DescStart);
                    DescEnd = FixIndex(DescEnd);
                }

                if (SourceStart != DescStart)
                {
                    for (int iCount = SourceStart; iCount <= DescStart; iCount++)
                    {
                        if (iCount >= 0 && iCount < HBFElements.Count)
                        {
                            if (((ZYTextElement)HBFElements[iCount]).HandleSelectedChange()) return false;
                        }
                    }
                }
                if (SourceEnd != DescEnd)
                {
                    for (int iCount = SourceEnd; iCount <= DescEnd; iCount++)
                    {
                        if (iCount >= 0 && iCount < HBFElements.Count)
                        {
                            if (((ZYTextElement)HBFElements[iCount]).HandleSelectedChange()) return false;
                        }
                    }
                }

                if (myDocument != null)
                {
                    myDocument.SelectionChanged(SourceStart, SourceEnd, DescStart, DescEnd);
                }

                if (OldSelectStart >= 0 && OldSelectStart < HBFElements.Count) //���������Խ����
                {
                    ((ZYTextElement)HBFElements[OldSelectStart]).HandleLeave(); //������Ԫ���뿪�¼�
                }
                if (intSelectStart >= 0 && intSelectStart < HBFElements.Count) //���������Խ����
                {
                    ((ZYTextElement)HBFElements[intSelectStart]).HandleEnter(); //������Ԫ�ؽ����¼�
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ��ɫ���ơ���>�����޶���2014-08-06
        /// <summary>
        /// �ж�ָ�����ĵ�Ԫ���Ƿ�ѡ�С�
        /// </summary>
        /// <param name="myElement">ָ�����ĵ�Ԫ�ء�</param>
        /// <returns>�Ƿ�ѡ�С�</returns>
        public bool isSelected(ZYTextElement myElement)
        {
            try
            {
                if (intSelectLength == 0 || myElement == null) return false;
                if (!HBFElements.Contains(myElement)) return false;
                int index = myElement.Index;
                if (intSelectLength > 0
                    && index >= intSelectStart
                    && index < intSelectStart + intSelectLength) return true;
                if (intSelectLength < 0
                    && index >= intSelectStart + intSelectLength
                    && index < intSelectStart) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ʶ��ǰ�����ѡ�ĵ�Ԫ�ز����Ƿ����ͬһ������ڡ�
        /// </summary>
        private bool selectingAreaInOneTable = false;
        /// <summary>
        /// ����һ������ֵ����ʶ��ǰ�����ѡ�ĵ�Ԫ�ز����Ƿ����ͬһ������ڡ�
        /// </summary>
        public bool SelectingAreaInOneTable
        {
            get { return selectingAreaInOneTable; }
        }

        /// <summary>
        /// ���ñ�ʾ�����ѡ�ĵ�Ԫ�ز����Ƿ����ͬһ������ڵĲ�����־�ֶΣ�ZYContent���е�selectingAreaInOneTable������ZYEditorControl���OnViewPaint�������ã���
        /// </summary>
        public void CheckSelectingAreaInOneTable()
        {
            try
            {
                ArrayList currSelectParas = GetSelectParagraph(); //ѡ��������伯��
                if (currSelectParas.Count <= 0) //�ж�ѡ��������伯���Ƿ�Ϊ��
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                if (myDocument.SelectedCells.Count == 0) //2014-08-06 ��һ���س���������ѡ��������һ����Ԫ��ʱ����ȷ�ж�����Ϊֻ��������˵�Ԫ��֮������ѡ��Ԫ��Ż���myDocument.SelectedCells������Ϊ0
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                ZYTextParagraph firstPara = currSelectParas[0] as ZYTextParagraph; //ѡ�������һ������
                ZYTextParagraph lastPara = currSelectParas[currSelectParas.Count - 1] as ZYTextParagraph; //ѡ���������һ������

                //�����һ�����䲻�ڵ�Ԫ���У���϶�����ͬһ������ڵ���ѡ��Ԫ�����
                if (!(firstPara.Parent is TPTextCell))
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                //�����һ�������ڵ�Ԫ���У������һ�����䲻�ڵ�Ԫ���У���϶�����ͬһ������ڵ���ѡ��Ԫ�����
                if (!(lastPara.Parent is TPTextCell))
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                TPTextCell firstCell = firstPara.Parent as TPTextCell; //ѡ�������һ����Ԫ��
                TPTextCell lastCell = lastPara.Parent as TPTextCell; //ѡ���������һ����Ԫ��
                //�����һ����Ԫ������һ����Ԫ�񶼴���ͬһ������ڣ��򷵻�true��ʾ��ͬһ������ڵ���ѡ��Ԫ�����
                if (firstCell.OwnerRow.OwnerTable.GetContentBounds() == lastCell.OwnerRow.OwnerTable.GetContentBounds())
                {
                    selectingAreaInOneTable = true; //add by myc 2014-07-30 ��ɫ����������Ҫ
                }
                else
                {
                    selectingAreaInOneTable = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// �����ѡ�ĵ�Ԫ�ز���ʱ����ѡ�����ĵ�Ԫ�ص����о���������з�ɫ���������ƣ�����
        /// </summary>
        /// <param name="myLine">ָ�����ĵ��ж���</param>
        /// <param name="HeightLightRect">��ͼ�������ʾ�Ĵ���ɫ�����������</param>
        public void HighlightSelectingArea(ZYTextLine myLine, Rectangle heightLightRect)
        {
            try
            {
                if (myLine.Container is ZYTextParagraph) //��ǰ�ĵ��ж���������������Ϊ����
                {
                    Rectangle rect = Rectangle.Empty; //�����跴ɫ�����������
                    ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                    if (para.Parent is TPTextCell) //��ǰ����λ�ڵ�Ԫ����
                    {
                        /*
                         2021-04-01
                        �ϲ���Ԫ���ҳʱ��ѡ��������Ҫ���з�ɫ���ƣ�����Ԫ���ҳʱ����һҳ�����ˣ���һҳ�ڻ���һ�Σ��ͻᵼ����Ч��
                        ��һ����������ʹ���ֶ��жϽ�������һ�λ��ƣ����⣺�����ִ��ڿ�ҳ�и���ʾʱ���޷��и���Ʒ�ɫ����
                        �ڶ�������������ҳ��λ��ƣ�ÿҳֻ���Ƶ�ǰҳ�и�ķ�ɫ����
                         */
                        Rectangle pagerect = myDocument.Pages[myDocument.PageIndex].Bounds;
                        if (pagerect.IntersectsWith(heightLightRect))
                            heightLightRect.Intersect(pagerect);



                        TPTextCell cell = para.Parent as TPTextCell;
                        if (selectingAreaInOneTable) //ͬһ������ڵ������ѡ����
                        {
                            //if (cell.CanAccess && myDocument.SelectedCells.Count == 1) //��ǰ������ĵ�Ԫ�񣬲���δ��ѡ�С���>�����һ����Ԫ���ڲ���ѡ���ĵ�Ԫ�ز���
                            //{
                            //    if (heightLightRect.Width > 0)
                            //    {
                            //        rect = myDocument.GetReversibleRect(heightLightRect);
                            //        //cell.Selected = false;
                            //    }
                            //}


                            //��ע��
                            //if (cell.Selected && myDocument.SelectedCells.Count > 1) //�ѱ�ѡ�е����ɸ���Ԫ��
                            //{
                            //    //��Ԫ���ѱ�ѡ�У����ɵ�Ԫ���RefreshView������ɷ�ɫ����
                            //}
                        }
                        else //��ͬһ������ڵ������ѡ��������ʵ�ʵ�heightLightRect�ж��Ƿ�����Ԫ��Ϊѡ��״̬
                        {
                            //if (heightLightRect.Width > 0)
                            //{
                            //    cell.Selected = true; //�õ�Ԫ��ѡ�У����ɵ�Ԫ���RefreshView������ɷ�ɫ����
                            //}

                            //if (cell.CanAccess && myDocument.SelectedCells.Count == 0) //�°淴ɫ��������2014-08-06 ��ǰ������ĵ�Ԫ�񣬲���δ��ѡ�С���>�����һ����Ԫ���ڲ���ѡ���ĵ�Ԫ�ز���
                            //2014-10-29 myc ����ϲ�������������Ԫ��֮�������Ƹ����ȱ�������У��
                            if ((myDocument.Content.SelectLength < 0
                                ? (myDocument.Content.SelectStart + myDocument.Content.SelectLength < myDocument.Content.HBFElements.Count
                                   && myDocument.GetOwnerCell(HBFElements[myDocument.Content.SelectStart + myDocument.Content.SelectLength] as ZYTextElement) != null)
                                : (myDocument.Content.SelectStart + myDocument.Content.SelectLength < myDocument.Content.HBFElements.Count
                                   && myDocument.GetOwnerCell(HBFElements[myDocument.Content.SelectStart + myDocument.Content.SelectLength] as ZYTextElement) != null)
                                )
                                && myDocument.SelectedCells.Count == 0) //2014-08-08 �µ�Ԫ����ѡ���ı��ж���ʽ
                            {
                                if (heightLightRect.Width > 0)
                                {
                                    rect = myDocument.GetReversibleRect(heightLightRect);
                                    //cell.Selected = false;
                                }
                            }
                            else //����ѡ���ĵ�Ԫ��ʱ�ĵ�Ԫ��ɫ����
                            {
                                if (heightLightRect.Width > 0)
                                {
                                    cell.Selected = true; //�õ�Ԫ��ѡ�У����ɵ�Ԫ���RefreshView������ɷ�ɫ����
                                }
                            }
                        }
                    }
                    else //��ǰ���䲻λ�ڵ�Ԫ����
                    {
                        if (heightLightRect.Width > 0)
                        {
                            rect = myDocument.GetReversibleRect(heightLightRect);
                        }
                    }

                    if (!rect.IsEmpty)
                    {
                        if (myDocument.OwnerControl != null && !myDocument.EnableSelectAreaPrint)
                        {
                            myDocument.OwnerControl.ReversibleViewFillRect(rect, myDocument.View.Graph);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ɾ��Ԫ�ء���>�����޶���2014-08-07
        /// <summary>
        /// ��õ�ǰ�������λ�ô����ĵ�Ԫ�ء�
        /// </summary>
        public ZYTextElement CurrentElement
        {
            get
            {
                ZYTextElement myElement = null;
                if (HBFElements.Count == 0) return null;
                if (HBFElements != null
                    && intSelectStart >= 0 && intSelectStart < HBFElements.Count)
                {
                    myElement = (ZYTextElement)HBFElements[intSelectStart];
                }
                else
                {
                    myElement = (ZYTextElement)HBFElements[HBFElements.Count - 1];
                }

                return myElement;
            }
            set
            {
                if (HBFElements.Contains(value))
                {
                    this.MoveSelectStart(HBFElements.IndexOf(value));
                }
                intSelectStart = this.FixIndex(intSelectStart);
            }
        }

        /// <summary>
        /// �ж��ĵ���ͼ�������Ƿ���ڱ�ѡ����ĵ�Ԫ�ض���
        /// </summary>
        /// <returns></returns>
        public bool HasSelected()
        {
            try
            {
                return (intSelectLength != 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ���ָ��Ԫ�ص������Ƿ������޸ġ�
        /// </summary>
        /// <param name="index">ָ��������</param>
        /// <returns>�Ƿ�������</returns>
        public bool IsLock(int index)
        {
            try
            {
                if (index >= 0)
                {
                    if (index == HBFElements.Count) //���������������>���ѡ���ĵ����һ��Ԫ��ʱ
                    {
                        index = HBFElements.Count - 1;
                    }

                    for (int iCount = index; iCount < HBFElements.Count; iCount++)
                    {
                        if (HBFElements[iCount] is ZYTextLock)
                        {
                            ZYTextLock Lock = (ZYTextLock)HBFElements[iCount];
                            if (Lock.Level >= intUserLevel) return true;
                        }
                    }
                    //�̶��ı�����ɾ
                    if (HBFElements[index] is ZYFixedText || HBFElements[index] is ZYText) return true;

                    //2019.10.01-hdf��ѡ��Ԫ�������˲�����ɾ����ֻ����˫��¼��
                    ZYTextElement rele = HBFElements[index] as ZYTextElement;
                    ZYTextElement lele = new ZYTextElement();
                    if (index > 0) lele = HBFElements[index - 1] as ZYTextElement;

                    if (rele.Parent == lele.Parent
                        && (rele.Parent is ZYSelectableElement || rele.Parent is ZYFormatNumber || rele.Parent is ZYFormatDatetime || rele.Parent is ZYPromptText))
                    {
                        //YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("��Ԫ�����ò�����ɾ��ֻ��˫��¼�룡");
                        return true;
                    }
                    else if (rele.Parent == lele.Parent && rele.Parent is ZYFixedText)
                    {
                        //YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("��ǩԪ���޷��༭��");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ǰѡ������ľ��Կ�ʼλ�á�
        /// </summary>
        public int AbsSelectStart
        {
            get
            {
                if (intSelectLength >= 0) //��귴��ѡ���ĵ�Ԫ��
                {
                    return intSelectStart;
                }
                else //�������ѡ���ĵ�Ԫ��
                {
                    return intSelectStart + intSelectLength;
                }
            }
        }

        /// <summary>
        /// ��ǰѡ������ľ��Խ���λ�á�
        /// </summary>
        public int AbsSelectEnd
        {
            get
            {
                int intValue;
                if (intSelectLength >= 0) //��귴��ѡ���ĵ�Ԫ��
                {
                    intValue = intSelectStart + intSelectLength;
                }
                else  //�������ѡ���ĵ�Ԫ��
                {
                    intValue = intSelectStart;
                }
                return intValue;
            }
        }

        /// <summary>
        /// ��ȡ��ǰ���ѡ�������ڵ������ı�����Ԫ�أ������س�������
        /// </summary>
        /// <returns>���ذ�������ѡ���ĵ�Ԫ�ص��б�</returns>
        public System.Collections.ArrayList GetSelectElements()
        {
            try
            {
                if (HBFElements == null)
                    return null;
                else
                {
                    System.Collections.ArrayList myList = new System.Collections.ArrayList();
                    int intEnd = this.AbsSelectEnd;
                    for (int iCount = this.AbsSelectStart; iCount < intEnd; iCount++)
                        myList.Add(HBFElements[iCount]);
                    return myList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// �������ѡ������Ķ���Ԫ�ء�
        /// </summary>
        /// <returns>���ذ�������ѡ���ĵ�����Ԫ�ص��б�������ʧ���򷵻ؿ����á�</returns>
        public System.Collections.ArrayList GetSelectParagraph()
        {
            try
            {
                if (HBFElements == null) return null;
                ArrayList myList = new System.Collections.ArrayList();
                int intEnd = this.AbsSelectEnd;
                for (int iCount = this.AbsSelectStart; iCount < intEnd; iCount++)
                {
                    ZYTextElement currElement = HBFElements[iCount] as ZYTextElement;
                    ZYTextContainer currContainer = null;
                    if (currElement.Parent is ZYTextBlock) //�ı��������ڲ����ı��ַ�Ԫ�������⴦��
                    {
                        currContainer = currElement.Parent.Parent;
                    }
                    else
                    {
                        currContainer = currElement.Parent;
                    }

                    if (currContainer is ZYTextParagraph)
                    {
                        if (!myList.Contains(currContainer))
                        {
                            myList.Add(currContainer);
                        }
                    }
                }
                return myList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����ָ���Ķ��伯�ϣ���ȡ��λ�ڲ�ͬ����ڵĶ���������Ԫ�񼯺ϣ��������һ���ֵ��б��桪��>��ɾ��ѡ���������ĵ�Ԫ�����̵��á�
        /// </summary>
        /// <param name="selectedParas">ָ����ѡ�ж��伯�ϡ�</param>
        /// <returns></returns>
        private Dictionary<TPTextTable, List<TPTextCell>> GetSelectedElementsInTable(ArrayList selectedParas)
        {
            try
            {
                List<TPTextCell> DeleteElementsInCells = new List<TPTextCell>(); //�洢ͬһ������ڵĶ���������Ԫ��
                Dictionary<TPTextTable, List<TPTextCell>> DeleteElementsInTables = new Dictionary<TPTextTable, List<TPTextCell>>();
                if (selectedParas == null) //û��ָ��ѡ�еĶ��伯�ϱ�ʾ��ͬһ������ڵ������ѡ���ɸ���Ԫ�����
                {
                    foreach (TPTextCell cell in myDocument.SelectedCells)
                    {
                        if (cell.ChildCount == 0) continue; //����ռλ��Ԫ��
                        DeleteElementsInCells.Add(cell);
                    }
                    DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                    return DeleteElementsInTables;
                }

                //����Ϊ������ѡ���ĵ�Ԫ��ʱ��DeleteElementsInTables���������
                foreach (ZYTextParagraph para in selectedParas)
                {
                    if (para.Parent is TPTextCell) //��ǰ����λ�ڵ�Ԫ����
                    {
                        TPTextCell cell = para.Parent as TPTextCell;
                        if (DeleteElementsInCells.Contains(cell)) //�Ѿ�������ɾ���ĵ�Ԫ�����
                        {
                            if (selectedParas.IndexOf(para) == selectedParas.Count - 1) //�������Ƿ�Ϊѡ�����������һ������Ԫ��
                            {
                                DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                DeleteElementsInCells = new List<TPTextCell>();
                            }
                        }
                        else //��������ɾ���ĵ�Ԫ�����
                        {
                            if (DeleteElementsInCells.Count == 0)
                            {
                                DeleteElementsInCells.Add(cell);
                                if (selectedParas.IndexOf(para) == selectedParas.Count - 1) //�������Ƿ�Ϊѡ�����������һ������Ԫ��
                                {
                                    DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                    DeleteElementsInCells = new List<TPTextCell>();
                                }
                            }
                            else
                            {
                                if (DeleteElementsInCells[DeleteElementsInCells.Count - 1].OwnerRow.OwnerTable.GetContentBounds()
                                    == cell.OwnerRow.OwnerTable.GetContentBounds()) //��ǰ��Ԫ����DeleteElementsInCells���Ѵ洢�ĵ�Ԫ��λ��ͬһ�������
                                {
                                    DeleteElementsInCells.Add(cell);
                                    if (selectedParas.IndexOf(para) == selectedParas.Count - 1) //�������Ƿ�Ϊѡ�����������һ������Ԫ��
                                    {
                                        DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                        DeleteElementsInCells = new List<TPTextCell>();
                                    }
                                }
                                else //��ǰ��Ԫ����DeleteElementsInCells���Ѵ洢�ĵ�Ԫ��λ��ͬһ�������
                                {
                                    DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                    DeleteElementsInCells = new List<TPTextCell>();
                                    DeleteElementsInCells.Add(cell);
                                }
                            }
                        }
                    }
                    else //��ǰ���䲻λ�ڵ�Ԫ����
                    {
                        if (DeleteElementsInCells.Count > 0)
                        {
                            DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                            DeleteElementsInCells = new List<TPTextCell>();
                        }
                    }
                }

                return DeleteElementsInTables;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UsId = null;//ǩ��ͼƬ��Ӧ���û�id
        /// <summary>
        /// ɾ����ǰλ�����ѡ�������ڵ������ĵ�Ԫ�أ����Ҵ������Ѿ�����÷Ǳ�����ĵ�Ԫ�������ɸ�������ĵ�Ԫ�ؽ���ʱ��ɾ��Ԫ���Լ���������ջ������
        /// </summary>
        /// <returns>�Ƿ�ɾ���ɹ���</returns>
        public bool DeleteSelectedElements()
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return false; //���Ԫ���б�Ϊ�գ���ֱ�ӷ���false
                if (IsLock(intSelectStart)) return false; //���������ǰ�����λ�ã���ֱ�ӷ���false
                int OldSelectStart = this.AbsSelectStart; //�ȱ��浱ǰ���λ�ã�ɾ�����������󽫾ݴ˻�ԭ
                if ((HBFElements[AbsSelectStart] as ZYTextElement).Parent is ZYTextBlock) //2014-08-07 �ı���Ԫ������ѡ��������Կ�ʼ����λ��
                {
                    OldSelectStart = (HBFElements[AbsSelectStart] as ZYTextElement).Parent.FirstElement.Index;
                }


                //if ((!selectingAreaInOneTable && myDocument.GetOwnerCell(HBFElements[AbsSelectStart] as ZYTextElement) == null) //2014-08-07 ����GetOwnerCell�жϷǳ��ؼ�
                //    || (selectingAreaInOneTable && myDocument.SelectedCells.Count > 1))
                if (myDocument.SelectedCells.Count == 0
                    && myDocument.GetOwnerCell(HBFElements[intSelectStart + intSelectLength] as ZYTextElement) != null) //2014-08-13 ����ԭ�жϷ�ʽ��У������ɾ��������׼ȷ��
                {
                    //ѡ��Ԫ������λ�þ���˵������>
                    // 1��ѡ��Ԫ��λ��ͬһ������ڲ���ֻ��һ����Ԫ�񱻵������ʱselectingAreaInOneTable = true && myDocument.SelectedCells.Count == 0��

                    //��ǰ��ѡ�е��ı�����Ԫ�أ������س�����
                    ArrayList selectedChars = this.GetSelectElements();
                    //��ǰѡ�������ڵĶ��伯��
                    ArrayList selectedParas = this.GetSelectParagraph();
                    //�����ı��ַ���ɾ���б����洢��ɾ�����ַ�
                    ArrayList deleteList = new ArrayList();
                    //����Ԫ�ص�ɾ�������б����洢��ɾ����Ԫ��
                    ArrayList deleteRealList = new ArrayList();

                    #region �ж��Ƿ�ִ������ɾ������
                    int intDelete = 0;
                    deleteRealList = myDocument.GetRealElements(selectedChars);
                    foreach (ZYTextElement ele in deleteRealList)
                    {
                        intDelete = myDocument.isDeleteElement(ele);
                    }
                    if (intDelete != 0) return false; //����ִ������ɾ��������ֱ�ӷ���false
                    if (!this.Document.DeleteFlag) //�ж��Ƿ���ɾ���̶��ı�
                    {
                        //if (this.Document.Info.DocumentModel != DocumentModel.Design) //��ǰ�ĵ����󲻴������״̬
                        //{
                        foreach (ZYTextElement ele in selectedChars)
                        {
                            bool candelete = CanDeleteElement(ele);
                            if (!candelete) return false;  //�������ɾ���򷵻�
                            ////����̶��ı�
                            //if (ele.Parent is ZYFixedText || ele.Parent is ZYText)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                            //    return false;
                            //}
                            ////����ť
                            //if (ele is ZYButton && !((ZYButton)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                            //    return false;
                            //}
                            ////����λ��
                            //if (ele is ZYFlag && !((ZYFlag)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                            //    return false;
                            //}
                        }
                        //}
                    }
                    #endregion

                    #region ɾ����ǰ��Ԫ����ѡ��Ԫ��
                    //��ǰ����λ��һ����Ԫ���ڡ���>������ע�ⵥԪ���ڱ�������һ���س����ṩ���û�����
                    for (int i = 0; i < selectedParas.Count; i++) //������������߲������޸ģ����Բ���forѭ����ʽ����
                    {
                        ZYTextParagraph para = selectedParas[i] as ZYTextParagraph;

                        //��ȡ��ǰ�����е������ı��ַ��������˹�����ɾ��������Ԫ���б�
                        deleteList.Clear();
                        int paraStartIndex = para.FirstElement.Index; //�����һ��Ԫ�ص��������
                        if (para.FirstElement is ZYTextBlock)
                        {
                            paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                        }
                        int paraEndIndex = para.LastElement.Index; //�������һ��Ԫ�أ��س��������������
                        ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);
                        foreach (ZYTextElement ele in paraChars)
                        {
                            if (selectedChars.Contains(ele))
                            {
                                deleteList.Add(ele);
                            }
                        }
                        deleteRealList = myDocument.GetRealElements(deleteList);

                        //���ΪͼƬ��ɾ�����ݿ���ͼƬ��¼
                        //foreach (var item in deleteRealList)
                        //{
                        //    if (item is ZYTextDocumentLib.ZYTextImage)
                        //    {
                        //        string imageId = (item as ZYTextDocumentLib.ZYTextImage).CurrentImageID;
                        //        string _sql = string.Format("delete from RecordImage where id = '{0}'", imageId);
                        //        int nonQueryCount = YiDanSqlHelper.YD_SqlHelper.ExecuteNonQuery(_sql);
                        //    }
                        //}

                        #region 2019.7.31-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ��Ҫ������¼�������޸��ı�
                        if (selectedParas.Count == 1 && deleteRealList.Count == 1 && (deleteRealList[0] is ZYMacro || deleteRealList[0] is ZYFormatString || deleteRealList[0] is ZYReplace || deleteRealList[0] is ZYDiag || deleteRealList[0] is ZYSubject))
                        {
                            //��ѡ������Ϊ��Ԫ���У������Ǻ�Ԫ�ء���ʽ���ַ�����������Ŀ����ɾ���ı�����ɾ����Ԫ�أ����λ��������
                            OldSelectStart = this.AbsSelectStart;
                            //�жϵ�ǰѡ���Ƿ�Ϊ��Ԫ��ȫ���ı�
                            if ((deleteRealList[0] as ZYTextBlock).ChildCount == deleteList.Count)
                            {
                                //�ж�Ԫ���Ƿ���ɾ��
                                if ((deleteRealList[0] as ZYTextBlock).CanDelete || this.Document.Info.DocumentModel == DocumentModel.Design)
                                {
                                    para.RemoveChildRange(deleteRealList);
                                }
                                else
                                {
                                    if (Document.CanContentChangeLog)
                                    {
                                        Document.ContentChangeLog.Container = deleteRealList[0] as ZYTextBlock;
                                        Document.ContentChangeLog.LogProperty((deleteRealList[0] as ZYTextBlock), (deleteRealList[0] as ZYTextBlock).GetType().GetProperty("Text"), (deleteRealList[0] as ZYTextBlock).Text, (deleteRealList[0] as ZYTextBlock).Name);
                                    }
                                    (deleteRealList[0] as ZYTextBlock).Text = (deleteRealList[0] as ZYTextBlock).Name;
                                    (deleteRealList[0] as ZYTextBlock).RefreshSize();
                                }
                            }
                            else
                            {
                                (deleteRealList[0] as ZYTextBlock).RemoveChildRange(deleteList);
                                if (Document.CanContentChangeLog)
                                {
                                    Document.ContentChangeLog.Container = deleteRealList[0] as ZYTextBlock;
                                    Document.ContentChangeLog.LogField((deleteRealList[0] as ZYTextBlock), (deleteRealList[0] as ZYTextBlock).GetType().GetField("text"), (deleteRealList[0] as ZYTextBlock).text, ZYTextElement.GetElementsText((deleteRealList[0] as ZYTextBlock).ChildElements));
                                }
                                (deleteRealList[0] as ZYTextBlock).text = ZYTextElement.GetElementsText((deleteRealList[0] as ZYTextBlock).ChildElements);
                            }
                        }
                        else if (deleteRealList.Cast<ZYTextElement>().ToList().Exists(e => (e is ZYMacro || e is ZYFormatString || e is ZYReplace || e is ZYDiag || e is ZYSubject) && !(e as ZYTextBlock).CanDelete) && this.Document.Info.DocumentModel != DocumentModel.Design)
                        {
                            //��ѡ�����������Ԫ�ء���ʽ���ַ�����������Ŀ��
                            //List<ZYTextElement> list = new List<ZYTextElement>(deleteRealList.Cast<ZYTextElement>().ToList());
                            //foreach (ZYTextElement ele in list.Where(e => e is ZYMacro || e is ZYFormatString || e is ZYReplace))
                            //{
                            //    if (!(ele as ZYTextBlock).CanDelete)
                            //    {
                            YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                            return false;
                            //    }
                            //}
                        }
                        else
                        {
                        #endregion
                            //��ʼִ��ɾ������
                            if (deleteRealList.Count == para.ChildCount) //ɾ����������
                            {
                                if (para.Parent is TPTextCell && para.Parent.ChildCount == 1)
                                {
                                    if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //�س��������⴦��
                                    {
                                        deleteRealList.RemoveAt(deleteRealList.Count - 1);
                                    }
                                    para.RemoveChildRange(deleteRealList);
                                }
                                else
                                {
                                    para.Parent.RemoveChild(para);
                                }
                            }
                            else //ɾ�������ڱ�ѡ�����ĵ�Ԫ��
                            {
                                if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //�س��������⴦��
                                {
                                    deleteRealList.RemoveAt(deleteRealList.Count - 1);
                                }
                                para.RemoveChildRange(deleteRealList);
                            }
                        }
                    }
                    #endregion

                    if (selectedChars.Count > 0) //����Խ���ж�
                    {
                        TPTextCell cell = myDocument.GetOwnerCell(selectedChars[0] as ZYTextElement);
                        if (cell != null)
                        {
                            cell.AdjustHeight(); //2014-08-07 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                        }
                    }
                }
                else
                {
                    //ѡ��Ԫ������λ�þ���˵������>
                    // 1��ѡ��Ԫ�ز�λ���κ�һ������ڣ���ʱselectingAreaInOneTable = false��
                    // 2��ѡ��Ԫ��λ��ͬһ������ڲ��������ɸ���Ԫ��ѡ�У���ʱselectingAreaInOneTable = true && myDocument.SelectedCells.Count > 1��
                    // 3��ѡ��Ԫ�ز�λ��ͬһ������ڣ����ڽ���ѡ���ĵ�Ԫ�أ���ʱselectingAreaInOneTable = false��

                    //��ǰ��ѡ�е��ı�����Ԫ�أ������س�����
                    ArrayList selectedChars = this.GetSelectElements();
                    //��ǰѡ�������ڵĶ��伯��
                    ArrayList selectedParas = this.GetSelectParagraph();
                    //�����ı��ַ���ɾ���б����洢��ɾ�����ַ�
                    ArrayList deleteList = new ArrayList();
                    //����Ԫ�ص�ɾ�������б����洢��ɾ����Ԫ��
                    ArrayList deleteRealList = new ArrayList();

                    #region Ԥ��������ѡ��Ԫ��
                    //�洢����ڱ�ѡ�е��ı�����Ԫ�أ������س�����
                    ArrayList selectedCharsInTable = new ArrayList();
                    //����ȡ�����ѡ��Ԫ�أ�ѡ�е�Ԫ���ѡ��һ����Ԫ���ڵ��ĵ�Ԫ�ص�������ɾ������
                    Dictionary<TPTextTable, List<TPTextCell>> DeleteElementsInTables = null;

                    if (selectingAreaInOneTable) //ͬһ������ڴ�SelectedCells�еõ�
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(null);

                        //У��ɾ��Ԫ��֮��Ĺ����ʾλ��
                        TPTextCell firstCell = myDocument.GetOwnerCell(selectedChars[0] as ZYTextElement);
                        if (firstCell != null)
                        {
                            ZYTextParagraph firstPara = firstCell.ChildElements[0] as ZYTextParagraph;
                            int paraStartIndex = firstPara.FirstElement.Index; //���俪ʼԪ��������
                            if (firstPara.FirstElement is ZYTextBlock)
                            {
                                paraStartIndex = (firstPara.FirstElement as ZYTextBlock).FirstElement.Index;
                            }
                            OldSelectStart = paraStartIndex;
                        }
                    }
                    else //��һ������ڴ�selectedParas�еõ�
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(selectedParas);
                    }

                    if (DeleteElementsInTables.Count > 0)
                    {
                        //�ȴ�selectedParas���Ƴ����еİ����ڵ�Ԫ���ڵĶ���
                        foreach (List<TPTextCell> cells in DeleteElementsInTables.Values)
                        {
                            foreach (TPTextCell cell in cells)
                            {
                                for (int i = 0; i < cell.ChildCount; i++)
                                {
                                    ZYTextParagraph para = cell.ChildElements[i] as ZYTextParagraph;
                                    selectedParas.Remove(para);

                                    #region �ж��Ƿ�ִ������ɾ��������Ҫ
                                    int paraStartIndex = para.FirstElement.Index; //�����һ��Ԫ�ص��������
                                    if (para.FirstElement is ZYTextBlock)
                                    {
                                        paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                                    }
                                    int paraEndIndex = para.LastElement.Index; //�������һ��Ԫ�أ��س��������������
                                    ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);
                                    foreach (ZYTextElement ele in paraChars)
                                    {
                                        if (!selectedChars.Contains(ele)) //û�а�����selectedChars�ڵ��ı��ַ�Ԫ���ȷ���selectedCharsInTable��
                                        {
                                            selectedCharsInTable.Add(ele);
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                    }

                    selectedCharsInTable.AddRange(selectedChars);
                    #endregion

                    #region �ж��Ƿ�ִ������ɾ������
                    int intDelete = 0;
                    deleteRealList = myDocument.GetRealElements(selectedCharsInTable);
                    foreach (ZYTextElement ele in deleteRealList)
                    {
                        intDelete = myDocument.isDeleteElement(ele);

                        //���ΪͼƬ��ɾ�����ݿ��м�¼
                        //if (ele is ZYTextDocumentLib.ZYTextImage)
                        //{
                        //    string imageId = (ele as ZYTextDocumentLib.ZYTextImage).CurrentImageID;
                        //    string _sql = string.Format("delete from RecordImage where id = '{0}'", imageId);
                        //    int nonQueryCount = YiDanSqlHelper.YD_SqlHelper.ExecuteNonQuery(_sql);
                        //}
                    }
                    if (intDelete != 0) return false; //����ִ������ɾ��������ֱ�ӷ���false
                    if (!this.Document.DeleteFlag) //�ж��Ƿ���ɾ���̶��ı�
                    {
                        //if (this.Document.Info.DocumentModel != DocumentModel.Design) //��ǰ�ĵ����󲻴������״̬
                        // {
                        foreach (ZYTextElement ele in selectedCharsInTable)
                        {
                            //����̶��ı�
                            //if (ele.Parent is ZYFixedText || ele.Parent is ZYText)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                            //    return false;
                            //}
                            ////����ť
                            //if (ele is ZYButton && !((ZYButton)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                            //    return false;
                            //}
                            ////����λ��
                            //if (ele is ZYFlag && !((ZYFlag)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                            //    return false;
                            //}

                            bool canDelete = CanDeleteElement(ele);
                            if (!canDelete) return false;
                        }
                        //}
                    }
                    #endregion

                    #region ɾ�������ѡ��Ԫ��
                    if (DeleteElementsInTables.Count > 0)
                    {
                        int k = 0;
                        foreach (TPTextTable currTB in DeleteElementsInTables.Keys)
                        {
                            k++;
                            int allArea = 0; //�洢ѡ�е�Ԫ�񼯺��ڷ�ռλ��Ԫ������֮��
                            foreach (TPTextCell cell in DeleteElementsInTables[currTB])
                            {
                                Rectangle rect = cell.GetContentBounds();
                                allArea += rect.Width * rect.Height;
                            }

                            //�Ƚ�ѡ�е�Ԫ�����о����ۼ�����뵱ǰ�������Ƿ���ȡ���>���������������屻ѡ��
                            if (currTB.Width * currTB.Height == allArea) //�����Ԫ�ر�ȫ��ѡ��
                            {
                                currTB.Parent.RemoveChild(currTB);
                                //У��ɾ��Ԫ��֮��Ĺ����ʾλ��
                                if (k == 1)
                                {
                                    TPTextCell firstCell = myDocument.GetOwnerCell(selectedChars[0] as ZYTextElement);
                                    if (firstCell != null)
                                    {
                                        ZYTextParagraph firstPara = firstCell.ChildElements[0] as ZYTextParagraph;
                                        int paraStartIndex = firstPara.FirstElement.Index; //���俪ʼԪ��������
                                        if (firstPara.FirstElement is ZYTextBlock)
                                        {
                                            paraStartIndex = (firstPara.FirstElement as ZYTextBlock).FirstElement.Index;
                                        }
                                        OldSelectStart = paraStartIndex;
                                        if (OldSelectStart > 0)
                                        {
                                            OldSelectStart -= 1;
                                        }
                                    }
                                }
                            }
                            else //�����Ԫ��δ��ȫ��ѡ��
                            {
                                foreach (TPTextCell cell in DeleteElementsInTables[currTB])
                                {
                                    //��ʼִ��ɾ������
                                    if (cell.ChildCount > 1)
                                    {
                                        cell.RemoveChildRange(cell.ChildElements.GetRange(0, cell.ChildCount - 1)); //��ɾ����Ԫ���ڳ����һ������֮�����������
                                    }
                                    ZYTextParagraph lastPara = cell.ChildElements[cell.ChildCount - 1] as ZYTextParagraph;
                                    lastPara.RemoveChildRange(lastPara.ChildElements.GetRange(0, lastPara.ChildCount - 1)); //��Ԫ�������һ����������һ���س�������ɾ��
                                    cell.Selected = false;

                                    cell.AdjustHeight(); //2014-08-07 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                                }
                            }
                        }
                    }
                    #endregion
                    XmlDocument doc = new XmlDocument();
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Config.xml";
                    doc.Load(path);    //����Xml�ļ� 

                    #region ɾ���Ǳ����ѡ��Ԫ��
                    if (!selectingAreaInOneTable) //λ��ͬһ������ڵ�ѡ��Ԫ�ز��ܲμ�����ɾ������
                    {
                        //��ǰ���䲻λ�ڵ�Ԫ���ڡ���>������ע��ҳü��ҳ�����ĵ�Ԫ�ؿ�ȫ��ɾ���������ı�������һ���س����ṩ���û�����
                        for (int i = 0; i < selectedParas.Count; i++) //������������߲������޸ģ����Բ���forѭ����ʽ����
                        {
                            ZYTextParagraph para = selectedParas[i] as ZYTextParagraph;
                            //��ȡ��ǰ�����е������ı��ַ��������˹�����ɾ��������Ԫ���б�
                            deleteList.Clear();
                            int paraStartIndex = para.FirstElement.Index; //�����һ��Ԫ�ص��������
                            if (para.FirstElement is ZYTextBlock)
                            {
                                paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                            }
                            int paraEndIndex = para.LastElement.Index; //�������һ��Ԫ�أ��س��������������
                            ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);
                            foreach (ZYTextElement ele in paraChars)
                            {
                                if (selectedChars.Contains(ele))
                                {
                                    deleteList.Add(ele);
                                    if (ele.ToString() == "ZYTextDocumentLib.ZYTextImage")
                                    {
                                        string userid = ((ZYTextDocumentLib.ZYTextImage)(ele)).ImageByUserID;
                                        XmlElement root = doc.DocumentElement;
                                        XmlElement selectEle = (XmlElement)root.SelectSingleNode(@"QmImgByUserid");
                                        if (selectEle == null)
                                        {
                                            continue;
                                        }
                                        string[] ss = selectEle.InnerText.Split(',');
                                        string newidlist = "";
                                        if (!selectEle.InnerText.Contains(userid))
                                        {
                                            continue;
                                        }
                                        for (int it = 0; it < ss.Length; it++)
                                        {
                                            if (ss[it] != userid)
                                            {
                                                newidlist += ss[it] + ",";
                                            }
                                        }

                                        selectEle.InnerText = newidlist.Trim().Length > 0 ? newidlist.Substring(0, newidlist.Length - 1) : "";
                                        UsId = newidlist.Trim().Length > 0 ? newidlist.Substring(0, newidlist.Length - 1) : "";
                                        doc.Save(path);
                                    }
                                }

                            }
                            deleteRealList = myDocument.GetRealElements(deleteList);


                            #region 2019.7.31-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ��Ҫ������¼�������޸��ı�
                            if (selectedParas.Count == 1 && deleteRealList.Count == 1 && (deleteRealList[0] is ZYMacro || deleteRealList[0] is ZYFormatString || deleteRealList[0] is ZYReplace || deleteRealList[0] is ZYDiag || deleteRealList[0] is ZYSubject))
                            {
                                //��ѡ������Ϊ��Ԫ���У������Ǻ�Ԫ�ء���ʽ���ַ�����������Ŀ����ɾ���ı�����ɾ����Ԫ�أ����λ��������
                                OldSelectStart = this.AbsSelectStart;
                                //�жϵ�ǰѡ���Ƿ�Ϊ��Ԫ��ȫ���ı�
                                if ((deleteRealList[0] as ZYTextBlock).ChildCount == deleteList.Count)
                                {
                                    //�ж�Ԫ���Ƿ���ɾ��
                                    if ((deleteRealList[0] as ZYTextBlock).CanDelete || this.Document.Info.DocumentModel == DocumentModel.Design)
                                    {
                                        para.RemoveChildRange(deleteRealList);
                                    }
                                    else
                                    {
                                        if (Document.CanContentChangeLog)
                                        {
                                            Document.ContentChangeLog.Container = deleteRealList[0] as ZYTextBlock;
                                            Document.ContentChangeLog.LogProperty((deleteRealList[0] as ZYTextBlock), (deleteRealList[0] as ZYTextBlock).GetType().GetProperty("Text"), (deleteRealList[0] as ZYTextBlock).Text, (deleteRealList[0] as ZYTextBlock).Name);
                                        }
                                        (deleteRealList[0] as ZYTextBlock).Text = (deleteRealList[0] as ZYTextBlock).Name;
                                        (deleteRealList[0] as ZYTextBlock).RefreshSize();
                                    }
                                }
                                else
                                {
                                    (deleteRealList[0] as ZYTextBlock).RemoveChildRange(deleteList);
                                    if (Document.CanContentChangeLog)
                                    {
                                        Document.ContentChangeLog.Container = deleteRealList[0] as ZYTextBlock;
                                        Document.ContentChangeLog.LogField((deleteRealList[0] as ZYTextBlock), (deleteRealList[0] as ZYTextBlock).GetType().GetField("text"), (deleteRealList[0] as ZYTextBlock).text, ZYTextElement.GetElementsText((deleteRealList[0] as ZYTextBlock).ChildElements));
                                    }
                                    (deleteRealList[0] as ZYTextBlock).text = ZYTextElement.GetElementsText((deleteRealList[0] as ZYTextBlock).ChildElements);
                                }
                            }
                            else if (deleteRealList.Cast<ZYTextElement>().ToList().Exists(e => (e is ZYMacro || e is ZYFormatString || e is ZYReplace || e is ZYDiag || e is ZYSubject) && !(e as ZYTextBlock).CanDelete) && this.Document.Info.DocumentModel != DocumentModel.Design)
                            {
                                //ѡ�������ݳ�������Ԫ�ط�Χ���漰���Ԫ��
                                //List<ZYTextElement> list = new List<ZYTextElement>(deleteRealList.Cast<ZYTextElement>().ToList());
                                //foreach (ZYTextElement ele in list.Where(e => e is ZYMacro || e is ZYFormatString || e is ZYReplace))
                                //{
                                //    if (!(ele as ZYTextBlock).CanDelete)
                                //    {
                                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                                return false;
                                //    }
                                //}
                            }
                            else
                            {
                            #endregion
                                //��ʼִ��ɾ������
                                if (deleteRealList.Count == para.ChildCount) //ɾ����������
                                {
                                    if (para.Parent is ZYTextDiv)
                                    {
                                        #region �ж��Ƿ�ɾ���������䡪��>���ڱ��ǰ�����Ԫ�ص����⴦��
                                        bool flag = true; //��־�Ƿ����ɾ����������
                                        if (para.Parent.ChildElements.IndexOf(para) == 0) //��һ������
                                        {
                                            if (para.Parent.ChildCount == 1)
                                            {
                                                flag = false;
                                            }
                                            else
                                            {
                                                if (para.Parent.ChildElements[para.Parent.ChildElements.IndexOf(para) + 1] is TPTextTable)
                                                {
                                                    flag = false;
                                                }
                                                else
                                                {
                                                    flag = true;
                                                }
                                            }
                                        }
                                        else if (para.Parent.ChildElements.IndexOf(para) == para.Parent.ChildCount - 1) //���һ������
                                        {
                                            if (para.Parent.ChildCount == 1)
                                            {
                                                flag = false;
                                            }
                                            else
                                            {
                                                if (para.Parent.ChildElements[para.Parent.ChildElements.IndexOf(para) - 1] is TPTextTable)
                                                {
                                                    flag = false;
                                                }
                                                else
                                                {
                                                    flag = true;
                                                }
                                            }
                                        }
                                        else //�м����
                                        {
                                            if (para.Parent.ChildElements[para.Parent.ChildElements.IndexOf(para) - 1] is TPTextTable
                                                && para.Parent.ChildElements[para.Parent.ChildElements.IndexOf(para) + 1] is TPTextTable)
                                            {
                                                flag = false;
                                            }
                                            else
                                            {
                                                flag = true;
                                            }
                                        }
                                        #endregion

                                        if (flag)
                                        {
                                            para.Parent.RemoveChild(para);
                                            if (selectedParas.IndexOf(para) == 0)
                                            {
                                                OldSelectStart -= 1;
                                            }
                                        }
                                        else
                                        {
                                            if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //�س��������⴦��
                                            {
                                                deleteRealList.RemoveAt(deleteRealList.Count - 1);
                                            }
                                            para.RemoveChildRange(deleteRealList);
                                        }
                                    }
                                    else //�ĵ�ҳü���ĵ�ҳ�����ݿ�ȫ��ɾ��
                                    {
                                        para.Parent.RemoveChild(para);
                                    }
                                }
                                else //ɾ�������ڱ�ѡ�����ĵ�Ԫ��
                                {
                                    if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //�س��������⴦��
                                    {
                                        deleteRealList.RemoveAt(deleteRealList.Count - 1);
                                    }
                                    para.RemoveChildRange(deleteRealList);
                                }
                            }
                        }
                    }
                    #endregion

                    //2019.8.5-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ�ڱ༭��Ԫ�ص��ı�ʱճ������������ı�ճ������Ԫ����һ��Ԫ�صĸ��������ڣ��������λ��
                    if (deleteRealList.Count == 0) OldSelectStart = this.AbsSelectStart;
                }

                myDocument.ContentChanged();

                //����ɾ������֮��Ĺ�꣨�������λ��
                if (myDocument.HBFDocumentElement is ZYTextDiv) //��ǰ�༭��Ϊ�ĵ�����
                {
                    this.MoveSelectStart(OldSelectStart); //2014-08-08 ���¹�굽��λ�ñ������ĵ����ݸı����̴������֮�����
                }
                else //��ǰ�༭��Ϊ�ĵ�ҳü���ĵ�ҳ��
                {
                    if (myDocument.HBFDocumentElement.ChildCount == 0)
                    {
                        myDocument.ToggleEditingArea(-1, -1, false); //ȫѡɾ��ҳü��ҳ������֮��Ĭ���л��༭��������
                    }
                    else
                    {
                        this.MoveSelectStart(OldSelectStart); //2014-08-08 ���¹�굽��λ�ñ������ĵ����ݸı����̴������֮�����
                    }
                }

                ////��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                //TPTextCell currCell = myDocument.GetOwnerCell(CurrentElement);
                //if (currCell != null)
                //{
                //    currCell.AdjustHeight();
                //}

                //myDocument.ContentChanged();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ������Delete����ɾ��������ɾ����ǰ���λ�ô��ĺ�һ��Ԫ�ء�
        /// </summary>
        /// <param name="flag">���ݴ˲�������ɾ���̶��ı�ʱ���Ƿ���Ҫ����ɾ����ʾ��</param>
        /// <returns>����0��ʾȷ��ɾ��Ԫ�أ�����1��ʾ��ɾ����Ԫ�أ�����2��ʾ�Ը�Ԫ�ؽ����߼�ɾ����</returns>
        public int DeleteCurrentElement(params object[] flag)
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return 1;
                if (IsLock(intSelectStart)) return 1;
                if (intSelectStart >= 0 && intSelectStart < HBFElements.Count - 1) //���λ�ڱ༭�����һ��Ԫ��֮ǰʱ������ִ��Deleteɾ������
                {
                    ZYTextElement currEle = HBFElements[intSelectStart] as ZYTextElement; //��ǰ���λ�ô��ĺ�һ��Ԫ��
                    int oldSelectStart = HBFElements.IndexOf(currEle); //��ǰ���λ�ô��ĺ�һ��Ԫ�ص��������

                    bool canDel = CanDeleteElement(currEle);

                    //2019.8.1-hdf����Ԫ�ء���ʽ���ַ�����������Ŀ����Ԫ���赥���жϣ�CanDeleteElement()�����޷��ж�
                    if ((currEle.Parent is ZYMacro || currEle.Parent is ZYFormatString || currEle.Parent is ZYReplace || currEle.Parent is ZYDiag || currEle.Parent is ZYSubject) && this.Document.Info.DocumentModel != DocumentModel.Design)
                    {
                        YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ�нڵ����óɲ�����ɾ��");
                        canDel = (currEle.Parent as ZYTextBlock).CanDelete;
                    }

                    if (!canDel) return 1;

                    #region ��ʼִ��ɾ������
                    int intDelete = myDocument.isDeleteElement(currEle);
                    if (intDelete == 0) //ȷ��ɾ��
                    {
                        ZYTextParagraph currPara = myDocument.GetOwnerPara(currEle); //��ǰ����������䣨�������һ��Ԫ�ؿ϶��ǻس�����
                        ZYTextContainer currRoot = myDocument.GetOwnerRoot(currEle); //��ǰ�����������������������

                        if (currEle is ZYTextEOF) //��ǰ���λ�ô���һ��Ԫ��Ϊ�س���
                        {
                            if (currPara.ChildCount == 1) //�����ǰ�����������Ϊһ���ն��䣨������һ���س�����
                            {
                                if (IsParaInCell(currEle)) //��Ԫ����
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.IndexOf(currPara) == currCell.ChildCount - 1) return 1; //��ǰ�����������Ϊ��Ԫ�������һ�����䣬������ִ��Deleteɾ����������>�����֧�ֳ�������ջ

                                    #region �ϲ���������
                                    ZYTextParagraph nextPara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) + 1] as ZYTextParagraph;
                                    //ArrayList insertList = nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1); //���������ַ�ʽ���ж���ϲ�����������֮����Deleteɾ����������
                                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                    xmlDoc.PreserveWhitespace = true;
                                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                    ZYTextElement.ElementsToXML(nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1), xmlDoc.DocumentElement);
                                    ArrayList insertList = new ArrayList();
                                    myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                    currCell.RemoveChild(nextPara); //��ɾ����һ�����䡪��>ע�����˳��ǳ���Ҫ����������ջ������ȷ��ǰ��
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                    }
                                    currPara.InsertRangeBefore(insertList, currPara.LastElement); //�ٽ���һ��������س���֮���Ԫ���������ǰ���� 
                                    #endregion

                                    currCell.AdjustHeight(); //2014-08-07 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                                }
                                else //�ǵ�Ԫ����
                                {
                                    //�ж���ǰ��������������һ���ı�����
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] is ZYTextParagraph) //��������
                                    {
                                        currRoot.RemoveChild(currPara);
                                    }
                                    else if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] is TPTextTable) //�������
                                    {
                                        //ɾ�����֮ǰ����ʱ���ж�����>���֮ǰ����һ������ʱ������ɾ��
                                        if (currRoot.IndexOf(currPara) > 0 && currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is ZYTextParagraph)
                                        {
                                            currRoot.RemoveChild(currPara);
                                        }
                                    }
                                }
                            }
                            else //��ǰ�����������Ϊ�ǿն���
                            {
                                if (IsParaInCell(currEle)) //��Ԫ����
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.ChildElements.IndexOf(currPara) != currCell.ChildCount - 1) //�ǵ�Ԫ�������һ������
                                    {
                                        #region �ϲ���������
                                        ZYTextParagraph nextPara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) + 1] as ZYTextParagraph;
                                        //ArrayList insertList = nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1); //���������ַ�ʽ���ж���ϲ�����������֮����Deleteɾ����������
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        currCell.RemoveChild(nextPara); //��ɾ����һ�����䡪��>ע�����˳��ǳ���Ҫ����������ջ������ȷ��ǰ��
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                        }
                                        currPara.InsertRangeBefore(insertList, currPara.LastElement); //�ٽ���һ��������س���֮���Ԫ���������ǰ���� 
                                        #endregion

                                        currCell.AdjustHeight(); //2014-08-07 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                                    }
                                }
                                else //�ǵ�Ԫ����
                                {
                                    //�ж���ǰ��������������һ���ı�����
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] is ZYTextParagraph) //��������
                                    {
                                        #region �ϲ���������
                                        ZYTextParagraph nextPara = currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] as ZYTextParagraph;
                                        //ArrayList insertList = nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1); //���������ַ�ʽ���ж���ϲ�����������֮����Deleteɾ����������
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        currRoot.RemoveChild(nextPara); //��ɾ����ǰ����
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                        }
                                        currPara.InsertRangeBefore(insertList, currPara.LastElement); //�ٽ���ǰ������س���֮���Ԫ���������һ������ 
                                        #endregion
                                    }
                                    //��ע����ǰ����س���֮��������Ǳ����ִ��Deleteɾ������
                                }
                            }
                        }
                        else //��ǰ�����������Ϊ�ǿն��䣬���ҵ�ǰ���λ�ڴ˶���β��֮ǰ
                        {
                            //2014-09-25 ��Ԫ������Ӧ�߶�
                            TPTextCell currCell = null;
                            if (IsParaInCell(currEle)) //��Ԫ����
                            {
                                currCell = myDocument.GetOwnerCell(currEle);
                            }

                            if (currEle.Parent is ZYTextBlock)
                            {
                                currPara.RemoveChild(currEle.Parent as ZYTextBlock);
                                //this.MoveSelectStart(currEle.Parent.FirstElement.Index); //ɾ�������ڵ��ı���Ԫ����Ҫ���µ������λ��
                                oldSelectStart = currEle.Parent.FirstElement.Index; //2014-08-08 ���¹��λ��
                            }
                            else
                            {
                                currPara.RemoveChild(currEle);
                            }

                            //2014-09-25 ��Ԫ������Ӧ�߶�
                            if (currCell != null) //��Ԫ����
                            {
                                currCell.AdjustHeight();
                            }
                        }

                        ////��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                        //TPTextCell cell = myDocument.GetOwnerCell(CurrentElement);
                        //if (cell != null)
                        //{
                        //    cell.AdjustHeight();
                        //}

                        myDocument.ContentChanged();
                        this.MoveSelectStart(oldSelectStart); //2014-08-08 ���¹�굽��λ�ñ������ĵ����ݸı����̴������֮�����
                    }
                    else if (intDelete == 2) //�߼�ɾ��
                    {
                        this.MoveSelectStart(intSelectStart + 1); //�ƶ��������ǰ���λ�ô��ĺ�һ��Ԫ��֮ǰ
                    }
                    #endregion
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// �жϵ�ǰ������Ԫ���Ƿ�����ɾ��
        /// �����ģʽ�¿���ɾ�����нڵ�
        /// </summary>
        /// <param name="zyTextElement"></param>
        /// <returns></returns>
        private bool CanDeleteElement(ZYTextElement zyTextElement)
        {
            if (this.Document.Info.DocumentModel == DocumentModel.Design) return true;   //�����ģʽ�¿���ɾ�����нڵ�

            if ((zyTextElement.Parent is ZYFixedText || zyTextElement.Parent is ZYText)) //�̶��ı�  
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ɾ����Χ�а����̶����ݣ�����ɾ��");
                return false;
            }
            //����ť
            else if (zyTextElement is ZYButton && !((ZYButton)zyTextElement).CanDelete)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                return false;
            }
            //����λ��
            else if (zyTextElement is ZYFlag && !((ZYFlag)zyTextElement).CanDelete)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ��Χ�а����̶����ݣ�����ɾ��");
                return false;
            }
            else if (zyTextElement is ZYFlag && !((ZYFlag)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ɾ����Χ�а����̶����ݣ�����ɾ��");
                return false;
            }
            else if (zyTextElement is ZYToothCheck && !((ZYToothCheck)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ�нڵ����óɲ�����ɾ��");
                return false;
            }
            else if (zyTextElement is ZYMensesFormula && !((ZYMensesFormula)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ�нڵ����óɲ�����ɾ��");
                return false;
            }
            else if (zyTextElement is ZYCheckBox && !((ZYCheckBox)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ�нڵ����óɲ�����ɾ��");
                return false;
            }
            else if (zyTextElement.Parent is ZYTextBlock
                && !((ZYTextBlock)zyTextElement.Parent).CanDelete
                //��Ԫ�ء���ʽ���ַ�����������Ŀ���ڴ��жϣ���ɾ�����һ���ı�ʱ�ж�
                && !(zyTextElement.Parent is ZYMacro)
                && !(zyTextElement.Parent is ZYFormatString)
                && !(zyTextElement.Parent is ZYReplace)
                && !(zyTextElement.Parent is ZYDiag)
                && !(zyTextElement.Parent is ZYSubject)
                )
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("ѡ�нڵ����óɲ�����ɾ��");
                return false;
            }
            return true;
        }

        /// <summary>
        /// ������Backspace����ɾ��������ɾ����ǰ���λ�ô���ǰһ��Ԫ�ء�
        /// </summary>
        /// <param name="flag">���ݴ˲�������ɾ���̶��ı�ʱ���Ƿ���Ҫ����ɾ����ʾ��</param>
        /// <returns>����0��ʾȷ��ɾ��Ԫ�أ�����1��ʾ��ɾ����Ԫ�أ�����2��ʾ�Ը�Ԫ�ؽ����߼�ɾ����</returns>
        public int DeletePreElement(params object[] flag)
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return 1;
                if (IsLock(intSelectStart)) return 1;
                if (intSelectStart > 0 && intSelectStart < HBFElements.Count) //���λ�ڱ༭����һ��Ԫ��֮ǰʱ������ִ��Backspaceɾ������
                {
                    ZYTextElement preEle = HBFElements[intSelectStart - 1] as ZYTextElement; //��ǰ���λ�ô���ǰһ��Ԫ��
                    ZYTextElement currEle = HBFElements[intSelectStart] as ZYTextElement; //��ǰ���λ�ô��ĺ�һ��Ԫ��
                    int oldSelectStart = HBFElements.IndexOf(preEle); //��ǰ���λ�ô���ǰһ��Ԫ�ص��������

                    bool canDel = CanDeleteElement(preEle);
                    if (!canDel) return 1;

                    #region ��ʼִ��ɾ������
                    int intDelete = myDocument.isDeleteElement(preEle);
                    if (intDelete == 0) //ȷ��ɾ��
                    {
                        ZYTextParagraph currPara = myDocument.GetOwnerPara(currEle); //��ǰ����������䣨�������һ��Ԫ�ؿ϶��ǻس�����
                        ZYTextContainer currRoot = myDocument.GetOwnerRoot(currEle); //��ǰ�����������������������

                        if (currEle is ZYTextEOF) //��ǰ���λ�ô���һ��Ԫ��Ϊ�س���
                        {
                            if (currPara.ChildCount == 1) //�����ǰ�����������Ϊһ���ն��䣨������һ���س�����
                            {
                                if (IsParaInCell(currEle)) //��Ԫ����
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.IndexOf(currPara) == 0) return 1; //��ǰ�����������Ϊ��Ԫ���ڵ�һ�����䣬������ִ��Backspaceɾ����������>�����֧�ֳ�������ջ

                                    #region �ϲ���������
                                    ZYTextParagraph prePara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                    //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //���������ַ�ʽ���ж���ϲ�����������֮����Deleteɾ����������
                                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                    xmlDoc.PreserveWhitespace = true;
                                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                    ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                    ArrayList insertList = new ArrayList();
                                    myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                    }
                                    currCell.RemoveChild(prePara); //��ɾ��ǰһ�����䡪��>ע�����˳��ǳ���Ҫ����������ջ������ȷ��ǰ��
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                    }
                                    currPara.InsertRangeBefore(insertList, currPara.FirstElement); //�ٽ�ǰһ��������س���֮���Ԫ���������ǰ���� 
                                    #endregion

                                    currCell.AdjustHeight(); //2014-08-07 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                                }
                                else //�ǵ�Ԫ����
                                {
                                    //�ж���ǰ��������������һ���ı�����
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is ZYTextParagraph) //��������
                                    {
                                        #region �ϲ���������
                                        ZYTextParagraph prePara = currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                        //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //���������ַ�ʽ���ж���ϲ�����������֮����Deleteɾ����������
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                        }
                                        currRoot.RemoveChild(prePara); //��ɾ��ǰһ�����䡪��>ע�����˳��ǳ���Ҫ����������ջ������ȷ��ǰ��
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                        }
                                        currPara.InsertRangeBefore(insertList, currPara.FirstElement); //�ٽ�ǰһ��������س���֮���Ԫ���������ǰ���� 
                                        #endregion
                                    }
                                    else if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is TPTextTable) //�������
                                    {
                                        //��ע����ǰ����س���֮ǰ�������Ǳ����ִ��Backspaceɾ������
                                        oldSelectStart = HBFElements.IndexOf(currEle); //���ֵ�ǰ���λ�ò���
                                    }
                                }
                            }
                            else //��ǰ�����������Ϊ�ǿն���
                            {
                                if (preEle.Parent is ZYTextBlock) //�ж��Ƿ�Ϊ�ı���Ԫ��
                                {
                                    #region 2019.7.31-hdf������¼��ʱ��Ԫ��text�����޸��ı�
                                    if (preEle.Parent is ZYMacro || preEle.Parent is ZYReplace || preEle.Parent is ZYFormatString || preEle.Parent is ZYDiag || preEle.Parent is ZYSubject)
                                    {
                                        //�ж�ɾ�����Ƿ��ǿ�Ԫ�ص����һ���ַ�
                                        int index = preEle.Parent.ChildElements.IndexOf(preEle);
                                        if (index == 0 && preEle.Parent.ChildElements.Count == 1)
                                        {
                                            preEle.Parent.RemoveChild(preEle);
                                            //�жϸÿ�Ԫ���Ƿ�����ɾ��
                                            if ((preEle.Parent as ZYTextBlock).CanDelete || this.Document.Info.DocumentModel == DocumentModel.Design)
                                            {
                                                currPara.RemoveChild(preEle.Parent as ZYTextBlock);
                                            }
                                            else
                                            {
                                                if (Document.CanContentChangeLog)
                                                {
                                                    Document.ContentChangeLog.UndoSteps.RemoveAt(Document.ContentChangeLog.UndoSteps.Count - 1);
                                                    Document.ContentChangeLog.Container = preEle.Parent;
                                                    Document.ContentChangeLog.LogProperty(preEle.Parent, preEle.Parent.GetType().GetProperty("Text"), (preEle.Parent as ZYTextBlock).Text, ((ZYTextBlock)preEle.Parent).Name);
                                                }
                                                //������ɾ����Text�ĳ�Name����ֵ��ˢ�´�С��ʾ����������ӵ��ı�û��index���Թ��λ��ֻ�ܼӵ�����Ԫ������
                                                //(preEle.Parent as ZYTextBlock).Text = ((ZYTextBlock)preEle.Parent).Name;
                                                (preEle.Parent as ZYTextBlock).Text = " "; //���������ɾ��������һ���ո�
                                                (preEle.Parent as ZYTextBlock).RefreshSize();
                                                oldSelectStart += preEle.Parent.ChildElements.Count;
                                            }
                                        }
                                        else
                                        {
                                            preEle.Parent.RemoveChild(preEle);
                                            if (Document.CanContentChangeLog)
                                            {
                                                Document.ContentChangeLog.Container = preEle.Parent;
                                                Document.ContentChangeLog.LogField(preEle.Parent, preEle.Parent.GetType().GetField("text"), (preEle.Parent as ZYTextBlock).text, ZYTextElement.GetElementsText(preEle.Parent.ChildElements));
                                            }
                                            (preEle.Parent as ZYTextBlock).text = ZYTextElement.GetElementsText(preEle.Parent.ChildElements);
                                        }
                                    }
                                    else
                                    {
                                        currPara.RemoveChild(preEle.Parent as ZYTextBlock);
                                        oldSelectStart = preEle.Parent.FirstElement.Index; //ɾ�������ڵ��ı���Ԫ����Ҫ���µ������λ��
                                    }
                                    #endregion
                                }
                                else
                                {
                                    currPara.RemoveChild(preEle);
                                }

                                //2014-09-25 ��Ԫ������Ӧ�߶�
                                if (IsParaInCell(currEle)) //��Ԫ����
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    currCell.AdjustHeight();
                                }
                            }
                        }
                        else //��ǰ�����������Ϊ�ǿն��䣬���ҵ�ǰ���λ�ڴ˶���β��֮ǰ
                        {
                            if ((currEle.Parent is ZYTextBlock ? currPara.IndexOf(currEle.Parent) : currPara.IndexOf(currEle)) == 0
                                && !(currEle.Parent is ZYMacro || currEle.Parent is ZYReplace || currEle.Parent is ZYFormatString || currEle.Parent is ZYDiag || currEle.Parent is ZYSubject)) //��ǰ���λ�ڶ����ײ�
                            {
                                if (IsParaInCell(currEle)) //��Ԫ����
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.IndexOf(currPara) == 0) return 1; //��ǰ�����������Ϊ��Ԫ���ڵ�һ�����䣬������ִ��Backspaceɾ����������>�����֧�ֳ�������ջ

                                    #region �ϲ���������
                                    ZYTextParagraph prePara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                    //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //���������ַ�ʽ���ж���ϲ�����������֮����Deleteɾ����������
                                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                    xmlDoc.PreserveWhitespace = true;
                                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                    ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                    ArrayList insertList = new ArrayList();
                                    myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                    }
                                    currCell.RemoveChild(prePara); //��ɾ��ǰһ�����䡪��>ע�����˳��ǳ���Ҫ����������ջ������ȷ��ǰ��
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                    }
                                    currPara.InsertRangeBefore(insertList, currPara.FirstElement); //�ٽ�ǰһ��������س���֮���Ԫ���������ǰ���� 
                                    #endregion

                                    currCell.AdjustHeight(); //2014-08-07 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                                }
                                else //�ǵ�Ԫ����
                                {
                                    //�ж���ǰ��������������һ���ı�����
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is ZYTextParagraph) //��������
                                    {
                                        #region �ϲ���������
                                        ZYTextParagraph prePara = currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                        //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //���������ַ�ʽ���ж���ϲ�����������֮����Deleteɾ����������
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                        }
                                        currRoot.RemoveChild(prePara); //��ɾ��ǰһ�����䡪��>ע�����˳��ǳ���Ҫ����������ջ������ȷ��ǰ��
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //���²���Ԫ�صĸ�����
                                        }

                                        if (currEle.Parent is ZYTextBlock) //�����ı���Ԫ����Ҫ�ر��� 2014-08-13 ����ǳ��ؼ�
                                        {
                                            currPara.RemoveChild(currEle.Parent as ZYTextBlock);
                                            oldSelectStart = currEle.Parent.FirstElement.Index - 1; //ɾ�������ڵ��ı���Ԫ����Ҫ���µ������λ�ã������ȥ1
                                        }

                                        currPara.InsertRangeBefore(insertList, currPara.FirstElement); //�ٽ�ǰһ��������س���֮���Ԫ���������ǰ���� 
                                        #endregion
                                    }
                                    else if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is TPTextTable) //�������
                                    {
                                        //��ע����ǰ����س���֮ǰ�������Ǳ����ִ��Backspaceɾ������
                                        oldSelectStart = HBFElements.IndexOf(currEle); //���ֵ�ǰ���λ�ò���
                                    }
                                }
                            }
                            else //��ǰ���λ�ڶ����в�
                            {
                                if (preEle.Parent is ZYTextBlock) //�ж��Ƿ�Ϊ�ı���Ԫ��
                                {
                                    #region 2019.7.31-hdf������¼��ʱ��Ԫ��text�����޸�
                                    if (preEle.Parent is ZYMacro || preEle.Parent is ZYReplace || preEle.Parent is ZYFormatString || preEle.Parent is ZYDiag || preEle.Parent is ZYSubject)
                                    {
                                        //�ж�ɾ�����Ƿ��ǿ�Ԫ�ص����һ���ַ�
                                        int index = preEle.Parent.ChildElements.IndexOf(preEle);
                                        if (index == 0 && preEle.Parent.ChildElements.Count == 1)
                                        {
                                            preEle.Parent.RemoveChild(preEle);
                                            //�жϸÿ�Ԫ���Ƿ�����ɾ��
                                            if ((preEle.Parent as ZYTextBlock).CanDelete || this.Document.Info.DocumentModel == DocumentModel.Design)
                                            {
                                                currPara.RemoveChild(preEle.Parent as ZYTextBlock);
                                            }
                                            else
                                            {
                                                if (Document.CanContentChangeLog)
                                                {
                                                    Document.ContentChangeLog.UndoSteps.RemoveAt(Document.ContentChangeLog.UndoSteps.Count - 1);
                                                    Document.ContentChangeLog.Container = preEle.Parent;
                                                    Document.ContentChangeLog.LogProperty(preEle.Parent, preEle.Parent.GetType().GetProperty("Text"), (preEle.Parent as ZYTextBlock).Text, ((ZYTextBlock)preEle.Parent).Name);
                                                }
                                                //������ɾ����Text�ĳ�Name����ֵ��ˢ�´�С��ʾ����������ӵ��ı�û��index���Թ��λ��ֻ�ܼӵ�����Ԫ������
                                                //(preEle.Parent as ZYTextBlock).Text = ((ZYTextBlock)preEle.Parent).Name;
                                                (preEle.Parent as ZYTextBlock).Text = " ";
                                                (preEle.Parent as ZYTextBlock).RefreshSize();
                                                oldSelectStart += preEle.Parent.ChildElements.Count;
                                            }
                                        }
                                        else
                                        {
                                            preEle.Parent.RemoveChild(preEle);
                                            if (Document.CanContentChangeLog)
                                            {
                                                Document.ContentChangeLog.Container = preEle.Parent;
                                                Document.ContentChangeLog.LogField(preEle.Parent, preEle.Parent.GetType().GetField("text"), (preEle.Parent as ZYTextBlock).text, ZYTextElement.GetElementsText(preEle.Parent.ChildElements));
                                            }
                                            (preEle.Parent as ZYTextBlock).text = ZYTextElement.GetElementsText(preEle.Parent.ChildElements);
                                        }
                                    }
                                    else
                                    {
                                        currPara.RemoveChild(preEle.Parent as ZYTextBlock);
                                        oldSelectStart = preEle.Parent.FirstElement.Index; //ɾ�������ڵ��ı���Ԫ����Ҫ���µ������λ��
                                    }
                                    #endregion
                                }
                                else
                                {
                                    currPara.RemoveChild(preEle);
                                }

                                //2014-09-25 ��Ԫ������Ӧ�߶�
                                if (IsParaInCell(currEle)) //��Ԫ����
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    currCell.AdjustHeight();
                                }
                            }
                        }

                        //this.MoveSelectStart(oldSelectStart);

                        ////��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                        //TPTextCell cell = myDocument.GetOwnerCell(CurrentElement);
                        //if (cell != null)
                        //{
                        //    cell.AdjustHeight();
                        //}

                        myDocument.ContentChanged();
                        this.MoveSelectStart(oldSelectStart); //2014-08-08 ���¹�굽��λ�ñ������ĵ����ݸı����̴������֮�����
                    }
                    else if (intDelete == 2) //�߼�ɾ��
                    {
                        this.MoveSelectStart(oldSelectStart); //�ƶ��������ǰ���λ�ô��ĺ�һ��Ԫ��֮ǰ
                    }
                    if (preEle.Parent is ZYSubject)
                    {
                        if (null != delChangeSubjectStr)
                        {
                            delChangeSubjectStr();
                        }
                    }
                    #endregion
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region �������� �����2014-08-15
        /// <summary>
        /// ���õ�ǰ���ѡ�������ڵ������ı�����Ԫ�ص��������ԡ�
        /// </summary>
        /// <param name="index">���Ե��ڲ���š�</param>
        /// <param name="strValue">����ֵ��</param>
        /// <param name="flag">��־�Ƿ�Ϊ����һ����Ԫ���ڵ�ѡ���ı����Բ�����</param>
        public void SetSelectingAreaAttribute(int index, string strValue, bool flag)
        {
            try
            {
                if (flag) //һ����Ԫ����ѡ���ı�
                {
                    ArrayList myList = this.GetSelectElements();
                    this.UpdateFontAttribute(index, strValue, myList);
                    TPTextCell cell = myDocument.GetOwnerCell(myList[0] as ZYTextElement);
                    if (cell != null)
                    {
                        cell.AdjustHeight(); //2014-08-15 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                    }
                }
                else //�����Ԫ��ѡ���򽻲�ѡ���ĵ�Ԫ��������Ԫ��
                {
                    ArrayList myList = this.GetSelectElements();

                    #region Ԥ��������ѡ��Ԫ��
                    //��ǰѡ�������ڵĶ��伯��
                    ArrayList selectedParas = this.GetSelectParagraph();
                    //����ȡ�����ѡ��Ԫ�أ�ѡ�е�Ԫ���ѡ��һ����Ԫ���ڵ��ĵ�Ԫ�ص�������ɾ������
                    Dictionary<TPTextTable, List<TPTextCell>> DeleteElementsInTables = null;
                    if (selectingAreaInOneTable) //ͬһ������ڴ�SelectedCells�еõ�
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(null);
                    }
                    else //��һ������ڴ�selectedParas�еõ�
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(selectedParas);
                    }

                    if (DeleteElementsInTables.Count > 0)
                    {
                        //�ȴ�selectedParas���Ƴ����еİ����ڵ�Ԫ���ڵ��ַ�Ԫ�أ������س�����
                        foreach (List<TPTextCell> cells in DeleteElementsInTables.Values)
                        {
                            foreach (TPTextCell cell in cells)
                            {
                                for (int i = 0; i < cell.ChildCount; i++)
                                {
                                    ZYTextParagraph para = cell.ChildElements[i] as ZYTextParagraph;
                                    int paraStartIndex = para.FirstElement.Index; //�����һ��Ԫ�ص��������
                                    if (para.FirstElement is ZYTextBlock)
                                    {
                                        paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                                    }
                                    int paraEndIndex = para.LastElement.Index; //�������һ��Ԫ�أ��س��������������
                                    ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);
                                    foreach (ZYTextElement ele in paraChars)
                                    {
                                        myList.Remove(ele);
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region ��������ѡ��Ԫ�ء���>��ʼ������������
                    if (DeleteElementsInTables.Count > 0)
                    {
                        foreach (TPTextTable currTB in DeleteElementsInTables.Keys)
                        {
                            foreach (TPTextCell cell in DeleteElementsInTables[currTB])
                            {
                                for (int i = 0; i < cell.ChildCount; i++)
                                {
                                    ZYTextParagraph para = cell.ChildElements[i] as ZYTextParagraph;
                                    int paraStartIndex = para.FirstElement.Index; //�����һ��Ԫ�ص��������
                                    if (para.FirstElement is ZYTextBlock)
                                    {
                                        paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                                    }
                                    int paraEndIndex = para.LastElement.Index; //�������һ��Ԫ�أ��س��������������
                                    ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);

                                    this.UpdateFontAttribute(index, strValue, paraChars);
                                    cell.AdjustHeight(); //2014-08-15 ��ǰԪ�ش��ڵ�Ԫ�������赥Ԫ������Ӧ�߶ȶ�̬����������Ҫ���ĵ����ݸı䴦������֮ǰ����
                                }
                            }
                        }
                    }
                    #endregion

                    //����Ǳ����ѡ��Ԫ�ء���>��ʼ������������
                    this.UpdateFontAttribute(index, strValue, myList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">���Ե��ڲ���š�</param>
        /// <param name="strValue">����ֵ��</param>
        /// <param name="myList">ָ�����ı�����Ԫ���б�</param>
        private void UpdateFontAttribute(int index, string strValue, ArrayList myList)
        {
            try
            {
                for (int iCount = 0; iCount < myList.Count; iCount++)
                {
                    if (myList[iCount] is ZYTextLineEnd) continue; //������س���

                    switch (index)
                    {
                        case 0: //��������
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontName = strValue;
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontName = strValue;
                            }
                            break;
                        case 1: //�����С
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontSize = float.Parse(strValue);
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontSize = float.Parse(strValue);
                            }
                            break;
                        case 2: //����
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontBold = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontBold = strValue.Equals("1");
                            }
                            break;
                        case 3: //б��
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontItalic = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontItalic = strValue.Equals("1");
                            }
                            break;
                        case 4: //�»���
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontUnderLine = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontUnderLine = strValue.Equals("1");
                            }
                            break;
                        case 5: //�ı���ɫ
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            break;
                        case 6: //Ԫ�ص���������
                            //myChar.Name = strValue ;
                            break;
                        case 7: //�±�
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).Sub = strValue.Equals("1");
                            }
                            break;
                        case 8: //�ϱ�
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).Sup = strValue.Equals("1");
                            }
                            break;
                        case 9: //�ı�������ɫ
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).BackgroundColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            break;
                        case 10: //Ȧ��
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).CircleFont = strValue.Equals("1");
                            }
                            break;
                        default:
                            return;
                    }

                    if (myList[iCount] is ZYTextChar)
                    {
                        ZYTextChar currChar = myList[iCount] as ZYTextChar;
                        currChar.RefreshSize();
                        //�����ZYTextBlock�е��ַ���ͬʱ����ZYTextBlock������
                        if (currChar.Parent is ZYTextBlock)
                        {
                            ZYTextBlock parent = currChar.Parent as ZYTextBlock;
                            currChar.Attributes.CopyTo(parent.Attributes);
                            parent.UpdateAttrubute();
                        }
                    }
                    else
                    {
                        (myList[iCount] as ZYTextEOF).RefreshSize();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
    }
}
