using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Data
{
	[ComVisible(false)]
	public class dlgParameterProvider : Form
	{
		private IParameterProvider _InputParameters = null;

		                                                                    /// <summary>
		                                                                    ///       Required designer variable.
		                                                                    ///       </summary>
		private IContainer components = null;

		private PropertyGrid propertyGrid1;

		private Button btnClose;

		public IParameterProvider InputParameters
		{
			get
			{
				return _InputParameters;
			}
			set
			{
				_InputParameters = value;
			}
		}

		public dlgParameterProvider()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgParameterProvider_Load(object sender, EventArgs e)
		{
			if (InputParameters != null)
			{
				propertyGrid1.SelectedObject = new ParameterProviderPackage(InputParameters);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       Clean up any resources being used.
		                                                                    ///       </summary>
		                                                                    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		                                                                    /// <summary>
		                                                                    ///       Required method for Designer support - do not modify
		                                                                    ///       the contents of this method with the code editor.
		                                                                    ///       </summary>
		private void InitializeComponent()
		{
			propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			btnClose = new System.Windows.Forms.Button();
			SuspendLayout();
			propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
			propertyGrid1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			propertyGrid1.Location = new System.Drawing.Point(0, 0);
			propertyGrid1.Name = "propertyGrid1";
			propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			propertyGrid1.SelectedObject = btnClose;
			propertyGrid1.Size = new System.Drawing.Size(390, 364);
			propertyGrid1.TabIndex = 0;
			propertyGrid1.ToolbarVisible = false;
			btnClose.Location = new System.Drawing.Point(274, 376);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(75, 23);
			btnClose.TabIndex = 1;
			btnClose.Text = "确定(&O)";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(390, 410);
			base.Controls.Add(btnClose);
			base.Controls.Add(propertyGrid1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgParameterProvider";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "输入参数";
			base.Load += new System.EventHandler(dlgParameterProvider_Load);
			ResumeLayout(false);
		}
	}
}
