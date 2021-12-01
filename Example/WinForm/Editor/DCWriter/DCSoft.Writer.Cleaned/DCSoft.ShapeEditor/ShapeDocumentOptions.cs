using System;
using System.Runtime.InteropServices;

namespace DCSoft.ShapeEditor
{
	/// <summary>
	///       图形文档选项信息
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class ShapeDocumentOptions
	{
		private ShapeDocumentViewOptions shapeDocumentViewOptions_0 = new ShapeDocumentViewOptions();

		/// <summary>
		///       视图选项
		///       </summary>
		public ShapeDocumentViewOptions ViewOptions
		{
			get
			{
				if (shapeDocumentViewOptions_0 == null)
				{
					shapeDocumentViewOptions_0 = new ShapeDocumentViewOptions();
				}
				return shapeDocumentViewOptions_0;
			}
			set
			{
				shapeDocumentViewOptions_0 = value;
			}
		}
	}
}
