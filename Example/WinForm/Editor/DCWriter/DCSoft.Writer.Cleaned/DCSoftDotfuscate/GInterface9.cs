using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ComVisible(false)]
	public interface GInterface9
	{
		GClass543 imethod_0();

		void imethod_1(GClass543 gclass543_0);

		void imethod_2();

		bool imethod_3(DCGraphics dcgraphics_0);

		bool imethod_4(int int_0);

		[EditorBrowsable(EditorBrowsableState.Never)]
		bool imethod_5(DocumentCommentList documentCommentList_0, DocumentCommentList documentCommentList_1);

		bool imethod_6(bool bool_0);

		void imethod_7(DCGraphics dcgraphics_0, RectangleF rectangleF_0, PrintPage printPage_0, bool bool_0);

		Color imethod_8(DocumentComment documentComment_0);

		DocumentComment imethod_9();

		void imethod_10(DocumentComment documentComment_0);
	}
}
