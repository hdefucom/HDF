using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DB_RecordDetail_DataGenerate
{
    public partial class Form_XMLGenerate : Form
    {
        public Form_XMLGenerate()
        {
            InitializeComponent();
        }


        class JBJL
        {
            public string this[string name]
            {
                get
                {
                    var val = this.GetType().GetProperty(name)?.GetValue(this);

                    if (val == null) return "";

                    if (val is DateTime dt)
                        return dt.ToString("yyyy-MM-dd HH:mm:ss");
                    else
                        return val.ToString();
                }

            }

            public string 住院号 { get; set; }
            public string 接班医师编号 { get; set; }
            public string 接班医师 { get; set; }
            public string 交班医师编号 { get; set; }
            public string 交班医师 { get; set; }
            public DateTime 交班时间 { get; set; }

        }


        XmlDocument TemplateDoc;

        Button curtype;


        IEnumerable<int> IdList = new List<int>();


        IEnumerable<JBJL> ModelList = new List<JBJL>();


        CancellationTokenSource cts = new CancellationTokenSource();


        List<Task> tasks = new List<Task>();



        Dictionary<string, Func<DataRow, string>> dict = new Dictionary<string, Func<DataRow, string>>();


        private void Form_XMLGenerate_Load(object sender, EventArgs e)
        {
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            curtype = sender as Button;

            string sql1 = "";
            if (sender == btn_Init_CYPG)
                sql1 = "select xml_doc_new from emrtemplet where templet_id='008795'";
            else if (sender == btn_Init_SSHL)
                sql1 = "select xml_doc_new from emrtemplet where templet_id='002606'";
            else if (sender == btn_Init_JBJL)
                sql1 = "select xml_doc_new from emrtemplet where templet_id='008797'";


            var tmp = OracleHelper.ExecuteScalar(sql1)?.ToString().GZipDecompressString();
            if (string.IsNullOrEmpty(tmp))
            {
                MessageBox.Show("模板xml无数据");
                this.Close();
                return;
            }

            try
            {
                this.TemplateDoc = new XmlDocument();
                this.TemplateDoc.PreserveWhitespace = true;
                this.TemplateDoc.LoadXml(tmp);
            }
            catch (Exception)
            {
                MessageBox.Show("模板xml数据无效");
                this.Close();
                return;
            }


            DataTable ids = null;

            if (sender == btn_Init_CYPG)
                ids = OracleHelper.ExecuteDataTable("select noofinpat from v_template_出院评估与指导");
            else if (sender == btn_Init_SSHL)
                ids = OracleHelper.ExecuteDataTable("select noofinpat from V_TEMPLATE_手术护理记录");
            else if (sender == btn_Init_JBJL)
            {
                ids = SqlServerHelper.ExecuteDataTable(@"with tmp as (
SELECT     z4comp, z4zyno, z4ghno, z4klys
FROM         dbo.zy04h AS a  WITH (NOLOCK)
WHERE     (z4sequ =
(SELECT     MIN(z4sequ) AS Expr1
FROM          dbo.zy04h AS b  WITH (NOLOCK)
WHERE      (a.z4comp = z4comp) AND (z4zyno = a.z4zyno) AND (a.z4ghno = z4ghno))))
--SELECT *FROM tmp
select  a.z1zyno as '住院号',a.z1ysno as '接班医师编号', a.z1ysnm as '接班医师',b.z1ysno as '交班医师编号', b.z1ysnm as '交班医师',b.z1outd  as '交班时间' from (
select * from DBGocent..zy01d  where left(z1endv,1) in('2','8')) a
,(
select * from DBGocent..zy01d A1 where z1endv='9.已更改责任护士和管床医生' AND
 NOT exists (select 1 FROM tmp C WHERE  A1.Z1ZYNO=C.Z4ZYNO AND A1.Z1YSNM=C.z4klys  ) ) b 
where a.z1zyno=b.z1zyno and a.z1ysnm!=b.z1ysnm 
and b.z1date>'2018-12-01 00:00:00'");

            }


            if (ids != null && ids.Rows.Count > 0)
            {
                int count = 0;
                if (sender == btn_Init_JBJL)
                {
                    ModelList = ids.Rows.Cast<DataRow>().Select(r => new JBJL()
                    {
                        住院号 = r["住院号"].ToString(),
                        接班医师编号 = r["接班医师编号"].ToString(),
                        接班医师 = r["接班医师"].ToString(),
                        交班医师编号 = r["交班医师编号"].ToString(),
                        交班医师 = r["交班医师"].ToString(),
                        交班时间 = Convert.ToDateTime(r["交班时间"])
                    }).GroupBy(p => p.住院号).Select(g => g.First());

                    count = ModelList.Count();
                }
                else
                {
                    IdList = ids.Rows.Cast<DataRow>().Select(r => Convert.ToInt32(r["noofinpat"]));
                    count = IdList.Count();
                }

                lbl_progress.Text = $"0/{count}";

                pb_progress.Minimum = 0;
                pb_progress.Maximum = count;
                pb_progress.Value = 0;

                btn_Start.Enabled = true;
                btn_Init_CYPG.Enabled = false;
                btn_Init_SSHL.Enabled = false;

                if (sender == btn_Init_CYPG)
                    dict = new Dictionary<string, Func<DataRow, string>>() {
                        { "姓名",row=>row["患者姓名"].ToString()},
                        { "性别",row=>row["患者性别名称"].ToString()},
                        { "年龄",row=>row["年龄值"].ToString()+row["年龄单位"].ToString()},
                        { "床号",row=>row["病床号"].ToString()},
                        { "科室",row=>row["科室名称"].ToString()},
                        { "住院号",row=>row["住院号"].ToString()},
                        { "入院时间",row=>Convert.ToDateTime(row["入院日期时间"]).ToString("yyyy年MM月dd日 HH时mm分")},
                        { "出院日期时间",row=>Convert.ToDateTime(row["出院日期时间"]).ToString("yyyy年MM月dd日 HH时mm分")},
                        { "中医病症",row=>row["中医病名"].ToString()},
                        { "中医症候",row=>row["中医证名"].ToString()},
                        { "西医诊断",row=>row["西医诊断名称"].ToString()},
                        { "出院情况",row=>row["出院情况代码"].ToString()},
                        { "离院方式",row=>row["离院方式代码"].ToString()},
                        { "对疾病认识程度",row=>row["对疾病认识程度"].ToString()},
                        { "饮食情况代码",row=>row["饮食情况代码"].ToString()},
                        { "饮食指导名称",row=>row["饮食指导代码"].ToString()},
                        { "心理状态",row=>row["心理状态代码"].ToString()},
                        { "自理能力代码",row=>row["自理能力代码"].ToString()},
                        { "服药行为",row=>row["服药行为"].ToString()},
                        { "皮肤情况",row=>row["皮肤情况"].ToString()},
                        { "宣教内容",row=>row["宣教内容代码"].ToString()},
                        { "宣教方式",row=>row["宣教方式"].ToString()},
                        { "对宣教理解程度",row=>row["对宣教理解程度"].ToString()},
                        { "用药指导",row=>row["用药指导"].ToString()},
                        { "生活方式指导",row=>row["生活方式指导"].ToString()},
                        { "复诊指导",row=>row["复诊指导描述"].ToString()},
                        { "责任护士签名",row=>row["责任护士姓名"].ToString()},
                        { "签名日期时间",row=>Convert.ToDateTime(row["文书创建时间"]).ToString("yyyy年MM月dd日 HH时mm分")},
                    };
                else if (sender == btn_Init_SSHL)
                    dict = new Dictionary<string, Func<DataRow, string>>() {
                        { "姓名",row=>row["患者姓名"].ToString()},
                        { "性别",row=>row["患者性别名称"].ToString()},
                        { "年龄",row=>row["年龄值"].ToString()+row["年龄单位"].ToString()},
                        { "床号",row=>row["病床号"].ToString()},
                        { "科室",row=>row["科室名称"].ToString()},
                        { "住院号",row=>row["住院号"].ToString()},
                        { "手术开始日期时间",row=>Convert.ToDateTime(row["手术时间"]).ToString("yyyy-MM-dd HH:mm:ss")},
                        { "术前诊断名称",row=>row["术前诊断名称"].ToString()},
                        { "手术名称",row=>row["手术名称"].ToString()},
                        { "手术部位名称",row=>row["手术部位名称"].ToString()},
                        { "麻醉方式名称",row=>row["麻醉方式名称"].ToString()},
                        { "手术操作者",row=>row["手术操作者"].ToString()},
                        { "术前准备",row=>row["术前准备"].ToString()},
                        { "术中病理标志",row=>row["术中病理标志"].ToString()},
                        { "护理观察项目名称",row=>row["护理观察项目名称"].ToString()},
                        { "护理观察项目结果",row=>row["护理观察项目结果"].ToString()},
                        { "过敏史标志",row=>{
                            var str=row["过敏史"].ToString();
                            return (string.IsNullOrEmpty(row["过敏史"].ToString())||str.Contains("无")||str.Contains("否认"))?"false":"true";
                        }},
                        { "过敏史",row=>row["过敏史"].ToString()},
                        { "皮肤情况",row=>row["皮肤情况"].ToString()},
                        { "留置导尿管",row=>row["留置导尿管"].ToString()},
                        { "器械护士姓名",row=>row["器械护士姓名"].ToString()},
                        { "巡台护士姓名",row=>row["巡台护士姓名"].ToString()},
                        { "病人交接核对项目",row=>row["病人交接核对项目"].ToString()},
                        { "返回病房",row=>row["返回病房"].ToString()},
                        { "意识",row=>row["意识"].ToString()},
                        { "体温",row=>row["体温"].ToString()},
                        { "血压",row=>row["血压"].ToString()},
                        { "脉搏",row=>row["脉搏"].ToString()},
                        { "呼吸",row=>row["呼吸"].ToString()},
                        { "x光片",row=>row["X光片"].ToString()},
                        { "药物",row=>row["药物"].ToString()},
                        { "输液部位",row=>row["输液部位"].ToString()},
                        { "护理操作名称",row=>row["护理操作名称"].ToString()},
                        { "注意事项",row=>row["注意事项"].ToString()},
                        { "交接护士姓名",row=>row["交接护士姓名"].ToString()},
                        { "转运者姓名",row=>row["转运者姓名"].ToString()},
                        { "交接时间",row=>Convert.ToDateTime(row["交接时间"]).ToString("yyyy-MM-dd HH:mm:ss")},
                        { "转运时间",row=>Convert.ToDateTime(row["转运时间"]).ToString("yyyy-MM-dd HH:mm:ss")},
                        { "入手术室时间",row=>Convert.ToDateTime(row["入手术室日期时间"]).ToString("yyyy-MM-dd HH:mm:ss")},
                        { "出手术室时间",row=>Convert.ToDateTime(row["手术结束时间"]).ToString("yyyy-MM-dd HH:mm:ss")},

                        { "手术间编号",row=>row["手术间编号"].ToString()},
                    };
                else if (sender == btn_Init_JBJL)
                    dict = new Dictionary<string, Func<DataRow, string>>()
                    {
                        { "姓名",row=>row["患者姓名"].ToString()},
                        { "性别",row=>row["患者性别名称"].ToString()},
                        { "年龄",row=>row["患者年龄"].ToString()+row["年龄单位"].ToString()},
                        { "床号",row=>row["病床号"].ToString()},
                        { "科室",row=>row["科室名称"].ToString()},
                        { "住院号",row=>row["住院号"].ToString()},

                        { "入院诊断",row=>row["入院西医诊断名称"].ToString()},
                        { "中医病名",row=>row["入院诊断中医病名名称"].ToString()},
                        { "中医症候",row=>row["入院诊断中医证候名称"].ToString()},
                        { "目前诊断",row=>row["目前西医诊断名称"].ToString()},
                        { "目前中医病名",row=>row["目前诊断中医病名"].ToString()},
                        { "目前中医症候",row=>row["目前诊断中医证候名称"].ToString()},

                        { "主诉",row=>row["主诉条目取值"].ToString()},
                        { "入院情况",row=>row["入院情况"].ToString()},
                        { "目前情况描述",row=>row["目前情况描述"].ToString()},
                        { "中医四诊观察结果",row=>row["中医四诊观察结果"].ToString()},
                        { "接班诊疗计划内容",row=>row["接班诊疗计划内容"].ToString()},


                    };

            }


        }


        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (curtype == btn_Init_JBJL)
                RunTask(ModelList);
            else
                RunTask(IdList);
        }


        private void RunTask<T>(IEnumerable<T> enumerable)
        {
            var en = enumerable.GetEnumerator();

            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    while (true)
                    {
                        if (cts.IsCancellationRequested)
                            break;

                        T item;

                        lock (this)
                        {
                            if (!en.MoveNext())
                            {
                                break;
                            }
                            item = en.Current;

                            this.Invoke(new Action(() =>
                            {
                                if (this.IsDisposed) return;

                                this.pb_progress.Value += 1;
                                this.lbl_progress.Text = this.pb_progress.Value + "/" + enumerable.Count();

                            }));
                        }

                        if (curtype == btn_Init_CYPG)
                            GenerateXML_CYPG(Convert.ToInt32(item));
                        else if (curtype == btn_Init_SSHL)
                            GenerateXML_SSHL(Convert.ToInt32(item));
                        else if (curtype == btn_Init_JBJL)
                            GenerateXML_JBJL(item as JBJL);
                    }
                }));
            }


            Task.WhenAll(tasks).ContinueWith(t =>
            {
                this.Invoke(new Action(() =>
                {
                    btn_Start.Enabled = false;
                    btn_Init_CYPG.Enabled = true;
                    btn_Init_SSHL.Enabled = true;
                    MessageBox.Show("生成完成！");
                }));
            });


        }





        private void GenerateXML_SSHL(int id)
        {

            var dt1 = OracleHelper.ExecuteDataTable($"select * from V_TEMPLATE_手术护理记录 where noofinpat='{id}'");

            var dt2 = OracleHelper.ExecuteDataTable($@"select (recorddate||' '||recordtime) as 文档创建时间,
createdoctorid as 医师标识,
CREATEDOCTORNAME as 医师名称,
(recorddate||' '||(case when
regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+',3) is null then regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+') 
else
regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+',3) end )) as 手术结束时间,
(recorddate||' '||(case when
regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+',3) is null then regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+') 
else
regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+',3) end )) as 交接时间,
(recorddate||' '||(case when
regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+',3) is null then regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+') 
else
regexp_substr(regexp_substr(replace(replace( valuexml,'：',':'),'时',':'),'\d+:.*?返回病房',1),'\d+:\d+',3) end )) as 转运时间,
valuexml as 护理操作名称 from v_std_一般护理记录_护理信息 where noofinpat='{id}' and element_name='病情观察及措施' and instr(valuexml,'返回病房') > 0 and rownum=1");

            if (dt1 != null && dt1.Rows.Count > 0 && dt2 != null && dt2.Rows.Count > 0)
            {
                var row1 = dt1.Rows[0];
                var row2 = dt2.Rows[0];

                try
                {

                    var xmldoc = TemplateDoc.Clone() as XmlDocument;


                    //替换header数据
                    foreach (XmlElement header in xmldoc.GetElementsByTagName("header"))
                    {
                        foreach (XmlElement p in header.GetElementsByTagName("p"))
                        {
                            foreach (XmlElement ele in p.ChildNodes.OfType<XmlElement>().Where(c => c.Name == "macro"))
                            {
                                if (this.dict.TryGetValue(ele.GetAttribute("name"), out var func))
                                {
                                    ele.InnerXml = func.Invoke(row1);
                                }
                            }

                        }

                    }

                    //文书保存日志
                    xmldoc.GetElementsByTagName("savelogs")[0].InnerXml = $"<savelog name=\"{row2["医师标识"]}\" time=\"{Convert.ToDateTime(row2["文档创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")}\" level=\"0\" />";

                    //文书设置
                    xmldoc.GetElementsByTagName("docsetting")[0].Attributes["documentmodel"].Value = "Edit";

                    //替换body数据
                    foreach (XmlElement p in ((XmlElement)xmldoc.GetElementsByTagName("body")[0]).GetElementsByTagName("p"))
                    {
                        foreach (XmlElement ele in p.ChildNodes.OfType<XmlElement>().Where(c => c.Name == "fstrelement" || c.Name == "ftimeelement"))
                        {
                            var name = ele.GetAttribute("name");
                            if (this.dict.TryGetValue(name, out var func))
                            {
                                if (new string[] { "出手术室时间", "交接时间", "转运时间" }.Contains(name))
                                    ele.InnerXml = func.Invoke(row2);
                                else
                                    ele.InnerXml = func.Invoke(row1);
                            }
                        }
                    }
                    //处理flag标签

                    var flags = xmldoc.GetElementsByTagName("flag")
                        .OfType<XmlElement>()
                        .GroupBy(f => f.GetAttribute("groupid"),
                            (key, list) => list.OrderByDescending(f => f.GetAttribute("direction"))
                        .ToList());

                    List<dynamic> itemlist = new List<dynamic>();

                    foreach (List<XmlElement> flag in flags)
                    {
                        if (flag.Count != 2) continue;

                        if (this.dict.TryGetValue(flag[0].GetAttribute("name"), out var func))
                        {
                            string flagvalue = "";
                            if (flag[0].GetAttribute("name") == "护理操作名称")
                                flagvalue = func.Invoke(row2);
                            else
                                flagvalue = func.Invoke(row1);

                            List<XmlElement> list = new List<XmlElement>();

                            if (flag[0].ParentNode == flag[1].ParentNode)
                            {
                                list = flag[0].ParentNode.Cast<XmlElement>()
                                    .SkipWhile(ele => ele != flag[0].NextSibling)
                                    .TakeWhile(ele => ele != flag[1]).ToList();
                            }
                            else
                            {
                                //获取段落集合
                                flag[0].ParentNode.ParentNode.Cast<XmlElement>()
                                    .SkipWhile(ele => ele != flag[0].ParentNode)
                                    .TakeWhile(ele => ele != flag[1].ParentNode.NextSibling)
                                    //获取跨段落两个flag中间的元素集合
                                    .ToList().ForEach(p =>
                                    {
                                        if (p == flag[0].ParentNode)
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>().SkipWhile(ele => ele != flag[0].NextSibling));
                                        }
                                        else if (p == flag[1].ParentNode)
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>().TakeWhile(ele => ele != flag[1]));
                                        }
                                        else
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>());
                                        }
                                    });
                            }

                            if (list.Exists(ele => ele.Name == "checkbox"))
                            {
                                if (flag[0].GetAttribute("name") == "皮肤情况")
                                    if (flagvalue.Contains("其它"))
                                    {
                                        list.FirstOrDefault(ele => ele.Name == "checkbox" && ele.GetAttribute("name") == "其它").InnerText = "True";

                                        var span = xmldoc.CreateElement("span");
                                        span.SetAttribute("fontname", "宋体");
                                        span.SetAttribute("fontsize", "10.5");
                                        span.SetAttribute("forecolor", "#000000");
                                        span.InnerText = flagvalue.Replace("其它", "").Replace("：", "").Replace(":", "");

                                        flag[1].ParentNode.InsertBefore(span, flag[1]);
                                    }


                                var vals = flagvalue.Split(',', '，');

                                list.Where(ele =>
                                    ele.Name == "checkbox" &&
                                    (vals.Contains(ele.GetAttribute("name")) || vals.Contains(ele.GetAttribute("itemcode")))
                                ).ToList().ForEach(chk => chk.InnerXml = "True");

                                itemlist.Add(new
                                {
                                    name = flag[0].GetAttribute("name"),
                                    elcode = flag[0].GetAttribute("code"),
                                    code = string.Join(",", list.Where(e => e.InnerText == "True").Select(e => e.GetAttribute("itemcode"))),
                                    value = string.Join("、", list.Where(e => e.InnerText == "True").Select(e => e.GetAttribute("name")))
                                });
                            }
                            else
                            {
                                var star = xmldoc.InnerXml.IndexOf(flag[0].OuterXml) + flag[0].OuterXml.Length;
                                var end = xmldoc.InnerXml.IndexOf(flag[1].OuterXml);

                                var str = xmldoc.InnerXml.Remove(star, end - star);

                                xmldoc.InnerXml = str.Insert(star, $"<span fontname=\"宋体\" fontsize=\"12\" forecolor=\"#000000\"> {flagvalue} </span>");

                                itemlist.Add(new
                                {
                                    name = flag[0].GetAttribute("name"),
                                    elcode = flag[0].GetAttribute("code"),
                                    code = "",
                                    value = flagvalue
                                });
                            }
                        }


                    }

                    string recordid = OracleHelper.ExecuteScalar("select seq_recorddetail_id.nextval from dual").ToString();


                    #region sql
                    string rsql = $@"
