using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    /// <summary>
    /// 单选的属性设置
    /// </summary>
    public class PropertySelectableElement : PropertyBase
    {
        ZYSelectableElement _e;
        public PropertySelectableElement(object e)
            : base(e)
        {
            _e = (ZYSelectableElement)e;
        }
        [Category("数据元代码"), DisplayName("数据元代码")]
        [EditorAttribute(typeof(DataElementMultiEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Code
        {
            get { return _e.Code; }
            set
            {
                _e.Code = value;
                _e.Name = DataElement.STD_DataElementBiz.GetSTD_DataElementEntityById(_e.Code).DATAELEMENT_NAME;
            }
        }
        [Category("属性设置"), DisplayName("名称")]
        public string Name
        {
            get { return _e.Name; }
            set { _e.Name = value; }
        }


        [Category("属性设置"), DisplayName("必点项"), Description("必须用鼠标双击，以表示关注过此项。")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool MustClick
        {
            get { return _e.MustClick; }
            set { _e.MustClick = value; }
        }

        //[Category("属性设置"), DisplayName("选项")]
        //[TypeConverter(typeof(BlankConverter)), Description("选项中子模板名用:[子模板名] 表示；提示用:{提示名} 表示；多选分组用:<组号> 表示")]
        //public string[] Items
        //{
        //    get { return _e.Items; }
        //    set { _e.Items = value; }
        //}

        [Category("属性设置"), DisplayName("选项")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(SelectableEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public List<ZYSelectableElementItem> Items
        {
            get { return _e.SelectList; }
            set { _e.SelectList = value; }
        }

        [Category("属性设置"), DisplayName("是否允许删除"), Description("设置改元素是否允许删除")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(BoolEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public bool CanDelete
        {
            get { return _e.CanDelete; }
            set { _e.CanDelete = value; }
        }


    }

}
