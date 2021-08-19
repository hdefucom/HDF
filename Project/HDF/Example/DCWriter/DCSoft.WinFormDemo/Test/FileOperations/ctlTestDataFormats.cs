using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestDataFormats : UserControl
    {
        public ctlTestDataFormats()
        {
            InitializeComponent();
        }


        private void frmTestDataFormats_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void UpdateWriterDataFormats(object sender, EventArgs e)
        {
            WriterDataFormats formats = WriterDataFormats.None;
            if (btnAcceptImage.Checked)
            {
                formats = formats | WriterDataFormats.Image;
            }
            if (btnAcceptRTF.Checked)
            {
                formats = formats | WriterDataFormats.RTF;
            }
            if (btnAcceptText.Checked)
            {
                formats = formats | WriterDataFormats.Text;
            }
            if (btnAcceptXML.Checked)
            {
                formats = formats | WriterDataFormats.XML;
            }
            if (btnAcceptKBEntry.Checked)
            {
                formats = formats | WriterDataFormats.KBEntry;
            }
            myWriterControl.AcceptDataFormats = formats;

            formats = WriterDataFormats.None;
            if (btnCreateHtml.Checked)
            {
                formats = formats | WriterDataFormats.Html;
            }
            if (btnCreateImage.Checked)
            {
                formats = formats | WriterDataFormats.Image;
            }
            if (btnCreateRTF.Checked)
            {
                formats = formats | WriterDataFormats.RTF;
            }
            if (btnCreateText.Checked)
            {
                formats = formats | WriterDataFormats.Text;
            }
            if (btnCreateXML.Checked)
            {
                formats = formats | WriterDataFormats.XML;
            }
            
            myWriterControl.CreationDataFormats = formats;
            myWriterControl.CommandControler.InvalidateCommandState();
        }

        private void btnInsertHTML_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("InsertHtml", false, @"<table border='1'>
    <col width ='200px' />
    <col width ='100px' />
    <col width ='100px' />
    <tr bgcolor='gray'>
        <td>药品名称</td>
        <td>用药途径</td>
        <td>用药频次</td>
    </tr>
    <tr>
        <td>苯磺酸氨氯地平片</td>
        <td>口服</td>
        <td>3/日</td>
    </tr>
    <tr>
        <td>氯化钠注射液（0.9%）</td>
        <td>静脉注射</td>
        <td>1/日</td>
    </tr>
    <tr>
        <td>注射用氨曲南</td>
        <td>静脉注射</td>
        <td>1/日</td>
    </tr>
</table>");
        }

        private void mInsertRTF_Click(object sender, EventArgs e)
        {
            this.myWriterControl.ExecuteCommand("InsertRTF", false, @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}
{\colortbl ;\red255\green0\blue0;}
{\*\generator Msftedit 5.41.21.2510;}{\info{\horzdoc}{\*\lchars ([\'7b\'a1\'a4\'a1\'ae\'a1\'b0\'a1\'b4\'a1\'b6\'a1\'b8\'a1\'ba\'a1\'be\'a1\'b2\'a1\'bc\'a3\'a8\'a3\'ae\'a3\'db\'a3\'fb\'a1\'ea\'a3\'a4}{\*\fchars !),.:\'3b?]\'7d\'a1\'a7\'a1\'a4\'a1\'a6\'a1\'a5\'a8\'44\'a1\'ac\'a1\'af\'a1\'b1\'a1\'ad\'a1\'c3\'a1\'a2\'a1\'a3\'a1\'a8\'a1\'a9\'a1\'b5\'a1\'b7\'a1\'b9\'a1\'bb\'a1\'bf\'a1\'b3\'a1\'bd\'a3\'a1\'a3\'a2\'a3\'a7\'a3\'a9\'a3\'ac\'a3\'ae\'a3\'ba\'a3\'bb\'a3\'bf\'a3\'dd\'a3\'e0\'a3\'fc\'a3\'fd\'a1\'ab\'a1\'e9}}
\viewkind4\uc1\pard\sa200\sl276\slmult1\lang2052\f0\fs22 1\cf1 2\cf0 3\par
}");
        }

        private string _xmlData = @"<?xml version='1.0'?>
<XTextDocument xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
  <XElements>
    <Element xsi:type='XTextBody'>
      <XElements>
        <Element xsi:type='XString'>
          <Text>111</Text>
        </Element>
        <Element xsi:type='XString' StyleIndex='0'>
          <Text>111</Text>
        </Element>
        <Element xsi:type='XString' StyleIndex='1'>
          <Text>11</Text>
        </Element>
        <Element xsi:type='XString' StyleIndex='2'>
          <Text>1</Text>
        </Element>
        <Element xsi:type='XString'>
          <Text>11</Text>
        </Element>
        <Element xsi:type='XParagraphFlag' />
      </XElements>
    </Element>
    <Element xsi:type='XTextHeader'>
      <XElements>
        <Element xsi:type='XParagraphFlag' />
      </XElements>
    </Element>
    <Element xsi:type='XTextFooter'>
      <XElements>
        <Element xsi:type='XParagraphFlag' />
      </XElements>
    </Element>
  </XElements>
  <Info>
    <CreationTime>2012-03-29T15:47:51.1032576+08:00</CreationTime>
    <LastModifiedTime>2012-03-29T15:47:51.1042577+08:00</LastModifiedTime>
    <LastPrintTime>1980-01-01T00:00:00</LastPrintTime>
    <Operator>DCSoft.Writer Version:1.0.1111.28434</Operator>
  </Info>
  <DefaultFont>
    <Size>12</Size>
  </DefaultFont>
  <ContentStyles>
    <Default>
      <FontName>宋体</FontName>
      <FontSize>12</FontSize>
    </Default>
    <Styles>
      <Style Index='0'>
        <Bold>true</Bold>
      </Style>
      <Style Index='1'>
        <FontSize>24</FontSize>
        <Bold>true</Bold>
      </Style>
      <Style Index='2'>
        <FontSize>24</FontSize>
      </Style>
    </Styles>
  </ContentStyles>
  <DocumentGraphicsUnit>Document</DocumentGraphicsUnit>
  <PageSettings>
    <DesignerPaperWidth>0</DesignerPaperWidth>
    <DesignerPaperHeight>0</DesignerPaperHeight>
  </PageSettings>
  <CustomerParameters />
</XTextDocument>";

        private void btnInsertXML_Click(object sender, EventArgs e)
        {

            this.myWriterControl.XMLText = _xmlData;
        }

        private void btnInsertOldXML_Click(object sender, EventArgs e)
        {
            string xml = @"<emrtextdoc version='1.0' checkcount='0' senior=''>
  <underwritemarks />
  <savelogs>
    <savelog name='周云美' time='2012-01-10 10:00:22' level='0' />
    <savelog name='周云美' time='2012-01-10 10:45:22' level='0' />
  </savelogs>
  <headstring>&lt;a&gt;&lt;text fontname='仿宋_GB2312' fontsize='12' bold='bold' center='center'&gt;仪征市刘集镇卫生院&lt;/text&gt;&lt;text fontname='仿宋_GB2312' fontsize='18' bold='bold' center='center'&gt;&lt;/text&gt;&lt;text fontname='仿宋_GB2312' fontsize='12' center='center'&gt;姓名：胡月     住院号：78     科室：妇产科     床号：22   &lt;/text&gt;&lt;line thick='5' &gt;&lt;/line&gt;&lt;/a&gt;</headstring>
  <headheight>259</headheight>
  <footerstring>&lt;a&gt;&lt;line thick='2'&gt;&lt;/line&gt;&lt;text fontname='宋体_GB2312' fontsize='10' center='center' &gt;第[%pageindex%]页&lt;/text&gt;&lt;/a&gt;</footerstring>
  <footerheight>177</footerheight>
  <docsetting title='' id='p7' modifytime='20120110104522' version='1.0' pagesize='Executive' />
  <script runpwd='' editpwd=''>
</script>
  <text>
手术记录

姓名：胡月     性别：女   年龄：19岁    科室：
手术日期：     2012             年      01月       07日
术前诊断：1孕1产0孕40周待产LOA   2社会因素
术后诊断：孕1产1孕40周已产LOA   2成熟男婴    
手术名称：子宫下段剖宫产术
手术者：   周云美                             助手：朱卫国
麻醉方法：      连硬麻                      麻醉者：陈海云
手术经过（术中出现的情况及处理）：麻醉成功后，取平卧位，常规消毒铺巾，取下腹正中纵切口约10CM,逐层进腹，探查子宫如孕足月大小，子宫下段形成好。遂行子宫下段剖宫产术。围纱排开肠管，弧形剪开膀胱、子宫返折腹膜，下推膀胱。切开子宫肌层，钝性向两侧分离约2cm，破膜，见羊水流出，羊水清，尽量洗净羊水，将子宫肌层切口再次钝性向两侧分离至8cm，术者右手伸入宫腔，上托抬头，助手按压宫体协助胎肩胎体娩出，将其解开后，清理呼吸道、断脐后交台下处理，鼠齿钳钳夹子宫切口四周，宫体注射缩宫素20u，待胎盘剥离后，牵引脐带协助胎盘、胎膜娩出，检查胎盘、胎膜完整，脐带位于胎盘中央，小纱布擦净宫腔残留物后，0号可吸收线连续缝合子宫肌层，间断加强，连续缝合膀胱子宫反折腹膜，探查子宫切口无渗血，双侧附件无异常，清点纱布、器械无误后逐层关腹，内锋皮肤层。
          新生儿Apgar评分为10分，为一成熟男婴。
           术中麻醉满意，血压平稳，出血约200ml，术中补液800cm,尿量300cm,母子安反病房继术中补液，给抗感染治疗，请注意阴道出血。
														周云美
</text>
  <body id='C2930BD7'>
    <text>
手术记录

姓名：胡月     性别：女   年龄：19岁    科室：[住院科室]     病案号：
手术日期：     2012             年      01月       07日
术前诊断：1孕1产0孕40周待产LOA   2社会因素
术后诊断：孕1产1孕40周已产LOA   2成熟男婴    
手术名称：子宫下段剖宫产术
手术者：   周云美                             助手：朱卫国
麻醉方法：      连硬麻                      麻醉者：陈海云
手术经过（术中出现的情况及处理）：麻醉成功后，取平卧位，常规消毒铺巾，取下腹正中纵切口约10CM,逐层进腹，探查子宫如孕足月大小，子宫下段形成好。遂行子宫下段剖宫产术。围纱排开肠管，弧形剪开膀胱、子宫返折腹膜，下推膀胱。切开子宫肌层，钝性向两侧分离约2cm，破膜，见羊水流出，羊水清，尽量洗净羊水，将子宫肌层切口再次钝性向两侧分离至8cm，术者右手伸入宫腔，上托抬头，助手按压宫体协助胎肩胎体娩出，将其解开后，清理呼吸道、断脐后交台下处理，鼠齿钳钳夹子宫切口四周，宫体注射缩宫素20u，待胎盘剥离后，牵引脐带协助胎盘、胎膜娩出，检查胎盘、胎膜完整，脐带位于胎盘中央，小纱布擦净宫腔残留物后，0号可吸收线连续缝合子宫肌层，间断加强，连续缝合膀胱子宫反折腹膜，探查子宫切口无渗血，双侧附件无异常，清点纱布、器械无误后逐层关腹，内锋皮肤层。
          新生儿Apgar评分为10分，为一成熟男婴。
           术中麻醉满意，血压平稳，出血约200ml，术中补液800cm,尿量300cm,母子安反病房继术中补液，给抗感染治疗，请注意阴道出血。
														周云美
</text>
    <p align='2' />
    <span fontname='Microsoft Sans Serif' fontsize='23' fontbold='1'>手术记录</span>
    <p align='2' />
    <p align='2' />
    <span fontname='Microsoft Sans Serif' fontsize='13'>姓名：</span>
    <select name='姓名' listsource='y0001000020900000002' id='kby0001000020900000002' text='胡月' value='#xm#' />
    <span fontname='Microsoft Sans Serif' fontsize='13'>     性别：</span>
    <select name='性别' listsource='y0001000020900000004' id='kby0001000020900000004' text='女' value='#xb#' />
    <span fontname='Microsoft Sans Serif' fontsize='13'>   年龄：</span>
    <select name='年龄' listsource='y0001000020900000003' id='kby0001000020900000003' text='19岁' value='#nl#' />
    <span fontname='Microsoft Sans Serif' fontsize='13'>    科室：</span>
    <select name='住院科室' listsource='y0001000020900000060' id='kby0001000020900000060' text='' value='#zyks#' />
    <span fontname='Microsoft Sans Serif' fontsize='13'>     病案号：</span>
    <p />
    <span fontname='Microsoft Sans Serif'>手术日期：     2012             年      01月       07日</span>
    <p />
    <span fontname='Microsoft Sans Serif'>术前诊断：1孕1产0孕40周待产LOA   2社会因素</span>
    <p />
    <span fontname='Microsoft Sans Serif'>术后诊断：孕1产1孕40周已产LOA   2成熟男婴    </span>
    <p />
    <span fontname='Microsoft Sans Serif'>手术名称：子宫下段剖宫产术</span>
    <p />
    <span fontname='Microsoft Sans Serif'>手术者：   周云美                             助手：朱卫国</span>
    <p />
    <span fontname='Microsoft Sans Serif'>麻醉方法：      连硬麻                      麻醉者：陈海云</span>
    <p />
    <span fontname='Microsoft Sans Serif'>手术经过（术中出现的情况及处理）：麻醉成功后，取平卧位，常规消毒铺巾，取下腹正中纵切口约10CM,逐层进腹，探查子宫如孕足月大小，子宫下段形成好。遂行子宫下段剖宫产术。围纱排开肠管，弧形剪开膀胱、子宫返折腹膜，下推膀胱。切开子宫肌层，钝性向两侧分离约2cm，破膜，见羊水流出，羊水清，尽量洗净羊水，将子宫肌层切口再次钝性向两侧分离至8cm，术者右手伸入宫腔，上托抬头，助手按压宫体协助胎肩胎体娩出，将其解开后，清理呼吸道、断脐后交台下处理，鼠齿钳钳夹子宫切口四周，宫体注射缩宫素20u，待胎盘剥离后，牵引脐带协助胎盘、胎膜娩出，检查胎盘、胎膜完整，脐带位于胎盘中央，小纱布擦净宫腔残留物后，0号可吸收线连续缝合子宫肌层，间断加强，连续缝合膀胱子宫反折腹膜，探查子宫切口无渗血，双侧附件无异常，清点纱布、器械无误后逐层关腹，内锋皮肤层。</span>
    <p />
    <span fontname='Microsoft Sans Serif'>          新生儿Apgar评分为10分，为一成熟男婴。</span>
    <p />
    <span fontname='Microsoft Sans Serif'>           术中麻醉满意，血压平稳，出血约200ml，术中补液800cm,尿量300cm,母子安反病房继术中补液，给抗感染治疗，请注意阴道出血。</span>
    <p />
    <span fontname='Microsoft Sans Serif'>														周云美</span>
    <p />
  </body>
</emrtextdoc>";
            this.myWriterControl.ExecuteCommand("InsertOldXml", false, xml);
        }

        private void btnReplaceField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = ( XTextInputFieldElement ) myWriterControl.Document.GetCurrentElement(typeof(XTextInputFieldElement));
            if (field != null)
            {
                myWriterControl.ExecuteCommand("DeleteField", false, null);
                myWriterControl.ExecuteCommand("InsertXML", false, this._xmlData);
            }
            else
            {
                MessageBox.Show("请将光标放在一个输入域当中");
            }
        }

        private void btnInsertXMLWithClearFormat_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("InsertXMLWithClearFormat", false, this._xmlData);
        }

        private void btnInsertString2_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("InsertString", false, "张三\r\n李四");
        }

        private void btnInsertXMLWithClearFontNameSize_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("InsertXMLWithClearFontNameSize", false, this._xmlData);
        }

        private void cboDataObjectRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            myWriterControl.DataObjectRange = (Writer.Controls.WriterDataObjectRange)cboDataObjectRange.SelectedIndex;
        }


    }
}
