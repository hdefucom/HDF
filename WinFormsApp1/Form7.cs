//using System.ComponentModel.Design.Serialization;

namespace WinFormsApp1;

public partial class Form7 : Form
{
    public Form7()
    {
        InitializeComponent();



        // 创建一个Form的设计面
        //DesignSurface ds = new DesignSurface();

        ////ds.BeginLoad(typeof(Form));
        //ds.BeginLoad(typeof(Form));

        //var v = ds.View as Control;

        //v.Dock = DockStyle.Fill;
        //this.Controls.Add(v);





        //IDesignerHost idh = (IDesignerHost)ds.GetService(typeof(IDesignerHost));
        //Button b = (Button)idh.CreateComponent(typeof(Button));// 创建组件
        //b.Text = "XXXXXXX";
        //b.Parent = (Control)idh.RootComponent;


        //var dddd = idh.GetDesigner(b);





    }

    private void Form7_Load(object sender, EventArgs e)
    {



    }

    private void Form7_Paint(object sender, PaintEventArgs e)
    {

        var str = "d😂bsdf";

        e.Graphics.DrawString(str, this.Font, Brushes.Black, 0, 0);


        //TextRenderer.DrawText(e.Graphics, str, this.Font, new Point(0, 0), Color.Black);


    }
}






