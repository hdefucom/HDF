using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.Control
{
    public class Control_1 : Button
    {
        public Control_1()
        {



        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public aaaa MyProperty { get; set; } = new aaaa();
    }


    [TypeConverter(typeof(TypeConverterSupportProperties))]
    [Serializable]
    public class aaaa
    {

        [DefaultValue(1)]
        public int MyPropertyInt { get; set; } = 1;
        [DefaultValue("aaaa")]
        public string MyPropertyString { get; set; } = "aaa";

    }


    public class UIAAAAPropertyEditor : UITypeEditor
    {

        /// <summary>
        /// GetEditStyle
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>UITypeEditorEditStyle</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            //指定为模式窗体属性编辑器类型
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// EditValue
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="provider">provider</param>
        /// <param name="value">value</param>
        /// <returns>object</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //打开属性编辑器修改数据
            //Form4 frm = new Form4();
            //frm.ShowDialog();
            //frm.Dispose();

            return value;
        }

    }




    public class TypeConverterSupportProperties : TypeConverter
    {
        /// <summary>
        ///       支持获得属性
        ///       </summary>
        /// <param name="context">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        ///       获得属性
        ///       </summary>
        /// <param name="context">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <param name="attributes">
        /// </param>
        /// <returns>
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value, attributes);
        }


        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return false;
            }
            return base.CanConvertTo(context, destinationType);



        }















    }



}
