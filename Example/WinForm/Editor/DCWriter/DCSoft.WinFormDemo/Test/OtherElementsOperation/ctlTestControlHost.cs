using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer;

namespace DCSoft.Writer.WinFormDemo.Test.OtherElementsOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestControlHost : UserControl
    {
        public ctlTestControlHost()
        {
            InitializeComponent();
        }

        private void frmTestControlHost_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnHostButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = new Button();
            btn.Width = 100;
            btn.Height = 50;
            btn.Text = "显示当前时间";
            btn.BackColor = Color.SkyBlue;
            btn.ForeColor = Color.Red;
            btn.Click += delegate(object sender2, EventArgs e2)
            {
                MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            };
            myWriterControl.ExecuteCommand("InsertControlHost", false, btn);
        }

        private void btnHostDI_Click(object sender, EventArgs e)
        {
            // 指定对象实例插入承载元素
            IDocumentImage img = new MyDocumentImage();
            myWriterControl.ExecuteCommand("InsertControlHost", false, img);
        }


        private void btnHostDI2_Click(object sender, EventArgs e)
        {
            // 指定类型插入承载元素
            myWriterControl.ExecuteCommand("InsertControlHost", false, typeof(MyDocumentImage));
        }

        /// <summary>
        /// 自定义的图形对象
        /// </summary>
        private class MyDocumentImage : IDocumentImage
        {
            public DocumentImageFlags ImageFlags
            {
                get
                {
                    // 声明自定义绘制背景
                    return DocumentImageFlags.CustomBackground;
                }
            }

            /// <summary>
            /// 获得图形对象最佳的大小
            /// </summary>
            /// <param name="g"></param>
            /// <returns></returns>
            public SizeF GetPreferredSize( DocumentPaintEventArgs args)
            {
                return new SizeF(800, 400);
            }

            /// <summary>
            /// 绘制图形
            /// </summary>
            /// <param name="args"></param>
            public void Draw(DocumentPaintEventArgs args)
            {
                RectangleF bounds = args.ClientViewBounds;
                args.Graphics.FillEllipse(Color.SkyBlue, bounds);
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    args.Graphics.DrawString(
                        "程序路径:" + Application.ExecutablePath,
                        Control.DefaultFont,
                        Brushes.Black,
                        bounds,
                        format);
                }
                args.Graphics.DrawEllipse(Pens.Red, bounds);
            }
        }

        private void btnInsertGrid_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(this.GetType().Assembly.GetManifestResourceStream("DCSoft.Writer.WinFormDemo.Test.DOCEX.xml"), XmlReadMode.Auto);
            System.Windows.Forms.DataGridView ctl = new DataGridView();
            ctl.DataSource = ds.Tables[0];
            ctl.Width = 400;
            ctl.Height = 200;
            myWriterControl.ExecuteCommand("InsertControlHost", false, ctl);
        }

        private void btnBindHandle_Click(object sender, EventArgs e)
        {
            XTextControlHostElement element = myWriterControl.CurrentElement as XTextControlHostElement;
            if (element != null)
            {
                using (DCSoft.WinForms.dlgBrowseWindowHandle dlg = new WinForms.dlgBrowseWindowHandle())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        element.SetNativeHostedControlHandle(dlg.SelectedWinHandle);
                        // 对应的，编辑控件还有SetNativeHostedControlHandle( elementID , int32Handle )方法。
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择一个控件容器元素。");
            }
        }
    }
}