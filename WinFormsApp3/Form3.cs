using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3;

public partial class Form3 : Form
{
    public Form3()
    {
        InitializeComponent();
        this.DoubleBuffered = true;
    }

    private void Form3_Load(object sender, System.EventArgs e)
    {

        this.listBox1.DisplayMember = "Key";
        this.listBox1.ValueMember = "Value";

        this.listBox1.DataSource = new List<KeyValuePair<string, Type>> {
        new ("数字", typeof(double)),
        new ("日期时间", typeof(DateTime)),
        new ("字符", typeof(string)),
        };
    }

    private void button5_Click(object sender, System.EventArgs e)
    {
        //枚举所有视频输入设备
        var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        if (videoDevices.Count != 0)
        {


            var videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame); //新建事件
            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();


        }

    }


    void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        if (!pz)
            return;

        pz = false;

        Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();   //Clone摄像头中的一帧

        pictureBox1.Image = bmp;
        //bmp.Save(path, ImageFormat.Png);

    }


    bool pz = false;

    private void button1_Click(object sender, System.EventArgs e)
    {
        pz = true;


        var obj = this.listBox1.SelectedValue;
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }
}
