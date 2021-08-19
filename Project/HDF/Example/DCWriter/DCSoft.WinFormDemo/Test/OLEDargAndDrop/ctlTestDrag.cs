using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.WinForms.Design;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Commands;
using DCSoft.Design;

namespace DCSoft.Writer.WinFormDemo.Test.OLEDargAndDrop
{
    [ToolboxItem(false)]
    public partial class ctlTestDrag : UserControl
    {
        public ctlTestDrag()
        {
            InitializeComponent();
        }

        private void frmTestDrag_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            TreeNode rootNode = new TreeNode("特殊字符");
            tvwData.Nodes.Add(rootNode);

            rootNode.Nodes.Add("Ⅰ");
            rootNode.Nodes.Add("Ⅱ");
            rootNode.Nodes.Add("Ⅲ");
            rootNode.Nodes.Add("Ⅳ");
            rootNode.Nodes.Add("Ⅴ");
            rootNode.Nodes.Add("Ⅵ");
            rootNode.Nodes.Add("Ⅶ");
            rootNode.Nodes.Add("Ⅷ");
            rootNode.Nodes.Add("Ⅸ");
            rootNode.Nodes.Add("Ⅹ");
            rootNode.Nodes.Add("α");
            rootNode.Nodes.Add("β");
            rootNode.Nodes.Add("℃");
            rootNode.Nodes.Add("㎎");
            rootNode.Nodes.Add("㎏");
            rootNode.Nodes.Add("㎜");
            rootNode.Nodes.Add("㎝");
            rootNode.Nodes.Add("㎡");
            rootNode.Nodes.Add("㎞");
            rootNode.Nodes.Add("％");
            rootNode.Nodes.Add("‰");
            rootNode.Nodes.Add("±");
            rootNode.Nodes.Add("≈");
            rootNode.Nodes.Add("≠");
            rootNode.Nodes.Add("≤");
            rootNode.Nodes.Add("≥");
            rootNode.Nodes.Add("＋");
            rootNode.Nodes.Add("－");
            rootNode.Nodes.Add("×");
            rootNode.Nodes.Add("÷");
            rootNode.Nodes.Add("∧");
            rootNode.Nodes.Add("∨");
            rootNode.Nodes.Add("√");
            rootNode.Nodes.Add("∑");
            rootNode.Nodes.Add("￥");
            rootNode.Nodes.Add("｛");
            rootNode.Nodes.Add("〖");
            rootNode.Nodes.Add("【");
            rootNode.Nodes.Add("＃");
            rootNode.Nodes.Add("※");
            rootNode.Nodes.Add("○");
            rootNode.Nodes.Add("◎");
            rootNode.Nodes.Add("□");
            rootNode.Nodes.Add("×");
            rootNode.Nodes.Add("÷");
            rootNode.Nodes.Add("№");
            rootNode.Nodes.Add("＄");
            rootNode.Nodes.Add("￥");
            rootNode.Nodes.Add("§");
            rootNode.Nodes.Add("～");
            rootNode.Nodes.Add("】");
            rootNode.Nodes.Add("〗");
            rootNode.Nodes.Add("｝");

            rootNode = new TreeNode("图形");
            tvwData.Nodes.Add(rootNode);

            foreach (System.Reflection.Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                HostComponentTypeInfoLoader loader = new HostComponentTypeInfoLoader();
                loader.SupportDocumentImage = true;
                loader.SupportWinFormControl = false;
                loader.SupportWPF = false;
                ComponentTypeInfo[] infos = loader.Load(asm);
                if (infos != null && infos.Length > 0)
                {
                    foreach (ComponentTypeInfo info in infos)
                    {
                        TreeNode node = new TreeNode(info.FullName );
                        rootNode.Nodes.Add(node);
                    }
                }
            }

            rootNode = new TreeNode("文档元素");
            tvwData.Nodes.Add(rootNode);

            rootNode.Nodes.Add("InputField");
            rootNode.Nodes.Add("Date");
        }


        private void tvwData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeViewHitTestInfo info = this.tvwData.HitTest(e.X, e.Y);
                if (info != null 
                    && info.Node != null 
                    && info.Location == TreeViewHitTestLocations.Label
                    && info.Node.Parent != null )
                {
                    this.tvwData.SelectedNode = info.Node;
                    // 获得数据类型
                    string type = info.Node.Parent.Text;
                    DataObject obj = new DataObject();
                    // 设置数据
                    obj.SetData(type, info.Node.Text);
                    // 开始拖拽数据
                    tvwData.DoDragDrop(obj, DragDropEffects.Copy);
                }
            }
        }
         
        private void myWriterControl_EventCanInsertObject(object sender, CanInsertObjectEventArgs args)
        {
            if( args.DataObject.GetDataPresent("特殊字符")
                || args.DataObject.GetDataPresent("图形")
                || args.DataObject.GetDataPresent("文档元素"))
            {
                args.Result = true ;
            }
        }

        private void myWriterControl_EventInsertObject(object sender, InsertObjectEventArgs args)
        {
            if (args.DataObject.GetDataPresent("特殊字符"))
            {
                // 拖拽了特殊字符
                string txt = Convert.ToString(args.DataObject.GetData("特殊字符"));
                if (string.IsNullOrEmpty(txt) == false)
                {
                    myWriterControl.ExecuteCommand("InsertString", false, txt);
                }
                args.Result = true;
            }
            else if (args.DataObject.GetDataPresent("图形"))
            {
                // 拖拽了图形
                string typeName = Convert.ToString(args.DataObject.GetData("图形"));
                if (string.IsNullOrEmpty(typeName) == false)
                {
                    myWriterControl.ExecuteCommand("InsertControlHost", false, typeName);
                }
                args.Result = true;
            }
            else if (args.DataObject.GetDataPresent("文档元素"))
            {
                // 拖拽了元素
                string name = Convert.ToString(args.DataObject.GetData("文档元素"));
                if (string.IsNullOrEmpty(name) == false)
                {
                    switch (name)
                    {
                        case "InputField":
                            {
                                XTextInputFieldElement field = new XTextInputFieldElement();
                                field.BackgroundText = "文本框";
                                field.StartBorderText = "【";
                                field.EndBorderText = "】";
                                field.ID = "field1";
                                myWriterControl.ExecuteCommand("InsertInputField", false, field);
                            }
                            break;
                        case "Date":
                            {
                                // 插入时间日期
                                myWriterControl.ExecuteCommand("InsertString", false, DateTime.Now.ToLongDateString());
                            }
                            break;
                    }
                }
                args.Result = true;
            }
        }

    }
}
