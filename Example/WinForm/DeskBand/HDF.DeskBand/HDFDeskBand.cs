using CSDeskBand;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HDF.DeskBand
{
    [ComVisible(true)]
    [Guid("1B92DD2C-CA05-4F03-99B8-BB0E4092B0B1")]
    [CSDeskBandRegistration(Name = "HDFDeskBand", ShowDeskBand = true)]
    public class HDFDeskBand : CSDeskBandWin
    {
        private Control _control;

        protected override Control Control => _control;


        private class CustomTextWriter : TextWriter
        {
            public override Encoding Encoding => Encoding.Default;

            public override void Write(char value)
            {
                //string LogPath = Application.StartupPath + "\\Console.txt";
                string LogPath = "E:\\Console.txt";
                File.AppendAllText(LogPath, value.ToString());
            }
        }

        public HDFDeskBand()
        {
            Console.SetOut(new CustomTextWriter());
            var form = new MainControl() { TaskbarEdge = TaskbarInfo.Edge };

            TaskbarInfo.TaskbarEdgeChanged += (sender, e) => form.TaskbarEdge = e.Edge;

            _control = form;


            Options.Title = "HDF";
            Options.ShowTitle = true;

            Options.HorizontalSize = new DeskBandSize(200, 40);
            Options.VerticalSize = new DeskBandSize(130, 40);

            Options.MinHorizontalSize = new DeskBandSize(200, 40);
            Options.MinVerticalSize = new DeskBandSize(130, 40);

        }


        protected override void DeskbandOnClosed()
        {

            (_control as MainControl)?.Dispose();

            base.DeskbandOnClosed();
        }


    }
}
