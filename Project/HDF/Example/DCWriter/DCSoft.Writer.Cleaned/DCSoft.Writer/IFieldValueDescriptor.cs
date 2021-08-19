using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>FieldValueDescriptor 的COM接口</summary>
	[Guid("D59EE5C4-1077-4C31-B53D-1D39D479500A")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IFieldValueDescriptor
	{
		/// <summary>属性BindingPath</summary>
		[DispId(2)]
		string BindingPath
		{
			get;
			set;
		}

		/// <summary>属性DataSource</summary>
		[DispId(3)]
		string DataSource
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(5)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(6)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(7)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(8)]
		string Value
		{
			get;
			set;
		}
	}
}
