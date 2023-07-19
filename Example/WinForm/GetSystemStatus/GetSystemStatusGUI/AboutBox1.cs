using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GetSystemStatusGUI;

internal class AboutBox1 : Form
{
	private IContainer components = null;

	private TableLayoutPanel tableLayoutPanel;

	private PictureBox logoPictureBox;

	private Label labelProductName;

	private Label labelVersion;

	private Label labelCopyright;

	private Label labelCompanyName;

	private TextBox textBoxDescription;

	private Button okButton;

	public string AssemblyTitle
	{
		get
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
			if (customAttributes.Length != 0)
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

	public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

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

	public AboutBox1()
	{
		InitializeComponent();
		Text = $"关于 {AssemblyTitle}";
		labelProductName.Text = AssemblyProduct;
		labelVersion.Text = $"版本 {AssemblyVersion}";
		labelCopyright.Text = AssemblyCopyright;
		labelCompanyName.Text = AssemblyCompany;
	}

	private void okButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetSystemStatusGUI.AboutBox1));
		this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
		this.logoPictureBox = new System.Windows.Forms.PictureBox();
		this.labelProductName = new System.Windows.Forms.Label();
		this.labelVersion = new System.Windows.Forms.Label();
		this.labelCopyright = new System.Windows.Forms.Label();
		this.labelCompanyName = new System.Windows.Forms.Label();
		this.textBoxDescription = new System.Windows.Forms.TextBox();
		this.okButton = new System.Windows.Forms.Button();
		this.tableLayoutPanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.logoPictureBox).BeginInit();
		base.SuspendLayout();
		this.tableLayoutPanel.ColumnCount = 2;
		this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33f));
		this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67f));
		this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
		this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
		this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
		this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
		this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
		this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
		this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
		this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel.Location = new System.Drawing.Point(9, 8);
		this.tableLayoutPanel.Name = "tableLayoutPanel";
		this.tableLayoutPanel.RowCount = 6;
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10f));
		this.tableLayoutPanel.Size = new System.Drawing.Size(417, 245);
		this.tableLayoutPanel.TabIndex = 0;
		this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
		this.logoPictureBox.Image = (System.Drawing.Image)resources.GetObject("logoPictureBox.Image");
		this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
		this.logoPictureBox.Name = "logoPictureBox";
		this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
		this.logoPictureBox.Size = new System.Drawing.Size(131, 239);
		this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.logoPictureBox.TabIndex = 12;
		this.logoPictureBox.TabStop = false;
		this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelProductName.Location = new System.Drawing.Point(143, 0);
		this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelProductName.MaximumSize = new System.Drawing.Size(0, 16);
		this.labelProductName.Name = "labelProductName";
		this.labelProductName.Size = new System.Drawing.Size(271, 16);
		this.labelProductName.TabIndex = 19;
		this.labelProductName.Text = "GetSystemStatus GUI Version";
		this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelVersion.Location = new System.Drawing.Point(143, 24);
		this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelVersion.MaximumSize = new System.Drawing.Size(0, 16);
		this.labelVersion.Name = "labelVersion";
		this.labelVersion.Size = new System.Drawing.Size(271, 16);
		this.labelVersion.TabIndex = 0;
		this.labelVersion.Text = "2.0.0";
		this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelCopyright.Location = new System.Drawing.Point(143, 48);
		this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 16);
		this.labelCopyright.Name = "labelCopyright";
		this.labelCopyright.Size = new System.Drawing.Size(271, 16);
		this.labelCopyright.TabIndex = 21;
		this.labelCopyright.Text = "Copyright © InnovatorNZ Group";
		this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.labelCompanyName.Location = new System.Drawing.Point(143, 72);
		this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 16);
		this.labelCompanyName.Name = "labelCompanyName";
		this.labelCompanyName.Size = new System.Drawing.Size(271, 16);
		this.labelCompanyName.TabIndex = 22;
		this.labelCompanyName.Text = "NOS Association × SEGroup";
		this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
		this.textBoxDescription.Location = new System.Drawing.Point(143, 99);
		this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		this.textBoxDescription.Multiline = true;
		this.textBoxDescription.Name = "textBoxDescription";
		this.textBoxDescription.ReadOnly = true;
		this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.textBoxDescription.Size = new System.Drawing.Size(271, 116);
		this.textBoxDescription.TabIndex = 23;
		this.textBoxDescription.TabStop = false;
		this.textBoxDescription.Text = "允许将此程序在注明原作者的情况下传播、修改或重发布\r\n\r\n项目仓库代码地址：https://northern_oceans.coding.net/public/GetSystemStatus/GetSystemStatus/git/files";
		this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.okButton.Location = new System.Drawing.Point(339, 221);
		this.okButton.Name = "okButton";
		this.okButton.Size = new System.Drawing.Size(75, 21);
		this.okButton.TabIndex = 24;
		this.okButton.Text = "确定(&O)";
		this.okButton.Click += new System.EventHandler(okButton_Click);
		base.AcceptButton = this.okButton;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(435, 261);
		base.Controls.Add(this.tableLayoutPanel);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AboutBox1";
		base.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "About";
		this.tableLayoutPanel.ResumeLayout(false);
		this.tableLayoutPanel.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.logoPictureBox).EndInit();
		base.ResumeLayout(false);
	}
}
