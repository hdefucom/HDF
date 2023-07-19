using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GetSystemStatusGUI;

public class DiskForm : Form
{
	private DiskInfo diskInfo;

	private Chart[] subCharts;

	private Color chartColor = Color.FromArgb(120, Color.LimeGreen);

	private Color borderColor = Color.FromArgb(180, Color.LimeGreen);

	private int beginTop;

	private int rows = 1;

	private int columns = 1;

	private const double margin_ratio = 35.0;

	private const int history_length = 60;

	private Form1 mainform;

	private IContainer components = null;

	private Label label1;

	public DiskForm(Form1 mainform)
	{
		InitializeComponent();
		diskInfo = new DiskInfo();
		this.mainform = mainform;
	}

	private void DiskForm_Load(object sender, EventArgs e)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < 60; i++)
		{
			list.Add(0);
		}
		beginTop = label1.Location.Y + label1.Size.Height;
		Utility.FactorDecompose(diskInfo.m_DiskNum, ref columns, ref rows);
		subCharts = new Chart[diskInfo.m_DiskNum];
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
				chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGreen;
				chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
				chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGreen;
				chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGreen;
				chart.ChartAreas[0].AxisX.LineColor = Color.LimeGreen;
				chart.ChartAreas[0].AxisY.LineColor = Color.LimeGreen;
				chart.ChartAreas[0].AxisX.LineWidth = 2;
				chart.ChartAreas[0].AxisY.LineWidth = 2;
				chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
				chart.ChartAreas[0].AxisX2.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisX2.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisX2.LineColor = Color.LimeGreen;
				chart.ChartAreas[0].AxisX2.LineWidth = 2;
				chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
				chart.ChartAreas[0].AxisY2.LabelStyle.Enabled = false;
				chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
				chart.ChartAreas[0].AxisY2.MajorTickMark.Enabled = false;
				chart.ChartAreas[0].AxisY2.LineColor = Color.LimeGreen;
				chart.ChartAreas[0].AxisY2.LineWidth = 2;
				chart.Titles.Add(num + "_0");
				chart.Titles[0].Text = "Disk " + num;
				chart.Titles[0].Alignment = ContentAlignment.MiddleLeft;
				chart.Titles[0].DockedToChartArea = num.ToString();
				chart.Titles[0].IsDockedInsideChartArea = false;
				chart.Titles[0].Font = new Font(FontFamily.GenericSansSerif, 14f);
				chart.Titles.Add(num + "_1");
				chart.Titles[1].Text = diskInfo.DiskModel(num);
				chart.Titles[1].Alignment = ContentAlignment.MiddleLeft;
				chart.Titles[1].DockedToChartArea = num.ToString();
				chart.Titles[1].IsDockedInsideChartArea = false;
				chart.Titles[1].ForeColor = SystemColors.GrayText;
				chart.Titles.Add(num + "_2");
				chart.Titles[2].Text = "Read 0KB/s\tWrite 0KB/s";
				chart.Titles[2].Alignment = ContentAlignment.MiddleLeft;
				chart.Titles[2].DockedToChartArea = num.ToString();
				chart.Titles[2].Docking = Docking.Bottom;
				chart.Titles[2].IsDockedInsideChartArea = false;
				chart.Titles[2].Font = new Font(FontFamily.GenericSansSerif, 11f);
				chart.Titles[2].ForeColor = ColorTranslator.FromHtml("#494949");
				subCharts[num] = chart;
				base.Controls.Add(subCharts[num]);
			}
		}
		InitialSize();
		DiskForm_Resize(null, null);
		new Action(disk_load_thread).BeginInvoke(null, null);
	}

	private void DiskForm_Resize(object sender, EventArgs e)
	{
		int num = (int)Math.Round((double)Math.Min(base.Size.Height, base.Size.Width) / 35.0);
		int num2 = num / 3;
		int num3 = (int)Math.Round((double)num * 1.1);
		int num4 = Math.Max(40, num * 2);
		int num5 = (int)Math.Round((double)(base.Size.Height - beginTop - num4 - (rows + 1) * num2) / (double)rows);
		int num6 = (int)Math.Round((double)(base.Size.Width - num3 - (columns + 1) * num) / (double)columns);
		if (num5 <= 0 || num6 <= 0 || subCharts == null)
		{
			return;
		}
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				int num7 = i * columns + j;
				int num8 = (j + 1) * num + j * num6;
				int num9 = beginTop + (i + 1) * num2 + i * num5;
				subCharts[num7].Size = new Size(num6, num5);
				subCharts[num7].Location = new Point(num8, num9);
			}
		}
	}

	private void InitialSize()
	{
		int val = beginTop + rows * 200 + (rows + 1) * 5;
		int val2 = columns * 180 + (columns + 1) * 10;
		val = Math.Max(val, base.Size.Height);
		val2 = Math.Max(val2, base.Size.Width);
		base.Size = new Size(val2, val);
	}

	private void DiskForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		mainform.DisableChecked("Disk");
	}

	private void disk_load_thread()
	{
		List<float>[] ys = new List<float>[diskInfo.m_DiskNum];
		for (int i = 0; i < diskInfo.m_DiskNum; i++)
		{
			ys[i] = new List<float>();
			for (int j = 0; j < 60; j++)
			{
				ys[i].Add(0f);
			}
		}
		while (!subCharts[0].IsDisposed)
		{
			for (int k = 0; k < diskInfo.m_DiskNum; k++)
			{
				ys[k].RemoveAt(0);
				try
				{
					ys[k].Add(diskInfo.DiskLoad(k));
				}
				catch
				{
					Action method = delegate
					{
						Thread.Sleep(100);
						mainform.btnDiskRefresh_Click(null, null);
					};
					Invoke(method);
					break;
				}
			}
			Action method2 = delegate
			{
				for (int l = 0; l < diskInfo.m_DiskNum; l++)
				{
					subCharts[l].Series[0].Points.DataBindY(ys[l]);
					string text = Utility.FormatSpeedString("Read", diskInfo.DiskRead(l), "Write", diskInfo.DiskWrite(l));
					subCharts[l].Titles[2].Text = text;
				}
			};
			try
			{
				Invoke(method2);
			}
			catch
			{
				break;
			}
			Thread.Sleep(Global.interval_ms);
		}
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
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 27f);
		this.label1.Location = new System.Drawing.Point(38, 38);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(94, 46);
		this.label1.TabIndex = 0;
		this.label1.Text = "Disk";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(662, 467);
		base.Controls.Add(this.label1);
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "DiskForm";
		this.Text = "Disks";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(DiskForm_FormClosing);
		base.Load += new System.EventHandler(DiskForm_Load);
		base.Resize += new System.EventHandler(DiskForm_Resize);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