insert into recorddetail(
    id,
    noofinpat,
    templateid,
    name,
    recorddesc,
    content,
    sortid,
    owner,
    createtime,
    valid,
    hassubmit, 
    hasprint,
    hassign, 
    captiondatetime,
    islock, 
    firstdailyflag, 
    isyihuangoutong, 
    ip,
    isconfigpagesize,
    departcode,
    wardcode,
    changeid,
    customName,
    fiflag,
    isgzip,
    IsSign)


select
    '{recordid}',
    '{row1["NOOFINPAT"].ToString()}',
    '002606',
    '手术护理记录-最新标准版 {Convert.ToDateTime(row2["文档创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")} {row2["医师名称"].ToString()}',
    '手术护理记录-最新标准版',
    :content,
    'AK',
    '{row2["医师标识"].ToString()}',
    '{Convert.ToDateTime(row2["文档创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")}',
    '1',
    '4600',
    '3600',
    '0',
    '{Convert.ToDateTime(row2["文档创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")}',
    '4700',
    '0',
    '0',
    '',--ip
    '1',
    '{row1["科室标识符"].ToString()}',
    '{row1["病区标识符"].ToString()}',
    id,
    '手术护理记录-最新标准版 {Convert.ToDateTime(row2["文档创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")} {row2["医师名称"].ToString()}',
    '',
    '1',
    '1'
