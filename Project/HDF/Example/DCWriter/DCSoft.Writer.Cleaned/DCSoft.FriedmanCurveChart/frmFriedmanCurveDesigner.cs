using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       产程图设计器窗体
	///       </summary>
	[ComVisible(false)]
	[DCPublishAPI]
	public class frmFriedmanCurveDesigner : Form
	{
		/// <summary>
		///       Required designer variable.
		///       </summary>
		private IContainer components = null;

		private FriedmanCurveDesignerControl myDesignerControl;

		/// <summary>
		///       文档对象
		///       </summary>
		public FriedmanCurveDocument SourceDocument
		{
			get
			{
				return myDesignerControl.SourceDocument;
			}
			set
			{
				myDesignerControl.SourceDocument = value;
			}
		}

		/// <summary>
		///       控件对象
		///       </summary>
		public FriedmanCurveControl SourceControl
		{
			get
			{
				return myDesignerControl.SourceControl;
			}
			set
			{
				myDesignerControl.SourceControl = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public frmFriedmanCurveDesigner()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			myDesignerControl.EventOKButtonClick += myDesignerControl_EventOKButtonClick;
			myDesignerControl.EventCancelButtonClick += myDesignerControl_EventCancelButtonClick;
		}

		private void myDesignerControl_EventCancelButtonClick(object sender, EventArgs e)
		{
			Close();
		}

		private void myDesignerControl_EventOKButtonClick(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.FriedmanCurveChart.frmFriedmanCurveDesigner));
			myDesignerControl = new DCSoft.FriedmanCurveChart.FriedmanCurveDesignerControl();
			SuspendLayout();
			resources.ApplyResources(myDesignerControl, "myDesignerControl");
			myDesignerControl.Name = "myDesignerControl";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(myDesignerControl);
			base.MinimizeBox = false;
			base.Name = "frmFriedmanCurveDesigner";
			base.ShowInTaskbar = false;
			ResumeLayout(false);
		}
	}
}
