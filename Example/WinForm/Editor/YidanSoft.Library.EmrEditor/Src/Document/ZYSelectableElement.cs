using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using YidanSoft.Library.EmrEditor.Src.Gui;
using System.Windows.Forms;
using System.Diagnostics;
using YidanSoft.Library.EmrEditor.Src.Common;
using System.Xml;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYSelectableElement : ZYTextBlock
    {
        public ZYSelectableElement()
        {
            //for (int i = 0; i < items.Length; i++)
            //{
            //    ZYSelectableElementItem selectItem = new ZYSelectableElementItem();
            //    selectItem.Parent = this;
            //    if (flag.Contains(i))
            //    {
            //        selectItem.IsSelected = true;
            //    }

            //    for (int j = 0; j < items[i].Length; j++)
            //    {
            //        ZYTextChar newChar = ZYTextChar.Create(items[i][j]);
            //        newChar.UpdateAttrubute();
            //        selectItem.ChildElements.Add(newChar);
            //    }
            //    myList.Add(selectItem);
            //}
            //this.Name = name;
        }

        public ZYSelectableElement(ElementType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        public ZYSelectableElementItem this[int index]
        {
            get { return this.myList[index]; }
        }

        /// <summary>
        /// 包含的项目列表
        /// </summary>
        List<ZYSelectableElementItem> myList = new List<ZYSelectableElementItem>();

        public List<ZYSelectableElementItem> SelectList
        {
            get { return myList; }
            set { myList = value;
            this.Text = this.Name;
            //this.UpDateText();
            }
        }

        public string[] Items
        {
            get
            {
                string[] temp = new string[myList.Count];
                int i = 0;
                foreach (ZYSelectableElementItem selectItem in myList)
                {
                    temp[i++] = selectItem.InnerValue;
                }
                return temp;
            }
            set
            {
                this.myList.Clear();
                for (int i = 0; i < value.Length; i++)
                {
                    ZYSelectableElementItem tempItem = new ZYSelectableElementItem();
                    tempItem.InnerValue = value[i];
                    tempItem.Parent = this;
                    tempItem.OwnerDocument = this.OwnerDocument;
                    this.myList.Add(tempItem);
                }

            }
        }

        public override string Text
        {
            get
            {
                string strText = "";

                if (this.Type == ElementType.SingleElement)
                {
                    foreach (ZYSelectableElementItem selectItem in myList)
                    {
                        if (selectItem.IsSelected == true)
                        {
                            strText = selectItem.InnerValue;
                        }
                    }
                }
                if (this.Type == ElementType.MultiElement)
                {
                    foreach (ZYSelectableElementItem selectItem in myList)
                    {
                        if (selectItem.IsSelected == true)
                        {
                            strText += ImplementFrm.ParseListViewItem(selectItem.InnerValue,null).Text + "、";
                            //strText += (selectItem.InnerValue + "；");
                        }
                    }
                    if (strText.Length > 0)
                    {
                        strText = strText.Substring(0, strText.Length - 1);
                    }
                }
                if (this.Type == ElementType.HaveNotElement)
                {
                    string strHaveText = "";
                    string strNoText = "";

                    foreach (ZYSelectableElementItem selectItem in myList)
                    {
                        if (selectItem.IsSelected == true)
                        {
                            strHaveText += (selectItem.InnerValue + "、");
                        }
                        else
                        {
                            strNoText += (selectItem.InnerValue + "、");
                        }
                    }
                    if (strHaveText.Length > 0)
                    {
                        strHaveText = this.Prifix + strHaveText.Substring(0, strHaveText.Length - 1);
                    }

                    if (strNoText.Length > 0)
                    {
                        strNoText = this.Postfix + strNoText.Substring(0, strNoText.Length - 1);
                    }

                    if (strHaveText.Length > 0 && strNoText.Length > 0)
                    {
                        strText = strHaveText + "," + strNoText;
                    }
                    else
                    {
                        strText = strHaveText + strNoText;
                    }

                }
                return strText;
            }
        }


        public override string GetXMLName()
        {
            return ZYTextConst.c_Selement;
        }
        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                base.FromXML(myElement);
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Attributes.FromXML(myElement);
                this.Name = myElement.GetAttribute("name");
                this.text = myElement.GetAttribute("text");

                //新增加的属性，为了兼容以前格式
                if (this.Type == ElementType.HaveNotElement)
                {
                    if (myElement.HasAttribute("prifix"))
                    {
                        this.Prifix = myElement.GetAttribute("prifix");
                    }
                    else
                    {
                        this.Prifix = "有";
                    }

                    if (myElement.HasAttribute("postfix"))
                    {
                        this.Postfix = myElement.GetAttribute("postfix");
                    }
                    else
                    {
                        this.Postfix = "无";
                    }

                }

                this.myList.Clear();

                for (int i = 0; i < myElement.ChildNodes.Count; i++)
                {
                    if (myElement.ChildNodes.Item(i).Name == "item")
                    {
                        //string selected = (myElement.ChildNodes.Item(i) as XmlElement).GetAttribute("selected");
                        //bool isSelected = Convert.ToBoolean(selected);//(selected != "") ? true : false;

                        ZYSelectableElementItem eleItem = new ZYSelectableElementItem();

                        //eleItem.InnerValue = myElement.ChildNodes.Item(i).InnerText;
                        //eleItem.IsSelected = isSelected;
                        //eleItem.Code =

                        //eleItem.Parent = this;
                        //eleItem.OwnerDocument = this.OwnerDocument;

                        eleItem.FromXML(myElement.ChildNodes.Item(i) as XmlElement);
                        this.myList.Add(eleItem);
                    }
                }
                
                UpDateText();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 用于判断是显示名称，还是显示内容.在显示的内容发生改变时，都应该调用它。
        /// </summary>
        public void UpDateText()
        {
            if (this.text.Length == 0)
            {
                this.Text = this.Name;
            }
            else
            {
                //this.Text = this.Text; //有意义，用于触发Text的set事件，不能去掉
                this.Text = this.text;
            }


        }

        public string Prifix = "有";
        public string Postfix = "无";

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                base.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));
                myElement.SetAttribute("name", this.Name);
                if (this.Type == ElementType.HaveNotElement)
                {
                    myElement.SetAttribute("prifix", this.Prifix);
                    myElement.SetAttribute("postfix", this.Postfix);
                }

                myElement.SetAttribute("text", this.text);



                foreach (ZYSelectableElementItem eleItem in this.myList)
                {
                    XmlElement item = myElement.OwnerDocument.CreateElement(eleItem.GetXMLName());
                    myElement.AppendChild(item);
                    eleItem.ToXML(item);
                }
                return true;
            }
            return false;
        }
    }

    public class ZYSelectableElementItem : ZYTextBlock
    {

        //是否是选择的项
        bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public string Code = "";
        public string Group = "";

        //包含的文本字符串
        public string InnerValue
        {
            get
            {
                string str = "";
                foreach (ZYTextElement element in this.ChildElements)
                {
                    if (element is ZYTextChar)
                    {
                        str += (element as ZYTextChar).Char.ToString();
                    }
                }
                return str;
            }
            set
            {
                for (int j = 0; j < value.Length; j++)
                {
                    ZYTextChar c = new ZYTextChar();
                    c.Char = value[j];
                    c.Parent = this;
                    //ZYTextChar defChar = this.OwnerDocument.Content.GetPreChar();
                    //if (defChar != null)
                    //{
                    //    defChar.Attributes.CopyTo(c.Attributes);
                    //    c.UpdateAttrubute();
                    //}
                    this.ChildElements.Add(c);
                }
            }
        }

        public override string GetXMLName()
        {
            return "item";
        }
        public override bool FromXML(XmlElement myElement)
        {
            this.IsSelected = Convert.ToBoolean(myElement.GetAttribute("selected"));
            this.Code = myElement.GetAttribute("code");
            this.Group = myElement.GetAttribute("group");
            this.InnerValue = myElement.InnerText;

            return true;
            //return base.FromXML(myElement);
        }
        public override bool ToXML(XmlElement myElement)
        {
            myElement.SetAttribute("selected", (this.IsSelected ? "true" : "false"));
            myElement.SetAttribute("code", this.Code);
            myElement.SetAttribute("group", this.Group);

            myElement.InnerText = this.InnerValue;

            return true;
            //return base.ToXML(myElement);
        }

    }
}
