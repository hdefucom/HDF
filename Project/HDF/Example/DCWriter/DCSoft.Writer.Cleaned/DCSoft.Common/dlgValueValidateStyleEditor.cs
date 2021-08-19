using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       数据校验规则编辑对话框
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福 </remarks>
	[ComVisible(false)]
	public class dlgValueValidateStyleEditor : Form
	{
		private ValueValidateStyle valueValidateStyle_0 = new ValueValidateStyle();

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtValueName;

		private CheckBox chkRequire;

		private GroupBox grbTextStyle;

		private NumericUpDown txtMinLength;

		private NumericUpDown txtMaxLength;

		private RadioButton rdoText;

		private GroupBox grbNumericStyle;

		private RadioButton rdoNumeric;

		private CheckBox chkMinValue;

		private CheckBox chkMaxValue;

		private CheckBox chkInteger;

		private GroupBox grpDateTimeStyle;

		private RadioButton rdoDate;

		private DateTimePicker dtpMinDate;

		private CheckBox chkMaxDateTime;

		private CheckBox chkMinDateTime;

		private DateTimePicker dtpMaxTime;

		private DateTimePicker dtpMinTime;

		private DateTimePicker dtpMaxDate;

		private GroupBox grpTimeStyle;

		private CheckBox chkMaxTime;

		private CheckBox chkMinTime;

		private DateTimePicker dtpMaxTime2;

		private DateTimePicker dtpMinTime2;

		private RadioButton rdoTime;

		private Label label4;

		private TextBox txtCustomMessage;

		private Button cmdOK;

		private Button cmdCancel;

		private TextBox txtMaxValue;

		private TextBox txtMinValue;

		private CheckBox chkMaxLength;

		private CheckBox chkMinLength;

		private RadioButton rdoRegExpress;

		private GroupBox grpRegExpression;

		private TextBox txtRegExpress;

		private Label label2;

		private TextBox txtExcludeKeyword;

		private CheckBox chkBinaryLength;

		private Label label3;

		private TextBox txtIncludeKeywords;

		private CheckBox chkMaxDemicalDigits;

		private NumericUpDown txtMaxDemicalDigits;

		private Label label5;

		private ComboBox cboLevel;

		                                                                    /// <summary>
		                                                                    ///       数据校验样式
		                                                                    ///       </summary>
		public ValueValidateStyle ValidateStyle
		{
			get
			{
				return valueValidateStyle_0;
			}
			set
			{
				valueValidateStyle_0 = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public dlgValueValidateStyleEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgValueValidateStyleEditor_Load(object sender, EventArgs e)
		{
			if (valueValidateStyle_0 == null)
			{
				valueValidateStyle_0 = new ValueValidateStyle();
			}
			txtValueName.Text = valueValidateStyle_0.ValueName;
			txtCustomMessage.Text = valueValidateStyle_0.CustomMessage;
			chkRequire.Checked = valueValidateStyle_0.Required;
			txtIncludeKeywords.Text = valueValidateStyle_0.IncludeKeywords;
			txtExcludeKeyword.Text = valueValidateStyle_0.ExcludeKeywords;
			int level = (int)valueValidateStyle_0.Level;
			if (level >= 0 && level < cboLevel.Items.Count)
			{
				cboLevel.SelectedIndex = level;
			}
			else
			{
				cboLevel.SelectedIndex = 0;
			}
			rdoDate.Checked = false;
			rdoNumeric.Checked = false;
			rdoText.Checked = false;
			rdoTime.Checked = false;
			if (valueValidateStyle_0.ValueType == ValueTypeStyle.Text)
			{
				rdoText.Checked = true;
				chkMaxLength.Checked = valueValidateStyle_0.CheckMaxValue;
				chkMinLength.Checked = valueValidateStyle_0.CheckMinValue;
				txtMaxLength.Value = valueValidateStyle_0.MaxLength;
				txtMinLength.Value = valueValidateStyle_0.MinLength;
				chkBinaryLength.Checked = valueValidateStyle_0.BinaryLength;
			}
			else if (valueValidateStyle_0.ValueType == ValueTypeStyle.Numeric || valueValidateStyle_0.ValueType == ValueTypeStyle.Integer)
			{
				rdoNumeric.Checked = true;
				chkInteger.Checked = (valueValidateStyle_0.ValueType == ValueTypeStyle.Integer);
				chkMaxValue.Checked = valueValidateStyle_0.CheckMaxValue;
				if (!double.IsNaN(valueValidateStyle_0.MaxValue))
				{
					txtMaxValue.Text = valueValidateStyle_0.MaxValue.ToString();
				}
				chkMinValue.Checked = valueValidateStyle_0.CheckMinValue;
				if (!double.IsNaN(valueValidateStyle_0.MinValue))
				{
					txtMinValue.Text = valueValidateStyle_0.MinValue.ToString();
				}
				chkMaxDemicalDigits.Checked = valueValidateStyle_0.CheckDecimalDigits;
				txtMaxDemicalDigits.Text = valueValidateStyle_0.MaxDecimalDigits.ToString();
			}
			else if (valueValidateStyle_0.ValueType == ValueTypeStyle.Date || valueValidateStyle_0.ValueType == ValueTypeStyle.DateTime)
			{
				rdoDate.Checked = true;
				dtpMaxDate.Value = valueValidateStyle_0.DateTimeMaxValue;
				dtpMaxTime.Value = valueValidateStyle_0.DateTimeMaxValue;
				chkMaxDateTime.Checked = valueValidateStyle_0.CheckMaxValue;
				dtpMinDate.Value = valueValidateStyle_0.DateTimeMinValue;
				dtpMinTime.Value = valueValidateStyle_0.DateTimeMinValue;
				chkMinDateTime.Checked = valueValidateStyle_0.CheckMinValue;
			}
			else if (valueValidateStyle_0.ValueType == ValueTypeStyle.Time)
			{
				rdoTime.Checked = true;
				dtpMaxTime2.Value = new DateTime(1900, 1, 1).Add(valueValidateStyle_0.DateTimeMaxValue.TimeOfDay);
				chkMaxTime.Checked = !valueValidateStyle_0.CheckMaxValue;
				chkMinTime.Checked = !valueValidateStyle_0.CheckMinValue;
				dtpMinTime2.Value = new DateTime(1900, 1, 1).Add(valueValidateStyle_0.DateTimeMinValue.TimeOfDay);
			}
			else if (valueValidateStyle_0.ValueType == ValueTypeStyle.RegExpress)
			{
				rdoRegExpress.Checked = true;
				txtRegExpress.Text = valueValidateStyle_0.RegExpression;
			}
			method_0(rdoText, grbTextStyle);
			method_0(rdoDate, grpDateTimeStyle);
			method_0(rdoTime, grpTimeStyle);
			method_0(rdoNumeric, grbNumericStyle);
			method_0(rdoRegExpress, grpRegExpression);
		}

		private void txtMinLength_ValueChanged(object sender, EventArgs e)
		{
		}

		private void rdoText_CheckedChanged(object sender, EventArgs e)
		{
			method_0((RadioButton)sender, grbTextStyle);
		}

		private void rdoNumeric_CheckedChanged(object sender, EventArgs e)
		{
			method_0((RadioButton)sender, grbNumericStyle);
		}

		private void rdoDate_CheckedChanged(object sender, EventArgs e)
		{
			method_0((RadioButton)sender, grpDateTimeStyle);
		}

		private void rdoTime_CheckedChanged(object sender, EventArgs e)
		{
			method_0((RadioButton)sender, grpTimeStyle);
		}

		private void rdoRegExpress_CheckedChanged(object sender, EventArgs e)
		{
			method_0((RadioButton)sender, grpRegExpression);
		}

		private void method_0(RadioButton radioButton_0, Control control_0)
		{
			if (radioButton_0.Checked)
			{
				foreach (Control control2 in control_0.Controls)
				{
					control2.Enabled = true;
				}
				if (radioButton_0 == rdoText)
				{
					txtMaxLength.Enabled = chkMaxLength.Checked;
					txtMinLength.Enabled = chkMinLength.Checked;
				}
				if (radioButton_0 == rdoNumeric)
				{
					txtMaxValue.Enabled = (chkMaxValue.Checked && chkMaxValue.Enabled);
					txtMinValue.Enabled = (chkMinValue.Checked && chkMinValue.Enabled);
					txtMaxDemicalDigits.Enabled = (chkMaxDemicalDigits.Checked && chkMaxDemicalDigits.Enabled);
				}
				else if (radioButton_0 == rdoDate)
				{
					dtpMinDate.Enabled = (chkMinDateTime.Checked && chkMinDateTime.Enabled);
					dtpMinTime.Enabled = (chkMinDateTime.Checked && chkMinDateTime.Enabled);
					dtpMaxDate.Enabled = (chkMaxDateTime.Checked && chkMaxDateTime.Enabled);
					dtpMaxTime.Enabled = (chkMaxDateTime.Checked && chkMaxDateTime.Enabled);
				}
				else if (radioButton_0 == rdoTime)
				{
					dtpMinTime2.Enabled = (chkMinTime.Checked && chkMinTime.Enabled);
					dtpMaxTime2.Enabled = (chkMaxTime.Checked && chkMaxTime.Enabled);
				}
			}
			else
			{
				foreach (Control control3 in control_0.Controls)
				{
					if (control3 != radioButton_0)
					{
						control3.Enabled = false;
					}
				}
			}
		}

		private void chkMaxValue_CheckedChanged(object sender, EventArgs e)
		{
			txtMaxValue.Enabled = (chkMaxValue.Checked && chkMaxValue.Enabled);
		}

		private void chkMinValue_CheckedChanged(object sender, EventArgs e)
		{
			txtMinValue.Enabled = (chkMinValue.Checked && chkMinValue.Enabled);
		}

		private void chkMinDateTime_CheckedChanged(object sender, EventArgs e)
		{
			dtpMinDate.Enabled = (chkMinDateTime.Checked && chkMinDateTime.Enabled);
			dtpMinTime.Enabled = (chkMinDateTime.Checked && chkMinDateTime.Enabled);
		}

		private void chkMaxDateTime_CheckedChanged(object sender, EventArgs e)
		{
			dtpMaxDate.Enabled = (chkMaxDateTime.Checked && chkMaxDateTime.Enabled);
			dtpMaxTime.Enabled = (chkMaxDateTime.Checked && chkMaxDateTime.Enabled);
		}

		private void chkMinTime_CheckedChanged(object sender, EventArgs e)
		{
			dtpMinTime2.Enabled = (chkMinTime.Checked && chkMinTime.Enabled);
		}

		private void chkMaxTime_CheckedChanged(object sender, EventArgs e)
		{
			dtpMaxTime2.Enabled = (chkMaxTime.Checked && chkMaxTime.Enabled);
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			valueValidateStyle_0.ValueName = txtValueName.Text.Trim();
			valueValidateStyle_0.CustomMessage = txtCustomMessage.Text.Trim();
			valueValidateStyle_0.Required = chkRequire.Checked;
			valueValidateStyle_0.IncludeKeywords = txtIncludeKeywords.Text;
			valueValidateStyle_0.Level = (ValueValidateLevel)cboLevel.SelectedIndex;
			valueValidateStyle_0.ContentVersion = -1;
			if (rdoText.Checked)
			{
				valueValidateStyle_0.ValueType = ValueTypeStyle.Text;
				valueValidateStyle_0.CheckMaxValue = chkMaxLength.Checked;
				valueValidateStyle_0.CheckMinValue = chkMinLength.Checked;
				valueValidateStyle_0.MaxLength = Convert.ToInt32(txtMaxLength.Value);
				valueValidateStyle_0.MinLength = Convert.ToInt32(txtMinLength.Value);
				valueValidateStyle_0.BinaryLength = chkBinaryLength.Checked;
			}
			else if (rdoNumeric.Checked)
			{
				valueValidateStyle_0.ValueType = (chkInteger.Checked ? ValueTypeStyle.Integer : ValueTypeStyle.Numeric);
				valueValidateStyle_0.CheckMaxValue = chkMaxValue.Checked;
				valueValidateStyle_0.CheckMinValue = chkMinValue.Checked;
				valueValidateStyle_0.CheckDecimalDigits = chkMaxDemicalDigits.Checked;
				if (chkMaxDemicalDigits.Checked)
				{
					valueValidateStyle_0.MaxDecimalDigits = Convert.ToInt32(txtMaxDemicalDigits.Value);
				}
				if (chkMaxValue.Checked)
				{
					double result = 0.0;
					if (!double.TryParse(txtMaxValue.Text, out result))
					{
						txtMaxValue.ForeColor = Color.Red;
						return;
					}
					valueValidateStyle_0.MaxValue = result;
				}
				else
				{
					valueValidateStyle_0.MaxValue = double.NaN;
				}
				if (chkMinValue.Checked)
				{
					double result = 0.0;
					if (!double.TryParse(txtMinValue.Text, out result))
					{
						txtMinValue.ForeColor = Color.Red;
						return;
					}
					valueValidateStyle_0.MinValue = result;
				}
				else
				{
					valueValidateStyle_0.MinValue = double.NaN;
				}
			}
			else if (rdoDate.Checked)
			{
				valueValidateStyle_0.ValueType = ValueTypeStyle.DateTime;
				if (chkMaxDateTime.Checked)
				{
					valueValidateStyle_0.DateTimeMaxValue = dtpMaxDate.Value.Date.Add(dtpMaxTime.Value.TimeOfDay);
					valueValidateStyle_0.CheckMaxValue = true;
				}
				else
				{
					valueValidateStyle_0.DateTimeMaxValue = ValueValidateStyle.NullDateTime;
					valueValidateStyle_0.CheckMaxValue = false;
				}
				if (chkMinDateTime.Checked)
				{
					valueValidateStyle_0.DateTimeMinValue = dtpMinDate.Value.Date.Add(dtpMinTime.Value.TimeOfDay);
					valueValidateStyle_0.CheckMinValue = true;
				}
				else
				{
					valueValidateStyle_0.DateTimeMinValue = ValueValidateStyle.NullDateTime;
					valueValidateStyle_0.CheckMinValue = false;
				}
			}
			else if (rdoTime.Checked)
			{
				valueValidateStyle_0.ValueType = ValueTypeStyle.Time;
				if (chkMaxTime.Checked)
				{
					valueValidateStyle_0.DateTimeMaxValue = dtpMaxTime2.Value;
				}
				else
				{
					valueValidateStyle_0.DateTimeMaxValue = ValueValidateStyle.NullDateTime;
				}
				if (chkMinTime.Checked)
				{
					valueValidateStyle_0.DateTimeMinValue = dtpMinTime2.Value;
				}
				else
				{
					valueValidateStyle_0.DateTimeMinValue = ValueValidateStyle.NullDateTime;
				}
			}
			else if (rdoRegExpress.Checked)
			{
				valueValidateStyle_0.ValueType = ValueTypeStyle.RegExpress;
				valueValidateStyle_0.RegExpression = txtRegExpress.Text;
			}
			valueValidateStyle_0.ExcludeKeywords = txtExcludeKeyword.Text;
			if (string.IsNullOrEmpty(valueValidateStyle_0.ValueName))
			{
				valueValidateStyle_0.ValueName = null;
			}
			if (string.IsNullOrEmpty(valueValidateStyle_0.IncludeKeywords))
			{
				valueValidateStyle_0.IncludeKeywords = null;
			}
			if (string.IsNullOrEmpty(valueValidateStyle_0.ExcludeKeywords))
			{
				valueValidateStyle_0.ExcludeKeywords = null;
			}
			if (string.IsNullOrEmpty(valueValidateStyle_0.CustomMessage))
			{
				valueValidateStyle_0.CustomMessage = null;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkMaxLength_CheckedChanged(object sender, EventArgs e)
		{
			txtMaxLength.Enabled = chkMaxLength.Checked;
		}

		private void chkMinLength_CheckedChanged(object sender, EventArgs e)
		{
			txtMinLength.Enabled = chkMinLength.Checked;
		}

		private void chkMaxDemicalDigits_CheckedChanged(object sender, EventArgs e)
		{
			txtMaxDemicalDigits.Enabled = chkMaxDemicalDigits.Checked;
			if (chkMaxDemicalDigits.Checked)
			{
				chkInteger.Checked = !chkMaxDemicalDigits.Checked;
			}
		}

		private void chkInteger_CheckedChanged(object sender, EventArgs e)
		{
			if (chkInteger.Checked)
			{
				chkMaxDemicalDigits.Checked = !chkInteger.Checked;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       清理所有正在使用的资源。
		                                                                    ///       </summary>
		                                                                    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Common.dlgValueValidateStyleEditor));
			label1 = new System.Windows.Forms.Label();
			txtValueName = new System.Windows.Forms.TextBox();
			chkRequire = new System.Windows.Forms.CheckBox();
			grbTextStyle = new System.Windows.Forms.GroupBox();
			txtMaxLength = new System.Windows.Forms.NumericUpDown();
			txtMinLength = new System.Windows.Forms.NumericUpDown();
			chkBinaryLength = new System.Windows.Forms.CheckBox();
			chkMaxLength = new System.Windows.Forms.CheckBox();
			chkMinLength = new System.Windows.Forms.CheckBox();
			rdoText = new System.Windows.Forms.RadioButton();
			grbNumericStyle = new System.Windows.Forms.GroupBox();
			txtMaxDemicalDigits = new System.Windows.Forms.NumericUpDown();
			chkMaxDemicalDigits = new System.Windows.Forms.CheckBox();
			txtMaxValue = new System.Windows.Forms.TextBox();
			txtMinValue = new System.Windows.Forms.TextBox();
			chkInteger = new System.Windows.Forms.CheckBox();
			chkMinValue = new System.Windows.Forms.CheckBox();
			chkMaxValue = new System.Windows.Forms.CheckBox();
			rdoNumeric = new System.Windows.Forms.RadioButton();
			grpDateTimeStyle = new System.Windows.Forms.GroupBox();
			dtpMaxTime = new System.Windows.Forms.DateTimePicker();
			dtpMaxDate = new System.Windows.Forms.DateTimePicker();
			dtpMinTime = new System.Windows.Forms.DateTimePicker();
			dtpMinDate = new System.Windows.Forms.DateTimePicker();
			chkMaxDateTime = new System.Windows.Forms.CheckBox();
			chkMinDateTime = new System.Windows.Forms.CheckBox();
			rdoDate = new System.Windows.Forms.RadioButton();
			grpTimeStyle = new System.Windows.Forms.GroupBox();
			chkMaxTime = new System.Windows.Forms.CheckBox();
			chkMinTime = new System.Windows.Forms.CheckBox();
			dtpMaxTime2 = new System.Windows.Forms.DateTimePicker();
			dtpMinTime2 = new System.Windows.Forms.DateTimePicker();
			rdoTime = new System.Windows.Forms.RadioButton();
			label4 = new System.Windows.Forms.Label();
			txtCustomMessage = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			rdoRegExpress = new System.Windows.Forms.RadioButton();
			grpRegExpression = new System.Windows.Forms.GroupBox();
			txtRegExpress = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtExcludeKeyword = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtIncludeKeywords = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			cboLevel = new System.Windows.Forms.ComboBox();
			grbTextStyle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtMaxLength).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtMinLength).BeginInit();
			grbNumericStyle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtMaxDemicalDigits).BeginInit();
			grpDateTimeStyle.SuspendLayout();
			grpTimeStyle.SuspendLayout();
			grpRegExpression.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtValueName, "txtValueName");
			txtValueName.Name = "txtValueName";
			resources.ApplyResources(chkRequire, "chkRequire");
			chkRequire.Name = "chkRequire";
			chkRequire.UseVisualStyleBackColor = true;
			grbTextStyle.Controls.Add(txtMaxLength);
			grbTextStyle.Controls.Add(txtMinLength);
			grbTextStyle.Controls.Add(chkBinaryLength);
			grbTextStyle.Controls.Add(chkMaxLength);
			grbTextStyle.Controls.Add(chkMinLength);
			resources.ApplyResources(grbTextStyle, "grbTextStyle");
			grbTextStyle.Name = "grbTextStyle";
			grbTextStyle.TabStop = false;
			resources.ApplyResources(txtMaxLength, "txtMaxLength");
			txtMaxLength.Maximum = new decimal(new int[4]
			{
				100000000,
				0,
				0,
				0
			});
			txtMaxLength.Name = "txtMaxLength";
			resources.ApplyResources(txtMinLength, "txtMinLength");
			txtMinLength.Maximum = new decimal(new int[4]
			{
				100000000,
				0,
				0,
				0
			});
			txtMinLength.Name = "txtMinLength";
			txtMinLength.ValueChanged += new System.EventHandler(txtMinLength_ValueChanged);
			resources.ApplyResources(chkBinaryLength, "chkBinaryLength");
			chkBinaryLength.Name = "chkBinaryLength";
			chkBinaryLength.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkMaxLength, "chkMaxLength");
			chkMaxLength.Name = "chkMaxLength";
			chkMaxLength.UseVisualStyleBackColor = true;
			chkMaxLength.CheckedChanged += new System.EventHandler(chkMaxLength_CheckedChanged);
			resources.ApplyResources(chkMinLength, "chkMinLength");
			chkMinLength.Name = "chkMinLength";
			chkMinLength.UseVisualStyleBackColor = true;
			chkMinLength.CheckedChanged += new System.EventHandler(chkMinLength_CheckedChanged);
			resources.ApplyResources(rdoText, "rdoText");
			rdoText.Name = "rdoText";
			rdoText.TabStop = true;
			rdoText.UseVisualStyleBackColor = true;
			rdoText.CheckedChanged += new System.EventHandler(rdoText_CheckedChanged);
			grbNumericStyle.Controls.Add(txtMaxDemicalDigits);
			grbNumericStyle.Controls.Add(chkMaxDemicalDigits);
			grbNumericStyle.Controls.Add(txtMaxValue);
			grbNumericStyle.Controls.Add(txtMinValue);
			grbNumericStyle.Controls.Add(chkInteger);
			grbNumericStyle.Controls.Add(chkMinValue);
			grbNumericStyle.Controls.Add(chkMaxValue);
			resources.ApplyResources(grbNumericStyle, "grbNumericStyle");
			grbNumericStyle.Name = "grbNumericStyle";
			grbNumericStyle.TabStop = false;
			resources.ApplyResources(txtMaxDemicalDigits, "txtMaxDemicalDigits");
			txtMaxDemicalDigits.Maximum = new decimal(new int[4]
			{
				100000000,
				0,
				0,
				0
			});
			txtMaxDemicalDigits.Name = "txtMaxDemicalDigits";
			resources.ApplyResources(chkMaxDemicalDigits, "chkMaxDemicalDigits");
			chkMaxDemicalDigits.Name = "chkMaxDemicalDigits";
			chkMaxDemicalDigits.UseVisualStyleBackColor = true;
			chkMaxDemicalDigits.CheckedChanged += new System.EventHandler(chkMaxDemicalDigits_CheckedChanged);
			resources.ApplyResources(txtMaxValue, "txtMaxValue");
			txtMaxValue.Name = "txtMaxValue";
			resources.ApplyResources(txtMinValue, "txtMinValue");
			txtMinValue.Name = "txtMinValue";
			resources.ApplyResources(chkInteger, "chkInteger");
			chkInteger.Name = "chkInteger";
			chkInteger.UseVisualStyleBackColor = true;
			chkInteger.CheckedChanged += new System.EventHandler(chkInteger_CheckedChanged);
			resources.ApplyResources(chkMinValue, "chkMinValue");
			chkMinValue.Name = "chkMinValue";
			chkMinValue.UseVisualStyleBackColor = true;
			chkMinValue.CheckedChanged += new System.EventHandler(chkMinValue_CheckedChanged);
			resources.ApplyResources(chkMaxValue, "chkMaxValue");
			chkMaxValue.Name = "chkMaxValue";
			chkMaxValue.UseVisualStyleBackColor = true;
			chkMaxValue.CheckedChanged += new System.EventHandler(chkMaxValue_CheckedChanged);
			resources.ApplyResources(rdoNumeric, "rdoNumeric");
			rdoNumeric.Name = "rdoNumeric";
			rdoNumeric.TabStop = true;
			rdoNumeric.UseVisualStyleBackColor = true;
			rdoNumeric.CheckedChanged += new System.EventHandler(rdoNumeric_CheckedChanged);
			grpDateTimeStyle.Controls.Add(dtpMaxTime);
			grpDateTimeStyle.Controls.Add(dtpMaxDate);
			grpDateTimeStyle.Controls.Add(dtpMinTime);
			grpDateTimeStyle.Controls.Add(dtpMinDate);
			grpDateTimeStyle.Controls.Add(chkMaxDateTime);
			grpDateTimeStyle.Controls.Add(chkMinDateTime);
			resources.ApplyResources(grpDateTimeStyle, "grpDateTimeStyle");
			grpDateTimeStyle.Name = "grpDateTimeStyle";
			grpDateTimeStyle.TabStop = false;
			dtpMaxTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			resources.ApplyResources(dtpMaxTime, "dtpMaxTime");
			dtpMaxTime.Name = "dtpMaxTime";
			dtpMaxTime.ShowUpDown = true;
			resources.ApplyResources(dtpMaxDate, "dtpMaxDate");
			dtpMaxDate.Name = "dtpMaxDate";
			dtpMinTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			resources.ApplyResources(dtpMinTime, "dtpMinTime");
			dtpMinTime.Name = "dtpMinTime";
			dtpMinTime.ShowUpDown = true;
			resources.ApplyResources(dtpMinDate, "dtpMinDate");
			dtpMinDate.Name = "dtpMinDate";
			resources.ApplyResources(chkMaxDateTime, "chkMaxDateTime");
			chkMaxDateTime.Name = "chkMaxDateTime";
			chkMaxDateTime.UseVisualStyleBackColor = true;
			chkMaxDateTime.CheckedChanged += new System.EventHandler(chkMaxDateTime_CheckedChanged);
			resources.ApplyResources(chkMinDateTime, "chkMinDateTime");
			chkMinDateTime.Name = "chkMinDateTime";
			chkMinDateTime.UseVisualStyleBackColor = true;
			chkMinDateTime.CheckedChanged += new System.EventHandler(chkMinDateTime_CheckedChanged);
			resources.ApplyResources(rdoDate, "rdoDate");
			rdoDate.Name = "rdoDate";
			rdoDate.TabStop = true;
			rdoDate.UseVisualStyleBackColor = true;
			rdoDate.CheckedChanged += new System.EventHandler(rdoDate_CheckedChanged);
			grpTimeStyle.Controls.Add(chkMaxTime);
			grpTimeStyle.Controls.Add(chkMinTime);
			grpTimeStyle.Controls.Add(dtpMaxTime2);
			grpTimeStyle.Controls.Add(dtpMinTime2);
			resources.ApplyResources(grpTimeStyle, "grpTimeStyle");
			grpTimeStyle.Name = "grpTimeStyle";
			grpTimeStyle.TabStop = false;
			resources.ApplyResources(chkMaxTime, "chkMaxTime");
			chkMaxTime.Name = "chkMaxTime";
			chkMaxTime.UseVisualStyleBackColor = true;
			chkMaxTime.CheckedChanged += new System.EventHandler(chkMaxTime_CheckedChanged);
			resources.ApplyResources(chkMinTime, "chkMinTime");
			chkMinTime.Name = "chkMinTime";
			chkMinTime.UseVisualStyleBackColor = true;
			chkMinTime.CheckedChanged += new System.EventHandler(chkMinTime_CheckedChanged);
			dtpMaxTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			resources.ApplyResources(dtpMaxTime2, "dtpMaxTime2");
			dtpMaxTime2.Name = "dtpMaxTime2";
			dtpMaxTime2.ShowUpDown = true;
			dtpMinTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			resources.ApplyResources(dtpMinTime2, "dtpMinTime2");
			dtpMinTime2.Name = "dtpMinTime2";
			dtpMinTime2.ShowUpDown = true;
			resources.ApplyResources(rdoTime, "rdoTime");
			rdoTime.Name = "rdoTime";
			rdoTime.TabStop = true;
			rdoTime.UseVisualStyleBackColor = true;
			rdoTime.CheckedChanged += new System.EventHandler(rdoTime_CheckedChanged);
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(txtCustomMessage, "txtCustomMessage");
			txtCustomMessage.Name = "txtCustomMessage";
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.UseVisualStyleBackColor = true;
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.UseVisualStyleBackColor = true;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(rdoRegExpress, "rdoRegExpress");
			rdoRegExpress.Name = "rdoRegExpress";
			rdoRegExpress.TabStop = true;
			rdoRegExpress.UseVisualStyleBackColor = true;
			rdoRegExpress.CheckedChanged += new System.EventHandler(rdoRegExpress_CheckedChanged);
			grpRegExpression.Controls.Add(txtRegExpress);
			resources.ApplyResources(grpRegExpression, "grpRegExpression");
			grpRegExpression.Name = "grpRegExpression";
			grpRegExpression.TabStop = false;
			resources.ApplyResources(txtRegExpress, "txtRegExpress");
			txtRegExpress.Name = "txtRegExpress";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtExcludeKeyword, "txtExcludeKeyword");
			txtExcludeKeyword.Name = "txtExcludeKeyword";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtIncludeKeywords, "txtIncludeKeywords");
			txtIncludeKeywords.Name = "txtIncludeKeywords";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboLevel.FormattingEnabled = true;
			cboLevel.Items.AddRange(new object[3]
			{
				resources.GetString("cboLevel.Items"),
				resources.GetString("cboLevel.Items1"),
				resources.GetString("cboLevel.Items2")
			});
			resources.ApplyResources(cboLevel, "cboLevel");
			cboLevel.Name = "cboLevel";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = cmdCancel;
			base.Controls.Add(cboLevel);
			base.Controls.Add(label5);
			base.Controls.Add(txtIncludeKeywords);
			base.Controls.Add(label3);
			base.Controls.Add(txtExcludeKeyword);
			base.Controls.Add(label2);
			base.Controls.Add(rdoRegExpress);
			base.Controls.Add(grpRegExpression);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(rdoNumeric);
			base.Controls.Add(grbNumericStyle);
			base.Controls.Add(rdoTime);
			base.Controls.Add(grpTimeStyle);
			base.Controls.Add(rdoText);
			base.Controls.Add(rdoDate);
			base.Controls.Add(grpDateTimeStyle);
			base.Controls.Add(grbTextStyle);
			base.Controls.Add(chkRequire);
			base.Controls.Add(txtCustomMessage);
			base.Controls.Add(label4);
			base.Controls.Add(txtValueName);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgValueValidateStyleEditor";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgValueValidateStyleEditor_Load);
			grbTextStyle.ResumeLayout(false);
			grbTextStyle.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtMaxLength).EndInit();
			((System.ComponentModel.ISupportInitialize)txtMinLength).EndInit();
			grbNumericStyle.ResumeLayout(false);
			grbNumericStyle.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtMaxDemicalDigits).EndInit();
			grpDateTimeStyle.ResumeLayout(false);
			grpDateTimeStyle.PerformLayout();
			grpTimeStyle.ResumeLayout(false);
			grpTimeStyle.PerformLayout();
			grpRegExpression.ResumeLayout(false);
			grpRegExpression.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
