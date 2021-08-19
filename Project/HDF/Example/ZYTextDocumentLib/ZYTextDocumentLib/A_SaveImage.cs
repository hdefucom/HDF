using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class A_SaveImage : ZYEditorAction
	{
		public override string ActionName()
		{
			return "saveimage";
		}

		public override bool Execute()
		{
			Bitmap preViewImage = myOwnerDocument.GetPreViewImage();
			if (preViewImage != null)
			{
				preViewImage.Save(Param1, ImageFormat.Png);
				preViewImage.Dispose();
				return true;
			}
			return false;
		}

		public override bool UIExecute()
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.FileName = myOwnerDocument.Info.FileName;
				saveFileDialog.CheckFileExists = false;
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.Filter = "PNG图片|*.png|所有文件|*.*";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					CommandLine commandLine = new CommandLine();
					commandLine.Writer = new StreamWriter(saveFileDialog.FileName + ".txt");
					myOwnerDocument.View.CommandOutPut = commandLine;
					commandLine.BeginWrite();
					myOwnerDocument.View.WriteCreateCommand();
					bool flag = false;
					string fileName = saveFileDialog.FileName;
					fileName = saveFileDialog.FileName;
					if (fileName.IndexOf(".") > 0)
					{
						fileName = fileName.Substring(0, fileName.IndexOf("."));
					}
					for (int i = 0; i < myOwnerDocument.Pages.Count; i++)
					{
						commandLine.CommandName = "page";
						commandLine.SetSize(myOwnerDocument.Pages.PaperWidth, myOwnerDocument.Pages.PaperHeight);
						commandLine.Write();
						using (Bitmap bitmap = myOwnerDocument.GetPreViewImage(i))
						{
							bitmap?.Save(fileName + "_" + i + ".png", ImageFormat.Png);
						}
					}
					myOwnerDocument.View.CommandOutPut = null;
					commandLine.EndWrite();
					commandLine.Writer.Close();
					return true;
				}
			}
			return false;
		}
	}
}
