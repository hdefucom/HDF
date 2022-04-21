using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public class GEventArgs4 : EventArgs
	{
		private bool bool_0 = false;

		private bool bool_1 = false;

		private float float_0 = 0f;

		private ContentChangedEventSource contentChangedEventSource_0 = ContentChangedEventSource.Default;

		private XTextContainerElement xtextContainerElement_0 = null;

		private int int_0 = 0;

		private int int_1 = 0;

		private XTextElementList xtextElementList_0 = null;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private bool bool_5 = false;

		private bool bool_6 = true;

		private bool bool_7 = false;

		private DomAccessFlags domAccessFlags_0 = DomAccessFlags.Normal;

		private bool bool_8 = true;

		private bool bool_9 = false;

		private EventHandler eventHandler_0 = null;

		private object object_0 = null;

		private int int_2 = 0;

		public GEventArgs4()
		{
		}

		public GEventArgs4(XTextContainerElement xtextContainerElement_1, int int_3, int int_4, XTextElementList xtextElementList_1, bool bool_10, bool bool_11, bool bool_12)
		{
			xtextContainerElement_0 = xtextContainerElement_1;
			int_0 = int_3;
			int_1 = int_4;
			xtextElementList_0 = xtextElementList_1;
			bool_3 = bool_10;
			bool_4 = bool_11;
			bool_6 = bool_12;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_10)
		{
			bool_0 = bool_10;
		}

		internal bool method_2()
		{
			return bool_1;
		}

		internal void method_3(bool bool_10)
		{
			bool_1 = bool_10;
		}

		public float method_4()
		{
			return float_0;
		}

		public void method_5(float float_1)
		{
			float_0 = float_1;
		}

		public ContentChangedEventSource method_6()
		{
			return contentChangedEventSource_0;
		}

		public void method_7(ContentChangedEventSource contentChangedEventSource_1)
		{
			contentChangedEventSource_0 = contentChangedEventSource_1;
		}

		public XTextContainerElement method_8()
		{
			return xtextContainerElement_0;
		}

		public void method_9(XTextContainerElement xtextContainerElement_1)
		{
			xtextContainerElement_0 = xtextContainerElement_1;
		}

		public int method_10()
		{
			return int_0;
		}

		public void method_11(int int_3)
		{
			int_0 = int_3;
		}

		public int method_12()
		{
			return int_1;
		}

		public void method_13(int int_3)
		{
			int_1 = int_3;
		}

		public XTextElementList method_14()
		{
			return xtextElementList_0;
		}

		public void method_15(XTextElementList xtextElementList_1)
		{
			xtextElementList_0 = xtextElementList_1;
		}

		public bool method_16()
		{
			return bool_2;
		}

		public void method_17(bool bool_10)
		{
			bool_2 = bool_10;
		}

		public bool method_18()
		{
			return bool_3;
		}

		public void method_19(bool bool_10)
		{
			bool_3 = bool_10;
		}

		public bool method_20()
		{
			return bool_4;
		}

		public void method_21(bool bool_10)
		{
			bool_4 = bool_10;
		}

		public bool method_22()
		{
			return bool_5;
		}

		public void method_23(bool bool_10)
		{
			bool_5 = bool_10;
		}

		public bool method_24()
		{
			return bool_6;
		}

		public void method_25(bool bool_10)
		{
			bool_6 = bool_10;
		}

		public bool method_26()
		{
			return bool_7;
		}

		public void method_27(bool bool_10)
		{
			bool_7 = bool_10;
		}

		public DomAccessFlags method_28()
		{
			return domAccessFlags_0;
		}

		public void method_29(DomAccessFlags domAccessFlags_1)
		{
			domAccessFlags_0 = domAccessFlags_1;
		}

		public bool method_30()
		{
			return bool_8;
		}

		public void method_31(bool bool_10)
		{
			bool_8 = bool_10;
		}

		public bool method_32()
		{
			return bool_9;
		}

		public void method_33(bool bool_10)
		{
			bool_9 = bool_10;
		}

		public EventHandler method_34()
		{
			return eventHandler_0;
		}

		public void method_35(EventHandler eventHandler_1)
		{
			eventHandler_0 = eventHandler_1;
		}

		public object method_36()
		{
			return object_0;
		}

		public void method_37(object object_1)
		{
			object_0 = object_1;
		}

		public int method_38()
		{
			return int_2;
		}

		public void method_39(int int_3)
		{
			int_2 = int_3;
		}
	}
}
