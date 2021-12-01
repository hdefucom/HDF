using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Common;

namespace ZYCommon
{
	/// <summary>
	/// dlgInputFormatText 的摘要说明。
	/// </summary>
	public class dlgInputFormatText : System.Windows.Forms.Form
    {
		private System.Windows.Forms.ComboBox cboFont;
		private System.Windows.Forms.ComboBox cboFontSize;
		private System.Windows.Forms.CheckBox chkBold;
		private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.TextBox txtInput;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.PanelControl panelControl2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dlgInputFormatText()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel ;
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.cboFontSize = new System.Windows.Forms.ComboBox();
            this.cboFont = new System.Windows.Forms.ComboBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkItalic
            // 
            this.chkItalic.Location = new System.Drawing.Point(294, 5);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(72, 24);
            this.chkItalic.TabIndex = 3;
            this.chkItalic.Text = "斜体";
            this.chkItalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);
            // 
            // chkBold
            // 
            this.chkBold.Location = new System.Drawing.Point(221, 5);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(64, 24);
            this.chkBold.TabIndex = 2;
            this.chkBold.Text = "粗体";
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // cboFontSize
            // 
            this.cboFontSize.Location = new System.Drawing.Point(165, 5);
            this.cboFontSize.MaxDropDownItems = 20;
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size(48, 20);
            this.cboFontSize.TabIndex = 1;
            this.cboFontSize.Text = "10";
            this.cboFontSize.SelectedIndexChanged += new System.EventHandler(this.cboFontSize_SelectedIndexChanged);
            // 
            // cboFont
            // 
            this.cboFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFont.Location = new System.Drawing.Point(5, 5);
            this.cboFont.MaxDropDownItems = 20;
            this.cboFont.Name = "cboFont";
            this.cboFont.Size = new System.Drawing.Size(144, 20);
            this.cboFont.TabIndex = 0;
            this.cboFont.SelectedIndexChanged += new System.EventHandler(this.cboFont_SelectedIndexChanged);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(0, 32);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(440, 224);
            this.txtInput.TabIndex = 1;
            this.txtInput.WordWrap = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmdCancel);
            this.panelControl1.Controls.Add(this.cmdOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 251);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(442, 44);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chkItalic);
            this.panelControl2.Controls.Add(this.chkBold);
            this.panelControl2.Controls.Add(this.cboFont);
            this.panelControl2.Controls.Add(this.cboFontSize);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(442, 32);
            this.panelControl2.TabIndex = 5;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(251, 13);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "确定(&O)";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(343, 13);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "取消(&C)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dlgInputFormatText
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(442, 295);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgInputFormatText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入格式化的文本";
            this.Load += new System.EventHandler(this.dlgInputFormatText_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public string	InputFontName	= "宋体";
		public float	InputFontSize	= 10 ;
		public bool		InputFontItalic	= false;
		public bool		InputFontBold	= false;
		public string	InputText		= "";

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			InputFontName	= this.cboFont.Text ;
			InputFontSize	= Convert.ToSingle( this.cboFontSize.Text );
			InputFontItalic	= this.chkItalic.Checked ;
			InputFontBold	= this.chkBold.Checked ;
			InputText	= this.txtInput.Text ;
			this.DialogResult = System.Windows.Forms.DialogResult.OK ;
			this.Close();
		}
		private void dlgInputFormatText_Load(object sender, System.EventArgs e)
		{
			foreach( System.Drawing.FontFamily f in System.Drawing.FontFamily.Families)
			{
				this.cboFont.Items.Add( f.Name );
				if( f.Name == InputFontName )
					this.cboFont.SelectedIndex = cboFont.Items.Count -1 ;
			}
			cboFontSize.Items.AddRange( new string[]{"8" ,"9" ,"10","11","12","14","16","18","20","22","24","26","28","36","48","72"});
			cboFontSize.Text	= InputFontSize.ToString();
			chkBold.Checked		= InputFontBold ;
			chkItalic.Checked	= InputFontItalic ;
			txtInput.Text		= InputText ;
			txtInput.Select();
		}

		private void ApplyFont()
		{
			this.txtInput.Font = new System.Drawing.Font(
				cboFont.Text ,
				Convert.ToSingle( this.cboFontSize.Text ) , 
				DocumentView.GetFontStyle( this.chkBold.Checked ,this.chkItalic.Checked , false));
		}
		private void cboFont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ApplyFont();
		}

		private void cboFontSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ApplyFont();
		}

		private void chkBold_CheckedChanged(object sender, System.EventArgs e)
		{
			ApplyFont();
		}

		private void chkItalic_CheckedChanged(object sender, System.EventArgs e)
		{
			ApplyFont();
		}

	}
}
