using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;

namespace DCSoftDotfuscate
{
    public class GClass54 : GClass53
    {
        private XTextElement xtextElement_0;

        public GClass54(string string_3, XTextElement xtextElement_1, GClass39 gclass39_0) : base(string_3)
        {
            int num = 12;
            xtextElement_0 = null;
            //base._002Ector(string_3);
            if (xtextElement_1 == null)
            {
                throw new ArgumentNullException("element");
            }
            xtextElement_0 = xtextElement_1;
            gdelegate2_1 = method_17;
            Class77 idictionary_ = new Class77(xtextElement_0.OwnerDocument, xtextElement_0, gclass39_0);
            method_10(idictionary_);
        }

        public override object vmethod_1()
        {
            if (!XTextDocument.smethod_13(GEnum6.const_125))
            {
                return null;
            }
            return base.vmethod_1();
        }

        public string method_16()
        {
            Class77 @class = method_9() as Class77;
            if (@class == null)
            {
                return "";
            }
            return @class.method_6();
        }

        private void method_17(string string_3, GEventArgs1 geventArgs1_0)
        {
            WriterControl writerControl = xtextElement_0.WriterControl;
            if (writerControl != null)
            {
                WriterExpressionFunctionEventArgs writerExpressionFunctionEventArgs = new WriterExpressionFunctionEventArgs(writerControl, xtextElement_0.OwnerDocument, xtextElement_0, string_3, geventArgs1_0.method_4());
                writerControl.method_58(writerExpressionFunctionEventArgs);
                if (writerExpressionFunctionEventArgs.Handled)
                {
                    geventArgs1_0.method_1(writerExpressionFunctionEventArgs.Result);
                    geventArgs1_0.method_3(bool_1: true);
                    return;
                }
            }
            WriterExpressionFunctionEventArgs writerExpressionFunctionEventArgs2 = new WriterExpressionFunctionEventArgs(xtextElement_0.WriterControl, xtextElement_0.OwnerDocument, xtextElement_0, string_3, geventArgs1_0.method_4());
            xtextElement_0.OwnerDocument.method_26(writerExpressionFunctionEventArgs2);
            if (writerExpressionFunctionEventArgs2.Handled)
            {
                geventArgs1_0.method_1(writerExpressionFunctionEventArgs2.Result);
                geventArgs1_0.method_3(bool_1: true);
            }
        }
    }
}
