using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       复选框编辑器对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgCheckBoxElementEditor : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtName;

		private CheckBox chkChecked;

		private Label label2;

		private TextBox txtValue;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkDeleteable;

		private CheckBox chkEnabled;

		private Label label4;

		private TextBox txtTag;

		private Label label5;

		private TextBox txtTooltip;

		private Button btnBrowseEventExpressions;

		private TextBox txtEventExpressions;

		private Label label13;

		private Label label6;

		private TextBox txtCheckedCascadeContainerName;

		private Label label7;

		private TextBox txtUnCheckedCascadeContainerName;

		private Button btnBrowseBinding;

		private TextBox txtBinding;

		private Label label8;

		private Label label9;

		private TextBox txtCaption;

		private Label label10;

		private TextBox txtID;

		private CheckBox chkCheckAlignLeft;

		private CheckBox chkMultiline;

		private Label label3;

		private ComboBox cboVisualStyle;

		private ComboBox cboEnableHighlight;

		private Label label12;

		private Label label11;

		private ComboBox cboPrintVisibilityWhenUnchecked;

		private CheckBox chkRequired;

		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		/// <summary>
		///       参数
		///       </summary>
		public ElementPropertiesEditEventArgs SourceEventArgs
		{
			get
			{
				return elementPropertiesEditEventArgs_0;
			}
			set
			{
				elementPropertiesEditEventArgs_0 = value;
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgCheckBoxElementEditor));
			label1 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			chkChecked = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			txtValue = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			chkEnabled = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			txtTag = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtTooltip = new System.Windows.Forms.TextBox();
			btnBrowseEventExpressions = new System.Windows.Forms.Button();
			txtEventExpressions = new System.Windows.Forms.TextBox();
			label13 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			txtCheckedCascadeContainerName = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtUnCheckedCascadeContainerName = new System.Windows.Forms.TextBox();
			btnBrowseBinding = new System.Windows.Forms.Button();
			txtBinding = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			txtCaption = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			chkCheckAlignLeft = new System.Windows.Forms.CheckBox();
			chkMultiline = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			cboVisualStyle = new System.Windows.Forms.ComboBox();
			cboEnableHighlight = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			cboPrintVisibilityWhenUnchecked = new System.Windows.Forms.ComboBox();
			chkRequired = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(chkChecked, "chkChecked");
			chkChecked.Name = "chkChecked";
			chkChecked.UseVisualStyleBackColor = true;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtValue, "txtValue");
			txtValue.Name = "txtValue";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(chkDeleteable, "chkDeleteable");
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkEnabled, "chkEnabled");
			chkEnabled.Name = "chkEnabled";
			chkEnabled.UseVisualStyleBackColor = true;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(txtTag, "txtTag");
			txtTag.Name = "txtTag";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(txtTooltip, "txtTooltip");
			txtTooltip.Name = "txtTooltip";
			resources.ApplyResources(btnBrowseEventExpressions, "btnBrowseEventExpressions");
			btnBrowseEventExpressions.Name = "btnBrowseEventExpressions";
			btnBrowseEventExpressions.UseVisualStyleBackColor = true;
			btnBrowseEventExpressions.Click += new System.EventHandler(btnBrowseEventExpressions_Click);
			resources.ApplyResources(txtEventExpressions, "txtEventExpressions");
			txtEventExpressions.Name = "txtEventExpressions";
			txtEventExpressions.ReadOnly = true;
			resources.ApplyResources(label13, "label13");
			label13.Name = "label13";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtCheckedCascadeContainerName, "txtCheckedCascadeContainerName");
			txtCheckedCascadeContainerName.Name = "txtCheckedCascadeContainerName";
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(txtUnCheckedCascadeContainerName, "txtUnCheckedCascadeContainerName");
			txtUnCheckedCascadeContainerName.Name = "txtUnCheckedCascadeContainerName";
			resources.ApplyResources(btnBrowseBinding, "btnBrowseBinding");
			btnBrowseBinding.Name = "btnBrowseBinding";
			btnBrowseBinding.UseVisualStyleBackColor = true;
			btnBrowseBinding.Click += new System.EventHandler(btnBrowseBinding_Click);
			resources.ApplyResources(txtBinding, "txtBinding");
			txtBinding.Name = "txtBinding";
			txtBinding.ReadOnly = true;
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(txtCaption, "txtCaption");
			txtCaption.Name = "txtCaption";
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(chkCheckAlignLeft, "chkCheckAlignLeft");
			chkCheckAlignLeft.Name = "chkCheckAlignLeft";
			chkCheckAlignLeft.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkMultiline, "chkMultiline");
			chkMultiline.Name = "chkMultiline";
			chkMultiline.UseVisualStyleBackColor = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboVisualStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboVisualStyle.FormattingEnabled = true;
			cboVisualStyle.Items.AddRange(new object[6]
			{
				resources.GetString("cboVisualStyle.Items"),
				resources.GetString("cboVisualStyle.Items1"),
				resources.GetString("cboVisualStyle.Items2"),
				resources.GetString("cboVisualStyle.Items3"),
				resources.GetString("cboVisualStyle.Items4"),
				resources.GetString("cboVisualStyle.Items5")
			});
			resources.ApplyResources(cboVisualStyle, "cboVisualStyle");
			cboVisualStyle.Name = "cboVisualStyle";
			cboEnableHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboEnableHighlight.FormattingEnabled = true;
			cboEnableHighlight.Items.AddRange(new object[3]
			{
				resources.GetString("cboEnableHighlight.Items"),
				resources.GetString("cboEnableHighlight.Items1"),
				resources.GetString("cboEnableHighlight.Items2")
			});
			resources.ApplyResources(cboEnableHighlight, "cboEnableHighlight");
			cboEnableHighlight.Name = "cboEnableHighlight";
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			cboPrintVisibilityWhenUnchecked.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboPrintVisibilityWhenUnchecked.FormattingEnabled = true;
			cboPrintVisibilityWhenUnchecked.Items.AddRange(new object[3]
			{
				resources.GetString("cboPrintVisibilityWhenUnchecked.Items"),
				resources.GetString("cboPrintVisibilityWhenUnchecked.Items1"),
				resources.GetString("cboPrintVisibilityWhenUnchecked.Items2")
			});
			resources.ApplyResources(cboPrintVisibilityWhenUnchecked, "cboPrintVisibilityWhenUnchecked");
			cboPrintVisibilityWhenUnchecked.Name = "cboPrintVisibilityWhenUnchecked";
			resources.ApplyResources(chkRequired, "chkRequired");
			chkRequired.Name = "chkRequired";
			chkRequired.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cboPrintVisibilityWhenUnchecked);
			base.Controls.Add(label11);
			base.Controls.Add(cboEnableHighlight);
			base.Controls.Add(label12);
			base.Controls.Add(cboVisualStyle);
			base.Controls.Add(label3);
			base.Controls.Add(chkMultiline);
			base.Controls.Add(chkRequired);
			base.Controls.Add(chkCheckAlignLeft);
			base.Controls.Add(label9);
			base.Controls.Add(btnBrowseBinding);
			base.Controls.Add(txtBinding);
			base.Controls.Add(label8);
			base.Controls.Add(btnBrowseEventExpressions);
			base.Controls.Add(txtEventExpressions);
			base.Controls.Add(label13);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkEnabled);
			base.Controls.Add(chkDeleteable);
			base.Controls.Add(chkChecked);
			base.Controls.Add(txtCaption);
			base.Controls.Add(txtUnCheckedCascadeContainerName);
			base.Controls.Add(label7);
			base.Controls.Add(txtCheckedCascadeContainerName);
			base.Controls.Add(label6);
			base.Controls.Add(txtTooltip);
			base.Controls.Add(label5);
			base.Controls.Add(txtTag);
			base.Controls.Add(label4);
			base.Controls.Add(txtValue);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label10);
			base.Controls.Add(txtName);
			base.Controls.Add(label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgCheckBoxElementEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgCheckBoxElementEditor_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCheckBoxElementEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgCheckBoxElementEditor_Load(object sender, EventArgs e)
		{
			int num = 8;
			if (SourceEventArgs != null && SourceEventArgs.WriterControl != null)
			{
				Text = SourceEventArgs.WriterControl.DialogTitlePrefix + Text;
			}
			if (SourceEventArgs != null && SourceEventArgs.Element is XTextCheckBoxElementBase)
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)SourceEventArgs.Element;
				if (xTextCheckBoxElementBase is XTextCheckBoxElement)
				{
					Text = WriterStrings.CheckboxProperty;
				}
				else
				{
					Text = WriterStrings.RadioboxProperty;
				}
				txtName.Text = xTextCheckBoxElementBase.Name;
				txtValue.Text = xTextCheckBoxElementBase.CheckedValue;
				cboVisualStyle.SelectedIndex = (int)xTextCheckBoxElementBase.VisualStyle;
				chkChecked.Checked = xTextCheckBoxElementBase.Checked;
				chkDeleteable.Checked = xTextCheckBoxElementBase.Deleteable;
				chkCheckAlignLeft.Checked = xTextCheckBoxElementBase.CheckAlignLeft;
				chkEnabled.Checked = xTextCheckBoxElementBase.Enabled;
				txtTag.Text = xTextCheckBoxElementBase.StringTag;
				txtTooltip.Text = xTextCheckBoxElementBase.ToolTip;
				txtBinding.Tag = xTextCheckBoxElementBase.ValueBinding;
				txtCaption.Text = xTextCheckBoxElementBase.Caption;
				txtID.Text = xTextCheckBoxElementBase.ID;
				chkMultiline.Checked = xTextCheckBoxElementBase.Multiline;
				chkRequired.Checked = xTextCheckBoxElementBase.Requried;
				cboPrintVisibilityWhenUnchecked.SelectedIndex = (int)xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked;
				if (xTextCheckBoxElementBase.ValueBinding != null)
				{
					txtBinding.Text = xTextCheckBoxElementBase.ValueBinding.ToString();
				}
				if (xTextCheckBoxElementBase.EventExpressions != null)
				{
					foreach (EventExpressionInfo eventExpression in xTextCheckBoxElementBase.EventExpressions)
					{
						if (eventExpression.EventName == "ContentChanged" && eventExpression.Target == EventExpressionTarget.Custom)
						{
							_ = eventExpression.Expression;
							if (GClass52.smethod_0(eventExpression.Expression, "this.Checked=true"))
							{
								txtCheckedCascadeContainerName.Text = eventExpression.CustomTargetName;
							}
							else if (GClass52.smethod_0(eventExpression.Expression, "this.Checked=false"))
							{
								txtUnCheckedCascadeContainerName.Text = eventExpression.CustomTargetName;
							}
						}
					}
					txtEventExpressions.Tag = xTextCheckBoxElementBase.EventExpressions;
					txtEventExpressions.Text = xTextCheckBoxElementBase.EventExpressions.ToString();
				}
				cboEnableHighlight.SelectedIndex = (int)xTextCheckBoxElementBase.EnableHighlight;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 14;
			if (SourceEventArgs != null)
			{
				bool flag = false;
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)SourceEventArgs.Element;
				XTextDocument document = SourceEventArgs.Document;
				bool flag2 = SourceEventArgs.LogUndo && document.CanLogUndo;
				EventExpressionInfoList eventExpressionInfoList = (EventExpressionInfoList)txtEventExpressions.Tag;
				string text = txtCheckedCascadeContainerName.Text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					if (eventExpressionInfoList == null)
					{
						eventExpressionInfoList = new EventExpressionInfoList();
					}
					EventExpressionInfo eventExpressionInfo = null;
					foreach (EventExpressionInfo item in eventExpressionInfoList)
					{
						if (item.EventName == "ContentChanged" && GClass52.smethod_0(item.Expression, "this.Checked=true"))
						{
							eventExpressionInfo = item;
							break;
						}
					}
					if (eventExpressionInfo == null)
					{
						eventExpressionInfo = new EventExpressionInfo();
						eventExpressionInfo.EventName = "ContentChanged";
						eventExpressionInfo.Expression = "this.Checked=true";
						eventExpressionInfoList.Add(eventExpressionInfo);
					}
					eventExpressionInfo.Target = EventExpressionTarget.Custom;
					eventExpressionInfo.CustomTargetName = text;
				}
				text = txtUnCheckedCascadeContainerName.Text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					if (eventExpressionInfoList == null)
					{
						eventExpressionInfoList = new EventExpressionInfoList();
					}
					EventExpressionInfo eventExpressionInfo = null;
					foreach (EventExpressionInfo item2 in eventExpressionInfoList)
					{
						if (item2.EventName == "ContentChanged" && GClass52.smethod_0(item2.Expression, "this.Checked=false"))
						{
							eventExpressionInfo = item2;
							break;
						}
					}
					if (eventExpressionInfo == null)
					{
						eventExpressionInfo = new EventExpressionInfo();
						eventExpressionInfo.EventName = "ContentChanged";
						eventExpressionInfo.Expression = "this.Checked=false";
						eventExpressionInfoList.Add(eventExpressionInfo);
					}
					eventExpressionInfo.Target = EventExpressionTarget.Custom;
					eventExpressionInfo.CustomTargetName = text;
				}
				if (eventExpressionInfoList != null)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("EventExpressions", xTextCheckBoxElementBase.EventExpressions, eventExpressionInfoList, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.EventExpressions = eventExpressionInfoList;
					flag = true;
				}
				EnableState selectedIndex = (EnableState)cboEnableHighlight.SelectedIndex;
				if (xTextCheckBoxElementBase.EnableHighlight != selectedIndex)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("EnableHighlight", xTextCheckBoxElementBase.EnableHighlight, selectedIndex, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.EnableHighlight = selectedIndex;
					SourceEventArgs.SetContentEffect(ContentEffects.Display);
					flag = true;
				}
				CheckBoxVisualStyle selectedIndex2 = (CheckBoxVisualStyle)cboVisualStyle.SelectedIndex;
				if (xTextCheckBoxElementBase.VisualStyle != selectedIndex2)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("VisualStyle", xTextCheckBoxElementBase.VisualStyle, selectedIndex2, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.VisualStyle = selectedIndex2;
					flag = true;
				}
				if (xTextCheckBoxElementBase.Checked != chkChecked.Checked)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Checked", xTextCheckBoxElementBase.Checked, chkChecked.Checked, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.Checked = chkChecked.Checked;
					flag = true;
				}
				if (xTextCheckBoxElementBase.Enabled != chkEnabled.Checked)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Enabled", xTextCheckBoxElementBase.Enabled, chkEnabled.Checked, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.Enabled = chkEnabled.Checked;
					flag = true;
				}
				if (xTextCheckBoxElementBase.CheckAlignLeft != chkCheckAlignLeft.Checked)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("CheckAlignLeft", xTextCheckBoxElementBase.CheckAlignLeft, chkCheckAlignLeft.Checked, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.CheckAlignLeft = chkCheckAlignLeft.Checked;
					flag = true;
				}
				if (xTextCheckBoxElementBase.Requried != chkRequired.Checked)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Requried", xTextCheckBoxElementBase.Requried, chkRequired.Checked, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.Requried = chkRequired.Checked;
					flag = true;
				}
				PrintVisibilityModeWhenUnchecked selectedIndex3 = (PrintVisibilityModeWhenUnchecked)cboPrintVisibilityWhenUnchecked.SelectedIndex;
				if (xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked != selectedIndex3)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("PrintVisibilityWhenUnchecked", xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked, selectedIndex3, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked = selectedIndex3;
					flag = true;
				}
				WriterUtils.smethod_27(xTextCheckBoxElementBase, "ID", txtID.Text.Trim(), flag2);
				text = txtTag.Text;
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextCheckBoxElementBase.StringTag != text)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Tag", xTextCheckBoxElementBase.StringTag, text, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.StringTag = text;
					flag = true;
				}
				text = txtCaption.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextCheckBoxElementBase.Caption != text)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Caption", xTextCheckBoxElementBase.Caption, text, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.Caption = text;
					xTextCheckBoxElementBase.SizeInvalid = true;
					xTextCheckBoxElementBase.Width = 0f;
					xTextCheckBoxElementBase.Height = 0f;
					flag = true;
				}
				text = txtTooltip.Text;
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextCheckBoxElementBase.ToolTip != text)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("ToolTip", xTextCheckBoxElementBase.ToolTip, text, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.ToolTip = text;
					flag = true;
				}
				text = txtValue.Text;
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextCheckBoxElementBase.CheckedValue != text)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("CheckedValue", xTextCheckBoxElementBase.CheckedValue, text, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.CheckedValue = text;
					flag = true;
				}
				if (xTextCheckBoxElementBase.Multiline != chkMultiline.Checked)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Multiline", xTextCheckBoxElementBase.Multiline, chkMultiline.Checked, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.Multiline = chkDeleteable.Checked;
					flag = true;
				}
				if (xTextCheckBoxElementBase.Deleteable != chkDeleteable.Checked)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Deleteable", xTextCheckBoxElementBase.Deleteable, chkDeleteable.Checked, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.Deleteable = chkDeleteable.Checked;
					flag = true;
				}
				text = txtName.Text;
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextCheckBoxElementBase.Name != text)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Name", xTextCheckBoxElementBase.Name, text, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.Name = text;
					flag = true;
				}
				XDataBinding xDataBinding = (XDataBinding)txtBinding.Tag;
				if (xDataBinding != xTextCheckBoxElementBase.ValueBinding)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("ValueBinding", xTextCheckBoxElementBase.ValueBinding, xDataBinding, xTextCheckBoxElementBase);
					}
					xTextCheckBoxElementBase.ValueBinding = xDataBinding;
					flag = true;
				}
				if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
				{
					if (flag)
					{
						base.DialogResult = DialogResult.OK;
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.Document = xTextCheckBoxElementBase.OwnerDocument;
						contentChangedEventArgs.Element = xTextCheckBoxElementBase;
						contentChangedEventArgs.LoadingDocument = false;
						xTextCheckBoxElementBase.EditorRefreshView();
						xTextCheckBoxElementBase.Parent.method_23(contentChangedEventArgs);
					}
				}
				else
				{
					base.DialogResult = DialogResult.OK;
				}
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnBrowseEventExpressions_Click(object sender, EventArgs e)
		{
			int num = 2;
			using (dlgEventExpressionInfos dlgEventExpressionInfos = new dlgEventExpressionInfos())
			{
				EventExpressionInfoList eventExpressionInfoList = (EventExpressionInfoList)txtEventExpressions.Tag;
				eventExpressionInfoList = (dlgEventExpressionInfos.InputExpressions = ((eventExpressionInfoList != null) ? eventExpressionInfoList.Clone() : new EventExpressionInfoList()));
				dlgEventExpressionInfos.Document = SourceEventArgs.Document;
				if (dlgEventExpressionInfos.ShowDialog(this) == DialogResult.OK)
				{
					EventExpressionInfoList inputExpressions = dlgEventExpressionInfos.InputExpressions;
					txtEventExpressions.Tag = inputExpressions;
					txtEventExpressions.Text = inputExpressions.ToString();
					if (inputExpressions != null)
					{
						txtCheckedCascadeContainerName.Text = "";
						txtUnCheckedCascadeContainerName.Text = "";
						foreach (EventExpressionInfo item in inputExpressions)
						{
							if (item.EventName == "ContentChanged" && item.Target == EventExpressionTarget.NextElement)
							{
								if (GClass52.smethod_0(item.Expression, "this.Checked=true"))
								{
									txtCheckedCascadeContainerName.Text = item.Expression;
								}
								else if (GClass52.smethod_0(item.Expression, "this.Checked=false"))
								{
									txtUnCheckedCascadeContainerName.Text = item.Expression;
								}
							}
						}
					}
				}
			}
		}

		private void btnBrowseBinding_Click(object sender, EventArgs e)
		{
			if (SourceEventArgs != null)
			{
				using (dlgXDataBinding dlgXDataBinding = new dlgXDataBinding())
				{
					dlgXDataBinding.XDataBinding = (XDataBinding)txtBinding.Tag;
					dlgXDataBinding.Document = SourceEventArgs.Document;
					if (dlgXDataBinding.ShowDialog(this) == DialogResult.OK)
					{
						txtBinding.Tag = dlgXDataBinding.XDataBinding.Clone();
						txtBinding.Text = dlgXDataBinding.XDataBinding.ToString();
					}
				}
			}
		}
	}
}
