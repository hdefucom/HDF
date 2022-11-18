using System;
using System.Windows.Forms;

namespace HDF.Test.Winform
{
    public partial class LoadingForm : Form, IDisposable
    {
        public LoadingForm()
        {
            InitializeComponent();
        }


        protected override void Dispose(bool disposing)
        {

            if (this.IsDisposed)
                return;

            if (!this.IsHandleCreated)
            {
                close = true;
                return;

            }

            this.Invoke(() =>
            {

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            });
        }

        bool close;

        protected override void OnShown(EventArgs e)
        {
            if (close)
                this.Close();
        }



        public static LoadingForm StartNew()
        {
            var obj = new LoadingForm();


            //Task.Run(() =>
            //{
            //    obj.ShowDialog();

            //});
            obj.Show();
            return obj;
        }







    }
}
