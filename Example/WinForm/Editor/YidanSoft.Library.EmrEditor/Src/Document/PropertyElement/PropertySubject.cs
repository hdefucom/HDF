﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document.PropertyElement
{
    public class PropertySubject : PropertyBase
    {
        ZYSubject _e;

        public PropertySubject(object o)
            : base(o)
        {
            _e = (ZYSubject)o;
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