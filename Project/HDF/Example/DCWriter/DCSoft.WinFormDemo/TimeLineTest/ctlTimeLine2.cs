﻿using System;
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
    public partial class ctlTimeLine2 : UserControl
    {
        public ctlTimeLine2() 
        {
            InitializeComponent();
            myTemperatureChartControl.EventValuePointClick 
                += new ValuePointClickEventHandler(myTemperatureChartControl_EventValuePointClick);
            myTemperatureChartControl.EventDocumentDblClick
                += new DocumentDblClickEventHandler(myTemperatureChartControl_EventDocumentDblClick);
            // 加载注册码
            myTemperatureChartControl.SetRegisterCode(DCSoft.Writer.WinFormDemo.Properties.Settings.Default.TimeLineRegisterCode);
       }

        void myTemperatureChartControl_EventDocumentDblClick(object eventSender, DocumentDblClickEventArgs args)
        {
            MessageBox.Show("用户双击事件");
        }


        private void btnFillSimple_Click(object sender, EventArgs e)
        {
            FillData(30000);
        }

        private void btnFill100000_Click(object sender, EventArgs e)
        {
            FillData(300);
        }
        private void FillData( int totalDays )
        {
            // 设置文档配置
            myTemperatureChartControl.DocumentConfigXml = @"
<TemperatureDocumentConfig xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' Version='1.0'>
   <DataGridTopPadding>0.1</DataGridTopPadding>
   <DataGridBottomPadding>0.1</DataGridBottomPadding>
   <Images />
   <Labels>
      <Label Text='体温单演示' Left='950' Top='170' Width='300' Height='80'>
         <Font>
            <Size>12</Size>
         </Font>
      </Label>
      <Label Text='' Left='200' Width='150' Height='150'>
         <Image>
            <ImageDataBase64String> iVBORw0K GgoAAAAN SUhEUgAA AGAAAABg CAYAAADi mHc4AAAA AXNSR0IA rs4c6QAA AARnQU1B AACxjwv8 YQUAAAAJ cEhZcwAA CxIAAAsS AdLdfvwA AAAZdEVY dFNvZnR3
 YXJlAFBh aW50Lk5F VCB2My41 LjlAPLDL AAAgfUlE QVR4Xu1d eXxV1bU+ 5+a/aiWB V1txIKi1 jhCqrVCF DMo8hUlB wIRR0UCC IlqrBNSW qggBwYEK YbAtCgpV BhEFtGqt
 FaG2fc4i fVqtdZ7q 63u63vrW 3uvcfc49 N/feDIS+ H/m5fyfk njutb43f WnvrEZF3 cLWeDA4K v5UV8CAA BwFoPfM/ EFzv/xsL mLN0K9Uu 3cLrIaq9 YzPNXrqJ Zt+5hWV8
 YAP8bwXA gnufpIqf rqOi8beS d/bV5J31 Y15Xkvej meR3m0le 18vJ++Fl svwfVJN3 xjTyvj+V 8rpMJa/o Ukp0vpi6 j59HFT9Z QfXrnzog wDngARh7 4wYqGPAz 8kpmkV86
 i7zia8nv wav4GvJ6 /ISBuIoB MEAkukZB mC4g+Kfz YiC8okvI 73wJeZ2m kHfaxZQ4 dTJ1GVpL NXN/3Wpg HJAAVNz8 ALUbchN5 51zH6wby ymrJK50j V7+0lhLF SSASPQwQ
 PoCANfBy rcH/AUCo Ia9LlVgD rgAB1tB5 2PVUWjmP Ovbk55xY QUVDrqHl 9z2+X8E4 YABYtnU3 FY5dTF5P 1nasXlgs fKxzrzcL gAAICwas QiwisIak W3JBSJxh QGhbfBVV
 z1tHO599 EUIOfr7m 3/a++S6V XcjveUIF FZZMp9kL 1+8XIFod gPkbnqXj Ku8kv89N lNfnRr7+ XJbXey55 fXgpIHz1 e1owAASs QlfJ7AAI vzu7JYkN V5DX7Qp2 SzOoY/kN
 VL/pGfqK IGrz8/XX yd+TfyM6 9twZ5H3v QvKPH0OF PWrorrU7 WxSIVgUg f0Qdef1u jl2JvjeS 19eAEQAS gHE9Jc5x LKKMLSFi DQCiba/Z tPCex+ir VFkzAhET sP9csOJh
 BqCSvOMv JO+7Y8jv eAGVjLqu xUBoFQBK rrqHvP7z yO83n68L yB9wCyV4 ef3x7/nk D2RQ+HGv L//NAQhW Ipah1iDu iV2SaxEl xiXVLNpC H37y3yFX k80/tj/z InknMgDs
 igCAd9xo 8o89n/I7 jaf6dTua HYj9CkD1 nTtY2AvI G8iCHcTa H10D+TH8 DY/zSjA4 AgRWChBs IRaMID6w S8ofeANt 3703VdYp VsAOKcYN AQD/xHHG Ck4Ya0EY RV7H88nr
 cB5VXn5r s4Kw3wAo qr47LPDB C8kbvIgX X8vZCsrt 7wCA/x2A Y0GBlYiF BEAgXliL sIG6+LKV 9MGn/8xG 0dPGgvmr tpF38kTy TrIgBFYw kvxCA0JR nxnNBkKL AzB//XOU
 N4iFDMGy sP3yW0XY 5soF1ZDw 8suXBPcE ADmWYoBI WkSi903k 95pLNbdt Syv4OE1P vdlYBIo0 /5RJAkDi BLaC70Wt YAR5xwyn 7/e+rFlA aFEAxi96 yAgdWj5k ESWg5Vbg
 /tDFhIV/ 6+/uNbhP wHKsw7oo F4jlW/8c K/zsBB9+ an636QYA WMHJaazg aAbh6CHU 6dzLmwxC iwFQVP1L 0XoRniNk b+ht5A27 nbzhvPjq D78jZcnj WHxvABIs Zoi1IgF1
 AeWfv4Se 3/tOxJd/ lZMLcm/e 8YdXyOt8 EXmnTpIq OSUWHMtu iBfcEKzA P2oYFfVs miW0CABd an4VuBkV vjdsiRHq iDvCa/hS BsNZ0ccV LGst3uDF lGBA2466 nZ579e+x
 gTQXBFwr Ka9hhQBV wTSFWMEp 400sQEZ0 /GiTEXFa KrGArQAA YJUOv6bR ltDsALQb zVrraL1q uQreH/EL 8s7DupO8 8++KX/K4 XQoILIdB yBu6hPLH 3EF7Xv9H LnLOeO9r
 b74X0BTC FbEVRIMx ijMXAFiB d+RQ8o4Y QjWz7mwU CM0KQP4F rEER4Qca rwKF0Efy GrXMrJH1 4RX83d4X AaLo8nvp w8++TB9w M4ravSHp ripqf2W4 ImZNDVk3 mRInm2Bs
 rMAG42PZ AiJuyG9f TolvD2hd ADIKH4K3 AvdHrSDv ArtGryTP Xfr3URaY UWwJeC4D UVBRT7v3 vhcRcVKI aYrb8P32 JlyUmti5 6zVD2Dlk HdyQdyrH A01J3cLM cUOJo40F
 eO0HU8EJ I3IGoVks oOOEZek1 39V4V+hj VpE3Fmu1 veq/+TrG giL3L6PE qOXUdsLd IvxwPdX4 gCuo8Ivh 9TqP5qoc rKkFALS1 h1jAbsg/ dUKoJnDd kH8MB+Oj 1A0NJu/b
 A2n6NUtz AqHJACDb 0TRTMhYJ tOyvz+PA 6mi9aDw0 XQTPQr+Q CzNefgU/ 31nm7/Ye vjcxmi2B n7vrjQ/S Fk+uisfR PukehwXM +sVW28Ax vQPXDfmd LhIA/JM5 GLuVMbsh
 rYwTRyfj gP+dQeQd 3mf/ATCh bish46ld 8zTV/voZ qrx1J+VX ssCQ1Yjm 8+9wJTGC F0FXcqo6 jn1vdPHf A1DGrKbl j79qNT+e Psje7X9l 3A7/h+vz L78V7qRZ N5QoMj2D
 IBuCG4rw Q14h0xNO OuodMZgA gH/4QCot vzJrEJpk ATV3PRZx CUYUK3a+ RMdNWyOu QzQeq2K1 CFWEjjV+ LS8m5dIt gMIgTVj2 pHmPTKqd DQrOa3zw 8RdUVMl1 BZo43Mr0
 z+TFbUx0 z7Rpky4b iqajYgWI AwyC953+ 5H2rX8sD 0Gnq6liZ 6HcEBXzd /X9k4deT f6EVPoSq Ah+3hryJ 9/JaZ9ak ++zv/DcG x59wL3WZ /VCg+dnI N+M9DgCV P+P3s100
 vxv3AKSP 7Loh27pE Oqr1ALsh H9mQMKSW G9J6oD2C sYkDAKBs UHZ8UaMs oHD8XVTB 7geGnPoT /tuGZ9+k /Cks0PG/ TgpfBc9C T0xcT97k +83C7/w3 CL9N1Xp6 9d3Pm0fz
 Ix9y+ebn hLI2zRvb wkwBIJmO hgKxTUdd ALyjWPhS D7AbYhcE ALz/6J2V FeQMQM3S nUIV1/7q d1kFRdy0 e9+HlF/F GjeBQVBt n7yB/Ekb KHHxA+Rd /BtZ/kV8 5b8DjPnb
 Xo7B9usm e6Jdr7zD zZtrpYMm TX07VSET FSELuDQc B1ALSBxw 6gGuiJEJ +R2YG1IA JA6wG/qP XlTz49sy gpAzAMLn M8dTveyx zBavfDub /u6/fkQF 01jAovEs fAgbQp/C
 AEx5kPyL efHv/pQN VDr/CZMl Rvj6VEo/ 28Bggvfu V96m/EFM Y3NjPxYA jLRoJmSb 9yFaIgqA U5ApAB4y IbYA/1t9 qEPRmOYF oKiKgymo YAagx9Xr MgIQFeKK J98wruYi
 CNoI3rtk Iy++Vm2i xJSNlODf 977X/K7n /U++oM4X cXamjX21 AJkvMoE4 mCdKKcgc WsJp0gRu KKAkTCZk XFBf8tr1 al4AEn1v lvahsJyD FsWykPHN 7qSmVt/D gZkB8C5l
 oV/Kwq/a Qt60zbIS VZupZu1f jPY3U+KD 10KTpmgK Z2Ro3Gj7 UqcpAgC4 ia8DXS4A UV4oqIjR JeNCLCYV dQGY8/NV DYKQtQvq UMnFVV9u fsAFDahj br+O6h99 IWQFEH4s
 AM5d733x JRVew10n Ef4mFjwX QnYVXPUo vf/Zv+zd aarc2A57 emMEb1RU xUUgty99 NPUtAHBD Ms6i03Vd cwWA2VHb plRqGpxQ YAGwAraA 04snNR2A 2tW/Na1A NNJtDADp
 1v3a+wJt jYpAeZav v/7f5EPW EB7Y8w4l pkL4vKoZ gBqeROA1 Z8sroawn yu3k0mDB vR9+9k86 7ZLVBMsN +sdlc0wM wKQdALAW IHNEmgm5 lEQaZlRT 0bQWYAHw 2zbshrKy
 gHbD7PiI CwCaI8zL 7/jzW7Hq 11B4xGMl C582ms8A +NMf5bWN 3vv8X2EL Em3Plu8J 3wfN71K9 ivz+3Dfm 6Qq0LWXG iAe89icA XkHPpluA aE+MBQCA LjPuiQEg vdAUmPv3
 /N34frGA R2jwXXua 3FzRD4Je QYeJTBDC WvvZ0RZ8 B0zbaQxo rAU4rGjU BSkdITHA WgAAWHi7 eIpYZc9o AR3GcEsR H56HpACC uqCg08WN kgUb/5gS kDMliHi8 cNZ28qZy
 37h6C9U/ /aYDpAug +T1jSmqf /ejz/0Vt RnOzB4mC AMDuB59d R1hyAED4 INuiTKWl k6MqGgNC ANgsyGt7 Lk2/8vbG AyCZAwIY RkDwZbgI E/YTIyVo sDMAbSqW x/D0cZ4p
 bBkVKzkj QiCu2kh7 3/8iNDoY FbpkRUFd YEGJvEXd g38ynwmf TQAw2h8a XzmHxxgx 0pg2C0rS 0k0FAP4f AJT2n9Y4 ACpv4nQR ALDvlEDW j4sYm4aa eR6edBjC 0w3cWO9w
 yd0Ndqri 4Kj/3T6p AwpmKOcD KWcGLnmH AeJDzpyK Z3FRh0kL jLrwZ0sM tAAgc4Py yMCvk4Zi lBGVsB1t 99JlQdwZ C9qTIUY0 bAFuJaxp qAJQ3H96 4wBoV87T Z5hKxigg
 BmZtHAjN +AQ9gDuo 0xX30Uef /09sUI4L pjteelcK suL5Dq3h PDubrGf7 X95iC2Tq m/sQogwW AJlFwmSd AMCfXaes dbIaFgAu KADAbu5I UwlLTyBS CbsxIB0A fsG5VNBh
 UOMA8Mt4 CtkCYOIA axIqYTut Fsz5YLwE TXZuG3aZ uZ5BcGYy GwgG21/8 u1ASRTfI BHLoJ5Pw 33j3Uxp2 C9cT6Bmj cY9GkMwc Gfcj4412 gCsEACap 7SBvYAG8 wybYXeM0
 ZbQnICMq jQTAyz+X vPxzcgdg 7FzmbKAt CFowX82E JBDb2U7r hsT02Q1B EP7IZVRY tYaeeyPa u001jPnb eBAW3BAv tZxMwRv3 1a59jtpM 4K4amj4i fJ6mC8ZW zBSe+v8g
 AMe5n0gN kHC5IKc5 705H+N+t kNF1acyj EAMNcfQw JuPKQ3Q0 2FC4oESb c8g/rCx3 AAoG/ZSD FftJAHAu /84pXBCI LR+EYIwZ nWQrkoWh 4ybcgJ+9 bnd89sJS hiALZzId
 Yanp2t/E T7cpbLCq 2vt2U5uJ 3ElDp802 6gV4WKD1 /5IgwALs HKlof9T/ uwFY9pcl +wHSkLHb mYKGjNMP SE5Mp+sH mIaMcEGc gkL7/TYl uQMgZops QQBIjQNB OqrjhhIL
 2A2hHQkQ MHpy/nI6 ZtpaWvDQ f9Jr734S mAB4/s6z uAaIdMNq frmLdr/x UXAfaOz6 375Ggxfs MI17HWHB dIXrenTE EdNzmJrj 9NPX+VF3 glr9P29r gv/3z0ol 4jJ2xLBv
 IGZAK0hB bUMGFhAA kKsF1K19 ivJ4H1Ze CQMQcUNq BQEAMnBr U1Jn8i1x XnIMBU11 fywvtCZt I960Jrk/ EOkHS9uS /5ZAo547 aTohIaMs ovlMqqnr sb7fzX5C +T+SBinA
 wtlPCgWh uyuD0ZRw L0Cb8tIN k2npUSmz QWhJmp6w tQDmgQQA dkGJXAHA VlD5kKBs s7ECuKLB jivC3Odw O/XGllB+ yyO04vFX mLZ4m3a+ 8DbVbX2B CqZwP9hO Rui1yzWb
 +LGX5J7t L74tllOx 9AnKn8Cg iPbb14SV OcI3ub/6 /qT2B+5H 95fF5P9J Dqg6ZSoC w1kh/2/b kZ4zFeH6 f5eK1hTU a1NGhaeM zM0FFVXy l0GODADg imAFTjYU igV2s4U7
 EZcYarKi 4jkPClcU ZDROhN21 7z1qN5n7 wqPNPFB5 3SNp0ldT Gmz4wxtU OpuLNjuq KO8xhBla R/ia+Qht rvvMLAMq GZ2b/TTQ B5C5ICHh nMEs3jcW 5/9jAzBr vwDAGRAC
 cEnfmtwA yDuL0zL+ gGIFMbFA MyL4WTcj ckFYuPH5 BtuH4Nmm rfq9zPzk MQiv/+NT C0DD5BsA Lb12fTjr CbSfq3Tx /fG7Z6LV L7Qf0xCy udvJ/3Uf cXwBljqg 67XniQg0
 Yr6t7qeP 9f+cgn6z lMr65VgJ m/22vNOw By9rBaJB TkrqWoHP /QEtzgpG L6Vde99P oRXi1Hs9 azXGFTtO jSP00hqE WNT9v3+d CifzoJcj fDfvF/ZT fT8s2NX+ SA8A6ad/
 uh1NdNJP 3aghBZhj AWlJuMMH hEg4uB9Y wNSZ6bc1 xZJx4hcB Ao9thGJB qdmdKI0N 4YcsQWdp 6oKRtzU4 tayuSK/Q ZtQNZXM2 x+9kbKAq xmt8+tkX MhxgNvjN o7x+rP29
 I9rPwjc7 7G0DRugH c7SBf6Zp wmAuVLOf pPtJnY6O jqMkp+Js KxKpJy/X /8MCFi1e m5sLwgcz O89hAT+W owFSXFEv tgiHpMs/ bxHtfu3d pNsJ/H16 lwIthk8H jyQ/OXa7
 FMhH/7SP 8odzNqZ+ XzXfZT7x HWQKgr8T lOtMXsEo SlL7Yyfi 4vy/3aAh FISMJHLu z2OJiXam AJMK2FoA f7O0rHPK A9fzqSN+ 1+nm3AXM zCBX7m4z IhsPohQF 3NHyh59P
 7zNCjwAQ A8r05U8a CoFXQyPn Db+wEnJf UvkcHvCy TRe4S228 eKGd9JgD MoWXan9o Ktp2wOB+ UtLPmB0y yfw/kn6i AGP34x2a vggDMCkA XMfDqlKS Y1xPXRFr jXFFXBcg
 ldPawDKl lfMezFL4 ydvALBdN v0cyGeTx yHL0JxMd 4b5ZaPc7 P1C76nES BXH8frq8 34wiNqD9 6XZK2mk4 1f4g/WzX R7QfBBy0 H+6n40nn p3U/sQDg jB0Z0RMQ 2EfK4BID
 gMpRQODF IPjg1VnL 8stv4Q3R qVtDAyGm DvOI/NC1 ktpB2MtF PGmXfpdj Vug671O/ Zbfl/Lni DSbg+DvA rQa0szOG qDNAjvbL pgwEXxRe WMr92CmI 0ByQZj+W /wH9oACM
 u2hubgDM uYPHRFAR 6rk7rhUE ILA/tYdm 4MviJ1Zr I111mZqw 0sRoY0Br cyaDDR6Z flK6YjEb rfU1ZAir P3NYcJ96 ikpXBgDf Cwp2Ohde 0eY7F16h vWH2zIho 8DW5P/t+
 OxEN3++2 IAEASDi4 n5V3b8oR gDs3iVnK gUdRV2Rr g4Qd7Ssc NT8s/CgK aXwJgrXs hOemibtb fvkjTMjl 4n9iEDOY mLiw5+W/ UX5ftlSd /zxzhrjX qOtJyfvV 9XDlC+Yz
 VPk6+8LE 9QTcj8l+ xP3AAtj9 +N/s3qDw Y10QjvsS zcBBR+KK OGDxB0fq ZlJTDsqc TQCEeWvj GykNajIL qPhK3kWp G67lfAgu 6Hh1HC+7 S3L+Sekd 8Hsojrte eosKenIa
 2k0n36zr Ob0qZQw9 yPvdPWHu JPQxPAPq TMEh+wmG ccH9WO4f wdf/ZjGd 1m1C7gAI Kjjc6HQX hGRQTvzI gADfuved D7MSliug +m3ct7XH DZg2J5rm dnKBf79l /R+C10xr
 DPaBbI1l z8tvUkHZ 1WTODbJ0 M76jUg7q eqJHFHyX N+TxfrDU wsvuBRDt 5+JLfT/3 f0G+Qfu9 Q3tQ3ZI1 jQQAH0xA MEAkg3Iy MwJflGkM MYoO/HLb YSxsjIeA pbTFHNJY
 PZam7dAF sUE9K6TT 3ITyApaQ X8o1gPp9 OTXL7IJJ 2ZLqHtLB O2FkXzC0 P+r7Ofj6 zviJcj/w /d4hmd1P rAvCH6UY QUkOIMQd ISZoZmRA qLyeqzv+ Ztlq4fuf fEnHjGba
 mlPXYEjK OYzJ5O8c NPlaveRh Blcn6rId zMoM0X3b 97Bi4Xsp 3ew03AO/ XxGQbsh8 AuFr4aU7 YaK8P7Sf XZAG3/JR V2fU/rQA YBbGL2LN EBCMycrB dxYEVMrY 3JZMQlRI
 8cL64GOe z5zETRo5 A84uPYYs csWpWAk+ A2j7H/9q Any2CDcg f/cllm94 Sr4bNuB5 2ICnBZcF AJy/7oQM XI+b92vm o8NXkcaL uh8IN5sV e1PJOOZU OCcOLEEP vAsC82VU
 M39DZpXj O15/52Pq PJ6pY53H QQ2B2Uwp lOyMjp4D Z68+XwtH 1fFUc+4H LqX7UC4I 42aZE1GC Qzkc4QcN F2cvsBt4 TeaTbDsm aYcSqXx9 FF8nD8tK +9NaQPXP uVOFvVGw
 BHVHAQgm Re08+ibz XdNoKP68 c9frdFhf Ju+0isYV xBgoDVlm QkEAQYWt f7cMbOXc +22caeru SPtRHXPq MowVwA26 gd939n9F Rs/dPWBh 329oB2Q+ 8P0r787+ wNhYC1j5
 wBNGOwAC Dq4Qd2Tj AgdmYQ7Z GtbvNPxP NBjv/dsH HCPuIcmY mEuS+RsQ YSiKcMQk qlOQY9p1 g8DtMn83 x475xVfT is27Ihxd I2NCRFFw SmLBD/k7 hU7GMsJP yXqi24+c
 yeeAdLOZ T8eTc9st n56lY+1w QRCXBCAQ xBCYeSV+ ME2Ogdzx 7Kus7a9R /cbfU8V1 a4TmRaA2 ADjLnnYr tIaCAmAi Kzj58Oyf UEGf2VJQ pfxAoLnG h8j96x9+ NnQ2XIhu
 kDOBzGko 0PyE7ICM uB7b81XS zTu0O61Y vTlr95PW BeGBonJ2 CTyOITsE sWUfAMTE BbUGqS41 U0K1iU6T JfSE1NNC zgVEf8d0 mk6oxTye 37s2JTXN KPuMNxhI h0zh6Tkc
 RWP7vHoU DQ5kCvge Z/tpiO9X xtNqf1mf qpyE3yAA dSu3GToW AQq+UtwR p21BXLAu yVqDm666 QAS0L0gw XtIICa0Z Qg+bFX0M E2t43uVU NOZmex5c asaVnvjL nCe8/9Hn
 lF/ESsZD VoHwbcoJ rRfNP5wX 3A44H6ff K3y/CD/7 vD+aGTWY KuXxcb7w kQIEXJJY Ay8AEVgD ijZ2Sxqk bcpqaodq 4V6E3k6z 1FKC3era o1UykP+d xwuvUXTB vGYv0gBR
 /drHrPB5 ys0K37cb r0Nbjjjl RMMFE89S 8YJytsKv nrkoZ+1v 0ALwYMlo Lo4QpEDL whIcl6QB WogsLA3S oHYjViHs qqSwxk1h NQiKvcfc yyBaCgHu bvBlDfFF jQvQSCJK
 RnBGJsJX 12PmfMTv Q/Mt3WDS TttsAeF2 SA9qe0R2 m7Kj2p8R ALkBXDhS NAChhxed MpESpzlu CeW8BSKU tjoBWwO3 933M3xhA 0i1hY+1K Po+LQTmK voqKJ84n FHfN+bPz
 qT+bgGtn PKPCh+vR STfl+sH3 eN84q1Ga r2BkrNY6 lrDWAgBU iDjQ9ESe j1EgQpkS u6UUIJTS sC4Kbspx Va5w0/6u z5Gq3NAj ALnziBvs ybiN03oF T5MpXLv0 4sRBK12X
 arDC9yXr MZ0udT01 M+taFgAc 5553PDOC 0hniq1gD xwR1Sxqk o2lrBAwI zViHA0og VBWuezX3 6nOCc//t 2f8eW2Dn 4XPog094 U3cz/MAN rVjDmwWd SjfRzmy2 FpLNCj9I
 Ob/RnYq6 jm2S8LNy QbipsJjd BeYh0ZzQ Fh02q7nx AWdsylmb bv0Asos5 F4DhABLE DRvIFZwA JI0ruHLW lTgVz7fE maWOlUbA /4Bh1wv7 +GO63WH+ Z5ZpqIvd Rx9/Hsr1
 k24n2eNV zW/bvm+T hZ81ALhR tuWjSjye ryEgbHxw Y4QG7JMM GEFBh1Q2 uiDY6Irc E7wGxsSR CGh6LBzO eMo/42JC UZWLzNNt ABk89jpK 8EEbRvic 8Tj9Xe8w phrY7zeX
 8HMCYPAk JujAjaNB gaIFnaI4 i1CrCLko k0HJshai Qs10FavS +XyNPXht mVbjpfGJ 3eT85VuE FnF7z9Fh sEzeqvZG 3n8QBFyj +UIxW+Ej 6OZa7cZl P1kHYffJ +Z24JrAH
 WLtAAIzA NWnWpC4q DhAVZDZX FbYKXITO 7k/JM7yf HqrKIJSM mkNwJeGf 7AP19ie4 ZyAbK5KD VdhgYTKe 7lS/quEm e0PCblQa Gn0SToyV 7hDOyMEW HVSQcE0A IWoVNl5o
 FiWCgwBz WSLsiMD1 dWGBulnC kmj4LDjr f8PWZ2Kn spPApIKC KLLjtzzS AuEfxjk+ Bqus5iPf b07Nb5QF 4Ek1c3h3 CgoWHNkI upaXWIV1 T1HLkOaG 66o0iAfB 3KS4gStx
 NTtyr7yO BVq6VVi2 Z6uWqWc3 4DP2GH4t 7dvnHm8c FnpcHFh+ 98MifG2s gF5ubrfj KnXGOiDO bMon8n5h FC2yQQ2s ISzCACGC UMtAU0OD t2Mlailx wISErMLG VQWudLHl
 blTwiaOM ZfodDINp iqqhzOUM pMppC+n1 vyaPOo7b rwDLQBAv HsCFolS4 ht8pOKJP i2h+oy1A n1jUm+mE I7lcxxdF s1qBsGC4 gLigqMtS YDJdAzAV XGt1gaaL SzQ7FQMa
 wfL3QVFl c/vBFdfT +s1PB4Fa Z4G1GJu/ mHcGocg6 hLMdDrYQ fq4+Pdf7 G2UBAQh8 dLsc14gv zCsJRtI6 XFcVBUUt pqGrujkj cBt/IHC7 XG0Pjo6U 4yMHCZOZ +A6zmEH/
 FoUVGM2e VDzwMqq+ agnNnruS aq5cTIWn 8c73w9jd INiy5hd1 rWhx4eeU hqZDttM5 0yivPZNW +NJHGCAU jMSR1joC gfFjOOpX rUVGPTIs R9jaIFH3 Iu+F3Sny 3liWQAN9
 rM0TbJqQ uX3O6UEl s/CDLCcf QVb9vXE5 3iHdaPoV TaMXcrGC JlmAvlFl NW+MthqH U6PE9HG1 YEBIqqly PdL8zw8C gMSFmRW6 z/rypMDt awYCN4KX 3Yl2TFAm 1XSjhD0+
 EhovLGaQ XhoqOZnl nC3CLzxp 6H7R+iYH 4TiE637x G6N1TGIZ gbDmOZop v7dn4UBQ 0FTw7QpQ 5IrH5Pgv C2bItVj3 Iq8PwgzD UXpWp7ga M6kmxZQ2 T1TwtqoV wSuhxrl9
 3iE/opor Gsfn56Lt zVIHZHrD 487gaheC EDBcQIyW iqaqhUQ0 OQmYuhTT kXI1XF8X +3GDPbl2 ZzqOigwJ PSR4MzYS CF58fTE1 po2YSQa5 PN4sLij6 hrNv+iUl ICAIRM7Q
 7Cf/Fu20 WqvgmH+7 S4EzV9Xu kLD1KABo uvp2TCZb N2MmlE3X CkIXKkE1 3gbZwpOG 0/IcG+i5 CDbbe1sE AH3ziiqe fGZiS4CA X1bBaVaS 5VVmcIJA arRcNT3w 7dwmFMrY
 uhk9JCMk +G+czX5+ OOf1G/e7 r08HSIsC EATpS29O MoxgGkVr IUjT6ktZ VsAqaFfY gcAD9wLB W7rYBlb/ MKPxiUOx MCx1Fg0d md2sZraa 21z37RcA 9MPiENOO nZlOgPDs
 kk0NkeU+ Lr+jCe76 c9FyXgXa m7W+PeJm evSeRgsW Zx4Rby5h NuZ19isA 7gecwwVQ 2QDuDUOY 6RaCJlqA zpIRQA2m EDiTZahe /UPOlpnM cZN/lnFb UGME1VLP aTUAol+o
 7rZ1UpWW 9ZtOxX2q qeCY/kke HoKWLT+l 8necvVDa d6rsQG9o E3RLCa05 X/eAAaA5 v9S/02sd BIAp9tYE rFXfvDW/ +IHy3gcB OGgBresC WtsSDlpA K1vA/wH0 te/2LYof
 jwAAAABJ RU5ErkJg gg==</ImageDataBase64String>
         </Image>
      </Label>
   </Labels>
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
   <Zones />
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
   <Title>南京都昌信息科技有限公司</Title>
   <SpecifyTitleHeight>300</SpecifyTitleHeight>
   <HeaderLabels>
      <Label Title='姓名' ParameterName='name' Value='' />
      <Label Title='性别' ParameterName='sex' Value='' />
      <Label Title='病区' ParameterName='section' Value='' />
      <Label Title='住院号' ParameterName='id' Value='' />
      <Label Title='住院日期' ParameterName='indate' Value='' />
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
      <Line LoopTextList='上午,下午' Title='' TickStep='3' ValueType='TickText'>
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
      <Line Name='huaxueyaopin' Title='化疗药品' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='mazuiyaopin' Title='麻醉药品' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='xiongguan' Title='胸管' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis Name='tiwen' AllowOutofRange='true' EnableLanternValue='true' LanternValueTitle='物理降温' Title='体温' ValueFormatString='0.0' RedLineValue='37' MaxValue='42' MinValue='34' SymbolStyle='Cross' BottomTitle='摄氏' SymbolColorValue='#0000FF'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='maibo' HollowCovertTargetName='tiwen' ShadowName='xinlv' Title='脉搏' MaxValue='180' MinValue='20' BottomTitle='次/分' TitleColorValue='#FF0000'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='xinlv' Title='心率' MaxValue='180' MinValue='20'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='yanya' Title='眼压' MaxValue='40' SymbolColorValue='#008000'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='shili' Title='视力' MaxValue='5.2' SymbolStyle='HollowCicle' SymbolColorValue='#0000FF'>
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
      <YAxis Name='wenben' Style='Text' Title='文本内容'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='wenben2' Style='Text' Title='文本内容2' SymbolColorValue='#000000'>
         <DataSource />
         <Scales />
      </YAxis>
   </YAxisInfos>
</TemperatureDocumentConfig>
";
            myTemperatureChartControl.ClearData();
            DateTime startDate = DateTime.Today.AddDays(-18);
            
            // 设置病人基本信息
            myTemperatureChartControl.SetParameterValue("name", "李四");
            myTemperatureChartControl.SetParameterValue("sex", "女");
            myTemperatureChartControl.SetParameterValue("section", "胸外科");
            myTemperatureChartControl.SetParameterValue("id", "000134");
            myTemperatureChartControl.SetParameterValue("indate", startDate.ToString("yyyy年MM月dd日"));


            // 添加数据
            // 总计的天数
            //int totalDays = 30000;
            // 页脚标题行 **********
            // 填充小便数据
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                myTemperatureChartControl.AddPointByTimeText(
                    "xiaobian",
                    startDate.AddDays(iCount),
                    "1000");
            }
            // 填充大便次数
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                myTemperatureChartControl.AddPointByTimeText("dabian", startDate.AddDays(iCount), "3");
            }


            //  液入量
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                myTemperatureChartControl.AddPointByTimeText("ruliang", startDate.AddDays(iCount), "800");
            }

            // 血压
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                myTemperatureChartControl.AddPointByTimeText("xuya", startDate.AddDays(iCount), "90/120");
            }

            // 血压
            for (int iCount = 0; iCount < totalDays; iCount++)
            {
                myTemperatureChartControl.AddPointByTimeText("tizhong", startDate.AddDays(iCount), "80");
            }

            Random rnd = new Random();


            // 中间数值信息 ********************
            int enterIndex = 2;
            // 体温
            for (int iCount = enterIndex; iCount < totalDays * 6; iCount++)
            {
                // 添加数据
                // 呼吸
                if (iCount > 20 && iCount < totalDays * 5)
                {
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
                        startDate.AddHours(iCount * 4 + 1),
                        txt);

                }
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
                    startDate.AddHours(iCount * 4 + 1),
                    v,
                    v2);
            }
            // 脉搏和心率
            for (int iCount = enterIndex; iCount < totalDays * 6; iCount++)
            {
                float v = TemperatureDocument.GenerateTestValue("脉搏", 20, 180);
                myTemperatureChartControl.AddPointByTimeValue(
                    "maibo",
                    startDate.AddHours(iCount * 4 + 1),
                    v);
                float v2 = v;
                if (rnd.NextDouble() > 0.4)
                {
                    // 有概率心率超过脉搏
                    v2 = (float)Math.Min(180, v + rnd.NextDouble() * 10);
                }
                myTemperatureChartControl.AddPointByTimeValue(
                    "xinlv",
                    startDate.AddHours(iCount * 4 + 1),
                    v2);
            }

            // 眼压
            for (int iCount = enterIndex; iCount < totalDays * 6; iCount++)
            {
                myTemperatureChartControl.AddPointByTimeValue(
                    "yanya",
                    startDate.AddHours(iCount * 4),
                    TemperatureDocument.GenerateTestValue("眼压", 0, 40));
            }
            // 视力
            for (int iCount = enterIndex; iCount < totalDays * 6; iCount++)
            {
                myTemperatureChartControl.AddPointByTimeValue(
                    "shili",
                    startDate.AddHours(iCount * 4 + 1),
                    TemperatureDocument.GenerateTestValue("视力", 0, 5.2f));
            }
            // 添加状态
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(8),
                "重症监护Z1",
                "#FF1493");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(90),
                "1级护理A1床",
                "#FF00FF");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(130),
                "2级护理A1床",
                "#ff9999");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(152),
                "手术",
                "#9400d3");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(154),
                "重症监护Z3",
                "#FF1493");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(203),
                "1级护理A1床",
                "#ff00ff");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(309),
                "2级护理A1床",
                "#ff9999");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(500),
                "3级护理A1床",
                "#00ff7f");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(590),
                "1级护理B3床",
                "#00ff7f");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(690),
                "请假",
                "#aaaaaa");
            myTemperatureChartControl.AddPointByTimeTextColor(
                "zhuangtai2",
                startDate.AddHours(800),
                "3级护理B3床",
                "#00ff7f");

            // 添加青霉素
            for (int iCount = 0; iCount < totalDays * 6; iCount += Math.Max(6, rnd.Next(40)))
            {
                float v = iCount % 4;
                myTemperatureChartControl.AddPointByTimeTextValue(
                    "qingmeisu2",
                    startDate.AddHours(iCount * 4),
                    v.ToString(),
                    v);
            }

            // 化学药品
            myTemperatureChartControl.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(30), "紫杉醇1000", "#3294f7");
            myTemperatureChartControl.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(50), "无", "#ffffff");
            myTemperatureChartControl.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(100), "奈达铂1500", "#f7c916");
            myTemperatureChartControl.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(170), "多西他赛500", "#e25b00");
            myTemperatureChartControl.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(300), "紫杉醇1500", "#32CD32");
            myTemperatureChartControl.AddPointByTimeTextColor("huaxueyaopin", startDate.AddHours(330), "无", "#ffffff");
            // 胸管
            myTemperatureChartControl.AddPointByTimeTextColor("xiongguan", startDate.AddHours(153), "右下胸,直径10mm", "#cccccc");
            myTemperatureChartControl.AddPointByTimeTextColor("xiongguan", startDate.AddHours(250), " ", "#ffffff");
            //  麻醉药
            myTemperatureChartControl.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(152), "芬太尼", "#cccccc");
            myTemperatureChartControl.AddPointByTimeTextColor("mazuiyaopin", startDate.AddHours(161), " ", "#ffffff");

            //文本
            ValuePoint vp = new ValuePoint();
            vp.Time = startDate.AddHours(8);
            vp.Text = "上午八时入院";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(20);
            vp.Text = "下午八时血生化";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(31);
            vp.Text = "敏感菌检查";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(40);
            vp.Text = "下午四时CT";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(152);
            vp.Text = "上午八时手术";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(161);
            vp.Text = "心脏起搏术";
            myTemperatureChartControl.AddPoint("wenben", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(250);
            vp.Text = "又做了手术";
            myTemperatureChartControl.AddPoint("wenben", vp);


            vp = new ValuePoint();
            vp.Time = startDate.AddHours(9);
            vp.Text = "不在";
            vp.Value = 0;
            myTemperatureChartControl.AddPoint("wenben2", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(50);
            vp.Text = "不愿";
            vp.Value = 0;
            myTemperatureChartControl.AddPoint("wenben2", vp);


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
            vp.Time = startDate.AddHours(130);
            vp.Text = "术前讨论";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(133);
            vp.Text = "手术通知书";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(154);
            vp.Text = "手术记录";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = startDate.AddHours(170);
            vp.ColorValue = "#ff9999";
            vp.Text = "抢救记录";
            vp.Title = "不及时填写，扣5分。";
            myTemperatureChartControl.AddPoint("wendang", vp);

            // 刷新文档内容
            myTemperatureChartControl.RefreshView();
            //myTemperatureChartControl.FixedTimelineLeftHeader = false;
        }

        void myTemperatureChartControl_EventValuePointClick(object eventSender, ValuePointClickEventArgs args)
        {
            System.Console.WriteLine("点击了 " + args.SerialTitle + " " + args.Point.Value + " " + args.Point.Text );
        }

        private string strFileName = null;
      
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML文件(*.xml)|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.Stream stream = dlg.OpenFile())
                    {
                        strFileName = dlg.FileName;
                        myTemperatureChartControl.LoadDocument(stream);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "XML文件(*.xml)|*.xml";
                dlg.CheckPathExists = true;
                dlg.OverwritePrompt = true;
                dlg.FileName = strFileName;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.Stream stream = dlg.OpenFile())
                    {
                        strFileName = dlg.FileName;
                        myTemperatureChartControl.SaveDocument(stream);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            myTemperatureChartControl.AboutControl();
        }

        private void btnTestData_Click(object sender, EventArgs e)
        {
            TemperatureDocument document = GenerateTestDocumentByDataSource();
            myTemperatureChartControl.Document = document;
            int tick = System.Environment.TickCount;
            myTemperatureChartControl.RefreshView();
            tick = Environment.TickCount - tick;
            MessageBox.Show("显示数据耗时" + tick + "毫秒");
        }

        /// <summary>
        /// 使用数据源绑定机制生成测试用的体温单文档
        /// </summary>
        /// <returns></returns>
        private TemperatureDocument GenerateTestDocumentByDataSource()
        {
            // 创建文档
            TemperatureDocument document = new TemperatureDocument();
            // 设置病人基本信息
            document.Title = "眼科医院";
            document.HeaderLabels.AddItemByDataSourceName("姓名" , "姓名值");
            document.HeaderLabels.AddItemByDataSourceName("性别","性别值");
            document.HeaderLabels.AddItemByDataSourceName("病区","病区值");
            document.HeaderLabels.AddItemByDataSourceName("住院号","住院号值");
            document.HeaderLabels.AddItemByDataSourceName("床号","床号值");

            // 页眉标题行 *********************
            TitleLineInfo info = new TitleLineInfo();
            info.Title = "日期";
            info.ValueType = TitleLineValueType.SerialDate;
            document.HeaderLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "住院天数";
            info.ValueType = TitleLineValueType.GlobalDayIndex;
            document.HeaderLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "术后天数";
            info.ValueType = TitleLineValueType.DayIndex;
            info.StartDateKeyword = "手术";
            document.HeaderLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "时刻";
            info.ValueType = TitleLineValueType.HourTick;
            document.HeaderLines.Add(info);

            // 页脚标题行 **********
            info = new TitleLineInfo();
            info.Title = "小便  ml";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "小便数值";
            document.FooterLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "大便次数";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "大便次数";
            document.FooterLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "液入量ml";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "液入量数值";
            document.FooterLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "血压  早";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "早上血压";
            document.FooterLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "血压  晚";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "晚上血压";
            document.FooterLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "体重   Kg";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "体重";
            document.FooterLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "腹    围";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "腹围";
            document.FooterLines.Add(info);

            info = new TitleLineInfo();
            info.Title = "引流   ml";
            info.DataSourceName = "按天测量结果";
            info.TimeFieldName = "测量时间";
            info.ValueFieldName = "引流数值";
            document.FooterLines.Add(info);

            // 中间数值信息 ********************

            YAxisInfo ya = new YAxisInfo();
            ya.Title = "体温";
            ya.DataSourceName = "按小时测量结果";
            ya.TimeFieldName = "测量时间";
            ya.ValueFieldName = "体温数值";
            ya.LanternValueFieldName = "物理降温数值";
            ya.MaxValue = 42;
            ya.MinValue = 34;
            ya.SymbolStyle = ValuePointSymbolStyle.Cross;
            ya.SymbolColor = Color.Blue;
            document.YAxisInfos.Add(ya);

            ya = new YAxisInfo();
            ya.Title = "脉搏";
            ya.DataSourceName = "按小时测量结果";
            ya.TimeFieldName = "测量时间";
            ya.ValueFieldName = "脉搏数值";
            ya.MaxValue = 180;
            ya.MinValue = 20;
            ya.SymbolStyle = ValuePointSymbolStyle.SolidCicle;
            ya.SymbolColor = Color.Red;
            document.YAxisInfos.Add(ya);

            ya = new YAxisInfo();
            ya.Title = "眼压";
            ya.DataSourceName = "按小时测量结果";
            ya.TimeFieldName = "测量时间";
            ya.ValueFieldName = "眼压数值";
            ya.MaxValue = 40;
            ya.MinValue = 0;
            ya.SymbolStyle = ValuePointSymbolStyle.SolidCicle;
            ya.SymbolColor = Color.Green;
            document.YAxisInfos.Add(ya);

            ya = new YAxisInfo();
            ya.Title = "视力";
            ya.DataSourceName = "按小时测量结果";
            ya.TimeFieldName = "测量时间";
            ya.ValueFieldName = "视力数值";
            ya.MaxValue = 5.2f;
            ya.MinValue = 0;
            // 添加视力的非线性Y坐标刻度
            // 视力线取值范围0-5.2。从0-4区间中的刻度是1.0,4-5.2区间中的刻度是0.3
            ya.Scales.AddItem(0, 0);
            ya.Scales.AddItem(1, 0.125f);
            ya.Scales.AddItem(2, 0.25f);
            ya.Scales.AddItem(3, 0.375f);
            ya.Scales.AddItem(4, 0.5f);
            ya.Scales.AddItem(4.3f, 0.625f);
            ya.Scales.AddItem(4.6f, 0.75f);
            ya.Scales.AddItem(4.9f, 0.875f);
            ya.Scales.AddItem(5.2f, 1.0f);
            ya.SymbolStyle = ValuePointSymbolStyle.HollowCicle;
            ya.SymbolColor = Color.Blue;
            document.YAxisInfos.Add(ya);

            ya = new YAxisInfo();
            ya.Title = "文本内容";
            ya.DataSourceName = "按小时测量结果";
            ya.TimeFieldName = "测量时间";
            ya.ValueFieldName = "文本";
            ya.Style = YAxisInfoStyle.Text ;
            ya.SymbolColor = Color.Blue;
            document.YAxisInfos.Add(ya);

            // 文档创建完毕，现在创建数据
            // 添加数据
            document.DataSources["姓名值"] = "张三";
            document.DataSources["性别值"] = "男";
            document.DataSources["病区值"] = "第三病区";
            document.DataSources["住院号值"] = "001234";
            document.DataSources["床号值"] = "A02";

            DataTable table = new DataTable();
            // 设置数据源
            document.DataSources["按天测量结果"] = table;
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
            for (int iCount = 0; iCount < 20; iCount += 5)
            {
                table.Rows.Add(startDate.AddDays(iCount), 100, 2, 1000, 90, 95, 80, 80, 900);
                table.Rows.Add(startDate.AddDays(iCount + 1), 130, 3, 1100, 95, 99, 79, 81, 950);
                table.Rows.Add(startDate.AddDays(iCount + 2), 130, 3, 1103, 95, 93, 77, 81, 800);
                table.Rows.Add(startDate.AddDays(iCount + 3), 130, 3, 1100, 95, 99, 79, 81, 950);
                table.Rows.Add(startDate.AddDays(iCount + 4), 130, 3, 1100, 95, 99, 79, 81, 950);
            }
            

            table = new DataTable();
            document.DataSources["按小时测量结果"] = table;
            // 设置数据栏目 
            table.Columns.Add("测量时间");
            table.Columns.Add("体温数值");
            table.Columns.Add("物理降温数值");
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
                if ((iCount % 30) == 0)
                {
                    // 物理降温
                    row[2] = Math.Max ( 34 , Convert.ToSingle(row[1]) - 2 );
                }
                else if ((iCount % 50) == 0)
                {
                    // 升温
                    row[2] = Math.Min(42, Convert.ToSingle(row[1]) + 2);
                }

                // 脉搏
                row[3] = TemperatureDocument.GenerateTestValue("脉搏", 20, 180);
                // 眼压
                row[4] = TemperatureDocument.GenerateTestValue("眼压", 0, 40);
                // 视力
                row[5] = TemperatureDocument.GenerateTestValue("视力", 0, 5.2f);
                // 文本内容
                if (iCount == 10)
                {
                    row[6] ="手术";
                }
                else
                {
                    row[6] = "" ;
                }
                table.Rows.Add(row);
            }
            return document;
        }
         
         
        private void btnShowConfig_Click(object sender, EventArgs e)
        {
            using (Form frm = new Form())
            {
                TextBox txt = new TextBox();
                txt.Multiline = true;
                txt.ScrollBars = ScrollBars.Both;
                txt.Text = this.myTemperatureChartControl.DocumentConfigXml;
                txt.Dock = DockStyle.Fill;
                frm.Controls.Add(txt);
                frm.ShowDialog(this);
            }
        }


        private void btnDesigner_Click(object sender, EventArgs e)
        {
            myTemperatureChartControl.RunDesigner();
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, myTemperatureChartControl.NumOfPages-1);
            myTemperatureChartControl.PageIndex = index;
        }

        private void btnEditValue_Click(object sender, EventArgs e)
        {
            
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
            tmr.Interval = 500;
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
                System.Threading.Thread.Sleep(500);
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
            }//while
        }

        void tmr_Tick(object sender, EventArgs e)
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
            DateTime startDate = DateTime.Today.AddDays(-18);
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (dlgRegister dlg = new dlgRegister())
            {
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    myTemperatureChartControl.SetRegisterCode(dlg.RegisterCode);
                    myTemperatureChartControl.Invalidate();
                    DCSoft.Writer.WinFormDemo.Properties.Settings.Default.TimeLineRegisterCode = dlg.RegisterCode;
                    DCSoft.Writer.WinFormDemo.Properties.Settings.Default.Save();
                }
            }
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
      <Zone Name='xuetou1' StartTime='2014-10-19T09:00:00+08:00' EndTime='2014-10-19T11:00:00+08:00' AlignToGrid='false' GridLineStyle='Dash' GridLineColorValue='#0000FF' BackColorValue='#F5F5F5' SpecifyTickWidth='100' AutoTickStepSeconds='1800'>
         <Ticks />
      </Zone>
      <Zone Name='xuetou2' StartTime='2014-10-29T10:00:00+08:00' EndTime='2014-10-29T12:30:00+08:00' AlignToGrid='false' GridLineStyle='Dash' GridLineColorValue='#0000FF' BackColorValue='#F5F5F5' SpecifyTickWidth='100' AutoTickStepSeconds='1800'>
         <Ticks />
      </Zone>
      <Zone Name='inpatient' StartTime='2014-11-01T09:00:00+08:00' EndTime='2014-11-19T00:00:00+08:00' GridLineColorValue='#E0E0E0'>
         <Ticks>
            <Tick Value='2' Text='2' ColorValue='#FF0000' />
            <Tick Value='6' Text='6' ColorValue='#FF0000' />
            <Tick Value='10' Text='10' />
            <Tick Value='14' Text='14' />
            <Tick Value='18' Text='18' />
            <Tick Value='22' Text='22' ColorValue='#FF0000' />
         </Ticks>
      </Zone>
      <Zone Name='oper' StartTime='2014-11-03T10:15:00+08:00' EndTime='2014-11-03T19:45:00+08:00' AlignToGrid='false' GridLineStyle='Dash' GridLineColorValue='#FF8080' BackColorValue='#F5F5F5' SpecifyTickWidth='100' AutoTickStepSeconds='1800'>
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
      <Line Name='wendang' Title='病历文档' ShowBackColor='true' LayoutType='HorizCascade' TickStep='2' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Title='时刻' ValueType='HourTick'>
         <DataSource />
         <Scales />
      </Line>
   </HeaderLines>
   <FooterLines>
      <Line Name='zhuangtai2' Title='状态' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='huxi' NormalMaxValue='30' NormalMinValue='9' ValueDisplayFormat='0' Title='呼吸' CircleText='R' SpecifyHeight='80' UpAndDownText='true' ValueType='TickText'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='xiaobian' Title='小便' TickStep='2' ValueType='Text'>
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
      <Line Name='fuguan' Title='腹管' ShowBackColor='true' LayoutType='Free' ValueType='Data'>
         <DataSource />
         <Scales />
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis Name='tiwen' ValuePrecision='1' AllowOutofRange='true' EnableLanternValue='true' LanternValueTitle='物理降温' TitleValueDispalyFormat='0°' Title='体温' ValueFormatString='0.0' RedLineValue='37' NormalRangeBackColorValue='#B4C0FFC0' OutofNormalRangeBackColorValue='#00000000' NormalMaxValue='37.5' NormalMinValue='36.5' MaxValue='42' MinValue='34' SymbolStyle='Cross' BottomTitle='摄氏' SymbolColorValue='#00FF00'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='xinlv' ValuePrecision='0' Title='心率' OutofNormalRangeBackColorValue='#FFC0CB' MaxValue='180' MinValue='20' BottomTitle='次/分' SymbolColorValue='#008000'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='xuetang' AllowOutofRange='true' Title='血糖' OutofNormalRangeBackColorValue='#64FFC0CB' NormalMaxValue='6.1' NormalMinValue='3.9' MaxValue='10' BottomTitle='mmHg'>
         <DataSource />
         <Scales />
      </YAxis>
      <YAxis Name='jigan' AllowOutofRange='true' Title='肌酐' OutofNormalRangeBackColorValue='#FFC0CB' MaxValue='1000' SymbolStyle='Square' BottomTitle='mmHg' SymbolColorValue='#C0C000'>
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
            DateTime startDate = DateTime.Today.AddDays(-30);
            // 整个数据结束时间
            DateTime endDate = DateTime.Today.AddDays(-1);

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
            myTemperatureChartControl.AddPointByTimeText("wenben", startDate.AddHours(8), "省人民上午八时门诊");
            myTemperatureChartControl.AddPointByTimeText("wenben", startDate.AddHours(10), "上午十时血生化");
            myTemperatureChartControl.AddPointByTimeText("wenben", startDate.AddHours(18), "下午六时CT");
            myTemperatureChartControl.AddPointByTimeText("wenben", inTime, "省人民上午九时入院");
            myTemperatureChartControl.AddPointByTimeText("wenben", fastTime, "开始禁食");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime, "手术开始");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(1.3), "改变体位");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(2), "割掉老肾");
            myTemperatureChartControl.AddPointByTimeText("wenben", operStartTime.AddHours(3), "换上新肾");
            myTemperatureChartControl.AddPointByTimeText("wenben", operEndTime, "手术结束");

            ValuePoint vp = new ValuePoint();
            vp.Text = "雷公藤";
            vp.ColorValue = "#333344";
            vp.Time = startDate.AddHours(40);
            myTemperatureChartControl.AddPoint("yongyao", vp);


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
            vp.Text = "门诊病历";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = xt1EndTime;
            vp.Text = "血透记录";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = xt2EndTime;
            vp.Text = "血透记录";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = inTime.AddHours( 2 );
            vp.Text = "入院记录";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = inTime.AddHours(4);
            vp.Text = "首次病程";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = operStartTime.AddHours(-1);
            vp.Text = "术前讨论";
            myTemperatureChartControl.AddPoint("wendang", vp);

            vp = new ValuePoint();
            vp.Time = operEndTime.Date.AddDays(1).AddHours(9);
            vp.Text = "手术记录";
            vp.ColorValue = "#ff9999";
            vp.Title = "不及时填写，扣5分。";
            myTemperatureChartControl.AddPoint("wendang", vp);

            
            vp = new ValuePoint();
            vp.Text = "右下腹,直径10mm";
            vp.ColorValue = "#cccccc";
            vp.Time = operStartTime.AddHours(1.5);
            vp.EndTime = operStartTime.AddHours(50);
            myTemperatureChartControl.AddPoint("fuguan", vp);

            // 刷新文档内容
            myTemperatureChartControl.RefreshView();
        }

        private void btnSaveDataHtml_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "html文件|*.htm;*.html";
                dlg.CheckPathExists = true;
                dlg.OverwritePrompt = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    myTemperatureChartControl.SaveDataHtmlToFile(dlg.FileName);
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.myTemperatureChartControl.Invalidate(true);
        }

        private void btnLayout_Click(object sender, EventArgs e)
        {
            this.myTemperatureChartControl.RefreshViewWithoutRefreshDataSource();
        }


    }
}
