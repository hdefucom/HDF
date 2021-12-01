using System.Drawing;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_InsertDiagramPic : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertdiagrampic";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			return true;
		}

		public override bool UIExecute()
		{
			using (LoadDiagramPic loadDiagramPic = new LoadDiagramPic())
			{
				loadDiagramPic.InitFormData(myOwnerDocument.DataSource.DBConn.Connection);
				if (loadDiagramPic.ShowDialog() == DialogResult.OK)
				{
					Param1 = loadDiagramPic.CurrrentSelectedImgId.ToString();
					Image currentSelectedImg = loadDiagramPic.CurrentSelectedImg;
					ZYTextImage zYTextImage = new ZYTextImage();
					zYTextImage.ImgSourceSrc = Param1;
					zYTextImage.Src = "";
					zYTextImage.ImageType = "";
					zYTextImage.Image = currentSelectedImg;
					zYTextImage.SaveInFile = true;
					if (zYTextImage.Image != null)
					{
						zYTextImage.Width = base.OwnerDocument.PixelToDocumentUnit(zYTextImage.Image.Width);
						zYTextImage.Height = base.OwnerDocument.PixelToDocumentUnit(zYTextImage.Image.Height);
					}
					myOwnerDocument._InsertElement(zYTextImage);
				}
			}
			return false;
		}
	}
}
