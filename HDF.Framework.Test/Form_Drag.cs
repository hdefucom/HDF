namespace HDF.Test.Winform
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            //this.ImeMode = ImeMode.On;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            e.Graphics.DrawString("ss😅😅😅😅😅😅😅😅33", this.Font, Brushes.Black, 100, 250);



            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new Rectangle(100, 100, 100, 100));


            //fill stype
            var b = new HatchBrush(HatchStyle.Percent05, Color.Black, Color.White);

            e.Graphics.FillPath(b, path);


        }


        private void button1_Click(object sender, EventArgs e)
        {

            this.Invalidate();


        }





        private void button2_Click(object sender, EventArgs e)
        {



            this.Invalidate(new Rectangle(100, 100, 10, 10));
            this.Invalidate(new Rectangle(200, 100, 10, 10));
        }







        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;//1鼠标位置为客户区
        private const int HTCAPTION = 0x2;//2鼠标位置为标题栏


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);


            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }








    }
}
