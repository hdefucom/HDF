using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DB_InfoTable_DataRepair
{
    public partial class Form1 : Form
    {
        public Dictionary<string, Action<XmlNode>> dict = new Dictionary<string, Action<XmlNode>>();


        CancellationTokenSource cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();


            //************************
            dict.Add("eof", node =>
            {
                node.InnerText = "\r\n";
            });
            //************************
            dict.Add("br", node =>
            {
                node.InnerText = "\r\n";
            });
            //************************
            dict.Add("img", node =>
            {
                node.InnerText = "";
            });
            //************************
            dict.Add("btnelement", node =>
            {
                node.InnerText = node.Attributes["name"]?.Value;
            });
            //************************
            dict.Add("checkbox", node =>
            {
                node.InnerText = node.Attributes["name"]?.Value;
            });
            //************************
            dict.Add("flag", node =>
            {
                node.InnerText = "";
            });
            //************************
            dict.Add("horizontalLine", node =>
            {
                node.InnerText = "_____________________________________________________________________\r\n";
            });
            //************************
            dict.Add("mensesformula", node =>
            {
                node.InnerText =
                $" {node.Attributes["firstage"]?.Value} {node.Attributes["last"]?.Value}/{node.Attributes["period"]?.Value} { node.Attributes["finallyageordate"]?.Value} ";
            });
            //************************
            dict.Add("toothcheck", node =>
            {
                node.InnerText =
                $" {node.Attributes["leftup"]?.Value} {node.Attributes["leftdown"]?.Value}/{node.Attributes["rightup"]?.Value} { node.Attributes["rightdown"]?.Value} ";
            });
            //************************
        }


        private void bt_RunByDate_Click(object sender, EventArgs e)
        {
            string vals = dt_Start.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string vale = dt_End.Value.ToString("yyyy-MM-dd HH:mm:ss");

            //这是info表没数据的文书补全all条目的sql
            string sql = $@"select ID as medicalrecordid,noofinpat from recorddetail 
                            where valid=1 
                                and to_date(createtime,'yyyy-MM-dd HH24:mi:ss') >to_date('{vals}','yyyy-MM-dd HH24:mi:ss')
                                and to_date(createtime,'yyyy-MM-dd HH24:mi:ss') <to_date('{vale}','yyyy-MM-dd HH24:mi:ss')
                                and ID not in (select medicalrecordid from reuserecordinfo group by medicalrecordid) ";
            var dt = SqlHelper.ExecuteDataTable(sql);


            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageBox.Show("无数据可修复！");
            }


            var list = dt.Rows.Cast<DataRow>()
                .Select(row => new data
                {
                    noofinpat = row["noofinpat"]?.ToString(),
                    medicalrecordid = row["medicalrecordid"]?.ToString()
                }).ToList();

            Run(list);
        }

        private void btn_RunAll_Click(object sender, EventArgs e)
        {
            //这是info表有数据的文书补全all条目的sql
            string sql = @"select medicalrecordid,noofinpat
                               from (
                                   select 
                                     medicalrecordid,
                                     noofinpat,
                                     min(Reusetype) as title
                                   from reuserecordinfo 
                                   group by medicalrecordid,noofinpat
                               ) 
                               where title <> 'ALL' ";
            var dt = SqlHelper.ExecuteDataTable(sql);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageBox.Show("无数据可修复！");
            }
            var list = dt.Rows.Cast<DataRow>()
                .Select(row => new data
                {
                    noofinpat = row["noofinpat"]?.ToString(),
                    medicalrecordid = row["medicalrecordid"]?.ToString()
                }).ToList();

            Run(list);
        }

        private void Convert(XmlNode node)
        {
            if (dict.TryGetValue(node.Name, out Action<XmlNode> act))
                act.Invoke(node);


            foreach (XmlNode n in node.ChildNodes)
            {
                Convert(n);
            }
        }


        class data
        {
            public string noofinpat { get; set; }
            public string medicalrecordid { get; set; }
        }


        private void Run(List<data> data)
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = data.Count;
            this.progressBar1.Value = 0;

            var en = data.GetEnumerator();

            int complete = 0;

            for (int j = 0; j < 5; j++)
            {
                new Thread(() =>
                {
                    while (true)
                    {
                        if (cts.IsCancellationRequested)
                            break;

                        data item;

                        lock (this)
                        {
                            if (!en.MoveNext())
                            {
                                complete++;
                                if (complete == 5)
                                    this.Invoke(new Action(() => MessageBox.Show("修复完成！")));
                                break;
                            }
                            item = en.Current;

                            this.Invoke(new Action(() =>
                            {
                                if (this.IsDisposed) return;
                                this.progressBar1.Value += 1;
                                this.lbl_Progress.Text = this.progressBar1.Value + "/" + data.Count;

                            }));


                        }
                        //var item = en.Current;

                        try
                        {

                            DataTable obj = SqlHelper.ExecuteDataTable("select  content,isgzip from recorddetail where id=" + item.medicalrecordid);

                            if (obj == null || obj.Rows.Count <= 0) continue;

                            string doc = obj.Rows[0]["CONTENT"].ToString();

                            if (obj.Rows[0]["ISGZIP"].ToString() == "1")
                                doc = ZipHelper.GZipDecompressString(doc);

                            XmlDocument document = new XmlDocument();
                            document.LoadXml(doc);
                            var node = document.GetElementsByTagName("body")[0];

                            Convert(node);

                            string xmlstr = node.InnerText;

                            if (xmlstr.Length > 2000)
                                xmlstr = xmlstr.Substring(0, 2000);

                            //存入数据量
                            string sql = "insert into reuserecordinfo (MedicalRecordID,Noofinpat,Reusetype,Reusevalue,createtime) values (:MedicalRecordID,:Noofinpat,'ALL',:Reusevalue,:createtime)";
                            OracleParameter[] parm ={
                                                new OracleParameter("@MedicalRecordID",item.medicalrecordid),
                                                new OracleParameter("@Noofinpat",item.noofinpat),
                                                new OracleParameter("@Reusevalue", xmlstr),
                                                 new OracleParameter("@createtime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                            };

                            var res = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parm.OfType<DbParameter>().ToArray());

                        }
                        catch (Exception ex)
                        {
                            lock (this)
                            {
                                File.AppendAllText(Application.StartupPath + "修复Log.txt", $@"【noofinpat：{item.noofinpat}】【medicalrecordid：{item.medicalrecordid}】异常
**********************************************************
{ex.Message}
********************************************************");
                            }

                        }

                    }

                }).Start();





            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            cts.Cancel();

            this.FormClosing -= new FormClosingEventHandler(Form1_FormClosing);

            cts.Token.Register(new Action(() =>
            {
                this.Close();
            }));

        }
    }
}
