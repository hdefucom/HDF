using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.FriedmanCurveChart;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.FriedmanCurveTest
{
    public partial class ctlFriedmanCurve : UserControl
    {
        public ctlFriedmanCurve()
        {
            InitializeComponent();
            FriedmanCurveControl1.EventDocumentDblClick
 += new FCDocumentDblClickEventHandler(myFriedmanCurveChartControl_EventDocumentDblClick);

            FriedmanCurveControl1.EventValuePointClick
                += new FCValuePointClickEventHandler(FriedmanCurveControl1_EventValuePointClick);
            this.FriedmanCurveControl1.SetRegisterCode(Properties.Settings.Default.FriedmanCurveRegisterCode);
        }
        void myFriedmanCurveChartControl_EventDocumentDblClick(object eventSender, FCDocumentDblClickEventArgs args)
        {
            MessageBox.Show("用户双击事件");
        }
        void FriedmanCurveControl1_EventValuePointClick(object eventSender, FCValuePointClickEventArgs args)
        {
            MessageBox.Show("点击了 " + args.SerialTitle + " " + args.Point.Value + " " + args.Point.Text);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "XML文档|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FriedmanCurveControl1.LoadDocumentFromFile(ofd.FileName);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FriedmanCurveControl1.RunDesigner();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (FriedmanCurveControl1.Document != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.SupportMultiDottedExtensions = false;
                    sfd.Filter = "XML文档|*.xml";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FriedmanCurveControl1.SaveDocumentToFile(sfd.FileName);
                    }
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FillData(18);
        }
        private void FillData(int totalHours)
        {
            // 设置文档配置
            FriedmanCurveControl1.DocumentConfigXml = @"
<FriedmanCurveDocumentConfig xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' Version='1.0'>
   <BothBlackWhenPrint>true</BothBlackWhenPrint>
   <LineWidthZoomRateWhenPrint>3</LineWidthZoomRateWhenPrint>
   <DataGridTopPadding>0.1</DataGridTopPadding>
   <DataGridBottomPadding>0.1</DataGridBottomPadding>
   <Images />
   <Labels>
      <Label Text='产程图演示' Left='950' Top='170' Width='300' Height='80'>
         <ShowBorder>true</ShowBorder>
         <Font>
            <Size>12</Size>
         </Font>
      </Label>
      <Label Text='' Left='200' Top='-20' Width='150' Height='150'>
         <Image>
            <ImageDataBase64String> iVBORw0K GgoAAAAN SUhEUgAA AfQAAAH0 CAYAAADL 1t+KAAAA CXBIWXMA ACcQAAAn EAGUaVEZ AAAKTWlD Q1BQaG90 b3Nob3Ag SUNDIHBy b2ZpbGUA AHjanVN3 WJP3Fj7f
 92UPVkLY 8LGXbIEA IiOsCMgQ WaIQkgBh hBASQMWF iApWFBUR nEhVxILV CkidiOKg KLhnQYqI WotVXDju H9yntX16 7+3t+9f7 vOec5/zO ec8PgBES JpHmomoA OVKFPDrY
 H49PSMTJ vYACFUjg BCAQ5svC ZwXFAADw A3l4fnSw P/wBr28A AgBw1S4k Esfh/4O6 UCZXACCR AOAiEucL AZBSAMgu VMgUAMgY ALBTs2QK AJQAAGx5 fEIiAKoN AOz0ST4F
 ANipk9wX ANiiHKkI AI0BAJko RyQCQLsA YFWBUiwC wMIAoKxA Ii4EwK4B gFm2MkcC gL0FAHaO WJAPQGAA gJlCLMwA IDgCAEMe E80DIEwD oDDSv+Cp X3CFuEgB AMDLlc2X
 S9IzFLiV 0Bp38vDg 4iHiwmyx QmEXKRBm CeQinJeb IxNI5wNM zgwAABr5 0cH+OD+Q 5+bk4eZm 52zv9MWi /mvwbyI+ IfHf/ryM AgQAEE7P 79pf5eXW A3DHAbB1 v2upWwDa
 VgBo3/ld M9sJoFoK 0Hr5i3k4 /EAenqFQ yDwdHAoL C+0lYqG9 MOOLPv8z 4W/gi372 /EAe/tt6 8ABxmkCZ rcCjg/1x YW52rlKO 58sEQjFu 9+cj/seF f/2OKdHi NLFcLBWK
 8ViJuFAi Tcd5uVKR RCHJleIS 6X8y8R+W /QmTdw0A rIZPwE62 B7XLbMB+ 7gECiw5Y 0nYAQH7z LYwaC5EA EGc0Mnn3 AACTv/mP QCsBAM2X pOMAALzo GFyolBdM xggAAESg
 gSqwQQcM wRSswA6c wR28wBcC YQZEQAwk wDwQQgbk gBwKoRiW QRlUwDrY BLWwAxqg EZrhELTB MTgN5+AS XIHrcBcG YBiewhi8 hgkEQcgI E2EhOogR Yo7YIs4I F5mOBCJh
 SDSSgKQg 6YgUUSLF yHKkAqlC apFdSCPy LXIUOY1c QPqQ28gg Mor8irxH MZSBslED 1AJ1QLmo HxqKxqBz 0XQ0D12A lqJr0Rq0 Hj2AtqKn 0UvodXQA fYqOY4DR MQ5mjNlh
 XIyHRWCJ WBomxxZj 5Vg1Vo81 Yx1YN3YV G8CeYe8I JAKLgBPs CF6EEMJs gpCQR1hM WEOoJewj tBK6CFcJ g4Qxwici k6hPtCV6 EvnEeGI6 sZBYRqwm 7iEeIZ4l XicOE1+T
 SCQOyZLk TgohJZAy SQtJa0jb SC2kU6Q+ 0hBpnEwm 65Btyd7k CLKArCCX kbeQD5BP kvvJw+S3 FDrFiOJM CaIkUqSU Eko1ZT/l BKWfMkKZ oKpRzame 1AiqiDqf WkltoHZQ
 L1OHqRM0 dZolzZsW Q8ukLaPV 0JppZ2n3 aC/pdLoJ 3YMeRZfQ l9Jr6Afp 5+mD9HcM DYYNg8dI YigZaxl7 GacYtxkv mUymBdOX mchUMNcy G5lnmA+Y b1VYKvYq fBWRyhKV
 OpVWlX6V 56pUVXNV P9V5qgtU q1UPq15W faZGVbNQ 46kJ1Bar 1akdVbup Nq7OUndS j1DPUV+j vl/9gvpj DbKGhUag hkijVGO3 xhmNIRbG MmXxWELW clYD6yxr mE1iW7L5
 7Ex2Bfsb di97TFND c6pmrGaR Zp3mcc0B Dsax4PA5 2ZxKziHO Dc57LQMt Py2x1mqt Zq1+rTfa etq+2mLt cu0W7eva 73VwnUCd LJ31Om06 93UJuja6 UbqFutt1 z+o+02Pr
 eekJ9cr1 Dund0Uf1 bfSj9Rfq 79bv0R83 MDQINpAZ bDE4Y/DM kGPoa5hp uNHwhOGo EctoupHE aKPRSaMn uCbuh2fj NXgXPmas bxxirDTe ZdxrPGFi aTLbpMSk xeS+Kc2U
 a5pmutG0 03TMzMgs 3KzYrMns jjnVnGue Yb7ZvNv8 jYWlRZzF Sos2i8eW 2pZ8ywWW TZb3rJhW PlZ5VvVW 16xJ1lzr LOtt1lds UBtXmwyb OpvLtqit m63Edptt 3xTiFI8p
 0in1U27a Mez87Ars muwG7Tn2 YfYl9m32 zx3MHBId 1jt0O3xy dHXMdmxw vOuk4TTD qcSpw+lX ZxtnoXOd 8zUXpkuQ yxKXdpcX U22niqdu n3rLleUa 7rrStdP1 o5u7m9yt
 2W3U3cw9 xX2r+00u mxvJXcM9 70H08PdY 4nHM452n m6fC85Dn L152Xlle +70eT7Oc Jp7WMG3I 28Rb4L3L e2A6Pj1l +s7pAz7G PgKfep+H vqa+It89 viN+1n6Z fgf8nvs7
 +sv9j/i/ 4XnyFvFO BWABwQHl Ab2BGoGz A2sDHwSZ BKUHNQWN BbsGLww+ FUIMCQ1Z H3KTb8AX 8hv5YzPc Zyya0RXK CJ0VWhv6 MMwmTB7W EY6Gzwjf EH5vpvlM 6cy2CIjg
 R2yIuB9p GZkX+X0U KSoyqi7q UbRTdHF0 9yzWrORZ +2e9jvGP qYy5O9tq tnJ2Z6xq bFJsY+yb uIC4qriB eIf4RfGX EnQTJAnt ieTE2MQ9 ieNzAuds mjOc5JpU lnRjruXc
 orkX5unO y553PFk1 WZB8OIWY EpeyP+WD IEJQLxhP 5aduTR0T 8oSbhU9F vqKNolGx t7hKPJLm nVaV9jjd O31D+miG T0Z1xjMJ T1IreZEZ krkj801W RNberM/Z cdktOZSc
 lJyjUg1p lrQr1zC3 KLdPZisr kw3keeZt yhuTh8r3 5CP5c/Pb FWyFTNGj tFKuUA4W TC+oK3hb GFt4uEi9 SFrUM99m /ur5IwuC Fny9kLBQ uLCz2Lh4 WfHgIr9F uxYji1MX
 dy4xXVK6 ZHhp8NJ9 y2jLspb9 UOJYUlXy annc8o5S g9KlpUMr glc0lamU ycturvRa uWMVYZVk Ve9ql9Vb Vn8qF5Vf rHCsqK74 sEa45uJX Tl/VfPV5 bdra3kq3 yu3rSOuk
 626s91m/ r0q9akHV 0IbwDa0b 8Y3lG19t St50oXpq 9Y7NtM3K zQM1YTXt W8y2rNvy oTaj9nqd f13LVv2t q7e+2Sba 1r/dd3vz DoMdFTve 75TsvLUr eFdrvUV9 9W7S7oLd
 jxpiG7q/ 5n7duEd3 T8Wej3ul ewf2Re/r anRvbNyv v7+yCW1S No0eSDpw 5ZuAb9qb 7Zp3tXBa Kg7CQeXB J9+mfHvj UOihzsPc w83fmX+3 9QjrSHkr 0jq/dawt o22gPaG9
 7+iMo50d Xh1Hvrf/ fu8x42N1 xzWPV56g nSg98fnk gpPjp2Sn np1OPz3U mdx590z8 mWtdUV29 Z0PPnj8X dO5Mt1/3 yfPe549d 8Lxw9CL3 Ytslt0ut Pa49R35w /eFIr1tv
 62X3y+1X PK509E3r O9Hv03/6 asDVc9f4 1y5dn3m9 78bsG7du Jt0cuCW6 9fh29u0X dwruTNxd eo94r/y+ 2v3qB/oP 6n+0/rFl wG3g+GDA YM/DWQ/v DgmHnv6U /9OH4dJH
 zEfVI0Yj jY+dHx8b DRq98mTO k+GnsqcT z8p+Vv95 63Or59/9 4vtLz1j8 2PAL+YvP v655qfNy 76uprzrH I8cfvM55 PfGm/K3O 233vuO+6 38e9H5ko /ED+UPPR +mPHp9BP
 9z7nfP78 L/eE8/sl 0p8zAAAA IGNIUk0A AHolAACA gwAA+f8A AIDpAAB1 MAAA6mAA ADqYAAAX b5JfxUYA AErMSURB VHja7N15 nN11fff9 19n3ZfaZ TJYJkABZ CBO2UdkE
 WRTcCEhV Ylvbqr1s r4QuXtV6 V+2j191H 71tvQr1s 3arWWKti 3MEFURHR MQEmIYBA IAlkmWT2 Oft+7j9+ 3yEDZs8s 5/zO+/l4 zEMEjHO+ v3O+7/P5 ro5qtYqI iIjUN7ea
 QESkPm3a tEmNIADc 2ZdyO3jo I9fidj8K JO7qD1fU LCIiInUR 4k4gTrF4 JYn0nQ7+ 4w/zxMKH iIQfJuD7 Bh7PL+/q D4+pqURE RGoyyOMU i1eTzb+N RPIKJhKd FIouB5+6
 vUKh6MDt Ar+vRCQ8 QSzyK0LB L+BxP6TK XUREZN4r 8TDFUh/Z 3B8zPnkN iVQLuZyL 8pF4dvC5 O4qkMi+f S3c6IeAv E48eJhb5 JX7ft/B6 HlDlLiIi MpeVeOkq crlbSKSu
 YiLRTTrr pnKUGtvp xMG//UGF fMFxzD/x SOU+Rizy G0LBL+Jx P6jKXURE ZMZDPEqp dBnp7J8y kbiaZKqZ XN5NqXz8 /2HQX3Gw aV2Vk926 5nRCwFem KTZIJPxr Av5v4vU8
 eFd/eEiP QURE5LQr 8deQy60j kbqGscmF ZHOuo1bi xxKL5B18 5p0lMlnX Kf8GLif4 /WWi4XGi 4W2Eg5/H 4/mZKncR EZEThniY UulVZHLv ZiLxWlLp ZjI5D6XS 6f2BLU1p
 B59+R5ls znlGv9lU 5R6PDhON PETAfw9e z4PAiMJd RETkpUr8 UnK520mk rmF8ciGZ nPuUKvFj 6WwbPf0K /biVu69M LDpCJPQI oeB/4vU8 AEwo3EVE pMFCPEip 9CrS2feQ
 SF5BMt16 RpX4sSxd 9LiD/3x3 hrGJwKy8 kqnV8tHw KLHIw4QC 9+DxPKDK XUREbBzi UUqlS8jm byOZuo7x ycVksu7p W8xmlMsF 5571FQdf fc8oh0ea Z/0VTg3L RyNjRMOP
 EQp8Ga/3 R6rcRUTE JpX4a8jk /pBk6gom U11ksjNf iR9NMFBh Wc+HHXzz /XvZf2gJ c3lJy9Sw fDQyZir3 b+By/Qyn c1jhLiIi dRLiYUql S8jlbyOZ vp7xycWk M55Zq8SP
 pb0lweLu 1zv4/l89 zHN7Xz1v LfL7lft/ 4/XeC4wp 3EVEpIYr 8dcwmVpA Juudk0r8 WJYu2klH 6zVufJ6n cbtfPW+/ TKUC6ayL dLaNwyM3 EPC9jnBo kqbYw3de VPxvVe4i
 IjL/lXj5 QnL5t3Ew eRMTiUXW cHp5/n85 j7uKz7sX GHPj9fbj df8RpZJz 3n+xI+He zPDYG/H7 biIaHicW 6b+zt/Ad PO7vK9xF RGSOKvHL yObWczB9 NRPJ7nmv xI8mECjh
 9/2Y/oGK g1999CJ2 73uQ0fFQ zbas0wl+ X8WE+6OE gl/A6/k5 Wi0vIiIz G+IXkCu8 g0TyJiaS i8hkaqMS P5bujoN0 d17M1h2D bhyOIYL+ YUap3UCv VCCTdZLJ tjA0ej1+
 3+umVe7f xeP+AU7n YYW7iIic Roi/imz+ NgbTr2Mi sYh0DVbi R+PxVImE H2HrjkEA N1t37GPF st/gcvVQ Ltf+C3h5 uN+E3/d6 a849uu3O i4pf0py7 iIicMMTL ldVks3/I
 geTrmUx1 13wlfjSh QIGA/7tT /9W6NtXn /Tl+322k X3GNav2E exMjY9fj 876OeHSU aHirmXP/ MU7nAYW7 iIhCnGLp EvKFWzmU vo6JRA+p tK/uQnyK wwHR8AE8 7gdeHuhu
 12NEQpOk My11+7Qq FcjmnGRz bQyN3ITX +3pikXGi 4YE71xb/ E7frflXu IiINFeJ+ yuXVZPPv slan1+jC ttPh9VaJ Ru5l644X Xh7oLtdO YpHHODxy 3ZweMDNb yi+FewtD
 o6/D572G WGScWOSR O3sL38bj vk+Vu4iI TSvxUnkt ufytHErf yPjkUjJZ D8WSw1Yv NBaZIOj/ wsuKdu66 xfqrtSv/ kGd2/wfp GbyopRaH KPy+CpFQ ilj0MSLB L+N236fK
 XUSk7ivx lWRzf0Ii dQOTyYVm n7jDFkXq 0Zx39rd5 +vlbpv+t I3PmbvdP aIoNks4u tO1Tr1an KvcoI+NX 4/Ne+dKw /IX5LXg9 P8Tp3Kdw FxGpk0o8 X3gTh1Jv Ynxyad2s
 Tj/z6jxP OPjJ36tZ X6rQ+3q9 JFKfZ9ee 9RRLjfXO cDrB560Q CSWIRXcQ Dn4Zj/te Ve4iIjUV 4l7K5ZVk cu8jlb6W yWQ36YzP dsPpx+Nx Q8+iB9m1 5+pjBzrA RavfwN79
 36jpQ2bm Ktytyv1x goEteL33 4XS8oHAX EZmHSrxc XkmusI5k 6o1MJM4m lfE1RCV+ NM2xLEsX vYtHn/jm 8QO9rzfI 8Ngv2LPv EirKrpfP uUd2EA79 Fx7393SI jYjIrFfi
 a8jk/oRU +nUvVeJ2 nhM/WcuX /ozm+Jvp H0gdP9AB Llzxfnbt udvWi+PO pHKPhBLE IjsJh76G x/NDnI59 d/WHS2og EZEzCnE/ 5fL55Avr SKTe2vCV +NEKzHg0 y1mLb8fj
 vpf+gcqJ A72vt5nD ww+xZ/8K teBxGtbr rRILJ4hG niQc/Bpe z7dwOgdV uYuInGIl ns29m2T6 GhKpxS/N iTd6Jf5K Pm+VnoX3 0RR709HC /OiBDtC7 8r08/fy/ kc051Yon
 WbmHg2ni sccIBbbg 9f5AlbuI yHEr8VtI pt/C+OQ5 pDJ+VeIn 0Nk2ysLO 23lk5wPH rDWPGuh9 vV4OHv4d Lx48S614 2pX7U4SD 38Dr2aJD bERElXh5 DdncH5PK vJZEcgmp
 jF+V+MlW 574q5yz+ IpHwn9M/ UDi1QAe4 cMVGntn9 CVXpZ1C5 ez0VouEU segA4eA3 NOcuIg1V iVcq55g5 8XWMTy7X nPhpcLuh u+N52ltv xuV89ljD 7ccP9L7e MEOjD7Fn
 34X6BjUD lbvPWyEa ThKNPEUo eA8+73e0 FU5EbFmJ 5/LvIJW5 lsnkOaTS qsTPREtT hkVdH2T7 U/96wqg5 ZqADXLTq Vp5/8StM JHxq1RkP 9xTRyBNE Qv+Fx/Nj E+766ioi
 dRjilbMo FG4jkbqN icQykmnN ic9UdX7O kh8Qj66n f2DizAId YPnSn/Ls nmvVsrMU 7tac+6RV uQfuxef7 usJdROqj Ei/cRip9 PYnUMlLp AIWiKvGZ 1Nk2yuIF V7N1xxMn
 FSknDPSL L7iSFw98 l6HRuFp3 Dir3cDBD PPa4qdw1 5y4itVaJ 304idSsT iXPMfeIK 8dkQixRY 3P2v7Hz6 b0+6oD/x v+H6Fe0t /0Uq8z4y Omxm1lSr kMs7yeXD jE68Gp+3
 j2g4RST8 uzvX5O7F 6/06Ludu hbuIzHEl vpJ84RaG MjcxmTxX lfgc8Lir dLQ+hN/3 uVOqC09Y oQNceuHZ DI9+iz37 LlBLzwOf r0okmCYW /R2R0H+a s+VVuYvI bIS4m3Ll
 LPL59STT b2YisYx0 xkeh6FDr zJFFXS/S 2f42tu34 7cwHOsDa Vbezd98X GZsMqLXn ydSwfCSU Jhp+hnDo B3i99+By PqtwF5Ez qsQrlfPI F95MMv1W VeLzqDmW ZXH3353M
 qvbTD3SA lcs/zzO7 /0SrF2uE 11MlHMrR FH2ScPir ZiucKncR OblKvFJd Sj7/DhLJ t5FI95BM BbTFbB75 fRV6Fn7L rGrPzW6g 9/XGGRza xr7Bc3Qb W41V7l5P lUg4TSzy
 O8LB+/B5 v4nT+bTC XUSmhbjf LGx7M6n0 LUwmzyOZ CVEoKMTn m9sFi7sH aG16N1t3 bD+tKDil QAdr6P3F g59jZCyi J1Cj4e52 VYmEc8Sj TxMJfw2f d4u2wok0 eCWey91B
 Mv1WEqmz SGWCCvEa 4nRCZ9sh utr/FI/7 h8c7DW5m Ax1g1bmb eG7vX5LL 61jYWg93 j7tKNJwm Hn2CUPBH Vrg7n72r P1xQA4nY NsS9lCs9 FIpvIpW+ lcnESpLp kObEazTM
 o+E8ixf8 C48//ZEz 6vJPK9D7 et2Mjv+M 5164Qm+O Ogp3r6dK KJgjHn2W SOgb+Hz3 4HTsUeUu YpNK3Fqd /k5SmTeS SC2zQlyV eE1riuVY 0PEVIqEP 0j8wMveB DnDJmuUc
 PPQgg8Od mk+v08o9 Es4Qjz5F OPh9fN5v q3IXqcNK vFJdQr5w M+n02xhP rNZweh3x +yos6f4p scgfsXXH 4Bl37acd 6AC9K/+U fQfvYmQ8 rCdjg8o9 FnmOSOi7 +HybdYiN
 SE1X4ueQ z7+ddPb1 TCbPVyVe h6xFcI/R HN/AI4// aka68zMK dIALzvtn nt3zv8jl deiAXcI9 HMoSizxD JPRNfN7v 4XQ+d1d/ OKcGEpnH EK9Ul1As 3kAi9S7G Jy8gnfFr
 TryOLezc T1fHrad6 eMzsBjrA uWf9gL37 30C+oFC3 a+UeDt2H 3/clXM7n VLmLzGEl XijcRirz RpKpc0mk wuQLToV4 HXM6oa15 nK72f8Tv +z/0D8xY fzozgX7J muWMjv83
 Lx5YS6ms B2bHcLfm 3LPEIk8T CW1R5S4y a5X4IorF 15NM38H4 5AWk0kEV SzYK82g4 x5LujxLw f47+gbEZ 7apnJNAB Lr7g1QwO 3cOBQwv0 1Bqgcg+H MkTDewgH f0zA/yUd
 YiNyRpX4 WRQKbyWd eQuJ1Hkk UlFV4jbU HM+woP3L PPHsn89K 9zxjgQ5w 0eqb2Hfw vxgajenJ NQircp/a Cvd1fN7v q3IXOZlK vNJl9onf wURyFcl0 iLzWItlW KFiiZ+GX
 iIT+lv6B idoP9L5e J7n8e9g3 +HFGx0N6 gg1YuYeC OaLhFwiH 7ifg+09c rp3aCicy vRIvvol0 5q0kkitU iTeIeDRH d8c3CIX+ ia3bd81a NzyjgT7l gvM+xt79 HySR8uhJ
 Nii3G8LB PE2xp4mG vz1tn7sq d2mkEHdS qXRTLL2R ZGo9E4lV OrGtwQod a6/5vUTD 752JveZz H+gAK5d/ jj373k0m q+NhG/0N 7XFXCQdz RCN7TOW+ WZW7NEQl nsm8mcnk
 apLpCLm8 KvFGY4X5 D4lG/opt O56d9e52 1gK9rzfM ZPLzvLD/ NjI5hbq8 snLfRTS8 BZ/3W6rc xSaVeBeF 4i2k0u9g MrmSRDqs w14aWMBf obvzt7Q2 3QwkZnJ7 2twHuhXq
 zSRS/4dn dr+dsraz yTEq91hk D6HQ/QT8 /43LuUPh LnVTiVeq SygUbiSd vY3JxBqS aWtOXMdh N7agv8LC rgeJRj7M I4//es66 1VkN9CnL lj7Iiweu 0F5KOUHl nqMpuptI
 +Hv4ff+t yl1quBJf RypzO4nk Kh32Ii8T CZXobPsN scgHeGRn /5zWSXMS 6Jeu6WIi 8WVeOHCt Ql1OqnIP BgrEo88T Cf0En28L btcjCneZ v0q80k2x dD3pzNsZ n7yYVCak
 Slx+r+/y eqv0dN9H LLqBrduf n/NfYU4C 3Qr1biYS X2L3i6/T aXJySpV7 KFCgKbaH aPhb+H1f U+Uuc1qJ pzO3Mpla RSIZUyUu xxQMlFm8 4F6i4f/B 1h0H5uU7 xZwFOph7
 1CfuZ9/B K8nltVBO To3HXSUc yhOL7CUS uhef95u4 3dsV7jKD lXgXxdJ1 pDN3MJFY SzIdUSUu JxQNF+lq v5+m2NuB FP0D8/KG mdtAB7j0 wqVMJv6d vfuv1/C7 nFG4h4J5
 YpEDRMPf x+/7Mi7X 7xTuchqV eDeF4ltI Z9eRSK4m kYorxOWk xaN5uju+ SjD4cbbt eGo+f5W5 D3SAS9d0 MJn8Arv3 vZ5iUaEu MxPu8ehu M+d+D27X 9rv6wxk1 jhwjxDso
 lW4klVnP RKJXq9Pl tLQ2peho vYdQ8GNs 3fHCfP86 8xPoU84/ 52vsO7iO VMatd4ac +bvZAW6X Fe7R8EGi 4R8T8H/R HGKjyl0h blXimeyb mUz2kkjF ddiLnBa3 C6KRLAs6
 Pks4+GH6 B1I10QXO a6D39baT Sn+MPfv+ jHTWpXeJ zOyH7qUF dbutOXff 93C7Hrur P5xS4zRM iLdRLF1P JvtOxicv I5GKUiiq EpfT53JB W/MoHW3/ m4Dvk3Nx YEx9BPqU
 Ved+khcP vFdnv8ss V+4FIqFD RMM/I+D/ rBbU2TbE uyiWbiaT vYXJ5EUk Uk3k8gpx mRmLuvbS HP8sO373 zzXX1dVE oAOsWfE3 7B/8GOOT QX3wZHYr dxcEg0Wa Y7uIhH6o
 yt0GIQ6t FIrXk0r/ EROJi0im oxQKTsrq S2SGBPwV 2luep73l nbhcz9A/ kFCgH0/v yj/j4OF/ 4fBIk949 MiesQ2yK RMODRMMP Egh8zoS7 FtTVfiXe TbF0A5ns W5hM9qkS
 l1nj9VTp WfgAsciH cLkGammY vXYDHeDi 1ddxeORz DA4t0QE0 MqdcTgiF ijTHdpvK /R7crsdV uddUJd5M oXA9qcy7 X6rEtbBN ZlNLU5rO 1i2Egp9g 647Ha/lX rb1AB7j4
 glczNvEp XjxwoUJd 5v5TYebc A4EisfBB q3L3/ydu 929Vuc9L Jd5lKvFb SaQuYjLZ qkpc5kRn 2yhtzV8m 4L+LrTv2 1XzXVZOB DnDpmkVM JL7A3v3X UtBedZlH bhcEA0Xi
 0X1EI/fi 933D7HNX 5T6blXix eB3J9J8w kVxLMhXT PnGZM0F/ heb4QVqb /1/8vi/V 4nx5fQX6 lJXLP8OB Q+9iMunX sJrMf7ib rXCxyAHC oYcJ+r+E 2/0bVe4z Uol3UCpd
 Tyb3ViaT r1IlLvMi FCzT2bqd WPRf8Hq2 zNcxrvYM 9L5eP7n8 +zl4+MMM jcb1bhNV 7raqxOMU CjeSyvwx k8m1JNNx hbjMm6ZY jo7WnxIK /juP7ryv 3n792g/0 KRetvpGh
 kc9waHgR xZKG4KX2 KvdgoEA8 coBI6Bf4 /V/D4/61 wv2olXgb pfLVZLLv ZDJ5GYlk C9m8SyEu 88bjhpam UVqavkkk 9De1cvKb fQO9r9dJ qdzHZOJf 2LPvci2W k5qv3GOR
 QaKRH+H3 fRWP+9FG DfcjlXjx DaQzdzCZ vJjJZJPm xKUmBANl WuIHaGn6 V7Y/9Yl6 fin1E+jT rVz+GQ4e fhfjk369 G6X2wz1Y JBY+QDT8 c/z+b+Bx /8ru4T7t sJeryGTX
 W/vEk82q xKWmxKN5 WpsfIR75 Gx7Z2V/v L6c+A72v 10uh8E4O HP44w2PN 6iCkrsI9 GjpMLPKA 2Qq3zS7h Pq0Sv45M 9g4mk5cx mWzRnLjU HK+nSjSc prPtKwQD n2Lrjifs
 8LLqM9Cn XLz6WkYn PsG+g2s0 BC91Wrkf JBp+AL9/ i5lzn6jD EG+mWLya dPadTCZf QyLVTC7n 0rGrUpNC wTJtzc8T j/4r25/6 lJ1eWn0H ulWth0mm PsX+Q7eT SPm0tU3q
 L9zdEPQX iYSHiUV+ TtD/H7Ve ud/Zl2ql ULzRXIDy Gi1sk5rn dEI0nKej 9aeEQ5/j 0Z3ftdtL rP9At0Ld Szb/foZG PsjgUJve uVK3XE4I BkrEoweI hn9mKveH 57tyf2k4
 vVi6gnTm j5hMXm6d na5KXOqA 31ehJT5E c/xr7Hzm Tru+THsE +pRLL1zK 2MRXGRy6 mEzWrWpd 6r5yD/hK RMPDRMIP Ewp+Do+7 /67+8Jyd WmUq8WvJ ZG8lmbqc iUSbKnGp
 K7FIgdbm HUTDn2Xg yc/b+aXa K9ABLl2z hEzurzl4 +E8Ymwjq 3Sy2qdwD /hJNsQNE w7/A778H j/s3d/WH x2ahEo+a SvyPmUhc SSodI5tz qxKX+vpC 7IK2lhGa YvcTDn6Q
 rTtesPtL tl+gT7l4 9bUMjX6G 4bGlZHNO vbvFVh1V MFAkEhol GnmIYODz Z1q539mX aqVYvJps /hYmk1cx Ptmp1elS t+LRPPHo XuLRT+L3 fY7+gUIj vGz7Bnpf r5NyuZd0
 9m94Yf9t pLMuvcvF dpxOCPpL NMUOmsr9 m2bO/YSV +519qSjF 0uWkM+8h keojkWwh l3drx4jU 9eehtXmc 1qb7CAY+ zSOP/6qR Xr59A326 i1a9naHR /5vhscXk 8qrWxb6V
 e8BfIhoZ IhLaSij4 BTzuh4DE Xf3hypEt ZqXXkM3d RjJ1BWOT 3WRzmhOX +hcKlmhr 3kU8+im8 nu/Vw3Wn CvTTq9bd lCsXkUz9 L148+CYy qtbF5lxO 8PvLRMOj hILP43Im
 KZbayOYW kUzFVYmL fVLMAS3x NB2t38Dv /xqP7vxJ wzZFQwT6 dL0r/4zh sX9gZKyb XF6XvIiI 1KtgoEJH 61M0Rf8Z t/uhRqzK X/Y9nhvP b6xX3LPw CYKBfoKB ZjK5ZRRL
 GoIXEakn Xk+VaCTH ku7PEA1/ HI/nR/x2 +0SjN0vj VejTXbTq FkbG/4Xh sbPIZBXs IiI1XYK6 IBQs0tq0 k+bYB3C7 t9E/kFDD WNwN/eo9 nu/R0bqb cHAjB4du 1+1tIiI1
 KhgoEw4l 6Gz9DD7f ZlzOp+kf 0GpOVehH cfEFVzI6 /imGR88j rVPmRERq o/ByQ1Ms QTz6CNHw 39vhmtPZ 0nhz6Mey eME+Av6f EglVqHI+ 6YyqdRGR +RSNFOho fY7W5k8S
 Dn6EbY8/ rUZRhX5q Ll3TRSL1 GQ6PXMdk 0q89uiIi c8TptLai dbYO0hz/ Oj7vD3hk 5wNqGFXo p+fA4RTn 9HyXSOhF fN7lZLKt lCva4iYi MtvamidZ 0P4wrc3v x+/bwtYd
 T6lRVKHP jL7eINnc Bxgc2sjI eEzVuojI DHO7wOct 097yDPHY JjyeX7B1 +y41jCr0 mbX/UJHD I79gxbL7 iYS6qFQW kyt41DAi IjMgHCrR 0fo87a3f 4dk9N9Kz 8Al+u31Y
 DaNAnz0H Dw9yTs+3 iYafxe8/ h1S6g4qG 4UVETlt3 xyAdrfcR i3yCHb/7 uCmidCbx adKQ++nq Xflexib+ hpHxpWSy Lm1zExE5 CV5PFb+/ SHfHd/D7 7sfn/Rr9 Ayk1zJlz
 qwlOk8/7 H7S3bCUS fjfDo+/k 8EiTGkVE 5DhBHg7m aIrvJB79 Rzzu39A/ MKaGUYVe W/p6gyRS /8HQ6M1M TIZ1i5WI yDRNsSzR 8H7i0S/h 8/4XTuc+ nfKmQK/l UPdSLN1A
 Kv2XHB65 gomEDqYR kcblcVvz kAu7dhIO /RC/9+ts e3xADaNA ry8XrbqF ieQHOHDo Ul3RKiIN xekEv69M W/NeIuH7 CPj/jW07 dMKbAr3e g331m5lI /D2j4xeQ Svs0FC8i
 thYNFwkG ErTE7yXg /5K5DU0L 3uaItq3N psGhZ1i2 9GeEQ4fx ebvJ5lop l1Wxi4h9 eNxVnA4H 3Z0v0t56 D02xT/L4 0/+bxd0H 6R/IqoFU odvT2pV/ yMj4PzA0 ulRD8SJS
 98LBEvHY INHwLwkF /xGXc4L+ gSE1jAK9 MfT1esnl 38dE4r2M TS4jnfFQ 1lC8iNSR oL9CPDZM LPILgv6v 4fH8iP6B nBpmfmnI fa7tP1Tm 0PBvWbb0 F0RDY3g9 3aSzLToj
 XkRqmscN Tgd0tI2w sPOzxMJf ZeczH2ZJ 97P0DxTV QKrQBeCi VW9ndOLD DI+eSzrr UoOISG0k hAOqVYhH 80TD+wmH tvLUrnfQ 19uuoXUF uhxLX6+b fOHtJFLv Z3ziApJp
 P8WS5tlF ZH64nBAM lGhp2k0k 9H283gd5 dOf31TAK dDlZl65Z QqF4M8n0 uzg8spZU Wsfzisjc aorlCIcO 0RT9Ch7P T/G4f6s5 cgW6nIlL 1lxGMvVh Dg1fx0TC pwYRkdlJ
 Aod1IEwk lKej9Zd4 vTsIBf4e qNA/UFID KdBlxqr2 C5eSznyI ick3MJHo 0Dy7iMxI iFerEAqW iYZHCQef IRb9EA7H ENt2PKsG qj9a5V4P Dhya4OzF DxIKPkQk nMHn7aJc
 DlOuOHVt q4icMo8b fL4ynW37 aW+9j3j0 Czy56y9Z vGA/W7eP qIFUocuc VexrFpEv 3EEi9U4O Hl5BvqDF cyJycprj GUKBEWLR b+Pz/gSX 81G27jis hlGgy3y7 ZM0KEsmP
 MzpxOaPj EVXsIvJ7 fN4qbneF RV0/xON+ hoD/k2zd 8YIaRoEu tRns55HL vZfJ5JuY TC4kmfbq sBqRBhfw V+ho3YXX c4B47D04 HeP0D4yp YRToUuv6 ev2Uyysp FG8glb6F
 8ckVpDLW fnZV7iKN we+rEI1M EgocJB79 JE7nHh7d +RM1jAJd 6jfcvRSK byaTvYOx iasYGo2p UURsyuup 4veViISH iYYfwufd ht/370CJ /oGCGkiB LnZy4Yr3 MZn8CwaH
 zieXd6pB ROqc2wVO Z5V4bJJQ YB+hwK/w +7bgdD7H 1h0v0Nfr pH9A824K dLGtl/a0 J97A2EQn 2ZzCXaTe xKN5/L4U 8egv8ft+ gdfzC7bu eFwhrkBX KzSavl43 lUoXxdKN
 pDLvIJFc w2Qypspd pIaFAmU8 nhKtzY/g 8z5J0P9Z XK7n6R+Y UOOIAl3g 0jXdlCtr yedfTypz DYnkYtJZ v/a2i9QA twvc7gpd 7U/h9bxA NPwRHM4E W7fvuosr 2Lhxo9pI
 jrxd1AQN buuOA8AB 4PtceuEy mmLXkcm+ gUTqMhKp OPmCm5KO chaZU35f hfaWvXjc YzTF/xqq BR7Z2a+G EQW6nGS4 b98F7AL+ jUvWLKdQ eBupzM1M JFaTSAYo lbX9TWS2
 BAMV4tEh vJ5xWps2 UMXDozvv gxfVNqJA lzNgXc7w T8A/cema JeTy7yaZ voWR8XNJ pjxqIJEZ EAqWiYQm 8XlHaW3+ n1SrrTz2 xFfYu19t Iwp0mY3K fccLwEeA j9DX2042
 9z+YTL6d odGzyejm N5FTEg6V CPgyBAOH aG36KJVq iIEnP88L B9Q2okCX OdQ/MAR8 FPgofb1O srkPMZl8 J4dHlmsL nMgrTF1R GgkX8XkK hEMv0hT7 ZyDIwJOf oavdrfvG
 RYEutRDu FaaG5QEu XPF+JpPv YWhkpe5s l4bldEKl ArFIAY8n TzT8PLHI pwEYePIz dLb56R/I mc+QwlwU 6FKDtj/1 KeBTAPSu XE8y/ecM j17EZNKr xhFbc7mg XIamWA6v
 J0Mk/Dsi oc04KPDY k1+krzdM /0DKhHhO DSYKdKkf A09uBjYD cPHq60im /5qxiVcx PBZV44gt eNzgcFSJ RxN4PSlC we0EA9/B 4ZjksSfu eUWIp9Rg okCX+vfI zvuB+wG4
 5IKLyGTf z0TyhpeO nnWYM2y0 JU5qnc9b xecrEg6O 4/MOEfDv wO/7MQ7H CI/u/BF9 vUH6BzIK cVGgi/1t e/xR4N0A Zjvc+0hl biSRXEY6 G6BcdlAq O3SXu9SM YKBCOJgi
 4B8i4P8d Hs/TeD0/ xekYZ9vj 2+jrnT4n nlGDiQJd Go+1He6D wAfp6w2T L7yLbO4G 0pk1ZHKt 5As+8nkX xZKOoZW5 43BAJFwg Gj6MzzNE KPgTHM5h fN4fWO/b 7bvo6z2y
 Ol1z4qJA F5nGGp78 N/MDF62+ iULxKvL5 tWRzZ5PN t5LOBLU1 TmY8vF1O 8PtKeL1F muM7cDrS RCMfpVpp 5dEnvkNf bzP9A2Mv u8lMq9NF gS5ykh7d eS9wLwCX rrmQYmk1
 5fIK8oVe MtlzSaQW aPW8nHaI u11VwqEc 4eBhQsEB 3O79hIMf olxexrbH B17xZXPM /KfmgUSB LnJGtu7Y Dmw34d5B NNJCR1sz xVIf2ewN TCbXMj7Z RKHowOWy FtdpDl5e
 yeOuEotk CIf2Ewr+ Ap/3V3g9 36BS6WDr jn3m3xpQ Q4kCXWRu wv0wcBiA vt6t7Hjq 4ybou8gX 3ks6+zqy 2aXkCzEK JS/ZnJti UXPwjcrr qRIOZYlH dxEJfR2f 72s4HYOm
 4p6a+96n hhIFush8 6h8oTAv6 QY4cSeum WLqJYnEt pfIy8oWz yeYWM5Fo 09nzdu3J 3NbhLg7A 5y3j82WJ hp4lGHiQ YOCjgPul oXMRBbpI 3QR9Cfiu +YFLLzwb qiEWdgYp
 li4hl7+R TPYCcvlm CkUvubyL bE5VfF31 XC7w+yDg h0i4QnM8 QShwGK9n K07nL6lW f06lmuKn vzqsxhIF uohdbN3+ /PS4Bz4J wE2vXUy5 0ke+sJxU +gqS6bOY TC5geDRI
 qax2q0U+ H7Q2QXtL is62STzu p3G5HqOj 9X487t24 XHvY9AUt oBAFukhD uffnLwIv AvDut/kp FmPkCy6+ /8CH8Pte R76wlGJJ K+lrRXM8 x9JFu+hq 20Ys+hBt zb8BMlVu
 evkc+Mab XvZfHZvW qe1EgS5i J9WNW473 j3PmB0f2 3n8Avghc hdP5R1Qq q9V689lL udO0NT9E S/zTdLY+ yTk9e6rc VHZwr6PK TdVTee4K d1Ggi9gz xI/1vxkD xhyb1j1D
 pfIz4F3A HUCbWnTO PYXb9VkG h75Svf3f R1/2nE4i zI/1flCw iwJdxMZB fpQ/IwVs d2xatw94 BvifwAq1 7pzZBnyU XP4X1Y1b MrPx/lCw i53oGE2x XZDPRJi/ 4s8cxboK
 9m9NyMjs 2wr8PfCT mQ7z2X6/ iCjQRWq4 Yzah8hMT MlvV4rNq B/APwM+r G7eU7PD+ EVGgi9RQ R2zC5ecm bHao9WfF 88AngJ/N VZi/8v0k Uq/cd3GF WkFqyp08 VLOdb3Xj
 lpJj07qf mdD5CHC2 ntiMGQQ+ DdxT3bil OJ9fEuHU 59fVl4oq dJEarsqP 8f9fBO4x 4TOoJzIj UsAW4KvV jVtytfI+ E1Ggi9i8 kzWh81UT Qik9mTNr TuAR4L9r 7QuSQl0U
 6CKN0bkO mhB6xISS nJ6DwNeB R6obt1T1 vhNRoIvC fK5/p6nK 8usmlOTU VYAHgB9V N24p6P0n okAXhfl8 /W4F4Ecm lHQpyKl7 GvgW8ILe hyIKdFGY z7cXTCg9 rSd2SspY
 e/t/W4tD 7Qp1UaCL NFjnacLo tyacdO/q ydsB/KC6 ccshvS9F FOiiMK+V 3/cQ8AN0 4MzJKgH3 Azv1/hRR oIvCvNbs NCFV0lM8 oSeBHwMj ep+KKNDF hjZu3FjP v/6ICakn
 9SSPq4J1 hO6z1Y1b 6nohoUJd FOgi9gtz TDg9a8JK K96P7QDw cD1X5wp1 UaCL2DTM X1GlP2xC S45uK/B4 deOWvF1e kEJdFOgi 9gpzTEg9 jq5YPZYc 8Ctgv97H Igp0USdY
 6/ab0Mrp Cf+eZ4AB tY2IAl2k XqrQARNe ckQF2AY8 h03PvleV Lgp0UXVu L1UTWtvQ 4rjphoAH gcF6ORlO 72tRoIs0 cKdnwmrQ hNeQnvZL 1fkzwBP1 vlVNRIEu 0kBMaD1h
 QkwBBkWs g3deaIQX qypdFOii 6txeXjAh VtRTZxzY Ud24ZVxN IaJAF6m3 Kn0c62z3 Rg+xMvAi sEtfXEUU 6KJOrl7t MmHWyLew FbCuln1O 73cRBbqo c6tXz5kw KzTwo88A
 z1Q3bjmg 972IAl3U qdUlE2LP mFBrVKPA bn0KRBTo IvVutwm1 hvxOg7WF b6++0Ioo 0EWdWb3b a0Kt2oCv vYR1FO5e fRJEFOgi dgj0/Sbc Gk0O2IMO 2NEXW1Gg izoxGxgy
 odaIF5Ik gN06HU6f B1Ggizqv umfCbLcJ t0Yzgobb 9bkQBbqo 07KRvSbc Gs1hrPUD IqJAF7GF QRNujeYQ MKbHry+8 okAXdVZ2 MWbCrZFU sE7JS+vx 63MiCnRR J2UXaRNu
 jbQ4LGle c0GPX0SB LmIXBRNu yQZ6zcNY oxIlPX59 ARYFuqhz souSCbfh BnrNg8BI deOWqh6/ iAJdxBZM qI3QWCu+ R4AJPX19 ERYFuqhT spsJGmvr 2giQ0mPX 50cU6KLO
 yG5SDRTo UyMSGT12 EQW6iN1k TMg1wpxy GmvffVaP XV+MRYEu 6oTsJmtC rhH2ZY+b 11rUYxdR oIvYTdGE 3HgDvNaE eZ26lEVf kEWBLup8 bKdiQq4R LmlJAaMK dBEFuohd
 A32Uxlj5 PQ5MaA+6 viiLAl3U 6diOCbcJ 7D/kXjGv U1vWRBTo IraVMmFn 56HoonmN CT1ufWEW Bbqos7Gr hAk7O6/+ zmKNQuhS FhEFuoht FUzY2Xl/ dh77j0KI KNBFGtzU
 /HLe5oE+ Wd24RYEu okAXsScT cpM2D/SC eY1yBjS1 JQp0USdT +yax9/xy AS2I0+dN FOiizqUB JGwe6GUg qccsokAX sbukCT27 ygM5PWZ9 kRYFuqhT sbsc9p5D T6MV7iIK
 dJEGUMHe N67lsPcI hL5QiwJd 1JkImLCz 85B0FnuP QIgo0EUE TNjZ+WCZ DDolTl+s RYEu6kQa QMGEnp1f n4bcRRTo IrZXtnkF WwRKesz6 gi0KdFHn YXcl7H85 S1GPWUSB
 LmJ3Rew7 h14yr03b 1vRFWxTo ok7D9iom 9Ow6LK05 dBEFukhD sPMcuhv7 TynoC7co 0EWdhQBH Fo25bfr6 SkBVj1lE gS5id1Xs PdyuMBdR oIs0VKjb cdg9h7VG QKE+yzSS
 Jgp0USdR G2FewZ7H v07NoWtR nIgCXcT2 yth3Dt1h frRtTUSB LqrOba8y LfjsJs+R EQgRUaCL 2D7Qq9jz RrICGnIX UaCLNIip IXfbnude 3bhFi+JE FOgyHzTc rrCbwT7F
 racsokAX aRRum37+ qupXRBTo Io322bNr pa4FcSIK dJGGYefQ c+jxiijQ ZR5o/lyh N8OvS/2K iAJdpKE+ e3YMdTfg 0uMVUaCL qvNG4cKe q8GdgEeP V0SBLtIo PDb9/DkA
 j2PTOm1d E1Ggi6pz ezNh58Ge Q+5VrNGH kJ60iAJd xO5CJvTs uG3NZX7U t4go0EUa 4nM3FXx2 4zU/OvpV RIEuc0HD 7fOqOi34 7MYD+NHx ryIKdJEG 4Dah57Hx 6/PqMYso
 0EXVud15 bVzBVqd9 YRERBbqI rU0NSdt1 ntmH9qKL KNBFGoDH hJ4dObBG IHSeu4gC XWaThtsV enMggI5/ FVGgizQA lwk9u9KQ u4gCXaQh 2HnIfSrQ fY5N6zTs LqJAl9mg
 4fb5Z0LO Z/NAd5nX p/5FRIEu YuvPnA97 zzFPDbmr QhdRoIvY t0jH/kPu YTSHLqJA l9mh4faa 4jGhZ+dA 9+kxiyjQ RezOZ/NA 95rXpwta RBToourc tqom7Lw2 f40RoKLH
 LaJAF7Gr igk7u1av VaAEBKob t6hCF1Gg i9g07ayQ C5jQs2vg Ta3kFxEF uoit2XmP tsN8YYnr MYso0EXs Lm5Cz677 tL1Aqx6z iAJdxO5a sfeiOBcQ 09GvIgp0 mUFa4V5b
 TMjFsPdJ cU4ghIbd RRToIjYW N2Fn58/e 1KK4bj1u EQW6qDq3 q27sf3GJ A/BjjUSI iAJdxJZi JuzsPr8c xt53voso 0EUaXAB7 H/s6JWh+ RESBLmdC w+0Kunnm Q0PuIgp0
 ERuL0Rin qIWBNm1d E1Ggi6pz 2zHh1kZj DLlHzWvV EbAiCnQR 2/GZkIs2 wGt1YY1G ePTYRRTo Inbjwf6H ykwXozFG I0QU6DLz NNxe08I0 1kKxONCk xy6iQBex myYa6zjU
 EI0xvSCi QBdpMFET co0iAgS1 0l1EgS5i GybUgibk GkUc+59b L6JAl5mn +fOa/6w1 2g1kYaxR CZcev4gC XcQuXCbc GmnVtw9o Btx6/CIK dBG7cJtw a6SDVgLA IgW6iAJd
 xG6BvojG uoHMAyxR PyOiQJdT oPnzuvis LaGxTk5z AJ2q0EUU 6CJ2q9A7 sf896K/U QmMtBBRR oIvYXNyE W6MJA13a iy6iQBep eybMumjM c83d5rWr rxFRoMuJ aP68Lj5n
 XTTmXLIf a3W/9qKL KNBF6p7L hJq/AV97 AGhVXyOi QBexy+es lcbasjb9 y0x7g36Z EVGgi9iM 34RaIw47 O8xrj+tt IKJAF6l3 cRNqjbjS 24W1XU/X qIoo0OV4 tCCuLkRN
 qDVihT4V 6KrQRRTo Irao0Bs1 0MG6MrZT bwMRBbpI veukse5B fyUv0K23 gYgCXY5B w+11o9uE WqMKYp0W 59NbQUSB LlKXTIh1 mVBrVH7T Bi16R4go 0EXqVYsJ s0beh+3E
 mnbo0ttB RIEuUq+6 TJg1+met FejQ20FE gS6voPnz utFhwqzR NQGtjk3r dDe6iAJd pL6Y8Go1 YdbowkAb jb04UESB LlKnvCbE wmoKAlin 5QXVFCIK dDE03F43 gibEAmoK
 vKYt9OVG RIEuUnfC JsQ0zGzd Bd8BxNQU Igp0kXoT MyGmhWCW TqDZsWmd Q00hokAX qQsmtJrR GebTNWON WHjUFCIK dJF64THh 1aymeEkE a1++piBE FOiiBXF1 w2vCK6Km
 eEkQWETj 3jonokAX qUMuE17a pvXyLzln KdBFFOgi 9RboZ6Hh 5Vf2N2fr S46IAl2k ngRNeOkz 9nJdQLdj 0zq1i4gC XaS2mbDq RreLHeuL znI1g4gC vaFpQVxd WY6Glo/G
 A6yobtxS UVOIKNBF apoJqxVo v/Wx+pwL 1AwiCnSR enGBPl9H 5QJ6HZvW aTufiAJd pLaZsOpF 27OOxY+1 YFBEFOgi Ne1sE1py bKu00l1E gS5Sy9W5 E1illjgu L7Aa8Kkp
 RBToDUcr 3OuGz4SV DpQ5tiDW lITuRhdR oIvUrLAJ K21ZOzYH sABoUVOI KNBFalWL CSvd+X18 PtNOIqJA F6lJC9Dc 8MmIAOdp YZyIAl2k 5phwOg9d mXoyoliH 77SqKUQU
 6CK1ptWE VFRNcUIB rN0AHWoK EQV6w9AK 97rRYUIq oKY4KQuA TjWDiAJd pNZ0ooVe pyKMhtxF FOgiNagV 7a0+FRGg x7FpnUY0 RBToIrXB hFIPWhB3 KkLA+UC7 mkJEgS5S
 K9pNOIXU FCf/PQhr EeFCNYWI At32tCCu biw04aQD ZU7NErTu QESBLlJD FphwklMT A5Y4Nq3T UbkiCnSR +WXCaIkJ Jzk1HuAc dPa9iAJd pAYETSh5 1BSnZRnQ pWYQUaCL
 zLcuE0py es7BGnZ3 qylEFOi2 pAVxtc+E 0BITSnJ6 FqIRDhEF usg8m5oD 1tarM+uH LkA7BEQU 6CLzWaSb MNJn6cyc g+bRRRTo IvOoCw23 z4SFwLma RxdRoIvM fWluhc+5
 aLh9JnQA KwGXmkJE gS4y11wm hHSn95nz KdBFFOgi 8x3oPjXF jPRFK9Ax sCIKdJF5 sMCEkD5H Z86BdZ/8 +Y5N67Ta XUSBLjJH 6WOFzvkm hBRAMyMG rEYjHiIK dJE55DPh
 o/PbZ7ZN lwNxNYWI At02dEpc zYub8FE1 OXO8pk0X qSlEFOgi c2WRCR+v mmLGOLCO 0dU8uogC XWQOUufI /PkSNH8+ 0yJYCw2j agoRBbrI bIua0Imo KWZcAGvk Q8fAiijQ
 RWZdlwmd gJpixrmB xUCPmkJE gS4y23pM 6Ojc8dnR DaxwbFoX VFOIKNBF ZoUJmRUm dGR2tJg2 blFTiCjQ 65q2rCls GpwH60hd zaOLKNBF Zk2XCRuP mmJWnYWu pRVRoIvM
 onNM2Mjs agFWOTat C6spRBTo IjPKhMsq NNw+F1zA xeiueREF usgsWGhC Rnd2z43L 0F3zIgp0 kVnQYUJG 5kYUONex aZ3WK4go 0OuPVrjX JhMq56Ij SefaxWiK Q0SBLjKD
 Wky4yNwH +mJd1iKi QBeZierc gXUynAJ9 7p1vfjTs LqJAFzlj nmnBInPL b75INakp RBToImeq yYSKX00x Ly4Gehyb 1ml3gYgC XeT0mBDp QcPt8+k8 rON2dbud iAJd5LQF
 TJicp6aY N3HgQiCu xXEiCvS6 oC1rNVed O6aHiVpk Xl2MdQ6A Al1EgS5y 6pluQkTD 7fNvFbAE qKopRBTo NW/Tpk1q hNpSNSGy Sk0x78LA BWhhoogC XeQ0+E2I 6Mav+VcB
 LgUWqSlE FOgip2qR CZGKmmLe ubDuoddo iYgCXeSU rTIhov3P 88+Bdfxu r2PTOg27 iyjQRU4y PazQ6DUh opXVtcEH rME6hldE FOgiJ2Wx CQ+fmqJm uIHlwAXa jy6iQBc5
 mercgbUY brkJEakd XVjbCGNq ChEFusiJ xExodKkp ak4Ia+Sk R00hokAX OZEeExoh NUXNcQHL gJWOTevU f4ko0GuT jn6dfyYk VprQ0Or2 2rQAuAiI qilEFOgi xxI1YbFA
 TVGzAsBq dMiMiAJd 5DgWmbDQ VZ217Wxg lYbdRRTo Ir/HhMMq ExZS26Yu zWlWU4go 0EVeqZkj 13RKbQti XWvbo6YQ UaCLvFKP CYmgmqIu nAdc6Ni0 TmcFiCjQ RSwmFC40
 ISH1oQO4 HOhUU4go 0EWmdJpw 0HB7/XAB l6HV7iIK dJFpFplw 0N7z+rIU 6HNsWqdd CdLw3DrM RBqdCYM+ Ew5SX3zA jcC3gb1q DlGFLtLY Okwo6Ga1 +nQZsFw3 sIkCXaSx
 q3MH1q1q l6k16lYM uAZoUlOI Al2kcTWZ MNB1nPXt KuBsnRwn CnSRxqzO nVinwl2l 1qh752Od wa8zBESB LtKAgiYE zldT1L2p YfeY5tJF gS7SWNW5 Y3oIqEVs 4XVAt5pB
 FOgijafb hIDYQxPw ejTsLgp0 kYYSNJ2/ VkbbRwW4 GlimphAF ukjjWGY6 /4qawjYc WGfxX+bY tM6j5hAF uojde32r s7/MdP5a QGWvQG8B XgO0qTlE gS5if22m 029RoNuO
 B7gSWK2m EAW6iP2t Np2+hmXt qRW4XNvX RIEuYmOm k7/cdPpi T37g1cBa NYUo0EXs a63p7P1q CttyAecC r3JsWudW c4gCXcR+ 1bkbeJXp 7HXvub21 AVcAS9QU okAXsZ8l
 ppPXCmj7 8wKXoGF3 UaCL2NJa 08l71RQN YSFwlWPT uoCaQhTo IjZhOvWr TCcvjcED XIy1ZkJE gS5iE682 nbu2qjWW ZcCVjk3r dAGPKNBF bFCdx7D2 neuM78bT jLVNcbma
 QhToIvVv uenUm9UU Deli4DU6 310U6CL1 XZ17sI55 vVit0bCi wHXA2WoK UaCL1K+z TWceVVM0 tLXAtY5N 63RXuijQ ReqwOg8C 16K9yAId WNflLlVT iAJdpP4s NZ14h5pC
 3++wpl4u cmxap2N/ RYEuUkfV uR+4yHTi unVLADqB G/QFTxTo IvWlw3Te nWoKmVal vxa4TFW6 KNBF6qc6 v8x03qrO 5ZVV+o36 oicKdBF1 2lL/VfpV wIWOTet0 pr8o0EVq
 uDr3Ahea TlvVuRzN EvOFr1VN IQp0kdrV ajpr3YMt x+ICrgdW OzatUx8o CnSRGqzO ncBq01m7 1CJygir9 JlXpokAX qd3q/CZV 53KSfd/1 wAVqClGg i9SeC0wn rfe1nIyl
 wM2OTeta 1BSiQBep EaZTvhkd 7SknzwO8 Dl3cIwp0 kZpysemc dUWmnPT3 QOAs4I2O Tet0ta4o 0EVqoDpv Bt5oOmdt VZNTEcCa prlSTSEK dJH5d6Xp lANqCjkN S0yVrhXv
 okAXmcfq vNVU51rZ LqfLC7wa uEZNIQp0 kflzjemM dYynnIke 4M2OTeu0 qFIU6CLz UJ0vBd5s OmORM+HH usznRjWF KNBF5t6N phPWVZgy E7qw9qXr C6Io0EXm sDrvwdp3
 3qXWkBl0 GXCbY9M6 bX8UBbrI HIS5B7jN dL4iM6kF axpnjZpC FOgis2+N 6XR1ZKfM hrXArY5N 68JqClGg i8xedR4G bjWdrshs CGCNAF2t phAFusjs udp0tjpE RmbTWcAf
 OData1dT SN0UPBvW qtCR+nD3 +p524P8D 3qnWOMEH uwreUoVQ pkw4XcJd rlLwOkkH XGT8Looe BxWHTsk9 gRHgH4DP b9i8t1iL v+CmRx/V U5KXuNUE Uidh7gHW ATeoNY7O
 Wa3iKVaJ ZEo0TRZZ dCjHgqE8 kXQJV6VK yeVgMuLm UIuPwTYf o3EviYib gttJVdl+ NK3AHwLb gEfUHKJA F5kZa0zn qvO2X1mJ FytEUyVa xwt0jeTp Gs4TSxbx lKov+3dd
 5SrtowXa xgqcvztF IuxmsM3P i11+RuNe 0gFV7kdx GXDH3et7 dm/YvHdM zSEKdJEz q86bgTvQ NrWXKnFv oUooW6Z1 osCiwSxd w3mi6RKu chVH9cRf AjylKi0T RVomipy7
 J8V41MNg m59DrV5G mr0kQm6K qtyn3A48 dPf6nu/V 6tC7iAJd 6iHMPVin wd2uStyq xNvGC3QN 5+kYzdM0 WcRVOXGI H4+nVKV9 rEDbeIHz dztJhNwM tvvY3+Fn uNlLxu+i
 4GnocO/E Gh167u71 PY9v2Ly3 qk+mKNBF Ti3MHcAK 05l2Nlwl XqniKVUJ Z0q0TBRZ bCrxiFnk 5pjhWJn6 0tA6UaB1 whqWH4t5 ONjmf2nO PRlyNWrl fh2wFXgR GNenUxTo
 IqcmjnU1 6nWNXIl3 DudpShZx lee2MHSX jsy5r3je yWTEzWCr j/2dfkaa vGQCrkZa UOcH3g48 evf6nvs3 bN5b0sdT FOgiJ1ed u4E+04na +vIVZ6WK t1glnC3R OlZg8aEc
 nSP5l7ab OeZ5gHfq S0bbmAn3 3SnGoh72 d/o53OJj pMlLKtgQ lfsK4I+A 54Bd+pSK Al3k5Cw1 necKW4a4 WdgWSZdo HyvQaVan x+ehEj+t yt3MuRc8 U5W7nwMd PkbiXjJB
 W1fubwQe uXt9z79v 2Lw3pY+p KNBFjl+d h4G3mM7T diEezlgh vvBQjs5R Mydeqr91 Vo4q+AoV 2kcLtI9a w/ITUTcH 2v0c6PAz GvOQtl/l HsAaNXr6 7vU9P96w eW9Bn1hR
 oIscPcy9 WKva344N jnedCvFo 2uwTH8rT PZwjmirV fCV+qjwl a1i+dbzA +c+nmIh6 GGzzcbDd qtxtFO69 wB8Az969 vudZrXoX BbrI74e5 A2uo/Q9M p1nXIR5J l+gYy9N9
 2NpiVitz 4nNSuRcr dIxar3tq Qd2+Tj8H 2/2MxTyk gi5KrroO 95uBF4CP AzpwRhTo Iq/QhLVF 7ea6C/FK FV+xQiRl HfayYOjI savucmMX cNMX1K3c lWI85uFQ q1W5j8br
 dkFdFOso 4p13r+/5 mqp0UaCL vLw6v8F0 ktF6qsRj qSIdowW6 hnJ0jBXq dk58LviK FTpHXl65 7+/ws7/T qtwz/roK 93OA9wHP ArolRRTo IsZa0zme U/OVeKFC JF2mZdJa
 2NY9lCOc KdtuTnw2 Td8K1zpe YMVzKcbi R46frZPK 3QlcDLzn 7vU9H9uw ee9BPVlR oEujV+cL gPeYztFZ 65X4gqEc 7aOFl24x cyjHzzjc fcWKdYjO SJ6i+8hq +f2dfkZj
 XjIBZ63O uQeAN2Ad C/vJDZv3 5vRERYEu jRrmfqz7 zd9ADa1q d1WqeItW Jd46XmDh 4RwLDucI Z1WJz0Xl fuSEuhSj pnIfbPUx bhbU1VDl 7gAWYF0e tAv4jp6i KNClUd1o
 OsMFpnOc 30qxUCGe PDIn3j41 J64Qn7fn sWDIOnRn 6hCblyr3 uJeM30nR Pe+DOk5g JbDh7vU9 hzZs3tuv pycKdGm0 6rwP2GA6 w3nplV2V Kt5ChXDG qsSXDGbp HM6rEq/R
 cJ+q3Fc+ l2K4yctg m4/DrT5G 4x7rPvf5 q9xdWNf7 vv/u9T2D GzbvfUFP TRTo0ihh vgR4v+kE XXNaTpk5 8aZEkfbR PJ2jBTpG jtwnLrUf 7t5ihe6h HAuGcxQ8 TiYiHg50
 +KwT6kzl Pg9z7lPz 6WN3r+/5 +IbNe/fp aYkCXewe 5ouAv2IO 581dZnV6 KFOmbbzA koNZOkfy hFSJ26Jy 7xjN0z6W Z+WuFKNN Xg60+zhk 5tznuHJv Bm4FBu9e 3/PpDZv3
 TugpiQJd 7BrmcaxF cLeazm/2 KnET4vFk SZV4o4R7 scKCoRyd w3kKXgcT EQ8H230c bLeufE37 XZRdjtkO 9y6sLZjJ u9f3fE7n vYsCXewY 5l4T5u8z nd6sVeKR dIn20QKL
 zFWkwZwq 8UbirFbx 56t05q1D bFbtsubc 93f6GWrx MhbzkA64 KbpnJdkd wBLgL4Dx u9f3fH3D 5r1lPRVR oItdwtxl qvK/MJ3d jId4LGnd YtY1lKNj 2j5xUeU+ NefeZSr3
 8aiHg+1+ DrT7GIt7 yfhdlGa+ cj8X+Dsg D2zRkxAF utjFW0zn du5MV+Kd IwUWHsrS PlYglC3j 1GEvcoLK feoQm1W7 nIzErcr9 UKuPiaib dMA9U+Hu AFYBH7h7 fU8W+NGG
 zXsregqi QJd6rcyd WHvNP2A6 t9PuJl2V Kr58hVjK mhNfYDrl UKasSlxO q3L3FY5U 7nmvk7G4 dXHMAXNx TPbMK3cH 1gmI/xfg uXt9zw80 /C6z9p7e sHatWkFm K8xdWDen
 /R1wKaex 13xqYVss VaJrOM/C wznaxgoE c6rEZXZU HVDwOBmN e9lnKvfx qLVavnRm c+6/Bf4f 4PsbNu8t zsTvuulR 3QkjqtBl 9sPcA7zR VOaXnVIl XrauIn1p TnzYqqDC
 GSvEReai cl8wlKNr OEfW52Is 5mGwzcdg m4+RJi85 32lV7peZ Sj109/qe b2/YvDel 1hYFutR6 mIeBt2Lt Nb/wZCtx f6FCPFGi Y9SqxFvH CxpOl3kP 92CuTDBX pnso97LK
 fbDNqtwz /lOq3C8E PgxE7l7f 81XtUxcF utRymMeB d2Ad6br8 RJW436xO n7oAZeqw F1XiUsuV e+dwnpzP aV0c037k 4piTXC2/ HPgbU6lv 3rB57yG1 rijQpdbC vBNYD/w5
 sPT4lXiR ruE8C4by tI0XCGZV iUv9cFar VuV+qMzC wzlrQV3M w77OAAfb rcp9akHd MSzFGsFq v3t9zxeA Z7VYTs74 S6cWxckM BLnLVB3v xro5rfNo lXg0VaJt rMCiQ9ax
 q4FcRSEu tlJ1QM7n YqjZy8F2 H4dbpsL9 mLfCpYEf A58Ffr1h 897kqfz/ aVGcKNBl JsM8Arwa eA9wAxCa Xok3TRbp HDlSiWs4 XRop3PNe J6MxLwc6 /BzoODLn Xv79yv1R
 YDPwLeDg yVbrCnRR oMtMVeUL gFuwhtkv elklPl5g 0WCWruE8 gXxFIS4N H+5Zn4vh aZX7RNRD +uUL6kaw TpT7L2AA SG/YvLeq QBcFusxm mIeBXuCd rnJ1nb9Q aY0nitZB
 L8OaExc5 norD8dIh Ngc6rONn p825F4Hf AN8EfgS8 CBSOFewK dJlOi+Lk lL8E+vOV 9/gL5beF suWLWscK 7sWDOTpG rTlxZ1Uh LnI8zmqV QL5M9+Ey C4ZyrPa6 GGqxhuUP
 t3g9kxHP lRm/6/yi 23GNCfVf 3L2+50Ug d6KKXRTo IicMccAL tALL1zyT +Fj7aCGs OXGRM/xg VSGQL7Pk YJZFg7kj W+Ha/G0H 2n1vGY95 rs75XL8u uh33Af1Y c+0iCnQ5
 5RD3Yd1Z fjawFrge WHvpzsmw Qlxk5iv3 6VvhVntd HG71xg90 +N8w3OS9 IhFyPwdc DmQBfQDl 9zttzaHL UUK8BVgG 9GGtYF+D tQBOXwBF 5ljF4SDn t26FWzyY /SfgQeAp
 YAzralaF uyjQ5aiV +KXAdcAF QBvg4gxu SBORGVUC JoBtwM+w VsPvAoaB nMK9sani atwQ95rA PhfresfX YA2rt5l/ JiK12We3 Aq8HrjVB /hTwK6zV 8b8DRhXu CnRpnEp8
 GfAq4BpT ibfovSBS d7xAN9Z0 2DUmyAeA nwKPALtV uSvQxX6V eDtwHtbe 8cuBi0wl 7kbD6SJ2 +Jy7zOf8 BlO5Hwae MJV7P/CM CXfNuSvQ pc4+3B7M FjOsofTX AquBJoW4
 SEP0693m 51qsxXM7 gJ8AvwX2 oGF5BbrU dIj7zDf0 ZVhz4Vdg zY236TmL NHQf3461 0PVqYBDY CTxswn0X 1pGzCncF usyzqS1m 52ENpV8F rDR/T6vT RWQ6D7AY WIQ1ND9q
 KvcHTMDv NeFeULgr 0GVuKvGA qbrPNhX4 lcAlWIvd FOIicjL9 yFTlfj3W sPxB4DGs lfJTlfso mnNXoMuM C3BkTvwq rHlxVeIi cqbBjulD FgELgZuw Fs/twFot v9WE+7gJ
 d1Ggy2lW 4u3AOVir 0l+LNTc+ VYmLiMxG 5d5lfq4F DmEdYvNr rHPkVbkr 0OUUQrwF WIE1J/4a 89faJy4i c81jqvaF wBtN5b4d 6+jZXwPP Ya2gLyrc Fehihbjf fBtehrVP
 /FrgQqwt Zk40nC4i 89tHTYX7 AvNzvanc +4GHTMg/ r8pdgd7I lXg71rGr l2Od2rZK lbiI1Elu LATWAW8G hoDHp1Xu U8PyRTWV At3OId7B kVvMrsa6 xSyG5sRF pD77NQ9H
 jp99HdYJ db8x4f74 tMpdW+EU 6HXNiTWc 3o41D/4q NCcuIvYO 94XAraZy P4S1Wn7q 4phnsFbL q3JXoNfN m9oPdHLk ApRrsbaY xdCcuIg0 Rj/oxdoK twi4cVrl /oCp3Pdi
 LahT5a5A r7lKfGqf +ErgMqx5 8VVYC9s8 aiIRadBg 5yiV+9Qh Nr/myCE2 Y6rcFei1 UIkvB15t KvHz0Zy4 iMjxKvce YAnWVrgh E+w/xRqe fwFrWF6V uwJ91ivx IEdWp7/a
 /EzdYqYT 20RETj7c pxbUTVXu B7Duc38Y a0vcc2jO XYE+w2+6 INbZ6edj DaVfjbWw LaJKXERk xir3paZy v9lU7v1Y V75uB16c Fu6q3BXo p1yJd5lK /FKs1elr gLhCXERk
 VvtfL0fm 3N9oKvdH TeW+TZW7 Av1k3kRT +8TPw7oA 5Urz11Hz z0VEZG75 gLOw5t3f ZCr3bcAP sebcpyr3 gpqqsQN9 KsS7TXBP VeIXmErc iTW0o3lx EZH57699 HNkK90as
 BXRbsVbK b8U6xGai kSv3Rgt0 BxDiyBaz qUp8GUff J64wFxGp PR6smyjP Bm7B2uf+ CHA/1vD8 C8AkDTbn 3giBPjUn vgBrMdsl wBVYq9M1 nC4iUt9F mh9YbH5u xhqG34Y1
 5/6Yqdwn aYBhebsG uss85AVY q9OvwhpO X25CXAvb RETsFexg DctPVe5v NZX7NuBn 5j+nV+4K 9DqoxBdO q8SnVqeH zQPXELqI iP3DfepC rB7z82YT 5v1YB9ls B3ZjnVBX
 UqDXToiH sA57WYW1 R/xVqsRF RGQaL9Za qbOxtsMN Ys25v7Jy r+twr8dA nwrxLhPi F2MNqa8y f9857Vua iIjI9PwI YG2FO8tU 7vuwboSb qtz3Uqer 5d119BBC WGenrwBe
 ayrxZarE RUTkNE2f c78d6xCb R4Bfmsp9 Tz1V7rUc 6K+sxC/l yLGr0ytx ERGRMzE1 536O+Xmr qdwfBh7E uvK15hfU 1VqgO7EW sLUDF2It atOcuIiI zEflfhbw NhPmj2EN
 zW/DWlCX qLXKvRYC fSrEF2Cd 2PYa4BoT 4iE0Fy4i IvOXTwGT TediHWKz H3gI+Dnw JNa+95qo 3Ocr0F0m rBdgHbX6 KlXiIiJS w6YOsTnb VO63mzDf irWgbvoh NmW7B/or
 K/ErsRa3 nWPCfXqj iYiI1Gqw T12tfZ4p RG8zlfuv TOW+E2sO PjGXlfts B7oT697w qUq8D3j1 tEpcC9tE RKSeTQ3L LzMF6u1Y q+O3mcp9 wFTuidmu 3Gcj0KeG 0xeaby9X
 m2r8LI7M iasKFxER O1bvQazL v87HWlB3 0FTu92Ot lj8IJGej cp+pQJ8a Tl/EkTnx PqxFBGFV 4iIi0oCV e5Aj+9z/ ANjFkTn3 7RxZLV+Z 70B3mbCe OuzlWqxb zM4yww9a
 2CYiInJk Qd1qrHNV 3o41x/5r 4AGsYflD Z1q5n2qg T1XiPeaX ugxrTvx8 E+KqxEVE RI4f7kGs EezlWHPu zwO/wbo8 ZqpyT55q 5e4+yX8n zJET214L XG5CXSe2 iYiInFm4
 r8aad7+D I7fC/dRU 7oNAipM4 xMZ9nEo8 gnVh/AWm Er/cfJtQ JS4iIjKz pubczzc/ U3PuDwO/ xVpQtxdr n3vlRIE+ VYl3YN0h fg3WcPpS juwT1+p0 ERGR2Rcw BfVKYP20
 yv3nWIfY HDSVe3l6 iMdMaK/i yIlt55o/ TAEuIiIy f6YWoK/E WoD+dqw5 94ew5t0f xzqxLuEG /gnrPvEe NCcuIiJS q6bPua8w lfturGH5 7zo2rF1b VoiLiIjU rQow5lSY
 i4iI1DUn 0Pr/DwAI pB1Mpi7h 4wAAAABJ RU5ErkJg gg==</ImageDataBase64String>
         </Image>
      </Label>
   </Labels>
   <PageIndexText />
   <SpecifyStartDate />
   <SpecifyEndDate />
   <PageSettings>
      <LeftMargin>50</LeftMargin>
      <TopMargin>50</TopMargin>
      <RightMargin>50</RightMargin>
      <BottomMargin>50</BottomMargin>
   </PageSettings>
   <FooterDescription />
   <PageTitlePosition>BottomRight</PageTitlePosition>
   <GridYSplitInfo />
   <Zones />
   <Ticks>
      <Tick Value='1' Text='1' />
   </Ticks>
   <SymbolSize>22</SymbolSize>
   <PageIndexFont>
      <Name>黑体</Name>
   </PageIndexFont>
   <BigVerticalGridLineColorValue>#000000</BigVerticalGridLineColorValue>
   <Title>南京都昌信息科技有限公司</Title>
   <SpecifyTitleHeight>300</SpecifyTitleHeight>
   <HeaderLabels>
      <Label Title='姓名' ParameterName='name' Value='' />
      <Label Title='性别' ParameterName='sex' Value='' />
      <Label Title='病区' ParameterName='section' Value='' />
      <Label Title='住院号' ParameterName='id' Value='' />
      <Label Title='住院日期' ParameterName='indate' Value='' />
   </HeaderLabels>
   <NumOfHoursInOnePage>28</NumOfHoursInOnePage>
   <HeaderLines>
      <Line Name='shichang' AfterOperaDaysFromZero='false' Title='时长' ValueType='DurationTick'>
         <DataSource />
         <Scales />
      </Line>
   </HeaderLines>
   <FooterLines>
      <Line InputTimePrecision='Hour' Name='chanhengshijian' AfterOperaDaysFromZero='false' Title='产程时间' ValueType='DurationTick'>
         <DataSource />
         <Scales />
      </Line>
      <Line BottomSpacing='50' Name='qishishijian' AfterOperaDaysFromZero='false' Title='2016-11-21' ValueType='HourTick'>
         <DataSource />
         <Scales />
      </Line>
      <Line InputTimePrecision='Hour' Name='jianchashijian' AfterOperaDaysFromZero='false' Title='检查时间'>
         <DataSource />
         <Scales />
      </Line>
      <Line InputTimePrecision='Hour' Name='xueya' AfterOperaDaysFromZero='false' Title='血    压' SpecifyHeight='100'>
         <DataSource />
         <Scales />
      </Line>
      <Line InputTimePrecision='Hour' Name='gongsuo' AfterOperaDaysFromZero='false' Title='宫    缩' SpecifyHeight='100'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='yangshui' AfterOperaDaysFromZero='false' Title='羊    水' SpecifyHeight='100'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='beizhu' AfterOperaDaysFromZero='false' Title='备    注' SpecifyHeight='300'>
         <DataSource />
         <Scales />
      </Line>
      <Line Name='qianming' AfterOperaDaysFromZero='false' Title='签    名' SpecifyHeight='150'>
         <DataSource />
         <Scales />
      </Line>
   </FooterLines>
   <YAxisInfos>
      <YAxis IsDrawContent='true' Name='taixinlv' AllowInterrupt='false' SpecifyTitleWidth='150' AllowOutofRange='true' Title='胎心率（次\分）' YSplitNum='10' ValueFormatString='0.0' RightOffset='0' MaxValue='180' MinValue='80' BottomTitle='' SymbolColorValue='#0000FF'>
         <TopPadding>0.04</TopPadding>
         <BottomPadding>0.5</BottomPadding>
         <DataSource />
         <ShadowPointVisible>true</ShadowPointVisible>
         <Scales />
      </YAxis>
      <YAxis MergeIntoLeft='true' IsDrawContent='true' Name='taitouxiajiang' InputTimePrecision='Hour' AllowInterrupt='false' SpecifyTitleWidth='150' AllowOutofRange='true' Title='胎头下降（厘米）' YSplitNum='10' RightOffset='-5' MaxValue='5' MinValue='-5' SymbolColorValue='#008000'>
         <TopPadding>0.54</TopPadding>
         <BottomPadding>0</BottomPadding>
         <DataSource />
         <ShadowPointVisible>true</ShadowPointVisible>
         <Scales />
      </YAxis>
      <YAxis IsDrawContent='true' Name='taixinlv2' AllowInterrupt='false' SpecifyTitleWidth='150' AllowOutofRange='true' Title='胎心率2（次\分）' YSplitNum='10' ValueFormatString='' RightOffset='0' MaxValue='180' MinValue='80' BottomTitle=''>
         <TopPadding>0.04</TopPadding>
         <BottomPadding>0.5</BottomPadding>
         <DataSource />
         <ShadowPointVisible>true</ShadowPointVisible>
         <Scales />
      </YAxis>
      <YAxis MergeIntoLeft='true' IsDrawContent='true' Name='gkkz' InputTimePrecision='Hour' AllowInterrupt='false' SpecifyTitleWidth='150' AllowOutofRange='true' Title='宫口扩张（厘米）' YSplitNum='10' RightOffset='-5' MaxValue='10' SymbolColorValue='#FF00FF'>
         <TopPadding>0.54</TopPadding>
         <BottomPadding>0</BottomPadding>
         <DataSource />
         <ShadowPointVisible>true</ShadowPointVisible>
         <Scales />
      </YAxis>
   </YAxisInfos>
</FriedmanCurveDocumentConfig>

";
            FriedmanCurveControl1.ClearData();
            DateTime startDate = DateTime.Today.AddHours(15);

            // 设置病人基本信息
            FriedmanCurveControl1.SetParameterValue("name", "李四");
            FriedmanCurveControl1.SetParameterValue("sex", "女");
            FriedmanCurveControl1.SetParameterValue("section", "胸外科");
            FriedmanCurveControl1.SetParameterValue("id", "000134");
            FriedmanCurveControl1.SetParameterValue("indate", startDate.ToString("yyyy年MM月dd日"));

            FriedmanCurveControl1.DocumentConfig.LineWidthZoomRateWhenPrint = 3;
            FriedmanCurveControl1.DocumentConfig.BothBlackWhenPrint = true;
            FriedmanCurveControl1.DocumentConfig.Labels[0].ShowBorder = true;
            FriedmanCurveControl1.ShowTooltip = true;
            Random rnd = new Random();

            // 添加数据
            // 总计的天数
            // 页脚标题行 **********
            // 检查时间数据
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                FriedmanCurveControl1.AddPointByTimeText("jianchashijian", startDate.AddHours(iCount), "0");
            }
            // 血压
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                FriedmanCurveControl1.AddPointByTimeText("xueya", startDate.AddHours(iCount), "11");
            }
            // 宫缩
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                FriedmanCurveControl1.AddPointByTimeText("gongsuo", startDate.AddHours(iCount), "11");
            }
            // 羊水
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                FriedmanCurveControl1.AddPointByTimeText("yangshui", startDate.AddHours(iCount), "2");
            }
            // 备注
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                FriedmanCurveControl1.AddPointByTimeText("beizhu", startDate.AddHours(iCount), "3\r\n3\r\n3");
            }
            // 签名
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                FriedmanCurveControl1.AddPointByTimeText("qianming", startDate.AddHours(iCount), "4\r\n4\r\n4");
            }

            // 中间数值信息 ********************
            // 胎心率
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                float v = FriedmanCurveDocument.GenerateTestValue("胎心率", 80, 180);
                FriedmanCurveControl1.AddPointByTimeValue(
                    "taixinlv",
                    startDate.AddHours(iCount),
                    v);
            }

            // 胎心率2
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                float v = FriedmanCurveDocument.GenerateTestValue("胎心率2", 80, 180);
                FriedmanCurveControl1.AddPointByTimeValue(
                    "taixinlv2",
                    startDate.AddHours(iCount),
                    v);
            }

            // 宫口扩张
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                float v = FriedmanCurveDocument.GenerateTestValue("宫口扩张", 0, 10);
                FriedmanCurveControl1.AddPointByTimeValue(
                    "gkkz",
                    startDate.AddHours(iCount),
                    v);
            }

            //// 胎头下降
            for (int iCount = 0; iCount < totalHours; iCount++)
            {
                float v = FriedmanCurveDocument.GenerateTestValue("胎头下降", -5, 5);
                FriedmanCurveControl1.AddPointByTimeValue(
                    "taitouxiajiang",
                    startDate.AddHours(iCount),
                    v);
            }

            FriedmanCurveControl1.RefreshView();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FriedmanCurveControl1.ClearData();
            FriedmanCurveControl1.RefreshView();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(Application.StartupPath + "\\FriedmanCurve.xml", FileMode.Open))
            {
                this.FriedmanCurveControl1.Document.Load(fs);
            }
            FriedmanCurveControl1.RefreshView();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(Application.StartupPath + "\\FriedmanCurve.xml", FileMode.Create))
            {
                this.FriedmanCurveControl1.Document.Save(fs);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using (dlgRegister dlg = new dlgRegister())
            {
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    FriedmanCurveControl1.SetRegisterCode(dlg.RegisterCode);
                    FriedmanCurveControl1.Invalidate();
                    DCSoft.Writer.WinFormDemo.Properties.Settings.Default.TimeLineRegisterCode = dlg.RegisterCode;
                    DCSoft.Writer.WinFormDemo.Properties.Settings.Default.Save();
                }
            }
        }

    }
}
