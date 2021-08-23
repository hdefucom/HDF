using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document.PropertyElement
{
    public class PropertyDiag : PropertyBase
    {
        ZYDiag e;
        public PropertyDiag(object o)
            : base(o)
        {
            e = (ZYDiag)o;
        }

        [Category("数据元代码"), DisplayName("数据元代码")]
        [EditorAttribute(typeof(DataElementMultiEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Code
        {
            get { return e.Code; }
            set
            {
                e.Code = value;
                //2019.07.02-hdf
                //注释原因：基本信息和复用项目 绑定数据元代码时，名字不能变，原来代码中根据名称有逻辑，只能加代码
                //e.Name = DataElement.STD_DataElementBiz.GetSTD_DataElementEntityById(e.Code).DATAELEMENT_NAME;
            }
        }


        [Category("属性设置"), DisplayName("名称")]
        public string Name
        {
            get { return e.Name; }
            set { e.Name = value; }
        }

        [Category("属性设置"), DisplayName("诊断类型")]
        [TypeConverter(typeof(BlankConverter))]
        [EditorAttribute(typeof(DropDownDiagTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DiagType DiagType
        {
            get { return e.DiagType; }
            set { e.DiagType = value; }
        }

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
