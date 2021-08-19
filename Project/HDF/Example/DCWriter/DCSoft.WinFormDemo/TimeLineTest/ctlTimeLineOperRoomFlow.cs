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

namespace DCSoft.Writer.WinFormDemo.TimeLineTest
{
    [System.ComponentModel.ToolboxItem(false)]
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class ctlTimeLineOperRoomFlow : UserControl
    {
        public ctlTimeLineOperRoomFlow() 
        {
            InitializeComponent();
            myTemperatureChartControl.EventValuePointClick 
                += new ValuePointClickEventHandler(myTemperatureChartControl_EventValuePointClick);
            myTemperatureChartControl.EventDocumentDblClick
                += new DocumentDblClickEventHandler(myTemperatureChartControl_EventDocumentDblClick);
            // 加载注册码
            //myTemperatureChartControl.SetRegisterCode(DCSoft.Writer.WinFormDemo.Properties.Settings.Default.TimeLineRegisterCode);
       }

        void myTemperatureChartControl_EventDocumentDblClick(object eventSender, DocumentDblClickEventArgs args)
        {
            MessageBox.Show("用户双击事件");
        }
         

        void myTemperatureChartControl_EventValuePointClick(object eventSender, ValuePointClickEventArgs args)
        {
            System.Console.WriteLine("点击了 " + args.SerialTitle + " " + args.Point.Value + " " + args.Point.Text );
        }
         
        private void btnDesigner_Click(object sender, EventArgs e)
        {
            myTemperatureChartControl.RunDesigner();
        }
         
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            myTemperatureChartControl.DocumentConfigXml = @"
<TemperatureDocumentConfig xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
   <DataGridTopPadding>0.1</DataGridTopPadding>
   <DataGridBottomPadding>0.1</DataGridBottomPadding>
   <Images />
   <PageIndexText>第[%pageindex%]页</PageIndexText>
   <SpecifyStartDate />
   <SpecifyEndDate />
   <PageSettings>
      <PaperSizeName>custom</PaperSizeName>
      <LeftMargin>50</LeftMargin>
      <TopMargin>50</TopMargin>
      <RightMargin>50</RightMargin>
      <BottomMargin>50</BottomMargin>
      <Landscape>true</Landscape>
   </PageSettings>
   <FooterDescription />
   <PageTitlePosition>BottomRight</PageTitlePosition>
   <Zones />
   <Ticks>
      <Tick Value='0' Text='0' ColorValue='Red' />
      <Tick Value='1' Text='1' ColorValue='Red' />
      <Tick Value='2' Text='2' ColorValue='Red' />
      <Tick Value='3' Text='3' ColorValue='Red' />
      <Tick Value='4' Text='4' ColorValue='Red' />
      <Tick Value='5' Text='5' ColorValue='Red' />
      <Tick Value='6' Text='6' ColorValue='Red' />
      <Tick Value='7' Text='7' ColorValue='Red' />
      <Tick Value='8' Text='8' ColorValue='Red' />
      <Tick Value='9' Text='9' />
      <Tick Value='10' Text='10' />
      <Tick Value='11' Text='11' />
      <Tick Value='12' Text='12' />
      <Tick Value='13' Text='13' />
      <Tick Value='14' Text='14' />
      <Tick Value='15' Text='15' />
      <Tick Value='16' Text='16' />
      <Tick Value='17' Text='17' />
      <Tick Value='18' Text='18' ColorValue='Red' />
      <Tick Value='19' Text='19' ColorValue='Red' />
      <Tick Value='20' Text='20' ColorValue='Red' />
      <Tick Value='21' Text='21' ColorValue='Red' />
      <Tick Value='22' Text='22' ColorValue='Red' />
      <Tick Value='23' Text='23' ColorValue='Red' />
   </Ticks>
   <SymbolSize>22</SymbolSize>
   <BigVerticalGridLineColorValue>Black</BigVerticalGridLineColorValue>
   <GridLineColorValue>#E0E0E0</GridLineColorValue>
   <Title>市人民医院手术室排程</Title>
   <HeaderLabels>
      <Label Title='手术室排程负责人' Value='王小二' />
      <Label Title='手术室电话：' Value='12345678' />
      <Label Title='报告时间' Value='2014-09-08 10:28:14' />
   </HeaderLabels>
   <NumOfDaysInOnePage>5</NumOfDaysInOnePage>
   <HeaderLines>
      <Line Title='日期'>
         <DataSource />
         <Scales />
      </Line>
      <Line LoopTextList='上午,下午' Title='' TickStep='12' ValueType='TickText'>
         <DataSource />
         <Scales />
      </Line>
      <Line Title='时刻' ValueType='HourTick'>
         <DataSource />
         <Scales />
      </Line>
   </HeaderLines>
   <FooterLines>
      <Line Name='room1' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室1' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='room2' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室2' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='room3' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室3' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='room4' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室4' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='room5' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室5' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='room6' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室6' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='room7' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室7' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='room8' ExtendGridLineType='Above' VerticalLineForFreeeLayout='false' Title='手术室8' SpecifyHeight='100' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis Name='shiyonglv' AllowOutofRange='true' EnableLanternValue='true' LanternValueTitle='' Title='使用率' ValueFormatString='0.0' ShowLegendInRule='false' SymbolStyle='Cross' BottomTitle='百分比' TitleColorValue='Blue' SymbolColorValue='Blue'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='blood' AllowOutofRange='true' Title='用血量' MaxValue='8000' ShowLegendInRule='false' BottomTitle='毫升' TitleColorValue='Red'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='renshu' AllowOutofRange='true' EnableLanternValue='true' LanternValueTitle='' Title='医护人数' ValueFormatString='0.0' MaxValue='80' ShowLegendInRule='false' SymbolStyle='HollowCicle' BottomTitle='个' SymbolColorValue='Black'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='wenben' Style='Text' Title='文本内容'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='timearea' Style='Background' Title='时间范围' SymbolColorValue='Black'>
         <DataSource />
         <Scales />
      </YAxis>
   </YAxisInfos>
</TemperatureDocumentConfig>";
            myTemperatureChartControl.ClearData();

            DateTime curTime = DateTime.Now;
            myTemperatureChartControl.CaretDateTime = curTime;
            myTemperatureChartControl.SetHeaderLableValue("报告时间", curTime.ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime startTime = curTime.AddDays(-5).Date ;
            DateTime maxTime = DateTime.MinValue;
            Random rnd = new Random();
            List<List<ValuePoint>> allValues = new List<List<ValuePoint>>();
            for (int iCount = 1; iCount <= 8; iCount++)
            {
                DateTime rt = startTime;
                List<ValuePoint> list = new List<ValuePoint>();
                allValues.Add(list);
                while (true)
                {
                    ValuePoint vp = new ValuePoint();
                    // 手术开始时间
                    DateTime dtm2  = rt.AddHours(0.5 + rnd.NextDouble());
                    vp.Time = dtm2;
                    if (vp.Time.Hour < 7)
                    {
                        // 每天早上7点上班
                        vp.Time = vp.Time.Date.AddHours(7);
                    }
                    else if (vp.Time.Hour > 20)
                    {
                        // 每天晚上20点下班,挪到下一天7点
                        vp.Time = vp.Time.Date.AddDays(1).AddHours( 7 );
                    }
                    // 手术结束时间,手术时间长度为1到21之间的随机数
                    vp.EndTime = vp.Time.AddHours(1 + rnd.NextDouble() * 20);

                    rt = vp.EndTime;
                    bool dead = vp.EndTime < curTime && rnd.NextDouble() < 0.05;
                    if (dead)
                    {
                        // 小概率死亡
                        vp.Color = Color.Red ;
                    }
                    else
                    {
                        vp.Color = Color.LightGreen ;
                    }
                    if (vp.Time > curTime)
                    {
                        vp.Color = Color.LightGray ;
                    }
                    string name = DCSoft.Common.TestValueGenerator.GenerateName((iCount % 2) == 0);
                    vp.Text = name + "|";
                    switch (rnd.Next(0, 3))
                    {
                        case 0:
                            vp.Text = vp.Text + "华佗,\r\n重度脑残症,开颅术";
                            break;
                        case 1:
                            vp.Text = vp.Text + "孙思邈,\r\n冠心病+缺心眼,搭桥术";
                            break;
                        case 2:
                            vp.Text = vp.Text + "李时珍\r\n伤寒,灌肠术";
                            break;
                    }
                    TimeSpan span = vp.EndTime - vp.Time;
                    vp.Title = vp.Text + "\r\n耗时 " + span.TotalHours.ToString("0.0") + " 小时";
                    if (dead)
                    {
                        vp.Title = vp.Title + " 死亡";
                    }
                    list.Add(vp);
                    myTemperatureChartControl.AddPoint("room" + iCount, vp);
                    if (dead)
                    {
                        // 添加死亡说明
                        myTemperatureChartControl.AddPointByTimeText("wenben", vp.EndTime,  name + " 死亡");
                    }
                    if (maxTime == DateTime.MinValue || maxTime < vp.EndTime )
                    {
                        maxTime = vp.EndTime;
                    }
                    if (vp.Time > curTime.AddDays(5))
                    {
                        break;
                    }
                }//while
            }//for
            // 计算手术室使用率
            Random rnd2 = new Random();
            for (DateTime dtm = startTime; dtm <= maxTime; dtm = dtm.AddHours(1))
            {
                int numCount = 0;
                float blood = 0;
                float renshu = 0;
                foreach (List<ValuePoint> list in allValues)
                {
                    foreach (ValuePoint vp in list)
                    {
                        if (dtm >= vp.Time && dtm <= vp.EndTime)
                        {
                            numCount++;
                            // 累计用血量
                            if (rnd2.NextDouble() < 0.2)
                            {
                                // 小概率用血
                                blood = blood + rnd2.Next(1, 20) * 100;
                            }
                            // 人数
                            renshu = renshu + rnd2.Next(3, 10);
                            break;
                        }
                    }
                }
                myTemperatureChartControl.AddPointByTimeValue("shiyonglv", dtm, (float)numCount * 100f / (float)allValues.Count);
                myTemperatureChartControl.AddPointByTimeValue("renshu", dtm, renshu);
                myTemperatureChartControl.AddPointByTimeValue("blood", dtm, blood);
            }
            ValuePoint vp3 = new ValuePoint();
            vp3.Time = curTime;
            vp3.Color = Color.LightGray  ;
            vp3.Text = " ";
            myTemperatureChartControl.AddPoint("timearea", vp3);
            myTemperatureChartControl.RefreshView();
        }

    }
}
