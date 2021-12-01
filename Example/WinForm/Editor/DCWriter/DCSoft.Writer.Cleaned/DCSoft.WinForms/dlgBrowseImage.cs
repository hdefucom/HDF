using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       选择图片的对话框
	///       </summary>
	public class dlgBrowseImage : Form
	{
		private GControl3 ctlImage;

		private Button cmdOK;

		private Button cmdCancel;

		private ToolStrip toolStrip1;

		private ToolStripButton cmdLoad;

		private ToolStripButton cmdClear;

		private ToolStripButton cmdCopy;

		private ToolStripButton cmdPaste;

		private ToolStripButton cmdScreenSnapshot;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton chkSelectable;

		private ToolStripButton cmdResize;

		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private Container components = null;

		private string strTitle = null;

		private byte[] bsInputData = null;

		private Image myImage = null;

		private Image mySelectedImage = null;

		/// <summary>
		///       用户选择的图片对象
		///       </summary>
		public Image Image
		{
			get
			{
				return myImage;
			}
			set
			{
				myImage = value;
			}
		}

		/// <summary>
		///       用户选择的图片的二进制数据
		///       </summary>
		public byte[] InputData
		{
			get
			{
				return bsInputData;
			}
			set
			{
				bsInputData = value;
				if (bsInputData == null)
				{
					myImage = null;
				}
				else
				{
					myImage = Image.FromStream(new MemoryStream(bsInputData));
				}
				ctlImage.method_6(myImage);
			}
		}

		/// <summary>
		///       用户选择的图片对象
		///       </summary>
		public Image SelectedImage => mySelectedImage;

		public dlgBrowseImage()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要使用代码编辑器修改
		///       此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgBrowseImage));
			ctlImage = new DCSoftDotfuscate.GControl3();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			cmdLoad = new System.Windows.Forms.ToolStripButton();
			cmdClear = new System.Windows.Forms.ToolStripButton();
			cmdCopy = new System.Windows.Forms.ToolStripButton();
			cmdPaste = new System.Windows.Forms.ToolStripButton();
			cmdScreenSnapshot = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			chkSelectable = new System.Windows.Forms.ToolStripButton();
			cmdResize = new System.Windows.Forms.ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(ctlImage, "ctlImage");
			ctlImage.BackColor = System.Drawing.Color.Silver;
			ctlImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			ctlImage.method_6(null);
			ctlImage.Name = "ctlImage";
			ctlImage.method_4(new System.Drawing.Rectangle(0, 0, 0, 0));
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[8]
			{
				cmdLoad,
				cmdClear,
				cmdCopy,
				cmdPaste,
				cmdResize,
				cmdScreenSnapshot,
				toolStripSeparator1,
				chkSelectable
			});
			resources.ApplyResources(toolStrip1, "toolStrip1");
			toolStrip1.Name = "toolStrip1";
			cmdLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(cmdLoad, "cmdLoad");
			cmdLoad.Name = "cmdLoad";
			cmdLoad.Click += new System.EventHandler(cmdLoad_Click);
			cmdClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(cmdClear, "cmdClear");
			cmdClear.Name = "cmdClear";
			cmdClear.Click += new System.EventHandler(cmdClear_Click);
			cmdCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(cmdCopy, "cmdCopy");
			cmdCopy.Name = "cmdCopy";
			cmdCopy.Click += new System.EventHandler(cmdCopy_Click);
			cmdPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(cmdPaste, "cmdPaste");
			cmdPaste.Name = "cmdPaste";
			cmdPaste.Click += new System.EventHandler(cmdPaste_Click);
			resources.ApplyResources(cmdScreenSnapshot, "cmdScreenSnapshot");
			cmdScreenSnapshot.Name = "cmdScreenSnapshot";
			cmdScreenSnapshot.Click += new System.EventHandler(cmdScreenSnapshot_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
			chkSelectable.CheckOnClick = true;
			chkSelectable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			resources.ApplyResources(chkSelectable, "chkSelectable");
			chkSelectable.Name = "chkSelectable";
			chkSelectable.Click += new System.EventHandler(chkSelectable_CheckedChanged);
			cmdResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(cmdResize, "cmdResize");
			cmdResize.Name = "cmdResize";
			cmdResize.Click += new System.EventHandler(cmdResize_Click);
			resources.ApplyResources(this, "$this");
			base.Controls.Add(toolStrip1);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(ctlImage);
			base.MinimizeBox = false;
			base.Name = "dlgBrowseImage";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgBrowseImage_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void cmdLoad_Click(object sender, EventArgs e)
		{
			int num = 3;
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "图片文件(*.bmp,*.jpg,*.png,*.gif)|*.bmp;*.jpg;*.png;*.gif";
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
					{
						bsInputData = new byte[fileStream.Length];
						fileStream.Read(bsInputData, 0, bsInputData.Length);
					}
					MemoryStream memoryStream = new MemoryStream(bsInputData);
					myImage = Image.FromStream(memoryStream);
					memoryStream.Close();
					ctlImage.method_6(myImage);
					ctlImage.Focus();
				}
			}
		}

		private void cmdClear_Click(object sender, EventArgs e)
		{
			myImage = null;
			ctlImage.method_6(null);
			bsInputData = null;
			ctlImage.Focus();
		}

		private void cmdZoomIn_Click(object sender, EventArgs e)
		{
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			mySelectedImage = ctlImage.method_5();
			if (ctlImage.method_0() == GEnum30.const_2)
			{
				mySelectedImage = ctlImage.method_2();
				bsInputData = null;
			}
			else
			{
				mySelectedImage = ctlImage.method_5();
			}
			if (mySelectedImage != null && bsInputData == null)
			{
				MemoryStream memoryStream = new MemoryStream();
				mySelectedImage.Save(memoryStream, ImageFormat.Png);
				memoryStream.Close();
				bsInputData = memoryStream.ToArray();
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cmdPaste_Click(object sender, EventArgs e)
		{
			if (ctlImage.method_12())
			{
				MemoryStream memoryStream = new MemoryStream();
				ctlImage.method_5().Save(memoryStream, ImageFormat.Jpeg);
				memoryStream.Close();
				bsInputData = memoryStream.ToArray();
			}
		}

		private void cmdCopy_Click(object sender, EventArgs e)
		{
			ctlImage.method_11();
		}

		private void dlgBrowseImage_Load(object sender, EventArgs e)
		{
			int num = 6;
			strTitle = Text;
			if (myImage != null)
			{
				Text = strTitle + " - W:" + myImage.Width + " H:" + myImage.Height + " Pixel:" + myImage.PixelFormat;
			}
		}

		private void cmdScreenSnapshot_Click(object sender, EventArgs e)
		{
			ctlImage.method_4(Rectangle.Empty);
			ctlImage.Refresh();
			using (dlgScreenSnapshot dlgScreenSnapshot = new dlgScreenSnapshot())
			{
				if (dlgScreenSnapshot.ShowDialog(this) == DialogResult.OK)
				{
					ctlImage.method_6(dlgScreenSnapshot.BmpContent);
					bsInputData = null;
					Activate();
					ctlImage.Refresh();
				}
			}
		}

		private void chkSelectable_CheckedChanged(object sender, EventArgs e)
		{
			ctlImage.method_1((!chkSelectable.Checked) ? GEnum30.const_1 : GEnum30.const_2);
		}

		private void cmdResize_Click(object sender, EventArgs e)
		{
			if (ctlImage.method_5() != null)
			{
				using (dlgImageResize dlgImageResize = new dlgImageResize())
				{
					dlgImageResize.OldSize = ctlImage.method_5().Size;
					if (dlgImageResize.ShowDialog(this) == DialogResult.OK)
					{
						XImageValue xImageValue = new XImageValue(ctlImage.method_5());
						xImageValue = xImageValue.GetThumbnailImage(dlgImageResize.NewSize.Width, dlgImageResize.NewSize.Height);
						ctlImage.method_6(xImageValue.Value);
						ctlImage.Refresh();
						bsInputData = null;
					}
				}
			}
		}
	}
}
