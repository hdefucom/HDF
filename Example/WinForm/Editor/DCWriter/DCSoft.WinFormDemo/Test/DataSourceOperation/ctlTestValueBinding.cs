using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.DataSourceOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestValueBinding : UserControl
    {
        public ctlTestValueBinding()
        {
            InitializeComponent();
        }


        private void frmTestValueBinding_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.DocumentContentChanged += new WriterEventHandler(myWriterControl_DocumentContentChanged);
            myWriterControl.QueryListItems += new Writer.Controls.QueryListItemsEventHandler(myWriterControl_QueryListItems);
        }

        void myWriterControl_QueryListItems(object eventSender, QueryListItemsEventArgs args)
        {
            if (args.ListSourceName == "ICD")
            {
                args.AddResultItemByTextValue("肺炎型鼠疫", "A20.251");
                args.AddResultItemByTextValue("继发性肺炎型鼠疫", "A20.252");
                args.AddResultItemByTextValue("原发性肺炎型鼠疫", "A20.253");
                args.AddResultItemByTextValue("鼠疫型脑膜炎", "A20.351");
                args.AddResultItemByTextValue("败血症性鼠疫", "A20.751");
                args.AddResultItemByTextValue("顿挫性鼠疫", "A20.851");
                args.AddResultItemByTextValue("无症状性鼠疫", "A20.852");
                args.AddResultItemByTextValue("轻鼠疫", "A20.853");
                args.AddResultItemByTextValue("鼠疫 NOS", "A20.901");
                args.AddResultItemByTextValue("溃疡淋巴腺型土拉菌病", "A21.051");
                args.AddResultItemByTextValue("眼土拉菌病", "A21.151");
                args.AddResultItemByTextValue("眼腺型土拉菌病", "A21.152");
                args.AddResultItemByTextValue("肺土拉菌病", "A21.251");
                args.AddResultItemByTextValue("腹部土拉菌病", "A21.351");
                args.AddResultItemByTextValue("胃肠土拉菌病", "A21.352");
                args.AddResultItemByTextValue("全身性土拉菌病", "A21.751");
                args.AddResultItemByTextValue("其他形式的土拉菌病", "A21.851");
                args.AddResultItemByTextValue("兔热病", "A21.901");
                args.AddResultItemByTextValue("土拉菌热", "A21.951");
                args.AddResultItemByTextValue("皮肤炭疽", "A22.051");
                args.AddResultItemByTextValue("恶性脓疱", "A22.052");
                args.AddResultItemByTextValue("恶性痈", "A22.053");
                args.AddResultItemByTextValue("肺炭疽", "A22.101");
                args.AddResultItemByTextValue("炭疽肺炎", "A22.102+");
                args.AddResultItemByTextValue("恶性炭疽(栋毛工病))", "A22.151");
                args.AddResultItemByTextValue("捡破烂人病", "A22.152");
                args.AddResultItemByTextValue("吸入性炭疽", "A22.153");
                args.AddResultItemByTextValue("胃肠炭疽", "A22.251");
                args.AddResultItemByTextValue("肠炭疽", "A22.252");
                args.AddResultItemByTextValue("炭疽性败血症", "A22.751");
                args.AddResultItemByTextValue("炭疽脑膜炎", "A22.851+");
                args.AddResultItemByTextValue("炭疽 NOS", "A22.901");
                args.AddResultItemByTextValue("直布罗陀热(西班牙)", "A23.051");
                args.AddResultItemByTextValue("地中海热", "A23.052");
            }
        }

        void myWriterControl_DocumentContentChanged(object eventSender, WriterEventArgs args)
        {
            
        }

        #region 测试单一绑定数据源 

        private void btnInsertNameSingle_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.Name = "姓名";
            field.BackgroundText = "请输入姓名";
            field.ValueBinding = new XDataBinding();
            field.ValueBinding.DataSource = "姓名";
            field.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnInsertAgeSingle_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.Name = "年龄";
            field.BackgroundText = "请输入年龄";
            field.ValueBinding = new XDataBinding();
            field.ValueBinding.DataSource = "年龄";
            field.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }


        private void bttInsertInputFieldWithDataSourceDescriptor_Click(object sender, EventArgs e)
        {
            DCSoft.Writer.Extension.Data.DataSourceDescriptor desc =
                new DCSoft.Writer.Extension.Data.DataSourceDescriptor();
            desc.Name = "age";
            desc.BackgroundText = "请输入年龄";
            desc.ValueBinding = new XDataBinding();
            desc.ValueBinding.DataSource = "年龄";
            desc.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand(
                "InsertInputFieldWithDataSourceDescriptor",
                false,
                desc);
        }

        private void btnBindingSingle_Click(object sender, EventArgs e)
        {
            myWriterControl.SetDocumentParameterValue("姓名", "张三");
            myWriterControl.SetDocumentParameterValue("年龄", "20");
            myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();// .ExecuteCommand("UpdateViewForDataSource", false, null);
        }


        private void btnUpdateNameOnly_Click(object sender, EventArgs e)
        {
            myWriterControl.SetDocumentParameterValue("姓名", "李四");
            myWriterControl.WriteDataFromDataSourceToDocumentSpecifyParameterNames("姓名");
        }

        private void btnGetSingleValue_Click(object sender, EventArgs e)
        {
            myWriterControl.UpdateDataSourceForView();// .ExecuteCommand("UpdateDataSourceForView", false, null);
            string name = Convert.ToString( myWriterControl.GetDocumnetParameterValue("姓名") );
            string age = Convert.ToString( myWriterControl.GetDocumnetParameterValue("年龄"));
            MessageBox.Show("从文档中获得的数据为 Name:" + name + "   Age:" + age);
        }

        #endregion

        #region 测试批量绑定数据源

        private void btnInsertName2_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.Name = "Name";
            field.BackgroundText = "请输入姓名";
            field.ValueBinding = new XDataBinding();
            field.ValueBinding.DataSource = "Patient";
            // 实体对象属性名或简单的XML文档中的XPath
            field.ValueBinding.BindingPath = "Name"; 
            field.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }


        private void btnInsertAge2_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.Name = "Age";
            field.BackgroundText = "请输入年龄";
            field.ValueBinding = new XDataBinding();
            field.ValueBinding.DataSource = "Patient";
            // 实体对象属性名或简单的XML文档中的XPath
            field.ValueBinding.BindingPath = "Age";
            field.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnInsertStree_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.Name = "Address.Street";
            field.BackgroundText = "请输入街道";
            field.ValueBinding = new XDataBinding();
            field.ValueBinding.DataSource = "Patient";
            // 实体对象属性名或简单的XML文档中的XPath
            field.ValueBinding.BindingPath = "Address.Street";
            // 当数据源数据为空时，设置默认显示的内容。
            field.DefaultValueForValueBinding = "--";
            field.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }


        private void btnSexRadioBox_Click(object sender, EventArgs e)
        {
            XTextRadioBoxElement rdo = new XTextRadioBoxElement();
            rdo.CheckedValue = "1";
            rdo.Caption = "男";
            rdo.ValueBinding = new XDataBinding();
            rdo.ValueBinding.DataSource = "Patient";
            rdo.ValueBinding.BindingPath = "Sex";
            rdo.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertRadioBox, false, rdo);
            rdo = new XTextRadioBoxElement();
            rdo.CheckedValue = "0";
            rdo.Caption = "女";
            rdo.ValueBinding = new XDataBinding();
            rdo.ValueBinding.DataSource = "Patient";
            rdo.ValueBinding.BindingPath = "Sex";
            rdo.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertRadioBox, false, rdo);
        }


        private void btnInserCheckBox_Click(object sender, EventArgs e)
        {
            XTextElementList elements = new XTextElementList();
            XTextCheckBoxElement chk = new XTextCheckBoxElement();
            chk.Caption = "花粉";
            chk.CheckedValue = "花粉";
            chk.ValueBinding = new XDataBinding();
            chk.ValueBinding.DataSource = "Patient";
            chk.ValueBinding.BindingPath = "过敏";
            chk.ValueBinding.Readonly = false;
            elements.Add(chk);
            chk = new XTextCheckBoxElement();
            chk.Caption = "青霉素";
            chk.CheckedValue = "青霉素";
            chk.ValueBinding = new XDataBinding();
            chk.ValueBinding.DataSource = "Patient";
            chk.ValueBinding.BindingPath = "过敏";
            chk.ValueBinding.Readonly = false;
            elements.Add(chk);
            chk = new XTextCheckBoxElement();
            chk.Caption = "链霉素";
            chk.CheckedValue = "链霉素";
            chk.ValueBinding = new XDataBinding();
            chk.ValueBinding.DataSource = "Patient";
            chk.ValueBinding.BindingPath = "过敏";
            chk.ValueBinding.Readonly = false;
            elements.Add(chk);
            chk = new XTextCheckBoxElement();
            chk.Caption = "油漆";
            chk.CheckedValue = "油漆";
            chk.ValueBinding = new XDataBinding();
            chk.ValueBinding.DataSource = "Patient";
            chk.ValueBinding.BindingPath = "过敏";
            chk.ValueBinding.Readonly = false;
            elements.Add(chk);
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertElements, false, elements);
        }


        private void btnInsertYiBao_Click(object sender, EventArgs e)
        {
            XTextCheckBoxElement chk = new XTextCheckBoxElement();
            chk.Caption = "是否为医保病人";
            chk.ValueBinding = new XDataBinding();
            chk.ValueBinding.DataSource = "Patient";
            chk.ValueBinding.BindingPath = "医保";
            chk.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertCheckBox, false, chk);
        }


        private void btnInsertICD_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.LabelText = "诊断:";
            field.BackgroundText = "双击选择诊断";
            field.ValueBinding = new XDataBinding();
            field.ValueBinding.DataSource = "Patient";
            field.ValueBinding.BindingPath = "ICD_Code";
            field.ValueBinding.BindingPathForText = "ICD_Name";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.UserEditable = false;
            field.FieldSettings.DynamicListItems = true;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.SourceName = "ICD";
            myWriterControl.ExecuteCommand(StandardCommandNames.InsertInputField, false, field);
        }

        private void btnBindingEntry_Click(object sender, EventArgs e)
        {
            PatientEntry p = new PatientEntry();
            p.Name = "王五";
            p.Age = "34";
            p.Address.Street = null;
            //p.Address.Street = "前门大街";
            p.Sex = "0";
            p.过敏 = "花粉,油漆";
            p.医保 = true ;
            p.ICD_Name = "胃肠土拉菌病";
            p.ICD_Code = "A21.352";

            myWriterControl.SetDocumentParameterValue("Patient", p);
            myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();// .ExecuteCommand("UpdateViewForDataSource", false, null);
        }


        private void btnBindTable_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            DataRow row = table.NewRow();
            row[0] = "赵六";
            row[1] = "99";
            table.Rows.Add(row);
            myWriterControl.SetDocumentParameterValue("Patient", table);
            myWriterControl.WriteDataFromDataSourceToDocument ();// .UpdateViewForDataSource();// .ExecuteCommand("UpdateViewForDataSource", false, null);
        }


        private void btnGetEntryValue_Click(object sender, EventArgs e)
        {
            myWriterControl.WriteDataFromDocumentToDataSource();// .UpdateDataSourceForView();// .ExecuteCommand("UpdateDataSourceForView", false, null);
            PatientEntry p = myWriterControl.GetDocumnetParameterValue("Patient") as PatientEntry;
            if (p != null)
            {
                MessageBox.Show("从文档中获得的数据为\r\n Name:" + p.Name 
                    + "\r\n  Age:" + p.Age
                    + "\r\n  Street:" + p.Address.Street
                    + "\r\n  Sex:" + p.Sex
                    + "\r\n  过敏:" + p.过敏
                    + "\r\n  是否医保病人:"+ p.医保 
                    + "\r\n  诊断名称:" + p.ICD_Name 
                    + "\r\n  诊断编号:" + p.ICD_Code );
            }
        }

        private void btnInsertXMLPostCodeField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.Name = "Address.PostCode";
            field.BackgroundText = "请输入邮编";
            field.ValueBinding = new XDataBinding();
            field.ValueBinding.DataSource = "Patient";
            // 实体对象属性名或简单的XML文档中的XPath
            field.ValueBinding.BindingPath = "Address/PostCode";
            field.ValueBinding.Readonly = false;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnXMLBinding_Click(object sender, EventArgs e)
        {
            string xml = "<a><Name>赵六</Name><Age>43</Age><Address><PostCode>210000</PostCode></Address></a>";
            myWriterControl.SetDocumentParameterValueXml("Patient", xml);
            myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();// .ExecuteCommand("UpdateViewForDataSource", false, null);
        }

        private void btnGetXML_Click(object sender, EventArgs e)
        {
            myWriterControl.WriteDataFromDocumentToDataSource();//.UpdateDataSourceForView();// .ExecuteCommand("UpdateDataSourceForView", false, null);
            string xml = myWriterControl.GetDocumentParameterValueXml("Patient") as string;
            if (xml != null)
            {
                MessageBox.Show("获得的XML为:" + xml);
            }
        }

        /// <summary>
        /// 病人基本信息实体类
        /// </summary>
        public class PatientEntry
        {
            private string _Name = null;
            /// <summary>
            /// 姓名
            /// </summary>
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            private string _Age = null;
            /// <summary>
            /// 年龄
            /// </summary>
            public string Age
            {
                get { return _Age; }
                set { _Age = value; }
            }

            private PatientAddress _Address = new PatientAddress();
            /// <summary>
            /// 地址信息
            /// </summary>
            public PatientAddress Address
            {
                get { return _Address; }
                set { _Address = value; }
            }

            private string _Sex = null;
            /// <summary>
            /// 性别
            /// </summary>
            public string Sex
            {
                get { return _Sex; }
                set { _Sex = value; }
            }

            private string _ICD_Name = null;

            public string ICD_Name
            {
                get { return _ICD_Name; }
                set { _ICD_Name = value; }
            }

            private string _ICD_Code = null;

            public string ICD_Code
            {
                get { return _ICD_Code; }
                set { _ICD_Code = value; }
            }

            private string _过敏 = null;

            public string 过敏
            {
                get { return _过敏; }
                set { _过敏 = value; }
            }

            private bool _医保 = true;

            public bool 医保
            {
                get { return _医保; }
                set { _医保 = value; }
            }
        }
        /// <summary>
        /// 病人住址信息实体类
        /// </summary>
        public class PatientAddress
        {
            private string _Street = null;
            /// <summary>
            /// 街道
            /// </summary>
            public string Street
            {
                get { return _Street; }
                set { _Street = value; }
            }

            private string _PostCode = null;
            /// <summary>
            /// 邮政编码
            /// </summary>
            public string PostCode
            {
                get { return _PostCode; }
                set { _PostCode = value; }
            }
        }

        #endregion

        private void btnFormValuesString_Click(object sender, EventArgs e)
        {
            txtFormValuesString.Text = myWriterControl.FormValuesString;
        }

        private void btnSetFormValuesString_Click(object sender, EventArgs e)
        {
            //myWriterControl.FormValuesString = txtFormValuesString.Text;
        }

        private void btnGetDescriptionsXML_Click(object sender, EventArgs e)
        {
            string xml = myWriterControl.GetDataSourceBindingDescriptionsXML();
            MessageBox.Show(xml);
        }

        private void btnGetBindingDataSources_Click(object sender, EventArgs e)
        {
            string list = myWriterControl.GetBindingDataSources();
            if (list != null)
            {
                MessageBox.Show(list);
            }
        }

        private void btnDetectValueBindingModified_Click(object sender, EventArgs e)
        {
            string msg = this.myWriterControl.GetDetectValueBindingModifiedMessage();
            if (msg == null)
            {
                MessageBox.Show(this, "没有任何改变。");
            }
            else
            {
                MessageBox.Show(this, "发现有数据发生改变\r\n" + msg );
            }
            // 使用以下代码可以获取更详细的信息
            //DetectResultForValueBindingModifiedList list = this.myWriterControl.DetectValueBindingModified();
            //if (list != null)
            //{
            //    MessageBox.Show(this, "发现有数据发生改变\r\n" + list.ToString());
            //}
            //else
            //{
            //    MessageBox.Show(this, "没有任何改变");
            //}
        }


    }
}
