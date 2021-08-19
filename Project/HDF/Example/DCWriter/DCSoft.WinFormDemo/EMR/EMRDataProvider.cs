using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.WinFormDemo.EMR.Model;
using DCSoft.ORM;

namespace DCSoft.Writer.WinFormDemo.EMR
{
    /// <summary>
    /// 电子病历应用系统数据提供者
    /// </summary>
    public class EMRDataProvider
    {
        private static EMRDataProvider _Instance = null;
        /// <summary>
        /// 对象唯一静态实例
        /// </summary>
        public static EMRDataProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new EMRDataProvider();

                }
                return _Instance;
            }
        }


        private string _CurrentPatientID = null;
        /// <summary>
        /// 当前病人ID号
        /// </summary>
        public string CurrentPatientID
        {
            get { return _CurrentPatientID; }
            set { _CurrentPatientID = value; }
        }

        private string _CurrentUserID = null;
        /// <summary>
        /// 当前登录的用户编号
        /// </summary>
        public string CurrentUserID
        {
            get { return _CurrentUserID; }
            set { _CurrentUserID = value; }
        }

        private ORMEngine _ORM = null;

        public ORMEngine ORM
        {
            get
            {
                if (_ORM == null)
                {
                    _ORM = new ORM.ORMEngine();
                    _ORM.DataBase.Connection = Utils.CreateConnection();
                    _ORM.AddType(typeof(Model.EMR_Patients));
                }
                return _ORM;
            }
        }


        /// <summary>
        /// 从数据库中加载知识库
        /// </summary>
        /// <param name="conn">数据连接对象</param>
        public static void LoadKBLibrary(IDbConnection conn, KBLibrary lib)
        {
            if (conn == null)
            {
                throw new ArgumentNullException("conn");
            }
            if (conn.State != ConnectionState.Open)
            {
                throw new ArgumentException("数据库连接没打开");
            }
            using (IDbCommand cmd = conn.CreateCommand())
            {
                IDataReader reader = null;

                // 读取知识节点,实际开发中可以为这个SQL查询添加过滤条件，只获得当前科室/部门所使用的知识节点
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
                    item.Value = item.ID;
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
                    if (currentParent == null || currentParent.ID != item.ParentID)
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
        }

        /// <summary>
        /// 获取指定的数据数据
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<EMR_Patients> GetSelectDate(IDbConnection conn)
        {
            if (conn == null)
            {
                throw new ArgumentNullException("conn");
            }
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            using (IDbCommand cmd = conn.CreateCommand())
            {
                IDataReader reader = null;
                // cmd.CommandText = @"Select PA_ID,PA_NAME,PA_SEX,PA_PIH_PATIENT_SAPCE,PA_HOMEPLACE from EMR_Patients  Limit 100";
                cmd.CommandText = @"Select Top 100 PA_ID,PA_NAME,PA_SEX,PA_PIH_PATIENT_SAPCE,PA_HOMEPLACE from EMR_Patients";//ZJ2016-4-11
                reader = cmd.ExecuteReader();
                List<EMR_Patients> list = new List<EMR_Patients>();
                while (reader.Read())
                {
                    EMR_Patients temp = new EMR_Patients();
                    if (!reader.IsDBNull(0))
                    {
                        temp.PA_ID = reader.GetString(0);
                    }
                    else
                    {
                        temp.PA_ID = "";
                    }
                    if (!reader.IsDBNull(1))
                    {
                        temp.PA_NAME = reader.GetString(1);
                    }
                    else
                    {
                        temp.PA_NAME = "";
                    }
                    if (!reader.IsDBNull(2))
                    {
                        temp.PA_SEX = reader.GetString(2);
                    }
                    else
                    {
                        temp.PA_SEX = "";
                    }
                    if (!reader.IsDBNull(3))
                    {
                        temp.PA_PIH_PATIENT_SAPCE = reader.GetString(3);
                    }
                    else
                    {
                        temp.PA_PIH_PATIENT_SAPCE = "";
                    }
                    if (!reader.IsDBNull(4))
                    {
                        temp.PA_HOMEPLACE = reader.GetString(4);
                    }
                    else
                    {
                        temp.PA_HOMEPLACE = "";
                    }
                    list.Add(temp);
                }
                reader.Close();
                return list;
            }

        }
    }

}
