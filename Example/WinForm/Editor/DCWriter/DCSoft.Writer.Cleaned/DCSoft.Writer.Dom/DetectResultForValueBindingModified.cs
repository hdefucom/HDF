using DCSoft.Common;
using DCSoft.Writer.Data;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       检测数据源绑定导致的内容发送改变的结果信息
	///       </summary>
	[ComDefaultInterface(typeof(IDetectResultForValueBindingModified))]
	
	[ComVisible(true)]
	[ComClass("52097494-3A6F-46AB-8DA0-A4CE0FBBB88F", "04099AAE-3E03-4F64-88EA-E9F22FED98E1")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("52097494-3A6F-46AB-8DA0-A4CE0FBBB88F")]
	public class DetectResultForValueBindingModified : IDetectResultForValueBindingModified
	{
		internal const string CLASSID = "52097494-3A6F-46AB-8DA0-A4CE0FBBB88F";

		internal const string CLASSID_Interface = "04099AAE-3E03-4F64-88EA-E9F22FED98E1";

		private XDataBinding _Binding;

		private XTextElement _Element;

		private string _CurrentValue;

		private string _NewValue;

		public XDataBinding Binding => _Binding;

		public XTextElement Element => _Element;

		/// <summary>
		///       当前数值
		///       </summary>
		public string CurrentValue => _CurrentValue;

		/// <summary>
		///       新数值
		///       </summary>
		public string NewValue => _NewValue;

		public DetectResultForValueBindingModified(XDataBinding binding, XTextElement element, string currentValue, string newValue)
		{
			int num = 4;
			_Binding = null;
			_Element = null;
			_CurrentValue = null;
			_NewValue = null;
			
			if (binding == null)
			{
				throw new ArgumentNullException("binding");
			}
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			_Binding = binding;
			_Element = element;
			_CurrentValue = currentValue;
			_NewValue = newValue;
		}
	}
}
