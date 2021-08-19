using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Extension.Medical
{
	/// <summary>
	///       本类型已经过期，请使用DCSoft.Writer.Dom.XTextNewMedicalExpressionElement类型
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[DebuggerDisplay("Medical expression:{Name}")]
	[ComClass("0AD5C109-0BD6-48EC-84D4-5A5C5DFDED32", "2076D8D3-5AB0-4AA8-9B4F-D24550AE550B")]
	[Guid("0AD5C109-0BD6-48EC-84D4-5A5C5DFDED32")]
	[XmlType("XMedicalExpressionField")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextMedicalExpressionFieldElement))]
	[ComVisible(true)]
	[DCInternal]
	public class XTextMedicalExpressionFieldElement : XTextShapeInputFieldElement, IXTextMedicalExpressionFieldElement
	{
		internal const string string_23 = "0AD5C109-0BD6-48EC-84D4-5A5C5DFDED32";

		internal const string string_24 = "2076D8D3-5AB0-4AA8-9B4F-D24550AE550B";

		private VerticalAlignStyle verticalAlignStyle_0 = VerticalAlignStyle.Middle;

		private bool bool_23 = true;

		private MedicalExpressionStyle medicalExpressionStyle_0 = MedicalExpressionStyle.FourValues;

		private string string_25 = null;

		[NonSerialized]
		private GClass24 gclass24_0 = null;

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[ComVisible(true)]
		[HtmlAttribute]
		[DefaultValue(VerticalAlignStyle.Middle)]
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
		///       以对话框的模式输入数值
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		public bool EditValueInDialog
		{
			get
			{
				return bool_23;
			}
			set
			{
				bool_23 = value;
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		[XmlElement]
		[Browsable(true)]
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
		[XmlElement]
		[Browsable(true)]
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
		[DefaultValue(MedicalExpressionStyle.FourValues)]
		[HtmlAttribute(DetectDefaultValue = false)]
		public MedicalExpressionStyle ExpressionStyle
		{
			get
			{
				return medicalExpressionStyle_0;
			}
			set
			{
				medicalExpressionStyle_0 = value;
				gclass24_0 = null;
			}
		}

		/// <summary>
		///       DCWriter内部使用.
		///       </summary>
		[Obsolete("DCWriter内部使用")]
		[HtmlAttribute]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DefaultValue(null)]
		public string InnerSerializeText
		{
			get
			{
				return Text;
			}
			set
			{
				string_25 = value;
			}
		}

		/// <summary>
		///       内置的表达式呈现器
		///       </summary>
		internal GClass24 ExpressionRender
		{
			get
			{
				CheckShapeState(updateSize: false);
				return gclass24_0;
			}
		}

		bool IXTextMedicalExpressionFieldElement.Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
			}
		}

		/// <summary>
		///       检查医学表达式元素状态
		///       </summary>
		/// <param name="updateSize">是否根据需要计算元素大小</param>
		public override void CheckShapeState(bool updateSize)
		{
			int num = 7;
			if (gclass24_0 == null)
			{
				gclass24_0 = new GClass24();
				gclass24_0.method_1(base.ContentVersion - 1);
			}
			if (gclass24_0.method_0() != base.ContentVersion)
			{
				gclass24_0.method_1(base.ContentVersion);
				gclass24_0.method_72(ExpressionStyle);
				string text = Text;
				if (text != null && text.Length > 0)
				{
					string[] array = text.Split(',', ';', '，');
					gclass24_0.method_8(null);
					gclass24_0.method_10(null);
					gclass24_0.method_12(null);
					gclass24_0.method_14(null);
					gclass24_0.method_16(null);
					gclass24_0.method_18(null);
					gclass24_0.method_20(null);
					gclass24_0.method_22(null);
					gclass24_0.method_24(null);
					gclass24_0.method_26(null);
					gclass24_0.method_28(null);
					gclass24_0.method_30(null);
					gclass24_0.method_32(null);
					gclass24_0.method_34(null);
					gclass24_0.method_36(null);
					gclass24_0.method_38(null);
					gclass24_0.method_40(null);
					gclass24_0.method_42(null);
					gclass24_0.method_44(null);
					gclass24_0.method_46(null);
					gclass24_0.method_48(null);
					gclass24_0.method_50(null);
					gclass24_0.method_52(null);
					gclass24_0.method_54(null);
					gclass24_0.method_56(null);
					gclass24_0.method_58(null);
					gclass24_0.method_60(null);
					gclass24_0.method_62(null);
					gclass24_0.method_64(null);
					gclass24_0.method_66(null);
					gclass24_0.method_68(null);
					gclass24_0.method_70(null);
					if (gclass24_0.method_71() == MedicalExpressionStyle.PermanentTeethBitmap)
					{
						string text2 = null;
						for (int i = 0; i < array.Length; i++)
						{
							switch (array[i])
							{
							case "18":
								gclass24_0.method_8("8");
								break;
							case "17":
								gclass24_0.method_10("7");
								break;
							case "16":
								gclass24_0.method_12("6");
								break;
							case "15":
								gclass24_0.method_14("5");
								break;
							case "14":
								gclass24_0.method_16("4");
								break;
							case "13":
								gclass24_0.method_18("3");
								break;
							case "12":
								gclass24_0.method_20("2");
								break;
							case "11":
								gclass24_0.method_22("1");
								break;
							case "21":
								gclass24_0.method_24("1");
								break;
							case "22":
								gclass24_0.method_26("2");
								break;
							case "23":
								gclass24_0.method_28("3");
								break;
							case "24":
								gclass24_0.method_30("4");
								break;
							case "25":
								gclass24_0.method_32("5");
								break;
							case "26":
								gclass24_0.method_34("6");
								break;
							case "27":
								gclass24_0.method_36("7");
								break;
							case "28":
								gclass24_0.method_38("8");
								break;
							case "48":
								gclass24_0.method_40("8");
								break;
							case "47":
								gclass24_0.method_42("7");
								break;
							case "46":
								gclass24_0.method_44("6");
								break;
							case "45":
								gclass24_0.method_46("5");
								break;
							case "44":
								gclass24_0.method_48("4");
								break;
							case "43":
								gclass24_0.method_50("3");
								break;
							case "42":
								gclass24_0.method_52("2");
								break;
							case "41":
								gclass24_0.method_54("1");
								break;
							case "31":
								gclass24_0.method_56("1");
								break;
							case "32":
								gclass24_0.method_58("2");
								break;
							case "33":
								gclass24_0.method_60("3");
								break;
							case "34":
								gclass24_0.method_62("4");
								break;
							case "35":
								gclass24_0.method_64("5");
								break;
							case "36":
								gclass24_0.method_66("6");
								break;
							case "37":
								gclass24_0.method_68("7");
								break;
							case "38":
								gclass24_0.method_70("8");
								break;
							}
						}
					}
					else if (gclass24_0.method_71() == MedicalExpressionStyle.DeciduousTeech)
					{
						string text2 = null;
						for (int i = 0; i < array.Length; i++)
						{
							switch (array[i])
							{
							case "15":
								gclass24_0.method_8("V");
								break;
							case "14":
								gclass24_0.method_10("IV");
								break;
							case "13":
								gclass24_0.method_12("III");
								break;
							case "12":
								gclass24_0.method_14("II");
								break;
							case "11":
								gclass24_0.method_16("I");
								break;
							case "21":
								gclass24_0.method_18("I");
								break;
							case "22":
								gclass24_0.method_20("II");
								break;
							case "23":
								gclass24_0.method_22("III");
								break;
							case "24":
								gclass24_0.method_24("IV");
								break;
							case "25":
								gclass24_0.method_26("V");
								break;
							case "45":
								gclass24_0.method_28("V");
								break;
							case "44":
								gclass24_0.method_30("IV");
								break;
							case "43":
								gclass24_0.method_32("III");
								break;
							case "42":
								gclass24_0.method_34("II");
								break;
							case "41":
								gclass24_0.method_36("I");
								break;
							case "31":
								gclass24_0.method_38("I");
								break;
							case "32":
								gclass24_0.method_40("II");
								break;
							case "33":
								gclass24_0.method_42("III");
								break;
							case "34":
								gclass24_0.method_44("IV");
								break;
							case "35":
								gclass24_0.method_46("V");
								break;
							}
						}
					}
					else
					{
						if (array.Length > 0)
						{
							gclass24_0.method_8(array[0]);
						}
						if (array.Length > 1)
						{
							gclass24_0.method_10(array[1]);
						}
						if (array.Length > 2)
						{
							gclass24_0.method_12(array[2]);
						}
						if (array.Length > 3)
						{
							gclass24_0.method_14(array[3]);
						}
						if (array.Length > 4)
						{
							gclass24_0.method_16(array[4]);
						}
						if (array.Length > 5)
						{
							gclass24_0.method_18(array[5]);
						}
						if (array.Length > 6)
						{
							gclass24_0.method_20(array[6]);
						}
						if (array.Length > 7)
						{
							gclass24_0.method_22(array[7]);
						}
						if (array.Length > 8)
						{
							gclass24_0.method_24(array[8]);
						}
					}
				}
				SizeInvalid = true;
			}
			if (updateSize)
			{
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				gclass24_0.method_3(runtimeStyle.Font);
				gclass24_0.method_5(runtimeStyle.Color);
			}
			if (updateSize && SizeInvalid)
			{
				using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
				{
					RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
					gclass24_0.method_3(runtimeStyle.Font);
					gclass24_0.method_5(runtimeStyle.Color);
					SizeF sizeF = gclass24_0.method_73(dcgraphics_);
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
			CheckShapeState(updateSize: true);
			gclass24_0.method_74(args.Graphics, AbsBounds);
			GEnum6 genum6_ = method_38(ExpressionStyle);
			XTextDocument.smethod_10(this, args, genum6_);
		}

		private GEnum6 method_38(MedicalExpressionStyle medicalExpressionStyle_1)
		{
			GEnum6 result = GEnum6.const_205;
			switch (medicalExpressionStyle_1)
			{
			case MedicalExpressionStyle.FourValues:
				result = GEnum6.const_205;
				break;
			case MedicalExpressionStyle.FourValues1:
				result = GEnum6.const_205;
				break;
			case MedicalExpressionStyle.FourValues2:
				result = GEnum6.const_205;
				break;
			case MedicalExpressionStyle.ThreeValues:
				result = GEnum6.const_205;
				break;
			case MedicalExpressionStyle.Pupil:
				result = GEnum6.const_206;
				break;
			case MedicalExpressionStyle.LightPositioning:
				result = GEnum6.const_207;
				break;
			case MedicalExpressionStyle.FetalHeart:
				result = GEnum6.const_208;
				break;
			case MedicalExpressionStyle.PermanentTeethBitmap:
				result = GEnum6.const_209;
				break;
			case MedicalExpressionStyle.DeciduousTeech:
				result = GEnum6.const_210;
				break;
			case MedicalExpressionStyle.PainIndex:
				result = GEnum6.const_211;
				break;
			}
			return result;
		}

		public override void vmethod_46(DocumentEventArgs documentEventArgs_0)
		{
			int num = 12;
			if (!OwnerDocument.DocumentControler.CanModify(this))
			{
				documentEventArgs_0.Handled = true;
			}
			else if (EditValueInDialog)
			{
				if (ExpressionStyle == MedicalExpressionStyle.FourValues1)
				{
					using (dlgFourValues1 dlgFourValues = new dlgFourValues1())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgFourValues.Value1 = array[0];
							}
							if (array.Length > 1)
							{
								dlgFourValues.Value2 = array[1];
							}
							if (array.Length > 2)
							{
								dlgFourValues.Value3 = array[2];
							}
							if (array.Length > 3)
							{
								dlgFourValues.Value4 = array[3];
							}
						}
						if (dlgFourValues.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgFourValues.Value1 + "," + dlgFourValues.Value2 + "," + dlgFourValues.Value3 + "," + dlgFourValues.Value4;
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.FourValues2)
				{
					using (dlgFourValues2 dlgFourValues2 = new dlgFourValues2())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgFourValues2.Value1 = array[0];
							}
							if (array.Length > 1)
							{
								dlgFourValues2.Value2 = array[1];
							}
							if (array.Length > 2)
							{
								dlgFourValues2.Value3 = array[2];
							}
							if (array.Length > 3)
							{
								dlgFourValues2.Value4 = array[3];
							}
						}
						if (dlgFourValues2.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgFourValues2.Value1 + "," + dlgFourValues2.Value2 + "," + dlgFourValues2.Value3 + "," + dlgFourValues2.Value4;
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.FourValues)
				{
					using (dlgFourValues3 dlgFourValues3 = new dlgFourValues3())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgFourValues3.Value1 = array[0];
							}
							if (array.Length > 1)
							{
								dlgFourValues3.Value2 = array[1];
							}
							if (array.Length > 2)
							{
								dlgFourValues3.Value3 = array[2];
							}
							if (array.Length > 3)
							{
								dlgFourValues3.Value4 = array[3];
							}
						}
						if (dlgFourValues3.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgFourValues3.Value1 + "," + dlgFourValues3.Value2 + "," + dlgFourValues3.Value3 + "," + dlgFourValues3.Value4;
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.ThreeValues)
				{
					using (dlgThreeValues1 dlgThreeValues = new dlgThreeValues1())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgThreeValues.Value1 = array[0];
							}
							if (array.Length > 1)
							{
								dlgThreeValues.Value2 = array[1];
							}
							if (array.Length > 2)
							{
								dlgThreeValues.Value3 = array[2];
							}
						}
						if (dlgThreeValues.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgThreeValues.Value1 + "," + dlgThreeValues.Value2 + "," + dlgThreeValues.Value3;
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.Pupil)
				{
					using (dlgPupil dlgPupil = new dlgPupil())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgPupil.Value1 = array[0];
							}
							if (array.Length > 1)
							{
								dlgPupil.Value2 = array[1];
							}
							if (array.Length > 2)
							{
								dlgPupil.Value3 = array[2];
							}
							if (array.Length > 3)
							{
								dlgPupil.Value4 = array[3];
							}
							if (array.Length > 4)
							{
								dlgPupil.Value5 = array[4];
							}
							if (array.Length > 5)
							{
								dlgPupil.Value6 = array[5];
							}
							if (array.Length > 6)
							{
								dlgPupil.Value7 = array[6];
							}
						}
						if (dlgPupil.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgPupil.Value1 + "," + dlgPupil.Value2 + "," + dlgPupil.Value3 + "," + dlgPupil.Value4 + "," + dlgPupil.Value5 + "," + dlgPupil.Value6 + "," + dlgPupil.Value7;
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.LightPositioning)
				{
					using (dlgLightPosition dlgLightPosition = new dlgLightPosition())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgLightPosition.Value1 = array[0];
							}
							if (array.Length > 1)
							{
								dlgLightPosition.Value2 = array[1];
							}
							if (array.Length > 2)
							{
								dlgLightPosition.Value3 = array[2];
							}
							if (array.Length > 3)
							{
								dlgLightPosition.Value4 = array[3];
							}
							if (array.Length > 4)
							{
								dlgLightPosition.Value5 = array[4];
							}
							if (array.Length > 5)
							{
								dlgLightPosition.Value6 = array[5];
							}
							if (array.Length > 6)
							{
								dlgLightPosition.Value7 = array[6];
							}
							if (array.Length > 7)
							{
								dlgLightPosition.Value8 = array[7];
							}
							if (array.Length > 8)
							{
								dlgLightPosition.Value9 = array[8];
							}
						}
						if (dlgLightPosition.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgLightPosition.Value1 + "," + dlgLightPosition.Value2 + "," + dlgLightPosition.Value3 + "," + dlgLightPosition.Value4 + "," + dlgLightPosition.Value5 + "," + dlgLightPosition.Value6 + "," + dlgLightPosition.Value7 + "," + dlgLightPosition.Value8 + "," + dlgLightPosition.Value9;
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.FetalHeart)
				{
					using (dlgFetalHeart dlgFetalHeart = new dlgFetalHeart())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgFetalHeart.Value1 = array[0];
							}
							if (array.Length > 1)
							{
								dlgFetalHeart.Value2 = array[1];
							}
							if (array.Length > 2)
							{
								dlgFetalHeart.Value3 = array[2];
							}
							if (array.Length > 3)
							{
								dlgFetalHeart.Value4 = array[3];
							}
							if (array.Length > 4)
							{
								dlgFetalHeart.Value5 = array[4];
							}
							if (array.Length > 5)
							{
								dlgFetalHeart.Value6 = array[5];
							}
						}
						if (dlgFetalHeart.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgFetalHeart.Value1 + "," + dlgFetalHeart.Value2 + "," + dlgFetalHeart.Value3 + "," + dlgFetalHeart.Value4 + "," + dlgFetalHeart.Value5 + "," + dlgFetalHeart.Value6;
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.PermanentTeethBitmap)
				{
					using (dlgPermanentTeethBitmap dlgPermanentTeethBitmap = new dlgPermanentTeethBitmap())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							string text3 = null;
							for (int i = 0; i < array.Length; i++)
							{
								switch (array[i])
								{
								case "18":
									dlgPermanentTeethBitmap.RightTopValue1 = 18;
									break;
								case "17":
									dlgPermanentTeethBitmap.RightTopValue2 = 17;
									break;
								case "16":
									dlgPermanentTeethBitmap.RightTopValue3 = 16;
									break;
								case "15":
									dlgPermanentTeethBitmap.RightTopValue4 = 15;
									break;
								case "14":
									dlgPermanentTeethBitmap.RightTopValue5 = 14;
									break;
								case "13":
									dlgPermanentTeethBitmap.RightTopValue6 = 13;
									break;
								case "12":
									dlgPermanentTeethBitmap.RightTopValue7 = 12;
									break;
								case "11":
									dlgPermanentTeethBitmap.RightTopValue8 = 11;
									break;
								case "21":
									dlgPermanentTeethBitmap.LeftTopValue1 = 21;
									break;
								case "22":
									dlgPermanentTeethBitmap.LeftTopValue2 = 22;
									break;
								case "23":
									dlgPermanentTeethBitmap.LeftTopValue3 = 23;
									break;
								case "24":
									dlgPermanentTeethBitmap.LeftTopValue4 = 24;
									break;
								case "25":
									dlgPermanentTeethBitmap.LeftTopValue5 = 25;
									break;
								case "26":
									dlgPermanentTeethBitmap.LeftTopValue6 = 26;
									break;
								case "27":
									dlgPermanentTeethBitmap.LeftTopValue7 = 27;
									break;
								case "28":
									dlgPermanentTeethBitmap.LeftTopValue8 = 28;
									break;
								case "48":
									dlgPermanentTeethBitmap.RightBottomValue1 = 48;
									break;
								case "47":
									dlgPermanentTeethBitmap.RightBottomValue2 = 47;
									break;
								case "46":
									dlgPermanentTeethBitmap.RightBottomValue3 = 46;
									break;
								case "45":
									dlgPermanentTeethBitmap.RightBottomValue4 = 45;
									break;
								case "44":
									dlgPermanentTeethBitmap.RightBottomValue5 = 44;
									break;
								case "43":
									dlgPermanentTeethBitmap.RightBottomValue6 = 43;
									break;
								case "42":
									dlgPermanentTeethBitmap.RightBottomValue7 = 42;
									break;
								case "41":
									dlgPermanentTeethBitmap.RightBottomValue8 = 41;
									break;
								case "31":
									dlgPermanentTeethBitmap.LeftBottomValue1 = 31;
									break;
								case "32":
									dlgPermanentTeethBitmap.LeftBottomValue2 = 32;
									break;
								case "33":
									dlgPermanentTeethBitmap.LeftBottomValue3 = 33;
									break;
								case "34":
									dlgPermanentTeethBitmap.LeftBottomValue4 = 34;
									break;
								case "35":
									dlgPermanentTeethBitmap.LeftBottomValue5 = 35;
									break;
								case "36":
									dlgPermanentTeethBitmap.LeftBottomValue6 = 36;
									break;
								case "37":
									dlgPermanentTeethBitmap.LeftBottomValue7 = 37;
									break;
								case "38":
									dlgPermanentTeethBitmap.LeftBottomValue8 = 38;
									break;
								}
							}
						}
						if (dlgPermanentTeethBitmap.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = string.Concat(dlgPermanentTeethBitmap.RightTopValue1, ",", dlgPermanentTeethBitmap.RightTopValue2, ",", dlgPermanentTeethBitmap.RightTopValue3, ",", dlgPermanentTeethBitmap.RightTopValue4, ",", dlgPermanentTeethBitmap.RightTopValue5, ",", dlgPermanentTeethBitmap.RightTopValue6, ",", dlgPermanentTeethBitmap.RightTopValue7, ",", dlgPermanentTeethBitmap.RightTopValue8, ",", dlgPermanentTeethBitmap.LeftTopValue1, ",", dlgPermanentTeethBitmap.LeftTopValue2, ",", dlgPermanentTeethBitmap.LeftTopValue3, ",", dlgPermanentTeethBitmap.LeftTopValue4, ",", dlgPermanentTeethBitmap.LeftTopValue5, ",", dlgPermanentTeethBitmap.LeftTopValue6, ",", dlgPermanentTeethBitmap.LeftTopValue7, ",", dlgPermanentTeethBitmap.LeftTopValue8, ",", dlgPermanentTeethBitmap.RightBottomValue1, ",", dlgPermanentTeethBitmap.RightBottomValue2, ",", dlgPermanentTeethBitmap.RightBottomValue3, ",", dlgPermanentTeethBitmap.RightBottomValue4, ",", dlgPermanentTeethBitmap.RightBottomValue5, ",", dlgPermanentTeethBitmap.RightBottomValue6, ",", dlgPermanentTeethBitmap.RightBottomValue7, ",", dlgPermanentTeethBitmap.RightBottomValue8, ",", dlgPermanentTeethBitmap.LeftBottomValue1, ",", dlgPermanentTeethBitmap.LeftBottomValue2, ",", dlgPermanentTeethBitmap.LeftBottomValue3, ",", dlgPermanentTeethBitmap.LeftBottomValue4, ",", dlgPermanentTeethBitmap.LeftBottomValue5, ",", dlgPermanentTeethBitmap.LeftBottomValue6, ",", dlgPermanentTeethBitmap.LeftBottomValue7, ",", dlgPermanentTeethBitmap.LeftBottomValue8);
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.DeciduousTeech)
				{
					using (dlgDeciduousTeech dlgDeciduousTeech = new dlgDeciduousTeech())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							string text3 = null;
							for (int i = 0; i < array.Length; i++)
							{
								switch (array[i])
								{
								case "15":
									dlgDeciduousTeech.RightTopValue1 = 15;
									break;
								case "14":
									dlgDeciduousTeech.RightTopValue2 = 14;
									break;
								case "13":
									dlgDeciduousTeech.RightTopValue3 = 13;
									break;
								case "12":
									dlgDeciduousTeech.RightTopValue4 = 12;
									break;
								case "11":
									dlgDeciduousTeech.RightTopValue5 = 11;
									break;
								case "21":
									dlgDeciduousTeech.LeftTopValue1 = 21;
									break;
								case "22":
									dlgDeciduousTeech.LeftTopValue2 = 22;
									break;
								case "23":
									dlgDeciduousTeech.LeftTopValue3 = 23;
									break;
								case "24":
									dlgDeciduousTeech.LeftTopValue4 = 24;
									break;
								case "25":
									dlgDeciduousTeech.LeftTopValue5 = 25;
									break;
								case "45":
									dlgDeciduousTeech.RightBottomValue1 = 45;
									break;
								case "44":
									dlgDeciduousTeech.RightBottomValue2 = 44;
									break;
								case "43":
									dlgDeciduousTeech.RightBottomValue3 = 43;
									break;
								case "42":
									dlgDeciduousTeech.RightBottomValue4 = 42;
									break;
								case "41":
									dlgDeciduousTeech.RightBottomValue5 = 41;
									break;
								case "31":
									dlgDeciduousTeech.LeftBottomValue1 = 31;
									break;
								case "32":
									dlgDeciduousTeech.LeftBottomValue2 = 32;
									break;
								case "33":
									dlgDeciduousTeech.LeftBottomValue3 = 33;
									break;
								case "34":
									dlgDeciduousTeech.LeftBottomValue4 = 34;
									break;
								case "35":
									dlgDeciduousTeech.LeftBottomValue5 = 35;
									break;
								}
							}
						}
						if (dlgDeciduousTeech.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = string.Concat(dlgDeciduousTeech.RightTopValue1, ",", dlgDeciduousTeech.RightTopValue2, ",", dlgDeciduousTeech.RightTopValue3, ",", dlgDeciduousTeech.RightTopValue4, ",", dlgDeciduousTeech.RightTopValue5, ",", dlgDeciduousTeech.LeftTopValue1, ",", dlgDeciduousTeech.LeftTopValue2, ",", dlgDeciduousTeech.LeftTopValue3, ",", dlgDeciduousTeech.LeftTopValue4, ",", dlgDeciduousTeech.LeftTopValue5, ",", dlgDeciduousTeech.RightBottomValue1, ",", dlgDeciduousTeech.RightBottomValue2, ",", dlgDeciduousTeech.RightBottomValue3, ",", dlgDeciduousTeech.RightBottomValue4, ",", dlgDeciduousTeech.RightBottomValue5, ",", dlgDeciduousTeech.LeftBottomValue1, ",", dlgDeciduousTeech.LeftBottomValue2, ",", dlgDeciduousTeech.LeftBottomValue3, ",", dlgDeciduousTeech.LeftBottomValue4, ",", dlgDeciduousTeech.LeftBottomValue5);
							if (text2 != text)
							{
								SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
							}
						}
					}
				}
				else if (medicalExpressionStyle_0 == MedicalExpressionStyle.PainIndex)
				{
					using (dlgPainIndex dlgPainIndex = new dlgPainIndex())
					{
						string text = Text;
						if (text != null && text.Length > 0)
						{
							string[] array = text.Split(',', ';', '，');
							if (array.Length > 0)
							{
								dlgPainIndex.PainIndexValue = array[0];
							}
						}
						if (dlgPainIndex.ShowDialog(OwnerDocument.EditorControl) == DialogResult.OK)
						{
							string text2 = dlgPainIndex.PainIndexValue.ToString();
							if (text2 != text)
							{
								if (string.IsNullOrEmpty(text2.Replace(',', ' ').Trim()))
								{
									EditorDelete(logUndo: true);
								}
								else
								{
									SetEditorTextExt(text2, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true);
								}
							}
						}
					}
				}
				documentEventArgs_0.Handled = true;
			}
			else
			{
				base.vmethod_46(documentEventArgs_0);
			}
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 16;
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			if (!string.IsNullOrEmpty(string_25))
			{
				string innerTextFast = string_25;
				string_25 = null;
				SetInnerTextFast(innerTextFast);
			}
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
