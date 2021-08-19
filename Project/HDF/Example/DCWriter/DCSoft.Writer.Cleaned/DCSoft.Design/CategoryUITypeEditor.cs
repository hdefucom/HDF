using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Design
{
	[ComVisible(false)]
	public class CategoryUITypeEditor : ListBoxUITypeEditor
	{
		private static List<string> _StdCategories = null;

		                                                                    /// <summary>
		                                                                    ///       可选的分类名称列表
		                                                                    ///       </summary>
		public static List<string> StdCategories
		{
			get
			{
				int num = 3;
				if (_StdCategories == null)
				{
					_StdCategories = new List<string>();
					_StdCategories.Add("Action");
					_StdCategories.Add("Appearance");
					_StdCategories.Add("Behavior");
					_StdCategories.Add("Data");
					_StdCategories.Add("Default");
					_StdCategories.Add("Design");
					_StdCategories.Add("DragDrop");
					_StdCategories.Add("Focus");
					_StdCategories.Add("Format");
					_StdCategories.Add("Key");
					_StdCategories.Add("Layout");
					_StdCategories.Add("Mouse");
					_StdCategories.Add("WindowStyle");
				}
				return _StdCategories;
			}
		}

		protected override ListBox CreateListBox(ITypeDescriptorContext context, IServiceProvider provider, object currentValue)
		{
			ListBox listBox = new ListBox();
			foreach (string stdCategory in StdCategories)
			{
				listBox.Items.Add(stdCategory);
			}
			listBox.Text = Convert.ToString(currentValue);
			listBox.Size = GetPreferSize(listBox);
			return listBox;
		}
	}
}
