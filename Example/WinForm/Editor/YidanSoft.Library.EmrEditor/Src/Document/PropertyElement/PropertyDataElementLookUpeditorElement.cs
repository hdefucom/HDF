using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class PropertyDataElementLookUpeditorElement : PropertyBase
    {
        ZYDataElementLookupEditor e;
        public PropertyDataElementLookUpeditorElement(object o)
            : base(o)
        {

            e = (ZYDataElementLookupEditor)o;
        }

        [Category("数据元代码"), DisplayName("数据元代码")]
        [EditorAttribute(typeof(DataElementMultiEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Code
        {
            get { return e.Code; }
            set
            {
                e.Code = value;
                e.Name = DataElement.STD_DataElementBiz.GetSTD_DataElementEntityById(e.Code).DATAELEMENT_NAME;
                //2019.06.27-hdf
                //用ZYDataElementLookupEditor的Wordbook属性存储数据元代码ValueRange
                e.Wordbook = DataElement.STD_DataElementBiz.GetSTD_DataElementEntityById(e.Code).VALUE_RANGE;
            }
        }

        [Category("属性设置"), DisplayName("名称")]
        public string Name
        {
            get { return e.Name; }
            set { e.Name = value; }
        }

        [Category("属性设置"), DisplayName("是否多选")]
        public bool Multi
        {
            get { return e.Multi; }
            set { e.Multi = value; }

        }



        //[Category("属性设置"), DisplayName("字典名称")]
        //[EditorAttribute(typeof(DropDownWordBookEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //public string WordBook
        //{
        //    get { return e.Wordbook; }
        //    set { e.Wordbook = value; }
        //}

        [Category("属性设置"), DisplayName("是否允许删除"), Description("设置改元素是否允许删除")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool CanDelete
        {
            get { return e.CanDelete; }
            set { e.CanDelete = value; }
        }
    }
}