from inpatientchangeinfo 
where noofinpat='{row1["NOOFINPAT"].ToString()}' and newdeptid='{row1["科室标识符"].ToString()}'  and rownum =1
order by createtime 

";

                    #endregion

                    OracleParameter param = new OracleParameter("content", OracleDbType.Clob);
                    param.Value = xmldoc.InnerXml.GZipCompressString();

                    var res = OracleHelper.ExecuteNonQuery(rsql, CommandType.Text, param);

                    if (res == 1)
                    {
                        //插入recorddetail_item表
                        var body = (XmlElement)xmldoc.GetElementsByTagName("body")[0];
                        body.GetElementsByTagName("fstrelement").OfType<XmlElement>()
                            .Concat(body.GetElementsByTagName("ftimeelement").OfType<XmlElement>())
                            .Concat(body.GetElementsByTagName("macro").OfType<XmlElement>())
                            .ToList().ForEach(e =>
                        itemlist.Add(new
                        {
                            name = e.GetAttribute("name"),
                            elcode = e.GetAttribute("code"),
                            code = "",
                            value = e.InnerText
                        }));

                        itemlist.ForEach(f =>
                        {
                            var itemsql = $@"insert into recorddetail_item(
                                                id,
                                                recorddetail_id,
                                                dataelement_id,
                                                dataelement_code,
                                                dataelement_name,
                                                value_code,
                                                value_name,
                                                create_time,
                                                create_user,
                                                name)
                                            values(
                                                '{Guid.NewGuid().ToString() }',
                                                '{recordid}',
                                                '{f.elcode}',
                                                '',
                                                '{f.name}',
                                                '{f.code}',
                                                :value,
                                                to_date('{row2["文档创建时间"]}','yyyy-mm-dd hh24:mi:ss'),
                                                '{row2["医师标识"]}',
                                                '手术护理记录单')
                                            ";

                            OracleParameter pa = new OracleParameter("value", OracleDbType.Varchar2);
                            pa.Value = f.value;
                            OracleHelper.ExecuteNonQuery(itemsql, CommandType.Text, pa);

                        });


                    }

                }
                catch (Exception ex)
                {
                    File.AppendAllText(Application.StartupPath + "\\log-手术护理记录单.txt", $"【******{row1["NOOFINPAT"].ToString()}**{ex.Message}**{ex.StackTrace}****】");
                }
                //xmldoc.Save($@"F:\{id}.xml");



            }
        }

        private void GenerateXML_CYPG(int id)
        {
            string sql = $@"select * from v_template_出院评估与指导 where noofinpat='{id}'";

            var dt = OracleHelper.ExecuteDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];

                try
                {
                    var xmldoc = TemplateDoc.Clone() as XmlDocument;


                    //替换header数据
                    foreach (XmlElement header in xmldoc.GetElementsByTagName("header"))
                    {
                        foreach (XmlElement p in header.GetElementsByTagName("p"))
                        {
                            foreach (XmlElement ele in p.ChildNodes.OfType<XmlElement>().Where(c => c.Name == "macro" || c.Name == "fstrelement"))
                            {
                                if (this.dict.TryGetValue(ele.GetAttribute("name"), out var func))
                                {
                                    ele.InnerXml = func.Invoke(row);
                                }
                            }

                        }

                    }

                    //文书保存日志
                    xmldoc.GetElementsByTagName("savelogs")[0].InnerXml = $"<savelog name=\"{row["责任护士工号"]}\" time=\"{Convert.ToDateTime(row["文书创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")}\" level=\"0\" />";

                    //文书设置
                    xmldoc.GetElementsByTagName("docsetting")[0].Attributes["documentmodel"].Value = "Edit";

                    //替换body数据
                    foreach (XmlElement p in ((XmlElement)xmldoc.GetElementsByTagName("body")[0]).GetElementsByTagName("p"))
                    {
                        foreach (XmlElement ele in p.ChildNodes.OfType<XmlElement>().Where(c => c.Name == "macro" || c.Name == "fstrelement" || c.Name == "ftimeelement"))
                        {
                            if (this.dict.TryGetValue(ele.GetAttribute("name"), out var func))
                            {
                                ele.InnerXml = func.Invoke(row);
                            }
                        }
                    }
                    //处理flag标签

                    var flags = xmldoc.GetElementsByTagName("flag")
                        .OfType<XmlElement>()
                        .GroupBy(f => f.GetAttribute("groupid"),
                            (key, list) => list.OrderByDescending(f => f.GetAttribute("direction"))
                        .ToList());

                    List<dynamic> itemlist = new List<dynamic>();

                    foreach (List<XmlElement> flag in flags)
                    {
                        if (flag.Count != 2) continue;

                        if (this.dict.TryGetValue(flag[0].GetAttribute("name"), out var func))
                        {
                            var flagvalue = func.Invoke(row);

                            List<XmlElement> list = new List<XmlElement>();

                            if (flag[0].ParentNode == flag[1].ParentNode)
                            {
                                list = flag[0].ParentNode.Cast<XmlElement>()
                                    .SkipWhile(ele => ele != flag[0].NextSibling)
                                    .TakeWhile(ele => ele != flag[1]).ToList();
                            }
                            else
                            {
                                //获取段落集合
                                flag[0].ParentNode.ParentNode.Cast<XmlElement>()
                                    .SkipWhile(ele => ele != flag[0].ParentNode)
                                    .TakeWhile(ele => ele != flag[1].ParentNode.NextSibling)
                                    //获取跨段落两个flag中间的元素集合
                                    .ToList().ForEach(p =>
                                    {
                                        if (p == flag[0].ParentNode)
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>().SkipWhile(ele => ele != flag[0].NextSibling));
                                        }
                                        else if (p == flag[1].ParentNode)
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>().TakeWhile(ele => ele != flag[1]));
                                        }
                                        else
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>());
                                        }
                                    });
                            }

                            if (list.Exists(ele => ele.Name == "checkbox"))
                            {
                                if (flag[0].GetAttribute("name") == "皮肤情况")
                                    if (flagvalue.Contains("其它"))
                                    {
                                        list.FirstOrDefault(ele => ele.Name == "checkbox" && ele.GetAttribute("name") == "其它").InnerText = "True";

                                        var span = xmldoc.CreateElement("span");
                                        span.SetAttribute("fontname", "宋体");
                                        span.SetAttribute("fontsize", "10.5");
                                        span.SetAttribute("forecolor", "#000000");
                                        span.InnerText = flagvalue.Replace("其它", "").Replace("：", "").Replace(":", "");

                                        flag[1].ParentNode.InsertBefore(span, flag[1]);
                                    }


                                var vals = flagvalue.Split(',', '，');

                                list.Where(ele =>
                                    ele.Name == "checkbox" &&
                                    (vals.Contains(ele.GetAttribute("name")) || vals.Contains(ele.GetAttribute("itemcode")))
                                ).ToList().ForEach(chk => chk.InnerXml = "True");

                                itemlist.Add(new
                                {
                                    name = flag[0].GetAttribute("name"),
                                    elcode = flag[0].GetAttribute("code"),
                                    code = string.Join(",", list.Where(e => e.InnerText == "True").Select(e => e.GetAttribute("itemcode"))),
                                    value = string.Join("、", list.Where(e => e.InnerText == "True").Select(e => e.GetAttribute("name")))
                                });
                            }
                            else
                            {
                                var star = xmldoc.InnerXml.IndexOf(flag[0].OuterXml) + flag[0].OuterXml.Length;
                                var end = xmldoc.InnerXml.IndexOf(flag[1].OuterXml);

                                var str = xmldoc.InnerXml.Remove(star, end - star);

                                xmldoc.InnerXml = str.Insert(star, $"<span fontname=\"宋体\" fontsize=\"12\" forecolor=\"#000000\"> {flagvalue} </span>");

                                itemlist.Add(new
                                {
                                    name = flag[0].GetAttribute("name"),
                                    elcode = flag[0].GetAttribute("code"),
                                    code = "",
                                    value = flagvalue
                                });
                            }
                        }


                    }

                    string recordid = OracleHelper.ExecuteScalar("select seq_recorddetail_id.nextval from dual").ToString();


                    #region sql
                    string rsql = $@"
