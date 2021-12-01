using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab.Drawing;
using DevExpress.XtraTab.ViewInfo;
using System.Collections;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTab.Registrator;
using DevExpress.XtraTab;

namespace WinFormsApp2.TabControl
{
    public class HDFViewInfoRegistrator : FlatViewInfoRegistrator
    {
        public override string ViewName => "HDFView";




        //public override BaseTabPainter CreatePainter(IXtraTab tabControl)
        //{
        //    return new PropertyViewTabPainter(tabControl);
        //}

        //public override ObjectPainter CreateClosePageButtonPainter(IXtraTab tabControl)
        //{
        //    return EditorButtonHelper.GetPainter(BorderStyles.UltraFlat);
        //}

        //public override BaseTabHeaderViewInfo CreateHeaderViewInfo(BaseTabControlViewInfo viewInfo)
        //{
        //    return new PropertyViewTabHeaderViewInfo(viewInfo);
        //}

        //protected override void RegisterDefaultAppearances(IXtraTab tabControl, Hashtable appearances)
        //{
        //    appearances.Clear();
        //    appearances[TabPageAppearance.TabControl] = new AppearanceDefault(SystemColors.ControlText, SystemColors.Control, HorzAlignment.Center, VertAlignment.Center);
        //    appearances[TabPageAppearance.PageClient] = new AppearanceDefault(SystemColors.ControlText, SystemColors.Window, SystemColors.Highlight, Color.Empty, HorzAlignment.Center, VertAlignment.Center);
        //    appearances[TabPageAppearance.PageHeader] = new AppearanceDefault(SystemColors.ControlText, SystemColors.Control, SystemColors.GrayText, Color.Empty, HorzAlignment.Center, VertAlignment.Center);
        //    appearances[TabPageAppearance.PageHeaderActive] = new AppearanceDefault(SystemColors.ControlText, SystemColors.Window, SystemColors.Highlight, Color.Empty, new Font(AppearanceObject.DefaultFont, FontStyle.Bold), HorzAlignment.Center, VertAlignment.Center);
        //    appearances[TabPageAppearance.PageHeaderPressed] = new AppearanceDefault(SystemColors.ControlText, SystemColors.Control, HorzAlignment.Center, VertAlignment.Center);
        //    appearances[TabPageAppearance.PageHeaderHotTracked] = new AppearanceDefault(SystemColors.ControlText, SystemColors.Control, HorzAlignment.Center, VertAlignment.Center);
        //    appearances[TabPageAppearance.PageHeaderDisabled] = new AppearanceDefault(SystemColors.GrayText, SystemColors.Control, HorzAlignment.Center, VertAlignment.Center);
        //}

        //public override BorderPainter CreatePageClientBorderPainter()
        //{
        //    return new PropertyViewClientBorderPainter();
        //}

        //public override BorderPainter CreateHeaderRowBorderPainter()
        //{
        //    return new SideHeaderRowBorderPainter();
        //}












    }
}
