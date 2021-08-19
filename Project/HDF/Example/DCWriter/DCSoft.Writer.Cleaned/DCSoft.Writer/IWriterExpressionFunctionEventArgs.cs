using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterExpressionFunctionEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("92FB3A91-1D68-4200-8AA8-B399F5070341")]
	[Browsable(false)]
	public interface IWriterExpressionFunctionEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性FunctionName</summary>
		[DispId(5)]
		string FunctionName
		{
			get;
		}

		/// <summary>属性Handled</summary>
		[DispId(6)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性ParametersCount</summary>
		[DispId(7)]
		int ParametersCount
		{
			get;
		}

		/// <summary>属性ParameterString1</summary>
		[DispId(8)]
		string ParameterString1
		{
			get;
		}

		/// <summary>属性ParameterString2</summary>
		[DispId(9)]
		string ParameterString2
		{
			get;
		}

		/// <summary>属性ParameterString3</summary>
		[DispId(10)]
		string ParameterString3
		{
			get;
		}

		/// <summary>属性ParameterString4</summary>
		[DispId(11)]
		string ParameterString4
		{
			get;
		}

		/// <summary>属性ResultString</summary>
		[DispId(12)]
		object ResultString
		{
			get;
			set;
		}

		/// <summary>方法GetParameterStringValue</summary>
		[DispId(2)]
		string GetParameterStringValue(int index);

		/// <summary>方法GetParameterValue</summary>
		[DispId(13)]
		object GetParameterValue(int index);
	}
}
