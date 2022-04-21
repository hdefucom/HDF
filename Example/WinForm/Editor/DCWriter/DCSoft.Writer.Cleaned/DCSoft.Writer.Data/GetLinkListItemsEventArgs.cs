using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       联动列表项目事件参数
	///       </summary>
	[ComVisible(true)]
	[ComClass("5DEE4ED0-0C1B-43CF-9E76-65438B9D7459", "C1DF2846-0F00-4E73-970D-DD8EB84C6328")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IGetLinkListItemsEventArgs))]
	
	[Guid("5DEE4ED0-0C1B-43CF-9E76-65438B9D7459")]
	
	public class GetLinkListItemsEventArgs : EventArgs, IGetLinkListItemsEventArgs
	{
		internal const string CLASSID = "5DEE4ED0-0C1B-43CF-9E76-65438B9D7459";

		internal const string CLASSID_Interface = "C1DF2846-0F00-4E73-970D-DD8EB84C6328";

		private XTextElementList _EffectElements = null;

		private XTextElement _ParentElement = null;

		private LinkListBindingInfo _ParentBinding = null;

		private string _ParentValue = null;

		private XTextElement _CurrentElement = null;

		private LinkListBindingInfo _CurrentBinding = null;

		private ListItemCollection _Items = new ListItemCollection();

		private bool _Handled = false;

		private bool _Cancel = false;

		/// <summary>
		///       所有关联的输入域元素列表
		///       </summary>
		
		public XTextElementList EffectElements
		{
			get
			{
				return _EffectElements;
			}
			set
			{
				_EffectElements = value;
			}
		}

		
		public string ParentTextList
		{
			get
			{
				int num = 16;
				if (_EffectElements != null)
				{
					int num2 = _EffectElements.IndexOf(CurrentElement);
					if (num2 > 0)
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < num2; i++)
						{
							XTextElement xTextElement = _EffectElements[i];
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(",");
							}
							stringBuilder.Append(xTextElement.Text);
						}
						return stringBuilder.ToString();
					}
				}
				return null;
			}
		}

		
		public string ParentValueList
		{
			get
			{
				int num = 2;
				if (_EffectElements != null)
				{
					int num2 = _EffectElements.IndexOf(CurrentElement);
					if (num2 > 1)
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < num2; i++)
						{
							XTextInputFieldElement xTextInputFieldElement = _EffectElements[i] as XTextInputFieldElement;
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(",");
							}
							if (xTextInputFieldElement != null)
							{
								stringBuilder.Append(xTextInputFieldElement.InnerValue);
							}
						}
						return stringBuilder.ToString();
					}
				}
				return null;
			}
		}

		/// <summary>
		///       父层次的文档元素对象
		///       </summary>
		
		public XTextElement ParentElement
		{
			get
			{
				return _ParentElement;
			}
			set
			{
				_ParentElement = value;
			}
		}

		/// <summary>
		///       父层次的绑定信息
		///       </summary>
		
		public LinkListBindingInfo ParentBinding
		{
			get
			{
				return _ParentBinding;
			}
			set
			{
				_ParentBinding = value;
			}
		}

		/// <summary>
		///       父层次元素值
		///       </summary>
		
		public string ParentValue
		{
			get
			{
				return _ParentValue;
			}
			set
			{
				_ParentValue = value;
			}
		}

		/// <summary>
		///       当前元素在联动中的等级，-1表示错误。
		///       </summary>
		
		public int CurrentLevelBase0
		{
			get
			{
				if (EffectElements != null)
				{
					return EffectElements.IndexOf(CurrentElement);
				}
				return -1;
			}
		}

		/// <summary>
		///       当前处理的文档元素对象
		///       </summary>
		
		public XTextElement CurrentElement
		{
			get
			{
				return _CurrentElement;
			}
			set
			{
				_CurrentElement = value;
			}
		}

		/// <summary>
		///       当前层次绑定信息
		///       </summary>
		
		public LinkListBindingInfo CurrentBinding
		{
			get
			{
				return _CurrentBinding;
			}
			set
			{
				_CurrentBinding = value;
			}
		}

		
		public string ProviderName
		{
			get
			{
				if (_CurrentBinding != null)
				{
					return _CurrentBinding.ProviderName;
				}
				return null;
			}
		}

		/// <summary>
		///       列表项目
		///       </summary>
		
		public ListItemCollection Items
		{
			get
			{
				return _Items;
			}
			set
			{
				_Items = value;
			}
		}

		/// <summary>
		///       事件已经处理了标记，若为true则表示无需后续处理
		///       </summary>
		
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       用户取消操作标记
		///       </summary>
		
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}
	}
}
