using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass28 : GInterface7
	{
		private XTextDocument xtextDocument_0;

		private List<XTextContainerElement> list_0;

		private int int_0;

		public GClass28(XTextDocument xtextDocument_1)
		{
			int num = 18;
			xtextDocument_0 = null;
			list_0 = null;
			int_0 = 0;
			
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public void imethod_0()
		{
			list_0 = null;
		}

		public XTextElementList imethod_1(XTextElement xtextElement_0)
		{
			if (xtextElement_0 == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(xtextElement_0.ID))
			{
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			XTextElementList elementsByType = method_0().GetElementsByType(typeof(XTextContainerElement));
			foreach (XTextContainerElement item in elementsByType)
			{
				if (item != xtextElement_0 && !item.IsParentOrSupParent(xtextElement_0) && !xtextElement_0.IsParentOrSupParent(item) && item.CopySource != null && !string.IsNullOrEmpty(item.CopySource.SourceID))
				{
					IDList iDList = new IDList(item.CopySource.SourceID);
					iDList.IgnoreCase = true;
					if (iDList.Contains(xtextElement_0.ID))
					{
						xTextElementList.Add(item);
					}
				}
			}
			return xTextElementList;
		}

		public int imethod_2(XTextElement xtextElement_0)
		{
			int num = 7;
			if (!XTextDocument.smethod_13(GEnum6.const_182))
			{
				return 0;
			}
			if (!method_0().Options.BehaviorOptions.EnableCopySource)
			{
				return 0;
			}
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("sourceElement");
			}
			if (string.IsNullOrEmpty(xtextElement_0.ID))
			{
				return 0;
			}
			if (int_0 > 0)
			{
				return 0;
			}
			int_0++;
			try
			{
				lock (this)
				{
					int num2 = 0;
					bool flag = false;
					WriterControlState writerControlState = null;
					if (!method_0().IsLoadingDocument && method_0().EditorControl != null && !method_0().EditorControl.IsUpdating)
					{
						flag = true;
					}
					DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(method_0());
					domTreeNodeEnumerable.ExcludeCharElement = true;
					domTreeNodeEnumerable.ExcludeParagraphFlag = true;
					foreach (XTextElement item in domTreeNodeEnumerable)
					{
						if (item is XTextContainerElement)
						{
							if (item == xtextElement_0)
							{
								domTreeNodeEnumerable.CancelChild();
							}
							else
							{
								XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
								if (xTextContainerElement.CopySource != null && !string.IsNullOrEmpty(xTextContainerElement.CopySource.SourceID))
								{
									string descPropertyName = xTextContainerElement.CopySource.DescPropertyName;
									if (!xTextContainerElement.IsParentOrSupParent(xtextElement_0))
									{
										IDList iDList = new IDList(xTextContainerElement.CopySource.SourceID);
										iDList.IgnoreCase = true;
										if (iDList.Contains(xtextElement_0.ID))
										{
											string sourcePropertyName = xTextContainerElement.CopySource.SourcePropertyName;
											bool flag2 = false;
											object object_ = null;
											if (string.IsNullOrEmpty(sourcePropertyName))
											{
												flag2 = true;
												object_ = xtextElement_0.Text;
											}
											else
											{
												flag2 = GClass348.smethod_1(xtextElement_0, sourcePropertyName, out object_);
											}
											if (flag2)
											{
												if (flag && writerControlState == null)
												{
													writerControlState = new WriterControlState(method_0().EditorControl);
												}
												bool flag3 = false;
												if (descPropertyName == null || descPropertyName.Length == 0)
												{
													xTextContainerElement.EditorTextExt = Convert.ToString(object_);
													flag3 = true;
												}
												else
												{
													flag3 = GClass348.smethod_3(xTextContainerElement, descPropertyName, object_, bool_0: false);
												}
												if (flag3)
												{
													num2++;
													if (xTextContainerElement.CopySource.IgnoreChildElements)
													{
														domTreeNodeEnumerable.CancelChild();
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (writerControlState != null && num2 > 0)
					{
						writerControlState.Restore();
					}
					return num2;
				}
			}
			finally
			{
				int_0--;
			}
		}

		public int imethod_4()
		{
			if (xtextDocument_0 == null)
			{
				return 0;
			}
			int num = 0;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(method_0());
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			List<XTextContainerElement> list = new List<XTextContainerElement>();
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				XTextContainerElement xTextContainerElement = item as XTextContainerElement;
				if (xTextContainerElement != null && xTextContainerElement.CopySource != null && !string.IsNullOrEmpty(xTextContainerElement.CopySource.SourceID))
				{
					list.Add(xTextContainerElement);
				}
			}
			foreach (XTextContainerElement item2 in list)
			{
				IDList iDList = new IDList(item2.CopySource.SourceID);
				foreach (string item3 in iDList)
				{
					XTextContainerElement xTextContainerElement2 = method_0().GetElementByIdExt(item3, idAttributeOnly: true) as XTextContainerElement;
					if (xTextContainerElement2 != null && method_1(xTextContainerElement2, item2))
					{
						num++;
						break;
					}
				}
			}
			return num;
		}

		private bool method_1(XTextContainerElement xtextContainerElement_0, XTextContainerElement xtextContainerElement_1)
		{
			string sourcePropertyName = xtextContainerElement_1.CopySource.SourcePropertyName;
			bool flag = false;
			object object_ = null;
			if (string.IsNullOrEmpty(sourcePropertyName))
			{
				flag = true;
				object_ = xtextContainerElement_0.Text;
			}
			else
			{
				flag = GClass348.smethod_1(xtextContainerElement_0, sourcePropertyName, out object_);
			}
			if (flag)
			{
				bool flag2 = false;
				string descPropertyName = xtextContainerElement_1.CopySource.DescPropertyName;
				if (descPropertyName == null || descPropertyName.Length == 0)
				{
					xtextContainerElement_1.EditorTextExt = Convert.ToString(object_);
					flag2 = true;
				}
				else
				{
					flag2 = GClass348.smethod_3(xtextContainerElement_1, descPropertyName, object_, bool_0: false);
				}
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		public List<CopySourceExecuteInfo> imethod_3()
		{
			List<CopySourceExecuteInfo> list = new List<CopySourceExecuteInfo>();
			XTextElementList elementsByType = method_0().GetElementsByType(typeof(XTextContainerElement));
			foreach (XTextContainerElement item in elementsByType)
			{
				if (item.CopySource != null && !string.IsNullOrEmpty(item.CopySource.SourceID))
				{
					IDList iDList = new IDList(item.CopySource.SourceID);
					iDList.IgnoreCase = true;
					foreach (XTextContainerElement item2 in elementsByType)
					{
						if (!string.IsNullOrEmpty(item2.ID) && item2 != item && !item2.IsParentOrSupParent(item) && !item.IsParentOrSupParent(item2) && iDList.Contains(item2.ID))
						{
							CopySourceExecuteInfo copySourceExecuteInfo = new CopySourceExecuteInfo();
							copySourceExecuteInfo.SourceElement = item2;
							copySourceExecuteInfo.TargetElement = item;
							copySourceExecuteInfo.SourcePropertyName = item.CopySource.SourcePropertyName;
							copySourceExecuteInfo.DescPropertyName = item.CopySource.DescPropertyName;
							list.Add(copySourceExecuteInfo);
						}
					}
				}
			}
			return list;
		}
	}
}
