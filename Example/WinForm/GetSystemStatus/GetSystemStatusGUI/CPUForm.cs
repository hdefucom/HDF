using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GetSystemStatusGUI;

public class CPUForm : Form
{
	private const int historyLength = 60;

	private int beginTop = 311;

	private Color chartColor = Color.FromArgb(120, Color.DodgerBlue);

	private Color borderColor = Color.FromArgb(180, Color.DodgerBlue);

	private Color gridColor = ColorTranslator.FromHtml("#905baeff");

	private int fixHeight = 40;

	private Form1 mainForm;

	private CPUInfo cpuInfo;

	private Chart[] subCharts;

	private int rows = 1;

	private int columns = 1;

	private IContainer components = null;

	private Label label1;

	private Label cpuName;

	private Chart chart1;

	public CPUForm(Form1 mainForm)
	{
		InitializeComponent();
		this.mainForm = mainForm;
		cpuInfo = new CPUInfo();
	}

	private void CPUForm_Load(object sender, EventArgs e)
	{
		cpuName.Text = cpuInfo.CpuName;
		beginTop = chart1.Location.Y + chart1.Size.Height + 5;
		List<float> list = new List<float>();
		for (int i = 0; i < 60; i++)
		{
			list.Add(0f);
		}
		chart1.Series[0].Points.DataBindY(list);
		chart1.Series[0].IsVisibleInLegend = false;
		chart1.PaletteCustomColors[0] = chartColor;
		chart1.Series[0].BorderColor = borderColor;
		chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = gridColor;
		chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = gridColor;
		chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = gridColor;
		Utility.FactorDecompose(cpuInfo.ProcessorCount, ref columns, ref rows);
		subCharts = new Chart[cpuInfo.ProcessorCount];
		for (int j = 0; j < rows; j++)
		{
			for (int k = 0; k < columns; k++)
			{
				int num = j * columns + k;
				Chart chart = new Chart();
				chart.Palette = ChartColorPalette.None;
				chart.PaletteCustomColors = new Color[1] { chartColor };
				chart.Series.Add(num.ToString());
				chart.Series[0].Points.DataBindY(list);
				chart.Series[0].ChartType = SeriesChartType.SplineArea;
				chart.Series[0].BorderColor = borderColor;
				chart.ChartAreas.Add(num.ToString());
				chart.ChartAreas[0].AxisY.Minimum = 0.0;
				chart.ChartAreas[0].AxisY.Maximum = 100.0;
				chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
				chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisY.MajorGrid.LineColor = gridColor;
				chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
				chart.ChartAreas[0].AxisX.MajorGrid.LineColor = gridColor;
				chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.MinorGrid.LineColor = gridColor;
				chart.ChartAreas[0].AxisX.LineColor = Color.DodgerBlue;
				chart.ChartAreas[0].AxisY.LineColor = Color.DodgerBlue;
				chart.ChartAreas[0].AxisX.LineWidth = 2;
				chart.ChartAreas[0].AxisY.LineWidth = 2;
				chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
				chart.ChartAreas[0].AxisX2.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX2.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisX2.LineColor = Color.DodgerBlue;
				chart.ChartAreas[0].AxisX2.LineWidth = 2;
				chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
				chart.ChartAreas[0].AxisY2.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisY2.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisY2.LineColor = Color.DodgerBlue;
				chart.ChartAreas[0].AxisY2.LineWidth = 2;
				chart.Titles.Add(num.ToString());
				chart.Titles[0].Text = "CPU " + num;
				chart.Titles[0].Alignment = ContentAlignment.MiddleLeft;
				chart.Titles[0].DockedToChartArea = num.ToString();
				chart.Titles[0].IsDockedInsideChartArea = false;
				chart.Titles[0].ForeColor = SystemColors.GrayText;
				subCharts[num] = chart;
				base.Controls.Add(subCharts[num]);
			}
		}
		InitialSize();
		CPUForm_Resize(null, null);
		new Action(cpu_load_thread).BeginInvoke(null, null);
	}

