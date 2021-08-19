using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands.Design
{
	/// <summary>
	///       编辑器命令名称编辑器
	///       </summary>
	[ComVisible(false)]
	public class WriterCommandNameDlgEditor : UITypeEditor
	{
		private class Class49 : IComparer
		{
			public int Compare(object object_0, object object_1)
			{
				if (object_0 is GClass133)
				{
					return string.Compare(((GClass133)object_0).method_4(), ((GClass133)object_1).method_4(), ignoreCase: true);
				}
				if (object_0 is GClass104)
				{
					GClass104 gClass = (GClass104)object_0;
					GClass104 gClass2 = (GClass104)object_1;
					return string.Compare(gClass.Name, gClass2.Name, ignoreCase: true);
				}
				return 0;
			}
		}

		private static List<WriterCommandSimpleInfo> list_0 = null;

		/// <summary>
		///       编辑模式
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		/// <summary>
		///       编辑数值
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <param name="provider">
		/// </param>
		/// <param name="value">
		/// </param>
		/// <returns>
		/// </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			using (dlgCommandNameEditor dlgCommandNameEditor = new dlgCommandNameEditor())
			{
				dlgCommandNameEditor.InputCommandName = Convert.ToString(value);
				dlgCommandNameEditor.CommandInfos = smethod_0(context);
				if (dlgCommandNameEditor.ShowDialog() == DialogResult.OK)
				{
					method_0(context, provider, dlgCommandNameEditor.InputCommandName);
					return dlgCommandNameEditor.InputCommandName;
				}
			}
			return value;
		}

		public static WriterCommandSimpleInfo BrowseWriterCommandInfo(IWin32Window parent, string selectedCommandName)
		{
			using (dlgCommandNameEditor dlgCommandNameEditor = new dlgCommandNameEditor())
			{
				dlgCommandNameEditor.InputCommandName = selectedCommandName;
				dlgCommandNameEditor.CommandInfos = smethod_0(null);
				if (dlgCommandNameEditor.ShowDialog(parent) == DialogResult.OK)
				{
					return dlgCommandNameEditor.SelectedCommandInfo;
				}
			}
			return null;
		}

		private void method_0(ITypeDescriptorContext itypeDescriptorContext_0, IServiceProvider iserviceProvider_0, object object_0)
		{
			int num = 5;
			string string_ = Convert.ToString(object_0);
			WriterCommandSimpleInfo writerCommandSimpleInfo = method_1(itypeDescriptorContext_0, string_);
			if (writerCommandSimpleInfo == null)
			{
				return;
			}
			IComponentChangeService componentChangeService = (IComponentChangeService)itypeDescriptorContext_0.GetService(typeof(IComponentChangeService));
			if (componentChangeService == null)
			{
				return;
			}
			PropertyDescriptor propertyDescriptor;
			if (writerCommandSimpleInfo.Image != null)
			{
				propertyDescriptor = TypeDescriptor.GetProperties(itypeDescriptorContext_0.Instance)["Image"];
				if (propertyDescriptor != null)
				{
					object value = propertyDescriptor.GetValue(itypeDescriptorContext_0.Instance);
					componentChangeService.OnComponentChanging(itypeDescriptorContext_0.Instance, propertyDescriptor);
					propertyDescriptor.SetValue(itypeDescriptorContext_0.Instance, writerCommandSimpleInfo.Image);
					componentChangeService.OnComponentChanged(itypeDescriptorContext_0.Instance, propertyDescriptor, value, writerCommandSimpleInfo.Image);
				}
			}
			if (string.IsNullOrEmpty(writerCommandSimpleInfo.Description))
			{
				return;
			}
			propertyDescriptor = TypeDescriptor.GetProperties(itypeDescriptorContext_0.Instance)["Text"];
			if (propertyDescriptor != null)
			{
				string description = writerCommandSimpleInfo.Description;
				if (description != null && description.Trim().Length > 0)
				{
					object value = propertyDescriptor.GetValue(itypeDescriptorContext_0.Instance);
					componentChangeService.OnComponentChanging(itypeDescriptorContext_0.Instance, propertyDescriptor);
					propertyDescriptor.SetValue(itypeDescriptorContext_0.Instance, description);
					componentChangeService.OnComponentChanged(itypeDescriptorContext_0.Instance, propertyDescriptor, value, description);
				}
			}
		}

		private WriterCommandSimpleInfo method_1(ITypeDescriptorContext itypeDescriptorContext_0, string string_0)
		{
			foreach (WriterCommandSimpleInfo item in smethod_0(itypeDescriptorContext_0))
			{
				if (string.Compare(item.Name, string_0, ignoreCase: true) == 0)
				{
					return item;
				}
			}
			return null;
		}

		/// <summary>
		///       获得所有可用的编辑器命令信息列表
		///       </summary>
		/// <returns>
		/// </returns>
		public static List<WriterCommandSimpleInfo> GetAllCommandInfo()
		{
			return new List<WriterCommandSimpleInfo>(smethod_0(null));
		}

		internal static List<WriterCommandSimpleInfo> smethod_0(ITypeDescriptorContext itypeDescriptorContext_0)
		{
			if (list_0 != null)
			{
				return list_0;
			}
			List<Type> list = new List<Type>();
			try
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			if (itypeDescriptorContext_0 != null)
			{
				ITypeDiscoveryService typeDiscoveryService = (ITypeDiscoveryService)itypeDescriptorContext_0.GetService(typeof(ITypeDiscoveryService));
				if (typeDiscoveryService != null)
				{
					ICollection types = typeDiscoveryService.GetTypes(typeof(WriterCommand), excludeGlobalTypes: false);
					if (types != null)
					{
						foreach (Type item2 in types)
						{
							if (!list.Contains(item2))
							{
								list.Add(item2);
							}
						}
					}
					types = typeDiscoveryService.GetTypes(typeof(WriterCommandModule), excludeGlobalTypes: false);
					if (types != null)
					{
						foreach (Type item3 in types)
						{
							if (!list.Contains(item3))
							{
								list.Add(item3);
							}
						}
					}
				}
			}
			else
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					try
					{
						Type[] types2 = assembly.GetTypes();
						foreach (Type item in types2)
						{
							if (typeof(WriterCommandModule).IsAssignableFrom(item) && !list.Contains(item))
							{
								list.Add(item);
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			list_0 = smethod_1(list.ToArray());
			return list_0;
		}

		internal static List<WriterCommandSimpleInfo> smethod_1(Type[] type_0)
		{
			List<WriterCommandSimpleInfo> list = new List<WriterCommandSimpleInfo>();
			foreach (Type type in type_0)
			{
				if (type.IsSubclassOf(typeof(WriterCommand)) && !type.Equals(typeof(WriterCommandDelegate)))
				{
					GClass133 gClass = GClass133.smethod_1(type, bool_1: false);
					if (gClass != null)
					{
						list.Add(new WriterCommandSimpleInfo(gClass));
					}
				}
				else if (type.IsSubclassOf(typeof(WriterCommandModule)))
				{
					GClass104 gClass2 = GClass104.smethod_2(type, bool_0: false);
					if (gClass2 != null)
					{
						foreach (GClass133 item in gClass2.method_8())
						{
							if (!item.method_2())
							{
								WriterCommandSimpleInfo writerCommandSimpleInfo = new WriterCommandSimpleInfo(item);
								writerCommandSimpleInfo.ModuleName = gClass2.Name;
								list.Add(writerCommandSimpleInfo);
							}
						}
					}
				}
			}
			list.Sort();
			return list;
		}

		/// <summary>
		///       支持属性
		///       </summary>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		///       自定义绘制数据
		///       </summary>
		/// <param name="e">
		/// </param>
		public override void PaintValue(PaintValueEventArgs paintValueEventArgs_0)
		{
			WriterCommandSimpleInfo writerCommandSimpleInfo = method_1(paintValueEventArgs_0.Context, Convert.ToString(paintValueEventArgs_0.Value));
			if (writerCommandSimpleInfo != null && writerCommandSimpleInfo.Image != null)
			{
				paintValueEventArgs_0.Graphics.DrawImage(writerCommandSimpleInfo.Image, paintValueEventArgs_0.Bounds.Left, paintValueEventArgs_0.Bounds.Top);
			}
			base.PaintValue(paintValueEventArgs_0);
		}
	}
}
