using DCSoft.WinForms.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxDCCardListViewControl 的COM接口</summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("4AA75334-A12F-4529-9CBE-A2C3E82F298E")]
	[ComVisible(true)]
	public interface IAxDCCardListViewControl
	{
		/// <summary>属性BackColor</summary>
		[DispId(-501)]
		Color BackColor
		{
			get;
			set;
		}

		/// <summary>属性BlinkTimerInterval</summary>
		[DispId(12)]
		int BlinkTimerInterval
		{
			get;
			set;
		}

		/// <summary>属性CardBackColor</summary>
		[DispId(13)]
		Color CardBackColor
		{
			get;
			set;
		}

		/// <summary>属性CardBorderColor</summary>
		[DispId(14)]
		Color CardBorderColor
		{
			get;
			set;
		}

		/// <summary>属性CardBorderWith</summary>
		[DispId(15)]
		int CardBorderWith
		{
			get;
			set;
		}

		/// <summary>属性CardHeight</summary>
		[DispId(16)]
		int CardHeight
		{
			get;
			set;
		}

		/// <summary>属性CardLineSpacing</summary>
		[DispId(17)]
		int CardLineSpacing
		{
			get;
			set;
		}

		/// <summary>属性CardRoundRadio</summary>
		[DispId(18)]
		int CardRoundRadio
		{
			get;
			set;
		}

		/// <summary>属性CardSpacing</summary>
		[DispId(19)]
		int CardSpacing
		{
			get;
			set;
		}

		/// <summary>属性CardTemplateConfigXml</summary>
		[DispId(21)]
		string CardTemplateConfigXml
		{
			get;
			set;
		}

		/// <summary>属性CardWidth</summary>
		[DispId(22)]
		int CardWidth
		{
			get;
			set;
		}

		/// <summary>属性EnableSupperTooltip</summary>
		[DispId(23)]
		bool EnableSupperTooltip
		{
			get;
			set;
		}

		/// <summary>属性ImageAnimateInterval</summary>
		[DispId(24)]
		int ImageAnimateInterval
		{
			get;
			set;
		}

		/// <summary>属性Items</summary>
		[DispId(25)]
		DCCardListViewItemCollection Items
		{
			get;
			set;
		}

		/// <summary>属性JustifySpacing</summary>
		[DispId(26)]
		bool JustifySpacing
		{
			get;
			set;
		}

		/// <summary>属性MouseHoverItem</summary>
		[DispId(27)]
		DCCardListViewItem MouseHoverItem
		{
			get;
		}

		/// <summary>属性SelectedCardBackColor</summary>
		[DispId(28)]
		Color SelectedCardBackColor
		{
			get;
			set;
		}

		/// <summary>属性ShowCardShade</summary>
		[DispId(29)]
		bool ShowCardShade
		{
			get;
			set;
		}

		/// <summary>属性TooltipHeight</summary>
		[DispId(31)]
		int TooltipHeight
		{
			get;
			set;
		}

		/// <summary>属性TooltipWidth</summary>
		[DispId(32)]
		int TooltipWidth
		{
			get;
			set;
		}

		/// <summary>方法AddNewItem</summary>
		[DispId(3)]
		int AddNewItem();

		/// <summary>方法Clear</summary>
		[DispId(4)]
		void Clear();

		/// <summary>方法ComDispose</summary>
		[DispId(5)]
		void ComDispose();

		/// <summary>方法EditCardTemplateConfigXml</summary>
		[DispId(35)]
		bool EditCardTemplateConfigXml();

		/// <summary>方法InvalidateItemByIndex</summary>
		[DispId(6)]
		void InvalidateItemByIndex(int itemIndex);

		/// <summary>方法RefreshView</summary>
		[DispId(7)]
		void RefreshView();

		/// <summary>方法SetListItemBlink</summary>
		[DispId(8)]
		void SetListItemBlink(int itemIndex, bool blink);

		/// <summary>方法SetListItemHighlight</summary>
		[DispId(9)]
		void SetListItemHighlight(int itemIndex, bool highlight);

		/// <summary>方法SetListItemImageValueByBase64String</summary>
		[DispId(33)]
		void SetListItemImageValueByBase64String(int itemIndex, string dataFieldName, string base64String);

		/// <summary>方法SetListItemImageValueByFileName</summary>
		[DispId(10)]
		void SetListItemImageValueByFileName(int itemIndex, string dataFieldName, string fileName);

		/// <summary>方法SetListItemStringValue</summary>
		[DispId(11)]
		void SetListItemStringValue(int itemIndex, string dataFieldName, string textValue);
	}
}
