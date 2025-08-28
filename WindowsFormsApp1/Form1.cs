using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            var writer = new CustomTestWriter();
            Action<string> aaa = str => txt_log.Invoke(new Action(() => txt_log.AppendText(str)));
            writer.Log += aaa;

            this.Disposed += (_, _) => writer.Log -= aaa;

            Console.SetOut(writer);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test1.Start(txt_sql.Text);

            MessageBox.Show("处理完成");
        }
    }





    public class CustomTestWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8;

        public event Action<string> Log;



        public override void Write(char value)
        {
            Log?.Invoke(value.ToString());
        }



        public override void Write(string value)
        {
            Log?.Invoke(value);
        }

        public override void WriteLine(string value)
        {
            Log?.Invoke(value + Environment.NewLine);
        }
    }
}
