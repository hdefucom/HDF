using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GetSystemStatusGUI;

public class RAMForm : Form
{
	private const int historyLength = 60;

	private RAMInfo ramInfo;

	private static string[] scale_unit = new string[5] { "Bytes", "KB", "MB", "GB", "TB" };

	private Color chartColor = Color.FromArgb(105, 139, 0, 139);

	private Color borderColor = Color.FromArgb(180, 139, 0, 139);

	private Form1 mainform;

	private IContainer components = null;

	private Label label1;

	private Label lblRAM;

	private Chart chart1;

	public RAMForm(Form1 mainform)
	{
		ramInfo = new RAMInfo();
		InitializeComponent();
		this.mainform = mainform;
	}

	private void RAMForm_Load(object sender, EventArgs e)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < 60; i++)
		{
			list.Add(0);
		}
		chart1.Series[0].Points.DataBindY(list);
		chart1.PaletteCustomColors[0] = chartColor;
		chart1.Series[0].BorderColor = borderColor;
		new Action(ram_update_thread).BeginInvoke(null, null);
	}

	private void ram_update_thread()
	{
		List<int> usageList = new List<int>();
		for (int i = 0; i < 60; i++)
		{
			usageList.Add(0);
		}
		while (!chart1.IsDisposed && !lblRAM.IsDisposed)
		{
			int rusage = (int)Math.Round((1.0 - (double)ramInfo.MemoryAvailable / (double)ramInfo.PhysicalMemory) * 100.0);
			int ramScale = (int)Math.Floor(Math.Log(ramInfo.PhysicalMemory - ramInfo.MemoryAvailable, 1024.0));
			double memAvail = Math.Round((double)ramInfo.MemoryAvailable / Math.Pow(1024.0, ramScale), 1);
			double memTotal = Math.Round((double)ramInfo.PhysicalMemory / Math.Pow(1024.0, ramScale), 1);
			usageList.RemoveAt(0);
			usageList.Add(rusage);
			Action method = delegate
			{
				if (ramScale == 2)
				{
					lblRAM.Text = $"{memTotal - memAvail:f0} / {memTotal:f0}{scale_unit[ramScale]} ({rusage}%)";
				}
				else if (ramScale == 3)
				{
					lblRAM.Text = $"{memTotal - memAvail:f1} / {memTotal:f1}{scale_unit[ramScale]} ({rusage}%)";
				}
				else if (ramScale == 4)
				{
					lblRAM.Text = $"{memTotal - memAvail:f2} / {memTotal:f2}{scale_unit[ramScale]} ({rusage}%)";
				}
				chart1.Series[0].Points.DataBindY(usageList);
			};
			try
			{
				Invoke(method);
			}
			catch
			{
				break;
			}
			Thread.Sleep(Global.interval_ms);
		}
	}

	private void RAMForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		mainform.DisableChecked("RAM");
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
		System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
		System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
		System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();
		System.Windows.Forms.DataVisualization.Charting.Title title = new System.Windows.Forms.DataVisualization.Charting.Title();
		this.label1 = new System.Windows.Forms.Label();
		this.lblRAM = new System.Windows.Forms.Label();
		this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
		((System.ComponentModel.ISupportInitialize)this.chart1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 22f);
		this.label1.Location = new System.Drawing.Point(38, 38);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(87, 39);
		this.label1.TabIndex = 0;
		this.label1.Text = "RAM";
		this.lblRAM.Font = new System.Drawing.Font("微软雅黑", 12f);
		this.lblRAM.Location = new System.Drawing.Point(184, 49);
		this.lblRAM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblRAM.Name = "lblRAM";
		this.lblRAM.Size = new System.Drawing.Size(319, 25);
		this.lblRAM.TabIndex = 1;
		this.lblRAM.Text = "Loading usage status...";
		this.lblRAM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chart1.BackColor = System.Drawing.Color.Transparent;
		chartArea.AxisX.LabelStyle.Enabled = false;
		chartArea.AxisX.LineColor = System.Drawing.Color.DarkMagenta;
		chartArea.AxisX.LineWidth = 2;
		chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Thistle;
		chartArea.AxisX.MajorTickMark.Enabled = false;
		chartArea.AxisX.MinorGrid.Enabled = true;
		chartArea.AxisX.MinorGrid.LineColor = System.Drawing.Color.Thistle;
		chartArea.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
		chartArea.AxisX2.LineColor = System.Drawing.Color.DarkMagenta;
		chartArea.AxisX2.LineWidth = 2;
		chartArea.AxisX2.MajorGrid.Enabled = false;
		chartArea.AxisX2.MajorTickMark.Enabled = false;
		chartArea.AxisY.LabelStyle.Enabled = false;
		chartArea.AxisY.LineColor = System.Drawing.Color.DarkMagenta;
		chartArea.AxisY.LineWidth = 2;
		chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Thistle;
		chartArea.AxisY.MajorTickMark.Enabled = false;
		chartArea.AxisY.Maximum = 100.0;
		chartArea.AxisY.Minimum = 0.0;
		chartArea.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
		chartArea.AxisY2.LabelStyle.Enabled = false;
		chartArea.AxisY2.LineColor = System.Drawing.Color.DarkMagenta;
		chartArea.AxisY2.LineWidth = 2;
		chartArea.AxisY2.MajorGrid.Enabled = false;
		chartArea.AxisY2.MajorTickMark.Enabled = false;
		chartArea.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DarkMagenta;
		chartArea.AxisY2.MajorTickMark.LineWidth = 2;
		chartArea.Name = "ChartArea1";
		this.chart1.ChartAreas.Add(chartArea);
		legend.Enabled = false;
		legend.Name = "Legend1";
		this.chart1.Legends.Add(legend);
		this.chart1.Location = new System.Drawing.Point(34, 77);
		this.chart1.Margin = new System.Windows.Forms.Padding(2);
		this.chart1.Name = "chart1";
		this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
		this.chart1.PaletteCustomColors = new System.Drawing.Color[1] { System.Drawing.Color.DarkMagenta };
		series.ChartArea = "ChartArea1";
		series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
		series.Legend = "Legend1";
		series.Name = "Series1";
		this.chart1.Series.Add(series);
		this.chart1.Size = new System.Drawing.Size(469, 280);
		this.chart1.TabIndex = 2;
		this.chart1.Text = "chart1";
		title.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
		title.DockedToChartArea = "ChartArea1";
		title.DockingOffset = 2;
		title.ForeColor = System.Drawing.SystemColors.GrayText;
		title.IsDockedInsideChartArea = false;
		title.Name = "Title1";
		title.Text = "Total Usage %";
		this.chart1.Titles.Add(title);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(539, 395);
		base.Controls.Add(this.lblRAM);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.chart1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.MaximizeBox = false;
		base.Name = "RAMForm";
		this.Text = "RAM";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RAMForm_FormClosing);
		base.Load += new System.EventHandler(RAMForm_Load);
		((System.ComponentModel.ISupportInitialize)this.chart1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