insert into recorddetail(
    id,
    noofinpat,
    templateid,
    name,
    recorddesc,
    content,
    sortid,
    owner,
    createtime,
    valid,
    hassubmit, 
    hasprint,
    hassign, 
    captiondatetime,
    islock, 
    firstdailyflag, 
    isyihuangoutong, 
    ip,
    isconfigpagesize,
    departcode,
    wardcode,
    changeid,
    customName,
    fiflag,
    isgzip,
    IsSign)


select
    '{recordid}',
    '{row["NOOFINPAT"].ToString()}',
    '008795',
    '出院评估与指导--最新标准版 {Convert.ToDateTime(row["文书创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")} {row["责任护士姓名"].ToString()}',
    '出院评估与指导--最新标准版',
    :content,
    'AI',
    '{row["责任护士工号"].ToString()}',
    '{Convert.ToDateTime(row["文书创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")}',
    '1',
    '4600',
    '3600',
    '0',
    '{Convert.ToDateTime(row["文书创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")}',
    '4700',
    '0',
    '0',
    '',--ip
    '0',
    '{row["科室标识符"].ToString()}',
    '{row["病区标识符"].ToString()}',
    id,
    '出院评估与指导--最新标准版 {Convert.ToDateTime(row["文书创建时间"]).ToString("yyyy-MM-dd HH:mm:ss")} {row["责任护士姓名"].ToString()}',
    '',
    '1',
    '1'
