using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	internal class Class137
	{
		private class Class138 : IComparer<GClass3>
		{
			public int Compare(GClass3 gclass3_0, GClass3 gclass3_1)
			{
				if (gclass3_0.method_0() == gclass3_1.method_0())
				{
					return gclass3_0.method_2() - gclass3_1.method_2();
				}
				return gclass3_1.method_0() - gclass3_0.method_0();
			}
		}

		private WriterViewControl writerViewControl_0;

		private bool bool_0;

		private bool bool_1;

		private XTextElementList xtextElementList_0;

		private List<GClass3> list_0;

		public Class137(WriterViewControl writerViewControl_1)
		{
			int num = 19;
			writerViewControl_0 = null;
			bool_0 = true;
			bool_1 = true;
			xtextElementList_0 = null;
			list_0 = null;
			
			if (writerViewControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			writerViewControl_0 = writerViewControl_1;
		}

		public void method_0()
		{
			bool_0 = true;
			bool_1 = true;
		}

		public void method_1()
		{
			bool_1 = true;
		}

		public void method_2()
		{
			writerViewControl_0 = null;
			method_3();
		}

		public void method_3()
		{
			if (xtextElementList_0 != null)
			{
				xtextElementList_0.Clear();
			}
			if (list_0 != null)
			{
				list_0.Clear();
			}
		}

		public void method_4()
		{
			if (!bool_0 && bool_1)
			{
				bool_1 = false;
				if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
				{
					foreach (XTextElement item in xtextElementList_0)
					{
						item.InvalidateView();
					}
				}
			}
			else if (bool_0 && !writerViewControl_0.IsUpdating)
			{
				bool_0 = false;
				if (xtextElementList_0 != null && xtextElementList_0.Count > 0)
				{
					foreach (XTextElement item2 in xtextElementList_0)
					{
						item2.InvalidateView();
					}
					xtextElementList_0.Clear();
				}
				xtextElementList_0 = new XTextElementList();
				DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(writerViewControl_0.Document);
				domTreeNodeEnumerable.ExcludeCharElement = true;
				domTreeNodeEnumerable.ExcludeParagraphFlag = true;
				foreach (XTextElement item3 in domTreeNodeEnumerable)
				{
					if (!item3.RuntimeVisible)
					{
						domTreeNodeEnumerable.CancelChild();
					}
					else if (item3.SupportElementViewHandle)
					{
						xtextElementList_0.Add(item3);
					}
				}
				xtextElementList_0.Reverse();
				list_0 = null;
			}
		}

		public void method_5()
		{
			list_0 = null;
		}

		public GClass3 method_6(XTextElement xtextElement_0)
		{
			if (list_0 != null)
			{
				foreach (GClass3 item in list_0)
				{
					if (item.method_6() == xtextElement_0)
					{
						return item;
					}
				}
			}
			return xtextElement_0.vmethod_2();
		}

		public void method_7(DocumentPaintEventArgs documentPaintEventArgs_0, XTextDocumentContentElement xtextDocumentContentElement_0)
		{
			method_4();
			foreach (XTextElement item in xtextElementList_0)
			{
				if (item.IsParentOrSupParent(xtextDocumentContentElement_0))
				{
					GClass3 gClass = item.vmethod_2();
					if (gClass != null)
					{
						gClass.vmethod_0(documentPaintEventArgs_0);
						if (list_0 == null)
						{
							list_0 = new List<GClass3>();
						}
						list_0.Add(gClass);
					}
				}
			}
		}

		public void method_8(DocumentEventArgs documentEventArgs_0)
		{
			if (list_0 == null || list_0.Count == 0 || (documentEventArgs_0.Style != DocumentEventStyles.MouseMove && documentEventArgs_0.Style != DocumentEventStyles.MouseDown))
			{
				return;
			}
			list_0.Sort(new Class138());
			int num = list_0.Count - 1;
			GClass3 gClass;
			while (num >= 0)
			{
				gClass = list_0[num];
				if (!gClass.method_19(documentEventArgs_0.X, documentEventArgs_0.Y))
				{
					num--;
					continue;
				}
				documentEventArgs_0.Cursor = gClass.method_20();
				documentEventArgs_0.Handled = true;
				if (documentEventArgs_0.Style == DocumentEventStyles.MouseMove && !string.IsNullOrEmpty(gClass.method_4()))
				{
					writerViewControl_0.method_94(gClass.method_4());
				}
				break;
			}
			if (documentEventArgs_0.Style != DocumentEventStyles.MouseDown)
			{
				return;
			}
			WriterMouseEventArgs writerMouseEventArgs = new WriterMouseEventArgs(writerViewControl_0.OwnerWriterControl, documentEventArgs_0.X, documentEventArgs_0.Y, documentEventArgs_0.MouseClicks, documentEventArgs_0.Button, documentEventArgs_0.WheelDelta);
			num = list_0.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					gClass = list_0[num];
					gClass.vmethod_1(writerMouseEventArgs);
					if (writerMouseEventArgs.Handled)
					{
						break;
					}
					num--;
					continue;
				}
				return;
			}
			documentEventArgs_0.Handled = true;
			documentEventArgs_0.Cursor = gClass.method_20();
		}
	}
}
