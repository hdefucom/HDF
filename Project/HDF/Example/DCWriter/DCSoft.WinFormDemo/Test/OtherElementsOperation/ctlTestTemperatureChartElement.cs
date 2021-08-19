using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.TemperatureChart;

namespace DCSoft.Writer.WinFormDemo.Test.OtherElementsOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestTemperatureChartElement : UserControl
    {
        public ctlTestTemperatureChartElement()
        {
            InitializeComponent();
        }

        private void frmTestSetSize_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();
            // 设置数据源
            SetDataSource();
        }

        private void SetDataSource()
        {
            // 病人基本信息
            myWriterControl.SetDocumentParameterValue("姓名值","张三");
            myWriterControl.SetDocumentParameterValue("性别值","男");
            myWriterControl.SetDocumentParameterValue("病区值","第三病区");
            myWriterControl.SetDocumentParameterValue("住院号值","001234");
            myWriterControl.SetDocumentParameterValue("床号值","A02");
            DataTable table = new DataTable();
            // 新增数据栏
            table.Columns.Add("测量时间", typeof(DateTime));
            table.Columns.Add("小便数值");
            table.Columns.Add("大便次数");
            table.Columns.Add("液入量数值");
            table.Columns.Add("早上血压");
            table.Columns.Add("晚上血压");
            table.Columns.Add("体重");
            table.Columns.Add("腹围");
            table.Columns.Add("引流数值");
            // 添加数据
            DateTime startDate = DateTime.Today.AddDays(-20);
            // 删掉分钟和秒数，精确到小时
            //startDate = startDate.Subtract(new TimeSpan(0, startDate.Minute, startDate.Second));
            for (int iCount = 0; iCount < 20; iCount += 5)
            {
                table.Rows.Add(startDate.AddDays(iCount), 100, 2, 1000, 90, 95, 80, 80, 900);
                table.Rows.Add(startDate.AddDays(iCount + 1), 130, 3, 1100, 95, 99, 79, 81, 950);
                table.Rows.Add(startDate.AddDays(iCount + 2), 130, 3, 1103, 95, 93, 77, 81, 800);
                table.Rows.Add(startDate.AddDays(iCount + 3), 130, 3, 1100, 95, 99, 79, 81, 950);
                table.Rows.Add(startDate.AddDays(iCount + 4), 130, 3, 1100, 95, 99, 79, 81, 950);
            }
            // 将数据作为文档参数传递到编辑器中
            myWriterControl.SetDocumentParameterValue("按天测量结果", table);
            
            // 中间数值信息 ********************
            table = new DataTable();
            // 设置数据栏目 
            table.Columns.Add("测量时间");
            table.Columns.Add("体温数值");
            table.Columns.Add("脉搏数值");
            table.Columns.Add("眼压数值");
            table.Columns.Add("视力数值");
            table.Columns.Add("文本");
            // 制造测试数据
            for (int iCount = 0; iCount < 600; iCount++)
            {
                DataRow row = table.NewRow();
                // 添加时间
                row[0] = startDate.AddHours(iCount * 4);
                // 体温
                row[1] = TemperatureDocument.GenerateTestValue("体温", 34, 42);
                // 脉搏
                row[2] = TemperatureDocument.GenerateTestValue("脉搏", 20, 180);
                // 眼压
                row[3] = TemperatureDocument.GenerateTestValue("眼压", 0, 40);
                // 视力
                row[4] = TemperatureDocument.GenerateTestValue("视力", 0, 5.2f);
                // 文本内容
                if (iCount == 10)
                {
                    row[5] = "手术";
                }
                else
                {
                    row[5] = "";
                }
                table.Rows.Add(row);
            }//for
            // 将数据作为文档参数传递到编辑器中
            myWriterControl.SetDocumentParameterValue("按小时测量结果", table);
        }

        private void btnInsertTemperatureElement_Click(object sender, EventArgs e)
        {
            // 创建文档
            TemperatureDocument document = new TemperatureDocument();
            // 设置文档配置
            document.ConfigXml = @"
<TemperatureDocumentConfig>
   <SpecifyStartDate></SpecifyStartDate>
   <SpecifyEndDate></SpecifyEndDate>
   <PageTitlePosition>BottomRight</PageTitlePosition>
   <HourTicksValue>2, 6, 10, 14, 18, 22 </HourTicksValue>
   <Title>眼科医院</Title>
   <FooterDescription>说明：脉搏（●）、体温（口温°，腋温×，肛温○）</FooterDescription>
   <SymbolSize>22</SymbolSize>
   <GridLineColorValue>#777777</GridLineColorValue>
    <PageSettings>
      <LeftMargin>50</LeftMargin>
      <TopMargin>50</TopMargin>
      <RightMargin>50</RightMargin>
      <BottomMargin>50</BottomMargin>
    </PageSettings>
   <HeaderLabels>
      <Label Title='姓名' Value='#' />
      <Label Title='性别' Value='#' />
      <Label Title='病区' Value='#' />
      <Label Title='住院号' Value='#' />
      <Label Title='住院日期' Value='#' />
   </HeaderLabels>
   <HeaderLines>
      <Line Title='日期'>
      </Line>
      <Line Title='住院天数' ValueType='InDayIndex'>
      </Line>
      <Line Title='术后天数' StartDateKeyword='手术' ValueType='DayIndex'>
      </Line>
      <Line Name='wendang' Title='病历文档'  ValueType='Data' ShowBackColor='true'  LayoutType='HorizCascade' TickStep='6' >
      </Line>
      <Line Title='时刻' ValueType='HourTick'>
      </Line>
   </HeaderLines>
   <FooterLines>
      <Line Name='huxi' Title='呼吸' ValueType='TickText' SpecifyHeight='80' CircleText='R' TickStep='1' UpAndDownText='true'>
      </Line>
      <Line Name='xiaobian' Title='小便' ValueType='TickText' TickStep='6' >
      </Line>
      <Line Name='zhuangtai2' Title='状态' ValueType='Data'  ShowBackColor='true' LayoutType='Free' TickStep='6' >
      </Line>
      <Line Name='huaxueyaopin' Title='化疗药品' ValueType='Data'  ShowBackColor='true'  LayoutType='Free' TickStep='6' >
      </Line>
      <Line Name='mazuiyaopin' Title='麻醉药品'  ValueType='Data' ShowBackColor='true'  LayoutType='Free' TickStep='6' >
      </Line>
      <Line Name='xiongguan' Title='胸管' ValueType='Data'  ShowBackColor='true'  LayoutType='Free' TickStep='6' >
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis Name='tiwen' Title='体温' MaxValue='42' MinValue='34' SymbolStyle='Cross'
        SymbolColorValue='Blue' ValueFormatString='0.0' RedLineValue='37' >
      </YAxis>
      <YAxis Name='maibo' Title='脉搏' MaxValue='180' MinValue='20' ShadowName='xinlv'><!-- 设置了阴影线条 -->
      </YAxis>
      <YAxis Name='xinlv' Title='心率' MaxValue='180' MinValue='20' >
      </YAxis>
      <YAxis Name='yanya' Title='眼压' MaxValue='40' SymbolColorValue='Green'  >
      </YAxis>
      <YAxis Name='shili' Title='视力' MaxValue='5.2' SymbolStyle='HollowCicle' SymbolColorValue='Blue'  >
         <Scales>
            <Scale Value='5.2' ScaleRate='1' />
            <Scale Value='4.9' ScaleRate='0.875' />
            <Scale Value='4.6' ScaleRate='0.75' />
            <Scale Value='4.3' ScaleRate='0.625' />
            <Scale Value='4' ScaleRate='0.5' />
            <Scale Value='3' ScaleRate='0.375' />
            <Scale Value='2' ScaleRate='0.25' />
            <Scale Value='1' ScaleRate='0.125' />
            <Scale />
         </Scales>
      </YAxis>
      <YAxis Name='wenben' Title='文本内容' Style='Text' SymbolColorValue='Blue'  >
      </YAxis>
   </YAxisInfos>
</TemperatureDocumentConfig>
";
            document.ClearData();
            // 添加数据
            DateTime startDate = DateTime.Today.AddDays(-20);
            // 设置病人基本信息
            document.SetHeaderLableValue("姓名", "李四");
            document.SetHeaderLableValue("性别", "女");
            document.SetHeaderLableValue("病区", "胸外科");
            document.SetHeaderLableValue("住院号", "000134");
            document.SetHeaderLableValue("住院日期", startDate.ToString("yyyy年MM月dd日"));

            // 总计的天数
            int totalDays = 100;
            // 页脚标题行 **********
            // 填充小便数据
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                document.AddPointByTimeText("xiaobian", startDate.AddDays(iCount), "1000");
            }
            // 填充大便次数
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                document.AddPointByTimeText("dabian", startDate.AddDays(iCount), "3");
            }


            //  液入量
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                document.AddPointByTimeText("ruliang", startDate.AddDays(iCount), "800");
            }

            // 血压
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                document.AddPointByTimeText("xuya", startDate.AddDays(iCount), "90/120");
            }

            // 血压
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                document.AddPointByTimeText("tizhong", startDate.AddDays(iCount), "80");
            }

            Random rnd = new Random();


            // 中间数值信息 ********************
            // 体温
            for (int iCount = 0; iCount < totalDays * 6; iCount++)
            {
                // 添加数据
                // 呼吸

                // 填充呼吸次数
                float v5 = TemperatureDocument.GenerateTestValue("呼吸", 10, 60);
                string txt = float.IsNaN(v5) ? "" : Convert.ToInt32(v5).ToString();
                if (rnd.NextDouble() < 0.1)
                {
                    // 小概率表示呼吸机呼吸
                    txt = "R";
                }
                document.AddPointByTimeText(
                    "huxi",
                    startDate.AddHours(iCount * 4),
                    txt);

                // 体温
                float v = TemperatureDocument.GenerateTestValue("体温", 33, 43);
                float v2 = TemperatureDocument.NullValue;
                if ((iCount % 30) == 5)
                {
                    // 物理降温
                    v2 = Math.Max(34, v - 1.5f);
                }
                else if ((iCount % 50) == 7)
                {
                    // 升温
                    v2 = Math.Min(42, v + 1);
                }
                document.AddPointByTimeValueLandernValue(
                    "tiwen",
                    startDate.AddHours(iCount * 4),
                    v,
                    v2);
            }
            // 脉搏和心率
            for (int iCount = 0; iCount < totalDays * 6; iCount++)
            {
                float v = TemperatureDocument.GenerateTestValue("脉搏", 20, 180);
                document.AddPointByTimeValue(
                    "maibo",
                    startDate.AddHours(iCount * 4),
                    v);
                float v2 = v;
                if (rnd.NextDouble() > 0.4)
                {
                    // 有概率心率超过脉搏
                    v2 = (float)Math.Min(180, v + rnd.NextDouble() * 10);
                }
                document.AddPointByTimeValue(
                    "xinlv",
                    startDate.AddHours(iCount * 4),
                    v2);
            }

            // 眼压
            for (int iCount = 0; iCount < totalDays * 6; iCount++)
            {
                document.AddPointByTimeValue(
                    "yanya",
                    startDate.AddHours(iCount * 4),
                    TemperatureDocument.GenerateTestValue("眼压", 0, 40));
            }
            // 视力
            for (int iCount = 0; iCount < totalDays * 6; iCount++)
            {
                document.AddPointByTimeValue(
                    "shili",
                    startDate.AddHours(iCount * 4),
                    TemperatureDocument.GenerateTestValue("视力", 0, 5.2f));
            }
            // 添加状态
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(9),
                "重症监护Z1",
                "#FF1493");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(90),
                "1级护理A1床",
                "#FF00FF");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(130),
                "2级护理A1床",
                "#ff9999");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(152),
                "手术",
                "#9400d3");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(154),
                "重症监护Z3",
                "#FF1493");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(203),
                "1级护理A1床",
                "#ff00ff");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(309),
                "2级护理A1床",
                "#ff9999");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(500),
                "3级护理A1床",
                "#00ff7f");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(590),
                "1级护理B3床",
                "#00ff7f");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(690),
                "请假",
                "#aaaaaa");
            document.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(800),
                "3级护理B3床",
                "#00ff7f");

            // 添加青霉素
            for (int iCount = 0; iCount < totalDays * 6; iCount += Math.Max(6, rnd.Next(40)))
            {
                float v = iCount % 4;
                document.AddPointByTimeTextValue(
                    "qingmeisu2",
                    startDate.AddHours(iCount * 4),
                    v.ToString(),
                    v);
            }

            // 化学药品
            document.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(30), "紫杉醇1000", "#3294f7");
            document.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(50), "无", "#ffffff");
            document.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(100), "奈达铂1500", "#f7c916");
            document.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(170), "多西他赛500", "#e25b00");
            document.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(300), "紫杉醇1500", "#32CD32");
            document.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(330), "无", "#ffffff");
            // 胸管
            document.AddPointByTimeTextColor("xiongguan", startDate.AddHours(153), "右下胸,直径10mm", "#cccccc");
            document.AddPointByTimeTextColor("xiongguan", startDate.AddHours(250), " ", "#ffffff");
            //  麻醉药
            document.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(152), "芬太尼", "#cccccc");
            document.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(161), " ", "#ffffff");

            //文本
            ValuePoint vp = new ValuePoint();
            vp.Time = startDate.AddHours(9);
            vp.Text = "上午九时入院";
            document.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(20);
            vp.Text = "下午八时血生化";
            document.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(31);
            vp.Text = "敏感菌检查";
            document.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(40);
            vp.Text = "下午四时CT";
            document.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(152);
            vp.Text = "上午八时手术";
            document.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(161);
            vp.Text = "心脏起搏术";
            document.AddPoint("wenben", vp);
            // 添加病历文档
            vp = new ValuePoint();
            vp.Time = startDate.AddHours(12);
            vp.Text = "入院记录";
            document.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(14);
            vp.Text = "首次病程";
            document.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(16);
            vp.Text = "病危通知书";
            document.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(130);
            vp.Text = "术前讨论";
            document.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(133);
            vp.Text = "手术通知书";
            document.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(154);
            vp.Text = "手术记录";
            document.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(170);
            vp.ColorValue = "#ff9999";
            vp.Text = "抢救记录";
            vp.Title = "不及时填写，扣5分。";
            document.AddPoint("wendang", vp);


            // 插入体温单
            this.myWriterControl.ExecuteCommand(
                StandardCommandNames.InsertTemperatureChart, 
                false, 
                document);
        }

    }
}
