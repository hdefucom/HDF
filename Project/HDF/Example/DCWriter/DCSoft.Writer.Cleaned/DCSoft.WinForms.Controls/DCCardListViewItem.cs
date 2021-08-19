using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片列表项目
	///       </summary>
	[DocumentComment]
	[Guid("D1907DF1-6F4A-4CA6-9CB2-93E35854F243")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDCCardListViewItem))]
	public class DCCardListViewItem : IDCCardListViewItem
	{
		private string _Name = null;

		internal DCCardListViewControl _ListView = null;

		private Color _BorderColor = Color.Empty;

		private int _BorderWidth = 1;

		private Color _BackColor = Color.Empty;

		private string _ToolTip = null;

		private bool _HighlightBorder = false;

		private bool _Highlight = false;

		/// <summary>
		///       闪烁状态的高亮度值
		///       </summary>
		internal bool _BlinkHighlight = false;

		private bool _Blink = false;

		private bool _Pushed = false;

		private bool _Selected = false;

		private object _Tag = null;

		internal int _Index = 0;

		internal int _RowIndex = 0;

		internal int _ColumnIndex = 0;

		[NonSerialized]
		private int _Left = 0;

		[NonSerialized]
		internal int _Top = 0;

		[NonSerialized]
		private int _Width = 0;

		[NonSerialized]
		private int _Height = 0;

		[NonSerialized]
		internal object _DataBoundItem = null;

		private Dictionary<DCCardContentItem, object> _Values = null;

		private Dictionary<DCCardContentItem, object> _TooltipValues = null;

		private bool _AutoLine = false;

		/// <summary>
		///       对象名称
		///       </summary>
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       项目所属的控件
		///       </summary>
		[Browsable(false)]
		public DCCardListViewControl ListView => _ListView;

		/// <summary>
		///       边框色
		///       </summary>
		[DefaultValue(typeof(Color), "Empty")]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
			}
		}

		/// <summary>
		///       边框线宽度
		///       </summary>
		[DefaultValue(1)]
		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = value;
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[DefaultValue(typeof(Color), "Empty")]
		public Color BackColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
			}
		}

		/// <summary>
		///       提示文本
		///       </summary>
		[DefaultValue(null)]
		public string ToolTip
		{
			get
			{
				return _ToolTip;
			}
			set
			{
				_ToolTip = value;
			}
		}

		/// <summary>
		///       高亮度显示边框
		///       </summary>
		[DefaultValue(false)]
		public bool HighlightBorder
		{
			get
			{
				return _HighlightBorder;
			}
			set
			{
				if (_HighlightBorder != value)
				{
					_HighlightBorder = value;
					if (_ListView != null)
					{
						_ListView.InvalidateItem(this);
					}
				}
			}
		}

		/// <summary>
		///       处于高亮度模式
		///       </summary>
		[DefaultValue(false)]
		public bool Highlight
		{
			get
			{
				return _Highlight;
			}
			set
			{
				if (_Highlight != value)
				{
					_Highlight = value;
					if (_ListView != null)
					{
						_ListView.InvalidateItem(this);
					}
				}
			}
		}

		/// <summary>
		///       闪烁模式
		///       </summary>
		[DefaultValue(false)]
		public bool Blink
		{
			get
			{
				return _Blink;
			}
			set
			{
				_Blink = value;
			}
		}

		/// <summary>
		///       项目被按下
		///       </summary>
		public bool Pushed
		{
			get
			{
				return _Pushed;
			}
			set
			{
				if (_Pushed != value)
				{
					_Pushed = value;
					if (_ListView != null)
					{
						_ListView.InvalidateItem(this);
					}
				}
			}
		}

		/// <summary>
		///       被选中标记
		///       </summary>
		public bool Selected
		{
			get
			{
				return _Selected;
			}
			set
			{
				_Selected = value;
			}
		}

		/// <summary>
		///       附加数据
		///       </summary>
		[Browsable(false)]
		public object Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		/// <summary>
		///       序号
		///       </summary>
		[ReadOnly(true)]
		[Browsable(false)]
		public int Index => _Index;

		/// <summary>
		///       从0开始计算的列号
		///       </summary>
		[Browsable(false)]
		public int RowIndex => _RowIndex;

		/// <summary>
		///       从0开始计算的行号
		///       </summary>
		[Browsable(false)]
		public int ColumnIndex => _ColumnIndex;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Left
		{
			get
			{
				return _Left;
			}
			set
			{
				_Left = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int Top
		{
			get
			{
				return _Top;
			}
			set
			{
				_Top = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Width
		{
			get
			{
				return _Width;
			}
			set
			{
				_Width = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Height
		{
			get
			{
				return _Height;
			}
			set
			{
				_Height = value;
			}
		}

		/// <summary>
		///       绑定的数据源对象
		///       </summary>
		public object DataBoundItem => _DataBoundItem;

		/// <summary>
		///       各个分项目的数据
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public Dictionary<DCCardContentItem, object> Values
		{
			get
			{
				return _Values;
			}
			set
			{
				_Values = value;
			}
		}

		/// <summary>
		///       工具条提示中各个项目的数据
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public Dictionary<DCCardContentItem, object> TooltipValues
		{
			get
			{
				return _TooltipValues;
			}
			set
			{
				_TooltipValues = value;
			}
		}

		/// <summary>
		///       强制换行
		///       </summary>
		[DefaultValue(false)]
		public bool AutoLine
		{
			get
			{
				return _AutoLine;
			}
			set
			{
				_AutoLine = value;
			}
		}

		/// <summary>
		///       声明卡片视图无效,需要重新绘制
		///       </summary>
		public void Invalidate()
		{
			if (ListView != null)
			{
				ListView.InvalidateItem(this);
			}
		}

		/// <summary>
		///       根据文件名设置图片值
		///       </summary>
		/// <param name="dataFieldName">字段名</param>
		/// <param name="fileName">图片文件名</param>
		/// <returns>操作是否修改了项目数值</returns>
		[ComVisible(true)]
		public bool SetImageValueByFileName(string dataFieldName, string fileName)
		{
			Image value = GClass343.smethod_8(fileName);
			return SetValue(dataFieldName, value);
		}

		/// <summary>
		///       根据BASE64字符串来设置图片值
		///       </summary>
		/// <param name="dataFieldName">字段名</param>
		/// <param name="base64String">BASE64字符串</param>
		/// <returns>操作是否修改了项目数据</returns>
		[ComVisible(true)]
		public bool SetImageValueByBase64String(string dataFieldName, string base64String)
		{
			Image value = GClass343.smethod_9(base64String);
			return SetValue(dataFieldName, value);
		}

		/// <summary>
		///       设置文本值
		///       </summary>
		/// <param name="dataFieldName">字段名</param>
		/// <param name="textValue">文本值</param>
		/// <returns>操作是否修改了项目值</returns>
		[ComVisible(true)]
		public bool SetStringValue(string dataFieldName, string textValue)
		{
			return SetValue(dataFieldName, textValue);
		}

		/// <summary>
		///       设置数值
		///       </summary>
		/// <param name="dataFieldName">字段名</param>
		/// <param name="Value">数值</param>
		/// <returns>操作是否修改了列表数据</returns>
		[ComVisible(false)]
		public bool SetValue(string dataFieldName, object Value)
		{
			if (ListView == null)
			{
				return false;
			}
			bool flag = false;
			if (Values == null)
			{
				Values = new Dictionary<DCCardContentItem, object>();
			}
			if (TooltipValues == null)
			{
				TooltipValues = new Dictionary<DCCardContentItem, object>();
			}
			foreach (DCCardContentItem item in ListView.CardTemplate)
			{
				if (item.DataField == dataFieldName)
				{
					Values[item] = Value;
					flag = true;
				}
			}
			foreach (DCCardContentItem tooltipContentItem in ListView.TooltipContentItems)
			{
				if (tooltipContentItem.DataField == dataFieldName)
				{
					TooltipValues[tooltipContentItem] = Value;
					flag = true;
				}
			}
			if (ListView.ItemTooltipDataFieldName == dataFieldName)
			{
				ToolTip = Convert.ToString(Value);
				flag = true;
			}
			if (flag && _ListView != null)
			{
				_ListView.InvalidateItem(this);
			}
			return flag;
		}

		/// <summary>
		///       获得指定字段的文本值
		///       </summary>
		/// <param name="fieldName">字段名</param>
		/// <returns>获得的文本值</returns>
		[ComVisible(true)]
		public string GetStringValue(string fieldName)
		{
			object value = GetValue(fieldName);
			if (value == null || DBNull.Value.Equals(value))
			{
				return null;
			}
			return Convert.ToString(value);
		}

		/// <summary>
		///       获得指定字段值
		///       </summary>
		/// <param name="fieldName">字段名</param>
		/// <returns>字段值</returns>
		[ComVisible(false)]
		public object GetValue(string fieldName)
		{
			if (Values != null)
			{
				foreach (DCCardContentItem key in Values.Keys)
				{
					if (key.DataField == fieldName)
					{
						return Values[key];
					}
				}
			}
			if (TooltipValues != null)
			{
				foreach (DCCardContentItem key2 in TooltipValues.Keys)
				{
					if (key2.DataField == fieldName)
					{
						return TooltipValues[key2];
					}
				}
			}
			return null;
		}
	}
}
