using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YidanSoft.Library.EmrEditor.Src.Document.PropertyElement
{
    public class PropertyReplace : PropertyBase
    {
        ZYReplace e;
        public PropertyReplace(object o)
            : base(o)
        {
            e = (ZYReplace)o;
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
                //基本信息和复用项目 绑定数据元代码时，名字不能变，原来代码中根据名称有逻辑，只能加代码
                //e.Name = DataElement.STD_DataElementBiz.GetSTD_DataElementEntityById(e.Code).DATAELEMENT_NAME;
            }
        }
    }
}
