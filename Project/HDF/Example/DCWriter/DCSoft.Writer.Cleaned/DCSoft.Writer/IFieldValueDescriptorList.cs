using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>FieldValueDescriptorList 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("BA509B64-EFC1-461C-B61A-6AACADA7D836")]
	public interface IFieldValueDescriptorList
	{
		/// <summary>属性Count</summary>
		[DispId(2)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(3)]
		FieldValueDescriptor this[int index]
		{
			get;
			set;
		}
	}
}
