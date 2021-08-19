using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class frmScript : Form
	{
		private Button cmdOK;

		private TextBox txtScript;

		private Button cmdCancel;

		private Button cmdRunPWD;

		private Button cmdEditPWD;

		public ZYVBScriptElement ScriptObj = null;

		private Button cmdLoadFile;

		private Button cmdSaveFile;

		private ToolTip toolTip1;

		private Button cmdCompile;

		private Panel panel1;

		private ListBox lstValues;

		private Splitter splValues;

		private CheckBox chkValues;

		private Button cmdAddValue;

		private Button cmdDeleteValue;

		private Panel pnlValues;

		private IContainer components;

		public frmScript()
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
			components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(ZYTextDocumentLib.frmScript));
			cmdOK = new System.Windows.Forms.Button();
			txtScript = new System.Windows.Forms.TextBox();
			cmdCancel = new System.Windows.Forms.Button();
			cmdRunPWD = new System.Windows.Forms.Button();
			cmdEditPWD = new System.Windows.Forms.Button();
			cmdLoadFile = new System.Windows.Forms.Button();
			cmdSaveFile = new System.Windows.Forms.Button();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			cmdCompile = new System.Windows.Forms.Button();
			lstValues = new System.Windows.Forms.ListBox();
			panel1 = new System.Windows.Forms.Panel();
			chkValues = new System.Windows.Forms.CheckBox();
			splValues = new System.Windows.Forms.Splitter();
			pnlValues = new System.Windows.Forms.Panel();
			cmdDeleteValue = new System.Windows.Forms.Button();
			cmdAddValue = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			pnlValues.SuspendLayout();
			SuspendLayout();
			cmdOK.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			cmdOK.Location = new System.Drawing.Point(376, 5);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 11;
			cmdOK.Text = "确定(&O)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			txtScript.AcceptsReturn = true;
			txtScript.AcceptsTab = true;
			txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
			txtScript.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtScript.HideSelection = false;
			txtScript.Location = new System.Drawing.Point(229, 32);
			txtScript.Multiline = true;
			txtScript.Name = "txtScript";
			txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtScript.Size = new System.Drawing.Size(307, 341);
			txtScript.TabIndex = 1;
			txtScript.Text = "";
			txtScript.WordWrap = false;
			cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			cmdCancel.Location = new System.Drawing.Point(456, 5);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.TabIndex = 12;
			cmdCancel.Text = "取消(&C)";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			cmdRunPWD.Location = new System.Drawing.Point(8, 5);
			cmdRunPWD.Name = "cmdRunPWD";
			cmdRunPWD.Size = new System.Drawing.Size(88, 23);
			cmdRunPWD.TabIndex = 2;
			cmdRunPWD.Text = "修改运行密码";
			cmdRunPWD.Click += new System.EventHandler(cmdRunPWD_Click);
			cmdEditPWD.Location = new System.Drawing.Point(96, 5);
			cmdEditPWD.Name = "cmdEditPWD";
			cmdEditPWD.Size = new System.Drawing.Size(88, 23);
			cmdEditPWD.TabIndex = 3;
			cmdEditPWD.Text = "修改编辑密码";
			cmdEditPWD.Click += new System.EventHandler(cmdEditPWD_Click);
			cmdLoadFile.Image = (System.Drawing.Image)resourceManager.GetObject("cmdLoadFile.Image");
			cmdLoadFile.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdLoadFile.Location = new System.Drawing.Point(184, 5);
			cmdLoadFile.Name = "cmdLoadFile";
			cmdLoadFile.Size = new System.Drawing.Size(28, 23);
			cmdLoadFile.TabIndex = 4;
			toolTip1.SetToolTip(cmdLoadFile, "加载脚本文件");
			cmdLoadFile.Click += new System.EventHandler(cmdLoadFile_Click);
			cmdSaveFile.Image = (System.Drawing.Image)resourceManager.GetObject("cmdSaveFile.Image");
			cmdSaveFile.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdSaveFile.Location = new System.Drawing.Point(212, 5);
			cmdSaveFile.Name = "cmdSaveFile";
			cmdSaveFile.Size = new System.Drawing.Size(28, 23);
			cmdSaveFile.TabIndex = 5;
			toolTip1.SetToolTip(cmdSaveFile, "保存脚本文件");
			cmdSaveFile.Click += new System.EventHandler(cmdSaveFile_Click);
			cmdCompile.Image = (System.Drawing.Image)resourceManager.GetObject("cmdCompile.Image");
			cmdCompile.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			cmdCompile.Location = new System.Drawing.Point(240, 5);
			cmdCompile.Name = "cmdCompile";
			cmdCompile.Size = new System.Drawing.Size(28, 23);
			cmdCompile.TabIndex = 6;
			toolTip1.SetToolTip(cmdCompile, "编译");
			cmdCompile.Click += new System.EventHandler(cmdCompile_Click);
			lstValues.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			lstValues.ItemHeight = 12;
			lstValues.Location = new System.Drawing.Point(0, 33);
			lstValues.Name = "lstValues";
			lstValues.Size = new System.Drawing.Size(220, 304);
			lstValues.TabIndex = 10;
			toolTip1.SetToolTip(lstValues, "双击列表在文本框中插入变量名");
			lstValues.DoubleClick += new System.EventHandler(lstValues_DoubleClick);
			panel1.Controls.Add(chkValues);
			panel1.Controls.Add(cmdSaveFile);
			panel1.Controls.Add(cmdCompile);
			panel1.Controls.Add(cmdCancel);
			panel1.Controls.Add(cmdRunPWD);
			panel1.Controls.Add(cmdEditPWD);
			panel1.Controls.Add(cmdLoadFile);
			panel1.Controls.Add(cmdOK);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(536, 32);
			panel1.TabIndex = 6;
			chkValues.Appearance = System.Windows.Forms.Appearance.Button;
			chkValues.Location = new System.Drawing.Point(268, 5);
			chkValues.Name = "chkValues";
			chkValues.Size = new System.Drawing.Size(88, 23);
			chkValues.TabIndex = 7;
			chkValues.Text = "显示变量列表";
			chkValues.CheckedChanged += new System.EventHandler(chkValues_CheckedChanged);
			splValues.Location = new System.Drawing.Point(224, 32);
			splValues.Name = "splValues";
			splValues.Size = new System.Drawing.Size(5, 341);
			splValues.TabIndex = 8;
			splValues.TabStop = false;
			splValues.Visible = false;
			pnlValues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			pnlValues.Controls.Add(cmdDeleteValue);
			pnlValues.Controls.Add(cmdAddValue);
			pnlValues.Controls.Add(lstValues);
			pnlValues.Dock = System.Windows.Forms.DockStyle.Left;
			pnlValues.Location = new System.Drawing.Point(0, 32);
			pnlValues.Name = "pnlValues";
			pnlValues.Size = new System.Drawing.Size(224, 341);
			pnlValues.TabIndex = 11;
			pnlValues.Visible = false;
			cmdDeleteValue.Location = new System.Drawing.Point(80, 6);
			cmdDeleteValue.Name = "cmdDeleteValue";
			cmdDeleteValue.TabIndex = 9;
			cmdDeleteValue.Text = "删除变量";
			cmdDeleteValue.Click += new System.EventHandler(cmdDeleteValue_Click);
			cmdAddValue.Location = new System.Drawing.Point(0, 6);
			cmdAddValue.Name = "cmdAddValue";
			cmdAddValue.TabIndex = 8;
			cmdAddValue.Text = "添加变量";
			cmdAddValue.Click += new System.EventHandler(cmdAddValue_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(536, 373);
			base.Controls.Add(txtScript);
			base.Controls.Add(splValues);
			base.Controls.Add(pnlValues);
			base.Controls.Add(panel1);
			base.Icon = (System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.MinimizeBox = false;
			base.Name = "frmScript";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "脚本编写";
			base.Load += new System.EventHandler(frmScript_Load);
			panel1.ResumeLayout(false);
			pnlValues.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void frmScript_Load(object sender, EventArgs e)
		{
			if (ScriptObj != null)
			{
				txtScript.Text = ScriptObj.SourceCode;
				for (int i = 0; i < ScriptObj.OwnerDocument.Variables.Count; i++)
				{
					lstValues.Items.Add(ScriptObj.OwnerDocument.Variables.GetName(i));
				}
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			if (ScriptObj != null)
			{
				ScriptObj.SourceCode = txtScript.Text;
			}
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void cmdRunPWD_Click(object sender, EventArgs e)
		{
			if (ScriptObj != null)
			{
				string text = dlgChangePWD.ChangePWD("修改启动代码密码", ScriptObj.CheckRunPWD);
				if (text != null)
				{
					ScriptObj.RunPWD = text;
				}
			}
		}

		private void cmdEditPWD_Click(object sender, EventArgs e)
		{
			if (ScriptObj != null)
			{
				string text = dlgChangePWD.ChangePWD("修改编辑代码密码", ScriptObj.CheckEditPWD);
				if (text != null)
				{
					ScriptObj.EditPWD = text;
				}
			}
		}

		private void cmdLoadFile_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(936));
					txtScript.Text = streamReader.ReadToEnd();
					streamReader.Close();
				}
			}
		}

		private void cmdSaveFile_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, append: false, Encoding.GetEncoding(936));
					streamWriter.Write(txtScript.Text);
					streamWriter.Close();
				}
			}
		}

		private void cmdCompile_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				ZYVBScriptEngine zYVBScriptEngine = new ZYVBScriptEngine();
				zYVBScriptEngine.ScriptText = ScriptObj.ConvertToRunTimeScript(txtScript.Text);
				if (zYVBScriptEngine.CompileEMRVB())
				{
					MessageBox.Show(this, "编译通过!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				zYVBScriptEngine.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "编译时发生错误\r\n" + ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			Cursor = Cursors.Default;
		}

		private void lstValues_DoubleClick(object sender, EventArgs e)
		{
			txtScript.SelectedText = "[" + lstValues.Text + "]";
		}

		private void chkValues_CheckedChanged(object sender, EventArgs e)
		{
			splValues.Visible = chkValues.Checked;
			pnlValues.Visible = chkValues.Checked;
		}

		private void cmdAddValue_Click(object sender, EventArgs e)
		{
			string[] array = dlgInputBox2.InputBox2("新增变量", "变量名称(不得为空且不得和已有变量名重复)", "变量值", "", "", CheckNewValueName, null);
			if (array != null)
			{
				ScriptObj.OwnerDocument.Variables.SetValue(array[0], array[1]);
				lstValues.Items.Add(array[0]);
			}
		}

		private bool CheckNewValueName(string strName)
		{
			if (StringCommon.isBlankString(strName))
			{
				return false;
			}
			if (ScriptObj.OwnerDocument.Variables.Contains(strName))
			{
				return false;
			}
			return true;
		}

		private void cmdDeleteValue_Click(object sender, EventArgs e)
		{
			if (lstValues.SelectedIndex >= 0)
			{
				ScriptObj.OwnerDocument.Variables.Remove(lstValues.Text);
				lstValues.Items.RemoveAt(lstValues.SelectedIndex);
			}
		}
	}
}
