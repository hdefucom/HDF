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
    public partial class ctlFillDynamic : UserControl
    {
        public ctlFillDynamic() 
        {
            InitializeComponent();
            // 加载注册码
            myTemperatureChartControl.SetRegisterCode(DCSoft.Writer.WinFormDemo.Properties.Settings.Default.TimeLineRegisterCode);
       }
         
         
        private void btnDesigner_Click(object sender, EventArgs e)
        {
            myTemperatureChartControl.RunDesigner();
        }
         
        private void btnFillCrossThread_Click(object sender, EventArgs e)
        {
            // 设置文档配置
            myTemperatureChartControl.DocumentConfigXml = @"
<TemperatureDocumentConfig xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
   <Images />
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
   <Ticks>
      <Tick Value='2' Text='2' ColorValue='Red' />
      <Tick Value='6' Text='6' ColorValue='Red' />
      <Tick Value='10' Text='10' />
      <Tick Value='14' Text='14' />
      <Tick Value='18' Text='18' />
      <Tick Value='22' Text='22' ColorValue='Red' />
   </Ticks>
   <SymbolSize>22</SymbolSize>
   <BigVerticalGridLineColorValue>Black</BigVerticalGridLineColorValue>
   <GridLineColorValue>#E0E0E0</GridLineColorValue>
   <Title>眼科医院</Title>
   <HeaderLabels>
      <Label Title='姓名' Value='李四' />
      <Label Title='性别' Value='女' />
      <Label Title='病区' Value='胸外科' />
      <Label Title='住院号' Value='000134' />
      <Label Title='住院日期' Value='2014年07月18日' />
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
      <Line Name='zhuangtai2' Title='状态' ShowBackColor='true' LayoutType='Free' TickStep='6' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis Name='tiwen' AllowOutofRange='true' EnableLanternValue='true' LanternValueTitle='物理降温' Title='体温' ValueFormatString='0.0' RedLineValue='37' MaxValue='42' MinValue='34' SymbolStyle='Cross' SymbolColorValue='Blue'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='maibo' HollowCovertTargetName='tiwen' ShadowName='xinlv' Title='脉搏' MaxValue='180' MinValue='20'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='xinlv' Title='心率' MaxValue='180' MinValue='20'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='yanya' Title='眼压' MaxValue='40' SymbolColorValue='Green'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='shili' Title='视力' MaxValue='5.2' SymbolStyle='HollowCicle' SymbolColorValue='Blue'>
         <DataSource />
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
      <YAxis Name='wenben' Style='Text' Title='文本内容' SymbolColorValue='Blue'>
         <DataSource />
         <Scales />
      </YAxis>
   </YAxisInfos>
</TemperatureDocumentConfig>
";
            myTemperatureChartControl.ClearData();
            this._StopThread = false;
            Timer tmr = new Timer();
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Interval = 100;
            tmr.Start();
            System.Threading.Thread thr = new System.Threading.Thread(this.FillDataCrossThread);
            thr.Start();
            btnStopThread.Enabled = true;
            btnFillCrossThread.Enabled = false;
        }


        private void btnStopThread_Click(object sender, EventArgs e)
        {
            this._StopThread = true;
            btnStopThread.Enabled = false;
            btnFillCrossThread.Enabled = true;
            myTemperatureChartControl.RefreshView();
        }

        private volatile bool _StopThread = false;

        void FillDataCrossThread()
        {
            DateTime currentTime = DateTime.Now;
            DateTime lastDate = currentTime.Date;
            Random rnd = new Random();
            int iCount = 0;
            while (_StopThread == false && this.Visible )
            {
                System.Threading.Thread.Sleep(100);
                if (_StopThread)
                {
                    break;
                }
                lock (myTemperatureChartControl)
                {
                    currentTime = currentTime.AddHours(5);
                    iCount++;
                    if (lastDate != currentTime.Date && currentTime.Hour == 8)
                    {
                        // 填充按天计算的数值
                        myTemperatureChartControl.AddPointByTimeText(
                            "xiaobian",
                            currentTime,
                            "1000");
                        myTemperatureChartControl.AddPointByTimeText("dabian", currentTime, "3");
                        myTemperatureChartControl.AddPointByTimeText("xuya", currentTime, "90/120");
                        myTemperatureChartControl.AddPointByTimeText("tizhong", currentTime, "80");
                    }

                    // 呼吸

                    // 填充呼吸次数
                    float v5 = TemperatureDocument.GenerateTestValue("呼吸", 10, 60);
                    string txt = float.IsNaN(v5) ? "" : Convert.ToInt32(v5).ToString();
                    if (rnd.NextDouble() < 0.1)
                    {
                        // 小概率表示呼吸机呼吸
                        txt = "R";
                    }
                    myTemperatureChartControl.AddPointByTimeText(
                        "huxi",
                        currentTime,
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
                    myTemperatureChartControl.AddPointByTimeValueLandernValue(
                        "tiwen",
                        currentTime,
                        v,
                        v2);

                    v = TemperatureDocument.GenerateTestValue("脉搏", 20, 180);
                    myTemperatureChartControl.AddPointByTimeValue(
                        "maibo",
                        currentTime,
                        v);
                    v2 = v;
                    if (rnd.NextDouble() > 0.4)
                    {
                        // 有概率心率超过脉搏
                        v2 = (float)Math.Min(180, v + rnd.NextDouble() * 10);
                    }
                    myTemperatureChartControl.AddPointByTimeValue(
                        "xinlv",
                        currentTime,
                        v2);

                    // 眼压

                    myTemperatureChartControl.AddPointByTimeValue(
                        "yanya",
                        currentTime,
                        TemperatureDocument.GenerateTestValue("眼压", 0, 40));
                    // 视力
                    myTemperatureChartControl.AddPointByTimeValue(
                        "shili",
                        currentTime,
                        TemperatureDocument.GenerateTestValue("视力", 0, 5.2f));

                    // 添加随机的状态改变
                    if (rnd.NextDouble() < 0.04)
                    {
                        switch (rnd.Next(0, 4))
                        {
                            case 0:
                                myTemperatureChartControl.AddPointByTimeTextColor(
                                    "zhuangtai2",
                                    currentTime,
                                    "重症监护Z1",
                                    "#FF1493");
                                break;
                            case 1:
                                myTemperatureChartControl.AddPointByTimeTextColor(
                                    "zhuangtai2",
                                    currentTime,
                                    "1级护理A1床",
                                    "#FF00FF");
                                break;
                            case 2:
                                myTemperatureChartControl.AddPointByTimeTextColor(
                                    "zhuangtai2",
                                    currentTime,
                                    "2级护理A1床",
                                    "#ff9999");
                                break;
                            case 3:
                                myTemperatureChartControl.AddPointByTimeTextColor(
                                   "zhuangtai2",
                                   currentTime,
                                   "3级护理B3床",
                                   "#00ff7f");
                                break;
                            case 4:
                                myTemperatureChartControl.AddPointByTimeTextColor(
                                    "zhuangtai2",
                                    currentTime,
                                    "请假",
                                    "#aaaaaa");
                                break;
                        }
                    }
                }
            }//while
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            lock (myTemperatureChartControl)
            {
                myTemperatureChartControl.RefreshView();
                myTemperatureChartControl.ScrollViewToLast();
                if (this._StopThread)
                {
                    Timer tmr = (Timer)sender;
                    tmr.Stop();
                    tmr.Dispose();
                }
            }
        }
         

    }
}
