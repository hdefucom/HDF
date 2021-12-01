using System.Windows.Forms;

namespace ZYTextDocumentLib
{
	public class A_InsertImage : ZYEditorAction
	{
		public override string ActionName()
		{
			return "insertimage";
		}

		public override bool isEnable()
		{
			return myOwnerDocument.CanModify();
		}

		public override bool Execute()
		{
			ZYTextImage zYTextImage = new ZYTextImage();
			zYTextImage.Src = Param1;
			zYTextImage.ImageType = Param2;
			zYTextImage.Image = ZYTextConst.ImageFromURL(Param1);
			zYTextImage.SaveInFile = true;
			if (zYTextImage.Image != null)
			{
				zYTextImage.Width = base.OwnerDocument.PixelToDocumentUnit(zYTextImage.Image.Width);
				zYTextImage.Height = base.OwnerDocument.PixelToDocumentUnit(zYTextImage.Image.Height);
			}
			myOwnerDocument._InsertElement(zYTextImage);
			return true;
		}

		public override bool UIExecute()
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "图像文件 (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|所有文件 (*.*)|*.*";
				openFileDialog.Title = "插入图片";
				openFileDialog.ShowReadOnly = false;
				openFileDialog.ShowHelp = false;
				openFileDialog.CheckFileExists = true;
				openFileDialog.ReadOnlyChecked = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					Param1 = openFileDialog.FileName;
					Param2 = "";
					return Execute();
				}
			}
			return false;
		}

		public override ZYEditorAction Clone()
		{
			A_InsertImage a_InsertImage = new A_InsertImage();
			a_InsertImage.BaseCloneFrom(this);
			return a_InsertImage;
		}
	}
}
