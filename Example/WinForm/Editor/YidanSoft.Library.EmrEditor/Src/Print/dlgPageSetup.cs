using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Print;
using XDesignerCommon;
using YiDanCommon.YiDanService;


namespace XDesignerPrinting
{
	/// <summary>
	/// 页面设置对话框
	/// </summary>
	public class dlgPageSetup : System.Windows.Forms.Form 
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown txtTopMargin;
		private System.Windows.Forms.NumericUpDown txtBottomMargin;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown txtLeftMargin;
		private System.Windows.Forms.NumericUpDown txtRightMargin;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.ComboBox cboPage;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox picPreview;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rdoLandscape;
		private System.Windows.Forms.RadioButton rdoLandscape2;
		private System.Windows.Forms.NumericUpDown txtWidth;
		private System.Windows.Forms.NumericUpDown txtHeight;
        private Button btnSetDefault;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dlgPageSetup()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPageSetup));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoLandscape = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoLandscape2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTopMargin = new System.Windows.Forms.NumericUpDown();
            this.txtLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBottomMargin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRightMargin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPage = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottomMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRightMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoLandscape);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rdoLandscape2);
            this.groupBox2.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rdoLandscape
            // 
            resources.ApplyResources(this.rdoLandscape, "rdoLandscape");
            this.rdoLandscape.BackColor = System.Drawing.SystemColors.Control;
            this.rdoLandscape.Name = "rdoLandscape";
            this.rdoLandscape.UseVisualStyleBackColor = false;
            this.rdoLandscape.CheckedChanged += new System.EventHandler(this.rdoLandscape_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // rdoLandscape2
            // 
            resources.ApplyResources(this.rdoLandscape2, "rdoLandscape2");
            this.rdoLandscape2.BackColor = System.Drawing.SystemColors.Control;
            this.rdoLandscape2.Name = "rdoLandscape2";
            this.rdoLandscape2.UseVisualStyleBackColor = false;
            this.rdoLandscape2.CheckedChanged += new System.EventHandler(this.rdoLandscape2_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTopMargin);
            this.groupBox1.Controls.Add(this.txtLeftMargin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBottomMargin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRightMargin);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtTopMargin
            // 
            resources.ApplyResources(this.txtTopMargin, "txtTopMargin");
            this.txtTopMargin.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.txtTopMargin.Name = "txtTopMargin";
            this.txtTopMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTopMargin.ValueChanged += new System.EventHandler(this.txtTopMargin_ValueChanged);
            this.txtTopMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTopMargin_KeyPress);
            // 
            // txtLeftMargin
            // 
            resources.ApplyResources(this.txtLeftMargin, "txtLeftMargin");
            this.txtLeftMargin.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.txtLeftMargin.Name = "txtLeftMargin";
            this.txtLeftMargin.ValueChanged += new System.EventHandler(this.txtLeftMargin_ValueChanged);
            this.txtLeftMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLeftMargin_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtBottomMargin
            // 
            resources.ApplyResources(this.txtBottomMargin, "txtBottomMargin");
            this.txtBottomMargin.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.txtBottomMargin.Name = "txtBottomMargin";
            this.txtBottomMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtBottomMargin.ValueChanged += new System.EventHandler(this.txtBottomMargin_ValueChanged);
            this.txtBottomMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBottomMargin_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtRightMargin
            // 
            resources.ApplyResources(this.txtRightMargin, "txtRightMargin");
            this.txtRightMargin.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.txtRightMargin.Name = "txtRightMargin";
            this.txtRightMargin.ValueChanged += new System.EventHandler(this.txtRightMargin_ValueChanged);
            this.txtRightMargin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRightMargin_KeyPress);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtWidth
            // 
            resources.ApplyResources(this.txtWidth, "txtWidth");
            this.txtWidth.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ValueChanged += new System.EventHandler(this.txtWidth_ValueChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cboPage
            // 
            this.cboPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboPage, "cboPage");
            this.cboPage.Name = "cboPage";
            this.cboPage.SelectedIndexChanged += new System.EventHandler(this.cboPage_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtHeight
            // 
            resources.ApplyResources(this.txtHeight, "txtHeight");
            this.txtHeight.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtHeight.ValueChanged += new System.EventHandler(this.txtHeight_ValueChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picPreview);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.picPreview, "picPreview");
            this.picPreview.Name = "picPreview";
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // cmdOK
            // 
            resources.ApplyResources(this.cmdOK, "cmdOK");
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnSetDefault
            // 
            resources.ApplyResources(this.btnSetDefault, "btnSetDefault");
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // dlgPageSetup
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnSetDefault);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboPage);
            this.Controls.Add(this.txtHeight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPageSetup";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.dlgPageSetup_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottomMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRightMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		internal string ErrorString = "Paget setting error";
		private XPageSettings myPageSettings = new XPageSettings();
		/// <summary>
		/// 页面设置对象
		/// </summary>
		public XPageSettings PageSettings
		{
			get{ return myPageSettings ;}
			set{ myPageSettings = value;}
		}
		public void dlgPageSetup_Load(object sender, System.EventArgs e)
		{
			this.cboPage.Items.Clear();
			this.cboPage.Items.AddRange( XPaperSizeCollection.StdInstance.ToArray());

			if( myPageSettings != null )
			{
				for(int iCount = 0 ; iCount < cboPage.Items.Count ; iCount ++ )
				{
					XPaperSize p = ( XPaperSize ) cboPage.Items[ iCount ] ;
					if( p.Kind == myPageSettings.PaperSize.Kind )
					{
						cboPage.SelectedIndex = iCount ;
						break;
					}
				}

				this.txtWidth.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( myPageSettings.PaperSize.Width ));
				this.txtHeight.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( myPageSettings.PaperSize.Height ));
				this.txtLeftMargin.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( myPageSettings.Margins.Left ));
				this.txtTopMargin.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( myPageSettings.Margins.Top  ));
				this.txtRightMargin.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( myPageSettings.Margins.Right ));
				this.txtBottomMargin.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( myPageSettings.Margins.Bottom ));
                 // xll  删除查询医院sql语句
                 if ( YD_SqlService.GetHospitalName().Contains("九江"))
                 {
                     this.txtLeftMargin.Value = 10;
                     this.txtTopMargin.Value = 20;
                     this.txtRightMargin.Value =10;
                     this.txtBottomMargin.Value = 15;
                 } 

			    if (YD_SqlService.GetHospitalName().Contains("玉山"))
			    {
                    this.txtLeftMargin.Value = 15;
			        this.txtTopMargin.Value = 20;
                    this.txtRightMargin.Value = 15;
			        this.txtBottomMargin.Value = 15;
			    }
				this.rdoLandscape.Checked = ! myPageSettings.Landscape ;
				this.rdoLandscape2.Checked = myPageSettings.Landscape ;
			}
			//this.cboPage.Items.AddRange( mySetting.PaperSizes );
		}

		private bool RefreshPageSettings()
		{
			if( myPageSettings != null )
			{
				XPaperSize Size = this.cboPage.SelectedItem as XPaperSize ;
				if( Size != null )
				{
					myPageSettings.PaperSize = Size ;
				}
				if( Size == null || myPageSettings.PaperSize.Kind == System.Drawing.Printing.PaperKind.Custom )
				{
					int vWidth = (int) ( MeasureConvert.MillimeterToHundredthsInch( Convert.ToDouble( this.txtWidth.Value) ) );
					int vHeight = (int) ( MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble(this.txtHeight.Value) ));
					myPageSettings.PaperSize = new XPaperSize( System.Drawing.Printing.PaperKind.Custom , vWidth , vHeight );
				}


				myPageSettings.Margins.Left = (int) MeasureConvert.MillimeterToHundredthsInch( Convert.ToDouble(this.txtLeftMargin.Value ));
				myPageSettings.Margins.Top  = (int) MeasureConvert.MillimeterToHundredthsInch(Convert.ToDouble( this.txtTopMargin.Value ));
				myPageSettings.Margins.Right = (int) MeasureConvert.MillimeterToHundredthsInch( Convert.ToDouble(this.txtRightMargin.Value ));
				myPageSettings.Margins.Bottom = (int) MeasureConvert.MillimeterToHundredthsInch( Convert.ToDouble(this.txtBottomMargin.Value) );
				myPageSettings.Landscape = this.rdoLandscape2.Checked ;
				return true ;
			}
			else
				return false;
		}

		private void picPreview_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if( RefreshPageSettings() == false )
			{
				using( System.Drawing.StringFormat f = new StringFormat())
				{
					f.Alignment = System.Drawing.StringAlignment.Center ;
					f.LineAlignment = System.Drawing.StringAlignment.Center ;
					e.Graphics.DrawString( ErrorString , this.Font , System.Drawing.Brushes.Red , new System.Drawing.RectangleF( 0 , 0 , picPreview.Width , picPreview.Height ) , f );
				}
				return ;
			}
			XDesignerGUI.PageSettingPreview myPreview = new XDesignerGUI.PageSettingPreview();
			myPreview.Landscape = myPageSettings.Landscape ;
			myPreview.Margins = myPageSettings.Margins ;
			myPreview.PaperSize = myPageSettings.PaperSize.StdSize ; 
			myPreview.Bounds = this.picPreview.ClientRectangle ;
			myPreview.OnPaint( sender , e );
		}

		private void cboPage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			XPaperSize mySize = this.cboPage.SelectedItem as XPaperSize ;
			if( mySize != null )
			{
				this.txtWidth.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( mySize.Width ));
				this.txtHeight.Value = Convert.ToDecimal( MeasureConvert.HundredthsInchToMillimeter( mySize.Height ));
                //this.txtWidth.ReadOnly = !( mySize.Kind == System.Drawing.Printing.PaperKind.Custom );
                //this.txtHeight.ReadOnly = !( mySize.Kind == System.Drawing.Printing.PaperKind.Custom ) ;
                this.txtWidth.Enabled = (mySize.Kind == System.Drawing.Printing.PaperKind.Custom);
                this.txtHeight.Enabled = (mySize.Kind == System.Drawing.Printing.PaperKind.Custom);
                
				this.picPreview.Invalidate();
			}
		}

		public void cmdOK_Click(object sender, System.EventArgs e)
		{
			if( this.RefreshPageSettings())
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK ;
				this.Close();
                
			}
			else
				XDesignerGUI.MessageBoxHelper.Alert( ErrorString );
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txtWidth_ValueChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtHeight_ValueChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void rdoLandscape_CheckedChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void rdoLandscape2_CheckedChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtTopMargin_ValueChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtBottomMargin_ValueChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtLeftMargin_ValueChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtRightMargin_ValueChanged(object sender, System.EventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtTopMargin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtBottomMargin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtLeftMargin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			this.picPreview.Invalidate();
		}

		private void txtRightMargin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			this.picPreview.Invalidate();
		}

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否要把当前的选项设置为默认配置? ","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            //RegistryKey key = Registry.LocalMachine;
            //RegistryKey software = key.CreateSubKey("software\\tphyemreditor");

            //纸张类型
            //todo 写入xml 周辉
            //software.SetValue("paperkind", this.cboPage.Text);
            //software.SetValue("width", this.txtWidth.Value);
            //software.SetValue("height", this.txtHeight.Value);
            //software.SetValue("aspect", rdoLandscape2.Checked);
            //software.SetValue("topmargin", this.txtTopMargin.Value);
            //software.SetValue("bottommargin", this.txtBottomMargin.Value);
            //software.SetValue("leftmargin", this.txtLeftMargin.Value);
            //software.SetValue("rightmargin", this.txtRightMargin.Value);
            //key.Close();
        }
	}//public class dlgPageSetup : System.Windows.Forms.Form
}