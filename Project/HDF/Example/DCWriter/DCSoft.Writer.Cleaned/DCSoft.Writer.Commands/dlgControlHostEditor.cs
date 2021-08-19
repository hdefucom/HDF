using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       控件承载元素编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgControlHostEditor : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtName;

		private Label label3;

		private TextBox txtTypeFullName;

		private Button cmdBrowseType;

		private GroupBox grbPreview;

		private Label label4;

		private ComboBox cboHostMode;

		private CheckBox chkAllowUserChangeWidth;

		private TabControl myTabControl;

		private TabPage pageCommon;

		private TabPage pageParameter;

		private DataGridView dgvParameter;

		private DataGridViewTextBoxColumn colParameterName;

		private DataGridViewTextBoxColumn colParameterValue;

		private TabPage pageProperty;

		private PropertyGrid pgControlProperty;

		private CheckBox chkSavePreviewImage;

		private Button cmdOK;

		private Button cmdCancel;

		private TabPage tabPage1;

		private TextBox txtDebug;

		private CheckBox chkAllowUserChangeHeight;

		private Label label5;

		private ComboBox cboValuePropertyName;

		private Label label6;

		private TextBox txtBackgroundText;

		private Panel pnlPreview;

		private ComboBox cboControlType;

		private Label label7;

		private CheckBox chkDelayLoadControl;

		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private bool bool_0 = true;

		private Size size_0 = Size.Empty;

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
		///       设置元素大小
		///       </summary>
		public bool SetElementSize
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgControlHostEditor));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtTypeFullName = new System.Windows.Forms.TextBox();
			cmdBrowseType = new System.Windows.Forms.Button();
			grbPreview = new System.Windows.Forms.GroupBox();
			pnlPreview = new System.Windows.Forms.Panel();
			label4 = new System.Windows.Forms.Label();
			cboHostMode = new System.Windows.Forms.ComboBox();
			chkAllowUserChangeWidth = new System.Windows.Forms.CheckBox();
			myTabControl = new System.Windows.Forms.TabControl();
			pageCommon = new System.Windows.Forms.TabPage();
			label5 = new System.Windows.Forms.Label();
			cboValuePropertyName = new System.Windows.Forms.ComboBox();
			chkSavePreviewImage = new System.Windows.Forms.CheckBox();
			chkAllowUserChangeHeight = new System.Windows.Forms.CheckBox();
			cboControlType = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			txtBackgroundText = new System.Windows.Forms.TextBox();
			pageParameter = new System.Windows.Forms.TabPage();
			dgvParameter = new System.Windows.Forms.DataGridView();
			colParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			pageProperty = new System.Windows.Forms.TabPage();
			pgControlProperty = new System.Windows.Forms.PropertyGrid();
			tabPage1 = new System.Windows.Forms.TabPage();
			txtDebug = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			chkDelayLoadControl = new System.Windows.Forms.CheckBox();
			grbPreview.SuspendLayout();
			myTabControl.SuspendLayout();
			pageCommon.SuspendLayout();
			pageParameter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvParameter).BeginInit();
			pageProperty.SuspendLayout();
			tabPage1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtTypeFullName, "txtTypeFullName");
			txtTypeFullName.Name = "txtTypeFullName";
			txtTypeFullName.Validated += new System.EventHandler(txtBackgroundText_Validated);
			resources.ApplyResources(cmdBrowseType, "cmdBrowseType");
			cmdBrowseType.Name = "cmdBrowseType";
			cmdBrowseType.UseVisualStyleBackColor = true;
			cmdBrowseType.Click += new System.EventHandler(cmdBrowseType_Click);
			grbPreview.Controls.Add(pnlPreview);
			resources.ApplyResources(grbPreview, "grbPreview");
			grbPreview.Name = "grbPreview";
			grbPreview.TabStop = false;
			pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(pnlPreview, "pnlPreview");
			pnlPreview.Name = "pnlPreview";
			pnlPreview.Paint += new System.Windows.Forms.PaintEventHandler(pnlPreview_Paint);
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			cboHostMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboHostMode.FormattingEnabled = true;
			cboHostMode.Items.AddRange(new object[3]
			{
				resources.GetString("cboHostMode.Items"),
				resources.GetString("cboHostMode.Items1"),
				resources.GetString("cboHostMode.Items2")
			});
			resources.ApplyResources(cboHostMode, "cboHostMode");
			cboHostMode.Name = "cboHostMode";
			resources.ApplyResources(chkAllowUserChangeWidth, "chkAllowUserChangeWidth");
			chkAllowUserChangeWidth.Name = "chkAllowUserChangeWidth";
			chkAllowUserChangeWidth.UseVisualStyleBackColor = true;
			myTabControl.Controls.Add(pageCommon);
			myTabControl.Controls.Add(pageParameter);
			myTabControl.Controls.Add(pageProperty);
			myTabControl.Controls.Add(tabPage1);
			resources.ApplyResources(myTabControl, "myTabControl");
			myTabControl.Name = "myTabControl";
			myTabControl.SelectedIndex = 0;
			pageCommon.Controls.Add(chkDelayLoadControl);
			pageCommon.Controls.Add(label5);
			pageCommon.Controls.Add(cboValuePropertyName);
			pageCommon.Controls.Add(txtName);
			pageCommon.Controls.Add(chkSavePreviewImage);
			pageCommon.Controls.Add(chkAllowUserChangeHeight);
			pageCommon.Controls.Add(chkAllowUserChangeWidth);
			pageCommon.Controls.Add(label1);
			pageCommon.Controls.Add(txtID);
			pageCommon.Controls.Add(label2);
			pageCommon.Controls.Add(cboControlType);
			pageCommon.Controls.Add(cboHostMode);
			pageCommon.Controls.Add(label6);
			pageCommon.Controls.Add(label7);
			pageCommon.Controls.Add(label3);
			pageCommon.Controls.Add(label4);
			pageCommon.Controls.Add(txtBackgroundText);
			pageCommon.Controls.Add(txtTypeFullName);
			pageCommon.Controls.Add(cmdBrowseType);
			resources.ApplyResources(pageCommon, "pageCommon");
			pageCommon.Name = "pageCommon";
			pageCommon.UseVisualStyleBackColor = true;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			cboValuePropertyName.FormattingEnabled = true;
			resources.ApplyResources(cboValuePropertyName, "cboValuePropertyName");
			cboValuePropertyName.Name = "cboValuePropertyName";
			resources.ApplyResources(chkSavePreviewImage, "chkSavePreviewImage");
			chkSavePreviewImage.Name = "chkSavePreviewImage";
			chkSavePreviewImage.UseVisualStyleBackColor = true;
			chkSavePreviewImage.CheckedChanged += new System.EventHandler(chkSavePreviewImage_CheckedChanged);
			resources.ApplyResources(chkAllowUserChangeHeight, "chkAllowUserChangeHeight");
			chkAllowUserChangeHeight.Name = "chkAllowUserChangeHeight";
			chkAllowUserChangeHeight.UseVisualStyleBackColor = true;
			cboControlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboControlType.FormattingEnabled = true;
			cboControlType.Items.AddRange(new object[5]
			{
				resources.GetString("cboControlType.Items"),
				resources.GetString("cboControlType.Items1"),
				resources.GetString("cboControlType.Items2"),
				resources.GetString("cboControlType.Items3"),
				resources.GetString("cboControlType.Items4")
			});
			resources.ApplyResources(cboControlType, "cboControlType");
			cboControlType.Name = "cboControlType";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(txtBackgroundText, "txtBackgroundText");
			txtBackgroundText.Name = "txtBackgroundText";
			txtBackgroundText.Validated += new System.EventHandler(txtBackgroundText_Validated);
			pageParameter.Controls.Add(dgvParameter);
			resources.ApplyResources(pageParameter, "pageParameter");
			pageParameter.Name = "pageParameter";
			pageParameter.UseVisualStyleBackColor = true;
			dgvParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvParameter.Columns.AddRange(colParameterName, colParameterValue);
			resources.ApplyResources(dgvParameter, "dgvParameter");
			dgvParameter.Name = "dgvParameter";
			dgvParameter.RowTemplate.Height = 23;
			dgvParameter.Validated += new System.EventHandler(dgvParameter_Validated);
			resources.ApplyResources(colParameterName, "colParameterName");
			colParameterName.Name = "colParameterName";
			resources.ApplyResources(colParameterValue, "colParameterValue");
			colParameterValue.Name = "colParameterValue";
			pageProperty.Controls.Add(pgControlProperty);
			resources.ApplyResources(pageProperty, "pageProperty");
			pageProperty.Name = "pageProperty";
			pageProperty.UseVisualStyleBackColor = true;
			resources.ApplyResources(pgControlProperty, "pgControlProperty");
			pgControlProperty.Name = "pgControlProperty";
			pgControlProperty.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(pgControlProperty_PropertyValueChanged);
			tabPage1.Controls.Add(txtDebug);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			resources.ApplyResources(txtDebug, "txtDebug");
			txtDebug.Name = "txtDebug";
			txtDebug.ReadOnly = true;
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.UseVisualStyleBackColor = true;
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.UseVisualStyleBackColor = true;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(chkDelayLoadControl, "chkDelayLoadControl");
			chkDelayLoadControl.Name = "chkDelayLoadControl";
			chkDelayLoadControl.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(myTabControl);
			base.Controls.Add(grbPreview);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgControlHostEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgControlHostEditor_Load);
			grbPreview.ResumeLayout(false);
			myTabControl.ResumeLayout(false);
			pageCommon.ResumeLayout(false);
			pageCommon.PerformLayout();
			pageParameter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvParameter).EndInit();
			pageProperty.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgControlHostEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgControlHostEditor_Load(object sender, EventArgs e)
		{
			try
			{
				if (SourceEventArgs != null && SourceEventArgs.WriterControl != null)
				{
					Text = SourceEventArgs.WriterControl.DialogTitlePrefix + Text;
				}
				if (SourceEventArgs != null && SourceEventArgs.Element != null)
				{
					XTextControlHostElement xTextControlHostElement = (XTextControlHostElement)SourceEventArgs.Element;
					txtID.Text = xTextControlHostElement.ID;
					txtName.Text = xTextControlHostElement.Name;
					txtTypeFullName.Text = xTextControlHostElement.TypeFullName;
					chkAllowUserChangeWidth.Checked = (xTextControlHostElement.AllowUserResize == ResizeableType.Width || xTextControlHostElement.AllowUserResize == ResizeableType.WidthAndHeight);
					chkAllowUserChangeHeight.Checked = (xTextControlHostElement.AllowUserResize == ResizeableType.Height || xTextControlHostElement.AllowUserResize == ResizeableType.WidthAndHeight);
					chkSavePreviewImage.Checked = xTextControlHostElement.SavePreviewImage;
					cboValuePropertyName.Text = xTextControlHostElement.ValuePropertyName;
					cboControlType.SelectedIndex = (int)xTextControlHostElement.ControlType;
					chkDelayLoadControl.Checked = xTextControlHostElement.DelayLoadControl;
					if (xTextControlHostElement.HostMode == ObjectHostMode.Disable)
					{
						cboHostMode.SelectedIndex = 0;
					}
					else if (xTextControlHostElement.HostMode == ObjectHostMode.Static)
					{
						cboHostMode.SelectedIndex = 1;
					}
					else if (xTextControlHostElement.HostMode == ObjectHostMode.Dynamic)
					{
						cboHostMode.SelectedIndex = 2;
					}
					method_2(xTextControlHostElement, bool_1: false);
				}
			}
			catch (Exception)
			{
			}
		}

		private object method_0(string string_0, bool bool_1)
		{
			Type controlType = ControlHelper.GetControlType(string_0, null);
			object obj = method_1();
			if (obj != null)
			{
				XTextControlHostElement xTextControlHostElement = SourceEventArgs.Element as XTextControlHostElement;
				xTextControlHostElement.vmethod_30(obj);
				if (obj is Control)
				{
					Control control = (Control)obj;
					if (!(controlType?.Equals(control.GetType()) ?? false))
					{
						size_0 = Size.Empty;
						pnlPreview.Controls.Remove(control);
						control.Dispose();
						obj = null;
					}
				}
				else if (obj is IDocumentImage)
				{
					if (!(controlType?.Equals(obj.GetType()) ?? false))
					{
						size_0 = Size.Empty;
						pnlPreview.Tag = null;
						if (obj is IDisposable)
						{
							((IDisposable)obj).Dispose();
						}
						obj = null;
					}
				}
				else if (GClass129.smethod_4(obj) && !(controlType?.Equals(obj.GetType()) ?? false))
				{
					size_0 = Size.Empty;
					if (pnlPreview.Controls.Count > 0)
					{
						Control control = pnlPreview.Controls[0];
						pnlPreview.Controls.Clear();
						control.Dispose();
					}
					obj = null;
				}
			}
			if (controlType != null)
			{
				if (typeof(Control).IsAssignableFrom(controlType))
				{
					if (obj == null)
					{
						Control control = (Control)Activator.CreateInstance(controlType);
						obj = control;
						pnlPreview.Controls.Add(control);
						if (!control.IsHandleCreated)
						{
							control.CreateControl();
						}
						size_0 = control.Size;
						control.Dock = DockStyle.Fill;
					}
				}
				else if (typeof(IDocumentImage).IsAssignableFrom(controlType))
				{
					if (obj == null)
					{
						size_0 = Size.Empty;
						obj = Activator.CreateInstance(controlType);
						pnlPreview.Tag = obj;
					}
				}
				else if (GClass129.smethod_3(controlType) && obj == null)
				{
					obj = Activator.CreateInstance(controlType);
					size_0 = GClass129.smethod_8(obj);
					Control control = GClass129.smethod_5(obj);
					control.Dock = DockStyle.Fill;
					pnlPreview.Controls.Add(control);
				}
			}
			int num = base.Width - base.ClientSize.Width + 5;
			if (obj == null)
			{
				if (!myTabControl.TabPages.Contains(pageParameter))
				{
					myTabControl.TabPages.Add(pageParameter);
				}
				if (myTabControl.TabPages.Contains(pageProperty))
				{
					myTabControl.TabPages.Remove(pageProperty);
				}
				base.Width = myTabControl.Right + num;
			}
			else
			{
				if (myTabControl.TabPages.Contains(pageParameter))
				{
					myTabControl.TabPages.Remove(pageParameter);
				}
				if (!myTabControl.TabPages.Contains(pageProperty))
				{
					myTabControl.TabPages.Add(pageProperty);
				}
				pgControlProperty.SelectedObject = obj;
				base.Width = grbPreview.Right + num;
			}
			return obj;
		}

		private object method_1()
		{
			if (pnlPreview.Controls.Count > 0)
			{
				return pnlPreview.Controls[0];
			}
			return pnlPreview.Tag;
		}

		private bool method_2(XTextControlHostElement xtextControlHostElement_0, bool bool_1)
		{
			try
			{
				object obj = method_1();
				object obj2 = method_0(txtTypeFullName.Text.Trim(), bool_1: true);
				if (obj != obj2)
				{
					cboValuePropertyName.Items.Clear();
					List<string> list = new List<string>();
					if (obj2 != null)
					{
						foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj2))
						{
							if (!property.IsReadOnly && property.SerializationVisibility != 0)
							{
								list.Add(property.Name);
							}
						}
						list.Sort();
						cboValuePropertyName.Items.AddRange(list.ToArray());
						PropertyDescriptor defaultProperty = TypeDescriptor.GetDefaultProperty(obj2.GetType());
						if (defaultProperty != null)
						{
							cboValuePropertyName.Text = defaultProperty.Name;
						}
					}
				}
				if (xtextControlHostElement_0 != null && obj2 != null)
				{
					try
					{
						xtextControlHostElement_0.vmethod_30(obj2);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				txtDebug.AppendText(ex.ToString() + Environment.NewLine);
				return false;
			}
		}

		private void txtBackgroundText_Validated(object sender, EventArgs e)
		{
			method_2(null, bool_1: true);
		}

		private void dgvParameter_Validated(object sender, EventArgs e)
		{
			method_2(null, bool_1: false);
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			int num = 17;
			try
			{
				if (SourceEventArgs != null && SourceEventArgs.Element != null)
				{
					XTextDocument document = elementPropertiesEditEventArgs_0.Document;
					XTextControlHostElement xTextControlHostElement = (XTextControlHostElement)SourceEventArgs.Element;
					bool flag = SourceEventArgs.LogUndo && document.CanLogUndo;
					string text = txtID.Text.Trim();
					bool flag2 = false;
					if (!WriterUtils.smethod_43(text, xTextControlHostElement.ID))
					{
						if (flag)
						{
							document.UndoList.AddProperty("ID", xTextControlHostElement.ID, text, xTextControlHostElement);
						}
						xTextControlHostElement.ID = text;
						flag2 = true;
					}
					text = txtName.Text.Trim();
					if (!WriterUtils.smethod_43(text, xTextControlHostElement.Name))
					{
						if (flag)
						{
							document.UndoList.AddProperty("Name", xTextControlHostElement.Name, text, xTextControlHostElement);
						}
						xTextControlHostElement.Name = text;
						flag2 = true;
					}
					text = txtTypeFullName.Text.Trim();
					if (!WriterUtils.smethod_43(text, xTextControlHostElement.TypeFullName))
					{
						if (flag)
						{
							document.UndoList.AddProperty("TypeFullName", xTextControlHostElement.TypeFullName, text, xTextControlHostElement);
						}
						xTextControlHostElement.TypeFullName = text;
						flag2 = true;
					}
					ObjectHostMode objectHostMode = ObjectHostMode.Disable;
					switch (cboHostMode.SelectedIndex)
					{
					case 0:
						objectHostMode = ObjectHostMode.Disable;
						break;
					case 1:
						objectHostMode = ObjectHostMode.Static;
						break;
					case 2:
						objectHostMode = ObjectHostMode.Dynamic;
						break;
					}
					if (objectHostMode != xTextControlHostElement.HostMode)
					{
						if (flag)
						{
							document.UndoList.AddProperty("HostMode", xTextControlHostElement.HostMode, objectHostMode, xTextControlHostElement);
						}
						xTextControlHostElement.HostMode = objectHostMode;
						flag2 = true;
					}
					HostedControlType selectedIndex = (HostedControlType)cboControlType.SelectedIndex;
					if (selectedIndex != xTextControlHostElement.ControlType)
					{
						if (flag)
						{
							document.UndoList.AddProperty("ControlType", xTextControlHostElement.ControlType, selectedIndex, xTextControlHostElement);
						}
						xTextControlHostElement.ControlType = selectedIndex;
						flag2 = true;
					}
					ResizeableType resizeableType = ResizeableType.FixSize;
					resizeableType = (chkAllowUserChangeHeight.Checked ? ((!chkAllowUserChangeWidth.Checked) ? ResizeableType.Height : ResizeableType.WidthAndHeight) : (chkAllowUserChangeWidth.Checked ? ResizeableType.Width : ResizeableType.FixSize));
					if (resizeableType != xTextControlHostElement.AllowUserResize)
					{
						if (flag)
						{
							document.UndoList.AddProperty("AllowUserResize", xTextControlHostElement.AllowUserResize, resizeableType, xTextControlHostElement);
						}
						xTextControlHostElement.AllowUserResize = resizeableType;
						flag2 = true;
					}
					if (chkSavePreviewImage.Checked != xTextControlHostElement.SavePreviewImage)
					{
						if (flag)
						{
							document.UndoList.AddProperty("SavePreviewImage", xTextControlHostElement.SavePreviewImage, chkSavePreviewImage.Checked, xTextControlHostElement);
						}
						xTextControlHostElement.SavePreviewImage = chkSavePreviewImage.Checked;
						flag2 = true;
					}
					if (chkDelayLoadControl.Checked != xTextControlHostElement.DelayLoadControl)
					{
						if (flag)
						{
							document.UndoList.AddProperty("DelayLoadControl", xTextControlHostElement.DelayLoadControl, chkDelayLoadControl.Checked, xTextControlHostElement);
						}
						xTextControlHostElement.DelayLoadControl = chkDelayLoadControl.Checked;
						flag2 = true;
					}
					text = cboValuePropertyName.Text.Trim();
					if (!WriterUtils.smethod_43(text, xTextControlHostElement.ValuePropertyName))
					{
						if (flag)
						{
							document.UndoList.AddProperty("ValuePropertyName", xTextControlHostElement.ValuePropertyName, text, xTextControlHostElement);
						}
						xTextControlHostElement.ValuePropertyName = text;
						flag2 = true;
					}
					if (!string.IsNullOrEmpty(xTextControlHostElement.ValuePropertyName))
					{
						object obj = method_1();
						if (obj != null)
						{
							string text2 = xTextControlHostElement.Text = ControlHelper.GetControlValue(obj, xTextControlHostElement.ValuePropertyName);
						}
					}
					if (myTabControl.TabPages.Contains(pageParameter))
					{
						ObjectParameterList objectParameterList = new ObjectParameterList();
						foreach (DataGridViewRow item in (IEnumerable)dgvParameter.Rows)
						{
							if (item.Index != dgvParameter.NewRowIndex)
							{
								ObjectParameter objectParameter = new ObjectParameter();
								objectParameter.Name = Convert.ToString(item.Cells[0].Value);
								objectParameter.Value = Convert.ToString(item.Cells[1].Value);
								objectParameterList.Add(objectParameter);
							}
						}
						if (flag)
						{
							document.UndoList.AddProperty("Parameters", xTextControlHostElement.Parameters, objectParameterList, xTextControlHostElement);
						}
						xTextControlHostElement.Parameters = objectParameterList;
						flag2 = true;
					}
					if (myTabControl.TabPages.Contains(pageProperty))
					{
						object obj = method_1();
						ObjectParameterList objectParameterList = new ObjectParameterList();
						PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
						foreach (PropertyDescriptor item2 in properties)
						{
							if (!(item2.Name == "Dock") && !(item2.Name == "Width") && !(item2.Name == "Height") && !(item2.Name == "Location") && !(item2.Name == "Size") && !(item2.Name == "Bounds") && !(item2.Name == "TabIndex") && !(item2.Name == "Visible") && string.Compare(item2.Name, cboValuePropertyName.Text, ignoreCase: true) != 0 && !item2.IsReadOnly && item2.IsBrowsable && item2.ShouldSerializeValue(obj) && item2.SerializationVisibility != 0)
							{
								object value = item2.GetValue(obj);
								if (value != null && (!(value is string) || !string.IsNullOrEmpty((string)value)))
								{
									string text3 = null;
									text3 = (item2.PropertyType.Equals(typeof(string)) ? ((string)value) : ((item2.Converter == null) ? Convert.ToString(value) : item2.Converter.ConvertToString(value)));
									ObjectParameter objectParameter2 = new ObjectParameter();
									objectParameter2.Name = item2.Name;
									objectParameter2.Value = text3;
									objectParameterList.Add(objectParameter2);
								}
							}
						}
						if (flag)
						{
							document.UndoList.AddProperty("Parameters", xTextControlHostElement.Parameters, objectParameterList, xTextControlHostElement);
						}
						xTextControlHostElement.Parameters = objectParameterList;
						flag2 = true;
						if (obj is IDocumentHostedObject)
						{
							IDocumentHostedObject documentHostedObject = (IDocumentHostedObject)obj;
							if (documentHostedObject != null && xTextControlHostElement.EnableViewState)
							{
								xTextControlHostElement.vmethod_31(documentHostedObject, bool_12: true);
							}
						}
					}
					if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
					{
						if (flag2)
						{
							xTextControlHostElement.ErrorMessage = null;
							base.DialogResult = DialogResult.OK;
						}
					}
					else
					{
						if (SetElementSize)
						{
							Size size = new Size(100, 100);
							if (!size_0.IsEmpty)
							{
								size = size_0;
							}
							if (size.Width < 10)
							{
								size.Width = 10;
							}
							if (size.Height < 10)
							{
								size.Height = 10;
							}
							SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(size.Width, size.Height), GraphicsUnit.Pixel, SourceEventArgs.Document.DocumentGraphicsUnit);
							sizeF.Width += XTextObjectElement.int_6 * 2;
							sizeF.Height += XTextObjectElement.int_6 * 2;
							xTextControlHostElement.Width = sizeF.Width;
							xTextControlHostElement.Height = sizeF.Height;
						}
						base.DialogResult = DialogResult.OK;
					}
					Close();
				}
			}
			catch (Exception)
			{
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cmdBrowseType_Click(object sender, EventArgs e)
		{
			try
			{
				using (dlgBrowseControlType dlgBrowseControlType = new dlgBrowseControlType())
				{
					dlgBrowseControlType.SelectedTypeName = txtTypeFullName.Text.Trim();
					if (dlgBrowseControlType.ShowDialog(this) == DialogResult.OK)
					{
						txtTypeFullName.Text = dlgBrowseControlType.SelectedTypeName;
						method_2(null, bool_1: true);
						txtBackgroundText.Text = txtTypeFullName.Text;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void chkSavePreviewImage_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void pgControlProperty_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
		{
			pnlPreview.Refresh();
		}

		private void pnlPreview_Paint(object sender, PaintEventArgs e)
		{
			if (SourceEventArgs != null && pnlPreview.Controls.Count == 0)
			{
				IDocumentImage documentImage = pnlPreview.Tag as IDocumentImage;
				if (documentImage != null)
				{
					RectangleF rectangleF = GraphicsUnitConvert.Convert(new RectangleF(10f, 10f, pnlPreview.ClientSize.Width - 20, pnlPreview.ClientSize.Height - 20), GraphicsUnit.Pixel, SourceEventArgs.Document.DocumentGraphicsUnit);
					DocumentPaintEventArgs documentPaintEventArgs = new DocumentPaintEventArgs(new DCGraphics(e.Graphics), rectangleF);
					documentPaintEventArgs.Graphics.PageUnit = SourceEventArgs.Document.DocumentGraphicsUnit;
					documentPaintEventArgs.ViewBounds = rectangleF;
					documentPaintEventArgs.ClientViewBounds = rectangleF;
					documentPaintEventArgs.Element = SourceEventArgs.Element;
					documentPaintEventArgs.Document = SourceEventArgs.Document;
					documentPaintEventArgs.RenderMode = DocumentRenderMode.Paint;
					documentPaintEventArgs.Render = SourceEventArgs.Document.Render;
					documentPaintEventArgs.Style = SourceEventArgs.Element.RuntimeStyle;
					documentImage.Draw(documentPaintEventArgs);
				}
			}
		}
	}
}
