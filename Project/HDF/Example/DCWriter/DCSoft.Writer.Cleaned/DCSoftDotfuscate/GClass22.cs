using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.ShapeEditor.Dom;
using DCSoft.TemperatureChart;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using DCSoft.Writer.Script;
using DCSoft.Writer.Security;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass22 : GClass21
	{
		protected override void vmethod_0(object object_0)
		{
			if (object_0 is HyperlinkInfo)
			{
				method_57((HyperlinkInfo)object_0);
			}
			if (object_0 is ValueValidateStyle)
			{
				method_59((ValueValidateStyle)object_0);
			}
			if (object_0 is ValueFormater)
			{
				method_61((ValueFormater)object_0);
			}
			if (object_0 is ContentStyle)
			{
				method_63((ContentStyle)object_0);
			}
			if (object_0 is ContentStyleList)
			{
				method_65((ContentStyleList)object_0);
			}
			if (object_0 is DocumentTerminalTextInfo)
			{
				method_67((DocumentTerminalTextInfo)object_0);
			}
			if (object_0 is PageBorderBackgroundStyle)
			{
				method_69((PageBorderBackgroundStyle)object_0);
			}
			if (object_0 is WatermarkInfo)
			{
				method_71((WatermarkInfo)object_0);
			}
			if (object_0 is XFontValue)
			{
				method_73((XFontValue)object_0);
			}
			if (object_0 is XImageValue)
			{
				method_75((XImageValue)object_0);
			}
			if (object_0 is DCGridLineInfo)
			{
				method_77((DCGridLineInfo)object_0);
			}
			if (object_0 is JumpPrintInfo)
			{
				method_79((JumpPrintInfo)object_0);
			}
			if (object_0 is XPageSettings)
			{
				method_81((XPageSettings)object_0);
			}
			if (object_0 is ShapeContentStyleContainer)
			{
				method_83((ShapeContentStyleContainer)object_0);
			}
			if (object_0 is ShapeDocument)
			{
				method_85((ShapeDocument)object_0);
			}
			if (object_0 is ShapeDocumentImagePage)
			{
				method_87((ShapeDocumentImagePage)object_0);
			}
			if (object_0 is ShapeElement)
			{
				method_89((ShapeElement)object_0);
			}
			if (object_0 is ShapeElementList)
			{
				method_91((ShapeElementList)object_0);
			}
			if (object_0 is ShapeEllipseElement)
			{
				method_93((ShapeEllipseElement)object_0);
			}
			if (object_0 is ShapeLineElement)
			{
				method_95((ShapeLineElement)object_0);
			}
			if (object_0 is ShapeLinesElement)
			{
				method_97((ShapeLinesElement)object_0);
			}
			if (object_0 is ShapePolygonElement)
			{
				method_99((ShapePolygonElement)object_0);
			}
			if (object_0 is ShapeRectangleElement)
			{
				method_101((ShapeRectangleElement)object_0);
			}
			if (object_0 is ShapeWireLabelElement)
			{
				method_103((ShapeWireLabelElement)object_0);
			}
			if (object_0 is ShapeZoomInElement)
			{
				method_105((ShapeZoomInElement)object_0);
			}
			if (object_0 is DCTimeLineImage)
			{
				method_107((DCTimeLineImage)object_0);
			}
			if (object_0 is DCTimeLineImageList)
			{
				method_109((DCTimeLineImageList)object_0);
			}
			if (object_0 is DCTimeLineLabel)
			{
				method_111((DCTimeLineLabel)object_0);
			}
			if (object_0 is DCTimeLineLabelList)
			{
				method_113((DCTimeLineLabelList)object_0);
			}
			if (object_0 is DCTimeLineParameter)
			{
				method_115((DCTimeLineParameter)object_0);
			}
			if (object_0 is DCTimeLineParameterList)
			{
				method_117((DCTimeLineParameterList)object_0);
			}
			if (object_0 is DocumentData)
			{
				method_119((DocumentData)object_0);
			}
			if (object_0 is DocumentDataList)
			{
				method_121((DocumentDataList)object_0);
			}
			if (object_0 is DocumentPageSettings)
			{
				method_123((DocumentPageSettings)object_0);
			}
			if (object_0 is HeaderLabelInfo)
			{
				method_125((HeaderLabelInfo)object_0);
			}
			if (object_0 is HeaderLabelInfoList)
			{
				method_127((HeaderLabelInfoList)object_0);
			}
			if (object_0 is TemperatureDocument)
			{
				method_129((TemperatureDocument)object_0);
			}
			if (object_0 is TemperatureDocumentConfig)
			{
				method_131((TemperatureDocumentConfig)object_0);
			}
			if (object_0 is TickInfo)
			{
				method_133((TickInfo)object_0);
			}
			if (object_0 is TickInfoList)
			{
				method_135((TickInfoList)object_0);
			}
			if (object_0 is TimeLineZoneInfo)
			{
				method_137((TimeLineZoneInfo)object_0);
			}
			if (object_0 is TimeLineZoneInfoList)
			{
				method_139((TimeLineZoneInfoList)object_0);
			}
			if (object_0 is TitleLineInfo)
			{
				method_141((TitleLineInfo)object_0);
			}
			if (object_0 is TitleLineInfoList)
			{
				method_143((TitleLineInfoList)object_0);
			}
			if (object_0 is ValuePoint)
			{
				method_145((ValuePoint)object_0);
			}
			if (object_0 is ValuePointDataSourceInfo)
			{
				method_147((ValuePointDataSourceInfo)object_0);
			}
			if (object_0 is ValuePointList)
			{
				method_149((ValuePointList)object_0);
			}
			if (object_0 is YAxisInfo)
			{
				method_151((YAxisInfo)object_0);
			}
			if (object_0 is YAxisInfoList)
			{
				method_153((YAxisInfoList)object_0);
			}
			if (object_0 is YAxisScaleInfo)
			{
				method_155((YAxisScaleInfo)object_0);
			}
			if (object_0 is YAxisScaleInfoList)
			{
				method_157((YAxisScaleInfoList)object_0);
			}
			if (object_0 is WriterControlOptions)
			{
				method_159((WriterControlOptions)object_0);
			}
			if (object_0 is CurrentUserInfo)
			{
				method_161((CurrentUserInfo)object_0);
			}
			if (object_0 is DocumentParameter)
			{
				method_163((DocumentParameter)object_0);
			}
			if (object_0 is DocumentParameterCollection)
			{
				method_165((DocumentParameterCollection)object_0);
			}
			if (object_0 is LinkListBindingInfo)
			{
				method_167((LinkListBindingInfo)object_0);
			}
			if (object_0 is ListItem)
			{
				method_169((ListItem)object_0);
			}
			if (object_0 is ListItemCollection)
			{
				method_171((ListItemCollection)object_0);
			}
			if (object_0 is ListSourceInfo)
			{
				method_173((ListSourceInfo)object_0);
			}
			if (object_0 is XDataBinding)
			{
				method_175((XDataBinding)object_0);
			}
			if (object_0 is XMLViewStateBag)
			{
				method_177((XMLViewStateBag)object_0);
			}
			if (object_0 is XMLViewStateBagItem)
			{
				method_179((XMLViewStateBagItem)object_0);
			}
			if (object_0 is DCXmlSerializablePackage)
			{
				method_181((DCXmlSerializablePackage)object_0);
			}
			if (object_0 is DocumentBehaviorOptions)
			{
				method_183((DocumentBehaviorOptions)object_0);
			}
			if (object_0 is DocumentEditOptions)
			{
				method_185((DocumentEditOptions)object_0);
			}
			if (object_0 is DocumentOptions)
			{
				method_187((DocumentOptions)object_0);
			}
			if (object_0 is DocumentViewOptions)
			{
				method_189((DocumentViewOptions)object_0);
			}
			if (object_0 is CopySourceInfo)
			{
				method_191((CopySourceInfo)object_0);
			}
			if (object_0 is DCContentLockInfo)
			{
				method_193((DCContentLockInfo)object_0);
			}
			if (object_0 is DocumentComment)
			{
				method_195((DocumentComment)object_0);
			}
			if (object_0 is DocumentCommentList)
			{
				method_197((DocumentCommentList)object_0);
			}
			if (object_0 is DocumentContentStyle)
			{
				method_199((DocumentContentStyle)object_0);
			}
			if (object_0 is DocumentContentStyleContainer)
			{
				method_201((DocumentContentStyleContainer)object_0);
			}
			if (object_0 is DocumentInfo)
			{
				method_203((DocumentInfo)object_0);
			}
			if (object_0 is FileContentSource)
			{
				method_205((FileContentSource)object_0);
			}
			if (object_0 is InputFieldListItem)
			{
				method_207((InputFieldListItem)object_0);
			}
			if (object_0 is InputFieldListItemList)
			{
				method_209((InputFieldListItemList)object_0);
			}
			if (object_0 is InputFieldSettings)
			{
				method_211((InputFieldSettings)object_0);
			}
			if (object_0 is LocalConfig)
			{
				method_213((LocalConfig)object_0);
			}
			if (object_0 is MotherTemplateInfo)
			{
				method_215((MotherTemplateInfo)object_0);
			}
			if (object_0 is ObjectParameter)
			{
				method_217((ObjectParameter)object_0);
			}
			if (object_0 is ObjectParameterList)
			{
				method_219((ObjectParameterList)object_0);
			}
			if (object_0 is PageContentVersionInfo)
			{
				method_221((PageContentVersionInfo)object_0);
			}
			if (object_0 is PageContentVersionInfoList)
			{
				method_223((PageContentVersionInfoList)object_0);
			}
			if (object_0 is PageImageInfo)
			{
				method_225((PageImageInfo)object_0);
			}
			if (object_0 is PageImageInfoList)
			{
				method_227((PageImageInfoList)object_0);
			}
			if (object_0 is PageLabelText)
			{
				method_229((PageLabelText)object_0);
			}
			if (object_0 is PageLabelTextList)
			{
				method_231((PageLabelTextList)object_0);
			}
			if (object_0 is PropertyExpressionInfo)
			{
				method_233((PropertyExpressionInfo)object_0);
			}
			if (object_0 is PropertyExpressionInfoList)
			{
				method_235((PropertyExpressionInfoList)object_0);
			}
			if (object_0 is RepeatedImageValue)
			{
				method_237((RepeatedImageValue)object_0);
			}
			if (object_0 is RepeatedImageValueList)
			{
				method_239((RepeatedImageValueList)object_0);
			}
			if (object_0 is SpecifyPageIndexInfo)
			{
				method_241((SpecifyPageIndexInfo)object_0);
			}
			if (object_0 is SpecifyPageIndexInfoList)
			{
				method_243((SpecifyPageIndexInfoList)object_0);
			}
			if (object_0 is SubDocumentSettings)
			{
				method_245((SubDocumentSettings)object_0);
			}
			if (object_0 is XAttribute)
			{
				method_247((XAttribute)object_0);
			}
			if (object_0 is XAttributeList)
			{
				method_249((XAttributeList)object_0);
			}
			if (object_0 is XTextAccountingNumberElement)
			{
				method_251((XTextAccountingNumberElement)object_0);
			}
			if (object_0 is XTextBarcodeFieldElement)
			{
				method_253((XTextBarcodeFieldElement)object_0);
			}
			if (object_0 is XTextBeanFieldElement)
			{
				method_255((XTextBeanFieldElement)object_0);
			}
			if (object_0 is XTextBookmark)
			{
				method_257((XTextBookmark)object_0);
			}
			if (object_0 is XTextButtonElement)
			{
				method_259((XTextButtonElement)object_0);
			}
			if (object_0 is XTextCheckBoxElement)
			{
				method_261((XTextCheckBoxElement)object_0);
			}
			if (object_0 is XTextContentLinkFieldElement)
			{
				method_263((XTextContentLinkFieldElement)object_0);
			}
			if (object_0 is XTextControlHostElement)
			{
				method_265((XTextControlHostElement)object_0);
			}
			if (object_0 is XTextCustomShapeElement)
			{
				method_267((XTextCustomShapeElement)object_0);
			}
			if (object_0 is XTextDirectoryFieldElement)
			{
				method_269((XTextDirectoryFieldElement)object_0);
			}
			if (object_0 is XTextDocument)
			{
				method_271((XTextDocument)object_0);
			}
			if (object_0 is XTextDocumentBodyElement)
			{
				method_273((XTextDocumentBodyElement)object_0);
			}
			if (object_0 is XTextDocumentFieldElement)
			{
				method_275((XTextDocumentFieldElement)object_0);
			}
			if (object_0 is XTextDocumentFooterElement)
			{
				method_277((XTextDocumentFooterElement)object_0);
			}
			if (object_0 is XTextDocumentHeaderElement)
			{
				method_279((XTextDocumentHeaderElement)object_0);
			}
			if (object_0 is XTextElement)
			{
				method_281((XTextElement)object_0);
			}
			if (object_0 is XTextElementList)
			{
				method_283((XTextElementList)object_0);
			}
			if (object_0 is XTextFieldElementBase)
			{
				method_285((XTextFieldElementBase)object_0);
			}
			if (object_0 is XTextFileBlockElement)
			{
				method_287((XTextFileBlockElement)object_0);
			}
			if (object_0 is XTextHorizontalLineElement)
			{
				method_289((XTextHorizontalLineElement)object_0);
			}
			if (object_0 is XTextImageElement)
			{
				method_291((XTextImageElement)object_0);
			}
			if (object_0 is XTextInputFieldElement)
			{
				method_293((XTextInputFieldElement)object_0);
			}
			if (object_0 is XTextInputFieldElementBase)
			{
				method_295((XTextInputFieldElementBase)object_0);
			}
			if (object_0 is XTextLabelElement)
			{
				method_297((XTextLabelElement)object_0);
			}
			if (object_0 is XTextLineBreakElement)
			{
				method_299((XTextLineBreakElement)object_0);
			}
			if (object_0 is XTextMediaElement)
			{
				method_301((XTextMediaElement)object_0);
			}
			if (object_0 is XTextObjectElement)
			{
				method_303((XTextObjectElement)object_0);
			}
			if (object_0 is XTextPageBreakElement)
			{
				method_305((XTextPageBreakElement)object_0);
			}
			if (object_0 is XTextPageInfoElement)
			{
				method_307((XTextPageInfoElement)object_0);
			}
			if (object_0 is XTextParagraphFlagElement)
			{
				method_309((XTextParagraphFlagElement)object_0);
			}
			if (object_0 is XTextRadioBoxElement)
			{
				method_311((XTextRadioBoxElement)object_0);
			}
			if (object_0 is XTextSectionElement)
			{
				method_313((XTextSectionElement)object_0);
			}
			if (object_0 is XTextSignElement)
			{
				method_315((XTextSignElement)object_0);
			}
			if (object_0 is XTextStringElement)
			{
				method_317((XTextStringElement)object_0);
			}
			if (object_0 is XTextSubDocumentElement)
			{
				method_319((XTextSubDocumentElement)object_0);
			}
			if (object_0 is XTextTableCellElement)
			{
				method_321((XTextTableCellElement)object_0);
			}
			if (object_0 is XTextTableColumnElement)
			{
				method_323((XTextTableColumnElement)object_0);
			}
			if (object_0 is XTextTableElement)
			{
				method_325((XTextTableElement)object_0);
			}
			if (object_0 is XTextTableRowElement)
			{
				method_327((XTextTableRowElement)object_0);
			}
			if (object_0 is XTextTDBarcodeElement)
			{
				method_329((XTextTDBarcodeElement)object_0);
			}
			if (object_0 is XTextTemperatureChartElement)
			{
				method_331((XTextTemperatureChartElement)object_0);
			}
			if (object_0 is EventExpressionInfo)
			{
				method_333((EventExpressionInfo)object_0);
			}
			if (object_0 is EventExpressionInfoList)
			{
				method_335((EventExpressionInfoList)object_0);
			}
			if (object_0 is DomExpression)
			{
				method_337((DomExpression)object_0);
			}
			if (object_0 is DomExpressionList)
			{
				method_339((DomExpressionList)object_0);
			}
			if (object_0 is VBScriptItem)
			{
				method_341((VBScriptItem)object_0);
			}
			if (object_0 is VBScriptItemList)
			{
				method_343((VBScriptItemList)object_0);
			}
			if (object_0 is DocumentSecurityOptions)
			{
				method_345((DocumentSecurityOptions)object_0);
			}
			if (object_0 is UserHistoryInfo)
			{
				method_347((UserHistoryInfo)object_0);
			}
			if (object_0 is UserHistoryInfoList)
			{
				method_349((UserHistoryInfoList)object_0);
			}
			if (object_0 is TrackVisibleConfig)
			{
				method_351((TrackVisibleConfig)object_0);
			}
			if (object_0 is List<string>)
			{
				method_353((List<string>)object_0);
			}
		}

		private void method_57(HyperlinkInfo hyperlinkInfo_0)
		{
			int num = 7;
			if (hyperlinkInfo_0 != null)
			{
				method_3("HyperlinkInfo");
				method_58(hyperlinkInfo_0);
				method_48();
			}
		}

		private void method_58(HyperlinkInfo hyperlinkInfo_0)
		{
			int num = 17;
			if (hyperlinkInfo_0 != null)
			{
				method_26("Reference", hyperlinkInfo_0.Reference, null);
				method_26("Target", hyperlinkInfo_0.Target, null);
				method_26("Title", hyperlinkInfo_0.Title, null);
			}
		}

		private void method_59(ValueValidateStyle valueValidateStyle_0)
		{
			int num = 8;
			if (valueValidateStyle_0 != null)
			{
				method_3("ValueValidateStyle");
				method_60(valueValidateStyle_0);
				method_48();
			}
		}

		private void method_60(ValueValidateStyle valueValidateStyle_0)
		{
			int num = 14;
			if (valueValidateStyle_0 != null)
			{
				method_35("BinaryLength", valueValidateStyle_0.BinaryLength, bool_1: false);
				method_35("CheckDecimalDigits", valueValidateStyle_0.CheckDecimalDigits, bool_1: false);
				method_35("CheckMaxValue", valueValidateStyle_0.CheckMaxValue, bool_1: false);
				method_35("CheckMinValue", valueValidateStyle_0.CheckMinValue, bool_1: false);
				method_26("CustomMessage", valueValidateStyle_0.CustomMessage, null);
				method_38("DateTimeMaxValue", valueValidateStyle_0.DateTimeMaxValue);
				method_38("DateTimeMinValue", valueValidateStyle_0.DateTimeMinValue);
				method_26("ExcludeKeywords", valueValidateStyle_0.ExcludeKeywords, null);
				method_26("IncludeKeywords", valueValidateStyle_0.IncludeKeywords, null);
				method_26("Level", GClass21.smethod_4(valueValidateStyle_0.Level), "Error");
				method_27("MaxDecimalDigits", valueValidateStyle_0.MaxDecimalDigits, 0);
				method_27("MaxLength", valueValidateStyle_0.MaxLength, 0);
				method_31("MaxValue", valueValidateStyle_0.MaxValue, 0.0);
				method_27("MinLength", valueValidateStyle_0.MinLength, 0);
				method_31("MinValue", valueValidateStyle_0.MinValue, 0.0);
				method_26("Range", valueValidateStyle_0.Range, null);
				method_26("RegExpression", valueValidateStyle_0.RegExpression, null);
				method_35("Required", valueValidateStyle_0.Required, bool_1: false);
				method_26("ValueName", valueValidateStyle_0.ValueName, null);
				method_26("ValueType", GClass21.smethod_4(valueValidateStyle_0.ValueType), "Text");
			}
		}

		private void method_61(ValueFormater valueFormater_0)
		{
			int num = 6;
			if (valueFormater_0 != null)
			{
				method_3("ValueFormater");
				method_62(valueFormater_0);
				method_48();
			}
		}

		private void method_62(ValueFormater valueFormater_0)
		{
			int num = 9;
			if (valueFormater_0 != null)
			{
				method_26("Format", valueFormater_0.Format, null);
				method_26("NoneText", valueFormater_0.NoneText, null);
				method_26("Style", GClass21.smethod_4(valueFormater_0.Style), "None");
			}
		}

		private void method_63(ContentStyle contentStyle_0)
		{
			int num = 19;
			if (contentStyle_0 != null)
			{
				method_3("ContentStyle");
				method_64(contentStyle_0);
				method_48();
			}
		}

		private void method_64(ContentStyle contentStyle_0)
		{
			int num = 7;
			if (contentStyle_0 != null)
			{
				method_7("Index", contentStyle_0.Index, -1);
				method_26("Align", GClass21.smethod_4(contentStyle_0.Align), "Left");
				method_26("BackgroundColor2", contentStyle_0.BackgroundColor2String, "Black");
				method_26("BackgroundColor", contentStyle_0.BackgroundColorString, "Transparent");
				if (contentStyle_0.BackgroundImage != null)
				{
					method_3("BackgroundImage");
					method_76(contentStyle_0.BackgroundImage);
					method_48();
				}
				method_26("BackgroundPosition", GClass21.smethod_4(contentStyle_0.BackgroundPosition), "TopLeft");
				method_29("BackgroundPositionX", contentStyle_0.BackgroundPositionX, 0f);
				method_29("BackgroundPositionY", contentStyle_0.BackgroundPositionY, 0f);
				method_35("BackgroundRepeat", contentStyle_0.BackgroundRepeat, bool_1: false);
				method_26("BackgroundStyle", GClass21.smethod_4(contentStyle_0.BackgroundStyle), "Solid");
				method_35("Bold", contentStyle_0.Bold, bool_1: false);
				method_35("BorderBottom", contentStyle_0.BorderBottom, bool_1: false);
				method_26("BorderBottomColor", contentStyle_0.BorderBottomColorString, "Black");
				method_35("BorderLeft", contentStyle_0.BorderLeft, bool_1: false);
				method_26("BorderLeftColor", contentStyle_0.BorderLeftColorString, "Black");
				method_35("BorderRight", contentStyle_0.BorderRight, bool_1: false);
				method_26("BorderRightColor", contentStyle_0.BorderRightColorString, "Black");
				method_29("BorderSpacing", contentStyle_0.BorderSpacing, 0f);
				method_26("BorderStyle", GClass21.smethod_4(contentStyle_0.BorderStyle), "Solid");
				method_35("BorderTop", contentStyle_0.BorderTop, bool_1: false);
				method_26("BorderTopColor", contentStyle_0.BorderTopColorString, "Black");
				method_29("BorderWidth", contentStyle_0.BorderWidth, 0f);
				method_26("CharacterCircle", GClass21.smethod_4(contentStyle_0.CharacterCircle), "None");
				method_26("Color", contentStyle_0.ColorString, "Black");
				method_26("DefaultValuePropertyNames", contentStyle_0.DefaultValuePropertyNames, null);
				method_29("FirstLineIndent", contentStyle_0.FirstLineIndent, 0f);
				method_35("FixedSpacing", contentStyle_0.FixedSpacing, bool_1: false);
				method_26("FontName", contentStyle_0.FontName, null);
				method_29("FontSize", contentStyle_0.FontSize, 0f);
				method_29("Height", contentStyle_0.Height, 0f);
				method_35("Italic", contentStyle_0.Italic, bool_1: false);
				method_26("LayoutAlign", GClass21.smethod_4(contentStyle_0.LayoutAlign), "EmbedInText");
				method_29("LayoutGridHeight", contentStyle_0.LayoutGridHeight, 0f);
				method_29("Left", contentStyle_0.Left, 0f);
				method_29("LeftIndent", contentStyle_0.LeftIndent, 0f);
				method_29("LetterSpacing", contentStyle_0.LetterSpacing, 0f);
				method_29("LineSpacing", contentStyle_0.LineSpacing, 0f);
				method_26("LineSpacingStyle", GClass21.smethod_4(contentStyle_0.LineSpacingStyle), "SpaceSingle");
				method_29("MarginBottom", contentStyle_0.MarginBottom, 0f);
				method_29("MarginLeft", contentStyle_0.MarginLeft, 0f);
				method_29("MarginRight", contentStyle_0.MarginRight, 0f);
				method_29("MarginTop", contentStyle_0.MarginTop, 0f);
				method_35("Multiline", contentStyle_0.Multiline, bool_1: false);
				method_29("PaddingBottom", contentStyle_0.PaddingBottom, 0f);
				method_29("PaddingLeft", contentStyle_0.PaddingLeft, 0f);
				method_29("PaddingRight", contentStyle_0.PaddingRight, 0f);
				method_29("PaddingTop", contentStyle_0.PaddingTop, 0f);
				method_35("PageBreakAfter", contentStyle_0.PageBreakAfter, bool_1: false);
				method_35("PageBreakBefore", contentStyle_0.PageBreakBefore, bool_1: false);
				method_26("ParagraphListStyle", GClass21.smethod_4(contentStyle_0.ParagraphListStyle), "None");
				method_35("ParagraphMultiLevel", contentStyle_0.ParagraphMultiLevel, bool_1: false);
				method_27("ParagraphOutlineLevel", contentStyle_0.ParagraphOutlineLevel, -1);
				method_35("RightToLeft", contentStyle_0.RightToLeft, bool_1: false);
				method_29("Rotate", contentStyle_0.Rotate, 0f);
				method_29("RoundRadio", contentStyle_0.RoundRadio, 0f);
				method_29("RTFLineSpacing", contentStyle_0.RTFLineSpacing, 0f);
				method_29("Spacing", contentStyle_0.Spacing, 0f);
				method_29("SpacingAfterParagraph", contentStyle_0.SpacingAfterParagraph, 0f);
				method_29("SpacingBeforeParagraph", contentStyle_0.SpacingBeforeParagraph, 0f);
				method_35("Strikeout", contentStyle_0.Strikeout, bool_1: false);
				method_35("Subscript", contentStyle_0.Subscript, bool_1: false);
				method_35("Superscript", contentStyle_0.Superscript, bool_1: false);
				method_29("Top", contentStyle_0.Top, 0f);
				method_35("Underline", contentStyle_0.Underline, bool_1: false);
				method_35("VertialText", contentStyle_0.VertialText, bool_1: false);
				method_26("VerticalAlign", GClass21.smethod_4(contentStyle_0.VerticalAlign), "Top");
				method_26("Visibility", GClass21.smethod_4(contentStyle_0.Visibility), "All");
				method_35("Visible", contentStyle_0.Visible, bool_1: true);
				method_35("VisibleInDirectory", contentStyle_0.VisibleInDirectory, bool_1: true);
				method_29("Width", contentStyle_0.Width, 0f);
				method_29("Zoom", contentStyle_0.Zoom, 1f);
			}
		}

		private void method_65(ContentStyleList contentStyleList_0)
		{
			int num = 8;
			if (contentStyleList_0 != null)
			{
				method_3("ContentStyleList");
				method_66(contentStyleList_0);
				method_48();
			}
		}

		private void method_66(ContentStyleList contentStyleList_0)
		{
			int num = 6;
			if (contentStyleList_0 != null)
			{
				foreach (ContentStyle item in contentStyleList_0)
				{
					if (item != null)
					{
						method_3("ContentStyle");
						method_64(item);
						method_48();
					}
					if (item is PageBorderBackgroundStyle)
					{
						method_3("PageBorderBackgroundStyle");
						method_70((PageBorderBackgroundStyle)item);
						method_48();
					}
					if (item is DocumentContentStyle)
					{
						method_3("DocumentContentStyle");
						method_200((DocumentContentStyle)item);
						method_48();
					}
				}
			}
		}

		private void method_67(DocumentTerminalTextInfo documentTerminalTextInfo_0)
		{
			int num = 17;
			if (documentTerminalTextInfo_0 != null)
			{
				method_3("DocumentTerminalTextInfo");
				method_68(documentTerminalTextInfo_0);
				method_48();
			}
		}

		private void method_68(DocumentTerminalTextInfo documentTerminalTextInfo_0)
		{
			int num = 11;
			if (documentTerminalTextInfo_0 != null)
			{
				method_26("ColorValue", documentTerminalTextInfo_0.ColorValue, null);
				if (documentTerminalTextInfo_0.Font != null)
				{
					method_3("Font");
					method_74(documentTerminalTextInfo_0.Font);
					method_48();
				}
				method_29("MinHeightInCMUnit", documentTerminalTextInfo_0.MinHeightInCMUnit, 2f);
				method_26("Text", documentTerminalTextInfo_0.Text, null);
			}
		}

		private void method_69(PageBorderBackgroundStyle pageBorderBackgroundStyle_0)
		{
			int num = 11;
			if (pageBorderBackgroundStyle_0 != null)
			{
				method_3("PageBorderBackgroundStyle");
				method_70(pageBorderBackgroundStyle_0);
				method_48();
			}
		}

		private void method_70(PageBorderBackgroundStyle pageBorderBackgroundStyle_0)
		{
			int num = 18;
			if (pageBorderBackgroundStyle_0 != null)
			{
				method_7("Index", pageBorderBackgroundStyle_0.Index, -1);
				method_26("Align", GClass21.smethod_4(pageBorderBackgroundStyle_0.Align), "Left");
				method_26("BackgroundColor2", pageBorderBackgroundStyle_0.BackgroundColor2String, "Black");
				method_26("BackgroundColor", pageBorderBackgroundStyle_0.BackgroundColorString, "Transparent");
				if (pageBorderBackgroundStyle_0.BackgroundImage != null)
				{
					method_3("BackgroundImage");
					method_76(pageBorderBackgroundStyle_0.BackgroundImage);
					method_48();
				}
				method_26("BackgroundPosition", GClass21.smethod_4(pageBorderBackgroundStyle_0.BackgroundPosition), "TopLeft");
				method_29("BackgroundPositionX", pageBorderBackgroundStyle_0.BackgroundPositionX, 0f);
				method_29("BackgroundPositionY", pageBorderBackgroundStyle_0.BackgroundPositionY, 0f);
				method_35("BackgroundRepeat", pageBorderBackgroundStyle_0.BackgroundRepeat, bool_1: false);
				method_26("BackgroundStyle", GClass21.smethod_4(pageBorderBackgroundStyle_0.BackgroundStyle), "Solid");
				method_35("Bold", pageBorderBackgroundStyle_0.Bold, bool_1: false);
				method_35("BorderBottom", pageBorderBackgroundStyle_0.BorderBottom, bool_1: false);
				method_26("BorderBottomColor", pageBorderBackgroundStyle_0.BorderBottomColorString, "Black");
				method_35("BorderLeft", pageBorderBackgroundStyle_0.BorderLeft, bool_1: false);
				method_26("BorderLeftColor", pageBorderBackgroundStyle_0.BorderLeftColorString, "Black");
				method_26("BorderRange", GClass21.smethod_4(pageBorderBackgroundStyle_0.BorderRange), "None");
				method_35("BorderRight", pageBorderBackgroundStyle_0.BorderRight, bool_1: false);
				method_26("BorderRightColor", pageBorderBackgroundStyle_0.BorderRightColorString, "Black");
				method_29("BorderSpacing", pageBorderBackgroundStyle_0.BorderSpacing, 0f);
				method_26("BorderStyle", GClass21.smethod_4(pageBorderBackgroundStyle_0.BorderStyle), "Solid");
				method_35("BorderTop", pageBorderBackgroundStyle_0.BorderTop, bool_1: false);
				method_26("BorderTopColor", pageBorderBackgroundStyle_0.BorderTopColorString, "Black");
				method_29("BorderWidth", pageBorderBackgroundStyle_0.BorderWidth, 0f);
				method_26("CharacterCircle", GClass21.smethod_4(pageBorderBackgroundStyle_0.CharacterCircle), "None");
				method_26("Color", pageBorderBackgroundStyle_0.ColorString, "Black");
				method_26("DefaultValuePropertyNames", pageBorderBackgroundStyle_0.DefaultValuePropertyNames, null);
				method_29("FirstLineIndent", pageBorderBackgroundStyle_0.FirstLineIndent, 0f);
				method_35("FixedSpacing", pageBorderBackgroundStyle_0.FixedSpacing, bool_1: false);
				method_26("FontName", pageBorderBackgroundStyle_0.FontName, null);
				method_29("FontSize", pageBorderBackgroundStyle_0.FontSize, 0f);
				method_29("Height", pageBorderBackgroundStyle_0.Height, 0f);
				method_35("Italic", pageBorderBackgroundStyle_0.Italic, bool_1: false);
				method_26("LayoutAlign", GClass21.smethod_4(pageBorderBackgroundStyle_0.LayoutAlign), "EmbedInText");
				method_29("LayoutGridHeight", pageBorderBackgroundStyle_0.LayoutGridHeight, 0f);
				method_29("Left", pageBorderBackgroundStyle_0.Left, 0f);
				method_29("LeftIndent", pageBorderBackgroundStyle_0.LeftIndent, 0f);
				method_29("LetterSpacing", pageBorderBackgroundStyle_0.LetterSpacing, 0f);
				method_29("LineSpacing", pageBorderBackgroundStyle_0.LineSpacing, 0f);
				method_26("LineSpacingStyle", GClass21.smethod_4(pageBorderBackgroundStyle_0.LineSpacingStyle), "SpaceSingle");
				method_29("MarginBottom", pageBorderBackgroundStyle_0.MarginBottom, 0f);
				method_29("MarginLeft", pageBorderBackgroundStyle_0.MarginLeft, 0f);
				method_29("MarginRight", pageBorderBackgroundStyle_0.MarginRight, 0f);
				method_29("MarginTop", pageBorderBackgroundStyle_0.MarginTop, 0f);
				method_35("Multiline", pageBorderBackgroundStyle_0.Multiline, bool_1: false);
				method_29("PaddingBottom", pageBorderBackgroundStyle_0.PaddingBottom, 0f);
				method_29("PaddingLeft", pageBorderBackgroundStyle_0.PaddingLeft, 0f);
				method_29("PaddingRight", pageBorderBackgroundStyle_0.PaddingRight, 0f);
				method_29("PaddingTop", pageBorderBackgroundStyle_0.PaddingTop, 0f);
				method_35("PageBreakAfter", pageBorderBackgroundStyle_0.PageBreakAfter, bool_1: false);
				method_35("PageBreakBefore", pageBorderBackgroundStyle_0.PageBreakBefore, bool_1: false);
				method_26("ParagraphListStyle", GClass21.smethod_4(pageBorderBackgroundStyle_0.ParagraphListStyle), "None");
				method_35("ParagraphMultiLevel", pageBorderBackgroundStyle_0.ParagraphMultiLevel, bool_1: false);
				method_27("ParagraphOutlineLevel", pageBorderBackgroundStyle_0.ParagraphOutlineLevel, -1);
				method_35("RightToLeft", pageBorderBackgroundStyle_0.RightToLeft, bool_1: false);
				method_29("Rotate", pageBorderBackgroundStyle_0.Rotate, 0f);
				method_29("RoundRadio", pageBorderBackgroundStyle_0.RoundRadio, 0f);
				method_29("RTFLineSpacing", pageBorderBackgroundStyle_0.RTFLineSpacing, 0f);
				method_29("Spacing", pageBorderBackgroundStyle_0.Spacing, 0f);
				method_29("SpacingAfterParagraph", pageBorderBackgroundStyle_0.SpacingAfterParagraph, 0f);
				method_29("SpacingBeforeParagraph", pageBorderBackgroundStyle_0.SpacingBeforeParagraph, 0f);
				method_35("Strikeout", pageBorderBackgroundStyle_0.Strikeout, bool_1: false);
				method_35("Subscript", pageBorderBackgroundStyle_0.Subscript, bool_1: false);
				method_35("Superscript", pageBorderBackgroundStyle_0.Superscript, bool_1: false);
				method_29("Top", pageBorderBackgroundStyle_0.Top, 0f);
				method_35("Underline", pageBorderBackgroundStyle_0.Underline, bool_1: false);
				method_35("VertialText", pageBorderBackgroundStyle_0.VertialText, bool_1: false);
				method_26("VerticalAlign", GClass21.smethod_4(pageBorderBackgroundStyle_0.VerticalAlign), "Top");
				method_26("Visibility", GClass21.smethod_4(pageBorderBackgroundStyle_0.Visibility), "All");
				method_35("Visible", pageBorderBackgroundStyle_0.Visible, bool_1: true);
				method_35("VisibleInDirectory", pageBorderBackgroundStyle_0.VisibleInDirectory, bool_1: true);
				method_29("Width", pageBorderBackgroundStyle_0.Width, 0f);
				method_29("Zoom", pageBorderBackgroundStyle_0.Zoom, 1f);
			}
		}

		private void method_71(WatermarkInfo watermarkInfo_0)
		{
			int num = 4;
			if (watermarkInfo_0 != null)
			{
				method_3("WatermarkInfo");
				method_72(watermarkInfo_0);
				method_48();
			}
		}

		private void method_72(WatermarkInfo watermarkInfo_0)
		{
			int num = 4;
			if (watermarkInfo_0 != null)
			{
				method_27("Alpha", watermarkInfo_0.Alpha, 80);
				method_29("Angle", watermarkInfo_0.Angle, 0f);
				method_26("BackColorValue", watermarkInfo_0.BackColorValue, "white");
				method_26("ColorValue", watermarkInfo_0.ColorValue, "black");
				if (watermarkInfo_0.Font != null)
				{
					method_3("Font");
					method_74(watermarkInfo_0.Font);
					method_48();
				}
				if (watermarkInfo_0.Image != null)
				{
					method_3("Image");
					method_76(watermarkInfo_0.Image);
					method_48();
				}
				method_35("PrintWatermark", watermarkInfo_0.PrintWatermark, bool_1: true);
				method_35("Repeat", watermarkInfo_0.Repeat, bool_1: false);
				method_35("ShowWatermark", watermarkInfo_0.ShowWatermark, bool_1: true);
				method_26("Text", watermarkInfo_0.Text, null);
				method_26("Type", GClass21.smethod_4(watermarkInfo_0.Type), "None");
			}
		}

		private void method_73(XFontValue xfontValue_0)
		{
			int num = 2;
			if (xfontValue_0 != null)
			{
				method_3("XFontValue");
				method_74(xfontValue_0);
				method_48();
			}
		}

		private void method_74(XFontValue xfontValue_0)
		{
			int num = 9;
			if (xfontValue_0 != null)
			{
				method_35("Bold", xfontValue_0.Bold, bool_1: false);
				method_35("Italic", xfontValue_0.Italic, bool_1: false);
				method_26("Name", xfontValue_0.Name, "宋体");
				method_29("Size", xfontValue_0.Size, 9f);
				method_35("Strikeout", xfontValue_0.Strikeout, bool_1: false);
				method_35("Underline", xfontValue_0.Underline, bool_1: false);
				method_26("Unit", GClass21.smethod_4(xfontValue_0.Unit), "Point");
			}
		}

		private void method_75(XImageValue ximageValue_0)
		{
			int num = 7;
			if (ximageValue_0 != null)
			{
				method_3("XImageValue");
				method_76(ximageValue_0);
				method_48();
			}
		}

		private void method_76(XImageValue ximageValue_0)
		{
			int num = 18;
			if (ximageValue_0 != null)
			{
				method_29("HorizontalResolution", ximageValue_0.HorizontalResolution, 0f);
				method_26("ImageDataBase64String", ximageValue_0.ImageDataBase64String, null);
				method_29("VerticalResolution", ximageValue_0.VerticalResolution, 0f);
			}
		}

		private void method_77(DCGridLineInfo dcgridLineInfo_0)
		{
			int num = 12;
			if (dcgridLineInfo_0 != null)
			{
				method_3("DCGridLineInfo");
				method_78(dcgridLineInfo_0);
				method_48();
			}
		}

		private void method_78(DCGridLineInfo dcgridLineInfo_0)
		{
			int num = 6;
			if (dcgridLineInfo_0 != null)
			{
				method_35("AlignToGridLine", dcgridLineInfo_0.AlignToGridLine, bool_1: true);
				method_26("ColorValue", dcgridLineInfo_0.ColorValue, null);
				method_27("GridNumInOnePage", dcgridLineInfo_0.GridNumInOnePage, 0);
				method_29("GridSpanInCM", dcgridLineInfo_0.GridSpanInCM, 0f);
				method_26("LineStyle", GClass21.smethod_4(dcgridLineInfo_0.LineStyle), "Solid");
				method_29("LineWidth", dcgridLineInfo_0.LineWidth, 1f);
				method_35("Printable", dcgridLineInfo_0.Printable, bool_1: true);
				method_35("Visible", dcgridLineInfo_0.Visible, bool_1: false);
			}
		}

		private void method_79(JumpPrintInfo jumpPrintInfo_0)
		{
			int num = 12;
			if (jumpPrintInfo_0 != null)
			{
				method_3("JumpPrintInfo");
				method_80(jumpPrintInfo_0);
				method_48();
			}
		}

		private void method_80(JumpPrintInfo jumpPrintInfo_0)
		{
			int num = 6;
			if (jumpPrintInfo_0 != null)
			{
				method_29("AbsPosition", jumpPrintInfo_0.AbsPosition, 0f);
				method_35("Enabled", jumpPrintInfo_0.Enabled, bool_1: false);
				method_27("EndPageIndex", jumpPrintInfo_0.EndPageIndex, -1);
				method_29("EndPosition", jumpPrintInfo_0.EndPosition, 0f);
				method_26("Mode", GClass21.smethod_4(jumpPrintInfo_0.Mode), "Disable");
				method_29("NativeEndPosition", jumpPrintInfo_0.NativeEndPosition, 0f);
				method_29("NativePosition", jumpPrintInfo_0.NativePosition, 0f);
				method_27("PageIndex", jumpPrintInfo_0.PageIndex, -1);
				method_29("Position", jumpPrintInfo_0.Position, 0f);
			}
		}

		private void method_81(XPageSettings xpageSettings_0)
		{
			int num = 4;
			if (xpageSettings_0 != null)
			{
				method_3("XPageSettings");
				method_82(xpageSettings_0);
				method_48();
			}
		}

		private void method_82(XPageSettings xpageSettings_0)
		{
			int num = 7;
			if (xpageSettings_0 != null)
			{
				method_35("AutoChoosePageSize", xpageSettings_0.AutoChoosePageSize, bool_1: true);
				method_35("AutoFitPageSize", xpageSettings_0.AutoFitPageSize, bool_1: false);
				method_35("AutoPaperWidth", xpageSettings_0.AutoPaperWidth, bool_1: false);
				method_27("BottomMargin", xpageSettings_0.BottomMargin, 100);
				method_27("Copies", xpageSettings_0.Copies, 1);
				method_27("DesignerPaperHeight", xpageSettings_0.DesignerPaperHeight, 0);
				method_27("DesignerPaperWidth", xpageSettings_0.DesignerPaperWidth, 0);
				if (xpageSettings_0.DocumentGridLine != null)
				{
					method_3("DocumentGridLine");
					method_78(xpageSettings_0.DocumentGridLine);
					method_48();
				}
				if (xpageSettings_0.EditTimeBackgroundImage != null)
				{
					method_3("EditTimeBackgroundImage");
					method_76(xpageSettings_0.EditTimeBackgroundImage);
					method_48();
				}
				method_27("FooterDistance", xpageSettings_0.FooterDistance, 50);
				method_35("ForPOSPrinter", xpageSettings_0.ForPOSPrinter, bool_1: false);
				method_27("HeaderDistance", xpageSettings_0.HeaderDistance, 50);
				method_35("Landscape", xpageSettings_0.Landscape, bool_1: false);
				method_27("LeftMargin", xpageSettings_0.LeftMargin, 100);
				method_30("OffsetX", xpageSettings_0.OffsetX);
				method_30("OffsetY", xpageSettings_0.OffsetY);
				if (xpageSettings_0.PageBorderBackground != null)
				{
					method_3("PageBorderBackground");
					method_70(xpageSettings_0.PageBorderBackground);
					method_48();
				}
				method_26("PageIndexsForHideHeaderFooter", xpageSettings_0.PageIndexsForHideHeaderFooter, null);
				method_27("PaperHeight", xpageSettings_0.PaperHeight, 1169);
				method_26("PaperKind", GClass21.smethod_4(xpageSettings_0.PaperKind), "A4");
				method_26("PaperSource", xpageSettings_0.PaperSource, null);
				method_27("PaperWidth", xpageSettings_0.PaperWidth, 827);
				method_26("PrinterName", xpageSettings_0.PrinterName, null);
				method_27("RightMargin", xpageSettings_0.RightMargin, 100);
				method_26("SpecifyDuplex", GClass21.smethod_4(xpageSettings_0.SpecifyDuplex), "NoSpecify");
				method_35("SwapLeftRightMargin", xpageSettings_0.SwapLeftRightMargin, bool_1: false);
				if (xpageSettings_0.TerminalText != null)
				{
					method_3("TerminalText");
					method_68(xpageSettings_0.TerminalText);
					method_48();
				}
				method_27("TopMargin", xpageSettings_0.TopMargin, 100);
				if (xpageSettings_0.Watermark != null)
				{
					method_3("Watermark");
					method_72(xpageSettings_0.Watermark);
					method_48();
				}
			}
		}

		private void method_83(ShapeContentStyleContainer shapeContentStyleContainer_0)
		{
			int num = 18;
			if (shapeContentStyleContainer_0 != null)
			{
				method_3("ShapeContentStyleContainer");
				method_84(shapeContentStyleContainer_0);
				method_48();
			}
		}

		private void method_84(ShapeContentStyleContainer shapeContentStyleContainer_0)
		{
			int num = 8;
			if (shapeContentStyleContainer_0 != null)
			{
				if (shapeContentStyleContainer_0.Default != null)
				{
					method_3("Default");
					method_64(shapeContentStyleContainer_0.Default);
					method_48();
				}
				if (shapeContentStyleContainer_0.Styles != null && shapeContentStyleContainer_0.Styles.Count > 0)
				{
					method_3("Styles");
					foreach (ContentStyle style in shapeContentStyleContainer_0.Styles)
					{
						method_3("Style");
						method_64(style);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_85(ShapeDocument shapeDocument_0)
		{
			int num = 8;
			if (shapeDocument_0 != null)
			{
				method_3("ShapeDocument");
				method_86(shapeDocument_0);
				method_48();
			}
		}

		private void method_86(ShapeDocument shapeDocument_0)
		{
			int num = 5;
			if (shapeDocument_0 != null)
			{
				method_7("StyleIndex", shapeDocument_0.StyleIndex, -1);
				method_35("AutoZoomFontSize", shapeDocument_0.AutoZoomFontSize, bool_1: true);
				if (shapeDocument_0.ContentStyles != null)
				{
					method_3("ContentStyles");
					method_84(shapeDocument_0.ContentStyles);
					method_48();
				}
				if (shapeDocument_0.DefaultFont != null)
				{
					method_3("DefaultFont");
					method_74(shapeDocument_0.DefaultFont);
					method_48();
				}
				method_26("DocumentGraphicsUnit", GClass21.smethod_4(shapeDocument_0.DocumentGraphicsUnit), "Document");
				method_35("EditMode", shapeDocument_0.EditMode, bool_1: true);
				method_29("Height", shapeDocument_0.Height, 100f);
				method_26("ID", shapeDocument_0.ID, null);
				method_29("Left", shapeDocument_0.Left, 0f);
				method_35("LocalElementStyleMode", shapeDocument_0.LocalElementStyleMode, bool_1: false);
				if (shapeDocument_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeDocument_0.LocalStyle);
					method_48();
				}
				method_35("Resizeable", shapeDocument_0.Resizeable, bool_1: true);
				method_26("Text", shapeDocument_0.Text, null);
				method_26("TextBackColorString", shapeDocument_0.TextBackColorString, null);
				method_29("Top", shapeDocument_0.Top, 0f);
				method_35("Visible", shapeDocument_0.Visible, bool_1: true);
				method_29("Width", shapeDocument_0.Width, 100f);
				if (shapeDocument_0.Elements != null && shapeDocument_0.Elements.Count > 0)
				{
					method_3("Elements");
					method_92(shapeDocument_0.Elements);
					method_48();
				}
			}
		}

		private void method_87(ShapeDocumentImagePage shapeDocumentImagePage_0)
		{
			int num = 4;
			if (shapeDocumentImagePage_0 != null)
			{
				method_3("ShapeDocumentImagePage");
				method_88(shapeDocumentImagePage_0);
				method_48();
			}
		}

		private void method_88(ShapeDocumentImagePage shapeDocumentImagePage_0)
		{
			int num = 7;
			if (shapeDocumentImagePage_0 != null)
			{
				method_7("StyleIndex", shapeDocumentImagePage_0.StyleIndex, -1);
				method_35("AutoSize", shapeDocumentImagePage_0.AutoSize, bool_1: true);
				method_29("Height", shapeDocumentImagePage_0.Height, 100f);
				method_26("ID", shapeDocumentImagePage_0.ID, null);
				if (shapeDocumentImagePage_0.Image != null)
				{
					method_3("Image");
					method_76(shapeDocumentImagePage_0.Image);
					method_48();
				}
				method_29("Left", shapeDocumentImagePage_0.Left, 0f);
				if (shapeDocumentImagePage_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeDocumentImagePage_0.LocalStyle);
					method_48();
				}
				method_26("Text", shapeDocumentImagePage_0.Text, null);
				method_29("Top", shapeDocumentImagePage_0.Top, 0f);
				method_35("Visible", shapeDocumentImagePage_0.Visible, bool_1: true);
				method_29("Width", shapeDocumentImagePage_0.Width, 100f);
				if (shapeDocumentImagePage_0.Elements != null && shapeDocumentImagePage_0.Elements.Count > 0)
				{
					method_3("Elements");
					method_92(shapeDocumentImagePage_0.Elements);
					method_48();
				}
			}
		}

		private void method_89(ShapeElement shapeElement_0)
		{
			int num = 8;
			if (shapeElement_0 != null)
			{
				method_3("ShapeElement");
				method_90(shapeElement_0);
				method_48();
			}
		}

		private void method_90(ShapeElement shapeElement_0)
		{
			int num = 7;
			if (shapeElement_0 != null)
			{
				method_7("StyleIndex", shapeElement_0.StyleIndex, -1);
				method_26("ID", shapeElement_0.ID, null);
				if (shapeElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeElement_0.LocalStyle);
					method_48();
				}
				method_35("Visible", shapeElement_0.Visible, bool_1: true);
			}
		}

		private void method_91(ShapeElementList shapeElementList_0)
		{
			int num = 18;
			if (shapeElementList_0 != null)
			{
				method_3("ShapeElementList");
				method_92(shapeElementList_0);
				method_48();
			}
		}

		private void method_92(ShapeElementList shapeElementList_0)
		{
			int num = 10;
			if (shapeElementList_0 != null)
			{
				foreach (ShapeElement item in shapeElementList_0)
				{
					if (item != null)
					{
						method_3("ShapeElement");
						method_90(item);
						method_48();
					}
					if (item is ShapeDocument)
					{
						method_3("ShapeDocument");
						method_86((ShapeDocument)item);
						method_48();
					}
					if (item is ShapeDocumentImagePage)
					{
						method_3("ShapeDocumentImagePage");
						method_88((ShapeDocumentImagePage)item);
						method_48();
					}
					if (item is ShapeEllipseElement)
					{
						method_3("ShapeEllipseElement");
						method_94((ShapeEllipseElement)item);
						method_48();
					}
					if (item is ShapeLineElement)
					{
						method_3("ShapeLineElement");
						method_96((ShapeLineElement)item);
						method_48();
					}
					if (item is ShapeLinesElement)
					{
						method_3("ShapeLinesElement");
						method_98((ShapeLinesElement)item);
						method_48();
					}
					if (item is ShapePolygonElement)
					{
						method_3("ShapePolygonElement");
						method_100((ShapePolygonElement)item);
						method_48();
					}
					if (item is ShapeRectangleElement)
					{
						method_3("ShapeRectangleElement");
						method_102((ShapeRectangleElement)item);
						method_48();
					}
					if (item is ShapeWireLabelElement)
					{
						method_3("ShapeWireLabelElement");
						method_104((ShapeWireLabelElement)item);
						method_48();
					}
					if (item is ShapeZoomInElement)
					{
						method_3("ShapeZoomInElement");
						method_106((ShapeZoomInElement)item);
						method_48();
					}
				}
			}
		}

		private void method_93(ShapeEllipseElement shapeEllipseElement_0)
		{
			int num = 9;
			if (shapeEllipseElement_0 != null)
			{
				method_3("ShapeEllipseElement");
				method_94(shapeEllipseElement_0);
				method_48();
			}
		}

		private void method_94(ShapeEllipseElement shapeEllipseElement_0)
		{
			int num = 6;
			if (shapeEllipseElement_0 != null)
			{
				method_7("StyleIndex", shapeEllipseElement_0.StyleIndex, -1);
				method_29("Height", shapeEllipseElement_0.Height, 100f);
				method_26("ID", shapeEllipseElement_0.ID, null);
				method_29("Left", shapeEllipseElement_0.Left, 0f);
				if (shapeEllipseElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeEllipseElement_0.LocalStyle);
					method_48();
				}
				method_35("Resizeable", shapeEllipseElement_0.Resizeable, bool_1: true);
				method_26("Text", shapeEllipseElement_0.Text, null);
				method_29("Top", shapeEllipseElement_0.Top, 0f);
				method_35("Visible", shapeEllipseElement_0.Visible, bool_1: true);
				method_29("Width", shapeEllipseElement_0.Width, 100f);
			}
		}

		private void method_95(ShapeLineElement shapeLineElement_0)
		{
			int num = 2;
			if (shapeLineElement_0 != null)
			{
				method_3("ShapeLineElement");
				method_96(shapeLineElement_0);
				method_48();
			}
		}

		private void method_96(ShapeLineElement shapeLineElement_0)
		{
			int num = 11;
			if (shapeLineElement_0 != null)
			{
				method_7("StyleIndex", shapeLineElement_0.StyleIndex, -1);
				method_26("ID", shapeLineElement_0.ID, null);
				if (shapeLineElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeLineElement_0.LocalStyle);
					method_48();
				}
				method_35("Visible", shapeLineElement_0.Visible, bool_1: true);
				method_29("X1", shapeLineElement_0.X1, 0f);
				method_29("X2", shapeLineElement_0.X2, 0f);
				method_29("Y1", shapeLineElement_0.Y1, 0f);
				method_29("Y2", shapeLineElement_0.Y2, 0f);
			}
		}

		private void method_97(ShapeLinesElement shapeLinesElement_0)
		{
			int num = 8;
			if (shapeLinesElement_0 != null)
			{
				method_3("ShapeLinesElement");
				method_98(shapeLinesElement_0);
				method_48();
			}
		}

		private void method_98(ShapeLinesElement shapeLinesElement_0)
		{
			int num = 1;
			if (shapeLinesElement_0 != null)
			{
				method_7("StyleIndex", shapeLinesElement_0.StyleIndex, -1);
				method_26("ID", shapeLinesElement_0.ID, null);
				if (shapeLinesElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeLinesElement_0.LocalStyle);
					method_48();
				}
				method_25("Points", shapeLinesElement_0.PointsString);
				method_35("Visible", shapeLinesElement_0.Visible, bool_1: true);
			}
		}

		private void method_99(ShapePolygonElement shapePolygonElement_0)
		{
			int num = 9;
			if (shapePolygonElement_0 != null)
			{
				method_3("ShapePolygonElement");
				method_100(shapePolygonElement_0);
				method_48();
			}
		}

		private void method_100(ShapePolygonElement shapePolygonElement_0)
		{
			int num = 2;
			if (shapePolygonElement_0 != null)
			{
				method_7("StyleIndex", shapePolygonElement_0.StyleIndex, -1);
				method_29("Height", shapePolygonElement_0.Height, 100f);
				method_26("ID", shapePolygonElement_0.ID, null);
				method_29("Left", shapePolygonElement_0.Left, 0f);
				if (shapePolygonElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapePolygonElement_0.LocalStyle);
					method_48();
				}
				method_25("Points", shapePolygonElement_0.PointsString);
				method_35("Resizeable", shapePolygonElement_0.Resizeable, bool_1: true);
				method_26("Text", shapePolygonElement_0.Text, null);
				method_29("Top", shapePolygonElement_0.Top, 0f);
				method_35("Visible", shapePolygonElement_0.Visible, bool_1: true);
				method_29("Width", shapePolygonElement_0.Width, 100f);
			}
		}

		private void method_101(ShapeRectangleElement shapeRectangleElement_0)
		{
			int num = 17;
			if (shapeRectangleElement_0 != null)
			{
				method_3("ShapeRectangleElement");
				method_102(shapeRectangleElement_0);
				method_48();
			}
		}

		private void method_102(ShapeRectangleElement shapeRectangleElement_0)
		{
			int num = 1;
			if (shapeRectangleElement_0 != null)
			{
				method_7("StyleIndex", shapeRectangleElement_0.StyleIndex, -1);
				method_29("Height", shapeRectangleElement_0.Height, 100f);
				method_26("ID", shapeRectangleElement_0.ID, null);
				method_29("Left", shapeRectangleElement_0.Left, 0f);
				if (shapeRectangleElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeRectangleElement_0.LocalStyle);
					method_48();
				}
				method_35("Resizeable", shapeRectangleElement_0.Resizeable, bool_1: true);
				method_26("Text", shapeRectangleElement_0.Text, null);
				method_29("Top", shapeRectangleElement_0.Top, 0f);
				method_35("Visible", shapeRectangleElement_0.Visible, bool_1: true);
				method_29("Width", shapeRectangleElement_0.Width, 100f);
			}
		}

		private void method_103(ShapeWireLabelElement shapeWireLabelElement_0)
		{
			int num = 13;
			if (shapeWireLabelElement_0 != null)
			{
				method_3("ShapeWireLabelElement");
				method_104(shapeWireLabelElement_0);
				method_48();
			}
		}

		private void method_104(ShapeWireLabelElement shapeWireLabelElement_0)
		{
			int num = 19;
			if (shapeWireLabelElement_0 != null)
			{
				method_7("StyleIndex", shapeWireLabelElement_0.StyleIndex, -1);
				method_26("ID", shapeWireLabelElement_0.ID, null);
				method_35("LabelAtLeft", shapeWireLabelElement_0.LabelAtLeft, bool_1: false);
				method_35("LabelAtUp", shapeWireLabelElement_0.LabelAtUp, bool_1: false);
				if (shapeWireLabelElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeWireLabelElement_0.LocalStyle);
					method_48();
				}
				method_26("Text", shapeWireLabelElement_0.Text, null);
				method_35("Visible", shapeWireLabelElement_0.Visible, bool_1: true);
				method_29("X1", shapeWireLabelElement_0.X1, 0f);
				method_29("X2", shapeWireLabelElement_0.X2, 0f);
				method_29("Y1", shapeWireLabelElement_0.Y1, 0f);
				method_29("Y2", shapeWireLabelElement_0.Y2, 0f);
			}
		}

		private void method_105(ShapeZoomInElement shapeZoomInElement_0)
		{
			int num = 6;
			if (shapeZoomInElement_0 != null)
			{
				method_3("ShapeZoomInElement");
				method_106(shapeZoomInElement_0);
				method_48();
			}
		}

		private void method_106(ShapeZoomInElement shapeZoomInElement_0)
		{
			int num = 10;
			if (shapeZoomInElement_0 != null)
			{
				method_7("StyleIndex", shapeZoomInElement_0.StyleIndex, -1);
				method_29("Height", shapeZoomInElement_0.Height, 100f);
				method_26("ID", shapeZoomInElement_0.ID, null);
				method_29("Left", shapeZoomInElement_0.Left, 0f);
				if (shapeZoomInElement_0.LocalStyle != null)
				{
					method_3("LocalStyle");
					method_64(shapeZoomInElement_0.LocalStyle);
					method_48();
				}
				method_35("Resizeable", shapeZoomInElement_0.Resizeable, bool_1: true);
				method_35("SmoothZoomIn", shapeZoomInElement_0.SmoothZoomIn, bool_1: false);
				method_26("Text", shapeZoomInElement_0.Text, null);
				method_29("Top", shapeZoomInElement_0.Top, 0f);
				method_35("Visible", shapeZoomInElement_0.Visible, bool_1: true);
				method_29("Width", shapeZoomInElement_0.Width, 100f);
				method_29("ZoomInRate", shapeZoomInElement_0.ZoomInRate, 2f);
			}
		}

		private void method_107(DCTimeLineImage dctimeLineImage_0)
		{
			int num = 11;
			if (dctimeLineImage_0 != null)
			{
				method_3("DCTimeLineImage");
				method_108(dctimeLineImage_0);
				method_48();
			}
		}

		private void method_108(DCTimeLineImage dctimeLineImage_0)
		{
			int num = 14;
			if (dctimeLineImage_0 != null)
			{
				method_9("Left", dctimeLineImage_0.Left, 0f);
				method_6("Name", dctimeLineImage_0.Name, null);
				method_9("Top", dctimeLineImage_0.Top, 0f);
				if (dctimeLineImage_0.Image != null)
				{
					method_3("Image");
					method_76(dctimeLineImage_0.Image);
					method_48();
				}
			}
		}

		private void method_109(DCTimeLineImageList dctimeLineImageList_0)
		{
			int num = 5;
			if (dctimeLineImageList_0 != null)
			{
				method_3("DCTimeLineImageList");
				method_110(dctimeLineImageList_0);
				method_48();
			}
		}

		private void method_110(DCTimeLineImageList dctimeLineImageList_0)
		{
			int num = 4;
			if (dctimeLineImageList_0 != null)
			{
				foreach (DCTimeLineImage item in dctimeLineImageList_0)
				{
					method_3("DCTimeLineImage");
					method_108(item);
					method_48();
				}
			}
		}

		private void method_111(DCTimeLineLabel dctimeLineLabel_0)
		{
			int num = 12;
			if (dctimeLineLabel_0 != null)
			{
				method_3("DCTimeLineLabel");
				method_112(dctimeLineLabel_0);
				method_48();
			}
		}

		private void method_112(DCTimeLineLabel dctimeLineLabel_0)
		{
			int num = 1;
			if (dctimeLineLabel_0 != null)
			{
				method_6("Alignment", GClass21.smethod_4(dctimeLineLabel_0.Alignment), "Center");
				method_6("BackColorValue", dctimeLineLabel_0.BackColorValue, null);
				method_6("ColorValue", dctimeLineLabel_0.ColorValue, null);
				method_9("Height", dctimeLineLabel_0.Height, 100f);
				method_9("Left", dctimeLineLabel_0.Left, 0f);
				method_6("LineAlignment", GClass21.smethod_4(dctimeLineLabel_0.LineAlignment), "Center");
				method_15("MultiLine", dctimeLineLabel_0.MultiLine, bool_1: false);
				method_6("ParameterName", dctimeLineLabel_0.ParameterName, null);
				method_6("Text", dctimeLineLabel_0.Text, null);
				method_9("Top", dctimeLineLabel_0.Top, 0f);
				method_9("Width", dctimeLineLabel_0.Width, 100f);
				if (dctimeLineLabel_0.Font != null)
				{
					method_3("Font");
					method_74(dctimeLineLabel_0.Font);
					method_48();
				}
				if (dctimeLineLabel_0.Image != null)
				{
					method_3("Image");
					method_76(dctimeLineLabel_0.Image);
					method_48();
				}
			}
		}

		private void method_113(DCTimeLineLabelList dctimeLineLabelList_0)
		{
			int num = 4;
			if (dctimeLineLabelList_0 != null)
			{
				method_3("DCTimeLineLabelList");
				method_114(dctimeLineLabelList_0);
				method_48();
			}
		}

		private void method_114(DCTimeLineLabelList dctimeLineLabelList_0)
		{
			int num = 1;
			if (dctimeLineLabelList_0 != null)
			{
				foreach (DCTimeLineLabel item in dctimeLineLabelList_0)
				{
					method_3("DCTimeLineLabel");
					method_112(item);
					method_48();
				}
			}
		}

		private void method_115(DCTimeLineParameter dctimeLineParameter_0)
		{
			int num = 10;
			if (dctimeLineParameter_0 != null)
			{
				method_3("DCTimeLineParameter");
				method_116(dctimeLineParameter_0);
				method_48();
			}
		}

		private void method_116(DCTimeLineParameter dctimeLineParameter_0)
		{
			int num = 19;
			if (dctimeLineParameter_0 != null)
			{
				method_6("Name", dctimeLineParameter_0.Name, null);
				method_52(dctimeLineParameter_0.Value);
			}
		}

		private void method_117(DCTimeLineParameterList dctimeLineParameterList_0)
		{
			int num = 11;
			if (dctimeLineParameterList_0 != null)
			{
				method_3("DCTimeLineParameterList");
				method_118(dctimeLineParameterList_0);
				method_48();
			}
		}

		private void method_118(DCTimeLineParameterList dctimeLineParameterList_0)
		{
			int num = 10;
			if (dctimeLineParameterList_0 != null)
			{
				foreach (DCTimeLineParameter item in dctimeLineParameterList_0)
				{
					method_3("DCTimeLineParameter");
					method_116(item);
					method_48();
				}
			}
		}

		private void method_119(DocumentData documentData_0)
		{
			int num = 18;
			if (documentData_0 != null)
			{
				method_3("DocumentData");
				method_120(documentData_0);
				method_48();
			}
		}

		private void method_120(DocumentData documentData_0)
		{
			int num = 3;
			if (documentData_0 != null)
			{
				method_6("Name", documentData_0.Name, null);
				if (documentData_0.Values != null && documentData_0.Values.Count > 0)
				{
					method_3("Values");
					foreach (ValuePoint value in documentData_0.Values)
					{
						method_3("Value");
						method_146(value);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_121(DocumentDataList documentDataList_0)
		{
			int num = 2;
			if (documentDataList_0 != null)
			{
				method_3("DocumentDataList");
				method_122(documentDataList_0);
				method_48();
			}
		}

		private void method_122(DocumentDataList documentDataList_0)
		{
			int num = 10;
			if (documentDataList_0 != null)
			{
				foreach (DocumentData item in documentDataList_0)
				{
					method_3("DocumentData");
					method_120(item);
					method_48();
				}
			}
		}

		private void method_123(DocumentPageSettings documentPageSettings_0)
		{
			int num = 3;
			if (documentPageSettings_0 != null)
			{
				method_3("DocumentPageSettings");
				method_124(documentPageSettings_0);
				method_48();
			}
		}

		private void method_124(DocumentPageSettings documentPageSettings_0)
		{
			int num = 4;
			if (documentPageSettings_0 != null)
			{
				method_27("BottomMargin", documentPageSettings_0.BottomMargin, 100);
				method_35("Landscape", documentPageSettings_0.Landscape, bool_1: false);
				method_27("LeftMargin", documentPageSettings_0.LeftMargin, 100);
				method_27("PaperHeight", documentPageSettings_0.PaperHeight, 1169);
				method_26("PaperSizeName", documentPageSettings_0.PaperSizeName, "A4");
				method_27("PaperWidth", documentPageSettings_0.PaperWidth, 827);
				method_27("RightMargin", documentPageSettings_0.RightMargin, 100);
				method_27("TopMargin", documentPageSettings_0.TopMargin, 100);
			}
		}

		private void method_125(HeaderLabelInfo headerLabelInfo_0)
		{
			int num = 0;
			if (headerLabelInfo_0 != null)
			{
				method_3("HeaderLabelInfo");
				method_126(headerLabelInfo_0);
				method_48();
			}
		}

		private void method_126(HeaderLabelInfo headerLabelInfo_0)
		{
			int num = 13;
			if (headerLabelInfo_0 != null)
			{
				method_6("DataSourceName", headerLabelInfo_0.DataSourceName, null);
				method_6("ParameterName", headerLabelInfo_0.ParameterName, null);
				method_6("Title", headerLabelInfo_0.Title, null);
				method_6("Value", headerLabelInfo_0.Value, null);
				method_6("ValueFieldName", headerLabelInfo_0.ValueFieldName, null);
			}
		}

		private void method_127(HeaderLabelInfoList headerLabelInfoList_0)
		{
			int num = 14;
			if (headerLabelInfoList_0 != null)
			{
				method_3("HeaderLabelInfoList");
				method_128(headerLabelInfoList_0);
				method_48();
			}
		}

		private void method_128(HeaderLabelInfoList headerLabelInfoList_0)
		{
			int num = 16;
			if (headerLabelInfoList_0 != null)
			{
				foreach (HeaderLabelInfo item in headerLabelInfoList_0)
				{
					method_3("HeaderLabelInfo");
					method_126(item);
					method_48();
				}
			}
		}

		private void method_129(TemperatureDocument temperatureDocument_0)
		{
			int num = 6;
			if (temperatureDocument_0 != null)
			{
				method_3("TemperatureDocument");
				method_130(temperatureDocument_0);
				method_48();
			}
		}

		private void method_130(TemperatureDocument temperatureDocument_0)
		{
			int num = 15;
			if (temperatureDocument_0 != null)
			{
				method_37("CaretDateTime", temperatureDocument_0.CaretDateTime, new DateTime(1900, 1, 1));
				if (temperatureDocument_0.Config != null)
				{
					method_3("Config");
					method_132(temperatureDocument_0.Config);
					method_48();
				}
				if (temperatureDocument_0.Datas != null && temperatureDocument_0.Datas.Count > 0)
				{
					method_3("Datas");
					foreach (DocumentData data in temperatureDocument_0.Datas)
					{
						method_3("Data");
						method_120(data);
						method_48();
					}
					method_48();
				}
				if (temperatureDocument_0.Parameters != null && temperatureDocument_0.Parameters.Count > 0)
				{
					method_3("Parameters");
					foreach (DCTimeLineParameter parameter in temperatureDocument_0.Parameters)
					{
						method_3("Parameter");
						method_116(parameter);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_131(TemperatureDocumentConfig temperatureDocumentConfig_0)
		{
			int num = 10;
			if (temperatureDocumentConfig_0 != null)
			{
				method_3("TemperatureDocumentConfig");
				method_132(temperatureDocumentConfig_0);
				method_48();
			}
		}

		private void method_132(TemperatureDocumentConfig temperatureDocumentConfig_0)
		{
			int num = 11;
			if (temperatureDocumentConfig_0 != null)
			{
				method_5("Version", temperatureDocumentConfig_0.Version);
				method_35("AllowUserCollapseZone", temperatureDocumentConfig_0.AllowUserCollapseZone, bool_1: true);
				method_26("BackColorValue", temperatureDocumentConfig_0.BackColorValue, null);
				method_29("BigTitleFontSize", temperatureDocumentConfig_0.BigTitleFontSize, 27f);
				method_26("BigVerticalGridLineColorValue", temperatureDocumentConfig_0.BigVerticalGridLineColorValue, null);
				method_29("DataGridBottomPadding", temperatureDocumentConfig_0.DataGridBottomPadding, 0f);
				method_29("DataGridTopPadding", temperatureDocumentConfig_0.DataGridTopPadding, 0f);
				method_26("DateFormatString", temperatureDocumentConfig_0.DateFormatString, "yyyy-MM-dd");
				method_35("DebugMode", temperatureDocumentConfig_0.DebugMode, bool_1: false);
				method_26("EditValuePointMode", GClass21.smethod_4(temperatureDocumentConfig_0.EditValuePointMode), "None");
				method_29("ExtendDaysForTimeLine", temperatureDocumentConfig_0.ExtendDaysForTimeLine, 0f);
				method_26("FontName", temperatureDocumentConfig_0.FontName, "宋体");
				method_29("FontSize", temperatureDocumentConfig_0.FontSize, 9f);
				method_26("FooterDescription", temperatureDocumentConfig_0.FooterDescription, null);
				method_26("ForeColorValue", temperatureDocumentConfig_0.ForeColorValue, null);
				method_26("GridBackColorValue", temperatureDocumentConfig_0.GridBackColorValue, null);
				method_26("GridLineColorValue", temperatureDocumentConfig_0.GridLineColorValue, null);
				method_27("GridYSplitNum", temperatureDocumentConfig_0.GridYSplitNum, 8);
				method_27("ImagePixelHeight", temperatureDocumentConfig_0.ImagePixelHeight, 16);
				method_27("ImagePixelWidth", temperatureDocumentConfig_0.ImagePixelWidth, 16);
				method_26("LinkVisualStyle", GClass21.smethod_4(temperatureDocumentConfig_0.LinkVisualStyle), "Hover");
				method_27("NumOfDaysInOnePage", temperatureDocumentConfig_0.NumOfDaysInOnePage, 7);
				method_26("PageBackColorValue", temperatureDocumentConfig_0.PageBackColorValue, null);
				method_26("PageIndexText", temperatureDocumentConfig_0.PageIndexText, null);
				if (temperatureDocumentConfig_0.PageSettings != null)
				{
					method_3("PageSettings");
					method_124(temperatureDocumentConfig_0.PageSettings);
					method_48();
				}
				method_26("PageTitlePosition", GClass21.smethod_4(temperatureDocumentConfig_0.PageTitlePosition), "TopLeft");
				method_35("Readonly", temperatureDocumentConfig_0.Readonly, bool_1: false);
				method_26("SelectionMode", GClass21.smethod_4(temperatureDocumentConfig_0.SelectionMode), "None");
				method_27("ShadowPointDetectSeconds", temperatureDocumentConfig_0.ShadowPointDetectSeconds, 2000);
				method_35("ShowIcon", temperatureDocumentConfig_0.ShowIcon, bool_1: false);
				method_35("ShowTooltip", temperatureDocumentConfig_0.ShowTooltip, bool_1: true);
				method_26("SpecifyEndDate", temperatureDocumentConfig_0.SpecifyEndDate, null);
				method_26("SpecifyStartDate", temperatureDocumentConfig_0.SpecifyStartDate, null);
				method_29("SpecifyTickWidth", temperatureDocumentConfig_0.SpecifyTickWidth, 0f);
				method_29("SpecifyTitleHeight", temperatureDocumentConfig_0.SpecifyTitleHeight, 0f);
				method_26("SQLTextForHeaderLabel", temperatureDocumentConfig_0.SQLTextForHeaderLabel, null);
				method_29("SymbolSize", temperatureDocumentConfig_0.SymbolSize, 20f);
				method_26("TickUnit", GClass21.smethod_4(temperatureDocumentConfig_0.TickUnit), "Hour");
				method_26("Title", temperatureDocumentConfig_0.Title, null);
				method_26("TitleForToolTip", temperatureDocumentConfig_0.TitleForToolTip, null);
				if (temperatureDocumentConfig_0.FooterLines != null && temperatureDocumentConfig_0.FooterLines.Count > 0)
				{
					method_3("FooterLines");
					foreach (TitleLineInfo footerLine in temperatureDocumentConfig_0.FooterLines)
					{
						method_3("Line");
						method_142(footerLine);
						method_48();
					}
					method_48();
				}
				if (temperatureDocumentConfig_0.HeaderLabels != null && temperatureDocumentConfig_0.HeaderLabels.Count > 0)
				{
					method_3("HeaderLabels");
					foreach (HeaderLabelInfo headerLabel in temperatureDocumentConfig_0.HeaderLabels)
					{
						method_3("Label");
						method_126(headerLabel);
						method_48();
					}
					method_48();
				}
				if (temperatureDocumentConfig_0.HeaderLines != null && temperatureDocumentConfig_0.HeaderLines.Count > 0)
				{
					method_3("HeaderLines");
					foreach (TitleLineInfo headerLine in temperatureDocumentConfig_0.HeaderLines)
					{
						method_3("Line");
						method_142(headerLine);
						method_48();
					}
					method_48();
				}
				if (temperatureDocumentConfig_0.Images != null && temperatureDocumentConfig_0.Images.Count > 0)
				{
					method_3("Images");
					foreach (DCTimeLineImage image in temperatureDocumentConfig_0.Images)
					{
						method_3("Image");
						method_108(image);
						method_48();
					}
					method_48();
				}
				if (temperatureDocumentConfig_0.Labels != null && temperatureDocumentConfig_0.Labels.Count > 0)
				{
					method_3("Labels");
					foreach (DCTimeLineLabel label in temperatureDocumentConfig_0.Labels)
					{
						method_3("Label");
						method_112(label);
						method_48();
					}
					method_48();
				}
				if (temperatureDocumentConfig_0.Ticks != null && temperatureDocumentConfig_0.Ticks.Count > 0)
				{
					method_3("Ticks");
					foreach (TickInfo tick in temperatureDocumentConfig_0.Ticks)
					{
						method_3("Tick");
						method_134(tick);
						method_48();
					}
					method_48();
				}
				if (temperatureDocumentConfig_0.YAxisInfos != null && temperatureDocumentConfig_0.YAxisInfos.Count > 0)
				{
					method_3("YAxisInfos");
					foreach (YAxisInfo yAxisInfo in temperatureDocumentConfig_0.YAxisInfos)
					{
						method_3("YAxis");
						method_152(yAxisInfo);
						method_48();
					}
					method_48();
				}
				if (temperatureDocumentConfig_0.Zones != null && temperatureDocumentConfig_0.Zones.Count > 0)
				{
					method_3("Zones");
					foreach (TimeLineZoneInfo zone in temperatureDocumentConfig_0.Zones)
					{
						method_3("Zone");
						method_138(zone);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_133(TickInfo tickInfo_0)
		{
			int num = 17;
			if (tickInfo_0 != null)
			{
				method_3("TickInfo");
				method_134(tickInfo_0);
				method_48();
			}
		}

		private void method_134(TickInfo tickInfo_0)
		{
			int num = 9;
			if (tickInfo_0 != null)
			{
				method_6("ColorValue", tickInfo_0.ColorValue, null);
				method_6("Text", tickInfo_0.Text, null);
				method_9("Value", tickInfo_0.Value, 0f);
			}
		}

		private void method_135(TickInfoList tickInfoList_0)
		{
			int num = 9;
			if (tickInfoList_0 != null)
			{
				method_3("TickInfoList");
				method_136(tickInfoList_0);
				method_48();
			}
		}

		private void method_136(TickInfoList tickInfoList_0)
		{
			int num = 2;
			if (tickInfoList_0 != null)
			{
				foreach (TickInfo item in tickInfoList_0)
				{
					method_3("TickInfo");
					method_134(item);
					method_48();
				}
			}
		}

		private void method_137(TimeLineZoneInfo timeLineZoneInfo_0)
		{
			int num = 13;
			if (timeLineZoneInfo_0 != null)
			{
				method_3("TimeLineZoneInfo");
				method_138(timeLineZoneInfo_0);
				method_48();
			}
		}

		private void method_138(TimeLineZoneInfo timeLineZoneInfo_0)
		{
			int num = 18;
			if (timeLineZoneInfo_0 != null)
			{
				method_15("AlignToGrid", timeLineZoneInfo_0.AlignToGrid, bool_1: true);
				method_6("AutoTickFormatString", timeLineZoneInfo_0.AutoTickFormatString, null);
				method_7("AutoTickStepSeconds", timeLineZoneInfo_0.AutoTickStepSeconds, 0);
				method_6("BackColorValue", timeLineZoneInfo_0.BackColorValue, null);
				method_17("EndTime", timeLineZoneInfo_0.EndTime, new DateTime(1900, 1, 1));
				method_6("GridLineColorValue", timeLineZoneInfo_0.GridLineColorValue, null);
				method_6("GridLineStyle", GClass21.smethod_4(timeLineZoneInfo_0.GridLineStyle), "Solid");
				method_6("Name", timeLineZoneInfo_0.Name, null);
				method_9("SpecifyTickWidth", timeLineZoneInfo_0.SpecifyTickWidth, 0f);
				method_17("StartTime", timeLineZoneInfo_0.StartTime, new DateTime(1900, 1, 1));
				if (timeLineZoneInfo_0.Ticks != null && timeLineZoneInfo_0.Ticks.Count > 0)
				{
					method_3("Ticks");
					foreach (TickInfo tick in timeLineZoneInfo_0.Ticks)
					{
						method_3("Tick");
						method_134(tick);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_139(TimeLineZoneInfoList timeLineZoneInfoList_0)
		{
			int num = 2;
			if (timeLineZoneInfoList_0 != null)
			{
				method_3("TimeLineZoneInfoList");
				method_140(timeLineZoneInfoList_0);
				method_48();
			}
		}

		private void method_140(TimeLineZoneInfoList timeLineZoneInfoList_0)
		{
			int num = 18;
			if (timeLineZoneInfoList_0 != null)
			{
				foreach (TimeLineZoneInfo item in timeLineZoneInfoList_0)
				{
					method_3("TimeLineZoneInfo");
					method_138(item);
					method_48();
				}
			}
		}

		private void method_141(TitleLineInfo titleLineInfo_0)
		{
			int num = 13;
			if (titleLineInfo_0 != null)
			{
				method_3("TitleLineInfo");
				method_142(titleLineInfo_0);
				method_48();
			}
		}

		private void method_142(TitleLineInfo titleLineInfo_0)
		{
			int num = 10;
			if (titleLineInfo_0 != null)
			{
				method_9("BlockWidth", titleLineInfo_0.BlockWidth, 15f);
				method_6("CircleText", titleLineInfo_0.CircleText, null);
				method_6("DataSourceName", titleLineInfo_0.DataSourceName, null);
				method_15("EnableEndTime", titleLineInfo_0.EnableEndTime, bool_1: true);
				method_6("ExtendGridLineType", GClass21.smethod_4(titleLineInfo_0.ExtendGridLineType), "Below");
				method_6("GroupName", titleLineInfo_0.GroupName, null);
				method_6("InputTimePrecision", GClass21.smethod_4(titleLineInfo_0.InputTimePrecision), "Minute");
				method_6("LayoutType", GClass21.smethod_4(titleLineInfo_0.LayoutType), "Normal");
				method_6("LoopTextList", titleLineInfo_0.LoopTextList, null);
				method_7("MaxValueForDayIndex", titleLineInfo_0.MaxValueForDayIndex, 13);
				method_6("Name", titleLineInfo_0.Name, null);
				method_9("NormalMaxValue", titleLineInfo_0.NormalMaxValue, -10000f);
				method_9("NormalMinValue", titleLineInfo_0.NormalMinValue, -10000f);
				method_6("OutofNormalRangeTextColorValue", titleLineInfo_0.OutofNormalRangeTextColorValue, null);
				method_15("ShowBackColor", titleLineInfo_0.ShowBackColor, bool_1: false);
				method_9("SpecifyHeight", titleLineInfo_0.SpecifyHeight, 0f);
				method_9("SpecifyTitleWidth", titleLineInfo_0.SpecifyTitleWidth, 0f);
				method_17("StartDate", titleLineInfo_0.StartDate, new DateTime(1900, 1, 1));
				method_6("StartDateKeyword", titleLineInfo_0.StartDateKeyword, null);
				method_6("TextColorValue", titleLineInfo_0.TextColorValue, null);
				method_7("TickStep", titleLineInfo_0.TickStep, 1);
				method_6("TimeFieldName", titleLineInfo_0.TimeFieldName, null);
				method_6("Title", titleLineInfo_0.Title, null);
				method_6("TitleAlign", GClass21.smethod_4(titleLineInfo_0.TitleAlign), "Center");
				method_6("TitleColorValue", titleLineInfo_0.TitleColorValue, null);
				method_15("UpAndDownText", titleLineInfo_0.UpAndDownText, bool_1: false);
				method_6("ValueAlign", GClass21.smethod_4(titleLineInfo_0.ValueAlign), "Center");
				method_6("ValueDisplayFormat", titleLineInfo_0.ValueDisplayFormat, null);
				method_6("ValueFieldName", titleLineInfo_0.ValueFieldName, null);
				method_6("ValueType", GClass21.smethod_4(titleLineInfo_0.ValueType), "SerialDate");
				method_15("VerticalLineForFreeeLayout", titleLineInfo_0.VerticalLineForFreeeLayout, bool_1: true);
				if (titleLineInfo_0.DataSource != null)
				{
					method_3("DataSource");
					method_148(titleLineInfo_0.DataSource);
					method_48();
				}
				if (titleLineInfo_0.Font != null)
				{
					method_3("Font");
					method_74(titleLineInfo_0.Font);
					method_48();
				}
				if (titleLineInfo_0.ValueFont != null)
				{
					method_3("ValueFont");
					method_74(titleLineInfo_0.ValueFont);
					method_48();
				}
				method_35("ValueTextMultiLine", titleLineInfo_0.ValueTextMultiLine, bool_1: false);
				if (titleLineInfo_0.Scales != null && titleLineInfo_0.Scales.Count > 0)
				{
					method_3("Scales");
					foreach (YAxisScaleInfo scale in titleLineInfo_0.Scales)
					{
						method_3("Scale");
						method_156(scale);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_143(TitleLineInfoList titleLineInfoList_0)
		{
			int num = 2;
			if (titleLineInfoList_0 != null)
			{
				method_3("TitleLineInfoList");
				method_144(titleLineInfoList_0);
				method_48();
			}
		}

		private void method_144(TitleLineInfoList titleLineInfoList_0)
		{
			int num = 4;
			if (titleLineInfoList_0 != null)
			{
				foreach (TitleLineInfo item in titleLineInfoList_0)
				{
					method_3("TitleLineInfo");
					method_142(item);
					method_48();
				}
			}
		}

		private void method_145(ValuePoint valuePoint_0)
		{
			int num = 14;
			if (valuePoint_0 != null)
			{
				method_3("ValuePoint");
				method_146(valuePoint_0);
				method_48();
			}
		}

		private void method_146(ValuePoint valuePoint_0)
		{
			int num = 17;
			if (valuePoint_0 != null)
			{
				method_6("ColorValue", valuePoint_0.ColorValue, null);
				method_18("EndTime", valuePoint_0.EndTime);
				method_6("ID", valuePoint_0.ID, null);
				method_9("LanternValue", valuePoint_0.LanternValue, -10000f);
				method_6("Link", valuePoint_0.Link, null);
				method_6("LinkTarget", valuePoint_0.LinkTarget, null);
				method_6("SpecifySymbolStyle", GClass21.smethod_4(valuePoint_0.SpecifySymbolStyle), "Default");
				method_6("Text", valuePoint_0.Text, null);
				method_18("Time", valuePoint_0.Time);
				method_6("Title", valuePoint_0.Title, null);
				method_9("Value", valuePoint_0.Value, -10000f);
				if (valuePoint_0.Image != null)
				{
					method_3("Image");
					method_76(valuePoint_0.Image);
					method_48();
				}
			}
		}

		private void method_147(ValuePointDataSourceInfo valuePointDataSourceInfo_0)
		{
			int num = 5;
			if (valuePointDataSourceInfo_0 != null)
			{
				method_3("ValuePointDataSourceInfo");
				method_148(valuePointDataSourceInfo_0);
				method_48();
			}
		}

		private void method_148(ValuePointDataSourceInfo valuePointDataSourceInfo_0)
		{
			int num = 7;
			if (valuePointDataSourceInfo_0 != null)
			{
				method_6("FieldNameForID", valuePointDataSourceInfo_0.FieldNameForID, null);
				method_6("FieldNameForLanternValue", valuePointDataSourceInfo_0.FieldNameForLanternValue, null);
				method_6("FieldNameForLink", valuePointDataSourceInfo_0.FieldNameForLink, null);
				method_6("FieldNameForText", valuePointDataSourceInfo_0.FieldNameForText, null);
				method_6("FieldNameForTime", valuePointDataSourceInfo_0.FieldNameForTime, null);
				method_6("FieldNameForTitle", valuePointDataSourceInfo_0.FieldNameForTitle, null);
				method_6("FieldNameForValue", valuePointDataSourceInfo_0.FieldNameForValue, null);
				method_26("SQLText", valuePointDataSourceInfo_0.SQLText, null);
			}
		}

		private void method_149(ValuePointList valuePointList_0)
		{
			int num = 15;
			if (valuePointList_0 != null)
			{
				method_3("ValuePointList");
				method_150(valuePointList_0);
				method_48();
			}
		}

		private void method_150(ValuePointList valuePointList_0)
		{
			int num = 2;
			if (valuePointList_0 != null)
			{
				foreach (ValuePoint item in valuePointList_0)
				{
					method_3("ValuePoint");
					method_146(item);
					method_48();
				}
			}
		}

		private void method_151(YAxisInfo yaxisInfo_0)
		{
			int num = 0;
			if (yaxisInfo_0 != null)
			{
				method_3("YAxisInfo");
				method_152(yaxisInfo_0);
				method_48();
			}
		}

		private void method_152(YAxisInfo yaxisInfo_0)
		{
			int num = 17;
			if (yaxisInfo_0 != null)
			{
				method_15("AllowInterrupt", yaxisInfo_0.AllowInterrupt, bool_1: true);
				method_15("AllowOutofRange", yaxisInfo_0.AllowOutofRange, bool_1: false);
				method_6("BottomTitle", yaxisInfo_0.BottomTitle, null);
				method_15("ClickToHide", yaxisInfo_0.ClickToHide, bool_1: true);
				method_6("DataSourceName", yaxisInfo_0.DataSourceName, null);
				method_15("EnableLanternValue", yaxisInfo_0.EnableLanternValue, bool_1: false);
				method_6("HiddenValueTitleBackColorValue", yaxisInfo_0.HiddenValueTitleBackColorValue, null);
				method_15("HighlightOutofNormalRange", yaxisInfo_0.HighlightOutofNormalRange, bool_1: true);
				method_6("HollowCovertTargetName", yaxisInfo_0.HollowCovertTargetName, null);
				method_6("InputTimePrecision", GClass21.smethod_4(yaxisInfo_0.InputTimePrecision), "Minute");
				method_6("LanternValueFieldName", yaxisInfo_0.LanternValueFieldName, null);
				method_6("LanternValueTitle", yaxisInfo_0.LanternValueTitle, null);
				method_7("LineWidth", yaxisInfo_0.LineWidth, 1);
				method_9("MaxValue", yaxisInfo_0.MaxValue, 100f);
				method_9("MinValue", yaxisInfo_0.MinValue, 0f);
				method_6("Name", yaxisInfo_0.Name, null);
				method_9("NormalMaxValue", yaxisInfo_0.NormalMaxValue, -10000f);
				method_9("NormalMinValue", yaxisInfo_0.NormalMinValue, -10000f);
				method_6("NormalRangeBackColorValue", yaxisInfo_0.NormalRangeBackColorValue, null);
				method_6("OutofNormalRangeBackColorValue", yaxisInfo_0.OutofNormalRangeBackColorValue, null);
				method_9("RedLineValue", yaxisInfo_0.RedLineValue, -10000f);
				method_6("ShadowName", yaxisInfo_0.ShadowName, null);
				method_15("ShowLegendInRule", yaxisInfo_0.ShowLegendInRule, bool_1: true);
				method_9("SpecifyTitleWidth", yaxisInfo_0.SpecifyTitleWidth, 0f);
				method_6("Style", GClass21.smethod_4(yaxisInfo_0.Style), "Value");
				method_6("SymbolColorValue", yaxisInfo_0.SymbolColorValue, "Red");
				method_9("SymbolSize", yaxisInfo_0.SymbolSize, 20f);
				method_6("SymbolStyle", GClass21.smethod_4(yaxisInfo_0.SymbolStyle), "SolidCicle");
				method_6("TimeFieldName", yaxisInfo_0.TimeFieldName, null);
				method_6("Title", yaxisInfo_0.Title, null);
				method_6("TitleBackColorValue", yaxisInfo_0.TitleBackColorValue, null);
				method_6("TitleColorValue", yaxisInfo_0.TitleColorValue, null);
				method_6("TitleValueDispalyFormat", yaxisInfo_0.TitleValueDispalyFormat, null);
				method_15("TitleVisible", yaxisInfo_0.TitleVisible, bool_1: true);
				method_6("ValueFieldName", yaxisInfo_0.ValueFieldName, null);
				method_6("ValueFormatString", yaxisInfo_0.ValueFormatString, null);
				method_7("ValuePrecision", yaxisInfo_0.ValuePrecision, 2);
				method_6("ValueTextBackColorValue", yaxisInfo_0.ValueTextBackColorValue, null);
				method_15("ValueVisible", yaxisInfo_0.ValueVisible, bool_1: true);
				method_15("Visible", yaxisInfo_0.Visible, bool_1: true);
				method_7("YSplitNum", yaxisInfo_0.YSplitNum, 8);
				method_29("BottomPadding", yaxisInfo_0.BottomPadding, -10000f);
				if (yaxisInfo_0.DataSource != null)
				{
					method_3("DataSource");
					method_148(yaxisInfo_0.DataSource);
					method_48();
				}
				if (yaxisInfo_0.Font != null)
				{
					method_3("Font");
					method_74(yaxisInfo_0.Font);
					method_48();
				}
				method_29("TopPadding", yaxisInfo_0.TopPadding, -10000f);
				if (yaxisInfo_0.ValueFont != null)
				{
					method_3("ValueFont");
					method_74(yaxisInfo_0.ValueFont);
					method_48();
				}
				if (yaxisInfo_0.Scales != null && yaxisInfo_0.Scales.Count > 0)
				{
					method_3("Scales");
					foreach (YAxisScaleInfo scale in yaxisInfo_0.Scales)
					{
						method_3("Scale");
						method_156(scale);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_153(YAxisInfoList yaxisInfoList_0)
		{
			int num = 2;
			if (yaxisInfoList_0 != null)
			{
				method_3("YAxisInfoList");
				method_154(yaxisInfoList_0);
				method_48();
			}
		}

		private void method_154(YAxisInfoList yaxisInfoList_0)
		{
			int num = 5;
			if (yaxisInfoList_0 != null)
			{
				foreach (YAxisInfo item in yaxisInfoList_0)
				{
					method_3("YAxisInfo");
					method_152(item);
					method_48();
				}
			}
		}

		private void method_155(YAxisScaleInfo yaxisScaleInfo_0)
		{
			int num = 0;
			if (yaxisScaleInfo_0 != null)
			{
				method_3("YAxisScaleInfo");
				method_156(yaxisScaleInfo_0);
				method_48();
			}
		}

		private void method_156(YAxisScaleInfo yaxisScaleInfo_0)
		{
			int num = 7;
			if (yaxisScaleInfo_0 != null)
			{
				method_6("ColorValue", yaxisScaleInfo_0.ColorValue, null);
				method_9("ScaleRate", yaxisScaleInfo_0.ScaleRate, 0f);
				method_6("Text", yaxisScaleInfo_0.Text, null);
				method_10("Value", yaxisScaleInfo_0.Value);
			}
		}

		private void method_157(YAxisScaleInfoList yaxisScaleInfoList_0)
		{
			int num = 18;
			if (yaxisScaleInfoList_0 != null)
			{
				method_3("YAxisScaleInfoList");
				method_158(yaxisScaleInfoList_0);
				method_48();
			}
		}

		private void method_158(YAxisScaleInfoList yaxisScaleInfoList_0)
		{
			int num = 8;
			if (yaxisScaleInfoList_0 != null)
			{
				foreach (YAxisScaleInfo item in yaxisScaleInfoList_0)
				{
					method_3("YAxisScaleInfo");
					method_156(item);
					method_48();
				}
			}
		}

		private void method_159(WriterControlOptions writerControlOptions_0)
		{
			int num = 19;
			if (writerControlOptions_0 != null)
			{
				method_3("WriterControlOptions");
				method_160(writerControlOptions_0);
				method_48();
			}
		}

		private void method_160(WriterControlOptions writerControlOptions_0)
		{
			int num = 12;
			if (writerControlOptions_0 != null)
			{
				method_35("AcceptsTab", writerControlOptions_0.AcceptsTab, bool_1: true);
				method_26("AdditionPageTitle", writerControlOptions_0.AdditionPageTitle, null);
				method_35("AllowDrop", writerControlOptions_0.AllowDrop, bool_1: false);
				method_35("BackgroundMode", writerControlOptions_0.BackgroundMode, bool_1: false);
				method_26("CurrentPageBorderColor", writerControlOptions_0.CurrentPageBorderColor, null);
				method_26("DefaultPrinterName", writerControlOptions_0.DefaultPrinterName, null);
				if (writerControlOptions_0.DocumentOptions != null)
				{
					method_3("DocumentOptions");
					method_188(writerControlOptions_0.DocumentOptions);
					method_48();
				}
				method_27("EndPageIndex", writerControlOptions_0.EndPageIndex, -1);
				if (writerControlOptions_0.Font != null)
				{
					method_3("Font");
					method_74(writerControlOptions_0.Font);
					method_48();
				}
				method_35("ForceShowCaret", writerControlOptions_0.ForceShowCaret, bool_1: false);
				method_26("FormView", GClass21.smethod_4(writerControlOptions_0.FormView), "Disable");
				method_25("HeaderFooterFlagVisible", GClass21.smethod_4(writerControlOptions_0.HeaderFooterFlagVisible));
				method_35("HeaderFooterReadonly", writerControlOptions_0.HeaderFooterReadonly, bool_1: false);
				method_35("HideCaretWhenHasSelection", writerControlOptions_0.HideCaretWhenHasSelection, bool_1: true);
				method_35("InsertMode", writerControlOptions_0.InsertMode, bool_1: true);
				method_35("IsAdministrator", writerControlOptions_0.IsAdministrator, bool_1: false);
				if (writerControlOptions_0.JumpPrint != null)
				{
					method_3("JumpPrint");
					method_80(writerControlOptions_0.JumpPrint);
					method_48();
				}
				method_26("KBLibraryUrl", writerControlOptions_0.KBLibraryUrl, null);
				method_26("PageBackColor", writerControlOptions_0.PageBackColor, null);
				method_26("PageBorderColor", writerControlOptions_0.PageBorderColor, null);
				method_27("PageSpacing", writerControlOptions_0.PageSpacing, 20);
				method_26("PageTitlePosition", GClass21.smethod_4(writerControlOptions_0.PageTitlePosition), "TopLeft");
				method_35("Readonly", writerControlOptions_0.Readonly, bool_1: false);
				method_35("ReadViewMode", writerControlOptions_0.ReadViewMode, bool_1: false);
				method_26("RuleBackColor", writerControlOptions_0.RuleBackColor, null);
				method_35("RuleEnabled", writerControlOptions_0.RuleEnabled, bool_1: true);
				method_35("RuleVisible", writerControlOptions_0.RuleVisible, bool_1: true);
				method_27("StartPageIndex", writerControlOptions_0.StartPageIndex, -1);
				method_25("StatusText", writerControlOptions_0.StatusText);
				if (writerControlOptions_0.UserInfo != null)
				{
					method_3("UserInfo");
					method_162(writerControlOptions_0.UserInfo);
					method_48();
				}
				method_26("ViewMode", GClass21.smethod_4(writerControlOptions_0.ViewMode), "Page");
			}
		}

		private void method_161(CurrentUserInfo currentUserInfo_0)
		{
			int num = 15;
			if (currentUserInfo_0 != null)
			{
				method_3("CurrentUserInfo");
				method_162(currentUserInfo_0);
				method_48();
			}
		}

		private void method_162(CurrentUserInfo currentUserInfo_0)
		{
			int num = 14;
			if (currentUserInfo_0 != null)
			{
				method_25("ClientName", currentUserInfo_0.ClientName);
				method_25("Description", currentUserInfo_0.Description);
				method_25("ID", currentUserInfo_0.ID);
				method_25("Name", currentUserInfo_0.Name);
				method_28("PermissionLevel", currentUserInfo_0.PermissionLevel);
			}
		}

		private void method_163(DocumentParameter documentParameter_0)
		{
			int num = 7;
			if (documentParameter_0 != null)
			{
				method_3("DocumentParameter");
				method_164(documentParameter_0);
				method_48();
			}
		}

		private void method_164(DocumentParameter documentParameter_0)
		{
			int num = 9;
			if (documentParameter_0 != null)
			{
				method_6("DefaultValue", documentParameter_0.DefaultValue, null);
				method_6("Description", documentParameter_0.Description, null);
				method_6("Name", documentParameter_0.Name, null);
				method_6("SourceColumn", documentParameter_0.SourceColumn, null);
				method_6("TypeName", documentParameter_0.TypeName, null);
				method_6("ValueType", GClass21.smethod_4(documentParameter_0.ValueType), "Object");
				method_6("ValueTypeFullName", documentParameter_0.ValueTypeFullName, null);
				if (documentParameter_0.SerializeValue != null)
				{
					method_3("SerializeValue");
					method_182(documentParameter_0.SerializeValue);
					method_48();
				}
			}
		}

		private void method_165(DocumentParameterCollection documentParameterCollection_0)
		{
			int num = 13;
			if (documentParameterCollection_0 != null)
			{
				method_3("DocumentParameterCollection");
				method_166(documentParameterCollection_0);
				method_48();
			}
		}

		private void method_166(DocumentParameterCollection documentParameterCollection_0)
		{
			int num = 0;
			if (documentParameterCollection_0 != null)
			{
				foreach (DocumentParameter item in documentParameterCollection_0)
				{
					method_3("DocumentParameter");
					method_164(item);
					method_48();
				}
			}
		}

		private void method_167(LinkListBindingInfo linkListBindingInfo_0)
		{
			int num = 4;
			if (linkListBindingInfo_0 != null)
			{
				method_3("LinkListBindingInfo");
				method_168(linkListBindingInfo_0);
				method_48();
			}
		}

		private void method_168(LinkListBindingInfo linkListBindingInfo_0)
		{
			int num = 15;
			if (linkListBindingInfo_0 != null)
			{
				method_35("AutoSetFirstItems", linkListBindingInfo_0.AutoSetFirstItems, bool_1: false);
				method_35("AutoUpdateTargetElement", linkListBindingInfo_0.AutoUpdateTargetElement, bool_1: true);
				method_35("IsRoot", linkListBindingInfo_0.IsRoot, bool_1: false);
				method_26("NextTarget", GClass21.smethod_4(linkListBindingInfo_0.NextTarget), "NextElement");
				method_26("NextTargetID", linkListBindingInfo_0.NextTargetID, null);
				method_26("ProviderName", linkListBindingInfo_0.ProviderName, null);
				method_26("UserFlag", linkListBindingInfo_0.UserFlag, null);
			}
		}

		private void method_169(ListItem listItem_0)
		{
			int num = 12;
			if (listItem_0 != null)
			{
				method_3("ListItem");
				method_170(listItem_0);
				method_48();
			}
		}

		private void method_170(ListItem listItem_0)
		{
			int num = 7;
			if (listItem_0 != null)
			{
				method_37("CheckedTime", listItem_0.CheckedTime, new DateTime(1900, 1, 1));
				method_26("EntryID", listItem_0.EntryID, null);
				method_26("Group", listItem_0.Group, null);
				method_26("ID", listItem_0.ID, null);
				method_27("ListIndex", listItem_0.ListIndex, 0);
				method_35("LonelyChecked", listItem_0.LonelyChecked, bool_1: false);
				method_26("SpellCode", listItem_0.SpellCode, null);
				method_26("SpellCode2", listItem_0.SpellCode2, null);
				method_26("SpellCode3", listItem_0.SpellCode3, null);
				method_26("Tag", listItem_0.Tag, null);
				method_26("Text", listItem_0.Text, null);
				method_26("Text2", listItem_0.Text2, null);
				method_26("TextInList", listItem_0.TextInList, null);
				method_26("Value", listItem_0.Value, null);
			}
		}

		private void method_171(ListItemCollection listItemCollection_0)
		{
			int num = 5;
			if (listItemCollection_0 != null)
			{
				method_3("ListItems");
				method_172(listItemCollection_0);
				method_48();
			}
		}

		private void method_172(ListItemCollection listItemCollection_0)
		{
			int num = 12;
			if (listItemCollection_0 != null)
			{
				foreach (ListItem item in listItemCollection_0)
				{
					method_3("ListItem");
					method_170(item);
					method_48();
				}
			}
		}

		private void method_173(ListSourceInfo listSourceInfo_0)
		{
			int num = 8;
			if (listSourceInfo_0 != null)
			{
				method_3("ListSourceInfo");
				method_174(listSourceInfo_0);
				method_48();
			}
		}

		private void method_174(ListSourceInfo listSourceInfo_0)
		{
			int num = 19;
			if (listSourceInfo_0 != null)
			{
				method_35("BufferItems", listSourceInfo_0.BufferItems, bool_1: true);
				method_26("DisplayPath", listSourceInfo_0.DisplayPath, null);
				method_26("SourceName", listSourceInfo_0.SourceName, null);
				method_26("ValuePath", listSourceInfo_0.ValuePath, null);
				if (listSourceInfo_0.Items != null && listSourceInfo_0.Items.Count > 0)
				{
					method_3("Items");
					foreach (ListItem item in listSourceInfo_0.Items)
					{
						method_3("Item");
						method_170(item);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_175(XDataBinding xdataBinding_0)
		{
			int num = 9;
			if (xdataBinding_0 != null)
			{
				method_3("XDataBinding");
				method_176(xdataBinding_0);
				method_48();
			}
		}

		private void method_176(XDataBinding xdataBinding_0)
		{
			int num = 11;
			if (xdataBinding_0 != null)
			{
				method_35("AutoUpdate", xdataBinding_0.AutoUpdate, bool_1: false);
				method_26("BindingPath", xdataBinding_0.BindingPath, null);
				method_26("DataSource", xdataBinding_0.DataSource, null);
				method_35("Enabled", xdataBinding_0.Enabled, bool_1: true);
				method_25("FormatString", xdataBinding_0.FormatString);
				method_26("ProcessState", GClass21.smethod_4(xdataBinding_0.ProcessState), "Always");
				method_35("Readonly", xdataBinding_0.Readonly, bool_1: false);
				method_26("WriteTextBindingPath", xdataBinding_0.WriteTextBindingPath, null);
			}
		}

		private void method_177(XMLViewStateBag xmlviewStateBag_0)
		{
			int num = 8;
			if (xmlviewStateBag_0 != null)
			{
				method_3("XMLViewStateBag");
				method_178(xmlviewStateBag_0);
				method_48();
			}
		}

		private void method_178(XMLViewStateBag xmlviewStateBag_0)
		{
			int num = 18;
			if (xmlviewStateBag_0 != null)
			{
				foreach (XMLViewStateBagItem item in xmlviewStateBag_0)
				{
					method_3("XMLViewStateBagItem");
					method_180(item);
					method_48();
				}
			}
		}

		private void method_179(XMLViewStateBagItem xmlviewStateBagItem_0)
		{
			int num = 9;
			if (xmlviewStateBagItem_0 != null)
			{
				method_3("XMLViewStateBagItem");
				method_180(xmlviewStateBagItem_0);
				method_48();
			}
		}

		private void method_180(XMLViewStateBagItem xmlviewStateBagItem_0)
		{
			int num = 3;
			if (xmlviewStateBagItem_0 != null)
			{
				method_6("Name", xmlviewStateBagItem_0.Name, null);
				method_6("TypeName", xmlviewStateBagItem_0.TypeName, null);
				if (xmlviewStateBagItem_0.XMLValue != null)
				{
					method_3("XMLValue");
					method_182(xmlviewStateBagItem_0.XMLValue);
					method_48();
				}
			}
		}

		private void method_181(DCXmlSerializablePackage dcxmlSerializablePackage_0)
		{
			int num = 8;
			if (dcxmlSerializablePackage_0 != null)
			{
				method_3("DCXmlSerializablePackage");
				method_182(dcxmlSerializablePackage_0);
				method_48();
			}
		}

		private void method_182(DCXmlSerializablePackage dcxmlSerializablePackage_0)
		{
			int num = 6;
			if (dcxmlSerializablePackage_0 != null)
			{
				method_35("AutoConvertToXMLElement", dcxmlSerializablePackage_0.AutoConvertToXMLElement, bool_1: false);
				method_26("ValueTypeName", dcxmlSerializablePackage_0.ValueTypeName, null);
			}
		}

		private void method_183(DocumentBehaviorOptions documentBehaviorOptions_0)
		{
			int num = 0;
			if (documentBehaviorOptions_0 != null)
			{
				method_3("DocumentBehaviorOptions");
				method_184(documentBehaviorOptions_0);
				method_48();
			}
		}

		private void method_184(DocumentBehaviorOptions documentBehaviorOptions_0)
		{
			int num = 3;
			if (documentBehaviorOptions_0 != null)
			{
				method_26("AcceptDataFormats", GClass21.smethod_4(documentBehaviorOptions_0.AcceptDataFormats), "All");
				method_35("ActiveCheckInstallWindowsMediaPlayer", documentBehaviorOptions_0.ActiveCheckInstallWindowsMediaPlayer, bool_1: false);
				method_35("AllowDeleteJumpOutOfField", documentBehaviorOptions_0.AllowDeleteJumpOutOfField, bool_1: true);
				method_35("AllowDragContent", documentBehaviorOptions_0.AllowDragContent, bool_1: false);
				method_26("AppErrorHandleMode", GClass21.smethod_4(documentBehaviorOptions_0.AppErrorHandleMode), "ThrowException");
				method_35("AutoActiveSystemTaskbarBeforeShowDialog", documentBehaviorOptions_0.AutoActiveSystemTaskbarBeforeShowDialog, bool_1: false);
				method_35("AutoAssistInsertString", documentBehaviorOptions_0.AutoAssistInsertString, bool_1: false);
				method_27("AutoAssistInsertStringDetectTextLength", documentBehaviorOptions_0.AutoAssistInsertStringDetectTextLength, 0);
				method_35("AutoClearTextFormatWhenPasteOrInsertContent", documentBehaviorOptions_0.AutoClearTextFormatWhenPasteOrInsertContent, bool_1: false);
				method_35("AutoCreateInstanceInProperty", documentBehaviorOptions_0.AutoCreateInstanceInProperty, bool_1: false);
				method_35("AutoDocumentValueValidate", documentBehaviorOptions_0.AutoDocumentValueValidate, bool_1: false);
				method_35("AutoFixElementIDWhenInsertElements", documentBehaviorOptions_0.AutoFixElementIDWhenInsertElements, bool_1: true);
				method_35("AutoIgnoreLastEmptyPage", documentBehaviorOptions_0.AutoIgnoreLastEmptyPage, bool_1: true);
				method_35("AutoRefreshUserTrackInfos", documentBehaviorOptions_0.AutoRefreshUserTrackInfos, bool_1: false);
				method_27("AutoSaveIntervalInSecond", documentBehaviorOptions_0.AutoSaveIntervalInSecond, 0);
				method_35("AutoScrollToCaretWhenGotFocus", documentBehaviorOptions_0.AutoScrollToCaretWhenGotFocus, bool_1: false);
				method_35("AutoShowScriptErrorMessage", documentBehaviorOptions_0.AutoShowScriptErrorMessage, bool_1: false);
				method_26("AutoTranslateDescString", documentBehaviorOptions_0.AutoTranslateDescString, null);
				method_26("AutoTranslateSourceString", documentBehaviorOptions_0.AutoTranslateSourceString, null);
				method_35("AutoUpdateButtonVisible", documentBehaviorOptions_0.AutoUpdateButtonVisible, bool_1: false);
				method_35("AutoUppercaseFirstCharInFirstLine", documentBehaviorOptions_0.AutoUppercaseFirstCharInFirstLine, bool_1: false);
				method_35("CloneSerialize", documentBehaviorOptions_0.CloneSerialize, bool_1: true);
				method_35("CommentEditableWhenReadonly", documentBehaviorOptions_0.CommentEditableWhenReadonly, bool_1: false);
				method_26("CommentVisibility", GClass21.smethod_4(documentBehaviorOptions_0.CommentVisibility), "Auto");
				method_35("CompressLayoutForFieldBorder", documentBehaviorOptions_0.CompressLayoutForFieldBorder, bool_1: true);
				method_35("ContinueHeaderParagrahStyle", documentBehaviorOptions_0.ContinueHeaderParagrahStyle, bool_1: false);
				method_26("CreationDataFormats", GClass21.smethod_4(documentBehaviorOptions_0.CreationDataFormats), "All");
				method_25("CustomPromptForbitCheckMRID", documentBehaviorOptions_0.CustomPromptForbitCheckMRID);
				method_26("CustomWarringCheckMRID", documentBehaviorOptions_0.CustomWarringCheckMRID, null);
				method_26("DataObjectRange", GClass21.smethod_4(documentBehaviorOptions_0.DataObjectRange), "OS");
				method_35("DebugMode", documentBehaviorOptions_0.DebugMode, bool_1: false);
				method_26("DefaultEditorActiveMode", GClass21.smethod_4(documentBehaviorOptions_0.DefaultEditorActiveMode), "None");
				method_35("DesignMode", documentBehaviorOptions_0.DesignMode, bool_1: false);
				method_35("DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject", documentBehaviorOptions_0.DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject, bool_1: false);
				method_35("DisplayFormatToInnerValue", documentBehaviorOptions_0.DisplayFormatToInnerValue, bool_1: true);
				method_35("DoubleClickToEditComment", documentBehaviorOptions_0.DoubleClickToEditComment, bool_1: true);
				method_35("DoubleClickToSelectWord", documentBehaviorOptions_0.DoubleClickToSelectWord, bool_1: true);
				method_35("EnableCalculateControl", documentBehaviorOptions_0.EnableCalculateControl, bool_1: true);
				method_35("EnableCheckControlLoaded", documentBehaviorOptions_0.EnableCheckControlLoaded, bool_1: false);
				method_35("EnableChineseFontSizeName", documentBehaviorOptions_0.EnableChineseFontSizeName, bool_1: true);
				method_35("EnableCompressUserHistories", documentBehaviorOptions_0.EnableCompressUserHistories, bool_1: true);
				method_35("EnableContentLock", documentBehaviorOptions_0.EnableContentLock, bool_1: true);
				method_35("EnableControlHostAtDesignTime", documentBehaviorOptions_0.EnableControlHostAtDesignTime, bool_1: true);
				method_35("EnableCopySource", documentBehaviorOptions_0.EnableCopySource, bool_1: true);
				method_35("EnableDataBinding", documentBehaviorOptions_0.EnableDataBinding, bool_1: true);
				method_35("EnabledElementEvent", documentBehaviorOptions_0.EnabledElementEvent, bool_1: true);
				method_35("EnableDeleteReadonlyEmptyContainer", documentBehaviorOptions_0.EnableDeleteReadonlyEmptyContainer, bool_1: true);
				method_35("EnableEditElementValue", documentBehaviorOptions_0.EnableEditElementValue, bool_1: true);
				method_35("EnableElementEvents", documentBehaviorOptions_0.EnableElementEvents, bool_1: true);
				method_35("EnableExpression", documentBehaviorOptions_0.EnableExpression, bool_1: true);
				method_35("EnableHyperLink", documentBehaviorOptions_0.EnableHyperLink, bool_1: true);
				method_35("EnableKBEntryRangeMask", documentBehaviorOptions_0.EnableKBEntryRangeMask, bool_1: true);
				method_35("EnableLogUndo", documentBehaviorOptions_0.EnableLogUndo, bool_1: true);
				method_35("EnableScript", documentBehaviorOptions_0.EnableScript, bool_1: true);
				method_35("EnableSetJumpPrintPositionWhenPreview", documentBehaviorOptions_0.EnableSetJumpPrintPositionWhenPreview, bool_1: true);
				method_26("ExcludeKeywords", documentBehaviorOptions_0.ExcludeKeywords, null);
				method_35("ExtendingPrintDialog", documentBehaviorOptions_0.ExtendingPrintDialog, bool_1: true);
				method_35("FastInputMode", documentBehaviorOptions_0.FastInputMode, bool_1: false);
				method_35("FillCommentToUserTrackList", documentBehaviorOptions_0.FillCommentToUserTrackList, bool_1: false);
				method_35("ForceCollateWhenPrint", documentBehaviorOptions_0.ForceCollateWhenPrint, bool_1: false);
				method_35("ForcePopupFormTopMost", documentBehaviorOptions_0.ForcePopupFormTopMost, bool_1: false);
				method_26("FormView", GClass21.smethod_4(documentBehaviorOptions_0.FormView), "Disable");
				method_35("GeneratePageContentVersion", documentBehaviorOptions_0.GeneratePageContentVersion, bool_1: false);
				method_35("GlobalSpecifyDebugModeValue", documentBehaviorOptions_0.GlobalSpecifyDebugModeValue, bool_1: false);
				method_35("HandleCommandException", documentBehaviorOptions_0.HandleCommandException, bool_1: true);
				method_35("IgnorePrintableAreaOffset", documentBehaviorOptions_0.IgnorePrintableAreaOffset, bool_1: false);
				method_26("ImageCompressSaveMode", GClass21.smethod_4(documentBehaviorOptions_0.ImageCompressSaveMode), "Prompt");
				method_26("ImageShapeEditorBackgroundMenuItemConfig", documentBehaviorOptions_0.ImageShapeEditorBackgroundMenuItemConfig, null);
				method_35("InsertCommentBindingUserTrack", documentBehaviorOptions_0.InsertCommentBindingUserTrack, bool_1: false);
				method_26("InsertDocumentWithCheckMRID", GClass21.smethod_4(documentBehaviorOptions_0.InsertDocumentWithCheckMRID), "None");
				method_35("MaximizedPrintPreviewDialog", documentBehaviorOptions_0.MaximizedPrintPreviewDialog, bool_1: false);
				method_27("MaxTextLengthForPaste", documentBehaviorOptions_0.MaxTextLengthForPaste, 0);
				method_29("MaxZoomRate", documentBehaviorOptions_0.MaxZoomRate, 5f);
				method_27("MinCountForDropdownListSpellCodeArea", documentBehaviorOptions_0.MinCountForDropdownListSpellCodeArea, 4);
				method_27("MinImageFileSizeForConfirmCompressSaveMode", documentBehaviorOptions_0.MinImageFileSizeForConfirmCompressSaveMode, 51200);
				method_29("MinZoomRate", documentBehaviorOptions_0.MinZoomRate, 0.2f);
				method_35("MoveCaretWhenDeleteFail", documentBehaviorOptions_0.MoveCaretWhenDeleteFail, bool_1: true);
				method_35("MoveFieldWhenDragWholeContent", documentBehaviorOptions_0.MoveFieldWhenDragWholeContent, bool_1: true);
				method_26("MoveFocusHotKey", GClass21.smethod_4(documentBehaviorOptions_0.MoveFocusHotKey), "None");
				method_27("NotificationWorkingTimeout", documentBehaviorOptions_0.NotificationWorkingTimeout, 2000);
				method_35("OutputBackgroundTextToRTF", documentBehaviorOptions_0.OutputBackgroundTextToRTF, bool_1: true);
				method_35("OutputFieldBorderTextToContentText", documentBehaviorOptions_0.OutputFieldBorderTextToContentText, bool_1: true);
				method_35("OutputFormatedXMLSource", documentBehaviorOptions_0.OutputFormatedXMLSource, bool_1: true);
				method_35("PageLineUnderPageBreak", documentBehaviorOptions_0.PageLineUnderPageBreak, bool_1: false);
				method_35("ParagraphFlagFollowTableOrSection", documentBehaviorOptions_0.ParagraphFlagFollowTableOrSection, bool_1: false);
				method_35("PowerfulCommentCommand", documentBehaviorOptions_0.PowerfulCommentCommand, bool_1: true);
				method_35("PreserveClipbardDataWhenExit", documentBehaviorOptions_0.PreserveClipbardDataWhenExit, bool_1: false);
				method_35("Printable", documentBehaviorOptions_0.Printable, bool_1: true);
				method_35("PromptForExcludeSystemClipboardRange", documentBehaviorOptions_0.PromptForExcludeSystemClipboardRange, bool_1: true);
				method_35("PromptForRejectFormat", documentBehaviorOptions_0.PromptForRejectFormat, bool_1: true);
				method_35("PromptJumpBackForSearch", documentBehaviorOptions_0.PromptJumpBackForSearch, bool_1: true);
				method_26("PromptProtectedContent", GClass21.smethod_4(documentBehaviorOptions_0.PromptProtectedContent), "Details");
				method_35("RaiseQueryListItemsWhenUserEditText", documentBehaviorOptions_0.RaiseQueryListItemsWhenUserEditText, bool_1: false);
				method_35("RemoveLastParagraphFlagWhenInsertDocument", documentBehaviorOptions_0.RemoveLastParagraphFlagWhenInsertDocument, bool_1: false);
				method_35("ShowDebugMessage", documentBehaviorOptions_0.ShowDebugMessage, bool_1: false);
				method_35("ShowTooltip", documentBehaviorOptions_0.ShowTooltip, bool_1: true);
				method_35("SimpleElementProperties", documentBehaviorOptions_0.SimpleElementProperties, bool_1: false);
				method_35("SmoothScrollView", documentBehaviorOptions_0.SmoothScrollView, bool_1: true);
				method_35("SpecifyDebugMode", documentBehaviorOptions_0.SpecifyDebugMode, bool_1: false);
				method_26("StdLablesForImageEditor", documentBehaviorOptions_0.StdLablesForImageEditor, null);
				method_27("TableCellOperationDetectDistance", documentBehaviorOptions_0.TableCellOperationDetectDistance, 3);
				method_35("ThreeClickToSelectParagraph", documentBehaviorOptions_0.ThreeClickToSelectParagraph, bool_1: true);
				method_26("TitleForToolTip", documentBehaviorOptions_0.TitleForToolTip, null);
				method_26("ValidateIDRepeatMode", GClass21.smethod_4(documentBehaviorOptions_0.ValidateIDRepeatMode), "None");
				method_35("ValidateUserIDWhenEditDeleteComment", documentBehaviorOptions_0.ValidateUserIDWhenEditDeleteComment, bool_1: false);
				method_35("WeakMode", documentBehaviorOptions_0.WeakMode, bool_1: false);
				method_35("WidelyRaiseFocusEvent", documentBehaviorOptions_0.WidelyRaiseFocusEvent, bool_1: false);
				method_26("XMLContentEncodingName", documentBehaviorOptions_0.XMLContentEncodingName, null);
			}
		}

		private void method_185(DocumentEditOptions documentEditOptions_0)
		{
			int num = 14;
			if (documentEditOptions_0 != null)
			{
				method_3("DocumentEditOptions");
				method_186(documentEditOptions_0);
				method_48();
			}
		}

		private void method_186(DocumentEditOptions documentEditOptions_0)
		{
			int num = 12;
			if (documentEditOptions_0 != null)
			{
				method_35("AutoInsertTableRowWhenMoveToNextCell", documentEditOptions_0.AutoInsertTableRowWhenMoveToNextCell, bool_1: true);
				method_35("ClearFieldValueWhenCopy", documentEditOptions_0.ClearFieldValueWhenCopy, bool_1: false);
				method_35("CloneWithoutElementBorderStyle", documentEditOptions_0.CloneWithoutElementBorderStyle, bool_1: true);
				method_35("CloneWithoutLogicDeletedContent", documentEditOptions_0.CloneWithoutLogicDeletedContent, bool_1: false);
				method_35("CopyInTextFormatOnly", documentEditOptions_0.CopyInTextFormatOnly, bool_1: false);
				method_35("CopyWithoutInputFieldStructure", documentEditOptions_0.CopyWithoutInputFieldStructure, bool_1: false);
				method_35("FixSizeWhenInsertImage", documentEditOptions_0.FixSizeWhenInsertImage, bool_1: true);
				method_35("FixWidthWhenInsertTable", documentEditOptions_0.FixWidthWhenInsertTable, bool_1: true);
				method_25("GridLinePreviewText", documentEditOptions_0.GridLinePreviewText);
				method_35("KeepTableWidthWhenInsertDeleteColumn", documentEditOptions_0.KeepTableWidthWhenInsertDeleteColumn, bool_1: true);
				method_35("TabKeyToFirstLineIndent", documentEditOptions_0.TabKeyToFirstLineIndent, bool_1: true);
				method_26("ValueValidateMode", GClass21.smethod_4(documentEditOptions_0.ValueValidateMode), "LostFocus");
			}
		}

		private void method_187(DocumentOptions documentOptions_0)
		{
			int num = 8;
			if (documentOptions_0 != null)
			{
				method_3("DocumentOptions");
				method_188(documentOptions_0);
				method_48();
			}
		}

		private void method_188(DocumentOptions documentOptions_0)
		{
			int num = 11;
			if (documentOptions_0 != null)
			{
				if (documentOptions_0.BehaviorOptions != null)
				{
					method_3("BehaviorOptions");
					method_184(documentOptions_0.BehaviorOptions);
					method_48();
				}
				if (documentOptions_0.EditOptions != null)
				{
					method_3("EditOptions");
					method_186(documentOptions_0.EditOptions);
					method_48();
				}
				if (documentOptions_0.SecurityOptions != null)
				{
					method_3("SecurityOptions");
					method_346(documentOptions_0.SecurityOptions);
					method_48();
				}
				if (documentOptions_0.ViewOptions != null)
				{
					method_3("ViewOptions");
					method_190(documentOptions_0.ViewOptions);
					method_48();
				}
			}
		}

		private void method_189(DocumentViewOptions documentViewOptions_0)
		{
			int num = 8;
			if (documentViewOptions_0 != null)
			{
				method_3("DocumentViewOptions");
				method_190(documentViewOptions_0);
				method_48();
			}
		}

		private void method_190(DocumentViewOptions documentViewOptions_0)
		{
			int num = 1;
			if (documentViewOptions_0 != null)
			{
				method_26("AdornTextBackColorValue", documentViewOptions_0.AdornTextBackColorValue, null);
				method_26("AdornTextVisibility", GClass21.smethod_4(documentViewOptions_0.AdornTextVisibility), "Hidden");
				method_35("AutoZoomDropdownListFontSize", documentViewOptions_0.AutoZoomDropdownListFontSize, bool_1: true);
				method_26("BackgroundTextColorValue", documentViewOptions_0.BackgroundTextColorValue, null);
				method_26("CommentDateFormatString", documentViewOptions_0.CommentDateFormatString, "yyyy-MM-dd HH:mm");
				method_29("CommentFontSize", documentViewOptions_0.CommentFontSize, 10f);
				method_26("DefaultAdornTextType", GClass21.smethod_4(documentViewOptions_0.DefaultAdornTextType), "DataSource");
				method_26("DefaultInputFieldHighlight", GClass21.smethod_4(documentViewOptions_0.DefaultInputFieldHighlight), "Enabled");
				method_26("DefaultInputFieldTextColorValue", documentViewOptions_0.DefaultInputFieldTextColorValue, null);
				method_26("DefaultLineColorForImageEditorValue", documentViewOptions_0.DefaultLineColorForImageEditorValue, null);
				method_26("DropdownListFontName", documentViewOptions_0.DropdownListFontName, null);
				method_29("DropdownListFontSize", documentViewOptions_0.DropdownListFontSize, 0f);
				method_35("EnableEncryptView", documentViewOptions_0.EnableEncryptView, bool_1: true);
				method_35("EnableFieldTextColor", documentViewOptions_0.EnableFieldTextColor, bool_1: false);
				method_35("EnableRightToLeft", documentViewOptions_0.EnableRightToLeft, bool_1: true);
				method_26("FieldBackColorValue", documentViewOptions_0.FieldBackColorValue, null);
				method_26("FieldBorderColorValue", documentViewOptions_0.FieldBorderColorValue, null);
				method_26("FieldFocusedBackColorValue", documentViewOptions_0.FieldFocusedBackColorValue, null);
				method_26("FieldHoverBackColorValue", documentViewOptions_0.FieldHoverBackColorValue, null);
				method_26("FieldInvalidateValueBackColorValue", documentViewOptions_0.FieldInvalidateValueBackColorValue, null);
				method_26("FieldInvalidateValueForeColorValue", documentViewOptions_0.FieldInvalidateValueForeColorValue, null);
				method_26("FieldTextColorValue", documentViewOptions_0.FieldTextColorValue, null);
				method_26("FieldTextPrintColorValue", documentViewOptions_0.FieldTextPrintColorValue, null);
				method_35("HiddenFieldBorderWhenLostFocus", documentViewOptions_0.HiddenFieldBorderWhenLostFocus, bool_1: true);
				method_35("HighlightProtectedContent", documentViewOptions_0.HighlightProtectedContent, bool_1: false);
				method_35("IgnoreFieldBorderWhenPrint", documentViewOptions_0.IgnoreFieldBorderWhenPrint, bool_1: true);
				method_26("LayoutDirection", GClass21.smethod_4(documentViewOptions_0.LayoutDirection), "LeftToRight");
				method_29("MinTableColumnWidth", documentViewOptions_0.MinTableColumnWidth, 50f);
				method_26("NoneBorderColorValue", documentViewOptions_0.NoneBorderColorValue, null);
				method_26("NormalFieldBorderColorValue", documentViewOptions_0.NormalFieldBorderColorValue, null);
				method_35("OldWhitespaceWidth", documentViewOptions_0.OldWhitespaceWidth, bool_1: false);
				method_27("PageMarginLineLength", documentViewOptions_0.PageMarginLineLength, 30);
				method_35("PreserveBackgroundTextWhenPrint", documentViewOptions_0.PreserveBackgroundTextWhenPrint, bool_1: false);
				method_35("PrintBackgroundText", documentViewOptions_0.PrintBackgroundText, bool_1: false);
				method_35("PrintImageAltText", documentViewOptions_0.PrintImageAltText, bool_1: false);
				method_26("ProtectedContentBackColorValue", documentViewOptions_0.ProtectedContentBackColorValue, null);
				method_26("ReadonlyFieldBorderColorValue", documentViewOptions_0.ReadonlyFieldBorderColorValue, null);
				method_35("RichTextBoxCompatibility", documentViewOptions_0.RichTextBoxCompatibility, bool_1: false);
				method_26("SectionBorderVisibility", GClass21.smethod_4(documentViewOptions_0.SectionBorderVisibility), "All");
				method_26("SelectionHighlight", GClass21.smethod_4(documentViewOptions_0.SelectionHighlight), "MaskColor");
				method_26("SelectionHightlightMaskColorValue", documentViewOptions_0.SelectionHightlightMaskColorValue, null);
				method_35("ShowBackgroundCellID", documentViewOptions_0.ShowBackgroundCellID, bool_1: false);
				method_35("ShowCellNoneBorder", documentViewOptions_0.ShowCellNoneBorder, bool_1: true);
				method_35("ShowExpressionFlag", documentViewOptions_0.ShowExpressionFlag, bool_1: true);
				method_35("ShowFieldBorderElement", documentViewOptions_0.ShowFieldBorderElement, bool_1: true);
				method_35("ShowFormButton", documentViewOptions_0.ShowFormButton, bool_1: false);
				method_35("ShowGrayMaskOverDisableContentParty", documentViewOptions_0.ShowGrayMaskOverDisableContentParty, bool_1: true);
				method_35("ShowHeaderBottomLine", documentViewOptions_0.ShowHeaderBottomLine, bool_1: true);
				method_35("ShowInputFieldStateTag", documentViewOptions_0.ShowInputFieldStateTag, bool_1: false);
				method_35("ShowLineNumber", documentViewOptions_0.ShowLineNumber, bool_1: false);
				method_35("ShowPageBreak", documentViewOptions_0.ShowPageBreak, bool_1: false);
				method_35("ShowPageLine", documentViewOptions_0.ShowPageLine, bool_1: true);
				method_35("ShowParagraphFlag", documentViewOptions_0.ShowParagraphFlag, bool_1: true);
				method_29("SpecifyExtenGridLineStep", documentViewOptions_0.SpecifyExtenGridLineStep, 0f);
				method_26("TableCellBorderVisibility", GClass21.smethod_4(documentViewOptions_0.TableCellBorderVisibility), "All");
				method_26("TagColorForModifiedFieldValue", documentViewOptions_0.TagColorForModifiedFieldValue, null);
				method_26("TagColorForNormalFieldValue", documentViewOptions_0.TagColorForNormalFieldValue, null);
				method_26("TagColorForReadonlyFieldValue", documentViewOptions_0.TagColorForReadonlyFieldValue, null);
				method_26("TagColorForValueInvalidateFieldValue", documentViewOptions_0.TagColorForValueInvalidateFieldValue, null);
				method_26("TextRenderStyle", GClass21.smethod_4(documentViewOptions_0.TextRenderStyle), "ClearTypeGridFit");
				method_26("UnEditableFieldBorderColorValue", documentViewOptions_0.UnEditableFieldBorderColorValue, null);
				method_35("UseLanguage2", documentViewOptions_0.UseLanguage2, bool_1: false);
			}
		}

		private void method_191(CopySourceInfo copySourceInfo_0)
		{
			int num = 3;
			if (copySourceInfo_0 != null)
			{
				method_3("CopySourceInfo");
				method_192(copySourceInfo_0);
				method_48();
			}
		}

		private void method_192(CopySourceInfo copySourceInfo_0)
		{
			int num = 5;
			if (copySourceInfo_0 != null)
			{
				method_26("DescPropertyName", copySourceInfo_0.DescPropertyName, null);
				method_35("IgnoreChildElements", copySourceInfo_0.IgnoreChildElements, bool_1: true);
				method_26("SourceID", copySourceInfo_0.SourceID, null);
				method_26("SourcePropertyName", copySourceInfo_0.SourcePropertyName, null);
			}
		}

		private void method_193(DCContentLockInfo dccontentLockInfo_0)
		{
			int num = 18;
			if (dccontentLockInfo_0 != null)
			{
				method_3("DCContentLockInfo");
				method_194(dccontentLockInfo_0);
				method_48();
			}
		}

		private void method_194(DCContentLockInfo dccontentLockInfo_0)
		{
			int num = 9;
			if (dccontentLockInfo_0 != null)
			{
				method_26("AuthorisedUserIDList", dccontentLockInfo_0.AuthorisedUserIDList, null);
				method_38("CreationTime", dccontentLockInfo_0.CreationTime);
				method_26("OwnerUserID", dccontentLockInfo_0.OwnerUserID, null);
			}
		}

		private void method_195(DocumentComment documentComment_0)
		{
			int num = 3;
			if (documentComment_0 != null)
			{
				method_3("Comment");
				method_196(documentComment_0);
				method_48();
			}
		}

		private void method_196(DocumentComment documentComment_0)
		{
			int num = 19;
			if (documentComment_0 != null)
			{
				method_8("Index", documentComment_0.Index);
				method_26("Author", documentComment_0.Author, null);
				method_26("AuthorID", documentComment_0.AuthorID, null);
				method_35("BindingUserTrack", documentComment_0.BindingUserTrack, bool_1: false);
				method_37("CreationTime", documentComment_0.CreationTime, new DateTime(1980, 1, 1));
				method_27("CreatorIndex", documentComment_0.CreatorIndex, -1);
				method_26("Text", documentComment_0.Text, null);
				if (documentComment_0.Attributes != null && documentComment_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in documentComment_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_197(DocumentCommentList documentCommentList_0)
		{
			int num = 2;
			if (documentCommentList_0 != null)
			{
				method_3("DocumentCommentList");
				method_198(documentCommentList_0);
				method_48();
			}
		}

		private void method_198(DocumentCommentList documentCommentList_0)
		{
			int num = 12;
			if (documentCommentList_0 != null)
			{
				foreach (DocumentComment item in documentCommentList_0)
				{
					method_3("Comment");
					method_196(item);
					method_48();
				}
			}
		}

		private void method_199(DocumentContentStyle documentContentStyle_0)
		{
			int num = 10;
			if (documentContentStyle_0 != null)
			{
				method_3("DocumentContentStyle");
				method_200(documentContentStyle_0);
				method_48();
			}
		}

		private void method_200(DocumentContentStyle documentContentStyle_0)
		{
			int num = 13;
			if (documentContentStyle_0 != null)
			{
				method_7("Index", documentContentStyle_0.Index, -1);
				method_26("Align", GClass21.smethod_4(documentContentStyle_0.Align), "Left");
				method_26("BackgroundColor2", documentContentStyle_0.BackgroundColor2String, "Black");
				method_26("BackgroundColor", documentContentStyle_0.BackgroundColorString, "Transparent");
				if (documentContentStyle_0.BackgroundImage != null)
				{
					method_3("BackgroundImage");
					method_76(documentContentStyle_0.BackgroundImage);
					method_48();
				}
				method_26("BackgroundPosition", GClass21.smethod_4(documentContentStyle_0.BackgroundPosition), "TopLeft");
				method_29("BackgroundPositionX", documentContentStyle_0.BackgroundPositionX, 0f);
				method_29("BackgroundPositionY", documentContentStyle_0.BackgroundPositionY, 0f);
				method_35("BackgroundRepeat", documentContentStyle_0.BackgroundRepeat, bool_1: false);
				method_26("BackgroundStyle", GClass21.smethod_4(documentContentStyle_0.BackgroundStyle), "Solid");
				method_35("Bold", documentContentStyle_0.Bold, bool_1: false);
				method_35("BorderBottom", documentContentStyle_0.BorderBottom, bool_1: false);
				method_26("BorderBottomColor", documentContentStyle_0.BorderBottomColorString, "Black");
				method_35("BorderLeft", documentContentStyle_0.BorderLeft, bool_1: false);
				method_26("BorderLeftColor", documentContentStyle_0.BorderLeftColorString, "Black");
				method_35("BorderRight", documentContentStyle_0.BorderRight, bool_1: false);
				method_26("BorderRightColor", documentContentStyle_0.BorderRightColorString, "Black");
				method_29("BorderSpacing", documentContentStyle_0.BorderSpacing, 0f);
				method_26("BorderStyle", GClass21.smethod_4(documentContentStyle_0.BorderStyle), "Solid");
				method_35("BorderTop", documentContentStyle_0.BorderTop, bool_1: false);
				method_26("BorderTopColor", documentContentStyle_0.BorderTopColorString, "Black");
				method_29("BorderWidth", documentContentStyle_0.BorderWidth, 0f);
				method_26("CharacterCircle", GClass21.smethod_4(documentContentStyle_0.CharacterCircle), "None");
				method_26("Color", documentContentStyle_0.ColorString, "Black");
				method_27("CommentIndex", documentContentStyle_0.CommentIndex, -1);
				method_27("CreatorIndex", documentContentStyle_0.CreatorIndex, -1);
				method_26("DefaultValuePropertyNames", documentContentStyle_0.DefaultValuePropertyNames, null);
				method_27("DeleterIndex", documentContentStyle_0.DeleterIndex, -1);
				method_29("FirstLineIndent", documentContentStyle_0.FirstLineIndent, 0f);
				method_35("FixedSpacing", documentContentStyle_0.FixedSpacing, bool_1: false);
				method_26("FontName", documentContentStyle_0.FontName, null);
				method_29("FontSize", documentContentStyle_0.FontSize, 0f);
				method_26("GridLineColor", documentContentStyle_0.GridLineColorString, "Black");
				method_29("GridLineOffsetY", documentContentStyle_0.GridLineOffsetY, 0f);
				method_26("GridLineStyle", GClass21.smethod_4(documentContentStyle_0.GridLineStyle), "Solid");
				method_26("GridLineType", GClass21.smethod_4(documentContentStyle_0.GridLineType), "None");
				method_29("Height", documentContentStyle_0.Height, 0f);
				method_35("Italic", documentContentStyle_0.Italic, bool_1: false);
				method_26("LayoutAlign", GClass21.smethod_4(documentContentStyle_0.LayoutAlign), "EmbedInText");
				method_26("LayoutDirection", GClass21.smethod_4(documentContentStyle_0.LayoutDirection), "Default");
				method_29("LayoutGridHeight", documentContentStyle_0.LayoutGridHeight, 0f);
				method_29("Left", documentContentStyle_0.Left, 0f);
				method_29("LeftIndent", documentContentStyle_0.LeftIndent, 0f);
				method_29("LetterSpacing", documentContentStyle_0.LetterSpacing, 0f);
				method_29("LineSpacing", documentContentStyle_0.LineSpacing, 0f);
				method_26("LineSpacingStyle", GClass21.smethod_4(documentContentStyle_0.LineSpacingStyle), "SpaceSingle");
				method_26("Link", documentContentStyle_0.Link, null);
				method_29("MarginBottom", documentContentStyle_0.MarginBottom, 0f);
				method_29("MarginLeft", documentContentStyle_0.MarginLeft, 0f);
				method_29("MarginRight", documentContentStyle_0.MarginRight, 0f);
				method_29("MarginTop", documentContentStyle_0.MarginTop, 0f);
				method_35("Multiline", documentContentStyle_0.Multiline, bool_1: false);
				method_26("Name", documentContentStyle_0.Name, null);
				method_29("PaddingBottom", documentContentStyle_0.PaddingBottom, 0f);
				method_29("PaddingLeft", documentContentStyle_0.PaddingLeft, 0f);
				method_29("PaddingRight", documentContentStyle_0.PaddingRight, 0f);
				method_29("PaddingTop", documentContentStyle_0.PaddingTop, 0f);
				method_35("PageBreakAfter", documentContentStyle_0.PageBreakAfter, bool_1: false);
				method_35("PageBreakBefore", documentContentStyle_0.PageBreakBefore, bool_1: false);
				method_26("ParagraphListStyle", GClass21.smethod_4(documentContentStyle_0.ParagraphListStyle), "None");
				method_35("ParagraphMultiLevel", documentContentStyle_0.ParagraphMultiLevel, bool_1: false);
				method_27("ParagraphOutlineLevel", documentContentStyle_0.ParagraphOutlineLevel, -1);
				method_26("PrintBackColor", documentContentStyle_0.PrintBackColorString, "");
				method_26("PrintColor", documentContentStyle_0.PrintColorString, "Transparent");
				method_26("ProtectType", GClass21.smethod_4(documentContentStyle_0.ProtectType), "None");
				method_35("RightToLeft", documentContentStyle_0.RightToLeft, bool_1: false);
				method_29("Rotate", documentContentStyle_0.Rotate, 0f);
				method_29("RoundRadio", documentContentStyle_0.RoundRadio, 0f);
				method_29("RTFLineSpacing", documentContentStyle_0.RTFLineSpacing, 0f);
				method_29("Spacing", documentContentStyle_0.Spacing, 0f);
				method_29("SpacingAfterParagraph", documentContentStyle_0.SpacingAfterParagraph, 0f);
				method_29("SpacingBeforeParagraph", documentContentStyle_0.SpacingBeforeParagraph, 0f);
				method_35("Strikeout", documentContentStyle_0.Strikeout, bool_1: false);
				method_35("Subscript", documentContentStyle_0.Subscript, bool_1: false);
				method_35("Superscript", documentContentStyle_0.Superscript, bool_1: false);
				method_27("TitleLevel", documentContentStyle_0.TitleLevel, -1);
				method_29("Top", documentContentStyle_0.Top, 0f);
				method_35("Underline", documentContentStyle_0.Underline, bool_1: false);
				method_35("VertialText", documentContentStyle_0.VertialText, bool_1: false);
				method_26("VerticalAlign", GClass21.smethod_4(documentContentStyle_0.VerticalAlign), "Top");
				method_26("Visibility", GClass21.smethod_4(documentContentStyle_0.Visibility), "All");
				method_35("Visible", documentContentStyle_0.Visible, bool_1: true);
				method_35("VisibleInDirectory", documentContentStyle_0.VisibleInDirectory, bool_1: true);
				method_29("Width", documentContentStyle_0.Width, 0f);
				method_29("Zoom", documentContentStyle_0.Zoom, 1f);
			}
		}

		private void method_201(DocumentContentStyleContainer documentContentStyleContainer_0)
		{
			int num = 13;
			if (documentContentStyleContainer_0 != null)
			{
				method_3("DocumentContentStyleContainer");
				method_202(documentContentStyleContainer_0);
				method_48();
			}
		}

		private void method_202(DocumentContentStyleContainer documentContentStyleContainer_0)
		{
			int num = 10;
			if (documentContentStyleContainer_0 != null)
			{
				if (documentContentStyleContainer_0.Default != null)
				{
					method_3("Default");
					method_64(documentContentStyleContainer_0.Default);
					method_48();
				}
				if (documentContentStyleContainer_0.Styles != null && documentContentStyleContainer_0.Styles.Count > 0)
				{
					method_3("Styles");
					foreach (DocumentContentStyle style in documentContentStyleContainer_0.Styles)
					{
						method_3("Style");
						method_200(style);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_203(DocumentInfo documentInfo_0)
		{
			int num = 15;
			if (documentInfo_0 != null)
			{
				method_3("DocumentInfo");
				method_204(documentInfo_0);
				method_48();
			}
		}

		private void method_204(DocumentInfo documentInfo_0)
		{
			int num = 8;
			if (documentInfo_0 != null)
			{
				method_26("Author", documentInfo_0.Author, null);
				method_26("AuthorName", documentInfo_0.AuthorName, null);
				method_27("AuthorPermissionLevel", documentInfo_0.AuthorPermissionLevel, 0);
				method_26("Comment", documentInfo_0.Comment, null);
				method_38("CreationTime", documentInfo_0.CreationTime);
				method_26("DepartmentID", documentInfo_0.DepartmentID, null);
				method_26("DepartmentName", documentInfo_0.DepartmentName, null);
				method_26("Description", documentInfo_0.Description, null);
				method_27("DocumentEditState", documentInfo_0.DocumentEditState, 0);
				method_26("DocumentFormat", documentInfo_0.DocumentFormat, null);
				method_27("DocumentProcessState", documentInfo_0.DocumentProcessState, 0);
				method_26("DocumentType", documentInfo_0.DocumentType, null);
				method_27("EditMinute", documentInfo_0.EditMinute, 0);
				method_29("FieldBorderElementWidth", documentInfo_0.FieldBorderElementWidth, 1f);
				method_27("HeightInPrintJob", documentInfo_0.HeightInPrintJob, 0);
				method_26("ID", documentInfo_0.ID, null);
				method_35("IsTemplate", documentInfo_0.IsTemplate, bool_1: false);
				method_27("KBEntryRangeMask", documentInfo_0.KBEntryRangeMask, 0);
				method_38("LastModifiedTime", documentInfo_0.LastModifiedTime);
				method_38("LastPrintTime", documentInfo_0.LastPrintTime);
				method_26("LicenseText", documentInfo_0.LicenseText, null);
				method_26("MRID", documentInfo_0.MRID, null);
				method_27("NumOfPage", documentInfo_0.NumOfPage, 0);
				method_26("Operator", documentInfo_0.Operator, null);
				method_35("Printable", documentInfo_0.Printable, bool_1: true);
				method_35("Readonly", documentInfo_0.Readonly, bool_1: false);
				method_26("ShowHeaderBottomLine", GClass21.smethod_4(documentInfo_0.ShowHeaderBottomLine), "Inherit");
				method_27("StartPositionInPringJob", documentInfo_0.StartPositionInPringJob, 0);
				if (documentInfo_0.SubDocumentSettings != null)
				{
					method_3("SubDocumentSettings");
					method_246(documentInfo_0.SubDocumentSettings);
					method_48();
				}
				method_27("TimeoutHours", documentInfo_0.TimeoutHours, 0);
				method_26("Title", documentInfo_0.Title, null);
				method_35("UseLanguage2", documentInfo_0.UseLanguage2, bool_1: false);
				method_26("Version", documentInfo_0.Version, null);
			}
		}

		private void method_205(FileContentSource fileContentSource_0)
		{
			int num = 17;
			if (fileContentSource_0 != null)
			{
				method_3("FileContentSource");
				method_206(fileContentSource_0);
				method_48();
			}
		}

		private void method_206(FileContentSource fileContentSource_0)
		{
			int num = 8;
			if (fileContentSource_0 != null)
			{
				method_26("FileName", fileContentSource_0.FileName, null);
				method_26("FileSystemName", fileContentSource_0.FileSystemName, null);
				method_26("Format", fileContentSource_0.Format, null);
				method_26("Range", fileContentSource_0.Range, null);
			}
		}

		private void method_207(InputFieldListItem inputFieldListItem_0)
		{
			int num = 9;
			if (inputFieldListItem_0 != null)
			{
				method_3("InputFieldListItem");
				method_208(inputFieldListItem_0);
				method_48();
			}
		}

		private void method_208(InputFieldListItem inputFieldListItem_0)
		{
			int num = 3;
			if (inputFieldListItem_0 != null)
			{
				method_26("Tag", inputFieldListItem_0.Tag, null);
				method_26("Text", inputFieldListItem_0.Text, null);
				method_26("Value", inputFieldListItem_0.Value, null);
			}
		}

		private void method_209(InputFieldListItemList inputFieldListItemList_0)
		{
			int num = 16;
			if (inputFieldListItemList_0 != null)
			{
				method_3("InputFieldListItemList");
				method_210(inputFieldListItemList_0);
				method_48();
			}
		}

		private void method_210(InputFieldListItemList inputFieldListItemList_0)
		{
			int num = 9;
			if (inputFieldListItemList_0 != null)
			{
				foreach (InputFieldListItem item in inputFieldListItemList_0)
				{
					method_3("InputFieldListItem");
					method_208(item);
					method_48();
				}
			}
		}

		private void method_211(InputFieldSettings inputFieldSettings_0)
		{
			int num = 19;
			if (inputFieldSettings_0 != null)
			{
				method_3("InputFieldSettings");
				method_212(inputFieldSettings_0);
				method_48();
			}
		}

		private void method_212(InputFieldSettings inputFieldSettings_0)
		{
			int num = 19;
			if (inputFieldSettings_0 != null)
			{
				method_35("DynamicListItems", inputFieldSettings_0.DynamicListItems, bool_1: false);
				method_26("EditStyle", GClass21.smethod_4(inputFieldSettings_0.EditStyle), "Text");
				method_35("GetValueOrderByTime", inputFieldSettings_0.GetValueOrderByTime, bool_1: false);
				if (inputFieldSettings_0.ListSource != null)
				{
					method_3("ListSource");
					method_174(inputFieldSettings_0.ListSource);
					method_48();
				}
				method_26("ListValueFormatString", inputFieldSettings_0.ListValueFormatString, null);
				method_26("ListValueSeparatorChar", inputFieldSettings_0.ListValueSeparatorChar, ",");
				method_35("MultiColumn", inputFieldSettings_0.MultiColumn, bool_1: false);
				method_35("MultiSelect", inputFieldSettings_0.MultiSelect, bool_1: false);
				method_35("RepulsionForGroup", inputFieldSettings_0.RepulsionForGroup, bool_1: false);
				if (inputFieldSettings_0.ListItems != null && inputFieldSettings_0.ListItems.Count > 0)
				{
					method_3("ListItems");
					foreach (InputFieldListItem listItem in inputFieldSettings_0.ListItems)
					{
						method_3("Item");
						method_208(listItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_213(LocalConfig localConfig_0)
		{
			int num = 18;
			if (localConfig_0 != null)
			{
				method_3("LocalConfig");
				method_214(localConfig_0);
				method_48();
			}
		}

		private void method_214(LocalConfig localConfig_0)
		{
			int num = 16;
			if (localConfig_0 != null)
			{
				method_35("OldWhitespaceWidth", localConfig_0.OldWhitespaceWidth, bool_1: false);
			}
		}

		private void method_215(MotherTemplateInfo motherTemplateInfo_0)
		{
			int num = 4;
			if (motherTemplateInfo_0 != null)
			{
				method_3("MotherTemplateInfo");
				method_216(motherTemplateInfo_0);
				method_48();
			}
		}

		private void method_216(MotherTemplateInfo motherTemplateInfo_0)
		{
			int num = 8;
			if (motherTemplateInfo_0 != null)
			{
				method_26("FileName", motherTemplateInfo_0.FileName, null);
				method_26("FileSystemName", motherTemplateInfo_0.FileSystemName, null);
				method_26("Format", motherTemplateInfo_0.Format, null);
				method_35("ImportFooter", motherTemplateInfo_0.ImportFooter, bool_1: true);
				method_35("ImportHeader", motherTemplateInfo_0.ImportHeader, bool_1: true);
				method_35("ImportPageSettings", motherTemplateInfo_0.ImportPageSettings, bool_1: true);
			}
		}

		private void method_217(ObjectParameter objectParameter_0)
		{
			int num = 13;
			if (objectParameter_0 != null)
			{
				method_3("ObjectParameter");
				method_218(objectParameter_0);
				method_48();
			}
		}

		private void method_218(ObjectParameter objectParameter_0)
		{
			int num = 3;
			if (objectParameter_0 != null)
			{
				method_6("Name", objectParameter_0.Name, null);
				method_52(objectParameter_0.Value);
			}
		}

		private void method_219(ObjectParameterList objectParameterList_0)
		{
			int num = 14;
			if (objectParameterList_0 != null)
			{
				method_3("ObjectParameterList");
				method_220(objectParameterList_0);
				method_48();
			}
		}

		private void method_220(ObjectParameterList objectParameterList_0)
		{
			int num = 0;
			if (objectParameterList_0 != null)
			{
				foreach (ObjectParameter item in objectParameterList_0)
				{
					method_3("ObjectParameter");
					method_218(item);
					method_48();
				}
			}
		}

		private void method_221(PageContentVersionInfo pageContentVersionInfo_0)
		{
			int num = 11;
			if (pageContentVersionInfo_0 != null)
			{
				method_3("PageContentVersionInfo");
				method_222(pageContentVersionInfo_0);
				method_48();
			}
		}

		private void method_222(PageContentVersionInfo pageContentVersionInfo_0)
		{
			int num = 12;
			if (pageContentVersionInfo_0 != null)
			{
				method_8("PageIndex", pageContentVersionInfo_0.PageIndex);
				method_6("Version", pageContentVersionInfo_0.Version, null);
			}
		}

		private void method_223(PageContentVersionInfoList pageContentVersionInfoList_0)
		{
			int num = 6;
			if (pageContentVersionInfoList_0 != null)
			{
				method_3("PageContentVersionInfoList");
				method_224(pageContentVersionInfoList_0);
				method_48();
			}
		}

		private void method_224(PageContentVersionInfoList pageContentVersionInfoList_0)
		{
			int num = 11;
			if (pageContentVersionInfoList_0 != null)
			{
				foreach (PageContentVersionInfo item in pageContentVersionInfoList_0)
				{
					method_3("PageContentVersionInfo");
					method_222(item);
					method_48();
				}
			}
		}

		private void method_225(PageImageInfo pageImageInfo_0)
		{
			int num = 3;
			if (pageImageInfo_0 != null)
			{
				method_3("PageImageInfo");
				method_226(pageImageInfo_0);
				method_48();
			}
		}

		private void method_226(PageImageInfo pageImageInfo_0)
		{
			int num = 0;
			if (pageImageInfo_0 != null)
			{
				if (pageImageInfo_0.Image != null)
				{
					method_3("Image");
					method_76(pageImageInfo_0.Image);
					method_48();
				}
				method_27("PageIndex", pageImageInfo_0.PageIndex, 0);
			}
		}

		private void method_227(PageImageInfoList pageImageInfoList_0)
		{
			int num = 13;
			if (pageImageInfoList_0 != null)
			{
				method_3("PageImageInfoList");
				method_228(pageImageInfoList_0);
				method_48();
			}
		}

		private void method_228(PageImageInfoList pageImageInfoList_0)
		{
			int num = 19;
			if (pageImageInfoList_0 != null)
			{
				foreach (PageImageInfo item in pageImageInfoList_0)
				{
					method_3("PageImageInfo");
					method_226(item);
					method_48();
				}
			}
		}

		private void method_229(PageLabelText pageLabelText_0)
		{
			int num = 16;
			if (pageLabelText_0 != null)
			{
				method_3("PageLabelText");
				method_230(pageLabelText_0);
				method_48();
			}
		}

		private void method_230(PageLabelText pageLabelText_0)
		{
			int num = 10;
			if (pageLabelText_0 != null)
			{
				method_27("PageIndex", pageLabelText_0.PageIndex, 0);
				method_26("Text", pageLabelText_0.Text, null);
			}
		}

		private void method_231(PageLabelTextList pageLabelTextList_0)
		{
			int num = 8;
			if (pageLabelTextList_0 != null)
			{
				method_3("PageLabelTextList");
				method_232(pageLabelTextList_0);
				method_48();
			}
		}

		private void method_232(PageLabelTextList pageLabelTextList_0)
		{
			int num = 15;
			if (pageLabelTextList_0 != null)
			{
				foreach (PageLabelText item in pageLabelTextList_0)
				{
					method_3("PageLabelText");
					method_230(item);
					method_48();
				}
			}
		}

		private void method_233(PropertyExpressionInfo propertyExpressionInfo_0)
		{
			int num = 8;
			if (propertyExpressionInfo_0 != null)
			{
				method_3("PropertyExpressionInfo");
				method_234(propertyExpressionInfo_0);
				method_48();
			}
		}

		private void method_234(PropertyExpressionInfo propertyExpressionInfo_0)
		{
			int num = 15;
			if (propertyExpressionInfo_0 != null)
			{
				method_15("AllowChainReaction", propertyExpressionInfo_0.AllowChainReaction, bool_1: true);
				method_6("Name", propertyExpressionInfo_0.Name, null);
				method_52(propertyExpressionInfo_0.Expression);
			}
		}

		private void method_235(PropertyExpressionInfoList propertyExpressionInfoList_0)
		{
			int num = 9;
			if (propertyExpressionInfoList_0 != null)
			{
				method_3("PropertyExpressionInfoList");
				method_236(propertyExpressionInfoList_0);
				method_48();
			}
		}

		private void method_236(PropertyExpressionInfoList propertyExpressionInfoList_0)
		{
			int num = 17;
			if (propertyExpressionInfoList_0 != null)
			{
				foreach (PropertyExpressionInfo item in propertyExpressionInfoList_0)
				{
					method_3("PropertyExpressionInfo");
					method_234(item);
					method_48();
				}
			}
		}

		private void method_237(RepeatedImageValue repeatedImageValue_0)
		{
			int num = 11;
			if (repeatedImageValue_0 != null)
			{
				method_3("RepeatedImageValue");
				method_238(repeatedImageValue_0);
				method_48();
			}
		}

		private void method_238(RepeatedImageValue repeatedImageValue_0)
		{
			int num = 12;
			if (repeatedImageValue_0 != null)
			{
				method_7("ReferenceCount", repeatedImageValue_0.ReferenceCount, 0);
				method_7("ValueIndex", repeatedImageValue_0.ValueIndex, 0);
				method_29("HorizontalResolution", repeatedImageValue_0.HorizontalResolution, 0f);
				method_26("ImageDataBase64String", repeatedImageValue_0.ImageDataBase64String, null);
				method_29("VerticalResolution", repeatedImageValue_0.VerticalResolution, 0f);
			}
		}

		private void method_239(RepeatedImageValueList repeatedImageValueList_0)
		{
			int num = 6;
			if (repeatedImageValueList_0 != null)
			{
				method_3("RepeatedImageValueList");
				method_240(repeatedImageValueList_0);
				method_48();
			}
		}

		private void method_240(RepeatedImageValueList repeatedImageValueList_0)
		{
			int num = 6;
			if (repeatedImageValueList_0 != null)
			{
				foreach (RepeatedImageValue item in repeatedImageValueList_0)
				{
					method_3("RepeatedImageValue");
					method_238(item);
					method_48();
				}
			}
		}

		private void method_241(SpecifyPageIndexInfo specifyPageIndexInfo_0)
		{
			int num = 3;
			if (specifyPageIndexInfo_0 != null)
			{
				method_3("SpecifyPageIndexInfo");
				method_242(specifyPageIndexInfo_0);
				method_48();
			}
		}

		private void method_242(SpecifyPageIndexInfo specifyPageIndexInfo_0)
		{
			int num = 5;
			if (specifyPageIndexInfo_0 != null)
			{
				method_7("RawPageIndex", specifyPageIndexInfo_0.RawPageIndex, 1);
				method_7("SpecifyPageIndex", specifyPageIndexInfo_0.SpecifyPageIndex, -1);
			}
		}

		private void method_243(SpecifyPageIndexInfoList specifyPageIndexInfoList_0)
		{
			int num = 14;
			if (specifyPageIndexInfoList_0 != null)
			{
				method_3("SpecifyPageIndexInfoList");
				method_244(specifyPageIndexInfoList_0);
				method_48();
			}
		}

		private void method_244(SpecifyPageIndexInfoList specifyPageIndexInfoList_0)
		{
			int num = 19;
			if (specifyPageIndexInfoList_0 != null)
			{
				foreach (SpecifyPageIndexInfo item in specifyPageIndexInfoList_0)
				{
					method_3("SpecifyPageIndexInfo");
					method_242(item);
					method_48();
				}
			}
		}

		private void method_245(SubDocumentSettings subDocumentSettings_0)
		{
			int num = 1;
			if (subDocumentSettings_0 != null)
			{
				method_3("SubDocumentSettings");
				method_246(subDocumentSettings_0);
				method_48();
			}
		}

		private void method_246(SubDocumentSettings subDocumentSettings_0)
		{
			int num = 3;
			if (subDocumentSettings_0 != null)
			{
				method_35("AllowSave", subDocumentSettings_0.AllowSave, bool_1: true);
				method_26("BackColorValue", subDocumentSettings_0.BackColorValue, null);
				method_26("BorderColorValue", subDocumentSettings_0.BorderColorValue, null);
				method_35("EnablePermission", subDocumentSettings_0.EnablePermission, bool_1: false);
				method_35("Locked", subDocumentSettings_0.Locked, bool_1: false);
				method_35("NewPage", subDocumentSettings_0.NewPage, bool_1: false);
				method_35("Readonly", subDocumentSettings_0.Readonly, bool_1: false);
				method_29("SubDocumentSpacing", subDocumentSettings_0.SubDocumentSpacing, 0f);
			}
		}

		private void method_247(XAttribute xattribute_0)
		{
			int num = 6;
			if (xattribute_0 != null)
			{
				method_3("XAttribute");
				method_248(xattribute_0);
				method_48();
			}
		}

		private void method_248(XAttribute xattribute_0)
		{
			int num = 2;
			if (xattribute_0 != null)
			{
				method_26("Name", xattribute_0.Name, null);
				method_26("Value", xattribute_0.Value, null);
			}
		}

		private void method_249(XAttributeList xattributeList_0)
		{
			int num = 4;
			if (xattributeList_0 != null)
			{
				method_3("XAttributeList");
				method_250(xattributeList_0);
				method_48();
			}
		}

		private void method_250(XAttributeList xattributeList_0)
		{
			int num = 14;
			if (xattributeList_0 != null)
			{
				foreach (XAttribute item in xattributeList_0)
				{
					method_3("XAttribute");
					method_248(item);
					method_48();
				}
			}
		}

		private void method_251(XTextAccountingNumberElement xtextAccountingNumberElement_0)
		{
			int num = 5;
			if (xtextAccountingNumberElement_0 != null)
			{
				method_3("XAccountingNumber");
				method_252(xtextAccountingNumberElement_0);
				method_48();
			}
		}

		private void method_252(XTextAccountingNumberElement xtextAccountingNumberElement_0)
		{
			int num = 19;
			if (xtextAccountingNumberElement_0 != null)
			{
				method_7("StyleIndex", xtextAccountingNumberElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextAccountingNumberElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextAccountingNumberElement_0.AcceptTab, bool_1: false);
				method_26("Alignment", GClass21.smethod_4(xtextAccountingNumberElement_0.Alignment), "Near");
				method_35("AutoExitEditMode", xtextAccountingNumberElement_0.AutoExitEditMode, bool_1: true);
				method_26("AutoHideMode", GClass21.smethod_4(xtextAccountingNumberElement_0.AutoHideMode), "None");
				method_26("BackgroundText", xtextAccountingNumberElement_0.BackgroundText, null);
				method_26("BackgroundTextColor", xtextAccountingNumberElement_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextAccountingNumberElement_0.BorderElementColorValue, null);
				method_26("BorderVisible", GClass21.smethod_4(xtextAccountingNumberElement_0.BorderVisible), "Default");
				if (xtextAccountingNumberElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextAccountingNumberElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextAccountingNumberElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextAccountingNumberElement_0.ContentReadonlyExpression, null);
				if (xtextAccountingNumberElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextAccountingNumberElement_0.CopySource);
					method_48();
				}
				method_26("DefaultEventExpression", xtextAccountingNumberElement_0.DefaultEventExpression, null);
				method_35("Deleteable", xtextAccountingNumberElement_0.Deleteable, bool_1: true);
				method_27("Digitals", xtextAccountingNumberElement_0.Digitals, 11);
				if (xtextAccountingNumberElement_0.DisplayFormat != null)
				{
					method_3("DisplayFormat");
					method_62(xtextAccountingNumberElement_0.DisplayFormat);
					method_48();
				}
				method_26("ElementIDForEditableDependent", xtextAccountingNumberElement_0.ElementIDForEditableDependent, null);
				method_35("Enabled", xtextAccountingNumberElement_0.Enabled, bool_1: true);
				method_26("EnableHighlight", GClass21.smethod_4(xtextAccountingNumberElement_0.EnableHighlight), "Enabled");
				method_26("EnablePermission", GClass21.smethod_4(xtextAccountingNumberElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextAccountingNumberElement_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextAccountingNumberElement_0.EndBorderText, null);
				method_26("EventTemplateName", xtextAccountingNumberElement_0.EventTemplateName, null);
				method_29("Height", xtextAccountingNumberElement_0.Height, 125f);
				method_26("ID", xtextAccountingNumberElement_0.ID, null);
				method_26("InnerValue", xtextAccountingNumberElement_0.InnerValue, null);
				method_26("JavaScriptForClick", xtextAccountingNumberElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextAccountingNumberElement_0.JavaScriptForDoubleClick, null);
				method_26("LabelText", xtextAccountingNumberElement_0.LabelText, null);
				method_26("MoveFocusHotKey", GClass21.smethod_4(xtextAccountingNumberElement_0.MoveFocusHotKey), "Default");
				method_26("Name", xtextAccountingNumberElement_0.Name, null);
				method_26("PrintBackgroundText", GClass21.smethod_4(xtextAccountingNumberElement_0.PrintBackgroundText), "Inherit");
				method_35("PrintGrid", xtextAccountingNumberElement_0.PrintGrid, bool_1: true);
				method_26("PrintVisibility", GClass21.smethod_4(xtextAccountingNumberElement_0.PrintVisibility), "Visible");
				method_26("RuntimeMoveFocusHotKey", GClass21.smethod_4(xtextAccountingNumberElement_0.RuntimeMoveFocusHotKey), "None");
				method_26("SelectedSpellCode", xtextAccountingNumberElement_0.SelectedSpellCode, null);
				method_35("ShowGrid", xtextAccountingNumberElement_0.ShowGrid, bool_1: true);
				method_29("SpecifyWidth", xtextAccountingNumberElement_0.SpecifyWidth, 0f);
				method_26("StartBorderText", xtextAccountingNumberElement_0.StartBorderText, null);
				method_27("TabIndex", xtextAccountingNumberElement_0.TabIndex, 0);
				method_35("TabStop", xtextAccountingNumberElement_0.TabStop, bool_1: true);
				method_26("TextColor", xtextAccountingNumberElement_0.TextColorString, null);
				method_26("ToolTip", xtextAccountingNumberElement_0.ToolTip, null);
				method_26("UnitMode", GClass21.smethod_4(xtextAccountingNumberElement_0.UnitMode), "LowerCaseChinese");
				method_26("UnitText", xtextAccountingNumberElement_0.UnitText, null);
				method_35("UserEditable", xtextAccountingNumberElement_0.UserEditable, bool_1: true);
				method_27("UserFlags", xtextAccountingNumberElement_0.UserFlags, 0);
				if (xtextAccountingNumberElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextAccountingNumberElement_0.ValidateStyle);
					method_48();
				}
				if (xtextAccountingNumberElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextAccountingNumberElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextAccountingNumberElement_0.ValueExpression, null);
				method_26("ViewEncryptType", GClass21.smethod_4(xtextAccountingNumberElement_0.ViewEncryptType), "None");
				method_35("Visible", xtextAccountingNumberElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextAccountingNumberElement_0.VisibleExpression, null);
				method_29("Width", xtextAccountingNumberElement_0.Width, 600f);
				if (xtextAccountingNumberElement_0.Attributes != null && xtextAccountingNumberElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextAccountingNumberElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextAccountingNumberElement_0.ElementsForSerialize != null && xtextAccountingNumberElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextAccountingNumberElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextAccountingNumberElement_0.EventExpressions != null && xtextAccountingNumberElement_0.EventExpressions.Count > 0)
				{
					method_3("EventExpressions");
					foreach (EventExpressionInfo eventExpression in xtextAccountingNumberElement_0.EventExpressions)
					{
						method_3("Expression");
						method_334(eventExpression);
						method_48();
					}
					method_48();
				}
				if (xtextAccountingNumberElement_0.Expressions != null && xtextAccountingNumberElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextAccountingNumberElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextAccountingNumberElement_0.PropertyExpressions != null && xtextAccountingNumberElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextAccountingNumberElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextAccountingNumberElement_0.ScriptItems != null && xtextAccountingNumberElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextAccountingNumberElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_253(XTextBarcodeFieldElement xtextBarcodeFieldElement_0)
		{
			int num = 17;
			if (xtextBarcodeFieldElement_0 != null)
			{
				method_3("XBarcodeField");
				method_254(xtextBarcodeFieldElement_0);
				method_48();
			}
		}

		private void method_254(XTextBarcodeFieldElement xtextBarcodeFieldElement_0)
		{
			int num = 9;
			if (xtextBarcodeFieldElement_0 != null)
			{
				method_7("StyleIndex", xtextBarcodeFieldElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextBarcodeFieldElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextBarcodeFieldElement_0.AcceptTab, bool_1: false);
				method_26("Alignment", GClass21.smethod_4(xtextBarcodeFieldElement_0.Alignment), "Near");
				method_35("AutoExitEditMode", xtextBarcodeFieldElement_0.AutoExitEditMode, bool_1: true);
				method_26("AutoHideMode", GClass21.smethod_4(xtextBarcodeFieldElement_0.AutoHideMode), "None");
				method_26("BackgroundText", xtextBarcodeFieldElement_0.BackgroundText, null);
				method_26("BackgroundTextColor", xtextBarcodeFieldElement_0.BackgroundTextColorString, null);
				method_26("BarcodeStyle", GClass21.smethod_4(xtextBarcodeFieldElement_0.BarcodeStyle), "Code128C");
				method_26("BorderElementColorValue", xtextBarcodeFieldElement_0.BorderElementColorValue, null);
				method_26("BorderVisible", GClass21.smethod_4(xtextBarcodeFieldElement_0.BorderVisible), "Default");
				if (xtextBarcodeFieldElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextBarcodeFieldElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextBarcodeFieldElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextBarcodeFieldElement_0.ContentReadonlyExpression, null);
				if (xtextBarcodeFieldElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextBarcodeFieldElement_0.CopySource);
					method_48();
				}
				method_26("DefaultEventExpression", xtextBarcodeFieldElement_0.DefaultEventExpression, null);
				method_35("Deleteable", xtextBarcodeFieldElement_0.Deleteable, bool_1: true);
				if (xtextBarcodeFieldElement_0.DisplayFormat != null)
				{
					method_3("DisplayFormat");
					method_62(xtextBarcodeFieldElement_0.DisplayFormat);
					method_48();
				}
				method_26("ElementIDForEditableDependent", xtextBarcodeFieldElement_0.ElementIDForEditableDependent, null);
				method_35("Enabled", xtextBarcodeFieldElement_0.Enabled, bool_1: true);
				method_26("EnableHighlight", GClass21.smethod_4(xtextBarcodeFieldElement_0.EnableHighlight), "Enabled");
				method_26("EnablePermission", GClass21.smethod_4(xtextBarcodeFieldElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextBarcodeFieldElement_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextBarcodeFieldElement_0.EndBorderText, null);
				method_26("EventTemplateName", xtextBarcodeFieldElement_0.EventTemplateName, null);
				method_29("Height", xtextBarcodeFieldElement_0.Height, 125f);
				method_26("ID", xtextBarcodeFieldElement_0.ID, null);
				method_26("InnerValue", xtextBarcodeFieldElement_0.InnerValue, null);
				method_26("JavaScriptForClick", xtextBarcodeFieldElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextBarcodeFieldElement_0.JavaScriptForDoubleClick, null);
				method_26("LabelText", xtextBarcodeFieldElement_0.LabelText, null);
				method_29("MinBarWidth", xtextBarcodeFieldElement_0.MinBarWidth, 7f);
				method_26("MoveFocusHotKey", GClass21.smethod_4(xtextBarcodeFieldElement_0.MoveFocusHotKey), "Default");
				method_26("Name", xtextBarcodeFieldElement_0.Name, null);
				method_26("PrintBackgroundText", GClass21.smethod_4(xtextBarcodeFieldElement_0.PrintBackgroundText), "Inherit");
				method_26("PrintVisibility", GClass21.smethod_4(xtextBarcodeFieldElement_0.PrintVisibility), "Visible");
				method_26("RuntimeMoveFocusHotKey", GClass21.smethod_4(xtextBarcodeFieldElement_0.RuntimeMoveFocusHotKey), "None");
				method_26("SelectedSpellCode", xtextBarcodeFieldElement_0.SelectedSpellCode, null);
				method_35("ShowText", xtextBarcodeFieldElement_0.ShowText, bool_1: true);
				method_29("SpecifyWidth", xtextBarcodeFieldElement_0.SpecifyWidth, 0f);
				method_26("StartBorderText", xtextBarcodeFieldElement_0.StartBorderText, null);
				method_27("TabIndex", xtextBarcodeFieldElement_0.TabIndex, 0);
				method_35("TabStop", xtextBarcodeFieldElement_0.TabStop, bool_1: true);
				method_26("TextAlignment", GClass21.smethod_4(xtextBarcodeFieldElement_0.TextAlignment), "Center");
				method_26("TextColor", xtextBarcodeFieldElement_0.TextColorString, null);
				method_26("ToolTip", xtextBarcodeFieldElement_0.ToolTip, null);
				method_26("UnitText", xtextBarcodeFieldElement_0.UnitText, null);
				method_35("UserEditable", xtextBarcodeFieldElement_0.UserEditable, bool_1: true);
				method_27("UserFlags", xtextBarcodeFieldElement_0.UserFlags, 0);
				if (xtextBarcodeFieldElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextBarcodeFieldElement_0.ValidateStyle);
					method_48();
				}
				if (xtextBarcodeFieldElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextBarcodeFieldElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextBarcodeFieldElement_0.ValueExpression, null);
				method_26("ViewEncryptType", GClass21.smethod_4(xtextBarcodeFieldElement_0.ViewEncryptType), "None");
				method_35("Visible", xtextBarcodeFieldElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextBarcodeFieldElement_0.VisibleExpression, null);
				if (xtextBarcodeFieldElement_0.Attributes != null && xtextBarcodeFieldElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextBarcodeFieldElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextBarcodeFieldElement_0.ElementsForSerialize != null && xtextBarcodeFieldElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextBarcodeFieldElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextBarcodeFieldElement_0.EventExpressions != null && xtextBarcodeFieldElement_0.EventExpressions.Count > 0)
				{
					method_3("EventExpressions");
					foreach (EventExpressionInfo eventExpression in xtextBarcodeFieldElement_0.EventExpressions)
					{
						method_3("Expression");
						method_334(eventExpression);
						method_48();
					}
					method_48();
				}
				if (xtextBarcodeFieldElement_0.Expressions != null && xtextBarcodeFieldElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextBarcodeFieldElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextBarcodeFieldElement_0.PropertyExpressions != null && xtextBarcodeFieldElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextBarcodeFieldElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextBarcodeFieldElement_0.ScriptItems != null && xtextBarcodeFieldElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextBarcodeFieldElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_255(XTextBeanFieldElement xtextBeanFieldElement_0)
		{
			int num = 1;
			if (xtextBeanFieldElement_0 != null)
			{
				method_3("XBean");
				method_256(xtextBeanFieldElement_0);
				method_48();
			}
		}

		private void method_256(XTextBeanFieldElement xtextBeanFieldElement_0)
		{
			int num = 0;
			if (xtextBeanFieldElement_0 != null)
			{
				method_7("StyleIndex", xtextBeanFieldElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextBeanFieldElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextBeanFieldElement_0.AcceptTab, bool_1: false);
				method_26("AutoHideMode", GClass21.smethod_4(xtextBeanFieldElement_0.AutoHideMode), "None");
				method_26("BackgroundTextColor", xtextBeanFieldElement_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextBeanFieldElement_0.BorderElementColorValue, null);
				if (xtextBeanFieldElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextBeanFieldElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextBeanFieldElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextBeanFieldElement_0.ContentReadonlyExpression, null);
				if (xtextBeanFieldElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextBeanFieldElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextBeanFieldElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextBeanFieldElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextBeanFieldElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextBeanFieldElement_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextBeanFieldElement_0.EndBorderText, null);
				method_26("EventTemplateName", xtextBeanFieldElement_0.EventTemplateName, null);
				method_26("ID", xtextBeanFieldElement_0.ID, null);
				method_26("JavaScriptForClick", xtextBeanFieldElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextBeanFieldElement_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextBeanFieldElement_0.PrintVisibility), "Visible");
				method_26("StartBorderText", xtextBeanFieldElement_0.StartBorderText, null);
				method_26("TextColor", xtextBeanFieldElement_0.TextColorString, null);
				method_27("UserFlags", xtextBeanFieldElement_0.UserFlags, 0);
				if (xtextBeanFieldElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextBeanFieldElement_0.ValidateStyle);
					method_48();
				}
				if (xtextBeanFieldElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextBeanFieldElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextBeanFieldElement_0.ValueExpression, null);
				method_35("Visible", xtextBeanFieldElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextBeanFieldElement_0.VisibleExpression, null);
				if (xtextBeanFieldElement_0.Attributes != null && xtextBeanFieldElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextBeanFieldElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextBeanFieldElement_0.ElementsForSerialize != null && xtextBeanFieldElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextBeanFieldElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextBeanFieldElement_0.Expressions != null && xtextBeanFieldElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextBeanFieldElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextBeanFieldElement_0.PropertyExpressions != null && xtextBeanFieldElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextBeanFieldElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextBeanFieldElement_0.ScriptItems != null && xtextBeanFieldElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextBeanFieldElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_257(XTextBookmark xtextBookmark_0)
		{
			int num = 3;
			if (xtextBookmark_0 != null)
			{
				method_3("XBookMark");
				method_258(xtextBookmark_0);
				method_48();
			}
		}

		private void method_258(XTextBookmark xtextBookmark_0)
		{
			int num = 3;
			if (xtextBookmark_0 != null)
			{
				method_7("StyleIndex", xtextBookmark_0.StyleIndex, -1);
				method_26("ID", xtextBookmark_0.ID, null);
				method_25("Name", xtextBookmark_0.Name);
				if (xtextBookmark_0.Attributes != null && xtextBookmark_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextBookmark_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_259(XTextButtonElement xtextButtonElement_0)
		{
			int num = 4;
			if (xtextButtonElement_0 != null)
			{
				method_3("XTextButton");
				method_260(xtextButtonElement_0);
				method_48();
			}
		}

		private void method_260(XTextButtonElement xtextButtonElement_0)
		{
			int num = 17;
			if (xtextButtonElement_0 != null)
			{
				method_7("StyleIndex", xtextButtonElement_0.StyleIndex, -1);
				method_26("CommandName", xtextButtonElement_0.CommandName, null);
				method_26("ContentReadonly", GClass21.smethod_4(xtextButtonElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextButtonElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextButtonElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextButtonElement_0.EventTemplateName, null);
				method_30("Height", xtextButtonElement_0.Height);
				method_26("ID", xtextButtonElement_0.ID, null);
				method_26("JavaScriptForClick", xtextButtonElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextButtonElement_0.JavaScriptForDoubleClick, null);
				if (xtextButtonElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextButtonElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextButtonElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextButtonElement_0.PrintVisibility), "Visible");
				method_26("ScriptTextForClick", xtextButtonElement_0.ScriptTextForClick, null);
				method_26("StringTag", xtextButtonElement_0.StringTag, null);
				method_25("Text", xtextButtonElement_0.Text);
				method_27("UserFlags", xtextButtonElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextButtonElement_0.ValueExpression, null);
				method_35("Visible", xtextButtonElement_0.Visible, bool_1: true);
				method_30("Width", xtextButtonElement_0.Width);
				if (xtextButtonElement_0.Attributes != null && xtextButtonElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextButtonElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextButtonElement_0.PropertyExpressions != null && xtextButtonElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextButtonElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextButtonElement_0.ScriptItems != null && xtextButtonElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextButtonElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_261(XTextCheckBoxElement xtextCheckBoxElement_0)
		{
			int num = 14;
			if (xtextCheckBoxElement_0 != null)
			{
				method_3("XTextCheckBox");
				method_262(xtextCheckBoxElement_0);
				method_48();
			}
		}

		private void method_262(XTextCheckBoxElement xtextCheckBoxElement_0)
		{
			int num = 10;
			if (xtextCheckBoxElement_0 != null)
			{
				method_7("StyleIndex", xtextCheckBoxElement_0.StyleIndex, -1);
				method_26("Caption", xtextCheckBoxElement_0.Caption, null);
				method_35("CheckAlignLeft", xtextCheckBoxElement_0.CheckAlignLeft, bool_1: true);
				method_35("Checked", xtextCheckBoxElement_0.Checked, bool_1: false);
				method_26("CheckedValue", xtextCheckBoxElement_0.CheckedValue, null);
				method_26("ContentReadonly", GClass21.smethod_4(xtextCheckBoxElement_0.ContentReadonly), "Inherit");
				method_26("ControlStyle", GClass21.smethod_4(xtextCheckBoxElement_0.ControlStyle), "CheckBox");
				method_35("Deleteable", xtextCheckBoxElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextCheckBoxElement_0.Enabled, bool_1: true);
				method_26("EnableHighlight", GClass21.smethod_4(xtextCheckBoxElement_0.EnableHighlight), "Enabled");
				method_26("EventTemplateName", xtextCheckBoxElement_0.EventTemplateName, null);
				method_26("GroupName", xtextCheckBoxElement_0.GroupName, null);
				method_30("Height", xtextCheckBoxElement_0.Height);
				method_26("ID", xtextCheckBoxElement_0.ID, null);
				method_26("JavaScriptForClick", xtextCheckBoxElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextCheckBoxElement_0.JavaScriptForDoubleClick, null);
				if (xtextCheckBoxElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextCheckBoxElement_0.LinkInfo);
					method_48();
				}
				method_35("Multiline", xtextCheckBoxElement_0.Multiline, bool_1: false);
				method_26("Name", xtextCheckBoxElement_0.Name, null);
				method_26("PrintVisibilityWhenUnchecked", GClass21.smethod_4(xtextCheckBoxElement_0.PrintVisibilityWhenUnchecked), "Visible");
				method_26("PrintTextForChecked", xtextCheckBoxElement_0.PrintTextForChecked, null);
				method_26("PrintTextForUnChecked", xtextCheckBoxElement_0.PrintTextForUnChecked, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextCheckBoxElement_0.PrintVisibility), "Visible");
				method_35("Readonly", xtextCheckBoxElement_0.Readonly, bool_1: false);
				method_26("StringTag", xtextCheckBoxElement_0.StringTag, null);
				method_26("ToolTip", xtextCheckBoxElement_0.ToolTip, null);
				method_27("UserFlags", xtextCheckBoxElement_0.UserFlags, 0);
				if (xtextCheckBoxElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextCheckBoxElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextCheckBoxElement_0.ValueExpression, null);
				method_35("Visible", xtextCheckBoxElement_0.Visible, bool_1: true);
				method_26("VisualStyle", GClass21.smethod_4(xtextCheckBoxElement_0.VisualStyle), "Default");
				method_30("Width", xtextCheckBoxElement_0.Width);
				if (xtextCheckBoxElement_0.Attributes != null && xtextCheckBoxElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextCheckBoxElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextCheckBoxElement_0.EventExpressions != null && xtextCheckBoxElement_0.EventExpressions.Count > 0)
				{
					method_3("EventExpressions");
					foreach (EventExpressionInfo eventExpression in xtextCheckBoxElement_0.EventExpressions)
					{
						method_3("Expression");
						method_334(eventExpression);
						method_48();
					}
					method_48();
				}
				if (xtextCheckBoxElement_0.PropertyExpressions != null && xtextCheckBoxElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextCheckBoxElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextCheckBoxElement_0.ScriptItems != null && xtextCheckBoxElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextCheckBoxElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_263(XTextContentLinkFieldElement xtextContentLinkFieldElement_0)
		{
			int num = 6;
			if (xtextContentLinkFieldElement_0 != null)
			{
				method_3("XContentLinkField");
				method_264(xtextContentLinkFieldElement_0);
				method_48();
			}
		}

		private void method_264(XTextContentLinkFieldElement xtextContentLinkFieldElement_0)
		{
			int num = 5;
			if (xtextContentLinkFieldElement_0 != null)
			{
				method_7("StyleIndex", xtextContentLinkFieldElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextContentLinkFieldElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextContentLinkFieldElement_0.AcceptTab, bool_1: false);
				method_26("AutoHideMode", GClass21.smethod_4(xtextContentLinkFieldElement_0.AutoHideMode), "None");
				method_26("BackgroundTextColor", xtextContentLinkFieldElement_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextContentLinkFieldElement_0.BorderElementColorValue, null);
				if (xtextContentLinkFieldElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextContentLinkFieldElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextContentLinkFieldElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextContentLinkFieldElement_0.ContentReadonlyExpression, null);
				if (xtextContentLinkFieldElement_0.ContentSource != null)
				{
					method_3("ContentSource");
					method_206(xtextContentLinkFieldElement_0.ContentSource);
					method_48();
				}
				if (xtextContentLinkFieldElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextContentLinkFieldElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextContentLinkFieldElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextContentLinkFieldElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextContentLinkFieldElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextContentLinkFieldElement_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextContentLinkFieldElement_0.EndBorderText, null);
				method_26("EventTemplateName", xtextContentLinkFieldElement_0.EventTemplateName, null);
				method_26("ID", xtextContentLinkFieldElement_0.ID, null);
				method_26("JavaScriptForClick", xtextContentLinkFieldElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextContentLinkFieldElement_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextContentLinkFieldElement_0.PrintVisibility), "Visible");
				method_35("Readonly", xtextContentLinkFieldElement_0.Readonly, bool_1: false);
				method_35("ReplaceUpdateMode", xtextContentLinkFieldElement_0.ReplaceUpdateMode, bool_1: false);
				method_35("SaveLinkedContent", xtextContentLinkFieldElement_0.SaveLinkedContent, bool_1: true);
				method_26("StartBorderText", xtextContentLinkFieldElement_0.StartBorderText, null);
				method_26("TextColor", xtextContentLinkFieldElement_0.TextColorString, null);
				method_26("UpdateState", GClass21.smethod_4(xtextContentLinkFieldElement_0.UpdateState), "AutoUpdate");
				method_27("UserFlags", xtextContentLinkFieldElement_0.UserFlags, 0);
				if (xtextContentLinkFieldElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextContentLinkFieldElement_0.ValidateStyle);
					method_48();
				}
				if (xtextContentLinkFieldElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextContentLinkFieldElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextContentLinkFieldElement_0.ValueExpression, null);
				method_35("Visible", xtextContentLinkFieldElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextContentLinkFieldElement_0.VisibleExpression, null);
				if (xtextContentLinkFieldElement_0.Attributes != null && xtextContentLinkFieldElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextContentLinkFieldElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextContentLinkFieldElement_0.ElementsForSerialize != null && xtextContentLinkFieldElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextContentLinkFieldElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextContentLinkFieldElement_0.Expressions != null && xtextContentLinkFieldElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextContentLinkFieldElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextContentLinkFieldElement_0.PropertyExpressions != null && xtextContentLinkFieldElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextContentLinkFieldElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextContentLinkFieldElement_0.ScriptItems != null && xtextContentLinkFieldElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextContentLinkFieldElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_265(XTextControlHostElement xtextControlHostElement_0)
		{
			int num = 0;
			if (xtextControlHostElement_0 != null)
			{
				method_3("XTextControlHost");
				method_266(xtextControlHostElement_0);
				method_48();
			}
		}

		private void method_266(XTextControlHostElement xtextControlHostElement_0)
		{
			int num = 4;
			if (xtextControlHostElement_0 != null)
			{
				method_7("StyleIndex", xtextControlHostElement_0.StyleIndex, -1);
				method_26("AllowUserResize", GClass21.smethod_4(xtextControlHostElement_0.AllowUserResize), "WidthAndHeight");
				method_26("ContentReadonly", GClass21.smethod_4(xtextControlHostElement_0.ContentReadonly), "Inherit");
				method_26("ControlType", GClass21.smethod_4(xtextControlHostElement_0.ControlType), "AutoDetect");
				method_35("DelayLoadControl", xtextControlHostElement_0.DelayLoadControl, bool_1: false);
				method_35("Deleteable", xtextControlHostElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextControlHostElement_0.Enabled, bool_1: true);
				method_35("EnableViewState", xtextControlHostElement_0.EnableViewState, bool_1: true);
				method_26("EventTemplateName", xtextControlHostElement_0.EventTemplateName, null);
				method_30("Height", xtextControlHostElement_0.Height);
				method_26("HostMode", GClass21.smethod_4(xtextControlHostElement_0.HostMode), "Dynamic");
				method_26("ID", xtextControlHostElement_0.ID, null);
				method_26("JavaScriptForClick", xtextControlHostElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextControlHostElement_0.JavaScriptForDoubleClick, null);
				if (xtextControlHostElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextControlHostElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextControlHostElement_0.Name, null);
				method_26("OptionsPropertyName", xtextControlHostElement_0.OptionsPropertyName, null);
				method_45("PreviewImageData", xtextControlHostElement_0.PreviewImageData);
				method_26("PrintVisibility", GClass21.smethod_4(xtextControlHostElement_0.PrintVisibility), "Visible");
				method_35("SavePreviewImage", xtextControlHostElement_0.SavePreviewImage, bool_1: false);
				method_26("StringTag", xtextControlHostElement_0.StringTag, null);
				method_26("Text", xtextControlHostElement_0.Text, null);
				method_26("TypeFullName", xtextControlHostElement_0.TypeFullName, null);
				method_27("UserFlags", xtextControlHostElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextControlHostElement_0.ValueExpression, null);
				method_26("ValuePropertyName", xtextControlHostElement_0.ValuePropertyName, null);
				method_35("Visible", xtextControlHostElement_0.Visible, bool_1: true);
				method_30("Width", xtextControlHostElement_0.Width);
				if (xtextControlHostElement_0.Attributes != null && xtextControlHostElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextControlHostElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextControlHostElement_0.Parameters != null && xtextControlHostElement_0.Parameters.Count > 0)
				{
					method_3("Parameters");
					foreach (ObjectParameter parameter in xtextControlHostElement_0.Parameters)
					{
						method_3("Parameter");
						method_218(parameter);
						method_48();
					}
					method_48();
				}
				if (xtextControlHostElement_0.PropertyExpressions != null && xtextControlHostElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextControlHostElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextControlHostElement_0.ScriptItems != null && xtextControlHostElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextControlHostElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
				if (xtextControlHostElement_0.ViewState != null && xtextControlHostElement_0.ViewState.Count > 0)
				{
					method_3("ViewState");
					foreach (XMLViewStateBagItem item in xtextControlHostElement_0.ViewState)
					{
						method_3("Item");
						method_180(item);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_267(XTextCustomShapeElement xtextCustomShapeElement_0)
		{
			int num = 11;
			if (xtextCustomShapeElement_0 != null)
			{
				method_3("XCustomShape");
				method_268(xtextCustomShapeElement_0);
				method_48();
			}
		}

		private void method_268(XTextCustomShapeElement xtextCustomShapeElement_0)
		{
			int num = 3;
			if (xtextCustomShapeElement_0 != null)
			{
				method_7("StyleIndex", xtextCustomShapeElement_0.StyleIndex, -1);
				method_27("ChartPageIndex", xtextCustomShapeElement_0.ChartPageIndex, 0);
				method_26("ContentReadonly", GClass21.smethod_4(xtextCustomShapeElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextCustomShapeElement_0.Deleteable, bool_1: true);
				method_26("DrawContentHandlerName", xtextCustomShapeElement_0.DrawContentHandlerName, null);
				method_35("Enabled", xtextCustomShapeElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextCustomShapeElement_0.EventTemplateName, null);
				method_30("Height", xtextCustomShapeElement_0.Height);
				method_26("ID", xtextCustomShapeElement_0.ID, null);
				method_26("JavaScriptForClick", xtextCustomShapeElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextCustomShapeElement_0.JavaScriptForDoubleClick, null);
				if (xtextCustomShapeElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextCustomShapeElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextCustomShapeElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextCustomShapeElement_0.PrintVisibility), "Visible");
				method_26("StringTag", xtextCustomShapeElement_0.StringTag, null);
				method_27("UserFlags", xtextCustomShapeElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextCustomShapeElement_0.ValueExpression, null);
				method_35("Visible", xtextCustomShapeElement_0.Visible, bool_1: true);
				method_30("Width", xtextCustomShapeElement_0.Width);
				if (xtextCustomShapeElement_0.Attributes != null && xtextCustomShapeElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextCustomShapeElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextCustomShapeElement_0.PropertyExpressions != null && xtextCustomShapeElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextCustomShapeElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextCustomShapeElement_0.ScriptItems != null && xtextCustomShapeElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextCustomShapeElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_269(XTextDirectoryFieldElement xtextDirectoryFieldElement_0)
		{
			int num = 6;
			if (xtextDirectoryFieldElement_0 != null)
			{
				method_3("XDirectoryField");
				method_270(xtextDirectoryFieldElement_0);
				method_48();
			}
		}

		private void method_270(XTextDirectoryFieldElement xtextDirectoryFieldElement_0)
		{
			int num = 6;
			if (xtextDirectoryFieldElement_0 != null)
			{
				method_7("StyleIndex", xtextDirectoryFieldElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextDirectoryFieldElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextDirectoryFieldElement_0.AcceptTab, bool_1: false);
				method_26("Alignment", GClass21.smethod_4(xtextDirectoryFieldElement_0.Alignment), "Near");
				method_26("AutoHideMode", GClass21.smethod_4(xtextDirectoryFieldElement_0.AutoHideMode), "None");
				method_26("BackgroundText", xtextDirectoryFieldElement_0.BackgroundText, null);
				method_26("BackgroundTextColor", xtextDirectoryFieldElement_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextDirectoryFieldElement_0.BorderElementColorValue, null);
				method_26("BorderVisible", GClass21.smethod_4(xtextDirectoryFieldElement_0.BorderVisible), "Default");
				if (xtextDirectoryFieldElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextDirectoryFieldElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextDirectoryFieldElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextDirectoryFieldElement_0.ContentReadonlyExpression, null);
				if (xtextDirectoryFieldElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextDirectoryFieldElement_0.CopySource);
					method_48();
				}
				method_26("DefaultEventExpression", xtextDirectoryFieldElement_0.DefaultEventExpression, null);
				method_35("Deleteable", xtextDirectoryFieldElement_0.Deleteable, bool_1: true);
				if (xtextDirectoryFieldElement_0.DisplayFormat != null)
				{
					method_3("DisplayFormat");
					method_62(xtextDirectoryFieldElement_0.DisplayFormat);
					method_48();
				}
				method_27("DisplayLevel", xtextDirectoryFieldElement_0.DisplayLevel, 3);
				method_26("ElementIDForEditableDependent", xtextDirectoryFieldElement_0.ElementIDForEditableDependent, null);
				method_26("EnableHighlight", GClass21.smethod_4(xtextDirectoryFieldElement_0.EnableHighlight), "Enabled");
				method_26("EnablePermission", GClass21.smethod_4(xtextDirectoryFieldElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextDirectoryFieldElement_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextDirectoryFieldElement_0.EndBorderText, null);
				method_26("EventTemplateName", xtextDirectoryFieldElement_0.EventTemplateName, null);
				method_26("ID", xtextDirectoryFieldElement_0.ID, null);
				method_26("InnerValue", xtextDirectoryFieldElement_0.InnerValue, null);
				method_26("JavaScriptForClick", xtextDirectoryFieldElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextDirectoryFieldElement_0.JavaScriptForDoubleClick, null);
				method_26("LabelText", xtextDirectoryFieldElement_0.LabelText, null);
				method_26("MoveFocusHotKey", GClass21.smethod_4(xtextDirectoryFieldElement_0.MoveFocusHotKey), "Default");
				method_26("Name", xtextDirectoryFieldElement_0.Name, null);
				method_26("PrintBackgroundText", GClass21.smethod_4(xtextDirectoryFieldElement_0.PrintBackgroundText), "Inherit");
				method_26("PrintVisibility", GClass21.smethod_4(xtextDirectoryFieldElement_0.PrintVisibility), "Visible");
				method_26("RuntimeMoveFocusHotKey", GClass21.smethod_4(xtextDirectoryFieldElement_0.RuntimeMoveFocusHotKey), "None");
				method_26("SelectedSpellCode", xtextDirectoryFieldElement_0.SelectedSpellCode, null);
				method_35("ShowPageIndex", xtextDirectoryFieldElement_0.ShowPageIndex, bool_1: true);
				method_29("SpecifyWidth", xtextDirectoryFieldElement_0.SpecifyWidth, 0f);
				method_26("StartBorderText", xtextDirectoryFieldElement_0.StartBorderText, null);
				method_27("TabIndex", xtextDirectoryFieldElement_0.TabIndex, 0);
				method_35("TabStop", xtextDirectoryFieldElement_0.TabStop, bool_1: true);
				method_26("TextColor", xtextDirectoryFieldElement_0.TextColorString, null);
				method_26("ToolTip", xtextDirectoryFieldElement_0.ToolTip, null);
				method_26("UnitText", xtextDirectoryFieldElement_0.UnitText, null);
				method_35("UserEditable", xtextDirectoryFieldElement_0.UserEditable, bool_1: true);
				method_27("UserFlags", xtextDirectoryFieldElement_0.UserFlags, 0);
				if (xtextDirectoryFieldElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextDirectoryFieldElement_0.ValidateStyle);
					method_48();
				}
				if (xtextDirectoryFieldElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextDirectoryFieldElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextDirectoryFieldElement_0.ValueExpression, null);
				method_26("ViewEncryptType", GClass21.smethod_4(xtextDirectoryFieldElement_0.ViewEncryptType), "None");
				method_35("Visible", xtextDirectoryFieldElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextDirectoryFieldElement_0.VisibleExpression, null);
				if (xtextDirectoryFieldElement_0.Attributes != null && xtextDirectoryFieldElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextDirectoryFieldElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextDirectoryFieldElement_0.ElementsForSerialize != null && xtextDirectoryFieldElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextDirectoryFieldElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextDirectoryFieldElement_0.EventExpressions != null && xtextDirectoryFieldElement_0.EventExpressions.Count > 0)
				{
					method_3("EventExpressions");
					foreach (EventExpressionInfo eventExpression in xtextDirectoryFieldElement_0.EventExpressions)
					{
						method_3("Expression");
						method_334(eventExpression);
						method_48();
					}
					method_48();
				}
				if (xtextDirectoryFieldElement_0.Expressions != null && xtextDirectoryFieldElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextDirectoryFieldElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextDirectoryFieldElement_0.PropertyExpressions != null && xtextDirectoryFieldElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextDirectoryFieldElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextDirectoryFieldElement_0.ScriptItems != null && xtextDirectoryFieldElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextDirectoryFieldElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_271(XTextDocument xtextDocument_0)
		{
			int num = 17;
			if (xtextDocument_0 != null)
			{
				method_3("XTextDocument");
				method_272(xtextDocument_0);
				method_48();
			}
		}

		private void method_272(XTextDocument xtextDocument_0)
		{
			int num = 1;
			if (xtextDocument_0 != null)
			{
				method_5("EditorVersionString", xtextDocument_0.EditorVersionString);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextDocument_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextDocument_0.AcceptTab, bool_1: false);
				method_26("AutoHideMode", GClass21.smethod_4(xtextDocument_0.AutoHideMode), "None");
				method_26("BodyText", xtextDocument_0.BodyText, null);
				if (xtextDocument_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextDocument_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextDocument_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextDocument_0.ContentReadonlyExpression, null);
				if (xtextDocument_0.ContentStyles != null)
				{
					method_3("ContentStyles");
					method_202(xtextDocument_0.ContentStyles);
					method_48();
				}
				if (xtextDocument_0.ControlOptionsForDebug != null)
				{
					method_3("ControlOptionsForDebug");
					method_160(xtextDocument_0.ControlOptionsForDebug);
					method_48();
				}
				method_35("Deleteable", xtextDocument_0.Deleteable, bool_1: true);
				method_27("DocumentContentVersion", xtextDocument_0.DocumentContentVersion, 0);
				method_26("DocumentGraphicsUnit", GClass21.smethod_4(xtextDocument_0.DocumentGraphicsUnit), "Document");
				if (xtextDocument_0.DocumentOptionsToSaveFile != null)
				{
					method_3("DocumentOptionsToSaveFile");
					method_188(xtextDocument_0.DocumentOptionsToSaveFile);
					method_48();
				}
				method_26("ElementIDForEditableDependent", xtextDocument_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextDocument_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextDocument_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextDocument_0.EventTemplateName, null);
				method_26("FileFormat", xtextDocument_0.FileFormat, null);
				method_26("FileName", xtextDocument_0.FileName, null);
				method_26("GlobalJavaScript", xtextDocument_0.GlobalJavaScript, null);
				method_26("ID", xtextDocument_0.ID, null);
				if (xtextDocument_0.Info != null)
				{
					method_3("Info");
					method_204(xtextDocument_0.Info);
					method_48();
				}
				method_26("JavaScriptForClick", xtextDocument_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextDocument_0.JavaScriptForDoubleClick, null);
				if (xtextDocument_0.LocalConfig != null)
				{
					method_3("LocalConfig");
					method_214(xtextDocument_0.LocalConfig);
					method_48();
				}
				method_26("LocalExcludeKeywords", xtextDocument_0.LocalExcludeKeywords, null);
				method_26("MeasureMode", GClass21.smethod_4(xtextDocument_0.MeasureMode), "Default");
				if (xtextDocument_0.MotherTemplate != null)
				{
					method_3("MotherTemplate");
					method_216(xtextDocument_0.MotherTemplate);
					method_48();
				}
				if (xtextDocument_0.PageSettings != null)
				{
					method_3("PageSettings");
					method_82(xtextDocument_0.PageSettings);
					method_48();
				}
				method_26("PrintVisibility", GClass21.smethod_4(xtextDocument_0.PrintVisibility), "Visible");
				method_35("SaveDocumentOptionsToFile", xtextDocument_0.SaveDocumentOptionsToFile, bool_1: false);
				method_26("ScriptText", xtextDocument_0.ScriptText, null);
				method_35("SerializeParameterValue", xtextDocument_0.SerializeParameterValue, bool_1: false);
				method_25("SpecialTag", xtextDocument_0.SpecialTag);
				method_27("UserFlags", xtextDocument_0.UserFlags, 0);
				if (xtextDocument_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextDocument_0.ValidateStyle);
					method_48();
				}
				if (xtextDocument_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextDocument_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextDocument_0.ValueExpression, null);
				method_35("Visible", xtextDocument_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextDocument_0.VisibleExpression, null);
				if (xtextDocument_0.Attributes != null && xtextDocument_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextDocument_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.Comments != null && xtextDocument_0.Comments.Count > 0)
				{
					method_3("Comments");
					method_198(xtextDocument_0.Comments);
					method_48();
				}
				if (xtextDocument_0.DisabledParameterNames != null && xtextDocument_0.DisabledParameterNames.Count > 0)
				{
					method_3("DisabledParameterNames");
					foreach (string disabledParameterName in xtextDocument_0.DisabledParameterNames)
					{
						method_3("Name");
						method_52(disabledParameterName);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.ElementsForSerialize != null && xtextDocument_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextDocument_0.ElementsForSerialize);
					method_48();
				}
				if (xtextDocument_0.Expressions != null && xtextDocument_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextDocument_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.GlobalJavaScriptReferences != null && xtextDocument_0.GlobalJavaScriptReferences.Count > 0)
				{
					method_3("GlobalJavaScriptReferences");
					foreach (string globalJavaScriptReference in xtextDocument_0.GlobalJavaScriptReferences)
					{
						method_3("Reference");
						method_52(globalJavaScriptReference);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.PageContentVersions != null && xtextDocument_0.PageContentVersions.Count > 0)
				{
					method_3("PageContentVersions");
					foreach (PageContentVersionInfo pageContentVersion in xtextDocument_0.PageContentVersions)
					{
						method_3("Item");
						method_222(pageContentVersion);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.Parameters != null && xtextDocument_0.Parameters.Count > 0)
				{
					method_3("Parameters");
					foreach (DocumentParameter parameter in xtextDocument_0.Parameters)
					{
						method_3("Parameter");
						method_164(parameter);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.PropertyExpressions != null && xtextDocument_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextDocument_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.RepeatedImages != null && xtextDocument_0.RepeatedImages.Count > 0)
				{
					method_3("RepeatedImages");
					foreach (RepeatedImageValue repeatedImage in xtextDocument_0.RepeatedImages)
					{
						method_3("Image");
						method_238(repeatedImage);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.ScriptItems != null && xtextDocument_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextDocument_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
				if (xtextDocument_0.UserHistories != null && xtextDocument_0.UserHistories.Count > 0)
				{
					method_3("UserHistories");
					foreach (UserHistoryInfo userHistory in xtextDocument_0.UserHistories)
					{
						method_3("History");
						method_348(userHistory);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_273(XTextDocumentBodyElement xtextDocumentBodyElement_0)
		{
			int num = 17;
			if (xtextDocumentBodyElement_0 != null)
			{
				method_3("XTextBody");
				method_274(xtextDocumentBodyElement_0);
				method_48();
			}
		}

		private void method_274(XTextDocumentBodyElement xtextDocumentBodyElement_0)
		{
			int num = 8;
			if (xtextDocumentBodyElement_0 != null)
			{
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextDocumentBodyElement_0.AcceptChildElementTypes2), "All");
				method_26("AutoHideMode", GClass21.smethod_4(xtextDocumentBodyElement_0.AutoHideMode), "None");
				if (xtextDocumentBodyElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextDocumentBodyElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextDocumentBodyElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextDocumentBodyElement_0.ContentReadonlyExpression, null);
				if (xtextDocumentBodyElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextDocumentBodyElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextDocumentBodyElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextDocumentBodyElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextDocumentBodyElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextDocumentBodyElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextDocumentBodyElement_0.EventTemplateName, null);
				method_26("ID", xtextDocumentBodyElement_0.ID, null);
				method_26("JavaScriptForClick", xtextDocumentBodyElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextDocumentBodyElement_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextDocumentBodyElement_0.PrintVisibility), "Visible");
				method_29("SpecifyFixedLineHeight", xtextDocumentBodyElement_0.SpecifyFixedLineHeight, 0f);
				method_27("UserFlags", xtextDocumentBodyElement_0.UserFlags, 0);
				if (xtextDocumentBodyElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextDocumentBodyElement_0.ValidateStyle);
					method_48();
				}
				if (xtextDocumentBodyElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextDocumentBodyElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextDocumentBodyElement_0.ValueExpression, null);
				method_35("Visible", xtextDocumentBodyElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextDocumentBodyElement_0.VisibleExpression, null);
				if (xtextDocumentBodyElement_0.Attributes != null && xtextDocumentBodyElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextDocumentBodyElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentBodyElement_0.ElementsForSerialize != null && xtextDocumentBodyElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextDocumentBodyElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextDocumentBodyElement_0.Expressions != null && xtextDocumentBodyElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextDocumentBodyElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentBodyElement_0.PropertyExpressions != null && xtextDocumentBodyElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextDocumentBodyElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentBodyElement_0.ScriptItems != null && xtextDocumentBodyElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextDocumentBodyElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_275(XTextDocumentFieldElement xtextDocumentFieldElement_0)
		{
			int num = 17;
			if (xtextDocumentFieldElement_0 != null)
			{
				method_3("DField");
				method_276(xtextDocumentFieldElement_0);
				method_48();
			}
		}

		private void method_276(XTextDocumentFieldElement xtextDocumentFieldElement_0)
		{
			int num = 6;
			if (xtextDocumentFieldElement_0 != null)
			{
				method_7("StyleIndex", xtextDocumentFieldElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextDocumentFieldElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextDocumentFieldElement_0.AcceptTab, bool_1: false);
				method_26("AutoHideMode", GClass21.smethod_4(xtextDocumentFieldElement_0.AutoHideMode), "None");
				method_35("AutoUpdateResult", xtextDocumentFieldElement_0.AutoUpdateResult, bool_1: false);
				method_26("BackgroundTextColor", xtextDocumentFieldElement_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextDocumentFieldElement_0.BorderElementColorValue, null);
				method_26("Code", xtextDocumentFieldElement_0.Code, null);
				if (xtextDocumentFieldElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextDocumentFieldElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextDocumentFieldElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextDocumentFieldElement_0.ContentReadonlyExpression, null);
				if (xtextDocumentFieldElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextDocumentFieldElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextDocumentFieldElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextDocumentFieldElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextDocumentFieldElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextDocumentFieldElement_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextDocumentFieldElement_0.EndBorderText, null);
				method_26("EventTemplateName", xtextDocumentFieldElement_0.EventTemplateName, null);
				method_26("ID", xtextDocumentFieldElement_0.ID, null);
				method_26("JavaScriptForClick", xtextDocumentFieldElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextDocumentFieldElement_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextDocumentFieldElement_0.PrintVisibility), "Visible");
				method_26("StartBorderText", xtextDocumentFieldElement_0.StartBorderText, null);
				method_26("TextColor", xtextDocumentFieldElement_0.TextColorString, null);
				method_27("UserFlags", xtextDocumentFieldElement_0.UserFlags, 0);
				if (xtextDocumentFieldElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextDocumentFieldElement_0.ValidateStyle);
					method_48();
				}
				if (xtextDocumentFieldElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextDocumentFieldElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextDocumentFieldElement_0.ValueExpression, null);
				method_35("Visible", xtextDocumentFieldElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextDocumentFieldElement_0.VisibleExpression, null);
				if (xtextDocumentFieldElement_0.Attributes != null && xtextDocumentFieldElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextDocumentFieldElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentFieldElement_0.ElementsForSerialize != null && xtextDocumentFieldElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextDocumentFieldElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextDocumentFieldElement_0.Expressions != null && xtextDocumentFieldElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextDocumentFieldElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentFieldElement_0.PropertyExpressions != null && xtextDocumentFieldElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextDocumentFieldElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentFieldElement_0.ScriptItems != null && xtextDocumentFieldElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextDocumentFieldElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_277(XTextDocumentFooterElement xtextDocumentFooterElement_0)
		{
			int num = 17;
			if (xtextDocumentFooterElement_0 != null)
			{
				method_3("XTextFooter");
				method_278(xtextDocumentFooterElement_0);
				method_48();
			}
		}

		private void method_278(XTextDocumentFooterElement xtextDocumentFooterElement_0)
		{
			int num = 6;
			if (xtextDocumentFooterElement_0 != null)
			{
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextDocumentFooterElement_0.AcceptChildElementTypes2), "All");
				method_26("AutoHideMode", GClass21.smethod_4(xtextDocumentFooterElement_0.AutoHideMode), "None");
				if (xtextDocumentFooterElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextDocumentFooterElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextDocumentFooterElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextDocumentFooterElement_0.ContentReadonlyExpression, null);
				if (xtextDocumentFooterElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextDocumentFooterElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextDocumentFooterElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextDocumentFooterElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextDocumentFooterElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextDocumentFooterElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextDocumentFooterElement_0.EventTemplateName, null);
				method_26("ID", xtextDocumentFooterElement_0.ID, null);
				method_26("JavaScriptForClick", xtextDocumentFooterElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextDocumentFooterElement_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextDocumentFooterElement_0.PrintVisibility), "Visible");
				method_29("SpecifyFixedLineHeight", xtextDocumentFooterElement_0.SpecifyFixedLineHeight, 0f);
				method_27("UserFlags", xtextDocumentFooterElement_0.UserFlags, 0);
				if (xtextDocumentFooterElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextDocumentFooterElement_0.ValidateStyle);
					method_48();
				}
				if (xtextDocumentFooterElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextDocumentFooterElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextDocumentFooterElement_0.ValueExpression, null);
				method_35("Visible", xtextDocumentFooterElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextDocumentFooterElement_0.VisibleExpression, null);
				if (xtextDocumentFooterElement_0.Attributes != null && xtextDocumentFooterElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextDocumentFooterElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentFooterElement_0.ElementsForSerialize != null && xtextDocumentFooterElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextDocumentFooterElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextDocumentFooterElement_0.Expressions != null && xtextDocumentFooterElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextDocumentFooterElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentFooterElement_0.PropertyExpressions != null && xtextDocumentFooterElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextDocumentFooterElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentFooterElement_0.ScriptItems != null && xtextDocumentFooterElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextDocumentFooterElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_279(XTextDocumentHeaderElement xtextDocumentHeaderElement_0)
		{
			int num = 9;
			if (xtextDocumentHeaderElement_0 != null)
			{
				method_3("XTextHeader");
				method_280(xtextDocumentHeaderElement_0);
				method_48();
			}
		}

		private void method_280(XTextDocumentHeaderElement xtextDocumentHeaderElement_0)
		{
			int num = 0;
			if (xtextDocumentHeaderElement_0 != null)
			{
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextDocumentHeaderElement_0.AcceptChildElementTypes2), "All");
				method_26("AutoHideMode", GClass21.smethod_4(xtextDocumentHeaderElement_0.AutoHideMode), "None");
				if (xtextDocumentHeaderElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextDocumentHeaderElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextDocumentHeaderElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextDocumentHeaderElement_0.ContentReadonlyExpression, null);
				if (xtextDocumentHeaderElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextDocumentHeaderElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextDocumentHeaderElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextDocumentHeaderElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextDocumentHeaderElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextDocumentHeaderElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextDocumentHeaderElement_0.EventTemplateName, null);
				method_26("ID", xtextDocumentHeaderElement_0.ID, null);
				method_26("JavaScriptForClick", xtextDocumentHeaderElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextDocumentHeaderElement_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextDocumentHeaderElement_0.PrintVisibility), "Visible");
				method_29("SpecifyFixedLineHeight", xtextDocumentHeaderElement_0.SpecifyFixedLineHeight, 0f);
				method_27("UserFlags", xtextDocumentHeaderElement_0.UserFlags, 0);
				if (xtextDocumentHeaderElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextDocumentHeaderElement_0.ValidateStyle);
					method_48();
				}
				if (xtextDocumentHeaderElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextDocumentHeaderElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextDocumentHeaderElement_0.ValueExpression, null);
				method_35("Visible", xtextDocumentHeaderElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextDocumentHeaderElement_0.VisibleExpression, null);
				if (xtextDocumentHeaderElement_0.Attributes != null && xtextDocumentHeaderElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextDocumentHeaderElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentHeaderElement_0.ElementsForSerialize != null && xtextDocumentHeaderElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextDocumentHeaderElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextDocumentHeaderElement_0.Expressions != null && xtextDocumentHeaderElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextDocumentHeaderElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentHeaderElement_0.PropertyExpressions != null && xtextDocumentHeaderElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextDocumentHeaderElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextDocumentHeaderElement_0.ScriptItems != null && xtextDocumentHeaderElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextDocumentHeaderElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_281(XTextElement xtextElement_0)
		{
			int num = 13;
			if (xtextElement_0 != null)
			{
				method_3("Element");
				method_282(xtextElement_0);
				method_48();
			}
		}

		private void method_282(XTextElement xtextElement_0)
		{
			int num = 11;
			if (xtextElement_0 != null)
			{
				method_7("StyleIndex", xtextElement_0.StyleIndex, -1);
				method_26("ID", xtextElement_0.ID, null);
				if (xtextElement_0.Attributes != null && xtextElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_283(XTextElementList xtextElementList_0)
		{
			int num = 14;
			if (xtextElementList_0 != null)
			{
				method_3("XTextElementList");
				method_284(xtextElementList_0);
				method_48();
			}
		}

		private void method_284(XTextElementList xtextElementList_0)
		{
			int num = 2;
			if (xtextElementList_0 != null)
			{
				foreach (XTextElement item in xtextElementList_0)
				{
					if (item is XTextAccountingNumberElement)
					{
						method_3("XAccountingNumber");
						method_252((XTextAccountingNumberElement)item);
						method_48();
					}
					if (item is XTextBarcodeFieldElement)
					{
						method_3("XBarcodeField");
						method_254((XTextBarcodeFieldElement)item);
						method_48();
					}
					if (item is XTextBeanFieldElement)
					{
						method_3("XBean");
						method_256((XTextBeanFieldElement)item);
						method_48();
					}
					if (item is XTextBookmark)
					{
						method_3("XBookMark");
						method_258((XTextBookmark)item);
						method_48();
					}
					if (item is XTextButtonElement)
					{
						method_3("XTextButton");
						method_260((XTextButtonElement)item);
						method_48();
					}
					if (item is XTextCheckBoxElement)
					{
						method_3("XTextCheckBox");
						method_262((XTextCheckBoxElement)item);
						method_48();
					}
					if (item is XTextContentLinkFieldElement)
					{
						method_3("XContentLinkField");
						method_264((XTextContentLinkFieldElement)item);
						method_48();
					}
					if (item is XTextControlHostElement)
					{
						method_3("XTextControlHost");
						method_266((XTextControlHostElement)item);
						method_48();
					}
					if (item is XTextCustomShapeElement)
					{
						method_3("XCustomShape");
						method_268((XTextCustomShapeElement)item);
						method_48();
					}
					if (item is XTextDirectoryFieldElement)
					{
						method_3("XDirectoryField");
						method_270((XTextDirectoryFieldElement)item);
						method_48();
					}
					if (item is XTextDocument)
					{
						method_3("XTextDocument");
						method_272((XTextDocument)item);
						method_48();
					}
					if (item is XTextDocumentBodyElement)
					{
						method_3("XTextBody");
						method_274((XTextDocumentBodyElement)item);
						method_48();
					}
					if (item is XTextDocumentFieldElement)
					{
						method_3("DField");
						method_276((XTextDocumentFieldElement)item);
						method_48();
					}
					if (item is XTextDocumentFooterElement)
					{
						method_3("XTextFooter");
						method_278((XTextDocumentFooterElement)item);
						method_48();
					}
					if (item is XTextDocumentHeaderElement)
					{
						method_3("XTextHeader");
						method_280((XTextDocumentHeaderElement)item);
						method_48();
					}
					if (item is XTextFieldElementBase)
					{
						method_3("XField");
						method_286((XTextFieldElementBase)item);
						method_48();
					}
					if (item is XTextFileBlockElement)
					{
						method_3("XFileBlock");
						method_288((XTextFileBlockElement)item);
						method_48();
					}
					if (item is XTextHorizontalLineElement)
					{
						method_3("HorizontalLine");
						method_290((XTextHorizontalLineElement)item);
						method_48();
					}
					if (item is XTextImageElement)
					{
						method_3("XImage");
						method_292((XTextImageElement)item);
						method_48();
					}
					if (item is XTextInputFieldElement)
					{
						method_3("XInputField");
						method_294((XTextInputFieldElement)item);
						method_48();
					}
					if (item is XTextInputFieldElementBase)
					{
						method_3("XInputFieldBase");
						method_296((XTextInputFieldElementBase)item);
						method_48();
					}
					if (item is XTextLabelElement)
					{
						method_3("Element");
						method_298((XTextLabelElement)item);
						method_48();
					}
					if (item is XTextLineBreakElement)
					{
						method_3("XLineBreak");
						method_300((XTextLineBreakElement)item);
						method_48();
					}
					if (item is XTextMediaElement)
					{
						method_3("XMedia");
						method_302((XTextMediaElement)item);
						method_48();
					}
					if (item is XTextObjectElement)
					{
						method_3("Element");
						method_304((XTextObjectElement)item);
						method_48();
					}
					if (item is XTextPageBreakElement)
					{
						method_3("XPageBreak");
						method_306((XTextPageBreakElement)item);
						method_48();
					}
					if (item is XTextPageInfoElement)
					{
						method_3("XPageInfo");
						method_308((XTextPageInfoElement)item);
						method_48();
					}
					if (item is XTextParagraphFlagElement)
					{
						method_3("XParagraphFlag");
						method_310((XTextParagraphFlagElement)item);
						method_48();
					}
					if (item is XTextRadioBoxElement)
					{
						method_3("XTextRadioBox");
						method_312((XTextRadioBoxElement)item);
						method_48();
					}
					if (item is XTextSectionElement)
					{
						method_3("XTextSection");
						method_314((XTextSectionElement)item);
						method_48();
					}
					if (item is XTextSignElement)
					{
						method_3("XTextLock");
						method_316((XTextSignElement)item);
						method_48();
					}
					if (item is XTextStringElement)
					{
						method_3("XString");
						method_318((XTextStringElement)item);
						method_48();
					}
					if (item is XTextSubDocumentElement)
					{
						method_3("XTextSubDocument");
						method_320((XTextSubDocumentElement)item);
						method_48();
					}
					if (item is XTextTableCellElement)
					{
						method_3("XTextTableCell");
						method_322((XTextTableCellElement)item);
						method_48();
					}
					if (item is XTextTableColumnElement)
					{
						method_3("XTextTableColumn");
						method_324((XTextTableColumnElement)item);
						method_48();
					}
					if (item is XTextTableElement)
					{
						method_3("XTextTable");
						method_326((XTextTableElement)item);
						method_48();
					}
					if (item is XTextTableRowElement)
					{
						method_3("XTextTableRow");
						method_328((XTextTableRowElement)item);
						method_48();
					}
					if (item is XTextTDBarcodeElement)
					{
						method_3("XTDBarcodeField");
						method_330((XTextTDBarcodeElement)item);
						method_48();
					}
					if (item is XTextTemperatureChartElement)
					{
						method_3("XTemperatureChart");
						method_332((XTextTemperatureChartElement)item);
						method_48();
					}
				}
			}
		}

		private void method_285(XTextFieldElementBase xtextFieldElementBase_0)
		{
			int num = 5;
			if (xtextFieldElementBase_0 != null)
			{
				method_3("XField");
				method_286(xtextFieldElementBase_0);
				method_48();
			}
		}

		private void method_286(XTextFieldElementBase xtextFieldElementBase_0)
		{
			int num = 9;
			if (xtextFieldElementBase_0 != null)
			{
				method_7("StyleIndex", xtextFieldElementBase_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextFieldElementBase_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextFieldElementBase_0.AcceptTab, bool_1: false);
				method_26("AutoHideMode", GClass21.smethod_4(xtextFieldElementBase_0.AutoHideMode), "None");
				method_26("BackgroundTextColor", xtextFieldElementBase_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextFieldElementBase_0.BorderElementColorValue, null);
				if (xtextFieldElementBase_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextFieldElementBase_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextFieldElementBase_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextFieldElementBase_0.ContentReadonlyExpression, null);
				if (xtextFieldElementBase_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextFieldElementBase_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextFieldElementBase_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextFieldElementBase_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextFieldElementBase_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextFieldElementBase_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextFieldElementBase_0.EndBorderText, null);
				method_26("EventTemplateName", xtextFieldElementBase_0.EventTemplateName, null);
				method_26("ID", xtextFieldElementBase_0.ID, null);
				method_26("JavaScriptForClick", xtextFieldElementBase_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextFieldElementBase_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextFieldElementBase_0.PrintVisibility), "Visible");
				method_26("StartBorderText", xtextFieldElementBase_0.StartBorderText, null);
				method_26("TextColor", xtextFieldElementBase_0.TextColorString, null);
				method_27("UserFlags", xtextFieldElementBase_0.UserFlags, 0);
				if (xtextFieldElementBase_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextFieldElementBase_0.ValidateStyle);
					method_48();
				}
				if (xtextFieldElementBase_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextFieldElementBase_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextFieldElementBase_0.ValueExpression, null);
				method_35("Visible", xtextFieldElementBase_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextFieldElementBase_0.VisibleExpression, null);
				if (xtextFieldElementBase_0.Attributes != null && xtextFieldElementBase_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextFieldElementBase_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextFieldElementBase_0.ElementsForSerialize != null && xtextFieldElementBase_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextFieldElementBase_0.ElementsForSerialize);
					method_48();
				}
				if (xtextFieldElementBase_0.Expressions != null && xtextFieldElementBase_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextFieldElementBase_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextFieldElementBase_0.PropertyExpressions != null && xtextFieldElementBase_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextFieldElementBase_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextFieldElementBase_0.ScriptItems != null && xtextFieldElementBase_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextFieldElementBase_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_287(XTextFileBlockElement xtextFileBlockElement_0)
		{
			int num = 17;
			if (xtextFileBlockElement_0 != null)
			{
				method_3("XFileBlock");
				method_288(xtextFileBlockElement_0);
				method_48();
			}
		}

		private void method_288(XTextFileBlockElement xtextFileBlockElement_0)
		{
			int num = 18;
			if (xtextFileBlockElement_0 != null)
			{
				method_7("StyleIndex", xtextFileBlockElement_0.StyleIndex, -1);
				method_26("ContentReadonly", GClass21.smethod_4(xtextFileBlockElement_0.ContentReadonly), "Inherit");
				if (xtextFileBlockElement_0.ContentSource != null)
				{
					method_3("ContentSource");
					method_206(xtextFileBlockElement_0.ContentSource);
					method_48();
				}
				method_35("Deleteable", xtextFileBlockElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextFileBlockElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextFileBlockElement_0.EventTemplateName, null);
				method_26("ID", xtextFileBlockElement_0.ID, null);
				method_26("JavaScriptForClick", xtextFileBlockElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextFileBlockElement_0.JavaScriptForDoubleClick, null);
				if (xtextFileBlockElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextFileBlockElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextFileBlockElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextFileBlockElement_0.PrintVisibility), "Visible");
				method_26("StringTag", xtextFileBlockElement_0.StringTag, null);
				method_26("Text", xtextFileBlockElement_0.Text, null);
				method_27("UserFlags", xtextFileBlockElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextFileBlockElement_0.ValueExpression, null);
				method_35("Visible", xtextFileBlockElement_0.Visible, bool_1: true);
				if (xtextFileBlockElement_0.Attributes != null && xtextFileBlockElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextFileBlockElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextFileBlockElement_0.PropertyExpressions != null && xtextFileBlockElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextFileBlockElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextFileBlockElement_0.ScriptItems != null && xtextFileBlockElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextFileBlockElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_289(XTextHorizontalLineElement xtextHorizontalLineElement_0)
		{
			int num = 13;
			if (xtextHorizontalLineElement_0 != null)
			{
				method_3("HorizontalLine");
				method_290(xtextHorizontalLineElement_0);
				method_48();
			}
		}

		private void method_290(XTextHorizontalLineElement xtextHorizontalLineElement_0)
		{
			int num = 9;
			if (xtextHorizontalLineElement_0 != null)
			{
				method_7("StyleIndex", xtextHorizontalLineElement_0.StyleIndex, -1);
				method_26("ContentReadonly", GClass21.smethod_4(xtextHorizontalLineElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextHorizontalLineElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextHorizontalLineElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextHorizontalLineElement_0.EventTemplateName, null);
				method_29("Height", xtextHorizontalLineElement_0.Height, 20f);
				method_26("ID", xtextHorizontalLineElement_0.ID, null);
				method_26("JavaScriptForClick", xtextHorizontalLineElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextHorizontalLineElement_0.JavaScriptForDoubleClick, null);
				method_29("LineLengthInCM", xtextHorizontalLineElement_0.LineLengthInCM, 0f);
				method_29("LineSize", xtextHorizontalLineElement_0.LineSize, 1f);
				if (xtextHorizontalLineElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextHorizontalLineElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextHorizontalLineElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextHorizontalLineElement_0.PrintVisibility), "Visible");
				method_26("StringTag", xtextHorizontalLineElement_0.StringTag, null);
				method_27("UserFlags", xtextHorizontalLineElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextHorizontalLineElement_0.ValueExpression, null);
				method_35("Visible", xtextHorizontalLineElement_0.Visible, bool_1: true);
				if (xtextHorizontalLineElement_0.Attributes != null && xtextHorizontalLineElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextHorizontalLineElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextHorizontalLineElement_0.PropertyExpressions != null && xtextHorizontalLineElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextHorizontalLineElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextHorizontalLineElement_0.ScriptItems != null && xtextHorizontalLineElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextHorizontalLineElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_291(XTextImageElement xtextImageElement_0)
		{
			int num = 14;
			if (xtextImageElement_0 != null)
			{
				method_3("XImage");
				method_292(xtextImageElement_0);
				method_48();
			}
		}

		private void method_292(XTextImageElement xtextImageElement_0)
		{
			int num = 7;
			if (xtextImageElement_0 != null)
			{
				method_7("StyleIndex", xtextImageElement_0.StyleIndex, -1);
				if (xtextImageElement_0.AdditionShape != null)
				{
					method_3("AdditionShape");
					method_86(xtextImageElement_0.AdditionShape);
					method_48();
				}
				method_35("AdditionShapeFixSize", xtextImageElement_0.AdditionShapeFixSize, bool_1: false);
				method_26("Alt", xtextImageElement_0.Alt, null);
				method_35("CompressSaveMode", xtextImageElement_0.CompressSaveMode, bool_1: true);
				method_26("ContentReadonly", GClass21.smethod_4(xtextImageElement_0.ContentReadonly), "Inherit");
				method_26("CustomAdditionShapeContent", xtextImageElement_0.CustomAdditionShapeContent, null);
				method_35("Deleteable", xtextImageElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextImageElement_0.Enabled, bool_1: true);
				method_35("EnableEditImageAdditionShape", xtextImageElement_0.EnableEditImageAdditionShape, bool_1: true);
				method_35("EnableRepeatedImage", xtextImageElement_0.EnableRepeatedImage, bool_1: false);
				method_26("EventTemplateName", xtextImageElement_0.EventTemplateName, null);
				method_30("Height", xtextImageElement_0.Height);
				method_26("ID", xtextImageElement_0.ID, null);
				if (xtextImageElement_0.Image != null)
				{
					method_3("Image");
					method_76(xtextImageElement_0.Image);
					method_48();
				}
				method_26("JavaScriptForClick", xtextImageElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextImageElement_0.JavaScriptForDoubleClick, null);
				method_35("KeepWidthHeightRate", xtextImageElement_0.KeepWidthHeightRate, bool_1: true);
				if (xtextImageElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextImageElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextImageElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextImageElement_0.PrintVisibility), "Visible");
				method_35("SaveContentInFile", xtextImageElement_0.SaveContentInFile, bool_1: true);
				method_35("SmoothZoom", xtextImageElement_0.SmoothZoom, bool_1: true);
				method_26("Source", xtextImageElement_0.Source, null);
				method_26("StringTag", xtextImageElement_0.StringTag, null);
				method_26("Title", xtextImageElement_0.Title, null);
				method_27("UserFlags", xtextImageElement_0.UserFlags, 0);
				method_26("VAlign", GClass21.smethod_4(xtextImageElement_0.VAlign), "Bottom");
				method_26("ValueExpression", xtextImageElement_0.ValueExpression, null);
				method_27("ValueIndexOfRepeatedImage", xtextImageElement_0.ValueIndexOfRepeatedImage, -1);
				method_35("Visible", xtextImageElement_0.Visible, bool_1: true);
				method_30("Width", xtextImageElement_0.Width);
				if (xtextImageElement_0.Attributes != null && xtextImageElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextImageElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextImageElement_0.PageImages != null && xtextImageElement_0.PageImages.Count > 0)
				{
					method_3("PageImages");
					foreach (PageImageInfo pageImage in xtextImageElement_0.PageImages)
					{
						method_3("Image");
						method_226(pageImage);
						method_48();
					}
					method_48();
				}
				if (xtextImageElement_0.PropertyExpressions != null && xtextImageElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextImageElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextImageElement_0.ScriptItems != null && xtextImageElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextImageElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_293(XTextInputFieldElement xtextInputFieldElement_0)
		{
			int num = 8;
			if (xtextInputFieldElement_0 != null)
			{
				method_3("XInputField");
				method_294(xtextInputFieldElement_0);
				method_48();
			}
		}

		private void method_294(XTextInputFieldElement xtextInputFieldElement_0)
		{
			int num = 9;
			if (xtextInputFieldElement_0 != null)
			{
				method_7("StyleIndex", xtextInputFieldElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextInputFieldElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextInputFieldElement_0.AcceptTab, bool_1: false);
				method_26("AdornTextType", GClass21.smethod_4(xtextInputFieldElement_0.AdornTextType), "Default");
				method_26("Alignment", GClass21.smethod_4(xtextInputFieldElement_0.Alignment), "Near");
				method_26("AutoHideMode", GClass21.smethod_4(xtextInputFieldElement_0.AutoHideMode), "None");
				method_35("AutoSetSpellCodeInDropdownList", xtextInputFieldElement_0.AutoSetSpellCodeInDropdownList, bool_1: false);
				method_26("BackgroundText", xtextInputFieldElement_0.BackgroundText, null);
				method_26("BackgroundTextColor", xtextInputFieldElement_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextInputFieldElement_0.BorderElementColorValue, null);
				method_26("BorderVisible", GClass21.smethod_4(xtextInputFieldElement_0.BorderVisible), "Default");
				if (xtextInputFieldElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextInputFieldElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextInputFieldElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextInputFieldElement_0.ContentReadonlyExpression, null);
				if (xtextInputFieldElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextInputFieldElement_0.CopySource);
					method_48();
				}
				method_26("CustomAdornText", xtextInputFieldElement_0.CustomAdornText, null);
				method_26("CustomValueEditorTypeName", xtextInputFieldElement_0.CustomValueEditorTypeName, null);
				method_26("DefaultEventExpression", xtextInputFieldElement_0.DefaultEventExpression, null);
				method_26("DefaultValueType", GClass21.smethod_4(xtextInputFieldElement_0.DefaultValueType), "None");
				method_35("Deleteable", xtextInputFieldElement_0.Deleteable, bool_1: true);
				if (xtextInputFieldElement_0.DisplayFormat != null)
				{
					method_3("DisplayFormat");
					method_62(xtextInputFieldElement_0.DisplayFormat);
					method_48();
				}
				method_26("EditorActiveMode", GClass21.smethod_4(xtextInputFieldElement_0.EditorActiveMode), "None,Program,F2,MouseDblClick");
				method_26("EditorControlTypeName", xtextInputFieldElement_0.EditorControlTypeName, null);
				method_26("ElementIDForEditableDependent", xtextInputFieldElement_0.ElementIDForEditableDependent, null);
				method_35("EnableFieldTextColor", xtextInputFieldElement_0.EnableFieldTextColor, bool_1: true);
				method_26("EnableHighlight", GClass21.smethod_4(xtextInputFieldElement_0.EnableHighlight), "Enabled");
				method_26("EnablePermission", GClass21.smethod_4(xtextInputFieldElement_0.EnablePermission), "Inherit");
				method_35("EnableValueEditor", xtextInputFieldElement_0.EnableValueEditor, bool_1: true);
				method_35("EnableValueValidate", xtextInputFieldElement_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextInputFieldElement_0.EndBorderText, null);
				method_26("EventTemplateName", xtextInputFieldElement_0.EventTemplateName, null);
				if (xtextInputFieldElement_0.FieldSettings != null)
				{
					method_3("FieldSettings");
					method_212(xtextInputFieldElement_0.FieldSettings);
					method_48();
				}
				method_26("FormButtonStyle", GClass21.smethod_4(xtextInputFieldElement_0.FormButtonStyle), "Auto");
				method_26("ID", xtextInputFieldElement_0.ID, null);
				method_26("InnerValue", xtextInputFieldElement_0.InnerValue, null);
				method_26("JavaScriptForClick", xtextInputFieldElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextInputFieldElement_0.JavaScriptForDoubleClick, null);
				method_26("LabelText", xtextInputFieldElement_0.LabelText, null);
				if (xtextInputFieldElement_0.LinkListBinding != null)
				{
					method_3("LinkListBinding");
					method_168(xtextInputFieldElement_0.LinkListBinding);
					method_48();
				}
				method_26("MoveFocusHotKey", GClass21.smethod_4(xtextInputFieldElement_0.MoveFocusHotKey), "Default");
				method_26("Name", xtextInputFieldElement_0.Name, null);
				method_26("PrintBackgroundText", GClass21.smethod_4(xtextInputFieldElement_0.PrintBackgroundText), "Inherit");
				method_26("PrintVisibility", GClass21.smethod_4(xtextInputFieldElement_0.PrintVisibility), "Visible");
				method_26("RuntimeMoveFocusHotKey", GClass21.smethod_4(xtextInputFieldElement_0.RuntimeMoveFocusHotKey), "None");
				method_27("SelectedIndex", xtextInputFieldElement_0.SelectedIndex, -1);
				method_26("SelectedSpellCode", xtextInputFieldElement_0.SelectedSpellCode, null);
				method_26("ShowFormButton", GClass21.smethod_4(xtextInputFieldElement_0.ShowFormButton), "Inherit");
				method_26("ShowInputFieldStateTag", GClass21.smethod_4(xtextInputFieldElement_0.ShowInputFieldStateTag), "Inherit");
				method_29("SpecifyWidth", xtextInputFieldElement_0.SpecifyWidth, 0f);
				method_26("StartBorderText", xtextInputFieldElement_0.StartBorderText, null);
				method_27("TabIndex", xtextInputFieldElement_0.TabIndex, 0);
				method_35("TabStop", xtextInputFieldElement_0.TabStop, bool_1: true);
				method_26("TextColor", xtextInputFieldElement_0.TextColorString, null);
				method_26("ToolTip", xtextInputFieldElement_0.ToolTip, null);
				method_26("UnitText", xtextInputFieldElement_0.UnitText, null);
				method_35("UserEditable", xtextInputFieldElement_0.UserEditable, bool_1: true);
				method_27("UserFlags", xtextInputFieldElement_0.UserFlags, 0);
				if (xtextInputFieldElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextInputFieldElement_0.ValidateStyle);
					method_48();
				}
				if (xtextInputFieldElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextInputFieldElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextInputFieldElement_0.ValueExpression, null);
				method_26("ViewEncryptType", GClass21.smethod_4(xtextInputFieldElement_0.ViewEncryptType), "None");
				method_35("Visible", xtextInputFieldElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextInputFieldElement_0.VisibleExpression, null);
				if (xtextInputFieldElement_0.Attributes != null && xtextInputFieldElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextInputFieldElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElement_0.ElementsForSerialize != null && xtextInputFieldElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextInputFieldElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextInputFieldElement_0.EventExpressions != null && xtextInputFieldElement_0.EventExpressions.Count > 0)
				{
					method_3("EventExpressions");
					foreach (EventExpressionInfo eventExpression in xtextInputFieldElement_0.EventExpressions)
					{
						method_3("Expression");
						method_334(eventExpression);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElement_0.Expressions != null && xtextInputFieldElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextInputFieldElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElement_0.LastSelectedListItems != null && xtextInputFieldElement_0.LastSelectedListItems.Count > 0)
				{
					method_3("LastSelectedListItems");
					foreach (ListItem lastSelectedListItem in xtextInputFieldElement_0.LastSelectedListItems)
					{
						method_3("Item");
						method_170(lastSelectedListItem);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElement_0.PropertyExpressions != null && xtextInputFieldElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextInputFieldElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElement_0.ScriptItems != null && xtextInputFieldElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextInputFieldElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_295(XTextInputFieldElementBase xtextInputFieldElementBase_0)
		{
			int num = 11;
			if (xtextInputFieldElementBase_0 != null)
			{
				method_3("XInputFieldBase");
				method_296(xtextInputFieldElementBase_0);
				method_48();
			}
		}

		private void method_296(XTextInputFieldElementBase xtextInputFieldElementBase_0)
		{
			int num = 13;
			if (xtextInputFieldElementBase_0 != null)
			{
				method_7("StyleIndex", xtextInputFieldElementBase_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextInputFieldElementBase_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextInputFieldElementBase_0.AcceptTab, bool_1: false);
				method_26("Alignment", GClass21.smethod_4(xtextInputFieldElementBase_0.Alignment), "Near");
				method_26("AutoHideMode", GClass21.smethod_4(xtextInputFieldElementBase_0.AutoHideMode), "None");
				method_26("BackgroundText", xtextInputFieldElementBase_0.BackgroundText, null);
				method_26("BackgroundTextColor", xtextInputFieldElementBase_0.BackgroundTextColorString, null);
				method_26("BorderElementColorValue", xtextInputFieldElementBase_0.BorderElementColorValue, null);
				method_26("BorderVisible", GClass21.smethod_4(xtextInputFieldElementBase_0.BorderVisible), "Default");
				if (xtextInputFieldElementBase_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextInputFieldElementBase_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextInputFieldElementBase_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextInputFieldElementBase_0.ContentReadonlyExpression, null);
				if (xtextInputFieldElementBase_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextInputFieldElementBase_0.CopySource);
					method_48();
				}
				method_26("DefaultEventExpression", xtextInputFieldElementBase_0.DefaultEventExpression, null);
				method_35("Deleteable", xtextInputFieldElementBase_0.Deleteable, bool_1: true);
				if (xtextInputFieldElementBase_0.DisplayFormat != null)
				{
					method_3("DisplayFormat");
					method_62(xtextInputFieldElementBase_0.DisplayFormat);
					method_48();
				}
				method_26("ElementIDForEditableDependent", xtextInputFieldElementBase_0.ElementIDForEditableDependent, null);
				method_26("EnableHighlight", GClass21.smethod_4(xtextInputFieldElementBase_0.EnableHighlight), "Enabled");
				method_26("EnablePermission", GClass21.smethod_4(xtextInputFieldElementBase_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextInputFieldElementBase_0.EnableValueValidate, bool_1: false);
				method_26("EndBorderText", xtextInputFieldElementBase_0.EndBorderText, null);
				method_26("EventTemplateName", xtextInputFieldElementBase_0.EventTemplateName, null);
				method_26("ID", xtextInputFieldElementBase_0.ID, null);
				method_26("InnerValue", xtextInputFieldElementBase_0.InnerValue, null);
				method_26("JavaScriptForClick", xtextInputFieldElementBase_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextInputFieldElementBase_0.JavaScriptForDoubleClick, null);
				method_26("LabelText", xtextInputFieldElementBase_0.LabelText, null);
				method_26("MoveFocusHotKey", GClass21.smethod_4(xtextInputFieldElementBase_0.MoveFocusHotKey), "Default");
				method_26("Name", xtextInputFieldElementBase_0.Name, null);
				method_26("PrintBackgroundText", GClass21.smethod_4(xtextInputFieldElementBase_0.PrintBackgroundText), "Inherit");
				method_26("PrintVisibility", GClass21.smethod_4(xtextInputFieldElementBase_0.PrintVisibility), "Visible");
				method_26("RuntimeMoveFocusHotKey", GClass21.smethod_4(xtextInputFieldElementBase_0.RuntimeMoveFocusHotKey), "None");
				method_26("SelectedSpellCode", xtextInputFieldElementBase_0.SelectedSpellCode, null);
				method_29("SpecifyWidth", xtextInputFieldElementBase_0.SpecifyWidth, 0f);
				method_26("StartBorderText", xtextInputFieldElementBase_0.StartBorderText, null);
				method_27("TabIndex", xtextInputFieldElementBase_0.TabIndex, 0);
				method_35("TabStop", xtextInputFieldElementBase_0.TabStop, bool_1: true);
				method_26("TextColor", xtextInputFieldElementBase_0.TextColorString, null);
				method_26("ToolTip", xtextInputFieldElementBase_0.ToolTip, null);
				method_26("UnitText", xtextInputFieldElementBase_0.UnitText, null);
				method_35("UserEditable", xtextInputFieldElementBase_0.UserEditable, bool_1: true);
				method_27("UserFlags", xtextInputFieldElementBase_0.UserFlags, 0);
				if (xtextInputFieldElementBase_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextInputFieldElementBase_0.ValidateStyle);
					method_48();
				}
				if (xtextInputFieldElementBase_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextInputFieldElementBase_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextInputFieldElementBase_0.ValueExpression, null);
				method_26("ViewEncryptType", GClass21.smethod_4(xtextInputFieldElementBase_0.ViewEncryptType), "None");
				method_35("Visible", xtextInputFieldElementBase_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextInputFieldElementBase_0.VisibleExpression, null);
				if (xtextInputFieldElementBase_0.Attributes != null && xtextInputFieldElementBase_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextInputFieldElementBase_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElementBase_0.ElementsForSerialize != null && xtextInputFieldElementBase_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextInputFieldElementBase_0.ElementsForSerialize);
					method_48();
				}
				if (xtextInputFieldElementBase_0.EventExpressions != null && xtextInputFieldElementBase_0.EventExpressions.Count > 0)
				{
					method_3("EventExpressions");
					foreach (EventExpressionInfo eventExpression in xtextInputFieldElementBase_0.EventExpressions)
					{
						method_3("Expression");
						method_334(eventExpression);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElementBase_0.Expressions != null && xtextInputFieldElementBase_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextInputFieldElementBase_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElementBase_0.PropertyExpressions != null && xtextInputFieldElementBase_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextInputFieldElementBase_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextInputFieldElementBase_0.ScriptItems != null && xtextInputFieldElementBase_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextInputFieldElementBase_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_297(XTextLabelElement xtextLabelElement_0)
		{
			int num = 18;
			if (xtextLabelElement_0 != null)
			{
				method_3("Element");
				method_298(xtextLabelElement_0);
				method_48();
			}
		}

		private void method_298(XTextLabelElement xtextLabelElement_0)
		{
			int num = 9;
			if (xtextLabelElement_0 != null)
			{
				method_7("StyleIndex", xtextLabelElement_0.StyleIndex, -1);
				method_26("Alignment", GClass21.smethod_4(xtextLabelElement_0.Alignment), "MiddleCenter");
				method_35("AllowUserEditCurrentPageLabelText", xtextLabelElement_0.AllowUserEditCurrentPageLabelText, bool_1: false);
				method_26("AttributeNameForContactAction", xtextLabelElement_0.AttributeNameForContactAction, null);
				method_35("AutoSize", xtextLabelElement_0.AutoSize, bool_1: true);
				method_26("ContactAction", GClass21.smethod_4(xtextLabelElement_0.ContactAction), "Disable");
				method_26("ContentReadonly", GClass21.smethod_4(xtextLabelElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextLabelElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextLabelElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextLabelElement_0.EventTemplateName, null);
				method_30("Height", xtextLabelElement_0.Height);
				method_26("ID", xtextLabelElement_0.ID, null);
				method_26("JavaScriptForClick", xtextLabelElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextLabelElement_0.JavaScriptForDoubleClick, null);
				if (xtextLabelElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextLabelElement_0.LinkInfo);
					method_48();
				}
				method_26("LinkTextForContactAction", xtextLabelElement_0.LinkTextForContactAction, null);
				method_35("Multiline", xtextLabelElement_0.Multiline, bool_1: true);
				method_26("Name", xtextLabelElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextLabelElement_0.PrintVisibility), "Visible");
				method_27("ReferencedTopicID", xtextLabelElement_0.ReferencedTopicID, -1);
				method_35("StrictMatchPageIndex", xtextLabelElement_0.StrictMatchPageIndex, bool_1: false);
				method_26("StringTag", xtextLabelElement_0.StringTag, null);
				method_25("Text", xtextLabelElement_0.Text);
				method_27("UserFlags", xtextLabelElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextLabelElement_0.ValueExpression, null);
				method_35("Visible", xtextLabelElement_0.Visible, bool_1: true);
				method_30("Width", xtextLabelElement_0.Width);
				if (xtextLabelElement_0.Attributes != null && xtextLabelElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextLabelElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextLabelElement_0.PageTexts != null && xtextLabelElement_0.PageTexts.Count > 0)
				{
					method_3("PageTexts");
					foreach (PageLabelText pageText in xtextLabelElement_0.PageTexts)
					{
						method_3("PageText");
						method_230(pageText);
						method_48();
					}
					method_48();
				}
				if (xtextLabelElement_0.PropertyExpressions != null && xtextLabelElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextLabelElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextLabelElement_0.ScriptItems != null && xtextLabelElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextLabelElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_299(XTextLineBreakElement xtextLineBreakElement_0)
		{
			int num = 19;
			if (xtextLineBreakElement_0 != null)
			{
				method_3("XLineBreak");
				method_300(xtextLineBreakElement_0);
				method_48();
			}
		}

		private void method_300(XTextLineBreakElement xtextLineBreakElement_0)
		{
			int num = 17;
			if (xtextLineBreakElement_0 != null)
			{
				method_7("StyleIndex", xtextLineBreakElement_0.StyleIndex, -1);
				method_26("ID", xtextLineBreakElement_0.ID, null);
				if (xtextLineBreakElement_0.Attributes != null && xtextLineBreakElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextLineBreakElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_301(XTextMediaElement xtextMediaElement_0)
		{
			int num = 12;
			if (xtextMediaElement_0 != null)
			{
				method_3("XMedia");
				method_302(xtextMediaElement_0);
				method_48();
			}
		}

		private void method_302(XTextMediaElement xtextMediaElement_0)
		{
			int num = 3;
			if (xtextMediaElement_0 != null)
			{
				method_7("StyleIndex", xtextMediaElement_0.StyleIndex, -1);
				method_26("AllowUserResize", GClass21.smethod_4(xtextMediaElement_0.AllowUserResize), "WidthAndHeight");
				method_26("ContentReadonly", GClass21.smethod_4(xtextMediaElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextMediaElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextMediaElement_0.Enabled, bool_1: true);
				method_35("EnableMediaContextMenu", xtextMediaElement_0.EnableMediaContextMenu, bool_1: true);
				method_35("EnableViewState", xtextMediaElement_0.EnableViewState, bool_1: true);
				method_26("EventTemplateName", xtextMediaElement_0.EventTemplateName, null);
				method_26("FileContentType", xtextMediaElement_0.FileContentType, null);
				method_26("FileName", xtextMediaElement_0.FileName, null);
				method_26("FileSystemName", xtextMediaElement_0.FileSystemName, null);
				method_30("Height", xtextMediaElement_0.Height);
				method_26("HostMode", GClass21.smethod_4(xtextMediaElement_0.HostMode), "Dynamic");
				method_26("ID", xtextMediaElement_0.ID, null);
				method_26("JavaScriptForClick", xtextMediaElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextMediaElement_0.JavaScriptForDoubleClick, null);
				if (xtextMediaElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextMediaElement_0.LinkInfo);
					method_48();
				}
				method_35("LoopPlay", xtextMediaElement_0.LoopPlay, bool_1: false);
				method_26("Name", xtextMediaElement_0.Name, null);
				method_26("OptionsPropertyName", xtextMediaElement_0.OptionsPropertyName, null);
				method_26("PlayerUIMode", GClass21.smethod_4(xtextMediaElement_0.PlayerUIMode), "mini");
				method_45("PreviewImageData", xtextMediaElement_0.PreviewImageData);
				method_26("PrintVisibility", GClass21.smethod_4(xtextMediaElement_0.PrintVisibility), "Visible");
				method_35("SavePreviewImage", xtextMediaElement_0.SavePreviewImage, bool_1: false);
				method_26("StringTag", xtextMediaElement_0.StringTag, null);
				method_26("Text", xtextMediaElement_0.Text, null);
				method_27("UserFlags", xtextMediaElement_0.UserFlags, 0);
				method_26("VAlign", GClass21.smethod_4(xtextMediaElement_0.VAlign), "Bottom");
				method_26("ValueExpression", xtextMediaElement_0.ValueExpression, null);
				method_26("ValuePropertyName", xtextMediaElement_0.ValuePropertyName, null);
				method_35("Visible", xtextMediaElement_0.Visible, bool_1: true);
				method_30("Width", xtextMediaElement_0.Width);
				if (xtextMediaElement_0.Attributes != null && xtextMediaElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextMediaElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextMediaElement_0.Parameters != null && xtextMediaElement_0.Parameters.Count > 0)
				{
					method_3("Parameters");
					foreach (ObjectParameter parameter in xtextMediaElement_0.Parameters)
					{
						method_3("Parameter");
						method_218(parameter);
						method_48();
					}
					method_48();
				}
				if (xtextMediaElement_0.PropertyExpressions != null && xtextMediaElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextMediaElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextMediaElement_0.ScriptItems != null && xtextMediaElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextMediaElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
				if (xtextMediaElement_0.ViewState != null && xtextMediaElement_0.ViewState.Count > 0)
				{
					method_3("ViewState");
					foreach (XMLViewStateBagItem item in xtextMediaElement_0.ViewState)
					{
						method_3("Item");
						method_180(item);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_303(XTextObjectElement xtextObjectElement_0)
		{
			int num = 15;
			if (xtextObjectElement_0 != null)
			{
				method_3("Element");
				method_304(xtextObjectElement_0);
				method_48();
			}
		}

		private void method_304(XTextObjectElement xtextObjectElement_0)
		{
			int num = 17;
			if (xtextObjectElement_0 != null)
			{
				method_7("StyleIndex", xtextObjectElement_0.StyleIndex, -1);
				method_26("ContentReadonly", GClass21.smethod_4(xtextObjectElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextObjectElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextObjectElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextObjectElement_0.EventTemplateName, null);
				method_26("ID", xtextObjectElement_0.ID, null);
				method_26("JavaScriptForClick", xtextObjectElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextObjectElement_0.JavaScriptForDoubleClick, null);
				if (xtextObjectElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextObjectElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextObjectElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextObjectElement_0.PrintVisibility), "Visible");
				method_26("StringTag", xtextObjectElement_0.StringTag, null);
				method_27("UserFlags", xtextObjectElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextObjectElement_0.ValueExpression, null);
				method_35("Visible", xtextObjectElement_0.Visible, bool_1: true);
				if (xtextObjectElement_0.Attributes != null && xtextObjectElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextObjectElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextObjectElement_0.PropertyExpressions != null && xtextObjectElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextObjectElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextObjectElement_0.ScriptItems != null && xtextObjectElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextObjectElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_305(XTextPageBreakElement xtextPageBreakElement_0)
		{
			int num = 17;
			if (xtextPageBreakElement_0 != null)
			{
				method_3("XPageBreak");
				method_306(xtextPageBreakElement_0);
				method_48();
			}
		}

		private void method_306(XTextPageBreakElement xtextPageBreakElement_0)
		{
			int num = 3;
			if (xtextPageBreakElement_0 != null)
			{
				method_7("StyleIndex", xtextPageBreakElement_0.StyleIndex, -1);
				method_26("ID", xtextPageBreakElement_0.ID, null);
				if (xtextPageBreakElement_0.Attributes != null && xtextPageBreakElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextPageBreakElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_307(XTextPageInfoElement xtextPageInfoElement_0)
		{
			int num = 2;
			if (xtextPageInfoElement_0 != null)
			{
				method_3("XPageInfo");
				method_308(xtextPageInfoElement_0);
				method_48();
			}
		}

		private void method_308(XTextPageInfoElement xtextPageInfoElement_0)
		{
			int num = 9;
			if (xtextPageInfoElement_0 != null)
			{
				method_7("StyleIndex", xtextPageInfoElement_0.StyleIndex, -1);
				method_35("AutoHeight", xtextPageInfoElement_0.AutoHeight, bool_1: false);
				method_35("ChangePageIndexMidway", xtextPageInfoElement_0.ChangePageIndexMidway, bool_1: true);
				method_26("ContentReadonly", GClass21.smethod_4(xtextPageInfoElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextPageInfoElement_0.Deleteable, bool_1: true);
				method_26("DisplayFormat", GClass21.smethod_4(xtextPageInfoElement_0.DisplayFormat), "ListNumberStyle");
				method_35("Enabled", xtextPageInfoElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextPageInfoElement_0.EventTemplateName, null);
				method_26("FormatString", xtextPageInfoElement_0.FormatString, null);
				method_30("Height", xtextPageInfoElement_0.Height);
				method_26("ID", xtextPageInfoElement_0.ID, null);
				method_26("JavaScriptForClick", xtextPageInfoElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextPageInfoElement_0.JavaScriptForDoubleClick, null);
				if (xtextPageInfoElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextPageInfoElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextPageInfoElement_0.Name, null);
				method_27("PageIndexFix", xtextPageInfoElement_0.PageIndexFix, 0);
				method_26("PrintVisibility", GClass21.smethod_4(xtextPageInfoElement_0.PrintVisibility), "Visible");
				method_26("SpecifyPageIndexTextList", xtextPageInfoElement_0.SpecifyPageIndexTextList, null);
				method_26("StringTag", xtextPageInfoElement_0.StringTag, null);
				method_27("UserFlags", xtextPageInfoElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextPageInfoElement_0.ValueExpression, null);
				method_26("ValueType", GClass21.smethod_4(xtextPageInfoElement_0.ValueType), "PageIndex");
				method_35("Visible", xtextPageInfoElement_0.Visible, bool_1: true);
				method_30("Width", xtextPageInfoElement_0.Width);
				if (xtextPageInfoElement_0.Attributes != null && xtextPageInfoElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextPageInfoElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextPageInfoElement_0.PropertyExpressions != null && xtextPageInfoElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextPageInfoElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextPageInfoElement_0.ScriptItems != null && xtextPageInfoElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextPageInfoElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
				if (xtextPageInfoElement_0.SpecifyPageIndexs != null && xtextPageInfoElement_0.SpecifyPageIndexs.Count > 0)
				{
					method_3("SpecifyPageIndexs");
					foreach (SpecifyPageIndexInfo specifyPageIndex in xtextPageInfoElement_0.SpecifyPageIndexs)
					{
						method_3("Index");
						method_242(specifyPageIndex);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_309(XTextParagraphFlagElement xtextParagraphFlagElement_0)
		{
			int num = 12;
			if (xtextParagraphFlagElement_0 != null)
			{
				method_3("XParagraphFlag");
				method_310(xtextParagraphFlagElement_0);
				method_48();
			}
		}

		private void method_310(XTextParagraphFlagElement xtextParagraphFlagElement_0)
		{
			int num = 15;
			if (xtextParagraphFlagElement_0 != null)
			{
				method_7("StyleIndex", xtextParagraphFlagElement_0.StyleIndex, -1);
				method_35("AutoCreate", xtextParagraphFlagElement_0.AutoCreate, bool_1: false);
				method_26("ID", xtextParagraphFlagElement_0.ID, null);
				method_35("ResetListIndexFlag", xtextParagraphFlagElement_0.ResetListIndexFlag, bool_1: false);
				method_27("TopicID", xtextParagraphFlagElement_0.TopicID, -1);
				if (xtextParagraphFlagElement_0.Attributes != null && xtextParagraphFlagElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextParagraphFlagElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_311(XTextRadioBoxElement xtextRadioBoxElement_0)
		{
			int num = 2;
			if (xtextRadioBoxElement_0 != null)
			{
				method_3("XTextRadioBox");
				method_312(xtextRadioBoxElement_0);
				method_48();
			}
		}

		private void method_312(XTextRadioBoxElement xtextRadioBoxElement_0)
		{
			int num = 16;
			if (xtextRadioBoxElement_0 != null)
			{
				method_7("StyleIndex", xtextRadioBoxElement_0.StyleIndex, -1);
				method_26("Caption", xtextRadioBoxElement_0.Caption, null);
				method_35("CheckAlignLeft", xtextRadioBoxElement_0.CheckAlignLeft, bool_1: true);
				method_35("Checked", xtextRadioBoxElement_0.Checked, bool_1: false);
				method_26("CheckedValue", xtextRadioBoxElement_0.CheckedValue, null);
				method_26("ContentReadonly", GClass21.smethod_4(xtextRadioBoxElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextRadioBoxElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextRadioBoxElement_0.Enabled, bool_1: true);
				method_26("EnableHighlight", GClass21.smethod_4(xtextRadioBoxElement_0.EnableHighlight), "Enabled");
				method_26("EventTemplateName", xtextRadioBoxElement_0.EventTemplateName, null);
				method_30("Height", xtextRadioBoxElement_0.Height);
				method_26("ID", xtextRadioBoxElement_0.ID, null);
				method_26("JavaScriptForClick", xtextRadioBoxElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextRadioBoxElement_0.JavaScriptForDoubleClick, null);
				if (xtextRadioBoxElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextRadioBoxElement_0.LinkInfo);
					method_48();
				}
				method_35("Multiline", xtextRadioBoxElement_0.Multiline, bool_1: false);
				method_26("Name", xtextRadioBoxElement_0.Name, null);
				method_26("PrintVisibilityWhenUnchecked", GClass21.smethod_4(xtextRadioBoxElement_0.PrintVisibilityWhenUnchecked), "Visible");
				method_26("PrintTextForChecked", xtextRadioBoxElement_0.PrintTextForChecked, null);
				method_26("PrintTextForUnChecked", xtextRadioBoxElement_0.PrintTextForUnChecked, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextRadioBoxElement_0.PrintVisibility), "Visible");
				method_35("Readonly", xtextRadioBoxElement_0.Readonly, bool_1: false);
				method_26("StringTag", xtextRadioBoxElement_0.StringTag, null);
				method_26("ToolTip", xtextRadioBoxElement_0.ToolTip, null);
				method_27("UserFlags", xtextRadioBoxElement_0.UserFlags, 0);
				if (xtextRadioBoxElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextRadioBoxElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextRadioBoxElement_0.ValueExpression, null);
				method_35("Visible", xtextRadioBoxElement_0.Visible, bool_1: true);
				method_26("VisualStyle", GClass21.smethod_4(xtextRadioBoxElement_0.VisualStyle), "Default");
				method_30("Width", xtextRadioBoxElement_0.Width);
				if (xtextRadioBoxElement_0.Attributes != null && xtextRadioBoxElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextRadioBoxElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextRadioBoxElement_0.EventExpressions != null && xtextRadioBoxElement_0.EventExpressions.Count > 0)
				{
					method_3("EventExpressions");
					foreach (EventExpressionInfo eventExpression in xtextRadioBoxElement_0.EventExpressions)
					{
						method_3("Expression");
						method_334(eventExpression);
						method_48();
					}
					method_48();
				}
				if (xtextRadioBoxElement_0.PropertyExpressions != null && xtextRadioBoxElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextRadioBoxElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextRadioBoxElement_0.ScriptItems != null && xtextRadioBoxElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextRadioBoxElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_313(XTextSectionElement xtextSectionElement_0)
		{
			int num = 14;
			if (xtextSectionElement_0 != null)
			{
				method_3("XTextSection");
				method_314(xtextSectionElement_0);
				method_48();
			}
		}

		private void method_314(XTextSectionElement xtextSectionElement_0)
		{
			int num = 4;
			if (xtextSectionElement_0 != null)
			{
				method_7("StyleIndex", xtextSectionElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextSectionElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextSectionElement_0.AcceptTab, bool_1: true);
				method_26("AutoHideMode", GClass21.smethod_4(xtextSectionElement_0.AutoHideMode), "None");
				method_35("CompressOwnerLineSpacing", xtextSectionElement_0.CompressOwnerLineSpacing, bool_1: false);
				if (xtextSectionElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextSectionElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextSectionElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextSectionElement_0.ContentReadonlyExpression, null);
				if (xtextSectionElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextSectionElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextSectionElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextSectionElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextSectionElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextSectionElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextSectionElement_0.EventTemplateName, null);
				if (xtextSectionElement_0.GridLine != null)
				{
					method_3("GridLine");
					method_78(xtextSectionElement_0.GridLine);
					method_48();
				}
				method_26("ID", xtextSectionElement_0.ID, null);
				method_26("JavaScriptForClick", xtextSectionElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextSectionElement_0.JavaScriptForDoubleClick, null);
				method_26("Name", xtextSectionElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextSectionElement_0.PrintVisibility), "Visible");
				method_29("SpecifyFixedLineHeight", xtextSectionElement_0.SpecifyFixedLineHeight, 0f);
				method_29("SpecifyHeight", xtextSectionElement_0.SpecifyHeight, 0f);
				method_27("UserFlags", xtextSectionElement_0.UserFlags, 0);
				if (xtextSectionElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextSectionElement_0.ValidateStyle);
					method_48();
				}
				if (xtextSectionElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextSectionElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextSectionElement_0.ValueExpression, null);
				method_35("Visible", xtextSectionElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextSectionElement_0.VisibleExpression, null);
				if (xtextSectionElement_0.Attributes != null && xtextSectionElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextSectionElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextSectionElement_0.ElementsForSerialize != null && xtextSectionElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextSectionElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextSectionElement_0.Expressions != null && xtextSectionElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextSectionElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextSectionElement_0.PropertyExpressions != null && xtextSectionElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextSectionElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextSectionElement_0.ScriptItems != null && xtextSectionElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextSectionElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_315(XTextSignElement xtextSignElement_0)
		{
			int num = 3;
			if (xtextSignElement_0 != null)
			{
				method_3("XTextLock");
				method_316(xtextSignElement_0);
				method_48();
			}
		}

		private void method_316(XTextSignElement xtextSignElement_0)
		{
			int num = 3;
			if (xtextSignElement_0 != null)
			{
				method_7("StyleIndex", xtextSignElement_0.StyleIndex, -1);
				method_26("ID", xtextSignElement_0.ID, null);
				if (xtextSignElement_0.Attributes != null && xtextSignElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextSignElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_317(XTextStringElement xtextStringElement_0)
		{
			int num = 15;
			if (xtextStringElement_0 != null)
			{
				method_3("XString");
				method_318(xtextStringElement_0);
				method_48();
			}
		}

		private void method_318(XTextStringElement xtextStringElement_0)
		{
			int num = 4;
			if (xtextStringElement_0 != null)
			{
				method_7("StyleIndex", xtextStringElement_0.StyleIndex, -1);
				method_7("WhiteSpaceLength", xtextStringElement_0.WhiteSpaceLength, 0);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextStringElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextStringElement_0.AcceptTab, bool_1: false);
				method_26("AutoHideMode", GClass21.smethod_4(xtextStringElement_0.AutoHideMode), "None");
				if (xtextStringElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextStringElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextStringElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextStringElement_0.ContentReadonlyExpression, null);
				if (xtextStringElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextStringElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextStringElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextStringElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextStringElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextStringElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextStringElement_0.EventTemplateName, null);
				method_26("ID", xtextStringElement_0.ID, null);
				method_26("JavaScriptForClick", xtextStringElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextStringElement_0.JavaScriptForDoubleClick, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextStringElement_0.PrintVisibility), "Visible");
				method_25("Text", xtextStringElement_0.Text);
				method_27("UserFlags", xtextStringElement_0.UserFlags, 0);
				if (xtextStringElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextStringElement_0.ValidateStyle);
					method_48();
				}
				if (xtextStringElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextStringElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextStringElement_0.ValueExpression, null);
				method_35("Visible", xtextStringElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextStringElement_0.VisibleExpression, null);
				if (xtextStringElement_0.Expressions != null && xtextStringElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextStringElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextStringElement_0.PropertyExpressions != null && xtextStringElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextStringElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextStringElement_0.ScriptItems != null && xtextStringElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextStringElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_319(XTextSubDocumentElement xtextSubDocumentElement_0)
		{
			int num = 0;
			if (xtextSubDocumentElement_0 != null)
			{
				method_3("XTextSubDocument");
				method_320(xtextSubDocumentElement_0);
				method_48();
			}
		}

		private void method_320(XTextSubDocumentElement xtextSubDocumentElement_0)
		{
			int num = 10;
			if (xtextSubDocumentElement_0 != null)
			{
				method_7("StyleIndex", xtextSubDocumentElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextSubDocumentElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextSubDocumentElement_0.AcceptTab, bool_1: true);
				method_26("AutoHideMode", GClass21.smethod_4(xtextSubDocumentElement_0.AutoHideMode), "None");
				method_35("CompressOwnerLineSpacing", xtextSubDocumentElement_0.CompressOwnerLineSpacing, bool_1: false);
				if (xtextSubDocumentElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextSubDocumentElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextSubDocumentElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextSubDocumentElement_0.ContentReadonlyExpression, null);
				if (xtextSubDocumentElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextSubDocumentElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextSubDocumentElement_0.Deleteable, bool_1: true);
				method_26("DocumentID", xtextSubDocumentElement_0.DocumentID, null);
				if (xtextSubDocumentElement_0.DocumentInfo != null)
				{
					method_3("DocumentInfo");
					method_204(xtextSubDocumentElement_0.DocumentInfo);
					method_48();
				}
				method_26("ElementIDForEditableDependent", xtextSubDocumentElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextSubDocumentElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextSubDocumentElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextSubDocumentElement_0.EventTemplateName, null);
				method_26("FileFormat", xtextSubDocumentElement_0.FileFormat, null);
				method_26("FileName", xtextSubDocumentElement_0.FileName, null);
				if (xtextSubDocumentElement_0.GridLine != null)
				{
					method_3("GridLine");
					method_78(xtextSubDocumentElement_0.GridLine);
					method_48();
				}
				method_26("ID", xtextSubDocumentElement_0.ID, null);
				method_35("ImportUserTrack", xtextSubDocumentElement_0.ImportUserTrack, bool_1: true);
				method_26("JavaScriptForClick", xtextSubDocumentElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextSubDocumentElement_0.JavaScriptForDoubleClick, null);
				method_35("Locked", xtextSubDocumentElement_0.Locked, bool_1: false);
				method_26("Name", xtextSubDocumentElement_0.Name, null);
				method_35("NewPage", xtextSubDocumentElement_0.NewPage, bool_1: false);
				method_35("Printed", xtextSubDocumentElement_0.Printed, bool_1: false);
				method_27("PrintedPageIndex", xtextSubDocumentElement_0.PrintedPageIndex, -1);
				method_29("PrintPositionInPage", xtextSubDocumentElement_0.PrintPositionInPage, 0f);
				method_26("PrintVisibility", GClass21.smethod_4(xtextSubDocumentElement_0.PrintVisibility), "Visible");
				method_29("SpecifyFixedLineHeight", xtextSubDocumentElement_0.SpecifyFixedLineHeight, 0f);
				method_29("SpecifyHeight", xtextSubDocumentElement_0.SpecifyHeight, 0f);
				method_27("UserFlags", xtextSubDocumentElement_0.UserFlags, 0);
				if (xtextSubDocumentElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextSubDocumentElement_0.ValidateStyle);
					method_48();
				}
				if (xtextSubDocumentElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextSubDocumentElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextSubDocumentElement_0.ValueExpression, null);
				method_35("Visible", xtextSubDocumentElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextSubDocumentElement_0.VisibleExpression, null);
				if (xtextSubDocumentElement_0.Attributes != null && xtextSubDocumentElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextSubDocumentElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextSubDocumentElement_0.ElementsForSerialize != null && xtextSubDocumentElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextSubDocumentElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextSubDocumentElement_0.Expressions != null && xtextSubDocumentElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextSubDocumentElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextSubDocumentElement_0.PropertyExpressions != null && xtextSubDocumentElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextSubDocumentElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextSubDocumentElement_0.ScriptItems != null && xtextSubDocumentElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextSubDocumentElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_321(XTextTableCellElement xtextTableCellElement_0)
		{
			int num = 6;
			if (xtextTableCellElement_0 != null)
			{
				method_3("XTextTableCell");
				method_322(xtextTableCellElement_0);
				method_48();
			}
		}

		private void method_322(XTextTableCellElement xtextTableCellElement_0)
		{
			int num = 12;
			if (xtextTableCellElement_0 != null)
			{
				method_7("StyleIndex", xtextTableCellElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextTableCellElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextTableCellElement_0.AcceptTab, bool_1: false);
				method_35("AutoFixFontSize", xtextTableCellElement_0.AutoFixFontSize, bool_1: false);
				method_26("AutoFixFontSizeMode", GClass21.smethod_4(xtextTableCellElement_0.AutoFixFontSizeMode), "None");
				method_26("AutoHideMode", GClass21.smethod_4(xtextTableCellElement_0.AutoHideMode), "None");
				method_35("BorderPrintedWhenJumpPrint", xtextTableCellElement_0.BorderPrintedWhenJumpPrint, bool_1: false);
				method_26("CloneType", GClass21.smethod_4(xtextTableCellElement_0.CloneType), "Default");
				method_27("ColSpan", xtextTableCellElement_0.ColSpan, 1);
				if (xtextTableCellElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextTableCellElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextTableCellElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextTableCellElement_0.ContentReadonlyExpression, null);
				if (xtextTableCellElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextTableCellElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextTableCellElement_0.Deleteable, bool_1: true);
				method_27("DesignColIndex", xtextTableCellElement_0.DesignColIndex, 0);
				method_27("DesignRowIndex", xtextTableCellElement_0.DesignRowIndex, 0);
				method_26("ElementIDForEditableDependent", xtextTableCellElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextTableCellElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextTableCellElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextTableCellElement_0.EventTemplateName, null);
				method_26("Expression", xtextTableCellElement_0.Expression, null);
				if (xtextTableCellElement_0.GridLine != null)
				{
					method_3("GridLine");
					method_78(xtextTableCellElement_0.GridLine);
					method_48();
				}
				method_26("ID", xtextTableCellElement_0.ID, null);
				method_26("JavaScriptForClick", xtextTableCellElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextTableCellElement_0.JavaScriptForDoubleClick, null);
				method_35("MirrorViewForCrossPage", xtextTableCellElement_0.MirrorViewForCrossPage, bool_1: false);
				method_26("MoveFocusHotKey", GClass21.smethod_4(xtextTableCellElement_0.MoveFocusHotKey), "Tab");
				method_26("PrintVisibility", GClass21.smethod_4(xtextTableCellElement_0.PrintVisibility), "Visible");
				method_27("RowSpan", xtextTableCellElement_0.RowSpan, 1);
				method_26("SlantSplitLineStyle", GClass21.smethod_4(xtextTableCellElement_0.SlantSplitLineStyle), "None");
				method_29("SpecifyFixedLineHeight", xtextTableCellElement_0.SpecifyFixedLineHeight, 0f);
				method_35("StressBorder", xtextTableCellElement_0.StressBorder, bool_1: false);
				method_35("TabStop", xtextTableCellElement_0.TabStop, bool_1: true);
				method_26("ToolTip", xtextTableCellElement_0.ToolTip, null);
				method_27("UserFlags", xtextTableCellElement_0.UserFlags, 0);
				if (xtextTableCellElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextTableCellElement_0.ValidateStyle);
					method_48();
				}
				if (xtextTableCellElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextTableCellElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextTableCellElement_0.ValueExpression, null);
				method_35("Visible", xtextTableCellElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextTableCellElement_0.VisibleExpression, null);
				if (xtextTableCellElement_0.Attributes != null && xtextTableCellElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextTableCellElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextTableCellElement_0.ElementsForSerialize != null && xtextTableCellElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextTableCellElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextTableCellElement_0.Expressions != null && xtextTableCellElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextTableCellElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextTableCellElement_0.PropertyExpressions != null && xtextTableCellElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextTableCellElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextTableCellElement_0.ScriptItems != null && xtextTableCellElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextTableCellElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_323(XTextTableColumnElement xtextTableColumnElement_0)
		{
			int num = 9;
			if (xtextTableColumnElement_0 != null)
			{
				method_3("XTextTableColumn");
				method_324(xtextTableColumnElement_0);
				method_48();
			}
		}

		private void method_324(XTextTableColumnElement xtextTableColumnElement_0)
		{
			int num = 16;
			if (xtextTableColumnElement_0 != null)
			{
				method_7("StyleIndex", xtextTableColumnElement_0.StyleIndex, -1);
				method_26("ID", xtextTableColumnElement_0.ID, null);
				if (xtextTableColumnElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextTableColumnElement_0.ValueBinding);
					method_48();
				}
				method_35("Visible", xtextTableColumnElement_0.Visible, bool_1: true);
				method_30("Width", xtextTableColumnElement_0.Width);
				if (xtextTableColumnElement_0.Attributes != null && xtextTableColumnElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextTableColumnElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_325(XTextTableElement xtextTableElement_0)
		{
			int num = 12;
			if (xtextTableElement_0 != null)
			{
				method_3("XTextTable");
				method_326(xtextTableElement_0);
				method_48();
			}
		}

		private void method_326(XTextTableElement xtextTableElement_0)
		{
			int num = 9;
			if (xtextTableElement_0 != null)
			{
				method_8("NumOfColumns", xtextTableElement_0.NumOfColumns);
				method_8("NumOfRows", xtextTableElement_0.NumOfRows);
				method_7("StyleIndex", xtextTableElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextTableElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextTableElement_0.AcceptTab, bool_1: false);
				method_35("AllowUserDeleteRow", xtextTableElement_0.AllowUserDeleteRow, bool_1: true);
				method_35("AllowUserInsertRow", xtextTableElement_0.AllowUserInsertRow, bool_1: true);
				method_35("AllowUserToResizeColumns", xtextTableElement_0.AllowUserToResizeColumns, bool_1: true);
				method_35("AllowUserToResizeEvenInFormViewMode", xtextTableElement_0.AllowUserToResizeEvenInFormViewMode, bool_1: false);
				method_35("AllowUserToResizeRows", xtextTableElement_0.AllowUserToResizeRows, bool_1: true);
				method_26("AutoHideMode", GClass21.smethod_4(xtextTableElement_0.AutoHideMode), "None");
				method_35("CompressOwnerLineSpacing", xtextTableElement_0.CompressOwnerLineSpacing, bool_1: false);
				if (xtextTableElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextTableElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextTableElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextTableElement_0.ContentReadonlyExpression, null);
				if (xtextTableElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextTableElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextTableElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextTableElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextTableElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextTableElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextTableElement_0.EventTemplateName, null);
				method_35("HoldWholeLine", xtextTableElement_0.HoldWholeLine, bool_1: true);
				method_26("ID", xtextTableElement_0.ID, null);
				method_26("JavaScriptForClick", xtextTableElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextTableElement_0.JavaScriptForDoubleClick, null);
				method_29("LeftIndent", xtextTableElement_0.LeftIndent, 0f);
				method_35("PrintBothBorderWhenJumpPrint", xtextTableElement_0.PrintBothBorderWhenJumpPrint, bool_1: false);
				method_26("PrintVisibility", GClass21.smethod_4(xtextTableElement_0.PrintVisibility), "Visible");
				method_27("UserFlags", xtextTableElement_0.UserFlags, 0);
				if (xtextTableElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextTableElement_0.ValidateStyle);
					method_48();
				}
				if (xtextTableElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextTableElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextTableElement_0.ValueExpression, null);
				method_35("Visible", xtextTableElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextTableElement_0.VisibleExpression, null);
				if (xtextTableElement_0.Attributes != null && xtextTableElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextTableElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextTableElement_0.Columns != null && xtextTableElement_0.Columns.Count > 0)
				{
					method_3("Columns");
					method_284(xtextTableElement_0.Columns);
					method_48();
				}
				if (xtextTableElement_0.ElementsForSerialize != null && xtextTableElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextTableElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextTableElement_0.Expressions != null && xtextTableElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextTableElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextTableElement_0.PropertyExpressions != null && xtextTableElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextTableElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextTableElement_0.ScriptItems != null && xtextTableElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextTableElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_327(XTextTableRowElement xtextTableRowElement_0)
		{
			int num = 13;
			if (xtextTableRowElement_0 != null)
			{
				method_3("XTextTableRow");
				method_328(xtextTableRowElement_0);
				method_48();
			}
		}

		private void method_328(XTextTableRowElement xtextTableRowElement_0)
		{
			int num = 7;
			if (xtextTableRowElement_0 != null)
			{
				method_7("StyleIndex", xtextTableRowElement_0.StyleIndex, -1);
				method_26("AcceptChildElementTypes2", GClass21.smethod_4(xtextTableRowElement_0.AcceptChildElementTypes2), "All");
				method_35("AcceptTab", xtextTableRowElement_0.AcceptTab, bool_1: false);
				method_35("AllowUserPressTabKeyToInsertRowDown", xtextTableRowElement_0.AllowUserPressTabKeyToInsertRowDown, bool_1: false);
				method_26("AllowUserToResizeHeight", GClass21.smethod_4(xtextTableRowElement_0.AllowUserToResizeHeight), "Inherit");
				method_26("AutoHideMode", GClass21.smethod_4(xtextTableRowElement_0.AutoHideMode), "None");
				method_35("CanSplitByPageLine", xtextTableRowElement_0.CanSplitByPageLine, bool_1: true);
				method_26("CloneType", GClass21.smethod_4(xtextTableRowElement_0.CloneType), "Default");
				if (xtextTableRowElement_0.ContentLock != null)
				{
					method_3("ContentLock");
					method_194(xtextTableRowElement_0.ContentLock);
					method_48();
				}
				method_26("ContentReadonly", GClass21.smethod_4(xtextTableRowElement_0.ContentReadonly), "Inherit");
				method_26("ContentReadonlyExpression", xtextTableRowElement_0.ContentReadonlyExpression, null);
				if (xtextTableRowElement_0.CopySource != null)
				{
					method_3("CopySource");
					method_192(xtextTableRowElement_0.CopySource);
					method_48();
				}
				method_35("Deleteable", xtextTableRowElement_0.Deleteable, bool_1: true);
				method_26("ElementIDForEditableDependent", xtextTableRowElement_0.ElementIDForEditableDependent, null);
				method_26("EnablePermission", GClass21.smethod_4(xtextTableRowElement_0.EnablePermission), "Inherit");
				method_35("EnableValueValidate", xtextTableRowElement_0.EnableValueValidate, bool_1: false);
				method_26("EventTemplateName", xtextTableRowElement_0.EventTemplateName, null);
				method_35("ExpendForDataBinding", xtextTableRowElement_0.ExpendForDataBinding, bool_1: true);
				method_35("HeaderStyle", xtextTableRowElement_0.HeaderStyle, bool_1: false);
				method_26("ID", xtextTableRowElement_0.ID, null);
				method_26("JavaScriptForClick", xtextTableRowElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextTableRowElement_0.JavaScriptForDoubleClick, null);
				method_35("NewPage", xtextTableRowElement_0.NewPage, bool_1: false);
				method_35("PrintCellBackground", xtextTableRowElement_0.PrintCellBackground, bool_1: true);
				method_35("PrintCellBorder", xtextTableRowElement_0.PrintCellBorder, bool_1: true);
				method_26("PrintVisibility", GClass21.smethod_4(xtextTableRowElement_0.PrintVisibility), "Visible");
				method_29("SpecifyHeight", xtextTableRowElement_0.SpecifyHeight, 0f);
				method_27("UserFlags", xtextTableRowElement_0.UserFlags, 0);
				if (xtextTableRowElement_0.ValidateStyle != null)
				{
					method_3("ValidateStyle");
					method_60(xtextTableRowElement_0.ValidateStyle);
					method_48();
				}
				if (xtextTableRowElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextTableRowElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextTableRowElement_0.ValueExpression, null);
				method_35("Visible", xtextTableRowElement_0.Visible, bool_1: true);
				method_26("VisibleExpression", xtextTableRowElement_0.VisibleExpression, null);
				if (xtextTableRowElement_0.Attributes != null && xtextTableRowElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextTableRowElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextTableRowElement_0.ElementsForSerialize != null && xtextTableRowElement_0.ElementsForSerialize.Count > 0)
				{
					method_3("XElements");
					method_284(xtextTableRowElement_0.ElementsForSerialize);
					method_48();
				}
				if (xtextTableRowElement_0.Expressions != null && xtextTableRowElement_0.Expressions.Count > 0)
				{
					method_3("Expressions");
					foreach (DomExpression expression in xtextTableRowElement_0.Expressions)
					{
						method_3("Expression");
						method_338(expression);
						method_48();
					}
					method_48();
				}
				if (xtextTableRowElement_0.PropertyExpressions != null && xtextTableRowElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextTableRowElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextTableRowElement_0.ScriptItems != null && xtextTableRowElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextTableRowElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_329(XTextTDBarcodeElement xtextTDBarcodeElement_0)
		{
			int num = 16;
			if (xtextTDBarcodeElement_0 != null)
			{
				method_3("XTDBarcodeField");
				method_330(xtextTDBarcodeElement_0);
				method_48();
			}
		}

		private void method_330(XTextTDBarcodeElement xtextTDBarcodeElement_0)
		{
			int num = 4;
			if (xtextTDBarcodeElement_0 != null)
			{
				method_7("StyleIndex", xtextTDBarcodeElement_0.StyleIndex, -1);
				method_26("BarcodeType", GClass21.smethod_4(xtextTDBarcodeElement_0.BarcodeType), "QR");
				method_26("ContentReadonly", GClass21.smethod_4(xtextTDBarcodeElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextTDBarcodeElement_0.Deleteable, bool_1: true);
				method_35("Enabled", xtextTDBarcodeElement_0.Enabled, bool_1: true);
				method_26("ErroeCorrectionLevel", GClass21.smethod_4(xtextTDBarcodeElement_0.ErroeCorrectionLevel), "M");
				method_26("EventTemplateName", xtextTDBarcodeElement_0.EventTemplateName, null);
				method_30("Height", xtextTDBarcodeElement_0.Height);
				method_26("ID", xtextTDBarcodeElement_0.ID, null);
				method_26("JavaScriptForClick", xtextTDBarcodeElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextTDBarcodeElement_0.JavaScriptForDoubleClick, null);
				if (xtextTDBarcodeElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextTDBarcodeElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextTDBarcodeElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextTDBarcodeElement_0.PrintVisibility), "Visible");
				method_26("StringTag", xtextTDBarcodeElement_0.StringTag, null);
				method_26("Text", xtextTDBarcodeElement_0.Text, null);
				method_27("UserFlags", xtextTDBarcodeElement_0.UserFlags, 0);
				method_26("VAlign", GClass21.smethod_4(xtextTDBarcodeElement_0.VAlign), "Bottom");
				if (xtextTDBarcodeElement_0.ValueBinding != null)
				{
					method_3("ValueBinding");
					method_176(xtextTDBarcodeElement_0.ValueBinding);
					method_48();
				}
				method_26("ValueExpression", xtextTDBarcodeElement_0.ValueExpression, null);
				method_35("Visible", xtextTDBarcodeElement_0.Visible, bool_1: true);
				method_30("Width", xtextTDBarcodeElement_0.Width);
				if (xtextTDBarcodeElement_0.Attributes != null && xtextTDBarcodeElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextTDBarcodeElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextTDBarcodeElement_0.PropertyExpressions != null && xtextTDBarcodeElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextTDBarcodeElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextTDBarcodeElement_0.ScriptItems != null && xtextTDBarcodeElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextTDBarcodeElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_331(XTextTemperatureChartElement xtextTemperatureChartElement_0)
		{
			int num = 7;
			if (xtextTemperatureChartElement_0 != null)
			{
				method_3("XTemperatureChart");
				method_332(xtextTemperatureChartElement_0);
				method_48();
			}
		}

		private void method_332(XTextTemperatureChartElement xtextTemperatureChartElement_0)
		{
			int num = 8;
			if (xtextTemperatureChartElement_0 != null)
			{
				method_7("StyleIndex", xtextTemperatureChartElement_0.StyleIndex, -1);
				method_27("ChartPageIndex", xtextTemperatureChartElement_0.ChartPageIndex, 0);
				method_26("ContentReadonly", GClass21.smethod_4(xtextTemperatureChartElement_0.ContentReadonly), "Inherit");
				method_35("Deleteable", xtextTemperatureChartElement_0.Deleteable, bool_1: true);
				if (xtextTemperatureChartElement_0.Document != null)
				{
					method_3("Document");
					method_130(xtextTemperatureChartElement_0.Document);
					method_48();
				}
				method_35("Enabled", xtextTemperatureChartElement_0.Enabled, bool_1: true);
				method_26("EventTemplateName", xtextTemperatureChartElement_0.EventTemplateName, null);
				method_30("Height", xtextTemperatureChartElement_0.Height);
				method_26("ID", xtextTemperatureChartElement_0.ID, null);
				method_26("JavaScriptForClick", xtextTemperatureChartElement_0.JavaScriptForClick, null);
				method_26("JavaScriptForDoubleClick", xtextTemperatureChartElement_0.JavaScriptForDoubleClick, null);
				if (xtextTemperatureChartElement_0.LinkInfo != null)
				{
					method_3("LinkInfo");
					method_58(xtextTemperatureChartElement_0.LinkInfo);
					method_48();
				}
				method_26("Name", xtextTemperatureChartElement_0.Name, null);
				method_26("PrintVisibility", GClass21.smethod_4(xtextTemperatureChartElement_0.PrintVisibility), "Visible");
				method_26("StringTag", xtextTemperatureChartElement_0.StringTag, null);
				method_27("UserFlags", xtextTemperatureChartElement_0.UserFlags, 0);
				method_26("ValueExpression", xtextTemperatureChartElement_0.ValueExpression, null);
				method_35("Visible", xtextTemperatureChartElement_0.Visible, bool_1: true);
				method_30("Width", xtextTemperatureChartElement_0.Width);
				if (xtextTemperatureChartElement_0.Attributes != null && xtextTemperatureChartElement_0.Attributes.Count > 0)
				{
					method_3("Attributes");
					foreach (XAttribute attribute in xtextTemperatureChartElement_0.Attributes)
					{
						method_3("Attribute");
						method_248(attribute);
						method_48();
					}
					method_48();
				}
				if (xtextTemperatureChartElement_0.PropertyExpressions != null && xtextTemperatureChartElement_0.PropertyExpressions.Count > 0)
				{
					method_3("PropertyExpressions");
					foreach (PropertyExpressionInfo propertyExpression in xtextTemperatureChartElement_0.PropertyExpressions)
					{
						method_3("Item");
						method_234(propertyExpression);
						method_48();
					}
					method_48();
				}
				if (xtextTemperatureChartElement_0.ScriptItems != null && xtextTemperatureChartElement_0.ScriptItems.Count > 0)
				{
					method_3("ScriptItems");
					foreach (VBScriptItem scriptItem in xtextTemperatureChartElement_0.ScriptItems)
					{
						method_3("Item");
						method_342(scriptItem);
						method_48();
					}
					method_48();
				}
			}
		}

		private void method_333(EventExpressionInfo eventExpressionInfo_0)
		{
			int num = 7;
			if (eventExpressionInfo_0 != null)
			{
				method_3("EventExpressionInfo");
				method_334(eventExpressionInfo_0);
				method_48();
			}
		}

		private void method_334(EventExpressionInfo eventExpressionInfo_0)
		{
			int num = 11;
			if (eventExpressionInfo_0 != null)
			{
				method_26("CustomTargetName", eventExpressionInfo_0.CustomTargetName, null);
				method_26("EventName", eventExpressionInfo_0.EventName, "ContentChanged");
				method_26("Expression", eventExpressionInfo_0.Expression, null);
				method_26("Target", GClass21.smethod_4(eventExpressionInfo_0.Target), "NextElement");
				method_26("TargetPropertyName", eventExpressionInfo_0.TargetPropertyName, "Visible");
			}
		}

		private void method_335(EventExpressionInfoList eventExpressionInfoList_0)
		{
			int num = 7;
			if (eventExpressionInfoList_0 != null)
			{
				method_3("EventExpressionInfoList");
				method_336(eventExpressionInfoList_0);
				method_48();
			}
		}

		private void method_336(EventExpressionInfoList eventExpressionInfoList_0)
		{
			int num = 10;
			if (eventExpressionInfoList_0 != null)
			{
				foreach (EventExpressionInfo item in eventExpressionInfoList_0)
				{
					method_3("EventExpressionInfo");
					method_334(item);
					method_48();
				}
			}
		}

		private void method_337(DomExpression domExpression_0)
		{
			int num = 15;
			if (domExpression_0 != null)
			{
				method_3("DomExpression");
				method_338(domExpression_0);
				method_48();
			}
		}

		private void method_338(DomExpression domExpression_0)
		{
			int num = 16;
			if (domExpression_0 != null)
			{
				method_26("Expression", domExpression_0.Expression, null);
				method_26("Name", domExpression_0.Name, null);
				method_26("Type", GClass21.smethod_4(domExpression_0.Type), "Simple");
			}
		}

		private void method_339(DomExpressionList domExpressionList_0)
		{
			int num = 5;
			if (domExpressionList_0 != null)
			{
				method_3("DomExpressionList");
				method_340(domExpressionList_0);
				method_48();
			}
		}

		private void method_340(DomExpressionList domExpressionList_0)
		{
			int num = 1;
			if (domExpressionList_0 != null)
			{
				foreach (DomExpression item in domExpressionList_0)
				{
					method_3("DomExpression");
					method_338(item);
					method_48();
				}
			}
		}

		private void method_341(VBScriptItem vbscriptItem_0)
		{
			int num = 7;
			if (vbscriptItem_0 != null)
			{
				method_3("VBScriptItem");
				method_342(vbscriptItem_0);
				method_48();
			}
		}

		private void method_342(VBScriptItem vbscriptItem_0)
		{
			int num = 7;
			if (vbscriptItem_0 != null)
			{
				method_26("Name", vbscriptItem_0.Name, null);
				method_26("ScriptText", vbscriptItem_0.ScriptText, null);
			}
		}

		private void method_343(VBScriptItemList vbscriptItemList_0)
		{
			int num = 6;
			if (vbscriptItemList_0 != null)
			{
				method_3("VBScriptItemList");
				method_344(vbscriptItemList_0);
				method_48();
			}
		}

		private void method_344(VBScriptItemList vbscriptItemList_0)
		{
			int num = 18;
			if (vbscriptItemList_0 != null)
			{
				foreach (VBScriptItem item in vbscriptItemList_0)
				{
					method_3("VBScriptItem");
					method_342(item);
					method_48();
				}
			}
		}

		private void method_345(DocumentSecurityOptions documentSecurityOptions_0)
		{
			int num = 7;
			if (documentSecurityOptions_0 != null)
			{
				method_3("DocumentSecurityOptions");
				method_346(documentSecurityOptions_0);
				method_48();
			}
		}

		private void method_346(DocumentSecurityOptions documentSecurityOptions_0)
		{
			int num = 17;
			if (documentSecurityOptions_0 != null)
			{
				method_35("AutoEnablePermissionWhenUserLogin", documentSecurityOptions_0.AutoEnablePermissionWhenUserLogin, bool_1: true);
				method_35("CanModifyDeleteSameLevelContent", documentSecurityOptions_0.CanModifyDeleteSameLevelContent, bool_1: true);
				method_26("CreatorTipFormatString", documentSecurityOptions_0.CreatorTipFormatString, null);
				method_26("DeleterTipFormatString", documentSecurityOptions_0.DeleterTipFormatString, null);
				method_35("EnableLogicDelete", documentSecurityOptions_0.EnableLogicDelete, bool_1: false);
				method_35("EnablePermission", documentSecurityOptions_0.EnablePermission, bool_1: false);
				method_35("PowerfulSignDocument", documentSecurityOptions_0.PowerfulSignDocument, bool_1: true);
				method_35("RealDeleteOwnerContent", documentSecurityOptions_0.RealDeleteOwnerContent, bool_1: false);
				method_35("ShowLogicDeletedContent", documentSecurityOptions_0.ShowLogicDeletedContent, bool_1: false);
				method_35("ShowPermissionMark", documentSecurityOptions_0.ShowPermissionMark, bool_1: false);
				method_35("ShowPermissionTip", documentSecurityOptions_0.ShowPermissionTip, bool_1: true);
				if (documentSecurityOptions_0.TrackVisibleLevel0 != null)
				{
					method_3("TrackVisibleLevel0");
					method_352(documentSecurityOptions_0.TrackVisibleLevel0);
					method_48();
				}
				if (documentSecurityOptions_0.TrackVisibleLevel1 != null)
				{
					method_3("TrackVisibleLevel1");
					method_352(documentSecurityOptions_0.TrackVisibleLevel1);
					method_48();
				}
				if (documentSecurityOptions_0.TrackVisibleLevel2 != null)
				{
					method_3("TrackVisibleLevel2");
					method_352(documentSecurityOptions_0.TrackVisibleLevel2);
					method_48();
				}
				if (documentSecurityOptions_0.TrackVisibleLevel3 != null)
				{
					method_3("TrackVisibleLevel3");
					method_352(documentSecurityOptions_0.TrackVisibleLevel3);
					method_48();
				}
			}
		}

		private void method_347(UserHistoryInfo userHistoryInfo_0)
		{
			int num = 13;
			if (userHistoryInfo_0 != null)
			{
				method_3("UserHistoryInfo");
				method_348(userHistoryInfo_0);
				method_48();
			}
		}

		private void method_348(UserHistoryInfo userHistoryInfo_0)
		{
			int num = 4;
			if (userHistoryInfo_0 != null)
			{
				method_7("Index", userHistoryInfo_0.Index, 0);
				method_26("ClientName", userHistoryInfo_0.ClientName, null);
				method_26("Description", userHistoryInfo_0.Description, null);
				method_26("ID", userHistoryInfo_0.ID, null);
				method_26("Name", userHistoryInfo_0.Name, null);
				method_26("Name2", userHistoryInfo_0.Name2, null);
				method_27("PermissionLevel", userHistoryInfo_0.PermissionLevel, 0);
				method_38("SavedTime", userHistoryInfo_0.SavedTime);
				method_26("Tag", userHistoryInfo_0.Tag, null);
			}
		}

		private void method_349(UserHistoryInfoList userHistoryInfoList_0)
		{
			int num = 5;
			if (userHistoryInfoList_0 != null)
			{
				method_3("UserHistoryInfoList");
				method_350(userHistoryInfoList_0);
				method_48();
			}
		}

		private void method_350(UserHistoryInfoList userHistoryInfoList_0)
		{
			int num = 8;
			if (userHistoryInfoList_0 != null)
			{
				foreach (UserHistoryInfo item in userHistoryInfoList_0)
				{
					method_3("UserHistoryInfo");
					method_348(item);
					method_48();
				}
			}
		}

		private void method_351(TrackVisibleConfig trackVisibleConfig_0)
		{
			int num = 17;
			if (trackVisibleConfig_0 != null)
			{
				method_3("TrackVisibleConfig");
				method_352(trackVisibleConfig_0);
				method_48();
			}
		}

		private void method_352(TrackVisibleConfig trackVisibleConfig_0)
		{
			int num = 14;
			if (trackVisibleConfig_0 != null)
			{
				method_26("BackgroundColorString", trackVisibleConfig_0.BackgroundColorString, null);
				method_26("DeleteLineColorString", trackVisibleConfig_0.DeleteLineColorString, null);
				method_27("DeleteLineNum", trackVisibleConfig_0.DeleteLineNum, 1);
				method_35("Enabled", trackVisibleConfig_0.Enabled, bool_1: true);
				method_27("UnderLineColorNum", trackVisibleConfig_0.UnderLineColorNum, 1);
				method_26("UnderLineColorString", trackVisibleConfig_0.UnderLineColorString, null);
			}
		}

		private void method_353(List<string> list_0)
		{
			int num = 9;
			if (list_0 != null)
			{
				method_3("StringList");
				method_354(list_0);
				method_48();
			}
		}

		private void method_354(List<string> list_0)
		{
			int num = 9;
			if (list_0 != null)
			{
				foreach (string item in list_0)
				{
					method_3("String");
					method_52(item);
					method_48();
				}
			}
		}
	}
}
