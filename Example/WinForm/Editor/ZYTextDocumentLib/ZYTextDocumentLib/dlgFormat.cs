using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class dlgFormat : Form
	{
		private Label label1;

		private Button cmdNew;

		private Button cmdDelete;

		private ListView lvwItem;

		private ColumnHeader aaaa;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private Button cmdOK;

		private Container components = null;

		private ContextMenu myMenu;

		public StringDataFormat myFormat;

		private MenuItem menuMin;

		private MenuItem menuMax;

		private MenuItem menuInteger;

		private MenuItem menuDouble;

		private MenuItem menuNoNull;

		private MenuItem menuInList;

		private MenuItem menuNotInList;

		private MenuItem menuDate;

		private MenuItem menuMinLength;

		private MenuItem menuMaxLength;

		public bool bolModify = false;

		public void RefreshView(StringDataFormatItem SelectedItem)
		{
			lvwItem.Items.Clear();
			if (myFormat != null)
			{
				int num = 0;
				foreach (StringDataFormatItem item in myFormat.Items)
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.Text = (item.CanEditSetting() ? item.SettingValue : "不能编辑");
					listViewItem.SubItems.Add(item.DisplayName);
					listViewItem.SubItems.Add(num.ToString());
					listViewItem.Tag = item;
					lvwItem.Items.Add(listViewItem);
					if (item == SelectedItem)
					{
						listViewItem.Selected = true;
						listViewItem.Focused = true;
						listViewItem.EnsureVisible();
					}
					num++;
				}
			}
		}

		public dlgFormat()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			cmdNew = new System.Windows.Forms.Button();
			cmdDelete = new System.Windows.Forms.Button();
			lvwItem = new System.Windows.Forms.ListView();
			aaaa = new System.Windows.Forms.ColumnHeader();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			cmdOK = new System.Windows.Forms.Button();
			myMenu = new System.Windows.Forms.ContextMenu();
			menuMin = new System.Windows.Forms.MenuItem();
			menuMax = new System.Windows.Forms.MenuItem();
			menuInteger = new System.Windows.Forms.MenuItem();
			menuDouble = new System.Windows.Forms.MenuItem();
			menuNoNull = new System.Windows.Forms.MenuItem();
			menuInList = new System.Windows.Forms.MenuItem();
			menuNotInList = new System.Windows.Forms.MenuItem();
			menuDate = new System.Windows.Forms.MenuItem();
			menuMinLength = new System.Windows.Forms.MenuItem();
			menuMaxLength = new System.Windows.Forms.MenuItem();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(283, 17);
			label1.TabIndex = 0;
			label1.Text = "格式判断条件列表 (该列表中靠上的项目优先级高)";
			cmdNew.Location = new System.Drawing.Point(16, 24);
			cmdNew.Name = "cmdNew";
			cmdNew.TabIndex = 1;
			cmdNew.Text = "新增";
			cmdNew.Click += new System.EventHandler(cmdNew_Click);
			cmdDelete.Location = new System.Drawing.Point(104, 24);
			cmdDelete.Name = "cmdDelete";
			cmdDelete.TabIndex = 3;
			cmdDelete.Text = "删除(&D)";
			cmdDelete.Click += new System.EventHandler(cmdDelete_Click);
			lvwItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
			{
				aaaa,
				columnHeader1,
				columnHeader2
			});
			lvwItem.FullRowSelect = true;
			lvwItem.GridLines = true;
			lvwItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			lvwItem.HideSelection = false;
			lvwItem.LabelEdit = true;
			lvwItem.Location = new System.Drawing.Point(16, 48);
			lvwItem.MultiSelect = false;
			lvwItem.Name = "lvwItem";
			lvwItem.Size = new System.Drawing.Size(384, 208);
			lvwItem.TabIndex = 6;
			lvwItem.View = System.Windows.Forms.View.Details;
			lvwItem.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(lvwItem_AfterLabelEdit);
			lvwItem.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(lvwItem_BeforeLabelEdit);
			aaaa.Text = "设置值";
			aaaa.Width = 150;
			columnHeader1.Text = "说明";
			columnHeader1.Width = 150;
			columnHeader2.Text = "序号";
			cmdOK.Location = new System.Drawing.Point(320, 272);
			cmdOK.Name = "cmdOK";
			cmdOK.TabIndex = 7;
			cmdOK.Text = "关闭(&C)";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			myMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[10]
			{
				menuMin,
				menuMax,
				menuInteger,
				menuDouble,
				menuNoNull,
				menuInList,
				menuNotInList,
				menuDate,
				menuMinLength,
				menuMaxLength
			});
			menuMin.Index = 0;
			menuMin.Text = "最小值限制";
			menuMin.Click += new System.EventHandler(menuMin_Click);
			menuMax.Index = 1;
			menuMax.Text = "最大值限制";
			menuMax.Click += new System.EventHandler(menuMax_Click);
			menuInteger.Index = 2;
			menuInteger.Text = "整数格式限制";
			menuInteger.Click += new System.EventHandler(menuInteger_Click);
			menuDouble.Index = 3;
			menuDouble.Text = "实数格式限制";
			menuDouble.Click += new System.EventHandler(menuDouble_Click);
			menuNoNull.Index = 4;
			menuNoNull.Text = "不得为空";
			menuNoNull.Click += new System.EventHandler(menuNoNull_Click);
			menuInList.Index = 5;
			menuInList.Text = "在指定列表中";
			menuInList.Click += new System.EventHandler(menuInList_Click);
			menuNotInList.Index = 6;
			menuNotInList.Text = "不在指定列表中";
			menuNotInList.Click += new System.EventHandler(menuNotInList_Click);
			menuDate.Index = 7;
			menuDate.Text = "为时间日期格式";
			menuDate.Click += new System.EventHandler(menuDate_Click);
			menuMinLength.Index = 8;
			menuMinLength.Text = "文本最小长度";
			menuMinLength.Click += new System.EventHandler(menuMinLength_Click);
			menuMaxLength.Index = 9;
			menuMaxLength.Text = "文本最大长度";
			menuMaxLength.Click += new System.EventHandler(menuMaxLength_Click);
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			base.ClientSize = new System.Drawing.Size(418, 303);
			base.Controls.Add(cmdOK);
			base.Controls.Add(lvwItem);
			base.Controls.Add(cmdDelete);
			base.Controls.Add(cmdNew);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFormat";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "数据格式判断";
			base.Load += new System.EventHandler(dlgFormat_Load);
			ResumeLayout(false);
		}

		private void lvwItem_BeforeLabelEdit(object sender, LabelEditEventArgs e)
		{
			StringDataFormatItem stringDataFormatItem = lvwItem.Items[e.Item].Tag as StringDataFormatItem;
			if (stringDataFormatItem != null && !stringDataFormatItem.CanEditSetting())
			{
				e.CancelEdit = true;
			}
		}

		private void lvwItem_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			StringDataFormatItem stringDataFormatItem = lvwItem.Items[e.Item].Tag as StringDataFormatItem;
			if (stringDataFormatItem != null && e.Label != null && stringDataFormatItem.CanEditSetting())
			{
				stringDataFormatItem.SettingValue = e.Label;
				lvwItem.Items[e.Item].Text = stringDataFormatItem.SettingValue;
				lvwItem.Items[e.Item].SubItems[1].Text = stringDataFormatItem.DisplayName;
				bolModify = true;
			}
		}

		private void cmdNew_Click(object sender, EventArgs e)
		{
			myMenu.Show(cmdNew, new Point(0, cmdNew.Height));
		}

		private void cmdDelete_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem selectedItem in lvwItem.SelectedItems)
			{
				myFormat.Items.Remove(selectedItem.Tag);
				lvwItem.Items.Remove(selectedItem);
				bolModify = true;
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgFormat_Load(object sender, EventArgs e)
		{
			RefreshView(null);
		}

		private void menuMin_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("min");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuMax_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("max");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuInteger_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("integer");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuDouble_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("double");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuNoNull_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("notnull");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuInList_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("inlist");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuNotInList_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("notinlist");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuDate_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("date");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuMinLength_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("minlength");
			RefreshView(selectedItem);
			bolModify = true;
		}

		private void menuMaxLength_Click(object sender, EventArgs e)
		{
			StringDataFormatItem selectedItem = myFormat.NewItem("maxlength");
			RefreshView(selectedItem);
			bolModify = true;
		}
	}
}
