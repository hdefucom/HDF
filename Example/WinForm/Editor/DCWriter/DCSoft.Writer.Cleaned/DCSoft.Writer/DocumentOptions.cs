#define DEBUG
using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档选项对象
	///       </summary>
	/// <remarks>
	///       编写 袁永福
	///       </remarks>
	[Serializable]
	[DocumentComment]
	[DCPublishAPI]
	[ComClass("00012345-6789-ABCD-EF01-23456789006A", "71B9BF56-ABD2-441E-A401-0F36367A01AE")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-23456789006A")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDocumentOptions))]
	[DCDescriptionResourceSource("DCSoft.Writer.WriterCoreDescriptionStrings")]
	public class DocumentOptions : ICloneable, IDocumentOptions
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789006A";

		internal const string CLASSID_Interface = "71B9BF56-ABD2-441E-A401-0F36367A01AE";

		[NonSerialized]
		private WriterViewControl _WriterControl = null;

		private DocumentSecurityOptions _SecurityOptions = new DocumentSecurityOptions();

		private DocumentViewOptions _ViewOptions = new DocumentViewOptions();

		private DocumentBehaviorOptions _BehaviorOptions = new DocumentBehaviorOptions();

		private DocumentEditOptions _EditOptions = new DocumentEditOptions();

		/// <summary>
		///       安全和权限方面的设置
		///       </summary>
		[Browsable(true)]
		[ReadOnly(true)]
		[DCDescription(typeof(DocumentOptions), "SecurityOptions")]
		[DCPublishAPI]
		public DocumentSecurityOptions SecurityOptions
		{
			get
			{
				if (_SecurityOptions == null)
				{
					_SecurityOptions = new DocumentSecurityOptions();
				}
				return _SecurityOptions;
			}
			set
			{
				_SecurityOptions = value;
			}
		}

		/// <summary>
		///       文档视图方面的选项
		///       </summary>
		[DCDescription(typeof(DocumentOptions), "ViewOptions")]
		[ReadOnly(true)]
		[Browsable(true)]
		[DCPublishAPI]
		public DocumentViewOptions ViewOptions
		{
			get
			{
				if (_ViewOptions == null)
				{
					_ViewOptions = new DocumentViewOptions();
				}
				return _ViewOptions;
			}
			set
			{
				_ViewOptions = value;
			}
		}

		/// <summary>
		///       编辑器行为方面的选项
		///       </summary>
		[DCPublishAPI]
		[ReadOnly(true)]
		[DCDescription(typeof(DocumentOptions), "BehaviorOptions")]
		[Browsable(true)]
		public DocumentBehaviorOptions BehaviorOptions
		{
			get
			{
				if (_BehaviorOptions == null)
				{
					_BehaviorOptions = new DocumentBehaviorOptions();
				}
				return _BehaviorOptions;
			}
			set
			{
				_BehaviorOptions = value;
			}
		}

		/// <summary>
		///       编辑方面的选项
		///       </summary>
		[DCDescription(typeof(DocumentOptions), "EditOptions")]
		[ReadOnly(true)]
		[DCPublishAPI]
		[Browsable(true)]
		public DocumentEditOptions EditOptions
		{
			get
			{
				if (_EditOptions == null)
				{
					_EditOptions = new DocumentEditOptions();
				}
				return _EditOptions;
			}
			set
			{
				_EditOptions = value;
			}
		}

		/// <summary>
		///       设置对象所属的编辑器控件
		///       </summary>
		/// <param name="ctl">
		/// </param>
		internal void SetWriterControl(WriterViewControl writerViewControl_0)
		{
			_WriterControl = writerViewControl_0;
		}

		/// <summary>
		///       保存对象状态。
		///       </summary>
		/// <remarks>
		///       有时程序完成一个操作时需要临时修改文档选项，操作完毕后需要恢复文档选项。则可以使用该方法。
		///       <br />该方法返回一个IDisposable对象，然后可以任意修改文档选项，当调用这个IDisposalbe.Dispose()
		///       时，则所有的文档选项立刻恢复原状。
		///       </remarks>
		/// <example>
		///       using (IDisposable res = this.myEditControl.DocumentOptions.SaveState())
		///       {
		///          myEditControl.DocumentOptions.ViewOptions.ShowCellNoneBorder = false;
		///          myEditControl.DocumentOptions.ViewOptions.ShowParagraphFlag = false;
		///          myEditControl.DocumentOptions.ViewOptions.ShowFieldBorderElement = false;
		///          //执行各种其他功能
		///       }//using
		///       // 这里自动恢复DocumentOptions中的各种配置选项。
		///       </example>
		/// <returns>
		/// </returns>
		public IDisposable SaveState()
		{
			GClass365 gClass = new GClass365();
			gClass.method_2(Clone());
			gClass.eventHandler_1 = InnerRestoreState;
			gClass.vmethod_0();
			return gClass;
		}

		/// <summary>
		///       和SaveState()函数配对使用。恢复DocumentOptions中的各种配置选项。
		///       </summary>
		/// <param name="state">SaveState()的返回值。</param>
		/// <returns>操作是否成功</returns>
		public bool RestoreState(object state)
		{
			if (state is GClass365)
			{
				GClass365 gClass = (GClass365)state;
				gClass.Dispose();
				return true;
			}
			return false;
		}

		private void InnerRestoreState(object sender, EventArgs e)
		{
			GClass365 gClass = (GClass365)sender;
			DocumentOptions documentOptions = (DocumentOptions)gClass.method_1();
			_BehaviorOptions = documentOptions._BehaviorOptions;
			_EditOptions = documentOptions._EditOptions;
			_SecurityOptions = documentOptions._SecurityOptions;
			_ViewOptions = documentOptions._ViewOptions;
			if (_WriterControl != null && _WriterControl.OwnerWriterControl != null)
			{
				_WriterControl.OwnerWriterControl.Invalidate(invalidateChildren: true);
			}
		}

		public Dictionary<string, string> GetAllOptionValues()
		{
			int num = 13;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				object value = propertyInfo.GetValue(this, null);
				PropertyInfo[] properties2 = value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo2 in properties2)
				{
					if (!propertyInfo2.CanRead || !propertyInfo2.CanWrite)
					{
						continue;
					}
					object value2 = propertyInfo2.GetValue(value, null);
					if (value2 != null)
					{
						string value3 = value2.ToString();
						if (value2 is Color)
						{
							value3 = XMLSerializeHelper.ColorToString((Color)value2);
						}
						dictionary[propertyInfo.Name + "." + propertyInfo2.Name] = value3;
					}
				}
			}
			return dictionary;
		}

		/// <summary>
		///       设置选项值,选项名称为“选项组名.选项名称”的格式，比如“ViewOptions.ShowParagraphFlag”。
		///       </summary>
		/// <remarks>
		///       比如
		///       obj.SetOptionValue("ViewOptions.ShowParagraphFlag","true");
		///       <br />obj.SetOptionValue("ViewOptions.TagColorForNormalField","#AAAAAA");
		///       </remarks>
		/// <param name="name">选项名称</param>
		/// <param name="Value">新的选项值</param>
		/// <returns>操作是否成功</returns>
		public bool SetOptionValue(string name, string Value)
		{
			int num = 18;
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			PropertyInfo prop = null;
			object instance = null;
			if (GetOptionProperty(name, ref prop, ref instance))
			{
				if (!string.IsNullOrEmpty(Value) && prop.PropertyType.Equals(typeof(Color)))
				{
					Color color = XMLSerializeHelper.StringToColor(Value, Color.Black);
					prop.SetValue(instance, color, null);
					return true;
				}
				return ValueTypeHelper.SetPropertyValue(instance, prop.Name, Value, throwException: false);
			}
			return false;
		}

		/// <summary>
		///       获得指定名称的选项数值,选项名称为“选项组名.选项名称”的格式，比如“ViewOptions.ShowParagraphFlag”。
		///       </summary>
		/// <remarks>
		///       比如
		///       string v = obj.GetOptionValue("ViewOptions.ShowParagraphFlag" ); // 返回 "true"或"false"。
		///       <br />string v2 = obj.GetOptionValue("ViewOptions.TagColorForNormalField");// 返回类似"#AAAAAA"等表示颜色值的字符串。
		///       </remarks>
		/// <param name="name">选项名称</param>
		/// <returns>选项数值</returns>
		public string GetOptionValue(string name)
		{
			int num = 5;
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			PropertyInfo prop = null;
			object instance = null;
			if (GetOptionProperty(name, ref prop, ref instance))
			{
				object value = prop.GetValue(instance, null);
				if (value == null || DBNull.Value.Equals(value))
				{
					return null;
				}
				if (value is Color)
				{
					return XMLSerializeHelper.ColorToString((Color)value);
				}
				if (value is DateTime)
				{
					return FormatUtils.ToYYYY_MM_DD_HH_MM_SS((DateTime)value);
				}
				return value.ToString();
			}
			return null;
		}

		private bool GetOptionProperty(string name, ref PropertyInfo prop, ref object instance)
		{
			int num = name.IndexOf('.');
			if (num > 0)
			{
				string name2 = name.Substring(0, num).Trim();
				string name3 = name.Substring(num + 1).Trim();
				PropertyInfo property = GetType().GetProperty(name2, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
				if (property != null)
				{
					object value = property.GetValue(this, null);
					if (value != null)
					{
						PropertyInfo property2 = value.GetType().GetProperty(name3, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
						if (property2 != null)
						{
							prop = property2;
							instance = value;
							return true;
						}
					}
				}
			}
			return false;
		}

		[DCPublishAPI]
		public string ToXMLString()
		{
			return XMLHelper.SaveObjectToIndentXMLString(this);
		}

		[DCPublishAPI]
		public void FromXMLString(string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				DocumentOptions documentOptions = (DocumentOptions)XMLHelper.LoadObjectFromXMLString(GetType(), string_0);
				if (documentOptions != null)
				{
					_BehaviorOptions = documentOptions._BehaviorOptions;
					_EditOptions = documentOptions._EditOptions;
					_SecurityOptions = documentOptions._SecurityOptions;
					_ViewOptions = documentOptions._ViewOptions;
				}
			}
		}

		/// <summary>
		///       加载独立配置文件
		///       </summary>
		/// <param name="fileName">
		/// </param>
		public void LoadLocalFile(string fileName)
		{
			int num = 19;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName);
			}
			using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(GetType());
				DocumentOptions documentOptions = (DocumentOptions)xmlSerializer.Deserialize(stream);
				_BehaviorOptions = documentOptions._BehaviorOptions;
				_EditOptions = documentOptions._EditOptions;
				_SecurityOptions = documentOptions._SecurityOptions;
				_ViewOptions = documentOptions._ViewOptions;
			}
		}

		/// <summary>
		///       保存到本地的独立文件
		///       </summary>
		/// <param name="fileName">
		/// </param>
		public void SaveLocalFile(string fileName)
		{
			int num = 4;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(GetType());
				xmlSerializer.Serialize(stream, this);
			}
		}

		/// <summary>
		///       从配置文件中加载系统配置
		///       </summary>
		public void LoadAppConfig()
		{
			int num = 12;
			NameValueCollection appSettings = ConfigurationManager.AppSettings;
			if (appSettings == null)
			{
				return;
			}
			string text = "DCSoft.Writer.Options.";
			string[] allKeys = appSettings.AllKeys;
			foreach (string text2 in allKeys)
			{
				string text3 = text2.Trim().ToLower();
				if (text3.StartsWith(text, StringComparison.CurrentCultureIgnoreCase))
				{
					string text4 = appSettings[text2];
					try
					{
						text3 = text3.Substring(text.Length);
						int num2 = text3.IndexOf(".");
						if (num2 > 0)
						{
							string name = text3.Substring(0, num2).Trim();
							string name2 = text3.Substring(num2 + 1).Trim();
							PropertyInfo property = GetType().GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance);
							if (property != null)
							{
								object value = property.GetValue(this, null);
								if (value != null)
								{
									PropertyInfo property2 = value.GetType().GetProperty(name2, BindingFlags.IgnoreCase | BindingFlags.Instance);
									if (property2 != null)
									{
										TypeConverter converter = TypeDescriptor.GetConverter(property2.PropertyType);
										if (converter.CanConvertFrom(typeof(string)))
										{
											object value2 = converter.ConvertFrom(text4);
											property2.SetValue(value, value2, null);
										}
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						Debug.WriteLine(text2 + "=" + text4 + ":" + ex.Message);
					}
				}
			}
		}

		/// <summary>
		///       内部使用
		///       </summary>
		public static void WriteName()
		{
			int num = 18;
			PropertyInfo[] properties = typeof(DocumentOptions).GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				PropertyInfo[] properties2 = propertyInfo.PropertyType.GetProperties();
				foreach (PropertyInfo propertyInfo2 in properties2)
				{
					Console.WriteLine("case \"dcsoft.writer.options." + propertyInfo.Name.ToLower() + "." + propertyInfo2.Name.ToLower() + "\":\r\n this." + propertyInfo.Name + "." + propertyInfo2.Name + "=1; \r\nbreak;");
				}
			}
			properties = typeof(DocumentOptions).GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				PropertyInfo[] properties2 = propertyInfo.PropertyType.GetProperties();
				foreach (PropertyInfo propertyInfo2 in properties2)
				{
					Console.WriteLine("<add key=\"DCSoft.Writer.Options." + propertyInfo.Name + "." + propertyInfo2.Name + "\" value=\"" + propertyInfo2.PropertyType.Name + "\" />");
				}
			}
		}

		internal void CopyValuesTo(DocumentOptions documentOptions_0)
		{
			if (_BehaviorOptions != null)
			{
				documentOptions_0._BehaviorOptions = _BehaviorOptions.Clone();
			}
			if (_EditOptions != null)
			{
				documentOptions_0._EditOptions = _EditOptions.Clone();
			}
			if (_SecurityOptions != null)
			{
				documentOptions_0._SecurityOptions = _SecurityOptions.Clone();
			}
			if (_ViewOptions != null)
			{
				documentOptions_0._ViewOptions = _ViewOptions.Clone();
			}
		}

		object ICloneable.Clone()
		{
			DocumentOptions documentOptions = new DocumentOptions();
			if (_EditOptions != null)
			{
				documentOptions._EditOptions = _EditOptions.Clone();
			}
			if (_ViewOptions != null)
			{
				documentOptions._ViewOptions = _ViewOptions.Clone();
			}
			if (_BehaviorOptions != null)
			{
				documentOptions._BehaviorOptions = _BehaviorOptions.Clone();
			}
			if (_SecurityOptions != null)
			{
				documentOptions._SecurityOptions = _SecurityOptions.Clone();
			}
			return documentOptions;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DocumentOptions Clone()
		{
			return (DocumentOptions)((ICloneable)this).Clone();
		}

		internal void InnerDispose()
		{
			_BehaviorOptions = null;
			_EditOptions = null;
			_SecurityOptions = null;
			_ViewOptions = null;
			_WriterControl = null;
		}
	}
}
