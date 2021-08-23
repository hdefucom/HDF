using System;
///////////////////////序列化需要的引用
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using YidanSoft.Library.EmrEditor.Src.Clipboard;
using System.Windows.Forms;
using System.Collections.Generic;
using YidanSoft.Library.EmrEditor.Src.Gui; //add by myc 2014-07-01 添加原因：新版页眉二期改版需要
using YidanSoft.Library.EmrEditor.Src.Document;
using System.Xml;
using System.Linq;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 自然语言电子病历文档内容管理器
    /// </summary>
    /// <remarks>本对象用于维护一个列表，该列表中全部为<link>ZYTextDocumentLib.ZYTextElement</link>类型，
    /// 包括删除修改和插入元素，电子病历文本文档对象可以借助它来维护自己的可显示元素的列表
    /// 本元素还使用<a href="#ZYTextDocumentLib.ZYContent.SelectStart">SelectStart</a>属性和<a href="#ZYTextDocumentLib.ZYContent.SelectLength">SelectLength</a>属性
    /// 来管理文档中的插入点和选择区域，并提供一系列函数来辅助管理这两个属性
    /// 此外还提供了一些处理文档内容的通用例程
    /// 本对象使用<link>ZYTextDocumentLib.IEMRContentDocument</link>接口来调用文档对象本身
    /// </remarks>
    /// 
    [Serializable]
    public class ZYContent
    {
        private ZYTextDocument myDocument = null;
        /// <summary>
        /// 所有显示的元素集合,在ZYDocument的构造函数中初始化
        /// </summary>
        private System.Collections.ArrayList myElements = null;

        /// <summary>
        /// mfb 用来保留上一次鼠标所在的索引位置
        /// 如果是第一次打开文档,鼠标位置默认在第一个元素处,当然为0
        /// </summary>
        private int intSelectStart = 0;
        /// <summary>
        /// mfb 用来保留上一次鼠标选择的长度,或者叫步长
        /// 如果为0, 代表单击,并没有划选.
        /// </summary>
        private int intSelectLength = 0;

        private string strFixLenText = null;

        /// <summary>
        /// AI症状建议
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
        //		/// 逻辑删除
        //		/// </summary>
        //		public bool LogicDelete
        //		{
        //			get{ return bolLogicDelete ;}
        //			set{ bolLogicDelete = value;}
        //		}

        /// <summary>
        /// 本内容所属的文档对象
        /// </summary>
        public ZYTextDocument Document
        {
            get { return myDocument; }
            set { myDocument = value; }
        }

        /// <summary>
        /// 是否自动清除选择状态,若为True则插入点位置修改时会自动设置SelectLength属性，否则会根据旧的插入点的位置计算SelectLength长度
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
        /// 所有显示的元素列表
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
            //return myElements.IndexOf(e); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            return HBFElements.IndexOf(e); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        }

        /// <summary>
        /// 设置,返回文档内容是否改变
        /// </summary>
        public bool Modified
        {
            get { return bolModified; }
            set { bolModified = value; }
        }

        /// <summary>
        /// 插入点的位置
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
        /// 获得前一行
        /// </summary>
        public ZYTextLine PreLine
        {
            get
            {
                try
                {
                    ZYTextLine myLine = this.CurrentLine;
                    //if (myDocument.Lines.IndexOf(myLine) > 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    if (myDocument.HBFLines.IndexOf(myLine) > 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    {
                        for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
                        {
                            //ZYTextElement myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                            ZYTextElement myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 获得下一行
        /// </summary>
        public ZYTextLine NextLine
        {
            get
            {
                try
                {
                    ZYTextLine myLine = this.CurrentLine;
                    //if (myDocument.Lines.IndexOf(myLine) < myDocument.Lines.Count - 1) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    if (myDocument.HBFLines.IndexOf(myLine) < myDocument.HBFLines.Count - 1) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    {
                        //for (int iCount = intSelectStart + 1; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                        //{
                        //    ZYTextElement myElement = (ZYTextElement)myElements[iCount];
                        //    if (myElement.OwnerLine != myLine)
                        //        return myElement.OwnerLine;
                        //}

                        for (int iCount = intSelectStart + 1; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 获得当前行
        /// </summary>
        public ZYTextLine CurrentLine
        {
            get
            {
                //if (myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                if (HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    return null;
                else
                {
                    //if (myElements != null && intSelectStart >= 0 && intSelectStart < myElements.Count) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    if (HBFElements != null && intSelectStart >= 0 && intSelectStart < HBFElements.Count) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    {
                        //ZYTextLine myLine = ((ZYTextElement)myElements[intSelectStart]).OwnerLine; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                        ZYTextLine myLine = ((ZYTextElement)HBFElements[intSelectStart]).OwnerLine; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

                        //if (this.bolLineEndFlag && myDocument.Lines.IndexOf(myLine) > 0)
                        //    return (ZYTextLine)myDocument.Lines[myDocument.Lines.IndexOf(myLine) - 1]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                        if (this.bolLineEndFlag && myDocument.HBFLines.IndexOf(myLine) > 0)
                            return (ZYTextLine)myDocument.HBFLines[myDocument.HBFLines.IndexOf(myLine) - 1]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                        else
                            return myLine;
                    }
                    else
                        //return ((ZYTextElement)myElements[myElements.Count - 1]).OwnerLine; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                        return ((ZYTextElement)HBFElements[HBFElements.Count - 1]).OwnerLine; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                }
            }
        }// CurrenLine 

        #region add by myc 2014-07-03 注释原因：新版页眉二期改版需要
        ///// <summary>
        ///// 获得当前元素
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
        //                //如果是元素，则
        //                #region bwy :
        //                //if (myElement.Parent != null && myElement.Parent is ZYTextBlock)
        //                //{
        //                //    myElement = myElement.Parent.FirstElement;
        //                //    //同时也要修改intSelectStart,因为删除操作是根据这个值去找元素的
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
        //            //Debug.WriteLine("CurrentElement获取当前元素是 " + myElement);
        //            return myElement;
        //        }
        //    }
        //    set
        //    {
        //        if (myElements.Contains(value))
        //            this.MoveSelectStart(myElements.IndexOf(value));
        //        intSelectStart = this.FixIndex(intSelectStart);
        //        Debug.WriteLine("设置当前元素 " + value + " value.RealTop:" + value.RealTop);
        //    }
        //} 
        #endregion

        /// <summary>
        /// 获得当前选中的元素,若没有选中元素或选中多个元素则返回空
        /// </summary>
        public ZYTextElement CurrentSelectElement
        {
            get
            {
                //if (myElements.Count == 0 || (intSelectLength != 1 && intSelectLength != -1)) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                if (HBFElements.Count == 0 || (intSelectLength != 1 && intSelectLength != -1)) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    return null;
                else
                    //return (ZYTextElement)myElements[this.AbsSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    return (ZYTextElement)HBFElements[this.AbsSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            }
            set
            {
                //if (myElements.Contains(value)) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                //{
                //    this.SetSelection(myElements.IndexOf(value) + 1, -1);
                //}

                if (HBFElements.Contains(value)) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                {
                    this.SetSelection(HBFElements.IndexOf(value) + 1, -1);
                }
            }
        }
        /// <summary>
        /// 获得当前位置的前一个元素
        /// </summary>
        public ZYTextElement PreElement
        {
            get
            {
                //if (myElements != null && myElements.Count > 0 && intSelectStart > 0 && intSelectStart < myElements.Count) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                //    return (ZYTextElement)myElements[intSelectStart - 1];

                if (HBFElements != null && HBFElements.Count > 0
                    && intSelectStart > 0 && intSelectStart < HBFElements.Count) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    return (ZYTextElement)HBFElements[intSelectStart - 1];
                else
                    return null;
            }
        }

        /// <summary>
        /// 获得指定元素的前一个元素
        /// </summary>
        /// <param name="refElement">指定的元素</param>
        /// <returns>该元素的前一个元素若没找到则返回空</returns>
        public ZYTextElement GetPreElement(ZYTextElement refElement)
        {
            //int index = myElements.IndexOf(refElement); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            int index = HBFElements.IndexOf(refElement); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            if (index >= 1)
                //return (ZYTextElement)myElements[index - 1]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                return (ZYTextElement)HBFElements[index - 1]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            else
                return null;
        }

        /// <summary>
        /// 获得指定元素的后一个元素
        /// </summary>
        /// <param name="refElement">指定的元素</param>
        /// <returns>该元素的前一个元素，若没有找到则返回空</returns>
        public ZYTextElement GetNextElement(ZYTextElement refElement)
        {
            //int index = myElements.IndexOf(refElement); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            //if (index >= 0 && index < myElements.Count - 1)
            //    return (ZYTextElement)myElements[index + 1];

            int index = HBFElements.IndexOf(refElement);  //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 当前用户等级
        /// </summary>
        public int UserLevel
        {
            get { return intUserLevel; }
            set { intUserLevel = value; }
        }

        #region add by myc 2014-06-12 注释原因：此方法并没有对选中区域边界上含有回车符时作出正确处理
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

        //        #region bwy : 固定文本不可删
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
        /// 判断一个元素是否当前元素
        /// </summary>
        /// <param name="myElement"></param>
        /// <returns></returns>
        public bool isCurrentElement(ZYTextElement myElement)
        {
            return (this.CurrentElement == myElement && intSelectLength == 0);
        }

        /// <summary>
        /// 获得插入点所在行的所有的元素
        /// </summary>
        /// <returns>元素列表</returns>
        public System.Collections.ArrayList GetCurrentLineElements()
        {
            intSelectStart = this.FixIndex(intSelectStart);
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            int LineIndex = myElement.LineIndex;
            // 获得当前行第一个元素的编号
            int StartIndex = 0;
            for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
            {
                //myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                if (myElement.LineIndex != LineIndex)
                {
                    StartIndex = iCount + 1;
                    break;
                }
            }
            // 填充当前行元素列表
            System.Collections.ArrayList myList = new System.Collections.ArrayList();
            //for (int iCount = StartIndex; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            for (int iCount = StartIndex; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                //myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 返回当前行行首的空白字符串
        /// </summary>
        /// <returns>行首的空白字符串</returns>
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

        #region ********************* 选择区域 *********************

        /// <summary>
        /// 选择区域的长度,可小于0
        /// </summary>
        public int SelectLength
        {
            get { return intSelectLength; }
            set { intSelectLength = value; }
        }

        #region add by myc 2014-06-12 注释原因：以下方法并未处理选中区域边界上的回车符和一个字符被选中情况
        ///// <summary>
        ///// 选择区域的绝对开始位置
        ///// </summary>
        //public int AbsSelectStart
        //{
        //    get { return (intSelectLength > 0 ? intSelectStart : intSelectStart + intSelectLength); }
        //}
        ///// <summary>
        ///// 选择区域的绝对结束位置
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

        #region add by myc 2014-06-09 注释原因：以下方法并未处理选中区域边界上的回车符
        /// <summary>
        /// 判断指定的元素是否处于选中区域
        /// </summary>
        /// <param name="myElement">文档元素对象</param>
        /// <returns>是否处于选中区域</returns>
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

        #region add by myc 2014-06-12 注释原因：以下方法并未处理选中区域边界上的回车符和一个字符被选中情况
        ///// <summary>
        ///// 判断是否存在选择的项目
        ///// </summary>
        ///// <returns></returns>
        //public bool HasSelected()
        //{
        //    return (intSelectLength != 0);
        //} 
        #endregion

        /// <summary>
        /// 判断是否选择了文本
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
        /// 获得选中的文本
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
        /// 判断是否选择了文本
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


        #region add by myc 2014-06-09 注释原因：此方法没有对单元格元素作处理，不完善，而且影响到光标在表格内的正确移动
        ///// <summary>
        ///// 将插入点尽量移动到指定位置
        ///// </summary>
        ///// <param name="x">指定位置的X坐标</param>
        ///// <param name="y">指定位置的Y坐标</param>
        //public void MoveTo(int x, int y)
        //{
        //    //intLastXPos = -1;
        //    if (myDocument != null)
        //    {
        //        ZYTextLine CurrentLine = null;

        //        //mfb 2009-7-14 改了定位行的方法
        //        foreach (ZYTextLine myLine in myDocument.Lines)
        //        {
        //            Rectangle lineRec = new Rectangle(myLine.RealLeft, myLine.RealTop, myLine.ContentWidth, myLine.FullHeight);
        //            if (lineRec.Contains(new Point(x, y)))
        //            {
        //                CurrentLine = myLine;
        //                break;
        //            }
        //        }

        //        //Debug.WriteLine("◣◣◣◣" + CurrentLine.Elements.Count);
        //        // 若没有找到当前行则设置最后一行为当前行
        //        if (CurrentLine == null && myDocument.Lines.Count > 0)
        //        {
        //            CurrentLine = (ZYTextLine)myDocument.Lines[myDocument.Lines.Count - 1];
        //        }

        //        // 若最后还是没有找到当前行则函数处理失败，立即返回
        //        if (CurrentLine == null)
        //            return;

        //        bool bolFlag = false;
        //        int index = 0;
        //        x -= CurrentLine.RealLeft;

        //        // 确定当前元素,当前元素是当前行中右边缘大于指定的Ｘ坐标的元素
        //        ZYTextElement CurrentElement = null;
        //        //当前行是一个空行,是一个空的P元素
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
        //            // 若没找到当前元素则表示当前位置已向右超出当前行的范围
        //            // 若当前行已换行符结尾则设置该换行符为当前元素
        //            // 否则设置为当前行最后一个元素的下一个元素,并设置行尾标志
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
        //            //找到正常的字符
        //            index = myElements.IndexOf(CurrentElement);
        //            bolFlag = false;
        //        }
        //        // 修正当前元素序号
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
        //    //			// 遍历所有的元素
        //    //			for( int iCount = myElements.Count -1 ; iCount >=0 ; iCount -- )
        //    //			{
        //    //				myElement = ( ZYTextElement) myElements[iCount];
        //    //				if( bolCorrectLine )
        //    //				{
        //    //					if( myElement.LineIndex == LastLineIndex )
        //    //					{
        //    //						if( x > (myElement.RealLeft   + myElement.Width / 2 ) )
        //    //						{
        //    //							// 若当前元素的中轴线在指定点的左边则将插入点定在该元素的右边(设置该元素的下一个元素为当前元素)
        //    //							// 若该元素为第一个高度匹配的元素则设置该元素为当前元素
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
        //    //						// 若元素所在文本行的绝对顶端位置小于指定位置的Y坐标,则插入点位于该行
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

        #region add by myc 2014-06-12 注释原因：此方法并没有对选中区域边界上含有回车符时作出正确处理
        ///// <summary>
        ///// 设置选择区域大小
        ///// </summary>
        ///// <param name="NewSelectStart">新的选择区域开始的序号</param>
        ///// <param name="NewSelectLength">新选择区域的长度</param>
        ///// <returns>操作是否成功</returns>
        //public bool SetSelection(int NewSelectStart, int NewSelectLength)
        //{
        //    bolLineEndFlag = false;
        //    if (myElements == null || myElements.Count == 0)
        //    {
        //        return false;
        //    }

        //    int sourceIndex = 0; //原来的索引位置
        //    int sourceLength = 0; //原来的选择长度,未选择则为0

        //    int newIndex = 0; //最新的索引位置
        //    int newLength = 0; //最新的选择长度

        //    int intTemp = 0;

        //    NewSelectStart = FixIndex(NewSelectStart);
        //    int iStep = (NewSelectStart > intSelectStart ? 1 : -1);

        //    bool bolZeroSelection = (NewSelectLength == 0);

        //    // 根据当前元素的父对象是否是一个整体进行插入点的修正
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

        //    //若选择区域未发生改变则直接退出函数
        //    if (intSelectStart == NewSelectStart && intSelectLength == NewSelectLength)
        //        return true;

        //    int OldSelectStart = intSelectStart;

        //    //ZYTextElement OldElement = ( ZYTextElement  )myElements[OldSelectStart] ;

        //    // 如果没有选择多个元素,或者说未发生 "划划划" 选
        //    // 只是鼠标点了一下而已,没什么大惊小怪的.
        //    if (NewSelectLength == 0 && intSelectLength == 0)
        //    {
        //        //保存本次点击的索引位置
        //        intSelectStart = NewSelectStart;

        //        //如果超出范围,该咋办咋办.反正不是定位到第一个元素,就是定位到最后一个元素
        //        if (intSelectStart < 0)
        //        {
        //            intSelectStart = 0;
        //        }
        //        if (intSelectStart >= myElements.Count)
        //        {
        //            intSelectStart = myElements.Count - 1;
        //        }
        //        //获取点击处的元素
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
        //    else //难道还有小于0的情况?
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
        //    // [s1->s2] 和 [e1->e2] 为文档中选中状态发生改变的元素的序号范围
        //    //
        //    //			// 遍历所有的文本行进行选中状态改变操作
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

        #region add by myc 2014-07-03 注释原因：新版页眉二期改版需要
        ///// <summary>
        ///// 修正元素序号以保证需要在元素列表的范围内
        ///// </summary>
        ///// <param name="index">原始的序号</param>
        ///// <returns>修正后的序号</returns>
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
        /// 选择所有的元素
        /// </summary>
        public void SelectAll()
        {
            //this.SetSelection(0, myElements.Count);
            //this.SetSelection(myElements.Count, -myElements.Count); //add by myc 2014-06-17 添加原因：Ctrl+A全选文档元素操作
            this.SetSelection(HBFElements.Count, -HBFElements.Count); //add by myc 2014-06-17 添加原因：Ctrl+A全选文档元素操作
        }

        #endregion

        #region add by myc 2014-06-12 注释原因：此方法并没有对选中区域边界上含有回车符时作出正确处理
        ///// <summary>
        ///// 移动当前插入点的位置
        ///// </summary>
        ///// <param name="index">插入点的新的位置</param>
        ///// <returns>操作是否成功</returns>
        //public bool MoveSelectStart(int index)
        //{
        //    index = this.FixIndex(index);
        //    int length = bolAutoClearSelection ? 0 : intSelectLength + intSelectStart - index;

        //    //Debug.WriteLine("zycontent MoveSelectStart 设置选择范围 " + index + "-" + length);

        //    return SetSelection(index, length);
        //}
        #endregion

        #region add by myc 2014-07-03 注释原因：新版页眉二期改版需要
        ///// <summary>
        ///// 将插入点移动到指定元素前面
        ///// </summary>
        ///// <param name="refElement">指定的元素</param>
        ///// <returns>操作是否成功</returns>
        //public bool MoveSelectStart(ZYTextElement refElement)
        //{
        //    if (myElements.IndexOf(refElement) >= 0)
        //    {
        //        return MoveSelectStart(myElements.IndexOf(refElement));
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// 获得所有选择区域的元素
        ///// </summary>
        ///// <returns>包含所有选中区域的元素的列表</returns>
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

        #region add by myc 2014-06-23 注释原因：此方法并没有对选中区域边界上含有回车符时和只读文本、复选项目等结构化元素作出正确处理
        ///// <summary>
        ///// 获得所有选择区域的段落元素mfb
        ///// </summary>
        ///// <returns>包含选择区域中所有段落元素的列表,若操作失败则返回空引用</returns>
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
        /// 获得两个序号之间的所有元素
        /// </summary>
        /// <param name="Index1">序号1</param>
        /// <param name="Index2">序号2</param>
        /// <returns>保存序号在指定的两个序号之间的所有元素的列表对象</returns>
        public System.Collections.ArrayList GetElementsRange(int Index1, int Index2)
        {
            //if (myElements == null) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
                    //myList.Add(myElements[iCount]); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    myList.Add(HBFElements[iCount]); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return myList;
            }
        }

        /// <summary>
        /// 若当前选中的一个元素则返回当前选择的元素,否则返回空引用
        /// </summary>
        /// <returns></returns>
        public ZYTextElement GetSelectElement()
        {
            if (intSelectLength == 1)
                //return (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                return (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            if (intSelectLength == -1)
                //return (ZYTextElement)myElements[intSelectStart - 1]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                return (ZYTextElement)HBFElements[intSelectStart - 1]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要 
            return null;
        }

        /// <summary>
        /// 获得选中区域的文本内容
        /// </summary>
        /// <returns></returns>
        public string GetSelectText()
        {
            return ZYTextElement.GetElementsText(this.GetSelectElements());
        }

        /// <summary>
        /// 使用指定文本替换选择区域
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns> 
        public bool ReplaceSelection(string strText)
        {
            if (strText == null || strText.Length == 0)
                return false;
            //this.DeleteSeleciton();

            //this.DeleteSelectedElements(); //add by myc 2014-08-07 注释原因：剪切板操作时如果遇到固定文本元素则不能进行原位置粘贴操作
            //this.InsertString(strText);


            if (this.DeleteSelectedElements()) //add by myc 2014-08-07 添加原因：剪切板操作时必须先检查是否完成正确的删除选定区域元素操作
            {
                this.InsertString(strText);
            }


            bolModified = true;
            return true;
        }

        /// <summary>
        /// 插入一批元素
        /// </summary>
        /// <param name="myList"></param>
        public void InsertRangeElements(System.Collections.ArrayList myList)
        {
            //if (myElements == null || myElements.Count == 0 || myList == null || myList.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0 || myList == null || myList.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (IsLock(intSelectStart))
                return;

            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            ZYTextContainer myParent = myElement.Parent;
            //不能在ZYTextBlock插入子元素
            if (myParent is ZYTextBlock)
            {
                myElement = myParent;
                myParent = myParent.Parent;
            }

            // 向当前元素所在的父对象插入新增的字符元素
            #region bwy
            //要修改此处，如果遇到EOF要产生新的段落，方法未完
            ArrayList templist = new ArrayList();
            foreach (object o in myList)
            {
                if (o is ZYTextEOF)
                {
                    myParent.InsertRangeBefore(templist, myElement);
                    myParent.RefreshLine();

                    templist.Clear();
                    this.Document._InsertChar('\r');

                    //myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    myParent = myElement.Parent;
                    //不能在ZYTextBlock插入子元素
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

            if ((myList[0] as ZYTextElement).Parent != null)//排除只复制换行符的情况 edit by ld 2015-12-08
            {
                #region add by myc 2014-05-21 可复用项目或子模板替换时的单元格自适应高度调整
                if ((myList[0] as ZYTextElement).Parent.Parent is TPTextCell) //第一次检查当前元素的祖父层次容器
                {
                    ((myList[0] as ZYTextElement).Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if ((myList[0] as ZYTextElement).Parent.Parent.Parent is TPTextCell) //第二次检查当前元素的曾祖父层次容器
                {
                    ((myList[0] as ZYTextElement).Parent.Parent.Parent as TPTextCell).AdjustHeight();
                }
                #endregion
            }
            myParent.RefreshLine();

            #endregion bwy
            //myParent.InsertRangeBefore(myList, myElement);//原
            //myParent.RefreshLine();
            bolModified = true;
            // 移动当前插入点到新增的字符串的末尾
            if (myDocument != null) myDocument.ContentChanged();
            this.AutoClearSelection = true;

            //this.MoveSelectStart(intSelectStart + myList.Count);
            #region bwy : 将上面一句改为如下
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
        /// 在当前位置插入一个字符串
        /// </summary>
        /// <param name="strText">字符串</param>
        public void InsertString(string strText)
        {
            bool isNeedRefreshLine = true; //当辅助决策弹窗插入段落时，不需要刷新行（既往史用）

            //if (myElements == null || myElements.Count == 0) return; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) return; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            if (IsLock(intSelectStart))
                return;

            this.Document.BeginUpdate();
            this.Document.BeginContentChangeLog();

            ZYTextChar NewChar = null;
            ZYTextChar defChar = null;

            //*********************Modified by wwj 2012-05-29 更改抓取前一个字符的规则**********************
            //ZYTextFlag defFlag = null;
            // 首先试图找到向前最近的一个字符类型的数据
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

            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            ZYTextContainer myParent = myElement.Parent;

            //2019.8.6-hdf：宏元素、格式化字符串、复用项目文本录入优化，根据光标左右块元素焦点判断是否是否录入到块元素内
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
                if (!new string[] { "中医诊断", "西医诊断", "证候诊断" }.Contains((myParent as ZYSubject).Name))
                {
                    if (strText == "，" || strText == "," || strText == "、")
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

                    //判断标签是否开启辅助决策
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

                    if (strText == "，" || strText == "," || strText == "、")
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
                //解决在结构化元素前粘贴内容的时候，被粘贴的内容与结构化元素的内容融合为一体的Bug
                //如：{a,b,{d,e,f}} -------其中 a、b为自由文本， d、e、f是结构化元素的内容
                //这个时候往b和d的中间插入自由文本c，则插入后的效果应该是 {a,b,c,{d,e,f}} 而不是 {a,b,{c,d,e,f}}
                //注意：确保当前元素是其父元素下的第一个子元素时才进入此逻辑
                if (myParent != null && !(myParent is ZYTextParagraph) && myParent.Parent is ZYTextParagraph && myParent.ChildElements.IndexOf(myElement) == 0)
                {
                    myElement = myParent;
                    myParent = myParent.Parent;
                }

            }
            //2019.8.12-hdf：添加格式化字符串长度校验
            if (myParent is ZYFormatString && (myParent as ZYTextBlock).IsFocus && (myParent as ZYFormatString).ChildCount + strText.Length > (myParent as ZYFormatString).Length)
            {
                this.SelectLength = 0;
                this.Document.EndContentChangeLog();
                this.Document.EndUpdate();
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("长度超出最大限制！");
                return;
            }



            // 根据字符串新增一系列字符元素对象
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

                    #region add by myc 2014-07-17 注释原因：新版字体属性控制需要
                    //if (defChar != null)
                    //    defChar.Attributes.CopyTo(NewChar.Attributes);

                    ////如果是在一个空段处，那么以默认字体大小为准 add by wwj 2012-05-29
                    //if (myElement is ZYTextEOF && myElement == myParent.FirstElement)
                    //{
                    //    NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, myElement.OwnerDocument.OwnerControl.GetDefaultFontSize());
                    //} 
                    #endregion

                    #region add by myc 2017-07-17 添加原因：新版字体属性控制
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

            //Add by wwj 2013-02-01 移除ArrayList末尾的ZYTextLineEnd元素,防止出现硬回车和软回车叠加的问题
            RemoveTheEndOFZYTextLineEnd(myList);

            //myElement.OwnerDocument.ContentChangeLog.CanLog = true;
            // 向当前元素所在的父对象插入新增的字符元素


            myParent.InsertRangeBefore(myList, myElement);


            if (myList.Count > 0)//排除只复制换行符的情况 edit by ld 2015-12-08
            {
                #region add by myc 2014-03-18 新版表格绘制之单元格内部新增或删除元素时的自适应高度调整
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

            if (myParent is ZYSubject && (myParent as ZYSubject).Name == "主诉" && null != delChangeSubjectStr)
            {
                delChangeSubjectStr();
            }

            // 移动当前插入点到新增的字符串的末尾
            if (myDocument != null) myDocument.ContentChanged();
            this.AutoClearSelection = true;
            this.MoveSelectStart(intSelectStart + myList.Count);//Modify by wwj 2013-02-01 移动光标至正确的位置

        }

        /// <summary>
        /// 移除ArrayList末尾的ZYTextLineEnd元素 Add by wwj 2013-02-01
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
        /// 获得当前插入点前最近的一个字符元素
        /// </summary>
        /// <returns>最近的字符元素，若没找到则返回空引用</returns>
        public ZYTextChar GetPreChar()
        {
            //for (int iCount = (intSelectStart == 0 && myElements.Count > 1 ? 1 : intSelectStart - 1); iCount >= 0; iCount--)
            //    if (myElements[iCount] is ZYTextChar)
            //    {
            //        return (ZYTextChar)myElements[iCount];
            //        //break;
            //    } //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            for (int iCount = (intSelectStart == 0 && HBFElements.Count > 1 ? 1 : intSelectStart - 1); iCount >= 0; iCount--)
                if (HBFElements[iCount] is ZYTextChar)
                {
                    return (ZYTextChar)HBFElements[iCount];
                    //break;
                } //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            return null;
        }

        /// <summary>
        /// 在当前位置插入一个字符串
        /// </summary>
        /// <param name="vChar">字符</param>
        /// <returns>新增的字符对象</returns>
        public ZYTextChar InsertChar(char vChar)
        {
            //if (myElements == null || myElements.Count == 0) return null; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) return null; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            if (IsLock(intSelectStart))
            {
                return null;
            }

            if (intSelectStart < 0) intSelectStart = 0;
            //if (intSelectStart >= myElements.Count) intSelectStart = myElements.Count - 1; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (intSelectStart >= HBFElements.Count) intSelectStart = HBFElements.Count - 1; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

            ZYTextChar NewChar = null;
            // 首先试图找到向前最近的一个字符类型的数据
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

            #region 2019.8.6-hdf：宏元素、格式化字符串、复用项目文本录入优化，根据光标左右块元素焦点判断是否是否录入到块元素内
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

                if (!new string[] { "中医诊断", "西医诊断", "证候诊断" }.Contains((myParent as ZYSubject).Name))
                {
                    if (vChar == '，' || vChar == ',' || vChar == '、')
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
                    if (vChar == '，' || vChar == ',' || vChar == '、')
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


            //2019.8.12-hdf：添加格式化字符串长度校验
            if (myParent is ZYFormatString && (myParent as ZYTextBlock).IsFocus && (myParent as ZYFormatString).ChildCount + 1 > (myParent as ZYFormatString).Length)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("长度超出最大限制！");
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
                //defChar.Attributes.CopyTo(NewChar.Attributes); //add by myc 2017-07-17 注释原因：新版字体属性控制

                //不继承上下标
                NewChar.Attributes.SetValue(ZYTextConst.c_Sup, false);
                NewChar.Attributes.SetValue(ZYTextConst.c_Sub, false);

                //NewChar.ForeColor = ColorTranslator.FromHtml(ColorTranslator.ToHtml(defChar.ForeColor)); //add by myc 2014-03-24 页眉区域字体属性之颜色设置更改需要
            }

            #region add by myc 2017-07-17 注释原因：新版字体属性控制
            NewChar.Attributes.SetValue(ZYTextConst.c_FontName, myDocument.FontPropertyManager.FontName);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, myDocument.FontPropertyManager.FontSize);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontBold, myDocument.FontPropertyManager.FontBold);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontItalic, myDocument.FontPropertyManager.FontItalic);
            NewChar.Attributes.SetValue(ZYTextConst.c_FontUnderLine, myDocument.FontPropertyManager.FontUnderLine);
            NewChar.Attributes.SetValue(ZYTextConst.c_ForeColor, ColorTranslator.FromHtml(ColorTranslator.ToHtml(myDocument.FontPropertyManager.ForeColor)));
            #endregion

            NewChar.CreatorIndex = this.Document.SaveLogs.CurrentIndex;

            //**************************Modified by wwj 2012-05-29**********************************
            //#region bwy 如果是在一个空段处，且设置了回车符的字体大小，那么应该以这个为准
            //if (myElement is ZYTextEOF && myElement == myParent.FirstElement && (myElement as ZYTextEOF).FontSize != 0)
            //{
            //    NewChar.Attributes.SetValue(ZYTextConst.c_FontSize, (myElement as ZYTextEOF).FontSize);
            //}
            //#endregion bwy

            #region 如果是在一个空段处，那么以默认字体大小为准
            //if (myElement is ZYTextEOF && myElement == myParent.FirstElement) //add by myc 2017-07-17 注释原因：新版字体属性控制
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


            #region add by myc 2014-03-18 新版表格绘制之单元格内部新增或删除元素时的自适应高度调整
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

            if (myParent is ZYSubject && (myParent as ZYSubject).Name == "主诉" && null != delChangeSubjectStr)
            {
                delChangeSubjectStr();
            }

            this.AutoClearSelection = true;
            // 移动当前插入点到新增的字符串的末尾
            this.MoveSelectStart(intSelectStart + 1);



            return NewChar;
        }

        /// <summary>
        /// 在当前位置插入一个元素
        /// </summary>
        /// <param name="NewElement"></param>
        public void InsertElement(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) return null; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            ZYTextContainer myParent = myElement.Parent;

            //2019.8.15-hdf：当光标左边或右边是宏元素、格式化字符串、复用项目，并且焦点进入了块元素，并且插入的元素是软回车
            //则把软回车元素插入到块元素内部
            ZYTextElement eleLeft = new ZYTextElement();
            if (intSelectStart > 0)
            {
                eleLeft = HBFElements[intSelectStart - 1] as ZYTextElement;
            }
            if (((myElement.Parent is ZYMacro || myElement.Parent is ZYReplace || myElement.Parent is ZYFormatString || myElement.Parent is ZYDiag) && (myElement.Parent as ZYTextBlock).IsFocus && NewElement is ZYTextLineEnd))
            {
                //当向光标右边的块元素内插入软回车
            }
            else if ((eleLeft.Parent is ZYMacro || eleLeft.Parent is ZYReplace || eleLeft.Parent is ZYFormatString || eleLeft.Parent is ZYDiag) && (eleLeft.Parent as ZYTextBlock).IsFocus && NewElement is ZYTextLineEnd)
            {
                //当向光标左边的块元素内插入软回车
                //把myParent换成获得焦点的块元素，把myELement设置null，向块元素最后添加软回车
                myElement = null;
                myParent = eleLeft.Parent;
            }
            //不能在ZYTextBlock插入子元素
            else if (myParent is ZYTextBlock)
            {
                myElement = myParent;
                myParent = myParent.Parent;
            }


            if (myParent.InsertBefore(NewElement, myElement))
            {
                bolModified = true;



                #region add by myc 2014-03-18 新版表格绘制之单元格内部新增或删除元素时的自适应高度调整
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
        /// 回车时插入一个段落
        /// </summary>
        /// <param name="NewElement">一个新的空段落元素</param>
        public void InsertParagraph(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) return null; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                return;
            }

            bool isContentChange = false;

            //当前元素(这里为一个eof符)
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            if (myElement.Parent is ZYTextBlock)
            {
                myElement = myElement.Parent;
            }
            //当前元素所属的段落对象

            ZYTextElement parent = myElement.Parent;
            while (!(parent is ZYTextParagraph))
            {
                parent = parent.Parent;
            }
            ZYTextParagraph Paraparent = parent as ZYTextParagraph;//myElement.Parent as ZYTextParagraph;

            //当前元素所属的容器的容器
            //ZYTextContainer divParent = myElement.Parent.Parent;
            ZYTextContainer divParent = Paraparent.Parent;

            if (myElement == Paraparent.LastElement)//当前元素为段落中最后一个元素
            {
                divParent.InsertAfter(NewElement, Paraparent);
                myElement = (NewElement as ZYTextParagraph).FirstElement;

                #region add by myc 2017-07-17 注释原因：新版字体属性控制
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
            else if (myElement == Paraparent.FirstElement)//当前元素为段落中第一个元素
            {
                divParent.InsertBefore(NewElement, Paraparent);
                myElement = (Paraparent as ZYTextParagraph).FirstElement;

                #region add by myc 2017-07-17 注释原因：新版字体属性控制
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
            else//当前元素为段落中的元素
            {
                int currentIndex = Paraparent.IndexOf(myElement);

                #region bwy
                ArrayList myList = new ArrayList();
                myList = Paraparent.ChildElements.GetRange(currentIndex, Paraparent.ChildElements.Count - currentIndex - 1);
                //copy 当前段中所有元素
                System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
                myDoc.PreserveWhitespace = true;
                myDoc.AppendChild(myDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                ZYTextElement.ElementsToXML(myList, myDoc.DocumentElement);

                //删除当段中当前元素后的元素

                Paraparent.RemoveChildRange(myList);

                ZYTextParagraph secondPara = new ZYTextParagraph();

                #region add by myc 2017-07-17 注释原因：新版字体属性控制
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

                //还原copy并插入到上一段,past
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



                #region add by myc 2014-03-18 新版表格绘制之单元格内部新增或删除元素时的自适应高度调整
                if (this.CurrentElement.Parent.Parent is TPTextCell)  //第一次检查当前元素的祖父层次容器
                {
                    (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //第二次检查当前元素的曾祖父层次容器
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


            myDocument.OwnerControl.ScrollViewToCaretVisibleDown(this.PreLine, this.CurrentLine); //add by myc 2014-08-08 调用ScrollViewToCaretVisibleDown例程使得敲入回车符时光标可见

        }

        #region ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅ 表格相关方法 ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅

        /// <summary>
        /// 在当前插入点处插入一个表格
        /// </summary>
        /// <param name="NewElement">表示一个表格元素</param>
        public void InsertTable(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

            //获得当前元素所在的段落
            ZYTextContainer secondaryParent = GetParentByElement(myElement, ZYTextConst.c_P) as ZYTextContainer;

            //ZYTextContainer rootParent = GetParentByElement(myElement, ZYTextConst.c_Div) as ZYTextDiv; add by myc 2014-07-04 注释原因：新版页眉二期改版需要

            #region add by myc 2014-07-04 添加原因：新版页眉二期改版之页眉区域插入表格
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

            //在元素所属的段落后插入一个表格.
            rootParent.InsertAfter(NewElement, secondaryParent);

            //然后再表格后再插入一个新的段落元素.
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
        /// mfb 在插入点处插入若干行
        /// </summary>
        /// <param name="RowNum">要插入的行数</param>
        /// <param name="IsAfter">是否在插入点后插入</param>
        public void InsertRows(int RowNum, bool IsAfter)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;
            //获得当前元素
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

            //获得当前表格
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                //获得当前行
                TPTextRow currentRow = GetParentByElement(myElement, ZYTextConst.c_Row) as TPTextRow;


                //获得当前行所在表格的索引
                int rowIndex = currentTable.IndexOf(currentRow);

                //如果在当前行前插入
                for (int k = 0; k < RowNum; k++)
                {
                    if (!IsAfter)
                    {
                        currentTable.InsertRow(rowIndex, currentRow);
                    }
                    else
                    {
                        //在最后一行之后插入
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
                //重新设置表格内所有单元格的边框宽度
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
        /// mfb 在插入点处插入若干个列
        /// </summary>
        /// <param name="columnNum">要插入的列数</param>
        /// <param name="IsAfter">是否在插入点之后插入</param>
        public void InsertColumns(int columnNum, bool IsAfter)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;

            //获得当前元素
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

            //获得当前表格
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                //获得当前行
                TPTextRow currentRow = GetParentByElement(myElement, ZYTextConst.c_Row) as TPTextRow;

                //获得当前单元格
                TPTextCell currentCell = GetParentByElement(myElement, ZYTextConst.c_Cell) as TPTextCell;

                //获得当前行所在表格的索引
                int rowIndex = currentTable.IndexOf(currentRow);

                //获得当前单元格所在行的索引
                int cellIndex = currentRow.IndexOf(currentCell);

                for (int k = 0; k < columnNum; k++)
                {
                    //如果在当前列前插入
                    if (!IsAfter)
                    {
                        currentTable.InsertColumns(cellIndex, currentCell);
                    }
                    else
                    {
                        //如果是最后一个单元格
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
                //重新设置表格内所有单元格的边框宽度
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
        /// mfb 删除选择元素所在的表格
        /// </summary>
        public void DeleteTable()
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;
            //如果有有选择了多项内容,则判断这些内容是不是都在表格内的.
            //如果是则删除表格,如果不是则不进行动作
            if (HasSelected())
            {
                int StartIndex = this.AbsSelectStart;
                int EndIndex = this.AbsSelectEnd;
                int iLen = (intSelectLength > 0 ? intSelectLength : 0 - intSelectLength);

                System.Collections.ArrayList myList = this.GetSelectElements();

                //是否所有选择的元素都在table中
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
                    //获得选中元素列表的第一个元素
                    //ZYTextElement myElement = (ZYTextElement)myElements[StartIndex]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    ZYTextElement myElement = (ZYTextElement)HBFElements[StartIndex]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    ZYTextElement currentTable = GetParentByElement(myElement, ZYTextConst.c_Table);

                    ZYTextContainer bodyElement = GetRootElement(myElement) as ZYTextContainer;

                    bodyElement.RemoveChild(currentTable);
                }
            }
            else
            {
                //获得当前元素
                //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

                //获得当前表格
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
        /// mfb 删除选择元素所在的行
        /// </summary>
        public void DeleteRows()
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;

            //获得当前元素
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            //获得当前表格
            TPTextTable currentTable = GetParentByElement(myElement, ZYTextConst.c_Table) as TPTextTable;
            if (currentTable != null)
            {
                //保存所有选择的元素所属的行列表
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

                //遍历所有选择的行,并删除之
                foreach (TPTextRow rowElement in rowList)
                {
                    currentTable.AllRows.Remove(rowElement);
                    currentTable.RemoveChild(rowElement);

                    #region 2021-04-13:当删除行时存在合并单元格时，仅删除选中行的部分，合并的单元格进行重置高度，被合并的单元格进行恢复
                    
                    foreach (var cell in rowElement)
                    {
                        if (cell.OwnerMergeCell != null)
                        {//当单元格是被合并的，重置所属合并各自的高度（减去当前删除格子的高度）
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
                                //计算单元格纯粹单行的高度
                                var ch = c.HasFlagCells.Count > 0 ? c.Height - c.HasFlagCells.Sum(a => a.Height) : c.Height;

                                //出由于内容太多导致删除行后单元格的高度小于内容高度，计算出高度差并刷新同行的其他单元格
                                var 高度差 = ch - (cell.OwnerMergeCell.Height - cell.OwnerMergeCell.HasFlagCells.Where(a => a != cell).Sum(a => a.Height));
                                if (高度差 != 0)
                                {
                                    if (Document.CanContentChangeLog)
                                    {
                                        Document.ContentChangeLog.Container = c;
                                        Document.ContentChangeLog.LogProperty(c, c.GetType().GetProperty("ContentHeight"), c.ContentHeight, c.ContentHeight - 高度差);
                                    }
                                    c.ContentHeight -= 高度差;
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
                        {//当单元格是合并单元格，则删除格子，并恢复被合并的格子
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
        /// mfb 删除选择元素所在的列
        /// </summary>
        public void DeleteColumns()
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;

            //获得当前元素
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            //获得当前表格
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
                    //TODO: 这里还需要斟酌一下.
                    //因为要删除的列都是紧挨着的,删除完第一个后. 后面的列的索引
                    //随之也会变化(自动减1),所以始终用第一个列号应该是正确的.
                    //功能虽然暂时达到,但是感觉不是回事,逻辑不严谨.
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
        /// mfb 判断当前元素(或容器)是否在一个cell中
        /// </summary>
        /// <returns></returns>
        public bool IsParaInCell(ZYTextElement CurrentElement)
        {
            //if (CurrentElement.GetXMLName() == ZYTextConst.c_Div) //add by myc 2014-07-10 注释原因：这种判断不兼容新版页眉和新版页脚
            //{
            //    return false;
            //}

            #region add by myc 2014-07-10 添加原因：兼容新版页眉和新版页脚
            //if (ZYTextDocument.CurrentEditingArea == 0) //页眉
            if (myDocument.EditingAreaFlag == 0) //页眉
            {
                if (CurrentElement.GetXMLName() == ZYTextConst.c_Header)
                {
                    return false;
                }
            }
            //else if (ZYTextDocument.CurrentEditingArea == 1) //正文
            else if (myDocument.EditingAreaFlag == 1) //正文
            {
                if (CurrentElement.GetXMLName() == ZYTextConst.c_Div)
                {
                    return false;
                }
            }
            //else if (ZYTextDocument.CurrentEditingArea == 2) //页脚
            else if (myDocument.EditingAreaFlag == 2) //页脚
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
        /// mfb 获取当前元素所属的父级元素
        /// </summary>
        /// <param name="currentElement">当前元素</param>
        /// <param name="findName">要找的父级元素的xmlName</param>
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


        #endregion ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅ end 表格相关插入方法 end ▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅▅


        /// <summary>
        ///  mfb 查找顶级body元素
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
        /// mfb 获得当前元素所属的最外层容器元素
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
        /// 插入签名
        /// </summary>
        /// <param name="NewElement"></param>
        public void InsertLock(ZYTextElement NewElement)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 删除选中区域的元素
        /// </summary>
        /// <param name="flag">删除标识，true 全部删除，false 固定文本不删除</param>
        public void DeleteSeleciton(bool flag)
        {
            this.Document.DeleteFlag = flag;
            //DeleteSeleciton();
            DeleteSelectedElements();
            this.Document.DeleteFlag = false;
        }
        /// <summary>
        /// 删除选中区域的元素  
        /// </summary>
        public bool DeleteSeleciton()//Modify by wwj 2013-02-01 增加返回值
        {
            //一定要基于Undo/redo 的几个方法才行
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要 
                return false;
            if (IsLock(intSelectStart))
                return false;

            ArrayList alp = this.GetSelectParagraph();

            //绝对的开始与结束位置，一定是前小后大

            int StartIndex = this.AbsSelectStart;
            int EndIndex = this.AbsSelectEnd;

            int iLen = (intSelectLength > 0 ? intSelectLength : 0 - intSelectLength);
            bool bolChanged = false;

            ///选择的字符列表
            System.Collections.ArrayList mySelList = this.GetSelectElements();
            //删除列表
            System.Collections.ArrayList myRemoveList = new System.Collections.ArrayList();
            //删除的真正元素列表
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
                        //    MessageBox.Show("选择范围中包含固定内容，不能删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return false;
                        //}
                        ////Add By wwj 2012-03-30 判断对ZYButton的删除操作
                        //if (ele is ZYButton && !((ZYButton)ele).CanDelete)
                        //{
                        //    MessageBox.Show("选择范围中包含固定内容，不能删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return false;
                        //}
                        ////Add By wwj 2013-08-01 判断对ZYFlag的删除操作
                        //if (ele is ZYFlag && !((ZYFlag)ele).CanDelete)
                        //{
                        //    MessageBox.Show("选择范围中包含固定内容，不能删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return false;
                        //}
                        bool canDelete = CanDeleteElement(ele);
                        if (!canDelete) return false;
                    }
                    //}
                }

                #region 获取当前被选中的表格,被选中表格的条件是从表格头选到表格尾 Add by wwj 2013-01-21
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

                    //p.LastElement 永远应是 EOF 
                    int pIndexEnd = p.LastElement.Index;

                    if (StartIndex <= pIndexStart && pIndexEnd <= EndIndex)
                    {
                        //如果要删除的段落在单元格内，则不用删除所有的段落,每个单元格中至少保留一个回车符，即至少保留一个段落 Add By wwj 2012-04-24 解决单元格内容删除的Bug
                        ZYTextElement textElement = this.GetParentByElement(p, ZYTextConst.c_Cell);
                        if (textElement != null)
                        {
                            if (((ZYTextContainer)textElement).ChildCount > 1)
                            {
                                //整段删除
                                p.Parent.RemoveChild(p);
                                //p.Parent.RefreshLine(); 
                                StartIndex += p.ChildCount;
                            }
                            else
                            {
                                //删除选择部分元素
                                myRemoveList = Elements.GetRange(StartIndex, EndIndex - StartIndex);
                                //转换为真正元素
                                myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                                p.RemoveChildRange(myRealRemoveList);
                                //p.RefreshLine(); //add by myc 2014-05-26 注释原因：删除选中区域元素时的单元格自适应高度调整
                            }
                        }
                        else
                        {
                            //Add by wwj 2013-02-01 增加段落删除前的判断
                            //由于在粘贴内容之前会清除选中的内容，如果当前为空行则不能删除此行
                            //增加此判断为了防止出现在粘贴内容后出现吃行的情况
                            if (StartIndex != EndIndex)
                            {
                                //整段删除
                                p.Parent.RemoveChild(p);
                                //p.Parent.RefreshLine(); //add by myc 2014-05-26 注释原因：删除选中区域元素时的单元格自适应高度调整
                            }
                        }
                    }
                    //选择在段中间
                    else if (pIndexStart <= StartIndex && EndIndex <= pIndexEnd)
                    {
                        //删除选择部分元素
                        myRemoveList = Elements.GetRange(StartIndex, EndIndex - StartIndex);
                        //转换为真正元素
                        myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                        p.RemoveChildRange(myRealRemoveList);
                        //p.RefreshLine(); //add by myc 2014-05-26 注释原因：删除选中区域元素时的单元格自适应高度调整
                    }

                    //是第一个被选择段 
                    else if (StartIndex > pIndexStart)
                    {
                        //删除选择部分元素
                        myRemoveList = Elements.GetRange(StartIndex, p.LastElement.Index - StartIndex);
                        //转换为真正元素
                        myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                        p.RemoveChildRange(myRealRemoveList);
                        //p.RefreshLine(); //add by myc 2014-05-26 注释原因：删除选中区域元素时的单元格自适应高度调整
                    }
                    //是最后一个被选择段
                    else if (pIndexEnd > EndIndex)
                    {
                        myRemoveList = Elements.GetRange(pIndexStart, EndIndex - pIndexStart);
                        myRealRemoveList = this.Document.GetRealElements(myRemoveList);
                        p.RemoveChildRange(myRealRemoveList);
                        //p.RefreshLine(); //add by myc 2014-05-26 注释原因：删除选中区域元素时的单元格自适应高度调整
                    }

                }

                //还原StartIndex变量的值 Add By wwj 2012-04-24
                StartIndex = this.AbsSelectStart;

                #region add by myc 2014-05-26 注释原因：此段检查代码应该放在删除表格之后，确保选中文档所有表格直接按下Enter键时不出现异常
                ////如果文档中一个段都没有了，需要new一个新段，加入文档中，否则，无法输入
                //if (this.Document.RootDocumentElement.ChildCount == 0)
                //{
                //    //MessageBox.Show("一个空段都没有了，还不快加一个");
                //    ZYTextParagraph myP = new ZYTextParagraph();
                //    myP.OwnerDocument = this.Document;
                //    this.InsertParagraph(myP);
                //} 
                #endregion

                #region 删除选中的表格 Add by wwj 2013-01-21
                if (selectionTableDict.Count > 0)
                {
                    foreach (KeyValuePair<ZYTextElement, TPTextTable> pair in selectionTableDict)
                    {
                        ZYTextContainer bodyElement = GetRootElement(pair.Key) as ZYTextContainer;
                        bodyElement.RemoveChild(pair.Value);
                    }
                }
                #endregion

                #region add by myc 2014-05-26 注释原因：此段检查代码应该放在删除表格之后，确保选中文档所有表格直接按下Enter键时不出现异常
                //如果文档中一个段都没有了，需要new一个新段，加入文档中，否则，无法输入
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

                #region add by myc 2014-03-18 新版表格绘制之单元格内部新增或删除元素时的自适应高度调整
                if (this.CurrentElement.Parent.Parent is TPTextCell)  //第一次检查当前元素的祖父层次容器
                {
                    (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
                }
                else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //第二次检查当前元素的曾祖父层次容器
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
            #region bwy : 消除删除最末尾文本后产生的下划线或上划线，刷新这个区域。
            this.Document.OwnerControl.Invalidate();
            #endregion bwy :

            return true;
        }

        #region add by myc 2014-07-03 注释原因：新版页眉二期改版需要
        ///// <summary>
        ///// 检查选择区域数据,若数据错误在修复之
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

        #region add by myc 2014-08-06 注释原因：重构Delete删除元素操作例程需要
        ///// <summary>
        ///// 删除当前元素,函数返回0:确认删除元素 1:不删除该元素 2:对该元素进行逻辑删除
        ///// </summary>
        ///// <param name="flag">根据此参数决定删除固定元素时，是否需要进行提示</param>
        ///// <returns>操作结果</returns>
        //public int DeleteCurrentElement(params object[] flag)
        //{
        //    //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //    if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要 
        //        return 1;
        //    if (IsLock(intSelectStart)) return 1;

        //    if (this.CheckSelectStart())
        //    {
        //        ZYTextElement myElement = this.CurrentElement;
        //        //如果是固定文本，删除
        //        //如果是固定文本，且在编辑状，不删除
        //        if ((myElement.Parent is ZYFixedText || myElement.Parent is ZYText) && this.Document.Info.DocumentModel != DocumentModel.Design)
        //        {
        //            if (flag.Length > 0)
        //            {
        //                MessageBox.Show("删除范围中包含固定内容，不能删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //            return 1;
        //        }

        //        #region Add By wwj 2013-08-01 解决在不可删除的元素ZYButton、ZYFlag之前定位光标后，按下Delete键后元素被删除的问题
        //        if (myElement is ZYButton)
        //        {
        //            if (!((ZYButton)myElement).CanDelete)
        //            {
        //                MessageBox.Show("删除范围中包含固定内容，不能删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                return 1;
        //            }
        //        }
        //        else if (myElement is ZYFlag)
        //        {
        //            if (!((ZYFlag)myElement).CanDelete)
        //            {
        //                MessageBox.Show("删除范围中包含固定内容，不能删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                return 1;
        //            }
        //        }
        //        #endregion

        //        // 若当前元素不是最后一个元素则删除之
        //        //if (myElement != myElements[myElements.Count - 1]) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //        if (myElement != HBFElements[HBFElements.Count - 1]) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        //        {

        //            //ZYTextElement afterElement = (ZYTextElement)myElements[intSelectStart + 1]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //            ZYTextElement afterElement = (ZYTextElement)HBFElements[intSelectStart + 1]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

        //            ZYTextParagraph parentPara = myElement.Parent as ZYTextParagraph;

        //            ZYTextContainer parentDiv = myElement.Parent.Parent;
        //            #region bwy :
        //            if (myElement.Parent is ZYTextBlock)
        //            {
        //                //if (myElements.Count > intSelectStart + myElement.Parent.ChildCount)//Add by wwj 2013-05-07 解决在删除文档末尾的结构化元素出错的问题
        //                //{
        //                //    afterElement = (ZYTextElement)myElements[intSelectStart + myElement.Parent.ChildCount];
        //                //} //add by myc 2014-07-04 注释原因：新版页眉二期改版需要

        //                if (HBFElements.Count > intSelectStart + myElement.Parent.ChildCount) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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

        //                //如果光标所在处为一个空段落,则删除这个段落
        //                if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF)
        //                //if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF && !IsParaInCell(myElement))
        //                {
        //                    #region add by myc 2014-05-09 单元格内的Delete删除回车符处理
        //                    if (IsParaInCell(myElement))
        //                    {
        //                        if (parentDiv.IndexOf(parentPara) == parentDiv.ChildCount - 1)
        //                        {
        //                            return 1;
        //                        }
        //                    }
        //                    #endregion

        //                    //获取当前段落的上一个容器.
        //                    object tmpEle = parentDiv.ChildElements[parentDiv.ChildElements.IndexOf(parentPara) + 1];
        //                    //如果不是table,则正常处理,否则不执行任何动作.
        //                    if (!(tmpEle is TPTextTable))
        //                    {
        //                        myElement = (tmpEle as ZYTextParagraph).FirstElement;
        //                        parentDiv.RemoveChild(parentPara);
        //                        Document.RefreshElements();
        //                    }

        //                }
        //                //如果光标在段落的最后元素处,且段落不为空,则合并这个段落到上个段落中.
        //                else if (myElement == parentPara.LastElement && parentPara.ChildCount > 1)
        //                {
        //                    int currentParaIndex = parentDiv.IndexOf(parentPara);

        //                    //不是容器中的第一个元素
        //                    if (currentParaIndex < parentDiv.ChildCount - 1)
        //                    {
        //                        for (int i = 0; i < parentPara.ChildCount - 1; i++)
        //                        {
        //                            #region 解决在段落的末尾按下Delete键时，出现结构化元素合并的情况 2013-05-17
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




        //                #region add by myc 2014-03-18 新版表格绘制之单元格内部新增或删除元素时的自适应高度调整
        //                if (this.CurrentElement.Parent.Parent is TPTextCell)  //第一次检查当前元素的祖父层次容器
        //                {
        //                    (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
        //                }
        //                else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //第二次检查当前元素的曾祖父层次容器
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
        /// 获取元素element所在的段落paragraph，以及元素element在段落paragraph中的元素textElement
        /// 当元素element为自由文本时，element == textElement
        /// 当元素element为结构化元素中的某个对象时，element != textElement
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

        #region add by myc 2014-08-06 注释原因：重构Backspace删除元素操作例程需要
        ///// <summary>
        ///// 删除当前元素前一个元素,函数返回0:确认删除元素 1:不删除该元素 2:对该元素进行逻辑删除
        ///// </summary>
        ///// <returns>操作结果</returns>
        //public int DeletePreElement(params object[] flag)
        //{
        //    //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //    if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        //    {
        //        return 1;
        //    }
        //    if (IsLock(intSelectStart - 1))
        //    {
        //        return 1;
        //    }
        //    //光标在整片文档的中间,即不再开始,也不再末尾.
        //    //if (intSelectStart > 0 && intSelectStart < myElements.Count) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //    if (intSelectStart > 0 && intSelectStart < HBFElements.Count) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        //    {
        //        //判断是否光标在文档的结尾,判断这个是因为.
        //        //如果是最后一个元素,那么当删除这个元素时myElements.Count的值会变化.
        //        //随之intSelectStart也会跟着变,而其他情况不会这样.
        //        //bool isLastElement = (intSelectStart == (myElements.Count - 1)) ? true : false; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //        bool isLastElement = (intSelectStart == (HBFElements.Count - 1)) ? true : false; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

        //        //光标后的那个元素
        //        //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //        ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        //        //光标前的那个元素
        //        //ZYTextElement preElement = (ZYTextElement)myElements[intSelectStart - 1]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //        ZYTextElement preElement = (ZYTextElement)HBFElements[intSelectStart - 1]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        //        //如果是固定文本，且在编辑状，不删除
        //        if ((preElement.Parent is ZYFixedText || preElement.Parent is ZYText) && this.Document.Info.DocumentModel != DocumentModel.Design)
        //        {
        //            if (flag.Length > 0)
        //            {
        //                MessageBox.Show("删除范围中包含固定内容，不能删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //            return 1;
        //        }
        //        //Add By wwj 2012-03-30 判断对ZYButton的删除操作
        //        if (preElement is ZYButton) if (!((ZYButton)preElement).CanDelete) return 1;

        //        //Add By wwj 2013-08-01 判断对ZYFlag的删除操作
        //        if (preElement is ZYFlag) if (!((ZYFlag)preElement).CanDelete) return 1;

        //        //当前元素的父元素
        //        ZYTextParagraph parentPara = null;
        //        //但前元素的父元素的父元素(在表格中为cell,在普通文档中为body)
        //        ZYTextContainer parentDiv = null;


        //        //如果当前元素是ZYTextBlock, 则将ZYTextBlock做为一个整体处理
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

        //        //int OldIndex = myElements.IndexOf(preElement); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
        //        int OldIndex = HBFElements.IndexOf(preElement); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

        //        if (intDelete == 0)
        //        {
        //            //如果是空行合并到上一行,则myElement等于preElement.
        //            //如果是带内容的行合并到上一行, 则myElement要合并行的第一个元素,而preElement为合并后行的最后一个元素
        //            #region 合并段落代码块

        //            //如果光标所在处为一个空段落,且不在cell中.则删除这个段落
        //            if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF && !IsParaInCell(myElement))
        //            {
        //                //获取当前段落的上一个容器.
        //                object tmpEle = parentDiv.ChildElements[parentDiv.ChildElements.IndexOf(parentPara) - 1];
        //                //如果不是table,则正常处理,否则不执行任何动作.
        //                if (!(tmpEle is TPTextTable))
        //                {
        //                    myElement = (tmpEle as ZYTextParagraph).LastElement;
        //                    parentDiv.RemoveChild(parentPara);
        //                    myDocument.RefreshElements();
        //                }
        //            }

        //            //如果光标所在处为一个空段落,且在cell中.
        //            //且当前段落不是cell的第一个元素
        //            else if (myElement == parentPara.FirstElement && parentPara.ChildCount == 1 && parentPara.FirstElement is ZYTextEOF &&
        //                IsParaInCell(myElement) && parentPara != parentDiv.FirstElement)
        //            {
        //                myElement = (parentDiv.ChildElements[parentDiv.ChildElements.IndexOf(parentPara) - 1] as ZYTextParagraph).LastElement;
        //                parentDiv.RemoveChild(parentPara);
        //                myDocument.RefreshElements();
        //            }

        //            //如果光标在段落的第一个元素处,且段落不为空,则合并这个段落到上个段落中.
        //            else if (myElement == parentPara.FirstElement && parentPara.ChildCount > 1 && !(parentPara.FirstElement is ZYTextEOF))
        //            {
        //                int currentParaIndex = parentDiv.IndexOf(parentPara);

        //                //Add by wwj 2012-05-29 【由于在表格的单元格中，光标位于最前面，按下删除键后，在下面一行中会报错，所以这里加上判断，避免报错】 todo
        //                if (currentParaIndex - 1 < 0) return 1;

        //                object tmpEle = parentDiv.ChildElements[currentParaIndex - 1];
        //                //不是容器中的第一个元素
        //                if (currentParaIndex > 0 && !(tmpEle is TPTextTable))
        //                {
        //                    //创建一个内存区域
        //                    System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
        //                    myDoc.PreserveWhitespace = true;
        //                    myDoc.AppendChild(myDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));

        //                    //copy 当前段中所有元素到一个列表中，EOF除外
        //                    ArrayList myList = new ArrayList();
        //                    for (int i = 0; i < parentPara.ChildCount - 1; i++)
        //                    {
        //                        myList.Add(parentPara.ChildElements[i]);
        //                    }
        //                    //将列表中的所有元素以xml的形式存到内存中
        //                    ZYTextElement.ElementsToXML(this.Document.GetRealElements(myList), myDoc.DocumentElement);

        //                    //还原copy并插入到上一段,past
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


        //            //如果当前元素不是当前段落的第一个元素, 且前一个元素不是容器
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

        //            #region add by myc 2014-07-04 添加原因：移动光标必须放在文档内容更新完毕之后
        //            ////如果光标在文档的结尾
        //            //if (isLastElement)
        //            //{
        //            //    //this.SetSelection(intSelectStart, 0); //add by myc 2014-06-23 注释原因：删除一个字符之后光标就应该前移一位，否则影响后续的BackSpace操作
        //            //    this.SetSelection(intSelectStart - 1, 0);
        //            //}
        //            //else
        //            //{
        //            //    //修正了元素在一段开头处退格时，光标位置不对的问题
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

        //            #region add by myc 2014-07-04 添加原因：移动光标必须放在文档内容更新完毕之后
        //            ////如果光标在文档的结尾
        //            //if (isLastElement)
        //            //{
        //            //    //this.SetSelection(intSelectStart, 0); //add by myc 2014-06-23 注释原因：删除一个字符之后光标就应该前移一位，否则影响后续的BackSpace操作
        //            //    this.SetSelection(intSelectStart - 1, 0);
        //            //    //this.MoveSelectStart(myElement); //add by myc 2014-07-10 添加原因：最后更正，删除一个字符之后光标就应该前移一位，否则影响后续的BackSpace操作
        //            //}
        //            //else
        //            //{
        //            //    //修正了元素在一段开头处退格时，光标位置不对的问题
        //            //    if (myElement is ZYTextBlock)
        //            //    {
        //            //        this.MoveSelectStart((myElement as ZYTextBlock).FirstElement);
        //            //    }
        //            //    else
        //            //    {
        //            //        this.MoveSelectStart(myElement);
        //            //    }
        //            //}

        //            this.MoveSelectStart(preElement); //add by myc 2014-08-06 添加原因：修正页眉和页脚区域Backspace删除光标不能正确定位

        //            #endregion
        //            //this.SetSelection(OldIndex, 0); //add by myc 2014-07-11 备注：用这个可以解决光标位置问题，但替换页码后的重做栈有问题

        //            #region add by myc 2014-03-18 新版表格绘制之单元格内部新增或删除元素时的自适应高度调整
        //            if (this.CurrentElement.Parent.Parent is TPTextCell)  //第一次检查当前元素的祖父层次容器
        //            {
        //                (this.CurrentElement.Parent.Parent as TPTextCell).AdjustHeight();
        //            }
        //            else if (this.CurrentElement.Parent.Parent.Parent is TPTextCell) //第二次检查当前元素的曾祖父层次容器
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
        /// 获得所有文本内容
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            //return ZYTextElement.GetElementsText(myElements); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            return ZYTextElement.GetElementsText(HBFElements); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        }


        /// <summary>
        /// 获得插入点前第一个单词的起始位置
        /// </summary>
        /// <returns></returns>
        public int GetPreWordIndex()
        {
            //intSelectStart = this.FixIndex( intSelectStart );
            int index = -1;
            ZYTextLine myLine = this.CurrentLine;
            for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
            {
                //if (myElements[iCount] is ZYTextChar) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                if (HBFElements[iCount] is ZYTextChar) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                {
                    //ZYTextChar myChar = (ZYTextChar)myElements[iCount]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    ZYTextChar myChar = (ZYTextChar)HBFElements[iCount]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 获得插入点前第一个单词的起始位置
        /// </summary>
        /// <param name="myElement">指定的元素对象</param>
        /// <returns></returns>
        public int GetPreWordIndex(ZYTextElement myElement)
        {
            //intSelectStart = this.FixIndex( intSelectStart );
            int index = -1;
            //if (myElement == null || myElements.Contains(myElement) == false) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (myElement == null || HBFElements.Contains(myElement) == false) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return -1;
            //for (int iCount = myElements.IndexOf(myElement) - 1; iCount >= 0; iCount--) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            for (int iCount = HBFElements.IndexOf(myElement) - 1; iCount >= 0; iCount--) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                //if (myElements[iCount] is ZYTextChar) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                if (HBFElements[iCount] is ZYTextChar) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                {
                    //if (char.IsLetter((myElements[iCount] as ZYTextChar).Char)) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    if (char.IsLetter((HBFElements[iCount] as ZYTextChar).Char)) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 获得插入点前的单词
        /// </summary>
        /// <returns>获得的单词，若不存在则返回空引用</returns>
        public string GetPreWord()
        {
            int index = this.GetPreWordIndex();
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            ZYTextChar myChar = null;
            if (index >= 0)
            {
                for (int iCount = index; iCount < intSelectStart; iCount++)
                {
                    //myChar = myElements[iCount] as ZYTextChar; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    myChar = (ZYTextChar)HBFElements[iCount] as ZYTextChar; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 获得指定元素前的单词
        /// </summary>
        /// <param name="myElement">指定的元素对象</param>
        /// <returns>获得的单词，若不存在则返回空引用</returns>
        public string GetPreWord(ZYTextElement myElement)
        {
            int index = this.GetPreWordIndex(myElement);
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            ZYTextChar myChar = null;
            if (index >= 0)
            {
                //for (int iCount = index; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                for (int iCount = index; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                {
                    //myChar = myElements[iCount] as ZYTextChar; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    myChar = (ZYTextChar)HBFElements[iCount] as ZYTextChar; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 获得指定范围内的元素的文本
        /// </summary>
        /// <param name="intStartIndex">选择区域的开始序号</param>
        /// <param name="intEndIndex">选择区域的结束序号</param>
        /// <returns>选择区域中所有的元素的文本</returns>
        public string GetRangeText(int intStartIndex, int intEndIndex)
        {
            intStartIndex = FixIndex(intStartIndex);
            intEndIndex = FixIndex(intEndIndex);
            System.Text.StringBuilder myStr = new System.Text.StringBuilder();
            for (int iCount = intStartIndex; iCount <= intEndIndex; iCount++)
            {
                //myStr.Append(((ZYTextElement)myElements[iCount]).ToEMRString()); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                myStr.Append(((ZYTextElement)HBFElements[iCount]).ToEMRString()); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            }
            return myStr.ToString();
        }

        /// <summary>
        /// 内部使用的获得同元素列表长度相等的字符串文本
        /// </summary>
        /// <returns></returns>
        internal string GetFixLenText()
        {
            //if (myElements == null) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return null;
            else
            {
                if (bolModified == false && strFixLenText != null)
                    return strFixLenText;
                else
                {
                    //char[] vChar = new char[myElements.Count]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    char[] vChar = new char[HBFElements.Count]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    ZYTextChar myChar = null;
                    //for (int iCount = 0; iCount < myElements.Count; iCount++) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    for (int iCount = 0; iCount < HBFElements.Count; iCount++) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    {
                        //myChar = myElements[iCount] as ZYTextChar; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                        myChar = HBFElements[iCount] as ZYTextChar; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 查找字符串,若找到则设置选择区域为找到的字符串
        /// </summary>
        /// <param name="strText">需要查找的字符串</param>
        /// <returns>是否找到字符串</returns>
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
        /// 替换字符串
        /// </summary>
        /// <param name="strFind">需要查找的字符串</param>
        /// <param name="strReplace">需要替换的字符串</param>
        /// <returns>是否替换了字符串</returns>
        public bool ReplaceText(string strFind, string strReplace, out string msg)
        {
            msg = "";
            if (this.GetSelectText() == strFind)
            {
                //如果要替换的内容在元素中，则不能替换
                bool flag = true;
                foreach (ZYTextElement ele in this.GetSelectElements())
                {
                    if (ele.Parent is ZYTextBlock || ele is ZYElement)
                    {
                        //MessageBox.Show("只能替换纯文本，不能替换元素内部文本。", "警告"); Modified by wwj 2013-04-18
                        msg = "只能替换纯文本，不能替换元素内部文本。";
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
        /// 替换所有的字符串
        /// </summary>
        /// <param name="strFind">查找的字符串</param>
        /// <param name="strReplace">替换的字符串</param>
        /// <returns>替换的次数</returns>
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

        #region 移动当前插入点位置的函数群 ************************************
        /// <summary>
        /// 将插入点向上移动一行,现在没有地方用用到它
        /// </summary>
        public void MoveUpOneLine2()
        {
            //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

            int TargetLineIndex = StartElement.RealLineIndex - 1;
            int OldLeft = StartElement.RealLeft;
            ZYTextElement myElement = null;
            for (int iCount = intSelectStart - 1; iCount >= 0; iCount--)
            {
                //myElement = (ZYTextElement)myElements[iCount]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                myElement = (ZYTextElement)HBFElements[iCount]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
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
        /// 将插入点向上移动一行
        /// </summary>
        public void MoveUpOneLine()
        {
            #region 2019.8.6-hdf：把所有块元素的焦点失去
            List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
            elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
            {
                if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                return ele;
            }).ToList();
            #endregion
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 添加原因：上下左右方向键移动光标时重置IsMoveCaretToLineEnd

            myDocument.OwnerControl.ScrollViewToCaretVisibleUp(this.CurrentLine, this.PreLine); //add by myc 2014-08-08 调用ScrollViewToCaretVisibleUp例程使得按下向上方向键时移动光标并可见


            ZYTextLine myLine = this.PreLine;
            if (myLine != null)
            {
                if (intLastXPos <= 0)
                {
                    //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    intLastXPos = StartElement.RealLeft;
                }
                for (int i = 0; i < myLine.Elements.Count; i++)//foreach (ZYTextElement myElement in myLine.Elements)
                {
                    ZYTextElement myElement = myLine.Elements[i] as ZYTextElement;
                    if (myElement.RealLeft >= intLastXPos)
                    {
                        #region bwy:
                        //如果在元素中//2019.8.16-hdf：块元素加入能插入换行功能，当块元素内有多行是时，光标移动需要能进入块元素
                        if (myElement.Parent is ZYTextBlock && !(myElement.Parent is ZYMacro || myElement.Parent is ZYReplace || myElement.Parent is ZYFormatString || myElement.Parent is ZYDiag || myElement.Parent is ZYSubject))
                        {
                            myElement = (myElement.Parent as ZYTextBlock).FirstElement;
                        }
                        #endregion bwy:
                        this.MoveSelectStart(myElement);
                        //2019.8.16-hdf：光标移动后判断是否在块元素内修改块元素的焦点获取状态
                        if ((this.CurrentElement.Parent is ZYMacro || this.CurrentElement.Parent is ZYReplace || this.CurrentElement.Parent is ZYFormatString || this.CurrentElement.Parent is ZYDiag || myElement.Parent is ZYSubject)
                            && this.CurrentElement != this.CurrentElement.Parent.FirstElement)
                        {
                            (this.CurrentElement.Parent as ZYTextBlock).IsFocus = true;
                        }
                        return;
                    }
                }
                this.MoveSelectStart(myLine.LastElement);
                //2019.8.16-hdf：光标移动后判断是否在块元素内修改块元素的焦点获取状态
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
        /// 将插入点向下移动一行
        /// </summary>
        public void MoveDownOneLine()
        {
            #region 2019.8.6-hdf：把所有块元素的焦点失去
            List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
            elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
            {
                if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                return ele;
            }).ToList();
            #endregion
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 添加原因：上下左右方向键移动光标时重置IsMoveCaretToLineEnd

            ZYTextLine myLine = this.NextLine;
            if (myLine != null)
            {
                myDocument.OwnerControl.ScrollViewToCaretVisibleDown(this.CurrentLine, this.NextLine); //add by myc 2014-08-08 调用ScrollViewToCaretVisibleDown例程使得按下向下方向键时移动光标并可见


                if (intLastXPos <= 0)
                {
                    //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    intLastXPos = StartElement.RealLeft;
                }
                for (int i = 0; i < myLine.Elements.Count; i++)//foreach (ZYTextElement myElement in myLine.Elements)
                {
                    ZYTextElement myElement = myLine.Elements[i] as ZYTextElement;
                    if (myElement.RealLeft >= intLastXPos)
                    {
                        #region bwy:
                        //如果在元素中//2019.8.16-hdf：块元素加入能插入换行功能，当块元素内有多行是时，光标移动需要能进入块元素
                        if (myElement.Parent is ZYTextBlock && !(myElement.Parent is ZYMacro || myElement.Parent is ZYReplace || myElement.Parent is ZYFormatString || myElement.Parent is ZYDiag || myElement.Parent is ZYSubject))
                        {
                            myElement = this.GetNextElement((myElement.Parent as ZYTextBlock).LastElement);
                        }
                        #endregion bwy:
                        this.MoveSelectStart(myElement);
                        //2019.8.16-hdf：光标移动后判断是否在块元素内修改块元素的焦点获取状态
                        if ((this.CurrentElement.Parent is ZYMacro || this.CurrentElement.Parent is ZYReplace || this.CurrentElement.Parent is ZYFormatString || this.CurrentElement.Parent is ZYDiag || this.CurrentElement.Parent is ZYSubject)
                            && this.CurrentElement != this.CurrentElement.Parent.FirstElement)
                        {
                            (this.CurrentElement.Parent as ZYTextBlock).IsFocus = true;
                        }
                        return;
                    }
                }
                this.MoveSelectStart(myLine.LastElement);
                //2019.8.16-hdf：光标移动后判断是否在块元素内修改块元素的焦点获取状态
                if (this.CurrentElement.Parent is ZYMacro || this.CurrentElement.Parent is ZYReplace || this.CurrentElement.Parent is ZYFormatString || this.CurrentElement.Parent is ZYDiag || this.CurrentElement.Parent is ZYSubject)
                {
                    (this.CurrentElement.Parent as ZYTextBlock).IsFocus = true;
                }
            }// MoveDownOneLine
        }

        /// <summary>
        /// 将插入点向左移动一个元素
        /// </summary>
        public void MoveLeft()
        {
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 添加原因：上下左右方向键移动光标时重置IsMoveCaretToLineEnd


            if (this.CurrentLine.Elements.IndexOf(CurrentElement) == 0) //add by myc 2014-08-08 当前光标位于当前文档行最后一个元素之前，则需调用ScrollViewToCaretVisibleUp例程
            {
                myDocument.OwnerControl.ScrollViewToCaretVisibleUp(this.CurrentLine, this.PreLine); //add by myc 2014-08-08 调用ScrollViewToCaretVisibleUp例程使得按下向上方向键时移动光标并可见
            }


            intLastXPos = -1;
            if (intSelectStart > 0)
            {
                //如果移动到了元素内部，则修正
                //ZYTextElement ele = this.Elements[intSelectStart - 1] as ZYTextElement; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                ZYTextElement ele = this.HBFElements[intSelectStart - 1] as ZYTextElement; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要

                //2019.8.6-hdf：宏元素、格式化字符串、复用项目文本录入优化，可左右键使焦点进入块元素进行文本录入
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
                    //intSelectStart = this.Elements.IndexOf((ele.Parent as ZYTextBlock).FirstElement); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    int newSelectStart = this.HBFElements.IndexOf((ele.Parent as ZYTextBlock).FirstElement); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    this.MoveSelectStart(newSelectStart); //2014-08-07 myc 左光标键移动
                }
                else
                {
                    this.MoveSelectStart(intSelectStart - 1);
                }
            }
            else
            {
                //2019.8.6-hdf：把所有块元素的焦点失去
                List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
                elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
                {
                    if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                    return ele;
                }).ToList();
            }

        }

        /// <summary>
        /// 将插入点向右移动一个元素
        /// </summary>
        public void MoveRight()
        {
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 添加原因：上下左右方向键移动光标时重置IsMoveCaretToLineEnd

            if (this.CurrentLine.Elements.IndexOf(CurrentElement) == this.CurrentLine.Elements.Count - 1) //add by myc 2014-08-08 当前光标位于当前文档行最后一个元素之前，则需调用ScrollViewToCaretVisible例程
            {
                myDocument.OwnerControl.ScrollViewToCaretVisibleDown(this.CurrentLine, this.NextLine); //add by myc 2014-08-08 调用ScrollViewToCaretVisibleDown例程使得按下向下方向键时移动光标并可见
            }


            intLastXPos = -1;
            //if (intSelectStart < myElements.Count - 1) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (intSelectStart < HBFElements.Count - 1) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            {
                //如果移动到了元素内部，则修正
                //ZYTextElement ele = this.Elements[intSelectStart - 1] as ZYTextElement; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                ZYTextElement ele = this.HBFElements[intSelectStart] as ZYTextElement; //add by myc 2014-07-16 添加原因：光标定位类Word处理

                //2019.8.6-hdf：宏元素、格式化字符串、复用项目文本录入优化，可左右键使焦点进入块元素进行文本录入
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
                    //intSelectStart = this.Elements.IndexOf((ele.Parent as ZYTextBlock).LastElement); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                    int newSelectStart = this.HBFElements.IndexOf((ele.Parent as ZYTextBlock).LastElement); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                    this.MoveSelectStart(newSelectStart + 1); //2014-08-07 myc 右光标键移动
                }
                else
                {
                    this.MoveSelectStart(intSelectStart + 1);
                }
            }
            else
            {
                //2019.8.6-hdf：把所有块元素的焦点失去
                List<ZYTextElement> elelist = this.Document.GetRealElements(this.Document.HBFElements).Cast<ZYTextElement>().ToList();
                elelist = elelist.Select<ZYTextElement, ZYTextElement>(ele =>
                {
                    if (ele is ZYTextBlock) (ele as ZYTextBlock).IsFocus = false;
                    return ele;
                }).ToList();
            }
        }

        /// <summary>
        /// 将插入点移动到当前行的最后一个元素处
        /// </summary>
        public void MoveEnd()
        {
            try
            {
                IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 添加原因：上下左右方向键移动光标时重置IsMoveCaretToLineEnd

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

                        //this.MoveSelectStart(myElements.IndexOf(ele) + 1); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                        IsMoveCaretToLineEnd = true;
                        this.MoveSelectStart(HBFElements.IndexOf(ele) + 1); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                        //bolLineEndFlag = true; //add by myc 2014-07-16 添加原因：光标定位类Word处理需要

                        ((ZYTextDocument)myDocument).UpdateTextCaret();
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 移动当前插入点到当前行的行首
        /// </summary>
        public void MoveHome()
        {
            IsMoveCaretToLineEnd = false; //add by myc 2014-07-16 添加原因：上下左右方向键移动光标时重置IsMoveCaretToLineEnd

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
                //int FirstIndex = myElements.IndexOf(ele); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                int FirstIndex = HBFElements.IndexOf(ele); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                #endregion bwy:
                // 获得第一个非空白字符元素的序号
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



        #region add by myc 2014-06-09 注释原因：此方法没有对单元格元素作处理，不完善，而且影响到光标在表格内的正确移动
        ///// <summary>
        ///// 获得指定位置处的元素
        ///// 2009-7-2 22:00 mfb重新实现. 参照了MoveTo(x,y)
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
        /// 检测当前的插入点位置是否正确
        /// </summary>
        /// <returns></returns>
        private bool CheckSelectStart()
        {
            //if (myElements == null) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return false;
            else
                //return (intSelectStart >= 0 && intSelectStart <= myElements.Count - 1); //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                return (intSelectStart >= 0 && intSelectStart <= HBFElements.Count - 1); //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
        }



        /// <summary>
        /// 移动当前插入点
        /// </summary>
        /// <param name="iStep">纵向的移动距离</param>
        public void MoveStep(int iStep)
        {
            //ZYTextElement StartElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement StartElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            //this.MoveTo(StartElement.RealLeft, StartElement.RealTop + iStep); //注释 add by myc 2014-07-30
            this.MoveToNoSelectingArea(StartElement.RealLeft, StartElement.RealTop + iStep); //添加 add by myc 2014-07-30 新光标定位
        }


        #endregion

        /// <summary>
        /// 初始化对象
        /// </summary>
        public ZYContent()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 判断是否可以删除选中元素,如果选中多个单元格的内容则不允许删除 Add By wwj 2012-04-24
        /// </summary>
        /// <returns></returns>
        public bool CanDeleteSelectElement()
        {
            //表示是否有元素在单元格的外部
            bool isHasElementOutCell = false;

            System.Collections.ArrayList myList = this.GetSelectElements();
            List<ZYTextElement> cellList = new List<ZYTextElement>();
            foreach (ZYTextElement ele in myList)
            {
                ZYTextElement textElement = this.GetParentByElement(ele, ZYTextConst.c_Cell);
                if (textElement != null)
                {
                    //既有在单元格内的，又有在单元格外的，则不允许删除元素
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
                    isHasElementOutCell = true;//表示此元素在单元格的外部

                    //当即选中表格外的元素，又选择了表格中的元素则不允许删除操作
                    if (cellList.Count > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 得到编辑器中第一个表格 Add by wwj 2012-05-29
        /// </summary>
        /// <returns></returns>
        public TPTextTable GetFirstTable()
        {
            //ArrayList list = myElements; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要 
            ArrayList list = HBFElements; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            for (int i = 0; i < list.Count; i++)
            {
                //ZYTextElement myElement = (ZYTextElement)myElements[i]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
                ZYTextElement myElement = (ZYTextElement)HBFElements[i]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                ZYTextElement table = GetParentByElement(myElement, ZYTextConst.c_Table);
                if (table != null && table is TPTextTable)
                {
                    return ((TPTextTable)table).Clone();
                }
            }
            return null;
        }

        /// <summary>
        /// 设置单元格是否可以换行 Add By wwj 2012-06-06
        /// </summary>
        public void SetTableCellCanInsertEnter(bool canEnter)
        {
            //if (myElements == null || myElements.Count == 0) //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            if (HBFElements == null || HBFElements.Count == 0) //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
                return;
            if (this.IsLock(intSelectStart))
                return;

            //获得当前元素
            //ZYTextElement myElement = (ZYTextElement)myElements[intSelectStart]; //add by myc 2014-07-04 注释原因：新版页眉二期改版需要
            ZYTextElement myElement = (ZYTextElement)HBFElements[intSelectStart]; //add by myc 2014-07-04 添加原因：新版页眉二期改版需要
            //获得当前表格
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






        #region add by myc 2014-07-03 添加原因：新版页眉二期改版之光标定位
        /// <summary>
        /// 标识光标是否移动至文本字符末尾。
        /// </summary>
        public static bool IsMoveCaretToLineEnd = false;
        #endregion




        #region 新版页眉页脚和正文统一管理例程 add by myc 2014-07-22
        #region 光标定位——>最终修订于2014-08-05
        /// <summary>
        /// 返回当前文档编辑区内的所有文本类型元素。
        /// </summary>
        public ArrayList HBFElements
        {
            get
            {
                return this.Document.HBFElements;
            }
        }

        /// <summary>
        /// 修正intSelectStart值以保证其在可见元素列表的索引范围内。
        /// </summary>
        /// <param name="index">原始的序号。</param>
        /// <returns>修正后的序号。</returns>
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
        /// 检查并校正选定区域内的intSelectStart和intSelectLength，以保证其在可见元素列表的索引范围内。
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
        /// 获取文档视图区内指定点位置处的文档元素对象。
        /// </summary>
        /// <param name="x">指定点的X坐标。</param>
        /// <param name="y">指定点的Y坐标。</param>
        /// <returns></returns>
        public ZYTextElement GetElementAt(int x, int y)
        {
            try
            {
                if (myDocument == null || myDocument.HBFLines == null || myDocument.HBFLines.Count == 0) return null;

                #region 先找到包含当前指定点的文档行对象
                //指导思想——>根据文档重新分行的递归算法，易知单元格内的文档行对象一定排在表格行内的文档行对象之前
                //同时，也易知拆分单元格内部的嵌套表格行内的文档行对象一定是排在拆分单元格本身所在表格行内的文档行对象之前
                //另外，表格行的高度是以它内部所有单元格的最小高度值作为基准，故对于合并单元格中的文档行对象也需单独处理

                ZYTextLine findLine = null;
                for (int i = 0; i < myDocument.HBFLines.Count; i++)
                {
                    ZYTextLine myLine = myDocument.HBFLines[i] as ZYTextLine;
                    if (myLine.Container is ZYTextParagraph)
                    {
                        ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                        if (para.Parent is TPTextCell) //当前文档行对象所属父级容器为单元格
                        {
                            #region 单元格内的段落
                            TPTextRow row = (para.Parent as TPTextCell).OwnerRow;
                            Rectangle rect1 = row.OwnerTable.GetContentBounds();
                            foreach (TPTextCell cell in row)
                            {
                                if (cell.ChildCount == 0) continue; //占位单元格
                                if (cell.ChildCount > 0
                                    && cell.ChildElements[0] is TPTextRow) continue; //拆分单元格

                                Rectangle rect = cell.GetContentBounds(); //当前单元格的外切矩形

                                int vHeight = 0;
                                if (rect.Bottom == rect1.Bottom)
                                {
                                    vHeight = myDocument.Info.LineSpacing; //2014-08-05 上下两页之内的文档行需要特殊边界判断（上一页之内的反色绘制不能跨越到下一页第一个文档行）
                                }

                                //if (y >= rect.Top //由单元格顶端往下区域——>如果鼠标移动至上一个文档行底端与这个单元格顶端之间，则这么判断会出现异常
                                if (y >= rect.Top - myDocument.Info.LineSpacing //2014-07-30 由上一个文档行底端至单元格底端区域
                                    //&& y <= rect.Top + rect.Height)
                                    && y <= rect.Top + rect.Height + vHeight) //2014-08-05 上下两页之内的文档行需要特殊边界判断（上一页之内的反色绘制不能跨越到下一页第一个文档行）
                                {
                                    //if (x >= rect.Left &&
                                    //        x <= rect.Left + rect.Width)
                                    //{
                                    //    findLine = MoveCaretInCell(cell, x, y);
                                    //    break;
                                    //} //——>这种方式判断对于表格左端右端与文档视图区存在间距时无效

                                    #region add by myc 2014-08-01 添加原因：处理表格边界与视图区存在间距时的光标定位与拖选单元格
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
                            if (findLine != null) break; //这个非常关键，找到单元格内的文本行对象之后必须退出循环
                            #endregion
                        }
                        else //当前文档行对象所属父级容器不为单元格
                        {
                            #region 文档内基本段落
                            if (i == 0) //第一个文档行对象
                            {
                                //if (y <= myLine.RealTop + myLine.Height) //由文档行底端往上区域
                                if (y <= myLine.RealTop + myLine.FullHeight) //2014-08-07 由文档行顶端往下至底端区域
                                {
                                    findLine = myLine;
                                    break;
                                }

                                if (myDocument.HBFLines.Count == 1) //只有一个文档行对象时的特殊处理
                                {
                                    if (y >= myLine.RealTop) //由文档行顶端往下区域
                                    {
                                        findLine = myLine;
                                        break;
                                    }
                                }
                            }
                            else if (i == myDocument.HBFLines.Count - 1) //最后一个文档行对象
                            {
                                //if (y >= myLine.RealTop) //由文档行顶端往下区域——>如果鼠标移动至上一个文档行底端与这个文档行顶端之间，则这么判断会出现异常
                                if (y >= myLine.RealTop - myDocument.Info.LineSpacing) //2014-07-30 由上一个文档行底端往下区域
                                {
                                    findLine = myLine;
                                    break;
                                }
                            }
                            //else if (y >= myLine.RealTop - myDocument.Info.LineSpacing
                            //    && y <= myLine.RealTop + myLine.Height) //中间的文档行对象（参照Word处理由文档行底端往上至上一文档行对象底端区域）——2014-08-04 上下两页之内的文档行需要特殊边界判断(后期处理)
                            else if (y >= myLine.RealTop
                                && y <= myLine.RealTop + myLine.FullHeight) //中间的文档行对象（参照Word处理由文档行顶端往下至上一文档行对象顶端区域）——2014-08-05 上下两页之内的文档行需要特殊边界判断（上一页之内的反色绘制不能跨越到下一页第一个文档行）
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

                #region 再找到最靠近当前指定点的文档元素
                ZYTextElement findElement = null;
                x -= findLine.RealLeft; //将X坐标换算成相对于findLine左端的X坐标——>因为后面的位置比较采用相对于findLine左端（作为X=0）的位置
                if (findLine.Elements.Count == 0)
                {
                    findElement = findLine.Container;
                    return findElement; //2014-08-21 解决出现空值异常
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
                        && x < myElement.Left + myElement.Width / 2) //X坐标位于myElement前一半区域内
                    {
                        findElement = myElement;
                        break;
                    }
                    else if (x >= myElement.Left + myElement.Width / 2
                        && x <= myElement.Left + myElement.Width + myElement.WidthFix) //X坐标位于myElement后一半区域内——>2014-07-29 注意必须加上WidthFix（用于分散对齐）
                    {
                        //2014-07-30 这种方式下如果所在单元格仅有一个回车符，则会跳跃到下一个单元格内（不合理）
                        //if (HBFElements.IndexOf(myElement) < HBFElements.Count - 1)
                        //{
                        //    findElement = HBFElements[HBFElements.IndexOf(myElement) + 1] as ZYTextElement;
                        //    break;
                        //}
                        if (findLine.Elements.IndexOf(myElement) < findLine.Elements.Count - 1)
                        {
                            if (myElement is ZYTextDocumentLib.ZYTextImage) //2014-07-25 这里特别关键——>处理图片右键编辑和保存功能
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
                            findElement = myElement; //2014-07-30 鼠标选定文档元素时会在MoveToInSelectingArea中重新调整传递的索引号
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
        /// 获取文档视图区内指定点位置处的单元格内部文档行对象。
        /// </summary>
        /// <param name="cell">包含指定点的单元格。</param>
        /// <param name="x">指定点的X坐标。</param>
        /// <param name="y">指定点的Y坐标。</param>
        /// <returns></returns>
        private ZYTextLine MoveCaretInCell(TPTextCell cell, int x, int y)
        {
            try
            {
                Rectangle rect = cell.GetContentBounds(); //当前单元格的外切矩形
                ZYTextLine firstLine = cell.Lines[0] as ZYTextLine; //当前单元格内第一个文本行对象，即第一个段落元素
                ZYTextLine lastLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine; //当前单元格内最后一个文本行对象，即最后一个段落元素

                ZYTextLine findLine = null;
                if (y >= rect.Top
                    && y < firstLine.RealTop) //单元格的上空白处——>单元格顶端与内部第一个文本行对象之间的空白区域（上侧内边距）
                {
                    findLine = cell.Lines[0] as ZYTextLine; //单元格第内部第一个文本行对象
                }
                else if (y > lastLine.RealTop + lastLine.Height
                    && y <= rect.Bottom) //单元格的下空白处——>不一定是下侧内边距，准确地说是单元格底端与内部最后一个文本行对象之间的空白区域
                {
                    findLine = cell.Lines[cell.Lines.Count - 1] as ZYTextLine; //单元格第内部最后一个文本行对象
                }
                else //单元格的内部段落区域
                {
                    foreach (ZYTextLine paraLine in cell.Lines) //单元格的Lines存储段落内部元素
                    {
                        if (y < paraLine.RealTop) //Y坐标位于当前遍历文本行对象的顶端与上一个遍历文本行对象之间的空白区域（段落与段落之间存在行间距）
                        {
                            findLine = paraLine;
                            break;
                        }
                        else if (y >= paraLine.RealTop
                            && y <= paraLine.RealTop + paraLine.Height) //Y坐标位于当前遍历文本行对象的内部区域
                        {
                            findLine = paraLine;
                            break;
                        }
                    }
                }

                if (findLine == null) //最后处理——>如果在此单元格内还没有找到所需文本行对象，则置findLine为此单元格内第一个文本行对象
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
        /// 将当前光标（插入符）移动到文档视图区内的指定点位置（鼠标按下事件调用）。
        /// </summary>
        /// <param name="x">指定点的X坐标。</param>
        /// <param name="y">指定点的Y坐标。</param>
        public void MoveToNoSelectingArea(int x, int y)
        {
            try
            {
                if (myDocument == null) return;
                ZYTextElement findElement = GetElementAt(x, y);

                if (findElement == null) return; //2014-08-21 如果findElement为null，则直接返回避免出现异常

                int index = HBFElements.IndexOf(findElement);
                this.MoveSelectStart(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将当前光标（插入符）移动到文档视图区内的指定点位置（鼠标移动事件调用，并且只针对选定文档元素）。
        /// </summary>
        /// <param name="x">指定点的X坐标。</param>
        /// <param name="y">指定点的Y坐标。</param>
        public void MoveToInSelectingArea(int x, int y)
        {
            try
            {
                if (myDocument == null) return;
                ZYTextElement findElement = GetElementAt(x, y);

                if (findElement == null) return; //2014-08-21 如果findElement为null，则直接返回避免出现异常

                int index = HBFElements.IndexOf(findElement);

                ZYTextLine findLine = findElement.OwnerLine;
                x -= findLine.RealLeft; //将X坐标换算成相对于findLine左端的X坐标
                if (x > findElement.Left + findElement.Width / 2
                    && findLine.Elements.IndexOf(findElement) == findLine.Elements.Count - 1) //X坐标位于findElement后一半区域并且是findLine内最后一个文档元素
                {
                    index += 1; //光标移动到回车符后面的元素（注意文档最后一个回车符要发生越界，需在后续操作中予以越界判断）
                }

                this.MoveSelectStart(index);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将当前光标（插入符）移动到文档视图区内的指定文档元素前面。
        /// </summary>
        /// <param name="refElement">指定的文档元素。</param>
        /// <returns>操作是否成功。</returns>
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
        /// 将当前光标（插入符）移动到文档视图区内的指定索引号的文档元素前面。
        /// </summary>
        /// <param name="index">指定的文档元素索引号。</param>
        /// <returns>操作是否成功。</returns>
        public bool MoveSelectStart(int index)
        {
            try
            {
                if (index != HBFElements.Count) //如果index == HBFElements.Count，则表示选中文档最后一个回车符，此时先跳过越界检查——>考虑到文档仅有一个回车符被选中情况
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
        /// 设置新选定区域的开始位置和选定长度。
        /// </summary>
        /// <param name="NewSelectStart">新选定区域的开始位置——>文档可见元素列表中的索引号。</param>
        /// <param name="NewSelectLength">新选定区域的选择长度。</param>
        /// <returns>操作是否成功。</returns>
        public bool SetSelection(int NewSelectStart, int NewSelectLength)
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return false;

                if (NewSelectStart != HBFElements.Count) //选定文档最后一个回车符时，跳过越界检查
                {
                    NewSelectStart = FixIndex(NewSelectStart);
                }

                //若选定区域未发生改变，则不执行后续代码段
                if (intSelectStart == NewSelectStart && intSelectLength == NewSelectLength) return true;

                #region 特殊处理
                //以下这段代码为处理用户只选中文档最后一个回车符又回到不选中时的特殊情况
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

                int OldSelectStart = intSelectStart; //光标（插入符）所在的旧位置

                #region 非鼠标选定元素操作
                //如果没有选定若干个元素，或者说未发生鼠标按下并移动的拖选文本元素操作
                //此时表示鼠标移动到某一元素，点击了一下
                if (intSelectLength == 0 && NewSelectLength == 0)
                {
                    intSelectStart = NewSelectStart; //更新光标插入符到新的位置，NewSelectStart已由FixIndex检查过索引位置是否越界

                    if (myDocument != null)
                    {
                        myDocument.SelectionChanged(OldSelectStart, 0, intSelectStart, 0);
                    }

                    if (OldSelectStart >= 0 && OldSelectStart < HBFElements.Count) //必须加索引越界检查
                    {
                        ((ZYTextElement)HBFElements[OldSelectStart]).HandleLeave(); //触发旧元素离开事件
                    }
                    if (intSelectStart >= 0 && intSelectStart < HBFElements.Count) //必须加索引越界检查
                    {
                        ((ZYTextElement)HBFElements[intSelectStart]).HandleEnter(); //触发新元素进入事件
                    }

                    return true;
                }
                #endregion

                #region 鼠标选定元素操作
                int SourceStart = 0; //原选定区域的开始位置
                int SourceEnd = 0; //原始选定区域的结束位置
                int DescStart = 0; //新选定区域的开始位置
                int DescEnd = 0; //新选定区域的结束位置

                //设置旧选定区域的开始与结束位置
                if (intSelectLength > 0) //反向选定
                {
                    SourceStart = intSelectStart;
                    SourceEnd = intSelectStart + intSelectLength;
                }
                else //正向选定
                {
                    SourceStart = intSelectStart + intSelectLength;
                    SourceEnd = intSelectStart;
                }

                //设置新选定区域的开始与结束位置
                if (NewSelectLength > 0) //反向选定
                {
                    DescStart = NewSelectStart;
                    DescEnd = NewSelectStart + NewSelectLength;
                }
                else //正向选定
                {
                    DescStart = NewSelectStart + NewSelectLength;
                    DescEnd = NewSelectStart;
                }

                //交换位置
                int temp = 0;
                if (SourceStart > DescStart) //使得旧选定区域的开始位置位于新选定区域的开始位置左侧（因为索引位置从小到大排列）
                {
                    temp = SourceStart;
                    SourceStart = DescStart;
                    DescStart = temp;
                }
                if (SourceEnd > DescEnd) //使得旧选定区域的结束位置位于新选定区域的结束位置左侧（因为索引位置从小到大排列）
                {
                    temp = SourceEnd;
                    SourceEnd = DescEnd;
                    DescEnd = temp;
                }
                //备注：[SourceStart->DescStart] 和 [DescStart->DescEnd] 为文档中选中状态发生改变的元素的序号范围

                intSelectStart = NewSelectStart; //保存新的插入符起始位置
                intSelectLength = NewSelectLength; //保存新的鼠标选定长度

                if (NewSelectStart != HBFElements.Count) //选定文档最后一个回车符时，跳过越界检查
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

                if (OldSelectStart >= 0 && OldSelectStart < HBFElements.Count) //必须加索引越界检查
                {
                    ((ZYTextElement)HBFElements[OldSelectStart]).HandleLeave(); //触发旧元素离开事件
                }
                if (intSelectStart >= 0 && intSelectStart < HBFElements.Count) //必须加索引越界检查
                {
                    ((ZYTextElement)HBFElements[intSelectStart]).HandleEnter(); //触发新元素进入事件
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

        #region 反色绘制——>最终修订于2014-08-06
        /// <summary>
        /// 判断指定的文档元素是否被选中。
        /// </summary>
        /// <param name="myElement">指定的文档元素。</param>
        /// <returns>是否被选中。</returns>
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
        /// 标识当前鼠标拖选文档元素操作是否仅在同一个表格内。
        /// </summary>
        private bool selectingAreaInOneTable = false;
        /// <summary>
        /// 返回一个布尔值，标识当前鼠标拖选文档元素操作是否仅在同一个表格内。
        /// </summary>
        public bool SelectingAreaInOneTable
        {
            get { return selectingAreaInOneTable; }
        }

        /// <summary>
        /// 设置表示鼠标拖选文档元素操作是否仅在同一个表格内的布尔标志字段（ZYContent类中的selectingAreaInOneTable，并由ZYEditorControl类的OnViewPaint方法调用）。
        /// </summary>
        public void CheckSelectingAreaInOneTable()
        {
            try
            {
                ArrayList currSelectParas = GetSelectParagraph(); //选中区域段落集合
                if (currSelectParas.Count <= 0) //判断选中区域段落集合是否为空
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                if (myDocument.SelectedCells.Count == 0) //2014-08-06 从一个回车符反向拖选至表格最后一个单元格时的正确判定，因为只有鼠标点击了单元格之后再拖选单元格才会有myDocument.SelectedCells个数不为0
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                ZYTextParagraph firstPara = currSelectParas[0] as ZYTextParagraph; //选中区域第一个段落
                ZYTextParagraph lastPara = currSelectParas[currSelectParas.Count - 1] as ZYTextParagraph; //选中区域最后一个段落

                //如果第一个段落不在单元格中，则肯定不是同一个表格内的拖选单元格操作
                if (!(firstPara.Parent is TPTextCell))
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                //如果第一个段落在单元格中，而最后一个段落不在单元格中，则肯定不是同一个表格内的拖选单元格操作
                if (!(lastPara.Parent is TPTextCell))
                {
                    selectingAreaInOneTable = false;
                    return;
                }

                TPTextCell firstCell = firstPara.Parent as TPTextCell; //选中区域第一个单元格
                TPTextCell lastCell = lastPara.Parent as TPTextCell; //选中区域最后一个单元格
                //如果第一个单元格和最后一个单元格都处于同一个表格内，则返回true表示是同一个表格内的拖选单元格操作
                if (firstCell.OwnerRow.OwnerTable.GetContentBounds() == lastCell.OwnerRow.OwnerTable.GetContentBounds())
                {
                    selectingAreaInOneTable = true; //add by myc 2014-07-30 反色高亮绘制需要
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
        /// 鼠标拖选文档元素操作时，对选定的文档元素的外切矩形区域进行反色（高亮绘制）处理。
        /// </summary>
        /// <param name="myLine">指定的文档行对象。</param>
        /// <param name="HeightLightRect">视图区坐标表示的待反色处理矩形区域。</param>
        public void HighlightSelectingArea(ZYTextLine myLine, Rectangle heightLightRect)
        {
            try
            {
                if (myLine.Container is ZYTextParagraph) //当前文档行对象所属父级容器为段落
                {
                    Rectangle rect = Rectangle.Empty; //保存需反色处理矩形区域
                    ZYTextParagraph para = myLine.Container as ZYTextParagraph;
                    if (para.Parent is TPTextCell) //当前段落位于单元格内
                    {
                        /*
                         2021-04-01
                        合并单元格跨页时，选中区域需要进行反色绘制，当单元格跨页时，上一页绘制了，下一页在绘制一次，就会导致无效果
                        第一版解决方案：使用字段判断进行拦截一次绘制，问题：当文字存在跨页切割显示时，无法切割绘制反色区域
                        第二版解决方案：跨页多次绘制，每页只绘制当前页切割的反色区域
                         */
                        Rectangle pagerect = myDocument.Pages[myDocument.PageIndex].Bounds;
                        if (pagerect.IntersectsWith(heightLightRect))
                            heightLightRect.Intersect(pagerect);



                        TPTextCell cell = para.Parent as TPTextCell;
                        if (selectingAreaInOneTable) //同一个表格内的鼠标拖选操作
                        {
                            //if (cell.CanAccess && myDocument.SelectedCells.Count == 1) //当前鼠标点击的单元格，并且未被选中——>处理仅一个单元格内部的选定文档元素操作
                            //{
                            //    if (heightLightRect.Width > 0)
                            //    {
                            //        rect = myDocument.GetReversibleRect(heightLightRect);
                            //        //cell.Selected = false;
                            //    }
                            //}


                            //备注：
                            //if (cell.Selected && myDocument.SelectedCells.Count > 1) //已被选中的若干个单元格
                            //{
                            //    //单元格已被选中，交由单元格的RefreshView方法完成反色处理
                            //}
                        }
                        else //非同一个表格内的鼠标拖选操作根据实际的heightLightRect判定是否至单元格为选中状态
                        {
                            //if (heightLightRect.Width > 0)
                            //{
                            //    cell.Selected = true; //置单元格被选中，交由单元格的RefreshView方法完成反色处理
                            //}

                            //if (cell.CanAccess && myDocument.SelectedCells.Count == 0) //新版反色绘制修正2014-08-06 当前鼠标点击的单元格，并且未被选中——>处理仅一个单元格内部的选定文档元素操作
                            //2014-10-29 myc 加入合并表格最后两个单元个之后界面绘制高亮度背景界限校验
                            if ((myDocument.Content.SelectLength < 0
                                ? (myDocument.Content.SelectStart + myDocument.Content.SelectLength < myDocument.Content.HBFElements.Count
                                   && myDocument.GetOwnerCell(HBFElements[myDocument.Content.SelectStart + myDocument.Content.SelectLength] as ZYTextElement) != null)
                                : (myDocument.Content.SelectStart + myDocument.Content.SelectLength < myDocument.Content.HBFElements.Count
                                   && myDocument.GetOwnerCell(HBFElements[myDocument.Content.SelectStart + myDocument.Content.SelectLength] as ZYTextElement) != null)
                                )
                                && myDocument.SelectedCells.Count == 0) //2014-08-08 新单元格内选定文本判定方式
                            {
                                if (heightLightRect.Width > 0)
                                {
                                    rect = myDocument.GetReversibleRect(heightLightRect);
                                    //cell.Selected = false;
                                }
                            }
                            else //交叉选定文档元素时的单元格反色处理
                            {
                                if (heightLightRect.Width > 0)
                                {
                                    cell.Selected = true; //置单元格被选中，交由单元格的RefreshView方法完成反色处理
                                }
                            }
                        }
                    }
                    else //当前段落不位于单元格内
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

        #region 删除元素——>最终修订于2014-08-07
        /// <summary>
        /// 获得当前光标所在位置处的文档元素。
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
        /// 判断文档视图区域内是否存在被选择的文档元素对象。
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
        /// 检查指定元素的索引是否允许被修改。
        /// </summary>
        /// <param name="index">指定索引。</param>
        /// <returns>是否被锁定。</returns>
        public bool IsLock(int index)
        {
            try
            {
                if (index >= 0)
                {
                    if (index == HBFElements.Count) //修正检查索引——>鼠标选定文档最后一个元素时
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
                    //固定文本不可删
                    if (HBFElements[index] is ZYFixedText || HBFElements[index] is ZYText) return true;

                    //2019.10.01-hdf：选择元素设置了不允许删除后，只允许双击录入
                    ZYTextElement rele = HBFElements[index] as ZYTextElement;
                    ZYTextElement lele = new ZYTextElement();
                    if (index > 0) lele = HBFElements[index - 1] as ZYTextElement;

                    if (rele.Parent == lele.Parent
                        && (rele.Parent is ZYSelectableElement || rele.Parent is ZYFormatNumber || rele.Parent is ZYFormatDatetime || rele.Parent is ZYPromptText))
                    {
                        //YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("该元素设置不允许删除只能双击录入！");
                        return true;
                    }
                    else if (rele.Parent == lele.Parent && rele.Parent is ZYFixedText)
                    {
                        //YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("标签元素无法编辑！");
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
        /// 当前选定区域的绝对开始位置。
        /// </summary>
        public int AbsSelectStart
        {
            get
            {
                if (intSelectLength >= 0) //鼠标反向选择文档元素
                {
                    return intSelectStart;
                }
                else //鼠标正向选择文档元素
                {
                    return intSelectStart + intSelectLength;
                }
            }
        }

        /// <summary>
        /// 当前选定区域的绝对结束位置。
        /// </summary>
        public int AbsSelectEnd
        {
            get
            {
                int intValue;
                if (intSelectLength >= 0) //鼠标反向选择文档元素
                {
                    intValue = intSelectStart + intSelectLength;
                }
                else  //鼠标正向选择文档元素
                {
                    intValue = intSelectStart;
                }
                return intValue;
            }
        }

        /// <summary>
        /// 获取当前鼠标选定区域内的所有文本类型元素（包括回车符）。
        /// </summary>
        /// <returns>返回包含所有选定文档元素的列表。</returns>
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
        /// 获得所有选择区域的段落元素。
        /// </summary>
        /// <returns>返回包含所有选定文档段落元素的列表，若操作失败则返回空引用。</returns>
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
                    if (currElement.Parent is ZYTextBlock) //文本块容器内部的文本字符元素需特殊处理
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
        /// 根据指定的段落集合，提取出位于不同表格内的段落所属单元格集合，并添加至一个字典中保存——>由删除选定区域内文档元素例程调用。
        /// </summary>
        /// <param name="selectedParas">指定的选中段落集合。</param>
        /// <returns></returns>
        private Dictionary<TPTextTable, List<TPTextCell>> GetSelectedElementsInTable(ArrayList selectedParas)
        {
            try
            {
                List<TPTextCell> DeleteElementsInCells = new List<TPTextCell>(); //存储同一个表格内的段落所属单元格
                Dictionary<TPTextTable, List<TPTextCell>> DeleteElementsInTables = new Dictionary<TPTextTable, List<TPTextCell>>();
                if (selectedParas == null) //没有指定选中的段落集合表示是同一个表格内的鼠标拖选若干个单元格操作
                {
                    foreach (TPTextCell cell in myDocument.SelectedCells)
                    {
                        if (cell.ChildCount == 0) continue; //跳过占位单元格
                        DeleteElementsInCells.Add(cell);
                    }
                    DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                    return DeleteElementsInTables;
                }

                //以下为处理交叉选定文档元素时的DeleteElementsInTables构建代码段
                foreach (ZYTextParagraph para in selectedParas)
                {
                    if (para.Parent is TPTextCell) //当前段落位于单元格内
                    {
                        TPTextCell cell = para.Parent as TPTextCell;
                        if (DeleteElementsInCells.Contains(cell)) //已经包含待删除的单元格对象
                        {
                            if (selectedParas.IndexOf(para) == selectedParas.Count - 1) //必须检查是否为选定区域内最后一个段落元素
                            {
                                DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                DeleteElementsInCells = new List<TPTextCell>();
                            }
                        }
                        else //不包含待删除的单元格对象
                        {
                            if (DeleteElementsInCells.Count == 0)
                            {
                                DeleteElementsInCells.Add(cell);
                                if (selectedParas.IndexOf(para) == selectedParas.Count - 1) //必须检查是否为选定区域内最后一个段落元素
                                {
                                    DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                    DeleteElementsInCells = new List<TPTextCell>();
                                }
                            }
                            else
                            {
                                if (DeleteElementsInCells[DeleteElementsInCells.Count - 1].OwnerRow.OwnerTable.GetContentBounds()
                                    == cell.OwnerRow.OwnerTable.GetContentBounds()) //当前单元格与DeleteElementsInCells中已存储的单元格位于同一个表格内
                                {
                                    DeleteElementsInCells.Add(cell);
                                    if (selectedParas.IndexOf(para) == selectedParas.Count - 1) //必须检查是否为选定区域内最后一个段落元素
                                    {
                                        DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                        DeleteElementsInCells = new List<TPTextCell>();
                                    }
                                }
                                else //当前单元格与DeleteElementsInCells中已存储的单元格不位于同一个表格内
                                {
                                    DeleteElementsInTables.Add(DeleteElementsInCells[0].OwnerRow.OwnerTable, DeleteElementsInCells);
                                    DeleteElementsInCells = new List<TPTextCell>();
                                    DeleteElementsInCells.Add(cell);
                                }
                            }
                        }
                    }
                    else //当前段落不位于单元格内
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

        public string UsId = null;//签名图片对应的用户id
        /// <summary>
        /// 删除当前位于鼠标选定区域内的所有文档元素，并且此例程已经处理好非表格内文档元素与若干个表格内文档元素交叉时的删除元素以及撤销重做栈操作。
        /// </summary>
        /// <returns>是否删除成功。</returns>
        public bool DeleteSelectedElements()
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return false; //如果元素列表为空，则直接返回false
                if (IsLock(intSelectStart)) return false; //如果锁定当前插入点位置，则直接返回false
                int OldSelectStart = this.AbsSelectStart; //先保存当前光标位置，删除操作结束后将据此还原
                if ((HBFElements[AbsSelectStart] as ZYTextElement).Parent is ZYTextBlock) //2014-08-07 文本块元素修正选定区域绝对开始索引位置
                {
                    OldSelectStart = (HBFElements[AbsSelectStart] as ZYTextElement).Parent.FirstElement.Index;
                }


                //if ((!selectingAreaInOneTable && myDocument.GetOwnerCell(HBFElements[AbsSelectStart] as ZYTextElement) == null) //2014-08-07 加上GetOwnerCell判断非常关键
                //    || (selectingAreaInOneTable && myDocument.SelectedCells.Count > 1))
                if (myDocument.SelectedCells.Count == 0
                    && myDocument.GetOwnerCell(HBFElements[intSelectStart + intSelectLength] as ZYTextElement) != null) //2014-08-13 调整原判断方式，校正交叉删除操作的准确性
                {
                    //选定元素所处位置具体说明——>
                    // 1）选定元素位于同一个表格内并且只有一个单元格被点击（此时selectingAreaInOneTable = true && myDocument.SelectedCells.Count == 0）

                    //当前被选中的文本类型元素（包括回车符）
                    ArrayList selectedChars = this.GetSelectElements();
                    //当前选定区域内的段落集合
                    ArrayList selectedParas = this.GetSelectParagraph();
                    //基于文本字符的删除列表——存储待删除的字符
                    ArrayList deleteList = new ArrayList();
                    //基于元素的删除真正列表——存储待删除的元素
                    ArrayList deleteRealList = new ArrayList();

                    #region 判断是否执行真正删除操作
                    int intDelete = 0;
                    deleteRealList = myDocument.GetRealElements(selectedChars);
                    foreach (ZYTextElement ele in deleteRealList)
                    {
                        intDelete = myDocument.isDeleteElement(ele);
                    }
                    if (intDelete != 0) return false; //不能执行真正删除操作则直接返回false
                    if (!this.Document.DeleteFlag) //判断是否能删除固定文本
                    {
                        //if (this.Document.Info.DocumentModel != DocumentModel.Design) //当前文档对象不处于设计状态
                        //{
                        foreach (ZYTextElement ele in selectedChars)
                        {
                            bool candelete = CanDeleteElement(ele);
                            if (!candelete) return false;  //如果不能删除则返回
                            ////处理固定文本
                            //if (ele.Parent is ZYFixedText || ele.Parent is ZYText)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                            //    return false;
                            //}
                            ////处理按钮
                            //if (ele is ZYButton && !((ZYButton)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                            //    return false;
                            //}
                            ////处理定位符
                            //if (ele is ZYFlag && !((ZYFlag)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                            //    return false;
                            //}
                        }
                        //}
                    }
                    #endregion

                    #region 删除当前单元格内选定元素
                    //当前段落位于一个单元格内——>这里需注意单元格内必须留下一个回车符提供给用户输入
                    for (int i = 0; i < selectedParas.Count; i++) //迭代器不允许边操作边修改，所以采用for循环方式遍历
                    {
                        ZYTextParagraph para = selectedParas[i] as ZYTextParagraph;

                        //提取当前段落中的所有文本字符，并依此构建待删除的真正元素列表
                        deleteList.Clear();
                        int paraStartIndex = para.FirstElement.Index; //段落第一个元素的索引序号
                        if (para.FirstElement is ZYTextBlock)
                        {
                            paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                        }
                        int paraEndIndex = para.LastElement.Index; //段落最后一个元素（回车符）的索引序号
                        ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);
                        foreach (ZYTextElement ele in paraChars)
                        {
                            if (selectedChars.Contains(ele))
                            {
                                deleteList.Add(ele);
                            }
                        }
                        deleteRealList = myDocument.GetRealElements(deleteList);

                        //如果为图片，删除数据库中图片记录
                        //foreach (var item in deleteRealList)
                        //{
                        //    if (item is ZYTextDocumentLib.ZYTextImage)
                        //    {
                        //        string imageId = (item as ZYTextDocumentLib.ZYTextImage).CurrentImageID;
                        //        string _sql = string.Format("delete from RecordImage where id = '{0}'", imageId);
                        //        int nonQueryCount = YiDanSqlHelper.YD_SqlHelper.ExecuteNonQuery(_sql);
                        //    }
                        //}

                        #region 2019.7.31-hdf：宏元素、格式化字符串、复用项目需要在文书录入是能修改文本
                        if (selectedParas.Count == 1 && deleteRealList.Count == 1 && (deleteRealList[0] is ZYMacro || deleteRealList[0] is ZYFormatString || deleteRealList[0] is ZYReplace || deleteRealList[0] is ZYDiag || deleteRealList[0] is ZYSubject))
                        {
                            //当选中区域为块元素中，并且是宏元素、格式化字符串、复用项目，则删除文本，不删除块元素，光标位置修正。
                            OldSelectStart = this.AbsSelectStart;
                            //判断当前选中是否为块元素全部文本
                            if ((deleteRealList[0] as ZYTextBlock).ChildCount == deleteList.Count)
                            {
                                //判断元素是否能删除
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
                            //当选中区域包含宏元素、格式化字符串、复用项目，
                            //List<ZYTextElement> list = new List<ZYTextElement>(deleteRealList.Cast<ZYTextElement>().ToList());
                            //foreach (ZYTextElement ele in list.Where(e => e is ZYMacro || e is ZYFormatString || e is ZYReplace))
                            //{
                            //    if (!(ele as ZYTextBlock).CanDelete)
                            //    {
                            YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                            return false;
                            //    }
                            //}
                        }
                        else
                        {
                        #endregion
                            //开始执行删除操作
                            if (deleteRealList.Count == para.ChildCount) //删除整个段落
                            {
                                if (para.Parent is TPTextCell && para.Parent.ChildCount == 1)
                                {
                                    if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //回车符需特殊处理
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
                            else //删除段落内被选定的文档元素
                            {
                                if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //回车符需特殊处理
                                {
                                    deleteRealList.RemoveAt(deleteRealList.Count - 1);
                                }
                                para.RemoveChildRange(deleteRealList);
                            }
                        }
                    }
                    #endregion

                    if (selectedChars.Count > 0) //索引越界判定
                    {
                        TPTextCell cell = myDocument.GetOwnerCell(selectedChars[0] as ZYTextElement);
                        if (cell != null)
                        {
                            cell.AdjustHeight(); //2014-08-07 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                        }
                    }
                }
                else
                {
                    //选定元素所处位置具体说明——>
                    // 1）选定元素不位于任何一个表格内（此时selectingAreaInOneTable = false）
                    // 2）选定元素位于同一个表格内并且有若干个单元格被选中（此时selectingAreaInOneTable = true && myDocument.SelectedCells.Count > 1）
                    // 3）选定元素不位于同一个表格内（存在交叉选定文档元素，此时selectingAreaInOneTable = false）

                    //当前被选中的文本类型元素（包括回车符）
                    ArrayList selectedChars = this.GetSelectElements();
                    //当前选定区域内的段落集合
                    ArrayList selectedParas = this.GetSelectParagraph();
                    //基于文本字符的删除列表——存储待删除的字符
                    ArrayList deleteList = new ArrayList();
                    //基于元素的删除真正列表——存储待删除的元素
                    ArrayList deleteRealList = new ArrayList();

                    #region 预处理表格内选定元素
                    //存储表格内被选中的文本类型元素（包括回车符）
                    ArrayList selectedCharsInTable = new ArrayList();
                    //先提取表格内选定元素，选中单元格或选中一个单元格内的文档元素单独处理删除操作
                    Dictionary<TPTextTable, List<TPTextCell>> DeleteElementsInTables = null;

                    if (selectingAreaInOneTable) //同一个表格内从SelectedCells中得到
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(null);

                        //校正删除元素之后的光标显示位置
                        TPTextCell firstCell = myDocument.GetOwnerCell(selectedChars[0] as ZYTextElement);
                        if (firstCell != null)
                        {
                            ZYTextParagraph firstPara = firstCell.ChildElements[0] as ZYTextParagraph;
                            int paraStartIndex = firstPara.FirstElement.Index; //段落开始元素索引号
                            if (firstPara.FirstElement is ZYTextBlock)
                            {
                                paraStartIndex = (firstPara.FirstElement as ZYTextBlock).FirstElement.Index;
                            }
                            OldSelectStart = paraStartIndex;
                        }
                    }
                    else //非一个表格内从selectedParas中得到
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(selectedParas);
                    }

                    if (DeleteElementsInTables.Count > 0)
                    {
                        //先从selectedParas中移除所有的包含于单元格内的段落
                        foreach (List<TPTextCell> cells in DeleteElementsInTables.Values)
                        {
                            foreach (TPTextCell cell in cells)
                            {
                                for (int i = 0; i < cell.ChildCount; i++)
                                {
                                    ZYTextParagraph para = cell.ChildElements[i] as ZYTextParagraph;
                                    selectedParas.Remove(para);

                                    #region 判定是否执行真正删除操作需要
                                    int paraStartIndex = para.FirstElement.Index; //段落第一个元素的索引序号
                                    if (para.FirstElement is ZYTextBlock)
                                    {
                                        paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                                    }
                                    int paraEndIndex = para.LastElement.Index; //段落最后一个元素（回车符）的索引序号
                                    ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);
                                    foreach (ZYTextElement ele in paraChars)
                                    {
                                        if (!selectedChars.Contains(ele)) //没有包含于selectedChars内的文本字符元素先放入selectedCharsInTable中
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

                    #region 判断是否执行真正删除操作
                    int intDelete = 0;
                    deleteRealList = myDocument.GetRealElements(selectedCharsInTable);
                    foreach (ZYTextElement ele in deleteRealList)
                    {
                        intDelete = myDocument.isDeleteElement(ele);

                        //如果为图片，删除数据库中记录
                        //if (ele is ZYTextDocumentLib.ZYTextImage)
                        //{
                        //    string imageId = (ele as ZYTextDocumentLib.ZYTextImage).CurrentImageID;
                        //    string _sql = string.Format("delete from RecordImage where id = '{0}'", imageId);
                        //    int nonQueryCount = YiDanSqlHelper.YD_SqlHelper.ExecuteNonQuery(_sql);
                        //}
                    }
                    if (intDelete != 0) return false; //不能执行真正删除操作则直接返回false
                    if (!this.Document.DeleteFlag) //判断是否能删除固定文本
                    {
                        //if (this.Document.Info.DocumentModel != DocumentModel.Design) //当前文档对象不处于设计状态
                        // {
                        foreach (ZYTextElement ele in selectedCharsInTable)
                        {
                            //处理固定文本
                            //if (ele.Parent is ZYFixedText || ele.Parent is ZYText)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                            //    return false;
                            //}
                            ////处理按钮
                            //if (ele is ZYButton && !((ZYButton)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                            //    return false;
                            //}
                            ////处理定位符
                            //if (ele is ZYFlag && !((ZYFlag)ele).CanDelete)
                            //{
                            //    YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                            //    return false;
                            //}

                            bool canDelete = CanDeleteElement(ele);
                            if (!canDelete) return false;
                        }
                        //}
                    }
                    #endregion

                    #region 删除表格内选定元素
                    if (DeleteElementsInTables.Count > 0)
                    {
                        int k = 0;
                        foreach (TPTextTable currTB in DeleteElementsInTables.Keys)
                        {
                            k++;
                            int allArea = 0; //存储选中单元格集合内非占位单元格的面积之和
                            foreach (TPTextCell cell in DeleteElementsInTables[currTB])
                            {
                                Rectangle rect = cell.GetContentBounds();
                                allArea += rect.Width * rect.Height;
                            }

                            //比较选中单元格外切矩形累加面积与当前表格面积是否相等——>若相等则代表表格整体被选中
                            if (currTB.Width * currTB.Height == allArea) //表格内元素被全部选中
                            {
                                currTB.Parent.RemoveChild(currTB);
                                //校正删除元素之后的光标显示位置
                                if (k == 1)
                                {
                                    TPTextCell firstCell = myDocument.GetOwnerCell(selectedChars[0] as ZYTextElement);
                                    if (firstCell != null)
                                    {
                                        ZYTextParagraph firstPara = firstCell.ChildElements[0] as ZYTextParagraph;
                                        int paraStartIndex = firstPara.FirstElement.Index; //段落开始元素索引号
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
                            else //表格内元素未被全部选中
                            {
                                foreach (TPTextCell cell in DeleteElementsInTables[currTB])
                                {
                                    //开始执行删除操作
                                    if (cell.ChildCount > 1)
                                    {
                                        cell.RemoveChildRange(cell.ChildElements.GetRange(0, cell.ChildCount - 1)); //先删除单元格内除最后一个段落之外的其他段落
                                    }
                                    ZYTextParagraph lastPara = cell.ChildElements[cell.ChildCount - 1] as ZYTextParagraph;
                                    lastPara.RemoveChildRange(lastPara.ChildElements.GetRange(0, lastPara.ChildCount - 1)); //单元格内最后一个段落的最后一个回车符不能删除
                                    cell.Selected = false;

                                    cell.AdjustHeight(); //2014-08-07 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                                }
                            }
                        }
                    }
                    #endregion
                    XmlDocument doc = new XmlDocument();
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Config.xml";
                    doc.Load(path);    //加载Xml文件 

                    #region 删除非表格内选定元素
                    if (!selectingAreaInOneTable) //位于同一个表格内的选定元素不能参加下述删除操作
                    {
                        //当前段落不位于单元格内——>这里需注意页眉、页脚内文档元素可全部删除，而正文必须留下一个回车符提供给用户输入
                        for (int i = 0; i < selectedParas.Count; i++) //迭代器不允许边操作边修改，所以采用for循环方式遍历
                        {
                            ZYTextParagraph para = selectedParas[i] as ZYTextParagraph;
                            //提取当前段落中的所有文本字符，并依此构建待删除的真正元素列表
                            deleteList.Clear();
                            int paraStartIndex = para.FirstElement.Index; //段落第一个元素的索引序号
                            if (para.FirstElement is ZYTextBlock)
                            {
                                paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                            }
                            int paraEndIndex = para.LastElement.Index; //段落最后一个元素（回车符）的索引序号
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


                            #region 2019.7.31-hdf：宏元素、格式化字符串、复用项目需要在文书录入是能修改文本
                            if (selectedParas.Count == 1 && deleteRealList.Count == 1 && (deleteRealList[0] is ZYMacro || deleteRealList[0] is ZYFormatString || deleteRealList[0] is ZYReplace || deleteRealList[0] is ZYDiag || deleteRealList[0] is ZYSubject))
                            {
                                //当选中区域为块元素中，并且是宏元素、格式化字符串、复用项目，则删除文本，不删除块元素，光标位置修正。
                                OldSelectStart = this.AbsSelectStart;
                                //判断当前选中是否为块元素全部文本
                                if ((deleteRealList[0] as ZYTextBlock).ChildCount == deleteList.Count)
                                {
                                    //判断元素是否能删除
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
                                //选中内内容超出单个元素范围，涉及多个元素
                                //List<ZYTextElement> list = new List<ZYTextElement>(deleteRealList.Cast<ZYTextElement>().ToList());
                                //foreach (ZYTextElement ele in list.Where(e => e is ZYMacro || e is ZYFormatString || e is ZYReplace))
                                //{
                                //    if (!(ele as ZYTextBlock).CanDelete)
                                //    {
                                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                                return false;
                                //    }
                                //}
                            }
                            else
                            {
                            #endregion
                                //开始执行删除操作
                                if (deleteRealList.Count == para.ChildCount) //删除整个段落
                                {
                                    if (para.Parent is ZYTextDiv)
                                    {
                                        #region 判断是否删除整个段落——>用于表格前后插入元素的特殊处理
                                        bool flag = true; //标志是否真的删除整个段落
                                        if (para.Parent.ChildElements.IndexOf(para) == 0) //第一个段落
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
                                        else if (para.Parent.ChildElements.IndexOf(para) == para.Parent.ChildCount - 1) //最后一个段落
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
                                        else //中间段落
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
                                            if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //回车符需特殊处理
                                            {
                                                deleteRealList.RemoveAt(deleteRealList.Count - 1);
                                            }
                                            para.RemoveChildRange(deleteRealList);
                                        }
                                    }
                                    else //文档页眉或文档页脚内容可全部删除
                                    {
                                        para.Parent.RemoveChild(para);
                                    }
                                }
                                else //删除段落内被选定的文档元素
                                {
                                    if (deleteRealList[deleteRealList.Count - 1] is ZYTextEOF) //回车符需特殊处理
                                    {
                                        deleteRealList.RemoveAt(deleteRealList.Count - 1);
                                    }
                                    para.RemoveChildRange(deleteRealList);
                                }
                            }
                        }
                    }
                    #endregion

                    //2019.8.5-hdf：宏元素、格式化字符串、复用项目在编辑块元素的文本时粘贴操作，会把文本粘贴到块元素上一个元素的父级容器内，修正光标位置
                    if (deleteRealList.Count == 0) OldSelectStart = this.AbsSelectStart;
                }

                myDocument.ContentChanged();

                //更新删除操作之后的光标（插入符）位置
                if (myDocument.HBFDocumentElement is ZYTextDiv) //当前编辑区为文档正文
                {
                    this.MoveSelectStart(OldSelectStart); //2014-08-08 更新光标到新位置必须在文档内容改变例程处理完毕之后进行
                }
                else //当前编辑区为文档页眉或文档页脚
                {
                    if (myDocument.HBFDocumentElement.ChildCount == 0)
                    {
                        myDocument.ToggleEditingArea(-1, -1, false); //全选删除页眉或页脚内容之后默认切换编辑区至正文
                    }
                    else
                    {
                        this.MoveSelectStart(OldSelectStart); //2014-08-08 更新光标到新位置必须在文档内容改变例程处理完毕之后进行
                    }
                }

                ////当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
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
        /// （处理Delete键单删除操作）删除当前光标位置处的后一个元素。
        /// </summary>
        /// <param name="flag">根据此参数决定删除固定文本时，是否需要进行删除提示。</param>
        /// <returns>返回0表示确认删除元素，返回1表示不删除该元素，返回2表示对该元素进行逻辑删除。</returns>
        public int DeleteCurrentElement(params object[] flag)
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return 1;
                if (IsLock(intSelectStart)) return 1;
                if (intSelectStart >= 0 && intSelectStart < HBFElements.Count - 1) //光标位于编辑区最后一个元素之前时不允许执行Delete删除操作
                {
                    ZYTextElement currEle = HBFElements[intSelectStart] as ZYTextElement; //当前光标位置处的后一个元素
                    int oldSelectStart = HBFElements.IndexOf(currEle); //当前光标位置处的后一个元素的索引序号

                    bool canDel = CanDeleteElement(currEle);

                    //2019.8.1-hdf：宏元素、格式化字符串、复用项目三个元素需单独判断，CanDeleteElement()方法无法判断
                    if ((currEle.Parent is ZYMacro || currEle.Parent is ZYFormatString || currEle.Parent is ZYReplace || currEle.Parent is ZYDiag || currEle.Parent is ZYSubject) && this.Document.Info.DocumentModel != DocumentModel.Design)
                    {
                        YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选中节点设置成不允许删除");
                        canDel = (currEle.Parent as ZYTextBlock).CanDelete;
                    }

                    if (!canDel) return 1;

                    #region 开始执行删除操作
                    int intDelete = myDocument.isDeleteElement(currEle);
                    if (intDelete == 0) //确认删除
                    {
                        ZYTextParagraph currPara = myDocument.GetOwnerPara(currEle); //当前光标所处段落（段落最后一个元素肯定是回车符）
                        ZYTextContainer currRoot = myDocument.GetOwnerRoot(currEle); //当前光标所处段落所属顶级容器

                        if (currEle is ZYTextEOF) //当前光标位置处后一个元素为回车符
                        {
                            if (currPara.ChildCount == 1) //如果当前光标所处段落为一个空段落（仅包含一个回车符）
                            {
                                if (IsParaInCell(currEle)) //单元格内
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.IndexOf(currPara) == currCell.ChildCount - 1) return 1; //当前光标所处段落为单元格内最后一个段落，则不允许执行Delete删除操作——>但最好支持撤销重做栈

                                    #region 合并段落内容
                                    ZYTextParagraph nextPara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) + 1] as ZYTextParagraph;
                                    //ArrayList insertList = nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1); //不能以这种方式进行段落合并，撤销操作之后再Delete删除会有问题
                                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                    xmlDoc.PreserveWhitespace = true;
                                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                    ZYTextElement.ElementsToXML(nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1), xmlDoc.DocumentElement);
                                    ArrayList insertList = new ArrayList();
                                    myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                    currCell.RemoveChild(nextPara); //先删除下一个段落——>注意这个顺序非常重要，撤销重做栈操作正确的前提
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //更新插入元素的父容器
                                    }
                                    currPara.InsertRangeBefore(insertList, currPara.LastElement); //再将下一个段落除回车符之外的元素添加至当前段落 
                                    #endregion

                                    currCell.AdjustHeight(); //2014-08-07 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                                }
                                else //非单元格内
                                {
                                    //判定当前光标所处段落的下一个文本容器
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] is ZYTextParagraph) //段落容器
                                    {
                                        currRoot.RemoveChild(currPara);
                                    }
                                    else if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] is TPTextTable) //表格容器
                                    {
                                        //删除表格之前段落时的判定——>表格之前仅有一个段落时不允许删除
                                        if (currRoot.IndexOf(currPara) > 0 && currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is ZYTextParagraph)
                                        {
                                            currRoot.RemoveChild(currPara);
                                        }
                                    }
                                }
                            }
                            else //当前光标所处段落为非空段落
                            {
                                if (IsParaInCell(currEle)) //单元格内
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.ChildElements.IndexOf(currPara) != currCell.ChildCount - 1) //非单元格内最后一个段落
                                    {
                                        #region 合并段落内容
                                        ZYTextParagraph nextPara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) + 1] as ZYTextParagraph;
                                        //ArrayList insertList = nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1); //不能以这种方式进行段落合并，撤销操作之后再Delete删除会有问题
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        currCell.RemoveChild(nextPara); //先删除下一个段落——>注意这个顺序非常重要，撤销重做栈操作正确的前提
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //更新插入元素的父容器
                                        }
                                        currPara.InsertRangeBefore(insertList, currPara.LastElement); //再将下一个段落除回车符之外的元素添加至当前段落 
                                        #endregion

                                        currCell.AdjustHeight(); //2014-08-07 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                                    }
                                }
                                else //非单元格内
                                {
                                    //判定当前光标所处段落的上一个文本容器
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] is ZYTextParagraph) //段落容器
                                    {
                                        #region 合并段落内容
                                        ZYTextParagraph nextPara = currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) + 1] as ZYTextParagraph;
                                        //ArrayList insertList = nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1); //不能以这种方式进行段落合并，撤销操作之后再Delete删除会有问题
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(nextPara.ChildElements.GetRange(0, nextPara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        currRoot.RemoveChild(nextPara); //先删除当前段落
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //更新插入元素的父容器
                                        }
                                        currPara.InsertRangeBefore(insertList, currPara.LastElement); //再将当前段落除回车符之外的元素添加至下一个段落 
                                        #endregion
                                    }
                                    //备注：当前段落回车符之后紧接着是表格则不执行Delete删除操作
                                }
                            }
                        }
                        else //当前光标所处段落为非空段落，并且当前光标位于此段落尾部之前
                        {
                            //2014-09-25 单元格自适应高度
                            TPTextCell currCell = null;
                            if (IsParaInCell(currEle)) //单元格内
                            {
                                currCell = myDocument.GetOwnerCell(currEle);
                            }

                            if (currEle.Parent is ZYTextBlock)
                            {
                                currPara.RemoveChild(currEle.Parent as ZYTextBlock);
                                //this.MoveSelectStart(currEle.Parent.FirstElement.Index); //删除段落内的文本块元素需要重新调整光标位置
                                oldSelectStart = currEle.Parent.FirstElement.Index; //2014-08-08 更新光标位置
                            }
                            else
                            {
                                currPara.RemoveChild(currEle);
                            }

                            //2014-09-25 单元格自适应高度
                            if (currCell != null) //单元格内
                            {
                                currCell.AdjustHeight();
                            }
                        }

                        ////当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                        //TPTextCell cell = myDocument.GetOwnerCell(CurrentElement);
                        //if (cell != null)
                        //{
                        //    cell.AdjustHeight();
                        //}

                        myDocument.ContentChanged();
                        this.MoveSelectStart(oldSelectStart); //2014-08-08 更新光标到新位置必须在文档内容改变例程处理完毕之后进行
                    }
                    else if (intDelete == 2) //逻辑删除
                    {
                        this.MoveSelectStart(intSelectStart + 1); //移动光标至当前光标位置处的后一个元素之前
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
        /// 判断当前的数据元素是否允许被删除
        /// 在设计模式下可以删除所有节点
        /// </summary>
        /// <param name="zyTextElement"></param>
        /// <returns></returns>
        private bool CanDeleteElement(ZYTextElement zyTextElement)
        {
            if (this.Document.Info.DocumentModel == DocumentModel.Design) return true;   //在设计模式下可以删除所有节点

            if ((zyTextElement.Parent is ZYFixedText || zyTextElement.Parent is ZYText)) //固定文本  
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("删除范围中包含固定内容，不能删除");
                return false;
            }
            //处理按钮
            else if (zyTextElement is ZYButton && !((ZYButton)zyTextElement).CanDelete)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                return false;
            }
            //处理定位符
            else if (zyTextElement is ZYFlag && !((ZYFlag)zyTextElement).CanDelete)
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选择范围中包含固定内容，不能删除");
                return false;
            }
            else if (zyTextElement is ZYFlag && !((ZYFlag)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("删除范围中包含固定内容，不能删除");
                return false;
            }
            else if (zyTextElement is ZYToothCheck && !((ZYToothCheck)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选中节点设置成不允许删除");
                return false;
            }
            else if (zyTextElement is ZYMensesFormula && !((ZYMensesFormula)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选中节点设置成不允许删除");
                return false;
            }
            else if (zyTextElement is ZYCheckBox && !((ZYCheckBox)zyTextElement).CanDelete)
            {

                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选中节点设置成不允许删除");
                return false;
            }
            else if (zyTextElement.Parent is ZYTextBlock
                && !((ZYTextBlock)zyTextElement.Parent).CanDelete
                //宏元素、格式化字符串、复用项目不在此判断，在删除最后一个文本时判断
                && !(zyTextElement.Parent is ZYMacro)
                && !(zyTextElement.Parent is ZYFormatString)
                && !(zyTextElement.Parent is ZYReplace)
                && !(zyTextElement.Parent is ZYDiag)
                && !(zyTextElement.Parent is ZYSubject)
                )
            {
                YiDanCommon.Ctrs.DLG.YiDanMessageBox.Show("选中节点设置成不允许删除");
                return false;
            }
            return true;
        }

        /// <summary>
        /// （处理Backspace键单删除操作）删除当前光标位置处的前一个元素。
        /// </summary>
        /// <param name="flag">根据此参数决定删除固定文本时，是否需要进行删除提示。</param>
        /// <returns>返回0表示确认删除元素，返回1表示不删除该元素，返回2表示对该元素进行逻辑删除。</returns>
        public int DeletePreElement(params object[] flag)
        {
            try
            {
                if (HBFElements == null || HBFElements.Count == 0) return 1;
                if (IsLock(intSelectStart)) return 1;
                if (intSelectStart > 0 && intSelectStart < HBFElements.Count) //光标位于编辑区第一个元素之前时不允许执行Backspace删除操作
                {
                    ZYTextElement preEle = HBFElements[intSelectStart - 1] as ZYTextElement; //当前光标位置处的前一个元素
                    ZYTextElement currEle = HBFElements[intSelectStart] as ZYTextElement; //当前光标位置处的后一个元素
                    int oldSelectStart = HBFElements.IndexOf(preEle); //当前光标位置处的前一个元素的索引序号

                    bool canDel = CanDeleteElement(preEle);
                    if (!canDel) return 1;

                    #region 开始执行删除操作
                    int intDelete = myDocument.isDeleteElement(preEle);
                    if (intDelete == 0) //确认删除
                    {
                        ZYTextParagraph currPara = myDocument.GetOwnerPara(currEle); //当前光标所处段落（段落最后一个元素肯定是回车符）
                        ZYTextContainer currRoot = myDocument.GetOwnerRoot(currEle); //当前光标所处段落所属顶级容器

                        if (currEle is ZYTextEOF) //当前光标位置处后一个元素为回车符
                        {
                            if (currPara.ChildCount == 1) //如果当前光标所处段落为一个空段落（仅包含一个回车符）
                            {
                                if (IsParaInCell(currEle)) //单元格内
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.IndexOf(currPara) == 0) return 1; //当前光标所处段落为单元格内第一个段落，则不允许执行Backspace删除操作——>但最好支持撤销重做栈

                                    #region 合并段落内容
                                    ZYTextParagraph prePara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                    //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //不能以这种方式进行段落合并，撤销操作之后再Delete删除会有问题
                                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                    xmlDoc.PreserveWhitespace = true;
                                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                    ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                    ArrayList insertList = new ArrayList();
                                    myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //更新插入元素的父容器
                                    }
                                    currCell.RemoveChild(prePara); //先删除前一个段落——>注意这个顺序非常重要，撤销重做栈操作正确的前提
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //更新插入元素的父容器
                                    }
                                    currPara.InsertRangeBefore(insertList, currPara.FirstElement); //再将前一个段落除回车符之外的元素添加至当前段落 
                                    #endregion

                                    currCell.AdjustHeight(); //2014-08-07 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                                }
                                else //非单元格内
                                {
                                    //判定当前光标所处段落的上一个文本容器
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is ZYTextParagraph) //段落容器
                                    {
                                        #region 合并段落内容
                                        ZYTextParagraph prePara = currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                        //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //不能以这种方式进行段落合并，撤销操作之后再Delete删除会有问题
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //更新插入元素的父容器
                                        }
                                        currRoot.RemoveChild(prePara); //先删除前一个段落——>注意这个顺序非常重要，撤销重做栈操作正确的前提
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //更新插入元素的父容器
                                        }
                                        currPara.InsertRangeBefore(insertList, currPara.FirstElement); //再将前一个段落除回车符之外的元素添加至当前段落 
                                        #endregion
                                    }
                                    else if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is TPTextTable) //表格容器
                                    {
                                        //备注：当前段落回车符之前紧接着是表格则不执行Backspace删除操作
                                        oldSelectStart = HBFElements.IndexOf(currEle); //保持当前光标位置不变
                                    }
                                }
                            }
                            else //当前光标所处段落为非空段落
                            {
                                if (preEle.Parent is ZYTextBlock) //判断是否为文本块元素
                                {
                                    #region 2019.7.31-hdf：文书录入时宏元素text允许修改文本
                                    if (preEle.Parent is ZYMacro || preEle.Parent is ZYReplace || preEle.Parent is ZYFormatString || preEle.Parent is ZYDiag || preEle.Parent is ZYSubject)
                                    {
                                        //判断删除的是否是块元素的最后一个字符
                                        int index = preEle.Parent.ChildElements.IndexOf(preEle);
                                        if (index == 0 && preEle.Parent.ChildElements.Count == 1)
                                        {
                                            preEle.Parent.RemoveChild(preEle);
                                            //判断该块元素是否允许删除
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
                                                //不允许删除则Text改成Name属性值，刷新大小显示，由于新添加的文本没有index所以光标位置只能加等于子元素数量
                                                //(preEle.Parent as ZYTextBlock).Text = ((ZYTextBlock)preEle.Parent).Name;
                                                (preEle.Parent as ZYTextBlock).Text = " "; //如果不允许删除，则保留一个空格
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
                                        oldSelectStart = preEle.Parent.FirstElement.Index; //删除段落内的文本块元素需要重新调整光标位置
                                    }
                                    #endregion
                                }
                                else
                                {
                                    currPara.RemoveChild(preEle);
                                }

                                //2014-09-25 单元格自适应高度
                                if (IsParaInCell(currEle)) //单元格内
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    currCell.AdjustHeight();
                                }
                            }
                        }
                        else //当前光标所处段落为非空段落，并且当前光标位于此段落尾部之前
                        {
                            if ((currEle.Parent is ZYTextBlock ? currPara.IndexOf(currEle.Parent) : currPara.IndexOf(currEle)) == 0
                                && !(currEle.Parent is ZYMacro || currEle.Parent is ZYReplace || currEle.Parent is ZYFormatString || currEle.Parent is ZYDiag || currEle.Parent is ZYSubject)) //当前光标位于段落首部
                            {
                                if (IsParaInCell(currEle)) //单元格内
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    if (currCell.IndexOf(currPara) == 0) return 1; //当前光标所处段落为单元格内第一个段落，则不允许执行Backspace删除操作——>但最好支持撤销重做栈

                                    #region 合并段落内容
                                    ZYTextParagraph prePara = currCell.ChildElements[currCell.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                    //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //不能以这种方式进行段落合并，撤销操作之后再Delete删除会有问题
                                    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                    xmlDoc.PreserveWhitespace = true;
                                    xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                    ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                    ArrayList insertList = new ArrayList();
                                    myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //更新插入元素的父容器
                                    }
                                    currCell.RemoveChild(prePara); //先删除前一个段落——>注意这个顺序非常重要，撤销重做栈操作正确的前提
                                    foreach (ZYTextElement ele in insertList)
                                    {
                                        ele.Parent = currPara; //更新插入元素的父容器
                                    }
                                    currPara.InsertRangeBefore(insertList, currPara.FirstElement); //再将前一个段落除回车符之外的元素添加至当前段落 
                                    #endregion

                                    currCell.AdjustHeight(); //2014-08-07 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                                }
                                else //非单元格内
                                {
                                    //判定当前光标所处段落的上一个文本容器
                                    if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is ZYTextParagraph) //段落容器
                                    {
                                        #region 合并段落内容
                                        ZYTextParagraph prePara = currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] as ZYTextParagraph;
                                        //ArrayList insertList = prePara.ChildElements.GetRange(0, prePara.ChildCount - 1); //不能以这种方式进行段落合并，撤销操作之后再Delete删除会有问题
                                        System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                        xmlDoc.PreserveWhitespace = true;
                                        xmlDoc.AppendChild(xmlDoc.CreateElement(ZYTextConst.c_ClipboardDataFormat));
                                        ZYTextElement.ElementsToXML(prePara.ChildElements.GetRange(0, prePara.ChildCount - 1), xmlDoc.DocumentElement);
                                        ArrayList insertList = new ArrayList();
                                        myDocument.LoadElementsToList(xmlDoc.DocumentElement, insertList);
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //更新插入元素的父容器
                                        }
                                        currRoot.RemoveChild(prePara); //先删除前一个段落——>注意这个顺序非常重要，撤销重做栈操作正确的前提
                                        foreach (ZYTextElement ele in insertList)
                                        {
                                            ele.Parent = currPara; //更新插入元素的父容器
                                        }

                                        if (currEle.Parent is ZYTextBlock) //遇到文本块元素需要特别处理 2014-08-13 这个非常关键
                                        {
                                            currPara.RemoveChild(currEle.Parent as ZYTextBlock);
                                            oldSelectStart = currEle.Parent.FirstElement.Index - 1; //删除段落内的文本块元素需要重新调整光标位置，必须减去1
                                        }

                                        currPara.InsertRangeBefore(insertList, currPara.FirstElement); //再将前一个段落除回车符之外的元素添加至当前段落 
                                        #endregion
                                    }
                                    else if (currRoot.ChildElements[currRoot.ChildElements.IndexOf(currPara) - 1] is TPTextTable) //表格容器
                                    {
                                        //备注：当前段落回车符之前紧接着是表格则不执行Backspace删除操作
                                        oldSelectStart = HBFElements.IndexOf(currEle); //保持当前光标位置不变
                                    }
                                }
                            }
                            else //当前光标位于段落中部
                            {
                                if (preEle.Parent is ZYTextBlock) //判断是否为文本块元素
                                {
                                    #region 2019.7.31-hdf：文书录入时宏元素text允许修改
                                    if (preEle.Parent is ZYMacro || preEle.Parent is ZYReplace || preEle.Parent is ZYFormatString || preEle.Parent is ZYDiag || preEle.Parent is ZYSubject)
                                    {
                                        //判断删除的是否是块元素的最后一个字符
                                        int index = preEle.Parent.ChildElements.IndexOf(preEle);
                                        if (index == 0 && preEle.Parent.ChildElements.Count == 1)
                                        {
                                            preEle.Parent.RemoveChild(preEle);
                                            //判断该块元素是否允许删除
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
                                                //不允许删除则Text改成Name属性值，刷新大小显示，由于新添加的文本没有index所以光标位置只能加等于子元素数量
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
                                        oldSelectStart = preEle.Parent.FirstElement.Index; //删除段落内的文本块元素需要重新调整光标位置
                                    }
                                    #endregion
                                }
                                else
                                {
                                    currPara.RemoveChild(preEle);
                                }

                                //2014-09-25 单元格自适应高度
                                if (IsParaInCell(currEle)) //单元格内
                                {
                                    TPTextCell currCell = myDocument.GetOwnerCell(currEle);
                                    currCell.AdjustHeight();
                                }
                            }
                        }

                        //this.MoveSelectStart(oldSelectStart);

                        ////当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                        //TPTextCell cell = myDocument.GetOwnerCell(CurrentElement);
                        //if (cell != null)
                        //{
                        //    cell.AdjustHeight();
                        //}

                        myDocument.ContentChanged();
                        this.MoveSelectStart(oldSelectStart); //2014-08-08 更新光标到新位置必须在文档内容改变例程处理完毕之后进行
                    }
                    else if (intDelete == 2) //逻辑删除
                    {
                        this.MoveSelectStart(oldSelectStart); //移动光标至当前光标位置处的后一个元素之前
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

        #region 字体属性 添加于2014-08-15
        /// <summary>
        /// 设置当前鼠标选定区域内的所有文本类型元素的字体属性。
        /// </summary>
        /// <param name="index">属性的内部序号。</param>
        /// <param name="strValue">属性值。</param>
        /// <param name="flag">标志是否为仅在一个单元格内的选定文本属性操作。</param>
        public void SetSelectingAreaAttribute(int index, string strValue, bool flag)
        {
            try
            {
                if (flag) //一个单元格内选定文本
                {
                    ArrayList myList = this.GetSelectElements();
                    this.UpdateFontAttribute(index, strValue, myList);
                    TPTextCell cell = myDocument.GetOwnerCell(myList[0] as ZYTextElement);
                    if (cell != null)
                    {
                        cell.AdjustHeight(); //2014-08-15 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                    }
                }
                else //多个单元格选定或交叉选定文档元素与表格内元素
                {
                    ArrayList myList = this.GetSelectElements();

                    #region 预处理表格内选定元素
                    //当前选定区域内的段落集合
                    ArrayList selectedParas = this.GetSelectParagraph();
                    //先提取表格内选定元素，选中单元格或选中一个单元格内的文档元素单独处理删除操作
                    Dictionary<TPTextTable, List<TPTextCell>> DeleteElementsInTables = null;
                    if (selectingAreaInOneTable) //同一个表格内从SelectedCells中得到
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(null);
                    }
                    else //非一个表格内从selectedParas中得到
                    {
                        DeleteElementsInTables = GetSelectedElementsInTable(selectedParas);
                    }

                    if (DeleteElementsInTables.Count > 0)
                    {
                        //先从selectedParas中移除所有的包含于单元格内的字符元素（包括回车符）
                        foreach (List<TPTextCell> cells in DeleteElementsInTables.Values)
                        {
                            foreach (TPTextCell cell in cells)
                            {
                                for (int i = 0; i < cell.ChildCount; i++)
                                {
                                    ZYTextParagraph para = cell.ChildElements[i] as ZYTextParagraph;
                                    int paraStartIndex = para.FirstElement.Index; //段落第一个元素的索引序号
                                    if (para.FirstElement is ZYTextBlock)
                                    {
                                        paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                                    }
                                    int paraEndIndex = para.LastElement.Index; //段落最后一个元素（回车符）的索引序号
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

                    #region 处理表格内选定元素——>开始更新字体属性
                    if (DeleteElementsInTables.Count > 0)
                    {
                        foreach (TPTextTable currTB in DeleteElementsInTables.Keys)
                        {
                            foreach (TPTextCell cell in DeleteElementsInTables[currTB])
                            {
                                for (int i = 0; i < cell.ChildCount; i++)
                                {
                                    ZYTextParagraph para = cell.ChildElements[i] as ZYTextParagraph;
                                    int paraStartIndex = para.FirstElement.Index; //段落第一个元素的索引序号
                                    if (para.FirstElement is ZYTextBlock)
                                    {
                                        paraStartIndex = (para.FirstElement as ZYTextBlock).FirstElement.Index;
                                    }
                                    int paraEndIndex = para.LastElement.Index; //段落最后一个元素（回车符）的索引序号
                                    ArrayList paraChars = HBFElements.GetRange(paraStartIndex, paraEndIndex - paraStartIndex + 1);

                                    this.UpdateFontAttribute(index, strValue, paraChars);
                                    cell.AdjustHeight(); //2014-08-15 当前元素处于单元格内则需单元格自适应高度动态调整，并且要在文档内容改变处理例程之前调用
                                }
                            }
                        }
                    }
                    #endregion

                    //处理非表格内选定元素——>开始更新字体属性
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
        /// <param name="index">属性的内部序号。</param>
        /// <param name="strValue">属性值。</param>
        /// <param name="myList">指定的文本类型元素列表。</param>
        private void UpdateFontAttribute(int index, string strValue, ArrayList myList)
        {
            try
            {
                for (int iCount = 0; iCount < myList.Count; iCount++)
                {
                    if (myList[iCount] is ZYTextLineEnd) continue; //跳过软回车符

                    switch (index)
                    {
                        case 0: //字体名称
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontName = strValue;
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontName = strValue;
                            }
                            break;
                        case 1: //字体大小
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontSize = float.Parse(strValue);
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontSize = float.Parse(strValue);
                            }
                            break;
                        case 2: //粗体
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontBold = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontBold = strValue.Equals("1");
                            }
                            break;
                        case 3: //斜体
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontItalic = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontItalic = strValue.Equals("1");
                            }
                            break;
                        case 4: //下划线
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).FontUnderLine = strValue.Equals("1");
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).FontUnderLine = strValue.Equals("1");
                            }
                            break;
                        case 5: //文本颜色
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            else
                            {
                                (myList[iCount] as ZYTextEOF).ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            break;
                        case 6: //元素的数据名称
                            //myChar.Name = strValue ;
                            break;
                        case 7: //下标
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).Sub = strValue.Equals("1");
                            }
                            break;
                        case 8: //上标
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).Sup = strValue.Equals("1");
                            }
                            break;
                        case 9: //文本背景颜色
                            if (myList[iCount] is ZYTextChar)
                            {
                                (myList[iCount] as ZYTextChar).BackgroundColor = System.Drawing.Color.FromArgb(Convert.ToInt32(strValue));
                            }
                            break;
                        case 10: //圈字
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
                        //如果是ZYTextBlock中的字符，同时设置ZYTextBlock的属性
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
