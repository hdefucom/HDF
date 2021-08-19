using DCSoft.TemperatureChart;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass147
	{
		private TemperatureControl temperatureControl_0;

		public GClass147(TemperatureControl temperatureControl_1)
		{
			int num = 14;
			temperatureControl_0 = null;
			
			if (temperatureControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			temperatureControl_0 = temperatureControl_1;
		}

		public bool method_0(TemperatureDocument temperatureDocument_0)
		{
			int num = 6;
			if (temperatureDocument_0 == null)
			{
				throw new ArgumentNullException("lbl");
			}
			using (dlgTitleValues dlgTitleValues = new dlgTitleValues())
			{
				foreach (HeaderLabelInfo headerLabel in temperatureControl_0.Document.HeaderLabels)
				{
					dlgTitleValues.InputTitles.Add(headerLabel.Title);
					dlgTitleValues.InputValues.Add(headerLabel.Value);
				}
				if (dlgTitleValues.ShowDialog(temperatureControl_0) == DialogResult.OK)
				{
					for (int i = 0; i < dlgTitleValues.InputValues.Count; i++)
					{
						temperatureControl_0.Document.HeaderLabels[i].Value = dlgTitleValues.InputValues[i];
					}
					temperatureControl_0.Document.Modified = true;
					temperatureControl_0.Invalidate(invalidateChildren: true);
					return true;
				}
			}
			return false;
		}

		public bool method_1(ValuePoint valuePoint_0)
		{
			int num = 18;
			if (valuePoint_0 == null)
			{
				throw new ArgumentNullException("vp");
			}
			if (valuePoint_0.Parent is TitleLineInfo)
			{
				TitleLineInfo titleLineInfo = (TitleLineInfo)valuePoint_0.Parent;
				using (dlgEditSingleValue dlgEditSingleValue = new dlgEditSingleValue())
				{
					dlgEditSingleValue.InputTime = valuePoint_0.Time;
					dlgEditSingleValue.InputTitle = string.Format(DCTimeLineStrings.InputTitle_Name, titleLineInfo.Title);
					dlgEditSingleValue.InputValue = valuePoint_0.Text;
					if (dlgEditSingleValue.ShowDialog(temperatureControl_0) == DialogResult.OK)
					{
						valuePoint_0.Text = dlgEditSingleValue.InputValue;
						temperatureControl_0.Document.method_18();
						temperatureControl_0.DocumentViewControl.Invalidate();
						return true;
					}
				}
			}
			else if (valuePoint_0.Parent is YAxisInfo)
			{
				YAxisInfo yAxisInfo = (YAxisInfo)valuePoint_0.Parent;
				if (yAxisInfo.Style == YAxisInfoStyle.Text)
				{
					using (dlgEditSingleValue dlgEditSingleValue = new dlgEditSingleValue())
					{
						dlgEditSingleValue.InputTime = valuePoint_0.Time;
						dlgEditSingleValue.InputTitle = string.Format(DCTimeLineStrings.InputTitle_Name, yAxisInfo.Title);
						dlgEditSingleValue.InputValue = valuePoint_0.Text;
						dlgEditSingleValue.Text = dlgEditSingleValue.Text + " " + valuePoint_0.InstanceIndex;
						if (dlgEditSingleValue.ShowDialog(temperatureControl_0) == DialogResult.OK)
						{
							valuePoint_0.Text = dlgEditSingleValue.InputValue;
							temperatureControl_0.Document.Modified = true;
							temperatureControl_0.DocumentViewControl.Invalidate();
							return true;
						}
					}
				}
				else if (valuePoint_0.ShadowPoint == null || !valuePoint_0.ShowShadowPoint)
				{
					if (yAxisInfo.EnableLanternValue)
					{
						using (dlgEditTowValues dlgEditTowValues = new dlgEditTowValues())
						{
							dlgEditTowValues.InputTime = valuePoint_0.Time;
							dlgEditTowValues.InputTitle1 = string.Format(DCTimeLineStrings.InputTitle_Name_Min_Max, yAxisInfo.Title, yAxisInfo.MinValue, yAxisInfo.MaxValue);
							dlgEditTowValues.Text = dlgEditTowValues.Text + " " + valuePoint_0.InstanceIndex;
							if (!TemperatureDocument.smethod_3(valuePoint_0.Value))
							{
								dlgEditTowValues.InputValue1 = valuePoint_0.Value.ToString();
							}
							dlgEditTowValues.InputParent1 = yAxisInfo;
							if (string.IsNullOrEmpty(yAxisInfo.LanternValueTitle))
							{
								dlgEditTowValues.InputTitle2 = DCTimeLineStrings.DefaultLanternValueTitle;
							}
							else
							{
								dlgEditTowValues.InputTitle2 = yAxisInfo.LanternValueTitle;
							}
							if (!TemperatureDocument.smethod_3(valuePoint_0.LanternValue))
							{
								dlgEditTowValues.InputValue2 = valuePoint_0.LanternValue.ToString();
							}
							dlgEditTowValues.InputParent2 = yAxisInfo;
							dlgEditTowValues.EventOKButtonClick += method_2;
							if (dlgEditTowValues.ShowDialog(temperatureControl_0) == DialogResult.OK)
							{
								float result = 0f;
								if (float.TryParse(dlgEditTowValues.InputValue1, out result))
								{
									valuePoint_0.Value = result;
								}
								else
								{
									valuePoint_0.Value = -10000f;
								}
								if (float.TryParse(dlgEditTowValues.InputValue2, out result))
								{
									valuePoint_0.LanternValue = result;
								}
								else
								{
									valuePoint_0.LanternValue = -10000f;
								}
								temperatureControl_0.Document.Modified = true;
								temperatureControl_0.Document.method_18();
								temperatureControl_0.DocumentViewControl.Invalidate();
								return true;
							}
						}
					}
					else
					{
						using (dlgEditSingleValue dlgEditSingleValue = new dlgEditSingleValue())
						{
							dlgEditSingleValue.InputTime = valuePoint_0.Time;
							dlgEditSingleValue.InputTitle = string.Format(DCTimeLineStrings.InputTitle_Name_Min_Max, yAxisInfo.Title, yAxisInfo.MinValue, yAxisInfo.MaxValue);
							if (!TemperatureDocument.smethod_3(valuePoint_0.Value))
							{
								dlgEditSingleValue.InputValue = valuePoint_0.Value.ToString();
							}
							dlgEditSingleValue.InputParent = yAxisInfo;
							dlgEditSingleValue.EventOKButtonClick += method_2;
							dlgEditSingleValue.Text = dlgEditSingleValue.Text + " " + valuePoint_0.InstanceIndex;
							if (dlgEditSingleValue.ShowDialog(temperatureControl_0) == DialogResult.OK)
							{
								float result = 0f;
								if (float.TryParse(dlgEditSingleValue.InputValue, out result))
								{
									valuePoint_0.Value = result;
								}
								else
								{
									valuePoint_0.Value = -10000f;
								}
								temperatureControl_0.Document.Modified = true;
								temperatureControl_0.Document.method_18();
								temperatureControl_0.DocumentViewControl.Invalidate();
								return true;
							}
						}
					}
				}
				else
				{
					YAxisInfo yAxisInfo2 = (YAxisInfo)valuePoint_0.ShadowPoint.Parent;
					using (dlgEditTowValues dlgEditTowValues = new dlgEditTowValues())
					{
						dlgEditTowValues.InputTime = valuePoint_0.Time;
						dlgEditTowValues.InputTitle1 = string.Format(DCTimeLineStrings.InputTitle_Name_Min_Max, yAxisInfo.Title, yAxisInfo.MinValue, yAxisInfo.MaxValue);
						if (!TemperatureDocument.smethod_3(valuePoint_0.Value))
						{
							dlgEditTowValues.InputValue1 = valuePoint_0.Value.ToString();
						}
						dlgEditTowValues.InputParent1 = yAxisInfo;
						dlgEditTowValues.InputTitle2 = string.Format(DCTimeLineStrings.InputTitle_Name_Min_Max, yAxisInfo2.Title, yAxisInfo2.MinValue, yAxisInfo2.MaxValue);
						if (!TemperatureDocument.smethod_3(valuePoint_0.ShadowPoint.Value))
						{
							dlgEditTowValues.InputValue2 = valuePoint_0.ShadowPoint.Value.ToString();
						}
						dlgEditTowValues.InputParent2 = yAxisInfo2;
						dlgEditTowValues.EventOKButtonClick += method_2;
						dlgEditTowValues.Text = dlgEditTowValues.Text + " " + valuePoint_0.InstanceIndex;
						if (dlgEditTowValues.ShowDialog(temperatureControl_0) == DialogResult.OK)
						{
							float result = 0f;
							if (float.TryParse(dlgEditTowValues.InputValue1, out result))
							{
								valuePoint_0.Value = result;
							}
							else
							{
								valuePoint_0.Value = -10000f;
							}
							if (float.TryParse(dlgEditTowValues.InputValue2, out result))
							{
								valuePoint_0.ShadowPoint.Value = result;
							}
							else
							{
								valuePoint_0.Value = -10000f;
							}
							temperatureControl_0.Document.Modified = true;
							temperatureControl_0.Document.method_18();
							temperatureControl_0.DocumentViewControl.Invalidate();
							return true;
						}
					}
				}
			}
			return false;
		}

		private void method_2(object sender, CancelEventArgs e)
		{
			if (sender is dlgEditSingleValue)
			{
				dlgEditSingleValue dlgEditSingleValue = (dlgEditSingleValue)sender;
				float result = 0f;
				if (!float.TryParse(dlgEditSingleValue.InputValue, out result))
				{
					result = -10000f;
				}
				else if (dlgEditSingleValue.InputParent is YAxisInfo)
				{
					YAxisInfo yAxisInfo = (YAxisInfo)dlgEditSingleValue.InputParent;
					if (!yAxisInfo.method_2(result))
					{
						e.Cancel = true;
						MessageBox.Show(dlgEditSingleValue, string.Format(DCTimeLineStrings.InputValueOutofRange_Title__MinValue_MaxValue, yAxisInfo.Title, yAxisInfo.MinValue, yAxisInfo.MaxValue), DCTimeLineStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				if (!(sender is dlgEditTowValues))
				{
					return;
				}
				dlgEditTowValues dlgEditTowValues = (dlgEditTowValues)sender;
				float result = 0f;
				if (!float.TryParse(dlgEditTowValues.InputValue1, out result))
				{
					result = -10000f;
				}
				else if (dlgEditTowValues.InputParent1 is YAxisInfo)
				{
					YAxisInfo yAxisInfo = (YAxisInfo)dlgEditTowValues.InputParent1;
					if (!yAxisInfo.method_2(result))
					{
						e.Cancel = true;
						MessageBox.Show(dlgEditTowValues, string.Format(DCTimeLineStrings.InputValueOutofRange_Title__MinValue_MaxValue, yAxisInfo.Title, yAxisInfo.MinValue, yAxisInfo.MaxValue), DCTimeLineStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				float result2 = 0f;
				if (!float.TryParse(dlgEditTowValues.InputTitle2, out result2))
				{
					result2 = -10000f;
				}
				else if (dlgEditTowValues.InputParent2 is YAxisInfo)
				{
					YAxisInfo yAxisInfo = (YAxisInfo)dlgEditTowValues.InputParent2;
					if (!yAxisInfo.method_2(result2))
					{
						e.Cancel = true;
						MessageBox.Show(dlgEditTowValues, string.Format(DCTimeLineStrings.InputValueOutofRange_Title__MinValue_MaxValue, yAxisInfo.Title, yAxisInfo.MinValue, yAxisInfo.MaxValue), DCTimeLineStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}
	}
}
