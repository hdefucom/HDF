using HDF.Common;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsFormsApp1
{
    public static class Test1
    {






        public static void Start(string sql)
        {
            //var xml11 = File.ReadAllText("C:\\Users\\12131\\Desktop\\2.xml");
            ////xml11 = xml11.GZipDecompressString(Encoding.UTF8);

            //var list22 = Handler(xml11);

            //return;




            var constr = ConfigurationManager.ConnectionStrings["EMR"].ConnectionString;

            using var connection = new OracleConnection(constr);

            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                var id = reader["id"].ToString();
                var noofinpat = reader["noofinpat"].ToString();

                var xml = reader["content"].ToString();
                var isgzip = reader["isgzip"].ToString();

                if (isgzip == "1")
                    xml = xml.GZipDecompressString(Encoding.UTF8);

                var list = Handler(xml);
                if (list != null && list.Count > 0)
                {
                    InsertData(connection, list, id, noofinpat);
                }

                Console.WriteLine($"{id}处理完成");
            }


        }

        static void InsertData(OracleConnection connection, List<Data> list, string id, string noofinpat)
        {
            foreach (var item in list)
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"insert into reuserecordinfo (MEDICALRECORDID, NOOFINPAT, REUSETYPE, REUSEVALUE1, CREATETIME, REUSEVALUE)
values (:MEDICALRECORDID, :NOOFINPAT, :REUSETYPE, :REUSEVALUE1, :CREATETIME, :REUSEVALUE)";

                cmd.Parameters.Add(new OracleParameter(":MEDICALRECORDID", "xxx_" + id));
                cmd.Parameters.Add(new OracleParameter(":NOOFINPAT", noofinpat));
                cmd.Parameters.Add(new OracleParameter(":REUSETYPE", item.Name));
                cmd.Parameters.Add(new OracleParameter(":REUSEVALUE1", item.Value.Length > 2000 ? item.Value.Substring(0, 2000) : item.Value));
                cmd.Parameters.Add(new OracleParameter(":CREATETIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                cmd.Parameters.Add(new OracleParameter(":REUSEVALUE", OracleDbType.Clob) { Value = item.Value });

                try
                {
                    var count = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"insert error:[{id}]-[{noofinpat}]-[{item.Name}]");
                    Console.WriteLine(ex);
                }

            }
        }




        public static List<Data> Handler(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                Console.WriteLine("xml为空");
                return null;
            }

            var doc = new XmlDocument();

            try
            {

                doc.LoadXml(xml);

            }
            catch (Exception ex)
            {
                Console.WriteLine("xml加载异常");
                Console.WriteLine(ex);
                return null;
            }


            var body = doc.GetElementsByTagName("body").Cast<XmlNode>().FirstOrDefault() as XmlElement;

            if (body == null)
            {
                Console.WriteLine("xml-body查找不到");
                return null;
            }


            List<Data> list = new List<Data>();


            var current_item = "";
            var current_item_value = "";



            void AddCurrentItem(string name)
            {
                if (!string.IsNullOrWhiteSpace(current_item) && !string.IsNullOrWhiteSpace(current_item_value))
                {
                    list.Add(new Data
                    {
                        Name = current_item.Trim(),
                        Value = current_item_value.Trim().TrimStart(new char[] { ':', '：' }),
                    });
                }
                current_item = name;
                current_item_value = "";
            }

            bool IsFormItemTitle(XmlElement xmlElement, out string outname)
            {
                outname = null;
                if (xmlElement.Name == "span"
                    && xmlElement.GetAttribute("fontbold") == "1"

                    )
                {
                    if (xmlElement.InnerText.Contains("辅助检查"))
                    {
                        outname = "辅助检查";
                        return true;
                    }

                    var eletitle = xmlElement.InnerText.TrimEnd();
                    if (eletitle.EndsWith(":") || eletitle.EndsWith("："))
                    {
                        outname = eletitle.TrimEnd(':', '：');
                        return true;
                    }

                    if (xmlElement.NextSibling is XmlElement { Name: "span" } xmlele222
                        && (xmlele222.InnerText.StartsWith(":") || xmlele222.InnerText.StartsWith("：")))
                    {
                        outname = eletitle.TrimEnd(':', '：');
                        return true;
                    }

                }

                return false;
            }




            foreach (var item in body.ChildNodes)
            {
                if (item is XmlElement { Name: "p" } ele)
                {
                    foreach (var item2 in ele.ChildNodes)
                    {
                        if (item2 is XmlElement ele2)
                        {
                            if (ele2.Name == "roelement")
                            {
                                AddCurrentItem(ele2.GetAttribute("name"));
                                continue;
                            }
                            else if (IsFormItemTitle(ele2, out var outname1))
                            {
                                AddCurrentItem(outname1);
                                continue;
                            }

                            //匹配到roelement元素项后开始附加文本内容
                            if (string.IsNullOrEmpty(current_item))
                                continue;

                            if (ele2.Name is "span" or "macro" or "ftimeelement")
                            {
                                current_item_value += ele2.InnerText.Trim();
                            }
                            else if (ele2.Name is "br" or "eof")
                            {
                                current_item_value += Environment.NewLine;
                            }

                        }
                    }
                }
                else if (item is XmlElement { Name: "table" } ele_table)
                {
                    var p_list = ele_table.SelectNodes(".//p");

                    foreach (XmlElement p_item in p_list)
                    {

                        foreach (var item2 in p_item.ChildNodes)
                        {
                            if (item2 is XmlElement ele2)
                            {
                                if (ele2.Name == "roelement")
                                {
                                    //AddCurrentItem(ele2.GetAttribute("name"));
                                    AddCurrentItem(ele2.InnerText);
                                    continue;
                                }
                                else if (IsFormItemTitle(ele2, out var outname1))
                                {
                                    AddCurrentItem(outname1);
                                    continue;
                                }

                                //匹配到roelement元素项后开始附加文本内容
                                if (string.IsNullOrEmpty(current_item))
                                    continue;

                                if (ele2.Name is "span" or "macro" or "ftimeelement")
                                {
                                    current_item_value += ele2.InnerText.Trim();
                                }
                                else if (ele2.Name is "br" or "eof")
                                {
                                    current_item_value += Environment.NewLine;
                                }

                            }
                        }
                    }

                    AddCurrentItem("");
                }

            }

            return list;
        }




        public class Data
        {

            public string Name { get; set; }
            public string Value { get; set; }
        }


    }












}