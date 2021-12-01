using DCSoft.Drawing;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       文档样式容器
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeContentStyleContainer : ContentStyleContainer
	{
		/// <summary>
		///       样式列表
		///       </summary>
		[XmlArrayItem("Style", typeof(ContentStyle))]
		public override ContentStyleList Styles
		{
			get
			{
				return base.Styles;
			}
			set
			{
				base.Styles = value;
			}
		}
	}
}
