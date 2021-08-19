using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>DataSourceBindingDescription 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("1C702A9E-7C16-40DF-AC7A-E57A1002714D")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDataSourceBindingDescription
	{
		/// <summary>属性AutoUpdate</summary>
		[DispId(2)]
		bool AutoUpdate
		{
			get;
			set;
		}

		/// <summary>属性BindingPath</summary>
		[DispId(3)]
		string BindingPath
		{
			get;
			set;
		}

		/// <summary>属性DataSource</summary>
		[DispId(4)]
		string DataSource
		{
			get;
			set;
		}

		/// <summary>属性Element</summary>
		[DispId(5)]
		XTextElement Element
		{
			get;
			set;
		}

		/// <summary>属性ElementID</summary>
		[DispId(6)]
		string ElementID
		{
			get;
			set;
		}

		/// <summary>属性FormatString</summary>
		[DispId(7)]
		string FormatString
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(8)]
		bool Readonly
		{
			get;
			set;
		}
	}
}
