using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class ZYDataElementLookupEditor : ZYTextBlock
    {

        public ZYDataElementLookupEditor()
        {
            this.Type = ElementType.DataElementLookUpEditor;
        }


        /// <summary>
        /// 值
        /// </summary>
        public string CodeValue
        {
            get { return _codeValue; }
            set { _codeValue = value; }
        }
        private string _codeValue;

        /// <summary>
        /// 是否是多选
        /// </summary>
        public bool Multi
        {
            get { return _multi; }
            set { _multi = value; }
        }
        private bool _multi;

        /// <summary>
        /// 2019.06.27-hdf
        /// 用来存储数据元代码ValueRange
        /// </summary>
        public string Wordbook
        {
            get { return _wordbook; }
            set { _wordbook = value; }
        }
        private string _wordbook;


        public override string GetXMLName()
        {
            return ZYTextConst.c_DataElementLookupEditor;
        }

        public override bool ToXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Attributes.ToXML(myElement);
                myElement.SetAttribute("type", StringCommon.GetNameByType(this.Type));

                myElement.SetAttribute("name", this.Name);
                myElement.SetAttribute("codevalue", this.CodeValue);
                myElement.SetAttribute("wordbook", this.Wordbook);//2019.07.19-hdf：文书录入数据元无法选择，应为没有保存值范围属性
                myElement.SetAttribute("multi", this.Multi.ToString());
                myElement.SetAttribute("code", this.Code);
                myElement.InnerText = this.Text;
                myElement.SetAttribute("candelete", this.CanDelete.ToString());//2019.07.11-hdf：元素有是否能删除属性但是导出xml时没保存
                //return base.ToXML(myElement);
            }
            return false;
        }

        public override bool FromXML(System.Xml.XmlElement myElement)
        {
            if (myElement != null)
            {
                this.Type = StringCommon.GetTypeByName(myElement.GetAttribute("type"));
                this.Attributes.FromXML(myElement);
                this.Name = myElement.GetAttribute("name");
                this.CodeValue = myElement.GetAttribute("codevalue");
                this.Text = myElement.InnerText;
                this.Wordbook = myElement.GetAttribute("wordbook");//2019.07.19-hdf：文书录入数据元无法选择，应为没有保存值范围属性
                this.Multi = bool.Parse(myElement.GetAttribute("multi"));
                this.Code = myElement.HasAttribute("code") == true ? myElement.GetAttribute("code") : "";
                //2019.07.11-hdf：元素有是否能删除属性但是导出xml时没保存
                if (myElement.HasAttribute("candelete"))
                {
                    this.CanDelete = bool.Parse(myElement.GetAttribute("candelete"));
                }
                return true;
            }
            return false;
        }

    }
}
