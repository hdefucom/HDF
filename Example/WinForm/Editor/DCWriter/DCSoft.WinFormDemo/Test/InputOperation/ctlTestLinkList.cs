using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Expression;
using System.Xml;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestLinkList : UserControl
    {
        public ctlTestLinkList()
        {
            InitializeComponent();
        }


        private void frmTestChangeTable_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnInsertLinkList_Click(object sender, EventArgs e)
        {
            string providerName = "省市县联动";
            // 添加基于XML文件的联动列表数据提供者
            myWriterControl.AddXMLLinkListProvider(
                providerName,
                System.IO.Path.Combine(
                    Application.StartupPath,
                    "DemoFile\\省市县联动.xml"));
            // ------- 以下是复杂的做法 ----------------
            //XMLLinkListProvider p = new XMLLinkListProvider();
            //p.Name = providerName;
            //p.LoadXMLDocument(System.IO.Path.Combine(
            //    Application.StartupPath,
            //    "DemoFile\\省市县联动.xml"));
            //myWriterControl.AppHost.LinkListProviders.Add(p);
            //-------------------------------------------

            // 添加省级列表
            XTextElementList list = new XTextElementList();
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.LinkListBinding = new LinkListBindingInfo();
            field.LinkListBinding.ProviderName = providerName;
            // 表示绑定根节点
            field.LinkListBinding.IsRoot = true;
            // 表示下层列表就是下一个输入域
            field.LinkListBinding.NextTarget = EventExpressionTarget.NextElement;
            field.BackgroundText = "省";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            list.Add(field);
            // 添加市级列表
            field = new XTextInputFieldElement();
            field.LinkListBinding = new LinkListBindingInfo();
            field.LinkListBinding.ProviderName = providerName;
            field.LinkListBinding.IsRoot = false;
            field.LinkListBinding.NextTarget = EventExpressionTarget.NextElement;
            // 更新列表内容后自动设置为第一个列表项目为当前项目
            field.LinkListBinding.AutoSetFirstItems = true;
            field.BackgroundText = "市";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            list.Add(field);
            // 添加县级列表
            field = new XTextInputFieldElement();
            field.LinkListBinding = new LinkListBindingInfo();
            field.LinkListBinding.ProviderName = providerName;
            field.LinkListBinding.IsRoot = false;
            // 没有下一个联动列表，联动结束。
            field.LinkListBinding.NextTarget = EventExpressionTarget.None;
            // 更新列表内容后自动设置为第一个列表项目为当前项目
            field.LinkListBinding.AutoSetFirstItems = true;
            field.BackgroundText = "县";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            list.Add(field);

            myWriterControl.ExecuteCommand(StandardCommandNames.InsertElements, false, list);
        }


        private bool _BindingEvent = false;

        private void btnUseEvent_Click(object sender, EventArgs e)
        {
            if (this._BindingEvent == false)
            {
                // 使用一个变量来防止重复绑定事件
                this._BindingEvent = true;
                myWriterControl.EventGetLinkListItems += new GetLinkListItemsEventHandler(
                    myWriterControl_EventGetLinkListItems);
            }

            string providerName = "事件中获得联动列表内容";
            // 添加省级列表
            XTextElementList list = new XTextElementList();
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.LinkListBinding = new LinkListBindingInfo();
            field.LinkListBinding.ProviderName = providerName;
            // 表示绑定根节点
            field.LinkListBinding.IsRoot = true;
            // 表示下层列表就是下一个输入域
            field.LinkListBinding.NextTarget = EventExpressionTarget.NextElement;
            field.BackgroundText = "省";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            list.Add(field);
            // 添加市级列表
            field = new XTextInputFieldElement();
            field.LinkListBinding = new LinkListBindingInfo();
            field.LinkListBinding.ProviderName = providerName;
            field.LinkListBinding.IsRoot = false;
            field.LinkListBinding.NextTarget = EventExpressionTarget.NextElement;
            // 更新列表内容后自动设置为第一个列表项目为当前项目
            field.LinkListBinding.AutoSetFirstItems = true;
            field.BackgroundText = "市";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            list.Add(field);
            // 添加县级列表
            field = new XTextInputFieldElement();
            field.LinkListBinding = new LinkListBindingInfo();
            field.LinkListBinding.ProviderName = providerName;
            field.LinkListBinding.IsRoot = false;
            // 没有下一个联动列表，联动结束。
            field.LinkListBinding.NextTarget = EventExpressionTarget.None;
            // 更新列表内容后自动设置为第一个列表项目为当前项目
            field.LinkListBinding.AutoSetFirstItems = true;
            field.BackgroundText = "县";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            list.Add(field);

            myWriterControl.ExecuteCommand(StandardCommandNames.InsertElements, false, list);

        }

        private System.Xml.XmlDocument xmlDoc = null;

        void myWriterControl_EventGetLinkListItems(object eventSender, GetLinkListItemsEventArgs args)
        {
            if (xmlDoc == null)
            {
                xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(System.IO.Path.Combine(
                    Application.StartupPath,
                    "DemoFile\\省市县联动.xml"));
            }
            if (args.ProviderName == "事件中获得联动列表内容")
            {
                // 设置Handled，表示该事件处理了，无需编辑器内部继续处理。
                args.Handled = true;
                args.Items = new ListItemCollection();
                string parentTextList = args.ParentTextList;
                XmlNode rootNode = null;
                if (string.IsNullOrEmpty(parentTextList) )
                {
                    // 上级文本为空，表示为级联列表中的第一个列表
                    rootNode = xmlDoc.DocumentElement;
                }
                else
                {
                    // 上级文本不为空。比如“江苏省,南京市”，各级文本之间用逗号分开。
                    System.Diagnostics.Debug.WriteLine("上级文本为:" + parentTextList);
                    // 进行拆分
                    string[] items = parentTextList.Split(',');
                    // 查找根节点
                    string strPath = null;
                    if (items.Length == 1)
                    {
                        strPath = "province[@Text='" + items[0] + "']";//比如 province[@Text='江苏省']
                    }
                    else if (items.Length == 2)
                    {
                        strPath = "province[@Text='" + items[0] + "']/city[@Text='" + items[1] + "']";//比如 province[@Text='江苏省']/city[@Text='南京市']
                    }
                    rootNode = xmlDoc.DocumentElement.SelectSingleNode(strPath);
                }
                if (rootNode != null)
                {
                    // 找到XML根节点，添加列表元素
                    foreach (XmlNode node in rootNode.ChildNodes )
                    {
                        if (node is XmlElement)
                        {
                            XmlElement xe = (XmlElement)node;
                            ListItem item = new ListItem();
                            item.Text = xe.GetAttribute("Text");
                            item.Value = xe.GetAttribute("Text");
                            args.Items.AddByTextValue(
                                xe.GetAttribute("Text"),
                                xe.GetAttribute("Text"));
                        }
                    }//foreach
                }//if

            }//if
        }
    }
}
