using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GetSystemStatusGUI;

public class Form1 : Form
{
	protected CPUForm cpuForm;

	protected RAMForm ramForm;

	protected DiskForm diskForm;

	protected NetworkForm networkForm;

	protected GPUForm gpuForm;

	private AboutBox1 aboutBox;

	private string iniFile = ".\\config.ini";

	private IContainer components = null;

	private CheckBox showCPU;

	private CheckBox showRAM;

	private CheckBox showDisk;

	private CheckBox showNetwork;

	private CheckBox showGPU;

	private Button buttonExit;

	private ComboBox cbUpdateInterval;

	private Label label1;

	private Button btnDiskRefresh;

	private Button btnNetworkRefresh;

	private ToolTip toolTip1;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem saveOpenedWindowLocationsToolStripMenuItem;

	private ToolStripMenuItem loadSavedLocationsToolStripMenuItem;

	private ToolStripMenuItem optionToolStripMenuItem;

	private ToolStripMenuItem doNotShowGPUAtStartToolStripMenuItem;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripMenuItem exitToolStripMenuItem;

	private ToolStripMenuItem helpToolStripMenuItem;

	private ToolStripMenuItem aboutToolStripMenuItem;

	public Form1()
	{
		InitializeComponent();
	}

	private void showCPU_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		if (checkBox.Checked)
		{
			if (cpuForm == null || cpuForm.IsDisposed)
			{
				cpuForm = new CPUForm(this);
			}
			cpuForm.Show();
		}
		else
		{
			cpuForm.Hide();
		}
	}

	public void DisableChecked(string target)
	{
		switch (target)
		{
		case "CPU":
			showCPU.Checked = false;
			break;
		case "RAM":
			showRAM.Checked = false;
			break;
		case "Disk":
			showDisk.Checked = false;
			break;
		case "Network":
			showNetwork.Checked = false;
			break;
		case "GPU":
			showGPU.Checked = false;
			break;
		case "noGPU":
			showGPU.Checked = false;
			showGPU.Enabled = false;
			showGPU.Text += " (No graphics detected)";
			break;
		case "noNetwork":
			showNetwork.Checked = false;
			showNetwork.Enabled = false;
			showNetwork.Text = "Show Network (No connections)";
			break;
		}
	}

	private void buttonExit_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		showCPU.Checked = true;
		showRAM.Checked = true;
		showDisk.Checked = true;
		showNetwork.Checked = true;
		bool flag = !bool.Parse(INIHelper.Read("DoNotShow", "GPU", "false", iniFile));
		doNotShowGPUAtStartToolStripMenuItem.Checked = !flag;
		if (Environment.OSVersion.Version.Major < 10)
		{
			showGPU.Enabled = false;
			showGPU.Text += " (Only available in Windows 10)";
		}
		else
		{
			showGPU.Checked = flag;
		}
		LoadSavedLocation();
	}

	private void showRAM_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		if (checkBox.Checked)
		{
			if (ramForm == null || ramForm.IsDisposed)
			{
				ramForm = new RAMForm(this);
			}
			ramForm.Show();
		}
		else
		{
			ramForm.Hide();
		}
	}

	private void showDisk_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		if (checkBox.Checked)
		{
			if (diskForm == null || diskForm.IsDisposed)
			{
				diskForm = new DiskForm(this);
			}
			diskForm.Show();
		}
		else
		{
			diskForm.Hide();
		}
	}

	private void showNetwork_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		if (checkBox.Checked)
		{
			if (networkForm == null || networkForm.IsDisposed)
			{
				networkForm = new NetworkForm(this);
			}
			if (!networkForm.IsDisposed)
			{
				networkForm.Show();
			}
		}
		else if (networkForm != null)
		{
			networkForm.Hide();
		}
	}

	private void showGPU_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		if (checkBox.Checked)
		{
			if (gpuForm == null || gpuForm.IsDisposed)
			{
				gpuForm = new GPUForm(this);
			}
			if (!gpuForm.IsDisposed)
			{
				gpuForm.Show();
				loadGPUFormLocation();
			}
		}
		else if (gpuForm != null)
		{
			gpuForm.Dispose();
		}
	}

	private void cbUpdateInterval_SelectedIndexChanged(object sender, EventArgs e)
	{
		ComboBox comboBox = (ComboBox)sender;
		switch (comboBox.Text)
		{
		case "1 sec":
			Global.interval_ms = 1000;
			break;
		case "2 sec":
			Global.interval_ms = 2000;
			break;
		case "0.5 sec":
			Global.interval_ms = 500;
			break;
		case "0.25 sec":
			Global.interval_ms = 250;
			break;
		default:
			cbUpdateInterval_TextChanged(sender, e);
			break;
		}
	}

	private void cbUpdateInterval_TextChanged(object sender, EventArgs e)
	{
		ComboBox comboBox = (ComboBox)sender;
		string text = comboBox.Text;
		try
		{
			string[] array = text.Split(' ');
			float num = float.Parse(array[0]);
			if (num == 0f)
			{
				return;
			}
			string text2 = array[1];
			switch (text2)
			{
			case "ms":
				Global.interval_ms = (int)Math.Round(num);
				break;
			default:
				if (!(text2 == "secs"))
				{
					break;
				}
				goto case "s";
			case "s":
			case "sec":
				Global.interval_ms = (int)Math.Round(num * 1000f);
				break;
			}
		}
		catch
		{
		}
	}

	public void btnDiskRefresh_Click(object sender, EventArgs e)
	{
		showDisk.Checked = false;
		if (!diskForm.IsDisposed)
		{
			diskForm.Dispose();
		}
		diskForm = new DiskForm(this);
		showDisk.Checked = true;
	}

	private void btnNetworkRefresh_Click(object sender, EventArgs e)
	{
		showNetwork.Enabled = true;
		showNetwork.Text = "Show Network and Adapter Speed";
		showNetwork.Checked = false;
		if (!networkForm.IsDisposed)
		{
			networkForm.Dispose();
		}
		networkForm = new NetworkForm(this);
		showNetwork.Checked = true;
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (aboutBox != null)
		{
			aboutBox.Dispose();
		}
		if (cpuForm != null)
		{
			cpuForm.Dispose();
		}
		if (ramForm != null)
		{
			ramForm.Dispose();
		}
		if (diskForm != null)
		{
			diskForm.Dispose();
		}
		if (networkForm != null)
		{
			networkForm.Dispose();
		}
		if (gpuForm != null)
		{
			gpuForm.Dispose();
		}
		Dispose();
	}

	private void btnDiskRefresh_MouseEnter(object sender, EventArgs e)
	{
		toolTip1.Show("Reload disks if you have new disk inserted", (Button)sender);
	}

	private void btnNetworkRefresh_MouseEnter(object sender, EventArgs e)
	{
		toolTip1.Show("Reload networks if you have connections established or removed", (Button)sender);
	}

	private void btnDiskRefresh_MouseLeave(object sender, EventArgs e)
	{
		toolTip1.Hide((Button)sender);
	}

	private void saveOpenedWindowLocationsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (cpuForm != null && !cpuForm.IsDisposed)
		{
			INIHelper.Write("CPUForm", "X", cpuForm.Location.X.ToString(), iniFile);
			INIHelper.Write("CPUForm", "Y", cpuForm.Location.Y.ToString(), iniFile);
		}
		if (ramForm != null && !ramForm.IsDisposed)
		{
			INIHelper.Write("RAMForm", "X", ramForm.Location.X.ToString(), iniFile);
			INIHelper.Write("RAMForm", "Y", ramForm.Location.Y.ToString(), iniFile);
		}
		if (diskForm != null && !diskForm.IsDisposed)
		{
			INIHelper.Write("DiskForm", "X", diskForm.Location.X.ToString(), iniFile);
			INIHelper.Write("DiskForm", "Y", diskForm.Location.Y.ToString(), iniFile);
		}
		if (networkForm != null && !networkForm.IsDisposed)
		{
			INIHelper.Write("NetworkForm", "X", networkForm.Location.X.ToString(), iniFile);
			INIHelper.Write("NetworkForm", "Y", networkForm.Location.Y.ToString(), iniFile);
		}
		if (gpuForm == null || gpuForm.IsDisposed)
		{
			return;
		}
		INIHelper.Write("GPUForm0", "X", gpuForm.Location.X.ToString(), iniFile);
		INIHelper.Write("GPUForm0", "Y", gpuForm.Location.Y.ToString(), iniFile);
		int num = 1;
		foreach (GPUForm moreGPUForm in gpuForm.moreGPUForms)
		{
			INIHelper.Write("GPUForm" + num, "X", moreGPUForm.Location.X.ToString(), iniFile);
			INIHelper.Write("GPUForm" + num, "Y", moreGPUForm.Location.Y.ToString(), iniFile);
			num++;
		}
	}

	private void loadSavedLocationsToolStripMenuItem_Click(object sender, EventArgs e)
	{
		LoadSavedLocation();
	}

	private void LoadSavedLocation()
	{
		if (cpuForm != null && !cpuForm.IsDisposed)
		{
			string s = INIHelper.Read("CPUForm", "X", cpuForm.Location.X.ToString(), iniFile);
			string s2 = INIHelper.Read("CPUForm", "Y", cpuForm.Location.Y.ToString(), iniFile);
			int num = int.Parse(s);
			int num2 = int.Parse(s2);
			cpuForm.Location = new Point(num, num2);
		}
		if (ramForm != null && !ramForm.IsDisposed)
		{
			string s3 = INIHelper.Read("RAMForm", "X", ramForm.Location.X.ToString(), iniFile);
			string s4 = INIHelper.Read("RAMForm", "Y", ramForm.Location.Y.ToString(), iniFile);
			int num3 = int.Parse(s3);
			int num4 = int.Parse(s4);
			ramForm.Location = new Point(num3, num4);
		}
		if (diskForm != null && !diskForm.IsDisposed)
		{
			string s5 = INIHelper.Read("DiskForm", "X", diskForm.Location.X.ToString(), iniFile);
			string s6 = INIHelper.Read("DiskForm", "Y", diskForm.Location.Y.ToString(), iniFile);
			int num5 = int.Parse(s5);
			int num6 = int.Parse(s6);
			diskForm.Location = new Point(num5, num6);
		}
		if (networkForm != null && !networkForm.IsDisposed)
		{
			string s7 = INIHelper.Read("NetworkForm", "X", networkForm.Location.X.ToString(), iniFile);
			string s8 = INIHelper.Read("NetworkForm", "Y", networkForm.Location.Y.ToString(), iniFile);
			int num7 = int.Parse(s7);
			int num8 = int.Parse(s8);
			networkForm.Location = new Point(num7, num8);
		}
		loadGPUFormLocation();
	}

	private void loadGPUFormLocation()
	{
		if (gpuForm == null || gpuForm.IsDisposed)
		{
			return;
		}
		string s = INIHelper.Read("GPUForm0", "X", gpuForm.Location.X.ToString(), iniFile);
		string s2 = INIHelper.Read("GPUForm0", "Y", gpuForm.Location.Y.ToString(), iniFile);
		int num = int.Parse(s);
		int num2 = int.Parse(s2);
		gpuForm.Location = new Point(num, num2);
		int num3 = 1;
		foreach (GPUForm moreGPUForm in gpuForm.moreGPUForms)
		{
			s = INIHelper.Read("GPUForm" + num3, "X", moreGPUForm.Location.X.ToString(), iniFile);
			s2 = INIHelper.Read("GPUForm" + num3, "Y", moreGPUForm.Location.Y.ToString(), iniFile);
			num = int.Parse(s);
			num2 = int.Parse(s2);
			moreGPUForm.Location = new Point(num, num2);
		}
	}

	private void doNotShowGPUAtStartToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
		if (toolStripMenuItem.Checked)
		{
			INIHelper.Write("DoNotShow", "GPU", "true", iniFile);
		}
		else
		{
			INIHelper.Write("DoNotShow", "GPU", "false", iniFile);
		}
	}

	private void exitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (aboutBox == null || aboutBox.IsDisposed)
		{
			aboutBox = new AboutBox1();
		}
		aboutBox.Show();
		aboutBox.Focus();
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
		this.components = new System.ComponentModel.Container();
		this.showCPU = new System.Windows.Forms.CheckBox();
		this.showRAM = new System.Windows.Forms.CheckBox();
		this.showDisk = new System.Windows.Forms.CheckBox();
		this.showNetwork = new System.Windows.Forms.CheckBox();
		this.showGPU = new System.Windows.Forms.CheckBox();
		this.buttonExit = new System.Windows.Forms.Button();
		this.cbUpdateInterval = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.btnDiskRefresh = new System.Windows.Forms.Button();
		this.btnNetworkRefresh = new System.Windows.Forms.Button();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.saveOpenedWindowLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.loadSavedLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.doNotShowGPUAtStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.menuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.showCPU.AutoSize = true;
		this.showCPU.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.showCPU.Location = new System.Drawing.Point(105, 89);
		this.showCPU.Name = "showCPU";
		this.showCPU.Size = new System.Drawing.Size(186, 24);
		this.showCPU.TabIndex = 0;
		this.showCPU.Text = "Show CPU Utilizations";
		this.showCPU.UseVisualStyleBackColor = true;
		this.showCPU.CheckedChanged += new System.EventHandler(showCPU_CheckedChanged);
		this.showRAM.AutoSize = true;
		this.showRAM.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.showRAM.Location = new System.Drawing.Point(105, 118);
		this.showRAM.Name = "showRAM";
		this.showRAM.Size = new System.Drawing.Size(157, 24);
		this.showRAM.TabIndex = 1;
		this.showRAM.Text = "Show RAM Usage";
		this.showRAM.UseVisualStyleBackColor = true;
		this.showRAM.CheckedChanged += new System.EventHandler(showRAM_CheckedChanged);
		this.showDisk.AutoSize = true;
		this.showDisk.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.showDisk.Location = new System.Drawing.Point(105, 148);
		this.showDisk.Name = "showDisk";
		this.showDisk.Size = new System.Drawing.Size(287, 24);
		this.showDisk.TabIndex = 2;
		this.showDisk.Text = "Show Disk Load and Transfer Speed";
		this.showDisk.UseVisualStyleBackColor = true;
		this.showDisk.CheckedChanged += new System.EventHandler(showDisk_CheckedChanged);
		this.showNetwork.AutoSize = true;
		this.showNetwork.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.showNetwork.Location = new System.Drawing.Point(105, 178);
		this.showNetwork.Name = "showNetwork";
		this.showNetwork.Size = new System.Drawing.Size(281, 24);
		this.showNetwork.TabIndex = 3;
		this.showNetwork.Text = "Show Network and Adapter Speed";
		this.showNetwork.UseVisualStyleBackColor = true;
		this.showNetwork.CheckedChanged += new System.EventHandler(showNetwork_CheckedChanged);
		this.showGPU.AutoSize = true;
		this.showGPU.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.showGPU.Location = new System.Drawing.Point(105, 209);
		this.showGPU.Name = "showGPU";
		this.showGPU.Size = new System.Drawing.Size(187, 24);
		this.showGPU.TabIndex = 4;
		this.showGPU.Text = "Show GPU Utilizations";
		this.showGPU.UseVisualStyleBackColor = true;
		this.showGPU.CheckedChanged += new System.EventHandler(showGPU_CheckedChanged);
		this.buttonExit.Location = new System.Drawing.Point(451, 324);
		this.buttonExit.Name = "buttonExit";
		this.buttonExit.Size = new System.Drawing.Size(80, 23);
		this.buttonExit.TabIndex = 5;
		this.buttonExit.Text = "Exit";
		this.buttonExit.UseVisualStyleBackColor = true;
		this.buttonExit.Click += new System.EventHandler(buttonExit_Click);
		this.cbUpdateInterval.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.cbUpdateInterval.FormattingEnabled = true;
		this.cbUpdateInterval.ImeMode = System.Windows.Forms.ImeMode.Disable;
		this.cbUpdateInterval.Items.AddRange(new object[4] { "1 sec", "2 sec", "0.5 sec", "0.25 sec" });
		this.cbUpdateInterval.Location = new System.Drawing.Point(248, 249);
		this.cbUpdateInterval.Margin = new System.Windows.Forms.Padding(2);
		this.cbUpdateInterval.Name = "cbUpdateInterval";
		this.cbUpdateInterval.Size = new System.Drawing.Size(98, 25);
		this.cbUpdateInterval.TabIndex = 6;
		this.cbUpdateInterval.Text = "1 sec";
		this.cbUpdateInterval.SelectedIndexChanged += new System.EventHandler(cbUpdateInterval_SelectedIndexChanged);
		this.cbUpdateInterval.TextChanged += new System.EventHandler(cbUpdateInterval_TextChanged);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(121, 249);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(121, 20);
		this.label1.TabIndex = 7;
		this.label1.Text = "Update interval";
		this.btnDiskRefresh.AutoSize = true;
		this.btnDiskRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.btnDiskRefresh.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnDiskRefresh.Location = new System.Drawing.Point(402, 147);
		this.btnDiskRefresh.Margin = new System.Windows.Forms.Padding(2);
		this.btnDiskRefresh.Name = "btnDiskRefresh";
		this.btnDiskRefresh.Size = new System.Drawing.Size(26, 25);
		this.btnDiskRefresh.TabIndex = 8;
		this.btnDiskRefresh.Text = "R";
		this.btnDiskRefresh.UseVisualStyleBackColor = true;
		this.btnDiskRefresh.Click += new System.EventHandler(btnDiskRefresh_Click);
		this.btnDiskRefresh.MouseEnter += new System.EventHandler(btnDiskRefresh_MouseEnter);
		this.btnDiskRefresh.MouseLeave += new System.EventHandler(btnDiskRefresh_MouseLeave);
		this.btnNetworkRefresh.AutoSize = true;
		this.btnNetworkRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.btnNetworkRefresh.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNetworkRefresh.Location = new System.Drawing.Point(402, 177);
		this.btnNetworkRefresh.Name = "btnNetworkRefresh";
		this.btnNetworkRefresh.Size = new System.Drawing.Size(26, 25);
		this.btnNetworkRefresh.TabIndex = 9;
		this.btnNetworkRefresh.Text = "R";
		this.btnNetworkRefresh.UseVisualStyleBackColor = true;
		this.btnNetworkRefresh.Click += new System.EventHandler(btnNetworkRefresh_Click);
		this.btnNetworkRefresh.MouseEnter += new System.EventHandler(btnNetworkRefresh_MouseEnter);
		this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.fileToolStripMenuItem, this.optionToolStripMenuItem, this.helpToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(544, 25);
		this.menuStrip1.TabIndex = 10;
		this.menuStrip1.Text = "menuStrip1";
		this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.saveOpenedWindowLocationsToolStripMenuItem, this.loadSavedLocationsToolStripMenuItem, this.toolStripSeparator1, this.exitToolStripMenuItem });
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
		this.fileToolStripMenuItem.Text = "File";
		this.saveOpenedWindowLocationsToolStripMenuItem.Name = "saveOpenedWindowLocationsToolStripMenuItem";
		this.saveOpenedWindowLocationsToolStripMenuItem.ShowShortcutKeys = false;
		this.saveOpenedWindowLocationsToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
		this.saveOpenedWindowLocationsToolStripMenuItem.Text = "Save opened window locations";
		this.saveOpenedWindowLocationsToolStripMenuItem.Click += new System.EventHandler(saveOpenedWindowLocationsToolStripMenuItem_Click);
		this.loadSavedLocationsToolStripMenuItem.Name = "loadSavedLocationsToolStripMenuItem";
		this.loadSavedLocationsToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
		this.loadSavedLocationsToolStripMenuItem.Text = "Load saved locations";
		this.loadSavedLocationsToolStripMenuItem.Click += new System.EventHandler(loadSavedLocationsToolStripMenuItem_Click);
		this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.doNotShowGPUAtStartToolStripMenuItem });
		this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
		this.optionToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
		this.optionToolStripMenuItem.Text = "Option";
		this.doNotShowGPUAtStartToolStripMenuItem.CheckOnClick = true;
		this.doNotShowGPUAtStartToolStripMenuItem.Name = "doNotShowGPUAtStartToolStripMenuItem";
		this.doNotShowGPUAtStartToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
		this.doNotShowGPUAtStartToolStripMenuItem.Text = "Do not show GPU at start";
		this.doNotShowGPUAtStartToolStripMenuItem.Click += new System.EventHandler(doNotShowGPUAtStartToolStripMenuItem_Click);
		this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		this.exitToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
		this.exitToolStripMenuItem.Text = "Exit";
		this.exitToolStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
		this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.aboutToolStripMenuItem });
		this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
		this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
		this.helpToolStripMenuItem.Text = "Help";
		this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
		this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.aboutToolStripMenuItem.Text = "About";
		this.aboutToolStripMenuItem.Click += new System.EventHandler(aboutToolStripMenuItem_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(544, 359);
		base.Controls.Add(this.btnNetworkRefresh);
		base.Controls.Add(this.btnDiskRefresh);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.cbUpdateInterval);
		base.Controls.Add(this.buttonExit);
		base.Controls.Add(this.showGPU);
		base.Controls.Add(this.showNetwork);
		base.Controls.Add(this.showDisk);
		base.Controls.Add(this.showRAM);
		base.Controls.Add(this.showCPU);
		base.Controls.Add(this.menuStrip1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MainMenuStrip = this.menuStrip1;
		base.MaximizeBox = false;
		base.Name = "Form1";
		this.Text = "Control Console";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
		base.Load += new System.EventHandler(Form1_Load);
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
