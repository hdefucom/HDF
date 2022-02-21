using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       编辑器事件消息信息对象,不可继承
	///       </summary>
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterControlEventMessage))]
	[DocumentComment]
	[Guid("C1C0450D-2691-4113-8605-190666E5E599")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("C1C0450D-2691-4113-8605-190666E5E599", "69AC547F-860C-4E11-8D79-95442A0C06EA")]
	public sealed class WriterControlEventMessage : IWriterControlEventMessage
	{
		internal const string CLASSID = "C1C0450D-2691-4113-8605-190666E5E599";

		internal const string CLASSID_Interface = "69AC547F-860C-4E11-8D79-95442A0C06EA";

		private DateTime _CreationTime = DateTime.Now;

		private bool _AltKey = false;

		private bool _AltLeft = false;

		private int _Button = 0;

		private bool _CancelBubble = false;

		private float _ClientX = 0f;

		private float _ClientY = 0f;

		private bool _CtrlKey = false;

		private bool _CtrlLeft = false;

		private XTextElement _FromElement = null;

		private int _KeyCode = 0;

		private float _OffsetX = 0f;

		private float _OffsetY = 0f;

		private object _ReturnValue = null;

		private float _ScreenX = 0f;

		private float _ScreenY = 0f;

		private bool _ShiftKey = false;

		private bool _ShiftLeft = false;

		private string _ContextText = null;

		private XTextElement _SrcElement = null;

		private string _SrcElementValue = null;

		private XTextElement _ToElement = null;

		private WriterControlEventMessageType _TypeValue = WriterControlEventMessageType.None;

		private int _WheelDelta = 0;

		private float _X = 0f;

		private float _Y = 0f;

		public bool AltKey
		{
			get
			{
				return _AltKey;
			}
			set
			{
				_AltKey = value;
			}
		}

		public bool AltLeft
		{
			get
			{
				return _AltLeft;
			}
			set
			{
				_AltLeft = value;
			}
		}

		public int Button
		{
			get
			{
				return _Button;
			}
			set
			{
				_Button = value;
			}
		}

		public bool CancelBubble
		{
			get
			{
				return _CancelBubble;
			}
			set
			{
				_CancelBubble = value;
			}
		}

		public float ClientX
		{
			get
			{
				return _ClientX;
			}
			set
			{
				_ClientX = value;
			}
		}

		public float ClientY
		{
			get
			{
				return _ClientY;
			}
			set
			{
				_ClientY = value;
			}
		}

		public bool CtrlKey
		{
			get
			{
				return _CtrlKey;
			}
			set
			{
				_CtrlKey = value;
			}
		}

		public bool CtrlLeft
		{
			get
			{
				return _CtrlLeft;
			}
			set
			{
				_CtrlLeft = value;
			}
		}

		public XTextElement FromElement
		{
			get
			{
				return _FromElement;
			}
			set
			{
				_FromElement = value;
			}
		}

		public int KeyCode
		{
			get
			{
				return _KeyCode;
			}
			set
			{
				_KeyCode = value;
			}
		}

		public float OffsetX
		{
			get
			{
				return _OffsetX;
			}
			set
			{
				_OffsetX = value;
			}
		}

		public float OffsetY
		{
			get
			{
				return _OffsetY;
			}
			set
			{
				_OffsetY = value;
			}
		}

		public object ReturnValue
		{
			get
			{
				return _ReturnValue;
			}
			set
			{
				_ReturnValue = value;
			}
		}

		public string StringReturnValue
		{
			get
			{
				if (_ReturnValue == null)
				{
					return null;
				}
				return _ReturnValue.ToString();
			}
			set
			{
				_ReturnValue = value;
			}
		}

		public float ScreenX
		{
			get
			{
				return _ScreenX;
			}
			set
			{
				_ScreenX = value;
			}
		}

		public float ScreenY
		{
			get
			{
				return _ScreenY;
			}
			set
			{
				_ScreenY = value;
			}
		}

		public bool ShiftKey
		{
			get
			{
				return _ShiftKey;
			}
			set
			{
				_ShiftKey = value;
			}
		}

		public bool ShiftLeft
		{
			get
			{
				return _ShiftLeft;
			}
			set
			{
				_ShiftLeft = value;
			}
		}

		/// <summary>
		///       事件相关的文本
		///       </summary>
		public string ContextText
		{
			get
			{
				return _ContextText;
			}
			set
			{
				_ContextText = value;
			}
		}

		/// <summary>
		///       事件来源元素
		///       </summary>
		public XTextElement SrcElement
		{
			get
			{
				return _SrcElement;
			}
			set
			{
				_SrcElement = value;
			}
		}

		/// <summary>
		///       事件来源元素编号
		///       </summary>
		public string SrcElementID
		{
			get
			{
				if (_SrcElement == null)
				{
					return null;
				}
				return _SrcElement.ID;
			}
		}

		/// <summary>
		///       事件来源元素名称
		///       </summary>
		public string SrcElementName
		{
			get
			{
				if (_SrcElement is XTextInputFieldElementBase)
				{
					return ((XTextInputFieldElementBase)_SrcElement).Name;
				}
				if (_SrcElement is XTextObjectElement)
				{
					return ((XTextObjectElement)_SrcElement).Name;
				}
				return null;
			}
		}

		/// <summary>
		///       来源元素值
		///       </summary>
		public string SrcElementValue
		{
			get
			{
				return _SrcElementValue;
			}
			set
			{
				_SrcElementValue = value;
			}
		}

		/// <summary>
		///       获得事件来源所在的输入域元素对象
		///       </summary>
		public XTextInputFieldElement SrcInputFieldElement
		{
			get
			{
				if (SrcElement == null)
				{
					return null;
				}
				return (XTextInputFieldElement)SrcElement.GetOwnerParent(typeof(XTextInputFieldElement), includeThis: true);
			}
		}

		/// <summary>
		///       获得事件来源所在的单元格元素对象
		///       </summary>
		public XTextTableCellElement SrcTableCellElement
		{
			get
			{
				if (SrcElement == null)
				{
					return null;
				}
				return (XTextTableCellElement)SrcElement.GetOwnerParent(typeof(XTextTableCellElement), includeThis: true);
			}
		}

		/// <summary>
		///       获得事件来源所在的表格行元素对象
		///       </summary>
		public XTextTableRowElement SrcTableRowElement
		{
			get
			{
				if (SrcElement == null)
				{
					return null;
				}
				return (XTextTableRowElement)SrcElement.GetOwnerParent(typeof(XTextTableRowElement), includeThis: true);
			}
		}

		/// <summary>
		///       获得事件来源所在的表格元素对象
		///       </summary>
		public XTextTableElement SrcTableElement
		{
			get
			{
				if (SrcElement == null)
				{
					return null;
				}
				return (XTextTableElement)SrcElement.GetOwnerParent(typeof(XTextTableElement), includeThis: true);
			}
		}

		/// <summary>
		///       获得事件来源所在的表格元素对象
		///       </summary>
		public XTextSectionElement SrcSectionElement
		{
			get
			{
				if (SrcElement == null)
				{
					return null;
				}
				return (XTextSectionElement)SrcElement.GetOwnerParent(typeof(XTextSectionElement), includeThis: true);
			}
		}

		/// <summary>
		///       事件来源文档元素类型名称
		///       </summary>
		public string SrcElementTypeName
		{
			get
			{
				if (SrcElement == null)
				{
					return null;
				}
				return SrcElement.GetType().Name;
			}
		}

		public XTextElement ToElement
		{
			get
			{
				return _ToElement;
			}
			set
			{
				_ToElement = value;
			}
		}

		internal WriterControlEventMessageType TypeValue
		{
			get
			{
				return _TypeValue;
			}
			set
			{
				_TypeValue = value;
			}
		}

		public string Type => _TypeValue.ToString();

		public int WheelDelta
		{
			get
			{
				return _WheelDelta;
			}
			set
			{
				_WheelDelta = value;
			}
		}

		public float X
		{
			get
			{
				return _X;
			}
			set
			{
				_X = value;
			}
		}

		public float Y
		{
			get
			{
				return _Y;
			}
			set
			{
				_Y = value;
			}
		}

		public static WriterControlEventMessage CreateForKeyEvent(WriterControlEventMessageType type, DocumentEventArgs args)
		{
			WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(type);
			writerControlEventMessage.KeyCode = (int)args.KeyCode;
			writerControlEventMessage.SrcElement = args.Element;
			writerControlEventMessage.ToElement = args.Element;
			writerControlEventMessage.X = args.X;
			writerControlEventMessage.Y = args.Y;
			writerControlEventMessage.Button = (int)args.Button;
			writerControlEventMessage.AltKey = args.AltKey;
			writerControlEventMessage.ShiftKey = args.ShiftKey;
			writerControlEventMessage.CtrlKey = args.CtlKey;
			writerControlEventMessage.WheelDelta = args.WheelDelta;
			writerControlEventMessage.ClientX = args.ClientX;
			writerControlEventMessage.ClientY = args.ClientY;
			return writerControlEventMessage;
		}

		public static WriterControlEventMessage CreateForMouseEvent(WriterControlEventMessageType type, DocumentEventArgs args)
		{
			WriterControlEventMessage writerControlEventMessage = new WriterControlEventMessage(type);
			writerControlEventMessage.KeyCode = (int)args.KeyCode;
			writerControlEventMessage.SrcElement = args.Element;
			writerControlEventMessage.ToElement = args.Element;
			writerControlEventMessage.X = args.X;
			writerControlEventMessage.Y = args.Y;
			writerControlEventMessage.Button = (int)args.Button;
			writerControlEventMessage.AltKey = args.AltKey;
			writerControlEventMessage.ShiftKey = args.ShiftKey;
			writerControlEventMessage.CtrlKey = args.CtlKey;
			writerControlEventMessage.WheelDelta = args.WheelDelta;
			writerControlEventMessage.ClientX = args.ClientX;
			writerControlEventMessage.ClientY = args.ClientY;
			return writerControlEventMessage;
		}

		public WriterControlEventMessage(WriterControlEventMessageType type)
		{
			_TypeValue = type;
		}

		public WriterControlEventMessage(WriterControlEventMessageType type, KeyEventArgs args)
		{
		}

		[ComVisible(false)]
		
		public void method_0()
		{
			_FromElement = null;
			_ReturnValue = null;
			_SrcElement = null;
			_SrcElementValue = null;
			_ToElement = null;
		}

		public bool CheckTimeout()
		{
			return (DateTime.Now - _CreationTime).TotalSeconds > 3.0;
		}

		public override string ToString()
		{
			int num = 9;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Type);
			if (!string.IsNullOrEmpty(ContextText))
			{
				stringBuilder.Append(":Text:" + ContextText);
			}
			if (SrcElement != null)
			{
				stringBuilder.Append(";" + SrcElement.ToDebugString());
			}
			return stringBuilder.ToString();
		}
	}
}
