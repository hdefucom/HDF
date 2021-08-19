using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       表格单元格元素
	///       </summary>
	[ComVisible(false)]
	public class DomTableCellElement : DomContainerElement
	{
		private bool _TabStop = true;

		/// <summary>
		///       获取或设置一个值，该值指示用户能否使用 Tab 键将焦点放到该元素中上。 
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool TabStop
		{
			get
			{
				return _TabStop;
			}
			set
			{
				_TabStop = value;
			}
		}
	}
}
