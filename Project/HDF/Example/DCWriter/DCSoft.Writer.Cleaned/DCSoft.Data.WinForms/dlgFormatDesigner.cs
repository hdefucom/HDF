using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Data.WinForms
{
	                                                                    /// <summary>
	                                                                    ///       数据源数据格式化编辑器控件
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class dlgFormatDesigner : Form
	{
		private GroupBox groupBox1;

		private Label lblSample;

		private Label label2;

		private ListBox lstStyle;

		private Label label1;

		private ComboBox cboFormat;

		private Button cmdOK;

		private Button cmdCancel;

		private Container container_0 = null;

		private bool bool_0 = false;

		private ValueFormater valueFormater_0 = new ValueFormater();

		private Hashtable hashtable_0 = new Hashtable();

		                                                                    /// <summary>
		                                                                    ///       数据是否改变标志
		                                                                    ///       </summary>
		public bool Modified => bool_0;

		public ValueFormater InputFormater
		{
			get
			{
				return valueFormater_0;
			}
			set
			{
				valueFormater_0 = value;
			}
		}

		public dlgFormatDesigner()
		{
			InitializeComponent();
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			base.DialogResult = DialogResult.Cancel;
		}

		                                                                    /// <summary> 
		                                                                    ///       清理所有正在使用的资源。
		                                                                    ///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && container_0 != null)
			{
				container_0.Dispose();
			}
			base.Dispose(disposing);
		}

		                                                                    /// <summary> 
		                                                                    ///       设计器支持所需的方法 - 不要使用代码编辑器 
		                                                                    ///       修改此方法的内容。
		                                                                    ///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Data.WinForms.dlgFormatDesigner));
			groupBox1 = new System.Windows.Forms.GroupBox();
			lblSample = new System.Windows.Forms.Label();
			cboFormat = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			lstStyle = new System.Windows.Forms.ListBox();
			label1 = new System.Windows.Forms.Label();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			SuspendLayout();
			groupBox1.Controls.Add(lblSample);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(lblSample, "lblSample");
			lblSample.Name = "lblSample";
			cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			resources.ApplyResources(cboFormat, "cboFormat");
			cboFormat.Name = "cboFormat";
			cboFormat.SelectedIndexChanged += new System.EventHandler(cboFormat_SelectedIndexChanged);
			cboFormat.TextChanged += new System.EventHandler(cboFormat_TextChanged);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(lstStyle, "lstStyle");
			lstStyle.Name = "lstStyle";
			lstStyle.SelectedIndexChanged += new System.EventHandler(lstStyle_SelectedIndexChanged);
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(this, "$this");
			base.Controls.Add(cmdOK);
			base.Controls.Add(groupBox1);
			base.Controls.Add(cboFormat);
			base.Controls.Add(label2);
			base.Controls.Add(lstStyle);
			base.Controls.Add(label1);
			base.Controls.Add(cmdCancel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFormatDesigner";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgFormatDesigner_Load);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private void dlgFormatDesigner_Load(object sender, EventArgs e)
		{
			hashtable_0[ValueFormatStyle.Currency] = DataStrings.FormatSample_Currency.Split('|');
			hashtable_0[ValueFormatStyle.Numeric] = new string[8]
			{
				"0.00",
				"#.00",
				"c",
				"e",
				"f",
				"g",
				"r",
				"FormatedSize"
			};
			hashtable_0[ValueFormatStyle.DateTime] = DataStrings.FormatSample_DateTime.Split('|');
			hashtable_0[ValueFormatStyle.String] = new string[7]
			{
				"trim",
				"normalizespace",
				"htmltext",
				"left,1",
				"right,1",
				"lower",
				"upper"
			};
			hashtable_0[ValueFormatStyle.Boolean] = DataStrings.FormatSample_Boolean.Split('|');
			hashtable_0[ValueFormatStyle.Percent] = new string[5]
			{
				"0",
				"1",
				"2",
				"3",
				"4"
			};
			lstStyle.Items.AddRange(Enum.GetNames(typeof(ValueFormatStyle)));
			if (valueFormater_0 == null)
			{
				valueFormater_0 = new ValueFormater();
			}
			lstStyle.Text = valueFormater_0.Style.ToString();
			cboFormat.Text = valueFormater_0.Format;
			bool_0 = false;
		}

		private void lstStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool_0 = true;
			cboFormat.Items.Clear();
			ValueFormatStyle valueFormatStyle = (ValueFormatStyle)Enum.Parse(typeof(ValueFormatStyle), lstStyle.Text, ignoreCase: true);
			string[] array = hashtable_0[valueFormatStyle] as string[];
			if (array != null)
			{
				cboFormat.Items.AddRange(array);
			}
		}

		private void cboFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			method_0();
		}

		private void cboFormat_TextChanged(object sender, EventArgs e)
		{
			method_0();
		}

		private void method_0()
		{
			int num = 0;
			if (lstStyle.SelectedIndex < 0)
			{
				lblSample.Text = "";
				return;
			}
			ValueFormater valueFormater = new ValueFormater();
			try
			{
				valueFormater.Style = (ValueFormatStyle)Enum.Parse(typeof(ValueFormatStyle), lstStyle.Text, ignoreCase: true);
				valueFormater.Format = cboFormat.Text;
				string text = "";
				if (valueFormater.Style == ValueFormatStyle.String)
				{
					text = "\"" + valueFormater.Execute(DataStrings.SampleText) + "\"";
				}
				else if (valueFormater.Style == ValueFormatStyle.Currency)
				{
					text = valueFormater.Execute("123456.789");
				}
				else if (valueFormater.Style == ValueFormatStyle.DateTime)
				{
					text = valueFormater.Execute(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				}
				else if (valueFormater.Style == ValueFormatStyle.Numeric)
				{
					text = valueFormater.Execute("123456.789");
				}
				else if (valueFormater.Style == ValueFormatStyle.Boolean)
				{
					text = "True:" + valueFormater.Execute("true") + "  False:" + valueFormater.Execute("false");
				}
				else if (valueFormater.Style == ValueFormatStyle.Percent)
				{
					text = valueFormater.Execute("123.45678");
				}
				lblSample.Text = text;
			}
			catch (Exception ex)
			{
				lblSample.Text = "#" + ex.Message;
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (valueFormater_0 == null)
			{
				valueFormater_0 = new ValueFormater();
			}
			if (lstStyle.SelectedIndex >= 0)
			{
				valueFormater_0.Style = (ValueFormatStyle)Enum.Parse(typeof(ValueFormatStyle), lstStyle.Text, ignoreCase: true);
				valueFormater_0.Format = cboFormat.Text;
			}
			else
			{
				valueFormater_0.Style = ValueFormatStyle.None;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
