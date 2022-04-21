using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	
	public class dlgRulerSettings : Form
	{
		/// <summary>
		///       Required designer variable.
		///       </summary>
		private IContainer components = null;

		private DataGridView dgvParameters;

		private Button btnOK;

		private Button btnCancel;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private ScalePropertyList _Scales = null;

		/// <summary>
		///       自定义的刻度信息列表
		///       </summary>
		[XmlArrayItem("Scale", typeof(ScaleProperty))]
		[Browsable(true)]
		[DefaultValue(null)]
		public ScalePropertyList Scales
		{
			get
			{
				if (_Scales == null)
				{
					_Scales = new ScalePropertyList();
				}
				return _Scales;
			}
			set
			{
				_Scales = value;
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
			dgvParameters = new System.Windows.Forms.DataGridView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvParameters).BeginInit();
			SuspendLayout();
			dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvParameters.Columns.AddRange(Column1, Column2);
			dgvParameters.Dock = System.Windows.Forms.DockStyle.Top;
			dgvParameters.Location = new System.Drawing.Point(0, 0);
			dgvParameters.Name = "dgvParameters";
			dgvParameters.RowTemplate.Height = 27;
			dgvParameters.Size = new System.Drawing.Size(358, 296);
			dgvParameters.TabIndex = 0;
			btnOK.Location = new System.Drawing.Point(52, 317);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 29);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(262, 319);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 29);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			Column1.HeaderText = "刻度值";
			Column1.Name = "Column1";
			Column2.HeaderText = "刻度位置";
			Column2.Name = "Column2";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(358, 357);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(dgvParameters);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgRulerSettings";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "dlgRulerSettings";
			base.Load += new System.EventHandler(dlgRulerSettings_Load);
			((System.ComponentModel.ISupportInitialize)dgvParameters).EndInit();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgRulerSettings()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in (IEnumerable)dgvParameters.Rows)
			{
				if (item.Index != dgvParameters.NewRowIndex)
				{
					ScaleProperty scaleProperty = new ScaleProperty();
					scaleProperty.Value = Convert.ToSingle(item.Cells[0].Value);
					scaleProperty.ScaleRate = Convert.ToSingle(item.Cells[1].Value);
					Scales.Add(scaleProperty);
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgRulerSettings_Load(object sender, EventArgs e)
		{
			if (_Scales != null && _Scales.Count > 1)
			{
				foreach (ScaleProperty scale in _Scales)
				{
					dgvParameters.Rows.Add(Convert.ToString(scale.Value), Convert.ToString(scale.ScaleRate));
				}
			}
		}
	}
}
