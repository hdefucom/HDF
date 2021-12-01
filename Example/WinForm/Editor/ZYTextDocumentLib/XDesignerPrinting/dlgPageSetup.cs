using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Resources;
using System.Windows.Forms;
using XDesignerCommon;
using XDesignerGUI;

namespace XDesignerPrinting
{
	public class dlgPageSetup : Form
	{
		private GroupBox groupBox1;

		private Label label1;

		private NumericUpDown txtTopMargin;

		private NumericUpDown txtBottomMargin;

		private Label label2;

		private Label label3;

		private NumericUpDown txtLeftMargin;

		private NumericUpDown txtRightMargin;

		private Label label4;

		private GroupBox groupBox2;

		private Label label7;

		private Label label8;

		private Label label9;

		private ComboBox cboPage;

		private GroupBox groupBox3;

		private PictureBox picPreview;

		private Button cmdOK;

		private Button cmdCancel;

		private Label label5;

		private Label label6;

		private RadioButton rdoLandscape;

		private RadioButton rdoLandscape2;

		private NumericUpDown txtWidth;

		private NumericUpDown txtHeight;

		private Container components = null;

		internal string ErrorString = "Paget setting error";

		private XPageSettings myPageSettings = null;

		public XPageSettings PageSettings
		{
			get
			{
				return myPageSettings;
			}
			set
			{
				myPageSettings = value;
			}
		}