from inpatientchangeinfo 
where noofinpat='{row["NOOFINPAT"].ToString()}' and newdeptid='{row["科室标识符"].ToString()}'  and rownum =1
order by createtime 

";

                    #endregion

                    OracleParameter param = new OracleParameter("content", OracleDbType.Clob);
                    param.Value = xmldoc.InnerXml.GZipCompressString();

                    var res = OracleHelper.ExecuteNonQuery(rsql, CommandType.Text, param);

                    if (res == 1)
                    {
                        //插入recorddetail_item表
                        var body = (XmlElement)xmldoc.GetElementsByTagName("body")[0];
                        body.GetElementsByTagName("fstrelement").OfType<XmlElement>()
                            .Concat(body.GetElementsByTagName("ftimeelement").OfType<XmlElement>())
                            .Concat(body.GetElementsByTagName("macro").OfType<XmlElement>())
                            .ToList().ForEach(e =>
                        itemlist.Add(new
                        {
                            name = e.GetAttribute("name"),
                            elcode = e.GetAttribute("code"),
                            code = "",
                            value = e.InnerText
                        }));

                        itemlist.ForEach(f =>
                        {
                            var itemsql = $@"insert into recorddetail_item(
                                                id,
                                                recorddetail_id,
                                                dataelement_id,
                                                dataelement_code,
                                                dataelement_name,
                                                value_code,
                                                value_name,
                                                create_time,
                                                create_user,
                                                name)
                                            values(
                                                '{Guid.NewGuid().ToString() }',
                                                '{recordid}',
                                                '{f.elcode}',
                                                '',
                                                '{f.name}',
                                                '{f.code}',
                                                '{f.value}',
                                                to_date('{row["文书创建时间"]}','yyyy-mm-dd hh24:mi:ss'),
                                                '{row["责任护士工号"]}',
                                                '出院评估与指导')
                                            ";

                            OracleHelper.ExecuteNonQuery(itemsql);

                        });


                    }

                }
                catch (Exception ex)
                {
                    File.AppendAllText(Application.StartupPath + "\\log-出院评估与指导.txt", $"【******{row["NOOFINPAT"].ToString()}**{ex.Message}**{ex.StackTrace}****】");
                }
                //xmldoc.Save($@"F:\{id}.xml");



            }
        }

        private void GenerateXML_JBJL(JBJL model)
        {
            if (model == null) return;

            string sql = $@"select * from v_template_交接班记录 where patid='{model.住院号}'";

            var dt = OracleHelper.ExecuteDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];

                try
                {
                    var xmldoc = TemplateDoc.Clone() as XmlDocument;


                    //替换header数据
                    foreach (XmlElement header in xmldoc.GetElementsByTagName("header"))
                    {
                        foreach (XmlElement p in header.GetElementsByTagName("p"))
                        {
                            foreach (XmlElement ele in p.ChildNodes.OfType<XmlElement>().Where(c => c.Name == "macro" || c.Name == "fstrelement"))
                            {
                                if (this.dict.TryGetValue(ele.GetAttribute("name"), out var func))
                                {
                                    ele.InnerXml = func.Invoke(row);
                                }
                            }

                        }

                    }

                    //文书保存日志
                    xmldoc.GetElementsByTagName("savelogs")[0].InnerXml = $"<savelog name=\"{model.交班医师编号}\" time=\"{model.交班时间.ToString("yyyy-MM-dd HH:mm:ss")}\" level=\"0\" />";

                    //文书设置
                    xmldoc.GetElementsByTagName("docsetting")[0].Attributes["documentmodel"].Value = "Edit";

                    //替换body数据
                    foreach (XmlElement p in ((XmlElement)xmldoc.GetElementsByTagName("body")[0]).GetElementsByTagName("p"))
                    {
                        foreach (XmlElement ele in p.ChildNodes.OfType<XmlElement>().Where(c => c.Name == "macro" || c.Name == "fstrelement" || c.Name == "ftimeelement"))
                        {
                            var name = ele.GetAttribute("name");
                            if (this.dict.TryGetValue(name, out var func))
                                ele.InnerXml = func.Invoke(row);
                            else if (name == "交班日期" || name == "接班日期")
                                ele.InnerXml = model.交班时间.ToString("yyyy-MM-dd HH:mm:ss");
                            else if (name == "交班医生")
                                ele.InnerXml = model.交班医师;
                            else if (name == "接班医生")
                                ele.InnerXml = model.接班医师;

                        }
                    }
                    //处理flag标签

                    var flags = xmldoc.GetElementsByTagName("flag")
                        .OfType<XmlElement>()
                        .GroupBy(f => f.GetAttribute("groupid"),
                            (key, list) => list.OrderByDescending(f => f.GetAttribute("direction"))
                        .ToList());

                    List<dynamic> itemlist = new List<dynamic>();

                    foreach (List<XmlElement> flag in flags)
                    {
                        if (flag.Count != 2) continue;

                        var name = flag[0].GetAttribute("name");

                        if (this.dict.TryGetValue(name, out var func))
                        {
                            var flagvalue = func.Invoke(row);

                            flagvalue = flagvalue.Replace("<", "&lt;").Replace(">", "&gt;").Replace("", "");

                            if (name == "接班诊疗计划内容")
                                flagvalue = flagvalue.Replace(" ", "");

                            List<XmlElement> list = new List<XmlElement>();

                            if (flag[0].ParentNode == flag[1].ParentNode)
                            {
                                list = flag[0].ParentNode.Cast<XmlElement>()
                                    .SkipWhile(ele => ele != flag[0].NextSibling)
                                    .TakeWhile(ele => ele != flag[1]).ToList();
                            }
                            else
                            {
                                //获取段落集合
                                flag[0].ParentNode.ParentNode.Cast<XmlElement>()
                                    .SkipWhile(ele => ele != flag[0].ParentNode)
                                    .TakeWhile(ele => ele != flag[1].ParentNode.NextSibling)
                                    //获取跨段落两个flag中间的元素集合
                                    .ToList().ForEach(p =>
                                    {
                                        if (p == flag[0].ParentNode)
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>().SkipWhile(ele => ele != flag[0].NextSibling));
                                        }
                                        else if (p == flag[1].ParentNode)
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>().TakeWhile(ele => ele != flag[1]));
                                        }
                                        else
                                        {
                                            list.AddRange(p.ChildNodes.Cast<XmlElement>());
                                        }
                                    });
                            }

                            var star = xmldoc.InnerXml.IndexOf(flag[0].OuterXml) + flag[0].OuterXml.Length;
                            var end = xmldoc.InnerXml.IndexOf(flag[1].OuterXml);

                            var str = xmldoc.InnerXml.Remove(star, end - star);

                            xmldoc.InnerXml = str.Insert(star, $"<span fontname=\"宋体\" fontsize=\"12\" forecolor=\"#000000\"> {flagvalue} </span>");

                            itemlist.Add(new
                            {
                                name = flag[0].GetAttribute("name"),
                                elcode = flag[0].GetAttribute("code"),
                                code = "",
                                value = flagvalue
                            });
                        }



                    }

                    string recordid = OracleHelper.ExecuteScalar("select seq_recorddetail_id.nextval from dual").ToString();


                    #region sql
                    string rsql = $@"
