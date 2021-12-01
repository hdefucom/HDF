using System;
//using ZYCommon;
using YidanSoft.Library.EmrEditor.Src.Actions;
using YidanSoft.Library.EmrEditor.Src.Document;

namespace ZYTextDocumentLib
{
    /// <summary>
    /// 用于处理文档元素新增或删除操作的动作
    /// </summary>
    /// <remarks>本动作对象比较特别特别</remarks>
    public class A_ContentChangeLog : ZYEditorAction
    {
        /// <summary>
        /// 对象是否可以进行记录
        /// </summary>
        internal bool CanLog = true;
        /// <summary>
        /// 本操作涉及到的元素的父元素
        /// </summary>
        internal ZYTextContainer Container = null;
        /// <summary>
        /// 新插入的元素在元素列表中的序号
        /// </summary>
        internal int index = 0;
        private System.Collections.ArrayList myUndoSteps = new System.Collections.ArrayList();

        #region add by myc 2014-07-11 添加原因：新版页眉二期改版（新版页脚）撤销重做
        /// <summary>
        /// 撤销动作所经历的步骤列表。
        /// </summary>
        public System.Collections.ArrayList UndoSteps
        {
            get { return myUndoSteps; }
        }
        #endregion

        /// <summary>
        /// 对象显示的名称
        /// </summary>
        public string strUndoName = null;

        /// <summary>
        /// 内部用于保存一个撤销操作信息的对象
        /// </summary>
        //private class UndoStep
        public class UndoStep
        {
            /// <summary>
            /// 元素在子元素列表中的序号
            /// </summary>
            internal int index;
            /// <summary>
            /// 涉及到的元素对象
            /// </summary>
            internal ZYTextElement Element;
            /// <summary>
            /// 涉及到的元素的数组
            /// </summary>
            internal System.Collections.ArrayList Elements;
            /// <summary>
            /// 涉及到的属性对象
            /// </summary>
            internal ZYAttribute Attribute;
            /// <summary>
            /// 涉及到的旧的数值
            /// </summary>
            internal object OldValue;
            /// <summary>
            /// 涉及到的新的数值
            /// </summary>
            internal object NewValue;
            /// <summary>
            /// 撤销操作信息类型
            /// </summary>
            internal int Style = 0;

            /// <summary>
            /// 针对同一个表格内拖选单元格删除所有段落记录单元格被选中的状态需要 add by myc 2014-08-07。
            /// </summary>
            internal bool Selected;

            /// <summary>
            /// 2019.7.31-hdf：添加对象属性字段撤销重做功能
            /// 涉及到的类成员对象（对象的属性、字段、函数(函数暂未实现)等）
            /// </summary>
            internal object ClassMember;
        }

