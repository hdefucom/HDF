using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public class CellEOF : ZYTextEOF
    {
        public override string GetXMLName()
        {
            return ZYTextConst.c_PEOF;
        }

        public override bool CanBeLineHead()
        {
            return true;
        }
        public override bool isNewLine()
        {
            return true;
        }
        public override bool isNewParagraph()
        {
            return true;
        }
    }
}