		public dlgPageSetup()
		{
			base.DialogResult = DialogResult.Cancel;
			InitializeComponent();
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
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(XDesignerPrinting.dlgPageSetup));
			groupBox2 = new System.Windows.Forms.GroupBox();
			rdoLandscape = new System.Windows.Forms.RadioButton();
			label5 = new System.Windows.Forms.Label();
			rdoLandscape2 = new System.Windows.Forms.RadioButton();
			label6 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			txtTopMargin = new System.Windows.Forms.NumericUpDown();
			txtLeftMargin = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			txtBottomMargin = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtRightMargin = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			txtWidth = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			cboPage = new System.Windows.Forms.ComboBox();
			label7 = new System.Windows.Forms.Label();
			txtHeight = new System.Windows.Forms.NumericUpDown();
			label9 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			picPreview = new System.Windows.Forms.PictureBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtTopMargin).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtLeftMargin).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtBottomMargin).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtRightMargin).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtHeight).BeginInit();
			groupBox3.SuspendLayout();
			SuspendLayout();
			groupBox2.AccessibleDescription = resourceManager.GetString("groupBox2.AccessibleDescription");
			groupBox2.AccessibleName = resourceManager.GetString("groupBox2.AccessibleName");
			groupBox2.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("groupBox2.Anchor");
			groupBox2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("groupBox2.BackgroundImage");
			groupBox2.Controls.Add(rdoLandscape);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(rdoLandscape2);
			groupBox2.Controls.Add(label6);
			groupBox2.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("groupBox2.Dock");
			groupBox2.Enabled = (bool)resourceManager.GetObject("groupBox2.Enabled");
			groupBox2.Font = (System.Drawing.Font)resourceManager.GetObject("groupBox2.Font");
			groupBox2.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("groupBox2.ImeMode");
			groupBox2.Location = (System.Drawing.Point)resourceManager.GetObject("groupBox2.Location");
			groupBox2.Name = "groupBox2";
			groupBox2.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("groupBox2.RightToLeft");
			groupBox2.Size = (System.Drawing.Size)resourceManager.GetObject("groupBox2.Size");
			groupBox2.TabIndex = (int)resourceManager.GetObject("groupBox2.TabIndex");
			groupBox2.TabStop = false;
			groupBox2.Text = resourceManager.GetString("groupBox2.Text");
			groupBox2.Visible = (bool)resourceManager.GetObject("groupBox2.Visible");
			rdoLandscape.AccessibleDescription = resourceManager.GetString("rdoLandscape.AccessibleDescription");
			rdoLandscape.AccessibleName = resourceManager.GetString("rdoLandscape.AccessibleName");
			rdoLandscape.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("rdoLandscape.Anchor");
			rdoLandscape.Appearance = (System.Windows.Forms.Appearance)resourceManager.GetObject("rdoLandscape.Appearance");
			rdoLandscape.BackColor = System.Drawing.SystemColors.Control;
			rdoLandscape.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("rdoLandscape.BackgroundImage");
			rdoLandscape.CheckAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("rdoLandscape.CheckAlign");
			rdoLandscape.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("rdoLandscape.Dock");
			rdoLandscape.Enabled = (bool)resourceManager.GetObject("rdoLandscape.Enabled");
			rdoLandscape.FlatStyle = (System.Windows.Forms.FlatStyle)resourceManager.GetObject("rdoLandscape.FlatStyle");
			rdoLandscape.Font = (System.Drawing.Font)resourceManager.GetObject("rdoLandscape.Font");
			rdoLandscape.Image = (System.Drawing.Image)resourceManager.GetObject("rdoLandscape.Image");
			rdoLandscape.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("rdoLandscape.ImageAlign");
			rdoLandscape.ImageIndex = (int)resourceManager.GetObject("rdoLandscape.ImageIndex");
			rdoLandscape.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("rdoLandscape.ImeMode");
			rdoLandscape.Location = (System.Drawing.Point)resourceManager.GetObject("rdoLandscape.Location");
			rdoLandscape.Name = "rdoLandscape";
			rdoLandscape.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("rdoLandscape.RightToLeft");
			rdoLandscape.Size = (System.Drawing.Size)resourceManager.GetObject("rdoLandscape.Size");
			rdoLandscape.TabIndex = (int)resourceManager.GetObject("rdoLandscape.TabIndex");
			rdoLandscape.Text = resourceManager.GetString("rdoLandscape.Text");
			rdoLandscape.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("rdoLandscape.TextAlign");
			rdoLandscape.Visible = (bool)resourceManager.GetObject("rdoLandscape.Visible");
			rdoLandscape.CheckedChanged += new System.EventHandler(rdoLandscape_CheckedChanged);
			label5.AccessibleDescription = resourceManager.GetString("label5.AccessibleDescription");
			label5.AccessibleName = resourceManager.GetString("label5.AccessibleName");
			label5.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label5.Anchor");
			label5.AutoSize = (bool)resourceManager.GetObject("label5.AutoSize");
			label5.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label5.Dock");
			label5.Enabled = (bool)resourceManager.GetObject("label5.Enabled");
			label5.Font = (System.Drawing.Font)resourceManager.GetObject("label5.Font");
			label5.Image = (System.Drawing.Image)resourceManager.GetObject("label5.Image");
			label5.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label5.ImageAlign");
			label5.ImageIndex = (int)resourceManager.GetObject("label5.ImageIndex");
			label5.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label5.ImeMode");
			label5.Location = (System.Drawing.Point)resourceManager.GetObject("label5.Location");
			label5.Name = "label5";
			label5.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label5.RightToLeft");
			label5.Size = (System.Drawing.Size)resourceManager.GetObject("label5.Size");
			label5.TabIndex = (int)resourceManager.GetObject("label5.TabIndex");
			label5.Text = resourceManager.GetString("label5.Text");
			label5.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label5.TextAlign");
			label5.Visible = (bool)resourceManager.GetObject("label5.Visible");
			rdoLandscape2.AccessibleDescription = resourceManager.GetString("rdoLandscape2.AccessibleDescription");
			rdoLandscape2.AccessibleName = resourceManager.GetString("rdoLandscape2.AccessibleName");
			rdoLandscape2.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("rdoLandscape2.Anchor");
			rdoLandscape2.Appearance = (System.Windows.Forms.Appearance)resourceManager.GetObject("rdoLandscape2.Appearance");
			rdoLandscape2.BackColor = System.Drawing.SystemColors.Control;
			rdoLandscape2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("rdoLandscape2.BackgroundImage");
			rdoLandscape2.CheckAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("rdoLandscape2.CheckAlign");
			rdoLandscape2.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("rdoLandscape2.Dock");
			rdoLandscape2.Enabled = (bool)resourceManager.GetObject("rdoLandscape2.Enabled");
			rdoLandscape2.FlatStyle = (System.Windows.Forms.FlatStyle)resourceManager.GetObject("rdoLandscape2.FlatStyle");
			rdoLandscape2.Font = (System.Drawing.Font)resourceManager.GetObject("rdoLandscape2.Font");
			rdoLandscape2.Image = (System.Drawing.Image)resourceManager.GetObject("rdoLandscape2.Image");
			rdoLandscape2.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("rdoLandscape2.ImageAlign");
			rdoLandscape2.ImageIndex = (int)resourceManager.GetObject("rdoLandscape2.ImageIndex");
			rdoLandscape2.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("rdoLandscape2.ImeMode");
			rdoLandscape2.Location = (System.Drawing.Point)resourceManager.GetObject("rdoLandscape2.Location");
			rdoLandscape2.Name = "rdoLandscape2";
			rdoLandscape2.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("rdoLandscape2.RightToLeft");
			rdoLandscape2.Size = (System.Drawing.Size)resourceManager.GetObject("rdoLandscape2.Size");
			rdoLandscape2.TabIndex = (int)resourceManager.GetObject("rdoLandscape2.TabIndex");
			rdoLandscape2.Text = resourceManager.GetString("rdoLandscape2.Text");
			rdoLandscape2.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("rdoLandscape2.TextAlign");
			rdoLandscape2.Visible = (bool)resourceManager.GetObject("rdoLandscape2.Visible");
			rdoLandscape2.CheckedChanged += new System.EventHandler(rdoLandscape2_CheckedChanged);
			label6.AccessibleDescription = resourceManager.GetString("label6.AccessibleDescription");
			label6.AccessibleName = resourceManager.GetString("label6.AccessibleName");
			label6.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label6.Anchor");
			label6.AutoSize = (bool)resourceManager.GetObject("label6.AutoSize");
			label6.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label6.Dock");
			label6.Enabled = (bool)resourceManager.GetObject("label6.Enabled");
			label6.Font = (System.Drawing.Font)resourceManager.GetObject("label6.Font");
			label6.Image = (System.Drawing.Image)resourceManager.GetObject("label6.Image");
			label6.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label6.ImageAlign");
			label6.ImageIndex = (int)resourceManager.GetObject("label6.ImageIndex");
			label6.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label6.ImeMode");
			label6.Location = (System.Drawing.Point)resourceManager.GetObject("label6.Location");
			label6.Name = "label6";
			label6.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label6.RightToLeft");
			label6.Size = (System.Drawing.Size)resourceManager.GetObject("label6.Size");
			label6.TabIndex = (int)resourceManager.GetObject("label6.TabIndex");
			label6.Text = resourceManager.GetString("label6.Text");
			label6.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label6.TextAlign");
			label6.Visible = (bool)resourceManager.GetObject("label6.Visible");
			groupBox1.AccessibleDescription = resourceManager.GetString("groupBox1.AccessibleDescription");
			groupBox1.AccessibleName = resourceManager.GetString("groupBox1.AccessibleName");
			groupBox1.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("groupBox1.Anchor");
			groupBox1.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("groupBox1.BackgroundImage");
			groupBox1.Controls.Add(txtTopMargin);
			groupBox1.Controls.Add(txtLeftMargin);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(txtBottomMargin);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(txtRightMargin);
			groupBox1.Controls.Add(label4);
			groupBox1.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("groupBox1.Dock");
			groupBox1.Enabled = (bool)resourceManager.GetObject("groupBox1.Enabled");
			groupBox1.Font = (System.Drawing.Font)resourceManager.GetObject("groupBox1.Font");
			groupBox1.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("groupBox1.ImeMode");
			groupBox1.Location = (System.Drawing.Point)resourceManager.GetObject("groupBox1.Location");
			groupBox1.Name = "groupBox1";
			groupBox1.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("groupBox1.RightToLeft");
			groupBox1.Size = (System.Drawing.Size)resourceManager.GetObject("groupBox1.Size");
			groupBox1.TabIndex = (int)resourceManager.GetObject("groupBox1.TabIndex");
			groupBox1.TabStop = false;
			groupBox1.Text = resourceManager.GetString("groupBox1.Text");
			groupBox1.Visible = (bool)resourceManager.GetObject("groupBox1.Visible");
			txtTopMargin.AccessibleDescription = resourceManager.GetString("txtTopMargin.AccessibleDescription");
			txtTopMargin.AccessibleName = resourceManager.GetString("txtTopMargin.AccessibleName");
			txtTopMargin.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("txtTopMargin.Anchor");
			txtTopMargin.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("txtTopMargin.Dock");
			txtTopMargin.Enabled = (bool)resourceManager.GetObject("txtTopMargin.Enabled");
			txtTopMargin.Font = (System.Drawing.Font)resourceManager.GetObject("txtTopMargin.Font");
			txtTopMargin.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("txtTopMargin.ImeMode");
			txtTopMargin.Location = (System.Drawing.Point)resourceManager.GetObject("txtTopMargin.Location");
			txtTopMargin.Maximum = new decimal(new int[4]
			{
				60000,
				0,
				0,
				0
			});
			txtTopMargin.Name = "txtTopMargin";
			txtTopMargin.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("txtTopMargin.RightToLeft");
			txtTopMargin.Size = (System.Drawing.Size)resourceManager.GetObject("txtTopMargin.Size");
			txtTopMargin.TabIndex = (int)resourceManager.GetObject("txtTopMargin.TabIndex");
			txtTopMargin.TextAlign = (System.Windows.Forms.HorizontalAlignment)resourceManager.GetObject("txtTopMargin.TextAlign");
			txtTopMargin.ThousandsSeparator = (bool)resourceManager.GetObject("txtTopMargin.ThousandsSeparator");
			txtTopMargin.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)resourceManager.GetObject("txtTopMargin.UpDownAlign");
			txtTopMargin.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtTopMargin.Visible = (bool)resourceManager.GetObject("txtTopMargin.Visible");
			txtTopMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtTopMargin_KeyPress);
			txtTopMargin.ValueChanged += new System.EventHandler(txtTopMargin_ValueChanged);
			txtLeftMargin.AccessibleDescription = resourceManager.GetString("txtLeftMargin.AccessibleDescription");
			txtLeftMargin.AccessibleName = resourceManager.GetString("txtLeftMargin.AccessibleName");
			txtLeftMargin.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("txtLeftMargin.Anchor");
			txtLeftMargin.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("txtLeftMargin.Dock");
			txtLeftMargin.Enabled = (bool)resourceManager.GetObject("txtLeftMargin.Enabled");
			txtLeftMargin.Font = (System.Drawing.Font)resourceManager.GetObject("txtLeftMargin.Font");
			txtLeftMargin.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("txtLeftMargin.ImeMode");
			txtLeftMargin.Location = (System.Drawing.Point)resourceManager.GetObject("txtLeftMargin.Location");
			txtLeftMargin.Maximum = new decimal(new int[4]
			{
				60000,
				0,
				0,
				0
			});
			txtLeftMargin.Name = "txtLeftMargin";
			txtLeftMargin.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("txtLeftMargin.RightToLeft");
			txtLeftMargin.Size = (System.Drawing.Size)resourceManager.GetObject("txtLeftMargin.Size");
			txtLeftMargin.TabIndex = (int)resourceManager.GetObject("txtLeftMargin.TabIndex");
			txtLeftMargin.TextAlign = (System.Windows.Forms.HorizontalAlignment)resourceManager.GetObject("txtLeftMargin.TextAlign");
			txtLeftMargin.ThousandsSeparator = (bool)resourceManager.GetObject("txtLeftMargin.ThousandsSeparator");
			txtLeftMargin.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)resourceManager.GetObject("txtLeftMargin.UpDownAlign");
			txtLeftMargin.Visible = (bool)resourceManager.GetObject("txtLeftMargin.Visible");
			txtLeftMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLeftMargin_KeyPress);
			txtLeftMargin.ValueChanged += new System.EventHandler(txtLeftMargin_ValueChanged);
			label1.AccessibleDescription = resourceManager.GetString("label1.AccessibleDescription");
			label1.AccessibleName = resourceManager.GetString("label1.AccessibleName");
			label1.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label1.Anchor");
			label1.AutoSize = (bool)resourceManager.GetObject("label1.AutoSize");
			label1.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label1.Dock");
			label1.Enabled = (bool)resourceManager.GetObject("label1.Enabled");
			label1.Font = (System.Drawing.Font)resourceManager.GetObject("label1.Font");
			label1.Image = (System.Drawing.Image)resourceManager.GetObject("label1.Image");
			label1.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label1.ImageAlign");
			label1.ImageIndex = (int)resourceManager.GetObject("label1.ImageIndex");
			label1.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label1.ImeMode");
			label1.Location = (System.Drawing.Point)resourceManager.GetObject("label1.Location");
			label1.Name = "label1";
			label1.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label1.RightToLeft");
			label1.Size = (System.Drawing.Size)resourceManager.GetObject("label1.Size");
			label1.TabIndex = (int)resourceManager.GetObject("label1.TabIndex");
			label1.Text = resourceManager.GetString("label1.Text");
			label1.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label1.TextAlign");
			label1.Visible = (bool)resourceManager.GetObject("label1.Visible");
			txtBottomMargin.AccessibleDescription = resourceManager.GetString("txtBottomMargin.AccessibleDescription");
			txtBottomMargin.AccessibleName = resourceManager.GetString("txtBottomMargin.AccessibleName");
			txtBottomMargin.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("txtBottomMargin.Anchor");
			txtBottomMargin.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("txtBottomMargin.Dock");
			txtBottomMargin.Enabled = (bool)resourceManager.GetObject("txtBottomMargin.Enabled");
			txtBottomMargin.Font = (System.Drawing.Font)resourceManager.GetObject("txtBottomMargin.Font");
			txtBottomMargin.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("txtBottomMargin.ImeMode");
			txtBottomMargin.Location = (System.Drawing.Point)resourceManager.GetObject("txtBottomMargin.Location");
			txtBottomMargin.Maximum = new decimal(new int[4]
			{
				600000,
				0,
				0,
				0
			});
			txtBottomMargin.Name = "txtBottomMargin";
			txtBottomMargin.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("txtBottomMargin.RightToLeft");
			txtBottomMargin.Size = (System.Drawing.Size)resourceManager.GetObject("txtBottomMargin.Size");
			txtBottomMargin.TabIndex = (int)resourceManager.GetObject("txtBottomMargin.TabIndex");
			txtBottomMargin.TextAlign = (System.Windows.Forms.HorizontalAlignment)resourceManager.GetObject("txtBottomMargin.TextAlign");
			txtBottomMargin.ThousandsSeparator = (bool)resourceManager.GetObject("txtBottomMargin.ThousandsSeparator");
			txtBottomMargin.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)resourceManager.GetObject("txtBottomMargin.UpDownAlign");
			txtBottomMargin.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtBottomMargin.Visible = (bool)resourceManager.GetObject("txtBottomMargin.Visible");
			txtBottomMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBottomMargin_KeyPress);
			txtBottomMargin.ValueChanged += new System.EventHandler(txtBottomMargin_ValueChanged);
			label2.AccessibleDescription = resourceManager.GetString("label2.AccessibleDescription");
			label2.AccessibleName = resourceManager.GetString("label2.AccessibleName");
			label2.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label2.Anchor");
			label2.AutoSize = (bool)resourceManager.GetObject("label2.AutoSize");
			label2.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label2.Dock");
			label2.Enabled = (bool)resourceManager.GetObject("label2.Enabled");
			label2.Font = (System.Drawing.Font)resourceManager.GetObject("label2.Font");
			label2.Image = (System.Drawing.Image)resourceManager.GetObject("label2.Image");
			label2.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label2.ImageAlign");
			label2.ImageIndex = (int)resourceManager.GetObject("label2.ImageIndex");
			label2.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label2.ImeMode");
			label2.Location = (System.Drawing.Point)resourceManager.GetObject("label2.Location");
			label2.Name = "label2";
			label2.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label2.RightToLeft");
			label2.Size = (System.Drawing.Size)resourceManager.GetObject("label2.Size");
			label2.TabIndex = (int)resourceManager.GetObject("label2.TabIndex");
			label2.Text = resourceManager.GetString("label2.Text");
			label2.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label2.TextAlign");
			label2.Visible = (bool)resourceManager.GetObject("label2.Visible");
			label3.AccessibleDescription = resourceManager.GetString("label3.AccessibleDescription");
			label3.AccessibleName = resourceManager.GetString("label3.AccessibleName");
			label3.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label3.Anchor");
			label3.AutoSize = (bool)resourceManager.GetObject("label3.AutoSize");
			label3.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label3.Dock");
			label3.Enabled = (bool)resourceManager.GetObject("label3.Enabled");
			label3.Font = (System.Drawing.Font)resourceManager.GetObject("label3.Font");
			label3.Image = (System.Drawing.Image)resourceManager.GetObject("label3.Image");
			label3.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label3.ImageAlign");
			label3.ImageIndex = (int)resourceManager.GetObject("label3.ImageIndex");
			label3.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label3.ImeMode");
			label3.Location = (System.Drawing.Point)resourceManager.GetObject("label3.Location");
			label3.Name = "label3";
			label3.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label3.RightToLeft");
			label3.Size = (System.Drawing.Size)resourceManager.GetObject("label3.Size");
			label3.TabIndex = (int)resourceManager.GetObject("label3.TabIndex");
			label3.Text = resourceManager.GetString("label3.Text");
			label3.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label3.TextAlign");
			label3.Visible = (bool)resourceManager.GetObject("label3.Visible");
			txtRightMargin.AccessibleDescription = resourceManager.GetString("txtRightMargin.AccessibleDescription");
			txtRightMargin.AccessibleName = resourceManager.GetString("txtRightMargin.AccessibleName");
			txtRightMargin.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("txtRightMargin.Anchor");
			txtRightMargin.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("txtRightMargin.Dock");
			txtRightMargin.Enabled = (bool)resourceManager.GetObject("txtRightMargin.Enabled");
			txtRightMargin.Font = (System.Drawing.Font)resourceManager.GetObject("txtRightMargin.Font");
			txtRightMargin.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("txtRightMargin.ImeMode");
			txtRightMargin.Location = (System.Drawing.Point)resourceManager.GetObject("txtRightMargin.Location");
			txtRightMargin.Maximum = new decimal(new int[4]
			{
				600000,
				0,
				0,
				0
			});
			txtRightMargin.Name = "txtRightMargin";
			txtRightMargin.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("txtRightMargin.RightToLeft");
			txtRightMargin.Size = (System.Drawing.Size)resourceManager.GetObject("txtRightMargin.Size");
			txtRightMargin.TabIndex = (int)resourceManager.GetObject("txtRightMargin.TabIndex");
			txtRightMargin.TextAlign = (System.Windows.Forms.HorizontalAlignment)resourceManager.GetObject("txtRightMargin.TextAlign");
			txtRightMargin.ThousandsSeparator = (bool)resourceManager.GetObject("txtRightMargin.ThousandsSeparator");
			txtRightMargin.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)resourceManager.GetObject("txtRightMargin.UpDownAlign");
			txtRightMargin.Visible = (bool)resourceManager.GetObject("txtRightMargin.Visible");
			txtRightMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRightMargin_KeyPress);
			txtRightMargin.ValueChanged += new System.EventHandler(txtRightMargin_ValueChanged);
			label4.AccessibleDescription = resourceManager.GetString("label4.AccessibleDescription");
			label4.AccessibleName = resourceManager.GetString("label4.AccessibleName");
			label4.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label4.Anchor");
			label4.AutoSize = (bool)resourceManager.GetObject("label4.AutoSize");
			label4.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label4.Dock");
			label4.Enabled = (bool)resourceManager.GetObject("label4.Enabled");
			label4.Font = (System.Drawing.Font)resourceManager.GetObject("label4.Font");
			label4.Image = (System.Drawing.Image)resourceManager.GetObject("label4.Image");
			label4.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label4.ImageAlign");
			label4.ImageIndex = (int)resourceManager.GetObject("label4.ImageIndex");
			label4.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label4.ImeMode");
			label4.Location = (System.Drawing.Point)resourceManager.GetObject("label4.Location");
			label4.Name = "label4";
			label4.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label4.RightToLeft");
			label4.Size = (System.Drawing.Size)resourceManager.GetObject("label4.Size");
			label4.TabIndex = (int)resourceManager.GetObject("label4.TabIndex");
			label4.Text = resourceManager.GetString("label4.Text");
			label4.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label4.TextAlign");
			label4.Visible = (bool)resourceManager.GetObject("label4.Visible");
			txtWidth.AccessibleDescription = resourceManager.GetString("txtWidth.AccessibleDescription");
			txtWidth.AccessibleName = resourceManager.GetString("txtWidth.AccessibleName");
			txtWidth.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("txtWidth.Anchor");
			txtWidth.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("txtWidth.Dock");
			txtWidth.Enabled = (bool)resourceManager.GetObject("txtWidth.Enabled");
			txtWidth.Font = (System.Drawing.Font)resourceManager.GetObject("txtWidth.Font");
			txtWidth.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("txtWidth.ImeMode");
			txtWidth.Location = (System.Drawing.Point)resourceManager.GetObject("txtWidth.Location");
			txtWidth.Maximum = new decimal(new int[4]
			{
				60000,
				0,
				0,
				0
			});
			txtWidth.Name = "txtWidth";
			txtWidth.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("txtWidth.RightToLeft");
			txtWidth.Size = (System.Drawing.Size)resourceManager.GetObject("txtWidth.Size");
			txtWidth.TabIndex = (int)resourceManager.GetObject("txtWidth.TabIndex");
			txtWidth.TextAlign = (System.Windows.Forms.HorizontalAlignment)resourceManager.GetObject("txtWidth.TextAlign");
			txtWidth.ThousandsSeparator = (bool)resourceManager.GetObject("txtWidth.ThousandsSeparator");
			txtWidth.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)resourceManager.GetObject("txtWidth.UpDownAlign");
			txtWidth.Visible = (bool)resourceManager.GetObject("txtWidth.Visible");
			txtWidth.ValueChanged += new System.EventHandler(txtWidth_ValueChanged);
			label8.AccessibleDescription = resourceManager.GetString("label8.AccessibleDescription");
			label8.AccessibleName = resourceManager.GetString("label8.AccessibleName");
			label8.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label8.Anchor");
			label8.AutoSize = (bool)resourceManager.GetObject("label8.AutoSize");
			label8.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label8.Dock");
			label8.Enabled = (bool)resourceManager.GetObject("label8.Enabled");
			label8.Font = (System.Drawing.Font)resourceManager.GetObject("label8.Font");
			label8.Image = (System.Drawing.Image)resourceManager.GetObject("label8.Image");
			label8.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label8.ImageAlign");
			label8.ImageIndex = (int)resourceManager.GetObject("label8.ImageIndex");
			label8.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label8.ImeMode");
			label8.Location = (System.Drawing.Point)resourceManager.GetObject("label8.Location");
			label8.Name = "label8";
			label8.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label8.RightToLeft");
			label8.Size = (System.Drawing.Size)resourceManager.GetObject("label8.Size");
			label8.TabIndex = (int)resourceManager.GetObject("label8.TabIndex");
			label8.Text = resourceManager.GetString("label8.Text");
			label8.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label8.TextAlign");
			label8.Visible = (bool)resourceManager.GetObject("label8.Visible");
			cboPage.AccessibleDescription = resourceManager.GetString("cboPage.AccessibleDescription");
			cboPage.AccessibleName = resourceManager.GetString("cboPage.AccessibleName");
			cboPage.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("cboPage.Anchor");
			cboPage.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cboPage.BackgroundImage");
			cboPage.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("cboPage.Dock");
			cboPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboPage.Enabled = (bool)resourceManager.GetObject("cboPage.Enabled");
			cboPage.Font = (System.Drawing.Font)resourceManager.GetObject("cboPage.Font");
			cboPage.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("cboPage.ImeMode");
			cboPage.IntegralHeight = (bool)resourceManager.GetObject("cboPage.IntegralHeight");
			cboPage.ItemHeight = (int)resourceManager.GetObject("cboPage.ItemHeight");
			cboPage.Location = (System.Drawing.Point)resourceManager.GetObject("cboPage.Location");
			cboPage.MaxDropDownItems = (int)resourceManager.GetObject("cboPage.MaxDropDownItems");
			cboPage.MaxLength = (int)resourceManager.GetObject("cboPage.MaxLength");
			cboPage.Name = "cboPage";
			cboPage.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("cboPage.RightToLeft");
			cboPage.Size = (System.Drawing.Size)resourceManager.GetObject("cboPage.Size");
			cboPage.TabIndex = (int)resourceManager.GetObject("cboPage.TabIndex");
			cboPage.Text = resourceManager.GetString("cboPage.Text");
			cboPage.Visible = (bool)resourceManager.GetObject("cboPage.Visible");
			cboPage.SelectedIndexChanged += new System.EventHandler(cboPage_SelectedIndexChanged);
			label7.AccessibleDescription = resourceManager.GetString("label7.AccessibleDescription");
			label7.AccessibleName = resourceManager.GetString("label7.AccessibleName");
			label7.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label7.Anchor");
			label7.AutoSize = (bool)resourceManager.GetObject("label7.AutoSize");
			label7.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label7.Dock");
			label7.Enabled = (bool)resourceManager.GetObject("label7.Enabled");
			label7.Font = (System.Drawing.Font)resourceManager.GetObject("label7.Font");
			label7.Image = (System.Drawing.Image)resourceManager.GetObject("label7.Image");
			label7.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label7.ImageAlign");
			label7.ImageIndex = (int)resourceManager.GetObject("label7.ImageIndex");
			label7.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label7.ImeMode");
			label7.Location = (System.Drawing.Point)resourceManager.GetObject("label7.Location");
			label7.Name = "label7";
			label7.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label7.RightToLeft");
			label7.Size = (System.Drawing.Size)resourceManager.GetObject("label7.Size");
			label7.TabIndex = (int)resourceManager.GetObject("label7.TabIndex");
			label7.Text = resourceManager.GetString("label7.Text");
			label7.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label7.TextAlign");
			label7.Visible = (bool)resourceManager.GetObject("label7.Visible");
			txtHeight.AccessibleDescription = resourceManager.GetString("txtHeight.AccessibleDescription");
			txtHeight.AccessibleName = resourceManager.GetString("txtHeight.AccessibleName");
			txtHeight.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("txtHeight.Anchor");
			txtHeight.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("txtHeight.Dock");
			txtHeight.Enabled = (bool)resourceManager.GetObject("txtHeight.Enabled");
			txtHeight.Font = (System.Drawing.Font)resourceManager.GetObject("txtHeight.Font");
			txtHeight.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("txtHeight.ImeMode");
			txtHeight.Location = (System.Drawing.Point)resourceManager.GetObject("txtHeight.Location");
			txtHeight.Maximum = new decimal(new int[4]
			{
				600000,
				0,
				0,
				0
			});
			txtHeight.Name = "txtHeight";
			txtHeight.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("txtHeight.RightToLeft");
			txtHeight.Size = (System.Drawing.Size)resourceManager.GetObject("txtHeight.Size");
			txtHeight.TabIndex = (int)resourceManager.GetObject("txtHeight.TabIndex");
			txtHeight.TextAlign = (System.Windows.Forms.HorizontalAlignment)resourceManager.GetObject("txtHeight.TextAlign");
			txtHeight.ThousandsSeparator = (bool)resourceManager.GetObject("txtHeight.ThousandsSeparator");
			txtHeight.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)resourceManager.GetObject("txtHeight.UpDownAlign");
			txtHeight.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtHeight.Visible = (bool)resourceManager.GetObject("txtHeight.Visible");
			txtHeight.ValueChanged += new System.EventHandler(txtHeight_ValueChanged);
			label9.AccessibleDescription = resourceManager.GetString("label9.AccessibleDescription");
			label9.AccessibleName = resourceManager.GetString("label9.AccessibleName");
			label9.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("label9.Anchor");
			label9.AutoSize = (bool)resourceManager.GetObject("label9.AutoSize");
			label9.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("label9.Dock");
			label9.Enabled = (bool)resourceManager.GetObject("label9.Enabled");
			label9.Font = (System.Drawing.Font)resourceManager.GetObject("label9.Font");
			label9.Image = (System.Drawing.Image)resourceManager.GetObject("label9.Image");
			label9.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label9.ImageAlign");
			label9.ImageIndex = (int)resourceManager.GetObject("label9.ImageIndex");
			label9.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("label9.ImeMode");
			label9.Location = (System.Drawing.Point)resourceManager.GetObject("label9.Location");
			label9.Name = "label9";
			label9.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("label9.RightToLeft");
			label9.Size = (System.Drawing.Size)resourceManager.GetObject("label9.Size");
			label9.TabIndex = (int)resourceManager.GetObject("label9.TabIndex");
			label9.Text = resourceManager.GetString("label9.Text");
			label9.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("label9.TextAlign");
			label9.Visible = (bool)resourceManager.GetObject("label9.Visible");
			groupBox3.AccessibleDescription = resourceManager.GetString("groupBox3.AccessibleDescription");
			groupBox3.AccessibleName = resourceManager.GetString("groupBox3.AccessibleName");
			groupBox3.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("groupBox3.Anchor");
			groupBox3.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("groupBox3.BackgroundImage");
			groupBox3.Controls.Add(picPreview);
			groupBox3.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("groupBox3.Dock");
			groupBox3.Enabled = (bool)resourceManager.GetObject("groupBox3.Enabled");
			groupBox3.Font = (System.Drawing.Font)resourceManager.GetObject("groupBox3.Font");
			groupBox3.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("groupBox3.ImeMode");
			groupBox3.Location = (System.Drawing.Point)resourceManager.GetObject("groupBox3.Location");
			groupBox3.Name = "groupBox3";
			groupBox3.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("groupBox3.RightToLeft");
			groupBox3.Size = (System.Drawing.Size)resourceManager.GetObject("groupBox3.Size");
			groupBox3.TabIndex = (int)resourceManager.GetObject("groupBox3.TabIndex");
			groupBox3.TabStop = false;
			groupBox3.Text = resourceManager.GetString("groupBox3.Text");
			groupBox3.Visible = (bool)resourceManager.GetObject("groupBox3.Visible");
			picPreview.AccessibleDescription = resourceManager.GetString("picPreview.AccessibleDescription");
			picPreview.AccessibleName = resourceManager.GetString("picPreview.AccessibleName");
			picPreview.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("picPreview.Anchor");
			picPreview.BackColor = System.Drawing.SystemColors.Control;
			picPreview.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("picPreview.BackgroundImage");
			picPreview.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("picPreview.Dock");
			picPreview.Enabled = (bool)resourceManager.GetObject("picPreview.Enabled");
			picPreview.Font = (System.Drawing.Font)resourceManager.GetObject("picPreview.Font");
			picPreview.Image = (System.Drawing.Image)resourceManager.GetObject("picPreview.Image");
			picPreview.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("picPreview.ImeMode");
			picPreview.Location = (System.Drawing.Point)resourceManager.GetObject("picPreview.Location");
			picPreview.Name = "picPreview";
			picPreview.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("picPreview.RightToLeft");
			picPreview.Size = (System.Drawing.Size)resourceManager.GetObject("picPreview.Size");
			picPreview.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)resourceManager.GetObject("picPreview.SizeMode");
			picPreview.TabIndex = (int)resourceManager.GetObject("picPreview.TabIndex");
			picPreview.TabStop = false;
			picPreview.Text = resourceManager.GetString("picPreview.Text");
			picPreview.Visible = (bool)resourceManager.GetObject("picPreview.Visible");
			picPreview.Paint += new System.Windows.Forms.PaintEventHandler(picPreview_Paint);
			cmdOK.AccessibleDescription = resourceManager.GetString("cmdOK.AccessibleDescription");
			cmdOK.AccessibleName = resourceManager.GetString("cmdOK.AccessibleName");
			cmdOK.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("cmdOK.Anchor");
			cmdOK.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdOK.BackgroundImage");
			cmdOK.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("cmdOK.Dock");
			cmdOK.Enabled = (bool)resourceManager.GetObject("cmdOK.Enabled");
			cmdOK.FlatStyle = (System.Windows.Forms.FlatStyle)resourceManager.GetObject("cmdOK.FlatStyle");
			cmdOK.Font = (System.Drawing.Font)resourceManager.GetObject("cmdOK.Font");
			cmdOK.Image = (System.Drawing.Image)resourceManager.GetObject("cmdOK.Image");
			cmdOK.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("cmdOK.ImageAlign");
			cmdOK.ImageIndex = (int)resourceManager.GetObject("cmdOK.ImageIndex");
			cmdOK.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("cmdOK.ImeMode");
			cmdOK.Location = (System.Drawing.Point)resourceManager.GetObject("cmdOK.Location");
			cmdOK.Name = "cmdOK";
			cmdOK.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("cmdOK.RightToLeft");
			cmdOK.Size = (System.Drawing.Size)resourceManager.GetObject("cmdOK.Size");
			cmdOK.TabIndex = (int)resourceManager.GetObject("cmdOK.TabIndex");
			cmdOK.Text = resourceManager.GetString("cmdOK.Text");
			cmdOK.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("cmdOK.TextAlign");
			cmdOK.Visible = (bool)resourceManager.GetObject("cmdOK.Visible");
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.AccessibleDescription = resourceManager.GetString("cmdCancel.AccessibleDescription");
			cmdCancel.AccessibleName = resourceManager.GetString("cmdCancel.AccessibleName");
			cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles)resourceManager.GetObject("cmdCancel.Anchor");
			cmdCancel.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdCancel.BackgroundImage");
			cmdCancel.Dock = (System.Windows.Forms.DockStyle)resourceManager.GetObject("cmdCancel.Dock");
			cmdCancel.Enabled = (bool)resourceManager.GetObject("cmdCancel.Enabled");
			cmdCancel.FlatStyle = (System.Windows.Forms.FlatStyle)resourceManager.GetObject("cmdCancel.FlatStyle");
			cmdCancel.Font = (System.Drawing.Font)resourceManager.GetObject("cmdCancel.Font");
			cmdCancel.Image = (System.Drawing.Image)resourceManager.GetObject("cmdCancel.Image");
			cmdCancel.ImageAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("cmdCancel.ImageAlign");
			cmdCancel.ImageIndex = (int)resourceManager.GetObject("cmdCancel.ImageIndex");
			cmdCancel.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("cmdCancel.ImeMode");
			cmdCancel.Location = (System.Drawing.Point)resourceManager.GetObject("cmdCancel.Location");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("cmdCancel.RightToLeft");
			cmdCancel.Size = (System.Drawing.Size)resourceManager.GetObject("cmdCancel.Size");
			cmdCancel.TabIndex = (int)resourceManager.GetObject("cmdCancel.TabIndex");
			cmdCancel.Text = resourceManager.GetString("cmdCancel.Text");
			cmdCancel.TextAlign = (System.Drawing.ContentAlignment)resourceManager.GetObject("cmdCancel.TextAlign");
			cmdCancel.Visible = (bool)resourceManager.GetObject("cmdCancel.Visible");
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			base.AccessibleDescription = resourceManager.GetString("$this.AccessibleDescription");
			base.AccessibleName = resourceManager.GetString("$this.AccessibleName");
			AutoScaleBaseSize = (System.Drawing.Size)resourceManager.GetObject("$this.AutoScaleBaseSize");
			AutoScroll = (bool)resourceManager.GetObject("$this.AutoScroll");
			base.AutoScrollMargin = (System.Drawing.Size)resourceManager.GetObject("$this.AutoScrollMargin");
			base.AutoScrollMinSize = (System.Drawing.Size)resourceManager.GetObject("$this.AutoScrollMinSize");
			BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("$this.BackgroundImage");
			base.ClientSize = (System.Drawing.Size)resourceManager.GetObject("$this.ClientSize");
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(txtWidth);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(label9);
			base.Controls.Add(cboPage);
			base.Controls.Add(txtHeight);
			base.Enabled = (bool)resourceManager.GetObject("$this.Enabled");
			Font = (System.Drawing.Font)resourceManager.GetObject("$this.Font");
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.ImeMode = (System.Windows.Forms.ImeMode)resourceManager.GetObject("$this.ImeMode");
			base.Location = (System.Drawing.Point)resourceManager.GetObject("$this.Location");
			base.MaximizeBox = false;
			MaximumSize = (System.Drawing.Size)resourceManager.GetObject("$this.MaximumSize");
			base.MinimizeBox = false;
			MinimumSize = (System.Drawing.Size)resourceManager.GetObject("$this.MinimumSize");
			base.Name = "dlgPageSetup";
			RightToLeft = (System.Windows.Forms.RightToLeft)resourceManager.GetObject("$this.RightToLeft");
			base.ShowInTaskbar = false;
			base.StartPosition = (System.Windows.Forms.FormStartPosition)resourceManager.GetObject("$this.StartPosition");
			Text = resourceManager.GetString("$this.Text");
			base.Load += new System.EventHandler(dlgPageSetup_Load);
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)txtTopMargin).EndInit();
			((System.ComponentModel.ISupportInitialize)txtLeftMargin).EndInit();
			((System.ComponentModel.ISupportInitialize)txtBottomMargin).EndInit();
			((System.ComponentModel.ISupportInitialize)txtRightMargin).EndInit();
			((System.ComponentModel.ISupportInitialize)txtWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)txtHeight).EndInit();
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void dlgPageSetup_Load(object sender, EventArgs e)
		{
			cboPage.Items.Clear();
			cboPage.Items.AddRange(XPaperSizeCollection.StdInstance.ToArray());
			if (myPageSettings == null)
			{
				return;
			}
			for (int i = 0; i < cboPage.Items.Count; i++)
			{
				XPaperSize xPaperSize = (XPaperSize)cboPage.Items[i];
				if (xPaperSize.Kind == myPageSettings.PaperSize.Kind)
				{
					cboPage.SelectedIndex = i;
					break;
				}
			}
			txtWidth.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(myPageSettings.PaperSize.Width));
			txtHeight.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(myPageSettings.PaperSize.Height));
			txtLeftMargin.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(myPageSettings.Margins.Left));
			txtTopMargin.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(myPageSettings.Margins.Top));
			txtRightMargin.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(myPageSettings.Margins.Right));
			txtBottomMargin.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(myPageSettings.Margins.Bottom));
			rdoLandscape.Checked = !myPageSettings.Landscape;
			rdoLandscape2.Checked = myPageSettings.Landscape;
		}

		private bool RefreshPageSettings()
		{
			if (myPageSettings != null)
			{
				XPaperSize xPaperSize = cboPage.SelectedItem as XPaperSize;
				if (xPaperSize != null)
				{
					myPageSettings.PaperSize = xPaperSize;
				}
				if (xPaperSize == null || myPageSettings.PaperSize.Kind == PaperKind.Custom)
				{
					int vWidth = (int)MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble(txtWidth.Value));
					int vHeight = (int)MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble(txtHeight.Value));
					myPageSettings.PaperSize = new XPaperSize(PaperKind.Custom, vWidth, vHeight);
				}
				myPageSettings.Margins.Left = (int)MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble(txtLeftMargin.Value));
				myPageSettings.Margins.Top = (int)MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble(txtTopMargin.Value));
				myPageSettings.Margins.Right = (int)MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble(txtRightMargin.Value));
				myPageSettings.Margins.Bottom = (int)MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble(txtBottomMargin.Value));
				myPageSettings.Landscape = rdoLandscape2.Checked;
				return true;
			}
			return false;
		}

		private void picPreview_Paint(object sender, PaintEventArgs e)
		{
			if (!RefreshPageSettings())
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					e.Graphics.DrawString(ErrorString, Font, Brushes.Red, new RectangleF(0f, 0f, picPreview.Width, picPreview.Height), stringFormat);
				}
				return;
			}
			PageSettingPreview pageSettingPreview = new PageSettingPreview();
			pageSettingPreview.Landscape = myPageSettings.Landscape;
			pageSettingPreview.Margins = myPageSettings.Margins;
			pageSettingPreview.PaperSize = myPageSettings.PaperSize.StdSize;
			pageSettingPreview.Bounds = picPreview.ClientRectangle;
			pageSettingPreview.OnPaint(sender, e);
		}

		private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
		{
			XPaperSize xPaperSize = cboPage.SelectedItem as XPaperSize;
			if (xPaperSize != null)
			{
				txtWidth.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(xPaperSize.Width));
				txtHeight.Value = Convert.ToDecimal(MeasureConvert.HundredthsInchToMillimeter(xPaperSize.Height));
				txtWidth.ReadOnly = (xPaperSize.Kind != PaperKind.Custom);
				txtHeight.ReadOnly = (xPaperSize.Kind != PaperKind.Custom);
				picPreview.Invalidate();
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (RefreshPageSettings())
			{
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBoxHelper.Alert(ErrorString);
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtWidth_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtHeight_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void rdoLandscape_CheckedChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void rdoLandscape2_CheckedChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtTopMargin_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtBottomMargin_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtLeftMargin_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtRightMargin_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtTopMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtBottomMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtLeftMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}

		private void txtRightMargin_KeyPress(object sender, KeyPressEventArgs e)
		{
			picPreview.Invalidate();
		}
	}
}
