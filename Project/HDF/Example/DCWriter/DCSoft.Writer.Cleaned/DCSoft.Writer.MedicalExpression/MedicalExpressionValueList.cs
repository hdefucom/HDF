using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.MedicalExpression
{
	[Serializable]
	[ComDefaultInterface(typeof(IMedicalExpressionValueList))]
	[ComClass("2BCE1B06-CD7F-4FC1-A564-2B78E5E66720", "4043911F-3EB5-41F1-B26B-AE33AD6CBC2B")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("2BCE1B06-CD7F-4FC1-A564-2B78E5E66720")]
	[DocumentComment]
	[ComVisible(true)]
	[DebuggerDisplay("Count={ Count }")]
	public class MedicalExpressionValueList : DCNameValueList, IDCStringSerializable, IMedicalExpressionValueList
	{
		internal const string CLASSID = "2BCE1B06-CD7F-4FC1-A564-2B78E5E66720";

		internal const string CLASSID_Interface = "4043911F-3EB5-41F1-B26B-AE33AD6CBC2B";

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string LeftBottomValue1
		{
			get
			{
				return GetValue("LeftBottomValue1");
			}
			set
			{
				SetValue("LeftBottomValue1", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string LeftBottomValue2
		{
			get
			{
				return GetValue("LeftBottomValue2");
			}
			set
			{
				SetValue("LeftBottomValue2", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string LeftBottomValue3
		{
			get
			{
				return GetValue("LeftBottomValue3");
			}
			set
			{
				SetValue("LeftBottomValue3", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string LeftBottomValue4
		{
			get
			{
				return GetValue("LeftBottomValue4");
			}
			set
			{
				SetValue("LeftBottomValue4", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string LeftBottomValue5
		{
			get
			{
				return GetValue("LeftBottomValue5");
			}
			set
			{
				SetValue("LeftBottomValue5", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string LeftBottomValue6
		{
			get
			{
				return GetValue("LeftBottomValue6");
			}
			set
			{
				SetValue("LeftBottomValue6", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string LeftBottomValue7
		{
			get
			{
				return GetValue("LeftBottomValue7");
			}
			set
			{
				SetValue("LeftBottomValue7", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string LeftBottomValue8
		{
			get
			{
				return GetValue("LeftBottomValue8");
			}
			set
			{
				SetValue("LeftBottomValue8", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string LeftTopValue1
		{
			get
			{
				return GetValue("LeftTopValue1");
			}
			set
			{
				SetValue("LeftTopValue1", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string LeftTopValue2
		{
			get
			{
				return GetValue("LeftTopValue2");
			}
			set
			{
				SetValue("LeftTopValue2", value);
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string LeftTopValue3
		{
			get
			{
				return GetValue("LeftTopValue3");
			}
			set
			{
				SetValue("LeftTopValue3", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string LeftTopValue4
		{
			get
			{
				return GetValue("LeftTopValue4");
			}
			set
			{
				SetValue("LeftTopValue4", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string LeftTopValue5
		{
			get
			{
				return GetValue("LeftTopValue5");
			}
			set
			{
				SetValue("LeftTopValue5", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string LeftTopValue6
		{
			get
			{
				return GetValue("LeftTopValue6");
			}
			set
			{
				SetValue("LeftTopValue6", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string LeftTopValue7
		{
			get
			{
				return GetValue("LeftTopValue7");
			}
			set
			{
				SetValue("LeftTopValue7", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string LeftTopValue8
		{
			get
			{
				return GetValue("LeftTopValue8");
			}
			set
			{
				SetValue("LeftTopValue8", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string RightBottomValue1
		{
			get
			{
				return GetValue("RightBottomValue1");
			}
			set
			{
				SetValue("RightBottomValue1", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string RightBottomValue2
		{
			get
			{
				return GetValue("RightBottomValue2");
			}
			set
			{
				SetValue("RightBottomValue2", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string RightBottomValue3
		{
			get
			{
				return GetValue("RightBottomValue3");
			}
			set
			{
				SetValue("RightBottomValue3", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string RightBottomValue4
		{
			get
			{
				return GetValue("RightBottomValue4");
			}
			set
			{
				SetValue("RightBottomValue4", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string RightBottomValue5
		{
			get
			{
				return GetValue("RightBottomValue5");
			}
			set
			{
				SetValue("RightBottomValue5", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string RightBottomValue6
		{
			get
			{
				return GetValue("RightBottomValue6");
			}
			set
			{
				SetValue("RightBottomValue6", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string RightBottomValue7
		{
			get
			{
				return GetValue("RightBottomValue7");
			}
			set
			{
				SetValue("RightBottomValue7", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string RightBottomValue8
		{
			get
			{
				return GetValue("RightBottomValue8");
			}
			set
			{
				SetValue("RightBottomValue8", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string RightTopValue1
		{
			get
			{
				return GetValue("RightTopValue1");
			}
			set
			{
				SetValue("RightTopValue1", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string RightTopValue2
		{
			get
			{
				return GetValue("RightTopValue2");
			}
			set
			{
				SetValue("RightTopValue2", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string RightTopValue3
		{
			get
			{
				return GetValue("RightTopValue3");
			}
			set
			{
				SetValue("RightTopValue3", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string RightTopValue4
		{
			get
			{
				return GetValue("RightTopValue4");
			}
			set
			{
				SetValue("RightTopValue4", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string RightTopValue5
		{
			get
			{
				return GetValue("RightTopValue5");
			}
			set
			{
				SetValue("RightTopValue5", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string RightTopValue6
		{
			get
			{
				return GetValue("RightTopValue6");
			}
			set
			{
				SetValue("RightTopValue6", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string RightTopValue7
		{
			get
			{
				return GetValue("RightTopValue7");
			}
			set
			{
				SetValue("RightTopValue7", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string RightTopValue8
		{
			get
			{
				return GetValue("RightTopValue8");
			}
			set
			{
				SetValue("RightTopValue8", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value1
		{
			get
			{
				return GetValue("Value1");
			}
			set
			{
				SetValue("Value1", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Value2
		{
			get
			{
				return GetValue("Value2");
			}
			set
			{
				SetValue("Value2", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Value3
		{
			get
			{
				return GetValue("Value3");
			}
			set
			{
				SetValue("Value3", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value4
		{
			get
			{
				return GetValue("Value4");
			}
			set
			{
				SetValue("Value4", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value5
		{
			get
			{
				return GetValue("Value5");
			}
			set
			{
				SetValue("Value5", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value6
		{
			get
			{
				return GetValue("Value6");
			}
			set
			{
				SetValue("Value6", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value7
		{
			get
			{
				return GetValue("Value7");
			}
			set
			{
				SetValue("Value7", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Value8
		{
			get
			{
				return GetValue("Value8");
			}
			set
			{
				SetValue("Value8", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value9
		{
			get
			{
				return GetValue("Value9");
			}
			set
			{
				SetValue("Value9", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string Value10
		{
			get
			{
				return GetValue("Value10");
			}
			set
			{
				SetValue("Value10", value);
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string Value11
		{
			get
			{
				return GetValue("Value11");
			}
			set
			{
				SetValue("Value11", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Value12
		{
			get
			{
				return GetValue("Value12");
			}
			set
			{
				SetValue("Value12", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value13
		{
			get
			{
				return GetValue("Value13");
			}
			set
			{
				SetValue("Value13", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value14
		{
			get
			{
				return GetValue("Value14");
			}
			set
			{
				SetValue("Value14", value);
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string Value15
		{
			get
			{
				return GetValue("Value15");
			}
			set
			{
				SetValue("Value15", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value16
		{
			get
			{
				return GetValue("Value16");
			}
			set
			{
				SetValue("Value16", value);
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string Value17
		{
			get
			{
				return GetValue("Value17");
			}
			set
			{
				SetValue("Value17", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value18
		{
			get
			{
				return GetValue("Value18");
			}
			set
			{
				SetValue("Value18", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string Value19
		{
			get
			{
				return GetValue("Value19");
			}
			set
			{
				SetValue("Value19", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value20
		{
			get
			{
				return GetValue("Value20");
			}
			set
			{
				SetValue("Value20", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value21
		{
			get
			{
				return GetValue("Value21");
			}
			set
			{
				SetValue("Value21", value);
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string Value22
		{
			get
			{
				return GetValue("Value22");
			}
			set
			{
				SetValue("Value22", value);
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string Value23
		{
			get
			{
				return GetValue("Value23");
			}
			set
			{
				SetValue("Value23", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Value24
		{
			get
			{
				return GetValue("Value24");
			}
			set
			{
				SetValue("Value24", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value25
		{
			get
			{
				return GetValue("Value25");
			}
			set
			{
				SetValue("Value25", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value26
		{
			get
			{
				return GetValue("Value26");
			}
			set
			{
				SetValue("Value26", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string Value27
		{
			get
			{
				return GetValue("Value27");
			}
			set
			{
				SetValue("Value27", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Value28
		{
			get
			{
				return GetValue("Value28");
			}
			set
			{
				SetValue("Value28", value);
			}
		}

		[DefaultValue(null)]
		[XmlIgnore]
		[ComVisible(true)]
		public string Value29
		{
			get
			{
				return GetValue("Value29");
			}
			set
			{
				SetValue("Value29", value);
			}
		}

		[ComVisible(true)]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Value30
		{
			get
			{
				return GetValue("Value30");
			}
			set
			{
				SetValue("Value30", value);
			}
		}

		[DefaultValue(null)]
		[ComVisible(true)]
		[XmlIgnore]
		public string Value31
		{
			get
			{
				return GetValue("Value31");
			}
			set
			{
				SetValue("Value31", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string Value32
		{
			get
			{
				return GetValue("Value32");
			}
			set
			{
				SetValue("Value32", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value33
		{
			get
			{
				return GetValue("Value33");
			}
			set
			{
				SetValue("Value33", value);
			}
		}

		[ComVisible(true)]
		[DefaultValue(null)]
		[XmlIgnore]
		public string Value34
		{
			get
			{
				return GetValue("Value34");
			}
			set
			{
				SetValue("Value34", value);
			}
		}

		[XmlIgnore]
		[ComVisible(true)]
		[DefaultValue(null)]
		public string Value35
		{
			get
			{
				return GetValue("Value35");
			}
			set
			{
				SetValue("Value35", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string Value36
		{
			get
			{
				return GetValue("Value36");
			}
			set
			{
				SetValue("Value36", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string Value37
		{
			get
			{
				return GetValue("Value37");
			}
			set
			{
				SetValue("Value37", value);
			}
		}

		[XmlIgnore]
		[DefaultValue(null)]
		[ComVisible(true)]
		public string Value38
		{
			get
			{
				return GetValue("Value38");
			}
			set
			{
				SetValue("Value38", value);
			}
		}

		[DCInternal]
		public string DCWriteString()
		{
			GClass338 gClass = new GClass338();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCNameValueItem current = enumerator.Current;
					gClass.method_2(current.Name, current.Value);
				}
			}
			return gClass.ToString();
		}

		[DCInternal]
		public void DCReadString(string text)
		{
			Clear();
			GClass340 gClass = new GClass340(text);
			foreach (GClass341 item in gClass)
			{
				DCNameValueItem dCNameValueItem = new DCNameValueItem();
				dCNameValueItem.Name = item.Name;
				dCNameValueItem.Value = item.method_0();
				Add(dCNameValueItem);
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCInternal]
		public new MedicalExpressionValueList Clone()
		{
			MedicalExpressionValueList medicalExpressionValueList = new MedicalExpressionValueList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DCNameValueItem current = enumerator.Current;
					medicalExpressionValueList.Add(current.Clone());
				}
			}
			return medicalExpressionValueList;
		}

		string IMedicalExpressionValueList.GetValue(string param0)
		{
			return GetValue(param0);
		}

		bool IMedicalExpressionValueList.SetValue(string param0, string param1)
		{
			return SetValue(param0, param1);
		}
	}
}
