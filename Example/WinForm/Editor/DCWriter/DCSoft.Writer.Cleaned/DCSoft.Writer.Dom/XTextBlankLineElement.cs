using DCSoft.Common;
using DCSoft.WinForms;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       空白行元素
	///       </summary>
	/// <remarks>
	///       本元素用于在文档中创建一个空白文档行，而且该文档行的高度不受段落行间距和段落间距的影响。
	///       </remarks>
	[DocumentComment]
	[DCPublishAPI]
	[XmlType("BlankLine")]
	public class XTextBlankLineElement : XTextObjectElement
	{
		/// <summary>
		///       对象大小修改样式
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override ResizeableType Resizeable
		{
			get
			{
				return ResizeableType.Height;
			}
			set
			{
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[XmlElement]
		[DefaultValue(100f)]
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
		///       初始化对象
		///       </summary>
		public XTextBlankLineElement()
		{
			Height = 100f;
		}
	}
}
