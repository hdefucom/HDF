using DCSoft.Design;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       专为设计器而开发的文档内容控制器
	///        </summary>
	[ComVisible(false)]
	public class DocumentControlerExt : DocumentControler
	{
		private object method_28(IDataObject idataObject_0)
		{
			int num = 1;
			string[] formats = idataObject_0.GetFormats();
			int num2 = 0;
			object data;
			while (true)
			{
				if (num2 < formats.Length)
				{
					string text = formats[num2];
					if (text.IndexOf("DataSourceDescriptor") >= 0)
					{
						data = idataObject_0.GetData(text);
						if (data is DataSourceDescriptor)
						{
							return data;
						}
					}
					if (text.IndexOf(typeof(ComponentTypeInfo).Name) >= 0)
					{
						data = idataObject_0.GetData(text);
						if (data is ComponentTypeInfo)
						{
							break;
						}
					}
					num2++;
					continue;
				}
				return null;
			}
			return data;
		}

		public override void vmethod_2(CanInsertObjectEventArgs canInsertObjectEventArgs_0)
		{
			base.vmethod_2(canInsertObjectEventArgs_0);
			if (!canInsertObjectEventArgs_0.Result)
			{
				if (string.IsNullOrEmpty(canInsertObjectEventArgs_0.SpecifyFormat) && method_28(canInsertObjectEventArgs_0.DataObject) != null)
				{
					canInsertObjectEventArgs_0.Result = true;
				}
				else
				{
					canInsertObjectEventArgs_0.Result = false;
				}
			}
		}

		public override void vmethod_4(InsertObjectEventArgs insertObjectEventArgs_0)
		{
			int num = 18;
			base.vmethod_4(insertObjectEventArgs_0);
			if (!insertObjectEventArgs_0.Result)
			{
				object obj = method_28(insertObjectEventArgs_0.DataObject);
				if (obj is DataSourceDescriptor)
				{
					DataSourceDescriptor dataSourceDescriptor = (DataSourceDescriptor)obj;
					XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.BackgroundText = dataSourceDescriptor.BackgroundText;
					xTextInputFieldElement.Name = dataSourceDescriptor.Name;
					xTextInputFieldElement.AcceptChildElementTypes2 = ElementType.Text;
					xTextInputFieldElement.ToolTip = dataSourceDescriptor.Description;
					xTextInputFieldElement.ContentReadonly = ((!dataSourceDescriptor.Readonly) ? ContentReadonlyState.Inherit : ContentReadonlyState.True);
					xTextInputFieldElement.ValueBinding = dataSourceDescriptor.ValueBinding;
					xTextInputFieldElement.DisplayFormat = dataSourceDescriptor.DisplayFormat;
					xTextInputFieldElement.FieldSettings = new InputFieldSettings();
					xTextInputFieldElement.FieldSettings.EditStyle = dataSourceDescriptor.EditStyle;
					xTextInputFieldElement.FieldSettings.ListSource = dataSourceDescriptor.ListSource;
					xTextInputFieldElement.ValidateStyle = dataSourceDescriptor.ValidateStyle;
					xTextInputFieldElement.UserEditable = dataSourceDescriptor.UserEditable;
					xTextInputFieldElement.Attributes.SetValue("TableName", "records");
					base.EditorControl.ExecuteCommand("InsertInputField", showUI: false, xTextInputFieldElement);
					insertObjectEventArgs_0.Result = true;
				}
				else if (obj is ComponentTypeInfo)
				{
					ComponentTypeInfo componentTypeInfo = (ComponentTypeInfo)obj;
					object obj2 = base.EditorControl.ExecuteCommand("InsertControlHost", showUI: false, componentTypeInfo.FullName);
					insertObjectEventArgs_0.Result = (obj2 != null);
				}
				else
				{
					insertObjectEventArgs_0.Result = false;
				}
			}
		}
	}
}
