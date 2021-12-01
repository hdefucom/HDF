using DevExpress.XtraTab;
using DevExpress.XtraTab.Registrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsApp2.TabControl
{
    public class HDFTabControl : XtraTabControl
    {


        static HDFTabControl()
        {
            PaintStyleCollection.DefaultPaintStyles.Add(new HDFViewInfoRegistrator());
        }










    }


}
