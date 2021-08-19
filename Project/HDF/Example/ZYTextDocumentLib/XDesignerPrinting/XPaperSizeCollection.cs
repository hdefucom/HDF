using System.Collections;
using System.Drawing.Printing;

namespace XDesignerPrinting
{
	public class XPaperSizeCollection : CollectionBase
	{
		private static XPaperSizeCollection myStdInstance = null;

		public static XPaperSizeCollection StdInstance
		{
			get
			{
				if (myStdInstance == null)
				{
					myStdInstance = new XPaperSizeCollection();
					myStdInstance.Add(PaperKind.A2, 1654, 2339);
					myStdInstance.Add(PaperKind.A3, 1169, 1654);
					myStdInstance.Add(PaperKind.A3Extra, 1268, 1752);
					myStdInstance.Add(PaperKind.A3ExtraTransverse, 1268, 1752);
					myStdInstance.Add(PaperKind.A3Rotated, 1654, 1169);
					myStdInstance.Add(PaperKind.A3Transverse, 1169, 1654);
					myStdInstance.Add(PaperKind.A4, 827, 1169);
					myStdInstance.Add(PaperKind.A4Extra, 929, 1268);
					myStdInstance.Add(PaperKind.A4Plus, 827, 1299);
					myStdInstance.Add(PaperKind.A4Rotated, 1169, 827);
					myStdInstance.Add(PaperKind.A4Small, 827, 1169);
					myStdInstance.Add(PaperKind.A4Transverse, 827, 1169);
					myStdInstance.Add(PaperKind.A5, 583, 827);
					myStdInstance.Add(PaperKind.A5Extra, 685, 925);
					myStdInstance.Add(PaperKind.A5Rotated, 827, 583);
					myStdInstance.Add(PaperKind.A5Transverse, 583, 827);
					myStdInstance.Add(PaperKind.A6, 413, 583);
					myStdInstance.Add(PaperKind.A6Rotated, 583, 413);
					myStdInstance.Add(PaperKind.APlus, 894, 1402);
					myStdInstance.Add(PaperKind.B4, 984, 1390);
					myStdInstance.Add(PaperKind.B4Envelope, 984, 1390);
					myStdInstance.Add(PaperKind.B5, 693, 984);
					myStdInstance.Add(PaperKind.B5Envelope, 693, 984);
					myStdInstance.Add(PaperKind.B5Extra, 791, 1087);
					myStdInstance.Add(PaperKind.B5JisRotated, 1012, 717);
					myStdInstance.Add(PaperKind.B5Transverse, 717, 1012);
					myStdInstance.Add(PaperKind.B6Envelope, 693, 492);
					myStdInstance.Add(PaperKind.B6Jis, 504, 717);
					myStdInstance.Add(PaperKind.BPlus, 1201, 1917);
					myStdInstance.Add(PaperKind.C3Envelope, 1201, 1917);
					myStdInstance.Add(PaperKind.C4Envelope, 902, 1276);
					myStdInstance.Add(PaperKind.C5Envelope, 638, 902);
					myStdInstance.Add(PaperKind.C65Envelope, 449, 902);
					myStdInstance.Add(PaperKind.C6Envelope, 449, 638);
					myStdInstance.Add(PaperKind.CSheet, 449, 638);
					myStdInstance.Add(PaperKind.Custom, 776, 1068);
					myStdInstance.Add(PaperKind.DLEnvelope, 433, 866);
					myStdInstance.Add(PaperKind.DSheet, 2201, 3402);
					myStdInstance.Add(PaperKind.ESheet, 3402, 4402);
					myStdInstance.Add(PaperKind.Executive, 724, 1051);
					myStdInstance.Add(PaperKind.Folio, 850, 1299);
					myStdInstance.Add(PaperKind.GermanLegalFanfold, 850, 1299);
					myStdInstance.Add(PaperKind.GermanStandardFanfold, 850, 1201);
					myStdInstance.Add(PaperKind.InviteEnvelope, 866, 866);
					myStdInstance.Add(PaperKind.IsoB4, 984, 1390);
					myStdInstance.Add(PaperKind.ItalyEnvelope, 433, 906);
					myStdInstance.Add(PaperKind.JapaneseDoublePostcard, 787, 583);
					myStdInstance.Add(PaperKind.JapaneseDoublePostcardRotated, 583, 787);
					myStdInstance.Add(PaperKind.JapanesePostcard, 394, 583);
					myStdInstance.Add(PaperKind.JapanesePostcardRotated, 583, 394);
					myStdInstance.Add(PaperKind.Ledger, 1701, 1098);
					myStdInstance.Add(PaperKind.Legal, 850, 1402);
					myStdInstance.Add(PaperKind.LegalExtra, 929, 1500);
					myStdInstance.Add(PaperKind.Letter, 850, 1098);
					myStdInstance.Add(PaperKind.LetterExtra, 929, 1197);
					myStdInstance.Add(PaperKind.LetterExtraTransverse, 929, 1201);
					myStdInstance.Add(PaperKind.LetterPlus, 850, 1268);
					myStdInstance.Add(PaperKind.LetterRotated, 1098, 850);
					myStdInstance.Add(PaperKind.LetterSmall, 850, 1098);
					myStdInstance.Add(PaperKind.LetterTransverse, 827, 1098);
					myStdInstance.Add(PaperKind.MonarchEnvelope, 386, 752);
					myStdInstance.Add(PaperKind.Note, 850, 1098);
					myStdInstance.Add(PaperKind.Number10Envelope, 413, 949);
					myStdInstance.Add(PaperKind.PersonalEnvelope, 362, 650);
					myStdInstance.Add(PaperKind.Prc16K, 575, 846);
					myStdInstance.Add(PaperKind.Prc16KRotated, 575, 846);
					myStdInstance.Add(PaperKind.Prc32K, 382, 594);
					myStdInstance.Add(PaperKind.Prc32KBig, 382, 594);
					myStdInstance.Add(PaperKind.Prc32KBigRotated, 382, 594);
					myStdInstance.Add(PaperKind.Prc32KRotated, 382, 594);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber1, 402, 650);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber10, 1276, 1803);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber10Rotated, 1803, 1276);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber1Rotated, 650, 402);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber2, 402, 693);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber2Rotated, 693, 402);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber3, 492, 693);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber3Rotated, 693, 492);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber4, 433, 819);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber4Rotated, 819, 433);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber5, 433, 866);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber5Rotated, 866, 433);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber6, 472, 906);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber6Rotated, 906, 472);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber7, 630, 906);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber7Rotated, 906, 630);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber8, 472, 1217);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber8Rotated, 1217, 472);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber9, 902, 1276);
					myStdInstance.Add(PaperKind.PrcEnvelopeNumber9Rotated, 902, 1276);
					myStdInstance.Add(PaperKind.Quarto, 846, 1083);
					myStdInstance.Add(PaperKind.Standard10x11, 1000, 1098);
					myStdInstance.Add(PaperKind.Standard10x14, 1000, 1402);
					myStdInstance.Add(PaperKind.Standard11x17, 1098, 1701);
					myStdInstance.Add(PaperKind.Standard12x11, 1201, 1098);
					myStdInstance.Add(PaperKind.Standard15x11, 1500, 1098);
					myStdInstance.Add(PaperKind.Standard9x11, 902, 1098);
					myStdInstance.Add(PaperKind.Statement, 551, 850);
					myStdInstance.Add(PaperKind.Tabloid, 1098, 1701);
					myStdInstance.Add(PaperKind.TabloidExtra, 1169, 1799);
					myStdInstance.Add(PaperKind.USStandardFanfold, 1488, 1098);
				}
				return myStdInstance;
			}
		}

		public XPaperSize this[int index] => (XPaperSize)base.List[index];

		public XPaperSize this[PaperKind vKind]
		{
			get
			{
				foreach (XPaperSize item in base.List)
				{
					if (item.Kind == vKind)
					{
						return item;
					}
				}
				return null;
			}
		}

		public void Add(XPaperSize size)
		{
			base.List.Add(size);
		}

		public XPaperSize Add(PaperKind vKind, int vWidth, int vHeight)
		{
			XPaperSize xPaperSize = new XPaperSize(vKind, vWidth, vHeight);
			base.List.Add(xPaperSize);
			return xPaperSize;
		}

		public void Add(PrinterSettings settings)
		{
			foreach (PaperSize paperSize in settings.PaperSizes)
			{
				XPaperSize value = new XPaperSize(paperSize.Kind, paperSize.Width, paperSize.Height);
				base.List.Add(value);
			}
		}

		public XPaperSize[] ToArray()
		{
			return (XPaperSize[])base.InnerList.ToArray(typeof(XPaperSize));
		}
	}
}
