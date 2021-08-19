using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DCSoft.TemperatureChart;
using DCSoft.WinForms;
using System.IO;
using DCSoft.WinForms.Native;

namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    [System.ComponentModel.ToolboxItem(false)]
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class ctlTimeLineTimeZone : UserControl
    {
        public ctlTimeLineTimeZone() 
        {
            InitializeComponent();
            myTemperatureChartControl.SetRegisterCode(DCSoft.Writer.WinFormDemo.Properties.Settings.Default.TimeLineRegisterCode); 
            myTemperatureChartControl.EventLinkClick += new DocumentLinkClickEventHandler(myTemperatureChartControl_EventLinkClick);
            // 加载注册码
            myTemperatureChartControl.SetRegisterCode(DCSoft.Writer.WinFormDemo.Properties.Settings.Default.TimeLineRegisterCode);
       }

        /// <summary>
        /// 文档超链接点击事件
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myTemperatureChartControl_EventLinkClick(object eventSender, DocumentLinkClickEventArgs args)
        {
            if (args.LinkTarget == "EMR")
            {
                using (frmViewDocument frm = new frmViewDocument())
                {
                    frm.DocumentName = Path.Combine(Application.StartupPath, args.Link);
                    AnimatedRectDrawer drawer = new AnimatedRectDrawer();
                    drawer.Style = AnimatedDrawStyle.Rectangle ;
                    drawer.Add(null, args.ScreenBounds, frm);
                    frm.ShowDialog(this);
                }
            }
            else if (args.LinkTarget == "PASC")
            {
                using (frmViewImage frm = new frmViewImage())
                {
                    frm.FileName = Path.Combine(Application.StartupPath, args.Link);
                    AnimatedRectDrawer drawer = new AnimatedRectDrawer();
                    drawer.Style = AnimatedDrawStyle.Rectangle;
                    drawer.Add(null, args.ScreenBounds, frm);
                    frm.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show(args.ValuePoint.Time.ToLongDateString() + Environment.NewLine +  args.ValuePoint.Title);
                if (args.ValuePoint.TagValue == "临床路径类型")
                {
                    args.ValuePoint.Color = Color.Black;
                    myTemperatureChartControl.InvalidateAll();
                }
            
            }
        }  

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            myTemperatureChartControl.RunDesigner();
        }
          
        private void btnTestBoundsOper_Click(object sender, EventArgs e)
        {
            // 设置文档配置
            myTemperatureChartControl.DocumentConfigXml = @"
<TemperatureDocumentConfig xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' Version='1.0'>
   <DataGridTopPadding>0.1</DataGridTopPadding>
   <DataGridBottomPadding>0.1</DataGridBottomPadding>
   <Images />
   <Labels />
   <PageIndexText>第[%pageindex%]页</PageIndexText>
   <SpecifyStartDate />
   <SpecifyEndDate />
   <PageSettings>
      <LeftMargin>50</LeftMargin>
      <TopMargin>50</TopMargin>
      <RightMargin>50</RightMargin>
      <BottomMargin>50</BottomMargin>
   </PageSettings>
   <FooterDescription>说明：脉搏（●）、体温（口温°，腋温×，肛温○）</FooterDescription>
   <PageTitlePosition>BottomRight</PageTitlePosition>
   <Zones>
      <Zone Name='oper' StartTime='2014-10-27T09:00:00+08:00' EndTime='2014-10-27T18:15:00+08:00' AlignToGrid='false' GridLineStyle='Dash' GridLineColorValue='#FF8080' BackColorValue='#F5F5F5' SpecifyTickWidth='110' AutoTickStepSeconds='1800'>
         <Ticks />
      </Zone>
   </Zones>
   <Ticks>
      <Tick Value='2' Text='2' ColorValue='#FF0000' />
      <Tick Value='6' Text='6' ColorValue='#FF0000' />
      <Tick Value='10' Text='10' />
      <Tick Value='14' Text='14' />
      <Tick Value='18' Text='18' />
      <Tick Value='22' Text='22' ColorValue='#FF0000' />
   </Ticks>
   <SymbolSize>22</SymbolSize>
   <BigVerticalGridLineColorValue>#000000</BigVerticalGridLineColorValue>
   <GridLineColorValue>#E0E0E0</GridLineColorValue>
   <Title>眼科医院</Title>
   <HeaderLabels>
      <Label Title='姓名' Value='李四' />
      <Label Title='性别' Value='女' />
      <Label Title='病区' Value='胸外科' />
      <Label Title='住院号' Value='000134' />
      <Label Title='住院日期' Value='2014年10月25日' />
   </HeaderLabels>
   <HeaderLines>
      <Line Title='日期'>
         <DataSource />
         <Scales />
      </Line>
      <Line Title='住院天数' ValueType='GlobalDayIndex'>
         <DataSource />
         <Scales />
      </Line>
      <Line Title='术后天数' StartDateKeyword='手术' ValueType='DayIndex'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='wendang' Title='病历文档' ShowBackColor='true' LayoutType='HorizCascade' TickStep='6' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Title='时刻' ValueType='HourTick'>
         <DataSource />
         <Scales />
      </Line>
   </HeaderLines>
   <FooterLines>
      <Line Name='huxi' Title='呼吸' CircleText='R' SpecifyHeight='80' UpAndDownText='true' ValueType='TickText'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='xiaobian' Title='小便' TickStep='6' ValueType='TickText'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='zhuangtai2' Title='状态' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='yongyao' Title='用药' ShowBackColor='true' LayoutType='FreeText' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='suye' Title='输液和输血' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='xiongguan' Title='胸管' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis Name='tiwen' AllowOutofRange='true' EnableLanternValue='true' LanternValueTitle='物理降温' Title='体温' ValueFormatString='0.0' RedLineValue='37' MaxValue='42' MinValue='34' SymbolStyle='Cross' BottomTitle='摄氏' SymbolColorValue='#00FF00'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='xinlv' Title='心率' MaxValue='180' MinValue='20' BottomTitle='次/分' SymbolColorValue='#008000'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='SYSTOLIC' Title='收缩压' MaxValue='170' MinValue='50' SymbolStyle='V' BottomTitle='mmHg'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='DIASTOLIC' Title='舒张压' MaxValue='170' MinValue='50' SymbolStyle='VReversed' BottomTitle='mmHg'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='wenben' Style='Text' Title='文本内容'>
         <DataSource />
         <Scales />
      </YAxis>
   </YAxisInfos>
</TemperatureDocumentConfig>
";
            myTemperatureChartControl.ClearData();
            // 整个数据开始时间
            DateTime startDate = DateTime.Today.AddDays(-8);
            // 整个数据结束时间
            DateTime endDate = DateTime.Today.AddDays(-1);
            // 禁食开始时间
            DateTime fastTime = startDate.AddHours(40);
            // 手术开始时间
            DateTime operStartTime = startDate.Date.AddDays( 2 ).AddHours( 9 );
            // 手术结束时间
            DateTime operEndTime = operStartTime.AddHours(9.25);
            // 设置手术时间范围
            myTemperatureChartControl.SetTimeLineZoneRange("oper", operStartTime, operEndTime);

            // 设置病人基本信息
            myTemperatureChartControl.SetHeaderLableValue("姓名", "李四");
            myTemperatureChartControl.SetHeaderLableValue("性别", "女");
            myTemperatureChartControl.SetHeaderLableValue("病区", "胸外科");
            myTemperatureChartControl.SetHeaderLableValue("住院号", "000134");
            myTemperatureChartControl.SetHeaderLableValue("住院日期", startDate.ToString("yyyy年MM月dd日"));

            for (DateTime dtm = startDate; dtm < endDate; dtm = dtm.AddDays(1))
            {
                // 添加小便数据
                myTemperatureChartControl.AddPointByTimeText("xiaobian", dtm, "1000");
                // 大便次数
                myTemperatureChartControl.AddPointByTimeText("dabian", dtm , "3");
                if (dtm < fastTime || dtm > operEndTime)
                {
                    // 液体入量
                    myTemperatureChartControl.AddPointByTimeText("ruliang", dtm, "800");
                }
            }
            float hourStep = 1 ;
            System.Random rnd = new Random();
            int iCount = 0;
            for (DateTime dtm = startDate; dtm < endDate; dtm = dtm.AddHours(hourStep))
            {
                iCount++;
                bool inOper = ( dtm >= operStartTime && dtm <= operEndTime );
                // 填充呼吸次数
                float v5 = TemperatureDocument.GenerateTestValue("呼吸", 10, 60  , ! inOper );
                string txt = float.IsNaN(v5) ? "" : Convert.ToInt32(v5).ToString();
                if (rnd.NextDouble() < 0.1)
                {
                    // 小概率表示呼吸机呼吸
                    txt = "R";
                }
                myTemperatureChartControl.AddPointByTimeText(
                    "huxi",
                    dtm ,
                    txt);
                // 体温
                float v = TemperatureDocument.GenerateTestValue("体温", 33, 43, !inOper);
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
                myTemperatureChartControl.AddPointByTimeValueLandernValue(
                    "tiwen",
                    dtm ,
                    v,
                    v2);

                v = TemperatureDocument.GenerateTestValue("脉搏", 20, 180, !inOper);
                myTemperatureChartControl.AddPointByTimeValue(
                    "maibo",
                    dtm ,
                    v);
                v2 = v;
                if (rnd.NextDouble() > 0.4)
                {
                    // 有概率心率超过脉搏
                    v2 = (float)Math.Min(180, v + rnd.NextDouble() * 10);
                }
                // 心率
                myTemperatureChartControl.AddPointByTimeValue(
                    "xinlv",
                    dtm ,
                    v2);
                // 收缩压
                myTemperatureChartControl.AddPointByTimeValue(
                    "SYSTOLIC",
                    dtm ,
                    TemperatureDocument.GenerateTestValue("收缩压", 100, 170, !inOper));
                // 舒张压
                myTemperatureChartControl.AddPointByTimeValue(
                    "DIASTOLIC",
                    dtm ,
                    TemperatureDocument.GenerateTestValue("舒张压", 50, 100, !inOper));

                DateTime nextTime = dtm.AddHours(hourStep);
                if (nextTime >= operStartTime && nextTime <= operEndTime)
                {
                    // 手术期间，10分钟测量一次
                    if (hourStep == 4)
                    {
                        dtm = operStartTime;
                    }
                    hourStep = 1.0f/6;
                    // 让变化来得更猛烈些吧。
                    DCSoft.Common.TestValueGenerator.JumpRate = 0.1f;
                    DCSoft.Common.TestValueGenerator.NoiseRate = 0.12f;
                }
                else
                {
                    // 平时4小时测量一次
                    if (hourStep != 4)
                    {
                        hourStep = 4;
                    }
                    DCSoft.Common.TestValueGenerator.JumpRate = 0.05f;
                    DCSoft.Common.TestValueGenerator.NoiseRate = 0;
                }
            }//for
            // 添加状态
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(8),
                "重症监护Z1",
                "#FF1493");
            ValuePoint vp = new ValuePoint();
            vp.ColorValue = "#9488d3";
            vp.Time = operStartTime;
            vp.EndTime = operEndTime;
            vp.Text = "第三手术室,华佗主刀开胸探查术";
            myTemperatureChartControl.AddPoint("zhuangtai2", vp);
              
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                operEndTime ,
                "重症监护Z3",
                "#FF1493");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                operEndTime.AddHours( 78 ),
                "1级护理A1床",
                "#ff00ff");
             
            //  麻醉药
            myTemperatureChartControl.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(152), "芬太尼", "#cccccc");
            myTemperatureChartControl.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(161), " ", "#ffffff");

            //文本
            myTemperatureChartControl.AddPointByTimeText("wenben", startDate.AddHours(8), "上午八时入院");
            myTemperatureChartControl.AddPointByTimeText("wenben", startDate.AddHours(10), "上午十时血生化");
            myTemperatureChartControl.AddPointByTimeText("wenben", startDate.AddHours(18), "下午六时CT");
            myTemperatureChartControl.AddPointByTimeText("wenben", fastTime, "开始禁食");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime, "手术开始");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(1.3), "改变体位");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(2), "撬开肋骨");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(3), "开始切肿瘤");
            myTemperatureChartControl.AddPointByTimeText("wenben" , operStartTime.AddHours( 4 ) , "又切了一个肿瘤");
            myTemperatureChartControl.AddPointByTimeText("wenben", operEndTime, "手术结束");
            vp = new ValuePoint();
            vp.Text = "阿扎司琼10mg PCIA";
            vp.ColorValue = "#333344";
            vp.Time = operStartTime.AddHours(1);
            myTemperatureChartControl.AddPoint("yongyao", vp);

            vp = new ValuePoint();
            vp.Text = "曲马多1000mg";
            vp.ColorValue = "#ff3333";
            vp.Time = operStartTime.AddHours(2.3);
            myTemperatureChartControl.AddPoint("yongyao", vp);

            vp = new ValuePoint();
            vp.Text = "面霸120g";
            vp.ColorValue = "#4444FF";
            vp.Time = operStartTime.AddHours(7);
            myTemperatureChartControl.AddPoint("yongyao", vp);

            vp = new ValuePoint();
            vp.Text = "乳酸钠林格氏液500ml ivgt";
            vp.ColorValue = "yellow";
            vp.Time = operStartTime.AddHours(1.2);
            vp.EndTime = operStartTime.AddHours(4);
            myTemperatureChartControl.AddPoint("suye", vp);
             
            // 添加病历文档
            vp = new ValuePoint();
            vp.Time = startDate.AddHours(12);
            vp.Text = "入院记录";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(14);
            vp.Text = "首次病程";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(16);
            vp.Text = "病危通知书";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(30);
            vp.Text = "术前讨论";
            myTemperatureChartControl.AddPoint("wendang", vp);
             
            vp = new ValuePoint();
            vp.Time = operEndTime.Date.AddDays( 1).AddHours( 9 );
            vp.Text = "手术记录";
             vp.ColorValue = "#ff9999";
            vp.Title = "不及时填写，扣5分。";
            myTemperatureChartControl.AddPoint("wendang", vp);

            // 胸管
            vp = new ValuePoint();
            vp.Text = "右下胸,直径10mm";
            vp.ColorValue = "#cccccc";
            vp.Time = operStartTime.AddHours(1.5);
            vp.EndTime = operStartTime.AddHours(50);
            myTemperatureChartControl.AddPoint("xiongguan", vp );

            // 刷新文档内容
            myTemperatureChartControl.RefreshView();
        }
         

        private void btnBoundsOper2_Click(object sender, EventArgs e)
        {
            // 设置文档配置
            myTemperatureChartControl.DocumentConfigXml = @"
<TemperatureDocumentConfig xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' Version='1.0'>
   <EditValuePointMode>OwnedUI</EditValuePointMode>
   <TitleForToolTip>南京都昌信息科技有限公司提醒您</TitleForToolTip>
   <SelectionMode>SingleSelect</SelectionMode>
   <DataGridTopPadding>0.1</DataGridTopPadding>
   <DataGridBottomPadding>0.1</DataGridBottomPadding>
   <Images />
   <Labels />
   <PageIndexText>第[%pageindex%]页</PageIndexText>
   <SpecifyStartDate />
   <SpecifyEndDate />
   <PageSettings>
      <LeftMargin>50</LeftMargin>
      <TopMargin>50</TopMargin>
      <RightMargin>50</RightMargin>
      <BottomMargin>50</BottomMargin>
   </PageSettings>
   <FooterDescription>说明：脉搏（●）、体温（口温°，腋温×，肛温○）</FooterDescription>
   <PageTitlePosition>BottomRight</PageTitlePosition>
   <Zones>
      <Zone Name='xuetou1' StartTime='2015-08-27T09:00:00+08:00' EndTime='2015-08-27T11:00:00+08:00' AlignToGrid='false' GridLineStyle='Dash' GridLineColorValue='#0000FF' BackColorValue='#F5F5F5' SpecifyTickWidth='100' AutoTickStepSeconds='1800'>
         <Ticks />
      </Zone>
      <Zone Name='xuetou2' StartTime='2015-09-06T10:00:00+08:00' EndTime='2015-09-06T12:30:00+08:00' AlignToGrid='false' GridLineStyle='Dash' GridLineColorValue='#0000FF' BackColorValue='#F5F5F5' SpecifyTickWidth='100' AutoTickStepSeconds='1800'>
         <Ticks />
      </Zone>
      <Zone Name='inpatient' StartTime='2015-09-09T09:00:00+08:00' EndTime='2015-09-27T00:00:00+08:00' GridLineColorValue='#E0E0E0'>
         <Ticks>
            <Tick Value='2' Text='2' ColorValue='#FF0000' />
            <Tick Value='6' Text='6' ColorValue='#FF0000' />
            <Tick Value='10' Text='10' />
            <Tick Value='14' Text='14' />
            <Tick Value='18' Text='18' />
            <Tick Value='22' Text='22' ColorValue='#FF0000' />
         </Ticks>
      </Zone>
      <Zone Name='oper' StartTime='2015-09-11T10:15:00+08:00' EndTime='2015-09-11T19:45:00+08:00' AlignToGrid='false' GridLineStyle='Dash' GridLineColorValue='#FF8080' BackColorValue='#F5F5F5' SpecifyTickWidth='100' AutoTickStepSeconds='1800'>
         <Ticks />
      </Zone>
   </Zones>
   <Ticks>
      <Tick Value='12' Text='12' />
      <Tick Value='24' Text='24' />
   </Ticks>
   <SymbolSize>22</SymbolSize>
   <BigVerticalGridLineColorValue>#A9A9A9</BigVerticalGridLineColorValue>
   <GridLineColorValue>#00FFFFFF</GridLineColorValue>
   <Title>眼科医院</Title>
   <HeaderLabels>
      <Label Title='姓名' ParameterName='name' Value='李四' />
      <Label Title='性别' ParameterName='sex' Value='女' />
      <Label Title='病区' ParameterName='section' Value='肾脏病科' />
      <Label Title='住院号' ParameterName='id' Value='000134' />
      <Label Title='住院日期' ParameterName='indate' Value='2014年08月30日' />
   </HeaderLabels>
   <HeaderLines>
      <Line Title='日期'>
         <DataSource />
         <Scales />
      </Line>
      <Line Title='术后天数' StartDateKeyword='手术' ValueType='DayIndex'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='wendang' Title='病历文档' ShowBackColor='true' LayoutType='AutoCascade' TickStep='2' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Title='时刻' ValueType='HourTick'>
         <DataSource />
         <Scales />
      </Line>
   </HeaderLines>
   <FooterLines>
      <Line Name='zhuangtai2' GroupName='状态' Title='状态' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='huxi' GroupName='状态' NormalMaxValue='30' NormalMinValue='9' ValueDisplayFormat='0' Title='呼吸' CircleText='R' SpecifyHeight='80' UpAndDownText='true' ValueType='TickText'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='xiaobian' GroupName='状态' Title='小便' TickStep='2' ValueType='Text'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='yongyao' GroupName='其他' Title='医嘱下达' ShowBackColor='true' LayoutType='FreeText' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='zhixing' GroupName='其他' Title='医嘱执行' ShowBackColor='true' LayoutType='FreeText' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='suye' GroupName='其他' Title='输液和输血' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='fuguan' GroupName='其他' Title='腹管' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis Name='tiwen' ValuePrecision='1' AllowOutofRange='true' EnableLanternValue='true' LanternValueTitle='物理降温' TitleValueDispalyFormat='0°' Title='体温' ValueFormatString='0.0' RedLineValue='37' NormalRangeBackColorValue='#B4C0FFC0' OutofNormalRangeBackColorValue='#00000000' NormalMaxValue='37.5' NormalMinValue='36.5' MaxValue='42' MinValue='34' SymbolStyle='Cross' BottomTitle='摄氏' SymbolColorValue='#00FF00'>
         <TopPadding>0.1</TopPadding>
         <BottomPadding>0.5</BottomPadding>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='xinlv' ValuePrecision='0' Title='心率' OutofNormalRangeBackColorValue='#FFC0CB' MaxValue='180' MinValue='20' BottomTitle='次/分' SymbolColorValue='#008000'>
         <TopPadding>0.1</TopPadding>
         <BottomPadding>0.5</BottomPadding>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='xuetang' AllowOutofRange='true' Title='血糖' OutofNormalRangeBackColorValue='#64FFC0CB' NormalMaxValue='6.1' NormalMinValue='3.9' MaxValue='10' BottomTitle='mmHg'>
         <TopPadding>0.5</TopPadding>
         <BottomPadding>0.1</BottomPadding>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='jigan' AllowOutofRange='true' Title='肌酐' OutofNormalRangeBackColorValue='#FFC0CB' MaxValue='1000' SymbolStyle='Square' BottomTitle='mmHg' SymbolColorValue='#C0C000'>
         <TopPadding>0.5</TopPadding>
         <BottomPadding>0.1</BottomPadding>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='wenben' Style='Text' Title='文本内容' OutofNormalRangeBackColorValue='#FFC0CB'>
         <DataSource />
         <Scales />
      </YAxis>
   </YAxisInfos>
</TemperatureDocumentConfig>
";
            myTemperatureChartControl.ClearData();
            // 整个数据开始时间
            DateTime startDate = DateTime.Today.AddDays(-21);
            // 整个数据结束时间
            DateTime endDate = DateTime.Today.AddDays(0);
           
            // 第一次血透开始时间
            DateTime xt1StartTime = startDate.AddDays( 3 ).AddHours( 9 );
            // 第一次血透结束时间
            DateTime xt1EndTime = xt1StartTime.AddHours(2);
            // 设置血透1时间范围
            myTemperatureChartControl.SetTimeLineZoneRange("xuetou1", xt1StartTime, xt1EndTime);

            // 第二次血透开始时间
            DateTime xt2StartTime = startDate.AddDays( 13 ).AddHours( 10 );
            // 第二次血透结束时间
            DateTime xt2EndTime = xt2StartTime.AddHours(2.5);
            // 设置血透2的时间范围
            myTemperatureChartControl.SetTimeLineZoneRange("xuetou2", xt2StartTime, xt2EndTime);

            // 入院时间
            DateTime inTime = startDate.AddDays(16).AddHours(9);
            myTemperatureChartControl.SetTimeLineZoneRange("inpatient", inTime, endDate.AddDays( 5 ));

            // 禁食开始时间
            DateTime fastTime = startDate.AddDays(17).AddHours(20);
            // 手术开始时间
            DateTime operStartTime = startDate.AddDays( 18 ) .AddHours( 10.25 );
            // 手术结束时间
            DateTime operEndTime = operStartTime.AddHours(9.5);
            // 设置手术时间范围
            myTemperatureChartControl.SetTimeLineZoneRange("oper", operStartTime, operEndTime);

            // 设置病人基本信息
            myTemperatureChartControl.SetParameterValue("name", "李四");
            myTemperatureChartControl.SetParameterValue("sex", "女");
            myTemperatureChartControl.SetParameterValue("section", "肾脏病科");
            myTemperatureChartControl.SetParameterValue("id", "000134");
            myTemperatureChartControl.SetParameterValue("indate", startDate.ToString("yyyy年MM月dd日"));

            
            for (DateTime dtm = startDate; dtm < endDate; dtm = dtm.AddDays(1))
            {
                // 添加小便数据
                myTemperatureChartControl.AddPointByTimeText("xiaobian", dtm, "1000");
                // 大便次数
                myTemperatureChartControl.AddPointByTimeText("dabian", dtm, "3");
                if (dtm < fastTime || dtm > operEndTime)
                {
                    // 液体入量
                    myTemperatureChartControl.AddPointByTimeText("ruliang", dtm, "800");
                }
            }
            
            System.Random rnd = new Random();
            // 添加肌酐
            // 肌酐初始值200
            float jgValue = 200;
            int normalCount = 0;
            for (DateTime dtm = startDate; dtm < endDate; dtm = dtm.AddSeconds(600))
            {
                bool inOper = false;
                bool addValue = false;
                DCSoft.Common.TestValueGenerator.NoiseRate = 0.01f;
                if ((dtm >= xt1StartTime && dtm <= xt1EndTime))
                {
                    // 第一次血透，数值逐渐下降
                    jgValue = jgValue - rnd.Next(4, 20);
                    addValue = true;
                    normalCount = 0;
                }
                else if (dtm >= xt2StartTime && dtm <= xt2EndTime)
                {
                    // 第二次血透
                    jgValue = jgValue - rnd.Next(4, 20);
                    addValue = true;
                    normalCount = 0;
                }
                else if (dtm >= operStartTime && dtm <= operEndTime)
                {
                    // 正在手术
                    // 手术时数值起伏比较大
                    inOper = true;
                    DCSoft.Common.TestValueGenerator.NoiseRate = 0.1f;
                    jgValue = jgValue - rnd.Next(4, 10);
                    addValue = true;
                    normalCount = 0;
                }
                else if (dtm > operEndTime)
                {
                    // 手术后，数值逐渐下降
                    jgValue = jgValue - (float)rnd.NextDouble() * 0.1f;
                    // 术后
                    addValue = (( normalCount ++ ) % 72 ) == 0 ;
                }
                else
                {
                    // 平时生活中，数值数据上升
                    jgValue = jgValue + ( float ) rnd.NextDouble() * 0.5f;
                    addValue = (( normalCount ++ ) % 72 ) == 0 ;
                }
                if (dtm > inTime)
                {
                    addValue = ((normalCount++) % 48) == 0;
                }
                if (addValue)
                {
                    myTemperatureChartControl.AddPointByTimeValue("jigan", dtm, jgValue);

                    float v = TemperatureDocument.GenerateTestValue("血糖", 0, 10, true);
                    myTemperatureChartControl.AddPointByTimeValue("xuetang", dtm,  v);

                    v = TemperatureDocument.GenerateTestValue("体温", 33, 43, !inOper);
                    myTemperatureChartControl.AddPointByTimeValue("tiwen", dtm, v);

                    v = TemperatureDocument.GenerateTestValue("心率", 20, 180, !inOper);
                    myTemperatureChartControl.AddPointByTimeValue("xinlv", dtm,  v);

                    v = TemperatureDocument.GenerateTestValue("呼吸", 4, 40, !inOper);
                    myTemperatureChartControl.AddPointByTimeValue("huxi", dtm, v);
                }
            }

            // 添加状态
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate ,
                "门诊(张仲景)",
                "#bbbbbb");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                xt1StartTime,
                "第12号血透机(张护士)",
                "#33FFFF");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                xt1EndTime,
                "蓝旗新村卫生院",
                "#bbbbbb");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                xt2StartTime,
                "第9号血透机(刘护士)",
                "#33ffff");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                xt2EndTime,
                "蓝旗新村卫生院",
                "#bbbbbb");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                inTime,
                "第21床三级护理(李护士)",
                "#33ffff");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                operStartTime,
                "第2手术室，华佗主刀肾移植术",
                "#9488d3");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                operEndTime,
                "第21床一级护理(王护士)",
                "#33ffff");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                operEndTime.AddDays(3),
                "第21床三级护理(李护士)",
                "#33ffff");
              
            //  麻醉药
            myTemperatureChartControl.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(152), "芬太尼", "#cccccc");
            myTemperatureChartControl.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(161), " ", "#ffffff");

            //文本
            ValuePoint vp = new ValuePoint();
            vp.Time = startDate.AddHours(8);
            vp.Text = "省人民上午八时门诊";
            vp.Link = "TimeLineTest\\Files\\门诊病历.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wenben", vp );

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(10);
            vp.Text = "上午十时血生化";
            vp.Link = "TimeLineTest\\Files\\血生化报告单.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(18);
            vp.Text = "下午六时CT";
            vp.Link = "TimeLineTest\\Files\\CT.JPG";
            vp.LinkTarget = "PASC";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(30);
            vp.Text = "病理分析";
            vp.Link = "TimeLineTest\\Files\\病理分析.JPG";
            vp.LinkTarget = "PASC";
            vp.Value = 100;
            myTemperatureChartControl.AddPoint("wenben", vp);


            vp = new ValuePoint();
            vp.Time = inTime;
            vp.Text = "省人民上午九时入院";
            vp.Link = "TimeLineTest\\Files\\入院记录.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wenben", vp);
            
            myTemperatureChartControl.AddPointByTimeText("wenben", fastTime, "开始禁食");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime, "手术开始");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(1.3), "改变体位");

            //vp = new ValuePoint();
            //vp.Time = operStartTime.AddHours(2);
            //vp.Text = "割掉老肾";
            //vp.Link = "TimeLineTest\\Files\\割掉老肾.jpg";
            //vp.LinkTarget = "PASC";
            //myTemperatureChartControl.AddPoint("wenben", vp);
            //myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(2), "割掉老肾");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(3), "换上新肾");
            myTemperatureChartControl.AddPointByTimeText("wenben", operEndTime, "手术结束");

            vp = new ValuePoint();
            vp.Text = "雷公藤";
            vp.ColorValue = "#333344";
            vp.Time = startDate.AddHours(40);
            myTemperatureChartControl.AddPoint("yongyao", vp);
            vp = new ValuePoint();
            vp.Text = "已服雷公藤";
            vp.ColorValue = "#333344";
            vp.Time = startDate.AddHours(44);
            myTemperatureChartControl.AddPoint("zhixing", vp);

            vp = new ValuePoint();
            vp.Text = "阿扎司琼10mg PCIA";
            vp.ColorValue = "#333344";
            vp.Time = operStartTime.AddHours(1);
            myTemperatureChartControl.AddPoint("yongyao", vp);
            vp = new ValuePoint();
            vp.Text = "已用阿扎司琼10mg PCIA";
            vp.ColorValue = "#333344";
            vp.Time = operStartTime.AddHours(1.03);
            myTemperatureChartControl.AddPoint("zhixing", vp);


            vp = new ValuePoint();
            vp.Text = "曲马多1000mg";
            vp.ColorValue = "#ff3333";
            vp.Time = operStartTime.AddHours(2.3);
            myTemperatureChartControl.AddPoint("yongyao", vp);
            vp = new ValuePoint();
            vp.Text = "过敏|曲马多";
            vp.ColorValue = "#ff0000";
            vp.Time = operStartTime.AddHours(2.4);
            myTemperatureChartControl.AddPoint("zhixing", vp);


            vp = new ValuePoint();
            vp.Text = "葡萄糖120g";
            vp.ColorValue = "#4444FF";
            vp.Time = operStartTime.AddHours(7);
            myTemperatureChartControl.AddPoint("yongyao", vp);
            vp = new ValuePoint();
            vp.Text = "葡萄糖120g";
            vp.ColorValue = "#FF0000";
            vp.Time = operStartTime.AddHours(9);
            myTemperatureChartControl.AddPoint("zhixing", vp);


            vp = new ValuePoint();
            vp.TagValue = "临床路径类型";
            vp.Text = "预约：口服头孢";
            vp.Title = "临床路径预约：口服头孢，一日三次，一次2片。";
            vp.ColorValue = "#999999";
            vp.Link = "预约：口服头孢";
            vp.Time = operStartTime.AddHours(37);
            myTemperatureChartControl.AddPoint("yongyao", vp);

            vp = new ValuePoint();
            vp.TagValue = "临床路径类型";
            vp.Text = "预约：氨茶碱";
            vp.Title = "临床路径预约：氨茶碱";
            vp.ColorValue = "#999999";
            vp.Link = "预约：氨茶碱";
            vp.Time = operStartTime.AddHours(77);
            myTemperatureChartControl.AddPoint("yongyao", vp);

            vp = new ValuePoint();
            vp.TagValue = "临床路径类型";
            vp.Text = "预约：卸支架";
            vp.Title = "临床路径预约：卸肘关节支架";
            vp.ColorValue = "#999999";
            vp.Link = "预约：卸支架";
            vp.Time = operStartTime.AddHours(110);
            myTemperatureChartControl.AddPoint("yongyao", vp);

            vp = new ValuePoint();
            vp.TagValue = "临床路径类型";
            vp.Text = "预约：远程会诊";
            vp.Title = "临床路径预约：美国刘博士远程会诊";
            vp.ColorValue = "#999999";
            vp.Link = "预约：远程会诊";
            vp.Time = operStartTime.AddHours(150);
            vp.EndTime = vp.Time.AddHours(1);
            myTemperatureChartControl.AddPoint("yongyao", vp);

            vp = new ValuePoint();
            vp.Text = "乳酸钠林格氏液500ml ivgt";
            vp.ColorValue = "yellow";
            vp.Time = operStartTime.AddHours(1.2);
            vp.EndTime = operStartTime.AddHours(4);
            myTemperatureChartControl.AddPoint("suye", vp);

            // 添加病历文档
            vp = new ValuePoint();
            vp.Time = startDate.AddHours(12);
            vp.Text = "门诊病历";
            vp.Link = "TimeLineTest\\Files\\门诊病历.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = xt1EndTime;
            vp.Text = "血透记录";
            vp.Link = "TimeLineTest\\Files\\血透记录1.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = xt2EndTime;
            vp.Text = "血透记录";
            vp.Link = "TimeLineTest\\Files\\血透记录2.xml";
            vp.LinkTarget = "EMR";
            vp.ID = "aaa";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = inTime.AddHours( 2 );
            vp.Text = "入院记录";
            vp.Link = "TimeLineTest\\Files\\入院记录.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = inTime.AddHours(4);
            vp.Text = "首次病程";
            vp.Link = "TimeLineTest\\Files\\首次病程.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = operStartTime.AddHours(-1);
            vp.Text = "术前讨论";
            vp.Link = "TimeLineTest\\Files\\术前讨论.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = operStartTime.AddHours(3);
            vp.Text = "麻醉护理记录单";
            vp.Link = "TimeLineTest\\Files\\麻醉护理记录单.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = operEndTime.Date.AddDays(1).AddHours(9);
            vp.Text = "手术记录";
            vp.ColorValue = "#ff9999";
            vp.Title = "不及时填写，扣5分。";
            vp.Link = "TimeLineTest\\Files\\手术记录.xml";
            vp.LinkTarget = "EMR";
            myTemperatureChartControl.AddPoint("wendang", vp);

            
            vp = new ValuePoint();
            vp.Text = "右下腹,直径10mm";
            vp.ColorValue = "#cccccc";
            vp.Link = "TimeLineTest\\Files\\护理记录单.xml";
            vp.LinkTarget = "EMR";
            vp.Time = operStartTime.AddHours(1.5);
            vp.EndTime = operStartTime.AddHours(50);
            myTemperatureChartControl.AddPoint("fuguan", vp);

            // 刷新文档内容
            myTemperatureChartControl.RefreshView();
        }
         
    }
}