insert into recorddetail(
    id,
    noofinpat,
    templateid,
    name,
    recorddesc,
    content,
    sortid,
    owner,
    createtime,
    valid,
    hassubmit, 
    hasprint,
    hassign, 
    captiondatetime,
    islock, 
    firstdailyflag, 
    isyihuangoutong, 
    ip,
    isconfigpagesize,
    departcode,
    wardcode,
    changeid,
    customName,
    fiflag,
    isgzip,
    IsSign)


select
    '{recordid}',
    '{row["NOOFINPAT"].ToString()}',
    '008797',
    '交接班记录--最新标准版 {model.交班时间.ToString("yyyy-MM-dd HH:mm:ss")} {model.交班医师}',
    '',
    :content,
    'AC',
    '{model.交班医师编号}',
    '{model.交班时间.ToString("yyyy-MM-dd HH:mm:ss")}',
    '1',
    '4600',
    '3600',
    '0',
    '{model.交班时间.ToString("yyyy-MM-dd HH:mm:ss")}',
    '4700',
    '0',
    '0',
    '',--ip
    '0',
    '{row["科室编码"].ToString()}',
    '{row["病区编码"].ToString()}',
    id,
    '交接班记录--最新标准版 {model.交班时间.ToString("yyyy-MM-dd HH:mm:ss")} {model.交班医师.ToString()}',
    '',
    '1',
    '1'
