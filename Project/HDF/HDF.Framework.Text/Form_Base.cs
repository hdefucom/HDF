using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Text
{
    public partial class Form_Base : Form
    {
        public Form_Base()
        {
            InitializeComponent();
        }



        private void Form_Base_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnClick_New(e);
        }


        [Description("点击_新"), Category("自定义事件")]
        public event Action<int> Click_New;






        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnClick_New(EventArgs e)
        {
            Click_New?.Invoke(2);



            //EventHandler eventHandler = (EventHandler)this.Events[Control.EventClick];
            //if (eventHandler == null)
            //    return;
            //eventHandler((object)this, e);
        }



    }



}