	private void CPUForm_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void CPUForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		mainForm.DisableChecked("CPU");
		Hide();
	}

	private void cpu_load_thread()
	{
		List<float> y = new List<float>();
		List<float>[] ys = new List<float>[cpuInfo.ProcessorCount];
		for (int i = 0; i < 60 * columns; i++)
		{
			y.Add(0f);
		}
		for (int j = 0; j < cpuInfo.ProcessorCount; j++)
		{
			ys[j] = new List<float>();
			for (int k = 0; k < 60; k++)
			{
				ys[j].Add(0f);
			}
		}
		while (true)
		{
			y.RemoveAt(0);
			y.Add(cpuInfo.CpuLoad);
			for (int l = 0; l < cpuInfo.ProcessorCount; l++)
			{
				ys[l].RemoveAt(0);
				ys[l].Add(cpuInfo.CpuCoreLoad(l));
			}
			Action method = delegate
			{
				chart1.Series["Series1"].Points.DataBindY(y);
				for (int m = 0; m < cpuInfo.ProcessorCount; m++)
				{
					subCharts[m].Series[0].Points.DataBindY(ys[m]);
				}
			};
			if (chart1.IsDisposed)
			{
				break;
			}
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

	private void CPUForm_Resize(object sender, EventArgs e)
	{
		int num = (int)Math.Round((double)Math.Min(base.Size.Height, base.Size.Width) / 50.0);
		int num2 = num;
		int num3 = (int)Math.Round((double)num2 * 1.1);
		fixHeight = Math.Max(40, num2 * 3);
		int num4 = (int)Math.Round((double)(base.Size.Height - beginTop - fixHeight - (rows + 1) * num) / (double)rows);
		int num5 = (int)Math.Round((double)(base.Size.Width - num3 - (columns + 1) * num2) / (double)columns);
		if (num4 <= 0 || num5 <= 0 || subCharts == null)
		{
			return;
		}
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				int num6 = i * columns + j;
				int num7 = (j + 1) * num2 + j * num5;
				int num8 = beginTop + (i + 1) * num + i * num4;
				subCharts[num6].Size = new Size(num5, num4);
				subCharts[num6].Location = new Point(num7, num8);
			}
		}
		chart1.Width = base.Size.Width - num2 - num3;
		chart1.Left = (int)Math.Round((double)num2 / 2.5);
	}

	private void InitialSize()
	{
		int val = beginTop + rows * 145 + (rows + 1) * 3;
		int val2 = columns * 145 + (columns + 1) * 7;
		val = Math.Max(val, base.Size.Height);
		val2 = Math.Max(val2, base.Size.Width);
		if (columns == 2)
		{
			val2 = Math.Min(val2, columns * 302 + (columns + 1) * 18);
		}
		base.Size = new Size(val2, val);
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
		this.cpuName = new System.Windows.Forms.Label();
		this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
		((System.ComponentModel.ISupportInitialize)this.chart1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 32.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(40, 40);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(112, 57);
		this.label1.TabIndex = 0;
		this.label1.Text = "CPU";
		this.cpuName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cpuName.BackColor = System.Drawing.Color.Transparent;
		this.cpuName.Font = new System.Drawing.Font("微软雅黑 Light", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.cpuName.Location = new System.Drawing.Point(185, 57);
		this.cpuName.Name = "cpuName";
		this.cpuName.Size = new System.Drawing.Size(579, 39);
		this.cpuName.TabIndex = 1;
		this.cpuName.Text = "cpuName";
		this.cpuName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chart1.BorderSkin.BorderColor = System.Drawing.Color.White;
		chartArea.AxisX.LabelStyle.Enabled = false;
		chartArea.AxisX.LineColor = System.Drawing.Color.DodgerBlue;
		chartArea.AxisX.LineWidth = 2;
		chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(91, 174, 255);
		chartArea.AxisX.MajorTickMark.Enabled = false;
		chartArea.AxisX.MinorGrid.Enabled = true;
		chartArea.AxisX.MinorGrid.LineColor = System.Drawing.Color.FromArgb(91, 174, 255);
		chartArea.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
		chartArea.AxisX2.LabelStyle.Enabled = false;
		chartArea.AxisX2.LineColor = System.Drawing.Color.DodgerBlue;
		chartArea.AxisX2.LineWidth = 2;
		chartArea.AxisX2.MajorGrid.Enabled = false;
		chartArea.AxisX2.MajorTickMark.Enabled = false;
		chartArea.AxisY.IsMarginVisible = false;
		chartArea.AxisY.LabelStyle.Enabled = false;
		chartArea.AxisY.LineColor = System.Drawing.Color.DodgerBlue;
		chartArea.AxisY.LineWidth = 2;
		chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(91, 174, 255);
		chartArea.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
		chartArea.AxisY.Maximum = 100.0;
		chartArea.AxisY.Minimum = 0.0;
		chartArea.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Transparent;
		chartArea.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
		chartArea.AxisY2.LabelStyle.Enabled = false;
		chartArea.AxisY2.LineColor = System.Drawing.Color.DodgerBlue;
		chartArea.AxisY2.LineWidth = 2;
		chartArea.AxisY2.MajorGrid.Enabled = false;
		chartArea.AxisY2.MajorTickMark.Enabled = false;
		chartArea.BackColor = System.Drawing.Color.Transparent;
		chartArea.BorderColor = System.Drawing.Color.Transparent;
		chartArea.Name = "ChartArea1";
		this.chart1.ChartAreas.Add(chartArea);
		legend.Enabled = false;
		legend.Name = "Legend1";
		this.chart1.Legends.Add(legend);
		this.chart1.Location = new System.Drawing.Point(10, 120);
		this.chart1.Margin = new System.Windows.Forms.Padding(2);
		this.chart1.Name = "chart1";
		this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
		this.chart1.PaletteCustomColors = new System.Drawing.Color[1] { System.Drawing.Color.DodgerBlue };
		series.ChartArea = "ChartArea1";
		series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
		series.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
		series.IsVisibleInLegend = false;
		series.LabelForeColor = System.Drawing.Color.Silver;
		series.Legend = "Legend1";
		series.Name = "Series1";
		series.YValuesPerPoint = 6;
		this.chart1.Series.Add(series);
		this.chart1.Size = new System.Drawing.Size(754, 129);
		this.chart1.TabIndex = 2;
		title.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
		title.DockedToChartArea = "ChartArea1";
		title.ForeColor = System.Drawing.SystemColors.GrayText;
		title.IsDockedInsideChartArea = false;
		title.Name = "Title1";
		title.Text = "Total Utilizations %";
		this.chart1.Titles.Add(title);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(795, 641);
		base.Controls.Add(this.chart1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.cpuName);
		base.Name = "CPUForm";
		this.Text = "CPU";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CPUForm_FormClosing);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(CPUForm_FormClosed);
		base.Load += new System.EventHandler(CPUForm_Load);
		base.Resize += new System.EventHandler(CPUForm_Resize);
		((System.ComponentModel.ISupportInitialize)this.chart1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
