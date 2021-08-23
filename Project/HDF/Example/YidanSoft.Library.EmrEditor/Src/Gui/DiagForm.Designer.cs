namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    partial class DiagForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Insert = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcDiag = new DevExpress.XtraGrid.GridControl();
            this.gvDiag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtFliter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Down = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Up = new DevExpress.XtraEditors.SimpleButton();
            this.gcSelectDiag = new DevExpress.XtraGrid.GridControl();
            this.gvSelectDiag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFliter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSelectDiag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectDiag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.btn_Close);
            this.panelControl1.Controls.Add(this.btn_Insert);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 670);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(976, 73);
            this.panelControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "注：此处为病人所有诊断";
            // 
            // btn_Close
            // 
            this.btn_Close.Image = global::YidanSoft.Library.EmrEditor.Properties.Resources.png_NO;
            this.btn_Close.Location = new System.Drawing.Point(795, 23);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(94, 35);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Insert
            // 
            this.btn_Insert.Image = global::YidanSoft.Library.EmrEditor.Properties.Resources.png_OK;
            this.btn_Insert.Location = new System.Drawing.Point(680, 23);
            this.btn_Insert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(94, 35);
            this.btn_Insert.TabIndex = 4;
            this.btn_Insert.Text = "插入";
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcDiag);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(339, 670);
            this.panelControl2.TabIndex = 1;
            // 
            // gcDiag
            // 
            this.gcDiag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDiag.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDiag.Location = new System.Drawing.Point(2, 66);
            this.gcDiag.MainView = this.gvDiag;
            this.gcDiag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDiag.Name = "gcDiag";
            this.gcDiag.Size = new System.Drawing.Size(335, 602);
            this.gcDiag.TabIndex = 5;
            this.gcDiag.TabStop = false;
            this.gcDiag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDiag});
            this.gcDiag.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gcDiag_MouseDoubleClick);
            // 
            // gvDiag
            // 
            this.gvDiag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvDiag.GridControl = this.gcDiag;
            this.gvDiag.Name = "gvDiag";
            this.gvDiag.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDiag.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDiag.OptionsBehavior.Editable = false;
            this.gvDiag.OptionsBehavior.ReadOnly = true;
            this.gvDiag.OptionsCustomization.AllowFilter = false;
            this.gvDiag.OptionsMenu.EnableColumnMenu = false;
            this.gvDiag.OptionsMenu.EnableFooterMenu = false;
            this.gvDiag.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvDiag.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gvDiag.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gvDiag.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gvDiag.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 93;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.FieldName = "NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 196;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.txtFliter);
            this.panelControl4.Controls.Add(this.labelControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(335, 64);
            this.panelControl4.TabIndex = 4;
            // 
            // txtFliter
            // 
            this.txtFliter.Location = new System.Drawing.Point(70, 15);
            this.txtFliter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFliter.Name = "txtFliter";
            this.txtFliter.Size = new System.Drawing.Size(246, 25);
            this.txtFliter.TabIndex = 2;
            this.txtFliter.EditValueChanged += new System.EventHandler(this.txtFliter_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 19);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 18);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "筛选：";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.panelControl5);
            this.panelControl3.Controls.Add(this.gcSelectDiag);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(418, 0);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(558, 670);
            this.panelControl3.TabIndex = 2;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.btn_Down);
            this.panelControl5.Controls.Add(this.btn_Up);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl5.Location = new System.Drawing.Point(485, 2);
            this.panelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(71, 666);
            this.panelControl5.TabIndex = 6;
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(8, 279);
            this.btn_Down.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(50, 35);
            this.btn_Down.TabIndex = 7;
            this.btn_Down.Text = "↓";
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(8, 217);
            this.btn_Up.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(51, 35);
            this.btn_Up.TabIndex = 6;
            this.btn_Up.Text = "↑";
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // gcSelectDiag
            // 
            this.gcSelectDiag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSelectDiag.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSelectDiag.Location = new System.Drawing.Point(2, 2);
            this.gcSelectDiag.MainView = this.gvSelectDiag;
            this.gcSelectDiag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcSelectDiag.Name = "gcSelectDiag";
            this.gcSelectDiag.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcSelectDiag.Size = new System.Drawing.Size(554, 666);
            this.gcSelectDiag.TabIndex = 5;
            this.gcSelectDiag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSelectDiag});
            this.gcSelectDiag.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gcSelectDiag_MouseDoubleClick);
            // 
            // gvSelectDiag
            // 
            this.gvSelectDiag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvSelectDiag.GridControl = this.gcSelectDiag;
            this.gvSelectDiag.Name = "gvSelectDiag";
            this.gvSelectDiag.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvSelectDiag.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvSelectDiag.OptionsCustomization.AllowFilter = false;
            this.gvSelectDiag.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvSelectDiag.OptionsFilter.AllowFilterEditor = false;
            this.gvSelectDiag.OptionsMenu.EnableColumnMenu = false;
            this.gvSelectDiag.OptionsMenu.EnableFooterMenu = false;
            this.gvSelectDiag.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvSelectDiag.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gvSelectDiag.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gvSelectDiag.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gvSelectDiag.OptionsView.ColumnAutoWidth = false;
            this.gvSelectDiag.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "全选";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "check";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 41;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "编号";
            this.gridColumn3.FieldName = "DIAGCODE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 72;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "名称";
            this.gridColumn4.FieldName = "DIAGNAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 138;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "自定义名称";
            this.gridColumn5.FieldName = "DIAGCUSTUMNAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 400;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(350, 282);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 35);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "<<";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(350, 220);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 35);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = ">>";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // DiagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 743);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人诊断";
            this.Load += new System.EventHandler(this.DiagForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDiag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDiag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFliter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSelectDiag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectDiag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFliter;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl gcDiag;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDiag;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gcSelectDiag;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSelectDiag;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_Down;
        private DevExpress.XtraEditors.SimpleButton btn_Up;
        private DevExpress.XtraEditors.SimpleButton btn_Insert;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private System.Windows.Forms.Label label1;


    }
}