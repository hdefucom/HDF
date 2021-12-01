using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using CSDeskBand;

namespace TestDeskBand
{
    [ComVisible(true)]
    [Guid("1E8B8C53-B581-4E16-82C5-7857E8A14EE1")]
    [CSDeskBandRegistration(Name = "HDFDeskBand", ShowDeskBand = true)]
    public class TestDeskBand : CSDeskBandWin
    {
        private Control _control;

        protected override Control Control => _control;


        public TestDeskBand()
        {
            _control = new TestControl();
            Options.Title = "HDF";
            Options.ShowTitle = true;

            Options.HorizontalSize = new DeskBandSize(200, 40);
            Options.VerticalSize = new DeskBandSize(130, 40);

            Options.MinHorizontalSize = new DeskBandSize(200, 40);
            Options.MinVerticalSize = new DeskBandSize(130, 40);

        }






    }





}
