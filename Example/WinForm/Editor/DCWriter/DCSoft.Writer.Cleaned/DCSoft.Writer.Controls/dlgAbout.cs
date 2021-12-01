using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       关于对话框
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public class dlgAbout : Form
	{
		private IContainer icontainer_0 = null;

		private Label labelVersion;

		private TextBox textBoxDescription;

		private Button okButton;

		private Label lblLicense;

		private LinkLabel lnkSite;

		private Button btnSystemInfo;

		private Label label1;

		private TextBox txtMainPath;

		private PictureBox pictureBox1;

		private PictureBox pictureBox3;

		private Panel panel1;

		private Label labelProductName;

		private Label labelCopyright;

		private Label label2;

		private Label lblRuntimeVersion;

		internal static string LicnesedUserName = null;

		/// <summary>
		///       程序标题
		///       </summary>
		public string AssemblyTitle
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
				if (customAttributes.Length > 0)
				{
					AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
					if (assemblyTitleAttribute.Title != "")
					{
						return assemblyTitleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		/// <summary>
		///       程序版本
		///       </summary>
		public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

		/// <summary>
		///       程序说明
		///       </summary>
		public string AssemblyDescription
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
			}
		}

		/// <summary>
		///       产品信息
		///       </summary>
		public string AssemblyProduct
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)customAttributes[0]).Product;
			}
		}

		/// <summary>
		///       版权信息
		///       </summary>
		public string AssemblyCopyright
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
			}
		}

		/// <summary>
		///       公司信息
		///       </summary>
		public string AssemblyCompany
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
			}
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgAbout));
			labelVersion = new System.Windows.Forms.Label();
			textBoxDescription = new System.Windows.Forms.TextBox();
			okButton = new System.Windows.Forms.Button();
			lblLicense = new System.Windows.Forms.Label();
			lnkSite = new System.Windows.Forms.LinkLabel();
			btnSystemInfo = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			txtMainPath = new System.Windows.Forms.TextBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			labelCopyright = new System.Windows.Forms.Label();
			labelProductName = new System.Windows.Forms.Label();
			lblRuntimeVersion = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(labelVersion, "labelVersion");
			labelVersion.ForeColor = System.Drawing.SystemColors.WindowText;
			labelVersion.Name = "labelVersion";
			resources.ApplyResources(textBoxDescription, "textBoxDescription");
			textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(89, 87, 87);
			textBoxDescription.Name = "textBoxDescription";
			textBoxDescription.ReadOnly = true;
			textBoxDescription.TabStop = false;
			okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(okButton, "okButton");
			okButton.Name = "okButton";
			okButton.Click += new System.EventHandler(okButton_Click);
			lblLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(lblLicense, "lblLicense");
			lblLicense.Name = "lblLicense";
			resources.ApplyResources(lnkSite, "lnkSite");
			lnkSite.ForeColor = System.Drawing.SystemColors.WindowText;
			lnkSite.Name = "lnkSite";
			lnkSite.TabStop = true;
			lnkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkSite_LinkClicked);
			resources.ApplyResources(btnSystemInfo, "btnSystemInfo");
			btnSystemInfo.Name = "btnSystemInfo";
			btnSystemInfo.UseVisualStyleBackColor = true;
			btnSystemInfo.Click += new System.EventHandler(btnSystemInfo_Click);
			resources.ApplyResources(label1, "label1");
			label1.ForeColor = System.Drawing.SystemColors.WindowText;
			label1.Name = "label1";
			resources.ApplyResources(txtMainPath, "txtMainPath");
			txtMainPath.ForeColor = System.Drawing.Color.FromArgb(89, 87, 87);
			txtMainPath.Name = "txtMainPath";
			txtMainPath.ReadOnly = true;
			resources.ApplyResources(pictureBox1, "pictureBox1");
			pictureBox1.Name = "pictureBox1";
			pictureBox1.TabStop = false;
			resources.ApplyResources(pictureBox3, "pictureBox3");
			pictureBox3.Name = "pictureBox3";
			pictureBox3.TabStop = false;
			panel1.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
			panel1.Controls.Add(labelCopyright);
			panel1.Controls.Add(labelProductName);
			panel1.Controls.Add(pictureBox3);
			panel1.Controls.Add(lblRuntimeVersion);
			panel1.Controls.Add(labelVersion);
			panel1.Controls.Add(txtMainPath);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(lblLicense);
			panel1.Controls.Add(btnSystemInfo);
			panel1.Controls.Add(textBoxDescription);
			panel1.Controls.Add(lnkSite);
			panel1.Controls.Add(okButton);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			resources.ApplyResources(labelCopyright, "labelCopyright");
			labelCopyright.Name = "labelCopyright";
			resources.ApplyResources(labelProductName, "labelProductName");
			labelProductName.Name = "labelProductName";
			resources.ApplyResources(lblRuntimeVersion, "lblRuntimeVersion");
			lblRuntimeVersion.ForeColor = System.Drawing.SystemColors.WindowText;
			lblRuntimeVersion.Name = "lblRuntimeVersion";
			resources.ApplyResources(label2, "label2");
			label2.ForeColor = System.Drawing.SystemColors.WindowText;
			label2.Name = "label2";
			base.AcceptButton = okButton;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(0, 168, 155);
			base.Controls.Add(panel1);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgAbout";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgAbout_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgAbout()
		{
			InitializeComponent();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgAbout_Load(object sender, EventArgs e)
		{
			int num = 7;
			Type typeFromHandle = typeof(WriterControl);
			PortableExecutableKinds peKind = PortableExecutableKinds.ILOnly;
			ImageFileMachine machine = ImageFileMachine.I386;
			typeFromHandle.Module.GetPEKind(out peKind, out machine);
			Text = string.Concat(Text, " [", peKind, ",", machine.ToString(), "][lan:", Thread.CurrentThread.CurrentUICulture.Name, "]");
			if (XTextDocument.IsAssemblyObfuscation)
			{
			}
			txtMainPath.Text += typeof(XTextDocument).Assembly.Location;
			AssemblyName assemblyName = new AssemblyName(typeFromHandle.Assembly.FullName);
			labelVersion.Text = string.Format(labelVersion.Text, assemblyName.Version.ToString(), WriterControl.StaticCoreVersion);
			lblRuntimeVersion.Text += Environment.Version.ToString();
			if (!string.IsNullOrEmpty(LicnesedUserName))
			{
				lblLicense.Text = string.Format(WriterUtils.smethod_0("RegisterTitle_UserName"), LicnesedUserName);
				return;
			}
			lblLicense.Text = WriterUtils.smethod_0("UnRegisterTitle");
			lblLicense.ForeColor = Color.Red;
		}

		private void lnkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.dcwriter.cn");
		}

		private void btnSystemInfo_Click(object sender, EventArgs e)
		{
			using (dlgEnvironmentInfo dlgEnvironmentInfo = new dlgEnvironmentInfo())
			{
				dlgEnvironmentInfo.ShowDialog(this);
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}
	}
}
