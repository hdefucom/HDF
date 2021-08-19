using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.MedicalExpression
{
	/// <summary>
	///       医学表达式的样式
	///       </summary>
	[DCPublishAPI]
	[Guid("7F150F47-3A4B-41E9-8C54-6E05C56D6236")]
	[ComVisible(true)]
	[DocumentComment]
	public enum DCMedicalExpressionStyle
	{
		/// <summary>
		///       4个数值的样式
		///       </summary>
		/// <remarks>
		///                        Value2
		///       样式为   Value1 -------- Value4
		///                        Value3
		///       </remarks>
		FourValuesGeneral,
		/// <summary>
		///       4个数值的样式
		///       </summary>
		/// <remarks>
		///                        Value2
		///       样式为   Value1 -------- Value4
		///                        Value3
		///       </remarks>
		FourValues,
		/// <summary>
		///       4个数值的样式
		///       </summary>
		/// <remarks>
		///                Value1  |  Value2
		///       样式为   ------------------
		///                Value3  |  Value4
		///       </remarks>
		FourValues1,
		/// <summary>
		///       4个数值的样式
		///       </summary>
		/// <remarks>
		///                \Value2/
		///       样式为    \    /
		///                  \  / 
		///          Value1   \/ Value3
		///                   /\
		///                  /  \
		///                 /    \
		///                /Value4\
		///       </remarks>
		FourValues2,
		/// <summary>
		///       3个数值的样式
		///       </summary>
		/// <remarks>
		///                          Value2
		///       样式为   Value1 / --------
		///                          Value3
		///       </remarks>
		ThreeValues,
		/// <summary>
		///       瞳孔图
		///       </summary>
		/// <remarks>
		///       value1          value2
		///       value3  value4  value5
		///       value6          value7
		///       </remarks>
		Pupil,
		/// <summary>
		///       光定位
		///       </summary>
		/// <remarks>
		///       value1  value2  value3
		///       value4  value5  value6
		///       value7  value8  value9
		///       </remarks>
		LightPositioning,
		/// <summary>
		///       胎心图
		///       </summary>
		/// <remarks>
		///        Value1  |  Value2
		///       -Value3-----Value4-
		///        Value5  |  Value6
		///       </remarks>
		FetalHeart,
		/// <summary>
		///       恒压牙位图
		///       </summary>
		/// <remarks>
		///        RightTopValue1     RightTopValue2     RightTopValue3     RightTopValue4     RightTopValue5     RightTopValue6     RightTopValue7     RightTopValue8     |  LeftTopValue1     LeftTopValue2     LeftTopValue3     LeftTopValue4     LeftTopValue5     LeftTopValue6     LeftTopValue7     LeftTopValue8
		///        --------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------
		///        RightBottomValue1  RightBottomValue2  RightBottomValue3  RightBottomValue4  RightBottomValue5  RightBottomValue6  RightBottomValue7  RightBottomValue8  |  LeftBottomValue1  LeftBottomValue2  LeftBottomValue3  LeftBottomValue4  LeftBottomValue5  LeftBottomValue6  LeftBottomValue7  LeftBottomValue8
		///       </remarks>
		PermanentTeethBitmap,
		/// <summary>
		///       乳牙牙位图
		///       </summary>
		/// <remarks>
		///        RightTopValue1     RightTopValue2     RightTopValue3     RightTopValue4     RightTopValue5      |  LeftTopValue1     LeftTopValue2     LeftTopValue3     LeftTopValue4     LeftTopValue5   
		///        ------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------
		///        RightBottomValue1  RightBottomValue2  RightBottomValue3  RightBottomValue4  RightBottomValue5   |  LeftBottomValue1  LeftBottomValue2  LeftBottomValue3  LeftBottomValue4  LeftBottomValue5
		///       </remarks>
		DeciduousTeech,
		/// <summary>
		///       疼痛指数图
		///       </summary>
		/// <remarks>
		///        |       |       |       |       |       |       |       |       |       |       |
		///        |---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
		///        |       |       |       |       |       |       |       |       |       |       |
		///        0       1       2       3       4       5       6       7       8       9       10
		///       </remarks>
		PainIndex,
		/// <summary>
		///       PD牙位图
		///       </summary>
		/// <remarks>
		///                Value1  |  Value2  |  Value3
		///       样式为   -----------------------------
		///                Value4  |  Value5  |  Value6
		///       </remarks>
		PDTeech,
		/// <summary>
		///       病变下牙牙位图
		///       </summary>
		/// <remarks>
		///                          Value2
		///       样式为   Value1  --------
		///                          Value3
		///       </remarks>
		DiseasedTeethBotton,
		/// <summary>
		///       病变上牙牙位图
		///       </summary>
		/// <remarks>
		///                   \ Value1/  
		///       样式为       \     /
		///                 Value2| Value3
		///                       |
		///                       |
		///       </remarks>
		DiseasedTeethTop
	}
}
