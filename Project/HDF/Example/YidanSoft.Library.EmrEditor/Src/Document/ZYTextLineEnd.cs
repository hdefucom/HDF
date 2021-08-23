using System;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
	/// <summary>
	/// ��β���,��س�.��Ȼ�ǻس�,���ǻ�������ͬһ��.
    /// ��Ӳ�س�,ֻҪ�ǻس���,�ͻ�����һ��.
    /// ��Ӧhtml�е� "br" Ԫ��
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
            //mfbע������.����������λ����.�ᵼ����س���߶ȹ���
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
