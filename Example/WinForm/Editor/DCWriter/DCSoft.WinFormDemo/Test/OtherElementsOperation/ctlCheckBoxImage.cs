using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.OtherElementsOperation
{
    [ToolboxItem(false)]
    public partial class ctlCheckBoxImage : UserControl
    {
        public ctlCheckBoxImage()
        {
            InitializeComponent();
        }


        private void ctlCheckBoxImage_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            btnOpenDemo_Click(null, null);
        }

        private void btnOpenDemo_Click(object sender, EventArgs e)
        {
            myWriterControl.LoadDocumentFromFile(
                System.IO.Path.Combine(Application.StartupPath, @"DemoFile2\护理记录--成都中医药大学附属医院入院护理记录.xml"), 
                null);

        }

        private void btnStdIcon_Click(object sender, EventArgs e)
        {
            this.myWriterControl.SetDomImage(DCStdImageKey.CheckBoxChecked, null);
            this.myWriterControl.SetDomImage(DCStdImageKey.CheckBoxUnchecked, null);
            this.myWriterControl.SetDomImage(DCStdImageKey.RadioBoxChecked, null);
            this.myWriterControl.SetDomImage(DCStdImageKey.RadioBoxUnchecked, null);
        }

        private void btnCustomIcon_Click(object sender, EventArgs e)
        {
            string fileName1 = System.IO.Path.Combine(Application.StartupPath, @"Test\iconchecked.bmp");
            string fileName2 = System.IO.Path.Combine(Application.StartupPath, @"Test\iconunchecked.bmp");
            string fileName3 = System.IO.Path.Combine(Application.StartupPath, @"Test\iconradiochecked.bmp");

            Bitmap img1 = (Bitmap)Image.FromFile(fileName1);
            Bitmap img2 = (Bitmap)Image.FromFile(fileName2);
            Bitmap img3 = (Bitmap)Image.FromFile(fileName3);

            this.myWriterControl.SetDomImage(DCStdImageKey.CheckBoxChecked, img1);
            this.myWriterControl.SetDomImage(DCStdImageKey.CheckBoxUnchecked, img2);
            this.myWriterControl.SetDomImage(DCStdImageKey.RadioBoxChecked, img3);
            this.myWriterControl.SetDomImage(DCStdImageKey.RadioBoxUnchecked, img2);

            // 下面的代码也可以实现相同的功能效果。
            //this.myWriterControl.SetDomImageByFileName(DCStdImageKey.CheckBoxChecked, fileName1);
            //this.myWriterControl.SetDomImageByFileName(DCStdImageKey.CheckBoxUnchecked, fileName2);
            //this.myWriterControl.SetDomImageByFileName(DCStdImageKey.RadioBoxChecked, fileName3);
            //this.myWriterControl.SetDomImageByFileName(DCStdImageKey.RadioBoxUnchecked, fileName2);

        }

        private void btnContentReadonlyBindingTargetID_Click(object sender, EventArgs e)
        {
            myWriterControl.LoadDocumentFromFile(
                System.IO.Path.Combine(Application.StartupPath, "DemoFile\\TestElementIDForEditableDependent.xml"),
                null );
        }

        private void menuVisible_Click(object sender, EventArgs e)
        {
            menuVisible.Checked = true;
            menuHiddenAll.Checked = false;
            menuHiddenCheckBoxOnly.Checked = false;
            SetPrintVisibilityModeWhenUnchecked(PrintVisibilityModeWhenUnchecked.Visible);
        }

        private void SetPrintVisibilityModeWhenUnchecked(DCSoft.Writer.Dom.PrintVisibilityModeWhenUnchecked mode)
        {
            foreach (XTextCheckBoxElement chk in this.myWriterControl.CheckBoxes)
            {
                chk.PrintVisibilityWhenUnchecked = mode;
            }
            foreach (XTextRadioBoxElement rdo in this.myWriterControl.RadioBoxes)
            {
                rdo.PrintVisibilityWhenUnchecked = mode;
            }

        }

        private void menuHiddenCheckBoxOnly_Click(object sender, EventArgs e)
        {
            menuVisible.Checked = false ;
            menuHiddenAll.Checked = false;
            menuHiddenCheckBoxOnly.Checked = true ;
            SetPrintVisibilityModeWhenUnchecked(PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly );
        }

        private void menuHiddenAll_Click(object sender, EventArgs e)
        {
            menuVisible.Checked = false;
            menuHiddenAll.Checked = true ;
            menuHiddenCheckBoxOnly.Checked = false ;
            SetPrintVisibilityModeWhenUnchecked(PrintVisibilityModeWhenUnchecked.HiddenAll );
        }
    }
}