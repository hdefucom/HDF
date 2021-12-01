using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZYCommon
{
	public class dlgInputFormatText : Form
	{
		private Panel pnlTool;

		private ComboBox cboFont;

		private ComboBox cboFontSize;

		private CheckBox chkBold;

		private CheckBox chkItalic;

		private TextBox txtInput;

		private Button cmdOK;

		private Button cmdCancel;

		private Container components = null;

		public string InputFontName = "宋体";

		public float InputFontSize = 10f;

		public bool InputFontItalic = false;

		public bool InputFontBold = false;

		public string InputText = "";

		public dlgInputFormatText()
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
			pnlTool = new System.Windows.Forms.Panel();
			chkItalic = new System.Windows.Forms.CheckBox();
			chkBold = new System.Windows.Forms.CheckBox();
			cboFontSize = new System.Windows.Forms.ComboBox();
			cboFont = new System.Windows.Forms.ComboBox();
			txtInput = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			pnlTool.SuspendLayout();
			SuspendLayout();
			pnlTool.Controls.Add(chkItalic);
			pnlTool.Controls.Add(chkBold);
			pnlTool.Controls.Add(cboFontSize);
			pnlTool.Controls.Add(cboFont);
			pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
			pnlTool.Location = new System.Drawing.Point(0, 0);
			pnlTool.Name = "pnlTool";
			pnlTool.Size = new System.Drawing.Size(442, 32);
			pnlTool.TabIndex = 0;
			chkItalic.Location = new System.Drawing.Point(296, 2);
			chkItalic.Name = "chkItalic";
			chkItalic.Size = new System.Drawing.Size(72, 24);
			chkItalic.TabIndex = 3;
			chkItalic.Text = "斜体";
			chkItalic.CheckedChanged += new System.EventHandler(chkItalic_CheckedChanged);
			chkBold.Location = new System.Drawing.Point(216, 2);
			chkBold.Name = "chkBold";
			chkBold.Size = new System.Drawing.Size(64, 24);
			chkBold.TabIndex = 2;
			chkBold.Text = "粗体";
			chkBold.CheckedChanged += new System.EventHandler(chkBold_CheckedChanged);
			cboFontSize.Location = new System.Drawing.Point(160, 4);
			cboFontSize.MaxDropDownItems = 20;
			cboFontSize.Name = "cboFontSize";
			cboFontSize.Size = new System.Drawing.Size(48, 20);
			cboFontSize.TabIndex = 1;
			cboFontSize.Text = "10";
			cboFontSize.SelectedIndexChanged += new System.EventHandler(cboFontSize_SelectedIndexChanged);
			cboFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboFont.Location = new System.Drawing.Point(8, 4);
			cboFont.MaxDropDownItems = 20;
			cboFont.Name = "cboFont";
			cboFont.Size = new System.Drawing.Size(144, 20);
			cboFont.TabIndex = 0;
			cboFont.SelectedIndexChanged += new System.EventHandler(cboFont_SelectedIndexChanged);
			txtInput.Location = new System.Drawing.Point(0, 32);
			txtInput.Multiline = true;
			txtInput.Name = "txtInput";
			txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtInput.Size = new System.Drawing.Size(440, 224);
			txtInput.TabIndex = 1;
			txtInput.Text = "";
			txtInput.WordWrap = false;
			cmdOK.Location = new System.Drawing.Point(280, 266);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 2;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdCancel.Location = new System.Drawing.Point(360, 266);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.CancelButton = cmdCancel;
			base.ClientSize = new System.Drawing.Size(442, 295);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtInput);
			base.Controls.Add(pnlTool);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputFormatText";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "输入格式化的文本";
			base.Load += new System.EventHandler(dlgInputFormatText_Load);
			pnlTool.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			InputFontName = cboFont.Text;
			InputFontSize = Convert.ToSingle(cboFontSize.Text);
			InputFontItalic = chkItalic.Checked;
			InputFontBold = chkBold.Checked;
			InputText = txtInput.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void dlgInputFormatText_Load(object sender, EventArgs e)
		{
			FontFamily[] families = FontFamily.Families;
			foreach (FontFamily fontFamily in families)
			{
				cboFont.Items.Add(fontFamily.Name);
				if (fontFamily.Name == InputFontName)
				{
					cboFont.SelectedIndex = cboFont.Items.Count - 1;
				}
			}
			cboFontSize.Items.AddRange(new string[16]
			{
				"8",
				"9",
				"10",
				"11",
				"12",
				"14",
				"16",
				"18",
				"20",
				"22",
				"24",
				"26",
				"28",
				"36",
				"48",
				"72"
			});
			cboFontSize.Text = InputFontSize.ToString();
			chkBold.Checked = InputFontBold;
			chkItalic.Checked = InputFontItalic;
			txtInput.Text = InputText;
			txtInput.Select();
		}

		private void ApplyFont()
		{
			txtInput.Font = new Font(cboFont.Text, Convert.ToSingle(cboFontSize.Text), DocumentView.GetFontStyle(chkBold.Checked, chkItalic.Checked, UnderLine: false));
		}

		private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
		{
			ApplyFont();
		}

		private void cboFontSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			ApplyFont();
		}

		private void chkBold_CheckedChanged(object sender, EventArgs e)
		{
			ApplyFont();
		}

		private void chkItalic_CheckedChanged(object sender, EventArgs e)
		{
			ApplyFont();
		}
	}
}
