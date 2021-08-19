using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Commands;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestOther : UserControl
    {
        public ctlTestOther()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnSetFontName_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FontName", false, "黑体");
        }

        private void btnSetFontSize_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FontSize", false, 30);
        }

        private void btnGetXMLText_Click(object sender, EventArgs e)
        {
            string xml = myWriterControl.XMLText;
            MessageBox.Show(xml.Length.ToString());
            xml = myWriterControl.Document.SaveToString("xml");
            MessageBox.Show(xml );
        }

        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            XTextTableElement table = ( XTextTableElement ) myWriterControl.Document.GetCurrentElement(typeof(XTextTableElement));
            if (table != null)
            {
                table.Rows.LastElement.Focus();
                myWriterControl.ExecuteCommand("Table_InsertRowDown", false, null);
            }
        }

        private void btnGetField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)myWriterControl.GetCurrentElementByTypeName("XTextInputFieldElement");
            MessageBox.Show(Convert.ToString(field != null));
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)myWriterControl.GetCurrentElement(typeof(XTextInputFieldElement));
            if (field != null)
            {
                field.MoveFocusHotKey = (MoveFocusHotKeys)4;
            }
        }

        private void btnTest3_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement ps = new XTextInputFieldElement();// WriterControlCommon.ConvertToXTextInputFieldElementPropertiesByElementItemInputFieldModel(elementItemInputFieldModel);
            ps.ID = "aaa";// xTextInputFieldElementProperties.ID + "_" + GetXTextCheckBoxElementMaxIdByGroupId(xTextInputFieldElementProperties.ID);
            ps.Name = ps.ID;
            //20170109 宋建明BUG修改 start
            ps.FieldSettings = new InputFieldSettings();
            ps.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            ps.FieldSettings.ListSource = new ListSourceInfo();
            ps.FieldSettings.ListSource.Items = new ListItemCollection();
            //20170109 宋建明BUG修改 end
            ps.FieldSettings.ListSource.Items.AddByTextValue( null , "aaa");
            ps.FieldSettings.ListSource.Items.AddByTextValue(null, "bbb");
            ps.FieldSettings.ListSource.Items.AddByTextValue(null, "ccc");
            ps.FieldSettings.ListSource.Items.AddByTextValue(null, "ddd");

            //if (ps.FieldSettings.ListSource != null && ps.FieldSettings.ListSource.Items.Count > 0)
            //    ps.FieldSettings.ListSource.Items.RemoveAt(0);
            //if (elementItemInputFieldModel.ElementItemStyle.IsShowName == false)
            //{
            //    if (ps.FieldSettings.ListSource != null && ps.FieldSettings.ListSource.Items.Count > 0)
            //        foreach (ListItem listItem in ps.FieldSettings.ListSource.Items)
            //        {
            //            listItem.Text = string.Empty;
            //        }
            //}
            XTextElementList xTextElementList = myWriterControl.ExecuteCommand(
                StandardCommandNames.InsertCheckBoxList, false, ps) as XTextElementList;

        }

        private void btnTest4_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)myWriterControl.GetCurrentElement(typeof(XTextInputFieldElement));
            if (field != null)
            {
                XTextDocument doc = field.CreateContentDocument(false);
                string xml = doc.XMLText;
                string txt = doc.Text;
                MessageBox.Show(txt + "\r\n" + xml);
            }
        }

        private void btnInsertString_Click(object sender, EventArgs e)
        {
            string text = @" 患者上午在介入室行“肝动脉插管化疗栓塞术”，术毕平车返回病房。神志清楚，右腹股沟穿刺处敷料干燥无渗血渗液，砂袋压迫，右下肢肢端温暖、末梢血运良好，足背搏动正常，予以右下肢制动24小时，指导禁食6小时，给予利尿、止吐、保肝、补液处理。



患者上午在全麻下行“左、右肝癌切除术”平车返回病房，神志清楚，切口敷料干燥无渗血渗液，腹带包扎。持续胃肠减压通常，呈草绿色，管外露65cm，持续左、右膈下引流管通畅，呈血性，持续导尿管通畅，尿色清，持续心电监护示窦性心律、律齐，持续低流量吸氧3l/min，给予抗炎、保肝、补液处理。




患者在B超引导下行'PTCD引流术'返回病房，神志清楚，腹部穿刺处敷料干燥。无渗血渗液。持续PTCD引流管通畅。呈黄褐色，指导其卧床休息，避免剧烈运动，以免脱管，给予止血补液处理。




患者今日在局麻下行临时起搏器安置术，术毕现返回病房，协助取平卧位休息，左右颈内静脉，左右锁骨下静脉穿刺处敷料干净，无渗血渗液，起搏器工作正常，起搏心律为60次/分，输出电压为3V，感知度为2MV。
";
            DCSoft.Writer.Commands.InsertStringCommandParameter p
                = new DCSoft.Writer.Commands.InsertStringCommandParameter();
            p.Text = text;
            p.Style = new DocumentContentStyle();
            p.Style.Color = Color.Red;
            p.Style.Bold = true;
            p.Style.FontSize = 40;

            p.ParagraphStyle = new DocumentContentStyle();
            p.ParagraphStyle.LineSpacingStyle = Drawing.LineSpacingStyle.SpaceMultiple;
            p.ParagraphStyle.LineSpacing = 3;
            p.ParagraphStyle.LeftIndent = 100;
            this.myWriterControl.ExecuteCommand("InsertString", false, p);
        }

        private void btnInsertString2_Click(object sender, EventArgs e)
        {
            using (dlgRTF dlg = new dlgRTF())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.myWriterControl.ExecuteCommand("InsertString", false, dlg.InputText);
                }
            }
        }

        private void btnWaittingMode_Click(object sender, EventArgs e)
        {
            //myWriterControl.WaittingMode = btnWaittingMode.Checked;
        }

        private void btnCreateDocumentFromClipboard_Click(object sender, EventArgs e)
        {
            XTextDocument document = this.myWriterControl.CreateDocumentFromClipboard();
            if (document != null)
            {
                myWriterControl.ExecuteCommand(StandardCommandNames.ViewXMLSourceWithNotePad, true, document);
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            XTextLabelElement lbl = myWriterControl.GetElementById("aaa") as XTextLabelElement;
            if (lbl != null)
            {
                lbl.Text = "张三";
            }
        }

        private void btnAddUserHistory_Click(object sender, EventArgs e)
        {
            DCSoft.Writer.Security.UserHistoryInfo his = new Security.UserHistoryInfo();
            his.Name = "aaaa";
            his.PermissionLevel = 4;
            this.myWriterControl.Document.UserHistories.Add(his);
        }

        private void btnCreateOwnerDocument_Click(object sender, EventArgs e)
        {
            XTextDocument document = null;
            if (myWriterControl.Document.CurrentField != null)
            {
                document = myWriterControl.Document.CurrentField.CreateContentDocument(true  );
            }
            else
            {
                document = this.myWriterControl.Document.Body.CreateContentDocument(true);
            }
            string xml = Convert.ToString( myWriterControl.ExecuteCommand(StandardCommandNames.ViewXMLSource, true, document));
            myWriterControl.LoadDocumentFromString(xml, null);
        }

        private void btnChangeBackgroundText_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = (XTextInputFieldElement)this.myWriterControl.GetCurrentElement(typeof(XTextInputFieldElement));
            if (field != null)
            {
                ElementEventTemplate eet = new ElementEventTemplate();
                eet.ContentChanged += new ContentChangedEventHandler(eet_ContentChanged);
                myWriterControl.GlobalEventTemplate_Field = eet;
                field.BackgroundText = "发的敬爱放大";
                field.EditorRefreshView();
            }
        }

        void eet_ContentChanged(object eventSender, ContentChangedEventArgs args)
        {
            MessageBox.Show(args.Element.ToString());
        }

        private void btnInsertImageHeader_Click(object sender, EventArgs e)
        {
            XTextImageElement img = new XTextImageElement();
            img.SetPageImage(0, imageList1.Images[0]);
            img.SetPageImage(1, imageList1.Images[1]);
            img.SetPageImage(2, imageList1.Images[2]);
            img.SetPageImage(3, imageList1.Images[3]);
            img.Width = 50;
            img.Height = 50;
            this.myWriterControl.Document.Header.ContentBuilder.Append(img);
            this.myWriterControl.RefreshDocument();
        }

        private void btnTestValueExpression_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.ID = "field1";
            field.BackgroundText = "value1";
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertInputField, false, field);

            field = new XTextInputFieldElement();
            field.ID = "field2";
            field.BackgroundText = "value2";
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertInputField, false, field);

            XTextSectionElement sec = new XTextSectionElement();
            sec.ValueExpression = "[field1]/[field2]";
            myWriterControl.ExecuteCommand( StandardCommandNames.InsertSection , false  ,sec );

            myWriterControl.MoveTo(MoveTarget.DocumentEnd);
            XTextLabelElement lbl = new XTextLabelElement();
            lbl.ValueExpression = "[field1]*[field2]";
            lbl.Width = 300;
            lbl.AutoSize = false;
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertLabel, false, lbl);
        }

        private void btnInsertField2_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.EditorTextExt = "aaaaaaaa";
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertInputField, false, field);
        }

        private void btnInsertListField3_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "XXXXXXX";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.Items = new ListItemCollection();
            ListItem item = new ListItem();
            item.TextInList = "项目1";
            item.Text = "项目1项目1项目1项目1项目1项目1";
            field.FieldSettings.ListSource.Items.Add(item);

            item = new ListItem();
            item.TextInList = "项目2";
            item.Text = "项目2项目2项目2项目2项目2项目2";
            field.FieldSettings.ListSource.Items.Add(item);

            item = new ListItem();
            item.TextInList = "项目3";
            item.Text = "项目3333333项目2项目2项目2项目2项目2";
            field.FieldSettings.ListSource.Items.Add(item);

            item = new ListItem();
            item.TextInList = "项目4";
            item.Text = "项目444444444项目2项目2项目2项目2项目2";
            field.FieldSettings.ListSource.Items.Add(item);

            item = new ListItem();
            item.TextInList = "项目5";
            item.Text = "项目555555555项目2项目2项目2项目2项目2";
            field.FieldSettings.ListSource.Items.Add(item);

            myWriterControl.ExecuteCommand(StandardCommandNames.InsertInputField, false, field);
        }
    }
}