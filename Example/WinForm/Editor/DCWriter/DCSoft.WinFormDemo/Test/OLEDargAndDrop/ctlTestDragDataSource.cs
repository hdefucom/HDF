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
    public partial class ctlTestDragDataSource : UserControl
    {
        public ctlTestDragDataSource()
        {
            InitializeComponent();
        }

        private void frmTestDrag_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            // 加载数据源树状列表
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(DCDataSourceDescriptor));
            DCDataSourceDescriptor datasource = (DCDataSourceDescriptor)ser.Deserialize(
                this.GetType().Assembly.GetManifestResourceStream(
                "DCSoft.Writer.WinFormDemo.Test.DCDataSourceDescriptor.xml"));
            TreeNode rootNode = tvwData.Nodes.Add("数据源");
            FillNodes(rootNode, datasource);
            tvwData.ExpandAll();
        }

        private void FillNodes(TreeNode rootNode, DCDataSourceDescriptor ds)
        {
            rootNode.Tag = ds;
            rootNode.Text = ds.Name;
            if (ds.ChildDescriptors != null && ds.ChildDescriptors.Count > 0)
            {
                foreach (DCDataSourceDescriptor subDs in ds.ChildDescriptors)
                {
                    TreeNode node2 = new TreeNode();
                    FillNodes(node2, subDs);
                    rootNode.Nodes.Add(node2);
                }
            }

        }

        private void tvwData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeViewHitTestInfo info = this.tvwData.HitTest(e.X, e.Y);
                if (info != null
                    && info.Node != null
                    && info.Location == TreeViewHitTestLocations.Label
                    && info.Node.Parent != null)
                {
                    this.tvwData.SelectedNode = info.Node;
                    DataObject obj = new DataObject();
                    // 设置数据
                    obj.SetData("datasource", info.Node.Tag);
                    // 开始拖拽数据
                    tvwData.DoDragDrop(obj, DragDropEffects.Copy);
                }
            }
        }

        private void myWriterControl_EventCanInsertObject(object sender, CanInsertObjectEventArgs args)
        {
            args.Result = true;
        }

        private void myWriterControl_EventInsertObject(object sender, InsertObjectEventArgs args)
        {
            if (args.DataObject.GetDataPresent("datasource"))
            {
                DCDataSourceDescriptor ds = (DCDataSourceDescriptor)args.DataObject.GetData("datasource");
                if (ds != null)
                {
                    // 根据拖拽的数据创建一个输入域对象
                    XTextInputFieldElement field = new XTextInputFieldElement();
                    field.UserEditable = ds.UserEditable;
                    field.FieldSettings = new InputFieldSettings();
                    field.FieldSettings.EditStyle = ds.EditStyle;
                    field.ValueBinding = ds.ValueBinding;
                    field.ContentReadonly = ds.Readonly ? ContentReadonlyState.True : ContentReadonlyState.Inherit;
                    field.BackgroundText = ds.BackgroundText;
                    field.Name = ds.Name;
                    field.FieldSettings.ListSource = ds.ListSource;
                    field.ValidateStyle = ds.ValidateStyle;
                    field.DisplayFormat = ds.DisplayFormat;
                    field.BackgroundText = ds.BackgroundText;
                    field.ToolTip = ds.Description;
                    // 将输入域插入到文档中
                    myWriterControl.ExecuteCommand("InsertInputField", false, field);
                    args.Result = true;
                }
            }
        }
    }
}