#define DEBUG
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       在文档编辑器中承载控件的元素
	///       </summary>
	/// <remarks>
	///       注意，当承载OCX控件时，会自动设置编辑器控件的Font.Unit属性值为GraphicsUnit.Point。
	///       </remarks>
	[Serializable]
	
	
	[DebuggerDisplay("Host:{TypeFullName}")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890054")]
	[ComClass("00012345-6789-ABCD-EF01-234567890054", "280EF940-4858-4348-800F-C4FEF1D2BD00")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IXTextControlHostElement))]
	[XmlType("XTextControlHost")]
	public class XTextControlHostElement : XTextObjectElement, IXTextControlHostElement
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[ToolboxItem(false)]
		[ComVisible(false)]
		
		public class GClass1 : AxHost
		{
			private XTextControlHostElement xtextControlHostElement_0 = null;

			private object object_0 = null;

			public GClass1(string string_0, XTextControlHostElement xtextControlHostElement_1)
				: base(string_0)
			{
				xtextControlHostElement_0 = xtextControlHostElement_1;
			}

			protected override void CreateHandle()
			{
				int num = 5;
				Debug.WriteLine("准备创建DCAxHost句柄,Font=" + base.Font.ToString());
				try
				{
					base.CreateHandle();
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.ToString());
					throw ex;
				}
				string text = "创建DCAxHost句柄:" + base.Handle;
				Debug.WriteLine(text);
				if (xtextControlHostElement_0 != null && xtextControlHostElement_0.OwnerDocument.Options.BehaviorOptions.SpecifyDebugMode)
				{
					MessageBox.Show(text);
				}
			}

			public object method_0()
			{
				return object_0;
			}

			protected override void AttachInterfaces()
			{
				base.AttachInterfaces();
				object_0 = GetOcx();
			}
		}

		internal const string string_9 = "00012345-6789-ABCD-EF01-234567890054";

		internal const string string_10 = "280EF940-4858-4348-800F-C4FEF1D2BD00";

		private bool bool_9 = false;

		private static int int_8 = 0;

		[NonSerialized]
		private int int_9 = int_8++;

		private HostedControlType hostedControlType_0 = HostedControlType.AutoDetect;

		private string string_11 = null;

		private string string_12 = null;

		private ObjectHostMode objectHostMode_0 = ObjectHostMode.Dynamic;

		private bool bool_10 = true;

		[NonSerialized]
		private XMLViewStateBag xmlviewStateBag_0 = null;

		private ObjectParameterList objectParameterList_0 = null;

		private bool bool_11 = false;

		[NonSerialized]
		private Image image_0 = null;

		private byte[] byte_0 = null;

		[NonSerialized]
		private string string_13 = null;

		private string string_14 = null;

		[NonSerialized]
		private object object_1 = null;

		[NonSerialized]
		private object object_2 = null;

		private static object object_3 = new object();

		private string string_15 = null;

		
		public override string DomDisplayName
		{
			get
			{
				int num = 15;
				if (string.IsNullOrEmpty(TypeFullName))
				{
					return "Host:" + base.ID + " " + TypeFullName;
				}
				return "Host:" + base.ID;
			}
		}

		/// <summary>
		///       延迟加载控件,用户点击才加载控件
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(false)]
		[XmlElement]
		public virtual bool DelayLoadControl
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。内部管理使用的元素ID
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		
		public int ManageID
		{
			get
			{
				return int_9;
			}
			set
			{
				int_9 = value;
			}
		}

		/// <summary>
		///       承载的控件的类型
		///       </summary>
		[DefaultValue(HostedControlType.AutoDetect)]
		
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public virtual HostedControlType ControlType
		{
			get
			{
				return hostedControlType_0;
			}
			set
			{
				hostedControlType_0 = (HostedControlType)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       运行时使用的承载的控件类型
		///       </summary>
		
		[Browsable(false)]
		public virtual HostedControlType RuntimeControlType
		{
			get
			{
				int num = 13;
				if (!XTextDocument.smethod_13(GEnum6.const_215))
				{
					return HostedControlType.InvalidateType;
				}
				HostedControlType hostedControlType = HostedControlType.InvalidateType;
				HostedControlType controlType = ControlType;
				if (controlType == HostedControlType.AutoDetect)
				{
					if (SpecifyHostedInstance != null)
					{
						hostedControlType = (GClass129.smethod_4(SpecifyHostedInstance) ? HostedControlType.WPF : ((SpecifyHostedInstance is GControl7) ? HostedControlType.NativeWinControl : ((SpecifyHostedInstance is Control) ? HostedControlType.Control : (SpecifyHostedInstance.GetType().IsCOMObject ? HostedControlType.OCX : ((!typeof(IDocumentImage).IsInstanceOfType(SpecifyHostedInstance)) ? HostedControlType.Control : HostedControlType.DocumentImage)))));
					}
					else if (string.IsNullOrEmpty(TypeFullName))
					{
						hostedControlType = HostedControlType.InvalidateType;
					}
					else
					{
						try
						{
							if (TypeFullName.StartsWith("OCX:", StringComparison.CurrentCultureIgnoreCase))
							{
								hostedControlType = HostedControlType.OCX;
							}
							else if (TypeFullName.IndexOf('-') > 0)
							{
								Guid a = new Guid(TypeFullName);
								if (a != Guid.Empty)
								{
									controlType = HostedControlType.OCX;
									hostedControlType = HostedControlType.OCX;
								}
							}
						}
						catch (Exception)
						{
						}
					}
					if (hostedControlType == HostedControlType.InvalidateType)
					{
						Type controlType2 = ControlHelper.GetControlType(TypeFullName, null);
						if (controlType2 == null)
						{
							hostedControlType = HostedControlType.InvalidateType;
						}
						else if (typeof(Control).IsAssignableFrom(controlType2))
						{
							hostedControlType = HostedControlType.Control;
						}
						else if (typeof(IDocumentImage).IsAssignableFrom(controlType2))
						{
							hostedControlType = HostedControlType.DocumentImage;
						}
						else if (GClass129.smethod_3(controlType2))
						{
							hostedControlType = HostedControlType.WPF;
						}
					}
				}
				else
				{
					hostedControlType = controlType;
				}
				switch (hostedControlType)
				{
				case HostedControlType.WPF:
					if (!XTextDocument.smethod_13(GEnum6.const_216))
					{
						hostedControlType = HostedControlType.InvalidateType;
					}
					break;
				case HostedControlType.OCX:
					if (!XTextDocument.smethod_13(GEnum6.const_217))
					{
						hostedControlType = HostedControlType.InvalidateType;
					}
					break;
				case HostedControlType.NativeWinControl:
					if (!XTextDocument.smethod_13(GEnum6.const_218))
					{
						hostedControlType = HostedControlType.InvalidateType;
					}
					break;
				}
				return hostedControlType;
			}
		}

		/// <summary>
		///       控件类型全名
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ContentElementLayout)]
		[DefaultValue(null)]
		
		[HtmlAttribute]
		public virtual string TypeFullName
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		private GInterface20 ControlHostManger
		{
			get
			{
				if (WriterControl != null)
				{
					return WriterControl.ControlHostManger;
				}
				return null;
			}
		}

		/// <summary>
		///       承载的对象类型
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public Type HostedType
		{
			get
			{
				return ControlHelper.GetControlType(string_11, null);
			}
			set
			{
				string_11 = ControlHelper.GetControlFullTypeName(value);
			}
		}

		/// <summary>
		///       控件的数值属性名称
		///       </summary>
		
		[DefaultValue(null)]
		public string ValuePropertyName
		{
			get
			{
				return string_12;
			}
			set
			{
				string_12 = value;
			}
		}

		/// <summary>
		///       控件承载模式
		///       </summary>
		[DefaultValue(ObjectHostMode.Dynamic)]
		[HtmlAttribute]
		
		public virtual ObjectHostMode HostMode
		{
			get
			{
				return objectHostMode_0;
			}
			set
			{
				objectHostMode_0 = value;
			}
		}

		/// <summary>
		///       是否启用视图状态
		///       </summary>
		[DefaultValue(true)]
		[HtmlAttribute]
		
		public bool EnableViewState
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		/// <summary>
		///       视图状态数据包对象
		///       </summary>
		[XmlArrayItem("Item", typeof(XMLViewStateBagItem))]
		[DefaultValue(null)]
		[Browsable(false)]
		
		public XMLViewStateBag ViewState
		{
			get
			{
				return xmlviewStateBag_0;
			}
			set
			{
				xmlviewStateBag_0 = value;
			}
		}

		/// <summary>
		///       能否让用户修改元素的大小
		///       </summary>
		[DefaultValue(ResizeableType.WidthAndHeight)]
		
		[HtmlAttribute]
		public virtual ResizeableType AllowUserResize
		{
			get
			{
				return base.Resizeable;
			}
			set
			{
				base.Resizeable = value;
			}
		}

		/// <summary>
		///       控件参数值
		///       </summary>
		
		[XmlArrayItem("Parameter", typeof(ObjectParameter))]
		[DefaultValue(null)]
		public virtual ObjectParameterList Parameters
		{
			get
			{
				return objectParameterList_0;
			}
			set
			{
				objectParameterList_0 = value;
			}
		}

		/// <summary>
		///       保存文档时是否保存预览图片
		///       </summary>
		[DefaultValue(false)]
		[HtmlAttribute]
		public virtual bool SavePreviewImage
		{
			get
			{
				return bool_11;
			}
			set
			{
				bool_11 = value;
			}
		}

		/// <summary>
		///       预览使用的图片
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public new Image PreviewImage
		{
			get
			{
				return image_0;
			}
			set
			{
				if (image_0 != value)
				{
					image_0 = value;
				}
			}
		}

		/// <summary>
		///       预览图片数据
		///       </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public byte[] PreviewImageData
		{
			get
			{
				if (SavePreviewImage)
				{
					if (byte_0 == null && PreviewImage != null)
					{
						MemoryStream memoryStream = new MemoryStream();
						PreviewImage.Save(memoryStream, ImageFormat.Png);
						byte_0 = memoryStream.ToArray();
						memoryStream.Close();
					}
					return byte_0;
				}
				return null;
			}
			set
			{
				byte_0 = value;
			}
		}

		/// <summary>
		///       错误信息
		///       </summary>
		[Browsable(true)]
		[XmlIgnore]
		
		[ReadOnly(true)]
		public string ErrorMessage
		{
			get
			{
				return string_13;
			}
			set
			{
				if (string_13 != value)
				{
					string_13 = value;
				}
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		
		[XmlElement]
		[Browsable(true)]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       承载对象的选项属性名
		///       </summary>
		[DefaultValue(null)]
		
		public string OptionsPropertyName
		{
			get
			{
				return string_14;
			}
			set
			{
				string_14 = value;
			}
		}

		/// <summary>
		///       承载的对象实例的选项信息对象
		///       </summary>
		
		[XmlIgnore]
		[Browsable(true)]
		public object InstanceOptions
		{
			get
			{
				return ValueTypeHelper.GetPropertyValue(HostedInstance, OptionsPropertyName, throwException: false);
			}
			set
			{
				ValueTypeHelper.SetPropertyValue(HostedInstance, OptionsPropertyName, value, throwException: false);
			}
		}

		/// <summary>
		///       用户指定的承载的对象
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public object SpecifyHostedInstance
		{
			get
			{
				return object_1;
			}
			set
			{
				object_1 = value;
			}
		}

		/// <summary>
		///       元素承载的对象
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public object HostedInstance
		{
			get
			{
				return vmethod_28();
			}
			set
			{
				object_2 = value;
			}
		}

		/// <summary>
		///       演示加载控件的提示文本
		///       </summary>
		protected virtual string MessageToDelayLoadControl => WriterStringsCore.ClickToLoadControl;

		[HtmlAttribute]
		
		[DefaultValue(null)]
		[Browsable(true)]
		[XmlElement]
		public override string Text
		{
			get
			{
				return string_15;
			}
			set
			{
				string_15 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextControlHostElement()
		{
			PrintVisibility = ElementVisibility.None;
		}

		
		public static bool smethod_0(string string_16)
		{
			int num = 13;
			if (string.IsNullOrEmpty(string_16))
			{
				return false;
			}
			if (string_16.StartsWith("OCX:", StringComparison.CurrentCultureIgnoreCase))
			{
				return true;
			}
			if (string_16.StartsWith("{") && string_16.EndsWith("}"))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       设置承载的原生态的控件。
		///       </summary>
		/// <param name="handle">控件句柄</param>
		[ComVisible(true)]
		public bool SetNativeHostedControlHandle(IntPtr handle)
		{
			GClass244 gClass = new GClass244(handle);
			if (gClass.method_37())
			{
				int int_ = gClass.method_15();
				int_ = MathCommon.smethod_25(int_, 0, bool_0: false);
				int_ = MathCommon.smethod_25(int_, 13565952, bool_0: false);
				gClass.method_16(int_);
				ControlType = HostedControlType.NativeWinControl;
				if (SpecifyHostedInstance is GControl7)
				{
					GControl7 gControl = (GControl7)SpecifyHostedInstance;
					gControl.method_3(handle);
				}
				else
				{
					GControl7 gControl2 = new GControl7(handle);
					gControl2.method_1(bool_1: true);
					SpecifyHostedInstance = gControl2;
				}
				if (ControlHostManger != null)
				{
					ControlHostManger.ReloadControl(this, checkDelayLoad: false, addAfterHostedControlLoaded: false);
				}
				return true;
			}
			return false;
		}

		
		public void method_16(string string_16, Exception exception_0)
		{
			ErrorMessage = string_16 + Environment.NewLine + exception_0.ToString();
		}

		/// <summary>
		///       刷新文档元素
		///       </summary>
		public override void EditorRefreshView()
		{
			base.EditorRefreshView();
			vmethod_29();
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">
		/// </param>
		
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.MouseClick && ControlHostManger != null && DelayLoadControl && ControlHostManger.GetControl(this) == null)
			{
				ControlHostManger.ReloadControl(this, checkDelayLoad: false, addAfterHostedControlLoaded: true);
				ControlHostManger.imethod_1();
			}
			base.HandleDocumentEvent(args);
		}

		
		public virtual Image vmethod_26()
		{
			ErrorMessage = null;
			Image image = null;
			if (RuntimeControlType == HostedControlType.Control || RuntimeControlType == HostedControlType.OCX)
			{
				Control control = null;
				if (ControlHostManger != null)
				{
					control = ControlHostManger.GetControl(this);
				}
				bool flag = false;
				try
				{
					if (control == null && !DelayLoadControl)
					{
						control = (Control)vmethod_32();
						if (control != null)
						{
							if (SpecifyHostedInstance == null)
							{
								vmethod_30(control);
								flag = true;
							}
							else
							{
								flag = false;
							}
							SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(ClientWidth, ClientHeight), OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
							control.Size = new Size((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));
							control.CreateControl();
						}
					}
					if (control != null)
					{
						if (control is IDocumentHostedObject)
						{
							DocumentHostElementEventArgs documentHostElementEventArgs = new DocumentHostElementEventArgs();
							documentHostElementEventArgs.Document = OwnerDocument;
							documentHostElementEventArgs.Element = this;
							documentHostElementEventArgs.ViewState = ViewState;
							image = ((IDocumentHostedObject)control).CreatePreviewImage(documentHostElementEventArgs);
						}
						if (image == null)
						{
							Bitmap bitmap = new Bitmap(control.Width + 1, control.Height + 1);
							if (!(control is GClass1))
							{
								control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));
							}
							image = bitmap;
						}
					}
				}
				catch (Exception ex)
				{
					method_16(ex.Message, ex);
				}
				finally
				{
					if (flag)
					{
						control.Dispose();
					}
				}
			}
			else if (RuntimeControlType == HostedControlType.WPF)
			{
				try
				{
					SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(ClientWidth, ClientHeight), OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
					image = GClass129.smethod_9(vmethod_28(), (int)sizeF.Width, (int)sizeF.Height);
				}
				catch (Exception ex)
				{
					method_16(ex.Message, ex);
				}
			}
			else if (RuntimeControlType == HostedControlType.DocumentImage)
			{
				try
				{
					IDocumentImage documentImage = vmethod_28() as IDocumentImage;
					if (documentImage != null)
					{
						SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(ClientWidth, ClientHeight), OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
						image = new Bitmap((int)sizeF.Width, (int)sizeF.Height);
						using (Graphics graphics = Graphics.FromImage(image))
						{
							graphics.PageUnit = OwnerDocument.DocumentGraphicsUnit;
							graphics.Clear(RuntimeStyle.BackgroundColor);
							DocumentPaintEventArgs documentPaintEventArgs = new DocumentPaintEventArgs(new DCGraphics(graphics), new Rectangle(0, 0, (int)ClientWidth, (int)ClientHeight));
							documentPaintEventArgs.ViewBounds = new RectangleF(1f, 1f, ClientWidth - 1f, ClientHeight - 1f);
							documentPaintEventArgs.Style = RuntimeStyle;
							documentPaintEventArgs.RenderMode = DocumentRenderMode.Bitmap;
							documentPaintEventArgs.Render = OwnerDocument.Render;
							documentPaintEventArgs.DocumentContentElement = base.DocumentContentElement;
							documentPaintEventArgs.Element = this;
							documentPaintEventArgs.ForCreateImage = true;
							documentImage.Draw(documentPaintEventArgs);
						}
					}
				}
				catch (Exception ex)
				{
					method_16(ex.Message, ex);
				}
			}
			if (image == null && PreviewImageData != null && PreviewImageData.Length > 0)
			{
				MemoryStream memoryStream = new MemoryStream(PreviewImageData);
				try
				{
					image = Image.FromStream(memoryStream);
				}
				catch (Exception ex)
				{
					method_16(ex.Message, ex);
				}
				memoryStream.Close();
			}
			return image;
		}

		private Bitmap method_17(string string_16)
		{
			SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(ClientWidth, ClientHeight), OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
			return WriterUtils.smethod_42((int)sizeF.Width, (int)sizeF.Height, string_16, XFontValue.font_0, Color.Black, Color.White);
		}

		
		public virtual void vmethod_27()
		{
			if (ControlHostManger != null)
			{
				ControlHostManger.RemoveControl(this);
			}
			if (object_2 != null)
			{
				if (object_2 is IDisposable)
				{
					((IDisposable)object_2).Dispose();
				}
				object_2 = null;
			}
		}

		
		public SizeF method_18(object object_4)
		{
			SizeF result = SizeF.Empty;
			if (object_4 is Control)
			{
				Control control = (Control)object_4;
				if (!control.IsHandleCreated)
				{
					control.CreateControl();
				}
				Size size = control.Size;
				result = GraphicsUnitConvert.Convert(new SizeF(size.Width, size.Height), GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
			}
			else if (object_4 is IDocumentImage)
			{
				IDocumentImage documentImage = (IDocumentImage)object_4;
				using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
				{
					DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(dcgraphics_);
					documentPaintEventArgs.Element = this;
					result = documentImage.GetPreferredSize(documentPaintEventArgs);
				}
			}
			else if (GClass129.smethod_4(object_4))
			{
				Size size = GClass129.smethod_8(object_4);
				if (!size.IsEmpty)
				{
					result = GraphicsUnitConvert.Convert(new SizeF(size.Width, size.Height), GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
				}
			}
			if (result.Width < 150f)
			{
				result.Width = 150f;
			}
			if (result.Height < 150f)
			{
				result.Height = 150f;
			}
			return result;
		}

		
		public virtual object vmethod_28()
		{
			if (RuntimeControlType == HostedControlType.Control)
			{
				if (ControlHostManger != null)
				{
					return ControlHostManger.GetControl(this);
				}
			}
			else
			{
				if (RuntimeControlType == HostedControlType.WPF)
				{
					if (ControlHostManger != null)
					{
						Control control = ControlHostManger.GetControl(this);
						if (control != null)
						{
							return GClass129.smethod_7(control);
						}
					}
					return object_2;
				}
				if (RuntimeControlType == HostedControlType.DocumentImage)
				{
					if (object_1 != null)
					{
						return object_1 as IDocumentImage;
					}
					if (object_2 == object_3)
					{
						try
						{
							object_2 = vmethod_32();
							vmethod_30(object_2);
						}
						catch (Exception ex)
						{
							object_2 = null;
							method_16(ex.Message, ex);
						}
					}
					return object_2 as IDocumentImage;
				}
			}
			return null;
		}

		
		public virtual object vmethod_29()
		{
			HostedControlType runtimeControlType = RuntimeControlType;
			if (runtimeControlType == HostedControlType.Control || runtimeControlType == HostedControlType.WPF || runtimeControlType == HostedControlType.OCX)
			{
				if (ControlHostManger != null)
				{
					object result = ControlHostManger.ReloadControl(this, checkDelayLoad: true, addAfterHostedControlLoaded: true);
					ControlHostManger.imethod_1();
					return result;
				}
			}
			else
			{
				switch (runtimeControlType)
				{
				case HostedControlType.DocumentImage:
				{
					if (object_2 != null && object_2 != object_1)
					{
						if (object_2 is IDisposable)
						{
							((IDisposable)object_2).Dispose();
						}
						object_2 = null;
					}
					Type controlType = ControlHelper.GetControlType(TypeFullName, typeof(IDocumentImage));
					if (controlType != null)
					{
						if (SpecifyHostedInstance == null)
						{
							object_2 = Activator.CreateInstance(controlType);
							if (object_2 != null)
							{
								vmethod_30(object_2);
							}
						}
						else
						{
							object_2 = SpecifyHostedInstance;
						}
					}
					return object_2;
				}
				case HostedControlType.InvalidateType:
					if (string.IsNullOrEmpty(TypeFullName))
					{
						ErrorMessage = "";
					}
					else
					{
						ErrorMessage = string.Format(WriterStringsCore.InvalidateType_Name, TypeFullName);
					}
					break;
				}
			}
			return null;
		}

		/// <summary>
		///       绘制对象
		///       </summary>
		/// <param name="args">参数</param>
		
		public override void Draw(DocumentPaintEventArgs args)
		{
			if (args.RenderMode == DocumentRenderMode.PDF)
			{
				base.Draw(args);
			}
			else
			{
				if (!OwnerDocument.Options.BehaviorOptions.DesignMode && RuntimeControlType == HostedControlType.DocumentImage)
				{
					IDocumentImage documentImage = (IDocumentImage)vmethod_28();
					if (documentImage != null && (documentImage.ImageFlags & DocumentImageFlags.CustomBackground) == DocumentImageFlags.CustomBackground)
					{
						method_20(args);
						method_19(args);
						return;
					}
				}
				base.Draw(args);
			}
			XTextDocument.smethod_10(this, args, GEnum6.const_215);
		}

		protected void method_19(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && documentPaintEventArgs_0.ActiveMode && base.ShowDragRect && base.Enabled)
			{
				GClass300 gClass = vmethod_24();
				gClass.method_9(new Rectangle((int)AbsLeft, (int)AbsTop, gClass.method_8().Width, gClass.method_8().Height));
				gClass.method_21(documentPaintEventArgs_0.Graphics);
			}
		}

		private bool method_20(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			IDocumentImage documentImage = (IDocumentImage)vmethod_28();
			if (documentImage != null)
			{
				DocumentPaintEventArgs documentPaintEventArgs = documentPaintEventArgs_0.Clone();
				RectangleF viewBounds = documentPaintEventArgs.ViewBounds;
				viewBounds.Offset(1f, 1f);
				viewBounds.Width -= 2f;
				viewBounds.Height -= 2f;
				documentPaintEventArgs.ViewBounds = viewBounds;
				RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
				documentPaintEventArgs.ClientViewBounds = new RectangleF(viewBounds.Left + runtimeStyle.PaddingLeft, viewBounds.Top + runtimeStyle.PaddingTop, viewBounds.Width - runtimeStyle.PaddingLeft - runtimeStyle.PaddingRight, viewBounds.Height - runtimeStyle.PaddingTop - runtimeStyle.PaddingBottom);
				documentPaintEventArgs.Bounds = viewBounds;
				documentImage.Draw(documentPaintEventArgs);
				return true;
			}
			return false;
		}

		/// <summary>
		///       绘制内容
		///       </summary>
		/// <param name="args">
		/// </param>
		
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			int num = 19;
			if (OwnerDocument.Options.BehaviorOptions.DesignMode)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("[" + WriterStringsCore.DocumentInDesignMode + "]");
				stringBuilder.AppendLine("ID:" + base.ID);
				stringBuilder.AppendLine("Name:" + base.Name);
				stringBuilder.AppendLine("Type:" + TypeFullName);
				stringBuilder.AppendLine("Mode:" + HostMode);
				if (Parameters != null)
				{
					foreach (ObjectParameter parameter in Parameters)
					{
						stringBuilder.AppendLine(parameter.Name + "=" + parameter.Value);
					}
				}
				string string_ = stringBuilder.ToString();
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					drawStringFormatExt.Alignment = StringAlignment.Near;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.Color = RuntimeStyle.Color;
					drawStringFormatExt.Font = RuntimeStyle.Font;
					drawStringFormatExt.SetBounds(args.ViewBounds);
					args.Graphics.method_2(string_, drawStringFormatExt);
				}
				OwnerDocument.method_114(this, args, GEnum6.const_215);
				return;
			}
			if (!string.IsNullOrEmpty(ErrorMessage))
			{
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					drawStringFormatExt.Alignment = StringAlignment.Near;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.Color = Color.Red;
					drawStringFormatExt.Font = new XFontValue();
					drawStringFormatExt.Font.Bold = true;
					drawStringFormatExt.SetBounds(args.ViewBounds);
					args.Graphics.method_2(ErrorMessage, drawStringFormatExt);
				}
				return;
			}
			HostedControlType runtimeControlType = RuntimeControlType;
			if (args.RenderMode == DocumentRenderMode.PDF)
			{
				if (PreviewImage == null)
				{
					PreviewImage = vmethod_26();
				}
				if (PreviewImage != null)
				{
					RectangleF clientViewBounds = args.ClientViewBounds;
					if (clientViewBounds.Width > 1f && clientViewBounds.Height > 1f)
					{
						Image previewImage = PreviewImage;
						PreviewImage = null;
						args.Graphics.DrawImage(previewImage, clientViewBounds);
					}
					else
					{
						ErrorMessage = "错误的大小:" + clientViewBounds.Width + "," + clientViewBounds.Height;
					}
					if (!string.IsNullOrEmpty(ErrorMessage))
					{
						method_21(ErrorMessage, args);
					}
				}
				return;
			}
			if (args.RenderMode == DocumentRenderMode.Paint)
			{
				if (runtimeControlType == HostedControlType.Control || runtimeControlType == HostedControlType.WPF)
				{
					if (OwnerDocument != null && OwnerDocument.EditorControl != null && vmethod_28() != null)
					{
						return;
					}
				}
				else if (runtimeControlType == HostedControlType.DocumentImage && method_20(args))
				{
					return;
				}
				if (!string.IsNullOrEmpty(ErrorMessage))
				{
					method_21(ErrorMessage, args);
				}
				else if (DelayLoadControl && ControlHostManger != null && ControlHostManger.GetControl(this) == null)
				{
					using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
					{
						drawStringFormatExt.Alignment = StringAlignment.Center;
						drawStringFormatExt.LineAlignment = StringAlignment.Center;
						drawStringFormatExt.Color = Color.Black;
						drawStringFormatExt.Font = new XFontValue();
						drawStringFormatExt.SetBounds(args.ClientViewBounds);
						args.Graphics.method_2(MessageToDelayLoadControl, drawStringFormatExt);
					}
				}
			}
			else if ((args.RenderMode == DocumentRenderMode.Print || args.RenderMode == DocumentRenderMode.ReadPaint) && runtimeControlType == HostedControlType.DocumentImage)
			{
				IDocumentImage documentImage = (IDocumentImage)vmethod_28();
				if (documentImage != null && method_20(args))
				{
					return;
				}
			}
			if (PreviewImage == null)
			{
				PreviewImage = vmethod_26();
			}
			if (PreviewImage != null)
			{
				RectangleF clientViewBounds = args.ClientViewBounds;
				if (clientViewBounds.Width > 1f && clientViewBounds.Height > 1f)
				{
					try
					{
						args.Graphics.DrawImageUnscaledAndClipped(PreviewImage, new Rectangle((int)clientViewBounds.X, (int)clientViewBounds.Y, (int)clientViewBounds.Width, (int)clientViewBounds.Height));
					}
					catch (Exception ex)
					{
						method_21(ex.Message, args);
					}
				}
				else
				{
					ErrorMessage = "错误的大小:" + clientViewBounds.Width + "," + clientViewBounds.Height;
				}
				if (!string.IsNullOrEmpty(ErrorMessage))
				{
					method_21(ErrorMessage, args);
				}
			}
			base.DrawContent(args);
		}

		private void method_21(string string_16, DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			if (!string.IsNullOrEmpty(string_16))
			{
				using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.Font = new XFontValue();
					if (OwnerDocument.EditorControl != null)
					{
						drawStringFormatExt.Font = new XFontValue(OwnerDocument.EditorControl.Font);
					}
					drawStringFormatExt.Color = Color.Red;
					drawStringFormatExt.SetBounds(documentPaintEventArgs_0.ViewBounds);
					documentPaintEventArgs_0.Graphics.method_2(string_16, drawStringFormatExt);
				}
			}
		}

		
		public override void vmethod_21(string string_16)
		{
			int num = 3;
			if (EnableViewState && OwnerDocument != null && OwnerDocument.EditorControl != null)
			{
				object obj = vmethod_28();
				if (obj != null)
				{
					vmethod_31(obj, bool_12: false);
				}
			}
			if (string.Compare(string_16, "xml", ignoreCase: true) == 0 && SavePreviewImage)
			{
				if (PreviewImage == null)
				{
					Image image = vmethod_26();
					if (image != null)
					{
						using (image)
						{
							MemoryStream memoryStream = new MemoryStream();
							image.Save(memoryStream, ImageFormat.Png);
							PreviewImageData = memoryStream.ToArray();
						}
					}
				}
				else
				{
					MemoryStream memoryStream = new MemoryStream();
					PreviewImage.Save(memoryStream, ImageFormat.Png);
					PreviewImageData = memoryStream.ToArray();
				}
			}
			if (!EnableViewState || xmlviewStateBag_0 == null)
			{
			}
			base.vmethod_21(string_16);
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public override void Dispose()
		{
			base.Dispose();
			method_22();
			if (xmlviewStateBag_0 != null)
			{
				xmlviewStateBag_0.Dispose();
				xmlviewStateBag_0 = null;
			}
		}

		
		public void method_22()
		{
			if (PreviewImage != null)
			{
				PreviewImage.Dispose();
				PreviewImage = null;
			}
		}

		
		public virtual void vmethod_30(object object_4)
		{
			try
			{
				try
				{
					if (object_4 != null && Parameters != null)
					{
						foreach (ObjectParameter parameter in Parameters)
						{
							try
							{
								ControlHelper.SetControlValue(object_4, parameter.Name, parameter.Value);
							}
							catch (Exception ex)
							{
								Debug.WriteLine(ex.Message);
							}
						}
					}
					if (!string.IsNullOrEmpty(ValuePropertyName))
					{
						ControlHelper.SetControlValue(object_4, ValuePropertyName, Text);
					}
					if (object_4 is IDocumentHostedObject)
					{
						IDocumentHostedObject documentHostedObject = (IDocumentHostedObject)object_4;
						DocumentHostElementEventArgs documentHostElementEventArgs = new DocumentHostElementEventArgs();
						documentHostElementEventArgs.Document = OwnerDocument;
						documentHostElementEventArgs.Element = this;
						documentHostElementEventArgs.WriterControl = OwnerDocument.EditorControl;
						if (EnableViewState)
						{
							documentHostElementEventArgs.ViewState = ViewState;
						}
						if (documentHostElementEventArgs.ViewState == null)
						{
							documentHostElementEventArgs.ViewState = new XMLViewStateBag();
						}
						documentHostedObject.LoadViewState(documentHostElementEventArgs);
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					method_16(ex.Message, ex);
				}
				if (object_4 is Control)
				{
				}
			}
			catch (Exception ex)
			{
				method_16(ex.Message, ex);
				Debug.WriteLine(ex.Message);
			}
		}

		public virtual void vmethod_31(object object_4, bool bool_12)
		{
			if (object_4 is IDocumentHostedObject)
			{
				IDocumentHostedObject documentHostedObject = (IDocumentHostedObject)object_4;
				DocumentHostElementEventArgs documentHostElementEventArgs = new DocumentHostElementEventArgs();
				documentHostElementEventArgs.Document = OwnerDocument;
				documentHostElementEventArgs.Element = this;
				documentHostElementEventArgs.WriterControl = OwnerDocument.EditorControl;
				if (EnableViewState)
				{
					if (ViewState == null)
					{
						ViewState = new XMLViewStateBag();
					}
					documentHostElementEventArgs.ViewState = ViewState;
				}
				if (documentHostElementEventArgs.ViewState == null)
				{
					documentHostElementEventArgs.ViewState = new XMLViewStateBag();
				}
				documentHostedObject.SaveViewState(documentHostElementEventArgs);
				if (ViewState != null && ViewState.Count == 0)
				{
					ViewState = null;
				}
			}
			if (!string.IsNullOrEmpty(ValuePropertyName))
			{
				string text = Text = ControlHelper.GetControlValue(object_4, ValuePropertyName);
			}
			if (object_4 != null && ControlHostManger != null)
			{
				ControlHostManger.UpdateControlContentVersion(this);
			}
		}

		/// <summary>
		///       承载的对象加载完毕后处理
		///       </summary>
		
		public virtual void AfterHostedControlLoaded()
		{
		}

		public virtual object vmethod_32()
		{
			int num = 14;
			if (!XTextDocument.smethod_13(GEnum6.const_215))
			{
				return null;
			}
			HostedControlType runtimeControlType = RuntimeControlType;
			if (runtimeControlType == HostedControlType.InvalidateType)
			{
				return null;
			}
			if (SpecifyHostedInstance != null)
			{
				switch (runtimeControlType)
				{
				case HostedControlType.OCX:
					return SpecifyHostedInstance;
				case HostedControlType.NativeWinControl:
					return SpecifyHostedInstance;
				default:
				{
					Type controlType = ControlHelper.GetControlType(TypeFullName, null);
					if (!controlType.IsInstanceOfType(SpecifyHostedInstance))
					{
						ErrorMessage = string.Format(WriterStringsCore.InvalidateControlType_Type_ExpectType, SpecifyHostedInstance.GetType().FullName, controlType.FullName);
						return null;
					}
					ErrorMessage = null;
					return SpecifyHostedInstance;
				}
				}
			}
			if (object_2 != null && object_2 != object_3)
			{
				ErrorMessage = null;
				return object_2;
			}
			if (string.IsNullOrEmpty(TypeFullName))
			{
				ErrorMessage = WriterStringsCore.HostControlTypeIsEmpty;
				return null;
			}
			switch (runtimeControlType)
			{
			case HostedControlType.Control:
			{
				Type controlType2 = ControlHelper.GetControlType(TypeFullName, typeof(Control));
				if (controlType2 != null)
				{
					object result2 = Activator.CreateInstance(controlType2);
					ErrorMessage = null;
					Debug.WriteLine("创建控件 " + controlType2.FullName);
					return result2;
				}
				break;
			}
			case HostedControlType.OCX:
			{
				string text = TypeFullName;
				if (text.StartsWith("OCX:"))
				{
					string text2 = text.Substring(4);
					text = GClass263.smethod_0(text2);
					if (string.IsNullOrEmpty(text))
					{
						ErrorMessage = string.Format(WriterStringsCore.InvalidateOCXType_Name, text2);
						return null;
					}
					try
					{
						Guid guid = new Guid(text);
					}
					catch (Exception ex)
					{
						ErrorMessage = ex.Message + " " + text;
						return null;
					}
				}
				GClass1 result3 = new GClass1(text, this);
				ErrorMessage = null;
				Debug.WriteLine("创建OCX控件:" + text);
				return result3;
			}
			case HostedControlType.WPF:
				if (GClass129.smethod_1() != null)
				{
					Type controlType2 = ControlHelper.GetControlType(TypeFullName, GClass129.smethod_1());
					if (controlType2 != null)
					{
						object result = Activator.CreateInstance(controlType2);
						ErrorMessage = null;
						Debug.WriteLine("创建WPF控件:" + controlType2.FullName);
						return result;
					}
				}
				break;
			case HostedControlType.DocumentImage:
			{
				Type controlType2 = ControlHelper.GetControlType(TypeFullName, typeof(IDocumentImage));
				if (controlType2 != null)
				{
					object result = Activator.CreateInstance(controlType2);
					ErrorMessage = null;
					Debug.WriteLine("创建Image对象:" + controlType2.FullName);
					return result;
				}
				break;
			}
			case HostedControlType.InvalidateType:
				ErrorMessage = string.Format(WriterStringsCore.InvalidateType_Name, TypeFullName);
				break;
			}
			return null;
		}

		
		public object method_23()
		{
			if (ControlHostManger != null)
			{
				object control = ControlHostManger.GetControl(this);
				if (control is GClass1)
				{
					GClass1 gClass = (GClass1)control;
					return gClass.method_0();
				}
			}
			return null;
		}

		
		public override void vmethod_23()
		{
			if (ControlHostManger == null)
			{
				method_22();
				base.vmethod_23();
				return;
			}
			bool flag = false;
			SizeF sizeF = ControlHostManger.TrySetControlSize(this, Width, Height);
			flag = true;
			if (!sizeF.IsEmpty)
			{
				Width = sizeF.Width;
				Height = sizeF.Height;
				ControlHostManger.UpdateHostWindowsControlPosition(this);
			}
			if (!flag)
			{
				Control control = null;
				control = ((!DelayLoadControl) ? ((Control)vmethod_32()) : ControlHostManger.GetControl(this));
				if (control != null)
				{
					using (control)
					{
						vmethod_30(control);
						SizeF sizeF2 = ControlHelper.TrySetControlSize(this, control, Width, Height);
						Width = sizeF2.Width;
						Height = sizeF2.Height;
					}
				}
			}
			method_22();
			base.vmethod_23();
		}

		/// <summary>
		///       文档加载后处理
		///       </summary>
		/// <param name="args">参数</param>
		
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			object_2 = object_3;
			base.AfterLoad(args);
		}

		
		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 6;
			Parameters = new ObjectParameterList();
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			base.ID = readHTMLEventArgs_0.HtmlElement.method_37();
			SizeF sizeF = readHTMLEventArgs_0.ReadImageSize(readHTMLEventArgs_0.HtmlElement);
			if (sizeF.Width > 0f)
			{
				Width = sizeF.Width;
			}
			if (sizeF.Height > 0f)
			{
				Height = sizeF.Height;
			}
			foreach (GClass163 item in readHTMLEventArgs_0.HtmlElement.vmethod_2())
			{
				if (item.TagName == "PARAM")
				{
					ObjectParameter objectParameter = new ObjectParameter();
					objectParameter.Name = item.method_9("name");
					objectParameter.Value = item.method_9("value");
					Parameters.Add(objectParameter);
				}
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		
		public override XTextElement Clone(bool Deeply)
		{
			XTextControlHostElement xTextControlHostElement = (XTextControlHostElement)base.Clone(Deeply);
			xTextControlHostElement.object_2 = null;
			if (objectParameterList_0 != null)
			{
				xTextControlHostElement.objectParameterList_0 = objectParameterList_0.Clone();
			}
			xTextControlHostElement.image_0 = null;
			xTextControlHostElement.byte_0 = null;
			xTextControlHostElement.object_1 = null;
			xTextControlHostElement.xmlviewStateBag_0 = null;
			return xTextControlHostElement;
		}
	}
}
