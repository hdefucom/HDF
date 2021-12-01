using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Document.PropertyElement;

namespace YidanSoft.Library.EmrEditor.Src.Document

{
    class DataElementMultiEditor : System.Drawing.Design.UITypeEditor
    {

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        // Displays the UI for value selection.
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                DataElementSelectrForm frm = new DataElementSelectrForm(value);

                //如果为ZYDataElementLookupEditor元素则把数据元代码列表进行筛选
                if (context.Instance is PropertyDataElementLookUpeditorElement)
                {
                    // 2019.06.26-hdf
                    // 新增病历模板编辑器功能，数据源字典，属性-选择数据源代码，窗体初始化查询进行筛选，筛选出所有S2,S3类型的数据元
                    // 给DataElementSelectrForm类添加了成员DataElementSelectrType默认值为“ALL”
                    frm.DataElementSelectrType = "S2S3";
                }
                edSvc.ShowDialog(frm);
                return frm.m_value;
            }
            return value;
        }
    }

}
