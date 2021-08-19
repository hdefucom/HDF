using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class dlgNumBox : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private Label label2;

		private Label label3;

		private NumericUpDown nudMaxValue;

		private NumericUpDown nudMinValue;

		private NumericUpDown nudPrecision;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private CheckBox chkUnDelete;

		private CheckBox chkEncrypt;

		private CheckBox chkReverseEdit;

		private CheckBox chkRequired;

		private CheckBox chkHidden;

		private CheckBox chkHiddenBorderLine;

		private CheckBox chkNoGenerationXML;

		private CheckBox chkUnEditable;

		private TextBox txtName;

		private TextBox txtPlaceholder;

		private TextBox txtTitle;

		private TextBox txtNnit;

		private Button btnOK;

		private Button btnCancle;

		private GroupBox grpConventional;

		private GroupBox grpLock;

		private GroupBox grpIntrinsicProperties;

		private bool bool_0 = true;

		private XTextInputFieldElement xtextInputFieldElement_0 = null;

		                                                                    /// <summary>
		                                                                    ///       填充NSO属性
		                                                                    ///       </summary>
		public bool FillNsoProperties
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       输入域对象
		                                                                    ///       </summary>
		public XTextInputFieldElement InputFieldElement
		{
			get
			{
				return xtextInputFieldElement_0;
			}
			set
			{
				xtextInputFieldElement_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       Clean up any resources being used.
		                                                                    ///       </summary>
		                                                                    /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		                                                                    /// <summary>
		                                                                    ///       Required method for Designer support - do not modify
		                                                                    ///       the contents of this method with the code editor.
		                                                                    ///       </summary>
		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			nudMaxValue = new System.Windows.Forms.NumericUpDown();
			nudMinValue = new System.Windows.Forms.NumericUpDown();
			nudPrecision = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			chkUnDelete = new System.Windows.Forms.CheckBox();
			chkEncrypt = new System.Windows.Forms.CheckBox();
			chkReverseEdit = new System.Windows.Forms.CheckBox();
			chkRequired = new System.Windows.Forms.CheckBox();
			chkHidden = new System.Windows.Forms.CheckBox();
			chkHiddenBorderLine = new System.Windows.Forms.CheckBox();
			chkNoGenerationXML = new System.Windows.Forms.CheckBox();
			chkUnEditable = new System.Windows.Forms.CheckBox();
			txtName = new System.Windows.Forms.TextBox();
			txtPlaceholder = new System.Windows.Forms.TextBox();
			txtTitle = new System.Windows.Forms.TextBox();
			txtNnit = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancle = new System.Windows.Forms.Button();
			grpConventional = new System.Windows.Forms.GroupBox();
			grpLock = new System.Windows.Forms.GroupBox();
			grpIntrinsicProperties = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)nudMaxValue).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudMinValue).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudPrecision).BeginInit();
			grpConventional.SuspendLayout();
			grpLock.SuspendLayout();
			grpIntrinsicProperties.SuspendLayout();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(47, 12);
			label1.TabIndex = 0;
			label1.Text = "名称(&I)";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 12);
			label2.TabIndex = 2;
			label2.Text = "标题(&T)";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(13, 75);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(83, 12);
			label3.TabIndex = 4;
			label3.Text = "提示占位符(&H)";
			nudMaxValue.Location = new System.Drawing.Point(75, 24);
			nudMaxValue.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			nudMaxValue.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			nudMaxValue.Name = "nudMaxValue";
			nudMaxValue.Size = new System.Drawing.Size(66, 21);
			nudMaxValue.TabIndex = 1;
			nudMinValue.Location = new System.Drawing.Point(217, 24);
			nudMinValue.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			nudMinValue.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			nudMinValue.Name = "nudMinValue";
			nudMinValue.Size = new System.Drawing.Size(66, 21);
			nudMinValue.TabIndex = 3;
			nudPrecision.Location = new System.Drawing.Point(75, 56);
			nudPrecision.Name = "nudPrecision";
			nudPrecision.Size = new System.Drawing.Size(66, 21);
			nudPrecision.TabIndex = 5;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(13, 28);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(59, 12);
			label4.TabIndex = 0;
			label4.Text = "最大值(&J)";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(152, 28);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(59, 12);
			label5.TabIndex = 2;
			label5.Text = "最小值(&K)";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(152, 60);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(47, 12);
			label6.TabIndex = 6;
			label6.Text = "单位(&N)";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(13, 60);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(47, 12);
			label7.TabIndex = 4;
			label7.Text = "精度(&M)";
			chkUnDelete.AutoSize = true;
			chkUnDelete.Location = new System.Drawing.Point(18, 20);
			chkUnDelete.Name = "chkUnDelete";
			chkUnDelete.Size = new System.Drawing.Size(126, 16);
			chkUnDelete.TabIndex = 0;
			chkUnDelete.Text = "无法删除数据元(&D)";
			chkUnDelete.UseVisualStyleBackColor = true;
			chkEncrypt.AutoSize = true;
			chkEncrypt.Location = new System.Drawing.Point(175, 64);
			chkEncrypt.Name = "chkEncrypt";
			chkEncrypt.Size = new System.Drawing.Size(90, 16);
			chkEncrypt.TabIndex = 5;
			chkEncrypt.Text = "保密显示(&S)";
			chkEncrypt.UseVisualStyleBackColor = true;
			chkReverseEdit.AutoSize = true;
			chkReverseEdit.Location = new System.Drawing.Point(175, 86);
			chkReverseEdit.Name = "chkReverseEdit";
			chkReverseEdit.Size = new System.Drawing.Size(90, 16);
			chkReverseEdit.TabIndex = 7;
			chkReverseEdit.Text = "反向编辑(&F)";
			chkReverseEdit.UseVisualStyleBackColor = true;
			chkRequired.AutoSize = true;
			chkRequired.Location = new System.Drawing.Point(175, 42);
			chkRequired.Name = "chkRequired";
			chkRequired.Size = new System.Drawing.Size(78, 16);
			chkRequired.TabIndex = 3;
			chkRequired.Text = "必填项(&R)";
			chkRequired.UseVisualStyleBackColor = true;
			chkHidden.AutoSize = true;
			chkHidden.Location = new System.Drawing.Point(175, 20);
			chkHidden.Name = "chkHidden";
			chkHidden.Size = new System.Drawing.Size(90, 16);
			chkHidden.TabIndex = 1;
			chkHidden.Text = "隐藏显示(&V)";
			chkHidden.UseVisualStyleBackColor = true;
			chkHiddenBorderLine.AutoSize = true;
			chkHiddenBorderLine.Location = new System.Drawing.Point(18, 86);
			chkHiddenBorderLine.Name = "chkHiddenBorderLine";
			chkHiddenBorderLine.Size = new System.Drawing.Size(102, 16);
			chkHiddenBorderLine.TabIndex = 6;
			chkHiddenBorderLine.Text = "不显示边框(&B)";
			chkHiddenBorderLine.UseVisualStyleBackColor = true;
			chkNoGenerationXML.AutoSize = true;
			chkNoGenerationXML.Location = new System.Drawing.Point(18, 64);
			chkNoGenerationXML.Name = "chkNoGenerationXML";
			chkNoGenerationXML.Size = new System.Drawing.Size(144, 16);
			chkNoGenerationXML.TabIndex = 4;
			chkNoGenerationXML.Text = "不生成在XML结构中(&X)";
			chkNoGenerationXML.UseVisualStyleBackColor = true;
			chkUnEditable.AutoSize = true;
			chkUnEditable.Location = new System.Drawing.Point(18, 42);
			chkUnEditable.Name = "chkUnEditable";
			chkUnEditable.Size = new System.Drawing.Size(114, 16);
			chkUnEditable.TabIndex = 2;
			chkUnEditable.Text = "无法编辑内容(&E)";
			chkUnEditable.UseVisualStyleBackColor = true;
			txtName.Location = new System.Drawing.Point(115, 17);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(165, 21);
			txtName.TabIndex = 1;
			txtPlaceholder.Location = new System.Drawing.Point(115, 71);
			txtPlaceholder.Name = "txtPlaceholder";
			txtPlaceholder.Size = new System.Drawing.Size(165, 21);
			txtPlaceholder.TabIndex = 5;
			txtTitle.Location = new System.Drawing.Point(115, 44);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new System.Drawing.Size(165, 21);
			txtTitle.TabIndex = 3;
			txtNnit.Location = new System.Drawing.Point(217, 56);
			txtNnit.Name = "txtNnit";
			txtNnit.Size = new System.Drawing.Size(66, 21);
			txtNnit.TabIndex = 7;
			btnOK.Location = new System.Drawing.Point(105, 314);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(88, 23);
			btnOK.TabIndex = 300;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancle.Location = new System.Drawing.Point(220, 314);
			btnCancle.Name = "btnCancle";
			btnCancle.Size = new System.Drawing.Size(88, 23);
			btnCancle.TabIndex = 400;
			btnCancle.Text = "取消(&C)";
			btnCancle.UseVisualStyleBackColor = true;
			btnCancle.Click += new System.EventHandler(btnCancle_Click);
			grpConventional.Controls.Add(label2);
			grpConventional.Controls.Add(label1);
			grpConventional.Controls.Add(label3);
			grpConventional.Controls.Add(txtName);
			grpConventional.Controls.Add(txtTitle);
			grpConventional.Controls.Add(txtPlaceholder);
			grpConventional.Location = new System.Drawing.Point(12, 2);
			grpConventional.Name = "grpConventional";
			grpConventional.Size = new System.Drawing.Size(295, 103);
			grpConventional.TabIndex = 4;
			grpConventional.TabStop = false;
			grpConventional.Text = "常规";
			grpLock.Controls.Add(chkUnDelete);
			grpLock.Controls.Add(chkEncrypt);
			grpLock.Controls.Add(chkReverseEdit);
			grpLock.Controls.Add(chkRequired);
			grpLock.Controls.Add(chkHidden);
			grpLock.Controls.Add(chkUnEditable);
			grpLock.Controls.Add(chkHiddenBorderLine);
			grpLock.Controls.Add(chkNoGenerationXML);
			grpLock.Location = new System.Drawing.Point(12, 106);
			grpLock.Name = "grpLock";
			grpLock.Size = new System.Drawing.Size(295, 111);
			grpLock.TabIndex = 100;
			grpLock.TabStop = false;
			grpLock.Text = "锁定";
			grpIntrinsicProperties.Controls.Add(label4);
			grpIntrinsicProperties.Controls.Add(nudMaxValue);
			grpIntrinsicProperties.Controls.Add(nudMinValue);
			grpIntrinsicProperties.Controls.Add(nudPrecision);
			grpIntrinsicProperties.Controls.Add(label5);
			grpIntrinsicProperties.Controls.Add(txtNnit);
			grpIntrinsicProperties.Controls.Add(label6);
			grpIntrinsicProperties.Controls.Add(label7);
			grpIntrinsicProperties.Location = new System.Drawing.Point(12, 218);
			grpIntrinsicProperties.Name = "grpIntrinsicProperties";
			grpIntrinsicProperties.Size = new System.Drawing.Size(295, 89);
			grpIntrinsicProperties.TabIndex = 200;
			grpIntrinsicProperties.TabStop = false;
			grpIntrinsicProperties.Text = "固有属性";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(319, 344);
			base.Controls.Add(grpIntrinsicProperties);
			base.Controls.Add(grpLock);
			base.Controls.Add(grpConventional);
			base.Controls.Add(btnCancle);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgNumBox";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "数值框";
			base.Load += new System.EventHandler(dlgNumBox_Load);
			((System.ComponentModel.ISupportInitialize)nudMaxValue).EndInit();
			((System.ComponentModel.ISupportInitialize)nudMinValue).EndInit();
			((System.ComponentModel.ISupportInitialize)nudPrecision).EndInit();
			grpConventional.ResumeLayout(false);
			grpConventional.PerformLayout();
			grpLock.ResumeLayout(false);
			grpLock.PerformLayout();
			grpIntrinsicProperties.ResumeLayout(false);
			grpIntrinsicProperties.PerformLayout();
			ResumeLayout(false);
		}

		public dlgNumBox()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgNumBox_Load(object sender, EventArgs e)
		{
			if (xtextInputFieldElement_0 != null)
			{
				try
				{
					txtName.Text = xtextInputFieldElement_0.Name;
					txtTitle.Text = xtextInputFieldElement_0.LabelText;
					txtPlaceholder.Text = xtextInputFieldElement_0.ToolTip;
					txtNnit.Text = xtextInputFieldElement_0.UnitText;
					chkUnDelete.Checked = !xtextInputFieldElement_0.Deleteable;
					chkUnEditable.Checked = !xtextInputFieldElement_0.UserEditable;
					chkHidden.Checked = !xtextInputFieldElement_0.Visible;
					if (xtextInputFieldElement_0.ViewEncryptType == ContentViewEncryptType.None)
					{
						chkEncrypt.Checked = false;
					}
					else
					{
						chkEncrypt.Checked = true;
					}
					if (xtextInputFieldElement_0.ValidateStyle != null)
					{
						chkRequired.Checked = xtextInputFieldElement_0.ValidateStyle.Required;
						nudMaxValue.Value = Convert.ToDecimal(xtextInputFieldElement_0.ValidateStyle.MaxValue);
						nudMinValue.Value = Convert.ToDecimal(xtextInputFieldElement_0.ValidateStyle.MinValue);
					}
					if (xtextInputFieldElement_0.DisplayFormat != null)
					{
						string format = xtextInputFieldElement_0.DisplayFormat.Format;
						if (format != null)
						{
							int num = 0;
							int num2 = format.Length - 1;
							while (num2 >= 0 && format[num2] == '0')
							{
								num++;
								num2--;
							}
							nudPrecision.Value = num;
						}
					}
					txtName.SelectAll();
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 15;
			try
			{
				xtextInputFieldElement_0.Name = txtName.Text.Trim();
				xtextInputFieldElement_0.LabelText = txtTitle.Text.Trim();
				xtextInputFieldElement_0.ToolTip = txtPlaceholder.Text.Trim();
				xtextInputFieldElement_0.UnitText = txtNnit.Text.Trim();
				xtextInputFieldElement_0.Deleteable = !chkUnDelete.Checked;
				xtextInputFieldElement_0.UserEditable = !chkUnEditable.Checked;
				xtextInputFieldElement_0.Visible = !chkHidden.Checked;
				int num2 = Convert.ToInt32(nudPrecision.Value);
				if (num2 > 0)
				{
					xtextInputFieldElement_0.DisplayFormat = new ValueFormater();
					xtextInputFieldElement_0.DisplayFormat.Style = ValueFormatStyle.Numeric;
					xtextInputFieldElement_0.DisplayFormat.Format = "0." + new string('0', num2);
				}
				else
				{
					xtextInputFieldElement_0.DisplayFormat = null;
				}
				if (chkEncrypt.Checked)
				{
					xtextInputFieldElement_0.ViewEncryptType = ContentViewEncryptType.Both;
				}
				else
				{
					xtextInputFieldElement_0.ViewEncryptType = ContentViewEncryptType.None;
				}
				xtextInputFieldElement_0.ValidateStyle = new ValueValidateStyle();
				xtextInputFieldElement_0.ValidateStyle.Required = chkRequired.Checked;
				if (nudMaxValue.Value == nudMinValue.Value)
				{
					xtextInputFieldElement_0.ValidateStyle.CheckMaxValue = false;
					xtextInputFieldElement_0.ValidateStyle.CheckMinValue = false;
				}
				else
				{
					xtextInputFieldElement_0.ValidateStyle.CheckMaxValue = true;
					xtextInputFieldElement_0.ValidateStyle.MaxValue = Convert.ToDouble(nudMaxValue.Value);
					xtextInputFieldElement_0.ValidateStyle.CheckMinValue = true;
					xtextInputFieldElement_0.ValidateStyle.MinValue = Convert.ToDouble(nudMinValue.Value);
				}
				if (FillNsoProperties)
				{
					xtextInputFieldElement_0.SetAttribute(ControlProp.MustFillContent.ToString(), chkRequired.Checked ? "TRUE" : "FALSE");
					xtextInputFieldElement_0.SetAttribute(ControlProp.ViewSecret.ToString(), chkEncrypt.Checked ? "TRUE" : "FALSE");
					xtextInputFieldElement_0.SetAttribute(ControlProp.Edge.ToString(), (xtextInputFieldElement_0.BorderVisible == DCVisibleState.Visible) ? "TRUE" : "FALSE");
					xtextInputFieldElement_0.SetAttribute(ControlProp.DelFlag.ToString(), xtextInputFieldElement_0.Deleteable ? "FALSE" : "TRUE");
				}
				base.DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnCancle_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
