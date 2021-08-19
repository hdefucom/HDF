using System.Drawing;
using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class ImageEditControl : UserControl
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 512;
				return createParams;
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			Point autoScrollPosition = base.AutoScrollPosition;
			autoScrollPosition.X = -autoScrollPosition.X;
			autoScrollPosition.Y = -autoScrollPosition.Y - e.Delta;
			base.AutoScrollPosition = autoScrollPosition;
			base.OnMouseWheel(e);
		}
	}
}
