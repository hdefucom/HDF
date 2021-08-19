using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.FriedmanCurveChart;
using DCSoft.TemperatureChart;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.MedicalExpression;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       插入内容编辑器命令容器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("Insert")]
	internal class WriterCommandModuleInsert : WriterCommandModule
	{
		/// <summary>
		///       插入医学表达式命令
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("InsertNewMedicalExpression")]
		public void InsertNewMedicalExpression(object sender, WriterCommandEventArgs e)
		{
			int num = 16;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null)
				{
					e.Enabled = e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextNewMedicalExpressionElement));
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = null;
				if (e.Parameter is XTextNewMedicalExpressionElement)
				{
					xTextNewMedicalExpressionElement = (XTextNewMedicalExpressionElement)e.Parameter;
				}
				if (xTextNewMedicalExpressionElement == null)
				{
					xTextNewMedicalExpressionElement = new XTextNewMedicalExpressionElement();
					xTextNewMedicalExpressionElement.OwnerDocument = e.Document;
				}
				e.Document.AllocElementID("exp", xTextNewMedicalExpressionElement);
				if (e.ShowUI)
				{
					xTextNewMedicalExpressionElement.OwnerDocument = e.Document;
					if (!WriterAppHost.smethod_4(e, xTextNewMedicalExpressionElement, ElementPropertiesEditMethod.Insert))
					{
						xTextNewMedicalExpressionElement.Dispose();
						xTextNewMedicalExpressionElement = null;
					}
				}
				if (xTextNewMedicalExpressionElement == null)
				{
					return;
				}
				XTextElement currentElement = e.Document.CurrentElement;
				xTextNewMedicalExpressionElement.StyleIndex = currentElement.StyleIndex;
				if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FourValues)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "2016/4/14";
						xTextNewMedicalExpressionElement.Values.Value2 = "3";
						xTextNewMedicalExpressionElement.Values.Value3 = "30";
						xTextNewMedicalExpressionElement.Values.Value4 = "2016/4/14";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FourValues1)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
						xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FourValues2)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
						xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.ThreeValues)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.Pupil)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
						xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
						xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
						xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
						xTextNewMedicalExpressionElement.Values.Value7 = "Value7";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.LightPositioning)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
						xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
						xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
						xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
						xTextNewMedicalExpressionElement.Values.Value7 = "Value7";
						xTextNewMedicalExpressionElement.Values.Value8 = "Value8";
						xTextNewMedicalExpressionElement.Values.Value9 = "Value9";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FetalHeart)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
						xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
						xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
						xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.PermanentTeethBitmap)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "8";
						xTextNewMedicalExpressionElement.Values.Value2 = "7";
						xTextNewMedicalExpressionElement.Values.Value3 = "6";
						xTextNewMedicalExpressionElement.Values.Value4 = "5";
						xTextNewMedicalExpressionElement.Values.Value5 = "4";
						xTextNewMedicalExpressionElement.Values.Value6 = "3";
						xTextNewMedicalExpressionElement.Values.Value7 = "2";
						xTextNewMedicalExpressionElement.Values.Value8 = "1";
						xTextNewMedicalExpressionElement.Values.Value9 = "1";
						xTextNewMedicalExpressionElement.Values.Value10 = "2";
						xTextNewMedicalExpressionElement.Values.Value11 = "3";
						xTextNewMedicalExpressionElement.Values.Value12 = "4";
						xTextNewMedicalExpressionElement.Values.Value13 = "5";
						xTextNewMedicalExpressionElement.Values.Value14 = "6";
						xTextNewMedicalExpressionElement.Values.Value15 = "7";
						xTextNewMedicalExpressionElement.Values.Value16 = "8";
						xTextNewMedicalExpressionElement.Values.Value17 = "8";
						xTextNewMedicalExpressionElement.Values.Value18 = "7";
						xTextNewMedicalExpressionElement.Values.Value19 = "6";
						xTextNewMedicalExpressionElement.Values.Value20 = "5";
						xTextNewMedicalExpressionElement.Values.Value21 = "4";
						xTextNewMedicalExpressionElement.Values.Value22 = "3";
						xTextNewMedicalExpressionElement.Values.Value23 = "2";
						xTextNewMedicalExpressionElement.Values.Value24 = "1";
						xTextNewMedicalExpressionElement.Values.Value25 = "1";
						xTextNewMedicalExpressionElement.Values.Value26 = "2";
						xTextNewMedicalExpressionElement.Values.Value27 = "3";
						xTextNewMedicalExpressionElement.Values.Value28 = "4";
						xTextNewMedicalExpressionElement.Values.Value29 = "5";
						xTextNewMedicalExpressionElement.Values.Value30 = "6";
						xTextNewMedicalExpressionElement.Values.Value31 = "7";
						xTextNewMedicalExpressionElement.Values.Value32 = "8";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.DeciduousTeech)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values.Value1 = "Ⅴ";
						xTextNewMedicalExpressionElement.Values.Value2 = "Ⅳ";
						xTextNewMedicalExpressionElement.Values.Value3 = "Ⅲ";
						xTextNewMedicalExpressionElement.Values.Value4 = "Ⅱ";
						xTextNewMedicalExpressionElement.Values.Value5 = "Ⅰ";
						xTextNewMedicalExpressionElement.Values.Value6 = "Ⅰ";
						xTextNewMedicalExpressionElement.Values.Value7 = "Ⅱ";
						xTextNewMedicalExpressionElement.Values.Value8 = "Ⅲ";
						xTextNewMedicalExpressionElement.Values.Value9 = "Ⅳ";
						xTextNewMedicalExpressionElement.Values.Value10 = "Ⅴ";
						xTextNewMedicalExpressionElement.Values.Value11 = "Ⅴ";
						xTextNewMedicalExpressionElement.Values.Value12 = "Ⅳ";
						xTextNewMedicalExpressionElement.Values.Value13 = "Ⅲ";
						xTextNewMedicalExpressionElement.Values.Value14 = "Ⅱ";
						xTextNewMedicalExpressionElement.Values.Value15 = "Ⅰ";
						xTextNewMedicalExpressionElement.Values.Value16 = "Ⅰ";
						xTextNewMedicalExpressionElement.Values.Value17 = "Ⅱ";
						xTextNewMedicalExpressionElement.Values.Value18 = "Ⅲ";
						xTextNewMedicalExpressionElement.Values.Value19 = "Ⅳ";
						xTextNewMedicalExpressionElement.Values.Value20 = "Ⅴ";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.PDTeech)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
						xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
						xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
						xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.DiseasedTeethBotton)
				{
					if (!xTextNewMedicalExpressionElement.HasValues)
					{
						xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
						xTextNewMedicalExpressionElement.Values.Value1 = "FI";
						xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
						xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					}
				}
				else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.DiseasedTeethTop && !xTextNewMedicalExpressionElement.HasValues)
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "1";
					xTextNewMedicalExpressionElement.Values.Value2 = "2";
					xTextNewMedicalExpressionElement.Values.Value3 = "3";
				}
				xTextNewMedicalExpressionElement.vmethod_0(bool_5: true);
				e.DocumentControler.InsertElement(xTextNewMedicalExpressionElement);
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Result = xTextNewMedicalExpressionElement;
			}
		}

		/// <summary>
		///       插入若干个文档元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertElements")]
		protected void InsertElements(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null)
				{
					e.Enabled = e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement));
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = 0;
				XTextElementList xTextElementList = e.Parameter as XTextElementList;
				if (xTextElementList != null && e.UIStartEditContent())
				{
					xTextElementList.method_0(bool_1: true);
					int num = e.DocumentControler.InsertElements(xTextElementList);
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = num;
				}
			}
		}

		/// <summary>
		///       插入文档节
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertSection", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertSection.bmp", ReturnValueType = typeof(XTextSectionElement), FunctionID = GEnum6.const_85)]
		protected void InsertSection(object sender, WriterCommandEventArgs e)
		{
			int num = 12;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextContainerElement container = null;
					int elementIndex = 0;
					e.Document.Content.GetCurrentPositionInfo(out container, out elementIndex);
					if (container is XTextDocumentBodyElement)
					{
						e.Enabled = e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextSectionElement));
					}
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextContainerElement container = null;
				int elementIndex = 0;
				e.Document.Content.GetCurrentPositionInfo(out container, out elementIndex);
				if (!(container is XTextDocumentBodyElement))
				{
					return;
				}
				XTextSectionElement xTextSectionElement = e.Parameter as XTextSectionElement;
				if (xTextSectionElement == null)
				{
					xTextSectionElement = (XTextSectionElement)e.Document.CreateElementByType(typeof(XTextSectionElement));
					xTextSectionElement.CompressOwnerLineSpacing = true;
				}
				xTextSectionElement.Parent = container;
				xTextSectionElement.OwnerDocument = e.Document;
				if (string.IsNullOrEmpty(xTextSectionElement.ID))
				{
					e.Document.AllocElementID("section", xTextSectionElement);
				}
				if (string.IsNullOrEmpty(xTextSectionElement.Name))
				{
					xTextSectionElement.Name = xTextSectionElement.ID;
				}
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextSectionElement, ElementPropertiesEditMethod.Insert))
				{
					xTextSectionElement.Dispose();
					xTextSectionElement = null;
				}
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)e.Document.CreateElementByType(typeof(XTextParagraphFlagElement));
				if (xTextSectionElement != null && xTextParagraphFlagElement != null)
				{
					xTextParagraphFlagElement.StyleIndex = -1;
					xTextSectionElement.StyleIndex = -1;
					xTextSectionElement.FixElements();
					using (DCGraphics dcgraphics_ = e.Document.CreateDCGraphics())
					{
						DocumentPaintEventArgs documentPaintEventArgs = e.Document.method_55(dcgraphics_);
						documentPaintEventArgs.Element = xTextParagraphFlagElement;
						xTextParagraphFlagElement.RefreshSize(documentPaintEventArgs);
						documentPaintEventArgs.Element = xTextSectionElement;
						xTextSectionElement.RefreshSize(documentPaintEventArgs);
					}
					XTextElementList xTextElementList = new XTextElementList();
					xTextElementList.Add(xTextSectionElement);
					e.Document.ValidateElementIDRepeat(xTextSectionElement);
					e.Document.BeginLogUndo();
					int num2 = e.Document.InsertElements(xTextElementList, updateContent: true);
					e.Document.EndLogUndo();
					if (num2 > 0)
					{
						int viewIndex = xTextSectionElement.Elements[0].ViewIndex;
						e.Document.Content.method_47(viewIndex, 0);
						e.Document.OnDocumentContentChanged();
						e.Result = xTextSectionElement;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       删除文档节
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DeleteSection", ReturnValueType = typeof(bool), DefaultResultValue = false)]
		protected void DeleteSection(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document == null)
				{
					return;
				}
				XTextContainerElement container = null;
				int elementIndex = 0;
				e.Document.Content.GetCurrentPositionInfo(out container, out elementIndex);
				while (true)
				{
					if (container != null)
					{
						if (container is XTextSectionElement)
						{
							break;
						}
						container = container.Parent;
						continue;
					}
					return;
				}
				e.Enabled = true;
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (!e.UIStartEditContent())
				{
					return;
				}
				XTextContainerElement container = null;
				int elementIndex = 0;
				e.Document.Content.GetCurrentPositionInfo(out container, out elementIndex);
				while (true)
				{
					if (container != null)
					{
						if (container is XTextSectionElement)
						{
							break;
						}
						container = container.Parent;
						continue;
					}
					return;
				}
				container.EditorDelete(logUndo: true);
				e.Result = true;
			}
		}

		/// <summary>
		///       插入强制分页符
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertPageBreak", ReturnValueType = typeof(bool), DefaultResultValue = false, ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertPageBreak.bmp")]
		protected void InsertPageBreak(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null)
				{
					e.Enabled = e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextPageBreakElement));
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)e.Document.CreateElementByType(typeof(XTextParagraphFlagElement));
					XTextPageBreakElement xTextPageBreakElement = (XTextPageBreakElement)e.Document.CreateElementByType(typeof(XTextPageBreakElement));
					if (xTextParagraphFlagElement != null && xTextPageBreakElement != null)
					{
						xTextParagraphFlagElement.StyleIndex = e.Document.CurrentParagraphEOF.StyleIndex;
						xTextPageBreakElement.StyleIndex = -1;
						using (DCGraphics dcgraphics_ = e.Document.CreateDCGraphics())
						{
							DocumentPaintEventArgs documentPaintEventArgs = e.Document.method_55(dcgraphics_);
							documentPaintEventArgs.Element = xTextParagraphFlagElement;
							xTextParagraphFlagElement.RefreshSize(documentPaintEventArgs);
							documentPaintEventArgs.Element = xTextPageBreakElement;
							xTextPageBreakElement.RefreshSize(documentPaintEventArgs);
						}
						XTextElementList xTextElementList = new XTextElementList();
						xTextElementList.Add(xTextPageBreakElement);
						e.Document.BeginLogUndo();
						xTextElementList.method_0(bool_1: true);
						e.Document.InsertElements(xTextElementList, updateContent: true);
						e.Document.Content.MoveToPosition(xTextPageBreakElement.ViewIndex + 1);
						XTextElement element = e.Document.Content.SafeGet(xTextPageBreakElement.ViewIndex + 1);
						e.Document.Content.MoveToElement(element);
						e.Document.EndLogUndo();
						e.Document.OnDocumentContentChanged();
						e.Result = true;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       将文档中的文本内容转换为表单元素的标签值
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ConvertTextContentToElementLabel")]
		protected void ConvertTextContentToElementLabel(object sender, WriterCommandEventArgs e)
		{
			int num = 4;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null && e.Document.Selection.Length != 0)
				{
					e.Enabled = (e.DocumentControler.CanInsertAtCurrentPosition && e.DocumentControler.Snapshot.CanDeleteSelection);
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent() || e.DocumentControler == null || e.Document.Selection.Length == 0 || e.DocumentControler.EditorControlReadonly)
				{
					return;
				}
				XTextElement firstElement = e.Document.Selection.FirstElement;
				XTextElement lastElement = e.Document.Selection.LastElement;
				XTextContainerElement xTextContainerElement = WriterUtils.smethod_56(firstElement, lastElement);
				if (xTextContainerElement is XTextTableElement)
				{
					xTextContainerElement = xTextContainerElement.Parent;
				}
				else if (xTextContainerElement is XTextTableRowElement)
				{
					xTextContainerElement = xTextContainerElement.Parent.Parent;
				}
				int num2 = -1;
				XTextElement xTextElement = firstElement;
				while (xTextElement != null)
				{
					if (xTextElement.Parent != xTextContainerElement)
					{
						xTextElement = xTextElement.Parent;
						continue;
					}
					num2 = xTextContainerElement.Elements.IndexOf(xTextElement);
					break;
				}
				int num3 = -1;
				xTextElement = lastElement;
				while (xTextElement != null)
				{
					if (xTextElement.Parent != xTextContainerElement)
					{
						xTextElement = xTextElement.Parent;
						continue;
					}
					num3 = xTextContainerElement.Elements.IndexOf(xTextElement);
					break;
				}
				if (num2 < 0 || num3 < 0 || num3 < num2)
				{
					return;
				}
				StringBuilder stringBuilder = new StringBuilder();
				XTextDocumentContentElement documentContentElement = xTextContainerElement.DocumentContentElement;
				bool flag = false;
				XTextElement xTextElement2 = null;
				for (int i = num2; i <= num3; i++)
				{
					xTextElement = xTextContainerElement.Elements[i];
					if (!(xTextElement is XTextInputFieldElement) && !documentContentElement.Content.Contains(xTextElement))
					{
						continue;
					}
					if (xTextElement is XTextCharElement || xTextElement is XTextLabelElement)
					{
						if (documentContentElement.Content.Contains(xTextElement))
						{
							stringBuilder.Append(xTextElement.Text);
						}
						continue;
					}
					if (xTextElement is XTextInputFieldElement || xTextElement is XTextCheckBoxElement || xTextElement is XTextRadioBoxElement)
					{
						flag = (stringBuilder.Length > 0);
						if (xTextElement2 == null)
						{
							xTextElement2 = xTextElement;
							continue;
						}
						return;
					}
					return;
				}
				if (xTextElement2 == null || stringBuilder.Length <= 0)
				{
					return;
				}
				e.Document.BeginLogUndo();
				if (xTextElement2 is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElement2;
					if (flag)
					{
						string text = xTextInputFieldElement.LabelText;
						if (text != null)
						{
							text = text.Trim();
						}
						string text2 = stringBuilder.ToString() + text;
						e.Document.UndoList.AddProperty("LabelText", xTextInputFieldElement.LabelText, text2, xTextInputFieldElement);
						xTextInputFieldElement.LabelText = text2;
					}
					else
					{
						string text3 = xTextInputFieldElement.UnitText;
						if (text3 != null)
						{
							text3 = text3.Trim();
						}
						string text2 = text3 + stringBuilder.ToString();
						e.Document.UndoList.AddProperty("UnitText", xTextInputFieldElement.UnitText, text2, xTextInputFieldElement);
						xTextInputFieldElement.UnitText = text2;
					}
				}
				else if (xTextElement2 is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xTextElement2;
					string text2 = stringBuilder.ToString() + xTextCheckBoxElementBase.Caption;
					string text4 = xTextCheckBoxElementBase.Caption;
					if (text4 != null)
					{
						text4 = text4.Trim();
					}
					text2 = ((!flag) ? (text4 + stringBuilder.ToString()) : (stringBuilder.ToString() + text4));
					e.Document.UndoList.AddProperty("Caption", xTextCheckBoxElementBase.Caption, text2, xTextCheckBoxElementBase);
					xTextCheckBoxElementBase.Caption = text2;
					e.Document.UndoList.AddProperty("CheckAlignLeft", xTextCheckBoxElementBase.CheckAlignLeft, !flag, xTextCheckBoxElementBase);
					xTextCheckBoxElementBase.CheckAlignLeft = !flag;
				}
				GEventArgs4 gEventArgs = new GEventArgs4();
				gEventArgs.method_9(xTextContainerElement);
				gEventArgs.method_11(num2);
				gEventArgs.method_13(num3 - num2 + 1);
				gEventArgs.method_15(new XTextElementList());
				gEventArgs.method_14().Add(xTextElement2);
				xTextElement2.SizeInvalid = true;
				gEventArgs.method_19(bool_10: true);
				gEventArgs.method_21(bool_10: true);
				gEventArgs.method_25(bool_10: true);
				int num4 = e.Document.method_63(gEventArgs);
				e.Document.EndLogUndo();
				if (num4 > 0)
				{
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = xTextElement2;
				}
			}
		}

		/// <summary>
		///       将文档中当前插入点所在的输入域转换为普通文档内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ConvertFieldToContent", ReturnValueType = typeof(bool))]
		protected void ConvertFieldToContent(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)e.Document.GetCurrentElement(typeof(XTextFieldElementBase), includeThis: false);
					if (xTextFieldElementBase != null)
					{
						e.Enabled = true;
					}
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)e.Document.GetCurrentElement(typeof(XTextFieldElementBase), includeThis: false);
				if (xTextFieldElementBase == null)
				{
					return;
				}
				XTextContainerElement parent = xTextFieldElementBase.Parent;
				foreach (XTextElement element in xTextFieldElementBase.Elements)
				{
					if (!e.DocumentControler.AcceptChildElement(parent, element.GetType(), DomAccessFlags.Normal))
					{
						return;
					}
				}
				if (e.UIStartEditContent() && e.DocumentControler.method_18(xTextFieldElementBase))
				{
					GEventArgs4 gEventArgs = new GEventArgs4();
					gEventArgs.method_9(parent);
					gEventArgs.method_11(parent.Elements.IndexOf(xTextFieldElementBase));
					gEventArgs.method_13(1);
					XTextElementList xTextElementList = new XTextElementList();
					foreach (XTextElement element2 in xTextFieldElementBase.Elements)
					{
						xTextElementList.AddRaw(element2);
					}
					gEventArgs.method_15(xTextElementList);
					gEventArgs.method_25(bool_10: true);
					gEventArgs.method_21(bool_10: true);
					gEventArgs.method_29(DomAccessFlags.Normal);
					gEventArgs.method_31(bool_10: true);
					gEventArgs.method_27(bool_10: false);
					gEventArgs.method_19(bool_10: true);
					e.Document.BeginLogUndo();
					int num = e.Document.method_63(gEventArgs);
					e.Document.EndLogUndo();
					e.RefreshLevel = UIStateRefreshLevel.All;
					if (num > 0)
					{
						e.Result = true;
					}
				}
			}
		}

		/// <summary>
		///       将文档中被选择的内容转换为输入域
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ConvertContentToField", ReturnValueType = typeof(XTextInputFieldElement))]
		protected void ConvertContentToField(object sender, WriterCommandEventArgs e)
		{
			int num = 0;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null && e.Document.Selection.Length != 0 && !e.DocumentControler.EditorControlReadonly)
				{
					XTextElement xTextElement = e.Document.Selection.FirstElement;
					XTextElement xTextElement2 = e.Document.Selection.LastElement;
					XTextElement xTextElement3 = WriterUtils.smethod_56(xTextElement, xTextElement2);
					if (xTextElement3 is XTextTableRowElement)
					{
						xTextElement3 = xTextElement3.Parent.Parent;
					}
					else if (xTextElement3 is XTextTableElement)
					{
						xTextElement3 = xTextElement3.Parent;
					}
					while (xTextElement != null && xTextElement.Parent != xTextElement3)
					{
						xTextElement = xTextElement.Parent;
					}
					while (xTextElement2 != null && xTextElement2.Parent != xTextElement3)
					{
						xTextElement2 = xTextElement2.Parent;
					}
					if (e.DocumentControler.method_18(xTextElement) && e.DocumentControler.method_18(xTextElement2) && e.DocumentControler.AcceptChildElement(xTextElement3, typeof(XTextInputFieldElement), DomAccessFlags.None))
					{
						e.Enabled = true;
					}
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextElement xTextElement = e.Document.Selection.FirstElement;
				XTextElement xTextElement2 = e.Document.Selection.LastElement;
				XTextContainerElement xTextContainerElement = WriterUtils.smethod_56(xTextElement, xTextElement2);
				if (xTextContainerElement is XTextTableElement)
				{
					xTextContainerElement = xTextContainerElement.Parent;
				}
				else if (xTextContainerElement is XTextTableRowElement)
				{
					xTextContainerElement = xTextContainerElement.Parent.Parent;
				}
				if (!e.DocumentControler.AcceptChildElement(xTextContainerElement, typeof(XTextInputFieldElement), DomAccessFlags.None))
				{
					return;
				}
				while (xTextElement != null && xTextElement.Parent != xTextContainerElement)
				{
					xTextElement = xTextElement.Parent;
				}
				while (xTextElement2 != null && xTextElement2.Parent != xTextContainerElement)
				{
					xTextElement2 = xTextElement2.Parent;
				}
				XTextInputFieldElement xTextInputFieldElement = null;
				if (e.Parameter is XTextInputFieldElement)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Parameter;
				}
				else if (e.Parameter is InputFieldSettings)
				{
					xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.FieldSettings = (InputFieldSettings)e.Parameter;
				}
				else if (e.Parameter is XDataBinding)
				{
					xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.ValueBinding = (XDataBinding)e.Parameter;
				}
				else if (e.Parameter is ValueValidateStyle)
				{
					xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.ValidateStyle = (ValueValidateStyle)e.Parameter;
				}
				if (xTextInputFieldElement == null)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Document.CreateElementByType(typeof(XTextInputFieldElement));
					if (xTextInputFieldElement == null)
					{
						return;
					}
				}
				ElementType elementType = ElementType.None;
				int num2 = xTextContainerElement.Elements.IndexOf(xTextElement2);
				XTextElement xTextElement4;
				for (int i = xTextContainerElement.Elements.IndexOf(xTextElement); i <= num2; i++)
				{
					xTextElement4 = xTextContainerElement.Elements[i];
					elementType |= WriterUtils.smethod_64(xTextElement4.GetType());
					if (xTextElement4 is XTextParagraphFlagElement)
					{
						xTextInputFieldElement.AcceptChildElementTypes2 |= ElementType.ParagraphFlag;
					}
				}
				xTextInputFieldElement.AcceptChildElementTypes2 = elementType;
				e.Document.AllocElementID("field", xTextInputFieldElement);
				xTextInputFieldElement.OwnerDocument = e.Document;
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextInputFieldElement, ElementPropertiesEditMethod.Insert))
				{
					xTextInputFieldElement.Dispose();
					xTextInputFieldElement = null;
				}
				if (xTextInputFieldElement == null || !e.UIStartEditContent())
				{
					return;
				}
				int num3 = xTextContainerElement.Elements.IndexOf(xTextElement);
				int num4 = xTextContainerElement.Elements.IndexOf(xTextElement2);
				for (int i = num3; i <= num4; i++)
				{
					if (!e.DocumentControler.AcceptChildElement(xTextInputFieldElement, xTextContainerElement.Elements[i].GetType(), DomAccessFlags.None))
					{
						return;
					}
				}
				xTextElement4 = e.Document.CurrentElement;
				xTextInputFieldElement.StyleIndex = xTextElement4.StyleIndex;
				xTextInputFieldElement.StartElement.StyleIndex = xTextElement4.StyleIndex;
				xTextInputFieldElement.EndElement.StyleIndex = xTextElement4.StyleIndex;
				xTextInputFieldElement.OwnerDocument = e.Document;
				foreach (XTextElement element in xTextInputFieldElement.Elements)
				{
					element.StyleIndex = xTextElement4.StyleIndex;
				}
				using (DCGraphics dcgraphics_ = e.Document.CreateDCGraphics())
				{
					DocumentPaintEventArgs args = e.Document.method_55(dcgraphics_);
					xTextInputFieldElement.StartElement.RefreshSize(args);
					xTextInputFieldElement.EndElement.RefreshSize(args);
				}
				xTextInputFieldElement.Elements.Clear();
				for (int i = num3; i <= num4; i++)
				{
					xTextInputFieldElement.Elements.AddRaw(xTextContainerElement.Elements[i]);
				}
				GEventArgs4 gEventArgs = new GEventArgs4();
				gEventArgs.method_9(xTextContainerElement);
				gEventArgs.method_15(new XTextElementList());
				gEventArgs.method_14().Add(xTextInputFieldElement);
				gEventArgs.method_11(num3);
				gEventArgs.method_13(num4 - num3 + 1);
				gEventArgs.method_31(bool_10: true);
				gEventArgs.method_29(DomAccessFlags.Normal);
				gEventArgs.method_27(bool_10: false);
				gEventArgs.method_19(bool_10: true);
				gEventArgs.method_25(bool_10: true);
				gEventArgs.method_21(bool_10: true);
				e.Document.BeginLogUndo();
				int num5 = e.Document.method_63(gEventArgs);
				e.Document.EndLogUndo();
				e.RefreshLevel = UIStateRefreshLevel.All;
				if (num5 > 0)
				{
					e.Result = xTextInputFieldElement;
				}
			}
		}

		/// <summary>
		///       将文档中被选择的内容转换为输入域
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ConvertContentToContainerElement")]
		protected void ConvertContentToContainerElement(object sender, WriterCommandEventArgs e)
		{
			int num = 0;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null && e.Document.Selection.Length != 0 && !e.DocumentControler.EditorControlReadonly)
				{
					XTextElement xTextElement = e.Document.Selection.FirstElement;
					XTextElement xTextElement2 = e.Document.Selection.LastElement;
					XTextElement xTextElement3 = WriterUtils.smethod_56(xTextElement, xTextElement2);
					if (xTextElement3 is XTextTableRowElement)
					{
						xTextElement3 = xTextElement3.Parent.Parent;
					}
					else if (xTextElement3 is XTextTableElement)
					{
						xTextElement3 = xTextElement3.Parent;
					}
					while (xTextElement != null && xTextElement.Parent != xTextElement3)
					{
						xTextElement = xTextElement.Parent;
					}
					while (xTextElement2 != null && xTextElement2.Parent != xTextElement3)
					{
						xTextElement2 = xTextElement2.Parent;
					}
					if (e.DocumentControler.method_18(xTextElement) && e.DocumentControler.method_18(xTextElement2))
					{
						e.Enabled = true;
					}
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextElement xTextElement = e.Document.Selection.FirstElement;
				XTextElement xTextElement2 = e.Document.Selection.LastElement;
				XTextContainerElement xTextContainerElement = WriterUtils.smethod_56(xTextElement, xTextElement2);
				if (xTextContainerElement is XTextTableElement)
				{
					xTextContainerElement = xTextContainerElement.Parent;
				}
				else if (xTextContainerElement is XTextTableRowElement)
				{
					xTextContainerElement = xTextContainerElement.Parent.Parent;
				}
				while (xTextElement != null && xTextElement.Parent != xTextContainerElement)
				{
					xTextElement = xTextElement.Parent;
				}
				while (xTextElement2 != null && xTextElement2.Parent != xTextContainerElement)
				{
					xTextElement2 = xTextElement2.Parent;
				}
				XTextContainerElement xTextContainerElement2 = null;
				if (e.Parameter is XTextContainerElement)
				{
					xTextContainerElement2 = (XTextContainerElement)e.Parameter;
				}
				else if (e.Parameter is Type)
				{
					Type elementType = (Type)e.Parameter;
					xTextContainerElement2 = (XTextContainerElement)e.Document.CreateElementByType(elementType);
				}
				if (xTextContainerElement2 == null)
				{
					xTextContainerElement2 = (XTextInputFieldElement)e.Document.CreateElementByType(typeof(XTextInputFieldElement));
					if (xTextContainerElement2 == null)
					{
						return;
					}
				}
				if (!e.DocumentControler.AcceptChildElement(xTextContainerElement, xTextContainerElement2, DomAccessFlags.None))
				{
					if (e.Document.Options.BehaviorOptions.ShowDebugMessage)
					{
						string string_ = string.Format(WriterStrings.FailToAcceptChildElement_Parent_Child, WriterUtils.smethod_10(xTextContainerElement), WriterUtils.smethod_10(xTextContainerElement2));
						e.Host.UITools.ShowMessageBox(e.EditorControl, string_);
					}
					return;
				}
				ElementType elementType2 = ElementType.None;
				int num2 = xTextContainerElement.Elements.IndexOf(xTextElement2);
				XTextElement xTextElement4;
				for (int i = xTextContainerElement.Elements.IndexOf(xTextElement); i <= num2; i++)
				{
					xTextElement4 = xTextContainerElement.Elements[i];
					elementType2 |= WriterUtils.smethod_64(xTextElement4.GetType());
					if (xTextElement4 is XTextParagraphFlagElement && xTextContainerElement2 is XTextInputFieldElement)
					{
						((XTextInputFieldElement)xTextContainerElement2).AcceptChildElementTypes2 |= ElementType.ParagraphFlag;
					}
				}
				if (xTextContainerElement2 is XTextInputFieldElement)
				{
					((XTextInputFieldElement)xTextContainerElement2).AcceptChildElementTypes2 = elementType2;
				}
				if (string.IsNullOrEmpty(xTextContainerElement2.ID))
				{
					e.Document.AllocElementID("element", xTextContainerElement2);
				}
				xTextContainerElement2.OwnerDocument = e.Document;
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextContainerElement2, ElementPropertiesEditMethod.Insert))
				{
					xTextContainerElement2.Dispose();
					xTextContainerElement2 = null;
				}
				if (xTextContainerElement2 == null || !e.UIStartEditContent())
				{
					return;
				}
				int num3 = xTextContainerElement.Elements.IndexOf(xTextElement);
				int num4 = xTextContainerElement.Elements.IndexOf(xTextElement2);
				for (int i = num3; i <= num4; i++)
				{
					if (!e.DocumentControler.AcceptChildElement(xTextContainerElement2, xTextContainerElement.Elements[i].GetType(), DomAccessFlags.None))
					{
						return;
					}
				}
				xTextElement4 = e.Document.CurrentElement;
				xTextContainerElement2.StyleIndex = xTextElement4.StyleIndex;
				xTextContainerElement2.OwnerDocument = e.Document;
				if (xTextContainerElement2 is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextContainerElement2;
					xTextInputFieldElementBase.StartElement.StyleIndex = xTextElement4.StyleIndex;
					xTextInputFieldElementBase.EndElement.StyleIndex = xTextElement4.StyleIndex;
					foreach (XTextElement element in xTextContainerElement2.Elements)
					{
						element.StyleIndex = xTextElement4.StyleIndex;
					}
					using (DCGraphics dcgraphics_ = e.Document.CreateDCGraphics())
					{
						DocumentPaintEventArgs args = e.Document.method_55(dcgraphics_);
						xTextInputFieldElementBase.StartElement.RefreshSize(args);
						xTextInputFieldElementBase.EndElement.RefreshSize(args);
					}
				}
				xTextContainerElement2.Elements.Clear();
				for (int i = num3; i <= num4; i++)
				{
					xTextContainerElement2.Elements.AddRaw(xTextContainerElement.Elements[i]);
				}
				if (xTextContainerElement2 is XTextContentElement)
				{
					((XTextContentElement)xTextContainerElement2).FixElements();
				}
				GEventArgs4 gEventArgs = new GEventArgs4();
				gEventArgs.method_9(xTextContainerElement);
				gEventArgs.method_15(new XTextElementList());
				gEventArgs.method_14().Add(xTextContainerElement2);
				gEventArgs.method_11(num3);
				gEventArgs.method_13(num4 - num3 + 1);
				gEventArgs.method_31(bool_10: true);
				gEventArgs.method_29(DomAccessFlags.Normal);
				gEventArgs.method_27(bool_10: false);
				gEventArgs.method_19(bool_10: true);
				gEventArgs.method_25(bool_10: true);
				gEventArgs.method_21(bool_10: true);
				e.Document.BeginLogUndo();
				int num5 = e.Document.method_63(gEventArgs);
				e.Document.EndLogUndo();
				e.RefreshLevel = UIStateRefreshLevel.All;
				if (num5 > 0)
				{
					e.Result = xTextContainerElement2;
				}
			}
		}

		/// <summary>
		///       插入条形码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertAccountingNumber", ReturnValueType = typeof(XTextAccountingNumberElement))]
		protected void InsertAccountingNumber(object sender, WriterCommandEventArgs e)
		{
			int num = 15;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextAccountingNumberElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextAccountingNumberElement xTextAccountingNumberElement = null;
				if (e.Parameter is XTextAccountingNumberElement)
				{
					xTextAccountingNumberElement = (XTextAccountingNumberElement)e.Parameter;
				}
				if (xTextAccountingNumberElement == null)
				{
					xTextAccountingNumberElement = (XTextAccountingNumberElement)e.Document.CreateElementByType(typeof(XTextAccountingNumberElement));
					xTextAccountingNumberElement.OwnerDocument = e.Document;
					xTextAccountingNumberElement.SetInnerTextFast("12345.67");
				}
				e.Document.AllocElementID("account", xTextAccountingNumberElement);
				if ((!e.ShowUI || WriterAppHost.smethod_4(e, xTextAccountingNumberElement, ElementPropertiesEditMethod.Insert)) && xTextAccountingNumberElement != null && e.UIStartEditContent())
				{
					xTextAccountingNumberElement.OwnerDocument = e.Document;
					e.DocumentControler.InsertElement(xTextAccountingNumberElement);
					e.Result = xTextAccountingNumberElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入体温单
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertTemperatureChart", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertTemperatureChart.bmp", ReturnValueType = typeof(XTextTemperatureChartElement))]
		protected void InsertTemperatureChart(object sender, WriterCommandEventArgs e)
		{
			int num = 2;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextTemperatureChartElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextTemperatureChartElement xTextTemperatureChartElement = null;
				if (e.Parameter is XTextTemperatureChartElement)
				{
					xTextTemperatureChartElement = (XTextTemperatureChartElement)e.Parameter;
				}
				if (xTextTemperatureChartElement == null)
				{
					xTextTemperatureChartElement = (XTextTemperatureChartElement)e.Document.CreateElementByType(typeof(XTextTemperatureChartElement));
					xTextTemperatureChartElement.Width = 2000f;
					xTextTemperatureChartElement.Height = 2000f;
					if (e.Parameter is TemperatureDocument)
					{
						xTextTemperatureChartElement.Document = (TemperatureDocument)e.Parameter;
					}
				}
				e.Document.AllocElementID("tmp", xTextTemperatureChartElement);
				if (xTextTemperatureChartElement != null)
				{
					WriterCommandModule.CheckImageSizeWhenInsertImage(e.Document, xTextTemperatureChartElement, keepWidthHeightRate: false, null);
					xTextTemperatureChartElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextTemperatureChartElement);
					e.DocumentControler.InsertElement(xTextTemperatureChartElement);
					e.Result = xTextTemperatureChartElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入产程图
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertFriedmanCurveChart", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertFriedmanCurveChart.bmp", ReturnValueType = typeof(XTextFriedmanCurveChartElement))]
		protected void InsertFriedmanCurveChartChart(object sender, WriterCommandEventArgs e)
		{
			int num = 14;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextFriedmanCurveChartElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextFriedmanCurveChartElement xTextFriedmanCurveChartElement = null;
				if (e.Parameter is XTextFriedmanCurveChartElement)
				{
					xTextFriedmanCurveChartElement = (XTextFriedmanCurveChartElement)e.Parameter;
				}
				if (xTextFriedmanCurveChartElement == null)
				{
					xTextFriedmanCurveChartElement = (XTextFriedmanCurveChartElement)e.Document.CreateElementByType(typeof(XTextFriedmanCurveChartElement));
					xTextFriedmanCurveChartElement.Width = 2000f;
					xTextFriedmanCurveChartElement.Height = 3000f;
					if (e.Parameter is FriedmanCurveDocument)
					{
						xTextFriedmanCurveChartElement.Document = (FriedmanCurveDocument)e.Parameter;
					}
				}
				e.Document.AllocElementID("tmp", xTextFriedmanCurveChartElement);
				if (xTextFriedmanCurveChartElement != null)
				{
					WriterCommandModule.CheckImageSizeWhenInsertImage(e.Document, xTextFriedmanCurveChartElement, keepWidthHeightRate: false, null);
					xTextFriedmanCurveChartElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextFriedmanCurveChartElement);
					xTextFriedmanCurveChartElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextFriedmanCurveChartElement);
					e.Result = xTextFriedmanCurveChartElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入条形码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertTDBarcode", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertTDBarcode.bmp", ReturnValueType = typeof(XTextTDBarcodeElement))]
		protected void InsertTDBarcode(object sender, WriterCommandEventArgs e)
		{
			int num = 1;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextTDBarcodeElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				XTextTDBarcodeElement xTextTDBarcodeElement = null;
				if (e.Parameter is XTextTDBarcodeElement)
				{
					xTextTDBarcodeElement = (XTextTDBarcodeElement)e.Parameter;
				}
				if (xTextTDBarcodeElement == null)
				{
					xTextTDBarcodeElement = (XTextTDBarcodeElement)e.Document.CreateElementByType(typeof(XTextTDBarcodeElement));
				}
				e.Document.AllocElementID("tdbarcode", xTextTDBarcodeElement);
				if ((!e.ShowUI || WriterAppHost.smethod_4(e, xTextTDBarcodeElement, ElementPropertiesEditMethod.Insert)) && xTextTDBarcodeElement != null)
				{
					xTextTDBarcodeElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextTDBarcodeElement);
					e.DocumentControler.InsertElement(xTextTDBarcodeElement);
					e.Result = xTextTDBarcodeElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入条形码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertBarcode", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertBarcode.bmp", ReturnValueType = typeof(XTextBarcodeFieldElement))]
		[Obsolete("请使用InsertNewBarcode命令")]
		protected void InsertBarcode(object sender, WriterCommandEventArgs e)
		{
			int num = 2;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextBarcodeFieldElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				XTextBarcodeFieldElement xTextBarcodeFieldElement = null;
				if (e.Parameter is XTextBarcodeFieldElement)
				{
					xTextBarcodeFieldElement = (XTextBarcodeFieldElement)e.Parameter;
				}
				if (xTextBarcodeFieldElement == null)
				{
					xTextBarcodeFieldElement = (XTextBarcodeFieldElement)e.Document.CreateElementByType(typeof(XTextBarcodeFieldElement));
				}
				e.Document.AllocElementID("barcode", xTextBarcodeFieldElement);
				if ((!e.ShowUI || WriterAppHost.smethod_4(e, xTextBarcodeFieldElement, ElementPropertiesEditMethod.Insert)) && xTextBarcodeFieldElement != null)
				{
					xTextBarcodeFieldElement.OwnerDocument = e.Document;
					e.DocumentControler.InsertElement(xTextBarcodeFieldElement);
					e.Result = xTextBarcodeFieldElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入条形码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertNewBarcode", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertBarcode.bmp", ReturnValueType = typeof(XTextBarcodeFieldElement))]
		protected void InsertNewBarcode(object sender, WriterCommandEventArgs e)
		{
			int num = 15;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextNewBarcodeElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextNewBarcodeElement xTextNewBarcodeElement = null;
				if (e.Parameter is XTextNewBarcodeElement)
				{
					xTextNewBarcodeElement = (XTextNewBarcodeElement)e.Parameter;
				}
				if (xTextNewBarcodeElement == null)
				{
					xTextNewBarcodeElement = (XTextNewBarcodeElement)e.Document.CreateElementByType(typeof(XTextNewBarcodeElement));
				}
				e.Document.AllocElementID("barcode", xTextNewBarcodeElement);
				if ((!e.ShowUI || WriterAppHost.smethod_4(e, xTextNewBarcodeElement, ElementPropertiesEditMethod.Insert)) && xTextNewBarcodeElement != null)
				{
					if (xTextNewBarcodeElement.Width <= 0f)
					{
						xTextNewBarcodeElement.Width = 400f;
					}
					if (xTextNewBarcodeElement.Height <= 0f)
					{
						xTextNewBarcodeElement.Height = 150f;
					}
					xTextNewBarcodeElement.OwnerDocument = e.Document;
					xTextNewBarcodeElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextNewBarcodeElement);
					e.Result = xTextNewBarcodeElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入水平线元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertFileBlock", ImageResource = "DCSoft.Writer.Dom.XTextFileBlockElement.bmp", ReturnValueType = typeof(XTextFileBlockElement))]
		protected void InsertFileBlock(object sender, WriterCommandEventArgs e)
		{
			int num = 19;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextFileBlockElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextFileBlockElement xTextFileBlockElement = null;
				if (e.Parameter is XTextFileBlockElement)
				{
					xTextFileBlockElement = (XTextFileBlockElement)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					xTextFileBlockElement = (XTextFileBlockElement)e.Document.CreateElementByType(typeof(XTextFileBlockElement));
					xTextFileBlockElement.ContentSource = new FileContentSource();
					xTextFileBlockElement.ContentSource.FileName = (string)e.Parameter;
					xTextFileBlockElement.Text = Path.GetFileNameWithoutExtension(xTextFileBlockElement.ContentSource.FileName);
				}
				else if (e.Parameter is FileContentSource)
				{
					xTextFileBlockElement = (XTextFileBlockElement)e.Document.CreateElementByType(typeof(XTextFileBlockElement));
					xTextFileBlockElement.ContentSource = (FileContentSource)e.Parameter;
					xTextFileBlockElement.Text = Path.GetFileNameWithoutExtension(xTextFileBlockElement.ContentSource.FileName);
				}
				e.Document.AllocElementID("file", xTextFileBlockElement);
				if (e.ShowUI)
				{
					if (xTextFileBlockElement == null)
					{
						xTextFileBlockElement = (XTextFileBlockElement)e.Document.CreateElementByType(typeof(XTextFileBlockElement));
						e.Document.AllocElementID("file", xTextFileBlockElement);
					}
					e.Document.AllocElementID("file", xTextFileBlockElement);
					if (!WriterAppHost.smethod_4(e, xTextFileBlockElement, ElementPropertiesEditMethod.Insert))
					{
						xTextFileBlockElement.Dispose();
						xTextFileBlockElement = null;
					}
				}
				else if (xTextFileBlockElement == null)
				{
					xTextFileBlockElement = new XTextFileBlockElement();
				}
				if (xTextFileBlockElement != null)
				{
					xTextFileBlockElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextFileBlockElement);
					xTextFileBlockElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextFileBlockElement);
					e.Result = xTextFileBlockElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入水平线元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertHorizontalLine", ImageResource = "DCSoft.Writer.Dom.XTextHorizontalLineElement.bmp", ReturnValueType = typeof(XTextHorizontalLineElement))]
		protected void InsertHorizontalLine(object sender, WriterCommandEventArgs e)
		{
			int num = 11;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextHorizontalLineElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				XTextHorizontalLineElement xTextHorizontalLineElement = null;
				if (e.Parameter is XTextHorizontalLineElement)
				{
					xTextHorizontalLineElement = (XTextHorizontalLineElement)e.Parameter;
				}
				if (xTextHorizontalLineElement == null)
				{
					xTextHorizontalLineElement = (XTextHorizontalLineElement)e.Document.CreateElementByType(typeof(XTextHorizontalLineElement));
				}
				e.Document.AllocElementID("hl", xTextHorizontalLineElement);
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextHorizontalLineElement, ElementPropertiesEditMethod.Insert))
				{
					xTextHorizontalLineElement.Dispose();
					xTextHorizontalLineElement = null;
				}
				if (xTextHorizontalLineElement != null)
				{
					xTextHorizontalLineElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextHorizontalLineElement);
					xTextHorizontalLineElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextHorizontalLineElement);
					e.Result = xTextHorizontalLineElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入一个文本标签对象
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertLabel", ReturnValueType = typeof(XTextLabelElement))]
		protected void InsertLabel(object sender, WriterCommandEventArgs e)
		{
			int num = 3;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextLabelElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextLabelElement xTextLabelElement = null;
				if (e.Parameter is XTextLabelElement)
				{
					xTextLabelElement = (XTextLabelElement)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					xTextLabelElement = (XTextLabelElement)e.Document.CreateElementByType(typeof(XTextLabelElement));
					xTextLabelElement.Text = (string)e.Parameter;
				}
				if (xTextLabelElement == null)
				{
					xTextLabelElement = (XTextLabelElement)e.Document.CreateElementByType(typeof(XTextLabelElement));
				}
				if (string.IsNullOrEmpty(xTextLabelElement.Text))
				{
					xTextLabelElement.Text = WriterStrings.LabelNewText;
				}
				e.Document.AllocElementID("label", xTextLabelElement);
				if ((!e.ShowUI || WriterAppHost.smethod_4(e, xTextLabelElement, ElementPropertiesEditMethod.Insert)) && xTextLabelElement != null)
				{
					xTextLabelElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextLabelElement);
					xTextLabelElement.vmethod_0(bool_5: true);
					if (e.DocumentControler.InsertElement(xTextLabelElement))
					{
						e.Result = xTextLabelElement;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       插入一个按钮对象
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertButton", ReturnValueType = typeof(XTextButtonElement))]
		protected void InsertButton(object sender, WriterCommandEventArgs e)
		{
			int num = 14;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextButtonElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextButtonElement xTextButtonElement = null;
				if (e.Parameter is XTextButtonElement)
				{
					xTextButtonElement = (XTextButtonElement)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					xTextButtonElement = (XTextButtonElement)e.Document.CreateElementByType(typeof(XTextButtonElement));
					xTextButtonElement.Text = (string)e.Parameter;
				}
				if (xTextButtonElement != null && string.IsNullOrEmpty(xTextButtonElement.Text))
				{
					xTextButtonElement.Text = WriterStrings.ButtonNewText;
				}
				e.Document.AllocElementID("button", xTextButtonElement);
				if (e.ShowUI)
				{
					if (xTextButtonElement == null)
					{
						xTextButtonElement = (XTextButtonElement)e.Document.CreateElementByType(typeof(XTextButtonElement));
					}
					if (!WriterAppHost.smethod_4(e, xTextButtonElement, ElementPropertiesEditMethod.Insert))
					{
						return;
					}
				}
				if (xTextButtonElement != null)
				{
					xTextButtonElement.OwnerDocument = e.Document;
					if (xTextButtonElement.Width == 199f && !string.IsNullOrEmpty(xTextButtonElement.Text))
					{
						using (DCGraphics dcgraphics_ = e.Document.CreateDCGraphics())
						{
							SizeF sizeF = xTextButtonElement.method_16(dcgraphics_);
							xTextButtonElement.Width = Math.Max(sizeF.Width, xTextButtonElement.Width);
							xTextButtonElement.Height = Math.Max(sizeF.Height, xTextButtonElement.Height);
						}
					}
					e.Document.ValidateElementIDRepeat(xTextButtonElement);
					if (e.DocumentControler.InsertElement(xTextButtonElement))
					{
						e.Result = xTextButtonElement;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		[WriterCommandDescription("InsertImageWithScreenSnapshot", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertImageWithScreenSnapshot.bmp", ReturnValueType = typeof(XTextImageElement), FunctionID = GEnum6.const_76)]
		protected void InsertImageWithScreenSnapshot(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				InsertImage(sender, e);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent() || !e.ShowUI)
				{
					return;
				}
				Image image = null;
				if (e.EditorControl != null)
				{
					Form form = e.EditorControl.FindForm();
					while (form != null)
					{
						if (form.Owner != null)
						{
							form = form.Owner;
							continue;
						}
						if (form.MdiParent != null)
						{
							form = form.MdiParent;
							continue;
						}
						if (form.FindForm() == null)
						{
							break;
						}
						Form form2 = form.FindForm();
						if (form2 == form)
						{
							break;
						}
						form = form.FindForm();
					}
					FormWindowState windowState = FormWindowState.Maximized;
					if (form != null)
					{
						windowState = form.WindowState;
						form.WindowState = FormWindowState.Minimized;
					}
					Application.DoEvents();
					Thread.Sleep(200);
					using (frmScreenSnapshot2 frmScreenSnapshot = new frmScreenSnapshot2())
					{
						if (WriterControl.UIShowDialog(e.EditorControl, frmScreenSnapshot, null) == DialogResult.OK)
						{
							image = frmScreenSnapshot.BmpConent;
						}
					}
					if (form != null)
					{
						form.WindowState = windowState;
					}
				}
				if (image != null)
				{
					e.Parameter = image;
					e.ShowUI = false;
					InsertImage(sender, e);
				}
			}
		}

		/// <summary>
		///       延时的截屏插入图片
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertImageWithScreenSnapshotDelay", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertImageWithScreenSnapshot.bmp", ReturnValueType = typeof(XTextImageElement), FunctionID = GEnum6.const_76)]
		protected void InsertImageWithScreenSnapshotDelay(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				InsertImage(sender, e);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent() || !e.ShowUI || e.EditorControl == null)
				{
					return;
				}
				Form form = e.EditorControl.FindForm();
				while (form != null)
				{
					if (form.Owner != null)
					{
						form = form.Owner;
						continue;
					}
					if (form.MdiParent != null)
					{
						form = form.MdiParent;
						continue;
					}
					if (form.FindForm() == null)
					{
						break;
					}
					Form form2 = form.FindForm();
					if (form2 == form)
					{
						break;
					}
					form = form.FindForm();
				}
				dlgPrepareScreenSnapshot dlgPrepareScreenSnapshot = e.EditorControl.DlgSnapshotDelay;
				if (dlgPrepareScreenSnapshot == null)
				{
					dlgPrepareScreenSnapshot = new dlgPrepareScreenSnapshot();
				}
				dlgPrepareScreenSnapshot.Tag = e;
				dlgPrepareScreenSnapshot.AfterGetSnashotImage = InsertImageWithScreenSnapshot_AfterGetBmp;
				dlgPrepareScreenSnapshot.Owner = form;
				e.EditorControl.DlgSnapshotDelay = dlgPrepareScreenSnapshot;
				dlgPrepareScreenSnapshot.Show(e.EditorControl);
			}
		}

		/// <summary>
		///       配合InsertImageWithScreenSnapshotDelay使用的插入图片的函数
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		private void InsertImageWithScreenSnapshot_AfterGetBmp(object sender, EventArgs e)
		{
			dlgPrepareScreenSnapshot dlgPrepareScreenSnapshot = (dlgPrepareScreenSnapshot)sender;
			WriterCommandEventArgs writerCommandEventArgs = (WriterCommandEventArgs)dlgPrepareScreenSnapshot.Tag;
			Bitmap bmpContent = dlgPrepareScreenSnapshot.BmpContent;
			if (bmpContent != null)
			{
				writerCommandEventArgs.Parameter = bmpContent;
				writerCommandEventArgs.ShowUI = false;
				writerCommandEventArgs.Mode = WriterCommandEventMode.Invoke;
				InsertImage(null, writerCommandEventArgs);
			}
		}

		/// <summary>
		///       插入自定义图形
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertCustomShape", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertCustomShape.bmp", ReturnValueType = typeof(XTextCustomShapeElement), FunctionID = GEnum6.const_75)]
		protected void InsertCustomShape(object sender, WriterCommandEventArgs e)
		{
			int num = 15;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextCustomShapeElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextCustomShapeElement xTextCustomShapeElement = null;
				if (e.Parameter is XTextCustomShapeElement)
				{
					xTextCustomShapeElement = (XTextCustomShapeElement)e.Parameter;
				}
				e.Document.AllocElementID("shape", xTextCustomShapeElement);
				if (e.ShowUI && xTextCustomShapeElement == null)
				{
					xTextCustomShapeElement = (XTextCustomShapeElement)e.Document.CreateElementByType(typeof(XTextCustomShapeElement));
					xTextCustomShapeElement.Width = 200f;
					xTextCustomShapeElement.Height = 200f;
					if (e.Parameter is string)
					{
						xTextCustomShapeElement.ID = (string)e.Parameter;
					}
				}
				if (xTextCustomShapeElement != null)
				{
					xTextCustomShapeElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextCustomShapeElement);
					xTextCustomShapeElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextCustomShapeElement);
					e.Result = xTextCustomShapeElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入图片
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertImage", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertImage.bmp", ReturnValueType = typeof(XTextImageElement), FunctionID = GEnum6.const_68)]
		protected void InsertImage(object sender, WriterCommandEventArgs e)
		{
			int num = 16;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextImageElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextImageElement xTextImageElement = null;
				if (e.Parameter is XTextImageElement)
				{
					xTextImageElement = (XTextImageElement)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					string text = (string)e.Parameter;
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
						xTextImageElement.LoadImage(text, setSize: false);
						xTextImageElement.CompressSaveMode = ConfirmCompressSaveModeForFileSize(text, e);
					}
				}
				else if (e.Parameter is Image)
				{
					xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
					xTextImageElement.Image.Value = (Image)e.Parameter;
				}
				else if (e.Parameter is XImageValue)
				{
					xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
					xTextImageElement.Image = (XImageValue)e.Parameter;
				}
				else if (e.Parameter is byte[])
				{
					xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
					XImageValue xImageValue = new XImageValue();
					xImageValue.ImageData = (byte[])e.Parameter;
					xTextImageElement.Image = xImageValue;
				}
				e.Document.AllocElementID("image", xTextImageElement);
				if (e.ShowUI)
				{
					if (xTextImageElement == null)
					{
						xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
					}
					using (OpenFileDialog openFileDialog = new OpenFileDialog())
					{
						openFileDialog.Filter = WriterStrings.ImageFileFilter;
						openFileDialog.CheckFileExists = true;
						openFileDialog.ShowReadOnly = false;
						if (openFileDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						XImageValue xImageValue = xTextImageElement.Image = new XImageValue(openFileDialog.FileName);
						xTextImageElement.CompressSaveMode = ConfirmCompressSaveModeForFileSize(openFileDialog.FileName, e);
						e.Document.AllocElementID("image", xTextImageElement);
					}
				}
				if (xTextImageElement != null)
				{
					xTextImageElement.OwnerDocument = e.Document;
					xTextImageElement.UpdateSize(keepSizePossible: false);
					WriterCommandModule.CheckImageSizeWhenInsertImage(e.Document, xTextImageElement, xTextImageElement.RuntimeKeepWidthHeightRate, null);
					e.Document.ValidateElementIDRepeat(xTextImageElement);
					xTextImageElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextImageElement);
					e.Result = xTextImageElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       提示用户是否压缩存储大图片的数据
		///       </summary>
		/// <param name="fileName">图片本地文件名</param>
		/// <param name="args">参数</param>
		/// <returns>是否压缩存储</returns>
		private bool ConfirmCompressSaveModeForFileSize(string fileName, WriterCommandEventArgs args)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				return false;
			}
			if (!File.Exists(fileName))
			{
				return false;
			}
			if (args.Document.Options.BehaviorOptions.ImageCompressSaveMode == DCImageCompressSaveMode.True)
			{
				return true;
			}
			if (args.Document.Options.BehaviorOptions.ImageCompressSaveMode == DCImageCompressSaveMode.False)
			{
				return false;
			}
			if (args.Document.Options.BehaviorOptions.ImageCompressSaveMode == DCImageCompressSaveMode.Prompt)
			{
				int minImageFileSizeForConfirmCompressSaveMode = args.Document.Options.BehaviorOptions.MinImageFileSizeForConfirmCompressSaveMode;
				if (minImageFileSizeForConfirmCompressSaveMode <= 0)
				{
					return false;
				}
				FileInfo fileInfo = new FileInfo(fileName);
				int num = (int)fileInfo.Length;
				if (num < minImageFileSizeForConfirmCompressSaveMode)
				{
					return false;
				}
				if (args.ShowUI)
				{
					string string_ = string.Format(WriterStrings.ConfirmCompressSaveModeForImageSize_Size_MinSize, FileHelper.FormatByteSize(num), FileHelper.FormatByteSize(minImageFileSizeForConfirmCompressSaveMode));
					if (args.Host.UITools.Confirm(args.EditorControl, string_))
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		/// <summary>
		///       直接插入图片
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertImageExt", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertImage.bmp", ReturnValueType = typeof(XTextImageElement), FunctionID = GEnum6.const_68)]
		protected void InsertImageExt(object sender, WriterCommandEventArgs e)
		{
			int num = 18;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextImageElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextImageElement xTextImageElement = null;
				if (e.Parameter is XTextImageElement)
				{
					xTextImageElement = (XTextImageElement)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					string text = (string)e.Parameter;
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
						xTextImageElement.LoadImage(text, setSize: false);
					}
				}
				else if (e.Parameter is Image)
				{
					xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
					xTextImageElement.Image.Value = (Image)e.Parameter;
				}
				else if (e.Parameter is XImageValue)
				{
					xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
					xTextImageElement.Image = (XImageValue)e.Parameter;
				}
				else if (e.Parameter is byte[])
				{
					xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
					XImageValue xImageValue = new XImageValue();
					xImageValue.ImageData = (byte[])e.Parameter;
					xTextImageElement.Image = xImageValue;
				}
				if (xTextImageElement != null && string.IsNullOrEmpty(xTextImageElement.ID))
				{
					e.Document.AllocElementID("image", xTextImageElement);
				}
				if (e.ShowUI)
				{
					if (xTextImageElement == null)
					{
						xTextImageElement = (XTextImageElement)e.Document.CreateElementByType(typeof(XTextImageElement));
						e.Document.AllocElementID("image", xTextImageElement);
					}
					xTextImageElement.OwnerDocument = e.Document;
					if (!WriterAppHost.smethod_4(e, xTextImageElement, ElementPropertiesEditMethod.Insert))
					{
						xTextImageElement.Dispose();
						xTextImageElement = null;
					}
				}
				if (xTextImageElement != null)
				{
					xTextImageElement.OwnerDocument = e.Document;
					xTextImageElement.UpdateSize(keepSizePossible: false);
					WriterCommandModule.CheckImageSizeWhenInsertImage(e.Document, xTextImageElement, xTextImageElement.RuntimeKeepWidthHeightRate, null);
					xTextImageElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextImageElement);
					e.Result = xTextImageElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       插入复选框元素的动作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertCheckBox", ImageResource = "DCSoft.Writer.Dom.XTextCheckBoxElement.bmp", ReturnValueType = typeof(XTextCheckBoxElement))]
		protected void InsertCheckBox(object sender, WriterCommandEventArgs e)
		{
			int num = 9;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextCheckBoxElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextCheckBoxElement xTextCheckBoxElement = null;
				if (e.Parameter is XTextCheckBoxElement)
				{
					xTextCheckBoxElement = (XTextCheckBoxElement)e.Parameter;
				}
				if (xTextCheckBoxElement == null)
				{
					xTextCheckBoxElement = (XTextCheckBoxElement)e.Document.CreateElementByType(typeof(XTextCheckBoxElement));
					xTextCheckBoxElement.VisualStyle = CheckBoxVisualStyle.SystemDefault;
				}
				if (xTextCheckBoxElement != null && string.IsNullOrEmpty(xTextCheckBoxElement.ID))
				{
					e.Document.AllocElementID("checkbox", xTextCheckBoxElement);
				}
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextCheckBoxElement, ElementPropertiesEditMethod.Insert))
				{
					xTextCheckBoxElement.Dispose();
					xTextCheckBoxElement = null;
				}
				else if (xTextCheckBoxElement != null && e.UIStartEditContent())
				{
					xTextCheckBoxElement.vmethod_0(bool_5: true);
					xTextCheckBoxElement.OwnerDocument = e.Document;
					_ = e.Document.CurrentElement;
					e.Document.ValidateElementIDRepeat(xTextCheckBoxElement);
					WriterUtils.smethod_20(e.Document, new XTextElementList(xTextCheckBoxElement), bool_2: true);
					WriterCommandModule.CheckImageSizeWhenInsertImage(e.Document, xTextCheckBoxElement, keepWidthHeightRate: false, null);
					e.Document.DocumentControler.InsertElement(xTextCheckBoxElement);
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = xTextCheckBoxElement;
				}
			}
		}

		/// <summary>
		///       插入复选框元素的动作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertCheckBoxes", ImageResource = "DCSoft.Writer.Dom.XTextCheckBoxElement.bmp", ReturnValueType = typeof(XTextElementList))]
		protected void InsertCheckBoxes(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextCheckBoxElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI && e.UIStartEditContent())
			{
				using (dlgInsertCheckBoxes dlgInsertCheckBoxes = new dlgInsertCheckBoxes())
				{
					dlgInsertCheckBoxes.OwnerDocument = e.Document;
					if (WriterControl.UIShowDialog(e.EditorControl, dlgInsertCheckBoxes, null) == DialogResult.OK)
					{
						XTextElementList resultElements = dlgInsertCheckBoxes.ResultElements;
						if (resultElements != null && resultElements.Count > 0)
						{
							foreach (XTextElement item in resultElements)
							{
								e.Document.ValidateElementIDRepeat(item);
							}
							resultElements.method_0(bool_1: true);
							e.DocumentControler.InsertElements(resultElements);
							e.RefreshLevel = UIStateRefreshLevel.All;
							e.Result = resultElements;
						}
					}
				}
			}
		}

		/// <summary>
		///       插入复选框元素的动作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertRadioBox", ReturnValueType = typeof(XTextRadioBoxElement))]
		protected void InsertRadioBox(object sender, WriterCommandEventArgs e)
		{
			int num = 1;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextRadioBoxElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextRadioBoxElement xTextRadioBoxElement = null;
				if (e.Parameter is XTextRadioBoxElement)
				{
					xTextRadioBoxElement = (XTextRadioBoxElement)e.Parameter;
				}
				if (xTextRadioBoxElement == null)
				{
					xTextRadioBoxElement = (XTextRadioBoxElement)e.Document.CreateElementByType(typeof(XTextRadioBoxElement));
					xTextRadioBoxElement.VisualStyle = CheckBoxVisualStyle.SystemDefault;
				}
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextRadioBoxElement, ElementPropertiesEditMethod.Insert))
				{
					xTextRadioBoxElement.Dispose();
					xTextRadioBoxElement = null;
				}
				else if (xTextRadioBoxElement != null)
				{
					if (string.IsNullOrEmpty(xTextRadioBoxElement.ID))
					{
						e.Document.AllocElementID("radio", xTextRadioBoxElement);
					}
					if (e.UIStartEditContent())
					{
						_ = e.Document.CurrentElement;
						e.Document.ValidateElementIDRepeat(xTextRadioBoxElement);
						xTextRadioBoxElement.vmethod_0(bool_5: true);
						e.Document.DocumentControler.InsertElement(xTextRadioBoxElement);
						e.RefreshLevel = UIStateRefreshLevel.All;
						e.Result = xTextRadioBoxElement;
					}
				}
			}
		}

		/// <summary>
		///       插入复选框列表
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertCheckBoxList", ReturnValueType = typeof(XTextElementList))]
		protected void InsertCheckBoxList(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextInputFieldElementBase)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextInputFieldElement xTextInputFieldElement = null;
				if (e.Parameter is XTextInputFieldElement)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Parameter;
				}
				else
				{
					XTextInputFieldElementProperties xTextInputFieldElementProperties = null;
					xTextInputFieldElementProperties = (e.Parameter as XTextInputFieldElementProperties);
					if (e.Parameter is XTextInputFieldElementProperties)
					{
						xTextInputFieldElementProperties = (XTextInputFieldElementProperties)e.Parameter;
					}
					if (xTextInputFieldElementProperties == null)
					{
						xTextInputFieldElementProperties = new XTextInputFieldElementProperties();
					}
					xTextInputFieldElementProperties.method_1(e.Document);
					if (e.Parameter is InputFieldSettings)
					{
						xTextInputFieldElementProperties.FieldSettings = (InputFieldSettings)e.Parameter;
					}
					else if (e.Parameter is XDataBinding)
					{
						xTextInputFieldElementProperties.ValueBinding = (XDataBinding)e.Parameter;
					}
					else if (e.Parameter is ValueValidateStyle)
					{
						xTextInputFieldElementProperties.ValidateStyle = (ValueValidateStyle)e.Parameter;
					}
					if (e.ShowUI && !xTextInputFieldElementProperties.PromptNewElement(e))
					{
						return;
					}
					xTextInputFieldElement = (XTextInputFieldElement)xTextInputFieldElementProperties.CreateElement(e.Document);
				}
				IListSourceProvider ilistSourceProvider_ = (IListSourceProvider)e.Host.Services.GetService(typeof(IListSourceProvider));
				XTextElementList xTextElementList = new XTextElementList();
				ListItemCollection listItemCollection = ListSourceInfo.smethod_0(e.EditorControl, xTextInputFieldElement, e.Host, xTextInputFieldElement.FieldSettings.ListSource, ilistSourceProvider_, null, null, bool_0: true, null);
				if (listItemCollection != null)
				{
					foreach (ListItem item in listItemCollection)
					{
						XTextCheckBoxElement xTextCheckBoxElement = new XTextCheckBoxElement();
						if (xTextInputFieldElement.FieldSettings.MultiSelect)
						{
							xTextCheckBoxElement.ControlStyle = CheckBoxControlStyle.CheckBox;
						}
						else
						{
							xTextCheckBoxElement.ControlStyle = CheckBoxControlStyle.RadioBox;
						}
						xTextCheckBoxElement.GroupName = xTextInputFieldElement.Name;
						xTextCheckBoxElement.CheckedValue = item.Value;
						xTextCheckBoxElement.StringTag = item.Tag;
						xTextCheckBoxElement.ID = xTextInputFieldElement.ID;
						if (xTextInputFieldElement.Attributes != null)
						{
							xTextCheckBoxElement.Attributes = xTextInputFieldElement.Attributes.Clone();
						}
						xTextElementList.Add(xTextCheckBoxElement);
						if (!string.IsNullOrEmpty(item.Text))
						{
							string text = item.Text;
							foreach (char charValue in text)
							{
								XTextCharElement xTextCharElement = new XTextCharElement();
								xTextCharElement.CharValue = charValue;
								xTextElementList.Add(xTextCharElement);
							}
						}
					}
				}
				if (xTextElementList.Count > 0)
				{
					int styleIndex = e.Document.ContentStyles.GetStyleIndex(e.Document.CurrentStyleInfo.Content);
					foreach (XTextElement item2 in xTextElementList)
					{
						item2.StyleIndex = styleIndex;
						item2.OwnerDocument = e.Document;
					}
					xTextElementList.method_0(bool_1: true);
					e.DocumentControler.InsertElements(xTextElementList);
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = xTextElementList;
				}
			}
		}

		/// <summary>
		///       插入页码信息元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertPageInfo", ReturnValueType = typeof(XTextPageInfoElement))]
		protected void InsertPageInfo(object sender, WriterCommandEventArgs e)
		{
			int num = 17;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextPageInfoElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				PageInfoValueType pageInfoValueType = PageInfoValueType.PageIndex;
				ParagraphListStyle displayFormat = ParagraphListStyle.ListNumberStyle;
				string text = null;
				bool flag = true;
				string text2 = null;
				XTextPageInfoElement xTextPageInfoElement = null;
				if (e.Parameter is XTextPageInfoElement)
				{
					xTextPageInfoElement = (XTextPageInfoElement)e.Parameter;
					pageInfoValueType = xTextPageInfoElement.ValueType;
					text = xTextPageInfoElement.FormatString;
					displayFormat = xTextPageInfoElement.DisplayFormat;
					flag = xTextPageInfoElement.AutoHeight;
					text2 = xTextPageInfoElement.SpecifyPageIndexTextList;
				}
				else if (e.Parameter is PageInfoValueType)
				{
					pageInfoValueType = (PageInfoValueType)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					try
					{
						pageInfoValueType = (xTextPageInfoElement.ValueType = (PageInfoValueType)Enum.Parse(typeof(PageInfoValueType), (string)e.Parameter, ignoreCase: true));
					}
					catch
					{
					}
				}
				e.Document.AllocElementID("page", xTextPageInfoElement);
				if (e.ShowUI)
				{
					using (dlgPageInfoType dlgPageInfoType = new dlgPageInfoType())
					{
						if (e.EditorControl != null)
						{
							dlgPageInfoType.Text = e.EditorControl.DialogTitlePrefix + dlgPageInfoType.Text;
						}
						dlgPageInfoType.ContentType = pageInfoValueType;
						dlgPageInfoType.DisplayFormat = displayFormat;
						dlgPageInfoType.InputFormatString = text;
						dlgPageInfoType.SetAutoHeight = flag;
						dlgPageInfoType.SpecifyPageIndexTexts = text2;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgPageInfoType, xTextPageInfoElement) != DialogResult.OK)
						{
							return;
						}
						pageInfoValueType = dlgPageInfoType.ContentType;
						displayFormat = dlgPageInfoType.DisplayFormat;
						text = dlgPageInfoType.InputFormatString;
						flag = dlgPageInfoType.SetAutoHeight;
						text2 = dlgPageInfoType.SpecifyPageIndexTexts;
					}
				}
				if (xTextPageInfoElement == null)
				{
					xTextPageInfoElement = (XTextPageInfoElement)e.Document.CreateElementByType(typeof(XTextPageInfoElement));
					xTextPageInfoElement.AutoHeight = true;
				}
				xTextPageInfoElement.OwnerDocument = e.Document;
				xTextPageInfoElement.ValueType = pageInfoValueType;
				xTextPageInfoElement.DisplayFormat = displayFormat;
				xTextPageInfoElement.FormatString = text;
				xTextPageInfoElement.AutoHeight = flag;
				xTextPageInfoElement.SpecifyPageIndexTextList = text2;
				xTextPageInfoElement.Style = WriterCommandModuleFormat.GetCurrentStyle(e.Document);
				xTextPageInfoElement.vmethod_0(bool_5: true);
				e.DocumentControler.InsertElement(xTextPageInfoElement);
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Result = xTextPageInfoElement;
			}
		}

		/// <summary>
		///       插入媒体元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertMediaElement", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertMediaElement.bmp")]
		protected void InsertMediaElement(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextControlHostElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextMediaElement xTextMediaElement = e.Parameter as XTextMediaElement;
				if (xTextMediaElement == null)
				{
					xTextMediaElement = new XTextMediaElement();
					xTextMediaElement.FileName = (e.Parameter as string);
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)e.Document.CurrentElement.Style.Clone();
					documentContentStyle.PaddingLeft = XTextObjectElement.int_6;
					documentContentStyle.PaddingTop = XTextObjectElement.int_6;
					documentContentStyle.PaddingRight = XTextObjectElement.int_6;
					documentContentStyle.PaddingBottom = XTextObjectElement.int_6;
					documentContentStyle.BorderWidth = 1f;
					documentContentStyle.BorderLeft = true;
					documentContentStyle.BorderTop = true;
					documentContentStyle.BorderRight = true;
					documentContentStyle.BorderBottom = true;
					documentContentStyle.BorderStyle = DashStyle.Solid;
					xTextMediaElement.StyleIndex = e.Document.ContentStyles.GetStyleIndex(documentContentStyle);
					xTextMediaElement.Width = 1000f;
					XTextContentElement currentContentElement = e.Document.CurrentContentElement;
					if (currentContentElement != null)
					{
						xTextMediaElement.Width = currentContentElement.ClientWidth - 10f;
					}
					xTextMediaElement.Height = 1000f;
				}
				if (e.ShowUI)
				{
					using (OpenFileDialog openFileDialog = new OpenFileDialog())
					{
						openFileDialog.Filter = WriterStrings.MediaFileFilter;
						openFileDialog.CheckFileExists = true;
						if (!string.IsNullOrEmpty(xTextMediaElement.FileName))
						{
							openFileDialog.FileName = xTextMediaElement.FileName;
						}
						if (openFileDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						xTextMediaElement.FileName = openFileDialog.FileName;
					}
				}
				XTextElement currentElement = e.Document.CurrentElement;
				if (xTextMediaElement.StyleIndex < 0)
				{
					xTextMediaElement.StyleIndex = currentElement.StyleIndex;
				}
				xTextMediaElement.OwnerDocument = e.Document;
				if (xTextMediaElement.ClientWidth <= 0f)
				{
					xTextMediaElement.ClientWidth = 300f;
				}
				if (xTextMediaElement.ClientHeight <= 0f)
				{
					xTextMediaElement.ClientHeight = 300f;
				}
				WriterCommandModule.CheckImageSizeWhenInsertImage(e.Document, xTextMediaElement, keepWidthHeightRate: false, null);
				ControlHelper.GetControlType(xTextMediaElement.TypeFullName, null);
				xTextMediaElement.vmethod_0(bool_5: true);
				e.DocumentControler.InsertElement(xTextMediaElement);
				xTextMediaElement.vmethod_29();
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Result = xTextMediaElement;
			}
		}

		/// <summary>
		///       插入文本输入域
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertControlHost", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertControlHost.bmp", ReturnValueType = typeof(XTextControlHostElement))]
		protected void InsertControlHost(object sender, WriterCommandEventArgs e)
		{
			int num = 0;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextControlHostElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextControlHostElement xTextControlHostElement = null;
				if (e.Parameter is XTextControlHostElement)
				{
					xTextControlHostElement = (XTextControlHostElement)e.Parameter;
				}
				if (xTextControlHostElement == null)
				{
					xTextControlHostElement = (XTextControlHostElement)e.Document.CreateElementByType(typeof(XTextControlHostElement));
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)e.Document.CurrentElement.Style.Clone();
					documentContentStyle.PaddingLeft = XTextObjectElement.int_6;
					documentContentStyle.PaddingTop = XTextObjectElement.int_6;
					documentContentStyle.PaddingRight = XTextObjectElement.int_6;
					documentContentStyle.PaddingBottom = XTextObjectElement.int_6;
					documentContentStyle.BorderWidth = 1f;
					documentContentStyle.BorderLeft = true;
					documentContentStyle.BorderTop = true;
					documentContentStyle.BorderRight = true;
					documentContentStyle.BorderBottom = true;
					documentContentStyle.BorderStyle = DashStyle.Solid;
					xTextControlHostElement.StyleIndex = e.Document.ContentStyles.GetStyleIndex(documentContentStyle);
				}
				e.Document.AllocElementID("host", xTextControlHostElement);
				xTextControlHostElement.OwnerDocument = e.Document;
				if (e.Parameter is string || e.Parameter is Type)
				{
					Type type = null;
					if (e.Parameter is string)
					{
						string text = (string)e.Parameter;
						text = text.Trim();
						if (text.Length > 0)
						{
							type = ControlHelper.GetControlType(text, null);
						}
						if (type == null && XTextControlHostElement.smethod_0(text))
						{
							xTextControlHostElement.TypeFullName = text;
							xTextControlHostElement.ControlType = HostedControlType.AutoDetect;
						}
					}
					else if (e.Parameter is Type)
					{
						type = (Type)e.Parameter;
					}
					if (type != null)
					{
						xTextControlHostElement.TypeFullName = ControlHelper.GetControlFullTypeName(type);
						if (!e.ShowUI && type != null && !xTextControlHostElement.DelayLoadControl)
						{
							object obj = xTextControlHostElement.vmethod_32();
							try
							{
								if (obj != null)
								{
									SizeF sizeF = xTextControlHostElement.method_18(obj);
									RuntimeDocumentContentStyle runtimeStyle = xTextControlHostElement.RuntimeStyle;
									xTextControlHostElement.Width = sizeF.Width + runtimeStyle.PaddingLeft + runtimeStyle.PaddingRight;
									xTextControlHostElement.Height = sizeF.Height + runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom;
									PropertyDescriptor defaultProperty = TypeDescriptor.GetDefaultProperty(obj);
									if (!(defaultProperty?.IsReadOnly ?? true))
									{
										xTextControlHostElement.ValuePropertyName = defaultProperty.Name;
									}
								}
							}
							finally
							{
								if (obj is IDisposable)
								{
									((IDisposable)obj).Dispose();
								}
							}
						}
					}
				}
				Size size = Size.Empty;
				if (e.Parameter != null)
				{
					Type type2 = e.Parameter.GetType();
					if (typeof(Control).IsAssignableFrom(type2))
					{
						xTextControlHostElement.SpecifyHostedInstance = e.Parameter;
						xTextControlHostElement.TypeFullName = ControlHelper.GetControlFullTypeName(type2);
						size = ((Control)e.Parameter).Size;
					}
					else if (typeof(IDocumentImage).IsAssignableFrom(type2))
					{
						xTextControlHostElement.SpecifyHostedInstance = e.Parameter;
						xTextControlHostElement.TypeFullName = ControlHelper.GetControlFullTypeName(type2);
						IDocumentImage documentImage = (IDocumentImage)e.Parameter;
						using (DCGraphics dcgraphics_ = e.Document.CreateDCGraphics())
						{
							DocumentPaintEventArgs args = e.Document.method_55(dcgraphics_);
							SizeF preferredSize = documentImage.GetPreferredSize(args);
							if (!preferredSize.IsEmpty)
							{
								xTextControlHostElement.ClientWidth = preferredSize.Width;
								xTextControlHostElement.ClientHeight = preferredSize.Height;
							}
						}
					}
					else if (GClass129.smethod_4(e.Parameter))
					{
						xTextControlHostElement.SpecifyHostedInstance = e.Parameter;
						xTextControlHostElement.TypeFullName = ControlHelper.GetControlFullTypeName(type2);
						size = GClass129.smethod_8(xTextControlHostElement.SpecifyHostedInstance);
					}
				}
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextControlHostElement, ElementPropertiesEditMethod.Insert))
				{
					xTextControlHostElement.Dispose();
					xTextControlHostElement = null;
				}
				if (xTextControlHostElement != null)
				{
					XTextElement currentElement = e.Document.CurrentElement;
					if (xTextControlHostElement.StyleIndex < 0)
					{
						xTextControlHostElement.StyleIndex = currentElement.StyleIndex;
					}
					xTextControlHostElement.OwnerDocument = e.Document;
					if (!size.IsEmpty)
					{
						xTextControlHostElement.ClientWidth = e.Document.PixelToDocumentUnit(size.Width);
						xTextControlHostElement.ClientHeight = e.Document.PixelToDocumentUnit(size.Height);
					}
					if (xTextControlHostElement.ClientWidth <= 0f)
					{
						xTextControlHostElement.ClientWidth = 300f;
					}
					if (xTextControlHostElement.ClientHeight <= 0f)
					{
						xTextControlHostElement.ClientHeight = 300f;
					}
					WriterCommandModule.CheckImageSizeWhenInsertImage(e.Document, xTextControlHostElement, keepWidthHeightRate: false, null);
					Type type = ControlHelper.GetControlType(xTextControlHostElement.TypeFullName, null);
					e.Document.AllocElementID("media", xTextControlHostElement);
					xTextControlHostElement.vmethod_0(bool_5: true);
					e.DocumentControler.InsertElement(xTextControlHostElement);
					xTextControlHostElement.vmethod_29();
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = xTextControlHostElement;
				}
			}
		}

		/// <summary>
		///       插入目录域
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertDirectoryField")]
		protected void InsertDirectoryField(object sender, WriterCommandEventArgs e)
		{
			int num = 11;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextDirectoryFieldElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				XTextDirectoryFieldElement xTextDirectoryFieldElement = e.Parameter as XTextDirectoryFieldElement;
				if (xTextDirectoryFieldElement == null)
				{
					xTextDirectoryFieldElement = new XTextDirectoryFieldElement();
				}
				e.Document.AllocElementID("directory", xTextDirectoryFieldElement);
				xTextDirectoryFieldElement.OwnerDocument = e.Document;
				xTextDirectoryFieldElement.Parent = e.Document.Body;
				if (e.ShowUI)
				{
					using (dlgInsertDirectoryField dlgInsertDirectoryField = new dlgInsertDirectoryField())
					{
						dlgInsertDirectoryField.InputElement = xTextDirectoryFieldElement;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgInsertDirectoryField, xTextDirectoryFieldElement) == DialogResult.Cancel)
						{
							return;
						}
					}
				}
				xTextDirectoryFieldElement.method_35(bool_21: false);
				e.DocumentControler.InsertElement(xTextDirectoryFieldElement);
				xTextDirectoryFieldElement.method_36();
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Result = xTextDirectoryFieldElement;
			}
		}

		/// <summary>
		///       插入文本输入域
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertInputField", ImageResource = "DCSoft.Writer.Dom.XTextInputFieldElement.bmp", ReturnValueType = typeof(XTextInputFieldElement))]
		protected void InsertInputField(object sender, WriterCommandEventArgs e)
		{
			int num = 17;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextInputFieldElementBase)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextInputFieldElement xTextInputFieldElement = null;
				if (e.Parameter is string)
				{
					string text = (string)e.Parameter;
					if (text.IndexOf("<XInputField") >= 0)
					{
						xTextInputFieldElement = (e.Document.CreateElementByXMLFragment(text) as XTextInputFieldElement);
					}
				}
				else if (e.Parameter is XTextInputFieldElement)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Parameter;
				}
				else if (e.Parameter is InputFieldSettings)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Document.CreateElementByType(typeof(XTextInputFieldElement));
					xTextInputFieldElement.FieldSettings = (InputFieldSettings)e.Parameter;
				}
				else if (e.Parameter is XDataBinding)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Document.CreateElementByType(typeof(XTextInputFieldElement));
					xTextInputFieldElement.ValueBinding = (XDataBinding)e.Parameter;
				}
				else if (e.Parameter is ValueValidateStyle)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Document.CreateElementByType(typeof(XTextInputFieldElement));
					xTextInputFieldElement.ValidateStyle = (ValueValidateStyle)e.Parameter;
				}
				if (xTextInputFieldElement == null)
				{
					xTextInputFieldElement = (XTextInputFieldElement)e.Document.CreateElementByType(typeof(XTextInputFieldElement));
				}
				xTextInputFieldElement.OwnerDocument = e.Document;
				e.Document.AllocElementID("field", xTextInputFieldElement);
				if (e.ShowUI && !WriterAppHost.smethod_4(e, xTextInputFieldElement, ElementPropertiesEditMethod.Insert))
				{
					xTextInputFieldElement.Dispose();
					xTextInputFieldElement = null;
				}
				if (xTextInputFieldElement != null)
				{
					_ = e.Document.CurrentElement;
					if (xTextInputFieldElement.StyleIndex == -1)
					{
						xTextInputFieldElement.StyleIndex = e.Document.ContentStyles.GetStyleIndex(e.Document.CurrentStyleInfo.ContentStyleForNewString);
					}
					xTextInputFieldElement.StartElement.StyleIndex = xTextInputFieldElement.StyleIndex;
					xTextInputFieldElement.EndElement.StyleIndex = xTextInputFieldElement.StyleIndex;
					xTextInputFieldElement.OwnerDocument = e.Document;
					foreach (XTextElement element in xTextInputFieldElement.Elements)
					{
						element.StyleIndex = xTextInputFieldElement.StyleIndex;
					}
					if (xTextInputFieldElement.ValueBinding != null && xTextInputFieldElement.ValueBinding.AutoUpdate)
					{
						xTextInputFieldElement.UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: true));
					}
					e.Document.ValidateElementIDRepeat(xTextInputFieldElement);
					xTextInputFieldElement.vmethod_0(bool_17: true);
					e.DocumentControler.InsertElement(xTextInputFieldElement);
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = xTextInputFieldElement;
				}
			}
		}

		/// <summary>
		///       插入文档内容链接
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertContentLink", ReturnValueType = typeof(XTextContentLinkFieldElement))]
		protected void InsertContentLink(object sender, WriterCommandEventArgs e)
		{
			int num = 11;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (!e.UIStartEditContent())
				{
					return;
				}
				XTextContentLinkFieldElement xTextContentLinkFieldElement = null;
				if (e.Parameter is XTextContentLinkFieldElement)
				{
					xTextContentLinkFieldElement = (XTextContentLinkFieldElement)e.Parameter;
				}
				if (xTextContentLinkFieldElement == null)
				{
					XTextContentLinkFieldElement xTextContentLinkFieldElement2 = (XTextContentLinkFieldElement)e.Document.CreateElementByType(typeof(XTextContentLinkFieldElement));
					xTextContentLinkFieldElement2.ContentSource = new FileContentSource();
					xTextContentLinkFieldElement2.ContentSource.FileSystemName = "template";
					xTextContentLinkFieldElement = xTextContentLinkFieldElement2;
				}
				e.Document.AllocElementID("clink", xTextContentLinkFieldElement);
				if (e.ShowUI)
				{
					using (dlgContentLinkEditor dlgContentLinkEditor = new dlgContentLinkEditor())
					{
						ElementPropertiesEditEventArgs elementPropertiesEditEventArgs = new ElementPropertiesEditEventArgs();
						elementPropertiesEditEventArgs.Document = e.Document;
						elementPropertiesEditEventArgs.Host = e.Host;
						elementPropertiesEditEventArgs.Element = xTextContentLinkFieldElement;
						elementPropertiesEditEventArgs.LogUndo = false;
						elementPropertiesEditEventArgs.Method = ElementPropertiesEditMethod.Insert;
						dlgContentLinkEditor.SourceEventArgs = elementPropertiesEditEventArgs;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgContentLinkEditor, xTextContentLinkFieldElement) != DialogResult.OK)
						{
							return;
						}
						xTextContentLinkFieldElement = (XTextContentLinkFieldElement)elementPropertiesEditEventArgs.Element;
					}
				}
				if (xTextContentLinkFieldElement != null)
				{
					xTextContentLinkFieldElement.OwnerDocument = e.Document;
					xTextContentLinkFieldElement.vmethod_0(bool_17: true);
					if (e.DocumentControler.InsertElement(xTextContentLinkFieldElement))
					{
						e.Result = xTextContentLinkFieldElement;
					}
				}
			}
		}

		/// <summary>
		///       插入文件内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertFileContent", ReturnValueType = typeof(XTextElementList))]
		protected void InsertFileContent(object sender, WriterCommandEventArgs e)
		{
			int num = 12;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = null;
				if (!e.UIStartEditContent())
				{
					return;
				}
				XTextDocument xTextDocument = null;
				string fileName = null;
				if (e.Parameter is string)
				{
					fileName = (string)e.Parameter;
				}
				else if (e.Parameter is XTextDocument)
				{
					xTextDocument = (XTextDocument)e.Parameter;
				}
				else if (e.Parameter is Stream)
				{
					Stream stream = (Stream)e.Parameter;
					xTextDocument = (XTextDocument)e.Document.Clone(Deeply: false);
					xTextDocument.Load(stream, null);
				}
				else if (e.Parameter is TextReader)
				{
					TextReader reader = (TextReader)e.Parameter;
					xTextDocument = (XTextDocument)e.Document.Clone(Deeply: false);
					xTextDocument.Load(reader, null);
				}
				else if (e.Parameter is byte[])
				{
					MemoryStream stream2 = new MemoryStream((byte[])e.Parameter);
					xTextDocument = (XTextDocument)e.Document.Clone(Deeply: false);
					xTextDocument.Load(stream2, null);
				}
				if (xTextDocument == null)
				{
					if (e.ShowUI)
					{
						using (OpenFileDialog openFileDialog = new OpenFileDialog())
						{
							openFileDialog.Filter = WriterStrings.XMLFilter;
							openFileDialog.CheckFileExists = true;
							openFileDialog.FileName = fileName;
							if (openFileDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
							{
								return;
							}
							fileName = openFileDialog.FileName;
						}
					}
					WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(e.EditorControl, e.Document, null, fileName, "document");
					byte[] array = WriterControl.ReadFileContent(e.EditorControl, writerReadFileContentEventArgs);
					if (array != null && array.Length > 0)
					{
						MemoryStream stream2 = new MemoryStream(array);
						xTextDocument = new XTextDocument();
						xTextDocument.Options = e.Document.Options;
						e.Document.Parameters.CopytValuesTo(xTextDocument.Parameters);
						xTextDocument.ServerObject = e.Document.ServerObject;
						xTextDocument.Load(stream2, writerReadFileContentEventArgs.FileFormat, fastMode: false);
						if (e.Host.Debuger != null)
						{
							e.Host.Debuger.DebugLoadFileComplete((int)stream2.Length);
						}
					}
				}
				if (xTextDocument != null && xTextDocument.Body != null && xTextDocument.Body.Elements.Count > 0)
				{
					XTextElementList elements = xTextDocument.Body.Elements;
					e.Document.method_41(elements);
					if (elements.Count > 0)
					{
						e.Document.ImportElements(elements);
						elements.method_0(bool_1: true);
						e.DocumentControler.InsertElements(elements);
						e.Result = elements;
					}
				}
			}
		}

		/// <summary>
		///       向文档的当前位置插入Html内容。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertHtml", ReturnValueType = typeof(XTextElementList))]
		protected void InsertHtml(object sender, WriterCommandEventArgs e)
		{
			int num = 9;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (!e.UIStartEditContent())
				{
					return;
				}
				XTextDocument xTextDocument = null;
				if (e.Parameter is string)
				{
					xTextDocument = (XTextDocument)Activator.CreateInstance(e.Document.GetType());
					StringReader reader = new StringReader((string)e.Parameter);
					xTextDocument.Load(reader, "html", fastMode: true);
				}
				else if (e.Parameter is Stream)
				{
					xTextDocument = (XTextDocument)Activator.CreateInstance(e.Document.GetType());
					xTextDocument.Load((Stream)e.Parameter, "html", fastMode: true);
				}
				else if (e.Parameter is TextReader)
				{
					xTextDocument = (XTextDocument)Activator.CreateInstance(e.Document.GetType());
					xTextDocument.Load((TextReader)e.Parameter, "html", fastMode: true);
				}
				if (xTextDocument != null && xTextDocument.Body != null && xTextDocument.Body.Elements.Count > 0)
				{
					XTextElementList elements = xTextDocument.Body.Elements;
					e.Document.ImportElements(elements);
					e.Document.method_41(elements);
					if (elements.Count > 0)
					{
						elements.method_0(bool_1: true);
						e.DocumentControler.InsertElements(elements);
						e.Result = elements;
					}
				}
			}
		}

		/// <summary>
		///       向文档的当前位置插入XML内容。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertXML", ReturnValueType = typeof(XTextElementList))]
		protected void InsertXML(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerInsertXML(e, 0);
			}
		}

		/// <summary>
		///       向文档的当前位置插入XML内容。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertXMLWithClearFormat", ReturnValueType = typeof(XTextElementList))]
		protected void InsertXMLWithClearFormat(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerInsertXML(e, 1);
			}
		}

		/// <summary>
		///       向文档的当前位置插入XML内容。并只清理字体名称和大小
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertXMLWithClearFontNameSize", ReturnValueType = typeof(XTextElementList))]
		protected void InsertXMLWithClearFontNameSize(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerInsertXML(e, 2);
			}
		}

		private void InnerInsertXML(WriterCommandEventArgs args, int clearFormatType)
		{
			int num = 7;
			args.Result = false;
			if (!args.UIStartEditContent())
			{
				return;
			}
			XTextDocument xTextDocument = null;
			if (args.Parameter is string)
			{
				string text = (string)args.Parameter;
				text = text.Trim();
				if (!text.StartsWith("<"))
				{
					return;
				}
				StringReader stringReader = new StringReader((string)args.Parameter);
				xTextDocument = (XTextDocument)args.Document.CreateElementByType(args.Document.GetType());
				xTextDocument.Load(stringReader, "xml", fastMode: true);
				stringReader.Close();
			}
			else if (args.Parameter is Stream)
			{
				xTextDocument = (XTextDocument)args.Document.CreateElementByType(args.Document.GetType());
				xTextDocument.Load((Stream)args.Parameter, "xml", fastMode: true);
			}
			else if (args.Parameter is TextReader)
			{
				xTextDocument = (XTextDocument)args.Document.CreateElementByType(args.Document.GetType());
				xTextDocument.Load((TextReader)args.Parameter, "xml", fastMode: true);
			}
			args.Result = InsertDocument(args, xTextDocument, clearFormatType, checkImportDocument: true);
		}

		private XTextElementList InsertDocument(WriterCommandEventArgs args, XTextDocument sourceDocument, int clearFormatType, bool checkImportDocument)
		{
			if (sourceDocument == null)
			{
				return null;
			}
			if (sourceDocument.Body == null)
			{
				return null;
			}
			if (sourceDocument.Body.Elements.Count == 0)
			{
				return null;
			}
			if (sourceDocument.Body.Elements.Count == 1 && sourceDocument.Body.Elements[0] is XTextParagraphFlagElement)
			{
				return null;
			}
			if (checkImportDocument && !args.DocumentControler.vmethod_1(sourceDocument, args.ShowUI))
			{
				return null;
			}
			sourceDocument.FixDomState();
			XTextElementList xTextElementList = sourceDocument.Body.Elements.Clone();
			switch (clearFormatType)
			{
			case 1:
			{
				sourceDocument.ContentStyles.Styles.Clear();
				sourceDocument.ContentStyles.Default = args.Document.ContentStyles.Default;
				int num = -1;
				int num2 = -1;
				num = args.Document.ContentStyles.GetStyleIndex(args.Document.CurrentStyleInfo.Content);
				num2 = args.Document.ContentStyles.GetStyleIndex(args.Document.CurrentStyleInfo.Paragraph);
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(xTextElementList);
				domTreeNodeEnumerable.ExcludeParagraphFlag = false;
				domTreeNodeEnumerable.ExcludeCharElement = false;
				foreach (XTextElement item in domTreeNodeEnumerable)
				{
					if (item is XTextParagraphFlagElement)
					{
						item.StyleIndex = num2;
					}
					else
					{
						item.StyleIndex = num;
					}
				}
				break;
			}
			case 2:
				sourceDocument.ContentStyles.Default.FontName = args.Document.CurrentStyleInfo.Content.FontName;
				sourceDocument.ContentStyles.Default.FontSize = args.Document.CurrentStyleInfo.Content.FontSize;
				foreach (DocumentContentStyle style in sourceDocument.ContentStyles.Styles)
				{
					style.FontName = args.Document.CurrentStyleInfo.Content.FontName;
					style.FontSize = args.Document.CurrentStyleInfo.Content.FontSize;
				}
				break;
			}
			args.Document.ImportElements(xTextElementList);
			args.Document.method_41(xTextElementList);
			if (xTextElementList.Count > 0)
			{
				xTextElementList.method_0(bool_1: true);
				args.DocumentControler.InsertElements(xTextElementList);
			}
			return xTextElementList;
		}

		/// <summary>
		///       插入RTF文本
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertRTF")]
		protected void InsertRTF(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (!e.UIStartEditContent())
				{
					return;
				}
				InsertRTFCommandParameter insertRTFCommandParameter = null;
				if (e.Parameter is InsertRTFCommandParameter)
				{
					insertRTFCommandParameter = (InsertRTFCommandParameter)e.Parameter;
				}
				else
				{
					insertRTFCommandParameter = new InsertRTFCommandParameter();
					if (e.Parameter != null)
					{
						insertRTFCommandParameter.RTFText = Convert.ToString(e.Parameter);
					}
				}
				if (e.ShowUI)
				{
					using (dlgInputRTF dlgInputRTF = new dlgInputRTF())
					{
						if (e.EditorControl != null)
						{
							dlgInputRTF.Text = e.EditorControl.DialogTitlePrefix + dlgInputRTF.Text;
						}
						dlgInputRTF.InputRTFText = insertRTFCommandParameter.RTFText;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgInputRTF, null) != DialogResult.OK)
						{
							return;
						}
						insertRTFCommandParameter.RTFText = dlgInputRTF.InputRTFText;
					}
				}
				if (!string.IsNullOrEmpty(insertRTFCommandParameter.RTFText))
				{
					e.Result = e.DocumentControler.InsertRTF(insertRTFCommandParameter.RTFText);
				}
			}
		}

		/// <summary>
		///       从文件中加载辅助录入列表项目
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("LoadGlobalAssistStringItemFromFile")]
		public void LoadGlobalAssistStringItemFromFile(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = 0;
				string text = Convert.ToString(e.Parameter);
				if (e.ShowUI)
				{
					using (OpenFileDialog openFileDialog = new OpenFileDialog())
					{
						openFileDialog.FileName = text;
						openFileDialog.CheckFileExists = true;
						openFileDialog.ShowReadOnly = false;
						if (openFileDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						text = openFileDialog.FileName;
					}
				}
				if (!File.Exists(text))
				{
					e.Result = 0;
				}
				else if (e.EditorControl.InnerViewControl.AssistStringListForm != null)
				{
					e.Result = e.EditorControl.InnerViewControl.AssistStringListForm.imethod_1(text);
				}
			}
		}

		/// <summary>
		///       从字符串中加载辅助录入项目
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("LoadGlobalAssistStringItem")]
		public void LoadGlobalAssistStringItem(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = 0;
				string string_ = Convert.ToString(e.Parameter);
				if (e.EditorControl.InnerViewControl.AssistStringListForm != null)
				{
					e.Result = e.EditorControl.InnerViewControl.AssistStringListForm.imethod_3(string_);
				}
			}
		}

		/// <summary>
		///       辅助输入纯文本
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AssistInsertString", ShortcutKey = Keys.F3)]
		protected void AssistInsertString(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				InsertString(sender, e);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				e.EditorControl.InnerViewControl.method_165();
			}
		}

		[WriterCommandDescription("InsertWhiteSpaceForAlignRight")]
		protected void InsertWhiteSpaceForAlignRight(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextCharElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextElement xTextElement = e.Parameter as XTextElement;
				if (xTextElement == null)
				{
					xTextElement = e.Document.CurrentElement;
				}
				if (xTextElement == null)
				{
					return;
				}
				XTextContentElement contentElement = xTextElement.ContentElement;
				if (contentElement == null)
				{
					return;
				}
				XTextLine ownerLine = xTextElement.OwnerLine;
				if (ownerLine != null && e.UIStartEditContent())
				{
					_ = contentElement.ClientWidth;
					float num = contentElement.ClientWidth - ownerLine.ContentWidth;
					XTextCharElement xTextCharElement = new XTextCharElement();
					xTextCharElement.StyleIndex = -1;
					xTextCharElement.CharValue = ' ';
					xTextCharElement.OwnerDocument = e.Document;
					int num2 = 0;
					using (DCGraphics dcgraphics_ = e.Document.CreateDCGraphics())
					{
						DocumentPaintEventArgs documentPaintEventArgs = e.Document.method_55(dcgraphics_);
						documentPaintEventArgs.Element = xTextCharElement;
						xTextCharElement.RefreshSize(documentPaintEventArgs);
						num2 = (int)Math.Floor(num / xTextCharElement.Width);
					}
					if (num2 > 0)
					{
						XTextDocumentContentElement documentContentElement = xTextElement.DocumentContentElement;
						documentContentElement.SetSelection(xTextElement.ViewIndex, 0);
						e.Result = e.DocumentControler.InsertString(new string(' ', num2), logUndo: true, InputValueSource.UI, e.Document.DefaultStyle, null);
					}
				}
			}
		}

		/// <summary>
		///       插入纯文本
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertString", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertString.bmp")]
		protected void InsertString(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextCharElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = 0;
				if (!e.UIStartEditContent())
				{
					return;
				}
				InsertStringCommandParameter insertStringCommandParameter = null;
				if (e.Parameter is InsertStringCommandParameter)
				{
					insertStringCommandParameter = (InsertStringCommandParameter)e.Parameter;
				}
				else
				{
					insertStringCommandParameter = new InsertStringCommandParameter();
					if (e.Parameter != null)
					{
						insertStringCommandParameter.Text = Convert.ToString(e.Parameter);
					}
				}
				if (e.ShowUI)
				{
					using (dlgInputString dlgInputString = new dlgInputString())
					{
						if (e.EditorControl != null)
						{
							dlgInputString.Text = e.EditorControl.DialogTitlePrefix + dlgInputString.Text;
						}
						dlgInputString.InputText = insertStringCommandParameter.Text;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgInputString, null) != DialogResult.OK)
						{
							return;
						}
						insertStringCommandParameter.Text = dlgInputString.InputText;
					}
				}
				if (!string.IsNullOrEmpty(insertStringCommandParameter.Text))
				{
					e.Result = e.DocumentControler.InsertString(insertStringCommandParameter.Text, logUndo: true, InputValueSource.UI, insertStringCommandParameter.Style, insertStringCommandParameter.ParagraphStyle);
				}
			}
		}

		/// <summary>
		///       插入软回车
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertLineBreak", ShortcutKey = (Keys.LButton | Keys.MButton | Keys.Back | Keys.Shift))]
		protected void InsertLineBreak(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextLineBreakElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				e.Result = e.DocumentControler.InsertLineBreak();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       插入段落符号
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertParagrahFlag", ReturnValueType = typeof(bool))]
		protected void InsertParagrahFlag(object sender, WriterCommandEventArgs e)
		{
			int num = 5;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextParagraphFlagElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					XTextElementList xTextElementList = e.DocumentControler.InsertString("\r", logUndo: true, InputValueSource.UI, null, null);
					if (xTextElementList != null && xTextElementList.Count > 0)
					{
						e.Result = true;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       根据插入点前面的文字插入知识库
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BeginInsertKBEntryByPreWord", ShortcutKey = Keys.F4)]
		protected void BeginInsertKBEntryByPreWord(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					string text = e.Document.Content.method_26(e.Document.Content.CurrentElement, bool_4: true, bool_5: false);
					if (!string.IsNullOrEmpty(text))
					{
						e.EditorControl.BeginInsertKBSpecifyText(text);
					}
				}
			}
		}

		/// <summary>
		///       插入知识库节点
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertKBEntry", ImageResource = "DCSoft.Writer.Data.KBEntry.bmp")]
		protected void InsertKBEntry(object sender, WriterCommandEventArgs e)
		{
			int num = 6;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (!e.UIStartEditContent())
				{
					return;
				}
				KBEntry kBEntry = null;
				if (e.Parameter is KBEntry)
				{
					kBEntry = (KBEntry)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					string text = (string)e.Parameter;
					text = text.Trim();
					if (text.IndexOf("<KBEntry") >= 0)
					{
						try
						{
							XmlSerializer xmlSerializer = new XmlSerializer(typeof(KBEntry));
							StringReader textReader = new StringReader(text);
							kBEntry = (KBEntry)xmlSerializer.Deserialize(textReader);
						}
						catch
						{
						}
					}
					if (kBEntry == null)
					{
						KBLibrary kBLibrary = null;
						kBLibrary = ((e.EditorControl != null) ? e.EditorControl.AppHost.KBLibrary : WriterAppHost.Default.KBLibrary);
						if (kBLibrary != null)
						{
							kBEntry = kBLibrary.SearchKBEntry(text);
						}
					}
				}
				if (kBEntry != null)
				{
					XTextElementList xTextElementList = e.DocumentControler.InsertKBEntry(kBEntry, logUndo: true, InputValueSource.UI);
					if (xTextElementList != null && xTextElementList.Count > 0)
					{
						e.Result = true;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		[WriterCommandDescription("InsertParameter", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertParameter.bmp")]
		protected void InsertParameter(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextParameterElement)));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				XDataBinding xDataBinding = new XDataBinding();
				xDataBinding.DataSource = Convert.ToString(e.Parameter);
				if (e.ShowUI)
				{
					using (dlgXDataBinding dlgXDataBinding = new dlgXDataBinding())
					{
						dlgXDataBinding.Document = e.Document;
						dlgXDataBinding.XDataBinding = xDataBinding;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgXDataBinding, null) != DialogResult.OK)
						{
							return;
						}
					}
				}
				XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.ValueBinding = xDataBinding;
				xTextInputFieldElement.OwnerDocument = e.Document;
				xTextInputFieldElement.ContentReadonly = ContentReadonlyState.False;
				xTextInputFieldElement.UserEditable = false;
				xTextInputFieldElement.StyleIndex = e.Document.ContentStyles.GetStyleIndex(e.Document.CurrentStyleInfo.Content);
				xTextInputFieldElement.UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: true));
				xTextInputFieldElement.StartElement.StyleIndex = xTextInputFieldElement.StyleIndex;
				xTextInputFieldElement.EndElement.StyleIndex = xTextInputFieldElement.StyleIndex;
				e.Document.DocumentControler.InsertElement(xTextInputFieldElement);
				e.Document.OnSelectionChanged();
				e.Document.OnDocumentContentChanged();
				e.Result = xTextInputFieldElement;
			}
		}

		/// <summary>
		///       插入一个标尺对象
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertRuler", ReturnValueType = typeof(XTextRulerElement))]
		protected void InsertRuler(object sender, WriterCommandEventArgs e)
		{
			int num = 5;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextRulerElement)));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextRulerElement xTextRulerElement = null;
				if (e.Parameter is XTextRulerElement)
				{
					xTextRulerElement = (XTextRulerElement)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					xTextRulerElement = (XTextRulerElement)e.Document.CreateElementByType(typeof(XTextRulerElement));
					xTextRulerElement.Text = (string)e.Parameter;
				}
				if (xTextRulerElement == null)
				{
					xTextRulerElement = (XTextRulerElement)e.Document.CreateElementByType(typeof(XTextRulerElement));
				}
				if (string.IsNullOrEmpty(xTextRulerElement.Text))
				{
					xTextRulerElement.Text = WriterStrings.LabelNewText;
				}
				e.Document.AllocElementID("ruler", xTextRulerElement);
				if ((!e.ShowUI || WriterAppHost.smethod_4(e, xTextRulerElement, ElementPropertiesEditMethod.Insert)) && xTextRulerElement != null)
				{
					xTextRulerElement.OwnerDocument = e.Document;
					e.Document.ValidateElementIDRepeat(xTextRulerElement);
					if (e.DocumentControler.InsertElement(xTextRulerElement))
					{
						e.Result = xTextRulerElement;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}
	}
}
