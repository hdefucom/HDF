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
	
	[ClassInterface(ClassInterfaceType.None)]
	[DebuggerDisplay("CheckBox:Group={GroupName} , Checked={Checked}")]
	[XmlType("XTextCheckBox")]
	[ToolboxBitmap(typeof(XTextCheckBoxElementBase))]
	[ComClass("00012345-6789-ABCD-EF01-23456789004E", "B66A5465-A0A1-4766-BEB8-2C42080D1916")]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-23456789004E")]
	[ComDefaultInterface(typeof(IXTextCheckBoxElement))]
	[DocumentComment]
	public sealed class XTextCheckBoxElement : XTextCheckBoxElementBase, IXTextCheckBoxElement
	{
		internal const string string_17 = "00012345-6789-ABCD-EF01-23456789004E";

		internal const string string_18 = "B66A5465-A0A1-4766-BEB8-2C42080D1916";

		
		public override string DomDisplayName => "CheckBox:" + base.ID;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		
		public override string ElementIDPrefix => "chk";

		/// <summary>
		///       控件类型
		///       </summary>
		
		[XmlElement]
		[Browsable(false)]
		[DefaultValue(CheckBoxControlStyle.CheckBox)]
		public override CheckBoxControlStyle ControlStyle
		{
			get
			{
				return base.ControlStyle;
			}
			set
			{
				base.ControlStyle = value;
			}
		}

		
		public override void vmethod_29(object sender, ContentChangedEventArgs e)
		{
			int num = 4;
			base.vmethod_29(sender, e);
			if (OwnerDocument.ExpressionExecuter != null && XTextDocument.smethod_13(GEnum6.const_188))
			{
				OwnerDocument.ExpressionExecuter.imethod_1(this, base.EventExpressions, "ContentChanged", e.LoadingDocument);
			}
		}
	}
}
