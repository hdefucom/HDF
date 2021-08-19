using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.MedicalExpression
{
	/// <summary>MedicalExpressionValueList 的COM接口</summary>
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("4043911F-3EB5-41F1-B26B-AE33AD6CBC2B")]
	public interface IMedicalExpressionValueList
	{
		/// <summary>属性Count</summary>
		[DispId(5)]
		int Count
		{
			get;
		}

		/// <summary>方法Clear</summary>
		[DispId(2)]
		void Clear();

		/// <summary>方法GetValue</summary>
		[DispId(3)]
		string GetValue(string name);

		/// <summary>方法SetValue</summary>
		[DispId(4)]
		bool SetValue(string name, string Value);
	}
}
