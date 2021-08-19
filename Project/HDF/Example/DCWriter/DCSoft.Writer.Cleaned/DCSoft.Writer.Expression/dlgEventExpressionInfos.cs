using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Expression
{
	/// <summary>
	///       表达式编辑器对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgEventExpressionInfos : Form
	{
		private XTextDocument xtextDocument_0 = null;

		private XTextElement xtextElement_0 = null;

		private bool bool_0 = false;

		private EventExpressionInfoList eventExpressionInfoList_0 = null;

		private IContainer icontainer_0 = null;

		private DataGridView dvgExpression;

		private Label label1;

		private Button btnOK;

		private Button btnCancel;

		private DataGridViewComboBoxColumn colEventName;

		private DataGridViewTextBoxColumn colExpression;

		private DataGridViewComboBoxColumn colTarget;

		private DataGridViewTextBoxColumn colTargetID;

		private DataGridViewComboBoxColumn colTargetPropertyName;

		private DataGridViewButtonColumn colDelete;

		private Label label2;

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       当前文档元素对象
		///       </summary>
		public XTextElement InputElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
			}
		}

		/// <summary>
		///       列表发生改变标记
		///       </summary>
		public bool ListModified
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
		///       编辑的表达式信息列表
		///       </summary>
		public EventExpressionInfoList InputExpressions
		{
			get
			{
				return eventExpressionInfoList_0;
			}
			set
			{
				eventExpressionInfoList_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgEventExpressionInfos()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgEventExpressionInfos_Load(object sender, EventArgs e)
		{
			if (xtextDocument_0 == null)
			{
			}
			if (eventExpressionInfoList_0 != null)
			{
				foreach (EventExpressionInfo inputExpression in InputExpressions)
				{
					dvgExpression.Rows.Add(inputExpression.EventName, inputExpression.Expression, colTarget.Items[(int)inputExpression.Target], inputExpression.CustomTargetName, inputExpression.TargetPropertyName, WriterStrings.Delete);
				}
				bool_0 = false;
			}
		}

		private void dvgExpression_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == colDelete.Index && e.RowIndex != dvgExpression.NewRowIndex)
			{
				dvgExpression.Rows.RemoveAt(e.RowIndex);
				bool_0 = true;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!bool_0)
			{
				base.DialogResult = DialogResult.Cancel;
				Close();
			}
			if (eventExpressionInfoList_0 == null)
			{
				eventExpressionInfoList_0 = new EventExpressionInfoList();
			}
			eventExpressionInfoList_0.Clear();
			foreach (DataGridViewRow item in (IEnumerable)dvgExpression.Rows)
			{
				if (item.Index != dvgExpression.NewRowIndex)
				{
					EventExpressionInfo eventExpressionInfo = new EventExpressionInfo();
					eventExpressionInfo.EventName = Convert.ToString(item.Cells[0].Value);
					eventExpressionInfo.Expression = Convert.ToString(item.Cells[1].Value);
					if ((string)item.Cells[2].Value == (string)colTarget.Items[0])
					{
						eventExpressionInfo.Target = EventExpressionTarget.NextElement;
					}
					else
					{
						eventExpressionInfo.Target = EventExpressionTarget.Custom;
					}
					eventExpressionInfo.CustomTargetName = Convert.ToString(item.Cells[3].Value);
					eventExpressionInfo.TargetPropertyName = Convert.ToString(item.Cells[4].Value);
					eventExpressionInfoList_0.Add(eventExpressionInfo);
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dvgExpression_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			bool_0 = true;
		}

		private void dvgExpression_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			bool_0 = true;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Expression.dlgEventExpressionInfos));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			dvgExpression = new System.Windows.Forms.DataGridView();
			colEventName = new System.Windows.Forms.DataGridViewComboBoxColumn();
			colExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colTarget = new System.Windows.Forms.DataGridViewComboBoxColumn();
			colTargetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colTargetPropertyName = new System.Windows.Forms.DataGridViewComboBoxColumn();
			colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
			label1 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dvgExpression).BeginInit();
			SuspendLayout();
			dvgExpression.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			dvgExpression.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dvgExpression.Columns.AddRange(colEventName, colExpression, colTarget, colTargetID, colTargetPropertyName, colDelete);
			resources.ApplyResources(dvgExpression, "dvgExpression");
			dvgExpression.Name = "dvgExpression";
			dvgExpression.RowTemplate.Height = 23;
			dvgExpression.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dvgExpression_CellContentClick);
			dvgExpression.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dvgExpression_CellValueChanged);
			dvgExpression.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(dvgExpression_RowsAdded);
			resources.ApplyResources(colEventName, "colEventName");
			colEventName.Items.AddRange("ContentChanged");
			colEventName.Name = "colEventName";
			colEventName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			colEventName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			resources.ApplyResources(colExpression, "colExpression");
			colExpression.Name = "colExpression";
			resources.ApplyResources(colTarget, "colTarget");
			colTarget.Items.AddRange("下一个域", "自定义");
			colTarget.Name = "colTarget";
			colTarget.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			colTarget.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			resources.ApplyResources(colTargetID, "colTargetID");
			colTargetID.Name = "colTargetID";
			resources.ApplyResources(colTargetPropertyName, "colTargetPropertyName");
			colTargetPropertyName.Items.AddRange("Visible", "Text");
			colTargetPropertyName.Name = "colTargetPropertyName";
			colTargetPropertyName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			colTargetPropertyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.NullValue = "删除";
			colDelete.DefaultCellStyle = dataGridViewCellStyle;
			resources.ApplyResources(colDelete, "colDelete");
			colDelete.Name = "colDelete";
			colDelete.Text = "操作";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			label2.BackColor = System.Drawing.Color.White;
			label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(label2, "label2");
			label2.ForeColor = System.Drawing.Color.Red;
			label2.Name = "label2";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(label2);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(label1);
			base.Controls.Add(dvgExpression);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgEventExpressionInfos";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgEventExpressionInfos_Load);
			((System.ComponentModel.ISupportInitialize)dvgExpression).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
