using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>XDataBinding 的COM接口</summary>
	[Guid("D862B3A3-5160-4386-8EB6-1A58A2A3D1C0")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IXDataBinding
	{
		/// <summary>属性AutoUpdate</summary>
		[DispId(7)]
		bool AutoUpdate
		{
			get;
			set;
		}

		/// <summary>属性BindingPath</summary>
		[DispId(2)]
		string BindingPath
		{
			get;
			set;
		}

		/// <summary>属性BindingPathForText</summary>
		[DispId(12)]
		string BindingPathForText
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

		/// <summary>属性Enabled</summary>
		[DispId(10)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性FormatString</summary>
		[DispId(4)]
		string FormatString
		{
			get;
			set;
		}

		/// <summary>属性IsEmptyBinding</summary>
		[DispId(5)]
		bool IsEmptyBinding
		{
			get;
		}

		/// <summary>属性ProcessState</summary>
		[DispId(8)]
		DCProcessStates ProcessState
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(6)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性ValueBindingPath</summary>
		[DispId(9)]
		string ValueBindingPath
		{
			get;
			set;
		}

		/// <summary>属性WriteTextBindingPath</summary>
		[DispId(11)]
		string WriteTextBindingPath
		{
			get;
			set;
		}
	}
}