        /// <summary>
        /// 添加修改对象属性的记录
        /// </summary>
        /// <param name="vElement">该属性所属的元素</param>
        /// <param name="vAttribute">属性对象</param>
        /// <param name="NewValue">将要设置的新的属性值</param>
        public void LogAttribute(ZYTextElement vElement, ZYAttribute vAttribute, object NewValue)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.Element = vElement;
                NewStep.Attribute = vAttribute;
                NewStep.OldValue = vAttribute.Value;
                NewStep.NewValue = NewValue;
                NewStep.Style = 4;
                myUndoSteps.Add(NewStep);
            }
        }

        /// <summary>
        /// 登记新增元素动作
        /// </summary>
        /// <param name="index">新增元素在元素列表中的序号</param>
        /// <param name="NewElement">新增的元素</param>
        public void LogInsert(int index, ZYTextElement NewElement)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.index = index;
                NewStep.Element = NewElement;
                NewStep.Style = 0;
                myUndoSteps.Add(NewStep);
            }
        }
        /// <summary>
        /// 登记新增多个元素动作
        /// </summary>
        /// <param name="index">第一个新增元素在元素列表中的序号</param>
        /// <param name="myList">新增的元素集合</param>
        public void LogInsertRange(int index, System.Collections.ArrayList myList)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.index = index;
                NewStep.Elements = myList;
                NewStep.Style = 1;
                myUndoSteps.Add(NewStep);
            }
        }

        /// <summary>
        /// 登记追加元素动作
        /// </summary>
        /// <param name="NewElement">追加的元素</param>
        public void LogAdd(ZYTextElement NewElement)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.Style = 2;
                NewStep.Element = NewElement;
                myUndoSteps.Add(NewStep);
            }
        }
        /// <summary>
        /// 登记追加多个元素动作
        /// </summary>
        /// <param name="myList">追加的元素列表</param>
        public void LogAddRang(System.Collections.ArrayList myList)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.Elements = myList;
                NewStep.Style = 5;
                myUndoSteps.Add(NewStep);
            }
        }
        /// <summary>
        /// 登记删除元素动作
        /// </summary>
        /// <param name="index">元素在元素列表中的序号</param>
        /// <param name="myElement">要删除的元素</param>
        public void LogRemove(int index, ZYTextElement myElement)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.Style = 3;
                NewStep.index = index;
                NewStep.Element = myElement;
                myUndoSteps.Add(NewStep);
            }
        }

        public void LogRemoveRange(int index, System.Collections.ArrayList myList)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();

                NewStep.Elements = new System.Collections.ArrayList();
                NewStep.Elements.AddRange(myList);

                NewStep.index = index;
                NewStep.Style = 6;

                #region add by myc 2014-08-07 撤销删除单元格内段落时的反色绘制
                if (myOwnerDocument.Content.SelectingAreaInOneTable)
                {
                    if (this.Container is TPTextCell)
                    {
                        NewStep.Selected = (this.Container as TPTextCell).Selected;
                    }
                    else if (this.Container.Parent is TPTextCell)
                    {
                        NewStep.Selected = (this.Container.Parent as TPTextCell).Selected;
                    }
                }
                #endregion

                myUndoSteps.Add(NewStep);
            }
        }

        /// <summary>
        /// 2019.7.31-hdf
        /// 登记修改对象属性动作
        /// </summary>
        /// <param name="vElement"></param>
        /// <param name="property"></param>
        /// <param name="OldValue"></param>
        /// <param name="NewValue"></param>
        public void LogProperty(ZYTextElement vElement, System.Reflection.PropertyInfo property, object OldValue, object NewValue)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.ClassMember = property;
                NewStep.OldValue = OldValue;
                NewStep.NewValue = NewValue;
                NewStep.Element = vElement;
                NewStep.Style = 7;
                myUndoSteps.Add(NewStep);
            }
        }
        /// <summary>
        /// 2019.7.31-hdf
        /// 登记修改对象字段动作
        /// </summary>
        /// <param name="vElement"></param>
        /// <param name="filed"></param>
        /// <param name="OldValue"></param>
        /// <param name="NewValue"></param>
        public void LogField(ZYTextElement vElement, System.Reflection.FieldInfo filed, object OldValue, object NewValue)
        {
            if (CanLog)
            {
                UndoStep NewStep = new UndoStep();
                NewStep.ClassMember = filed;
                NewStep.OldValue = OldValue;
                NewStep.NewValue = NewValue;
                NewStep.Element = vElement;
                NewStep.Style = 8;
                myUndoSteps.Add(NewStep);
            }
        }



        #region add by myc 2014-06-12 注释原因：特殊情况下删除回车符时，根本就不允许删除，但是也应该记录此动作
        /// <summary>
        /// 登记删除一系列元素空动作。
        /// </summary>
        public void LogRemoveRange()
        {
            try
            {
                if (CanLog)
                {
                    UndoStep NewStep = new UndoStep();
                    NewStep.Style = 6;
                    myUndoSteps.Add(NewStep);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        /// <summary>
        /// 已重载:当对象没有撤销信息时对象不可用
        /// </summary>
        /// <returns></returns>
        public override bool isEnable()
        {
            return myUndoSteps.Count > 0;
        }

        /// <summary>
        /// 已重载:执行重复操作
        /// </summary>
        /// <returns></returns>
        public override bool Redo()
        {
            bool bolRefreshElements = false;
            int NewIndex = -1;
            ZYTextElement NewStart = null;
            if (myUndoSteps.Count > 0)
            {
                foreach (UndoStep myStep in myUndoSteps)
                {
                    switch (myStep.Style)
                    {
                        case 0:
                            Container = myStep.Element.Parent;

                            bolRefreshElements = true;
                            Container.ChildElements.Insert(myStep.index, myStep.Element);
                            myStep.Element.OwnerDocument = Container.OwnerDocument;
                            myStep.Element.Parent = Container;
                            NewStart = myStep.Element;
                            break;
                        case 1:
                            Container = (myStep.Elements[0] as ZYTextElement).Parent;
                            bolRefreshElements = true;
                            Container.ChildElements.InsertRange(myStep.index, myStep.Elements);
                            if (myStep.Elements.Count > 0)
                                NewStart = (ZYTextElement)myStep.Elements[0];
                            break;
                        case 5:
                            Container = (myStep.Elements[0] as ZYTextElement).Parent;
                            bolRefreshElements = true;
                            Container.ChildElements.AddRange(myStep.Elements);
                            if (myStep.Elements.Count > 0)
                                NewStart = (ZYTextElement)myStep.Elements[0];
                            break;
                        case 6:
                            if (myStep.Elements == null) break; //add by myc 2014-06-24 注释原因：特殊情况下删除回车符时，根本就不允许删除，但是也应该记录此动作

                            Container = (myStep.Elements[0] as ZYTextElement).Parent;
                            bolRefreshElements = true;
                            NewIndex = myStep.index;
                            Container.ChildElements.RemoveRange(myStep.index, myStep.Elements.Count);

                            #region add by myc 2014-08-07 撤销删除单元格内段落时的反色绘制
                            if (Container != null)
                            {
                                if (Container is TPTextCell)
                                {
                                    (Container as TPTextCell).Selected = !myStep.Selected;
                                }
                                else if (Container.Parent is TPTextCell)
                                {
                                    (Container.Parent as TPTextCell).Selected = !myStep.Selected;
                                }
                            }
                            #endregion

                            break;
                        case 2:
                            Container = myStep.Element.Parent;
                            bolRefreshElements = true;
                            Container.ChildElements.Add(myStep.Element);
                            NewStart = myStep.Element;
                            break;
                        case 3:
                            Container = myStep.Element.Parent;
                            bolRefreshElements = true;
                            NewIndex = myStep.index;
                            Container.ChildElements.Remove(myStep.Element);
                            //2021-04-13:表格行删除撤销重做栈时，只删除了ChildElements未删除AllRows导致布局错误，根本原因是设计不合理导致
                            if (Container is TPTextTable && myStep.Element is TPTextRow)
                            {
                                TPTextTable t = Container as TPTextTable;
                                TPTextRow r = myStep.Element as TPTextRow;
                                t.AllRows.Remove(r);
                            }
                            break;
                        case 4:

                            myStep.Attribute.SetValue(myStep.NewValue);
                            myStep.Element.RefreshSize();
                            NewStart = myStep.Element;
                            myStep.Element.UpdateAttrubute();
                            break;
                        #region 2019.7.31-hdf：添加修改对象属性、字段撤销重做功能
                        case 7:
                            System.Reflection.PropertyInfo property = myStep.ClassMember as System.Reflection.PropertyInfo;
                            property.SetValue(myStep.Element, myStep.NewValue, null);
                            myStep.Element.RefreshSize();
                            NewStart = myStep.Element;
                            break;
                        case 8:
                            System.Reflection.FieldInfo field = myStep.ClassMember as System.Reflection.FieldInfo;
                            field.SetValue(myStep.Element, myStep.NewValue);
                            myStep.Element.RefreshSize();
                            NewStart = myStep.Element;
                            break;
                        #endregion
                    }


                    #region add by myc 2014-08-15 重做单元格内插入、删除、复制、粘贴、剪切等操作时的单元格自适应高度调整
                    //2014-08-15 新版撤销操作时的单元格自适应高度
                    if (myStep.Element != null)
                    {
                        TPTextCell cell = myOwnerDocument.GetOwnerCell(myStep.Element);
                        if (cell != null)
                        {
                            cell.AdjustHeight();
                        }
                    }
                    else if (myStep.Elements != null)
                    {
                        TPTextCell cell = myOwnerDocument.GetOwnerCell(myStep.Elements[0] as ZYTextElement);
                        if (cell != null)
                        {
                            cell.AdjustHeight();
                        }
                    }
                    #endregion
                }

                if (bolRefreshElements)
                    OwnerDocument.RefreshElements();

                OwnerDocument.RefreshLine();
                OwnerDocument.UpdateView();

                //这句以前是被注释掉的，现在也放出来
                myOwnerDocument.Content.SelectLength = 0;
                if (NewStart != null)
                    myOwnerDocument.Content.CurrentElement = NewStart;
                else if (NewIndex >= 0)
                    myOwnerDocument.Content.MoveSelectStart(NewIndex);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 已重载:执行撤销操作
        /// </summary>
        /// <returns></returns>
        public override bool Undo()
        {
            ZYTextElement NewStart = null;
            int NewIndex = -1;
            bool bolRefreshElements = false;

            if (myUndoSteps.Count > 0)
            {
                #region add by myc 2014-08-07 撤销删除单元格内段落时的反色绘制——>避免与全选删除表格发生干扰
                if (Container != null)
                {
                    TPTextTable currTB = null;
                    if (Container is TPTextCell)
                    {
                        currTB = (Container as TPTextCell).OwnerRow.OwnerTable;
                    }
                    else if (Container.Parent is TPTextCell)
                    {
                        currTB = (Container.Parent as TPTextCell).OwnerRow.OwnerTable;
                    }

                    if (currTB != null)
                    {
                        for (int i = 0; i < currTB.AllRows.Count; i++)
                        {
                            for (int j = 0; j < currTB.AllRows[i].Cells.Count; j++)
                            {
                                currTB.ClearSelectedCell(currTB.AllRows[i][j]);
                            }
                        }
                    }
                }
                #endregion


                for (int iCount = myUndoSteps.Count - 1; iCount >= 0; iCount--)
                {
                    UndoStep myStep = (UndoStep)myUndoSteps[iCount];

                    #region bwy 两段合并时会涉及到两个不同的Container
                    //Container = myStep.Element.Parent;
                    #endregion bwy
                    switch (myStep.Style)
                    {
                        case 0:
                            Container = myStep.Element.Parent;
                            bolRefreshElements = true;
                            NewIndex = myStep.Element.Index;
                            Container.ChildElements.Remove(myStep.Element);
                            break;

                        case 1:
                            bolRefreshElements = true;
                            foreach (ZYTextElement e in myStep.Elements)
                            {
                                Container = e.Parent;
                                NewIndex = e.Index;
                                Container.ChildElements.Remove(e);
                            }
                            break;
                        case 2:
                            Container = myStep.Element.Parent;
                            bolRefreshElements = true;
                            NewIndex = myStep.Element.Index;
                            Container.ChildElements.Remove(myStep.Element);
                            break;
                        case 3:
                            Container = myStep.Element.Parent;
                            bolRefreshElements = true;
                            //先从此处控制，索引小于0的不进行操作edit by ywk 2013年3月11日17:31:02 
                            if (myStep.index >= 0)
                            {
                                Container.ChildElements.Insert(myStep.index, myStep.Element);

                                //2021-04-13:表格行删除撤销重做栈时，只删除了ChildElements未删除AllRows导致布局错误，根本原因是设计不合理导致
                                if (Container is TPTextTable && myStep.Element is TPTextRow)
                                {
                                    TPTextTable t = Container as TPTextTable;
                                    TPTextRow r = myStep.Element as TPTextRow;
                                    t.AllRows.Insert(myStep.index, r);
                                }

                                NewStart = myStep.Element;
                            }
                            //Container.ChildElements.Insert(myStep.index, myStep.Element);
                            //NewStart = myStep.Element;
                            break;

                        case 4:

                            myStep.Attribute.SetValue(myStep.OldValue);
                            myStep.Element.UpdateAttrubute();
                            myStep.Element.RefreshSize();
                            NewStart = myStep.Element;
                            break;
                        case 5:

                            bolRefreshElements = true;
                            foreach (ZYTextElement e in myStep.Elements)
                            {
                                Container = e.Parent;
                                NewIndex = e.Index;
                                Container.ChildElements.Remove(e);
                            }
                            break;

                        case 6:
                            if (myStep.Elements == null) break; //add by myc 2014-06-12 注释原因：特殊情况下删除回车符时，根本就不允许删除，但是也应该记录此动作

                            Container = (myStep.Elements[0] as ZYTextElement).Parent;
                            bolRefreshElements = true;
                            //索引需大于等于0才进入  add by ywk 2013年4月2日16:16:48 
                            if (myStep.index >= 0)
                            {
                                Container.ChildElements.InsertRange(myStep.index, myStep.Elements);
                                NewIndex = myStep.index;
                            }


                            #region add by myc 2014-08-07 撤销删除单元格内段落时的反色绘制
                            if (Container is TPTextCell)
                            {
                                //TPTextTable currTB = (Container as TPTextCell).OwnerRow.OwnerTable;
                                //for (int i = 0; i < currTB.AllRows.Count; i++)
                                //{
                                //    for (int j = 0; j < currTB.AllRows[i].Cells.Count; j++)
                                //    {
                                //        currTB.ClearSelectedCell(currTB.AllRows[i][j]);
                                //    }
                                //}
                                (Container as TPTextCell).Selected = myStep.Selected;
                            }
                            else if (Container.Parent is TPTextCell)
                            {
                                //TPTextTable currTB = (Container.Parent as TPTextCell).OwnerRow.OwnerTable;
                                //for (int i = 0; i < currTB.AllRows.Count; i++)
                                //{
                                //    for (int j = 0; j < currTB.AllRows[i].Cells.Count; j++)
                                //    {
                                //        currTB.ClearSelectedCell(currTB.AllRows[i][j]);
                                //    }
                                //}
                                (Container.Parent as TPTextCell).Selected = myStep.Selected;
                            }
                            #endregion


                            break;

                        #region 2019.7.31-hdf：添加修改对象属性、字段撤销重做功能
                        case 7:
                            bolRefreshElements = true;
                            System.Reflection.PropertyInfo property = myStep.ClassMember as System.Reflection.PropertyInfo;
                            property.SetValue(myStep.Element, myStep.OldValue, null);
                            myStep.Element.RefreshSize();
                            NewStart = myStep.Element;
                            break;
                        case 8:
                            bolRefreshElements = true;
                            System.Reflection.FieldInfo field = myStep.ClassMember as System.Reflection.FieldInfo;
                            field.SetValue(myStep.Element, myStep.OldValue);
                            myStep.Element.RefreshSize();
                            NewStart = myStep.Element;
                            break;
                        #endregion
                    }



                    #region add by myc 2014-05-22 撤销单元格内插入、删除、复制、粘贴、剪切等操作时的单元格自适应高度调整
                    //if (myStep.Element != null) //撤销插入或删除单个元素
                    //{
                    //    if (myStep.Element.Parent is TPTextCell) //如果Element为段落元素，则父亲层次容器即有可能为单元格
                    //    {
                    //        (myStep.Element.Parent as TPTextCell).AdjustHeight();
                    //    }
                    //    else if (myStep.Element.Parent != null) //必须检查是否为空引用
                    //    {
                    //        if (myStep.Element.Parent.Parent is TPTextCell) //第一次检查Element的祖父层次容器
                    //        {
                    //            (myStep.Element.Parent.Parent as TPTextCell).AdjustHeight();
                    //        }
                    //    }
                    //    else if (myStep.Element.Parent.Parent != null) //必须检查是否为空引用
                    //    {
                    //        if (myStep.Element.Parent.Parent.Parent is TPTextCell) //第一次检查Element的祖父层次容器
                    //        {
                    //            (myStep.Element.Parent.Parent.Parent as TPTextCell).AdjustHeight();
                    //        }
                    //    }
                    //}
                    //else if (myStep.Elements != null)//撤销复制、粘贴、剪切多个元素
                    //{
                    //    ZYTextElement myEle = myStep.Elements[0] as ZYTextElement;
                    //    if (myEle.Parent is TPTextCell) //如果myEle为段落元素，则父亲层次容器即有可能为单元格
                    //    {
                    //        (myEle.Parent as TPTextCell).AdjustHeight();
                    //    }
                    //    else if (myEle.Parent != null) //必须检查是否为空引用
                    //    {
                    //        if (myEle.Parent.Parent is TPTextCell) //第一次检查myEle的祖父层次容器
                    //        {
                    //            (myEle.Parent.Parent as TPTextCell).AdjustHeight();
                    //        }
                    //    }
                    //    else if (myEle.Parent.Parent != null) //必须检查是否为空引用
                    //    {
                    //        if (myEle.Parent.Parent.Parent is TPTextCell) //第一次检查myEle的祖父层次容器
                    //        {
                    //            (myEle.Parent.Parent.Parent as TPTextCell).AdjustHeight();
                    //        }
                    //    }
                    //}

                    //2014-08-15 新版撤销操作时的单元格自适应高度
                    if (myStep.Element != null)
                    {
                        TPTextCell cell = myOwnerDocument.GetOwnerCell(myStep.Element);
                        if (cell != null)
                        {
                            cell.AdjustHeight();
                        }
                    }
                    else if (myStep.Elements != null)
                    {
                        TPTextCell cell = myOwnerDocument.GetOwnerCell(myStep.Elements[0] as ZYTextElement);
                        if (cell != null)
                        {
                            cell.AdjustHeight();
                        }
                    }
                    #endregion
                }

                if (bolRefreshElements)
                    myOwnerDocument.RefreshElements();


                #region add by myc 2014-05-26 注释原因：此段检查代码确保编辑器文档中至少有一个回车符，用于输入元素
                ////如果文档中一个段都没有了，需要new一个新段，加入文档中，否则，无法输入
                //if (this.OwnerDocument.RootDocumentElement.ChildCount == 0)
                //{
                //    ZYTextParagraph myP = new ZYTextParagraph();
                //    myP.OwnerDocument = this.OwnerDocument;
                //    this.OwnerDocument.RootDocumentElement.ChildElements.Add(myP);
                //    myP.Parent = this.OwnerDocument.RootDocumentElement;
                //    this.OwnerDocument.RefreshElements();
                //    this.OwnerDocument.RefreshSize();
                //    //this.OwnerDocument.Content.InsertParagraph(myP);
                //}
                #endregion

                myOwnerDocument.RefreshLine();
                myOwnerDocument.UpdateView();

                #region bwy 以前是被注释的，现在放出来
                //myOwnerDocument.Content.SelectLength = 0;
                //if (NewStart != null)
                //    myOwnerDocument.Content.CurrentElement = NewStart;
                //else if (NewIndex >= 0)
                //    myOwnerDocument.Content.MoveSelectStart(NewIndex); //add by myc 2014-06-23 注释原因：此段代码在撤销删除选定元素时的光标移动操作不正确，会出现光标跳动闪烁
                #endregion bwy



                return true;
            }
            return false;
        }

        /// <summary>
        /// 已重载:本对象可以撤销
        /// </summary>
        /// <returns></returns>
        public override bool isUndoable()
        {
            return true;
        }
        /// <summary>
        /// 已重载:对象名称为 strUndoName 值
        /// </summary>
        /// <returns></returns>
        public override string UndoName()
        {
            return strUndoName;
        }

        /// <summary>
        /// 已重载:将自己添加到文档对象的撤销对象列表中
        /// </summary>
        /// <returns></returns>
        public override ZYEditorAction Clone()
        {
            return this;
        }
    }// class A_ContentChangeLog
}