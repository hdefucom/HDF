using System;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// 行尾标记,软回车.虽然是回车,但是还是属于同一段.
    /// 而硬回车,只要是回车了,就会另起一段.
    /// 对应html中的 "br" 元素
	/// </summary>
	public class ZYTextLineEnd : ZYTextElement
	{
		public override bool CanBeLineHead()
		{
			return false;
		}
		public override bool isNewLine()
		{
			return true;
		}
		public override string GetXMLName()
		{
			return ZYTextConst.c_Br ;
		}
		
		public override bool RefreshSize()
		{
			intWidth = myOwnerDocument.PixelToDocumentUnit( 11 );
            //mfb注释修正.如果用这个单位不对.会导致软回车后高度过高
			//intHeight = myOwnerDocument.PixelToDocumentUnit( myOwnerDocument.DefaultRowHeight  ); 
            intHeight = myOwnerDocument.DefaultRowHeight;
			return true;
		}
		public override string ToEMRString()
		{
			return "\r\n";
		}

		public override bool RefreshView()
		{
			if( myOwnerDocument.Info.Printing )
				return true ;

			if( myOwnerDocument.Info.ShowParagraphFlag )
				myOwnerDocument.View.DrawLineFlag(
					this.RealLeft , 
					this.RealTop + this.Height ,
					GraphicsUnitConvert.GetRate( myOwnerDocument.DocumentGraphicsUnit , System.Drawing.GraphicsUnit.Pixel ));
			return true;
		}
	}
}
