using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       复选框控件
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[DocumentComment]
	[XmlType("XTextRadioBox")]
	[DCPublishAPI]
	[ToolboxBitmap(typeof(XTextRadioBoxElement))]
	[ComClass("CDCE6FD0-4D2A-4241-A9DD-52CEAFC909D8", "FA36AF8F-4188-4AAA-ABA2-621971228E34")]
	[ComDefaultInterface(typeof(IXTextRadioBoxElement))]
	[DebuggerDisplay("Radio:Name={Name} , Checked={Checked}")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("CDCE6FD0-4D2A-4241-A9DD-52CEAFC909D8")]
	public sealed class XTextRadioBoxElement : XTextCheckBoxElementBase, IXTextRadioBoxElement
	{
		internal const string string_17 = "CDCE6FD0-4D2A-4241-A9DD-52CEAFC909D8";

		internal const string string_18 = "FA36AF8F-4188-4AAA-ABA2-621971228E34";

		public override string DomDisplayName => "Radio:" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "rdo";

		/// <summary>
		///       组名,已作废
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlIgnore]
		public override string GroupName
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		/// <summary>
		///       控件类型为单选框类型
		///       </summary>
		[DefaultValue(CheckBoxControlStyle.RadioBox)]
		[XmlIgnore]
		[Browsable(false)]
		public override CheckBoxControlStyle ControlStyle
		{
			get
			{
				return CheckBoxControlStyle.RadioBox;
			}
			set
			{
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextRadioBoxElement()
		{
		}

		public override void vmethod_29(object sender, ContentChangedEventArgs e)
		{
			int num = 2;
			base.vmethod_29(sender, e);
			if (OwnerDocument.ExpressionExecuter != null && XTextDocument.smethod_13(GEnum6.const_188))
			{
				OwnerDocument.ExpressionExecuter.imethod_1(this, base.EventExpressions, "ContentChanged", e.LoadingDocument);
			}
		}
	}
}
