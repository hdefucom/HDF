using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.WinForms.Design
{
	/// <summary>
	///       能自定义绘制项目的下拉列表样式的属性值编辑器
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(false)]
	public class CustomDrawValueListBoxEditor : UITypeEditor
	{
		private GClass9 myProvider = null;

		private ITypeDescriptorContext myContext = null;

		private IWindowsFormsEditorService myService = null;

		private static bool bolCheckExecuteDesignTimeEntryPoint = false;

		public GClass9 Provider
		{
			get
			{
				return myProvider;
			}
			set
			{
				myProvider = value;
			}
		}

		/// <summary>
		///       绘制图区域的大小
		///       </summary>
		public virtual Size BoxSize
		{
			get
			{
				if (myProvider == null)
				{
					return Size.Empty;
				}
				return myProvider.vmethod_2();
			}
		}

		protected ITypeDescriptorContext Context
		{
			get
			{
				return myContext;
			}
			set
			{
				myContext = value;
			}
		}

		protected IWindowsFormsEditorService Service => myService;

		/// <summary>
		///       绘制图形的接口
		///       </summary>
		/// <param name="g">图形绘制对象</param>
		/// <param name="Bounds">绘制区域的边界</param>
		/// <param name="Value">要绘制的数据</param>
		/// <param name="context">上下文信息</param>
		protected virtual void DrawValue(Graphics graphics_0, Rectangle Bounds, object Value, ITypeDescriptorContext context)
		{
			if (myProvider != null)
			{
				myProvider.method_6(context);
				myProvider.vmethod_4(graphics_0, Bounds, Value);
			}
		}

		/// <summary>
		///       填充列表框控件的项目列表
		///       </summary>
		/// <param name="ctl">列表框控件</param>
		protected virtual void FillListBox(ListBox listBox_0, ITypeDescriptorContext context)
		{
		}

		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return !BoxSize.IsEmpty;
		}

		public override void PaintValue(PaintValueEventArgs paintValueEventArgs_0)
		{
			DrawValue(paintValueEventArgs_0.Graphics, paintValueEventArgs_0.Bounds, paintValueEventArgs_0.Value, paintValueEventArgs_0.Context);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object Value)
		{
			myContext = context;
			myService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			using (ListBox listBox = new ListBox())
			{
				listBox.BorderStyle = BorderStyle.None;
				if (myProvider == null)
				{
					if (BoxSize.Height > 0)
					{
						listBox.DrawMode = DrawMode.OwnerDrawFixed;
						listBox.DrawItem += lst_DrawItem;
						listBox.ItemHeight = BoxSize.Height + 5;
						if (listBox.ItemHeight < 20)
						{
							listBox.ItemHeight = 20;
						}
					}
					FillListBox(listBox, context);
				}
				else
				{
					myProvider.method_6(context);
					myProvider.method_4(Value);
					myProvider.method_1(listBox);
				}
				if (listBox.Items.Count == 0)
				{
					return Value;
				}
				int num = 20;
				using (Graphics graphics = listBox.CreateGraphics())
				{
					foreach (object item in listBox.Items)
					{
						string itemText = listBox.GetItemText(item);
						if (itemText != null)
						{
							SizeF sizeF = graphics.MeasureString(itemText, listBox.Font, 10000, StringFormat.GenericDefault);
							if ((float)num < sizeF.Width)
							{
								num = (int)sizeF.Width;
							}
						}
					}
				}
				num = num + BoxSize.Width + 30;
				if (num < 150)
				{
					num = 150;
				}
				int num2 = listBox.Items.Count * listBox.ItemHeight + 5;
				double num3 = (double)Screen.PrimaryScreen.Bounds.Height * 0.4;
				if (num3 > 400.0)
				{
					num3 = 400.0;
				}
				if ((double)num2 > num3)
				{
					num2 = (int)Math.Ceiling(num3 / (double)listBox.ItemHeight) * listBox.ItemHeight + 5;
				}
				listBox.Size = new Size(num, num2);
				if (myProvider != null)
				{
					foreach (object item2 in listBox.Items)
					{
						object obj = myProvider.vmethod_5(item2);
						if (obj == Value)
						{
							listBox.SelectedItem = item2;
							break;
						}
						if (obj != null && obj.Equals(Value))
						{
							listBox.SelectedItem = item2;
							break;
						}
					}
				}
				else
				{
					listBox.SelectedItem = Value;
				}
				listBox.SelectedIndexChanged += lst_SelectedIndexChanged;
				int selectedIndex = listBox.SelectedIndex;
				myService.DropDownControl(listBox);
				if (selectedIndex == listBox.SelectedIndex)
				{
					return Value;
				}
				object obj2 = null;
				obj2 = ((Provider != null) ? Provider.vmethod_5(listBox.SelectedItem) : listBox.SelectedItem);
				OnValueChanged(context, provider, obj2);
				return obj2;
			}
		}

		protected virtual void OnValueChanged(ITypeDescriptorContext context, IServiceProvider provider, object NewValue)
		{
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			myService.CloseDropDown();
		}

		private void lst_DrawItem(object sender, DrawItemEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			Rectangle rectangle = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + (e.Bounds.Height - BoxSize.Height) / 2, BoxSize.Width, BoxSize.Height);
			e.DrawBackground();
			DrawValue(e.Graphics, rectangle, listBox.Items[e.Index], myContext);
			e.Graphics.DrawRectangle(Pens.Black, rectangle);
			string itemText = listBox.GetItemText(listBox.Items[e.Index]);
			if (itemText != null)
			{
				using (SolidBrush brush = new SolidBrush(e.ForeColor))
				{
					using (StringFormat stringFormat = new StringFormat())
					{
						stringFormat.Alignment = StringAlignment.Near;
						stringFormat.LineAlignment = StringAlignment.Center;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						e.Graphics.DrawString(itemText, e.Font, brush, new RectangleF(rectangle.Right + 3, e.Bounds.Top, e.Bounds.Width - rectangle.Right - 3, e.Bounds.Height), stringFormat);
					}
				}
			}
		}

		public void CheckExecuteDesignTimeEntryPoint()
		{
			CheckExecuteDesignTimeEntryPoint(Context);
		}

		public static void CheckExecuteDesignTimeEntryPoint(ITypeDescriptorContext context)
		{
			if (bolCheckExecuteDesignTimeEntryPoint || context == null)
			{
				return;
			}
			bolCheckExecuteDesignTimeEntryPoint = true;
			IDesignerHost designerHost = (IDesignerHost)context.GetService(typeof(IDesignerHost));
			if (designerHost == null)
			{
				return;
			}
			ITypeResolutionService typeResolutionService = (ITypeResolutionService)context.GetService(typeof(ITypeResolutionService));
			if (typeResolutionService != null)
			{
				Type type = typeResolutionService.GetType(designerHost.RootComponentClassName, throwOnError: false);
				if (type != null)
				{
					ExecuteDesignTimeEntryPoint(type.Assembly);
				}
			}
		}

		public static bool ExecuteDesignTimeEntryPoint(Assembly assembly_0)
		{
			int num = 7;
			MethodInfo entryPoint = assembly_0.EntryPoint;
			if (entryPoint != null)
			{
				MethodInfo method = entryPoint.DeclaringType.GetMethod("DesignTimeMain", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
				if (method != null)
				{
					method.Invoke(null, null);
					return true;
				}
			}
			else
			{
				Type type = assembly_0.GetType("DesignTimeMainContainer", throwOnError: false, ignoreCase: true);
				if (type != null)
				{
					MethodInfo method = type.GetMethod("DesignTimeMain", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
					if (method != null)
					{
						method.Invoke(null, null);
						return true;
					}
				}
			}
			return false;
		}
	}
}
