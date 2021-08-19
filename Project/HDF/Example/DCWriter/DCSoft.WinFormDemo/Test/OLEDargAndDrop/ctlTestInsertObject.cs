using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Commands;
using DCSoft.Design;
using DCSoft.Writer.Extension.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.OLEDargAndDrop
{
    [ToolboxItem(false)]
    public partial class ctlTestInsertObject : UserControl
    {
        public ctlTestInsertObject()
        {
            InitializeComponent();
        }

        private DataSourceTreeViewControler dsControler = null;

        /// <summary>
        /// 窗体加载时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTestInsertObject_Load(object sender, EventArgs e)
        {
            dsControler = new DataSourceTreeViewControler(this.tvwDataSource);
            tvwDataSource.MouseDown += new MouseEventHandler(dsControler.HandleTreeViewMouseDown);
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            RefreshDataSourceList();
            RefreshControlTreeView();
            RefreshKBTreeView();
        }

        private void RefreshKBTreeView()
        {
            string fileName = System.IO.Path.Combine(Application.StartupPath, "kblibrary.xml");
            if (System.IO.File.Exists(fileName))
            {
                KBLibrary lib = ( KBLibrary ) myWriterControl.ExecuteCommand(
                    "LoadKBLibrary",
                    false,
                    fileName);
                if (lib != null)
                {
                    lib.Fill(tvwKBEntry);
                }
            }
        }

        /// <summary>
        /// 填充控件树状列表
        /// </summary>
        private void RefreshControlTreeView()
        {
            ComponentTypeControler ctl = new ComponentTypeControler();
            ctl.BrowseType = ComponentTypeBrowseTypes.ForControlHost;
            ctl.FillTreeView(tvwControl, null);

            //tvwControl.Nodes.Clear();
            //foreach (System.Reflection.Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    HostComponentTypeInfoLoader loader = new HostComponentTypeInfoLoader();
            //    ComponentTypeInfo[] infos = loader.Load(asm);
            //    if (infos != null && infos.Length > 0)
            //    {
            //        TreeNode asmNode = new TreeNode(asm.GetName().Name);
            //        asmNode.ImageIndex = 0;
            //        asmNode.SelectedImageIndex = 0;
            //        tvwControl.Nodes.Add(asmNode);
            //        ComponentTypeInfoLoader.Fill(asmNode, infos);
            //    }
            //}
        }

        /// <summary>
        /// 填充数据源列表
        /// </summary>
        private void RefreshDataSourceList()
        {
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                "DataSourceDescriptor.xml");
            //tvwDataSource.BeginUpdate();
            //tvwDataSource.Nodes.Clear();
            if (System.IO.File.Exists(fileName))
            {
                dsControler.LoadFile(fileName);
            }
            //tvwDataSource.EndUpdate();
        }

        /// <summary>
        /// 知识库树状列表鼠标按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwKBEntry_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeViewHitTestInfo info = tvwKBEntry.HitTest(e.X, e.Y);

                if ((info.Location == TreeViewHitTestLocations.Image
                        || info.Location == TreeViewHitTestLocations.Label)
                    && info.Node != null && info.Node.Tag is KBEntry )
                {
                    tvwKBEntry.SelectedNode = info.Node;
                    if (DesignerUtils.DragDetect(tvwKBEntry.Handle))
                    {
                        tvwKBEntry.DoDragDrop(info.Node.Tag, DragDropEffects.Copy);
                    }
                }
            }
        }

        /// <summary>
        /// 控件树状列表鼠标按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeViewHitTestInfo info = tvwControl.HitTest(e.X, e.Y);

                if ((info.Location == TreeViewHitTestLocations.Image
                        || info.Location == TreeViewHitTestLocations.Label)
                    && info.Node != null && info.Node.Tag is ComponentTypeInfo)
                {
                    tvwControl.SelectedNode = info.Node;
                    if (DesignerUtils.DragDetect(tvwControl.Handle))
                    {
                        tvwControl.DoDragDrop(info.Node.Tag, DragDropEffects.Copy);
                    }
                }
            }
        }
         
        /// <summary>
        /// 处理判断能否向编辑器插入对象的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_EventCanInsertObject(
            object sender,
            CanInsertObjectEventArgs args)
        {
            if (string.IsNullOrEmpty(args.SpecifyFormat))
            {
                if (GetSupportInstance(args.DataObject) != null)
                {
                    args.Result = true;
                    return;
                }
            }
            args.Result = false;
        }

        /// <summary>
        /// 处理向编辑器插入对象的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_EventInsertObject(
            object sender,
            InsertObjectEventArgs args)
        {
            object v = GetSupportInstance(args.DataObject);
            if (v is DataSourceDescriptor)
            {
                DataSourceDescriptor p = (DataSourceDescriptor)v;
                // 根据属性说明在创建一个文本输入域原始
                XTextInputFieldElement field = new XTextInputFieldElement();
                field.BackgroundText = p.BackgroundText;
                field.Name = p.Name;
                field.AcceptChildElementTypes2 = ElementType.Text;
                field.ToolTip = p.Description;
                field.ContentReadonly = p.Readonly ? ContentReadonlyState.True : ContentReadonlyState.Inherit;
                field.ValueBinding = p.ValueBinding;
                field.DisplayFormat = p.DisplayFormat;
                field.FieldSettings = new InputFieldSettings();
                field.FieldSettings.EditStyle = p.EditStyle;
                field.FieldSettings.ListSource = p.ListSource;
                field.ValidateStyle = p.ValidateStyle ;
                field.UserEditable = p.UserEditable;
                field.Attributes = new XAttributeList();
                field.Attributes.SetValue("TableName", "records");
                // 将输入域对象插入到文档当前位置
                this.myWriterControl.ExecuteCommand(
                    "InsertInputField",
                    false,
                    field);
                args.Result = true;
                args.Handled = true;
                return;
            }
            else if (v is ComponentTypeInfo)
            {
                ComponentTypeInfo info = (ComponentTypeInfo)v;
                // 调用InsertControlHost命令
                object result = this.myWriterControl.ExecuteCommand(
                    "InsertControlHost",
                    false,
                    info.FullName);
                args.Result = result != null;
                args.Handled = true;
                return;
            }
            else if (v is KBEntry)
            {
                /*
                 * 
----------------------------- 自定义处理知识库节点 -----------------------------
                 * 
                 * */
                // 遇到知识库节点，则进行有条件的判断处理
                KBEntry entry = (KBEntry)v;
                if (entry.Style == KBEntryStyle.ListSQL || entry.Style == KBEntryStyle.List)
                {
                    // 如果是下拉列表的知识库节点则进行处理
                    IKBProvider kp = (IKBProvider)this.myWriterControl.AppHost.Services.GetService(typeof(IKBProvider));
                    if (kp != null)
                    {
                        // 使用系统配置的知识库提供者对象根据知识库节点创建文档元素对象
                        CreateElementsByKBEntryEventArgs args2 = new CreateElementsByKBEntryEventArgs(
                            this.myWriterControl.Document, 
                            entry,
                            InputValueSource.UI);
                        kp.CreateElements(args2);
                        XTextElementList list = args2.Result;
                        if (list != null && list.Count == 1 && list[0] is XTextInputFieldElement )
                        {
                            // 若创建结果为一个输入域文档元素则追加额外的数据
                            XTextInputFieldElement field = (XTextInputFieldElement)list[0];
                            field.Attributes = new XAttributeList();
                            field.Attributes.SetValue("创建对象的时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            // 将输入域文档元素对象添加到文档
                            object result = myWriterControl.ExecuteCommand(
                                "InsertInputField",
                                false,
                                field);
                            args.Result = result != null ;
                            // 做标记，通知系统本事件已经被处理掉了
                            args.Handled = true;
                            return;
                        }
                    }
                }
            }
            args.Result = false;
        }

        /// <summary>
        /// 获得能向编辑器插入的对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private object GetSupportInstance(IDataObject data)
        {
            foreach (string format in data.GetFormats())
            {
                if (format.IndexOf("DataSourceDescriptor") >= 0)
                {
                    object v = data.GetData(format);
                    if (v is DataSourceDescriptor)
                    {
                        return v;
                    }
                }
                if (format.IndexOf(typeof(ComponentTypeInfo).Name) >= 0)
                {
                    object v = data.GetData(format);
                    if (v is ComponentTypeInfo)
                    {
                        return v;
                    }
                }
                if (format.IndexOf(typeof(DCSoft.Writer.Data.KBEntry).Name) >= 0)
                {
                    object v = data.GetData(format);
                    if (v is KBEntry)
                    {
                        return v;
                    }
                }
            }
            return null;
        }

    }
}