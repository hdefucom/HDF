using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>DataSourceDescriptor 的COM接口</summary>
	[Guid("80071BC8-41E7-4413-A17E-3B18FF1C02AC")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IDataSourceDescriptor
	{
		/// <summary>属性BackgroundText</summary>
		[DispId(4)]
		string BackgroundText
		{
			get;
			set;
		}

		/// <summary>属性ChildDescriptors</summary>
		[DispId(5)]
		DataSourceDescriptorList ChildDescriptors
		{
			get;
			set;
		}

		/// <summary>属性Description</summary>
		[DispId(6)]
		string Description
		{
			get;
			set;
		}

		/// <summary>属性DisplayFormat</summary>
		[DispId(7)]
		ValueFormater DisplayFormat
		{
			get;
			set;
		}

		/// <summary>属性EditStyle</summary>
		[DispId(8)]
		InputFieldEditStyle EditStyle
		{
			get;
			set;
		}

		/// <summary>属性ElementType</summary>
		[DispId(9)]
		DocumentElementType ElementType
		{
			get;
			set;
		}

		/// <summary>属性ListSource</summary>
		[DispId(10)]
		ListSourceInfo ListSource
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(11)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(12)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(13)]
		string TypeName
		{
			get;
			set;
		}

		/// <summary>属性UserEditable</summary>
		[DispId(14)]
		bool UserEditable
		{
			get;
			set;
		}

		/// <summary>属性ValidateStyle</summary>
		[DispId(15)]
		ValueValidateStyle ValidateStyle
		{
			get;
			set;
		}

		/// <summary>属性ValueBinding</summary>
		[DispId(16)]
		XDataBinding ValueBinding
		{
			get;
			set;
		}

		/// <summary>方法Load</summary>
		[DispId(2)]
		void Load(string fileName);

		/// <summary>方法Save</summary>
		[DispId(3)]
		void Save(string fileName);
	}
}
