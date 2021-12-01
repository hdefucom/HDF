using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class dlgBrowseImageLibrary : Form
    {
        public dlgBrowseImageLibrary()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dlgBrowseImage_Load(object sender, EventArgs e)
        {
            string libPath = System.IO.Path.Combine(
                Application.StartupPath,
                "DemoFile\\ImageLibrary");
            if (Directory.Exists(libPath))
            {
                ImageList imgs = null ;
                
                foreach (string fileName in Directory.GetFiles(libPath, "*.png"))
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(fileName);
                    if (imgs == null)
                    {
                        imgs = new ImageList();
                        imgs.ColorDepth = ColorDepth.Depth24Bit;
                        imgs.ImageSize = img.Size;
                    }
                    imgs.Images.Add( Path.GetFileNameWithoutExtension( fileName ) , img );
                }
                lvwImage.LargeImageList = imgs;
                foreach (string key in imgs.Images.Keys)
                {
                    ListViewItem item = new ListViewItem(key);
                    item.ImageKey = key;
                    item.Tag = Path.Combine(libPath, key + ".png");
                    lvwImage.Items.Add(item);
                }
            }
        }

        private System.Drawing.Image _SelectedImage = null;

        public System.Drawing.Image SelectedImage
        {
            get { return _SelectedImage; }
            set { _SelectedImage = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvwImage.FocusedItem != null)
            {
                this.SelectedImage = lvwImage.LargeImageList.Images[lvwImage.FocusedItem.ImageKey];
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
