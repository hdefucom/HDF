using DCSoft.FriedmanCurveChart;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass152
	{
		private FriedmanCurveControl friedmanCurveControl_0;

		public GClass152(FriedmanCurveControl friedmanCurveControl_1)
		{
			int num = 18;
			friedmanCurveControl_0 = null;
			
			if (friedmanCurveControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			friedmanCurveControl_0 = friedmanCurveControl_1;
		}

		public bool method_0(FriedmanCurveDocument friedmanCurveDocument_0)
		{
			int num = 12;
			if (friedmanCurveDocument_0 == null)
			{
				throw new ArgumentNullException("lbl");
			}
			using (FCdlgTitleValues fCdlgTitleValues = new FCdlgTitleValues())
			{
				foreach (FCHeaderLabelInfo headerLabel in friedmanCurveControl_0.Document.HeaderLabels)
				{
					fCdlgTitleValues.InputTitles.Add(headerLabel.Title);
					fCdlgTitleValues.InputValues.Add(headerLabel.Value);
				}
				if (fCdlgTitleValues.ShowDialog(friedmanCurveControl_0) == DialogResult.OK)
				{
					for (int i = 0; i < fCdlgTitleValues.InputValues.Count; i++)
					{
						friedmanCurveControl_0.Document.HeaderLabels[i].Value = fCdlgTitleValues.InputValues[i];
					}
					friedmanCurveControl_0.Document.Modified = true;
					friedmanCurveControl_0.Invalidate(invalidateChildren: true);
					return true;
				}
			}
			return false;
		}

		public bool method_1(FCValuePoint fcvaluePoint_0)
		{
			int num = 15;
			if (fcvaluePoint_0 == null)
			{
				throw new ArgumentNullException("vp");
			}
			if (fcvaluePoint_0.Parent is FCTitleLineInfo)
			{
				FCTitleLineInfo fCTitleLineInfo = (FCTitleLineInfo)fcvaluePoint_0.Parent;
				using (FCdlgEditSingleValue fCdlgEditSingleValue = new FCdlgEditSingleValue())
				{
					fCdlgEditSingleValue.InputTime = fcvaluePoint_0.Time;
					fCdlgEditSingleValue.InputTitle = string.Format(DCFriedmanCurveStrings.InputTitle_Name, fCTitleLineInfo.Title);
					fCdlgEditSingleValue.InputValue = fcvaluePoint_0.Text;
					if (fCdlgEditSingleValue.ShowDialog(friedmanCurveControl_0) == DialogResult.OK)
					{
						fcvaluePoint_0.Text = fCdlgEditSingleValue.InputValue;
						friedmanCurveControl_0.Document.method_39();
						friedmanCurveControl_0.DocumentViewControl.Invalidate();
						return true;
					}
				}
			}
			else if (fcvaluePoint_0.Parent is FCYAxisInfo)
			{
				FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)fcvaluePoint_0.Parent;
				if (fCYAxisInfo.Style == FCYAxisInfoStyle.Text)
				{
					using (FCdlgEditSingleValue fCdlgEditSingleValue = new FCdlgEditSingleValue())
					{
						fCdlgEditSingleValue.InputTime = fcvaluePoint_0.Time;
						fCdlgEditSingleValue.InputTitle = string.Format(DCFriedmanCurveStrings.InputTitle_Name, fCYAxisInfo.Title);
						fCdlgEditSingleValue.InputValue = fcvaluePoint_0.Text;
						fCdlgEditSingleValue.Text = fCdlgEditSingleValue.Text + " " + fcvaluePoint_0.InstanceIndex;
						if (fCdlgEditSingleValue.ShowDialog(friedmanCurveControl_0) == DialogResult.OK)
						{
							fcvaluePoint_0.Text = fCdlgEditSingleValue.InputValue;
							friedmanCurveControl_0.Document.Modified = true;
							friedmanCurveControl_0.DocumentViewControl.Invalidate();
							return true;
						}
					}
				}
				else if (fcvaluePoint_0.ShadowPoint == null || !fcvaluePoint_0.ShowShadowPoint)
				{
					if (fCYAxisInfo.EnableLanternValue)
					{
						using (FCdlgEditTowValues fCdlgEditTowValues = new FCdlgEditTowValues())
						{
							fCdlgEditTowValues.InputTime = fcvaluePoint_0.Time;
							fCdlgEditTowValues.InputTitle1 = string.Format(DCFriedmanCurveStrings.InputTitle_Name_Min_Max, fCYAxisInfo.Title, fCYAxisInfo.MinValue, fCYAxisInfo.MaxValue);
							fCdlgEditTowValues.Text = fCdlgEditTowValues.Text + " " + fcvaluePoint_0.InstanceIndex;
							if (!FriedmanCurveDocument.smethod_3(fcvaluePoint_0.Value))
							{
								fCdlgEditTowValues.InputValue1 = fcvaluePoint_0.Value.ToString();
							}
							fCdlgEditTowValues.InputParent1 = fCYAxisInfo;
							if (string.IsNullOrEmpty(fCYAxisInfo.LanternValueTitle))
							{
								fCdlgEditTowValues.InputTitle2 = DCFriedmanCurveStrings.DefaultLanternValueTitle;
							}
							else
							{
								fCdlgEditTowValues.InputTitle2 = fCYAxisInfo.LanternValueTitle;
							}
							if (!FriedmanCurveDocument.smethod_3(fcvaluePoint_0.LanternValue))
							{
								fCdlgEditTowValues.InputValue2 = fcvaluePoint_0.LanternValue.ToString();
							}
							fCdlgEditTowValues.InputParent2 = fCYAxisInfo;
							fCdlgEditTowValues.EventOKButtonClick += method_2;
							if (fCdlgEditTowValues.ShowDialog(friedmanCurveControl_0) == DialogResult.OK)
							{
								float result = 0f;
								if (float.TryParse(fCdlgEditTowValues.InputValue1, out result))
								{
									fcvaluePoint_0.Value = result;
								}
								else
								{
									fcvaluePoint_0.Value = -10000f;
								}
								if (float.TryParse(fCdlgEditTowValues.InputValue2, out result))
								{
									fcvaluePoint_0.LanternValue = result;
								}
								else
								{
									fcvaluePoint_0.LanternValue = -10000f;
								}
								friedmanCurveControl_0.Document.Modified = true;
								friedmanCurveControl_0.Document.method_39();
								friedmanCurveControl_0.DocumentViewControl.Invalidate();
								return true;
							}
						}
					}
					else
					{
						using (FCdlgEditSingleValue fCdlgEditSingleValue = new FCdlgEditSingleValue())
						{
							fCdlgEditSingleValue.InputTime = fcvaluePoint_0.Time;
							fCdlgEditSingleValue.InputTitle = string.Format(DCFriedmanCurveStrings.InputTitle_Name_Min_Max, fCYAxisInfo.Title, fCYAxisInfo.MinValue, fCYAxisInfo.MaxValue);
							if (!FriedmanCurveDocument.smethod_3(fcvaluePoint_0.Value))
							{
								fCdlgEditSingleValue.InputValue = fcvaluePoint_0.Value.ToString();
							}
							fCdlgEditSingleValue.InputParent = fCYAxisInfo;
							fCdlgEditSingleValue.EventOKButtonClick += method_2;
							fCdlgEditSingleValue.Text = fCdlgEditSingleValue.Text + " " + fcvaluePoint_0.InstanceIndex;
							if (fCdlgEditSingleValue.ShowDialog(friedmanCurveControl_0) == DialogResult.OK)
							{
								float result = 0f;
								if (float.TryParse(fCdlgEditSingleValue.InputValue, out result))
								{
									fcvaluePoint_0.Value = result;
								}
								else
								{
									fcvaluePoint_0.Value = -10000f;
								}
								friedmanCurveControl_0.Document.Modified = true;
								friedmanCurveControl_0.Document.method_39();
								friedmanCurveControl_0.DocumentViewControl.Invalidate();
								return true;
							}
						}
					}
				}
				else
				{
					FCYAxisInfo fCYAxisInfo2 = (FCYAxisInfo)fcvaluePoint_0.ShadowPoint.Parent;
					using (FCdlgEditTowValues fCdlgEditTowValues = new FCdlgEditTowValues())
					{
						fCdlgEditTowValues.InputTime = fcvaluePoint_0.Time;
						fCdlgEditTowValues.InputTitle1 = string.Format(DCFriedmanCurveStrings.InputTitle_Name_Min_Max, fCYAxisInfo.Title, fCYAxisInfo.MinValue, fCYAxisInfo.MaxValue);
						if (!FriedmanCurveDocument.smethod_3(fcvaluePoint_0.Value))
						{
							fCdlgEditTowValues.InputValue1 = fcvaluePoint_0.Value.ToString();
						}
						fCdlgEditTowValues.InputParent1 = fCYAxisInfo;
						fCdlgEditTowValues.InputTitle2 = string.Format(DCFriedmanCurveStrings.InputTitle_Name_Min_Max, fCYAxisInfo2.Title, fCYAxisInfo2.MinValue, fCYAxisInfo2.MaxValue);
						if (!FriedmanCurveDocument.smethod_3(fcvaluePoint_0.ShadowPoint.Value))
						{
							fCdlgEditTowValues.InputValue2 = fcvaluePoint_0.ShadowPoint.Value.ToString();
						}
						fCdlgEditTowValues.InputParent2 = fCYAxisInfo2;
						fCdlgEditTowValues.EventOKButtonClick += method_2;
						fCdlgEditTowValues.Text = fCdlgEditTowValues.Text + " " + fcvaluePoint_0.InstanceIndex;
						if (fCdlgEditTowValues.ShowDialog(friedmanCurveControl_0) == DialogResult.OK)
						{
							float result = 0f;
							if (float.TryParse(fCdlgEditTowValues.InputValue1, out result))
							{
								fcvaluePoint_0.Value = result;
							}
							else
							{
								fcvaluePoint_0.Value = -10000f;
							}
							if (float.TryParse(fCdlgEditTowValues.InputValue2, out result))
							{
								fcvaluePoint_0.ShadowPoint.Value = result;
							}
							else
							{
								fcvaluePoint_0.Value = -10000f;
							}
							friedmanCurveControl_0.Document.Modified = true;
							friedmanCurveControl_0.Document.method_39();
							friedmanCurveControl_0.DocumentViewControl.Invalidate();
							return true;
						}
					}
				}
			}
			return false;
		}

		private void method_2(object sender, CancelEventArgs e)
		{
			if (sender is FCdlgEditSingleValue)
			{
				FCdlgEditSingleValue fCdlgEditSingleValue = (FCdlgEditSingleValue)sender;
				float result = 0f;
				if (!float.TryParse(fCdlgEditSingleValue.InputValue, out result))
				{
					result = -10000f;
				}
				else if (fCdlgEditSingleValue.InputParent is FCYAxisInfo)
				{
					FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)fCdlgEditSingleValue.InputParent;
					if (!fCYAxisInfo.method_2(result))
					{
						e.Cancel = true;
						MessageBox.Show(fCdlgEditSingleValue, string.Format(DCFriedmanCurveStrings.InputValueOutofRange_Title__MinValue_MaxValue, fCYAxisInfo.Title, fCYAxisInfo.MinValue, fCYAxisInfo.MaxValue), DCFriedmanCurveStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				if (!(sender is FCdlgEditTowValues))
				{
					return;
				}
				FCdlgEditTowValues fCdlgEditTowValues = (FCdlgEditTowValues)sender;
				float result = 0f;
				if (!float.TryParse(fCdlgEditTowValues.InputValue1, out result))
				{
					result = -10000f;
				}
				else if (fCdlgEditTowValues.InputParent1 is FCYAxisInfo)
				{
					FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)fCdlgEditTowValues.InputParent1;
					if (!fCYAxisInfo.method_2(result))
					{
						e.Cancel = true;
						MessageBox.Show(fCdlgEditTowValues, string.Format(DCFriedmanCurveStrings.InputValueOutofRange_Title__MinValue_MaxValue, fCYAxisInfo.Title, fCYAxisInfo.MinValue, fCYAxisInfo.MaxValue), DCFriedmanCurveStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				float result2 = 0f;
				if (!float.TryParse(fCdlgEditTowValues.InputTitle2, out result2))
				{
					result2 = -10000f;
				}
				else if (fCdlgEditTowValues.InputParent2 is FCYAxisInfo)
				{
					FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)fCdlgEditTowValues.InputParent2;
					if (!fCYAxisInfo.method_2(result2))
					{
						e.Cancel = true;
						MessageBox.Show(fCdlgEditTowValues, string.Format(DCFriedmanCurveStrings.InputValueOutofRange_Title__MinValue_MaxValue, fCYAxisInfo.Title, fCYAxisInfo.MinValue, fCYAxisInfo.MaxValue), DCFriedmanCurveStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}
	}
}
