using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DCSoft.Writer;
using DCSoft.Writer.Controls ;
using DCSoft.Writer.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace DCSoft.Writer.WinFormDemo
{
    internal class Utils
    {
        public static void QueryListItems( QueryListItemsEventArgs args)
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
                case "多栏药品列表": strSQL = "Select NAME,FOREIGNNAME,SPEC,MEDECODE FROM EMR_DOCEX ORDER BY NAME"; break;
            }
            if (args.KBEntry != null && args.KBEntry.Style == KBEntryStyle.ListSQL)
            {
                strSQL = args.KBEntry.Value;
            }
            if ( string.IsNullOrEmpty( strSQL ) == false )
            {
                using (IDbConnection conn = CreateConnection())
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
                            if (sourceName == "多栏药品列表")
                            {
                                item.Text = Convert.ToString(reader.GetValue(0));
                                item.Value = Convert.ToString(reader.GetValue(0));
                                StringBuilder str = new StringBuilder();
                                for (int iCount = 0; iCount < fieldCount; iCount++)
                                {
                                    if (iCount > 0)
                                    {
                                        str.Append(",");
                                    }
                                    if (reader.IsDBNull(iCount) == false)
                                    {
                                        string txt = Convert.ToString(reader.GetValue(iCount));
                                        if (txt != null)
                                        {
                                            // 过滤掉文字中的逗号,因为在编辑器列表是中是用逗号来进行分组拆分的。
                                            txt = txt.Replace(',', '_');
                                            str.Append(txt);
                                        }
                                    }
                                }
                                item.TextInList = str.ToString();
                                args.AddResultItem(item);
                                continue;
                            }
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
                            args.AddResultItem( item );
                        }//while
                        reader.Close();
                    }//using
                }//using
            }//if
        }

        /// <summary>
        /// 为读取文件而打开文件流
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>获得的文件流</returns>
        public static byte[] ReadTemplate( WriterReadFileContentEventArgs args )
        {
            using (IDbConnection conn = CreateConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select ObjectData From ET_Document where ObjectID ='" + args.FileName + "'";
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
                        if (string.IsNullOrEmpty(txt))
                        {
                            return null;
                        }
                        Byte[] bs = System.Text.Encoding.UTF8.GetBytes(txt);
                        return bs;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 创建数据库连接对象
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection()
        {
            try
            {
                return InnerCreateConnect();
            }
            catch (System.BadImageFormatException ext)
            {
                string msg = ext.Message + "\r\n提示：为解决这个问题，请参考DCWriter用户手册的【11.19】节！";
                System.Windows.Forms.MessageBox.Show(msg);
                return null;
            }
        }
         
        private static string _ConnectionString = null;
        private static bool _IsSQLServer = false;

        private static IDbConnection InnerCreateConnect()
        {
            if (string.IsNullOrEmpty(_ConnectionString))
            {
                string dbFile = System.IO.Path.Combine(Application.StartupPath, "EMR.mdb");
                if (File.Exists(dbFile))
                {
                    // 存在演示数据库文件
                    _ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=EMR.mdb";
                    _IsSQLServer = false;
                }
                else
                {
                    try
                    {
                        using (Microsoft.Data.ConnectionUI.DataConnectionDialog dlg = new Microsoft.Data.ConnectionUI.DataConnectionDialog())
                        {
                            dlg.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.AccessDataSource); // Access 
                            dlg.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.SqlDataSource); // Sql Server
                            dlg.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.SqlFileDataSource); // Sql Server File

                            // 初始化
                            dlg.SelectedDataSource = Microsoft.Data.ConnectionUI.DataSource.AccessDataSource;
                            dlg.SelectedDataProvider = Microsoft.Data.ConnectionUI.DataProvider.OleDBDataProvider;

                            dlg.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=EMR.mdb";
                            dlg.Text = "连接DCWriter演示数据库";
                            //只能够通过DataConnectionDialog类的静态方琺Show出对话框
                            //不同使用dialog.Show()或dialog.ShowDialog()来呈现对话框
                            if (Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(dlg) == DialogResult.OK)
                            {
                                _ConnectionString = dlg.ConnectionString;
                                _IsSQLServer = dlg.SelectedDataSource == Microsoft.Data.ConnectionUI.DataSource.SqlDataSource
                                    || dlg.SelectedDataSource == Microsoft.Data.ConnectionUI.DataSource.SqlFileDataSource;
                            }
                        }
                    }
                    catch (Exception ext)
                    {
                        MessageBox.Show(ext.Message);
                        _ConnectionString = null;
                    }
                }
            }
            if (string.IsNullOrEmpty(_ConnectionString) == false)
            {
                if (_IsSQLServer)
                {
                    SqlConnection conn = new SqlConnection(_ConnectionString);
                    return conn;
                }
                else
                {
                    OleDbConnection conn = new System.Data.OleDb.OleDbConnection(_ConnectionString);
                    return conn;
                }
            }
            return null;
        }
    }
}
