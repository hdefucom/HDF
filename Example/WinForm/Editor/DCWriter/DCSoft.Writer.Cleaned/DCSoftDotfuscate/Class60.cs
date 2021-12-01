using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class60 : GInterface8
	{
		private WriterControl writerControl_0 = null;

		private static KBEntryList kbentryList_0 = new KBEntryList();

		public Class60(WriterControl writerControl_1)
		{
			writerControl_0 = writerControl_1;
		}

		private WriterControl method_0()
		{
			return writerControl_0;
		}

		public bool imethod_0(string string_0)
		{
			if (!method_6())
			{
				return false;
			}
			KBEntryList kBEntryList = method_3(string_0);
			if (kBEntryList == null)
			{
				return false;
			}
			if (kBEntryList != null && kBEntryList.Count > 0)
			{
				using (XTreeListBoxEditControl2 xTreeListBoxEditControl = new XTreeListBoxEditControl2())
				{
					xTreeListBoxEditControl.EditorHost = method_0().EditorHost;
					xTreeListBoxEditControl.EditorHost.ElementInstance = method_0().CurrentElement;
					foreach (KBEntry item in kBEntryList)
					{
						xTreeListBoxEditControl.ListBox.method_8().Add(method_5(item, bool_0: true));
					}
					xTreeListBoxEditControl.ListBox.method_28(bool_14: true);
					xTreeListBoxEditControl.ListBox.method_15(bool_14: false);
					xTreeListBoxEditControl.ListBox.vmethod_7(bool_14: false);
					xTreeListBoxEditControl.ButtonVisible = false;
					xTreeListBoxEditControl.ListBox.method_110(bool_14: false);
					method_0().InnerViewControl.method_226(xTreeListBoxEditControl.ListBox, bool_47: true);
					xTreeListBoxEditControl.Modified = false;
					if (xTreeListBoxEditControl.method_0())
					{
						method_0().Focus();
						method_0().UpdateTextCaret();
						if (xTreeListBoxEditControl.ListBox.method_78() != null)
						{
							KBEntry data = (KBEntry)xTreeListBoxEditControl.ListBox.method_78().method_27();
							InsertObjectEventArgs insertObjectEventArgs = new InsertObjectEventArgs(method_0().Document);
							insertObjectEventArgs.DataObject = new GClass303();
							insertObjectEventArgs.DataObject.SetData(typeof(KBEntry), data);
							method_0().OnEventInsertObject(insertObjectEventArgs);
							return insertObjectEventArgs.Result;
						}
					}
				}
			}
			return false;
		}

		public bool imethod_1()
		{
			if (!method_6())
			{
				return false;
			}
			KBEntryList kBEntryList = method_3(null);
			if (kBEntryList == null)
			{
				return false;
			}
			if (kBEntryList != null && kBEntryList.Count > 0)
			{
				using (XTreeListBoxEditControl2 xTreeListBoxEditControl = new XTreeListBoxEditControl2())
				{
					xTreeListBoxEditControl.EditorHost = method_0().EditorHost;
					method_0().EditorHost.KeepWriterControlFocused = false;
					xTreeListBoxEditControl.EditorHost.ElementInstance = method_0().CurrentElement;
					foreach (KBEntry item in kBEntryList)
					{
						xTreeListBoxEditControl.ListBox.method_8().Add(method_5(item, bool_0: false));
					}
					xTreeListBoxEditControl.ListBox.method_28(bool_14: true);
					xTreeListBoxEditControl.ListBox.method_15(bool_14: false);
					xTreeListBoxEditControl.ListBox.vmethod_7(bool_14: false);
					xTreeListBoxEditControl.ButtonVisible = false;
					xTreeListBoxEditControl.ListBox.method_110(bool_14: false);
					xTreeListBoxEditControl.ListBox.method_48(method_2);
					xTreeListBoxEditControl.ListBox.method_122(method_1);
					method_0().InnerViewControl.method_226(xTreeListBoxEditControl.ListBox, bool_47: true);
					xTreeListBoxEditControl.Modified = false;
					if (xTreeListBoxEditControl.method_0())
					{
						method_0().Focus();
						method_0().UpdateTextCaret();
						if (xTreeListBoxEditControl.ListBox.method_78() != null)
						{
							KBEntry data = (KBEntry)xTreeListBoxEditControl.ListBox.method_78().method_27();
							InsertObjectEventArgs insertObjectEventArgs = new InsertObjectEventArgs(method_0().Document);
							insertObjectEventArgs.DataObject = new GClass303();
							insertObjectEventArgs.DataObject.SetData(typeof(KBEntry), data);
							method_0().OnEventInsertObject(insertObjectEventArgs);
							return insertObjectEventArgs.Result;
						}
					}
				}
			}
			return false;
		}

		private void method_1(object sender, CancelEventArgs e)
		{
			GControl5 gControl = (GControl5)sender;
			string string_ = gControl.method_120();
			KBEntryList kBEntryList = method_3(string_);
			if (kBEntryList == kbentryList_0)
			{
				e.Cancel = true;
			}
			else if (kBEntryList != null && kBEntryList.Count > 0)
			{
				gControl.method_100();
				gControl.method_8().Clear();
				foreach (KBEntry item2 in kBEntryList)
				{
					GClass290 item = method_5(item2, bool_0: true);
					gControl.method_8().Add(item);
				}
				gControl.method_28(string.IsNullOrEmpty(gControl.method_120()));
				gControl.method_101();
				TextWindowsFormsEditorHost editorHost = method_0().EditorHost;
				editorHost.method_2();
				gControl.method_68(-1);
				gControl.method_68(0);
				e.Cancel = true;
			}
		}

		private void method_2(object sender, GEventArgs9 e)
		{
			IKBProvider iKBProvider = (IKBProvider)method_0().AppHost.Services.GetService(typeof(IKBProvider));
			if (iKBProvider != null)
			{
				List<KBEntry> subEntries = iKBProvider.GetSubEntries(method_0().AppHost, (KBEntry)e.method_0().method_27());
				if (subEntries != null && subEntries.Count > 0)
				{
					foreach (KBEntry item in subEntries)
					{
						e.method_1().Add(method_5(item, bool_0: false));
					}
				}
			}
		}

		private KBEntryList method_3(string string_0)
		{
			QueryKBEntriesEventArgs queryKBEntriesEventArgs = new QueryKBEntriesEventArgs(method_0(), string_0);
			method_0().method_66(queryKBEntriesEventArgs);
			if (queryKBEntriesEventArgs.Cancel)
			{
				return kbentryList_0;
			}
			KBEntryList kBEntryList = queryKBEntriesEventArgs.Result;
			if (kBEntryList == null)
			{
				KBLibrary kBLibrary = method_0().KBLibrary;
				if (kBLibrary == null)
				{
					kBLibrary = (KBLibrary)method_0().AppHost.Services.GetService(typeof(KBLibrary));
				}
				if (kBLibrary == null)
				{
					return null;
				}
				kBLibrary.UseLanguage2 = method_0().DocumentOptions.ViewOptions.UseLanguage2;
				kBEntryList = ((!string.IsNullOrEmpty(string_0)) ? kBLibrary.SearchKBEntries(string_0) : kBLibrary.KBEntries);
			}
			return kBEntryList;
		}

		private string method_4(KBEntry kbentry_0)
		{
			if (method_0().DocumentOptions.ViewOptions.UseLanguage2)
			{
				return kbentry_0.Text2;
			}
			return kbentry_0.Text;
		}

		private GClass290 method_5(KBEntry kbentry_0, bool bool_0)
		{
			int num = 10;
			GClass290 gClass = new GClass290();
			if (bool_0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (KBEntry parent = kbentry_0.Parent; parent != null; parent = parent.Parent)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Insert(0, "\\");
					}
					stringBuilder.Insert(0, method_4(parent));
				}
				if (stringBuilder.Length > 0)
				{
					gClass.method_3(method_4(kbentry_0) + " - " + stringBuilder.ToString());
				}
				else
				{
					gClass.method_3(method_4(kbentry_0));
				}
			}
			else
			{
				gClass.method_3(method_4(kbentry_0));
			}
			gClass.method_6(kbentry_0.Value);
			gClass.method_28(kbentry_0);
			if (kbentry_0 == KBEntry.NullKBEntry)
			{
				gClass.method_1(GEnum69.const_1);
				return gClass;
			}
			gClass.method_42(kbentry_0.SubEntries != null && kbentry_0.SubEntries.Count > 0);
			if (kbentry_0.Style == KBEntryStyle.Template)
			{
				gClass.method_30(WriterResources.KBTemplate);
				gClass.method_42(bool_5: false);
			}
			else if (!gClass.method_41())
			{
				gClass.method_30(WriterResources.KBBlankEntry);
			}
			else
			{
				gClass.method_30(WriterResources.KBListEntry);
			}
			return gClass;
		}

		private bool method_6()
		{
			if (method_0().Readonly)
			{
				return false;
			}
			if (!method_0().DocumentControler.CanInsertAtCurrentPosition)
			{
				return false;
			}
			if (method_0().EditorHost.EditingValue)
			{
				return false;
			}
			if ((method_0().AcceptDataFormats & WriterDataFormats.KBEntry) != WriterDataFormats.KBEntry)
			{
				return false;
			}
			return true;
		}
	}
}
