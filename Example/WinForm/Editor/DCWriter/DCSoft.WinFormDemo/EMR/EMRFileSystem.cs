//using System;
//using System.Collections.Generic;
//using System.Text;
//using DCSoft.Writer.Data;
//using System.Data;
//using System.ComponentModel.Design;
//using DCSoft.Writer.Dom;

//namespace DCSoft.Writer.WinFormDemo.EMR
//{
//    /// <summary>
//    /// 基于数据库的文件系统
//    /// </summary>
//    /// <remarks>编制 袁永福</remarks>
//    public class EMRFileSystem : IFileSystem
//    {
//        private static EMRFileSystem _Instance = null;
//        /// <summary>
//        /// 对象唯一静态实例
//        /// </summary>
//        public static EMRFileSystem Instance
//        {
//            get
//            {
//                if (_Instance == null)
//                {
//                    _Instance = new EMRFileSystem();
//                }
//                return _Instance; 
//            }
//        }

//        /// <summary>
//        /// 初始化对象
//        /// </summary>
//        public EMRFileSystem()
//        {
//        }

//        /// <summary>
//        /// 为读取文件而打开文件流
//        /// </summary>
//        /// <param name="fileName">文件名</param>
//        /// <returns>获得的文件流</returns>
//        byte[] IFileSystem.Read(VFileSystemEventArgs args )
//        {
//            using (IDbConnection conn = DataHelper.CreateConnection())
//            {
//                conn.Open();
//                using (IDbCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = "Select ObjectData From ET_Document where ObjectID ='" + args.FileName + "'";
//                    object v = cmd.ExecuteScalar();
//                    if (DBNull.Value.Equals(v) == false)
//                    {
//                        string txt = (string)v;
//                        if (txt != null)
//                        {
//                            if (txt.IndexOf("<emrtextdoc") >= 0)
//                            {
//                                args.FileFormat = "OldXml";
//                            }
//                            else
//                            {
//                                args.FileFormat = "xml";
//                            }
//                        }
//                        Byte[] bs = System.Text.Encoding.UTF8.GetBytes(txt);
//                        return bs;
//                    }
//                }
//            }
//            return null;
//        }

//        /// <summary>
//        /// 为保持数据而打开文件流
//        /// </summary>
//        /// <param name="fileName">文件名</param>
//        /// <returns>获得的文件流</returns>
//        bool IFileSystem.Write(VFileSystemEventArgs args, byte[] content )
//        {
//            using (IDbConnection conn = DataHelper.CreateConnection())
//            {
//                conn.Open();
//                using (IDbCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = "Update ET_Document Set ObjectData = ? Where ObjectID = '" + args.FileName + "'";
//                    IDataParameter p = cmd.CreateParameter();
//                    if (content != null && content.Length > 0)
//                    {
//                        string txt = System.Text.Encoding.UTF8.GetString(content);
//                        p.Value = txt;
//                    }
//                    else
//                    {
//                        p.Value = DBNull.Value;
//                    }
//                    cmd.Parameters.Add(p);
//                    return cmd.ExecuteNonQuery() > 0;
//                }
//            }
//        }
         
//        public VFileInfo GetFileInfo(VFileSystemEventArgs args)
//        {
//            return GetFileInfo(args.FileName);
//        }

//        private VFileInfo GetFileInfo( string fileName )
//        {
//            using (IDbConnection conn = DataHelper.CreateConnection())
//            {
//                conn.Open();
//                using (IDbCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = "Select ObjectName From ET_Document Where ObjectID = '" + fileName + "'";
//                    IDataReader reader = cmd.ExecuteReader();
//                    VFileInfo info = new VFileInfo();
//                    info.Name = fileName;
//                    info.FullPath = fileName ;
//                    info.Format = "OldXML";
//                    if (reader.Read())
//                    {
//                        info.Exists = true;
//                        info.Title = Convert.ToString(reader.GetValue(0));
//                    }
//                    else
//                    {
//                        info.Exists = false;
//                    }
//                    reader.Close();
//                    return info;
//                }
//            }
//        }
          
//        /// <summary>
//        /// 为读取文件和显示浏览文件对话框
//        /// </summary>
//        /// <param name="initalizeFileName">对话框初始化使用的文件名</param>
//        /// <returns>获得的文件名</returns>
//        VFileInfo IFileSystem.BrowseForRead(VFileSystemEventArgs args)
//        {
//            using (dlgTemplateBrowse dlg = new dlgTemplateBrowse())
//            {
//                using (IDbConnection conn = DataHelper.CreateConnection())
//                {
//                    conn.Open();
//                    using (IDbCommand cmd = conn.CreateCommand())
//                    {
//                        cmd.CommandText = "Select ObjectID , ObjectName From ET_Document order by ObjectName";
//                        IDataReader reader = cmd.ExecuteReader();
//                        Dictionary<string, string> names = new Dictionary<string, string>();
//                        while (reader.Read())
//                        {
//                            if (reader.IsDBNull(0) == false
//                                && reader.IsDBNull(1) == false)
//                            {
//                                names[reader.GetString(1)] = reader.GetString(0);
//                            }
//                        }
//                        reader.Close();
//                        dlg.SelectedFileID = args.FileName ;
//                        dlg.FileNames = names;
//                    }
//                }
//                if (dlg.ShowDialog(args.ParentWindow) == System.Windows.Forms.DialogResult.OK)
//                {
//                    return GetFileInfo( dlg.SelectedFileID );
//                }
//            }
//            return null ;
//        }

