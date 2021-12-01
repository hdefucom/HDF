using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data ;
using System.Runtime.InteropServices;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.KnowledgeBase
{
    [ToolboxItem(false)]
    public partial class ctlDBKBLibrary : UserControl
    {
        public ctlDBKBLibrary()
        {
            InitializeComponent();
        }

        private void ctlDBKBLibrary_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            myWriterControl.QueryListItems += new  QueryListItemsEventHandler(myWriterControl_QueryListItems);
            myWriterControl.EventReadFileContent += new WriterReadFileContentEventHandler(myWriterControl_EventReadFileContent);
        }

        void myWriterControl_EventReadFileContent(object eventSender, WriterReadFileContentEventArgs args)
        {
            //if( args.FileSystemName == "kblibrary")
            
            using (IDbConnection conn = Utils.CreateConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select ObjectData From ET_Document where ObjectID ='"
                        + args.FileName + "'";
                    object v = cmd.ExecuteScalar();
                    if (DBNull.Value.Equals(v) == false)
                    {
                        string txt = (string)v;
                        if (txt != null)
                        {
                            if (txt.IndexOf("<emrtextdoc") >= 0)
                            {
                                args.FileFormat = "OldXml";
                            }
                            else
                            {
                                args.FileFormat = "xml";
                            }
                        }
                        byte[] bs = System.Text.Encoding.UTF8.GetBytes(txt);
                        args.ResultBinary = bs;
                    }
                }
            }
        }

        void myWriterControl_QueryListItems(object eventSender, QueryListItemsEventArgs args)
        {
            args.Handled = true;
            string strSQL = null;
            string sourceName = args.ListSourceName;
            if (sourceName != null)
            {
                sourceName = sourceName.ToUpper();
            }
            switch (sourceName)
            {
                case "医保类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0006' Order by SysDesc"; break;
                case "药品类别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0052' Order by SysDesc"; break;
                case "婚姻状态": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0008' Order by SysDesc"; break;
                case "证件类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0009' Order by SysDesc"; break;
                case "兵种": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0010' Order by SysDesc"; break;
                case "住院病历状态": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0012' Order by SysDesc"; break;
                case "医嘱类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0013' Order by SysDesc"; break;
                case "医嘱状态": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0014' Order by SysDesc"; break;
                case "医嘱有效期": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0015' Order by SysDesc"; break;
                case "出院医嘱类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0016' Order by SysDesc"; break;
                case "民族": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0017' Order by SysDesc"; break;
                case "职业": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0018' Order by SysDesc"; break;
                case "联系人关系": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0019' Order by SysDesc"; break;
                case "血型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0020' Order by SysDesc"; break;
                case "病情": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0021' Order by SysDesc"; break;
                case "护理等级": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0022' Order by SysDesc"; break;
                case "药品剂量": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0025' Order by SysDesc"; break;
                case "医院代码": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0030' Order by SysDesc"; break;
                case "医院名称": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0031' Order by SysDesc"; break;
                case "开关": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='9998' Order by SysDesc"; break;
                case "医嘱频率": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0032' Order by SysDesc"; break;
                case "医嘱给药途径": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0033' Order by SysDesc"; break;
                case "医嘱持续时间单位": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0034' Order by SysDesc"; break;
                case "医嘱速度单位": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0035' Order by SysDesc"; break;
                case "医嘱总量单位": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0036' Order by SysDesc"; break;
                case "病程类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0037' Order by SysDesc"; break;
                case "药房": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0038' Order by SysDesc"; break;
                case "检验样品": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0029' Order by SysDesc"; break;
                case "检验样品类别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0039' Order by SysDesc"; break;
                case "文本模板类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0040' Order by SysDesc"; break;
                case "病理标本": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0041' Order by SysDesc"; break;
                case "根据医嘱频率确定执行医嘱时间": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0042' Order by SysDesc"; break;
                case "根据检验样本确定样本的类别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0043' Order by SysDesc"; break;
                case "体温单中的时间点": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0044' Order by SysDesc"; break;
                case "出生地": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0005' Order by SysDesc"; break;
                case "籍贯": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0004' Order by SysDesc"; break;
                case "国籍": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0003' Order by SysDesc"; break;
                case "性别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0002' Order by SysDesc"; break;
                case "收费类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0001' Order by SysDesc"; break;
                case "文化水平": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0007' Order by SysDesc"; break;
                case "入院方式": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0054' Order by SysDesc"; break;
                case "入院情况": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0055' Order by SysDesc"; break;
                case "联系人类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0057' Order by SysDesc"; break;
                case "付款方式": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0056' Order by SysDesc"; break;

                case "DOCEX": strSQL = "Select Name , Name From EMR_Docex Order By Name"; break;
                case "EXAMIN": strSQL = "Select Examine , Examine From EMR_Examine Order By Examine"; break;
                case "科室": strSQL = "Select Name , id from EMR_DEPARTMENT ORDER BY name"; break;
                case "病人来源": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0053' Order by SysDesc"; break;
                case "本科门诊医生": strSQL = "Select em_Name , ID from emr_employee order by em_name"; break;
                case "本科住院医生": strSQL = "Select em_Name , ID from emr_employee order by em_name"; break;
            }

            if (strSQL != null)
            {
                using (IDbConnection conn = Utils.CreateConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = strSQL;
                        IDataReader reader = cmd.ExecuteReader();
                        int fieldCount = reader.FieldCount;
                        while (reader.Read())
                        {
                            ListItem item = new ListItem();
                            if (reader.IsDBNull(0) == false)
                            {
                                item.Text = Convert.ToString(reader.GetValue(0));
                            }
                            if (fieldCount == 1)
                            {
                                item.Value = item.Text;
                            }
                            else
                            {
                                if (reader.IsDBNull(1) == false)
                                {
                                    item.Value = Convert.ToString(reader.GetValue(1));
                                }
                            }
                            if (fieldCount >= 3)
                            {
                                if (reader.IsDBNull(2) == false)
                                {
                                    item.SpellCode = Convert.ToString(reader.GetValue(2));
                                }
                            }
                            args.Result.Add(item);
                        }//while
                        reader.Close();
                    }//using
                }//using
            }//if
        }
         
        /// <summary>
        /// 处理树状列表中鼠标按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwKBLibrary_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                TreeViewHitTestInfo info = tvwKBLibrary.HitTest(e.X, e.Y);
                if (info.Location == TreeViewHitTestLocations.Image
                    || info.Location == TreeViewHitTestLocations.Label)
                {
                    if (info.Node.Tag is KBEntry)
                    {
                        // 命中某个节点的图标或者文本
                        tvwKBLibrary.SelectedNode = info.Node;
                        if (DragDetect(tvwKBLibrary.Handle))
                        {
                            // 开始执行鼠标拖拽
                            System.Windows.Forms.DataObject obj = new DataObject(info.Node.Tag);
                            tvwKBLibrary.DoDragDrop(obj, DragDropEffects.Copy);
                        }
                    }
                }
            }
        }

        private void btnLoadDBKBLibrary_Click(object sender, EventArgs e)
        {
            KBLibrary lib = null;
            using (IDbConnection conn = Utils.CreateConnection())
            {
                conn.Open();
                // 从数据库中加载知识库对象
                lib = LoadKBLibrary(conn);
            }
            // 将知识库结构填充到树状列表中
            tvwKBLibrary.BeginUpdate();
            tvwKBLibrary.Nodes.Clear();
            FillKBNode(tvwKBLibrary.Nodes, lib.KBEntries);
            tvwKBLibrary.EndUpdate();
            // 将知识库对象添加到编辑器体系中
            myWriterControl.ExecuteCommand("LoadKBLibrary", false, lib);
            //myWriterControl.ExecuteCommand("AddService", false, new MyDBListItemsProvider());
        }

        /// <summary>
        /// 递归填充树状结构
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="entries"></param>
        private void FillKBNode(TreeNodeCollection nodes, KBEntryList entries)
        {
            foreach (KBEntry entry in entries)
            {
                TreeNode node = new TreeNode(entry.Text);
                node.Tag = entry;
                nodes.Add(node);
                if (entry.SubEntries != null && entry.SubEntries.Count > 0)
                {
                    // 递归填充子节点
                    FillKBNode(node.Nodes, entry.SubEntries);
                }
            }
        }


        /// <summary>
        /// 从数据库中加载知识库
        /// </summary>
        /// <param name="conn">数据连接对象</param>
        public KBLibrary LoadKBLibrary(IDbConnection conn )
        {
            if (conn == null)
            {
                throw new ArgumentNullException("conn");
            }
            if (conn.State != ConnectionState.Open)
            {
                throw new ArgumentException("数据库连接没打开");
            }
            KBLibrary lib = new KBLibrary();
            // 设置加载模板数据使用的虚拟文件系统对象
            lib.TemplateFileSystemName = "kblibrary";
            //lib.TemplateFileSystem = new DBTemplateFileSystem();
            using (IDbCommand cmd = conn.CreateCommand())
            {
                IDataReader reader = null;

                // 读取知识节点,实际开发中可以为这个SQL查询添加过滤条件，
                // 只获得当前科室/部门所使用的知识节点
                cmd.CommandText = @"
                    Select
                        KB_SEQ ,
                        KB_PARENT ,
                        KB_NAME ,
                        ListIndex ,
                        kb_style
                    From KB_List
                    Order By KB_PARENT , LISTINDEX , KB_NAME";
                reader = cmd.ExecuteReader();
                List<KBEntry> list = new List<KBEntry>();
                while (reader.Read())
                {
                    KBEntry item = new KBEntry();
                    item.ID = reader.GetString(0);
                    item.ParentID = reader.GetString(1);
                    item.Text = reader.GetString(2);
                    item.Value = item.Text ;
                    item.Style = KBEntryStyle.List;
                    list.Add(item);
                }//while
                reader.Close();

                // 加载知识点列表项目，实际开发中可添加查询过滤条件
                cmd.CommandText = @"
                    Select
                        ITEM_SEQ ,
                        KB_SEQ ,
                        ITEM_TEXT ,
                        ITEM_VALUE ,
                        ITEM_STYLE
                    FROM KB_ITEM
                    ORDER BY KB_SEQ , LISTINDEX , ITEM_TEXT";
                reader = cmd.ExecuteReader();
                KBEntry currentEnty = null;
                string bad_kb_seq = null;
                while (reader.Read())
                {
                    string kb_seq = reader.GetString(1);
                    if (kb_seq == bad_kb_seq)
                    {
                        // 错误的知识点节点编号，跳过记录
                        continue;
                    }
                    if (currentEnty == null || currentEnty.ID != kb_seq)
                    {
                        // 查找当前知识点
                        currentEnty = null;
                        bad_kb_seq = null;
                        foreach (KBEntry entry in list)
                        {
                            if (entry.ID == kb_seq)
                            {
                                currentEnty = entry;
                                break;
                            }
                        }//foreach
                    }
                    if (currentEnty == null)
                    {
                        bad_kb_seq = kb_seq;
                        continue;
                    }
                    if (reader.IsDBNull(4) == false)
                    {
                        int itemStyle = Convert.ToInt32(reader.GetValue(4));
                        if (itemStyle == 100)
                        {
                            // 遇到模板节点，添加知识库子节点
                            if (currentEnty.SubEntries == null)
                            {
                                currentEnty.SubEntries = new KBEntryList();
                            }
                            KBEntry subEntry = new KBEntry();
                            subEntry.Style = KBEntryStyle.Template;
                            subEntry.Text = Convert.ToString(reader.GetValue(2));
                            subEntry.Value = Convert.ToString(reader.GetValue(3));
                            currentEnty.SubEntries.Add(subEntry);
                            continue;
                        }
                    }

                    if (currentEnty.ListItems == null)
                    {
                        currentEnty.ListItems = new ListItemCollection();
                    }
                    DCSoft.Writer.Data.ListItem item = new ListItem();
                    item.Text = reader.GetString(2);
                    item.Value = reader.GetString(3);
                    if (item.Value == null)
                    {
                        item.Value = item.Text;
                    }
                    else
                    {
                        string txt = item.Value.Trim();
                        if (txt.Length == 0)
                        {
                            item.Value = item.Text;
                        }
                        else
                        {
                            item.Value = txt;
                        }
                    }
                    currentEnty.ListItems.Add(item);
                }//while
                reader.Close();

                // 对知识点进行排列，达成上下级关系
                KBEntry currentParent = null;
                string rootID = null;
                lib.KBEntries = new KBEntryList();
                //this.KBEntries.AddRange(list);
                foreach (KBEntry item in list)
                {
                    if (item.ParentID == rootID)
                    {
                        lib.KBEntries.Add(item);
                        continue;
                    }
                    if (currentParent == null 
                        || currentParent.ID != item.ParentID)
                    {
                        currentParent = null;
                        // 找到
                        foreach (KBEntry item2 in list)
                        {
                            if (item2.ID == item.ParentID)
                            {
                                currentParent = item2;
                                break;
                            }
                        }
                        if (currentParent == null)
                        {
                            // 没有找到上级节点，则为根节点
                            rootID = item.ParentID;
                            lib.KBEntries.Add(item);
                            continue;
                        }
                    }
                    if (currentParent.SubEntries == null)
                    {
                        currentParent.SubEntries = new KBEntryList();
                    }
                    currentParent.SubEntries.Add(item);
                }//foreach
            }//using
            return lib;
        }

        ///// <summary>
        ///// 从数据库中获得模板的虚拟文件系统
        ///// </summary>
        //private class DBTemplateFileSystem : IFileSystem
        //{
        //    /// <summary>
        //    /// 获得模板文件信息
        //    /// </summary>
        //    /// <param name="args">参数</param>
        //    /// <returns>获得的信息对象</returns>
        //    public VFileInfo GetFileInfo(VFileSystemEventArgs args)
        //    {
        //        using (IDbConnection conn = EMR.DataHelper.CreateConnection())
        //        {
        //            conn.Open();
        //            using (IDbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = "Select ObjectName From ET_Document Where ObjectID = '" + args.FileName + "'";
        //                IDataReader reader = cmd.ExecuteReader();
        //                VFileInfo info = new VFileInfo();
        //                info.Name = args.FileName;
        //                info.FullPath = args.FileName ;
        //                info.Format = "OldXML";
        //                if (reader.Read())
        //                {
        //                    info.Exists = true;
        //                    info.Title = Convert.ToString(reader.GetValue(0));
        //                }
        //                else
        //                {
        //                    info.Exists = false;
        //                }
        //                reader.Close();
        //                return info;
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// 读取模板数据
        //    /// </summary>
        //    /// <param name="args">参数</param>
        //    /// <returns>获得的模板二进制内容</returns>
        //    public byte[] Read(VFileSystemEventArgs args)
        //    {
        //        using (IDbConnection conn = EMR.DataHelper.CreateConnection())
        //        {
        //            conn.Open();
        //            using (IDbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = "Select ObjectData From ET_Document where ObjectID ='" 
        //                    + args.FileName + "'";
        //                object v = cmd.ExecuteScalar();
        //                if (DBNull.Value.Equals(v) == false)
        //                {
        //                    string txt = (string)v;
        //                    if (txt != null)
        //                    {
        //                        if (txt.IndexOf("<emrtextdoc") >= 0)
        //                        {
        //                            args.FileFormat = "OldXml";
        //                        }
        //                        else
        //                        {
        //                            args.FileFormat = "xml";
        //                        }
        //                    }
        //                    Byte[] bs = System.Text.Encoding.UTF8.GetBytes(txt);
        //                    return bs;
        //                }
        //            }
        //        }
        //        return null;
        //    }

        //    /// <summary>
        //    /// 知识库体系不会使用该功能，不予实现
        //    /// </summary>
        //    /// <param name="args"></param>
        //    /// <returns></returns>
        //    public bool Write(VFileSystemEventArgs args, byte[] content)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    /// <summary>
        //    /// 知识库体系不会使用该功能，不予实现
        //    /// </summary>
        //    /// <param name="args"></param>
        //    /// <returns></returns>
        //    public VFileInfo BrowseForRead(VFileSystemEventArgs args)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    /// <summary>
        //    /// 知识库体系不会使用该功能，不予实现
        //    /// </summary>
        //    /// <param name="args"></param>
        //    /// <returns></returns>
        //    public VFileInfo BrowseForWrite(VFileSystemEventArgs args)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        ///// <summary>
        ///// 自定义的加载知识节点下拉列表项目的类型
        ///// </summary>
        ///// <remarks>编制 袁永福</remarks>
        //private class MyDBListItemsProvider : IListItemsProvider
        //{
        //    /// <summary>
        //    /// 初始化对象
        //    /// </summary>
        //    public MyDBListItemsProvider()
        //    {
        //    }

        //    public ListItemCollection GetListItems(ListItemsEventArgs args)
        //    {
        //        string strSQL = null;
        //        // 获得查询数据使用的SQL语句
        //        if (args.KBEntry != null && args.KBEntry.Style == KBEntryStyle.ListSQL)
        //        {
        //            // 知识库节点本身就提供SQL语句
        //            strSQL = args.KBEntry.Value;
        //        }//if
        //        else
        //        {
        //            // 获得数据来源的名称
        //            string sourceName = args.SourceName;
        //            if (sourceName == null)
        //            {
        //                sourceName = "";
        //            }
        //            sourceName = sourceName.Trim().ToUpper();
        //            // 根据数据来源的名称来设置SQL语句
        //            switch( sourceName )
        //            {
        //                case "医保类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0006' Order by SysDesc"; break;
        //                case "药品类别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0052' Order by SysDesc"; break;
        //                case "婚姻状态": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0008' Order by SysDesc"; break;
        //                case "证件类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0009' Order by SysDesc"; break;
        //                case "兵种": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0010' Order by SysDesc"; break;
        //                case "住院病历状态": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0012' Order by SysDesc"; break;
        //                case "医嘱类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0013' Order by SysDesc"; break;
        //                case "医嘱状态": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0014' Order by SysDesc"; break;
        //                case "医嘱有效期": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0015' Order by SysDesc"; break;
        //                case "出院医嘱类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0016' Order by SysDesc"; break;
        //                case "民族": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0017' Order by SysDesc"; break;
        //                case "职业": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0018' Order by SysDesc"; break;
        //                case "联系人关系": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0019' Order by SysDesc"; break;
        //                case "血型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0020' Order by SysDesc"; break;
        //                case "病情": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0021' Order by SysDesc"; break;
        //                case "护理等级": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0022' Order by SysDesc"; break;
        //                case "药品剂量": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0025' Order by SysDesc"; break;
        //                case "医院代码": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0030' Order by SysDesc"; break;
        //                case "医院名称": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0031' Order by SysDesc"; break;
        //                case "开关": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='9998' Order by SysDesc"; break;
        //                case "医嘱频率": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0032' Order by SysDesc"; break;
        //                case "医嘱给药途径": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0033' Order by SysDesc"; break;
        //                case "医嘱持续时间单位": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0034' Order by SysDesc"; break;
        //                case "医嘱速度单位": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0035' Order by SysDesc"; break;
        //                case "医嘱总量单位": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0036' Order by SysDesc"; break;
        //                case "病程类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0037' Order by SysDesc"; break;
        //                case "药房": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0038' Order by SysDesc"; break;
        //                case "检验样品": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0029' Order by SysDesc"; break;
        //                case "检验样品类别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0039' Order by SysDesc"; break;
        //                case "文本模板类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0040' Order by SysDesc"; break;
        //                case "病理标本": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0041' Order by SysDesc"; break;
        //                case "根据医嘱频率确定执行医嘱时间": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0042' Order by SysDesc"; break;
        //                case "根据检验样本确定样本的类别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0043' Order by SysDesc"; break;
        //                case "体温单中的时间点": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0044' Order by SysDesc"; break;
        //                case "出生地": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0005' Order by SysDesc"; break;
        //                case "籍贯": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0004' Order by SysDesc"; break;
        //                case "国籍": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0003' Order by SysDesc"; break;
        //                case "性别": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0002' Order by SysDesc"; break;
        //                case "收费类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0001' Order by SysDesc"; break;
        //                case "文化水平": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0007' Order by SysDesc"; break;
        //                case "入院方式": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0054' Order by SysDesc"; break;
        //                case "入院情况": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0055' Order by SysDesc"; break;
        //                case "联系人类型": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0057' Order by SysDesc"; break;
        //                case "付款方式": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0056' Order by SysDesc"; break;
        //                case "DOCEX": strSQL = "Select Name , Name From EMR_Docex Order By Name"; break;
        //                case "EXAMIN": strSQL = "Select Examine , Examine From EMR_Examine Order By Examine"; break;
        //                case "科室": strSQL = "Select Name , id from EMR_DEPARTMENT ORDER BY name"; break;
        //                case "病人来源": strSQL = "Select SysDesc , SysCode From EMR_SysCode Where SysType='0053' Order by SysDesc"; break;
        //                case "本科门诊医生": strSQL = "Select em_Name , ID from emr_employee order by em_name"; break;
        //                case "本科住院医生": strSQL = "Select em_Name , ID from emr_employee order by em_name"; break;
        //                default :
        //                    break;
        //            }//swtich
        //        }//else
        //        if ( string.IsNullOrEmpty( strSQL ) == false )
        //        {
        //            using (IDbConnection conn = EMR.DataHelper.CreateConnection())
        //            {
        //                conn.Open();
        //                using (IDbCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = strSQL ;
        //                    IDataReader reader = cmd.ExecuteReader();
        //                    ListItemCollection list = CreateListItems(reader);
        //                    reader.Close();
        //                    return list;
        //                }//using
        //            }//using
        //        }//if
        //        return null;
        //    }

        //    /// <summary>
        //    /// 根据读取的数据生成项目列表
        //    /// </summary>
        //    /// <param name="reader">数据读取器</param>
        //    /// <returns>项目列表</returns>
        //    private ListItemCollection CreateListItems(IDataReader reader)
        //    {
        //        int fieldCount = reader.FieldCount;
        //        if (fieldCount == 0)
        //        {
        //            return null;
        //        }
        //        ListItemCollection list = new ListItemCollection();
        //        while (reader.Read())
        //        {
        //            ListItem item = new ListItem();
        //            if (reader.IsDBNull(0) == false)
        //            {
        //                item.Text = Convert.ToString(reader.GetValue(0));
        //            }
        //            if (fieldCount == 1)
        //            {
        //                item.Value = item.Text;
        //            }
        //            else
        //            {
        //                if (reader.IsDBNull(1) == false)
        //                {
        //                    item.Value = Convert.ToString(reader.GetValue(1));
        //                }
        //            }
        //            if (fieldCount >= 3)
        //            {
        //                if (reader.IsDBNull(2) == false)
        //                {
        //                    item.SpellCode = Convert.ToString(reader.GetValue(2));
        //                }
        //            }
        //            list.Add(item);
        //        }//while
        //        return list;
        //    }
        //}



        /// <summary>
        /// 检测鼠标是否开始执行了拖拽操作
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns>是否开始进行了鼠标拖拽操作</returns>
        public static bool DragDetect(IntPtr hwnd)
        {
            POINT p = new POINT();
            p.x = System.Windows.Forms.Control.MousePosition.X;
            p.y = System.Windows.Forms.Control.MousePosition.Y;
            return DragDetect(hwnd, p);
            //return false;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DragDetect(System.IntPtr hWnd, POINT pt);

        private void btnInsertKB_Click(object sender, EventArgs e)
        {
            myWriterControl.BeginInsertKBSpecifyText(myWriterControl.SelectedText);
        }

    }
}