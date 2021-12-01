using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
    public class XPaperSizeCollection : System.Collections.CollectionBase
    {
        private static XPaperSizeCollection myStdInstance = null;
        public static XPaperSizeCollection StdInstance
        {
            get
            {
                //System.Console.WriteLine
                if (myStdInstance == null)
                {
                    myStdInstance = new XPaperSizeCollection();
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A2, 1654, 2339); 	//A2 纸（420 毫米 × 594 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A3, 1169, 1654); 	//A3 纸（297 毫米 × 420 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A3Extra, 1268, 1752); 	//A3 extra 纸（322 毫米 × 445 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A3ExtraTransverse, 1268, 1752); 	//A3 extra transverse 纸（322 毫米 × 445 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A3Rotated, 1654, 1169); 	//A3 rotated 纸（420 毫米 × 297 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A3Transverse, 1169, 1654); 	//A3 transverse 纸（297 毫米 × 420 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A4, /*827*/ 790, 1169); 	//A4 纸（210 毫米 × 297 毫米）。//Modified by wwj 2012-02-21 解决使用A4纸打印时出现偏移的情况
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A4Extra, 929, 1268); 	//A4 extra 纸（236 毫米 × 322 毫米）。该值是针对 PostScript 驱动程序的，仅供 Linotronic 打印机使用以节省纸张。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A4Plus, 827, 1299); 	//A4 plus 纸（210 毫米 × 330 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A4Rotated, 1169, 827); 	//A4 rotated 纸（297 毫米 × 210 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A4Small, 827, 1169); 	//A4 small 纸（210 毫米 × 297 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A4Transverse, 827, 1169); 	//A4 transverse 纸（210 毫米 × 297 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A5, 583, 827); 	//A5 纸（148 毫米 × 210 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A5Extra, 685, 925); 	//A5 extra 纸（174 毫米 × 235 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A5Rotated, 827, 583); 	//A5 rotated 纸（210 毫米 × 148 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A5Transverse, 583, 827); 	//A5 transverse 纸（148 毫米 × 210 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A6, 413, 583); 	//A6 纸（105 毫米 × 148 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.A6Rotated, 583, 413); 	//A6 rotated 纸（148 毫米 × 105 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.APlus, 894, 1402); 	//SuperA/SuperA/A4 纸（227 毫米 × 356 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B4, 984, 1390); 	//B4 纸（250 × 353 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B4Envelope, 984, 1390); 	//B4 信封（250 × 353 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B5, 693, 984); 	//B5 纸（176 毫米 × 250 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B5Envelope, 693, 984); 	//B5 信封（176 毫米 × 250 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B5Extra, 791, 1087); 	//ISO B5 extra 纸（201 毫米 × 276 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B5JisRotated, 1012, 717); 	//JIS B5 rotated 纸（257 毫米 × 182 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B5Transverse, 717, 1012); 	//JIS B5 transverse 纸（182 毫米 × 257 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B6Envelope, 693, 492); 	//B6 信封（176 毫米 × 125 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.B6Jis, 504, 717); 	//JIS B6 纸（128 毫米 × 182 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.BPlus, 1201, 1917); 	//SuperB/SuperB/A3 纸（305 毫米 × 487 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.C3Envelope, 1201, 1917); 	//SuperB/SuperB/A3 纸（305 毫米 × 487 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.C4Envelope, 902, 1276); 	//C4 信封（229 毫米 × 324 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.C5Envelope, 638, 902); 	//C5 信封（162 毫米 × 229 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.C65Envelope, 449, 902); 	//C65 信封（114 毫米 × 229 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.C6Envelope, 449, 638); 	//C6 信封（114 毫米 × 162 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.CSheet, 449, 638); 	//C6 信封（114 毫米 × 162 毫米）。 

                    //Modified By wwj 2011-12-01 由于使用16k的纸张，在系统PagerSize枚举中没有16K的，所以默认选中自定义的选线
                    //myStdInstance.Add(System.Drawing.Printing.PaperKind.Custom, 776, 1068); // 自定义大小
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Custom, 776, 1035); 	//自定义大小（192 毫米 × 265 毫米）。

                    myStdInstance.Add(System.Drawing.Printing.PaperKind.DLEnvelope, 433, 866); 	//DL 信封（110 毫米 × 220 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.DSheet, 2201, 3402); 	//D 纸（559 毫米 × 864 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.ESheet, 3402, 4402); 	//E 纸（864 毫米 × 1118 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Executive, 724, 1051); 	//Executive 纸（184 毫米 × 267 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Folio, 850, 1299); 	//Folio 纸（216 毫米 × 330 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.GermanLegalFanfold, 850, 1299); 	//German legal fanfold（216 毫米 × 330 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.GermanStandardFanfold, 850, 1201); 	//German standard fanfold（216 毫米 × 305 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.InviteEnvelope, 866, 866); 	//Invite envelope（220 毫米 × 220 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.IsoB4, 984, 1390); 	//ISO B4（250 毫米 × 353 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.ItalyEnvelope, 433, 906); 	//Italy envelope（110 毫米 × 230 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.JapaneseDoublePostcard, 787, 583); 	//Japanese double postcard（200 毫米 × 148 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.JapaneseDoublePostcardRotated, 583, 787); 	//Japanese rotated double postcard（148 毫米 × 200 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.JapanesePostcard, 394, 583); 	//Japanese postcard（100 毫米 × 148 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.JapanesePostcardRotated, 583, 394); 	//Japanese rotated postcard（148 毫米 × 100 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Ledger, 1701, 1098); 	//Ledger 纸（432 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Legal, 850, 1402); 	//Legal 纸（216 × 356 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.LegalExtra, 929, 1500); 	//Legal extra 纸（236 毫米 × 381 毫米）。该值特定于 PostScript 驱动程序，仅供 Linotronic 打印机使用以节省纸张。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Letter, 850, 1098); 	//Letter 纸（216 毫米 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.LetterExtra, 929, 1197); 	//Letter extra 纸（236 毫米 × 304 毫米）。该值特定于 PostScript 驱动程序，仅供 Linotronic 打印机使用以节省纸张。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.LetterExtraTransverse, 929, 1201); 	//Letter extra transverse 纸（236 毫米 × 305 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.LetterPlus, 850, 1268); 	//Letter plus 纸（216 毫米 毫米 × 322 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.LetterRotated, 1098, 850); 	//Letter rotated 纸（279 毫米 × 216 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.LetterSmall, 850, 1098); 	//Letter small 纸（216 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.LetterTransverse, 827, 1098); 	//Letter transverse 纸（210 毫米 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.MonarchEnvelope, 386, 752); 	//Monarch envelope（98 毫米 × 191 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Note, 850, 1098); 	//Note 纸（216 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Number10Envelope, 413, 949); 	//#10 envelope（105 × 241 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PersonalEnvelope, 362, 650); 	//6 3/4 envelope（92 毫米 × 165 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Prc16K, 575, 846); 	//PRC 16K 纸（146 × 215 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Prc16KRotated, 575, 846); 	//PRC 16K rotated 纸（146 × 215 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Prc32K, 382, 594); 	//PRC 32K 纸（97 × 151 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Prc32KBig, 382, 594); 	//PRC 32K(Big) 纸（97 × 151 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Prc32KBigRotated, 382, 594); 	//PRC 32K rotated 纸（97 × 151 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Prc32KRotated, 382, 594); 	//PRC 32K rotated 纸（97 × 151 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber1, 402, 650); 	//PRC #1 envelope（102 × 165 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber10, 1276, 1803); 	//PRC #10 envelope（324 × 458 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber10Rotated, 1803, 1276); 	//PRC #10 rotated envelope（458 × 324 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber1Rotated, 650, 402); 	//PRC #1 rotated envelope（165 × 102 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber2, 402, 693); 	//PRC #2 envelope（102 × 176 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber2Rotated, 693, 402); 	//PRC #2 rotated envelope（176 × 102 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber3, 492, 693); 	//PRC #3 envelope（125 × 176 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber3Rotated, 693, 492); 	//PRC #3 rotated envelope（176 × 125 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber4, 433, 819); 	//PRC #4 envelope（110 × 208 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber4Rotated, 819, 433); 	//PRC #4 rotated envelope（208 × 110 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber5, 433, 866); 	//PRC #5 envelope（110 × 220 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber5Rotated, 866, 433); 	//PRC #5 rotated envelope（220 × 110 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber6, 472, 906); 	//PRC #6 envelope（120 × 230 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber6Rotated, 906, 472); 	//PRC #6 rotated envelope（230 × 120 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber7, 630, 906); 	//PRC #7 envelope（160 × 230 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber7Rotated, 906, 630); 	//PRC #7 rotated envelope（230 × 160 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber8, 472, 1217); 	//PRC #8 envelope（120 × 309 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber8Rotated, 1217, 472); 	//PRC #8 rotated envelope（309 × 120 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber9, 902, 1276); 	//PRC #9 envelope（229 × 324 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.PrcEnvelopeNumber9Rotated, 902, 1276); 	//PRC #9 rotated envelope（229 × 324 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Quarto, 846, 1083); 	//Quarto 纸（215 毫米 × 275 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Standard10x11, 1000, 1098); 	//Standard 纸（254 毫米 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Standard10x14, 1000, 1402); 	//Standard 纸（254 毫米 × 356 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Standard11x17, 1098, 1701); 	//Standard 纸（279 毫米 × 432 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Standard12x11, 1201, 1098); 	//Standard 纸（305 × 279 毫米）。需要 Windows 98、Windows NT 4.0 或更高版本。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Standard15x11, 1500, 1098); 	//Standard 纸（381 毫米 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Standard9x11, 902, 1098); 	//Standard 纸（229 × 279 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Statement, 551, 850); 	//Statement 纸（140 毫米 × 216 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.Tabloid, 1098, 1701); 	//Tabloid 纸（279 毫米 × 432 毫米）。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.TabloidExtra, 1169, 1799); 	//Tabloid extra 纸（297 毫米 × 457 毫米）。该值特定于 PostScript 驱动程序，仅供 Linotronic 打印机使用以节省纸张。
                    myStdInstance.Add(System.Drawing.Printing.PaperKind.USStandardFanfold, 1488, 1098); 	//US standard fanfold（378 毫米 × 279 毫米）。
                }
                return myStdInstance;
            }
        }
        public XPaperSize this[int index]
        {
            get { return (XPaperSize)this.List[index]; }
        }
        public XPaperSize this[System.Drawing.Printing.PaperKind vKind]
        {
            get
            {
                foreach (XPaperSize size in this.List)
                {
                    if (size.Kind == vKind)
                    {
                        return size;
                    }
                }
                return null;
            }
        }
        public void Add(XPaperSize size)
        {
            this.List.Add(size);
        }
        public XPaperSize Add(System.Drawing.Printing.PaperKind vKind, int vWidth, int vHeight)
        {
            XPaperSize size = new XPaperSize(vKind, vWidth, vHeight);
            this.List.Add(size);
            return size;
        }
        public void Add(System.Drawing.Printing.PrinterSettings settings)
        {
            foreach (System.Drawing.Printing.PaperSize size in settings.PaperSizes)
            {
                XPaperSize size2 = new XPaperSize(size.Kind, size.Width, size.Height);
                this.List.Add(size2);
            }
        }
        public XPaperSize[] ToArray()
        {
            return (XPaperSize[])this.InnerList.ToArray(typeof(XPaperSize));
        }

    }//public class XPaperSizeCollection : System.Collections.CollectionBase 
}