//        /// <summary>
//        /// 为保存数据而显示文件选择对话框
//        /// </summary>
//        /// <param name="initalizeFileName">初始化使用的文件名</param>
//        /// <returns>文件名</returns>
//        VFileInfo IFileSystem.BrowseForWrite(VFileSystemEventArgs args )
//        {
//            using (dlgTemplateBrowse dlg = new dlgTemplateBrowse())
//            {
//                using (IDbConnection conn = DataHelper.CreateConnection())
//                {
//                    conn.Open();
//                    using (IDbCommand cmd = conn.CreateCommand())
//                    {
//                        cmd.CommandText = "Select ObjectID , ObjectName From ET_Document Order by ObjectName ";
//                        IDataReader reader = cmd.ExecuteReader();
//                        Dictionary<string, string> names = new Dictionary<string, string>();
//                        while (reader.Read())
//                        {
//                            if (reader.IsDBNull(0) == false
//                                && reader.IsDBNull(1) == false)
//                            {
//                                names[reader.GetString(1)] = reader.GetString(0);
//                            }
//                        }
//                        reader.Close();
//                        dlg.SelectedFileID =args.FileName  ;
//                        dlg.FileNames = names;
//                    }
//                }
//                if (dlg.ShowDialog(args.ParentWindow) == System.Windows.Forms.DialogResult.OK)
//                {
//                    return GetFileInfo( dlg.SelectedFileID );
//                }
//            }
//            return null ;
//        }

//        internal static int OutputXML(string path , bool useFileName )
//        {
//            if( string.IsNullOrEmpty( path ))
//            {
//                path = System.Environment.CurrentDirectory ;
//            }
//            if( System.IO.Directory.Exists( path ) == false )
//            {
//                System.IO.Directory.CreateDirectory( path );
//            }
//            int result = 0;
//            using (IDbConnection conn = DataHelper.CreateConnection())
//            {
//                conn.Open();
//                using (IDbCommand cmd = conn.CreateCommand())
//                {
//                    if (useFileName)
//                    {
//                        cmd.CommandText = "Select ObjectName , objectData From ET_Document";
//                    }
//                    else
//                    {
//                        cmd.CommandText = "Select ObjectID , objectData From ET_Document";
//                    }
//                    IDataReader reader = cmd.ExecuteReader();
//                    while (reader.Read())
//                    {
//                        if (reader.IsDBNull(0) || reader.IsDBNull(1))
//                        {
//                            continue;
//                        }
//                        string fileName = Convert.ToString(reader.GetValue(0));
//                        string text = Convert.ToString(reader.GetValue(1));
//                        if (string.IsNullOrEmpty(text) == false)
//                        {
//                            fileName = System.IO.Path.Combine(path, fileName + ".xml");
//                            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
//                            try
//                            {
//                                doc.LoadXml(text);
//                                using (System.IO.StreamWriter writer
//                                    = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
//                                {
//                                    doc.Save(writer);
//                                }
//                            }
//                            catch
//                            {
//                            }
//                            //using (System.IO.StreamWriter writer 
//                            //    = new System.IO.StreamWriter(fileName, false, Encoding.Unicode))
//                            //{
//                            //    writer.Write(text);
//                            //}
//                            result++;
//                        }
//                    }
//                    reader.Close();
//                }
//            }
//            return result;
//        }

//        internal static int ConvertOldXML2NewXML()
//        {
//            int result = 0;
//            using (IDbConnection conn = DataHelper.CreateConnection())
//            {
//                conn.Open();
//                Dictionary<string, string> contents = new Dictionary<string, string>();
//                using (IDbCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = "select objectid , objectdata from et_document";
//                    IDataReader reader = cmd.ExecuteReader();
//                    while (reader.Read())
//                    {
//                        if (reader.IsDBNull(0) == false && reader.IsDBNull(1) == false)
//                        {
//                            string id = Convert.ToString(reader.GetValue(0));
//                            string xml = Convert.ToString(reader.GetValue(1));
//                            if (xml.IndexOf("<emrtextdoc") >= 0)
//                            {
//                                contents[id] = xml;
//                            }
//                        }
//                    }//while
//                    reader.Close();
//                    if (contents.Count > 0)
//                    {
//                        cmd.CommandText = "Update ET_Document Set ObjectData = ? where objectid= ?";
//                        cmd.Parameters.Clear();
//                        IDataParameter pData = cmd.CreateParameter();
//                        cmd.Parameters.Add( pData );
//                        IDataParameter pID = cmd.CreateParameter();
//                        cmd.Parameters.Add(pID);
//                        XTextDocument document = new XTextDocument();
//                        foreach (string id in contents.Keys)
//                        {
//                            string xml = contents[id];
//                            System.IO.StringReader reader2 = new System.IO.StringReader(xml);
//                            document.Load(reader2, "oldxml");
//                            string newXML =  document.XMLText;

//                            pID.Value = id;
//                            pData.Value = newXML;
//                            if (cmd.ExecuteNonQuery() > 0)
//                            {
//                                result++;
//                            }
//                        }//foreach
//                        document.Dispose();
//                    }//if
//                }//using
//            }//using
//            return result;
//        }
//    }
//}
