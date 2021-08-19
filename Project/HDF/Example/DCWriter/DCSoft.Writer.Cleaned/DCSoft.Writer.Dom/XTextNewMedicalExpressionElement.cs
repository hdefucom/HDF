using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.MedicalExpression;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[XmlType("XNewMedicalExpression")]
	[ComClass("D879B0C3-A23C-44F4-B142-412E935CBA89", "67E28F15-15A0-4F8B-89C0-3210F4B8FA53")]
	[DCPublishAPI]
	[DebuggerDisplay("New medical expression:{Name}")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXTextNewMedicalExpressionElement))]
	[Guid("D879B0C3-A23C-44F4-B142-412E935CBA89")]
	public class XTextNewMedicalExpressionElement : XTextObjectElement, IXTextNewMedicalExpressionElement
	{
		internal const string string_9 = "D879B0C3-A23C-44F4-B142-412E935CBA89";

		internal const string string_10 = "67E28F15-15A0-4F8B-89C0-3210F4B8FA53";

		private MedicalExpressionValueList medicalExpressionValueList_0 = new MedicalExpressionValueList();

		private VerticalAlignStyle verticalAlignStyle_0 = VerticalAlignStyle.Middle;

		private DCMedicalExpressionStyle dcmedicalExpressionStyle_0 = DCMedicalExpressionStyle.FourValues;

		[NonSerialized]
		private GClass20 gclass20_0 = null;

		public override string Text
		{
			get
			{
				if (medicalExpressionValueList_0 != null && medicalExpressionValueList_0.Count > 0)
				{
					return medicalExpressionValueList_0.ToString();
				}
				return null;
			}
			set
			{
				base.Text = value;
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		[HtmlAttribute]
		[XmlArrayItem("Value", typeof(DCNameValueItem))]
		[ComVisible(true)]
		[DefaultValue(null)]
		public MedicalExpressionValueList Values
		{
			get
			{
				return medicalExpressionValueList_0;
			}
			set
			{
				medicalExpressionValueList_0 = value;
			}
		}

		/// <summary>
		///       判断是否存在数据
		///       </summary>
		public bool HasValues => medicalExpressionValueList_0 != null && medicalExpressionValueList_0.Count > 0;

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(VerticalAlignStyle.Middle)]
		[ComVisible(true)]
		public virtual VerticalAlignStyle VAlign
		{
			get
			{
				return verticalAlignStyle_0;
			}
			set
			{
				verticalAlignStyle_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的垂直对齐方式
		///       </summary>
		public override VerticalAlignStyle RuntimeVAlign => VAlign;

		/// <summary>
		///       对象宽度
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       医学表达式类型
		///       </summary>
		[DefaultValue(DCMedicalExpressionStyle.FourValues)]
		[HtmlAttribute(DetectDefaultValue = false)]
		public DCMedicalExpressionStyle ExpressionStyle
		{
			get
			{
				return dcmedicalExpressionStyle_0;
			}
			set
			{
				dcmedicalExpressionStyle_0 = value;
				gclass20_0 = null;
			}
		}

		/// <summary>
		///       内置的表达式呈现器
		///       </summary>
		internal GClass20 ExpressionRender
		{
			get
			{
				method_16(bool_9: false);
				return gclass20_0;
			}
		}

		/// <summary>
		///       获得表达式子项目数据
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <returns>
		/// </returns>
		[ComVisible(true)]
		public string GetItemValue(string name)
		{
			if (medicalExpressionValueList_0 != null)
			{
				return medicalExpressionValueList_0.GetValue(name);
			}
			return null;
		}

		/// <summary>
		///       设置表达式子项目数据
		///       </summary>
		/// <param name="name">
		/// </param>
		/// <param name="newValue">
		/// </param>
		[ComVisible(true)]
		public void SetItemValue(string name, string newValue)
		{
			if (medicalExpressionValueList_0 == null)
			{
				medicalExpressionValueList_0 = new MedicalExpressionValueList();
			}
			medicalExpressionValueList_0.SetValue(name, newValue);
		}

		/// <summary>
		///       计算对象大小
		///       </summary>
		/// <param name="args">参数</param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			SizeInvalid = true;
			method_16(bool_9: true);
			base.RefreshSize(args);
		}

		public void method_16(bool bool_9)
		{
			if (gclass20_0 == null)
			{
				gclass20_0 = new GClass20();
				gclass20_0.method_3(base.ContentVersion - 1);
			}
			if (gclass20_0.method_2() != base.ContentVersion)
			{
				gclass20_0.method_3(base.ContentVersion);
				gclass20_0.method_9(ExpressionStyle);
				gclass20_0.method_1(Values);
				SizeInvalid = true;
			}
			if (bool_9)
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				gclass20_0.method_5(runtimeStyle.Font);
				gclass20_0.method_7(runtimeStyle.Color);
			}
			if (bool_9 && SizeInvalid)
			{
				using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
				{
					RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
					gclass20_0.method_5(runtimeStyle.Font);
					gclass20_0.method_7(runtimeStyle.Color);
					SizeF sizeF = gclass20_0.method_10(dcgraphics_);
					base.SizeInvalid = false;
					if (Width == 0f)
					{
						Width = sizeF.Width;
						Height = sizeF.Height;
					}
				}
			}
		}

		/// <summary>
		///       绘制内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			method_16(bool_9: true);
			gclass20_0.method_11(args.Graphics, AbsBounds);
			GEnum6 genum6_ = method_17(ExpressionStyle);
			OwnerDocument.method_114(this, args, genum6_);
		}

		private GEnum6 method_17(DCMedicalExpressionStyle dcmedicalExpressionStyle_1)
		{
			GEnum6 result = GEnum6.const_205;
			switch (dcmedicalExpressionStyle_1)
			{
			case DCMedicalExpressionStyle.FourValues:
				result = GEnum6.const_205;
				break;
			case DCMedicalExpressionStyle.FourValues1:
				result = GEnum6.const_205;
				break;
			case DCMedicalExpressionStyle.FourValues2:
				result = GEnum6.const_205;
				break;
			case DCMedicalExpressionStyle.ThreeValues:
				result = GEnum6.const_205;
				break;
			case DCMedicalExpressionStyle.Pupil:
				result = GEnum6.const_206;
				break;
			case DCMedicalExpressionStyle.LightPositioning:
				result = GEnum6.const_207;
				break;
			case DCMedicalExpressionStyle.FetalHeart:
				result = GEnum6.const_208;
				break;
			case DCMedicalExpressionStyle.PermanentTeethBitmap:
				result = GEnum6.const_209;
				break;
			case DCMedicalExpressionStyle.DeciduousTeech:
				result = GEnum6.const_210;
				break;
			case DCMedicalExpressionStyle.PainIndex:
				result = GEnum6.const_211;
				break;
			case DCMedicalExpressionStyle.PDTeech:
				result = GEnum6.const_212;
				break;
			case DCMedicalExpressionStyle.DiseasedTeethBotton:
				result = GEnum6.const_213;
				break;
			case DCMedicalExpressionStyle.DiseasedTeethTop:
				result = GEnum6.const_214;
				break;
			}
			return result;
		}

		internal void method_18(MedicalExpressionValueList medicalExpressionValueList_1, bool bool_9)
		{
			int num = 5;
			if (medicalExpressionValueList_0 != medicalExpressionValueList_1)
			{
				if (OwnerDocument.BeginLogUndo())
				{
					OwnerDocument.UndoList.AddProperty("Values", Values, medicalExpressionValueList_1, this);
					OwnerDocument.UndoList.method_16(this);
					OwnerDocument.EndLogUndo();
				}
				Values = medicalExpressionValueList_1;
				_ContentVersion++;
				OwnerDocument.Modified = true;
				if (bool_9 && Parent != null)
				{
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = OwnerDocument;
					contentChangedEventArgs.Element = this;
					Parent.method_23(contentChangedEventArgs);
					OwnerDocument.OnDocumentContentChanged();
				}
			}
		}

		public override void OnViewMouseDblClick(ElementMouseEventArgs elementMouseEventArgs_0)
		{
			base.OnViewMouseDblClick(elementMouseEventArgs_0);
			if (!elementMouseEventArgs_0.Handled && elementMouseEventArgs_0.Button == MouseButtons.Left && !RuntimeContentReadonly)
			{
				method_19();
				InvalidateView();
				elementMouseEventArgs_0.Handled = true;
			}
		}

		public void method_19()
		{
			if (OwnerDocument.DocumentControler.CanModify(this))
			{
				if (ExpressionStyle == DCMedicalExpressionStyle.FourValuesGeneral)
				{
					using (dlgFourValuesGeneral dlgFourValuesGeneral = new dlgFourValuesGeneral())
					{
						dlgFourValuesGeneral.InputValues = Values;
						if (dlgFourValuesGeneral.ShowDialog(WriterControl) == DialogResult.OK)
						{
							method_18(dlgFourValuesGeneral.InputValues.Clone(), bool_9: true);
						}
					}
				}
				if (ExpressionStyle == DCMedicalExpressionStyle.FourValues1)
				{
					using (dlgFourValues1 dlgFourValues = new dlgFourValues1())
					{
						dlgFourValues.InputValues = Values;
						if (dlgFourValues.ShowDialog(WriterControl) == DialogResult.OK)
						{
							method_18(dlgFourValues.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.FourValues2)
				{
					using (dlgFourValues2 dlgFourValues2 = new dlgFourValues2())
					{
						dlgFourValues2.InputValues = Values;
						if (dlgFourValues2.ShowDialog(WriterControl) == DialogResult.OK)
						{
							method_18(dlgFourValues2.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.FourValues)
				{
					using (dlgFourValues3 dlgFourValues3 = new dlgFourValues3())
					{
						dlgFourValues3.InputValues = Values;
						if (dlgFourValues3.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgFourValues3.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.ThreeValues)
				{
					using (dlgThreeValues1 dlgThreeValues = new dlgThreeValues1())
					{
						dlgThreeValues.InputValues = Values;
						if (dlgThreeValues.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgThreeValues.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.Pupil)
				{
					using (dlgPupil dlgPupil = new dlgPupil())
					{
						dlgPupil.InputValues = Values;
						if (dlgPupil.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgPupil.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.LightPositioning)
				{
					using (dlgLightPosition dlgLightPosition = new dlgLightPosition())
					{
						dlgLightPosition.InputValues = Values;
						if (dlgLightPosition.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgLightPosition.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.FetalHeart)
				{
					using (dlgFetalHeart dlgFetalHeart = new dlgFetalHeart())
					{
						dlgFetalHeart.InputValues = Values;
						if (dlgFetalHeart.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgFetalHeart.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.PermanentTeethBitmap)
				{
					using (dlgPermanentTeethBitmap dlgPermanentTeethBitmap = new dlgPermanentTeethBitmap())
					{
						dlgPermanentTeethBitmap.InputValues = Values;
						if (dlgPermanentTeethBitmap.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgPermanentTeethBitmap.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.DeciduousTeech)
				{
					using (dlgDeciduousTeech dlgDeciduousTeech = new dlgDeciduousTeech())
					{
						dlgDeciduousTeech.InputValues = Values;
						if (dlgDeciduousTeech.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgDeciduousTeech.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.PainIndex)
				{
					using (dlgPainIndex dlgPainIndex = new dlgPainIndex())
					{
						dlgPainIndex.InputValues = Values;
						if (dlgPainIndex.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgPainIndex.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.PDTeech)
				{
					using (dlgPDTeech dlgPDTeech = new dlgPDTeech())
					{
						dlgPDTeech.InputValues = Values;
						if (dlgPDTeech.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgPDTeech.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.DiseasedTeethBotton)
				{
					using (dlgDiseasedTeethBottom dlgDiseasedTeethBottom = new dlgDiseasedTeethBottom())
					{
						dlgDiseasedTeethBottom.InputValues = Values;
						if (dlgDiseasedTeethBottom.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgDiseasedTeethBottom.InputValues.Clone(), bool_9: true);
						}
					}
				}
				else if (dcmedicalExpressionStyle_0 == DCMedicalExpressionStyle.DiseasedTeethTop)
				{
					using (dlgDiseasedTeethTop dlgDiseasedTeethTop = new dlgDiseasedTeethTop())
					{
						dlgDiseasedTeethTop.InputValues = Values;
						if (dlgDiseasedTeethTop.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							method_18(dlgDiseasedTeethTop.InputValues.Clone(), bool_9: true);
						}
					}
				}
			}
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 2;
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			SizeF sizeF = readHTMLEventArgs_0.ReadImageSize(readHTMLEventArgs_0.HtmlElement);
			if (sizeF.Width > 0f)
			{
				Width = sizeF.Width;
			}
			if (sizeF.Height > 0f)
			{
				Height = sizeF.Height;
			}
			if (readHTMLEventArgs_0.HtmlElement.method_13("dcfontsize"))
			{
				float result = 9f;
				if (float.TryParse(readHTMLEventArgs_0.HtmlElement.method_9("dcfontsize"), out result))
				{
					Style.FontSize = result;
				}
			}
		}
	}
}