from inpatientchangeinfo 
where noofinpat='{row["NOOFINPAT"].ToString()}' and newdeptid='{row["科室编码"].ToString()}'  and rownum =1
order by createtime 

";

                    #endregion

                    OracleParameter param = new OracleParameter("content", OracleDbType.Clob);
                    param.Value = xmldoc.InnerXml.GZipCompressString();

                    var res = OracleHelper.ExecuteNonQuery(rsql, CommandType.Text, param);

                    if (res == 1)
                    {
                        //插入recorddetail_item表
                        var body = (XmlElement)xmldoc.GetElementsByTagName("body")[0];
                        body.GetElementsByTagName("fstrelement").OfType<XmlElement>()
                            .Concat(body.GetElementsByTagName("ftimeelement").OfType<XmlElement>())
                            .Concat(body.GetElementsByTagName("macro").OfType<XmlElement>())
                            .ToList().ForEach(e =>
                        itemlist.Add(new
                        {
                            name = e.GetAttribute("name"),
                            elcode = e.GetAttribute("code"),
                            code = "",
                            value = e.InnerText
                        }));

                        itemlist.ForEach(f =>
                        {
                            var itemsql = $@"insert into recorddetail_item(
                                                id,
                                                recorddetail_id,
                                                dataelement_id,
                                                dataelement_code,
                                                dataelement_name,
                                                value_code,
                                                value_name,
                                                create_time,
                                                create_user,
                                                name)
                                            values(
                                                '{Guid.NewGuid().ToString() }',
                                                '{recordid}',
                                                '{f.elcode}',
                                                '',
                                                '{f.name}',
                                                '{f.code}',
                                                '{f.value}',
                                                to_date('{model.交班时间}','yyyy-mm-dd hh24:mi:ss'),
                                                '{model.交班医师编号}',
                                                '交接班记录')
                                            ";

                            OracleHelper.ExecuteNonQuery(itemsql);

                        });


                    }

                }
                catch (Exception ex)
                {
                    File.AppendAllText(Application.StartupPath + "\\log-交接班记录.txt", $"【******{row["NOOFINPAT"].ToString()}**{ex.Message}**{ex.StackTrace}****】");
                }
                //xmldoc.Save($@"F:\{id}.xml");



            }
        }









        private void Form_XMLGenerate_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.FormClosing -= new FormClosingEventHandler(Form_XMLGenerate_FormClosing);




            Task.WhenAll(tasks).ContinueWith(t =>
            {
                this.Invoke(new Action(() => this.Close()));
            });

            cts.Cancel();
        }

    }
}
