using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;

namespace DCSoftDotfuscate
{
	internal class Class115
	{
		private XTextDocument xtextDocument_0;

		private Enum10 enum10_0;

		public Class115(XTextDocument xtextDocument_1)
		{
			int num = 6;
			xtextDocument_0 = null;
			enum10_0 = Enum10.const_0;
			
			if (xtextDocument_1 == null)
			{
				throw new ArgumentNullException("document");
			}
			xtextDocument_0 = xtextDocument_1;
		}

		public void method_0()
		{
			enum10_0 = Enum10.const_0;
			if (xtextDocument_0.WriterControl != null)
			{
				xtextDocument_0.WriterControl.method_60();
			}
		}

		internal bool method_1()
		{
			WriterControl writerControl = xtextDocument_0.WriterControl;
			if (!(writerControl?.IsDisposed ?? false))
			{
				return true;
			}
			if (writerControl.BackgroundMode)
			{
				return true;
			}
			if (!writerControl.EnableUIEventStartEditContent)
			{
				return true;
			}
			if (enum10_0 == Enum10.const_3)
			{
				return true;
			}
			if (enum10_0 == Enum10.const_1)
			{
				return false;
			}
			if (enum10_0 == Enum10.const_2 || enum10_0 == Enum10.const_0)
			{
				WriterStartEditEventArgs writerStartEditEventArgs = new WriterStartEditEventArgs(writerControl, xtextDocument_0);
				writerControl.OnEventUIStartEditContent(writerStartEditEventArgs);
				if (writerStartEditEventArgs.Readonly)
				{
					if (writerStartEditEventArgs.CanDetectAgain)
					{
						enum10_0 = Enum10.const_2;
					}
					else
					{
						enum10_0 = Enum10.const_1;
					}
					return false;
				}
				enum10_0 = Enum10.const_3;
				if (!writerStartEditEventArgs.ReloadDocument)
				{
				}
				return true;
			}
			return true;
		}
	}
}
